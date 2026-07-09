Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing

Public Class Ordering_Reports

    Private connStr As String = DBConnection.connStr

    Private Sub Ordering_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set date range for the whole day
        dtpFrom.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0)
        dtpTo.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)

        ' Make grid fully view-only
        dgvHistory.ReadOnly = True
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.AllowUserToResizeRows = False
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Enable double-click to open details
        AddHandler dgvHistory.CellDoubleClick, AddressOf dgvHistory_CellDoubleClick

        LoadData()
    End Sub

    Sub LoadData()
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' --- ONLY STOCK ORDERING ---
                Dim sqlQuery As String = "SELECT 
                            PO_NUMBER AS [Document No],
                            DR AS [DR Number],
                            [FROM] AS [Vendor / Source],
                            PREPARED_BY AS [Prepared By],
                            REQUEST_DATE AS [Request Date],
                            [TO] AS [To Branch],
                            RECEIVER AS [Received By],
                            RECEIVE_DATE AS [Receive Date],
                            STATUS,
                            TOTAL AS [Amount],
                            'Stock Ordering' AS [Transaction Type]
                         FROM dbo.STO_DATA 
                         WHERE REQUEST_DATE BETWEEN @DateStart AND @DateEnd
                         ORDER BY PO_NUMBER DESC"

                Using cmd As New SqlCommand(sqlQuery, conn)
                    cmd.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = dtpFrom.Value
                    cmd.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = dtpTo.Value

                    Dim dtResult As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dtResult)

                    dgvHistory.DataSource = dtResult
                End Using
            End Using

            FormatGrid()

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        For Each col As DataGridViewColumn In dgvHistory.Columns
            col.ReadOnly = True

            ' Format amount as currency
            If col.Name.Equals("Amount", StringComparison.OrdinalIgnoreCase) Then
                col.DefaultCellStyle.Format = "N2"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            ' Format dates
            If col.Name.Contains("Date") Then
                col.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
                col.DefaultCellStyle.NullValue = ""
            End If
        Next

        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    ' --- DOUBLE CLICK TO OPEN DETAILS ---
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvHistory.Rows(e.RowIndex)
        Dim docNo As String = row.Cells("Document No").Value.ToString().Trim()

        ' Open only Stock Ordering details
        Dim frmOrder As New frmSTO_Information()
        frmOrder.LoadOrderDetails(docNo)
        frmOrder.ShowDialog()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
    End Sub

End Class