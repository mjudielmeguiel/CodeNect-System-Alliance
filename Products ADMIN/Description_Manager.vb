Imports System.Data
Imports MySqlConnector

Public Class frmUser_Description_Manager
    Private CurrentAccountID As String = ""
    Private connStr As String = DBConnection.connStr

    Private Sub Description_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentAccountID = Login.LoggedInAccountID
        Me.Text = "Description Manager - Account: " & CurrentAccountID

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
                FROM `admin_inventory_file` "

            Dim hasFilter As Boolean = False

            If Not String.IsNullOrEmpty(CurrentAccountID) Then
                SqlQuery &= " WHERE `ACCOUNT_ID` = @AccountID "
                hasFilter = True
            Else
                MessageBox.Show("No Account ID retrieved from login! Showing all products for now.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If Not String.IsNullOrWhiteSpace(SearchText) Then
                SqlQuery &= If(hasFilter, " AND ", " WHERE ") & " 
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
                    If Not String.IsNullOrEmpty(CurrentAccountID) Then
                        cmd.Parameters.AddWithValue("@AccountID", CurrentAccountID.Trim())
                    End If
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
                If Not String.IsNullOrEmpty(CurrentAccountID) Then
                    MessageBox.Show("No products registered for this Account.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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

        Catch ex As Exception
            MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            Dim frmDetails As New frmProduct_Information
            frmDetails.LoadDataFromGrid(selectedRow)
            frmDetails.ShowDialog()
            LoadAllProducts(txtSearch.Text.Trim())
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadAllProducts()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAllProducts(txtSearch.Text.Trim())
    End Sub

    Private Sub btnaddproduct_Click(sender As Object, e As EventArgs) Handles btnaddproduct.Click
        frmDashboard.Panelmenu.Controls.Clear()
        Dim Scan As New frmADDProduct_Scan
        Scan.TopLevel = False
        Scan.FormBorderStyle = FormBorderStyle.None
        Scan.Dock = DockStyle.Fill
        frmDashboard.Panelmenu.Controls.Add(Scan)
        Scan.Show()
    End Sub
End Class