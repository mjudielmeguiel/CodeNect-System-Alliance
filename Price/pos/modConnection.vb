Imports System.Data.SqlClient

Module modConnection
    Public connStr As String = "Data Source=192.168.68.103\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Encrypt=False;TrustServerCertificate=True"

    Public Sub SetUserOnline(username As String)
        Try
            Using conn As New SqlConnection(connStr)
                Dim query As String = "UPDATE User_Accounts SET STATUS = 'ONLINE' WHERE USERNAME = @User"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@User", username.Trim())
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status to ONLINE: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetUserOffline(username As String)
        Try
            Using conn As New SqlConnection(connStr)
                Dim query As String = "UPDATE User_Accounts SET STATUS = 'OFFLINE' WHERE USERNAME = @User"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@User", username.Trim())
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status to OFFLINE: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module