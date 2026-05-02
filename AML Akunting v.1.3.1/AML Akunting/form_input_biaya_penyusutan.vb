Imports MySql.Data.MySqlClient

Public Class form_input_biaya_penyusutan

    Private Sub buat_kode()
        Dim dtptoday As New DateTimePicker
        txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        txt_kode.Text = txt_kode.Text.Replace("-", "").Replace(":", "")
    End Sub

    Private Sub txt_nilai_buku_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nilai_buku.KeyPress
        'If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c AndAlso e.KeyChar <> ControlChars.Back Then
        '    e.Handled = True
        '    Exit Sub
        'End If
    End Sub
    Private Sub txt_nilai_buku_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nilai_buku.LostFocus
        If txt_nilai_buku.Text <> "" Then
            Dim input As String = txt_nilai_buku.Text
            Dim number As Decimal
            If Decimal.TryParse(input, number) Then
                txt_nilai_buku.Text = number.ToString("#,##0")
            Else
                MessageBox.Show("NILAI BUKU harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_nilai_buku.SelectAll()
                txt_nilai_buku.Focus()
            End If
        End If
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If btn_simpan.Text = "GENERATE" Then
                If cbo_aset.Text = "-- Pilih Aset --" Then
                    MsgBox("Pilih terlebih dahulu kategori Asetnya")
                    cbo_aset.Focus()
                ElseIf txt_nama_aset.Text = "" Then
                    MsgBox("Nama Aset belum diinput")
                    txt_nama_aset.Focus()
                ElseIf txt_nilai_buku.Text = "" Then
                    MsgBox("Nilai Buku belum diinput")
                    txt_nilai_buku.Focus()
                Else
                    Call buat_kolom_dgv1()
                    If cbo_aset.Text = "MESIN" Then
                        Call hitung_penyusutan_mesin()
                    ElseIf cbo_aset.Text = "INVENTARIS" Or cbo_aset.Text = "KENDARAAN" Then
                        Call hitung_penyusutan_Kendaraan_inventaris()
                    ElseIf cbo_aset.Text = "BANGUNAN" Then
                        Call hitung_penyusutan_bangunan()
                    ElseIf cbo_aset.Text = "TANKI PENGOLAH LIMBAH" Then
                        Call hitung_penyusutan_tanki()
                    End If
                    If txt_id.Text = "" Then
                        btn_simpan.Text = "SIMPAN"
                        pn_input.Enabled = False
                    Else
                        btn_simpan.Text = "UPDATE"
                        pn_input.Enabled = False
                    End If
                End If
            ElseIf btn_simpan.Text = "SIMPAN" Then
                Call buat_kode()
                Call simpan()
                MsgBox("Data penyusutan baru berhasil disimpan")
                Me.Close()
                form_biaya_penyusutan.Show()
                form_biaya_penyusutan.Focus()
                form_biaya_penyusutan.ts_refresh.PerformClick()
            ElseIf btn_simpan.Text = "UPDATE" Then
                Call hapus()
                Call buat_kode()
                Call simpan()
                MsgBox("Data penyusutan berhasil di Update")
                Me.Close()
                form_biaya_penyusutan.Show()
                form_biaya_penyusutan.Focus()
                form_biaya_penyusutan.ts_refresh.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub simpan()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbindukpenyusutan (kode,kategori_aset,nama_aset,tahun,nilai_buku) " &
                "VALUES (@1,@2,@3,@4,@5)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_kode.Text)
                    .Parameters.AddWithValue("@2", cbo_aset.Text)
                    .Parameters.AddWithValue("@3", txt_nama_aset.Text)
                    .Parameters.AddWithValue("@4", dtp_tahun.Text)
                    .Parameters.AddWithValue("@5", txt_nilai_buku.Text.Replace(".", "").Replace(",", "."))
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbdatapenyusutan (tahun,persentase,nilai_penyusutan,nilai_buku,kode,kategori_aset) " &
                "VALUES (@1,@2,@3,@4,@5,@6)"
            For Each row As DataGridViewRow In dgv1.Rows
                If Not row.IsNewRow Then
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", row.Cells(0).Value)
                            .Parameters.AddWithValue("@2", row.Cells(1).Value)
                            .Parameters.AddWithValue("@3", row.Cells(2).Value)
                            .Parameters.AddWithValue("@4", row.Cells(3).Value)
                            .Parameters.AddWithValue("@5", txt_kode.Text)
                            .Parameters.AddWithValue("@6", cbo_aset.Text)
                            .ExecuteNonQuery()
                        End With
                    End Using
                End If
            Next
        End Using
    End Sub
    Private Sub hapus()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT kode FROM tbindukpenyusutan WHERE kode='" & txt_id.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbindukpenyusutan WHERE kode='" & txt_id.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbdatapenyusutan WHERE kode='" & txt_id.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub buat_kolom_dgv1()
        dgv1.DataSource = Nothing ' Putus koneksi dengan DataSource
        dgv1.Columns.Clear()     ' Hapus semua kolom yang ada
        dgv1.Rows.Clear()        ' Bersihkan semua baris (opsional, untuk berjaga-jaga)
        ' Tambahkan kolom ke dgv1
        dgv1.Columns.Add("Tahun", "Tahun")
        dgv1.Columns.Add("PersentasePenyusutan", "%")
        dgv1.Columns.Add("NilaiPenyusutan", "Penyusutan")
        dgv1.Columns.Add("NilaiBuku", "Nilai Buku")
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns("PersentasePenyusutan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns("NilaiPenyusutan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns("NilaiBuku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns("Tahun").Width = 70
        dgv1.Columns("PersentasePenyusutan").Width = 80
        dgv1.Columns("NilaiPenyusutan").Width = 120
        dgv1.Columns("NilaiBuku").Width = 120
        ' Atur format angka ke dua desimal tanpa pemisah ribuan
        dgv1.Columns("NilaiPenyusutan").DefaultCellStyle.Format = "#,##0"
        dgv1.Columns("NilaiBuku").DefaultCellStyle.Format = "#,##0"
    End Sub
    Private Sub hitung_penyusutan_mesin()
        ' Bersihkan dgv1 sebelum memasukkan data baru
        dgv1.Rows.Clear()
        ' Pastikan txt_nilai_buku memiliki angka yang valid
        Dim nilaiBukuAwal As Decimal
        If Not Decimal.TryParse(txt_nilai_buku.Text, nilaiBukuAwal) Then
            MessageBox.Show("Masukkan nilai buku yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' Tahun awal penyusutan (diambil dari tahun sekarang atau bisa dari input)
        Dim tahunAwal As Integer = dtp_tahun.Text
        Dim tarifPenyusutan As Decimal = 0.125 ' 12.5%
        Dim nilaiBuku As Decimal = nilaiBukuAwal
        ' Iterasi penyusutan maksimal 16 kali
        Dim tahun As Integer = tahunAwal
        For i As Integer = 1 To 16
            Dim nilaiPenyusutan As Decimal
            ' Jika sudah di baris ke-16, nilai penyusutan harus sama dengan nilai buku agar nilai buku menjadi 0
            If i = 16 Then
                nilaiPenyusutan = nilaiBuku
            Else
                nilaiPenyusutan = nilaiBuku * tarifPenyusutan ' Dibulatkan ke satuan terdekat
            End If
            ' Kurangi nilai buku
            nilaiBuku -= nilaiPenyusutan
            ' Tambahkan hasil ke dalam DataGridView (dgv1)
            dgv1.Rows.Add(tahun, (tarifPenyusutan * 100).ToString("0.##") & "%", nilaiPenyusutan, nilaiBuku)
            ' Hentikan jika nilai buku sudah 0
            If nilaiBuku = 0 Then Exit For
            ' Naikkan tahun
            tahun += 1
        Next
    End Sub
    Private Sub hitung_penyusutan_Kendaraan_inventaris()
        ' Bersihkan dgv1 sebelum memasukkan data baru
        dgv1.Rows.Clear()
        ' Pastikan txt_nilai_buku memiliki angka yang valid
        Dim nilaiBukuAwal As Decimal
        If Not Decimal.TryParse(txt_nilai_buku.Text, nilaiBukuAwal) Then
            MessageBox.Show("Masukkan nilai buku yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' Tahun awal penyusutan (diambil dari tahun sekarang atau bisa dari input)
        Dim tahunAwal As Integer = dtp_tahun.Text
        Dim tarifPenyusutan As Decimal = 0.25 ' 12.5%
        Dim nilaiBuku As Decimal = nilaiBukuAwal
        ' Iterasi penyusutan maksimal 4 kali
        Dim tahun As Integer = tahunAwal
        For i As Integer = 1 To 4
            Dim nilaiPenyusutan As Decimal
            ' Jika sudah di baris ke-16, nilai penyusutan harus sama dengan nilai buku agar nilai buku menjadi 0
            If i = 4 Then
                nilaiPenyusutan = nilaiBuku
            Else
                nilaiPenyusutan = nilaiBuku * tarifPenyusutan ' Dibulatkan ke satuan terdekat
            End If
            ' Kurangi nilai buku
            nilaiBuku -= nilaiPenyusutan
            ' Tambahkan hasil ke dalam DataGridView (dgv1)
            dgv1.Rows.Add(tahun, (tarifPenyusutan * 100).ToString("0.##") & "%", nilaiPenyusutan, nilaiBuku)
            ' Hentikan jika nilai buku sudah 0
            If nilaiBuku = 0 Then Exit For
            ' Naikkan tahun
            tahun += 1
        Next
    End Sub
    Private Sub hitung_penyusutan_bangunan()
        dgv1.Rows.Clear()
        Dim nilaiBukuAwal As Decimal
        If Not Decimal.TryParse(txt_nilai_buku.Text, nilaiBukuAwal) Then
            MessageBox.Show("Masukkan nilai buku yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim tahunAwal As Integer = dtp_tahun.Text
        Dim tarifPenyusutan As Decimal = 0.05 ' 12.5%
        Dim nilaiBuku As Decimal = nilaiBukuAwal
        Dim tahun As Integer = tahunAwal
        Dim nilaiPenyusutan As Decimal
        nilaiPenyusutan = tarifPenyusutan * nilaiBuku
        For i As Integer = 1 To 20
            nilaiBuku -= nilaiPenyusutan
            dgv1.Rows.Add(tahun, (tarifPenyusutan * 100).ToString("0.##") & "%", nilaiPenyusutan, nilaiBuku)
            If nilaiBuku = 0 Then Exit For
            tahun += 1
        Next
    End Sub
    Private Sub hitung_penyusutan_tanki()
        dgv1.Rows.Clear()
        Dim nilaiBukuAwal As Decimal
        If Not Decimal.TryParse(txt_nilai_buku.Text, nilaiBukuAwal) Then
            MessageBox.Show("Masukkan nilai buku yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim tahunAwal As Integer = dtp_tahun.Text
        Dim tarifPenyusutan As Decimal = 0.0625
        Dim nilaiBuku As Decimal = nilaiBukuAwal
        Dim tahun As Integer = tahunAwal
        For i As Integer = 1 To 17
            Dim nilaiPenyusutan As Decimal
            If i = 17 Then
                nilaiPenyusutan = nilaiBuku
            ElseIf i = 1 Then
                nilaiPenyusutan = (11 / 12) * tarifPenyusutan * nilaiBuku
            Else
                nilaiPenyusutan = nilaiBukuAwal * tarifPenyusutan
            End If
            nilaiBuku -= nilaiPenyusutan
            dgv1.Rows.Add(tahun, (tarifPenyusutan * 100).ToString("0.##") & "%", nilaiPenyusutan, nilaiBuku)
            If nilaiBuku = 0 Then Exit For
            tahun += 1
        Next
    End Sub
    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        If btn_simpan.Text = "UPDATE" Then
            btn_simpan.Text = "GENERATE"
            pn_input.Enabled = True
        Else
            dgv1.Columns.Clear()
            cbo_aset.Text = "-- Pilih Aset --"
            txt_nama_aset.Text = ""
            txt_nilai_buku.Text = ""
            btn_simpan.Text = "GENERATE"
            txt_id.Text = ""
            pn_input.Enabled = True
            Label7.Text = "INPUT PENYUSUTAN"
        End If
    End Sub

    Private Sub txt_nama_aset_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nama_aset.LostFocus
        'If txt_id.Text = "" Then
        '    Using conx As New MySqlConnection(sLocalConn)
        '        conx.Open()
        '        Dim sqlx = "SELECT nama_aset FROM tbindukpenyusutan WHERE nama_aset='" & txt_nama_aset.Text & "'"
        '        Using cmdx As New MySqlCommand(sqlx, conx)
        '            Using drx As MySqlDataReader = cmdx.ExecuteReader
        '                drx.Read()
        '                If drx.HasRows Then
        '                    MsgBox("Nama aset sudah terdapat di Database")
        '                    txt_nama_aset.Focus()
        '                End If
        '            End Using
        '        End Using
        '    End Using
        'End If
    End Sub

    Private Sub txt_id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        Call tampil_detail_penyusutan()
    End Sub
    Private Sub tampil_detail_penyusutan()
        dgv1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku, kode " &
                                "FROM tbdatapenyusutan " &
                                "WHERE kode = '" & txt_id.Text & "' " &
                                "ORDER BY tahun ASC"
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
        dgv1.Columns(0).HeaderText = "TAHUN"
        dgv1.Columns(1).HeaderText = "%"
        dgv1.Columns(2).HeaderText = "PENYUSUTAN"
        dgv1.Columns(3).HeaderText = "NILAI BUKU"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(4).Visible = False
        dgv1.Columns(0).Width = 70
        dgv1.Columns(1).Width = 70
        dgv1.Columns(2).Width = 120
        dgv1.Columns(3).Width = 120
        dgv1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(2).DefaultCellStyle.Format = "#,##0"
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0"
    End Sub
End Class