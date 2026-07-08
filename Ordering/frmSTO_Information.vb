Imports System.Data
Imports System.Data.SqlClient

Public Class frmSTO_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadOrderDetails(poNumber As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim sqlHeader As String = "SELECT * FROM STO_DATA WHERE PO_NUMBER = @DocNo"
                Using cmd As New SqlCommand(sqlHeader, conn)
                    cmd.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber
                    Dim dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        lblPONumber.Text = dr("PO_NUMBER").ToString()
                        lblDR.Text = dr("DR").ToString()
                        lblFrom.Text = dr("FROM").ToString()
                        lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                        lblTo.Text = dr("TO").ToString()
                        lblstatus.Text = dr("STATUS").ToString()
                        lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")
                    End If
                    dr.Close()
                End Using

                ' Optional: Load order items
                Dim sqlItems As String = "SELECT * FROM Stock_Ordering WHERE PO_NUMBER = @DocNo"
                Using cmd As New SqlCommand(sqlItems, conn)
                    cmd.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = poNumber
                    Dim dtItems As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dtItems)

                    ' dgvItems.DataSource = dtItems
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class