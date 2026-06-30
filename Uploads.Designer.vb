<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Uploads
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Uploads))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.CODENECTDataSet = New CodeNect_System_Alliance.CODENECTDataSet()
        Me.InventoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager()
        Me.PcountTableAdapter = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.PcountTableAdapter()
        Me.PcountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PcountDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PcountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PcountDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1355, 73)
        Me.Panel1.TabIndex = 144
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.DarkRed
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Info
        Me.TextBox1.Location = New System.Drawing.Point(311, 11)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(323, 43)
        Me.TextBox1.TabIndex = 154
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(105, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 45)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "UPLOADS"
        '
        'adminpic
        '
        Me.adminpic.Dock = System.Windows.Forms.DockStyle.Left
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(0, 0)
        Me.adminpic.Margin = New System.Windows.Forms.Padding(4)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(97, 73)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'userPic
        '
        Me.userPic.Image = CType(resources.GetObject("userPic.Image"), System.Drawing.Image)
        Me.userPic.Location = New System.Drawing.Point(0, 0)
        Me.userPic.Margin = New System.Windows.Forms.Padding(4)
        Me.userPic.Name = "userPic"
        Me.userPic.Size = New System.Drawing.Size(97, 66)
        Me.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.userPic.TabIndex = 7
        Me.userPic.TabStop = False
        '
        'CODENECTDataSet
        '
        Me.CODENECTDataSet.DataSetName = "CODENECTDataSet"
        Me.CODENECTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InventoryBindingSource
        '
        Me.InventoryBindingSource.DataMember = "Inventory"
        Me.InventoryBindingSource.DataSource = Me.CODENECTDataSet
        '
        'InventoryTableAdapter
        '
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.Account_RecoverTableAdapter = Nothing
        Me.TableAdapterManager.AccountTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BranchesTableAdapter = Nothing
        Me.TableAdapterManager.DescriptionsTableAdapter = Nothing
        Me.TableAdapterManager.PcountTableAdapter = Me.PcountTableAdapter
        Me.TableAdapterManager.Stock_OrderingTableAdapter = Nothing
        Me.TableAdapterManager.StoTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableAdapter = Nothing
        Me.TableAdapterManager.VendorTableAdapter = Nothing
        '
        'PcountTableAdapter
        '
        Me.PcountTableAdapter.ClearBeforeFill = True
        '
        'PcountBindingSource
        '
        Me.PcountBindingSource.DataMember = "Pcount"
        Me.PcountBindingSource.DataSource = Me.CODENECTDataSet
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(1170, 662)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(165, 46)
        Me.Button5.TabIndex = 153
        Me.Button5.Text = "Cancel"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Maroon
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(794, 662)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(180, 46)
        Me.Button7.TabIndex = 168
        Me.Button7.Text = "Print"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Maroon
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(982, 662)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(180, 46)
        Me.Button6.TabIndex = 167
        Me.Button6.Text = " Save to Excel"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "UNIT"
        Me.DataGridViewTextBoxColumn20.HeaderText = "UNIT"
        Me.DataGridViewTextBoxColumn20.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 125
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "CATEGORY"
        Me.DataGridViewTextBoxColumn19.HeaderText = "CATEGORY"
        Me.DataGridViewTextBoxColumn19.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 125
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "PRICE"
        Me.DataGridViewTextBoxColumn18.HeaderText = "PRICE"
        Me.DataGridViewTextBoxColumn18.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 125
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "SIZE"
        Me.DataGridViewTextBoxColumn17.HeaderText = "SIZE"
        Me.DataGridViewTextBoxColumn17.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 125
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "BRAND"
        Me.DataGridViewTextBoxColumn16.HeaderText = "BRAND"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 125
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "DESCRIPTIONS"
        Me.DataGridViewTextBoxColumn15.HeaderText = "DESCRIPTIONS"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 125
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "BARCODE(EAN/UPC)"
        Me.DataGridViewTextBoxColumn14.HeaderText = "BARCODE(EAN/UPC)"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 125
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "VENDOR"
        Me.DataGridViewTextBoxColumn12.HeaderText = "VENDOR"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 125
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "VENDOR ID"
        Me.DataGridViewTextBoxColumn11.HeaderText = "VENDOR ID"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "AVAILABILITY"
        Me.DataGridViewTextBoxColumn8.HeaderText = "AVAILABILITY"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "QTY"
        Me.DataGridViewTextBoxColumn7.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SKU"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SKU"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TRANSACTION ID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TRANSACTION ID"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'PcountDataGridView
        '
        Me.PcountDataGridView.AutoGenerateColumns = False
        Me.PcountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PcountDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.PcountDataGridView.DataSource = Me.PcountBindingSource
        Me.PcountDataGridView.Location = New System.Drawing.Point(12, 80)
        Me.PcountDataGridView.Name = "PcountDataGridView"
        Me.PcountDataGridView.RowHeadersWidth = 51
        Me.PcountDataGridView.RowTemplate.Height = 24
        Me.PcountDataGridView.Size = New System.Drawing.Size(1331, 575)
        Me.PcountDataGridView.TabIndex = 168
        '
        'Uploads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 728)
        Me.Controls.Add(Me.PcountDataGridView)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Uploads"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uploads"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PcountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PcountDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CODENECTDataSet As CODENECTDataSet
    Friend WithEvents InventoryBindingSource As BindingSource
    Friend WithEvents TableAdapterManager As CODENECTDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PcountTableAdapter As CODENECTDataSetTableAdapters.PcountTableAdapter
    Friend WithEvents PcountBindingSource As BindingSource
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents PcountDataGridView As DataGridView
End Class
