Imports MySqlConnector

Public Class frmOrders

    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVendorOrders()
    End Sub

    Private Sub LoadVendorOrders()
        Dim vendorCode As String = DBConnection.CurrentVendorCode

        If String.IsNullOrWhiteSpace(vendorCode) Then
            MessageBox.Show("No Vendor logged in.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' ✅ BINAGO — HINDI NA KASAMA SA LISTAHAN KUNG ACCEPTED O REFUSED NA
                Dim sql As String = "
                    SELECT PO_NUMBER, PREPARED_BY, REQUEST_DATE, STATUS, TRANSACTION_TYPE, 
                           TOTAL, BRANCH_ID, VENDOR_CODE, VENDOR_NAME, RECEIVE_DATE, RECEIVER, ACCOUNT_ID, DR
                    FROM sto_data
                    WHERE VENDOR_CODE = @VENDOR_CODE
                      AND STATUS NOT IN ('Accepted', 'Refused', 'Order Placed', 'Completed')
                    ORDER BY REQUEST_DATE DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", vendorCode)

                    Using dt As New DataTable()
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using

                        dgvOrders.DataSource = Nothing
                        dgvOrders.Columns.Clear()
                        dgvOrders.DataSource = dt

                        AddActionButtons()
                        FormatColumns()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading Orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddActionButtons()
        Dim btnAccept As New DataGridViewButtonColumn()
        With btnAccept
            .Name = "colAccept"
            .HeaderText = "Action"
            .Text = "Accept"
            .UseColumnTextForButtonValue = True
            .Width = 70
            .DefaultCellStyle.BackColor = Color.LightGreen
        End With

        Dim btnView As New DataGridViewButtonColumn()
        With btnView
            .Name = "colView"
            .HeaderText = "View"
            .Text = "View"
            .UseColumnTextForButtonValue = True
            .Width = 60
            .DefaultCellStyle.BackColor = Color.LightBlue
        End With

        Dim btnRefuse As New DataGridViewButtonColumn()
        With btnRefuse
            .Name = "colRefuse"
            .HeaderText = "Refuse"
            .Text = "Refuse"
            .UseColumnTextForButtonValue = True
            .Width = 70
            .DefaultCellStyle.BackColor = Color.LightCoral
        End With

        dgvOrders.Columns.Add(btnAccept)
        dgvOrders.Columns.Add(btnView)
        dgvOrders.Columns.Add(btnRefuse)
    End Sub

    Private Sub FormatColumns()
        If dgvOrders.Columns.Count = 0 Then Exit Sub

        dgvOrders.AllowUserToAddRows = False
        dgvOrders.ReadOnly = True
        dgvOrders.RowTemplate.Height = 30
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvOrders.Columns("PO_NUMBER").HeaderText = "PO Number"
        dgvOrders.Columns("PREPARED_BY").HeaderText = "Prepared By"
        dgvOrders.Columns("REQUEST_DATE").HeaderText = "Request Date"
        dgvOrders.Columns("STATUS").HeaderText = "Status"
        dgvOrders.Columns("STATUS").Visible = True
        dgvOrders.Columns("TRANSACTION_TYPE").HeaderText = "Type"
        dgvOrders.Columns("TOTAL").HeaderText = "Total Amount"
        dgvOrders.Columns("BRANCH_ID").HeaderText = "Branch"

        dgvOrders.Columns("TOTAL").DefaultCellStyle.Format = "N2"
        dgvOrders.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOrders.Columns("REQUEST_DATE").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
    End Sub

    Private Sub dgvOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrders.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim poNumber As String = dgvOrders.Rows(e.RowIndex).Cells("PO_NUMBER").Value.ToString()
        Dim currentStatus As String = dgvOrders.Rows(e.RowIndex).Cells("STATUS").Value?.ToString().Trim()

        If e.ColumnIndex = dgvOrders.Columns("colAccept").Index Then
            If currentStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) OrElse
               currentStatus.Equals("Preparing", StringComparison.OrdinalIgnoreCase) Then
                UpdateOrderStatus(poNumber, "Accepted")
            Else
                MessageBox.Show($"Order is already {currentStatus}", "Cannot Accept", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf e.ColumnIndex = dgvOrders.Columns("colRefuse").Index Then
            If currentStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) OrElse
               currentStatus.Equals("Preparing", StringComparison.OrdinalIgnoreCase) Then
                If MessageBox.Show("Refuse this Order?", "Confirm Refuse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    UpdateOrderStatus(poNumber, "Refused")
                End If
            Else
                MessageBox.Show($"Order is already {currentStatus}", "Cannot Refuse", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf e.ColumnIndex = dgvOrders.Columns("colView").Index Then
            Dim frmDetails As New frmOrderDetails()
            frmDetails.PO_NUMBER = poNumber
            frmDetails.ShowDialog()
            LoadVendorOrders()
        End If
    End Sub

    Private Sub UpdateOrderStatus(poNumber As String, newStatus As String)
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE sto_data SET STATUS = @STATUS WHERE PO_NUMBER = @PO", conn)
                    cmd.Parameters.AddWithValue("@STATUS", newStatus)
                    cmd.Parameters.AddWithValue("@PO", poNumber)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show($"Order {newStatus} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadVendorOrders() ' ✅ AWTOMATIKONG MAWALA SA LISTAHAN
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadVendorOrders()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim vendorCode As String = DBConnection.CurrentVendorCode
        Dim keyword As String = txtSearch.Text.Trim()

        If String.IsNullOrWhiteSpace(vendorCode) Then Exit Sub

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' ✅ HINDI KASAMA SA PAGHANDEL KUNG ACCEPTED/REFUSED NA
                Dim sql As String = "
                    SELECT PO_NUMBER, PREPARED_BY, REQUEST_DATE, STATUS, TRANSACTION_TYPE, 
                           TOTAL, BRANCH_ID, VENDOR_CODE, VENDOR_NAME, RECEIVE_DATE, RECEIVER, ACCOUNT_ID, DR
                    FROM sto_data
                    WHERE VENDOR_CODE = @VENDOR_CODE
                      AND STATUS NOT IN ('Accepted', 'Refused', 'Order Placed', 'Completed')
                      AND (PO_NUMBER LIKE @KEYWORD 
                           OR PREPARED_BY LIKE @KEYWORD 
                           OR STATUS LIKE @KEYWORD
                           OR BRANCH_ID LIKE @KEYWORD)
                    ORDER BY REQUEST_DATE DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@VENDOR_CODE", vendorCode)
                    cmd.Parameters.AddWithValue("@KEYWORD", "%" & keyword & "%")

                    Using dt As New DataTable()
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                        dgvOrders.DataSource = dt
                        AddActionButtons()
                        FormatColumns()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class