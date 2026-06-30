Public Class TRANSACTION_ID
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter a Transaction ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Uploads.TextBox1.Text = "" & Trim(TextBox1.Text)
        Me.Hide()
        Uploads.Show()

    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only numbers, backspace, delete, and space characters
        If Char.IsControl(e.KeyChar) Then
            ' Allow control characters (like backspace and delete)
            e.Handled = False
            Return
        End If
        ' Check if the character is a number or a valid control character
        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Delete) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = False
            Return
        End If
        ' If the character is not a number or valid control character, handle it
        ' by setting e.Handled to True and showing an error message
        ' This will prevent the character from being entered into the TextBox
        e.Handled = True
        ' Show an error message to the user
        MessageBox.Show("Alphabetical Letter is not Allowed. Please Input Transaction ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class