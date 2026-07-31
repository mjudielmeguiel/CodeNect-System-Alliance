<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmADDProduct_Scan
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
        Dim SKULabel As System.Windows.Forms.Label
        Dim DESCRIPTIONSLabel As System.Windows.Forms.Label
        Dim BARCODE_EAN_UPC_Label As System.Windows.Forms.Label
        Dim BRANDLabel As System.Windows.Forms.Label
        Dim SIZELabel As System.Windows.Forms.Label
        Dim PRICELabel As System.Windows.Forms.Label
        Dim CATEGORYLabel1 As System.Windows.Forms.Label
        Dim UNITLabel As System.Windows.Forms.Label
        Dim VENDORLabel1 As System.Windows.Forms.Label
        Dim VENDOR_CODELabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmADDProduct_Scan))
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.txtVendorcode = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        SKULabel = New System.Windows.Forms.Label()
        DESCRIPTIONSLabel = New System.Windows.Forms.Label()
        BARCODE_EAN_UPC_Label = New System.Windows.Forms.Label()
        BRANDLabel = New System.Windows.Forms.Label()
        SIZELabel = New System.Windows.Forms.Label()
        PRICELabel = New System.Windows.Forms.Label()
        CATEGORYLabel1 = New System.Windows.Forms.Label()
        UNITLabel = New System.Windows.Forms.Label()
        VENDORLabel1 = New System.Windows.Forms.Label()
        VENDOR_CODELabel1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SKULabel.Location = New System.Drawing.Point(448, 95)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(45, 21)
        SKULabel.TabIndex = 256
        SKULabel.Text = "SKU:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(42, 158)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(129, 21)
        DESCRIPTIONSLabel.TabIndex = 258
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(42, 92)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(90, 21)
        BARCODE_EAN_UPC_Label.TabIndex = 254
        BARCODE_EAN_UPC_Label.Text = "BARCODE:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BRANDLabel.Location = New System.Drawing.Point(45, 213)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(70, 21)
        BRANDLabel.TabIndex = 260
        BRANDLabel.Text = "BRAND:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SIZELabel.Location = New System.Drawing.Point(45, 284)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(47, 21)
        SIZELabel.TabIndex = 264
        SIZELabel.Text = "SIZE:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PRICELabel.Location = New System.Drawing.Point(448, 354)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(59, 21)
        PRICELabel.TabIndex = 266
        PRICELabel.Text = "PRICE:"
        '
        'CATEGORYLabel1
        '
        CATEGORYLabel1.AutoSize = True
        CATEGORYLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CATEGORYLabel1.Location = New System.Drawing.Point(448, 213)
        CATEGORYLabel1.Name = "CATEGORYLabel1"
        CATEGORYLabel1.Size = New System.Drawing.Size(99, 21)
        CATEGORYLabel1.TabIndex = 280
        CATEGORYLabel1.Text = "CATEGORY:"
        '
        'UNITLabel
        '
        UNITLabel.AutoSize = True
        UNITLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UNITLabel.Location = New System.Drawing.Point(448, 284)
        UNITLabel.Name = "UNITLabel"
        UNITLabel.Size = New System.Drawing.Size(53, 21)
        UNITLabel.TabIndex = 268
        UNITLabel.Text = "UNIT:"
        '
        'VENDORLabel1
        '
        VENDORLabel1.AutoSize = True
        VENDORLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDORLabel1.Location = New System.Drawing.Point(42, 438)
        VENDORLabel1.Name = "VENDORLabel1"
        VENDORLabel1.Size = New System.Drawing.Size(82, 21)
        VENDORLabel1.TabIndex = 282
        VENDORLabel1.Text = "VENDOR:"
        '
        'VENDOR_CODELabel1
        '
        VENDOR_CODELabel1.AutoSize = True
        VENDOR_CODELabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDOR_CODELabel1.Location = New System.Drawing.Point(42, 354)
        VENDOR_CODELabel1.Name = "VENDOR_CODELabel1"
        VENDOR_CODELabel1.Size = New System.Drawing.Size(132, 21)
        VENDOR_CODELabel1.TabIndex = 281
        VENDOR_CODELabel1.Text = "VENDOR CODE:"
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(509, 95)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(17, 21)
        Me.lblSKU.TabIndex = 302
        Me.lblSKU.Text = "-"
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.SystemColors.Control
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(553, 348)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(254, 32)
        Me.txtPrice.TabIndex = 312
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(201, 152)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(606, 32)
        Me.txtDescription.TabIndex = 313
        '
        'txtBrand
        '
        Me.txtBrand.BackColor = System.Drawing.SystemColors.Control
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(201, 207)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(241, 32)
        Me.txtBrand.TabIndex = 314
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(198, 432)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(609, 32)
        Me.txtVendor.TabIndex = 317
        '
        'txtVendorcode
        '
        Me.txtVendorcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendorcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorcode.Location = New System.Drawing.Point(198, 348)
        Me.txtVendorcode.Name = "txtVendorcode"
        Me.txtVendorcode.Size = New System.Drawing.Size(244, 32)
        Me.txtVendorcode.TabIndex = 316
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.Control
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(553, 278)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(254, 32)
        Me.txtUnit.TabIndex = 320
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.SystemColors.Control
        Me.txtSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(198, 278)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(244, 32)
        Me.txtSize.TabIndex = 321
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(41, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(299, 26)
        Me.Label9.TabIndex = 324
        Me.Label9.Text = "Scan or Fill all Product Details"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DarkRed
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(837, 719)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(134, 37)
        Me.btnSave.TabIndex = 326
        Me.btnSave.Text = "Submit"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.cboCategory)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Controls.Add(Me.picProduct)
        Me.Panel1.Controls.Add(BARCODE_EAN_UPC_Label)
        Me.Panel1.Controls.Add(DESCRIPTIONSLabel)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(SKULabel)
        Me.Panel1.Controls.Add(BRANDLabel)
        Me.Panel1.Controls.Add(Me.txtSize)
        Me.Panel1.Controls.Add(CATEGORYLabel1)
        Me.Panel1.Controls.Add(Me.txtUnit)
        Me.Panel1.Controls.Add(VENDOR_CODELabel1)
        Me.Panel1.Controls.Add(Me.txtVendor)
        Me.Panel1.Controls.Add(VENDORLabel1)
        Me.Panel1.Controls.Add(Me.txtVendorcode)
        Me.Panel1.Controls.Add(Me.lblSKU)
        Me.Panel1.Controls.Add(Me.txtBrand)
        Me.Panel1.Controls.Add(Me.txtDescription)
        Me.Panel1.Controls.Add(Me.txtPrice)
        Me.Panel1.Controls.Add(PRICELabel)
        Me.Panel1.Controls.Add(SIZELabel)
        Me.Panel1.Controls.Add(UNITLabel)
        Me.Panel1.Location = New System.Drawing.Point(260, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(851, 664)
        Me.Panel1.TabIndex = 329
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(198, 86)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(241, 32)
        Me.txtBarcode.TabIndex = 326
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(646, 20)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(118, 111)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 293
        Me.picProduct.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 43)
        Me.Panel2.TabIndex = 330
        '
        'cboCategory
        '
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(553, 210)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(254, 29)
        Me.cboCategory.TabIndex = 327
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(977, 719)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 37)
        Me.Button1.TabIndex = 331
        Me.Button1.Text = "Category"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmADDProduct_Scan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmADDProduct_Scan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Description"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSKU As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents txtVendorcode As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Button1 As Button
End Class
