Imports MySqlConnector

Public Class frmVendorHome

    Public Shared VendorID As String = ""
    Public Shared VendorName As String = ""
    Public Shared VendorCode As String = ""

    Private Sub frmVendorHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVendorNameHome.Text = VendorName
        LoadDashboardStats()
    End Sub

    Public Sub RefreshDashboard()
        LoadDashboardStats()
    End Sub

    Private Sub LoadDashboardStats()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                lblTotalProducts.Text = GetCount(conn, "SELECT COUNT(*) FROM `vendor_products` WHERE `VENDOR_CODE` = @vcode", VendorCode).ToString()

                ' TODO: Create these tables first in your database
                lblPendingOrders.Text = "0"
                lblCompletedOrders.Text = "0"
                lblTotalReturns.Text = "0"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading Dashboard: " & ex.Message, "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function GetCount(conn As MySqlConnection, sql As String, vcode As String) As Integer
        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@vcode", vcode)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
        End Using
        Return 0
    End Function

End Class