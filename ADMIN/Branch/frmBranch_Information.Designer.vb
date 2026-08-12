<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranch_Information
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBranch_Information))
        Me.dgvProductList = New System.Windows.Forms.DataGridView()
        Me.txtSearchProduct = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblBusinessTypeValue = New System.Windows.Forms.Label()
        Me.lblContactValue = New System.Windows.Forms.Label()
        Me.lblEmailValue = New System.Windows.Forms.Label()
        Me.lblManagerValue = New System.Windows.Forms.Label()
        Me.lblBranchIDValue = New System.Windows.Forms.Label()
        Me.lblBranchName = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblAddressValue = New System.Windows.Forms.Label()
        Me.picBranchPhoto = New System.Windows.Forms.PictureBox()
        CType(Me.dgvProductList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBranchPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProductList
        '
        Me.dgvProductList.AllowUserToAddRows = False
        Me.dgvProductList.AllowUserToDeleteRows = False
        Me.dgvProductList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProductList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvProductList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductList.Location = New System.Drawing.Point(12, 291)
        Me.dgvProductList.Name = "dgvProductList"
        Me.dgvProductList.ReadOnly = True
        Me.dgvProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductList.Size = New System.Drawing.Size(1240, 335)
        Me.dgvProductList.TabIndex = 337
        '
        'txtSearchProduct
        '
        Me.txtSearchProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearchProduct.BackColor = System.Drawing.SystemColors.Control
        Me.txtSearchProduct.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchProduct.Location = New System.Drawing.Point(621, 200)
        Me.txtSearchProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchProduct.Name = "txtSearchProduct"
        Me.txtSearchProduct.Size = New System.Drawing.Size(441, 28)
        Me.txtSearchProduct.TabIndex = 332
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Location = New System.Drawing.Point(12, 239)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1240, 46)
        Me.Panel3.TabIndex = 336
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1264, 48)
        Me.Panel2.TabIndex = 333
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(79, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 28)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Branch Information"
        '
        'adminpic
        '
        Me.adminpic.Dock = System.Windows.Forms.DockStyle.Left
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(0, 0)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 48)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 8
        Me.adminpic.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Location = New System.Drawing.Point(1100, 632)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(152, 37)
        Me.btnClose.TabIndex = 357
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblBusinessTypeValue
        '
        Me.lblBusinessTypeValue.AutoSize = True
        Me.lblBusinessTypeValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusinessTypeValue.Location = New System.Drawing.Point(12, 119)
        Me.lblBusinessTypeValue.Name = "lblBusinessTypeValue"
        Me.lblBusinessTypeValue.Size = New System.Drawing.Size(97, 19)
        Me.lblBusinessTypeValue.TabIndex = 361
        Me.lblBusinessTypeValue.Text = "Business Type:"
        Me.lblBusinessTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContactValue
        '
        Me.lblContactValue.AutoSize = True
        Me.lblContactValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactValue.Location = New System.Drawing.Point(617, 119)
        Me.lblContactValue.Name = "lblContactValue"
        Me.lblContactValue.Size = New System.Drawing.Size(61, 19)
        Me.lblContactValue.TabIndex = 362
        Me.lblContactValue.Text = "Contact:"
        Me.lblContactValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEmailValue
        '
        Me.lblEmailValue.AutoSize = True
        Me.lblEmailValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailValue.Location = New System.Drawing.Point(617, 162)
        Me.lblEmailValue.Name = "lblEmailValue"
        Me.lblEmailValue.Size = New System.Drawing.Size(41, 19)
        Me.lblEmailValue.TabIndex = 363
        Me.lblEmailValue.Text = "Email"
        Me.lblEmailValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblManagerValue
        '
        Me.lblManagerValue.AutoSize = True
        Me.lblManagerValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManagerValue.Location = New System.Drawing.Point(12, 162)
        Me.lblManagerValue.Name = "lblManagerValue"
        Me.lblManagerValue.Size = New System.Drawing.Size(64, 19)
        Me.lblManagerValue.TabIndex = 365
        Me.lblManagerValue.Text = "Manager"
        Me.lblManagerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBranchIDValue
        '
        Me.lblBranchIDValue.AutoSize = True
        Me.lblBranchIDValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchIDValue.Location = New System.Drawing.Point(617, 69)
        Me.lblBranchIDValue.Name = "lblBranchIDValue"
        Me.lblBranchIDValue.Size = New System.Drawing.Size(70, 19)
        Me.lblBranchIDValue.TabIndex = 366
        Me.lblBranchIDValue.Text = "Branch ID"
        Me.lblBranchIDValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBranchName
        '
        Me.lblBranchName.AutoSize = True
        Me.lblBranchName.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.Location = New System.Drawing.Point(7, 62)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(155, 28)
        Me.lblBranchName.TabIndex = 338
        Me.lblBranchName.Text = "Branch Name"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.DarkRed
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.Location = New System.Drawing.Point(1100, 196)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(152, 37)
        Me.btnPrint.TabIndex = 368
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'lblAddressValue
        '
        Me.lblAddressValue.AutoSize = True
        Me.lblAddressValue.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddressValue.Location = New System.Drawing.Point(9, 205)
        Me.lblAddressValue.Name = "lblAddressValue"
        Me.lblAddressValue.Size = New System.Drawing.Size(58, 19)
        Me.lblAddressValue.TabIndex = 369
        Me.lblAddressValue.Text = "Address"
        Me.lblAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picBranchPhoto
        '
        Me.picBranchPhoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picBranchPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBranchPhoto.Location = New System.Drawing.Point(1100, 54)
        Me.picBranchPhoto.Name = "picBranchPhoto"
        Me.picBranchPhoto.Size = New System.Drawing.Size(152, 136)
        Me.picBranchPhoto.TabIndex = 339
        Me.picBranchPhoto.TabStop = False
        '
        'frmBranch_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.lblAddressValue)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblBranchIDValue)
        Me.Controls.Add(Me.lblManagerValue)
        Me.Controls.Add(Me.lblEmailValue)
        Me.Controls.Add(Me.lblContactValue)
        Me.Controls.Add(Me.lblBusinessTypeValue)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picBranchPhoto)
        Me.Controls.Add(Me.lblBranchName)
        Me.Controls.Add(Me.dgvProductList)
        Me.Controls.Add(Me.txtSearchProduct)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBranch_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBranch_Information"
        CType(Me.dgvProductList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBranchPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProductList As DataGridView
    Friend WithEvents txtSearchProduct As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents lblBusinessTypeValue As Label
    Friend WithEvents lblContactValue As Label
    Friend WithEvents lblEmailValue As Label
    Friend WithEvents lblManagerValue As Label
    Friend WithEvents lblBranchIDValue As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents lblBranchName As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblAddressValue As Label
    Friend WithEvents picBranchPhoto As PictureBox
End Class
