Imports System.Data.SqlClient

Public Class Login

    Public Shared LoggedInBranchID As String = ""
    Public Shared LoggedInAccountID As String = ""
    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUsername As String = ""
    Public Shared LoggedInUserType As String = ""

    Dim attemptCount As Integer = 0
    Dim maxAttempts As Integer = 3

    Dim connString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" OrElse username = "Enter Username" Then
            MessageBox.Show("Please enter your Username", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If password = "" OrElse password = "Enter Password" Then
            MessageBox.Show("Please enter your Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Using conn As New SqlConnection(connString)
            Try
                conn.Open()

                ' CHECK ADMIN ACCOUNT (NO ATTEMPT LOCK)
                Dim isAdminFound As Boolean = False
                Dim adminStatus As String = ""
                Dim adminID As String = ""
                Dim adminFullName As String = ""

                Dim queryAdmin As String = "SELECT ID, ACCOUNT_ID, STATUS, ACCOUNT FROM adm.Account WHERE USERNAME=@user"
                Using cmdAdmin As New SqlCommand(queryAdmin, conn)
                    cmdAdmin.Parameters.AddWithValue("@user", username)

                    Using drAdmin As SqlDataReader = cmdAdmin.ExecuteReader()
                        If drAdmin.Read() Then
                            isAdminFound = True
                            adminID = drAdmin("ID").ToString().Trim()
                            adminStatus = drAdmin("STATUS").ToString().Trim()
                            adminFullName = drAdmin("ACCOUNT").ToString().Trim()
                            LoggedInAccountID = drAdmin("ACCOUNT_ID").ToString().Trim()
                        End If
                    End Using
                End Using

                If isAdminFound Then
                    ' GET PASSWORD SEPARATELY FOR ADMIN
                    Dim passCheck As String = ""
                    Dim queryAdminPass As String = "SELECT PASSWORD FROM adm.Account WHERE ID=@id"
                    Using cmdPass As New SqlCommand(queryAdminPass, conn)
                        cmdPass.Parameters.AddWithValue("@id", adminID)
                        passCheck = cmdPass.ExecuteScalar().ToString().Trim()
                    End Using

                    Select Case adminStatus.ToUpper()
                        Case "ACTIVE"
                            MessageBox.Show("This account is already logged in on another device.", "Already Logged In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return

                        Case "LOCKED"
                            MessageBox.Show("Account is LOCKED. Please contact IT.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return

                        Case "OFFLINE"
                            If passCheck = password Then
                                ' ✅ UPDATE STATUS GAMIT ID
                                Using cmdUpdate As New SqlCommand("UPDATE adm.Account SET STATUS = 'ACTIVE' WHERE ID = @id", conn)
                                    cmdUpdate.Parameters.AddWithValue("@id", adminID)
                                    cmdUpdate.ExecuteNonQuery()
                                End Using

                                LoggedInUserID = adminID
                                LoggedInBranchID = ""
                                LoggedInUserType = "ADMIN"
                                LoggedInUsername = adminFullName

                                DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                                DashBoard.ToolStripStatusLabel4.Text = "MAIN OFFICE"
                                DashBoard.Label1.Text = "ADMIN PANEL"
                                DashBoard.Btn_Manage.Visible = False
                                DashBoard.Btn_Manage.Visible = False
                                Me.Hide()
                                DashBoard.Show()
                            Else
                                MessageBox.Show("Username or Password does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                    End Select
                    Return
                End If


                ' CHECK REGULAR USER ACCOUNT (WITH ATTEMPT LOCK)
                Dim userFound As Boolean = False
                Dim userStatus As String = ""
                Dim userID As String = ""
                Dim storedPassword As String = ""
                Dim branchCode As String = ""
                Dim branchName As String = ""
                Dim userType As String = ""
                Dim fullName As String = ""

                Dim queryUser As String = "SELECT ID, ACCOUNT_ID, BRANCH_ID, BRANCH, USER_TYPE, STATUS, FULL_NAME, PASSWORD FROM User_Accounts WHERE USERNAME=@user"
                Using cmdUser As New SqlCommand(queryUser, conn)
                    cmdUser.Parameters.AddWithValue("@user", username)

                    Using drUser As SqlDataReader = cmdUser.ExecuteReader()
                        If drUser.Read() Then
                            userFound = True
                            userID = drUser("ID").ToString().Trim()
                            fullName = drUser("FULL_NAME").ToString().Trim()
                            userStatus = drUser("STATUS").ToString().Trim()
                            storedPassword = drUser("PASSWORD").ToString().Trim()
                            branchCode = drUser("BRANCH_ID").ToString().Trim()
                            branchName = drUser("BRANCH").ToString().Trim()
                            userType = drUser("USER_TYPE").ToString().Trim()
                            LoggedInAccountID = drUser("ACCOUNT_ID").ToString().Trim()
                        End If
                    End Using
                End Using


                If Not userFound Then
                    ' USERNAME NOT EXIST
                    MessageBox.Show("Username or Password does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If


                Select Case userStatus.ToUpper()
                    Case "ACTIVE"
                        MessageBox.Show("This account is already logged in on another device.", "Already Logged In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return

                    Case "LOCKED"
                        MessageBox.Show("Account is LOCKED after 3 failed attempts. Contact IT to unlock.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return

                    Case "OFFLINE"
                        ' Continue
                End Select


                If storedPassword = password Then
                    attemptCount = 0

                    ' ✅ UPDATE STATUS GAMIT ID
                    Using cmdUpdate As New SqlCommand("UPDATE User_Accounts SET STATUS = 'ACTIVE' WHERE ID = @id", conn)
                        cmdUpdate.Parameters.AddWithValue("@id", userID)
                        cmdUpdate.ExecuteNonQuery()
                    End Using

                    LoggedInUserID = userID
                    LoggedInBranchID = branchCode
                    LoggedInUserType = userType
                    LoggedInUsername = fullName

                    'POS SYSTEM
                    If userType.Equals("CASHIER", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("POS", StringComparison.OrdinalIgnoreCase) Then
                        POS_System.tsname.Text = LoggedInUsername
                        POS_System.tsbranch.Text = branchName
                        POS_System.Show()

                        ' BRANCH ADMIN DASHBOARD
                    ElseIf userType.Equals("Branch Administrator", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Branch Administrator", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = True
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()

                        'IT SUPPORT DASHBOARD
                    ElseIf userType.Equals("IT Support", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("IT Support", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = True
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()

                        'BRANCH MANAGER DASHBOARD
                    ElseIf userType.Equals("Branch Manager", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Branch Manager", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = False
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()

                        'SUPERVISOR DASHBOARD
                    ElseIf userType.Equals("Supervisor", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Supervisor", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = False
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()

                        'INVENTORY CLERK DASHBOARD
                    ElseIf userType.Equals("Inventory Clerk", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Inventory Clerk", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = False
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()

                        'RECIEVING DEPARTMENT UNIT (RDU) DASHBOARD
                    ElseIf userType.Equals("Recieving Department Unit", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Recieving Department Unit", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = False
                        DashBoard.Show()

                        'SALES STAFF DASHBOARD
                    ElseIf userType.Equals("Sales Staff", StringComparison.OrdinalIgnoreCase) OrElse userType.Equals("Sales Staff", StringComparison.OrdinalIgnoreCase) Then
                        DashBoard.ToolStripStatusLabel1.Text = LoggedInUsername
                        DashBoard.ToolStripStatusLabel4.Text = branchName
                        DashBoard.Label1.Text = userType.ToUpper() & " DASHBOARD"

                        DashBoard.UserManageToolStripMenuItem.Visible = False
                        DashBoard.Btn_Manage.Visible = True
                        DashBoard.Show()
                    End If
                    DashBoard.Show()
                    Me.Hide()

                Else
                    attemptCount += 1
                    If attemptCount >= maxAttempts Then
                        ' LOCK ACCOUNT GAMIT ID
                        Using cmdLock As New SqlCommand("UPDATE User_Accounts SET STATUS = 'LOCKED' WHERE ID = @id", conn)
                            cmdLock.Parameters.AddWithValue("@id", userID)
                            cmdLock.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("ACCOUNT LOCKED! Contact IT to unlock.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        attemptCount = 0
                    Else
                        ' WRONG PASSWORD
                        MessageBox.Show("Username or Password does not exist. Remaining attempts: " & (maxAttempts - attemptCount), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = "Enter Username"
        txtUsername.ForeColor = Color.Gray
        txtPassword.Text = "Enter Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing
        attemptCount = 0
        Button1.Enabled = True
    End Sub

    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = "Enter Username" OrElse txt.Text = "Enter Password" Then
            txt.Text = ""
            txt.ForeColor = Color.Black
            If txt.Name = "txtPassword" Then txt.PasswordChar = "*"
        End If
    End Sub

    Private Sub txt_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus, txtPassword.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text.Trim() = "" Then
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

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Register_account.Show()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        If MessageBox.Show("Are you sure you want to exit?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class