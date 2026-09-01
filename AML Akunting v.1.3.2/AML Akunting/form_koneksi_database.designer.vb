<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_koneksi_database
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
        Me.TxtDbPassword = New System.Windows.Forms.TextBox()
        Me.TxtDbName = New System.Windows.Forms.TextBox()
        Me.TxtDbUser = New System.Windows.Forms.TextBox()
        Me.TxtDbServer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BtnBatal = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDbPassword
        '
        Me.TxtDbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDbPassword.Location = New System.Drawing.Point(134, 59)
        Me.TxtDbPassword.MaxLength = 100
        Me.TxtDbPassword.Name = "TxtDbPassword"
        Me.TxtDbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtDbPassword.Size = New System.Drawing.Size(138, 22)
        Me.TxtDbPassword.TabIndex = 57
        '
        'TxtDbName
        '
        Me.TxtDbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDbName.Location = New System.Drawing.Point(134, 72)
        Me.TxtDbName.MaxLength = 100
        Me.TxtDbName.Name = "TxtDbName"
        Me.TxtDbName.Size = New System.Drawing.Size(138, 22)
        Me.TxtDbName.TabIndex = 62
        Me.TxtDbName.TabStop = False
        Me.TxtDbName.Text = "dbhaotex"
        '
        'TxtDbUser
        '
        Me.TxtDbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDbUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDbUser.Location = New System.Drawing.Point(134, 11)
        Me.TxtDbUser.MaxLength = 100
        Me.TxtDbUser.Name = "TxtDbUser"
        Me.TxtDbUser.Size = New System.Drawing.Size(138, 22)
        Me.TxtDbUser.TabIndex = 2
        Me.TxtDbUser.TabStop = False
        Me.TxtDbUser.Text = "haotex"
        '
        'TxtDbServer
        '
        Me.TxtDbServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDbServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDbServer.Location = New System.Drawing.Point(84, 12)
        Me.TxtDbServer.MaxLength = 100
        Me.TxtDbServer.Name = "TxtDbServer"
        Me.TxtDbServer.Size = New System.Drawing.Size(172, 22)
        Me.TxtDbServer.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtDbServer)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(15, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(276, 49)
        Me.Panel1.TabIndex = 56
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label26.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.Window
        Me.Label26.Location = New System.Drawing.Point(15, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(276, 32)
        Me.Label26.TabIndex = 63
        Me.Label26.Text = "KONEKSI KE DATABASE"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBatal
        '
        Me.BtnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBatal.Location = New System.Drawing.Point(170, 117)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(69, 43)
        Me.BtnBatal.TabIndex = 59
        Me.BtnBatal.TabStop = False
        Me.BtnBatal.Text = "BATAL"
        Me.BtnBatal.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnOk.Location = New System.Drawing.Point(67, 117)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(69, 43)
        Me.BtnOk.TabIndex = 58
        Me.BtnOk.TabStop = False
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'form_koneksi_database
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(307, 169)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtDbPassword)
        Me.Controls.Add(Me.TxtDbName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnBatal)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.TxtDbUser)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "form_koneksi_database"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDbPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtDbName As System.Windows.Forms.TextBox
    Friend WithEvents TxtDbUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtDbServer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BtnBatal As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
End Class
