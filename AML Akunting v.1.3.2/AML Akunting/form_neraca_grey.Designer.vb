<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_neraca_grey
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_jenis_biaya = New System.Windows.Forms.Button()
        Me.CboJenisBiaya = New System.Windows.Forms.TextBox()
        Me.btn_supplier = New System.Windows.Forms.Button()
        Me.Cbo_Supplier = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cb_polos = New System.Windows.Forms.CheckBox()
        Me.cb_ppn = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_akhir = New System.Windows.Forms.DateTimePicker()
        Me.dtp_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_hari_ini = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_supplier = New System.Windows.Forms.DataGridView()
        Me.dgv_jenis_biaya = New System.Windows.Forms.DataGridView()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_cari = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_perbarui = New System.Windows.Forms.ToolStripButton()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_total_dpp_beli = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_dpp_tersedia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_awal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_masuk = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_akhir = New System.Windows.Forms.TextBox()
        Me.txt_keluar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btn_kosong_tanggal = New System.Windows.Forms.Button()
        Me.txt_tanggal = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_dpp_beli = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_kode_neraca = New System.Windows.Forms.TextBox()
        Me.txt_harga = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_jenis_biaya, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_jenis_biaya)
        Me.Panel3.Controls.Add(Me.CboJenisBiaya)
        Me.Panel3.Controls.Add(Me.btn_supplier)
        Me.Panel3.Controls.Add(Me.Cbo_Supplier)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cb_polos)
        Me.Panel3.Controls.Add(Me.cb_ppn)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.dtp_akhir)
        Me.Panel3.Controls.Add(Me.dtp_awal)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(2, 6)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(245, 256)
        Me.Panel3.TabIndex = 15
        '
        'btn_jenis_biaya
        '
        Me.btn_jenis_biaya.BackColor = System.Drawing.SystemColors.Control
        Me.btn_jenis_biaya.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_jenis_biaya.Location = New System.Drawing.Point(212, 218)
        Me.btn_jenis_biaya.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_jenis_biaya.Name = "btn_jenis_biaya"
        Me.btn_jenis_biaya.Size = New System.Drawing.Size(24, 24)
        Me.btn_jenis_biaya.TabIndex = 54
        Me.btn_jenis_biaya.Text = "X"
        Me.btn_jenis_biaya.UseVisualStyleBackColor = False
        '
        'CboJenisBiaya
        '
        Me.CboJenisBiaya.Location = New System.Drawing.Point(9, 219)
        Me.CboJenisBiaya.Name = "CboJenisBiaya"
        Me.CboJenisBiaya.Size = New System.Drawing.Size(202, 22)
        Me.CboJenisBiaya.TabIndex = 53
        '
        'btn_supplier
        '
        Me.btn_supplier.BackColor = System.Drawing.SystemColors.Control
        Me.btn_supplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_supplier.Location = New System.Drawing.Point(212, 166)
        Me.btn_supplier.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_supplier.Name = "btn_supplier"
        Me.btn_supplier.Size = New System.Drawing.Size(24, 24)
        Me.btn_supplier.TabIndex = 52
        Me.btn_supplier.Text = "X"
        Me.btn_supplier.UseVisualStyleBackColor = False
        '
        'Cbo_Supplier
        '
        Me.Cbo_Supplier.Location = New System.Drawing.Point(9, 167)
        Me.Cbo_Supplier.Name = "Cbo_Supplier"
        Me.Cbo_Supplier.Size = New System.Drawing.Size(202, 22)
        Me.Cbo_Supplier.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 201)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Jenis Biaya"
        '
        'cb_polos
        '
        Me.cb_polos.AutoSize = True
        Me.cb_polos.Checked = True
        Me.cb_polos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_polos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_polos.Location = New System.Drawing.Point(103, 108)
        Me.cb_polos.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_polos.Name = "cb_polos"
        Me.cb_polos.Size = New System.Drawing.Size(61, 20)
        Me.cb_polos.TabIndex = 9
        Me.cb_polos.Text = "Polos"
        Me.cb_polos.UseVisualStyleBackColor = True
        '
        'cb_ppn
        '
        Me.cb_ppn.AutoSize = True
        Me.cb_ppn.Checked = True
        Me.cb_ppn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_ppn.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ppn.Location = New System.Drawing.Point(9, 108)
        Me.cb_ppn.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_ppn.Name = "cb_ppn"
        Me.cb_ppn.Size = New System.Drawing.Size(52, 20)
        Me.cb_ppn.TabIndex = 8
        Me.cb_ppn.Text = "PPN"
        Me.cb_ppn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 69)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "s/d"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 37)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dari"
        '
        'dtp_akhir
        '
        Me.dtp_akhir.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_akhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_akhir.Location = New System.Drawing.Point(49, 65)
        Me.dtp_akhir.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_akhir.Name = "dtp_akhir"
        Me.dtp_akhir.Size = New System.Drawing.Size(115, 23)
        Me.dtp_akhir.TabIndex = 5
        '
        'dtp_awal
        '
        Me.dtp_awal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_awal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_awal.Location = New System.Drawing.Point(49, 32)
        Me.dtp_awal.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_awal.Name = "dtp_awal"
        Me.dtp_awal.Size = New System.Drawing.Size(115, 23)
        Me.dtp_awal.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tanggal Pembelian"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 149)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Supplier"
        '
        'dtp_hari_ini
        '
        Me.dtp_hari_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hari_ini.Location = New System.Drawing.Point(273, 112)
        Me.dtp_hari_ini.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_hari_ini.Name = "dtp_hari_ini"
        Me.dtp_hari_ini.Size = New System.Drawing.Size(100, 22)
        Me.dtp_hari_ini.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.dgv_supplier)
        Me.Panel1.Controls.Add(Me.dgv_jenis_biaya)
        Me.Panel1.Location = New System.Drawing.Point(2, 58)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 527)
        Me.Panel1.TabIndex = 57
        '
        'dgv_supplier
        '
        Me.dgv_supplier.AllowUserToAddRows = False
        Me.dgv_supplier.AllowUserToDeleteRows = False
        Me.dgv_supplier.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_supplier.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_supplier.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_supplier.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_supplier.Location = New System.Drawing.Point(11, 203)
        Me.dgv_supplier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv_supplier.MultiSelect = False
        Me.dgv_supplier.Name = "dgv_supplier"
        Me.dgv_supplier.ReadOnly = True
        Me.dgv_supplier.Size = New System.Drawing.Size(227, 318)
        Me.dgv_supplier.TabIndex = 51
        Me.dgv_supplier.Visible = False
        '
        'dgv_jenis_biaya
        '
        Me.dgv_jenis_biaya.AllowUserToAddRows = False
        Me.dgv_jenis_biaya.AllowUserToDeleteRows = False
        Me.dgv_jenis_biaya.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_jenis_biaya.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_jenis_biaya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_jenis_biaya.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_jenis_biaya.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_jenis_biaya.Location = New System.Drawing.Point(11, 254)
        Me.dgv_jenis_biaya.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv_jenis_biaya.MultiSelect = False
        Me.dgv_jenis_biaya.Name = "dgv_jenis_biaya"
        Me.dgv_jenis_biaya.ReadOnly = True
        Me.dgv_jenis_biaya.Size = New System.Drawing.Size(227, 240)
        Me.dgv_jenis_biaya.TabIndex = 52
        Me.dgv_jenis_biaya.Visible = False
        '
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.SystemColors.Control
        Me.btn_reset.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reset.Location = New System.Drawing.Point(143, 95)
        Me.btn_reset.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(75, 30)
        Me.btn_reset.TabIndex = 53
        Me.btn_reset.Text = "RESET"
        Me.btn_reset.UseVisualStyleBackColor = False
        '
        'btn_cari
        '
        Me.btn_cari.BackColor = System.Drawing.SystemColors.Control
        Me.btn_cari.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cari.Location = New System.Drawing.Point(32, 95)
        Me.btn_cari.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 30)
        Me.btn_cari.TabIndex = 14
        Me.btn_cari.Text = "CARI"
        Me.btn_cari.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_perbarui})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1131, 25)
        Me.ToolStrip1.TabIndex = 55
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_perbarui
        '
        Me.ts_perbarui.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_perbarui.Name = "ts_perbarui"
        Me.ts_perbarui.Size = New System.Drawing.Size(104, 22)
        Me.ts_perbarui.Text = "Perbarui   |"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(255, 58)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(874, 456)
        Me.dgv1.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label6.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(2, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1127, 28)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "NERACA GREY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txt_total_dpp_beli)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txt_dpp_tersedia)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txt_awal)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txt_masuk)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_akhir)
        Me.Panel2.Controls.Add(Me.txt_keluar)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(255, 517)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 68)
        Me.Panel2.TabIndex = 60
        '
        'txt_total_dpp_beli
        '
        Me.txt_total_dpp_beli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_dpp_beli.Location = New System.Drawing.Point(686, 31)
        Me.txt_total_dpp_beli.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_dpp_beli.Name = "txt_total_dpp_beli"
        Me.txt_total_dpp_beli.ReadOnly = True
        Me.txt_total_dpp_beli.Size = New System.Drawing.Size(170, 22)
        Me.txt_total_dpp_beli.TabIndex = 167
        Me.txt_total_dpp_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(725, 14)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 16)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "DPP Beli (Rp)"
        '
        'txt_dpp_tersedia
        '
        Me.txt_dpp_tersedia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_tersedia.Location = New System.Drawing.Point(504, 31)
        Me.txt_dpp_tersedia.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_tersedia.Name = "txt_dpp_tersedia"
        Me.txt_dpp_tersedia.ReadOnly = True
        Me.txt_dpp_tersedia.Size = New System.Drawing.Size(170, 22)
        Me.txt_dpp_tersedia.TabIndex = 165
        Me.txt_dpp_tersedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(511, 13)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 16)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "DPP Jual Tersedia (Rp)"
        '
        'txt_awal
        '
        Me.txt_awal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_awal.Location = New System.Drawing.Point(16, 31)
        Me.txt_awal.Name = "txt_awal"
        Me.txt_awal.ReadOnly = True
        Me.txt_awal.Size = New System.Drawing.Size(110, 22)
        Me.txt_awal.TabIndex = 164
        Me.txt_awal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(169, 13)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 159
        Me.Label12.Text = "Masuk"
        '
        'txt_masuk
        '
        Me.txt_masuk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_masuk.Location = New System.Drawing.Point(138, 31)
        Me.txt_masuk.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_masuk.Name = "txt_masuk"
        Me.txt_masuk.ReadOnly = True
        Me.txt_masuk.Size = New System.Drawing.Size(110, 22)
        Me.txt_masuk.TabIndex = 162
        Me.txt_masuk.TabStop = False
        Me.txt_masuk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(400, 13)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "Stok Akhir"
        '
        'txt_akhir
        '
        Me.txt_akhir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_akhir.Location = New System.Drawing.Point(382, 31)
        Me.txt_akhir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_akhir.Name = "txt_akhir"
        Me.txt_akhir.ReadOnly = True
        Me.txt_akhir.Size = New System.Drawing.Size(110, 22)
        Me.txt_akhir.TabIndex = 157
        Me.txt_akhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_keluar
        '
        Me.txt_keluar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_keluar.Location = New System.Drawing.Point(260, 31)
        Me.txt_keluar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_keluar.Name = "txt_keluar"
        Me.txt_keluar.ReadOnly = True
        Me.txt_keluar.Size = New System.Drawing.Size(110, 22)
        Me.txt_keluar.TabIndex = 156
        Me.txt_keluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(34, 13)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 16)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "Stok Awal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(291, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "Keluar"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btn_reset)
        Me.Panel4.Controls.Add(Me.ListBox1)
        Me.Panel4.Controls.Add(Me.btn_cari)
        Me.Panel4.Controls.Add(Me.btn_kosong_tanggal)
        Me.Panel4.Controls.Add(Me.txt_tanggal)
        Me.Panel4.Controls.Add(Me.dtp_tanggal)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txt_dpp_beli)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.txt_qty)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.txt_kode_neraca)
        Me.Panel4.Controls.Add(Me.txt_harga)
        Me.Panel4.Location = New System.Drawing.Point(2, 58)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(250, 527)
        Me.Panel4.TabIndex = 61
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(11, 162)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 200)
        Me.ListBox1.TabIndex = 62
        Me.ListBox1.Visible = False
        '
        'btn_kosong_tanggal
        '
        Me.btn_kosong_tanggal.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal.Location = New System.Drawing.Point(165, 43)
        Me.btn_kosong_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal.Name = "btn_kosong_tanggal"
        Me.btn_kosong_tanggal.Size = New System.Drawing.Size(23, 23)
        Me.btn_kosong_tanggal.TabIndex = 174
        Me.btn_kosong_tanggal.TabStop = False
        Me.btn_kosong_tanggal.Text = "X"
        Me.btn_kosong_tanggal.UseMnemonic = False
        Me.btn_kosong_tanggal.UseVisualStyleBackColor = False
        '
        'txt_tanggal
        '
        Me.txt_tanggal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal.Location = New System.Drawing.Point(15, 43)
        Me.txt_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal.Name = "txt_tanggal"
        Me.txt_tanggal.ReadOnly = True
        Me.txt_tanggal.Size = New System.Drawing.Size(124, 23)
        Me.txt_tanggal.TabIndex = 173
        Me.txt_tanggal.TabStop = False
        Me.txt_tanggal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(142, 43)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(15, 23)
        Me.dtp_tanggal.TabIndex = 172
        Me.dtp_tanggal.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 19)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 16)
        Me.Label17.TabIndex = 171
        Me.Label17.Text = "Bulan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(2, 385)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 16)
        Me.Label15.TabIndex = 170
        Me.Label15.Text = "DPP Beli"
        Me.Label15.Visible = False
        '
        'txt_dpp_beli
        '
        Me.txt_dpp_beli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_beli.Location = New System.Drawing.Point(95, 382)
        Me.txt_dpp_beli.Name = "txt_dpp_beli"
        Me.txt_dpp_beli.ReadOnly = True
        Me.txt_dpp_beli.Size = New System.Drawing.Size(150, 22)
        Me.txt_dpp_beli.TabIndex = 169
        Me.txt_dpp_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_dpp_beli.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 421)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 166
        Me.Label10.Text = "Jumlah"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 457)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 16)
        Me.Label11.TabIndex = 167
        Me.Label11.Text = "Kode Neraca"
        Me.Label11.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(2, 493)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 16)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "Harga"
        Me.Label14.Visible = False
        '
        'txt_qty
        '
        Me.txt_qty.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qty.Location = New System.Drawing.Point(95, 418)
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.ReadOnly = True
        Me.txt_qty.Size = New System.Drawing.Size(150, 22)
        Me.txt_qty.TabIndex = 168
        Me.txt_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_qty.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(154, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 62
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txt_kode_neraca
        '
        Me.txt_kode_neraca.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kode_neraca.Location = New System.Drawing.Point(95, 454)
        Me.txt_kode_neraca.Name = "txt_kode_neraca"
        Me.txt_kode_neraca.ReadOnly = True
        Me.txt_kode_neraca.Size = New System.Drawing.Size(150, 22)
        Me.txt_kode_neraca.TabIndex = 167
        Me.txt_kode_neraca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_kode_neraca.Visible = False
        '
        'txt_harga
        '
        Me.txt_harga.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_harga.Location = New System.Drawing.Point(95, 490)
        Me.txt_harga.Name = "txt_harga"
        Me.txt_harga.ReadOnly = True
        Me.txt_harga.Size = New System.Drawing.Size(150, 22)
        Me.txt_harga.TabIndex = 166
        Me.txt_harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_harga.Visible = False
        '
        'form_neraca_grey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 587)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.dtp_hari_ini)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_neraca_grey"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_jenis_biaya, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_jenis_biaya As System.Windows.Forms.Button
    Friend WithEvents CboJenisBiaya As System.Windows.Forms.TextBox
    Friend WithEvents btn_supplier As System.Windows.Forms.Button
    Friend WithEvents Cbo_Supplier As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_polos As System.Windows.Forms.CheckBox
    Friend WithEvents cb_ppn As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_hari_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv_supplier As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_jenis_biaya As System.Windows.Forms.DataGridView
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_perbarui As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txt_dpp_tersedia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_awal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_masuk As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_akhir As System.Windows.Forms.TextBox
    Friend WithEvents txt_keluar As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_harga As System.Windows.Forms.TextBox
    Friend WithEvents txt_kode_neraca As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_beli As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_total_dpp_beli As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btn_kosong_tanggal As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
