Imports System.Data
Imports MySqlConnector
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class frmADDProduct_Scan

    Private Current_AccountID As String = ""
    Private Current_BranchID As String = ""
    Private connStr As String = DBConnection.connStr

    Private Const phBarcode As String = "Enter barcode..."
    Private Const phQty As String = "Enter quantity..."
    Private Const phPrice As String = "Enter price..."

    Private Sub ADD_Description_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetIDsUsingBranchName()
        SetFieldsSettings()
        GenerateRandom6DigitSKU()

        picProduct.SizeMode = PictureBoxSizeMode.Zoom
        picProduct.BackColor = Color.White
        picProduct.Image = Nothing
        picProduct.Cursor = Cursors.Hand

        Me.Text = "ADD NEW PRODUCT | Account ID: " & Current_AccountID & " | Branch ID: " & Current_BranchID
    End Sub

    Private Sub GetIDsUsingBranchName()
        Try
            Dim BranchNameFromDashboard As String = DashBoard.ToolStripStatusLabel4.Text.Trim()
            If String.IsNullOrEmpty(BranchNameFromDashboard) Then
                MessageBox.Show("Branch name not found from Dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using conn As New MySqlConnection(connStr)
                ' ✅ TOP 1 → LIMIT 1, dbo. removed, TRIM() instead of RTRIM+LTRIM
                Dim query As String = "SELECT `ACCOUNT_ID`, `BRANCH_ID` FROM `User_Accounts` WHERE TRIM(`BRANCH`) = TRIM(@BranchName) AND `STATUS` = 'Active' ORDER BY `ID` DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BranchName", BranchNameFromDashboard)
                    conn.Open()
                    Dim dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Current_AccountID = dr("ACCOUNT_ID").ToString().Trim()
                        Current_BranchID = dr("BRANCH_ID").ToString().Trim()
                    Else
                        MessageBox.Show("No record found for this branch.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting IDs: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picProduct_DoubleClick(sender As Object, e As EventArgs) Handles picProduct.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Product Image"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.RestoreDirectory = True
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    picProduct.Image = Image.FromFile(ofd.FileName)
                Catch ex As Exception
                    MessageBox.Show("Cannot open image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Function ImageToByteArray(img As Image) As Byte()
        If img Is Nothing Then Return Nothing
        Try
            Using bmp As New Bitmap(img)
                Using ms As New MemoryStream()
                    bmp.Save(ms, ImageFormat.Png)
                    Return ms.ToArray()
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub GenerateRandom6DigitSKU()
        Try
            Dim newSKU As String = ""
            Dim exists As Boolean
            Dim rnd As New Random()
            Do
                newSKU = rnd.Next(100000, 999999).ToString("D6")
                Using conn As New MySqlConnection(connStr)
                    ' ✅ inv. prefix removed, backticks added
                    Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM `Inventory_Master_file` WHERE `SKU` = @SKU AND `ACCOUNT_ID` = @AccID", conn)
                    cmd.Parameters.AddWithValue("@SKU", newSKU)
                    cmd.Parameters.AddWithValue("@AccID", Current_AccountID)
                    conn.Open()
                    exists = (CInt(cmd.ExecuteScalar()) > 0)
                End Using
            Loop While exists
            lblSKU.Text = newSKU
        Catch
            Dim rndBackup As New Random(DateTime.Now.Millisecond)
            lblSKU.Text = rndBackup.Next(100000, 999999).ToString("D6")
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
        If txtBarcode.Text <> phBarcode AndAlso txtBarcode.Text.Trim.Length >= 5 Then
            LoadVendorDetails()
        ElseIf txtBarcode.Text <> phBarcode Then
            ClearAll()
            GenerateRandom6DigitSKU()
        End If
    End Sub

    Private Sub LoadVendorDetails()
        Try
            Using conn As New MySqlConnection(connStr)
                ' ✅ dbo. removed, TRIM() instead of RTRIM+LTRIM, backticks added
                Dim query As String = "SELECT `DESCRIPTIONS`, `BRAND`, `CATEGORY`, `VENDOR_CODE`, `VENDOR`, `UNIT`, `SIZE`, `PRICE`, `PRODUCT_IMAGE` FROM `Vendor_Products` WHERE TRIM(`BARCODE`) = @Barcode"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim())
                    conn.Open()
                    Dim dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        lblDescription.Text = dr("DESCRIPTIONS").ToString().Trim()
                        lblBrand.Text = dr("BRAND").ToString().Trim()
                        lblCategory.Text = dr("CATEGORY").ToString().Trim()
                        lblVendorCode.Text = dr("VENDOR_CODE").ToString().Trim()
                        lblVendor.Text = dr("VENDOR").ToString().Trim()
                        lblUnit.Text = dr("UNIT").ToString().Trim()
                        lblSize.Text = dr("SIZE").ToString().Trim()
                        txtPrice.Text = CDec(dr("PRICE")).ToString("0.00")
                        txtPrice.ForeColor = Color.Black
                        picProduct.Image = Nothing
                        If Not dr.IsDBNull(dr.GetOrdinal("PRODUCT_IMAGE")) Then
                            Try
                                Dim imgBytes As Byte() = DirectCast(dr("PRODUCT_IMAGE"), Byte())
                                If imgBytes.Length > 0 Then
                                    Using ms As New MemoryStream(imgBytes)
                                        picProduct.Image = Image.FromStream(ms)
                                    End Using
                                End If
                            Catch
                                picProduct.Image = Nothing
                            End Try
                        End If
                        txtStockAvailable.Clear()
                        lblAvailability.Text = ""
                        lblTotal.Text = "0.00"
                    Else
                        ClearAll()
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Vendor info: " & ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtStockAvailable_TextChanged(sender As Object, e As EventArgs) Handles txtStockAvailable.TextChanged
        If txtStockAvailable.Text = phQty Then Exit Sub
        txtStockAvailable.ForeColor = Color.Black
        ComputeTotal()
        SetAvailabilityStatus()
    End Sub

    Private Sub txtStockAvailable_Enter(sender As Object, e As EventArgs) Handles txtStockAvailable.Enter
        If txtStockAvailable.Text = phQty Then
            txtStockAvailable.Text = ""
            txtStockAvailable.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtStockAvailable_Leave(sender As Object, e As EventArgs) Handles txtStockAvailable.Leave
        If String.IsNullOrWhiteSpace(txtStockAvailable.Text) Then
            txtStockAvailable.Text = phQty
            txtStockAvailable.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        If txtPrice.Text = phPrice Then Exit Sub
        txtPrice.ForeColor = Color.Black
        ComputeTotal()
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

    Private Sub ComputeTotal()
        Try
            Dim price As Decimal = 0
            Dim qty As Integer = 0
            If txtPrice.Text <> phPrice AndAlso txtStockAvailable.Text <> phQty Then
                If Decimal.TryParse(txtPrice.Text.Trim(), price) AndAlso Integer.TryParse(txtStockAvailable.Text.Trim(), qty) Then
                    lblTotal.Text = (price * qty).ToString("0.00")
                Else
                    lblTotal.Text = "0.00"
                End If
            End If
        Catch
            lblTotal.Text = "0.00"
        End Try
    End Sub

    Private Sub SetAvailabilityStatus()
        Try
            Dim stock As Integer = 0
            If txtStockAvailable.Text <> phQty AndAlso Integer.TryParse(txtStockAvailable.Text.Trim(), stock) Then
                Select Case stock
                    Case 0
                        lblAvailability.Text = "OUT OF STOCK"
                        lblAvailability.ForeColor = Color.Red
                    Case 1 To 10
                        lblAvailability.Text = "CRITICAL"
                        lblAvailability.ForeColor = Color.Orange
                    Case Is > 10
                        lblAvailability.Text = "AVAILABLE"
                        lblAvailability.ForeColor = Color.Green
                End Select
            Else
                lblAvailability.Text = ""
            End If
        Catch
            lblAvailability.Text = ""
        End Try
    End Sub

    Private Sub SetFieldsSettings()
        txtBarcode.Text = phBarcode
        txtBarcode.ForeColor = Color.Gray
        txtStockAvailable.Text = phQty
        txtStockAvailable.ForeColor = Color.Gray
        txtPrice.Text = phPrice
        txtPrice.ForeColor = Color.Gray

        txtBarcode.BackColor = Color.White
        txtStockAvailable.BackColor = Color.White
        txtPrice.BackColor = Color.White
    End Sub

    Private Sub ClearAll()
        lblSKU.Text = ""
        lblDescription.Text = ""
        lblBrand.Text = ""
        lblCategory.Text = ""
        lblVendorCode.Text = ""
        lblVendor.Text = ""
        lblUnit.Text = ""
        lblSize.Text = ""
        lblAvailability.Text = ""
        lblTotal.Text = "0.00"
        picProduct.Image = Nothing
        GenerateRandom6DigitSKU()

        txtBarcode.Text = phBarcode
        txtBarcode.ForeColor = Color.Gray
        txtStockAvailable.Text = phQty
        txtStockAvailable.ForeColor = Color.Gray
        txtPrice.Text = phPrice
        txtPrice.ForeColor = Color.Gray
    End Sub

    Private Sub btnSaveProduct_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(Current_AccountID) Or String.IsNullOrEmpty(Current_BranchID) Then
            MessageBox.Show("Account or Branch ID not found. Cannot save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If txtBarcode.Text = phBarcode OrElse String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            MessageBox.Show("Please enter Barcode.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(lblDescription.Text) Then
            MessageBox.Show("Product details not found. Check Barcode.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtPrice.Text = phPrice OrElse Not Decimal.TryParse(txtPrice.Text.Trim(), Nothing) Then
            MessageBox.Show("Please enter valid Price.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If
        If txtStockAvailable.Text = phQty OrElse Not Integer.TryParse(txtStockAvailable.Text.Trim(), Nothing) Then
            MessageBox.Show("Please enter valid Stock Quantity.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockAvailable.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                ' ✅ Updated table/column names
                Dim checkQuery As String = "SELECT COUNT(*) FROM `Inventory_Master_file` WHERE `ACCOUNT_ID` = @AccID AND `BRANCH_ID` = @BrID AND (`BARCODE` = @Barcode OR `SKU` = @SKU)"
                Using cmdCheck As New MySqlCommand(checkQuery, conn)
                    cmdCheck.Parameters.AddWithValue("@AccID", Current_AccountID)
                    cmdCheck.Parameters.AddWithValue("@BrID", Current_BranchID)
                    cmdCheck.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim())
                    cmdCheck.Parameters.AddWithValue("@SKU", lblSKU.Text.Trim())
                    conn.Open()
                    Dim existingCount As Integer = CInt(cmdCheck.ExecuteScalar())
                    If existingCount > 0 Then
                        MessageBox.Show("Product already exists with this Barcode or SKU.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking duplicate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim confirm = MessageBox.Show("Save this product?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Dim imgBytes As Byte() = ImageToByteArray(picProduct.Image)
            Using conn As New MySqlConnection(connStr)
                ' ✅ Updated INSERT query for MySQL
                Dim query As String = "INSERT INTO `Inventory_Master_file` (`ACCOUNT_ID`, `BRANCH_ID`, `PRODUCT_IMAGE`, `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `CATEGORY`, `SIZE`, `PRICE`, `UNIT`, `AVAILABLE`, `VENDOR_CODE`, `VENDOR`) VALUES (@ACCOUNT, @BRANCH, @PRODUCT_IMAGE, @BARCODE, @SKU, @BRAND, @DESCRIPTIONS, @CATEGORY, @SIZE, @PRICE, @UNIT, @AVAILABLE, @VENDOR_CODE, @VENDOR)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ACCOUNT", Current_AccountID)
                    cmd.Parameters.AddWithValue("@BRANCH", Current_BranchID)
                    cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", If(imgBytes IsNot Nothing, imgBytes, DBNull.Value))
                    cmd.Parameters.AddWithValue("@BARCODE", txtBarcode.Text.Trim())
                    cmd.Parameters.AddWithValue("@SKU", lblSKU.Text.Trim())
                    cmd.Parameters.AddWithValue("@BRAND", lblBrand.Text.Trim())
                    cmd.Parameters.AddWithValue("@DESCRIPTIONS", lblDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@CATEGORY", lblCategory.Text.Trim())
                    cmd.Parameters.AddWithValue("@SIZE", lblSize.Text.Trim())
                    cmd.Parameters.AddWithValue("@PRICE", CDec(txtPrice.Text.Trim()))
                    cmd.Parameters.AddWithValue("@UNIT", lblUnit.Text.Trim())
                    cmd.Parameters.AddWithValue("@AVAILABLE", CInt(txtStockAvailable.Text.Trim()))
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", lblVendorCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@VENDOR", lblVendor.Text.Trim())

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Product saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAll()
        Catch ex As Exception
            MessageBox.Show("Save failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class