Imports MySqlConnector

Public Class frmDashboard

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menupanel.Visible = Not menupanel.Visible
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menupanel.Visible = False
        LoadHomeForm()
        AuditLogger.LogAction("OPEN", "Dashboard", "Opened main dashboard")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AuditLogger.LogAction("EXIT", "System", "User closed the entire application")
        Application.Exit()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        LoadHomeForm()
        AuditLogger.LogAction("NAVIGATE", "Dashboard", "Navigated to Home / Overview")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Panelmenu.Controls.Clear()
        Dim STO As New Stock_Ordering
        STO.TopLevel = False
        STO.FormBorderStyle = FormBorderStyle.None
        STO.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(STO)
        STO.Show()
        AuditLogger.LogAction("OPEN", "Inventory", "Opened Stock Ordering module")
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
        AuditLogger.LogAction("OPEN", "User Management", "Opened User Account Manager")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Panelmenu.Controls.Clear()
        Dim branch As New Branch_Manage
        branch.TopLevel = False
        branch.FormBorderStyle = FormBorderStyle.None
        branch.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(branch)
        branch.Show()
        AuditLogger.LogAction("OPEN", "Branch Management", "Opened Branch Manager")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panelmenu.Controls.Clear()
        Dim Description As New frmUser_Description_Manager
        Description.TopLevel = False
        Description.FormBorderStyle = FormBorderStyle.None
        Description.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(Description)
        Description.Show()
        AuditLogger.LogAction("OPEN", "Settings", "Opened User Description Manager")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panelmenu.Controls.Clear()
        Dim list As New frmProductlist
        list.TopLevel = False
        list.FormBorderStyle = FormBorderStyle.None
        list.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(list)
        list.Show()
        AuditLogger.LogAction("OPEN", "Inventory", "Opened Product List / Inventory")
    End Sub
End Class