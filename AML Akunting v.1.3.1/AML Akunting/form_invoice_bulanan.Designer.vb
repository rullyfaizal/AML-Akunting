<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_invoice_bulanan
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
        Me.panelPrintSuratJalanBulanan = New System.Windows.Forms.Panel()
        Me.dgv_list_sj = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_total_inv = New System.Windows.Forms.TextBox()
        Me.lblPPN = New System.Windows.Forms.Label()
        Me.txt_ppn_inv = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_dpp_inv = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_no_faktur = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_bulan = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_ket_sj_bulanan = New System.Windows.Forms.TextBox()
        Me.btn_ekspor_sj_bulanan = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_tanggal_print_sj_bulanan = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_print_sj_bulanan = New System.Windows.Forms.DateTimePicker()
        Me.txt_no_sj_print_bulanan = New System.Windows.Forms.TextBox()
        Me.txt_kota_client_bulanan = New System.Windows.Forms.TextBox()
        Me.txt_alamat_client_bulanan = New System.Windows.Forms.TextBox()
        Me.txt_client_bulanan = New System.Windows.Forms.TextBox()
        Me.lbl_print_sj_bulanan = New System.Windows.Forms.Label()
        Me.btn_print_sj_bulanan = New System.Windows.Forms.Button()
        Me.btn_batal_print_sj_bulanan = New System.Windows.Forms.Button()
        Me.dgv_print_sj_bulanan = New System.Windows.Forms.DataGridView()
        Me.panelPrintSuratJalanBulanan.SuspendLayout()
        CType(Me.dgv_list_sj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_print_sj_bulanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelPrintSuratJalanBulanan
        '
        Me.panelPrintSuratJalanBulanan.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panelPrintSuratJalanBulanan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.dgv_list_sj)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label22)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_total_inv)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.lblPPN)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_ppn_inv)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label20)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_dpp_inv)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label19)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_no_faktur)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label1)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_bulan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label13)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_ket_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.btn_ekspor_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label21)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.Label24)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_tanggal_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.dtp_tanggal_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_no_sj_print_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_kota_client_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_alamat_client_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.txt_client_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.lbl_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.btn_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.btn_batal_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Controls.Add(Me.dgv_print_sj_bulanan)
        Me.panelPrintSuratJalanBulanan.Location = New System.Drawing.Point(12, 10)
        Me.panelPrintSuratJalanBulanan.Name = "panelPrintSuratJalanBulanan"
        Me.panelPrintSuratJalanBulanan.Size = New System.Drawing.Size(630, 330)
        Me.panelPrintSuratJalanBulanan.TabIndex = 235
        '
        'dgv_list_sj
        '
        Me.dgv_list_sj.AllowUserToAddRows = False
        Me.dgv_list_sj.AllowUserToDeleteRows = False
        Me.dgv_list_sj.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_list_sj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_list_sj.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_list_sj.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_list_sj.Location = New System.Drawing.Point(14, 73)
        Me.dgv_list_sj.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_list_sj.MultiSelect = False
        Me.dgv_list_sj.Name = "dgv_list_sj"
        Me.dgv_list_sj.ReadOnly = True
        Me.dgv_list_sj.Size = New System.Drawing.Size(600, 200)
        Me.dgv_list_sj.TabIndex = 155
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(139, 134)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 16)
        Me.Label22.TabIndex = 248
        Me.Label22.Text = "TOTAL"
        '
        'txt_total_inv
        '
        Me.txt_total_inv.Location = New System.Drawing.Point(189, 131)
        Me.txt_total_inv.Name = "txt_total_inv"
        Me.txt_total_inv.ReadOnly = True
        Me.txt_total_inv.Size = New System.Drawing.Size(116, 20)
        Me.txt_total_inv.TabIndex = 247
        Me.txt_total_inv.TabStop = False
        Me.txt_total_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPPN
        '
        Me.lblPPN.AutoSize = True
        Me.lblPPN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPN.Location = New System.Drawing.Point(139, 110)
        Me.lblPPN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPPN.Name = "lblPPN"
        Me.lblPPN.Size = New System.Drawing.Size(33, 16)
        Me.lblPPN.TabIndex = 246
        Me.lblPPN.Text = "PPN"
        '
        'txt_ppn_inv
        '
        Me.txt_ppn_inv.Location = New System.Drawing.Point(189, 107)
        Me.txt_ppn_inv.Name = "txt_ppn_inv"
        Me.txt_ppn_inv.ReadOnly = True
        Me.txt_ppn_inv.Size = New System.Drawing.Size(116, 20)
        Me.txt_ppn_inv.TabIndex = 245
        Me.txt_ppn_inv.TabStop = False
        Me.txt_ppn_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(139, 86)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 16)
        Me.Label20.TabIndex = 244
        Me.Label20.Text = "DPP"
        '
        'txt_dpp_inv
        '
        Me.txt_dpp_inv.Location = New System.Drawing.Point(189, 83)
        Me.txt_dpp_inv.Name = "txt_dpp_inv"
        Me.txt_dpp_inv.ReadOnly = True
        Me.txt_dpp_inv.Size = New System.Drawing.Size(116, 20)
        Me.txt_dpp_inv.TabIndex = 243
        Me.txt_dpp_inv.TabStop = False
        Me.txt_dpp_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(17, 200)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 16)
        Me.Label19.TabIndex = 242
        Me.Label19.Text = "No Faktur"
        '
        'txt_no_faktur
        '
        Me.txt_no_faktur.Location = New System.Drawing.Point(102, 214)
        Me.txt_no_faktur.Name = "txt_no_faktur"
        Me.txt_no_faktur.ReadOnly = True
        Me.txt_no_faktur.Size = New System.Drawing.Size(130, 20)
        Me.txt_no_faktur.TabIndex = 241
        Me.txt_no_faktur.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(215, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 240
        Me.Label1.Text = "Bulan"
        '
        'txt_bulan
        '
        Me.txt_bulan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bulan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_bulan.Location = New System.Drawing.Point(264, 39)
        Me.txt_bulan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_bulan.Name = "txt_bulan"
        Me.txt_bulan.ReadOnly = True
        Me.txt_bulan.Size = New System.Drawing.Size(130, 22)
        Me.txt_bulan.TabIndex = 239
        Me.txt_bulan.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 184)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 16)
        Me.Label13.TabIndex = 238
        Me.Label13.Text = "Keterangan"
        '
        'txt_ket_sj_bulanan
        '
        Me.txt_ket_sj_bulanan.Location = New System.Drawing.Point(102, 194)
        Me.txt_ket_sj_bulanan.MaxLength = 70
        Me.txt_ket_sj_bulanan.Name = "txt_ket_sj_bulanan"
        Me.txt_ket_sj_bulanan.ReadOnly = True
        Me.txt_ket_sj_bulanan.Size = New System.Drawing.Size(116, 20)
        Me.txt_ket_sj_bulanan.TabIndex = 237
        Me.txt_ket_sj_bulanan.TabStop = False
        '
        'btn_ekspor_sj_bulanan
        '
        Me.btn_ekspor_sj_bulanan.BackColor = System.Drawing.SystemColors.Control
        Me.btn_ekspor_sj_bulanan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ekspor_sj_bulanan.Location = New System.Drawing.Point(256, 287)
        Me.btn_ekspor_sj_bulanan.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ekspor_sj_bulanan.Name = "btn_ekspor_sj_bulanan"
        Me.btn_ekspor_sj_bulanan.Size = New System.Drawing.Size(117, 30)
        Me.btn_ekspor_sj_bulanan.TabIndex = 236
        Me.btn_ekspor_sj_bulanan.Text = "EKSPOR"
        Me.btn_ekspor_sj_bulanan.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(17, 168)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 16)
        Me.Label21.TabIndex = 153
        Me.Label21.Text = "No SJ"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(17, 152)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 16)
        Me.Label24.TabIndex = 54
        Me.Label24.Text = "Tanggal"
        '
        'txt_tanggal_print_sj_bulanan
        '
        Me.txt_tanggal_print_sj_bulanan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_print_sj_bulanan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_print_sj_bulanan.Location = New System.Drawing.Point(102, 152)
        Me.txt_tanggal_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_print_sj_bulanan.Name = "txt_tanggal_print_sj_bulanan"
        Me.txt_tanggal_print_sj_bulanan.ReadOnly = True
        Me.txt_tanggal_print_sj_bulanan.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_print_sj_bulanan.TabIndex = 150
        Me.txt_tanggal_print_sj_bulanan.TabStop = False
        '
        'dtp_tanggal_print_sj_bulanan
        '
        Me.dtp_tanggal_print_sj_bulanan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_print_sj_bulanan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_print_sj_bulanan.Location = New System.Drawing.Point(398, 39)
        Me.dtp_tanggal_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_print_sj_bulanan.Name = "dtp_tanggal_print_sj_bulanan"
        Me.dtp_tanggal_print_sj_bulanan.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_print_sj_bulanan.TabIndex = 149
        Me.dtp_tanggal_print_sj_bulanan.TabStop = False
        '
        'txt_no_sj_print_bulanan
        '
        Me.txt_no_sj_print_bulanan.Location = New System.Drawing.Point(102, 174)
        Me.txt_no_sj_print_bulanan.Name = "txt_no_sj_print_bulanan"
        Me.txt_no_sj_print_bulanan.ReadOnly = True
        Me.txt_no_sj_print_bulanan.Size = New System.Drawing.Size(130, 20)
        Me.txt_no_sj_print_bulanan.TabIndex = 148
        Me.txt_no_sj_print_bulanan.TabStop = False
        '
        'txt_kota_client_bulanan
        '
        Me.txt_kota_client_bulanan.Location = New System.Drawing.Point(20, 129)
        Me.txt_kota_client_bulanan.Name = "txt_kota_client_bulanan"
        Me.txt_kota_client_bulanan.ReadOnly = True
        Me.txt_kota_client_bulanan.Size = New System.Drawing.Size(105, 20)
        Me.txt_kota_client_bulanan.TabIndex = 147
        Me.txt_kota_client_bulanan.TabStop = False
        '
        'txt_alamat_client_bulanan
        '
        Me.txt_alamat_client_bulanan.Location = New System.Drawing.Point(20, 106)
        Me.txt_alamat_client_bulanan.Name = "txt_alamat_client_bulanan"
        Me.txt_alamat_client_bulanan.ReadOnly = True
        Me.txt_alamat_client_bulanan.Size = New System.Drawing.Size(105, 20)
        Me.txt_alamat_client_bulanan.TabIndex = 146
        Me.txt_alamat_client_bulanan.TabStop = False
        '
        'txt_client_bulanan
        '
        Me.txt_client_bulanan.Location = New System.Drawing.Point(20, 83)
        Me.txt_client_bulanan.Name = "txt_client_bulanan"
        Me.txt_client_bulanan.ReadOnly = True
        Me.txt_client_bulanan.Size = New System.Drawing.Size(105, 20)
        Me.txt_client_bulanan.TabIndex = 145
        Me.txt_client_bulanan.TabStop = False
        '
        'lbl_print_sj_bulanan
        '
        Me.lbl_print_sj_bulanan.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.lbl_print_sj_bulanan.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_print_sj_bulanan.ForeColor = System.Drawing.SystemColors.Window
        Me.lbl_print_sj_bulanan.Location = New System.Drawing.Point(-1, 0)
        Me.lbl_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_print_sj_bulanan.Name = "lbl_print_sj_bulanan"
        Me.lbl_print_sj_bulanan.Size = New System.Drawing.Size(630, 28)
        Me.lbl_print_sj_bulanan.TabIndex = 144
        Me.lbl_print_sj_bulanan.Text = "INVOICE SATU BULAN"
        Me.lbl_print_sj_bulanan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_print_sj_bulanan
        '
        Me.btn_print_sj_bulanan.BackColor = System.Drawing.SystemColors.Control
        Me.btn_print_sj_bulanan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_print_sj_bulanan.Location = New System.Drawing.Point(115, 287)
        Me.btn_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_print_sj_bulanan.Name = "btn_print_sj_bulanan"
        Me.btn_print_sj_bulanan.Size = New System.Drawing.Size(117, 30)
        Me.btn_print_sj_bulanan.TabIndex = 27
        Me.btn_print_sj_bulanan.Text = "PRINT"
        Me.btn_print_sj_bulanan.UseVisualStyleBackColor = False
        '
        'btn_batal_print_sj_bulanan
        '
        Me.btn_batal_print_sj_bulanan.BackColor = System.Drawing.SystemColors.Control
        Me.btn_batal_print_sj_bulanan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_batal_print_sj_bulanan.Location = New System.Drawing.Point(397, 287)
        Me.btn_batal_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_batal_print_sj_bulanan.Name = "btn_batal_print_sj_bulanan"
        Me.btn_batal_print_sj_bulanan.Size = New System.Drawing.Size(117, 30)
        Me.btn_batal_print_sj_bulanan.TabIndex = 25
        Me.btn_batal_print_sj_bulanan.Text = "BATAL"
        Me.btn_batal_print_sj_bulanan.UseVisualStyleBackColor = False
        '
        'dgv_print_sj_bulanan
        '
        Me.dgv_print_sj_bulanan.AllowUserToAddRows = False
        Me.dgv_print_sj_bulanan.AllowUserToDeleteRows = False
        Me.dgv_print_sj_bulanan.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_print_sj_bulanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_print_sj_bulanan.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_print_sj_bulanan.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv_print_sj_bulanan.Location = New System.Drawing.Point(303, 83)
        Me.dgv_print_sj_bulanan.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_print_sj_bulanan.MultiSelect = False
        Me.dgv_print_sj_bulanan.Name = "dgv_print_sj_bulanan"
        Me.dgv_print_sj_bulanan.Size = New System.Drawing.Size(292, 173)
        Me.dgv_print_sj_bulanan.TabIndex = 24
        '
        'form_invoice_bulanan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 351)
        Me.Controls.Add(Me.panelPrintSuratJalanBulanan)
        Me.Name = "form_invoice_bulanan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelPrintSuratJalanBulanan.ResumeLayout(False)
        Me.panelPrintSuratJalanBulanan.PerformLayout()
        CType(Me.dgv_list_sj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_print_sj_bulanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPrintSuratJalanBulanan As System.Windows.Forms.Panel
    Friend WithEvents dgv_list_sj As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_bulan As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_ket_sj_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents btn_ekspor_sj_bulanan As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_tanggal_print_sj_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_print_sj_bulanan As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_no_sj_print_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents txt_kota_client_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents txt_alamat_client_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents txt_client_bulanan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_print_sj_bulanan As System.Windows.Forms.Label
    Friend WithEvents btn_print_sj_bulanan As System.Windows.Forms.Button
    Friend WithEvents btn_batal_print_sj_bulanan As System.Windows.Forms.Button
    Friend WithEvents dgv_print_sj_bulanan As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_total_inv As System.Windows.Forms.TextBox
    Friend WithEvents lblPPN As System.Windows.Forms.Label
    Friend WithEvents txt_ppn_inv As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_inv As System.Windows.Forms.TextBox
End Class
