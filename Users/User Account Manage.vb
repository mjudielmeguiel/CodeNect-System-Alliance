Imports System.Data
Imports System.Data.SqlClient

Public Class User_Account_Manage

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
        cboUserType.Items.AddRange({
            "ALL", "Branch Administrator", "IT Support", "Branch Manager",
            "Supervisor", "Cashier", "Inventory Clerk", "Sales Staff", "Viewer"
        })
        cboUserType.SelectedIndex = 0
    End Sub

    Public Sub LoadData()
        Dim filterType As String = cboUserType.SelectedItem.ToString()
        Dim searchText As String = txtSearch.Text.Trim()
        dgvUsers.Rows.Clear()

        Try
            Dim sql As String = "
                SELECT 
                    u.ID, u.FULL_NAME, u.USER_TYPE, u.BRANCH_ID, 
                    b.BRANCH AS BRANCH_NAME, u.EMAIL, u.CONTACT, u.STATUS, 
                    u.DATE_CREATED, u.PROFILE
                FROM User_Accounts u
                LEFT JOIN Branches b ON u.BRANCH_ID = b.BRANCH_ID
                WHERE 1=1"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, conn)

                    ' Filter based on logged-in user's role
                    If Login.LoggedInUserType.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) Then
                        cmd.Parameters.Add("@AccID", SqlDbType.NVarChar, 50).Value = Login.LoggedInAccountID
                        sql &= " AND u.ACCOUNT_ID = @AccID"
                    Else
                        cmd.Parameters.Add("@BranchID", SqlDbType.NVarChar, 20).Value = Login.LoggedInBranchID
                        sql &= " AND u.BRANCH_ID = @BranchID AND u.USER_TYPE <> 'ADMIN'"
                    End If

                    ' Filter by user type if not "ALL"
                    If filterType <> "ALL" Then
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = filterType
                        sql &= " AND u.USER_TYPE = @Type"
                    End If

                    ' Filter by search text
                    If Not String.IsNullOrEmpty(searchText) Then
                        cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 150).Value = "%" & searchText & "%"
                        sql &= " AND u.FULL_NAME LIKE @Search"
                    End If

                    sql &= " ORDER BY u.DATE_CREATED DESC"
                    cmd.CommandText = sql

                    conn.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim userID As Integer = CInt(dr("ID"))
                            Dim fullName As String = dr("FULL_NAME").ToString().Trim()
                            Dim userType As String = If(IsDBNull(dr("USER_TYPE")), "", dr("USER_TYPE").ToString().Trim())
                            Dim branchName As String = If(IsDBNull(dr("BRANCH_NAME")), "", dr("BRANCH_NAME").ToString().Trim())
                            Dim branchID As String = If(IsDBNull(dr("BRANCH_ID")), "", dr("BRANCH_ID").ToString().Trim())
                            Dim email As String = If(IsDBNull(dr("EMAIL")), "", dr("EMAIL").ToString().Trim())
                            Dim contact As String = If(IsDBNull(dr("CONTACT")), "", dr("CONTACT").ToString().Trim())
                            Dim status As String = If(IsDBNull(dr("STATUS")), "", dr("STATUS").ToString().Trim())
                            Dim dateCreated As DateTime = Convert.ToDateTime(dr("DATE_CREATED"))
                            Dim profileBytes As Byte() = If(IsDBNull(dr("PROFILE")), Nothing, CType(dr("PROFILE"), Byte()))

                            ' Add row to grid
                            Dim rowIndex As Integer = dgvUsers.Rows.Add(
                                fullName,
                                userType,
                                branchName,
                                email,
                                contact,
                                status,
                                dateCreated.ToString("yyyy-MM-dd")
                            )

                            ' Store complete user data in Tag for Edit_User
                            dgvUsers.Rows(rowIndex).Cells(0).Tag = New With {
                                .ID = userID,
                                .FULL_NAME = fullName,
                                .USER_TYPE = userType,
                                .BRANCH = branchName,
                                .BRANCH_ID = branchID,
                                .EMAIL = email,
                                .CONTACT = contact,
                                .STATUS = status,
                                .PROFILE = profileBytes
                            }
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellDoubleClick
        If e.RowIndex < 0 Then Return

        Dim selectedTag = dgvUsers.Rows(e.RowIndex).Cells(0).Tag
        If selectedTag IsNot Nothing Then
            Dim editForm As New Edit_User()
            editForm.LoadUserDetails(selectedTag)
            editForm.ShowDialog()
            LoadData() ' Refresh list after closing edit form
        End If
    End Sub

    Private Sub cboUserType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUserType.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadData()
    End Sub

End Class