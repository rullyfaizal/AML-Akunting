<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_input_bukpot
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_pph23_actual = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_kode_gabung = New System.Windows.Forms.TextBox()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.dtp_masa_bukpot = New System.Windows.Forms.DateTimePicker()
        Me.dtp_tgl_bukpot = New System.Windows.Forms.DateTimePicker()
        Me.txt_nama_customer = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.txt_no_bukpot = New System.Windows.Forms.TextBox()
        Me.txt_pph23 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_npwp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.dtp_tahun_bukpot = New System.Windows.Forms.DateTimePicker()
        Me.lbl_dgv2 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.INPUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UBAHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HAPUSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EKSPORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(397, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 14)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "PPh 23 Actual"
        '
        'txt_pph23_actual
        '
        Me.txt_pph23_actual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pph23_actual.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pph23_actual.Location = New System.Drawing.Point(499, 106)
        Me.txt_pph23_actual.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_pph23_actual.MaxLength = 15
        Me.txt_pph23_actual.Name = "txt_pph23_actual"
        Me.txt_pph23_actual.Size = New System.Drawing.Size(162, 22)
        Me.txt_pph23_actual.TabIndex = 5
        Me.txt_pph23_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(397, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Tanggal"
        '
        'lbl_judul
        '
        Me.lbl_judul.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.lbl_judul.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.SystemColors.Window
        Me.lbl_judul.Location = New System.Drawing.Point(2, 30)
        Me.lbl_judul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(917, 26)
        Me.lbl_judul.TabIndex = 53
        Me.lbl_judul.Text = "INPUT BUKTI POTONG"
        Me.lbl_judul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_kode_gabung)
        Me.Panel2.Controls.Add(Me.txt_tanggal_upload)
        Me.Panel2.Controls.Add(Me.dtp_masa_bukpot)
        Me.Panel2.Controls.Add(Me.dtp_tgl_bukpot)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_pph23_actual)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_nama_customer)
        Me.Panel2.Controls.Add(Me.btn_simpan)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.btn_refresh)
        Me.Panel2.Controls.Add(Me.txt_no_bukpot)
        Me.Panel2.Controls.Add(Me.txt_pph23)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txt_npwp)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(2, 433)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(917, 144)
        Me.Panel2.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 114)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 14)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Kode Gabung"
        Me.Label7.Visible = False
        '
        'txt_kode_gabung
        '
        Me.txt_kode_gabung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kode_gabung.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kode_gabung.Location = New System.Drawing.Point(122, 112)
        Me.txt_kode_gabung.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_kode_gabung.MaxLength = 15
        Me.txt_kode_gabung.Name = "txt_kode_gabung"
        Me.txt_kode_gabung.ReadOnly = True
        Me.txt_kode_gabung.Size = New System.Drawing.Size(162, 22)
        Me.txt_kode_gabung.TabIndex = 121
        Me.txt_kode_gabung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_kode_gabung.Visible = False
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(499, 46)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_upload.TabIndex = 120
        Me.txt_tanggal_upload.TabStop = False
        '
        'dtp_masa_bukpot
        '
        Me.dtp_masa_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_masa_bukpot.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_masa_bukpot.Location = New System.Drawing.Point(632, 46)
        Me.dtp_masa_bukpot.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_masa_bukpot.Name = "dtp_masa_bukpot"
        Me.dtp_masa_bukpot.Size = New System.Drawing.Size(15, 22)
        Me.dtp_masa_bukpot.TabIndex = 119
        Me.dtp_masa_bukpot.TabStop = False
        '
        'dtp_tgl_bukpot
        '
        Me.dtp_tgl_bukpot.CustomFormat = "yyy"
        Me.dtp_tgl_bukpot.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_tgl_bukpot.Location = New System.Drawing.Point(499, 16)
        Me.dtp_tgl_bukpot.Name = "dtp_tgl_bukpot"
        Me.dtp_tgl_bukpot.Size = New System.Drawing.Size(148, 22)
        Me.dtp_tgl_bukpot.TabIndex = 49
        '
        'txt_nama_customer
        '
        Me.txt_nama_customer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nama_customer.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nama_customer.Location = New System.Drawing.Point(122, 16)
        Me.txt_nama_customer.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_nama_customer.MaxLength = 100
        Me.txt_nama_customer.Name = "txt_nama_customer"
        Me.txt_nama_customer.ReadOnly = True
        Me.txt_nama_customer.Size = New System.Drawing.Size(220, 22)
        Me.txt_nama_customer.TabIndex = 2
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(758, 25)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(97, 38)
        Me.btn_simpan.TabIndex = 30
        Me.btn_simpan.TabStop = False
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(44, 80)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "PPH 23"
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(758, 81)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(97, 38)
        Me.btn_refresh.TabIndex = 45
        Me.btn_refresh.TabStop = False
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'txt_no_bukpot
        '
        Me.txt_no_bukpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_no_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_bukpot.Location = New System.Drawing.Point(499, 76)
        Me.txt_no_bukpot.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_no_bukpot.MaxLength = 100
        Me.txt_no_bukpot.Name = "txt_no_bukpot"
        Me.txt_no_bukpot.Size = New System.Drawing.Size(162, 22)
        Me.txt_no_bukpot.TabIndex = 1
        '
        'txt_pph23
        '
        Me.txt_pph23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pph23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pph23.Location = New System.Drawing.Point(122, 76)
        Me.txt_pph23.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_pph23.MaxLength = 15
        Me.txt_pph23.Name = "txt_pph23"
        Me.txt_pph23.ReadOnly = True
        Me.txt_pph23.Size = New System.Drawing.Size(162, 22)
        Me.txt_pph23.TabIndex = 6
        Me.txt_pph23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(397, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "No Bukpot"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(397, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Masa"
        '
        'txt_npwp
        '
        Me.txt_npwp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_npwp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_npwp.Location = New System.Drawing.Point(122, 46)
        Me.txt_npwp.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_npwp.MaxLength = 30
        Me.txt_npwp.Name = "txt_npwp"
        Me.txt_npwp.ReadOnly = True
        Me.txt_npwp.Size = New System.Drawing.Size(162, 22)
        Me.txt_npwp.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "NPWP"
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.dtp_tahun_bukpot)
        Me.panel_bukpot.Controls.Add(Me.lbl_dgv2)
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Controls.Add(Me.lbl_dgv1)
        Me.panel_bukpot.Controls.Add(Me.dgv2)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(2, 59)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(917, 370)
        Me.panel_bukpot.TabIndex = 56
        '
        'dtp_tahun_bukpot
        '
        Me.dtp_tahun_bukpot.CustomFormat = "yyyy"
        Me.dtp_tahun_bukpot.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun_bukpot.Location = New System.Drawing.Point(253, 4)
        Me.dtp_tahun_bukpot.Name = "dtp_tahun_bukpot"
        Me.dtp_tahun_bukpot.ShowUpDown = True
        Me.dtp_tahun_bukpot.Size = New System.Drawing.Size(58, 22)
        Me.dtp_tahun_bukpot.TabIndex = 50
        Me.dtp_tahun_bukpot.Visible = False
        '
        'lbl_dgv2
        '
        Me.lbl_dgv2.AutoSize = True
        Me.lbl_dgv2.Location = New System.Drawing.Point(11, 243)
        Me.lbl_dgv2.Name = "lbl_dgv2"
        Me.lbl_dgv2.Size = New System.Drawing.Size(215, 14)
        Me.lbl_dgv2.TabIndex = 48
        Me.lbl_dgv2.Text = "List Penjualan akan input Bukpot"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(8, 29)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(901, 206)
        Me.dgv1.TabIndex = 47
        '
        'lbl_dgv1
        '
        Me.lbl_dgv1.AutoSize = True
        Me.lbl_dgv1.Location = New System.Drawing.Point(12, 8)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(186, 14)
        Me.lbl_dgv1.TabIndex = 26
        Me.lbl_dgv1.Text = "List Penjualan Belum bukpot"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(8, 261)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(901, 102)
        Me.dgv2.TabIndex = 25
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INPUTToolStripMenuItem, Me.UBAHToolStripMenuItem, Me.HAPUSToolStripMenuItem, Me.EKSPORToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(921, 26)
        Me.MenuStrip1.TabIndex = 57
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'INPUTToolStripMenuItem
        '
        Me.INPUTToolStripMenuItem.Name = "INPUTToolStripMenuItem"
        Me.INPUTToolStripMenuItem.Size = New System.Drawing.Size(71, 22)
        Me.INPUTToolStripMenuItem.Text = "INPUT"
        '
        'UBAHToolStripMenuItem
        '
        Me.UBAHToolStripMenuItem.Name = "UBAHToolStripMenuItem"
        Me.UBAHToolStripMenuItem.Size = New System.Drawing.Size(66, 22)
        Me.UBAHToolStripMenuItem.Text = "UBAH"
        '
        'HAPUSToolStripMenuItem
        '
        Me.HAPUSToolStripMenuItem.Name = "HAPUSToolStripMenuItem"
        Me.HAPUSToolStripMenuItem.Size = New System.Drawing.Size(75, 22)
        Me.HAPUSToolStripMenuItem.Text = "HAPUS"
        '
        'EKSPORToolStripMenuItem
        '
        Me.EKSPORToolStripMenuItem.Name = "EKSPORToolStripMenuItem"
        Me.EKSPORToolStripMenuItem.Size = New System.Drawing.Size(85, 22)
        Me.EKSPORToolStripMenuItem.Text = "EKSPOR"
        '
        'form_input_bukpot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 581)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.lbl_judul)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_input_bukpot"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panel_bukpot.ResumeLayout(False)
        Me.panel_bukpot.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_pph23_actual As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_nama_customer As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_no_bukpot As System.Windows.Forms.TextBox
    Friend WithEvents txt_pph23 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_npwp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_tgl_bukpot As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents INPUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UBAHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EKSPORToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_dgv2 As System.Windows.Forms.Label
    Friend WithEvents HAPUSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents dtp_masa_bukpot As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_kode_gabung As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tahun_bukpot As System.Windows.Forms.DateTimePicker
End Class
