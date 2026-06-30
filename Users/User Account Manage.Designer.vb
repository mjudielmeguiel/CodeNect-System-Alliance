<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class User_Account_Manage
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
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDRESS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BUSINESS_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(82, 9)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(880, 26)
        Me.txtSearch.TabIndex = 212
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboUserType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Location = New System.Drawing.Point(12, 708)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 48)
        Me.Panel1.TabIndex = 223
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 19)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Search :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(967, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "Designaton :"
        '
        'cboUserType
        '
        Me.cboUserType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Location = New System.Drawing.Point(1059, 8)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(269, 28)
        Me.cboUserType.TabIndex = 225
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CONTACT"
        Me.DataGridViewTextBoxColumn7.HeaderText = "CONTACT"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 97
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EMAIL"
        Me.DataGridViewTextBoxColumn6.HeaderText = "EMAIL"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 74
        '
        'ADDRESS
        '
        Me.ADDRESS.DataPropertyName = "ADDRESS"
        Me.ADDRESS.HeaderText = "ADDRESS"
        Me.ADDRESS.Name = "ADDRESS"
        '
        'TIN
        '
        Me.TIN.DataPropertyName = "TIN"
        Me.TIN.HeaderText = "TIN"
        Me.TIN.Name = "TIN"
        '
        'BUSINESS_TYPE
        '
        Me.BUSINESS_TYPE.DataPropertyName = "BUSINESS_TYPE"
        Me.BUSINESS_TYPE.HeaderText = "BUSINESS_TYPE"
        Me.BUSINESS_TYPE.Name = "BUSINESS_TYPE"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BRANCH"
        Me.DataGridViewTextBoxColumn5.HeaderText = "BRANCH"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 89
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BRANCH ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "BRANCH ID"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 107
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ACCOUNT"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ACCOUNT"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ACCOUNT ID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ACCOUNT ID"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Width = 118
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.AllowUserToDeleteRows = False
        Me.dgvUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(12, 12)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(1342, 690)
        Me.dgvUsers.TabIndex = 224
        '
        'User_Account_Manage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "User_Account_Manage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User_Account_Manage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents ADDRESS As DataGridViewTextBoxColumn
    Friend WithEvents TIN As DataGridViewTextBoxColumn
    Friend WithEvents BUSINESS_TYPE As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents cboUserType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
