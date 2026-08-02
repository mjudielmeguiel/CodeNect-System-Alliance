Imports System.Text.RegularExpressions
Imports BCrypt.Net.BCrypt
Imports MySqlConnector
Imports Org.BouncyCastle.Crypto.Generators

Public Class Account_Recovery

    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub Account_Recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateRecoveryID()
        txtReason.Multiline = True
        txtReason.ScrollBars = ScrollBars.Vertical
        txtNewPassword.PasswordChar = "●"c
        txtConfirmPassword.PasswordChar = "●"c
        AuditLogger.LogAction("OPEN", "Account Recovery", "Opened password recovery form")
    End Sub

    Private Sub GenerateRecoveryID()
        Dim rnd As New Random()
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
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT `USERNAME` FROM `user_accounts` WHERE `EMAIL` = @EMAIL LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@EMAIL", email)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    txtUsername.Text = result.ToString().Trim()
                    txtUsername.ReadOnly = True
                Else
                    txtUsername.Text = "Not found"
                    txtUsername.ReadOnly = False
                    AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Email not found: {email}")
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

    ' ✅ TANGGAL NA ANG DOBLE NA EVENT — ITO NA ANG TAMANG MAY "Handles btnSave.Click"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation muna
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
            AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Password mismatch for user: {txtUsername.Text.Trim()}")
            Return
        End If

        Dim pass As String = txtNewPassword.Text
        If pass.Length < 8 OrElse Not Regex.IsMatch(pass, "[A-Z]") OrElse Not Regex.IsMatch(pass, "[a-z]") Then
            MessageBox.Show("Password must be at least 8 characters long, with both uppercase and lowercase letters.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            AuditLogger.LogAction("RECOVERY_FAILED", "Account Recovery", $"Weak password attempt for user: {txtUsername.Text.Trim()}")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                ' ✅ TUGMA NA SA PANGALAN NG KOLUM — GAMIT ANG "USERNAME" HINDI "USER_NAME"
                Dim cmd As New MySqlCommand("
                    INSERT INTO `Recovery` (
                        `RECOVERY_ID`, `EMAIL`, `USERNAME`, `NEW_PASSWORD`, `REASON`, `DATEREQUESTED`
                    ) VALUES (
                        @RID, @EMAIL, @USER, @PASS, @REASON, NOW()
                    )", conn)

                cmd.Parameters.AddWithValue("@RID", txtRecoveryID.Text.Trim())
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@USER", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@PASS", BCrypt.Net.BCrypt.HashPassword(pass))
                cmd.Parameters.AddWithValue("@REASON", txtReason.Text.Trim())

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Recovery request submitted successfully!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("RECOVERY_SUBMIT", "Account Recovery", $"Recovery request submitted | ID: {txtRecoveryID.Text} | User: {txtUsername.Text.Trim()}")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        AuditLogger.LogAction("CANCEL", "Account Recovery", "User cancelled recovery request")
        Me.Close()
    End Sub

End Class