<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_omset_penjualan
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_kode_omset = New System.Windows.Forms.TextBox()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_sisa_omset = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_polos = New System.Windows.Forms.TextBox()
        Me.txt_dpp_kain = New System.Windows.Forms.TextBox()
        Me.txt_grand_total_kain = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_client = New System.Windows.Forms.TextBox()
        Me.btn_client = New System.Windows.Forms.Button()
        Me.btn_kosong_tanggal = New System.Windows.Forms.Button()
        Me.txt_tanggal = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_grand_total_omset = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_dpp_omset = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_tanggal_asal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_client_asal = New System.Windows.Forms.TextBox()
        Me.txt_grand_total_omset_asal = New System.Windows.Forms.TextBox()
        Me.txt_dpp_omset_asal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_id_omset = New System.Windows.Forms.TextBox()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_hapus_cari = New System.Windows.Forms.Button()
        Me.txt_tanggal_cari = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_cari = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgv_client = New System.Windows.Forms.DataGridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv_client, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_kode_omset
        '
        Me.txt_kode_omset.Location = New System.Drawing.Point(13, 430)
        Me.txt_kode_omset.Name = "txt_kode_omset"
        Me.txt_kode_omset.Size = New System.Drawing.Size(122, 22)
        Me.txt_kode_omset.TabIndex = 49
        Me.txt_kode_omset.Visible = False
        '
        'btn_update
        '
        Me.btn_update.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_update.Location = New System.Drawing.Point(118, 310)
        Me.btn_update.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(80, 29)
        Me.btn_update.TabIndex = 48
        Me.btn_update.Text = "UPDATE"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_sisa_omset)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_polos)
        Me.Panel2.Controls.Add(Me.txt_dpp_kain)
        Me.Panel2.Controls.Add(Me.txt_grand_total_kain)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txt_client)
        Me.Panel2.Controls.Add(Me.btn_client)
        Me.Panel2.Controls.Add(Me.btn_kosong_tanggal)
        Me.Panel2.Controls.Add(Me.txt_tanggal)
        Me.Panel2.Controls.Add(Me.dtp_tanggal)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txt_grand_total_omset)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txt_dpp_omset)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(414, 291)
        Me.Panel2.TabIndex = 46
        '
        'txt_sisa_omset
        '
        Me.txt_sisa_omset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sisa_omset.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sisa_omset.Location = New System.Drawing.Point(159, 249)
        Me.txt_sisa_omset.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_sisa_omset.MaxLength = 30
        Me.txt_sisa_omset.Name = "txt_sisa_omset"
        Me.txt_sisa_omset.ReadOnly = True
        Me.txt_sisa_omset.Size = New System.Drawing.Size(170, 22)
        Me.txt_sisa_omset.TabIndex = 513
        Me.txt_sisa_omset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 253)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 14)
        Me.Label9.TabIndex = 512
        Me.Label9.Text = "Sisa Omset"
        '
        'txt_polos
        '
        Me.txt_polos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_polos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_polos.Location = New System.Drawing.Point(159, 217)
        Me.txt_polos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_polos.MaxLength = 30
        Me.txt_polos.Name = "txt_polos"
        Me.txt_polos.ReadOnly = True
        Me.txt_polos.Size = New System.Drawing.Size(170, 22)
        Me.txt_polos.TabIndex = 511
        Me.txt_polos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_dpp_kain
        '
        Me.txt_dpp_kain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dpp_kain.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_kain.Location = New System.Drawing.Point(159, 185)
        Me.txt_dpp_kain.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_dpp_kain.MaxLength = 30
        Me.txt_dpp_kain.Name = "txt_dpp_kain"
        Me.txt_dpp_kain.ReadOnly = True
        Me.txt_dpp_kain.Size = New System.Drawing.Size(170, 22)
        Me.txt_dpp_kain.TabIndex = 510
        Me.txt_dpp_kain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_grand_total_kain
        '
        Me.txt_grand_total_kain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_grand_total_kain.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grand_total_kain.Location = New System.Drawing.Point(159, 153)
        Me.txt_grand_total_kain.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_grand_total_kain.MaxLength = 30
        Me.txt_grand_total_kain.Name = "txt_grand_total_kain"
        Me.txt_grand_total_kain.ReadOnly = True
        Me.txt_grand_total_kain.Size = New System.Drawing.Size(170, 22)
        Me.txt_grand_total_kain.TabIndex = 509
        Me.txt_grand_total_kain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 221)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Polos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 61)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 14)
        Me.Label13.TabIndex = 505
        Me.Label13.Text = "Client"
        '
        'txt_client
        '
        Me.txt_client.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_client.Location = New System.Drawing.Point(159, 57)
        Me.txt_client.Name = "txt_client"
        Me.txt_client.Size = New System.Drawing.Size(202, 22)
        Me.txt_client.TabIndex = 506
        Me.txt_client.TabStop = False
        '
        'btn_client
        '
        Me.btn_client.BackColor = System.Drawing.SystemColors.Control
        Me.btn_client.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_client.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_client.Location = New System.Drawing.Point(363, 56)
        Me.btn_client.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_client.Name = "btn_client"
        Me.btn_client.Size = New System.Drawing.Size(24, 24)
        Me.btn_client.TabIndex = 507
        Me.btn_client.TabStop = False
        Me.btn_client.Text = "X"
        Me.btn_client.UseVisualStyleBackColor = False
        '
        'btn_kosong_tanggal
        '
        Me.btn_kosong_tanggal.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal.Location = New System.Drawing.Point(310, 25)
        Me.btn_kosong_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal.Name = "btn_kosong_tanggal"
        Me.btn_kosong_tanggal.Size = New System.Drawing.Size(27, 22)
        Me.btn_kosong_tanggal.TabIndex = 125
        Me.btn_kosong_tanggal.TabStop = False
        Me.btn_kosong_tanggal.Text = "X"
        Me.btn_kosong_tanggal.UseMnemonic = False
        Me.btn_kosong_tanggal.UseVisualStyleBackColor = False
        '
        'txt_tanggal
        '
        Me.txt_tanggal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal.Location = New System.Drawing.Point(159, 25)
        Me.txt_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal.Name = "txt_tanggal"
        Me.txt_tanggal.ReadOnly = True
        Me.txt_tanggal.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal.TabIndex = 124
        Me.txt_tanggal.TabStop = False
        Me.txt_tanggal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(292, 25)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal.TabIndex = 123
        Me.dtp_tanggal.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 189)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "DPP Kain"
        '
        'txt_grand_total_omset
        '
        Me.txt_grand_total_omset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_grand_total_omset.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grand_total_omset.Location = New System.Drawing.Point(159, 89)
        Me.txt_grand_total_omset.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_grand_total_omset.MaxLength = 15
        Me.txt_grand_total_omset.Name = "txt_grand_total_omset"
        Me.txt_grand_total_omset.Size = New System.Drawing.Size(170, 22)
        Me.txt_grand_total_omset.TabIndex = 3
        Me.txt_grand_total_omset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Bulan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 157)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 14)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Grand Total Kain"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 14)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Grand Total Omset"
        '
        'txt_dpp_omset
        '
        Me.txt_dpp_omset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dpp_omset.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_omset.Location = New System.Drawing.Point(159, 121)
        Me.txt_dpp_omset.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_dpp_omset.MaxLength = 30
        Me.txt_dpp_omset.Name = "txt_dpp_omset"
        Me.txt_dpp_omset.Size = New System.Drawing.Size(170, 22)
        Me.txt_dpp_omset.TabIndex = 4
        Me.txt_dpp_omset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 125)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "DPP Omset"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None
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
        Me.dgv1.Location = New System.Drawing.Point(422, 76)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(700, 445)
        Me.dgv1.TabIndex = 50
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txt_tanggal_asal)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_client_asal)
        Me.Panel1.Controls.Add(Me.txt_grand_total_omset_asal)
        Me.Panel1.Controls.Add(Me.txt_dpp_omset_asal)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_kode_omset)
        Me.Panel1.Controls.Add(Me.btn_update)
        Me.Panel1.Controls.Add(Me.txt_id_omset)
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.btn_refresh)
        Me.Panel1.Controls.Add(Me.btn_hapus)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 494)
        Me.Panel1.TabIndex = 51
        '
        'txt_tanggal_asal
        '
        Me.txt_tanggal_asal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_asal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_asal.Location = New System.Drawing.Point(80, 460)
        Me.txt_tanggal_asal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_asal.Name = "txt_tanggal_asal"
        Me.txt_tanggal_asal.ReadOnly = True
        Me.txt_tanggal_asal.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_asal.TabIndex = 515
        Me.txt_tanggal_asal.TabStop = False
        Me.txt_tanggal_asal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_tanggal_asal.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(219, 442)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 14)
        Me.Label14.TabIndex = 514
        Me.Label14.Text = "Client Asal"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 463)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 514
        Me.Label15.Text = "Bulan"
        Me.Label15.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(252, 398)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 14)
        Me.Label12.TabIndex = 514
        Me.Label12.Text = "DPP Omset Asal"
        Me.Label12.Visible = False
        '
        'txt_client_asal
        '
        Me.txt_client_asal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_client_asal.Location = New System.Drawing.Point(214, 460)
        Me.txt_client_asal.Name = "txt_client_asal"
        Me.txt_client_asal.Size = New System.Drawing.Size(202, 22)
        Me.txt_client_asal.TabIndex = 515
        Me.txt_client_asal.TabStop = False
        Me.txt_client_asal.Visible = False
        '
        'txt_grand_total_omset_asal
        '
        Me.txt_grand_total_omset_asal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_grand_total_omset_asal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_grand_total_omset_asal.Location = New System.Drawing.Point(247, 372)
        Me.txt_grand_total_omset_asal.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_grand_total_omset_asal.MaxLength = 15
        Me.txt_grand_total_omset_asal.Name = "txt_grand_total_omset_asal"
        Me.txt_grand_total_omset_asal.Size = New System.Drawing.Size(170, 22)
        Me.txt_grand_total_omset_asal.TabIndex = 514
        Me.txt_grand_total_omset_asal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_grand_total_omset_asal.Visible = False
        '
        'txt_dpp_omset_asal
        '
        Me.txt_dpp_omset_asal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_dpp_omset_asal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_omset_asal.Location = New System.Drawing.Point(246, 416)
        Me.txt_dpp_omset_asal.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_dpp_omset_asal.MaxLength = 30
        Me.txt_dpp_omset_asal.Name = "txt_dpp_omset_asal"
        Me.txt_dpp_omset_asal.Size = New System.Drawing.Size(170, 22)
        Me.txt_dpp_omset_asal.TabIndex = 515
        Me.txt_dpp_omset_asal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_dpp_omset_asal.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 413)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 14)
        Me.Label11.TabIndex = 513
        Me.Label11.Text = "Kode Omset"
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(252, 354)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 14)
        Me.Label10.TabIndex = 513
        Me.Label10.Text = "Grand Total Omset Asal"
        Me.Label10.Visible = False
        '
        'txt_id_omset
        '
        Me.txt_id_omset.Location = New System.Drawing.Point(14, 383)
        Me.txt_id_omset.Name = "txt_id_omset"
        Me.txt_id_omset.Size = New System.Drawing.Size(122, 22)
        Me.txt_id_omset.TabIndex = 47
        Me.txt_id_omset.Visible = False
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(14, 310)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(80, 29)
        Me.btn_simpan.TabIndex = 30
        Me.btn_simpan.Text = "SIMPAN"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'btn_refresh
        '
        Me.btn_refresh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_refresh.Location = New System.Drawing.Point(326, 310)
        Me.btn_refresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(80, 29)
        Me.btn_refresh.TabIndex = 45
        Me.btn_refresh.Text = "REFRESH"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_hapus
        '
        Me.btn_hapus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus.Location = New System.Drawing.Point(222, 310)
        Me.btn_hapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(80, 29)
        Me.btn_hapus.TabIndex = 44
        Me.btn_hapus.Text = "HAPUS"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel3.Controls.Add(Me.btn_hapus_cari)
        Me.Panel3.Controls.Add(Me.txt_tanggal_cari)
        Me.Panel3.Controls.Add(Me.dtp_tanggal_cari)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(422, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(700, 46)
        Me.Panel3.TabIndex = 52
        '
        'btn_hapus_cari
        '
        Me.btn_hapus_cari.BackColor = System.Drawing.SystemColors.Window
        Me.btn_hapus_cari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_hapus_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hapus_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus_cari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus_cari.Location = New System.Drawing.Point(231, 11)
        Me.btn_hapus_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_hapus_cari.Name = "btn_hapus_cari"
        Me.btn_hapus_cari.Size = New System.Drawing.Size(27, 22)
        Me.btn_hapus_cari.TabIndex = 128
        Me.btn_hapus_cari.TabStop = False
        Me.btn_hapus_cari.Text = "X"
        Me.btn_hapus_cari.UseMnemonic = False
        Me.btn_hapus_cari.UseVisualStyleBackColor = False
        '
        'txt_tanggal_cari
        '
        Me.txt_tanggal_cari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_cari.Location = New System.Drawing.Point(80, 11)
        Me.txt_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_cari.Name = "txt_tanggal_cari"
        Me.txt_tanggal_cari.ReadOnly = True
        Me.txt_tanggal_cari.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_cari.TabIndex = 127
        Me.txt_tanggal_cari.TabStop = False
        Me.txt_tanggal_cari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_tanggal_cari
        '
        Me.dtp_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_cari.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_cari.Location = New System.Drawing.Point(213, 11)
        Me.dtp_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_cari.Name = "dtp_tanggal_cari"
        Me.dtp_tanggal_cari.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_cari.TabIndex = 126
        Me.dtp_tanggal_cari.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "CARI"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label7.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1122, 26)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "OMSET PENJUALAN"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv_client
        '
        Me.dgv_client.AllowUserToAddRows = False
        Me.dgv_client.AllowUserToDeleteRows = False
        Me.dgv_client.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_client.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_client.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_client.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_client.Location = New System.Drawing.Point(162, 114)
        Me.dgv_client.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv_client.MultiSelect = False
        Me.dgv_client.Name = "dgv_client"
        Me.dgv_client.ReadOnly = True
        Me.dgv_client.Size = New System.Drawing.Size(227, 350)
        Me.dgv_client.TabIndex = 508
        Me.dgv_client.TabStop = False
        Me.dgv_client.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 366)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 14)
        Me.Label16.TabIndex = 516
        Me.Label16.Text = "Id Omset"
        Me.Label16.Visible = False
        '
        'form_omset_penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 521)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.dgv_client)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_omset_penjualan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgv_client, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_kode_omset As System.Windows.Forms.TextBox
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_grand_total_omset As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_omset As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_id_omset As System.Windows.Forms.TextBox
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_kosong_tanggal As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_client As System.Windows.Forms.TextBox
    Friend WithEvents btn_client As System.Windows.Forms.Button
    Friend WithEvents dgv_client As System.Windows.Forms.DataGridView
    Friend WithEvents txt_polos As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_kain As System.Windows.Forms.TextBox
    Friend WithEvents txt_grand_total_kain As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_hapus_cari As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal_cari As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_cari As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_sisa_omset As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_grand_total_omset_asal As System.Windows.Forms.TextBox
    Friend WithEvents txt_dpp_omset_asal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_client_asal As System.Windows.Forms.TextBox
    Friend WithEvents txt_tanggal_asal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
