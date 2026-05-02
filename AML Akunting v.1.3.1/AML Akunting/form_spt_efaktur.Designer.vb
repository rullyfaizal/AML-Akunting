<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_spt_efaktur
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
        Me.txt_ppn_disetor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_ppn_keluaran = New System.Windows.Forms.TextBox()
        Me.txt_ppn_masukan = New System.Windows.Forms.TextBox()
        Me.txt_nilai_masukan = New System.Windows.Forms.TextBox()
        Me.txt_nilai_keluaran = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.cbo_bulan = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_tahun = New System.Windows.Forms.DateTimePicker()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_ppn_disetor
        '
        Me.txt_ppn_disetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ppn_disetor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ppn_disetor.Location = New System.Drawing.Point(156, 260)
        Me.txt_ppn_disetor.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_ppn_disetor.MaxLength = 100
        Me.txt_ppn_disetor.Name = "txt_ppn_disetor"
        Me.txt_ppn_disetor.ReadOnly = True
        Me.txt_ppn_disetor.Size = New System.Drawing.Size(170, 22)
        Me.txt_ppn_disetor.TabIndex = 3
        Me.txt_ppn_disetor.TabStop = False
        Me.txt_ppn_disetor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1122, 26)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "SPT MASA PPN EFAKTUR"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_ppn_keluaran
        '
        Me.txt_ppn_keluaran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ppn_keluaran.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ppn_keluaran.Location = New System.Drawing.Point(156, 222)
        Me.txt_ppn_keluaran.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_ppn_keluaran.MaxLength = 100
        Me.txt_ppn_keluaran.Name = "txt_ppn_keluaran"
        Me.txt_ppn_keluaran.Size = New System.Drawing.Size(170, 22)
        Me.txt_ppn_keluaran.TabIndex = 2
        Me.txt_ppn_keluaran.TabStop = False
        Me.txt_ppn_keluaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ppn_masukan
        '
        Me.txt_ppn_masukan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ppn_masukan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ppn_masukan.Location = New System.Drawing.Point(156, 184)
        Me.txt_ppn_masukan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_ppn_masukan.MaxLength = 100
        Me.txt_ppn_masukan.Name = "txt_ppn_masukan"
        Me.txt_ppn_masukan.Size = New System.Drawing.Size(170, 22)
        Me.txt_ppn_masukan.TabIndex = 1
        Me.txt_ppn_masukan.TabStop = False
        Me.txt_ppn_masukan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nilai_masukan
        '
        Me.txt_nilai_masukan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nilai_masukan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nilai_masukan.Location = New System.Drawing.Point(156, 108)
        Me.txt_nilai_masukan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_nilai_masukan.MaxLength = 100
        Me.txt_nilai_masukan.Name = "txt_nilai_masukan"
        Me.txt_nilai_masukan.Size = New System.Drawing.Size(170, 22)
        Me.txt_nilai_masukan.TabIndex = 3
        Me.txt_nilai_masukan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nilai_keluaran
        '
        Me.txt_nilai_keluaran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nilai_keluaran.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nilai_keluaran.Location = New System.Drawing.Point(156, 146)
        Me.txt_nilai_keluaran.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_nilai_keluaran.MaxLength = 100
        Me.txt_nilai_keluaran.Name = "txt_nilai_keluaran"
        Me.txt_nilai_keluaran.Size = New System.Drawing.Size(170, 22)
        Me.txt_nilai_keluaran.TabIndex = 4
        Me.txt_nilai_keluaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(31, 326)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 5
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.cbo_bulan)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtp_tahun)
        Me.Panel1.Controls.Add(Me.lbl_dgv1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_ppn_disetor)
        Me.Panel1.Controls.Add(Me.txt_nilai_masukan)
        Me.Panel1.Controls.Add(Me.txt_nilai_keluaran)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.txt_ppn_keluaran)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Controls.Add(Me.txt_ppn_masukan)
        Me.Panel1.Location = New System.Drawing.Point(1, 29)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 490)
        Me.Panel1.TabIndex = 55
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(16, 379)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(100, 22)
        Me.txt_id.TabIndex = 63
        Me.txt_id.Visible = False
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(25, 264)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(91, 14)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "PPN DISETOR"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(25, 226)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 14)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "PPN KELUARAN"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(25, 188)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 14)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "PPN MASUKAN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(25, 150)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 14)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "NILAI KELUARAN"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 112)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 14)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "NILAI MASUKAN"
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(135, 326)
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
        Me.btn_hapus.Location = New System.Drawing.Point(239, 326)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(80, 29)
        Me.btn_hapus.TabIndex = 7
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(355, 29)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(765, 490)
        Me.panel_bukpot.TabIndex = 59
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
        Me.dgv1.Size = New System.Drawing.Size(748, 463)
        Me.dgv1.TabIndex = 47
        Me.dgv1.TabStop = False
        '
        'form_spt_efaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 521)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_spt_efaktur"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panel_bukpot.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_ppn_disetor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ppn_keluaran As System.Windows.Forms.TextBox
    Friend WithEvents txt_ppn_masukan As System.Windows.Forms.TextBox
    Friend WithEvents txt_nilai_masukan As System.Windows.Forms.TextBox
    Friend WithEvents txt_nilai_keluaran As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtp_tahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents cbo_bulan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
End Class
