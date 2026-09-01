<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_export_bukpot
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
        Me.panel_bukpot = New System.Windows.Forms.Panel()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.dtp_tahun_bukpot = New System.Windows.Forms.DateTimePicker()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.lbl_dgv1 = New System.Windows.Forms.Label()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.panel_bukpot.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_bukpot
        '
        Me.panel_bukpot.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel_bukpot.Controls.Add(Me.btn_simpan)
        Me.panel_bukpot.Controls.Add(Me.dtp_tahun_bukpot)
        Me.panel_bukpot.Controls.Add(Me.dgv1)
        Me.panel_bukpot.Controls.Add(Me.lbl_dgv1)
        Me.panel_bukpot.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bukpot.Location = New System.Drawing.Point(2, 32)
        Me.panel_bukpot.Name = "panel_bukpot"
        Me.panel_bukpot.Size = New System.Drawing.Size(917, 546)
        Me.panel_bukpot.TabIndex = 58
        '
        'btn_simpan
        '
        Me.btn_simpan.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_simpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_simpan.Location = New System.Drawing.Point(596, 10)
        Me.btn_simpan.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(97, 38)
        Me.btn_simpan.TabIndex = 51
        Me.btn_simpan.TabStop = False
        Me.btn_simpan.Text = "EKSPOR"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'dtp_tahun_bukpot
        '
        Me.dtp_tahun_bukpot.CalendarFont = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun_bukpot.CustomFormat = "yyyy"
        Me.dtp_tahun_bukpot.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tahun_bukpot.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tahun_bukpot.Location = New System.Drawing.Point(343, 16)
        Me.dtp_tahun_bukpot.Name = "dtp_tahun_bukpot"
        Me.dtp_tahun_bukpot.ShowUpDown = True
        Me.dtp_tahun_bukpot.Size = New System.Drawing.Size(71, 26)
        Me.dtp_tahun_bukpot.TabIndex = 50
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
        Me.dgv1.Location = New System.Drawing.Point(8, 56)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(901, 480)
        Me.dgv1.TabIndex = 47
        '
        'lbl_dgv1
        '
        Me.lbl_dgv1.AutoSize = True
        Me.lbl_dgv1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dgv1.Location = New System.Drawing.Point(224, 20)
        Me.lbl_dgv1.Name = "lbl_dgv1"
        Me.lbl_dgv1.Size = New System.Drawing.Size(109, 18)
        Me.lbl_dgv1.TabIndex = 26
        Me.lbl_dgv1.Text = "Tahun Bukpot"
        '
        'lbl_judul
        '
        Me.lbl_judul.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.lbl_judul.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.SystemColors.Window
        Me.lbl_judul.Location = New System.Drawing.Point(2, 3)
        Me.lbl_judul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(917, 26)
        Me.lbl_judul.TabIndex = 57
        Me.lbl_judul.Text = "EKSPOR BUKTI POTONG"
        Me.lbl_judul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'form_export_bukpot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 581)
        Me.Controls.Add(Me.panel_bukpot)
        Me.Controls.Add(Me.lbl_judul)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "form_export_bukpot"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel_bukpot.ResumeLayout(False)
        Me.panel_bukpot.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panel_bukpot As System.Windows.Forms.Panel
    Friend WithEvents dtp_tahun_bukpot As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_dgv1 As System.Windows.Forms.Label
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
End Class
