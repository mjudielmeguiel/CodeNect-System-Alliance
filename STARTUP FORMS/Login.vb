Imports System.IO
Imports System.Xml
Imports MySqlConnector

Public Class Login

    Public Shared LoggedInBranchID As String = ""
    Public Shared LoggedInAccountID As String = ""
    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUsername As String = ""
    Public Shared LoggedInUserType As String = ""

    Const maxAttempts As Integer = 3
    Private Const PLACEHOLDER_USER As String = "Enter Username"
    Private Const PLACEHOLDER_PASS As String = "Enter Password"

    ' ✅ BAGO: AWTOMATIKONG ILIPAT SA OFFLINE ANG USER BAGO MAG-LOGIN
    Private Sub SetUserOfflineByUsername(targetUsername As String, conn As MySqlConnection)
        Try
            ' ✅ User Accounts Table
            Using cmd1 As New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='OFFLINE' WHERE TRIM(`USERNAME`)=TRIM(@U)", conn)
                cmd1.Parameters.AddWithValue("@U", targetUsername)
                cmd1.ExecuteNonQuery()
            End Using
            ' ✅ Admin Account Table
            Using cmd2 As New MySqlCommand("UPDATE `account` SET `STATUS`='OFFLINE' WHERE TRIM(`USERNAME`)=TRIM(@U)", conn)
                cmd2.Parameters.AddWithValue("@U", targetUsername)
                cmd2.ExecuteNonQuery()
            End Using
            ' ✅ Vendor Account Table
            Using cmd3 As New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='OFFLINE' WHERE TRIM(`USERNAME`)=TRIM(@U)", conn)
                cmd3.Parameters.AddWithValue("@U", targetUsername)
                cmd3.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            AuditLogger.LogAction("STATUS_UPDATE", "Authentication", $"Auto-offline failed: {ex.Message}")
        End Try
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(LoggedInUserID) OrElse Not String.IsNullOrEmpty(LoggedInAccountID) Then
            Try
                Using conn As New MySqlConnection(DBConnection.connStr)
                    conn.Open()
                    ' ✅ USER → user_accounts → gamit ang ID
                    If Not String.IsNullOrEmpty(LoggedInUserID) AndAlso LoggedInUserType = "USER" Then
                        Using cmd As New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='OFFLINE' WHERE `ID`=@id", conn)
                            cmd.Parameters.AddWithValue("@id", LoggedInUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    ' ✅ ADMIN → account → gamit ang ACCOUNT_ID (HINDI ID!)
                    If Not String.IsNullOrEmpty(LoggedInAccountID) AndAlso LoggedInUserType = "BUSINESS ADMIN" Then
                        Using cmd As New MySqlCommand("UPDATE `account` SET `STATUS`='OFFLINE' WHERE `ACCOUNT_ID`=@aid", conn)
                            cmd.Parameters.AddWithValue("@aid", LoggedInAccountID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    ' ✅ VENDOR → vendor_account → gamit ang ID
                    If Not String.IsNullOrEmpty(LoggedInUserID) AndAlso LoggedInUserType = "VENDOR" Then
                        Using cmd As New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='OFFLINE' WHERE `ID`=@id", conn)
                            cmd.Parameters.AddWithValue("@id", LoggedInUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
                AuditLogger.LogAction("LOGOUT", "Authentication", $"User [{LoggedInUsername}] logged out")
            Catch ex As Exception
                AuditLogger.LogAction("ERROR", "Authentication", $"Logout status update failed: {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        lblError.Text = ""
        If txt.Text = PLACEHOLDER_USER OrElse txt.Text = PLACEHOLDER_PASS Then
            txt.Text = ""
            txt.ForeColor = Color.Black
            If txt.Name = "txtPassword" Then txt.PasswordChar = "●"c
        End If
    End Sub

    Private Sub txt_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus, txtPassword.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            If txt.Name = "txtUsername" Then
                txt.Text = PLACEHOLDER_USER
                txt.ForeColor = Color.Gray
            Else
                txt.Text = PLACEHOLDER_PASS
                txt.ForeColor = Color.Gray
                txt.PasswordChar = Nothing
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        AuditLogger.LogAction("OPEN", "Authentication", "Opened Register Account form")
        Register_account.Show()
        Me.Hide()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        lblError.Text = ""
        Dim username As String = If(txtUsername.Text = PLACEHOLDER_USER, "", txtUsername.Text.Trim())
        Dim password As String = If(txtPassword.Text = PLACEHOLDER_PASS, "", txtPassword.Text.Trim())

        If String.IsNullOrWhiteSpace(username) Then
            lblError.Text = "Please enter your Username"
            lblError.ForeColor = Color.OrangeRed
            txtUsername.Focus()
            AuditLogger.LogAction("LOGIN_VALIDATION", "Authentication", "Login attempt with empty username")
            Return
        End If
        If String.IsNullOrWhiteSpace(password) Then
            lblError.Text = "Please enter your Password"
            lblError.ForeColor = Color.OrangeRed
            txtPassword.Focus()
            AuditLogger.LogAction("LOGIN_VALIDATION", "Authentication", $"Login attempt with empty password for username: [{username}]")
            Return
        End If

        Try
            Dim userFound As Boolean = False
            Dim loginSuccess As Boolean = False

            Using connUser As New MySqlConnection(DBConnection.connStr)
                connUser.Open()

                ' ✅ BAGO: I-OFFLINE MUNA ANG USERNAME BAGO MAG-CHECK
                SetUserOfflineByUsername(username, connUser)

                Dim qUser As String = "SELECT `ID`, `ACCOUNT_ID`, `BRANCH_ID`, `USER_TYPE`, `STATUS`, `USERNAME`, `PASSWORD`, `login_attempts` 
                                       FROM `user_accounts` 
                                       WHERE TRIM(`USERNAME`) = TRIM(@u) 
                                       OR TRIM(LOWER(`USERNAME`)) = TRIM(LOWER(@u)) 
                                       LIMIT 1"

                Using cmdUser As New MySqlCommand(qUser, connUser)
                    cmdUser.Parameters.AddWithValue("@u", username)
                    Using drUser = cmdUser.ExecuteReader()
                        If drUser.Read() Then
                            userFound = True
                            Dim uid = drUser("ID").ToString()
                            Dim aid = drUser("ACCOUNT_ID").ToString()
                            Dim bid = drUser("BRANCH_ID").ToString()
                            Dim utype = drUser("USER_TYPE").ToString()
                            Dim stat = drUser("STATUS").ToString().ToUpper()
                            Dim uname = drUser("USERNAME").ToString()
                            Dim pass = drUser("PASSWORD").ToString()
                            Dim attempts = Convert.ToInt32(drUser("login_attempts"))
                            drUser.Close()

                            ' ✅ STATUS AY OFFLINE NA DAHIL SA SETUserOfflineByUsername
                            ' KAYA HINDI NA LALABAS ANG "Already logged in"
                            If stat = "LOCKED" Then
                                lblError.Text = "Account is LOCKED."
                                lblError.ForeColor = Color.Red
                                AuditLogger.LogAction("LOGIN_DENIED", "Authentication", $"Login rejected for [{uname}] – account locked")
                                Return
                            End If

                            If pass = password Then
                                Using upd = New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='ACTIVE', `login_attempts`=0 WHERE `ID`=@id", connUser)
                                    upd.Parameters.AddWithValue("@id", uid)
                                    upd.ExecuteNonQuery()
                                End Using

                                LoggedInUserID = uid
                                LoggedInAccountID = aid
                                LoggedInBranchID = bid
                                LoggedInUserType = utype
                                LoggedInUsername = uname

                                DBConnection.CurrentUserAccountID = aid
                                DBConnection.CurrentUserBranchID = bid
                                DBConnection.CurrentLoggedInUser = uname
                                DBConnection.CurrentUserType = utype

                                AuditLogger.LogAction("LOGIN_SUCCESS", "Authentication", $"User [{LoggedInUsername}] | Type: {LoggedInUserType} | Branch: {LoggedInBranchID} | Account: {LoggedInAccountID}")

                                If utype.Trim.ToUpper = "CASHIER" Then
                                    frmPOS_System.Show()
                                Else
                                    frmDashboard.Show()
                                End If

                                Me.Hide()
                                loginSuccess = True
                            Else
                                attempts += 1
                                AuditLogger.LogAction("LOGIN_FAILED", "Authentication", $"User [{username}] | Wrong Password | Attempt {attempts}/{maxAttempts}")

                                If attempts >= maxAttempts Then
                                    Using lck = New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='LOCKED', `login_attempts`=@att WHERE `ID`=@id", connUser)
                                        lck.Parameters.AddWithValue("@att", attempts)
                                        lck.Parameters.AddWithValue("@id", uid)
                                        lck.ExecuteNonQuery()
                                    End Using
                                    lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                    lblError.ForeColor = Color.Red
                                    AuditLogger.LogAction("ACCOUNT_LOCKED", "Authentication", $"User [{username}] locked after {attempts} failed attempts")
                                Else
                                    Using updAtt = New MySqlCommand("UPDATE `user_accounts` SET `login_attempts`=@att WHERE `ID`=@id", connUser)
                                        updAtt.Parameters.AddWithValue("@att", attempts)
                                        updAtt.Parameters.AddWithValue("@id", uid)
                                        updAtt.ExecuteNonQuery()
                                    End Using
                                    lblError.Text = "Wrong Password. Attempts left: " & (maxAttempts - attempts)
                                    lblError.ForeColor = Color.OrangeRed
                                End If
                                Return
                            End If
                        End If
                    End Using
                End Using
            End Using

            If loginSuccess Then Return

            Using connAdmin As New MySqlConnection(DBConnection.connStr)
                connAdmin.Open()

                ' ✅ BAGO: I-OFFLINE MUNA BAGO MAG-CHECK
                SetUserOfflineByUsername(username, connAdmin)

                Dim qAdmin As String = "SELECT `ACCOUNT_ID`, `STATUS`, `OWNER_FULLNAME`, `USERNAME`, `PASSWORD`, `login_attempts` 
                                        FROM `account` 
                                        WHERE TRIM(`USERNAME`) = TRIM(@u) 
                                        OR TRIM(LOWER(`USERNAME`)) = TRIM(LOWER(@u)) 
                                        LIMIT 1"

                Using cmdAdmin As New MySqlCommand(qAdmin, connAdmin)
                    cmdAdmin.Parameters.AddWithValue("@u", username)
                    Using drAdmin = cmdAdmin.ExecuteReader()
                        If drAdmin.Read() Then
                            userFound = True
                            Dim aid = drAdmin("ACCOUNT_ID").ToString()
                            Dim stat = drAdmin("STATUS").ToString().ToUpper()
                            Dim name = drAdmin("OWNER_FULLNAME").ToString()
                            Dim pass = drAdmin("PASSWORD").ToString()
                            Dim attempts = Convert.ToInt32(drAdmin("login_attempts"))
                            drAdmin.Close()

                            ' ✅ STATUS AY OFFLINE NA DAHIL SA SETUserOfflineByUsername
                            If stat = "LOCKED" Then
                                lblError.Text = "Account is LOCKED."
                                lblError.ForeColor = Color.Red
                                AuditLogger.LogAction("LOGIN_DENIED", "Authentication", $"Admin [{name}] login rejected – account locked")
                                Return
                            End If
                            If stat = "PENDING" Then
                                lblError.Text = "Account is still PENDING for approval."
                                lblError.ForeColor = Color.Orange
                                AuditLogger.LogAction("LOGIN_DENIED", "Authentication", $"Admin [{name}] login rejected – pending approval")
                                Return
                            End If

                            If pass = password Then
                                Using upd = New MySqlCommand("UPDATE `account` SET `STATUS`='ACTIVE', `login_attempts`=0 WHERE `ACCOUNT_ID`=@id", connAdmin)
                                    upd.Parameters.AddWithValue("@id", aid)
                                    upd.ExecuteNonQuery()
                                End Using

                                LoggedInUserID = aid
                                LoggedInAccountID = aid
                                LoggedInUserType = "BUSINESS ADMIN"
                                LoggedInUsername = name
                                LoggedInBranchID = String.Empty

                                DBConnection.CurrentUserAccountID = aid
                                DBConnection.CurrentUserBranchID = String.Empty
                                DBConnection.CurrentLoggedInUser = name
                                DBConnection.CurrentUserType = "BUSINESS ADMIN"

                                AuditLogger.LogAction("LOGIN_SUCCESS", "Authentication", $"Business Admin [{LoggedInUsername}] | Account ID: {LoggedInAccountID}")

                                frmDashboard.Show()
                                Me.Hide()
                                Return
                            Else
                                attempts += 1
                                AuditLogger.LogAction("LOGIN_FAILED", "Authentication", $"Admin [{username}] | Wrong Password | Attempt {attempts}/{maxAttempts}")

                                If attempts >= maxAttempts Then
                                    Using lck = New MySqlCommand("UPDATE `account` SET `STATUS`='LOCKED', `login_attempts`=@att WHERE `ACCOUNT_ID`=@id", connAdmin)
                                        lck.Parameters.AddWithValue("@att", attempts)
                                        lck.Parameters.AddWithValue("@id", aid)
                                        lck.ExecuteNonQuery()
                                    End Using
                                    lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                    lblError.ForeColor = Color.Red
                                    AuditLogger.LogAction("ACCOUNT_LOCKED", "Authentication", $"Admin [{username}] locked after {attempts} failed attempts")
                                Else
                                    Using updAtt = New MySqlCommand("UPDATE `account` SET `login_attempts`=@att WHERE `ACCOUNT_ID`=@id", connAdmin)
                                        updAtt.Parameters.AddWithValue("@att", attempts)
                                        updAtt.Parameters.AddWithValue("@id", aid)
                                        updAtt.ExecuteNonQuery()
                                    End Using
                                    lblError.Text = "Wrong Password. Attempts left: " & (maxAttempts - attempts)
                                    lblError.ForeColor = Color.OrangeRed
                                End If
                                Return
                            End If
                        End If
                    End Using
                End Using
            End Using

            Using connVendor As New MySqlConnection(DBConnection.connStr)
                connVendor.Open()

                ' ✅ BAGO: I-OFFLINE MUNA BAGO MAG-CHECK
                SetUserOfflineByUsername(username, connVendor)

                Dim qVendor As String = "SELECT `ID`, `VENDOR_CODE`, `VENDOR`, `USERNAME`, `PASSWORD`, `STATUS` 
                                         FROM `vendor_account` 
                                         WHERE TRIM(`USERNAME`) = TRIM(@u) 
                                         OR TRIM(LOWER(`USERNAME`)) = TRIM(LOWER(@u)) 
                                         LIMIT 1"

                Using cmdVendor As New MySqlCommand(qVendor, connVendor)
                    cmdVendor.Parameters.AddWithValue("@u", username)
                    Using drVendor = cmdVendor.ExecuteReader()
                        If drVendor.Read() Then
                            userFound = True
                            Dim vid = drVendor("ID").ToString()
                            Dim vendorCode = drVendor("VENDOR_CODE").ToString()
                            Dim vendorName = drVendor("VENDOR").ToString()
                            Dim uname = drVendor("USERNAME").ToString()
                            Dim pass = drVendor("PASSWORD").ToString()
                            Dim stat = drVendor("STATUS").ToString().ToUpper()
                            drVendor.Close()

                            ' ✅ STATUS AY OFFLINE NA
                            If stat = "LOCKED" Then
                                lblError.Text = "Account is LOCKED."
                                lblError.ForeColor = Color.Red
                                AuditLogger.LogAction("LOGIN_DENIED", "Authentication", $"Vendor [{vendorName}] login rejected – locked")
                                Return
                            End If

                            If pass = password Then
                                Using upd = New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='ACTIVE' WHERE `ID`=@id", connVendor)
                                    upd.Parameters.AddWithValue("@id", vid)
                                    upd.ExecuteNonQuery()
                                End Using

                                LoggedInUserID = vid
                                LoggedInAccountID = ""
                                LoggedInBranchID = "VENDOR"
                                LoggedInUserType = "VENDOR"
                                LoggedInUsername = vendorName

                                DBConnection.CurrentUserAccountID = ""
                                DBConnection.CurrentUserBranchID = "VENDOR"
                                DBConnection.CurrentLoggedInUser = vendorName
                                DBConnection.CurrentUserType = "VENDOR"
                                DBConnection.SetVendorInfo(vendorCode, vendorName)

                                AuditLogger.LogAction("LOGIN_SUCCESS", "Authentication", $"Vendor [{vendorName}] | Code: {vendorCode}")

                                frmVendorDashboard.VendorID = vid
                                frmVendorDashboard.VendorName = vendorName
                                frmVendorDashboard.VendorCode = vendorCode
                                frmVendorDashboard.Show()
                                Me.Hide()
                                Return
                            Else
                                AuditLogger.LogAction("LOGIN_FAILED", "Authentication", $"Vendor [{username}] | Wrong Password")
                                lblError.Text = "Wrong Password."
                                lblError.ForeColor = Color.OrangeRed
                                Return
                            End If
                        End If
                    End Using
                End Using
            End Using

            If Not userFound Then
                AuditLogger.LogAction("LOGIN_FAILED", "Authentication", $"Username not found: [{username}]")
                lblError.Text = "Username does not exist in our records."
                lblError.ForeColor = Color.OrangeRed
            End If

        Catch ex As Exception
            lblError.Text = "System Error: " & ex.Message
            lblError.ForeColor = Color.Red
            AuditLogger.LogAction("SYSTEM_ERROR", "Authentication", $"Login error: {ex.Message}")
        End Try
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = PLACEHOLDER_USER
        txtUsername.ForeColor = Color.Gray
        txtPassword.Text = PLACEHOLDER_PASS
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing
        lblError.Text = ""
        btnlogin.Enabled = True
        AuditLogger.LogAction("OPEN", "Authentication", "Opened Login form")
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        txtPassword.PasswordChar = If(txtPassword.PasswordChar = "●"c, Char.MinValue, "●"c)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Account_Recovery.Show()
    End Sub

End Class