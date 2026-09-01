<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_retur
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
        Me.panelRetur = New System.Windows.Forms.Panel()
        Me.txt_kode_grey = New System.Windows.Forms.TextBox()
        Me.txt_kode_neraca = New System.Windows.Forms.TextBox()
        Me.Txt_kode = New System.Windows.Forms.TextBox()
        Me.txt_dpp_asal = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal = New System.Windows.Forms.TextBox()
        Me.txt_id_grey_retur = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_no_faktur_retur = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nama_grey_retur = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_jumlah_retur = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.txt_kode_induk = New System.Windows.Forms.TextBox()
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
        Me.panelRetur.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelRetur
        '
        Me.panelRetur.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panelRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRetur.Controls.Add(Me.txt_kode_grey)
        Me.panelRetur.Controls.Add(Me.txt_kode_neraca)
        Me.panelRetur.Controls.Add(Me.Txt_kode)
        Me.panelRetur.Controls.Add(Me.txt_dpp_asal)
        Me.panelRetur.Controls.Add(Me.txt_jumlah_asal)
        Me.panelRetur.Controls.Add(Me.txt_id_grey_retur)
        Me.panelRetur.Controls.Add(Me.Label7)
        Me.panelRetur.Controls.Add(Me.Label6)
        Me.panelRetur.Controls.Add(Me.txt_no_faktur_retur)
        Me.panelRetur.Controls.Add(Me.Label5)
        Me.panelRetur.Controls.Add(Me.txt_nama_grey_retur)
        Me.panelRetur.Controls.Add(Me.Label4)
        Me.panelRetur.Controls.Add(Me.txt_jumlah_retur)
        Me.panelRetur.Controls.Add(Me.Label3)
        Me.panelRetur.Controls.Add(Me.Label2)
        Me.panelRetur.Controls.Add(Me.Label1)
        Me.panelRetur.Controls.Add(Me.dgv2)
        Me.panelRetur.Controls.Add(Me.dgv1)
        Me.panelRetur.Controls.Add(Me.txt_kode_induk)
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
        Me.panelRetur.Location = New System.Drawing.Point(12, 9)
        Me.panelRetur.Name = "panelRetur"
        Me.panelRetur.Size = New System.Drawing.Size(773, 542)
        Me.panelRetur.TabIndex = 235
        '
        'txt_kode_grey
        '
        Me.txt_kode_grey.Location = New System.Drawing.Point(362, 292)
        Me.txt_kode_grey.Name = "txt_kode_grey"
        Me.txt_kode_grey.Size = New System.Drawing.Size(174, 22)
        Me.txt_kode_grey.TabIndex = 181
        Me.txt_kode_grey.TabStop = False
        Me.txt_kode_grey.Visible = False
        '
        'txt_kode_neraca
        '
        Me.txt_kode_neraca.Location = New System.Drawing.Point(542, 292)
        Me.txt_kode_neraca.Name = "txt_kode_neraca"
        Me.txt_kode_neraca.Size = New System.Drawing.Size(174, 22)
        Me.txt_kode_neraca.TabIndex = 180
        Me.txt_kode_neraca.TabStop = False
        Me.txt_kode_neraca.Visible = False
        '
        'Txt_kode
        '
        Me.Txt_kode.Location = New System.Drawing.Point(247, 264)
        Me.Txt_kode.Name = "Txt_kode"
        Me.Txt_kode.Size = New System.Drawing.Size(174, 22)
        Me.Txt_kode.TabIndex = 179
        Me.Txt_kode.TabStop = False
        Me.Txt_kode.Visible = False
        '
        'txt_dpp_asal
        '
        Me.txt_dpp_asal.Location = New System.Drawing.Point(713, 264)
        Me.txt_dpp_asal.MaxLength = 70
        Me.txt_dpp_asal.Name = "txt_dpp_asal"
        Me.txt_dpp_asal.Size = New System.Drawing.Size(50, 22)
        Me.txt_dpp_asal.TabIndex = 178
        Me.txt_dpp_asal.TabStop = False
        Me.txt_dpp_asal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_dpp_asal.Visible = False
        '
        'txt_jumlah_asal
        '
        Me.txt_jumlah_asal.Location = New System.Drawing.Point(656, 264)
        Me.txt_jumlah_asal.MaxLength = 70
        Me.txt_jumlah_asal.Name = "txt_jumlah_asal"
        Me.txt_jumlah_asal.Size = New System.Drawing.Size(50, 22)
        Me.txt_jumlah_asal.TabIndex = 177
        Me.txt_jumlah_asal.TabStop = False
        Me.txt_jumlah_asal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal.Visible = False
        '
        'txt_id_grey_retur
        '
        Me.txt_id_grey_retur.Location = New System.Drawing.Point(599, 264)
        Me.txt_id_grey_retur.Name = "txt_id_grey_retur"
        Me.txt_id_grey_retur.Size = New System.Drawing.Size(50, 22)
        Me.txt_id_grey_retur.TabIndex = 176
        Me.txt_id_grey_retur.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 14)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "DATA RETUR GREY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 402)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "No Faktur"
        '
        'txt_no_faktur_retur
        '
        Me.txt_no_faktur_retur.Location = New System.Drawing.Point(150, 399)
        Me.txt_no_faktur_retur.MaxLength = 70
        Me.txt_no_faktur_retur.Name = "txt_no_faktur_retur"
        Me.txt_no_faktur_retur.ReadOnly = True
        Me.txt_no_faktur_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_no_faktur_retur.TabIndex = 173
        Me.txt_no_faktur_retur.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 432)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 172
        Me.Label5.Text = "Nama Grey"
        '
        'txt_nama_grey_retur
        '
        Me.txt_nama_grey_retur.Location = New System.Drawing.Point(150, 429)
        Me.txt_nama_grey_retur.MaxLength = 70
        Me.txt_nama_grey_retur.Name = "txt_nama_grey_retur"
        Me.txt_nama_grey_retur.ReadOnly = True
        Me.txt_nama_grey_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_nama_grey_retur.TabIndex = 171
        Me.txt_nama_grey_retur.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(389, 342)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "Jumlah"
        '
        'txt_jumlah_retur
        '
        Me.txt_jumlah_retur.Location = New System.Drawing.Point(515, 339)
        Me.txt_jumlah_retur.MaxLength = 70
        Me.txt_jumlah_retur.Name = "txt_jumlah_retur"
        Me.txt_jumlah_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_jumlah_retur.TabIndex = 169
        Me.txt_jumlah_retur.TabStop = False
        Me.txt_jumlah_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 13)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "*pilih grey yang akan di retur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 14)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "DATA PEMBELIAN"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "STOK GREY"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(5, 172)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(760, 90)
        Me.dgv2.TabIndex = 165
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
        Me.dgv1.Location = New System.Drawing.Point(4, 61)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(760, 90)
        Me.dgv1.TabIndex = 164
        '
        'txt_kode_induk
        '
        Me.txt_kode_induk.Location = New System.Drawing.Point(428, 264)
        Me.txt_kode_induk.Name = "txt_kode_induk"
        Me.txt_kode_induk.Size = New System.Drawing.Size(165, 22)
        Me.txt_kode_induk.TabIndex = 163
        Me.txt_kode_induk.Visible = False
        '
        'btn_hitung_retur
        '
        Me.btn_hitung_retur.BackColor = System.Drawing.SystemColors.Control
        Me.btn_hitung_retur.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_hitung_retur.Location = New System.Drawing.Point(194, 488)
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
        Me.Label22.Location = New System.Drawing.Point(389, 432)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 16)
        Me.Label22.TabIndex = 161
        Me.Label22.Text = "Grand Total (Rp)"
        '
        'txt_total_retur
        '
        Me.txt_total_retur.Location = New System.Drawing.Point(515, 429)
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
        Me.lblPPN.Location = New System.Drawing.Point(389, 402)
        Me.lblPPN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(104, 16)
        Me.lblPPN.TabIndex = 159
        Me.lblPPN.Text = "Total PPN (Rp)"
        '
        'txt_ppn_retur
        '
        Me.txt_ppn_retur.Location = New System.Drawing.Point(515, 399)
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
        Me.Label20.Location = New System.Drawing.Point(389, 372)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 157
        Me.Label20.Text = "Total DPP (Rp)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(56, 372)
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
        Me.Label17.Location = New System.Drawing.Point(56, 342)
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
        Me.dtp_tanggal_retur.Location = New System.Drawing.Point(150, 339)
        Me.dtp_tanggal_retur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_retur.Name = "dtp_tanggal_retur"
        Me.dtp_tanggal_retur.Size = New System.Drawing.Size(119, 22)
        Me.dtp_tanggal_retur.TabIndex = 149
        Me.dtp_tanggal_retur.TabStop = False
        '
        'txt_supplier_retur
        '
        Me.txt_supplier_retur.Location = New System.Drawing.Point(150, 369)
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
        Me.Label18.Size = New System.Drawing.Size(758, 28)
        Me.Label18.TabIndex = 144
        Me.Label18.Text = "RETUR PEMBELIAN GREY"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_simpan_retur
        '
        Me.btn_simpan_retur.BackColor = System.Drawing.SystemColors.Control
        Me.btn_simpan_retur.Enabled = False
        Me.btn_simpan_retur.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_simpan_retur.Location = New System.Drawing.Point(327, 488)
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
        Me.btn_batal_retur.Location = New System.Drawing.Point(460, 488)
        Me.btn_batal_retur.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_batal_retur.Name = "btn_batal_retur"
        Me.btn_batal_retur.Size = New System.Drawing.Size(117, 30)
        Me.btn_batal_retur.TabIndex = 25
        Me.btn_batal_retur.Text = "BATAL"
        Me.btn_batal_retur.UseVisualStyleBackColor = False
        '
        'txt_dpp_retur
        '
        Me.txt_dpp_retur.Location = New System.Drawing.Point(515, 369)
        Me.txt_dpp_retur.MaxLength = 70
        Me.txt_dpp_retur.Name = "txt_dpp_retur"
        Me.txt_dpp_retur.ReadOnly = True
        Me.txt_dpp_retur.Size = New System.Drawing.Size(199, 22)
        Me.txt_dpp_retur.TabIndex = 143
        Me.txt_dpp_retur.TabStop = False
        Me.txt_dpp_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'form_retur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 561)
        Me.Controls.Add(Me.panelRetur)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_retur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelRetur.ResumeLayout(False)
        Me.panelRetur.PerformLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelRetur As System.Windows.Forms.Panel
    Friend WithEvents btn_hitung_retur As System.Windows.Forms.Button
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
    Friend WithEvents txt_kode_induk As System.Windows.Forms.TextBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_no_faktur_retur As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nama_grey_retur As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlah_retur As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_grey_retur As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_asal As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_kode As System.Windows.Forms.TextBox
    Friend WithEvents txt_kode_neraca As System.Windows.Forms.TextBox
    Friend WithEvents txt_kode_grey As System.Windows.Forms.TextBox
End Class
