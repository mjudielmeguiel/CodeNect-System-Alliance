Imports System.Data.SqlClient

Public Class Description_Manager
    Private CurrentBranchID As String = ""

    Private Sub Description_Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' KUNIN ANG BRANCH ID MULA SA LOGIN
        CurrentBranchID = Login.LoggedInBranchID

        ' ✅ PARA MAKITA MO KUNG ANO ANG KINUKUHA NIYANG BRANCH ID (PANSAMANTALA LANG ITO)
        Me.Text = "Description Manager - Branch: " & CurrentBranchID

        ' SETUP DATAGRID
        dgvProducts.AutoGenerateColumns = True
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.ReadOnly = True
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.RowHeadersVisible = False

        ' IPATAWAG ANG LOAD
        KuninAngLahatNgProdukto()
    End Sub

    Private Sub KuninAngLahatNgProdukto(Optional SearchText As String = "")
        Try
            ' CONNECTION STRING - SIGURADUHIN TAMA ITO
            Dim ConnectionString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

            ' ✅ QUERY: KUNIN LAHAT PERO NAKA-FILTER SA BRANCH
            Dim SqlQuery As String = "
                SELECT 
                    ID, BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, 
                    PRICE, UNIT, AVAILABLE, AVAILABILITY, VENDOR_CODE, 
                    VENDOR, TOTAL, PRODUCT_IMAGE, ACCOUNT_ID, BRANCH_ID
                FROM inv.Inventory_Master_file "

            Dim mayFilter As Boolean = False

            ' ✅ HINDI TAYO MAGPAPATULOY KUNG WALANG BRANCH ID, KASI WALA TALAGANG LALABAS
            If Not String.IsNullOrEmpty(CurrentBranchID) Then
                SqlQuery &= " WHERE BRANCH_ID = @BranchID "
                mayFilter = True
            Else
                ' ⚠️ KUNG PUMASOK DITO, ITO ANG PROBLEMA: WALANG NAKUHANG BRANCH ID MULA SA LOGIN
                MessageBox.Show("Walang nakuha na Branch ID mula sa login! Ipakikita ang lahat ng produkto muna.", "Babala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' Kung gusto mong makita lahat kahit walang branch, burahin ang linya sa taas na MessageBox.
            End If

            ' ✅ SEARCH FUNCTION
            If Not String.IsNullOrWhiteSpace(SearchText) Then
                SqlQuery &= If(mayFilter, " AND ", " WHERE ") & " 
                   (BARCODE LIKE '%' + @Search + '%' 
                    OR SKU LIKE '%' + @Search + '%' 
                    OR BRAND LIKE '%' + @Search + '%' 
                    OR DESCRIPTIONS LIKE '%' + @Search + '%' 
                    OR CATEGORY LIKE '%' + @Search + '%')"
            End If

            SqlQuery &= " ORDER BY DESCRIPTIONS ASC"

            Dim dt As New DataTable()
            Using koneksyon As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(SqlQuery, koneksyon)

                    ' ✅ IDAGDAG ANG PARAMETERS
                    If Not String.IsNullOrEmpty(CurrentBranchID) Then
                        cmd.Parameters.Add("@BranchID", SqlDbType.NVarChar, 20).Value = CurrentBranchID.Trim() ' ✅ NAGDAGDAG NG TRIM PARA TANGGALIN ESPASYO
                    End If

                    If Not String.IsNullOrWhiteSpace(SearchText) Then
                        cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 255).Value = SearchText.Trim()
                    End If

                    ' ✅ PAGKUNAN NG DATA
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            ' ✅ IPASOK SA DATAGRID
            dgvProducts.DataSource = dt

            ' ✅ KUNG WALANG LAMAN ANG DATATABLE
            If dt.Rows.Count = 0 Then
                dgvProducts.DataSource = Nothing
                lblTotalAmount.Text = "0.00"
                ' ✅ IPAPAKITA NATIN BAKIT WALANG LAMAN
                If Not String.IsNullOrEmpty(CurrentBranchID) Then
                    MessageBox.Show("Walang produkto na nakarehistro para sa Branch ID: " & CurrentBranchID, "Walang Nahanap", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Exit Sub
            End If

            ' ✅ FORMAT NG HEADER AT CELLS
            With dgvProducts
                If .Columns.Contains("BARCODE") Then .Columns("BARCODE").HeaderText = "Barcode"
                If .Columns.Contains("SKU") Then .Columns("SKU").HeaderText = "SKU"
                If .Columns.Contains("BRAND") Then .Columns("BRAND").HeaderText = "Brand"
                If .Columns.Contains("DESCRIPTIONS") Then .Columns("DESCRIPTIONS").HeaderText = "Descriptions"
                If .Columns.Contains("CATEGORY") Then .Columns("CATEGORY").HeaderText = "Category"
                If .Columns.Contains("SIZE") Then .Columns("SIZE").HeaderText = "Size"
                If .Columns.Contains("PRICE") Then .Columns("PRICE").HeaderText = "Price"
                If .Columns.Contains("UNIT") Then .Columns("UNIT").HeaderText = "Unit"
                If .Columns.Contains("AVAILABLE") Then .Columns("AVAILABLE").HeaderText = "Available"
                If .Columns.Contains("AVAILABILITY") Then .Columns("AVAILABILITY").HeaderText = "Availability"
                If .Columns.Contains("VENDOR_CODE") Then .Columns("VENDOR_CODE").HeaderText = "Vendor Code"
                If .Columns.Contains("VENDOR") Then .Columns("VENDOR").HeaderText = "Vendor"
                If .Columns.Contains("TOTAL") Then .Columns("TOTAL").HeaderText = "Total"

                ' FORMAT NG NUMERO
                If .Columns.Contains("PRICE") Then
                    .Columns("PRICE").DefaultCellStyle.Format = "N2"
                    .Columns("PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                If .Columns.Contains("TOTAL") Then
                    .Columns("TOTAL").DefaultCellStyle.Format = "N2"
                    .Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                If .Columns.Contains("AVAILABLE") Then
                    .Columns("AVAILABLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

                ' ITAGO ANG HINDI KAILANGANG MAKITA
                If .Columns.Contains("ID") Then .Columns("ID").Visible = False
                If .Columns.Contains("ACCOUNT_ID") Then .Columns("ACCOUNT_ID").Visible = False
                If .Columns.Contains("BRANCH_ID") Then .Columns("BRANCH_ID").Visible = False
                If .Columns.Contains("PRODUCT_IMAGE") Then .Columns("PRODUCT_IMAGE").Visible = False
            End With

            ' ✅ KABUUAN NG TOTAL
            Dim Kabuuan As Decimal = 0
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row("TOTAL")) Then
                    Kabuuan += CDec(row("TOTAL"))
                End If
            Next
            lblTotalAmount.Text = Kabuuan.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("System Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblTotalAmount.Text = "0.00"
        End Try
    End Sub

    ' DOBLE KLIK PARA BUKAS ANG DETALYE
    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim napilingLinya As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            Dim frmDetalye As New Product_Information()
            frmDetalye.LoadDataFromGrid(napilingLinya)
            frmDetalye.ShowDialog()
            KuninAngLahatNgProdukto(txtSearch.Text.Trim())
        End If
    End Sub

    ' REFRESH BUTTON
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        KuninAngLahatNgProdukto()
    End Sub

    ' SEARCH TXTBOX
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        KuninAngLahatNgProdukto(txtSearch.Text.Trim())
    End Sub

    ' ADD NEW PRODUCT
    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmBagongProdukto As New ADD_Description()
        frmBagongProdukto.ShowDialog()
        KuninAngLahatNgProdukto(txtSearch.Text.Trim())
    End Sub
End Class