Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports System.IO
Imports OfficeOpenXml.Style

Public Class form_export_penjualan
    Dim bulan, tahun As Integer

    Private Sub txt_tanggal_upload_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal_upload.TextChanged
        btn_simpan.Text = "CARI"
        dgv1.Columns.Clear()
    End Sub

    Private Sub dtp_tanggal_upload_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_tanggal_upload.TextChanged
        Dim selectedDate As DateTime = dtp_tanggal_upload.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_upload.Text = formattedDate
        bulan = Month(dtp_tanggal_upload.Value)
        tahun = Year(dtp_tanggal_upload.Value)
        txtbulan.Text = bulan
        txttahun.Text = tahun
    End Sub

    Private Sub isidgvindukpembelian()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT supplier, dpp, ppn, total FROM tbpenjualan WHERE YEAR(tanggal) = '" & txttahun.Text & "' AND MONTH(tanggal) = '" & txtbulan.Text & "' AND upload <> '' ORDER BY supplier ASC"
                'Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE YEAR(tanggal) = '" & txttahun.Text & "' AND MONTH(tanggal) = '" & txtbulan.Text & "' AND no_faktur <> '' ORDER BY tanggal ASC"
                ' Dim sqlx As String = "SELECT supplier, SUM(dpp), SUM(ppn), SUM(total) FROM tbpenjualan " &
                '"WHERE YEAR(tanggal) = '" & txttahun.Text & "' AND MONTH(tanggal) = '" & txtbulan.Text & "' AND no_faktur <> '' " &
                '"GROUP BY supplier, no_faktur ORDER BY no_faktur ASC;"
                Dim sqlx As String = "SELECT supplier, SUM(dpp), SUM(ppn), SUM(total) FROM tbpenjualan " &
               "WHERE YEAR(tanggal) = '" & txttahun.Text & "' AND MONTH(tanggal) = '" & txtbulan.Text & "' AND no_faktur <> '' " &
               "GROUP BY supplier, no_faktur ORDER BY tanggal ASC, supplier ASC, FIELD(jenis_biaya, 'Obat', 'Jasa', 'Kain'), nama_kain ASC;"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                            Call atur_dgv_induk2()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub atur_dgv_induk2()
        dgv1.Columns(0).HeaderText = "Client"
        dgv1.Columns(1).HeaderText = "DPP"
        dgv1.Columns(2).HeaderText = "PPN"
        dgv1.Columns(3).HeaderText = "Total"
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(0).Width = 250
        dgv1.Columns(1).Width = 120
        dgv1.Columns(2).Width = 120
        dgv1.Columns(3).Width = 125
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv1.Columns(2).DefaultCellStyle.Format = "#,##0"
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0"
    End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If btn_simpan.Text = "CARI" Then
            If txt_tanggal_upload.Text = "" Then
                MsgBox("Silahkan pilih terlebih dahulu bulan UPLOAD")
            Else
                Call isidgvindukpembelian()
                btn_simpan.Text = "EKSPOR"
            End If
        Else
            If dgv1.Rows.Count = 0 Then
                MessageBox.Show("DATA yang anda cari tidak ada silahkan cari di Bulan lain.", "Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                btn_simpan.Text = "CARI"
                Dim txtdate As New TextBox
                Dim dtptoday As New DateTimePicker
                dtptoday.Value = DateTime.Now
                txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
                ExportDataGridViewToExcelEPPlus(dgv1, "D:\Ekspor\Upload Penjualan Bulan " & txt_tanggal_upload.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
            End If
        End If
    End Sub

    Public Sub ExportDataGridViewToExcelEPPlus(ByVal dgv1 As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add(txt_tanggal_upload.Text)
                ws.Cells(1, 1, 1, dgv1.Columns.Count + 1).Merge = True
                ws.Cells(1, 1).Value = "FAKTUR PENJUALAN"
                ws.Cells(2, 1, 2, dgv1.Columns.Count + 1).Merge = True
                ws.Cells(2, 1).Value = "MASA " & txt_tanggal_upload.Text & ""
                ws.Cells(3, 1).Value = "No"
                ws.Cells(3, 1).Style.Font.Bold = True
                ws.Cells(3, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(3, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(3, 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                ws.Cells(3, 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 1 To dgv1.Columns.Count
                    Dim cell = ws.Cells(3, col + 1)
                    cell.Value = dgv1.Columns(col - 1).HeaderText
                    cell.Style.Font.Bold = True
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next

                For row As Integer = 0 To dgv1.Rows.Count - 1
                    Dim cellNo = ws.Cells(row + 4, 1)
                    cellNo.Value = row + 1
                    cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    For col As Integer = 0 To dgv1.Columns.Count - 1
                        Dim cell = ws.Cells(row + 4, col + 2)

                        Dim value = dgv1(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            cell.Value = value
                            cell.Style.Numberformat.Format = "#,##0"
                        Else
                            cell.Value = value.ToString()
                        End If
                        'If TypeOf value Is DateTime Then
                        '    Dim dt As DateTime = DirectCast(value, DateTime)
                        '    cell.Value = dt
                        '    cell.Style.Numberformat.Format = "[$-id-ID]mmmm yyyy" ' Format bulan dan tahun dalam bahasa Indonesia
                        'ElseIf TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    cell.Value = value
                        '    cell.Style.Numberformat.Format = "0.00######" ' Format untuk angka desimal
                        'Else
                        '    cell.Value = value.ToString()
                        'End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next
                ws.Cells(ws.Dimension.Address).AutoFitColumns()
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Data ke Format Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btn_kosong_tanggal_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal_upload.Click
        If Not txt_tanggal_upload.Text = "" Then
            txt_tanggal_upload.Text = ""
        End If
    End Sub
End Class