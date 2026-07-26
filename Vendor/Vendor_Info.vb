Imports System.Data
Imports MySqlConnector
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Runtime.InteropServices
' ✅ Nilagyan ng alias para iwas conflict
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Vendor_Info

    Private connStr As String = DBConnection.connStr
    Private currentPhoto As Byte() = Nothing

    Public Property SelectedVendorCode As String = ""

    Private Sub Vendor_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDropdownItems()

        txtVendorCode.ReadOnly = False
        txtVendorCode.Enabled = True

        If Not String.IsNullOrEmpty(SelectedVendorCode) Then
            LoadVendorDetails()
            LoadVendorInventory()
        End If

        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.ReadOnly = True
        dgvProducts.AutoGenerateColumns = True

        If picVendor IsNot Nothing Then
            picVendor.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub SetDropdownItems()
        cboVatStatus.Items.Clear()
        cboVatStatus.Items.Add("VAT Registered")
        cboVatStatus.Items.Add("Non-VAT")
        cboVatStatus.SelectedIndex = 0

        cboModeOfPayment.Items.Clear()
        cboModeOfPayment.Items.Add("Cash")
        cboModeOfPayment.Items.Add("Check")
        cboModeOfPayment.Items.Add("Online Transfer")
        cboModeOfPayment.Items.Add("GCash / Maya")
        cboModeOfPayment.Items.Add("Credit Card")
        cboModeOfPayment.Items.Add("Bank Transfer")
        cboModeOfPayment.SelectedIndex = -1

        cboBank.Items.Clear()
        cboBank.Items.Add("BDO")
        cboBank.Items.Add("BPI")
        cboBank.Items.Add("Metrobank")
        cboBank.Items.Add("Landbank")
        cboBank.Items.Add("Unionbank")
        cboBank.Items.Add("RCBC")
        cboBank.Items.Add("Security Bank")
        cboBank.SelectedIndex = -1

        cboPaymentTerms.Items.Clear()
        cboPaymentTerms.Items.Add("7 Days")
        cboPaymentTerms.Items.Add("15 Days")
        cboPaymentTerms.Items.Add("30 Days")
        cboPaymentTerms.Items.Add("60 Days")
        cboPaymentTerms.Items.Add("90 Days")
        cboPaymentTerms.SelectedIndex = -1
    End Sub

    Private Sub LoadVendorDetails()
        Try
            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand("SELECT *, IFNULL(`VENDOR_PHOTO`, NULL) AS `VENDOR_PHOTO` FROM `vendor` WHERE TRIM(`VENDOR_CODE`) = @VC", conn)
                    cmd.Parameters.AddWithValue("@VC", SelectedVendorCode.Trim())
                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            txtVendorCode.Text = dr("VENDOR_CODE").ToString().Trim()
                            txtVendor.Text = dr("VENDOR").ToString().Trim()
                            txtTIN.Text = dr("TIN").ToString().Trim()
                            txtContact.Text = dr("CONTACT").ToString().Trim()
                            txtEmail.Text = dr("EMAIL").ToString().Trim()
                            txtSalesPerson.Text = dr("SALES_PERSON").ToString().Trim()
                            cboBusinessType.Text = dr("BUSINESS_TYPE").ToString().Trim()
                            txtAddress.Text = dr("ADDRESS").ToString().Trim()
                            txtDTI.Text = dr("DTI_REG_NUMBER").ToString().Trim()
                            cboModeOfPayment.Text = dr("MODE_OF_PAYMENT").ToString().Trim()
                            cboBank.Text = dr("BANK").ToString().Trim()
                            txtBankAccount.Text = dr("BANK_ACCOUNT_NUMBER").ToString().Trim()
                            cboPaymentTerms.Text = dr("PAYMENT_TERMS").ToString().Trim()
                            cboVatStatus.Text = dr("VAT_STATUS").ToString().Trim()

                            If Not dr.IsDBNull(dr.GetOrdinal("VENDOR_PHOTO")) Then
                                currentPhoto = DirectCast(dr("VENDOR_PHOTO"), Byte())
                                Using ms As New MemoryStream(currentPhoto)
                                    picVendor.Image = Image.FromStream(ms)
                                    picVendor.SizeMode = PictureBoxSizeMode.Zoom
                                End Using
                            Else
                                picVendor.Image = Nothing
                                currentPhoto = Nothing
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Vendor Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadVendorInventory(Optional filter As String = "")
        Dim dt As New DataTable()
        Try
            Dim query As String = "SELECT `BARCODE`, `BRAND`, `DESCRIPTIONS`, `CATEGORY`, `UNIT`, `SIZE`, `PRICE` FROM `Vendor_Products` WHERE TRIM(UPPER(`VENDOR_CODE`)) = UPPER(@VC)"
            If Not String.IsNullOrEmpty(filter) Then
                query &= " AND (TRIM(UPPER(`BARCODE`)) LIKE CONCAT('%', UPPER(@Filter), '%') OR TRIM(UPPER(`BRAND`)) LIKE CONCAT('%', UPPER(@Filter), '%') OR TRIM(UPPER(`DESCRIPTIONS`)) LIKE CONCAT('%', UPPER(@Filter), '%') OR TRIM(UPPER(`CATEGORY`)) LIKE CONCAT('%', UPPER(@Filter), '%'))"
            End If

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@VC", txtVendorCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@Filter", filter.Trim())
                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(dr)
                    End Using
                End Using
            End Using

            dgvProducts.DataSource = dt
            FormatGridColumns()
        Catch ex As Exception
            MessageBox.Show("Inventory Error: " & ex.Message)
        End Try
    End Sub

    Private Sub FormatGridColumns()
        If dgvProducts.Columns.Count > 0 Then
            Try
                With dgvProducts
                    .Columns("BARCODE").HeaderText = "Barcode"
                    .Columns("BARCODE").Width = 130
                    .Columns("BARCODE").DisplayIndex = 0
                    .Columns("BRAND").HeaderText = "Brand"
                    .Columns("BRAND").Width = 120
                    .Columns("BRAND").DisplayIndex = 1
                    .Columns("DESCRIPTIONS").HeaderText = "Description"
                    .Columns("DESCRIPTIONS").Width = 240
                    .Columns("DESCRIPTIONS").DisplayIndex = 2
                    .Columns("CATEGORY").HeaderText = "Category"
                    .Columns("CATEGORY").Width = 110
                    .Columns("CATEGORY").DisplayIndex = 3
                    .Columns("UNIT").HeaderText = "Unit"
                    .Columns("UNIT").Width = 70
                    .Columns("UNIT").DisplayIndex = 4
                    .Columns("SIZE").HeaderText = "Size"
                    .Columns("SIZE").Width = 80
                    .Columns("SIZE").DisplayIndex = 5
                    .Columns("PRICE").HeaderText = "Price"
                    .Columns("PRICE").Width = 80
                    .Columns("PRICE").DefaultCellStyle.Format = "0.00"
                    .Columns("PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("PRICE").DisplayIndex = 6
                End With
            Catch
            End Try
        End If
    End Sub

    Private Sub picVendor_DoubleClick(sender As Object, e As EventArgs) Handles picVendor.DoubleClick
        Using ofd As New OpenFileDialog() With {
            .Title = "Select Vendor Photo",
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            .RestoreDirectory = True
        }
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    picVendor.Image = Image.FromFile(ofd.FileName)
                    picVendor.SizeMode = PictureBoxSizeMode.Zoom
                    Using ms As New MemoryStream()
                        picVendor.Image.Save(ms, picVendor.Image.RawFormat)
                        currentPhoto = ms.ToArray()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Cannot open image: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Not String.IsNullOrWhiteSpace(txtVendorCode.Text) Then
            SelectedVendorCode = txtVendorCode.Text.Trim()
            LoadVendorDetails()
            txtSearch.Clear()
            LoadVendorInventory()
        Else
            MessageBox.Show("Please enter Vendor Code first!")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(txtVendor.Text) OrElse String.IsNullOrWhiteSpace(txtTIN.Text) OrElse String.IsNullOrWhiteSpace(txtVendorCode.Text) Then
            MessageBox.Show("Vendor Code, Vendor Name and TIN are required!")
            Return
        End If

        Dim ans = MessageBox.Show("Update vendor details? This includes photo and products.", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ans <> DialogResult.Yes Then Return

        Dim oldVendorCode As String = SelectedVendorCode.Trim()
        Dim newVendorCode As String = txtVendorCode.Text.Trim()

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                If oldVendorCode.ToUpper() <> newVendorCode.ToUpper() Then
                    Using cmdUpdProd As New MySqlCommand("UPDATE `Vendor_Products` SET `VENDOR_CODE` = @NewCode WHERE TRIM(UPPER(`VENDOR_CODE`)) = UPPER(@OldCode)", conn)
                        cmdUpdProd.Parameters.AddWithValue("@NewCode", newVendorCode)
                        cmdUpdProd.Parameters.AddWithValue("@OldCode", oldVendorCode)
                        cmdUpdProd.ExecuteNonQuery()
                    End Using
                End If

                Using cmd As New MySqlCommand("UPDATE `vendor` SET `VENDOR_CODE` = @NewCode, `VENDOR` = @VENDOR, `TIN` = @TIN, `CONTACT` = @CONTACT, `EMAIL` = @EMAIL, `SALES_PERSON` = @SALES, `BUSINESS_TYPE` = @BTYPE, `ADDRESS` = @ADDRESS, `DTI_REG_NUMBER` = @DTI, `VAT_STATUS` = @VAT, `MODE_OF_PAYMENT` = @MOP, `BANK` = @BANK, `BANK_ACCOUNT_NUMBER` = @ACC, `PAYMENT_TERMS` = @TERMS, `VENDOR_PHOTO` = @PHOTO WHERE TRIM(`VENDOR_CODE`) = @OldCode", conn)
                    cmd.Parameters.AddWithValue("@NewCode", newVendorCode)
                    cmd.Parameters.AddWithValue("@OldCode", oldVendorCode)
                    cmd.Parameters.AddWithValue("@VENDOR", txtVendor.Text.Trim())
                    cmd.Parameters.AddWithValue("@TIN", txtTIN.Text.Trim())
                    cmd.Parameters.AddWithValue("@CONTACT", txtContact.Text.Trim())
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@SALES", txtSalesPerson.Text.Trim())
                    cmd.Parameters.AddWithValue("@BTYPE", cboBusinessType.Text.Trim())
                    cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@DTI", txtDTI.Text.Trim())
                    cmd.Parameters.AddWithValue("@VAT", cboVatStatus.Text.Trim())
                    cmd.Parameters.AddWithValue("@MOP", cboModeOfPayment.Text.Trim())
                    cmd.Parameters.AddWithValue("@BANK", cboBank.Text.Trim())
                    cmd.Parameters.AddWithValue("@ACC", txtBankAccount.Text.Trim())
                    cmd.Parameters.AddWithValue("@TERMS", cboPaymentTerms.Text.Trim())
                    cmd.Parameters.AddWithValue("@PHOTO", If(currentPhoto IsNot Nothing, DirectCast(currentPhoto, Object), DBNull.Value))
                    cmd.ExecuteNonQuery()
                End Using

                SelectedVendorCode = newVendorCode
                MessageBox.Show("Vendor updated successfully!")
            End Using
        Catch ex As Exception
            MessageBox.Show("Update Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ans = MessageBox.Show("Delete this vendor and all its products?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ans <> DialogResult.Yes Then Return

        Dim currentCode As String = txtVendorCode.Text.Trim()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using cmdDelInv As New MySqlCommand("DELETE FROM `Vendor_Products` WHERE TRIM(UPPER(`VENDOR_CODE`)) = UPPER(@VC)", conn)
                    cmdDelInv.Parameters.AddWithValue("@VC", currentCode)
                    cmdDelInv.ExecuteNonQuery()
                End Using
                Using cmdDelVendor As New MySqlCommand("DELETE FROM `vendor` WHERE TRIM(`VENDOR_CODE`) = @VC", conn)
                    cmdDelVendor.Parameters.AddWithValue("@VC", currentCode)
                    cmdDelVendor.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Vendor and all products deleted successfully!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Delete Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSaveExcel_Click(sender As Object, e As EventArgs) Handles btnSaveExcel.Click
        If dgvProducts.Rows.Count = 0 Then
            MessageBox.Show("No products to export!")
            Return
        End If

        Using save As New SaveFileDialog()
            save.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            save.FileName = txtVendor.Text.Replace(" ", "_") & "_ProductList_" & Now.ToString("yyyyMMdd")
            If save.ShowDialog() <> DialogResult.OK Then Return

            Dim oExcel As Excel.Application = Nothing, oWorkBook As Excel.Workbook = Nothing, oWorkSheet As Excel.Worksheet = Nothing
            Try
                oExcel = New Excel.Application() With {.Visible = False, .DisplayAlerts = False}
                oWorkBook = oExcel.Workbooks.Add()
                oWorkSheet = CType(oWorkBook.Sheets(1), Excel.Worksheet)
                oWorkSheet.Name = "Product List"

                oWorkSheet.Cells(1, 1) = txtVendor.Text
                oWorkSheet.Cells(2, 1) = "Vendor Code: " & txtVendorCode.Text
                oWorkSheet.Cells(3, 1) = "Date Generated: " & Now.ToString("MMMM dd, yyyy hh:mm tt")
                With oWorkSheet.Range("A1:G1") : .Merge() : .Font.Size = 16 : .Font.Bold = True : .Font.Color = RGB(25, 60, 120) : .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : End With
                With oWorkSheet.Range("A2:G3") : .Merge() : .Font.Size = 11 : .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : End With

                Dim headerRow As Integer = 5
                oWorkSheet.Cells(headerRow, 1) = "BARCODE"
                oWorkSheet.Cells(headerRow, 2) = "BRAND"
                oWorkSheet.Cells(headerRow, 3) = "DESCRIPTION"
                oWorkSheet.Cells(headerRow, 4) = "CATEGORY"
                oWorkSheet.Cells(headerRow, 5) = "UNIT"
                oWorkSheet.Cells(headerRow, 6) = "SIZE"
                oWorkSheet.Cells(headerRow, 7) = "PRICE"
                With oWorkSheet.Range("A" & headerRow & ":G" & headerRow)
                    .Interior.Color = RGB(25, 60, 120) : .Font.Color = RGB(255, 255, 255) : .Font.Bold = True : .Font.Size = 10
                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous : .Borders.Weight = Excel.XlBorderWeight.xlThin
                End With
                oWorkSheet.Columns("A").NumberFormat = "@" : oWorkSheet.Columns("G").NumberFormat = "#,##0.00"

                Dim currentRow As Integer = headerRow + 1
                For i As Integer = 0 To dgvProducts.Rows.Count - 1
                    oWorkSheet.Cells(currentRow, 1) = "'" & dgvProducts.Rows(i).Cells("BARCODE").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 2) = dgvProducts.Rows(i).Cells("BRAND").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 3) = dgvProducts.Rows(i).Cells("DESCRIPTIONS").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 4) = dgvProducts.Rows(i).Cells("CATEGORY").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 5) = dgvProducts.Rows(i).Cells("UNIT").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 6) = dgvProducts.Rows(i).Cells("SIZE").Value.ToString().Trim()
                    oWorkSheet.Cells(currentRow, 7) = CDec(dgvProducts.Rows(i).Cells("PRICE").Value)
                    With oWorkSheet.Range("A" & currentRow & ":G" & currentRow) : .Borders.LineStyle = Excel.XlLineStyle.xlContinuous : .Borders.Weight = Excel.XlBorderWeight.xlThin : End With
                    currentRow += 1
                Next

                oWorkSheet.Columns("A:G").AutoFit()
                With oWorkSheet.PageSetup
                    .PaperSize = Excel.XlPaperSize.xlPaperA4 : .Orientation = Excel.XlPageOrientation.xlPortrait : .CenterHorizontally = True : .Zoom = 85
                    .LeftMargin = oExcel.InchesToPoints(0.5) : .RightMargin = oExcel.InchesToPoints(0.5)
                    .TopMargin = oExcel.InchesToPoints(0.75) : .BottomMargin = oExcel.InchesToPoints(0.75)
                End With
                oWorkSheet.Columns("A").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                oWorkSheet.Columns("B").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                oWorkSheet.Columns("C").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                oWorkSheet.Columns("D").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                oWorkSheet.Columns("E").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                oWorkSheet.Columns("F").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                oWorkSheet.Columns("G").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

                oWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook)
                MessageBox.Show("Exported successfully!")
            Catch ex As Exception
                MessageBox.Show("Export Error: " & ex.Message)
            Finally
                If oWorkSheet IsNot Nothing Then Marshal.ReleaseComObject(oWorkSheet)
                If oWorkBook IsNot Nothing Then : oWorkBook.Close() : Marshal.ReleaseComObject(oWorkBook) : End If
                If oExcel IsNot Nothing Then : oExcel.Quit() : Marshal.ReleaseComObject(oExcel) : End If
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Using
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvProducts.Rows.Count = 0 Then
            MessageBox.Show("No products to print!")
            Return
        End If

        Dim oExcel As Excel.Application = Nothing, oWorkBook As Excel.Workbook = Nothing, oWorkSheet As Excel.Worksheet = Nothing
        Try
            oExcel = New Excel.Application() With {.Visible = False, .DisplayAlerts = False}
            oWorkBook = oExcel.Workbooks.Add()
            oWorkSheet = CType(oWorkBook.Sheets(1), Excel.Worksheet)

            oWorkSheet.Cells(1, 1) = txtVendor.Text
            oWorkSheet.Cells(2, 1) = "Vendor Code: " & txtVendorCode.Text
            oWorkSheet.Cells(3, 1) = "Date Generated: " & Now.ToString("MMMM dd, yyyy hh:mm tt")
            With oWorkSheet.Range("A1:G1") : .Merge() : .Font.Size = 16 : .Font.Bold = True : .Font.Color = RGB(25, 60, 120) : .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : End With
            With oWorkSheet.Range("A2:G3") : .Merge() : .Font.Size = 11 : .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : End With

            Dim headerRow As Integer = 5
            oWorkSheet.Cells(headerRow, 1) = "BARCODE"
            oWorkSheet.Cells(headerRow, 2) = "BRAND"
            oWorkSheet.Cells(headerRow, 3) = "DESCRIPTION"
            oWorkSheet.Cells(headerRow, 4) = "CATEGORY"
            oWorkSheet.Cells(headerRow, 5) = "UNIT"
            oWorkSheet.Cells(headerRow, 6) = "SIZE"
            oWorkSheet.Cells(headerRow, 7) = "PRICE"
            With oWorkSheet.Range("A" & headerRow & ":G" & headerRow)
                .Interior.Color = RGB(25, 60, 120) : .Font.Color = RGB(255, 255, 255) : .Font.Bold = True : .Font.Size = 10
                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter : .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                .Borders.LineStyle = Excel.XlLineStyle.xlContinuous : .Borders.Weight = Excel.XlBorderWeight.xlThin
            End With
            oWorkSheet.Columns("A").NumberFormat = "@" : oWorkSheet.Columns("G").NumberFormat = "#,##0.00"

            Dim currentRow As Integer = headerRow + 1
            For i As Integer = 0 To dgvProducts.Rows.Count - 1
                oWorkSheet.Cells(currentRow, 1) = "'" & dgvProducts.Rows(i).Cells("BARCODE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 2) = dgvProducts.Rows(i).Cells("BRAND").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 3) = dgvProducts.Rows(i).Cells("DESCRIPTIONS").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 4) = dgvProducts.Rows(i).Cells("CATEGORY").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 5) = dgvProducts.Rows(i).Cells("UNIT").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 6) = dgvProducts.Rows(i).Cells("SIZE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 7) = CDec(dgvProducts.Rows(i).Cells("PRICE").Value)
                With oWorkSheet.Range("A" & currentRow & ":G" & currentRow) : .Borders.LineStyle = Excel.XlLineStyle.xlContinuous : .Borders.Weight = Excel.XlBorderWeight.xlThin : End With
                currentRow += 1
            Next

            oWorkSheet.Columns("A:G").AutoFit()
            With oWorkSheet.PageSetup
                .PaperSize = Excel.XlPaperSize.xlPaperA4 : .Orientation = Excel.XlPageOrientation.xlPortrait : .CenterHorizontally = True : .Zoom = 85
                .LeftMargin = oExcel.InchesToPoints(0.5) : .RightMargin = oExcel.InchesToPoints(0.5)
                .TopMargin = oExcel.InchesToPoints(0.75) : .BottomMargin = oExcel.InchesToPoints(0.75)
            End With

            oWorkSheet.PrintOut()
            MessageBox.Show("Sent to printer successfully!")
        Catch ex As Exception
            MessageBox.Show("Print Error: " & ex.Message)
        Finally
            If oWorkSheet IsNot Nothing Then Marshal.ReleaseComObject(oWorkSheet)
            If oWorkBook IsNot Nothing Then : oWorkBook.Close(SaveChanges:=False) : Marshal.ReleaseComObject(oWorkBook) : End If
            If oExcel IsNot Nothing Then : oExcel.Quit() : Marshal.ReleaseComObject(oExcel) : End If
            GC.Collect() : GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If Not String.IsNullOrWhiteSpace(txtVendorCode.Text) Then LoadVendorInventory(txtSearch.Text.Trim())
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSendToGmail_Click(sender As Object, e As EventArgs) Handles btnSendToGmail.Click
        MessageBox.Show("This feature is not available yet. Coming soon!")
    End Sub

End Class