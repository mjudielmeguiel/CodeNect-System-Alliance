Public Class frmSetQuantity

    Public Property NewQuantity As Integer = 0

    Public Sub New(productName As String, currentQty As Integer)
        InitializeComponent()
        lblProduct.Text = productName
        txtQuantity.Text = currentQty.ToString()
        NewQuantity = currentQty

        txtQuantity.Focus()
        txtQuantity.SelectAll()
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If Integer.TryParse(txtQuantity.Text, NewQuantity) AndAlso NewQuantity >= 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please enter a valid number (0 or higher).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.SelectAll()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmSetQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class