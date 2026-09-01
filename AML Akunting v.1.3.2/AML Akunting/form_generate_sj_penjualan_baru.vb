Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_generate_sj_penjualan_baru
    Private Sub cari_max_surat_jalan()
        Dim tahunDipilih As Integer = dtp_tanggal_cari.Value.Year
        Dim bulanDipilih As Integer = dtp_tanggal_cari.Value.Month
        Dim query As String = "SELECT MAX(CAST(SUBSTRING(surat_jalan, 5, 5) AS UNSIGNED)) AS xxxxx_terakhir FROM tbpenjualan WHERE YEAR(tanggal) = @tahun"

        Using conn As New MySqlConnection(sLocalConn)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@tahun", tahunDipilih)
                conn.Open()
                Dim result As Object = cmd.ExecuteScalar()
                Dim xxxxxTerakhir As Integer = If(IsDBNull(result), 0, Convert.ToInt32(result)) + 1

                ' Mengonversi bulan ke angka Romawi
                Dim bulanRomawi As String = GetBulanRomawi(bulanDipilih)

                ' Menyusun nomor surat jalan
                'txt_surat_jalan.Text = "AML-{xxxxxTerakhir:D5}/{bulanRomawi}/{tahunDipilih}"
                txt_surat_jalan.Text = String.Format("AML-{0:D5}/{1}/{2}", xxxxxTerakhir, bulanRomawi, tahunDipilih)

            End Using
        End Using
    End Sub

    ' Fungsi untuk mengonversi bulan ke angka Romawi
    Private Function GetBulanRomawi(ByVal bulan As Integer) As String
        Select Case bulan
            Case 1 : Return "I"
            Case 2 : Return "II"
            Case 3 : Return "III"
            Case 4 : Return "IV"
            Case 5 : Return "V"
            Case 6 : Return "VI"
            Case 7 : Return "VII"
            Case 8 : Return "VIII"
            Case 9 : Return "IX"
            Case 10 : Return "X"
            Case 11 : Return "XI"
            Case 12 : Return "XII"
            Case Else : Throw New ArgumentOutOfRangeException("Bulan tidak valid.")
        End Select
    End Function

    Private Sub dtp_tanggal_cari_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal_cari.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal_cari.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_cari.Text = formattedDate
    End Sub
    Private Sub btn_hapus_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus_cari.Click
        If Not txt_tanggal_cari.Text = "" Then
            txt_tanggal_cari.Text = ""
            dgv1_clone.Rows.Clear()
            txt_no_faktur.Text = ""
            txt_no_faktur_akhir.Text = ""
            txt_surat_jalan.Text = ""
            txt_surat_jalan_akhir.Text = ""
            txt_jumlah_faktur.Text = ""
            btn_simpan.Enabled = False
            btnNaik.Enabled = False
            btnTurun.Enabled = False
        End If
    End Sub
    Private Sub txt_tanggal_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal_cari.TextChanged
        Call isidgvpenjualan()
        cari_max_surat_jalan()
        dgv_kol45.Rows.Clear()
        btn_simpan.Enabled = False
        btnNaik.Enabled = False
        btnTurun.Enabled = False
    End Sub
    Private Sub isidgvpenjualan()
        Try
            Dim currentMonth As Integer = Month(dtp_tanggal_cari.Value)
            Dim currentYear As Integer = Year(dtp_tanggal_cari.Value)
            dtp_tanggal_cari.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan WHERE MONTH(tanggal) = '" & currentMonth & "' AND Year(tanggal) = '" & currentYear & "' AND surat_jalan = '' AND no_faktur = '' GROUP BY kode ORDER BY tanggal ASC"
                'Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode,gabung_faktur FROM tbpenjualan WHERE MONTH(tanggal) = '" & currentMonth & "' AND Year(tanggal) = '" & currentYear & "' AND surat_jalan = '' AND no_faktur = '' ORDER BY tanggal ASC"
                Dim sqlx As String = "SELECT id_jual, supplier, tanggal, surat_jalan, no_faktur, jenis_biaya, nama_kain, jumlah, harga, dpp, ppn, total, pph23, transfer, total_polos, satuan, status, baris, kode, gabung_faktur " &
                     "FROM tbpenjualan " &
                     "WHERE MONTH(tanggal) = '" & currentMonth & "' AND YEAR(tanggal) = '" & currentYear & "' AND surat_jalan = '' AND no_faktur = '' " &
                     "ORDER BY tanggal ASC, supplier ASC, (baris % 2 = 1) DESC"

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
            dtp_tanggal_cari.CustomFormat = "dd/MM/yyyy"

            Call CloneDataGridView(dgv1, dgv1_clone)
            Call atur_dgv_induk()
            For Each col As DataGridViewColumn In dgv1_clone.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk()
        'For i As Integer = 0 To dgv1_clone.Columns.Count - 1
        '    If i = 3 Or i = 4 Then ' Kolom ke-4 dan ke-5 (indeks mulai dari 0)
        '        dgv1_clone.Columns(i).ReadOnly = False ' Kolom ini dapat diedit
        '    Else
        '        dgv1_clone.Columns(i).ReadOnly = True ' Kolom lain tidak dapat diedit
        '    End If
        'Next
        dgv1_clone.Columns(1).HeaderText = "NAMA CLIENT"
        dgv1_clone.Columns(2).HeaderText = "TANGGAL"
        dgv1_clone.Columns(3).HeaderText = "SURAT JALAN"
        dgv1_clone.Columns(4).HeaderText = "FAKTUR PAJAK"
        dgv1_clone.Columns(6).HeaderText = "NAMA KAIN"
        dgv1_clone.Columns(7).HeaderText = "QTY"
        dgv1_clone.Columns(8).HeaderText = "HARGA (Rp)"
        dgv1_clone.Columns(9).HeaderText = "DPP (Rp)"
        dgv1_clone.Columns(10).HeaderText = "PPN (Rp)"
        dgv1_clone.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        dgv1_clone.Columns(12).HeaderText = "PPH23 (Rp)"
        dgv1_clone.Columns(13).HeaderText = "TOTAL TRANSFER (Rp)"
        For Each column As DataGridViewColumn In dgv1_clone.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'column.Width = 200
        Next
        dgv1_clone.Columns(0).Visible = False
        dgv1_clone.Columns(5).Visible = False
        dgv1_clone.Columns(14).Visible = False
        dgv1_clone.Columns(15).Visible = False
        dgv1_clone.Columns(16).Visible = False
        dgv1_clone.Columns(17).Visible = False
        dgv1_clone.Columns(18).Visible = False
        dgv1_clone.Columns(19).Visible = False
        dgv1_clone.RowHeadersWidth = 60
        dgv1_clone.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        'dgv1_clone.Columns(2).Width = 100
        dgv1_clone.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1_clone.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(13).DefaultCellStyle.Format = "#,##0.00"
        dgv1_clone.Columns(3).Width = 150
        dgv1_clone.Columns(4).Width = 170
    End Sub

    Private Sub CloneDataGridView(ByVal dgvSource As DataGridView, ByVal dgvTarget As DataGridView)
        ' Clear target DataGridView
        dgvTarget.Columns.Clear()
        dgvTarget.Rows.Clear()

        ' Clone kolom dari sumber ke target
        For Each col As DataGridViewColumn In dgvSource.Columns
            dgvTarget.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next

        ' Clone baris dari sumber ke target
        For Each row As DataGridViewRow In dgvSource.Rows
            If Not row.IsNewRow Then ' Abaikan baris kosong (NewRow)
                Dim clonedRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    ' Periksa apakah tipe data adalah DateTime
                    If TypeOf row.Cells(i).Value Is DateTime Then
                        Dim dt As DateTime = CType(row.Cells(i).Value, DateTime)
                        ' Simpan hanya bagian tanggal tanpa waktu
                        clonedRow.Cells(i).Value = dt.ToString("dd/MM/yyyy")
                    Else
                        clonedRow.Cells(i).Value = row.Cells(i).Value
                    End If
                Next
                dgvTarget.Rows.Add(clonedRow)
            End If
        Next

        ' Sinkronisasi properti penting lainnya jika diperlukan
        dgvTarget.AllowUserToAddRows = dgvSource.AllowUserToAddRows
    End Sub

    Private Sub dgv1_clone_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1_clone.CellFormatting
        ' Pastikan e.RowIndex valid
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgv1_clone.Rows.Count Then
            ' Tambahkan nomor baris di HeaderCell
            dgv1_clone.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
            Dim statusValue As String = TryCast(dgv1_clone.Rows(e.RowIndex).Cells("status").Value, String) ' Ganti "status" dengan nama kolom Anda

            ' Ubah warna berdasarkan nilai kolom "status"
            If Not String.IsNullOrEmpty(statusValue) Then
                Select Case statusValue
                    Case "Celup"
                        dgv1_clone.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                    Case "Kain"
                        dgv1_clone.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Khaki
                    Case Else
                        dgv1_clone.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End Select
            Else
                ' Jika nilai kosong, pastikan warna default
                dgv1_clone.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If

        End If
    End Sub

    'Private Sub btnNaik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNaik.Click
    '    ' Pastikan ada baris yang aktif
    '    If dgv1_clone.CurrentRow Is Nothing Then
    '        MessageBox.Show("Silakan pilih baris terlebih dahulu.")
    '        Return
    '    End If
    '    ' Mendapatkan index baris aktif
    '    Dim currentIndex As Integer = dgv1_clone.CurrentRow.Index
    '    ' Ambil nilai kode dari baris aktif
    '    Dim currentKode As String = dgv1_clone.Rows(currentIndex).Cells(18).Value.ToString()
    '    ' Hitung jumlah baris di atas currentIndex dengan kode yang sama dan dapatkan indeks baris teratas
    '    Dim topIndex As Integer = -1
    '    For i As Integer = currentIndex - 1 To 0 Step -1
    '        If dgv1_clone.Rows(i).Cells(18).Value.ToString() = currentKode Then
    '            topIndex = i ' Simpan indeks baris teratas yang memiliki kode yang sama
    '        Else
    '            Exit For ' Berhenti jika kode tidak sama
    '        End If
    '    Next
    '    ' Tentukan kolom yang akan digunakan sebagai referensi, misalnya kolom "kode" di index ke-18
    '    Dim referenceColumnIndex As Integer = 1
    '    ' Pindahkan current index ke baris teratas dengan kode yang sama
    '    If topIndex <> -1 Then
    '        ' Pastikan baris target terlihat
    '        dgv1_clone.Rows(topIndex).Visible = True
    '        ' Pindahkan current cell ke kolom referensi pada baris teratas
    '        dgv1_clone.CurrentCell = dgv1_clone.Rows(topIndex).Cells(referenceColumnIndex)
    '    End If
    '    ' Variabel untuk menghitung jumlah baris dengan kode yang sama
    '    Dim count As Integer = 0
    '    ' Loop melalui semua baris di DataGridView
    '    For Each row As DataGridViewRow In dgv1_clone.Rows
    '        If row.Cells(18).Value IsNot Nothing AndAlso row.Cells(18).Value.ToString() = currentKode Then
    '            count += 1
    '        End If
    '    Next
    '    currentIndex = dgv1_clone.CurrentRow.Index
    '    ' Pastikan tidak memeriksa baris pertama
    '    If currentIndex = 0 Then
    '        MessageBox.Show("Ini Baris pertama tidak bisa dinaikkan lagi")
    '        Return
    '    End If
    '    ' Ambil nilai kode dari baris tepat di atas baris aktif
    '    Dim targetKode As String = dgv1_clone.Rows(currentIndex - 1).Cells(18).Value.ToString()
    '    'MessageBox.Show("Baris di atas index: " & targetKode)
    '    ' Hitung jumlah baris di atas yang memiliki kode yang sama
    '    Dim countnaik As Integer = 0
    '    For i As Integer = currentIndex - 1 To 0 Step -1
    '        If dgv1_clone.Rows(i).Cells(18).Value.ToString() = targetKode Then
    '            countnaik += 1
    '        Else
    '            Exit For ' Berhenti jika kode tidak sama
    '        End If
    '    Next
    '    ' Tambahkan kolom jika belum ada
    '    If dgv_kol45.Columns.Count = 0 Then
    '        dgv_kol45.Columns.Add("Kolom4", "Kolom 4") ' Kolom untuk menyimpan nilai dari kolom 4
    '        dgv_kol45.Columns.Add("Kolom5", "Kolom 5") ' Kolom untuk menyimpan nilai dari kolom 5
    '    End If
    '    ' Pastikan dgv_kol45 memiliki jumlah baris yang sama dengan dgv1_clone
    '    If dgv_kol45.Rows.Count <> dgv1_clone.Rows.Count Then
    '        dgv_kol45.Rows.Clear()
    '        For Each row As DataGridViewRow In dgv1_clone.Rows
    '            dgv_kol45.Rows.Add()
    '        Next
    '    End If
    '    ' Salin nilai kolom 4 dan 5 dari dgv1_clone ke dgv_kol45 sebelum operasi
    '    For i As Integer = 0 To dgv1_clone.Rows.Count - 1
    '        dgv_kol45.Rows(i).Cells(0).Value = dgv1_clone.Rows(i).Cells(3).Value ' Kolom 4
    '        dgv_kol45.Rows(i).Cells(1).Value = dgv1_clone.Rows(i).Cells(4).Value ' Kolom 5
    '    Next
    '    ' Lanjutkan dengan menaikkan baris
    '    If countnaik > 0 Then
    '        ' Simpan semua baris yang akan dinaikkan ke dalam list
    '        Dim rowsToMove As New List(Of DataGridViewRow)
    '        ' Cari semua baris dengan kode yang sama dengan currentKode
    '        For i As Integer = currentIndex To dgv1_clone.Rows.Count - 1
    '            If dgv1_clone.Rows(i).Cells(18).Value.ToString() = currentKode Then
    '                rowsToMove.Add(dgv1_clone.Rows(i))
    '            Else
    '                Exit For ' Berhenti jika menemukan kode yang berbeda
    '            End If
    '        Next
    '        ' Hapus baris yang akan dipindahkan dari DataGridView
    '        For Each row As DataGridViewRow In rowsToMove
    '            dgv1_clone.Rows.Remove(row)
    '        Next
    '        ' Sisipkan baris ke posisi baru (di atas baris target)
    '        Dim newIndex As Integer = currentIndex - countnaik
    '        For Each row As DataGridViewRow In rowsToMove
    '            dgv1_clone.Rows.Insert(newIndex, row)
    '            newIndex += 1
    '        Next
    '        ' Pindahkan fokus ke baris teratas dari paket yang baru dipindahkan
    '        dgv1_clone.CurrentCell = dgv1_clone.Rows(newIndex - rowsToMove.Count).Cells(referenceColumnIndex)
    '    End If
    '    ' Kembalikan nilai kolom 4 dan 5 dari dgv_kol45 ke dgv1_clone setelah operasi selesai
    '    For i As Integer = 0 To dgv1_clone.Rows.Count - 1
    '        dgv1_clone.Rows(i).Cells(3).Value = dgv_kol45.Rows(i).Cells(0).Value ' Kolom 4
    '        dgv1_clone.Rows(i).Cells(4).Value = dgv_kol45.Rows(i).Cells(1).Value ' Kolom 5
    '    Next
    '    Call GenerateNoFaktur()
    'End Sub

    Private Sub btnNaik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNaik.Click
        ' Pastikan ada baris yang aktif
        If dgv1_clone.CurrentRow Is Nothing Then
            MessageBox.Show("Silakan pilih baris terlebih dahulu.")
            Return
        End If

        ' Mendapatkan index baris aktif
        Dim currentIndex As Integer = dgv1_clone.CurrentRow.Index

        ' Ambil nilai kode dari Cells(18) atau Cells(19) jika tidak kosong
        Dim currentKode As String = dgv1_clone.Rows(currentIndex).Cells(18).Value.ToString()
        If Not String.IsNullOrEmpty(dgv1_clone.Rows(currentIndex).Cells(19).Value.ToString()) Then
            currentKode = dgv1_clone.Rows(currentIndex).Cells(19).Value.ToString()
        End If

        ' Hitung jumlah baris di atas currentIndex dengan kode yang sama dan dapatkan indeks baris teratas
        Dim topIndex As Integer = -1
        For i As Integer = currentIndex - 1 To 0 Step -1
            Dim rowKode As String = dgv1_clone.Rows(i).Cells(18).Value.ToString()
            If Not String.IsNullOrEmpty(dgv1_clone.Rows(i).Cells(19).Value.ToString()) Then
                rowKode = dgv1_clone.Rows(i).Cells(19).Value.ToString()
            End If

            If rowKode = currentKode Then
                topIndex = i ' Simpan indeks baris teratas yang memiliki kode yang sama
            Else
                Exit For ' Berhenti jika kode tidak sama
            End If
        Next

        ' Tentukan kolom yang akan digunakan sebagai referensi, misalnya kolom "kode" di index ke-18
        Dim referenceColumnIndex As Integer = 1

        ' Pindahkan current index ke baris teratas dengan kode yang sama
        If topIndex <> -1 Then
            ' Pastikan baris target terlihat
            dgv1_clone.Rows(topIndex).Visible = True
            ' Pindahkan current cell ke kolom referensi pada baris teratas
            dgv1_clone.CurrentCell = dgv1_clone.Rows(topIndex).Cells(referenceColumnIndex)
        End If

        ' Variabel untuk menghitung jumlah baris dengan kode yang sama
        Dim count As Integer = 0

        ' Loop melalui semua baris di DataGridView
        For Each row As DataGridViewRow In dgv1_clone.Rows
            Dim rowKode As String = row.Cells(18).Value.ToString()
            If Not String.IsNullOrEmpty(row.Cells(19).Value.ToString()) Then
                rowKode = row.Cells(19).Value.ToString()
            End If

            If rowKode = currentKode Then
                count += 1
            End If
        Next

        currentIndex = dgv1_clone.CurrentRow.Index

        ' Pastikan tidak memeriksa baris pertama
        If currentIndex = 0 Then
            MessageBox.Show("Ini Baris pertama tidak bisa dinaikkan lagi")
            Return
        End If

        ' Ambil nilai kode dari baris tepat di atas baris aktif
        Dim targetKode As String = dgv1_clone.Rows(currentIndex - 1).Cells(18).Value.ToString()
        If Not String.IsNullOrEmpty(dgv1_clone.Rows(currentIndex - 1).Cells(19).Value.ToString()) Then
            targetKode = dgv1_clone.Rows(currentIndex - 1).Cells(19).Value.ToString()
        End If

        ' Hitung jumlah baris di atas yang memiliki kode yang sama
        Dim countnaik As Integer = 0
        For i As Integer = currentIndex - 1 To 0 Step -1
            Dim rowKode As String = dgv1_clone.Rows(i).Cells(18).Value.ToString()
            If Not String.IsNullOrEmpty(dgv1_clone.Rows(i).Cells(19).Value.ToString()) Then
                rowKode = dgv1_clone.Rows(i).Cells(19).Value.ToString()
            End If

            If rowKode = targetKode Then
                countnaik += 1
            Else
                Exit For ' Berhenti jika kode tidak sama
            End If
        Next

        ' Tambahkan kolom jika belum ada
        If dgv_kol45.Columns.Count = 0 Then
            dgv_kol45.Columns.Add("Kolom4", "Kolom 4") ' Kolom untuk menyimpan nilai dari kolom 4
            dgv_kol45.Columns.Add("Kolom5", "Kolom 5") ' Kolom untuk menyimpan nilai dari kolom 5
        End If

        ' Pastikan dgv_kol45 memiliki jumlah baris yang sama dengan dgv1_clone
        If dgv_kol45.Rows.Count <> dgv1_clone.Rows.Count Then
            dgv_kol45.Rows.Clear()
            For Each row As DataGridViewRow In dgv1_clone.Rows
                dgv_kol45.Rows.Add()
            Next
        End If

        ' Salin nilai kolom 4 dan 5 dari dgv1_clone ke dgv_kol45 sebelum operasi
        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            dgv_kol45.Rows(i).Cells(0).Value = dgv1_clone.Rows(i).Cells(3).Value ' Kolom 4
            dgv_kol45.Rows(i).Cells(1).Value = dgv1_clone.Rows(i).Cells(4).Value ' Kolom 5
        Next

        ' Lanjutkan dengan menaikkan baris
        If countnaik > 0 Then
            ' Simpan semua baris yang akan dinaikkan ke dalam list
            Dim rowsToMove As New List(Of DataGridViewRow)

            ' Cari semua baris dengan kode yang sama dengan currentKode
            For i As Integer = currentIndex To dgv1_clone.Rows.Count - 1
                Dim rowKode As String = dgv1_clone.Rows(i).Cells(18).Value.ToString()
                If Not String.IsNullOrEmpty(dgv1_clone.Rows(i).Cells(19).Value.ToString()) Then
                    rowKode = dgv1_clone.Rows(i).Cells(19).Value.ToString()
                End If

                If rowKode = currentKode Then
                    rowsToMove.Add(dgv1_clone.Rows(i))
                Else
                    Exit For ' Berhenti jika menemukan kode yang berbeda
                End If
            Next

            ' Hapus baris yang akan dipindahkan dari DataGridView
            For Each row As DataGridViewRow In rowsToMove
                dgv1_clone.Rows.Remove(row)
            Next

            ' Sisipkan baris ke posisi baru (di atas baris target)
            Dim newIndex As Integer = currentIndex - countnaik
            For Each row As DataGridViewRow In rowsToMove
                dgv1_clone.Rows.Insert(newIndex, row)
                newIndex += 1
            Next

            ' Pindahkan fokus ke baris teratas dari paket yang baru dipindahkan
            dgv1_clone.CurrentCell = dgv1_clone.Rows(newIndex - rowsToMove.Count).Cells(referenceColumnIndex)
        End If

        ' Kembalikan nilai kolom 4 dan 5 dari dgv_kol45 ke dgv1_clone setelah operasi selesai
        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            dgv1_clone.Rows(i).Cells(3).Value = dgv_kol45.Rows(i).Cells(0).Value ' Kolom 4
            dgv1_clone.Rows(i).Cells(4).Value = dgv_kol45.Rows(i).Cells(1).Value ' Kolom 5
        Next

        Call GenerateNoFaktur()
    End Sub

    'Private Sub btnTurun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurun.Click
    '    ' Pastikan ada baris yang aktif
    '    If dgv1_clone.CurrentRow Is Nothing Then
    '        MessageBox.Show("Silakan pilih baris terlebih dahulu.")
    '        Return
    '    End If
    '    ' Mendapatkan index baris aktif
    '    Dim currentIndex As Integer = dgv1_clone.CurrentRow.Index
    '    ' Ambil nilai kode dari baris aktif
    '    Dim currentKode As String = dgv1_clone.Rows(currentIndex).Cells(18).Value.ToString()
    '    Dim bottomIndex As Integer = -1
    '    For i As Integer = currentIndex + 1 To dgv1_clone.Rows.Count - 1
    '        If dgv1_clone.Rows(i).Cells(18).Value.ToString() = currentKode Then
    '            bottomIndex = i ' Simpan indeks baris terakhir yang memiliki kode yang sama
    '        Else
    '            Exit For ' Berhenti jika kode tidak sama
    '        End If
    '    Next
    '    ' Jika ditemukan, pindahkan current cell ke baris paling bawah dengan kode yang sama
    '    Dim referenceColumnIndex As Integer = 1 ' Ganti sesuai kolom referensi Anda
    '    If bottomIndex <> -1 Then
    '        ' Pastikan baris target terlihat
    '        dgv1_clone.Rows(bottomIndex).Visible = True
    '        ' Pindahkan current cell ke kolom referensi pada baris paling bawah

    '        dgv1_clone.CurrentCell = dgv1_clone.Rows(bottomIndex).Cells(referenceColumnIndex)
    '    End If
    '    Dim count As Integer = 0
    '    ' Loop melalui semua baris di DataGridView
    '    For Each row As DataGridViewRow In dgv1_clone.Rows
    '        If row.Cells(18).Value IsNot Nothing AndAlso row.Cells(18).Value.ToString() = currentKode Then
    '            count += 1
    '        End If
    '    Next
    '    currentIndex = dgv1_clone.CurrentRow.Index
    '    If currentIndex = dgv1_clone.Rows.Count - 1 Then
    '        MessageBox.Show("Ini Baris terakhir, tidak bisa diturunkan lagi")
    '        Return
    '    End If

    '    ' Ambil nilai kode dari baris tepat di bawah baris aktif
    '    Dim targetKode As String = dgv1_clone.Rows(currentIndex + 1).Cells(18).Value.ToString()
    '    ' Hitung jumlah baris di bawah yang memiliki kode yang sama
    '    Dim countturun As Integer = 0
    '    For i As Integer = currentIndex + 1 To dgv1_clone.Rows.Count - 1
    '        If dgv1_clone.Rows(i).Cells(18).Value.ToString() = targetKode Then
    '            countturun += 1
    '        Else
    '            Exit For ' Berhenti jika kode tidak sama
    '        End If
    '    Next
    '    ' Tambahkan kolom jika belum ada
    '    If dgv_kol45.Columns.Count = 0 Then
    '        dgv_kol45.Columns.Add("Kolom4", "Kolom 4") ' Kolom untuk menyimpan nilai dari kolom 4
    '        dgv_kol45.Columns.Add("Kolom5", "Kolom 5") ' Kolom untuk menyimpan nilai dari kolom 5
    '    End If
    '    ' Pastikan dgv_kol45 memiliki jumlah baris yang sama dengan dgv1_clone
    '    If dgv_kol45.Rows.Count <> dgv1_clone.Rows.Count Then
    '        dgv_kol45.Rows.Clear()
    '        For Each row As DataGridViewRow In dgv1_clone.Rows
    '            dgv_kol45.Rows.Add()
    '        Next
    '    End If
    '    ' Salin nilai kolom 4 dan 5 dari dgv1_clone ke dgv_kol45 sebelum operasi
    '    For i As Integer = 0 To dgv1_clone.Rows.Count - 1
    '        dgv_kol45.Rows(i).Cells(0).Value = dgv1_clone.Rows(i).Cells(3).Value ' Kolom 4
    '        dgv_kol45.Rows(i).Cells(1).Value = dgv1_clone.Rows(i).Cells(4).Value ' Kolom 5
    '    Next
    '    ' kode turunkan
    '    ' Kode untuk menurunkan baris
    '    If countturun > 0 Then
    '        ' Simpan paket baris yang akan diturunkan
    '        Dim rowsToMove As New List(Of DataGridViewRow)
    '        For i As Integer = currentIndex - count + 1 To currentIndex
    '            rowsToMove.Add(dgv1_clone.Rows(i))
    '        Next
    '        ' Hapus paket baris dari DataGridView
    '        For Each row As DataGridViewRow In rowsToMove
    '            dgv1_clone.Rows.Remove(row)
    '        Next
    '        ' Hitung posisi baru untuk menyisipkan paket baris
    '        Dim newIndex As Integer = currentIndex + countturun - count + 1

    '        ' Sisipkan paket baris ke posisi baru
    '        For Each row As DataGridViewRow In rowsToMove
    '            dgv1_clone.Rows.Insert(newIndex, row)
    '            newIndex += 1
    '        Next
    '        ' Fokus ke baris pertama dari paket yang baru dipindahkan
    '        dgv1_clone.CurrentCell = dgv1_clone.Rows(newIndex - rowsToMove.Count).Cells(referenceColumnIndex)
    '    Else
    '        MessageBox.Show("Tidak ada paket yang bisa diturunkan.")
    '    End If
    '    'akhir kode turun
    '    ' Kembalikan nilai kolom 4 dan 5 dari dgv_kol45 ke dgv1_clone setelah operasi selesai
    '    For i As Integer = 0 To dgv1_clone.Rows.Count - 1
    '        dgv1_clone.Rows(i).Cells(3).Value = dgv_kol45.Rows(i).Cells(0).Value ' Kolom 4
    '        dgv1_clone.Rows(i).Cells(4).Value = dgv_kol45.Rows(i).Cells(1).Value ' Kolom 5
    '    Next
    '    Call GenerateNoFaktur()
    'End Sub

    Private Sub btnTurun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurun.Click
        ' Pastikan ada baris yang aktif
        If dgv1_clone.CurrentRow Is Nothing Then
            MessageBox.Show("Silakan pilih baris terlebih dahulu.")
            Return
        End If
        ' Mendapatkan index baris aktif
        Dim currentIndex As Integer = dgv1_clone.CurrentRow.Index
        ' Ambil nilai kode dari baris aktif
        Dim currentKode As String = dgv1_clone.Rows(currentIndex).Cells(18).Value.ToString()
        Dim currentKode1 As String = dgv1_clone.Rows(currentIndex).Cells(19).Value.ToString()

        Dim bottomIndex As Integer = -1
        For i As Integer = currentIndex + 1 To dgv1_clone.Rows.Count - 1
            If dgv1_clone.Rows(i).Cells(19).Value.ToString() = currentKode1 And currentKode1 <> "" Then
                bottomIndex = i ' Simpan indeks baris terakhir yang memiliki kode yang sama
            ElseIf dgv1_clone.Rows(i).Cells(18).Value.ToString() = currentKode Then
                bottomIndex = i ' Simpan indeks baris terakhir yang memiliki kode yang sama
            Else
                Exit For ' Berhenti jika kode tidak sama
            End If
        Next
        ' Jika ditemukan, pindahkan current cell ke baris paling bawah dengan kode yang sama
        Dim referenceColumnIndex As Integer = 1 ' Ganti sesuai kolom referensi Anda
        If bottomIndex <> -1 Then
            ' Pastikan baris target terlihat
            dgv1_clone.Rows(bottomIndex).Visible = True
            ' Pindahkan current cell ke kolom referensi pada baris paling bawah

            dgv1_clone.CurrentCell = dgv1_clone.Rows(bottomIndex).Cells(referenceColumnIndex)
        End If
        Dim count As Integer = 0
        ' Loop melalui semua baris di DataGridView
        For Each row As DataGridViewRow In dgv1_clone.Rows
            If row.Cells(19).Value <> "" And row.Cells(19).Value.ToString() = currentKode1 Then
                count += 1
            ElseIf row.Cells(18).Value.ToString() = currentKode Then
                count += 1
            End If
        Next
        currentIndex = dgv1_clone.CurrentRow.Index
        If currentIndex = dgv1_clone.Rows.Count - 1 Then
            MessageBox.Show("Ini Baris terakhir, tidak bisa diturunkan lagi")
            Return
        End If

        ' Ambil nilai kode dari baris tepat di bawah baris aktif
        Dim targetKode As String = dgv1_clone.Rows(currentIndex + 1).Cells(18).Value.ToString()
        Dim targetKode1 As String = dgv1_clone.Rows(currentIndex + 1).Cells(19).Value.ToString()
        ' Hitung jumlah baris di bawah yang memiliki kode yang sama
        Dim countturun As Integer = 0
        For i As Integer = currentIndex + 1 To dgv1_clone.Rows.Count - 1
            If dgv1_clone.Rows(i).Cells(19).Value.ToString() = targetKode1 And dgv1_clone.Rows(i).Cells(19).Value <> "" Then
                countturun += 1
            ElseIf dgv1_clone.Rows(i).Cells(18).Value.ToString() = targetKode Then
                countturun += 1
            Else
                Exit For ' Berhenti jika kode tidak sama
            End If
        Next
        ' Tambahkan kolom jika belum ada
        If dgv_kol45.Columns.Count = 0 Then
            dgv_kol45.Columns.Add("Kolom4", "Kolom 4") ' Kolom untuk menyimpan nilai dari kolom 4
            dgv_kol45.Columns.Add("Kolom5", "Kolom 5") ' Kolom untuk menyimpan nilai dari kolom 5
        End If
        ' Pastikan dgv_kol45 memiliki jumlah baris yang sama dengan dgv1_clone
        If dgv_kol45.Rows.Count <> dgv1_clone.Rows.Count Then
            dgv_kol45.Rows.Clear()
            For Each row As DataGridViewRow In dgv1_clone.Rows
                dgv_kol45.Rows.Add()
            Next
        End If
        ' Salin nilai kolom 4 dan 5 dari dgv1_clone ke dgv_kol45 sebelum operasi
        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            dgv_kol45.Rows(i).Cells(0).Value = dgv1_clone.Rows(i).Cells(3).Value ' Kolom 4
            dgv_kol45.Rows(i).Cells(1).Value = dgv1_clone.Rows(i).Cells(4).Value ' Kolom 5
        Next
        ' kode turunkan
        ' Kode untuk menurunkan baris
        If countturun > 0 Then
            ' Simpan paket baris yang akan diturunkan
            Dim rowsToMove As New List(Of DataGridViewRow)
            For i As Integer = currentIndex - count + 1 To currentIndex
                rowsToMove.Add(dgv1_clone.Rows(i))
            Next
            ' Hapus paket baris dari DataGridView
            For Each row As DataGridViewRow In rowsToMove
                dgv1_clone.Rows.Remove(row)
            Next
            ' Hitung posisi baru untuk menyisipkan paket baris
            Dim newIndex As Integer = currentIndex + countturun - count + 1

            ' Sisipkan paket baris ke posisi baru
            For Each row As DataGridViewRow In rowsToMove
                dgv1_clone.Rows.Insert(newIndex, row)
                newIndex += 1
            Next
            ' Fokus ke baris pertama dari paket yang baru dipindahkan
            dgv1_clone.CurrentCell = dgv1_clone.Rows(newIndex - rowsToMove.Count).Cells(referenceColumnIndex)
        Else
            MessageBox.Show("Tidak ada paket yang bisa diturunkan.")
        End If
        'akhir kode turun
        ' Kembalikan nilai kolom 4 dan 5 dari dgv_kol45 ke dgv1_clone setelah operasi selesai
        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            dgv1_clone.Rows(i).Cells(3).Value = dgv_kol45.Rows(i).Cells(0).Value ' Kolom 4
            dgv1_clone.Rows(i).Cells(4).Value = dgv_kol45.Rows(i).Cells(1).Value ' Kolom 5
        Next
        Call GenerateNoFaktur()
    End Sub

    Private Sub txt_no_faktur_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_no_faktur.KeyPress
        ' Mengizinkan hanya angka
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Posisi kursor saat ini
        Dim cursorPosition As Integer = txt_no_faktur.SelectionStart

        ' Hanya memproses input jika belum penuh
        If txt_no_faktur.Text.Length >= 19 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Memasukkan karakter ke posisi yang sesuai
        If Char.IsDigit(e.KeyChar) Then
            Select Case cursorPosition
                Case 2, 9
                    'txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
                    txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & ".")
                    cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
                Case 6
                    'txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
                    txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & "-")
                    cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
                Case Else
                    txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar.ToString())
                    cursorPosition += 1
            End Select

            ' Menangani event untuk mencegah karakter ganda
            e.Handled = True

            ' Mengatur posisi kursor baru
            txt_no_faktur.SelectionStart = cursorPosition
        End If
    End Sub

    Sub GenerateNoFaktur()
        ' Ambil nomor faktur awal dari TextBox
        Dim noFakturAwal As String = txt_no_faktur.Text

        ' Validasi format nomor faktur menggunakan regex
        Dim fakturPattern As String = "^\d{3}\.\d{3}-\d{2}\.\d{8}$" ' Format xxx.xxx-xx.xxxxxxxx
        Dim regex As New System.Text.RegularExpressions.Regex(fakturPattern)

        ' Cek apakah nomor faktur sesuai dengan format
        If Not regex.IsMatch(noFakturAwal) Then
            MessageBox.Show("Nomor faktur tidak sesuai dengan format xxx.xxx-xx.xxxxxxxx", "Format Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_no_faktur.Focus()
            Exit Sub ' Hentikan proses jika format tidak sesuai
        End If

        ' Jika format valid, lanjutkan generate nomor faktur
        Dim prefix As String = noFakturAwal.Substring(0, noFakturAwal.LastIndexOf("-") + 1) ' Ambil bagian depan nomor faktur
        Dim noUrut As Long = CLng(noFakturAwal.Substring(noFakturAwal.LastIndexOf("-") + 1)) ' Ambil bagian akhir sebagai angka

        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            ' Cek apakah kolom 17 bernilai "Kain"
            If dgv1_clone.Rows(i).Cells(16).Value.ToString = "Kain" Then
                ' Cek apakah baris atas juga bernilai "Kain" dan memiliki nilai yang sama di kolom 19
                If i > 0 AndAlso dgv1_clone.Rows(i - 1).Cells(16).Value.ToString = "Kain" AndAlso dgv1_clone.Rows(i - 1).Cells(18).Value.ToString = dgv1_clone.Rows(i).Cells(18).Value.ToString Then
                    ' Jika ya, maka no faktur dibuat sama dengan baris atas
                    dgv1_clone.Rows(i).Cells(4).Value = dgv1_clone.Rows(i - 1).Cells(4).Value
                ElseIf i > 0 AndAlso dgv1_clone.Rows(i - 1).Cells(16).Value.ToString = "Kain" AndAlso dgv1_clone.Rows(i - 1).Cells(19).Value.ToString = dgv1_clone.Rows(i).Cells(19).Value.ToString AndAlso dgv1_clone.Rows(i - 1).Cells(19).Value.ToString <> "" Then
                    ' Jika ya, maka no faktur dibuat sama dengan baris atas
                    dgv1_clone.Rows(i).Cells(4).Value = dgv1_clone.Rows(i - 1).Cells(4).Value
                Else
                    ' Jika tidak, maka generate no faktur baru
                    Dim noFakturBaru As String = prefix & noUrut.ToString("00\.00000000") ' Format xx.00000000
                    dgv1_clone.Rows(i).Cells(4).Value = noFakturBaru
                    noUrut += 1 ' Tambah nomor urut
                End If
            ElseIf dgv1_clone.Rows(i).Cells(16).Value.ToString = "Celup" Then
                ' Cek apakah kolom 18 bernilai ganjil atau genap
                Dim nilai As Integer = CInt(dgv1_clone.Rows(i).Cells(17).Value)
                Dim jenis As String = If(nilai Mod 2 = 0, "Genap", "Ganjil")

                ' Cari ke seluruh atas baris adakah yang memilik kolom 17 "Celup" kolom 18 bernilai ganjil/genap dengan kolom 19 mempunyai nilai yang sama
                Dim found As Boolean = False
                For j As Integer = i - 1 To 0 Step -1
                    If dgv1_clone.Rows(j).Cells(16).Value.ToString = "Celup" AndAlso dgv1_clone.Rows(j).Cells(17).Value.ToString Mod 2 = nilai Mod 2 AndAlso dgv1_clone.Rows(j).Cells(18).Value.ToString = dgv1_clone.Rows(i).Cells(18).Value.ToString Then
                        ' Jika ya, maka no faktur dibuat sama dengan baris atas
                        dgv1_clone.Rows(i).Cells(4).Value = dgv1_clone.Rows(j).Cells(4).Value
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then
                    ' Jika tidak, maka generate no faktur baru
                    Dim noFakturBaru As String = prefix & noUrut.ToString("00\.00000000") ' Format xx.00000000
                    dgv1_clone.Rows(i).Cells(4).Value = noFakturBaru
                    noUrut += 1 ' Tambah nomor urut
                End If
            Else
                ' Jika kolom 17 tidak bernilai "Kain" atau "Celup", maka generate no faktur baru
                Dim noFakturBaru As String = prefix & noUrut.ToString("00\.000000 00000000") ' Format xx.00000000
                dgv1_clone.Rows(i).Cells(4).Value = noFakturBaru
                noUrut += 1 ' Tambah nomor urut
            End If
        Next

        ' Tampilkan nomor faktur terakhir di TextBox txt_no_faktur_akhir
        txt_no_faktur_akhir.Text = prefix & (noUrut - 1).ToString("00\.00000000")

        Call GenerateSuratJalan()

        Dim noFakturUnik As New HashSet(Of String)
        For i As Integer = 0 To dgv1_clone.Rows.Count - 1
            noFakturUnik.Add(dgv1_clone.Rows(i).Cells(4).Value.ToString)
        Next

        txt_jumlah_faktur.Text = noFakturUnik.Count.ToString
    End Sub
    Sub GenerateSuratJalan()
        Dim jumlah As Integer = dgv1_clone.Rows.Count ' Jumlah baris pada DataGridView
        Dim noAwal As String = txt_surat_jalan.Text ' Nomor awal dari txt_sj
        Dim pattern As String = "^AML-\d{5}/[IVXLCDM]+/\d{4}$" ' Regex untuk validasi format surat jalan

        ' Validasi format penulisan surat jalan
        If Not System.Text.RegularExpressions.Regex.IsMatch(noAwal, pattern) Then
            MessageBox.Show("Format nomor surat jalan tidak valid. Format yang benar: AML-xxxxx/mm/yyyy", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_surat_jalan.Focus()
            Exit Sub
        End If

        Dim noAwalUrutan As Integer = Convert.ToInt32(noAwal.Substring(4, 5)) ' Mengambil urutan nomor dari txt_sj
        Dim tahun As String = dtp_tanggal_cari.Value.Year.ToString()
        Dim bulanRomawi As String = GetBulanRomawi(dtp_tanggal_cari.Value.Month)

        ' Variabel untuk urutan surat jalan
        Dim urutan As Integer = noAwalUrutan

        ' Loop untuk mengisi DataGridView
        For i As Integer = 0 To jumlah - 1
            ' Ambil kode dari kolom ke-18
            Dim kode As String = dgv1_clone.Rows(i).Cells(18).Value.ToString()
            Dim gabung As String = dgv1_clone.Rows(i).Cells(19).Value.ToString()

            ' Periksa apakah ini bukan baris pertama
            If i > 0 Then
                Dim kodeSebelumnya As String = dgv1_clone.Rows(i - 1).Cells(18).Value.ToString()
                Dim gabungsebelumnya As String = dgv1_clone.Rows(i - 1).Cells(19).Value.ToString()

                ' Jika kode sama dengan kode sebelumnya, gunakan nomor surat jalan yang sama
                If gabung = gabungsebelumnya And gabung <> "" Then
                    dgv1_clone.Rows(i).Cells(3).Value = dgv1_clone.Rows(i - 1).Cells(3).Value
                    Continue For
                ElseIf kode = kodeSebelumnya Then
                    dgv1_clone.Rows(i).Cells(3).Value = dgv1_clone.Rows(i - 1).Cells(3).Value
                    Continue For
                End If
            End If

            ' Buat nomor surat jalan baru jika berbeda
            Dim noSuratJalan As String = String.Format("AML-{0:D5}/{1}/{2}", urutan, bulanRomawi, tahun)
            dgv1_clone.Rows(i).Cells(3).Value = noSuratJalan
            urutan += 1 ' Tambahkan urutan hanya jika nomor baru dibuat
        Next

        ' Menampilkan nomor faktur terakhir di txt_sj_akhir
        Dim noTerakhir As String = String.Format("AML-{0:D5}/{1}/{2}", urutan - 1, bulanRomawi, tahun)
        txt_surat_jalan_akhir.Text = noTerakhir
    End Sub
    Private Sub btn_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        Try
            If txt_tanggal_cari.Text = "" Then
                MsgBox("Bulan belum dipilih")
            ElseIf dgv1.RowCount = 0 Then
                MsgBox("Tidak ada Data Penjualan silahkan pilih bulan lain")
            ElseIf txt_surat_jalan.Text = "" Then
                MsgBox("Surat Jalan belum Diinput")
                txt_surat_jalan.Focus()
            ElseIf txt_no_faktur.Text = "" Then
                MsgBox("No Faktur belum Diinput")
                txt_no_faktur.Focus()
            Else
                Call GenerateNoFaktur()
                btn_simpan.Enabled = True
                btnNaik.Enabled = True
                btnTurun.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If MsgBox("Yakin Data Penjualan Akan Di UPDATE ?", vbYesNo + vbQuestion, "Update Data") = vbYes Then
                ' Pastikan Anda sudah membuka koneksi ke database MySQL
                Using connection As New MySqlConnection(sLocalConn)
                    connection.Open()
                    ' Loop untuk setiap baris data yang akan di-update
                    For i As Integer = 0 To dgv1_clone.Rows.Count - 1
                        Dim idJual As String = dgv1_clone.Rows(i).Cells(0).Value.ToString()
                        Dim suratJalan As String = dgv1_clone.Rows(i).Cells(3).Value.ToString()
                        Dim noFaktur As String = dgv1_clone.Rows(i).Cells(4).Value.ToString()
                        ' Perintah update ke database
                        Dim query As String = "UPDATE tbpenjualan SET surat_jalan = @suratJalan, no_faktur = @noFaktur WHERE id_jual = @idJual"
                        ' Membuat command dan menambahkan parameter
                        Using command As New MySqlCommand(query, connection)
                            command.Parameters.AddWithValue("@suratJalan", suratJalan)
                            command.Parameters.AddWithValue("@noFaktur", noFaktur)
                            command.Parameters.AddWithValue("@idJual", idJual)
                            ' Eksekusi perintah
                            command.ExecuteNonQuery()
                        End Using
                    Next
                    connection.Close()
                End Using
                MessageBox.Show("DATA PENJUALAN berhasil di UPDATE", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                form_menu_utama.btn_hitung_bukpot.Visible = True
                form_menu_utama.btn_hitung_bukpot.PerformClick()

                form_penjualan.Show()
                form_penjualan.Focus()

                ' Ambil bulan dan tahun dari dtp_tanggal
                Dim tahun As Integer = dtp_tanggal_cari.Value.Year
                Dim bulan As Integer = dtp_tanggal_cari.Value.Month

                ' Set nilai dtp_awal ke tanggal 1 di bulan dan tahun yang dipilih
                form_penjualan.dtp_awal.Value = New DateTime(tahun, bulan, 1)

                ' Set nilai dtp_akhir ke tanggal terakhir di bulan dan tahun yang dipilih
                form_penjualan.dtp_akhir.Value = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))

                form_penjualan.btn_cari.PerformClick()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class