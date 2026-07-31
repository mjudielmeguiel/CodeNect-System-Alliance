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

    ' --- AUTO SET STATUS TO OFFLINE WHEN LOGIN FORM CLOSES ---
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Only run if user successfully logged in
        If Not String.IsNullOrEmpty(LoggedInUserID) OrElse Not String.IsNullOrEmpty(LoggedInAccountID) Then
            Try
                Using conn As New MySqlConnection(DBConnection.connStr)
                    conn.Open()
                    ' For normal users
                    If Not String.IsNullOrEmpty(LoggedInUserID) Then
                        Using cmd As New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='OFFLINE' WHERE `ID`=@id", conn)
                            cmd.Parameters.AddWithValue("@id", LoggedInUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    ' For Business Admin
                    If Not String.IsNullOrEmpty(LoggedInAccountID) AndAlso LoggedInUserType = "BUSINESS ADMIN" Then
                        Using cmd As New MySqlCommand("UPDATE `account` SET `STATUS`='OFFLINE' WHERE `ACCOUNT_ID`=@aid", conn)
                            cmd.Parameters.AddWithValue("@aid", LoggedInAccountID)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            Catch ex As Exception
                ' Ignore error if connection fails
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
        Register_account.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        lblError.Text = ""
        Dim username As String = If(txtUsername.Text = PLACEHOLDER_USER, "", txtUsername.Text.Trim())
        Dim password As String = If(txtPassword.Text = PLACEHOLDER_PASS, "", txtPassword.Text.Trim())

        If String.IsNullOrWhiteSpace(username) Then
            lblError.Text = "Please enter your Username"
            lblError.ForeColor = Color.OrangeRed
            txtUsername.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(password) Then
            lblError.Text = "Please enter your Password"
            lblError.ForeColor = Color.OrangeRed
            txtPassword.Focus()
            Return
        End If

        Try
            Dim userFound As Boolean = False
            Dim loginSuccess As Boolean = False

            Using connUser As New MySqlConnection(DBConnection.connStr)
                connUser.Open()
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

                            If stat = "ACTIVE" Then
                                lblError.Text = "Already logged in."
                                lblError.ForeColor = Color.Orange
                                Return
                            End If
                            If stat = "LOCKED" Then
                                lblError.Text = "Account is LOCKED."
                                lblError.ForeColor = Color.Red
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

                                frmDashboard.Show()

                                Me.Hide()
                                loginSuccess = True
                            Else
                                attempts += 1
                                If attempts >= maxAttempts Then
                                    Using lck = New MySqlCommand("UPDATE `user_accounts` SET `STATUS`='LOCKED', `login_attempts`=@att WHERE `ID`=@id", connUser)
                                        lck.Parameters.AddWithValue("@att", attempts)
                                        lck.Parameters.AddWithValue("@id", uid)
                                        lck.ExecuteNonQuery()
                                    End Using
                                    lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                    lblError.ForeColor = Color.Red
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

                            If stat = "ACTIVE" Then
                                lblError.Text = "Already logged in."
                                lblError.ForeColor = Color.Orange
                                Return
                            End If
                            If stat = "LOCKED" Then
                                lblError.Text = "Account is LOCKED."
                                lblError.ForeColor = Color.Red
                                Return
                            End If
                            If stat = "PENDING" Then
                                lblError.Text = "Account is still PENDING for approval."
                                lblError.ForeColor = Color.Orange
                                Return
                            End If
                            If stat = "OFFLINE" Then
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

                                    frmDashboard.Show()
                                    Me.Hide()
                                    Return
                                Else
                                    attempts += 1
                                    If attempts >= maxAttempts Then
                                        Using lck = New MySqlCommand("UPDATE `account` SET `STATUS`='LOCKED', `login_attempts`=@att WHERE `ACCOUNT_ID`=@id", connAdmin)
                                            lck.Parameters.AddWithValue("@att", attempts)
                                            lck.Parameters.AddWithValue("@id", aid)
                                            lck.ExecuteNonQuery()
                                        End Using
                                        lblError.Text = "ACCOUNT LOCKED! Too many failed attempts."
                                        lblError.ForeColor = Color.Red
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
                        End If
                    End Using
                End Using
            End Using

            If Not userFound Then
                lblError.Text = "Username does not exist in our records."
                lblError.ForeColor = Color.OrangeRed
            End If

        Catch ex As Exception
            lblError.Text = "System Error: " & ex.Message
            lblError.ForeColor = Color.Red
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
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        txtPassword.PasswordChar = If(txtPassword.PasswordChar = "●"c, Char.MinValue, "●"c)
    End Sub

End Class