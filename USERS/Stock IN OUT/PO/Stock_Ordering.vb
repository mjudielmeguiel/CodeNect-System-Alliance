Imports MySqlConnector
Imports System.Text.RegularExpressions

Public Class Stock_Ordering
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Dim totalAmount As Decimal = 0

    Private orderVendorCode As String = Nothing
    Private orderVendorName As String = Nothing
    Private userBranchID As String = Nothing
    Private userAccountID As String = Nothing
    Private userName As String = Nothing

    Private Sub Stock_Ordering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userAccountID = If(DBConnection.CurrentUserAccountID IsNot Nothing, DBConnection.CurrentUserAccountID.Trim(), "")
        userBranchID = If(DBConnection.CurrentUserBranchID IsNot Nothing, DBConnection.CurrentUserBranchID.Trim(), "")
        userName = If(DBConnection.CurrentLoggedInUser IsNot Nothing, DBConnection.CurrentLoggedInUser.Trim(), "")

        dgvOrderList.Columns.Clear()

        dgvOrderList.Columns.Add("colBarcode", "Barcode")
        dgvOrderList.Columns.Add("colBrand", "Brand")
        dgvOrderList.Columns.Add("colDesc", "Description")
        dgvOrderList.Columns.Add("colSize", "Size")

        dgvOrderList.Columns.Add("colQty", "Qty")
        With dgvOrderList.Columns("colQty")
            .ReadOnly = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.BackColor = Color.White
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Width = 60
        End With

        dgvOrderList.Columns.Add("colPrice", "Price")
        dgvOrderList.Columns.Add("colTotal", "Total")

        dgvOrderList.Columns.Add(New DataGridViewButtonColumn() With {
            .Name = "colRemove",
            .Text = "Remove",
            .UseColumnTextForButtonValue = True,
            .Width = 70
        })

        dgvOrderList.ReadOnly = False
        dgvOrderList.AllowUserToAddRows = False
        dgvOrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrderList.RowTemplate.Height = 28
        dgvOrderList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        For Each col As DataGridViewColumn In dgvOrderList.Columns
            If col.Name <> "colQty" AndAlso col.Name <> "colRemove" Then
                col.ReadOnly = True
            End If
        Next

        AddHandler dgvOrderList.CellPainting, AddressOf dgvOrderList_CellPainting

        rdoScan.Checked = True
        rdoManual.Checked = False
        txtScan.Clear()
        txtScan.Focus()
        GeneratePONumber()

        lblVendorName.Text = "Vendor: -"
        lblVendorCode.Text = "Vendor Code: -"
    End Sub

    Private Sub dgvOrderList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim isTargetColumn = e.ColumnIndex = dgvOrderList.Columns("colQty").Index
            Dim isSelectedRow = (e.RowIndex = dgvOrderList.CurrentCell.RowIndex)

            e.PaintBackground(e.CellBounds, True)
            e.PaintContent(e.CellBounds)

            If isTargetColumn AndAlso isSelectedRow Then
                ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Black, 2, ButtonBorderStyle.Solid,
                                        Color.Black, 2, ButtonBorderStyle.Solid,
                                        Color.Black, 2, ButtonBorderStyle.Solid,
                                        Color.Black, 2, ButtonBorderStyle.Solid)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GeneratePONumber()
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT CONCAT('PO-', DATE_FORMAT(NOW(), '%Y%m%d'), LPAD(COALESCE(MAX(RIGHT(PO_NUMBER, 4)), 0)+1,4,'0')) FROM stock_ordering", conn)
            lblPONumber.Text = cmd.ExecuteScalar().ToString()
        End Using
    End Sub

    Private Sub rdoScan_CheckedChanged(sender As Object, e As EventArgs) Handles rdoScan.CheckedChanged, rdoManual.CheckedChanged
        txtScan.Clear()
        txtScan.Focus()
    End Sub

    Private Sub txtScan_TextChanged(sender As Object, e As EventArgs) Handles txtScan.TextChanged
        If rdoScan.Checked AndAlso Not String.IsNullOrWhiteSpace(txtScan.Text) Then
            Dim code = txtScan.Text.Trim()
            txtScan.Clear()
            AddProductToOrder(code)
        End If
    End Sub

    Private Sub txtScan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtScan.KeyPress
        If rdoManual.Checked AndAlso e.KeyChar = ChrW(Keys.Enter) Then
            AddProductToOrder(txtScan.Text.Trim())
            txtScan.Clear()
            txtScan.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvOrderList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvOrderList.EditingControlShowing
        If dgvOrderList.CurrentCell.ColumnIndex = dgvOrderList.Columns("colQty").Index Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf QtyTextBox_KeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf QtyTextBox_KeyPress
        End If
    End Sub

    Private Sub QtyTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvOrderList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderList.CellEndEdit
        If e.ColumnIndex = dgvOrderList.Columns("colQty").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim qty = Convert.ToInt32(dgvOrderList.Rows(e.RowIndex).Cells("colQty").Value)
                Dim price = Convert.ToDecimal(dgvOrderList.Rows(e.RowIndex).Cells("colPrice").Value)

                If qty < 1 Then
                    MessageBox.Show("Quantity cannot be less than 1!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvOrderList.Rows(e.RowIndex).Cells("colQty").Value = 1
                    qty = 1
                End If

                dgvOrderList.Rows(e.RowIndex).Cells("colTotal").Value = qty * price
                CalculateTotal()

            Catch ex As Exception
                MessageBox.Show("Please enter a valid number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvOrderList.CancelEdit()
            End Try
        End If
    End Sub

    Private Sub dgvOrderList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderList.CellContentClick
        If e.ColumnIndex = dgvOrderList.Columns("colRemove").Index AndAlso e.RowIndex >= 0 Then
            dgvOrderList.Rows.RemoveAt(e.RowIndex)
            CalculateTotal()

            If dgvOrderList.Rows.Count = 0 Then
                orderVendorCode = Nothing
                orderVendorName = Nothing
                lblVendorName.Text = "Vendor: -"
                lblVendorCode.Text = "Vendor Code: -"
            End If
        End If
    End Sub

    ' ✅ BARCODE LANG — WALANG SKU!
    Private Sub AddProductToOrder(searchCode As String)
        If String.IsNullOrWhiteSpace(searchCode) Then Exit Sub

        ' ✅ Kung nandoon na — dagdagan na lang ang Qty
        For Each row As DataGridViewRow In dgvOrderList.Rows
            Dim existingBarcode = If(row.Cells("colBarcode").Value IsNot Nothing, row.Cells("colBarcode").Value.ToString(), "")

            If existingBarcode.Equals(searchCode, StringComparison.OrdinalIgnoreCase) Then
                Dim currentQty = Convert.ToInt32(row.Cells("colQty").Value)
                Dim price = Convert.ToDecimal(row.Cells("colPrice").Value)
                row.Cells("colQty").Value = currentQty + 1
                row.Cells("colTotal").Value = (currentQty + 1) * price
                CalculateTotal()
                Exit Sub
            End If
        Next

        ' ✅ KUKUHA SA vendor_products — BARCODE LANG! WALANG SKU!
        Using conn As New MySqlConnection(connStr)
            conn.Open()

            Dim cmd As New MySqlCommand("
                SELECT BARCODE, BRAND, DESCRIPTIONS, SIZE, PRICE, VENDOR_CODE, VENDOR, AVAILABILITY
                FROM vendor_products 
                WHERE BARCODE = @CODE 
                LIMIT 1", conn)

            cmd.Parameters.AddWithValue("@CODE", searchCode)

            Using dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Dim barcode = dr("BARCODE").ToString()
                    Dim brand = dr("BRAND").ToString()
                    Dim desc = dr("DESCRIPTIONS").ToString()
                    Dim size = dr("SIZE").ToString()
                    Dim price As Decimal = 0

                    If Not IsDBNull(dr("PRICE")) AndAlso dr("PRICE") IsNot Nothing Then
                        price = Convert.ToDecimal(dr("PRICE"))
                    End If

                    Dim itemVendorCode = dr("VENDOR_CODE")?.ToString().Trim()
                    Dim itemVendorName = dr("VENDOR")?.ToString().Trim()

                    ' ✅ I-check kung iisang Vendor lang
                    If orderVendorCode Is Nothing Then
                        orderVendorCode = itemVendorCode
                        orderVendorName = itemVendorName
                        lblVendorName.Text = $"Vendor: {orderVendorName}"
                        lblVendorCode.Text = $"Vendor Code: {orderVendorCode}"
                    Else
                        If Not String.Equals(orderVendorCode, itemVendorCode, StringComparison.OrdinalIgnoreCase) Then
                            MessageBox.Show(
                                $"This product belongs to a different Vendor.{vbCrLf}{vbCrLf}" &
                                $"Order Vendor: {orderVendorName} ({orderVendorCode}){vbCrLf}" &
                                $"Product Vendor: {itemVendorName} ({itemVendorCode})",
                                "Vendor Mismatch",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            )
                            Exit Sub
                        End If
                    End If

                    Dim qty As Integer = 1
                    Dim lineTotal = price * qty

                    ' ✅ I-add — WALANG SKU COLUMN!
                    dgvOrderList.Rows.Add(barcode, brand, desc, size, qty, price, lineTotal, Nothing)
                    CalculateTotal()

                Else
                    MessageBox.Show(
                        $"Item not found in Vendor Products.{vbCrLf}{vbCrLf}Code: {searchCode}",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    )
                End If
            End Using
        End Using
    End Sub

    Private Sub CalculateTotal()
        totalAmount = 0
        For Each row As DataGridViewRow In dgvOrderList.Rows
            If row.Cells("colTotal").Value IsNot Nothing AndAlso Not DBNull.Value.Equals(row.Cells("colTotal").Value) Then
                totalAmount += Convert.ToDecimal(row.Cells("colTotal").Value)
            End If
        Next
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvOrderList.Rows.Count = 0 Then
            MessageBox.Show("No items added to order!", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(userAccountID) OrElse String.IsNullOrWhiteSpace(userBranchID) Then
            MessageBox.Show("Missing account or branch information! Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    For Each row As DataGridViewRow In dgvOrderList.Rows
                        Dim barcodeVal = If(row.Cells("colBarcode").Value IsNot Nothing, row.Cells("colBarcode").Value.ToString(), "")
                        Dim brandVal = If(row.Cells("colBrand").Value IsNot Nothing, row.Cells("colBrand").Value.ToString(), "")
                        Dim descVal = If(row.Cells("colDesc").Value IsNot Nothing, row.Cells("colDesc").Value.ToString(), "")
                        Dim sizeVal = If(row.Cells("colSize").Value IsNot Nothing, row.Cells("colSize").Value.ToString(), "")
                        Dim orderQty = Convert.ToInt32(row.Cells("colQty").Value)
                        Dim priceVal = Convert.ToDecimal(row.Cells("colPrice").Value)
                        Dim lineTotal = Convert.ToDecimal(row.Cells("colTotal").Value)

                        ' ✅ WALANG SKU SA INSERT!
                        Dim cmdItem As New MySqlCommand("
                            INSERT INTO stock_ordering 
                            (PO_NUMBER, ACCOUNT_ID, BRANCH_ID, BARCODE, BRAND, DESCRIPTIONS, SIZE, PRICE, ORDER_QTY, TOTAL, VENDOR_CODE, VENDOR_NAME)
                            VALUES (@PO, @ACCID, @BRANCHID, @BAR, @BRAND, @DESC, @SIZE, @PRICE, @QTY, @LINE_TOTAL, @VENDOR_CODE, @VENDOR_NAME)", conn, tran)

                        cmdItem.Parameters.AddWithValue("@PO", lblPONumber.Text)
                        cmdItem.Parameters.AddWithValue("@ACCID", userAccountID)
                        cmdItem.Parameters.AddWithValue("@BRANCHID", userBranchID)
                        cmdItem.Parameters.AddWithValue("@BAR", barcodeVal)
                        cmdItem.Parameters.AddWithValue("@BRAND", brandVal)
                        cmdItem.Parameters.AddWithValue("@DESC", descVal)
                        cmdItem.Parameters.AddWithValue("@SIZE", sizeVal)
                        cmdItem.Parameters.AddWithValue("@PRICE", priceVal)
                        cmdItem.Parameters.AddWithValue("@QTY", orderQty)
                        cmdItem.Parameters.AddWithValue("@LINE_TOTAL", lineTotal)
                        cmdItem.Parameters.AddWithValue("@VENDOR_CODE", If(String.IsNullOrWhiteSpace(orderVendorCode), DBNull.Value, orderVendorCode))
                        cmdItem.Parameters.AddWithValue("@VENDOR_NAME", If(String.IsNullOrWhiteSpace(orderVendorName), DBNull.Value, orderVendorName))
                        cmdItem.ExecuteNonQuery()
                    Next

                    Dim cmdSummary As New MySqlCommand("
                        INSERT INTO sto_data 
                        (PO_NUMBER, ACCOUNT_ID, BRANCH_ID, PREPARED_BY, REQUEST_DATE, STATUS, TRANSACTION_TYPE, TOTAL, VENDOR_CODE, VENDOR_NAME)
                        VALUES (@PO, @ACCID, @BRANCHID, @PREPARED, NOW(), 'Pending', 'Purchase Order', @GRAND_TOTAL, @VENDOR_CODE, @VENDOR_NAME)", conn, tran)

                    cmdSummary.Parameters.AddWithValue("@PO", lblPONumber.Text)
                    cmdSummary.Parameters.AddWithValue("@ACCID", userAccountID)
                    cmdSummary.Parameters.AddWithValue("@BRANCHID", userBranchID)
                    cmdSummary.Parameters.AddWithValue("@PREPARED", userName)
                    cmdSummary.Parameters.AddWithValue("@GRAND_TOTAL", totalAmount)
                    cmdSummary.Parameters.AddWithValue("@VENDOR_CODE", If(String.IsNullOrWhiteSpace(orderVendorCode), DBNull.Value, orderVendorCode))
                    cmdSummary.Parameters.AddWithValue("@VENDOR_NAME", If(String.IsNullOrWhiteSpace(orderVendorName), DBNull.Value, orderVendorName))
                    cmdSummary.ExecuteNonQuery()

                    tran.Commit()
                    MessageBox.Show("Purchase Order saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvOrderList.Rows.Clear()
                    totalAmount = 0
                    orderVendorCode = Nothing
                    orderVendorName = Nothing
                    lblVendorName.Text = "Vendor: -"
                    lblVendorCode.Text = "Vendor Code: -"
                    GeneratePONumber()

                Catch ex As Exception
                    tran.Rollback()
                    MessageBox.Show("Error: " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class