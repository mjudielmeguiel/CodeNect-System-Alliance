Public Class ADD_Vendor
    Private Sub VendorBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.VendorBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)

    End Sub

    Private Sub ADD_Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CODENECTDataSet.Vendor' table. You can move, or remove it, as needed.
        Me.VendorTableAdapter.Fill(Me.CODENECTDataSet.Vendor)
        'TODO: This line of code loads data into the 'CODENECTDataSet.Vendor' table. You can move, or remove it, as needed.
        Me.VendorTableAdapter.Fill(Me.CODENECTDataSet.Vendor)

    End Sub
    Private Function GenerateVendorcode() As String
        Dim random As New Random()
        Dim Vendor As String = ""
        For i As Integer = 1 To 6
            Vendor &= random.Next(0, 6).ToString()
        Next
        Return Vendor
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        VendorBindingSource.AddNew()
        Panel1.Enabled = True
        Button3.Show()
        Button1.Hide()
        STATUSTextBox.Text = "ACTIVE"
        PASSWORDTextBox.Text = "Password1*"
        TextBox1.Text = "Password1*"

        Dim Vendor As String = GenerateVendorcode()
        VENDOR_IDTextBox.Text = Vendor  ' Assuming you have a TextBox named SKUTextBox to display the SKU

        MessageBox.Show("You can now add a New account. Please fill In the required fields And click 'Save' to create the account.", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If MessageBox.Show("Are you sure you want to save this account?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Me.Validate()
                Me.VendorBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)
                MessageBox.Show("Account has been successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Panel1.Enabled = False
                Button1.Show()
                Button3.Hide()
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show("An error occurred while saving the account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub VendorBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.VendorBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)

    End Sub

    Private Sub VendorBindingNavigatorSaveItem_Click_2(sender As Object, e As EventArgs)
        Me.Validate()
        Me.VendorBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CODENECTDataSet)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If MessageBox.Show("Are you sure you want to cancel adding this account?", "Cancel Account Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            VendorBindingSource.CancelEdit()
            Panel1.Enabled = False
            Button1.Show()
            Button3.Hide()
            Me.Hide()
            MessageBox.Show("Account creation has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            PASSWORDTextBox.UseSystemPasswordChar = False
            TextBox1.UseSystemPasswordChar = False
        Else
            PASSWORDTextBox.UseSystemPasswordChar = True
            TextBox1.UseSystemPasswordChar = True
        End If
    End Sub
End Class