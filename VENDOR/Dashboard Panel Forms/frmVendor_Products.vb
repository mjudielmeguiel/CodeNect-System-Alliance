Imports MySqlConnector
Imports System.Windows.Forms

Public Class frmVendor_Products

    Private ReadOnly connStr As String = DBConnection.connStr
    Private vendorCode As String = Nothing
    Private vendorName As String = Nothing

    Private Sub frmVendor_Products_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vendorCode = If(DBConnection.CurrentVendorCode IsNot Nothing, DBConnection.CurrentVendorCode.Trim(), "")
        vendorName = If(DBConnection.CurrentVendorName IsNot Nothing, DBConnection.CurrentVendorName.Trim(), "")

        If String.IsNullOrWhiteSpace(vendorCode) Then
            MessageBox.Show("Access Denied! No Vendor account logged in.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Return
        End If

        Me.Text = $"Products — {vendorName} ({vendorCode})"
        LoadVendorProducts()
    End Sub

    Private Sub LoadVendorProducts(Optional searchKeyword As String = "")
        dgvProducts.Columns.Clear()
        dgvProducts.DataSource = Nothing

        Using conn As New MySqlConnection(connStr)
            conn.Open()

            Dim sql As String = "
                SELECT 
                    ID,
                    BARCODE,
                    BRAND,
                    DESCRIPTIONS,
                    SIZE,
                    PRICE,
                    UNIT,
                    AVAILABLE,
                    AVAILABILITY,
                    CATEGORY,
                    VENDOR,
                    VENDOR_CODE
                FROM vendor_products 
                WHERE VENDOR_CODE = @VENDOR_CODE
            "

            If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                sql &= " AND (
                    BARCODE LIKE @KEYWORD OR 
                    BRAND LIKE @KEYWORD OR 
                    DESCRIPTIONS LIKE @KEYWORD OR 
                    SIZE LIKE @KEYWORD OR
                    CATEGORY LIKE @KEYWORD
                )"
            End If

            sql &= " ORDER BY BRAND, DESCRIPTIONS"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@VENDOR_CODE", vendorCode)

                If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                    cmd.Parameters.AddWithValue("@KEYWORD", "%" & searchKeyword.Trim() & "%")
                End If

                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvProducts.DataSource = dt
                    FormatGridColumns()
                End Using
            End Using
        End Using
    End Sub

    Private Sub FormatGridColumns()
        With dgvProducts
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 30
        End With

        If dgvProducts.Columns.Contains("ID") Then dgvProducts.Columns("ID").HeaderText = "ID"
        If dgvProducts.Columns.Contains("BARCODE") Then dgvProducts.Columns("BARCODE").HeaderText = "Barcode"
        If dgvProducts.Columns.Contains("BRAND") Then dgvProducts.Columns("BRAND").HeaderText = "Brand"
        If dgvProducts.Columns.Contains("DESCRIPTIONS") Then dgvProducts.Columns("DESCRIPTIONS").HeaderText = "Description"
        If dgvProducts.Columns.Contains("SIZE") Then dgvProducts.Columns("SIZE").HeaderText = "Size / Weight"
        If dgvProducts.Columns.Contains("PRICE") Then
            dgvProducts.Columns("PRICE").HeaderText = "Price"
            dgvProducts.Columns("PRICE").DefaultCellStyle.Format = "N2"
        End If
        If dgvProducts.Columns.Contains("UNIT") Then dgvProducts.Columns("UNIT").HeaderText = "Unit"
        If dgvProducts.Columns.Contains("AVAILABLE") Then dgvProducts.Columns("AVAILABLE").HeaderText = "Available Qty"
        If dgvProducts.Columns.Contains("AVAILABILITY") Then dgvProducts.Columns("AVAILABILITY").HeaderText = "Status"
        If dgvProducts.Columns.Contains("CATEGORY") Then dgvProducts.Columns("CATEGORY").HeaderText = "Category"
        If dgvProducts.Columns.Contains("VENDOR") Then dgvProducts.Columns("VENDOR").HeaderText = "Vendor Name"
        If dgvProducts.Columns.Contains("VENDOR_CODE") Then dgvProducts.Columns("VENDOR_CODE").HeaderText = "Vendor Code"

        If dgvProducts.Columns.Contains("ID") Then dgvProducts.Columns("ID").Visible = False
        If dgvProducts.Columns.Contains("VENDOR_CODE") Then dgvProducts.Columns("VENDOR_CODE").Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadVendorProducts(txtSearch.Text)
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnaddproduct.Click
        Dim addForm As New ADD_Vendor_Product()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadVendorProducts()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadVendorProducts()
        MessageBox.Show("Product list refreshed!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class