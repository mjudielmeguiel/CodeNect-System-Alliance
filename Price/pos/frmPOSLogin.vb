Imports System.Data.SqlClient

Public Class frmPOSLogin

    Public Shared LoggedInBranchID As String = ""
    Public Shared LoggedInAccountID As String = ""
    Public Shared LoggedInUserID As String = ""
    Public Shared LoggedInUsername As String = ""
    Public Shared LoggedInUserType As String = ""

    Dim attemptCount As Integer = 0
    Dim maxAttempts As Integer = 3

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

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

        Using conn As New SqlConnection(modConnection.connStr)
            Try
                conn.Open()

                Dim userFound As Boolean = False
                Dim userStatus As String = ""
                Dim userID As String = ""
                Dim storedPassword As String = ""
                Dim branchCode As String = ""
                Dim branchName As String = ""
                Dim userType As String = ""
                Dim fullName As String = ""

                Dim queryUser As String = "SELECT ID, ACCOUNT_ID, BRANCH_ID, BRANCH, USER_TYPE, STATUS, FULL_NAME, PASSWORD 
                                            FROM User_Accounts 
                                            WHERE USERNAME=@user"

                Using cmdUser As New SqlCommand(queryUser, conn)
                    cmdUser.Parameters.AddWithValue("@user", username)

                    Using drUser As SqlDataReader = cmdUser.ExecuteReader()
                        If drUser.Read() Then
                            userType = drUser("USER_TYPE").ToString().Trim()

                            If Not userType.Equals("CASHIER", StringComparison.OrdinalIgnoreCase) AndAlso
                               Not userType.Equals("POS", StringComparison.OrdinalIgnoreCase) Then
                                MessageBox.Show("This login is for POS / Cashier only. Please use the main system login.",
                                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return
                            End If

                            userFound = True
                            userID = drUser("ID").ToString().Trim()
                            fullName = drUser("FULL_NAME").ToString().Trim()
                            userStatus = drUser("STATUS").ToString().Trim()
                            storedPassword = drUser("PASSWORD").ToString().Trim()
                            branchCode = drUser("BRANCH_ID").ToString().Trim()
                            branchName = drUser("BRANCH").ToString().Trim()
                            LoggedInAccountID = drUser("ACCOUNT_ID").ToString().Trim()
                        End If
                    End Using
                End Using

                If Not userFound Then
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
                End Select

                If storedPassword = password Then
                    attemptCount = 0

                    modConnection.SetUserOnline(username)

                    LoggedInUserID = userID
                    LoggedInBranchID = branchCode
                    LoggedInUserType = userType
                    LoggedInUsername = fullName

                    frmPOS_System.tsname.Text = LoggedInUsername
                    frmPOS_System.tsbranch.Text = branchName
                    frmPOS_System.Show()

                    Me.Hide()

                Else
                    attemptCount += 1
                    If attemptCount >= maxAttempts Then
                        Using cmdLock As New SqlCommand("UPDATE User_Accounts SET STATUS = 'LOCKED' WHERE ID = @id", conn)
                            cmdLock.Parameters.AddWithValue("@id", userID)
                            cmdLock.ExecuteNonQuery()
                        End Using
                        MessageBox.Show("ACCOUNT LOCKED! Too many failed attempts. Contact IT to unlock.",
                                        "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        attemptCount = 0
                    Else
                        MessageBox.Show("Incorrect Password. Remaining attempts: " & (maxAttempts - attemptCount),
                                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub frmPOSLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = "Enter Username"
        txtUsername.ForeColor = Color.Gray
        txtPassword.Text = "Enter Password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = Nothing
        attemptCount = 0
        btnlogin.Enabled = True
    End Sub

    Private Sub txt_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus, txtPassword.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = "Enter Username" OrElse txt.Text = "Enter Password" Then
            txt.Text = ""
            txt.ForeColor = Color.Black
            If txt.Name = "txtPassword" Then txt.PasswordChar = "●"c
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

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        If txtPassword.PasswordChar = Nothing Then
            txtPassword.PasswordChar = "●"c
        Else
            txtPassword.PasswordChar = Nothing
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class