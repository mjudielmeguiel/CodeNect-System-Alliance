Imports MySqlConnector

Public Class frmDashboard

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menupanel.Visible = Not menupanel.Visible
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menupanel.Visible = False
        LoadHomeForm()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        LoadHomeForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Panelmenu.Controls.Clear()
        Dim STO As New Stock_Ordering
        STO.TopLevel = False
        STO.FormBorderStyle = FormBorderStyle.None
        STO.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(STO)
        STO.Show()
    End Sub

    Private Sub LoadHomeForm()
        Panelmenu.Controls.Clear()

        Dim Home As New frmHome
        Home.lblname.Text = Login.LoggedInUsername
        Home.lblbranchname.Text = If(String.IsNullOrEmpty(Login.LoggedInBranchID), "MAIN OFFICE", Login.LoggedInBranchID)
        Home.lblrole.Text = If(Login.LoggedInUserType.ToUpper() = "BUSINESS ADMIN", "BUSINESS ADMIN PANEL", Login.LoggedInUserType & " DASHBOARD")

        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Home)
        Home.Show()
    End Sub

    Private Sub btnuselist_Click(sender As Object, e As EventArgs) Handles btnuselist.Click
        Panelmenu.Controls.Clear()
        Dim User As New frmUsermanager
        User.TopLevel = False
        User.FormBorderStyle = FormBorderStyle.None
        User.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(User)
        User.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panelmenu.Controls.Clear()
        Dim branch As New Branch_Manage
        branch.TopLevel = False
        branch.FormBorderStyle = FormBorderStyle.None
        branch.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(branch)
        branch.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panelmenu.Controls.Clear()
        Dim Description As New frmUser_Description_Manager
        Description.TopLevel = False
        Description.FormBorderStyle = FormBorderStyle.None
        Description.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Description)
        Description.Show()
    End Sub
End Class