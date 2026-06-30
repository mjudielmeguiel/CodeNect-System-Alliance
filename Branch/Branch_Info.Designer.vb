<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Branch_Info
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Branch_Info))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtAddress = New System.Windows.Forms.RichTextBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.txtTIN = New System.Windows.Forms.TextBox()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.cboBusType = New System.Windows.Forms.ComboBox()
        Me.userPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtBranchID = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboManager = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1195, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 37)
        Me.btnCancel.TabIndex = 222
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(564, 72)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(548, 109)
        Me.txtAddress.TabIndex = 25
        Me.txtAddress.Text = ""
        '
        'picLogo
        '
        Me.picLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(1150, 6)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(204, 175)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 24
        Me.picLogo.TabStop = False
        '
        'txtTIN
        '
        Me.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN.Location = New System.Drawing.Point(13, 70)
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(218, 26)
        Me.txtTIN.TabIndex = 22
        '
        'txtAccountID
        '
        Me.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountID.Location = New System.Drawing.Point(11, 6)
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(100, 26)
        Me.txtAccountID.TabIndex = 19
        '
        'txtAccount
        '
        Me.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.Location = New System.Drawing.Point(117, 6)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(441, 26)
        Me.txtAccount.TabIndex = 20
        '
        'cboBusType
        '
        Me.cboBusType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusType.FormattingEnabled = True
        Me.cboBusType.Items.AddRange(New Object() {"Retail Grocery Store", "Supermarket (Retail Trade)", "Food and Grocery Retail Business", "Convenience Store / Mini-Mart"})
        Me.cboBusType.Location = New System.Drawing.Point(237, 70)
        Me.cboBusType.Name = "cboBusType"
        Me.cboBusType.Size = New System.Drawing.Size(320, 28)
        Me.cboBusType.TabIndex = 16
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
        Me.Label1.Size = New System.Drawing.Size(173, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Branch Info"
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkRed
        Me.Panel2.Controls.Add(Me.userPic)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.adminpic)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1366, 54)
        Me.Panel2.TabIndex = 220
        '
        'txtBranchID
        '
        Me.txtBranchID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchID.Location = New System.Drawing.Point(12, 38)
        Me.txtBranchID.Name = "txtBranchID"
        Me.txtBranchID.Size = New System.Drawing.Size(147, 26)
        Me.txtBranchID.TabIndex = 7
        '
        'txtBranch
        '
        Me.txtBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(165, 38)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(394, 26)
        Me.txtBranch.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(564, 6)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(316, 26)
        Me.txtEmail.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Maroon
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(1054, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 37)
        Me.btnSave.TabIndex = 221
        Me.btnSave.Text = " Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(886, 6)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(225, 26)
        Me.txtContact.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboManager)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.picLogo)
        Me.Panel1.Controls.Add(Me.txtTIN)
        Me.Panel1.Controls.Add(Me.txtAccountID)
        Me.Panel1.Controls.Add(Me.txtAccount)
        Me.Panel1.Controls.Add(Me.cboBusType)
        Me.Panel1.Controls.Add(Me.txtBranchID)
        Me.Panel1.Controls.Add(Me.txtBranch)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.txtContact)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 200)
        Me.Panel1.TabIndex = 219
        '
        'cboManager
        '
        Me.cboManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboManager.FormattingEnabled = True
        Me.cboManager.Items.AddRange(New Object() {"Retail Grocery Store", "Supermarket (Retail Trade)", "Food and Grocery Retail Business", "Convenience Store / Mini-Mart"})
        Me.cboManager.Location = New System.Drawing.Point(564, 38)
        Me.cboManager.Name = "cboManager"
        Me.cboManager.Size = New System.Drawing.Size(547, 28)
        Me.cboManager.TabIndex = 26
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Location = New System.Drawing.Point(10, 707)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1344, 49)
        Me.Panel4.TabIndex = 305
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(16, 10)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1032, 26)
        Me.TextBox2.TabIndex = 297
        '
        'dgvProducts
        '
        Me.dgvProducts.AllowUserToAddRows = False
        Me.dgvProducts.AllowUserToDeleteRows = False
        Me.dgvProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Location = New System.Drawing.Point(10, 260)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.ReadOnly = True
        Me.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size = New System.Drawing.Size(1344, 441)
        Me.dgvProducts.TabIndex = 306
        '
        'Branch_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Branch_Info"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Branch_Info"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents txtAddress As RichTextBox
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents txtTIN As TextBox
    Friend WithEvents txtAccountID As TextBox
    Friend WithEvents txtAccount As TextBox
    Friend WithEvents cboBusType As ComboBox
    Friend WithEvents userPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtBranchID As TextBox
    Friend WithEvents txtBranch As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents txtContact As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboManager As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents dgvProducts As DataGridView
End Class
