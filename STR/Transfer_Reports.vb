Imports System.Data
Imports MySqlConnector

Public Class Transfer_Reports
    Private connStr As String = DBConnection.connStr

    Private Sub Transfer_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0)
        dtpTo.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)
        dgvHistory.ReadOnly = True
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AddHandler dgvHistory.CellDoubleClick, AddressOf dgvHistory_CellDoubleClick
        LoadData()
        AuditLogger.LogAction("OPEN_TRANSFER_RPT", "TransferReports", "Opened Stock Transfer Reports")
    End Sub

    Sub LoadData()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT `STR_NUMBER` AS `Document No`, `DR`, `FROM_MV`, `PREPARED_BY`, `REQUEST_DATE`, `TO_MV`, `RECEIVER`, `RECEIVE_DATE`, `STATUS`, `TOTAL` " &
                                    "FROM `STR_DATA` WHERE `REQUEST_DATE` BETWEEN @d1 AND @d2 ORDER BY `STR_NUMBER` DESC"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@d1", dtpFrom.Value)
                    cmd.Parameters.AddWithValue("@d2", dtpTo.Value)
                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    dgvHistory.DataSource = dt
                    AuditLogger.LogAction("TRANSFER_LOADED", "TransferReports", $"Loaded {dt.Rows.Count} transfer records | From: {dtpFrom.Value:yyyy-MM-dd} To: {dtpTo.Value:yyyy-MM-dd}")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Load error: " & ex.Message)
            AuditLogger.LogAction("ERROR", "TransferReports", $"Load failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        Dim no As String = dgvHistory.Rows(e.RowIndex).Cells("Document No").Value.ToString().Trim()
        AuditLogger.LogAction("VIEW_TRANSFER", "TransferReports", $"Viewing transfer details | No: {no}")
        Dim frm As New frmSTR_Information()
        frm.LoadTransferDetails(no)
        frm.ShowDialog()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
        AuditLogger.LogAction("FILTER_DATE_FROM", "TransferReports", $"Date filter changed | From: {dtpFrom.Value:yyyy-MM-dd}")
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
        AuditLogger.LogAction("FILTER_DATE_TO", "TransferReports", $"Date filter changed | To: {dtpTo.Value:yyyy-MM-dd}")
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub
End Class