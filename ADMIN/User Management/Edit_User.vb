Imports System.Data
Imports System.Drawing
Imports MySqlConnector

Public Class Edit_User

    Private currentUserID As Integer
    Private connStr As String = DBConnection.connStr
    Private isEditingAdmin As Boolean = False
    Private currentUserStatus As String = ""

    Public Sub LoadUserDetails(userInfo As Object)
        Try
            currentUserID = CInt(userInfo.ID)
            txtFullName.Text = userInfo.FULL_NAME?.ToString()
            txtEmail.Text = userInfo.EMAIL?.ToString()
            txtContact.Text = userInfo.CONTACT?.ToString()
            currentUserStatus = If(userInfo.STATUS?.ToString(), "OFFLINE").ToUpper()
            lblStatus.Text = "Status: " & currentUserStatus
            isEditingAdmin = userInfo.USER_TYPE?.ToString().Equals("BUSINESS ADMIN", StringComparison.OrdinalIgnoreCase)
            cbousertype.Items.Clear()
            cbousertype.Items.AddRange({
                "Branch Administrator", "IT Support", "Branch Manager", "Supervisor",
                "Cashier", "Receiving Department Unit", "Inventory Clerk", "Sales Staff"
            })
            If Not String.IsNullOrWhiteSpace(userInfo.USER_TYPE?.ToString()) Then
                cbousertype.SelectedItem = userInfo.USER_TYPE.ToString()
            End If
            LoadBranchList()
            If Not String.IsNullOrWhiteSpace(userInfo.BRANCH_ID?.ToString()) Then
                cboBranch.SelectedValue = userInfo.BRANCH_ID.ToString()
            End If
            btnResetStatus.Visible = True
            btnResetStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBranchList()
        Try
            Dim dt As New DataTable()
            Dim sql As String = "SELECT DISTINCT BRANCH_ID, BRANCH FROM branches GROUP BY BRANCH_ID, BRANCH ORDER BY BRANCH ASC"
            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            cboBranch.DataSource = Nothing
            cboBranch.DisplayMember = Nothing
            cboBranch.ValueMember = Nothing
            cboBranch.DisplayMember = "BRANCH"
            cboBranch.ValueMember = "BRANCH_ID"
            cboBranch.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Branch Load Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetStatus_Click(sender As Object, e As EventArgs) Handles btnResetStatus.Click
        If MessageBox.Show("Reset locked account to OFFLINE?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        Try
            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand("UPDATE user_accounts SET STATUS = 'OFFLINE' WHERE ID = @UID", conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            currentUserStatus = "OFFLINE"
            lblStatus.Text = "Status: " & currentUserStatus
            MessageBox.Show("Status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Enter full name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If
        If cboBranch.SelectedIndex = -1 Then
            MessageBox.Show("Select a branch!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim newBranchID As String = cboBranch.SelectedValue.ToString()
            Dim newType As String = If(cbousertype.SelectedItem IsNot Nothing, cbousertype.SelectedItem.ToString(), "")

            Dim sql As String = "UPDATE user_accounts SET FULL_NAME = @FN, USER_TYPE = @UT, BRANCH_ID = @BID, EMAIL = @EM, CONTACT = @CT"
            If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then sql &= ", PASSWORD = @PASS"
            sql &= " WHERE ID = @UID"

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    cmd.Parameters.AddWithValue("@FN", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@UT", newType)
                    cmd.Parameters.AddWithValue("@BID", newBranchID)
                    cmd.Parameters.AddWithValue("@EM", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@CT", txtContact.Text.Trim())
                    If Not String.IsNullOrWhiteSpace(txtNewPass.Text) Then
                        cmd.Parameters.AddWithValue("@PASS", txtNewPass.Text.Trim())
                    End If
                    conn.Open()
                    Dim rows = cmd.ExecuteNonQuery()
                    MessageBox.Show("Done! Updated rows: " & rows & vbCrLf & "New Branch ID saved: " & newBranchID, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If isEditingAdmin Then
            MessageBox.Show("Cannot delete ADMIN account!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return
        Try
            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand("DELETE FROM user_accounts WHERE ID = @UID", conn)
                    cmd.Parameters.AddWithValue("@UID", currentUserID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("User deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Delete Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class