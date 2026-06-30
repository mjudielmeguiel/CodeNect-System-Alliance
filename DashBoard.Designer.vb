<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashBoard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashBoard))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SwitchAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.StockOrderingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockTransferToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnToVendorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.StockCountToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DamageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpiryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PromoUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RetunToVendorManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Manage_PC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.toolbarCheckIn = New System.Windows.Forms.ToolStripDropDownButton()
        Me.StockOrderingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockTransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnToVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Inventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sotex = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_Manage = New System.Windows.Forms.ToolStripButton()
        Me.toolbarRoom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ADDToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TOP1000SKUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.B1T1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALESToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Btn_History = New System.Windows.Forms.ToolStripDropDownButton()
        Me.InventoryManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoonToExpireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BadOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 54)
        Me.Panel1.TabIndex = 1
        '
        'userPic
        '
        Me.userPic.Image = CType(resources.GetObject("userPic.Image"), System.Drawing.Image)
        Me.userPic.Location = New System.Drawing.Point(0, 0)
        Me.userPic.Name = "userPic"
        Me.userPic.Size = New System.Drawing.Size(73, 54)
        Me.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.userPic.TabIndex = 7
        Me.userPic.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADMIN - MAIN OFFICE"
        '
        'adminpic
        '
        Me.adminpic.Dock = System.Windows.Forms.DockStyle.Left
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(0, 0)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 54)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton2, Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 54)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1366, 28)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.UserManageToolStripMenuItem, Me.ToolStripMenuItem9, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.SwitchAccountToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(47, 25)
        Me.ToolStripButton3.Text = "File"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Image = CType(resources.GetObject("UserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.UserToolStripMenuItem.Text = "Account"
        '
        'UserManageToolStripMenuItem
        '
        Me.UserManageToolStripMenuItem.Image = CType(resources.GetObject("UserManageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UserManageToolStripMenuItem.Name = "UserManageToolStripMenuItem"
        Me.UserManageToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.UserManageToolStripMenuItem.Text = "ADD Account"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(208, 26)
        Me.ToolStripMenuItem9.Text = "Account Manager"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(208, 26)
        Me.ToolStripMenuItem1.Text = "Account Recovery"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        'SwitchAccountToolStripMenuItem
        '
        Me.SwitchAccountToolStripMenuItem.Image = CType(resources.GetObject("SwitchAccountToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SwitchAccountToolStripMenuItem.Name = "SwitchAccountToolStripMenuItem"
        Me.SwitchAccountToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.SwitchAccountToolStripMenuItem.Text = "Switch Account"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Image = CType(resources.GetObject("LogOutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.LogOutToolStripMenuItem.Text = "Exit"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockOrderingToolStripMenuItem1, Me.StockTransferToolStripMenuItem1, Me.ReturnToVendorToolStripMenuItem1, Me.ToolStripSeparator3, Me.StockCountToolStripMenuItem1, Me.DamageToolStripMenuItem, Me.ExpiryToolStripMenuItem, Me.ToolStripMenuItem2, Me.PromoUpdatesToolStripMenuItem, Me.SalesToolStripMenuItem})
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(101, 25)
        Me.ToolStripButton4.Text = "Monitoring"
        '
        'StockOrderingToolStripMenuItem1
        '
        Me.StockOrderingToolStripMenuItem1.Name = "StockOrderingToolStripMenuItem1"
        Me.StockOrderingToolStripMenuItem1.Size = New System.Drawing.Size(199, 26)
        Me.StockOrderingToolStripMenuItem1.Text = "Stock Ordering"
        '
        'StockTransferToolStripMenuItem1
        '
        Me.StockTransferToolStripMenuItem1.Name = "StockTransferToolStripMenuItem1"
        Me.StockTransferToolStripMenuItem1.Size = New System.Drawing.Size(199, 26)
        Me.StockTransferToolStripMenuItem1.Text = "Stock Transfer"
        '
        'ReturnToVendorToolStripMenuItem1
        '
        Me.ReturnToVendorToolStripMenuItem1.Name = "ReturnToVendorToolStripMenuItem1"
        Me.ReturnToVendorToolStripMenuItem1.Size = New System.Drawing.Size(199, 26)
        Me.ReturnToVendorToolStripMenuItem1.Text = "Return to Vendor"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(196, 6)
        '
        'StockCountToolStripMenuItem1
        '
        Me.StockCountToolStripMenuItem1.Name = "StockCountToolStripMenuItem1"
        Me.StockCountToolStripMenuItem1.Size = New System.Drawing.Size(199, 26)
        Me.StockCountToolStripMenuItem1.Text = "Stock Count"
        '
        'DamageToolStripMenuItem
        '
        Me.DamageToolStripMenuItem.Name = "DamageToolStripMenuItem"
        Me.DamageToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.DamageToolStripMenuItem.Text = "Damage (B/O)"
        '
        'ExpiryToolStripMenuItem
        '
        Me.ExpiryToolStripMenuItem.Name = "ExpiryToolStripMenuItem"
        Me.ExpiryToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.ExpiryToolStripMenuItem.Text = "Expiry"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(196, 6)
        '
        'PromoUpdatesToolStripMenuItem
        '
        Me.PromoUpdatesToolStripMenuItem.Name = "PromoUpdatesToolStripMenuItem"
        Me.PromoUpdatesToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.PromoUpdatesToolStripMenuItem.Text = "Promo Updates"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RetunToVendorManageToolStripMenuItem, Me.ToolStripSeparator2, Me.Manage_PC})
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(79, 25)
        Me.ToolStripButton2.Text = "Settings"
        '
        'RetunToVendorManageToolStripMenuItem
        '
        Me.RetunToVendorManageToolStripMenuItem.Name = "RetunToVendorManageToolStripMenuItem"
        Me.RetunToVendorManageToolStripMenuItem.Size = New System.Drawing.Size(195, 26)
        Me.RetunToVendorManageToolStripMenuItem.Text = "System Features"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(192, 6)
        '
        'Manage_PC
        '
        Me.Manage_PC.Name = "Manage_PC"
        Me.Manage_PC.Size = New System.Drawing.Size(195, 26)
        Me.Manage_PC.Text = "Manage User PC"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(56, 25)
        Me.ToolStripButton8.Text = "Active"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 746)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1366, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(440, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(440, 17)
        Me.ToolStripStatusLabel4.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(440, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolbarCheckIn, Me.ToolStripButton7, Me.Btn_Manage, Me.toolbarRoom, Me.ToolStripButton12, Me.ToolStripButton10, Me.ToolStripButton13, Me.ToolStripButton1, Me.Btn_History, Me.ToolStripButton6})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 82)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1366, 39)
        Me.ToolStrip2.TabIndex = 15
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'toolbarCheckIn
        '
        Me.toolbarCheckIn.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockOrderingToolStripMenuItem, Me.StockTransferToolStripMenuItem, Me.ReturnToVendorToolStripMenuItem})
        Me.toolbarCheckIn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolbarCheckIn.Image = CType(resources.GetObject("toolbarCheckIn.Image"), System.Drawing.Image)
        Me.toolbarCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarCheckIn.Name = "toolbarCheckIn"
        Me.toolbarCheckIn.Size = New System.Drawing.Size(127, 36)
        Me.toolbarCheckIn.Text = "Stock Transfer"
        Me.toolbarCheckIn.ToolTipText = "Checkin"
        '
        'StockOrderingToolStripMenuItem
        '
        Me.StockOrderingToolStripMenuItem.Image = CType(resources.GetObject("StockOrderingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockOrderingToolStripMenuItem.Name = "StockOrderingToolStripMenuItem"
        Me.StockOrderingToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.StockOrderingToolStripMenuItem.Text = "Stock Ordering"
        '
        'StockTransferToolStripMenuItem
        '
        Me.StockTransferToolStripMenuItem.Image = CType(resources.GetObject("StockTransferToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockTransferToolStripMenuItem.Name = "StockTransferToolStripMenuItem"
        Me.StockTransferToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.StockTransferToolStripMenuItem.Text = "Stock Transfering"
        '
        'ReturnToVendorToolStripMenuItem
        '
        Me.ReturnToVendorToolStripMenuItem.Image = CType(resources.GetObject("ReturnToVendorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReturnToVendorToolStripMenuItem.Name = "ReturnToVendorToolStripMenuItem"
        Me.ReturnToVendorToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ReturnToVendorToolStripMenuItem.Text = "Return to Vendor"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Inventory, Me.Sotex, Me.Bo})
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripButton7.Text = "Reports"
        '
        'Inventory
        '
        Me.Inventory.Image = CType(resources.GetObject("Inventory.Image"), System.Drawing.Image)
        Me.Inventory.Name = "Inventory"
        Me.Inventory.Size = New System.Drawing.Size(198, 22)
        Me.Inventory.Text = "Inventory Management"
        '
        'Sotex
        '
        Me.Sotex.Image = CType(resources.GetObject("Sotex.Image"), System.Drawing.Image)
        Me.Sotex.Name = "Sotex"
        Me.Sotex.Size = New System.Drawing.Size(198, 22)
        Me.Sotex.Text = "Soon to Expire"
        '
        'Bo
        '
        Me.Bo.Image = CType(resources.GetObject("Bo.Image"), System.Drawing.Image)
        Me.Bo.Name = "Bo"
        Me.Bo.Size = New System.Drawing.Size(198, 22)
        Me.Bo.Text = "Bad Order"
        '
        'Btn_Manage
        '
        Me.Btn_Manage.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Manage.Image = CType(resources.GetObject("Btn_Manage.Image"), System.Drawing.Image)
        Me.Btn_Manage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Manage.Name = "Btn_Manage"
        Me.Btn_Manage.Size = New System.Drawing.Size(154, 36)
        Me.Btn_Manage.Text = "Product Descriptions"
        Me.Btn_Manage.ToolTipText = "Checkout"
        '
        'toolbarRoom
        '
        Me.toolbarRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolbarRoom.Image = CType(resources.GetObject("toolbarRoom.Image"), System.Drawing.Image)
        Me.toolbarRoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbarRoom.Name = "toolbarRoom"
        Me.toolbarRoom.Size = New System.Drawing.Size(67, 36)
        Me.toolbarRoom.Text = "Tags"
        Me.toolbarRoom.ToolTipText = "Room"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDToolStripMenuItem1, Me.ManageToolStripMenuItem3})
        Me.ToolStripButton12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(100, 36)
        Me.ToolStripButton12.Text = "Branches"
        Me.ToolStripButton12.ToolTipText = "Logout"
        '
        'ADDToolStripMenuItem1
        '
        Me.ADDToolStripMenuItem1.Image = CType(resources.GetObject("ADDToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ADDToolStripMenuItem1.Name = "ADDToolStripMenuItem1"
        Me.ADDToolStripMenuItem1.Size = New System.Drawing.Size(117, 22)
        Me.ADDToolStripMenuItem1.Text = "ADD"
        '
        'ManageToolStripMenuItem3
        '
        Me.ManageToolStripMenuItem3.Image = CType(resources.GetObject("ManageToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ManageToolStripMenuItem3.Name = "ManageToolStripMenuItem3"
        Me.ManageToolStripMenuItem3.Size = New System.Drawing.Size(117, 22)
        Me.ManageToolStripMenuItem3.Text = "Manage"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(81, 36)
        Me.ToolStripButton10.Text = "Vendor"
        Me.ToolStripButton10.ToolTipText = "Guest"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOP1000SKUToolStripMenuItem, Me.B1T1ToolStripMenuItem, Me.SALESToolStripMenuItem1, Me.PriceUpdateToolStripMenuItem})
        Me.ToolStripButton13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(95, 36)
        Me.ToolStripButton13.Text = "Promo's"
        Me.ToolStripButton13.ToolTipText = "Exit"
        '
        'TOP1000SKUToolStripMenuItem
        '
        Me.TOP1000SKUToolStripMenuItem.Name = "TOP1000SKUToolStripMenuItem"
        Me.TOP1000SKUToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.TOP1000SKUToolStripMenuItem.Text = "TOP 1000 SKU"
        '
        'B1T1ToolStripMenuItem
        '
        Me.B1T1ToolStripMenuItem.Name = "B1T1ToolStripMenuItem"
        Me.B1T1ToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.B1T1ToolStripMenuItem.Text = "BUY 1 TAKE 1"
        '
        'SALESToolStripMenuItem1
        '
        Me.SALESToolStripMenuItem1.Name = "SALESToolStripMenuItem1"
        Me.SALESToolStripMenuItem1.Size = New System.Drawing.Size(174, 22)
        Me.SALESToolStripMenuItem1.Text = "50% PROMO SALE"
        '
        'PriceUpdateToolStripMenuItem
        '
        Me.PriceUpdateToolStripMenuItem.Name = "PriceUpdateToolStripMenuItem"
        Me.PriceUpdateToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PriceUpdateToolStripMenuItem.Text = "Price Update"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(70, 36)
        Me.ToolStripButton1.Text = "Sales"
        Me.ToolStripButton1.ToolTipText = "Exit"
        '
        'Btn_History
        '
        Me.Btn_History.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryManagementToolStripMenuItem, Me.SoonToExpireToolStripMenuItem, Me.BadOrderToolStripMenuItem, Me.ToolStripMenuItem4})
        Me.Btn_History.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_History.Image = CType(resources.GetObject("Btn_History.Image"), System.Drawing.Image)
        Me.Btn_History.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_History.Name = "Btn_History"
        Me.Btn_History.Size = New System.Drawing.Size(95, 36)
        Me.Btn_History.Text = "Uploads"
        Me.Btn_History.ToolTipText = "Exit"
        '
        'InventoryManagementToolStripMenuItem
        '
        Me.InventoryManagementToolStripMenuItem.Image = CType(resources.GetObject("InventoryManagementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InventoryManagementToolStripMenuItem.Name = "InventoryManagementToolStripMenuItem"
        Me.InventoryManagementToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.InventoryManagementToolStripMenuItem.Text = "Inventory Management"
        '
        'SoonToExpireToolStripMenuItem
        '
        Me.SoonToExpireToolStripMenuItem.Image = CType(resources.GetObject("SoonToExpireToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SoonToExpireToolStripMenuItem.Name = "SoonToExpireToolStripMenuItem"
        Me.SoonToExpireToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SoonToExpireToolStripMenuItem.Text = "Soon to Expire"
        '
        'BadOrderToolStripMenuItem
        '
        Me.BadOrderToolStripMenuItem.Image = CType(resources.GetObject("BadOrderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BadOrderToolStripMenuItem.Name = "BadOrderToolStripMenuItem"
        Me.BadOrderToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.BadOrderToolStripMenuItem.Text = "Bad Order"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItem4.Text = "History"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(89, 36)
        Me.ToolStripButton6.Text = "Message"
        Me.ToolStripButton6.ToolTipText = "Exit"
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 121)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 625)
        Me.Panel2.TabIndex = 16
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Red
        Me.LinkLabel1.Location = New System.Drawing.Point(243, 59)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(260, 19)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Unregistered version, please register."
        '
        'DashBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DashBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DashBoard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripDropDownButton
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserManageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SwitchAccountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As ToolStripDropDownButton
    Friend WithEvents StockOrderingToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StockTransferToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReturnToVendorToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents StockCountToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DamageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpiryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents PromoUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents toolbarCheckIn As ToolStripDropDownButton
    Friend WithEvents StockTransferToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolbarRoom As ToolStripButton
    Friend WithEvents ToolStripButton12 As ToolStripDropDownButton
    Friend WithEvents ADDToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents StockOrderingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripButton2 As ToolStripDropDownButton
    Friend WithEvents RetunToVendorManageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton8 As ToolStripButton
    Friend WithEvents Manage_PC As ToolStripMenuItem
    Friend WithEvents ToolStripButton7 As ToolStripDropDownButton
    Friend WithEvents Inventory As ToolStripMenuItem
    Friend WithEvents Sotex As ToolStripMenuItem
    Friend WithEvents Bo As ToolStripMenuItem
    Friend WithEvents Btn_History As ToolStripDropDownButton
    Friend WithEvents InventoryManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoonToExpireToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BadOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btn_Manage As ToolStripButton
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ToolStripButton13 As ToolStripDropDownButton
    Friend WithEvents TOP1000SKUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents B1T1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SALESToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PriceUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton10 As ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ReturnToVendorToolStripMenuItem As ToolStripMenuItem
End Class
