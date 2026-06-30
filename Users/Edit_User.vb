Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Edit_User

    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS;Initial Catalog=CodeNectDB;User ID=sa;Password=Password1*;Connect Timeout=15"

    Private currentUserID As Integer
    Private currentBranchCode As String
    Private currentUserType As String
    Private userImageData As Byte() = Nothing

    Public Sub LoadUserDetails(userInfo As Object)
        Try
            ' Load basic data
            currentUserID = CInt(userInfo.ID)
            currentBranchCode = userInfo.BRANCH_ID?.ToString()
            currentUserType = userInfo.USER_TYPE?.ToString()

            lblAccountID.Text = userInfo.ID.ToString()
            txtBranchID.Text = userInfo.BRANCH_ID?.ToString()
            txtFullName.Text = userInfo.FULL_NAME?.ToString()
            txtEmail.Text = userInfo.EMAIL?.ToString()
            txtContact.Text = userInfo.CONTACT?.ToString()

            ' Fill User Type combo
            cbousertype.Items.Clear()
            cbousertype.Items.AddRange({"Branch Administrator", "IT Support", "Branch Manager", "Supervisor", "Cashier", "Inventory Clerk", "Sales Staff", "Viewer"})
            If Not String.IsNullOrWhiteSpace(userInfo.USER_TYPE?.ToString()) Then
                cbousertype.SelectedItem = userInfo.USER_TYPE.ToString()
            Else
                cbousertype.SelectedIndex = 0
            End If

            ' Fill Status combo
            cboStatus.Items.Clear()
            cboStatus.Items.AddRange({"ACTIVE", "OFFLINE", "LOCKED"})
            If Not String.IsNullOrWhiteSpace(userInfo.STATUS?.ToString()) Then
                cboStatus.SelectedItem = userInfo.STATUS.ToString()
            Else
                cboStatus.SelectedIndex = 0
            End If

            ' ✅ FIX: Load branches first, then select the EXACT branch of the user
            LoadBranchCombo()
            If Not String.IsNullOrWhiteSpace(currentBranchCode) Then
                cboBranch.SelectedValue = currentBranchCode
            End If

            ' Load profile picture
            LoadImageFromDB()

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadImageFromDB()
        Try
            Using conn As New SqlConnection(ConnString)
                Dim sql As String = "SELECT PROFILE FROM User_Accounts WHERE ID = @UID"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        userImageData = CType(result, Byte())
                        Using ms As New MemoryStream(userImageData)
                            PictureBox1.Image = Image.FromStream(ms)
                            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        End Using
                    Else
                        PictureBox1.Image = Nothing
                        userImageData = Nothing
                    End If
                End Using
            End Using
        Catch
            PictureBox1.Image = Nothing
            userImageData = Nothing
        End Try
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Try
            Dim openDlg As New OpenFileDialog With {
                .Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                .Title = "Select Profile Picture"
            }

            If openDlg.ShowDialog() = DialogResult.OK Then
                userImageData = File.ReadAllBytes(openDlg.FileName)
                PictureBox1.Image = Image.FromFile(openDlg.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        Catch ex As Exception
            MessageBox.Show("Error selecting image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBranchCombo()
        Try
            Using conn As New SqlConnection(ConnString)
                Dim sql As String = "SELECT BRANCH_ID, BRANCH FROM Branches ORDER BY BRANCH ASC"
                Using cmd As New SqlCommand(sql, conn)
                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    cboBranch.DataSource = Nothing
                    cboBranch.Items.Clear()

                    cboBranch.DataSource = dt
                    cboBranch.DisplayMember = "BRANCH"   ' shows branch name
                    cboBranch.ValueMember = "BRANCH_ID" ' holds branch ID
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Basic check para sa kinakailangang impormasyon
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Full Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        If cboBranch.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a valid branch!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New SqlConnection(ConnString)
                Dim sql As String = "UPDATE User_Accounts SET " &
                                "FULL_NAME = @FN, " &
                                "USER_TYPE = @UT, " &
                                "BRANCH_ID = @BID, " &
                                "EMAIL = @EM, " &
                                "CONTACT = @CT, " &
                                "STATUS = @ST, " &
                                "PROFILE = @PROFILE"

                If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                    sql &= ", PASSWORD = @PASS"
                End If

                sql &= " WHERE ID = @UID"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    cmd.Parameters.AddWithValue("@FN", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@UT", If(cbousertype.SelectedItem IsNot Nothing, cbousertype.SelectedItem.ToString(), DBNull.Value))
                    cmd.Parameters.AddWithValue("@BID", If(cboBranch.SelectedValue IsNot Nothing, cboBranch.SelectedValue.ToString(), DBNull.Value))
                    cmd.Parameters.AddWithValue("@EM", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@CT", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@ST", If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), DBNull.Value))

                    ' Para sa litrato
                    If userImageData IsNot Nothing Then
                        cmd.Parameters.Add("@PROFILE", SqlDbType.VarBinary).Value = userImageData
                    Else
                        cmd.Parameters.Add("@PROFILE", SqlDbType.VarBinary).Value = DBNull.Value
                    End If

                    ' Palitan lang ang password kung may inilagay
                    If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                        cmd.Parameters.AddWithValue("@PASS", txtNewPass.Text.Trim())
                    End If

                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("✅ User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("⚠️ No changes were saved.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim confirm = MessageBox.Show("Are you sure you want to delete this user? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Exit Sub

        Try
            Using conn As New SqlConnection(ConnString)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        ' Prevent deleting branch when deleting regular users
                        Dim delUserSql As String = "DELETE FROM User_Accounts WHERE ID = @UID"
                        Using cmdDelUser As New SqlCommand(delUserSql, conn, trans)
                            cmdDelUser.Parameters.AddWithValue("@UID", currentUserID)
                            cmdDelUser.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        MessageBox.Show("✅ User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Catch
                        trans.Rollback()
                        MessageBox.Show("❌ Failed to delete user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class