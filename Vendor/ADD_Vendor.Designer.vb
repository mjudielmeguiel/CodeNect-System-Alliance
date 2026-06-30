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
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.txtVendorCode = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.txtSalesPerson = New System.Windows.Forms.TextBox()
        Me.cboBusinessType = New System.Windows.Forms.ComboBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.cboModeOfPayment = New System.Windows.Forms.ComboBox()
        Me.txtBankAccount = New System.Windows.Forms.TextBox()
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboVatStatus = New System.Windows.Forms.ComboBox()
        Me.txtDTI = New System.Windows.Forms.TextBox()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
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
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VENDOR_IDLabel
        '
        VENDOR_IDLabel.AutoSize = True
        VENDOR_IDLabel.Location = New System.Drawing.Point(12, 17)
        VENDOR_IDLabel.Name = "VENDOR_IDLabel"
        VENDOR_IDLabel.Size = New System.Drawing.Size(89, 13)
        VENDOR_IDLabel.TabIndex = 3
        VENDOR_IDLabel.Text = "VENDOR CODE:"
        '
        'VENDOR_NAMELabel
        '
        VENDOR_NAMELabel.AutoSize = True
        VENDOR_NAMELabel.Location = New System.Drawing.Point(136, 17)
        VENDOR_NAMELabel.Name = "VENDOR_NAMELabel"
        VENDOR_NAMELabel.Size = New System.Drawing.Size(56, 13)
        VENDOR_NAMELabel.TabIndex = 5
        VENDOR_NAMELabel.Text = "VENDOR:"
        '
        'CONTACTLabel
        '
        CONTACTLabel.AutoSize = True
        CONTACTLabel.Location = New System.Drawing.Point(12, 107)
        CONTACTLabel.Name = "CONTACTLabel"
        CONTACTLabel.Size = New System.Drawing.Size(61, 13)
        CONTACTLabel.TabIndex = 7
        CONTACTLabel.Text = "CONTACT:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Location = New System.Drawing.Point(197, 107)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(42, 13)
        EMAILLabel.TabIndex = 9
        EMAILLabel.Text = "EMAIL:"
        '
        'TINLabel
        '
        TINLabel.AutoSize = True
        TINLabel.Location = New System.Drawing.Point(12, 62)
        TINLabel.Name = "TINLabel"
        TINLabel.Size = New System.Drawing.Size(28, 13)
        TINLabel.TabIndex = 17
        TINLabel.Text = "TIN:"
        '
        'SALES_PERSONLabel
        '
        SALES_PERSONLabel.AutoSize = True
        SALES_PERSONLabel.Location = New System.Drawing.Point(9, 152)
        SALES_PERSONLabel.Name = "SALES_PERSONLabel"
        SALES_PERSONLabel.Size = New System.Drawing.Size(92, 13)
        SALES_PERSONLabel.TabIndex = 19
        SALES_PERSONLabel.Text = "SALES PERSON:"
        '
        'BUSINESS_TYPELabel
        '
        BUSINESS_TYPELabel.AutoSize = True
        BUSINESS_TYPELabel.Location = New System.Drawing.Point(339, 152)
        BUSINESS_TYPELabel.Name = "BUSINESS_TYPELabel"
        BUSINESS_TYPELabel.Size = New System.Drawing.Size(95, 13)
        BUSINESS_TYPELabel.TabIndex = 21
        BUSINESS_TYPELabel.Text = "BUSINESS TYPE:"
        '
        'ADDRESSLabel
        '
        ADDRESSLabel.AutoSize = True
        ADDRESSLabel.Location = New System.Drawing.Point(9, 197)
        ADDRESSLabel.Name = "ADDRESSLabel"
        ADDRESSLabel.Size = New System.Drawing.Size(62, 13)
        ADDRESSLabel.TabIndex = 23
        ADDRESSLabel.Text = "ADDRESS:"
        '
        'MODE_OF_PAYMENTLabel
        '
        MODE_OF_PAYMENTLabel.AutoSize = True
        MODE_OF_PAYMENTLabel.Location = New System.Drawing.Point(9, 242)
        MODE_OF_PAYMENTLabel.Name = "MODE_OF_PAYMENTLabel"
        MODE_OF_PAYMENTLabel.Size = New System.Drawing.Size(114, 13)
        MODE_OF_PAYMENTLabel.TabIndex = 25
        MODE_OF_PAYMENTLabel.Text = "MODE OF PAYMENT:"
        '
        'BANK_ACCOUNT_NUMBERLabel
        '
        BANK_ACCOUNT_NUMBERLabel.AutoSize = True
        BANK_ACCOUNT_NUMBERLabel.Location = New System.Drawing.Point(9, 334)
        BANK_ACCOUNT_NUMBERLabel.Name = "BANK_ACCOUNT_NUMBERLabel"
        BANK_ACCOUNT_NUMBERLabel.Size = New System.Drawing.Size(144, 13)
        BANK_ACCOUNT_NUMBERLabel.TabIndex = 27
        BANK_ACCOUNT_NUMBERLabel.Text = "BANK ACCOUNT NUMBER:"
        '
        'PAYMENT_TERMSLabel
        '
        PAYMENT_TERMSLabel.AutoSize = True
        PAYMENT_TERMSLabel.Location = New System.Drawing.Point(336, 334)
        PAYMENT_TERMSLabel.Name = "PAYMENT_TERMSLabel"
        PAYMENT_TERMSLabel.Size = New System.Drawing.Size(103, 13)
        PAYMENT_TERMSLabel.TabIndex = 29
        PAYMENT_TERMSLabel.Text = "PAYMENT TERMS:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 287)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(39, 13)
        Label3.TabIndex = 138
        Label3.Text = "BANK:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(527, 287)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(28, 13)
        Label5.TabIndex = 142
        Label5.Text = "DTI:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(524, 334)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(77, 13)
        Label6.TabIndex = 144
        Label6.Text = "VAT STATUS:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 54)
        Me.Panel1.TabIndex = 2
        '
        'userPic
        '
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
        Me.Label1.Size = New System.Drawing.Size(279, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW VENDOR"
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
        Me.txtVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorCode.Enabled = False
        Me.txtVendorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCode.Location = New System.Drawing.Point(12, 33)
        Me.txtVendorCode.Name = "txtVendorCode"
        Me.txtVendorCode.Size = New System.Drawing.Size(121, 26)
        Me.txtVendorCode.TabIndex = 4
        '
        'txtVendor
        '
        Me.txtVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(139, 33)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(382, 26)
        Me.txtVendor.TabIndex = 6
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(12, 123)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(182, 26)
        Me.txtContact.TabIndex = 8
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(200, 123)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(321, 26)
        Me.txtEmail.TabIndex = 10
        '
        'txtTIN
        '
        Me.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(12, 78)
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(335, 26)
        Me.txtTIN.TabIndex = 18
        '
        'txtSalesPerson
        '
        Me.txtSalesPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPerson.Location = New System.Drawing.Point(12, 168)
        Me.txtSalesPerson.Name = "txtSalesPerson"
        Me.txtSalesPerson.Size = New System.Drawing.Size(324, 26)
        Me.txtSalesPerson.TabIndex = 20
        '
        'cboBusinessType
        '
        Me.cboBusinessType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusinessType.FormattingEnabled = True
        Me.cboBusinessType.Items.AddRange(New Object() {"DIRECT SUPPLIER", "DISTRIBUTOR"})
        Me.cboBusinessType.Location = New System.Drawing.Point(342, 168)
        Me.cboBusinessType.Name = "cboBusinessType"
        Me.cboBusinessType.Size = New System.Drawing.Size(179, 26)
        Me.cboBusinessType.TabIndex = 22
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(12, 213)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(509, 26)
        Me.txtAddress.TabIndex = 24
        '
        'cboModeOfPayment
        '
        Me.cboModeOfPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfPayment.FormattingEnabled = True
        Me.cboModeOfPayment.Items.AddRange(New Object() {"BDO Unibank", "Bank of the Philippine Islands (BPI)", "Metrobank (Metropolitan Bank & Trust Company)", "Land Bank of the Philippines (LandBank)", "Philippine National Bank (PNB)", "Security Bank", "UnionBank of the Philippines", "China Banking Corporation (China Bank)", "Rizal Commercial Banking Corporation (RCBC)", "EastWest Bank", "Development Bank of the Philippines (DBP)", "Asia United Bank (AUB)", "Maybank Philippines", "Philippine Bank of Communications (PBCOM)", "Robinsons Bank", "Bank of Commerce", "CTBC Bank Philippines", "Standard Chartered Bank Philippines", "HSBC Philippines", "Citibank Philippines (mainly corporate)"})
        Me.cboModeOfPayment.Location = New System.Drawing.Point(12, 258)
        Me.cboModeOfPayment.Name = "cboModeOfPayment"
        Me.cboModeOfPayment.Size = New System.Drawing.Size(509, 26)
        Me.cboModeOfPayment.TabIndex = 26
        '
        'txtBankAccount
        '
        Me.txtBankAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccount.Location = New System.Drawing.Point(12, 350)
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.Size = New System.Drawing.Size(321, 26)
        Me.txtBankAccount.TabIndex = 28
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"7 Days", "15 Days", "30 Days", "45 Days", "60 Days", "120 Days"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(339, 350)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(182, 26)
        Me.cboPaymentTerms.TabIndex = 30
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(604, 473)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 37)
        Me.btnCancel.TabIndex = 135
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
        Me.btnSave.Location = New System.Drawing.Point(457, 473)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(141, 37)
        Me.btnSave.TabIndex = 133
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cboVatStatus)
        Me.Panel2.Controls.Add(Label6)
        Me.Panel2.Controls.Add(Label5)
        Me.Panel2.Controls.Add(Me.txtDTI)
        Me.Panel2.Controls.Add(Me.cboBank)
        Me.Panel2.Controls.Add(Label3)
        Me.Panel2.Controls.Add(Me.picLogo)
        Me.Panel2.Controls.Add(Me.cboPaymentTerms)
        Me.Panel2.Controls.Add(PAYMENT_TERMSLabel)
        Me.Panel2.Controls.Add(Me.txtBankAccount)
        Me.Panel2.Controls.Add(BANK_ACCOUNT_NUMBERLabel)
        Me.Panel2.Controls.Add(Me.cboModeOfPayment)
        Me.Panel2.Controls.Add(VENDOR_IDLabel)
        Me.Panel2.Controls.Add(MODE_OF_PAYMENTLabel)
        Me.Panel2.Controls.Add(Me.txtVendorCode)
        Me.Panel2.Controls.Add(Me.txtAddress)
        Me.Panel2.Controls.Add(VENDOR_NAMELabel)
        Me.Panel2.Controls.Add(ADDRESSLabel)
        Me.Panel2.Controls.Add(Me.txtVendor)
        Me.Panel2.Controls.Add(Me.cboBusinessType)
        Me.Panel2.Controls.Add(CONTACTLabel)
        Me.Panel2.Controls.Add(BUSINESS_TYPELabel)
        Me.Panel2.Controls.Add(Me.txtContact)
        Me.Panel2.Controls.Add(Me.txtSalesPerson)
        Me.Panel2.Controls.Add(EMAILLabel)
        Me.Panel2.Controls.Add(SALES_PERSONLabel)
        Me.Panel2.Controls.Add(Me.txtEmail)
        Me.Panel2.Controls.Add(Me.txtTIN)
        Me.Panel2.Controls.Add(TINLabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(757, 403)
        Me.Panel2.TabIndex = 136
        '
        'cboVatStatus
        '
        Me.cboVatStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVatStatus.FormattingEnabled = True
        Me.cboVatStatus.Items.AddRange(New Object() {"7 Days", "15 Days", "30 Days", "45 Days", "60 Days", "120 Days"})
        Me.cboVatStatus.Location = New System.Drawing.Point(527, 350)
        Me.cboVatStatus.Name = "cboVatStatus"
        Me.cboVatStatus.Size = New System.Drawing.Size(218, 26)
        Me.cboVatStatus.TabIndex = 145
        '
        'txtDTI
        '
        Me.txtDTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDTI.Location = New System.Drawing.Point(527, 303)
        Me.txtDTI.Name = "txtDTI"
        Me.txtDTI.Size = New System.Drawing.Size(218, 26)
        Me.txtDTI.TabIndex = 143
        Me.txtDTI.UseSystemPasswordChar = True
        '
        'cboBank
        '
        Me.cboBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Items.AddRange(New Object() {"BDO Unibank", "Bank of the Philippine Islands (BPI)", "Metrobank (Metropolitan Bank & Trust Company)", "Land Bank of the Philippines (LandBank)", "Philippine National Bank (PNB)", "Security Bank", "UnionBank of the Philippines", "China Banking Corporation (China Bank)", "Rizal Commercial Banking Corporation (RCBC)", "EastWest Bank", "Development Bank of the Philippines (DBP)", "Asia United Bank (AUB)", "Maybank Philippines", "Philippine Bank of Communications (PBCOM)", "Robinsons Bank", "Bank of Commerce", "CTBC Bank Philippines", "Standard Chartered Bank Philippines", "HSBC Philippines", "Citibank Philippines (mainly corporate)"})
        Me.cboBank.Location = New System.Drawing.Point(12, 303)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(509, 26)
        Me.cboBank.TabIndex = 139
        '
        'picLogo
        '
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(527, 33)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(121, 109)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 137
        Me.picLogo.TabStop = False
        '
        'ADD_Vendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 522)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ADD_Vendor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Vendor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents txtVendorCode As TextBox
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents txtSalesPerson As TextBox
    Friend WithEvents cboBusinessType As ComboBox
    Friend WithEvents cboModeOfPayment As ComboBox
    Friend WithEvents txtBankAccount As TextBox
    Friend WithEvents cboPaymentTerms As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtDTI As TextBox
    Friend WithEvents cboVatStatus As ComboBox
End Class
