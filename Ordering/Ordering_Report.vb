Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Ordering_Report

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateTime.Today
        dtpTo.Value = DateTime.Today.AddDays(1).AddSeconds(-1)
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
                Dim dateFrom As DateTime = dtpFrom.Value.Date
                Dim dateTo As DateTime = dtpTo.Value.Date.AddDays(1).AddSeconds(-1)
                Dim dt As New DataTable()

                Dim sql As String = "SELECT 
                                        PO_NUMBER AS [PO Number],
                                        DR AS [DR Number],
                                        [FROM] AS Vendor,
                                        PREPARED_BY AS [Prepared By],
                                        REQUEST_DATE AS [Request Date],
                                        [TO] AS Branch,
                                        RECEIVER AS [Receive By],
                                        RECEIVE_DATE AS [Receive Date],
                                        STATUS,
                                        TOTAL AS Amount
                                     FROM STO_DATA 
                                     WHERE [TO] = @Branch 
                                       AND REQUEST_DATE BETWEEN @DateFrom AND @DateTo
                                     ORDER BY PO_NUMBER DESC"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@Branch", SqlDbType.NVarChar, 100).Value = selectedBranch
                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dateFrom
                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dateTo
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                dgvHistory.DataSource = dt

                For Each col As DataGridViewColumn In dgvHistory.Columns
                    If col.Name.Equals("Amount", StringComparison.OrdinalIgnoreCase) Then
                        col.DefaultCellStyle.Format = "N2"
                    ElseIf col.Name.Contains("Date") Then
                        col.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
                        col.DefaultCellStyle.NullValue = ""
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row = dgvHistory.Rows(e.RowIndex)
        Dim poNo = row.Cells("PO Number").Value.ToString()
        Dim status = row.Cells("STATUS").Value.ToString().Trim()

        Using frm As New Transaction_Details("Stock Ordering", poNo, status)
            frm.ShowDialog()
        End Using

        LoadData()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class