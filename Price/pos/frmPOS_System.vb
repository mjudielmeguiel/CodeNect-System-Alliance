Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class frmPOS_System

    Public totalAmount As Decimal = 0
    Public discountPercent As Decimal = 0
    Public discountAmount As Decimal = 0
    Public isVATExempt As Boolean = False
    Private Const VAT_RATE As Decimal = 0.12D
    Private currentOrderID As String = ""
    Public LoggedInUser As String = ""

    Private finalTotal As Decimal = 0
    Private totalPaid As Decimal = 0
    Private paymentDetails As New List(Of String)()

    Private Sub POS_System_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        SetupGrid()
        txtBarcode.Clear()
        txtBarcode.Focus()

        LoggedInUser = frmPOSLogin.txtUsername.Text.Trim()
        txtAmountInput.Enabled = False

        ' Reset all labels
        lblTransactionID.Text = "-"
        lblProductName.Text = "-"
        lblSize.Text = "-"
        lblPrice.Text = "-"
        lblQty.Text = "-"
        lblTotal.Text = "0.00"
        lblDiscountAmount.Text = "0.00"
        lblDiscountedTotal.Text = "0.00"
        lblVAT.Text = "0.00"
        lblTotalAmount.Text = "0.00"
        lblAmountPaid.Text = "0.00"
        lblRemainingBalance.Text = "0.00"
        lblChange.Text = "0.00"
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
            Using conn As New SqlConnection(modConnection.connStr)
                Dim sql As String = "SELECT BARCODE, DESCRIPTIONS, SIZE, PRICE, AVAILABLE FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @bcode"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@bcode", barcode.Trim())
                    conn.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Dim stockAvailable As Integer = CInt(dr("AVAILABLE"))
                            Dim existingRow As DataGridViewRow = Nothing

                            ' Check if product is already in cart
                            For Each row As DataGridViewRow In dgvCart.Rows
                                If row.Cells("Barcode").Value.ToString().Trim().ToUpper() = barcode.Trim().ToUpper() Then
                                    existingRow = row
                                    Exit For
                                End If
                            Next

                            If existingRow IsNot Nothing Then
                                ' If exists, increase quantity
                                Dim currentQty As Integer = CInt(existingRow.Cells("Qty").Value)
                                Dim newQty As Integer = currentQty + 1

                                ' Check if enough stock is available
                                If newQty > stockAvailable Then
                                    MessageBox.Show($"⚠️ Cannot add more!{vbCrLf}Remaining stock: {stockAvailable} piece(s)", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Return
                                End If

                                existingRow.Cells("Qty").Value = newQty
                                existingRow.Cells("SubTotal").Value = Math.Round(CDec(existingRow.Cells("Price").Value) * newQty, 2)

                            Else
                                ' Check stock before adding new product
                                If stockAvailable <= 0 Then
                                    MessageBox.Show($"❌ OUT OF STOCK!{vbCrLf}Product: {dr("DESCRIPTIONS").ToString()}", "No Stock Available", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Return
                                ElseIf stockAvailable = 1 Then
                                    MessageBox.Show($"⚠️ NOTICE: Only 1 piece left in stock for this product.", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ElseIf stockAvailable <= 5 Then
                                    MessageBox.Show($"⚠️ NOTICE: Only {stockAvailable} piece(s) left in stock for this product.", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                ' Add product to cart
                                Dim price As Decimal = CDec(dr("PRICE"))
                                dgvCart.Rows.Add(dr("BARCODE"), dr("DESCRIPTIONS"), dr("SIZE"), price, 1, price)
                            End If

                            ' Display product details on the right panel
                            lblProductName.Text = dr("DESCRIPTIONS").ToString()
                            lblSize.Text = dr("SIZE").ToString()
                            lblPrice.Text = CDec(dr("PRICE")).ToString("N2")
                            lblQty.Text = "1"

                            ComputeTotal()

                            ' Generate Transaction ID if it's the first item
                            If dgvCart.Rows.Count = 1 Then
                                currentOrderID = New Random().Next(10000000, 99999999).ToString()
                                lblTransactionID.Text = currentOrderID
                                txtAmountInput.Enabled = True
                            End If

                        Else
                            MessageBox.Show("❌ Product not found in inventory.", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCart_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCart.Rows(e.RowIndex)
            lblProductName.Text = row.Cells("ProductName").Value.ToString()
            lblSize.Text = row.Cells("Size").Value.ToString()
            lblPrice.Text = CDec(row.Cells("Price").Value).ToString("N2")
            lblQty.Text = row.Cells("Qty").Value.ToString()
        End If
    End Sub

    Private Sub dgvCart_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvCart.Rows(e.RowIndex)

        Using frmQty As New frmProductQTY()
            frmQty.Barcode = row.Cells("Barcode").Value.ToString().Trim()
            frmQty.Description = row.Cells("ProductName").Value.ToString()
            frmQty.ProductSize = row.Cells("Size").Value.ToString()
            frmQty.Price = CDec(row.Cells("Price").Value)
            frmQty.CurrentQty = CInt(row.Cells("Qty").Value)

            If frmQty.ShowDialog() = DialogResult.OK Then
                Dim newQuantity As Integer = frmQty.CurrentQty
                Dim price As Decimal = CDec(row.Cells("Price").Value)

                ' Update quantity and subtotal
                row.Cells("Qty").Value = newQuantity
                row.Cells("SubTotal").Value = Math.Round(price * newQuantity, 2)

                ' Update right-side labels
                lblQty.Text = newQuantity.ToString()
                lblTotal.Text = CDec(row.Cells("SubTotal").Value).ToString("N2")

                ' Recalculate transaction totals
                ComputeTotal()
            End If
        End Using
    End Sub

    Public Sub ApplyPWDDiscount(discountPercentValue As Integer, vatExemptStatus As Boolean)
        discountPercent = discountPercentValue
        isVATExempt = vatExemptStatus
        ComputeTotal()
    End Sub

    Public Sub ComputeTotal()
        Dim subtotal As Decimal = 0
        For Each row As DataGridViewRow In dgvCart.Rows
            subtotal += CDec(row.Cells("SubTotal").Value)
        Next

        totalAmount = subtotal
        Dim vatableAmount As Decimal = totalAmount
        Dim vatAmount As Decimal = 0

        If isVATExempt Then
            vatableAmount = totalAmount / 1.12
            vatAmount = 0
        Else
            vatAmount = Math.Round(totalAmount - (totalAmount / 1.12), 2)
        End If

        discountAmount = Math.Round(vatableAmount * (discountPercent / 100), 2)
        finalTotal = Math.Round(vatableAmount - discountAmount, 2)

        lblTotal.Text = totalAmount.ToString("N2")
        lblVAT.Text = vatAmount.ToString("N2")
        lblDiscountAmount.Text = discountAmount.ToString("N2")
        lblDiscountedTotal.Text = finalTotal.ToString("N2")
        lblTotalAmount.Text = finalTotal.ToString("N2")

        UpdatePaymentDisplay()
    End Sub

    Private Sub txtAmountInput_TextChanged(sender As Object, e As EventArgs) Handles txtAmountInput.TextChanged
        If finalTotal <= 0 Then
            lblChange.Text = "0.00"
            lblRemainingBalance.Text = "0.00"
            Return
        End If

        Dim inputAmt As Decimal = 0
        Decimal.TryParse(txtAmountInput.Text, inputAmt)
        Dim totalNowPaid As Decimal = Math.Round(totalPaid + inputAmt, 2)

        lblRemainingBalance.Text = Math.Max(0, finalTotal - totalNowPaid).ToString("N2")
        lblChange.Text = Math.Max(0, totalNowPaid - finalTotal).ToString("N2")
        lblAmountPaid.Text = totalNowPaid.ToString("N2")
    End Sub

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
        If Not Decimal.TryParse(txtAmountInput.Text, inputAmt) OrElse inputAmt <= 0 Then
            MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        totalPaid = Math.Round(totalPaid + inputAmt, 2)
        paymentDetails.Add($"Cash: ₱{inputAmt:N2}")
        UpdatePaymentDisplay()
        txtAmountInput.Clear()
    End Sub

    Private Sub UpdatePaymentDisplay()
        Dim currentInput As Decimal = 0
        Decimal.TryParse(txtAmountInput.Text, currentInput)
        Dim totalNowPaid As Decimal = Math.Round(totalPaid + currentInput, 2)
        lblRemainingBalance.Text = Math.Max(0, finalTotal - totalNowPaid).ToString("N2")
        lblChange.Text = Math.Max(0, totalNowPaid - finalTotal).ToString("N2")
        lblAmountPaid.Text = totalNowPaid.ToString("N2")
    End Sub

    Private Sub DeductStockFromInventory()
        Try
            Using conn As New SqlConnection(modConnection.connStr)
                conn.Open()
                For Each row As DataGridViewRow In dgvCart.Rows
                    Dim barcode As String = row.Cells("Barcode").Value.ToString().Trim()
                    Dim qtySold As Integer = CInt(row.Cells("Qty").Value)

                    Dim updateQuery As String = "UPDATE inv.Inventory_Master_file 
                                             SET AVAILABLE = AVAILABLE - @qty 
                                             WHERE RTRIM(LTRIM(BARCODE)) = @barcode"

                    Using cmd As New SqlCommand(updateQuery, conn)
                        cmd.Parameters.AddWithValue("@qty", qtySold)
                        cmd.Parameters.AddWithValue("@barcode", barcode.Trim())

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected = 0 Then
                            Dim checkCmd As New SqlCommand("SELECT AVAILABLE FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @b", conn)
                            checkCmd.Parameters.AddWithValue("@b", barcode.Trim())
                            Dim available As Object = checkCmd.ExecuteScalar()

                            If available IsNot Nothing AndAlso CInt(available) < qtySold Then
                                MessageBox.Show($"⚠️ Insufficient stock for: {barcode}{vbCrLf}Available: {available}, Required: {qtySold}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End Using
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Inventory Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If dgvCart.Rows.Count = 0 Then
            MessageBox.Show("No items in the cart.", "Empty Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim currentInput As Decimal = 0
        Decimal.TryParse(txtAmountInput.Text, currentInput)
        Dim totalNowPaid As Decimal = Math.Round(totalPaid + currentInput, 2)

        If totalNowPaid < finalTotal Then
            Dim remaining As Decimal = Math.Round(finalTotal - totalNowPaid, 2)
            MessageBox.Show($"Amount still needed: ₱{remaining:N2}", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim changeAmount As Decimal = Math.Max(0, Math.Round(totalNowPaid - finalTotal, 2))

        If currentInput > 0 Then
            Dim cashToRecord As Decimal = Math.Round(currentInput - changeAmount, 2)
            If cashToRecord > 0 Then
                totalPaid = Math.Round(totalPaid + cashToRecord, 2)
                paymentDetails.Add($"Cash: ₱{cashToRecord:N2}")
            End If
            txtAmountInput.Clear()
        End If

        UpdatePaymentDisplay()
        DeductStockFromInventory()

        Dim receipt As New Text.StringBuilder()
        receipt.AppendLine("==============================")
        receipt.AppendLine("            RECEIPT           ")
        receipt.AppendLine("==============================")
        receipt.AppendLine($"Transaction #: {currentOrderID}")
        receipt.AppendLine($"Cashier: {LoggedInUser}")
        receipt.AppendLine($"Date: {Now.ToString("yyyy-MM-dd HH:mm")}")
        receipt.AppendLine("------------------------------")

        For Each row As DataGridViewRow In dgvCart.Rows
            receipt.AppendLine($"{row.Cells("ProductName").Value} ({row.Cells("Size").Value})")
            receipt.AppendLine($"{row.Cells("Qty").Value} x ₱{CDec(row.Cells("Price").Value):N2} = ₱{CDec(row.Cells("SubTotal").Value):N2}")
        Next

        receipt.AppendLine("------------------------------")
        receipt.AppendLine($"Subtotal: ₱{totalAmount:N2}")
        receipt.AppendLine($"VAT (12%): ₱{Math.Round(totalAmount - (totalAmount / 1.12), 2):N2}")
        receipt.AppendLine($"Discount: ₱{discountAmount:N2}")
        receipt.AppendLine($"TOTAL AMOUNT: ₱{finalTotal:N2}")
        receipt.AppendLine("------------------------------")
        receipt.AppendLine("PAYMENT DETAILS:")

        For Each payment In paymentDetails
            receipt.AppendLine(payment)
        Next

        receipt.AppendLine("------------------------------")
        receipt.AppendLine($"TOTAL PAID: ₱{finalTotal:N2}")
        receipt.AppendLine($"CHANGE: ₱{changeAmount:N2}")
        receipt.AppendLine("==============================")
        receipt.AppendLine("Thank you for your purchase!")
        receipt.AppendLine("==============================")

        MessageBox.Show(receipt.ToString(), "Official Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ResetAll()
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

        Using frmOnline As New frmOnlinePayment()
            frmOnline.TransID = currentOrderID
            frmOnline.RemainingBalance = remainingToPay

            If frmOnline.ShowDialog() = DialogResult.OK Then
                Dim payAmount As Decimal = Math.Min(Math.Round(frmOnline.PaidAmount, 2), remainingToPay)
                totalPaid = Math.Round(totalPaid + payAmount, 2)

                paymentDetails.Add($"{frmOnline.PaymentMethod}: ₱{payAmount:N2} | Ref: {If(String.IsNullOrEmpty(frmOnline.ReferenceNo), "None", frmOnline.ReferenceNo)} | Sender: {frmOnline.SenderName}")
                UpdatePaymentDisplay()

                Dim newRemaining As Decimal = Math.Round(finalTotal - totalPaid, 2)

                MessageBox.Show(
                $"✅ Payment recorded{vbCrLf}" &
                $"Amount: ₱ {payAmount:N2}{vbCrLf}" &
                $"Method: {frmOnline.PaymentMethod}{vbCrLf}" &
                $"Ref #: {If(String.IsNullOrEmpty(frmOnline.ReferenceNo), "None", frmOnline.ReferenceNo)}{vbCrLf}" &
                $"Remaining Balance: ₱ {newRemaining:N2}{vbCrLf}" &
                $"Click CHECK OUT once payment is complete.",
                "Partial Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        Dim frmDisc As New frmPWDDiscount()
        frmDisc.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvCart.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to remove.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Remove selected item from cart?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            dgvCart.Rows.Remove(dgvCart.SelectedRows(0))
            ComputeTotal()
        End If
    End Sub

    Private Sub btnCancelTransaction_Click(sender As Object, e As EventArgs) Handles btnCancelTransaction.Click
        If MessageBox.Show("Cancel the entire transaction?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ResetAll()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub ResetAll()
        dgvCart.Rows.Clear()
        lblTransactionID.Text = "-"
        lblProductName.Text = "-"
        lblSize.Text = "-"
        lblPrice.Text = "-"
        lblQty.Text = "-"
        lblTotal.Text = "0.00"
        lblDiscountAmount.Text = "0.00"
        lblDiscountedTotal.Text = "0.00"
        lblVAT.Text = "0.00"
        lblTotalAmount.Text = "0.00"
        lblAmountPaid.Text = "0.00"
        lblRemainingBalance.Text = "0.00"
        lblChange.Text = "0.00"
        txtAmountInput.Clear()
        txtAmountInput.Enabled = False
        txtBarcode.Clear()
        txtBarcode.Focus()

        totalAmount = 0
        discountPercent = 0
        discountAmount = 0
        isVATExempt = False
        finalTotal = 0
        totalPaid = 0
        paymentDetails.Clear()
        currentOrderID = ""
    End Sub

End Class