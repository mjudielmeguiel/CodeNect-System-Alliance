<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADD_Vendor_Product
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADD_Vendor_Product))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtBrand = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSaveProduct = New System.Windows.Forms.Button()
        Me.cboVendorName = New System.Windows.Forms.ComboBox()
        Me.cboVendorCode = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(480, 5)
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
        Me.cboCategory.Location = New System.Drawing.Point(12, 75)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(460, 26)
        Me.cboCategory.TabIndex = 281
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.cboVendorCode)
        Me.Panel5.Controls.Add(Me.cboCategory)
        Me.Panel5.Controls.Add(Me.cboVendorName)
        Me.Panel5.Controls.Add(Me.picProduct)
        Me.Panel5.Controls.Add(Me.txtBarcode)
        Me.Panel5.Controls.Add(Me.txtBrand)
        Me.Panel5.Controls.Add(Me.txtDescription)
        Me.Panel5.Location = New System.Drawing.Point(12, 60)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(629, 147)
        Me.Panel5.TabIndex = 303
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(478, 10)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(137, 123)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 293
        Me.picProduct.TabStop = False
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(12, 10)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(177, 26)
        Me.txtBarcode.TabIndex = 255
        '
        'txtBrand
        '
        Me.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrand.Location = New System.Drawing.Point(195, 11)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(277, 26)
        Me.txtBrand.TabIndex = 261
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(12, 43)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(460, 26)
        Me.txtDescription.TabIndex = 259
        '
        'txtSize
        '
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(68, 9)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(79, 26)
        Me.txtSize.TabIndex = 265
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(153, 10)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(69, 26)
        Me.txtPrice.TabIndex = 267
        '
        'txtUnit
        '
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(12, 9)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(50, 26)
        Me.txtUnit.TabIndex = 269
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtSize)
        Me.Panel2.Controls.Add(Me.btnSaveProduct)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.txtPrice)
        Me.Panel2.Controls.Add(Me.txtUnit)
        Me.Panel2.Location = New System.Drawing.Point(12, 213)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 49)
        Me.Panel2.TabIndex = 300
        '
        'btnSaveProduct
        '
        Me.btnSaveProduct.BackColor = System.Drawing.Color.Maroon
        Me.btnSaveProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveProduct.Image = CType(resources.GetObject("btnSaveProduct.Image"), System.Drawing.Image)
        Me.btnSaveProduct.Location = New System.Drawing.Point(337, 5)
        Me.btnSaveProduct.Name = "btnSaveProduct"
        Me.btnSaveProduct.Size = New System.Drawing.Size(135, 37)
        Me.btnSaveProduct.TabIndex = 253
        Me.btnSaveProduct.Text = " Save Product"
        Me.btnSaveProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveProduct.UseVisualStyleBackColor = False
        '
        'cboVendorName
        '
        Me.cboVendorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorName.FormattingEnabled = True
        Me.cboVendorName.Location = New System.Drawing.Point(165, 107)
        Me.cboVendorName.Name = "cboVendorName"
        Me.cboVendorName.Size = New System.Drawing.Size(307, 26)
        Me.cboVendorName.TabIndex = 283
        '
        'cboVendorCode
        '
        Me.cboVendorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(12, 107)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(147, 26)
        Me.cboVendorCode.TabIndex = 282
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
        Me.Panel1.Size = New System.Drawing.Size(652, 54)
        Me.Panel1.TabIndex = 299
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
        Me.Label1.Size = New System.Drawing.Size(423, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW VENDOR PRODUCT"
        '
        'ADD_Vendor_Product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 277)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ADD_Vendor_Product"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Vendor_Product"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSaveProduct As Button
    Friend WithEvents cboVendorName As ComboBox
    Friend WithEvents cboVendorCode As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
End Class
