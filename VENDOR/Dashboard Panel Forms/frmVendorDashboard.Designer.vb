<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVendorDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendorDashboard))
        Me.btnSignOut = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.menupanel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnReturns = New System.Windows.Forms.Button()
        Me.btnCient = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.menupanel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSignOut
        '
        Me.btnSignOut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSignOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSignOut.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSignOut.FlatAppearance.BorderSize = 0
        Me.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignOut.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSignOut.Image = CType(resources.GetObject("btnSignOut.Image"), System.Drawing.Image)
        Me.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSignOut.Location = New System.Drawing.Point(0, 389)
        Me.btnSignOut.Name = "btnSignOut"
        Me.btnSignOut.Size = New System.Drawing.Size(332, 47)
        Me.btnSignOut.TabIndex = 318
        Me.btnSignOut.Text = "Sign Out"
        Me.btnSignOut.UseVisualStyleBackColor = False
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDashboard.Image = CType(resources.GetObject("btnDashboard.Image"), System.Drawing.Image)
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDashboard.Location = New System.Drawing.Point(0, 154)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(332, 47)
        Me.btnDashboard.TabIndex = 319
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'btnProducts
        '
        Me.btnProducts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnProducts.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProducts.FlatAppearance.BorderSize = 0
        Me.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProducts.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProducts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProducts.Image = CType(resources.GetObject("btnProducts.Image"), System.Drawing.Image)
        Me.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProducts.Location = New System.Drawing.Point(0, 201)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(332, 47)
        Me.btnProducts.TabIndex = 315
        Me.btnProducts.Text = "Produt Descriptions"
        Me.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProducts.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(332, 154)
        Me.Panel4.TabIndex = 325
        '
        'menupanel
        '
        Me.menupanel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.menupanel.Controls.Add(Me.Panel3)
        Me.menupanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.menupanel.Location = New System.Drawing.Point(0, 48)
        Me.menupanel.Name = "menupanel"
        Me.menupanel.Size = New System.Drawing.Size(332, 720)
        Me.menupanel.TabIndex = 314
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSignOut)
        Me.Panel3.Controls.Add(Me.btnOrders)
        Me.Panel3.Controls.Add(Me.btnReturns)
        Me.Panel3.Controls.Add(Me.btnCient)
        Me.Panel3.Controls.Add(Me.btnProducts)
        Me.Panel3.Controls.Add(Me.btnDashboard)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(332, 720)
        Me.Panel3.TabIndex = 313
        '
        'btnOrders
        '
        Me.btnOrders.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOrders.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnOrders.FlatAppearance.BorderSize = 0
        Me.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrders.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOrders.Image = CType(resources.GetObject("btnOrders.Image"), System.Drawing.Image)
        Me.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOrders.Location = New System.Drawing.Point(0, 342)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(332, 47)
        Me.btnOrders.TabIndex = 326
        Me.btnOrders.Text = "Orders"
        Me.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrders.UseVisualStyleBackColor = False
        '
        'btnReturns
        '
        Me.btnReturns.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReturns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReturns.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReturns.FlatAppearance.BorderSize = 0
        Me.btnReturns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturns.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturns.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReturns.Image = CType(resources.GetObject("btnReturns.Image"), System.Drawing.Image)
        Me.btnReturns.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReturns.Location = New System.Drawing.Point(0, 295)
        Me.btnReturns.Name = "btnReturns"
        Me.btnReturns.Size = New System.Drawing.Size(332, 47)
        Me.btnReturns.TabIndex = 327
        Me.btnReturns.Text = "Returns"
        Me.btnReturns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReturns.UseVisualStyleBackColor = False
        '
        'btnCient
        '
        Me.btnCient.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCient.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCient.FlatAppearance.BorderSize = 0
        Me.btnCient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCient.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCient.Image = CType(resources.GetObject("btnCient.Image"), System.Drawing.Image)
        Me.btnCient.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCient.Location = New System.Drawing.Point(0, 248)
        Me.btnCient.Name = "btnCient"
        Me.btnCient.Size = New System.Drawing.Size(332, 47)
        Me.btnCient.TabIndex = 328
        Me.btnCient.Text = "Client List"
        Me.btnCient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCient.UseVisualStyleBackColor = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(60, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor Dashbooard"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 48)
        Me.Panel1.TabIndex = 313
        '
        'Panelmenu
        '
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelmenu.Location = New System.Drawing.Point(332, 48)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(1034, 720)
        Me.Panelmenu.TabIndex = 315
        '
        'frmVendorDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panelmenu)
        Me.Controls.Add(Me.menupanel)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVendorDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVendorDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menupanel.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSignOut As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents menupanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button10 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReturns As Button
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnCient As Button
    Friend WithEvents Panelmenu As Panel
End Class
