<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Product_Information
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
        Dim BARCODE_EAN_UPC_Label As System.Windows.Forms.Label
        Dim SKULabel As System.Windows.Forms.Label
        Dim DESCRIPTIONSLabel As System.Windows.Forms.Label
        Dim BRANDLabel As System.Windows.Forms.Label
        Dim SIZELabel As System.Windows.Forms.Label
        Dim PRICELabel As System.Windows.Forms.Label
        Dim UNITLabel As System.Windows.Forms.Label
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim AVAILABILITYLabel As System.Windows.Forms.Label
        Dim TOTALLabel As System.Windows.Forms.Label
        Dim CATEGORYLabel1 As System.Windows.Forms.Label
        Dim VENDOR_CODELabel1 As System.Windows.Forms.Label
        Dim VENDORLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Product_Information))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.txtDescriptions = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtStockAvailable = New System.Windows.Forms.TextBox()
        Me.txtAvailability = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.btnDeleteProduct = New System.Windows.Forms.Button()
        Me.btnNotCarried = New System.Windows.Forms.Button()
        Me.btnCarried = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.cboVendorCode = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        BARCODE_EAN_UPC_Label = New System.Windows.Forms.Label()
        SKULabel = New System.Windows.Forms.Label()
        DESCRIPTIONSLabel = New System.Windows.Forms.Label()
        BRANDLabel = New System.Windows.Forms.Label()
        SIZELabel = New System.Windows.Forms.Label()
        PRICELabel = New System.Windows.Forms.Label()
        UNITLabel = New System.Windows.Forms.Label()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        AVAILABILITYLabel = New System.Windows.Forms.Label()
        TOTALLabel = New System.Windows.Forms.Label()
        CATEGORYLabel1 = New System.Windows.Forms.Label()
        VENDOR_CODELabel1 = New System.Windows.Forms.Label()
        VENDORLabel1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(9, 18)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(62, 13)
        BARCODE_EAN_UPC_Label.TabIndex = 254
        BARCODE_EAN_UPC_Label.Text = "BARCODE:"
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Location = New System.Drawing.Point(363, 18)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(32, 13)
        SKULabel.TabIndex = 256
        SKULabel.Text = "SKU:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(9, 50)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(90, 13)
        DESCRIPTIONSLabel.TabIndex = 258
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Location = New System.Drawing.Point(11, 82)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(48, 13)
        BRANDLabel.TabIndex = 260
        BRANDLabel.Text = "BRAND:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Location = New System.Drawing.Point(105, 15)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(34, 13)
        SIZELabel.TabIndex = 264
        SIZELabel.Text = "SIZE:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Location = New System.Drawing.Point(230, 15)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(42, 13)
        PRICELabel.TabIndex = 266
        PRICELabel.Text = "PRICE:"
        '
        'UNITLabel
        '
        UNITLabel.AutoSize = True
        UNITLabel.Location = New System.Drawing.Point(7, 16)
        UNITLabel.Name = "UNITLabel"
        UNITLabel.Size = New System.Drawing.Size(36, 13)
        UNITLabel.TabIndex = 268
        UNITLabel.Text = "UNIT:"
        '
        'STOCK_AVAILABLELabel
        '
        STOCK_AVAILABLELabel.AutoSize = True
        STOCK_AVAILABLELabel.Location = New System.Drawing.Point(302, 19)
        STOCK_AVAILABLELabel.Name = "STOCK_AVAILABLELabel"
        STOCK_AVAILABLELabel.Size = New System.Drawing.Size(106, 13)
        STOCK_AVAILABLELabel.TabIndex = 270
        STOCK_AVAILABLELabel.Text = "STOCK AVAILABLE:"
        '
        'AVAILABILITYLabel
        '
        AVAILABILITYLabel.AutoSize = True
        AVAILABILITYLabel.Location = New System.Drawing.Point(10, 19)
        AVAILABILITYLabel.Name = "AVAILABILITYLabel"
        AVAILABILITYLabel.Size = New System.Drawing.Size(80, 13)
        AVAILABILITYLabel.TabIndex = 272
        AVAILABILITYLabel.Text = "AVAILABILITY:"
        '
        'TOTALLabel
        '
        TOTALLabel.AutoSize = True
        TOTALLabel.Location = New System.Drawing.Point(468, 19)
        TOTALLabel.Name = "TOTALLabel"
        TOTALLabel.Size = New System.Drawing.Size(45, 13)
        TOTALLabel.TabIndex = 278
        TOTALLabel.Text = "TOTAL:"
        '
        'CATEGORYLabel1
        '
        CATEGORYLabel1.AutoSize = True
        CATEGORYLabel1.Location = New System.Drawing.Point(10, 114)
        CATEGORYLabel1.Name = "CATEGORYLabel1"
        CATEGORYLabel1.Size = New System.Drawing.Size(69, 13)
        CATEGORYLabel1.TabIndex = 280
        CATEGORYLabel1.Text = "CATEGORY:"
        '
        'VENDOR_CODELabel1
        '
        VENDOR_CODELabel1.AutoSize = True
        VENDOR_CODELabel1.Location = New System.Drawing.Point(9, 13)
        VENDOR_CODELabel1.Name = "VENDOR_CODELabel1"
        VENDOR_CODELabel1.Size = New System.Drawing.Size(89, 13)
        VENDOR_CODELabel1.TabIndex = 281
        VENDOR_CODELabel1.Text = "VENDOR CODE:"
        '
        'VENDORLabel1
        '
        VENDORLabel1.AutoSize = True
        VENDORLabel1.Location = New System.Drawing.Point(257, 13)
        VENDORLabel1.Name = "VENDORLabel1"
        VENDORLabel1.Size = New System.Drawing.Size(56, 13)
        VENDORLabel1.TabIndex = 282
        VENDORLabel1.Text = "VENDOR:"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Maroon
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(294, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(135, 37)
        Me.btnUpdate.TabIndex = 253
        Me.btnUpdate.Text = " Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(752, 54)
        Me.Panel1.TabIndex = 254
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(0, 0)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 54)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
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
        Me.Label1.Size = New System.Drawing.Size(366, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PRODUCT INFORMATION"
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(109, 10)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(248, 26)
        Me.txtBarcode.TabIndex = 255
        '
        'txtSKU
        '
        Me.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKU.Location = New System.Drawing.Point(401, 11)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.ReadOnly = True
        Me.txtSKU.Size = New System.Drawing.Size(168, 26)
        Me.txtSKU.TabIndex = 257
        '
        'txtDescriptions
        '
        Me.txtDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescriptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescriptions.Location = New System.Drawing.Point(109, 43)
        Me.txtDescriptions.Name = "txtDescriptions"
        Me.txtDescriptions.Size = New System.Drawing.Size(460, 26)
        Me.txtDescriptions.TabIndex = 259
        '
        'txtBrand
        '
        Me.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(109, 75)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(460, 26)
        Me.txtBrand.TabIndex = 261
        '
        'txtSize
        '
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(145, 8)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(79, 26)
        Me.txtSize.TabIndex = 265
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(278, 8)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(69, 26)
        Me.txtPrice.TabIndex = 267
        '
        'txtUnit
        '
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(49, 8)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(50, 26)
        Me.txtUnit.TabIndex = 269
        '
        'txtStockAvailable
        '
        Me.txtStockAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockAvailable.Location = New System.Drawing.Point(414, 12)
        Me.txtStockAvailable.Name = "txtStockAvailable"
        Me.txtStockAvailable.Size = New System.Drawing.Size(48, 26)
        Me.txtStockAvailable.TabIndex = 271
        '
        'txtAvailability
        '
        Me.txtAvailability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailability.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailability.Location = New System.Drawing.Point(96, 12)
        Me.txtAvailability.Name = "txtAvailability"
        Me.txtAvailability.ReadOnly = True
        Me.txtAvailability.Size = New System.Drawing.Size(200, 26)
        Me.txtAvailability.TabIndex = 273
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(519, 12)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(193, 26)
        Me.txtTotal.TabIndex = 279
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(576, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(135, 37)
        Me.btnClose.TabIndex = 280
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(108, 107)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(462, 26)
        Me.cboCategory.TabIndex = 281
        '
        'btnDeleteProduct
        '
        Me.btnDeleteProduct.BackColor = System.Drawing.Color.Maroon
        Me.btnDeleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDeleteProduct.Image = CType(resources.GetObject("btnDeleteProduct.Image"), System.Drawing.Image)
        Me.btnDeleteProduct.Location = New System.Drawing.Point(435, 5)
        Me.btnDeleteProduct.Name = "btnDeleteProduct"
        Me.btnDeleteProduct.Size = New System.Drawing.Size(135, 37)
        Me.btnDeleteProduct.TabIndex = 284
        Me.btnDeleteProduct.Text = " Delete Product"
        Me.btnDeleteProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDeleteProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteProduct.UseVisualStyleBackColor = False
        '
        'btnNotCarried
        '
        Me.btnNotCarried.BackColor = System.Drawing.Color.Maroon
        Me.btnNotCarried.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNotCarried.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNotCarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotCarried.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNotCarried.Image = CType(resources.GetObject("btnNotCarried.Image"), System.Drawing.Image)
        Me.btnNotCarried.Location = New System.Drawing.Point(154, 4)
        Me.btnNotCarried.Name = "btnNotCarried"
        Me.btnNotCarried.Size = New System.Drawing.Size(135, 37)
        Me.btnNotCarried.TabIndex = 286
        Me.btnNotCarried.Text = " Not Carried"
        Me.btnNotCarried.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNotCarried.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNotCarried.UseVisualStyleBackColor = False
        '
        'btnCarried
        '
        Me.btnCarried.BackColor = System.Drawing.Color.Maroon
        Me.btnCarried.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCarried.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarried.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarried.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCarried.Image = CType(resources.GetObject("btnCarried.Image"), System.Drawing.Image)
        Me.btnCarried.Location = New System.Drawing.Point(13, 3)
        Me.btnCarried.Name = "btnCarried"
        Me.btnCarried.Size = New System.Drawing.Size(135, 37)
        Me.btnCarried.TabIndex = 285
        Me.btnCarried.Text = " Carried"
        Me.btnCarried.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCarried.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCarried.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnCarried)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnNotCarried)
        Me.Panel2.Controls.Add(Me.btnDeleteProduct)
        Me.Panel2.Location = New System.Drawing.Point(12, 367)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(728, 49)
        Me.Panel2.TabIndex = 288
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtTotal)
        Me.Panel3.Controls.Add(TOTALLabel)
        Me.Panel3.Controls.Add(Me.txtStockAvailable)
        Me.Panel3.Controls.Add(STOCK_AVAILABLELabel)
        Me.Panel3.Controls.Add(Me.txtAvailability)
        Me.Panel3.Controls.Add(AVAILABILITYLabel)
        Me.Panel3.Location = New System.Drawing.Point(12, 311)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(728, 51)
        Me.Panel3.TabIndex = 289
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtSize)
        Me.Panel4.Controls.Add(SIZELabel)
        Me.Panel4.Controls.Add(Me.txtPrice)
        Me.Panel4.Controls.Add(PRICELabel)
        Me.Panel4.Controls.Add(Me.txtUnit)
        Me.Panel4.Controls.Add(UNITLabel)
        Me.Panel4.Location = New System.Drawing.Point(12, 262)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(728, 43)
        Me.Panel4.TabIndex = 290
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.cboCategory)
        Me.Panel5.Controls.Add(Me.txtSKU)
        Me.Panel5.Controls.Add(Me.picProduct)
        Me.Panel5.Controls.Add(SKULabel)
        Me.Panel5.Controls.Add(DESCRIPTIONSLabel)
        Me.Panel5.Controls.Add(CATEGORYLabel1)
        Me.Panel5.Controls.Add(Me.txtBarcode)
        Me.Panel5.Controls.Add(Me.txtBrand)
        Me.Panel5.Controls.Add(BARCODE_EAN_UPC_Label)
        Me.Panel5.Controls.Add(Me.txtDescriptions)
        Me.Panel5.Controls.Add(BRANDLabel)
        Me.Panel5.Location = New System.Drawing.Point(12, 60)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(728, 147)
        Me.Panel5.TabIndex = 291
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(575, 10)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(137, 123)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 293
        Me.picProduct.TabStop = False
        '
        'cboVendor
        '
        Me.cboVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(319, 6)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(393, 26)
        Me.cboVendor.TabIndex = 283
        '
        'cboVendorCode
        '
        Me.cboVendorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(104, 6)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(147, 26)
        Me.cboVendorCode.TabIndex = 282
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.cboVendorCode)
        Me.Panel6.Controls.Add(Me.cboVendor)
        Me.Panel6.Controls.Add(VENDORLabel1)
        Me.Panel6.Controls.Add(VENDOR_CODELabel1)
        Me.Panel6.Location = New System.Drawing.Point(12, 213)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(728, 43)
        Me.Panel6.TabIndex = 292
        '
        'Product_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 428)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Product_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product_Information"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtSKU As TextBox
    Friend WithEvents txtDescriptions As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtStockAvailable As TextBox
    Friend WithEvents txtAvailability As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents btnNotCarried As Button
    Friend WithEvents btnCarried As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents cboVendor As ComboBox
    Friend WithEvents cboVendorCode As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnDeleteProduct As Button
End Class
