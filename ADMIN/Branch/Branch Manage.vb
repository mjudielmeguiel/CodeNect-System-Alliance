Imports System.IO
Imports MySqlConnector

Public Class Branch_Manage

    Private Sub Branch_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBranches()
        AuditLogger.LogAction("OPEN", "Branch Management", "Opened Branch List / Manager")
    End Sub

    Private Sub LoadBranches(Optional ByVal SearchText As String = "")
        Try
            Dim CurrentAccountID As String = Login.LoggedInAccountID

            If String.IsNullOrWhiteSpace(CurrentAccountID) Then
                MessageBox.Show("No logged-in account found. Please login again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim Sql As String = "SELECT `ACCOUNT_ID`, `ACCOUNT`, `BRANCH_ID`, `BRANCH`, `TIN`, `BUSINESS_TYPE`, `ADDRESS`, `EMAIL`, `CONTACT`, `MANAGER`, `SALES` " &
                                 "FROM `branches` " &
                                 "WHERE `ACCOUNT_ID` = @AccID "

            If Not String.IsNullOrWhiteSpace(SearchText) Then
                Sql &= "AND (`BRANCH` LIKE CONCAT('%', @Filter, '%') OR `ADDRESS` LIKE CONCAT('%', @Filter, '%') OR `MANAGER` LIKE CONCAT('%', @Filter, '%')) "
            End If

            Sql &= "ORDER BY `BRANCH` ASC"

            Using Conn As New MySqlConnection(DBConnection.connStr)
                Using Cmd As New MySqlCommand(Sql, Conn)
                    Cmd.Parameters.AddWithValue("@AccID", CurrentAccountID)

                    If Not String.IsNullOrWhiteSpace(SearchText) Then
                        Cmd.Parameters.AddWithValue("@Filter", SearchText)
                    End If

                    Dim Da As New MySqlDataAdapter(Cmd)
                    Dim Dt As New DataTable
                    Da.Fill(Dt)

                    dgvBranches.DataSource = Dt

                    If Dt.Rows.Count = 0 Then
                        MessageBox.Show("No branches found under your account." & vbCrLf &
                                        "Account ID: " & CurrentAccountID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading branches: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadBranches(txtSearch.Text.Trim())
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ADD_Branch.Show()
        AuditLogger.LogAction("OPEN", "Branch Management", "Opened Add New Branch form from list")
    End Sub

    Private Sub dgvBranches_DoubleClick(sender As Object, e As EventArgs) Handles dgvBranches.DoubleClick
        Dim dashBoard As frmDashboard = Application.OpenForms.OfType(Of frmDashboard)().FirstOrDefault()
        If dashBoard IsNot Nothing Then
            dashBoard.OpenDailySales()
        End If
    End Sub

End Class