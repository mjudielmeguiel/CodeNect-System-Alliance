Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Module DBConnection
    Private ReadOnly settingsFile As String = Path.Combine(Application.StartupPath, "ConnectionSettings.xml")

    Public ReadOnly Property connStr As String
        Get
            If Not File.Exists(settingsFile) Then
                Return "Data Source=192.168.68.105\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Encrypt=False;Trust Server Certificate=True"
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

                Return $"Data Source={ip},{port};Initial Catalog={db};User ID={user};Password={pass};Connect Timeout={oras};"
            Catch
                Return ""
            End Try
        End Get
    End Property

    Public Function TestConnection() As Boolean
        Using conn As New SqlConnection(connStr)
            Try
                conn.Open()
                Return True
            Catch ex As SqlException
                Return False
            Catch
                Return False
            End Try
        End Using
    End Function
End Module