Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class Vendor_Info

    Dim conn As New SqlConnection(connStr)

    Public Property SelectedVendorCode As String = ""
    Private currentPhoto As Byte() = Nothing

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
            Using cmd As New SqlCommand("SELECT *, ISNULL(VENDOR_PHOTO, NULL) AS VENDOR_PHOTO FROM dbo.vendor WHERE RTRIM(LTRIM(VENDOR_CODE)) = @VC", conn)
                cmd.Parameters.Add("@VC", SqlDbType.NVarChar, 10).Value = SelectedVendorCode.Trim()
                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

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
                dr.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Vendor Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub LoadVendorInventory(Optional filter As String = "")
        Dim dt As New System.Data.DataTable()

        Try
            Dim query As String = "SELECT BARCODE, BRAND, DESCRIPTIONS, CATEGORY, UNIT, SIZE, PRICE FROM dbo.Vendor_Products WHERE RTRIM(LTRIM(UPPER(VENDOR_CODE))) = UPPER(@VC)"

            If Not String.IsNullOrEmpty(filter) Then
                query &= " AND (RTRIM(LTRIM(UPPER(BARCODE))) LIKE '%' + UPPER(@Filter) + '%' OR RTRIM(LTRIM(UPPER(BRAND))) LIKE '%' + UPPER(@Filter) + '%' OR RTRIM(LTRIM(UPPER(DESCRIPTIONS))) LIKE '%' + UPPER(@Filter) + '%' OR RTRIM(LTRIM(UPPER(CATEGORY))) LIKE '%' + UPPER(@Filter) + '%')"
            End If

            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.Add("@VC", SqlDbType.NVarChar, 10).Value = txtVendorCode.Text.Trim()
                cmd.Parameters.Add("@Filter", SqlDbType.NVarChar, 255).Value = filter.Trim()

                Using dr As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(dr)
                End Using
            End Using

            dgvProducts.DataSource = dt
            FormatGridColumns()

        Catch ex As Exception
            MessageBox.Show("Inventory Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
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
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Select Vendor Photo"
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.RestoreDirectory = True

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
        If String.IsNullOrWhiteSpace(txtVendor.Text) Or String.IsNullOrWhiteSpace(txtTIN.Text) Or String.IsNullOrWhiteSpace(txtVendorCode.Text) Then
            MessageBox.Show("Vendor Code, Vendor Name and TIN are required!")
            Return
        End If

        Dim ans = MessageBox.Show("Update vendor details? This includes photo and products.", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ans <> DialogResult.Yes Then Return

        Dim oldVendorCode As String = SelectedVendorCode.Trim()
        Dim newVendorCode As String = txtVendorCode.Text.Trim()

        Try
            conn.Open()

            If oldVendorCode.ToUpper() <> newVendorCode.ToUpper() Then
                Using cmdUpdProd As New SqlCommand("UPDATE dbo.Vendor_Products SET VENDOR_CODE = @NewCode WHERE RTRIM(LTRIM(UPPER(VENDOR_CODE))) = UPPER(@OldCode)", conn)
                    cmdUpdProd.Parameters.Add("@NewCode", SqlDbType.NVarChar, 10).Value = newVendorCode
                    cmdUpdProd.Parameters.Add("@OldCode", SqlDbType.NVarChar, 10).Value = oldVendorCode
                    cmdUpdProd.ExecuteNonQuery()
                End Using
            End If

            Using cmd As New SqlCommand("UPDATE dbo.vendor SET VENDOR_CODE = @NewCode, VENDOR = @VENDOR, TIN = @TIN, CONTACT = @CONTACT, EMAIL = @EMAIL, SALES_PERSON = @SALES, BUSINESS_TYPE = @BTYPE, ADDRESS = @ADDRESS, DTI_REG_NUMBER = @DTI, VAT_STATUS = @VAT, MODE_OF_PAYMENT = @MOP, BANK = @BANK, BANK_ACCOUNT_NUMBER = @ACC, PAYMENT_TERMS = @TERMS, VENDOR_PHOTO = @PHOTO WHERE RTRIM(LTRIM(VENDOR_CODE)) = @OldCode", conn)
                cmd.Parameters.Add("@NewCode", SqlDbType.NVarChar, 10).Value = newVendorCode
                cmd.Parameters.Add("@OldCode", SqlDbType.NVarChar, 10).Value = oldVendorCode
                cmd.Parameters.Add("@VENDOR", SqlDbType.NVarChar, 255).Value = txtVendor.Text.Trim()
                cmd.Parameters.Add("@TIN", SqlDbType.NVarChar, 50).Value = txtTIN.Text.Trim()
                cmd.Parameters.Add("@CONTACT", SqlDbType.NVarChar, 100).Value = txtContact.Text.Trim()
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 150).Value = txtEmail.Text.Trim()
                cmd.Parameters.Add("@SALES", SqlDbType.NVarChar, 100).Value = txtSalesPerson.Text.Trim()
                cmd.Parameters.Add("@BTYPE", SqlDbType.NVarChar, 100).Value = cboBusinessType.Text.Trim()
                cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar, 500).Value = txtAddress.Text.Trim()
                cmd.Parameters.Add("@DTI", SqlDbType.NVarChar, 100).Value = txtDTI.Text.Trim()
                cmd.Parameters.Add("@VAT", SqlDbType.NVarChar, 50).Value = cboVatStatus.Text.Trim()
                cmd.Parameters.Add("@MOP", SqlDbType.NVarChar, 50).Value = cboModeOfPayment.Text.Trim()
                cmd.Parameters.Add("@BANK", SqlDbType.NVarChar, 100).Value = cboBank.Text.Trim()
                cmd.Parameters.Add("@ACC", SqlDbType.NVarChar, 100).Value = txtBankAccount.Text.Trim()
                cmd.Parameters.Add("@TERMS", SqlDbType.NVarChar, 100).Value = cboPaymentTerms.Text.Trim()
                cmd.Parameters.Add("@PHOTO", SqlDbType.VarBinary).Value = If(currentPhoto IsNot Nothing, DirectCast(currentPhoto, Object), DBNull.Value)

                cmd.ExecuteNonQuery()
            End Using

            SelectedVendorCode = newVendorCode
            MessageBox.Show("Vendor updated successfully!")

        Catch ex As Exception
            MessageBox.Show("Update Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ans = MessageBox.Show("Delete this vendor and all its products?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ans <> DialogResult.Yes Then Return

        Dim currentCode As String = txtVendorCode.Text.Trim()

        Try
            conn.Open()
            Using cmdDelInv As New SqlCommand("DELETE FROM dbo.Vendor_Products WHERE RTRIM(LTRIM(UPPER(VENDOR_CODE))) = UPPER(@VC)", conn)
                cmdDelInv.Parameters.Add("@VC", SqlDbType.NVarChar, 10).Value = currentCode
                cmdDelInv.ExecuteNonQuery()
            End Using

            Using cmdDelVendor As New SqlCommand("DELETE FROM dbo.vendor WHERE RTRIM(LTRIM(VENDOR_CODE)) = @VC", conn)
                cmdDelVendor.Parameters.Add("@VC", SqlDbType.NVarChar, 10).Value = currentCode
                cmdDelVendor.ExecuteNonQuery()
            End Using

            MessageBox.Show("Vendor and all products deleted successfully!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Delete Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnSaveExcel_Click(sender As Object, e As EventArgs) Handles btnSaveExcel.Click
        If dgvProducts.Rows.Count = 0 Then
            MessageBox.Show("No products to export!")
            Return
        End If

        Dim save As New SaveFileDialog()
        save.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        save.FileName = txtVendor.Text.Replace(" ", "_") & "_ProductList_" & Now.ToString("yyyyMMdd")

        If save.ShowDialog() <> DialogResult.OK Then Return

        Dim oExcel As Application = Nothing
        Dim oWorkBook As Workbook = Nothing
        Dim oWorkSheet As Worksheet = Nothing

        Try
            oExcel = New Application()
            oExcel.Visible = False
            oExcel.DisplayAlerts = False
            oWorkBook = oExcel.Workbooks.Add()
            oWorkSheet = CType(oWorkBook.Sheets(1), Worksheet)
            oWorkSheet.Name = "Product List"

            oWorkSheet.Cells(1, 1) = txtVendor.Text
            oWorkSheet.Cells(2, 1) = "Vendor Code: " & txtVendorCode.Text
            oWorkSheet.Cells(3, 1) = "Date Generated: " & Now.ToString("MMMM dd, yyyy hh:mm tt")

            With oWorkSheet.Range("A1:G1")
                .Merge()
                .Font.Size = 16
                .Font.Bold = True
                .Font.Color = RGB(25, 60, 120)
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
            End With
            With oWorkSheet.Range("A2:G3")
                .Merge()
                .Font.Size = 11
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
            End With

            Dim headerRow As Integer = 5
            oWorkSheet.Cells(headerRow, 1) = "BARCODE"
            oWorkSheet.Cells(headerRow, 2) = "BRAND"
            oWorkSheet.Cells(headerRow, 3) = "DESCRIPTION"
            oWorkSheet.Cells(headerRow, 4) = "CATEGORY"
            oWorkSheet.Cells(headerRow, 5) = "UNIT"
            oWorkSheet.Cells(headerRow, 6) = "SIZE"
            oWorkSheet.Cells(headerRow, 7) = "PRICE"

            With oWorkSheet.Range("A" & headerRow & ":G" & headerRow)
                .Interior.Color = RGB(25, 60, 120)
                .Font.Color = RGB(255, 255, 255)
                .Font.Bold = True
                .Font.Size = 10
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
                .VerticalAlignment = XlVAlign.xlVAlignCenter
                .Borders.LineStyle = XlLineStyle.xlContinuous
                .Borders.Weight = XlBorderWeight.xlThin
            End With

            oWorkSheet.Columns("A").NumberFormat = "@"
            oWorkSheet.Columns("G").NumberFormat = "#,##0.00"

            Dim currentRow As Integer = headerRow + 1
            For i As Integer = 0 To dgvProducts.Rows.Count - 1
                oWorkSheet.Cells(currentRow, 1) = "'" & dgvProducts.Rows(i).Cells("BARCODE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 2) = dgvProducts.Rows(i).Cells("BRAND").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 3) = dgvProducts.Rows(i).Cells("DESCRIPTIONS").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 4) = dgvProducts.Rows(i).Cells("CATEGORY").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 5) = dgvProducts.Rows(i).Cells("UNIT").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 6) = dgvProducts.Rows(i).Cells("SIZE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 7) = CDec(dgvProducts.Rows(i).Cells("PRICE").Value)

                With oWorkSheet.Range("A" & currentRow & ":G" & currentRow)
                    .Borders.LineStyle = XlLineStyle.xlContinuous
                    .Borders.Weight = XlBorderWeight.xlThin
                End With

                currentRow += 1
            Next

            oWorkSheet.Columns("A:G").AutoFit()

            Dim oPageSetup As PageSetup = oWorkSheet.PageSetup
            oPageSetup.PaperSize = XlPaperSize.xlPaperA4
            oPageSetup.Orientation = XlPageOrientation.xlPortrait
            oPageSetup.CenterHorizontally = True
            oPageSetup.Zoom = 85
            oPageSetup.LeftMargin = oExcel.InchesToPoints(0.5)
            oPageSetup.RightMargin = oExcel.InchesToPoints(0.5)
            oPageSetup.TopMargin = oExcel.InchesToPoints(0.75)
            oPageSetup.BottomMargin = oExcel.InchesToPoints(0.75)

            oWorkSheet.Columns("A").HorizontalAlignment = XlHAlign.xlHAlignLeft
            oWorkSheet.Columns("B").HorizontalAlignment = XlHAlign.xlHAlignLeft
            oWorkSheet.Columns("C").HorizontalAlignment = XlHAlign.xlHAlignLeft
            oWorkSheet.Columns("D").HorizontalAlignment = XlHAlign.xlHAlignCenter
            oWorkSheet.Columns("E").HorizontalAlignment = XlHAlign.xlHAlignCenter
            oWorkSheet.Columns("F").HorizontalAlignment = XlHAlign.xlHAlignCenter
            oWorkSheet.Columns("G").HorizontalAlignment = XlHAlign.xlHAlignRight

            oWorkBook.SaveAs(save.FileName, XlFileFormat.xlOpenXMLWorkbook)
            MessageBox.Show("Exported successfully!")

        Catch ex As Exception
            MessageBox.Show("Export Error: " & ex.Message)
        Finally
            If oWorkSheet IsNot Nothing Then Marshal.ReleaseComObject(oWorkSheet)
            If oWorkBook IsNot Nothing Then
                oWorkBook.Close()
                Marshal.ReleaseComObject(oWorkBook)
            End If
            If oExcel IsNot Nothing Then
                oExcel.Quit()
                Marshal.ReleaseComObject(oExcel)
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvProducts.Rows.Count = 0 Then
            MessageBox.Show("No products to print!")
            Return
        End If

        Dim oExcel As Application = Nothing
        Dim oWorkBook As Workbook = Nothing
        Dim oWorkSheet As Worksheet = Nothing

        Try
            oExcel = New Application()
            oExcel.Visible = False
            oExcel.DisplayAlerts = False
            oWorkBook = oExcel.Workbooks.Add()
            oWorkSheet = CType(oWorkBook.Sheets(1), Worksheet)

            oWorkSheet.Cells(1, 1) = txtVendor.Text
            oWorkSheet.Cells(2, 1) = "Vendor Code: " & txtVendorCode.Text
            oWorkSheet.Cells(3, 1) = "Date Generated: " & Now.ToString("MMMM dd, yyyy hh:mm tt")

            With oWorkSheet.Range("A1:G1")
                .Merge()
                .Font.Size = 16
                .Font.Bold = True
                .Font.Color = RGB(25, 60, 120)
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
            End With
            With oWorkSheet.Range("A2:G3")
                .Merge()
                .Font.Size = 11
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
            End With

            Dim headerRow As Integer = 5
            oWorkSheet.Cells(headerRow, 1) = "BARCODE"
            oWorkSheet.Cells(headerRow, 2) = "BRAND"
            oWorkSheet.Cells(headerRow, 3) = "DESCRIPTION"
            oWorkSheet.Cells(headerRow, 4) = "CATEGORY"
            oWorkSheet.Cells(headerRow, 5) = "UNIT"
            oWorkSheet.Cells(headerRow, 6) = "SIZE"
            oWorkSheet.Cells(headerRow, 7) = "PRICE"

            With oWorkSheet.Range("A" & headerRow & ":G" & headerRow)
                .Interior.Color = RGB(25, 60, 120)
                .Font.Color = RGB(255, 255, 255)
                .Font.Bold = True
                .Font.Size = 10
                .HorizontalAlignment = XlHAlign.xlHAlignCenter
                .VerticalAlignment = XlVAlign.xlVAlignCenter
                .Borders.LineStyle = XlLineStyle.xlContinuous
                .Borders.Weight = XlBorderWeight.xlThin
            End With

            oWorkSheet.Columns("A").NumberFormat = "@"
            oWorkSheet.Columns("G").NumberFormat = "#,##0.00"

            Dim currentRow As Integer = headerRow + 1
            For i As Integer = 0 To dgvProducts.Rows.Count - 1
                oWorkSheet.Cells(currentRow, 1) = "'" & dgvProducts.Rows(i).Cells("BARCODE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 2) = dgvProducts.Rows(i).Cells("BRAND").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 3) = dgvProducts.Rows(i).Cells("DESCRIPTIONS").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 4) = dgvProducts.Rows(i).Cells("CATEGORY").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 5) = dgvProducts.Rows(i).Cells("UNIT").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 6) = dgvProducts.Rows(i).Cells("SIZE").Value.ToString().Trim()
                oWorkSheet.Cells(currentRow, 7) = CDec(dgvProducts.Rows(i).Cells("PRICE").Value)

                With oWorkSheet.Range("A" & currentRow & ":G" & currentRow)
                    .Borders.LineStyle = XlLineStyle.xlContinuous
                    .Borders.Weight = XlBorderWeight.xlThin
                End With

                currentRow += 1
            Next

            oWorkSheet.Columns("A:G").AutoFit()

            Dim oPageSetup As PageSetup = oWorkSheet.PageSetup
            oPageSetup.PaperSize = XlPaperSize.xlPaperA4
            oPageSetup.Orientation = XlPageOrientation.xlPortrait
            oPageSetup.CenterHorizontally = True
            oPageSetup.Zoom = 85
            oPageSetup.LeftMargin = oExcel.InchesToPoints(0.5)
            oPageSetup.RightMargin = oExcel.InchesToPoints(0.5)
            oPageSetup.TopMargin = oExcel.InchesToPoints(0.75)
            oPageSetup.BottomMargin = oExcel.InchesToPoints(0.75)

            oWorkSheet.PrintOut()
            MessageBox.Show("Sent to printer successfully!")

        Catch ex As Exception
            MessageBox.Show("Print Error: " & ex.Message)
        Finally
            If oWorkSheet IsNot Nothing Then Marshal.ReleaseComObject(oWorkSheet)
            If oWorkBook IsNot Nothing Then
                oWorkBook.Close(SaveChanges:=False)
                Marshal.ReleaseComObject(oWorkBook)
            End If
            If oExcel IsNot Nothing Then
                oExcel.Quit()
                Marshal.ReleaseComObject(oExcel)
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If Not String.IsNullOrWhiteSpace(txtVendorCode.Text) Then
            LoadVendorInventory(txtSearch.Text.Trim())
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSendToGmail_Click(sender As Object, e As EventArgs) Handles btnSendToGmail.Click
        MessageBox.Show("This feature is not available yet. Coming soon!")
    End Sub

End Class