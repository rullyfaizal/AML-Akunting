<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_biaya_tahunan
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtp_tahun = New System.Windows.Forms.DateTimePicker()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_pbb = New System.Windows.Forms.TextBox()
        Me.txt_upah_harian = New System.Windows.Forms.TextBox()
        Me.txt_gaji_pegawai = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.txt_sewa_kantor = New System.Windows.Forms.TextBox()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.txt_sewa_pabrik = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(20, 348)
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
        Me.panel_bukpot.Size = New System.Drawing.Size(399, 490)
        Me.panel_bukpot.TabIndex = 62
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(9, 14)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(380, 463)
        Me.dgv1.TabIndex = 47
        Me.dgv1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.dtp_tahun)
        Me.Panel1.Controls.Add(Me.lbl_dgv1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_pbb)
        Me.Panel1.Controls.Add(Me.txt_upah_harian)
        Me.Panel1.Controls.Add(Me.txt_gaji_pegawai)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.txt_sewa_kantor)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Controls.Add(Me.txt_sewa_pabrik)
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 490)
        Me.Panel1.TabIndex = 61
        '
        'dtp_tahun
        '
        Me.dtp_tahun.CalendarFont = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.CustomFormat = "yyyy"
        Me.dtp_tahun.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun.Location = New System.Drawing.Point(160, 34)
        Me.dtp_tahun.Name = "dtp_tahun"
        Me.dtp_tahun.ShowUpDown = True
        Me.dtp_tahun.Size = New System.Drawing.Size(71, 26)
        Me.dtp_tahun.TabIndex = 1
        Me.dtp_tahun.TabStop = False
        '
        'lbl_dgv1
        '
        Me.lbl_dgv1.AutoSize = True
        Me.lbl_dgv1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dgv1.Location = New System.Drawing.Point(29, 40)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(48, 14)
        Me.lbl_dgv1.TabIndex = 60
        Me.lbl_dgv1.Text = "TAHUN"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(29, 233)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 14)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "PBB"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(29, 195)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 14)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "SEWA KANTOR"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(29, 157)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 14)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "SEWA PABRIK"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(29, 119)
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
        Me.Label14.Location = New System.Drawing.Point(29, 80)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 14)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "UPAH HARIAN"
        '
        'txt_pbb
        '
        Me.txt_pbb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pbb.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pbb.Location = New System.Drawing.Point(160, 229)
        Me.txt_pbb.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_pbb.MaxLength = 100
        Me.txt_pbb.Name = "txt_pbb"
        Me.txt_pbb.Size = New System.Drawing.Size(170, 22)
        Me.txt_pbb.TabIndex = 5
        Me.txt_pbb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_upah_harian
        '
        Me.txt_upah_harian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_upah_harian.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_upah_harian.Location = New System.Drawing.Point(160, 76)
        Me.txt_upah_harian.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_upah_harian.MaxLength = 100
        Me.txt_upah_harian.Name = "txt_upah_harian"
        Me.txt_upah_harian.ReadOnly = True
        Me.txt_upah_harian.Size = New System.Drawing.Size(170, 22)
        Me.txt_upah_harian.TabIndex = 1
        Me.txt_upah_harian.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_gaji_pegawai
        '
        Me.txt_gaji_pegawai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gaji_pegawai.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gaji_pegawai.Location = New System.Drawing.Point(160, 115)
        Me.txt_gaji_pegawai.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_gaji_pegawai.MaxLength = 100
        Me.txt_gaji_pegawai.Name = "txt_gaji_pegawai"
        Me.txt_gaji_pegawai.ReadOnly = True
        Me.txt_gaji_pegawai.Size = New System.Drawing.Size(170, 22)
        Me.txt_gaji_pegawai.TabIndex = 2
        Me.txt_gaji_pegawai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(35, 295)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 6
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'txt_sewa_kantor
        '
        Me.txt_sewa_kantor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sewa_kantor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sewa_kantor.Location = New System.Drawing.Point(160, 191)
        Me.txt_sewa_kantor.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_sewa_kantor.MaxLength = 100
        Me.txt_sewa_kantor.Name = "txt_sewa_kantor"
        Me.txt_sewa_kantor.Size = New System.Drawing.Size(170, 22)
        Me.txt_sewa_kantor.TabIndex = 4
        Me.txt_sewa_kantor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(139, 295)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(80, 29)
        Me.btn_refresh.TabIndex = 7
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_hapus
        '
        Me.btn_hapus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus.Location = New System.Drawing.Point(243, 295)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(80, 29)
        Me.btn_hapus.TabIndex = 8
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'txt_sewa_pabrik
        '
        Me.txt_sewa_pabrik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sewa_pabrik.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sewa_pabrik.Location = New System.Drawing.Point(160, 153)
        Me.txt_sewa_pabrik.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_sewa_pabrik.MaxLength = 100
        Me.txt_sewa_pabrik.Name = "txt_sewa_pabrik"
        Me.txt_sewa_pabrik.Size = New System.Drawing.Size(170, 22)
        Me.txt_sewa_pabrik.TabIndex = 3
        Me.txt_sewa_pabrik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(0, 1)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(754, 26)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "BIAYA TAHUNAN"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form_biaya_tahunan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 521)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form_biaya_tahunan"
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtp_tahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_pbb As System.Windows.Forms.TextBox
    Friend WithEvents txt_upah_harian As System.Windows.Forms.TextBox
    Friend WithEvents txt_gaji_pegawai As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents txt_sewa_kantor As System.Windows.Forms.TextBox
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents txt_sewa_pabrik As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
