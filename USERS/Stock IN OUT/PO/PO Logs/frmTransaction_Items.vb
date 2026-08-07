Imports MySqlConnector
Imports System.Drawing

Public Class frmTransaction_Items
    ' ✅ Tatanggap ng PO Number mula sa Order_History form
    Public Property SelectedPONumber As String = Nothing

    Private Sub frmTransaction_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ I-setup ang DataGridView
        dgvItems.AutoGenerateColumns = False
        dgvItems.ReadOnly = True
        dgvItems.AllowUserToAddRows = False
        dgvItems.Columns.Clear()

        ' ✅ MGA COLUMN — KASAMA NA ANG STATUS
        dgvItems.Columns.Add("BARCODE", "Barcode")
        dgvItems.Columns.Add("BRAND", "Brand")
        dgvItems.Columns.Add("DESCRIPTIONS", "Description")
        dgvItems.Columns.Add("ORDER_QTY", "Ordered Qty")
        dgvItems.Columns.Add("SIZE", "Size")
        dgvItems.Columns.Add("SKU", "SKU")
        dgvItems.Columns.Add("PRICE", "Unit Price")
        dgvItems.Columns.Add("TOTAL", "Total Amount")
        dgvItems.Columns.Add("STOCK_IN", "Stock In")
        dgvItems.Columns.Add("STOCK_OUT", "Stock Out")
        dgvItems.Columns.Add("STATUS", "Status")

        ' Lahat ay Read-Only
        For Each col As DataGridViewColumn In dgvItems.Columns
            col.ReadOnly = True
        Next

        ' ✅ Check kung may natanggap na PO Number
        If String.IsNullOrWhiteSpace(SelectedPONumber) Then
            MessageBox.Show("Walang natanggap na PO Number!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadItemsByPO()
    End Sub

    Private Sub LoadItemsByPO()
        dgvItems.Rows.Clear()

        Using conn As New MySqlConnection(DBConnection.connStr)
            conn.Open()

            Dim cmd As New MySqlCommand("
                SELECT so.BARCODE, so.BRAND, so.DESCRIPTIONS, so.ORDER_QTY, so.SIZE, so.SKU, so.PRICE, so.TOTAL, so.STOCK_IN, so.STOCK_OUT, sd.STATUS
                FROM stock_ordering so
                LEFT JOIN sto_data sd ON so.PO_NUMBER = sd.PO_NUMBER
                WHERE so.PO_NUMBER = @PO
                ORDER BY so.ID", conn)

            cmd.Parameters.AddWithValue("@PO", SelectedPONumber)

            Using dr = cmd.ExecuteReader()
                Dim itemCount As Integer = 0

                While dr.Read()
                    Dim barcode As String = dr("BARCODE").ToString()
                    Dim brand As String = dr("BRAND").ToString()
                    Dim desc As String = dr("DESCRIPTIONS").ToString()
                    Dim qty As String = dr("ORDER_QTY").ToString()
                    Dim size As String = dr("SIZE").ToString()
                    Dim sku As String = dr("SKU").ToString()
                    Dim price As String = Convert.ToDecimal(dr("PRICE")).ToString("N2")
                    Dim totalAmt As String = Convert.ToDecimal(dr("TOTAL")).ToString("N2")

                    Dim stockIn As String = If(dr.IsDBNull(dr.GetOrdinal("STOCK_IN")), "-", dr("STOCK_IN").ToString())
                    Dim stockOut As String = If(dr.IsDBNull(dr.GetOrdinal("STOCK_OUT")), "-", dr("STOCK_OUT").ToString())
                    Dim status As String = If(dr.IsDBNull(dr.GetOrdinal("STATUS")), "-", dr("STATUS").ToString().Trim().ToUpper())

                    ' ✅ Idagdag lahat — KASAMA NA ANG STATUS
                    Dim rowIdx As Integer = dgvItems.Rows.Add(barcode, brand, desc, qty, size, sku, price, totalAmt, stockIn, stockOut, status)

                    ' ✅ Kulay ayon sa Status
                    Dim statusCell = dgvItems.Rows(rowIdx).Cells("STATUS")
                    Select Case status
                        Case "PENDING"
                            statusCell.Style.BackColor = Color.Orange
                            statusCell.Style.ForeColor = Color.White
                        Case "RECEIVED"
                            statusCell.Style.BackColor = Color.Green
                            statusCell.Style.ForeColor = Color.White
                        Case "CANCELLED"
                            statusCell.Style.BackColor = Color.Red
                            statusCell.Style.ForeColor = Color.White
                    End Select

                    itemCount += 1
                End While

                If itemCount = 0 Then
                    MessageBox.Show($"Walang nakitang produkto para sa PO: {SelectedPONumber}", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End Using
    End Sub
End Class