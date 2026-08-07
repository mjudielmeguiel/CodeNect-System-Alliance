Imports System.Data
Imports MySqlConnector

Public Class frmProductlistShelftag

    Private connStr As String = DBConnection.connStr
    Dim dtSource As New DataTable()

    Private Sub frmProductlistShelftag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sql As String = "SELECT `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE` " &
                                    "FROM `inventory_information` " &
                                    "WHERE `BRANCH_ID` = @BID " &
                                    "ORDER BY `BRAND`, `DESCRIPTIONS`"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@BID", Login.LoggedInBranchID)

                    dtSource.Clear()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtSource)
                    End Using

                    dgvProductList.AutoGenerateColumns = True
                    dgvProductList.DataSource = dtSource
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim filterText As String = txtSearch.Text.Trim()

        If String.IsNullOrWhiteSpace(filterText) Then
            dgvProductList.DataSource = dtSource
        Else
            Dim dv As New DataView(dtSource)
            dv.RowFilter = "CONVERT(`BARCODE`, System.String) LIKE '%" & filterText & "%' " &
                           "OR CONVERT(`SKU`, System.String) LIKE '%" & filterText & "%' " &
                           "OR CONVERT(`DESCRIPTIONS`, System.String) LIKE '%" & filterText & "%'"
            dgvProductList.DataSource = dv
        End If
    End Sub

    Private Sub dgvProductList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductList.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim selRow As DataGridViewRow = dgvProductList.Rows(e.RowIndex)

        Dim bc As String = selRow.Cells("BARCODE").Value?.ToString().Trim()
        Dim sku As String = selRow.Cells("SKU").Value?.ToString().Trim()
        Dim brand As String = selRow.Cells("BRAND").Value?.ToString().Trim()
        Dim desc As String = selRow.Cells("DESCRIPTIONS").Value?.ToString().Trim()
        Dim sz As String = selRow.Cells("SIZE").Value?.ToString().Trim()
        Dim prc As Decimal = CDec(selRow.Cells("PRICE").Value)

        Dim shelfForm As ShelfTag_Printer = TryCast(Application.OpenForms("ShelfTag_Printer"), ShelfTag_Printer)

        If shelfForm IsNot Nothing Then
            shelfForm.AddFromProductList(bc, sku, brand, desc, sz, prc)
            Me.Close()
        Else
            MessageBox.Show("Open Shelftag Printer first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        txtSearch.Clear()
        LoadProducts()
    End Sub

End Class