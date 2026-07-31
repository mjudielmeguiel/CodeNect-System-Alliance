<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmADDProduct_Manual
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TOTALLabel As System.Windows.Forms.Label
        Dim UNITLabel As System.Windows.Forms.Label
        Dim SIZELabel As System.Windows.Forms.Label
        Dim PRICELabel As System.Windows.Forms.Label
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim AVAILABILITYLabel As System.Windows.Forms.Label
        Dim VENDORLabel1 As System.Windows.Forms.Label
        Dim VENDOR_CODELabel1 As System.Windows.Forms.Label
        Dim DESCRIPTIONSLabel As System.Windows.Forms.Label
        Dim CATEGORYLabel1 As System.Windows.Forms.Label
        Dim BRANDLabel As System.Windows.Forms.Label
        Dim SKULabel As System.Windows.Forms.Label
        Dim BARCODE_EAN_UPC_Label As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmADDProduct_Manual))
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStockAvailable = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.cboVendorCode = New System.Windows.Forms.ComboBox()
        Me.cboVendor = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.lblAvailability = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        TOTALLabel = New System.Windows.Forms.Label()
        UNITLabel = New System.Windows.Forms.Label()
        SIZELabel = New System.Windows.Forms.Label()
        PRICELabel = New System.Windows.Forms.Label()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        AVAILABILITYLabel = New System.Windows.Forms.Label()
        VENDORLabel1 = New System.Windows.Forms.Label()
        VENDOR_CODELabel1 = New System.Windows.Forms.Label()
        DESCRIPTIONSLabel = New System.Windows.Forms.Label()
        CATEGORYLabel1 = New System.Windows.Forms.Label()
        BRANDLabel = New System.Windows.Forms.Label()
        SKULabel = New System.Windows.Forms.Label()
        BARCODE_EAN_UPC_Label = New System.Windows.Forms.Label()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TOTALLabel
        '
        TOTALLabel.AutoSize = True
        TOTALLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TOTALLabel.Location = New System.Drawing.Point(409, 314)
        TOTALLabel.Name = "TOTALLabel"
        TOTALLabel.Size = New System.Drawing.Size(64, 21)
        TOTALLabel.TabIndex = 326
        TOTALLabel.Text = "TOTAL:"
        '
        'UNITLabel
        '
        UNITLabel.AutoSize = True
        UNITLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UNITLabel.Location = New System.Drawing.Point(409, 256)
        UNITLabel.Name = "UNITLabel"
        UNITLabel.Size = New System.Drawing.Size(53, 21)
        UNITLabel.TabIndex = 322
        UNITLabel.Text = "UNIT:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SIZELabel.Location = New System.Drawing.Point(409, 207)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(47, 21)
        SIZELabel.TabIndex = 320
        SIZELabel.Text = "SIZE:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PRICELabel.Location = New System.Drawing.Point(409, 372)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(59, 21)
        PRICELabel.TabIndex = 321
        PRICELabel.Text = "PRICE:"
        '
        'STOCK_AVAILABLELabel
        '
        STOCK_AVAILABLELabel.AutoSize = True
        STOCK_AVAILABLELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        STOCK_AVAILABLELabel.Location = New System.Drawing.Point(409, 422)
        STOCK_AVAILABLELabel.Name = "STOCK_AVAILABLELabel"
        STOCK_AVAILABLELabel.Size = New System.Drawing.Size(46, 21)
        STOCK_AVAILABLELabel.TabIndex = 323
        STOCK_AVAILABLELabel.Text = "QTY:"
        '
        'AVAILABILITYLabel
        '
        AVAILABILITYLabel.AutoSize = True
        AVAILABILITYLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AVAILABILITYLabel.Location = New System.Drawing.Point(12, 422)
        AVAILABILITYLabel.Name = "AVAILABILITYLabel"
        AVAILABILITYLabel.Size = New System.Drawing.Size(118, 21)
        AVAILABILITYLabel.TabIndex = 325
        AVAILABILITYLabel.Text = "AVAILABILITY:"
        '
        'VENDORLabel1
        '
        VENDORLabel1.AutoSize = True
        VENDORLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDORLabel1.Location = New System.Drawing.Point(12, 368)
        VENDORLabel1.Name = "VENDORLabel1"
        VENDORLabel1.Size = New System.Drawing.Size(82, 21)
        VENDORLabel1.TabIndex = 329
        VENDORLabel1.Text = "VENDOR:"
        '
        'VENDOR_CODELabel1
        '
        VENDOR_CODELabel1.AutoSize = True
        VENDOR_CODELabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDOR_CODELabel1.Location = New System.Drawing.Point(12, 314)
        VENDOR_CODELabel1.Name = "VENDOR_CODELabel1"
        VENDOR_CODELabel1.Size = New System.Drawing.Size(132, 21)
        VENDOR_CODELabel1.TabIndex = 328
        VENDOR_CODELabel1.Text = "VENDOR CODE:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(12, 148)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(129, 21)
        DESCRIPTIONSLabel.TabIndex = 318
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'CATEGORYLabel1
        '
        CATEGORYLabel1.AutoSize = True
        CATEGORYLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CATEGORYLabel1.Location = New System.Drawing.Point(12, 256)
        CATEGORYLabel1.Name = "CATEGORYLabel1"
        CATEGORYLabel1.Size = New System.Drawing.Size(99, 21)
        CATEGORYLabel1.TabIndex = 327
        CATEGORYLabel1.Text = "CATEGORY:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BRANDLabel.Location = New System.Drawing.Point(12, 198)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(70, 21)
        BRANDLabel.TabIndex = 319
        BRANDLabel.Text = "BRAND:"
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SKULabel.Location = New System.Drawing.Point(409, 103)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(45, 21)
        SKULabel.TabIndex = 317
        SKULabel.Text = "SKU:"
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(12, 103)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(90, 21)
        BARCODE_EAN_UPC_Label.TabIndex = 315
        BARCODE_EAN_UPC_Label.Text = "BARCODE:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(479, 314)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(17, 21)
        Me.lblTotal.TabIndex = 341
        Me.lblTotal.Text = "-"
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(471, 369)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(148, 25)
        Me.txtPrice.TabIndex = 343
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(12, 12)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 54)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 314
        Me.adminpic.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(91, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(431, 36)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "ADD NEW PRODUCT MANUAL"
        '
        'txtStockAvailable
        '
        Me.txtStockAvailable.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtStockAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStockAvailable.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockAvailable.Location = New System.Drawing.Point(471, 422)
        Me.txtStockAvailable.Name = "txtStockAvailable"
        Me.txtStockAvailable.Size = New System.Drawing.Size(148, 25)
        Me.txtStockAvailable.TabIndex = 324
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(460, 104)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(17, 21)
        Me.lblSKU.TabIndex = 333
        Me.lblSKU.Text = "-"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(794, 414)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 331
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(690, 414)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 47)
        Me.btnSave.TabIndex = 332
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(631, 88)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(261, 247)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 330
        Me.picProduct.TabStop = False
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(151, 100)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(252, 25)
        Me.txtBarcode.TabIndex = 316
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(151, 145)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(468, 25)
        Me.txtDescription.TabIndex = 344
        '
        'txtBrand
        '
        Me.txtBrand.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(171, 195)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(232, 25)
        Me.txtBrand.TabIndex = 345
        '
        'cboVendorCode
        '
        Me.cboVendorCode.BackColor = System.Drawing.SystemColors.Control
        Me.cboVendorCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(150, 308)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(253, 33)
        Me.cboVendorCode.TabIndex = 347
        '
        'cboVendor
        '
        Me.cboVendor.BackColor = System.Drawing.SystemColors.Control
        Me.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(100, 362)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(303, 33)
        Me.cboVendor.TabIndex = 348
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(468, 253)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(151, 25)
        Me.txtUnit.TabIndex = 350
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(461, 204)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(158, 25)
        Me.txtSize.TabIndex = 351
        '
        'lblAvailability
        '
        Me.lblAvailability.AutoSize = True
        Me.lblAvailability.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailability.Location = New System.Drawing.Point(147, 426)
        Me.lblAvailability.Name = "lblAvailability"
        Me.lblAvailability.Size = New System.Drawing.Size(17, 21)
        Me.lblAvailability.TabIndex = 352
        Me.lblAvailability.Text = "-"
        '
        'cboCategory
        '
        Me.cboCategory.BackColor = System.Drawing.SystemColors.Control
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(151, 250)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(252, 33)
        Me.cboCategory.TabIndex = 346
        '
        'frmADDProduct_Manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 473)
        Me.Controls.Add(Me.lblAvailability)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.cboVendorCode)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(TOTALLabel)
        Me.Controls.Add(UNITLabel)
        Me.Controls.Add(Me.adminpic)
        Me.Controls.Add(SIZELabel)
        Me.Controls.Add(PRICELabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStockAvailable)
        Me.Controls.Add(STOCK_AVAILABLELabel)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(AVAILABILITYLabel)
        Me.Controls.Add(VENDORLabel1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(VENDOR_CODELabel1)
        Me.Controls.Add(DESCRIPTIONSLabel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(CATEGORYLabel1)
        Me.Controls.Add(BRANDLabel)
        Me.Controls.Add(SKULabel)
        Me.Controls.Add(Me.picProduct)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(BARCODE_EAN_UPC_Label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmADDProduct_Manual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmADDProduct_Manual"
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotal As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStockAvailable As TextBox
    Friend WithEvents lblSKU As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents cboVendorCode As ComboBox
    Friend WithEvents cboVendor As ComboBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents lblAvailability As Label
    Friend WithEvents cboCategory As ComboBox
End Class
