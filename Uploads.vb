Imports System.Data.OleDb
Imports ClosedXML.Excel

Public Class Uploads
    Private Sub Uploads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CODENECTDataSet.Pcount' table. You can move, or remove it, as needed.
        Me.PcountTableAdapter.Fill(Me.CODENECTDataSet.Pcount)

    End Sub

    Private connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mjudi\Desktop\Data\CODENECT.accdb"

    Private Sub RefreshDataGridView()
        Using conn As New OleDbConnection(connStr)
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT * FROM [Inventory]", conn)
            da.Fill(dt)
            PcountDataGridView.DataSource = dt
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Filterbranch(TextBox1.Text)
    End Sub

    Private Sub Filterbranch(searchText As String)
        Using conn As New OleDbConnection(connStr)
            Dim dt As New DataTable()
            Dim query As String = "SELECT * FROM [Inventory] WHERE [TRANSACTION ID] LIKE ?"
            Using da As New OleDbDataAdapter(query, conn)
                da.SelectCommand.Parameters.AddWithValue("?", "%" & searchText & "%")
                da.Fill(dt)
                PcountDataGridView.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub EditSelectedUser()
        If PcountDataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to edit.")
            Return
        End If
    End Sub

    Private Sub RetrieveColumnInfo()
        Using conn As New OleDbConnection(connStr)
            Dim dt As New DataTable()
            Dim query As String = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Inventory'"
            Using da As New OleDbDataAdapter(query, conn)
                da.Fill(dt)
                ' You can process the DataTable (dt) as needed
            End Using
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        TRANSACTION_ID.Show()
        TextBox1.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Using sfd As SaveFileDialog = New SaveFileDialog() With {.Filter = "Excel Workbook|*.xlsx"}
            If sfd.ShowDialog() = DialogResult.OK Then

                Try
                    Using Workbook As XLWorkbook = New XLWorkbook()
                        Workbook.Worksheets.Add(Me.CODENECTDataSet.Pcount.CopyToDataTable(), "Pcount")
                        Workbook.SaveAs(sfd.FileName)
                    End Using
                    MessageBox.Show("Saved")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub
End Class