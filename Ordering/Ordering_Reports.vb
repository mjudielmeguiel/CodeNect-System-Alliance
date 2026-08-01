Imports MySqlConnector

Public Class Ordering_Reports

    Private connStr As String = DBConnection.connStr

    Private Sub Ordering_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0)
        dtpTo.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)

        dgvHistory.ReadOnly = True
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.AllowUserToResizeRows = False
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        AddHandler dgvHistory.CellDoubleClick, AddressOf dgvHistory_CellDoubleClick

        LoadData()
        AuditLogger.LogAction("OPEN", "Reports", "Opened Ordering Reports / History")
    End Sub

    Sub LoadData()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sqlQuery As String = "SELECT 
                            `PO_NUMBER` AS `Document No`,
                            `DR` AS `DR Number`,
                            `FROM` AS `Vendor / Source`,
                            `PREPARED_BY` AS `Prepared By`,
                            `REQUEST_DATE` AS `Request Date`,
                            `TO` AS `To Branch`,
                            `RECEIVER` AS `Received By`,
                            `RECEIVE_DATE` AS `Receive Date`,
                            `STATUS`,
                            `TOTAL` AS `Amount`,
                            'Stock Ordering' AS `Transaction Type`
                         FROM `STO_DATA` 
                         WHERE `REQUEST_DATE` BETWEEN @DateStart AND @DateEnd
                         ORDER BY `PO_NUMBER` DESC"

                Using cmd As New MySqlCommand(sqlQuery, conn)
                    cmd.Parameters.AddWithValue("@DateStart", dtpFrom.Value)
                    cmd.Parameters.AddWithValue("@DateEnd", dtpTo.Value)

                    Dim dtResult As New DataTable()
                    Dim da As New MySqlDataAdapter(cmd)
                    da.Fill(dtResult)

                    dgvHistory.DataSource = dtResult
                End Using
            End Using

            FormatGrid()

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Reports", $"Failed to load ordering reports: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatGrid()
        For Each col As DataGridViewColumn In dgvHistory.Columns
            col.ReadOnly = True

            If col.Name.Equals("Amount", StringComparison.OrdinalIgnoreCase) Then
                col.DefaultCellStyle.Format = "N2"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            If col.Name.Contains("Date") Then
                col.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
                col.DefaultCellStyle.NullValue = ""
            End If
        Next

        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvHistory.Rows(e.RowIndex)
        Dim docNo As String = row.Cells("Document No").Value.ToString().Trim()

        Dim frmOrder As New frmSTO_Information()
        frmOrder.LoadOrderDetails(docNo)
        AuditLogger.LogAction("OPEN", "Reports", $"Opened Order Details from Reports | PO: {docNo}")
        frmOrder.ShowDialog()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
    End Sub

End Class