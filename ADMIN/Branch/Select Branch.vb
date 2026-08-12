Imports System.Data
Imports System.Text
Imports MySqlConnector

Public Class Select_Branch

    ' ✅ Properties — sapat na para sa Branch Name
    Public Property AccountID As String
    Public Property AccountName As String
    Public Property BranchID As String
    Public Property BranchName As String
    Public Property TIN As String
    Public Property BusinessType As String
    Public Property Address As String
    Public Property Email As String
    Public Property Contact As String
    Public Property Manager As String
    Public Property Sales As String

    Private connStr As String = DBConnection.connStr
    Private adminAccountID As String = Login.LoggedInAccountID

    Private Sub Select_Branch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadAvailableBranches()
    End Sub

    ' ✅ Grid — WALANG Account ID, WALANG Account Name
    Private Sub SetupDataGridView()
        dgvBranches.Columns.Clear()

        Dim btnCol As New DataGridViewButtonColumn()
        btnCol.Name = "ACTION"
        btnCol.HeaderText = "Action"
        btnCol.Text = "Select"
        btnCol.UseColumnTextForButtonValue = True
        btnCol.Width = 80
        dgvBranches.Columns.Add(btnCol)

        ' ✅ Ipinapakita na lang
        dgvBranches.Columns.Add("BRANCH_ID", "Branch ID")
        dgvBranches.Columns.Add("BRANCH", "Branch Name")
        dgvBranches.Columns.Add("TIN", "TIN")
        dgvBranches.Columns.Add("BUSINESS_TYPE", "Business Type")
        dgvBranches.Columns.Add("ADDRESS", "Address")
        dgvBranches.Columns.Add("EMAIL", "Email")
        dgvBranches.Columns.Add("CONTACT", "Contact")
        dgvBranches.Columns.Add("MANAGER", "Manager")
        dgvBranches.Columns.Add("SALES", "Sales")

        ' ✅ Lapad ng Column
        dgvBranches.Columns("BRANCH_ID").Width = 110
        dgvBranches.Columns("BRANCH").Width = 160
        dgvBranches.Columns("TIN").Width = 110
        dgvBranches.Columns("BUSINESS_TYPE").Width = 120
        dgvBranches.Columns("ADDRESS").Width = 240
        dgvBranches.Columns("EMAIL").Width = 150
        dgvBranches.Columns("CONTACT").Width = 100
        dgvBranches.Columns("MANAGER").Width = 130
        dgvBranches.Columns("SALES").Width = 90

        dgvBranches.RowHeadersVisible = False
    End Sub

    Private Sub LoadAvailableBranches(Optional searchKeyword As String = "")
        dgvBranches.Rows.Clear()

        Try
            Dim sql As New StringBuilder()

            ' ✅ Lahat ng Branch — WALANG Photo, Status, Reg Date
            sql.AppendLine("SELECT b.`ACCOUNT_ID`, b.`ACCOUNT`, b.`BRANCH_ID`, b.`BRANCH`, b.`TIN`, b.`BUSINESS_TYPE`, b.`ADDRESS`, b.`EMAIL`, b.`CONTACT`, b.`MANAGER`, b.`SALES`")
            sql.AppendLine("FROM `branches` b")

            Dim cmd As New MySqlCommand()

            If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                cmd.Parameters.AddWithValue("@Search", "%" & searchKeyword & "%")
                sql.AppendLine(" WHERE (")
                sql.AppendLine("    b.`BRANCH` LIKE @Search")
                sql.AppendLine(" OR b.`ACCOUNT` LIKE @Search")
                sql.AppendLine(" OR b.`MANAGER` LIKE @Search")
                sql.AppendLine(" OR b.`ADDRESS` LIKE @Search")
                sql.AppendLine(" OR b.`ACCOUNT_ID` LIKE @Search")
                sql.AppendLine(" OR b.`BRANCH_ID` LIKE @Search")
                sql.AppendLine(")")
            End If

            sql.AppendLine(" ORDER BY b.`ACCOUNT`, b.`BRANCH` ASC")

            Using conn As New MySqlConnection(connStr)
                cmd.Connection = conn
                cmd.CommandText = sql.ToString()
                conn.Open()

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim accID As String = If(IsDBNull(dr("ACCOUNT_ID")), "", dr("ACCOUNT_ID").ToString().Trim())
                        Dim accName As String = If(IsDBNull(dr("ACCOUNT")), "", dr("ACCOUNT").ToString().Trim())
                        Dim brID As String = If(IsDBNull(dr("BRANCH_ID")), "", dr("BRANCH_ID").ToString().Trim())
                        Dim brName As String = If(IsDBNull(dr("BRANCH")), "", dr("BRANCH").ToString().Trim())
                        Dim tin As String = If(IsDBNull(dr("TIN")), "", dr("TIN").ToString().Trim())
                        Dim busType As String = If(IsDBNull(dr("BUSINESS_TYPE")), "", dr("BUSINESS_TYPE").ToString().Trim())
                        Dim addr As String = If(IsDBNull(dr("ADDRESS")), "", dr("ADDRESS").ToString().Trim())
                        Dim email As String = If(IsDBNull(dr("EMAIL")), "", dr("EMAIL").ToString().Trim())
                        Dim contact As String = If(IsDBNull(dr("CONTACT")), "", dr("CONTACT").ToString().Trim())
                        Dim mgr As String = If(IsDBNull(dr("MANAGER")), "", dr("MANAGER").ToString().Trim())
                        Dim sales As String = If(IsDBNull(dr("SALES")), "", dr("SALES").ToString().Trim())

                        ' ✅ IPASOK SA GRID
                        Dim rowIdx As Integer = dgvBranches.Rows.Add(
                            "Select",   ' Action Button
                            brID,       ' Branch ID
                            brName,     ' Branch Name
                            tin,        ' TIN
                            busType,    ' Business Type
                            addr,       ' Address
                            email,      ' Email
                            contact,    ' Contact
                            mgr,        ' Manager
                            sales       ' Sales
                        )

                        ' ✅ I-STORE — kailangan lang ang Branch Name
                        dgvBranches.Rows(rowIdx).Tag = New Select_Branch With {
                            .AccountID = accID,
                            .AccountName = accName,
                            .BranchID = brID,
                            .BranchName = brName,
                            .TIN = tin,
                            .BusinessType = busType,
                            .Address = addr,
                            .Email = email,
                            .Contact = contact,
                            .Manager = mgr,
                            .Sales = sales
                        }
                    End While
                End Using
            End Using

            If dgvBranches.Rows.Count = 0 Then
                MessageBox.Show("No branches found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ PININDAOT ANG SELECT BUTTON — PUPUNAN LANG ANG BRANCH NAME SA ADD_BRANCH
    Private Sub dgvBranches_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBranches.CellContentClick
        If e.RowIndex < 0 OrElse e.ColumnIndex <> 0 Then Exit Sub

        Try
            Dim r As DataGridViewRow = dgvBranches.Rows(e.RowIndex)
            Dim brInfo As Select_Branch = TryCast(r.Tag, Select_Branch)
            If brInfo Is Nothing Then
                MessageBox.Show("⚠️ Branch information missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ Hanapin ang ADD_Branch form — pupunan lang ang Branch Name
            Dim frm As ADD_Branch = Application.OpenForms.OfType(Of ADD_Branch)().FirstOrDefault()
            If frm Is Nothing Then
                MessageBox.Show("❌ Buksan muna ang **Add New Branch** form bago pumili ng branch.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ BRANCH NAME LANG ANG ILALAGAY — iba mananatiling blangko
            frm.FillBranchName(brInfo.BranchName)

            AuditLogger.LogAction("SELECT", "Branch Management", $"Selected branch name: {brInfo.BranchName}")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAvailableBranches(txtSearch.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadAvailableBranches()
    End Sub

End Class