Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports MySqlConnector

Module DBConnection

    Private ReadOnly settingsFile As String = Path.Combine(Application.StartupPath, "ConnectionSettings.xml")

    Public ReadOnly Property connStr As String
        Get
            If Not File.Exists(settingsFile) Then
                ' Default connection string for XAMPP MySQL
                ' Port = 3306 (default) or 3307 if you changed it earlier
                Return "Server=localhost;Port=3306;Database=CodeNectDB;User ID=root;Password=;SslMode=None;Allow User Variables=True;"
            End If

            Try
                Dim doc As New XmlDocument()
                doc.Load(settingsFile)
                Dim root = doc.DocumentElement

                Dim ip = root.SelectSingleNode("ServerIP").InnerText
                Dim port = root.SelectSingleNode("Port").InnerText
                Dim db = root.SelectSingleNode("Database").InnerText
                Dim user = root.SelectSingleNode("DBUser").InnerText
                Dim pass = root.SelectSingleNode("DBPass").InnerText
                Dim oras = root.SelectSingleNode("Timeout").InnerText

                Return $"Server={ip};Port={port};Database={db};User ID={user};Password={pass};Connect Timeout={oras};SslMode=None;"
            Catch
                Return ""
            End Try
        End Get
    End Property

    Public Function TestConnection() As Boolean
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Return True
            Catch ex As MySqlException
                MessageBox.Show("Connection Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

End Module