<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Add_User
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
        Dim BRANCHLabel As System.Windows.Forms.Label
        Dim CONTACTLabel As System.Windows.Forms.Label
        Dim EMAILLabel As System.Windows.Forms.Label
        Dim USERLabel As System.Windows.Forms.Label
        Dim USERTYPELabel As System.Windows.Forms.Label
        Dim USERNAMELabel As System.Windows.Forms.Label
        Dim PASSWORDLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Add_User))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Me.picProfile = New System.Windows.Forms.PictureBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        BRANCHLabel = New System.Windows.Forms.Label()
        CONTACTLabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        USERLabel = New System.Windows.Forms.Label()
        USERTYPELabel = New System.Windows.Forms.Label()
        USERNAMELabel = New System.Windows.Forms.Label()
        PASSWORDLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BRANCHLabel
        '
        BRANCHLabel.AutoSize = True
        BRANCHLabel.Location = New System.Drawing.Point(12, 205)
        BRANCHLabel.Name = "BRANCHLabel"
        BRANCHLabel.Size = New System.Drawing.Size(55, 13)
        BRANCHLabel.TabIndex = 6
        BRANCHLabel.Text = "BRANCH:"
        '
        'CONTACTLabel
        '
        CONTACTLabel.AutoSize = True
        CONTACTLabel.Location = New System.Drawing.Point(12, 140)
        CONTACTLabel.Name = "CONTACTLabel"
        CONTACTLabel.Size = New System.Drawing.Size(61, 13)
        CONTACTLabel.TabIndex = 8
        CONTACTLabel.Text = "CONTACT:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Location = New System.Drawing.Point(12, 172)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(42, 13)
        EMAILLabel.TabIndex = 10
        EMAILLabel.Text = "EMAIL:"
        '
        'USERLabel
        '
        USERLabel.AutoSize = True
        USERLabel.Location = New System.Drawing.Point(12, 74)
        USERLabel.Name = "USERLabel"
        USERLabel.Size = New System.Drawing.Size(70, 13)
        USERLabel.TabIndex = 12
        USERLabel.Text = "FULL NAME:"
        '
        'USERTYPELabel
        '
        USERTYPELabel.AutoSize = True
        USERTYPELabel.Location = New System.Drawing.Point(12, 107)
        USERTYPELabel.Name = "USERTYPELabel"
        USERTYPELabel.Size = New System.Drawing.Size(68, 13)
        USERTYPELabel.TabIndex = 14
        USERTYPELabel.Text = "USERTYPE:"
        '
        'USERNAMELabel
        '
        USERNAMELabel.AutoSize = True
        USERNAMELabel.Location = New System.Drawing.Point(12, 238)
        USERNAMELabel.Name = "USERNAMELabel"
        USERNAMELabel.Size = New System.Drawing.Size(71, 13)
        USERNAMELabel.TabIndex = 16
        USERNAMELabel.Text = "USERNAME:"
        '
        'PASSWORDLabel
        '
        PASSWORDLabel.AutoSize = True
        PASSWORDLabel.Location = New System.Drawing.Point(12, 302)
        PASSWORDLabel.Name = "PASSWORDLabel"
        PASSWORDLabel.Size = New System.Drawing.Size(73, 13)
        PASSWORDLabel.TabIndex = 18
        PASSWORDLabel.Text = "PASSWORD:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 270)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(125, 13)
        Label2.TabIndex = 22
        Label2.Text = "CONFIRM PASSWORD:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.ForeColor = System.Drawing.Color.Red
        Label3.Location = New System.Drawing.Point(498, 324)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(63, 13)
        Label3.TabIndex = 126
        Label3.Text = "Password1*"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(274, 358)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(140, 37)
        Me.btnSave.TabIndex = 127
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Maroon
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(274, 358)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(140, 37)
        Me.Button5.TabIndex = 128
        Me.Button5.Text = " Save"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(420, 358)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 37)
        Me.btnCancel.TabIndex = 126
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtBranchID
        '
        Me.txtBranchID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(420, 199)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.ReadOnly = True
        Me.txtBranchID.Size = New System.Drawing.Size(141, 26)
        Me.txtBranchID.TabIndex = 130
        Me.txtBranchID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(147, 133)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(268, 26)
        Me.txtContact.TabIndex = 129
        Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboBranch
        '
        Me.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Items.AddRange(New Object() {"IT", "ADMIN", "MANAGER", "SUPERVISOR", "RDU", "CASHIER"})
        Me.cboBranch.Location = New System.Drawing.Point(147, 197)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(268, 28)
        Me.cboBranch.TabIndex = 128
        '
        'picProfile
        '
        Me.picProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picProfile.Image = CType(resources.GetObject("picProfile.Image"), System.Drawing.Image)
        Me.picProfile.Location = New System.Drawing.Point(421, 67)
        Me.picProfile.Name = "picProfile"
        Me.picProfile.Size = New System.Drawing.Size(140, 124)
        Me.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picProfile.TabIndex = 127
        Me.picProfile.TabStop = False
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(147, 263)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(414, 26)
        Me.txtConfirmPassword.TabIndex = 23
        Me.txtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(147, 165)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(268, 26)
        Me.txtEmail.TabIndex = 11
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFullName
        '
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullName.Location = New System.Drawing.Point(147, 67)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(268, 26)
        Me.txtFullName.TabIndex = 13
        Me.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboUserType
        '
        Me.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Items.AddRange(New Object() {"IT", "ADMIN", "MANAGER", "SUPERVISOR", "RDU", "CASHIER"})
        Me.cboUserType.Location = New System.Drawing.Point(146, 99)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(269, 28)
        Me.cboUserType.TabIndex = 15
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(147, 231)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(414, 26)
        Me.txtUsername.TabIndex = 17
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(147, 295)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(414, 26)
        Me.txtPassword.TabIndex = 19
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.userPic)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(573, 54)
        Me.Panel2.TabIndex = 137
        '
        'userPic
        '
        Me.userPic.Dock = System.Windows.Forms.DockStyle.Left
        Me.userPic.Image = CType(resources.GetObject("userPic.Image"), System.Drawing.Image)
        Me.userPic.Location = New System.Drawing.Point(0, 0)
        Me.userPic.Name = "userPic"
        Me.userPic.Size = New System.Drawing.Size(73, 54)
        Me.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.userPic.TabIndex = 7
        Me.userPic.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW USER ACCOUNT"
        '
        'Add_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 407)
        Me.Controls.Add(Me.txtBranchID)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cboBranch)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.picProfile)
        Me.Controls.Add(BRANCHLabel)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(CONTACTLabel)
        Me.Controls.Add(Label3)
        Me.Controls.Add(EMAILLabel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Label2)
        Me.Controls.Add(USERLabel)
        Me.Controls.Add(Me.cboUserType)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(PASSWORDLabel)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(USERNAMELabel)
        Me.Controls.Add(USERTYPELabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Add_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_User"
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents cboUserType As ComboBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents picProfile As PictureBox
    Friend WithEvents cboBranch As ComboBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtBranchID As TextBox
End Class
