Imports System.IO
Imports System.Xml
Imports MySqlConnector

Public Class Login

    Public Shared LoggedInBranchID As String = ""
    Public Shared LoggedInAccountID As String = ""
    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUsername As String = ""
    Public Shared LoggedInUserType As String = ""
    Public Shared IsAdminAccount As Boolean = False
    Public Shared IsVendorAccount As Boolean = False

    ' ✅ NEW: Scope control
    Public Shared UserScope As String = "" ' "ADMIN" or "BRANCH"

    Const maxAttempts As Integer = 3
    Private Const PLACEHOLDER_USER As String = "Enter Username"
    Private Const PLACEHOLDER_PASS As String = "Enter Password"

    Private Sub SetUserOfflineByUsername_User(targetUsername As String, conn As MySqlConnection)
        Try
            Using cmd1 As New MySqlCommand("UPDATE `user_accounts` SET `status`='OFFLINE' WHERE TRIM(`username`)=TRIM(@U)", conn)
                cmd1.Parameters.AddWithValue("@U", targetUsername)
                cmd1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            AuditLogger.LogAction("STATUS_UPDATE", "Authentication", $"Auto-offline failed (User): {ex.Message}")
        End Try
    End Sub

    Private Sub SetUserOfflineByUsername_Admin(targetUsername As String, conn As MySqlConnection)
        Try
            Using cmd1 As New MySqlCommand("UPDATE `account` SET `status`='OFFLINE' WHERE TRIM(`username`)=TRIM(@U)", conn)
                cmd1.Parameters.AddWithValue("@U", targetUsername)
                cmd1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            AuditLogger.LogAction("STATUS_UPDATE", "Authentication", $"Auto-offline failed (Admin): {ex.Message}")
        End Try
    End Sub

    Private Sub SetUserOfflineByUsername_Vendor(targetUsername As String, conn As MySqlConnection)
        Try
            Using cmd1 As New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='OFFLINE' WHERE TRIM(`USERNAME`)=TRIM(@U)", conn)
                cmd1.Parameters.AddWithValue("@U", targetUsername)
                cmd1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            AuditLogger.LogAction("STATUS_UPDATE", "Authentication", $"Auto-offline failed (Vendor): {ex.Message}")
        End Try
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(LoggedInUserID) Then
            Try
                Using conn As New MySqlConnection(DBConnection.connStr)
                    conn.Open()
                    If IsVendorAccount Then
                        Using cmd As New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='OFFLINE' WHERE `ID`=@id", conn)
                            cmd.Parameters.AddWithValue("@id", LoggedInUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                    ElseIf IsAdminAccount Then
                        Using cmd As New MySqlCommand("UPDATE `account` SET `status`='OFFLINE' WHERE `id`=@id", conn)
                            cmd.Parameters.AddWithValue("@id", LoggedInUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        Using cmd As New MySqlCommand("UPDATE `user_accounts` SET `status`='OFFLINE' WHERE `id`=@id", conn)
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
            Dim isAdmin As Boolean = False
            Dim isVendor As Boolean = False

            Dim uid As String = ""
            Dim aid As String = ""
            Dim bid As String = ""
            Dim roleOrType As String = ""
            Dim stat As String = ""
            Dim uname As String = ""
            Dim pass As String = ""
            Dim attempts As String = "0"
            Dim vendorName As String = ""
            Dim vendorCode As String = ""

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                ' =====================================================
                ' 🎯 CHECK 1: VENDOR ACCOUNT — SEPARATE TABLE
                ' =====================================================
                SetUserOfflineByUsername_Vendor(username, conn)

                Dim qVendor As String = "SELECT `ID`, `USERNAME`, `PASSWORD`, `STATUS`, `VENDOR`, `VENDOR_CODE`,
                                                IFNULL(`login_attempts`,0) as login_attempts
                                         FROM `vendor_account`
                                         WHERE TRIM(`USERNAME`) = TRIM(@u)
                                            OR TRIM(LOWER(`USERNAME`)) = TRIM(LOWER(@u))
                                         LIMIT 1"

                Using cmdVendor As New MySqlCommand(qVendor, conn)
                    cmdVendor.Parameters.AddWithValue("@u", username)
                    Using drVendor = cmdVendor.ExecuteReader()
                        If drVendor.Read() Then
                            userFound = True
                            isVendor = True
                            isAdmin = False
                            uid = drVendor("ID").ToString()
                            aid = ""
                            bid = ""
                            roleOrType = "Vendor"
                            stat = drVendor("STATUS").ToString().ToUpper()
                            uname = drVendor("USERNAME").ToString()
                            pass = drVendor("PASSWORD").ToString()
                            vendorName = drVendor("VENDOR").ToString()
                            vendorCode = drVendor("VENDOR_CODE").ToString()
                            attempts = drVendor("login_attempts").ToString()
                        End If
                    End Using
                End Using

                ' =====================================================
                ' 🎯 CHECK 2: ADMIN ACCOUNT (`account` table)
                ' =====================================================
                If Not userFound Then
                    SetUserOfflineByUsername_Admin(username, conn)

                    Dim qAdmin As String = "SELECT `id`, `account_id`, `business_type`, `status`, `username`, `password`, `login_attempts`
                                           FROM `account`
                                           WHERE TRIM(`username`) = TRIM(@u)
                                              OR TRIM(LOWER(`username`)) = TRIM(LOWER(@u))
                                           LIMIT 1"

                    Using cmdAdmin As New MySqlCommand(qAdmin, conn)
                        cmdAdmin.Parameters.AddWithValue("@u", username)
                        Using drAdmin = cmdAdmin.ExecuteReader()
                            If drAdmin.Read() Then
                                userFound = True
                                isVendor = False
                                isAdmin = True ' ✅ DETECTED AS ADMIN
                                uid = drAdmin("id").ToString()
                                aid = drAdmin("account_id").ToString() ' ✅ Admin's Account ID
                                bid = "" ' ✅ Admin = NO branch restriction — sees ALL branches under this account_id
                                roleOrType = drAdmin("business_type").ToString().Trim()
                                stat = drAdmin("status").ToString().ToUpper()
                                uname = drAdmin("username").ToString()
                                pass = drAdmin("password").ToString()
                                attempts = drAdmin("login_attempts").ToString()
                            End If
                        End Using
                    End Using
                End If

                ' =====================================================
                ' 🎯 CHECK 3: BRANCH USER (`user_accounts` table)
                ' =====================================================
                If Not userFound Then
                    SetUserOfflineByUsername_User(username, conn)

                    Dim qUser As String = "SELECT `id`, `account_id`, `branch_id`, `user_type`, `status`, `username`, `password`, `login_attempts`
                                          FROM `user_accounts`
                                          WHERE TRIM(`username`) = TRIM(@u)
                                             OR TRIM(LOWER(`username`)) = TRIM(LOWER(@u))
                                          LIMIT 1"

                    Using cmdUser As New MySqlCommand(qUser, conn)
                        cmdUser.Parameters.AddWithValue("@u", username)
                        Using drUser = cmdUser.ExecuteReader()
                            If drUser.Read() Then
                                userFound = True
                                isVendor = False
                                isAdmin = False ' ✅ DETECTED AS BRANCH USER
                                uid = drUser("id").ToString()
                                aid = drUser("account_id").ToString() ' ✅ Belongs to this Account
                                bid = drUser("branch_id").ToString()    ' ✅ RESTRICTED to THIS Branch ONLY
                                roleOrType = drUser("user_type").ToString().Trim()
                                stat = drUser("status").ToString().ToUpper()
                                uname = drUser("username").ToString()
                                pass = drUser("password").ToString()
                                attempts = drUser("login_attempts").ToString()
                            End If
                        End Using
                    End Using
                End If

                ' =====================================================
                ' ✅ PROCESS LOGIN
                ' =====================================================
                If userFound Then
                    Dim attemptCount As Integer = Convert.ToInt32(attempts)

                    If stat = "LOCKED" Then
                        lblError.Text = "Account is LOCKED."
                        lblError.ForeColor = Color.Red
                        AuditLogger.LogAction("LOGIN_DENIED", "Authentication", $"Login rejected for [{uname}] – account locked")
                        Return
                    End If

                    If pass = password Then

                        ' Update status & reset attempts
                        If isVendor Then
                            Using upd = New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='ONLINE', `login_attempts`=0 WHERE `ID`=@id", conn)
                                upd.Parameters.AddWithValue("@id", uid)
                                upd.ExecuteNonQuery()
                            End Using
                        ElseIf isAdmin Then
                            Using upd = New MySqlCommand("UPDATE `account` SET `status`='ONLINE', `login_attempts`=0 WHERE `id`=@id", conn)
                                upd.Parameters.AddWithValue("@id", uid)
                                upd.ExecuteNonQuery()
                            End Using
                        Else
                            Using upd = New MySqlCommand("UPDATE `user_accounts` SET `status`='ONLINE', `login_attempts`=0 WHERE `id`=@id", conn)
                                upd.Parameters.AddWithValue("@id", uid)
                                upd.ExecuteNonQuery()
                            End Using
                        End If

                        ' ✅ SESSION & SCOPE SETUP
                        LoggedInUserID = uid
                        LoggedInAccountID = aid ' ← Admin: his account scope | User: his account owner
                        LoggedInBranchID = bid   ' ← Admin: EMPTY (sees all) | User: fixed branch ONLY
                        LoggedInUsername = uname
                        LoggedInUserType = roleOrType
                        IsAdminAccount = isAdmin
                        IsVendorAccount = isVendor

                        ' ✅ SCOPE FLAG — use this for filtering queries across your system
                        If isAdmin Then
                            UserScope = "ADMIN"      ' Sees ALL branches under LoggedInAccountID
                        Else
                            UserScope = "BRANCH"     ' Sees ONLY LoggedInBranchID + LoggedInAccountID
                        End If

                        DBConnection.CurrentUserAccountID = aid
                        If Not isAdmin AndAlso Not isVendor Then
                            DBConnection.CurrentUserBranchID = bid
                        End If
                        DBConnection.CurrentLoggedInUser = uname
                        DBConnection.CurrentUserType = roleOrType

                        AuditLogger.LogAction("LOGIN_SUCCESS", "Authentication",
                            $"User [{uname}] | AccountID: [{aid}] | BranchID: [{bid}] | Scope: {UserScope} | Vendor: {isVendor} | Admin: {isAdmin}")

                        ' =====================================================
                        ' 🎯 VENDOR — SEPARATE DASHBOARD
                        ' =====================================================
                        If isVendor Then
                            frmVendorDashboard.Show()
                            frmVendorDashboard.lblVendorInfo.Text = $"Vendor: {vendorName} ({vendorCode})"
                            Me.Hide()
                            Return
                        End If

                        ' =====================================================
                        ' 🎯 ROLE DISPLAY TEXT — UNCHANGED
                        ' =====================================================
                        Dim roleText As String = roleOrType
                        If isAdmin Then
                            Select Case roleOrType
                                Case "1" : roleText = "Branch Administrator"
                                Case "2" : roleText = "IT Support"
                                Case "3" : roleText = "Manager"
                                Case "4" : roleText = "Supervisor"
                                Case "5" : roleText = "Cashier"
                                Case "6" : roleText = "RDU"
                                Case "7" : roleText = "Inventory Clerk"
                                Case Else : roleText = "Admin (Type " & roleOrType & ")"
                            End Select
                        End If

                        frmDashboard.Button1.Show() 'Product List For ADMIN
                        frmDashboard.Button2.Hide() 'Out of Stocks
                        frmDashboard.Button3.Hide() 'Product Descriptions USERS
                        frmDashboard.Button4.Hide() 'Shelftags
                        frmDashboard.Button5.Hide() 'Inventory
                        frmDashboard.Button6.Hide() 'price adjustment
                        frmDashboard.Button12.Show() 'Branch List
                        frmDashboard.btnuselist.Show() 'User List


                        frmDashboard.btnSOTEX_Expiry.Hide() 'SOTEX Expiry
                        frmDashboard.btnPO.Hide() 'Purchase Order
                        frmDashboard.btnSTR.Hide() 'Stock Transfer Request
                        frmDashboard.btnRTV.Hide() 'Return to Vendor

                        frmDashboard.btnPrice_Adjustment_Reports.Show() 'Price Adjustment Reports
                        frmDashboard.btnINV_Reports.Show() 'Inventory Reports
                        frmDashboard.Button7.Hide() 'Out of Stocks Reports
                        frmDashboard.btnSTR_Reports.Show() ' Stock Transfer Request Reports
                        frmDashboard.btnPO_Reports.Show() 'Purchase Order Reports
                        frmDashboard.btnRTV_Reports.Show() 'Return to Vendor Reports

                        If roleText = "Branch Administrator" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "Branch Administrator"

                            ' ✅ ADMIN — LAHAT NG BUTTON IPAPAKITA! WALANG TIKATAGO
                            frmDashboard.Button1.Show()
                            frmDashboard.Button3.Show()
                            frmDashboard.Button4.Show()
                            frmDashboard.Button5.Show()
                            frmDashboard.Button6.Show()
                            frmDashboard.Button2.Show()
                            frmDashboard.Button12.Show()
                            frmDashboard.btnuselist.Show()
                            frmDashboard.btnSOTEX_Expiry.Show()
                            frmDashboard.btnPO.Show()
                            frmDashboard.btnSTR.Show()
                            frmDashboard.btnRTV.Show()
                            frmDashboard.btnPrice_Adjustment_Reports.Show()
                            frmDashboard.btnINV_Reports.Show()
                            frmDashboard.Button7.Show()
                            frmDashboard.btnSTR_Reports.Show()
                            frmDashboard.btnPO_Reports.Show()
                            frmDashboard.btnRTV_Reports.Show()


                        ElseIf roleText = "IT Support" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "IT Support"
                            frmDashboard.Button1.Show()
                            frmDashboard.Button6.Show()
                            frmDashboard.Button12.Show()
                            frmDashboard.btnuselist.Show()

                        ElseIf roleText = "Manager" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "Manager"
                            frmDashboard.Button3.Show()
                            frmDashboard.Button4.Show()
                            frmDashboard.btnPrice_Adjustment_Reports.Show()
                            frmDashboard.btnINV_Reports.Show()
                            frmDashboard.Button7.Show()
                            frmDashboard.btnSTR_Reports.Show()
                            frmDashboard.btnPO_Reports.Show()
                            frmDashboard.btnRTV_Reports.Show()

                        ElseIf roleText = "Supervisor" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "Supervisor"
                            frmDashboard.Button3.Show()
                            frmDashboard.Button4.Show()
                            frmDashboard.btnPrice_Adjustment_Reports.Show()
                            frmDashboard.btnINV_Reports.Show()
                            frmDashboard.Button7.Show()
                            frmDashboard.btnSTR_Reports.Show()
                            frmDashboard.btnPO_Reports.Show()
                            frmDashboard.btnRTV_Reports.Show()

                        ElseIf roleText = "Cashier" Then
                            frmPOS_System.Show()
                            Return

                        ElseIf roleText = "RDU" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "RDU"
                            frmDashboard.btnPO.Show()
                            frmDashboard.btnSTR.Show()
                            frmDashboard.btnRTV.Show()
                            frmDashboard.Button7.Show()
                            frmDashboard.btnSTR_Reports.Show()
                            frmDashboard.btnPO_Reports.Show()
                            frmDashboard.btnRTV_Reports.Show()

                        ElseIf roleText = "Inventory Clerk" Then
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = "Inventory Clerk"
                            frmDashboard.btnSOTEX_Expiry.Show()
                            frmDashboard.Button5.Show()
                            frmDashboard.Button2.Show()
                            frmDashboard.btnINV_Reports.Show()
                            frmDashboard.Button7.Show()

                        Else
                            frmDashboard.Show()
                            frmDashboard.lblrole.Text = roleText
                        End If

                        Me.Hide()
                        Return
                    Else

                        attemptCount += 1

                        If isVendor Then
                            If attemptCount >= maxAttempts Then
                                Using lck = New MySqlCommand("UPDATE `vendor_account` SET `STATUS`='LOCKED', `login_attempts`=@att WHERE `ID`=@id", conn)
                                    lck.Parameters.AddWithValue("@att", attemptCount)
                                    lck.Parameters.AddWithValue("@id", uid)
                                    lck.ExecuteNonQuery()
                                End Using
                                lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                lblError.ForeColor = Color.Red
                            Else
                                Using updAtt = New MySqlCommand("UPDATE `vendor_account` SET `login_attempts`=@att WHERE `ID`=@id", conn)
                                    updAtt.Parameters.AddWithValue("@att", attemptCount)
                                    updAtt.Parameters.AddWithValue("@id", uid)
                                    updAtt.ExecuteNonQuery()
                                End Using
                                lblError.Text = "Wrong Password. Attempts left: " & (maxAttempts - attemptCount)
                                lblError.ForeColor = Color.OrangeRed
                            End If
                        ElseIf isAdmin Then
                            If attemptCount >= maxAttempts Then
                                Using lck = New MySqlCommand("UPDATE `account` SET `status`='LOCKED', `login_attempts`=@att WHERE `id`=@id", conn)
                                    lck.Parameters.AddWithValue("@att", attemptCount)
                                    lck.Parameters.AddWithValue("@id", uid)
                                    lck.ExecuteNonQuery()
                                End Using
                                lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                lblError.ForeColor = Color.Red
                            Else
                                Using updAtt = New MySqlCommand("UPDATE `account` SET `login_attempts`=@att WHERE `id`=@id", conn)
                                    updAtt.Parameters.AddWithValue("@att", attemptCount)
                                    updAtt.Parameters.AddWithValue("@id", uid)
                                    updAtt.ExecuteNonQuery()
                                End Using
                                lblError.Text = "Wrong Password. Attempts left: " & (maxAttempts - attemptCount)
                                lblError.ForeColor = Color.OrangeRed
                            End If
                        Else
                            If attemptCount >= maxAttempts Then
                                Using lck = New MySqlCommand("UPDATE `user_accounts` SET `status`='LOCKED', `login_attempts`=@att WHERE `id`=@id", conn)
                                    lck.Parameters.AddWithValue("@att", attemptCount)
                                    lck.Parameters.AddWithValue("@id", uid)
                                    lck.ExecuteNonQuery()
                                End Using
                                lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                lblError.ForeColor = Color.Red
                            Else
                                Using updAtt = New MySqlCommand("UPDATE `user_accounts` SET `login_attempts`=@att WHERE `id`=@id", conn)
                                    updAtt.Parameters.AddWithValue("@att", attemptCount)
                                    updAtt.Parameters.AddWithValue("@id", uid)
                                    updAtt.ExecuteNonQuery()
                                End Using
                                lblError.Text = "Wrong Password. Attempts left: " & (maxAttempts - attemptCount)
                                lblError.ForeColor = Color.OrangeRed
                            End If
                        End If
                        Return
                    End If
                End If

                If Not userFound Then
                    AuditLogger.LogAction("LOGIN_FAILED", "Authentication", $"Username not found: [{username}]")
                    lblError.Text = "Username does not exist in our records."
                    lblError.ForeColor = Color.OrangeRed
                End If

            End Using

        Catch ex As Exception
            lblError.Text = "System Error: " & ex.Message
            lblError.ForeColor = Color.Red
            AuditLogger.LogAction("SYSTEM_ERROR", "Authentication", $"Login error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        txtPassword.PasswordChar = If(txtPassword.PasswordChar = "●"c, Char.MinValue, "●"c)
    End Sub

End Class