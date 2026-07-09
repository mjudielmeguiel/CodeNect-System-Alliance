Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Text.RegularExpressions

Public Class Account_Recovery

    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub Account_Recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateRecoveryID()
        txtReason.Multiline = True
        txtReason.ScrollBars = ScrollBars.Vertical
        txtNewPassword.PasswordChar = "●"c
        txtConfirmPassword.PasswordChar = "●"c
    End Sub

    ' --- ✅ BINAGO: 6 DIGITS LANG ANG RECOVERY ID ---
    Private Sub GenerateRecoveryID()
        Dim rnd As New Random()
        ' Bumubuo ng numero mula 100000 hanggang 999999
        Dim num As Integer = rnd.Next(100000, 999999)
        txtRecoveryID.Text = num.ToString()
        txtRecoveryID.ReadOnly = True
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        Dim emailInput As String = txtEmail.Text.Trim()
        If Regex.IsMatch(emailInput, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            GetUsernameFromEmail(emailInput)
        Else
            txtUsername.Clear()
            txtUsername.ReadOnly = False
        End If
    End Sub

    Private Sub GetUsernameFromEmail(email As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT TOP 1 USERNAME FROM User_Accounts WHERE EMAIL = @EMAIL", conn)
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100).Value = email

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    txtUsername.Text = result.ToString().Trim()
                    txtUsername.ReadOnly = True
                Else
                    txtUsername.Text = "Not found"
                    txtUsername.ReadOnly = False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading username: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged
        CheckPasswordStrength(txtNewPassword.Text)
    End Sub

    Private Sub CheckPasswordStrength(pass As String)
        Dim hasUpper As Boolean = Regex.IsMatch(pass, "[A-Z]")
        Dim hasLower As Boolean = Regex.IsMatch(pass, "[a-z]")
        Dim hasNumber As Boolean = Regex.IsMatch(pass, "[0-9]")

        If String.IsNullOrWhiteSpace(pass) Then
            lblPasswordverification.Text = ""
            lblPasswordverification.ForeColor = Color.Black
        ElseIf pass.Length < 8 Then
            lblPasswordverification.Text = " Minimum 8 characters"
            lblPasswordverification.ForeColor = Color.OrangeRed
        ElseIf Not hasUpper Then
            lblPasswordverification.Text = " Must include uppercase letter (A-Z)"
            lblPasswordverification.ForeColor = Color.Red
        ElseIf Not hasLower Then
            lblPasswordverification.Text = " Must include lowercase letter (a-z)"
            lblPasswordverification.ForeColor = Color.Red
        ElseIf Not hasNumber Then
            lblPasswordverification.Text = " Add numbers for stronger password"
            lblPasswordverification.ForeColor = Color.Blue
        Else
            lblPasswordverification.Text = " Strong password"
            lblPasswordverification.ForeColor = Color.Green
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtRecoveryID.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtNewPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtReason.Text) Then

            MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim pass As String = txtNewPassword.Text
        If pass.Length < 8 OrElse Not Regex.IsMatch(pass, "[A-Z]") OrElse Not Regex.IsMatch(pass, "[a-z]") Then
            MessageBox.Show("Password must be at least 8 characters long, with both uppercase and lowercase letters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Recovery (RECOVERY_ID, EMAIL, USERNAME, PASSWORD, REASON)
                                           VALUES (@RID, @EMAIL, @USER, @PASS, @REASON)", conn)

                cmd.Parameters.Add("@RID", SqlDbType.NVarChar, 6).Value = txtRecoveryID.Text.Trim()
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100).Value = txtEmail.Text.Trim()
                cmd.Parameters.Add("@USER", SqlDbType.NVarChar, 50).Value = txtUsername.Text.Trim()
                cmd.Parameters.Add("@PASS", SqlDbType.NVarChar, 255).Value = txtNewPassword.Text
                cmd.Parameters.Add("@REASON", SqlDbType.NVarChar, 500).Value = txtReason.Text.Trim()

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Recovery request submitted successfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class