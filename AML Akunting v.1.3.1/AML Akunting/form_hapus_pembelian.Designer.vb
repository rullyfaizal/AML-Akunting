<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_hapus_pembelian
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
        Me.txt_no_faktur = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbo_pembayaran = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.CboJenisBiaya = New System.Windows.Forms.ComboBox()
        Me.dtp_tanggal_upload = New System.Windows.Forms.DateTimePicker()
        Me.Cbo_Supplier = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.txt_jumlah_asal10 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal9 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal8 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal7 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal6 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal5 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal4 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal3 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal2 = New System.Windows.Forms.TextBox()
        Me.txt_jumlah_asal1 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli10 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli9 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli8 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli7 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli6 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli5 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli4 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli3 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli2 = New System.Windows.Forms.TextBox()
        Me.txt_id_beli1 = New System.Windows.Forms.TextBox()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_total_polos = New System.Windows.Forms.TextBox()
        Me.txt_total_ppn = New System.Windows.Forms.TextBox()
        Me.txt_total_dpp = New System.Windows.Forms.TextBox()
        Me.txt_gran_total = New System.Windows.Forms.TextBox()
        Me.Txt_kode = New System.Windows.Forms.TextBox()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_no_faktur
        '
        Me.txt_no_faktur.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_no_faktur.Location = New System.Drawing.Point(182, 30)
        Me.txt_no_faktur.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_no_faktur.Name = "txt_no_faktur"
        Me.txt_no_faktur.Size = New System.Drawing.Size(164, 23)
        Me.txt_no_faktur.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cbo_pembayaran)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_tanggal_upload)
        Me.Panel2.Controls.Add(Me.lbl_tanggal_upload)
        Me.Panel2.Controls.Add(Me.txt_no_faktur)
        Me.Panel2.Controls.Add(Me.dtp_tanggal)
        Me.Panel2.Controls.Add(Me.CboJenisBiaya)
        Me.Panel2.Controls.Add(Me.dtp_tanggal_upload)
        Me.Panel2.Controls.Add(Me.Cbo_Supplier)
        Me.Panel2.Location = New System.Drawing.Point(0, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1200, 74)
        Me.Panel2.TabIndex = 141
        '
        'cbo_pembayaran
        '
        Me.cbo_pembayaran.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_pembayaran.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_pembayaran.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_pembayaran.FormattingEnabled = True
        Me.cbo_pembayaran.Items.AddRange(New Object() {"Cash", "CC", "TT"})
        Me.cbo_pembayaran.Location = New System.Drawing.Point(859, 30)
        Me.cbo_pembayaran.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_pembayaran.MaxDropDownItems = 15
        Me.cbo_pembayaran.Name = "cbo_pembayaran"
        Me.cbo_pembayaran.Size = New System.Drawing.Size(118, 24)
        Me.cbo_pembayaran.Sorted = True
        Me.cbo_pembayaran.TabIndex = 125
        Me.cbo_pembayaran.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(874, 12)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "Pembayaran"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Tanggal Beli"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(683, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Jenis Biaya"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(452, 12)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 110
        Me.Label13.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(229, 12)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "No Faktur"
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(1008, 31)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 23)
        Me.txt_tanggal_upload.TabIndex = 118
        Me.txt_tanggal_upload.TabStop = False
        Me.txt_tanggal_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(1027, 12)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(92, 16)
        Me.lbl_tanggal_upload.TabIndex = 113
        Me.lbl_tanggal_upload.Text = "Bulan Upload"
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(44, 30)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(107, 23)
        Me.dtp_tanggal.TabIndex = 108
        Me.dtp_tanggal.TabStop = False
        '
        'CboJenisBiaya
        '
        Me.CboJenisBiaya.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboJenisBiaya.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboJenisBiaya.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboJenisBiaya.FormattingEnabled = True
        Me.CboJenisBiaya.Location = New System.Drawing.Point(618, 30)
        Me.CboJenisBiaya.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CboJenisBiaya.MaxDropDownItems = 15
        Me.CboJenisBiaya.Name = "CboJenisBiaya"
        Me.CboJenisBiaya.Size = New System.Drawing.Size(210, 24)
        Me.CboJenisBiaya.Sorted = True
        Me.CboJenisBiaya.TabIndex = 2
        Me.CboJenisBiaya.TabStop = False
        '
        'dtp_tanggal_upload
        '
        Me.dtp_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_upload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_upload.Location = New System.Drawing.Point(1142, 31)
        Me.dtp_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_upload.Name = "dtp_tanggal_upload"
        Me.dtp_tanggal_upload.Size = New System.Drawing.Size(15, 23)
        Me.dtp_tanggal_upload.TabIndex = 114
        Me.dtp_tanggal_upload.TabStop = False
        '
        'Cbo_Supplier
        '
        Me.Cbo_Supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cbo_Supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cbo_Supplier.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Supplier.FormattingEnabled = True
        Me.Cbo_Supplier.Location = New System.Drawing.Point(377, 30)
        Me.Cbo_Supplier.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Cbo_Supplier.MaxDropDownItems = 15
        Me.Cbo_Supplier.Name = "Cbo_Supplier"
        Me.Cbo_Supplier.Size = New System.Drawing.Size(210, 24)
        Me.Cbo_Supplier.Sorted = True
        Me.Cbo_Supplier.TabIndex = 1
        Me.Cbo_Supplier.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.dgv1)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal10)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal9)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal8)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal7)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal6)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal5)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal4)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal3)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal2)
        Me.Panel1.Controls.Add(Me.txt_jumlah_asal1)
        Me.Panel1.Controls.Add(Me.txt_id_beli10)
        Me.Panel1.Controls.Add(Me.txt_id_beli9)
        Me.Panel1.Controls.Add(Me.txt_id_beli8)
        Me.Panel1.Controls.Add(Me.txt_id_beli7)
        Me.Panel1.Controls.Add(Me.txt_id_beli6)
        Me.Panel1.Controls.Add(Me.txt_id_beli5)
        Me.Panel1.Controls.Add(Me.txt_id_beli4)
        Me.Panel1.Controls.Add(Me.txt_id_beli3)
        Me.Panel1.Controls.Add(Me.txt_id_beli2)
        Me.Panel1.Controls.Add(Me.txt_id_beli1)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txt_total_polos)
        Me.Panel1.Controls.Add(Me.txt_total_ppn)
        Me.Panel1.Controls.Add(Me.txt_total_dpp)
        Me.Panel1.Controls.Add(Me.txt_gran_total)
        Me.Panel1.Controls.Add(Me.Txt_kode)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgv2)
        Me.Panel1.Location = New System.Drawing.Point(-8, 24)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 546)
        Me.Panel1.TabIndex = 125
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
        Me.dgv1.Location = New System.Drawing.Point(30, 80)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1141, 333)
        Me.dgv1.TabIndex = 143
        '
        'txt_jumlah_asal10
        '
        Me.txt_jumlah_asal10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal10.Location = New System.Drawing.Point(1073, 422)
        Me.txt_jumlah_asal10.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal10.Name = "txt_jumlah_asal10"
        Me.txt_jumlah_asal10.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal10.TabIndex = 257
        Me.txt_jumlah_asal10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal10.Visible = False
        '
        'txt_jumlah_asal9
        '
        Me.txt_jumlah_asal9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal9.Location = New System.Drawing.Point(1023, 480)
        Me.txt_jumlah_asal9.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal9.Name = "txt_jumlah_asal9"
        Me.txt_jumlah_asal9.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal9.TabIndex = 256
        Me.txt_jumlah_asal9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal9.Visible = False
        '
        'txt_jumlah_asal8
        '
        Me.txt_jumlah_asal8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal8.Location = New System.Drawing.Point(1023, 451)
        Me.txt_jumlah_asal8.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal8.Name = "txt_jumlah_asal8"
        Me.txt_jumlah_asal8.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal8.TabIndex = 255
        Me.txt_jumlah_asal8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal8.Visible = False
        '
        'txt_jumlah_asal7
        '
        Me.txt_jumlah_asal7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal7.Location = New System.Drawing.Point(1023, 422)
        Me.txt_jumlah_asal7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal7.Name = "txt_jumlah_asal7"
        Me.txt_jumlah_asal7.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal7.TabIndex = 254
        Me.txt_jumlah_asal7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal7.Visible = False
        '
        'txt_jumlah_asal6
        '
        Me.txt_jumlah_asal6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal6.Location = New System.Drawing.Point(973, 480)
        Me.txt_jumlah_asal6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal6.Name = "txt_jumlah_asal6"
        Me.txt_jumlah_asal6.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal6.TabIndex = 253
        Me.txt_jumlah_asal6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal6.Visible = False
        '
        'txt_jumlah_asal5
        '
        Me.txt_jumlah_asal5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal5.Location = New System.Drawing.Point(973, 451)
        Me.txt_jumlah_asal5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal5.Name = "txt_jumlah_asal5"
        Me.txt_jumlah_asal5.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal5.TabIndex = 252
        Me.txt_jumlah_asal5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal5.Visible = False
        '
        'txt_jumlah_asal4
        '
        Me.txt_jumlah_asal4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal4.Location = New System.Drawing.Point(973, 422)
        Me.txt_jumlah_asal4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal4.Name = "txt_jumlah_asal4"
        Me.txt_jumlah_asal4.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal4.TabIndex = 251
        Me.txt_jumlah_asal4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal4.Visible = False
        '
        'txt_jumlah_asal3
        '
        Me.txt_jumlah_asal3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal3.Location = New System.Drawing.Point(923, 478)
        Me.txt_jumlah_asal3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal3.Name = "txt_jumlah_asal3"
        Me.txt_jumlah_asal3.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal3.TabIndex = 250
        Me.txt_jumlah_asal3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal3.Visible = False
        '
        'txt_jumlah_asal2
        '
        Me.txt_jumlah_asal2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal2.Location = New System.Drawing.Point(923, 451)
        Me.txt_jumlah_asal2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal2.Name = "txt_jumlah_asal2"
        Me.txt_jumlah_asal2.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal2.TabIndex = 249
        Me.txt_jumlah_asal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal2.Visible = False
        '
        'txt_jumlah_asal1
        '
        Me.txt_jumlah_asal1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah_asal1.Location = New System.Drawing.Point(923, 422)
        Me.txt_jumlah_asal1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_jumlah_asal1.Name = "txt_jumlah_asal1"
        Me.txt_jumlah_asal1.Size = New System.Drawing.Size(46, 23)
        Me.txt_jumlah_asal1.TabIndex = 248
        Me.txt_jumlah_asal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_jumlah_asal1.Visible = False
        '
        'txt_id_beli10
        '
        Me.txt_id_beli10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli10.Location = New System.Drawing.Point(180, 422)
        Me.txt_id_beli10.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli10.Name = "txt_id_beli10"
        Me.txt_id_beli10.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli10.TabIndex = 247
        Me.txt_id_beli10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli10.Visible = False
        '
        'txt_id_beli9
        '
        Me.txt_id_beli9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli9.Location = New System.Drawing.Point(130, 480)
        Me.txt_id_beli9.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli9.Name = "txt_id_beli9"
        Me.txt_id_beli9.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli9.TabIndex = 246
        Me.txt_id_beli9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli9.Visible = False
        '
        'txt_id_beli8
        '
        Me.txt_id_beli8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli8.Location = New System.Drawing.Point(130, 451)
        Me.txt_id_beli8.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli8.Name = "txt_id_beli8"
        Me.txt_id_beli8.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli8.TabIndex = 245
        Me.txt_id_beli8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli8.Visible = False
        '
        'txt_id_beli7
        '
        Me.txt_id_beli7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli7.Location = New System.Drawing.Point(130, 422)
        Me.txt_id_beli7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli7.Name = "txt_id_beli7"
        Me.txt_id_beli7.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli7.TabIndex = 244
        Me.txt_id_beli7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli7.Visible = False
        '
        'txt_id_beli6
        '
        Me.txt_id_beli6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli6.Location = New System.Drawing.Point(80, 480)
        Me.txt_id_beli6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli6.Name = "txt_id_beli6"
        Me.txt_id_beli6.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli6.TabIndex = 243
        Me.txt_id_beli6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli6.Visible = False
        '
        'txt_id_beli5
        '
        Me.txt_id_beli5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli5.Location = New System.Drawing.Point(80, 451)
        Me.txt_id_beli5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli5.Name = "txt_id_beli5"
        Me.txt_id_beli5.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli5.TabIndex = 242
        Me.txt_id_beli5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli5.Visible = False
        '
        'txt_id_beli4
        '
        Me.txt_id_beli4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli4.Location = New System.Drawing.Point(80, 422)
        Me.txt_id_beli4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli4.Name = "txt_id_beli4"
        Me.txt_id_beli4.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli4.TabIndex = 241
        Me.txt_id_beli4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli4.Visible = False
        '
        'txt_id_beli3
        '
        Me.txt_id_beli3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli3.Location = New System.Drawing.Point(30, 478)
        Me.txt_id_beli3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli3.Name = "txt_id_beli3"
        Me.txt_id_beli3.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli3.TabIndex = 240
        Me.txt_id_beli3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli3.Visible = False
        '
        'txt_id_beli2
        '
        Me.txt_id_beli2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli2.Location = New System.Drawing.Point(30, 451)
        Me.txt_id_beli2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli2.Name = "txt_id_beli2"
        Me.txt_id_beli2.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli2.TabIndex = 239
        Me.txt_id_beli2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli2.Visible = False
        '
        'txt_id_beli1
        '
        Me.txt_id_beli1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_beli1.Location = New System.Drawing.Point(30, 422)
        Me.txt_id_beli1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_id_beli1.Name = "txt_id_beli1"
        Me.txt_id_beli1.Size = New System.Drawing.Size(46, 23)
        Me.txt_id_beli1.TabIndex = 238
        Me.txt_id_beli1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_id_beli1.Visible = False
        '
        'btn_hapus
        '
        Me.btn_hapus.BackColor = System.Drawing.SystemColors.Window
        Me.btn_hapus.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus.Location = New System.Drawing.Point(546, 495)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(108, 34)
        Me.btn_hapus.TabIndex = 222
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(776, 422)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 16)
        Me.Label26.TabIndex = 220
        Me.Label26.Text = "Grand Total (Rp)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(631, 422)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 16)
        Me.Label25.TabIndex = 219
        Me.Label25.Text = "Total PPN (Rp)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(480, 422)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(104, 16)
        Me.Label24.TabIndex = 218
        Me.Label24.Text = "Total DPP (Rp)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(310, 422)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 16)
        Me.Label23.TabIndex = 217
        Me.Label23.Text = "Total Polos (Rp)"
        '
        'txt_total_polos
        '
        Me.txt_total_polos.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_polos.Location = New System.Drawing.Point(291, 441)
        Me.txt_total_polos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_polos.Name = "txt_total_polos"
        Me.txt_total_polos.ReadOnly = True
        Me.txt_total_polos.Size = New System.Drawing.Size(150, 23)
        Me.txt_total_polos.TabIndex = 216
        Me.txt_total_polos.TabStop = False
        Me.txt_total_polos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_ppn
        '
        Me.txt_total_ppn.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_ppn.Location = New System.Drawing.Point(623, 441)
        Me.txt_total_ppn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_ppn.Name = "txt_total_ppn"
        Me.txt_total_ppn.ReadOnly = True
        Me.txt_total_ppn.Size = New System.Drawing.Size(120, 23)
        Me.txt_total_ppn.TabIndex = 215
        Me.txt_total_ppn.TabStop = False
        Me.txt_total_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_dpp
        '
        Me.txt_total_dpp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_dpp.Location = New System.Drawing.Point(457, 441)
        Me.txt_total_dpp.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_total_dpp.Name = "txt_total_dpp"
        Me.txt_total_dpp.ReadOnly = True
        Me.txt_total_dpp.Size = New System.Drawing.Size(150, 23)
        Me.txt_total_dpp.TabIndex = 214
        Me.txt_total_dpp.TabStop = False
        Me.txt_total_dpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_gran_total
        '
        Me.txt_gran_total.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gran_total.Location = New System.Drawing.Point(759, 441)
        Me.txt_gran_total.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_gran_total.Name = "txt_gran_total"
        Me.txt_gran_total.ReadOnly = True
        Me.txt_gran_total.Size = New System.Drawing.Size(150, 23)
        Me.txt_gran_total.TabIndex = 213
        Me.txt_gran_total.TabStop = False
        Me.txt_gran_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_kode
        '
        Me.Txt_kode.Location = New System.Drawing.Point(232, 502)
        Me.Txt_kode.Name = "Txt_kode"
        Me.Txt_kode.Size = New System.Drawing.Size(174, 23)
        Me.Txt_kode.TabIndex = 142
        Me.Txt_kode.TabStop = False
        Me.Txt_kode.Visible = False
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
        Me.dgv2.Location = New System.Drawing.Point(84, 222)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(893, 113)
        Me.dgv2.TabIndex = 221
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(-8, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1200, 26)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "HAPUS PEMBELIAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_hapus_pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1184, 611)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "form_hapus_pembelian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbo_pembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboJenisBiaya As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_tanggal_upload As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbo_Supplier As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txt_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_total_polos As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_ppn As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_dpp As System.Windows.Forms.TextBox
    Friend WithEvents txt_gran_total As System.Windows.Forms.TextBox
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents txt_id_beli10 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli9 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli8 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli7 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_beli1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal10 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal9 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal8 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal7 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jumlah_asal1 As System.Windows.Forms.TextBox
End Class
