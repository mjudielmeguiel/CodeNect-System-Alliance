Imports System.Data.SqlClient

Public Class frmPWDDiscount

    ' Mga variable para hawakan ang halaga ng transaksyon
    Public Property TransactionTotal As Decimal = 0
    Public Property DiscountAmount As Decimal = 0
    Public Property FinalAmount As Decimal = 0
    Public Property ORNumber As String = ""

    Private Sub frmPWDDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboIDType.Items.AddRange(New String() {"PWD ID", "Senior Citizen ID", "Government ID", "Unified ID", "Other"})
        cboSuffix.Items.AddRange(New String() {"", "Jr.", "Sr.", "II", "III", "IV", "V"})
        cboIDType.SelectedIndex = -1
        cboSuffix.SelectedIndex = -1

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom
        dtpDateOfBirth.CustomFormat = " "

        ' Ipakita ang kasalukuyang kabuuan para makita ng user
        lblTotalBeforeDiscount.Text = $"Total Amount: ₱ {TransactionTotal:N2}"
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub txtIDNumber_Leave(sender As Object, e As EventArgs) Handles txtIDNumber.Leave
        Dim idNum As String = txtIDNumber.Text.Trim()
        If idNum = "" Then Exit Sub

        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                Dim query As String = "SELECT TOP 1 * FROM PWD_Discount WHERE ID_Number = @idnum ORDER BY DateRecorded DESC"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idnum", idNum)
                    conn.Open()

                    Using dr As SqlDataReader = cmd.ExecuteReader()
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

                            MessageBox.Show("✅ Existing record found! You can still update details if needed.", "Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ClearFields(keepID:=True)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching record: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnApplyDiscount_Click(sender As Object, e As EventArgs) Handles btnApplyDiscount.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(cboIDType.Text) Then
            MessageBox.Show("Please select ID Type.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboIDType.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtIDNumber.Text) Then
            MessageBox.Show("Please enter ID Number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIDNumber.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtSurname.Text) Then
            MessageBox.Show("Please enter Surname.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSurname.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please enter First Name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(rchFullAddress.Text) Then
            MessageBox.Show("Please enter Full Address.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rchFullAddress.Focus()
            Return
        End If

        ' --- COMPUTE DISCOUNT ---
        Const DISCOUNT_RATE As Decimal = 20D ' 20% discount
        Dim vatableAmount As Decimal = Math.Round(TransactionTotal / 1.12D, 2) ' Ihiwalay ang VAT
        DiscountAmount = Math.Round(vatableAmount * (DISCOUNT_RATE / 100), 2)
        FinalAmount = Math.Round(TransactionTotal - DiscountAmount, 2)

        ' Ipakita ang detalye ng discount sa user
        Dim summary As String =
            $"--- DISCOUNT DETAILS ---{vbCrLf}" &
            $"Original Total: ₱ {TransactionTotal:N2}{vbCrLf}" &
            $"VATable Amount: ₱ {vatableAmount:N2}{vbCrLf}" &
            $"Discount ({DISCOUNT_RATE}%): ₱ {DiscountAmount:N2}{vbCrLf}" &
            $"Amount To Pay: ₱ {FinalAmount:N2}{vbCrLf}"

        MessageBox.Show(summary, "Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' --- SAVE RECORD TO DATABASE ---
        SaveToDatabase()

        ' Ipadala ang halaga pabalik sa POS form
        frmPOS_System.ApplyPWDDiscount(CInt(DISCOUNT_RATE), True)

        Me.Close()
    End Sub

    Private Sub SaveToDatabase()
        Dim gender As String = If(rdomale.Checked, "Male", If(rdofemale.Checked, "Female", ""))

        Try
            Using conn As New SqlConnection(DBConnection.connStr)
                ' Gamitin ang MERGE para mag-UPDATE kung may existing ID, o mag-INSERT kung bago
                Dim sql As String = "
                MERGE INTO dbo.PWD_Discount AS Target
                USING (SELECT @idnum AS ID_Number) AS Source
                ON Target.ID_Number = Source.ID_Number
                WHEN MATCHED THEN
                    UPDATE SET
                        ID_Type = @idtype,
                        Surname = @lname,
                        FirstName = @fname,
                        MiddleName = @mname,
                        Suffix = @suffix,
                        Gender = @gender,
                        DateOfBirth = @dob,
                        FullAddress = @address,
                        ContactNumber = @contact,
                        Email = @email,
                        Discount_Percent = 20.00,
                        Discount_Amount = @discAmt,
                        VAT_Exempt = 1,
                        Transaction_Total = @transTotal,
                        Amount_After_Discount = @finalAmt,
                        OR_Number = @orNo,
                        DateRecorded = GETDATE()
                WHEN NOT MATCHED THEN
                    INSERT (
                        ID_Type, ID_Number, Surname, FirstName, MiddleName, Suffix, Gender, DateOfBirth,
                        FullAddress, ContactNumber, Email, Discount_Percent, Discount_Amount,
                        VAT_Exempt, Transaction_Total, Amount_After_Discount, OR_Number, DateRecorded
                    )
                    VALUES (
                        @idtype, @idnum, @lname, @fname, @mname, @suffix, @gender, @dob,
                        @address, @contact, @email, 20.00, @discAmt,
                        1, @transTotal, @finalAmt, @orNo, GETDATE()
                    );"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idtype", cboIDType.Text.Trim())
                    cmd.Parameters.AddWithValue("@idnum", txtIDNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@lname", txtSurname.Text.Trim())
                    cmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@mname", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text.Trim()))
                    cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrWhiteSpace(cboSuffix.Text), DBNull.Value, cboSuffix.Text.Trim()))
                    cmd.Parameters.AddWithValue("@gender", If(String.IsNullOrWhiteSpace(gender), DBNull.Value, gender))

                    If dtpDateOfBirth.CustomFormat <> " " Then
                        cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.Date)
                    Else
                        cmd.Parameters.AddWithValue("@dob", DBNull.Value)
                    End If

                    cmd.Parameters.AddWithValue("@address", rchFullAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@contact", If(String.IsNullOrWhiteSpace(txtContact.Text), DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@discAmt", DiscountAmount)
                    cmd.Parameters.AddWithValue("@transTotal", TransactionTotal)
                    cmd.Parameters.AddWithValue("@finalAmt", FinalAmount)
                    cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(ORNumber), DBNull.Value, ORNumber))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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