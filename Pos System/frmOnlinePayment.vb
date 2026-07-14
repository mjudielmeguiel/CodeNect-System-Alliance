Imports System.Data.SqlClient

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
    End Sub

    Private Sub txtAmountPaid_Leave(sender As Object, e As EventArgs) Handles txtAmountPaid.Leave
        Dim inputAmt As Decimal = 0
        If Decimal.TryParse(txtAmountPaid.Text.Trim(), inputAmt) Then
            If inputAmt > RemainingBalance Then
                MessageBox.Show($"Maaaring magbayad hanggang ₱{RemainingBalance:N2} lang.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Information)
                inputAmt = RemainingBalance
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
            Return
        End If

        Dim inputAmt As Decimal
        If Not Decimal.TryParse(txtAmountPaid.Text.Trim(), inputAmt) OrElse inputAmt <= 0 Then
            MessageBox.Show("Maglagay ng tamang halaga na mas mataas sa 0.", "Maling Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmountPaid.SelectAll()
            Return
        End If

        PaidAmount = inputAmt
        PaymentMethod = cboPaymentMethod.Text.Trim()
        ReferenceNo = txtReferenceNumber.Text.Trim()
        SenderName = txtSender.Text.Trim()
        Remarks = rtbremarks.Text.Trim()

        If SavePaymentToDatabase() Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        Me.TopMost = False
    End Sub

    Private Function SavePaymentToDatabase() As Boolean
        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                Dim sql As String = "
                    INSERT INTO dbo.Payments (
                        OrderID, PaymentMethod, ReferenceNumber, AmountPaid, Sender, Remarks, PaymentDate, Status
                    ) VALUES (
                        @OrderID, @Method, @RefNo, @Amount, @Sender, @Remarks, GETDATE(), 'Completed'
                    )"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@OrderID", TransID)
                    cmd.Parameters.AddWithValue("@Method", PaymentMethod)
                    cmd.Parameters.AddWithValue("@RefNo", If(String.IsNullOrWhiteSpace(ReferenceNo), DBNull.Value, ReferenceNo))
                    cmd.Parameters.AddWithValue("@Amount", PaidAmount)
                    cmd.Parameters.AddWithValue("@Sender", If(String.IsNullOrWhiteSpace(SenderName), DBNull.Value, SenderName))
                    cmd.Parameters.AddWithValue("@Remarks", If(String.IsNullOrWhiteSpace(Remarks), DBNull.Value, Remarks))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Error saving payment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class