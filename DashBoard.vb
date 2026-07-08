Imports System.Data.OleDb
Imports System.Net
Imports System.Net.NetworkInformation
Imports ClosedXML.Excel
Imports System.Data.SqlClient

Public Class DashBoard

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

#Region "OFFLINE CURRENT USER ACCOUNT"
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
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected = 0 Then
                        MessageBox.Show("Warning: No user record updated. Check if ID/Table is correct.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            Login.LoggedInUserID = ""
            Login.LoggedInBranchID = ""
            Login.LoggedInUsername = ""
            Login.LoggedInUserType = ""
            Application.Exit()
        End If
    End Sub

    Private Sub SwitchAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchAccountToolStripMenuItem.Click
        If MessageBox.Show("Switch account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            Login.LoggedInUserID = ""
            Login.LoggedInBranchID = ""
            Login.LoggedInUsername = ""
            Login.LoggedInUserType = ""
            Login.txtUsername.Clear()
            Login.txtPassword.Clear()
            Application.Restart()
        End If
    End Sub
#End Region

#Region "TOOLSTRIP BUTTONS"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = "Date and Time : " & Now.ToString("MMMM dd, yyyy hh:mm:ss tt")
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        MessageBox.Show("Coming soon.", "CODENECT", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UserManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserManageToolStripMenuItem.Click
        Add_User.Show()
    End Sub

    'Private Sub ADDToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem2.Click
    '    ADD_Vendor.Show()
    'End Sub

    Private Sub ADDToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem1.Click
        ADD_Branch.Show()
    End Sub

    'Private Sub ADDProductVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDProductVendorToolStripMenuItem.Click
    'ADD_Vendor_Product.ShowDialog()
    'End Sub

    Private Sub toolbarRoom_Click(sender As Object, e As EventArgs) Handles toolbarRoom.Click
        ShelfTag_Printer.Show()
    End Sub

    Private Sub PriceUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceUpdateToolStripMenuItem.Click
        Price_Adjustment.ShowDialog()
    End Sub
#End Region

#Region "DATA AND INFORMATIONS"
    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New User_Account_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    'Private Sub ManageToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem1.Click
    'Panel2.Controls.Clear()
    'Dim frmBottom As New Vendor_Manage
    'frmBottom.TopLevel = False
    'frmBottom.FormBorderStyle = FormBorderStyle.None
    'frmBottom'.Dock = DockStyle.Fill
    'Panel2.Controls.Add(frmBottom)
    'frmBottom.Show()
    'End Sub

    Private Sub ManageToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem3.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Branch_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles TsVendolist.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Vendor_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Branch_Performance
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Panel2.Controls.Clear()
        Dim frmBottom As New Ordering_Report
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ProductListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductListToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Description_Manager
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub Inventory_Click(sender As Object, e As EventArgs) Handles Inventory.Click
        Dim inv As New Inventory
        inv.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
    End Sub

    Private Sub StockOrderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOrderingToolStripMenuItem.Click

        Dim Ordering As New Stock_Ordering

        Ordering.lblpreparedby.Text = ToolStripStatusLabel1.Text
        Ordering.lblbranch.Text = ToolStripStatusLabel4.Text
        Ordering.lblstatus.Text = "PENDING"
        Ordering.lbltransactiontype.Text = "STOCK ORDERING"
        Ordering.Show()
    End Sub

    Private Sub StockTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockTransferToolStripMenuItem.Click

        Dim STR As New Stock_Transfer

        STR.lblPreparedBy.Text = ToolStripStatusLabel1.Text
        STR.lblFromBranch.Text = ToolStripStatusLabel4.Text
        STR.lblstatus.Text = "PENDING"
        STR.lbltransactiontype.Text = "STOCK TRANSFER"
        STR.Show()
    End Sub

    Private Sub BtnTransactions_Click(sender As Object, e As EventArgs) Handles BtnTransactions.Click
        Ordering_Report.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles btntransferReport.Click
        Panel2.Controls.Clear()
        Dim Report As New Transfer_Reports
        Report.TopLevel = False
        Report.FormBorderStyle = FormBorderStyle.None
        Report.Dock = DockStyle.Fill
        Panel2.Controls.Add(Report)
        Report.Show()
    End Sub

    Private Sub ConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionSettingsToolStripMenuItem.Click
        frmConnectionSettings.Show()
    End Sub

    Private Sub AddProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProductToolStripMenuItem.Click
        Dim scan As New frmADDProduct_Scan
        scan.ShowDialog()
    End Sub

    Private Sub ManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem.Click
        frmADDProduct_Manual.Show()
    End Sub
#End Region

End Class