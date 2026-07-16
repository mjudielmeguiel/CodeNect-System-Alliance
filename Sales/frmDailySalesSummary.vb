Imports System.Data.SqlClient

Public Class frmDailySalesSummary

    Private Sub frmDailySalesSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Default: show today's summary
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date

        ' Load branches into dropdown
        LoadBranches()

        ' Load summary data on form open
        LoadSalesSummary()
    End Sub

    Private Sub LoadBranches()
        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                ' ✅ Tamang table at columns
                Dim sql As String = "SELECT DISTINCT BRANCH_ID, BRANCH FROM dbo.Branches ORDER BY BRANCH"
                Using cmd As New SqlCommand(sql, conn)
                    Dim da As New SqlDataAdapter(cmd)
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

    ' Load summary data from Daily_Sales_Summary table
    Private Sub LoadSalesSummary()
        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                Dim sql As New Text.StringBuilder()
                sql.AppendLine("SELECT")
                sql.AppendLine("    SummaryID,")
                sql.AppendLine("    Branch_Code,")
                sql.AppendLine("    Cashier_ID,")
                sql.AppendLine("    Cashier_Name,")
                sql.AppendLine("    Transaction_Date,")
                sql.AppendLine("    Total_Transactions,")
                sql.AppendLine("    Total_Sales_Amount,")
                sql.AppendLine("    Total_Cash,")
                sql.AppendLine("    Total_Online,")
                sql.AppendLine("    Date_Added")
                sql.AppendLine("FROM dbo.Daily_Sales_Summary")
                sql.AppendLine("WHERE Transaction_Date BETWEEN @DateFrom AND @DateTo")

                ' Add branch filter if selected
                If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                    sql.AppendLine("AND Branch_Code = @BranchCode")
                End If

                sql.AppendLine("ORDER BY Transaction_Date DESC, Branch_Code, Cashier_Name")

                Using cmd As New SqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@DateFrom", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@DateTo", dtpTo.Value.Date)

                    If Not String.IsNullOrEmpty(cboBranch.SelectedValue?.ToString()) Then
                        cmd.Parameters.AddWithValue("@BranchCode", cboBranch.SelectedValue.ToString())
                    End If

                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Bind to grid
                    dgvSummary.DataSource = dt

                    ' Format columns
                    FormatSummaryGrid()

                    ' Calculate grand total
                    CalculateTotals(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading sales summary: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatSummaryGrid()
        With dgvSummary
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            .ReadOnly = True
            .AllowUserToAddRows = False

            ' Hide ID and code columns
            .Columns("SummaryID").Visible = False
            .Columns("Branch_Code").Visible = False
            .Columns("Cashier_ID").Visible = False

            ' Format number columns
            .Columns("Total_Sales_Amount").DefaultCellStyle.Format = "N2"
            .Columns("Total_Cash").DefaultCellStyle.Format = "N2"
            .Columns("Total_Online").DefaultCellStyle.Format = "N2"

            .Columns("Total_Sales_Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Cash").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Online").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Rename headers
            .Columns("Cashier_Name").HeaderText = "Cashier Name"
            .Columns("Transaction_Date").HeaderText = "Sales Date"
            .Columns("Total_Transactions").HeaderText = "No. of Transactions"
            .Columns("Total_Sales_Amount").HeaderText = "Total Sales"
            .Columns("Total_Cash").HeaderText = "Cash Sales"
            .Columns("Total_Online").HeaderText = "Online Sales"
            .Columns("Date_Added").HeaderText = "Recorded On"
        End With
    End Sub

    ' Compute totals for the displayed list
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

    ' Load button click
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadSalesSummary()
    End Sub

    ' Reset filters
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dtpFrom.Value = DateTime.Now.Date
        dtpTo.Value = DateTime.Now.Date
        cboBranch.SelectedIndex = 0
        LoadSalesSummary()
    End Sub

    ' ✅ Double-click a row to open its transactions
    Private Sub dgvSummary_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSummary.CellDoubleClick
        If e.RowIndex < 0 Then Return

        ' Get values from selected row
        Dim selectedDate As Date = CDate(dgvSummary.Rows(e.RowIndex).Cells("Transaction_Date").Value)
        Dim selectedBranch As String = dgvSummary.Rows(e.RowIndex).Cells("Branch_Code").Value.ToString().Trim()
        Dim selectedCashierID As String = dgvSummary.Rows(e.RowIndex).Cells("Cashier_ID").Value.ToString().Trim()
        Dim selectedCashierName As String = dgvSummary.Rows(e.RowIndex).Cells("Cashier_Name").Value.ToString().Trim()

        ' Create the transactions form
        Dim frmTrans As New frmSalesTransactions()

        ' Set date range
        frmTrans.dtpFrom.Value = selectedDate.Date
        frmTrans.dtpTo.Value = selectedDate.Date.AddDays(1).AddSeconds(-1)

        ' ✅ Fixed: Filter branch using correct column name BRANCH_ID
        If frmTrans.cboBranch.DataSource IsNot Nothing Then
            Dim branchView As DataView = CType(frmTrans.cboBranch.DataSource, DataTable).DefaultView
            branchView.RowFilter = $"BRANCH_ID = '{selectedBranch.Replace("'", "''")}'"
            If branchView.Count > 0 Then
                frmTrans.cboBranch.SelectedValue = selectedBranch
            Else
                frmTrans.cboBranch.SelectedIndex = 0 ' Set to All Branches if not found
            End If
            branchView.RowFilter = ""
        End If

        ' Filter cashier
        If frmTrans.cboCashier.DataSource IsNot Nothing Then
            Dim cashierView As DataView = CType(frmTrans.cboCashier.DataSource, DataTable).DefaultView
            cashierView.RowFilter = $"Cashier_ID = '{selectedCashierID.Replace("'", "''")}'"
            If cashierView.Count > 0 Then
                frmTrans.cboCashier.SelectedValue = selectedCashierID
            Else
                frmTrans.cboCashier.SelectedIndex = 0 ' Set to All Cashiers if not found
            End If
            cashierView.RowFilter = ""
        End If

        ' Load filtered transactions
        frmTrans.LoadTransactions()

        ' Set form title
        frmTrans.Text = $"Transactions: {selectedDate:MMM dd, yyyy} | {selectedBranch} | {selectedCashierName}"

        ' ✅ Fixed: Embed frmTrans inside Dashboard Panel2 correctly
        DashBoard.Panel2.Controls.Clear()
        frmTrans.TopLevel = False
        frmTrans.FormBorderStyle = FormBorderStyle.None
        frmTrans.Dock = DockStyle.Fill
        DashBoard.Panel2.Controls.Add(frmTrans)
        frmTrans.Show()
    End Sub

End Class