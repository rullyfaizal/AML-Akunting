Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports System.IO
Imports OfficeOpenXml.Style

Public Class form_export_excel_coretax

    Dim bulan, tahun As Integer
    Dim npwparta As String = My.Settings.npwpartha

    Private Sub form_export_excel_coretax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_kode_transaksi.Text = "04"
    End Sub
    Private Sub txt_tanggal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal.TextChanged
        btn_generate.Text = "GENERATE"
        dgv1.Columns.Clear()
        dgv2.Columns.Clear()
    End Sub
    Private Sub dtp_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal.Text = formattedDate
        bulan = Month(dtp_tanggal.Value)
        tahun = Year(dtp_tanggal.Value)
    End Sub
    Private Sub btn_kosong_tanggal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal.Click
        If Not txt_tanggal.Text = "" Then
            txt_tanggal.Text = ""
        End If
    End Sub

    Private Sub setup_dgv1()
        dgv1.ColumnCount = 17
        dgv1.Columns(0).Name = "Baris"
        dgv1.Columns(1).Name = "Tanggal Faktur"
        dgv1.Columns(2).Name = "Jenis Faktur"
        dgv1.Columns(3).Name = "Kode Transaksi"
        dgv1.Columns(4).Name = "Keterangan Tambahan"
        dgv1.Columns(5).Name = "Dokumen Pendukung"
        dgv1.Columns(6).Name = "Referensi"
        dgv1.Columns(7).Name = "Cap Fasilitas"
        dgv1.Columns(8).Name = "ID TKU Penjual"
        dgv1.Columns(9).Name = "NPWP/NIK Pembeli"
        dgv1.Columns(10).Name = "Jenis ID Pembeli"
        dgv1.Columns(11).Name = "Negara Pembeli"
        dgv1.Columns(12).Name = "Nomor Dokumen Pembeli"
        dgv1.Columns(13).Name = "Nama Pembeli"
        dgv1.Columns(14).Name = "Alamat Pembeli"
        dgv1.Columns(15).Name = "Email Pembeli"
        dgv1.Columns(16).Name = "ID TKU Pembeli"

        dgv1.Columns(0).Width = 50
        dgv1.Columns(1).Width = 90
        dgv1.Columns(2).Width = 70
        dgv1.Columns(3).Width = 70
        dgv1.Columns(4).Width = 50
        dgv1.Columns(5).Width = 50
        dgv1.Columns(6).Width = 50
        dgv1.Columns(7).Width = 50
        dgv1.Columns(8).Width = 200
        dgv1.Columns(9).Width = 150
        dgv1.Columns(10).Width = 70
        dgv1.Columns(11).Width = 70
        dgv1.Columns(12).Width = 70
        dgv1.Columns(13).Width = 150
        dgv1.Columns(14).Width = 200
        dgv1.Columns(15).Width = 70
        dgv1.Columns(16).Width = 200
    End Sub
    Private Sub setup_dgv2()
        dgv2.ColumnCount = 14
        dgv2.Columns(0).Name = "Baris"
        dgv2.Columns(1).Name = "Barang/Jasa"
        dgv2.Columns(2).Name = "Kode Barang Jasa"
        dgv2.Columns(3).Name = "Nama Barang/Jasa"
        dgv2.Columns(4).Name = "Nama Satuan Ukur"
        dgv2.Columns(5).Name = "Harga Satuan"
        dgv2.Columns(6).Name = "Jumlah Barang Jasa"
        dgv2.Columns(7).Name = "Total Diskon"
        dgv2.Columns(8).Name = "DPP"
        dgv2.Columns(9).Name = "DPP Nilai Lain"
        dgv2.Columns(10).Name = "Tarif PPN"
        dgv2.Columns(11).Name = "PPN"
        dgv2.Columns(12).Name = "Tarif PPnBM"
        dgv2.Columns(13).Name = "PPnBM"

        dgv2.Columns(0).Width = 50
        dgv2.Columns(1).Width = 90
        dgv2.Columns(2).Width = 70
        dgv2.Columns(3).Width = 200
        dgv2.Columns(4).Width = 90
        dgv2.Columns(5).Width = 100
        dgv2.Columns(6).Width = 100
        dgv2.Columns(7).Width = 70
        dgv2.Columns(8).Width = 120
        dgv2.Columns(9).Width = 120
        dgv2.Columns(10).Width = 70
        dgv2.Columns(11).Width = 120
        dgv2.Columns(12).Width = 70
        dgv2.Columns(13).Width = 70

        dgv2.Columns(5).DefaultCellStyle.Format = "0.00"
        dgv2.Columns(6).DefaultCellStyle.Format = "0.##"
        dgv2.Columns(7).DefaultCellStyle.Format = "0.00"
        dgv2.Columns(8).DefaultCellStyle.Format = "0.00"
        dgv2.Columns(9).DefaultCellStyle.Format = "0.00"
        dgv2.Columns(11).DefaultCellStyle.Format = "0.00"
        dgv2.Columns(13).DefaultCellStyle.Format = "0.00"

        For i = 5 To 13
            dgv2.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

    End Sub
    Private Sub load_dgv1()
        dgv1.Columns.Clear()
        Call setup_dgv1()

        Dim tahun As Integer = dtp_tanggal.Value.Year
        Dim bulan As Integer = dtp_tanggal.Value.Month

        Dim query1 As String = "SELECT tanggal, supplier FROM tbpenjualan WHERE YEAR(tanggal) = @tahun AND MONTH(tanggal) = @bulan " &
            "ORDER BY tanggal ASC, supplier ASC, FIELD(jenis_biaya, 'Obat', 'Jasa', 'Kain'), nama_kain ASC;"

        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query1, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                cmd.Parameters.AddWithValue("@bulan", bulan)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim nomorUrut As Integer = 1 ' Inisialisasi nomor urut
                    Dim kodeTransaksi As String = txt_kode_transaksi.Text
                    While reader.Read()
                        Dim tanggalFaktur As Date = reader.GetDateTime("tanggal")
                        Dim pembeli As String = reader.GetString("supplier")
                        Dim alamat As String = ""
                        Dim npwppembeli As String = ""
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim queryy As String = "SELECT alamat, npwp FROM tbclient WHERE nama = @pembeli;"
                            Using cmdy As New MySqlCommand(queryy, cony)
                                cmdy.Parameters.AddWithValue("@pembeli", pembeli)
                                Using readery As MySqlDataReader = cmdy.ExecuteReader()
                                    If readery.Read() Then ' Pastikan ada data sebelum membaca
                                        alamat = readery("alamat").ToString() ' Hindari NullReferenceException
                                        npwppembeli = readery("npwp").ToString()
                                    End If
                                End Using
                            End Using
                        End Using
                        dgv1.Rows.Add(nomorUrut, tanggalFaktur.ToString("dd/MM/yyyy"), "Normal", kodeTransaksi, "", "", "", "" _
                                      , npwparta & "000000", npwppembeli, "TIN", "IDN", "-", pembeli, alamat, "", npwppembeli & "000000") ' Isi kolom "Baris" dengan nomor urut
                        nomorUrut += 1 ' Tambah nomor urut
                    End While
                End Using
            End Using
        End Using

    End Sub
    Private Sub load_dgv2()
        dgv2.Columns.Clear()
        Call setup_dgv2()

        Dim tahun As Integer = dtp_tanggal.Value.Year
        Dim bulan As Integer = dtp_tanggal.Value.Month

        Dim query1 As String = "SELECT jenis_biaya, nama_kain, satuan, harga, jumlah, dpp FROM tbpenjualan WHERE YEAR(tanggal) = @tahun AND MONTH(tanggal) = @bulan " &
            "ORDER BY tanggal ASC, supplier ASC, FIELD(jenis_biaya, 'Obat', 'Jasa', 'Kain'), nama_kain ASC;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query1, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                cmd.Parameters.AddWithValue("@bulan", bulan)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    Dim nomorUrut As Integer = 1 ' Inisialisasi nomor urut
                    Dim barangJasa As String = ""
                    Dim kodeBarangJasa As String = ""
                    Dim namaBarangJasa As String = ""
                    Dim satuan As String = ""
                    Dim harga As Decimal = 0
                    Dim jumlah As Decimal = 0
                    Dim diskon As Decimal = 0
                    Dim dpp As Decimal = 0
                    Dim dpplain As Decimal = 0
                    Dim jumlahPPN As Decimal = 0
                    While reader.Read()
                        If reader.GetString("jenis_biaya") = "Kain" Then
                            barangJasa = "A"
                            kodeBarangJasa = "000000"
                            namaBarangJasa = reader.GetString("nama_kain")
                            If reader.GetString("satuan") = "Yard" Then
                                satuan = "UM.0016"
                            ElseIf reader.GetString("satuan") = "Meter" Then
                                satuan = "UM.0013"
                            End If
                        ElseIf reader.GetString("jenis_biaya") = "Obat" Then
                            barangJasa = "A"
                            kodeBarangJasa = "000000"
                            namaBarangJasa = "Penggantian Obat Makloon"
                            satuan = "UM.0003"
                        ElseIf reader.GetString("jenis_biaya") = "Jasa" Then
                            barangJasa = "B"
                            kodeBarangJasa = "290105"
                            namaBarangJasa = "Jasa Makloon"
                            satuan = "UM.0033"
                        End If
                        'harga = Math.Round(reader.GetDecimal("harga"), 2, MidpointRounding.AwayFromZero)
                        harga = reader.GetDecimal("harga")
                        'jumlah = Math.Round(reader.GetDecimal("jumlah"), 2, MidpointRounding.AwayFromZero)
                        'dpp = Math.Round(reader.GetDecimal("dpp"), 2, MidpointRounding.AwayFromZero)
                        'dpplain = Math.Round(11 / 12 * dpp, 2, MidpointRounding.AwayFromZero)
                        'jumlahPPN = Math.Round(dpplain * 12 / 100, 2, MidpointRounding.AwayFromZero)
                        jumlah = reader.GetDecimal("jumlah")
                        dpp = reader.GetDecimal("dpp")
                        dpplain = 11 / 12 * dpp
                        jumlahPPN = dpplain * 12 / 100

                        dgv2.Rows.Add(nomorUrut, barangJasa, kodeBarangJasa, namaBarangJasa, satuan, harga, jumlah, diskon, dpp, dpplain, 12, jumlahPPN, 0, 0) ' Isi kolom "Baris" dengan nomor urut
                        nomorUrut += 1 ' Tambah nomor urut
                    End While
                End Using
            End Using
        End Using

    End Sub

    Private Sub Export(ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws1 As ExcelWorksheet = package.Workbook.Worksheets.Add("Faktur")
                ws1.Cells(1, 1).Value = "NPWP Penjual"
                ws1.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws1.Cells(1, 1).Style.Font.Bold = True
                ws1.Cells(1, 1, 1, 2).Merge = True
                ws1.Cells(1, 3).Value = npwparta
                For col As Integer = 1 To dgv1.Columns.Count
                    ws1.Cells(3, col).Value = dgv1.Columns(col - 1).HeaderText
                    ws1.Cells(3, col).Style.Font.Bold = True
                Next
                Dim akhirrow As Integer = 0
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    For col As Integer = 0 To dgv1.Columns.Count - 1
                        ws1.Cells(row + 4, col + 1).Value = dgv1.Rows(row).Cells(col).Value
                    Next
                    akhirrow = row
                Next
                ws1.Cells(akhirrow + 5, 1).Value = "END"
                ws1.Column(1).Width = 7
                ws1.Column(2).Width = 15
                ws1.Column(3).Width = 15
                ws1.Column(4).Width = 15
                ws1.Column(5).Width = 2
                ws1.Column(6).Width = 2
                ws1.Column(7).Width = 2
                ws1.Column(8).Width = 2
                ws1.Column(9).Width = 25
                ws1.Column(10).Width = 20
                ws1.Column(11).Width = 17
                ws1.Column(12).Width = 17
                ws1.Column(14).Width = 20
                ws1.Column(15).Width = 25
                ws1.Column(17).Width = 25

                Dim ws2 As ExcelWorksheet = package.Workbook.Worksheets.Add("DetailFaktur")
                Dim akhirrow2 As Integer = 0
                For row As Integer = 0 To dgv2.Rows.Count - 1
                    For col As Integer = 0 To dgv2.Columns.Count - 1
                        'If col = 5 Or col = 7 Or col = 13 Then
                        '    ws2.Cells(row + 2, col + 1).Style.Numberformat.Format = "0.00"
                        '    ws2.Cells(row + 2, col + 1).Value = dgv2.Rows(row).Cells(col).Value
                        'ElseIf col = 8 Then
                        '    ws2.Cells(row + 2, col + 1).Formula = "=G" & (row + 2) & "*F" & (row + 2) & "-H" & (row + 2)
                        '    ws2.Cells(row + 2, col + 1).Style.Numberformat.Format = "0.00"
                        'ElseIf col = 9 Then
                        '    ws2.Cells(row + 2, col + 1).Formula = "=11/12*I" & (row + 2)
                        '    ws2.Cells(row + 2, col + 1).Style.Numberformat.Format = "0.00"
                        'ElseIf col = 11 Then
                        '    ws2.Cells(row + 2, col + 1).Formula = "=J" & (row + 2) & "*K" & (row + 2) & "/100"
                        '    ws2.Cells(row + 2, col + 1).Style.Numberformat.Format = "0.00"
                        'Else
                        '    ws2.Cells(row + 2, col + 1).Value = dgv2.Rows(row).Cells(col).Value
                        'End If
                        Dim cell = ws2.Cells(row + 2, col + 1)
                        Dim value = dgv2.Rows(row).Cells(col).Value
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Or col = 2 Or col = 10 Or col = 12 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If col = 6 Then
                                        If numericValue < 0 Then
                                            cell.Value = numericValue
                                            cell.Style.Numberformat.Format = "0;(0)"
                                        Else
                                            cell.Value = numericValue
                                            cell.Style.Numberformat.Format = "0"
                                        End If
                                    Else
                                        If numericValue < 0 Then
                                            cell.Value = numericValue
                                            cell.Style.Numberformat.Format = "0.00;(0.00)"
                                        Else
                                            cell.Value = numericValue
                                            cell.Style.Numberformat.Format = "0.00"
                                        End If
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                    Next
                    akhirrow2 = row
                Next
                ws2.Cells(akhirrow2 + 3, 1).Value = "END"
                ws2.Column(1).Width = 7
                ws2.Column(2).Width = 12
                ws2.Column(3).Width = 12
                ws2.Column(4).Width = 27
                ws2.Column(5).Width = 17
                ws2.Column(6).Width = 13
                ws2.Column(7).Width = 19
                ws2.Column(8).Width = 12
                ws2.Column(9).Width = 15
                ws2.Column(10).Width = 15
                ws2.Column(11).Width = 9
                ws2.Column(12).Width = 15
                ws2.Column(13).Width = 12
                ws2.Column(14).Width = 8
                ws2.Cells(1, 1).Value = "Baris"
                ws2.Cells(1, 2).Value = "Barang/Jasa"
                ws2.Cells(1, 3).Value = "Kode Barang Jasa"
                ws2.Cells(1, 4).Value = "Nama Barang/Jasa"
                ws2.Cells(1, 5).Value = "Nama Satuan Ukur"
                ws2.Cells(1, 6).Value = "Harga Satuan"
                ws2.Cells(1, 7).Value = "Jumlah Barang Jasa"
                ws2.Cells(1, 8).Value = "Total Diskon"
                ws2.Cells(1, 9).Value = "DPP"
                ws2.Cells(1, 10).Value = "DPP Nilai Lain"
                ws2.Cells(1, 11).Value = "Tarif PPN"
                ws2.Cells(1, 12).Value = "PPN"
                ws2.Cells(1, 13).Value = "Tarif PPnBM"
                ws2.Cells(1, 14).Value = "PPnBM"

                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Data ke Excel Berhasil!")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        Try
            If txt_tanggal.Text = "" Then
                MsgBox("Silahkan pilih Bulan terlebih dahulu")
            ElseIf txt_kode_transaksi.Text = "" Then
                MsgBox("Silahkan isi terlebih dahulu kode Transaksi")
                txt_kode_transaksi.Focus()
            Else
                If btn_generate.Text = "GENERATE" Then
                    btn_generate.Text = "EKSPOR"
                    Call load_dgv1()
                    Call load_dgv2()
                Else
                    If dgv1.RowCount = 0 Then
                        MsgBox("Tidak terdapat Data untuk di Ekspor, Silahkan pilih bulan Lain")
                    Else
                        Dim txtdate, txttahun As New TextBox
                        Dim dtptoday As New DateTimePicker
                        dtptoday.Value = DateTime.Now
                        txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
                        txttahun.Text = dtp_tanggal.Value.ToString("MMM yyyy")
                        Export("D:\Ekspor\Ekspor Excel Coretax Bulan " & txttahun.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        Me.Close() ' Menutup form saat ini
        Dim newForm As New form_export_excel_coretax() ' Membuat instance baru dari form
        newForm.Show() '
    End Sub
End Class