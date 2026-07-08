Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class frmADDProduct_Manual
    Private Sub frmADDProduct_Manual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetIDsUsingBranchName()
        SetFieldsSettings()
        GenerateRandom6DigitSKU()

        picProduct.SizeMode = PictureBoxSizeMode.Zoom
        picProduct.BackColor = Color.White
        picProduct.Image = Nothing
        picProduct.Cursor = Cursors.Hand

        Me.Text = "ADD NEW PRODUCT | Account ID: " & Current_AccountID & " | Branch ID: " & Current_BranchID
    End Sub

    Private Current_AccountID As String = ""
    Private Current_BranchID As String = ""

    Private Const phBarcode As String = "Enter barcode..."
    Private Const phQty As String = "Enter quantity..."
    Private Const phPrice As String = "Enter price..."

    Private Sub GetIDsUsingBranchName()
        Try
            Dim BranchNameFromDashboard As String = DashBoard.ToolStripStatusLabel4.Text.Trim()
            If String.IsNullOrEmpty(BranchNameFromDashboard) Then
                MessageBox.Show("Branch name not found from Dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using conn As New SqlConnection(connStr)
                Dim query As String = "SELECT TOP 1 ACCOUNT_ID, BRANCH_ID FROM dbo.User_Accounts WHERE RTRIM(LTRIM(BRANCH)) = RTRIM(LTRIM(@BranchName)) AND STATUS = 'Active' ORDER BY ID DESC"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@BranchName", SqlDbType.NVarChar, 100).Value = BranchNameFromDashboard
                    conn.Open()
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
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
                Using conn As New SqlConnection(connStr)
                    Dim cmd As New SqlCommand("SELECT COUNT(*) FROM inv.Inventory_Master_file WHERE SKU = @SKU AND ACCOUNT_ID = @AccID", conn)
                    cmd.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = newSKU
                    cmd.Parameters.Add("@AccID", SqlDbType.NVarChar, 50).Value = Current_AccountID
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
        ElseIf txtBarcode.Text <> phBarcode Then
            ClearAll()
            GenerateRandom6DigitSKU()
        End If
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
        txtDescription.Text = ""
        txtBrand.Text = ""
        cboCategory.selectedindex = -1
        cboVendorCode.SelectedIndex = -1
        cboVendor.Text = ""
        txtUnit.Text = ""
        txtSize.Text = ""
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
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
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
            Using conn As New SqlConnection(connStr)
                Dim checkQuery As String = "SELECT COUNT(*) FROM inv.Inventory_Master_file WHERE ACCOUNT_ID = @AccID AND BRANCH_ID = @BrID AND (BARCODE = @Barcode OR SKU = @SKU)"
                Using cmdCheck As New SqlCommand(checkQuery, conn)
                    cmdCheck.Parameters.Add("@AccID", SqlDbType.NVarChar, 50).Value = Current_AccountID
                    cmdCheck.Parameters.Add("@BrID", SqlDbType.NVarChar, 50).Value = Current_BranchID
                    cmdCheck.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = txtBarcode.Text.Trim()
                    cmdCheck.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = lblSKU.Text.Trim()
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
            Using conn As New SqlConnection(connStr)
                Dim query As String = "INSERT INTO inv.Inventory_Master_file (ACCOUNT_ID, BRANCH_ID, PRODUCT_IMAGE, BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, PRICE, UNIT, AVAILABLE, VENDOR_CODE, VENDOR) VALUES (@ACCOUNT, @BRANCH, @PRODUCT_IMAGE, @BARCODE, @SKU, @BRAND, @DESCRIPTIONS, @CATEGORY, @SIZE, @PRICE, @UNIT, @AVAILABLE, @VENDOR_CODE, @VENDOR)"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@ACCOUNT", SqlDbType.NVarChar, 50).Value = Current_AccountID
                    cmd.Parameters.Add("@BRANCH", SqlDbType.NVarChar, 50).Value = Current_BranchID
                    cmd.Parameters.Add("@PRODUCT_IMAGE", SqlDbType.VarBinary).Value = If(imgBytes IsNot Nothing, imgBytes, DBNull.Value)
                    cmd.Parameters.Add("@BARCODE", SqlDbType.NChar, 15).Value = txtBarcode.Text.Trim()
                    cmd.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = lblSKU.Text.Trim()
                    cmd.Parameters.Add("@BRAND", SqlDbType.VarChar, 255).Value = txtBrand.Text.Trim()
                    cmd.Parameters.Add("@DESCRIPTIONS", SqlDbType.VarChar, 255).Value = txtDescription.Text.Trim()
                    cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 255).Value = cboCategory.Text.Trim()
                    cmd.Parameters.Add("@SIZE", SqlDbType.NVarChar, 20).Value = txtSize.Text.Trim()

                    Dim priceParam As New SqlParameter("@PRICE", SqlDbType.Decimal)
                    priceParam.Precision = 18
                    priceParam.Scale = 2
                    priceParam.Value = CDec(txtPrice.Text.Trim())
                    cmd.Parameters.Add(priceParam)

                    cmd.Parameters.Add("@UNIT", SqlDbType.NChar, 10).Value = txtUnit.Text.Trim()
                    cmd.Parameters.Add("@AVAILABLE", SqlDbType.Int).Value = CInt(txtStockAvailable.Text.Trim())
                    cmd.Parameters.Add("@VENDOR_CODE", SqlDbType.NVarChar, 10).Value = cboVendorCode.Text.Trim()
                    cmd.Parameters.Add("@VENDOR", SqlDbType.VarChar, 100).Value = cboVendor.Text.Trim()

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