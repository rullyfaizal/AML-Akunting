<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_upload_pembelian
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.dgv3 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.txt_selisih_ppn = New System.Windows.Forms.TextBox()
        Me.btn_kosong_tanggal_upload = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.txt_dpp_akan_upload = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.txt_dpp_upload = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtp_tanggal_upload = New System.Windows.Forms.DateTimePicker()
        Me.txt_dpp_penjualan = New System.Windows.Forms.TextBox()
        Me.dgv_upload = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_batal_upload = New System.Windows.Forms.DataGridView()
        Me.dgv_tampil_upload = New System.Windows.Forms.DataGridView()
        Me.btn_batal_upload = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_penjualan = New System.Windows.Forms.DataGridView()
        Me.btnCek = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_batal_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_tampil_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_penjualan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(0, 46)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(565, 230)
        Me.dgv1.TabIndex = 144
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1136, 26)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "UPLOAD PEMBELIAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(160, 28)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(244, 16)
        Me.Label17.TabIndex = 146
        Me.Label17.Text = "DATA PEMBELIAN BELUM DI UPLOAD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(167, 286)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 16)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "DATA PEMBELIAN AKAN DIUPLOAD"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(0, 306)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(565, 230)
        Me.dgv2.TabIndex = 147
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv3.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv3.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv3.Location = New System.Drawing.Point(0, 46)
        Me.dgv3.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv3.MultiSelect = False
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.Size = New System.Drawing.Size(565, 230)
        Me.dgv3.TabIndex = 149
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCek)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.txt_selisih_ppn)
        Me.Panel1.Controls.Add(Me.btn_kosong_tanggal_upload)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txt_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_dpp_akan_upload)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.lbl_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_dpp_upload)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.dtp_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_dpp_penjualan)
        Me.Panel1.Location = New System.Drawing.Point(0, 543)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1136, 60)
        Me.Panel1.TabIndex = 150
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(978, 13)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 14)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "Selisih PPN (Rp)"
        '
        'btn_simpan
        '
        Me.btn_simpan.BackColor = System.Drawing.SystemColors.Window
        Me.btn_simpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(223, 14)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(111, 30)
        Me.btn_simpan.TabIndex = 124
        Me.btn_simpan.TabStop = False
        Me.btn_simpan.Text = "UPLOAD"
        Me.btn_simpan.UseMnemonic = False
        Me.btn_simpan.UseVisualStyleBackColor = False
        '
        'txt_selisih_ppn
        '
        Me.txt_selisih_ppn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_selisih_ppn.Location = New System.Drawing.Point(949, 32)
        Me.txt_selisih_ppn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_selisih_ppn.Name = "txt_selisih_ppn"
        Me.txt_selisih_ppn.ReadOnly = True
        Me.txt_selisih_ppn.Size = New System.Drawing.Size(165, 22)
        Me.txt_selisih_ppn.TabIndex = 231
        Me.txt_selisih_ppn.TabStop = False
        Me.txt_selisih_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_kosong_tanggal_upload
        '
        Me.btn_kosong_tanggal_upload.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal_upload.Location = New System.Drawing.Point(168, 28)
        Me.btn_kosong_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal_upload.Name = "btn_kosong_tanggal_upload"
        Me.btn_kosong_tanggal_upload.Size = New System.Drawing.Size(27, 22)
        Me.btn_kosong_tanggal_upload.TabIndex = 122
        Me.btn_kosong_tanggal_upload.TabStop = False
        Me.btn_kosong_tanggal_upload.Text = "X"
        Me.btn_kosong_tanggal_upload.UseMnemonic = False
        Me.btn_kosong_tanggal_upload.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(778, 13)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(145, 14)
        Me.Label26.TabIndex = 228
        Me.Label26.Text = "DPP Akan Upload (Rp)"
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(17, 28)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_upload.TabIndex = 118
        Me.txt_tanggal_upload.TabStop = False
        Me.txt_tanggal_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_dpp_akan_upload
        '
        Me.txt_dpp_akan_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_akan_upload.Location = New System.Drawing.Point(768, 32)
        Me.txt_dpp_akan_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_akan_upload.Name = "txt_dpp_akan_upload"
        Me.txt_dpp_akan_upload.ReadOnly = True
        Me.txt_dpp_akan_upload.Size = New System.Drawing.Size(165, 22)
        Me.txt_dpp_akan_upload.TabIndex = 221
        Me.txt_dpp_akan_upload.TabStop = False
        Me.txt_dpp_akan_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(614, 13)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 14)
        Me.Label25.TabIndex = 227
        Me.Label25.Text = "DPP Upload (Rp)"
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(37, 9)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(90, 14)
        Me.lbl_tanggal_upload.TabIndex = 113
        Me.lbl_tanggal_upload.Text = "Bulan Upload"
        '
        'txt_dpp_upload
        '
        Me.txt_dpp_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_upload.Location = New System.Drawing.Point(587, 32)
        Me.txt_dpp_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_upload.Name = "txt_dpp_upload"
        Me.txt_dpp_upload.ReadOnly = True
        Me.txt_dpp_upload.Size = New System.Drawing.Size(165, 22)
        Me.txt_dpp_upload.TabIndex = 223
        Me.txt_dpp_upload.TabStop = False
        Me.txt_dpp_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(386, 13)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(129, 14)
        Me.Label23.TabIndex = 225
        Me.Label23.Text = "DPP Penjualan (Rp)"
        '
        'dtp_tanggal_upload
        '
        Me.dtp_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_upload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_upload.Location = New System.Drawing.Point(150, 28)
        Me.dtp_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_upload.Name = "dtp_tanggal_upload"
        Me.dtp_tanggal_upload.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_upload.TabIndex = 114
        Me.dtp_tanggal_upload.TabStop = False
        '
        'txt_dpp_penjualan
        '
        Me.txt_dpp_penjualan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_penjualan.Location = New System.Drawing.Point(381, 32)
        Me.txt_dpp_penjualan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_penjualan.Name = "txt_dpp_penjualan"
        Me.txt_dpp_penjualan.ReadOnly = True
        Me.txt_dpp_penjualan.Size = New System.Drawing.Size(190, 22)
        Me.txt_dpp_penjualan.TabIndex = 224
        Me.txt_dpp_penjualan.TabStop = False
        Me.txt_dpp_penjualan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_upload
        '
        Me.dgv_upload.AllowUserToAddRows = False
        Me.dgv_upload.AllowUserToDeleteRows = False
        Me.dgv_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_upload.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_upload.Location = New System.Drawing.Point(571, 46)
        Me.dgv_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_upload.MultiSelect = False
        Me.dgv_upload.Name = "dgv_upload"
        Me.dgv_upload.ReadOnly = True
        Me.dgv_upload.Size = New System.Drawing.Size(565, 230)
        Me.dgv_upload.TabIndex = 151
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(730, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 16)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "DATA PEMBELIAN SUDAH DI UPLOAD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(722, 286)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(262, 16)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "DATA PEMBELIAN AKAN BATAL UPLOAD"
        '
        'dgv_batal_upload
        '
        Me.dgv_batal_upload.AllowUserToAddRows = False
        Me.dgv_batal_upload.AllowUserToDeleteRows = False
        Me.dgv_batal_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_batal_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_batal_upload.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_batal_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_batal_upload.Location = New System.Drawing.Point(571, 306)
        Me.dgv_batal_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_batal_upload.MultiSelect = False
        Me.dgv_batal_upload.Name = "dgv_batal_upload"
        Me.dgv_batal_upload.ReadOnly = True
        Me.dgv_batal_upload.Size = New System.Drawing.Size(565, 184)
        Me.dgv_batal_upload.TabIndex = 153
        '
        'dgv_tampil_upload
        '
        Me.dgv_tampil_upload.AllowUserToAddRows = False
        Me.dgv_tampil_upload.AllowUserToDeleteRows = False
        Me.dgv_tampil_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_tampil_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_tampil_upload.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_tampil_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_tampil_upload.Location = New System.Drawing.Point(571, 46)
        Me.dgv_tampil_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_tampil_upload.MultiSelect = False
        Me.dgv_tampil_upload.Name = "dgv_tampil_upload"
        Me.dgv_tampil_upload.ReadOnly = True
        Me.dgv_tampil_upload.Size = New System.Drawing.Size(565, 230)
        Me.dgv_tampil_upload.TabIndex = 155
        '
        'btn_batal_upload
        '
        Me.btn_batal_upload.BackColor = System.Drawing.SystemColors.Window
        Me.btn_batal_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_batal_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_batal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_batal_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_batal_upload.Location = New System.Drawing.Point(214, 5)
        Me.btn_batal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_batal_upload.Name = "btn_batal_upload"
        Me.btn_batal_upload.Size = New System.Drawing.Size(134, 30)
        Me.btn_batal_upload.TabIndex = 233
        Me.btn_batal_upload.TabStop = False
        Me.btn_batal_upload.Text = "BATAL UPLOAD"
        Me.btn_batal_upload.UseMnemonic = False
        Me.btn_batal_upload.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_batal_upload)
        Me.Panel2.Location = New System.Drawing.Point(571, 494)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(565, 42)
        Me.Panel2.TabIndex = 234
        '
        'dgv_penjualan
        '
        Me.dgv_penjualan.AllowUserToAddRows = False
        Me.dgv_penjualan.AllowUserToDeleteRows = False
        Me.dgv_penjualan.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_penjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_penjualan.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_penjualan.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_penjualan.Location = New System.Drawing.Point(0, 306)
        Me.dgv_penjualan.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_penjualan.MultiSelect = False
        Me.dgv_penjualan.Name = "dgv_penjualan"
        Me.dgv_penjualan.ReadOnly = True
        Me.dgv_penjualan.Size = New System.Drawing.Size(565, 230)
        Me.dgv_penjualan.TabIndex = 249
        '
        'btnCek
        '
        Me.btnCek.BackColor = System.Drawing.SystemColors.Window
        Me.btnCek.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCek.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCek.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCek.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCek.Location = New System.Drawing.Point(523, 2)
        Me.btnCek.Margin = New System.Windows.Forms.Padding(1)
        Me.btnCek.Name = "btnCek"
        Me.btnCek.Size = New System.Drawing.Size(48, 30)
        Me.btnCek.TabIndex = 233
        Me.btnCek.TabStop = False
        Me.btnCek.Text = "CEK"
        Me.btnCek.UseMnemonic = False
        Me.btnCek.UseVisualStyleBackColor = False
        '
        'form_upload_pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 611)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_batal_upload)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgv_upload)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_tampil_upload)
        Me.Controls.Add(Me.dgv3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.dgv_penjualan)
        Me.Name = "form_upload_pembelian"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_upload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_batal_upload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_tampil_upload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv_penjualan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv3 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_kosong_tanggal_upload As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents dtp_tanggal_upload As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv_upload As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_selisih_ppn As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_penjualan As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_upload As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_akan_upload As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_batal_upload As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_tampil_upload As System.Windows.Forms.DataGridView
    Friend WithEvents btn_batal_upload As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgv_penjualan As System.Windows.Forms.DataGridView
    Friend WithEvents btnCek As System.Windows.Forms.Button
End Class
