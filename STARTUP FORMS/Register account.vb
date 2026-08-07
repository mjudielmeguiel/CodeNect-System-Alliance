Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports MySqlConnector

Public Class Register_account

    Private Sub Register_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c
        LoadBusinessTypeOptions()
        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Black
    End Sub

    Private Sub LoadBusinessTypeOptions()
        cboBusinessType.DropDownStyle = ComboBoxStyle.DropDownList
        cboBusinessType.Items.Clear()
        cboBusinessType.Items.AddRange({
            "Sole Proprietorship",
            "Partnership",
            "Corporation",
            "Cooperative",
            "Retail Store",
            "Grocery / Supermarket",
            "Franchise Business",
            "Food & Beverage",
            "Wholesale & Distribution",
            "Services & Professional",
            "Freelancer / Self-Employed",
            "Other Business Entity"
        })
    End Sub

    Private Function GenerateAccountID(businessName As String, regDate As DateTime) As String
        Dim prefix As String = If(businessName.Length >= 3, businessName.Substring(0, 3).ToUpper(), businessName.ToUpper().PadRight(3, "0"c))
        Return $"{prefix}-{regDate:yyyyMMddHHmmss}"
    End Function

    Private Function IsPasswordStrong(password As String) As Boolean
        Dim pattern As String = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$"
        Return Regex.IsMatch(password, pattern)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        lblMessage.ForeColor = Color.Black

        If String.IsNullOrWhiteSpace(txtAccount.Text) OrElse
           String.IsNullOrWhiteSpace(txtOwnerFullName.Text) OrElse
           cboBusinessType.SelectedIndex = -1 OrElse
           String.IsNullOrWhiteSpace(txtContact.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then

            lblMessage.Text = "Please complete all required information."
            lblMessage.ForeColor = Color.OrangeRed
            Exit Sub
        End If

        If Not IsPasswordStrong(txtPassword.Text.Trim()) Then
            lblMessage.Text = "Password must contain uppercase, lowercase, numbers, and special characters."
            lblMessage.ForeColor = Color.OrangeRed
            txtPassword.Clear()
            txtConfirmPassword.Clear()
            Exit Sub
        End If

        If txtPassword.Text.Trim() <> txtConfirmPassword.Text.Trim() Then
            lblMessage.Text = "Passwords do not match. Please verify and try again."
            lblMessage.ForeColor = Color.OrangeRed
            txtPassword.Clear()
            txtConfirmPassword.Clear()
            txtPassword.Focus()
            Exit Sub
        End If

        Try
            Using connCheck As New MySqlConnection(DBConnection.connStr)
                connCheck.Open()

                Dim cmdUser As New MySqlCommand("SELECT COUNT(*) FROM `account` WHERE `USERNAME`=@VAL", connCheck)
                cmdUser.Parameters.AddWithValue("@VAL", txtUsername.Text.Trim().ToUpper())
                If CInt(cmdUser.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists.", "DUPLICATE ENTRY", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    AuditLogger.LogAction("REGISTRATION_FAILED", "Account Registration", $"Failed registration: Username [{txtUsername.Text.Trim()}] already exists")
                    Exit Sub
                End If

                Dim cmdEmail As New MySqlCommand("SELECT COUNT(*) FROM `account` WHERE `EMAIL`=@VAL", connCheck)
                cmdEmail.Parameters.AddWithValue("@VAL", txtEmail.Text.Trim().ToLower())
                If CInt(cmdEmail.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Email address already exists.", "DUPLICATE ENTRY", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    AuditLogger.LogAction("REGISTRATION_FAILED", "Account Registration", $"Failed registration: Email [{txtEmail.Text.Trim()}] already exists")
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
            Dim newAccountID As String = GenerateAccountID(txtAccount.Text.Trim(), CurrentNow)

            Dim cmdInsert As String = "INSERT INTO `account` 
            (`account_id`, `account`, `owner_fullname`, `business_type`, `contact`, `email`, `username`, `password`, `status`, `created_at`) 
            VALUES (@AID, @ACC, @OWNER, @BTYPE, @CONT, @EMAIL, @USER, @PASS, 'OFFLINE', @CRT)"

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

            MessageBox.Show("Account created successfully." & vbCrLf & vbCrLf &
                            "Account ID: " & newAccountID & vbCrLf &
                            "Status: OFFLINE",
                            "ACCOUNT REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Information)

            AuditLogger.LogAction("REGISTER", "Account Registration", $"Created new business account | ID: {newAccountID} | Business: {txtAccount.Text.Trim()} | Owner: {txtOwnerFullName.Text.Trim()}")

            ClearFields()
            lblMessage.Text = ""

        Catch ex As Exception
            MessageBox.Show("ERROR SAVING RECORD: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Restart()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRegisterVendor.Show()
    End Sub
End Class