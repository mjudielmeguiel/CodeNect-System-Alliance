<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmADDProduct_Scan
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
        Dim SKULabel As System.Windows.Forms.Label
        Dim DESCRIPTIONSLabel As System.Windows.Forms.Label
        Dim BARCODE_EAN_UPC_Label As System.Windows.Forms.Label
        Dim BRANDLabel As System.Windows.Forms.Label
        Dim SIZELabel As System.Windows.Forms.Label
        Dim PRICELabel As System.Windows.Forms.Label
        Dim CATEGORYLabel1 As System.Windows.Forms.Label
        Dim UNITLabel As System.Windows.Forms.Label
        Dim TOTALLabel As System.Windows.Forms.Label
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim AVAILABILITYLabel As System.Windows.Forms.Label
        Dim VENDORLabel1 As System.Windows.Forms.Label
        Dim VENDOR_CODELabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmADDProduct_Scan))
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtStockAvailable = New System.Windows.Forms.TextBox()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAvailability = New System.Windows.Forms.Label()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.lblVendorCode = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        SKULabel = New System.Windows.Forms.Label()
        DESCRIPTIONSLabel = New System.Windows.Forms.Label()
        BARCODE_EAN_UPC_Label = New System.Windows.Forms.Label()
        BRANDLabel = New System.Windows.Forms.Label()
        SIZELabel = New System.Windows.Forms.Label()
        PRICELabel = New System.Windows.Forms.Label()
        CATEGORYLabel1 = New System.Windows.Forms.Label()
        UNITLabel = New System.Windows.Forms.Label()
        TOTALLabel = New System.Windows.Forms.Label()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        AVAILABILITYLabel = New System.Windows.Forms.Label()
        VENDORLabel1 = New System.Windows.Forms.Label()
        VENDOR_CODELabel1 = New System.Windows.Forms.Label()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SKULabel.Location = New System.Drawing.Point(409, 103)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(45, 21)
        SKULabel.TabIndex = 256
        SKULabel.Text = "SKU:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(12, 148)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(129, 21)
        DESCRIPTIONSLabel.TabIndex = 258
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(12, 103)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(90, 21)
        BARCODE_EAN_UPC_Label.TabIndex = 254
        BARCODE_EAN_UPC_Label.Text = "BARCODE:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BRANDLabel.Location = New System.Drawing.Point(12, 198)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(70, 21)
        BRANDLabel.TabIndex = 260
        BRANDLabel.Text = "BRAND:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SIZELabel.Location = New System.Drawing.Point(409, 207)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(47, 21)
        SIZELabel.TabIndex = 264
        SIZELabel.Text = "SIZE:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PRICELabel.Location = New System.Drawing.Point(409, 372)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(59, 21)
        PRICELabel.TabIndex = 266
        PRICELabel.Text = "PRICE:"
        '
        'CATEGORYLabel1
        '
        CATEGORYLabel1.AutoSize = True
        CATEGORYLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CATEGORYLabel1.Location = New System.Drawing.Point(12, 256)
        CATEGORYLabel1.Name = "CATEGORYLabel1"
        CATEGORYLabel1.Size = New System.Drawing.Size(99, 21)
        CATEGORYLabel1.TabIndex = 280
        CATEGORYLabel1.Text = "CATEGORY:"
        '
        'UNITLabel
        '
        UNITLabel.AutoSize = True
        UNITLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UNITLabel.Location = New System.Drawing.Point(409, 256)
        UNITLabel.Name = "UNITLabel"
        UNITLabel.Size = New System.Drawing.Size(53, 21)
        UNITLabel.TabIndex = 268
        UNITLabel.Text = "UNIT:"
        '
        'TOTALLabel
        '
        TOTALLabel.AutoSize = True
        TOTALLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TOTALLabel.Location = New System.Drawing.Point(409, 314)
        TOTALLabel.Name = "TOTALLabel"
        TOTALLabel.Size = New System.Drawing.Size(64, 21)
        TOTALLabel.TabIndex = 278
        TOTALLabel.Text = "TOTAL:"
        '
        'STOCK_AVAILABLELabel
        '
        STOCK_AVAILABLELabel.AutoSize = True
        STOCK_AVAILABLELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        STOCK_AVAILABLELabel.Location = New System.Drawing.Point(409, 422)
        STOCK_AVAILABLELabel.Name = "STOCK_AVAILABLELabel"
        STOCK_AVAILABLELabel.Size = New System.Drawing.Size(46, 21)
        STOCK_AVAILABLELabel.TabIndex = 270
        STOCK_AVAILABLELabel.Text = "QTY:"
        '
        'AVAILABILITYLabel
        '
        AVAILABILITYLabel.AutoSize = True
        AVAILABILITYLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AVAILABILITYLabel.Location = New System.Drawing.Point(12, 422)
        AVAILABILITYLabel.Name = "AVAILABILITYLabel"
        AVAILABILITYLabel.Size = New System.Drawing.Size(118, 21)
        AVAILABILITYLabel.TabIndex = 272
        AVAILABILITYLabel.Text = "AVAILABILITY:"
        '
        'VENDORLabel1
        '
        VENDORLabel1.AutoSize = True
        VENDORLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDORLabel1.Location = New System.Drawing.Point(12, 368)
        VENDORLabel1.Name = "VENDORLabel1"
        VENDORLabel1.Size = New System.Drawing.Size(82, 21)
        VENDORLabel1.TabIndex = 282
        VENDORLabel1.Text = "VENDOR:"
        '
        'VENDOR_CODELabel1
        '
        VENDOR_CODELabel1.AutoSize = True
        VENDOR_CODELabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDOR_CODELabel1.Location = New System.Drawing.Point(12, 314)
        VENDOR_CODELabel1.Name = "VENDOR_CODELabel1"
        VENDOR_CODELabel1.Size = New System.Drawing.Size(132, 21)
        VENDOR_CODELabel1.TabIndex = 281
        VENDOR_CODELabel1.Text = "VENDOR CODE:"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(171, 100)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(232, 25)
        Me.txtBarcode.TabIndex = 255
        '
        'txtStockAvailable
        '
        Me.txtStockAvailable.BackColor = System.Drawing.SystemColors.Control
        Me.txtStockAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStockAvailable.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockAvailable.Location = New System.Drawing.Point(461, 422)
        Me.txtStockAvailable.Name = "txtStockAvailable"
        Me.txtStockAvailable.Size = New System.Drawing.Size(158, 25)
        Me.txtStockAvailable.TabIndex = 271
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(631, 88)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(261, 247)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 293
        Me.picProduct.TabStop = False
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
        Me.btnClose.TabIndex = 299
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
        Me.btnSave.TabIndex = 300
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(91, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW PRODUCT SCAN"
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(12, 12)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 54)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.SystemColors.Control
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(471, 369)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(148, 25)
        Me.txtPrice.TabIndex = 312
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(460, 104)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(17, 21)
        Me.lblSKU.TabIndex = 302
        Me.lblSKU.Text = "-"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(468, 207)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(17, 21)
        Me.lblSize.TabIndex = 308
        Me.lblSize.Text = "-"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.Location = New System.Drawing.Point(470, 256)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(17, 21)
        Me.lblUnit.TabIndex = 309
        Me.lblUnit.Text = "-"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(479, 314)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(17, 21)
        Me.lblTotal.TabIndex = 311
        Me.lblTotal.Text = "-"
        '
        'lblAvailability
        '
        Me.lblAvailability.AutoSize = True
        Me.lblAvailability.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailability.Location = New System.Drawing.Point(167, 422)
        Me.lblAvailability.Name = "lblAvailability"
        Me.lblAvailability.Size = New System.Drawing.Size(17, 21)
        Me.lblAvailability.TabIndex = 312
        Me.lblAvailability.Text = "-"
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendor.Location = New System.Drawing.Point(167, 372)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(17, 21)
        Me.lblVendor.TabIndex = 307
        Me.lblVendor.Text = "-"
        '
        'lblVendorCode
        '
        Me.lblVendorCode.AutoSize = True
        Me.lblVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorCode.Location = New System.Drawing.Point(167, 314)
        Me.lblVendorCode.Name = "lblVendorCode"
        Me.lblVendorCode.Size = New System.Drawing.Size(17, 21)
        Me.lblVendorCode.TabIndex = 306
        Me.lblVendorCode.Text = "-"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(167, 256)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(17, 21)
        Me.lblCategory.TabIndex = 305
        Me.lblCategory.Text = "-"
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.Location = New System.Drawing.Point(167, 198)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(17, 21)
        Me.lblBrand.TabIndex = 303
        Me.lblBrand.Text = "-"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(167, 148)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(17, 21)
        Me.lblDescription.TabIndex = 304
        Me.lblDescription.Text = "-"
        '
        'frmADDProduct_Scan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 473)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(TOTALLabel)
        Me.Controls.Add(UNITLabel)
        Me.Controls.Add(Me.adminpic)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.lblAvailability)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(SIZELabel)
        Me.Controls.Add(PRICELabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVendorCode)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtStockAvailable)
        Me.Controls.Add(Me.lblBrand)
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
        Me.Name = "frmADDProduct_Scan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Description"
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents txtStockAvailable As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblSKU As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblAvailability As Label
    Friend WithEvents lblVendor As Label
    Friend WithEvents lblVendorCode As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblDescription As Label
End Class
