<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_upah_dan_gaji
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.cbo_bulan = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_tahun = New System.Windows.Forms.DateTimePicker()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_upah = New System.Windows.Forms.TextBox()
        Me.txt_gaji = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(19, 274)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(100, 22)
        Me.txt_id.TabIndex = 63
        Me.txt_id.Visible = False
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(355, 30)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(417, 340)
        Me.panel_bukpot.TabIndex = 62
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(8, 14)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(400, 310)
        Me.dgv1.TabIndex = 47
        Me.dgv1.TabStop = False
        '
        'cbo_bulan
        '
        Me.cbo_bulan.FormattingEnabled = True
        Me.cbo_bulan.Items.AddRange(New Object() {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.cbo_bulan.Location = New System.Drawing.Point(156, 70)
        Me.cbo_bulan.Name = "cbo_bulan"
        Me.cbo_bulan.Size = New System.Drawing.Size(121, 22)
        Me.cbo_bulan.TabIndex = 2
        Me.cbo_bulan.Text = "-- Pilih Bulan --"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.cbo_bulan)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtp_tahun)
        Me.Panel1.Controls.Add(Me.lbl_dgv1)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_upah)
        Me.Panel1.Controls.Add(Me.txt_gaji)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Location = New System.Drawing.Point(1, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 340)
        Me.Panel1.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 74)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "BULAN"
        '
        'dtp_tahun
        '
        Me.dtp_tahun.CalendarFont = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.CustomFormat = "yyyy"
        Me.dtp_tahun.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun.Location = New System.Drawing.Point(156, 30)
        Me.dtp_tahun.Name = "dtp_tahun"
        Me.dtp_tahun.ShowUpDown = True
        Me.dtp_tahun.Size = New System.Drawing.Size(71, 26)
        Me.dtp_tahun.TabIndex = 1
        '
        'lbl_dgv1
        '
        Me.lbl_dgv1.AutoSize = True
        Me.lbl_dgv1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dgv1.Location = New System.Drawing.Point(25, 36)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(48, 14)
        Me.lbl_dgv1.TabIndex = 60
        Me.lbl_dgv1.Text = "TAHUN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(25, 150)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 14)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "GAJI PEGAWAI"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 112)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 14)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "UPAH HARIAN"
        '
        'txt_upah
        '
        Me.txt_upah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_upah.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_upah.Location = New System.Drawing.Point(156, 108)
        Me.txt_upah.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_upah.MaxLength = 100
        Me.txt_upah.Name = "txt_upah"
        Me.txt_upah.Size = New System.Drawing.Size(170, 22)
        Me.txt_upah.TabIndex = 3
        Me.txt_upah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_gaji
        '
        Me.txt_gaji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gaji.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gaji.Location = New System.Drawing.Point(156, 146)
        Me.txt_gaji.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_gaji.MaxLength = 100
        Me.txt_gaji.Name = "txt_gaji"
        Me.txt_gaji.Size = New System.Drawing.Size(170, 22)
        Me.txt_gaji.TabIndex = 4
        Me.txt_gaji.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(31, 221)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 5
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(135, 221)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(80, 29)
        Me.btn_refresh.TabIndex = 6
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_hapus
        '
        Me.btn_hapus.Enabled = False
        Me.btn_hapus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus.Location = New System.Drawing.Point(239, 221)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(80, 29)
        Me.btn_hapus.TabIndex = 7
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(1, 1)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(771, 26)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "UPAH DAN GAJI"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_upah_dan_gaji
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 374)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_upah_dan_gaji"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel_bukpot.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_bulan As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_tahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_upah As System.Windows.Forms.TextBox
    Friend WithEvents txt_gaji As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
