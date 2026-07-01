Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Register_account

    Private Sub Register_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAccountID.Text = GenerateRandomID()
        txtAccountID.ForeColor = Color.Black
        txtAccountID.ReadOnly = True

        txtAccount.Text = "Enter Account Name"
        txtAccount.ForeColor = Color.Gray

        txtAddress.Text = "Enter Complete Address"
        txtAddress.ForeColor = Color.Gray

        txtContact.Text = "Enter Contact Number"
        txtContact.ForeColor = Color.Gray

        txtEmail.Text = "Enter Email Address"
        txtEmail.ForeColor = Color.Gray

        txtUsername.Text = "Enter Username"
        txtUsername.ForeColor = Color.Gray

        txtPassword.Text = "Enter Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing

        txtConfirmPassword.Text = "Confirm Password"
        txtConfirmPassword.ForeColor = Color.Gray
        txtConfirmPassword.PasswordChar = Nothing
    End Sub

    Private Function GenerateRandomID() As String
        Dim rnd As New Random()
        Return rnd.Next(100000, 999999).ToString()
    End Function

    Private Sub RefreshAccountID()
        txtAccountID.Text = GenerateRandomID()
    End Sub

    Private Function IsPasswordStrong(password As String) As Boolean
        Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$"
        Return Regex.IsMatch(password, pattern)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtAccount.Text = "" Or txtAccount.Text = "Enter Account Name" Or
           txtAddress.Text = "" Or txtAddress.Text = "Enter Complete Address" Or
           txtContact.Text = "" Or txtContact.Text = "Enter Contact Number" Or
           txtEmail.Text = "" Or txtEmail.Text = "Enter Email Address" Or
           txtUsername.Text = "" Or txtUsername.Text = "Enter Username" Or
           txtPassword.Text = "" Or txtPassword.Text = "Enter Password" Or
           txtConfirmPassword.Text = "" Or txtConfirmPassword.Text = "Confirm Password" Then

            MessageBox.Show("Please fill in all required fields.", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsPasswordStrong(txtPassword.Text.Trim()) Then
            MessageBox.Show("Weak Password!" & vbCrLf &
                          "Must contain:" & vbCrLf &
                          "• Uppercase (A-Z)" & vbCrLf &
                          "• Lowercase (a-z)" & vbCrLf &
                          "• Number (0-9)" & vbCrLf &
                          "• Special character (!@#$%^&*)", "REQUIREMENT NOT MET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Clear()
            txtConfirmPassword.Clear()
            Exit Sub
        End If

        If txtPassword.Text.Trim() <> txtConfirmPassword.Text.Trim() Then
            MessageBox.Show("Passwords do not match.", "MISMATCH", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Clear()
            txtConfirmPassword.Clear()
            Exit Sub
        End If

        Try
            Using connCheck As New SqlConnection(connStr)
                connCheck.Open()

                Dim cmdUser As New SqlCommand("SELECT COUNT(*) FROM adm.Account WHERE USERNAME=@VAL", connCheck)
                cmdUser.Parameters.AddWithValue("@VAL", txtUsername.Text.Trim().ToUpper())
                If CInt(cmdUser.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists.", "DUPLICATE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim cmdEmail As New SqlCommand("SELECT COUNT(*) FROM adm.Account WHERE EMAIL=@VAL", connCheck)
                cmdEmail.Parameters.AddWithValue("@VAL", txtEmail.Text.Trim().ToLower())
                If CInt(cmdEmail.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Email already exists.", "DUPLICATE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmail.Focus()
                    Exit Sub
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Try
            Dim CurrentNow As DateTime = Date.Now
            Dim newAccountID As String = txtAccountID.Text

            Dim cmdInsert As String = "INSERT INTO adm.Account (ACCOUNT_ID, ACCOUNT, ADDRESS, CONTACT, EMAIL, USERNAME, PASSWORD, STATUS, CREATE_AT) " &
                                       "VALUES (@AID, @ACC, @ADDR, @CONT, @EMAIL, @USER, @PASS, 'OFFLINE', @CRT)"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(cmdInsert, conn)
                    cmd.Parameters.AddWithValue("@AID", newAccountID)
                    cmd.Parameters.AddWithValue("@ACC", txtAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@ADDR", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@CONT", txtContact.Text.Trim())
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim().ToLower())
                    cmd.Parameters.AddWithValue("@USER", txtUsername.Text.Trim().ToUpper())
                    cmd.Parameters.AddWithValue("@PASS", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@CRT", CurrentNow)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("SUCCESS! Account created." & vbCrLf & "Account ID: " & newAccountID, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            RefreshAccountID()

        Catch ex As Exception
            MessageBox.Show("ERROR SAVING: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtAccount.Text = "Enter Account Name"
        txtAccount.ForeColor = Color.Gray

        txtAddress.Text = "Enter Complete Address"
        txtAddress.ForeColor = Color.Gray

        txtContact.Text = "Enter Contact Number"
        txtContact.ForeColor = Color.Gray

        txtEmail.Text = "Enter Email Address"
        txtEmail.ForeColor = Color.Gray

        txtUsername.Text = "Enter Username"
        txtUsername.ForeColor = Color.Gray

        txtPassword.Text = "Enter Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing

        txtConfirmPassword.Text = "Confirm Password"
        txtConfirmPassword.ForeColor = Color.Gray
        txtConfirmPassword.PasswordChar = Nothing
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#Region "Placeholder Text Handling"
    Private Sub txtAccount_GotFocus(sender As Object, e As EventArgs) Handles txtAccount.GotFocus
        If txtAccount.Text = "Enter Account Name" Then
            txtAccount.Text = ""
            txtAccount.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtAccount_LostFocus(sender As Object, e As EventArgs) Handles txtAccount.LostFocus
        If String.IsNullOrWhiteSpace(txtAccount.Text) Then
            txtAccount.Text = "Enter Account Name"
            txtAccount.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtAddress_GotFocus(sender As Object, e As EventArgs) Handles txtAddress.GotFocus
        If txtAddress.Text = "Enter Complete Address" Then
            txtAddress.Text = ""
            txtAddress.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtAddress_LostFocus(sender As Object, e As EventArgs) Handles txtAddress.LostFocus
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            txtAddress.Text = "Enter Complete Address"
            txtAddress.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtContact_GotFocus(sender As Object, e As EventArgs) Handles txtContact.GotFocus
        If txtContact.Text = "Enter Contact Number" Then
            txtContact.Text = ""
            txtContact.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtContact_LostFocus(sender As Object, e As EventArgs) Handles txtContact.LostFocus
        If String.IsNullOrWhiteSpace(txtContact.Text) Then
            txtContact.Text = "Enter Contact Number"
            txtContact.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtEmail_GotFocus(sender As Object, e As EventArgs) Handles txtEmail.GotFocus
        If txtEmail.Text = "Enter Email Address" Then
            txtEmail.Text = ""
            txtEmail.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtEmail_LostFocus(sender As Object, e As EventArgs) Handles txtEmail.LostFocus
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            txtEmail.Text = "Enter Email Address"
            txtEmail.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Enter Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            txtUsername.Text = "Enter Username"
            txtUsername.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Enter Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "*"
        End If
    End Sub
    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            txtPassword.Text = "Enter Password"
            txtPassword.ForeColor = Color.Gray
            txtPassword.PasswordChar = Nothing
        End If
    End Sub

    Private Sub txtConfirmPassword_GotFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.GotFocus
        If txtConfirmPassword.Text = "Confirm Password" Then
            txtConfirmPassword.Text = ""
            txtConfirmPassword.ForeColor = Color.Black
            txtConfirmPassword.PasswordChar = "*"
        End If
    End Sub
    Private Sub txtConfirmPassword_LostFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.LostFocus
        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            txtConfirmPassword.Text = "Confirm Password"
            txtConfirmPassword.ForeColor = Color.Gray
            txtConfirmPassword.PasswordChar = Nothing
        End If
    End Sub
#End Region
End Class