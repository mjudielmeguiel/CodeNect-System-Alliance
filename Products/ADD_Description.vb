Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class ADD_Description

    Private Current_AccountID As String = ""
    Private Current_BranchID As String = ""

    Private Sub ADD_Description_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetIDsUsingBranchName()
        txtBarcode.Focus()
        GenerateRandom6DigitSKU()
        SetFieldsSettings()

        picProduct.SizeMode = PictureBoxSizeMode.Zoom
        picProduct.BackColor = Color.White
        picProduct.Image = Nothing
        picProduct.Cursor = Cursors.Hand

        txtTotal.ReadOnly = True
        txtAvailability.ReadOnly = True

        Me.Text = $"ADD NEW PRODUCT | Account ID: {Current_AccountID} | Branch ID: {Current_BranchID}"
    End Sub

    Private Sub GetIDsUsingBranchName()
        Try
            Dim BranchNameFromDashboard As String = DashBoard.ToolStripStatusLabel4.Text.Trim()

            If String.IsNullOrEmpty(BranchNameFromDashboard) Then
                MessageBox.Show("❌ Walang nakuhang pangalan ng Branch mula sa Dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using conn As New SqlConnection(connStr)
                Dim query As String = "
                    SELECT TOP 1 
                        ACCOUNT_ID, 
                        BRANCH_ID
                    FROM dbo.User_Accounts
                    WHERE 
                        RTRIM(LTRIM(BRANCH)) = RTRIM(LTRIM(@BranchName))
                        AND STATUS = 'Active'
                    ORDER BY ID DESC
                "

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@BranchName", SqlDbType.NVarChar, 100).Value = BranchNameFromDashboard
                    conn.Open()
                    Dim dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        Current_AccountID = dr("ACCOUNT_ID").ToString().Trim()
                        Current_BranchID = dr("BRANCH_ID").ToString().Trim()

                        MessageBox.Show($"✅ Matagumpay na nakuha ang mga ID!{Environment.NewLine}" &
                                        $"Pangalan ng Branch: {BranchNameFromDashboard}{Environment.NewLine}" &
                                        $"Account ID: {Current_AccountID}{Environment.NewLine}" &
                                        $"Branch ID: {Current_BranchID}", "Tagumpay", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show($"⚠️ Hindi makita ang impormasyon para sa Branch: [{BranchNameFromDashboard}]{Environment.NewLine}" &
                                        "Tingnan kung pareho ang baybay nito sa table na User_Accounts.",
                                        "Walang Natagpuan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    dr.Close()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error habang kinukuha ang ID:" & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picProduct_DoubleClick(sender As Object, e As EventArgs) Handles picProduct.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Pumili ng Litrato ng Produkto"
            ofd.Filter = "Mga Larawan|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.RestoreDirectory = True
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    picProduct.Image = Image.FromFile(ofd.FileName)
                Catch ex As Exception
                    MessageBox.Show("Hindi mabuksan ang litrato: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            txtSKU.Text = newSKU
            txtSKU.ReadOnly = True
        Catch
            Dim rndBackup As New Random(DateTime.Now.Millisecond)
            txtSKU.Text = rndBackup.Next(100000, 999999).ToString("D6")
        End Try
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        If txtBarcode.Text.Trim.Length >= 5 Then
            LoadVendorDetails()
        Else
            ClearAll()
            GenerateRandom6DigitSKU()
        End If
    End Sub

    Private Sub LoadVendorDetails()
        Try
            Using conn As New SqlConnection(connStr)
                Dim query As String = "SELECT DESCRIPTIONS, BRAND, CATEGORY, VENDOR_CODE, VENDOR, UNIT, SIZE, PRICE, PRODUCT_IMAGE FROM dbo.Vendor_Products WHERE RTRIM(LTRIM(BARCODE)) = @Barcode"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = txtBarcode.Text.Trim()
                    conn.Open()
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        txtDescription.Text = dr("DESCRIPTIONS").ToString().Trim()
                        txtBrand.Text = dr("BRAND").ToString().Trim()
                        txtCategory.Text = dr("CATEGORY").ToString().Trim()
                        txtVendorCode.Text = dr("VENDOR_CODE").ToString().Trim()
                        txtVendor.Text = dr("VENDOR").ToString().Trim()
                        txtUnit.Text = dr("UNIT").ToString().Trim()
                        txtSize.Text = dr("SIZE").ToString().Trim()
                        txtPrice.Text = CDec(dr("PRICE")).ToString("0.00")
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
                        txtAvailability.Clear()
                        txtTotal.Text = "0.00"
                    Else
                        ClearAll()
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Info mula sa vendor: " & ex.Message, "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtStockAvailable_TextChanged(sender As Object, e As EventArgs) Handles txtStockAvailable.TextChanged
        ComputeTotal()
        SetAvailabilityStatus()
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        ComputeTotal()
    End Sub

    Private Sub ComputeTotal()
        Try
            Dim price As Decimal = 0
            Dim qty As Integer = 0
            If Decimal.TryParse(txtPrice.Text.Trim(), price) AndAlso Integer.TryParse(txtStockAvailable.Text.Trim(), qty) Then
                txtTotal.Text = (price * qty).ToString("0.00")
            Else
                txtTotal.Text = "0.00"
            End If
        Catch
            txtTotal.Text = "0.00"
        End Try
    End Sub

    Private Sub SetAvailabilityStatus()
        Try
            Dim stock As Integer = 0
            If Integer.TryParse(txtStockAvailable.Text.Trim(), stock) Then
                Select Case stock
                    Case 0 : txtAvailability.Text = "OUT OF STOCK"
                    Case 1 To 10 : txtAvailability.Text = "CRITICAL"
                    Case Is > 10 : txtAvailability.Text = "AVAILABLE"
                End Select
            Else
                txtAvailability.Clear()
            End If
        Catch
            txtAvailability.Clear()
        End Try
    End Sub

    Private Sub SetFieldsSettings()
        txtSKU.ReadOnly = True
        txtDescription.ReadOnly = True
        txtBrand.ReadOnly = True
        txtCategory.ReadOnly = True
        txtVendorCode.ReadOnly = True
        txtVendor.ReadOnly = True
        txtUnit.ReadOnly = True
        txtSize.ReadOnly = True
        txtPrice.ReadOnly = False
        txtAvailability.ReadOnly = True
        txtStockAvailable.ReadOnly = False
        txtTotal.ReadOnly = True
    End Sub

    Private Sub ClearAll()
        txtDescription.Clear()
        txtBrand.Clear()
        txtCategory.Clear()
        txtVendorCode.Clear()
        txtVendor.Clear()
        txtUnit.Clear()
        txtSize.Clear()
        txtPrice.Clear()
        txtAvailability.Clear()
        txtStockAvailable.Clear()
        txtTotal.Clear()
        picProduct.Image = Nothing
        GenerateRandom6DigitSKU()
    End Sub

    Private Sub btnSaveProduct_Click(sender As Object, e As EventArgs) Handles btnSaveProduct.Click
        If String.IsNullOrEmpty(Current_AccountID) Or String.IsNullOrEmpty(Current_BranchID) Then
            MessageBox.Show("❌ Walang nakuhang Account o Branch ID. Hindi makakapag-save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then MessageBox.Show("Ilagay ang Barcode.", "Kailangan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtBarcode.Focus() : Return
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then MessageBox.Show("Ilagay ang Deskripsyon.", "Kailangan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        If String.IsNullOrWhiteSpace(txtStockAvailable.Text) OrElse Not Integer.TryParse(txtStockAvailable.Text.Trim(), Nothing) Then MessageBox.Show("Ilagay ang dami ng Stock.", "Kailangan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtStockAvailable.Focus() : Return

        Try
            Using conn As New SqlConnection(connStr)
                Dim checkQuery As String = "
            SELECT COUNT(*) 
            FROM inv.Inventory_Master_file 
            WHERE 
                ACCOUNT_ID = @AccID 
                AND BRANCH_ID = @BrID 
                AND (BARCODE = @Barcode OR SKU = @SKU)
        "
                Using cmdCheck As New SqlCommand(checkQuery, conn)
                    cmdCheck.Parameters.Add("@AccID", SqlDbType.NVarChar, 50).Value = Current_AccountID
                    cmdCheck.Parameters.Add("@BrID", SqlDbType.NVarChar, 50).Value = Current_BranchID
                    cmdCheck.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = txtBarcode.Text.Trim()
                    cmdCheck.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = txtSKU.Text.Trim()

                    conn.Open()
                    Dim existingCount As Integer = CInt(cmdCheck.ExecuteScalar())

                    If existingCount > 0 Then
                        MessageBox.Show("⚠️ MAYROON NANG KAPAREHONG PRODUKTO SA DATABASE!" & Environment.NewLine &
                                        "Ang Barcode o SKU na iyong inilagay ay nakarehistro na para sa Branch at Account na ito." & Environment.NewLine &
                                        "Hindi maaaring magkaroon ng dalawang magkatulad na talaan.",
                                        "Paalala: Mayroon na", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Error habang tinitingnan kung may kapareho: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim confirm = MessageBox.Show($"I-save ang produkto?{Environment.NewLine}Account ID: {Current_AccountID}{Environment.NewLine}Branch ID: {Current_BranchID}{Environment.NewLine}SKU: {txtSKU.Text}", "Kumpirmahin", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                    cmd.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = txtSKU.Text.Trim()
                    cmd.Parameters.Add("@BRAND", SqlDbType.VarChar, 255).Value = txtBrand.Text.Trim()
                    cmd.Parameters.Add("@DESCRIPTIONS", SqlDbType.VarChar, 255).Value = txtDescription.Text.Trim()
                    cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 255).Value = txtCategory.Text.Trim()
                    cmd.Parameters.Add("@SIZE", SqlDbType.NVarChar, 20).Value = txtSize.Text.Trim()

                    Dim priceParam As New SqlParameter("@PRICE", SqlDbType.Decimal)
                    priceParam.Precision = 18
                    priceParam.Scale = 2
                    priceParam.Value = CDec(txtPrice.Text.Trim())
                    cmd.Parameters.Add(priceParam)

                    cmd.Parameters.Add("@UNIT", SqlDbType.NChar, 10).Value = txtUnit.Text.Trim()
                    cmd.Parameters.Add("@AVAILABLE", SqlDbType.Int).Value = CInt(txtStockAvailable.Text.Trim())
                    cmd.Parameters.Add("@VENDOR_CODE", SqlDbType.NVarChar, 10).Value = txtVendorCode.Text.Trim()
                    cmd.Parameters.Add("@VENDOR", SqlDbType.VarChar, 100).Value = txtVendor.Text.Trim()

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show($"✅ Na-save nang matagumpay!{Environment.NewLine}Account ID: {Current_AccountID}{Environment.NewLine}Branch ID: {Current_BranchID}", "Tagumpay", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAll()
            txtBarcode.Clear()
            txtBarcode.Focus()
        Catch ex As Exception
            MessageBox.Show("❌ Hindi na-save: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class