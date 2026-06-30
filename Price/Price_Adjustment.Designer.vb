<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Price_Adjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Price_Adjustment))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.lblAvail = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.picProduct = New System.Windows.Forms.PictureBox()
        Me.lblVendorCode = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Controls.Add(Me.lblAvail)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(659, 54)
        Me.Panel2.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PRICE ADJUSTMENT"
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
        'lblAvail
        '
        Me.lblAvail.AutoSize = True
        Me.lblAvail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvail.ForeColor = System.Drawing.Color.Black
        Me.lblAvail.Location = New System.Drawing.Point(535, 18)
        Me.lblAvail.Name = "lblAvail"
        Me.lblAvail.Size = New System.Drawing.Size(112, 22)
        Me.lblAvail.TabIndex = 8
        Me.lblAvail.Text = "AVAIABILITY"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtbarcode)
        Me.Panel3.Controls.Add(Me.txtPrice)
        Me.Panel3.Controls.Add(Me.lblVendor)
        Me.Panel3.Controls.Add(Me.picProduct)
        Me.Panel3.Controls.Add(Me.lblVendorCode)
        Me.Panel3.Controls.Add(Me.lblSize)
        Me.Panel3.Controls.Add(Me.lblDesc)
        Me.Panel3.Controls.Add(Me.lblBrand)
        Me.Panel3.Location = New System.Drawing.Point(12, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(635, 207)
        Me.Panel3.TabIndex = 48
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendor.Location = New System.Drawing.Point(299, 124)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(86, 22)
        Me.lblVendor.TabIndex = 10
        Me.lblVendor.Text = "VENDOR:"
        '
        'picProduct
        '
        Me.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProduct.Image = CType(resources.GetObject("picProduct.Image"), System.Drawing.Image)
        Me.picProduct.Location = New System.Drawing.Point(15, 20)
        Me.picProduct.Name = "picProduct"
        Me.picProduct.Size = New System.Drawing.Size(140, 126)
        Me.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProduct.TabIndex = 25
        Me.picProduct.TabStop = False
        '
        'lblVendorCode
        '
        Me.lblVendorCode.AutoSize = True
        Me.lblVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorCode.Location = New System.Drawing.Point(161, 124)
        Me.lblVendorCode.Name = "lblVendorCode"
        Me.lblVendorCode.Size = New System.Drawing.Size(132, 22)
        Me.lblVendorCode.TabIndex = 9
        Me.lblVendorCode.Text = "VENDOR CODE"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(163, 91)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(49, 22)
        Me.lblSize.TabIndex = 5
        Me.lblSize.Text = "SIZE:"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.Location = New System.Drawing.Point(160, 56)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(159, 26)
        Me.lblDesc.TabIndex = 3
        Me.lblDesc.Text = "DESCRIPTIONS:"
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.Location = New System.Drawing.Point(161, 20)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(124, 36)
        Me.lblBrand.TabIndex = 2
        Me.lblBrand.Text = "BRAND:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 273)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(635, 59)
        Me.Panel1.TabIndex = 47
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(15, 152)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(140, 38)
        Me.txtPrice.TabIndex = 26
        '
        'txtbarcode
        '
        Me.txtbarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.Location = New System.Drawing.Point(161, 152)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(274, 38)
        Me.txtbarcode.TabIndex = 27
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(483, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 221
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(342, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 220
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-249, -548)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 109)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 219
        Me.PictureBox1.TabStop = False
        '
        'Price_Adjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 343)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Price_Adjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price_Adjustment"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents lblVendor As Label
    Friend WithEvents lblVendorCode As Label
    Friend WithEvents lblAvail As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents picProduct As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents lblDesc As Label
End Class
