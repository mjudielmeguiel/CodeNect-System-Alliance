Imports System.Data.SqlClient

Public Class User_Account_Manage

    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS;Initial Catalog=CodeNectDB;User ID=sa;Password=Password1*;Connect Timeout=15"

    Private Sub User_Account_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupColumns()
        SetupComboBox()
        LoadData()
    End Sub

    Private Sub SetupColumns()
        dgvUsers.Columns.Clear()
        dgvUsers.Columns.Add("FULL_NAME", "FULL NAME")
        dgvUsers.Columns.Add("USER_TYPE", "USER TYPE")
        dgvUsers.Columns.Add("BRANCH_NAME", "BRANCH NAME")
        dgvUsers.Columns.Add("EMAIL", "EMAIL")
        dgvUsers.Columns.Add("CONTACT", "CONTACT")
        dgvUsers.Columns.Add("STATUS", "STATUS")
        dgvUsers.Columns.Add("DATE_CREATED", "DATE CREATED")
    End Sub

    Private Sub SetupComboBox()
        cboUserType.Items.Clear()
        cboUserType.Items.Add("ALL")
        cboUserType.Items.Add("Administrator")
        cboUserType.Items.Add("IT")
        cboUserType.Items.Add("Manager")
        cboUserType.Items.Add("Cashier")
        cboUserType.Items.Add("Inventory Clerk")
        cboUserType.Items.Add("Sales Staff")
        cboUserType.Items.Add("Viewer")
        cboUserType.SelectedIndex = 0
    End Sub

    Public Sub LoadData()
        Dim filterType As String = cboUserType.SelectedItem.ToString()
        Dim searchText As String = txtSearch.Text.Trim()
        dgvUsers.Rows.Clear()

        Try
            Using conn As New SqlConnection(ConnString)
                ' ✅ DINAGDAG KO ANG u.PROFILE DITO PARA SA PICTURE
                Dim sql As String = "SELECT u.ID, u.FULL_NAME, u.USER_TYPE, u.BRANCH_ID, b.BRANCH AS BRANCH_NAME, u.EMAIL, u.CONTACT, u.STATUS, u.DATE_CREATED, u.PROFILE " &
                                    "FROM User_Accounts u " &
                                    "LEFT JOIN Branches b ON u.BRANCH_ID = b.BRANCH_ID " &
                                    "WHERE 1=1 "

                If Login.LoggedInUserType = "ADMIN" Then
                    sql &= " AND u.ACCOUNT_ID = @AccID "
                Else
                    sql &= " AND u.BRANCH_ID = @BranchID "
                    sql &= " AND u.USER_TYPE <> 'ADMIN' "
                End If

                If filterType <> "ALL" Then
                    sql &= " AND u.USER_TYPE = @Type "
                End If

                If searchText <> "" Then
                    sql &= " AND u.FULL_NAME LIKE @Search "
                End If

                sql &= " ORDER BY u.DATE_CREATED DESC"

                Using cmd As New SqlCommand(sql, conn)
                    If Login.LoggedInUserType = "ADMIN" Then
                        cmd.Parameters.AddWithValue("@AccID", Login.LoggedInAccountID)
                    Else
                        cmd.Parameters.AddWithValue("@BranchID", Login.LoggedInBranchID)
                    End If

                    If filterType <> "ALL" Then
                        cmd.Parameters.AddWithValue("@Type", filterType)
                    End If
                    If searchText <> "" Then
                        cmd.Parameters.AddWithValue("@Search", "%" & searchText & "%")
                    End If

                    conn.Open()
                    Dim dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        Dim userID As Integer = CInt(dr("ID"))
                        Dim branchName As String = If(IsDBNull(dr("BRANCH_NAME")), "", dr("BRANCH_NAME").ToString())
                        Dim branchCode As String = If(IsDBNull(dr("BRANCH_ID")), "", dr("BRANCH_ID").ToString())
                        Dim userType As String = If(IsDBNull(dr("USER_TYPE")), "", dr("USER_TYPE").ToString())
                        Dim profilePath As String = If(IsDBNull(dr("PROFILE")), "", dr("PROFILE").ToString()) ' ✅ PICTURE PATH

                        Dim row As String() = {
                            dr("FULL_NAME").ToString(),
                            userType,
                            branchName,
                            dr("EMAIL").ToString(),
                            dr("CONTACT").ToString(),
                            dr("STATUS").ToString(),
                            Convert.ToDateTime(dr("DATE_CREATED")).ToString("yyyy-MM-dd")
                        }

                        ' ✅ TAMA NA PANGALAN NG VARIABLES, TUGMA SA EDIT_USER
                        dgvUsers.Rows.Add(row)
                        dgvUsers.Rows(dgvUsers.Rows.Count - 1).Cells(0).Tag = New With {
                            .ID = userID,
                            .FULL_NAME = dr("FULL_NAME").ToString(),   ' <-- DATI FULLNAME, NGAYON FULL_NAME
                            .USER_TYPE = userType,                      ' <-- DATI USERTYPE, NGAYON USER_TYPE
                            .BRANCH = branchName,                       ' <-- DATI BRANCH_NAME, NGAYON BRANCH
                            .BRANCH_ID = branchCode,                    ' <-- DATI BRANCH_CODE, NGAYON BRANCH_ID
                            .EMAIL = dr("EMAIL").ToString(),
                            .CONTACT = dr("CONTACT").ToString(),
                            .STATUS = dr("STATUS").ToString(),
                            .PROFILE = profilePath                       ' <-- PICTURE PATH
                        }
                    End While
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim userInfo = CType(dgvUsers.Rows(e.RowIndex).Cells(0).Tag, Object)
            Edit_User.LoadUserDetails(userInfo)
            Edit_User.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub cboUserType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUserType.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadData()
    End Sub

End Class