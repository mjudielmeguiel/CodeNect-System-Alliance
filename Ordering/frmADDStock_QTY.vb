Imports MySqlConnector

Public Class frmADDStock_QTY

    Public Property Barcode As String = ""
    Public Property SKU As String = ""
    Public Property Brand As String = ""
    Public Property Description As String = ""
    Public Property ProductSize As String = ""
    Public Property UnitPrice As Decimal = 0D
    Public Property VendorName As String = ""
    Public Property OrderQty As Integer = 0
    Public Property PONumber As String = ""

    Private connStr As String = DBConnection.connStr

    Private Sub frmADDStock_QTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBarcode.Text = Barcode
        lblSKU.Text = SKU
        lblBrand.Text = Brand
        lblDescription.Text = Description
        lblSize.Text = ProductSize
        lblPrice.Text = UnitPrice.ToString("N2")
        lblVendor.Text = VendorName
        lblMaxOrderQty.Text = OrderQty.ToString()

        txtReceivedQty.Text = "0"
        txtReturnQty.Text = "0"

        btnSubmit.Enabled = True
        AuditLogger.LogAction("OPEN", "Inventory", $"Opened Add Stock form | SKU: {SKU} | Item: {Brand} - {Description}")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            btnSubmit.Enabled = False

            Dim receivedQty As Integer = 0
            Dim returnQty As Integer = 0

            If Not Integer.TryParse(txtReceivedQty.Text.Trim(), receivedQty) OrElse receivedQty < 0 Then
                MessageBox.Show("Enter valid Received Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.LogAction("SAVE_FAILED", "Inventory", $"Invalid received quantity input for SKU: {SKU}")
                txtReceivedQty.Focus()
                btnSubmit.Enabled = True
                Return
            End If

            If Not Integer.TryParse(txtReturnQty.Text.Trim(), returnQty) OrElse returnQty < 0 Then
                MessageBox.Show("Enter valid Return Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.LogAction("SAVE_FAILED", "Inventory", $"Invalid return quantity input for SKU: {SKU}")
                txtReturnQty.Focus()
                btnSubmit.Enabled = True
                Return
            End If

            If receivedQty > OrderQty Then
                MessageBox.Show($"Cannot receive more than ordered ({OrderQty}).", "Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.LogAction("SAVE_FAILED", "Inventory", $"Received qty exceeds ordered qty for SKU: {SKU}")
                txtReceivedQty.Focus()
                btnSubmit.Enabled = True
                Return
            End If

            If returnQty > receivedQty Then
                MessageBox.Show("Return quantity cannot be more than received.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AuditLogger.LogAction("SAVE_FAILED", "Inventory", $"Return qty exceeds received qty for SKU: {SKU}")
                btnSubmit.Enabled = True
                Return
            End If

            Dim addQty As Integer = receivedQty - returnQty
            If addQty <= 0 Then
                MessageBox.Show("No stock to add.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("SAVE_FAILED", "Inventory", $"Net quantity zero/negative for SKU: {SKU}")
                btnSubmit.Enabled = True
                Return
            End If

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using tran As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sqlUpdate As String = "
                            UPDATE `Inventory_Master_file`
                            SET 
                                `AVAILABLE` = IFNULL(`AVAILABLE`, 0) + @AddQty,
                                `PRICE` = @Price,
                                `DATE_ADDED` = NOW()
                            WHERE `BARCODE` = @Barcode OR `SKU` = @SKU;
                        "
                        Dim rowsAffected As Integer = 0
                        Using cmdUpd As New MySqlCommand(sqlUpdate, conn, tran)
                            cmdUpd.Parameters.AddWithValue("@AddQty", addQty)
                            cmdUpd.Parameters.AddWithValue("@Price", UnitPrice)
                            cmdUpd.Parameters.AddWithValue("@Barcode", Barcode)
                            cmdUpd.Parameters.AddWithValue("@SKU", SKU)
                            rowsAffected = cmdUpd.ExecuteNonQuery()
                        End Using

                        If rowsAffected = 0 Then
                            Dim sqlInsert As String = "
                                INSERT INTO `Inventory_Master_file` 
                                    (`BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `CATEGORY`, `SIZE`, `PRICE`, `AVAILABLE`, `VENDOR`, `DATE_ADDED`)
                                VALUES 
                                    (@Barcode, @SKU, @Brand, @Desc, '', @Size, @Price, @AddQty, @Vendor, NOW());
                            "
                            Using cmdIns As New MySqlCommand(sqlInsert, conn, tran)
                                cmdIns.Parameters.AddWithValue("@Barcode", Barcode)
                                cmdIns.Parameters.AddWithValue("@SKU", SKU)
                                cmdIns.Parameters.AddWithValue("@Brand", Brand)
                                cmdIns.Parameters.AddWithValue("@Desc", Description)
                                cmdIns.Parameters.AddWithValue("@Size", ProductSize)
                                cmdIns.Parameters.AddWithValue("@Price", UnitPrice)
                                cmdIns.Parameters.AddWithValue("@AddQty", addQty)
                                cmdIns.Parameters.AddWithValue("@Vendor", VendorName)
                                cmdIns.ExecuteNonQuery()
                            End Using
                            AuditLogger.LogAction("INSERT", "Inventory", $"Added new product stock | SKU: {SKU} | Qty: {addQty}")
                        Else
                            AuditLogger.LogAction("UPDATE", "Inventory", $"Updated existing stock | SKU: {SKU} | Added Qty: {addQty}")
                        End If

                        Dim sqlStatus As String = "
                            UPDATE `STO_DATA`
                            SET 
                                `STATUS` = 'PENDING',
                                `RECEIVE_DATE` = NOW()
                            WHERE `PO_NUMBER` = @PONumber;
                        "
                        Using cmdStat As New MySqlCommand(sqlStatus, conn, tran)
                            cmdStat.Parameters.AddWithValue("@PONumber", PONumber)
                            cmdStat.ExecuteNonQuery()
                        End Using

                        tran.Commit()

                        MessageBox.Show($"Transaction completed!
Received: {receivedQty}
Returned: {returnQty}
Added to Inventory: {addQty}
Order Status: PENDING", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        AuditLogger.LogAction("STOCK_RECEIVE", "Inventory", $"Stock received | PO: {PONumber} | SKU: {SKU} | Received: {receivedQty} | Returned: {returnQty} | Net Added: {addQty}")

                        Me.Close()

                    Catch exTran As Exception
                        tran.Rollback()
                        AuditLogger.LogAction("ERROR", "Inventory", $"Transaction rolled back for PO {PONumber}: {exTran.Message}")
                        Throw exTran
                    End Try
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Inventory", $"Error adding stock for SKU {SKU}: {ex.Message}")
            btnSubmit.Enabled = True
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CANCEL", "Inventory", $"Cancelled Add Stock form | SKU: {SKU}")
        Me.Close()
    End Sub

End Class