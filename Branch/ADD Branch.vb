Imports System.Data.SqlClient
Imports System.IO

Public Class ADD_Branch

    Dim logoImageData() As Byte = Nothing
    Private currentAccountID As String = ""
    Private currentAccountName As String = ""

    ReadOnly ph_BranchID As String = "BRANCH ID"
    ReadOnly ph_Branch As String = "BRANCH NAME"
    ReadOnly ph_TIN As String = "TIN NUMBER"
    ReadOnly ph_BusinessType As String = "BUSINESS TYPE"
    ReadOnly ph_Address As String = "FULL ADDRESS"
    ReadOnly ph_Email As String = "EMAIL ADDRESS"
    ReadOnly ph_Contact As String = "CONTACT NUMBER"
    ReadOnly ph_Manager As String = "MANAGER NAME"

    Private Sub ADD_Branch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAccountDetails()
        GenerateBranchID()
        SetPlaceholdersOnLoad()
        SetupBusinessTypeCombo()
    End Sub

    Private Sub SetPlaceholdersOnLoad()
        If String.IsNullOrEmpty(txtBranchID.Text) Then
            txtBranchID.Text = ph_BranchID
            txtBranchID.ForeColor = Color.Black
        End If
        If String.IsNullOrEmpty(txtBranch.Text) Then
            txtBranch.Text = ph_Branch
            txtBranch.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(txtTIN.Text) Then
            txtTIN.Text = ph_TIN
            txtTIN.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(txtAddress.Text) Then
            txtAddress.Text = ph_Address
            txtAddress.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(txtEmail.Text) Then
            txtEmail.Text = ph_Email
            txtEmail.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(txtContact.Text) Then
            txtContact.Text = ph_Contact
            txtContact.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(txtManager.Text) Then
            txtManager.Text = ph_Manager
            txtManager.ForeColor = Color.Gray
        End If
        If String.IsNullOrEmpty(cmbBusinessType.Text) Then
            cmbBusinessType.Text = ph_BusinessType
            cmbBusinessType.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs) Handles txtBranch.GotFocus, txtTIN.GotFocus, txtEmail.GotFocus, txtContact.GotFocus, txtManager.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text = ph_Branch Or txt.Text = ph_TIN Or txt.Text = ph_Email Or txt.Text = ph_Contact Or txt.Text = ph_Manager Then
            txt.Text = ""
            txt.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs) Handles txtBranch.LostFocus, txtTIN.LostFocus, txtEmail.LostFocus, txtContact.LostFocus, txtManager.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            Select Case txt.Name
                Case "txtBranch" : txt.Text = ph_Branch
                Case "txtTIN" : txt.Text = ph_TIN
                Case "txtEmail" : txt.Text = ph_Email
                Case "txtContact" : txt.Text = ph_Contact
                Case "txtManager" : txt.Text = ph_Manager
            End Select
            txt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtAddress_GotFocus(sender As Object, e As EventArgs) Handles txtAddress.GotFocus
        If txtAddress.Text = ph_Address Then
            txtAddress.Text = ""
            txtAddress.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtAddress_LostFocus(sender As Object, e As EventArgs) Handles txtAddress.LostFocus
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            txtAddress.Text = ph_Address
            txtAddress.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub SetupBusinessTypeCombo()
        cmbBusinessType.Items.Clear()
        cmbBusinessType.DropDownStyle = ComboBoxStyle.DropDownList
        Dim mainExists As Boolean = CheckIfMainOfficeExists()
        If Not mainExists Then cmbBusinessType.Items.Add("MAIN OFFICE")
        cmbBusinessType.Items.AddRange({"BRANCH", "RETAIL STORE", "WHOLESALE OUTLET", "FOOD OUTLET", "SERVICE CENTER", "WAREHOUSE", "OFFICE ONLY"})
    End Sub

    Private Function CheckIfMainOfficeExists() As Boolean
        If String.IsNullOrEmpty(currentAccountID) Then Return False
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Branches WHERE ACCOUNT_ID = @AID AND BUSINESS_TYPE = 'MAIN OFFICE'", conn)
                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub cmbBusinessType_GotFocus(sender As Object, e As EventArgs) Handles cmbBusinessType.GotFocus
        If cmbBusinessType.Text = ph_BusinessType Then
            cmbBusinessType.Text = ""
            cmbBusinessType.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmbBusinessType_LostFocus(sender As Object, e As EventArgs) Handles cmbBusinessType.LostFocus
        If String.IsNullOrWhiteSpace(cmbBusinessType.Text) Then
            cmbBusinessType.Text = ph_BusinessType
            cmbBusinessType.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub GetAccountDetails()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT TOP 1 ACCOUNT_ID, ACCOUNT FROM adm.Account ORDER BY ID DESC", conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    currentAccountID = reader("ACCOUNT_ID").ToString()
                    currentAccountName = reader("ACCOUNT").ToString()
                Else
                    currentAccountID = ""
                    currentAccountName = ""
                    MessageBox.Show("No account information found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateBranchID()
        Dim datePart As String = DateTime.Now.ToString("yyyyMMdd")
        Dim rnd As New Random()
        txtBranchID.Text = $"{datePart}-{rnd.Next(1000, 9999)}"
        txtBranchID.ReadOnly = True
        txtBranchID.ForeColor = Color.Black
    End Sub

    Private Sub picBusinessLogo_DoubleClick(sender As Object, e As EventArgs) Handles picBusinessLogo.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Business Logo"
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                picBusinessLogo.Image = Image.FromFile(ofd.FileName)
                picBusinessLogo.SizeMode = PictureBoxSizeMode.StretchImage
                Using ms As New MemoryStream()
                    Dim bmp As New Bitmap(picBusinessLogo.Image)
                    bmp.Save(ms, picBusinessLogo.Image.RawFormat)
                    logoImageData = ms.ToArray()
                End Using
            End If
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtBranch.Text) Or txtBranch.Text = ph_Branch Or
           String.IsNullOrWhiteSpace(txtTIN.Text) Or txtTIN.Text = ph_TIN Or
           String.IsNullOrWhiteSpace(txtAddress.Text) Or txtAddress.Text = ph_Address Or
           String.IsNullOrWhiteSpace(txtEmail.Text) Or txtEmail.Text = ph_Email Or
           String.IsNullOrWhiteSpace(txtContact.Text) Or txtContact.Text = ph_Contact Or
           String.IsNullOrWhiteSpace(txtManager.Text) Or txtManager.Text = ph_Manager Or
           String.IsNullOrWhiteSpace(cmbBusinessType.Text) Or cmbBusinessType.Text = ph_BusinessType Then
            MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrEmpty(currentAccountID) Or String.IsNullOrEmpty(currentAccountName) Then
            MessageBox.Show("Account data not found. Restart the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Branches (ACCOUNT_ID, ACCOUNT, BRANCH_ID, BRANCH, TIN, BUSINESS_TYPE, BUSINESS_LOGO, ADDRESS, EMAIL, CONTACT, MANAGER, REGISTRATION_DATE, STATUS) VALUES (@AID, @ACC, @BID, @BRN, @TIN, @BT, @LOGO, @ADDR, @EML, @CONT, @MGR, @REGDATE, @STAT)", conn)
                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                cmd.Parameters.AddWithValue("@ACC", currentAccountName)
                cmd.Parameters.AddWithValue("@BID", txtBranchID.Text)
                cmd.Parameters.AddWithValue("@BRN", txtBranch.Text)
                cmd.Parameters.AddWithValue("@TIN", txtTIN.Text)
                cmd.Parameters.AddWithValue("@BT", cmbBusinessType.Text)
                cmd.Parameters.AddWithValue("@LOGO", If(logoImageData Is Nothing, DBNull.Value, logoImageData))
                cmd.Parameters.AddWithValue("@ADDR", txtAddress.Text)
                cmd.Parameters.AddWithValue("@EML", txtEmail.Text)
                cmd.Parameters.AddWithValue("@CONT", txtContact.Text)
                cmd.Parameters.AddWithValue("@MGR", txtManager.Text)
                cmd.Parameters.AddWithValue("@REGDATE", DateTime.Now)
                cmd.Parameters.AddWithValue("@STAT", "OFFLINE")
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Branch saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GenerateBranchID()
            SetupBusinessTypeCombo()
            ClearInputs()
        Catch ex As Exception
            MessageBox.Show("Error saving record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        SetPlaceholdersOnLoad()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class