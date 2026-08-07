Imports MySqlConnector
Imports System.Text

Public Class frmRegisterVendor

    Private random As New Random() ' ✅ Para sa Random Numbers

    Private Sub frmRegisterVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ SOURCE TYPE: Dalawa lang ang pagpipilian
        cboSourceType.Items.Clear()
        cboSourceType.Items.Add("Direct Supplier")
        cboSourceType.Items.Add("Distributor")
        cboSourceType.SelectedIndex = 0

        ' ✅ BANK: Listahan ng mga bangko
        cboBank.Items.Clear()
        cboBank.Items.Add("Banco de Oro (BDO)")
        cboBank.Items.Add("Bank of the Philippine Islands (BPI)")
        cboBank.Items.Add("Metrobank")
        cboBank.Items.Add("Landbank of the Philippines")
        cboBank.Items.Add("Philippine National Bank (PNB)")
        cboBank.Items.Add("Security Bank")
        cboBank.Items.Add("UnionBank")
        cboBank.Items.Add("Chinabank")
        cboBank.Items.Add("EastWest Bank")
        cboBank.Items.Add("Rizal Commercial Banking Corp (RCBC)")
        cboBank.Items.Add("Development Bank of the Philippines (DBP)")
        cboBank.Items.Add("Asia United Bank")
        cboBank.Items.Add("Citibank")
        cboBank.Items.Add("Standard Chartered Bank")
        cboBank.Items.Add("Other")
        cboBank.SelectedIndex = 0
    End Sub

    ' ✅ GUMAGAWA NG VENDOR CODE: INITIALS + RANDOM NUMBERS
    Private Function GenerateVendorCode(vendorName As String) As String
        If String.IsNullOrWhiteSpace(vendorName) Then Return "V-00000"

        ' ✅ Kunin ang UNANG TITIK ng bawat salita
        Dim initials As New StringBuilder()
        Dim words = vendorName.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        For Each word In words
            If Not String.IsNullOrWhiteSpace(word) AndAlso Char.IsLetter(word(0)) Then
                initials.Append(Char.ToUpper(word(0)))
            End If
        Next

        ' ✅ Kung walang nakuha na letra → gumamit ng "V"
        If initials.Length = 0 Then initials.Append("V")

        ' ✅ Kunin lamang hanggang 2 letra (kung mas marami)
        If initials.Length > 2 Then
            Return initials.ToString().Substring(0, 2) & "-" & random.Next(10000, 99999).ToString()
        End If

        ' ✅ Format: INITIALS-XXXXX  halimbawa: LT-48291
        Return initials.ToString() & "-" & random.Next(10000, 99999).ToString()
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' ✅ VALIDATION — Required Fields
        If String.IsNullOrWhiteSpace(txtVendor.Text) Then
            MessageBox.Show("Please enter Vendor Name!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVendor.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter Username!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter Password!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            MessageBox.Show("Please Confirm your Password!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Focus()
            Return
        End If
        ' ✅ Check kung magkatugma ang Password at Confirm Password
        If txtPassword.Text.Trim() <> txtConfirmPassword.Text.Trim() Then
            MessageBox.Show("Password do not match! Please re-type your password.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Clear()
            txtConfirmPassword.Clear()
            txtPassword.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please enter Email Address!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtBankAccountNumber.Text) Then
            MessageBox.Show("Please enter Bank Account Number!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBankAccountNumber.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                ' ✅ BUMUO NG VENDOR CODE BASED SA NAME + RANDOM NUMBERS
                Dim vendorCode As String = GenerateVendorCode(txtVendor.Text.Trim())

                ' ✅ I-INSERT SA DATABASE KASAMA ANG GENERATED VENDOR_CODE
                Dim sql As New StringBuilder()
                sql.AppendLine("INSERT INTO `vendor_account` (")
                sql.AppendLine("    `VENDOR_CODE`, `VENDOR`, `USERNAME`, `PASSWORD`, `EMAIL`, `ADDRESS`, `CONTACT`,")
                sql.AppendLine("    `TIN`, `DTI_REG_NUMBER`, `BANK`, `BANK_ACCOUNT_NUMBER`, `SOURCE_TYPE`,")
                sql.AppendLine("    `SALES_PERSON`")
                sql.AppendLine(") VALUES (")
                sql.AppendLine("    @vcode, @vendor, @uname, @pass, @email, @address, @contact,")
                sql.AppendLine("    @tin, @dti, @bank, @bankacc, @stype,")
                sql.AppendLine("    @salesperson")
                sql.AppendLine(");")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@vcode", vendorCode)
                    cmd.Parameters.AddWithValue("@vendor", txtVendor.Text.Trim())
                    cmd.Parameters.AddWithValue("@uname", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(txtAddress.Text), DBNull.Value, txtAddress.Text.Trim()))
                    cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@tin", If(String.IsNullOrWhiteSpace(txtTIN.Text), DBNull.Value, txtTIN.Text.Trim()))
                    cmd.Parameters.AddWithValue("@dti", If(String.IsNullOrWhiteSpace(txtDTI.Text), DBNull.Value, txtDTI.Text.Trim()))
                    cmd.Parameters.AddWithValue("@bank", cboBank.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@bankacc", txtBankAccountNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@stype", cboSourceType.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@salesperson", If(String.IsNullOrWhiteSpace(txtSalesPerson.Text), DBNull.Value, txtSalesPerson.Text.Trim()))

                    cmd.ExecuteNonQuery()

                    ' ✅ KUNIN ANG BAGONG GINAWANG VENDOR ID — Auto-generated!
                    Dim newVendorID As Integer = CInt(cmd.LastInsertedId)

                    MessageBox.Show($"✅ Vendor Account Successfully Created!{Environment.NewLine}{Environment.NewLine}" &
                                    $"Vendor ID: {newVendorID}{Environment.NewLine}" &
                                    $"Vendor Code: {vendorCode}{Environment.NewLine}" &
                                    $"Vendor: {txtVendor.Text.Trim()}{Environment.NewLine}" &
                                    $"Username: {txtUsername.Text.Trim()}{Environment.NewLine}" &
                                    $"Source Type: {cboSourceType.SelectedItem}{Environment.NewLine}" &
                                    $"Bank: {cboBank.SelectedItem}",
                                    "Account Registered", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    AuditLogger.LogAction("REGISTER_VENDOR", "Vendor Account", $"Created Vendor [{txtVendor.Text.Trim()}] | ID: {newVendorID} | Code: {vendorCode} | User: {txtUsername.Text.Trim()} | Type: {cboSourceType.SelectedItem}")

                    ' ✅ CLEAR FORM after save
                    ClearForm()
                End Using
            End Using
        Catch ex As MySqlException When ex.Number = 1062
            MessageBox.Show("⚠️ Username already exists! Please use another username.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("❌ Error saving Vendor Account: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Vendor Account", $"Failed to register vendor: {ex.Message}")
        End Try
    End Sub

    Private Sub ClearForm()
        txtVendor.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtContact.Clear()
        txtTIN.Clear()
        txtDTI.Clear()
        txtBankAccountNumber.Clear()
        txtSalesPerson.Clear()
        cboSourceType.SelectedIndex = 0
        cboBank.SelectedIndex = 0
    End Sub

End Class