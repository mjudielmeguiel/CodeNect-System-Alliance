Imports System.Data.SqlClient
Imports System.IO

Public Class Branch_Manage

    ' ✅ Connection String
    Private ConnString As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    Private Sub Branch_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranches()
    End Sub

    Private Sub LoadBranches(Optional ByVal SearchText As String = "")
        Try
            ' ✅ Get the Account ID of the currently logged-in user
            Dim CurrentAccountID As String = Login.LoggedInAccountID

            ' Check if Account ID is available
            If String.IsNullOrEmpty(CurrentAccountID) Then
                MessageBox.Show("Account ID not found. Please log out and log in again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ Retrieve only branches belonging to the current Account ID
            Dim Sql As String = "SELECT ACCOUNT_ID, ACCOUNT, BRANCH_ID, BRANCH, TIN, BUSINESS_TYPE, ADDRESS, EMAIL, CONTACT, MANAGER " &
                                 "FROM dbo.Branches " &
                                 "WHERE ACCOUNT_ID = @AccID "

            ' Add search filter if text is entered
            If Not String.IsNullOrEmpty(SearchText) Then
                Sql &= "AND (BRANCH LIKE '%' + @Filter + '%' OR ADDRESS LIKE '%' + @Filter + '%' OR MANAGER LIKE '%' + @Filter + '%') "
            End If

            Sql &= "ORDER BY BRANCH ASC"

            Using Conn As New SqlConnection(ConnString)
                Using Cmd As New SqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@AccID", CurrentAccountID)

                    If Not String.IsNullOrEmpty(SearchText) Then
                        Cmd.Parameters.AddWithValue("@Filter", SearchText)
                    End If

                    Dim Da As New SqlDataAdapter(Cmd)
                    Dim Dt As New DataTable
                    Da.Fill(Dt)

                    dgvBranches.DataSource = Dt

                    ' ✅ Show message if no branches are found
                    If Dt.Rows.Count = 0 Then
                        MessageBox.Show("No records found. This means: " & vbCrLf &
                                        "1. No branches have been registered under Account ID: " & CurrentAccountID & vbCrLf &
                                        "2. Or the Account ID assigned to the branch does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Open branch details on double-click
    Private Sub dgvBranches_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBranches.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim SelectedBranchID As String = dgvBranches.Rows(e.RowIndex).Cells("BRANCH_ID").Value.ToString()

            Dim frmInfo As New Branch_Info
            frmInfo.SelectedBranchID = SelectedBranchID
            frmInfo.ShowDialog()

            ' Refresh list after editing
            LoadBranches()
        End If
    End Sub

    ' ✅ Search function
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBranches(txtSearch.Text.Trim())
    End Sub

    ' ✅ Refresh button
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        LoadBranches()
    End Sub

    ' ✅ Export list to CSV/Excel
    Private Sub btnSaveExcel_Click(sender As Object, e As EventArgs) Handles btnSaveExcel.Click
        If dgvBranches.Rows.Count = 0 Then
            MessageBox.Show("No data available to export!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim SFD As New SaveFileDialog
        SFD.Filter = "Excel CSV File (*.csv)|*.csv"
        SFD.FileName = "Branch List - " & DateTime.Now.ToString("yyyy-MM-dd")

        If SFD.ShowDialog() = DialogResult.OK Then
            Try
                Dim sw As New StreamWriter(SFD.FileName, False, System.Text.Encoding.UTF8)

                ' Write headers
                Dim Header As String = ""
                For Each col As DataGridViewColumn In dgvBranches.Columns
                    Header &= col.HeaderText & ","
                Next
                Header = Header.TrimEnd(","c)
                sw.WriteLine(Header)

                ' Write rows
                For Each row As DataGridViewRow In dgvBranches.Rows
                    If Not row.IsNewRow Then
                        Dim Line As String = ""
                        For Each cell As DataGridViewCell In row.Cells
                            Dim value As String = If(cell.Value IsNot Nothing, cell.Value.ToString().Replace(",", " "), "")
                            Line &= value & ","
                        Next
                        Line = Line.TrimEnd(","c)
                        sw.WriteLine(Line)
                    End If
                Next

                sw.Close()

                MessageBox.Show("Successfully saved to:" & vbCrLf & SFD.FileName & vbCrLf & vbCrLf & "*Open this file using Microsoft Excel", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error during export: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class