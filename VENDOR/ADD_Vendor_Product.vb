Imports System.Data
Imports MySqlConnector
Imports System.Drawing
Imports System.IO

Public Class ADD_Vendor_Product

    Private vendorCode As String = Nothing
    Private vendorName As String = Nothing

    Private connStr As String = DBConnection.connStr

    Private Sub ADD_Vendor_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vendorCode = If(DBConnection.CurrentVendorCode IsNot Nothing, DBConnection.CurrentVendorCode.Trim(), "")
        vendorName = If(DBConnection.CurrentVendorName IsNot Nothing, DBConnection.CurrentVendorName.Trim(), "")

        If String.IsNullOrWhiteSpace(vendorCode) Then
            MessageBox.Show("Vendor account not found! Please log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Return
        End If

        LoadCategories()
        SetPlaceholders()
    End Sub

    Private Sub SetPlaceholders()
        txtBarcode.Text = "BARCODE"
        txtBarcode.ForeColor = Color.Gray

        txtBrand.Text = "BRAND"
        txtBrand.ForeColor = Color.Gray

        txtDescription.Text = "DESCRIPTION"
        txtDescription.ForeColor = Color.Gray

        txtUnit.Text = "UNIT"
        txtUnit.ForeColor = Color.Gray

        txtSize.Text = "SIZE / WEIGHT"
        txtSize.ForeColor = Color.Gray

        txtPrice.Text = "PRICE"
        txtPrice.ForeColor = Color.Gray

        txtAvailable.Text = "Available Qty"
        txtAvailable.ForeColor = Color.Gray
    End Sub

    Private Sub txtBarcode_GotFocus(sender As Object, e As EventArgs) Handles txtBarcode.GotFocus
        If txtBarcode.ForeColor = Color.Gray Then txtBarcode.Text = ""
        txtBarcode.ForeColor = Color.Black
    End Sub

    Private Sub txtBrand_GotFocus(sender As Object, e As EventArgs) Handles txtBrand.GotFocus
        If txtBrand.ForeColor = Color.Gray Then txtBrand.Text = ""
        txtBrand.ForeColor = Color.Black
    End Sub

    Private Sub txtDescription_GotFocus(sender As Object, e As EventArgs) Handles txtDescription.GotFocus
        If txtDescription.ForeColor = Color.Gray Then txtDescription.Text = ""
        txtDescription.ForeColor = Color.Black
    End Sub

    Private Sub txtUnit_GotFocus(sender As Object, e As EventArgs) Handles txtUnit.GotFocus
        If txtUnit.ForeColor = Color.Gray Then txtUnit.Text = ""
        txtUnit.ForeColor = Color.Black
    End Sub

    Private Sub txtSize_GotFocus(sender As Object, e As EventArgs) Handles txtSize.GotFocus
        If txtSize.ForeColor = Color.Gray Then txtSize.Text = ""
        txtSize.ForeColor = Color.Black
    End Sub

    Private Sub txtPrice_GotFocus(sender As Object, e As EventArgs) Handles txtPrice.GotFocus
        If txtPrice.ForeColor = Color.Gray Then txtPrice.Text = ""
        txtPrice.ForeColor = Color.Black
    End Sub

    Private Sub txtAvailable_GotFocus(sender As Object, e As EventArgs) Handles txtAvailable.GotFocus
        If txtAvailable.ForeColor = Color.Gray Then txtAvailable.Text = ""
        txtAvailable.ForeColor = Color.Black
    End Sub

    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus
        If txtBarcode.Text = "" Then
            txtBarcode.Text = "BARCODE"
            txtBarcode.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtBrand_LostFocus(sender As Object, e As EventArgs) Handles txtBrand.LostFocus
        If txtBrand.Text = "" Then
            txtBrand.Text = "BRAND"
            txtBrand.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtDescription_LostFocus(sender As Object, e As EventArgs) Handles txtDescription.LostFocus
        If txtDescription.Text = "" Then
            txtDescription.Text = "DESCRIPTION"
            txtDescription.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtUnit_LostFocus(sender As Object, e As EventArgs) Handles txtUnit.LostFocus
        If txtUnit.Text = "" Then
            txtUnit.Text = "UNIT"
            txtUnit.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtSize_LostFocus(sender As Object, e As EventArgs) Handles txtSize.LostFocus
        If txtSize.Text = "" Then
            txtSize.Text = "SIZE / WEIGHT"
            txtSize.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtPrice_LostFocus(sender As Object, e As EventArgs) Handles txtPrice.LostFocus
        If txtPrice.Text = "" Then
            txtPrice.Text = "PRICE"
            txtPrice.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtAvailable_LostFocus(sender As Object, e As EventArgs) Handles txtAvailable.LostFocus
        If txtAvailable.Text = "" Then
            txtAvailable.Text = "Available Qty"
            txtAvailable.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub LoadCategories()
        cboCategory.Items.Clear()
        cboCategory.Items.Add("--- FOOD & GROCERIES ---")
        cboCategory.Items.Add("Rice & Grains")
        cboCategory.Items.Add("Canned Goods & Preserved Food")
        cboCategory.Items.Add("Noodles & Pasta")
        cboCategory.Items.Add("Bread, Biscuits & Crackers")
        cboCategory.Items.Add("Snacks, Chips & Candies")
        cboCategory.Items.Add("Baking Ingredients & Flour")
        cboCategory.Items.Add("Cooking Oil & Vinegar")
        cboCategory.Items.Add("Sauces, Spices & Seasonings")
        cboCategory.Items.Add("Sugar, Salt & Sweeteners")
        cboCategory.Items.Add("Condiments & Dressings")
        cboCategory.Items.Add("Dairy & Eggs")
        cboCategory.Items.Add("Milk, Milk Powder & Creamers")
        cboCategory.Items.Add("Cheese & Butter")
        cboCategory.Items.Add("Frozen Meat, Poultry & Seafood")
        cboCategory.Items.Add("Fresh Meat & Sausages")
        cboCategory.Items.Add("Fresh Fruits & Vegetables")
        cboCategory.Items.Add("Frozen Fruits & Vegetables")
        cboCategory.Items.Add("Ready-to-Eat Meals")
        cboCategory.Items.Add("Cereals & Oatmeal")
        cboCategory.Items.Add("Baby Food & Formula")
        cboCategory.Items.Add("Coffee, Tea & Cocoa")
        cboCategory.Items.Add("Chocolates & Desserts")
        cboCategory.Items.Add("--- BEVERAGES ---")
        cboCategory.Items.Add("Mineral Water & Purified Water")
        cboCategory.Items.Add("Soft Drinks & Sodas")
        cboCategory.Items.Add("Juices & Fruit Drinks")
        cboCategory.Items.Add("Energy Drinks")
        cboCategory.Items.Add("Beer, Wine & Liquor")
        cboCategory.Items.Add("Alcoholic Beverages")
        cboCategory.Items.Add("Powdered Drinks")
        cboCategory.Items.Add("--- HOUSEHOLD CARE ---")
        cboCategory.Items.Add("Dishwashing Liquid & Bar")
        cboCategory.Items.Add("Laundry Detergent & Powder")
        cboCategory.Items.Add("Fabric Softener & Bleach")
        cboCategory.Items.Add("Toilet Cleaners & Disinfectants")
        cboCategory.Items.Add("Floor & Surface Cleaners")
        cboCategory.Items.Add("Bathroom & Kitchen Cleaners")
        cboCategory.Items.Add("Trash Bags & Wipes")
        cboCategory.Items.Add("Air Fresheners & Deodorizers")
        cboCategory.Items.Add("Insect Repellents & Pesticides")
        cboCategory.Items.Add("--- PERSONAL CARE ---")
        cboCategory.Items.Add("Soap & Body Wash")
        cboCategory.Items.Add("Shampoo & Conditioner")
        cboCategory.Items.Add("Toothpaste & Toothbrushes")
        cboCategory.Items.Add("Deodorants & Antiperspirants")
        cboCategory.Items.Add("Skincare & Lotions")
        cboCategory.Items.Add("Feminine Care Products")
        cboCategory.Items.Add("Diapers & Adult Care")
        cboCategory.Items.Add("Hair Care & Styling")
        cboCategory.Items.Add("Oral Care Products")
        cboCategory.Items.Add("Shaving & Grooming Items")
        cboCategory.Items.Add("--- HEALTH & MEDICINE ---")
        cboCategory.Items.Add("Over-the-Counter Medicines")
        cboCategory.Items.Add("Vitamins & Supplements")
        cboCategory.Items.Add("First Aid & Medical Supplies")
        cboCategory.Items.Add("Pain Relievers & Fever Medicine")
        cboCategory.Items.Add("Digestive Health Products")
        cboCategory.Items.Add("Allergy & Cold Remedies")
        cboCategory.Items.Add("--- HOME & KITCHEN ---")
        cboCategory.Items.Add("Kitchenware & Utensils")
        cboCategory.Items.Add("Cookware & Bakeware")
        cboCategory.Items.Add("Plasticware & Containers")
        cboCategory.Items.Add("Cleaning Tools & Supplies")
        cboCategory.Items.Add("Paper Towels & Toilet Paper")
        cboCategory.Items.Add("Tissues & Napkins")
        cboCategory.Items.Add("Lighting & Batteries")
        cboCategory.Items.Add("Small Appliances")
        cboCategory.Items.Add("Storage & Organization")
        cboCategory.Items.Add("--- SCHOOL & OFFICE ---")
        cboCategory.Items.Add("Notebooks & Writing Pads")
        cboCategory.Items.Add("Pens, Pencils & Markers")
        cboCategory.Items.Add("Paper & Envelopes")
        cboCategory.Items.Add("Glue, Tape & Adhesives")
        cboCategory.Items.Add("School & Office Supplies")
        cboCategory.Items.Add("--- PET CARE ---")
        cboCategory.Items.Add("Pet Food & Treats")
        cboCategory.Items.Add("Pet Grooming Supplies")
        cboCategory.Items.Add("Pet Health Products")
        cboCategory.Items.Add("--- OTHERS ---")
        cboCategory.Items.Add("Cigarettes & Tobacco")
        cboCategory.Items.Add("Party & Disposable Items")
        cboCategory.Items.Add("Gift Items & Novelties")
        cboCategory.Items.Add("Miscellaneous Goods")

        cboCategory.Text = "Select Category"
        cboCategory.ForeColor = Color.Gray
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        cboCategory.ForeColor = If(cboCategory.Text.StartsWith("---"), Color.Gray, Color.Black)
    End Sub


    Private Sub picProduct_DoubleClick(sender As Object, e As EventArgs) Handles picProduct.DoubleClick
        Using openFile As New OpenFileDialog()
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            openFile.Title = "Select Product Image"
            If openFile.ShowDialog() = DialogResult.OK Then
                picProduct.Image = Image.FromFile(openFile.FileName)
                picProduct.SizeMode = PictureBoxSizeMode.Zoom
            End If
        End Using
    End Sub

    Private Sub ClearForm()
        SetPlaceholders()
        cboCategory.Text = "Select Category"
        cboCategory.ForeColor = Color.Gray
        picProduct.Image = Nothing
        txtBarcode.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSaveProduct_Click_1(sender As Object, e As EventArgs) Handles btnSaveProduct.Click
        ' ✅ VALIDATION
        If txtBarcode.Text = "" OrElse txtBarcode.Text = "BARCODE" Then
            MessageBox.Show("Please enter the product barcode.")
            txtBarcode.Focus()
            Return
        End If
        If txtDescription.Text = "" OrElse txtDescription.Text = "DESCRIPTION" Then
            MessageBox.Show("Please enter the product description.")
            txtDescription.Focus()
            Return
        End If
        If txtBrand.Text = "" OrElse txtBrand.Text = "BRAND" Then
            MessageBox.Show("Please enter the product brand.")
            txtBrand.Focus()
            Return
        End If
        If txtUnit.Text = "" OrElse txtUnit.Text = "UNIT" Then
            MessageBox.Show("Please enter the unit (e.g., pc, kg, pack).")
            txtUnit.Focus()
            Return
        End If
        If cboCategory.Text = "" OrElse cboCategory.Text = "Select Category" OrElse cboCategory.Text.StartsWith("---") Then
            MessageBox.Show("Please select a valid category.")
            cboCategory.DroppedDown = True
            Return
        End If
        If txtPrice.Text = "" OrElse txtPrice.Text = "PRICE" OrElse Not IsNumeric(txtPrice.Text) Then
            MessageBox.Show("Please enter a valid price.")
            txtPrice.SelectAll()
            txtPrice.Focus()
            Return
        End If
        If txtAvailable.Text = "" OrElse txtAvailable.Text = "Available Qty" OrElse Not IsNumeric(txtAvailable.Text) Then
            MessageBox.Show("Please enter available quantity.")
            txtAvailable.SelectAll()
            txtAvailable.Focus()
            Return
        End If

        Dim availableQty As Integer = CInt(txtAvailable.Text.Trim())
        Dim availabilityStatus As String

        If availableQty <= 0 Then
            availabilityStatus = "Out of Stock"
        ElseIf availableQty >= 10 Then
            availabilityStatus = "Available"
        Else
            availabilityStatus = "Critical"
        End If

        Dim imageBytes() As Byte = Nothing
        If picProduct.Image IsNot Nothing Then
            Using ms As New MemoryStream()
                picProduct.Image.Save(ms, picProduct.Image.RawFormat)
                imageBytes = ms.ToArray()
            End Using
        End If

        Try
            Dim sql As String = "
                INSERT INTO `Vendor_Products` (
                    `BARCODE`, `DESCRIPTIONS`, `BRAND`, `CATEGORY`, `VENDOR_CODE`, `VENDOR`, 
                    `UNIT`, `SIZE`, `PRICE`, `AVAILABLE`, `AVAILABILITY`, `PRODUCT_IMAGE`, `DATE_ADDED`
                ) VALUES (
                    @BARCODE, @DESCRIPTIONS, @BRAND, @CATEGORY, @VENDOR_CODE, @VENDOR, 
                    @UNIT, @SIZE, @PRICE, @AVAILABLE, @AVAILABILITY, @PRODUCT_IMAGE, NOW()
                )"

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BARCODE", txtBarcode.Text.Trim())
                    cmd.Parameters.AddWithValue("@DESCRIPTIONS", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@BRAND", txtBrand.Text.Trim())
                    cmd.Parameters.AddWithValue("@CATEGORY", cboCategory.Text.Trim())

                    cmd.Parameters.AddWithValue("@VENDOR_CODE", vendorCode)
                    cmd.Parameters.AddWithValue("@VENDOR", vendorName)

                    cmd.Parameters.AddWithValue("@UNIT", txtUnit.Text.Trim())
                    cmd.Parameters.AddWithValue("@SIZE", If(txtSize.Text = "SIZE / WEIGHT", DBNull.Value, txtSize.Text.Trim()))
                    cmd.Parameters.AddWithValue("@PRICE", CDec(txtPrice.Text.Trim()))
                    cmd.Parameters.AddWithValue("@AVAILABLE", availableQty)
                    cmd.Parameters.AddWithValue("@AVAILABILITY", availabilityStatus)
                    cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", If(imageBytes IsNot Nothing, imageBytes, DBNull.Value))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"✅ Product saved successfully!{vbCrLf}Status: {availabilityStatus}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            ClearForm()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class