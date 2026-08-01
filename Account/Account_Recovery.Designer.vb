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
        Me.lblPasswordverification = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        RECOVERY_IDLabel = New System.Windows.Forms.Label()
        REASONLabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        NEW_PASSWORDLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RECOVERY_IDLabel
        '
        RECOVERY_IDLabel.AutoSize = True
        RECOVERY_IDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RECOVERY_IDLabel.Location = New System.Drawing.Point(337, 116)
        RECOVERY_IDLabel.Name = "RECOVERY_IDLabel"
        RECOVERY_IDLabel.Size = New System.Drawing.Size(97, 19)
        RECOVERY_IDLabel.TabIndex = 3
        RECOVERY_IDLabel.Text = "RECOVERY ID:"
        '
        'REASONLabel
        '
        REASONLabel.AutoSize = True
        REASONLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        REASONLabel.Location = New System.Drawing.Point(334, 335)
        REASONLabel.Name = "REASONLabel"
        REASONLabel.Size = New System.Drawing.Size(66, 19)
        REASONLabel.TabIndex = 7
        REASONLabel.Text = "REASON:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMAILLabel.Location = New System.Drawing.Point(487, 116)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(52, 19)
        EMAILLabel.TabIndex = 9
        EMAILLabel.Text = "EMAIL:"
        '
        'NEW_PASSWORDLabel
        '
        NEW_PASSWORDLabel.AutoSize = True
        NEW_PASSWORDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NEW_PASSWORDLabel.Location = New System.Drawing.Point(337, 260)
        NEW_PASSWORDLabel.Name = "NEW_PASSWORDLabel"
        NEW_PASSWORDLabel.Size = New System.Drawing.Size(122, 19)
        NEW_PASSWORDLabel.TabIndex = 11
        NEW_PASSWORDLabel.Text = "NEW PASSWORD:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(597, 260)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(154, 19)
        Label2.TabIndex = 14
        Label2.Text = "CONFIRM PASSWORD:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(334, 185)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(85, 19)
        Label3.TabIndex = 17
        Label3.Text = "USERNAME:"
        '
        'txtRecoveryID
        '
        Me.txtRecoveryID.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecoveryID.Location = New System.Drawing.Point(341, 138)
        Me.txtRecoveryID.Name = "txtRecoveryID"
        Me.txtRecoveryID.ReadOnly = True
        Me.txtRecoveryID.Size = New System.Drawing.Size(147, 28)
        Me.txtRecoveryID.TabIndex = 4
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.SystemColors.Control
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(341, 357)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(507, 129)
        Me.txtReason.TabIndex = 8
        Me.txtReason.Text = ""
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(491, 138)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(354, 28)
        Me.txtEmail.TabIndex = 10
        '
        'txtNewPassword
        '
        Me.txtNewPassword.BackColor = System.Drawing.SystemColors.Control
        Me.txtNewPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPassword.Location = New System.Drawing.Point(341, 282)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(254, 28)
        Me.txtNewPassword.TabIndex = 12
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'lblPasswordverification
        '
        Me.lblPasswordverification.AutoSize = True
        Me.lblPasswordverification.Location = New System.Drawing.Point(710, 311)
        Me.lblPasswordverification.Name = "lblPasswordverification"
        Me.lblPasswordverification.Size = New System.Drawing.Size(16, 13)
        Me.lblPasswordverification.TabIndex = 19
        Me.lblPasswordverification.Text = "---"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.SystemColors.Control
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(341, 207)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(507, 28)
        Me.txtUsername.TabIndex = 18
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BackColor = System.Drawing.SystemColors.Control
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(601, 282)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(247, 28)
        Me.txtConfirmPassword.TabIndex = 15
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(289, 538)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 221
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkRed
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(755, 513)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 222
        Me.btnSave.Text = "Submit"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(836, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(54, 39)
        Me.btnCancel.TabIndex = 223
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(319, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(239, 26)
        Me.Label9.TabIndex = 224
        Me.Label9.Text = "Fill all User Information"
        '
        'Account_Recovery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 562)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblPasswordverification)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtUsername)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Account_Recovery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account_Recovery"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecoveryID As TextBox
    Friend WithEvents txtReason As RichTextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPasswordverification As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label9 As Label
End Class
