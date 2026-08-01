Imports MySqlConnector

Public Class frmPWDDiscount

    ' Transaction values
    Public Property TransactionTotal As Decimal = 0
    Public Property DiscountAmount As Decimal = 0
    Public Property FinalAmount As Decimal = 0
    Public Property ORNumber As String = ""

    Private connStr As String = DBConnection.connStr

    Private Sub frmPWDDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboIDType.Items.AddRange(New String() {"PWD ID", "Senior Citizen ID", "Government ID", "Unified ID", "Other"})
        cboSuffix.Items.AddRange(New String() {"", "Jr.", "Sr.", "II", "III", "IV", "V"})
        cboIDType.SelectedIndex = -1
        cboSuffix.SelectedIndex = -1

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom
        dtpDateOfBirth.CustomFormat = " "

        lblTotalBeforeDiscount.Text = $"Total Amount: ₱ {TransactionTotal:N2}"
        AuditLogger.LogAction("OPEN_DISC_FORM", "PWD_Discount", $"Opened discount form | OR: {ORNumber} | Total: {TransactionTotal:N2}")
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub txtIDNumber_Leave(sender As Object, e As EventArgs) Handles txtIDNumber.Leave
        Dim idNum As String = txtIDNumber.Text.Trim()
        If idNum = "" Then Exit Sub

        Try
            Using conn As New MySqlConnection(connStr)
                Dim query As String = "SELECT * FROM `PWD_Discount` WHERE `ID_Number` = @idnum ORDER BY `DateRecorded` DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idnum", idNum)
                    conn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            cboIDType.Text = dr("ID_Type").ToString().Trim()
                            txtSurname.Text = dr("Surname").ToString().Trim()
                            txtFirstName.Text = dr("FirstName").ToString().Trim()
                            txtMiddleName.Text = dr("MiddleName").ToString().Trim()
                            cboSuffix.Text = dr("Suffix").ToString().Trim()
                            rchFullAddress.Text = dr("FullAddress").ToString().Trim()
                            txtContact.Text = dr("ContactNumber").ToString().Trim()
                            txtEmail.Text = dr("Email").ToString().Trim()

                            If Not IsDBNull(dr("DateOfBirth")) Then
                                dtpDateOfBirth.Value = CDate(dr("DateOfBirth"))
                                dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
                            Else
                                dtpDateOfBirth.CustomFormat = " "
                            End If

                            Dim gender As String = dr("Gender").ToString().Trim()
                            rdomale.Checked = (gender = "Male")
                            rdofemale.Checked = (gender = "Female")

                            MessageBox.Show("✅ Details loaded from previous record.", "Auto-Fill", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogger.LogAction("LOAD_DISC_REC", "PWD_Discount", $"Loaded existing record | ID: {idNum}")
                        Else
                            ClearFields(keepID:=True)
                            MessageBox.Show("ℹ️ New ID — please fill in the details.", "New Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            AuditLogger.LogAction("NEW_DISC_REC", "PWD_Discount", $"New ID detected | ID: {idNum}")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "PWD_Discount", $"Load record failed | ID: {idNum} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnApplyDiscount_Click(sender As Object, e As EventArgs) Handles btnApplyDiscount.Click
        ' Validation
        If String.IsNullOrWhiteSpace(cboIDType.Text) Then
            MessageBox.Show("Select ID Type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboIDType.Focus()
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no ID Type selected")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtIDNumber.Text) Then
            MessageBox.Show("Enter ID Number.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIDNumber.Focus()
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no ID Number entered")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtSurname.Text) Then
            MessageBox.Show("Enter Surname.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSurname.Focus()
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no Surname")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Enter First Name.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no First Name")
            Return
        End If
        If String.IsNullOrWhiteSpace(rchFullAddress.Text) Then
            MessageBox.Show("Enter Full Address.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rchFullAddress.Focus()
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no Address")
            Return
        End If
        If Not rdomale.Checked AndAlso Not rdofemale.Checked Then
            MessageBox.Show("Select Gender.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            AuditLogger.LogAction("DISC_VALID", "PWD_Discount", "Validation failed - no Gender selected")
            Return
        End If

        ' Discount calculation
        Const DISCOUNT_RATE As Decimal = 20D
        Dim vatableAmount As Decimal = Math.Round(TransactionTotal / 1.12D, 2)
        DiscountAmount = Math.Round(vatableAmount * (DISCOUNT_RATE / 100), 2)
        FinalAmount = Math.Round(TransactionTotal - DiscountAmount, 2)

        Dim summary As String =
            $"--- DISCOUNT SUMMARY ---{vbCrLf}" &
            $"Total Amount: ₱ {TransactionTotal:N2}{vbCrLf}" &
            $"Vatable Amount: ₱ {vatableAmount:N2}{vbCrLf}" &
            $"Discount ({DISCOUNT_RATE}%): ₱ {DiscountAmount:N2}{vbCrLf}" &
            $"Amount Due: ₱ {FinalAmount:N2}"

        MessageBox.Show(summary, "Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Information)

        SaveToDatabase()
        frmPOS_System.ApplyPWDDiscount(CInt(DISCOUNT_RATE), True)
        AuditLogger.LogAction("DISC_APPLIED", "PWD_Discount", $"Discount applied | OR: {ORNumber} | ID: {txtIDNumber.Text.Trim()} | Disc: {DiscountAmount:N2} | Final: {FinalAmount:N2}")
        Me.Close()
    End Sub

    Private Sub SaveToDatabase()
        Try
            Using conn As New MySqlConnection(connStr)
                Dim sql As String = "
                    INSERT INTO `PWD_Discount` (
                        `Account_ID`, `Branch_ID`, `ID_Type`, `ID_Number`, `Surname`, `FirstName`, `MiddleName`, `Suffix`, `Gender`,
                        `FullAddress`, `ContactNumber`, `Email`, `DateCreated`, `DateRecorded`, `DateOfBirth`,
                        `Discount_Percent`, `Discount_Amount`, `VAT_Exempt`, `Transaction_Total`, `Amount_After_Discount`, `OR_Number`
                    ) VALUES (
                        @AccountID, @BranchID, @IDType, @IDNumber, @Surname, @FirstName, @MiddleName, @Suffix, @Gender,
                        @Address, @Contact, @Email, NOW(), NOW(), @DOB,
                        @DiscPct, @DiscAmt, @VATExempt, @Total, @Net, @OR
                    )
                "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountID", Login.LoggedInAccountID)
                    cmd.Parameters.AddWithValue("@BranchID", Login.LoggedInBranchID)
                    cmd.Parameters.AddWithValue("@IDType", cboIDType.Text.Trim())
                    cmd.Parameters.AddWithValue("@IDNumber", txtIDNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim())
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@MiddleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Suffix", If(String.IsNullOrWhiteSpace(cboSuffix.Text), DBNull.Value, cboSuffix.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Gender", If(rdomale.Checked, "Male", "Female"))
                    cmd.Parameters.AddWithValue("@Address", rchFullAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Contact", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@DOB", If(dtpDateOfBirth.CustomFormat = " ", DBNull.Value, dtpDateOfBirth.Value.Date))
                    cmd.Parameters.AddWithValue("@DiscPct", 20D)
                    cmd.Parameters.AddWithValue("@DiscAmt", DiscountAmount)
                    cmd.Parameters.AddWithValue("@VATExempt", 1)
                    cmd.Parameters.AddWithValue("@Total", TransactionTotal)
                    cmd.Parameters.AddWithValue("@Net", FinalAmount)
                    cmd.Parameters.AddWithValue("@OR", If(String.IsNullOrWhiteSpace(ORNumber), DBNull.Value, ORNumber.Trim()))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("✅ Record saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("DISC_SAVED", "PWD_Discount", $"Discount record saved | ID: {txtIDNumber.Text.Trim()} | OR: {ORNumber}")
        Catch ex As Exception
            MessageBox.Show("❌ Error saving: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "PWD_Discount", $"Save discount failed | ID: {txtIDNumber.Text.Trim()} | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE_DISC", "PWD_Discount", $"Discount form closed | OR: {ORNumber}")
        Me.Close()
    End Sub

    Private Sub ClearFields(Optional keepID As Boolean = False)
        If Not keepID Then txtIDNumber.Clear()
        cboIDType.SelectedIndex = -1
        txtSurname.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        cboSuffix.SelectedIndex = -1
        rdomale.Checked = False
        rdofemale.Checked = False
        dtpDateOfBirth.CustomFormat = " "
        rchFullAddress.Clear()
        txtContact.Clear()
        txtEmail.Clear()
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

End Class