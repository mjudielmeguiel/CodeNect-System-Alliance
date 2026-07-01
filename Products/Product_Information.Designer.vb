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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Product_Information))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDeleteProduct = New System.Windows.Forms.Button()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.lblVendorCode = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblAvailability = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblStockAvailable = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(780, 362)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 280
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnDeleteProduct
        '
        Me.btnDeleteProduct.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDeleteProduct.FlatAppearance.BorderSize = 0
        Me.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteProduct.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProduct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteProduct.Image = CType(resources.GetObject("btnDeleteProduct.Image"), System.Drawing.Image)
        Me.btnDeleteProduct.Location = New System.Drawing.Point(676, 362)
        Me.btnDeleteProduct.Name = "btnDeleteProduct"
        Me.btnDeleteProduct.Size = New System.Drawing.Size(98, 47)
        Me.btnDeleteProduct.TabIndex = 284
        Me.btnDeleteProduct.Text = "Delete"
        Me.btnDeleteProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnDeleteProduct.UseVisualStyleBackColor = False
        '
        'picProduct
        '
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(12, 12)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(258, 249)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 293
        Me.picProduct.TabStop = False
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcode.Location = New System.Drawing.Point(362, 21)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(27, 36)
        Me.lblBarcode.TabIndex = 295
        Me.lblBarcode.Text = "-"
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = True
        Me.lblSKU.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSKU.Location = New System.Drawing.Point(672, 21)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(27, 36)
        Me.lblSKU.TabIndex = 296
        Me.lblSKU.Text = "-"
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.Location = New System.Drawing.Point(278, 125)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(17, 24)
        Me.lblBrand.TabIndex = 298
        Me.lblBrand.Text = "-"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(277, 70)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(21, 28)
        Me.lblDescription.TabIndex = 297
        Me.lblDescription.Text = "-"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.DarkRed
        Me.lblUnit.Location = New System.Drawing.Point(489, 373)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(19, 21)
        Me.lblUnit.TabIndex = 302
        Me.lblUnit.Text = "0"
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendor.ForeColor = System.Drawing.Color.DarkRed
        Me.lblVendor.Location = New System.Drawing.Point(355, 297)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(17, 22)
        Me.lblVendor.TabIndex = 301
        Me.lblVendor.Text = "-"
        '
        'lblVendorCode
        '
        Me.lblVendorCode.AutoSize = True
        Me.lblVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorCode.ForeColor = System.Drawing.Color.DarkRed
        Me.lblVendorCode.Location = New System.Drawing.Point(132, 297)
        Me.lblVendorCode.Name = "lblVendorCode"
        Me.lblVendorCode.Size = New System.Drawing.Size(17, 22)
        Me.lblVendorCode.TabIndex = 300
        Me.lblVendorCode.Text = "-"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(617, 214)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(20, 26)
        Me.lblCategory.TabIndex = 299
        Me.lblCategory.Text = "-"
        '
        'lblAvailability
        '
        Me.lblAvailability.AutoSize = True
        Me.lblAvailability.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailability.Location = New System.Drawing.Point(617, 125)
        Me.lblAvailability.Name = "lblAvailability"
        Me.lblAvailability.Size = New System.Drawing.Size(20, 26)
        Me.lblAvailability.TabIndex = 306
        Me.lblAvailability.Text = "-"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPrice.Location = New System.Drawing.Point(274, 168)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(96, 46)
        Me.lblPrice.TabIndex = 304
        Me.lblPrice.Text = "0.00"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(277, 214)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(20, 26)
        Me.lblSize.TabIndex = 303
        Me.lblSize.Text = "-"
        '
        'lblStockAvailable
        '
        Me.lblStockAvailable.AutoSize = True
        Me.lblStockAvailable.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockAvailable.ForeColor = System.Drawing.Color.DarkRed
        Me.lblStockAvailable.Location = New System.Drawing.Point(68, 375)
        Me.lblStockAvailable.Name = "lblStockAvailable"
        Me.lblStockAvailable.Size = New System.Drawing.Size(19, 21)
        Me.lblStockAvailable.TabIndex = 305
        Me.lblStockAvailable.Text = "0"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotal.Location = New System.Drawing.Point(250, 373)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(19, 21)
        Me.lblTotal.TabIndex = 307
        Me.lblTotal.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 375)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 21)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "QTY :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(184, 373)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 21)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "Value :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(435, 373)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 21)
        Me.Label3.TabIndex = 311
        Me.Label3.Text = "Unit :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(276, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 21)
        Me.Label6.TabIndex = 315
        Me.Label6.Text = "Barcode :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(618, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 21)
        Me.Label7.TabIndex = 316
        Me.Label7.Text = "SKU :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 21)
        Me.Label8.TabIndex = 317
        Me.Label8.Text = "Vendor Code :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(276, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 21)
        Me.Label9.TabIndex = 318
        Me.Label9.Text = "Vendor :"
        '
        'Product_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 421)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblBarcode)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.btnDeleteProduct)
        Me.Controls.Add(Me.lblVendorCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblAvailability)
        Me.Controls.Add(Me.lblStockAvailable)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.picProduct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Product_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product_Information"
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents btnDeleteProduct As Button
    Friend WithEvents lblBarcode As Label
    Friend WithEvents lblSKU As Label
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents lblVendor As Label
    Friend WithEvents lblVendorCode As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblAvailability As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblStockAvailable As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
