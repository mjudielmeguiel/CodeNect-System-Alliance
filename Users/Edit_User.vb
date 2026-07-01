Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Edit_User

    Private currentUserID As Integer
    Private userImageData As Byte() = Nothing

    Public Sub LoadUserDetails(userInfo As Object)
        Try
            ' Load basic data
            currentUserID = CInt(userInfo.ID)
            txtBranchID.Text = userInfo.BRANCH_ID?.ToString()
            txtFullName.Text = userInfo.FULL_NAME?.ToString()
            txtEmail.Text = userInfo.EMAIL?.ToString()
            txtContact.Text = userInfo.CONTACT?.ToString()

            ' Fill User Type combo
            cbousertype.Items.Clear()
            cbousertype.Items.AddRange({
                "Branch Administrator", "IT Support", "Branch Manager",
                "Supervisor", "Cashier", "Inventory Clerk", "Sales Staff", "Viewer"
            })
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

            ' Load branches and select current user's branch
            LoadBranchCombo()
            If Not String.IsNullOrWhiteSpace(userInfo.BRANCH_ID?.ToString()) Then
                cboBranch.SelectedValue = userInfo.BRANCH_ID.ToString()
            End If

            ' Load existing profile picture
            LoadImageFromDB()

        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadImageFromDB()
        Try
            Using conn As New SqlConnection(connStr)
                Dim sql As String = "SELECT PROFILE FROM User_Accounts WHERE ID = @UID"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@UID", SqlDbType.Int).Value = currentUserID
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
            Using openDlg As New OpenFileDialog With {
                .Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                .Title = "Select Profile Picture"
            }
                If openDlg.ShowDialog() = DialogResult.OK Then
                    userImageData = File.ReadAllBytes(openDlg.FileName)
                    PictureBox1.Image = Image.FromFile(openDlg.FileName)
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error selecting image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBranchCombo()
        Try
            Dim dt As New DataTable()
            Dim sql As String = "SELECT BRANCH_ID, BRANCH FROM Branches ORDER BY BRANCH ASC"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, conn)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            cboBranch.DataSource = Nothing
            cboBranch.DataSource = dt
            cboBranch.DisplayMember = "BRANCH"    ' Shows branch name
            cboBranch.ValueMember = "BRANCH_ID"  ' Stores branch ID

        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Validation
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
            Dim sql As String = "
                UPDATE User_Accounts 
                SET 
                    FULL_NAME = @FN,
                    USER_TYPE = @UT,
                    BRANCH_ID = @BID,
                    BRANCH = @BName,
                    EMAIL = @EM,
                    CONTACT = @CT,
                    STATUS = @ST,
                    PROFILE = @PROFILE"

            ' Only update password if a new one is provided
            If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                sql &= ", PASSWORD = @PASS"
            End If

            sql &= " WHERE ID = @UID"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@UID", SqlDbType.Int).Value = currentUserID
                    cmd.Parameters.Add("@FN", SqlDbType.NVarChar, 150).Value = txtFullName.Text.Trim()
                    cmd.Parameters.Add("@UT", SqlDbType.NVarChar, 50).Value = If(cbousertype.SelectedItem IsNot Nothing, cbousertype.SelectedItem.ToString().Trim(), DBNull.Value)
                    cmd.Parameters.Add("@BID", SqlDbType.NVarChar, 20).Value = cboBranch.SelectedValue.ToString().Trim()
                    cmd.Parameters.Add("@BName", SqlDbType.NVarChar, 100).Value = cboBranch.Text.Trim()
                    cmd.Parameters.Add("@EM", SqlDbType.NVarChar, 100).Value = If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim())
                    cmd.Parameters.Add("@CT", SqlDbType.NVarChar, 30).Value = If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim())
                    cmd.Parameters.Add("@ST", SqlDbType.NVarChar, 20).Value = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString().Trim(), DBNull.Value)
                    cmd.Parameters.Add("@PROFILE", SqlDbType.VarBinary).Value = If(userImageData IsNot Nothing, userImageData, DBNull.Value)

                    If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                        ' Note: For production, use hashing instead of plain text
                        cmd.Parameters.Add("@PASS", SqlDbType.NVarChar, 100).Value = txtNewPass.Text.Trim()
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
            MessageBox.Show("❌ Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim confirm = MessageBox.Show(
            "Are you sure you want to delete this user? This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
        )
        If confirm = DialogResult.No Then Return

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        Dim delSql As String = "DELETE FROM User_Accounts WHERE ID = @UID"
                        Using cmd As New SqlCommand(delSql, conn, trans)
                            cmd.Parameters.Add("@UID", SqlDbType.Int).Value = currentUserID
                            cmd.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        MessageBox.Show("✅ User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Catch exTrans As Exception
                        trans.Rollback()
                        MessageBox.Show("❌ Failed to delete user: " & exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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