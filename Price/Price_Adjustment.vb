Imports System.Data.SqlClient

Public Class Price_Adjustment

    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        If Not String.IsNullOrWhiteSpace(txtbarcode.Text.Trim()) Then
            LoadProduct(txtbarcode.Text.Trim())
        Else
            ClearFields()
        End If
    End Sub

    Private Sub LoadProduct(searchKey As String)
        Using conn As New SqlConnection(connStr)
            Try
                conn.Open()
                Dim sql As String = "SELECT BRAND, DESCRIPTIONS, SIZE, VENDOR_CODE, VENDOR, PRICE, AVAILABILITY, PRODUCT_IMAGE " &
                                    "FROM inv.Inventory_Master_file " &
                                    "WHERE BARCODE = @key OR SKU = @key"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@key", searchKey)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        lblBrand.Text = reader("BRAND").ToString()
                        lblDesc.Text = reader("DESCRIPTIONS").ToString()
                        lblSize.Text = reader("SIZE").ToString()
                        lblVendorCode.Text = reader("VENDOR_CODE").ToString()
                        lblVendor.Text = reader("VENDOR").ToString()
                        lblAvail.Text = reader("AVAILABILITY").ToString()
                        txtPrice.Text = Convert.ToDecimal(reader("PRICE")).ToString("F2")

                        If Not IsDBNull(reader("PRODUCT_IMAGE")) Then
                            Dim imgBytes As Byte() = CType(reader("PRODUCT_IMAGE"), Byte())
                            Using ms As New IO.MemoryStream(imgBytes)
                                picProduct.Image = Image.FromStream(ms)
                            End Using
                        Else
                            picProduct.Image = Nothing
                        End If
                    Else
                        ClearFields()
                    End If
                End Using
            Catch
                ClearFields()
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtbarcode.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Product not found or price missing.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim newPrice As Decimal
        If Not Decimal.TryParse(txtPrice.Text, newPrice) Then
            MessageBox.Show("Invalid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Using conn As New SqlConnection(connStr)
            Try
                conn.Open()
                Dim updSql As String = "UPDATE inv.Inventory_Master_file SET PRICE = @newPrice " &
                                       "WHERE BARCODE = @key OR SKU = @key"

                Using cmd As New SqlCommand(updSql, conn)
                    cmd.Parameters.AddWithValue("@newPrice", newPrice)
                    cmd.Parameters.AddWithValue("@key", txtbarcode.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Price updated successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtbarcode.Clear()
        lblBrand.Text = ""
        lblDesc.Text = ""
        lblSize.Text = ""
        lblVendorCode.Text = ""
        lblVendor.Text = ""
        txtPrice.Clear()
        lblAvail.Text = ""
        picProduct.Image = Nothing
    End Sub

    Private Sub Price_Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPrice.ReadOnly = False
        txtbarcode.Focus()
    End Sub

End Class