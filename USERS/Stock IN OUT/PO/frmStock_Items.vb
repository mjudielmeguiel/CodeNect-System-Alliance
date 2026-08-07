Imports MySqlConnector
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmStock_Items
    Public Property SelectedPONumber As String = Nothing
    Private userAccountID As String = Nothing
    Private userBranchID As String = Nothing
    Private isTransactionComplete As Boolean = False

    Private Sub frmStock_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userAccountID = If(DBConnection.CurrentUserAccountID IsNot Nothing, DBConnection.CurrentUserAccountID.Trim(), "")
        userBranchID = If(DBConnection.CurrentUserBranchID IsNot Nothing, DBConnection.CurrentUserBranchID.Trim(), "")

        dgvItems.AutoGenerateColumns = False
        dgvItems.ReadOnly = False
        dgvItems.AllowUserToAddRows = False
        dgvItems.Columns.Clear()

        dgvItems.Columns.Add("BARCODE", "Barcode")
        dgvItems.Columns.Add("BRAND", "Brand")
        dgvItems.Columns.Add("DESCRIPTIONS", "Product Name")
        dgvItems.Columns.Add("ORDER_QTY", "Ordered Qty")
        dgvItems.Columns.Add("SIZE", "Size")
        dgvItems.Columns.Add("SKU", "SKU")
        dgvItems.Columns.Add("PRICE", "Unit Price")
        dgvItems.Columns.Add("STOCK_IN", "Stock In")
        dgvItems.Columns.Add("STATUS", "Status")

        For Each col As DataGridViewColumn In dgvItems.Columns
            col.ReadOnly = True
        Next
        dgvItems.Columns("STOCK_IN").ReadOnly = False

        lblMessage.Text = ""
        btnReceive.Enabled = False
        txtSearch.Clear()
        isTransactionComplete = False

        LoadAllProductsFromPO()
    End Sub

    Private Sub LoadAllProductsFromPO()
        If String.IsNullOrWhiteSpace(SelectedPONumber) OrElse String.IsNullOrWhiteSpace(userBranchID) Then
            lblMessage.Text = "Missing PO or Branch information!"
            lblMessage.ForeColor = Color.Red
            Return
        End If

        dgvItems.Rows.Clear()

        Using conn As New MySqlConnection(DBConnection.connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("
                SELECT BARCODE, BRAND, DESCRIPTIONS, ORDER_QTY, SIZE, SKU, PRICE, STATUS
                FROM stock_ordering
                WHERE PO_NUMBER = @PO 
                  AND BRANCH_ID = @MY_BRANCH
                ORDER BY DESCRIPTIONS", conn)

            cmd.Parameters.AddWithValue("@PO", SelectedPONumber)
            cmd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    Dim statusVal = dr("STATUS")?.ToString().Trim()
                    dgvItems.Rows.Add(
                        dr("BARCODE").ToString(),
                        dr("BRAND").ToString(),
                        dr("DESCRIPTIONS").ToString(),
                        dr("ORDER_QTY").ToString(),
                        dr("SIZE").ToString(),
                        dr("SKU").ToString(),
                        Convert.ToDecimal(dr("PRICE")).ToString("N2"),
                        "",
                        statusVal
                    )

                    If statusVal.Equals("Received", StringComparison.OrdinalIgnoreCase) Then
                        isTransactionComplete = True
                        LockStockInColumn()
                    End If
                End While
            End Using
        End Using

        UpdateReceiveButtonState()
    End Sub

    Private Sub LockStockInColumn()
        dgvItems.Columns("STOCK_IN").ReadOnly = True
        btnReceive.Enabled = False
    End Sub

    Private Sub UpdateReceiveButtonState()
        If isTransactionComplete OrElse dgvItems.Rows.Count = 0 Then
            btnReceive.Enabled = False
            Exit Sub
        End If

        Dim allFilled As Boolean = True
        For Each row As DataGridViewRow In dgvItems.Rows
            Dim stockIn As String = row.Cells("STOCK_IN").Value?.ToString().Trim()
            If String.IsNullOrWhiteSpace(stockIn) Then
                allFilled = False
                Exit For
            End If
        Next
        btnReceive.Enabled = allFilled
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword = txtSearch.Text.Trim().ToUpper()
        If String.IsNullOrWhiteSpace(keyword) Then
            For Each row As DataGridViewRow In dgvItems.Rows
                row.Visible = True
            Next
            Exit Sub
        End If

        For Each row As DataGridViewRow In dgvItems.Rows
            Dim barcode = row.Cells("BARCODE").Value?.ToString().ToUpper()
            Dim name = row.Cells("DESCRIPTIONS").Value?.ToString().ToUpper()
            Dim sku = row.Cells("SKU").Value?.ToString().ToUpper()
            row.Visible = (barcode.Contains(keyword)) OrElse (name.Contains(keyword)) OrElse (sku.Contains(keyword))
        Next
    End Sub

    Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        If dgvItems.Rows.Count = 0 Then Exit Sub
        If String.IsNullOrWhiteSpace(userBranchID) Then
            lblMessage.Text = "Branch information not found!"
            lblMessage.ForeColor = Color.Red
            Exit Sub
        End If

        Dim successCount As Integer = 0

        For Each row As DataGridViewRow In dgvItems.Rows
            If row.Cells("STATUS").Value?.ToString().Trim().ToUpper() = "RECEIVED" Then Continue For

            Dim barcodeVal = row.Cells("BARCODE").Value?.ToString()
            Dim stockInQty As Integer = 0
            Integer.TryParse(row.Cells("STOCK_IN").Value?.ToString().Trim(), stockInQty)

            row.Cells("STATUS").Value = "Received"

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmdUpdStatus As New MySqlCommand("
                    UPDATE stock_ordering 
                    SET STATUS = 'Received', STOCK_IN = @QTY
                    WHERE PO_NUMBER = @PO 
                      AND BARCODE = @BARCODE 
                      AND BRANCH_ID = @MY_BRANCH", conn)

                cmdUpdStatus.Parameters.AddWithValue("@PO", SelectedPONumber)
                cmdUpdStatus.Parameters.AddWithValue("@BARCODE", barcodeVal)
                cmdUpdStatus.Parameters.AddWithValue("@QTY", stockInQty)
                cmdUpdStatus.Parameters.AddWithValue("@MY_BRANCH", userBranchID)
                cmdUpdStatus.ExecuteNonQuery()
                successCount += 1
            End Using
        Next

        isTransactionComplete = True
        LockStockInColumn()

        lblMessage.Text = $"Receive Complete! {successCount} item(s) marked as Received."
        lblMessage.ForeColor = Color.Green
    End Sub

    Private Sub dgvItems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvItems.CellBeginEdit
        If isTransactionComplete Then
            e.Cancel = True
            lblMessage.Text = "Transaction Complete — Cannot modify!"
            lblMessage.ForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If Not isTransactionComplete Then
            UpdateReceiveButtonState()
        End If
    End Sub
End Class