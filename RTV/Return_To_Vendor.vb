Imports System.Data
Imports MySqlConnector

Public Class Return_To_Vendor

    Private orderList As New DataTable()
    Private connStr As String = DBConnection.connStr

    Private Sub Return_To_Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateRTVNumber()
        LoadVendors()
        SetupOrderListTable()

        lblstatus.Text = "PENDING"
        lbltransactiontype.Text = "RETURN TO VENDOR"
        lblbranch.Text = DashBoard.ToolStripStatusLabel4.Text.Trim()
        txtBarcode.Focus()
    End Sub

    Private Sub GenerateRTVNumber()
        Try
            Using con As New MySqlConnection(connStr)
                ' ✅ ISNULL → IFNULL, dbo. removed, backticks added
                Dim cmd As New MySqlCommand("SELECT IFNULL(MAX(`RTV_NUMBER`), 0) + 1 FROM `RTV_DATA`", con)
                con.Open()
                Dim nextRTV As Integer = CInt(cmd.ExecuteScalar())
                lblRTVnumber.Text = nextRTV.ToString("D6")
            End Using
        Catch
            lblRTVnumber.Text = "000001"
        End Try
    End Sub

    Private Sub LoadVendors()
        Try
            Using con As New MySqlConnection(connStr)
                Dim query As String = "SELECT `VENDOR_CODE`, `VENDOR` FROM `VENDOR` WHERE `STATUS` = 'Active' ORDER BY `VENDOR`"
                Dim cmd As New MySqlCommand(query, con)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                cboVendor.DataSource = dt
                cboVendor.DisplayMember = "VENDOR"
                cboVendor.ValueMember = "VENDOR_CODE"
                cboVendor.Text = "-- Select Vendor --"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading vendors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
        orderList.Columns.Add("STOCK_IN", GetType(Integer))
        orderList.Columns.Add("STOCK_OUT", GetType(Integer))
        orderList.Columns.Add("TOTAL", GetType(Decimal))

        dgvOrderItems.DataSource = orderList
        dgvOrderItems.Columns("PRICE").DefaultCellStyle.Format = "N2"
        dgvOrderItems.Columns("TOTAL").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If txtBarcode.Text.Trim.Length >= 5 AndAlso cboVendor.SelectedValue IsNot Nothing Then
            SearchProduct(txtBarcode.Text.Trim(), cboVendor.SelectedValue.ToString())
        End If
    End Sub

    Private Sub SearchProduct(barcode As String, vendorCode As String)
        Try
            Using con As New MySqlConnection(connStr)
                ' ✅ inv. prefix removed, backticks added
                Dim query As String = "SELECT `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `VENDOR_CODE`, `VENDOR`, `AVAILABLE` " &
                                      "FROM `Inventory_Master_file` WHERE `BARCODE` = @Barcode"

                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Barcode", barcode)
                    con.Open()
                    Dim dr As MySqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        txtBarcode.Tag = New With {
                            .SKU = dr("SKU").ToString(),
                            .Brand = dr("BRAND").ToString(),
                            .Desc = dr("DESCRIPTIONS").ToString(),
                            .Size = dr("SIZE").ToString(),
                            .Price = CDec(dr("PRICE")),
                            .AvailableStock = CInt(dr("AVAILABLE")),
                            .VendorCode = dr("VENDOR_CODE").ToString(),
                            .VendorName = dr("VENDOR").ToString()
                        }
                        txtQty.Focus()
                    Else
                        MessageBox.Show("Product not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        If qty > prod.AvailableStock Then
            MessageBox.Show($"Cannot return {qty} pcs — only {prod.AvailableStock} available!", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Clear()
            txtQty.Focus()
            Return
        End If

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
        newRow("STOCK_IN") = 0
        newRow("STOCK_OUT") = qty
        newRow("TOTAL") = subtotal

        orderList.Rows.Add(newRow)
        ComputeGrandTotal()

        txtBarcode.Clear()
        txtQty.Clear()
        txtBarcode.Tag = Nothing
        txtBarcode.Focus()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If dgvOrderItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row first!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Remove this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            orderList.Rows(dgvOrderItems.SelectedRows(0).Index).Delete()
            orderList.AcceptChanges()
            ComputeGrandTotal()
        End If
    End Sub

    Private Sub ComputeGrandTotal()
        lbltotal.Text = If(orderList.Rows.Count > 0, orderList.AsEnumerable().Sum(Function(r) CDec(r("TOTAL"))).ToString("N2"), "0.00")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If orderList.Rows.Count = 0 Then
            MessageBox.Show("No items added!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboVendor.SelectedValue Is Nothing OrElse cboVendor.Text = "-- Select Vendor --" Then
            MessageBox.Show("Select a Vendor first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Submit this Return To Vendor? This will deduct stock from inventory.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim rtvNumber As String = lblRTVnumber.Text
        Dim vendorName As String = cboVendor.Text
        Dim preparedBy As String = lblpreparedby.Text
        Dim branchName As String = DashBoard.ToolStripStatusLabel4.Text.Trim()
        Dim grandTotal As Decimal = CDec(lbltotal.Text)

        Try
            Using con As New MySqlConnection(connStr)
                con.Open()
                ' ✅ SqlTransaction → MySqlTransaction
                Dim tran As MySqlTransaction = con.BeginTransaction()

                Try
                    ' ✅ GETDATE() → NOW(), dbo. removed, backticks added
                    Dim cmdHeader As New MySqlCommand("INSERT INTO `RTV_DATA` (`RTV_NUMBER`, `FROM`, `TO`, `REQUEST_DATE`, `PREPARED_BY`, `TRANSACTION_TYPE`, `TOTAL`, `STATUS`) " &
                                                "VALUES (@RTV, @From, @To, NOW(), @PreparedBy, @Type, @Total, @Status)", con, tran)

                    cmdHeader.Parameters.AddWithValue("@RTV", rtvNumber.Trim())
                    cmdHeader.Parameters.AddWithValue("@From", If(branchName.Length > 100, branchName.Substring(0, 100), branchName))
                    cmdHeader.Parameters.AddWithValue("@To", If(vendorName.Length > 100, vendorName.Substring(0, 100), vendorName))
                    cmdHeader.Parameters.AddWithValue("@PreparedBy", If(preparedBy.Length > 50, preparedBy.Substring(0, 50), preparedBy))
                    cmdHeader.Parameters.AddWithValue("@Type", lbltransactiontype.Text)
                    cmdHeader.Parameters.AddWithValue("@Total", grandTotal)
                    cmdHeader.Parameters.AddWithValue("@Status", lblstatus.Text)

                    cmdHeader.ExecuteNonQuery()

                    For Each row As DataRow In orderList.Rows
                        Dim barcode As String = row("BARCODE").ToString()
                        Dim qtyReturn As Integer = CInt(row("STOCK_OUT"))

                        ' ✅ dbo. removed, backticks added
                        Dim cmdLine As New MySqlCommand("INSERT INTO `Return_to_Vendor` (`RTV_NUMBER`, `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `ORDER_QTY`, `VENDOR_CODE`, `VENDOR_NAME`, `STOCK_IN`, `STOCK_OUT`, `TOTAL`) " &
                                                  "VALUES (@RTV, @Barcode, @SKU, @Brand, @Desc, @Size, @Price, @Qty, @VendorCode, @Vendor, @StockIn, @StockOut, @Subtotal)", con, tran)

                        cmdLine.Parameters.AddWithValue("@RTV", rtvNumber.Trim())
                        cmdLine.Parameters.AddWithValue("@Barcode", barcode)
                        cmdLine.Parameters.AddWithValue("@SKU", row("SKU").ToString())
                        cmdLine.Parameters.AddWithValue("@Brand", row("BRAND").ToString())
                        cmdLine.Parameters.AddWithValue("@Desc", row("DESCRIPTIONS").ToString())
                        cmdLine.Parameters.AddWithValue("@Size", row("SIZE").ToString())
                        cmdLine.Parameters.AddWithValue("@Price", row("PRICE"))
                        cmdLine.Parameters.AddWithValue("@Qty", row("ORDER_QTY"))
                        cmdLine.Parameters.AddWithValue("@VendorCode", row("VENDOR_CODE").ToString())
                        cmdLine.Parameters.AddWithValue("@Vendor", row("VENDOR_NAME").ToString())
                        cmdLine.Parameters.AddWithValue("@StockIn", row("STOCK_IN"))
                        cmdLine.Parameters.AddWithValue("@StockOut", qtyReturn)
                        cmdLine.Parameters.AddWithValue("@Subtotal", row("TOTAL"))

                        cmdLine.ExecuteNonQuery()

                        ' ✅ inv. prefix removed, backticks added
                        Dim cmdUpdateStock As New MySqlCommand("UPDATE `Inventory_Master_file` SET `AVAILABLE` = `AVAILABLE` - @QtyReturn WHERE `BARCODE` = @Barcode", con, tran)
                        cmdUpdateStock.Parameters.AddWithValue("@QtyReturn", qtyReturn)
                        cmdUpdateStock.Parameters.AddWithValue("@Barcode", barcode)
                        cmdUpdateStock.ExecuteNonQuery()
                    Next

                    tran.Commit()
                    MessageBox.Show("Return saved and stock updated successfully! RTV: " & rtvNumber, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        GenerateRTVNumber()
        orderList.Clear()
        lbltotal.Text = "0.00"
        txtBarcode.Clear()
        txtQty.Clear()
        txtBarcode.Tag = Nothing
        lblstatus.Text = "PENDING"
        cboVendor.SelectedIndex = -1
        lblbranch.Text = DashBoard.ToolStripStatusLabel4.Text.Trim()
        txtBarcode.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Cancel transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Hide()
        End If
    End Sub

End Class