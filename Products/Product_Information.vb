Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class Product_Information

    Private _dtVendors As New DataTable
    Private _ProductID As Integer = 0
    Private _OriginalImageBytes As Byte() = Nothing
    Private ReadOnly _fileDialog As New OpenFileDialog()

    ' ─────────────────────────────────────────────────────────
    ' Load data from selected grid row
    ' ─────────────────────────────────────────────────────────
    Public Sub LoadDataFromGrid(row As DataGridViewRow)
        Try
            _ProductID = CInt(row.Cells("ID").Value)

            txtBarcode.Text = If(row.Cells("BARCODE").Value IsNot DBNull.Value, row.Cells("BARCODE").Value.ToString(), "")
            txtSKU.Text = If(row.Cells("SKU").Value IsNot DBNull.Value, row.Cells("SKU").Value.ToString(), "")
            txtDescriptions.Text = If(row.Cells("DESCRIPTIONS").Value IsNot DBNull.Value, row.Cells("DESCRIPTIONS").Value.ToString(), "")
            txtBrand.Text = If(row.Cells("BRAND").Value IsNot DBNull.Value, row.Cells("BRAND").Value.ToString(), "")
            txtUnit.Text = If(row.Cells("UNIT").Value IsNot DBNull.Value, row.Cells("UNIT").Value.ToString(), "")
            txtSize.Text = If(row.Cells("SIZE").Value IsNot DBNull.Value, row.Cells("SIZE").Value.ToString(), "")
            txtPrice.Text = If(row.Cells("PRICE").Value IsNot DBNull.Value, CDec(row.Cells("PRICE").Value).ToString("N2"), "0.00")
            txtStockAvailable.Text = If(row.Cells("AVAILABLE").Value IsNot DBNull.Value, CInt(row.Cells("AVAILABLE").Value).ToString(), "0")
            txtAvailability.Text = If(row.Cells("AVAILABILITY").Value IsNot DBNull.Value, row.Cells("AVAILABILITY").Value.ToString(), "")
            txtTotal.Text = If(row.Cells("TOTAL").Value IsNot DBNull.Value, CDec(row.Cells("TOTAL").Value).ToString("N2"), "0.00")

            picProduct.SizeMode = PictureBoxSizeMode.Zoom
            If row.Cells("PRODUCT_IMAGE").Value IsNot DBNull.Value Then
                _OriginalImageBytes = DirectCast(row.Cells("PRODUCT_IMAGE").Value, Byte())
                Using ms As New MemoryStream(_OriginalImageBytes)
                    picProduct.Image = Image.FromStream(ms)
                End Using
            Else
                picProduct.Image = Nothing
                _OriginalImageBytes = Nothing
            End If

            LoadAllVendorsFromDB()
            LoadCategories()
            SetCurrentVendor(row)

        Catch ex As Exception
            MessageBox.Show("Error loading product data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Load vendor list from database
    ' ─────────────────────────────────────────────────────────
    Private Sub LoadAllVendorsFromDB()
        Try
            _dtVendors.Clear()
            _dtVendors.Columns.Clear()
            _dtVendors.Columns.Add("VENDOR_CODE", GetType(String))
            _dtVendors.Columns.Add("VENDOR", GetType(String))

            Dim sql As String = "SELECT VENDOR_CODE, VENDOR FROM dbo.vendor ORDER BY VENDOR"

            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, con)
                    con.Open()
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim code As String = dr("VENDOR_CODE").ToString().Trim()
                        Dim name As String = dr("VENDOR").ToString().Trim()
                        If Not String.IsNullOrEmpty(code) AndAlso Not String.IsNullOrEmpty(name) Then
                            _dtVendors.Rows.Add(code, name)
                        End If
                    End While
                    dr.Close()
                End Using
            End Using

            cboVendorCode.DataSource = Nothing
            cboVendorCode.DisplayMember = "VENDOR_CODE"
            cboVendorCode.ValueMember = "VENDOR_CODE"
            cboVendorCode.DataSource = _dtVendors
            cboVendorCode.DropDownStyle = ComboBoxStyle.DropDown
            cboVendorCode.MaxDropDownItems = 25

            cboVendor.DataSource = Nothing
            cboVendor.DisplayMember = "VENDOR"
            cboVendor.ValueMember = "VENDOR"
            cboVendor.DataSource = _dtVendors
            cboVendor.DropDownStyle = ComboBoxStyle.DropDown
            cboVendor.MaxDropDownItems = 25

        Catch ex As Exception
            MessageBox.Show("Error loading vendors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Set current vendor values
    ' ─────────────────────────────────────────────────────────
    Private Sub SetCurrentVendor(row As DataGridViewRow)
        Try
            Dim currentCode As String = If(row.Cells("VENDOR_CODE").Value IsNot DBNull.Value, row.Cells("VENDOR_CODE").Value.ToString().Trim(), "")
            Dim currentName As String = If(row.Cells("VENDOR").Value IsNot DBNull.Value, row.Cells("VENDOR").Value.ToString().Trim(), "")

            If Not String.IsNullOrEmpty(currentCode) Then
                For Each dr As DataRow In _dtVendors.Rows
                    If dr("VENDOR_CODE").ToString().Trim() = currentCode Then
                        cboVendorCode.SelectedValue = dr("VENDOR_CODE")
                        cboVendor.SelectedValue = dr("VENDOR")
                        Exit For
                    End If
                Next
            Else
                cboVendorCode.Text = currentCode
                cboVendor.Text = currentName
            End If
        Catch ex As Exception
            MessageBox.Show("Error setting vendor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Sync vendor code and name
    ' ─────────────────────────────────────────────────────────
    Private Sub cboVendorCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendorCode.SelectedIndexChanged
        Try
            If cboVendorCode.SelectedIndex >= 0 AndAlso _dtVendors.Rows.Count > 0 Then
                Dim dr As DataRow = _dtVendors.Rows(cboVendorCode.SelectedIndex)
                cboVendor.SelectedValue = dr("VENDOR")
            End If
        Catch
        End Try
    End Sub

    Private Sub cboVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendor.SelectedIndexChanged
        Try
            If cboVendor.SelectedIndex >= 0 AndAlso _dtVendors.Rows.Count > 0 Then
                Dim dr As DataRow = _dtVendors.Rows(cboVendor.SelectedIndex)
                cboVendorCode.SelectedValue = dr("VENDOR_CODE")
            End If
        Catch
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Load categories
    ' ─────────────────────────────────────────────────────────
    Private Sub LoadCategories()
        Try
            Dim dtCat As New DataTable()
            Dim sql As String = "SELECT DISTINCT CATEGORY FROM inv.Inventory_Master_file WHERE CATEGORY <> '' ORDER BY CATEGORY"

            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, con)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dtCat)
                    End Using
                End Using
            End Using

            cboCategory.DataSource = dtCat
            cboCategory.DisplayMember = "CATEGORY"
            cboCategory.ValueMember = "CATEGORY"
            cboCategory.DropDownStyle = ComboBoxStyle.DropDown

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Select new product image
    ' ─────────────────────────────────────────────────────────
    Private Sub picProduct_DoubleClick(sender As Object, e As EventArgs) Handles picProduct.DoubleClick
        _fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp"
        _fileDialog.Title = "Select Product Image"
        If _fileDialog.ShowDialog() = DialogResult.OK Then
            Try
                picProduct.Image = Image.FromFile(_fileDialog.FileName)
            Catch ex As Exception
                MessageBox.Show("Failed to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Calculate total and availability status
    ' ─────────────────────────────────────────────────────────
    Private Sub ComputeTotalAndAvailability()
        Try
            Dim p As Decimal = If(IsNumeric(txtPrice.Text), CDec(txtPrice.Text), 0)
            Dim s As Integer = If(IsNumeric(txtStockAvailable.Text), CInt(txtStockAvailable.Text), 0)
            txtTotal.Text = (p * s).ToString("N2")
            txtAvailability.Text = If(s <= 0, "Out of Stock", If(s <= 10, "Critical", "Available"))
        Catch
            txtTotal.Text = "0.00"
        End Try
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        ComputeTotalAndAvailability()
    End Sub

    Private Sub txtStockAvailable_TextChanged(sender As Object, e As EventArgs) Handles txtStockAvailable.TextChanged
        ComputeTotalAndAvailability()
    End Sub

    Private Sub btnCarried_Click(sender As Object, e As EventArgs) Handles btnCarried.Click
        txtAvailability.Text = "Available"
    End Sub

    Private Sub btnNotCarried_Click(sender As Object, e As EventArgs) Handles btnNotCarried.Click
        txtAvailability.Text = "Not Carried"
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Update product details
    ' ─────────────────────────────────────────────────────────
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
                MessageBox.Show("Barcode cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrWhiteSpace(txtSKU.Text) Then
                MessageBox.Show("SKU cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Not Decimal.TryParse(txtPrice.Text, Nothing) OrElse CDec(txtPrice.Text) <= 0 Then
                MessageBox.Show("Enter a valid price greater than zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Not Integer.TryParse(txtStockAvailable.Text, Nothing) OrElse CInt(txtStockAvailable.Text) < 0 Then
                MessageBox.Show("Enter a valid stock quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim imgBytes As Byte() = Nothing
            If picProduct.Image IsNot Nothing Then
                If Not String.IsNullOrEmpty(_fileDialog.FileName) Then
                    Using ms As New MemoryStream()
                        picProduct.Image.Save(ms, ImageFormat.Jpeg)
                        imgBytes = ms.ToArray()
                    End Using
                Else
                    imgBytes = _OriginalImageBytes
                End If
            End If

            Dim sql As String = "
                UPDATE inv.Inventory_Master_file
                SET
                    BARCODE = @Barcode,
                    SKU = @SKU,
                    DESCRIPTIONS = @Desc,
                    BRAND = @Brand,
                    CATEGORY = @Cat,
                    VENDOR_CODE = @VC,
                    VENDOR = @VN,
                    UNIT = @Unit,
                    SIZE = @Size,
                    PRICE = @Price,
                    AVAILABLE = @Stock,
                    AVAILABILITY = @Avail,
                    TOTAL = @Total,
                    PRODUCT_IMAGE = @Img
                WHERE ID = @ID"

            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _ProductID
                    cmd.Parameters.Add("@Barcode", SqlDbType.VarChar, 50).Value = txtBarcode.Text.Trim()
                    cmd.Parameters.Add("@SKU", SqlDbType.VarChar, 50).Value = txtSKU.Text.Trim()
                    cmd.Parameters.Add("@Desc", SqlDbType.VarChar, 255).Value = If(String.IsNullOrEmpty(txtDescriptions.Text), DBNull.Value, txtDescriptions.Text.Trim())
                    cmd.Parameters.Add("@Brand", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(txtBrand.Text), DBNull.Value, txtBrand.Text.Trim())
                    cmd.Parameters.Add("@Cat", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(cboCategory.Text), DBNull.Value, cboCategory.Text.Trim())
                    cmd.Parameters.Add("@VC", SqlDbType.VarChar, 50).Value = If(String.IsNullOrEmpty(cboVendorCode.Text), DBNull.Value, cboVendorCode.Text.Trim())
                    cmd.Parameters.Add("@VN", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(cboVendor.Text), DBNull.Value, cboVendor.Text.Trim())
                    cmd.Parameters.Add("@Unit", SqlDbType.VarChar, 20).Value = If(String.IsNullOrEmpty(txtUnit.Text), DBNull.Value, txtUnit.Text.Trim())
                    cmd.Parameters.Add("@Size", SqlDbType.VarChar, 50).Value = If(String.IsNullOrEmpty(txtSize.Text), DBNull.Value, txtSize.Text.Trim())
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = CDec(txtPrice.Text)
                    cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = CInt(txtStockAvailable.Text)
                    cmd.Parameters.Add("@Avail", SqlDbType.VarChar, 20).Value = txtAvailability.Text.Trim()
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = CDec(txtTotal.Text)
                    cmd.Parameters.Add("@Img", SqlDbType.VarBinary).Value = If(imgBytes IsNot Nothing, imgBytes, DBNull.Value)

                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ─────────────────────────────────────────────────────────
    ' Delete product
    ' ─────────────────────────────────────────────────────────
    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        Try
            If MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            Dim sql As String = "DELETE FROM inv.Inventory_Master_file WHERE ID = @ID"

            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, con)
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

    ' ─────────────────────────────────────────────────────────
    ' Close form
    ' ─────────────────────────────────────────────────────────
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class