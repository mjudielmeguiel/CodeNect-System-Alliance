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

        LoadBranchList()
        LoadAllProducts()
    End Sub

    ' ✅ I-LOAD ANG MGA BRANCH NG KASALUKUYANG ACCOUNT
    Private Sub LoadBranchList()
        Try
            cboBranch.Items.Clear()
            cboBranch.DisplayMember = "BRANCH"
            cboBranch.ValueMember = "BRANCH_ID"

            Dim dtBranch As New DataTable()
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    SELECT BRANCH_ID, BRANCH 
                    FROM branches 
                    WHERE ACCOUNT_ID = @ACCT 
                    ORDER BY BRANCH ASC", conn)
                cmd.Parameters.AddWithValue("@ACCT", CurrentAccountID.Trim())
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtBranch)
                End Using
            End Using

            If dtBranch.Rows.Count > 0 Then
                cboBranch.DataSource = dtBranch
            Else
                MessageBox.Show("No branches found for this account.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            AuditLogger.LogAction("BRANCH_LOADED", "DescManager", $"Loaded {dtBranch.Rows.Count} branches for account")
        Catch ex As Exception
            MessageBox.Show("Failed to load branches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("BRANCH_ERROR", "DescManager", $"Load branch failed: {ex.Message}")
        End Try
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

    ' ✅ AYOS NA — LAHAT NG HINDI PA NANDOON SA BRANCH AY II-IMPORT
    Private Sub btnImportToBranch_Click(sender As Object, e As EventArgs) Handles btnImportToBranch.Click
        If cboBranch.SelectedIndex = -1 Then
            MessageBox.Show("Please select a target Branch first.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBranch.Focus()
            Return
        End If

        Dim drv As DataRowView = TryCast(cboBranch.SelectedItem, DataRowView)
        If drv Is Nothing Then Return

        Dim targetBranchID As String = drv("BRANCH_ID").ToString().Trim()
        Dim targetBranchName As String = drv("BRANCH").ToString().Trim()
        Dim addedCount As Integer = 0
        Dim skipCount As Integer = 0
        Dim totalCount As Integer = dgvProducts.Rows.Count

        If totalCount = 0 Then
            MessageBox.Show("No products to import.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        ' ✅ Kunin muna lahat ng nandoon na sa Branch — para mabilis
                        Dim existingProducts As New DataTable()
                        Dim getExistingSql As String = "
                            SELECT BARCODE, SKU 
                            FROM inventory_information 
                            WHERE ACCOUNT_ID = @ACCT AND BRANCH_ID = @BID"

                        Using cmdGet As New MySqlCommand(getExistingSql, conn, tran)
                            cmdGet.Parameters.AddWithValue("@ACCT", CurrentAccountID)
                            cmdGet.Parameters.AddWithValue("@BID", targetBranchID)
                            Using da As New MySqlDataAdapter(cmdGet)
                                da.Fill(existingProducts)
                            End Using
                        End Using

                        ' ✅ Gumawa ng listahan ng mga nandoon na
                        Dim existingBarcodes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                        Dim existingSKUs As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

                        For Each exRow As DataRow In existingProducts.Rows
                            If Not IsDBNull(exRow("BARCODE")) AndAlso Not String.IsNullOrWhiteSpace(exRow("BARCODE").ToString()) Then
                                existingBarcodes.Add(exRow("BARCODE").ToString().Trim())
                            End If
                            If Not IsDBNull(exRow("SKU")) AndAlso Not String.IsNullOrWhiteSpace(exRow("SKU").ToString()) Then
                                existingSKUs.Add(exRow("SKU").ToString().Trim())
                            End If
                        Next

                        ' ✅ PROSESOHIN ANG BAWAT PRODUKTO
                        For Each row As DataGridViewRow In dgvProducts.Rows
                            If row.IsNewRow Then Continue For

                            Dim barCode As String = If(row.Cells("BARCODE")?.Value Is Nothing, "", row.Cells("BARCODE").Value.ToString().Trim())
                            Dim skuCode As String = If(row.Cells("SKU")?.Value Is Nothing, "", row.Cells("SKU").Value.ToString().Trim())

                            ' ✅ Suriin kung nandoon na
                            Dim isExists As Boolean = False
                            If Not String.IsNullOrWhiteSpace(barCode) AndAlso existingBarcodes.Contains(barCode) Then
                                isExists = True
                            End If
                            If Not String.IsNullOrWhiteSpace(skuCode) AndAlso existingSKUs.Contains(skuCode) Then
                                isExists = True
                            End If

                            If isExists Then
                                skipCount += 1
                                Continue For
                            End If

                            ' ✅ I-IMPORT ANG BAGONG PRODUKTO
                            Dim priceVal As Decimal = 0
                            If row.Cells("PRICE")?.Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("PRICE").Value) Then
                                Decimal.TryParse(row.Cells("PRICE").Value.ToString(), priceVal)
                            End If

                            Dim insertCmd As New MySqlCommand("
                                INSERT INTO inventory_information 
                                (ACCOUNT_ID, BRANCH_ID, BARCODE, SKU, BRAND, CATEGORY, DESCRIPTIONS, PRICE, SIZE, UNIT, VENDOR, VENDOR_CODE, AVAILABILITY, AVAILABLE, TOTAL)
                                VALUES 
                                (@ACCT, @BID, @BAR, @SKU, @BRAND, @CAT, @DESC, @PRICE, @SIZE, @UNIT, @VEND, @VENDCODE, 'PENDING', 0, 0)", conn, tran)

                            insertCmd.Parameters.AddWithValue("@ACCT", CurrentAccountID)
                            insertCmd.Parameters.AddWithValue("@BID", targetBranchID)
                            insertCmd.Parameters.AddWithValue("@BAR", If(String.IsNullOrWhiteSpace(barCode), DBNull.Value, barCode))
                            insertCmd.Parameters.AddWithValue("@SKU", If(String.IsNullOrWhiteSpace(skuCode), DBNull.Value, skuCode))
                            insertCmd.Parameters.AddWithValue("@BRAND", If(row.Cells("BRAND")?.Value Is Nothing OrElse IsDBNull(row.Cells("BRAND").Value), DBNull.Value, row.Cells("BRAND").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@CAT", If(row.Cells("CATEGORY")?.Value Is Nothing OrElse IsDBNull(row.Cells("CATEGORY").Value), DBNull.Value, row.Cells("CATEGORY").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@DESC", If(row.Cells("DESCRIPTIONS")?.Value Is Nothing OrElse IsDBNull(row.Cells("DESCRIPTIONS").Value), DBNull.Value, row.Cells("DESCRIPTIONS").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@PRICE", priceVal)
                            insertCmd.Parameters.AddWithValue("@SIZE", If(row.Cells("SIZE")?.Value Is Nothing OrElse IsDBNull(row.Cells("SIZE").Value), DBNull.Value, row.Cells("SIZE").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@UNIT", If(row.Cells("UNIT")?.Value Is Nothing OrElse IsDBNull(row.Cells("UNIT").Value), DBNull.Value, row.Cells("UNIT").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@VEND", If(row.Cells("VENDOR")?.Value Is Nothing OrElse IsDBNull(row.Cells("VENDOR").Value), DBNull.Value, row.Cells("VENDOR").Value.ToString()))
                            insertCmd.Parameters.AddWithValue("@VENDCODE", If(row.Cells("VENDOR_CODE")?.Value Is Nothing OrElse IsDBNull(row.Cells("VENDOR_CODE").Value), DBNull.Value, row.Cells("VENDOR_CODE").Value.ToString()))

                            insertCmd.ExecuteNonQuery()
                            addedCount += 1
                        Next

                        tran.Commit()

                        MessageBox.Show($"✅ Import Complete!{vbCrLf}{vbCrLf}" &
                                        $"Target Branch: {targetBranchName}{vbCrLf}" &
                                        $"Total Products: {totalCount}{vbCrLf}" &
                                        $"✅ Newly Added: {addedCount}{vbCrLf}" &
                                        $"⏭️ Skipped (Already Exists): {skipCount}",
                                        "Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        AuditLogger.LogAction("IMPORT_BRANCH", "DescManager",
                            $"Imported to Branch [{targetBranchID}] | Total:{totalCount} Added:{addedCount} Skipped:{skipCount}")

                    Catch ex As Exception
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Import Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("IMPORT_ERROR", "DescManager", $"Import failed: {ex.Message}")
        End Try
    End Sub

End Class