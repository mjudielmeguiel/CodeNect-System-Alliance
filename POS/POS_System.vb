'Judiel Meguiel mescallado
'june 20, 2026  


Public Class POS_System
    Private Sub POS_System_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'this a timer for shongwing current date and time in the status strip
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsdate.Text = "Date and Time : " & Now.ToString("MMMM dd, yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        PWDDiscount.Show()
    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs)
        frmProductQTY.Show()
    End Sub

    Private Sub btnlogout_Click_1(sender As Object, e As EventArgs) Handles btnlogout.Click
        If MessageBox.Show("Are you sure you want to switch accounts?", "Switch Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Restart()
            Login.Show()
        End If
    End Sub
End Class