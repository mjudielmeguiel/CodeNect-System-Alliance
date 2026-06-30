<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Movements
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
        Dim lblFromTo As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock_Movements))
        Me.cboParty = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        lblFromTo = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFromTo
        '
        lblFromTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblFromTo.AutoSize = True
        lblFromTo.Location = New System.Drawing.Point(43, 109)
        lblFromTo.Name = "lblFromTo"
        lblFromTo.Size = New System.Drawing.Size(36, 13)
        lblFromTo.TabIndex = 287
        lblFromTo.Text = "From :"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(43, 159)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(26, 13)
        Label1.TabIndex = 289
        Label1.Text = "To :"
        '
        'cboParty
        '
        Me.cboParty.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParty.FormattingEnabled = True
        Me.cboParty.Location = New System.Drawing.Point(85, 101)
        Me.cboParty.Name = "cboParty"
        Me.cboParty.Size = New System.Drawing.Size(280, 28)
        Me.cboParty.TabIndex = 286
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(85, 151)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(280, 28)
        Me.ComboBox1.TabIndex = 288
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 54)
        Me.Panel1.TabIndex = 290
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(79, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(298, 36)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "STOCK MOVEMENTS"
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
        'Stock_Movements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.cboParty)
        Me.Controls.Add(lblFromTo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Stock_Movements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock_Movements"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboParty As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents adminpic As PictureBox
End Class
