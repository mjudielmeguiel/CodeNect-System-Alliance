Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class Account_Recovery

    ' --- KONEKSYON SA DATABASE ---
    Dim connStr As String = "Data Source=192.168.68.109\SQLEXPRESS,1433;Initial Catalog=CodeNectDB;User ID=CodeNect_Database;Password=Password1*;Connect Timeout=15"

    ' --- PAGBUBUKAS NG FORM: GUMAGAWA AGAD NG RECOVERY ID ---
    Private Sub Account_Recovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateRecoveryID() ' Gagawa agad ng ID pagbukas pa lang
        txtReason.Multiline = True
        txtReason.ScrollBars = ScrollBars.Vertical ' Para ma-scroll yung Reason
    End Sub

    ' --- 1. AUTOMATIC NA PAGGAWA NG RECOVERY ID ---
    Private Sub GenerateRecoveryID()
        ' Format: REC-YYYYMMDD-XXXX (Halimbawa: REC-20260603-0001)
        Dim datePart As String = DateTime.Now.ToString("yyyyMMdd")
        Dim randomPart As New Random()
        Dim num As Integer = randomPart.Next(1000, 9999)
        txtRecoveryID.Text = $"REC-{datePart}-{num}"
        txtRecoveryID.ReadOnly = True ' Hindi pwedeng baguhin ng user
    End Sub

    ' --- 2. PAGKATYPE NG EMAIL -> AUTOMATIC LALABAS ANG USERNAME ---
    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        If txtEmail.Text.Contains("@") AndAlso txtEmail.Text.Contains(".") Then
            GetUsernameFromEmail(txtEmail.Text.Trim())
        Else
            txtUsername.Clear() ' Burahin kung mali ang format
        End If
    End Sub

    Private Sub GetUsernameFromEmail(email As String)
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                ' Hanapin ang Username base sa Email sa table na 'Recovery' o User_Accounts
                Dim cmd As New SqlCommand("SELECT TOP 1 USERNAME FROM Recovery WHERE EMAIL = @EMAIL", conn)
                ' Kung sa User_Accounts naka-save ang email, palitan ang table name:
                ' Dim cmd As New SqlCommand("SELECT TOP 1 USERNAME FROM User_Accounts WHERE EMAIL = @EMAIL", conn)

                cmd.Parameters.AddWithValue("@EMAIL", email)
                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing Then
                    txtUsername.Text = result.ToString()
                    txtUsername.ReadOnly = True ' Hindi na pwedeng baguhin, kasi galing sa database
                Else
                    txtUsername.Text = "Hindi natagpuan"
                    txtUsername.ReadOnly = False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error sa pagkuha ng Username: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- 3. PASSWORD VALIDATION: MAY KAILANGANG UPPER AT LOWER CASE ---
    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged
        CheckPasswordStrength(txtNewPassword.Text)
    End Sub

    Private Sub CheckPasswordStrength(pass As String)
        ' Dapat may: Malaking titik (A-Z), Maliit na titik (a-z), at kahit 8 na letra
        Dim hasUpper As Boolean = Regex.IsMatch(pass, "[A-Z]")
        Dim hasLower As Boolean = Regex.IsMatch(pass, "[a-z]")
        Dim hasNumber As Boolean = Regex.IsMatch(pass, "[0-9]")

        If pass.Length < 8 Then
            Label4.Text = "⚠️ Masyadong maikli (min. 8)"
            Label4.ForeColor = Color.Orange
        ElseIf Not hasUpper Then
            Label4.Text = "⚠️ Kailangan ng MALAKING TITIK (A-Z)"
            Label4.ForeColor = Color.Red
        ElseIf Not hasLower Then
            Label4.Text = "⚠️ Kailangan ng maliit na titik (a-z)"
            Label4.ForeColor = Color.Red
        ElseIf Not hasNumber Then
            Label4.Text = "⚠️ Maganda kung may numero rin"
            Label4.ForeColor = Color.Blue
        Else
            Label4.Text = "✅ Matibay na Password"
            Label4.ForeColor = Color.Green
        End If
    End Sub

    ' --- 4. SHOW / HIDE PASSWORD ---
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtNewPassword.PasswordChar = ControlChars.NullChar
            txtConfirmPassword.PasswordChar = ControlChars.NullChar
        Else
            txtNewPassword.PasswordChar = "●"c
            txtConfirmPassword.PasswordChar = "●"c
        End If
    End Sub

    ' --- 5. SAVE BUTTON: I-SAVE SA DATABASE AT I-SEND ANG EMAIL ---
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' VALIDATION MUNA
        If String.IsNullOrWhiteSpace(txtRecoveryID.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtNewPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then

            MessageBox.Show("Pakiusap, punan lahat ng patlang.", "BABALA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("HINDI MAGKATUGMA ang Password at Confirm Password!", "BABALA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Suriin ulit kung tama ang password rules
        If Not Regex.IsMatch(txtNewPassword.Text, "[A-Z]") OrElse Not Regex.IsMatch(txtNewPassword.Text, "[a-z]") Then
            MessageBox.Show("Ang password ay dapat may MALAKING titik at maliit na titik.", "DI HIN TANGGAP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ' --- I-SAVE SA DATABASE ---
        Try
            Using conn As New SqlConnection(connStr)
                conn.Open()
                Dim cmd As New SqlCommand("INSERT INTO Recovery (RECOVERY_ID, EMAIL, USERNAME, PASSWORD, REASON) 
                                           VALUES (@RID, @EMAIL, @USER, @PASS, @REASON)", conn)

                cmd.Parameters.AddWithValue("@RID", txtRecoveryID.Text)
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text)
                cmd.Parameters.AddWithValue("@USER", txtUsername.Text)
                cmd.Parameters.AddWithValue("@PASS", txtNewPassword.Text)
                cmd.Parameters.AddWithValue("@REASON", txtReason.Text)

                cmd.ExecuteNonQuery()
            End Using

            ' --- PADALHAN NG EMAIL ANG USER ---
            SendRecoveryEmail(txtEmail.Text, txtUsername.Text, txtRecoveryID.Text, txtReason.Text)

            MessageBox.Show("Matagumpay na naisave at naipadala ang abiso sa email!", "TAGUMPAY", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "PANGYAYARI", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- 6. ANG TUNAY NA PAGPADALA NG EMAIL ---
    Private Sub SendRecoveryEmail(targetEmail As String, user As String, rid As String, reason As String)
        Try
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True

            ' ✅ GAMITIN MO ITO, SIGURADONG GAGANA NA! WALA KANG BABAGUHIN DITO
            smtp.Credentials = New Net.NetworkCredential("codenectsystemalliance@gmail.com", "vjysqvjwqvpdjtql")

            Dim msg As New MailMessage()
            msg.From = New MailAddress("codenectsystemalliance@gmail.com", "CodeNect System Alliance")
            msg.To.Add(targetEmail) ' Dito ipapadala sa email na nilagay niya
            msg.Subject = "ACCOUNT RECOVERY REQUEST - ID: " & rid

            ' ITO ANG LAMAN NG EMAIL
            msg.Body = $"Magandang araw po, {user}." & vbCrLf & vbCrLf &
                       "May natanggap kaming kahilingan para sa pagbawi o pagpalit ng inyong account." & vbCrLf &
                       $"Recovery ID: {rid}" & vbCrLf &
                       $"Username: {user}" & vbCrLf & vbCrLf &
                       "Dahilan ng paghingi:" & vbCrLf &
                       "----------------------------------------" & vbCrLf &
                       reason & vbCrLf &
                       "----------------------------------------" & vbCrLf & vbCrLf &
                       "Kung hindi ninyo ito ginawa, huwag po kayong mag-alala at huwag ibahagi ang inyong impormasyon." & vbCrLf &
                       "Lubos na gumagalang," & vbCrLf &
                       "CodeNect System Alliance Team"

            smtp.Send(msg)

        Catch ex As Exception
            MessageBox.Show("Na-save sa database pero HINDI NAIPADALA ang email: " & ex.Message, "BABALA SA EMAIL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' --- CANCEL BUTTON ---
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class