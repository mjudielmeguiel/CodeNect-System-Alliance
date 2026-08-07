Imports System.Data
Imports MySqlConnector

Public Class frmADDProduct_Scan

    Private Current_AccountID As String = ""
    Private connStr As String = DBConnection.connStr
    Private _productImagePath As String = ""

    Private Const phBarcode As String = "Enter or Scan Barcode..."
    Private Const phPrice As String = "Enter Price..."

    Private Sub ADD_Description_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Current_AccountID = Login.LoggedInAccountID
        Me.Text = "ADD NEW PRODUCT | Account ID: " & Current_AccountID

        txtBarcode.Enabled = True
        txtBarcode.ReadOnly = False
        txtBarcode.Text = phBarcode
        txtBarcode.ForeColor = Color.Gray
        txtBarcode.Focus()

        LoadCategoryList()
        SetFieldsSettings()
        GenerateRandom6DigitSKU()
        AuditLogger.LogAction("OPEN_ADD_DESC", "AddProductScan", $"Opened Add Product Form | Account: {Current_AccountID}")
    End Sub

    Private Sub LoadCategoryList()
        Try
            cboCategory.Items.Clear()
            If String.IsNullOrEmpty(Current_AccountID) Then Exit Sub

            Using conn As New MySqlConnection(connStr)
                Dim qry As String = "SELECT `category_name` FROM `product_categories` WHERE `ACCOUNT_ID` = @Acc ORDER BY `category_name`"
                Using cmd As New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@Acc", Current_AccountID)
                    conn.Open()
                    Dim dr = cmd.ExecuteReader()
                    While dr.Read()
                        cboCategory.Items.Add(dr("category_name").ToString())
                    End While
                    dr.Close()
                End Using
            End Using
            cboCategory.Text = ""
            AuditLogger.LogAction("CATS_LOADED", "AddProductScan", $"Category list loaded | Account: {Current_AccountID}")
        Catch ex As Exception
            MessageBox.Show("Load Category: " & ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("ERROR", "AddProductScan", $"Load categories failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub GenerateRandom6DigitSKU()
        Try
            Dim newSKU As String = ""
            Dim exists As Boolean
            Dim rnd As New Random()
            Do
                newSKU = rnd.Next(100000, 999999).ToString("D6")
                Using conn As New MySqlConnection(connStr)
                    Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM `admin_inventory_file` WHERE `SKU` = @SKU AND `ACCOUNT_ID` = @AccID", conn)
                    cmd.Parameters.AddWithValue("@SKU", newSKU)
                    cmd.Parameters.AddWithValue("@AccID", Current_AccountID)
                    conn.Open()
                    exists = (CInt(cmd.ExecuteScalar()) > 0)
                End Using
            Loop While exists
            lblSKU.Text = newSKU
            AuditLogger.LogAction("SKU_GENERATED", "AddProductScan", $"New SKU generated: {newSKU}")
        Catch
            lblSKU.Text = New Random().Next(100000, 999999).ToString("D6")
            AuditLogger.LogAction("SKU_FALLBACK", "AddProductScan", "Used fallback SKU generation")
        End Try
    End Sub

    Private Sub txtBarcode_Enter(sender As Object, e As EventArgs) Handles txtBarcode.Enter
        If txtBarcode.Text = phBarcode Then
            txtBarcode.Text = ""
            txtBarcode.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtBarcode_Leave(sender As Object, e As EventArgs) Handles txtBarcode.Leave
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            txtBarcode.Text = phBarcode
            txtBarcode.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If txtBarcode.Text = phBarcode Then Exit Sub

        Dim bc As String = txtBarcode.Text.Trim()
        If bc.Length >= 1 Then
            LoadVendorDetails(bc)
        Else
            ClearAll()
            GenerateRandom6DigitSKU()
        End If
    End Sub

    Private Sub LoadVendorDetails(barcode As String)
        Try
            Using conn As New MySqlConnection(connStr)
                Dim qry As String = "SELECT `DESCRIPTIONS`, `BRAND`, `CATEGORY`, `VENDOR_CODE`, `VENDOR`, `UNIT`, `SIZE`, `PRICE`, `PRODUCT_IMAGE` FROM `Vendor_Products` WHERE TRIM(`BARCODE`) = @BC"
                Using cmd As New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@BC", barcode)
                    conn.Open()
                    Dim dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        txtDescription.Text = dr("DESCRIPTIONS").ToString().Trim()
                        txtBrand.Text = dr("BRAND").ToString().Trim()

                        Dim catName As String = dr("CATEGORY").ToString().Trim()
                        If cboCategory.Items.Contains(catName) Then
                            cboCategory.SelectedItem = catName
                        Else
                            cboCategory.Text = catName
                        End If

                        txtVendorcode.Text = dr("VENDOR_CODE").ToString().Trim()
                        txtVendor.Text = dr("VENDOR").ToString().Trim()
                        txtUnit.Text = dr("UNIT").ToString().Trim()
                        txtSize.Text = dr("SIZE").ToString().Trim()
                        txtPrice.Text = CDec(dr("PRICE")).ToString("0.00")
                        txtPrice.ForeColor = Color.Black
                        _productImagePath = If(dr.IsDBNull(dr.GetOrdinal("PRODUCT_IMAGE")), "", dr("PRODUCT_IMAGE").ToString().Trim())
                        AuditLogger.LogAction("VENDOR_FOUND", "AddProductScan", $"Vendor details loaded | Barcode: {barcode}")
                    Else
                        ClearAll()
                        AuditLogger.LogAction("VENDOR_NOTFOUND", "AddProductScan", $"No vendor record | Barcode: {barcode}")
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("ERROR", "AddProductScan", $"Load vendor failed | Barcode: {barcode} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub txtPrice_Enter(sender As Object, e As EventArgs) Handles txtPrice.Enter
        If txtPrice.Text = phPrice Then
            txtPrice.Text = ""
            txtPrice.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPrice_Leave(sender As Object, e As EventArgs) Handles txtPrice.Leave
        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            txtPrice.Text = phPrice
            txtPrice.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub SetFieldsSettings()
        txtPrice.Text = phPrice
        txtPrice.ForeColor = Color.Gray
    End Sub

    Private Sub ClearAll()
        lblSKU.Text = ""
        txtDescription.Clear()
        txtBrand.Clear()
        cboCategory.Text = ""
        txtVendorcode.Clear()
        txtVendor.Clear()
        txtUnit.Clear()
        txtSize.Clear()
        _productImagePath = ""
        GenerateRandom6DigitSKU()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bc As String = txtBarcode.Text.Trim()
        If bc = phBarcode OrElse String.IsNullOrWhiteSpace(bc) Then
            MessageBox.Show("Enter or Scan Barcode.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            AuditLogger.LogAction("VALID_FAIL", "AddProductScan", "Save cancelled - no barcode")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("No product found.", "Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("VALID_FAIL", "AddProductScan", "Save cancelled - no description")
            Return
        End If
        If String.IsNullOrWhiteSpace(cboCategory.Text) Then
            MessageBox.Show("Select or enter Category.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            AuditLogger.LogAction("VALID_FAIL", "AddProductScan", "Save cancelled - no category")
            Return
        End If
        If Not Decimal.TryParse(txtPrice.Text.Trim(), Nothing) Then
            MessageBox.Show("Enter valid Price.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            AuditLogger.LogAction("VALID_FAIL", "AddProductScan", "Save cancelled - invalid price")
            Return
        End If

        ' CHECK DUPLICATE
        Try
            Using conn As New MySqlConnection(connStr)
                Dim chk As String = "SELECT COUNT(*) FROM `admin_inventory_file` WHERE `ACCOUNT_ID`=@Acc AND (`BARCODE`=@BC OR `SKU`=@SKU)"
                Using cmd As New MySqlCommand(chk, conn)
                    cmd.Parameters.AddWithValue("@Acc", Current_AccountID)
                    cmd.Parameters.AddWithValue("@BC", bc)
                    cmd.Parameters.AddWithValue("@SKU", lblSKU.Text.Trim())
                    conn.Open()
                    If CInt(cmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Product already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        AuditLogger.LogAction("DUPLICATE", "AddProductScan", $"Duplicate detected | Barcode: {bc} | SKU: {lblSKU.Text.Trim()}")
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Check Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "AddProductScan", $"Duplicate check failed | Error: {ex.Message}")
            Return
        End Try

        ' SAVE
        If MessageBox.Show("Save this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As New MySqlConnection(connStr)
                    Dim ins As String = "INSERT INTO `admin_inventory_file` 
                    (`ACCOUNT_ID`,`BARCODE`,`BRAND`,`CATEGORY`,`DATE_ADDED`,`DESCRIPTIONS`,`PRICE`,`PRODUCT_IMAGE`,`SIZE`,`SKU`,`UNIT`,`VENDOR`,`VENDOR_CODE`)
                    VALUES (@Acc,@BC,@Brand,@Cat,NOW(),@Desc,@Price,@Img,@Size,@SKU,@Unit,@Ven,@VenCode)"
                    Using cmd As New MySqlCommand(ins, conn)
                        cmd.Parameters.AddWithValue("@Acc", Current_AccountID)
                        cmd.Parameters.AddWithValue("@BC", bc)
                        cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim())
                        cmd.Parameters.AddWithValue("@Cat", cboCategory.Text.Trim())
                        cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim())
                        cmd.Parameters.AddWithValue("@Price", CDec(txtPrice.Text.Trim()))
                        cmd.Parameters.AddWithValue("@Img", If(String.IsNullOrEmpty(_productImagePath), DBNull.Value, _productImagePath))
                        cmd.Parameters.AddWithValue("@Size", txtSize.Text.Trim())
                        cmd.Parameters.AddWithValue("@SKU", lblSKU.Text.Trim())
                        cmd.Parameters.AddWithValue("@Unit", txtUnit.Text.Trim())
                        cmd.Parameters.AddWithValue("@Ven", txtVendor.Text.Trim())
                        cmd.Parameters.AddWithValue("@VenCode", txtVendorcode.Text.Trim())
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Saved successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("PROD_SAVED", "AddProductScan", $"Product added | Barcode: {bc} | SKU: {lblSKU.Text.Trim()} | Desc: {txtDescription.Text.Trim()}")
                ClearAll()
            Catch ex As Exception
                MessageBox.Show("Save failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                AuditLogger.LogAction("SAVE_FAIL", "AddProductScan", $"Insert failed | Barcode: {bc} | Error: {ex.Message}")
            End Try
        Else
            AuditLogger.LogAction("SAVE_CANCEL", "AddProductScan", $"Save cancelled by user | Barcode: {bc}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AuditLogger.LogAction("OPEN_CAT", "AddProductScan", "Opened Category Manager")
        frmCategory.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        AuditLogger.LogAction("CLOSE_ADD", "AddProductScan", "Form closed without saving")
        ClearAll()
        Me.Close()
    End Sub
End Class