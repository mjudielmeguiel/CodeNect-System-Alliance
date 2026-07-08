<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConnectionSettings
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
        Dim VENDOR_IDLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnectionSettings))
        Me.txtServerIP = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.rchFullConnection = New System.Windows.Forms.RichTextBox()
        Me.lblconnection = New System.Windows.Forms.Label()
        VENDOR_IDLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VENDOR_IDLabel
        '
        VENDOR_IDLabel.AutoSize = True
        VENDOR_IDLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VENDOR_IDLabel.ForeColor = System.Drawing.Color.DarkRed
        VENDOR_IDLabel.Location = New System.Drawing.Point(8, 104)
        VENDOR_IDLabel.Name = "VENDOR_IDLabel"
        VENDOR_IDLabel.Size = New System.Drawing.Size(114, 21)
        VENDOR_IDLabel.TabIndex = 5
        VENDOR_IDLabel.Text = "Server name :"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.ForeColor = System.Drawing.Color.DarkRed
        Label1.Location = New System.Drawing.Point(8, 163)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(51, 21)
        Label1.TabIndex = 7
        Label1.Text = "Port :"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.ForeColor = System.Drawing.Color.DarkRed
        Label2.Location = New System.Drawing.Point(7, 281)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(53, 21)
        Label2.TabIndex = 11
        Label2.Text = "User :"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.ForeColor = System.Drawing.Color.DarkRed
        Label3.Location = New System.Drawing.Point(7, 222)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(90, 21)
        Label3.TabIndex = 9
        Label3.Text = "Database :"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.ForeColor = System.Drawing.Color.DarkRed
        Label4.Location = New System.Drawing.Point(7, 399)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(87, 21)
        Label4.TabIndex = 15
        Label4.Text = "Time out :"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.ForeColor = System.Drawing.Color.DarkRed
        Label5.Location = New System.Drawing.Point(7, 340)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(91, 21)
        Label5.TabIndex = 13
        Label5.Text = "Password :"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.ForeColor = System.Drawing.Color.DarkRed
        Label7.Location = New System.Drawing.Point(8, 485)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(155, 21)
        Label7.TabIndex = 324
        Label7.Text = "Connection string :"
        '
        'txtServerIP
        '
        Me.txtServerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServerIP.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerIP.Location = New System.Drawing.Point(11, 128)
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(478, 32)
        Me.txtServerIP.TabIndex = 6
        '
        'txtPort
        '
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPort.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(12, 187)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(478, 32)
        Me.txtPort.TabIndex = 8
        '
        'txtUser
        '
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(11, 305)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(478, 32)
        Me.txtUser.TabIndex = 12
        '
        'txtTimeout
        '
        Me.txtTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimeout.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeout.Location = New System.Drawing.Point(10, 423)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(478, 32)
        Me.txtTimeout.TabIndex = 16
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(11, 364)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(478, 32)
        Me.txtPassword.TabIndex = 14
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(391, 646)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 47)
        Me.btnClose.TabIndex = 301
        Me.btnClose.Text = "Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(287, 646)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 47)
        Me.btnSave.TabIndex = 302
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtDatabase
        '
        Me.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatabase.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabase.Location = New System.Drawing.Point(11, 246)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(478, 32)
        Me.txtDatabase.TabIndex = 10
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(12, 12)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(73, 54)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'rchFullConnection
        '
        Me.rchFullConnection.Location = New System.Drawing.Point(12, 509)
        Me.rchFullConnection.Name = "rchFullConnection"
        Me.rchFullConnection.ReadOnly = True
        Me.rchFullConnection.Size = New System.Drawing.Size(477, 105)
        Me.rchFullConnection.TabIndex = 323
        Me.rchFullConnection.Text = ""
        '
        'lblconnection
        '
        Me.lblconnection.AutoSize = True
        Me.lblconnection.BackColor = System.Drawing.Color.Transparent
        Me.lblconnection.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconnection.ForeColor = System.Drawing.Color.DarkRed
        Me.lblconnection.Location = New System.Drawing.Point(91, 20)
        Me.lblconnection.Name = "lblconnection"
        Me.lblconnection.Size = New System.Drawing.Size(291, 36)
        Me.lblconnection.TabIndex = 0
        Me.lblconnection.Text = "Connection Settings"
        '
        'frmConnectionSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(501, 705)
        Me.Controls.Add(Me.adminpic)
        Me.Controls.Add(Me.lblconnection)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label7)
        Me.Controls.Add(VENDOR_IDLabel)
        Me.Controls.Add(Me.rchFullConnection)
        Me.Controls.Add(Me.txtTimeout)
        Me.Controls.Add(Me.txtServerIP)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDatabase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConnectionSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConnectionSettings"
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtServerIP As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtTimeout As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents rchFullConnection As RichTextBox
    Friend WithEvents lblconnection As Label
End Class
