Imports System.Data
Imports System.Data.SqlClient

Public Class frmADDStock_QTY

    ' Properties to receive data from main form
    Public Property Barcode As String = ""
    Public Property SKU As String = ""
    Public Property Brand As String = ""
    Public Property Description As String = ""
    Public Property ProductSize As String = ""
    Public Property UnitPrice As Decimal = 0D
    Public Property VendorName As String = ""
    Public Property OrderQty As Integer = 0
    ' ↓ NEW: Add this to pass the PO number so we can update its status
    Public Property PONumber As String = ""

    Private connStr As String = DBConnection.connStr

    Private Sub frmADDStock_QTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill display labels
        lblBarcode.Text = Barcode
        lblSKU.Text = SKU
        lblBrand.Text = Brand
        lblDescription.Text = Description
        lblSize.Text = ProductSize
        lblPrice.Text = UnitPrice.ToString("N2")
        lblVendor.Text = VendorName
        lblMaxOrderQty.Text = OrderQty.ToString()

        ' Default values
        txtReceivedQty.Text = "0"
        txtReturnQty.Text = "0"

        ' Make sure button is enabled when form opens
        btnSubmit.Enabled = True
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' Immediately disable button to prevent double-click
            btnSubmit.Enabled = False

            Dim receivedQty As Integer = 0
            Dim returnQty As Integer = 0

            ' Validate inputs
            If Not Integer.TryParse(txtReceivedQty.Text.Trim(), receivedQty) OrElse receivedQty < 0 Then
                MessageBox.Show("Enter valid Received Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReceivedQty.Focus()
                btnSubmit.Enabled = True ' Re-enable if error
                Return
            End If

            If Not Integer.TryParse(txtReturnQty.Text.Trim(), returnQty) OrElse returnQty < 0 Then
                MessageBox.Show("Enter valid Return Quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Focus()
                btnSubmit.Enabled = True ' Re-enable if error
                Return
            End If

            If receivedQty > OrderQty Then
                MessageBox.Show($"Cannot receive more than ordered ({OrderQty}).", "Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReceivedQty.Focus()
                btnSubmit.Enabled = True ' Re-enable if error
                Return
            End If

            If returnQty > receivedQty Then
                MessageBox.Show("Return quantity cannot be more than received.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Focus()
                btnSubmit.Enabled = True ' Re-enable if error
                Return
            End If

            Dim addQty As Integer = receivedQty - returnQty
            If addQty <= 0 Then
                MessageBox.Show("No stock to add.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSubmit.Enabled = True ' Re-enable if error
                Return
            End If

            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' --- 1. Update Inventory ---
                Dim sqlInventory As String = "
                UPDATE inv.Inventory_Master_file
                SET 
                    AVAILABLE = ISNULL(AVAILABLE, 0) + @AddQty,
                    PRICE = @Price,
                    DATE_ADDED = GETDATE()
                WHERE BARCODE = @Barcode OR SKU = @SKU;

                IF @@ROWCOUNT = 0
                INSERT INTO inv.Inventory_Master_file 
                    (BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, PRICE, AVAILABLE, VENDOR, DATE_ADDED)
                VALUES 
                    (@Barcode, @SKU, @Brand, @Desc, '', @Size, @Price, @AddQty, @Vendor, GETDATE());
                "

                Using cmdInv As New SqlCommand(sqlInventory, conn)
                    cmdInv.Parameters.Add("@AddQty", SqlDbType.Int).Value = addQty
                    cmdInv.Parameters.Add("@Price", SqlDbType.Decimal, 10, 2).Value = UnitPrice
                    cmdInv.Parameters.Add("@Barcode", SqlDbType.NChar, 15).Value = Barcode
                    cmdInv.Parameters.Add("@SKU", SqlDbType.NChar, 15).Value = SKU
                    cmdInv.Parameters.Add("@Brand", SqlDbType.VarChar, 255).Value = Brand
                    cmdInv.Parameters.Add("@Desc", SqlDbType.VarChar, 255).Value = Description
                    cmdInv.Parameters.Add("@Size", SqlDbType.VarChar, 20).Value = ProductSize
                    cmdInv.Parameters.Add("@Vendor", SqlDbType.VarChar, 100).Value = VendorName

                    cmdInv.ExecuteNonQuery()
                End Using

                ' --- 2. Update STO Status to DELIVERED ---
                Dim sqlUpdateStatus As String = "
                    UPDATE dbo.STO_DATA
                    SET 
                        STATUS = 'PENDING',
                        RECEIVE_DATE = GETDATE()
                    WHERE PO_NUMBER = @PONumber;
                "

                Using cmdStatus As New SqlCommand(sqlUpdateStatus, conn)
                    cmdStatus.Parameters.Add("@PONumber", SqlDbType.VarChar, 15).Value = PONumber
                    cmdStatus.ExecuteNonQuery()
                End Using

                MessageBox.Show($"✅ Transaction completed!
Received: {receivedQty}
Returned: {returnQty}
Added to Inventory: {addQty}
Order Status: PENDING", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Close form automatically after success
                Me.Close()

            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Re-enable button if there is an error
            btnSubmit.Enabled = True
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class