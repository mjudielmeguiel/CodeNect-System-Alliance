Imports System.Data
Imports MySqlConnector

Public Class Transfer_Reports
    Inherits Form

    Private ReadOnly connStr As String = DBConnection.connStr
    Private ReadOnly myBranchID As String = ""

    ' ✅ IPASA ANG BRANCH ID MO KAPAG BINUKSAN
    Public Sub New(Optional currentBranchID As String = "")
        InitializeComponent()
        myBranchID = currentBranchID
    End Sub

    Private Sub Transfer_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvReports.Columns.Clear()
        dgvReports.AutoGenerateColumns = False
        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToDeleteRows = False

        ' ✅ MGA COLUMN — TUGMA SA TABLE MO
        dgvReports.Columns.Add("ACCOUNT_ID", "Account ID")
        dgvReports.Columns.Add("APPROVED_BY", "Approved By")
        dgvReports.Columns.Add("DR_NUMBER", "DR Number")
        dgvReports.Columns.Add("FROM_BRANCH", "From Branch")
        dgvReports.Columns.Add("TO_BRANCH", "To Branch")
        dgvReports.Columns.Add("TRANSFER_DATE", "Transfer Date")
        dgvReports.Columns.Add("STR_NUMBER", "STR Number")
        dgvReports.Columns.Add("TOTAL_ITEMS", "Total Items")
        dgvReports.Columns.Add("TOTAL_AMOUNT", "Total Amount")
        dgvReports.Columns.Add("PREPARED_BY", "Prepared By")
        dgvReports.Columns.Add("RECEIVED_BY", "Received By")
        dgvReports.Columns.Add("STATUS", "Status")
        dgvReports.Columns.Add("REMARKS", "Remarks")
        dgvReports.Columns.Add("ID", "ID")

        ' ✅ NAKA-HIDE ANG MGA HINDI KAILANGAN
        dgvReports.Columns("ID").Visible = False
        dgvReports.Columns("ACCOUNT_ID").Visible = False

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

            ' ✅ KUNG MAY BRANCH ID — KUNIN LANG YUNG IPINADALA SA IYO
            Dim sql As String
            If String.IsNullOrWhiteSpace(myBranchID) Then
                sql = "
                SELECT ACCOUNT_ID, APPROVED_BY, DR_NUMBER, FROM_BRANCH, FROM_BRANCH_ID, 
                       TO_BRANCH, TO_BRANCH_ID, TRANSFER_DATE, STR_NUMBER, 
                       TOTAL_ITEMS, TOTAL_AMOUNT, PREPARED_BY, RECEIVED_BY, 
                       STATUS, REMARKS, ID
                FROM transfer_data
                ORDER BY TRANSFER_DATE DESC"
            Else
                sql = "
                SELECT ACCOUNT_ID, APPROVED_BY, DR_NUMBER, FROM_BRANCH, FROM_BRANCH_ID, 
                       TO_BRANCH, TO_BRANCH_ID, TRANSFER_DATE, STR_NUMBER, 
                       TOTAL_ITEMS, TOTAL_AMOUNT, PREPARED_BY, RECEIVED_BY, 
                       STATUS, REMARKS, ID
                FROM transfer_data
                WHERE TO_BRANCH_ID = @MyBranchID
                ORDER BY TRANSFER_DATE DESC"
            End If

            Dim cmd As New MySqlCommand(sql, conn)

            If Not String.IsNullOrWhiteSpace(myBranchID) Then
                cmd.Parameters.AddWithValue("@MyBranchID", myBranchID.Trim())
            End If

            Using dr = cmd.ExecuteReader()
                While dr.Read()
                    ' ✅ GAMITIN ANG dr.Item("") — WALANG ERROR!
                    Dim accountId As String = ""
                    If Not dr.Item("ACCOUNT_ID") Is DBNull.Value Then
                        accountId = dr.Item("ACCOUNT_ID").ToString()
                    End If

                    Dim approvedBy As String = ""
                    If Not dr.Item("APPROVED_BY") Is DBNull.Value Then
                        approvedBy = dr.Item("APPROVED_BY").ToString()
                    End If

                    Dim drNum As String = ""
                    If Not dr.Item("DR_NUMBER") Is DBNull.Value Then
                        drNum = dr.Item("DR_NUMBER").ToString()
                    End If

                    Dim fromBranch As String = ""
                    If Not dr.Item("FROM_BRANCH") Is DBNull.Value Then
                        fromBranch = dr.Item("FROM_BRANCH").ToString()
                    End If

                    Dim toBranch As String = ""
                    If Not dr.Item("TO_BRANCH") Is DBNull.Value Then
                        toBranch = dr.Item("TO_BRANCH").ToString()
                    End If

                    Dim strNum As String = ""
                    If Not dr.Item("STR_NUMBER") Is DBNull.Value Then
                        strNum = dr.Item("STR_NUMBER").ToString()
                    End If

                    Dim totalItems As String = ""
                    If Not dr.Item("TOTAL_ITEMS") Is DBNull.Value Then
                        totalItems = dr.Item("TOTAL_ITEMS").ToString()
                    End If

                    Dim preparedBy As String = ""
                    If Not dr.Item("PREPARED_BY") Is DBNull.Value Then
                        preparedBy = dr.Item("PREPARED_BY").ToString()
                    End If

                    Dim receivedBy As String = ""
                    If Not dr.Item("RECEIVED_BY") Is DBNull.Value Then
                        receivedBy = dr.Item("RECEIVED_BY").ToString()
                    End If

                    Dim status As String = ""
                    If Not dr.Item("STATUS") Is DBNull.Value Then
                        status = dr.Item("STATUS").ToString()
                    End If

                    Dim remarks As String = ""
                    If Not dr.Item("REMARKS") Is DBNull.Value Then
                        remarks = dr.Item("REMARKS").ToString()
                    End If

                    Dim idVal As String = dr.Item("ID").ToString()

                    ' ✅ ILAGAY SA DATAGRID
                    dgvReports.Rows.Add(
        accountId,
        approvedBy,
        drNum,
        fromBranch,
        toBranch,
        FormatDate(dr, "TRANSFER_DATE"),
        strNum,
        totalItems,
        FormatAmount(dr, "TOTAL_AMOUNT"),
        preparedBy,
        receivedBy,
        status,
        remarks,
        idVal
    )
                End While
            End Using
        End Using
    End Sub

    ' ✅ AYUSIN ANG PETSA — GAMIT dr.Item() HINDI IsDBNull(STRING)
    Private Function FormatDate(dr As MySqlDataReader, columnName As String) As String
        If dr.Item(columnName) Is DBNull.Value Then
            Return ""
        End If
        Try
            Return Convert.ToDateTime(dr.Item(columnName)).ToString("yyyy-MM-dd HH:mm")
        Catch
            Return dr.Item(columnName).ToString()
        End Try
    End Function

    ' ✅ AYUSIN ANG HALAGA — GAMIT dr.Item() HINDI IsDBNull(STRING)
    Private Function FormatAmount(dr As MySqlDataReader, columnName As String) As String
        If dr.Item(columnName) Is DBNull.Value Then
            Return ""
        End If
        Try
            Return Convert.ToDecimal(dr.Item(columnName)).ToString("N2")
        Catch
            Return dr.Item(columnName).ToString()
        End Try
    End Function

End Class