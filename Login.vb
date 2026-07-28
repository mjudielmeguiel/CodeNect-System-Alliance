Imports System.IO
Imports System.Xml
Imports MySqlConnector

Public Class Login

    ' ==================== SESSION VARIABLES ====================
    Public Shared LoggedInBranchID As String = ""
    Public Shared LoggedInAccountID As String = ""
    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUsername As String = ""
    Public Shared LoggedInUserType As String = ""

    ' ==================== LOGIN SETTINGS ====================
    Dim attemptCount As Integer = 0
    Const maxAttempts As Integer = 3

    ' ==================== PLACEHOLDER: ON FOCUS ====================
    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = "Enter Username" OrElse txt.Text = "Enter Password" Then
            txt.Text = ""
            txt.ForeColor = Color.Black
            If txt.Name = "txtPassword" Then txt.PasswordChar = "●"c
        End If
    End Sub

    ' ==================== PLACEHOLDER: LOST FOCUS ====================
    Private Sub txt_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus, txtPassword.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            If txt.Name = "txtUsername" Then
                txt.Text = "Enter Username"
                txt.ForeColor = Color.Gray
            Else
                txt.Text = "Enter Password"
                txt.ForeColor = Color.Gray
                txt.PasswordChar = Nothing
            End If
        End If
    End Sub

    ' ==================== GO TO REGISTER ====================
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Register_account.Show()
        Me.Hide()
    End Sub

    ' ==================== EXIT BUTTON ====================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' ==================== LOGIN BUTTON (FIXED CONNECTION ERROR) ====================
    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' ✅ BASIC VALIDATION
        If username = "" OrElse username.Equals("Enter Username", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Please enter your Username", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If
        If password = "" OrElse password.Equals("Enter Password", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Please enter your Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' ==============================================
        ' 1. CHECK IN user_accounts (Cashier/Branch Users)
        ' ✅ Separate connection scope — NO REUSE
        ' ==============================================
        Try
            Dim userFound As Boolean = False
            Dim loginSuccess As Boolean = False

            Using connUser As New MySqlConnection(DBConnection.connStr)
                connUser.Open()
                Dim qUser As String = "SELECT `ID`, `ACCOUNT_ID`, `BRANCH_ID`, `USER_TYPE`, `STATUS`, `USERNAME`, `PASSWORD` 
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
                            drUser.Close() ' ✅ Close reader BEFORE running UPDATE

                            If stat = "ACTIVE" Then
                                MessageBox.Show("Already logged in.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Return
                            End If
                            If stat = "LOCKED" Then
                                MessageBox.Show("Account is LOCKED.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return
                            End If

                            If pass = password Then
                                Using upd = New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='ACTIVE' WHERE `ID`=@id", connUser)
                                    upd.Parameters.AddWithValue("@id", uid)
                                    upd.ExecuteNonQuery()
                                End Using

                                LoggedInUserID = uid
                                LoggedInAccountID = aid
                                LoggedInBranchID = bid
                                LoggedInUserType = utype
                                LoggedInUsername = uname

                                If utype.ToUpper() = "CASHIER" OrElse utype.ToUpper() = "POS" Then
                                    frmPOS_System.tsname.Text = uname
                                    frmPOS_System.tsbranch.Text = "BRANCH ID: " & bid
                                    frmPOS_System.ToolStripStatusLabel3.Text = utype.ToUpper
                                    frmPOS_System.Show()
                                Else
                                    DashBoard.UserToolStripMenuItem.Text = uname
                                    DashBoard.ToolStripStatusLabel1.Text = uname
                                    DashBoard.ToolStripStatusLabel4.Text = "BRANCH ID: " & bid
                                    DashBoard.Label1.Text = utype.ToUpper() & " DASHBOARD"
                                    DashBoard.UserManageToolStripMenuItem.Visible = (utype.ToUpper() = "BRANCH ADMINISTRATOR" OrElse utype.ToUpper() = "IT SUPPORT")
                                    DashBoard.Btn_Manage.Visible = (utype.ToUpper() = "BRANCH ADMINISTRATOR" OrElse utype.ToUpper() = "IT SUPPORT")
                                    DashBoard.Show()
                                End If
                                Me.Hide()
                                loginSuccess = True
                            Else
                                attemptCount += 1
                                If attemptCount >= maxAttempts Then
                                    Using lck = New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='LOCKED' WHERE `ID`=@id", connUser)
                                        lck.Parameters.AddWithValue("@id", uid)
                                        lck.ExecuteNonQuery()
                                    End Using
                                    MessageBox.Show("ACCOUNT LOCKED! Too many failed attempts.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    attemptCount = 0
                                Else
                                    MessageBox.Show("Wrong Password. Attempts left: " & (maxAttempts - attemptCount), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                Return
                            End If
                        End If
                    End Using
                End Using
            End Using

            If loginSuccess Then Return

            ' ==============================================
            ' 2. CHECK IN account (Business Admin)
            ' ✅ Separate connection — NO BRANCH NEEDED
            ' ==============================================
            Using connAdmin As New MySqlConnection(DBConnection.connStr)
                connAdmin.Open()
                Dim qAdmin As String = "SELECT `ACCOUNT_ID`, `STATUS`, `OWNER_FULLNAME`, `USERNAME`, `PASSWORD` 
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
                            drAdmin.Close()

                            If stat = "ACTIVE" Then
                                MessageBox.Show("Already logged in.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Return
                            End If
                            If stat = "LOCKED" Then
                                MessageBox.Show("Account is LOCKED.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return
                            End If
                            If stat = "PENDING" Then
                                MessageBox.Show("Account is still PENDING for approval.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If
                            If stat = "OFFLINE" Then
                                If pass = password Then
                                    Using upd = New MySqlCommand("UPDATE `account` SET `STATUS`='ACTIVE' WHERE `ACCOUNT_ID`=@id", connAdmin)
                                        upd.Parameters.AddWithValue("@id", aid)
                                        upd.ExecuteNonQuery()
                                    End Using

                                    LoggedInUserID = aid
                                    LoggedInAccountID = aid
                                    LoggedInUserType = "BUSINESS ADMIN"
                                    LoggedInUsername = name
                                    LoggedInBranchID = String.Empty ' ✅ NO BRANCH FOR ADMIN

                                    DashBoard.ToolStripStatusLabel1.Text = name
                                    DashBoard.ToolStripStatusLabel4.Text = "MAIN OFFICE"
                                    DashBoard.Label1.Text = "BUSINESS ADMIN PANEL"
                                    DashBoard.Btn_Manage.Visible = False
                                    DashBoard.UserManageToolStripMenuItem.Visible = False
                                    DashBoard.Show()
                                    Me.Hide()
                                    Return
                                Else
                                    MessageBox.Show("Wrong Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Return
                                End If
                            End If
                        End If
                    End Using
                End Using
            End Using

            If Not userFound Then
                MessageBox.Show("Username does not exist in our records.", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==================== FORM LOAD ====================
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = "Enter Username"
        txtUsername.ForeColor = Color.Gray
        txtPassword.Text = "Enter Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing
        attemptCount = 0
        btnlogin.Enabled = True
    End Sub

End Class