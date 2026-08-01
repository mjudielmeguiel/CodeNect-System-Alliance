Imports System.Data
Imports MySqlConnector

Public Class Branch_Performance

    Private connStr As String = DBConnection.connStr

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AuditLogger.LogAction("OPEN_BRANCH_PERF", "BranchPerf", "Opened Branch Performance Report — ADMIN ONLY ACCESS")
        LoadAllData()
    End Sub

    Private Sub LoadAllData()
        Try
            Dim dt As New DataTable()

            Dim sql As String = "
                SELECT
                    `ACCOUNT_ID`,
                    `BRANCH_ID`,
                    `BRANCH_NAME`,
                    `Transaction_Date`,
                    `Total_Transactions`,
                    `Cash_Sales`,
                    `Online_Sales`,
                    `Total_Discount`,
                    `Total_VAT`,
                    `Net_Sales`,
                    `Recorded_At`
                FROM `Daily_Sales_Log`
                ORDER BY `Transaction_Date` DESC
            "

            Using conn As New MySqlConnection(connStr)
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvBranchList.AutoGenerateColumns = True
            dgvBranchList.DataSource = dt

            AuditLogger.LogAction("BRANCH_DATA_LOADED", "BranchPerf", $"Loaded {dt.Rows.Count} sales records — ADMIN VIEW")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            AuditLogger.LogAction("ERROR", "BranchPerf", $"Load failed — ADMIN ONLY — Error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        AuditLogger.LogAction("REFRESH_BRANCH_PERF", "BranchPerf", "Admin refreshed performance report")
        LoadAllData()
    End Sub

End Class