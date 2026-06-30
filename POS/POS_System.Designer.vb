<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS_System
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS_System))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbldashboard = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsname = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbranch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(937, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 589)
        Me.Panel1.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 264)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(919, 385)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkRed
        Me.Panel3.Controls.Add(Me.lbldashboard)
        Me.Panel3.Controls.Add(Me.adminpic)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1366, 54)
        Me.Panel3.TabIndex = 4
        '
        'lbldashboard
        '
        Me.lbldashboard.AutoSize = True
        Me.lbldashboard.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldashboard.ForeColor = System.Drawing.SystemColors.Control
        Me.lbldashboard.Location = New System.Drawing.Point(79, 9)
        Me.lbldashboard.Name = "lbldashboard"
        Me.lbldashboard.Size = New System.Drawing.Size(341, 36)
        Me.lbldashboard.TabIndex = 0
        Me.lbldashboard.Text = "POINT OF SALE SYSTEM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnlogout)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Location = New System.Drawing.Point(12, 689)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 48)
        Me.Panel2.TabIndex = 220
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
        Me.btnAdd.Location = New System.Drawing.Point(769, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 37)
        Me.btnAdd.TabIndex = 273
        Me.btnAdd.Text = " Import"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
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
        Me.Button6.Location = New System.Drawing.Point(1051, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 37)
        Me.Button6.TabIndex = 214
        Me.Button6.Text = " Save to Excel"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
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
        Me.btnRefresh.Location = New System.Drawing.Point(910, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 37)
        Me.btnRefresh.TabIndex = 211
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnlogout
        '
        Me.btnlogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlogout.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnlogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogout.ForeColor = System.Drawing.Color.Maroon
        Me.btnlogout.Image = CType(resources.GetObject("btnlogout.Image"), System.Drawing.Image)
        Me.btnlogout.Location = New System.Drawing.Point(1192, 5)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(135, 37)
        Me.btnlogout.TabIndex = 221
        Me.btnlogout.Text = "Log out"
        Me.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlogout.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(12, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 22)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "BARCODE :"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(117, 228)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(223, 26)
        Me.TextBox1.TabIndex = 274
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 22)
        Me.Label1.TabIndex = 275
        Me.Label1.Text = "TOTAL:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsname, Me.tsbranch, Me.tsdate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 746)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1366, 22)
        Me.StatusStrip1.TabIndex = 275
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsname
        '
        Me.tsname.Name = "tsname"
        Me.tsname.Size = New System.Drawing.Size(450, 17)
        Me.tsname.Spring = True
        '
        'tsbranch
        '
        Me.tsbranch.Name = "tsbranch"
        Me.tsbranch.Size = New System.Drawing.Size(450, 17)
        Me.tsbranch.Spring = True
        '
        'tsdate
        '
        Me.tsdate.Name = "tsdate"
        Me.tsdate.Size = New System.Drawing.Size(450, 17)
        Me.tsdate.Spring = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'POS_System
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "POS_System"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS_System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbldashboard As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnlogout As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsname As ToolStripStatusLabel
    Friend WithEvents tsbranch As ToolStripStatusLabel
    Friend WithEvents tsdate As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
End Class
