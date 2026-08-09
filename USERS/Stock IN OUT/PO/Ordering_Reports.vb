Imports MySqlConnector
Imports System.Drawing
Imports System.Windows.Forms

Public Class Ordering_Reports
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private selectedPONumber As String = Nothing
    Private userAccountID As String = Nothing
    Private userBranchID As String = Nothing

    Private Sub Ordering_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userAccountID = If(DBConnection.CurrentUserAccountID IsNot Nothing, DBConnection.CurrentUserAccountID.Trim(), "")
        userBranchID = If(DBConnection.CurrentUserBranchID IsNot Nothing, DBConnection.CurrentUserBranchID.Trim(), "")

        dtpFrom.Value = New DateTime(2020, 1, 1)
        dtpTo.Value = DateTime.Now.Date

        lblStatus.Text = "Status: -"
        lblStatus.ForeColor = Color.Black
        lblPONumber.Text = "PO Number: -"
        lblVendorCode.Text = "Vendor Code: -"
        lblVendor.Text = "Vendor: -"

        dgvReports.ReadOnly = False
        dgvReports.AutoGenerateColumns = False
        dgvReports.Columns.Clear()

        dgvReports.Columns.Add("PO_NUMBER", "PO Number")
        dgvReports.Columns.Add("REQUEST_DATE", "Order Date")
        dgvReports.Columns.Add("STATUS", "Status")
        dgvReports.Columns.Add("DR", "DR Number")
        dgvReports.Columns.Add("PREPARED_BY", "Prepared By")
        dgvReports.Columns.Add("RECEIVER", "Received By")
        dgvReports.Columns.Add("RECEIVE_DATE", "Received Date")
        dgvReports.Columns.Add("TRANSACTION_TYPE", "Type")
        dgvReports.Columns.Add("TOTAL", "Total")

        For Each col As DataGridViewColumn In dgvReports.Columns
            col.ReadOnly = True
        Next
        dgvReports.Columns("DR").ReadOnly = False

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

        LoadReportData()
    End Sub

    Private Sub LoadReportData()
        dgvReports.Rows.Clear()

        If String.IsNullOrWhiteSpace(userBranchID) Then
            MessageBox.Show("Branch information not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("
                SELECT PO_NUMBER, REQUEST_DATE, STATUS, DR, PREPARED_BY, RECEIVER, RECEIVE_DATE, TRANSACTION_TYPE, TOTAL
                FROM sto_data
                WHERE STATUS IN ('Pending', 'Order Placed')
                  AND BRANCH_ID = @MY_BRANCH
                ORDER BY REQUEST_DATE DESC", conn)

            cmd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    dgvReports.Rows.Add(
                        dr(0).ToString(),
                        Convert.ToDateTime(dr(1)).ToString("yyyy-MM-dd"),
                        dr(2).ToString(),
                        If(dr.IsDBNull(3), "", dr(3).ToString()),
                        dr(4).ToString(),
                        If(dr.IsDBNull(5), "", dr(5).ToString()),
                        If(dr.IsDBNull(6), "", Convert.ToDateTime(dr(6)).ToString("yyyy-MM-dd HH:mm")),
                        dr(7).ToString(),
                        Convert.ToDecimal(dr(8)).ToString("N2")
                    )
                End While
            End Using
        End Using
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

        selectedPONumber = dgvReports.Rows(e.RowIndex).Cells("PO_NUMBER").Value?.ToString()
        Dim currentStatus = dgvReports.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()

        lblPONumber.Text = $"PO Number: {selectedPONumber}"
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

        If String.IsNullOrWhiteSpace(userBranchID) OrElse String.IsNullOrWhiteSpace(selectedPONumber) Then Return

        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim cmd As New MySqlCommand("
                SELECT VENDOR_CODE, VENDOR_NAME 
                FROM sto_data 
                WHERE PO_NUMBER = @PO 
                  AND BRANCH_ID = @MY_BRANCH 
                LIMIT 1", conn)

            cmd.Parameters.AddWithValue("@PO", selectedPONumber)
            cmd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)

            Using dr = cmd.ExecuteReader()
                If dr.Read() Then
                    lblVendorCode.Text = $"Vendor Code: {dr("VENDOR_CODE")?.ToString()}"
                    lblVendor.Text = $"Vendor: {dr("VENDOR_NAME")?.ToString()}"
                End If
            End Using
        End Using
    End Sub

    Private Sub dgvReports_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReports.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        Dim poNum = dgvReports.Rows(e.RowIndex).Cells("PO_NUMBER").Value?.ToString()
        Dim drValue = dgvReports.Rows(e.RowIndex).Cells("DR").Value?.ToString()
        Dim status = dgvReports.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()

        If String.IsNullOrWhiteSpace(userBranchID) Then
            MessageBox.Show("Branch information not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If e.ColumnIndex = dgvReports.Columns("colView").Index Then
            Dim frmItems As New frmStock_Items()
            frmItems.SelectedPONumber = poNum
            frmItems.ShowDialog()
            Exit Sub
        End If

        If e.ColumnIndex = dgvReports.Columns("colReceive").Index Then
            If status.Equals("Received", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("This order has already been received.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If String.IsNullOrWhiteSpace(drValue) Then
                MessageBox.Show("Please enter the DR Number first.", "DR Number Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvReports.CurrentCell = dgvReports.Rows(e.RowIndex).Cells("DR")
                Return
            End If

            Dim currentUser = DBConnection.CurrentLoggedInUser?.Trim()

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim itemsToUpdate As New List(Of Tuple(Of String, Integer))()

                        Dim cmdGetItems As New MySqlCommand("
                            SELECT BARCODE, ORDER_QTY, STOCK_IN 
                            FROM stock_ordering 
                            WHERE PO_NUMBER = @PO 
                              AND BRANCH_ID = @MY_BRANCH", conn, tran)

                        cmdGetItems.Parameters.AddWithValue("@PO", poNum)
                        cmdGetItems.Parameters.AddWithValue("@MY_BRANCH", userBranchID)

                        Using dr = cmdGetItems.ExecuteReader()
                            While dr.Read()
                                Dim barcode As String = dr("BARCODE").ToString()
                                Dim receiveQty As Integer = 0

                                Dim stockInIndex As Integer = dr.GetOrdinal("STOCK_IN")
                                If Not dr.IsDBNull(stockInIndex) Then
                                    receiveQty = dr.GetInt32(stockInIndex)
                                    If receiveQty <= 0 Then
                                        receiveQty = Convert.ToInt32(dr("ORDER_QTY"))
                                    End If
                                Else
                                    receiveQty = Convert.ToInt32(dr("ORDER_QTY"))
                                End If

                                If receiveQty <= 0 Then
                                    Throw New InvalidOperationException($"Invalid quantity for item {barcode}")
                                End If

                                itemsToUpdate.Add(Tuple.Create(barcode, receiveQty))
                            End While
                        End Using

                        If itemsToUpdate.Count = 0 Then
                            MessageBox.Show("No items found for this PO in your Branch.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        For Each item In itemsToUpdate
                            Dim cmdUpdateStock As New MySqlCommand("
                                UPDATE inventory_information 
                                SET AVAILABLE = AVAILABLE + @QTY,
                                    AVAILABILITY = CASE 
                                        WHEN (AVAILABLE + @QTY) > 0 THEN 'Available'
                                        ELSE 'Out of Stock'
                                    END
                                WHERE BARCODE = @BARCODE 
                                  AND BRANCH_ID = @MY_BRANCH", conn, tran)

                            cmdUpdateStock.Parameters.AddWithValue("@QTY", item.Item2)
                            cmdUpdateStock.Parameters.AddWithValue("@BARCODE", item.Item1)
                            cmdUpdateStock.Parameters.AddWithValue("@MY_BRANCH", userBranchID)
                            cmdUpdateStock.ExecuteNonQuery()
                        Next

                        Dim cmdUpd As New MySqlCommand("
                            UPDATE sto_data
                            SET STATUS = 'Received', DR = @DR, RECEIVER = @RECEIVER, RECEIVE_DATE = NOW()
                            WHERE PO_NUMBER = @PONUM 
                              AND BRANCH_ID = @MY_BRANCH", conn, tran)

                        cmdUpd.Parameters.AddWithValue("@DR", drValue)
                        cmdUpd.Parameters.AddWithValue("@RECEIVER", currentUser)
                        cmdUpd.Parameters.AddWithValue("@PONUM", poNum)
                        cmdUpd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)
                        cmdUpd.ExecuteNonQuery()

                        tran.Commit()

                        MessageBox.Show(
                            $"✅ Order Received Successfully!{vbCrLf}" &
                            $"Items Updated: {itemsToUpdate.Count}{vbCrLf}" &
                            $"Used Quantity from Stock In{vbCrLf}" &
                            $"DR Number: {drValue}{vbCrLf}" &
                            $"Received By: {currentUser}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        LoadReportData()

                    Catch ex As Exception
                        tran.Rollback()
                        MessageBox.Show("Error: " & ex.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
            Exit Sub
        End If

        If e.ColumnIndex = dgvReports.Columns("colCancel").Index Then
            If status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) OrElse status.Equals("Received", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("This order cannot be cancelled.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    UPDATE sto_data 
                    SET STATUS = 'Cancelled' 
                    WHERE PO_NUMBER = @PO 
                      AND BRANCH_ID = @MY_BRANCH", conn)

                cmd.Parameters.AddWithValue("@PO", poNum)
                cmd.Parameters.AddWithValue("@MY_BRANCH", userBranchID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Order has been Cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadReportData()
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim branchID As String = If(Login.LoggedInBranchID IsNot Nothing, Login.LoggedInBranchID.ToString().Trim(), "")
        Dim accountID As String = If(Login.LoggedInAccountID IsNot Nothing, Login.LoggedInAccountID.ToString().Trim(), "")
        Dim username As String = If(Login.LoggedInUsername IsNot Nothing, Login.LoggedInUsername.ToString().Trim(), "")

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(branchID) Then
            MessageBox.Show("Missing login information. Please log in again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        DBConnection.CurrentUserBranchID = branchID
        DBConnection.CurrentUserAccountID = accountID
        DBConnection.CurrentLoggedInUser = username

        Dim POLOGS As New Order_History()

        frmDashboard.Panelmenu.Controls.Clear()

        POLOGS.TopLevel = False
        POLOGS.FormBorderStyle = FormBorderStyle.None
        POLOGS.Dock = DockStyle.Fill

        frmDashboard.Panelmenu.Controls.Add(POLOGS)

        POLOGS.Show()
    End Sub
End Class