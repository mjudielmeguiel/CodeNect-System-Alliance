Public Class frmCash_Declaration

    Private Sub txtDenomination_TextChanged(sender As Object, e As EventArgs) Handles _
        txt1000.TextChanged,
        txt500.TextChanged,
        txt200.TextChanged,
        txt100.TextChanged,
        txt50.TextChanged,
        txt20.TextChanged,
        txt10.TextChanged,
        txt5.TextChanged,
        txt1.TextChanged,
        txt25c.TextChanged,
        txt10c.TextChanged,
        txt1c.TextChanged

        Dim total As Decimal = 0D

        Dim c1000 As Integer = If(Integer.TryParse(txt1000.Text.Trim, c1000), c1000, 0)
        Dim amt1000 As Decimal = c1000 * 1000D
        lblAmt1000.Text = amt1000.ToString("N2")
        total += amt1000

        Dim c500 As Integer = If(Integer.TryParse(txt500.Text.Trim, c500), c500, 0)
        Dim amt500 As Decimal = c500 * 500D
        lblAmt500.Text = amt500.ToString("N2")
        total += amt500

        Dim c200 As Integer = If(Integer.TryParse(txt200.Text.Trim, c200), c200, 0)
        Dim amt200 As Decimal = c200 * 200D
        lblAmt200.Text = amt200.ToString("N2")
        total += amt200

        Dim c100 As Integer = If(Integer.TryParse(txt100.Text.Trim, c100), c100, 0)
        Dim amt100 As Decimal = c100 * 100D
        lblAmt100.Text = amt100.ToString("N2")
        total += amt100

        Dim c50 As Integer = If(Integer.TryParse(txt50.Text.Trim, c50), c50, 0)
        Dim amt50 As Decimal = c50 * 50D
        lblAmt50.Text = amt50.ToString("N2")
        total += amt50

        Dim c20 As Integer = If(Integer.TryParse(txt20.Text.Trim, c20), c20, 0)
        Dim amt20 As Decimal = c20 * 20D
        lblAmt20.Text = amt20.ToString("N2")
        total += amt20

        Dim c10 As Integer = If(Integer.TryParse(txt10.Text.Trim, c10), c10, 0)
        Dim amt10 As Decimal = c10 * 10D
        lblAmt10.Text = amt10.ToString("N2")
        total += amt10

        Dim c5 As Integer = If(Integer.TryParse(txt5.Text.Trim, c5), c5, 0)
        Dim amt5 As Decimal = c5 * 5D
        lblAmt5.Text = amt5.ToString("N2")
        total += amt5

        Dim c1 As Integer = If(Integer.TryParse(txt1.Text.Trim, c1), c1, 0)
        Dim amt1 As Decimal = c1 * 1D
        lblAmt1.Text = amt1.ToString("N2")
        total += amt1

        Dim c25c As Integer = If(Integer.TryParse(txt25c.Text.Trim, c25c), c25c, 0)
        Dim amt25c As Decimal = c25c * 0.25D
        lblAmt25c.Text = amt25c.ToString("N2")
        total += amt25c

        Dim c10c As Integer = If(Integer.TryParse(txt10c.Text.Trim, c10c), c10c, 0)
        Dim amt10c As Decimal = c10c * 0.1D
        lblAmt10c.Text = amt10c.ToString("N2")
        total += amt10c

        Dim c1c As Integer = If(Integer.TryParse(txt1c.Text.Trim, c1c), c1c, 0)
        Dim amt1c As Decimal = c1c * 0.01D
        lblAmt1c.Text = amt1c.ToString("N2")
        total += amt1c

        lblTotal.Text = total.ToString("N2")
    End Sub

    Private Sub btnDeclare_Click(sender As Object, e As EventArgs) Handles btnDeclare.Click
        Dim totalAmount As Decimal = 0D
        Decimal.TryParse(lblTotal.Text, totalAmount)

        If totalAmount <= 0 Then
            MessageBox.Show("Please enter at least one denomination before declaring.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("DECLARE_FAILED", "Cash Declaration", "Attempted declaration with zero total amount")
            Return
        End If

        If MessageBox.Show($"Total Amount: ₱{totalAmount:N2}{Environment.NewLine}Confirm this declaration?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            MessageBox.Show("Cash Declaration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("DECLARE", "Cash Declaration", $"Declared total amount: ₱{totalAmount:N2}")
            ClearAll()
        Else
            AuditLogger.LogAction("CANCEL", "Cash Declaration", "User cancelled declaration confirmation")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Are you sure you want to close? Unsaved data will be lost.",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            AuditLogger.LogAction("CLOSE", "Cash Declaration", "Closed form - unsaved data discarded")
            Me.Close()
        End If
    End Sub

    Private Sub ClearAll()
        txt1000.Clear()
        txt500.Clear()
        txt200.Clear()
        txt100.Clear()
        txt50.Clear()
        txt20.Clear()
        txt10.Clear()
        txt5.Clear()
        txt1.Clear()
        txt25c.Clear()
        txt10c.Clear()
        txt1c.Clear()

        lblAmt1000.Text = "0.00"
        lblAmt500.Text = "0.00"
        lblAmt200.Text = "0.00"
        lblAmt100.Text = "0.00"
        lblAmt50.Text = "0.00"
        lblAmt20.Text = "0.00"
        lblAmt10.Text = "0.00"
        lblAmt5.Text = "0.00"
        lblAmt1.Text = "0.00"
        lblAmt25c.Text = "0.00"
        lblAmt10c.Text = "0.00"
        lblAmt1c.Text = "0.00"

        lblTotal.Text = "0.00"
    End Sub

    Private Sub frmCash_Declaration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearAll()
        AuditLogger.LogAction("OPEN", "Cash Declaration", "Opened Cash Declaration form")
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        txt1000.KeyPress, txt500.KeyPress, txt200.KeyPress, txt100.KeyPress,
        txt50.KeyPress, txt20.KeyPress, txt10.KeyPress, txt5.KeyPress,
        txt1.KeyPress, txt25c.KeyPress, txt10c.KeyPress, txt1c.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

End Class