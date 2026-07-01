<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShelfTag_Printer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShelfTag_Printer))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdo50 = New System.Windows.Forms.RadioButton()
        Me.rdo20 = New System.Windows.Forms.RadioButton()
        Me.rdo10 = New System.Windows.Forms.RadioButton()
        Me.rdoPriceUpdate = New System.Windows.Forms.RadioButton()
        Me.rdoBuy1Take1 = New System.Windows.Forms.RadioButton()
        Me.rdoShelfTag = New System.Windows.Forms.RadioButton()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Location = New System.Drawing.Point(12, 489)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(731, 48)
        Me.Panel2.TabIndex = 327
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Maroon
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(150, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 37)
        Me.btnAdd.TabIndex = 335
        Me.btnAdd.Text = " ADD"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(573, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(141, 37)
        Me.btnClose.TabIndex = 139
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Maroon
        Me.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(432, 6)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(135, 37)
        Me.btnRemove.TabIndex = 223
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.Maroon
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(9, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(135, 37)
        Me.btnPrint.TabIndex = 224
        Me.btnPrint.Text = " Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Maroon
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(291, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 37)
        Me.btnRefresh.TabIndex = 211
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(660, 9)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(54, 29)
        Me.txtQuantity.TabIndex = 225
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(76, 9)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(394, 29)
        Me.txtBarcode.TabIndex = 212
        '
        'dgvItems
        '
        Me.dgvItems.AllowUserToDeleteRows = False
        Me.dgvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Location = New System.Drawing.Point(12, 212)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItems.Size = New System.Drawing.Size(731, 271)
        Me.dgvItems.TabIndex = 328
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkRed
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.adminpic)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(755, 54)
        Me.Panel4.TabIndex = 334
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SHELFTAG Printer"
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
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtQuantity)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Location = New System.Drawing.Point(12, 158)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 48)
        Me.Panel1.TabIndex = 335
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(622, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "QTY:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "BARCODE:"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.rdo50)
        Me.Panel3.Controls.Add(Me.rdo20)
        Me.Panel3.Controls.Add(Me.rdo10)
        Me.Panel3.Controls.Add(Me.rdoPriceUpdate)
        Me.Panel3.Controls.Add(Me.rdoBuy1Take1)
        Me.Panel3.Controls.Add(Me.rdoShelfTag)
        Me.Panel3.Location = New System.Drawing.Point(12, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 92)
        Me.Panel3.TabIndex = 336
        '
        'rdo50
        '
        Me.rdo50.AutoSize = True
        Me.rdo50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo50.Location = New System.Drawing.Point(150, 61)
        Me.rdo50.Name = "rdo50"
        Me.rdo50.Size = New System.Drawing.Size(75, 17)
        Me.rdo50.TabIndex = 8
        Me.rdo50.TabStop = True
        Me.rdo50.Text = "50% OFF"
        Me.rdo50.UseVisualStyleBackColor = True
        '
        'rdo20
        '
        Me.rdo20.AutoSize = True
        Me.rdo20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo20.Location = New System.Drawing.Point(150, 38)
        Me.rdo20.Name = "rdo20"
        Me.rdo20.Size = New System.Drawing.Size(75, 17)
        Me.rdo20.TabIndex = 7
        Me.rdo20.TabStop = True
        Me.rdo20.Text = "20% OFF"
        Me.rdo20.UseVisualStyleBackColor = True
        '
        'rdo10
        '
        Me.rdo10.AutoSize = True
        Me.rdo10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo10.Location = New System.Drawing.Point(150, 15)
        Me.rdo10.Name = "rdo10"
        Me.rdo10.Size = New System.Drawing.Size(75, 17)
        Me.rdo10.TabIndex = 6
        Me.rdo10.TabStop = True
        Me.rdo10.Text = "10% OFF"
        Me.rdo10.UseVisualStyleBackColor = True
        '
        'rdoPriceUpdate
        '
        Me.rdoPriceUpdate.AutoSize = True
        Me.rdoPriceUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPriceUpdate.Location = New System.Drawing.Point(11, 61)
        Me.rdoPriceUpdate.Name = "rdoPriceUpdate"
        Me.rdoPriceUpdate.Size = New System.Drawing.Size(97, 17)
        Me.rdoPriceUpdate.TabIndex = 5
        Me.rdoPriceUpdate.TabStop = True
        Me.rdoPriceUpdate.Text = "Price update"
        Me.rdoPriceUpdate.UseVisualStyleBackColor = True
        '
        'rdoBuy1Take1
        '
        Me.rdoBuy1Take1.AutoSize = True
        Me.rdoBuy1Take1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBuy1Take1.Location = New System.Drawing.Point(11, 38)
        Me.rdoBuy1Take1.Name = "rdoBuy1Take1"
        Me.rdoBuy1Take1.Size = New System.Drawing.Size(101, 17)
        Me.rdoBuy1Take1.TabIndex = 1
        Me.rdoBuy1Take1.TabStop = True
        Me.rdoBuy1Take1.Text = "Buy 1 Take 1"
        Me.rdoBuy1Take1.UseVisualStyleBackColor = True
        '
        'rdoShelfTag
        '
        Me.rdoShelfTag.AutoSize = True
        Me.rdoShelfTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoShelfTag.Location = New System.Drawing.Point(10, 15)
        Me.rdoShelfTag.Name = "rdoShelfTag"
        Me.rdoShelfTag.Size = New System.Drawing.Size(102, 17)
        Me.rdoShelfTag.TabIndex = 0
        Me.rdoShelfTag.TabStop = True
        Me.rdoShelfTag.Text = "Shelftag Print"
        Me.rdoShelfTag.UseVisualStyleBackColor = True
        '
        'ShelfTag_Printer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 549)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShelfTag_Printer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdoBuy1Take1 As RadioButton
    Friend WithEvents rdoShelfTag As RadioButton
    Friend WithEvents rdoPriceUpdate As RadioButton
    Friend WithEvents rdo10 As RadioButton
    Friend WithEvents rdo20 As RadioButton
    Friend WithEvents rdo50 As RadioButton
End Class
