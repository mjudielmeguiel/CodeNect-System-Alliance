<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADD_Vendor
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
        Dim VENDOR_IDLabel As System.Windows.Forms.Label
        Dim VENDOR_NAMELabel As System.Windows.Forms.Label
        Dim CONTACTLabel As System.Windows.Forms.Label
        Dim EMAILLabel As System.Windows.Forms.Label
        Dim TINLabel As System.Windows.Forms.Label
        Dim SALES_PERSONLabel As System.Windows.Forms.Label
        Dim BUSINESS_TYPELabel As System.Windows.Forms.Label
        Dim ADDRESSLabel As System.Windows.Forms.Label
        Dim MODE_OF_PAYMENTLabel As System.Windows.Forms.Label
        Dim BANK_ACCOUNT_NUMBERLabel As System.Windows.Forms.Label
        Dim PAYMENT_TERMSLabel As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADD_Vendor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.txtVendorCode = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.txtSalesPerson = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtBankAccount = New System.Windows.Forms.TextBox()
        Me.txtDTI = New System.Windows.Forms.TextBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnclose2 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cboBusinessType = New System.Windows.Forms.ComboBox()
        Me.cboVatStatus = New System.Windows.Forms.ComboBox()
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.cboModeOfPayment = New System.Windows.Forms.ComboBox()
        VENDOR_IDLabel = New System.Windows.Forms.Label()
        VENDOR_NAMELabel = New System.Windows.Forms.Label()
        CONTACTLabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        TINLabel = New System.Windows.Forms.Label()
        SALES_PERSONLabel = New System.Windows.Forms.Label()
        BUSINESS_TYPELabel = New System.Windows.Forms.Label()
        ADDRESSLabel = New System.Windows.Forms.Label()
        MODE_OF_PAYMENTLabel = New System.Windows.Forms.Label()
        BANK_ACCOUNT_NUMBERLabel = New System.Windows.Forms.Label()
        PAYMENT_TERMSLabel = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VENDOR_IDLabel
        '
        VENDOR_IDLabel.AutoSize = True
        VENDOR_IDLabel.Location = New System.Drawing.Point(9, 69)
        VENDOR_IDLabel.Name = "VENDOR_IDLabel"
        VENDOR_IDLabel.Size = New System.Drawing.Size(89, 13)
        VENDOR_IDLabel.TabIndex = 3
        VENDOR_IDLabel.Text = "VENDOR CODE:"
        '
        'VENDOR_NAMELabel
        '
        VENDOR_NAMELabel.AutoSize = True
        VENDOR_NAMELabel.Location = New System.Drawing.Point(216, 69)
        VENDOR_NAMELabel.Name = "VENDOR_NAMELabel"
        VENDOR_NAMELabel.Size = New System.Drawing.Size(56, 13)
        VENDOR_NAMELabel.TabIndex = 5
        VENDOR_NAMELabel.Text = "VENDOR:"
        '
        'CONTACTLabel
        '
        CONTACTLabel.AutoSize = True
        CONTACTLabel.Location = New System.Drawing.Point(9, 211)
        CONTACTLabel.Name = "CONTACTLabel"
        CONTACTLabel.Size = New System.Drawing.Size(61, 13)
        CONTACTLabel.TabIndex = 7
        CONTACTLabel.Text = "CONTACT:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Location = New System.Drawing.Point(212, 211)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(42, 13)
        EMAILLabel.TabIndex = 9
        EMAILLabel.Text = "EMAIL:"
        '
        'TINLabel
        '
        TINLabel.AutoSize = True
        TINLabel.Location = New System.Drawing.Point(347, 280)
        TINLabel.Name = "TINLabel"
        TINLabel.Size = New System.Drawing.Size(28, 13)
        TINLabel.TabIndex = 17
        TINLabel.Text = "TIN:"
        '
        'SALES_PERSONLabel
        '
        SALES_PERSONLabel.AutoSize = True
        SALES_PERSONLabel.Location = New System.Drawing.Point(9, 353)
        SALES_PERSONLabel.Name = "SALES_PERSONLabel"
        SALES_PERSONLabel.Size = New System.Drawing.Size(92, 13)
        SALES_PERSONLabel.TabIndex = 19
        SALES_PERSONLabel.Text = "SALES PERSON:"
        '
        'BUSINESS_TYPELabel
        '
        BUSINESS_TYPELabel.AutoSize = True
        BUSINESS_TYPELabel.Location = New System.Drawing.Point(539, 214)
        BUSINESS_TYPELabel.Name = "BUSINESS_TYPELabel"
        BUSINESS_TYPELabel.Size = New System.Drawing.Size(95, 13)
        BUSINESS_TYPELabel.TabIndex = 21
        BUSINESS_TYPELabel.Text = "BUSINESS TYPE:"
        '
        'ADDRESSLabel
        '
        ADDRESSLabel.AutoSize = True
        ADDRESSLabel.Location = New System.Drawing.Point(9, 140)
        ADDRESSLabel.Name = "ADDRESSLabel"
        ADDRESSLabel.Size = New System.Drawing.Size(62, 13)
        ADDRESSLabel.TabIndex = 23
        ADDRESSLabel.Text = "ADDRESS:"
        '
        'MODE_OF_PAYMENTLabel
        '
        MODE_OF_PAYMENTLabel.AutoSize = True
        MODE_OF_PAYMENTLabel.Location = New System.Drawing.Point(9, 426)
        MODE_OF_PAYMENTLabel.Name = "MODE_OF_PAYMENTLabel"
        MODE_OF_PAYMENTLabel.Size = New System.Drawing.Size(114, 13)
        MODE_OF_PAYMENTLabel.TabIndex = 25
        MODE_OF_PAYMENTLabel.Text = "MODE OF PAYMENT:"
        '
        'BANK_ACCOUNT_NUMBERLabel
        '
        BANK_ACCOUNT_NUMBERLabel.AutoSize = True
        BANK_ACCOUNT_NUMBERLabel.Location = New System.Drawing.Point(769, 427)
        BANK_ACCOUNT_NUMBERLabel.Name = "BANK_ACCOUNT_NUMBERLabel"
        BANK_ACCOUNT_NUMBERLabel.Size = New System.Drawing.Size(144, 13)
        BANK_ACCOUNT_NUMBERLabel.TabIndex = 27
        BANK_ACCOUNT_NUMBERLabel.Text = "BANK ACCOUNT NUMBER:"
        '
        'PAYMENT_TERMSLabel
        '
        PAYMENT_TERMSLabel.AutoSize = True
        PAYMENT_TERMSLabel.Location = New System.Drawing.Point(769, 356)
        PAYMENT_TERMSLabel.Name = "PAYMENT_TERMSLabel"
        PAYMENT_TERMSLabel.Size = New System.Drawing.Size(103, 13)
        PAYMENT_TERMSLabel.TabIndex = 29
        PAYMENT_TERMSLabel.Text = "PAYMENT TERMS:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(239, 426)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(39, 13)
        Label3.TabIndex = 138
        Label3.Text = "BANK:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(9, 279)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(28, 13)
        Label5.TabIndex = 142
        Label5.Text = "DTI:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(769, 282)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(77, 13)
        Label6.TabIndex = 144
        Label6.Text = "VAT STATUS:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.btnclose2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1081, 54)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(79, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add New Vendor"
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
        'txtVendorCode
        '
        Me.txtVendorCode.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendorCode.Enabled = False
        Me.txtVendorCode.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCode.Location = New System.Drawing.Point(9, 85)
        Me.txtVendorCode.Name = "txtVendorCode"
        Me.txtVendorCode.Size = New System.Drawing.Size(200, 32)
        Me.txtVendorCode.TabIndex = 4
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.SystemColors.Control
        Me.txtVendor.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(219, 85)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(547, 32)
        Me.txtVendor.TabIndex = 6
        '
        'txtContact
        '
        Me.txtContact.BackColor = System.Drawing.SystemColors.Control
        Me.txtContact.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(12, 227)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(197, 32)
        Me.txtContact.TabIndex = 8
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(215, 227)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(321, 32)
        Me.txtEmail.TabIndex = 10
        '
        'txtTIN
        '
        Me.txtTIN.BackColor = System.Drawing.SystemColors.Control
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(350, 296)
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(416, 32)
        Me.txtTIN.TabIndex = 18
        '
        'txtSalesPerson
        '
        Me.txtSalesPerson.BackColor = System.Drawing.SystemColors.Control
        Me.txtSalesPerson.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPerson.Location = New System.Drawing.Point(12, 369)
        Me.txtSalesPerson.Name = "txtSalesPerson"
        Me.txtSalesPerson.Size = New System.Drawing.Size(754, 32)
        Me.txtSalesPerson.TabIndex = 20
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(12, 156)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(754, 32)
        Me.txtAddress.TabIndex = 24
        '
        'txtBankAccount
        '
        Me.txtBankAccount.BackColor = System.Drawing.SystemColors.Control
        Me.txtBankAccount.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccount.Location = New System.Drawing.Point(772, 443)
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.Size = New System.Drawing.Size(297, 32)
        Me.txtBankAccount.TabIndex = 28
        '
        'txtDTI
        '
        Me.txtDTI.BackColor = System.Drawing.SystemColors.Control
        Me.txtDTI.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDTI.Location = New System.Drawing.Point(12, 295)
        Me.txtDTI.Name = "txtDTI"
        Me.txtDTI.Size = New System.Drawing.Size(332, 32)
        Me.txtDTI.TabIndex = 143
        Me.txtDTI.UseSystemPasswordChar = True
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(819, 85)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(194, 174)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 137
        Me.picLogo.TabStop = False
        '
        'btnclose2
        '
        Me.btnclose2.BackColor = System.Drawing.Color.DarkRed
        Me.btnclose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnclose2.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose2.FlatAppearance.BorderSize = 0
        Me.btnclose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose2.ForeColor = System.Drawing.Color.Maroon
        Me.btnclose2.Image = CType(resources.GetObject("btnclose2.Image"), System.Drawing.Image)
        Me.btnclose2.Location = New System.Drawing.Point(1015, 0)
        Me.btnclose2.Name = "btnclose2"
        Me.btnclose2.Size = New System.Drawing.Size(66, 54)
        Me.btnclose2.TabIndex = 137
        Me.btnclose2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnclose2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnclose2.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(971, 488)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 47)
        Me.btnCancel.TabIndex = 295
        Me.btnCancel.Text = "Close"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(850, 488)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(115, 47)
        Me.btnSave.TabIndex = 296
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cboBusinessType
        '
        Me.cboBusinessType.BackColor = System.Drawing.SystemColors.Control
        Me.cboBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBusinessType.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusinessType.FormattingEnabled = True
        Me.cboBusinessType.Location = New System.Drawing.Point(542, 230)
        Me.cboBusinessType.Name = "cboBusinessType"
        Me.cboBusinessType.Size = New System.Drawing.Size(224, 29)
        Me.cboBusinessType.TabIndex = 297
        '
        'cboVatStatus
        '
        Me.cboVatStatus.BackColor = System.Drawing.SystemColors.Control
        Me.cboVatStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVatStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVatStatus.FormattingEnabled = True
        Me.cboVatStatus.Location = New System.Drawing.Point(772, 299)
        Me.cboVatStatus.Name = "cboVatStatus"
        Me.cboVatStatus.Size = New System.Drawing.Size(297, 29)
        Me.cboVatStatus.TabIndex = 298
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.BackColor = System.Drawing.SystemColors.Control
        Me.cboPaymentTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentTerms.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(772, 372)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(297, 29)
        Me.cboPaymentTerms.TabIndex = 299
        '
        'cboBank
        '
        Me.cboBank.BackColor = System.Drawing.SystemColors.Control
        Me.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBank.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(242, 446)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(524, 29)
        Me.cboBank.TabIndex = 300
        '
        'cboModeOfPayment
        '
        Me.cboModeOfPayment.BackColor = System.Drawing.SystemColors.Control
        Me.cboModeOfPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModeOfPayment.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfPayment.FormattingEnabled = True
        Me.cboModeOfPayment.Location = New System.Drawing.Point(12, 446)
        Me.cboModeOfPayment.Name = "cboModeOfPayment"
        Me.cboModeOfPayment.Size = New System.Drawing.Size(224, 29)
        Me.cboModeOfPayment.TabIndex = 301
        '
        'ADD_Vendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 547)
        Me.Controls.Add(Me.cboModeOfPayment)
        Me.Controls.Add(Me.cboBank)
        Me.Controls.Add(Me.cboPaymentTerms)
        Me.Controls.Add(Me.cboVatStatus)
        Me.Controls.Add(Me.cboBusinessType)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtDTI)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtVendorCode)
        Me.Controls.Add(Label3)
        Me.Controls.Add(TINLabel)
        Me.Controls.Add(Me.txtTIN)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(PAYMENT_TERMSLabel)
        Me.Controls.Add(SALES_PERSONLabel)
        Me.Controls.Add(Me.txtBankAccount)
        Me.Controls.Add(EMAILLabel)
        Me.Controls.Add(BANK_ACCOUNT_NUMBERLabel)
        Me.Controls.Add(Me.txtSalesPerson)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(VENDOR_IDLabel)
        Me.Controls.Add(BUSINESS_TYPELabel)
        Me.Controls.Add(MODE_OF_PAYMENTLabel)
        Me.Controls.Add(CONTACTLabel)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(VENDOR_NAMELabel)
        Me.Controls.Add(ADDRESSLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ADD_Vendor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Vendor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents txtVendorCode As TextBox
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents txtSalesPerson As TextBox
    Friend WithEvents txtBankAccount As TextBox
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtDTI As TextBox
    Friend WithEvents btnclose2 As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cboBusinessType As ComboBox
    Friend WithEvents cboVatStatus As ComboBox
    Friend WithEvents cboPaymentTerms As ComboBox
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents cboModeOfPayment As ComboBox
End Class
