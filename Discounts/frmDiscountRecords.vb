Imports System.Data.SqlClient
Imports System.IO

Public Class frmDiscountRecords

    Private _FilterBranchName As String = ""

    Public Sub SetUser(AccountID As String, BranchID As String)
        ' Kunin ang pangalan ng branch mula sa status bar ng Dashboard
        _FilterBranchName = DashBoard.ToolStripStatusLabel4.Text.Trim()
        LoadIDTypes()
        LoadDiscountRecords()
    End Sub

    Private Sub frmDiscountRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sakop ng petsa mula simula hanggang ngayon
        dtpStart.Value = New DateTime(2020, 1, 1)
        dtpEnd.Value = DateTime.Now.Date.AddDays(1)

        ' Ayos ng itsura ng listahan
        dgvRecords.AutoGenerateColumns = True
        dgvRecords.AllowUserToAddRows = False
        dgvRecords.ReadOnly = True
        dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecords.RowHeadersVisible = False
        dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        ' Huwag papalitan ang laman ng combo box
        cboIDType.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' I-load ang listahan ng mga uri ng ID
    Private Sub LoadIDTypes()
        Try
            Using conn As New SqlConnection(connStr)
                Dim sql As String = "SELECT DISTINCT ID_Type FROM PWD_Discount ORDER BY ID_Type"
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    ' Maglagay ng pagpipilian na "Lahat"
                    dt.Rows.InsertAt(dt.NewRow(), 0)
                    dt.Rows(0)("ID_Type") = "All"

                    cboIDType.DataSource = dt
                    cboIDType.DisplayMember = "ID_Type"
                    cboIDType.ValueMember = "ID_Type"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error sa pagkuha ng listahan ng ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Ipakita ang kasaysayan ng transaksyon nang walang doble
    Private Sub LoadDiscountRecords()
        Dim dt As New DataTable()

        Try
            Using conn As New SqlConnection(connStr)
                ' ✅ Gamit ang OUTER APPLY para kumuha ng ISANG pangalan lang ng branch
                ' ✅ Hindi na magdodoble ang iisang transaksyon
                Dim sql As String = "
                    SELECT
                        d.PWD_ID AS [PWD ID],
                        d.Account_ID AS [Account ID],
                        d.Branch_ID AS [Branch ID],
                        ISNULL(b.BRANCH, '') AS [Branch Name],
                        d.ID_Type AS [ID Type],
                        d.ID_Number AS [ID Number],
                        d.Surname AS [Surname],
                        d.FirstName AS [First Name],
                        d.MiddleName AS [Middle Name],
                        d.Suffix AS [Suffix],
                        d.Gender AS [Gender],
                        d.FullAddress AS [Full Address],
                        d.ContactNumber AS [Contact Number],
                        d.Email AS [Email],
                        d.DateCreated AS [Date Created],
                        d.DateRecorded AS [Date Recorded],
                        d.DateOfBirth AS [Date of Birth],
                        d.Discount_Percent AS [Discount %],
                        d.Discount_Amount AS [Discount Amount],
                        CASE WHEN d.VAT_Exempt = 1 THEN 'Yes' ELSE 'No' END AS [VAT Exempt],
                        d.Transaction_Total AS [Transaction Total],
                        d.Amount_After_Discount AS [Amount After Discount],
                        d.OR_Number AS [OR Number]
                    FROM PWD_Discount d
                    OUTER APPLY (
                        SELECT TOP 1 BRANCH 
                        FROM User_Accounts u 
                        WHERE u.BRANCH_ID = d.Branch_ID
                    ) AS b
                    WHERE 
                        (@BranchName = 'MAIN OFFICE' OR b.BRANCH = @BranchName)
                        AND d.DateRecorded >= @StartDate 
                        AND d.DateRecorded < @EndDate
                "

                ' Maglagay ng filter ayon sa uri ng ID kung hindi "All" ang napili
                If cboIDType.SelectedValue IsNot Nothing AndAlso cboIDType.SelectedValue.ToString() <> "All" Then
                    sql &= " AND d.ID_Type = @IDType"
                End If

                ' Ayusin ang pagkakasunod-sunod mula pinakabago hanggang luma
                sql &= " ORDER BY d.DateRecorded DESC"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BranchName", _FilterBranchName)
                    cmd.Parameters.AddWithValue("@StartDate", dtpStart.Value.Date)
                    cmd.Parameters.AddWithValue("@EndDate", dtpEnd.Value.Date.AddDays(1))

                    If cboIDType.SelectedValue IsNot Nothing AndAlso cboIDType.SelectedValue.ToString() <> "All" Then
                        cmd.Parameters.AddWithValue("@IDType", cboIDType.SelectedValue.ToString())
                    End If

                    conn.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgvRecords.DataSource = dt

            ' Ayos ng itsura ng mga numero
            If dt.Rows.Count > 0 Then
                dgvRecords.Columns("Discount Amount").DefaultCellStyle.Format = "N2"
                dgvRecords.Columns("Transaction Total").DefaultCellStyle.Format = "N2"
                dgvRecords.Columns("Amount After Discount").DefaultCellStyle.Format = "N2"
            End If

        Catch ex As Exception
            MessageBox.Show("Error sa pagkuha ng talaan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Awtomatikong mag-refresh kapag binago ang petsa o uri ng ID
    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadDiscountRecords()
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        LoadDiscountRecords()
    End Sub

    Private Sub cboIDType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIDType.SelectedIndexChanged
        LoadDiscountRecords()
    End Sub

    ' Pag-save ng listahan bilang CSV file
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If dgvRecords.Rows.Count = 0 Then
            MessageBox.Show("Walang talaan na maii-export.", "Paalala", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim sfd As New SaveFileDialog With {
                .Filter = "CSV File (*.csv)|*.csv",
                .FileName = $"Discount_History_{_FilterBranchName.Replace(" ", "_")}_{Now:yyyyMMdd}"
            }

            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                    ' Mga pamagat ng kolumna
                    Dim headers = dgvRecords.Columns.Cast(Of DataGridViewColumn).Select(Function(c) c.HeaderText)
                    sw.WriteLine(String.Join(",", headers))

                    ' Mga laman ng bawat transaksyon
                    For Each row As DataGridViewRow In dgvRecords.Rows
                        Dim cells = row.Cells.Cast(Of DataGridViewCell).Select(Function(c) """" & c.Value.ToString().Replace("""", """""") & """")
                        sw.WriteLine(String.Join(",", cells))
                    Next
                End Using
                MessageBox.Show("Ang kasaysayan ay matagumpay na naisave!", "Tagumpay", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error sa pag-save: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class