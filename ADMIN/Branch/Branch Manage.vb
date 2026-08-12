Imports System.IO
Imports MySqlConnector

Public Class Branch_Manage

    Private branchesTable As DataTable

    Private Sub Branch_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranches()
        AuditLogger.LogAction("OPEN", "Branch Management", "Opened Branch List / Manager")
    End Sub

    Private Sub LoadBranches(Optional ByVal SearchText As String = "")
        Try
            Dim CurrentAccountID As String = Login.LoggedInAccountID

            If String.IsNullOrWhiteSpace(CurrentAccountID) Then
                MessageBox.Show("No logged-in account found. Please login again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ DAPAT MAY `BRANCH_PHOTO` SA DULO NG QUERY
            Dim Sql As String = "SELECT `ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `TIN`, `TIN_REGISTERED`, `BUSINESS_TYPE`, " &
                                 "       `ADDRESS`, `EMAIL`, `CONTACT`, `MANAGER`, `SALES`, `STATUS`, `REGISTRATION_DATE`, `BRANCH_PHOTO` " &
                                 "FROM `branches` " &
                                 "WHERE `ACCOUNT_ID` = @AccID "

            If Not String.IsNullOrWhiteSpace(SearchText) Then
                Sql &= "AND (`BRANCH` LIKE CONCAT('%', @Filter, '%') OR `ADDRESS` LIKE CONCAT('%', @Filter, '%') OR `MANAGER` LIKE CONCAT('%', @Filter, '%')) "
            End If

            Sql &= "ORDER BY `BRANCH` ASC"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using Cmd As New MySqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@AccID", CurrentAccountID)

                    If Not String.IsNullOrWhiteSpace(SearchText) Then
                        Cmd.Parameters.AddWithValue("@Filter", SearchText)
                    End If

                    Dim Da As New MySqlDataAdapter(Cmd)
                    branchesTable = New DataTable()
                    Da.Fill(branchesTable)

                    dgvBranches.DataSource = Nothing
                    dgvBranches.DataSource = branchesTable

                    SetupDataGridViewHeaders()

                    If branchesTable.Rows.Count = 0 Then
                        MessageBox.Show("No branches found under your account." & vbCrLf &
                                        "Account ID: " & CurrentAccountID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ ITINAGO: Account ID, Account Name — KASAMA NA ANG BILANG NG COLUMN
    Private Sub SetupDataGridViewHeaders()
        ' ✅ DAPAT >= 15 NA DAHIL MAY BAGONG COLUMN
        If dgvBranches.Columns.Count >= 15 Then
            dgvBranches.Columns(0).Visible = False
            dgvBranches.Columns(1).Visible = False

            dgvBranches.Columns(2).HeaderText = "Branch ID"
            dgvBranches.Columns(3).HeaderText = "Branch Name"
            dgvBranches.Columns(4).HeaderText = "TIN"
            dgvBranches.Columns(5).HeaderText = "TIN Registered"
            dgvBranches.Columns(6).HeaderText = "Business Type"
            dgvBranches.Columns(7).HeaderText = "Address"
            dgvBranches.Columns(8).HeaderText = "Email"
            dgvBranches.Columns(9).HeaderText = "Contact"
            dgvBranches.Columns(10).HeaderText = "Manager"
            dgvBranches.Columns(11).HeaderText = "Sales"
            dgvBranches.Columns(12).HeaderText = "Status"
            dgvBranches.Columns(13).HeaderText = "Registration Date"
            dgvBranches.Columns(14).HeaderText = "Branch Photo"
            dgvBranches.Columns(14).Visible = False

            For Each col As DataGridViewColumn In dgvBranches.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If
    End Sub

    Private Sub dgvBranches_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBranches.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            Dim row As DataGridViewRow = dgvBranches.Rows(e.RowIndex)

            Dim branchInfo As New Dictionary(Of String, String)()

            branchInfo("BranchID") = If(row.Cells("BRANCH_ID").Value?.ToString().Trim(), "")
            branchInfo("BranchName") = If(row.Cells("BRANCH").Value?.ToString().Trim(), "")
            branchInfo("TIN") = If(row.Cells("TIN").Value?.ToString().Trim(), "")
            branchInfo("TINRegistered") = If(row.Cells("TIN_REGISTERED").Value?.ToString().Trim(), "")
            branchInfo("BusinessType") = If(row.Cells("BUSINESS_TYPE").Value?.ToString().Trim(), "")
            branchInfo("Address") = If(row.Cells("ADDRESS").Value?.ToString().Trim(), "")
            branchInfo("Email") = If(row.Cells("EMAIL").Value?.ToString().Trim(), "")
            branchInfo("Contact") = If(row.Cells("CONTACT").Value?.ToString().Trim(), "")
            branchInfo("Manager") = If(row.Cells("MANAGER").Value?.ToString().Trim(), "")
            branchInfo("Sales") = If(row.Cells("SALES").Value?.ToString().Trim(), "")
            branchInfo("Status") = If(row.Cells("STATUS").Value?.ToString().Trim(), "")
            branchInfo("RegistrationDate") = If(row.Cells("REGISTRATION_DATE").Value?.ToString().Trim(), "")

            ' ✅ KUNG MAY BRANCH_PHOTO, KUNIN — KUNG WALA, WALANG LAMAN
            If dgvBranches.Columns.Contains("BRANCH_PHOTO") Then
                branchInfo("BranchPhoto") = If(row.Cells("BRANCH_PHOTO").Value?.ToString().Trim(), "")
            Else
                branchInfo("BranchPhoto") = ""
            End If

            Dim frmInfo As New frmBranch_Information(branchInfo)
            frmInfo.ShowDialog()

            AuditLogger.LogAction("VIEW", "Branch Information", $"Viewed details for: {branchInfo("BranchName")}")

        Catch ex As Exception
            MessageBox.Show("❌ Error opening branch information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub AddBranchFromSelectionFull(adminAccID As String, adminAccName As String, newBranchID As String,
                                           branchName As String, tin As String, tinRegistered As String, businessType As String,
                                           address As String, email As String, contact As String,
                                           manager As String, sales As String, status As String,
                                           regDate As Date?)

        Try
            If branchesTable Is Nothing Then LoadBranches()

            Dim newRegDate As Date = If(regDate.HasValue, regDate.Value, DateTime.Now)
            Dim newStatus As String = If(String.IsNullOrWhiteSpace(status), "Active", status)

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                Dim insertSql As String = "INSERT INTO `branches` " &
                    "(`ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `TIN`, `TIN_REGISTERED`, `BUSINESS_TYPE`, " &
                    " `ADDRESS`, `EMAIL`, `CONTACT`, `MANAGER`, `SALES`, `STATUS`, `REGISTRATION_DATE`) " &
                    "VALUES (@AccID, @AccName, @BranchID, @BranchName, @TIN, @TinReg, @BusType, " &
                    "        @Address, @Email, @Contact, @Manager, @Sales, @Status, @RegDate)"

                Using cmd As New MySqlCommand(insertSql, conn)
                    cmd.Parameters.AddWithValue("@AccID", adminAccID)
                    cmd.Parameters.AddWithValue("@AccName", adminAccName)
                    cmd.Parameters.AddWithValue("@BranchID", newBranchID)
                    cmd.Parameters.AddWithValue("@BranchName", branchName)
                    cmd.Parameters.AddWithValue("@TIN", tin)
                    cmd.Parameters.AddWithValue("@TinReg", tinRegistered)
                    cmd.Parameters.AddWithValue("@BusType", businessType)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Contact", contact)
                    cmd.Parameters.AddWithValue("@Manager", manager)
                    cmd.Parameters.AddWithValue("@Sales", sales)
                    cmd.Parameters.AddWithValue("@Status", newStatus)
                    cmd.Parameters.AddWithValue("@RegDate", newRegDate)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            LoadBranches()

            MessageBox.Show("✅ Naidagdag at NAI-SAVE na!" & vbCrLf & "Branch ID: " & newBranchID,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("❌ Error adding branch: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBranches(txtSearch.Text.Trim())
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ADD_Branch.Show()
        AuditLogger.LogAction("OPEN", "Branch Management", "Opened Add New Branch form from list")
    End Sub

End Class