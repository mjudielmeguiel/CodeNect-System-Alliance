<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.lblrole = New System.Windows.Forms.Label()
        Me.menupanel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.btnRTV_Reports = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnSTR_Reports = New System.Windows.Forms.Button()
        Me.btnSOTEX_Reports = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnPO_Reports = New System.Windows.Forms.Button()
        Me.btnINV_Reports = New System.Windows.Forms.Button()
        Me.btnPrice_Adjustment_Reports = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnRTV = New System.Windows.Forms.Button()
        Me.btnPO = New System.Windows.Forms.Button()
        Me.btnSTR = New System.Windows.Forms.Button()
        Me.btnuselist = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSOTEX_Expiry = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.menupanel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.lblrole)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(332, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1034, 48)
        Me.Panel1.TabIndex = 2
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.DarkRed
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(0, 0)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(54, 48)
        Me.Button10.TabIndex = 143
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = False
        '
        'lblrole
        '
        Me.lblrole.AutoSize = True
        Me.lblrole.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrole.ForeColor = System.Drawing.SystemColors.Control
        Me.lblrole.Location = New System.Drawing.Point(60, 6)
        Me.lblrole.Name = "lblrole"
        Me.lblrole.Size = New System.Drawing.Size(326, 36)
        Me.lblrole.TabIndex = 0
        Me.lblrole.Text = "ADMIN - MAIN OFFICE"
        '
        'menupanel
        '
        Me.menupanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.menupanel.Controls.Add(Me.Panel3)
        Me.menupanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.menupanel.Location = New System.Drawing.Point(0, 0)
        Me.menupanel.Name = "menupanel"
        Me.menupanel.Size = New System.Drawing.Size(332, 768)
        Me.menupanel.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.Button9)
        Me.Panel3.Controls.Add(Me.btnRTV)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.btnPO)
        Me.Panel3.Controls.Add(Me.btnSTR)
        Me.Panel3.Controls.Add(Me.btnSOTEX_Expiry)
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.btnRTV_Reports)
        Me.Panel3.Controls.Add(Me.Button7)
        Me.Panel3.Controls.Add(Me.btnSTR_Reports)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.btnSOTEX_Reports)
        Me.Panel3.Controls.Add(Me.Button6)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button12)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.btnPO_Reports)
        Me.Panel3.Controls.Add(Me.btnuselist)
        Me.Panel3.Controls.Add(Me.btnINV_Reports)
        Me.Panel3.Controls.Add(Me.btnPrice_Adjustment_Reports)
        Me.Panel3.Controls.Add(Me.Button11)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(332, 768)
        Me.Panel3.TabIndex = 313
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.Location = New System.Drawing.Point(0, 988)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(315, 47)
        Me.Button9.TabIndex = 318
        Me.Button9.Text = "Sign Out"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'btnRTV_Reports
        '
        Me.btnRTV_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRTV_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRTV_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRTV_Reports.FlatAppearance.BorderSize = 0
        Me.btnRTV_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRTV_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRTV_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRTV_Reports.Image = CType(resources.GetObject("btnRTV_Reports.Image"), System.Drawing.Image)
        Me.btnRTV_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRTV_Reports.Location = New System.Drawing.Point(0, 659)
        Me.btnRTV_Reports.Name = "btnRTV_Reports"
        Me.btnRTV_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnRTV_Reports.TabIndex = 334
        Me.btnRTV_Reports.Text = "Return to Vendor Reports"
        Me.btnRTV_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRTV_Reports.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(0, 612)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(315, 47)
        Me.Button7.TabIndex = 329
        Me.Button7.Text = "Out of Stocks Reports"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnSTR_Reports
        '
        Me.btnSTR_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSTR_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSTR_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSTR_Reports.FlatAppearance.BorderSize = 0
        Me.btnSTR_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSTR_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSTR_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSTR_Reports.Image = CType(resources.GetObject("btnSTR_Reports.Image"), System.Drawing.Image)
        Me.btnSTR_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSTR_Reports.Location = New System.Drawing.Point(0, 565)
        Me.btnSTR_Reports.Name = "btnSTR_Reports"
        Me.btnSTR_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnSTR_Reports.TabIndex = 323
        Me.btnSTR_Reports.Text = "Stock Transfer reports"
        Me.btnSTR_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSTR_Reports.UseVisualStyleBackColor = False
        '
        'btnSOTEX_Reports
        '
        Me.btnSOTEX_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSOTEX_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSOTEX_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSOTEX_Reports.FlatAppearance.BorderSize = 0
        Me.btnSOTEX_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSOTEX_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSOTEX_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSOTEX_Reports.Image = CType(resources.GetObject("btnSOTEX_Reports.Image"), System.Drawing.Image)
        Me.btnSOTEX_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSOTEX_Reports.Location = New System.Drawing.Point(0, 471)
        Me.btnSOTEX_Reports.Name = "btnSOTEX_Reports"
        Me.btnSOTEX_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnSOTEX_Reports.TabIndex = 327
        Me.btnSOTEX_Reports.Text = "Soon to Expiry Reports"
        Me.btnSOTEX_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSOTEX_Reports.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(0, 377)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(315, 47)
        Me.Button3.TabIndex = 322
        Me.Button3.Text = "USER Product Descriptions"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(0, 283)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(315, 47)
        Me.Button4.TabIndex = 313
        Me.Button4.Text = "Print Shelftags"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btnPO_Reports
        '
        Me.btnPO_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPO_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPO_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPO_Reports.FlatAppearance.BorderSize = 0
        Me.btnPO_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPO_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPO_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPO_Reports.Image = CType(resources.GetObject("btnPO_Reports.Image"), System.Drawing.Image)
        Me.btnPO_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPO_Reports.Location = New System.Drawing.Point(0, 236)
        Me.btnPO_Reports.Name = "btnPO_Reports"
        Me.btnPO_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnPO_Reports.TabIndex = 316
        Me.btnPO_Reports.Text = "Purchase Order Reports"
        Me.btnPO_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPO_Reports.UseVisualStyleBackColor = False
        '
        'btnINV_Reports
        '
        Me.btnINV_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnINV_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnINV_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnINV_Reports.FlatAppearance.BorderSize = 0
        Me.btnINV_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnINV_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnINV_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnINV_Reports.Image = CType(resources.GetObject("btnINV_Reports.Image"), System.Drawing.Image)
        Me.btnINV_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnINV_Reports.Location = New System.Drawing.Point(0, 142)
        Me.btnINV_Reports.Name = "btnINV_Reports"
        Me.btnINV_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnINV_Reports.TabIndex = 332
        Me.btnINV_Reports.Text = "Inventory reports"
        Me.btnINV_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnINV_Reports.UseVisualStyleBackColor = False
        '
        'btnPrice_Adjustment_Reports
        '
        Me.btnPrice_Adjustment_Reports.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPrice_Adjustment_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPrice_Adjustment_Reports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPrice_Adjustment_Reports.FlatAppearance.BorderSize = 0
        Me.btnPrice_Adjustment_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrice_Adjustment_Reports.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrice_Adjustment_Reports.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrice_Adjustment_Reports.Image = CType(resources.GetObject("btnPrice_Adjustment_Reports.Image"), System.Drawing.Image)
        Me.btnPrice_Adjustment_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrice_Adjustment_Reports.Location = New System.Drawing.Point(0, 95)
        Me.btnPrice_Adjustment_Reports.Name = "btnPrice_Adjustment_Reports"
        Me.btnPrice_Adjustment_Reports.Size = New System.Drawing.Size(315, 47)
        Me.btnPrice_Adjustment_Reports.TabIndex = 325
        Me.btnPrice_Adjustment_Reports.Text = "Price Adjustment Reports"
        Me.btnPrice_Adjustment_Reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrice_Adjustment_Reports.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.Location = New System.Drawing.Point(0, 48)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(315, 47)
        Me.Button11.TabIndex = 319
        Me.Button11.Text = "Dashboard"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(315, 48)
        Me.Panel4.TabIndex = 325
        '
        'btnRTV
        '
        Me.btnRTV.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRTV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRTV.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRTV.FlatAppearance.BorderSize = 0
        Me.btnRTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRTV.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRTV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRTV.Image = CType(resources.GetObject("btnRTV.Image"), System.Drawing.Image)
        Me.btnRTV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRTV.Location = New System.Drawing.Point(0, 941)
        Me.btnRTV.Name = "btnRTV"
        Me.btnRTV.Size = New System.Drawing.Size(315, 47)
        Me.btnRTV.TabIndex = 333
        Me.btnRTV.Text = "Return to Vendor"
        Me.btnRTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRTV.UseVisualStyleBackColor = False
        '
        'btnPO
        '
        Me.btnPO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPO.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPO.FlatAppearance.BorderSize = 0
        Me.btnPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPO.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPO.Image = CType(resources.GetObject("btnPO.Image"), System.Drawing.Image)
        Me.btnPO.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPO.Location = New System.Drawing.Point(0, 847)
        Me.btnPO.Name = "btnPO"
        Me.btnPO.Size = New System.Drawing.Size(315, 47)
        Me.btnPO.TabIndex = 309
        Me.btnPO.Text = "Purchase Order"
        Me.btnPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPO.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnPO.UseVisualStyleBackColor = False
        '
        'btnSTR
        '
        Me.btnSTR.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSTR.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSTR.FlatAppearance.BorderSize = 0
        Me.btnSTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSTR.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSTR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSTR.Image = CType(resources.GetObject("btnSTR.Image"), System.Drawing.Image)
        Me.btnSTR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSTR.Location = New System.Drawing.Point(0, 800)
        Me.btnSTR.Name = "btnSTR"
        Me.btnSTR.Size = New System.Drawing.Size(315, 47)
        Me.btnSTR.TabIndex = 317
        Me.btnSTR.Text = "Stock Transfer"
        Me.btnSTR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSTR.UseVisualStyleBackColor = False
        '
        'btnuselist
        '
        Me.btnuselist.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnuselist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnuselist.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnuselist.FlatAppearance.BorderSize = 0
        Me.btnuselist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnuselist.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuselist.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnuselist.Image = CType(resources.GetObject("btnuselist.Image"), System.Drawing.Image)
        Me.btnuselist.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnuselist.Location = New System.Drawing.Point(0, 189)
        Me.btnuselist.Name = "btnuselist"
        Me.btnuselist.Size = New System.Drawing.Size(315, 47)
        Me.btnuselist.TabIndex = 320
        Me.btnuselist.Text = "User List"
        Me.btnuselist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnuselist.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(0, 706)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(315, 47)
        Me.Button5.TabIndex = 324
        Me.Button5.Text = "Inventory Management"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(0, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(315, 47)
        Me.Button1.TabIndex = 310
        Me.Button1.Text = "ADMIN Product Descriptions"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(0, 424)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(315, 47)
        Me.Button6.TabIndex = 315
        Me.Button6.Text = "Price Adjustment"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.Location = New System.Drawing.Point(0, 330)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(315, 47)
        Me.Button12.TabIndex = 321
        Me.Button12.Text = "Branch List"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Panelmenu
        '
        Me.Panelmenu.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelmenu.Location = New System.Drawing.Point(332, 0)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(1034, 768)
        Me.Panelmenu.TabIndex = 312
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(0, 894)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(315, 47)
        Me.Button2.TabIndex = 328
        Me.Button2.Text = "Out of Stock"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnSOTEX_Expiry
        '
        Me.btnSOTEX_Expiry.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSOTEX_Expiry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSOTEX_Expiry.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSOTEX_Expiry.FlatAppearance.BorderSize = 0
        Me.btnSOTEX_Expiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSOTEX_Expiry.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSOTEX_Expiry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSOTEX_Expiry.Image = CType(resources.GetObject("btnSOTEX_Expiry.Image"), System.Drawing.Image)
        Me.btnSOTEX_Expiry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSOTEX_Expiry.Location = New System.Drawing.Point(0, 753)
        Me.btnSOTEX_Expiry.Name = "btnSOTEX_Expiry"
        Me.btnSOTEX_Expiry.Size = New System.Drawing.Size(315, 47)
        Me.btnSOTEX_Expiry.TabIndex = 326
        Me.btnSOTEX_Expiry.Text = "Soon to Expiry"
        Me.btnSOTEX_Expiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSOTEX_Expiry.UseVisualStyleBackColor = False
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panelmenu)
        Me.Controls.Add(Me.menupanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.menupanel.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblrole As Label
    Friend WithEvents menupanel As Panel
    Friend WithEvents Button10 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnSTR_Reports As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents btnSTR As Button
    Friend WithEvents btnPO_Reports As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btnPO As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents btnuselist As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panelmenu As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnINV_Reports As Button
    Friend WithEvents btnRTV As Button
    Friend WithEvents btnPrice_Adjustment_Reports As Button
    Friend WithEvents btnSOTEX_Reports As Button
    Friend WithEvents btnSOTEX_Expiry As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnRTV_Reports As Button
End Class
