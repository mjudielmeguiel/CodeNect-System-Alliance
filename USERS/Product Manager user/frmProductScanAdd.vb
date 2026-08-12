Imports MySqlConnector

Public Class frmProductScanAdd

    Private Sub frmProductScanAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBarcode.Focus()
        lblMessage.Text = ""
        rdoScan.Checked = True
        btnadd.Enabled = False
        AuditLogger.LogAction("OPEN_SCAN_ADD", "ProductScanAdd", "Opened scan/add product form | Default: Scan Mode")
    End Sub

    Private Sub rdoManual_CheckedChanged(sender As Object, e As EventArgs) Handles rdoManual.CheckedChanged
        If rdoManual.Checked Then
            btnadd.Enabled = True
            lblMessage.Text = "Manual Mode: Type barcode then click Add or press Enter."
            lblMessage.ForeColor = Color.Blue
            AuditLogger.LogAction("MODE_CHANGE", "ProductScanAdd", "Switched to Manual Entry Mode")
        End If
    End Sub

    Private Sub rdoScan_CheckedChanged(sender As Object, e As EventArgs) Handles rdoScan.CheckedChanged
        If rdoScan.Checked Then
            btnadd.Enabled = False
            lblMessage.Text = "Scan Mode: Automatically processes on complete scan."
            lblMessage.ForeColor = Color.Blue
            AuditLogger.LogAction("MODE_CHANGE", "ProductScanAdd", "Switched to Auto Scan Mode")
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If rdoManual.Checked AndAlso e.KeyChar = ChrW(Keys.Enter) Then
            btnadd.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If Not rdoScan.Checked Then Exit Sub

        If txtBarcode.Text.Length > 0 AndAlso txtBarcode.Text.Length < 8 Then
            lblMessage.Text = "Barcode must be exactly 8 digits."
            lblMessage.ForeColor = Color.Orange
        Else
            lblMessage.Text = ""
        End If

        If txtBarcode.Text.Length >= 8 Then
            ProcessScan(txtBarcode.Text.Trim())
            txtBarcode.Clear()
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            lblMessage.Text = "Please enter a barcode first."
            lblMessage.ForeColor = Color.Red
            AuditLogger.LogAction("SCAN_VALID", "ProductScanAdd", "No barcode entered")
            Exit Sub
        End If

        If txtBarcode.Text.Length < 8 Then
            lblMessage.Text = "Barcode must be exactly 8 digits."
            lblMessage.ForeColor = Color.Orange
            AuditLogger.LogAction("SCAN_VALID", "ProductScanAdd", $"Invalid length | Input: {txtBarcode.Text.Trim()}")
            Exit Sub
        End If

        ProcessScan(txtBarcode.Text.Trim())
        txtBarcode.Clear()
        txtBarcode.Focus()
    End Sub

    Private Sub ProcessScan(barcode As String)
        lblMessage.Text = "Processing..."
        lblMessage.ForeColor = Color.Gray
        AuditLogger.LogAction("PROCESS_START", "ProductScanAdd", $"Processing barcode: {barcode}")

        If String.IsNullOrEmpty(Login.LoggedInAccountID) OrElse String.IsNullOrEmpty(Login.LoggedInBranchID) Then
            lblMessage.Text = "Missing account or branch information. Please log in again."
            lblMessage.ForeColor = Color.Red
            AuditLogger.LogAction("ACCESS_DENIED", "ProductScanAdd", "Missing account/branch info - cannot process")
            Exit Sub
        End If

        Try
            Dim sku, brand, desc, cat, sz, unit, vendor, vcode As String
            Dim price As Decimal

            ' ✅ KUKUNIN ANG DATA MULA SA admin_inventory_file
            Dim checkSource As String = "SELECT * FROM admin_inventory_file 
                                         WHERE BARCODE = @barcode 
                                           AND ACCOUNT_ID = @aid 
                                         LIMIT 1"

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                Using cmdSource As New MySqlCommand(checkSource, conn)
                    cmdSource.Parameters.AddWithValue("@barcode", barcode)
                    cmdSource.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)

                    Using drSource = cmdSource.ExecuteReader()
                        If Not drSource.Read() Then
                            lblMessage.Text = "Barcode not found under your Account ID."
                            lblMessage.ForeColor = Color.OrangeRed
                            AuditLogger.LogAction("NOT_FOUND", "ProductScanAdd", $"Barcode not found in master list | Code: {barcode}")
                            Return
                        End If

                        ' ✅ KUMPLETO — LAHAT NG COLUMN KASAMA NA ANG SKU AT CATEGORY
                        sku = drSource("SKU").ToString()
                        brand = drSource("BRAND").ToString()
                        desc = drSource("DESCRIPTIONS").ToString()
                        cat = drSource("CATEGORY").ToString()
                        sz = drSource("SIZE").ToString()
                        price = Convert.ToDecimal(drSource("PRICE"))
                        unit = drSource("UNIT").ToString()
                        vendor = drSource("VENDOR").ToString()
                        vcode = drSource("VENDOR_CODE").ToString()
                    End Using

                    ' ✅ TIGNAN KUNG NASA inventory_information NA
                    Dim checkExist As String = "SELECT COUNT(*) FROM inventory_information 
                                                WHERE BARCODE = @barcode 
                                                  AND ACCOUNT_ID = @aid 
                                                  AND BRANCH_ID = @bid"

                    Using cmdExist As New MySqlCommand(checkExist, conn)
                        cmdExist.Parameters.AddWithValue("@barcode", barcode)
                        cmdExist.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)
                        cmdExist.Parameters.AddWithValue("@bid", Login.LoggedInBranchID)

                        Dim count As Integer = Convert.ToInt32(cmdExist.ExecuteScalar())

                        If count > 0 Then
                            ' ✅ MAYROON NA → DAGDAGAN ANG AVAILABLE
                            Using cmdUpd As New MySqlCommand("UPDATE inventory_information 
                                                             SET AVAILABLE = AVAILABLE + 1,
                                                                 TOTAL = (AVAILABLE * PRICE),
                                                                 DATE_UPDATED = NOW()
                                                             WHERE BARCODE = @barcode
                                                               AND ACCOUNT_ID = @aid
                                                               AND BRANCH_ID = @bid", conn)
                                cmdUpd.Parameters.AddWithValue("@barcode", barcode)
                                cmdUpd.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)
                                cmdUpd.Parameters.AddWithValue("@bid", Login.LoggedInBranchID)
                                cmdUpd.ExecuteNonQuery()
                            End Using
                            lblMessage.Text = $"Updated: {desc} | SKU: {sku} | Category: {cat}"
                            lblMessage.ForeColor = Color.Green
                            AuditLogger.LogAction("STOCK_UPDATED", "ProductScanAdd", $"Restocked | SKU: {sku} | Item: {desc} | Category: {cat}")
                        Else
                            ' ✅ WALA PA → I-INSERT BAGONG PRODUKTO
                            Using cmdAdd As New MySqlCommand("INSERT INTO inventory_information 
                                                             (ACCOUNT_ID, BRANCH_ID, BARCODE, SKU, BRAND, DESCRIPTIONS, 
                                                              CATEGORY, SIZE, PRICE, AVAILABILITY, AVAILABLE, UNIT, 
                                                              TOTAL, VENDOR, VENDOR_CODE)
                                                             VALUES (@aid, @bid, @bar, @sku, @brnd, @desc, 
                                                                     @cat, @sz, @prc, 'Pending', 1, @unt, 
                                                                     @prc, @ven, @vcd)", conn)
                                cmdAdd.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)
                                cmdAdd.Parameters.AddWithValue("@bid", Login.LoggedInBranchID)
                                cmdAdd.Parameters.AddWithValue("@bar", barcode)
                                cmdAdd.Parameters.AddWithValue("@sku", sku)
                                cmdAdd.Parameters.AddWithValue("@brnd", brand)
                                cmdAdd.Parameters.AddWithValue("@desc", desc)
                                cmdAdd.Parameters.AddWithValue("@cat", cat)
                                cmdAdd.Parameters.AddWithValue("@sz", sz)
                                cmdAdd.Parameters.AddWithValue("@prc", price)
                                cmdAdd.Parameters.AddWithValue("@unt", unit)
                                cmdAdd.Parameters.AddWithValue("@ven", vendor)
                                cmdAdd.Parameters.AddWithValue("@vcd", vcode)
                                cmdAdd.ExecuteNonQuery()
                            End Using
                            lblMessage.Text = $"Added: {desc} | SKU: {sku} | Category: {cat} | Status: Pending"
                            lblMessage.ForeColor = Color.Green
                            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogger.LogAction("ITEM_ADDED", "ProductScanAdd", $"New item | SKU: {sku} | Item: {desc} | Category: {cat}")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblMessage.Text = "Error: " & ex.Message
            lblMessage.ForeColor = Color.Red
            AuditLogger.LogAction("ERROR", "ProductScanAdd", $"Process failed | Barcode: {barcode} | Error: {ex.Message}")
        End Try
    End Sub

End Class