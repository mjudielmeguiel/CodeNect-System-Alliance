Imports System.Data
Imports MySqlConnector
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Security.Principal
Imports System.Text

Public Class ShelfTag_Printer

    Private connStr As String = DBConnection.connStr

    ' Branch ID ng kasalukuyang naka-login
    Private userBranchID As String = ""

    Private ReadOnly tagWidth_Normal As Single = 92.0F
    Private ReadOnly tagHeight_Normal As Single = 29.0F
    Private ReadOnly tagWidth_Promo As Single = 46.0F
    Private ReadOnly tagHeight_Promo As Single = 14.5F
    Private ReadOnly safeMargin As Single = 2.5F
    Private ReadOnly rightSpace As Single = 3.0F

    Private WithEvents printDoc As New PrintDocument()
    Private tempPrintList As New DataTable()
    Private currentItemIndex As Integer = 0
    Private columnsPerRow As Integer = 2
    Private rowsPerPage As Integer = 8
    Private selectedPrintType As String = "NORMAL"
    Private selectedInputMode As String = "MANUAL"

    Private Sub ShelfTag_Printer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userBranchID = Login.LoggedInBranchID.Trim()

        SetupGrid()
        ClearInputFields()
        rdoShelfTag.Checked = True
        rdoManual.Checked = True
        selectedPrintType = "NORMAL"
        selectedInputMode = "MANUAL"
        AuditLogger.LogAction("OPEN_SHELF_TAG", "ShelfTagPrinter", $"Opened Shelf Tag Printer | Branch: {userBranchID}")
    End Sub

    Public Sub AddFromProductList(barcode As String, sku As String, brand As String, desc As String, size As String, price As Decimal)
        Try
            dgvItems.Rows.Add(
                barcode,
                sku,
                brand,
                desc,
                size,
                price,
                1
            )

            txtBarcode.Text = barcode
            txtQuantity.Text = "1"

            AuditLogger.LogAction("ITEM_ADDED_FROM_LIST", "ShelfTagPrinter", $"From product list | Barcode: {barcode} | SKU: {sku}")
        Catch ex As Exception
            MessageBox.Show("Failed to add product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "ShelfTagPrinter", $"Add from list failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub rdoScan_CheckedChanged(sender As Object, e As EventArgs) Handles rdoScan.CheckedChanged
        If rdoScan.Checked Then
            selectedInputMode = "SCAN"
            txtBarcode.Enabled = True
            txtQuantity.Enabled = False
            txtQuantity.Text = "1"
            btnAdd.Enabled = False
            AuditLogger.LogAction("INPUT_MODE", "ShelfTagPrinter", $"Mode set to SCAN | Branch: {userBranchID}")
        End If
    End Sub

    Private Sub rdoManual_CheckedChanged(sender As Object, e As EventArgs) Handles rdoManual.CheckedChanged
        If rdoManual.Checked Then
            selectedInputMode = "MANUAL"
            txtBarcode.Enabled = True
            txtQuantity.Enabled = True
            btnAdd.Enabled = True
            AuditLogger.LogAction("INPUT_MODE", "ShelfTagPrinter", $"Mode set to MANUAL | Branch: {userBranchID}")
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If selectedInputMode = "SCAN" AndAlso e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            ProcessItemAdd(txtBarcode.Text.Trim(), 1)
        End If
    End Sub

    Private Sub rdoShelfTag_CheckedChanged(sender As Object, e As EventArgs) Handles rdoShelfTag.CheckedChanged
        If rdoShelfTag.Checked Then
            selectedPrintType = "NORMAL"
            columnsPerRow = 2
            rowsPerPage = 8
            AuditLogger.LogAction("PRINT_TYPE", "ShelfTagPrinter", "Print type set to NORMAL")
        End If
    End Sub

    Private Sub rdoBuy1Take1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBuy1Take1.CheckedChanged
        If rdoBuy1Take1.Checked Then
            selectedPrintType = "BUY1TAKE1"
            columnsPerRow = 4
            rowsPerPage = 16
            AuditLogger.LogAction("PRINT_TYPE", "ShelfTagPrinter", "Print type set to BUY1TAKE1")
        End If
    End Sub

    Private Sub rdoPriceUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPriceUpdate.CheckedChanged
        If rdoPriceUpdate.Checked Then
            selectedPrintType = "PRICEUPDATE"
            columnsPerRow = 2
            rowsPerPage = 8
            AuditLogger.LogAction("PRINT_TYPE", "ShelfTagPrinter", "Print type set to PRICEUPDATE")
        End If
    End Sub

    Private Sub rdoDiscount_CheckedChanged(sender As Object, e As EventArgs) Handles rdo10.CheckedChanged, rdo20.CheckedChanged, rdo50.CheckedChanged
        Dim rdo As RadioButton = CType(sender, RadioButton)
        If rdo.Checked Then
            selectedPrintType = rdo.Text
            columnsPerRow = 4
            rowsPerPage = 16
            AuditLogger.LogAction("PRINT_TYPE", "ShelfTagPrinter", $"Print type set to {selectedPrintType}")
        End If
    End Sub

    Private Sub SetupGrid()
        dgvItems.AutoGenerateColumns = False
        dgvItems.AllowUserToAddRows = False
        dgvItems.ReadOnly = False
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItems.Columns.Clear()
        tempPrintList = New DataTable()

        ' Mga column na lang na nasa DataGridView
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "BARCODE", .HeaderText = "BARCODE", .Width = 110, .ReadOnly = True})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "SKU", .HeaderText = "SKU", .Width = 110, .ReadOnly = True})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "BRAND", .HeaderText = "BRAND", .Width = 120, .ReadOnly = True})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "DESCRIPTIONS", .HeaderText = "DESCRIPTION", .Width = 220, .ReadOnly = True})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "SIZE", .HeaderText = "SIZE", .Width = 70, .ReadOnly = True})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "PRICE", .HeaderText = "PRICE", .Width = 80, .ReadOnly = True, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "0.00", .Alignment = DataGridViewContentAlignment.MiddleRight}})
        dgvItems.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "QTY", .HeaderText = "QTY", .Width = 60, .ReadOnly = False, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})

        tempPrintList.Columns.Add("BARCODE", GetType(String))
        tempPrintList.Columns.Add("SKU", GetType(String))
        tempPrintList.Columns.Add("BRAND", GetType(String))
        tempPrintList.Columns.Add("DESCRIPTIONS", GetType(String))
        tempPrintList.Columns.Add("SIZE", GetType(String))
        tempPrintList.Columns.Add("PRICE", GetType(Decimal))
    End Sub

    Private Sub ClearInputFields()
        txtBarcode.Clear()
        txtQuantity.Text = "1"
        txtBarcode.Focus()
    End Sub

    Private Sub ClearAll()
        dgvItems.Rows.Clear()
        tempPrintList.Clear()
        ClearInputFields()
        currentItemIndex = 0
        AuditLogger.LogAction("LIST_CLEARED", "ShelfTagPrinter", "Item list cleared")
    End Sub

    Private Sub ProcessItemAdd(codeInput As String, qtyToAdd As Integer)
        If String.IsNullOrWhiteSpace(codeInput) Then
            MessageBox.Show("Please enter Barcode or SKU!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        If qtyToAdd < 1 Then qtyToAdd = 1

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' Tinanggal na ang PRODUCT_IMAGE sa query
                Dim qry As String = "SELECT `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE` 
                                    FROM `inventory_information` 
                                    WHERE (TRIM(`BARCODE`) = @Code OR TRIM(`SKU`) = @Code)"

                ' Mag-filter lang kung may Branch ID
                If Not String.IsNullOrEmpty(userBranchID) Then
                    qry &= " AND TRIM(`BRANCH_ID`) = @BranchID"
                End If

                Dim cmd As New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@Code", codeInput)
                If Not String.IsNullOrEmpty(userBranchID) Then
                    cmd.Parameters.AddWithValue("@BranchID", userBranchID)
                End If

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        dgvItems.Rows.Add(
                            dr("BARCODE").ToString().Trim(),
                            dr("SKU").ToString().Trim(),
                            dr("BRAND").ToString().Trim(),
                            dr("DESCRIPTIONS").ToString().Trim(),
                            dr("SIZE").ToString().Trim(),
                            Convert.ToDecimal(dr("PRICE")),
                            qtyToAdd
                        )
                        AuditLogger.LogAction("ITEM_ADDED", "ShelfTagPrinter", $"Item added | Barcode: {dr("BARCODE")} | Qty: {qtyToAdd} | Branch: {userBranchID}")
                        ClearInputFields()
                    Else
                        MessageBox.Show("Product not found or not available in your branch!", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        AuditLogger.LogAction("ITEM_NOTFOUND", "ShelfTagPrinter", $"Product not found | Input: {codeInput} | Branch: {userBranchID}")
                        txtBarcode.SelectAll()
                        txtBarcode.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "ShelfTagPrinter", $"Add item failed | Error: {ex.Message} | Branch: {userBranchID}")
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If selectedInputMode <> "MANUAL" Then Exit Sub

        Dim qtyToAdd As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), qtyToAdd) OrElse qtyToAdd < 1 Then
            MessageBox.Show("Enter a valid quantity!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Text = "1"
            txtQuantity.Focus()
            Return
        End If

        ProcessItemAdd(txtBarcode.Text.Trim(), qtyToAdd)
    End Sub

    Private Sub btnRemove_Click_1(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvItems.SelectedRows.Count > 0 Then
            Dim removedCode = dgvItems.SelectedRows(0).Cells("BARCODE").Value.ToString()
            dgvItems.Rows.RemoveAt(dgvItems.SelectedRows(0).Index)
            AuditLogger.LogAction("ITEM_REMOVED", "ShelfTagPrinter", $"Item removed | Barcode: {removedCode} | Branch: {userBranchID}")
        Else
            MessageBox.Show("Select an item to remove!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MessageBox.Show("Clear the entire list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearAll()
        End If
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE_TAG_PRINT", "ShelfTagPrinter", $"Shelf Tag Printer closed | Branch: {userBranchID}")
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvItems.Rows.Count = 0 Then
            MessageBox.Show("No items added!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        tempPrintList.Clear()
        currentItemIndex = 0

        For Each row As DataGridViewRow In dgvItems.Rows
            If row.IsNewRow Then Continue For

            Dim bc = row.Cells("BARCODE").Value.ToString().Trim()
            Dim sku = row.Cells("SKU").Value.ToString().Trim()
            Dim br = row.Cells("BRAND").Value.ToString().Trim()
            Dim ds = row.Cells("DESCRIPTIONS").Value.ToString().Trim()
            Dim sz = row.Cells("SIZE").Value.ToString().Trim()
            Dim pr = Convert.ToDecimal(row.Cells("PRICE").Value)
            Dim qty = CInt(row.Cells("QTY").Value)

            For i As Integer = 1 To qty
                tempPrintList.Rows.Add(bc, sku, br, ds, sz, pr)
            Next
        Next

        Dim pd As New PrintDialog()
        pd.Document = printDoc
        If pd.ShowDialog() = DialogResult.OK Then
            printDoc.Print()
            MessageBox.Show($"Print job sent successfully! Total tags: {tempPrintList.Rows.Count}", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("PRINT_SENT", "ShelfTagPrinter", $"Print job sent | Type: {selectedPrintType} | Tags: {tempPrintList.Rows.Count} | Branch: {userBranchID}")
        End If
    End Sub

    ' --- BARCODE & PRINTING FUNCTIONS (TINANGGAL NA ANG IMAGE PART) ---
    Private Function GetValidBarcodePattern(codeNum As String) As String
        Dim pureNum As String = New String(codeNum.Where(AddressOf Char.IsDigit).ToArray())
        If pureNum.Length = 13 Then Return GenerateEAN13(pureNum)
        If pureNum.Length = 8 Then Return GenerateEAN8(pureNum)
        pureNum = pureNum.PadRight(12, "0"c).Substring(0, 12)
        Dim checkDigit As Integer = CalculateCheckDigit(pureNum)
        Return GenerateEAN13(pureNum & checkDigit.ToString())
    End Function

    Private Function CalculateCheckDigit(num12 As String) As Integer
        Dim sumOdd As Integer = 0, sumEven As Integer = 0
        For i As Integer = 0 To 11
            Dim val As Integer = CInt(num12(i).ToString())
            If i Mod 2 = 0 Then sumOdd += val Else sumEven += val
        Next
        Dim total As Integer = sumOdd + sumEven * 3
        Return (10 - (total Mod 10)) Mod 10
    End Function

    Private ReadOnly leftOdd As String() = {"0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011"}
    Private ReadOnly leftEven As String() = {"0100111", "0110011", "0011011", "0100001", "011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
    Private ReadOnly rightCode As String() = {"1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"}
    Private ReadOnly parityPattern As String() = {"000000", "001011", "001101", "001110", "010011", "011001", "011100", "010101", "010110", "011010"}

    Private Function GenerateEAN13(ean As String) As String
        Dim firstDigit As Integer = CInt(ean(0).ToString())
        Dim parity As String = parityPattern(firstDigit)
        Dim pattern As New StringBuilder("101")
        For i As Integer = 1 To 6
            Dim d As Integer = CInt(ean(i).ToString())
            If parity(i - 1) = "0" Then pattern.Append(leftOdd(d)) Else pattern.Append(leftEven(d))
        Next
        pattern.Append("01010")
        For i As Integer = 7 To 12
            Dim d As Integer = CInt(ean(i).ToString())
            pattern.Append(rightCode(d))
        Next
        pattern.Append("101")
        Return pattern.ToString()
    End Function

    Private Function GenerateEAN8(ean As String) As String
        Dim pattern As New StringBuilder("101")
        For i As Integer = 0 To 3
            pattern.Append(leftOdd(CInt(ean(i).ToString())))
        Next
        pattern.Append("01010")
        For i As Integer = 4 To 7
            pattern.Append(rightCode(CInt(ean(i).ToString())))
        Next
        pattern.Append("101")
        Return pattern.ToString()
    End Function

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Dim g As Graphics = e.Graphics
        g.PageUnit = GraphicsUnit.Millimeter
        g.Clear(Color.White)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim penBorder As New Pen(Color.Black, 0.25F)
        Dim marginLeftPage As Single = 12.0F
        Dim marginTopPage As Single = 8.0F
        Dim printedThisPage As Integer = 0
        Dim tagsPerPage As Integer = columnsPerRow * rowsPerPage
        Dim textFormat As New StringFormat With {.FormatFlags = StringFormatFlags.LineLimit, .Trimming = StringTrimming.Word, .Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
        Dim alignRight As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim currentTagWidth As Single
        Dim currentTagHeight As Single
        Dim isPromoSize As Boolean = (selectedPrintType <> "NORMAL" AndAlso selectedPrintType <> "PRICEUPDATE")
        If isPromoSize Then currentTagWidth = tagWidth_Promo : currentTagHeight = tagHeight_Promo Else currentTagWidth = tagWidth_Normal : currentTagHeight = tagHeight_Normal

        While currentItemIndex < tempPrintList.Rows.Count AndAlso printedThisPage < tagsPerPage
            Dim colPos As Integer = printedThisPage Mod columnsPerRow
            Dim rowPos As Integer = Math.Floor(printedThisPage / columnsPerRow)
            Dim xStart As Single = marginLeftPage + (colPos * currentTagWidth)
            Dim yStart As Single = marginTopPage + (rowPos * currentTagHeight)
            Dim rightLimit As Single = xStart + currentTagWidth - rightSpace
            g.DrawRectangle(penBorder, xStart, yStart, currentTagWidth, currentTagHeight)
            If currentItemIndex >= tempPrintList.Rows.Count Then printedThisPage += 1 : Continue While
            Dim p As DataRow = tempPrintList.Rows(currentItemIndex)

            If Not isPromoSize Then
                Dim fBrand As New Font("Arial", 10, FontStyle.Bold)
                Dim fDesc As New Font("Arial", 8.5, FontStyle.Regular)
                Dim fSize As New Font("Arial", 7, FontStyle.Regular)
                Dim fPriceBig As New Font("Arial", 26, FontStyle.Bold)
                Dim fCent As New Font("Arial", 11, FontStyle.Bold)
                Dim fPc As New Font("Arial", 7, FontStyle.Regular)
                Dim fBarcodeNum As New Font("Arial", 7, FontStyle.Regular)
                Dim fSku As New Font("Arial", 6.5, FontStyle.Regular)

                ' Tinanggal na ang image part
                Dim skuText As String = p("SKU").ToString().Trim()
                g.DrawString(skuText, fSku, Brushes.Black, xStart + safeMargin, yStart + safeMargin)
                Dim textX As Single = xStart + safeMargin
                g.DrawString(p("BRAND").ToString().ToUpper(), fBrand, Brushes.Black, textX, yStart + safeMargin + 2, textFormat)
                g.DrawString(p("DESCRIPTIONS").ToString().ToUpper(), fDesc, Brushes.Black, New RectangleF(textX, yStart + 12, 52, 11), textFormat)
                g.DrawString(p("SIZE").ToString().ToUpper(), fSize, Brushes.Black, textX, yStart + 22, textFormat)
                Dim val As Decimal = CDec(p("PRICE"))
                Dim whole As Integer = CInt(Math.Truncate(val))
                Dim cent As Integer = CInt((val - whole) * 100)
                Dim centStr As String = cent.ToString("00")
                Dim pesoW As SizeF = g.MeasureString("₱", fBrand)
                Dim wholeW As SizeF = g.MeasureString(whole.ToString(), fPriceBig)
                Dim centW As SizeF = g.MeasureString(centStr, fCent)
                Dim totalPresyoW As Single = pesoW.Width + wholeW.Width + centW.Width
                Dim presyoStartX As Single = rightLimit - totalPresyoW
                Dim posX As Single = presyoStartX
                g.DrawString("₱", fBrand, Brushes.Black, posX, yStart + 2)
                posX += pesoW.Width
                g.DrawString(whole.ToString(), fPriceBig, Brushes.Black, posX, yStart)
                posX += wholeW.Width
                g.DrawString(centStr, fCent, Brushes.Black, posX, yStart + 3)
                g.DrawString("/PC", fPc, Brushes.Black, rightLimit, yStart + 9, alignRight)
                Dim bcTextRaw As String = p("BARCODE").ToString().Trim()
                Dim bcPattern As String = GetValidBarcodePattern(bcTextRaw)
                Dim barcodeHeight As Single = 4.5F
                Dim barcodeY As Single = yStart + 15
                Dim maxAvailableWidth As Single = rightLimit - presyoStartX
                Dim barWidth As Single = Math.Min(0.22F, maxAvailableWidth / bcPattern.Length)
                Dim penB As New Pen(Color.Black, barWidth)
                Dim penW As New Pen(Color.White, barWidth)
                Dim currentX As Single = presyoStartX
                For Each bit As Char In bcPattern
                    If bit = "1" Then g.DrawLine(penB, currentX, barcodeY, currentX, barcodeY + barcodeHeight) Else g.DrawLine(penW, currentX, barcodeY, currentX, barcodeY + barcodeHeight)
                    currentX += barWidth
                Next
                Dim pureNumDisplay As String = New String(bcTextRaw.Where(AddressOf Char.IsDigit).ToArray())
                If pureNumDisplay.Length = 12 Then pureNumDisplay &= CalculateCheckDigit(pureNumDisplay).ToString()
                g.DrawString(pureNumDisplay, fBarcodeNum, Brushes.Black, presyoStartX, barcodeY + barcodeHeight + 0.5F)
            Else
                Dim fBrandSmall As New Font("Arial", 7, FontStyle.Bold)
                Dim fPriceSmall As New Font("Arial", 14, FontStyle.Bold)
                Dim fPromoText As New Font("Arial", 6, FontStyle.Bold)
                If selectedPrintType = "BUY1TAKE1" Then
                    g.FillRectangle(Brushes.Red, xStart, yStart, currentTagWidth, 3.5F)
                    g.DrawString("BUY 1 TAKE 1", fPromoText, Brushes.White, xStart + 1, yStart + 0.3F)
                Else
                    g.FillRectangle(Brushes.DarkOrange, xStart, yStart, currentTagWidth, 3.5F)
                    g.DrawString(selectedPrintType, fPromoText, Brushes.White, xStart + 1, yStart + 0.3F)
                End If
                g.DrawString(p("BRAND").ToString().ToUpper(), fBrandSmall, Brushes.Black, xStart + safeMargin, yStart + 4, textFormat)
                g.DrawString(p("DESCRIPTIONS").ToString().ToUpper(), New Font("Arial", 5.5F), Brushes.Black, New RectangleF(xStart + safeMargin, yStart + 7, currentTagWidth - 5, 5), textFormat)
                Dim val As Decimal = CDec(p("PRICE"))
                Dim whole As Integer = CInt(Math.Truncate(val))
                Dim cent As Integer = CInt((val - whole) * 100)
                Dim priceStr As String = "₱" & whole & "." & cent.ToString("00")
                g.DrawString(priceStr, fPriceSmall, Brushes.Black, rightLimit, yStart + 3, alignRight)
                g.DrawString("SKU: " & p("SKU").ToString(), New Font("Arial", 5), Brushes.Gray, xStart + safeMargin, yStart + 11)
            End If
            printedThisPage += 1
            currentItemIndex += 1
        End While
        e.HasMorePages = (currentItemIndex < tempPrintList.Rows.Count)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmProductlistShelftag.Show()
    End Sub
End Class