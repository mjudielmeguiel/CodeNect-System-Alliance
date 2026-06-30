Imports System.Data.SqlClient
Imports System.IO

Public Class Add_User

    ' Connection String
    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=sa;Password=Password1*;Connect Timeout=15"
    Private NewProfilePhoto As Byte() = Nothing

    Private Sub Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' USER TYPE LIST
        cboUserType.Items.Add("Branch Administrator")
        cboUserType.Items.Add("IT Support")
        cboUserType.Items.Add("Branch Manager")
        cboUserType.Items.Add("Supervisor")
        cboUserType.Items.Add("Cashier")
        cboUserType.Items.Add("Recieving Department Unit")
        cboUserType.Items.Add("Inventory Clerk")
        cboUserType.Items.Add("Sales Staff")

        LoadBranches()

        ' Hide Password
        txtPassword.Text = "Password1*"
        txtConfirmPassword.Text = "Password1*"
    End Sub

    Private Sub LoadBranches()
        Try
            cboBranch.Items.Clear()
            txtBranchID.Clear()

            Using Conn As New SqlConnection(ConnString)
                Conn.Open()
                Dim sql As String = "SELECT BRANCH FROM Branches WHERE ACCOUNT_ID = @AccID ORDER BY BRANCH"
                Using cmd As New SqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@AccID", Login.LoggedInAccountID)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            cboBranch.Items.Add(dr("BRANCH").ToString())
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message)
        End Try
    End Sub

    Private Sub cboBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranch.SelectedIndexChanged
        If cboBranch.SelectedIndex <> -1 Then
            Dim selectedBranch As String = cboBranch.SelectedItem.ToString()
            Dim branchID As String = GetBranchID(selectedBranch)
            txtBranchID.Text = branchID
        Else
            txtBranchID.Clear()
        End If
    End Sub

    Private Sub picProfile_DoubleClick(sender As Object, e As EventArgs) Handles picProfile.DoubleClick
        Dim open As New OpenFileDialog()
        open.Filter = "Image Files|*.jpg;*.jpeg;*.png"

        If open.ShowDialog() = DialogResult.OK Then
            picProfile.Image = Image.FromFile(open.FileName)
            NewProfilePhoto = File.ReadAllBytes(open.FileName)
        End If
    End Sub

    ' ✅ FUNCTION PARA KUNIN ANG BRANCH ID
    Private Function GetBranchID(branchName As String) As String
        Dim id As String = ""
        Try
            Using Conn As New SqlConnection(ConnString)
                Conn.Open()
                Dim sql As String = "SELECT BRANCH_ID FROM Branches WHERE BRANCH = @Name AND ACCOUNT_ID = @Acc"
                Using cmd As New SqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@Name", branchName)
                    cmd.Parameters.AddWithValue("@Acc", Login.LoggedInAccountID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        id = result.ToString()
                    Else
                        id = "0"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting Branch ID: " & ex.Message)
            id = "0"
        End Try
        Return id
    End Function

#Region "SAVE BUTTON"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' CHECK VALIDATION
        If txtFullName.Text = "" Then
            MessageBox.Show("Please enter Full Name!")
            Exit Sub
        End If
        If txtUsername.Text = "" Then
            MessageBox.Show("Please enter Username!")
            Exit Sub
        End If
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Password does not match!")
            Exit Sub
        End If
        If cboUserType.SelectedIndex = -1 Then
            MessageBox.Show("Please select User Type!")
            Exit Sub
        End If
        If cboBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Branch!")
            Exit Sub
        End If
        If txtBranchID.Text.Trim() = "" Then
            MessageBox.Show("Branch ID not found! Please select a valid branch.")
            Exit Sub
        End If
        If txtEmail.Text = "" Then
            MessageBox.Show("Please enter a valid Email!")
            Exit Sub
        End If
        If txtContact.Text = "" Then
            MessageBox.Show("Please enter a valid Contact Number!")
            Exit Sub
        End If

        Try
            ' ---- GET DATA ----
            Dim branchName As String = cboBranch.SelectedItem.ToString()
            Dim branchID As String = txtBranchID.Text.Trim() ' Kukunin na galing sa textbox

            ' ✅ ACCOUNT ID = AUTOMATIC NA KUKUHA GALING SA NAKALOGIN
            Dim accountID As String = Login.LoggedInAccountID

            ' ---- SAVE TO DATABASE ----
            Dim sqlSave As String = "INSERT INTO User_Accounts " &
                "(ACCOUNT_ID, BRANCH_ID, BRANCH, PROFILE, USERNAME, PASSWORD, FULL_NAME, USER_TYPE, CONTACT, EMAIL, STATUS, DATE_CREATED) " &
                "VALUES (@Acc, @BrID, @BrName, @Pro, @User, @Pass, @Full, @Type, @contact, @email, 'INACTIVE', GETDATE())"

            Using Conn As New SqlConnection(ConnString)
                Conn.Open()
                Using cmd As New SqlCommand(sqlSave, Conn)
                    cmd.Parameters.AddWithValue("@Acc", accountID)
                    cmd.Parameters.AddWithValue("@BrID", branchID)
                    cmd.Parameters.AddWithValue("@BrName", branchName)

                    ' Save Picture
                    If NewProfilePhoto IsNot Nothing Then
                        cmd.Parameters.AddWithValue("@Pro", NewProfilePhoto)
                    Else
                        cmd.Parameters.AddWithValue("@Pro", DBNull.Value)
                    End If

                    ' Other Data
                    cmd.Parameters.AddWithValue("@User", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@Pass", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@Full", txtFullName.Text)
                    cmd.Parameters.AddWithValue("@Type", cboUserType.Text)
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ User added successfully!")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message)
        End Try
    End Sub

#End Region

    ' Cancel
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class