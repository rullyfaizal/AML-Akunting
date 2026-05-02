<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_ambil_omset_penjualan
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_isi_dgv = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.txt_baris = New System.Windows.Forms.TextBox()
        Me.btn_hapus_cari = New System.Windows.Forms.Button()
        Me.txt_tanggal_cari = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_cari = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(-2, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1030, 26)
        Me.Label1.TabIndex = 509
        Me.Label1.Text = "PILIH OMSET PENJUALAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_isi_dgv
        '
        Me.btn_isi_dgv.Location = New System.Drawing.Point(232, 470)
        Me.btn_isi_dgv.Name = "btn_isi_dgv"
        Me.btn_isi_dgv.Size = New System.Drawing.Size(75, 23)
        Me.btn_isi_dgv.TabIndex = 507
        Me.btn_isi_dgv.TabStop = False
        Me.btn_isi_dgv.Text = "ISI DGV"
        Me.btn_isi_dgv.UseVisualStyleBackColor = True
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
        Me.dgv1.Location = New System.Drawing.Point(3, 82)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1020, 419)
        Me.dgv1.TabIndex = 506
        Me.dgv1.TabStop = False
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(129, 471)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(98, 22)
        Me.dtp_tanggal.TabIndex = 505
        Me.dtp_tanggal.TabStop = False
        '
        'txt_baris
        '
        Me.txt_baris.Location = New System.Drawing.Point(24, 471)
        Me.txt_baris.Name = "txt_baris"
        Me.txt_baris.Size = New System.Drawing.Size(100, 22)
        Me.txt_baris.TabIndex = 504
        Me.txt_baris.TabStop = False
        '
        'btn_hapus_cari
        '
        Me.btn_hapus_cari.BackColor = System.Drawing.SystemColors.Window
        Me.btn_hapus_cari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_hapus_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hapus_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hapus_cari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_hapus_cari.Location = New System.Drawing.Point(230, 11)
        Me.btn_hapus_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_hapus_cari.Name = "btn_hapus_cari"
        Me.btn_hapus_cari.Size = New System.Drawing.Size(27, 22)
        Me.btn_hapus_cari.TabIndex = 512
        Me.btn_hapus_cari.TabStop = False
        Me.btn_hapus_cari.Text = "X"
        Me.btn_hapus_cari.UseMnemonic = False
        Me.btn_hapus_cari.UseVisualStyleBackColor = False
        '
        'txt_tanggal_cari
        '
        Me.txt_tanggal_cari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_cari.Location = New System.Drawing.Point(79, 11)
        Me.txt_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_cari.Name = "txt_tanggal_cari"
        Me.txt_tanggal_cari.ReadOnly = True
        Me.txt_tanggal_cari.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_cari.TabIndex = 511
        Me.txt_tanggal_cari.TabStop = False
        Me.txt_tanggal_cari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtp_tanggal_cari
        '
        Me.dtp_tanggal_cari.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_cari.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_cari.Location = New System.Drawing.Point(212, 11)
        Me.dtp_tanggal_cari.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_cari.Name = "dtp_tanggal_cari"
        Me.dtp_tanggal_cari.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_cari.TabIndex = 510
        Me.dtp_tanggal_cari.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 513
        Me.Label3.Text = "Bulan"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txt_tanggal_cari)
        Me.Panel3.Controls.Add(Me.dtp_tanggal_cari)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btn_hapus_cari)
        Me.Panel3.Location = New System.Drawing.Point(3, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1020, 46)
        Me.Panel3.TabIndex = 514
        '
        'form_ambil_omset_penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 504)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_isi_dgv)
        Me.Controls.Add(Me.dtp_tanggal)
        Me.Controls.Add(Me.txt_baris)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_ambil_omset_penjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_isi_dgv As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_baris As System.Windows.Forms.TextBox
    Friend WithEvents btn_hapus_cari As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal_cari As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_cari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
