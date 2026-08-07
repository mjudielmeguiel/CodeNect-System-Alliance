<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetun_To_Vendor
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVendorCode = New System.Windows.Forms.Label()
        Me.lblRTVNumber = New System.Windows.Forms.Label()
        Me.lblVendorName = New System.Windows.Forms.Label()
        Me.rdoManual = New System.Windows.Forms.RadioButton()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdoScan = New System.Windows.Forms.RadioButton()
        Me.txtScan = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvReturnList = New System.Windows.Forms.DataGridView()
        CType(Me.dgvReturnList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 28)
        Me.Label4.TabIndex = 349
        Me.Label4.Text = "Return To Vendor"
        '
        'lblVendorCode
        '
        Me.lblVendorCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVendorCode.AutoSize = True
        Me.lblVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorCode.Location = New System.Drawing.Point(931, 113)
        Me.lblVendorCode.Name = "lblVendorCode"
        Me.lblVendorCode.Size = New System.Drawing.Size(15, 19)
        Me.lblVendorCode.TabIndex = 355
        Me.lblVendorCode.Text = "-"
        '
        'lblRTVNumber
        '
        Me.lblRTVNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRTVNumber.AutoSize = True
        Me.lblRTVNumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTVNumber.Location = New System.Drawing.Point(931, 75)
        Me.lblRTVNumber.Name = "lblRTVNumber"
        Me.lblRTVNumber.Size = New System.Drawing.Size(15, 19)
        Me.lblRTVNumber.TabIndex = 352
        Me.lblRTVNumber.Text = "-"
        '
        'lblVendorName
        '
        Me.lblVendorName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVendorName.AutoSize = True
        Me.lblVendorName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(931, 132)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(15, 19)
        Me.lblVendorName.TabIndex = 354
        Me.lblVendorName.Text = "-"
        '
        'rdoManual
        '
        Me.rdoManual.AutoSize = True
        Me.rdoManual.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoManual.Location = New System.Drawing.Point(372, 158)
        Me.rdoManual.Name = "rdoManual"
        Me.rdoManual.Size = New System.Drawing.Size(73, 23)
        Me.rdoManual.TabIndex = 351
        Me.rdoManual.TabStop = True
        Me.rdoManual.Text = "Manual"
        Me.rdoManual.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.DarkRed
        Me.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.Location = New System.Drawing.Point(1220, 725)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(134, 37)
        Me.btnSubmit.TabIndex = 348
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 353
        Me.Label3.Text = "Barcode :"
        '
        'rdoScan
        '
        Me.rdoScan.AutoSize = True
        Me.rdoScan.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoScan.Location = New System.Drawing.Point(309, 158)
        Me.rdoScan.Name = "rdoScan"
        Me.rdoScan.Size = New System.Drawing.Size(57, 23)
        Me.rdoScan.TabIndex = 350
        Me.rdoScan.TabStop = True
        Me.rdoScan.Text = "Scan"
        Me.rdoScan.UseVisualStyleBackColor = True
        '
        'txtScan
        '
        Me.txtScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScan.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScan.Location = New System.Drawing.Point(12, 155)
        Me.txtScan.Name = "txtScan"
        Me.txtScan.Size = New System.Drawing.Size(291, 28)
        Me.txtScan.TabIndex = 346
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 48)
        Me.Panel2.TabIndex = 347
        '
        'dgvReturnList
        '
        Me.dgvReturnList.AllowUserToAddRows = False
        Me.dgvReturnList.AllowUserToDeleteRows = False
        Me.dgvReturnList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReturnList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvReturnList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReturnList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvReturnList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnList.GridColor = System.Drawing.SystemColors.Control
        Me.dgvReturnList.Location = New System.Drawing.Point(12, 190)
        Me.dgvReturnList.Name = "dgvReturnList"
        Me.dgvReturnList.ReadOnly = True
        Me.dgvReturnList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvReturnList.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReturnList.Size = New System.Drawing.Size(1342, 529)
        Me.dgvReturnList.TabIndex = 345
        '
        'frmRetun_To_Vendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblVendorCode)
        Me.Controls.Add(Me.lblRTVNumber)
        Me.Controls.Add(Me.lblVendorName)
        Me.Controls.Add(Me.rdoManual)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rdoScan)
        Me.Controls.Add(Me.txtScan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvReturnList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRetun_To_Vendor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRetun_To_Vendor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvReturnList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents lblVendorCode As Label
    Friend WithEvents lblRTVNumber As Label
    Friend WithEvents lblVendorName As Label
    Friend WithEvents rdoManual As RadioButton
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents rdoScan As RadioButton
    Friend WithEvents txtScan As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvReturnList As DataGridView
End Class
