<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Description_Manager
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
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Description_Manager))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblTotalAmount = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(707, 17)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(34, 13)
        Label1.TabIndex = 272
        Label1.Text = "Total:"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.Color.Maroon
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(1200, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 37)
        Me.Button6.TabIndex = 214
        Me.Button6.Text = " Save to Excel"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(65, 10)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(637, 26)
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
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.Location = New System.Drawing.Point(756, 10)
        Me.lblTotalAmount.Margin = New System.Windows.Forms.Padding(2)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(157, 26)
        Me.lblTotalAmount.TabIndex = 218
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(STOCK_AVAILABLELabel)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.lblTotalAmount)
        Me.Panel1.Location = New System.Drawing.Point(12, 708)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 48)
        Me.Panel1.TabIndex = 219
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Maroon
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(918, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 37)
        Me.btnAdd.TabIndex = 273
        Me.btnAdd.Text = " Import"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgvProducts
        '
        Me.dgvProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProducts.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProducts.Location = New System.Drawing.Point(12, 12)
        Me.dgvProducts.Name = "dgvProducts"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(1342, 690)
        Me.dgvProducts.TabIndex = 220
        '
        'Description_Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Description_Manager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Description_Manager"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents Button6 As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblTotalAmount As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents btnAdd As Button
End Class
