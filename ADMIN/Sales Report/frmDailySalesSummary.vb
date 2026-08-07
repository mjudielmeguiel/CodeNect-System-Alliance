Imports System.Data
Imports MySqlConnector

Public Class frmDailySalesSummary

    Private connStr As String = DBConnection.connStr
    Private ReadOnly _CurrentBranchID As String = Login.LoggedInBranchID

    Private Sub frmDailySalesSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date
        LoadSalesSummary()
        AuditLogger.LogAction("OPEN_DAILY_SUM", "DailySalesSum", $"Opened Daily Sales Summary — Filtered to Branch: {_CurrentBranchID}")
    End Sub

    Private Sub LoadSalesSummary()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As New Text.StringBuilder()
                sql.AppendLine("SELECT")
                sql.AppendLine("    `summary_id`,")
                sql.AppendLine("    `account_id`,")
                sql.AppendLine("    `branch_id`,")
                sql.AppendLine("    `user_id`,")
                sql.AppendLine("    `cashier_name`,")
                sql.AppendLine("    `transaction_date`,")
                sql.AppendLine("    `total_transactions`,")
                sql.AppendLine("    `total_sales`,")
                sql.AppendLine("    `total_cash`,")
                sql.AppendLine("    `total_online`,")
                sql.AppendLine("    `date_added`")
                sql.AppendLine("FROM `daily_sales_summary`")
                sql.AppendLine("WHERE `transaction_date` BETWEEN @DateFrom AND @DateTo")
                sql.AppendLine("AND `branch_id` = @BranchID")
                sql.AppendLine("ORDER BY `transaction_date` DESC, `cashier_name`")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@DateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@DateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
                    cmd.Parameters.AddWithValue("@BranchID", _CurrentBranchID)

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvBranchList.DataSource = dt
                    FormatSummaryGrid()
                    CalculateTotals(dt)
                    AuditLogger.LogAction("SUMMARY_LOADED", "DailySalesSum", $"Loaded {dt.Rows.Count} records | Branch: {_CurrentBranchID} | From: {dtpFrom.Value:yyyy-MM-dd} To: {dtpTo.Value:yyyy-MM-dd}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading sales summary: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "DailySalesSum", $"Load summary failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatSummaryGrid()
        With dgvBranchList
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False

            If .Columns.Contains("summary_id") Then .Columns("summary_id").Visible = False
            If .Columns.Contains("account_id") Then .Columns("account_id").Visible = False
            If .Columns.Contains("branch_id") Then .Columns("branch_id").Visible = False
            If .Columns.Contains("user_id") Then .Columns("user_id").Visible = False

            For Each colName In {"total_sales", "total_cash", "total_online"}
                If .Columns.Contains(colName) Then
                    .Columns(colName).DefaultCellStyle.Format = "N2"
                    .Columns(colName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

            If .Columns.Contains("cashier_name") Then .Columns("cashier_name").HeaderText = "Cashier Name"
            If .Columns.Contains("transaction_date") Then .Columns("transaction_date").HeaderText = "Sales Date"
            If .Columns.Contains("total_transactions") Then .Columns("total_transactions").HeaderText = "No. of Transactions"
            If .Columns.Contains("total_sales") Then .Columns("total_sales").HeaderText = "Total Sales"
            If .Columns.Contains("total_cash") Then .Columns("total_cash").HeaderText = "Cash Sales"
            If .Columns.Contains("total_online") Then .Columns("total_online").HeaderText = "Online Sales"
            If .Columns.Contains("date_added") Then .Columns("date_added").HeaderText = "Recorded On"
        End With
    End Sub

    Private Sub CalculateTotals(dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            lblGrandTotal.Text = "Grand Total: ₱0.00"
            Return
        End If
        Dim totalSales As Decimal = 0
        Dim totalCash As Decimal = 0
        Dim totalOnline As Decimal = 0
        Dim totalTx As Integer = 0

        For Each row As DataRow In dt.Rows
            totalSales += Convert.ToDecimal(row("total_sales"))
            totalCash += Convert.ToDecimal(row("total_cash"))
            totalOnline += Convert.ToDecimal(row("total_online"))
            totalTx += Convert.ToInt32(row("total_transactions"))
        Next

        lblGrandTotal.Text = $"Grand Total: ₱{totalSales:N2} | Cash: ₱{totalCash:N2} | Online: ₱{totalOnline:N2} | Transactions: {totalTx}"
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        AuditLogger.LogAction("FILTER_LOAD", "DailySalesSum", "User clicked Load/Filter")
        LoadSalesSummary()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date
        AuditLogger.LogAction("FILTER_RESET", "DailySalesSum", "Date filters reset to default")
        LoadSalesSummary()
    End Sub

    Private Sub dgvSummary_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBranchList.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Try
            Dim row As DataGridViewRow = dgvBranchList.Rows(e.RowIndex)

            Dim selectedDate As Date
            If Not Date.TryParse(row.Cells("transaction_date").Value?.ToString(), selectedDate) Then
                MessageBox.Show("Hindi mabasa ang petsa.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim selectedBranchId As String = row.Cells("branch_id").Value?.ToString().Trim()
            Dim selectedUserId As Integer = 0
            Integer.TryParse(row.Cells("user_id").Value?.ToString(), selectedUserId)
            Dim selectedCashierName As String = row.Cells("cashier_name").Value?.ToString().Trim()

            AuditLogger.LogAction("VIEW_DETAIL", "DailySalesSum", $"Open | Date: {selectedDate:yyyy-MM-dd} | UserID: {selectedUserId} | {selectedCashierName}")

            Dim frmTrans As New frmSalesTransactions()
            frmTrans.dtpFrom.Value = selectedDate.Date
            frmTrans.dtpTo.Value = selectedDate.Date.AddDays(1).AddSeconds(-1)

            If frmTrans.cboBranch.DataSource IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedBranchId) Then
                For Each itm In frmTrans.cboBranch.Items
                    If TypeOf itm Is DataRowView Then
                        Dim drv = CType(itm, DataRowView)
                        If drv("branch_id").ToString().Trim().Equals(selectedBranchId, StringComparison.OrdinalIgnoreCase) Then
                            frmTrans.cboBranch.SelectedItem = itm
                            frmTrans.cboBranch.Enabled = False
                            Exit For
                        End If
                    End If
                Next
            End If

            If frmTrans.cboCashier.DataSource IsNot Nothing AndAlso selectedUserId > 0 Then
                For Each itm In frmTrans.cboCashier.Items
                    If TypeOf itm Is DataRowView Then
                        Dim drv = CType(itm, DataRowView)
                        Dim uid As Integer = 0
                        If Integer.TryParse(drv("user_id").ToString(), uid) AndAlso uid = selectedUserId Then
                            frmTrans.cboCashier.SelectedItem = itm
                            Exit For
                        End If
                    End If
                Next
            End If

            frmTrans.LoadTransactions()
            frmTrans.Text = $"Transactions: {selectedDate:MMM dd, yyyy} — {selectedCashierName}"

            Dim parentDash As frmDashboard = CType(Me.ParentForm, frmDashboard)
            parentDash.Panelmenu.SuspendLayout()
            parentDash.Panelmenu.Controls.Clear()
            frmTrans.TopLevel = False
            frmTrans.FormBorderStyle = FormBorderStyle.None
            frmTrans.Dock = DockStyle.Fill
            frmTrans.BringToFront()
            parentDash.Panelmenu.Controls.Add(frmTrans)
            parentDash.Panelmenu.ResumeLayout()
            frmTrans.Show()

        Catch ex As Exception
            MessageBox.Show($"Hindi mabuksan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "DailySalesSum", $"DoubleClick Error: {ex.Message} | {ex.StackTrace}")
        End Try
    End Sub
End Class