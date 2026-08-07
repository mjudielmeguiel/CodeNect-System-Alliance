Imports System.Data
Imports MySqlConnector

Public Class frmSalesTransactions

    Private connStr As String = DBConnection.connStr

    Private Sub frmSalesTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
        LoadBranches()
        LoadCashiers()
        LoadTransactions()
        AuditLogger.LogAction("OPEN_TRANS", "SalesTrans", "Opened Sales Transactions View")
    End Sub

    Private Sub LoadBranches()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "SELECT DISTINCT `branch_id`, `branch` FROM `branches` ORDER BY `branch`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Dim drAll = dt.NewRow()
                    drAll("branch_id") = DBNull.Value
                    drAll("branch") = "-- All Branches --"
                    dt.Rows.InsertAt(drAll, 0)
                    cboBranch.DisplayMember = "branch"
                    cboBranch.ValueMember = "branch_id"
                    cboBranch.DataSource = dt
                End Using
            End Using
            AuditLogger.LogAction("BRANCH_LOADED", "SalesTrans", "Branch filter list loaded")
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "SalesTrans", $"Load branches failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadCashiers()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "SELECT DISTINCT `user_id`, `user_name` FROM `sales_transactions` ORDER BY `user_name`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Dim drAll = dt.NewRow()
                    drAll("user_id") = DBNull.Value
                    drAll("user_name") = "-- All Cashiers --"
                    dt.Rows.InsertAt(drAll, 0)
                    cboCashier.DisplayMember = "user_name"
                    cboCashier.ValueMember = "user_id"
                    cboCashier.DataSource = dt
                End Using
            End Using
            AuditLogger.LogAction("CASHIER_LOADED", "SalesTrans", "Cashier filter list loaded")
        Catch ex As Exception
            MessageBox.Show("Error loading cashiers: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "SalesTrans", $"Load cashiers failed | Error: {ex.Message}")
        End Try
    End Sub

    Public Sub LoadTransactions()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As New Text.StringBuilder()
                sql.AppendLine("SELECT")
                sql.AppendLine("    `id`,")
                sql.AppendLine("    `transaction_id`,")
                sql.AppendLine("    `branch_id`,")
                sql.AppendLine("    `user_id`,")
                sql.AppendLine("    `user_name`,")
                sql.AppendLine("    `transaction_date`,")
                sql.AppendLine("    `transaction_time`,")
                sql.AppendLine("    `item_count`,")
                sql.AppendLine("    `subtotal_amount`,")
                sql.AppendLine("    `vatable_amount`,")
                sql.AppendLine("    `vat_amount`,")
                sql.AppendLine("    `discount_type`,")
                sql.AppendLine("    `discount_percent`,")
                sql.AppendLine("    `discount_amount`,")
                sql.AppendLine("    `amount_due`,")
                sql.AppendLine("    `amount_paid`,")
                sql.AppendLine("    `cash_amount`,")
                sql.AppendLine("    `online_amount`,")
                sql.AppendLine("    `change_amount`,")
                sql.AppendLine("    `payment_method`,")
                sql.AppendLine("    `status`,")
                sql.AppendLine("    `remarks`")
                sql.AppendLine("FROM `sales_transactions`")
                sql.AppendLine("WHERE `transaction_date` BETWEEN @DateFrom AND @DateTo")

                If cboBranch.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cboBranch.SelectedValue) Then
                    Dim br = cboBranch.SelectedValue.ToString().Trim()
                    If Not String.IsNullOrEmpty(br) Then sql.AppendLine("AND `branch_id` = @BranchId")
                End If
                If cboCashier.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cboCashier.SelectedValue) Then
                    Dim ca = cboCashier.SelectedValue.ToString().Trim()
                    If Not String.IsNullOrEmpty(ca) Then sql.AppendLine("AND `user_id` = @UserId")
                End If

                sql.AppendLine("ORDER BY `transaction_date` DESC, `transaction_time` DESC")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@DateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@DateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                    If cboBranch.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cboBranch.SelectedValue) Then
                        Dim br = cboBranch.SelectedValue.ToString().Trim()
                        If Not String.IsNullOrEmpty(br) Then cmd.Parameters.AddWithValue("@BranchId", br)
                    End If
                    If cboCashier.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cboCashier.SelectedValue) Then
                        Dim ca = cboCashier.SelectedValue.ToString().Trim()
                        If Not String.IsNullOrEmpty(ca) Then cmd.Parameters.AddWithValue("@UserId", ca)
                    End If

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvTransactions.DataSource = dt
                    FormatGrid()
                    CalculateTotalSales(dt)
                    AuditLogger.LogAction("TRANS_LOADED", "SalesTrans", $"Loaded {dt.Rows.Count} records")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "SalesTrans", ex.Message)
        End Try
    End Sub

    Private Sub FormatGrid()
        With dgvTransactions
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False

            If .Columns.Contains("id") Then .Columns("id").Visible = False
            If .Columns.Contains("branch_id") Then .Columns("branch_id").Visible = False
            If .Columns.Contains("user_id") Then .Columns("user_id").Visible = False

            For Each colName In {"subtotal_amount", "vatable_amount", "vat_amount", "discount_amount",
                                 "amount_due", "amount_paid", "cash_amount", "online_amount", "change_amount"}
                If .Columns.Contains(colName) Then
                    .Columns(colName).DefaultCellStyle.Format = "N2"
                    .Columns(colName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

            If .Columns.Contains("transaction_id") Then .Columns("transaction_id").HeaderText = "OR / Trans No."
            If .Columns.Contains("user_name") Then .Columns("user_name").HeaderText = "Cashier"
            If .Columns.Contains("transaction_date") Then .Columns("transaction_date").HeaderText = "Date"
            If .Columns.Contains("transaction_time") Then .Columns("transaction_time").HeaderText = "Time"
            If .Columns.Contains("item_count") Then .Columns("item_count").HeaderText = "Items"
            If .Columns.Contains("discount_percent") Then .Columns("discount_percent").HeaderText = "Discount %"
            If .Columns.Contains("payment_method") Then .Columns("payment_method").HeaderText = "Payment Method"
        End With
    End Sub

    Private Sub CalculateTotalSales(dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            lblTotalSales.Text = "Total Sales: ₱0.00"
            Return
        End If
        Dim total As Decimal = 0
        Dim totalCash As Decimal = 0
        Dim totalOnline As Decimal = 0
        For Each row As DataRow In dt.Rows
            total += Convert.ToDecimal(row("amount_due"))
            totalCash += Convert.ToDecimal(row("cash_amount"))
            totalOnline += Convert.ToDecimal(row("online_amount"))
        Next
        lblTotalSales.Text = $"Total Sales: ₱{total:N2} | Cash: ₱{totalCash:N2} | Online: ₱{totalOnline:N2}"
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadTransactions()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
        If cboBranch.Items.Count > 0 Then cboBranch.SelectedIndex = 0
        If cboCashier.Items.Count > 0 Then cboCashier.SelectedIndex = 0
        LoadTransactions()
    End Sub

End Class