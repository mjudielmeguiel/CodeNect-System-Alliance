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
            AuditLogger.LogAction("BRANCH_LOADED", "SalesTrans", "Branch filter list loaded")
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "SalesTrans", $"Load branches failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadCashiers()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "SELECT DISTINCT `Cashier_ID`, `Cashier_Name` FROM `Sales_Transactions` ORDER BY `Cashier_Name`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dt.Rows.InsertAt(dt.NewRow(), 0)
                    dt.Rows(0)("Cashier_ID") = ""
                    dt.Rows(0)("Cashier_Name") = "-- All Cashiers --"
                    cboCashier.DisplayMember = "Cashier_Name"
                    cboCashier.ValueMember = "Cashier_ID"
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
                sql.AppendLine("    `Transaction_ID`,")
                sql.AppendLine("    `Branch_Code`,")
                sql.AppendLine("    `Cashier_ID`,")
                sql.AppendLine("    `Cashier_Name`,")
                sql.AppendLine("    `Transaction_Date`,")
                sql.AppendLine("    `Transaction_Time`,")
                sql.AppendLine("    `Item_Count`,")
                sql.AppendLine("    `Subtotal_Amount`,")
                sql.AppendLine("    `VATable_Amount`,")
                sql.AppendLine("    `VAT_Amount`,")
                sql.AppendLine("    `Discount_Type`,")
                sql.AppendLine("    `Discount_Percent`,")
                sql.AppendLine("    `Discount_Amount`,")
                sql.AppendLine("    `Amount_Due`,")
                sql.AppendLine("    `Amount_Paid`,")
                sql.AppendLine("    `Cash_Amount`,")
                sql.AppendLine("    `Online_Amount`,")
                sql.AppendLine("    `Change_Amount`,")
                sql.AppendLine("    `Payment_Method`,")
                sql.AppendLine("    `Status`")
                sql.AppendLine("FROM `Sales_Transactions`")
                sql.AppendLine("WHERE `Transaction_Date` BETWEEN @DateFrom AND @DateTo")
                If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                    sql.AppendLine("AND `Branch_Code` = @BranchCode")
                End If
                If Not String.IsNullOrEmpty(cboCashier.SelectedValue?.ToString()) Then
                    sql.AppendLine("AND `Cashier_ID` = @CashierID")
                End If
                sql.AppendLine("ORDER BY `Transaction_Date` DESC, `Transaction_Time` DESC")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@DateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@DateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
                    If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                        cmd.Parameters.AddWithValue("@BranchCode", cboBranch.SelectedValue.ToString())
                    End If
                    If Not String.IsNullOrEmpty(cboCashier.SelectedValue?.ToString()) Then
                        cmd.Parameters.AddWithValue("@CashierID", cboCashier.SelectedValue.ToString())
                    End If

                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvTransactions.DataSource = dt
                    FormatGrid()
                    CalculateTotalSales(dt)
                    AuditLogger.LogAction("TRANS_LOADED", "SalesTrans", $"Loaded {dt.Rows.Count} transactions | From: {dtpFrom.Value:yyyy-MM-dd} To: {dtpTo.Value:yyyy-MM-dd}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "SalesTrans", $"Load transactions failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatGrid()
        With dgvTransactions
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .Columns("Branch_Code").Visible = False
            .Columns("Cashier_ID").Visible = False
            For Each col As DataGridViewColumn In .Columns
                If col.Name.EndsWith("_Amount") OrElse col.Name = "Amount_Due" OrElse col.Name = "Amount_Paid" Then
                    col.DefaultCellStyle.Format = "N2"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
            .Columns("Transaction_ID").HeaderText = "OR / Trans No."
            .Columns("Cashier_Name").HeaderText = "Cashier"
            .Columns("Transaction_Date").HeaderText = "Date"
            .Columns("Transaction_Time").HeaderText = "Time"
            .Columns("Item_Count").HeaderText = "Items"
            .Columns("Subtotal_Amount").HeaderText = "Subtotal"
            .Columns("VATable_Amount").HeaderText = "VATable"
            .Columns("VAT_Amount").HeaderText = "VAT"
            .Columns("Discount_Type").HeaderText = "Discount Type"
            .Columns("Discount_Percent").HeaderText = "Discount %"
            .Columns("Discount_Amount").HeaderText = "Discount Amount"
            .Columns("Amount_Due").HeaderText = "Total Due"
            .Columns("Amount_Paid").HeaderText = "Amount Paid"
            .Columns("Cash_Amount").HeaderText = "Cash"
            .Columns("Online_Amount").HeaderText = "Online"
            .Columns("Change_Amount").HeaderText = "Change"
            .Columns("Payment_Method").HeaderText = "Payment Method"
            .Columns("Status").HeaderText = "Status"
        End With
    End Sub

    Private Sub CalculateTotalSales(dt As DataTable)
        If dt.Rows.Count = 0 Then
            lblTotalSales.Text = "Total Sales: ₱0.00"
            Return
        End If
        Dim total As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Amount_Due"))
        Dim totalCash As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Cash_Amount"))
        Dim totalOnline As Decimal = dt.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Online_Amount"))
        lblTotalSales.Text = $"Total Sales: ₱{total:N2} | Cash: ₱{totalCash:N2} | Online: ₱{totalOnline:N2}"
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        AuditLogger.LogAction("REFRESH_TRANS", "SalesTrans", "User refreshed transaction list")
        LoadTransactions()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
        cboBranch.SelectedIndex = 0
        cboCashier.SelectedIndex = 0
        AuditLogger.LogAction("RESET_FILTER", "SalesTrans", "Filters reset to default")
        LoadTransactions()
    End Sub

End Class