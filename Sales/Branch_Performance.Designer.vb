<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Branch_Performance
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
        Dim Label1 As System.Windows.Forms.Label
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Branch_Performance))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dgvBranchList = New System.Windows.Forms.DataGridView()
        Label1 = New System.Windows.Forms.Label()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvBranchList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(517, 18)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(32, 13)
        Label1.TabIndex = 272
        Label1.Text = "Start:"
        '
        'STOCK_AVAILABLELabel
        '
        STOCK_AVAILABLELabel.AutoSize = True
        STOCK_AVAILABLELabel.Location = New System.Drawing.Point(16, 17)
        STOCK_AVAILABLELabel.Name = "STOCK_AVAILABLELabel"
        STOCK_AVAILABLELabel.Size = New System.Drawing.Size(44, 13)
        STOCK_AVAILABLELabel.TabIndex = 271
        STOCK_AVAILABLELabel.Text = "Search:"
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(789, 17)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(29, 13)
        Label2.TabIndex = 275
        Label2.Text = "End:"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.Maroon
        Me.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Location = New System.Drawing.Point(1200, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(135, 37)
        Me.btnExport.TabIndex = 214
        Me.btnExport.Text = " Save to Excel"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(65, 10)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(447, 26)
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
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpEnd)
        Me.Panel1.Controls.Add(Label2)
        Me.Panel1.Controls.Add(Me.dtpStart)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(STOCK_AVAILABLELabel)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Location = New System.Drawing.Point(12, 708)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 48)
        Me.Panel1.TabIndex = 221
        '
        'dtpEnd
        '
        Me.dtpEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEnd.Location = New System.Drawing.Point(827, 11)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(226, 20)
        Me.dtpEnd.TabIndex = 276
        '
        'dtpStart
        '
        Me.dtpStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpStart.Location = New System.Drawing.Point(555, 12)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(226, 20)
        Me.dtpStart.TabIndex = 274
        '
        'dgvBranchList
        '
        Me.dgvBranchList.AllowUserToAddRows = False
        Me.dgvBranchList.AllowUserToDeleteRows = False
        Me.dgvBranchList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBranchList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBranchList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBranchList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBranchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBranchList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBranchList.Location = New System.Drawing.Point(12, 12)
        Me.dgvBranchList.Name = "dgvBranchList"
        Me.dgvBranchList.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBranchList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBranchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBranchList.Size = New System.Drawing.Size(1342, 690)
        Me.dgvBranchList.TabIndex = 222
        '
        'Branch_Performance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvBranchList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Branch_Performance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Branch_Performance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvBranchList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExport As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvBranchList As DataGridView
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents dtpEnd As DateTimePicker
End Class
