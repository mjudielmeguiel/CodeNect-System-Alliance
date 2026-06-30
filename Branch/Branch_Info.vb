Imports System.Data.SqlClient
Imports System.IO

Public Class Branch_Info

    Public SelectedBranchID As String
    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"
    Private NewImageBytes As Byte() = Nothing

#Region "OFFLINE CURRENT USER ACCOUNT" 'if ever mag Crash or mag sutdown bigla, naka Automatic na syang offline

    Private Sub DashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(Login.LoggedInUserID) Then
            SetAccountOffline()
        End If
    End Sub

    Private Sub SetAccountOffline()
        If String.IsNullOrEmpty(Login.LoggedInUserID) Then Return

        Try
            Using conn As New SqlConnection(ConnString)
                conn.Open()
                Dim cmdText As String = ""

                If Login.LoggedInUserType.ToUpper() = "ADMIN" Then

                    cmdText = "UPDATE dbo.User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @UserID"
                Else
                    cmdText = "UPDATE dbo.User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @UserID"
                End If

                Using cmd As New SqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        MessageBox.Show("Warning: No user record updated. Check if ID/Table is correct.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region


    Private Sub Branch_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboBusType.DropDownStyle = ComboBoxStyle.DropDown
        cboManager.DropDownStyle = ComboBoxStyle.DropDown

        cboBusType.Items.Clear()
        cboBusType.Items.Add("Food and Grocery Retail Business")
        cboBusType.Items.Add("Retail Business")
        cboBusType.Items.Add("Wholesale Business")
        cboBusType.Items.Add("Service Business")
        cboBusType.Items.Add("Manufacturing Business")
        cboBusType.Items.Add("Franchise Business")
        cboBusType.Items.Add("Corporation")
        cboBusType.Items.Add("Partnership")
        cboBusType.Items.Add("Sole Proprietorship")
        cboBusType.Items.Add("Cooperative")

        LoadManagerList()
        LoadBranchDetails()
        LoadProductsForBranch()
    End Sub

    Private Sub LoadManagerList()
        Try
            Dim Sql As String = "SELECT DISTINCT FULL_NAME, USERNAME FROM dbo.User_Accounts " &
                                "WHERE (USER_TYPE = 'Manager' OR USER_TYPE = 'manager' OR USER_TYPE = 'MANAGER') " &
                                "AND STATUS = 'ACTIVE' " &
                                "ORDER BY FULL_NAME ASC"

            Using Conn As New SqlConnection(ConnString)
                Using Cmd As New SqlCommand(Sql, Conn)
                    Conn.Open()
                    Dim Dr As SqlDataReader = Cmd.ExecuteReader()

                    cboManager.Items.Clear()

                    While Dr.Read()
                        cboManager.Items.Add(Dr("FULL_NAME").ToString())
                    End While
                    Dr.Close()
                End Using
            End Using

            If cboManager.Items.Count = 0 Then
                cboManager.Items.Add("No active Manager found")
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Manager list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBranchDetails()
        Try
            Dim Sql As String = "SELECT ACCOUNT_ID, ACCOUNT, BRANCH_ID, BRANCH, TIN, BUSINESS_TYPE, ADDRESS, EMAIL, CONTACT, MANAGER, BUSINESS_LOGO " &
                                 "FROM dbo.Branches " &
                                 "WHERE BRANCH_ID = @BranchID"

            Using Conn As New SqlConnection(ConnString)
                Using Cmd As New SqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@BranchID", SelectedBranchID)

                    Conn.Open()
                    Dim Dr As SqlDataReader = Cmd.ExecuteReader()

                    If Dr.Read() Then
                        txtAccountID.Text = Dr("ACCOUNT_ID").ToString()
                        txtAccount.Text = Dr("ACCOUNT").ToString()
                        txtBranchID.Text = Dr("BRANCH_ID").ToString()
                        txtBranch.Text = Dr("BRANCH").ToString()
                        txtTIN.Text = Dr("TIN").ToString()

                        If Not IsDBNull(Dr("BUSINESS_TYPE")) Then
                            Dim valBusType = Dr("BUSINESS_TYPE").ToString()
                            cboBusType.Text = valBusType
                            If Not cboBusType.Items.Contains(valBusType) Then
                                cboBusType.Items.Add(valBusType)
                            End If
                        End If

                        txtAddress.Text = Dr("ADDRESS").ToString()
                        txtEmail.Text = Dr("EMAIL").ToString()
                        txtContact.Text = Dr("CONTACT").ToString()

                        If Not IsDBNull(Dr("MANAGER")) Then
                            Dim valManager = Dr("MANAGER").ToString()
                            cboManager.Text = valManager
                            If Not cboManager.Items.Contains(valManager) Then
                                cboManager.Items.Add(valManager)
                            End If
                        Else
                            cboManager.Text = ""
                        End If

                        If Not IsDBNull(Dr("BUSINESS_LOGO")) Then
                            Dim imgBytes As Byte() = CType(Dr("BUSINESS_LOGO"), Byte())
                            Using ms As New MemoryStream(imgBytes)
                                picLogo.Image = Image.FromStream(ms)
                                picLogo.SizeMode = PictureBoxSizeMode.StretchImage
                            End Using
                        Else
                            picLogo.Image = Nothing
                        End If
                    End If

                    Dr.Close()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading branch details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProductsForBranch()
        Try
            Dim Sql As String = "SELECT " &
                                "BARCODE, SKU, BRAND, DESCRIPTIONS, CATEGORY, SIZE, " &
                                "PRICE, UNIT, AVAILABLE, VENDOR_CODE " &
                                "FROM inv.Inventory_Master_file " &
                                "WHERE BRANCH_ID = @BranchID " &
                                "ORDER BY DESCRIPTIONS ASC"

            Using Conn As New SqlConnection(ConnString)
                Using Cmd As New SqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@BranchID", SelectedBranchID)

                    Dim Da As New SqlDataAdapter(Cmd)
                    Dim Dt As New DataTable()
                    Da.Fill(Dt)

                    dgvProducts.DataSource = Dt

                    ' Ayusin ang pangalan ng ulo ng column para mas madaling maintindihan
                    dgvProducts.Columns("BARCODE").HeaderText = "Barcode"
                    dgvProducts.Columns("SKU").HeaderText = "SKU"
                    dgvProducts.Columns("BRAND").HeaderText = "Brand"
                    dgvProducts.Columns("DESCRIPTIONS").HeaderText = "Product Description"
                    dgvProducts.Columns("CATEGORY").HeaderText = "Category"
                    dgvProducts.Columns("SIZE").HeaderText = "Size"
                    dgvProducts.Columns("PRICE").HeaderText = "Unit Price"
                    dgvProducts.Columns("UNIT").HeaderText = "Unit"
                    dgvProducts.Columns("AVAILABLE").HeaderText = "Stock Available"
                    dgvProducts.Columns("VENDOR_CODE").HeaderText = "Vendor Code"

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picLogo_DoubleClick(sender As Object, e As EventArgs) Handles picLogo.DoubleClick
        Dim OpenFile As New OpenFileDialog()
        OpenFile.Title = "Select New Image"
        OpenFile.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"

        If OpenFile.ShowDialog() = DialogResult.OK Then
            Try
                picLogo.Image = Image.FromFile(OpenFile.FileName)
                picLogo.SizeMode = PictureBoxSizeMode.StretchImage
                NewImageBytes = File.ReadAllBytes(OpenFile.FileName)
                MessageBox.Show("New image selected. Click Save to update.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Cannot open image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtBranch.Text) Then
            MessageBox.Show("Branch name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBranch.Focus()
            Exit Sub
        End If

        Try
            Dim Sql As String = "UPDATE dbo.Branches SET " &
                                 "ACCOUNT = @Account, " &
                                 "BRANCH = @Branch, " &
                                 "TIN = @TIN, " &
                                 "BUSINESS_TYPE = @BusType, " &
                                 "ADDRESS = @Address, " &
                                 "EMAIL = @Email, " &
                                 "CONTACT = @Contact, " &
                                 "MANAGER = @Manager"

            If NewImageBytes IsNot Nothing Then
                Sql &= ", BUSINESS_LOGO = @Logo"
            End If

            Sql &= " WHERE BRANCH_ID = @BranchID"

            Using Conn As New SqlConnection(ConnString)
                Using Cmd As New SqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@Account", txtAccount.Text.Trim())
                    Cmd.Parameters.AddWithValue("@Branch", txtBranch.Text.Trim())
                    Cmd.Parameters.AddWithValue("@TIN", txtTIN.Text.Trim())
                    Cmd.Parameters.AddWithValue("@BusType", cboBusType.Text.Trim())
                    Cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    Cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    Cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim())
                    Cmd.Parameters.AddWithValue("@Manager", cboManager.Text.Trim())
                    Cmd.Parameters.AddWithValue("@BranchID", SelectedBranchID)

                    If NewImageBytes IsNot Nothing Then
                        Cmd.Parameters.AddWithValue("@Logo", NewImageBytes)
                    End If

                    Conn.Open()
                    Dim Result As Integer = Cmd.ExecuteNonQuery()

                    If Result > 0 Then
                        MessageBox.Show("Branch information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        MessageBox.Show("No changes were saved. Please try again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class