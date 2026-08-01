Imports System.Data
Imports MySqlConnector

Public Class frmUser_Description_Manager
    Private CurrentAccountID As String = ""
    Private connStr As String = DBConnection.connStr

    Private Sub Description_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(Login.LoggedInAccountID) Then
            MessageBox.Show("No active account found! Please log in again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ACCESS_DENIED", "DescManager", "No active account on form open")
            Me.Close()
            Exit Sub
        End If

        CurrentAccountID = Login.LoggedInAccountID
        Me.Text = "Description Manager - Account: " & CurrentAccountID
        AuditLogger.LogAction("OPEN_DESC_MGR", "DescManager", $"Opened Description Manager | Account: {CurrentAccountID}")

        dgvProducts.AutoGenerateColumns = True
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.ReadOnly = True
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.RowHeadersVisible = False

        LoadAllProducts()
    End Sub

    Private Sub LoadAllProducts(Optional SearchText As String = "")
        Try
            Dim SqlQuery As String = "
                SELECT 
                    `ID`, `ACCOUNT_ID`, `BARCODE`, `BRAND`, 
                    `CATEGORY`, `DATE_ADDED`, `DESCRIPTIONS`, `PRICE`, 
                    `PRODUCT_IMAGE`, `SIZE`, `SKU`, `UNIT`, `VENDOR`, `VENDOR_CODE`
                FROM `admin_inventory_file`
                WHERE `ACCOUNT_ID` = @AccountID "

            If Not String.IsNullOrWhiteSpace(SearchText) Then
                SqlQuery &= " AND 
                   (`BARCODE` LIKE CONCAT('%', @Search, '%') 
                    OR `SKU` LIKE CONCAT('%', @Search, '%') 
                    OR `BRAND` LIKE CONCAT('%', @Search, '%') 
                    OR `DESCRIPTIONS` LIKE CONCAT('%', @Search, '%') 
                    OR `CATEGORY` LIKE CONCAT('%', @Search, '%'))"
            End If

            SqlQuery &= " ORDER BY `DESCRIPTIONS` ASC"

            Dim dt As New DataTable()
            Using connection As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(SqlQuery, connection)
                    cmd.Parameters.AddWithValue("@AccountID", CurrentAccountID.Trim())
                    If Not String.IsNullOrWhiteSpace(SearchText) Then
                        cmd.Parameters.AddWithValue("@Search", SearchText.Trim())
                    End If
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvProducts.DataSource = dt

            If dt.Rows.Count = 0 Then
                dgvProducts.DataSource = Nothing
                MessageBox.Show("No products registered for your account yet.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("NO_RECORDS", "DescManager", $"No products found | Search: '{SearchText}'")
                Exit Sub
            End If

            With dgvProducts
                If .Columns.Contains("BARCODE") Then .Columns("BARCODE").HeaderText = "Barcode"
                If .Columns.Contains("SKU") Then .Columns("SKU").HeaderText = "SKU"
                If .Columns.Contains("BRAND") Then .Columns("BRAND").HeaderText = "Brand"
                If .Columns.Contains("DESCRIPTIONS") Then .Columns("DESCRIPTIONS").HeaderText = "Description"
                If .Columns.Contains("CATEGORY") Then .Columns("CATEGORY").HeaderText = "Category"
                If .Columns.Contains("SIZE") Then .Columns("SIZE").HeaderText = "Size"
                If .Columns.Contains("PRICE") Then .Columns("PRICE").HeaderText = "Price"
                If .Columns.Contains("UNIT") Then .Columns("UNIT").HeaderText = "Unit"
                If .Columns.Contains("VENDOR_CODE") Then .Columns("VENDOR_CODE").HeaderText = "Vendor Code"
                If .Columns.Contains("VENDOR") Then .Columns("VENDOR").HeaderText = "Vendor"
                If .Columns.Contains("DATE_ADDED") Then .Columns("DATE_ADDED").HeaderText = "Date Added"

                If .Columns.Contains("PRICE") Then
                    .Columns("PRICE").DefaultCellStyle.Format = "N2"
                    .Columns("PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                If .Columns.Contains("DATE_ADDED") Then
                    .Columns("DATE_ADDED").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

                If .Columns.Contains("ID") Then .Columns("ID").Visible = False
                If .Columns.Contains("ACCOUNT_ID") Then .Columns("ACCOUNT_ID").Visible = False
                If .Columns.Contains("PRODUCT_IMAGE") Then .Columns("PRODUCT_IMAGE").Visible = False
            End With

            AuditLogger.LogAction("PRODS_LOADED", "DescManager", $"Loaded {dt.Rows.Count} products | Search: '{SearchText}'")
        Catch ex As Exception
            MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "DescManager", $"Load failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadAllProducts()
        AuditLogger.LogAction("REFRESH_LIST", "DescManager", "Product list refreshed")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAllProducts(txtSearch.Text.Trim())
    End Sub

    Private Sub btnaddproduct_Click(sender As Object, e As EventArgs) Handles btnaddproduct.Click
        AuditLogger.LogAction("OPEN_ADD_PROD", "DescManager", "Opened add product scan form")
        frmADDProduct_Scan.Show()
    End Sub
End Class