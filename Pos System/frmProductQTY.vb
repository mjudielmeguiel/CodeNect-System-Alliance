Imports System.Data.SqlClient

Public Class frmProductQTY

    Public Property Barcode As String = ""
    Public Property CurrentQty As Integer = 0

    Private Sub frmProductQTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQty.Text = CurrentQty.ToString()

        Me.TopMost = True
        txtQty.SelectAll()
        txtQty.Focus()

        LoadStock()
    End Sub

    Private Sub LoadStock()
        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT ISNULL(AVAILABLE, 0) FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @Barcode", conn)
                cmd.Parameters.Add("@Barcode", SqlDbType.VarChar, 100).Value = Barcode.Trim()

                Dim result As Object = cmd.ExecuteScalar()
                Dim availableStock As Integer = If(result IsNot Nothing, CInt(result), 0)

                lblMaxStock.Text = $"Maximum quantity available: {availableStock}"
            End Using
        Catch ex As Exception
            lblMaxStock.Text = "Error loading stock"
        End Try
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnConfirm.PerformClick()
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim newQty As Integer = 0
        If Not Integer.TryParse(txtQty.Text.Trim(), newQty) OrElse newQty <= 0 Then
            MessageBox.Show("Please enter a valid quantity greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.SelectAll()
            txtQty.Focus()
            Return
        End If

        Dim availableStock As Integer = 0
        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT ISNULL(AVAILABLE, 0) FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @Barcode", conn)
                cmd.Parameters.Add("@Barcode", SqlDbType.VarChar, 100).Value = Barcode.Trim()

                Dim result As Object = cmd.ExecuteScalar()
                availableStock = If(result IsNot Nothing, CInt(result), 0)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If newQty > availableStock Then
            MessageBox.Show($"Quantity exceeds available stock!{vbCrLf}Only {availableStock} item(s) in stock.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtQty.SelectAll()
            txtQty.Focus()
            Return
        End If

        CurrentQty = newQty
        Me.DialogResult = DialogResult.OK
        Me.TopMost = False
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.TopMost = False
        Me.Close()
    End Sub

End Class