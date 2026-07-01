<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Account_Recovery
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
        Dim RECOVERY_IDLabel As System.Windows.Forms.Label
        Dim REASONLabel As System.Windows.Forms.Label
        Dim EMAILLabel As System.Windows.Forms.Label
        Dim NEW_PASSWORDLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Account_Recovery))
        Me.txtRecoveryID = New System.Windows.Forms.TextBox()
        Me.txtReason = New System.Windows.Forms.RichTextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblPasswordverification = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        RECOVERY_IDLabel = New System.Windows.Forms.Label()
        REASONLabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        NEW_PASSWORDLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RECOVERY_IDLabel
        '
        RECOVERY_IDLabel.AutoSize = True
        RECOVERY_IDLabel.Location = New System.Drawing.Point(12, 67)
        RECOVERY_IDLabel.Name = "RECOVERY_IDLabel"
        RECOVERY_IDLabel.Size = New System.Drawing.Size(83, 13)
        RECOVERY_IDLabel.TabIndex = 3
        RECOVERY_IDLabel.Text = "RECOVERY ID:"
        '
        'REASONLabel
        '
        REASONLabel.AutoSize = True
        REASONLabel.Location = New System.Drawing.Point(9, 212)
        REASONLabel.Name = "REASONLabel"
        REASONLabel.Size = New System.Drawing.Size(55, 13)
        REASONLabel.TabIndex = 7
        REASONLabel.Text = "REASON:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Location = New System.Drawing.Point(162, 67)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(42, 13)
        EMAILLabel.TabIndex = 9
        EMAILLabel.Text = "EMAIL:"
        '
        'NEW_PASSWORDLabel
        '
        NEW_PASSWORDLabel.AutoSize = True
        NEW_PASSWORDLabel.Location = New System.Drawing.Point(12, 157)
        NEW_PASSWORDLabel.Name = "NEW_PASSWORDLabel"
        NEW_PASSWORDLabel.Size = New System.Drawing.Size(102, 13)
        NEW_PASSWORDLabel.TabIndex = 11
        NEW_PASSWORDLabel.Text = "NEW PASSWORD:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(272, 157)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(125, 13)
        Label2.TabIndex = 14
        Label2.Text = "CONFIRM PASSWORD:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 112)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(71, 13)
        Label3.TabIndex = 17
        Label3.Text = "USERNAME:"
        '
        'txtRecoveryID
        '
        Me.txtRecoveryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecoveryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecoveryID.Location = New System.Drawing.Point(12, 83)
        Me.txtRecoveryID.Name = "txtRecoveryID"
        Me.txtRecoveryID.ReadOnly = True
        Me.txtRecoveryID.Size = New System.Drawing.Size(147, 26)
        Me.txtRecoveryID.TabIndex = 4
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(12, 228)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(507, 189)
        Me.txtReason.TabIndex = 8
        Me.txtReason.Text = ""
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(165, 83)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(354, 26)
        Me.txtEmail.TabIndex = 10
        '
        'txtNewPassword
        '
        Me.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPassword.Location = New System.Drawing.Point(12, 173)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(254, 26)
        Me.txtNewPassword.TabIndex = 12
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(531, 54)
        Me.Panel1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RECOVERY"
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
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(384, 423)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 220
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(243, 423)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 219
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblPasswordverification
        '
        Me.lblPasswordverification.AutoSize = True
        Me.lblPasswordverification.Location = New System.Drawing.Point(381, 202)
        Me.lblPasswordverification.Name = "lblPasswordverification"
        Me.lblPasswordverification.Size = New System.Drawing.Size(16, 13)
        Me.lblPasswordverification.TabIndex = 19
        Me.lblPasswordverification.Text = "---"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(12, 128)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(507, 26)
        Me.txtUsername.TabIndex = 18
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(272, 173)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(247, 26)
        Me.txtConfirmPassword.TabIndex = 15
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'Account_Recovery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 472)
        Me.Controls.Add(Me.lblPasswordverification)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(RECOVERY_IDLabel)
        Me.Controls.Add(NEW_PASSWORDLabel)
        Me.Controls.Add(Me.txtRecoveryID)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(REASONLabel)
        Me.Controls.Add(EMAILLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Account_Recovery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account_Recovery"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecoveryID As TextBox
    Friend WithEvents txtReason As RichTextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPasswordverification As Label
End Class
