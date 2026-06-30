Imports System.Data.SqlClient
Imports System.IO

Public Class ADD_Vendor_Product

    ' ✅ Tamang koneksyon para sa database mo
    Private strKoneksyon As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    '=============================
    ' Pagbukas ng Form
    '=============================
    Private Sub ADD_Vendor_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IpakitaMgaVendor()
        IlagayMgaKategorya()
        IlagayMgaPlaceholder()
    End Sub

    '=============================
    ' ✅ Maglagay ng pangalan sa loob ng bawat kahon - Mas malinaw ang kulay
    '=============================
    Private Sub IlagayMgaPlaceholder()
        txtBarcode.Text = "BARCODE"
        txtBarcode.ForeColor = Color.Gray ' Kulay abo lang kapag walang laman

        txtBrand.Text = "BRAND"
        txtBrand.ForeColor = Color.Gray

        txtDescription.Text = "DESCRIPTIONS"
        txtDescription.ForeColor = Color.Gray

        txtUnit.Text = "UNIT"
        txtUnit.ForeColor = Color.Gray

        txtSize.Text = "SIZE / WEIGHT"
        txtSize.ForeColor = Color.Gray

        txtPrice.Text = "PRICE"
        txtPrice.ForeColor = Color.Gray
    End Sub

    '=============================
    ' ✅ Kapag pinindot ang kahon, mawawala ang nakasulat at magiging itim ang sulat
    '=============================
    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        If txtBarcode.ForeColor = Color.Gray Then
            txtBarcode.Text = ""
        End If
        txtBarcode.ForeColor = Color.Black ' Agad itim kapag napili
    End Sub

    Private Sub txtBrand_GotFocus(sender As Object, e As EventArgs) Handles txtBrand.GotFocus
        If txtBrand.ForeColor = Color.Gray Then
            txtBrand.Text = ""
        End If
        txtBrand.ForeColor = Color.Black
    End Sub

    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        If txtDescription.ForeColor = Color.Gray Then
            txtDescription.Text = ""
        End If
        txtDescription.ForeColor = Color.Black
    End Sub

    Private Sub txtUnit_GotFocus(sender As Object, e As EventArgs) Handles txtUnit.GotFocus
        If txtUnit.ForeColor = Color.Gray Then
            txtUnit.Text = ""
        End If
        txtUnit.ForeColor = Color.Black
    End Sub

    Private Sub txtSize_GotFocus(sender As Object, e As EventArgs) Handles txtSize.GotFocus
        If txtSize.ForeColor = Color.Gray Then
            txtSize.Text = ""
        End If
        txtSize.ForeColor = Color.Black
    End Sub

    Private Sub txtPrice_GotFocus(sender As Object, e As EventArgs) Handles txtPrice.GotFocus
        If txtPrice.ForeColor = Color.Gray Then
            txtPrice.Text = ""
        End If
        txtPrice.ForeColor = Color.Black
    End Sub

    '=============================
    ' ✅ Kapag umalis ang kursor at walang laman, babalik ang kulay abo
    '=============================
    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        If String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            txtBarcode.Text = "BARCODE"
            txtBarcode.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtBrand_LostFocus(sender As Object, e As EventArgs) Handles txtBrand.LostFocus
        If String.IsNullOrWhiteSpace(txtBrand.Text) Then
            txtBrand.Text = "BRAND"
            txtBrand.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtDescription_LostFocus(sender As Object, e As EventArgs) Handles txtDescription.LostFocus
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            txtDescription.Text = "DESCRIPTIONS"
            txtDescription.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtUnit_LostFocus(sender As Object, e As EventArgs) Handles txtUnit.LostFocus
        If String.IsNullOrWhiteSpace(txtUnit.Text) Then
            txtUnit.Text = "UNIT"
            txtUnit.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtSize_LostFocus(sender As Object, e As EventArgs) Handles txtSize.LostFocus
        If String.IsNullOrWhiteSpace(txtSize.Text) Then
            txtSize.Text = "SIZE / WEIGHT"
            txtSize.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPrice_LostFocus(sender As Object, e As EventArgs) Handles txtPrice.LostFocus
        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            txtPrice.Text = "PRICE"
            txtPrice.ForeColor = Color.Gray
        End If
    End Sub

    '=============================
    ' ✅ Kategorya - Mas matingkad at itim agad kapag napili
    '=============================
    Private Sub IpakitaMgaVendor()
        Try
            Using kon As New SqlConnection(strKoneksyon)
                Dim sql As String = "SELECT VENDOR_CODE, VENDOR FROM dbo.vendor ORDER BY VENDOR ASC"
                Dim cmd As New SqlCommand(sql, kon)
                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(cmd)

                kon.Open()
                da.Fill(dt)

                cboVendorCode.DataSource = dt
                cboVendorCode.DisplayMember = "VENDOR_CODE"
                cboVendorCode.ValueMember = "VENDOR_CODE"
                cboVendorCode.Text = "Select Vendor Code"
                cboVendorCode.ForeColor = Color.Gray

                cboVendorName.DataSource = dt.Copy()
                cboVendorName.DisplayMember = "VENDOR"
                cboVendorName.ValueMember = "VENDOR_CODE"
                cboVendorName.Text = "Select Vendor Name"
                cboVendorName.ForeColor = Color.Gray
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading vendors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=============================
    ' ✅ KUMPLETONG KATEGORYA - ENGLISH, MATAAS ANG KALIDAD
    '=============================
    Private Sub IlagayMgaKategorya()
        cboCategory.Items.Clear()
        cboCategory.Items.AddRange(New String() {
            "--- FOOD & GROCERIES ---",
            "Rice & Grains",
            "Canned Goods & Preserved Food",
            "Noodles & Pasta",
            "Bread, Biscuits & Crackers",
            "Snacks, Chips & Candies",
            "Baking Ingredients & Flour",
            "Cooking Oil & Vinegar",
            "Sauces, Spices & Seasonings",
            "Sugar, Salt & Sweeteners",
            "Condiments & Dressings",
            "Dairy & Eggs",
            "Milk, Milk Powder & Creamers",
            "Cheese & Butter",
            "Frozen Meat, Poultry & Seafood",
            "Fresh Meat & Sausages",
            "Fresh Fruits & Vegetables",
            "Frozen Fruits & Vegetables",
            "Ready-to-Eat Meals",
            "Cereals & Oatmeal",
            "Baby Food & Formula",
            "Coffee, Tea & Cocoa",
            "Chocolates & Desserts",
            "--- BEVERAGES ---",
            "Mineral Water & Purified Water",
            "Soft Drinks & Sodas",
            "Juices & Fruit Drinks",
            "Energy Drinks",
            "Beer, Wine & Liquor",
            "Alcoholic Beverages",
            "Powdered Drinks",
            "--- HOUSEHOLD CARE ---",
            "Dishwashing Liquid & Bar",
            "Laundry Detergent & Powder",
            "Fabric Softener & Bleach",
            "Toilet Cleaners & Disinfectants",
            "Floor & Surface Cleaners",
            "Bathroom & Kitchen Cleaners",
            "Trash Bags & Wipes",
            "Air Fresheners & Deodorizers",
            "Insect Repellents & Pesticides",
            "--- PERSONAL CARE ---",
            "Soap & Body Wash",
            "Shampoo & Conditioner",
            "Toothpaste & Toothbrushes",
            "Deodorants & Antiperspirants",
            "Skincare & Lotions",
            "Feminine Care Products",
            "Diapers & Adult Care",
            "Hair Care & Styling",
            "Oral Care Products",
            "Shaving & Grooming Items",
            "--- HEALTH & MEDICINE ---",
            "Over-the-Counter Medicines",
            "Vitamins & Supplements",
            "First Aid & Medical Supplies",
            "Pain Relievers & Fever Medicine",
            "Digestive Health Products",
            "Allergy & Cold Remedies",
            "--- HOME & KITCHEN ---",
            "Kitchenware & Utensils",
            "Cookware & Bakeware",
            "Plasticware & Containers",
            "Cleaning Tools & Supplies",
            "Paper Towels & Toilet Paper",
            "Tissues & Napkins",
            "Lighting & Batteries",
            "Small Appliances",
            "Storage & Organization",
            "--- SCHOOL & OFFICE ---",
            "Notebooks & Writing Pads",
            "Pens, Pencils & Markers",
            "Paper & Envelopes",
            "Glue, Tape & Adhesives",
            "School & Office Supplies",
            "--- PET CARE ---",
            "Pet Food & Treats",
            "Pet Grooming Supplies",
            "Pet Health Products",
            "--- OTHERS ---",
            "Cigarettes & Tobacco",
            "Party & Disposable Items",
            "Gift Items & Novelties",
            "Miscellaneous Goods"
        })
        cboCategory.Text = "Select Category"
        cboCategory.ForeColor = Color.Gray
    End Sub

    '=============================
    ' ✅ Kulay ng Category - Itim agad kapag napili
    '=============================
    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If Not cboCategory.Text.StartsWith("---") Then
            cboCategory.ForeColor = Color.Black ' Matingkad na itim kapag may napili
        Else
            cboCategory.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub cboVendorCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendorCode.SelectedIndexChanged
        If cboVendorCode.SelectedValue IsNot Nothing Then
            cboVendorName.SelectedValue = cboVendorCode.SelectedValue
            cboVendorCode.ForeColor = Color.Black ' Itim agad
        End If
    End Sub

    Private Sub cboVendorName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVendorName.SelectedIndexChanged
        If cboVendorName.SelectedValue IsNot Nothing Then
            cboVendorCode.SelectedValue = cboVendorName.SelectedValue
            cboVendorName.ForeColor = Color.Black ' Itim agad
        End If
    End Sub

    '=============================
    ' Dobleng pindutin ang litrato para pumili
    '=============================
    Private Sub picProduct_DoubleClick(sender As Object, e As EventArgs) Handles picProduct.DoubleClick
        Dim bukasFile As New OpenFileDialog()
        bukasFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        bukasFile.Title = "Select Product Image"

        If bukasFile.ShowDialog() = DialogResult.OK Then
            picProduct.Image = Image.FromFile(bukasFile.FileName)
            picProduct.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    '=============================
    ' ✅ PAG-SAVE NG PRODUKTO
    '=============================
    Private Sub btnSaveProduct_Click(sender As Object, e As EventArgs) Handles btnSaveProduct.Click
        ' --- Pagsuri ng mga kinakailangang impormasyon ---
        If String.IsNullOrWhiteSpace(txtBarcode.Text) OrElse txtBarcode.Text = "BARCODE" Then
            MessageBox.Show("Please enter the product barcode.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtDescription.Text) OrElse txtDescription.Text = "DESCRIPTIONS" Then
            MessageBox.Show("Please enter the product description.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtBrand.Text) OrElse txtBrand.Text = "BRAND" Then
            MessageBox.Show("Please enter the product brand.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBrand.Focus()
            Return
        End If
        If cboCategory.Text = "" OrElse cboCategory.Text = "Select Category" OrElse cboCategory.Text.StartsWith("---") Then
            MessageBox.Show("Please select a valid product category.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.DroppedDown = True
            Return
        End If
        If cboVendorCode.Text = "" OrElse cboVendorCode.Text = "Select Vendor Code" Then
            MessageBox.Show("Please select a vendor/supplier.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.DroppedDown = True
            Return
        End If
        If String.IsNullOrWhiteSpace(txtPrice.Text) OrElse txtPrice.Text = "PRICE" OrElse Not Decimal.TryParse(txtPrice.Text, Nothing) Then
            MessageBox.Show("Please enter a valid price (numbers only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.SelectAll()
            txtPrice.Focus()
            Return
        End If

        ' --- Ihanda ang litrato para maipasok ---
        Dim litratoBytes() As Byte = Nothing
        If picProduct.Image IsNot Nothing Then
            Using daluyan As New MemoryStream()
                picProduct.Image.Save(daluyan, picProduct.Image.RawFormat)
                litratoBytes = daluyan.ToArray()
            End Using
        End If

        ' --- Ipasok sa Database ---
        Try
            Using kon As New SqlConnection(strKoneksyon)
                Dim sql As String = "INSERT INTO dbo.Vendor_Products " &
                                    "(BARCODE, DESCRIPTIONS, BRAND, CATEGORY, VENDOR_CODE, VENDOR, UNIT, SIZE, PRICE, PRODUCT_IMAGE, DATE_ADDED) " &
                                    "VALUES (@BARCODE, @DESCRIPTIONS, @BRAND, @CATEGORY, @VENDOR_CODE, @VENDOR, @UNIT, @SIZE, @PRICE, @PRODUCT_IMAGE, GETDATE())"

                Using cmd As New SqlCommand(sql, kon)
                    cmd.Parameters.AddWithValue("@BARCODE", txtBarcode.Text.Trim())
                    cmd.Parameters.AddWithValue("@DESCRIPTIONS", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@BRAND", txtBrand.Text.Trim())
                    cmd.Parameters.AddWithValue("@CATEGORY", cboCategory.Text.Trim())
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", cboVendorCode.SelectedValue.ToString())
                    cmd.Parameters.AddWithValue("@VENDOR", cboVendorName.Text.Trim())
                    cmd.Parameters.AddWithValue("@UNIT", If(txtUnit.Text = "UNIT", "", txtUnit.Text.Trim()))
                    cmd.Parameters.AddWithValue("@SIZE", If(txtSize.Text = "SIZE / WEIGHT", "", txtSize.Text.Trim()))
                    cmd.Parameters.AddWithValue("@PRICE", Decimal.Parse(txtPrice.Text.Trim()))
                    cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", If(litratoBytes, DBNull.Value))

                    kon.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product saved successfully! ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Linisin ang form para sa susunod
            LinisinForm()

        Catch ex As SqlException
            MessageBox.Show("Database error: " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=============================
    ' Linisin ang form para sa susunod na gagawin
    '=============================
    Private Sub LinisinForm()
        IlagayMgaPlaceholder()
        cboCategory.Text = "Select Category"
        cboCategory.ForeColor = Color.Gray
        cboVendorCode.Text = "Select Vendor Code"
        cboVendorCode.ForeColor = Color.Gray
        cboVendorName.Text = "Select Vendor Name"
        cboVendorName.ForeColor = Color.Gray
        picProduct.Image = Nothing
        txtBarcode.Focus()
    End Sub

    '=============================
    ' Isara ang form
    '=============================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class