Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Devices

Public Class AI_RecoveryChat

    '============================
    ' CONFIG
    '============================
    Private Const DB_PATH As String = "C:\Users\mjudi\Desktop\Data\CODENECT.accdb"
    Private ReadOnly connStr As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DB_PATH}"
    Private Const PIN_LENGTH As Integer = 8
    Private Const DEFAULT_PIN As String = "12345678"
    Public CurrentLoggedUser As String = ""
    Private conversationStep As ConversationState = ConversationState.MainMenu
    Private tempPassword As String = ""
    Private selectedOption As String = ""
    Private AdminOnline As Boolean = False
    Private inCommonConversation As Boolean = False
    Private rnd As New Random() ' shared random instance

    ' PIN security
    Private failedPinAttempts As Integer = 0
    Private Const MaxPinAttempts As Integer = 3
    Private Const PinBlockMinutes As Integer = 1
    Private blockEndTime As DateTime = DateTime.MinValue

    Private Enum ConversationState
        MainMenu = 0
        AwaitingNewPassword = 1
        AwaitingConfirmPassword = 2
    End Enum

    '============================
    ' FORM LOAD
    '============================
    Private Sub AI_RecoveryChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.Controls.Clear()
        Dim status As String = ""

        Try
            Using conn As New OleDbConnection(connStr)
                Dim cmd As New OleDbCommand("SELECT [Status] FROM Users WHERE Username=?", conn)
                cmd.Parameters.AddWithValue("?", CurrentLoggedUser)
                conn.Open()
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    status = reader("Status").ToString()
                End If
            End Using
        Catch ex As Exception
            AddMessageBubble("AI", "❌ Database connection failed: " & ex.Message)
            Exit Sub
        End Try

        If status = "Blocked" Then
            AddMessageBubble("AI", "Your account is blocked. Please reset your PIN to recover your account.")
            AddMessageBubble("AI", $"Options: 1️⃣ Change PIN | 2️⃣ Reset to Default PIN ({DEFAULT_PIN})")
            conversationStep = ConversationState.MainMenu
        Else
            ShowMainMenu()
        End If

        TxtMessage.Focus()
    End Sub

    '============================
    ' MAIN MENU
    '============================
    Private Sub ShowMainMenu()
        AddMessageBubble("AI", "Hello! I am your CODENECT AI Assistant 🤖")
        AddMessageBubble("AI", $"Options: 1️⃣ Change PIN | 2️⃣ Reset to Default PIN ({DEFAULT_PIN})")
        AddMessageBubble("AI", "Or chat normally. Type **HI** to start a friendly conversation.")
        conversationStep = ConversationState.MainMenu
    End Sub

    '============================
    ' ENTER KEY SEND
    '============================
    Private Sub TxtMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMessage.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        e.SuppressKeyPress = True

        Dim msg As String = TxtMessage.Text.Trim()
        If msg = "" Then Exit Sub
        AddMessageBubble("User", msg)
        TxtMessage.Clear()

        Dim input As String = msg.ToLower()

        ' ---------- PIN Recovery ----------
        Select Case conversationStep
            Case ConversationState.MainMenu
                ProcessOptionSelection(input)
            Case ConversationState.AwaitingNewPassword
                ProcessNewPIN(input)
            Case ConversationState.AwaitingConfirmPassword
                ProcessConfirmPIN(input)
        End Select
    End Sub

    '============================
    ' ADD MESSAGE BUBBLE
    '============================
    Private Sub AddMessageBubble(sender As String, msg As String)
        Dim bubble As New Panel With {
            .AutoSize = True,
            .Padding = New Padding(10),
            .Margin = New Padding(5),
            .MaximumSize = New Size(FlowLayoutPanel1.Width - 30, 0)
        }

        Dim lbl As New Label With {
            .Text = msg,
            .ForeColor = Color.White,
            .AutoSize = True
        }

        Dim lblTime As New Label With {
            .Text = Now.ToString("HH:mm"),
            .ForeColor = Color.LightGray,
            .Font = New Font("Arial", 7),
            .AutoSize = True
        }

        bubble.Controls.Add(lbl)
        bubble.Controls.Add(lblTime)

        If sender = "User" Then
            bubble.BackColor = Color.Green
            bubble.Anchor = AnchorStyles.Right
        Else
            bubble.BackColor = Color.DarkRed
            bubble.Anchor = AnchorStyles.Left
        End If

        FlowLayoutPanel1.Controls.Add(bubble)
        FlowLayoutPanel1.ScrollControlIntoView(bubble)
    End Sub

    '============================
    ' PIN RECOVERY / UPDATE
    '============================
    Private Sub ProcessOptionSelection(input As String)
        If input = "1" Then
            selectedOption = "change"
            Dim autoPin = GenerateRandomPIN()
            AddMessageBubble("AI", $"Changing PIN for: {CurrentLoggedUser}")
            AddMessageBubble("AI", $"Suggested random 8-digit PIN: {autoPin}")
            AddMessageBubble("AI", "Enter your new 8-digit PIN:")
            conversationStep = ConversationState.AwaitingNewPassword
        ElseIf input = "2" Then
            selectedOption = "default"
            ResetToDefaultPIN()
        Else
            AddMessageBubble("AI", "Invalid option. Select 1 or 2.")
        End If
    End Sub

    Private Sub ProcessNewPIN(newPin As String)
        tempPassword = newPin

        ' Check block
        If blockEndTime > DateTime.Now Then
            Dim remaining = blockEndTime - DateTime.Now
            AddMessageBubble("AI", $"⛔ You are temporarily blocked. Try again in {remaining.Seconds} seconds.")
            Exit Sub
        End If

        ' Must be exactly 8 digits
        If tempPassword.Length <> PIN_LENGTH OrElse Not Regex.IsMatch(tempPassword, "^\d{8}$") Then
            failedPinAttempts += 1
            CheckPinLockout()
            AddMessageBubble("AI", "❌ PIN must be exactly 8 numeric digits. Try again:")
            Exit Sub
        End If

        ' Weak PIN check
        If IsWeakPIN(tempPassword) Then
            AddMessageBubble("AI", "⚠ PIN too weak. Choose another 8-digit PIN:")
            Exit Sub
        End If

        failedPinAttempts = 0
        AddMessageBubble("AI", "✅ PIN accepted. Confirm your PIN:")
        conversationStep = ConversationState.AwaitingConfirmPassword
    End Sub

    Private Sub ProcessConfirmPIN(confirmPin As String)
        If confirmPin <> tempPassword Then
            AddMessageBubble("AI", "❌ PINs do not match. Enter new PIN again:")
            conversationStep = ConversationState.AwaitingNewPassword
        Else
            SavePIN(tempPassword)
        End If
    End Sub

    Private Sub SavePIN(pin As String)
        If UpdatePIN(CurrentLoggedUser, pin) Then
            AddMessageBubble("AI", "✅ PIN updated successfully!")
        Else
            AddMessageBubble("AI", "❌ Failed to update PIN.")
        End If
    End Sub

    Private Sub ResetToDefaultPIN()
        If UpdatePIN(CurrentLoggedUser, DEFAULT_PIN) Then
            AddMessageBubble("AI", $"PIN reset to default: {DEFAULT_PIN}")
        Else
            AddMessageBubble("AI", "❌ ERROR: Could not reset PIN.")
        End If
    End Sub

    Private Sub CheckPinLockout()
        If failedPinAttempts >= MaxPinAttempts Then
            blockEndTime = DateTime.Now.AddMinutes(PinBlockMinutes)
            failedPinAttempts = 0
            AddMessageBubble("AI", $"⛔ Too many invalid attempts. You are blocked for {PinBlockMinutes} minute(s).")
        End If
    End Sub

    Private Function IsWeakPIN(pin As String) As Boolean
        Dim weakList As String() = {
            "00000000", "11111111", "22222222", "33333333", "44444444",
            "55555555", "66666666", "77777777", "88888888", "99999999",
            "12345678", "87654321"
        }
        Return weakList.Contains(pin)
    End Function

    Private Function GenerateRandomPIN() As String
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 1 To PIN_LENGTH
            sb.Append(rnd.Next(0, 10))
        Next
        Return sb.ToString()
    End Function

    Private Function UpdatePIN(username As String, pin As String) As Boolean
        Try
            Using conn As New OleDbConnection(connStr)
                Dim cmd As New OleDbCommand("UPDATE Users SET [UserPassword]=? WHERE Username=?", conn)
                cmd.Parameters.AddWithValue("?", pin)
                cmd.Parameters.AddWithValue("?", username)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            AddMessageBubble("AI", "DB ERROR: " & ex.Message)
            Return False
        End Try
    End Function

End Class
