Imports MySqlConnector

Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardCounts()
        AuditLogger.LogAction("OPEN", "Dashboard", "Loaded Home Dashboard overview")
    End Sub

    Private Sub LoadDashboardCounts()
        Dim accID As String = DBConnection.CurrentUserAccountID
        Dim userBranchID As String = DBConnection.CurrentUserBranchID
        Dim userType As String = DBConnection.CurrentUserType

        If String.IsNullOrWhiteSpace(accID) Then
            MessageBox.Show("No active account found. Please log in again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                ' ✅ DETECT: ADMIN = MAIN OFFICE, WALANG BRANCH FILTER
                Dim IsAdmin As Boolean = (userType = "BUSINESS ADMIN" OrElse userBranchID = "MAIN OFFICE")

                ' ===== Total Users =====
                Dim sqlUsers As String
                If IsAdmin Then
                    sqlUsers = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid"
                Else
                    sqlUsers = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid AND `BRANCH_ID` = @branchid"
                End If
                Using cmd As New MySqlCommand(sqlUsers, conn)
                    cmd.Parameters.AddWithValue("@accid", accID)
                    If Not IsAdmin Then cmd.Parameters.AddWithValue("@branchid", userBranchID)
                    lblTotalUsers.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' ===== Active Users =====
                Dim sqlActive As String
                If IsAdmin Then
                    sqlActive = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid AND `status` = 'ACTIVE'"
                Else
                    sqlActive = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid AND `BRANCH_ID` = @branchid AND `status` = 'ACTIVE'"
                End If
                Using cmd As New MySqlCommand(sqlActive, conn)
                    cmd.Parameters.AddWithValue("@accid", accID)
                    If Not IsAdmin Then cmd.Parameters.AddWithValue("@branchid", userBranchID)
                    lblActiveUsers.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' ===== Locked Accounts =====
                Dim sqlLocked As String
                If IsAdmin Then
                    sqlLocked = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid AND `login_attempts` >= 3"
                Else
                    sqlLocked = "SELECT COUNT(*) FROM `user_accounts` WHERE `account_id` = @accid AND `BRANCH_ID` = @branchid AND `login_attempts` >= 3"
                End If
                Using cmd As New MySqlCommand(sqlLocked, conn)
                    cmd.Parameters.AddWithValue("@accid", accID)
                    If Not IsAdmin Then cmd.Parameters.AddWithValue("@branchid", userBranchID)
                    lblLockedUsers.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' ===== Total Branches (Account-wide, walang pagbabago) =====
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM `branches` WHERE `account_id` = @accid", conn)
                    cmd.Parameters.AddWithValue("@accid", accID)
                    lblBranches.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' ===== Total Products =====
                Dim sqlProd As String
                If userType.Trim().ToUpper() = "BUSINESS ADMIN" Then
                    sqlProd = "SELECT COUNT(*) FROM `admin_inventory_file` WHERE `ACCOUNT_ID` = @accid"
                Else
                    sqlProd = "SELECT COUNT(*) FROM `inventory_information` WHERE `ACCOUNT_ID` = @accid AND `BRANCH_ID` = @branchid"
                End If
                Using cmdProd As New MySqlCommand(sqlProd, conn)
                    cmdProd.Parameters.AddWithValue("@accid", accID)
                    If userType.Trim().ToUpper() <> "BUSINESS ADMIN" Then
                        cmdProd.Parameters.AddWithValue("@branchid", userBranchID)
                    End If
                    lblTotalProducts.Text = cmdProd.ExecuteScalar().ToString()
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Dashboard", $"Failed to load dashboard counts: {ex.Message}")
        End Try
    End Sub

End Class