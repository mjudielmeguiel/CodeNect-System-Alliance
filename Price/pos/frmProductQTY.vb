Imports System.Data.SqlClient

Public Class frmProductQTY

    Public Property Barcode As String = ""
    Public Property Description As String = ""
    Public Property ProductSize As String = ""
    Public Property Price As Decimal = 0
    Public Property CurrentQty As Integer = 0

    Private Sub frmProductQTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProductName.Text = Description
        lblSize.Text = ProductSize
        lblPrice.Text = Price.ToString("N2")
        txtQty.Text = CurrentQty.ToString()

        ' Kunin ang kasalukuyang dami ng stock
        Try
            Using conn As New SqlConnection(modConnection.connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT AVAILABLE FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @b", conn)
                cmd.Parameters.AddWithValue("@b", Barcode.Trim())
                Dim stock As Object = cmd.ExecuteScalar()
                If stock IsNot Nothing Then
                    lblMaxStock.Text = $"Max na pwedeng ibenta: {CInt(stock)}"
                End If
            End Using
        Catch ex As Exception
            lblMaxStock.Text = "Hindi makuha ang stock"
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim newQty As Integer = 0
        If Not Integer.TryParse(txtQty.Text.Trim(), newQty) OrElse newQty <= 0 Then
            MessageBox.Show("Maglagay ng tamang bilang na mas mataas sa 0.", "Maling Bilang", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Suriin kung may sapat na stock
        Dim availableStock As Integer = 0
        Using conn As New SqlConnection(modConnection.connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT AVAILABLE FROM inv.Inventory_Master_file WHERE RTRIM(LTRIM(BARCODE)) = @b", conn)
            cmd.Parameters.AddWithValue("@b", Barcode.Trim())
            Dim stockObj As Object = cmd.ExecuteScalar()
            If stockObj IsNot Nothing Then
                availableStock = CInt(stockObj)
            End If
        End Using

        If newQty > availableStock Then
            MessageBox.Show($"❌ Sobra sa dami!{vbCrLf}May natitira lang na: {availableStock} piraso", "Hindi Sapat na Stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        CurrentQty = newQty
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class