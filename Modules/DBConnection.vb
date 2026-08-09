Imports MySqlConnector
Imports System.Windows.Forms

Module DBConnection
    Public ReadOnly connStr As String = "server=192.168.100.16;user=root;password=;database=codenectdb;SslMode=None;"

    Public CurrentUserBranchID As String = ""
    Public CurrentUserAccountID As String = ""
    Public CurrentLoggedInUser As String = ""
    Public CurrentUserType As String = ""

    Public CurrentVendorCode As String = Nothing
    Public CurrentVendorName As String = Nothing

    Public Function TestConnection() As Boolean
        Try
            Using testConn As New MySqlConnection(connStr)
                testConn.Open()
                MessageBox.Show("Connection Success!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Public Sub SetVendorInfo(vendorCode As String, vendorName As String)
        CurrentVendorCode = If(String.IsNullOrWhiteSpace(vendorCode), Nothing, vendorCode.Trim())
        CurrentVendorName = If(String.IsNullOrWhiteSpace(vendorName), Nothing, vendorName.Trim())
    End Sub

    Public Sub ClearVendorInfo()
        CurrentVendorCode = Nothing
        CurrentVendorName = Nothing
    End Sub

End Module