<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBad_Order
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBad_Order))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnremove = New System.Windows.Forms.Button()
        Me.lblNameBranch = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblPreparedBy = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'userPic
        '
        Me.userPic.Dock = System.Windows.Forms.DockStyle.Left
        Me.userPic.Image = CType(resources.GetObject("userPic.Image"), System.Drawing.Image)
        Me.userPic.Location = New System.Drawing.Point(0, 0)
        Me.userPic.Name = "userPic"
        Me.userPic.Size = New System.Drawing.Size(73, 54)
        Me.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.userPic.TabIndex = 7
        Me.userPic.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.lblTransactionID)
        Me.Panel1.Controls.Add(Me.lblMemo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 54)
        Me.Panel1.TabIndex = 311
        '
        'lblTransactionID
        '
        Me.lblTransactionID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTransactionID.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionID.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTransactionID.Location = New System.Drawing.Point(1223, 29)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(131, 23)
        Me.lblTransactionID.TabIndex = 319
        Me.lblTransactionID.Text = "000000"
        Me.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMemo
        '
        Me.lblMemo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMemo.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMemo.Location = New System.Drawing.Point(73, 0)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(428, 54)
        Me.lblMemo.TabIndex = 12
        Me.lblMemo.Text = "BAD ORDER"
        Me.lblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(1223, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 23)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "TRANSACTION ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.SystemColors.Control
        Me.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmit.Location = New System.Drawing.Point(1048, 709)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(98, 47)
        Me.btnSubmit.TabIndex = 316
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(1256, 709)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 315
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnremove
        '
        Me.btnremove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnremove.BackColor = System.Drawing.SystemColors.Control
        Me.btnremove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnremove.FlatAppearance.BorderSize = 0
        Me.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremove.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnremove.Image = CType(resources.GetObject("btnremove.Image"), System.Drawing.Image)
        Me.btnremove.Location = New System.Drawing.Point(1152, 709)
        Me.btnremove.Name = "btnremove"
        Me.btnremove.Size = New System.Drawing.Size(98, 47)
        Me.btnremove.TabIndex = 317
        Me.btnremove.Text = "Remove"
        Me.btnremove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnremove.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnremove.UseVisualStyleBackColor = False
        '
        'lblNameBranch
        '
        Me.lblNameBranch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameBranch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNameBranch.Location = New System.Drawing.Point(11, 91)
        Me.lblNameBranch.Name = "lblNameBranch"
        Me.lblNameBranch.Size = New System.Drawing.Size(536, 23)
        Me.lblNameBranch.TabIndex = 318
        Me.lblNameBranch.Text = "BRANCH NAME"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(1260, 68)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(94, 23)
        Me.lblStatus.TabIndex = 320
        Me.lblStatus.Text = "PENDING"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPreparedBy
        '
        Me.lblPreparedBy.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreparedBy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPreparedBy.Location = New System.Drawing.Point(12, 68)
        Me.lblPreparedBy.Name = "lblPreparedBy"
        Me.lblPreparedBy.Size = New System.Drawing.Size(535, 23)
        Me.lblPreparedBy.TabIndex = 319
        Me.lblPreparedBy.Text = "NAME OF USER"
        Me.lblPreparedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 729)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 21)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "BARCODE :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(113, 724)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(460, 32)
        Me.txtBarcode.TabIndex = 321
        '
        'dgvInventory
        '
        Me.dgvInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventory.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInventory.Location = New System.Drawing.Point(12, 169)
        Me.dgvInventory.Name = "dgvInventory"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInventory.Size = New System.Drawing.Size(923, 538)
        Me.dgvInventory.TabIndex = 323
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(941, 169)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(413, 534)
        Me.Panel2.TabIndex = 324
        '
        'frmBad_Order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.lblNameBranch)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblPreparedBy)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnremove)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBad_Order"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBad_Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents userPic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblMemo As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnremove As Button
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNameBranch As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblPreparedBy As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents Panel2 As Panel
End Class
