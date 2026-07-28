Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports MySqlConnector

Public Class Register_account

    Private Sub Register_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAccountID.Text = GenerateRandomID()
        txtAccountID.ForeColor = Color.Black
        txtAccountID.ReadOnly = True

        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c

        ' ✅ LOAD BUSINESS TYPE OPTIONS
        LoadBusinessTypeOptions()
    End Sub

    ' ==================== BUSINESS TYPE DROPDOWN ====================
    Private Sub LoadBusinessTypeOptions()
        cboBusinessType.DropDownStyle = ComboBoxStyle.DropDownList
        cboBusinessType.Items.Clear()
        cboBusinessType.Items.AddRange({
            "Sole Proprietorship",
            "Partnership",
            "Corporation",
            "Cooperative",
            "Freelancer / Self-Employed"
        })
    End Sub

    ' ==================== HELPER FUNCTIONS ====================
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

    ' ==================== SAVE BUTTON (FIXED COLUMN NAMES) ====================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not DBConnection.TestConnection() Then Exit Sub

        ' ✅ REQUIRED FIELDS VALIDATION
        If String.IsNullOrWhiteSpace(txtAccountID.Text) OrElse
           String.IsNullOrWhiteSpace(txtAccount.Text) OrElse
           String.IsNullOrWhiteSpace(txtOwnerFullName.Text) OrElse
           cboBusinessType.SelectedIndex = -1 OrElse
           String.IsNullOrWhiteSpace(txtContact.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then

            MessageBox.Show("Please fill in all required basic information.", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ✅ PASSWORD STRENGTH CHECK
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

        ' ✅ CHECK FOR DUPLICATE USERNAME & EMAIL
        Try
            Using connCheck As New MySqlConnection(DBConnection.connStr)
                connCheck.Open()

                ' Check duplicate Username
                Dim cmdUser As New MySqlCommand("SELECT COUNT(*) FROM `account` WHERE `USERNAME`=@VAL", connCheck)
                cmdUser.Parameters.AddWithValue("@VAL", txtUsername.Text.Trim().ToUpper())
                If CInt(cmdUser.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists.", "DUPLICATE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Check duplicate Email
                Dim cmdEmail As New MySqlCommand("SELECT COUNT(*) FROM `account` WHERE `EMAIL`=@VAL", connCheck)
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

        ' ✅ INSERT RECORD – FIXED COLUMN MISMATCHES
        Try
            Dim CurrentNow As DateTime = Date.Now
            Dim newAccountID As String = txtAccountID.Text

            ' ⚠️ UPDATE COLUMN NAMES HERE IF YOUR TABLE USES DIFFERENT ONES
            Dim cmdInsert As String = "INSERT INTO `account` 
            (`ACCOUNT_ID`, `BUSINESS_NAME`, `OWNER_FULLNAME`, `BUSINESS_TYPE`, `CONTACT`, `EMAIL`, `USERNAME`, `PASSWORD`, `STATUS`, `CREATED_AT`) 
            VALUES (@AID, @ACC, @OWNER, @BTYPE, @CONT, @EMAIL, @USER, @PASS, 'PENDING', @CRT)"

            Using conn As New MySqlConnection(DBConnection.connStr)
                Using cmd As New MySqlCommand(cmdInsert, conn)
                    cmd.Parameters.AddWithValue("@AID", newAccountID)
                    cmd.Parameters.AddWithValue("@ACC", txtAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@OWNER", txtOwnerFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@BTYPE", cboBusinessType.Text)
                    cmd.Parameters.AddWithValue("@CONT", txtContact.Text.Trim())
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim().ToLower())
                    cmd.Parameters.AddWithValue("@USER", txtUsername.Text.Trim().ToUpper())
                    cmd.Parameters.AddWithValue("@PASS", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@CRT", CurrentNow)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("SUCCESS! Basic Business Account Created." & vbCrLf &
                            "Account ID: " & newAccountID & vbCrLf & vbCrLf &
                            "Full verification & documents can be submitted later.",
                            "ACCOUNT CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            RefreshAccountID()

        Catch ex As Exception
            MessageBox.Show("ERROR SAVING: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==================== CLEAR ALL INPUT FIELDS ====================
    Private Sub ClearFields()
        txtAccount.Clear()
        txtOwnerFullName.Clear()
        cboBusinessType.SelectedIndex = -1
        txtContact.Clear()
        txtEmail.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
    End Sub

    ' ==================== CANCEL BUTTON ====================
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class