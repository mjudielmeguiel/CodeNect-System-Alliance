Imports System.IO
Imports MySqlConnector

Public Class Add_User

    Private NewProfilePhoto As Byte() = Nothing
    Private CurrentAccountName As String = ""

    Private Sub Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' USER TYPE LIST
        cboUserType.Items.Add("Branch Administrator")
        cboUserType.Items.Add("IT Support")
        cboUserType.Items.Add("Branch Manager")
        cboUserType.Items.Add("Supervisor")
        cboUserType.Items.Add("Cashier")
        cboUserType.Items.Add("Receiving Department Unit")
        cboUserType.Items.Add("Inventory Clerk")
        cboUserType.Items.Add("Sales Staff")

        LoadBranches()

        ' DEFAULT PASSWORD
        txtPassword.Text = "Password1*"
        txtConfirmPassword.Text = "Password1*"
        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c
    End Sub

    Private Sub LoadBranches()
        Try
            cboBranch.Items.Clear()
            txtBranchID.Clear()
            CurrentAccountName = ""

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

    Private Sub cboBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranch.SelectedIndexChanged
        If cboBranch.SelectedIndex <> -1 Then
            txtBranchID.Text = GetBranchDetails(cboBranch.SelectedItem.ToString())
        Else
            txtBranchID.Clear()
            CurrentAccountName = ""
        End If
    End Sub

    Private Function GetBranchDetails(branchName As String) As String
        Dim brID As String = "0"
        Try
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BRANCH_ID`, `ACCOUNT` FROM `Branches` WHERE `BRANCH` = @Name AND `ACCOUNT_ID` = @Acc"
                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@Name", branchName.Trim())
                    cmd.Parameters.AddWithValue("@Acc", Login.LoggedInAccountID)
                    Conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            brID = dr("BRANCH_ID").ToString().Trim()
                            CurrentAccountName = dr("ACCOUNT").ToString().Trim()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            brID = "0"
            CurrentAccountName = ""
        End Try
        Return brID
    End Function

    Private Sub picProfile_DoubleClick(sender As Object, e As EventArgs) Handles picProfile.DoubleClick
        Using open As New OpenFileDialog()
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            open.Title = "Select Profile Picture"
            If open.ShowDialog() = DialogResult.OK Then
                Try
                    picProfile.Image = Image.FromFile(open.FileName)
                    NewProfilePhoto = File.ReadAllBytes(open.FileName)
                Catch ex As Exception
                    MessageBox.Show("Failed to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

#Region "SAVE USER"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' VALIDATION
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Enter Full Name!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Enter Username!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If cboUserType.SelectedIndex = -1 Then
            MessageBox.Show("Select User Type!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUserType.Focus()
            Return
        End If
        If cboBranch.SelectedIndex = -1 Then
            MessageBox.Show("Select Branch!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBranch.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtBranchID.Text) Or txtBranchID.Text = "0" Then
            MessageBox.Show("Invalid Branch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(CurrentAccountName) Then
            MessageBox.Show("Account details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtEmail.Text) Or Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Enter valid Email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("Enter Contact Number!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContact.Focus()
            Return
        End If

        Try
            Dim autoAccID As String = Login.LoggedInAccountID
            Dim autoAccName As String = CurrentAccountName
            Dim brName As String = cboBranch.SelectedItem.ToString().Trim()
            Dim brID As String = txtBranchID.Text.Trim()

            ' CHECK DUPLICATE USERNAME
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim checkSQL As String = "SELECT COUNT(*) FROM `User_Accounts` WHERE `USERNAME` = @User"
                Using cmdCheck As New MySqlCommand(checkSQL, Conn)
                    cmdCheck.Parameters.AddWithValue("@User", txtUsername.Text.Trim())
                    Conn.Open()
                    If CInt(cmdCheck.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            ' SAVE TO DATABASE
            Dim saveSQL As String = "
                INSERT INTO `User_Accounts` 
                (`ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `PROFILE`, `USERNAME`, `PASSWORD`, `FULL_NAME`, `USER_TYPE`, `CONTACT`, `EMAIL`, `STATUS`, `DATE_CREATED`) 
                VALUES 
                (@AccID, @Acc, @BrID, @BrName, @Prof, @Usr, @Pass, @Full, @Type, @Cont, @Mail, 'Active', NOW())"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using cmdSave As New MySqlCommand(saveSQL, Conn)
                    cmdSave.Parameters.AddWithValue("@AccID", autoAccID)
                    cmdSave.Parameters.AddWithValue("@Acc", autoAccName)
                    cmdSave.Parameters.AddWithValue("@BrID", brID)
                    cmdSave.Parameters.AddWithValue("@BrName", brName)
                    cmdSave.Parameters.AddWithValue("@Prof", If(NewProfilePhoto IsNot Nothing, NewProfilePhoto, DBNull.Value))
                    cmdSave.Parameters.AddWithValue("@Usr", txtUsername.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Pass", txtPassword.Text)
                    cmdSave.Parameters.AddWithValue("@Full", txtFullName.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Type", cboUserType.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Cont", txtContact.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@Mail", txtEmail.Text.Trim())

                    Conn.Open()
                    cmdSave.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Save Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class