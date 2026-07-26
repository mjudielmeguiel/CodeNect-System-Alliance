Imports System.IO
Imports MySqlConnector

Public Class Add_User

    Private NewProfilePhoto As Byte() = Nothing

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

        ' Default password placeholder
        txtPassword.Text = "Password1*"
        txtConfirmPassword.Text = "Password1*"
        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c
    End Sub

    Private Sub LoadBranches()
        Try
            cboBranch.Items.Clear()
            txtBranchID.Clear()

            ' ✅ MySQL syntax: backticks, MySqlConnection
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
            Dim selectedBranch As String = cboBranch.SelectedItem.ToString()
            txtBranchID.Text = GetBranchID(selectedBranch)
        Else
            txtBranchID.Clear()
        End If
    End Sub

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

    Private Function GetBranchID(branchName As String) As String
        Dim id As String = ""
        Try
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BRANCH_ID` FROM `Branches` WHERE `BRANCH` = @Name AND `ACCOUNT_ID` = @Acc"
                Using cmd As New MySqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@Name", branchName.Trim())
                    cmd.Parameters.AddWithValue("@Acc", Login.LoggedInAccountID)
                    Conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    id = If(result IsNot Nothing, result.ToString().Trim(), "0")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting Branch ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            id = "0"
        End Try
        Return id
    End Function

#Region "SAVE BUTTON"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' --- VALIDATION ---
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Please enter Full Name!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter Username!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If cboUserType.SelectedIndex = -1 Then
            MessageBox.Show("Please select User Type!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUserType.Focus()
            Return
        End If
        If cboBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Branch!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBranch.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtBranchID.Text) OrElse txtBranchID.Text = "0" Then
            MessageBox.Show("Valid Branch ID not found. Please select a valid branch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid Email address!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("Please enter a valid Contact Number!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContact.Focus()
            Return
        End If

        Try
            Dim branchName As String = cboBranch.SelectedItem.ToString().Trim()
            Dim branchID As String = txtBranchID.Text.Trim()
            Dim accountID As String = Login.LoggedInAccountID

            ' --- CHECK IF USERNAME ALREADY EXISTS ---
            Dim checkQuery As String = "SELECT COUNT(*) FROM `User_Accounts` WHERE `USERNAME` = @Username"
            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using cmdCheck As New MySqlCommand(checkQuery, Conn)
                    cmdCheck.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    Conn.Open()
                    Dim count As Integer = CInt(cmdCheck.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Username already exists! Please choose another.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            ' --- INSERT NEW USER ---
            ' ✅ GETDATE() → NOW() | ✅ All identifiers wrapped in backticks | ✅ No dbo. prefix
            Dim sqlSave As String = "
                INSERT INTO `User_Accounts` 
                (`ACCOUNT_ID`, `BRANCH_ID`, `BRANCH`, `PROFILE`, `USERNAME`, `PASSWORD`, `FULL_NAME`, `USER_TYPE`, `CONTACT`, `EMAIL`, `STATUS`, `DATE_CREATED`) 
                VALUES 
                (@Acc, @BrID, @BrName, @Pro, @User, @Pass, @Full, @Type, @Contact, @Email, 'OFFLINE', NOW())"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using cmd As New MySqlCommand(sqlSave, Conn)
                    cmd.Parameters.AddWithValue("@Acc", accountID)
                    cmd.Parameters.AddWithValue("@BrID", branchID)
                    cmd.Parameters.AddWithValue("@BrName", branchName)
                    cmd.Parameters.AddWithValue("@Pro", If(NewProfilePhoto IsNot Nothing, NewProfilePhoto, DBNull.Value))
                    cmd.Parameters.AddWithValue("@User", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@Pass", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@Full", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Type", cboUserType.Text.Trim())
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())

                    Conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error saving user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class