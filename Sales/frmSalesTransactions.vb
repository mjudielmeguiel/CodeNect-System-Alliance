Imports System.Data
Imports MySqlConnector

Public Class frmSalesTransactions

    Private connStr As String = DBConnection.connStr

    Private Sub frmSalesTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range: Today
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1)

        ' Load branches and cashiers into dropdowns
        LoadBranches()
        LoadCashiers()

        ' Load all transactions by default
        LoadTransactions()
    End Sub

    Private Sub LoadBranches()
        Try
            Using conn As New MySqlConnection(connStr)
                ' ✅ dbo. removed, backticks added
                Dim sql As String = "SELECT DISTINCT `BRANCH_ID`, `BRANCH` FROM `Branches` ORDER BY `BRANCH`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Add "All Branches" option
                    dt.Rows.InsertAt(dt.NewRow(), 0)
                    dt.Rows(0)("BRANCH_ID") = ""
                    dt.Rows(0)("BRANCH") = "-- All Branches --"

                    cboBranch.DisplayMember = "BRANCH"
                    cboBranch.ValueMember = "BRANCH_ID"
                    cboBranch.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Load list of cashiers
    Private Sub LoadCashiers()
        Try
            Using conn As New MySqlConnection(connStr)
                ' ✅ dbo. removed, backticks added
                Dim sql As String = "SELECT DISTINCT `Cashier_ID`, `Cashier_Name` FROM `Sales_Transactions` ORDER BY `Cashier_Name`"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Add "All Cashiers" option
                    dt.Rows.InsertAt(dt.NewRow(), 0)
                    dt.Rows(0)("Cashier_ID") = ""
                    dt.Rows(0)("Cashier_Name") = "-- All Cashiers --"

                    cboCashier.DisplayMember = "Cashier_Name"
                    cboCashier.ValueMember = "Cashier_ID"
                    cboCashier.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading cashiers: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' ✅ Public para matawagan mula sa ibang forms
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

                ' Add filters if selected
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

                    ' Bind to grid
                    dgvTransactions.DataSource = dt

                    ' Format columns for readability
                    FormatGrid()

                    ' Calculate total sales
                    CalculateTotalSales(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        With dgvTransactions
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False

            ' Hide Branch and Cashier ID columns
            .Columns("Branch_Code").Visible = False
            .Columns("Cashier_ID").Visible = False

            ' Format number columns
            For Each col As DataGridViewColumn In .Columns
                If col.Name.EndsWith("_Amount") OrElse col.Name = "Amount_Due" OrElse col.Name = "Amount_Paid" Then
                    col.DefaultCellStyle.Format = "N2"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

            ' Rename headers for better display
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

    ' Compute total sales for the filtered list
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

    ' Button: Load / Refresh
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadTransactions()
    End Sub

    ' Button: Reset filters
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1)
        cboBranch.SelectedIndex = 0
        cboCashier.SelectedIndex = 0
        LoadTransactions()
    End Sub

End Class