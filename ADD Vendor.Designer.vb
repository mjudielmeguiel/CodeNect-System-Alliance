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
        Me.components = New System.ComponentModel.Container()
        Dim Label1 As System.Windows.Forms.Label
        Dim VENDOR_IDLabel1 As System.Windows.Forms.Label
        Dim VENDOR_NAMELabel1 As System.Windows.Forms.Label
        Dim COMPANYLabel1 As System.Windows.Forms.Label
        Dim CONTACTLabel1 As System.Windows.Forms.Label
        Dim EMAILLabel1 As System.Windows.Forms.Label
        Dim USERNAMELabel As System.Windows.Forms.Label
        Dim PASSWORDLabel As System.Windows.Forms.Label
        Dim STATUSLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADD_Vendor))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CODENECTDataSet = New CodeNect_System_Alliance.CODENECTDataSet()
        Me.VENDOR_IDTextBox = New System.Windows.Forms.TextBox()
        Me.VENDOR_NAMETextBox = New System.Windows.Forms.TextBox()
        Me.COMPANYTextBox = New System.Windows.Forms.TextBox()
        Me.CONTACTTextBox = New System.Windows.Forms.TextBox()
        Me.EMAILTextBox = New System.Windows.Forms.TextBox()
        Me.USERNAMETextBox = New System.Windows.Forms.TextBox()
        Me.PASSWORDTextBox = New System.Windows.Forms.TextBox()
        Me.STATUSTextBox = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.VendorTableAdapter = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.VendorTableAdapter()
        Me.TableAdapterManager = New CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager()
        Me.Button4 = New System.Windows.Forms.Button()
        Label1 = New System.Windows.Forms.Label()
        VENDOR_IDLabel1 = New System.Windows.Forms.Label()
        VENDOR_NAMELabel1 = New System.Windows.Forms.Label()
        COMPANYLabel1 = New System.Windows.Forms.Label()
        CONTACTLabel1 = New System.Windows.Forms.Label()
        EMAILLabel1 = New System.Windows.Forms.Label()
        USERNAMELabel = New System.Windows.Forms.Label()
        PASSWORDLabel = New System.Windows.Forms.Label()
        STATUSLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(304, 82)
        Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(99, 19)
        Label1.TabIndex = 46
        Label1.Text = "ADD VENDOR"
        '
        'VENDOR_IDLabel1
        '
        VENDOR_IDLabel1.AutoSize = True
        VENDOR_IDLabel1.Location = New System.Drawing.Point(12, 20)
        VENDOR_IDLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        VENDOR_IDLabel1.Name = "VENDOR_IDLabel1"
        VENDOR_IDLabel1.Size = New System.Drawing.Size(84, 16)
        VENDOR_IDLabel1.TabIndex = 12
        VENDOR_IDLabel1.Text = "VENDOR ID:"
        '
        'VENDOR_NAMELabel1
        '
        VENDOR_NAMELabel1.AutoSize = True
        VENDOR_NAMELabel1.Location = New System.Drawing.Point(177, 20)
        VENDOR_NAMELabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        VENDOR_NAMELabel1.Name = "VENDOR_NAMELabel1"
        VENDOR_NAMELabel1.Size = New System.Drawing.Size(110, 16)
        VENDOR_NAMELabel1.TabIndex = 14
        VENDOR_NAMELabel1.Text = "VENDOR NAME:"
        '
        'COMPANYLabel1
        '
        COMPANYLabel1.AutoSize = True
        COMPANYLabel1.Location = New System.Drawing.Point(12, 75)
        COMPANYLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        COMPANYLabel1.Name = "COMPANYLabel1"
        COMPANYLabel1.Size = New System.Drawing.Size(77, 16)
        COMPANYLabel1.TabIndex = 16
        COMPANYLabel1.Text = "COMPANY:"
        '
        'CONTACTLabel1
        '
        CONTACTLabel1.AutoSize = True
        CONTACTLabel1.Location = New System.Drawing.Point(12, 130)
        CONTACTLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CONTACTLabel1.Name = "CONTACTLabel1"
        CONTACTLabel1.Size = New System.Drawing.Size(75, 16)
        CONTACTLabel1.TabIndex = 18
        CONTACTLabel1.Text = "CONTACT:"
        '
        'EMAILLabel1
        '
        EMAILLabel1.AutoSize = True
        EMAILLabel1.Location = New System.Drawing.Point(284, 130)
        EMAILLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EMAILLabel1.Name = "EMAILLabel1"
        EMAILLabel1.Size = New System.Drawing.Size(49, 16)
        EMAILLabel1.TabIndex = 20
        EMAILLabel1.Text = "EMAIL:"
        '
        'USERNAMELabel
        '
        USERNAMELabel.AutoSize = True
        USERNAMELabel.Location = New System.Drawing.Point(12, 186)
        USERNAMELabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        USERNAMELabel.Name = "USERNAMELabel"
        USERNAMELabel.Size = New System.Drawing.Size(87, 16)
        USERNAMELabel.TabIndex = 22
        USERNAMELabel.Text = "USERNAME:"
        '
        'PASSWORDLabel
        '
        PASSWORDLabel.AutoSize = True
        PASSWORDLabel.Location = New System.Drawing.Point(284, 186)
        PASSWORDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PASSWORDLabel.Name = "PASSWORDLabel"
        PASSWORDLabel.Size = New System.Drawing.Size(89, 16)
        PASSWORDLabel.TabIndex = 24
        PASSWORDLabel.Text = "PASSWORD:"
        '
        'STATUSLabel
        '
        STATUSLabel.AutoSize = True
        STATUSLabel.Location = New System.Drawing.Point(549, 75)
        STATUSLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        STATUSLabel.Name = "STATUSLabel"
        STATUSLabel.Size = New System.Drawing.Size(65, 16)
        STATUSLabel.TabIndex = 26
        STATUSLabel.Text = "STATUS:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(508, 186)
        Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(153, 16)
        Label2.TabIndex = 28
        Label2.Text = "CONFIRM PASSWORD:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(735, 107)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Label2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(VENDOR_IDLabel1)
        Me.Panel1.Controls.Add(Me.VENDOR_IDTextBox)
        Me.Panel1.Controls.Add(VENDOR_NAMELabel1)
        Me.Panel1.Controls.Add(Me.VENDOR_NAMETextBox)
        Me.Panel1.Controls.Add(COMPANYLabel1)
        Me.Panel1.Controls.Add(Me.COMPANYTextBox)
        Me.Panel1.Controls.Add(CONTACTLabel1)
        Me.Panel1.Controls.Add(Me.CONTACTTextBox)
        Me.Panel1.Controls.Add(EMAILLabel1)
        Me.Panel1.Controls.Add(Me.EMAILTextBox)
        Me.Panel1.Controls.Add(USERNAMELabel)
        Me.Panel1.Controls.Add(Me.USERNAMETextBox)
        Me.Panel1.Controls.Add(PASSWORDLabel)
        Me.Panel1.Controls.Add(Me.PASSWORDTextBox)
        Me.Panel1.Controls.Add(STATUSLabel)
        Me.Panel1.Controls.Add(Me.STATUSTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(0, 107)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 273)
        Me.Panel1.TabIndex = 47
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(583, 245)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(125, 20)
        Me.CheckBox1.TabIndex = 157
        Me.CheckBox1.Text = "Show Password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "PASSWORD", True))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(512, 206)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 30)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.CODENECTDataSet
        '
        'CODENECTDataSet
        '
        Me.CODENECTDataSet.DataSetName = "CODENECTDataSet"
        Me.CODENECTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VENDOR_IDTextBox
        '
        Me.VENDOR_IDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VENDOR_IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "VENDOR ID", True))
        Me.VENDOR_IDTextBox.Enabled = False
        Me.VENDOR_IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VENDOR_IDTextBox.Location = New System.Drawing.Point(16, 39)
        Me.VENDOR_IDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VENDOR_IDTextBox.Name = "VENDOR_IDTextBox"
        Me.VENDOR_IDTextBox.Size = New System.Drawing.Size(157, 30)
        Me.VENDOR_IDTextBox.TabIndex = 13
        Me.VENDOR_IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'VENDOR_NAMETextBox
        '
        Me.VENDOR_NAMETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VENDOR_NAMETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "VENDOR NAME", True))
        Me.VENDOR_NAMETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VENDOR_NAMETextBox.Location = New System.Drawing.Point(181, 39)
        Me.VENDOR_NAMETextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.VENDOR_NAMETextBox.Name = "VENDOR_NAMETextBox"
        Me.VENDOR_NAMETextBox.Size = New System.Drawing.Size(537, 30)
        Me.VENDOR_NAMETextBox.TabIndex = 15
        '
        'COMPANYTextBox
        '
        Me.COMPANYTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.COMPANYTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "COMPANY", True))
        Me.COMPANYTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMPANYTextBox.Location = New System.Drawing.Point(16, 95)
        Me.COMPANYTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.COMPANYTextBox.Name = "COMPANYTextBox"
        Me.COMPANYTextBox.Size = New System.Drawing.Size(529, 30)
        Me.COMPANYTextBox.TabIndex = 17
        '
        'CONTACTTextBox
        '
        Me.CONTACTTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CONTACTTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "CONTACT", True))
        Me.CONTACTTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CONTACTTextBox.Location = New System.Drawing.Point(16, 150)
        Me.CONTACTTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CONTACTTextBox.Name = "CONTACTTextBox"
        Me.CONTACTTextBox.Size = New System.Drawing.Size(263, 30)
        Me.CONTACTTextBox.TabIndex = 19
        '
        'EMAILTextBox
        '
        Me.EMAILTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMAILTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "EMAIL", True))
        Me.EMAILTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EMAILTextBox.Location = New System.Drawing.Point(288, 150)
        Me.EMAILTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EMAILTextBox.Name = "EMAILTextBox"
        Me.EMAILTextBox.Size = New System.Drawing.Size(430, 30)
        Me.EMAILTextBox.TabIndex = 21
        '
        'USERNAMETextBox
        '
        Me.USERNAMETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.USERNAMETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "USERNAME", True))
        Me.USERNAMETextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.USERNAMETextBox.Location = New System.Drawing.Point(16, 206)
        Me.USERNAMETextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.USERNAMETextBox.Name = "USERNAMETextBox"
        Me.USERNAMETextBox.Size = New System.Drawing.Size(263, 30)
        Me.USERNAMETextBox.TabIndex = 23
        '
        'PASSWORDTextBox
        '
        Me.PASSWORDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PASSWORDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "PASSWORD", True))
        Me.PASSWORDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PASSWORDTextBox.Location = New System.Drawing.Point(288, 206)
        Me.PASSWORDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PASSWORDTextBox.Name = "PASSWORDTextBox"
        Me.PASSWORDTextBox.Size = New System.Drawing.Size(215, 30)
        Me.PASSWORDTextBox.TabIndex = 25
        Me.PASSWORDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.PASSWORDTextBox.UseSystemPasswordChar = True
        '
        'STATUSTextBox
        '
        Me.STATUSTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.STATUSTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VendorBindingSource, "STATUS", True))
        Me.STATUSTextBox.Enabled = False
        Me.STATUSTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STATUSTextBox.Location = New System.Drawing.Point(553, 95)
        Me.STATUSTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.STATUSTextBox.Name = "STATUSTextBox"
        Me.STATUSTextBox.Size = New System.Drawing.Size(165, 30)
        Me.STATUSTextBox.TabIndex = 27
        Me.STATUSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(335, 388)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 46)
        Me.Button3.TabIndex = 49
        Me.Button3.Text = " Save"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(335, 388)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 46)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = " Start"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.Account_RecoverTableAdapter = Nothing
        Me.TableAdapterManager.AccountTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BranchesTableAdapter = Nothing
        Me.TableAdapterManager.DescriptionsTableAdapter = Nothing
        Me.TableAdapterManager.PcountTableAdapter = Nothing
        Me.TableAdapterManager.Stock_OrderingTableAdapter = Nothing
        Me.TableAdapterManager.StoTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CodeNect_System_Alliance.CODENECTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableAdapter = Nothing
        Me.TableAdapterManager.VendorTableAdapter = Me.VendorTableAdapter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Maroon
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(531, 388)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(188, 46)
        Me.Button4.TabIndex = 132
        Me.Button4.Text = "Cancel"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ADD_Vendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 448)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ADD_Vendor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Vendor"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODENECTDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents CODENECTDataSet As CODENECTDataSet
    Friend WithEvents VendorBindingSource As BindingSource
    Friend WithEvents VendorTableAdapter As CODENECTDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents TableAdapterManager As CODENECTDataSetTableAdapters.TableAdapterManager
    Friend WithEvents VENDOR_IDTextBox As TextBox
    Friend WithEvents VENDOR_NAMETextBox As TextBox
    Friend WithEvents COMPANYTextBox As TextBox
    Friend WithEvents CONTACTTextBox As TextBox
    Friend WithEvents EMAILTextBox As TextBox
    Friend WithEvents USERNAMETextBox As TextBox
    Friend WithEvents PASSWORDTextBox As TextBox
    Friend WithEvents STATUSTextBox As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents CheckBox1 As CheckBox
End Class
