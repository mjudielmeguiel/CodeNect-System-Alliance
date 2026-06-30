<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TRANSACTION_ID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TRANSACTION_ID))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.adminpic = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(211, 28)
        Me.TextBox1.TabIndex = 145
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Maroon
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(142, 116)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 37)
        Me.Button5.TabIndex = 152
        Me.Button5.Text = "Cancel"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Transaction ID:"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Maroon
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(12, 116)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(124, 37)
        Me.Button7.TabIndex = 169
        Me.Button7.Text = "Search ID"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'adminpic
        '
        Me.adminpic.Image = CType(resources.GetObject("adminpic.Image"), System.Drawing.Image)
        Me.adminpic.Location = New System.Drawing.Point(3, 3)
        Me.adminpic.Name = "adminpic"
        Me.adminpic.Size = New System.Drawing.Size(80, 51)
        Me.adminpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.adminpic.TabIndex = 6
        Me.adminpic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(226, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 28)
        Me.Button1.TabIndex = 146
        Me.Button1.Text = "..."
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Controls.Add(Me.adminpic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(278, 54)
        Me.Panel1.TabIndex = 170
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(92, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 36)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "UPLOADS"
        '
        'TRANSACTION_ID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 165)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TRANSACTION_ID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRANSACTION_ID"
        CType(Me.adminpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents adminpic As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
