Imports MySqlConnector

Public Class frmOrderDetails

    Public Property PO_NUMBER As String = ""
    Private ReadOnly connStr As String = DBConnection.connStr

    Private Sub frmOrderDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrWhiteSpace(PO_NUMBER) Then
            MessageBox.Show("Invalid PO Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Me.Text = $"Order Details — {PO_NUMBER}"
        lblPONumber.Text = $"PO Number: {PO_NUMBER}"

        SetupDataGridView()
        LoadOrderItems()
    End Sub

    Private Sub SetupDataGridView()
        dgvOrderDetails.Columns.Clear()
        dgvOrderDetails.AllowUserToAddRows = False
        dgvOrderDetails.RowTemplate.Height = 30
        dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' ✅ PINAKA-SIMPLE: F2 o Pag-type = PWEDE NA AGAD
        dgvOrderDetails.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        dgvOrderDetails.Columns.Add("colBarcode", "Barcode")
        dgvOrderDetails.Columns.Add("colBrand", "Brand")
        dgvOrderDetails.Columns.Add("colDescription", "Description")
        dgvOrderDetails.Columns.Add("colSize", "Size")
        dgvOrderDetails.Columns.Add("colPrice", "Unit Price")
        dgvOrderDetails.Columns.Add("colQty", "Quantity ✏️")
        dgvOrderDetails.Columns.Add("colTotal", "Line Total")

        ' ✅ LAHAT READ-ONLY — MALIBAN SA QUANTITY
        dgvOrderDetails.Columns("colBarcode").ReadOnly = True
        dgvOrderDetails.Columns("colBrand").ReadOnly = True
        dgvOrderDetails.Columns("colDescription").ReadOnly = True
        dgvOrderDetails.Columns("colSize").ReadOnly = True
        dgvOrderDetails.Columns("colPrice").ReadOnly = True
        dgvOrderDetails.Columns("colQty").ReadOnly = False ' ✅ DITO LANG PWEDE!
        dgvOrderDetails.Columns("colTotal").ReadOnly = True

        ' Format lang — walang kulay, walang error!
        dgvOrderDetails.Columns("colPrice").DefaultCellStyle.Format = "N2"
        dgvOrderDetails.Columns("colPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOrderDetails.Columns("colQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvOrderDetails.Columns("colTotal").DefaultCellStyle.Format = "N2"
        dgvOrderDetails.Columns("colTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' ✅ HANDLERS
        AddHandler dgvOrderDetails.CellEndEdit, AddressOf dgvOrderDetails_CellEndEdit
        AddHandler dgvOrderDetails.CellValidating, AddressOf dgvOrderDetails_CellValidating
    End Sub

    ' ✅ NUMERO LANG ANG PWEDENG ILAGAY
    Private Sub dgvOrderDetails_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        If e.ColumnIndex = dgvOrderDetails.Columns("colQty").Index Then
            Dim input As String = e.FormattedValue.ToString().Trim()
            Dim qty As Integer

            If Not Integer.TryParse(input, qty) OrElse qty < 1 Then
                MessageBox.Show("Ilagay lang ang numero na 1 o mas mataas!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
                Return
            End If
        End If
    End Sub

    ' ✅ AWTOMATIK NAG-COMPUTE NG TOTAL KAPAG BINAGO ANG QTY
    Private Sub dgvOrderDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = dgvOrderDetails.Columns("colQty").Index AndAlso e.RowIndex >= 0 Then
            Try
                Dim qty As Integer = Convert.ToInt32(dgvOrderDetails.Rows(e.RowIndex).Cells("colQty").Value)
                Dim price As Decimal = Convert.ToDecimal(dgvOrderDetails.Rows(e.RowIndex).Cells("colPrice").Value)
                dgvOrderDetails.Rows(e.RowIndex).Cells("colTotal").Value = (qty * price).ToString("N2")
            Catch ex As Exception
                MessageBox.Show("Maling numero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadOrderItems()
        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                Dim sql As String = "
                    SELECT BARCODE, BRAND, DESCRIPTIONS, SIZE, PRICE, ORDER_QTY, TOTAL
                    FROM stock_ordering
                    WHERE PO_NUMBER = @PO
                    ORDER BY ID"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@PO", PO_NUMBER)

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        dgvOrderDetails.Rows.Clear()

                        Do While dr.Read()
                            Dim barcode = dr("BARCODE").ToString()
                            Dim brand = dr("BRAND").ToString()
                            Dim desc = dr("DESCRIPTIONS").ToString()
                            Dim size = dr("SIZE").ToString()
                            Dim price = Convert.ToDecimal(dr("PRICE"))
                            Dim qty = Convert.ToInt32(dr("ORDER_QTY"))
                            Dim lineTotal = Convert.ToDecimal(dr("TOTAL"))

                            dgvOrderDetails.Rows.Add(barcode, brand, desc, size, price, qty, lineTotal)
                        Loop
                    End Using
                End Using
            End Using

            If dgvOrderDetails.Rows.Count = 0 Then
                MessageBox.Show("No items found for this PO.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading Order Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ ORDER PLACED BUTTON
    Private Sub btnOrderPlaced_Click(sender As Object, e As EventArgs) Handles btnOrderPlaced.Click
        If MessageBox.Show("I-saave ang binago at markahan as ORDER PLACED?",
                           "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                Using tran = conn.BeginTransaction()

                    ' ✅ I-update ang bawat produkto
                    For Each row As DataGridViewRow In dgvOrderDetails.Rows
                        Dim barcode = row.Cells("colBarcode").Value.ToString()
                        Dim newQty = Convert.ToInt32(row.Cells("colQty").Value)
                        Dim newTotal = Convert.ToDecimal(row.Cells("colTotal").Value)

                        Dim cmdUpdateItem As New MySqlCommand("
                            UPDATE stock_ordering 
                            SET ORDER_QTY = @QTY, TOTAL = @TOTAL
                            WHERE PO_NUMBER = @PO AND BARCODE = @BARCODE", conn, tran)

                        cmdUpdateItem.Parameters.AddWithValue("@QTY", newQty)
                        cmdUpdateItem.Parameters.AddWithValue("@TOTAL", newTotal)
                        cmdUpdateItem.Parameters.AddWithValue("@PO", PO_NUMBER)
                        cmdUpdateItem.Parameters.AddWithValue("@BARCODE", barcode)
                        cmdUpdateItem.ExecuteNonQuery()
                    Next

                    Dim cmdUpdateStatus As New MySqlCommand("
                        UPDATE sto_data 
                        SET STATUS = 'Order Placed' 
                        WHERE PO_NUMBER = @PO", conn, tran)

                    cmdUpdateStatus.Parameters.AddWithValue("@PO", PO_NUMBER)
                    cmdUpdateStatus.ExecuteNonQuery()

                    tran.Commit()
                End Using
            End Using

            MessageBox.Show("✅ NA-SAVE! Order marked as ORDER PLACED!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class