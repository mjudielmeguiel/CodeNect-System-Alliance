Imports ClosedXML.Excel
Imports MySqlConnector

Public Class frmPWDDiscount

    ' Transaction values
    Public Property TransactionTotal As Decimal = 0
    Public Property DiscountAmount As Decimal = 0
    Public Property FinalAmount As Decimal = 0
    Public Property ORNumber As String = ""

    Private connStr As String = DBConnection.connStr
    ' ✅ HARDCODED NA LANG LAHAT — WALANG KUKUHA SA DATABASE
    Private Const _vatRatePct As Decimal = 12D
    Private Const _discountRatePct As Decimal = 20D
    Private Const _isVATExempt As Boolean = True

    Private Sub frmPWDDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ✅ DISCOUNT TYPE — MANO-MANO NA LANG, WALA NANG DATABASE
        cboDiscountType.Items.AddRange(New String() {"Senior Citizen", "PWD", "Government", "Other"})

        ' ✅ ID TYPE — MANO-MANO LANG
        cboDiscountType.Items.AddRange(New String() {"PWD ID", "Senior Citizen ID", "Government ID", "Unified ID", "Other"})
        cboSuffix.Items.AddRange(New String() {"", "Jr.", "Sr.", "II", "III", "IV", "V"})

        ' ✅ AYUSIN ANG SELECTION
        cboDiscountType.SelectedIndex = -1
        cboDiscountType.SelectedIndex = -1
        cboSuffix.SelectedIndex = -1

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom
        dtpDateOfBirth.CustomFormat = " "

        lblTotalBeforeDiscount.Text = $"Total Amount: ₱ {TransactionTotal:N2}"
        lblDiscountAmount.Text = "Discount: ₱ 0.00"
        lblFinalAmount.Text = "Amount Due: ₱ 0.00"

        AuditLogger.LogAction("OPEN_DISC_FORM", "PWD_Discount", $"Opened | OR: {ORNumber} | Total: {TransactionTotal:N2}")
    End Sub

    ' ✅ KAPAG NAGPILI NG DISCOUNT — AUTOMATIC NA ANG KUWENTA
    Private Sub cboDiscountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDiscountType.SelectedIndexChanged
        CalculateAndShow()
    End Sub

    ' ✅ AUTOMATIC NA KUWENTA
    Private Sub CalculateAndShow()
        Dim vatRate As Decimal = _vatRatePct / 100D
        Dim vatableAmount As Decimal = Math.Round(TransactionTotal / (1 + vatRate), 2)
        DiscountAmount = Math.Round(vatableAmount * (_discountRatePct / 100D), 2)
        FinalAmount = Math.Round(TransactionTotal - DiscountAmount, 2)

        lblDiscountAmount.Text = $"Discount: ₱ {DiscountAmount:N2}"
        lblFinalAmount.Text = $"Amount Due: ₱ {FinalAmount:N2}"
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub txtIDNumber_Leave(sender As Object, e As EventArgs) Handles txtIDNumber.Leave
        Dim idNum As String = txtIDNumber.Text.Trim()
        If idNum = "" Then Exit Sub

        Try
            Using conn As New MySqlConnection(connStr)
                Dim query As String = "SELECT * FROM `PWD_DISCOUNT` WHERE `ID_NUMBER` = @idnum ORDER BY `DATERECORDED` DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idnum", idNum)
                    conn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            cboDiscountType.Text = dr("ID_TYPE").ToString().Trim()
                            txtFullName.Text = dr("FULL_NAME").ToString().Trim()
                            cboSuffix.Text = dr("SUFFIX").ToString().Trim()
                            txtAddress.Text = dr("ADDRESS").ToString().Trim()

                            If Not IsDBNull(dr("DATEOFBIRTH")) Then
                                dtpDateOfBirth.Value = CDate(dr("DATEOFBIRTH"))
                                dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
                            Else
                                dtpDateOfBirth.CustomFormat = " "
                            End If

                            Dim gender As String = dr("GENDER").ToString().Trim()
                            rdomale.Checked = gender.Equals("Male", StringComparison.OrdinalIgnoreCase)
                            rdofemale.Checked = gender.Equals("Female", StringComparison.OrdinalIgnoreCase)

                            MessageBox.Show("✅ Details loaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogger.LogAction("LOAD_DISC_REC", "PWD_Discount", $"Loaded | ID: {idNum}")
                        Else
                            ClearFields(keepID:=True)
                            MessageBox.Show("ℹ️ New ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogger.LogAction("NEW_DISC_REC", "PWD_Discount", $"New | ID: {idNum}")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Load Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "PWD_Discount", $"Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnApplyDiscount_Click(sender As Object, e As EventArgs) Handles btnApplyDiscount.Click
        If cboDiscountType.SelectedIndex = -1 Then
            MessageBox.Show("Pumili muna ng Discount Type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(cboDiscountType.Text) Then
            MessageBox.Show("Select ID Type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDiscountType.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtIDNumber.Text) Then
            MessageBox.Show("Enter ID Number.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIDNumber.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Enter Full Name.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Enter Address.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return
        End If
        If Not rdomale.Checked AndAlso Not rdofemale.Checked Then
            MessageBox.Show("Select Gender.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim summary = $"--- DISCOUNT SUMMARY ---{vbCrLf}" &
                      $"Discount Type: {cboDiscountType.Text}{vbCrLf}" &
                      $"ID Type: {cboDiscountType.Text}{vbCrLf}" &
                      $"Total Amount: ₱ {TransactionTotal:N2}{vbCrLf}" &
                      $"Discount: ₱ {DiscountAmount:N2}{vbCrLf}" &
                      $"Amount Due: ₱ {FinalAmount:N2}"

        MessageBox.Show(summary, "Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Information)

        SaveToDatabase()
        frmPOS_System.ApplyPWDDiscount(CInt(_discountRatePct), _isVATExempt)
        AuditLogger.LogAction("DISC_APPLIED", "PWD_Discount", $"Applied | Type: {cboDiscountType.Text} | Total: {TransactionTotal:N2}")
        Me.Close()
    End Sub

    Private Sub SaveToDatabase()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql = "INSERT INTO `PWD_DISCOUNT` (" &
                          "`ACCOUNT_ID`, `BRANCH_ID`, `ID_TYPE`, `ID_NUMBER`, `FULL_NAME`, `SUFFIX`, `GENDER`, " &
                          "`ADDRESS`, `NATIONALITY`, `DATECREATED`, `DATERECORDED`, `DATEOFBIRTH`, " &
                          "`DISCOUNT_PERCENT`, `DISCOUNT_AMOUNT`, `VAT_EXEMPT`, `TRANSACTION_TOTAL`, `AMOUNT_AFTER_DISCOUNT`, `OR_NUMBER`, `TRANSACTION_ID`" &
                          ") VALUES (" &
                          "@AccountID, @BranchID, @IDType, @IDNumber, @FullName, @Suffix, @Gender, " &
                          "@Address, @Nationality, NOW(), NOW(), @DOB, " &
                          "@DiscPct, @DiscAmt, @VATExempt, @Total, @Net, @OR, @TransID" &
                          ")"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountID", Login.LoggedInAccountID)
                    cmd.Parameters.AddWithValue("@BranchID", Login.LoggedInBranchID)
                    cmd.Parameters.AddWithValue("@IDType", cboDiscountType.Text.Trim())
                    cmd.Parameters.AddWithValue("@IDNumber", txtIDNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Suffix", If(String.IsNullOrWhiteSpace(cboSuffix.Text), DBNull.Value, cboSuffix.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Gender", If(rdomale.Checked, "Male", "Female"))
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Nationality", If(String.IsNullOrWhiteSpace(txtNationality.Text), "Filipino", txtNationality.Text.Trim()))
                    cmd.Parameters.AddWithValue("@DOB", If(dtpDateOfBirth.CustomFormat = " ", DBNull.Value, dtpDateOfBirth.Value.Date))
                    cmd.Parameters.AddWithValue("@DiscPct", _discountRatePct)
                    cmd.Parameters.AddWithValue("@DiscAmt", DiscountAmount)
                    cmd.Parameters.AddWithValue("@VATExempt", If(_isVATExempt, 1, 0))
                    cmd.Parameters.AddWithValue("@Total", TransactionTotal)
                    cmd.Parameters.AddWithValue("@Net", FinalAmount)
                    cmd.Parameters.AddWithValue("@OR", If(String.IsNullOrWhiteSpace(ORNumber), DBNull.Value, ORNumber.Trim()))
                    cmd.Parameters.AddWithValue("@TransID", If(String.IsNullOrWhiteSpace(ORNumber), DBNull.Value, ORNumber.Trim()))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("✅ Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("DISC_SAVED", "PWD_Discount", $"Saved | ID: {txtIDNumber.Text.Trim()}")
        Catch ex As Exception
            MessageBox.Show("Save Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "PWD_Discount", $"Save failed: {ex.Message}")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE", "PWD_Discount", "Form closed")
        Me.Close()
    End Sub

    Private Sub ClearFields(Optional keepID As Boolean = False)
        If Not keepID Then txtIDNumber.Clear()
        cboDiscountType.SelectedIndex = -1
        cboDiscountType.SelectedIndex = -1
        txtFullName.Clear()
        cboSuffix.SelectedIndex = -1
        rdomale.Checked = False
        rdofemale.Checked = False
        dtpDateOfBirth.CustomFormat = " "
        txtAddress.Clear()
        txtNationality.Clear()
        lblDiscountAmount.Text = "Discount: ₱ 0.00"
        lblFinalAmount.Text = "Amount Due: ₱ 0.00"
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

End Class