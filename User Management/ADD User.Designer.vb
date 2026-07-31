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
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblUserID = New System.Windows.Forms.Label()
        BRANCHLabel = New System.Windows.Forms.Label()
        CONTACTLabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        USERLabel = New System.Windows.Forms.Label()
        USERTYPELabel = New System.Windows.Forms.Label()
        USERNAMELabel = New System.Windows.Forms.Label()
        PASSWORDLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BRANCHLabel
        '
        BRANCHLabel.AutoSize = True
        BRANCHLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BRANCHLabel.Location = New System.Drawing.Point(323, 238)
        BRANCHLabel.Name = "BRANCHLabel"
        BRANCHLabel.Size = New System.Drawing.Size(57, 16)
        BRANCHLabel.TabIndex = 6
        BRANCHLabel.Text = "BRANCH:"
        '
        'CONTACTLabel
        '
        CONTACTLabel.AutoSize = True
        CONTACTLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CONTACTLabel.Location = New System.Drawing.Point(692, 165)
        CONTACTLabel.Name = "CONTACTLabel"
        CONTACTLabel.Size = New System.Drawing.Size(62, 16)
        CONTACTLabel.TabIndex = 8
        CONTACTLabel.Text = "CONTACT:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EMAILLabel.Location = New System.Drawing.Point(323, 165)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(44, 16)
        EMAILLabel.TabIndex = 10
        EMAILLabel.Text = "EMAIL:"
        '
        'USERLabel
        '
        USERLabel.AutoSize = True
        USERLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        USERLabel.Location = New System.Drawing.Point(323, 88)
        USERLabel.Name = "USERLabel"
        USERLabel.Size = New System.Drawing.Size(73, 16)
        USERLabel.TabIndex = 12
        USERLabel.Text = "FULL NAME:"
        '
        'USERTYPELabel
        '
        USERTYPELabel.AutoSize = True
        USERTYPELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        USERTYPELabel.Location = New System.Drawing.Point(692, 88)
        USERTYPELabel.Name = "USERTYPELabel"
        USERTYPELabel.Size = New System.Drawing.Size(63, 16)
        USERTYPELabel.TabIndex = 14
        USERTYPELabel.Text = "USERTYPE:"
        '
        'USERNAMELabel
        '
        USERNAMELabel.AutoSize = True
        USERNAMELabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        USERNAMELabel.Location = New System.Drawing.Point(692, 238)
        USERNAMELabel.Name = "USERNAMELabel"
        USERNAMELabel.Size = New System.Drawing.Size(71, 16)
        USERNAMELabel.TabIndex = 16
        USERNAMELabel.Text = "USERNAME:"
        '
        'PASSWORDLabel
        '
        PASSWORDLabel.AutoSize = True
        PASSWORDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PASSWORDLabel.Location = New System.Drawing.Point(323, 318)
        PASSWORDLabel.Name = "PASSWORDLabel"
        PASSWORDLabel.Size = New System.Drawing.Size(72, 16)
        PASSWORDLabel.TabIndex = 18
        PASSWORDLabel.Text = "PASSWORD:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(323, 404)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(127, 16)
        Label2.TabIndex = 22
        Label2.Text = "CONFIRM PASSWORD:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.ForeColor = System.Drawing.Color.Red
        Label3.Location = New System.Drawing.Point(527, 454)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(68, 16)
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
        Me.btnSave.Location = New System.Drawing.Point(1005, 365)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(140, 37)
        Me.btnSave.TabIndex = 127
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(695, 184)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(269, 28)
        Me.txtContact.TabIndex = 129
        Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboBranch
        '
        Me.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Items.AddRange(New Object() {"IT", "ADMIN", "MANAGER", "SUPERVISOR", "RDU", "CASHIER"})
        Me.cboBranch.Location = New System.Drawing.Point(326, 257)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(363, 28)
        Me.cboBranch.TabIndex = 128
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(326, 423)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(269, 28)
        Me.txtConfirmPassword.TabIndex = 23
        Me.txtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(326, 184)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(363, 28)
        Me.txtEmail.TabIndex = 11
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullName.Location = New System.Drawing.Point(326, 107)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(363, 28)
        Me.txtFullName.TabIndex = 13
        Me.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboUserType
        '
        Me.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Items.AddRange(New Object() {"IT", "ADMIN", "MANAGER", "SUPERVISOR", "RDU", "CASHIER"})
        Me.cboUserType.Location = New System.Drawing.Point(695, 107)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(269, 28)
        Me.cboUserType.TabIndex = 15
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(695, 257)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(269, 28)
        Me.txtUsername.TabIndex = 17
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(326, 337)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(269, 28)
        Me.txtPassword.TabIndex = 19
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(321, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 26)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Please fill all fields"
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
        Me.btnCancel.Location = New System.Drawing.Point(1139, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(54, 39)
        Me.btnCancel.TabIndex = 171
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(289, 475)
        Me.PictureBox1.TabIndex = 175
        Me.PictureBox1.TabStop = False
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(844, 332)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(39, 13)
        Me.lblUserID.TabIndex = 176
        Me.lblUserID.Text = "Label1"
        '
        'Add_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 499)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cboBranch)
        Me.Controls.Add(BRANCHLabel)
        Me.Controls.Add(CONTACTLabel)
        Me.Controls.Add(Label3)
        Me.Controls.Add(EMAILLabel)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents cboUserType As ComboBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents cboBranch As ComboBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblUserID As Label
End Class
