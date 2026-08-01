Imports System.Data
Imports MySqlConnector

Public Class Stock_Transfer

    Private connStr As String = DBConnection.connStr
    Private strNumber As String = ""

    Private Sub Stock_Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateSTRNumber()
        SetupGrid()
        LoadBranchList()
        AuditLogger.LogAction("OPEN_ST", "StockTransfer", "Opened Stock Transfer form")
    End Sub

    Private Sub GenerateSTRNumber()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT IFNULL(MAX(`STR_NUMBER`), '000000') FROM `STR_DATA`", conn)
                Dim lastNo As String = cmd.ExecuteScalar().ToString().Trim()
                Dim lastNum As Integer = CInt(lastNo)
                Dim newNum As Integer = lastNum + 1
                strNumber = newNum.ToString("D6")
                lblSTRNumber.Text = strNumber
                lblstatus.Text = "PENDING"
                lbltotal.Text = "0.00"
                AuditLogger.LogAction("STR_GEN", "StockTransfer", $"New STR generated: {strNumber}")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "StockTransfer", $"Generate STR failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub SetupGrid()
        dgvItems.Columns.Clear()
        dgvItems.Columns.Add("BARCODE", "Barcode")
        dgvItems.Columns.Add("SKU", "SKU")
        dgvItems.Columns.Add("BRAND", "Brand")
        dgvItems.Columns.Add("DESCRIPTIONS", "Description")
        dgvItems.Columns.Add("SIZE", "Size")
        dgvItems.Columns.Add("PRICE", "Price")
        dgvItems.Columns.Add("QTY", "Quantity")
        dgvItems.Columns.Add("TOTAL", "Total")
        dgvItems.AllowUserToAddRows = False
        dgvItems.ReadOnly = True
    End Sub

    Private Sub LoadBranchList()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT DISTINCT `BRANCH` FROM `Branches` ORDER BY `BRANCH`", conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                cboToBranch.DataSource = dt
                cboToBranch.DisplayMember = "BRANCH"
                cboToBranch.ValueMember = "BRANCH"
                AuditLogger.LogAction("BRANCH_LOADED", "StockTransfer", "Destination branch list loaded")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "StockTransfer", $"Load branches failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then btnAdd.PerformClick()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim barcode As String = txtBarcode.Text.Trim()
        Dim qtyText As String = txtQty.Text.Trim()

        If barcode = "" Then
            MessageBox.Show("Enter barcode first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            AuditLogger.LogAction("ADD_FAIL", "StockTransfer", "Add cancelled - empty barcode")
            Return
        End If

        If Not IsNumeric(qtyText) OrElse CInt(qtyText) <= 0 Then
            MessageBox.Show("Enter valid quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Clear()
            txtQty.Focus()
            AuditLogger.LogAction("ADD_FAIL", "StockTransfer", "Add cancelled - invalid quantity")
            Return
        End If

        Dim qty As Integer = CInt(qtyText)

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT `SKU`, `BARCODE`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE` FROM `Inventory_Master_file` WHERE `BARCODE` = @Barcode", conn)
                cmd.Parameters.AddWithValue("@Barcode", barcode)
                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Dim price As Decimal = CDec(dr("PRICE"))
                    Dim lineTotal As Decimal = price * qty
                    dgvItems.Rows.Add(
                        dr("BARCODE").ToString(),
                        dr("SKU").ToString(),
                        dr("BRAND").ToString(),
                        dr("DESCRIPTIONS").ToString(),
                        dr("SIZE").ToString(),
                        price.ToString("N2"),
                        qty,
                        lineTotal.ToString("N2")
                    )
                    CalculateTotal()
                    txtBarcode.Clear()
                    txtQty.Clear()
                    txtBarcode.Focus()
                    AuditLogger.LogAction("ITEM_ADDED", "StockTransfer", $"Item added | Barcode: {barcode} | Qty: {qty}")
                Else
                    MessageBox.Show("Product not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtBarcode.SelectAll()
                    txtBarcode.Focus()
                    AuditLogger.LogAction("ITEM_NOTFOUND", "StockTransfer", $"Product not found | Barcode: {barcode}")
                End If
                dr.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "StockTransfer", $"Add item failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If dgvItems.SelectedRows.Count > 0 Then
            Dim removedBarcode As String = dgvItems.SelectedRows(0).Cells("BARCODE").Value.ToString()
            dgvItems.Rows.Remove(dgvItems.SelectedRows(0))
            CalculateTotal()
            AuditLogger.LogAction("ITEM_REMOVED", "StockTransfer", $"Item removed | Barcode: {removedBarcode}")
        Else
            MessageBox.Show("Select an item to remove", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("REMOVE_FAIL", "StockTransfer", "Remove cancelled - no selection")
        End If
    End Sub

    Private Sub CalculateTotal()
        Dim grandTotal As Decimal = 0
        For Each row As DataGridViewRow In dgvItems.Rows
            grandTotal += CDec(row.Cells("TOTAL").Value)
        Next
        lbltotal.Text = grandTotal.ToString("N2")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvItems.Rows.Count = 0 Then
            MessageBox.Show("No items to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("SAVE_FAIL", "StockTransfer", "Submit cancelled - no items")
            Return
        End If

        If lblFromBranch.Text.Trim() = "" OrElse cboToBranch.Text.Trim() = "" Then
            MessageBox.Show("Fill From and To Branch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("SAVE_FAIL", "StockTransfer", "Submit cancelled - missing branch")
            Return
        End If

        If MessageBox.Show("Save this transfer?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then
            AuditLogger.LogAction("SAVE_CANCEL", "StockTransfer", $"Submit cancelled by user | STR: {strNumber}")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    Dim cmdHeader As New MySqlCommand("
                        INSERT INTO `STR_DATA` 
                        (`STR_NUMBER`, `FROM_MV`, `TO_MV`, `REQUEST_DATE`, `PREPARED_BY`, `TRANSACTION_TYPE`, `STATUS`, `TOTAL`)
                        VALUES (@STR, @From, @To, NOW(), @Prepared, 'STOCK TRANSFER', 'PENDING', @Total)", conn, trans)
                    cmdHeader.Parameters.AddWithValue("@STR", strNumber)
                    cmdHeader.Parameters.AddWithValue("@From", lblFromBranch.Text.Trim())
                    cmdHeader.Parameters.AddWithValue("@To", cboToBranch.Text.Trim())
                    cmdHeader.Parameters.AddWithValue("@Prepared", lblPreparedBy.Text.Trim())
                    cmdHeader.Parameters.AddWithValue("@Total", CDec(lbltotal.Text))
                    cmdHeader.ExecuteNonQuery()

                    Dim cmdDetail As New MySqlCommand("
                        INSERT INTO `Stock_Transfer` 
                        (`STR_NUMBER`, `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `ORDER_QTY`, `STOCK_OUT`, `TOTAL`)
                        VALUES (@STR, @Barcode, @SKU, @Brand, @Desc, @Size, @Price, @Qty, @Qty, @Total)", conn, trans)

                    For Each row As DataGridViewRow In dgvItems.Rows
                        cmdDetail.Parameters.Clear()
                        cmdDetail.Parameters.AddWithValue("@STR", strNumber)
                        cmdDetail.Parameters.AddWithValue("@Barcode", row.Cells("BARCODE").Value)
                        cmdDetail.Parameters.AddWithValue("@SKU", row.Cells("SKU").Value)
                        cmdDetail.Parameters.AddWithValue("@Brand", row.Cells("BRAND").Value)
                        cmdDetail.Parameters.AddWithValue("@Desc", row.Cells("DESCRIPTIONS").Value)
                        cmdDetail.Parameters.AddWithValue("@Size", row.Cells("SIZE").Value)
                        cmdDetail.Parameters.AddWithValue("@Price", CDec(row.Cells("PRICE").Value))
                        cmdDetail.Parameters.AddWithValue("@Qty", CInt(row.Cells("QTY").Value))
                        cmdDetail.Parameters.AddWithValue("@Total", CDec(row.Cells("TOTAL").Value))
                        cmdDetail.ExecuteNonQuery()
                    Next

                    trans.Commit()
                    MessageBox.Show("Transfer saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AuditLogger.LogAction("STR_SAVED", "StockTransfer", $"Transfer saved | STR: {strNumber} | From: {lblFromBranch.Text} | To: {cboToBranch.Text} | Items: {dgvItems.RowCount}")

                    GenerateSTRNumber()
                    dgvItems.Rows.Clear()
                    lblPreparedBy.Text = ""
                    lblFromBranch.Text = ""
                    cboToBranch.SelectedIndex = -1
                    txtBarcode.Focus()

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Save Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    AuditLogger.LogAction("SAVE_ROLLBACK", "StockTransfer", $"Save rolled back | STR: {strNumber} | Error: {ex.Message}")
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "StockTransfer", $"Submit failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE_ST", "StockTransfer", "Stock Transfer form closed")
        Me.Close()
    End Sub
End Class