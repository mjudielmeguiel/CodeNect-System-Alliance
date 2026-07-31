Imports System.IO
Imports MySqlConnector

Public Class ADD_Branch

    Dim logoImageData() As Byte = Nothing
    Private currentAccountID As String = ""
    Private currentAccountName As String = ""

    Private Sub ADD_Branch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAccountDetails()
        GenerateBranchID()
        SetupBusinessTypeCombo()
        Me.TopMost = True
    End Sub

    Private Sub SetupBusinessTypeCombo()
        cmbBusinessType.Items.Clear()
        cmbBusinessType.DropDownStyle = ComboBoxStyle.DropDownList
        Dim mainOfficeExists As Boolean = CheckIfMainOfficeExists()

        If Not mainOfficeExists Then
            cmbBusinessType.Items.Add("MAIN OFFICE")
        End If

        cmbBusinessType.Items.AddRange({
            "BRANCH",
            "RETAIL STORE",
            "WHOLESALE OUTLET",
            "FOOD OUTLET",
            "SERVICE CENTER",
            "WAREHOUSE",
            "OFFICE ONLY"
        })
    End Sub

    Private Function CheckIfMainOfficeExists() As Boolean
        If String.IsNullOrEmpty(currentAccountID) Then Return False

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM `branches` WHERE `ACCOUNT_ID` = @AID AND `BUSINESS_TYPE` = 'MAIN OFFICE'", conn)
                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub GetAccountDetails()
        Try
            If String.IsNullOrEmpty(Login.LoggedInAccountID) Then
                MessageBox.Show("No logged-in account found. Please log in first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT `ACCOUNT_ID`, `ACCOUNT` FROM `account` WHERE `ACCOUNT_ID` = @AID", conn)
                cmd.Parameters.AddWithValue("@AID", Login.LoggedInAccountID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        currentAccountID = reader("ACCOUNT_ID").ToString().Trim()
                        currentAccountName = reader("ACCOUNT").ToString().Trim()
                    Else
                        MessageBox.Show("Account information not found.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading account details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub GenerateBranchID()
        Dim datePart As String = DateTime.Now.ToString("yyyyMMdd")
        Static rnd As New Random()
        txtBranchID.Text = $"{datePart}-{rnd.Next(1000, 9999)}"
        txtBranchID.ReadOnly = True
    End Sub

    Private Sub picBusinessLogo_DoubleClick(sender As Object, e As EventArgs) Handles picBusinessLogo.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Business Logo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    picBusinessLogo.Image = Image.FromFile(ofd.FileName)
                    picBusinessLogo.SizeMode = PictureBoxSizeMode.StretchImage

                    Using ms As New MemoryStream()
                        picBusinessLogo.Image.Save(ms, picBusinessLogo.Image.RawFormat)
                        logoImageData = ms.ToArray()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Failed to load image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub ClearInputs()
        txtBranch.Clear()
        txtTIN.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
        txtContact.Clear()
        txtManager.Clear()
        cmbBusinessType.SelectedIndex = -1
        picBusinessLogo.Image = Nothing
        logoImageData = Nothing
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.TopMost = True
        Me.Close()
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtBranch.Text) Or
           String.IsNullOrWhiteSpace(txtTIN.Text) Or
           String.IsNullOrWhiteSpace(txtAddress.Text) Or
           String.IsNullOrWhiteSpace(txtEmail.Text) Or
           String.IsNullOrWhiteSpace(txtContact.Text) Or
           String.IsNullOrWhiteSpace(txtManager.Text) Or
           cmbBusinessType.SelectedIndex = -1 Then

            MessageBox.Show("Please fill in all required fields.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(currentAccountID) Then
            MessageBox.Show("Account data not found. Close and reopen the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "INSERT INTO `branches` (`ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `TIN`, `TIN_REGISTERED`, `BUSINESS_TYPE`, `BRANCH_PHOTO`, `ADDRESS`, `EMAIL`, `CONTACT`, `MANAGER`, `REGISTRATION_DATE`, `STATUS`) " &
                    "VALUES (@AID, @ACC, @BID, @BRN, @TIN, 'REGISTERED', @BT, @LOGO, @ADDR, @EML, @CONT, @MGR, CURDATE(), 'ACTIVE')", conn)

                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                cmd.Parameters.AddWithValue("@ACC", currentAccountName)
                cmd.Parameters.AddWithValue("@BID", txtBranchID.Text.Trim())
                cmd.Parameters.AddWithValue("@BRN", txtBranch.Text.Trim())
                cmd.Parameters.AddWithValue("@TIN", txtTIN.Text.Trim())
                cmd.Parameters.AddWithValue("@BT", cmbBusinessType.Text)
                cmd.Parameters.AddWithValue("@LOGO", If(logoImageData IsNot Nothing, logoImageData, DBNull.Value))
                cmd.Parameters.AddWithValue("@ADDR", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@EML", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@CONT", txtContact.Text.Trim())
                cmd.Parameters.AddWithValue("@MGR", txtManager.Text.Trim())

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Branch saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            GenerateBranchID()
            SetupBusinessTypeCombo()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class