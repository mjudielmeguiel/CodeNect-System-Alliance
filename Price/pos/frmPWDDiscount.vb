Imports System.Data.SqlClient

Public Class frmPWDDiscount

    Private Sub frmPWDDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboIDType.Items.AddRange(New String() {"PWD ID", "Government ID", "Unified ID", "Other"})
        cboSuffix.Items.AddRange(New String() {"", "Jr.", "Sr.", "II", "III", "IV", "V"})
        cboIDType.SelectedIndex = -1
        cboSuffix.SelectedIndex = -1

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom
        dtpDateOfBirth.CustomFormat = " "
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        dtpDateOfBirth.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub txtIDNumber_Leave(sender As Object, e As EventArgs) Handles txtIDNumber.Leave
        Dim idNum As String = txtIDNumber.Text.Trim()
        If idNum = "" Then Exit Sub

        Try
            Using conn As New SqlConnection(modConnection.connStr)
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

                            If dr("Gender").ToString().Trim() = "Male" Then
                                rdomale.Checked = True
                                rdofemale.Checked = False
                            ElseIf dr("Gender").ToString().Trim() = "Female" Then
                                rdofemale.Checked = True
                                rdomale.Checked = False
                            Else
                                rdomale.Checked = False
                                rdofemale.Checked = False
                            End If

                            MessageBox.Show("Existing record found! You can edit details if needed.", "Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        If cboIDType.Text.Trim() = "" Then
            MessageBox.Show("Please select ID Type.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboIDType.Focus()
            Return
        End If
        If txtIDNumber.Text.Trim() = "" Then
            MessageBox.Show("Please enter ID Number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIDNumber.Focus()
            Return
        End If
        If txtSurname.Text.Trim() = "" Then
            MessageBox.Show("Please enter Surname.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSurname.Focus()
            Return
        End If
        If txtFirstName.Text.Trim() = "" Then
            MessageBox.Show("Please enter First Name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return
        End If
        If rchFullAddress.Text.Trim() = "" Then
            MessageBox.Show("Please enter Full Address.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rchFullAddress.Focus()
            Return
        End If

        frmPOS_System.ApplyPWDDiscount(20, True)
        MessageBox.Show("✅ Discount applied! Details will be saved when you complete the transaction.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
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
        If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Public Sub SaveToDatabase()
        Dim gender As String = If(rdomale.Checked, "Male", If(rdofemale.Checked, "Female", ""))

        Try
            Using conn As New SqlConnection(modConnection.connStr)
                Dim sql As String = "INSERT INTO PWD_Discount 
                    (ID_Type, ID_Number, Surname, FirstName, MiddleName, Suffix, Gender, DateOfBirth, FullAddress, ContactNumber, Email)
                    VALUES 
                    (@idtype, @idnum, @lname, @fname, @mname, @suffix, @gender, @dob, @address, @contact, @email)"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idtype", cboIDType.Text.Trim())
                    cmd.Parameters.AddWithValue("@idnum", txtIDNumber.Text.Trim())
                    cmd.Parameters.AddWithValue("@lname", txtSurname.Text.Trim())
                    cmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@mname", If(txtMiddleName.Text.Trim() = "", DBNull.Value, txtMiddleName.Text.Trim()))
                    cmd.Parameters.AddWithValue("@suffix", If(cboSuffix.Text.Trim() = "", DBNull.Value, cboSuffix.Text.Trim()))
                    cmd.Parameters.AddWithValue("@gender", If(gender = "", DBNull.Value, gender))

                    If dtpDateOfBirth.CustomFormat <> " " Then
                        cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.Date)
                    Else
                        cmd.Parameters.AddWithValue("@dob", DBNull.Value)
                    End If

                    cmd.Parameters.AddWithValue("@address", rchFullAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@contact", If(txtContact.Text.Trim() = "", DBNull.Value, txtContact.Text.Trim()))
                    cmd.Parameters.AddWithValue("@email", If(txtEmail.Text.Trim() = "", DBNull.Value, txtEmail.Text.Trim()))

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving PWD record: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class