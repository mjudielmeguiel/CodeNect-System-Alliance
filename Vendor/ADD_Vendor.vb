Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class ADD_Vendor

    Private Sub ADD_Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GenerateVendorCode()

            ' Mode of Payment options
            cboModeOfPayment.Items.Clear()
            cboModeOfPayment.Items.AddRange({"Cash", "Check", "Online Transfer", "Bank Transfer"})
            cboModeOfPayment.SelectedIndex = -1

            ' VAT Status options
            cboVatStatus.Items.Clear()
            cboVatStatus.Items.AddRange({"Active", "Inactive"})
            cboVatStatus.SelectedIndex = 0 ' Default to Active

            ' Bank options
            cboBank.Items.Clear()
            cboBank.Items.AddRange({"BDO", "BPI", "Metrobank", "Landbank", "Unionbank", "RCBC", "Security Bank", "Others"})
            cboBank.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Vendor code will be generated once connected to the database.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Generate unique 6-digit Vendor Code
    Private Sub GenerateVendorCode()
        Dim rnd As New Random()
        Dim newCode As String
        Dim codeExists As Boolean

        Do
            newCode = rnd.Next(100000, 999999).ToString()
            codeExists = CheckIfCodeExists(newCode)
        Loop While codeExists

        txtVendorCode.Text = newCode
        txtVendorCode.ReadOnly = True
    End Sub

    ' Check if Vendor Code already exists in database
    Private Function CheckIfCodeExists(code As String) As Boolean
        Dim exists As Boolean = False

        Try
            Using conn As New SqlConnection(connStr)
                Dim sql As String = "SELECT COUNT(*) FROM vendor WHERE VENDOR_CODE = @VC"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@VC", SqlDbType.NVarChar, 10).Value = code
                    conn.Open()
                    Dim count As Integer = CInt(cmd.ExecuteScalar())
                    exists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking vendor code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return exists
    End Function

    ' Select and display vendor logo
    Private Sub picLogo_DoubleClick(sender As Object, e As EventArgs) Handles picLogo.DoubleClick
        Try
            Using openDlg As New OpenFileDialog()
                openDlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
                openDlg.Title = "Select Vendor Logo"

                If openDlg.ShowDialog() = DialogResult.OK Then
                    picLogo.Image = Image.FromFile(openDlg.FileName)
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Save new vendor record
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Basic validation
        If String.IsNullOrWhiteSpace(txtVendor.Text) OrElse String.IsNullOrWhiteSpace(txtTIN.Text) Then
            MessageBox.Show("Please enter Vendor Name and TIN Number!", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim sqlQuery As String = "
                INSERT INTO vendor (
                    VENDOR_CODE, VENDOR, LOGO, BUSINESS_TYPE, CONTACT, EMAIL, TIN, ADDRESS,
                    DTI_REG_NUMBER, VAT_STATUS, SALES_PERSON, MODE_OF_PAYMENT, BANK, BANK_ACCOUNT_NUMBER,
                    PAYMENT_TERMS, DATE_REGISTERED, STATUS
                ) VALUES (
                    @VENDOR_CODE, @VENDOR, @LOGO, @BUSINESS_TYPE, @CONTACT, @EMAIL, @TIN, @ADDRESS,
                    @DTI_REG_NUMBER, @VAT_STATUS, @SALES_PERSON, @MODE_OF_PAYMENT, @BANK, @BANK_ACCOUNT_NUMBER,
                    @PAYMENT_TERMS, GETDATE(), 'Active'
                )"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sqlQuery, conn)
                    cmd.Parameters.Add("@VENDOR_CODE", SqlDbType.NVarChar, 10).Value = txtVendorCode.Text.Trim()
                    cmd.Parameters.Add("@VENDOR", SqlDbType.NVarChar, 150).Value = txtVendor.Text.Trim()

                    ' Handle logo image
                    If picLogo.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            picLogo.Image.Save(ms, picLogo.Image.RawFormat)
                            cmd.Parameters.Add("@LOGO", SqlDbType.VarBinary).Value = ms.ToArray()
                        End Using
                    Else
                        cmd.Parameters.Add("@LOGO", SqlDbType.VarBinary).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add("@BUSINESS_TYPE", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(cboBusinessType.Text), DBNull.Value, cboBusinessType.Text.Trim())
                    cmd.Parameters.Add("@CONTACT", SqlDbType.NVarChar, 30).Value = If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim())
                    cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100).Value = If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim())
                    cmd.Parameters.Add("@TIN", SqlDbType.NVarChar, 30).Value = txtTIN.Text.Trim()
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar, 255).Value = If(String.IsNullOrWhiteSpace(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim())
                    cmd.Parameters.Add("@DTI_REG_NUMBER", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(txtDTI.Text), DBNull.Value, txtDTI.Text.Trim())
                    cmd.Parameters.Add("@VAT_STATUS", SqlDbType.NVarChar, 20).Value = If(String.IsNullOrWhiteSpace(cboVatStatus.Text), "Active", cboVatStatus.Text.Trim())
                    cmd.Parameters.Add("@SALES_PERSON", SqlDbType.NVarChar, 100).Value = If(String.IsNullOrWhiteSpace(txtSalesPerson.Text), DBNull.Value, txtSalesPerson.Text.Trim())
                    cmd.Parameters.Add("@MODE_OF_PAYMENT", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(cboModeOfPayment.Text), DBNull.Value, cboModeOfPayment.Text.Trim())
                    cmd.Parameters.Add("@BANK", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(cboBank.Text), DBNull.Value, cboBank.Text.Trim())
                    cmd.Parameters.Add("@BANK_ACCOUNT_NUMBER", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(txtBankAccount.Text), DBNull.Value, txtBankAccount.Text.Trim())
                    cmd.Parameters.Add("@PAYMENT_TERMS", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrWhiteSpace(cboPaymentTerms.Text), DBNull.Value, cboPaymentTerms.Text.Trim())

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ Vendor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAll()
            GenerateVendorCode()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error saving vendor: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel button - clear or close
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Do you want to clear all entries?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearAll()
            GenerateVendorCode()
        End If
    End Sub

    ' Reset all input fields
    Private Sub ClearAll()
        txtVendor.Clear()
        txtTIN.Clear()
        txtContact.Clear()
        txtEmail.Clear()
        txtSalesPerson.Clear()
        cboBusinessType.SelectedIndex = -1
        txtAddress.Clear()
        txtDTI.Clear()
        cboVatStatus.SelectedIndex = 0
        cboModeOfPayment.SelectedIndex = -1
        cboBank.SelectedIndex = -1
        txtBankAccount.Clear()
        cboPaymentTerms.SelectedIndex = -1
        picLogo.Image = Nothing
    End Sub

End Class