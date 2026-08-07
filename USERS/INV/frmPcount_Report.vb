Imports MySqlConnector

Public Class frmPcount_Report
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private selectedInvNo As String = Nothing
    Private ReadOnly currentAccountId As String = DBConnection.CurrentUserAccountID
    Private ReadOnly currentBranchId As String = DBConnection.CurrentUserBranchID

    Private Sub frmPcount_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New DateTime(2020, 1, 1)
        dtpTo.Value = DateTime.Now.Date

        lblStatus.Text = "Status: -"
        lblStatus.ForeColor = Color.Black
        lblInvNumber.Text = "INV Number: -"
        lblItemCount.Text = "Item Count: -"
        lblTotalAmount.Text = "Total Amount: -"

        dgvReports.ReadOnly = False
        dgvReports.AutoGenerateColumns = False
        dgvReports.Columns.Clear()

        dgvReports.Columns.Add("TRANSACTION_ID", "INV Number")
        dgvReports.Columns.Add("REPORT_DATE", "Report Date")
        dgvReports.Columns.Add("STATUS", "Status")
        dgvReports.Columns.Add("ITEM_COUNT", "Item Count")
        dgvReports.Columns.Add("TOTAL", "Total Amount")
        dgvReports.Columns.Add("TRANSACTION_TYPE", "Type")

        For Each col As DataGridViewColumn In dgvReports.Columns
            col.ReadOnly = True
        Next

        Dim btnView As New DataGridViewButtonColumn()
        btnView.Name = "colView"
        btnView.Text = "View"
        btnView.UseColumnTextForButtonValue = True
        dgvReports.Columns.Add(btnView)

        LoadReportData()
    End Sub

    Private Sub LoadReportData()
        dgvReports.Rows.Clear()

        Using conn As New MySqlConnection(connStr)
            conn.Open()

            Dim cmd As New MySqlCommand("
                SELECT TRANSACTION_ID, REPORT_DATE, STATUS, ITEM_COUNT, TOTAL, TRANSACTION_TYPE
                FROM inv_data
                WHERE ACCOUNT_ID = @ACCID 
                  AND BRANCH_ID = @BRNCHID
                  AND REPORT_DATE BETWEEN @FROMDATE AND @TODATE
                ORDER BY REPORT_DATE DESC", conn)

            cmd.Parameters.AddWithValue("@ACCID", currentAccountId)
            cmd.Parameters.AddWithValue("@BRNCHID", currentBranchId)
            cmd.Parameters.AddWithValue("@FROMDATE", dtpFrom.Value.Date)
            cmd.Parameters.AddWithValue("@TODATE", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    dgvReports.Rows.Add(
                        dr("TRANSACTION_ID").ToString(),
                        If(dr.IsDBNull("REPORT_DATE"), "", Convert.ToDateTime(dr("REPORT_DATE")).ToString("yyyy-MM-dd")),
                        dr("STATUS").ToString(),
                        Convert.ToInt32(dr("ITEM_COUNT")).ToString(),
                        Convert.ToDecimal(dr("TOTAL")).ToString("N2"),
                        dr("TRANSACTION_TYPE").ToString()
                    )
                End While
            End Using
        End Using
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadReportData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadReportData()
    End Sub

    Private Sub dgvReports_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReports.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim statusCell = dgvReports.Rows(e.RowIndex).Cells("STATUS")
        If statusCell.Value Is Nothing Then Return

        Dim status = statusCell.Value.ToString().Trim().ToUpper()

        Select Case status
            Case "COMPLETED"
                e.CellStyle.ForeColor = Color.Green
            Case "DRAFT"
                e.CellStyle.ForeColor = Color.Orange
            Case "CANCELLED"
                e.CellStyle.ForeColor = Color.Red
        End Select
    End Sub

    Private Sub dgvReports_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReports.CellClick
        If e.RowIndex < 0 OrElse TypeOf dgvReports.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then Exit Sub

        selectedInvNo = dgvReports.Rows(e.RowIndex).Cells("TRANSACTION_ID").Value?.ToString()
        Dim currentStatus = dgvReports.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()
        Dim itemCount = dgvReports.Rows(e.RowIndex).Cells("ITEM_COUNT").Value?.ToString()
        Dim totalAmt = dgvReports.Rows(e.RowIndex).Cells("TOTAL").Value?.ToString()

        lblInvNumber.Text = $"INV Number: {selectedInvNo}"
        lblStatus.Text = $"Status: {currentStatus}"
        lblItemCount.Text = $"Item Count: {itemCount}"
        lblTotalAmount.Text = $"Total Amount: {totalAmt}"

        Select Case currentStatus.ToUpper()
            Case "COMPLETED"
                lblStatus.ForeColor = Color.Green
            Case "CANCELLED"
                lblStatus.ForeColor = Color.Red
            Case "DRAFT"
                lblStatus.ForeColor = Color.Orange
            Case Else
                lblStatus.ForeColor = Color.Black
        End Select
    End Sub

    Private Sub dgvReports_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReports.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Dim invNo = dgvReports.Rows(e.RowIndex).Cells("TRANSACTION_ID").Value?.ToString()

        If e.ColumnIndex = dgvReports.Columns("colView").Index Then
            MessageBox.Show($"Viewing Inventory: {invNo}", "View", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class