<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOS_System
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS_System))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbldiscount = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsname = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbranch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancelTransaction = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnOnlinePayment = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnDiscount = New System.Windows.Forms.Button()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAmountInput = New System.Windows.Forms.TextBox()
        Me.lblAmountPaid = New System.Windows.Forms.Label()
        Me.lblRemainingBalance = New System.Windows.Forms.Label()
        Me.lblDiscountAmount = New System.Windows.Forms.Label()
        Me.lblDiscountedTotal = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.lblTransactionID)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.lbldiscount)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 54)
        Me.Panel2.TabIndex = 325
        '
        'lblTransactionID
        '
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionID.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTransactionID.Location = New System.Drawing.Point(1241, 29)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(15, 20)
        Me.lblTransactionID.TabIndex = 348
        Me.lblTransactionID.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkRed
        Me.Label15.Location = New System.Drawing.Point(1241, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 20)
        Me.Label15.TabIndex = 347
        Me.Label15.Text = "Transaction ID :"
        '
        'lbldiscount
        '
        Me.lbldiscount.AutoSize = True
        Me.lbldiscount.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldiscount.ForeColor = System.Drawing.Color.DarkRed
        Me.lbldiscount.Location = New System.Drawing.Point(79, 9)
        Me.lbldiscount.Name = "lbldiscount"
        Me.lbldiscount.Size = New System.Drawing.Size(223, 36)
        Me.lbldiscount.TabIndex = 0
        Me.lbldiscount.Text = "POINT OF SALE"
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblQty)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lblPrice)
        Me.Panel1.Controls.Add(Me.lblSize)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lblProductName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(929, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 213)
        Me.Panel1.TabIndex = 326
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkRed
        Me.Label16.Location = New System.Drawing.Point(15, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 20)
        Me.Label16.TabIndex = 343
        Me.Label16.Text = "product Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(264, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 20)
        Me.Label11.TabIndex = 342
        Me.Label11.Text = "Qty"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkRed
        Me.Label7.Location = New System.Drawing.Point(14, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 20)
        Me.Label7.TabIndex = 339
        Me.Label7.Text = "Total"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.DarkRed
        Me.lblQty.Location = New System.Drawing.Point(303, 110)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(15, 20)
        Me.lblQty.TabIndex = 338
        Me.lblQty.Text = "-"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkRed
        Me.Label13.Location = New System.Drawing.Point(137, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 341
        Me.Label13.Text = "price"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPrice.Location = New System.Drawing.Point(184, 110)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(15, 20)
        Me.lblPrice.TabIndex = 337
        Me.lblPrice.Text = "-"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.ForeColor = System.Drawing.Color.DarkRed
        Me.lblSize.Location = New System.Drawing.Point(54, 110)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(15, 20)
        Me.lblSize.TabIndex = 336
        Me.lblSize.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkRed
        Me.Label14.Location = New System.Drawing.Point(12, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 20)
        Me.Label14.TabIndex = 340
        Me.Label14.Text = "Size"
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.ForeColor = System.Drawing.Color.DarkRed
        Me.lblProductName.Location = New System.Drawing.Point(127, 63)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(15, 20)
        Me.lblProductName.TabIndex = 335
        Me.lblProductName.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 334
        Me.Label1.Text = "BARCODE"
        '
        'dgvCart
        '
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AllowUserToDeleteRows = False
        Me.dgvCart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCart.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCart.Location = New System.Drawing.Point(12, 60)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.ReadOnly = True
        Me.dgvCart.Size = New System.Drawing.Size(911, 570)
        Me.dgvCart.TabIndex = 327
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtBarcode)
        Me.Panel3.Location = New System.Drawing.Point(12, 636)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(911, 54)
        Me.Panel3.TabIndex = 327
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 20)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "BARCODE SCAN :"
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(150, 13)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(742, 28)
        Me.txtBarcode.TabIndex = 331
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsname, Me.tsbranch, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 746)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1366, 22)
        Me.StatusStrip1.TabIndex = 329
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsname
        '
        Me.tsname.Name = "tsname"
        Me.tsname.Size = New System.Drawing.Size(450, 17)
        Me.tsname.Spring = True
        '
        'tsbranch
        '
        Me.tsbranch.Name = "tsbranch"
        Me.tsbranch.Size = New System.Drawing.Size(450, 17)
        Me.tsbranch.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(450, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.Location = New System.Drawing.Point(1256, 696)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 47)
        Me.btnExit.TabIndex = 375
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancelTransaction
        '
        Me.btnCancelTransaction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelTransaction.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelTransaction.FlatAppearance.BorderSize = 0
        Me.btnCancelTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelTransaction.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelTransaction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancelTransaction.Image = CType(resources.GetObject("btnCancelTransaction.Image"), System.Drawing.Image)
        Me.btnCancelTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelTransaction.Location = New System.Drawing.Point(1052, 696)
        Me.btnCancelTransaction.Name = "btnCancelTransaction"
        Me.btnCancelTransaction.Size = New System.Drawing.Size(198, 47)
        Me.btnCancelTransaction.TabIndex = 376
        Me.btnCancelTransaction.Text = "Cancel Transaction"
        Me.btnCancelTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCancelTransaction.UseVisualStyleBackColor = False
        '
        'btnVoid
        '
        Me.btnVoid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoid.BackColor = System.Drawing.SystemColors.Control
        Me.btnVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVoid.FlatAppearance.BorderSize = 0
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoid.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnVoid.Image = CType(resources.GetObject("btnVoid.Image"), System.Drawing.Image)
        Me.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoid.Location = New System.Drawing.Point(948, 696)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(98, 47)
        Me.btnVoid.TabIndex = 377
        Me.btnVoid.Text = "Void"
        Me.btnVoid.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'btnOnlinePayment
        '
        Me.btnOnlinePayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOnlinePayment.BackColor = System.Drawing.SystemColors.Control
        Me.btnOnlinePayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOnlinePayment.FlatAppearance.BorderSize = 0
        Me.btnOnlinePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnlinePayment.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOnlinePayment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOnlinePayment.Image = CType(resources.GetObject("btnOnlinePayment.Image"), System.Drawing.Image)
        Me.btnOnlinePayment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOnlinePayment.Location = New System.Drawing.Point(653, 696)
        Me.btnOnlinePayment.Name = "btnOnlinePayment"
        Me.btnOnlinePayment.Size = New System.Drawing.Size(169, 47)
        Me.btnOnlinePayment.TabIndex = 378
        Me.btnOnlinePayment.Text = "Online Payment"
        Me.btnOnlinePayment.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnOnlinePayment.UseVisualStyleBackColor = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckOut.BackColor = System.Drawing.SystemColors.Control
        Me.btnCheckOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCheckOut.FlatAppearance.BorderSize = 0
        Me.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckOut.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCheckOut.Image = CType(resources.GetObject("btnCheckOut.Image"), System.Drawing.Image)
        Me.btnCheckOut.Location = New System.Drawing.Point(533, 696)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(114, 47)
        Me.btnCheckOut.TabIndex = 379
        Me.btnCheckOut.Text = "Check out"
        Me.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckOut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'btnDiscount
        '
        Me.btnDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDiscount.BackColor = System.Drawing.SystemColors.Control
        Me.btnDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDiscount.FlatAppearance.BorderSize = 0
        Me.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDiscount.Image = CType(resources.GetObject("btnDiscount.Image"), System.Drawing.Image)
        Me.btnDiscount.Location = New System.Drawing.Point(828, 696)
        Me.btnDiscount.Name = "btnDiscount"
        Me.btnDiscount.Size = New System.Drawing.Size(114, 47)
        Me.btnDiscount.TabIndex = 380
        Me.btnDiscount.Text = "Discount"
        Me.btnDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnDiscount.UseVisualStyleBackColor = False
        '
        'lblVAT
        '
        Me.lblVAT.AutoSize = True
        Me.lblVAT.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVAT.ForeColor = System.Drawing.Color.DarkRed
        Me.lblVAT.Location = New System.Drawing.Point(55, 170)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(15, 20)
        Me.lblVAT.TabIndex = 340
        Me.lblVAT.Text = "-"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotal.Location = New System.Drawing.Point(214, 170)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(15, 20)
        Me.lblTotal.TabIndex = 341
        Me.lblTotal.Text = "-"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblAmount.Location = New System.Drawing.Point(14, 359)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(112, 20)
        Me.lblAmount.TabIndex = 342
        Me.lblAmount.Text = "Amount Input :"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChange.ForeColor = System.Drawing.Color.DarkRed
        Me.lblChange.Location = New System.Drawing.Point(316, 359)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(15, 20)
        Me.lblChange.TabIndex = 343
        Me.lblChange.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(12, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 20)
        Me.Label12.TabIndex = 344
        Me.Label12.Text = "Payment Type"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblTotalAmount)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtAmountInput)
        Me.Panel4.Controls.Add(Me.lblAmountPaid)
        Me.Panel4.Controls.Add(Me.lblRemainingBalance)
        Me.Panel4.Controls.Add(Me.lblDiscountAmount)
        Me.Panel4.Controls.Add(Me.lblDiscountedTotal)
        Me.Panel4.Controls.Add(Me.lblVAT)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.lblTotal)
        Me.Panel4.Controls.Add(Me.lblAmount)
        Me.Panel4.Controls.Add(Me.lblChange)
        Me.Panel4.Location = New System.Drawing.Point(929, 279)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(425, 411)
        Me.Panel4.TabIndex = 340
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalAmount.Location = New System.Drawing.Point(129, 321)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(15, 20)
        Me.lblTotalAmount.TabIndex = 357
        Me.lblTotalAmount.Text = "-"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkRed
        Me.Label17.Location = New System.Drawing.Point(14, 321)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 20)
        Me.Label17.TabIndex = 356
        Me.Label17.Text = "Total Amount :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(12, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 20)
        Me.Label9.TabIndex = 355
        Me.Label9.Text = "Discount Amount"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(12, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 20)
        Me.Label10.TabIndex = 354
        Me.Label10.Text = "Discounted Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(12, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 20)
        Me.Label6.TabIndex = 352
        Me.Label6.Text = "VAT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Location = New System.Drawing.Point(166, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 20)
        Me.Label8.TabIndex = 353
        Me.Label8.Text = "Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(15, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 351
        Me.Label5.Text = "Amount Paid :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(14, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 350
        Me.Label4.Text = "Remaining Balance"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(248, 359)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 349
        Me.Label2.Text = "Change"
        '
        'txtAmountInput
        '
        Me.txtAmountInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmountInput.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountInput.Location = New System.Drawing.Point(131, 356)
        Me.txtAmountInput.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAmountInput.Name = "txtAmountInput"
        Me.txtAmountInput.Size = New System.Drawing.Size(112, 28)
        Me.txtAmountInput.TabIndex = 334
        Me.txtAmountInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.AutoSize = True
        Me.lblAmountPaid.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountPaid.ForeColor = System.Drawing.Color.DarkRed
        Me.lblAmountPaid.Location = New System.Drawing.Point(126, 223)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Size = New System.Drawing.Size(15, 20)
        Me.lblAmountPaid.TabIndex = 347
        Me.lblAmountPaid.Text = "-"
        '
        'lblRemainingBalance
        '
        Me.lblRemainingBalance.AutoSize = True
        Me.lblRemainingBalance.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemainingBalance.ForeColor = System.Drawing.Color.DarkRed
        Me.lblRemainingBalance.Location = New System.Drawing.Point(156, 284)
        Me.lblRemainingBalance.Name = "lblRemainingBalance"
        Me.lblRemainingBalance.Size = New System.Drawing.Size(15, 20)
        Me.lblRemainingBalance.TabIndex = 348
        Me.lblRemainingBalance.Text = "-"
        '
        'lblDiscountAmount
        '
        Me.lblDiscountAmount.AutoSize = True
        Me.lblDiscountAmount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscountAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblDiscountAmount.Location = New System.Drawing.Point(140, 74)
        Me.lblDiscountAmount.Name = "lblDiscountAmount"
        Me.lblDiscountAmount.Size = New System.Drawing.Size(15, 20)
        Me.lblDiscountAmount.TabIndex = 346
        Me.lblDiscountAmount.Text = "-"
        '
        'lblDiscountedTotal
        '
        Me.lblDiscountedTotal.AutoSize = True
        Me.lblDiscountedTotal.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscountedTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.lblDiscountedTotal.Location = New System.Drawing.Point(140, 122)
        Me.lblDiscountedTotal.Name = "lblDiscountedTotal"
        Me.lblDiscountedTotal.Size = New System.Drawing.Size(15, 20)
        Me.lblDiscountedTotal.TabIndex = 345
        Me.lblDiscountedTotal.Text = "-"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmPOS_System
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btnCancelTransaction)
        Me.Controls.Add(Me.btnDiscount)
        Me.Controls.Add(Me.btnCheckOut)
        Me.Controls.Add(Me.btnOnlinePayment)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dgvCart)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPOS_System"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPOS_System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbldiscount As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsname As ToolStripStatusLabel
    Friend WithEvents tsbranch As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents btnCancelTransaction As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents btnOnlinePayment As Button
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnDiscount As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblProductName As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblVAT As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblDiscountAmount As Label
    Friend WithEvents lblDiscountedTotal As Label
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblRemainingBalance As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAmountInput As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblAmountPaid As Label
    Friend WithEvents btnExit As Button
End Class
