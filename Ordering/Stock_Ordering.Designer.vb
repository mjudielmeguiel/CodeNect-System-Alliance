<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Stock_Ordering
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock_Ordering))
        Me.cboBranchFrom = New System.Windows.Forms.ComboBox()
        Me.lblPOnumber = New System.Windows.Forms.Label()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.lblpreparedby = New System.Windows.Forms.Label()
        Me.lblbranch = New System.Windows.Forms.Label()
        Me.dgvOrderItems = New System.Windows.Forms.DataGridView()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbltransactiontype = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnremove = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboBranchFrom
        '
        Me.cboBranchFrom.BackColor = System.Drawing.SystemColors.Control
        Me.cboBranchFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranchFrom.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranchFrom.FormattingEnabled = True
        Me.cboBranchFrom.Location = New System.Drawing.Point(182, 145)
        Me.cboBranchFrom.Name = "cboBranchFrom"
        Me.cboBranchFrom.Size = New System.Drawing.Size(463, 33)
        Me.cboBranchFrom.TabIndex = 286
        '
        'lblPOnumber
        '
        Me.lblPOnumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPOnumber.AutoSize = True
        Me.lblPOnumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOnumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPOnumber.Location = New System.Drawing.Point(1328, 9)
        Me.lblPOnumber.Name = "lblPOnumber"
        Me.lblPOnumber.Size = New System.Drawing.Size(15, 19)
        Me.lblPOnumber.TabIndex = 292
        Me.lblPOnumber.Text = "-"
        Me.lblPOnumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblstatus
        '
        Me.lblstatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatus.Location = New System.Drawing.Point(899, 107)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(17, 22)
        Me.lblstatus.TabIndex = 293
        Me.lblstatus.Text = "-"
        Me.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblpreparedby
        '
        Me.lblpreparedby.AutoSize = True
        Me.lblpreparedby.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpreparedby.Location = New System.Drawing.Point(177, 102)
        Me.lblpreparedby.Name = "lblpreparedby"
        Me.lblpreparedby.Size = New System.Drawing.Size(21, 28)
        Me.lblpreparedby.TabIndex = 296
        Me.lblpreparedby.Text = "-"
        Me.lblpreparedby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblbranch
        '
        Me.lblbranch.AutoSize = True
        Me.lblbranch.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbranch.Location = New System.Drawing.Point(177, 185)
        Me.lblbranch.Name = "lblbranch"
        Me.lblbranch.Size = New System.Drawing.Size(21, 28)
        Me.lblbranch.TabIndex = 297
        Me.lblbranch.Text = "-"
        Me.lblbranch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvOrderItems
        '
        Me.dgvOrderItems.AllowUserToAddRows = False
        Me.dgvOrderItems.AllowUserToDeleteRows = False
        Me.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrderItems.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvOrderItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvOrderItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderItems.GridColor = System.Drawing.SystemColors.Control
        Me.dgvOrderItems.Location = New System.Drawing.Point(24, 301)
        Me.dgvOrderItems.Name = "dgvOrderItems"
        Me.dgvOrderItems.ReadOnly = True
        Me.dgvOrderItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOrderItems.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrderItems.Size = New System.Drawing.Size(1328, 268)
        Me.dgvOrderItems.TabIndex = 299
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(15, 11)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(900, 32)
        Me.txtBarcode.TabIndex = 300
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.DarkRed
        Me.lbltotal.Location = New System.Drawing.Point(899, 146)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(17, 22)
        Me.lbltotal.TabIndex = 304
        Me.lbltotal.Text = "-"
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(822, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 22)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Total :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(822, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 22)
        Me.Label8.TabIndex = 309
        Me.Label8.Text = "Status :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(57, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 22)
        Me.Label5.TabIndex = 307
        Me.Label5.Text = "order by :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 22)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "To :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 22)
        Me.Label3.TabIndex = 305
        Me.Label3.Text = "From :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(1128, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 19)
        Me.Label7.TabIndex = 308
        Me.Label7.Text = "PO NUMBER :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltransactiontype
        '
        Me.lbltransactiontype.AutoSize = True
        Me.lbltransactiontype.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransactiontype.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbltransactiontype.Location = New System.Drawing.Point(676, 102)
        Me.lbltransactiontype.Name = "lbltransactiontype"
        Me.lbltransactiontype.Size = New System.Drawing.Size(27, 36)
        Me.lbltransactiontype.TabIndex = 0
        Me.lbltransactiontype.Text = "-"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.btnremove)
        Me.Panel1.Controls.Add(Me.btnSubmit)
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Location = New System.Drawing.Point(12, 701)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 55)
        Me.Panel1.TabIndex = 307
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lblPOnumber)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 43)
        Me.Panel2.TabIndex = 311
        '
        'btnremove
        '
        Me.btnremove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnremove.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnremove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremove.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremove.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnremove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnremove.Location = New System.Drawing.Point(1055, 9)
        Me.btnremove.Name = "btnremove"
        Me.btnremove.Size = New System.Drawing.Size(134, 37)
        Me.btnremove.TabIndex = 313
        Me.btnremove.Text = "Remove"
        Me.btnremove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnremove.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.DarkBlue
        Me.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.Location = New System.Drawing.Point(1195, 9)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(134, 37)
        Me.btnSubmit.TabIndex = 312
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(921, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 32)
        Me.TextBox1.TabIndex = 314
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.DarkBlue
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(1220, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 37)
        Me.Button1.TabIndex = 315
        Me.Button1.Text = "Print"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Stock_Ordering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbltransactiontype)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboBranchFrom)
        Me.Controls.Add(Me.lblpreparedby)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblbranch)
        Me.Controls.Add(Me.dgvOrderItems)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblstatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Stock_Ordering"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock_Movements"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboBranchFrom As ComboBox
    Friend WithEvents lblPOnumber As Label
    Friend WithEvents lblstatus As Label
    Friend WithEvents lblpreparedby As Label
    Friend WithEvents lblbranch As Label
    Friend WithEvents dgvOrderItems As DataGridView
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbltransactiontype As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnremove As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
End Class
