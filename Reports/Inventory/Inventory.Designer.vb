<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventory))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnremove = New System.Windows.Forms.Button()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblBranchName = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 54)
        Me.Panel1.TabIndex = 326
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
        Me.lblMemo.Text = "INVENTORY"
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
        Me.btnremove.TabIndex = 329
        Me.btnremove.Text = "Remove"
        Me.btnremove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnremove.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnremove.UseVisualStyleBackColor = False
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(96, 5)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(299, 28)
        Me.txtBarcode.TabIndex = 321
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 19)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "BARCODE :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtBarcode)
        Me.Panel3.Controls.Add(Me.lblTotal)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(12, 662)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1342, 41)
        Me.Panel3.TabIndex = 335
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotal.Location = New System.Drawing.Point(877, 9)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(334, 23)
        Me.lblTotal.TabIndex = 339
        Me.lblTotal.Text = "-"
        '
        'dgvInventory
        '
        Me.dgvInventory.AllowUserToAddRows = False
        Me.dgvInventory.AllowUserToDeleteRows = False
        Me.dgvInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventory.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInventory.Location = New System.Drawing.Point(12, 193)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvInventory.Size = New System.Drawing.Size(1342, 463)
        Me.dgvInventory.TabIndex = 333
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
        Me.btnSubmit.Location = New System.Drawing.Point(819, 709)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(98, 47)
        Me.btnSubmit.TabIndex = 328
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(1038, 709)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(108, 47)
        Me.btnExcel.TabIndex = 336
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(923, 709)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 47)
        Me.Button2.TabIndex = 337
        Me.Button2.Text = "Gmail"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Button2.UseVisualStyleBackColor = False
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUserName.Location = New System.Drawing.Point(12, 74)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(535, 23)
        Me.lblUserName.TabIndex = 331
        Me.lblUserName.Text = "NAME OF USER"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(1260, 74)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(94, 23)
        Me.lblStatus.TabIndex = 332
        Me.lblStatus.Text = "PENDING"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBranchName
        '
        Me.lblBranchName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBranchName.Location = New System.Drawing.Point(12, 108)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(536, 23)
        Me.lblBranchName.TabIndex = 330
        Me.lblBranchName.Text = "BRANCH NAME"
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
        Me.btnClose.TabIndex = 339
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblBranchName)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.btnremove)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dgvInventory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents userPic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents lblMemo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnremove As Button
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblBranchName As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTotal As Label
End Class
