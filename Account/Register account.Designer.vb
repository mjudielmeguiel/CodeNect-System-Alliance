<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Register_account
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register_account))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.RichTextBox()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(185, 344)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 216
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(327, 344)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 217
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtAccountID
        '
        Me.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountID.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountID.Location = New System.Drawing.Point(12, 60)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(137, 28)
        Me.txtAccountID.TabIndex = 1
        Me.txtAccountID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAccount
        '
        Me.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccount.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.Location = New System.Drawing.Point(155, 60)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(307, 28)
        Me.txtAccount.TabIndex = 3
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(12, 94)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(174, 28)
        Me.txtContact.TabIndex = 5
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(192, 94)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(270, 28)
        Me.txtEmail.TabIndex = 7
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(12, 249)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(450, 28)
        Me.txtUsername.TabIndex = 11
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(12, 283)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(219, 28)
        Me.txtPassword.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(474, 54)
        Me.Panel2.TabIndex = 241
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(70, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Register Account"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(237, 283)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(225, 28)
        Me.txtConfirmPassword.TabIndex = 242
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(12, 128)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(450, 115)
        Me.txtAddress.TabIndex = 245
        Me.txtAddress.Text = ""
        '
        'Register_account
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 393)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtAccountID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Register_account"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register Account"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtAccountID As TextBox
    Friend WithEvents txtAccount As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAddress As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
