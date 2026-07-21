<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory_DATA
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory_DATA))
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Label2 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(289, 23)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(29, 13)
        Label2.TabIndex = 275
        Label2.Text = "End:"
        AddHandler Label2.Click, AddressOf Me.Label2_Click
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(289, 6)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(32, 13)
        Label1.TabIndex = 272
        Label1.Text = "Start:"
        AddHandler Label1.Click, AddressOf Me.Label1_Click
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(16, 17)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(44, 13)
        Label3.TabIndex = 271
        Label3.Text = "Search:"
        AddHandler Label3.Click, AddressOf Me.Label3_Click
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReport.Location = New System.Drawing.Point(12, 12)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(1342, 690)
        Me.dgvReport.TabIndex = 224
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.dtpEnd)
        Me.Panel2.Controls.Add(Label2)
        Me.Panel2.Controls.Add(Me.dtpStart)
        Me.Panel2.Controls.Add(Label1)
        Me.Panel2.Controls.Add(Label3)
        Me.Panel2.Controls.Add(Me.btnExportExcel)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.btnLoad)
        Me.Panel2.Location = New System.Drawing.Point(12, 708)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 48)
        Me.Panel2.TabIndex = 225
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.BackColor = System.Drawing.Color.Maroon
        Me.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(918, 6)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(135, 37)
        Me.btnReset.TabIndex = 277
        Me.btnReset.Text = " Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'dtpEnd
        '
        Me.dtpEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEnd.Location = New System.Drawing.Point(327, 23)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(197, 20)
        Me.dtpEnd.TabIndex = 276
        '
        'dtpStart
        '
        Me.dtpStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpStart.Location = New System.Drawing.Point(327, 3)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(196, 20)
        Me.dtpStart.TabIndex = 274
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportExcel.BackColor = System.Drawing.Color.Maroon
        Me.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.Location = New System.Drawing.Point(1200, 5)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(135, 37)
        Me.btnExportExcel.TabIndex = 214
        Me.btnExportExcel.Text = " Save to Excel"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(65, 10)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(146, 26)
        Me.txtSearch.TabIndex = 212
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackColor = System.Drawing.Color.Maroon
        Me.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(1059, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(135, 37)
        Me.btnLoad.TabIndex = 211
        Me.btnLoad.Text = " Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'frmInventory_DATA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInventory_DATA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInventory_DATA"
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnReset As Button
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnLoad As Button
End Class
