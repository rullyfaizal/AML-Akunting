<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_saldo_laporan_hpp
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_akhir_kain_warna = New System.Windows.Forms.TextBox()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.dtp_tahun = New System.Windows.Forms.DateTimePicker()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_awal_kain_warna = New System.Windows.Forms.TextBox()
        Me.txt_awal_tahun_obat = New System.Windows.Forms.TextBox()
        Me.txt_akhir_tahun_obat = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.txt_akhir_kain_proses = New System.Windows.Forms.TextBox()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.txt_awal_kain_proses = New System.Windows.Forms.TextBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_bukpot.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_akhir_kain_warna)
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.dtp_tahun)
        Me.Panel1.Controls.Add(Me.lbl_dgv1)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_awal_kain_warna)
        Me.Panel1.Controls.Add(Me.txt_awal_tahun_obat)
        Me.Panel1.Controls.Add(Me.txt_akhir_tahun_obat)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.txt_akhir_kain_proses)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Controls.Add(Me.txt_awal_kain_proses)
        Me.Panel1.Location = New System.Drawing.Point(2, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(451, 490)
        Me.Panel1.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 264)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 14)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "SALDO AKHIR KAIN WARNA"
        '
        'txt_akhir_kain_warna
        '
        Me.txt_akhir_kain_warna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_akhir_kain_warna.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_akhir_kain_warna.Location = New System.Drawing.Point(260, 260)
        Me.txt_akhir_kain_warna.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_akhir_kain_warna.MaxLength = 100
        Me.txt_akhir_kain_warna.Name = "txt_akhir_kain_warna"
        Me.txt_akhir_kain_warna.Size = New System.Drawing.Size(170, 22)
        Me.txt_akhir_kain_warna.TabIndex = 6
        Me.txt_akhir_kain_warna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(20, 405)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(100, 22)
        Me.txt_id.TabIndex = 63
        Me.txt_id.Visible = False
        '
        'dtp_tahun
        '
        Me.dtp_tahun.CalendarFont = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.CustomFormat = "yyyy"
        Me.dtp_tahun.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun.Location = New System.Drawing.Point(260, 34)
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
        Me.lbl_dgv1.Location = New System.Drawing.Point(21, 40)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(48, 14)
        Me.lbl_dgv1.TabIndex = 60
        Me.lbl_dgv1.Text = "TAHUN"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 227)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(173, 14)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "SALDO AWAL KAIN WARNA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 190)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(225, 14)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "SALDO AKHIR KAIN DALAM PROSES"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 153)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(223, 14)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "SALDO AWAL KAIN DALAM PROSES"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 116)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(182, 14)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "SALDO AKHIR TAHUN (OBAT)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(21, 79)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(180, 14)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "SALDO AWAL TAHUN (OBAT)"
        '
        'txt_awal_kain_warna
        '
        Me.txt_awal_kain_warna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_awal_kain_warna.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_awal_kain_warna.Location = New System.Drawing.Point(260, 223)
        Me.txt_awal_kain_warna.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_awal_kain_warna.MaxLength = 100
        Me.txt_awal_kain_warna.Name = "txt_awal_kain_warna"
        Me.txt_awal_kain_warna.Size = New System.Drawing.Size(170, 22)
        Me.txt_awal_kain_warna.TabIndex = 5
        Me.txt_awal_kain_warna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_awal_tahun_obat
        '
        Me.txt_awal_tahun_obat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_awal_tahun_obat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_awal_tahun_obat.Location = New System.Drawing.Point(260, 75)
        Me.txt_awal_tahun_obat.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_awal_tahun_obat.MaxLength = 100
        Me.txt_awal_tahun_obat.Name = "txt_awal_tahun_obat"
        Me.txt_awal_tahun_obat.Size = New System.Drawing.Size(170, 22)
        Me.txt_awal_tahun_obat.TabIndex = 1
        Me.txt_awal_tahun_obat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_akhir_tahun_obat
        '
        Me.txt_akhir_tahun_obat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_akhir_tahun_obat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_akhir_tahun_obat.Location = New System.Drawing.Point(260, 112)
        Me.txt_akhir_tahun_obat.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_akhir_tahun_obat.MaxLength = 100
        Me.txt_akhir_tahun_obat.Name = "txt_akhir_tahun_obat"
        Me.txt_akhir_tahun_obat.Size = New System.Drawing.Size(170, 22)
        Me.txt_akhir_tahun_obat.TabIndex = 2
        Me.txt_akhir_tahun_obat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(81, 317)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 7
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'txt_akhir_kain_proses
        '
        Me.txt_akhir_kain_proses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_akhir_kain_proses.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_akhir_kain_proses.Location = New System.Drawing.Point(260, 186)
        Me.txt_akhir_kain_proses.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_akhir_kain_proses.MaxLength = 100
        Me.txt_akhir_kain_proses.Name = "txt_akhir_kain_proses"
        Me.txt_akhir_kain_proses.Size = New System.Drawing.Size(170, 22)
        Me.txt_akhir_kain_proses.TabIndex = 4
        Me.txt_akhir_kain_proses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(185, 317)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(80, 29)
        Me.btn_refresh.TabIndex = 8
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_hapus
        '
        Me.btn_hapus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus.Location = New System.Drawing.Point(289, 317)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(80, 29)
        Me.btn_hapus.TabIndex = 9
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'txt_awal_kain_proses
        '
        Me.txt_awal_kain_proses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_awal_kain_proses.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_awal_kain_proses.Location = New System.Drawing.Point(260, 149)
        Me.txt_awal_kain_proses.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_awal_kain_proses.MaxLength = 100
        Me.txt_awal_kain_proses.Name = "txt_awal_kain_proses"
        Me.txt_awal_kain_proses.Size = New System.Drawing.Size(170, 22)
        Me.txt_awal_kain_proses.TabIndex = 3
        Me.txt_awal_kain_proses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.dgv1.Location = New System.Drawing.Point(9, 14)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(430, 463)
        Me.dgv1.TabIndex = 47
        Me.dgv1.TabStop = False
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(456, 30)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(449, 490)
        Me.panel_bukpot.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(1, 1)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(904, 26)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "SALDO LAPORAN HPP"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_saldo_laporan_hpp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 521)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_saldo_laporan_hpp"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_bukpot.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_awal_kain_warna As System.Windows.Forms.TextBox
    Friend WithEvents txt_awal_tahun_obat As System.Windows.Forms.TextBox
    Friend WithEvents txt_akhir_tahun_obat As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents txt_akhir_kain_proses As System.Windows.Forms.TextBox
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents txt_awal_kain_proses As System.Windows.Forms.TextBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_akhir_kain_warna As System.Windows.Forms.TextBox
End Class
