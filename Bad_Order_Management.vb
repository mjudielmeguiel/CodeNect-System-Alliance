Public Class Bad_Order_Management
    Private Sub Bad_Order_ReportsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Bad_Order_ReportsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)

    End Sub

    Private Sub Bad_Order_ReportsBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Bad_Order_ReportsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)

    End Sub

    Private Sub Bad_Order_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CODENECTDataSet.Vendor' table. You can move, or remove it, as needed.
        Me.VendorTableAdapter.Fill(Me.CODENECTDataSet.Vendor)

    End Sub

    Public Sub FillFromDescription(
    barcode As String,
    sku As String,
    description As String,
    brand As String,
    category As String,
    size As String,
    price As Decimal,
    unit As String,
    stock As Integer,
    availability As String,
    vendorCode As String,
    vendor As String)

        BARCODE_EAN_UPC_TextBox.Text = barcode
        SKUTextBox.Text = sku
        DESCRIPTIONSTextBox.Text = description
        BRANDTextBox.Text = brand
        CATEGORYTextBox.Text = category
        SIZETextBox.Text = size
        PRICETextBox.Text = price.ToString("F2")
        STOCK_AVAILABLETextBox.Text = stock.ToString()
        VENDOR_CODETextBox.Text = vendorCode
        VENDORTextBox.Text = vendor
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Bad_Order_Masterfile.Show()
    End Sub
End Class