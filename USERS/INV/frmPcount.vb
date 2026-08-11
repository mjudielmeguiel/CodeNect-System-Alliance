Imports MySqlConnector
Imports System.Text.RegularExpressions

Public Class frmPcount

    Private ReadOnly connStr As String = DBConnection.connStr
    Private currentTransID As String = String.Empty
    Private totalItemCount As Integer = 0
    Private totalAmount As Decimal = 0
    Private userAccountID As String = Login.LoggedInAccountID
    Private userBranchID As String = Login.LoggedInBranchID

    Private Sub frmPcount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateTransactionID()
        SetupGridView()
        txtBarcode.Focus()
        lblInventoryID.Text = $"Inventory ID: {currentTransID}"
    End Sub

    Private Sub GenerateTransactionID()
        currentTransID = DateTime.Now.ToString("INV-yyyyMMdd-") & New Random().Next(100000, 999999)
    End Sub

    Private Sub SetupGridView()
        dgvInventory.AutoGenerateColumns = False
        dgvInventory.Columns.Clear()

        ' ✅ BAGONG AYOS: May "Current Stock" Column na!
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Barcode", .HeaderText = "Barcode", .Width = 120})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "SKU", .HeaderText = "SKU", .Width = 100})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Description", .HeaderText = "Description", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Unit", .HeaderText = "Unit", .Width = 70})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "CurrentStock", .HeaderText = "Current Stock", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Price", .HeaderText = "Unit Price", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Count", .HeaderText = "Counted Qty", .Width = 80, .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "SubTotal", .HeaderText = "Sub Total", .Width = 100, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}})
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            Dim inputCode As String = txtBarcode.Text.Trim()
            If String.IsNullOrWhiteSpace(inputCode) Then Return
            SearchAndAddProduct(inputCode)
            txtBarcode.Clear()
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub SearchAndAddProduct(searchValue As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmdText As String = "SELECT * FROM `inventory_information` 
                                          WHERE (`BARCODE` = @searchVal OR `SKU` = @searchVal)
                                          AND `ACCOUNT_ID` = @accid 
                                          AND `BRANCH_ID` = @brid 
                                          LIMIT 1"
                Dim cmd As New MySqlCommand(cmdText, conn)
                cmd.Parameters.AddWithValue("@searchVal", searchValue.Trim())
                cmd.Parameters.AddWithValue("@accid", userAccountID)
                cmd.Parameters.AddWithValue("@brid", userBranchID)

                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim barcode As String = dr("BARCODE").ToString().Trim()
                        Dim price As Decimal = Convert.ToDecimal(dr("PRICE"))
                        Dim desc As String = dr("DESCRIPTIONS").ToString()
                        Dim sku As String = dr("SKU").ToString().Trim()
                        Dim unit As String = dr("UNIT").ToString()
                        Dim currentStock As Integer = Convert.ToInt32(dr("AVAILABLE")) ' ✅ KASAMA NA ANG KASALUKUYANG STOCK
                        Dim found As Boolean = False

                        For Each row As DataGridViewRow In dgvInventory.Rows
                            If row.Cells("Barcode").Value.ToString().Trim() = barcode Then
                                Dim qty As Integer = Convert.ToInt32(row.Cells("Count").Value) + 1
                                Dim subtotal As Decimal = qty * price
                                row.Cells("Count").Value = qty
                                row.Cells("SubTotal").Value = subtotal
                                found = True
                                Exit For
                            End If
                        Next

                        If Not found Then
                            ' ✅ Makikita mo na agad ang Current Stock bago i-update!
                            dgvInventory.Rows.Add(barcode, sku, desc, unit, currentStock, price, 1, price)
                        End If

                        RecalculateTotals()
                        AuditLogger.LogAction("SCAN", "Inventory Count", $"Added: {barcode} | {desc}")
                    Else
                        MessageBox.Show($"Produkto HINDI nakita!{vbCrLf}{vbCrLf}Hinanap: [{searchValue}]{vbCrLf}ACCOUNT_ID: {userAccountID}{vbCrLf}BRANCH_ID: {userBranchID}",
                                        "Hindi Nakita", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RecalculateTotals()
        totalItemCount = 0
        totalAmount = 0
        For Each row As DataGridViewRow In dgvInventory.Rows
            totalItemCount += Convert.ToInt32(row.Cells("Count").Value)
            totalAmount += Convert.ToDecimal(row.Cells("SubTotal").Value)
        Next
        lblTotalProducts.Text = $"Total Products: {totalItemCount}"
        lblTotalAmount.Text = $"Total Value: {totalAmount:N2}"
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvInventory.Rows.Count = 0 Then
            MessageBox.Show("Wala pang produkto na inilagay.", "Walang Laman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        Dim cmdHeader As New MySqlCommand("
                            INSERT INTO `inv_data` (
                                `TRANSACTION_ID`, `ACCOUNT_ID`, `BRANCH_ID`, `PREPARED_BY`, 
                                `REPORT_DATE`, `STATUS`, `ITEM_COUNT`, `TOTAL`, 
                                `TRANSACTION_TYPE`, `CREATED_BY`
                            ) VALUES (
                                @tid, @accid, @brid, @prep, NOW(), 'PENDING', @cnt, @tot, 'PHYSICAL_COUNT', @user
                            )", conn, trans)

                        cmdHeader.Parameters.AddWithValue("@tid", currentTransID)
                        cmdHeader.Parameters.AddWithValue("@accid", userAccountID)
                        cmdHeader.Parameters.AddWithValue("@brid", userBranchID)
                        cmdHeader.Parameters.AddWithValue("@prep", Login.LoggedInUsername)
                        cmdHeader.Parameters.AddWithValue("@cnt", totalItemCount)
                        cmdHeader.Parameters.AddWithValue("@tot", totalAmount)
                        cmdHeader.Parameters.AddWithValue("@user", Login.LoggedInUsername)
                        cmdHeader.ExecuteNonQuery()

                        For Each row As DataGridViewRow In dgvInventory.Rows
                            ' ✅ ✅ NAITAMA NA: GINAGAMIT NA ANG TAMANG COLUMN NA "AVAILABLE"
                            ' ITO ANG AWTOMATIKONG MAGBABAGO NG QUANTITY SA DATABASE
                            Dim cmdUpdStock As New MySqlCommand("
                                UPDATE `inventory_information` 
                                SET `AVAILABLE` = @newqty 
                                WHERE `BARCODE` = @barcode 
                                AND `ACCOUNT_ID` = @accid 
                                AND `BRANCH_ID` = @brid", conn, trans)

                            cmdUpdStock.Parameters.AddWithValue("@newqty", row.Cells("Count").Value)
                            cmdUpdStock.Parameters.AddWithValue("@barcode", row.Cells("Barcode").Value)
                            cmdUpdStock.Parameters.AddWithValue("@accid", userAccountID)
                            cmdUpdStock.Parameters.AddWithValue("@brid", userBranchID)
                            cmdUpdStock.ExecuteNonQuery()

                            ' ✅ May UPDATED_DATE na, WALANG UPDATED_BY
                            Dim cmdLog As New MySqlCommand("
                                INSERT INTO `inv_information` (
                                    `TRANSACTION_ID`, `ACCOUNT_ID`, `BRANCH_ID`, 
                                    `BARCODE`, `QUANTITY`, `PREVIOUS_QTY`, 
                                    `UPDATED_DATE`
                                ) VALUES (
                                    @tid, @accid, @brid, @barcode, @qty, @prevqty, NOW()
                                )", conn, trans)

                            cmdLog.Parameters.AddWithValue("@tid", currentTransID)
                            cmdLog.Parameters.AddWithValue("@accid", userAccountID)
                            cmdLog.Parameters.AddWithValue("@brid", userBranchID)
                            cmdLog.Parameters.AddWithValue("@barcode", row.Cells("Barcode").Value)
                            cmdLog.Parameters.AddWithValue("@qty", row.Cells("Count").Value)
                            cmdLog.Parameters.AddWithValue("@prevqty", DBNull.Value)
                            cmdLog.ExecuteNonQuery()
                        Next

                        trans.Commit()
                        MessageBox.Show($"Nai-save na!{vbCrLf}Transaction ID: {currentTransID}{vbCrLf}{vbCrLf}✅ Awtomatikong na-update na ang Stock Quantity!", "Nai-save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        AuditLogger.LogAction("SAVE", "Inventory Count", $"Saved batch {currentTransID} | Items: {totalItemCount} | Total: {totalAmount:N2}")

                        dgvInventory.Rows.Clear()
                        totalItemCount = 0
                        totalAmount = 0
                        RecalculateTotals()
                        GenerateTransactionID()
                        lblInventoryID.Text = $"Inventory ID: {currentTransID}"
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Inventory Count", $"Save failed: {ex.Message}")
        End Try
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        MessageBox.Show("Reports module will open here.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class