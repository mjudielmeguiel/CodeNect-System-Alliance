Imports System.Data
Imports MySqlConnector
Imports System.Drawing
Imports System.IO

Public Class Edit_User

    Private currentUserID As Integer
    Private userImageData As Byte() = Nothing
    Private connStr As String = DBConnection.connStr

    Public Sub LoadUserDetails(userInfo As Object)
        Try
            currentUserID = CInt(userInfo.ID)
            txtBranchID.Text = userInfo.BRANCH_ID?.ToString()
            txtFullName.Text = userInfo.FULL_NAME?.ToString()
            txtEmail.Text = userInfo.EMAIL?.ToString()
            txtContact.Text = userInfo.CONTACT?.ToString()

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

            cboStatus.Items.Clear()
            cboStatus.Items.AddRange({"ACTIVE", "OFFLINE", "LOCKED"})
            If Not String.IsNullOrWhiteSpace(userInfo.STATUS?.ToString()) Then
                cboStatus.SelectedItem = userInfo.STATUS.ToString()
            Else
                cboStatus.SelectedIndex = 0
            End If

            LoadBranchCombo()
            If Not String.IsNullOrWhiteSpace(userInfo.BRANCH_ID?.ToString()) Then
                cboBranch.SelectedValue = userInfo.BRANCH_ID.ToString()
            End If

            LoadImageFromDB()
            AuditLogger.LogAction("LOAD_USER_EDIT", "EditUser", $"Loaded user for edit | ID: {currentUserID} | Name: {txtFullName.Text}")
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "EditUser", $"Load user failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadImageFromDB()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "SELECT `PROFILE` FROM `User_Accounts` WHERE `ID` = @UID"
                Using cmd As New MySqlCommand(sql, conn)
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
            Using openDlg As New OpenFileDialog With {
                .Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                .Title = "Select Profile Picture"
            }
                If openDlg.ShowDialog() = DialogResult.OK Then
                    userImageData = File.ReadAllBytes(openDlg.FileName)
                    PictureBox1.Image = Image.FromFile(openDlg.FileName)
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    AuditLogger.LogAction("PROFILE_PIC_UPD", "EditUser", $"Profile picture changed | User ID: {currentUserID}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error selecting image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "EditUser", $"Change profile pic failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadBranchCombo()
        Try
            Dim dt As New DataTable()
            Dim sql As String = "SELECT `BRANCH_ID`, `BRANCH` FROM `Branches` ORDER BY `BRANCH` ASC"
            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            cboBranch.DataSource = Nothing
            cboBranch.DataSource = dt
            cboBranch.DisplayMember = "BRANCH"
            cboBranch.ValueMember = "BRANCH_ID"
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "EditUser", $"Load branches failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
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
                UPDATE `User_Accounts` 
                SET 
                    `FULL_NAME` = @FN,
                    `USER_TYPE` = @UT,
                    `BRANCH_ID` = @BID,
                    `BRANCH` = @BName,
                    `EMAIL` = @EM,
                    `CONTACT` = @CT,
                    `STATUS` = @ST,
                    `PROFILE` = @PROFILE"
            If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                sql &= ", `PASSWORD` = @PASS"
            End If
            sql &= " WHERE `ID` = @UID"

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    cmd.Parameters.AddWithValue("@FN", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@UT", If(cbousertype.SelectedItem IsNot Nothing, cbousertype.SelectedItem.ToString().Trim(), DBNull.Value))
                    cmd.Parameters.AddWithValue("@BID", cboBranch.SelectedValue.ToString().Trim())
                    cmd.Parameters.AddWithValue("@BName", cboBranch.Text.Trim())
                    cmd.Parameters.AddWithValue("@EM", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@CT", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@ST", If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString().Trim(), DBNull.Value))
                    cmd.Parameters.AddWithValue("@PROFILE", If(userImageData IsNot Nothing, userImageData, DBNull.Value))
                    If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                        cmd.Parameters.AddWithValue("@PASS", txtNewPass.Text.Trim())
                        AuditLogger.LogAction("PASS_CHANGE", "EditUser", $"Password updated | User ID: {currentUserID}")
                    End If
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("✅ User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        AuditLogger.LogAction("USER_UPDATED", "EditUser", $"User updated | ID: {currentUserID} | Name: {txtFullName.Text} | Type: {cbousertype.Text} | Status: {cboStatus.Text}")
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("⚠️ No changes were saved.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        AuditLogger.LogAction("NO_CHANGES", "EditUser", $"No changes saved | User ID: {currentUserID}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("UPDATE_ERROR", "EditUser", $"Update failed | ID: {currentUserID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim confirm = MessageBox.Show(
            "Are you sure you want to delete this user? This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
        )
        If confirm = DialogResult.No Then
            AuditLogger.LogAction("DELETE_CANCEL", "EditUser", $"User delete cancelled | ID: {currentUserID}")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        Dim delSql As String = "DELETE FROM `User_Accounts` WHERE `ID` = @UID"
                        Using cmd As New MySqlCommand(delSql, conn, trans)
                            cmd.Parameters.AddWithValue("@UID", currentUserID)
                            cmd.ExecuteNonQuery()
                        End Using
                        trans.Commit()
                        MessageBox.Show("✅ User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        AuditLogger.LogAction("USER_DELETED", "EditUser", $"User deleted | ID: {currentUserID} | Name: {txtFullName.Text}")
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Catch exTrans As Exception
                        trans.Rollback()
                        MessageBox.Show("❌ Failed to delete user: " & exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        AuditLogger.LogAction("DELETE_ROLLBACK", "EditUser", $"Delete rolled back | ID: {currentUserID} | Error: {exTrans.Message}")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("DELETE_ERROR", "EditUser", $"Delete failed | ID: {currentUserID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        AuditLogger.LogAction("CANCEL_EDIT_USER", "EditUser", "Edit User cancelled by user")
        Me.Close()
    End Sub

    Private Sub Edit_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AuditLogger.LogAction("OPEN_EDIT_USER", "EditUser", "Opened Edit User form")
    End Sub

End Class