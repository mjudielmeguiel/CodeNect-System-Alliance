Imports System.Data
Imports System.Data.SqlClient

Public Class frmSTR_Information

    Private connStr As String = DBConnection.connStr

    Public Sub LoadTransferDetails(strNumber As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()

                ' Get header info
                Dim sqlHeader As String = "SELECT * FROM STR_DATA WHERE STR_NUMBER = @DocNo"
                Using cmd As New SqlCommand(sqlHeader, conn)
                    cmd.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = strNumber
                    Dim dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        lblSTRNumber.Text = dr("STR_NUMBER").ToString()
                        lblPreparedBy.Text = dr("PREPARED_BY").ToString()
                        lblFrom.Text = dr("FROM_MV").ToString()
                        lblTo.Text = dr("TO_MV").ToString()
                        lblstatus.Text = dr("STATUS").ToString()
                        lbltotal.Text = Convert.ToDecimal(dr("TOTAL")).ToString("N2")
                    End If
                    dr.Close()
                End Using

                ' Optional: Load items/products
                Dim sqlItems As String = "SELECT * FROM Stock_Transfer WHERE STR_NUMBER = @DocNo"
                Using cmd As New SqlCommand(sqlItems, conn)
                    cmd.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = strNumber
                    Dim dtItems As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dtItems)
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Transfer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class