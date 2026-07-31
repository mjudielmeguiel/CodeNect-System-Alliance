Imports System.IO
Imports MySqlConnector

Public Class Add_User

    Private rnd As New Random()

    Private Sub Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboUserType.Items.Add("Branch Administrator")
        cboUserType.Items.Add("IT Support")
        cboUserType.Items.Add("Branch Manager")
        cboUserType.Items.Add("Supervisor")
        cboUserType.Items.Add("Cashier")
        cboUserType.Items.Add("Receiving Department Unit")
        cboUserType.Items.Add("Inventory Clerk")
        cboUserType.Items.Add("Sales Staff")

        LoadBranches()
        lblUserID.Text = GenerateUniqueUserID().ToString()

        txtPassword.Text = "Password1*"
        txtConfirmPassword.Text = "Password1*"
        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c
    End Sub

    Private Sub LoadBranches()
        Try
            cboBranch.Items.Clear()

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BRANCH` FROM `Branches` WHERE `ACCOUNT_ID` = @AccID ORDER BY `BRANCH`"
                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@AccID", Login.LoggedInAccountID)
                    Conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            cboBranch.Items.Add(dr("BRANCH").ToString().Trim())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetBranchID(branchName As String) As String
        Dim brID As String = "0"
        Try
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BRANCH_ID` FROM `Branches` WHERE `BRANCH` = @Name AND `ACCOUNT_ID` = @Acc"
                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@Name", branchName.Trim())
                    cmd.Parameters.AddWithValue("@Acc", Login.LoggedInAccountID)
                    Conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            brID = dr("BRANCH_ID").ToString().Trim()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            brID = "0"
        End Try
        Return brID
    End Function

    Private Function GenerateUniqueUserID() As Integer
        Dim newID As Integer
        Dim exists As Boolean
        Do
            newID = rnd.Next(100000, 1000000)
            exists = False
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim checkSQL As String = "SELECT COUNT(*) FROM `user_accounts` WHERE `user_id` = @ID"
                Using cmd As New MySqlCommand(checkSQL, Conn)
                    cmd.Parameters.AddWithValue("@ID", newID)
                    Conn.Open()
                    If CInt(cmd.ExecuteScalar()) > 0 Then exists = True
                End Using
            End Using
        Loop While exists
        Return newID
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim autoAccID As String = Login.LoggedInAccountID
            Dim brName As String = If(cboBranch.SelectedItem IsNot Nothing, cboBranch.SelectedItem.ToString().Trim(), "")
            Dim brID As String = GetBranchID(brName)
            Dim newUserID As Integer = Integer.Parse(lblUserID.Text)

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim checkSQL As String = "SELECT COUNT(*) FROM `user_accounts` WHERE `username` = @User"
                Using cmdCheck As New MySqlCommand(checkSQL, Conn)
                    cmdCheck.Parameters.AddWithValue("@User", txtUsername.Text.Trim())
                    Conn.Open()
                    If CInt(cmdCheck.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            Dim saveSQL As String = "
                INSERT INTO `user_accounts` 
                (`account_id`, `branch_id`, `branch_name`, `user_id`, `username`, `password`, `full_name`, `user_type`, `contact`, `email`, `status`, `date_created`) 
                VALUES 
                (@AccID, @BrID, @BrName, @UsrID, @Usr, @Pass, @Full, @Type, @Cont, @Mail, 'OFFLINE', NOW())"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using cmdSave As New MySqlCommand(saveSQL, Conn)
                    cmdSave.Parameters.AddWithValue("@AccID", autoAccID)
                    cmdSave.Parameters.AddWithValue("@BrID", brID)
                    cmdSave.Parameters.AddWithValue("@BrName", brName)
                    cmdSave.Parameters.AddWithValue("@UsrID", newUserID)
                    cmdSave.Parameters.AddWithValue("@Usr", txtUsername.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Pass", txtPassword.Text)
                    cmdSave.Parameters.AddWithValue("@Full", txtFullName.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Type", If(cboUserType.SelectedItem IsNot Nothing, cboUserType.Text.Trim(), ""))
                    cmdSave.Parameters.AddWithValue("@Cont", txtContact.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Mail", txtEmail.Text.Trim())

                    Conn.Open()
                    cmdSave.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User added successfully! User ID: " & newUserID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Save Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class