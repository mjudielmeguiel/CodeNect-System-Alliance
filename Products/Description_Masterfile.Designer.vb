<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Description_Masterfile
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Description_Masterfile))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.DescriptionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DescriptionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(12, 683)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(1044, 32)
        Me.txtSearch.TabIndex = 2
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.BackColor = System.Drawing.Color.Maroon
        Me.ButtonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonRefresh.Image = CType(resources.GetObject("ButtonRefresh.Image"), System.Drawing.Image)
        Me.ButtonRefresh.Location = New System.Drawing.Point(1062, 680)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(135, 37)
        Me.ButtonRefresh.TabIndex = 212
        Me.ButtonRefresh.Text = " Refresh"
        Me.ButtonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonRefresh.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(1203, 680)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(135, 37)
        Me.Button5.TabIndex = 218
        Me.Button5.Text = "Cancel"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1350, 54)
        Me.Panel1.TabIndex = 219
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
        Me.Label1.Size = New System.Drawing.Size(379, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DESCRIPTION MASTERFILE"
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
        'DescriptionsDataGridView
        '
        Me.DescriptionsDataGridView.AllowUserToAddRows = False
        Me.DescriptionsDataGridView.AllowUserToDeleteRows = False
        Me.DescriptionsDataGridView.AutoGenerateColumns = False
        Me.DescriptionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DescriptionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DescriptionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DescriptionsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.DescriptionsDataGridView.DataSource = Me.DescriptionsBindingSource
        Me.DescriptionsDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.DescriptionsDataGridView.Location = New System.Drawing.Point(0, 54)
        Me.DescriptionsDataGridView.Name = "DescriptionsDataGridView"
        Me.DescriptionsDataGridView.ReadOnly = True
        Me.DescriptionsDataGridView.Size = New System.Drawing.Size(1350, 620)
        Me.DescriptionsDataGridView.TabIndex = 219
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "BARCODE(EAN/UPC)"
        Me.DataGridViewTextBoxColumn2.HeaderText = "BARCODE(EAN/UPC)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 139
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "SKU"
        Me.DataGridViewTextBoxColumn3.HeaderText = "SKU"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 54
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPTIONS"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESCRIPTIONS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 112
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BRAND"
        Me.DataGridViewTextBoxColumn5.HeaderText = "BRAND"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CATEGORY"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CATEGORY"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 91
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SIZE"
        Me.DataGridViewTextBoxColumn7.HeaderText = "SIZE"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 56
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PRICE"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PRICE"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 64
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "UNIT"
        Me.DataGridViewTextBoxColumn9.HeaderText = "UNIT"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 58
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "STOCK_AVAILABLE"
        Me.DataGridViewTextBoxColumn10.HeaderText = "STOCK_AVAILABLE"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 131
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "AVAILABILITY"
        Me.DataGridViewTextBoxColumn11.HeaderText = "AVAILABILITY"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 102
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "VENDOR_CODE"
        Me.DataGridViewTextBoxColumn12.HeaderText = "VENDOR_CODE"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 114
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "VENDOR"
        Me.DataGridViewTextBoxColumn13.HeaderText = "VENDOR"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 78
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "TOTAL"
        Me.DataGridViewTextBoxColumn14.HeaderText = "TOTAL"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 67
        '
        'Description_Masterfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.DescriptionsDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.txtSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Description_Masterfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Description_Masterfile"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DescriptionsBindingSource As BindingSource
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents DescriptionsDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
End Class
