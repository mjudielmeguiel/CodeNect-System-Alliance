Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class ADD_Vendor

    ' ✅ Tamang koneksyon sa database
    Dim strConn As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    ' ✅ Kapag binuksan ang form - ilalagay na agad ang mga pagpipilian
    Private Sub ADD_Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GenerateVendorCode()

            ' 🔹 AYUSIN ANG LAMAN NG MGA DROPDOWN
            ' Mode of Payment - mga paraan ng pagbabayad
            cboModeOfPayment.Items.Clear()
            cboModeOfPayment.Items.Add("Cash")
            cboModeOfPayment.Items.Add("Check")
            cboModeOfPayment.Items.Add("Online Transfer")
            cboModeOfPayment.Items.Add("Bank Transfer")
            cboModeOfPayment.SelectedIndex = -1

            ' VAT Status - kung Active o Inactive ang vendor
            cboVatStatus.Items.Clear()
            cboVatStatus.Items.Add("Active")
            cboVatStatus.Items.Add("Inactive")
            cboVatStatus.SelectedIndex = 0 ' Default ay Active

            ' Kung gusto mo pa ring may laman ang Bangko, ito ay hiwalay na
            cboBank.Items.Clear()
            cboBank.Items.Add("BDO")
            cboBank.Items.Add("BPI")
            cboBank.Items.Add("Metrobank")
            cboBank.Items.Add("Landbank")
            cboBank.Items.Add("Unionbank")
            cboBank.Items.Add("RCBC")
            cboBank.Items.Add("Security Bank")
            cboBank.Items.Add("others")
            cboBank.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Paalala: Mabubuo ang Vendor Code kapag naka-connect nang maayos.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' 🔹 Gumawa ng 6-digit na natatanging Vendor Code
    Private Sub GenerateVendorCode()
        Dim rnd As New Random()
        Dim newCode As String
        Dim mayKapareho As Boolean

        Do
            newCode = rnd.Next(100000, 999999).ToString()
            mayKapareho = CheckIfCodeExists(newCode)
        Loop While mayKapareho

        txtVendorCode.Text = newCode
        txtVendorCode.ReadOnly = True
    End Sub

    ' 🔹 Suriin kung may kaparehong code - INAYOS NA WALANG ERROR
    Private Function CheckIfCodeExists(code As String) As Boolean
        Dim exists As Boolean = False
        Dim tempConn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            tempConn = New SqlConnection(strConn)
            tempConn.Open()
            cmd = New SqlCommand("SELECT COUNT(*) FROM vendor WHERE VENDOR_CODE = @VC", tempConn)
            cmd.Parameters.AddWithValue("@VC", code)
            Dim count As Integer = CInt(cmd.ExecuteScalar())
            exists = (count > 0)
        Catch ex As Exception
            MessageBox.Show("Sa pag-check ng code: " & ex.Message, "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
            If tempConn IsNot Nothing AndAlso tempConn.State = ConnectionState.Open Then
                tempConn.Close()
            End If
        End Try

        Return exists
    End Function

    ' 🔹 Double click sa Logo - INAYOS NA WALANG PULANG GUHIT
    Private Sub picLogo_DoubleClick(sender As Object, e As EventArgs) Handles picLogo.DoubleClick
        Try
            Dim piliLitrato As New OpenFileDialog()
            piliLitrato.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            piliLitrato.Title = "Pumili ng Logo ng Vendor"

            If piliLitrato.ShowDialog() = DialogResult.OK Then
                picLogo.Image = Image.FromFile(piliLitrato.FileName)
                picLogo.SizeMode = PictureBoxSizeMode.Zoom
            End If
        Catch ex As Exception
            MessageBox.Show("Sa pagbukas ng litrato: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🔹 SAVE BUTTON - EKSAKTO SA DATABASE MO, LAHAT AY TAMA NA
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Suriin ang mga kailangang sagutan
        If txtVendor.Text.Trim() = "" OrElse txtTIN.Text.Trim() = "" Then
            MessageBox.Show("Pakilagay ang Pangalan ng Vendor at TIN Number!", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim tempConn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            tempConn = New SqlConnection(strConn)
            tempConn.Open()

            ' ✅ Tamang SQL Query - tugma sa lahat ng kolum
            Dim sqlQuery As String = "INSERT INTO vendor (" &
                "VENDOR_CODE, VENDOR, LOGO, BUSINESS_TYPE, CONTACT, EMAIL, TIN, ADDRESS, " &
                "DTI_REG_NUMBER, VAT_STATUS, SALES_PERSON, MODE_OF_PAYMENT, BANK, BANK_ACCOUNT_NUMBER, " &
                "PAYMENT_TERMS, DATE_REGISTERED, STATUS) " &
                "VALUES (" &
                "@VENDOR_CODE, @VENDOR, @LOGO, @BUSINESS_TYPE, @CONTACT, @EMAIL, @TIN, @ADDRESS, " &
                "@DTI_REG_NUMBER, @VAT_STATUS, @SALES_PERSON, @MODE_OF_PAYMENT, @BANK, @BANK_ACCOUNT_NUMBER, " &
                "@PAYMENT_TERMS, GETDATE(), 'Active')"

            cmd = New SqlCommand(sqlQuery, tempConn)

            cmd.Parameters.AddWithValue("@VENDOR_CODE", txtVendorCode.Text)
            cmd.Parameters.AddWithValue("@VENDOR", txtVendor.Text)

            ' Para sa Logo
            If picLogo.Image IsNot Nothing Then
                Dim ms As New MemoryStream()
                picLogo.Image.Save(ms, picLogo.Image.RawFormat)
                cmd.Parameters.AddWithValue("@LOGO", ms.ToArray())
            Else
                cmd.Parameters.AddWithValue("@LOGO", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@BUSINESS_TYPE", If(String.IsNullOrEmpty(cboBusinessType.Text), DBNull.Value, cboBusinessType.Text))
            cmd.Parameters.AddWithValue("@CONTACT", If(String.IsNullOrEmpty(txtContact.Text), DBNull.Value, txtContact.Text))
            cmd.Parameters.AddWithValue("@EMAIL", If(String.IsNullOrEmpty(txtEmail.Text), DBNull.Value, txtEmail.Text))
            cmd.Parameters.AddWithValue("@TIN", txtTIN.Text)
            cmd.Parameters.AddWithValue("@ADDRESS", If(String.IsNullOrEmpty(txtAddress.Text), DBNull.Value, txtAddress.Text))
            cmd.Parameters.AddWithValue("@DTI_REG_NUMBER", If(String.IsNullOrEmpty(txtDTI.Text), DBNull.Value, txtDTI.Text))
            cmd.Parameters.AddWithValue("@VAT_STATUS", If(String.IsNullOrEmpty(cboVatStatus.Text), "Active", cboVatStatus.Text)) ' ✅ Active/Inactive
            cmd.Parameters.AddWithValue("@SALES_PERSON", If(String.IsNullOrEmpty(txtSalesPerson.Text), DBNull.Value, txtSalesPerson.Text))
            cmd.Parameters.AddWithValue("@MODE_OF_PAYMENT", If(String.IsNullOrEmpty(cboModeOfPayment.Text), DBNull.Value, cboModeOfPayment.Text)) ' ✅ Tamang paraan ng bayad
            cmd.Parameters.AddWithValue("@BANK", If(String.IsNullOrEmpty(cboBank.Text), DBNull.Value, cboBank.Text)) ' ✅ Hiwalay na Bangko
            cmd.Parameters.AddWithValue("@BANK_ACCOUNT_NUMBER", If(String.IsNullOrEmpty(txtBankAccount.Text), DBNull.Value, txtBankAccount.Text))
            cmd.Parameters.AddWithValue("@PAYMENT_TERMS", If(String.IsNullOrEmpty(cboPaymentTerms.Text), DBNull.Value, cboPaymentTerms.Text))

            cmd.ExecuteNonQuery()

            MessageBox.Show("✅ Matagumpay na naidagdag ang Bagong Vendor!", "Tagumpay", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearAll()
            GenerateVendorCode()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ May naging problema: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
            If tempConn IsNot Nothing AndAlso tempConn.State = ConnectionState.Open Then
                tempConn.Close()
            End If
        End Try
    End Sub

    ' 🔹 CANCEL BUTTON
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Gusto mo bang burahin ang lahat ng impormasyon?", "Kumpirmasyon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearAll()
            GenerateVendorCode()
        End If
    End Sub

    ' 🔹 Linisin ang lahat ng field
    Private Sub ClearAll()
        txtVendor.Clear()
        txtTIN.Clear()
        txtContact.Clear()
        txtEmail.Clear()
        txtSalesPerson.Clear()
        cboBusinessType.SelectedIndex = -1
        txtAddress.Clear()
        txtDTI.Clear()
        cboVatStatus.SelectedIndex = 0 ' Babalik sa Active
        cboModeOfPayment.SelectedIndex = -1
        cboBank.SelectedIndex = -1
        txtBankAccount.Clear()
        cboPaymentTerms.SelectedIndex = -1
        picLogo.Image = Nothing
    End Sub

End Class