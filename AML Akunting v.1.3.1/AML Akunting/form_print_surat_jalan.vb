Public Class form_print_surat_jalan

    Private Sub form_print_surat_jalan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        'Me.ReportViewer1.ZoomPercent = 30
    End Sub
End Class