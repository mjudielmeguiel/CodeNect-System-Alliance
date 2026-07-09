Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Transaction_Details

    Private Sub DashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(Login.LoggedInUserID) Then
            SetAccountOffline()
        End If
    End Sub

    Private Sub SetAccountOffline()
        If String.IsNullOrEmpty(Login.LoggedInUserID) Then Return

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmdText As String = "UPDATE dbo.User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @UserID"

                Using cmd As New SqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private connStr As String = DBConnection.connStr
    Private _transType As String = "Stock Ordering"
    Private _transNo As String
    Private _status As String
    Private _isLoading As Boolean = False
    Private _isViewOnly As Boolean = False

    ' Constructor for Stock Ordering only
    Public Sub New(transNo As String, Optional status As String = "", Optional isViewOnly As Boolean = False)
        InitializeComponent()
        _transNo = transNo
        _status = status
        _isViewOnly = isViewOnly
    End Sub

    Private Sub Transaction_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTransType.Text = _transType
        lblTransNo.Text = "PO-" & _transNo
        lblstatus.Text = _status

        SetFormTitle()
        SetStatusLabelColor()
        LoadItems()

        ' Apply view-only mode
        If _isViewOnly OrElse
           _status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then
            SetViewOnlyMode()
        End If
    End Sub

    Private Sub SetFormTitle()
        Me.Text = "STOCK ORDERING DETAILS"
    End Sub

    Private Sub SetStatusLabelColor()
        Select Case _status.ToUpper()
            Case "PENDING"
                lblstatus.BackColor = Color.Transparent
                lblstatus.ForeColor = Color.Orange
            Case "RECEIVED"
                lblstatus.BackColor = Color.Transparent
                lblstatus.ForeColor = Color.Green
            Case Else
                lblstatus.BackColor = Color.Transparent
                lblstatus.ForeColor = Color.Black
        End Select
    End Sub

    Private Sub SetViewOnlyMode()
        txtDRNumber.ReadOnly = True
        txtStockIn.ReadOnly = True
        txtStockOut.ReadOnly = True
        btnSubmit.Enabled = False
        dgvItems.ReadOnly = True
        dgvItems.AllowUserToAddRows = False
        dgvItems.AllowUserToDeleteRows = False
        Me.Text &= " - VIEW ONLY"
    End Sub

    Private Sub LoadItems()
        Try
            _isLoading = True
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim sql As String = "SELECT 
                    SKU,
                    BARCODE,
                    BRAND,
                    DESCRIPTIONS AS [Description],
                    SIZE,
                    PRICE,
                    ORDER_QTY AS [Order Qty],
                    ISNULL(STOCK_IN, 0) AS [Stock In],
                    ISNULL(STOCK_OUT, 0) AS [Stock Out],
                    (ISNULL(STOCK_IN, 0) - ISNULL(STOCK_OUT, 0)) AS REMARKS,
                    ((ISNULL(STOCK_IN, 0) - ISNULL(STOCK_OUT, 0)) * PRICE) AS [Total To Pay]
                FROM dbo.Stock_Ordering 
                WHERE PO_NUMBER = @DocNo
                ORDER BY SKU"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@DocNo", SqlDbType.NVarChar, 15).Value = _transNo
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgvItems.DataSource = dt
                End Using
            End Using

            FormatGrid()
            CalculateGrandTotal()
        Catch ex As Exception
            MessageBox.Show("Load Error: " & ex.Message)
        Finally
            _isLoading = False
        End Try
    End Sub

    Private Sub FormatGrid()
        For Each col As DataGridViewColumn In dgvItems.Columns
            If col.Name = "PRICE" Or col.Name = "Total To Pay" Then
                col.DefaultCellStyle.Format = "N2"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf col.Name = "REMARKS" Or col.Name.Contains("Qty") Or col.Name.Contains("Stock") Then
                col.DefaultCellStyle.Format = "N0"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvItems.AllowUserToAddRows = False
    End Sub

    Private Sub CalculateGrandTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvItems.Rows
            total += Val(row.Cells("Total To Pay").Value)
        Next
        lblGrandTotal.Text = total.ToString("N2")
    End Sub

    Private Sub dgvItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellClick
        If e.RowIndex < 0 OrElse _isViewOnly OrElse
           _status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then Return

        _isLoading = True
        Dim row = dgvItems.Rows(e.RowIndex)
        txtStockIn.Text = row.Cells("Stock In").Value.ToString()
        txtStockOut.Text = row.Cells("Stock Out").Value.ToString()
        _isLoading = False
    End Sub

    Private Sub txtStockIn_TextChanged(sender As Object, e As EventArgs) Handles txtStockIn.TextChanged, txtStockOut.TextChanged
        If _isLoading OrElse _isViewOnly OrElse
           _status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then Return

        Dim sIn = Math.Max(0, CInt(Math.Truncate(Val(txtStockIn.Text))))
        Dim sOut = Math.Max(0, CInt(Math.Truncate(Val(txtStockOut.Text))))

        Dim row = dgvItems.CurrentRow
        If row IsNot Nothing Then
            Dim price = Val(row.Cells("PRICE").Value)
            Dim remarksQty = sIn - sOut
            Dim totalPay = remarksQty * price

            row.Cells("Stock In").Value = sIn
            row.Cells("Stock Out").Value = sOut
            row.Cells("REMARKS").Value = remarksQty
            row.Cells("Total To Pay").Value = totalPay

            CalculateGrandTotal()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If _isViewOnly Then
            MessageBox.Show("View-only mode — changes not allowed.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If _status.Equals("RECEIVED", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Transaction already completed — cannot edit.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvItems.Rows.Count = 0 Then
            MessageBox.Show("No items to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtDRNumber.Text) Then
            MessageBox.Show("Please enter DR Number first.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDRNumber.Focus()
            Return
        End If

        If MessageBox.Show("Save this transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Using trans = conn.BeginTransaction()
                    Try
                        Dim grandTotal As Decimal = 0
                        Dim receiverName = DashBoard.ToolStripStatusLabel1.Text.Trim()
                        If receiverName.Length > 20 Then receiverName = receiverName.Substring(0, 20)

                        Dim cmdItem As New SqlCommand("UPDATE dbo.Stock_Ordering 
                            SET STOCK_IN = @In, STOCK_OUT = @Out, REMARKS = @Remarks, TOTAL = @ItemTotal
                            WHERE PO_NUMBER = @DocNo AND SKU = @SKU", conn, trans)

                        Dim cmdUpdateInventory As New SqlCommand("UPDATE inv.Inventory_Master_file 
                            SET AVAILABLE = AVAILABLE + @QtyReceived 
                            WHERE SKU = @SKU", conn, trans)

                        Dim cmdHeader As New SqlCommand("UPDATE dbo.STO_DATA 
                            SET 
                                DR = @DR,
                                RECEIVER = @Receiver,
                                RECEIVE_DATE = GETDATE(),
                                STATUS = 'RECEIVED',
                                TOTAL = @GrandTotal
                            WHERE PO_NUMBER = @DocNo", conn, trans)

                        For Each row As DataGridViewRow In dgvItems.Rows
                            Dim remarksQty = CInt(row.Cells("REMARKS").Value)
                            Dim itemTotal = Val(row.Cells("Total To Pay").Value)
                            Dim itemSKU = row.Cells("SKU").Value.ToString().Trim()
                            grandTotal += itemTotal

                            cmdItem.Parameters.Clear()
                            cmdItem.Parameters.Add("@DocNo", SqlDbType.NVarChar, 15).Value = _transNo
                            cmdItem.Parameters.Add("@SKU", SqlDbType.NVarChar, 15).Value = itemSKU
                            cmdItem.Parameters.Add("@In", SqlDbType.Int).Value = row.Cells("Stock In").Value
                            cmdItem.Parameters.Add("@Out", SqlDbType.Int).Value = row.Cells("Stock Out").Value
                            cmdItem.Parameters.Add("@Remarks", SqlDbType.Int).Value = remarksQty
                            cmdItem.Parameters.Add("@ItemTotal", SqlDbType.Decimal, 18, 2).Value = itemTotal
                            cmdItem.ExecuteNonQuery()

                            cmdUpdateInventory.Parameters.Clear()
                            cmdUpdateInventory.Parameters.Add("@QtyReceived", SqlDbType.Int).Value = remarksQty
                            cmdUpdateInventory.Parameters.Add("@SKU", SqlDbType.NVarChar, 15).Value = itemSKU
                            cmdUpdateInventory.ExecuteNonQuery()
                        Next

                        cmdHeader.Parameters.Add("@DocNo", SqlDbType.NVarChar, 15).Value = _transNo
                        cmdHeader.Parameters.Add("@DR", SqlDbType.NVarChar, 20).Value = txtDRNumber.Text.Trim()
                        cmdHeader.Parameters.Add("@Receiver", SqlDbType.NVarChar, 20).Value = receiverName
                        cmdHeader.Parameters.Add("@GrandTotal", SqlDbType.Decimal, 18, 2).Value = grandTotal
                        cmdHeader.ExecuteNonQuery()

                        trans.Commit()
                        MessageBox.Show("Saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _status = "RECEIVED"
                        lblstatus.Text = _status
                        SetStatusLabelColor()
                        SetViewOnlyMode()

                    Catch ex As Exception
                        trans.Rollback()
                        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvItems.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Excel File (*.xlsx)|*.xlsx"
            sfd.FileName = "PO_" & _transNo & "_" & DateTime.Now.ToString("yyyyMMdd") & ".xlsx"

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim excelApp As Microsoft.Office.Interop.Excel.Application = Nothing
            Dim wb As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim ws As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Try
                excelApp = New Microsoft.Office.Interop.Excel.Application()
                wb = excelApp.Workbooks.Add()
                ws = CType(wb.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                ws.Name = "PO Details"

                ws.Cells(1, 1) = "Transaction Type"
                ws.Cells(1, 2) = _transType
                ws.Cells(2, 1) = "PO Number"
                ws.Cells(2, 2) = _transNo
                ws.Cells(3, 1) = "Status"
                ws.Cells(3, 2) = _status
                ws.Cells(4, 1) = "Grand Total"
                ws.Cells(4, 2) = lblGrandTotal.Text

                Dim headerRow As Integer = 6
                For col As Integer = 0 To dgvItems.Columns.Count - 1
                    ws.Cells(headerRow, col + 1) = dgvItems.Columns(col).HeaderText
                    With ws.Cells(headerRow, col + 1)
                        .Font.Bold = True
                        .Interior.Color = Color.LightGray
                    End With
                Next

                For row As Integer = 0 To dgvItems.Rows.Count - 1
                    For col As Integer = 0 To dgvItems.Columns.Count - 1
                        ws.Cells(headerRow + 1 + row, col + 1) = dgvItems.Rows(row).Cells(col).Value?.ToString()
                    Next
                Next

                ws.Columns.AutoFit()
                wb.SaveAs(sfd.FileName)
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Finally
                If ws IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
                If wb IsNot Nothing Then
                    wb.Close()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
                End If
                If excelApp IsNot Nothing Then
                    excelApp.Quit()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)
                End If
            End Try

        Catch ex As Exception
            MessageBox.Show("Export Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class