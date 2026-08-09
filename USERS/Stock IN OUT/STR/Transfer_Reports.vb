Imports System.Data
Imports MySqlConnector

Public Class Transfer_Reports
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub Transfer_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvReports.Columns.Clear()
        dgvReports.AutoGenerateColumns = False
        dgvReports.AllowUserToAddRows = False

        dgvReports.Columns.Add("ACCOUNT_ID", "ACCOUNT_ID")
        dgvReports.Columns.Add("APPROVED_BY", "APPROVED_BY")
        dgvReports.Columns.Add("DR_NUMBER", "DR_NUMBER")
        dgvReports.Columns.Add("FROM_BRANCH", "FROM_BRANCH")
        dgvReports.Columns.Add("FROM_BRANCH_ID", "FROM_BRANCH_ID")
        dgvReports.Columns.Add("ID", "ID")
        dgvReports.Columns.Add("PREPARED_BY", "PREPARED_BY")
        dgvReports.Columns.Add("RECEIVED_BY", "RECEIVED_BY")
        dgvReports.Columns.Add("REMARKS", "REMARKS")
        dgvReports.Columns.Add("STATUS", "STATUS")
        dgvReports.Columns.Add("STR_NUMBER", "STR_NUMBER")
        dgvReports.Columns.Add("TOTAL_AMOUNT", "TOTAL_AMOUNT")
        dgvReports.Columns.Add("TOTAL_ITEMS", "TOTAL_ITEMS")
        dgvReports.Columns.Add("TO_BRANCH", "TO_BRANCH")
        dgvReports.Columns.Add("TO_BRANCH_ID", "TO_BRANCH_ID")
        dgvReports.Columns.Add("TRANSFER_DATE", "TRANSFER_DATE")

        For Each col As DataGridViewColumn In dgvReports.Columns
            col.ReadOnly = True
        Next

        LoadReportData()
    End Sub

    Private Sub LoadReportData()
        If dgvReports.Columns.Count = 0 Then Exit Sub
        dgvReports.Rows.Clear()

        Using conn As New MySqlConnection(connStr)
            conn.Open()

            ' ✅ EKSAKTONG SELECT — KATULAD NG transfer_data TABLE MO
            Dim sql As String = "
                SELECT ACCOUNT_ID, APPROVED_BY, DR_NUMBER, FROM_BRANCH, FROM_BRANCH_ID, ID,
                       PREPARED_BY, RECEIVED_BY, REMARKS, STATUS, STR_NUMBER,
                       TOTAL_AMOUNT, TOTAL_ITEMS, TO_BRANCH, TO_BRANCH_ID, TRANSFER_DATE
                FROM transfer_data
                ORDER BY ID DESC"

            Dim cmd As New MySqlCommand(sql, conn)

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    dgvReports.Rows.Add(
                        If(dr.IsDBNull("ACCOUNT_ID"), "", dr("ACCOUNT_ID").ToString()),
                        If(dr.IsDBNull("APPROVED_BY"), "", dr("APPROVED_BY").ToString()),
                        If(dr.IsDBNull("DR_NUMBER"), "", dr("DR_NUMBER").ToString()),
                        If(dr.IsDBNull("FROM_BRANCH"), "", dr("FROM_BRANCH").ToString()),
                        If(dr.IsDBNull("FROM_BRANCH_ID"), "", dr("FROM_BRANCH_ID").ToString()),
                        dr("ID").ToString(),
                        If(dr.IsDBNull("PREPARED_BY"), "", dr("PREPARED_BY").ToString()),
                        If(dr.IsDBNull("RECEIVED_BY"), "", dr("RECEIVED_BY").ToString()),
                        If(dr.IsDBNull("REMARKS"), "", dr("REMARKS").ToString()),
                        If(dr.IsDBNull("STATUS"), "", dr("STATUS").ToString()),
                        dr("STR_NUMBER").ToString(),
                        If(dr.IsDBNull("TOTAL_AMOUNT"), "", Convert.ToDecimal(dr("TOTAL_AMOUNT")).ToString("N2")),
                        If(dr.IsDBNull("TOTAL_ITEMS"), "", dr("TOTAL_ITEMS").ToString()),
                        If(dr.IsDBNull("TO_BRANCH"), "", dr("TO_BRANCH").ToString()),
                        If(dr.IsDBNull("TO_BRANCH_ID"), "", dr("TO_BRANCH_ID").ToString()),
                        If(dr.IsDBNull("TRANSFER_DATE"), "", Convert.ToDateTime(dr("TRANSFER_DATE")).ToString("yyyy-MM-dd HH:mm"))
                    )
                End While
            End Using
        End Using
    End Sub

End Class