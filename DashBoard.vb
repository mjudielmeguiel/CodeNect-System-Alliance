Imports System.Net
Imports System.Net.NetworkInformation
Imports ClosedXML.Excel
Imports MySqlConnector

Public Class DashBoard

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

#Region "OFFLINE CURRENT USER ACCOUNT"
    Private Sub DashBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' I-update lang kung may aktibong naka-login
        If Not String.IsNullOrEmpty(Login.LoggedInUserID) OrElse Not String.IsNullOrEmpty(Login.LoggedInAccountID) Then
            SetAccountOffline()
        End If
    End Sub

    Private Sub SetAccountOffline()
        Try
            Using conn As New MySqlConnection(DBConnection.connStr)
                conn.Open()
                Dim cmdText As String = ""
                Dim paramValue As String = ""

                ' ✅ Kung ADMIN → nasa `account` table
                If Login.LoggedInUserType.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) Then
                    cmdText = "UPDATE account SET STATUS = 'OFFLINE' WHERE ACCOUNT_ID = @ID"
                    paramValue = Login.LoggedInAccountID
                Else
                    ' ✅ Kung Regular User → nasa `User_Accounts` table
                    cmdText = "UPDATE User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @ID"
                    paramValue = Login.LoggedInUserID
                End If

                ' Huwag isagawa kung walang laman ang ID
                If String.IsNullOrWhiteSpace(paramValue) Then Return

                Using cmd As New MySqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@ID", paramValue)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            ' I-reset lahat ng login variables
            Login.LoggedInUserID = ""
            Login.LoggedInBranchID = ""
            Login.LoggedInAccountID = ""
            Login.LoggedInUsername = ""
            Login.LoggedInUserType = ""
            Application.Exit()
        End If
    End Sub

    Private Sub SwitchAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchAccountToolStripMenuItem.Click
        If MessageBox.Show("Switch to another account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            ' I-reset lahat ng login fields at variables
            Login.LoggedInUserID = ""
            Login.LoggedInBranchID = ""
            Login.LoggedInAccountID = ""
            Login.LoggedInUsername = ""
            Login.LoggedInUserType = ""
            Login.txtUsername.Clear()
            Login.txtPassword.Clear()
            Application.Restart()
        End If
    End Sub
#End Region

#Region "TOOLSTRIP & TIMER"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = "Date and Time : " & Now.ToString("MMMM dd, yyyy hh:mm:ss tt")
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        MessageBox.Show("Coming soon.", "CODENECT", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UserManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserManageToolStripMenuItem.Click
        Add_User.Show()
    End Sub

    Private Sub toolbarRoom_Click(sender As Object, e As EventArgs) Handles toolbarRoom.Click
        ShelfTag_Printer.Show()
    End Sub

    Private Sub PriceUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceUpdateToolStripMenuItem.Click
        Price_Adjustment.ShowDialog()
    End Sub
#End Region

#Region "FORMS & REPORTS LOADER"
    ' Vendor List
    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles TsVendolist.Click
        Panel2.Controls.Clear()
        Dim frmVendor As New Vendor_Manage
        frmVendor.TopLevel = False
        frmVendor.FormBorderStyle = FormBorderStyle.None
        frmVendor.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmVendor)
        frmVendor.Show()
    End Sub

    ' Inventory
    Private Sub Inventory_Click(sender As Object, e As EventArgs) Handles Inventory.Click
        Dim frmInv As New Inventory
        frmInv.Show()
    End Sub

    ' Stock Ordering
    Private Sub StockOrderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOrderingToolStripMenuItem.Click
        Dim frmOrder As New Stock_Ordering
        frmOrder.lblpreparedby.Text = ToolStripStatusLabel1.Text
        frmOrder.lblbranch.Text = ToolStripStatusLabel4.Text
        frmOrder.lblstatus.Text = "PENDING"
        frmOrder.lbltransactiontype.Text = "STOCK ORDERING"
        frmOrder.Show()
    End Sub

    ' Stock Transfer
    Private Sub StockTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockTransferToolStripMenuItem.Click
        Dim frmSTR As New Stock_Transfer
        frmSTR.lblPreparedBy.Text = ToolStripStatusLabel1.Text
        frmSTR.lblFromBranch.Text = ToolStripStatusLabel4.Text
        frmSTR.lblstatus.Text = "PENDING"
        frmSTR.lbltransactiontype.Text = "STOCK TRANSFER"
        frmSTR.Show()
    End Sub

    ' Connection Settings
    Private Sub ConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionSettingsToolStripMenuItem.Click
        frmConnectionSettings.Show()
    End Sub

    ' User / PC Management
    Private Sub Manage_PC_Click(sender As Object, e As EventArgs) Handles Manage_PC.Click
        Panel2.Controls.Clear()
        Dim frmUserMgr As New User_Account_Manage
        frmUserMgr.TopLevel = False
        frmUserMgr.FormBorderStyle = FormBorderStyle.None
        frmUserMgr.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmUserMgr)
        frmUserMgr.Show()
    End Sub

    ' Stock Ordering Reports
    Private Sub tsStockOrdering_Click(sender As Object, e As EventArgs) Handles tsStockOrdering.Click
        Panel2.Controls.Clear()
        Dim frmOrderRep As New Ordering_Reports
        frmOrderRep.TopLevel = False
        frmOrderRep.FormBorderStyle = FormBorderStyle.None
        frmOrderRep.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmOrderRep)
        frmOrderRep.Show()
    End Sub

    ' Stock Transfer Reports
    Private Sub tsStockTransfer_Click(sender As Object, e As EventArgs) Handles tsStockTransfer.Click
        Panel2.Controls.Clear()
        Dim frmTransferRep As New Transfer_Reports
        frmTransferRep.TopLevel = False
        frmTransferRep.FormBorderStyle = FormBorderStyle.None
        frmTransferRep.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmTransferRep)
        frmTransferRep.Show()
    End Sub

    ' Return to Vendor
    Private Sub ReturnToVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToVendorToolStripMenuItem.Click
        Dim frmRTV As New Return_To_Vendor
        frmRTV.lblpreparedby.Text = ToolStripStatusLabel1.Text
        frmRTV.lblbranch.Text = ToolStripStatusLabel4.Text
        frmRTV.lblstatus.Text = "PENDING"
        frmRTV.lbltransactiontype.Text = "RETURN TO VENDOR"
        frmRTV.Show()
    End Sub

    ' Top Branch Performance
    Private Sub TopBranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopBranchToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim frmPerf As New Branch_Performance
        frmPerf.TopLevel = False
        frmPerf.FormBorderStyle = FormBorderStyle.None
        frmPerf.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmPerf)
        frmPerf.Show()
    End Sub

    ' Sales Transactions
    Private Sub SalesTransactionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesTransactionsToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim frmSales As New frmDailySalesSummary
        frmSales.TopLevel = False
        frmSales.FormBorderStyle = FormBorderStyle.None
        frmSales.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmSales)
        frmSales.Show()
    End Sub

    ' Discount Records
    Private Sub tsDiscounts_Click(sender As Object, e As EventArgs) Handles tsDiscounts.Click
        Panel2.Controls.Clear()
        Dim frmDisc As New frmDiscountRecords
        ' I-pass ang login details
        frmDisc.SetUser(Login.LoggedInUserID, Login.LoggedInBranchID)
        frmDisc.TopLevel = False
        frmDisc.FormBorderStyle = FormBorderStyle.None
        frmDisc.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmDisc)
        frmDisc.Show()
    End Sub

    ' Bad Order
    Private Sub Bo_Click(sender As Object, e As EventArgs) Handles Bo.Click
        Dim frmBO As New frmBad_Order
        frmBO.lblPreparedBy.Text = ToolStripStatusLabel1.Text
        frmBO.lblNameBranch.Text = ToolStripStatusLabel4.Text
        frmBO.Show()
    End Sub

    ' Add Branch
    Private Sub BranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchToolStripMenuItem.Click
        Dim frmAddBr As New ADD_Branch()
        frmAddBr.ShowDialog()
    End Sub

    ' Manage Branch
    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Panel2.Controls.Clear()
        Dim frmBrMgr As New Branch_Manage
        frmBrMgr.TopLevel = False
        frmBrMgr.FormBorderStyle = FormBorderStyle.None
        frmBrMgr.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBrMgr)
        frmBrMgr.Show()
    End Sub

    ' Add Product - Scan
    Private Sub ScanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanToolStripMenuItem.Click
        Dim frmScan As New frmADDProduct_Scan
        frmScan.ShowDialog()
    End Sub

    ' Add Product - Manual
    Private Sub ManualToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem1.Click
        Dim frmManual As New frmADDProduct_Manual
        frmManual.Show()
    End Sub

    ' Description Manager
    Private Sub Btn_Manage_Click(sender As Object, e As EventArgs) Handles Btn_Manage.Click
        Panel2.Controls.Clear()
        Dim frmDescMgr As New Description_Manager
        frmDescMgr.TopLevel = False
        frmDescMgr.FormBorderStyle = FormBorderStyle.None
        frmDescMgr.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmDescMgr)
        frmDescMgr.Show()
    End Sub
#End Region

End Class