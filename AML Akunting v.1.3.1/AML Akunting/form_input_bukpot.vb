Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.ComponentModel

Public Class form_input_bukpot

    Private Sub form_input_bukpot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_belum_bukpot()
        Call InitializeDgv2()
        Call masa_bukpot()
        Call generate_kode_gabung()
    End Sub
    Private Sub generate_kode_gabung()
        Dim dtptoday As New DateTimePicker
        txt_kode_gabung.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        txt_kode_gabung.Text = txt_kode_gabung.Text.Replace("-", "").Replace(":", "")
    End Sub
    Private Sub masa_bukpot()
        Dim selectedDate As DateTime = dtp_masa_bukpot.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_upload.Text = formattedDate
    End Sub

    Private Sub tampil_belum_bukpot()
        dgv1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT id_jual, supplier, npwp, tanggal, no_faktur, dpp, ppn, pph23, pph23_actual, no_bukpot, tgl_bukpot, masa_bukpot, gabung_bukpot " &
                                 "FROM tbpenjualan " &
                                 "WHERE no_bukpot = '' " &
                                 "AND jenis_biaya = 'Jasa' " &
                                 "AND no_faktur <> '' " &
                                 "ORDER BY tanggal ASC"
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
        dgv1.Columns(3).HeaderText = "TANGGAL"
        dgv1.Columns(4).HeaderText = "NO FAKTUR"
        dgv1.Columns(5).HeaderText = "DPP"
        dgv1.Columns(6).HeaderText = "PPN"
        dgv1.Columns(7).HeaderText = "PPH 23"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(0).Visible = False
        dgv1.Columns(2).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(9).Visible = False
        dgv1.Columns(10).Visible = False
        dgv1.Columns(11).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(1).Width = 220
        dgv1.Columns(3).Width = 85
        dgv1.Columns(4).Width = 160
        dgv1.Columns(5).Width = 120
        dgv1.Columns(6).Width = 120
        dgv1.Columns(7).Width = 110
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub dgv2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv2.CellFormatting
        dgv2.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub tampil_sudah_bukpot()
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
    End Sub
    Private Sub InitializeDgv2()
        'id_jual, supplier, npwp, tanggal, no_faktur, dpp, ppn, pph23, pph23_actual, no_bukpot, tgl_bukpot, masa_bukpot, gabung_bukpot
        dgv2.Columns.Clear()
        dgv2.Columns.Add("id_jual", "id_jual")
        dgv2.Columns.Add("supplier", "supplier")
        dgv2.Columns.Add("npwp", "npwp")
        dgv2.Columns.Add("tanggal", "tanggal")
        dgv2.Columns.Add("no_faktur", "no_faktur")
        dgv2.Columns.Add("dpp", "dpp")
        dgv2.Columns.Add("ppn", "ppn")
        dgv2.Columns.Add("pph23", "pph23")
        dgv2.Columns.Add("pph23_actual", "pph23_actual")
        dgv2.Columns.Add("no_bukpot", "no_bukpot")
        dgv2.Columns.Add("tgl_bukpot", "tgl_bukpot")
        dgv2.Columns.Add("masa_bukpot", "masa_bukpot")
        dgv2.Columns.Add("gabung_bukpot", "gabung_bukpot")

        dgv2.Columns(1).HeaderText = "CUSTOMER"
        dgv2.Columns(3).HeaderText = "TANGGAL"
        dgv2.Columns(4).HeaderText = "NO FAKTUR"
        dgv2.Columns(5).HeaderText = "DPP"
        dgv2.Columns(6).HeaderText = "PPN"
        dgv2.Columns(7).HeaderText = "PPH 23"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.RowHeadersWidth = 60
        dgv2.Columns(0).Visible = False
        dgv2.Columns(2).Visible = False
        dgv2.Columns(8).Visible = False
        dgv2.Columns(9).Visible = False
        dgv2.Columns(10).Visible = False
        dgv2.Columns(11).Visible = False
        dgv2.Columns(12).Visible = False
        dgv2.Columns(1).Width = 220
        dgv2.Columns(3).Width = 85
        dgv2.Columns(4).Width = 160
        dgv2.Columns(5).Width = 120
        dgv2.Columns(6).Width = 120
        dgv2.Columns(7).Width = 110
        dgv2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
        dgv2.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(7).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub InitializeDgv2_ubah_hapus()
        dgv2.Columns.Clear()
        dgv2.Columns.Add("id_jual", "id_jual")
        dgv2.Columns.Add("supplier", "supplier")
        dgv2.Columns.Add("npwp", "npwp")
        dgv2.Columns.Add("tanggal", "tanggal")
        dgv2.Columns.Add("no_faktur", "no_faktur")
        dgv2.Columns.Add("dpp", "dpp")
        dgv2.Columns.Add("ppn", "ppn")
        dgv2.Columns.Add("pph23", "pph23")
        dgv2.Columns.Add("pph23_actual", "pph23_actual")
        dgv2.Columns.Add("no_bukpot", "no_bukpot")
        dgv2.Columns.Add("tgl_bukpot", "tgl_bukpot")
        dgv2.Columns.Add("masa_bukpot", "masa_bukpot")
        dgv2.Columns.Add("gabung_bukpot", "gabung_bukpot")

        dgv2.Columns(1).HeaderText = "CUSTOMER"
        dgv2.Columns(2).HeaderText = "NPWP"
        dgv2.Columns(3).HeaderText = "TANGGAL"
        dgv2.Columns(4).HeaderText = "NO FAKTUR"
        dgv2.Columns(5).HeaderText = "DPP"
        dgv2.Columns(6).HeaderText = "PPN"
        dgv2.Columns(7).HeaderText = "PPH 23"
        dgv2.Columns(8).HeaderText = "PPH23 ACTUAL"
        dgv2.Columns(9).HeaderText = "NO BUKPOT"
        dgv2.Columns(10).HeaderText = "TGL BUKPOT"
        dgv2.Columns(11).HeaderText = "MASA BUKPOT"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.RowHeadersWidth = 60
        dgv2.Columns(0).Visible = False
        dgv2.Columns(12).Visible = False
        dgv2.Columns(1).Width = 220
        dgv2.Columns(2).Width = 160
        dgv2.Columns(3).Width = 85
        dgv2.Columns(4).Width = 160
        dgv2.Columns(5).Width = 120
        dgv2.Columns(6).Width = 120
        dgv2.Columns(7).Width = 120
        dgv2.Columns(8).Width = 140
        dgv2.Columns(9).Width = 120
        dgv2.Columns(10).Width = 120
        dgv2.Columns(11).Width = 120
        dgv2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
        dgv2.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(10).DefaultCellStyle.Format = "dd-MMM-yy"
        dgv2.Columns(11).DefaultCellStyle.Format = "MMMM-yy"
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim selectedName As String = dgv1.Rows(e.RowIndex).Cells(1).Value.ToString()
        If String.IsNullOrEmpty(selectedName) Then Exit Sub

        If lbl_judul.Text = "INPUT BUKTI POTONG" Then
            ' Cek apakah dgv2 kosong
            If dgv2.Rows.Count = 0 Then
                ' Pindahkan baris ke dgv2 dan hapus dari dgv1
                PindahkanBaris(e.RowIndex)
            Else
                ' Periksa apakah ada nama yang berbeda di kolom CUSTOMER (kolom 1)
                Dim adaNamaBerbeda As Boolean = dgv2.Rows.Cast(Of DataGridViewRow)().
                    Any(Function(row) row.Cells(1).Value.ToString() <> selectedName)

                If adaNamaBerbeda Then
                    MessageBox.Show("Nama Customer berbeda tidak bisa digabung", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Jika nama cocok, pindahkan baris
                    PindahkanBaris(e.RowIndex)
                End If
            End If

            If dgv2.Rows.Count = 1 Then
                txt_nama_customer.Text = dgv2.Rows(0).Cells(1).Value
                Call cari_npwp()
                Dim formattedValue As String = Format(CDec(dgv2.Rows(0).Cells(7).Value), "#,##0.00")
                txt_pph23.Text = formattedValue
            Else
                Dim total As Decimal = 0
                For Each row As DataGridViewRow In dgv2.Rows
                    total += CDec(row.Cells(7).Value)
                Next
                Dim formattedValue As String = Format(CDec(total), "#,##0.00")
                txt_pph23.Text = formattedValue
            End If

        ElseIf lbl_judul.Text = "UBAH BUKTI POTONG" Then
            If dgv2.Rows.Count < 1 Then
                PindahkanBarisUbahHapus(e.RowIndex)

                txt_nama_customer.Text = dgv2.Rows(0).Cells(1).Value
                Call cari_npwp()
                Dim total As Decimal = 0
                For Each row As DataGridViewRow In dgv2.Rows
                    total += CDec(row.Cells(7).Value)
                Next
                Dim formattedValue As String = Format(CDec(total), "#,##0.00")
                txt_pph23.Text = formattedValue
                dtp_tgl_bukpot.Value = dgv2.Rows(0).Cells(10).Value
                dtp_masa_bukpot.Value = dgv2.Rows(0).Cells(11).Value
                txt_no_bukpot.Text = dgv2.Rows(0).Cells(9).Value
                Dim actual As String = Format(CDec(dgv2.Rows(0).Cells(8).Value), "#,##0.00")
                txt_pph23_actual.Text = actual
                txt_kode_gabung.Text = dgv2.Rows(0).Cells(12).Value
            Else
                MsgBox("Data Penjualan yang akan diubah Bukpot Sudah dipilih")
            End If
        ElseIf lbl_judul.Text = "HAPUS BUKTI POTONG" Then
            If dgv2.Rows.Count < 1 Then
                PindahkanBarisUbahHapus(e.RowIndex)

                txt_nama_customer.Text = dgv2.Rows(0).Cells(1).Value
                Call cari_npwp()
                Dim total As Decimal = 0
                For Each row As DataGridViewRow In dgv2.Rows
                    total += CDec(row.Cells(7).Value)
                Next
                Dim formattedValue As String = Format(CDec(total), "#,##0.00")
                txt_pph23.Text = formattedValue
                dtp_tgl_bukpot.Value = dgv2.Rows(0).Cells(10).Value
                dtp_masa_bukpot.Value = dgv2.Rows(0).Cells(11).Value
                txt_no_bukpot.Text = dgv2.Rows(0).Cells(9).Value
                Dim actual As String = Format(CDec(dgv2.Rows(0).Cells(8).Value), "#,##0.00")
                txt_pph23_actual.Text = actual
                txt_kode_gabung.Text = dgv2.Rows(0).Cells(12).Value
            Else
                MsgBox("Data Penjualan yang akan dihapus Bukpot Sudah dipilih")
            End If
        End If

    End Sub
    Private Sub cari_npwp()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT npwp from tbclient WHERE nama = '" & txt_nama_customer.Text & "' "
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        txt_npwp.Text = drx(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub PindahkanBaris(ByVal rowIndex As Integer)
        Dim rowToMove As DataGridViewRow = dgv1.Rows(rowIndex)
        Dim newRowIdx As Integer = dgv2.Rows.Add()
        ' Salin data dari dgv1 ke dgv2 (kolom sesuai struktur)
        dgv2.Rows(newRowIdx).Cells(0).Value = rowToMove.Cells(0).Value
        dgv2.Rows(newRowIdx).Cells(1).Value = rowToMove.Cells(1).Value
        dgv2.Rows(newRowIdx).Cells(2).Value = rowToMove.Cells(2).Value
        dgv2.Rows(newRowIdx).Cells(3).Value = rowToMove.Cells(3).Value
        dgv2.Rows(newRowIdx).Cells(4).Value = rowToMove.Cells(4).Value
        dgv2.Rows(newRowIdx).Cells(5).Value = rowToMove.Cells(5).Value
        dgv2.Rows(newRowIdx).Cells(6).Value = rowToMove.Cells(6).Value
        dgv2.Rows(newRowIdx).Cells(7).Value = rowToMove.Cells(7).Value
        dgv2.Rows(newRowIdx).Cells(8).Value = rowToMove.Cells(8).Value
        dgv2.Rows(newRowIdx).Cells(9).Value = rowToMove.Cells(9).Value
        dgv2.Rows(newRowIdx).Cells(10).Value = rowToMove.Cells(10).Value
        dgv2.Rows(newRowIdx).Cells(11).Value = rowToMove.Cells(11).Value
        dgv2.Rows(newRowIdx).Cells(12).Value = rowToMove.Cells(12).Value
        ' Hapus baris dari dgv1
        dgv1.Rows.RemoveAt(rowIndex)
    End Sub
    Private Sub PindahkanBarisUbahHapus(ByVal rowIndex As Integer)
        Dim rowToMove As DataGridViewRow = dgv1.Rows(rowIndex)
        Dim referenceValue As Object = rowToMove.Cells(12).Value ' Nilai yang akan dijadikan referensi
        ' Pindahkan semua baris dengan nilai yang sama di kolom index ke-12
        For i As Integer = dgv1.Rows.Count - 1 To 0 Step -1
            Dim currentValue As Object = dgv1.Rows(i).Cells(12).Value
            ' Periksa kesamaan nilai (perhatikan tipe datanya)
            If Not IsDBNull(currentValue) AndAlso currentValue.Equals(referenceValue) Then
                Dim newRowIdx As Integer = dgv2.Rows.Add()
                ' Salin data dari dgv1 ke dgv2 (kolom sesuai struktur)
                For colIndex As Integer = 0 To dgv1.Columns.Count - 1
                    dgv2.Rows(newRowIdx).Cells(colIndex).Value = dgv1.Rows(i).Cells(colIndex).Value
                Next
                ' Hapus baris dari dgv1
                dgv1.Rows.RemoveAt(i)
            End If
        Next

        Dim colToSort As DataGridViewColumn = dgv2.Columns(8)
        dgv2.Sort(colToSort, ListSortDirection.Descending)
    End Sub

    Private Sub dtp_masa_bukpot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_masa_bukpot.ValueChanged
        Call masa_bukpot()
    End Sub
    Private Sub txt_pph23_actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pph23_actual.KeyPress
        Dim txt As TextBox = DirectCast(sender, TextBox)
        ' Izinkan angka, koma, dan backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "," AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        ' Cek jika koma (",") dimasukkan
        If e.KeyChar = "," Then
            ' Tidak boleh ada lebih dari satu koma
            If txt.Text.Contains(",") Then
                e.Handled = True
                Return
            End If
            ' Tidak boleh koma diawal tanpa angka
            If txt.Text.Length = 0 Then
                e.Handled = True
                Return
            End If
        End If
    End Sub

    Private Sub txt_pph23_actual_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pph23_actual.LostFocus
        Dim nilai, pph23_awal As Decimal
        ' Periksa apakah teks kosong
        If String.IsNullOrWhiteSpace(txt_pph23_actual.Text) Then
            txt_pph23_actual.Text = "" ' Biarkan kosong tanpa notif
        ElseIf Decimal.TryParse(txt_pph23_actual.Text, nilai) Then
            ' Format angka jika input valid
            txt_pph23_actual.Text = nilai.ToString("#,##0.00")
        Else
            ' Tampilkan pesan peringatan jika input tidak valid
            MessageBox.Show("Input harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_pph23_actual.Focus() ' Kembalikan fokus ke textbox
            txt_pph23_actual.SelectAll() ' Pilih semua teks untuk memudahkan pengeditan
        End If

        Decimal.TryParse(txt_pph23.Text, pph23_awal)


    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            Dim pph23_actual, pph23_awal As Decimal
            Decimal.TryParse(txt_pph23.Text, pph23_awal)
            Decimal.TryParse(txt_pph23_actual.Text, pph23_actual)

            If btn_simpan.Text = "SIMPAN" Then
                If dgv2.Rows.Count = 0 Then
                    MsgBox("Pilih terlebih dahulu data penjualan yang akan diinput Bukpot")
                Else
                    If txt_no_bukpot.Text = "" Then
                        MsgBox("Isi terlebih dahulu No Bukpot")
                        txt_no_bukpot.Focus()
                    ElseIf txt_pph23_actual.Text = "" Then
                        MsgBox("Isi terlebih dahulu PPh 23 Actual")
                        txt_pph23_actual.Focus()
                    ElseIf pph23_awal > pph23_actual + 2 Or pph23_actual > pph23_awal + 2 Then
                        MsgBox("Nilai PPH 23 Actual tidak boleh selisih 2 Rupiah dengan PPH 23")
                        txt_pph23_actual.Focus()
                    Else
                        If dgv2.Rows.Count = 1 Then
                            Call simpan_bukpot()
                        Else
                            Call simpan_bukpot()
                            Call simpan_bukpot_gabung()
                        End If
                        MsgBox("Input Bukpot Berhasil Disimpan")
                        btn_refresh.PerformClick()
                        form_menu_utama.btn_hitung_bukpot.Visible = True
                        form_menu_utama.btn_hitung_bukpot.PerformClick()
                    End If
                End If
            ElseIf btn_simpan.Text = "UPDATE" Then
                If txt_no_bukpot.Text = "" Then
                    MsgBox("Isi terlebih dahulu No Bukpot")
                    txt_no_bukpot.Focus()
                ElseIf txt_pph23_actual.Text = "" Then
                    MsgBox("Isi terlebih dahulu PPh 23 Actual")
                    txt_pph23_actual.Focus()
                ElseIf pph23_awal > pph23_actual + 2 Or pph23_actual > pph23_awal + 2 Then
                    MsgBox("Nilai PPH 23 Actual tidak boleh selisih 2 Rupiah dengan PPH 23")
                    txt_pph23_actual.Focus()
                ElseIf dtp_tgl_bukpot.Value = dgv2.Rows(0).Cells(10).Value _
                    And dtp_masa_bukpot.Value = dgv2.Rows(0).Cells(11).Value _
                    And txt_no_bukpot.Text = dgv2.Rows(0).Cells(9).Value _
                    And txt_pph23_actual.Text = dgv2.Rows(0).Cells(8).Value Then
                    MsgBox("Data belum ada yang diubah")
                Else
                    If MsgBox("Yakin DATA BUKPOT Akan Diubah ?", vbYesNo + vbQuestion, "Update Data") = vbYes Then
                        If dgv2.Rows.Count = 1 Then
                            Call ubah_bukpot()
                        Else
                            Call ubah_bukpot()
                            Call ubah_bukpot_gabung()
                        End If
                        MsgBox("Data Bukpot Berhasil Diubah")
                        btn_refresh.PerformClick()
                    End If
                End If
            ElseIf btn_simpan.Text = "HAPUS" Then
                If dgv2.Rows.Count = 0 Then
                    MsgBox("Pilih terlebih dahulu data penjualan yang akan dihapus Bukpot")
                Else
                    If MsgBox("Yakin DATA BUKPOT Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                        If dgv2.Rows.Count = 1 Then
                            Call hapus_bukpot()
                        Else
                            Call hapus_bukpot()
                            Call hapus_bukpot_gabung()
                        End If
                        MsgBox("Data Bukpot Berhasil Dihapus")
                        btn_refresh.PerformClick()
                        form_menu_utama.btn_hitung_bukpot.Visible = True
                        form_menu_utama.btn_hitung_bukpot.PerformClick()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub simpan_bukpot()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan  SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5, gabung_bukpot=@6 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                    dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id_jual", dgv2.Rows(0).Cells(0).Value)
                    .Parameters.AddWithValue("@1", txt_npwp.Text)
                    .Parameters.AddWithValue("@2", txt_no_bukpot.Text)
                    .Parameters.AddWithValue("@3", txt_pph23_actual.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@4", dtp_tgl_bukpot.Value)
                    .Parameters.AddWithValue("@5", dtp_masa_bukpot.Value)
                    .Parameters.AddWithValue("@6", txt_kode_gabung.Text)
                    .ExecuteNonQuery()
                    dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                    dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_bukpot_gabung()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5, gabung_bukpot=@6 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                For i As Integer = 1 To dgv2.Rows.Count - 1
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@id_jual", dgv2.Rows(i).Cells(0).Value)
                        .Parameters.AddWithValue("@1", txt_npwp.Text)
                        .Parameters.AddWithValue("@2", txt_no_bukpot.Text)
                        .Parameters.AddWithValue("@3", 0)
                        .Parameters.AddWithValue("@4", dtp_tgl_bukpot.Value)
                        .Parameters.AddWithValue("@5", dtp_masa_bukpot.Value)
                        .Parameters.AddWithValue("@6", txt_kode_gabung.Text)
                        .ExecuteNonQuery()
                    End With
                Next
                dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
            End Using
        End Using
    End Sub
    Private Sub ubah_bukpot()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan  SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                    dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id_jual", dgv2.Rows(0).Cells(0).Value)
                    .Parameters.AddWithValue("@1", txt_npwp.Text)
                    .Parameters.AddWithValue("@2", txt_no_bukpot.Text)
                    .Parameters.AddWithValue("@3", txt_pph23_actual.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@4", dtp_tgl_bukpot.Value)
                    .Parameters.AddWithValue("@5", dtp_masa_bukpot.Value)
                    .ExecuteNonQuery()
                    dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                    dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub ubah_bukpot_gabung()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                For i As Integer = 1 To dgv2.Rows.Count - 1
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@id_jual", dgv2.Rows(i).Cells(0).Value)
                        .Parameters.AddWithValue("@1", txt_npwp.Text)
                        .Parameters.AddWithValue("@2", txt_no_bukpot.Text)
                        .Parameters.AddWithValue("@3", 0)
                        .Parameters.AddWithValue("@4", dtp_tgl_bukpot.Value)
                        .Parameters.AddWithValue("@5", dtp_masa_bukpot.Value)
                        .ExecuteNonQuery()
                    End With
                Next
                dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
            End Using
        End Using
    End Sub
    Private Sub hapus_bukpot()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan  SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5, gabung_bukpot=@6 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                    dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@id_jual", dgv2.Rows(0).Cells(0).Value)
                    .Parameters.AddWithValue("@1", "")
                    .Parameters.AddWithValue("@2", "")
                    .Parameters.AddWithValue("@3", 0)
                    .Parameters.AddWithValue("@4", DBNull.Value)
                    .Parameters.AddWithValue("@5", DBNull.Value)
                    .Parameters.AddWithValue("@6", "")
                    .ExecuteNonQuery()
                    dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                    dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub hapus_bukpot_gabung()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbpenjualan SET npwp=@1, no_bukpot=@2, pph23_actual=@3, tgl_bukpot=@4, masa_bukpot=@5, gabung_bukpot=@6 WHERE id_jual = @id_jual"
            Using cmdy As New MySqlCommand(sqly, cony)
                dtp_tgl_bukpot.CustomFormat = "yyyy/MM/dd"
                dtp_masa_bukpot.CustomFormat = "yyyy/MM/dd"
                For i As Integer = 1 To dgv2.Rows.Count - 1
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@id_jual", dgv2.Rows(i).Cells(0).Value)
                        .Parameters.AddWithValue("@1", "")
                        .Parameters.AddWithValue("@2", "")
                        .Parameters.AddWithValue("@3", 0)
                        .Parameters.AddWithValue("@4", DBNull.Value)
                        .Parameters.AddWithValue("@5", DBNull.Value)
                        .Parameters.AddWithValue("@6", "")
                        .ExecuteNonQuery()
                    End With
                Next
                dtp_tgl_bukpot.CustomFormat = "dd/MM/yyyy"
                dtp_masa_bukpot.CustomFormat = "dd/MM/yyyy"
            End Using
        End Using
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        If lbl_judul.Text = "INPUT BUKTI POTONG" Then
            Call tampil_belum_bukpot()
            Call InitializeDgv2()
            Call generate_kode_gabung()
            Call bersih()
        ElseIf lbl_judul.Text = "UBAH BUKTI POTONG" Then
            lbl_judul.Text = "UBAH BUKTI POTONG"
            lbl_dgv1.Text = "List Penjualan sudah bukpot tahun"
            lbl_dgv2.Text = "List Penjualan akan ubah Bukpot"
            btn_simpan.Text = "UPDATE"
            txt_no_bukpot.ReadOnly = False
            txt_pph23_actual.ReadOnly = False
            dtp_tahun_bukpot.Visible = True
            dtp_tahun_bukpot.Value = Today
            Call tampil_sudah_bukpot()
            Call InitializeDgv2_ubah_hapus()
            Call bersih()
        ElseIf lbl_judul.Text = "HAPUS BUKTI POTONG" Then
            lbl_judul.Text = "HAPUS BUKTI POTONG"
            lbl_dgv1.Text = "List Penjualan sudah bukpot tahun"
            lbl_dgv2.Text = "List Penjualan akan hapus Bukpot"
            btn_simpan.Text = "HAPUS"
            txt_no_bukpot.ReadOnly = True
            txt_pph23_actual.ReadOnly = True
            dtp_tahun_bukpot.Visible = True
            Call tampil_sudah_bukpot()
            Call InitializeDgv2_ubah_hapus()
            Call bersih()
        End If
    End Sub
    Private Sub INPUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INPUTToolStripMenuItem.Click
        If lbl_judul.Text <> "INPUT BUKTI POTONG" Then
            lbl_judul.Text = "INPUT BUKTI POTONG"
            lbl_dgv1.Text = "List Penjualan Belum bukpot"
            lbl_dgv2.Text = "List Penjualan akan input Bukpot"
            btn_simpan.Text = "SIMPAN"
            txt_no_bukpot.ReadOnly = False
            txt_pph23_actual.ReadOnly = False
            dtp_tahun_bukpot.Visible = False
            Call tampil_belum_bukpot()
            Call InitializeDgv2()
            Call generate_kode_gabung()
            Call bersih()
        End If
    End Sub
    Private Sub UBAHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UBAHToolStripMenuItem.Click
        If lbl_judul.Text <> "UBAH BUKTI POTONG" Then
            lbl_judul.Text = "UBAH BUKTI POTONG"
            lbl_dgv1.Text = "List Penjualan sudah bukpot tahun"
            lbl_dgv2.Text = "List Penjualan akan ubah Bukpot"
            btn_simpan.Text = "UPDATE"
            txt_no_bukpot.ReadOnly = False
            txt_pph23_actual.ReadOnly = False
            dtp_tahun_bukpot.Visible = True
            dtp_tahun_bukpot.Value = Today
            Call tampil_sudah_bukpot()
            Call InitializeDgv2_ubah_hapus()
            Call bersih()
        End If
    End Sub
    Private Sub HAPUSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HAPUSToolStripMenuItem.Click
        If lbl_judul.Text <> "HAPUS BUKTI POTONG" Then
            lbl_judul.Text = "HAPUS BUKTI POTONG"
            lbl_dgv1.Text = "List Penjualan sudah bukpot tahun"
            lbl_dgv2.Text = "List Penjualan akan hapus Bukpot"
            btn_simpan.Text = "HAPUS"
            txt_no_bukpot.ReadOnly = True
            txt_pph23_actual.ReadOnly = True
            dtp_tahun_bukpot.Visible = True
            Call tampil_sudah_bukpot()
            Call InitializeDgv2_ubah_hapus()
            Call bersih()
        End If
    End Sub
    Private Sub dtp_tahun_bukpot_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tahun_bukpot.ValueChanged
        Call tampil_sudah_bukpot()
        Call InitializeDgv2_ubah_hapus()
        Call bersih()
    End Sub
    Private Sub bersih()
        txt_nama_customer.Text = ""
        txt_npwp.Text = ""
        txt_pph23.Text = ""
        txt_pph23_actual.Text = ""
        txt_no_bukpot.Text = ""
    End Sub

    Private Sub EKSPORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EKSPORToolStripMenuItem.Click
        form_export_bukpot.Show()
        form_export_bukpot.Focus()
    End Sub
End Class