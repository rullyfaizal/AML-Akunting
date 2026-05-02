<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_upload_penjualan
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_batal_upload = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.txt_selisih_ppn = New System.Windows.Forms.TextBox()
        Me.btn_kosong_tanggal_upload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.dgv_upload = New System.Windows.Forms.DataGridView()
        Me.btn_batal_upload = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.dgv_tampil_upload = New System.Windows.Forms.DataGridView()
        Me.txt_dpp_akan_upload = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.txt_dpp_upload = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtp_tanggal_upload = New System.Windows.Forms.DateTimePicker()
        Me.txt_dpp_penjualan = New System.Windows.Forms.TextBox()
        Me.dgv3 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_pembelian = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_batal_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_tampil_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_pembelian, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(778, 9)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(145, 14)
        Me.Label26.TabIndex = 228
        Me.Label26.Text = "DPP Akan Upload (Rp)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(722, 286)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(263, 16)
        Me.Label4.TabIndex = 245
        Me.Label4.Text = "DATA PENJUALAN AKAN BATAL UPLOAD"
        '
        'dgv_batal_upload
        '
        Me.dgv_batal_upload.AllowUserToAddRows = False
        Me.dgv_batal_upload.AllowUserToDeleteRows = False
        Me.dgv_batal_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_batal_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_batal_upload.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_batal_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_batal_upload.Location = New System.Drawing.Point(571, 306)
        Me.dgv_batal_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_batal_upload.MultiSelect = False
        Me.dgv_batal_upload.Name = "dgv_batal_upload"
        Me.dgv_batal_upload.ReadOnly = True
        Me.dgv_batal_upload.Size = New System.Drawing.Size(565, 184)
        Me.dgv_batal_upload.TabIndex = 244
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(730, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 16)
        Me.Label3.TabIndex = 243
        Me.Label3.Text = "DATA PENJUALAN SUDAH DI UPLOAD"
        '
        'btn_simpan
        '
        Me.btn_simpan.BackColor = System.Drawing.SystemColors.Window
        Me.btn_simpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(255, 14)
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
        Me.txt_selisih_ppn.Location = New System.Drawing.Point(949, 28)
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
        Me.btn_kosong_tanggal_upload.Location = New System.Drawing.Point(180, 28)
        Me.btn_kosong_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal_upload.Name = "btn_kosong_tanggal_upload"
        Me.btn_kosong_tanggal_upload.Size = New System.Drawing.Size(27, 22)
        Me.btn_kosong_tanggal_upload.TabIndex = 122
        Me.btn_kosong_tanggal_upload.TabStop = False
        Me.btn_kosong_tanggal_upload.Text = "X"
        Me.btn_kosong_tanggal_upload.UseMnemonic = False
        Me.btn_kosong_tanggal_upload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(978, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 14)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "Selisih PPN (Rp)"
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(29, 28)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_upload.TabIndex = 118
        Me.txt_tanggal_upload.TabStop = False
        Me.txt_tanggal_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv_upload
        '
        Me.dgv_upload.AllowUserToAddRows = False
        Me.dgv_upload.AllowUserToDeleteRows = False
        Me.dgv_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_upload.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_upload.Location = New System.Drawing.Point(571, 46)
        Me.dgv_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_upload.MultiSelect = False
        Me.dgv_upload.Name = "dgv_upload"
        Me.dgv_upload.ReadOnly = True
        Me.dgv_upload.Size = New System.Drawing.Size(565, 230)
        Me.dgv_upload.TabIndex = 242
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
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(0, 46)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(565, 230)
        Me.dgv1.TabIndex = 235
        '
        'dgv_tampil_upload
        '
        Me.dgv_tampil_upload.AllowUserToAddRows = False
        Me.dgv_tampil_upload.AllowUserToDeleteRows = False
        Me.dgv_tampil_upload.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_tampil_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_tampil_upload.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgv_tampil_upload.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_tampil_upload.Location = New System.Drawing.Point(571, 46)
        Me.dgv_tampil_upload.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_tampil_upload.MultiSelect = False
        Me.dgv_tampil_upload.Name = "dgv_tampil_upload"
        Me.dgv_tampil_upload.ReadOnly = True
        Me.dgv_tampil_upload.Size = New System.Drawing.Size(565, 230)
        Me.dgv_tampil_upload.TabIndex = 246
        '
        'txt_dpp_akan_upload
        '
        Me.txt_dpp_akan_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_akan_upload.Location = New System.Drawing.Point(768, 28)
        Me.txt_dpp_akan_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_akan_upload.Name = "txt_dpp_akan_upload"
        Me.txt_dpp_akan_upload.ReadOnly = True
        Me.txt_dpp_akan_upload.Size = New System.Drawing.Size(165, 22)
        Me.txt_dpp_akan_upload.TabIndex = 221
        Me.txt_dpp_akan_upload.TabStop = False
        Me.txt_dpp_akan_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_batal_upload)
        Me.Panel2.Location = New System.Drawing.Point(571, 494)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(565, 42)
        Me.Panel2.TabIndex = 247
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(614, 9)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 14)
        Me.Label25.TabIndex = 227
        Me.Label25.Text = "DPP Upload (Rp)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel1.TabIndex = 241
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(73, 9)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(42, 14)
        Me.lbl_tanggal_upload.TabIndex = 113
        Me.lbl_tanggal_upload.Text = "Bulan"
        '
        'txt_dpp_upload
        '
        Me.txt_dpp_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_upload.Location = New System.Drawing.Point(587, 28)
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
        Me.Label23.Location = New System.Drawing.Point(424, 9)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(131, 14)
        Me.Label23.TabIndex = 225
        Me.Label23.Text = "DPP Pembelian (Rp)"
        '
        'dtp_tanggal_upload
        '
        Me.dtp_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_upload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_upload.Location = New System.Drawing.Point(162, 28)
        Me.dtp_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_upload.Name = "dtp_tanggal_upload"
        Me.dtp_tanggal_upload.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_upload.TabIndex = 114
        Me.dtp_tanggal_upload.TabStop = False
        '
        'txt_dpp_penjualan
        '
        Me.txt_dpp_penjualan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_penjualan.Location = New System.Drawing.Point(406, 28)
        Me.txt_dpp_penjualan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_penjualan.Name = "txt_dpp_penjualan"
        Me.txt_dpp_penjualan.ReadOnly = True
        Me.txt_dpp_penjualan.Size = New System.Drawing.Size(165, 22)
        Me.txt_dpp_penjualan.TabIndex = 224
        Me.txt_dpp_penjualan.TabStop = False
        Me.txt_dpp_penjualan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv3.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgv3.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv3.Location = New System.Drawing.Point(0, 46)
        Me.dgv3.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv3.MultiSelect = False
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.Size = New System.Drawing.Size(565, 230)
        Me.dgv3.TabIndex = 240
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(167, 286)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 16)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "DATA PENJUALAN AKAN DIUPLOAD"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(0, 306)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(565, 230)
        Me.dgv2.TabIndex = 238
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(160, 28)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(245, 16)
        Me.Label17.TabIndex = 237
        Me.Label17.Text = "DATA PENJUALAN BELUM DI UPLOAD"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1136, 26)
        Me.Label1.TabIndex = 236
        Me.Label1.Text = "UPLOAD PENJUALAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_pembelian
        '
        Me.dgv_pembelian.AllowUserToAddRows = False
        Me.dgv_pembelian.AllowUserToDeleteRows = False
        Me.dgv_pembelian.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_pembelian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pembelian.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgv_pembelian.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_pembelian.Location = New System.Drawing.Point(0, 306)
        Me.dgv_pembelian.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_pembelian.MultiSelect = False
        Me.dgv_pembelian.Name = "dgv_pembelian"
        Me.dgv_pembelian.ReadOnly = True
        Me.dgv_pembelian.Size = New System.Drawing.Size(565, 230)
        Me.dgv_pembelian.TabIndex = 248
        '
        'form_upload_penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 611)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_batal_upload)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.dgv_upload)
        Me.Controls.Add(Me.dgv_tampil_upload)
        Me.Controls.Add(Me.dgv_pembelian)
        Me.Name = "form_upload_penjualan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv_batal_upload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_upload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_tampil_upload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_pembelian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_batal_upload As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents txt_selisih_ppn As System.Windows.Forms.TextBox
    Friend WithEvents btn_kosong_tanggal_upload As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents dgv_upload As System.Windows.Forms.DataGridView
    Friend WithEvents btn_batal_upload As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_tampil_upload As System.Windows.Forms.DataGridView
    Friend WithEvents txt_dpp_akan_upload As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_upload As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtp_tanggal_upload As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_dpp_penjualan As System.Windows.Forms.TextBox
    Friend WithEvents dgv3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_pembelian As System.Windows.Forms.DataGridView
End Class
