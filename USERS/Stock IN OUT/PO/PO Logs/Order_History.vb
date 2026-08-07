Imports MySqlConnector
Imports System.Drawing

Public Class Order_History
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private ReadOnly currentUser As String = DBConnection.CurrentLoggedInUser?.Trim()
    Private ReadOnly currentBranchID As String = If(Login.LoggedInBranchID IsNot Nothing, Login.LoggedInBranchID.Trim(), "")

    Private Sub Order_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridViewColumns()

        dtpFrom.Value = New DateTime(2020, 1, 1)
        dtpTo.Value = DateTime.Now.Date

        If String.IsNullOrWhiteSpace(currentUser) Then
            MessageBox.Show("Missing User info. Please login again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(currentBranchID) Then
            MessageBox.Show("Missing Branch info. Please login again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadHistoryData()
    End Sub

    Private Sub SetupDataGridViewColumns()
        dgvHistory.Columns.Clear()
        dgvHistory.ReadOnly = True
        dgvHistory.AutoGenerateColumns = False

        dgvHistory.Columns.Add("PO_NUMBER", "PO Number")
        dgvHistory.Columns.Add("REQUEST_DATE", "Order Date")
        dgvHistory.Columns.Add("VENDOR_CODE", "Vendor Code")
        dgvHistory.Columns.Add("VENDOR_NAME", "Vendor Name")
        dgvHistory.Columns.Add("STATUS", "Status")
        dgvHistory.Columns.Add("DR", "DR Number")
        dgvHistory.Columns.Add("PREPARED_BY", "Prepared By")
        dgvHistory.Columns.Add("RECEIVER", "Received By")
        dgvHistory.Columns.Add("RECEIVE_DATE", "Received Date")
        dgvHistory.Columns.Add("TRANSACTION_TYPE", "Type")
        dgvHistory.Columns.Add("TOTAL", "Total Amount")

        For Each col As DataGridViewColumn In dgvHistory.Columns
            col.ReadOnly = True
        Next
    End Sub

    Private Sub LoadHistoryData()
        dgvHistory.Rows.Clear()

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' ✅ RECEIVED at CANCELLED LANG — HINDI ISASAMA ANG PENDING
                Dim cmd As New MySqlCommand("
                    SELECT PO_NUMBER, REQUEST_DATE, VENDOR_CODE, VENDOR_NAME, STATUS, 
                           DR, PREPARED_BY, RECEIVER, RECEIVE_DATE, TRANSACTION_TYPE, TOTAL
                    FROM sto_data
                    WHERE PREPARED_BY = @CurrentUser
                      AND UPPER(STATUS) IN ('RECEIVED', 'CANCELLED')
                      AND DATE(REQUEST_DATE) BETWEEN @dtpFrom AND @dtpTo
                    ORDER BY REQUEST_DATE DESC", conn)

                cmd.Parameters.AddWithValue("@CurrentUser", currentUser)
                cmd.Parameters.AddWithValue("@dtpFrom", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@dtpTo", dtpTo.Value.Date)

                ' ⚠️ Kung may Branch ID filter — alisin ang ' sa ibaba:
                ' cmd.CommandText = cmd.CommandText.Replace("WHERE PREPARED_BY", "WHERE BRANCH_ID = @BranchID AND PREPARED_BY")
                ' cmd.Parameters.AddWithValue("@BranchID", currentBranchID)

                Using dr = cmd.ExecuteReader()
                    If Not dr.HasRows Then
                        MessageBox.Show("Walang nakitang RECEIVED o CANCELLED na transaction sa napiling petsa.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    While dr.Read()
                        Dim poNum As String = GetStringSafe(dr, "PO_NUMBER")
                        Dim reqDate As String = GetDateSafe(dr, "REQUEST_DATE")
                        Dim venCode As String = GetStringSafe(dr, "VENDOR_CODE")
                        Dim venName As String = GetStringSafe(dr, "VENDOR_NAME")
                        Dim status As String = GetStringSafe(dr, "STATUS").ToUpper()
                        Dim drNum As String = GetStringSafe(dr, "DR")
                        Dim prepBy As String = GetStringSafe(dr, "PREPARED_BY")
                        Dim receiver As String = GetStringSafe(dr, "RECEIVER")
                        Dim recDate As String = GetDateSafe(dr, "RECEIVE_DATE")
                        Dim transType As String = GetStringSafe(dr, "TRANSACTION_TYPE")
                        Dim totalAmt As String = GetDecimalSafe(dr, "TOTAL")

                        Dim rowIndex = dgvHistory.Rows.Add(poNum, reqDate, venCode, venName, status, drNum, prepBy, receiver, recDate, transType, totalAmt)

                        ' ✅ Kulay ayon sa Status
                        Dim statusCell = dgvHistory.Rows(rowIndex).Cells("STATUS")
                        Select Case status
                            Case "RECEIVED"
                                statusCell.Style.BackColor = Color.Green
                                statusCell.Style.ForeColor = Color.White
                            Case "CANCELLED"
                                statusCell.Style.BackColor = Color.Red
                                statusCell.Style.ForeColor = Color.White
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error Loading History", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ DOUBLE CLICK — BUBUKSAN ANG MGA PRODUKTO NG PO NA ITO
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim poNumber As String = dgvHistory.Rows(e.RowIndex).Cells("PO_NUMBER").Value?.ToString()

        If String.IsNullOrWhiteSpace(poNumber) Then
            MessageBox.Show("PO Number not found!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim frmItems As New frmTransaction_Items()
            frmItems.SelectedPONumber = poNumber
            frmItems.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadHistoryData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadHistoryData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadHistoryData()
        MessageBox.Show("History refreshed successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function GetStringSafe(dr As MySqlDataReader, colName As String) As String
        If dr.IsDBNull(dr.GetOrdinal(colName)) Then Return "-"
        Return dr(colName).ToString().Trim()
    End Function

    Private Function GetDateSafe(dr As MySqlDataReader, colName As String) As String
        If dr.IsDBNull(dr.GetOrdinal(colName)) Then Return "-"
        Return Convert.ToDateTime(dr(colName)).ToString("yyyy-MM-dd HH:mm")
    End Function

    Private Function GetDecimalSafe(dr As MySqlDataReader, colName As String) As String
        If dr.IsDBNull(dr.GetOrdinal(colName)) Then Return "0.00"
        Return Convert.ToDecimal(dr(colName)).ToString("N2")
    End Function
End Class