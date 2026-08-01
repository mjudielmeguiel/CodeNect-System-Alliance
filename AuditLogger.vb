Imports MySqlConnector
Imports System.Net

Module AuditLogger
    Public Sub LogAction(actionType As String, moduleName As String, details As String,
                         Optional oldVal As String = Nothing, Optional newVal As String = Nothing)
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    INSERT INTO SYSTEM_AUDIT_LOG 
                    (ACCOUNT_ID, USER_ID, USERNAME, BRANCH_ID, ACTION_TYPE, MODULE_NAME, ACTION_DETAILS, OLD_VALUE, NEW_VALUE, IP_ADDRESS, DEVICE_NAME)
                    VALUES (@aid, @uid, @un, @bid, @act, @mod, @det, @old, @new, @ip, @dev)
                ", conn)

                cmd.Parameters.AddWithValue("@aid", Login.LoggedInAccountID)
                cmd.Parameters.AddWithValue("@uid", Login.LoggedInUserID)
                cmd.Parameters.AddWithValue("@un", Login.LoggedInUsername)
                cmd.Parameters.AddWithValue("@bid", Login.LoggedInBranchID)
                cmd.Parameters.AddWithValue("@act", actionType)
                cmd.Parameters.AddWithValue("@mod", moduleName)
                cmd.Parameters.AddWithValue("@det", details)
                cmd.Parameters.AddWithValue("@old", If(oldVal, DBNull.Value))
                cmd.Parameters.AddWithValue("@new", If(newVal, DBNull.Value))
                cmd.Parameters.AddWithValue("@ip", GetLocalIP())
                cmd.Parameters.AddWithValue("@dev", Environment.MachineName)

                cmd.ExecuteNonQuery()
            End Using
        Catch
            ' Huwag magpakita ng error para hindi makaabala sa user
        End Try
    End Sub

    Private Function GetLocalIP() As String
        Try
            Dim host = Dns.GetHostEntry(Dns.GetHostName())
            Return host.AddressList.FirstOrDefault(Function(a) a.AddressFamily = Net.Sockets.AddressFamily.InterNetwork)?.ToString() Or "Unknown"
        Catch
            Return "Unknown"
        End Try
    End Function
End Module