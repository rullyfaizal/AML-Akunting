<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_upload_penjualan_baru
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
        Me.btn_kosong_tanggal_upload = New System.Windows.Forms.Button()
        Me.txt_tanggal_upload = New System.Windows.Forms.TextBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_tanggal_upload = New System.Windows.Forms.Label()
        Me.txt_dpp_upload = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal_upload = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_kosong_tanggal_upload
        '
        Me.btn_kosong_tanggal_upload.BackColor = System.Drawing.SystemColors.Window
        Me.btn_kosong_tanggal_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_kosong_tanggal_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_kosong_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_kosong_tanggal_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_kosong_tanggal_upload.Location = New System.Drawing.Point(188, 28)
        Me.btn_kosong_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_kosong_tanggal_upload.Name = "btn_kosong_tanggal_upload"
        Me.btn_kosong_tanggal_upload.Size = New System.Drawing.Size(27, 22)
        Me.btn_kosong_tanggal_upload.TabIndex = 122
        Me.btn_kosong_tanggal_upload.TabStop = False
        Me.btn_kosong_tanggal_upload.Text = "X"
        Me.btn_kosong_tanggal_upload.UseMnemonic = False
        Me.btn_kosong_tanggal_upload.UseVisualStyleBackColor = False
        '
        'txt_tanggal_upload
        '
        Me.txt_tanggal_upload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tanggal_upload.Location = New System.Drawing.Point(37, 28)
        Me.txt_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_tanggal_upload.Name = "txt_tanggal_upload"
        Me.txt_tanggal_upload.ReadOnly = True
        Me.txt_tanggal_upload.Size = New System.Drawing.Size(130, 22)
        Me.txt_tanggal_upload.TabIndex = 118
        Me.txt_tanggal_upload.TabStop = False
        Me.txt_tanggal_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.dgv1.Location = New System.Drawing.Point(5, 97)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(565, 509)
        Me.dgv1.TabIndex = 235
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(358, 8)
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
        Me.Panel1.Controls.Add(Me.btn_kosong_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_tanggal_upload)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.lbl_tanggal_upload)
        Me.Panel1.Controls.Add(Me.txt_dpp_upload)
        Me.Panel1.Controls.Add(Me.dtp_tanggal_upload)
        Me.Panel1.Location = New System.Drawing.Point(5, 32)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(565, 60)
        Me.Panel1.TabIndex = 241
        '
        'lbl_tanggal_upload
        '
        Me.lbl_tanggal_upload.AutoSize = True
        Me.lbl_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tanggal_upload.Location = New System.Drawing.Point(81, 9)
        Me.lbl_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_tanggal_upload.Name = "lbl_tanggal_upload"
        Me.lbl_tanggal_upload.Size = New System.Drawing.Size(42, 14)
        Me.lbl_tanggal_upload.TabIndex = 113
        Me.lbl_tanggal_upload.Text = "Bulan"
        '
        'txt_dpp_upload
        '
        Me.txt_dpp_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dpp_upload.Location = New System.Drawing.Point(300, 28)
        Me.txt_dpp_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_dpp_upload.Name = "txt_dpp_upload"
        Me.txt_dpp_upload.ReadOnly = True
        Me.txt_dpp_upload.Size = New System.Drawing.Size(226, 22)
        Me.txt_dpp_upload.TabIndex = 223
        Me.txt_dpp_upload.TabStop = False
        Me.txt_dpp_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp_tanggal_upload
        '
        Me.dtp_tanggal_upload.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal_upload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal_upload.Location = New System.Drawing.Point(170, 28)
        Me.dtp_tanggal_upload.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal_upload.Name = "dtp_tanggal_upload"
        Me.dtp_tanggal_upload.Size = New System.Drawing.Size(15, 22)
        Me.dtp_tanggal_upload.TabIndex = 114
        Me.dtp_tanggal_upload.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(-3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(580, 26)
        Me.Label1.TabIndex = 236
        Me.Label1.Text = "UPLOAD PENJUALAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_upload_penjualan_baru
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 611)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "form_upload_penjualan_baru"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_kosong_tanggal_upload As System.Windows.Forms.Button
    Friend WithEvents txt_tanggal_upload As System.Windows.Forms.TextBox
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_tanggal_upload As System.Windows.Forms.Label
    Friend WithEvents txt_dpp_upload As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal_upload As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
