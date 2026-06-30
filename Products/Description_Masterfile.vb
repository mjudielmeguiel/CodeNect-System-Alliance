Imports System.Data.OleDb

Public Class Description_Masterfile
    Private connStr As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"


    Private Sub Description_Masterfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using conn As New OleDbConnection(connStr)
                Dim dt As New DataTable()

                Dim query As String = "
            SELECT * FROM Descriptions
            WHERE AVAILABILITY IN ('AVAILABLE', 'CRITICAL', 'OUT OF STOCK')"

                Using da As New OleDbDataAdapter(query, conn)
                    da.Fill(dt)
                End Using

                DescriptionsDataGridView.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load data: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub RefreshDataGridView()
        Try
            Using conn As New OleDbConnection(connStr)
                Dim dt As New DataTable()

                Dim query As String = "
            SELECT * FROM Descriptions 
            WHERE AVAILABILITY IN ('AVAILABLE', 'CRITICAL', 'OUT OF STOCK')"

                Using da As New OleDbDataAdapter(query, conn)
                    da.Fill(dt)
                End Using

                DescriptionsDataGridView.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load data: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ResponsiveProductSearch(txtSearch.Text.Trim())
    End Sub

    Private Sub ResponsiveProductSearch(searchText As String)
        If String.IsNullOrWhiteSpace(searchText) Then
            Exit Sub
        End If

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                ' 1. Check if product exists but is NOT CARRIED
                Dim checkNotCarriedQuery As String = "
            SELECT COUNT(*) FROM Descriptions 
            WHERE (
                [BARCODE(EAN/UPC)] LIKE ? OR 
                [SKU] LIKE ? OR 
                [DESCRIPTIONS] LIKE ?
            ) AND AVAILABILITY = 'NOT CARRIED'"

                Using cmd As New OleDbCommand(checkNotCarriedQuery, conn)
                    For i As Integer = 1 To 3
                        cmd.Parameters.AddWithValue("?", "%" & searchText & "%")
                    Next

                    Dim countNotCarried As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If countNotCarried > 0 Then
                        MessageBox.Show("This product is NOT CARRIED.", "NOT CARRIED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        DescriptionsDataGridView.DataSource = Nothing
                        Exit Sub
                    End If
                End Using

                ' 2. Check if product exists but is OUT OF STOCK
                Dim checkOutOfStockQuery As String = "
            SELECT COUNT(*) FROM Descriptions 
            WHERE (
                [BARCODE(EAN/UPC)] LIKE ? OR 
                [SKU] LIKE ? OR 
                [DESCRIPTIONS] LIKE ?
            ) AND AVAILABILITY = 'OUT OF STOCK'"

                Using cmd As New OleDbCommand(checkOutOfStockQuery, conn)
                    For i As Integer = 1 To 3
                        cmd.Parameters.AddWithValue("?", "%" & searchText & "%")
                    Next

                    Dim countOutOfStock As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If countOutOfStock > 0 Then
                        MessageBox.Show("This product is OUT OF STOCK.", "OUT OF STOCK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using

                ' 3. Load only AVAILABLE, CRITICAL, and OUT OF STOCK into the grid
                Dim dt As New DataTable()
                Dim query As String = "
            SELECT * FROM Descriptions 
            WHERE AVAILABILITY IN ('AVAILABLE', 'CRITICAL', 'OUT OF STOCK')
            AND (
                [BARCODE(EAN/UPC)] LIKE ? OR 
                [SKU] LIKE ? OR 
                [DESCRIPTIONS] LIKE ?
            )"

                Using da As New OleDbDataAdapter(query, conn)
                    For i As Integer = 1 To 3
                        da.SelectCommand.Parameters.AddWithValue("?", "%" & searchText & "%")
                    Next
                    da.Fill(dt)
                End Using

                ' 4. If nothing is found at all → product does not exist
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("The product does not exist.", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DescriptionsDataGridView.DataSource = Nothing
                Else
                    DescriptionsDataGridView.DataSource = dt
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DescriptionsDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DescriptionsDataGridView.CellDoubleClick
        ' Make sure user clicked a valid row
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DescriptionsDataGridView.Rows(e.RowIndex)

        ' Extract data using column indexes (PriceBox removed)
        Dim barcode As String = row.Cells(0).Value.ToString()
        Dim sku As String = row.Cells(1).Value.ToString()
        Dim description As String = row.Cells(2).Value.ToString()
        Dim brand As String = row.Cells(3).Value.ToString()
        Dim category As String = row.Cells(4).Value.ToString()
        Dim size As String = row.Cells(5).Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(row.Cells(6).Value)
        Dim unit As String = row.Cells(7).Value.ToString()
        Dim stock As Integer = Convert.ToInt32(row.Cells(8).Value)
        Dim availability As String = row.Cells(9).Value.ToString()
        Dim vendorCode As String = row.Cells(10).Value.ToString()
        Dim vendor As String = row.Cells(11).Value.ToString()

    End Sub


    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        txtSearch.Clear()
        RefreshDataGridView()
    End Sub
End Class