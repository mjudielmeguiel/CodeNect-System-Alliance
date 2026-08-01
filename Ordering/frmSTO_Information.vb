Imports MySqlConnector

Public Class frmSTO_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadOrderDetails(poNumber As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sqlHeader As String = "SELECT * FROM `STO_DATA` WHERE `PO_NUMBER` = @DocNo"
                Using cmdHeader As New MySqlCommand(sqlHeader, conn)
                    cmdHeader.Parameters.AddWithValue("@DocNo", poNumber)

                    Using dr As MySqlDataReader = cmdHeader.ExecuteReader()
                        If dr.Read() Then
                            lblPONumber.Text = dr("PO_NUMBER").ToString()
                            txtDR.Text = dr("DR").ToString()
                            lblFrom.Text = dr("FROM").ToString()
                            lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                            lblTo.Text = dr("TO").ToString()
                            lblstatus.Text = dr("STATUS").ToString().Trim()
                            lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")

                            SetControlsEnabled(lblstatus.Text <> "DELIVERED")
                        End If
                    End Using
                End Using

                Dim sqlItems As String = "SELECT 
                    `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, 
                    `PRICE`, `ORDER_QTY`, `TOTAL`, `VENDOR_NAME`, `REMARKS` 
                    FROM `Stock_Ordering` 
                    WHERE `PO_NUMBER` = @DocNo"

                Using cmdItems As New MySqlCommand(sqlItems, conn)
                    cmdItems.Parameters.AddWithValue("@DocNo", poNumber)

                    Dim dtItems As New DataTable()
                    Using da As New MySqlDataAdapter(cmdItems)
                        da.Fill(dtItems)
                    End Using

                    dgvItems.DataSource = dtItems
                    FormatGridColumns()
                End Using

                AuditLogger.LogAction("OPEN", "Stock Ordering", $"Loaded Order Details | PO: {poNumber} | Status: {lblstatus.Text}")

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Stock Ordering", $"Failed to load order {poNumber}: {ex.Message}")
        End Try
    End Sub

    Private Sub SetControlsEnabled(enabled As Boolean)
        txtDR.Enabled = enabled
        btnSubmit.Enabled = enabled
        dgvItems.Enabled = enabled
    End Sub

    Private Sub FormatGridColumns()
        With dgvItems
            .Columns("BARCODE").HeaderText = "Barcode"
            .Columns("SKU").HeaderText = "SKU"
            .Columns("BRAND").HeaderText = "Brand"
            .Columns("DESCRIPTIONS").HeaderText = "Description"
            .Columns("SIZE").HeaderText = "Size"
            .Columns("PRICE").HeaderText = "Unit Price"
            .Columns("ORDER_QTY").HeaderText = "Order Qty"
            .Columns("TOTAL").HeaderText = "Line Total"
            .Columns("VENDOR_NAME").HeaderText = "Vendor"
            .Columns("REMARKS").HeaderText = "Remarks"

            .Columns("PRICE").DefaultCellStyle.Format = "N2"
            .Columns("TOTAL").DefaultCellStyle.Format = "N2"
            .AutoResizeColumns()

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE", "Stock Ordering", $"Closed Order Info | PO: {lblPONumber.Text}")
        Me.Close()
    End Sub

    Private Sub dgvItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick
        If lblstatus.Text.Trim() = "DELIVERED" Then
            MessageBox.Show("This order is already DELIVERED. Editing is disabled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("ACCESS_DENIED", "Stock Ordering", $"Attempted to receive item on already delivered PO: {lblPONumber.Text}")
            Return
        End If

        If e.RowIndex >= 0 AndAlso Not dgvItems.Rows(e.RowIndex).IsNewRow Then
            Dim selectedRow As DataGridViewRow = dgvItems.Rows(e.RowIndex)

            Dim frmAddStock As New frmADDStock_QTY()

            With frmAddStock
                .Barcode = If(selectedRow.Cells("BARCODE").Value IsNot DBNull.Value, selectedRow.Cells("BARCODE").Value.ToString(), "")
                .SKU = If(selectedRow.Cells("SKU").Value IsNot DBNull.Value, selectedRow.Cells("SKU").Value.ToString(), "")
                .Brand = If(selectedRow.Cells("BRAND").Value IsNot DBNull.Value, selectedRow.Cells("BRAND").Value.ToString(), "")
                .Description = If(selectedRow.Cells("DESCRIPTIONS").Value IsNot DBNull.Value, selectedRow.Cells("DESCRIPTIONS").Value.ToString(), "")
                .ProductSize = If(selectedRow.Cells("SIZE").Value IsNot DBNull.Value, selectedRow.Cells("SIZE").Value.ToString(), "")
                .UnitPrice = If(selectedRow.Cells("PRICE").Value IsNot DBNull.Value, Convert.ToDecimal(selectedRow.Cells("PRICE").Value), 0D)
                .VendorName = If(selectedRow.Cells("VENDOR_NAME").Value IsNot DBNull.Value, selectedRow.Cells("VENDOR_NAME").Value.ToString(), "")
                .OrderQty = If(selectedRow.Cells("ORDER_QTY").Value IsNot DBNull.Value, Convert.ToInt32(selectedRow.Cells("ORDER_QTY").Value), 0)
                .PONumber = lblPONumber.Text
            End With

            AuditLogger.LogAction("OPEN", "Stock Ordering", $"Opened Receive Item form | PO: {lblPONumber.Text} | SKU: {frmAddStock.SKU}")
            frmAddStock.ShowDialog()

            LoadOrderDetails(lblPONumber.Text)
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If lblstatus.Text.Trim() = "DELIVERED" Then
                MessageBox.Show("This order is already DELIVERED.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("SUBMIT_FAILED", "Stock Ordering", $"Attempted to re-submit delivered PO: {lblPONumber.Text}")
                Return
            End If

            If String.IsNullOrWhiteSpace(lblPONumber.Text) Then
                MessageBox.Show("No Order selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.LogAction("SUBMIT_FAILED", "Stock Ordering", "Submit attempted with no PO selected")
                Return
            End If

            If String.IsNullOrWhiteSpace(txtDR.Text.Trim()) Then
                MessageBox.Show("Please enter a DR Number first before submitting!", "Missing DR Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDR.Focus()
                AuditLogger.LogAction("SUBMIT_FAILED", "Stock Ordering", $"Missing DR Number for PO: {lblPONumber.Text}")
                Return
            End If

            Dim result = MessageBox.Show("Are you sure you want to mark this Order as DELIVERED? This cannot be undone.",
                                         "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then
                AuditLogger.LogAction("CANCEL", "Stock Ordering", $"Cancelled mark-as-delivered for PO: {lblPONumber.Text}")
                Return
            End If

            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sqlUpdate As String = "
                    UPDATE `STO_DATA`
                    SET 
                        `STATUS` = 'DELIVERED',
                        `RECEIVE_DATE` = NOW(),
                        `DR` = @DRNumber
                    WHERE `PO_NUMBER` = @PONumber;
                "

                Using cmd As New MySqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@PONumber", lblPONumber.Text)
                    cmd.Parameters.AddWithValue("@DRNumber", txtDR.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Order successfully submitted and marked as DELIVERED.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("UPDATE", "Stock Ordering", $"Marked PO as DELIVERED | PO: {lblPONumber.Text} | DR: {txtDR.Text.Trim()}")

                LoadOrderDetails(lblPONumber.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error submitting Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Stock Ordering", $"Error marking PO {lblPONumber.Text} as delivered: {ex.Message}")
        End Try
    End Sub

End Class