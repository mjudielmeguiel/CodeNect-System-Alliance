<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Edit_User
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edit_User))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblAccountID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.LabelFullName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.LabelContact = New System.Windows.Forms.Label()
        Me.LabelEmail = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbousertype = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(343, 618)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 37)
        Me.btnCancel.TabIndex = 127
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblAccountID
        '
        Me.lblAccountID.AutoSize = True
        Me.lblAccountID.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountID.Location = New System.Drawing.Point(178, 74)
        Me.lblAccountID.Name = "lblAccountID"
        Me.lblAccountID.Size = New System.Drawing.Size(57, 19)
        Me.lblAccountID.TabIndex = 253
        Me.lblAccountID.Text = "000000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 19)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "ACCOUNT ID :"
        '
        'txtFullName
        '
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullName.Location = New System.Drawing.Point(140, 265)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(344, 26)
        Me.txtFullName.TabIndex = 251
        '
        'LabelFullName
        '
        Me.LabelFullName.AutoSize = True
        Me.LabelFullName.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFullName.Location = New System.Drawing.Point(11, 268)
        Me.LabelFullName.Name = "LabelFullName"
        Me.LabelFullName.Size = New System.Drawing.Size(91, 19)
        Me.LabelFullName.TabIndex = 238
        Me.LabelFullName.Text = "FULL NAME :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 249
        Me.Label5.Text = "BRANCH :"
        '
        'cboBranch
        '
        Me.cboBranch.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Location = New System.Drawing.Point(140, 215)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(344, 28)
        Me.cboBranch.TabIndex = 250
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = "BRANCH ID :"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(140, 360)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(344, 26)
        Me.txtEmail.TabIndex = 246
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(140, 406)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(344, 26)
        Me.txtContact.TabIndex = 245
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 19)
        Me.Label4.TabIndex = 243
        Me.Label4.Text = "STATUS :"
        '
        'cboStatus
        '
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(140, 168)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(195, 28)
        Me.cboStatus.TabIndex = 244
        '
        'LabelContact
        '
        Me.LabelContact.AutoSize = True
        Me.LabelContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelContact.Location = New System.Drawing.Point(11, 409)
        Me.LabelContact.Name = "LabelContact"
        Me.LabelContact.Size = New System.Drawing.Size(79, 19)
        Me.LabelContact.TabIndex = 240
        Me.LabelContact.Text = "CONTACT :"
        '
        'LabelEmail
        '
        Me.LabelEmail.AutoSize = True
        Me.LabelEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEmail.Location = New System.Drawing.Point(11, 363)
        Me.LabelEmail.Name = "LabelEmail"
        Me.LabelEmail.Size = New System.Drawing.Size(56, 19)
        Me.LabelEmail.TabIndex = 239
        Me.LabelEmail.Text = "EMAIL :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 241
        Me.Label3.Text = "USER_TYPE :"
        '
        'cbousertype
        '
        Me.cbousertype.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbousertype.FormattingEnabled = True
        Me.cbousertype.Location = New System.Drawing.Point(140, 314)
        Me.cbousertype.Name = "cbousertype"
        Me.cbousertype.Size = New System.Drawing.Size(344, 28)
        Me.cbousertype.TabIndex = 242
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Maroon
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(200, 618)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(135, 37)
        Me.btnDelete.TabIndex = 279
        Me.btnDelete.Text = " Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Maroon
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(54, 618)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(140, 37)
        Me.btnUpdate.TabIndex = 277
        Me.btnUpdate.Text = " Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 54)
        Me.Panel1.TabIndex = 280
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EDIT USER"
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
        'txtOldPassword
        '
        Me.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOldPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPassword.Location = New System.Drawing.Point(140, 454)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Size = New System.Drawing.Size(344, 26)
        Me.txtOldPassword.TabIndex = 282
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 457)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 19)
        Me.Label2.TabIndex = 281
        Me.Label2.Text = "OLD PASSWORD :"
        '
        'txtNewPass
        '
        Me.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPass.Location = New System.Drawing.Point(140, 500)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(344, 26)
        Me.txtNewPass.TabIndex = 284
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 503)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 19)
        Me.Label9.TabIndex = 283
        Me.Label9.Text = "NEW PASSWORD :"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.Location = New System.Drawing.Point(141, 550)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(344, 26)
        Me.txtConfirmPassword.TabIndex = 286
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 553)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 19)
        Me.Label10.TabIndex = 285
        Me.Label10.Text = "CONFIRM :"
        '
        'txtBranchID
        '
        Me.txtBranchID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(140, 120)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.Size = New System.Drawing.Size(198, 26)
        Me.txtBranchID.TabIndex = 287
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(344, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(140, 122)
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'Edit_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 667)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtBranchID)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblAccountID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.LabelFullName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboBranch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.LabelContact)
        Me.Controls.Add(Me.LabelEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbousertype)
        Me.Controls.Add(Me.btnCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Edit_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit_User"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents lblAccountID As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents LabelFullName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboBranch As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents LabelContact As Label
    Friend WithEvents LabelEmail As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbousertype As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents txtOldPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBranchID As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
