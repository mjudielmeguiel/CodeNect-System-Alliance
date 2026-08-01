Imports System.Data
Imports MySqlConnector

Public Class frmSTR_Information
    Private connStr As String = DBConnection.connStr
    Private dtAllItems As New DataTable()

    Public Sub LoadTransferDetails(strNumber As String)
        Try
            strNumber = strNumber.Trim().PadLeft(6, "0"c)
            AuditLogger.LogAction("LOAD_STR", "STRInfo", $"Loading STR details | No: {strNumber}")

            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sqlHeader As String = "SELECT * FROM `STR_DATA` WHERE `STR_NUMBER` = @DocNo"
                Using cmdHeader As New MySqlCommand(sqlHeader, conn)
                    cmdHeader.Parameters.AddWithValue("@DocNo", strNumber)
                    Using dr As MySqlDataReader = cmdHeader.ExecuteReader()
                        If dr.Read() Then
                            lblSTRNumber.Text = dr("STR_NUMBER").ToString()
                            lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                            lblFrom.Text = dr("FROM_MV").ToString()
                            lblTo.Text = dr("TO_MV").ToString()
                            lblstatus.Text = dr("STATUS").ToString()
                            lblDR.Text = If(dr.IsDBNull(dr.GetOrdinal("DR")), "", dr("DR").ToString())
                            lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")
                        Else
                            MessageBox.Show("No record")
                            AuditLogger.LogAction("STR_NOTFOUND", "STRInfo", $"No STR record found | No: {strNumber}")
                            Return
                        End If
                    End Using
                End Using

                Dim sqlItems As String = "SELECT `BARCODE`, `SKU`, `BRAND`, `DESCRIPTIONS`, `SIZE`, `PRICE`, `ORDER_QTY`, `STOCK_IN`, `STOCK_OUT`, `VENDOR_CODE`, `VENDOR_NAME`, `REMARKS`, `TOTAL` 
                                          FROM `Stock_Transfer` WHERE `STR_NUMBER` = @DocNo"
                Using cmdItems As New MySqlCommand(sqlItems, conn)
                    cmdItems.Parameters.AddWithValue("@DocNo", strNumber)
                    dtAllItems.Clear()
                    Using da As New MySqlDataAdapter(cmdItems)
                        da.Fill(dtAllItems)
                    End Using

                    dgvItems.AutoGenerateColumns = True
                    dgvItems.DataSource = Nothing
                    dgvItems.DataSource = dtAllItems

                    If dtAllItems.Rows.Count > 0 Then
                        FormatGrid()
                        AuditLogger.LogAction("STR_ITEMS_LOADED", "STRInfo", $"Loaded {dtAllItems.Rows.Count} items | STR No: {strNumber}")
                    Else
                        MessageBox.Show("Items: " & dtAllItems.Rows.Count.ToString())
                        AuditLogger.LogAction("STR_NOITEMS", "STRInfo", $"STR has no line items | No: {strNumber}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            AuditLogger.LogAction("ERROR", "STRInfo", $"Load failed | Error: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatGrid()
        With dgvItems
            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            If .Columns.Contains("BARCODE") Then .Columns("BARCODE").HeaderText = "BARCODE"
            If .Columns.Contains("SKU") Then .Columns("SKU").HeaderText = "SKU"
            If .Columns.Contains("BRAND") Then .Columns("BRAND").HeaderText = "BRAND"
            If .Columns.Contains("DESCRIPTIONS") Then .Columns("DESCRIPTIONS").HeaderText = "DESCRIPTION"
            If .Columns.Contains("SIZE") Then .Columns("SIZE").HeaderText = "SIZE"
            If .Columns.Contains("PRICE") Then
                .Columns("PRICE").HeaderText = "PRICE"
                .Columns("PRICE").DefaultCellStyle.Format = "N2"
            End If
            If .Columns.Contains("ORDER_QTY") Then .Columns("ORDER_QTY").HeaderText = "QTY"
            If .Columns.Contains("STOCK_IN") Then .Columns("STOCK_IN").HeaderText = "STOCK IN"
            If .Columns.Contains("STOCK_OUT") Then .Columns("STOCK_OUT").HeaderText = "STOCK OUT"
            If .Columns.Contains("VENDOR_CODE") Then .Columns("VENDOR_CODE").HeaderText = "VENDOR CODE"
            If .Columns.Contains("VENDOR_NAME") Then .Columns("VENDOR_NAME").HeaderText = "VENDOR NAME"
            If .Columns.Contains("REMARKS") Then .Columns("REMARKS").HeaderText = "REMARKS"
            If .Columns.Contains("TOTAL") Then
                .Columns("TOTAL").HeaderText = "TOTAL"
                .Columns("TOTAL").DefaultCellStyle.Format = "N2"
            End If
        End With
    End Sub

    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        Try
            If dtAllItems Is Nothing OrElse dtAllItems.Rows.Count = 0 Then Exit Sub
            Dim dv As New DataView(dtAllItems)
            dv.RowFilter = String.Format("BARCODE LIKE '%{0}%'", txtBarcode.Text.Trim().Replace("'", "''"))
            dgvItems.DataSource = dv
        Catch
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        AuditLogger.LogAction("CLOSE_STR", "STRInfo", "STR Information form closed")
        Me.Close()
    End Sub

    Private Sub frmSTR_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvItems.DataSource = Nothing
        dtAllItems.Clear()
        AuditLogger.LogAction("OPEN_STR_INFO", "STRInfo", "Opened STR Information form")
    End Sub
End Class