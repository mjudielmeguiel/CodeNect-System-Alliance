Imports System.Data.SqlClient
Imports System.IO

Public Class ADD_Branch

    ' --- KONEKSYON ---
    Dim connStr As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"
    Dim logoImageData() As Byte = Nothing

    ' --- ✅ ITATAGO NA LANG PERO KUKUNIN PA RIN SA DATABASE ---
    Private currentAccountID As String = ""
    Private currentAccountName As String = ""

    ' --- GABAY SA MGA TEXTBOX ---
    ReadOnly ph_BranchID As String = "BRANCH ID"
    ReadOnly ph_Branch As String = "PANGALAN NG BRANCH"
    ReadOnly ph_TIN As String = "TIN NUMBER"
    ReadOnly ph_BusinessType As String = "URI NG NEGOSYO"
    ReadOnly ph_Address As String = "BUONG TIRAHAN / ADDRESS"
    ReadOnly ph_Email As String = "EMAIL ADDRESS"
    ReadOnly ph_Contact As String = "CONTACT NUMBER"
    ReadOnly ph_Manager As String = "PANGALAN NG MANAGER"

    ' --- PAGBUKAS NG FORM ---
    Private Sub ADD_Branch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAccountDetails()      ' kukunin ang mga details ng account para magamit sa pag-save ng branch
        GenerateBranchID()
        SetPlaceholdersOnLoad()
        SetupBusinessTypeCombo() ' ✅ Load types + check if Main Office exists
        SetupListView()
        LoadBranchesToList()
    End Sub

    ' Placeholders sa pag-load ng form
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

    ' Focus at Lost Focus events para sa mga TextBox (Branch, TIN, Email, Contact, Manager)
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

    ' --- RICHTEXTBOX (ADDRESS) ---
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

    ' --- ✅ SETUP BUSINESS TYPE COMBO BOX ---
    Private Sub SetupBusinessTypeCombo()
        cmbBusinessType.Items.Clear()
        cmbBusinessType.DropDownStyle = ComboBoxStyle.DropDownList

        ' Check if MAIN OFFICE already exists
        Dim mainExists As Boolean = CheckIfMainOfficeExists()

        ' Add MAIN OFFICE ONLY if none exists yet
        If Not mainExists Then
            cmbBusinessType.Items.Add("MAIN OFFICE")
        End If

        ' Add other fixed options
        cmbBusinessType.Items.Add("BRANCH")
        cmbBusinessType.Items.Add("RETAIL STORE")
        cmbBusinessType.Items.Add("WHOLESALE OUTLET")
        cmbBusinessType.Items.Add("FOOD OUTLET")
        cmbBusinessType.Items.Add("SERVICE CENTER")
        cmbBusinessType.Items.Add("WAREHOUSE")
        cmbBusinessType.Items.Add("OFFICE ONLY")
    End Sub

    ' --- ✅ CHECK IF MAIN OFFICE ALREADY EXISTS ---
    Private Function CheckIfMainOfficeExists() As Boolean
        If String.IsNullOrEmpty(currentAccountID) Then Return False

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Branches WHERE ACCOUNT_ID = @AID AND BUSINESS_TYPE = 'MAIN OFFICE'", conn)
                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    ' --- COMBO BOX ---
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

    ' --- ✅ KUNIN ANG ACCOUNT DETAILS (ITATAGO NA LANG SA VARIABLE) ---
    Private Sub GetAccountDetails()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT TOP 1 ACCOUNT_ID, ACCOUNT FROM adm.Account ORDER BY ID DESC", conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    currentAccountID = reader("ACCOUNT_ID").ToString() 'etong part na to ay nakatago lang di ko na sinama sa form para mas malinis tignan
                    currentAccountName = reader("ACCOUNT").ToString()
                Else
                    currentAccountID = ""
                    currentAccountName = ""
                    MessageBox.Show("Walang nakuhang impormasyon ng account.", "BABALA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error sa pagkuha ng Account: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- AUTOMATIC NA BRANCH ID ---
    Private Sub GenerateBranchID()
        Dim datePart As String = DateTime.Now.ToString("yyyyMMdd")
        Dim randomPart As New Random()
        Dim num As Integer = randomPart.Next(1000, 9999)
        txtBranchID.Text = $"{datePart}-{num}"
        txtBranchID.ReadOnly = True
        txtBranchID.ForeColor = Color.Black
    End Sub

    ' --- BUSINESS LOGO ---
    Private Sub picBusinessLogo_DoubleClick(sender As Object, e As EventArgs) Handles picBusinessLogo.DoubleClick
        Using openFile As New OpenFileDialog()
            openFile.Title = "Pumili ng Business Logo"
            openFile.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"

            If openFile.ShowDialog() = DialogResult.OK Then
                picBusinessLogo.Image = Image.FromFile(openFile.FileName)
                picBusinessLogo.SizeMode = PictureBoxSizeMode.StretchImage

                Using ms As New MemoryStream()
                    Dim bmp As New Bitmap(picBusinessLogo.Image)
                    bmp.Save(ms, picBusinessLogo.Image.RawFormat)
                    logoImageData = ms.ToArray()
                End Using
            End If
        End Using
    End Sub

    ' --- AYUSIN ANG LISTVIEW ---
    Private Sub SetupListView()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Sorting = SortOrder.Ascending

        ListView1.Columns.Add("BRANCH ID", 120)
        ListView1.Columns.Add("PANGALAN", 180)
        ListView1.Columns.Add("URI NG NEGOSYO", 140)
        ListView1.Columns.Add("MANAGER", 150)
        ListView1.Columns.Add("STATUS", 80)
    End Sub

    ' --- IPAKITA ANG MGA BRANCH ---
    Private Sub LoadBranchesToList()
        ListView1.Items.Clear()
        If String.IsNullOrEmpty(currentAccountID) Then Exit Sub

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                ' ✅ GUMAGAMIT PA RIN NG currentAccountID, HINDI NA GALING SA TEXTBOX
                Dim cmd As New SqlCommand("SELECT BRANCH_ID, BRANCH, BUSINESS_TYPE, MANAGER, STATUS FROM Branches WHERE ACCOUNT_ID = @AID ORDER BY BRANCH", conn)
                cmd.Parameters.AddWithValue("@AID", currentAccountID)

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("BRANCH_ID").ToString())
                    item.SubItems.Add(reader("BRANCH").ToString())
                    item.SubItems.Add(reader("BUSINESS_TYPE").ToString())
                    item.SubItems.Add(reader("MANAGER").ToString())
                    item.SubItems.Add(reader("STATUS").ToString())
                    ListView1.Items.Add(item)
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error sa pag-load ng listahan: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- ✅ SAVE BUTTON (NABAGO NA: WALANG TEXTBOX NG ACCOUNT) ---
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' VALIDATION
        If String.IsNullOrWhiteSpace(txtBranch.Text) Or txtBranch.Text = ph_Branch Or
           String.IsNullOrWhiteSpace(txtTIN.Text) Or txtTIN.Text = ph_TIN Or
           String.IsNullOrWhiteSpace(txtAddress.Text) Or txtAddress.Text = ph_Address Or
           String.IsNullOrWhiteSpace(txtEmail.Text) Or txtEmail.Text = ph_Email Or
           String.IsNullOrWhiteSpace(txtContact.Text) Or txtContact.Text = ph_Contact Or
           String.IsNullOrWhiteSpace(txtManager.Text) Or txtManager.Text = ph_Manager Or
           String.IsNullOrWhiteSpace(cmbBusinessType.Text) Or cmbBusinessType.Text = ph_BusinessType Then

            MessageBox.Show("Pakiusap, punan lahat ng patlang nang tama.", "BABALA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' SIGURADUHIN MAY DATA ANG ACCOUNT
        If String.IsNullOrEmpty(currentAccountID) Or String.IsNullOrEmpty(currentAccountName) Then
            MessageBox.Show("Hindi makuha ang impormasyon ng may-ari. Isara at buksan ulit ang form.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Branches 
                                           (ACCOUNT_ID, ACCOUNT, BRANCH_ID, BRANCH, TIN, TIN_REGISTERED, BUSINESS_TYPE, BUSINESS_LOGO, ADDRESS, EMAIL, CONTACT, MANAGER, REGISTRATION_DATE, STATUS) 
                                           VALUES 
                                           (@AID, @ACC, @BID, @BRN, @TIN, @TINREG, @BT, @LOGO, @ADDR, @EML, @CONT, @MGR, @REGDATE, @STAT)", conn)

                ' ✅ AUTOMATIC: GALING SA VARIABLE, HINDI NA SA TEXTBOX
                cmd.Parameters.AddWithValue("@AID", currentAccountID)
                cmd.Parameters.AddWithValue("@ACC", currentAccountName)

                ' ✅ GALING SA FORM (TULAD NG DATI)
                cmd.Parameters.AddWithValue("@BID", txtBranchID.Text)
                cmd.Parameters.AddWithValue("@BRN", txtBranch.Text)
                cmd.Parameters.AddWithValue("@TIN", txtTIN.Text)
                cmd.Parameters.AddWithValue("@TINREG", dtpTIN_Registered.Value)
                cmd.Parameters.AddWithValue("@BT", cmbBusinessType.Text)
                cmd.Parameters.AddWithValue("@LOGO", If(logoImageData Is Nothing, DBNull.Value, logoImageData))
                cmd.Parameters.AddWithValue("@ADDR", txtAddress.Text)
                cmd.Parameters.AddWithValue("@EML", txtEmail.Text)
                cmd.Parameters.AddWithValue("@CONT", txtContact.Text)
                cmd.Parameters.AddWithValue("@MGR", txtManager.Text)

                ' ✅ AUTOMATIC NA PETSA AT STATUS
                cmd.Parameters.AddWithValue("@REGDATE", DateTime.Now)
                cmd.Parameters.AddWithValue("@STAT", "OFFLINE")

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Bagong Branch matagumpay na naisave!", "TAGUMPAY", MessageBoxButtons.OK, MessageBoxIcon.Information)

            GenerateBranchID()
            SetupBusinessTypeCombo() ' ✅ Refresh combo — hides MAIN OFFICE now if saved
            LoadBranchesToList()
            ClearInputs()

        Catch ex As Exception
            MessageBox.Show("Error sa pag-save: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- LINISIN ANG MGA INPUT ---
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

    ' --- CANCEL BUTTON ---
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class