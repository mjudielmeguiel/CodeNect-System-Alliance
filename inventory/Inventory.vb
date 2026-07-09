Imports System.Data.SqlClient

Public Class Inventory

    Private currentAccountName As String = "JUDIEL MEGUIEL MESCALLADO"
    Private currentBranchName As String = "WALTERMART MUNTINLUPA"
    Private currentTransactionID As Integer = 0
    Private Const CriticalLevel As Integer = 5

    Private Sub Inventory_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        GetUserDetails()
        GetNewTransactionID()
        UpdateHeaderDisplay()
        SetupGrid()
        txtBarcode.Clear()
        txtActualQty.Clear()
        lblGrandTotal.Text = "0.00"
        txtBarcode.Focus()
    End Sub

    Private Sub GetUserDetails()
        Try
            Using con As New SqlConnection(connStr)
                con.Open()
                Dim cmd As New SqlCommand("SELECT TOP 1 ACCOUNT, BRANCH FROM User_Accounts", con)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        currentAccountName = dr("ACCOUNT").ToString().Trim().ToUpper()
                        currentBranchName = dr("BRANCH").ToString().Trim().ToUpper()
                    End If
                End Using
            End Using
        Catch
            currentAccountName = "JUDIEL MEGUIEL MESCALLADO"
            currentBranchName = "WALTERMART MUNTINLUPA"
        End Try
    End Sub

    Private Sub GetNewTransactionID()
        Try
            Using con As New SqlConnection(connStr)
                con.Open()
                Dim cmd As New SqlCommand("SELECT ISNULL(MAX(TRANSACTION_ID), 0) + 1 FROM inv.Inventory", con)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    currentTransactionID = CInt(result)
                Else
                    currentTransactionID = 1
                End If
            End Using
        Catch
            currentTransactionID = 1
        End Try
    End Sub

    Private Sub UpdateHeaderDisplay()
        lblNameBranch.Text = "NAME OF USER" & vbCrLf & currentAccountName
        lblStatus.Text = "PENDING"
        lblTransactionID.Text = currentTransactionID.ToString("D6")
    End Sub

    Private Sub SetupGrid()
        With dgvInventory
            .AutoGenerateColumns = False
            .Columns.Clear()
            .AllowUserToAddRows = False
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .Columns.Add("BARCODE", "Barcode")
            .Columns.Add("SKU", "SKU")
            .Columns.Add("BRAND", "Brand")
            .Columns.Add("DESCRIPTIONS", "Description")
            .Columns.Add("CATEGORY", "Category")
            .Columns.Add("SIZE", "Size")
            .Columns.Add("PRICE", "Price")
            .Columns.Add("UNIT", "Unit")
            .Columns.Add("AVAILABLE", "System Qty")
            .Columns.Add("ACTUAL_COUNT", "Actual Qty")
            .Columns.Add("DIFFERENCE", "Variance")
            .Columns.Add("TOTAL_PER_ITEM", "Item Total")
            .Columns.Add("AVAILABILITY", "Availability")

            .Columns("PRICE").DefaultCellStyle.Format = "N2"
            .Columns("TOTAL_PER_ITEM").DefaultCellStyle.Format = "N2"
            .Columns("AVAILABLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ACTUAL_COUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("DIFFERENCE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TOTAL_PER_ITEM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            AddHandler .CellClick, AddressOf PopulateFieldsFromSelectedRow
        End With
    End Sub

    Private Sub PopulateFieldsFromSelectedRow(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            txtBarcode.Text = selectedRow.Cells("BARCODE").Value.ToString()
            txtActualQty.Text = selectedRow.Cells("ACTUAL_COUNT").Value.ToString()
            txtActualQty.Focus()
            txtActualQty.SelectAll()
        End If
    End Sub

    Private Function GetAvailabilityStatus(systemQty As Integer, actualQty As Integer) As String
        If actualQty <= 0 Then
            Return "OUT OF STOCK"
        ElseIf actualQty <= CriticalLevel Then
            Return "CRITICAL"
        Else
            Return "IN STOCK"
        End If
    End Function

    Private Sub AddProductToList()
        Dim enteredBarcode As String = txtBarcode.Text.Trim()
        Dim enteredQty As Integer = 0

        If String.IsNullOrWhiteSpace(enteredBarcode) Then
            MessageBox.Show("Please scan or enter a Barcode!", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        If Not Integer.TryParse(txtActualQty.Text.Trim(), enteredQty) OrElse enteredQty < 0 Then
            MessageBox.Show("Please enter a valid quantity (0 or higher)!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtActualQty.SelectAll()
            txtActualQty.Focus()
            Return
        End If

        Dim existingRow As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In dgvInventory.Rows
            If row.Cells("BARCODE").Value.ToString().Trim().Equals(enteredBarcode, StringComparison.OrdinalIgnoreCase) Then
                existingRow = row
                Exit For
            End If
        Next

        Try
            Using con As New SqlConnection(connStr)
                con.Open()
                Dim cmd As New SqlCommand("SELECT BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, PRICE, UNIT, AVAILABLE FROM inv.Inventory_Master_file WHERE BARCODE = @barcode", con)
                cmd.Parameters.AddWithValue("@barcode", enteredBarcode)

                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim sysQty As Integer = Convert.ToInt32(dr("AVAILABLE"))
                        Dim price As Decimal = Convert.ToDecimal(dr("PRICE"))
                        Dim variance As Integer = enteredQty - sysQty
                        Dim newItemTotal As Decimal = enteredQty * price
                        Dim newStatus As String = GetAvailabilityStatus(sysQty, enteredQty)

                        If existingRow IsNot Nothing Then
                            MessageBox.Show("PRODUCT UPDATED" & vbCrLf & vbCrLf &
                                            "Old Qty: " & existingRow.Cells("ACTUAL_COUNT").Value & vbCrLf &
                                            "New Qty: " & enteredQty & vbCrLf &
                                            "Variance: " & variance, "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            existingRow.Cells("ACTUAL_COUNT").Value = enteredQty
                            existingRow.Cells("DIFFERENCE").Value = variance
                            existingRow.Cells("TOTAL_PER_ITEM").Value = newItemTotal
                            existingRow.Cells("AVAILABILITY").Value = newStatus
                        Else
                            Dim rowIndex As Integer = dgvInventory.Rows.Add()
                            Dim row As DataGridViewRow = dgvInventory.Rows(rowIndex)

                            row.Cells("BARCODE").Value = dr("BARCODE").ToString().Trim()
                            row.Cells("SKU").Value = If(IsDBNull(dr("SKU")), "", dr("SKU").ToString().Trim())
                            row.Cells("BRAND").Value = If(IsDBNull(dr("BRAND")), "", dr("BRAND").ToString().Trim())
                            row.Cells("DESCRIPTIONS").Value = If(IsDBNull(dr("DESCRIPTIONS")), "", dr("DESCRIPTIONS").ToString().Trim())
                            row.Cells("CATEGORY").Value = If(IsDBNull(dr("CATEGORY")), "", dr("CATEGORY").ToString().Trim())
                            row.Cells("SIZE").Value = If(IsDBNull(dr("SIZE")), "", dr("SIZE").ToString().Trim())
                            row.Cells("PRICE").Value = price
                            row.Cells("UNIT").Value = If(IsDBNull(dr("UNIT")), "", dr("UNIT").ToString().Trim())
                            row.Cells("AVAILABLE").Value = sysQty
                            row.Cells("ACTUAL_COUNT").Value = enteredQty
                            row.Cells("DIFFERENCE").Value = variance
                            row.Cells("TOTAL_PER_ITEM").Value = newItemTotal
                            row.Cells("AVAILABILITY").Value = newStatus
                        End If

                        UpdateGrandTotal()
                        txtBarcode.Focus()
                    Else
                        MessageBox.Show("THIS PRODUCT IS NOT CARRIED / DOES NOT EXIST IN INVENTORY MASTER FILE", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtBarcode.SelectAll()
                        txtBarcode.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking product: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddProductToList()
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
    End Sub

    Private Sub txtActualQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtActualQty.KeyDown
    End Sub

    Private Sub UpdateGrandTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvInventory.Rows
            If Not row.IsNewRow Then
                total += CDec(row.Cells("TOTAL_PER_ITEM").Value)
            End If
        Next
        lblGrandTotal.Text = total.ToString("N2")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
    End Sub

    Private Sub btnSaveToExcel_Click(sender As Object, e As EventArgs) Handles btnSaveToExcel.Click
        MessageBox.Show("Export to Excel feature ready!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class