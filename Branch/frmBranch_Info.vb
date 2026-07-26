Imports System.IO
Imports MySqlConnector

Public Class frmBranch_Info

    Public SelectedBranchID As String

    Private Sub DashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(Login.LoggedInUserID) Then
            SetAccountOffline()
        End If
    End Sub

    Private Sub SetAccountOffline()
        If String.IsNullOrEmpty(Login.LoggedInUserID) Then Return

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmdText As String = "UPDATE `User_Accounts` SET `STATUS` = 'OFFLINE' WHERE `ID` = @UserID"

                Using cmd As New MySqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Branch_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranchDetails()
        LoadProductsForBranch()
    End Sub

    Private Sub LoadBranchDetails()
        Try
            ' ✅ Tugma sa table at column na `BUSINESS_LO` mo
            Dim Sql As String = "SELECT `ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `TIN`, `BUSINESS_TYPE`, `ADDRESS`, `EMAIL`, `CONTACT`, `MANAGER`, `BUSINESS_LO` " &
                                 "FROM `branches` " &
                                 "WHERE `BRANCH_ID` = @BranchID"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using Cmd As New MySqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@BranchID", SelectedBranchID)
                    Conn.Open()
                    Dim Dr As MySqlDataReader = Cmd.ExecuteReader()

                    If Dr.Read() Then
                        lblAccountID.Text = Dr("ACCOUNT_ID").ToString()
                        lblAccount.Text = Dr("ACCOUNT").ToString()
                        lblBranchID.Text = Dr("BRANCH_ID").ToString()
                        lblBranch.Text = Dr("BRANCH").ToString()
                        lblTIN.Text = Dr("TIN").ToString()
                        lblBusType.Text = If(Not IsDBNull(Dr("BUSINESS_TYPE")), Dr("BUSINESS_TYPE").ToString(), "")
                        lblAddress.Text = Dr("ADDRESS").ToString()
                        lblEmail.Text = Dr("EMAIL").ToString()
                        lblContact.Text = Dr("CONTACT").ToString()
                        lblManager.Text = If(Not IsDBNull(Dr("MANAGER")), Dr("MANAGER").ToString(), "")

                        If Not IsDBNull(Dr("BUSINESS_LO")) Then
                            Dim imgBytes As Byte() = CType(Dr("BUSINESS_LO"), Byte())
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

    Private Sub LoadProductsForBranch(Optional searchText As String = "")
        Try
            ' ✅ Kung ang table ay `Inventory_Master_file` sa MySQL, walang `inv.` schema
            Dim Sql As String = "SELECT " &
                                "`BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `CATEGORY`, `SIZE`, " &
                                "`PRICE`, `UNIT`, `AVAILABLE`, `VENDOR_CODE` " &
                                "FROM `Inventory_Master_file` " &
                                "WHERE `BRANCH_ID` = @BranchID"

            If Not String.IsNullOrWhiteSpace(searchText) Then
                Sql &= " AND (`BARCODE` LIKE CONCAT('%', @Search, '%') OR " &
                       "`SKU` LIKE CONCAT('%', @Search, '%') OR " &
                       "`BRAND` LIKE CONCAT('%', @Search, '%') OR " &
                       "`DESCRIPTIONS` LIKE CONCAT('%', @Search, '%'))"
            End If

            Sql &= " ORDER BY `DESCRIPTIONS` ASC"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using Cmd As New MySqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@BranchID", SelectedBranchID)
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        Cmd.Parameters.AddWithValue("@Search", searchText)
                    End If

                    Dim Da As New MySqlDataAdapter(Cmd)
                    Dim Dt As New DataTable()
                    Da.Fill(Dt)

                    dgvProducts.DataSource = Dt

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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadProductsForBranch(txtSearch.Text.Trim())
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class