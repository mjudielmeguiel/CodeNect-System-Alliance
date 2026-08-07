Imports MySqlConnector

Public Class frmBranches

    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub frmBranches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllAccounts()
    End Sub

    Private Sub LoadAllAccounts()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sql As String = "
                    SELECT account_id, ACCOUNT, owner_fullname, address, contact, email, 
                           business_type, status, created_at, serial_number
                    FROM account
                    ORDER BY ACCOUNT"

                Using cmd As New MySqlCommand(sql, conn)
                    Using dt As New DataTable()
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using

                        dgvBranches.DataSource = Nothing
                        dgvBranches.Columns.Clear()
                        dgvBranches.DataSource = dt

                        AddImportButton()
                        FormatColumns()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading Accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddImportButton()
        Dim btnImport As New DataGridViewButtonColumn()
        With btnImport
            .Name = "colImport"
            .HeaderText = "Action"
            .Text = "Import Products"
            .UseColumnTextForButtonValue = True
            .Width = 110
            .DefaultCellStyle.BackColor = Color.LightGreen
        End With
        dgvBranches.Columns.Add(btnImport)
    End Sub

    Private Sub FormatColumns()
        If dgvBranches.Columns.Count = 0 Then Exit Sub

        dgvBranches.AllowUserToAddRows = False
        dgvBranches.ReadOnly = True
        dgvBranches.RowTemplate.Height = 28
        dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvBranches.Columns("account_id").HeaderText = "Account ID"
        dgvBranches.Columns("ACCOUNT").HeaderText = "Account Name"
        dgvBranches.Columns("owner_fullname").HeaderText = "Owner Name"
        dgvBranches.Columns("address").HeaderText = "Address"
        dgvBranches.Columns("contact").HeaderText = "Contact"
        dgvBranches.Columns("email").HeaderText = "Email"
        dgvBranches.Columns("business_type").HeaderText = "Business Type"
        dgvBranches.Columns("status").HeaderText = "Status"
        dgvBranches.Columns("created_at").HeaderText = "Created Date"
        dgvBranches.Columns("serial_number").HeaderText = "Serial Number"

        dgvBranches.Columns("created_at").DefaultCellStyle.Format = "yyyy-MM-dd"
    End Sub

    Private Sub dgvBranches_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBranches.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = dgvBranches.Columns("colImport").Index Then
            Dim targetAccountID As String = dgvBranches.Rows(e.RowIndex).Cells("account_id").Value.ToString()
            Dim accountName As String = dgvBranches.Rows(e.RowIndex).Cells("ACCOUNT").Value.ToString()

            Dim vendorCode As String = DBConnection.CurrentVendorCode

            If String.IsNullOrWhiteSpace(vendorCode) Then
                MessageBox.Show("No Vendor logged in.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MessageBox.Show($"Import ALL Products to:{vbCrLf}{vbCrLf}Account: {accountName}{vbCrLf}Account ID: {targetAccountID}",
                             "Confirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Exit Sub
            End If

            ImportProductsToAccount(vendorCode, targetAccountID)
        End If
    End Sub

    Private Sub ImportProductsToAccount(vendorCode As String, accountID As String)
        Dim importedCount As Integer = 0
        Dim skippedCount As Integer = 0

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim getProductsSql As String = "
                            SELECT BARCODE, BRAND, DESCRIPTIONS, SIZE, UNIT, VENDOR, VENDOR_CODE, PRODUCT_IMAGE
                            FROM vendor_products
                            WHERE VENDOR_CODE = @VENDOR_CODE"

                        Dim productList As New List(Of ProductInfo)()

                        ' ✅ BASAHIN MUNA LAHAT AT ILAGAY SA LISTAHAN BAGO ISARA ANG READER
                        Using cmdGet As New MySqlCommand(getProductsSql, conn, tran)
                            cmdGet.Parameters.AddWithValue("@VENDOR_CODE", vendorCode)

                            Using dr As MySqlDataReader = cmdGet.ExecuteReader()
                                While dr.Read()
                                    Dim prod As New ProductInfo()
                                    prod.Barcode = dr("BARCODE").ToString()
                                    prod.Brand = dr("BRAND").ToString()
                                    prod.Description = dr("DESCRIPTIONS").ToString()
                                    prod.Size = dr("SIZE").ToString()
                                    prod.Unit = dr("UNIT").ToString()
                                    prod.VendorName = dr("VENDOR").ToString()
                                    prod.VendorCode = dr("VENDOR_CODE").ToString()
                                    prod.ProductImage = If(dr("PRODUCT_IMAGE") IsNot DBNull.Value, dr("PRODUCT_IMAGE").ToString(), "")
                                    productList.Add(prod)
                                End While
                            End Using ' ✅ Dito lang isasara ang Reader — tapos na basahin lahat
                        End Using

                        ' ✅ NGAYON — I-PROSESO ANG LISTAHAN (HINDI NA DEPENDE SA READER)
                        For Each item In productList
                            Dim checkSql As String = "
                                SELECT COUNT(*) FROM admin_inventory_file 
                                WHERE BARCODE = @BARCODE AND ACCOUNT_ID = @ACCOUNT_ID"

                            Using cmdCheck As New MySqlCommand(checkSql, conn, tran)
                                cmdCheck.Parameters.AddWithValue("@BARCODE", item.Barcode)
                                cmdCheck.Parameters.AddWithValue("@ACCOUNT_ID", accountID)

                                Dim exists = Convert.ToInt32(cmdCheck.ExecuteScalar())

                                If exists > 0 Then
                                    skippedCount += 1
                                    Continue For
                                End If
                            End Using

                            ' ✅ Gumamit ng 0.00 kung hindi pa naayos ang PRICE column sa DB
                            Dim insertSql As String = "
                                INSERT INTO admin_inventory_file 
                                (ACCOUNT_ID, BARCODE, BRAND, DESCRIPTIONS, SIZE, UNIT, 
                                 VENDOR, VENDOR_CODE, PRODUCT_IMAGE, DATE_ADDED, PRICE, CATEGORY)
                                VALUES (@ACCID, @BAR, @BRAND, @DESC, @SIZE, @UNIT,
                                        @VENDOR, @VENDOR_CODE, @IMAGE, NOW(), 0.00, NULL)"

                            Using cmdInsert As New MySqlCommand(insertSql, conn, tran)
                                cmdInsert.Parameters.AddWithValue("@ACCID", accountID)
                                cmdInsert.Parameters.AddWithValue("@BAR", item.Barcode)
                                cmdInsert.Parameters.AddWithValue("@BRAND", item.Brand)
                                cmdInsert.Parameters.AddWithValue("@DESC", item.Description)
                                cmdInsert.Parameters.AddWithValue("@SIZE", item.Size)
                                cmdInsert.Parameters.AddWithValue("@UNIT", item.Unit)
                                cmdInsert.Parameters.AddWithValue("@VENDOR", item.VendorName)
                                cmdInsert.Parameters.AddWithValue("@VENDOR_CODE", item.VendorCode)
                                cmdInsert.Parameters.AddWithValue("@IMAGE", If(String.IsNullOrWhiteSpace(item.ProductImage), DBNull.Value, item.ProductImage))
                                cmdInsert.ExecuteNonQuery()
                            End Using

                            importedCount += 1
                        Next

                        tran.Commit()

                        Dim msg As String = $"Import Complete!{vbCrLf}{vbCrLf}" &
                                            $"Imported: {importedCount} Products{vbCrLf}"
                        If skippedCount > 0 Then
                            msg &= $"Skipped (Already exists): {skippedCount}"
                        End If

                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Import Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Class ProductInfo
        Public Property Barcode As String
        Public Property Brand As String
        Public Property Description As String
        Public Property Size As String
        Public Property Unit As String
        Public Property VendorName As String
        Public Property VendorCode As String
        Public Property ProductImage As String
    End Class

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim keyword As String = txtSearch.Text.Trim()

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sql As String = "
                    SELECT account_id, ACCOUNT, owner_fullname, address, contact, email, 
                           business_type, status, created_at, serial_number
                    FROM account
                    WHERE ACCOUNT LIKE @KEYWORD 
                       OR account_id LIKE @KEYWORD
                       OR owner_fullname LIKE @KEYWORD
                       OR contact LIKE @KEYWORD
                       OR status LIKE @KEYWORD
                    ORDER BY ACCOUNT"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@KEYWORD", "%" & keyword & "%")

                    Using dt As New DataTable()
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                        dgvBranches.DataSource = dt
                        AddImportButton()
                        FormatColumns()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAllAccounts()
        txtSearch.Clear()
    End Sub

End Class