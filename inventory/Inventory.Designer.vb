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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtActualQty = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnSaveToExcel = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.lblHeaderInfo = New System.Windows.Forms.Label()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.lblNameBranch = New System.Windows.Forms.Label()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPreparedBy = New System.Windows.Forms.Label()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtActualQty)
        Me.Panel3.Controls.Add(Me.txtBarcode)
        Me.Panel3.Location = New System.Drawing.Point(12, 232)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1342, 49)
        Me.Panel3.TabIndex = 303
        '
        'txtActualQty
        '
        Me.txtActualQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActualQty.Location = New System.Drawing.Point(462, 12)
        Me.txtActualQty.Name = "txtActualQty"
        Me.txtActualQty.Size = New System.Drawing.Size(126, 26)
        Me.txtActualQty.TabIndex = 298
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(21, 12)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(435, 26)
        Me.txtBarcode.TabIndex = 297
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.btnSaveToExcel)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Location = New System.Drawing.Point(12, 707)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 49)
        Me.Panel2.TabIndex = 301
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1195, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 209
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Maroon
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(490, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 37)
        Me.btnAdd.TabIndex = 202
        Me.btnAdd.Text = " ADD"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Maroon
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(913, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 37)
        Me.btnRefresh.TabIndex = 203
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Maroon
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(490, 5)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(135, 37)
        Me.Button7.TabIndex = 235
        Me.Button7.Text = " ADD"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnSaveToExcel
        '
        Me.btnSaveToExcel.BackColor = System.Drawing.Color.Maroon
        Me.btnSaveToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveToExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveToExcel.Image = CType(resources.GetObject("btnSaveToExcel.Image"), System.Drawing.Image)
        Me.btnSaveToExcel.Location = New System.Drawing.Point(1054, 5)
        Me.btnSaveToExcel.Name = "btnSaveToExcel"
        Me.btnSaveToExcel.Size = New System.Drawing.Size(135, 37)
        Me.btnSaveToExcel.TabIndex = 206
        Me.btnSaveToExcel.Text = " Save to Excel"
        Me.btnSaveToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveToExcel.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Maroon
        Me.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(772, 5)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(135, 37)
        Me.btnRemove.TabIndex = 207
        Me.btnRemove.Text = " Remove"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(631, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 208
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.Location = New System.Drawing.Point(1244, 82)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(94, 23)
        Me.lblGrandTotal.TabIndex = 17
        Me.lblGrandTotal.Text = "9,999,999,99"
        Me.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeaderInfo
        '
        Me.lblHeaderInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderInfo.Location = New System.Drawing.Point(985, 29)
        Me.lblHeaderInfo.Name = "lblHeaderInfo"
        Me.lblHeaderInfo.Size = New System.Drawing.Size(94, 23)
        Me.lblHeaderInfo.TabIndex = 299
        Me.lblHeaderInfo.Text = "------"
        Me.lblHeaderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTransactionID
        '
        Me.lblTransactionID.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionID.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTransactionID.Location = New System.Drawing.Point(1210, 31)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(128, 23)
        Me.lblTransactionID.TabIndex = 16
        Me.lblTransactionID.Text = "000000"
        Me.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(1207, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "TRANSACTION ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.lblMemo.Text = "INVENTORY MANAGEMENT"
        Me.lblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNameBranch
        '
        Me.lblNameBranch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameBranch.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNameBranch.Location = New System.Drawing.Point(607, 31)
        Me.lblNameBranch.Name = "lblNameBranch"
        Me.lblNameBranch.Size = New System.Drawing.Size(536, 23)
        Me.lblNameBranch.TabIndex = 6
        Me.lblNameBranch.Text = "BRANCH NAME"
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
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(507, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(94, 23)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "PENDING"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.lblHeaderInfo)
        Me.Panel1.Controls.Add(Me.lblTransactionID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblMemo)
        Me.Panel1.Controls.Add(Me.lblNameBranch)
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.lblPreparedBy)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 54)
        Me.Panel1.TabIndex = 300
        '
        'lblPreparedBy
        '
        Me.lblPreparedBy.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreparedBy.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPreparedBy.Location = New System.Drawing.Point(608, 8)
        Me.lblPreparedBy.Name = "lblPreparedBy"
        Me.lblPreparedBy.Size = New System.Drawing.Size(535, 23)
        Me.lblPreparedBy.TabIndex = 8
        Me.lblPreparedBy.Text = "NAME OF USER"
        Me.lblPreparedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.dgvInventory.Location = New System.Drawing.Point(12, 287)
        Me.dgvInventory.Name = "dgvInventory"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInventory.Size = New System.Drawing.Size(1342, 414)
        Me.dgvInventory.TabIndex = 302
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Location = New System.Drawing.Point(12, 177)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(504, 49)
        Me.Panel4.TabIndex = 304
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(21, 18)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(435, 26)
        Me.TextBox2.TabIndex = 297
        '
        'Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvInventory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtActualQty As TextBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents btnSaveToExcel As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblHeaderInfo As Label
    Friend WithEvents lblTransactionID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMemo As Label
    Friend WithEvents lblNameBranch As Label
    Friend WithEvents userPic As PictureBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPreparedBy As Label
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TextBox2 As TextBox
End Class
