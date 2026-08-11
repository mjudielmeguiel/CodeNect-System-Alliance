<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPcount_Report
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
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblItemCount = New System.Windows.Forms.Label()
        Me.lblInvNumber = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvReports = New System.Windows.Forms.DataGridView()
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(222, 75)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 19)
        Me.lblStatus.TabIndex = 359
        Me.lblStatus.Text = "Status"
        '
        'lblItemCount
        '
        Me.lblItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemCount.AutoSize = True
        Me.lblItemCount.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCount.Location = New System.Drawing.Point(931, 113)
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(92, 19)
        Me.lblItemCount.TabIndex = 358
        Me.lblItemCount.Text = "ITEM COUNT"
        '
        'lblInvNumber
        '
        Me.lblInvNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInvNumber.AutoSize = True
        Me.lblInvNumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvNumber.Location = New System.Drawing.Point(931, 75)
        Me.lblInvNumber.Name = "lblInvNumber"
        Me.lblInvNumber.Size = New System.Drawing.Size(88, 19)
        Me.lblInvNumber.TabIndex = 356
        Me.lblInvNumber.Text = "INV Number"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.Location = New System.Drawing.Point(931, 132)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(115, 19)
        Me.lblTotalAmount.TabIndex = 357
        Me.lblTotalAmount.Text = "TOTAL AMOUNT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(259, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 19)
        Me.Label2.TabIndex = 355
        Me.Label2.Text = "To ;"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 19)
        Me.Label3.TabIndex = 354
        Me.Label3.Text = "From :"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(12, 146)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(245, 24)
        Me.dtpFrom.TabIndex = 349
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(263, 146)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(245, 24)
        Me.dtpTo.TabIndex = 350
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 28)
        Me.Label1.TabIndex = 353
        Me.Label1.Text = "Inventory Reports"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 48)
        Me.Panel2.TabIndex = 352
        '
        'dgvReports
        '
        Me.dgvReports.AllowUserToAddRows = False
        Me.dgvReports.AllowUserToDeleteRows = False
        Me.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReports.Location = New System.Drawing.Point(17, 176)
        Me.dgvReports.Name = "dgvReports"
        Me.dgvReports.ReadOnly = True
        Me.dgvReports.Size = New System.Drawing.Size(1337, 580)
        Me.dgvReports.TabIndex = 360
        '
        'frmPcount_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvReports)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblItemCount)
        Me.Controls.Add(Me.lblInvNumber)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPcount_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPcount_Report"
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStatus As Label
    Friend WithEvents lblItemCount As Label
    Friend WithEvents lblInvNumber As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents dgvReports As DataGridView
End Class
