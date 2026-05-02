<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_export_excel_coretax
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_kode_transaksi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_generate = New System.Windows.Forms.Button()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.txt_tanggal = New System.Windows.Forms.TextBox()
        Me.btn_kosong_tanggal = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.btn_reset)
        Me.Panel1.Controls.Add(Me.txt_kode_transaksi)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_generate)
        Me.Panel1.Controls.Add(Me.dtp_tanggal)
        Me.Panel1.Controls.Add(Me.lbl_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_tanggal)
        Me.Panel1.Controls.Add(Me.btn_kosong_tanggal)
        Me.Panel1.Location = New System.Drawing.Point(3, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 55)
        Me.Panel1.TabIndex = 132
        '
        'txt_kode_transaksi
        '
        Me.txt_kode_transaksi.Location = New System.Drawing.Point(491, 16)
        Me.txt_kode_transaksi.MaxLength = 4
        Me.txt_kode_transaksi.Name = "txt_kode_transaksi"
        Me.txt_kode_transaksi.Size = New System.Drawing.Size(44, 22)
        Me.txt_kode_transaksi.TabIndex = 3
        Me.txt_kode_transaksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(380, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Kode Transaksi"
        '
        'btn_generate
        '
        Me.btn_generate.BackColor = System.Drawing.SystemColors.Window
        Me.btn_generate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_generate.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generate.Location = New System.Drawing.Point(637, 12)
        Me.btn_generate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_generate.Name = "btn_generate"
        Me.btn_generate.Size = New System.Drawing.Size(103, 30)
        Me.btn_generate.TabIndex = 1
        Me.btn_generate.Text = "GENERATE"
        Me.btn_generate.UseMnemonic = False
        Me.btn_generate.UseVisualStyleBackColor = False
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(294, 16)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(15, 23)
        Me.dtp_tanggal.TabIndex = 124
        Me.dtp_tanggal.TabStop = False
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(113, 19)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(43, 16)
        Me.lbl_tanggal_upload.TabIndex = 123
        Me.lbl_tanggal_upload.Text = "Bulan"
        '
        'txt_tanggal
        '
        Me.txt_tanggal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal.Location = New System.Drawing.Point(160, 16)
        Me.txt_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal.Name = "txt_tanggal"
        Me.txt_tanggal.ReadOnly = True
        Me.txt_tanggal.Size = New System.Drawing.Size(130, 23)
        Me.txt_tanggal.TabIndex = 100
        Me.txt_tanggal.TabStop = False
        '
        'btn_kosong_tanggal
        '
        Me.btn_kosong_tanggal.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal.Location = New System.Drawing.Point(312, 15)
        Me.btn_kosong_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal.Name = "btn_kosong_tanggal"
        Me.btn_kosong_tanggal.Size = New System.Drawing.Size(25, 24)
        Me.btn_kosong_tanggal.TabIndex = 126
        Me.btn_kosong_tanggal.TabStop = False
        Me.btn_kosong_tanggal.Text = "X"
        Me.btn_kosong_tanggal.UseMnemonic = False
        Me.btn_kosong_tanggal.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(3, 2)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(991, 28)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "EKSPOR EXCEL CORETAX"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(995, 430)
        Me.TabControl1.TabIndex = 133
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(987, 403)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Faktur"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.dgv1.Location = New System.Drawing.Point(7, 8)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(973, 387)
        Me.dgv1.TabIndex = 22
        Me.dgv1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgv2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(987, 403)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detail Faktur"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(7, 8)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(973, 387)
        Me.dgv2.TabIndex = 23
        Me.dgv2.TabStop = False
        '
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.SystemColors.Window
        Me.btn_reset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reset.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_reset.Location = New System.Drawing.Point(775, 12)
        Me.btn_reset.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(103, 30)
        Me.btn_reset.TabIndex = 2
        Me.btn_reset.Text = "RESET"
        Me.btn_reset.UseMnemonic = False
        Me.btn_reset.UseVisualStyleBackColor = False
        '
        'form_export_excel_coretax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 525)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_export_excel_coretax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents txt_tanggal As System.Windows.Forms.TextBox
    Friend WithEvents btn_kosong_tanggal As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txt_kode_transaksi As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_reset As System.Windows.Forms.Button
End Class
