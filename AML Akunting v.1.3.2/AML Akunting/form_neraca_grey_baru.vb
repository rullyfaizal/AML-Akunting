Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_neraca_grey_baru

    Private Sub form_neraca_grey_baru_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim selectedDate As DateTime = dtp_tanggal.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal.Text = formattedDate
        Dim bulanDipilih As Integer = dtp_tanggal.Value.Month
        Dim tahunDipilih As Integer = dtp_tanggal.Value.Year
        Dim tanggalTerakhirBulanSebelumnya As DateTime = New DateTime(tahunDipilih, bulanDipilih, 1).AddDays(-1)
        dtp_awal.Value = tanggalTerakhirBulanSebelumnya
        dtp_akhir.Value = dtp_awal.Value.AddYears(-3)
        dtp_akhir.Value = dtp_akhir.Value.AddDays(+1)
        btn_cari.PerformClick()
    End Sub

    Private Sub stokawalbulan()
        dtp_awal.CustomFormat = "yyyy/MM/dd"
        dtp_akhir.CustomFormat = "yyyy/MM/dd"
        dgv1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                 "SUM(stok_masuk) - SUM(stok_keluar) AS stok_awal, " &
                 "harga, harga_jual " &
                 "FROM tbhistorygrey " &
                 "WHERE tanggal BETWEEN @dtp_akhir AND @dtp_awal " &
                 "GROUP BY nama_specs;"
            '"GROUP BY nama_specs, harga_jual_ppn;"
           Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp_awal", dtp_awal.Value)
                cmdx.Parameters.AddWithValue("@dtp_akhir", dtp_akhir.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv1.DataSource = dsx.Tables("tbhistorygrey")
                        'Call tambahkolom()
                        'Call hitungjumlah()
                        'Call atur_dgv_induk()
                    End Using
                End Using
            End Using
        End Using
        dtp_awal.CustomFormat = "dd/MM/yyyy"
        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub stok()
        dtp_awal.CustomFormat = "yyyy/MM/dd"
        dtp_akhir.CustomFormat = "yyyy/MM/dd"
        dgv2.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                "harga, harga_jual " &
                "FROM tbhistorygrey " &
                "WHERE MONTH(tanggal) = MONTH(@dtp) AND YEAR(tanggal) = YEAR(@dtp) " &
                "GROUP BY nama_specs;"
            '"GROUP BY nama_specs, harga_jual_ppn;"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp", dtp_tanggal.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv2.DataSource = dsx.Tables("tbhistorygrey")
                        'Call tambahkolom()
                        'Call hitungjumlah()
                        'Call atur_dgv_induk()
                    End Using
                End Using
            End Using
        End Using
        dtp_awal.CustomFormat = "dd/MM/yyyy"
        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub dtp_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal.ValueChanged
        ' Mengatur dtp2 agar memiliki bulan dan tahun yang sama dengan dtp1, tetapi tanggalnya menjadi 1
        Dim bulanDipilih As Integer = dtp_tanggal.Value.Month
        Dim tahunDipilih As Integer = dtp_tanggal.Value.Year

        Dim tanggalTerakhirBulanSebelumnya As DateTime = New DateTime(tahunDipilih, bulanDipilih, 1).AddDays(-1)

        ' Mengatur dtp2 ke tanggal terakhir bulan sebelumnya
        dtp_awal.Value = tanggalTerakhirBulanSebelumnya

        Dim selectedDate As DateTime = dtp_tanggal.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal.Text = formattedDate
    End Sub

    Private Sub dtp_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_awal.ValueChanged
        dtp_akhir.Value = dtp_awal.Value.AddYears(-3)
        dtp_akhir.Value = dtp_akhir.Value.AddDays(+1)
    End Sub

    Private Sub GabungkanData()
        ' Membersihkan dgv3 dan menambahkan kolom-kolom yang diperlukan
        dgv3.Columns.Clear()
        dgv3.Rows.Clear()

        ' Menambahkan kolom-kolom ke dgv3
        dgv3.Columns.Add("nama_specs", "Nama Specs")
        dgv3.Columns.Add("harga_jual_ppn", "Harga Jual PPN")
        dgv3.Columns.Add("stok_awal", "Stok Awal")
        dgv3.Columns.Add("total_stok_masuk", "Total Stok Masuk")
        dgv3.Columns.Add("total_stok_keluar", "Total Stok Keluar")
        dgv3.Columns.Add("stok_akhir", "Stok Akhir")
        dgv3.Columns.Add("harga", "Harga")
        dgv3.Columns.Add("harga_jual", "Harga Jual")
        dgv3.Columns.Add("dpp_beli_akhir", "DPP Beli Akhir")
        dgv3.Columns.Add("dpp_jual_akhir", "DPP Jual Akhir")

        ' Mengatur tipe data untuk kolom desimal
        dgv3.Columns("harga_jual_ppn").ValueType = GetType(Decimal)
        dgv3.Columns("stok_awal").ValueType = GetType(Decimal)
        dgv3.Columns("total_stok_masuk").ValueType = GetType(Decimal)
        dgv3.Columns("total_stok_keluar").ValueType = GetType(Decimal)
        dgv3.Columns("stok_akhir").ValueType = GetType(Decimal)
        dgv3.Columns("harga").ValueType = GetType(Decimal)
        dgv3.Columns("harga_jual").ValueType = GetType(Decimal)
        dgv3.Columns("dpp_beli_akhir").ValueType = GetType(Decimal)
        dgv3.Columns("dpp_jual_akhir").ValueType = GetType(Decimal)

        ' Membuat dictionary untuk menyimpan data sementara
        Dim combinedData As New Dictionary(Of String, DataGridViewRow)

        ' Mengisi data dari dgv1 (stok bulan sebelumnya)
        For Each row As DataGridViewRow In dgv1.Rows
            If Not row.IsNewRow Then
                Dim namaSpecs As String = row.Cells("nama_specs").Value.ToString()
                Dim hargaJualPPN As Decimal = Convert.ToDecimal(row.Cells("harga_jual_ppn").Value)
                Dim stokAwal As Decimal = Convert.ToDecimal(row.Cells("stok_awal").Value)
                Dim harga As Decimal = Convert.ToDecimal(row.Cells("harga").Value)
                Dim hargaJual As Decimal = Convert.ToDecimal(row.Cells("harga_jual").Value)

                ' Key berdasarkan kombinasi nama_specs dan harga_jual_ppn
                'Dim key As String = namaSpecs & "|" & hargaJualPPN.ToString()
                Dim key As String = namaSpecs.ToString()

                ' Menambahkan data ke dictionary dengan stok_awal dari dgv1
                If Not combinedData.ContainsKey(key) Then
                    ' Tambahkan baris baru ke dgv3 dengan stok_awal, total_stok_masuk, dan total_stok_keluar sementara 0
                    Dim index As Integer = dgv3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, 0D, 0D, stokAwal, harga, hargaJual, 0D, 0D)
                    combinedData(key) = dgv3.Rows(index)
                End If
            End If
        Next

        ' Mengisi data dari dgv2 (stok bulan berjalan)
        For Each row As DataGridViewRow In dgv2.Rows
            If Not row.IsNewRow Then
                Dim namaSpecs As String = row.Cells("nama_specs").Value.ToString()
                Dim hargaJualPPN As Decimal = Convert.ToDecimal(row.Cells("harga_jual_ppn").Value)
                Dim totalStokMasuk As Decimal = Convert.ToDecimal(row.Cells("total_stok_masuk").Value)
                Dim totalStokKeluar As Decimal = Convert.ToDecimal(row.Cells("total_stok_keluar").Value)
                Dim harga As Decimal = Convert.ToDecimal(row.Cells("harga").Value)
                Dim hargaJual As Decimal = Convert.ToDecimal(row.Cells("harga_jual").Value)

                ' Key berdasarkan kombinasi nama_specs dan harga_jual_ppn
                Dim key As String = namaSpecs.ToString()

                If combinedData.ContainsKey(key) Then
                    ' Update data di dgv3 untuk kolom total_stok_masuk dan total_stok_keluar dari dgv2 saja
                    Dim dgvRow As DataGridViewRow = combinedData(key)
                    dgvRow.Cells("total_stok_masuk").Value = totalStokMasuk
                    dgvRow.Cells("total_stok_keluar").Value = totalStokKeluar

                    ' Update harga dan harga_jual dari dgv2
                    dgvRow.Cells("harga").Value = harga
                    dgvRow.Cells("harga_jual").Value = hargaJual

                    ' Hitung stok_akhir berdasarkan stok_awal di dgv3 dan total_stok_masuk/total_stok_keluar dari dgv2
                    Dim stokAwal As Decimal = Convert.ToDecimal(dgvRow.Cells("stok_awal").Value)
                    Dim stokAkhir As Decimal = stokAwal + totalStokMasuk - totalStokKeluar
                    dgvRow.Cells("stok_akhir").Value = stokAkhir

                    ' Hitung dpp_beli_akhir dan dpp_jual_akhir
                    dgvRow.Cells("dpp_beli_akhir").Value = stokAkhir * harga
                    dgvRow.Cells("dpp_jual_akhir").Value = stokAkhir * hargaJual
                Else
                    ' Jika tidak ada di dgv1, tambahkan stok_awal = 0 dan data total_stok_masuk serta total_stok_keluar dari dgv2
                    Dim stokAwal As Decimal = 0D
                    Dim stokAkhir As Decimal = stokAwal + totalStokMasuk - totalStokKeluar
                    Dim dppBeliAkhir As Decimal = stokAkhir * harga
                    Dim dppJualAkhir As Decimal = stokAkhir * hargaJual

                    Dim index As Integer = dgv3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, totalStokMasuk, totalStokKeluar, stokAkhir, harga, hargaJual, dppBeliAkhir, dppJualAkhir)
                    combinedData(key) = dgv3.Rows(index)
                End If
            End If
        Next

        ' Mengisi stok_akhir untuk data yang hanya ada di dgv1 (jika tidak ada data di dgv2)
        For Each kvp As KeyValuePair(Of String, DataGridViewRow) In combinedData
            Dim dgvRow As DataGridViewRow = kvp.Value
            If Convert.ToDecimal(dgvRow.Cells("total_stok_masuk").Value) = 0D AndAlso Convert.ToDecimal(dgvRow.Cells("total_stok_keluar").Value) = 0D Then
                ' Jika total_stok_masuk dan total_stok_keluar masih 0, hitung stok_akhir berdasarkan stok_awal saja
                Dim stokAwal As Decimal = Convert.ToDecimal(dgvRow.Cells("stok_awal").Value)
                dgvRow.Cells("stok_akhir").Value = stokAwal

                ' Hitung dpp_beli_akhir dan dpp_jual_akhir
                Dim harga As Decimal = Convert.ToDecimal(dgvRow.Cells("harga").Value)
                Dim hargaJual As Decimal = Convert.ToDecimal(dgvRow.Cells("harga_jual").Value)
                dgvRow.Cells("dpp_beli_akhir").Value = stokAwal * harga
                dgvRow.Cells("dpp_jual_akhir").Value = stokAwal * hargaJual
            End If
        Next

        '' Menghapus baris dengan stok_akhir = 0
        'For i As Integer = dgv3.Rows.Count - 1 To 0 Step -1
        '    If Not dgv3.Rows(i).IsNewRow Then
        '        Dim stokAwal As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(2).Value)
        '        Dim stokMasuk As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(3).Value)
        '        Dim stokKeluar As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(4).Value)
        '        Dim stokAkhir As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(5).Value)
        '        If stokAwal <= 0D And stokMasuk <= 0D And stokKeluar <= 0D And stokAkhir <= 0D Then
        '            dgv3.Rows.RemoveAt(i)
        '        End If
        '    End If
        'Next

        ' Menghapus baris dengan stok_akhir < 5
        For i As Integer = dgv3.Rows.Count - 1 To 0 Step -1
            If Not dgv3.Rows(i).IsNewRow Then
                Dim stokAwal As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(2).Value)
                Dim stokMasuk As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(3).Value)
                Dim stokKeluar As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(4).Value)
                Dim stokAkhir As Decimal = Convert.ToDecimal(dgv3.Rows(i).Cells(5).Value)
                If stokAwal <= 5D And stokMasuk <= 0D And stokKeluar <= 0D And stokAkhir <= 5D Then
                    dgv3.Rows.RemoveAt(i)
                End If
            End If
        Next
    End Sub

    Private Sub atur_dgv3()
        dgv3.Columns(0).HeaderText = "Nama Grey"
        dgv3.Columns(1).HeaderText = "Harga Jual PPN (Rp)"
        dgv3.Columns(2).HeaderText = "Stok Awal"
        dgv3.Columns(3).HeaderText = "Stok Masuk"
        dgv3.Columns(4).HeaderText = "Stok Keluar"
        dgv3.Columns(5).HeaderText = "Stok Akhir"
        dgv3.Columns(6).HeaderText = "Harga Beli (Rp)"
        dgv3.Columns(7).HeaderText = "Harga Jual (Rp)"
        dgv3.Columns(8).HeaderText = "DPP Beli Akhir (Rp)"
        dgv3.Columns(9).HeaderText = "DPP Jual Akhir (Rp)"
        For Each column As DataGridViewColumn In dgv3.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv3.RowHeadersWidth = 60
        dgv3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(0).Width = 150
        dgv3.Columns(1).Width = 100
        dgv3.Columns(2).Width = 100
        dgv3.Columns(3).Width = 100
        dgv3.Columns(4).Width = 100
        dgv3.Columns(5).Width = 100
        dgv3.Columns(6).Width = 100
        dgv3.Columns(7).Width = 100
        dgv3.Columns(8).Width = 150
        dgv3.Columns(9).Width = 150
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Call stokawalbulan()
        Call stok()
        Call GabungkanData()
        Call atur_dgv3()
        Call hitungjumlah()
        Label6.Text = "NERACA GREY Bulan " & txt_tanggal.Text
    End Sub
    Private Sub hitungjumlah()
        Dim awal, masuk, keluar, akhir, dpp, beli As Decimal
        awal = 0
        masuk = 0
        keluar = 0
        akhir = 0
        dpp = 0
        beli = 0
        For i As Integer = 0 To dgv3.Rows.Count - 1
            awal = awal + Decimal.Round((dgv3.Rows(i).Cells(2).Value), 10)
            masuk = masuk + Decimal.Round((dgv3.Rows(i).Cells(3).Value), 10)
            keluar = keluar + Decimal.Round((dgv3.Rows(i).Cells(4).Value), 10)
            akhir = akhir + Decimal.Round((dgv3.Rows(i).Cells(5).Value), 10)
            dpp = dpp + Decimal.Round((dgv3.Rows(i).Cells(9).Value), 10)
            beli = beli + Decimal.Round((dgv3.Rows(i).Cells(8).Value), 10)
        Next
        txt_awal.Text = awal.ToString("#,##0.00")
        txt_masuk.Text = masuk.ToString("#,##0.00")
        txt_keluar.Text = keluar.ToString("#,##0.00")
        txt_akhir.Text = akhir.ToString("#,##0.00")
        txt_dpp_tersedia.Text = dpp.ToString("#,##0.00")
        txt_total_dpp_beli.Text = beli.ToString("#,##0.00")
    End Sub
    Private Sub dgv3_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv3.CellFormatting
        dgv3.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        ' Periksa apakah sel memiliki nilai numerik
        If IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)
            ' Jika nilai negatif, ubah tampilannya menjadi tanda kurung
            If nilai < 0 Then
                e.Value = "0,00"
                e.FormattingApplied = True ' Tandai format sudah diterapkan
            End If
        End If
        If e.ColumnIndex = 2 Then
            ' Periksa apakah nilai kurang dari atau sama dengan 5
            If IsNumeric(e.Value) AndAlso Convert.ToDecimal(e.Value) <= 5 Then
                e.Value = "0,00"
                e.FormattingApplied = True ' Tandai format sudah diterapkan
            End If
        End If
    End Sub

End Class