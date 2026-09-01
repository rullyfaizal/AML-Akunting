Imports MySql.Data.MySqlClient

Public Class form_retur

    Dim ppn As Double
    Private Sub isi_ppn()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT ppn from tbppn WHERE id ='ppn'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        ppn = drx(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub form_retur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        Call buatkode()
    End Sub
    Private Sub buatkode()
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
    End Sub

    Private Sub btn_batal_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_retur.Click
        Me.Close()
    End Sub

    Private Sub isidgvpembelian()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbpembelian WHERE kode = '" & txt_kode_induk.Text & "' ORDER BY baris ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                            Call atur_dgv1()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv1()
        dgv1.Columns(1).HeaderText = "TGL BELI"
        dgv1.Columns(2).HeaderText = "NO FAKTUR"
        dgv1.Columns(3).HeaderText = "SUPPLIER"
        dgv1.Columns(5).HeaderText = "NAMA GREY"
        dgv1.Columns(6).HeaderText = "QUANTITY"
        dgv1.Columns(7).HeaderText = "DPP GREY"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(1).Width = 90
        dgv1.Columns(2).Width = 150
        dgv1.Columns(3).Width = 150
        dgv1.Columns(5).Width = 110
        dgv1.Columns(6).Width = 100
        dgv1.Columns(7).Width = 100
        dgv1.Columns(0).Visible = False
        dgv1.Columns(4).Visible = False
        dgv1.Columns(8).Visible = False
        For i As Integer = 9 To 16
            dgv1.Columns(i).Visible = False
        Next
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub isidgvgrey()
        Try
            dgv2.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE kode = '" & txt_kode_induk.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv2.DataSource = dsx.Tables("tbpembelian")
                            Call atur_dgv2()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv2()
        dgv2.Columns(2).HeaderText = "TGL BELI"
        dgv2.Columns(3).HeaderText = "NO FAKTUR"
        dgv2.Columns(4).HeaderText = "SUPPLIER"
        dgv2.Columns(5).HeaderText = "NAMA GREY"
        dgv2.Columns(9).HeaderText = "STOK TERSEDIA"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.Columns(2).Width = 90
        dgv2.Columns(3).Width = 150
        dgv2.Columns(4).Width = 150
        dgv2.Columns(5).Width = 110
        dgv2.Columns(9).Width = 140
        dgv2.Columns(0).Visible = False
        dgv2.Columns(1).Visible = False
        dgv2.Columns(6).Visible = False
        dgv2.Columns(7).Visible = False
        dgv2.Columns(8).Visible = False
        For i As Integer = 10 To 17
            dgv2.Columns(i).Visible = False
        Next
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub txt_kode_induk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kode_induk.TextChanged
        Call isidgvpembelian()
        Call isidgvgrey()
        If dgv2.RowCount = 0 Then
            MsgBox("Silahkah Input Harga Greynya terlebih dahulu agar Grey masuk ke Stok")
            Me.Close()
        Else
            Dim total As Decimal = 0
            For Each row As DataGridViewRow In dgv2.Rows
                ' Pastikan baris bukan baris baru (new row)
                If Not row.IsNewRow Then
                    ' Cek apakah nilai di kolom ke-10 tidak kosong dan valid
                    If Not IsDBNull(row.Cells(9).Value) AndAlso row.Cells(9).Value IsNot Nothing Then
                        Dim nilai As Decimal
                        If Decimal.TryParse(row.Cells(9).Value.ToString(), nilai) Then
                            total += nilai
                        End If
                    End If
                End If
            Next
            If total <= 0 Then
                MsgBox("Grey yang dipilih sudah terpakai semua")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub dgv2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv2.CellMouseClick
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di tampilkan")
            Else
                txt_id_grey_retur.Text = dgv2.CurrentRow.Cells(0).Value.ToString()
                txt_nama_grey_retur.Text = dgv2.CurrentRow.Cells(5).Value.ToString()
                txt_jumlah_asal.Text = dgv2.CurrentRow.Cells(9).Value.ToString()
                txt_dpp_asal.Text = dgv2.CurrentRow.Cells(10).Value.ToString()
                txt_kode_grey.Text = dgv2.CurrentRow.Cells(16).Value.ToString()
                txt_kode_neraca.Text = dgv2.CurrentRow.Cells(17).Value.ToString()
                txt_jumlah_retur.Text = ""
                txt_dpp_retur.Text = ""
                txt_ppn_retur.Text = ""
                txt_total_retur.Text = ""
                btn_simpan_retur.Enabled = False
                txt_jumlah_retur.ReadOnly = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_hitung_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung_retur.Click
        Dim angka1 As Decimal
        Dim angka2 As Decimal
        If txt_nama_grey_retur.Text = "" Then
            MsgBox("Pilih terlebih dahulu GREY yang akan di RETUR")
            txt_jumlah_retur.Focus()
        ElseIf txt_jumlah_retur.Text = "" Or txt_jumlah_retur.Text = "0" Then
            MsgBox("Jumlah GREY yang akan di RETUR belum diinput")
            txt_jumlah_retur.Focus()
        ElseIf Decimal.TryParse(txt_jumlah_retur.Text, Globalization.NumberStyles.Any, Globalization.CultureInfo.CurrentCulture, angka1) _
            AndAlso Decimal.TryParse(txt_jumlah_asal.Text, Globalization.NumberStyles.Any, Globalization.CultureInfo.CurrentCulture, angka2) Then
            If angka1 > angka2 Then
                MessageBox.Show("Jumlah RETUR GREY tidak boleh melebihi stok yang ada")
                txt_jumlah_retur.Focus()
            Else
                Dim jumlah, harga, total_dpp, total_ppn, grand_total As Double
                jumlah = txt_jumlah_retur.Text.Replace(".", "")
                harga = txt_dpp_asal.Text.Replace(".", "")
                total_dpp = jumlah * harga
                txt_dpp_retur.Text = total_dpp.ToString("#,##0.00########")
                total_ppn = total_dpp * (ppn / 100)
                txt_ppn_retur.Text = total_ppn.ToString("#,##0.00########")
                grand_total = total_dpp + total_ppn
                txt_total_retur.Text = grand_total.ToString("#,##0.00########")
                btn_simpan_retur.Enabled = True
                txt_jumlah_retur.ReadOnly = True

            End If
        End If

    End Sub

    Private Sub txt_jumlah_retur_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_jumlah_retur.LostFocus
        If txt_jumlah_retur.Text <> "" Then
            Dim input As String = txt_jumlah_retur.Text
            Dim number As Decimal
            If Decimal.TryParse(input, number) Then
                txt_jumlah_retur.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Jumlah GREY harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah_retur.SelectAll()
                txt_jumlah_retur.Focus()
            End If
        End If
    End Sub

    Private Sub btn_simpan_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan_retur.Click
        Call buatkode()
        Call simpanretur()
        Call updategrey()
        Call simpanhistorygrey()
        Call updateneracagrey()
        MsgBox("RETUR Pembelian Berhasil Disimpan")
        Me.Close()
        form_pembelian.btn_cari.PerformClick()
    End Sub
    Private Sub simpanretur()
        Dim dpp As String = txt_dpp_retur.Text
        Dim ppn_retur As String = txt_ppn_retur.Text
        Dim total As String = txt_total_retur.Text
        Dim dpp_satuan As String = txt_dpp_asal.Text
        Dim jumlah As String = txt_jumlah_retur.Text
        Dim dpp_d, ppn_retur_d, total_d, dpp_satuan_d, jumlah_d As Decimal
        Decimal.TryParse(dpp, dpp_d)
        Decimal.TryParse(ppn_retur, ppn_retur_d)
        Decimal.TryParse(total, total_d)
        Decimal.TryParse(dpp_satuan, dpp_satuan_d)
        Decimal.TryParse(jumlah, jumlah_d)
        dpp_d = dpp_d * -1
        ppn_retur_d = ppn_retur_d * -1
        total_d = total_d * -1
        dpp_satuan_d = dpp_satuan_d * -1
        dtp_tanggal_retur.CustomFormat = "yyyy/MM/dd"

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal_retur.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur_retur.Text)
                    .Parameters.AddWithValue("@3", txt_supplier_retur.Text)
                    .Parameters.AddWithValue("@4", "RETUR")
                    .Parameters.AddWithValue("@5", txt_nama_grey_retur.Text)
                    .Parameters.AddWithValue("@6", jumlah_d)
                    .Parameters.AddWithValue("@7", dpp_satuan_d)
                    .Parameters.AddWithValue("@8", dpp_d)
                    .Parameters.AddWithValue("@9", ppn_retur_d)
                    .Parameters.AddWithValue("@10", total_d)
                    .Parameters.AddWithValue("@11", "")
                    If dtp_tanggal_retur.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_retur.Text)
                    End If
                    .Parameters.AddWithValue("@13", "ppn")
                    .Parameters.AddWithValue("@14", 1)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbindukpembelian (kode,tanggal,no_faktur,supplier,jenis_biaya,total_dpp,total_ppn,total_pembelian,pembayaran,tanggal_upload,total_polos) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@0", Txt_kode.Text)
                    .Parameters.AddWithValue("@1", dtp_tanggal_retur.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur_retur.Text)
                    .Parameters.AddWithValue("@3", txt_supplier_retur.Text)
                    .Parameters.AddWithValue("@4", "RETUR")
                    .Parameters.AddWithValue("@5", dpp_d)
                    .Parameters.AddWithValue("@6", ppn_retur_d)
                    .Parameters.AddWithValue("@7", total_d)
                    .Parameters.AddWithValue("@8", "")
                    If dtp_tanggal_retur.Text = "" Then
                        .Parameters.AddWithValue("@9", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@9", dtp_tanggal_retur.Text)
                    End If
                    .Parameters.AddWithValue("@10", "")
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
        dtp_tanggal_retur.CustomFormat = "dd/MM/yyyy"


    End Sub
    Private Sub updategrey()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbgrey WHERE id_grey = '" & txt_id_grey_retur.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                Using reader As MySqlDataReader = cmdy.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            stok_keluar = Convert.ToDecimal(reader("stok_keluar"))
                            stok_akhir = Convert.ToDecimal(reader("stok_akhir"))
                            harga_jual = Convert.ToDecimal(reader("harga_jual"))
                        End While
                    End If
                End Using
            End Using
        End Using
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_jumlah_retur.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE id_grey = '" & txt_id_grey_retur.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", stok_keluar)
                    .Parameters.AddWithValue("@2", stok_akhir)
                    .Parameters.AddWithValue("@3", dpp_jual)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    End Sub
    Private Sub simpanhistorygrey()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga," &
                "harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca,kode_jual) " &
                "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal_retur.CustomFormat = "yyyy/MM/dd"
                    'dtp_tanggal_beli1.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_id_grey_retur.Text)
                    .Parameters.AddWithValue("@2", dtp_tanggal_retur.Text)
                    .Parameters.AddWithValue("@3", txt_no_faktur_retur.Text)
                    .Parameters.AddWithValue("@4", txt_supplier_retur.Text)
                    .Parameters.AddWithValue("@5", txt_nama_grey_retur.Text)
                    .Parameters.AddWithValue("@6", 0)
                    .Parameters.AddWithValue("@7", 0)
                    .Parameters.AddWithValue("@8", txt_jumlah_retur.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", 0)
                    .Parameters.AddWithValue("@10", txt_dpp_asal.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", 0)
                    .Parameters.AddWithValue("@12", 0)
                    .Parameters.AddWithValue("@13", txt_dpp_retur.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@14", "")
                    .Parameters.AddWithValue("@15", txt_kode_induk.Text)
                    .Parameters.AddWithValue("@16", txt_kode_grey.Text)
                    .Parameters.AddWithValue("@17", txt_kode_neraca.Text)
                    .Parameters.AddWithValue("@18", "")
                    .ExecuteNonQuery()
                    dtp_tanggal_retur.CustomFormat = "dd/MM/yyyy"
                    'dtp_tanggal_beli1.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub updateneracagrey()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbneracagrey WHERE kode_neraca = '" & txt_kode_neraca.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                Using reader As MySqlDataReader = cmdy.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            stok_keluar = Convert.ToDecimal(reader("stok_keluar"))
                            stok_akhir = Convert.ToDecimal(reader("stok_akhir"))
                            harga_jual = Convert.ToDecimal(reader("harga_jual"))
                        End While
                    End If
                End Using
            End Using
        End Using
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_jumlah_retur.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE kode_neraca = '" & txt_kode_neraca.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", stok_keluar)
                    .Parameters.AddWithValue("@2", stok_akhir)
                    .Parameters.AddWithValue("@3", dpp_jual)
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    End Sub
End Class