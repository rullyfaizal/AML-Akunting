<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_data_grey
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_harga_jual = New System.Windows.Forms.ToolStripButton()
        Me.ts_hapus = New System.Windows.Forms.ToolStripButton()
        Me.ts_perbarui = New System.Windows.Forms.ToolStripButton()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_cari = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_dpp_tersedia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_akhir = New System.Windows.Forms.TextBox()
        Me.txt_awal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_masuk = New System.Windows.Forms.TextBox()
        Me.txt_keluar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.dtp_hari_ini = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cb_kosong = New System.Windows.Forms.CheckBox()
        Me.cb_bs = New System.Windows.Forms.CheckBox()
        Me.cb_tersedia = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rb_kosong = New System.Windows.Forms.RadioButton()
        Me.rb_bs = New System.Windows.Forms.RadioButton()
        Me.rb_tersedia = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_akhir = New System.Windows.Forms.DateTimePicker()
        Me.dtp_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ts_edit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_harga_jual, Me.ts_edit, Me.ts_hapus, Me.ts_perbarui})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1131, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_harga_jual
        '
        Me.ts_harga_jual.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_harga_jual.Name = "ts_harga_jual"
        Me.ts_harga_jual.Size = New System.Drawing.Size(173, 22)
        Me.ts_harga_jual.Text = "Input Harga Jual   |"
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
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.SystemColors.Control
        Me.btn_reset.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_reset.Location = New System.Drawing.Point(142, 190)
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
        Me.btn_cari.Location = New System.Drawing.Point(31, 190)
        Me.btn_cari.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 30)
        Me.btn_cari.TabIndex = 14
        Me.btn_cari.Text = "CARI"
        Me.btn_cari.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txt_dpp_tersedia)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_akhir)
        Me.Panel2.Location = New System.Drawing.Point(255, 516)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 68)
        Me.Panel2.TabIndex = 26
        '
        'txt_dpp_tersedia
        '
        Me.txt_dpp_tersedia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_tersedia.Location = New System.Drawing.Point(457, 31)
        Me.txt_dpp_tersedia.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_tersedia.Name = "txt_dpp_tersedia"
        Me.txt_dpp_tersedia.ReadOnly = True
        Me.txt_dpp_tersedia.Size = New System.Drawing.Size(200, 22)
        Me.txt_dpp_tersedia.TabIndex = 175
        Me.txt_dpp_tersedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(479, 13)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 16)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "DPP Jual Tersedia (Rp)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(229, 13)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(172, 16)
        Me.Label9.TabIndex = 171
        Me.Label9.Text = "Stok Tersedia (Mtr/Yard)"
        '
        'txt_akhir
        '
        Me.txt_akhir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_akhir.Location = New System.Drawing.Point(215, 31)
        Me.txt_akhir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_akhir.Name = "txt_akhir"
        Me.txt_akhir.ReadOnly = True
        Me.txt_akhir.Size = New System.Drawing.Size(200, 22)
        Me.txt_akhir.TabIndex = 167
        Me.txt_akhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_awal
        '
        Me.txt_awal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_awal.Location = New System.Drawing.Point(38, 384)
        Me.txt_awal.Name = "txt_awal"
        Me.txt_awal.ReadOnly = True
        Me.txt_awal.Size = New System.Drawing.Size(150, 22)
        Me.txt_awal.TabIndex = 174
        Me.txt_awal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_awal.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(86, 418)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Masuk"
        Me.Label12.Visible = False
        '
        'txt_masuk
        '
        Me.txt_masuk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_masuk.Location = New System.Drawing.Point(35, 436)
        Me.txt_masuk.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_masuk.Name = "txt_masuk"
        Me.txt_masuk.ReadOnly = True
        Me.txt_masuk.Size = New System.Drawing.Size(150, 22)
        Me.txt_masuk.TabIndex = 172
        Me.txt_masuk.TabStop = False
        Me.txt_masuk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_masuk.Visible = False
        '
        'txt_keluar
        '
        Me.txt_keluar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_keluar.Location = New System.Drawing.Point(36, 488)
        Me.txt_keluar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_keluar.Name = "txt_keluar"
        Me.txt_keluar.ReadOnly = True
        Me.txt_keluar.Size = New System.Drawing.Size(150, 22)
        Me.txt_keluar.TabIndex = 166
        Me.txt_keluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_keluar.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(76, 366)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 16)
        Me.Label13.TabIndex = 168
        Me.Label13.Text = "Stok Awal"
        Me.Label13.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 470)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Keluar"
        Me.Label1.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label6.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(2, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1127, 28)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "DATA STOK GREY"
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(255, 57)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(874, 456)
        Me.dgv1.TabIndex = 22
        '
        'dtp_hari_ini
        '
        Me.dtp_hari_ini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hari_ini.Location = New System.Drawing.Point(273, 111)
        Me.dtp_hari_ini.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_hari_ini.Name = "dtp_hari_ini"
        Me.dtp_hari_ini.Size = New System.Drawing.Size(100, 22)
        Me.dtp_hari_ini.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txt_awal)
        Me.Panel1.Controls.Add(Me.cb_kosong)
        Me.Panel1.Controls.Add(Me.btn_reset)
        Me.Panel1.Controls.Add(Me.cb_bs)
        Me.Panel1.Controls.Add(Me.cb_tersedia)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btn_cari)
        Me.Panel1.Controls.Add(Me.txt_masuk)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.txt_keluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 57)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 527)
        Me.Panel1.TabIndex = 23
        '
        'cb_kosong
        '
        Me.cb_kosong.AutoSize = True
        Me.cb_kosong.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_kosong.Location = New System.Drawing.Point(152, 337)
        Me.cb_kosong.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_kosong.Name = "cb_kosong"
        Me.cb_kosong.Size = New System.Drawing.Size(74, 20)
        Me.cb_kosong.TabIndex = 10
        Me.cb_kosong.Text = "Kosong"
        Me.cb_kosong.UseVisualStyleBackColor = True
        Me.cb_kosong.Visible = False
        '
        'cb_bs
        '
        Me.cb_bs.AutoSize = True
        Me.cb_bs.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bs.Location = New System.Drawing.Point(92, 337)
        Me.cb_bs.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_bs.Name = "cb_bs"
        Me.cb_bs.Size = New System.Drawing.Size(44, 20)
        Me.cb_bs.TabIndex = 9
        Me.cb_bs.Text = "BS"
        Me.cb_bs.UseVisualStyleBackColor = True
        Me.cb_bs.Visible = False
        '
        'cb_tersedia
        '
        Me.cb_tersedia.AutoSize = True
        Me.cb_tersedia.Checked = True
        Me.cb_tersedia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_tersedia.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tersedia.Location = New System.Drawing.Point(8, 337)
        Me.cb_tersedia.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_tersedia.Name = "cb_tersedia"
        Me.cb_tersedia.Size = New System.Drawing.Size(82, 20)
        Me.cb_tersedia.TabIndex = 8
        Me.cb_tersedia.Text = "Tersedia"
        Me.cb_tersedia.UseVisualStyleBackColor = True
        Me.cb_tersedia.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rb_kosong)
        Me.Panel3.Controls.Add(Me.rb_bs)
        Me.Panel3.Controls.Add(Me.rb_tersedia)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.dtp_akhir)
        Me.Panel3.Controls.Add(Me.dtp_awal)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(2, 6)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(245, 168)
        Me.Panel3.TabIndex = 15
        '
        'rb_kosong
        '
        Me.rb_kosong.AutoSize = True
        Me.rb_kosong.Location = New System.Drawing.Point(164, 137)
        Me.rb_kosong.Name = "rb_kosong"
        Me.rb_kosong.Size = New System.Drawing.Size(72, 18)
        Me.rb_kosong.TabIndex = 14
        Me.rb_kosong.Text = "Kosong"
        Me.rb_kosong.UseVisualStyleBackColor = True
        '
        'rb_bs
        '
        Me.rb_bs.AutoSize = True
        Me.rb_bs.Location = New System.Drawing.Point(105, 137)
        Me.rb_bs.Name = "rb_bs"
        Me.rb_bs.Size = New System.Drawing.Size(41, 18)
        Me.rb_bs.TabIndex = 13
        Me.rb_bs.Text = "BS"
        Me.rb_bs.UseVisualStyleBackColor = True
        '
        'rb_tersedia
        '
        Me.rb_tersedia.AutoSize = True
        Me.rb_tersedia.Checked = True
        Me.rb_tersedia.Location = New System.Drawing.Point(9, 137)
        Me.rb_tersedia.Name = "rb_tersedia"
        Me.rb_tersedia.Size = New System.Drawing.Size(78, 18)
        Me.rb_tersedia.TabIndex = 12
        Me.rb_tersedia.TabStop = True
        Me.rb_tersedia.Text = "Tersedia"
        Me.rb_tersedia.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Stok"
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
        'ts_edit
        '
        Me.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_edit.Name = "ts_edit"
        Me.ts_edit.Size = New System.Drawing.Size(79, 22)
        Me.ts_edit.Text = "Ubah   |"
        '
        'form_data_grey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 587)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtp_hari_ini)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_data_grey"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_harga_jual As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_hari_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cb_bs As System.Windows.Forms.CheckBox
    Friend WithEvents cb_tersedia As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ts_perbarui As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_kosong As System.Windows.Forms.CheckBox
    Friend WithEvents rb_kosong As System.Windows.Forms.RadioButton
    Friend WithEvents rb_bs As System.Windows.Forms.RadioButton
    Friend WithEvents rb_tersedia As System.Windows.Forms.RadioButton
    Friend WithEvents ts_hapus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
End Class
