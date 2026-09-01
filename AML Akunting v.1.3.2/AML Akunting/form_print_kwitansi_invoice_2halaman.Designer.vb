<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_print_kwitansi_invoice_2halaman
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSet1 = New AML_Akunting.DataSet1()
        Me.KwitansiInvoiceHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KwitansiInvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KwitansiInvoice2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KwitansiInvoiceHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KwitansiInvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KwitansiInvoice2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.KwitansiInvoiceHeaderBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.KwitansiInvoiceBindingSource
        ReportDataSource3.Name = "DataSet3"
        ReportDataSource3.Value = Me.KwitansiInvoice2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AML_Akunting.rpt_kwitansi_invoice_2hal.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(815, 693)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KwitansiInvoiceHeaderBindingSource
        '
        Me.KwitansiInvoiceHeaderBindingSource.DataMember = "KwitansiInvoiceHeader"
        Me.KwitansiInvoiceHeaderBindingSource.DataSource = Me.DataSet1
        '
        'KwitansiInvoiceBindingSource
        '
        Me.KwitansiInvoiceBindingSource.DataMember = "KwitansiInvoice"
        Me.KwitansiInvoiceBindingSource.DataSource = Me.DataSet1
        '
        'KwitansiInvoice2BindingSource
        '
        Me.KwitansiInvoice2BindingSource.DataMember = "KwitansiInvoice2"
        Me.KwitansiInvoice2BindingSource.DataSource = Me.DataSet1
        '
        'form_print_kwitansi_invoice_2halaman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 693)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "form_print_kwitansi_invoice_2halaman"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRINT KWITANSI INVOICE"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KwitansiInvoiceHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KwitansiInvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KwitansiInvoice2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents KwitansiInvoiceHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As AML_Akunting.DataSet1
    Friend WithEvents KwitansiInvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KwitansiInvoice2BindingSource As System.Windows.Forms.BindingSource
End Class
