Imports MySqlConnector
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmBranch_Information

    Private branchData As Dictionary(Of String, String)
    Private branchID As String = ""
    Private connStr As String = DBConnection.connStr
    Private ReadOnly PlaceholderText As String = "Search Product Using Barcode/SKU/Description"

    Public Sub New(branchInfo As Dictionary(Of String, String))
        InitializeComponent()
        branchData = branchInfo
        If branchInfo.ContainsKey("BranchID") Then
            branchID = branchInfo("BranchID")
        End If
    End Sub

    Private Sub frmBranch_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillBranchInfoControls()
        LoadProductListToGrid()
        SetPlaceholder()
    End Sub

    ' ✅ PLACEHOLDER
    Private Sub SetPlaceholder()
        If String.IsNullOrWhiteSpace(txtSearchProduct.Text) Then
            txtSearchProduct.Text = PlaceholderText
            txtSearchProduct.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub

    Private Sub txtSearchProduct_Enter(sender As Object, e As EventArgs) Handles txtSearchProduct.Enter
        If txtSearchProduct.Text = PlaceholderText Then
            txtSearchProduct.Text = ""
            txtSearchProduct.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub txtSearchProduct_Leave(sender As Object, e As EventArgs) Handles txtSearchProduct.Leave
        If String.IsNullOrWhiteSpace(txtSearchProduct.Text) Then
            txtSearchProduct.Text = PlaceholderText
            txtSearchProduct.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub

    ' ✅ Punan ang Branch Info
    Private Sub FillBranchInfoControls()
        If lblBranchName IsNot Nothing Then lblBranchName.Text = branchData("BranchName")
        If lblBranchIDValue IsNot Nothing Then lblBranchIDValue.Text = branchData("BranchID")
        If lblBusinessTypeValue IsNot Nothing Then lblBusinessTypeValue.Text = branchData("BusinessType")
        If lblContactValue IsNot Nothing Then lblContactValue.Text = branchData("Contact")
        If lblManagerValue IsNot Nothing Then lblManagerValue.Text = branchData("Manager")
        If lblEmailValue IsNot Nothing Then lblEmailValue.Text = branchData("Email")
        If lblAddressValue IsNot Nothing Then lblAddressValue.Text = branchData("Address")
    End Sub

    ' ✅ I-LOAD ANG PRODUKTO
    Private Sub LoadProductListToGrid()
        Try
            Dim sql As String = "SELECT `BARCODE`, `BRAND`, `DESCRIPTIONS`, `CATEGORY`, `PRICE`, `AVAILABLE`, `AVAILABILITY`, `UNIT`, `SIZE`, `SKU`, `VENDOR`, `VENDOR_CODE` " &
                                "FROM `inventory_information` " &
                                "WHERE `BRANCH_ID` = @BranchID " &
                                "ORDER BY `BRAND`, `DESCRIPTIONS` ASC"

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BranchID", branchID)
                    Dim dt As New DataTable()
                    Dim da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                    If dgvProductList IsNot Nothing Then
                        dgvProductList.DataSource = dt
                        SetupProductGridHeaders()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SetupProductGridHeaders()
        If dgvProductList Is Nothing Then Return
        If dgvProductList.Columns.Count = 0 Then Return

        dgvProductList.Columns("BARCODE").HeaderText = "Barcode"
        dgvProductList.Columns("BRAND").HeaderText = "Brand"
        dgvProductList.Columns("DESCRIPTIONS").HeaderText = "Description"
        dgvProductList.Columns("CATEGORY").HeaderText = "Category"
        dgvProductList.Columns("PRICE").HeaderText = "Price"
        dgvProductList.Columns("AVAILABLE").HeaderText = "Available Stock"
        dgvProductList.Columns("AVAILABILITY").HeaderText = "Status"
        dgvProductList.Columns("UNIT").HeaderText = "Unit"
        dgvProductList.Columns("SIZE").HeaderText = "Size"
        dgvProductList.Columns("SKU").HeaderText = "SKU"
        dgvProductList.Columns("VENDOR").HeaderText = "Vendor"
        dgvProductList.Columns("VENDOR_CODE").HeaderText = "Vendor Code"
    End Sub

    ' ✅ SEARCH FUNCTION
    Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProduct.TextChanged
        If txtSearchProduct.Text = PlaceholderText Then Return
        If dgvProductList Is Nothing OrElse dgvProductList.DataSource Is Nothing Then Return

        Dim dt As DataTable = CType(dgvProductList.DataSource, DataTable)
        Dim dv As DataView = dt.DefaultView
        Dim keyword As String = txtSearchProduct.Text.Trim.Replace("'", "''")

        If String.IsNullOrWhiteSpace(keyword) Then
            dv.RowFilter = ""
        Else
            dv.RowFilter = $"[BARCODE] LIKE '%{keyword}%' OR [SKU] LIKE '%{keyword}%' OR [DESCRIPTIONS] LIKE '%{keyword}%' OR [BRAND] LIKE '%{keyword}%' OR [CATEGORY] LIKE '%{keyword}%'"
        End If
    End Sub
    Private Function MakeFont(size As Single, isBold As Boolean) As iTextSharp.text.Font
        Dim style As Integer = If(isBold, iTextSharp.text.Font.BOLD, iTextSharp.text.Font.NORMAL)
        ' ✅ HELVETICA = 1 (Direktang numero — WALANG FONTFAMILY!)
        Return New iTextSharp.text.Font(1, size, style, iTextSharp.text.BaseColor.Black)
    End Function

    ' ✅ PRINT BUTTON — GUMAWA NG PDF!
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            ' 📍 I-save sa Desktop
            Dim fileName As String = $"Branch_Info_{branchData("BranchName")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            Dim savePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)

            ' ✅ GUMAGAWA NG PDF — A4 size
            Using fs As New FileStream(savePath, FileMode.Create)
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30, 30, 30, 30)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                doc.Open()

                ' ✅ GUMAMIT NG HELPER FUNCTION — WALANG ERROR!
                Dim fontTitle As iTextSharp.text.Font = MakeFont(16, True)
                Dim fontHeader As iTextSharp.text.Font = MakeFont(11, True)
                Dim fontNormal As iTextSharp.text.Font = MakeFont(10, False)
                Dim fontSmall As iTextSharp.text.Font = MakeFont(8, False)

                ' ✅ TITLE — Branch Name
                Dim pTitle As New iTextSharp.text.Paragraph(branchData("BranchName") & " — Branch Information", fontTitle)
                pTitle.Alignment = iTextSharp.text.Element.ALIGN_CENTER
                doc.Add(pTitle)
                doc.Add(New iTextSharp.text.Paragraph(" "))

                ' ✅ IMPORMASYON NG BRANCH
                Dim infoTable As New iTextSharp.text.pdf.PdfPTable(2)
                infoTable.WidthPercentage = 100
                infoTable.SetWidths(New Single() {1, 2})

                AddInfoRow(infoTable, "Branch ID:", branchData("BranchID"), fontHeader, fontNormal)
                AddInfoRow(infoTable, "Business Type:", branchData("BusinessType"), fontHeader, fontNormal)
                AddInfoRow(infoTable, "Contact:", branchData("Contact"), fontHeader, fontNormal)
                AddInfoRow(infoTable, "Manager:", branchData("Manager"), fontHeader, fontNormal)
                AddInfoRow(infoTable, "Email:", branchData("Email"), fontHeader, fontNormal)
                AddInfoRow(infoTable, "Address:", branchData("Address"), fontHeader, fontNormal)

                doc.Add(infoTable)
                doc.Add(New iTextSharp.text.Paragraph(" "))
                doc.Add(New iTextSharp.text.Paragraph("────────────────────────────────────────────────────", fontNormal))
                doc.Add(New iTextSharp.text.Paragraph("PRODUCT LIST / INVENTORY", fontHeader))
                doc.Add(New iTextSharp.text.Paragraph("────────────────────────────────────────────────────", fontNormal))
                doc.Add(New iTextSharp.text.Paragraph(" "))

                ' ✅ TALAHANAN NG PRODUKTO
                Dim prodTable As New iTextSharp.text.pdf.PdfPTable(6)
                prodTable.WidthPercentage = 100
                prodTable.SetWidths(New Single() {1.2F, 2.5F, 1.5F, 1, 1, 1})

                ' ✅ HEADER
                AddTableHeader(prodTable, "Barcode", fontHeader)
                AddTableHeader(prodTable, "Description", fontHeader)
                AddTableHeader(prodTable, "Category", fontHeader)
                AddTableHeader(prodTable, "Price", fontHeader)
                AddTableHeader(prodTable, "Stock", fontHeader)
                AddTableHeader(prodTable, "Status", fontHeader)

                ' ✅ MGA PRODUKTO
                If dgvProductList.DataSource IsNot Nothing Then
                    Dim dt As DataTable = CType(dgvProductList.DataSource, DataTable)
                    For Each row As DataRow In dt.Rows
                        AddTableRow(prodTable, row("BARCODE").ToString(), fontNormal)
                        AddTableRow(prodTable, row("DESCRIPTIONS").ToString(), fontNormal)
                        AddTableRow(prodTable, row("CATEGORY").ToString(), fontNormal)
                        AddTableRow(prodTable, Convert.ToDecimal(row("PRICE")).ToString("F2"), fontNormal)
                        AddTableRow(prodTable, row("AVAILABLE").ToString(), fontNormal)
                        AddTableRow(prodTable, row("AVAILABILITY").ToString(), fontNormal)
                    Next
                End If

                doc.Add(prodTable)

                ' ✅ PABABA — Petsa at Oras
                doc.Add(New iTextSharp.text.Paragraph(" "))
                doc.Add(New iTextSharp.text.Paragraph(" "))
                Dim pFooter As New iTextSharp.text.Paragraph($"Printed: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", fontSmall)
                pFooter.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
                doc.Add(pFooter)

                doc.Close()
                writer.Close()
            End Using

            ' ✅ MATAGUMPAY — Buksan ang PDF
            MessageBox.Show($"✅ PDF Naigawa na!" & vbCrLf & vbCrLf & $"Lokasyon: {savePath}", "Print Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(savePath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("❌ Error creating PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ TUMUTULONG — Impormasyon
    Private Sub AddInfoRow(table As iTextSharp.text.pdf.PdfPTable, label As String, value As String, fontLabel As iTextSharp.text.Font, fontValue As iTextSharp.text.Font)
        Dim cLabel As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(label, fontLabel))
        cLabel.Border = iTextSharp.text.Rectangle.NO_BORDER
        cLabel.Padding = 4
        table.AddCell(cLabel)

        Dim cValue As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(value, fontValue))
        cValue.Border = iTextSharp.text.Rectangle.NO_BORDER
        cValue.Padding = 4
        table.AddCell(cValue)
    End Sub

    ' ✅ TUMUTULONG — Header
    Private Sub AddTableHeader(table As iTextSharp.text.pdf.PdfPTable, text As String, font As iTextSharp.text.Font)
        Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(text, font))
        cell.BackgroundColor = New iTextSharp.text.BaseColor(211, 211, 211) ' Light Gray
        cell.Padding = 6
        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
        table.AddCell(cell)
    End Sub

    ' ✅ TUMUTULONG — Laman ng Talahanayan
    Private Sub AddTableRow(table As iTextSharp.text.pdf.PdfPTable, text As String, font As iTextSharp.text.Font)
        Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(text, font))
        cell.Padding = 5
        table.AddCell(cell)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class