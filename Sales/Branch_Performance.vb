Imports System.Data
Imports System.Data.SqlClient

Public Class Branch_Performance

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default dates: last 1 month up to today
        dtpStart.Value = DateTime.Now.AddMonths(-1)
        dtpEnd.Value = DateTime.Now
        LoadBranchSales()
    End Sub

    ' ==============================================
    ' LOAD BRANCH SALES BY DATE RANGE
    ' ==============================================
    Private Sub LoadBranchSales()
        Try
            Dim startDate As String = dtpStart.Value.ToString("yyyy-MM-dd")
            Dim endDate As String = dtpEnd.Value.ToString("yyyy-MM-dd")

            ' Query: Get all branches, total sales within date range, rank results
            Dim query As String = "
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY ISNULL(S.TOTAL_SALES, 0) DESC) AS [RANK],
                    B.BRANCH_ID,
                    B.BRANCH,
                    ISNULL(S.TOTAL_SALES, 0) AS TOTAL_SALES
                FROM dbo.Branches B
                LEFT JOIN (
                    SELECT BRANCH_ID, SUM(AMOUNT) AS TOTAL_SALES
                    FROM dbo.Sales
                    WHERE TRANS_DATE BETWEEN @StartDate AND DATEADD(DAY, 1, @EndDate)
                    GROUP BY BRANCH_ID
                ) S ON B.BRANCH_ID = S.BRANCH_ID
                ORDER BY TOTAL_SALES DESC
            "

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpStart.Value
                    cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEnd.Value

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvBranchList.DataSource = dt

                    ' Set column headers
                    dgvBranchList.Columns("RANK").HeaderText = "Rank"
                    dgvBranchList.Columns("BRANCH_ID").HeaderText = "Branch ID"
                    dgvBranchList.Columns("BRANCH").HeaderText = "Branch Name"
                    dgvBranchList.Columns("TOTAL_SALES").HeaderText = "Total Sales"

                    ' Format sales as currency
                    dgvBranchList.Columns("TOTAL_SALES").DefaultCellStyle.Format = "#,##0.00"
                    dgvBranchList.Columns("RANK").ReadOnly = True
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================================
    ' Refresh when date changes
    ' ==============================================
    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadBranchSales()
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        LoadBranchSales()
    End Sub

    ' ==============================================
    ' Refresh button
    ' ==============================================
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBranchSales()
        MessageBox.Show("Data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ==============================================
    ' Export to Excel
    ' ==============================================
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            saveDialog.Title = "Export Branch Performance Report"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
                Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
                Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(workbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                ' Header row
                worksheet.Cells(1, 1) = "Rank"
                worksheet.Cells(1, 2) = "Branch ID"
                worksheet.Cells(1, 3) = "Branch Name"
                worksheet.Cells(1, 4) = "Total Sales"
                worksheet.Range("A1:D1").Font.Bold = True
                worksheet.Range("A1:D1").Interior.Color = System.Drawing.Color.LightGray

                ' Data rows
                For rowIndex As Integer = 0 To dgvBranchList.Rows.Count - 1
                    With dgvBranchList.Rows(rowIndex)
                        worksheet.Cells(rowIndex + 2, 1) = .Cells("RANK").Value.ToString()
                        worksheet.Cells(rowIndex + 2, 2) = .Cells("BRANCH_ID").Value.ToString()
                        worksheet.Cells(rowIndex + 2, 3) = .Cells("BRANCH").Value.ToString()
                        worksheet.Cells(rowIndex + 2, 4) = CDec(.Cells("TOTAL_SALES").Value)
                    End With
                Next

                ' Auto-fit columns
                worksheet.Columns.AutoFit()

                ' Save and close
                workbook.SaveAs(saveDialog.FileName)
                workbook.Close()
                excelApp.Quit()

                MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class