Imports System.Data
Imports System.Data.SqlClient

Public Class Branch_Performance

    Private Sub Branch_Performance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllData()
    End Sub

    Private Sub LoadAllData()
        Try
            Dim dt As New DataTable()

            ' Kukunin LAHAT ng laman, eksaktong pangalan ng column
            Dim sql As String = "
                SELECT
                    ACCOUNT_ID,
                    BRANCH_ID,
                    BRANCH_NAME,
                    Transaction_Date,
                    Total_Transactions,
                    Cash_Sales,
                    Online_Sales,
                    Total_Discount,
                    Total_VAT,
                    Net_Sales,
                    Recorded_At
                FROM dbo.Daily_Sales_Log
                ORDER BY Transaction_Date DESC
            "

            Using conn As New SqlConnection(DBConnection.connStr)
                Using cmd As New SqlCommand(sql, conn)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            ' Hayaan ang grid na gumawa ng column mismo base sa table
            dgvBranchList.AutoGenerateColumns = True
            dgvBranchList.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAllData()
    End Sub

End Class