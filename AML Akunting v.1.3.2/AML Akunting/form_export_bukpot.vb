Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports System.IO
Imports OfficeOpenXml.Style

Public Class form_export_bukpot

    Private Sub form_export_bukpot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_data_bukpot()
    End Sub

    Private Sub tampil_data_bukpot()
        dgv1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim selectedYear As Integer = dtp_tahun_bukpot.Value.Year
            Dim sqlx As String = "SELECT id_jual, supplier, npwp, tanggal, no_faktur, dpp, ppn, pph23, pph23_actual, no_bukpot, tgl_bukpot, masa_bukpot, gabung_bukpot " &
                                 "FROM tbpenjualan " &
                                 "WHERE no_bukpot <> '' " &
                                 "AND jenis_biaya = 'Jasa' " &
                                 "AND no_faktur <> '' " &
                                 "AND YEAR(masa_bukpot) = " & selectedYear & " " &
                                 "ORDER BY tgl_bukpot ASC, no_bukpot ASC, supplier ASC, pph23_actual DESC"
            '"AND YEAR(tgl_bukpot) = " & selectedYear & " " &

            Using cmdx As New MySqlCommand(sqlx, conx)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbpenjualan")
                        dgv1.DataSource = dsx.Tables("tbpenjualan")
                    End Using
                End Using
            End Using
        End Using

        dgv1.Columns(1).HeaderText = "CUSTOMER"
        dgv1.Columns(2).HeaderText = "NPWP"
        dgv1.Columns(3).HeaderText = "TANGGAL"
        dgv1.Columns(4).HeaderText = "NO FAKTUR"
        dgv1.Columns(5).HeaderText = "DPP"
        dgv1.Columns(6).HeaderText = "PPN"
        dgv1.Columns(7).HeaderText = "PPH 23"
        dgv1.Columns(8).HeaderText = "PPH23 ACTUAL"
        dgv1.Columns(9).HeaderText = "NO BUKPOT"
        dgv1.Columns(10).HeaderText = "TGL BUKPOT"
        dgv1.Columns(11).HeaderText = "MASA BUKPOT"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(0).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(1).Width = 220
        dgv1.Columns(2).Width = 160
        dgv1.Columns(3).Width = 85
        dgv1.Columns(4).Width = 160
        dgv1.Columns(5).Width = 120
        dgv1.Columns(6).Width = 120
        dgv1.Columns(7).Width = 120
        dgv1.Columns(8).Width = 140
        dgv1.Columns(9).Width = 120
        dgv1.Columns(10).Width = 120
        dgv1.Columns(11).Width = 120
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "dd-MMM-yy"
        dgv1.Columns(11).DefaultCellStyle.Format = "MMMM-yy"

        For Each col As DataGridViewColumn In dgv1.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub dtp_tahun_bukpot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tahun_bukpot.ValueChanged
        Call tampil_data_bukpot()
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If dgv1.RowCount = 0 Then
            MsgBox("Tidak terdapat data untuk di ekspor")
        Else
            Dim txtdate, txttahun As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            txttahun.Text = dtp_tahun_bukpot.Value.ToString("yyyy")
            Ekspor(dgv1, "D:\Ekspor\Bukti Potong Tahun " & txttahun.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub

    Private Sub Ekspor(ByVal dgv1 As DataGridView, ByVal filePath As String)
        Try
            Dim txttahun As New TextBox
            txttahun.Text = dtp_tahun_bukpot.Value.ToString("yyyy")
            Using package As New ExcelPackage()
                ' Membuat worksheet dengan nama tahun
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add(txttahun.Text)

                ' Menambahkan judul
                ws.Cells(1, 1, 1, 12).Merge = True
                ws.Cells(1, 1).Value = "DAFTAR BUKTI POTONG TAHUN PAJAK " & txttahun.Text

                ' Menambahkan header
                ws.Cells(3, 1).Value = "NO"
                ws.Cells(3, 2).Value = "NAMA CUSTOMER PEMOTONG"
                ws.Cells(3, 3).Value = "NPWP CUSTOMER"
                ws.Cells(3, 4).Value = "TANGGAL FP"
                ws.Cells(3, 5).Value = "NO FAKTUR PAJAK"
                ws.Cells(3, 6).Value = "NILAI DPP"
                ws.Cells(3, 7).Value = "PPN"
                ws.Cells(3, 8).Value = "PPH23"
                ws.Cells(3, 9).Value = "PPH23 ACTUAL"
                ws.Cells(3, 10).Value = "NO BUKPOT"
                ws.Cells(3, 11).Value = "TGL BUKPOT"
                ws.Cells(3, 12).Value = "MASA BUKPOT"

                ' Set style header
                For col As Integer = 1 To 12
                    ws.Cells(3, col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws.Cells(3, col).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(3, col).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                    ws.Cells(3, col).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next

                ' Mengelompokkan data berdasarkan nilai gabung_bukpot
                Dim groupedData As New List(Of Dictionary(Of String, Object))
                Dim tempGroup As Dictionary(Of String, Object) = Nothing
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    Dim gabung_bukpot = dgv1.Rows(row).Cells("gabung_bukpot").Value.ToString()
                    If tempGroup IsNot Nothing AndAlso tempGroup("gabung_bukpot").ToString() = gabung_bukpot Then
                        ' Gabungkan nilai pph23_actual
                        tempGroup("pph23_actual") = CDbl(tempGroup("pph23_actual")) + CDbl(dgv1.Rows(row).Cells("pph23_actual").Value)
                        tempGroup("rows").Add(row)
                    Else
                        ' Tambahkan grup baru
                        If tempGroup IsNot Nothing Then groupedData.Add(tempGroup)
                        tempGroup = New Dictionary(Of String, Object) From {
                            {"gabung_bukpot", gabung_bukpot},
                            {"pph23_actual", dgv1.Rows(row).Cells("pph23_actual").Value},
                            {"rows", New List(Of Integer) From {row}}
                        }
                    End If
                Next
                If tempGroup IsNot Nothing Then groupedData.Add(tempGroup)

                ' Mengisi data ke Excel
                Dim rowIndex As Integer = 4
                For Each group In groupedData
                    Dim rows = group("rows")
                    Dim startRow = rowIndex
                    Dim endRow = rowIndex + rows.Count - 1

                    For Each rowIndexInGroup In rows
                        ' Menulis nomor urut
                        ws.Cells(rowIndex, 1).Value = rowIndex - 3
                        ws.Cells(rowIndex, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws.Cells(rowIndex, 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                        ' Menulis data ke kolom lain
                        Dim colIndexData As Integer = 1
                        For col As Integer = 0 To dgv1.Columns.Count - 1
                            If dgv1.Columns(col).Name <> "id_jual" AndAlso dgv1.Columns(col).Name <> "gabung_bukpot" Then
                                colIndexData += 1
                                Dim cell = ws.Cells(rowIndex, colIndexData)
                                Dim value = dgv1.Rows(rowIndexInGroup).Cells(col).Value

                                ' Format khusus untuk kolom tertentu
                                Select Case dgv1.Columns(col).Name
                                    Case "tanggal", "tgl_bukpot"
                                        ' Format tanggal menjadi 19-Jan-2024
                                        If value IsNot Nothing AndAlso IsDate(value) Then
                                            cell.Value = CDate(value)
                                            cell.Style.Numberformat.Format = "dd-MMM-yyyy"
                                        End If
                                    Case "masa_bukpot"
                                        ' Format masa_bukpot menjadi Januari-24
                                        If value IsNot Nothing AndAlso IsDate(value) Then
                                            cell.Value = CDate(value).ToString("MMMM-yy")
                                        End If
                                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                    Case "no_bukpot"
                                        ' Rata kanan untuk no_bukpot
                                        cell.Value = value.ToString()
                                        cell.Style.Numberformat.Format = "@"
                                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                    Case "pph23_actual"
                                        If rowIndex = startRow Then
                                            ' Tuliskan nilai hasil penjumlahan pada baris pertama
                                            cell.Value = CDbl(group("pph23_actual"))
                                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                            cell.Style.Numberformat.Format = "#,##0.00"
                                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                                            ' Merge cell pph23_actual
                                            ws.Cells(startRow, colIndexData, endRow, colIndexData).Merge = True
                                        End If
                                    Case Else
                                        ' Default untuk kolom lainnya
                                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                                            cell.Value = value
                                            cell.Style.Numberformat.Format = "#,##0.00"
                                        Else
                                            cell.Value = value.ToString()
                                        End If
                                End Select
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                            End If
                        Next
                        rowIndex += 1
                    Next
                Next

                ' Menyesuaikan lebar kolom
                ws.Cells(ws.Dimension.Address).AutoFitColumns()

                ' Menyimpan file Excel
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)

                MessageBox.Show("Ekspor Data ke Format Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseClick
        Call tampil_data_bukpot()
    End Sub
End Class