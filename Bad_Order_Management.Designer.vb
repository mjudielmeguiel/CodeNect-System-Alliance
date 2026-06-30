<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Bad_Order_Management
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
        Me.components = New System.ComponentModel.Container()
        Dim TRANSACTION_IDLabel As System.Windows.Forms.Label
        Dim TOTALLabel As System.Windows.Forms.Label
        Dim TRANSACTION_IDLabel2 As System.Windows.Forms.Label
        Dim BARCODE_EAN_UPC_Label As System.Windows.Forms.Label
        Dim SKULabel As System.Windows.Forms.Label
        Dim DESCRIPTIONSLabel As System.Windows.Forms.Label
        Dim BRANDLabel As System.Windows.Forms.Label
        Dim CATEGORYLabel As System.Windows.Forms.Label
        Dim SIZELabel As System.Windows.Forms.Label
        Dim STOCK_AVAILABLELabel As System.Windows.Forms.Label
        Dim QUANTITYLabel As System.Windows.Forms.Label
        Dim PRICELabel As System.Windows.Forms.Label
        Dim VENDOR_CODELabel As System.Windows.Forms.Label
        Dim VENDORLabel As System.Windows.Forms.Label
        Dim TOTALLabel1 As System.Windows.Forms.Label
        Dim REASONLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bad_Order_Management))
        Dim Label2 As System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.USERTextBox = New System.Windows.Forms.TextBox()
        Me.Bad_Order_ReportsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CODENECTDataSet = New CodeNect_System_Alliance.CODENECTDataSet()
        Me.VENDORComboBox = New System.Windows.Forms.ComboBox()
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TRANSACTION_IDTextBox = New System.Windows.Forms.TextBox()
        Me.Bad_OrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENDOR_CODETextBox = New System.Windows.Forms.TextBox()
        Me.PREPAREDDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TOTALTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TRANSACTION_IDLabel1 = New System.Windows.Forms.Label()
        Me.BRANCHLabel1 = New System.Windows.Forms.Label()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.MEMOLabel1 = New System.Windows.Forms.Label()
        Me.STATUSLabel1 = New System.Windows.Forms.Label()
        Me.Bad_Order_ReportsTableAdapter = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.Bad_Order_ReportsTableAdapter()
        Me.TableAdapterManager = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager()
        Me.Bad_OrderTableAdapter = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.Bad_OrderTableAdapter()
        Me.VendorTableAdapter = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.VendorTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.REASONComboBox = New System.Windows.Forms.ComboBox()
        Me.BARCODE_EAN_UPC_TextBox = New System.Windows.Forms.TextBox()
        Me.SKUTextBox = New System.Windows.Forms.TextBox()
        Me.SIZETextBox = New System.Windows.Forms.TextBox()
        Me.DESCRIPTIONSTextBox = New System.Windows.Forms.TextBox()
        Me.BRANDTextBox = New System.Windows.Forms.TextBox()
        Me.CATEGORYTextBox = New System.Windows.Forms.TextBox()
        Me.STOCK_AVAILABLETextBox = New System.Windows.Forms.TextBox()
        Me.QUANTITYTextBox = New System.Windows.Forms.TextBox()
        Me.PRICETextBox = New System.Windows.Forms.TextBox()
        Me.VENDORTextBox = New System.Windows.Forms.TextBox()
        Me.TOTALTextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        TRANSACTION_IDLabel = New System.Windows.Forms.Label()
        TOTALLabel = New System.Windows.Forms.Label()
        TRANSACTION_IDLabel2 = New System.Windows.Forms.Label()
        BARCODE_EAN_UPC_Label = New System.Windows.Forms.Label()
        SKULabel = New System.Windows.Forms.Label()
        DESCRIPTIONSLabel = New System.Windows.Forms.Label()
        BRANDLabel = New System.Windows.Forms.Label()
        CATEGORYLabel = New System.Windows.Forms.Label()
        SIZELabel = New System.Windows.Forms.Label()
        STOCK_AVAILABLELabel = New System.Windows.Forms.Label()
        QUANTITYLabel = New System.Windows.Forms.Label()
        PRICELabel = New System.Windows.Forms.Label()
        VENDOR_CODELabel = New System.Windows.Forms.Label()
        VENDORLabel = New System.Windows.Forms.Label()
        TOTALLabel1 = New System.Windows.Forms.Label()
        REASONLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Bad_Order_ReportsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bad_OrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TRANSACTION_IDLabel
        '
        TRANSACTION_IDLabel.AutoSize = True
        TRANSACTION_IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TRANSACTION_IDLabel.ForeColor = System.Drawing.SystemColors.Control
        TRANSACTION_IDLabel.Location = New System.Drawing.Point(471, 9)
        TRANSACTION_IDLabel.Name = "TRANSACTION_IDLabel"
        TRANSACTION_IDLabel.Size = New System.Drawing.Size(116, 13)
        TRANSACTION_IDLabel.TabIndex = 3
        TRANSACTION_IDLabel.Text = "TRANSACTION ID:"
        '
        'TOTALLabel
        '
        TOTALLabel.AutoSize = True
        TOTALLabel.Location = New System.Drawing.Point(173, 18)
        TOTALLabel.Name = "TOTALLabel"
        TOTALLabel.Size = New System.Drawing.Size(94, 13)
        TOTALLabel.TabIndex = 17
        TOTALLabel.Text = "TOTAL DAMAGE:"
        '
        'TRANSACTION_IDLabel2
        '
        TRANSACTION_IDLabel2.AutoSize = True
        TRANSACTION_IDLabel2.Location = New System.Drawing.Point(4, 19)
        TRANSACTION_IDLabel2.Name = "TRANSACTION_IDLabel2"
        TRANSACTION_IDLabel2.Size = New System.Drawing.Size(101, 13)
        TRANSACTION_IDLabel2.TabIndex = 2
        TRANSACTION_IDLabel2.Text = "TRANSACTION ID:"
        '
        'BARCODE_EAN_UPC_Label
        '
        BARCODE_EAN_UPC_Label.AutoSize = True
        BARCODE_EAN_UPC_Label.Location = New System.Drawing.Point(4, 27)
        BARCODE_EAN_UPC_Label.Name = "BARCODE_EAN_UPC_Label"
        BARCODE_EAN_UPC_Label.Size = New System.Drawing.Size(117, 13)
        BARCODE_EAN_UPC_Label.TabIndex = 4
        BARCODE_EAN_UPC_Label.Text = "BARCODE(EAN/UPC):"
        '
        'SKULabel
        '
        SKULabel.AutoSize = True
        SKULabel.Location = New System.Drawing.Point(272, 27)
        SKULabel.Name = "SKULabel"
        SKULabel.Size = New System.Drawing.Size(32, 13)
        SKULabel.TabIndex = 6
        SKULabel.Text = "SKU:"
        '
        'DESCRIPTIONSLabel
        '
        DESCRIPTIONSLabel.AutoSize = True
        DESCRIPTIONSLabel.Location = New System.Drawing.Point(4, 73)
        DESCRIPTIONSLabel.Name = "DESCRIPTIONSLabel"
        DESCRIPTIONSLabel.Size = New System.Drawing.Size(90, 13)
        DESCRIPTIONSLabel.TabIndex = 8
        DESCRIPTIONSLabel.Text = "DESCRIPTIONS:"
        '
        'BRANDLabel
        '
        BRANDLabel.AutoSize = True
        BRANDLabel.Location = New System.Drawing.Point(4, 120)
        BRANDLabel.Name = "BRANDLabel"
        BRANDLabel.Size = New System.Drawing.Size(48, 13)
        BRANDLabel.TabIndex = 10
        BRANDLabel.Text = "BRAND:"
        '
        'CATEGORYLabel
        '
        CATEGORYLabel.AutoSize = True
        CATEGORYLabel.Location = New System.Drawing.Point(282, 120)
        CATEGORYLabel.Name = "CATEGORYLabel"
        CATEGORYLabel.Size = New System.Drawing.Size(69, 13)
        CATEGORYLabel.TabIndex = 12
        CATEGORYLabel.Text = "CATEGORY:"
        '
        'SIZELabel
        '
        SIZELabel.AutoSize = True
        SIZELabel.Location = New System.Drawing.Point(217, 167)
        SIZELabel.Name = "SIZELabel"
        SIZELabel.Size = New System.Drawing.Size(34, 13)
        SIZELabel.TabIndex = 14
        SIZELabel.Text = "SIZE:"
        '
        'STOCK_AVAILABLELabel
        '
        STOCK_AVAILABLELabel.AutoSize = True
        STOCK_AVAILABLELabel.Location = New System.Drawing.Point(353, 167)
        STOCK_AVAILABLELabel.Name = "STOCK_AVAILABLELabel"
        STOCK_AVAILABLELabel.Size = New System.Drawing.Size(106, 13)
        STOCK_AVAILABLELabel.TabIndex = 16
        STOCK_AVAILABLELabel.Text = "STOCK AVAILABLE:"
        '
        'QUANTITYLabel
        '
        QUANTITYLabel.AutoSize = True
        QUANTITYLabel.Location = New System.Drawing.Point(4, 268)
        QUANTITYLabel.Name = "QUANTITYLabel"
        QUANTITYLabel.Size = New System.Drawing.Size(65, 13)
        QUANTITYLabel.TabIndex = 18
        QUANTITYLabel.Text = "QUANTITY:"
        '
        'PRICELabel
        '
        PRICELabel.AutoSize = True
        PRICELabel.Location = New System.Drawing.Point(4, 167)
        PRICELabel.Name = "PRICELabel"
        PRICELabel.Size = New System.Drawing.Size(42, 13)
        PRICELabel.TabIndex = 20
        PRICELabel.Text = "PRICE:"
        '
        'VENDOR_CODELabel
        '
        VENDOR_CODELabel.AutoSize = True
        VENDOR_CODELabel.Location = New System.Drawing.Point(370, 108)
        VENDOR_CODELabel.Name = "VENDOR_CODELabel"
        VENDOR_CODELabel.Size = New System.Drawing.Size(89, 13)
        VENDOR_CODELabel.TabIndex = 24
        VENDOR_CODELabel.Text = "VENDOR CODE:"
        '
        'VENDORLabel
        '
        VENDORLabel.AutoSize = True
        VENDORLabel.Location = New System.Drawing.Point(4, 218)
        VENDORLabel.Name = "VENDORLabel"
        VENDORLabel.Size = New System.Drawing.Size(56, 13)
        VENDORLabel.TabIndex = 26
        VENDORLabel.Text = "VENDOR:"
        '
        'TOTALLabel1
        '
        TOTALLabel1.AutoSize = True
        TOTALLabel1.Location = New System.Drawing.Point(414, 18)
        TOTALLabel1.Name = "TOTALLabel1"
        TOTALLabel1.Size = New System.Drawing.Size(45, 13)
        TOTALLabel1.TabIndex = 28
        TOTALLabel1.Text = "TOTAL:"
        '
        'REASONLabel
        '
        REASONLabel.AutoSize = True
        REASONLabel.Location = New System.Drawing.Point(221, 269)
        REASONLabel.Name = "REASONLabel"
        REASONLabel.Size = New System.Drawing.Size(55, 13)
        REASONLabel.TabIndex = 29
        REASONLabel.Text = "REASON:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(4, 108)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(56, 13)
        Label1.TabIndex = 31
        Label1.Text = "VENDOR:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Label2)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(Me.USERTextBox)
        Me.Panel1.Controls.Add(Me.VENDORComboBox)
        Me.Panel1.Controls.Add(Me.TRANSACTION_IDTextBox)
        Me.Panel1.Controls.Add(TRANSACTION_IDLabel2)
        Me.Panel1.Controls.Add(Me.VENDOR_CODETextBox)
        Me.Panel1.Controls.Add(VENDOR_CODELabel)
        Me.Panel1.Controls.Add(Me.PREPAREDDateTimePicker)
        Me.Panel1.Location = New System.Drawing.Point(12, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 137)
        Me.Panel1.TabIndex = 0
        '
        'USERTextBox
        '
        Me.USERTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.USERTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "USER", True))
        Me.USERTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.USERTextBox.Location = New System.Drawing.Point(332, 56)
        Me.USERTextBox.Name = "USERTextBox"
        Me.USERTextBox.Size = New System.Drawing.Size(232, 26)
        Me.USERTextBox.TabIndex = 10
        '
        'Bad_Order_ReportsBindingSource
        '
        Me.Bad_Order_ReportsBindingSource.DataMember = "Bad_Order_Reports"
        Me.Bad_Order_ReportsBindingSource.DataSource = Me.CODENECTDataSet
        '
        'CODENECTDataSet
        '
        Me.CODENECTDataSet.DataSetName = "CODENECTDataSet"
        Me.CODENECTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VENDORComboBox
        '
        Me.VENDORComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "VENDOR", True))
        Me.VENDORComboBox.DataSource = Me.VendorBindingSource
        Me.VENDORComboBox.DisplayMember = "VENDOR NAME"
        Me.VENDORComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VENDORComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VENDORComboBox.FormattingEnabled = True
        Me.VENDORComboBox.Location = New System.Drawing.Point(66, 101)
        Me.VENDORComboBox.Name = "VENDORComboBox"
        Me.VENDORComboBox.Size = New System.Drawing.Size(298, 26)
        Me.VENDORComboBox.TabIndex = 19
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.CODENECTDataSet
        '
        'TRANSACTION_IDTextBox
        '
        Me.TRANSACTION_IDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TRANSACTION_IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "TRANSACTION_ID", True))
        Me.TRANSACTION_IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRANSACTION_IDTextBox.Location = New System.Drawing.Point(111, 12)
        Me.TRANSACTION_IDTextBox.Name = "TRANSACTION_IDTextBox"
        Me.TRANSACTION_IDTextBox.Size = New System.Drawing.Size(158, 26)
        Me.TRANSACTION_IDTextBox.TabIndex = 3
        '
        'Bad_OrderBindingSource
        '
        Me.Bad_OrderBindingSource.DataMember = "Bad_Order"
        Me.Bad_OrderBindingSource.DataSource = Me.CODENECTDataSet
        '
        'VENDOR_CODETextBox
        '
        Me.VENDOR_CODETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VENDOR_CODETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "VENDOR_CODE", True))
        Me.VENDOR_CODETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VENDOR_CODETextBox.Location = New System.Drawing.Point(465, 101)
        Me.VENDOR_CODETextBox.Name = "VENDOR_CODETextBox"
        Me.VENDOR_CODETextBox.Size = New System.Drawing.Size(99, 26)
        Me.VENDOR_CODETextBox.TabIndex = 25
        '
        'PREPAREDDateTimePicker
        '
        Me.PREPAREDDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.Bad_Order_ReportsBindingSource, "PREPARED", True))
        Me.PREPAREDDateTimePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PREPAREDDateTimePicker.Location = New System.Drawing.Point(275, 12)
        Me.PREPAREDDateTimePicker.Name = "PREPAREDDateTimePicker"
        Me.PREPAREDDateTimePicker.Size = New System.Drawing.Size(289, 26)
        Me.PREPAREDDateTimePicker.TabIndex = 12
        '
        'TOTALTextBox
        '
        Me.TOTALTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOTALTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "TOTAL", True))
        Me.TOTALTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOTALTextBox.Location = New System.Drawing.Point(273, 11)
        Me.TOTALTextBox.Name = "TOTALTextBox"
        Me.TOTALTextBox.Size = New System.Drawing.Size(135, 26)
        Me.TOTALTextBox.TabIndex = 18
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.TRANSACTION_IDLabel1)
        Me.Panel2.Controls.Add(Me.BRANCHLabel1)
        Me.Panel2.Controls.Add(TRANSACTION_IDLabel)
        Me.Panel2.Controls.Add(Me.userPic)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Controls.Add(Me.MEMOLabel1)
        Me.Panel2.Controls.Add(Me.STATUSLabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(599, 54)
        Me.Panel2.TabIndex = 2
        '
        'TRANSACTION_IDLabel1
        '
        Me.TRANSACTION_IDLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "TRANSACTION_ID", True))
        Me.TRANSACTION_IDLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRANSACTION_IDLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.TRANSACTION_IDLabel1.Location = New System.Drawing.Point(474, 22)
        Me.TRANSACTION_IDLabel1.Name = "TRANSACTION_IDLabel1"
        Me.TRANSACTION_IDLabel1.Size = New System.Drawing.Size(113, 23)
        Me.TRANSACTION_IDLabel1.TabIndex = 4
        Me.TRANSACTION_IDLabel1.Text = "-------"
        Me.TRANSACTION_IDLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BRANCHLabel1
        '
        Me.BRANCHLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "BRANCH", True))
        Me.BRANCHLabel1.Location = New System.Drawing.Point(282, 9)
        Me.BRANCHLabel1.Name = "BRANCHLabel1"
        Me.BRANCHLabel1.Size = New System.Drawing.Size(234, 23)
        Me.BRANCHLabel1.TabIndex = 13
        Me.BRANCHLabel1.Text = "--------------------------------------"
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
        'MEMOLabel1
        '
        Me.MEMOLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "MEMO", True))
        Me.MEMOLabel1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEMOLabel1.ForeColor = System.Drawing.SystemColors.Control
        Me.MEMOLabel1.Location = New System.Drawing.Point(79, 9)
        Me.MEMOLabel1.Name = "MEMOLabel1"
        Me.MEMOLabel1.Size = New System.Drawing.Size(197, 36)
        Me.MEMOLabel1.TabIndex = 14
        Me.MEMOLabel1.Text = "BAD ORDER"
        '
        'STATUSLabel1
        '
        Me.STATUSLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_Order_ReportsBindingSource, "STATUS", True))
        Me.STATUSLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STATUSLabel1.Location = New System.Drawing.Point(282, 31)
        Me.STATUSLabel1.Name = "STATUSLabel1"
        Me.STATUSLabel1.Size = New System.Drawing.Size(151, 23)
        Me.STATUSLabel1.TabIndex = 16
        Me.STATUSLabel1.Text = "-------------------------"
        Me.STATUSLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bad_Order_ReportsTableAdapter
        '
        Me.Bad_Order_ReportsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.Account_RecoverTableAdapter = Nothing
        Me.TableAdapterManager.AccountTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Bad_Order_ReportsTableAdapter = Me.Bad_Order_ReportsTableAdapter
        Me.TableAdapterManager.Bad_OrderTableAdapter = Me.Bad_OrderTableAdapter
        Me.TableAdapterManager.BranchesTableAdapter = Nothing
        Me.TableAdapterManager.CategoryTableAdapter = Nothing
        Me.TableAdapterManager.DescriptionsTableAdapter = Nothing
        Me.TableAdapterManager.Login_HistoryTableAdapter = Nothing
        Me.TableAdapterManager.PCInfoTableAdapter = Nothing
        Me.TableAdapterManager.PcountTableAdapter = Nothing
        Me.TableAdapterManager.ReportsTableAdapter = Nothing
        Me.TableAdapterManager.Sotex_ReportsTableAdapter = Nothing
        Me.TableAdapterManager.SotexTableAdapter = Nothing
        Me.TableAdapterManager.Stock_OrderingTableAdapter = Nothing
        Me.TableAdapterManager.StoTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableAdapter = Nothing
        Me.TableAdapterManager.Vendor_ProductsTableAdapter = Nothing
        Me.TableAdapterManager.VendorTableAdapter = Me.VendorTableAdapter
        '
        'Bad_OrderTableAdapter
        '
        Me.Bad_OrderTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(7, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 37)
        Me.Button1.TabIndex = 242
        Me.Button1.Text = " ADD"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(430, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(135, 37)
        Me.Button5.TabIndex = 246
        Me.Button5.Text = "Cancel"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.Maroon
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.Location = New System.Drawing.Point(148, 7)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(135, 37)
        Me.ButtonSave.TabIndex = 245
        Me.ButtonSave.Text = " Save"
        Me.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Maroon
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(289, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 37)
        Me.Button2.TabIndex = 244
        Me.Button2.Text = " Remove"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.ButtonSave)
        Me.Panel3.Location = New System.Drawing.Point(12, 569)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(575, 51)
        Me.Panel3.TabIndex = 247
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(REASONLabel)
        Me.Panel4.Controls.Add(Me.REASONComboBox)
        Me.Panel4.Controls.Add(BARCODE_EAN_UPC_Label)
        Me.Panel4.Controls.Add(Me.BARCODE_EAN_UPC_TextBox)
        Me.Panel4.Controls.Add(SKULabel)
        Me.Panel4.Controls.Add(Me.SKUTextBox)
        Me.Panel4.Controls.Add(Me.SIZETextBox)
        Me.Panel4.Controls.Add(SIZELabel)
        Me.Panel4.Controls.Add(DESCRIPTIONSLabel)
        Me.Panel4.Controls.Add(Me.DESCRIPTIONSTextBox)
        Me.Panel4.Controls.Add(BRANDLabel)
        Me.Panel4.Controls.Add(Me.BRANDTextBox)
        Me.Panel4.Controls.Add(CATEGORYLabel)
        Me.Panel4.Controls.Add(Me.CATEGORYTextBox)
        Me.Panel4.Controls.Add(STOCK_AVAILABLELabel)
        Me.Panel4.Controls.Add(Me.STOCK_AVAILABLETextBox)
        Me.Panel4.Controls.Add(QUANTITYLabel)
        Me.Panel4.Controls.Add(Me.QUANTITYTextBox)
        Me.Panel4.Controls.Add(PRICELabel)
        Me.Panel4.Controls.Add(Me.PRICETextBox)
        Me.Panel4.Controls.Add(VENDORLabel)
        Me.Panel4.Controls.Add(Me.VENDORTextBox)
        Me.Panel4.Location = New System.Drawing.Point(12, 203)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(575, 307)
        Me.Panel4.TabIndex = 248
        '
        'REASONComboBox
        '
        Me.REASONComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "REASON", True))
        Me.REASONComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.REASONComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.REASONComboBox.FormattingEnabled = True
        Me.REASONComboBox.Items.AddRange(New Object() {"", "Expired or Near-Expired Items", "Damaged Packaging", "Spoiled or Contaminated Products", "Defective Products", "Product Recall", "Pest Infestation", "Wrong Handling", "Overstock / Slow-Moving Items", "Price / Barcode Issues", "Customer Returns"})
        Me.REASONComboBox.Location = New System.Drawing.Point(282, 261)
        Me.REASONComboBox.Name = "REASONComboBox"
        Me.REASONComboBox.Size = New System.Drawing.Size(282, 28)
        Me.REASONComboBox.TabIndex = 30
        '
        'BARCODE_EAN_UPC_TextBox
        '
        Me.BARCODE_EAN_UPC_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BARCODE_EAN_UPC_TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "BARCODE(EAN/UPC)", True))
        Me.BARCODE_EAN_UPC_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BARCODE_EAN_UPC_TextBox.Location = New System.Drawing.Point(127, 20)
        Me.BARCODE_EAN_UPC_TextBox.Name = "BARCODE_EAN_UPC_TextBox"
        Me.BARCODE_EAN_UPC_TextBox.Size = New System.Drawing.Size(139, 26)
        Me.BARCODE_EAN_UPC_TextBox.TabIndex = 5
        '
        'SKUTextBox
        '
        Me.SKUTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SKUTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "SKU", True))
        Me.SKUTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SKUTextBox.Location = New System.Drawing.Point(310, 20)
        Me.SKUTextBox.Name = "SKUTextBox"
        Me.SKUTextBox.Size = New System.Drawing.Size(118, 26)
        Me.SKUTextBox.TabIndex = 7
        '
        'SIZETextBox
        '
        Me.SIZETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SIZETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "SIZE", True))
        Me.SIZETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIZETextBox.Location = New System.Drawing.Point(257, 160)
        Me.SIZETextBox.Name = "SIZETextBox"
        Me.SIZETextBox.Size = New System.Drawing.Size(90, 26)
        Me.SIZETextBox.TabIndex = 15
        '
        'DESCRIPTIONSTextBox
        '
        Me.DESCRIPTIONSTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DESCRIPTIONSTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "DESCRIPTIONS", True))
        Me.DESCRIPTIONSTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DESCRIPTIONSTextBox.Location = New System.Drawing.Point(127, 66)
        Me.DESCRIPTIONSTextBox.Name = "DESCRIPTIONSTextBox"
        Me.DESCRIPTIONSTextBox.Size = New System.Drawing.Size(437, 26)
        Me.DESCRIPTIONSTextBox.TabIndex = 9
        '
        'BRANDTextBox
        '
        Me.BRANDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BRANDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "BRAND", True))
        Me.BRANDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRANDTextBox.Location = New System.Drawing.Point(127, 113)
        Me.BRANDTextBox.Name = "BRANDTextBox"
        Me.BRANDTextBox.Size = New System.Drawing.Size(149, 26)
        Me.BRANDTextBox.TabIndex = 11
        '
        'CATEGORYTextBox
        '
        Me.CATEGORYTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CATEGORYTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "CATEGORY", True))
        Me.CATEGORYTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CATEGORYTextBox.Location = New System.Drawing.Point(357, 113)
        Me.CATEGORYTextBox.Name = "CATEGORYTextBox"
        Me.CATEGORYTextBox.Size = New System.Drawing.Size(208, 26)
        Me.CATEGORYTextBox.TabIndex = 13
        '
        'STOCK_AVAILABLETextBox
        '
        Me.STOCK_AVAILABLETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.STOCK_AVAILABLETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "STOCK_AVAILABLE", True))
        Me.STOCK_AVAILABLETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STOCK_AVAILABLETextBox.Location = New System.Drawing.Point(465, 160)
        Me.STOCK_AVAILABLETextBox.Name = "STOCK_AVAILABLETextBox"
        Me.STOCK_AVAILABLETextBox.Size = New System.Drawing.Size(99, 26)
        Me.STOCK_AVAILABLETextBox.TabIndex = 17
        '
        'QUANTITYTextBox
        '
        Me.QUANTITYTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QUANTITYTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "QUANTITY", True))
        Me.QUANTITYTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QUANTITYTextBox.Location = New System.Drawing.Point(127, 261)
        Me.QUANTITYTextBox.Name = "QUANTITYTextBox"
        Me.QUANTITYTextBox.Size = New System.Drawing.Size(88, 26)
        Me.QUANTITYTextBox.TabIndex = 19
        '
        'PRICETextBox
        '
        Me.PRICETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PRICETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "PRICE", True))
        Me.PRICETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PRICETextBox.Location = New System.Drawing.Point(127, 160)
        Me.PRICETextBox.Name = "PRICETextBox"
        Me.PRICETextBox.Size = New System.Drawing.Size(84, 26)
        Me.PRICETextBox.TabIndex = 21
        '
        'VENDORTextBox
        '
        Me.VENDORTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VENDORTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "VENDOR", True))
        Me.VENDORTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VENDORTextBox.Location = New System.Drawing.Point(127, 211)
        Me.VENDORTextBox.Name = "VENDORTextBox"
        Me.VENDORTextBox.Size = New System.Drawing.Size(437, 26)
        Me.VENDORTextBox.TabIndex = 27
        '
        'TOTALTextBox1
        '
        Me.TOTALTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOTALTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bad_OrderBindingSource, "TOTAL", True))
        Me.TOTALTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOTALTextBox1.Location = New System.Drawing.Point(465, 11)
        Me.TOTALTextBox1.Name = "TOTALTextBox1"
        Me.TOTALTextBox1.Size = New System.Drawing.Size(100, 26)
        Me.TOTALTextBox1.TabIndex = 29
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(286, 63)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 32
        Label2.Text = "USER:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TOTALTextBox1)
        Me.Panel5.Controls.Add(TOTALLabel)
        Me.Panel5.Controls.Add(TOTALLabel1)
        Me.Panel5.Controls.Add(Me.TOTALTextBox)
        Me.Panel5.Location = New System.Drawing.Point(12, 516)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(575, 47)
        Me.Panel5.TabIndex = 249
        '
        'Bad_Order_Management
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 630)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Bad_Order_Management"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bad_Order_Management"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Bad_Order_ReportsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bad_OrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents userPic As PictureBox
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents CODENECTDataSet As CODENECTDataSet
    Friend WithEvents Bad_Order_ReportsBindingSource As BindingSource
    Friend WithEvents Bad_Order_ReportsTableAdapter As CODENECTDataSetTableAdapters.Bad_Order_ReportsTableAdapter
    Friend WithEvents TableAdapterManager As CODENECTDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TRANSACTION_IDLabel1 As Label
    Friend WithEvents USERTextBox As TextBox
    Friend WithEvents PREPAREDDateTimePicker As DateTimePicker
    Friend WithEvents MEMOLabel1 As Label
    Friend WithEvents STATUSLabel1 As Label
    Friend WithEvents TOTALTextBox As TextBox
    Friend WithEvents VENDORComboBox As ComboBox
    Friend WithEvents BRANCHLabel1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents ButtonSave As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents VendorTableAdapter As CODENECTDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents VendorBindingSource As BindingSource
    Friend WithEvents Bad_OrderTableAdapter As CODENECTDataSetTableAdapters.Bad_OrderTableAdapter
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Bad_OrderBindingSource As BindingSource
    Friend WithEvents TRANSACTION_IDTextBox As TextBox
    Friend WithEvents REASONComboBox As ComboBox
    Friend WithEvents BARCODE_EAN_UPC_TextBox As TextBox
    Friend WithEvents SKUTextBox As TextBox
    Friend WithEvents DESCRIPTIONSTextBox As TextBox
    Friend WithEvents BRANDTextBox As TextBox
    Friend WithEvents CATEGORYTextBox As TextBox
    Friend WithEvents SIZETextBox As TextBox
    Friend WithEvents STOCK_AVAILABLETextBox As TextBox
    Friend WithEvents QUANTITYTextBox As TextBox
    Friend WithEvents PRICETextBox As TextBox
    Friend WithEvents VENDOR_CODETextBox As TextBox
    Friend WithEvents VENDORTextBox As TextBox
    Friend WithEvents TOTALTextBox1 As TextBox
    Friend WithEvents Panel5 As Panel
End Class
