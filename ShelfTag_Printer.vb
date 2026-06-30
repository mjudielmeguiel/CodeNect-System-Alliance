Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class ShelfTag_Printer

    ' ===== KONEKSIYON SA DATABASE =====
    Private ReadOnly strConn As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"
    Private conn As New SqlConnection(strConn)

    ' ===== SUKAT NG TAG =====
    ' ✅ ORIHINAL (NORMAL / PRICE UPDATE)
    Private ReadOnly tagWidth_Normal As Single = 92.0F
    Private ReadOnly tagHeight_Normal As Single = 29.0F
    ' ✅ PROMO (BUY 1 TAKE 1 / DISCOUNT) - 1/4 SIZE
    Private ReadOnly tagWidth_Promo As Single = 46.0F  ' Kalahati ng lapad
    Private ReadOnly tagHeight_Promo As Single = 14.5F ' Kalahati ng taas

    Private ReadOnly safeMargin As Single = 2.5F
    Private ReadOnly rightSpace As Single = 3.0F

    ' ===== MGA SETTING SA PAG-I-PRINT =====
    Private WithEvents printDoc As New PrintDocument()
    Private tempPrintList As New DataTable()
    Private currentItemIndex As Integer = 0
    Private columnsPerRow As Integer = 2
    Private rowsPerPage As Integer = 8

    ' ✅ TINUTUKOY KUNG ANONG URI NG PRINT ANG PINILI
    Private selectedPrintType As String = "NORMAL" ' Default

    ' ===== PAGBUKAS NG PROGRAMA =====
    Private Sub ShelfTag_Printer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        ClearInputFields()
        ' ✅ I-SET ANG DEFAULT NA RADIO BUTTON
        rdoShelfTag.Checked = True
        selectedPrintType = "NORMAL"
    End Sub

    ' ✅ PAGBABAGO NG SETTING KAPAG PININDOT ANG RADIO BUTTON
    Private Sub rdoShelfTag_CheckedChanged(sender As Object, e As EventArgs) Handles rdoShelfTag.CheckedChanged
        If rdoShelfTag.Checked Then
            selectedPrintType = "NORMAL"
            columnsPerRow = 2
            rowsPerPage = 8
        End If
    End Sub

    Private Sub rdoBuy1Take1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBuy1Take1.CheckedChanged
        If rdoBuy1Take1.Checked Then
            selectedPrintType = "BUY1TAKE1"
            ' ✅ DAHIL MALIIT, DADAMI ANG ILALAGAY SA ISANG PAHINA
            columnsPerRow = 4
            rowsPerPage = 16
        End If
    End Sub

    Private Sub rdoPriceUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPriceUpdate.CheckedChanged
        If rdoPriceUpdate.Checked Then
            selectedPrintType = "PRICEUPDATE"
            columnsPerRow = 2
            rowsPerPage = 8
        End If
    End Sub

    Private Sub rdo10_CheckedChanged(sender As Object, e As EventArgs) Handles rdo10.CheckedChanged, rdo20.CheckedChanged, rdo50.CheckedChanged
        Dim rdo As RadioButton = CType(sender, RadioButton)
        If rdo.Checked Then
            selectedPrintType = rdo.Text ' "10% OFF", "20% OFF", etc.
            columnsPerRow = 4
            rowsPerPage = 16
        End If
    End Sub

    ' ===== AYOS NG LISTAHAN NG PRODUKTO =====
    Private Sub SetupGrid()
        dgvItems.AutoGenerateColumns = False
        dgvItems.AllowUserToAddRows = False
        dgvItems.ReadOnly = False
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvItems.Columns.Clear()
        tempPrintList = New DataTable()

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
        tempPrintList.Columns.Add("PRODUCT_IMAGE", GetType(Byte()))
    End Sub

    ' ===== LINISIN ANG MGA KAHON =====
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
    End Sub

    ' ===== PAGDAGDAG NG PRODUKTO =====
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtBarcode.Text.Trim()) Then
            MessageBox.Show("Maglagay muna ng Barcode o SKU!", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        Dim qtyToAdd As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), qtyToAdd) OrElse qtyToAdd < 1 Then
            MessageBox.Show("Ilagay ang tamang dami!", "Maling Halaga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Text = "1"
            txtQuantity.Focus()
            Return
        End If

        Try
            conn.Open()
            Dim cmd As New SqlCommand("SELECT BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, PRICE, PRODUCT_IMAGE FROM inv.Inventory_Master_File WHERE RTRIM(LTRIM(BARCODE)) = @Code OR RTRIM(LTRIM(SKU)) = @Code", conn)
            cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = txtBarcode.Text.Trim()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                dgvItems.Rows.Add(dr("BARCODE").ToString().Trim(), dr("SKU").ToString().Trim(), dr("BRAND").ToString().Trim(), dr("DESCRIPTIONS").ToString().Trim(), dr("SIZE").ToString().Trim(), CDec(dr("PRICE")), qtyToAdd)
                ClearInputFields()
            Else
                MessageBox.Show("Hindi natagpuan ang produkto!", "Walang Resulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtBarcode.SelectAll()
                txtBarcode.Focus()
            End If
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("May naging problema: " & ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' ===== PAGTANGGAL NG PRODUKTO =====
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvItems.SelectedRows.Count > 0 Then
            dgvItems.Rows.RemoveAt(dgvItems.SelectedRows(0).Index)
        Else
            MessageBox.Show("Pumili muna ng tatanggalin!", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' ===== PAGLINIS NG LISTAHAN =====
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MessageBox.Show("Burahin ba ang buong listahan?", "Kumpirmasyon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearAll()
        End If
    End Sub

    ' ===== PAGSARA NG PROGRAMA =====
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ===== PAGSIMULA NG PAG-I-PRINT =====
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvItems.Rows.Count = 0 Then
            MessageBox.Show("Walang nakalagay na produkto!", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        tempPrintList.Clear()
        currentItemIndex = 0

        Try
            conn.Open()
            For Each row As DataGridViewRow In dgvItems.Rows
                If row.IsNewRow Then Continue For
                Dim bc = row.Cells("BARCODE").Value.ToString().Trim()
                Dim sku = row.Cells("SKU").Value.ToString().Trim()
                Dim br = row.Cells("BRAND").Value.ToString().Trim()
                Dim ds = row.Cells("DESCRIPTIONS").Value.ToString().Trim()
                Dim sz = row.Cells("SIZE").Value.ToString().Trim()
                Dim pr = CDec(row.Cells("PRICE").Value)
                Dim qt = CInt(row.Cells("QTY").Value)

                Dim imgCmd As New SqlCommand("SELECT PRODUCT_IMAGE FROM inv.Inventory_Master_File WHERE BARCODE=@BC", conn)
                imgCmd.Parameters.Add("@BC", SqlDbType.NVarChar, 50).Value = bc
                Dim imgBytes As Byte() = TryCast(imgCmd.ExecuteScalar(), Byte())

                For i As Integer = 1 To qt
                    tempPrintList.Rows.Add(bc, sku, br, ds, sz, pr, imgBytes)
                Next
            Next

            Dim pd As New PrintDialog()
            pd.Document = printDoc
            If pd.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
                MessageBox.Show("Matagumpay na nai-print!", "Tapos Na", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error sa pag-print: " & ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            ClearAll()
        End Try
    End Sub

    ' ==========================================================
    ' 🎯 BARCODE GENERATOR
    ' ==========================================================
    Private Function GetValidBarcodePattern(codeNum As String) As String
        Dim pureNum As String = New String(codeNum.Where(AddressOf Char.IsDigit).ToArray())

        If pureNum.Length = 13 Then
            Return GenerateEAN13(pureNum)
        End If
        If pureNum.Length = 8 Then
            Return GenerateEAN8(pureNum)
        End If

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
    Private ReadOnly leftEven As String() = {"0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
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

    ' ==========================================================
    ' 🎨 PAGGUHIT NG TAG - MAY BAGONG ANYO DEPENDE SA PINILI
    ' ==========================================================
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

        ' ✅ ITAKDA ANG TAMANG SUKAT BASE SA PINILI
        Dim currentTagWidth As Single
        Dim currentTagHeight As Single
        Dim isPromoSize As Boolean = False

        If selectedPrintType = "NORMAL" OrElse selectedPrintType = "PRICEUPDATE" Then
            currentTagWidth = tagWidth_Normal
            currentTagHeight = tagHeight_Normal
            isPromoSize = False
        Else
            currentTagWidth = tagWidth_Promo
            currentTagHeight = tagHeight_Promo
            isPromoSize = True
        End If

        While currentItemIndex < tempPrintList.Rows.Count AndAlso printedThisPage < tagsPerPage
            Dim colPos As Integer = printedThisPage Mod columnsPerRow
            Dim rowPos As Integer = Math.Floor(printedThisPage / columnsPerRow)

            Dim xStart As Single = marginLeftPage + (colPos * currentTagWidth)
            Dim yStart As Single = marginTopPage + (rowPos * currentTagHeight)
            Dim rightLimit As Single = xStart + currentTagWidth - rightSpace

            g.DrawRectangle(penBorder, xStart, yStart, currentTagWidth, currentTagHeight)
            If currentItemIndex >= tempPrintList.Rows.Count Then printedThisPage += 1 : Continue While

            Dim p As DataRow = tempPrintList.Rows(currentItemIndex)

            ' ==========================================================
            ' 🟢 NORMAL / PRICE UPDATE - ORIHINAL NA LAKI AT DETALYE
            ' ==========================================================
            If Not isPromoSize Then
                ' MGA URI NG SULAT
                Dim fBrand As New Font("Arial", 10, FontStyle.Bold)
                Dim fDesc As New Font("Arial", 8.5, FontStyle.Regular)
                Dim fSize As New Font("Arial", 7, FontStyle.Regular)
                Dim fPriceBig As New Font("Arial", 26, FontStyle.Bold)
                Dim fCent As New Font("Arial", 11, FontStyle.Bold)
                Dim fPc As New Font("Arial", 7, FontStyle.Regular)
                Dim fBarcodeNum As New Font("Arial", 7, FontStyle.Regular)
                Dim fSku As New Font("Arial", 6.5, FontStyle.Regular)

                ' LARAWAN
                Dim imgSize As Single = 18
                If Not IsDBNull(p("PRODUCT_IMAGE")) Then
                    Try
                        Using ms As New MemoryStream(CType(p("PRODUCT_IMAGE"), Byte()))
                            Using img As Image = Image.FromStream(ms)
                                g.DrawImage(img, xStart + safeMargin, yStart + safeMargin, imgSize, imgSize)
                            End Using
                        End Using
                    Catch
                    End Try
                End If
                ' SKU
                Dim skuText As String = p("SKU").ToString().Trim()
                g.DrawString(skuText, fSku, Brushes.Black, xStart + safeMargin, yStart + safeMargin + imgSize + 0.5F)

                ' DETALYE
                Dim textX As Single = xStart + safeMargin + imgSize + 2
                g.DrawString(p("BRAND").ToString().ToUpper(), fBrand, Brushes.Black, textX, yStart + safeMargin, textFormat)
                g.DrawString(p("DESCRIPTIONS").ToString().ToUpper(), fDesc, Brushes.Black, New RectangleF(textX, yStart + 10, 52, 11), textFormat)
                g.DrawString(p("SIZE").ToString().ToUpper(), fSize, Brushes.Black, textX, yStart + 20, textFormat)

                ' PRESYO
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

                ' BARCODE
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
                ' ==========================================================
                ' 🔴 PROMO / DISCOUNT - 1/4 SIZE, NAKA-COMPACT
                ' ==========================================================
                Dim fBrandSmall As New Font("Arial", 7, FontStyle.Bold)
                Dim fPriceSmall As New Font("Arial", 14, FontStyle.Bold)
                Dim fPromoText As New Font("Arial", 6, FontStyle.Bold)

                ' PROMO LABEL
                If selectedPrintType = "BUY1TAKE1" Then
                    ' ✅ BUY 1 TAKE 1 DESIGN
                    g.FillRectangle(Brushes.Red, xStart, yStart, currentTagWidth, 3.5F)
                    g.DrawString("BUY 1 TAKE 1", fPromoText, Brushes.White, xStart + 1, yStart + 0.3F)
                Else
                    ' ✅ DISCOUNT DESIGN (10% - 50%)
                    g.FillRectangle(Brushes.DarkOrange, xStart, yStart, currentTagWidth, 3.5F)
                    g.DrawString(selectedPrintType, fPromoText, Brushes.White, xStart + 1, yStart + 0.3F)
                End If

                ' BRAND & DESCRIPTION
                g.DrawString(p("BRAND").ToString().ToUpper(), fBrandSmall, Brushes.Black, xStart + safeMargin, yStart + 4, textFormat)
                g.DrawString(p("DESCRIPTIONS").ToString().ToUpper(), New Font("Arial", 5.5F), Brushes.Black, New RectangleF(xStart + safeMargin, yStart + 7, currentTagWidth - 5, 5), textFormat)

                ' PRESYO SA KANAN
                Dim val As Decimal = CDec(p("PRICE"))
                Dim whole As Integer = CInt(Math.Truncate(val))
                Dim cent As Integer = CInt((val - whole) * 100)
                Dim priceStr As String = "₱" & whole & "." & cent.ToString("00")

                g.DrawString(priceStr, fPriceSmall, Brushes.Black, rightLimit, yStart + 3, alignRight)

                ' SKU SA BABA
                g.DrawString("SKU: " & p("SKU").ToString(), New Font("Arial", 5), Brushes.Gray, xStart + safeMargin, yStart + 11)

            End If

            printedThisPage += 1
            currentItemIndex += 1
        End While

        e.HasMorePages = (currentItemIndex < tempPrintList.Rows.Count)
    End Sub

End Class