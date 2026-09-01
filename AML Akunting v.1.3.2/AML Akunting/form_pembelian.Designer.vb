<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_pembelian
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_hari_ini = New System.Windows.Forms.DateTimePicker()
        Me.cb_polos = New System.Windows.Forms.CheckBox()
        Me.cb_ppn = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_akhir = New System.Windows.Forms.DateTimePicker()
        Me.dtp_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_supplier = New System.Windows.Forms.DataGridView()
        Me.dgv_jenis_biaya = New System.Windows.Forms.DataGridView()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_cari = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_jenis_biaya = New System.Windows.Forms.Button()
        Me.CboJenisBiaya = New System.Windows.Forms.TextBox()
        Me.btn_supplier = New System.Windows.Forms.Button()
        Me.Cbo_Supplier = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_total_polos = New System.Windows.Forms.TextBox()
        Me.txt_total_ppn = New System.Windows.Forms.TextBox()
        Me.txt_total_dpp = New System.Windows.Forms.TextBox()
        Me.txt_gran_total = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.panelRetur = New System.Windows.Forms.Panel()
        Me.btn_hitung_retur = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_total_retur = New System.Windows.Forms.TextBox()
        Me.lblPPN = New System.Windows.Forms.Label()
        Me.txt_ppn_retur = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtp_tanggal_retur = New System.Windows.Forms.DateTimePicker()
        Me.txt_supplier_retur = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btn_simpan_retur = New System.Windows.Forms.Button()
        Me.btn_batal_retur = New System.Windows.Forms.Button()
        Me.txt_dpp_retur = New System.Windows.Forms.TextBox()
        Me.ts_baru = New System.Windows.Forms.ToolStripButton()
        Me.ts_ubah = New System.Windows.Forms.ToolStripButton()
        Me.ts_hapus = New System.Windows.Forms.ToolStripButton()
        Me.ts_perbarui = New System.Windows.Forms.ToolStripButton()
        Me.ts_cari_barang = New System.Windows.Forms.ToolStripButton()
        Me.ts_upload = New System.Windows.Forms.ToolStripButton()
        Me.ts_excel = New System.Windows.Forms.ToolStripButton()
        Me.ts_retur = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_jenis_biaya, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.panelRetur.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "DATA PEMBELIAN"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp_hari_ini
        '
        Me.dtp_hari_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hari_ini.Location = New System.Drawing.Point(1576, 40)
        Me.dtp_hari_ini.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_hari_ini.Name = "dtp_hari_ini"
        Me.dtp_hari_ini.Size = New System.Drawing.Size(1300, 22)
        Me.dtp_hari_ini.TabIndex = 19
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgv_supplier)
        Me.Panel1.Controls.Add(Me.dgv_jenis_biaya)
        Me.Panel1.Controls.Add(Me.btn_reset)
        Me.Panel1.Controls.Add(Me.btn_cari)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(2, 58)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 527)
        Me.Panel1.TabIndex = 17
        '
        'dgv_supplier
        '
        Me.dgv_supplier.AllowUserToAddRows = False
        Me.dgv_supplier.AllowUserToDeleteRows = False
        Me.dgv_supplier.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_supplier.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_supplier.DefaultCellStyle = DataGridViewCellStyle4
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_jenis_biaya.DefaultCellStyle = DataGridViewCellStyle5
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
        Me.btn_reset.Location = New System.Drawing.Point(142, 282)
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
        Me.btn_cari.Location = New System.Drawing.Point(31, 282)
        Me.btn_cari.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 30)
        Me.btn_cari.TabIndex = 14
        Me.btn_cari.Text = "CARI"
        Me.btn_cari.UseVisualStyleBackColor = False
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
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(255, 58)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(874, 455)
        Me.dgv1.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txt_total_polos)
        Me.Panel2.Controls.Add(Me.txt_total_ppn)
        Me.Panel2.Controls.Add(Me.txt_total_dpp)
        Me.Panel2.Controls.Add(Me.txt_gran_total)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Location = New System.Drawing.Point(255, 516)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 68)
        Me.Panel2.TabIndex = 21
        '
        'txt_total_polos
        '
        Me.txt_total_polos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_polos.Location = New System.Drawing.Point(15, 31)
        Me.txt_total_polos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_polos.Name = "txt_total_polos"
        Me.txt_total_polos.ReadOnly = True
        Me.txt_total_polos.Size = New System.Drawing.Size(200, 23)
        Me.txt_total_polos.TabIndex = 224
        Me.txt_total_polos.TabStop = False
        Me.txt_total_polos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_ppn
        '
        Me.txt_total_ppn.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_ppn.Location = New System.Drawing.Point(443, 31)
        Me.txt_total_ppn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_ppn.Name = "txt_total_ppn"
        Me.txt_total_ppn.ReadOnly = True
        Me.txt_total_ppn.Size = New System.Drawing.Size(200, 23)
        Me.txt_total_ppn.TabIndex = 223
        Me.txt_total_ppn.TabStop = False
        Me.txt_total_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_dpp
        '
        Me.txt_total_dpp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_dpp.Location = New System.Drawing.Point(229, 31)
        Me.txt_total_dpp.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_dpp.Name = "txt_total_dpp"
        Me.txt_total_dpp.ReadOnly = True
        Me.txt_total_dpp.Size = New System.Drawing.Size(200, 23)
        Me.txt_total_dpp.TabIndex = 222
        Me.txt_total_dpp.TabStop = False
        Me.txt_total_dpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_gran_total
        '
        Me.txt_gran_total.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gran_total.Location = New System.Drawing.Point(657, 31)
        Me.txt_gran_total.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_gran_total.Name = "txt_gran_total"
        Me.txt_gran_total.ReadOnly = True
        Me.txt_gran_total.Size = New System.Drawing.Size(200, 23)
        Me.txt_gran_total.TabIndex = 221
        Me.txt_gran_total.TabStop = False
        Me.txt_gran_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(711, 13)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 16)
        Me.Label26.TabIndex = 228
        Me.Label26.Text = "Grand Total (Rp)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(495, 13)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 16)
        Me.Label25.TabIndex = 227
        Me.Label25.Text = "Total PPN (Rp)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(273, 13)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 16)
        Me.Label24.TabIndex = 226
        Me.Label24.Text = "Total DPP (Rp)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(47, 13)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 16)
        Me.Label23.TabIndex = 225
        Me.Label23.Text = "Total Polos (Rp)"
        '
        'panelRetur
        '
        Me.panelRetur.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panelRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRetur.Controls.Add(Me.btn_hitung_retur)
        Me.panelRetur.Controls.Add(Me.Label22)
        Me.panelRetur.Controls.Add(Me.txt_total_retur)
        Me.panelRetur.Controls.Add(Me.lblPPN)
        Me.panelRetur.Controls.Add(Me.txt_ppn_retur)
        Me.panelRetur.Controls.Add(Me.Label20)
        Me.panelRetur.Controls.Add(Me.Label19)
        Me.panelRetur.Controls.Add(Me.Label17)
        Me.panelRetur.Controls.Add(Me.dtp_tanggal_retur)
        Me.panelRetur.Controls.Add(Me.txt_supplier_retur)
        Me.panelRetur.Controls.Add(Me.Label18)
        Me.panelRetur.Controls.Add(Me.btn_simpan_retur)
        Me.panelRetur.Controls.Add(Me.btn_batal_retur)
        Me.panelRetur.Controls.Add(Me.txt_dpp_retur)
        Me.panelRetur.Location = New System.Drawing.Point(363, 145)
        Me.panelRetur.Name = "panelRetur"
        Me.panelRetur.Size = New System.Drawing.Size(405, 256)
        Me.panelRetur.TabIndex = 234
        Me.panelRetur.Visible = False
        '
        'btn_hitung_retur
        '
        Me.btn_hitung_retur.BackColor = System.Drawing.SystemColors.Control
        Me.btn_hitung_retur.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_hitung_retur.Location = New System.Drawing.Point(10, 210)
        Me.btn_hitung_retur.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_hitung_retur.Name = "btn_hitung_retur"
        Me.btn_hitung_retur.Size = New System.Drawing.Size(117, 30)
        Me.btn_hitung_retur.TabIndex = 162
        Me.btn_hitung_retur.Text = "HITUNG"
        Me.btn_hitung_retur.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(55, 168)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 16)
        Me.Label22.TabIndex = 161
        Me.Label22.Text = "TOTAL (Rp)"
        '
        'txt_total_retur
        '
        Me.txt_total_retur.Location = New System.Drawing.Point(149, 165)
        Me.txt_total_retur.Name = "txt_total_retur"
        Me.txt_total_retur.ReadOnly = True
        Me.txt_total_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_total_retur.TabIndex = 160
        Me.txt_total_retur.TabStop = False
        Me.txt_total_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(55, 140)
        Me.lblPPN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(66, 16)
        Me.lblPPN.TabIndex = 159
        Me.lblPPN.Text = "PPN (Rp)"
        '
        'txt_ppn_retur
        '
        Me.txt_ppn_retur.Location = New System.Drawing.Point(149, 137)
        Me.txt_ppn_retur.Name = "txt_ppn_retur"
        Me.txt_ppn_retur.ReadOnly = True
        Me.txt_ppn_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_ppn_retur.TabIndex = 158
        Me.txt_ppn_retur.TabStop = False
        Me.txt_ppn_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(55, 112)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 16)
        Me.Label20.TabIndex = 157
        Me.Label20.Text = "DPP (Rp)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(55, 84)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 16)
        Me.Label19.TabIndex = 155
        Me.Label19.Text = "Supplier"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(55, 56)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 16)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Tanggal"
        '
        'dtp_tanggal_retur
        '
        Me.dtp_tanggal_retur.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_retur.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_retur.Location = New System.Drawing.Point(149, 53)
        Me.dtp_tanggal_retur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_retur.Name = "dtp_tanggal_retur"
        Me.dtp_tanggal_retur.Size = New System.Drawing.Size(119, 22)
        Me.dtp_tanggal_retur.TabIndex = 149
        Me.dtp_tanggal_retur.TabStop = False
        '
        'txt_supplier_retur
        '
        Me.txt_supplier_retur.Location = New System.Drawing.Point(149, 81)
        Me.txt_supplier_retur.Name = "txt_supplier_retur"
        Me.txt_supplier_retur.ReadOnly = True
        Me.txt_supplier_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_supplier_retur.TabIndex = 148
        Me.txt_supplier_retur.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label18.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Window
        Me.Label18.Location = New System.Drawing.Point(6, 7)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(391, 28)
        Me.Label18.TabIndex = 144
        Me.Label18.Text = "RETUR PEMBELIAN"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_simpan_retur
        '
        Me.btn_simpan_retur.BackColor = System.Drawing.SystemColors.Control
        Me.btn_simpan_retur.Enabled = False
        Me.btn_simpan_retur.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_simpan_retur.Location = New System.Drawing.Point(143, 210)
        Me.btn_simpan_retur.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_simpan_retur.Name = "btn_simpan_retur"
        Me.btn_simpan_retur.Size = New System.Drawing.Size(117, 30)
        Me.btn_simpan_retur.TabIndex = 27
        Me.btn_simpan_retur.Text = "SIMPAN"
        Me.btn_simpan_retur.UseVisualStyleBackColor = False
        '
        'btn_batal_retur
        '
        Me.btn_batal_retur.BackColor = System.Drawing.SystemColors.Control
        Me.btn_batal_retur.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_batal_retur.Location = New System.Drawing.Point(276, 210)
        Me.btn_batal_retur.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_batal_retur.Name = "btn_batal_retur"
        Me.btn_batal_retur.Size = New System.Drawing.Size(117, 30)
        Me.btn_batal_retur.TabIndex = 25
        Me.btn_batal_retur.Text = "BATAL"
        Me.btn_batal_retur.UseVisualStyleBackColor = False
        '
        'txt_dpp_retur
        '
        Me.txt_dpp_retur.Location = New System.Drawing.Point(149, 109)
        Me.txt_dpp_retur.MaxLength = 70
        Me.txt_dpp_retur.Name = "txt_dpp_retur"
        Me.txt_dpp_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_dpp_retur.TabIndex = 143
        Me.txt_dpp_retur.TabStop = False
        Me.txt_dpp_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ts_baru
        '
        Me.ts_baru.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_baru.Name = "ts_baru"
        Me.ts_baru.Size = New System.Drawing.Size(74, 22)
        Me.ts_baru.Text = "Baru   |"
        '
        'ts_ubah
        '
        Me.ts_ubah.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_ubah.Name = "ts_ubah"
        Me.ts_ubah.Size = New System.Drawing.Size(79, 22)
        Me.ts_ubah.Text = "Ubah   |"
        '
        'ts_hapus
        '
        Me.ts_hapus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_hapus.Name = "ts_hapus"
        Me.ts_hapus.Size = New System.Drawing.Size(88, 22)
        Me.ts_hapus.Text = "Hapus   |"
        '
        'ts_perbarui
        '
        Me.ts_perbarui.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_perbarui.Name = "ts_perbarui"
        Me.ts_perbarui.Size = New System.Drawing.Size(104, 22)
        Me.ts_perbarui.Text = "Perbarui   |"
        '
        'ts_cari_barang
        '
        Me.ts_cari_barang.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cari_barang.Name = "ts_cari_barang"
        Me.ts_cari_barang.Size = New System.Drawing.Size(132, 22)
        Me.ts_cari_barang.Text = "Cari Barang   |"
        '
        'ts_upload
        '
        Me.ts_upload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_upload.Name = "ts_upload"
        Me.ts_upload.Size = New System.Drawing.Size(94, 22)
        Me.ts_upload.Text = "Upload   |"
        '
        'ts_excel
        '
        Me.ts_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_excel.Name = "ts_excel"
        Me.ts_excel.Size = New System.Drawing.Size(79, 22)
        Me.ts_excel.Text = "Excel   |"
        '
        'ts_retur
        '
        Me.ts_retur.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_retur.Name = "ts_retur"
        Me.ts_retur.Size = New System.Drawing.Size(81, 22)
        Me.ts_retur.Text = "Retur   |"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_baru, Me.ts_ubah, Me.ts_hapus, Me.ts_perbarui, Me.ts_cari_barang, Me.ts_upload, Me.ts_excel, Me.ts_retur})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1131, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'form_pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 587)
        Me.Controls.Add(Me.panelRetur)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtp_hari_ini)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "form_pembelian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_jenis_biaya, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelRetur.ResumeLayout(False)
        Me.panelRetur.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_hari_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_polos As System.Windows.Forms.CheckBox
    Friend WithEvents cb_ppn As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_total_polos As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_ppn As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_dpp As System.Windows.Forms.TextBox
    Friend WithEvents txt_gran_total As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Supplier As System.Windows.Forms.TextBox
    Friend WithEvents dgv_supplier As System.Windows.Forms.DataGridView
    Friend WithEvents btn_supplier As System.Windows.Forms.Button
    Friend WithEvents btn_jenis_biaya As System.Windows.Forms.Button
    Friend WithEvents CboJenisBiaya As System.Windows.Forms.TextBox
    Friend WithEvents dgv_jenis_biaya As System.Windows.Forms.DataGridView
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents panelRetur As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_total_retur As System.Windows.Forms.TextBox
    Friend WithEvents lblPPN As System.Windows.Forms.Label
    Friend WithEvents txt_ppn_retur As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtp_tanggal_retur As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_supplier_retur As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_simpan_retur As System.Windows.Forms.Button
    Friend WithEvents btn_batal_retur As System.Windows.Forms.Button
    Friend WithEvents txt_dpp_retur As System.Windows.Forms.TextBox
    Friend WithEvents btn_hitung_retur As System.Windows.Forms.Button
    Friend WithEvents ts_baru As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_ubah As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_hapus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_perbarui As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cari_barang As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_upload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_retur As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
