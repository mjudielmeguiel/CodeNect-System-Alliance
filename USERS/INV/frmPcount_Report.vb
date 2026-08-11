Imports MySqlConnector

Public Class frmPcount_Report
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private selectedInvNo As String = Nothing
    Private ReadOnly currentAccountId As String = DBConnection.CurrentUserAccountID
    Private ReadOnly currentBranchId As String = DBConnection.CurrentUserBranchID
    Private isAdminUser As Boolean = False

    Private Sub frmPcount_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New DateTime(2020, 1, 1)
        dtpTo.Value = DateTime.Now.Date

        lblStatus.Text = "Status: -"
        lblStatus.ForeColor = Color.Black
        lblInvNumber.Text = "INV Number: -"
        lblItemCount.Text = "Item Count: -"
        lblTotalAmount.Text = "Total Amount: -"

        ' ✅ MALINIS: LIKHIN ANG MGA COLUMNS — DIRETSAHAN
        dgvReports.Columns.Clear()
        dgvReports.AutoGenerateColumns = False

        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TRANSACTION_ID", .HeaderText = "INV Number", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "REPORT_DATE", .HeaderText = "Report Date", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "STATUS", .HeaderText = "Status", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ITEM_COUNT", .HeaderText = "Item Count", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TOTAL", .HeaderText = "Total Amount", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TRANSACTION_TYPE", .HeaderText = "Type", .ReadOnly = True})
        dgvReports.Columns.Add(New DataGridViewButtonColumn With {.Name = "colView", .Text = "View", .UseColumnTextForButtonValue = True})

        ' ✅ TIGNAN KUNG ADMIN
        CheckIfUserIsAdmin()
    End Sub

    ' ✅ PAGKABUKAS NA NG FORM — SAKA MAG-LOAD NG DATA
    Private Sub frmPcount_Report_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadReportData()
    End Sub

    Private Sub CheckIfUserIsAdmin()
        isAdminUser = False
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT user_type FROM user_accounts WHERE account_id = @accid AND branch_id = @brid LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@accid", currentAccountId)
                cmd.Parameters.AddWithValue("@brid", currentBranchId)
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim ut = dr("user_type").ToString().Trim().ToUpper()
                        isAdminUser = (ut = "ADMIN")
                    End If
                End Using
            End Using
        Catch ex As Exception
            isAdminUser = False
        End Try
    End Sub

    Private Sub LoadReportData()
        ' ✅ SIGURADUHIN MUNA NA MAY COLUMNS — KUNG WALA, HUWAG TUMULOY
        If dgvReports.Columns.Count = 0 Then Exit Sub

        dgvReports.Rows.Clear()
        Dim grandTotal As Decimal = 0

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmdText As String

            If isAdminUser Then
                cmdText = "SELECT TRANSACTION_ID, REPORT_DATE, STATUS, ITEM_COUNT, TOTAL, TRANSACTION_TYPE FROM inv_data WHERE ACCOUNT_ID = @ACCID AND REPORT_DATE BETWEEN @FROMDATE AND @TODATE ORDER BY REPORT_DATE DESC"
            Else
                cmdText = "SELECT TRANSACTION_ID, REPORT_DATE, STATUS, ITEM_COUNT, TOTAL, TRANSACTION_TYPE FROM inv_data WHERE ACCOUNT_ID = @ACCID AND BRANCH_ID = @BRNCHID AND REPORT_DATE BETWEEN @FROMDATE AND @TODATE ORDER BY REPORT_DATE DESC"
            End If

            Using cmd As New MySqlCommand(cmdText, conn)
                cmd.Parameters.AddWithValue("@ACCID", currentAccountId)
                cmd.Parameters.AddWithValue("@FROMDATE", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@TODATE", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
                If Not isAdminUser Then cmd.Parameters.AddWithValue("@BRNCHID", currentBranchId)

                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        ' ✅ LIGTAS NA PETSA
                        Dim reportDateStr As String = ""
                        If Not dr.IsDBNull(dr.GetOrdinal("REPORT_DATE")) Then
                            reportDateStr = Convert.ToDateTime(dr("REPORT_DATE")).ToString("yyyy-MM-dd")
                        End If

                        ' ✅ KABUUAN
                        Dim rowTotal As Decimal = 0
                        If Not dr.IsDBNull(dr.GetOrdinal("TOTAL")) Then
                            rowTotal = Convert.ToDecimal(dr("TOTAL"))
                            grandTotal += rowTotal
                        End If

                        ' ✅ TUGMA SA 6 DATA COLUMNS — WALANG SOBRANG HALAGA
                        dgvReports.Rows.Add(
                            dr("TRANSACTION_ID").ToString(),
                            reportDateStr,
                            dr("STATUS").ToString(),
                            Convert.ToInt32(dr("ITEM_COUNT")).ToString(),
                            rowTotal.ToString("N2"),
                            dr("TRANSACTION_TYPE").ToString()
                        )
                    End While
                End Using
            End Using
        End Using

        lblTotalAmount.Text = $"GRAND TOTAL: {grandTotal.ToString("N2")}"
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
        Select Case statusCell.Value.ToString().Trim().ToUpper()
            Case "COMPLETED" : e.CellStyle.ForeColor = Color.Green
            Case "DRAFT" : e.CellStyle.ForeColor = Color.Orange
            Case "CANCELLED" : e.CellStyle.ForeColor = Color.Red
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
            Case "COMPLETED" : lblStatus.ForeColor = Color.Green
            Case "CANCELLED" : lblStatus.ForeColor = Color.Red
            Case "DRAFT" : lblStatus.ForeColor = Color.Orange
            Case Else : lblStatus.ForeColor = Color.Black
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