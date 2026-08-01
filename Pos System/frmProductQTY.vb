Imports MySqlConnector

Public Class frmProductQTY

    Public Property Barcode As String = ""
    Public Property CurrentQty As Integer = 0

    Private Sub frmProductQTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQty.Text = CurrentQty.ToString()

        Me.TopMost = True
        txtQty.SelectAll()
        txtQty.Focus()

        LoadStock()
        AuditLogger.LogAction("OPEN_QTY", "ProductQty", $"Opened quantity editor | Barcode: {Barcode} | Current Qty: {CurrentQty}")
    End Sub

    Private Sub LoadStock()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT IFNULL(`AVAILABLE`, 0) FROM `Inventory_Master_file` WHERE TRIM(`BARCODE`) = @Barcode", conn)
                cmd.Parameters.AddWithValue("@Barcode", Barcode.Trim())

                Dim result As Object = cmd.ExecuteScalar()
                Dim availableStock As Integer = If(result IsNot Nothing, CInt(result), 0)

                lblMaxStock.Text = $"Maximum quantity available: {availableStock}"
            End Using
        Catch ex As Exception
            lblMaxStock.Text = "Error loading stock"
            AuditLogger.LogAction("ERROR", "ProductQty", $"Load stock failed | Barcode: {Barcode} | Error: {ex.Message}")
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
            AuditLogger.LogAction("QTY_INVALID", "ProductQty", $"Invalid quantity entered | Barcode: {Barcode} | Input: {txtQty.Text.Trim()}")
            txtQty.SelectAll()
            txtQty.Focus()
            Return
        End If

        Dim availableStock As Integer = 0
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT IFNULL(`AVAILABLE`, 0) FROM `Inventory_Master_file` WHERE TRIM(`BARCODE`) = @Barcode", conn)
                cmd.Parameters.AddWithValue("@Barcode", Barcode.Trim())

                Dim result As Object = cmd.ExecuteScalar()
                availableStock = If(result IsNot Nothing, CInt(result), 0)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "ProductQty", $"Check stock failed | Barcode: {Barcode} | Error: {ex.Message}")
            Return
        End Try

        If newQty > availableStock Then
            MessageBox.Show($"Quantity exceeds available stock!{vbCrLf}Only {availableStock} item(s) in stock.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            AuditLogger.LogAction("QTY_EXCEED", "ProductQty", $"Quantity exceeds stock | Barcode: {Barcode} | Requested: {newQty} | Available: {availableStock}")
            txtQty.SelectAll()
            txtQty.Focus()
            Return
        End If

        CurrentQty = newQty
        AuditLogger.LogAction("QTY_CONFIRM", "ProductQty", $"Quantity updated | Barcode: {Barcode} | Old: {CurrentQty} → New: {newQty}")
        Me.DialogResult = DialogResult.OK
        Me.TopMost = False
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        AuditLogger.LogAction("QTY_CANCEL", "ProductQty", $"Quantity edit cancelled | Barcode: {Barcode}")
        Me.DialogResult = DialogResult.Cancel
        Me.TopMost = False
        Me.Close()
    End Sub

End Class