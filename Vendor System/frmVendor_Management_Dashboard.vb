Public Class frmVendor_Management_Dashboard

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Listpanel.Visible = True Then
            Listpanel.Hide()
        Else
            Listpanel.Show()
        End If
    End Sub

    Private Sub frmVendor_Management_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listpanel.Hide()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        Panel2.Controls.Clear()
        Dim Dash As New frmDashboard_Summary
        Dash.TopLevel = False
        Dash.FormBorderStyle = FormBorderStyle.None
        Dash.Dock = DockStyle.Fill
        Panel2.Controls.Add(Dash)
        Dash.Show()
    End Sub
End Class