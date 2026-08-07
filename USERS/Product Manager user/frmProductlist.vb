Imports MySqlConnector
Imports System.Data

Public Class frmProductlist

    Private Sub frmProductlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AuditLogger.LogAction("OPEN_PROD_LIST", "ProductList", "Opened product list form")
        LoadBranchProducts()
    End Sub

    Private Sub LoadBranchProducts(Optional SearchText As String = "")
        If String.IsNullOrEmpty(Login.LoggedInAccountID) OrElse String.IsNullOrEmpty(Login.LoggedInBranchID) Then
            MessageBox.Show("Missing account or branch info! Please log in again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("ACCESS_DENIED", "ProductList", "Missing account/branch info - cannot load products")
            Exit Sub
        End If

        Dim sqlQuery As String = "
            SELECT ID, BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, PRICE,
                   AVAILABILITY, AVAILABLE, UNIT, TOTAL, VENDOR, VENDOR_CODE
            FROM inventory_information
            WHERE ACCOUNT_ID = @aid 
              AND BRANCH_ID = @bid"

        If Not String.IsNullOrWhiteSpace(SearchText) Then
            sqlQuery &= " 
              AND (BARCODE LIKE CONCAT('%', @srch, '%') 
                OR SKU LIKE CONCAT('%', @srch, '%') 
                OR DESCRIPTIONS LIKE CONCAT('%', @srch, '%'))"
        End If

        sqlQuery &= " ORDER BY DESCRIPTIONS ASC"

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Using cmd As New MySqlCommand(sqlQuery, conn)
                    cmd.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)
                    cmd.Parameters.AddWithValue("@bid", Login.LoggedInBranchID)
                    If Not String.IsNullOrWhiteSpace(SearchText) Then
                        cmd.Parameters.AddWithValue("@srch", SearchText.Trim())
                    End If
                    conn.Open()

                    Dim dt As New DataTable()
                    dt.Load(cmd.ExecuteReader())

                    ' ✅ AYUS NA LOGIC:
                    ' PENDING lang kapag 0 ang stock
                    ' Kapag may stock na → magiging Available na agad!
                    For Each row As DataRow In dt.Rows
                        Dim availableQty As Integer = 0
                        If Not row.IsNull("AVAILABLE") Then
                            availableQty = Convert.ToInt32(row("AVAILABLE"))
                        End If

                        If availableQty <= 0 Then
                            row("AVAILABILITY") = "Out of Stock"
                        Else
                            row("AVAILABILITY") = "Available"
                        End If
                    Next

                    dgvProducts.DataSource = Nothing
                    dgvProducts.DataSource = dt

                    dgvProducts.AutoGenerateColumns = True
                    dgvProducts.AllowUserToAddRows = False
                    dgvProducts.ReadOnly = True
                    dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                    AuditLogger.LogAction("LOADED_PROD", "ProductList", $"Loaded {dt.Rows.Count} products | Search: '{SearchText}' | Branch: {Login.LoggedInBranchID}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "ProductList", $"Load products failed | Branch: {Login.LoggedInBranchID} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBranchProducts(txtSearch.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadBranchProducts()
        AuditLogger.LogAction("REFRESH_LIST", "ProductList", "Product list refreshed & search cleared")
    End Sub

    Private Sub btnaddproduct_Click(sender As Object, e As EventArgs) Handles btnaddproduct.Click
        AuditLogger.LogAction("OPEN_ADD_PROD", "ProductList", "Opened add product scan form")
        frmProductScanAdd.Show()
    End Sub

End Class