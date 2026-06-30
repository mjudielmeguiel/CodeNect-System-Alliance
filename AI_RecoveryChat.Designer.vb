<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AI_RecoveryChat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AI_RecoveryChat))
        Me.AITimer = New System.Windows.Forms.Timer(Me.components)
        Me.TxtMessage = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtMessage
        '
        Me.TxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessage.Location = New System.Drawing.Point(12, 639)
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(666, 30)
        Me.TxtMessage.TabIndex = 32
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(690, 66)
        Me.Panel1.TabIndex = 34
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(0, 0)
        Me.adminpic.Margin = New System.Windows.Forms.Padding(4)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(97, 66)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'userPic
        '
        Me.userPic.Image = CType(resources.GetObject("userPic.Image"), System.Drawing.Image)
        Me.userPic.Location = New System.Drawing.Point(0, 0)
        Me.userPic.Margin = New System.Windows.Forms.Padding(4)
        Me.userPic.Name = "userPic"
        Me.userPic.Size = New System.Drawing.Size(97, 66)
        Me.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.userPic.TabIndex = 7
        Me.userPic.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(105, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(253, 45)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "MESSAGE US!"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 73)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(666, 544)
        Me.FlowLayoutPanel1.TabIndex = 36
        '
        'AI_RecoveryChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 721)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AI_RecoveryChat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AI_RecoveryChat"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AITimer As Timer
    Friend WithEvents TxtMessage As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
