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
        Me.cboDiscountType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnApplyDiscount = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSuffix = New System.Windows.Forms.ComboBox()
        Me.rdomale = New System.Windows.Forms.RadioButton()
        Me.rdofemale = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblDiscountAmount = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtNationality = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFinalAmount = New System.Windows.Forms.Label()
        Me.lblTotalBeforeDiscount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboDiscountType
        '
        Me.cboDiscountType.BackColor = System.Drawing.SystemColors.Control
        Me.cboDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiscountType.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDiscountType.FormattingEnabled = True
        Me.cboDiscountType.Location = New System.Drawing.Point(16, 45)
        Me.cboDiscountType.Name = "cboDiscountType"
        Me.cboDiscountType.Size = New System.Drawing.Size(434, 28)
        Me.cboDiscountType.TabIndex = 308
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(451, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = "ID Number :"
        '
        'txtIDNumber
        '
        Me.txtIDNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDNumber.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.Location = New System.Drawing.Point(455, 45)
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
        Me.Label3.Location = New System.Drawing.Point(12, 22)
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
        Me.Label4.Location = New System.Drawing.Point(12, 273)
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
        Me.Label5.Location = New System.Drawing.Point(12, 463)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 317
        Me.Label5.Text = "Contact # :"
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(16, 485)
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
        Me.Label6.Location = New System.Drawing.Point(329, 463)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 319
        Me.Label6.Text = "Email :"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(333, 485)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(402, 28)
        Me.txtEmail.TabIndex = 318
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.btnApplyDiscount.Location = New System.Drawing.Point(534, 595)
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
        Me.btnClose.Location = New System.Drawing.Point(638, 595)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 322
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkRed
        Me.Label7.Location = New System.Drawing.Point(17, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 20)
        Me.Label7.TabIndex = 326
        Me.Label7.Text = "Middle :"
        '
        'txtFullName
        '
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullName.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullName.Location = New System.Drawing.Point(16, 107)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(605, 28)
        Me.txtFullName.TabIndex = 325
        Me.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(622, 84)
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
        Me.cboSuffix.Location = New System.Drawing.Point(626, 107)
        Me.cboSuffix.Name = "cboSuffix"
        Me.cboSuffix.Size = New System.Drawing.Size(109, 28)
        Me.cboSuffix.TabIndex = 329
        '
        'rdomale
        '
        Me.rdomale.AutoSize = True
        Me.rdomale.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdomale.ForeColor = System.Drawing.Color.DarkRed
        Me.rdomale.Location = New System.Drawing.Point(16, 212)
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
        Me.rdofemale.Location = New System.Drawing.Point(137, 212)
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
        Me.Label10.Location = New System.Drawing.Point(12, 171)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 20)
        Me.Label10.TabIndex = 333
        Me.Label10.Text = "Gender :"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(421, 212)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(314, 29)
        Me.dtpDateOfBirth.TabIndex = 334
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(417, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 20)
        Me.Label11.TabIndex = 335
        Me.Label11.Text = "Date of Birth :"
        '
        'lblDiscountAmount
        '
        Me.lblDiscountAmount.AutoSize = True
        Me.lblDiscountAmount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscountAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblDiscountAmount.Location = New System.Drawing.Point(305, 544)
        Me.lblDiscountAmount.Name = "lblDiscountAmount"
        Me.lblDiscountAmount.Size = New System.Drawing.Size(15, 20)
        Me.lblDiscountAmount.TabIndex = 337
        Me.lblDiscountAmount.Text = "-"
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(16, 295)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(605, 28)
        Me.txtAddress.TabIndex = 338
        Me.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNationality
        '
        Me.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNationality.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNationality.Location = New System.Drawing.Point(16, 375)
        Me.txtNationality.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.Size = New System.Drawing.Size(605, 28)
        Me.txtNationality.TabIndex = 340
        Me.txtNationality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(12, 353)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Nationality:"
        '
        'lblFinalAmount
        '
        Me.lblFinalAmount.AutoSize = True
        Me.lblFinalAmount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalAmount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblFinalAmount.Location = New System.Drawing.Point(548, 544)
        Me.lblFinalAmount.Name = "lblFinalAmount"
        Me.lblFinalAmount.Size = New System.Drawing.Size(15, 20)
        Me.lblFinalAmount.TabIndex = 342
        Me.lblFinalAmount.Text = "-"
        '
        'lblTotalBeforeDiscount
        '
        Me.lblTotalBeforeDiscount.AutoSize = True
        Me.lblTotalBeforeDiscount.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBeforeDiscount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalBeforeDiscount.Location = New System.Drawing.Point(12, 544)
        Me.lblTotalBeforeDiscount.Name = "lblTotalBeforeDiscount"
        Me.lblTotalBeforeDiscount.Size = New System.Drawing.Size(15, 20)
        Me.lblTotalBeforeDiscount.TabIndex = 344
        Me.lblTotalBeforeDiscount.Text = "-"
        '
        'frmPWDDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 654)
        Me.Controls.Add(Me.lblTotalBeforeDiscount)
        Me.Controls.Add(Me.lblFinalAmount)
        Me.Controls.Add(Me.txtNationality)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblDiscountAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.rdofemale)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rdomale)
        Me.Controls.Add(Me.cboSuffix)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.btnApplyDiscount)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIDNumber)
        Me.Controls.Add(Me.cboDiscountType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPWDDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PWDDiscount"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboDiscountType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIDNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnApplyDiscount As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboSuffix As ComboBox
    Friend WithEvents rdomale As RadioButton
    Friend WithEvents rdofemale As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents lblDiscountAmount As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtNationality As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFinalAmount As Label
    Friend WithEvents lblTotalBeforeDiscount As Label
End Class
