Imports System.Data
Imports MySqlConnector

Public Class frmDailySalesSummary

    Private connStr As String = DBConnection.connStr

    Private Sub frmDailySalesSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date
        LoadBranches()
        LoadSalesSummary()
        AuditLogger.LogAction("OPEN_DAILY_SUM", "DailySalesSum", "Opened Daily Sales Summary — User/Admin access")
    End Sub

    Private Sub LoadBranches()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "SELECT DISTINCT `BRANCH_ID`, `BRANCH` FROM `Branches` ORDER BY `BRANCH`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dt.Rows.InsertAt(dt.NewRow(), 0)
                    dt.Rows(0)("BRANCH_ID") = ""
                    dt.Rows(0)("BRANCH") = "-- All Branches --"
                    cboBranch.DisplayMember = "BRANCH"
                    cboBranch.ValueMember = "BRANCH_ID"
                    cboBranch.DataSource = dt
                End Using
            End Using
            AuditLogger.LogAction("BRANCHES_LOADED", "DailySalesSum", "Branch list loaded")
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "DailySalesSum", $"Load branches failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadSalesSummary()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As New Text.StringBuilder()
                sql.AppendLine("SELECT")
                sql.AppendLine("    `SummaryID`,")
                sql.AppendLine("    `Branch_Code`,")
                sql.AppendLine("    `Cashier_ID`,")
                sql.AppendLine("    `Cashier_Name`,")
                sql.AppendLine("    `Transaction_Date`,")
                sql.AppendLine("    `Total_Transactions`,")
                sql.AppendLine("    `Total_Sales_Amount`,")
                sql.AppendLine("    `Total_Cash`,")
                sql.AppendLine("    `Total_Online`,")
                sql.AppendLine("    `Date_Added`")
                sql.AppendLine("FROM `Daily_Sales_Summary`")
                sql.AppendLine("WHERE `Transaction_Date` BETWEEN @DateFrom AND @DateTo")
                If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                    sql.AppendLine("AND `Branch_Code` = @BranchCode")
                End If
                sql.AppendLine("ORDER BY `Transaction_Date` DESC, `Branch_Code`, `Cashier_Name`")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@DateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@DateTo", dtpTo.Value.Date)
                    If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                        cmd.Parameters.AddWithValue("@BranchCode", cboBranch.SelectedValue.ToString())
                    End If

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvSummary.DataSource = dt
                    FormatSummaryGrid()
                    CalculateTotals(dt)
                    AuditLogger.LogAction("SUMMARY_LOADED", "DailySalesSum", $"Loaded {dt.Rows.Count} records | From: {dtpFrom.Value:yyyy-MM-dd} To: {dtpTo.Value:yyyy-MM-dd} | Branch: {cboBranch.Text}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading sales summary: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "DailySalesSum", $"Load summary failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatSummaryGrid()
        With dgvSummary
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .Columns("SummaryID").Visible = False
            .Columns("Branch_Code").Visible = False
            .Columns("Cashier_ID").Visible = False
            .Columns("Total_Sales_Amount").DefaultCellStyle.Format = "N2"
            .Columns("Total_Cash").DefaultCellStyle.Format = "N2"
            .Columns("Total_Online").DefaultCellStyle.Format = "N2"
            .Columns("Total_Sales_Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Online").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Cashier_Name").HeaderText = "Cashier Name"
            .Columns("Transaction_Date").HeaderText = "Sales Date"
            .Columns("Total_Transactions").HeaderText = "No. of Transactions"
            .Columns("Total_Sales_Amount").HeaderText = "Total Sales"
            .Columns("Total_Cash").HeaderText = "Cash Sales"
            .Columns("Total_Online").HeaderText = "Online Sales"
            .Columns("Date_Added").HeaderText = "Recorded On"
        End With
    End Sub

    Private Sub CalculateTotals(dt As DataTable)
        If dt.Rows.Count = 0 Then
            lblGrandTotal.Text = "Grand Total: ₱0.00"
            Return
        End If
        Dim totalSales As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Total_Sales_Amount"))
        Dim totalCash As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Total_Cash"))
        Dim totalOnline As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Total_Online"))
        Dim totalTx As Integer = dt.AsEnumerable().Sum(Function(r) r.Field(Of Integer)("Total_Transactions"))
        lblGrandTotal.Text = $"Grand Total: ₱{totalSales:N2} | Cash: ₱{totalCash:N2} | Online: ₱{totalOnline:N2} | Transactions: {totalTx}"
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        AuditLogger.LogAction("FILTER_LOAD", "DailySalesSum", "User clicked Load/Filter")
        LoadSalesSummary()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date
        cboBranch.SelectedIndex = 0
        AuditLogger.LogAction("FILTER_RESET", "DailySalesSum", "Filters reset to default")
        LoadSalesSummary()
    End Sub

    Private Sub dgvSummary_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSummary.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim selectedDate As Date = CDate(dgvSummary.Rows(e.RowIndex).Cells("Transaction_Date").Value)
        Dim selectedBranch As String = dgvSummary.Rows(e.RowIndex).Cells("Branch_Code").Value.ToString().Trim()
        Dim selectedCashierID As String = dgvSummary.Rows(e.RowIndex).Cells("Cashier_ID").Value.ToString().Trim()
        Dim selectedCashierName As String = dgvSummary.Rows(e.RowIndex).Cells("Cashier_Name").Value.ToString().Trim()

        AuditLogger.LogAction("VIEW_DETAIL", "DailySalesSum", $"Opened transactions | Date: {selectedDate:yyyy-MM-dd} | Branch: {selectedBranch} | Cashier: {selectedCashierName}")

        Dim frmTrans As New frmSalesTransactions()
        frmTrans.dtpFrom.Value = selectedDate.Date
        frmTrans.dtpTo.Value = selectedDate.Date.AddDays(1).AddSeconds(-1)

        If frmTrans.cboBranch.DataSource IsNot Nothing Then
            Dim branchView As DataView = CType(frmTrans.cboBranch.DataSource, DataTable).DefaultView
            branchView.RowFilter = $"BRANCH_ID = '{selectedBranch.Replace("'", "''")}'"
            If branchView.Count > 0 Then
                frmTrans.cboBranch.SelectedValue = selectedBranch
            Else
                frmTrans.cboBranch.SelectedIndex = 0
            End If
            branchView.RowFilter = ""
        End If

        If frmTrans.cboCashier.DataSource IsNot Nothing Then
            Dim cashierView As DataView = CType(frmTrans.cboCashier.DataSource, DataTable).DefaultView
            cashierView.RowFilter = $"Cashier_ID = '{selectedCashierID.Replace("'", "''")}'"
            If cashierView.Count > 0 Then
                frmTrans.cboCashier.SelectedValue = selectedCashierID
            Else
                frmTrans.cboCashier.SelectedIndex = 0
            End If
            cashierView.RowFilter = ""
        End If

        frmTrans.LoadTransactions()
        frmTrans.Text = $"Transactions: {selectedDate:MMM dd, yyyy} | {selectedBranch} | {selectedCashierName}"
        DashBoard.Panel2.Controls.Clear()
        frmTrans.TopLevel = False
        frmTrans.FormBorderStyle = FormBorderStyle.None
        frmTrans.Dock = DockStyle.Fill
        DashBoard.Panel2.Controls.Add(frmTrans)
        frmTrans.Show()
    End Sub

End Class