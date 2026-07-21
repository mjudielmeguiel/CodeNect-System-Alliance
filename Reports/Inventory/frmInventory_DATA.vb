Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class frmInventory_DATA

    Private ReadOnly connStr As String = DBConnection.connStr
    Private currentAccountID As String = Login.LoggedInAccountID
    Private currentBranchID As String = Login.LoggedInBranchID

    Private Sub frmInventoryReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range to today
        dtpStart.Value = DateTime.Today
        dtpEnd.Value = DateTime.Today

        ' Load data automatically when form opens
        LoadReportData()
    End Sub

    Private Sub LoadReportData()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Base query: only records for current Account and Branch
                Dim sql As String = "SELECT * FROM dbo.INVENTORY_DATA " &
                                "WHERE ACCOUNT_ID = @AccountID AND BRANCH_ID = @BranchID " &
                                "AND REPORT_DATE BETWEEN @StartDate AND DATEADD(DAY, 1, @EndDate) "

                ' Add search filter if there is text
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    sql &= "AND (TRANSACTION_ID LIKE @Search OR BRANCH LIKE @Search OR PREPARED_BY LIKE @Search) "
                End If

                sql &= "ORDER BY REPORT_DATE DESC"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountID", currentAccountID)
                    cmd.Parameters.AddWithValue("@BranchID", currentBranchID)
                    cmd.Parameters.AddWithValue("@StartDate", dtpStart.Value.Date)
                    cmd.Parameters.AddWithValue("@EndDate", dtpEnd.Value.Date)

                    If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                        cmd.Parameters.AddWithValue("@Search", "%" & txtSearch.Text.Trim() & "%")
                    End If

                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Bind to DataGridView
                    dgvReport.DataSource = dt

                    ' Optional: Format columns for readability
                    FormatGrid()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvReport.Columns.Count = 0 Then Return

        ' Hide technical columns if not needed
        If dgvReport.Columns.Contains("ID") Then dgvReport.Columns("ID").Visible = False

        ' Set column headers
        dgvReport.Columns("TRANSACTION_ID").HeaderText = "Transaction ID"
        dgvReport.Columns("ACCOUNT_ID").HeaderText = "Account ID"
        dgvReport.Columns("ACCOUNT").HeaderText = "Account"
        dgvReport.Columns("BRANCH_ID").HeaderText = "Branch ID"
        dgvReport.Columns("BRANCH").HeaderText = "Branch Name"
        dgvReport.Columns("REPORT_DATE").HeaderText = "Date & Time"
        dgvReport.Columns("PREPARED_BY").HeaderText = "Prepared By"
        dgvReport.Columns("TRANSACTION_TYPE").HeaderText = "Type"
        dgvReport.Columns("STATUS").HeaderText = "Status"
        dgvReport.Columns("TOTAL").HeaderText = "Total Amount"

        ' Format date and number
        dgvReport.Columns("REPORT_DATE").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
        dgvReport.Columns("TOTAL").DefaultCellStyle.Format = "N2"
        dgvReport.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadReportData()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Clear()
        dtpStart.Value = DateTime.Today
        dtpEnd.Value = DateTime.Today
        LoadReportData()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx"
                sfd.FileName = $"Inventory_Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Using wb As New XLWorkbook()
                        Dim ws = wb.Worksheets.Add("Inventory Report")

                        ' Export grid headers and data
                        For col As Integer = 0 To dgvReport.Columns.Count - 1
                            ws.Cell(1, col + 1).Value = dgvReport.Columns(col).HeaderText
                        Next

                        For row As Integer = 0 To dgvReport.Rows.Count - 1
                            For col As Integer = 0 To dgvReport.Columns.Count - 1
                                ws.Cell(row + 2, col + 1).Value = dgvReport.Rows(row).Cells(col).Value?.ToString()
                            Next
                        Next

                        ws.Columns().AdjustToContents()
                        wb.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Optional: Auto load when search is pressed Enter
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadReportData()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub dgvReport_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvReport.Rows(e.RowIndex)
            Dim transID As String = selectedRow.Cells("TRANSACTION_ID").Value.ToString().Trim()

            If String.IsNullOrEmpty(transID) Then
                MessageBox.Show("No Transaction ID found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            DashBoard.Panel2.Controls.Clear()

            Dim frmDetails As New frmInventory_Information(transID)
            frmDetails.TopLevel = False
            frmDetails.FormBorderStyle = FormBorderStyle.None
            frmDetails.Dock = DockStyle.Fill
            frmDetails.Visible = True

            DashBoard.Panel2.Controls.Add(frmDetails)
            frmDetails.Show()
        End If
    End Sub

End Class