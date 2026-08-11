Imports MySqlConnector
Imports System.Windows.Forms

Module DBConnection
    Public ReadOnly connStr As String = "server=192.168.100.16;Port=3306;user=root;password=;database=codenectdb;SslMode=None;Connect Timeout=30;"

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
                MessageBox.Show("✅ Connection Success via IP Address!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Connection Failed:" & vbCrLf & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
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