<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_input_harga_jual_grey
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_dpp_grey_ppn = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_nama_jual = New System.Windows.Forms.ComboBox()
        Me.txt_dpp_tersedia = New System.Windows.Forms.TextBox()
        Me.txt_harga_dpp_penjualan = New System.Windows.Forms.TextBox()
        Me.txt_harga_jual_ppn = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Supplier = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_nama_grey = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_dpp_grey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_jumlah = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_no_faktur = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_kode_grey = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_id_beli = New System.Windows.Forms.TextBox()
        Me.txt_kode_beli = New System.Windows.Forms.TextBox()
        Me.btn_hitung = New System.Windows.Forms.Button()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_kode_neraca = New System.Windows.Forms.TextBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(2, 2)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1127, 28)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "INPUT NAMA DAN HARGA JUAL GREY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(6, 6)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1115, 234)
        Me.dgv1.TabIndex = 21
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.txt_dpp_grey_ppn)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cbo_nama_jual)
        Me.Panel1.Controls.Add(Me.txt_dpp_tersedia)
        Me.Panel1.Controls.Add(Me.dgv1)
        Me.Panel1.Controls.Add(Me.txt_harga_dpp_penjualan)
        Me.Panel1.Controls.Add(Me.txt_harga_jual_ppn)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txt_Supplier)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_nama_grey)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txt_dpp_grey)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_jumlah)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_no_faktur)
        Me.Panel1.Controls.Add(Me.dtp_tanggal)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 33)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1127, 524)
        Me.Panel1.TabIndex = 124
        '
        'txt_dpp_grey_ppn
        '
        Me.txt_dpp_grey_ppn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_grey_ppn.Location = New System.Drawing.Point(27, 328)
        Me.txt_dpp_grey_ppn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_grey_ppn.Name = "txt_dpp_grey_ppn"
        Me.txt_dpp_grey_ppn.ReadOnly = True
        Me.txt_dpp_grey_ppn.Size = New System.Drawing.Size(200, 22)
        Me.txt_dpp_grey_ppn.TabIndex = 161
        Me.txt_dpp_grey_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(33, 310)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(188, 16)
        Me.Label15.TabIndex = 160
        Me.Label15.Text = "Harga DPP Grey + PPN (Rp)"
        '
        'cbo_nama_jual
        '
        Me.cbo_nama_jual.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_nama_jual.FormattingEnabled = True
        Me.cbo_nama_jual.Items.AddRange(New Object() {"Cotton", "Polyester", "Polyester Cotton", "Polyester Rayon"})
        Me.cbo_nama_jual.Location = New System.Drawing.Point(245, 328)
        Me.cbo_nama_jual.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_nama_jual.MaxDropDownItems = 15
        Me.cbo_nama_jual.Name = "cbo_nama_jual"
        Me.cbo_nama_jual.Size = New System.Drawing.Size(200, 22)
        Me.cbo_nama_jual.Sorted = True
        Me.cbo_nama_jual.TabIndex = 156
        Me.cbo_nama_jual.TabStop = False
        '
        'txt_dpp_tersedia
        '
        Me.txt_dpp_tersedia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_tersedia.Location = New System.Drawing.Point(899, 328)
        Me.txt_dpp_tersedia.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_tersedia.Name = "txt_dpp_tersedia"
        Me.txt_dpp_tersedia.ReadOnly = True
        Me.txt_dpp_tersedia.Size = New System.Drawing.Size(200, 22)
        Me.txt_dpp_tersedia.TabIndex = 155
        Me.txt_dpp_tersedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_harga_dpp_penjualan
        '
        Me.txt_harga_dpp_penjualan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_harga_dpp_penjualan.Location = New System.Drawing.Point(681, 328)
        Me.txt_harga_dpp_penjualan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_harga_dpp_penjualan.Name = "txt_harga_dpp_penjualan"
        Me.txt_harga_dpp_penjualan.ReadOnly = True
        Me.txt_harga_dpp_penjualan.Size = New System.Drawing.Size(200, 22)
        Me.txt_harga_dpp_penjualan.TabIndex = 151
        Me.txt_harga_dpp_penjualan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_harga_jual_ppn
        '
        Me.txt_harga_jual_ppn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_harga_jual_ppn.Location = New System.Drawing.Point(463, 328)
        Me.txt_harga_jual_ppn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_harga_jual_ppn.Name = "txt_harga_jual_ppn"
        Me.txt_harga_jual_ppn.Size = New System.Drawing.Size(200, 22)
        Me.txt_harga_jual_ppn.TabIndex = 150
        Me.txt_harga_jual_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(308, 310)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 16)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "Nama Jual"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(936, 310)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 16)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "DPP Tersedia (Rp)"
        '
        'txt_Supplier
        '
        Me.txt_Supplier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Supplier.Location = New System.Drawing.Point(319, 269)
        Me.txt_Supplier.Name = "txt_Supplier"
        Me.txt_Supplier.ReadOnly = True
        Me.txt_Supplier.Size = New System.Drawing.Size(200, 22)
        Me.txt_Supplier.TabIndex = 143
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(590, 251)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 16)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Nama grey"
        '
        'txt_nama_grey
        '
        Me.txt_nama_grey.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nama_grey.Location = New System.Drawing.Point(529, 269)
        Me.txt_nama_grey.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_nama_grey.Name = "txt_nama_grey"
        Me.txt_nama_grey.ReadOnly = True
        Me.txt_nama_grey.Size = New System.Drawing.Size(200, 22)
        Me.txt_nama_grey.TabIndex = 121
        Me.txt_nama_grey.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(927, 251)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 16)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Harga DPP Grey (Rp)"
        '
        'txt_dpp_grey
        '
        Me.txt_dpp_grey.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_grey.Location = New System.Drawing.Point(899, 269)
        Me.txt_dpp_grey.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_grey.Name = "txt_dpp_grey"
        Me.txt_dpp_grey.ReadOnly = True
        Me.txt_dpp_grey.Size = New System.Drawing.Size(200, 22)
        Me.txt_dpp_grey.TabIndex = 2
        Me.txt_dpp_grey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 251)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Tanggal Beli"
        '
        'txt_jumlah
        '
        Me.txt_jumlah.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah.Location = New System.Drawing.Point(739, 269)
        Me.txt_jumlah.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah.Name = "txt_jumlah"
        Me.txt_jumlah.ReadOnly = True
        Me.txt_jumlah.Size = New System.Drawing.Size(150, 22)
        Me.txt_jumlah.TabIndex = 1
        Me.txt_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(389, 251)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 110
        Me.Label13.Text = "Supplier"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(695, 310)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(172, 16)
        Me.Label27.TabIndex = 118
        Me.Label27.Text = "Harga DPP Penjualan(Rp)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 251)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "No Faktur"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(782, 251)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Quantity"
        '
        'txt_no_faktur
        '
        Me.txt_no_faktur.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_faktur.Location = New System.Drawing.Point(144, 269)
        Me.txt_no_faktur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_no_faktur.Name = "txt_no_faktur"
        Me.txt_no_faktur.ReadOnly = True
        Me.txt_no_faktur.Size = New System.Drawing.Size(165, 22)
        Me.txt_no_faktur.TabIndex = 0
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Enabled = False
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(27, 269)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(107, 22)
        Me.dtp_tanggal.TabIndex = 108
        Me.dtp_tanggal.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(487, 310)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 16)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Harga Jual + PPN (Rp)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 363)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1108, 147)
        Me.GroupBox1.TabIndex = 158
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Grey Yang Sama"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(12, 22)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(1084, 113)
        Me.dgv2.TabIndex = 157
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(339, 14)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 16)
        Me.Label14.TabIndex = 154
        Me.Label14.Text = "kode grey"
        Me.Label14.Visible = False
        '
        'txt_kode_grey
        '
        Me.txt_kode_grey.Location = New System.Drawing.Point(295, 33)
        Me.txt_kode_grey.Name = "txt_kode_grey"
        Me.txt_kode_grey.Size = New System.Drawing.Size(174, 21)
        Me.txt_kode_grey.TabIndex = 153
        Me.txt_kode_grey.TabStop = False
        Me.txt_kode_grey.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(159, 14)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 152
        Me.Label11.Text = "kode beli"
        Me.Label11.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(36, 14)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "id beli"
        Me.Label7.Visible = False
        '
        'txt_id_beli
        '
        Me.txt_id_beli.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli.Location = New System.Drawing.Point(10, 33)
        Me.txt_id_beli.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli.Name = "txt_id_beli"
        Me.txt_id_beli.Size = New System.Drawing.Size(100, 23)
        Me.txt_id_beli.TabIndex = 146
        Me.txt_id_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli.Visible = False
        '
        'txt_kode_beli
        '
        Me.txt_kode_beli.Location = New System.Drawing.Point(115, 33)
        Me.txt_kode_beli.Name = "txt_kode_beli"
        Me.txt_kode_beli.Size = New System.Drawing.Size(174, 21)
        Me.txt_kode_beli.TabIndex = 142
        Me.txt_kode_beli.TabStop = False
        Me.txt_kode_beli.Visible = False
        '
        'btn_hitung
        '
        Me.btn_hitung.BackColor = System.Drawing.SystemColors.Window
        Me.btn_hitung.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_hitung.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hitung.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hitung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hitung.Location = New System.Drawing.Point(416, 14)
        Me.btn_hitung.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_hitung.Name = "btn_hitung"
        Me.btn_hitung.Size = New System.Drawing.Size(105, 30)
        Me.btn_hitung.TabIndex = 139
        Me.btn_hitung.TabStop = False
        Me.btn_hitung.Text = "HITUNG"
        Me.btn_hitung.UseMnemonic = False
        Me.btn_hitung.UseVisualStyleBackColor = False
        '
        'btn_simpan
        '
        Me.btn_simpan.BackColor = System.Drawing.SystemColors.Window
        Me.btn_simpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_simpan.Enabled = False
        Me.btn_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(600, 14)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(111, 30)
        Me.btn_simpan.TabIndex = 124
        Me.btn_simpan.TabStop = False
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseMnemonic = False
        Me.btn_simpan.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txt_kode_neraca)
        Me.Panel2.Controls.Add(Me.btn_simpan)
        Me.Panel2.Controls.Add(Me.btn_hitung)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txt_kode_grey)
        Me.Panel2.Controls.Add(Me.txt_kode_beli)
        Me.Panel2.Controls.Add(Me.txt_id_beli)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(2, 560)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1127, 59)
        Me.Panel2.TabIndex = 144
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(758, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "Kode Neraca"
        Me.Label3.Visible = False
        '
        'txt_kode_neraca
        '
        Me.txt_kode_neraca.Location = New System.Drawing.Point(716, 35)
        Me.txt_kode_neraca.Name = "txt_kode_neraca"
        Me.txt_kode_neraca.Size = New System.Drawing.Size(174, 21)
        Me.txt_kode_neraca.TabIndex = 155
        Me.txt_kode_neraca.TabStop = False
        Me.txt_kode_neraca.Visible = False
        '
        'form_input_harga_jual_grey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 621)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "form_input_harga_jual_grey"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_Supplier As System.Windows.Forms.TextBox
    Friend WithEvents txt_kode_beli As System.Windows.Forms.TextBox
    Friend WithEvents btn_hitung As System.Windows.Forms.Button
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_nama_grey As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_grey As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_id_beli As System.Windows.Forms.TextBox
    Friend WithEvents txt_harga_jual_ppn As System.Windows.Forms.TextBox
    Friend WithEvents txt_harga_dpp_penjualan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_tersedia As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_kode_grey As System.Windows.Forms.TextBox
    Friend WithEvents cbo_nama_jual As System.Windows.Forms.ComboBox
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_kode_neraca As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_grey_ppn As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
