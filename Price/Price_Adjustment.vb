Imports System.Data.SqlClient

Public Class Price_Adjustment

    ' Koneksyon — pareho sa iyong setup
    Private connectionString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    ' ✅ AWTOMATIKO: Habang nagbabago ang laman ng barcode/SKU box → hanap agad
    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        ' Maghanap kapag hindi walang laman
        If Not String.IsNullOrWhiteSpace(txtbarcode.Text.Trim()) Then
            LoadProduct(txtbarcode.Text.Trim())
        Else
            ClearFields() ' kung nabura, linisin ang form
        End If
    End Sub

    ' Kumuha ng detalye mula sa iyong table
    Private Sub LoadProduct(searchKey As String)
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim sql As String = "SELECT BRAND, DESCRIPTIONS, SIZE, VENDOR_CODE, VENDOR, PRICE, AVAILABILITY, PRODUCT_IMAGE " &
                                    "FROM inv.Inventory_Master_file " &
                                    "WHERE BARCODE = @key OR SKU = @key"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@key", searchKey)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Ipakita ang detalye — hindi pwedeng i‑edit
                        lblBrand.Text = reader("BRAND").ToString()
                        lblDesc.Text = reader("DESCRIPTIONS").ToString()
                        lblSize.Text = reader("SIZE").ToString()
                        lblVendorCode.Text = reader("VENDOR_CODE").ToString()
                        lblVendor.Text = reader("VENDOR").ToString()
                        lblAvail.Text = reader("AVAILABILITY").ToString()

                        ' ✅ Presyo — pwede baguhin lang ito
                        txtPrice.Text = Convert.ToDecimal(reader("PRICE")).ToString("F2")

                        ' Litrato — pampakita lang
                        If Not IsDBNull(reader("PRODUCT_IMAGE")) Then
                            Dim imgBytes As Byte() = CType(reader("PRODUCT_IMAGE"), Byte())
                            Using ms As New IO.MemoryStream(imgBytes)
                                picProduct.Image = Image.FromStream(ms)
                            End Using
                        Else
                            picProduct.Image = Nothing
                        End If
                    Else
                        ' Walang nahanap → linisin
                        ClearFields()
                    End If
                End Using
            Catch ex As Exception
                ' Kung may mali, linisin lang (walang extra Enter)
                ClearFields()
            End Try
        End Using
    End Sub

    ' ✅ UPDATE / SAVE — tanging pagbabago lang sa presyo
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

        Using conn As New SqlConnection(connectionString)
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

    ' ❌ CANCEL — linisin lang
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearFields()
    End Sub

    ' Pantulong: Linisin lahat
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

    ' Simula: I‑lock ang iba — presyo lang bukas
    Private Sub Price_Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPrice.ReadOnly = False
        txtbarcode.Focus()
    End Sub
End Class