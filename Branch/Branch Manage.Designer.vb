<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Branch_Manage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Branch_Manage))
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUSINESS_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDRESS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSaveExcel = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.lblTotalAmount = New System.Windows.Forms.TextBox()
        Me.dgvBranches = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ACCOUNT ID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ACCOUNT ID"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Width = 118
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ACCOUNT"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ACCOUNT"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BRANCH ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "BRANCH ID"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 107
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BRANCH"
        Me.DataGridViewTextBoxColumn5.HeaderText = "BRANCH"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 89
        '
        'BUSINESS_TYPE
        '
        Me.BUSINESS_TYPE.DataPropertyName = "BUSINESS_TYPE"
        Me.BUSINESS_TYPE.HeaderText = "BUSINESS_TYPE"
        Me.BUSINESS_TYPE.Name = "BUSINESS_TYPE"
        '
        'TIN
        '
        Me.TIN.DataPropertyName = "TIN"
        Me.TIN.HeaderText = "TIN"
        Me.TIN.Name = "TIN"
        '
        'ADDRESS
        '
        Me.ADDRESS.DataPropertyName = "ADDRESS"
        Me.ADDRESS.HeaderText = "ADDRESS"
        Me.ADDRESS.Name = "ADDRESS"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EMAIL"
        Me.DataGridViewTextBoxColumn6.HeaderText = "EMAIL"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 74
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CONTACT"
        Me.DataGridViewTextBoxColumn7.HeaderText = "CONTACT"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 97
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSaveExcel)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.ButtonAdd)
        Me.Panel1.Controls.Add(Me.lblTotalAmount)
        Me.Panel1.Location = New System.Drawing.Point(13, 708)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 48)
        Me.Panel1.TabIndex = 221
        '
        'btnSaveExcel
        '
        Me.btnSaveExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveExcel.BackColor = System.Drawing.Color.Maroon
        Me.btnSaveExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveExcel.Image = CType(resources.GetObject("btnSaveExcel.Image"), System.Drawing.Image)
        Me.btnSaveExcel.Location = New System.Drawing.Point(1200, 5)
        Me.btnSaveExcel.Name = "btnSaveExcel"
        Me.btnSaveExcel.Size = New System.Drawing.Size(135, 37)
        Me.btnSaveExcel.TabIndex = 214
        Me.btnSaveExcel.Text = " Save to Excel"
        Me.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveExcel.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(10, 10)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(789, 26)
        Me.txtSearch.TabIndex = 212
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
        Me.btnRefresh.Location = New System.Drawing.Point(1059, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 37)
        Me.btnRefresh.TabIndex = 211
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdd.BackColor = System.Drawing.Color.Maroon
        Me.ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonAdd.Image = CType(resources.GetObject("ButtonAdd.Image"), System.Drawing.Image)
        Me.ButtonAdd.Location = New System.Drawing.Point(918, 5)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(135, 37)
        Me.ButtonAdd.TabIndex = 210
        Me.ButtonAdd.Text = " ADD"
        Me.ButtonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonAdd.UseVisualStyleBackColor = False
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.Location = New System.Drawing.Point(803, 10)
        Me.lblTotalAmount.Margin = New System.Windows.Forms.Padding(2)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(110, 26)
        Me.lblTotalAmount.TabIndex = 218
        '
        'dgvBranches
        '
        Me.dgvBranches.AllowUserToDeleteRows = False
        Me.dgvBranches.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranches.Location = New System.Drawing.Point(13, 12)
        Me.dgvBranches.Name = "dgvBranches"
        Me.dgvBranches.ReadOnly = True
        Me.dgvBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBranches.Size = New System.Drawing.Size(1341, 690)
        Me.dgvBranches.TabIndex = 222
        '
        'Branch_Manage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvBranches)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Branch_Manage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Branch Manage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents BUSINESS_TYPE As DataGridViewTextBoxColumn
    Friend WithEvents TIN As DataGridViewTextBoxColumn
    Friend WithEvents ADDRESS As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSaveExcel As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents ButtonAdd As Button
    Friend WithEvents lblTotalAmount As TextBox
    Friend WithEvents dgvBranches As DataGridView
End Class
