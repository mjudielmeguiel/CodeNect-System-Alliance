Imports MySqlConnector

Public Class Stock_Ordering

    Private orderList As New DataTable()

    Private Sub Stock_Ordering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GeneratePONumber()
        LoadVendors()
        SetupOrderListTable()

        lblstatus.Text = "PENDING"
        lbltransactiontype.Text = "STOCK ORDER"
        lblbranch.Text = DashBoard.ToolStripStatusLabel4.Text.Trim()

        txtBarcode.Focus()
    End Sub

    ' --- Generate unique PO Number ---
    Private Sub GeneratePONumber()
        Try
            Using con As New MySqlConnection(DBConnection.connStr)
                Dim cmd As New MySqlCommand("SELECT IFNULL(MAX(`PO_NUMBER`), 0) + 1 FROM `STO_DATA`", con)
                con.Open()
                Dim nextPO As Integer = CInt(cmd.ExecuteScalar())
                lblPOnumber.Text = nextPO.ToString("D6")
            End Using
        Catch
            lblPOnumber.Text = "000001"
        End Try
    End Sub

    ' --- Load Vendors ---
    Private Sub LoadVendors()
        Try
            Using con As New MySqlConnection(DBConnection.connStr)
                Dim query As String = "SELECT `VENDOR_CODE`, `VENDOR` FROM `VENDOR` WHERE `STATUS` = 'Active' ORDER BY `VENDOR`"
                Dim cmd As New MySqlCommand(query, con)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                cboBranchFrom.DataSource = dt
                cboBranchFrom.DisplayMember = "VENDOR"
                cboBranchFrom.ValueMember = "VENDOR_CODE"
                cboBranchFrom.Text = "-- Select Vendor --"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading vendors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Setup grid ---
    Private Sub SetupOrderListTable()
        orderList.Columns.Add("BARCODE", GetType(String))
        orderList.Columns.Add("SKU", GetType(String))
        orderList.Columns.Add("BRAND", GetType(String))
        orderList.Columns.Add("DESCRIPTIONS", GetType(String))
        orderList.Columns.Add("SIZE", GetType(String))
        orderList.Columns.Add("PRICE", GetType(Decimal))
        orderList.Columns.Add("ORDER_QTY", GetType(Integer))
        orderList.Columns.Add("VENDOR_CODE", GetType(String))
        orderList.Columns.Add("VENDOR_NAME", GetType(String))
        orderList.Columns.Add("TOTAL", GetType(Decimal))

        dgvOrderItems.DataSource = orderList
        dgvOrderItems.Columns("PRICE").DefaultCellStyle.Format = "N2"
        dgvOrderItems.Columns("TOTAL").DefaultCellStyle.Format = "N2"
    End Sub

    ' --- Search product by barcode ---
    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If txtBarcode.Text.Trim.Length >= 5 AndAlso cboBranchFrom.SelectedValue IsNot Nothing Then
            SearchProduct(txtBarcode.Text.Trim(), cboBranchFrom.SelectedValue.ToString())
        End If
    End Sub

    Private Sub SearchProduct(barcode As String, vendorCode As String)
        Try
            Using con As New MySqlConnection(DBConnection.connStr)
                Dim query As String = "SELECT `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `VENDOR_CODE`, `VENDOR` " &
                                      "FROM `Inventory_Master_file` " &
                                      "WHERE `BARCODE` = @Barcode AND `VENDOR_CODE` = @VendorCode"

                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Barcode", barcode)
                    cmd.Parameters.AddWithValue("@VendorCode", vendorCode)

                    con.Open()
                    Dim dr As MySqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        txtBarcode.Tag = New With {
                            .SKU = dr("SKU").ToString(),
                            .Brand = dr("BRAND").ToString(),
                            .Desc = dr("DESCRIPTIONS").ToString(),
                            .Size = dr("SIZE").ToString(),
                            .Price = CDec(dr("PRICE")),
                            .VendorCode = dr("VENDOR_CODE").ToString(),
                            .VendorName = dr("VENDOR").ToString()
                        }
                        txtQty.Focus()
                    Else
                        MessageBox.Show("Product not found for this Vendor!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBarcode.Clear()
                        txtBarcode.Focus()
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- Add item to list ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtBarcode.Tag Is Nothing Then
            MessageBox.Show("Scan a barcode first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQty.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Enter valid quantity!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Clear()
            txtQty.Focus()
            Return
        End If

        Dim prod = CType(txtBarcode.Tag, Object)
        Dim subtotal As Decimal = prod.Price * qty

        Dim newRow As DataRow = orderList.NewRow()
        newRow("BARCODE") = txtBarcode.Text.Trim()
        newRow("SKU") = prod.SKU
        newRow("BRAND") = prod.Brand
        newRow("DESCRIPTIONS") = prod.Desc
        newRow("SIZE") = prod.Size
        newRow("PRICE") = prod.Price
        newRow("ORDER_QTY") = qty
        newRow("VENDOR_CODE") = prod.VendorCode
        newRow("VENDOR_NAME") = prod.VendorName
        newRow("TOTAL") = subtotal

        orderList.Rows.Add(newRow)
        ComputeGrandTotal()

        txtBarcode.Clear()
        txtQty.Clear()
        txtBarcode.Tag = Nothing
        txtBarcode.Focus()
    End Sub

    ' --- Remove item ---
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If dgvOrderItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to remove first!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to remove this item?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            orderList.Rows(dgvOrderItems.SelectedRows(0).Index).Delete()
            orderList.AcceptChanges()
            ComputeGrandTotal()
        End If
    End Sub

    Private Sub ComputeGrandTotal()
        Dim total As Decimal = 0
        If orderList.Rows.Count > 0 Then
            total = orderList.AsEnumerable().Sum(Function(r) CDec(r("TOTAL")))
        End If
        lbltotal.Text = total.ToString("N2")
    End Sub

    ' --- Submit order with Transaction ---
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If orderList.Rows.Count = 0 Then
            MessageBox.Show("No items added!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboBranchFrom.SelectedValue Is Nothing OrElse cboBranchFrom.Text = "-- Select Vendor --" Then
            MessageBox.Show("Select a Vendor first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Submit this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim poNumber As String = lblPOnumber.Text
        Dim vendorName As String = cboBranchFrom.Text
        Dim preparedBy As String = lblpreparedby.Text
        Dim branchName As String = DashBoard.ToolStripStatusLabel4.Text.Trim()
        Dim grandTotal As Decimal = CDec(lbltotal.Text)

        Try
            Using con As New MySqlConnection(DBConnection.connStr)
                con.Open()
                Dim tran As MySqlTransaction = con.BeginTransaction()

                Try
                    ' Insert header
                    Dim cmdHeader As New MySqlCommand("
                        INSERT INTO `STO_DATA` 
                        (`PO_NUMBER`, `FROM`, `TO`, `REQUEST_DATE`, `PREPARED_BY`, `TRANSACTION_TYPE`, `TOTAL`, `STATUS`) 
                        VALUES (@PO, @From, @To, NOW(), @PreparedBy, @Type, @Total, @Status)", con, tran)

                    cmdHeader.Parameters.AddWithValue("@PO", poNumber)
                    cmdHeader.Parameters.AddWithValue("@From", If(vendorName.Length > 100, vendorName.Substring(0, 100), vendorName))
                    cmdHeader.Parameters.AddWithValue("@To", If(branchName.Length > 100, branchName.Substring(0, 100), branchName))
                    cmdHeader.Parameters.AddWithValue("@PreparedBy", If(preparedBy.Length > 50, preparedBy.Substring(0, 50), preparedBy))
                    cmdHeader.Parameters.AddWithValue("@Type", lbltransactiontype.Text)
                    cmdHeader.Parameters.AddWithValue("@Total", grandTotal)
                    cmdHeader.Parameters.AddWithValue("@Status", lblstatus.Text)
                    cmdHeader.ExecuteNonQuery()

                    ' Insert line items
                    For Each row As DataRow In orderList.Rows
                        Dim cmdLine As New MySqlCommand("
                            INSERT INTO `Stock_Ordering` 
                            (`PO_NUMBER`, `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `ORDER_QTY`, `VENDOR_CODE`, `VENDOR_NAME`, `TOTAL`) 
                            VALUES (@PO, @Barcode, @SKU, @Brand, @Desc, @Size, @Price, @Qty, @VendorCode, @Vendor, @Subtotal)", con, tran)

                        cmdLine.Parameters.AddWithValue("@PO", poNumber)
                        cmdLine.Parameters.AddWithValue("@Barcode", row("BARCODE"))
                        cmdLine.Parameters.AddWithValue("@SKU", row("SKU"))
                        cmdLine.Parameters.AddWithValue("@Brand", row("BRAND"))
                        cmdLine.Parameters.AddWithValue("@Desc", row("DESCRIPTIONS"))
                        cmdLine.Parameters.AddWithValue("@Size", row("SIZE"))
                        cmdLine.Parameters.AddWithValue("@Price", row("PRICE"))
                        cmdLine.Parameters.AddWithValue("@Qty", row("ORDER_QTY"))
                        cmdLine.Parameters.AddWithValue("@VendorCode", row("VENDOR_CODE"))
                        cmdLine.Parameters.AddWithValue("@Vendor", row("VENDOR_NAME"))
                        cmdLine.Parameters.AddWithValue("@Subtotal", row("TOTAL"))
                        cmdLine.ExecuteNonQuery()
                    Next

                    tran.Commit()
                    MessageBox.Show("Order saved successfully! PO: " & poNumber, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearAll()

                Catch ex As Exception
                    tran.Rollback()
                    MessageBox.Show("Save failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAll()
        GeneratePONumber()
        orderList.Clear()
        lbltotal.Text = "0.00"
        txtBarcode.Clear()
        txtQty.Clear()
        txtBarcode.Tag = Nothing
        lblstatus.Text = "PENDING"
        cboBranchFrom.SelectedIndex = -1
        lblbranch.Text = DashBoard.ToolStripStatusLabel4.Text.Trim()
        txtBarcode.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Are you sure you want to cancel this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            lbltransactiontype.Text = "-"
            lblbranch.Text = "-"
            lblpreparedby.Text = "-"
            lblPOnumber.Text = "-"
            lblstatus.Text = "CANCELLED"
            Me.Hide()
        End If
    End Sub

End Class