Imports System.Data.SqlClient

Public Class Branch_Performance

    ' Connection String
    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=sa;Password=Password1*;Connect Timeout=15"

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default dates (Today as end, 1 month ago as start)
        dtpStart.Value = DateTime.Now.AddMonths(-1)
        dtpEnd.Value = DateTime.Now

        ' Load data automatically when form opens
        LoadBranchSales()
    End Sub

    ' ==============================================
    ' LOAD BRANCH SALES BY DATE RANGE
    ' ==============================================
    Private Sub LoadBranchSales()
        Try
            Dim startDate As String = dtpStart.Value.ToString("yyyy-MM-dd")
            Dim endDate As String = dtpEnd.Value.ToString("yyyy-MM-dd")

            ' ✅ QUERY: ALL BRANCHES + SALES BY DATE + RANK + 0 IF NO SALES
            Dim query As String = "SELECT " &
                                  "ROW_NUMBER() OVER (ORDER BY ISNULL([SALES], 0) DESC) AS RANK, " &
                                  "BRANCH_ID, " &
                                  "BRANCH, " &
                                  "ISNULL([SALES], 0) AS TOTAL_SALES " &
                                  "FROM dbo.Branches " &
                                  "ORDER BY TOTAL_SALES DESC"

            Using conn As New SqlConnection(ConnString)
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    ' Show data
                    dgvBranchList.DataSource = dt

                    ' Set Column Names
                    dgvBranchList.Columns("RANK").HeaderText = "Rank"
                    dgvBranchList.Columns("BRANCH_ID").HeaderText = "Branch ID"
                    dgvBranchList.Columns("BRANCH").HeaderText = "Branch Name"
                    dgvBranchList.Columns("TOTAL_SALES").HeaderText = "Total Sales"

                    ' Format as Currency (0.00 if no sales)
                    dgvBranchList.Columns("TOTAL_SALES").DefaultCellStyle.Format = "#,##0.00"
                    dgvBranchList.Columns("RANK").ReadOnly = True
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================================
    ' WHEN DATE IS CHANGED -> REFRESH DATA
    ' ==============================================
    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadBranchSales()
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        LoadBranchSales()
    End Sub

    ' ==============================================
    ' REFRESH DATA
    ' ==============================================
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBranchSales()
        MessageBox.Show("Data Refreshed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ==============================================
    ' EXPORT TO EXCEL
    ' ==============================================
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel File (*.xlsx)|*.xlsx"
            saveDialog.Title = "Export Branch Sales"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
                Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
                Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = workbook.Sheets(1)

                ' Headers
                worksheet.Cells(1, 1) = "Rank"
                worksheet.Cells(1, 2) = "Branch ID"
                worksheet.Cells(1, 3) = "Branch Name"
                worksheet.Cells(1, 4) = "Total Sales"
                worksheet.Range("A1:D1").Font.Bold = True

                ' Data
                For i As Integer = 0 To dgvBranchList.Rows.Count - 1
                    worksheet.Cells(i + 2, 1) = dgvBranchList.Rows(i).Cells("RANK").Value.ToString()
                    worksheet.Cells(i + 2, 2) = dgvBranchList.Rows(i).Cells("BRANCH_ID").Value.ToString()
                    worksheet.Cells(i + 2, 3) = dgvBranchList.Rows(i).Cells("BRANCH").Value.ToString()
                    worksheet.Cells(i + 2, 4) = dgvBranchList.Rows(i).Cells("TOTAL_SALES").Value.ToString()
                Next

                workbook.SaveAs(saveDialog.FileName)
                workbook.Close()
                excelApp.Quit()

                MessageBox.Show("Successfully exported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class