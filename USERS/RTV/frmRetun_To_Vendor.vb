Imports MySqlConnector
Imports System.Text.RegularExpressions

Public Class frmRetun_To_Vendor
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Dim totalAmount As Decimal = 0
    Private returnVendorId As String = Nothing
    Private returnVendorName As String = Nothing
    Private userBranchID As String = Nothing
    Private userAccountID As String = Nothing
    Private userName As String = Nothing

    Private Sub frmRetun_To_Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userAccountID = If(DBConnection.CurrentUserAccountID IsNot Nothing, DBConnection.CurrentUserAccountID.Trim(), "")
        userBranchID = If(DBConnection.CurrentUserBranchID IsNot Nothing, DBConnection.CurrentUserBranchID.Trim(), "")
        userName = If(DBConnection.CurrentLoggedInUser IsNot Nothing, DBConnection.CurrentLoggedInUser.Trim(), "")

        lblVendorName.Text = "Vendor: -"
        lblVendorCode.Text = "Vendor Code: -"

        dgvReturnList.Columns.Clear()
        dgvReturnList.Columns.Add("colBarcode", "Barcode")
        dgvReturnList.Columns.Add("colSKU", "SKU")
        dgvReturnList.Columns.Add("colBrand", "Brand")
        dgvReturnList.Columns.Add("colDesc", "Description")
        dgvReturnList.Columns.Add("colSize", "Size")

        dgvReturnList.Columns.Add("colQty", "Return Qty")
        With dgvReturnList.Columns("colQty")
            .ReadOnly = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.BackColor = Color.LightPink
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Width = 70
        End With

        dgvReturnList.Columns.Add("colPrice", "Price")
        dgvReturnList.Columns.Add("colTotal", "Total")
        dgvReturnList.Columns.Add("colReason", "Reason")

        dgvReturnList.Columns.Add(New DataGridViewButtonColumn() With {
            .Name = "colRemove",
            .Text = "Remove",
            .UseColumnTextForButtonValue = True,
            .Width = 70
        })

        dgvReturnList.ReadOnly = False
        dgvReturnList.AllowUserToAddRows = False
        dgvReturnList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReturnList.RowTemplate.Height = 28
        dgvReturnList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        For Each col As DataGridViewColumn In dgvReturnList.Columns
            If col.Name <> "colQty" AndAlso col.Name <> "colReason" AndAlso col.Name <> "colRemove" Then
                col.ReadOnly = True
            End If
        Next

        AddHandler dgvReturnList.CellPainting, AddressOf dgvReturnList_CellPainting

        rdoScan.Checked = True
        rdoManual.Checked = False
        txtScan.Clear()
        txtScan.Focus()
        GenerateRTVNumber()
    End Sub

    Private Sub dgvReturnList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim isTargetColumn = e.ColumnIndex = dgvReturnList.Columns("colQty").Index
            Dim isSelectedRow = (e.RowIndex = dgvReturnList.CurrentCell.RowIndex)

            e.PaintBackground(e.CellBounds, True)
            e.PaintContent(e.CellBounds)

            If isTargetColumn AndAlso isSelectedRow Then
                ControlPaint.DrawBorder(e.Graphics, e.CellBounds, Color.Red, 2, ButtonBorderStyle.Solid,
                                        Color.Red, 2, ButtonBorderStyle.Solid,
                                        Color.Red, 2, ButtonBorderStyle.Solid,
                                        Color.Red, 2, ButtonBorderStyle.Solid)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GenerateRTVNumber()
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT CONCAT('RTV-', DATE_FORMAT(NOW(), '%Y%m%d'), LPAD(COALESCE(MAX(RIGHT(PO_NUMBER, 4)), 0)+1, 4, '0')) FROM rtv_information", conn)
            lblRTVNumber.Text = cmd.ExecuteScalar()?.ToString()
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
            AddProductToReturn(code)
        End If
    End Sub

    Private Sub txtScan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtScan.KeyPress
        If rdoManual.Checked AndAlso e.KeyChar = ChrW(Keys.Enter) Then
            AddProductToReturn(txtScan.Text.Trim())
            txtScan.Clear()
            txtScan.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvReturnList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvReturnList.EditingControlShowing
        If dgvReturnList.CurrentCell.ColumnIndex = dgvReturnList.Columns("colQty").Index Then
            RemoveHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf QtyTextBox_KeyPress
            AddHandler DirectCast(e.Control, TextBox).KeyPress, AddressOf QtyTextBox_KeyPress
        End If
    End Sub

    Private Sub QtyTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvReturnList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturnList.CellEndEdit
        If e.ColumnIndex = dgvReturnList.Columns("colQty").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim qty = Convert.ToInt32(dgvReturnList.Rows(e.RowIndex).Cells("colQty").Value)
                Dim price = Convert.ToDecimal(dgvReturnList.Rows(e.RowIndex).Cells("colPrice").Value)
                Dim availableStockCell = dgvReturnList.Rows(e.RowIndex).Cells("colAvailable")
                Dim availableStock As Integer = 0
                If availableStockCell.Value IsNot Nothing Then
                    availableStock = Convert.ToInt32(availableStockCell.Value)
                End If

                If qty < 1 Then
                    MessageBox.Show("Return quantity cannot be less than 1!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvReturnList.Rows(e.RowIndex).Cells("colQty").Value = 1
                    qty = 1
                End If

                If qty > availableStock Then
                    MessageBox.Show($"Cannot return more than available stock! Available: {availableStock}", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvReturnList.Rows(e.RowIndex).Cells("colQty").Value = availableStock
                    qty = availableStock
                End If

                dgvReturnList.Rows(e.RowIndex).Cells("colTotal").Value = qty * price
                CalculateTotal()

            Catch ex As Exception
                MessageBox.Show("Please enter a valid number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dgvReturnList.CancelEdit()
            End Try
        End If
    End Sub

    Private Sub dgvReturnList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturnList.CellContentClick
        If e.ColumnIndex = dgvReturnList.Columns("colRemove").Index AndAlso e.RowIndex >= 0 Then
            dgvReturnList.Rows.RemoveAt(e.RowIndex)
            CalculateTotal()

            ' ✅ Kapag walang laman, ibalik sa "Vendor: -"
            If dgvReturnList.Rows.Count = 0 Then
                returnVendorId = Nothing
                returnVendorName = Nothing
                lblVendorName.Text = "Vendor: -"
                lblVendorCode.Text = "Vendor Code: -"
            End If
        End If
    End Sub

    Private Sub AddProductToReturn(searchCode As String)
        If String.IsNullOrWhiteSpace(searchCode) Then Exit Sub

        If String.IsNullOrWhiteSpace(userBranchID) Then
            MessageBox.Show("Branch information not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Kung nadagdag na, dagdagan lang ang quantity
        For Each row As DataGridViewRow In dgvReturnList.Rows
            If row.Cells("colBarcode").Value?.ToString().Equals(searchCode, StringComparison.OrdinalIgnoreCase) Then
                Dim currentQty = Convert.ToInt32(row.Cells("colQty").Value)
                Dim availableStock = Convert.ToInt32(row.Cells("colAvailable").Value)
                Dim price = Convert.ToDecimal(row.Cells("colPrice").Value)

                If currentQty + 1 > availableStock Then
                    MessageBox.Show($"Cannot return more than available stock! Available: {availableStock}", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                row.Cells("colQty").Value = currentQty + 1
                row.Cells("colTotal").Value = (currentQty + 1) * price
                CalculateTotal()
                Exit Sub
            End If
        Next

        ' ✅ HANAPIN ANG PRODUKTO → KUNIN ANG VENDOR INFO → ILAGAY SA LABEL
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("
                SELECT BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, PRICE, VENDOR_CODE, VENDOR, STOCK_IN as AVAILABILITY
                FROM inventory_information 
                WHERE (BARCODE = @CODE OR SKU = @CODE)
                  AND BRANCH_ID = @MY_BRANCH
                LIMIT 1", conn)

            cmd.Parameters.AddWithValue("@CODE", searchCode)
            cmd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)

            Using dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Dim barcode = dr("BARCODE").ToString()
                    Dim sku = dr("SKU").ToString()
                    Dim brand = dr("BRAND").ToString()
                    Dim desc = dr("DESCRIPTIONS").ToString()
                    Dim size = dr("SIZE").ToString()
                    Dim price = Convert.ToDecimal(dr("PRICE"))
                    Dim itemVendorCode = dr("VENDOR_CODE")?.ToString().Trim()
                    Dim itemVendorName = dr("VENDOR")?.ToString().Trim()
                    Dim availableStock = Convert.ToInt32(dr("AVAILABILITY"))

                    If availableStock <= 0 Then
                        MessageBox.Show("This product is OUT OF STOCK. Cannot be returned.", "No Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' ✅ UNANG PRODUKTO → ILABAS AGAD SA LABEL!
                    If returnVendorId Is Nothing Then
                        returnVendorId = itemVendorCode       ' ← I-save ang Vendor Code
                        returnVendorName = itemVendorName     ' ← I-save ang Vendor Name
                        ' ✅ AYAW NG LABELS — AUTOMATIC LALABAS DITO!
                        lblVendorName.Text = $"Vendor: {returnVendorName}"
                        lblVendorCode.Text = $"Vendor Code: {returnVendorId}"
                    Else
                        ' ✅ Iba na Vendor? I-bawal!
                        If Not String.Equals(returnVendorId, itemVendorCode, StringComparison.OrdinalIgnoreCase) Then
                            MessageBox.Show(
                                $"This product belongs to a different Vendor.{vbCrLf}{vbCrLf}" &
                                $"RTV Vendor: {returnVendorName} ({returnVendorId}){vbCrLf}" &
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
                    dgvReturnList.Rows.Add(barcode, sku, brand, desc, size, qty, price, lineTotal, availableStock, "")
                    CalculateTotal()

                Else
                    MessageBox.Show(
                        $"Item not found in your Branch.{vbCrLf}{vbCrLf}" &
                        $"Your Branch: {userBranchID}",
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
        For Each row As DataGridViewRow In dgvReturnList.Rows
            totalAmount += Convert.ToDecimal(row.Cells("colTotal").Value)
        Next
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvReturnList.Rows.Count = 0 Then
            MessageBox.Show("No items added to return!", "Empty Return", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(userAccountID) OrElse String.IsNullOrWhiteSpace(userBranchID) Then
            MessageBox.Show("Missing account or branch information! Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If MessageBox.Show("Confirm Return to Vendor? Stock will be DEDUCTED from Inventory!", "Confirm Submit",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    For Each row As DataGridViewRow In dgvReturnList.Rows
                        Dim barcodeVal = row.Cells("colBarcode").Value.ToString()
                        Dim returnQty = Convert.ToInt32(row.Cells("colQty").Value)
                        Dim priceVal = Convert.ToDecimal(row.Cells("colPrice").Value)
                        Dim lineTotal = Convert.ToDecimal(row.Cells("colTotal").Value)
                        Dim reason = If(row.Cells("colReason").Value IsNot Nothing, row.Cells("colReason").Value.ToString(), "")

                        Dim cmdItem As New MySqlCommand("
                            INSERT INTO rtv_information 
                            (PO_NUMBER, ACCOUNT_ID, BRANCH_ID, BARCODE, BRAND, DESCRIPTIONS, SKU, SIZE, PRICE, ORDER_QTY, RETURN_ITEM, TOTAL, REMARKS, VENDOR_CODE, VENDOR_NAME, STATUS)
                            VALUES (@RTVNO, @ACCID, @BRANCHID, @BAR, @BRAND, @DESC, @SKU, @SIZE, @PRICE, @QTY, @RETURN_QTY, @LINE_TOTAL, @REMARKS, @VENDOR_CODE, @VENDOR_NAME, 'Completed')", conn, tran)

                        cmdItem.Parameters.AddWithValue("@RTVNO", lblRTVNumber.Text)
                        cmdItem.Parameters.AddWithValue("@ACCID", userAccountID)
                        cmdItem.Parameters.AddWithValue("@BRANCHID", userBranchID)
                        cmdItem.Parameters.AddWithValue("@BAR", barcodeVal)
                        cmdItem.Parameters.AddWithValue("@BRAND", row.Cells("colBrand").Value)
                        cmdItem.Parameters.AddWithValue("@DESC", row.Cells("colDesc").Value)
                        cmdItem.Parameters.AddWithValue("@SKU", row.Cells("colSKU").Value)
                        cmdItem.Parameters.AddWithValue("@SIZE", row.Cells("colSize").Value)
                        cmdItem.Parameters.AddWithValue("@PRICE", priceVal)
                        cmdItem.Parameters.AddWithValue("@QTY", returnQty)
                        cmdItem.Parameters.AddWithValue("@RETURN_QTY", returnQty)
                        cmdItem.Parameters.AddWithValue("@LINE_TOTAL", lineTotal)
                        cmdItem.Parameters.AddWithValue("@REMARKS", reason)
                        cmdItem.Parameters.AddWithValue("@VENDOR_CODE", If(String.IsNullOrWhiteSpace(returnVendorId), DBNull.Value, returnVendorId))
                        cmdItem.Parameters.AddWithValue("@VENDOR_NAME", If(String.IsNullOrWhiteSpace(returnVendorName), DBNull.Value, returnVendorName))
                        cmdItem.ExecuteNonQuery()

                        Dim cmdDeduct As New MySqlCommand("
                            UPDATE inventory_information 
                            SET STOCK_IN = STOCK_IN - @QTY 
                            WHERE BARCODE = @BARCODE 
                              AND BRANCH_ID = @BRANCHID
                              AND (STOCK_IN - @QTY) >= 0", conn, tran)

                        cmdDeduct.Parameters.AddWithValue("@QTY", returnQty)
                        cmdDeduct.Parameters.AddWithValue("@BARCODE", barcodeVal)
                        cmdDeduct.Parameters.AddWithValue("@BRANCHID", userBranchID)

                        If cmdDeduct.ExecuteNonQuery() = 0 Then
                            Throw New Exception($"Insufficient stock for item: {barcodeVal}")
                        End If
                    Next

                    tran.Commit()
                    MessageBox.Show("✅ Return to Vendor Saved! Stock has been DEDUCTED from Inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dgvReturnList.Rows.Clear()
                    totalAmount = 0
                    returnVendorId = Nothing
                    returnVendorName = Nothing
                    lblVendorName.Text = "Vendor: -"
                    lblVendorCode.Text = "Vendor Code: -"
                    GenerateRTVNumber()
                Catch ex As Exception
                    tran.Rollback()
                    MessageBox.Show("Error: " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class