<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_input_biaya_penyusutan
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
        Me.cbo_aset = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pn_input = New System.Windows.Forms.Panel()
        Me.dtp_tahun = New System.Windows.Forms.DateTimePicker()
        Me.txt_nama_aset = New System.Windows.Forms.TextBox()
        Me.txt_nilai_buku = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_kode = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pn_input.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(68, 281)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.ReadOnly = True
        Me.txt_id.Size = New System.Drawing.Size(170, 22)
        Me.txt_id.TabIndex = 63
        Me.txt_id.Visible = False
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(373, 30)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(468, 488)
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
        Me.dgv1.Location = New System.Drawing.Point(7, 9)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(454, 470)
        Me.dgv1.TabIndex = 47
        Me.dgv1.TabStop = False
        '
        'cbo_aset
        '
        Me.cbo_aset.FormattingEnabled = True
        Me.cbo_aset.Items.AddRange(New Object() {"MESIN", "INVENTARIS", "BANGUNAN", "KENDARAAN", "TANKI PENGOLAH LIMBAH"})
        Me.cbo_aset.Location = New System.Drawing.Point(131, 58)
        Me.cbo_aset.Name = "cbo_aset"
        Me.cbo_aset.Size = New System.Drawing.Size(210, 22)
        Me.cbo_aset.TabIndex = 2
        Me.cbo_aset.Text = "-- Pilih Aset --"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.pn_input)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txt_kode)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Location = New System.Drawing.Point(3, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(367, 488)
        Me.Panel1.TabIndex = 61
        '
        'pn_input
        '
        Me.pn_input.Controls.Add(Me.dtp_tahun)
        Me.pn_input.Controls.Add(Me.txt_nama_aset)
        Me.pn_input.Controls.Add(Me.txt_nilai_buku)
        Me.pn_input.Controls.Add(Me.cbo_aset)
        Me.pn_input.Controls.Add(Me.Label14)
        Me.pn_input.Controls.Add(Me.Label1)
        Me.pn_input.Controls.Add(Me.Label15)
        Me.pn_input.Controls.Add(Me.lbl_dgv1)
        Me.pn_input.Location = New System.Drawing.Point(4, 4)
        Me.pn_input.Name = "pn_input"
        Me.pn_input.Size = New System.Drawing.Size(359, 175)
        Me.pn_input.TabIndex = 65
        '
        'dtp_tahun
        '
        Me.dtp_tahun.CalendarFont = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.CustomFormat = "yyyy"
        Me.dtp_tahun.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun.Location = New System.Drawing.Point(131, 20)
        Me.dtp_tahun.Name = "dtp_tahun"
        Me.dtp_tahun.ShowUpDown = True
        Me.dtp_tahun.Size = New System.Drawing.Size(71, 26)
        Me.dtp_tahun.TabIndex = 1
        '
        'txt_nama_aset
        '
        Me.txt_nama_aset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nama_aset.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nama_aset.Location = New System.Drawing.Point(131, 94)
        Me.txt_nama_aset.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_nama_aset.MaxLength = 100
        Me.txt_nama_aset.Name = "txt_nama_aset"
        Me.txt_nama_aset.Size = New System.Drawing.Size(170, 22)
        Me.txt_nama_aset.TabIndex = 4
        '
        'txt_nilai_buku
        '
        Me.txt_nilai_buku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nilai_buku.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nilai_buku.Location = New System.Drawing.Point(131, 130)
        Me.txt_nilai_buku.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_nilai_buku.MaxLength = 100
        Me.txt_nilai_buku.Name = "txt_nilai_buku"
        Me.txt_nilai_buku.Size = New System.Drawing.Size(110, 22)
        Me.txt_nilai_buku.TabIndex = 3
        Me.txt_nilai_buku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 134)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 14)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "NILAI BUKU"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 14)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "KATEGORI ASET"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 98)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 14)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "NAMA ASET"
        '
        'lbl_dgv1
        '
        Me.lbl_dgv1.AutoSize = True
        Me.lbl_dgv1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dgv1.Location = New System.Drawing.Point(18, 26)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(48, 14)
        Me.lbl_dgv1.TabIndex = 60
        Me.lbl_dgv1.Text = "TAHUN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 281)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 14)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Id"
        Me.Label2.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 312)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 14)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Kode"
        Me.Label18.Visible = False
        '
        'txt_kode
        '
        Me.txt_kode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kode.Location = New System.Drawing.Point(68, 310)
        Me.txt_kode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_kode.MaxLength = 100
        Me.txt_kode.Name = "txt_kode"
        Me.txt_kode.ReadOnly = True
        Me.txt_kode.Size = New System.Drawing.Size(170, 22)
        Me.txt_kode.TabIndex = 3
        Me.txt_kode.TabStop = False
        Me.txt_kode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_kode.Visible = False
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(83, 199)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 5
        Me.btn_simpan.Text = "GENERATE"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(203, 199)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(80, 29)
        Me.btn_refresh.TabIndex = 6
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(0, 1)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(845, 26)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "INPUT PENYUSUTAN"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_input_biaya_penyusutan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 521)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_input_biaya_penyusutan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel_bukpot.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pn_input.ResumeLayout(False)
        Me.pn_input.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_aset As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_tahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_kode As System.Windows.Forms.TextBox
    Friend WithEvents txt_nilai_buku As System.Windows.Forms.TextBox
    Friend WithEvents txt_nama_aset As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pn_input As System.Windows.Forms.Panel
End Class
