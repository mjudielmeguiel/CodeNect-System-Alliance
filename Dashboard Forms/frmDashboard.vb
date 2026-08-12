Imports MySqlConnector

Public Class frmDashboard

    Private Shared CurrentUserID As String = Nothing
    Private Shared CurrentUsername As String = Nothing
    Private Shared IsAdminUser As Boolean = False

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menupanel.Visible = Not menupanel.Visible
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menupanel.Visible = False

        SaveUserSessionToDBConnection()

        CurrentUserID = If(Login.LoggedInAccountID, "").ToString().Trim()
        CurrentUsername = If(Login.LoggedInUsername, "").ToString().Trim()

        Dim branchID As String = If(Login.LoggedInBranchID, "").ToString().Trim()
        IsAdminUser = (String.IsNullOrWhiteSpace(branchID) OrElse branchID = "MAIN OFFICE")

        LoadHomeForm()
    End Sub

    Private Sub SaveUserSessionToDBConnection()
        Dim accountID As String = If(Login.LoggedInAccountID IsNot Nothing, Login.LoggedInAccountID.Trim(), "")
        Dim branchID As String = If(Login.LoggedInBranchID IsNot Nothing, Login.LoggedInBranchID.Trim(), "")
        Dim username As String = If(Login.LoggedInUsername IsNot Nothing, Login.LoggedInUsername.Trim(), "")

        If String.IsNullOrWhiteSpace(branchID) OrElse branchID = "MAIN OFFICE" Then
            DBConnection.CurrentUserBranchID = "MAIN OFFICE"
            DBConnection.CurrentUserType = "BUSINESS ADMIN"
        Else
            DBConnection.CurrentUserBranchID = branchID
            DBConnection.CurrentUserType = If(Login.LoggedInUserType IsNot Nothing, Login.LoggedInUserType.Trim(), "")
        End If

        DBConnection.CurrentUserAccountID = accountID
        DBConnection.CurrentLoggedInUser = username
    End Sub

    Private Sub SetUserOffline()
        Try
            Dim uid As String = CurrentUserID?.Trim()
            Dim uname As String = CurrentUsername?.Trim()

            If String.IsNullOrWhiteSpace(uid) AndAlso String.IsNullOrWhiteSpace(uname) Then
                Return ' WALA TALAGANG DETALYE
            End If

            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()

                Dim totalUpdated As Integer = 0

                If Not String.IsNullOrWhiteSpace(uname) Then
                    Using cmd1 As New MySqlCommand("UPDATE user_accounts SET STATUS='OFFLINE' WHERE USERNAME=@U", conn)
                        cmd1.Parameters.AddWithValue("@U", uname)
                        totalUpdated += cmd1.ExecuteNonQuery()
                    End Using

                    Using cmd2 As New MySqlCommand("UPDATE account SET STATUS='OFFLINE' WHERE USERNAME=@U", conn)
                        cmd2.Parameters.AddWithValue("@U", uname)
                        totalUpdated += cmd2.ExecuteNonQuery()
                    End Using
                End If

                If Not String.IsNullOrWhiteSpace(uid) Then
                    Using cmd3 As New MySqlCommand("UPDATE user_accounts SET STATUS='OFFLINE' WHERE ID=@ID", conn)
                        cmd3.Parameters.AddWithValue("@ID", uid)
                        totalUpdated += cmd3.ExecuteNonQuery()
                    End Using
                    Using cmd4 As New MySqlCommand("UPDATE account SET STATUS='OFFLINE' WHERE ID=@ID", conn)
                        cmd4.Parameters.AddWithValue("@ID", uid)
                        totalUpdated += cmd4.ExecuteNonQuery()
                    End Using
                End If

                MessageBox.Show($"Status Updated: {totalUpdated} record(s) set to OFFLINE", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error setting offline: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SetUserOffline()

        Dim login As New Login()
        login.Show()
        Me.Close()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            SetUserOffline()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        LoadHomeForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnPO.Click
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnSTR.Click
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

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnRTV.Click
        SaveUserSessionToDBConnection()
        Panelmenu.Controls.Clear()
        Dim RTV As New frmRetun_To_Vendor
        RTV.TopLevel = False
        RTV.FormBorderStyle = FormBorderStyle.None
        RTV.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(RTV)
        RTV.Show()
    End Sub

    Private Sub btnRTV_Reports_Click(sender As Object, e As EventArgs) Handles btnRTV_Reports.Click
        MsgBox("This feature is currently under development. Please check back later.", MsgBoxStyle.Information, "Feature Under Development")
    End Sub

    Private Sub btnPrice_Adjustment_Reports_Click(sender As Object, e As EventArgs) Handles btnPrice_Adjustment_Reports.Click
        MsgBox("This feature is currently under development. Please check back later.", MsgBoxStyle.Information, "Feature Under Development")
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox("This feature is currently under development. Please check back later.", MsgBoxStyle.Information, "Feature Under Development")
    End Sub

    Private Sub btnSOTEX_Reports_Click(sender As Object, e As EventArgs) Handles btnSOTEX_Reports.Click
        MsgBox("This feature is currently under development. Please check back later.", MsgBoxStyle.Information, "Feature Under Development")
    End Sub

    Private Sub btnINV_Reports_Click(sender As Object, e As EventArgs) Handles btnINV_Reports.Click
        SaveUserSessionToDBConnection()
        Panelmenu.Controls.Clear()
        Dim PCOUNTR As New frmPcount_Report
        PCOUNTR.TopLevel = False
        PCOUNTR.FormBorderStyle = FormBorderStyle.None
        PCOUNTR.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(PCOUNTR)
        PCOUNTR.Show()
    End Sub

    Private Sub btnPO_Reports_Click(sender As Object, e As EventArgs) Handles btnPO_Reports.Click
        Panelmenu.Controls.Clear()
        Dim PO As New Ordering_Reports
        PO.TopLevel = False
        PO.FormBorderStyle = FormBorderStyle.None
        PO.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(PO)
        PO.Show()
    End Sub

    Private Sub btnSTR_Reports_Click(sender As Object, e As EventArgs) Handles btnSTR_Reports.Click
        Panelmenu.Controls.Clear()
        Dim STRR As New Transfer_Reports
        STRR.TopLevel = False
        STRR.FormBorderStyle = FormBorderStyle.None
        STRR.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(STRR)
        STRR.Show()
    End Sub

    Private Sub btnSales_Report_Click(sender As Object, e As EventArgs) Handles btnSales_Report.Click
        Panelmenu.Controls.Clear()
        Dim SalesSummary As New frmDailySalesSummary
        SalesSummary.TopLevel = False
        SalesSummary.FormBorderStyle = FormBorderStyle.None
        SalesSummary.Dock = DockStyle.Fill
        Panelmenu.Controls.Add(SalesSummary)
        SalesSummary.Show()
    End Sub
End Class