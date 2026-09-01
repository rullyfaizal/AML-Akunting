<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_export_penjualan
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.txtbulan = New System.Windows.Forms.TextBox()
        Me.txttahun = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_upload = New System.Windows.Forms.DateTimePicker()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_kosong_tanggal_upload = New System.Windows.Forms.Button()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label6.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(6, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(700, 28)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "EKSPOR UPLOAD PENJUALAN"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_simpan
        '
        Me.btn_simpan.BackColor = System.Drawing.SystemColors.Window
        Me.btn_simpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(438, 12)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(100, 30)
        Me.btn_simpan.TabIndex = 129
        Me.btn_simpan.TabStop = False
        Me.btn_simpan.Text = "CARI"
        Me.btn_simpan.UseMnemonic = False
        Me.btn_simpan.UseVisualStyleBackColor = False
        '
        'txtbulan
        '
        Me.txtbulan.Location = New System.Drawing.Point(620, 4)
        Me.txtbulan.Name = "txtbulan"
        Me.txtbulan.Size = New System.Drawing.Size(77, 20)
        Me.txtbulan.TabIndex = 128
        Me.txtbulan.Visible = False
        '
        'txttahun
        '
        Me.txttahun.Location = New System.Drawing.Point(620, 24)
        Me.txttahun.Name = "txttahun"
        Me.txttahun.Size = New System.Drawing.Size(77, 20)
        Me.txttahun.TabIndex = 127
        Me.txttahun.Visible = False
        '
        'dtp_tanggal_upload
        '
        Me.dtp_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_upload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_upload.Location = New System.Drawing.Point(339, 16)
        Me.dtp_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_upload.Name = "dtp_tanggal_upload"
        Me.dtp_tanggal_upload.Size = New System.Drawing.Size(15, 23)
        Me.dtp_tanggal_upload.TabIndex = 124
        Me.dtp_tanggal_upload.TabStop = False
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(109, 19)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(92, 16)
        Me.lbl_tanggal_upload.TabIndex = 123
        Me.lbl_tanggal_upload.Text = "Bulan Upload"
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
        Me.dgv1.Location = New System.Drawing.Point(6, 97)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(700, 520)
        Me.dgv1.TabIndex = 131
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(205, 16)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 23)
        Me.txt_tanggal_upload.TabIndex = 125
        Me.txt_tanggal_upload.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.btn_simpan)
        Me.Panel1.Controls.Add(Me.txtbulan)
        Me.Panel1.Controls.Add(Me.txttahun)
        Me.Panel1.Controls.Add(Me.dtp_tanggal_upload)
        Me.Panel1.Controls.Add(Me.lbl_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_tanggal_upload)
        Me.Panel1.Controls.Add(Me.btn_kosong_tanggal_upload)
        Me.Panel1.Location = New System.Drawing.Point(6, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(700, 55)
        Me.Panel1.TabIndex = 133
        '
        'btn_kosong_tanggal_upload
        '
        Me.btn_kosong_tanggal_upload.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal_upload.Location = New System.Drawing.Point(357, 15)
        Me.btn_kosong_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal_upload.Name = "btn_kosong_tanggal_upload"
        Me.btn_kosong_tanggal_upload.Size = New System.Drawing.Size(25, 24)
        Me.btn_kosong_tanggal_upload.TabIndex = 126
        Me.btn_kosong_tanggal_upload.TabStop = False
        Me.btn_kosong_tanggal_upload.Text = "X"
        Me.btn_kosong_tanggal_upload.UseMnemonic = False
        Me.btn_kosong_tanggal_upload.UseVisualStyleBackColor = False
        '
        'form_export_penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 624)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form_export_penjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents txtbulan As System.Windows.Forms.TextBox
    Friend WithEvents txttahun As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_upload As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_kosong_tanggal_upload As System.Windows.Forms.Button
End Class
