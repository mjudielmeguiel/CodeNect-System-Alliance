Imports MySqlConnector

Public Class frmDashboard

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menupanel.Visible = Not menupanel.Visible
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menupanel.Visible = False

        SaveUserSessionToDBConnection()

        LoadHomeForm()
    End Sub

    Private Sub SaveUserSessionToDBConnection()
        Dim accountID As String = If(Login.LoggedInAccountID IsNot Nothing, Login.LoggedInAccountID.Trim(), "")
        Dim branchID As String = If(Login.LoggedInBranchID IsNot Nothing, Login.LoggedInBranchID.Trim(), "")
        Dim username As String = If(Login.LoggedInUsername IsNot Nothing, Login.LoggedInUsername.Trim(), "")

        ' ✅ KUNG WALANG BRANCH ID = ADMIN (account table) → MAIN OFFICE AGAD
        If String.IsNullOrWhiteSpace(branchID) OrElse branchID = "MAIN OFFICE" Then
            DBConnection.CurrentUserBranchID = "MAIN OFFICE"
            DBConnection.CurrentUserType = "BUSINESS ADMIN"
        Else
            ' ✅ KUNG MAY BRANCH ID = ORDINARY USER (user_accounts table)
            DBConnection.CurrentUserBranchID = branchID
            DBConnection.CurrentUserType = If(Login.LoggedInUserType IsNot Nothing, Login.LoggedInUserType.Trim(), "")
        End If

        DBConnection.CurrentUserAccountID = accountID
        DBConnection.CurrentLoggedInUser = username
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AuditLogger.LogAction("EXIT", "System", "User closed the entire application")
        Application.Exit()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        LoadHomeForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        SaveUserSessionToDBConnection()

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

        Dim branchDisplay As String
        Dim roleDisplay As String

        ' ✅ WALANG BRANCH = ADMIN → MAIN OFFICE
        If DBConnection.CurrentUserType = "BUSINESS ADMIN" Then
            branchDisplay = "MAIN OFFICE"
            roleDisplay = "BUSINESS ADMIN PANEL"
        Else
            branchDisplay = If(String.IsNullOrWhiteSpace(DBConnection.CurrentUserBranchID), "NOT ASSIGNED", DBConnection.CurrentUserBranchID)
            roleDisplay = $"{DBConnection.CurrentUserType} DASHBOARD"
        End If

        Dim Home As New frmHome
        Home.lblname.Text = DBConnection.CurrentLoggedInUser
        Home.lblbranchname.Text = branchDisplay
        Home.lblrole.Text = roleDisplay

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panelmenu.Controls.Clear()
        Dim list As New frmProductlist
        list.TopLevel = False
        list.FormBorderStyle = FormBorderStyle.None
        list.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(list)
        list.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShelfTag_Printer.Show()
    End Sub

    Public Sub OpenDailySales()
        Panelmenu.Controls.Clear()
        Dim daily As New frmDailySalesSummary
        daily.TopLevel = False
        daily.FormBorderStyle = FormBorderStyle.None
        daily.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(daily)
        daily.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panelmenu.Controls.Clear()
        Dim PO As New Ordering_Reports
        PO.TopLevel = False
        PO.FormBorderStyle = FormBorderStyle.None
        PO.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(PO)
        PO.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panelmenu.Controls.Clear()
        Dim STR As New frmStock_Transfer
        STR.TopLevel = False
        STR.FormBorderStyle = FormBorderStyle.None
        STR.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(STR)
        STR.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Price_Adjustment.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panelmenu.Controls.Clear()
        Dim STR As New Transfer_Reports()
        STR.TopLevel = False
        STR.FormBorderStyle = FormBorderStyle.None
        STR.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(STR)
        STR.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panelmenu.Controls.Clear()
        Dim INV As New frmPcount
        INV.TopLevel = False
        INV.FormBorderStyle = FormBorderStyle.None
        INV.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(INV)
        INV.Show()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        Panelmenu.Controls.Clear()
        Dim INVR As New frmPcount_Report
        INVR.TopLevel = False
        INVR.FormBorderStyle = FormBorderStyle.None
        INVR.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(INVR)
        INVR.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        SaveUserSessionToDBConnection()

        Panelmenu.Controls.Clear()
        Dim RTV As New frmRetun_To_Vendor
        RTV.TopLevel = False
        RTV.FormBorderStyle = FormBorderStyle.None
        RTV.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(RTV)
        RTV.Show()
    End Sub
End Class