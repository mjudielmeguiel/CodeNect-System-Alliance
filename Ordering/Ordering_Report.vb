Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Ordering_Report

    Private connStr As String = DBConnection.connStr

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set date range to full day by default
        dtpFrom.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0)
        dtpTo.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)

        LoadData()
    End Sub

    Sub LoadData()
        Try
            Dim selectedBranch As String = DashBoard.ToolStripStatusLabel4.Text.Trim()

            If String.IsNullOrEmpty(selectedBranch) Then
                MessageBox.Show("Branch information not found in Dashboard.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvHistory.DataSource = Nothing
                Return
            End If

            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Only Stock Ordering query remains
                Dim sql As String = "SELECT 
                        PO_NUMBER AS [Document No],
                        DR AS [DR Number],
                        [FROM] AS Vendor,
                        PREPARED_BY AS [Prepared By],
                        REQUEST_DATE AS [Request Date],
                        [TO] AS [To Branch],
                        RECEIVER AS [Receive By],
                        RECEIVE_DATE AS [Receive Date],
                        STATUS,
                        TOTAL AS Amount,
                        'Stock Ordering' AS [Transaction Type]
                     FROM dbo.STO_DATA 
                     WHERE LTRIM(RTRIM([TO])) = LTRIM(RTRIM(@Branch))
                       AND REQUEST_DATE BETWEEN @DateFrom AND @DateTo
                     ORDER BY PO_NUMBER DESC"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@Branch", SqlDbType.NVarChar, 100).Value = selectedBranch
                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtpFrom.Value
                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtpTo.Value

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvHistory.DataSource = dt
                End Using
            End Using

            FormatGrid()

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        For Each col As DataGridViewColumn In dgvHistory.Columns
            If col.Name.Equals("Amount", StringComparison.OrdinalIgnoreCase) Then
                col.DefaultCellStyle.Format = "N2"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf col.Name.Contains("Date") Then
                col.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
                col.DefaultCellStyle.NullValue = ""
            End If
        Next
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
    End Sub

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row = dgvHistory.Rows(e.RowIndex)
        Dim docNo As String = row.Cells("Document No").Value.ToString().Trim()
        Dim status As String = row.Cells("STATUS").Value.ToString().Trim()

        ' Matches the simplified Transaction_Details constructor we made earlier
        Using frm As New Transaction_Details(docNo, status)
            frm.ShowDialog()
        End Using

        LoadData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class