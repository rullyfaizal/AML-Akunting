<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_ambil_stok_grey
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
        Me.txt_baris = New System.Windows.Forms.TextBox()
        Me.dtp_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.btn_isi_dgv = New System.Windows.Forms.Button()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_id_grey3 = New System.Windows.Forms.TextBox()
        Me.txt_id_grey2 = New System.Windows.Forms.TextBox()
        Me.txt_id_grey1 = New System.Windows.Forms.TextBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_baris
        '
        Me.txt_baris.Location = New System.Drawing.Point(24, 470)
        Me.txt_baris.Name = "txt_baris"
        Me.txt_baris.Size = New System.Drawing.Size(100, 22)
        Me.txt_baris.TabIndex = 0
        Me.txt_baris.TabStop = False
        '
        'dtp_tanggal
        '
        Me.dtp_tanggal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tanggal.Location = New System.Drawing.Point(129, 470)
        Me.dtp_tanggal.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_tanggal.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtp_tanggal.Name = "dtp_tanggal"
        Me.dtp_tanggal.Size = New System.Drawing.Size(98, 22)
        Me.dtp_tanggal.TabIndex = 109
        Me.dtp_tanggal.TabStop = False
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv1.Location = New System.Drawing.Point(3, 31)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(1020, 265)
        Me.dgv1.TabIndex = 110
        Me.dgv1.TabStop = False
        '
        'btn_isi_dgv
        '
        Me.btn_isi_dgv.Location = New System.Drawing.Point(232, 469)
        Me.btn_isi_dgv.Name = "btn_isi_dgv"
        Me.btn_isi_dgv.Size = New System.Drawing.Size(75, 23)
        Me.btn_isi_dgv.TabIndex = 111
        Me.btn_isi_dgv.TabStop = False
        Me.btn_isi_dgv.Text = "ISI DGV"
        Me.btn_isi_dgv.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgv2.Location = New System.Drawing.Point(3, 320)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(1020, 180)
        Me.dgv2.TabIndex = 112
        Me.dgv2.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(-2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1030, 26)
        Me.Label1.TabIndex = 502
        Me.Label1.Text = "PILIH STOK GREY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 14)
        Me.Label2.TabIndex = 503
        Me.Label2.Text = "STOK Tanggal SJ Kain Lebih awal dari SJ Grey"
        '
        'txt_id_grey3
        '
        Me.txt_id_grey3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_grey3.Location = New System.Drawing.Point(312, 470)
        Me.txt_id_grey3.Name = "txt_id_grey3"
        Me.txt_id_grey3.Size = New System.Drawing.Size(43, 21)
        Me.txt_id_grey3.TabIndex = 520
        Me.txt_id_grey3.TabStop = False
        '
        'txt_id_grey2
        '
        Me.txt_id_grey2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_grey2.Location = New System.Drawing.Point(312, 447)
        Me.txt_id_grey2.Name = "txt_id_grey2"
        Me.txt_id_grey2.Size = New System.Drawing.Size(43, 21)
        Me.txt_id_grey2.TabIndex = 519
        Me.txt_id_grey2.TabStop = False
        '
        'txt_id_grey1
        '
        Me.txt_id_grey1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id_grey1.Location = New System.Drawing.Point(312, 424)
        Me.txt_id_grey1.Name = "txt_id_grey1"
        Me.txt_id_grey1.Size = New System.Drawing.Size(43, 21)
        Me.txt_id_grey1.TabIndex = 518
        Me.txt_id_grey1.TabStop = False
        '
        'form_ambil_stok_grey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 504)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.txt_id_grey3)
        Me.Controls.Add(Me.txt_id_grey2)
        Me.Controls.Add(Me.txt_id_grey1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_isi_dgv)
        Me.Controls.Add(Me.dtp_tanggal)
        Me.Controls.Add(Me.txt_baris)
        Me.Controls.Add(Me.dgv1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_ambil_stok_grey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_baris As System.Windows.Forms.TextBox
    Friend WithEvents dtp_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_isi_dgv As System.Windows.Forms.Button
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_id_grey3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_grey2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_grey1 As System.Windows.Forms.TextBox
End Class
