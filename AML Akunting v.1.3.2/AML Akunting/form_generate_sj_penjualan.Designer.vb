<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_generate_sj_penjualan
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv3 = New System.Windows.Forms.DataGridView()
        Me.btn_sj_turun = New System.Windows.Forms.Button()
        Me.btn_sj_naik = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_surat_jalan_akhir = New System.Windows.Forms.TextBox()
        Me.txt_surat_jalan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_jumlah_baris = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_no_faktur_akhir = New System.Windows.Forms.TextBox()
        Me.txt_no_faktur = New System.Windows.Forms.TextBox()
        Me.txt_tanggal_cari = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_cari = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_hapus_cari = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.btn_generate = New System.Windows.Forms.Button()
        Me.btn_faktur_naik = New System.Windows.Forms.Button()
        Me.btn_faktur_turun = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_faktur_hapus = New System.Windows.Forms.Button()
        Me.btn_faktur_tambah = New System.Windows.Forms.Button()
        Me.btn_sj_hapus = New System.Windows.Forms.Button()
        Me.btn_sj_tambah = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.panel_tambah_sj = New System.Windows.Forms.Panel()
        Me.btn_cancel_sj = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_tambah_sj = New System.Windows.Forms.Button()
        Me.txt_tambah_sj = New System.Windows.Forms.TextBox()
        Me.panel_tambah_faktur = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_tambah_no_faktur = New System.Windows.Forms.TextBox()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panel_tambah_sj.SuspendLayout()
        Me.panel_tambah_faktur.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv3.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv3.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv3.Location = New System.Drawing.Point(1, 123)
        Me.dgv3.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv3.MultiSelect = False
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.Size = New System.Drawing.Size(230, 385)
        Me.dgv3.TabIndex = 150
        '
        'btn_sj_turun
        '
        Me.btn_sj_turun.BackColor = System.Drawing.SystemColors.Window
        Me.btn_sj_turun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sj_turun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sj_turun.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sj_turun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sj_turun.Location = New System.Drawing.Point(164, 12)
        Me.btn_sj_turun.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_sj_turun.Name = "btn_sj_turun"
        Me.btn_sj_turun.Size = New System.Drawing.Size(38, 30)
        Me.btn_sj_turun.TabIndex = 151
        Me.btn_sj_turun.TabStop = False
        Me.btn_sj_turun.Text = ">"
        Me.btn_sj_turun.UseMnemonic = False
        Me.btn_sj_turun.UseVisualStyleBackColor = False
        '
        'btn_sj_naik
        '
        Me.btn_sj_naik.BackColor = System.Drawing.SystemColors.Window
        Me.btn_sj_naik.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sj_naik.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sj_naik.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sj_naik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sj_naik.Location = New System.Drawing.Point(26, 12)
        Me.btn_sj_naik.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_sj_naik.Name = "btn_sj_naik"
        Me.btn_sj_naik.Size = New System.Drawing.Size(38, 30)
        Me.btn_sj_naik.TabIndex = 152
        Me.btn_sj_naik.TabStop = False
        Me.btn_sj_naik.Text = "<"
        Me.btn_sj_naik.UseMnemonic = False
        Me.btn_sj_naik.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txt_surat_jalan_akhir)
        Me.Panel3.Controls.Add(Me.txt_surat_jalan)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txt_jumlah_baris)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txt_no_faktur_akhir)
        Me.Panel3.Controls.Add(Me.txt_no_faktur)
        Me.Panel3.Controls.Add(Me.txt_tanggal_cari)
        Me.Panel3.Controls.Add(Me.dtp_tanggal_cari)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btn_hapus_cari)
        Me.Panel3.Location = New System.Drawing.Point(1, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1116, 89)
        Me.Panel3.TabIndex = 515
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1048, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 14)
        Me.Label6.TabIndex = 523
        Me.Label6.Text = "Lembar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 522
        Me.Label4.Text = "Surat Jalan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 521
        Me.Label5.Text = "s/d"
        '
        'txt_surat_jalan_akhir
        '
        Me.txt_surat_jalan_akhir.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_surat_jalan_akhir.Location = New System.Drawing.Point(287, 46)
        Me.txt_surat_jalan_akhir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_surat_jalan_akhir.Name = "txt_surat_jalan_akhir"
        Me.txt_surat_jalan_akhir.ReadOnly = True
        Me.txt_surat_jalan_akhir.Size = New System.Drawing.Size(164, 23)
        Me.txt_surat_jalan_akhir.TabIndex = 520
        Me.txt_surat_jalan_akhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_surat_jalan
        '
        Me.txt_surat_jalan.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_surat_jalan.Location = New System.Drawing.Point(96, 46)
        Me.txt_surat_jalan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_surat_jalan.Name = "txt_surat_jalan"
        Me.txt_surat_jalan.Size = New System.Drawing.Size(164, 23)
        Me.txt_surat_jalan.TabIndex = 519
        Me.txt_surat_jalan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(520, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 518
        Me.Label2.Text = "No Faktur"
        '
        'txt_jumlah_baris
        '
        Me.txt_jumlah_baris.Location = New System.Drawing.Point(1005, 46)
        Me.txt_jumlah_baris.MaxLength = 3
        Me.txt_jumlah_baris.Name = "txt_jumlah_baris"
        Me.txt_jumlah_baris.Size = New System.Drawing.Size(41, 22)
        Me.txt_jumlah_baris.TabIndex = 517
        Me.txt_jumlah_baris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(754, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 516
        Me.Label1.Text = "s/d"
        '
        'txt_no_faktur_akhir
        '
        Me.txt_no_faktur_akhir.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_faktur_akhir.Location = New System.Drawing.Point(782, 46)
        Me.txt_no_faktur_akhir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_no_faktur_akhir.Name = "txt_no_faktur_akhir"
        Me.txt_no_faktur_akhir.ReadOnly = True
        Me.txt_no_faktur_akhir.Size = New System.Drawing.Size(164, 23)
        Me.txt_no_faktur_akhir.TabIndex = 515
        Me.txt_no_faktur_akhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_no_faktur
        '
        Me.txt_no_faktur.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_faktur.Location = New System.Drawing.Point(590, 46)
        Me.txt_no_faktur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_no_faktur.Name = "txt_no_faktur"
        Me.txt_no_faktur.Size = New System.Drawing.Size(164, 23)
        Me.txt_no_faktur.TabIndex = 514
        Me.txt_no_faktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_tanggal_cari
        '
        Me.txt_tanggal_cari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_cari.Location = New System.Drawing.Point(492, 8)
        Me.txt_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_cari.Name = "txt_tanggal_cari"
        Me.txt_tanggal_cari.ReadOnly = True
        Me.txt_tanggal_cari.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_cari.TabIndex = 511
        Me.txt_tanggal_cari.TabStop = False
        Me.txt_tanggal_cari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_tanggal_cari
        '
        Me.dtp_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_cari.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_cari.Location = New System.Drawing.Point(625, 8)
        Me.dtp_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_cari.Name = "dtp_tanggal_cari"
        Me.dtp_tanggal_cari.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_cari.TabIndex = 510
        Me.dtp_tanggal_cari.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(444, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 513
        Me.Label3.Text = "Bulan"
        '
        'btn_hapus_cari
        '
        Me.btn_hapus_cari.BackColor = System.Drawing.SystemColors.Window
        Me.btn_hapus_cari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_hapus_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hapus_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus_cari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus_cari.Location = New System.Drawing.Point(643, 8)
        Me.btn_hapus_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_hapus_cari.Name = "btn_hapus_cari"
        Me.btn_hapus_cari.Size = New System.Drawing.Size(27, 22)
        Me.btn_hapus_cari.TabIndex = 512
        Me.btn_hapus_cari.TabStop = False
        Me.btn_hapus_cari.Text = "X"
        Me.btn_hapus_cari.UseMnemonic = False
        Me.btn_hapus_cari.UseVisualStyleBackColor = False
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
        Me.dgv1.Location = New System.Drawing.Point(468, 123)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(649, 385)
        Me.dgv1.TabIndex = 516
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(234, 123)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(230, 385)
        Me.dgv2.TabIndex = 517
        '
        'btn_generate
        '
        Me.btn_generate.BackColor = System.Drawing.SystemColors.Window
        Me.btn_generate.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generate.Location = New System.Drawing.Point(147, 10)
        Me.btn_generate.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_generate.Name = "btn_generate"
        Me.btn_generate.Size = New System.Drawing.Size(132, 34)
        Me.btn_generate.TabIndex = 518
        Me.btn_generate.Text = "GENERATE"
        Me.btn_generate.UseVisualStyleBackColor = False
        '
        'btn_faktur_naik
        '
        Me.btn_faktur_naik.BackColor = System.Drawing.SystemColors.Window
        Me.btn_faktur_naik.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_faktur_naik.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_faktur_naik.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_faktur_naik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_faktur_naik.Location = New System.Drawing.Point(26, 12)
        Me.btn_faktur_naik.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_faktur_naik.Name = "btn_faktur_naik"
        Me.btn_faktur_naik.Size = New System.Drawing.Size(38, 30)
        Me.btn_faktur_naik.TabIndex = 520
        Me.btn_faktur_naik.TabStop = False
        Me.btn_faktur_naik.Text = "<"
        Me.btn_faktur_naik.UseMnemonic = False
        Me.btn_faktur_naik.UseVisualStyleBackColor = False
        '
        'btn_faktur_turun
        '
        Me.btn_faktur_turun.BackColor = System.Drawing.SystemColors.Window
        Me.btn_faktur_turun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_faktur_turun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_faktur_turun.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_faktur_turun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_faktur_turun.Location = New System.Drawing.Point(164, 12)
        Me.btn_faktur_turun.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_faktur_turun.Name = "btn_faktur_turun"
        Me.btn_faktur_turun.Size = New System.Drawing.Size(38, 30)
        Me.btn_faktur_turun.TabIndex = 519
        Me.btn_faktur_turun.TabStop = False
        Me.btn_faktur_turun.Text = ">"
        Me.btn_faktur_turun.UseMnemonic = False
        Me.btn_faktur_turun.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(2, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1116, 26)
        Me.Label7.TabIndex = 521
        Me.Label7.Text = "GENERATE SURAT JALAN DAN NO FAKTUR"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_simpan
        '
        Me.btn_simpan.BackColor = System.Drawing.SystemColors.Window
        Me.btn_simpan.Enabled = False
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(369, 10)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(132, 34)
        Me.btn_simpan.TabIndex = 522
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.btn_generate)
        Me.Panel1.Location = New System.Drawing.Point(468, 511)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 57)
        Me.Panel1.TabIndex = 523
        '
        'btn_faktur_hapus
        '
        Me.btn_faktur_hapus.BackColor = System.Drawing.SystemColors.Window
        Me.btn_faktur_hapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_faktur_hapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_faktur_hapus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_faktur_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_faktur_hapus.Location = New System.Drawing.Point(118, 12)
        Me.btn_faktur_hapus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_faktur_hapus.Name = "btn_faktur_hapus"
        Me.btn_faktur_hapus.Size = New System.Drawing.Size(38, 30)
        Me.btn_faktur_hapus.TabIndex = 526
        Me.btn_faktur_hapus.TabStop = False
        Me.btn_faktur_hapus.Text = "X"
        Me.btn_faktur_hapus.UseMnemonic = False
        Me.btn_faktur_hapus.UseVisualStyleBackColor = False
        '
        'btn_faktur_tambah
        '
        Me.btn_faktur_tambah.BackColor = System.Drawing.SystemColors.Window
        Me.btn_faktur_tambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_faktur_tambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_faktur_tambah.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_faktur_tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_faktur_tambah.Location = New System.Drawing.Point(72, 12)
        Me.btn_faktur_tambah.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_faktur_tambah.Name = "btn_faktur_tambah"
        Me.btn_faktur_tambah.Size = New System.Drawing.Size(38, 30)
        Me.btn_faktur_tambah.TabIndex = 525
        Me.btn_faktur_tambah.TabStop = False
        Me.btn_faktur_tambah.Text = "+"
        Me.btn_faktur_tambah.UseMnemonic = False
        Me.btn_faktur_tambah.UseVisualStyleBackColor = False
        '
        'btn_sj_hapus
        '
        Me.btn_sj_hapus.BackColor = System.Drawing.SystemColors.Window
        Me.btn_sj_hapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sj_hapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sj_hapus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sj_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sj_hapus.Location = New System.Drawing.Point(118, 12)
        Me.btn_sj_hapus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_sj_hapus.Name = "btn_sj_hapus"
        Me.btn_sj_hapus.Size = New System.Drawing.Size(38, 30)
        Me.btn_sj_hapus.TabIndex = 524
        Me.btn_sj_hapus.TabStop = False
        Me.btn_sj_hapus.Text = "X"
        Me.btn_sj_hapus.UseMnemonic = False
        Me.btn_sj_hapus.UseVisualStyleBackColor = False
        '
        'btn_sj_tambah
        '
        Me.btn_sj_tambah.BackColor = System.Drawing.SystemColors.Window
        Me.btn_sj_tambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sj_tambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sj_tambah.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sj_tambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sj_tambah.Location = New System.Drawing.Point(72, 12)
        Me.btn_sj_tambah.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_sj_tambah.Name = "btn_sj_tambah"
        Me.btn_sj_tambah.Size = New System.Drawing.Size(38, 30)
        Me.btn_sj_tambah.TabIndex = 523
        Me.btn_sj_tambah.TabStop = False
        Me.btn_sj_tambah.Text = "+"
        Me.btn_sj_tambah.UseMnemonic = False
        Me.btn_sj_tambah.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_faktur_turun)
        Me.Panel2.Controls.Add(Me.btn_faktur_naik)
        Me.Panel2.Controls.Add(Me.btn_faktur_hapus)
        Me.Panel2.Controls.Add(Me.btn_faktur_tambah)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(234, 511)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(230, 57)
        Me.Panel2.TabIndex = 524
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btn_sj_tambah)
        Me.Panel4.Controls.Add(Me.btn_sj_naik)
        Me.Panel4.Controls.Add(Me.btn_sj_turun)
        Me.Panel4.Controls.Add(Me.btn_sj_hapus)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(1, 511)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(230, 57)
        Me.Panel4.TabIndex = 525
        '
        'panel_tambah_sj
        '
        Me.panel_tambah_sj.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_tambah_sj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_tambah_sj.Controls.Add(Me.btn_cancel_sj)
        Me.panel_tambah_sj.Controls.Add(Me.Label10)
        Me.panel_tambah_sj.Controls.Add(Me.btn_tambah_sj)
        Me.panel_tambah_sj.Controls.Add(Me.txt_tambah_sj)
        Me.panel_tambah_sj.Location = New System.Drawing.Point(433, 208)
        Me.panel_tambah_sj.Name = "panel_tambah_sj"
        Me.panel_tambah_sj.Size = New System.Drawing.Size(255, 154)
        Me.panel_tambah_sj.TabIndex = 526
        Me.panel_tambah_sj.Visible = False
        '
        'btn_cancel_sj
        '
        Me.btn_cancel_sj.BackColor = System.Drawing.SystemColors.Window
        Me.btn_cancel_sj.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel_sj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancel_sj.Location = New System.Drawing.Point(138, 99)
        Me.btn_cancel_sj.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cancel_sj.Name = "btn_cancel_sj"
        Me.btn_cancel_sj.Size = New System.Drawing.Size(88, 30)
        Me.btn_cancel_sj.TabIndex = 528
        Me.btn_cancel_sj.Text = "TUTUP"
        Me.btn_cancel_sj.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Window
        Me.Label10.Location = New System.Drawing.Point(-1, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(255, 26)
        Me.Label10.TabIndex = 527
        Me.Label10.Text = "TAMBAH SURAT JALAN"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_tambah_sj
        '
        Me.btn_tambah_sj.BackColor = System.Drawing.SystemColors.Window
        Me.btn_tambah_sj.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tambah_sj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_tambah_sj.Location = New System.Drawing.Point(27, 99)
        Me.btn_tambah_sj.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_tambah_sj.Name = "btn_tambah_sj"
        Me.btn_tambah_sj.Size = New System.Drawing.Size(88, 30)
        Me.btn_tambah_sj.TabIndex = 526
        Me.btn_tambah_sj.Text = "TAMBAH"
        Me.btn_tambah_sj.UseVisualStyleBackColor = False
        '
        'txt_tambah_sj
        '
        Me.txt_tambah_sj.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tambah_sj.Location = New System.Drawing.Point(27, 48)
        Me.txt_tambah_sj.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tambah_sj.Name = "txt_tambah_sj"
        Me.txt_tambah_sj.Size = New System.Drawing.Size(199, 23)
        Me.txt_tambah_sj.TabIndex = 522
        Me.txt_tambah_sj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'panel_tambah_faktur
        '
        Me.panel_tambah_faktur.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_tambah_faktur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_tambah_faktur.Controls.Add(Me.Button1)
        Me.panel_tambah_faktur.Controls.Add(Me.Label8)
        Me.panel_tambah_faktur.Controls.Add(Me.Button2)
        Me.panel_tambah_faktur.Controls.Add(Me.txt_tambah_no_faktur)
        Me.panel_tambah_faktur.Location = New System.Drawing.Point(433, 208)
        Me.panel_tambah_faktur.Name = "panel_tambah_faktur"
        Me.panel_tambah_faktur.Size = New System.Drawing.Size(255, 154)
        Me.panel_tambah_faktur.TabIndex = 529
        Me.panel_tambah_faktur.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Window
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(138, 99)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 528
        Me.Button1.Text = "TUTUP"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(-1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(255, 26)
        Me.Label8.TabIndex = 527
        Me.Label8.Text = "TAMBAH NO FAKTUR"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Window
        Me.Button2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(27, 99)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 30)
        Me.Button2.TabIndex = 526
        Me.Button2.Text = "TAMBAH"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txt_tambah_no_faktur
        '
        Me.txt_tambah_no_faktur.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tambah_no_faktur.Location = New System.Drawing.Point(27, 48)
        Me.txt_tambah_no_faktur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tambah_no_faktur.Name = "txt_tambah_no_faktur"
        Me.txt_tambah_no_faktur.Size = New System.Drawing.Size(199, 23)
        Me.txt_tambah_no_faktur.TabIndex = 522
        Me.txt_tambah_no_faktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'form_generate_sj_penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 571)
        Me.Controls.Add(Me.panel_tambah_faktur)
        Me.Controls.Add(Me.panel_tambah_sj)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv3)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_generate_sj_penjualan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.panel_tambah_sj.ResumeLayout(False)
        Me.panel_tambah_sj.PerformLayout()
        Me.panel_tambah_faktur.ResumeLayout(False)
        Me.panel_tambah_faktur.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv3 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_sj_turun As System.Windows.Forms.Button
    Friend WithEvents btn_sj_naik As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_tanggal_cari As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_cari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_hapus_cari As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_baris As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_no_faktur_akhir As System.Windows.Forms.TextBox
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_surat_jalan_akhir As System.Windows.Forms.TextBox
    Friend WithEvents txt_surat_jalan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_faktur_naik As System.Windows.Forms.Button
    Friend WithEvents btn_faktur_turun As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_faktur_hapus As System.Windows.Forms.Button
    Friend WithEvents btn_faktur_tambah As System.Windows.Forms.Button
    Friend WithEvents btn_sj_hapus As System.Windows.Forms.Button
    Friend WithEvents btn_sj_tambah As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents panel_tambah_sj As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_tambah_sj As System.Windows.Forms.Button
    Friend WithEvents txt_tambah_sj As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancel_sj As System.Windows.Forms.Button
    Friend WithEvents panel_tambah_faktur As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt_tambah_no_faktur As System.Windows.Forms.TextBox
End Class
