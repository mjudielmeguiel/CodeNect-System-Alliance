Imports System.Data
Imports System.Text
Imports MySqlConnector

Public Class frmUsermanager

    Private connStr As String = DBConnection.connStr

    Private Sub frmUsermanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupColumns()
        SetupRoleFilter()
        LoadData()
        AuditLogger.LogAction("OPEN", "User Management", "Opened User Manager / User List")
    End Sub

    Private Sub SetupColumns()
        dgvUsers.Columns.Clear()
        dgvUsers.Columns.Add("FULL_NAME", "FULL NAME")
        dgvUsers.Columns.Add("USER_TYPE", "USER TYPE")
        dgvUsers.Columns.Add("BRANCH_NAME", "BRANCH NAME")
        dgvUsers.Columns.Add("EMAIL", "EMAIL")
        dgvUsers.Columns.Add("CONTACT", "CONTACT")
        dgvUsers.Columns.Add("LOGIN_ATTEMPTS", "LOGIN ATTEMPTS")
        dgvUsers.Columns.Add("STATUS", "STATUS")
        dgvUsers.Columns.Add("DATE_CREATED", "DATE CREATED")
    End Sub

    Private Sub SetupRoleFilter()
        cboRole.Items.Clear()
        cboRole.Items.Add("ALL")
        cboRole.Items.Add("Admin")
        cboRole.Items.Add("IT Support")
        cboRole.Items.Add("Branch Manager")
        cboRole.Items.Add("Supervisor")
        cboRole.Items.Add("Cashier")
        cboRole.Items.Add("Receiving Department Unit")
        cboRole.Items.Add("Inventory Clerk")
        cboRole.Items.Add("Sales Staff")
        cboRole.SelectedIndex = 0
    End Sub

    Public Sub LoadData()
        Dim searchText As String = txtSearch.Text.Trim()
        Dim selectedRole As String = cboRole.SelectedItem.ToString()
        dgvUsers.Rows.Clear()

        Try
            Dim sql As New StringBuilder()
            sql.AppendLine("SELECT ")
            sql.AppendLine("    u.`id`, u.`full_name`, u.`user_type`, u.`branch_id`, u.`account_id`, ")
            sql.AppendLine("    u.`branch_name`, u.`email`, u.`contact`, u.`login_attempts`, u.`status`, u.`date_created`")
            sql.AppendLine("FROM `user_accounts` u")
            sql.AppendLine("WHERE 1 = 1")

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand()
                    cmd.Connection = conn

                    ' =====================================================
                    ' 🔐 PANUNTUNAN SA PAGKITA NG LISTAHAN
                    ' =====================================================
                    ' ✅ ADMIN: MAKIKITA LAHAT NG USER NA SAKOP NG KANYANG ACCOUNT ID
                    If Login.IsAdminAccount Then
                        cmd.Parameters.AddWithValue("@AccID", Login.LoggedInAccountID)
                        sql.AppendLine(" AND u.`account_id` = @AccID")
                    Else
                        ' ✅ BRANCH USER: MAKIKITA LANG NASA KANYANG BRANCH
                        cmd.Parameters.AddWithValue("@BranchID", Login.LoggedInBranchID)
                        sql.AppendLine(" AND u.`branch_id` = @BranchID")
                    End If

                    ' FILTER NG ROLE
                    If selectedRole <> "ALL" Then
                        cmd.Parameters.AddWithValue("@Role", selectedRole)
                        sql.AppendLine(" AND u.`user_type` = @Role")
                    End If

                    ' FILTER NG PAGHANAP
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@Search", "%" & searchText & "%")
                        sql.AppendLine(" AND u.`full_name` LIKE @Search")
                    End If

                    sql.AppendLine(" ORDER BY u.`date_created` DESC")
                    cmd.CommandText = sql.ToString()

                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim userID As Integer = CInt(dr("id"))
                            Dim fullName As String = dr("full_name").ToString().Trim()
                            Dim userType As String = If(IsDBNull(dr("user_type")), "", dr("user_type").ToString().Trim())
                            Dim branchName As String = If(IsDBNull(dr("branch_name")), "", dr("branch_name").ToString().Trim())
                            Dim branchID As String = If(IsDBNull(dr("branch_id")), "", dr("branch_id").ToString().Trim())
                            Dim email As String = If(IsDBNull(dr("email")), "", dr("email").ToString().Trim())
                            Dim contact As String = If(IsDBNull(dr("contact")), "", dr("contact").ToString().Trim())
                            Dim loginAttempts As Integer = If(IsDBNull(dr("login_attempts")), 0, Convert.ToInt32(dr("login_attempts")))
                            Dim status As String = If(IsDBNull(dr("status")), "", dr("status").ToString().Trim())
                            Dim dateCreated As DateTime = Convert.ToDateTime(dr("date_created"))

                            Dim rowIndex As Integer = dgvUsers.Rows.Add(
                                    fullName,
                                    userType,
                                    branchName,
                                    email,
                                    contact,
                                    loginAttempts.ToString(),
                                    status,
                                    dateCreated.ToString("yyyy-MM-dd")
                                )

                            dgvUsers.Rows(rowIndex).Cells(0).Tag = New With {
                                    .ID = userID,
                                    .FULL_NAME = fullName,
                                    .USER_TYPE = userType,
                                    .BRANCH = branchName,
                                    .BRANCH_ID = branchID,
                                    .EMAIL = email,
                                    .CONTACT = contact,
                                    .STATUS = status
                                }
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "User Management", $"Failed to load user list: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellDoubleClick
        If e.RowIndex < 0 Then Return

        Dim selectedTag = dgvUsers.Rows(e.RowIndex).Cells(0).Tag
        If selectedTag IsNot Nothing Then
            Dim editForm As New Edit_User()
            editForm.LoadUserDetails(selectedTag)
            editForm.ShowDialog()
            LoadData()
            AuditLogger.LogAction("OPEN", "User Management", $"Opened Edit User form for: {selectedTag.FULL_NAME}")
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadData()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Add_User.Show()
        AuditLogger.LogAction("OPEN", "User Management", "Opened Add New User form")
    End Sub

    Private Sub cboRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRole.SelectedIndexChanged
        LoadData()
    End Sub

End Class