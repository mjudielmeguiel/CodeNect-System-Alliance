'Judiel Meguiel mescallado
'june 20, 2026  


Public Class POS_System
    Private Sub POS_System_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'this a timer for shongwing current date and time in the status strip
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsdate.Text = "Date and Time : " & Now.ToString("MMMM dd, yyyy hh:mm:ss tt")
    End Sub

    'ths is a Log out button for POS System and switching user account
    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        If MessageBox.Show("Are you sure you want to switch accounts?", "Switch Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Restart()
            Login.Show()
        End If
    End Sub
End Class