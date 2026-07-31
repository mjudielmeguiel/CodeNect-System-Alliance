<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblLockedUsers = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblActiveUsers = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalUsers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.lblbranchname = New System.Windows.Forms.Label()
        Me.lblrole = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblBranches = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblLockedUsers)
        Me.Panel3.Location = New System.Drawing.Point(600, 201)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(237, 113)
        Me.Panel3.TabIndex = 171
        '
        'lblLockedUsers
        '
        Me.lblLockedUsers.AutoSize = True
        Me.lblLockedUsers.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLockedUsers.ForeColor = System.Drawing.Color.DarkRed
        Me.lblLockedUsers.Location = New System.Drawing.Point(98, 15)
        Me.lblLockedUsers.Name = "lblLockedUsers"
        Me.lblLockedUsers.Size = New System.Drawing.Size(45, 50)
        Me.lblLockedUsers.TabIndex = 163
        Me.lblLockedUsers.Text = "0"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblActiveUsers)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(321, 201)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(237, 113)
        Me.Panel2.TabIndex = 170
        '
        'lblActiveUsers
        '
        Me.lblActiveUsers.AutoSize = True
        Me.lblActiveUsers.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveUsers.ForeColor = System.Drawing.Color.DarkRed
        Me.lblActiveUsers.Location = New System.Drawing.Point(97, 15)
        Me.lblActiveUsers.Name = "lblActiveUsers"
        Me.lblActiveUsers.Size = New System.Drawing.Size(45, 50)
        Me.lblActiveUsers.TabIndex = 163
        Me.lblActiveUsers.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(67, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 22)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Active Users"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblTotalUsers)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(42, 201)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 113)
        Me.Panel1.TabIndex = 169
        '
        'lblTotalUsers
        '
        Me.lblTotalUsers.AutoSize = True
        Me.lblTotalUsers.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalUsers.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalUsers.Location = New System.Drawing.Point(86, 15)
        Me.lblTotalUsers.Name = "lblTotalUsers"
        Me.lblTotalUsers.Size = New System.Drawing.Size(45, 50)
        Me.lblTotalUsers.TabIndex = 163
        Me.lblTotalUsers.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(51, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 22)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Total Users"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.DarkRed
        Me.lblname.Location = New System.Drawing.Point(38, 89)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(119, 22)
        Me.lblname.TabIndex = 165
        Me.lblname.Text = "Name of user"
        '
        'lblbranchname
        '
        Me.lblbranchname.AutoSize = True
        Me.lblbranchname.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbranchname.ForeColor = System.Drawing.Color.DarkRed
        Me.lblbranchname.Location = New System.Drawing.Point(33, 24)
        Me.lblbranchname.Name = "lblbranchname"
        Me.lblbranchname.Size = New System.Drawing.Size(272, 50)
        Me.lblbranchname.TabIndex = 165
        Me.lblbranchname.Text = "Branch Name"
        '
        'lblrole
        '
        Me.lblrole.AutoSize = True
        Me.lblrole.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrole.ForeColor = System.Drawing.Color.DarkRed
        Me.lblrole.Location = New System.Drawing.Point(38, 134)
        Me.lblrole.Name = "lblrole"
        Me.lblrole.Size = New System.Drawing.Size(46, 22)
        Me.lblrole.TabIndex = 172
        Me.lblrole.Text = "Role"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblBranches)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(887, 201)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(237, 113)
        Me.Panel4.TabIndex = 172
        '
        'lblBranches
        '
        Me.lblBranches.AutoSize = True
        Me.lblBranches.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranches.ForeColor = System.Drawing.Color.DarkRed
        Me.lblBranches.Location = New System.Drawing.Point(98, 15)
        Me.lblBranches.Name = "lblBranches"
        Me.lblBranches.Size = New System.Drawing.Size(45, 50)
        Me.lblBranches.TabIndex = 163
        Me.lblBranches.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(76, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 22)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Branches"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1255, 675)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 173
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(57, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 22)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Locked Users"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblrole)
        Me.Controls.Add(Me.lblbranchname)
        Me.Controls.Add(Me.lblname)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHome"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblLockedUsers As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblActiveUsers As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblname As Label
    Friend WithEvents lblbranchname As Label
    Friend WithEvents lblrole As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblBranches As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
End Class
