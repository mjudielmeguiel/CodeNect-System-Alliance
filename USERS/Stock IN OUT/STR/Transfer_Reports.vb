Imports System.Data
Imports MySqlConnector

Public Class Transfer_Reports
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private selectedSTRNumber As String = Nothing
    Private userAccountID As String = Nothing
    Private userBranchID As String = Nothing
    Private isAdmin As Boolean = False

    Private Sub Transfer_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New DateTime(2020, 1, 1)
        dtpTo.Value = DateTime.Now.Date

        lblStatus.Text = "Status: -"
        lblStatus.ForeColor = Color.Black
        lblPONumber.Text = "STR Number: -"
        lblVendorCode.Text = "From Branch: -"
        lblVendor.Text = "To Branch: -"

        dgvReports.ReadOnly = False
        dgvReports.AutoGenerateColumns = False
        dgvReports.Columns.Clear()

        dgvReports.Columns.Add("STR_NUMBER", "STR Number")
        dgvReports.Columns.Add("TRANSFER_DATE", "Transfer Date")
        dgvReports.Columns.Add("STATUS", "Status")
        dgvReports.Columns.Add("DR_NUMBER", "DR Number")
        dgvReports.Columns.Add("PREPARED_BY", "Prepared By")
        dgvReports.Columns.Add("APPROVED_BY", "Approved By")
        dgvReports.Columns.Add("TOTAL_AMOUNT", "Total Amount")
        dgvReports.Columns.Add("FROM_BRANCH", "From Branch")
        dgvReports.Columns.Add("TO_BRANCH", "To Branch")

        For Each col As DataGridViewColumn In dgvReports.Columns
            col.ReadOnly = True
        Next
        dgvReports.Columns("DR_NUMBER").ReadOnly = False

        Dim btnReceive As New DataGridViewButtonColumn()
        btnReceive.Name = "colReceive"
        btnReceive.Text = "Receive"
        btnReceive.UseColumnTextForButtonValue = True
        dgvReports.Columns.Add(btnReceive)

        Dim btnCancel As New DataGridViewButtonColumn()
        btnCancel.Name = "colCancel"
        btnCancel.Text = "Cancel"
        btnCancel.UseColumnTextForButtonValue = True
        dgvReports.Columns.Add(btnCancel)

        Dim btnView As New DataGridViewButtonColumn()
        btnView.Name = "colView"
        btnView.Text = "View"
        btnView.UseColumnTextForButtonValue = True
        dgvReports.Columns.Add(btnView)

        GetUserAccessScope()
        LoadReportData()
    End Sub

    Private Sub GetUserAccessScope()
        ' Use pre-saved values from Login first – no extra query needed
        If Not String.IsNullOrWhiteSpace(Login.LoggedInAccountID) AndAlso
           Not String.IsNullOrWhiteSpace(Login.LoggedInUsername) Then

            userAccountID = Login.LoggedInAccountID.Trim()
            userBranchID = Login.LoggedInBranchID.Trim()
            isAdmin = (Login.LoggedInUserType.Trim.ToUpper() = "BUSINESS ADMIN")
            Exit Sub
        End If

        ' Fallback: only if pre-saved values are missing
        Dim currentUser = Login.LoggedInUsername?.Trim()
        If String.IsNullOrWhiteSpace(currentUser) Then
            MessageBox.Show("No logged-in user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("
                SELECT account_id, branch_id, user_type 
                FROM user_accounts 
                WHERE username = @USER", conn)

            cmd.Parameters.AddWithValue("@USER", currentUser)

            Using dr = cmd.ExecuteReader()
                If dr.Read() Then
                    userAccountID = dr("account_id")?.ToString().Trim()
                    userBranchID = dr("branch_id")?.ToString().Trim()
                    isAdmin = (dr("user_type")?.ToString().Trim().ToUpper() = "BUSINESS ADMIN")
                Else
                    MessageBox.Show("User account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            End Using
        End Using
    End Sub

    Private Sub LoadReportData()
        dgvReports.Rows.Clear()

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim sql As String = ""

            If isAdmin Then
                ' ✅ BUSINESS ADMIN: ALL transfers under their Account ID (all branches)
                sql = "
                    SELECT STR_NUMBER, TRANSFER_DATE, STATUS, DR_NUMBER, PREPARED_BY, APPROVED_BY, TOTAL_AMOUNT, FROM_BRANCH, TO_BRANCH
                    FROM transfer_data
                    WHERE ACCOUNT_ID = @ACCOUNTID
                      AND TRANSFER_DATE BETWEEN @FROMDATE AND @TODATE
                    ORDER BY TRANSFER_DATE DESC"
            Else
                ' ✅ Regular User: only transfers involving their branch
                sql = "
                    SELECT STR_NUMBER, TRANSFER_DATE, STATUS, DR_NUMBER, PREPARED_BY, APPROVED_BY, TOTAL_AMOUNT, FROM_BRANCH, TO_BRANCH
                    FROM transfer_data
                    WHERE ACCOUNT_ID = @ACCOUNTID
                      AND (FROM_BRANCH_ID = @BRANCHID OR TO_BRANCH_ID = @BRANCHID)
                      AND TRANSFER_DATE BETWEEN @FROMDATE AND @TODATE
                    ORDER BY TRANSFER_DATE DESC"
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ACCOUNTID", userAccountID)
            cmd.Parameters.AddWithValue("@FROMDATE", dtpFrom.Value.Date)
            cmd.Parameters.AddWithValue("@TODATE", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
            If Not isAdmin Then
                cmd.Parameters.AddWithValue("@BRANCHID", userBranchID)
            End If

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    dgvReports.Rows.Add(
                        dr("STR_NUMBER").ToString(),
                        Convert.ToDateTime(dr("TRANSFER_DATE")).ToString("yyyy-MM-dd"),
                        dr("STATUS").ToString(),
                        If(dr.IsDBNull("DR_NUMBER"), "", dr("DR_NUMBER").ToString()),
                        dr("PREPARED_BY").ToString(),
                        If(dr.IsDBNull("APPROVED_BY"), "", dr("APPROVED_BY").ToString()),
                        Convert.ToDecimal(dr("TOTAL_AMOUNT")).ToString("N2"),
                        dr("FROM_BRANCH").ToString(),
                        dr("TO_BRANCH").ToString()
                    )
                End While
            End Using
        End Using
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadReportData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadReportData()
    End Sub

    Private Sub dgvReports_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReports.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim statusCell = dgvReports.Rows(e.RowIndex).Cells("STATUS")
        If statusCell.Value Is Nothing Then Return

        Dim status = statusCell.Value.ToString().Trim().ToUpper()

        If status = "RECEIVED" OrElse status = "CANCELLED" Then
            If dgvReports.Columns(e.ColumnIndex).Name = "colReceive" OrElse dgvReports.Columns(e.ColumnIndex).Name = "colCancel" Then
                dgvReports.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
                e.CellStyle.BackColor = Color.LightGray
                e.CellStyle.ForeColor = Color.Gray
            End If
        End If
    End Sub

    Private Sub dgvReports_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReports.CellClick
        If e.RowIndex < 0 OrElse TypeOf dgvReports.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then Exit Sub

        selectedSTRNumber = dgvReports.Rows(e.RowIndex).Cells("STR_NUMBER").Value?.ToString()
        Dim currentStatus = dgvReports.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()

        lblPONumber.Text = $"STR Number: {selectedSTRNumber}"
        lblStatus.Text = $"Status: {currentStatus}"

        Select Case currentStatus.ToUpper()
            Case "RECEIVED"
                lblStatus.ForeColor = Color.Green
            Case "CANCELLED"
                lblStatus.ForeColor = Color.Red
            Case "PENDING"
                lblStatus.ForeColor = Color.Orange
            Case Else
                lblStatus.ForeColor = Color.Black
        End Select

        lblVendorCode.Text = $"From Branch: {dgvReports.Rows(e.RowIndex).Cells("FROM_BRANCH").Value?.ToString()}"
        lblVendor.Text = $"To Branch: {dgvReports.Rows(e.RowIndex).Cells("TO_BRANCH").Value?.ToString()}"
    End Sub

    Private Sub dgvReports_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReports.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Dim strNum = dgvReports.Rows(e.RowIndex).Cells("STR_NUMBER").Value?.ToString()
        Dim drValue = dgvReports.Rows(e.RowIndex).Cells("DR_NUMBER").Value?.ToString()
        Dim status = dgvReports.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()

        If e.ColumnIndex = dgvReports.Columns("colView").Index Then
            Dim frmItems As New frmStock_Items()
            frmItems.SelectedPONumber = strNum
            frmItems.ShowDialog()
            Exit Sub
        End If

        If e.ColumnIndex = dgvReports.Columns("colReceive").Index Then
            If status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("This transfer is already Received.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If String.IsNullOrWhiteSpace(drValue) Then
                MessageBox.Show("Please enter DR Number first.", "Missing DR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvReports.CurrentCell = dgvReports.Rows(e.RowIndex).Cells("DR_NUMBER")
                Return
            End If

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmdUpd As New MySqlCommand("
                    UPDATE transfer_data
                    SET STATUS = 'RECEIVED', DR_NUMBER = @DR
                    WHERE STR_NUMBER = @STRNUM
                      AND ACCOUNT_ID = @ACCT
                      AND (FROM_BRANCH_ID = @BR OR TO_BRANCH_ID = @BR)", conn)

                cmdUpd.Parameters.AddWithValue("@DR", drValue)
                cmdUpd.Parameters.AddWithValue("@STRNUM", strNum)
                cmdUpd.Parameters.AddWithValue("@ACCT", userAccountID)
                cmdUpd.Parameters.AddWithValue("@BR", userBranchID)
                cmdUpd.ExecuteNonQuery()
            End Using

            MessageBox.Show($"Transfer Received!{vbCrLf}DR: {drValue}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadReportData()
        End If

        If e.ColumnIndex = dgvReports.Columns("colCancel").Index Then
            If status.Equals("CANCELLED", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Cannot cancel this transfer.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If MessageBox.Show("Cancel this transfer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    UPDATE transfer_data 
                    SET STATUS = 'CANCELLED' 
                    WHERE STR_NUMBER = @STRNUM
                      AND ACCOUNT_ID = @ACCT
                      AND (FROM_BRANCH_ID = @BR OR TO_BRANCH_ID = @BR)", conn)

                cmd.Parameters.AddWithValue("@STRNUM", strNum)
                cmd.Parameters.AddWithValue("@ACCT", userAccountID)
                cmd.Parameters.AddWithValue("@BR", userBranchID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Transfer Cancelled.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadReportData()
        End If
    End Sub
End Class