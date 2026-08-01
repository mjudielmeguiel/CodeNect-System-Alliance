Imports MySqlConnector

Module DBConnection
    Public ReadOnly connStr As String = "server=192.168.100.16;user=root;password=;database=codenectdb;SslMode=None;"
    Public CurrentUserBranchID As String = ""

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
End Module