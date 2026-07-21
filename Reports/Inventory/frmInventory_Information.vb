Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class frmInventory_Information

    Private ReadOnly connStr As String = DBConnection.connStr
    Private _transactionID As String

    ' Constructor: Tatanggapin ang Transaction ID
    Public Sub New(transactionID As String)
        InitializeComponent()
        _transactionID = transactionID
    End Sub

    Private Sub frmInventory_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = $"Transaction Details: {_transactionID}"
        LoadTransactionDetails()
    End Sub

    Private Sub LoadTransactionDetails()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' ✅ Eksaktong tugma sa table mo, tama ang mga pangalan ng column
                Dim sql As String = "
                    SELECT 
                        BARCODE AS Barcode,
                        SKU AS SKU,
                        BRAND AS Brand,
                        DESCRIPTIONS AS [Description],
                        CATEGORY AS Category,
                        SIZE AS Size,
                        PRICE AS Price,
                        UNIT AS Unit,
                        AVAILABLE AS [Stock Before],
                        ACTUAL_COUNT AS [Actual Count],
                        DIFFERENCE AS Difference,
                        DIFFERENCE_VALUE AS [Difference Amount],
                        TOTAL AS [Line Total],
                        AVAILABILITY AS [Availability Status],
                        VENDOR_CODE AS [Vendor Code],
                        VENDOR AS Vendor
                    FROM dbo.INVENTORY_INFORMATION
                    WHERE TRANSACTION_ID = @TransID
                "

                ' Filter para sa search
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    sql &= " AND (BARCODE LIKE @Search OR SKU LIKE @Search OR BRAND LIKE @Search OR DESCRIPTIONS LIKE @Search)"
                End If

                sql &= " ORDER BY BRAND, DESCRIPTIONS"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TransID", _transactionID)

                    If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                        cmd.Parameters.AddWithValue("@Search", "%" & txtSearch.Text.Trim() & "%")
                    End If

                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    dgvDetails.DataSource = dt

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("No items found for this transaction.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    FormatGrid()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        ' ✅ I-check muna kung may laman ang grid bago i-format
        If dgvDetails.Columns.Count = 0 Then Return

        Try
            ' Format ng mga numero
            dgvDetails.Columns("Price").DefaultCellStyle.Format = "N2"
            dgvDetails.Columns("Difference Amount").DefaultCellStyle.Format = "N2"
            dgvDetails.Columns("Line Total").DefaultCellStyle.Format = "N2"

            ' I-align pakanan ang mga numero
            dgvDetails.Columns("Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetails.Columns("Stock Before").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetails.Columns("Actual Count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetails.Columns("Difference").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetails.Columns("Difference Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetails.Columns("Line Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Ayusin ang lapad ng mga column
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MessageBox.Show("Error formatting grid: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadTransactionDetails()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvDetails.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx"
                sfd.FileName = $"Transaction_{_transactionID}_Details_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Using wb As New XLWorkbook()
                        Dim ws = wb.Worksheets.Add("Transaction Details")

                        ' Ilagay ang mga header
                        For col As Integer = 0 To dgvDetails.Columns.Count - 1
                            ws.Cell(1, col + 1).Value = dgvDetails.Columns(col).HeaderText
                        Next

                        ' Ilagay ang mga datos
                        For row As Integer = 0 To dgvDetails.Rows.Count - 1
                            For col As Integer = 0 To dgvDetails.Columns.Count - 1
                                ws.Cell(row + 2, col + 1).Value = dgvDetails.Rows(row).Cells(col).Value
                            Next
                        Next

                        ws.Columns().AdjustToContents()
                        wb.SaveAs(sfd.FileName)
                    End Using
                    MessageBox.Show("Exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class