Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Price_Adjustment

    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        Dim searchValue As String = txtbarcode.Text.Trim()

        If Not String.IsNullOrWhiteSpace(searchValue) Then
            LoadProduct(searchValue)
        Else
            ClearAllFields()
        End If
    End Sub

    Private Sub LoadProduct(searchKey As String)
        ClearDisplay()

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Query na walang branch filter muna
                Dim sql As String = "SELECT BRAND, DESCRIPTIONS, SIZE, VENDOR_CODE, VENDOR, PRICE, AVAILABILITY, PRODUCT_IMAGE " &
                                    "FROM inv.Inventory_Master_file " &
                                    "WHERE (BARCODE = @Key OR SKU = @Key)"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@Key", SqlDbType.VarChar).Value = searchKey

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblBrand.Text = reader("BRAND").ToString()
                            lblDesc.Text = reader("DESCRIPTIONS").ToString()
                            lblSize.Text = reader("SIZE").ToString()
                            lblVendorCode.Text = reader("VENDOR_CODE").ToString()
                            lblVendor.Text = reader("VENDOR").ToString()
                            lblAvail.Text = reader("AVAILABILITY").ToString()

                            txtPrice.Text = Convert.ToDecimal(reader("PRICE")).ToString("F2")

                            If Not reader.IsDBNull(reader.GetOrdinal("PRODUCT_IMAGE")) Then
                                Dim imgBytes As Byte() = DirectCast(reader("PRODUCT_IMAGE"), Byte())
                                Using ms As New MemoryStream(imgBytes)
                                    picProduct.Image = Image.FromStream(ms)
                                End Using
                            Else
                                picProduct.Image = Nothing
                            End If

                            ' Check kung available
                            If reader("AVAILABILITY").ToString().Trim().ToUpper() <> "AVAILABLE" Then
                                MessageBox.Show("This product is NOT carried by this branch.", "Product Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ClearAllFields()
                            End If

                        Else
                            MessageBox.Show("This product is NOT carried by this branch or does not exist.", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ClearDisplay()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim searchKey As String = txtbarcode.Text.Trim()

        If String.IsNullOrWhiteSpace(searchKey) Then
            MessageBox.Show("Please enter a valid Barcode or SKU.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbarcode.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Please enter a price.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrice.Focus()
            Return
        End If

        Dim newPrice As Decimal
        If Not Decimal.TryParse(txtPrice.Text, newPrice) Then
            MessageBox.Show("Invalid price. Enter numbers only.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrice.SelectAll()
            txtPrice.Focus()
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Walang branch filter muna
                Dim updSql As String = "UPDATE inv.Inventory_Master_file " &
                                       "SET PRICE = @NewPrice " &
                                       "WHERE (BARCODE = @Key OR SKU = @Key) AND AVAILABILITY = 'AVAILABLE'"

                Using cmd As New SqlCommand(updSql, conn)
                    cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = newPrice
                    cmd.Parameters.Add("@Key", SqlDbType.VarChar).Value = searchKey

                    Dim rowsUpdated As Integer = cmd.ExecuteNonQuery()

                    If rowsUpdated > 0 Then
                        MessageBox.Show("Price updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearAllFields()
                        txtbarcode.Focus()
                    Else
                        MessageBox.Show("Update failed: Product is not available.", "Cannot Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearDisplay()
        lblBrand.Text = String.Empty
        lblDesc.Text = String.Empty
        lblSize.Text = String.Empty
        lblVendorCode.Text = String.Empty
        lblVendor.Text = String.Empty
        lblAvail.Text = String.Empty
        picProduct.Image = Nothing
    End Sub

    Private Sub ClearAllFields()
        txtbarcode.Clear()
        txtPrice.Clear()
        ClearDisplay()
    End Sub

    Private Sub Price_Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbarcode.ReadOnly = False
        txtPrice.ReadOnly = False
        txtbarcode.Focus()
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso txtPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

End Class