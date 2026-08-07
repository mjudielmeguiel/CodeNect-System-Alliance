Imports System.Text.RegularExpressions
Imports BCrypt.Net.BCrypt
Imports MySqlConnector

Public Class Account_Recovery

    Private ReadOnly connStr As String = DBConnection.connStr
    Private currentRecoveryID As String = String.Empty
    Private userAccountID As String = String.Empty
    Private userBranchID As String = String.Empty

    Private Sub Account_Recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateRecoveryID()
        LoadRecoveryReasons()
        txtNewPassword.PasswordChar = "●"c
        txtConfirmPassword.PasswordChar = "●"c
        lblPasswordverification.Text = String.Empty
    End Sub

    Private Sub GenerateRecoveryID()
        Dim rnd As New Random()
        currentRecoveryID = rnd.Next(100000, 999999).ToString()
    End Sub

    Private Sub LoadRecoveryReasons()
        cboReason.DropDownStyle = ComboBoxStyle.DropDownList
        cboReason.Items.Clear()
        cboReason.Items.AddRange({
            "Forgot my password",
            "Account locked out",
            "Password compromised",
            "Security concern",
            "Unauthorized access attempt",
            "Other reason"
        })
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        Dim emailInput As String = txtEmail.Text.Trim()
        If Regex.IsMatch(emailInput, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            FetchUserRegistrationDetails(emailInput)
        Else
            txtUsername.Clear()
            userAccountID = String.Empty
            userBranchID = String.Empty
            txtUsername.ReadOnly = False
        End If
    End Sub

    Private Sub FetchUserRegistrationDetails(email As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT `username`, `account_id`, `branch_id` FROM `account` WHERE `email` = @EMAIL LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@EMAIL", email.Trim().ToLower())

                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        txtUsername.Text = dr("username").ToString().Trim()
                        userAccountID = dr("account_id").ToString().Trim()
                        userBranchID = If(dr.IsDBNull(dr.GetOrdinal("branch_id")), String.Empty, dr("branch_id").ToString().Trim())
                        txtUsername.ReadOnly = True
                    Else
                        txtUsername.Text = "Not Found"
                        userAccountID = String.Empty
                        userBranchID = String.Empty
                        txtUsername.ReadOnly = False
                        AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Email not found in records: {email}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading details: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged
        CheckPasswordStrength(txtNewPassword.Text)
    End Sub

    Private Sub CheckPasswordStrength(pass As String)
        Dim metCount As Integer = 0
        If Regex.IsMatch(pass, "[A-Z]") Then metCount += 1
        If Regex.IsMatch(pass, "[a-z]") Then metCount += 1
        If Regex.IsMatch(pass, "[0-9]") Then metCount += 1
        If Regex.IsMatch(pass, "[^a-zA-Z0-9]") Then metCount += 1

        If String.IsNullOrWhiteSpace(pass) Then
            lblPasswordverification.Text = String.Empty
        ElseIf pass.Length < 8 Then
            lblPasswordverification.Text = "At least 8 characters long"
            lblPasswordverification.ForeColor = Color.OrangeRed
        ElseIf metCount < 3 Then
            lblPasswordverification.Text = $"Need at least 3 types (you have {metCount})"
            lblPasswordverification.ForeColor = Color.DarkOrange
        Else
            lblPasswordverification.Text = "Password meets requirements"
            lblPasswordverification.ForeColor = Color.Green
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(userAccountID) OrElse
           String.IsNullOrWhiteSpace(txtNewPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) OrElse
           cboReason.SelectedIndex = -1 Then

            MessageBox.Show("Please fill all required fields.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtNewPassword.Text.Trim() <> txtConfirmPassword.Text.Trim() Then
            MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Mismatch for: {txtUsername.Text.Trim()}")
            Return
        End If

        Dim pass As String = txtNewPassword.Text.Trim()
        Dim metCount As Integer = 0
        If Regex.IsMatch(pass, "[A-Z]") Then metCount += 1
        If Regex.IsMatch(pass, "[a-z]") Then metCount += 1
        If Regex.IsMatch(pass, "[0-9]") Then metCount += 1
        If Regex.IsMatch(pass, "[^a-zA-Z0-9]") Then metCount += 1

        If pass.Length < 8 OrElse metCount < 3 Then
            MessageBox.Show("Password must be at least 8 characters with at least 3 of: uppercase, lowercase, number, special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Weak password for: {txtUsername.Text.Trim()}")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    INSERT INTO `recovery` (
                        `RECOVERY_ID`, `USERNAME`, `ACCOUNT_ID`, `BRANCH_ID`, `EMAIL`, `NEW_PASSWORD`, `REASON`, `STATUS`, `DATEREQUESTED`
                    ) VALUES (
                        @RID, @USER, @ACCID, @BRNID, @EMAIL, @PASS, @REASON, 'PENDING', NOW()
                    )", conn)

                cmd.Parameters.AddWithValue("@RID", currentRecoveryID)
                cmd.Parameters.AddWithValue("@USER", txtUsername.Text.Trim().ToUpper())
                cmd.Parameters.AddWithValue("@ACCID", userAccountID)
                cmd.Parameters.AddWithValue("@BRNID", If(String.IsNullOrEmpty(userBranchID), DBNull.Value, userBranchID))
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim().ToLower())
                cmd.Parameters.AddWithValue("@PASS", BCrypt.Net.BCrypt.HashPassword(pass))
                cmd.Parameters.AddWithValue("@REASON", cboReason.Text)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Request submitted successfully!" & vbCrLf & "Waiting for admin approval.", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("RECOVERY_SUBMIT", "Account Recovery", $"ID:{currentRecoveryID} | Account:{userAccountID} | Branch:{userBranchID} | User:{txtUsername.Text.Trim()}")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class