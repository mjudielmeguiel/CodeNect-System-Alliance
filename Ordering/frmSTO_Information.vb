Imports MySqlConnector

Public Class frmSTO_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadOrderDetails(poNumber As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' --- Load Header Information from STO_DATA ---
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

                            ' Check status and disable controls if already DELIVERED
                            SetControlsEnabled(lblstatus.Text <> "DELIVERED")
                        End If
                    End Using
                End Using

                ' --- Load Stock Ordering Items into DataGridView ---
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

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Enable/disable all controls based on status
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
        Me.Close()
    End Sub

    ' Double Click to Receive Item
    Private Sub dgvItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick
        If lblstatus.Text.Trim() = "DELIVERED" Then
            MessageBox.Show("This order is already DELIVERED. Editing is disabled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            frmAddStock.ShowDialog()

            ' Refresh after receiving
            LoadOrderDetails(lblPONumber.Text)
        End If
    End Sub

    ' Submit Button – Mark as DELIVERED
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If lblstatus.Text.Trim() = "DELIVERED" Then
                MessageBox.Show("This order is already DELIVERED.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If String.IsNullOrWhiteSpace(lblPONumber.Text) Then
                MessageBox.Show("No Order selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtDR.Text.Trim()) Then
                MessageBox.Show("⚠️ Please enter a DR Number first before submitting!", "Missing DR Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDR.Focus()
                Return
            End If

            Dim result = MessageBox.Show("Are you sure you want to mark this Order as DELIVERED? This cannot be undone.",
                                         "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then Return

            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' Update status, DR, and receive date
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

                MessageBox.Show("✅ Order successfully submitted and marked as DELIVERED.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadOrderDetails(lblPONumber.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error submitting Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSTO_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class