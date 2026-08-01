Imports MySqlConnector

Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardCounts()
        AuditLogger.LogAction("OPEN", "Dashboard", "Loaded Home Dashboard overview")
    End Sub

    Private Sub LoadDashboardCounts()
        Dim accID As String = Login.LoggedInAccountID

        If String.IsNullOrWhiteSpace(accID) Then
            MessageBox.Show("No active account found. Please log in again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @AID", conn)
                    cmd.Parameters.AddWithValue("@AID", accID)
                    lblTotalUsers.Text = cmd.ExecuteScalar().ToString()
                End Using

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @AID AND `status` = 'ONLINE'", conn)
                    cmd.Parameters.AddWithValue("@AID", accID)
                    lblActiveUsers.Text = cmd.ExecuteScalar().ToString()
                End Using

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @AID AND `login_attempts` >= 3", conn)
                    cmd.Parameters.AddWithValue("@AID", accID)
                End Using

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM `branches` WHERE `account_id` = @AID", conn)
                    cmd.Parameters.AddWithValue("@AID", accID)
                    lblBranches.Text = cmd.ExecuteScalar().ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Dashboard", $"Failed to load dashboard counts: {ex.Message}")
        End Try
    End Sub

End Class