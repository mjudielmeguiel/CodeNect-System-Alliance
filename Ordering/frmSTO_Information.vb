Imports System.Data
Imports System.Data.SqlClient

Public Class frmSTO_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadOrderDetails(poNumber As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' --- Load Header Information from STO_DATA ---
                Dim sqlHeader As String = "SELECT * FROM STO_DATA WHERE PO_NUMBER = @DocNo"
                Using cmdHeader As New SqlCommand(sqlHeader, conn)
                    cmdHeader.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber

                    Using dr As SqlDataReader = cmdHeader.ExecuteReader()
                        If dr.Read() Then
                            lblPONumber.Text = dr("PO_NUMBER").ToString()
                            lblDR.Text = dr("DR").ToString()
                            lblFrom.Text = dr("FROM").ToString()
                            lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                            lblTo.Text = dr("TO").ToString()
                            lblstatus.Text = dr("STATUS").ToString()
                            lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")
                        End If
                    End Using
                End Using

                ' --- Load Stock Ordering Items into DataGridView ---
                ' Select only the columns you need, using the exact names from your table
                Dim sqlItems As String = "SELECT 
                    BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, 
                    PRICE, ORDER_QTY, TOTAL, VENDOR_NAME, REMARKS 
                    FROM Stock_Ordering 
                    WHERE PO_NUMBER = @DocNo"

                Using cmdItems As New SqlCommand(sqlItems, conn)
                    cmdItems.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber

                    Dim dtItems As New DataTable()
                    Using da As New SqlDataAdapter(cmdItems)
                        da.Fill(dtItems)
                    End Using

                    ' Bind to DataGridView
                    dgvItems.DataSource = dtItems

                    ' Optional: Format columns for better readability
                    FormatGridColumns()
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGridColumns()
        ' Set friendly column headers
        With dgvItems
            .Columns("BARCODE").HeaderText = "Barcode"
            .Columns("SKU").HeaderText = "SKU"
            .Columns("BRAND").HeaderText = "Brand"
            .Columns("DESCRIPTIONS").HeaderText = "Description"
            .Columns("SIZE").HeaderText = "Size"
            .Columns("PRICE").HeaderText = "Unit Price"
            .Columns("ORDER_QTY").HeaderText = "Order Qty"
            .Columns("TOTAL").HeaderText = "Line Total"
            .Columns("VENDOR_NAME").HeaderText = "Vendor"
            .Columns("REMARKS").HeaderText = "Remarks"

            ' Format number columns
            .Columns("PRICE").DefaultCellStyle.Format = "N2"
            .Columns("TOTAL").DefaultCellStyle.Format = "N2"

            ' Auto-fit columns
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class