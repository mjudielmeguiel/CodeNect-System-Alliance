<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ADD_Branch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADD_Branch))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAddress = New System.Windows.Forms.RichTextBox()
        Me.picBusinessLogo = New System.Windows.Forms.PictureBox()
        Me.dtpTIN_Registered = New System.Windows.Forms.DateTimePicker()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.txtManager = New System.Windows.Forms.TextBox()
        Me.cmbBusinessType = New System.Windows.Forms.ComboBox()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        CType(Me.picBusinessLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.picBusinessLogo)
        Me.Panel1.Controls.Add(Me.dtpTIN_Registered)
        Me.Panel1.Controls.Add(Me.txtTIN)
        Me.Panel1.Controls.Add(Me.txtManager)
        Me.Panel1.Controls.Add(Me.cmbBusinessType)
        Me.Panel1.Controls.Add(Me.txtBranchID)
        Me.Panel1.Controls.Add(Me.txtBranch)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtContact)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(482, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 620)
        Me.Panel1.TabIndex = 41
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(140, 123)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(417, 109)
        Me.txtAddress.TabIndex = 25
        Me.txtAddress.Text = ""
        '
        'picBusinessLogo
        '
        Me.picBusinessLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBusinessLogo.Image = CType(resources.GetObject("picBusinessLogo.Image"), System.Drawing.Image)
        Me.picBusinessLogo.Location = New System.Drawing.Point(13, 123)
        Me.picBusinessLogo.Name = "picBusinessLogo"
        Me.picBusinessLogo.Size = New System.Drawing.Size(121, 109)
        Me.picBusinessLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBusinessLogo.TabIndex = 24
        Me.picBusinessLogo.TabStop = False
        '
        'dtpTIN_Registered
        '
        Me.dtpTIN_Registered.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTIN_Registered.Location = New System.Drawing.Point(283, 57)
        Me.dtpTIN_Registered.Name = "dtpTIN_Registered"
        Me.dtpTIN_Registered.Size = New System.Drawing.Size(275, 26)
        Me.dtpTIN_Registered.TabIndex = 23
        '
        'txtTIN
        '
        Me.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(13, 57)
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(264, 26)
        Me.txtTIN.TabIndex = 22
        '
        'txtManager
        '
        Me.txtManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManager.Location = New System.Drawing.Point(10, 270)
        Me.txtManager.Name = "txtManager"
        Me.txtManager.Size = New System.Drawing.Size(547, 26)
        Me.txtManager.TabIndex = 17
        '
        'cmbBusinessType
        '
        Me.cmbBusinessType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBusinessType.FormattingEnabled = True
        Me.cmbBusinessType.Items.AddRange(New Object() {"Retail Grocery Store", "Supermarket (Retail Trade)", "Food and Grocery Retail Business", "Convenience Store / Mini-Mart"})
        Me.cmbBusinessType.Location = New System.Drawing.Point(10, 89)
        Me.cmbBusinessType.Name = "cmbBusinessType"
        Me.cmbBusinessType.Size = New System.Drawing.Size(547, 28)
        Me.cmbBusinessType.TabIndex = 16
        '
        'txtBranchID
        '
        Me.txtBranchID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(12, 25)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.Size = New System.Drawing.Size(147, 26)
        Me.txtBranchID.TabIndex = 7
        '
        'txtBranch
        '
        Me.txtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(165, 25)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(394, 26)
        Me.txtBranch.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(10, 238)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(316, 26)
        Me.txtEmail.TabIndex = 11
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(332, 238)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(225, 26)
        Me.txtContact.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.userPic)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1075, 54)
        Me.Panel2.TabIndex = 45
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
        Me.Label1.Size = New System.Drawing.Size(280, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW BRANCH"
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
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(782, 680)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 217
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(923, 680)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 218
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ListView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 54)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(482, 675)
        Me.Panel3.TabIndex = 219
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 11)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(451, 652)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ADD_Branch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 729)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ADD_Branch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADD_Branch"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picBusinessLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtBranchID As TextBox
    Friend WithEvents txtBranch As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtManager As TextBox
    Friend WithEvents cmbBusinessType As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtAddress As RichTextBox
    Friend WithEvents picBusinessLogo As PictureBox
    Friend WithEvents dtpTIN_Registered As DateTimePicker
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ListView1 As ListView
End Class
