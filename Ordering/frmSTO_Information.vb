Imports System.Data
Imports System.Data.SqlClient

Public Class frmSTO_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadOrderDetails(poNumber As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' --- Load Header Information from STO_DATA ---
                Dim sqlHeader As String = "SELECT * FROM dbo.STO_DATA WHERE PO_NUMBER = @DocNo"
                Using cmdHeader As New SqlCommand(sqlHeader, conn)
                    cmdHeader.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber

                    Using dr As SqlDataReader = cmdHeader.ExecuteReader()
                        If dr.Read() Then
                            lblPONumber.Text = dr("PO_NUMBER").ToString()
                            txtDR.Text = dr("DR").ToString()
                            lblFrom.Text = dr("FROM").ToString()
                            lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                            lblTo.Text = dr("TO").ToString()
                            lblstatus.Text = dr("STATUS").ToString().Trim()
                            lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")

                            ' ✅ Check status and disable controls if already DELIVERED
                            SetControlsEnabled(lblstatus.Text <> "DELIVERED")
                        End If
                    End Using
                End Using

                ' --- Load Stock Ordering Items into DataGridView ---
                Dim sqlItems As String = "SELECT 
                    BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, 
                    PRICE, ORDER_QTY, TOTAL, VENDOR_NAME, REMARKS 
                    FROM Stock_Ordering 
                    WHERE PO_NUMBER = @DocNo"

                Using cmdItems As New SqlCommand(sqlItems, conn)
                    cmdItems.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber

                    Dim dtItems As New DataTable()
                    Using da As New SqlDataAdapter(cmdItems)
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

    ' --- ✅ New method to enable/disable all controls ---
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

            ' Make the whole row selectable
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' --- Double Click to Receive Item ---
    Private Sub dgvItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick
        ' Only allow double-click if status is not DELIVERED
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

            ' Refresh data after closing the receive form
            LoadOrderDetails(lblPONumber.Text)
        End If
    End Sub

    ' --- ✅ UPDATED SUBMIT BUTTON WITH DR VALIDATION ---
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' Block if already delivered
            If lblstatus.Text.Trim() = "DELIVERED" Then
                MessageBox.Show("This order is already DELIVERED.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Check if PO Number exists
            If String.IsNullOrWhiteSpace(lblPONumber.Text) Then
                MessageBox.Show("No Order selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check if DR Number is empty
            If String.IsNullOrWhiteSpace(txtDR.Text.Trim()) Then
                MessageBox.Show("⚠️ Please enter a DR Number first before submitting!", "Missing DR Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDR.Focus()
                Return
            End If

            Dim result = MessageBox.Show("Are you sure you want to mark this Order as DELIVERED? This cannot be undone.",
                                         "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then Return

            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Update status, DR number and receive date
                Dim sqlUpdate As String = "
                    UPDATE dbo.STO_DATA
                    SET 
                        STATUS = 'DELIVERED',
                        RECEIVE_DATE = GETDATE(),
                        DR = @DRNumber
                    WHERE PO_NUMBER = @PONumber;
                "

                Using cmd As New SqlCommand(sqlUpdate, conn)
                    cmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 15).Value = lblPONumber.Text
                    cmd.Parameters.Add("@DRNumber", SqlDbType.NChar, 20).Value = txtDR.Text.Trim()
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("✅ Order successfully submitted and marked as DELIVERED.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh to show updated status and disable controls
                LoadOrderDetails(lblPONumber.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error submitting Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class