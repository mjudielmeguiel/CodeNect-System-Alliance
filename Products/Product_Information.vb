Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Product_Information

    Private _ProductID As Integer = 0
    Private _OriginalImageBytes As Byte() = Nothing

    Public Sub LoadDataFromGrid(row As DataGridViewRow)
        Try
            _ProductID = CInt(row.Cells("ID").Value)

            ' Lahat ay ipapakita gamit ang LABEL lang
            lblBarcode.Text = If(row.Cells("BARCODE").Value IsNot DBNull.Value, row.Cells("BARCODE").Value.ToString(), "")
            lblSKU.Text = If(row.Cells("SKU").Value IsNot DBNull.Value, row.Cells("SKU").Value.ToString(), "")
            lblDescription.Text = If(row.Cells("DESCRIPTIONS").Value IsNot DBNull.Value, row.Cells("DESCRIPTIONS").Value.ToString(), "")
            lblBrand.Text = If(row.Cells("BRAND").Value IsNot DBNull.Value, row.Cells("BRAND").Value.ToString(), "")
            lblCategory.Text = If(row.Cells("CATEGORY").Value IsNot DBNull.Value, row.Cells("CATEGORY").Value.ToString(), "")
            lblVendorCode.Text = If(row.Cells("VENDOR_CODE").Value IsNot DBNull.Value, row.Cells("VENDOR_CODE").Value.ToString(), "")
            lblVendor.Text = If(row.Cells("VENDOR").Value IsNot DBNull.Value, row.Cells("VENDOR").Value.ToString(), "")
            lblUnit.Text = If(row.Cells("UNIT").Value IsNot DBNull.Value, row.Cells("UNIT").Value.ToString(), "")
            lblSize.Text = If(row.Cells("SIZE").Value IsNot DBNull.Value, row.Cells("SIZE").Value.ToString(), "")
            lblPrice.Text = If(row.Cells("PRICE").Value IsNot DBNull.Value, CDec(row.Cells("PRICE").Value).ToString("N2"), "0.00")
            lblStockAvailable.Text = If(row.Cells("AVAILABLE").Value IsNot DBNull.Value, CInt(row.Cells("AVAILABLE").Value).ToString(), "0")
            lblAvailability.Text = If(row.Cells("AVAILABILITY").Value IsNot DBNull.Value, row.Cells("AVAILABILITY").Value.ToString(), "")
            lblTotal.Text = If(row.Cells("TOTAL").Value IsNot DBNull.Value, CDec(row.Cells("TOTAL").Value).ToString("N2"), "0.00")

            ' Ipakita ang litrato ng produkto
            picProduct.SizeMode = PictureBoxSizeMode.Zoom
            If row.Cells("PRODUCT_IMAGE").Value IsNot DBNull.Value Then
                _OriginalImageBytes = DirectCast(row.Cells("PRODUCT_IMAGE").Value, Byte())
                Using ms As New MemoryStream(_OriginalImageBytes)
                    picProduct.Image = Image.FromStream(ms)
                End Using
            Else
                picProduct.Image = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        If MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand("DELETE FROM inv.Inventory_Master_file WHERE ID = @ID", con)
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _ProductID
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Delete failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class