Imports System.Data
Imports System.Data.SqlClient

Public Class Branch_Performance

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranchesWithSales()
    End Sub

    Private Sub LoadBranchesWithSales()
        Try
            Dim query As String = "
                SELECT
                    BRANCH_ID,
                    BRANCH AS Branch_Name,
                    ADDRESS,
                    TIN,
                    MANAGER,
                    ISNULL(b.SALES, 0.00) AS Gross_Sales,
                    -- Get breakdown from transactions
                    ISNULL(st.Total_Transactions, 0) AS Total_Transactions,
                    ISNULL(st.Total_Cash, 0.00) AS Cash_Sales,
                    ISNULL(st.Total_Online, 0.00) AS Online_Sales,
                    ISNULL(st.Total_Discount, 0.00) AS Total_Discount,
                    ISNULL(st.Total_VAT, 0.00) AS Total_VAT,
                    STATUS
                FROM dbo.Branches b
                LEFT JOIN (
                    SELECT
                        RTRIM(LTRIM(Branch_Code)) AS Branch_Code,
                        COUNT(*) AS Total_Transactions,
                        SUM(Cash_Amount) AS Total_Cash,
                        SUM(Online_Amount) AS Total_Online,
                        SUM(Discount_Amount) AS Total_Discount,
                        SUM(VAT_Amount) AS Total_VAT
                    FROM dbo.Sales_Transactions
                    GROUP BY RTRIM(LTRIM(Branch_Code))
                ) st ON RTRIM(LTRIM(b.BRANCH_ID)) = st.Branch_Code
                ORDER BY b.BRANCH_ID
            "

            Using conn As New SqlConnection(DBConnection.connStr)
                Using cmd As New SqlCommand(query, conn)
                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvBranchList.DataSource = dt

                    With dgvBranchList
                        .Columns("BRANCH_ID").HeaderText = "Branch ID"
                        .Columns("Branch_Name").HeaderText = "Branch Name"
                        .Columns("ADDRESS").HeaderText = "Address"
                        .Columns("TIN").HeaderText = "TIN"
                        .Columns("MANAGER").HeaderText = "Manager"
                        .Columns("Total_Transactions").HeaderText = "No. of Transactions"
                        .Columns("Gross_Sales").HeaderText = "Total Sales"
                        .Columns("Cash_Sales").HeaderText = "Cash Sales"
                        .Columns("Online_Sales").HeaderText = "Online Sales"
                        .Columns("Total_Discount").HeaderText = "Total Discount"
                        .Columns("Total_VAT").HeaderText = "Total VAT"
                        .Columns("STATUS").HeaderText = "Status"

                        ' Format as currency
                        .Columns("Gross_Sales").DefaultCellStyle.Format = "#,##0.00"
                        .Columns("Cash_Sales").DefaultCellStyle.Format = "#,##0.00"
                        .Columns("Online_Sales").DefaultCellStyle.Format = "#,##0.00"
                        .Columns("Total_Discount").DefaultCellStyle.Format = "#,##0.00"
                        .Columns("Total_VAT").DefaultCellStyle.Format = "#,##0.00"
                    End With
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBranchesWithSales()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel Files|*.xlsx"
            saveDialog.Title = "Export Branch Performance"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
                Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
                Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(workbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim headers() As String = {
                    "Branch ID", "Branch Name", "Address", "TIN", "Manager",
                    "No. of Transactions", "Total Sales", "Cash Sales", "Online Sales",
                    "Total Discount", "Total VAT", "Status"
                }

                For c As Integer = 0 To headers.Length - 1
                    worksheet.Cells(1, c + 1) = headers(c)
                Next

                worksheet.Rows(1).Font.Bold = True
                worksheet.Rows(1).Interior.Color = Drawing.Color.LightSteelBlue

                For r As Integer = 0 To dgvBranchList.Rows.Count - 1
                    For c As Integer = 0 To headers.Length - 1
                        worksheet.Cells(r + 2, c + 1) = dgvBranchList.Rows(r).Cells(c).Value
                    Next
                Next

                worksheet.Columns.AutoFit()
                workbook.SaveAs(saveDialog.FileName)
                workbook.Close()
                excelApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Export Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class