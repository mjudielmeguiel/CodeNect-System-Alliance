Imports MySqlConnector

Public Class frmOnlinePayment

    Public Property TransID As String = ""
    Public Property RemainingBalance As Decimal = 0
    Public Property PaidAmount As Decimal = 0
    Public Property PaymentMethod As String = ""
    Public Property ReferenceNo As String = ""
    Public Property SenderName As String = ""
    Public Property Remarks As String = ""

    Private Sub frmOnlinePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTransactionID.Text = TransID
        lblTotalDue.Text = RemainingBalance.ToString("N2")

        cboPaymentMethod.Items.Clear()
        cboPaymentMethod.Items.AddRange({"GCash", "Maya", "Bank Transfer", "Credit Card", "Debit Card"})
        If cboPaymentMethod.Items.Count > 0 Then cboPaymentMethod.SelectedIndex = 0

        txtAmountPaid.Text = "0.00"
        txtReferenceNumber.Clear()
        txtSender.Clear()
        rtbremarks.Clear()
        txtAmountPaid.Focus()
        Me.TopMost = True

        AuditLogger.LogAction("OPEN", "Payments", $"Opened Online Payment form | TransID: {TransID} | Balance: {RemainingBalance:N2}")
    End Sub

    Private Sub txtAmountPaid_Leave(sender As Object, e As EventArgs) Handles txtAmountPaid.Leave
        Dim inputAmt As Decimal = 0
        If Decimal.TryParse(txtAmountPaid.Text.Trim(), inputAmt) Then
            If inputAmt > RemainingBalance Then
                MessageBox.Show($"Maaaring magbayad hanggang ₱{RemainingBalance:N2} lang.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Information)
                inputAmt = RemainingBalance
                AuditLogger.LogAction("VALIDATION", "Payments", $"Payment amount capped to balance | TransID: {TransID}")
            End If
            txtAmountPaid.Text = inputAmt.ToString("N2")
        Else
            txtAmountPaid.Text = "0.00"
        End If
    End Sub

    Private Sub txtAmountPaid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountPaid.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." AndAlso txtAmountPaid.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        txtAmountPaid_Leave(Nothing, Nothing)

        If String.IsNullOrWhiteSpace(cboPaymentMethod.Text) Then
            MessageBox.Show("Pumili muna ng paraan ng pagbabayad.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("SAVE_FAILED", "Payments", $"No payment method selected | TransID: {TransID}")
            Return
        End If

        Dim inputAmt As Decimal
        If Not Decimal.TryParse(txtAmountPaid.Text.Trim(), inputAmt) OrElse inputAmt <= 0 Then
            MessageBox.Show("Maglagay ng tamang halaga na mas mataas sa 0.", "Maling Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmountPaid.SelectAll()
            AuditLogger.LogAction("SAVE_FAILED", "Payments", $"Invalid/zero amount entered | TransID: {TransID}")
            Return
        End If

        PaidAmount = inputAmt
        PaymentMethod = cboPaymentMethod.Text.Trim()
        ReferenceNo = txtReferenceNumber.Text.Trim()
        SenderName = txtSender.Text.Trim()
        Remarks = rtbremarks.Text.Trim()

        If SavePaymentToDatabase() Then
            AuditLogger.LogAction("INSERT", "Payments", $"Payment saved | TransID: {TransID} | Method: {PaymentMethod} | Amount: {PaidAmount:N2} | Ref: {ReferenceNo}")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        AuditLogger.LogAction("CANCEL", "Payments", $"Payment cancelled | TransID: {TransID}")
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        Me.TopMost = False
    End Sub

    Private Function SavePaymentToDatabase() As Boolean
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "
                    INSERT INTO `payments` (
                        `ACCOUNT_ID`, `BRANCH_ID`, `TRANSACTION_ID`, `User_ID`,
                        `AmountPaid`, `PaymentMethod`, `ReferenceNumber`, `Sender`,
                        `Remarks`, `PaymentDate`, `Status`
                    ) VALUES (
                        @AccountID, @BranchID, @TransID, @UserID,
                        @Amount, @Method, @RefNo, @Sender,
                        @Remarks, NOW(), 'Completed'
                    )"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountID", Login.LoggedInAccountID)
                    cmd.Parameters.AddWithValue("@BranchID", Login.LoggedInBranchID)
                    cmd.Parameters.AddWithValue("@TransID", TransID)
                    cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
                    cmd.Parameters.AddWithValue("@Amount", PaidAmount)
                    cmd.Parameters.AddWithValue("@Method", PaymentMethod)
                    cmd.Parameters.AddWithValue("@RefNo", If(String.IsNullOrWhiteSpace(ReferenceNo), DBNull.Value, ReferenceNo))
                    cmd.Parameters.AddWithValue("@Sender", If(String.IsNullOrWhiteSpace(SenderName), DBNull.Value, SenderName))
                    cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrWhiteSpace(Remarks), DBNull.Value, Remarks))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Error saving payment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Payments", $"Save failed | TransID: {TransID} | Error: {ex.Message}")
            Return False
        End Try
    End Function

End Class