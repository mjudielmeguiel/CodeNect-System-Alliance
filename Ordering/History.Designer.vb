<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class History
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(History))
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.btnSaveExcel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Label2 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(790, 17)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(55, 13)
        Label2.TabIndex = 284
        Label2.Text = "REPORT:"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(529, 17)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(59, 13)
        Label1.TabIndex = 290
        Label1.Text = "Branch list:"
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        Me.dgvHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistory.Location = New System.Drawing.Point(12, 12)
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistory.Size = New System.Drawing.Size(1342, 690)
        Me.dgvHistory.TabIndex = 222
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
        Me.btnSaveExcel.Location = New System.Drawing.Point(1051, 5)
        Me.btnSaveExcel.Name = "btnSaveExcel"
        Me.btnSaveExcel.Size = New System.Drawing.Size(135, 37)
        Me.btnSaveExcel.TabIndex = 214
        Me.btnSaveExcel.Text = " Save to Excel"
        Me.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveExcel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1192, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(135, 37)
        Me.btnClose.TabIndex = 282
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cboType
        '
        Me.cboType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(851, 10)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(194, 26)
        Me.cboType.TabIndex = 222
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Label1)
        Me.Panel2.Controls.Add(Me.cboBranch)
        Me.Panel2.Controls.Add(Label2)
        Me.Panel2.Controls.Add(Me.cboType)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnSaveExcel)
        Me.Panel2.Location = New System.Drawing.Point(12, 708)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 48)
        Me.Panel2.TabIndex = 221
        '
        'cboBranch
        '
        Me.cboBranch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Location = New System.Drawing.Point(590, 10)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(194, 26)
        Me.cboBranch.TabIndex = 289
        '
        'History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvHistory)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents btnSaveExcel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents cboType As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboBranch As ComboBox
End Class
