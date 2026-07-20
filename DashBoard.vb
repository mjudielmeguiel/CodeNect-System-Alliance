Imports System.Data.SqlClient
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
        ' Tawagin lang kung may naka-login
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

                ' ✅ Kung ADMIN ang naka-login
                If Login.LoggedInUserType.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) Then
                    cmdText = "UPDATE adm_Account SET STATUS = 'OFFLINE' WHERE ACCOUNT_ID = @ID"
                    paramValue = Login.LoggedInAccountID

                    ' ✅ Kung Regular User ang naka-login
                Else
                    cmdText = "UPDATE User_Accounts SET STATUS = 'OFFLINE' WHERE ID = @ID"
                    paramValue = Login.LoggedInUserID
                End If

                ' Siguradong may laman ang halaga bago isagawa
                If String.IsNullOrEmpty(paramValue) Then Return

                Using cmd As New MySqlCommand(cmdText, conn)
                    cmd.Parameters.AddWithValue("@ID", paramValue)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error sa pag-update ng katayuan: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MessageBox.Show("Sigurado ka bang nais mong lumabas?", "Kumpirmahin ang Pag-alis", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            ' I-reset ang lahat ng variable
            Login.LoggedInUserID = ""
            Login.LoggedInBranchID = ""
            Login.LoggedInAccountID = ""
            Login.LoggedInUsername = ""
            Login.LoggedInUserType = ""
            Application.Exit()
        End If
    End Sub

    Private Sub SwitchAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchAccountToolStripMenuItem.Click
        If MessageBox.Show("Gusto mo bang lumipat ng account?", "Kumpirmahin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            SetAccountOffline()
            ' I-reset ang lahat ng variable
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

    Private Sub toolbarRoom_Click(sender As Object, e As EventArgs) Handles toolbarRoom.Click
        ShelfTag_Printer.Show()
    End Sub

    Private Sub PriceUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceUpdateToolStripMenuItem.Click
        Price_Adjustment.ShowDialog()
    End Sub
#End Region

#Region "DATA AND INFORMATIONS"

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles TsVendolist.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Vendor_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Panel2.Controls.Clear()
        Dim frmBottom As New Ordering_Reports
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

    Private Sub ConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionSettingsToolStripMenuItem.Click
        frmConnectionSettings.Show()
    End Sub

    Private Sub Manage_PC_Click(sender As Object, e As EventArgs) Handles Manage_PC.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New User_Account_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub tsStockOrdering_Click(sender As Object, e As EventArgs) Handles tsStockOrdering.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Ordering_Reports
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub tsStockTransfer_Click(sender As Object, e As EventArgs) Handles tsStockTransfer.Click
        Panel2.Controls.Clear()
        Dim Report As New Transfer_Reports
        Report.TopLevel = False
        Report.FormBorderStyle = FormBorderStyle.None
        Report.Dock = DockStyle.Fill
        Panel2.Controls.Add(Report)
        Report.Show()
    End Sub

    Private Sub ReturnToVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToVendorToolStripMenuItem.Click
        Dim RTV As New Return_To_Vendor
        RTV.lblpreparedby.Text = ToolStripStatusLabel1.Text
        RTV.lblbranch.Text = ToolStripStatusLabel4.Text
        RTV.lblstatus.Text = "PENDING"
        RTV.lbltransactiontype.Text = "RETURN TO VENDOR"
        RTV.Show()
    End Sub

    Private Sub TopBranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopBranchToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Branch_Performance
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub SalesTransactionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesTransactionsToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim Sales As New frmDailySalesSummary
        Sales.TopLevel = False
        Sales.FormBorderStyle = FormBorderStyle.None
        Sales.Dock = DockStyle.Fill
        Panel2.Controls.Add(Sales)
        Sales.Show()
    End Sub

    Private Sub tsDiscounts_Click(sender As Object, e As EventArgs) Handles tsDiscounts.Click
        Panel2.Controls.Clear()
        Dim Discount As New frmDiscountRecords
        ' Send values from your Login module
        Discount.SetUser(Login.LoggedInUserID, Login.LoggedInBranchID)
        Discount.TopLevel = False
        Discount.FormBorderStyle = FormBorderStyle.None
        Discount.Dock = DockStyle.Fill
        Panel2.Controls.Add(Discount)
        Discount.Show()
    End Sub

    Private Sub Bo_Click(sender As Object, e As EventArgs) Handles Bo.Click
        Dim BO As New frmBad_Order
        BO.Show()
        BO.lblPreparedBy.Text = ToolStripStatusLabel1.Text 'Trim lang from Dashboard to Bad Order Form
        BO.lblNameBranch.Text = ToolStripStatusLabel4.Text
    End Sub

    Private Sub BranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchToolStripMenuItem.Click
        Dim frmAddBranch As New ADD_Branch()
        frmAddBranch.ShowDialog()
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Branch_Manage
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

    Private Sub ScanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanToolStripMenuItem.Click
        Dim scan As New frmADDProduct_Scan
        scan.ShowDialog()
    End Sub

    Private Sub ManualToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem1.Click
        Dim Manual As New frmADDProduct_Manual
        Manual.Show()
    End Sub

    Private Sub Btn_Manage_Click(sender As Object, e As EventArgs) Handles Btn_Manage.Click
        Panel2.Controls.Clear()
        Dim frmBottom As New Description_Manager
        frmBottom.TopLevel = False
        frmBottom.FormBorderStyle = FormBorderStyle.None
        frmBottom.Dock = DockStyle.Fill
        Panel2.Controls.Add(frmBottom)
        frmBottom.Show()
    End Sub

#End Region

End Class