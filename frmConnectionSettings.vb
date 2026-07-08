Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class frmConnectionSettings

    Private Sub DashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(Login.LoggedInUserID) Then
            SetAccountOffline()
        End If
    End Sub

    Private Sub SetAccountOffline()
        If String.IsNullOrEmpty(Login.LoggedInUserID) Then Return

        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmdText As String = "UPDATE dbo.User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @UserID"

                Using cmd As New SqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@UserID", Login.LoggedInUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private settingsFile As String = Path.Combine(Application.StartupPath, "ConnectionSettings.xml")

    Private Sub UpdateFullConnectionString()
        Dim serverPart As String = txtServerIP.Text.Trim()
        Dim portPart As String = If(String.IsNullOrWhiteSpace(txtPort.Text.Trim()), "", "," & txtPort.Text.Trim())

        rchFullConnection.Text =
            $"Data Source={serverPart}{portPart};" &
            $"Initial Catalog={txtDatabase.Text.Trim()};" &
            $"User ID={txtUser.Text.Trim()};" &
            $"Password={txtPassword.Text.Trim()};" &
            $"Connect Timeout={txtTimeout.Text.Trim()};"
    End Sub

    Private Sub frmConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(settingsFile) Then
            Try
                Dim doc As New XmlDocument()
                doc.Load(settingsFile)
                Dim root = doc.DocumentElement

                txtServerIP.Text = root.SelectSingleNode("ServerIP")?.InnerText
                txtPort.Text = root.SelectSingleNode("Port")?.InnerText
                txtDatabase.Text = root.SelectSingleNode("Database")?.InnerText
                txtUser.Text = root.SelectSingleNode("DBUser")?.InnerText
                txtPassword.Text = root.SelectSingleNode("DBPass")?.InnerText
                txtTimeout.Text = root.SelectSingleNode("Timeout")?.InnerText
            Catch
                SetDefaultValues()
            End Try
        Else
            SetDefaultValues()
        End If

        UpdateFullConnectionString()
    End Sub

    Private Sub SetDefaultValues()
        txtServerIP.Text = "192.168.68.105\SQLEXPRESS"
        txtPort.Text = "1433"
        txtDatabase.Text = "CodeNectDB"
        txtUser.Text = "CodeNect_Database"
        txtPassword.Text = "Password1*"
        txtTimeout.Text = "15"
    End Sub

    Private Sub txtServerIP_TextChanged(sender As Object, e As EventArgs) Handles txtServerIP.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub txtPort_TextChanged(sender As Object, e As EventArgs) Handles txtPort.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub txtDatabase_TextChanged(sender As Object, e As EventArgs) Handles txtDatabase.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub txtTimeout_TextChanged(sender As Object, e As EventArgs) Handles txtTimeout.TextChanged
        UpdateFullConnectionString()
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(rchFullConnection.Text) Then
            MessageBox.Show("Connection string is empty!", "Warning", MessageBoxButtons.OK)
            Return
        End If

        Try
            Using conn As New SqlConnection(rchFullConnection.Text)
                conn.Open()
                MessageBox.Show("Successfully connected to the database!", "Connection OK", MessageBoxButtons.OK)
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection failed:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtServerIP.Text) OrElse String.IsNullOrWhiteSpace(txtDatabase.Text) Then
            MessageBox.Show("Please enter Server IP and Database Name!", "Missing Information", MessageBoxButtons.OK)
            Return
        End If

        Try
            Dim doc As New XmlDocument()
            Dim root = doc.CreateElement("Settings")

            root.AppendChild(MakeNode(doc, "ServerIP", txtServerIP.Text.Trim()))
            root.AppendChild(MakeNode(doc, "Port", txtPort.Text.Trim()))
            root.AppendChild(MakeNode(doc, "Database", txtDatabase.Text.Trim()))
            root.AppendChild(MakeNode(doc, "DBUser", txtUser.Text.Trim()))
            root.AppendChild(MakeNode(doc, "DBPass", txtPassword.Text.Trim()))
            root.AppendChild(MakeNode(doc, "Timeout", txtTimeout.Text.Trim()))

            doc.AppendChild(root)
            doc.Save(settingsFile)

            MessageBox.Show("Settings saved successfully! The system will use these values.", "Saved", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Failed to save: " & ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Function MakeNode(doc As XmlDocument, name As String, value As String) As XmlNode
        Dim newNode = doc.CreateElement(name)
        newNode.InnerText = value
        Return newNode
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class