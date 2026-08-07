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

    ' Generate unique Transaction ID para sa batch na ito
    Private Sub GenerateTransactionID()
        currentTransID = DateTime.Now.ToString("INV-yyyyMMdd-") & New Random().Next(100000, 999999)
    End Sub

    ' I-setup ang DataGridView
    Private Sub SetupGridView()
        dgvInventory.AutoGenerateColumns = False
        dgvInventory.Columns.Clear()

        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Barcode", .HeaderText = "Barcode", .Width = 120})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "SKU", .HeaderText = "SKU", .Width = 100})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Description", .HeaderText = "Description", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Unit", .HeaderText = "Unit", .Width = 70})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Price", .HeaderText = "Unit Price", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Qty", .HeaderText = "Count", .Width = 60, .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "SubTotal", .HeaderText = "Sub Total", .Width = 100, .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}})
    End Sub

    ' Kapag nag-type o nag-scan sa Barcode Field
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        ' Kapag Enter o natapos ang scan (kadalasan may kasamang Enter)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If String.IsNullOrWhiteSpace(txtBarcode.Text) Then Return

            ' Alin ang napiling mode?
            If rdoScan.Checked Then
                ProcessScannedBarcode(txtBarcode.Text.Trim())
            ElseIf rdoManual.Checked Then
                ' Dito pwede buksan form o panel para ilagay manually ang detalye
                MessageBox.Show("Manual entry mode: Ilagay ang detalye ng produkto.", "Manual Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' --- Dito mo ilalagay ang code kung gusto mo may manual entry form ---
            End If

            txtBarcode.Clear()
            txtBarcode.Focus()
        End If
    End Sub

    ' Proseso ng na-scan na Barcode
    Private Sub ProcessScannedBarcode(barcode As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                ' ✅ MAHALAGA: Hahanap lang sa ilalim ng iyong Account at Branch
                Dim cmd As New MySqlCommand("SELECT * FROM `inv_information` 
                                             WHERE `BARCODE` = @barcode 
                                             AND `ACCOUNT_ID` = @accid 
                                             AND `BRANCH_ID` = @brid 
                                             LIMIT 1", conn)

                cmd.Parameters.AddWithValue("@barcode", barcode)
                cmd.Parameters.AddWithValue("@accid", userAccountID)
                cmd.Parameters.AddWithValue("@brid", userBranchID)

                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        ' Nakita na ang produkto - idagdag o dagdagan ang bilang
                        Dim found As Boolean = False
                        Dim price As Decimal = Convert.ToDecimal(dr("PRICE"))
                        Dim desc As String = dr("DESCRIPTIONS").ToString()
                        Dim sku As String = dr("SKU").ToString()
                        Dim unit As String = dr("UNIT").ToString()

                        ' Check kung nasa listahan na
                        For Each row As DataGridViewRow In dgvInventory.Rows
                            If row.Cells("Barcode").Value.ToString() = barcode Then
                                ' Dagdagan lang ang bilang
                                Dim qty As Integer = Convert.ToInt32(row.Cells("Qty").Value) + 1
                                Dim subtotal As Decimal = qty * price
                                row.Cells("Qty").Value = qty
                                row.Cells("SubTotal").Value = subtotal
                                found = True
                                Exit For
                            End If
                        Next

                        ' Kung bago pa lang, idagdag sa listahan
                        If Not found Then
                            dgvInventory.Rows.Add(barcode, sku, desc, unit, price, 1, price)
                        End If

                        ' I-update ang Kabuuan
                        RecalculateTotals()
                        AuditLogger.LogAction("SCAN", "Inventory Count", $"Scanned: {barcode} | {desc}")
                    Else
                        MessageBox.Show("Product not found or does not belong to your branch.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error scanning product: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' I-compute ulit ang Total Items at Total Amount
    Private Sub RecalculateTotals()
        totalItemCount = 0
        totalAmount = 0

        For Each row As DataGridViewRow In dgvInventory.Rows
            totalItemCount += Convert.ToInt32(row.Cells("Qty").Value)
            totalAmount += Convert.ToDecimal(row.Cells("SubTotal").Value)
        Next

        lblTotalProducts.Text = $"Total Products: {totalItemCount}"
        lblTotalAmount.Text = $"Total Value: {totalAmount:N2}"
    End Sub

    ' I-save lahat ng na-scan
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvInventory.Rows.Count = 0 Then
            MessageBox.Show("No products scanned yet.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        ' 1. I-save muna ang header sa inv_data
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

                        ' 2. I-update ang TRANSACTION_ID sa bawat napiling produkto
                        For Each row As DataGridViewRow In dgvInventory.Rows
                            Dim cmdUpd As New MySqlCommand("
                                UPDATE `inv_information` 
                                SET `TRANSACTION_ID` = @tid 
                                WHERE `BARCODE` = @barcode 
                                AND `ACCOUNT_ID` = @accid 
                                AND `BRANCH_ID` = @brid", conn, trans)

                            cmdUpd.Parameters.AddWithValue("@tid", currentTransID)
                            cmdUpd.Parameters.AddWithValue("@barcode", row.Cells("Barcode").Value)
                            cmdUpd.Parameters.AddWithValue("@accid", userAccountID)
                            cmdUpd.Parameters.AddWithValue("@brid", userBranchID)
                            cmdUpd.ExecuteNonQuery()
                        Next

                        trans.Commit()
                        MessageBox.Show($"Inventory count saved successfully!{vbCrLf}Transaction ID: {currentTransID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        AuditLogger.LogAction("SAVE", "Inventory Count", $"Saved batch {currentTransID} | Items: {totalItemCount} | Total: {totalAmount:N2}")

                        ' I-reset para sa susunod
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
        ' Dito mo ilalagay ang code para buksan ang report form
        MessageBox.Show("Reports module will open here.", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class