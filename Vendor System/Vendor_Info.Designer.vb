<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Vendor_Info
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
        Dim Label6 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim PAYMENT_TERMSLabel As System.Windows.Forms.Label
        Dim BANK_ACCOUNT_NUMBERLabel As System.Windows.Forms.Label
        Dim VENDOR_IDLabel As System.Windows.Forms.Label
        Dim MODE_OF_PAYMENTLabel As System.Windows.Forms.Label
        Dim VENDOR_NAMELabel As System.Windows.Forms.Label
        Dim ADDRESSLabel As System.Windows.Forms.Label
        Dim CONTACTLabel As System.Windows.Forms.Label
        Dim BUSINESS_TYPELabel As System.Windows.Forms.Label
        Dim EMAILLabel As System.Windows.Forms.Label
        Dim SALES_PERSONLabel As System.Windows.Forms.Label
        Dim TINLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Vendor_Info))
        Me.cboVatStatus = New System.Windows.Forms.ComboBox()
        Me.txtDTI = New System.Windows.Forms.TextBox()
        Me.picVendor = New System.Windows.Forms.PictureBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox()
        Me.txtBankAccount = New System.Windows.Forms.TextBox()
        Me.cboModeOfPayment = New System.Windows.Forms.ComboBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.cboBusinessType = New System.Windows.Forms.ComboBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtSalesPerson = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.txtVendorCode = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSendToGmail = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSaveExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Label6 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        PAYMENT_TERMSLabel = New System.Windows.Forms.Label()
        BANK_ACCOUNT_NUMBERLabel = New System.Windows.Forms.Label()
        VENDOR_IDLabel = New System.Windows.Forms.Label()
        MODE_OF_PAYMENTLabel = New System.Windows.Forms.Label()
        VENDOR_NAMELabel = New System.Windows.Forms.Label()
        ADDRESSLabel = New System.Windows.Forms.Label()
        CONTACTLabel = New System.Windows.Forms.Label()
        BUSINESS_TYPELabel = New System.Windows.Forms.Label()
        EMAILLabel = New System.Windows.Forms.Label()
        SALES_PERSONLabel = New System.Windows.Forms.Label()
        TINLabel = New System.Windows.Forms.Label()
        CType(Me.picVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(1056, 217)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(77, 13)
        Label6.TabIndex = 144
        Label6.Text = "VAT STATUS:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(1059, 170)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(28, 13)
        Label5.TabIndex = 142
        Label5.Text = "DTI:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(541, 170)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(39, 13)
        Label3.TabIndex = 138
        Label3.Text = "BANK:"
        '
        'PAYMENT_TERMSLabel
        '
        PAYMENT_TERMSLabel.AutoSize = True
        PAYMENT_TERMSLabel.Location = New System.Drawing.Point(868, 217)
        PAYMENT_TERMSLabel.Name = "PAYMENT_TERMSLabel"
        PAYMENT_TERMSLabel.Size = New System.Drawing.Size(103, 13)
        PAYMENT_TERMSLabel.TabIndex = 29
        PAYMENT_TERMSLabel.Text = "PAYMENT TERMS:"
        '
        'BANK_ACCOUNT_NUMBERLabel
        '
        BANK_ACCOUNT_NUMBERLabel.AutoSize = True
        BANK_ACCOUNT_NUMBERLabel.Location = New System.Drawing.Point(541, 217)
        BANK_ACCOUNT_NUMBERLabel.Name = "BANK_ACCOUNT_NUMBERLabel"
        BANK_ACCOUNT_NUMBERLabel.Size = New System.Drawing.Size(144, 13)
        BANK_ACCOUNT_NUMBERLabel.TabIndex = 27
        BANK_ACCOUNT_NUMBERLabel.Text = "BANK ACCOUNT NUMBER:"
        '
        'VENDOR_IDLabel
        '
        VENDOR_IDLabel.AutoSize = True
        VENDOR_IDLabel.Location = New System.Drawing.Point(15, 72)
        VENDOR_IDLabel.Name = "VENDOR_IDLabel"
        VENDOR_IDLabel.Size = New System.Drawing.Size(89, 13)
        VENDOR_IDLabel.TabIndex = 3
        VENDOR_IDLabel.Text = "VENDOR CODE:"
        '
        'MODE_OF_PAYMENTLabel
        '
        MODE_OF_PAYMENTLabel.AutoSize = True
        MODE_OF_PAYMENTLabel.Location = New System.Drawing.Point(541, 125)
        MODE_OF_PAYMENTLabel.Name = "MODE_OF_PAYMENTLabel"
        MODE_OF_PAYMENTLabel.Size = New System.Drawing.Size(114, 13)
        MODE_OF_PAYMENTLabel.TabIndex = 25
        MODE_OF_PAYMENTLabel.Text = "MODE OF PAYMENT:"
        '
        'VENDOR_NAMELabel
        '
        VENDOR_NAMELabel.AutoSize = True
        VENDOR_NAMELabel.Location = New System.Drawing.Point(139, 72)
        VENDOR_NAMELabel.Name = "VENDOR_NAMELabel"
        VENDOR_NAMELabel.Size = New System.Drawing.Size(56, 13)
        VENDOR_NAMELabel.TabIndex = 5
        VENDOR_NAMELabel.Text = "VENDOR:"
        '
        'ADDRESSLabel
        '
        ADDRESSLabel.AutoSize = True
        ADDRESSLabel.Location = New System.Drawing.Point(541, 80)
        ADDRESSLabel.Name = "ADDRESSLabel"
        ADDRESSLabel.Size = New System.Drawing.Size(62, 13)
        ADDRESSLabel.TabIndex = 23
        ADDRESSLabel.Text = "ADDRESS:"
        '
        'CONTACTLabel
        '
        CONTACTLabel.AutoSize = True
        CONTACTLabel.Location = New System.Drawing.Point(15, 162)
        CONTACTLabel.Name = "CONTACTLabel"
        CONTACTLabel.Size = New System.Drawing.Size(61, 13)
        CONTACTLabel.TabIndex = 7
        CONTACTLabel.Text = "CONTACT:"
        '
        'BUSINESS_TYPELabel
        '
        BUSINESS_TYPELabel.AutoSize = True
        BUSINESS_TYPELabel.Location = New System.Drawing.Point(345, 212)
        BUSINESS_TYPELabel.Name = "BUSINESS_TYPELabel"
        BUSINESS_TYPELabel.Size = New System.Drawing.Size(95, 13)
        BUSINESS_TYPELabel.TabIndex = 21
        BUSINESS_TYPELabel.Text = "BUSINESS TYPE:"
        '
        'EMAILLabel
        '
        EMAILLabel.AutoSize = True
        EMAILLabel.Location = New System.Drawing.Point(200, 162)
        EMAILLabel.Name = "EMAILLabel"
        EMAILLabel.Size = New System.Drawing.Size(42, 13)
        EMAILLabel.TabIndex = 9
        EMAILLabel.Text = "EMAIL:"
        '
        'SALES_PERSONLabel
        '
        SALES_PERSONLabel.AutoSize = True
        SALES_PERSONLabel.Location = New System.Drawing.Point(15, 212)
        SALES_PERSONLabel.Name = "SALES_PERSONLabel"
        SALES_PERSONLabel.Size = New System.Drawing.Size(92, 13)
        SALES_PERSONLabel.TabIndex = 19
        SALES_PERSONLabel.Text = "SALES PERSON:"
        '
        'TINLabel
        '
        TINLabel.AutoSize = True
        TINLabel.Location = New System.Drawing.Point(15, 117)
        TINLabel.Name = "TINLabel"
        TINLabel.Size = New System.Drawing.Size(28, 13)
        TINLabel.TabIndex = 17
        TINLabel.Text = "TIN:"
        '
        'cboVatStatus
        '
        Me.cboVatStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVatStatus.FormattingEnabled = True
        Me.cboVatStatus.Items.AddRange(New Object() {"7 Days", "15 Days", "30 Days", "45 Days", "60 Days", "120 Days"})
        Me.cboVatStatus.Location = New System.Drawing.Point(1059, 233)
        Me.cboVatStatus.Name = "cboVatStatus"
        Me.cboVatStatus.Size = New System.Drawing.Size(218, 26)
        Me.cboVatStatus.TabIndex = 145
        '
        'txtDTI
        '
        Me.txtDTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDTI.Location = New System.Drawing.Point(1059, 186)
        Me.txtDTI.Name = "txtDTI"
        Me.txtDTI.Size = New System.Drawing.Size(218, 26)
        Me.txtDTI.TabIndex = 143
        Me.txtDTI.UseSystemPasswordChar = True
        '
        'picVendor
        '
        Me.picVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picVendor.Image = CType(resources.GetObject("picVendor.Image"), System.Drawing.Image)
        Me.picVendor.Location = New System.Drawing.Point(1217, 60)
        Me.picVendor.Name = "picVendor"
        Me.picVendor.Size = New System.Drawing.Size(121, 109)
        Me.picVendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picVendor.TabIndex = 137
        Me.picVendor.TabStop = False
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
        Me.Label1.Size = New System.Drawing.Size(211, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VENDOR INFO"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"7 Days", "15 Days", "30 Days", "45 Days", "60 Days", "120 Days"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(871, 233)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(182, 26)
        Me.cboPaymentTerms.TabIndex = 30
        '
        'txtBankAccount
        '
        Me.txtBankAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccount.Location = New System.Drawing.Point(544, 233)
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.Size = New System.Drawing.Size(321, 26)
        Me.txtBankAccount.TabIndex = 28
        '
        'cboModeOfPayment
        '
        Me.cboModeOfPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfPayment.FormattingEnabled = True
        Me.cboModeOfPayment.Items.AddRange(New Object() {"BDO Unibank", "Bank of the Philippine Islands (BPI)", "Metrobank (Metropolitan Bank & Trust Company)", "Land Bank of the Philippines (LandBank)", "Philippine National Bank (PNB)", "Security Bank", "UnionBank of the Philippines", "China Banking Corporation (China Bank)", "Rizal Commercial Banking Corporation (RCBC)", "EastWest Bank", "Development Bank of the Philippines (DBP)", "Asia United Bank (AUB)", "Maybank Philippines", "Philippine Bank of Communications (PBCOM)", "Robinsons Bank", "Bank of Commerce", "CTBC Bank Philippines", "Standard Chartered Bank Philippines", "HSBC Philippines", "Citibank Philippines (mainly corporate)"})
        Me.cboModeOfPayment.Location = New System.Drawing.Point(544, 141)
        Me.cboModeOfPayment.Name = "cboModeOfPayment"
        Me.cboModeOfPayment.Size = New System.Drawing.Size(509, 26)
        Me.cboModeOfPayment.TabIndex = 26
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Maroon
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(464, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(141, 37)
        Me.btnUpdate.TabIndex = 138
        Me.btnUpdate.Text = " Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(544, 96)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(509, 26)
        Me.txtAddress.TabIndex = 24
        '
        'cboBusinessType
        '
        Me.cboBusinessType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusinessType.FormattingEnabled = True
        Me.cboBusinessType.Items.AddRange(New Object() {"DIRECT SUPPLIER", "DISTRIBUTOR"})
        Me.cboBusinessType.Location = New System.Drawing.Point(348, 228)
        Me.cboBusinessType.Name = "cboBusinessType"
        Me.cboBusinessType.Size = New System.Drawing.Size(179, 26)
        Me.cboBusinessType.TabIndex = 22
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(15, 178)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(182, 26)
        Me.txtContact.TabIndex = 8
        '
        'txtSalesPerson
        '
        Me.txtSalesPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPerson.Location = New System.Drawing.Point(18, 228)
        Me.txtSalesPerson.Name = "txtSalesPerson"
        Me.txtSalesPerson.Size = New System.Drawing.Size(324, 26)
        Me.txtSalesPerson.TabIndex = 20
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(203, 178)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(321, 26)
        Me.txtEmail.TabIndex = 10
        '
        'txtTIN
        '
        Me.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(15, 133)
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(335, 26)
        Me.txtTIN.TabIndex = 18
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1175, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 37)
        Me.btnCancel.TabIndex = 139
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'cboBank
        '
        Me.cboBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Items.AddRange(New Object() {"BDO Unibank", "Bank of the Philippine Islands (BPI)", "Metrobank (Metropolitan Bank & Trust Company)", "Land Bank of the Philippines (LandBank)", "Philippine National Bank (PNB)", "Security Bank", "UnionBank of the Philippines", "China Banking Corporation (China Bank)", "Rizal Commercial Banking Corporation (RCBC)", "EastWest Bank", "Development Bank of the Philippines (DBP)", "Asia United Bank (AUB)", "Maybank Philippines", "Philippine Bank of Communications (PBCOM)", "Robinsons Bank", "Bank of Commerce", "CTBC Bank Philippines", "Standard Chartered Bank Philippines", "HSBC Philippines", "Citibank Philippines (mainly corporate)"})
        Me.cboBank.Location = New System.Drawing.Point(544, 186)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(509, 26)
        Me.cboBank.TabIndex = 139
        '
        'txtVendorCode
        '
        Me.txtVendorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorCode.Enabled = False
        Me.txtVendorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorCode.Location = New System.Drawing.Point(15, 88)
        Me.txtVendorCode.Name = "txtVendorCode"
        Me.txtVendorCode.Size = New System.Drawing.Size(121, 26)
        Me.txtVendorCode.TabIndex = 4
        '
        'txtVendor
        '
        Me.txtVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(142, 88)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(382, 26)
        Me.txtVendor.TabIndex = 6
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.userPic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1350, 54)
        Me.Panel1.TabIndex = 137
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Maroon
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(611, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(135, 37)
        Me.btnDelete.TabIndex = 223
        Me.btnDelete.Text = " Delete Vendor"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnSendToGmail)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnSaveExcel)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Location = New System.Drawing.Point(12, 669)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1326, 48)
        Me.Panel2.TabIndex = 326
        '
        'btnSendToGmail
        '
        Me.btnSendToGmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendToGmail.BackColor = System.Drawing.Color.Maroon
        Me.btnSendToGmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSendToGmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendToGmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendToGmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSendToGmail.Image = CType(resources.GetObject("btnSendToGmail.Image"), System.Drawing.Image)
        Me.btnSendToGmail.Location = New System.Drawing.Point(1034, 6)
        Me.btnSendToGmail.Name = "btnSendToGmail"
        Me.btnSendToGmail.Size = New System.Drawing.Size(135, 37)
        Me.btnSendToGmail.TabIndex = 225
        Me.btnSendToGmail.Text = " Send to Gmail"
        Me.btnSendToGmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSendToGmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSendToGmail.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.Maroon
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(893, 6)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(135, 37)
        Me.btnPrint.TabIndex = 224
        Me.btnPrint.Text = " Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnSaveExcel
        '
        Me.btnSaveExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveExcel.BackColor = System.Drawing.Color.Maroon
        Me.btnSaveExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveExcel.Image = CType(resources.GetObject("btnSaveExcel.Image"), System.Drawing.Image)
        Me.btnSaveExcel.Location = New System.Drawing.Point(752, 6)
        Me.btnSaveExcel.Name = "btnSaveExcel"
        Me.btnSaveExcel.Size = New System.Drawing.Size(135, 37)
        Me.btnSaveExcel.TabIndex = 214
        Me.btnSaveExcel.Text = " Save to Excel"
        Me.btnSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveExcel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Maroon
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(323, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 37)
        Me.btnRefresh.TabIndex = 211
        Me.btnRefresh.Text = " Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(10, 10)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(308, 26)
        Me.txtSearch.TabIndex = 212
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Location = New System.Drawing.Point(12, 265)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(1325, 398)
        Me.dgvProducts.TabIndex = 327
        '
        'Vendor_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cboVatStatus)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtDTI)
        Me.Controls.Add(Me.cboBank)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtBankAccount)
        Me.Controls.Add(Me.picVendor)
        Me.Controls.Add(TINLabel)
        Me.Controls.Add(Me.cboPaymentTerms)
        Me.Controls.Add(Me.txtTIN)
        Me.Controls.Add(PAYMENT_TERMSLabel)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(SALES_PERSONLabel)
        Me.Controls.Add(BANK_ACCOUNT_NUMBERLabel)
        Me.Controls.Add(EMAILLabel)
        Me.Controls.Add(Me.cboModeOfPayment)
        Me.Controls.Add(Me.txtSalesPerson)
        Me.Controls.Add(VENDOR_IDLabel)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(MODE_OF_PAYMENTLabel)
        Me.Controls.Add(BUSINESS_TYPELabel)
        Me.Controls.Add(Me.txtVendorCode)
        Me.Controls.Add(CONTACTLabel)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.cboBusinessType)
        Me.Controls.Add(VENDOR_NAMELabel)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(ADDRESSLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Vendor_Info"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor_Info"
        CType(Me.picVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboVatStatus As ComboBox
    Friend WithEvents txtDTI As TextBox
    Friend WithEvents picVendor As PictureBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPaymentTerms As ComboBox
    Friend WithEvents txtBankAccount As TextBox
    Friend WithEvents cboModeOfPayment As ComboBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents cboBusinessType As ComboBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtSalesPerson As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents txtVendorCode As TextBox
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSaveExcel As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnSendToGmail As Button
End Class
