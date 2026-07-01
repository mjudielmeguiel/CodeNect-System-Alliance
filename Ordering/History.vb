Imports System.Data.SqlClient
Imports System.Data
Imports Excel = Microsoft.Office.Interop.Excel

Public Class History

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboType.Items.Clear()
        cboType.Items.Add("Stock Ordering")
        cboType.Items.Add("Stock Transfer")
        cboType.Items.Add("Return to Vendor")
        cboType.SelectedIndex = 0

        cboBranch.Items.Clear()

        Try
            Using conn As New SqlConnection(connStr)
                Dim sqlBranches As String = "SELECT DISTINCT BRANCH FROM Branches WHERE BRANCH IS NOT NULL ORDER BY BRANCH"
                Using cmd As New SqlCommand(sqlBranches, conn)
                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim b As String = reader("BRANCH").ToString().Trim()
                            If b <> "" Then cboBranch.Items.Add(b)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message)
        End Try

        If cboBranch.Items.Contains("more Store - Festival Mall") Then
            cboBranch.SelectedItem = "more Store - Festival Mall"
        Else
            If cboBranch.Items.Count > 0 Then cboBranch.SelectedIndex = 0
        End If

        LoadData()
    End Sub

    Sub LoadData()
        Try
            Using conn As New SqlConnection(connStr)
                Dim selectedBranch As String = cboBranch.Text
                Dim dt As New DataTable

                If cboType.Text = "Stock Ordering" Then
                    Dim sql As String = "SELECT 
                                            PO_NUMBER AS [PO Number],
                                            DR_NUMBER AS [DR Number],
                                            VENDOR_CODE AS [Vendor Code],
                                            VENDOR,
                                            PREPARED_BY AS [Prepared By],
                                            REQUEST_DATE AS [Request Date],
                                            BRANCH_ID AS [Branch ID],
                                            BRANCH,
                                            RECIEVE_BY AS [Receive By],
                                            RECIEVE_DATE AS [Receive Date],
                                            STATUS,
                                            TOTAL AS Amount
                                         FROM inv.Sto 
                                         WHERE BRANCH = @Branch
                                         ORDER BY PO_NUMBER DESC"

                    Using cmd As New SqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@Branch", selectedBranch)
                        Dim da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                ElseIf cboType.Text = "Stock Transfer" Then
                    Dim sql As String = "SELECT 
                                            STR_NUMBER AS [STR Number],
                                            DR_NUMBER AS [DR Number],
                                            TRANSFER_FROM AS [From],
                                            REQUEST_DATE AS [Request Date],
                                            TRANSFER_DATE AS [Transfer Date],
                                            PREPARED_BY AS [Prepared By],
                                            APPROVED_BY AS [Approved By],
                                            TRANSFER_TO AS [To],
                                            RECEIVE_DATE AS [Receive Date],
                                            RECEIVED_BY AS [Received By],
                                            MEMO,
                                            STATUS,
                                            TOTAL AS Amount
                                         FROM inv.Str
                                         WHERE TRANSFER_FROM = @Branch OR TRANSFER_TO = @Branch
                                         ORDER BY STR_NUMBER DESC"

                    Using cmd As New SqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@Branch", selectedBranch)
                        Dim da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                ElseIf cboType.Text = "Return to Vendor" Then
                    Dim sql As String = "SELECT 
                                            RTV_NUMBER AS [RTV Number],
                                            FROM_BRANCH AS [From],
                                            TO_VENDOR AS [To Vendor],
                                            REASON,
                                            REMARKS,
                                            PREPARED_DATE AS [Prepared Date],
                                            PULLOUT_DATE AS [Pullout Date],
                                            RETURN_DATE AS [Return Date],
                                            VENDOR_RECEIVED_DATE AS [Vendor Received Date],
                                            PREPARED_BY AS [Prepared By],
                                            APPROVED_BY AS [Approved By],
                                            VERIFIED_BY AS [Verified By],
                                            TOTAL_QUANTITY AS [Total Quantity],
                                            TOTAL_AMOUNT AS Amount,
                                            STATUS,
                                            REFERENCE_NUMBER AS [Reference No]
                                         FROM ven.Rtv
                                         WHERE FROM_BRANCH = @Branch
                                         ORDER BY RTV_NUMBER DESC"

                    Using cmd As New SqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@Branch", selectedBranch)
                        Dim da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End If

                dgvHistory.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub cboBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranch.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub btnSaveExcel_Click(sender As Object, e As EventArgs) Handles btnSaveExcel.Click
        Try
            If dgvHistory.Rows.Count = 0 Then
                MessageBox.Show("No data to export.")
                Exit Sub
            End If

            Dim excelApp As New Excel.Application()
            Dim excelWB As Excel.Workbook = excelApp.Workbooks.Add()
            Dim excelWS As Excel.Worksheet = CType(excelWB.Worksheets(1), Excel.Worksheet)

            For col As Integer = 0 To dgvHistory.Columns.Count - 1
                excelWS.Cells(1, col + 1) = dgvHistory.Columns(col).HeaderText
            Next

            For row As Integer = 0 To dgvHistory.Rows.Count - 1
                For col As Integer = 0 To dgvHistory.Columns.Count - 1
                    Dim val = dgvHistory.Rows(row).Cells(col).Value
                    excelWS.Cells(row + 2, col + 1) = If(val Is DBNull.Value, "", val.ToString())
                Next
            Next

            excelWS.Columns.AutoFit()
            excelApp.Visible = True
            MessageBox.Show("Successfully Exported!")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class