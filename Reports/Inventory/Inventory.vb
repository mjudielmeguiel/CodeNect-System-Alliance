Imports System.Data.SqlClient
Imports ClosedXML.Excel

Public Class Inventory

    Private ReadOnly connStr As String = DBConnection.connStr
    Private currentTransID As String = ""
    Private currentBranchID As String = Login.LoggedInBranchID
    Private currentBranchName As String = ""
    Private currentAccountID As String = Login.LoggedInAccountID

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = currentAccountID
        lblStatus.Text = "PENDING"

        GetBranchName()
        GenerateTransactionID()
        SetupDataGridView()

        txtBarcode.Clear()
        txtBarcode.Focus()
        CalculateTotal()
    End Sub

    ' Kumuha ng pangalan ng Branch
    Private Sub GetBranchName()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT BRANCH FROM dbo.Branches WHERE BRANCH_ID = @BranchID", conn)
                cmd.Parameters.AddWithValue("@BranchID", currentBranchID)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    currentBranchName = result.ToString()
                Else
                    currentBranchName = "Unknown Branch"
                End If

                lblBranchName.Text = currentBranchName
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not load branch name: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblBranchName.Text = "Branch: " & currentBranchID
        End Try
    End Sub

    ' Gumawa ng Transaction ID (numero lang, walang "INV")
    Private Sub GenerateTransactionID()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("
                    SELECT ISNULL(MAX(CASE WHEN ISNUMERIC(TRANSACTION_ID) = 1 THEN CAST(TRANSACTION_ID AS INT) 
                                         ELSE CAST(REPLACE(TRANSACTION_ID, 'INV', '') AS INT) END), 0) + 1 
                    FROM dbo.INVENTORY_DATA
                ", conn)

                Dim nextNum As Integer = CInt(cmd.ExecuteScalar())
                currentTransID = nextNum.ToString("D6")
                lblTransactionID.Text = currentTransID
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating Transaction ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            currentTransID = "000001"
            lblTransactionID.Text = currentTransID
        End Try
    End Sub

    Private Sub SetupDataGridView()
        dgvInventory.Columns.Clear()

        dgvInventory.Columns.Add("ID", "ID")
        dgvInventory.Columns.Add("TRANSACTION_ID", "Transaction ID")
        dgvInventory.Columns.Add("ACCOUNT_ID", "Account ID")
        dgvInventory.Columns.Add("BRANCH_ID", "Branch ID")
        dgvInventory.Columns.Add("BARCODE", "Barcode")
        dgvInventory.Columns.Add("SKU", "SKU")
        dgvInventory.Columns.Add("BRAND", "Brand")
        dgvInventory.Columns.Add("DESCRIPTIONS", "Description")
        dgvInventory.Columns.Add("CATEGORY", "Category")
        dgvInventory.Columns.Add("SIZE", "Size")
        dgvInventory.Columns.Add("PRICE", "Unit Price")
        dgvInventory.Columns.Add("UNIT", "Unit")
        dgvInventory.Columns.Add("AVAILABLE", "Available Stock")
        dgvInventory.Columns.Add("QTY", "Quantity")
        dgvInventory.Columns.Add("AMOUNT", "Amount")
        dgvInventory.Columns.Add("ACTUAL_COUNT", "Actual Count")
        dgvInventory.Columns.Add("VENDOR_CODE", "Vendor Code")
        dgvInventory.Columns.Add("VENDOR", "Vendor Name")

        ' Itago ang mga hindi kailangang makita
        dgvInventory.Columns("ID").Visible = False
        dgvInventory.Columns("TRANSACTION_ID").Visible = False
        dgvInventory.Columns("ACCOUNT_ID").Visible = False
        dgvInventory.Columns("BRANCH_ID").Visible = False

        For Each col As DataGridViewColumn In dgvInventory.Columns
            col.ReadOnly = True
        Next
        dgvInventory.Columns("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvInventory.Columns("QTY").DefaultCellStyle.BackColor = Color.LightYellow

        dgvInventory.Columns("AMOUNT").DefaultCellStyle.Format = "N2"
        dgvInventory.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        AddHandler dgvInventory.CellDoubleClick, AddressOf dgvInventory_CellDoubleClick
    End Sub

    Private Sub dgvInventory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            Dim productInfo As String = $"{selectedRow.Cells("BRAND").Value} - {selectedRow.Cells("DESCRIPTIONS").Value}"
            Dim currentQty As Integer = CInt(selectedRow.Cells("QTY").Value)

            Using frmQty As New frmSetQuantity(productInfo, currentQty)
                If frmQty.ShowDialog() = DialogResult.OK Then
                    selectedRow.Cells("QTY").Value = frmQty.NewQuantity
                    Dim price As Decimal = CDec(selectedRow.Cells("PRICE").Value)
                    selectedRow.Cells("AMOUNT").Value = frmQty.NewQuantity * price
                    selectedRow.Cells("ACTUAL_COUNT").Value = frmQty.NewQuantity
                    CalculateTotal()
                End If
            End Using
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        Dim barcode As String = txtBarcode.Text.Trim()
        If barcode.Length >= 5 Then
            SearchAndAddProduct(barcode)
        End If
    End Sub

    Private Sub SearchAndAddProduct(barcode As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT * FROM inv.Inventory_Master_file WHERE BARCODE = @Barcode AND BRANCH_ID = @BranchID", conn)
                cmd.Parameters.AddWithValue("@Barcode", barcode)
                cmd.Parameters.AddWithValue("@BranchID", currentBranchID)

                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                If dt.Rows.Count = 0 Then
                    txtBarcode.Clear()
                    txtBarcode.Focus()
                    Return
                End If

                AddOrUpdateRow(dt.Rows(0))
            End Using
        Catch ex As Exception
            MessageBox.Show("Search Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBarcode.Clear()
            txtBarcode.Focus()
        End Try
    End Sub

    Private Sub AddOrUpdateRow(row As DataRow)
        Dim barcode = row("BARCODE").ToString().Trim()
        Dim existingRow As DataGridViewRow = Nothing

        For Each r As DataGridViewRow In dgvInventory.Rows
            If r.Cells("BARCODE").Value.ToString().Trim() = barcode Then
                existingRow = r
                Exit For
            End If
        Next

        If existingRow IsNot Nothing Then
            Dim newQty As Integer = CInt(existingRow.Cells("QTY").Value) + 1
            Dim price As Decimal = CDec(existingRow.Cells("PRICE").Value)
            existingRow.Cells("QTY").Value = newQty
            existingRow.Cells("AMOUNT").Value = newQty * price
            existingRow.Cells("ACTUAL_COUNT").Value = newQty
        Else
            Dim price As Decimal = CDec(row("PRICE"))
            Dim qty As Integer = 1
            Dim amount As Decimal = qty * price

            dgvInventory.Rows.Add(
                row("ID"), currentTransID, currentAccountID, currentBranchID,
                row("BARCODE"), row("SKU"), row("BRAND"), row("DESCRIPTIONS"),
                row("CATEGORY"), row("SIZE"), price, row("UNIT"),
                row("AVAILABLE"), qty, amount, qty,
                row("VENDOR_CODE"), row("VENDOR")
            )
        End If

        CalculateTotal()
        txtBarcode.Clear()
        txtBarcode.Focus()
    End Sub

    Private Sub CalculateTotal()
        Dim totalValue As Decimal = 0
        For Each row As DataGridViewRow In dgvInventory.Rows
            If Not row.IsNewRow Then
                Dim qty As Integer = CInt(row.Cells("QTY").Value)
                Dim price As Decimal = CDec(row.Cells("PRICE").Value)
                Dim amount As Decimal = qty * price
                row.Cells("AMOUNT").Value = amount
                row.Cells("ACTUAL_COUNT").Value = qty
                totalValue += amount
            End If
        Next
        lblTotal.Text = $"GRAND TOTAL: ₱ {totalValue:N2}"
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If dgvInventory.SelectedRows.Count > 0 Then
            dgvInventory.Rows.Remove(dgvInventory.SelectedRows(0))
            CalculateTotal()
        End If
    End Sub

    ' ✅ Naayos na AVAILABILITY: AVAILABLE / CRITICAL / OUT OF STOCK
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvInventory.Rows.Count = 0 Then
            MessageBox.Show("No items to save.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New SqlConnection(connStr)
            Dim tran As SqlTransaction = Nothing
            Try
                conn.Open()
                tran = conn.BeginTransaction()

                ' Ipasok sa dbo.INVENTORY_DATA
                Dim cmdHeader As New SqlCommand("
                    INSERT INTO dbo.INVENTORY_DATA 
                    (TRANSACTION_ID, ACCOUNT_ID, ACCOUNT, BRANCH_ID, BRANCH, REPORT_DATE, PREPARED_BY, TRANSACTION_TYPE, STATUS, TOTAL)
                    VALUES (@TransID, @AccID, @AccID, @BranchID, @BranchName, GETDATE(), @PreparedBy, 'INVENTORY', 'COMPLETED', @Total)
                ", conn, tran)

                cmdHeader.Parameters.AddWithValue("@TransID", currentTransID)
                cmdHeader.Parameters.AddWithValue("@AccID", currentAccountID)
                cmdHeader.Parameters.AddWithValue("@BranchID", currentBranchID)
                cmdHeader.Parameters.AddWithValue("@BranchName", currentBranchName.Substring(0, Math.Min(currentBranchName.Length, 25)))
                cmdHeader.Parameters.AddWithValue("@PreparedBy", currentAccountID)
                cmdHeader.Parameters.AddWithValue("@Total", CDec(lblTotal.Text.Replace("GRAND TOTAL: ₱ ", "")))
                cmdHeader.ExecuteNonQuery()

                ' Ipasok ang bawat produkto
                For Each row As DataGridViewRow In dgvInventory.Rows
                    If row.IsNewRow Then Continue For

                    Dim qty = CInt(row.Cells("QTY").Value)
                    Dim available = CInt(row.Cells("AVAILABLE").Value)

                    ' ✅ Itakda ang status ng Availability
                    Dim availabilityStatus As String
                    If qty = 0 Then
                        availabilityStatus = "OUT OF STOCK"
                    ElseIf qty <= 10 Then
                        availabilityStatus = "CRITICAL"
                    Else
                        availabilityStatus = "AVAILABLE"
                    End If

                    Dim cmdDetail As New SqlCommand("
                        INSERT INTO dbo.INVENTORY_INFORMATION 
                        (TRANSACTION_ID, ACCOUNT_ID, BRANCH_ID, BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, PRICE, UNIT, AVAILABLE, ACTUAL_COUNT, AVAILABILITY, VENDOR_CODE, VENDOR)
                        VALUES (@TransID, @AccID, @BranchID, @Barcode, @SKU, @Brand, @Desc, @Cat, @Size, @Price, @Unit, @Available, @Actual, @Availability, @VendorCode, @Vendor)
                    ", conn, tran)

                    cmdDetail.Parameters.AddWithValue("@TransID", currentTransID)
                    cmdDetail.Parameters.AddWithValue("@AccID", currentAccountID)
                    cmdDetail.Parameters.AddWithValue("@BranchID", currentBranchID)
                    cmdDetail.Parameters.AddWithValue("@Barcode", row.Cells("BARCODE").Value)
                    cmdDetail.Parameters.AddWithValue("@SKU", row.Cells("SKU").Value)
                    cmdDetail.Parameters.AddWithValue("@Brand", row.Cells("BRAND").Value)
                    cmdDetail.Parameters.AddWithValue("@Desc", row.Cells("DESCRIPTIONS").Value)
                    cmdDetail.Parameters.AddWithValue("@Cat", row.Cells("CATEGORY").Value)
                    cmdDetail.Parameters.AddWithValue("@Size", row.Cells("SIZE").Value)
                    cmdDetail.Parameters.AddWithValue("@Price", row.Cells("PRICE").Value)
                    cmdDetail.Parameters.AddWithValue("@Unit", row.Cells("UNIT").Value)
                    cmdDetail.Parameters.AddWithValue("@Available", available)
                    cmdDetail.Parameters.AddWithValue("@Actual", qty)
                    cmdDetail.Parameters.AddWithValue("@Availability", availabilityStatus) ' ✅ Tamang teksto
                    cmdDetail.Parameters.AddWithValue("@VendorCode", row.Cells("VENDOR_CODE").Value)
                    cmdDetail.Parameters.AddWithValue("@Vendor", row.Cells("VENDOR").Value)
                    cmdDetail.ExecuteNonQuery()

                    ' I-update ang stock
                    Dim cmdUpdateStock As New SqlCommand("
                        UPDATE inv.Inventory_Master_file 
                        SET AVAILABLE = @NewQty, DATE_ADDED = GETDATE()
                        WHERE BARCODE = @Barcode AND BRANCH_ID = @BranchID
                    ", conn, tran)

                    cmdUpdateStock.Parameters.AddWithValue("@NewQty", qty)
                    cmdUpdateStock.Parameters.AddWithValue("@Barcode", row.Cells("BARCODE").Value)
                    cmdUpdateStock.Parameters.AddWithValue("@BranchID", currentBranchID)
                    cmdUpdateStock.ExecuteNonQuery()
                Next

                tran.Commit()
                MessageBox.Show("✅ Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' I-reset ang form
                dgvInventory.Rows.Clear()
                GenerateTransactionID()
                txtBarcode.Clear()
                txtBarcode.Focus()
                CalculateTotal()

            Catch ex As Exception
                tran?.Rollback()
                MessageBox.Show("❌ Save failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class