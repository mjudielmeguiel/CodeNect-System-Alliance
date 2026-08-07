Imports System.IO
Imports MySqlConnector

Public Class frmDiscountRecords

    Private _FilterBranchName As String = ""

    Public Sub SetUser(AccountID As String, BranchID As String)
        LoadIDTypes()
        LoadDiscountRecords()
        AuditLogger.LogAction("OPEN", "Discount Records", $"Opened Discount History for branch: {_FilterBranchName}")
    End Sub

    Private Sub frmDiscountRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStart.Value = New DateTime(2020, 1, 1)
        dtpEnd.Value = DateTime.Now.Date.AddDays(1)

        dgvRecords.AutoGenerateColumns = True
        dgvRecords.AllowUserToAddRows = False
        dgvRecords.ReadOnly = True
        dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecords.RowHeadersVisible = False
        dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        cboIDType.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub LoadIDTypes()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                Dim sql As String = "SELECT DISTINCT `ID_TYPE` FROM `PWD_DISCOUNT` ORDER BY `ID_TYPE`"
                Using cmd As New MySqlCommand(sql, conn)
                    conn.Open()
                    Dim dt As New DataTable()
                    Dim da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)

                    Dim drAll = dt.NewRow()
                    drAll("ID_TYPE") = "All"
                    dt.Rows.InsertAt(drAll, 0)

                    cboIDType.DataSource = dt
                    cboIDType.DisplayMember = "ID_TYPE"
                    cboIDType.ValueMember = "ID_TYPE"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading ID types: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Discount Records", $"Failed to load ID types: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadDiscountRecords()
        Dim dt As New DataTable()

        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                ' ✅ TAMA NA ANG LAHAT NG PANGALAN NG KOLUM — TUGMA SA LARAWAN MO
                Dim sql As String = "
                    SELECT
                        d.`ID` AS `ID`,
                        d.`ACCOUNT_ID` AS `Account ID`,
                        d.`BRANCH_ID` AS `Branch ID`,
                        IFNULL(b.`BRANCH`, '') AS `Branch Name`,
                        d.`ID_TYPE` AS `ID Type`,
                        d.`ID_NUMBER` AS `ID Number`,
                        d.`SUFFIX` AS `Suffix`,
                        d.`FULL_NAME` AS `Full Name`,
                        d.`GENDER` AS `Gender`,
                        d.`ADDRESS` AS `Address`,
                        d.`NATIONALITY` AS `Nationality`,
                        d.`DATEOFBIRTH` AS `Date of Birth`,
                        d.`DATECREATED` AS `Date Created`,
                        d.`DATERECORDED` AS `Date Recorded`,
                        d.`DISCOUNT_PERCENT` AS `Discount %`,
                        d.`DISCOUNT_AMOUNT` AS `Discount Amount`,
                        CASE WHEN d.`VAT_EXEMPT` = 1 THEN 'Yes' ELSE 'No' END AS `VAT Exempt`,
                        d.`TRANSACTION_TOTAL` AS `Transaction Total`,
                        d.`AMOUNT_AFTER_DISCOUNT` AS `Amount After Discount`,
                        d.`OR_NUMBER` AS `OR Number`,
                        d.`TRANSACTION_ID` AS `Transaction ID`
                    FROM `PWD_DISCOUNT` d
                    LEFT JOIN (
                        SELECT DISTINCT `BRANCH`, `BRANCH_ID`
                        FROM `USER_ACCOUNTS`
                    ) AS b ON b.`BRANCH_ID` = d.`BRANCH_ID`
                    WHERE 
                        (@BranchName = 'MAIN OFFICE' OR b.`BRANCH` = @BranchName)
                        AND d.`DATERECORDED` >= @StartDate 
                        AND d.`DATERECORDED` < @EndDate
                "

                If cboIDType.SelectedValue IsNot Nothing AndAlso cboIDType.SelectedValue.ToString() <> "All" Then
                    sql &= " AND d.`ID_TYPE` = @IDType"
                End If

                sql &= " ORDER BY d.`DATERECORDED` DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BranchName", _FilterBranchName)
                    cmd.Parameters.AddWithValue("@StartDate", dtpStart.Value.Date)
                    cmd.Parameters.AddWithValue("@EndDate", dtpEnd.Value.Date.AddDays(1))

                    If cboIDType.SelectedValue IsNot Nothing AndAlso cboIDType.SelectedValue.ToString() <> "All" Then
                        cmd.Parameters.AddWithValue("@IDType", cboIDType.SelectedValue.ToString())
                    End If

                    conn.Open()
                    Dim da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgvRecords.DataSource = dt

            ' ✅ Tamang format ng pera
            If dt.Rows.Count > 0 Then
                For Each col In {"Discount Amount", "Transaction Total", "Amount After Discount"}
                    If dgvRecords.Columns.Contains(col) Then
                        dgvRecords.Columns(col).DefaultCellStyle.Format = "N2"
                        dgvRecords.Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("ERROR", "Discount Records", $"Failed to load discount records: {ex.Message}")
        End Try
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadDiscountRecords()
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        LoadDiscountRecords()
    End Sub

    Private Sub cboIDType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIDType.SelectedIndexChanged
        LoadDiscountRecords()
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvRecords.Rows.Count = 0 Then
            MessageBox.Show("No records to export.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditLogger.LogAction("EXPORT_FAILED", "Discount Records", "Export attempted with empty record list")
            Return
        End If

        Try
            Dim sfd As New SaveFileDialog With {
                .Filter = "CSV File (*.csv)|*.csv",
                .FileName = $"Discount_History_{_FilterBranchName.Replace(" ", "_")}_{Now:yyyyMMdd}"
            }

            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                    Dim headers = dgvRecords.Columns.Cast(Of DataGridViewColumn).Select(Function(c) c.HeaderText)
                    sw.WriteLine(String.Join(",", headers))

                    For Each row As DataGridViewRow In dgvRecords.Rows
                        Dim cells = row.Cells.Cast(Of DataGridViewCell).Select(Function(c) """" & c.Value?.ToString().Replace("""", "") & """")
                        sw.WriteLine(String.Join(",", cells))
                    Next
                End Using
                MessageBox.Show("History saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                AuditLogger.LogAction("EXPORT", "Discount Records", $"Exported discount records to file: {sfd.FileName}")
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AuditLogger.LogAction("EXPORT_FAILED", "Discount Records", $"Export failed: {ex.Message}")
        End Try
    End Sub

End Class