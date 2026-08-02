Imports MySqlConnector
Imports System.Collections.Generic

Public Class frmPOS_System

    Public totalAmount As Decimal = 0
    Public discountPercent As Decimal = 0
    Public discountAmount As Decimal = 0
    Public isVATExempt As Boolean = False
    Private Const VAT_RATE As Decimal = 0.12D
    Private currentOrderID As String = ""
    Public LoggedInUser As String = ""
    Public UserBranchCode As String = ""

    Public BranchName As String = ""
    Public BranchAddress As String = ""
    Public BranchTIN As String = ""
    Public BranchAccountID As String = ""

    Private finalTotal As Decimal = 0
    Private totalPaid As Decimal = 0
    Private paymentDetails As New List(Of String)()

    Private paymentMethod As String = "Cash"
    Private cashAmount As Decimal = 0
    Private onlineAmount As Decimal = 0
    Private LoggedInUserID As Integer = 0

    Private Sub frmPOS_System_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SetUserStatus("OFFLINE")
        AuditLogger.LogAction("LOGOUT", "POS", $"User logged out | User: {LoggedInUser} | Branch: {UserBranchCode}")
    End Sub

    Private Sub SetUserStatus(status As String)
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "
                UPDATE `user_accounts` 
                SET `status` = @NewStatus, `last_login` = NOW()
                WHERE `username` = @User"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@NewStatus", status)
                    cmd.Parameters.AddWithValue("@User", Login.txtUsername.Text.Trim())
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Status Update Error: " & ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "POS", $"Failed to update user status | User: {LoggedInUser} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub DeterminePaymentMethod()
        paymentMethod = "Cash"
        cashAmount = 0
        onlineAmount = 0

        For Each line As String In paymentDetails
            If line.StartsWith("Cash:") Then
                Dim amtStr = line.Split("₱")(1).Trim()
                Decimal.TryParse(amtStr, cashAmount)
            ElseIf line.Contains("GCash") OrElse line.Contains("Maya") OrElse line.Contains("Online") OrElse line.Contains("Ref:") Then
                Dim amtStr = line.Split("₱")(1).Split("|")(0).Trim()
                Decimal.TryParse(amtStr, onlineAmount)
            End If
        Next

        If cashAmount > 0 AndAlso onlineAmount > 0 Then
            paymentMethod = "Split Payment (Cash + Online)"
        ElseIf onlineAmount > 0 Then
            paymentMethod = "Online Payment"
        Else
            paymentMethod = "Cash Payment"
        End If
    End Sub

    Private Sub POS_System_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        SetupGrid()
        txtBarcode.Clear()
        txtBarcode.Focus()

        LoggedInUser = Login.txtUsername.Text.Trim()
        txtAmountInput.Enabled = False

        GetUserBranch()
        GetBranchDetails()

        rtbReceipt.ReadOnly = True
        rtbReceipt.Font = New Font("Courier New", 9, FontStyle.Regular)
        rtbReceipt.Clear()

        btnCheckOut.Text = "Pay " & "₱0.00"
        lblChange.Text = "0.00"
        lblRemainingBalance.Text = ""
        lblRemainingBalance.Visible = False

        SetUserStatus("ONLINE")
        AuditLogger.LogAction("LOGIN", "POS", $"User logged in | User: {LoggedInUser} | Branch: {UserBranchCode}")
    End Sub

    Private Sub GetUserBranch()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `branch_id`, `full_name`, `account_id`, `user_id` FROM `user_accounts` WHERE `username` = @Username"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Username", LoggedInUser)
                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            UserBranchCode = dr("branch_id").ToString().Trim()
                            LoggedInUser = dr("full_name").ToString().Trim()
                            LoggedInUserID = CInt(dr("user_id"))
                        Else
                            UserBranchCode = "MAIN"
                            LoggedInUser = "Unknown User"
                            LoggedInUserID = 0
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting user branch: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserBranchCode = "MAIN"
            AuditLogger.LogAction("ERROR", "POS", $"Failed to load user branch | User: {LoggedInUser} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub GetBranchDetails()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BRANCH` AS BranchName, `ADDRESS`, `TIN`, `ACCOUNT_ID` FROM `branches` WHERE `BRANCH_ID` = @BranchCode"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BranchCode", UserBranchCode)
                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            BranchName = dr("BranchName").ToString().Trim()
                            BranchAddress = dr("ADDRESS").ToString().Trim()
                            BranchTIN = dr("TIN").ToString().Trim()
                            BranchAccountID = dr("ACCOUNT_ID").ToString().Trim()
                        Else
                            BranchName = UserBranchCode & " BRANCH"
                            BranchAddress = "Not Registered"
                            BranchTIN = "---"
                            BranchAccountID = ""
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            BranchName = UserBranchCode & " BRANCH"
            BranchAddress = "Muntinlupa City, Metro Manila"
            BranchTIN = "138-647-329-002"
            AuditLogger.LogAction("WARNING", "POS", $"Using default branch details | Branch: {UserBranchCode}")
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvCart
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditProgrammatically

            .Columns.Add("Barcode", "Barcode")
            .Columns.Add("ProductName", "Product Name")
            .Columns.Add("Size", "Size")
            .Columns.Add("Price", "Price")
            .Columns.Add("Qty", "Qty")
            .Columns.Add("SubTotal", "Sub Total")

            .Columns("Price").DefaultCellStyle.Format = "N2"
            .Columns("SubTotal").DefaultCellStyle.Format = "N2"
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = "Date and Time : " & Now.ToString("MMMM dd, yyyy hh:mm:ss tt")
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        Dim code As String = txtBarcode.Text.Trim()
        If Not String.IsNullOrEmpty(code) Then
            AddProduct(code)
            txtBarcode.Clear()
        End If
    End Sub

    Private Sub AddProduct(barcode As String)
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT `BARCODE`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `AVAILABLE` FROM `inventory_information` WHERE TRIM(`BARCODE`) = @bcode AND TRIM(`BRANCH_ID`) = @branchId"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@bcode", barcode.Trim())
                    cmd.Parameters.AddWithValue("@branchId", UserBranchCode.Trim())
                    conn.Open()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Dim stockAvailable As Integer = CInt(dr("AVAILABLE"))
                            Dim existingRow As DataGridViewRow = Nothing

                            For Each row As DataGridViewRow In dgvCart.Rows
                                If row.Cells("Barcode").Value.ToString().Trim().ToUpper() = barcode.Trim().ToUpper() Then
                                    existingRow = row
                                    Exit For
                                End If
                            Next

                            If existingRow IsNot Nothing Then
                                Dim currentQty As Integer = CInt(existingRow.Cells("Qty").Value)
                                Dim newQty As Integer = currentQty + 1

                                If newQty > stockAvailable Then
                                    MessageBox.Show($"Cannot add more!{vbCrLf}Remaining stock: {stockAvailable} piece(s)", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    AuditLogger.LogAction("STOCK_ERROR", "POS", $"Add failed - insufficient stock | Barcode: {barcode} | Requested: {newQty} | Available: {stockAvailable}")
                                    Return
                                End If

                                existingRow.Cells("Qty").Value = newQty
                                existingRow.Cells("SubTotal").Value = Math.Round(CDec(existingRow.Cells("Price").Value) * newQty, 2)
                                AuditLogger.LogAction("UPDATE_CART", "POS", $"Item qty updated | Barcode: {barcode} | New Qty: {newQty} | TransID: {currentOrderID}")

                            Else
                                If stockAvailable <= 0 Then
                                    MessageBox.Show($"OUT OF STOCK!{vbCrLf}Product: {dr("DESCRIPTIONS").ToString()}", "No Stock Available", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    AuditLogger.LogAction("OUT_OF_STOCK", "POS", $"Item out of stock | Barcode: {barcode}")
                                    Return
                                ElseIf stockAvailable = 1 Then
                                    MessageBox.Show($"NOTICE: Only 1 piece left in stock for this product.", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ElseIf stockAvailable <= 5 Then
                                    MessageBox.Show($"NOTICE: Only {stockAvailable} piece(s) left in stock for this product.", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                Dim price As Decimal = CDec(dr("PRICE"))
                                dgvCart.Rows.Add(dr("BARCODE"), dr("DESCRIPTIONS"), dr("SIZE"), price, 1, price)
                                AuditLogger.LogAction("ADD_TO_CART", "POS", $"Item added | Barcode: {barcode} | Name: {dr("DESCRIPTIONS")} | Price: {price:N2} | TransID: {currentOrderID}")
                            End If

                            ComputeTotal()

                            If dgvCart.Rows.Count = 1 Then
                                currentOrderID = New Random().Next(10000000, 99999999).ToString()
                                txtAmountInput.Enabled = True
                                AuditLogger.LogAction("NEW_TRANS", "POS", $"New transaction started | TransID: {currentOrderID} | Cashier: {LoggedInUser}")
                            End If

                        Else
                            If ProductExistsInAnyBranch(barcode) Then
                                MessageBox.Show("This product is not carried by your branch.", "Product Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AuditLogger.LogAction("PRODUCT_NOT_BRANCH", "POS", $"Product exists but not at branch | Barcode: {barcode} | Branch: {UserBranchCode}")
                            Else
                                MessageBox.Show("Product not found in inventory.", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                AuditLogger.LogAction("INVALID_BARCODE", "POS", $"Barcode not found | Barcode: {barcode}")
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "POS", $"Add product error | Barcode: {barcode} | Error: {ex.Message}")
        End Try
    End Sub

    Private Function ProductExistsInAnyBranch(barcode As String) As Boolean
        Using conn As New MySqlConnection(DBConnection.connStr)
            Dim sql As String = "SELECT COUNT(*) FROM `inventory_information` WHERE TRIM(`BARCODE`) = @bcode"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@bcode", barcode.Trim())
                conn.Open()
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Private Sub dgvCart_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCart.KeyDown
        If e.KeyCode = Keys.Enter AndAlso dgvCart.SelectedRows.Count > 0 Then
            e.SuppressKeyPress = True

            Dim row As DataGridViewRow = dgvCart.SelectedRows(0)
            Dim barcode As String = row.Cells("Barcode").Value.ToString().Trim()

            Using frmQty As New frmProductQTY()
                frmQty.Barcode = barcode
                frmQty.CurrentQty = CInt(row.Cells("Qty").Value)
                frmQty.UserBranchCode = UserBranchCode

                If frmQty.ShowDialog() = DialogResult.OK Then
                    Dim newQuantity As Integer = frmQty.CurrentQty
                    Dim price As Decimal = CDec(row.Cells("Price").Value)

                    row.Cells("Qty").Value = newQuantity
                    row.Cells("SubTotal").Value = Math.Round(price * newQuantity, 2)

                    ComputeTotal()
                    AuditLogger.LogAction("EDIT_QTY", "POS", $"Item qty edited | Barcode: {barcode} | New Qty: {newQuantity} | TransID: {currentOrderID}")
                End If
            End Using
        End If
    End Sub

    Public Sub ApplyPWDDiscount(discountPercentValue As Integer, vatExemptStatus As Boolean)
        discountPercent = discountPercentValue
        isVATExempt = vatExemptStatus
        ComputeTotal()
        AuditLogger.LogAction("DISCOUNT_APPLY", "POS", $"Discount applied | TransID: {currentOrderID} | Percent: {discountPercentValue}% | VAT Exempt: {vatExemptStatus}")
    End Sub

    Private Function GetVatableSales() As Decimal
        Return Math.Round(totalAmount / (1 + VAT_RATE), 2)
    End Function

    Private Function GetVatAmount(vatableSales As Decimal) As Decimal
        If isVATExempt Then Return 0
        Return Math.Round(totalAmount - vatableSales, 2)
    End Function

    Public Sub ComputeTotal()
        Dim subtotal As Decimal = 0
        For Each row As DataGridViewRow In dgvCart.Rows
            subtotal += CDec(row.Cells("SubTotal").Value)
        Next

        totalAmount = Math.Round(subtotal, 2)
        Dim vatableSales As Decimal = GetVatableSales()

        discountAmount = Math.Round(vatableSales * (discountPercent / 100), 2)
        finalTotal = Math.Round(vatableSales - discountAmount, 2)

        RefreshDisplay()
    End Sub

    Private Sub RefreshDisplay()
        Dim itemCount As Integer = GetItemCount()
        Dim vatableSales As Decimal = GetVatableSales()
        Dim vatAmount As Decimal = GetVatAmount(vatableSales)

        Dim currentInput As Decimal = 0
        Decimal.TryParse(txtAmountInput.Text.Trim(), currentInput)
        Dim totalNowPaid As Decimal = Math.Round(totalPaid + currentInput, 2)

        Dim remainingBalance As Decimal = Math.Max(0, finalTotal - totalNowPaid)
        Dim changeAmount As Decimal = Math.Max(0, totalNowPaid - finalTotal)
        Dim amountPaidDisplay As Decimal = Math.Min(totalNowPaid, finalTotal)

        btnCheckOut.Text = finalTotal.ToString("N2")
        lblChange.Text = changeAmount.ToString("N2")

        If remainingBalance > 0 Then
            lblRemainingBalance.Text = remainingBalance.ToString("N2")
            lblRemainingBalance.Visible = True
        Else
            lblRemainingBalance.Text = ""
            lblRemainingBalance.Visible = False
        End If

        UpdateReceiptFormat(itemCount, vatableSales, vatAmount, amountPaidDisplay, remainingBalance, changeAmount)
    End Sub

    Private Sub UpdateReceiptFormat(itemCount As Integer, vatableSales As Decimal, vatAmount As Decimal,
                                     amountPaid As Decimal, remainingBalance As Decimal, changeAmount As Decimal)
        Dim sb As New Text.StringBuilder()

        sb.AppendLine(tsbranch.Text)
        sb.AppendLine("Proprietor : JUDIEL MEGUIEL MESCALLADO")
        sb.AppendLine(BranchAddress)
        sb.AppendLine($"VAT REG. TIN : {BranchTIN}")
        sb.AppendLine("MIN 39701573864721756 / S/N PC059YU6")
        sb.AppendLine($"Time/Date: {Now:HH:mm:ss dd/MM/yy}")
        sb.AppendLine($"Cashier : {LoggedInUser}")
        sb.AppendLine($"Transaction No. : {If(String.IsNullOrEmpty(currentOrderID), "-", currentOrderID)}")
        sb.AppendLine()
        sb.AppendLine()
        sb.AppendLine()

        For Each row As DataGridViewRow In dgvCart.Rows
            Dim name As String = row.Cells("ProductName").Value.ToString()
            Dim size As String = row.Cells("Size").Value.ToString()
            Dim qty As Integer = CInt(row.Cells("Qty").Value)
            Dim price As Decimal = CDec(row.Cells("Price").Value)
            Dim subtotal As Decimal = CDec(row.Cells("SubTotal").Value)

            If name.Length > 25 Then name = name.Substring(0, 22) & "..."

            sb.AppendLine($"{name} {size}")
            sb.AppendLine($"{qty,3} @ {price,6:N2} {subtotal,12:N2} V")
            sb.AppendLine()
        Next

        sb.AppendLine("----------------------------------------")

        sb.AppendLine($"TOTAL : {totalAmount,20:N2}")

        DeterminePaymentMethod()
        sb.AppendLine($"PAYMENT METHOD: {paymentMethod}")
        If cashAmount > 0 Then sb.AppendLine($"Cash Paid: {cashAmount,18:N2}")
        If onlineAmount > 0 Then sb.AppendLine($"Online Paid: {onlineAmount,16:N2}")

        sb.AppendLine($"Amount Paid : {amountPaid,12:N2}")
        sb.AppendLine($"Remaining Balance : {remainingBalance,6:N2}")
        sb.AppendLine($"Change : {changeAmount,20:N2}")
        sb.AppendLine()
        sb.AppendLine($"Item Count : {itemCount}")
        sb.AppendLine()

        sb.AppendLine("****************************************")
        sb.AppendLine($"VATABLE : {vatableSales,18:N2}")
        sb.AppendLine("ZERO RATED :              0.00")
        sb.AppendLine(If(isVATExempt, $"EXEMPT : {vatableSales,20:N2}", "EXEMPT :              0.00"))
        sb.AppendLine($"VAT : {vatAmount,25:N2}")
        sb.AppendLine($"AMOUNT DUE : {finalTotal,18:N2}")
        sb.AppendLine()
        sb.AppendLine($"O.R No. {currentOrderID}")

        rtbReceipt.Text = sb.ToString()
    End Sub

    Private Sub txtAmountInput_TextChanged(sender As Object, e As EventArgs) Handles txtAmountInput.TextChanged
        RefreshDisplay()
    End Sub

    Private Function GetItemCount() As Integer
        Dim cnt As Integer = 0
        For Each row As DataGridViewRow In dgvCart.Rows
            cnt += CInt(row.Cells("Qty").Value)
        Next
        Return cnt
    End Function

    Private Sub txtAmountInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountInput.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso txtAmountInput.Text.Contains(".") Then e.Handled = True
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            ProcessCashPayment()
        End If
    End Sub

    Private Sub ProcessCashPayment()
        Dim inputAmt As Decimal = 0
        If Not Decimal.TryParse(txtAmountInput.Text.Trim(), inputAmt) OrElse inputAmt <= 0 Then
            MessageBox.Show("Please enter a valid amount greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("PAY_FAILED", "POS", $"Invalid cash amount | TransID: {currentOrderID}")
            Return
        End If

        Dim applyAmt As Decimal = Math.Min(inputAmt, finalTotal - totalPaid)
        If applyAmt <= 0 Then
            MessageBox.Show("No remaining balance to pay.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAmountInput.Clear()
            Return
        End If

        totalPaid = Math.Round(totalPaid + applyAmt, 2)
        paymentDetails.Add($"Cash: ₱{applyAmt:N2}")

        SaveCashPaymentToDB(applyAmt)
        AuditLogger.LogAction("CASH_PAY", "POS", $"Cash payment added | TransID: {currentOrderID} | Amount: {applyAmt:N2}")

        txtAmountInput.Clear()
        RefreshDisplay()
    End Sub

    Private Sub SaveCashPaymentToDB(amount As Decimal)
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "
                INSERT INTO `Payments` (
                    `OrderID`, `PaymentMethod`, `ReferenceNumber`, `AmountPaid`, `Sender`, `Remarks`, `PaymentDate`, `Status`
                ) VALUES (
                    @OrderID, 'Cash', NULL, @Amount, NULL, 'Cash payment', NOW(), 'Completed'
                )"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@OrderID", currentOrderID)
                    cmd.Parameters.AddWithValue("@Amount", amount)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving cash payment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "POS", $"Save cash pay error | TransID: {currentOrderID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub SaveSalesTransaction(ByVal changeValue As Decimal)
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim vatable = Math.Round(totalAmount / (1 + VAT_RATE), 2)
                Dim vatAmt = Math.Round(totalAmount - vatable, 2)
                Dim itemCount = GetItemCount()
                Dim discountType = If(discountPercent > 0, "PWD / Senior", "None")

                Dim sql As String = "
            INSERT INTO `sales_transactions` (
                `transaction_id`, `branch_id`, `user_id`, `user_name`,
                `transaction_date`, `transaction_time`, `item_count`, `subtotal_amount`, `vatable_amount`,
                `vat_amount`, `discount_type`, `discount_percent`, `discount_amount`,
                `amount_due`, `amount_paid`, `cash_amount`, `online_amount`,
                `change_amount`, `payment_method`, `status`
            ) VALUES (
                @TransID, @BranchID, @UserID, @UserName,
                CURDATE(), CURTIME(), @ItemCount, @Subtotal, @VATable,
                @VAT, @DiscType, @DiscPercent, @DiscAmount,
                @AmountDue, @AmountPaid, @CashAmt, @OnlineAmt,
                @Change, @PaymentMethod, 'Completed'
            )"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@TransID", currentOrderID)
                    cmd.Parameters.AddWithValue("@BranchID", UserBranchCode)
                    cmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                    cmd.Parameters.AddWithValue("@UserName", LoggedInUser)
                    cmd.Parameters.AddWithValue("@ItemCount", itemCount)
                    cmd.Parameters.AddWithValue("@Subtotal", totalAmount)
                    cmd.Parameters.AddWithValue("@VATable", vatable)
                    cmd.Parameters.AddWithValue("@VAT", vatAmt)
                    cmd.Parameters.AddWithValue("@DiscType", discountType)
                    cmd.Parameters.AddWithValue("@DiscPercent", discountPercent)
                    cmd.Parameters.AddWithValue("@DiscAmount", discountAmount)
                    cmd.Parameters.AddWithValue("@AmountDue", finalTotal)
                    cmd.Parameters.AddWithValue("@AmountPaid", Math.Min(totalPaid, finalTotal))
                    cmd.Parameters.AddWithValue("@CashAmt", cashAmount)
                    cmd.Parameters.AddWithValue("@OnlineAmt", onlineAmount)
                    cmd.Parameters.AddWithValue("@Change", Math.Round(changeValue, 2))
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)

                    conn.Open()
                    cmd.ExecuteNonQuery()

                    Dim updateSalesSql As String = "
                UPDATE `branches`
                SET `SALES` = IFNULL(`SALES`, 0) + @AddAmount
                WHERE TRIM(UPPER(`BRANCH_ID`)) = TRIM(UPPER(@BranchID))"
                    Using cmdUpdate As New MySqlCommand(updateSalesSql, conn)
                        cmdUpdate.Parameters.AddWithValue("@AddAmount", finalTotal)
                        cmdUpdate.Parameters.AddWithValue("@BranchID", UserBranchCode)
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                End Using
            End Using
            AuditLogger.LogAction("SAVE_SALE", "POS", $"Transaction saved | TransID: {currentOrderID} | Total: {finalTotal:N2} | Paid: {totalPaid:N2} | Change: {changeValue:N2} | PayMethod: {paymentMethod}")
        Catch ex As Exception
            MessageBox.Show("Failed to save sales record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "POS", $"Save sale failed | TransID: {currentOrderID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub SaveToDailySalesSummary()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim checkSql As String = "SELECT 1 FROM `daily_sales_summary` WHERE `transaction_date` = CURDATE() AND `branch_id` = @BranchID AND `user_id` = @UserID LIMIT 1"
                Using cmdCheck As New MySqlCommand(checkSql, conn)
                    cmdCheck.Parameters.AddWithValue("@BranchID", UserBranchCode)
                    cmdCheck.Parameters.AddWithValue("@UserID", LoggedInUserID)
                    conn.Open()
                    Dim exists As Boolean = cmdCheck.ExecuteScalar() IsNot Nothing

                    If exists Then
                        Dim updSql As String = "
                        UPDATE `daily_sales_summary`
                        SET 
                            `transaction_id` = @TransID,
                            `total_transactions` = `total_transactions` + 1,
                            `total_sales` = `total_sales` + @SalesAmt,
                            `total_cash` = `total_cash` + @CashAmt,
                            `total_online` = `total_online` + @OnlineAmt,
                            `date_added` = NOW()
                        WHERE 
                            `transaction_date` = CURDATE() 
                            AND `branch_id` = @BranchID 
                            AND `user_id` = @UserID"
                        Using cmdUpd As New MySqlCommand(updSql, conn)
                            cmdUpd.Parameters.AddWithValue("@TransID", currentOrderID)
                            cmdUpd.Parameters.AddWithValue("@BranchID", UserBranchCode)
                            cmdUpd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                            cmdUpd.Parameters.AddWithValue("@SalesAmt", finalTotal)
                            cmdUpd.Parameters.AddWithValue("@CashAmt", cashAmount)
                            cmdUpd.Parameters.AddWithValue("@OnlineAmt", onlineAmount)
                            cmdUpd.ExecuteNonQuery()
                        End Using
                    Else
                        Dim insSql As String = "
                        INSERT INTO `daily_sales_summary` (
                            `transaction_id`, `account_id`, `branch_id`, `user_id`, `cashier_name`,
                            `transaction_date`, `total_transactions`, `total_sales`,
                            `total_cash`, `total_online`, `date_added`
                        )
                        VALUES (
                            @TransID, @AccountID, @BranchID, @UserID, @CashierName,
                            CURDATE(), 1, @SalesAmt,
                            @CashAmt, @OnlineAmt, NOW()
                        )"
                        Using cmdIns As New MySqlCommand(insSql, conn)
                            cmdIns.Parameters.AddWithValue("@TransID", currentOrderID)
                            cmdIns.Parameters.AddWithValue("@AccountID", BranchAccountID)
                            cmdIns.Parameters.AddWithValue("@BranchID", UserBranchCode)
                            cmdIns.Parameters.AddWithValue("@UserID", LoggedInUserID)
                            cmdIns.Parameters.AddWithValue("@CashierName", LoggedInUser)
                            cmdIns.Parameters.AddWithValue("@SalesAmt", finalTotal)
                            cmdIns.Parameters.AddWithValue("@CashAmt", cashAmount)
                            cmdIns.Parameters.AddWithValue("@OnlineAmt", onlineAmount)
                            cmdIns.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating daily sales summary: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ERROR", "POS", $"Daily summary error | TransID: {currentOrderID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("No items in the cart.", "Empty Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("CHECKOUT_FAIL", "POS", $"Checkout failed - empty cart | Cashier: {LoggedInUser}")
            Return
        End If

        Dim currentInput As Decimal = 0
        Decimal.TryParse(txtAmountInput.Text.Trim(), currentInput)
        Dim totalNowPaid As Decimal = Math.Round(totalPaid + currentInput, 2)

        If totalNowPaid < finalTotal Then
            Dim remaining As Decimal = Math.Round(finalTotal - totalNowPaid, 2)
            MessageBox.Show($"INSUFFICIENT PAYMENT{vbCrLf}{vbCrLf}Total Amount Due: ₱{finalTotal:N2}{vbCrLf}Amount Paid: ₱{totalNowPaid:N2}{vbCrLf}Remaining Balance: ₱{remaining:N2}{vbCrLf}{vbCrLf}Please enter the correct amount.", "Payment Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("CHECKOUT_FAIL", "POS", $"Insufficient payment | TransID: {currentOrderID} | Due: {finalTotal:N2} | Paid: {totalNowPaid:N2}")
            Return
        End If

        ' Idagdag ang huling bayad
        If currentInput > 0 Then
            Dim applyAmt As Decimal = Math.Min(currentInput, finalTotal - totalPaid)
            If applyAmt > 0 Then
                totalPaid = Math.Round(totalPaid + applyAmt, 2)
                paymentDetails.Add($"Cash: ₱{applyAmt:N2}")
            End If
            txtAmountInput.Clear()
        End If

        ' ✅ SIGURADUHIN MUNA ANG LAHAT NG HALAGA
        DeterminePaymentMethod()

        ' ✅ DITO NA KUNIN ANG SUKLI — HINDI NA MABABAGO KAHIT ANONG MANGYARI
        Dim finalChange As Decimal = Math.Max(0, totalPaid - finalTotal)

        DeductStockFromInventory()

        ' ✅ IPASA ANG TAMANG SUKLI
        SaveSalesTransaction(finalChange)
        SaveToDailySalesSummary()

        MessageBox.Show(rtbReceipt.Text, "Official Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AuditLogger.LogAction("TRANS_COMPLETE", "POS", $"Transaction completed | TransID: {currentOrderID} | Total: {finalTotal:N2} | Change: {finalChange:N2}")
        ResetAll()
    End Sub

    Private Sub DeductStockFromInventory()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                For Each row As DataGridViewRow In dgvCart.Rows
                    Dim barcode As String = row.Cells("Barcode").Value.ToString().Trim()
                    Dim qtySold As Integer = CInt(row.Cells("Qty").Value)
                    Dim updateQuery As String = "UPDATE `inventory_information` SET `AVAILABLE` = `AVAILABLE` - @qty WHERE TRIM(`BARCODE`) = @barcode AND TRIM(`BRANCH_ID`) = @branchId"
                    Using cmd As New MySqlCommand(updateQuery, conn)
                        cmd.Parameters.AddWithValue("@qty", qtySold)
                        cmd.Parameters.AddWithValue("@barcode", barcode.Trim())
                        cmd.Parameters.AddWithValue("@branchId", UserBranchCode.Trim())
                        cmd.ExecuteNonQuery()
                    End Using
                    AuditLogger.LogAction("STOCK_DEDUCT", "POS", $"Stock deducted | Barcode: {barcode} | Qty: {qtySold} | TransID: {currentOrderID}")
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Inventory Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "POS", $"Stock deduct error | TransID: {currentOrderID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnOnlinePayment_Click(sender As Object, e As EventArgs) Handles btnOnlinePayment.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("No transaction available for payment.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim remainingToPay As Decimal = Math.Round(finalTotal - totalPaid, 2)
        If remainingToPay <= 0 Then
            MessageBox.Show("This transaction is already fully paid.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        AuditLogger.LogAction("OPEN_ONLINE_PAY", "POS", $"Opened online payment | TransID: {currentOrderID} | Remaining: {remainingToPay:N2}")
        Using frmOnline As New frmOnlinePayment()
            frmOnline.TransID = currentOrderID
            frmOnline.RemainingBalance = remainingToPay
            If frmOnline.ShowDialog() = DialogResult.OK Then
                Dim payAmount As Decimal = Math.Min(Math.Round(frmOnline.PaidAmount, 2), remainingToPay)
                totalPaid = Math.Round(totalPaid + payAmount, 2)
                paymentDetails.Add($"{frmOnline.PaymentMethod}: ₱{payAmount:N2} | Ref: {If(String.IsNullOrEmpty(frmOnline.ReferenceNo), "None", frmOnline.ReferenceNo)}")
                AuditLogger.LogAction("ONLINE_PAY", "POS", $"Online payment added | TransID: {currentOrderID} | Method: {frmOnline.PaymentMethod} | Amount: {payAmount:N2} | Ref: {frmOnline.ReferenceNo}")
                RefreshDisplay()
            End If
        End Using
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("No items in the cart to apply discount.", "Empty Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        AuditLogger.LogAction("OPEN_DISC", "POS", $"Opened discount form | TransID: {currentOrderID}")
        Dim frmDisc As New frmPWDDiscount()
        frmDisc.TransactionTotal = totalAmount
        frmDisc.ORNumber = currentOrderID
        frmDisc.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to remove.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Remove selected item from cart?", "CodeNect System Alliance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim barcode As String = dgvCart.SelectedRows(0).Cells("Barcode").Value.ToString().Trim()
            Dim qty As Integer = CInt(dgvCart.SelectedRows(0).Cells("Qty").Value)
            dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
            ComputeTotal()
            AuditLogger.LogAction("REMOVE_ITEM", "POS", $"Item removed from cart | Barcode: {barcode} | Qty: {qty} | TransID: {currentOrderID}")
        End If
    End Sub

    Private Sub btnCancelTransaction_Click(sender As Object, e As EventArgs) Handles btnCancelTransaction.Click
        If MessageBox.Show("Cancel the entire transaction?", "CodeNect System Alliance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            AuditLogger.LogAction("CANCEL_TRANS", "POS", $"Transaction cancelled | TransID: {currentOrderID} | Total: {finalTotal:N2}")
            ResetAll()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit/logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetUserStatus("OFFLINE")
            Me.Hide()
            Login.Show()
        End If
    End Sub

    Private Sub ResetAll()
        dgvCart.Rows.Clear()
        btnCheckOut.Text = "0.00"
        lblChange.Text = "0.00"
        lblRemainingBalance.Text = ""
        lblRemainingBalance.Visible = False
        txtAmountInput.Clear()
        txtAmountInput.Enabled = False
        txtBarcode.Clear()
        txtBarcode.Focus()

        rtbReceipt.Clear()

        totalAmount = 0
        discountPercent = 0
        discountAmount = 0
        isVATExempt = False
        finalTotal = 0
        totalPaid = 0
        paymentDetails.Clear()
        cashAmount = 0
        onlineAmount = 0
        paymentMethod = "Cash"
        currentOrderID = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AuditLogger.LogAction("OPEN_CASH_DECL", "POS", "Opened Cash Declaration form")
        frmCash_Declaration.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AuditLogger.LogAction("OPEN_HOLD", "POS", $"Opened Hold Transaction | TransID: {currentOrderID}")
        frmHold_Transaction.Show()
        Me.Enabled = False
        frmHold_Transaction.TopMost = True
    End Sub

End Class