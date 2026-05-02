Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_generate_sj_penjualan

    Private Sub form_generate_sj_penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupDataGridView()
        SetupDataGridViewdgv3()
    End Sub

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
        End If
    End Sub
    Private Sub txt_tanggal_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal_cari.TextChanged
        Call isidgvpenjualan()

        ' Menghitung jumlah baris yang ditampilkan di DataGridView
        Dim rowCount As Integer = dgv1.Rows.Count

        ' Menampilkan jumlah baris di TextBox
        txt_jumlah_baris.Text = rowCount.ToString()

        cari_max_surat_jalan()
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
                Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan WHERE MONTH(tanggal) = '" & currentMonth & "' AND Year(tanggal) = '" & currentYear & "' AND surat_jalan = '' AND no_faktur = '' ORDER BY tanggal ASC"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv1.DataSource = dsx.Tables("tbpenjualan")
                            Call atur_dgv_induk()
                        End Using
                    End Using
                End Using
            End Using
            dtp_tanggal_cari.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk()
        dgv1.Columns(1).HeaderText = "NAMA CLIENT"
        dgv1.Columns(2).HeaderText = "TANGGAL"
        dgv1.Columns(3).HeaderText = "SURAT JALAN"
        dgv1.Columns(4).HeaderText = "FAKTUR PAJAK"
        dgv1.Columns(6).HeaderText = "NAMA KAIN"
        dgv1.Columns(7).HeaderText = "QTY"
        dgv1.Columns(8).HeaderText = "HARGA (Rp)"
        dgv1.Columns(9).HeaderText = "DPP (Rp)"
        dgv1.Columns(10).HeaderText = "PPN (Rp)"
        dgv1.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        dgv1.Columns(12).HeaderText = "PPH23 (Rp)"
        dgv1.Columns(13).HeaderText = "TOTAL TRANSFER (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            column.Width = 200
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(3).Visible = False
        dgv1.Columns(4).Visible = False
        dgv1.Columns(5).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.Columns(18).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        'dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)

        'Dim indexStatusColumn As Integer = dgv1.Columns(16).Index

        '' Memeriksa apakah kolom yang sedang diformat adalah kolom "Status"
        'If e.ColumnIndex = indexStatusColumn Then
        '    ' Ambil nilai dari kolom "Status"
        '    Dim statusValue As String = e.Value.ToString()
        '    ' Ubah warna baris berdasarkan nilai kolom "Status"
        '    If statusValue = "Celup" Then
        '        dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        '    ElseIf statusValue = "Kain" Then
        '        dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Khaki
        '    Else
        '        ' Warna default
        '        dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        '    End If
        'End If

        If dgv1.ColumnCount > 15 Then
            ' Tambahkan nomor baris di HeaderCell
            dgv1.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()

            ' Periksa apakah DataBoundItem ada
            If dgv1.Rows(e.RowIndex).DataBoundItem IsNot Nothing Then
                ' Ambil nilai "Status" langsung dari sumber data
                Dim statusValue As String = TryCast(dgv1.Rows(e.RowIndex).Cells("status").Value, String) ' Ganti "Status" dengan nama kolom di data sumber

                ' Jika nilai tidak null, ubah warna berdasarkan status
                If Not String.IsNullOrEmpty(statusValue) Then
                    Select Case statusValue
                        Case "Celup"
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "Kain"
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Khaki
                        Case Else
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    End Select
                End If
            End If
        End If
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
    Private Sub txt_tambah_no_faktur_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_tambah_no_faktur.KeyPress
        ' Mengizinkan hanya angka
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Posisi kursor saat ini
        Dim cursorPosition As Integer = txt_tambah_no_faktur.SelectionStart

        ' Hanya memproses input jika belum penuh
        If txt_tambah_no_faktur.Text.Length >= 19 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Memasukkan karakter ke posisi yang sesuai
        If Char.IsDigit(e.KeyChar) Then
            Select Case cursorPosition
                Case 2, 9
                    'txt_tambah_no_faktur.Text = txt_tambah_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
                    txt_tambah_no_faktur.Text = txt_tambah_no_faktur.Text.Insert(cursorPosition, e.KeyChar & ".")
                    cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
                Case 6
                    'txt_tambah_no_faktur.Text = txt_tambah_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
                    txt_tambah_no_faktur.Text = txt_tambah_no_faktur.Text.Insert(cursorPosition, e.KeyChar & "-")
                    cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
                Case Else
                    txt_tambah_no_faktur.Text = txt_tambah_no_faktur.Text.Insert(cursorPosition, e.KeyChar.ToString())
                    cursorPosition += 1
            End Select

            ' Menangani event untuk mencegah karakter ganda
            e.Handled = True

            ' Mengatur posisi kursor baru
            txt_tambah_no_faktur.SelectionStart = cursorPosition
        End If
    End Sub

    ' Fungsi untuk menyiapkan DataGridView dan kolomnya
    Sub SetupDataGridView()
        ' Pastikan DataGridView dgv2 kosong sebelum menambahkan kolom
        dgv2.Columns.Clear()

        ' Tambahkan kolom untuk nomor faktur
        Dim colNoFaktur As New DataGridViewTextBoxColumn
        colNoFaktur.HeaderText = "No Faktur"
        colNoFaktur.Name = "no_faktur"
        colNoFaktur.Width = 150
        dgv2.Columns.Add(colNoFaktur)
        dgv2.RowHeadersWidth = 60

    End Sub
    Sub SetupDataGridViewdgv3()
        dgv3.Columns.Clear()
        Dim colSuratJalan As New DataGridViewTextBoxColumn
        colSuratJalan.HeaderText = "Surat Jalan"
        colSuratJalan.Name = "surat_jalan"
        colSuratJalan.Width = 150
        dgv3.Columns.Add(colSuratJalan)
        dgv3.RowHeadersWidth = 60
    End Sub

    ' Fungsi untuk generate nomor faktur
    Sub GenerateNoFaktur()
        ' Ambil nomor faktur awal dari TextBox
        Dim noFakturAwal As String = txt_no_faktur.Text
        Dim totalBaris As Integer = CInt(txt_jumlah_baris.Text) ' Ambil total baris dari TextBox

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

        ' Bersihkan baris di dgv2
        dgv2.Rows.Clear()

        ' Loop sebanyak total baris dan generate nomor faktur
        For i As Integer = 0 To totalBaris - 1
            ' Format nomor faktur dengan titik sebelum delapan digit terakhir
            Dim noFakturBaru As String = prefix & noUrut.ToString("00\.00000000") ' Format xx.00000000
            dgv2.Rows.Add(noFakturBaru) ' Tambahkan nomor faktur ke DataGridView
            noUrut += 1 ' Tambah nomor urut
        Next

        ' Tampilkan nomor faktur terakhir di TextBox txt_no_faktur_akhir
        txt_no_faktur_akhir.Text = prefix & (noUrut - 1).ToString("00\.00000000")
    End Sub
    Sub GenerateSuratJalan()
        Dim jumlah As Integer = Convert.ToInt32(txt_jumlah_baris.Text)
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

        ' Mengisi DataGridView dengan nomor surat jalan
        dgv3.Rows.Clear() ' Membersihkan DataGridView sebelum mengisi

        For i As Integer = 0 To jumlah - 1
            Dim noSuratJalan As String = String.Format("AML-{0:D5}/{1}/{2}", noAwalUrutan + i, bulanRomawi, tahun)
            dgv3.Rows.Add(noSuratJalan)
        Next

        ' Menampilkan nomor faktur terakhir di txt_sj_akhir
        Dim noTerakhir As String = String.Format("AML-{0:D5}/{1}/{2}", noAwalUrutan + jumlah - 1, bulanRomawi, tahun)
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
            ElseIf txt_jumlah_baris.Text = "0" Or txt_jumlah_baris.Text = "" Then
                MsgBox("Jumlah Lembar tidak boleh kosong atau bernilai 0")
                txt_jumlah_baris.Focus()
            Else
                Call GenerateNoFaktur()
                Call GenerateSuratJalan()
                Panel2.Enabled = True
                Panel4.Enabled = True
                btn_simpan.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv2.CellFormatting
        dgv2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgv3_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv3.CellFormatting
        dgv3.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btn_faktur_turun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_faktur_turun.Click
        If dgv2.Rows.Count = 0 OrElse dgv2.CurrentRow Is Nothing Then
            MessageBox.Show("Tidak ada baris yang dipilih atau DataGridView kosong.")
            Return
        End If

        Dim index As Integer = dgv2.CurrentCell.RowIndex

        ' Pastikan tidak di baris paling bawah
        If index < dgv2.Rows.Count - 1 Then ' Minus 2 karena ada row kosong di akhir
            ' Simpan baris yang dipilih
            Dim temp As DataGridViewRow = dgv2.Rows(index)

            ' Hapus baris yang dipilih
            dgv2.Rows.RemoveAt(index)

            ' Masukkan kembali di bawah baris berikutnya
            dgv2.Rows.Insert(index + 1, temp)

            ' Pilih kembali baris yang dipindahkan
            dgv2.ClearSelection()
            dgv2.Rows(index + 1).Selected = True
            dgv2.CurrentCell = dgv2.Rows(index + 1).Cells(0)
        End If
    End Sub
    Private Sub btn_faktur_naik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_faktur_naik.Click
        If dgv2.Rows.Count = 0 OrElse dgv2.CurrentRow Is Nothing Then
            MessageBox.Show("Tidak ada baris yang dipilih atau DataGridView kosong.")
            Return
        End If

        Dim index As Integer = dgv2.CurrentCell.RowIndex

        ' Pastikan tidak di baris paling atas
        If index > 0 Then
            ' Simpan baris yang dipilih
            Dim temp As DataGridViewRow = dgv2.Rows(index)

            ' Hapus baris yang dipilih
            dgv2.Rows.RemoveAt(index)

            ' Masukkan kembali di atas baris sebelumnya
            dgv2.Rows.Insert(index - 1, temp)

            ' Pilih kembali baris yang dipindahkan
            dgv2.ClearSelection()
            dgv2.Rows(index - 1).Selected = True
            dgv2.CurrentCell = dgv2.Rows(index - 1).Cells(0)
        End If
    End Sub
    Private Sub btn_sj_turun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sj_turun.Click
        If dgv3.Rows.Count = 0 OrElse dgv3.CurrentRow Is Nothing Then
            MessageBox.Show("Tidak ada baris yang dipilih atau DataGridView kosong.")
            Return
        End If

        Dim index As Integer = dgv3.CurrentCell.RowIndex

        ' Pastikan tidak di baris paling bawah
        If index < dgv3.Rows.Count - 1 Then ' Minus 2 karena ada row kosong di akhir
            ' Simpan baris yang dipilih
            Dim temp As DataGridViewRow = dgv3.Rows(index)

            ' Hapus baris yang dipilih
            dgv3.Rows.RemoveAt(index)

            ' Masukkan kembali di bawah baris berikutnya
            dgv3.Rows.Insert(index + 1, temp)

            ' Pilih kembali baris yang dipindahkan
            dgv3.ClearSelection()
            dgv3.Rows(index + 1).Selected = True
            dgv3.CurrentCell = dgv3.Rows(index + 1).Cells(0)
        End If
    End Sub
    Private Sub btn_sj_naik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sj_naik.Click
        If dgv3.Rows.Count = 0 OrElse dgv3.CurrentRow Is Nothing Then
            MessageBox.Show("Tidak ada baris yang dipilih atau DataGridView kosong.")
            Return
        End If

        Dim index As Integer = dgv3.CurrentCell.RowIndex

        ' Pastikan tidak di baris paling atas
        If index > 0 Then
            ' Simpan baris yang dipilih
            Dim temp As DataGridViewRow = dgv3.Rows(index)

            ' Hapus baris yang dipilih
            dgv3.Rows.RemoveAt(index)

            ' Masukkan kembali di atas baris sebelumnya
            dgv3.Rows.Insert(index - 1, temp)

            ' Pilih kembali baris yang dipindahkan
            dgv3.ClearSelection()
            dgv3.Rows(index - 1).Selected = True
            dgv3.CurrentCell = dgv3.Rows(index - 1).Cells(0)
        End If
    End Sub

    Private Sub btn_sj_tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sj_tambah.Click
        panel_tambah_sj.Visible = True
        txt_tambah_sj.Focus()
    End Sub
    Private Sub btn_cancel_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel_sj.Click
        txt_tambah_sj.Text = ""
        panel_tambah_sj.Visible = False
    End Sub
    Private Sub btn_tambah_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tambah_sj.Click
        Dim noSuratJalanBaru As String = txt_tambah_sj.Text
        Dim pattern As String = "^AML-\d{5}/[IVXLCDM]+/\d{4}$" ' Regex untuk validasi format surat jalan

        ' Validasi format penulisan surat jalan
        If Not System.Text.RegularExpressions.Regex.IsMatch(noSuratJalanBaru, pattern) Then
            MessageBox.Show("Format nomor surat jalan tidak valid. Format yang benar: AML-xxxxx/mr/yyyy", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_tambah_sj.Focus()
            Exit Sub
        End If

        ' Menambahkan nomor surat jalan baru ke DataGridView
        dgv3.Rows.Add(noSuratJalanBaru)

        Dim lastRowIndex As Integer = dgv3.Rows.Count - 1
        dgv3.CurrentCell = dgv3.Rows(lastRowIndex).Cells(0)
        dgv3.FirstDisplayedScrollingRowIndex = lastRowIndex
        'MessageBox.Show("Nomor surat jalan berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btn_sj_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sj_hapus.Click
        If dgv3.CurrentRow IsNot Nothing Then
            dgv3.Rows.RemoveAt(dgv3.CurrentRow.Index)
        Else
            MessageBox.Show("Silakan pilih nomor surat jalan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btn_faktur_tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_faktur_tambah.Click
        panel_tambah_faktur.Visible = True
        txt_tambah_no_faktur.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_tambah_no_faktur.Text = ""
        panel_tambah_faktur.Visible = False
    End Sub
    Private Sub btn_faktur_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_faktur_hapus.Click
        If dgv2.CurrentRow IsNot Nothing Then
            dgv2.Rows.RemoveAt(dgv2.CurrentRow.Index)
        Else
            MessageBox.Show("Silakan pilih nomor faktur yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Ambil nomor faktur awal dari TextBox
        Dim noFakturAwal As String = txt_tambah_no_faktur.Text
        
        ' Validasi format nomor faktur menggunakan regex
        Dim fakturPattern As String = "^\d{3}\.\d{3}-\d{2}\.\d{8}$" ' Format 555.555-55.55555556
        Dim regex As New System.Text.RegularExpressions.Regex(fakturPattern)

        ' Cek apakah nomor faktur sesuai dengan format
        If Not regex.IsMatch(noFakturAwal) Then
            MessageBox.Show("Nomor faktur tidak sesuai dengan format xxx.xxx-xx.xxxxxxxx", "Format Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_tambah_no_faktur.Focus()
            Exit Sub ' Hentikan proses jika format tidak sesuai
        End If

        dgv2.Rows.Add(noFakturAwal)

        Dim lastRowIndex As Integer = dgv2.Rows.Count - 1
        dgv2.CurrentCell = dgv2.Rows(lastRowIndex).Cells(0)
        dgv2.FirstDisplayedScrollingRowIndex = lastRowIndex
    End Sub

    Private Sub txt_jumlah_baris_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_jumlah_baris.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) AndAlso Not e.KeyChar = ChrW(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txt_jumlah_baris_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_jumlah_baris.LostFocus
        ' Cek apakah teks bukan kosong atau nol
        If Not String.IsNullOrEmpty(txt_jumlah_baris.Text) Then
            ' Menghapus nol di depan dan mengubah ke format angka
            txt_jumlah_baris.Text = CInt(txt_jumlah_baris.Text).ToString()
        End If
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If dgv3.Rows.Count <> dgv2.Rows.Count Then
                MessageBox.Show("Jumlah baris di Surat Jalan dan No Faktur harus sama", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dgv3.Rows.Count = 0 Or dgv2.Rows.Count = 0 Then
                MessageBox.Show("Jumlah baris di Surat Jalan atau No Faktur Tidak boleh kosong", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dgv3.Rows.Count > dgv1.Rows.Count Or dgv2.Rows.Count > dgv1.Rows.Count Then
                MessageBox.Show("Jumlah baris di Surat Jalan atau No Faktur Tidak boleh lebih dari data Penjualan", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MsgBox("Yakin Data Penjualan Akan Di UPDATE ?", vbYesNo + vbQuestion, "Update Data") = vbYes Then
                ' Pastikan Anda sudah membuka koneksi ke database MySQL
                Using connection As New MySqlConnection(sLocalConn)
                    connection.Open()

                    ' Periksa jumlah baris yang akan di-update
                    Dim rowCount As Integer = Math.Min(dgv2.Rows.Count, dgv3.Rows.Count)

                    ' Loop untuk setiap baris data yang akan di-update
                    For i As Integer = 0 To rowCount - 1
                        Dim idJual As String = dgv1.Rows(i).Cells("id_jual").Value.ToString()
                        Dim suratJalan As String = dgv3.Rows(i).Cells(0).Value.ToString()
                        Dim noFaktur As String = dgv2.Rows(i).Cells(0).Value.ToString()

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