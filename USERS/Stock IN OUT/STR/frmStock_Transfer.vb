Imports MySqlConnector
Imports System.Text.RegularExpressions
Public Class frmStock_Transfer

    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Dim totalAmount As Decimal = 0

    Private Sub frmStock_Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOrderList.Columns.Clear()

        dgvOrderList.Columns.Add("colBarcode", "Barcode")
        dgvOrderList.Columns.Add("colSKU", "SKU")
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

        ' ✅ MAGLOAD NG LAHAT NG BRANCHES SA DALAWANG COMBOBOX
        LoadBranchList()
        GenerateSTRNumber()
    End Sub

    Private Sub LoadBranchList()
        cboFromBranch.Items.Clear()
        cboToBranch.Items.Clear()

        Dim userAccountId As String = DBConnection.CurrentUserAccountID.Trim()

        If String.IsNullOrWhiteSpace(userAccountId) Then
            MessageBox.Show("Walang laman ang Account ID! Siguraduhin na naiset ito sa Login.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT DISTINCT `BRANCH` AS BRANCH_NAME, BRANCH_ID FROM branches WHERE ACCOUNT_ID = @ACCOUNT_ID ORDER BY `BRANCH`"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ACCOUNT_ID", userAccountId)

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim branchName = dr("BRANCH_NAME").ToString().Trim()
                            Dim branchId = dr("BRANCH_ID").ToString().Trim()
                            Dim item = New KeyValuePair(Of String, String)(branchName, branchId)
                            cboFromBranch.Items.Add(item)
                            cboToBranch.Items.Add(item)
                        End While
                    End Using
                End Using
            End Using

            cboFromBranch.DisplayMember = "Key"
            cboFromBranch.ValueMember = "Value"
            cboToBranch.DisplayMember = "Key"
            cboToBranch.ValueMember = "Value"

            ' ✅ DEFAULT — CURRENT BRANCH ANG FROM BRANCH
            Dim myBranchId = DBConnection.CurrentUserBranchID.Trim()
            For i = 0 To cboFromBranch.Items.Count - 1
                Dim item = CType(cboFromBranch.Items(i), KeyValuePair(Of String, String))
                If item.Value.Equals(myBranchId, StringComparison.OrdinalIgnoreCase) Then
                    cboFromBranch.SelectedIndex = i
                    Exit For
                End If
            Next

            If cboToBranch.Items.Count > 0 Then
                If cboToBranch.SelectedIndex = -1 OrElse cboToBranch.SelectedIndex = cboFromBranch.SelectedIndex Then
                    If cboToBranch.Items.Count > 1 Then
                        cboToBranch.SelectedIndex = 0
                        If cboToBranch.SelectedIndex = cboFromBranch.SelectedIndex Then
                            cboToBranch.SelectedIndex = 1
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvOrderList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.ColumnIndex = dgvOrderList.Columns("colQty").Index AndAlso e.RowIndex >= 0 Then
            e.PaintBackground(e.CellBounds, True)
            e.PaintContent(e.CellBounds)
            e.Graphics.DrawRectangle(Pens.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1)
            e.Handled = True
        End If
    End Sub

    Private Sub GenerateSTRNumber()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT IFNULL(CONCAT('STR-', DATE_FORMAT(NOW(), '%Y%m%d'), LPAD(MAX(CAST(RIGHT(STR_NUMBER, 4) AS UNSIGNED)) + 1, 4, '0')), CONCAT('STR-', DATE_FORMAT(NOW(), '%Y%m%d'), '0001')) FROM transfer_data"
                Dim cmd As New MySqlCommand(sql, conn)
                Dim result = cmd.ExecuteScalar()
                lblSTRNumber.Text = If(result IsNot Nothing AndAlso result IsNot DBNull.Value, result.ToString(), "STR-" & DateTime.Now.ToString("yyyyMMdd") & "0001")
            End Using
        Catch
            lblSTRNumber.Text = "STR-" & DateTime.Now.ToString("yyyyMMdd") & "0001"
        End Try
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
                    MessageBox.Show("Quantity cannot be less than 1!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        End If
    End Sub

    Private Sub AddProductToOrder(searchCode As String)
        If String.IsNullOrWhiteSpace(searchCode) Then Exit Sub

        ' ✅ SIGURADUHIN NA NAKAPILI MUNA NG DALAWANG BRANCH
        If cboFromBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Source Branch first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtScan.Focus()
            Return
        End If
        If cboToBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Destination Branch first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtScan.Focus()
            Return
        End If

        Dim fromBranch = CType(cboFromBranch.SelectedItem, KeyValuePair(Of String, String))
        Dim fromBranchName = fromBranch.Key
        Dim fromBranchId = fromBranch.Value

        Dim toBranch = CType(cboToBranch.SelectedItem, KeyValuePair(Of String, String))
        Dim toBranchName = toBranch.Key
        Dim toBranchId = toBranch.Value

        If fromBranchId.Equals(toBranchId, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Cannot transfer to the same branch!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connStr)
            conn.Open()

            ' ✅ KUNIN ANG PRODUKTO MULA SA PINILING FROM BRANCH
            Dim cmdCheckSource As New MySqlCommand("
                SELECT BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, PRICE 
                FROM inventory_information 
                WHERE (BARCODE = @CODE OR SKU = @CODE) AND BRANCH_ID = @FROM_BRANCH
                LIMIT 1", conn)

            cmdCheckSource.Parameters.AddWithValue("@CODE", searchCode)
            cmdCheckSource.Parameters.AddWithValue("@FROM_BRANCH", fromBranchId)

            Using drSource As MySqlDataReader = cmdCheckSource.ExecuteReader()
                If Not drSource.Read() Then
                    MessageBox.Show($"Item does not exist in {fromBranchName}.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim barcode = drSource("BARCODE").ToString()
                Dim sku = drSource("SKU").ToString()
                Dim brand = drSource("BRAND").ToString()
                Dim desc = drSource("DESCRIPTIONS").ToString()
                Dim size = drSource("SIZE").ToString()
                Dim price = Convert.ToDecimal(drSource("PRICE"))

                drSource.Close()

                ' ✅ SURIIN KUNG MAY PRODUKTO SA DESTINATION BRANCH
                Dim cmdCheckDest As New MySqlCommand("
                    SELECT COUNT(*) FROM inventory_information 
                    WHERE BARCODE = @BAR AND BRANCH_ID = @TO_BRANCH", conn)

                cmdCheckDest.Parameters.AddWithValue("@BAR", barcode)
                cmdCheckDest.Parameters.AddWithValue("@TO_BRANCH", toBranchId)

                Dim existsInDest = Convert.ToInt32(cmdCheckDest.ExecuteScalar()) > 0
                If Not existsInDest Then
                    MessageBox.Show($"This product is not carried by {toBranchName}.{vbCrLf}{vbCrLf}Item: {desc} ({sku})", "Product Not Carried", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtScan.Focus()
                    Return
                End If

                ' ✅ KUNG MAY KATULAD NA — DAGDAGAN ANG DAMI
                For Each row As DataGridViewRow In dgvOrderList.Rows
                    If row.Cells("colBarcode").Value.ToString().Equals(barcode, StringComparison.OrdinalIgnoreCase) Then
                        Dim currentQty = Convert.ToInt32(row.Cells("colQty").Value)
                        row.Cells("colQty").Value = currentQty + 1
                        row.Cells("colTotal").Value = (currentQty + 1) * price
                        CalculateTotal()
                        Return
                    End If
                Next

                ' ✅ KUNG BAGO — ILAGAY SA LISTAHAN
                Dim qty As Integer = 1
                Dim lineTotal = price * qty
                dgvOrderList.Rows.Add(barcode, sku, brand, desc, size, qty, price, lineTotal, Nothing)
                CalculateTotal()
            End Using
        End Using
    End Sub

    Private Sub CalculateTotal()
        totalAmount = 0
        For Each row As DataGridViewRow In dgvOrderList.Rows
            totalAmount += Convert.ToDecimal(row.Cells("colTotal").Value)
        Next
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvOrderList.Rows.Count = 0 Then
            MessageBox.Show("No items added to transfer!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboFromBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Source Branch!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboToBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select Destination Branch!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fromBranch = CType(cboFromBranch.SelectedItem, KeyValuePair(Of String, String))
        Dim fromBranchName = fromBranch.Key
        Dim fromBranchId = fromBranch.Value

        Dim toBranch = CType(cboToBranch.SelectedItem, KeyValuePair(Of String, String))
        Dim toBranchName = toBranch.Key
        Dim toBranchId = toBranch.Value

        If fromBranchId.Equals(toBranchId, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Cannot transfer to the same branch!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim strNumber = lblSTRNumber.Text.Trim()
        Dim totalItems = dgvOrderList.Rows.Count
        Dim preparedBy = DBConnection.CurrentLoggedInUser.Trim()
        Dim userAccountId = DBConnection.CurrentUserAccountID.Trim()

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    ' ✅ 1. I-SAVE SA transfer_data TABLE
                    Dim cmdHeader As New MySqlCommand("
                        INSERT INTO transfer_data 
                        (ACCOUNT_ID, APPROVED_BY, DR_NUMBER, FROM_BRANCH, FROM_BRANCH_ID, 
                         PREPARED_BY, RECEIVED_BY, REMARKS, STATUS, STR_NUMBER, 
                         TOTAL_AMOUNT, TOTAL_ITEMS, TO_BRANCH, TO_BRANCH_ID, TRANSFER_DATE)
                        VALUES (@ACCT, NULL, NULL, @FROM_BRANCH_NAME, @FROM_BRANCH_ID, 
                                @PREPARED, NULL, NULL, 'PENDING', @STRNUMBER, 
                                @TOTALAMT, @TOTALITEMS, @TO_BRANCH_NAME, @TO_BRANCH_ID, NOW())", conn, tran)

                    cmdHeader.Parameters.AddWithValue("@ACCT", userAccountId)
                    cmdHeader.Parameters.AddWithValue("@FROM_BRANCH_NAME", fromBranchName)
                    cmdHeader.Parameters.AddWithValue("@FROM_BRANCH_ID", fromBranchId)
                    cmdHeader.Parameters.AddWithValue("@PREPARED", preparedBy)
                    cmdHeader.Parameters.AddWithValue("@STRNUMBER", strNumber)
                    cmdHeader.Parameters.AddWithValue("@TOTALAMT", totalAmount)
                    cmdHeader.Parameters.AddWithValue("@TOTALITEMS", totalItems)
                    cmdHeader.Parameters.AddWithValue("@TO_BRANCH_NAME", toBranchName)
                    cmdHeader.Parameters.AddWithValue("@TO_BRANCH_ID", toBranchId)
                    cmdHeader.ExecuteNonQuery()

                    ' ✅ 2. I-SAVE SA stock_transfer + UPDATE INVENTORY
                    For Each row As DataGridViewRow In dgvOrderList.Rows
                        Dim barcode = row.Cells("colBarcode").Value.ToString()
                        Dim qtyVal = Convert.ToInt32(row.Cells("colQty").Value)
                        Dim lineTotalVal = Convert.ToDecimal(row.Cells("colTotal").Value)

                        ' ✅ I-SAVE ANG PRODUKTO
                        Dim cmdDetail As New MySqlCommand("
                            INSERT INTO stock_transfer 
                            (STR_NUMBER, BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, PRICE, ORDER_QTY, TOTAL, STOCK_IN, STOCK_OUT)
                            VALUES (@STR, @BAR, @SKU, @BRAND, @DESC, @SIZE, @PRICE, @QTY, @LINE_TOTAL, 0, @STOCK_OUT_VAL)", conn, tran)

                        cmdDetail.Parameters.AddWithValue("@STR", strNumber)
                        cmdDetail.Parameters.AddWithValue("@BAR", barcode)
                        cmdDetail.Parameters.AddWithValue("@SKU", row.Cells("colSKU").Value)
                        cmdDetail.Parameters.AddWithValue("@BRAND", row.Cells("colBrand").Value)
                        cmdDetail.Parameters.AddWithValue("@DESC", row.Cells("colDesc").Value)
                        cmdDetail.Parameters.AddWithValue("@SIZE", row.Cells("colSize").Value)
                        cmdDetail.Parameters.AddWithValue("@PRICE", row.Cells("colPrice").Value)
                        cmdDetail.Parameters.AddWithValue("@QTY", qtyVal)
                        cmdDetail.Parameters.AddWithValue("@LINE_TOTAL", lineTotalVal)
                        cmdDetail.Parameters.AddWithValue("@STOCK_OUT_VAL", qtyVal)
                        cmdDetail.ExecuteNonQuery()

                        ' ✅ 3. BAWASAN SA PINANGGALINGANG BRANCH
                        ' ⚠️ PALITAN ANG "AVAILABLE" KUNG IBA ANG PANGALAN NG COLUMN MO
                        Dim cmdUpdateFrom As New MySqlCommand("
                            UPDATE inventory_information 
                            SET AVAILABLE = AVAILABLE - @QTY 
                            WHERE BARCODE = @BARCODE AND BRANCH_ID = @BRANCHID", conn, tran)

                        cmdUpdateFrom.Parameters.AddWithValue("@QTY", qtyVal)
                        cmdUpdateFrom.Parameters.AddWithValue("@BARCODE", barcode)
                        cmdUpdateFrom.Parameters.AddWithValue("@BRANCHID", fromBranchId)
                        cmdUpdateFrom.ExecuteNonQuery()

                        ' ✅ 4. DAGDAGAN SA PINADALHANG BRANCH
                        Dim cmdUpdateTo As New MySqlCommand("
                            UPDATE inventory_information 
                            SET AVAILABLE = AVAILABLE + @QTY 
                            WHERE BARCODE = @BARCODE AND BRANCH_ID = @BRANCHID", conn, tran)

                        cmdUpdateTo.Parameters.AddWithValue("@QTY", qtyVal)
                        cmdUpdateTo.Parameters.AddWithValue("@BARCODE", barcode)
                        cmdUpdateTo.Parameters.AddWithValue("@BRANCHID", toBranchId)
                        cmdUpdateTo.ExecuteNonQuery()
                    Next

                    tran.Commit()
                    MessageBox.Show($"✅ Transfer Saved!{vbCrLf}From: {fromBranchName}{vbCrLf}To: {toBranchName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvOrderList.Rows.Clear()
                    totalAmount = 0
                    GenerateSTRNumber()
                    LoadBranchList() ' ✅ I-REFRESH ANG BRANCH SELECTION

                Catch ex As Exception
                    tran.Rollback()
                    MessageBox.Show("Error: " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class