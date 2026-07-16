Imports System.Data
Imports System.Data.SqlClient

Public Class Branch_Performance

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranchesOnly()
    End Sub

    Private Sub LoadBranchesOnly()
        Try
            ' Simpleng listahan ng lahat ng branches
            Dim query As String = "
                SELECT 
                    ACCOUNT_ID,
                    ACCOUNT,
                    BRANCH_ID,
                    BRANCH,
                    TIN,
                    BUSINESS_TYPE,
                    ADDRESS,
                    EMAIL,
                    CONTACT,
                    MANAGER,
                    SALES,
                    STATUS
                FROM dbo.Branches
                ORDER BY BRANCH_ID
            "

            Using conn As New SqlConnection(DBConnection.connStr)
                Using cmd As New SqlCommand(query, conn)

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvBranchList.DataSource = dt

                    With dgvBranchList
                        .Columns("ACCOUNT_ID").HeaderText = "Account ID"
                        .Columns("ACCOUNT").HeaderText = "Account Name"
                        .Columns("BRANCH_ID").HeaderText = "Branch ID"
                        .Columns("BRANCH").HeaderText = "Branch Name"
                        .Columns("TIN").HeaderText = "TIN"
                        .Columns("BUSINESS_TYPE").HeaderText = "Business Type"
                        .Columns("ADDRESS").HeaderText = "Address"
                        .Columns("EMAIL").HeaderText = "Email"
                        .Columns("CONTACT").HeaderText = "Contact Number"
                        .Columns("MANAGER").HeaderText = "Branch Manager"
                        .Columns("SALES").HeaderText = "Total Sales"
                        .Columns("STATUS").HeaderText = "Status"

                        .Columns("SALES").DefaultCellStyle.Format = "#,##0.00"
                    End With

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBranchesOnly()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel Files|*.xlsx"
            saveDialog.Title = "Export Branches"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
                Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
                Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(workbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

                Dim headers() As String = {"Account ID", "Account Name", "Branch ID", "Branch Name", "TIN", "Business Type", "Address", "Email", "Contact Number", "Branch Manager", "Total Sales", "Status"}

                For c As Integer = 0 To headers.Length - 1
                    worksheet.Cells(1, c + 1) = headers(c)
                Next

                worksheet.Rows(1).Font.Bold = True
                worksheet.Rows(1).Interior.Color = Drawing.Color.LightGray

                For r As Integer = 0 To dgvBranchList.Rows.Count - 1
                    For c As Integer = 0 To headers.Length - 1
                        worksheet.Cells(r + 2, c + 1) = dgvBranchList.Rows(r).Cells(c).Value.ToString()
                    Next
                Next

                worksheet.Columns.AutoFit()
                workbook.SaveAs(saveDialog.FileName)
                workbook.Close()
                excelApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)

                MessageBox.Show("Export complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Export Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class