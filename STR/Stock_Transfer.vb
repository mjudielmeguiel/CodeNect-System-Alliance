Imports System.Data
Imports System.Data.SqlClient

Public Class Stock_Transfer

    Private connStr As String = DBConnection.connStr
    Private strNumber As String = "" ' Only 6 digits, no STR-

    Private Sub Stock_Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateSTRNumber()
        SetupGrid()
        LoadBranchList()
    End Sub

    Private Sub GenerateSTRNumber()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                ' Get max number, no STR-
                Dim cmd As New SqlCommand("SELECT ISNULL(MAX(STR_NUMBER), '000000') FROM dbo.STR_DATA", conn)
                Dim lastNo As String = cmd.ExecuteScalar().ToString().Trim()

                Dim lastNum As Integer = CInt(lastNo)
                Dim newNum As Integer = lastNum + 1

                ' Store and show only 6 digits
                strNumber = newNum.ToString("D6")
                lblSTRNumber.Text = strNumber
            End Using
            lblstatus.Text = "PENDING"
            lbltotal.Text = "0.00"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        dgvItems.Columns.Clear()
        dgvItems.Columns.Add("BARCODE", "Barcode")
        dgvItems.Columns.Add("SKU", "SKU")
        dgvItems.Columns.Add("BRAND", "Brand")
        dgvItems.Columns.Add("DESCRIPTIONS", "Description")
        dgvItems.Columns.Add("SIZE", "Size")
        dgvItems.Columns.Add("PRICE", "Price")
        dgvItems.Columns.Add("QTY", "Quantity")
        dgvItems.Columns.Add("TOTAL", "Total")

        dgvItems.AllowUserToAddRows = False
        dgvItems.ReadOnly = True
    End Sub

    Private Sub LoadBranchList()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT DISTINCT BRANCH FROM dbo.Branches ORDER BY BRANCH", conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                cboToBranch.DataSource = dt
                cboToBranch.DisplayMember = "BRANCH"
                cboToBranch.ValueMember = "BRANCH"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then btnAdd.PerformClick()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim barcode As String = txtBarcode.Text.Trim()
        Dim qtyText As String = txtQty.Text.Trim()

        If barcode = "" Then
            MessageBox.Show("Enter barcode first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If

        If Not IsNumeric(qtyText) OrElse CInt(qtyText) <= 0 Then
            MessageBox.Show("Enter valid quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            Return
        End If

        Dim qty As Integer = CInt(qtyText)

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT SKU, BARCODE, BRAND, DESCRIPTIONS, SIZE, PRICE FROM inv.Inventory_Master_file WHERE BARCODE = @Barcode", conn)
                cmd.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = barcode

                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Dim price As Decimal = CDec(dr("PRICE"))
                    Dim lineTotal As Decimal = price * qty

                    dgvItems.Rows.Add(
                        dr("BARCODE").ToString(),
                        dr("SKU").ToString(),
                        dr("BRAND").ToString(),
                        dr("DESCRIPTIONS").ToString(),
                        dr("SIZE").ToString(),
                        price.ToString("N2"),
                        qty,
                        lineTotal.ToString("N2")
                    )

                    CalculateTotal()
                    txtBarcode.Clear()
                    txtQty.Clear()
                    txtBarcode.Focus()
                Else
                    MessageBox.Show("Product not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtBarcode.SelectAll()
                    txtBarcode.Focus()
                End If
                dr.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If dgvItems.SelectedRows.Count > 0 Then
            dgvItems.Rows.Remove(dgvItems.SelectedRows(0))
            CalculateTotal()
        Else
            MessageBox.Show("Select an item to remove", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CalculateTotal()
        Dim grandTotal As Decimal = 0
        For Each row As DataGridViewRow In dgvItems.Rows
            grandTotal += CDec(row.Cells("TOTAL").Value)
        Next
        lbltotal.Text = grandTotal.ToString("N2")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If dgvItems.Rows.Count = 0 Then
            MessageBox.Show("No items to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If lblFromBranch.Text.Trim() = "" OrElse cboToBranch.Text.Trim() = "" Then
            MessageBox.Show("Fill From and To Branch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Save this transfer?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim trans As SqlTransaction = conn.BeginTransaction()

                Try
                    ' Save ONLY 6-digit number
                    Dim cmdHeader As New SqlCommand("
                        INSERT INTO dbo.STR_DATA 
                        (STR_NUMBER, FROM_MV, TO_MV, REQUEST_DATE, PREPARED_BY, TRANSACTION_TYPE, STATUS, TOTAL)
                        VALUES (@STR, @From, @To, GETDATE(), @Prepared, 'STOCK TRANSFER', 'PENDING', @Total)", conn, trans)

                    cmdHeader.Parameters.Add("@STR", SqlDbType.VarChar, 6).Value = strNumber
                    cmdHeader.Parameters.Add("@From", SqlDbType.NVarChar, 255).Value = lblFromBranch.Text.Trim()
                    cmdHeader.Parameters.Add("@To", SqlDbType.NVarChar, 255).Value = cboToBranch.Text.Trim()
                    cmdHeader.Parameters.Add("@Prepared", SqlDbType.NVarChar, 100).Value = lblPreparedBy.Text.Trim()
                    cmdHeader.Parameters.Add("@Total", SqlDbType.Decimal, 10, 2).Value = CDec(lbltotal.Text)
                    cmdHeader.ExecuteNonQuery()

                    Dim cmdDetail As New SqlCommand("
                        INSERT INTO dbo.Stock_Transfer 
                        (STR_NUMBER, BARCODE, SKU, BRAND, DESCRIPTIONS, SIZE, PRICE, ORDER_QTY, STOCK_OUT, TOTAL)
                        VALUES (@STR, @Barcode, @SKU, @Brand, @Desc, @Size, @Price, @Qty, @Qty, @Total)", conn, trans)

                    For Each row As DataGridViewRow In dgvItems.Rows
                        cmdDetail.Parameters.Clear()
                        cmdDetail.Parameters.Add("@STR", SqlDbType.VarChar, 6).Value = strNumber
                        cmdDetail.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = row.Cells("BARCODE").Value
                        cmdDetail.Parameters.Add("@SKU", SqlDbType.NChar, 20).Value = row.Cells("SKU").Value
                        cmdDetail.Parameters.Add("@Brand", SqlDbType.VarChar, 255).Value = row.Cells("BRAND").Value
                        cmdDetail.Parameters.Add("@Desc", SqlDbType.VarChar, 255).Value = row.Cells("DESCRIPTIONS").Value
                        cmdDetail.Parameters.Add("@Size", SqlDbType.VarChar, 255).Value = row.Cells("SIZE").Value
                        cmdDetail.Parameters.Add("@Price", SqlDbType.Decimal, 10, 2).Value = CDec(row.Cells("PRICE").Value)
                        cmdDetail.Parameters.Add("@Qty", SqlDbType.Int).Value = CInt(row.Cells("QTY").Value)
                        cmdDetail.Parameters.Add("@Total", SqlDbType.Decimal, 10, 2).Value = CDec(row.Cells("TOTAL").Value)
                        cmdDetail.ExecuteNonQuery()
                    Next

                    trans.Commit()
                    MessageBox.Show("Transfer saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    GenerateSTRNumber()
                    dgvItems.Rows.Clear()
                    lblPreparedBy.Text = ""
                    lblFromBranch.Text = ""
                    cboToBranch.SelectedIndex = -1
                    txtBarcode.Focus()

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Save Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class