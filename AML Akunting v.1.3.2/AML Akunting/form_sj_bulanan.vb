Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO

Public Class form_sj_bulanan
    Dim FormatID As New CultureInfo("id-ID")
    'Fungsi potong nama client
    Private Function AmbilDuaKata(ByVal txt As TextBox) As String
        Dim kata() As String = txt.Text.Trim().Split(" "c)
        If kata.Length >= 2 Then
            Return kata(0) & " " & kata(1)
        ElseIf kata.Length = 1 Then
            Return kata(0)
        Else
            Return ""
        End If
    End Function
    'Fungsi potong alamat client
    Private Function AmbilDelapanKata(ByVal txt As TextBox) As String
        Dim kata() As String = txt.Text.Trim().Split(" "c)
        Dim hasil As String = ""
        Dim jumlahKata As Integer = Math.Min(8, kata.Length)
        For i As Integer = 0 To jumlahKata - 1
            hasil &= kata(i) & " "
        Next
        Return hasil.Trim()
    End Function
    ' Fungsi untuk mendapatkan nilai Decimal dari sel DGV
    Private Function GetDecimalValue(ByVal cellValue As Object, Optional ByVal defaultValue As Decimal = 0) As Decimal
        Dim result As Decimal
        If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
            Return result
        End If
        Return defaultValue
    End Function
    ' Fungsi untuk mendapatkan nilai String dari sel DGV
    Private Function GetStringValue(ByVal cellValue As Object, Optional ByVal defaultValue As String = "") As String
        If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
            Return cellValue.ToString().Trim()
        End If
        Return defaultValue
    End Function

    Private Sub btn_batal_print_sj_bulanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_print_sj_bulanan.Click
        Me.Close()
    End Sub
    Private Sub dtp_tanggal_print_sj_bulanan_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal_print_sj_bulanan.ValueChanged
        dgv_list_sj.Columns.Clear()
        Dim namaBulan As String = dtp_tanggal_print_sj_bulanan.Value.ToString("MMMM", New Globalization.CultureInfo("id-ID")).ToUpper()
        Dim namaTahun As String = dtp_tanggal_print_sj_bulanan.Value.ToString("yyyy")
        Dim selectedDate As DateTime = dtp_tanggal_print_sj_bulanan.Value
        txt_bulan.Text = selectedDate.ToString("MMMM yyyy", FormatID)
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT DISTINCT surat_jalan, supplier, tanggal, status FROM tbpenjualan " &
                                 "WHERE MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun " &
                                 "ORDER BY surat_jalan ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@bulan", dtp_tanggal_print_sj_bulanan.Value.Month)
                cmdx.Parameters.AddWithValue("@tahun", dtp_tanggal_print_sj_bulanan.Value.Year)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "surat_jalan")
                        dgv_list_sj.DataSource = dsx.Tables("surat_jalan")
                        dgv_list_sj.RowHeadersWidth = 60
                        dgv_list_sj.Columns(0).Width = 170
                        dgv_list_sj.Columns(0).HeaderText = "SURAT JALAN"
                        dgv_list_sj.Columns(1).Width = 250
                        dgv_list_sj.Columns(1).HeaderText = "CLIENT"
                        dgv_list_sj.Columns(2).Width = 100
                        dgv_list_sj.Columns(2).HeaderText = "TANGGAL"
                        dgv_list_sj.Columns(3).Visible = False
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub btn_print_sj_bulanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_sj_bulanan.Click
        If dgv_list_sj.RowCount = 0 Then
            MsgBox("Tidak Terdapat data untuk Print Surat Jalan")
        Else
            For a = 0 To dgv_list_sj.RowCount - 1
                txt_no_sj_print_bulanan.Text = dgv_list_sj.Rows(a).Cells("surat_jalan").Value.ToString()
                txt_client_bulanan.Text = dgv_list_sj.Rows(a).Cells("supplier").Value.ToString()
                Dim selectedDate As DateTime = dgv_list_sj.Rows(a).Cells("tanggal").Value
                txt_tanggal_print_sj_bulanan.Text = selectedDate.ToString("dd MMMM yyyy", FormatID)

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx As String = "SELECT alamat, kota FROM tbclient WHERE nama = @nama"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        cmdx.Parameters.AddWithValue("@nama", txt_client_bulanan.Text)
                        Using reader As MySqlDataReader = cmdx.ExecuteReader()
                            If reader.Read() Then
                                txt_alamat_client_bulanan.Text = reader("alamat").ToString()
                                txt_kota_client_bulanan.Text = reader("kota").ToString()
                                txt_alamat_client_bulanan.Text = AmbilDelapanKata(txt_alamat_client_bulanan)
                            End If
                        End Using
                    End Using
                End Using

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx As String = ""
                    If dgv_list_sj.Rows(a).Cells("status").Value = "Celup" Then
                        sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Obat'"
                    Else
                        sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Kain'"
                    End If
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        cmdx.Parameters.AddWithValue("@surat_jalan", txt_no_sj_print_bulanan.Text)
                        Using dax As New MySqlDataAdapter
                            dax.SelectCommand = cmdx
                            Using dsx As New DataSet
                                dax.Fill(dsx, "tbpenjualan")
                                dgv_print_sj_bulanan.DataSource = dsx.Tables("tbpenjualan")
                                dgv_print_sj_bulanan.Columns(1).DefaultCellStyle.Format = "#,##0.00"
                            End Using
                        End Using
                    End Using
                End Using

                Dim tbsuratjalan As New DataTable
                With tbsuratjalan
                    .Columns.Add("client")
                    .Columns.Add("alamat_client")
                    .Columns.Add("kota_client")
                    .Columns.Add("no_surat_jalan")
                    .Columns.Add("tanggal")
                    .Columns.Add("ket_bawah")
                End With
                tbsuratjalan.Rows.Add(txt_client_bulanan.Text, txt_alamat_client_bulanan.Text, txt_kota_client_bulanan.Text, _
                                      txt_no_sj_print_bulanan.Text, txt_tanggal_print_sj_bulanan.Text, txt_ket_sj_bulanan.Text)

                Dim tbdata As New DataTable
                ' Tambahkan kolom ke DataTable
                With tbdata
                    .Columns.Add("no")
                    .Columns.Add("nama_barang")
                    .Columns.Add("kuantitas")
                    .Columns.Add("satuan")
                    .Columns.Add("keterangan")
                End With
                Dim nourut As Integer = 1
                For Each row As DataGridViewRow In dgv_print_sj_bulanan.Rows
                    If Not row.IsNewRow Then
                        tbdata.Rows.Add(nourut, "Kain " & row.Cells("nama_kain").Value, Format(row.Cells("jumlah").Value, "#,##0.00"), row.Cells("satuan").Value, "")
                        nourut += 1
                    End If
                Next

                form_print_surat_jalan.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbsuratjalan
                form_print_surat_jalan.ReportViewer1.LocalReport.DataSources.Item(1).Value = tbdata
                form_print_surat_jalan.ShowDialog()
                form_print_surat_jalan.Dispose()
            Next
        End If
    End Sub

    Private Sub dgv_list_sj_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_list_sj.CellFormatting
        dgv_list_sj.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub btn_ekspor_sj_bulanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ekspor_sj_bulanan.Click
        Try
            If dgv_list_sj.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Ekspor Surat Jalan")
            Else
                Dim txtdate As New TextBox
                Dim dtptoday As New DateTimePicker
                dtptoday.Value = DateTime.Now
                Dim namaclient As String = AmbilDuaKata(txt_client_bulanan)
                txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
                Dim selectedDate As DateTime = dtp_tanggal_print_sj_bulanan.Value
                EksporMultiSJ(dgv_print_sj_bulanan, "D:\Ekspor\Surat Jalan Bulan " & selectedDate.ToString("MMMM yyyy", FormatID) & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Ekspor Surat Jalan")
        End Try
    End Sub
    Private Sub EksporMultiSJ(ByVal dgv_print_sj_bulanan As DataGridView, ByVal filePath As String)
        Dim fi As New FileInfo(filePath)
        Using package As New ExcelPackage()
            For a = 0 To dgv_list_sj.RowCount - 1
                txt_no_sj_print_bulanan.Text = dgv_list_sj.Rows(a).Cells("surat_jalan").Value.ToString()
                txt_client_bulanan.Text = dgv_list_sj.Rows(a).Cells("supplier").Value.ToString()
                Dim selectedDate As DateTime = dgv_list_sj.Rows(a).Cells("tanggal").Value
                txt_tanggal_print_sj_bulanan.Text = selectedDate.ToString("dd MMMM yyyy", FormatID)

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx As String = "SELECT alamat, kota FROM tbclient WHERE nama = @nama"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        cmdx.Parameters.AddWithValue("@nama", txt_client_bulanan.Text)
                        Using reader As MySqlDataReader = cmdx.ExecuteReader()
                            If reader.Read() Then
                                txt_alamat_client_bulanan.Text = reader("alamat").ToString()
                                txt_kota_client_bulanan.Text = reader("kota").ToString()
                                txt_alamat_client_bulanan.Text = AmbilDelapanKata(txt_alamat_client_bulanan)
                            End If
                        End Using
                    End Using
                End Using

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx As String = ""
                    If dgv_list_sj.Rows(a).Cells("status").Value = "Celup" Then
                        sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Obat'"
                    Else
                        sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Kain'"
                    End If
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        cmdx.Parameters.AddWithValue("@surat_jalan", txt_no_sj_print_bulanan.Text)
                        Using dax As New MySqlDataAdapter
                            dax.SelectCommand = cmdx
                            Using dsx As New DataSet
                                dax.Fill(dsx, "tbpenjualan")
                                dgv_print_sj_bulanan.DataSource = dsx.Tables("tbpenjualan")
                                dgv_print_sj_bulanan.Columns(1).DefaultCellStyle.Format = "#,##0.00"
                            End Using
                        End Using
                    End Using
                End Using

                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add(txt_no_sj_print_bulanan.Text)
                ' === Set judul laporan ===
                ws.Cells.Style.Font.Name = "Arial"
                Dim values As String() = {
                    "CV. Artha Mekar Lestari",
                    "Jl. Halimun No. 5",
                    "Malabar, Kota Bandung"}
                For i As Integer = 0 To values.Length - 1
                    With ws.Cells(i + 1, 1)
                        .Value = values(i)
                        .Style.Font.Size = 9
                    End With
                Next
                For i As Integer = 1 To 3
                    ws.Row(i).Height = 12 ' 16 pixel ≈ 12 point
                Next
                With ws.Cells(4, 1)
                    .Value = "SURAT JALAN"
                    .Style.Font.Size = 24
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With
                ws.Cells(4, 1, 4, 9).Merge = True
                ws.Row(4).Height = 30

                Dim columnWidths As Double() = {4.71, 13.84, 1.43, 18.41, 13.42, 9.42, 1.43, 13.42, 13.13}
                For i As Integer = 0 To columnWidths.Length - 1
                    ws.Column(i + 1).Width = columnWidths(i)
                Next
                For i As Integer = 5 To 21
                    ws.Row(i).Height = 12
                    ws.Row(i).Style.Font.Size = 9
                Next
                ws.Cells(6, 1).Value = "Kepada"
                ws.Cells(6, 3).Value = ":"
                ws.Cells(6, 4).Value = txt_client_bulanan.Text
                ws.Cells(7, 4).Value = txt_alamat_client_bulanan.Text
                ws.Cells(8, 4).Value = txt_kota_client_bulanan.Text
                ws.Cells(6, 4, 6, 9).Merge = True
                ws.Cells(7, 4, 7, 9).Merge = True
                ws.Cells(8, 4, 8, 9).Merge = True
                ws.Cells(10, 1, 10, 9).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                ws.Cells(10, 1).Value = "No. Surat Jalan"
                ws.Cells(10, 3).Value = ":"
                ws.Cells(10, 4).Value = txt_no_sj_print_bulanan.Text
                ws.Cells(10, 6).Value = "Tanggal"
                ws.Cells(10, 7).Value = ":"
                ws.Cells(10, 8).Value = txt_tanggal_print_sj_bulanan.Text

                For i As Integer = 12 To 18
                    For j As Integer = 1 To 9
                        ws.Cells(i, j).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                    ws.Cells(i, 2, i, 4).Merge = True
                    ws.Cells(i, 6, i, 7).Merge = True
                    ws.Cells(i, 8, i, 9).Merge = True
                Next
                ws.Cells(12, 1).Value = "No."
                ws.Cells(12, 2).Value = "Nama Barang"
                ws.Cells(12, 5).Value = "Kuantitas"
                ws.Cells(12, 6).Value = "Satuan"
                ws.Cells(12, 8).Value = "Keterangan"
                ws.Cells(10, 4, 10, 5).Merge = True
                ws.Cells(10, 8, 10, 9).Merge = True

                For row As Integer = 0 To dgv_print_sj_bulanan.Rows.Count - 1
                    ' Pastikan baris bukan baris baru
                    If Not dgv_print_sj_bulanan.Rows(row).IsNewRow Then
                        Dim cellNo = ws.Cells(row + 13, 1) ' Kolom 1 di Excel untuk nomor urut
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

                        ' Menggunakan nama kolom DGV
                        Dim cellNamaKain = "Kain " & dgv_print_sj_bulanan.Rows(row).Cells("nama_kain").Value
                        Dim cellJumlah = dgv_print_sj_bulanan.Rows(row).Cells("jumlah").Value
                        Dim cellSatuan = dgv_print_sj_bulanan.Rows(row).Cells("satuan").Value

                        ' Pastikan data tidak kosong
                        If cellNamaKain IsNot Nothing Then
                            ws.Cells(row + 13, 2).Value = cellNamaKain.ToString().Trim()
                        End If

                        If cellJumlah IsNot Nothing AndAlso Not IsDBNull(cellJumlah) Then
                            Dim jumlah As Decimal
                            If Decimal.TryParse(cellJumlah.ToString(), jumlah) Then
                                ws.Cells(row + 13, 5).Value = jumlah
                                ws.Cells(row + 13, 5).Style.Numberformat.Format = "#,##0.00"
                                ws.Cells(row + 13, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                            Else
                                ws.Cells(row + 13, 5).Value = 0 ' Jika parsing gagal
                            End If
                        End If

                        If cellSatuan IsNot Nothing Then
                            ws.Cells(row + 13, 6).Value = cellSatuan.ToString().Trim()
                        End If

                    End If
                Next
                ws.Cells(20, 2).Value = "Keterangan"
                ws.Cells(20, 3).Value = ":"
                'ws.Cells(20, 4).Value = txt_ket_sj.Text
                ws.Cells(20, 4, 20, 9).Merge = True
                ws.Cells(22, 2).Value = "Yang Menerima"
                ws.Cells(27, 2).Value = "(                     )"
                ws.Cells(22, 8).Value = "Hormat Kami"
                ws.Cells(27, 8).Value = "(                     )"

            Next
            package.SaveAs(fi)
            MessageBox.Show("Ekspor Surat Jalan ke Excel Berhasil (multi-sheet)")
        End Using
    End Sub

   
End Class