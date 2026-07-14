<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPWDDiscount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPWDDiscount))
        Me.cboIDType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.rchFullAddress = New System.Windows.Forms.RichTextBox()
        Me.btnApplyDiscount = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbldiscount = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSuffix = New System.Windows.Forms.ComboBox()
        Me.rdomale = New System.Windows.Forms.RadioButton()
        Me.rdofemale = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalBeforeDiscount = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboIDType
        '
        Me.cboIDType.BackColor = System.Drawing.SystemColors.Control
        Me.cboIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIDType.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIDType.FormattingEnabled = True
        Me.cboIDType.Location = New System.Drawing.Point(16, 107)
        Me.cboIDType.Name = "cboIDType"
        Me.cboIDType.Size = New System.Drawing.Size(434, 28)
        Me.cboIDType.TabIndex = 308
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(208, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 310
        Me.Label2.Text = "First Name :"
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(212, 169)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(205, 28)
        Me.txtFirstName.TabIndex = 309
        Me.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(451, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = "ID Number :"
        '
        'txtIDNumber
        '
        Me.txtIDNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDNumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.Location = New System.Drawing.Point(455, 107)
        Me.txtIDNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(281, 28)
        Me.txtIDNumber.TabIndex = 311
        Me.txtIDNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(12, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 313
        Me.Label3.Text = "ID type :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(12, 335)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 315
        Me.Label4.Text = "Full Address :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(12, 525)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 317
        Me.Label5.Text = "Contact # :"
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(16, 547)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(2)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(313, 28)
        Me.txtContact.TabIndex = 316
        Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(329, 525)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 319
        Me.Label6.Text = "Email :"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(333, 547)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(402, 28)
        Me.txtEmail.TabIndex = 318
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rchFullAddress
        '
        Me.rchFullAddress.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchFullAddress.Location = New System.Drawing.Point(16, 358)
        Me.rchFullAddress.Name = "rchFullAddress"
        Me.rchFullAddress.Size = New System.Drawing.Size(719, 149)
        Me.rchFullAddress.TabIndex = 320
        Me.rchFullAddress.Text = ""
        '
        'btnApplyDiscount
        '
        Me.btnApplyDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApplyDiscount.BackColor = System.Drawing.SystemColors.Control
        Me.btnApplyDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnApplyDiscount.FlatAppearance.BorderSize = 0
        Me.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyDiscount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyDiscount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnApplyDiscount.Image = CType(resources.GetObject("btnApplyDiscount.Image"), System.Drawing.Image)
        Me.btnApplyDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApplyDiscount.Location = New System.Drawing.Point(533, 657)
        Me.btnApplyDiscount.Name = "btnApplyDiscount"
        Me.btnApplyDiscount.Size = New System.Drawing.Size(98, 47)
        Me.btnApplyDiscount.TabIndex = 323
        Me.btnApplyDiscount.Text = "Discount"
        Me.btnApplyDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnApplyDiscount.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(637, 657)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 322
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.lbldiscount)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(747, 54)
        Me.Panel2.TabIndex = 324
        '
        'lbldiscount
        '
        Me.lbldiscount.AutoSize = True
        Me.lbldiscount.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldiscount.ForeColor = System.Drawing.Color.DarkRed
        Me.lbldiscount.Location = New System.Drawing.Point(79, 9)
        Me.lbldiscount.Name = "lbldiscount"
        Me.lbldiscount.Size = New System.Drawing.Size(212, 36)
        Me.lbldiscount.TabIndex = 0
        Me.lbldiscount.Text = "PWD Discount"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkRed
        Me.Label7.Location = New System.Drawing.Point(417, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 20)
        Me.Label7.TabIndex = 326
        Me.Label7.Text = "Middle :"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMiddleName.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(421, 169)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(200, 28)
        Me.txtMiddleName.TabIndex = 325
        Me.txtMiddleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Location = New System.Drawing.Point(12, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 20)
        Me.Label8.TabIndex = 328
        Me.Label8.Text = "Surname :"
        '
        'txtSurname
        '
        Me.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurname.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurname.Location = New System.Drawing.Point(16, 169)
        Me.txtSurname.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(192, 28)
        Me.txtSurname.TabIndex = 327
        Me.txtSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(622, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 20)
        Me.Label9.TabIndex = 330
        Me.Label9.Text = "Suffix :"
        '
        'cboSuffix
        '
        Me.cboSuffix.BackColor = System.Drawing.SystemColors.Control
        Me.cboSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSuffix.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSuffix.FormattingEnabled = True
        Me.cboSuffix.Location = New System.Drawing.Point(626, 169)
        Me.cboSuffix.Name = "cboSuffix"
        Me.cboSuffix.Size = New System.Drawing.Size(109, 28)
        Me.cboSuffix.TabIndex = 329
        '
        'rdomale
        '
        Me.rdomale.AutoSize = True
        Me.rdomale.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdomale.ForeColor = System.Drawing.Color.DarkRed
        Me.rdomale.Location = New System.Drawing.Point(16, 274)
        Me.rdomale.Name = "rdomale"
        Me.rdomale.Size = New System.Drawing.Size(76, 29)
        Me.rdomale.TabIndex = 331
        Me.rdomale.TabStop = True
        Me.rdomale.Text = "Male"
        Me.rdomale.UseVisualStyleBackColor = True
        '
        'rdofemale
        '
        Me.rdofemale.AutoSize = True
        Me.rdofemale.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdofemale.ForeColor = System.Drawing.Color.DarkRed
        Me.rdofemale.Location = New System.Drawing.Point(137, 274)
        Me.rdofemale.Name = "rdofemale"
        Me.rdofemale.Size = New System.Drawing.Size(96, 29)
        Me.rdofemale.TabIndex = 332
        Me.rdofemale.TabStop = True
        Me.rdofemale.Text = "Female"
        Me.rdofemale.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(12, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 20)
        Me.Label10.TabIndex = 333
        Me.Label10.Text = "Gender :"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(421, 274)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(314, 29)
        Me.dtpDateOfBirth.TabIndex = 334
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(417, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 20)
        Me.Label11.TabIndex = 335
        Me.Label11.Text = "Date of Birth :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(12, 625)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 20)
        Me.Label12.TabIndex = 336
        Me.Label12.Text = "Discount :"
        '
        'lblTotalBeforeDiscount
        '
        Me.lblTotalBeforeDiscount.AutoSize = True
        Me.lblTotalBeforeDiscount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBeforeDiscount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalBeforeDiscount.Location = New System.Drawing.Point(94, 625)
        Me.lblTotalBeforeDiscount.Name = "lblTotalBeforeDiscount"
        Me.lblTotalBeforeDiscount.Size = New System.Drawing.Size(76, 20)
        Me.lblTotalBeforeDiscount.TabIndex = 337
        Me.lblTotalBeforeDiscount.Text = "Discount :"
        '
        'frmPWDDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 716)
        Me.Controls.Add(Me.lblTotalBeforeDiscount)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.rdofemale)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rdomale)
        Me.Controls.Add(Me.cboSuffix)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMiddleName)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnApplyDiscount)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rchFullAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIDNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.cboIDType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPWDDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PWDDiscount"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboIDType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIDNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents rchFullAddress As RichTextBox
    Friend WithEvents btnApplyDiscount As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbldiscount As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboSuffix As ComboBox
    Friend WithEvents rdomale As RadioButton
    Friend WithEvents rdofemale As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTotalBeforeDiscount As Label
End Class
