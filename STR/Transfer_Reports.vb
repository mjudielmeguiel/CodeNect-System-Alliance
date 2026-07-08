Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Transfer_Reports

    Private connStr As String = DBConnection.connStr

    Private Sub Transfer_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add transaction types to dropdown
        cboTransactionType.Items.AddRange({"Stock Ordering", "Stock Transfer"})
        cboTransactionType.SelectedIndex = 0

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
            Dim selectedType As String = If(cboTransactionType.SelectedItem IsNot Nothing, cboTransactionType.SelectedItem.ToString(), "")

            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim sqlQuery As String = ""

                ' --- STOCK ORDERING ---
                If selectedType = "Stock Ordering" Then
                    sqlQuery = "SELECT 
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

                    ' --- STOCK TRANSFER ---
                ElseIf selectedType = "Stock Transfer" Then
                    sqlQuery = "SELECT 
                                STR_NUMBER AS [Document No],
                                DR AS [DR Number],
                                FROM_MV AS [From Branch],
                                PREPARED_BY AS [Prepared By],
                                REQUEST_DATE AS [Request Date],
                                TO_MV AS [To Branch],
                                RECEIVER AS [Received By],
                                RECEIVE_DATE AS [Receive Date],
                                STATUS,
                                TOTAL AS [Amount],
                                'Stock Transfer' AS [Transaction Type]
                             FROM dbo.STR_DATA 
                             WHERE REQUEST_DATE BETWEEN @DateStart AND @DateEnd
                             ORDER BY STR_NUMBER DESC"
                End If

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
        Dim transType As String = row.Cells("Transaction Type").Value.ToString()
        Dim docNo As String = row.Cells("Document No").Value.ToString()

        If transType = "Stock Transfer" Then
            ' Open Stock Transfer form
            Dim frmTransfer As New frmSTR_Information() ' <-- use your actual form name
            frmTransfer.LoadTransferDetails(docNo)
            frmTransfer.ShowDialog()

        ElseIf transType = "Stock Ordering" Then
            ' Open Stock Ordering form
            Dim frmOrder As New frmSTO_Information() ' <-- use your actual form name
            frmOrder.LoadOrderDetails(docNo)
            frmOrder.ShowDialog()
        End If
    End Sub

    Private Sub cboTransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTransactionType.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadData()
    End Sub
End Class