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
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        Me.SuspendLayout()
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SKULabel.Location = New System.Drawing.Point(458, 82)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(35, 17)
        SKULabel.TabIndex = 256
        SKULabel.Text = "SKU:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(38, 162)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(99, 17)
        DESCRIPTIONSLabel.TabIndex = 258
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(38, 82)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(69, 17)
        BARCODE_EAN_UPC_Label.TabIndex = 254
        BARCODE_EAN_UPC_Label.Text = "BARCODE:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BRANDLabel.Location = New System.Drawing.Point(650, 162)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(54, 17)
        BRANDLabel.TabIndex = 260
        BRANDLabel.Text = "BRAND:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SIZELabel.Location = New System.Drawing.Point(38, 249)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(36, 17)
        SIZELabel.TabIndex = 264
        SIZELabel.Text = "SIZE:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PRICELabel.Location = New System.Drawing.Point(209, 249)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(45, 17)
        PRICELabel.TabIndex = 266
        PRICELabel.Text = "PRICE:"
        '
        'CATEGORYLabel1
        '
        CATEGORYLabel1.AutoSize = True
        CATEGORYLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CATEGORYLabel1.Location = New System.Drawing.Point(458, 252)
        CATEGORYLabel1.Name = "CATEGORYLabel1"
        CATEGORYLabel1.Size = New System.Drawing.Size(75, 17)
        CATEGORYLabel1.TabIndex = 280
        CATEGORYLabel1.Text = "CATEGORY:"
        '
        'UNITLabel
        '
        UNITLabel.AutoSize = True
        UNITLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UNITLabel.Location = New System.Drawing.Point(351, 249)
        UNITLabel.Name = "UNITLabel"
        UNITLabel.Size = New System.Drawing.Size(41, 17)
        UNITLabel.TabIndex = 268
        UNITLabel.Text = "UNIT:"
        '
        'VENDORLabel1
        '
        VENDORLabel1.AutoSize = True
        VENDORLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDORLabel1.Location = New System.Drawing.Point(209, 338)
        VENDORLabel1.Name = "VENDORLabel1"
        VENDORLabel1.Size = New System.Drawing.Size(63, 17)
        VENDORLabel1.TabIndex = 282
        VENDORLabel1.Text = "VENDOR:"
        '
        'VENDOR_CODELabel1
        '
        VENDOR_CODELabel1.AutoSize = True
        VENDOR_CODELabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDOR_CODELabel1.Location = New System.Drawing.Point(38, 338)
        VENDOR_CODELabel1.Name = "VENDOR_CODELabel1"
        VENDOR_CODELabel1.Size = New System.Drawing.Size(101, 17)
        VENDOR_CODELabel1.TabIndex = 281
        VENDOR_CODELabel1.Text = "VENDOR CODE:"
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(457, 112)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(17, 21)
        Me.lblSKU.TabIndex = 302
        Me.lblSKU.Text = "-"
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(212, 269)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(136, 32)
        Me.txtPrice.TabIndex = 312
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(41, 182)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(606, 32)
        Me.txtDescription.TabIndex = 313
        '
        'txtBrand
        '
        Me.txtBrand.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(653, 182)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(254, 32)
        Me.txtBrand.TabIndex = 314
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(212, 358)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(698, 32)
        Me.txtVendor.TabIndex = 317
        '
        'txtVendorcode
        '
        Me.txtVendorcode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtVendorcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorcode.Location = New System.Drawing.Point(41, 358)
        Me.txtVendorcode.Name = "txtVendorcode"
        Me.txtVendorcode.Size = New System.Drawing.Size(165, 32)
        Me.txtVendorcode.TabIndex = 316
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(354, 269)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(101, 32)
        Me.txtUnit.TabIndex = 320
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(41, 269)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(165, 32)
        Me.txtSize.TabIndex = 321
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(12, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(299, 26)
        Me.Label9.TabIndex = 324
        Me.Label9.Text = "Scan or Fill all Product Details"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkRed
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(776, 431)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(134, 37)
        Me.btnSave.TabIndex = 326
        Me.btnSave.Text = "Submit"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cboCategory
        '
        Me.cboCategory.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCategory.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(461, 272)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(404, 29)
        Me.cboCategory.TabIndex = 327
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(41, 102)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(307, 32)
        Me.txtBarcode.TabIndex = 326
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(871, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 29)
        Me.Button1.TabIndex = 331
        Me.Button1.Text = "..."
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(886, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(54, 39)
        Me.btnCancel.TabIndex = 332
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmADDProduct_Scan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(952, 493)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(BARCODE_EAN_UPC_Label)
        Me.Controls.Add(DESCRIPTIONSLabel)
        Me.Controls.Add(UNITLabel)
        Me.Controls.Add(SIZELabel)
        Me.Controls.Add(SKULabel)
        Me.Controls.Add(PRICELabel)
        Me.Controls.Add(BRANDLabel)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(CATEGORYLabel1)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(VENDOR_CODELabel1)
        Me.Controls.Add(Me.txtVendorcode)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(VENDORLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmADDProduct_Scan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Description"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCancel As Button
End Class
