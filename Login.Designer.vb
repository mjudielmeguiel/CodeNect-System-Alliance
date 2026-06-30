<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DarkRed
        Me.LinkLabel1.Location = New System.Drawing.Point(124, 374)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(97, 13)
        Me.LinkLabel1.TabIndex = 33
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Recover Account?"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(25, 115)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtUsername.Size = New System.Drawing.Size(310, 30)
        Me.txtUsername.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(25, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(312, 37)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = " Login"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(25, 172)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(310, 30)
        Me.txtPassword.TabIndex = 29
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(364, 80)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DarkRed
        Me.LinkLabel2.Location = New System.Drawing.Point(111, 348)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(126, 13)
        Me.LinkLabel2.TabIndex = 37
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Create Business Account"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 419)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(364, 22)
        Me.StatusStrip1.TabIndex = 128
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkRed
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(349, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Copyright © 2024"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(25, 270)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(310, 37)
        Me.btnClose.TabIndex = 127
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 441)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
End Class
