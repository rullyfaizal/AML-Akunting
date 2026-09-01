Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO

Public Class form_laporan_keuangan

    Dim pendapatan As Decimal = 0
    Dim hargapokokpenjualan As Decimal = 0

    Private Sub form_laporan_keuangan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
    End Sub

    Dim ppn, pph23, pph22 As Double
    Private Sub isi_ppn()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT ppn,pph23,pph22 from tbppn WHERE id ='ppn'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        ppn = drx(0)
                        pph23 = drx(1)
                        pph22 = drx(2)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub btn_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        Try
            Me.Enabled = False
            If btn_generate.Text = "GENERATE" Then
                btn_generate.Text = "EKSPOR"
                btn_reset.Enabled = True

                Call load_sheet_hpp()

                Call load_sheet_biaya_baru()

                Call load_sheet_masukan()
                Call load_list_masukan_kain()
                Call load_list_masukan_obat()
                Call load_list_masukan_batubara()
                Call load_list_masukan_lain2()
                Call gabung_dgv_masukan()

                Call load_sheet_keluaran()
                Call load_list_dpp_celup()
                Call load_list_dpp_kain()
                Call load_list_dpp_total()
                Call gabung_dgv_keluaran()
                Call load_list_kg()
                Call load_list_mtr()
                Call load_list_yard()
                Call gabung_dgv_keluaran_satuan()

                Call load_sheet_lapkeu()

                Call tampil_spt()
                Call LoadDataPLN()
                Call tampil_data_bukpot()

                Call tampil_induk_penyusutan()
                Call tampil_data_penyusutan()

                dtp_tahun.Enabled = False
            Else
                Dim txtdate, txttahun As New TextBox
                Dim dtptoday As New DateTimePicker
                dtptoday.Value = DateTime.Now
                txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
                txttahun.Text = dtp_tahun.Value.ToString("yyyy")
                Export("D:\Ekspor\Laporan Keuangan Tahun " & txttahun.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")

            End If
            Me.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim nilai_saldo_awal As Decimal = 0
    Dim nilai_saldo_akhir As Decimal = 0
    Private Sub load_sheet_hpp()
        lbl_hpp_tahun.Text = "1 JANUARI - 31 DESEMBER " & dtp_tahun.Text
        dgv_hpp.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        If dgv_hpp.ColumnCount = 0 Then
            dgv_hpp.Columns.Add("kategori", "")
            dgv_hpp.Columns.Add("kain", "KAIN GREY")
            dgv_hpp.Columns.Add("obat", "OBAT")
            dgv_hpp.Columns.Add("kosong", "")
            dgv_hpp.Columns.Add("jumlah", "JUMLAH")
        End If
        dgv_hpp.Rows.Add("", "KAIN GREY", "OBAT", "", "JUMLAH") '0
        dgv_hpp.Rows.Add("PEMAKAIAN BAHAN", "", "", "", "") '1

        '2
        Dim awal_tahun_obat As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT awal_tahun_obat FROM tblaphpp WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("awal_tahun_obat")) Then
                            awal_tahun_obat = reader.GetDecimal("awal_tahun_obat")
                        End If
                    End If
                End Using
            End Using
        End Using
        Call saldo_awal()
        dgv_hpp.Rows.Add("SALDO AWAL TAHUN " & tahun, nilai_saldo_awal, awal_tahun_obat, "", nilai_saldo_awal + awal_tahun_obat)

        '3
        Dim jenisBiaya As String() = {"GREY", "OBAT"}
        Dim total_biaya As New Dictionary(Of String, Decimal) From {
            {"GREY", 0},
            {"OBAT", 0}
        }
        Dim query3 As String = "SELECT jenis_biaya, " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya IN (@jenisBiaya1, @jenisBiaya2) " &
            "AND YEAR(tanggal) = @tahun " &
            "GROUP BY jenis_biaya;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query3, conx)
                cmd.Parameters.AddWithValue("@jenisBiaya1", jenisBiaya(0))
                cmd.Parameters.AddWithValue("@jenisBiaya2", jenisBiaya(1))
                cmd.Parameters.AddWithValue("@tahun", tahun)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim jenis As String = reader.GetString("jenis_biaya")
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0)
                        total_biaya(jenis) = total_dpp + total_polos
                    End While
                End Using
            End Using
        End Using
        Dim total_biaya_GREY As Decimal = total_biaya("GREY")
        Dim total_biaya_OBAT As Decimal = total_biaya("OBAT")
        dgv_hpp.Rows.Add("PEMBELIAN TAHUN " & tahun, total_biaya_GREY, total_biaya_OBAT, "", total_biaya_GREY + total_biaya_OBAT)

        '4
        dgv_hpp.Rows.Add("TERSEDIA", total_biaya_GREY + nilai_saldo_awal, awal_tahun_obat + total_biaya_OBAT, "", nilai_saldo_awal + awal_tahun_obat + total_biaya_GREY + total_biaya_OBAT)

        '5
        Dim akhir_tahun_obat As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT akhir_tahun_obat FROM tblaphpp WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("akhir_tahun_obat")) Then
                            akhir_tahun_obat = reader.GetDecimal("akhir_tahun_obat")
                        End If
                    End If
                End Using
            End Using
        End Using
        Call saldo_akhir()
        dgv_hpp.Rows.Add("SALDO AKHIR TAHUN " & tahun, nilai_saldo_akhir, akhir_tahun_obat, "", nilai_saldo_akhir + akhir_tahun_obat)

        '6
        Dim pemakaian_bahan As Decimal = 0
        pemakaian_bahan = (nilai_saldo_awal + awal_tahun_obat + total_biaya_GREY + total_biaya_OBAT) - nilai_saldo_akhir + akhir_tahun_obat
        dgv_hpp.Rows.Add("PEMAKAIAN BAHAN DALAM TAHUN " & tahun, (total_biaya_GREY + nilai_saldo_awal) - nilai_saldo_akhir, _
                         (awal_tahun_obat + total_biaya_OBAT) - akhir_tahun_obat, "", _
                         pemakaian_bahan)
        '7
        dgv_hpp.Rows.Add("", "", "", "", "")

        '8
        Dim upah_harian As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT upah_harian FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("upah_harian")) Then
                            upah_harian = reader.GetDecimal("upah_harian")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_hpp.Rows.Add("UPAH HARIAN", "", "", upah_harian, "")

        '9
        dgv_hpp.Rows.Add("JUMLAH BIAYA UPAH HARIAN", "", "", "", upah_harian)
        dgv_hpp.Rows(9).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight

        '10-13
        Dim jenisPenyusutan As String() = {"BANGUNAN", "INVENTARIS", "TANKI PENGOLAH LIMBAH", "MESIN"}
        Dim total_penyusutan As New Dictionary(Of String, Decimal) From {
            {"BANGUNAN", 0},
            {"INVENTARIS", 0},
            {"TANKI PENGOLAH LIMBAH", 0},
            {"MESIN", 0}
        }
        Dim query10 As String = "SELECT kategori_aset, SUM(nilai_penyusutan) AS total_penyusutan " &
                                "FROM tbdatapenyusutan " &
                                "WHERE kategori_aset IN (@jenis1, @jenis2, @jenis3, @jenis4) " &
                                "AND tahun = @tahun " &
                                "GROUP BY kategori_aset;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query10, conx)
                cmd.Parameters.AddWithValue("@jenis1", jenisPenyusutan(0))
                cmd.Parameters.AddWithValue("@jenis2", jenisPenyusutan(1))
                cmd.Parameters.AddWithValue("@jenis3", jenisPenyusutan(2))
                cmd.Parameters.AddWithValue("@jenis4", jenisPenyusutan(3))
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim jenis As String = reader.GetString("kategori_aset")
                        Dim total As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_penyusutan")), reader.GetDecimal("total_penyusutan"), 0)

                        ' Simpan ke dictionary
                        If total_penyusutan.ContainsKey(jenis) Then
                            total_penyusutan(jenis) = total
                        End If
                    End While
                End Using
            End Using
        End Using

        ' Menampilkan hasil
        Dim total_penyusutan_BANGUNAN As Decimal = total_penyusutan("BANGUNAN")
        Dim total_penyusutan_INVENTARIS As Decimal = total_penyusutan("INVENTARIS")
        Dim total_penyusutan_TANKI As Decimal = total_penyusutan("TANKI PENGOLAH LIMBAH")
        Dim total_penyusutan_MESIN As Decimal = total_penyusutan("MESIN")
        dgv_hpp.Rows.Add("BIAYA PENYUSUTAN BANGUNAN", "", "", total_penyusutan_BANGUNAN, "")
        dgv_hpp.Rows.Add("BIAYA PENYUSUTAN INVENTARIS PABRIK", "", "", total_penyusutan_INVENTARIS, "")
        dgv_hpp.Rows.Add("BIAYA PENYUSUTAN TANGKI PENGOLAH LIMBAH", "", "", total_penyusutan_TANKI, "")
        dgv_hpp.Rows.Add("BIAYA PENYUSUTAN MESIN", "", "", total_penyusutan_MESIN, "")

        '14
        Dim jumlah_biaya_penyusutan As Decimal = 0
        jumlah_biaya_penyusutan = total_penyusutan_BANGUNAN + total_penyusutan_INVENTARIS + total_penyusutan_TANKI + total_penyusutan_MESIN
        dgv_hpp.Rows.Add("JUMLAH BIAYA PENYUSUTAN", "", "", "", jumlah_biaya_penyusutan)
        dgv_hpp.Rows(14).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        '15,16
        dgv_hpp.Rows.Add("", "", "", "", "")
        dgv_hpp.Rows.Add("BIAYA LAIN2 PRODUKSI", "", "", "", "")

        '17-24
        Dim daftarProduksi() As String = {
             "BIAYA LISTRIK PABRIK", "BATUBARA", "BIAYA GARAM", "BIAYA PACKING",
             "BIAYA PEMAKAIAN SPAREPART MESIN", "BIAYA PENGOLAHAN LIMBAH",
             "BIAYA PENGUJIAN DAN LEGALITAS", "BIAYA MAINTENANCE MESIN"}
        Dim total_produksi As New Dictionary(Of String, Decimal) From {
            {"BIAYA LISTRIK PABRIK", 0},
            {"BATUBARA", 0},
            {"BIAYA GARAM", 0},
            {"BIAYA PACKING", 0},
            {"BIAYA PEMAKAIAN SPAREPART MESIN", 0},
            {"BIAYA PENGOLAHAN LIMBAH", 0},
            {"BIAYA PENGUJIAN DAN LEGALITAS", 0},
            {"BIAYA MAINTENANCE MESIN", 0}
        }
        Dim query17 As String = "SELECT jenis_biaya, " &
                   "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                   "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                   "FROM tbpembelian " &
                   "WHERE jenis_biaya IN (@produksi1, @produksi2, @produksi3, @produksi4, @produksi5, @produksi6, @produksi7, @produksi8) " &
                   "AND YEAR(tanggal) = @tahun " &
                   "GROUP BY jenis_biaya;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query17, conx)
                cmd.Parameters.AddWithValue("@produksi1", daftarProduksi(0))
                cmd.Parameters.AddWithValue("@produksi2", daftarProduksi(1))
                cmd.Parameters.AddWithValue("@produksi3", daftarProduksi(2))
                cmd.Parameters.AddWithValue("@produksi4", daftarProduksi(3))
                cmd.Parameters.AddWithValue("@produksi5", daftarProduksi(4))
                cmd.Parameters.AddWithValue("@produksi6", daftarProduksi(5))
                cmd.Parameters.AddWithValue("@produksi7", daftarProduksi(6))
                cmd.Parameters.AddWithValue("@produksi8", daftarProduksi(7))
                cmd.Parameters.AddWithValue("@tahun", tahun)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim produksi As String = reader.GetString("jenis_biaya")
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0)
                        total_produksi(produksi) = total_dpp + total_polos
                    End While
                End Using
            End Using
        End Using
        Dim total_produksi_listrik As Decimal = total_produksi("BIAYA LISTRIK PABRIK")
        Dim total_produksi_batubara As Decimal = total_produksi("BATUBARA")
        Dim total_produksi_garam As Decimal = total_produksi("BIAYA GARAM")
        Dim total_produksi_packing As Decimal = total_produksi("BIAYA PACKING")
        Dim total_produksi_sparepart As Decimal = total_produksi("BIAYA PEMAKAIAN SPAREPART MESIN")
        Dim total_produksi_limbah As Decimal = total_produksi("BIAYA PENGOLAHAN LIMBAH")
        Dim total_produksi_pengujian As Decimal = total_produksi("BIAYA PENGUJIAN DAN LEGALITAS")
        Dim total_produksi_maintenance As Decimal = total_produksi("BIAYA MAINTENANCE MESIN")
        dgv_hpp.Rows.Add("BIAYA LISTRIK PABRIK", "", "", total_produksi_listrik, "")
        dgv_hpp.Rows.Add("BIAYA BATUBARA", "", "", total_produksi_batubara, "")
        dgv_hpp.Rows.Add("BIAYA GARAM", "", "", total_produksi_garam, "")
        dgv_hpp.Rows.Add("BIAYA PACKING", "", "", total_produksi_packing, "")
        dgv_hpp.Rows.Add("BIAYA PEMAKAIAN SPAREPART MESIN", "", "", total_produksi_sparepart, "")
        dgv_hpp.Rows.Add("BIAYA PENGOLAHAN LIMBAH", "", "", total_produksi_limbah, "")
        dgv_hpp.Rows.Add("BIAYA PENGUJIAN DAN LEGALITAS", "", "", total_produksi_pengujian, "")
        dgv_hpp.Rows.Add("BIAYA MAINTENANCE MESIN", "", "", total_produksi_maintenance, "")

        '25
        Dim sewa_pabrik As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT sewa_pabrik FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_pabrik")) Then
                            sewa_pabrik = reader.GetDecimal("sewa_pabrik")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_hpp.Rows.Add("SEWA PABRIK", "", "", sewa_pabrik, "")

        '26
        Dim lain2_produksi As Decimal = 0
        lain2_produksi = total_produksi_listrik + total_produksi_batubara + total_produksi_garam _
                         + total_produksi_packing + total_produksi_sparepart + total_produksi_limbah + total_produksi_pengujian _
                         + total_produksi_maintenance + sewa_pabrik
        dgv_hpp.Rows.Add("JUMLAH BIAYA LAIN LAIN PRODUKSI", "", "", "", lain2_produksi)
        dgv_hpp.Rows(26).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_hpp.Rows.Add("", "", "", "", "") '27

        '28
        dgv_hpp.Rows.Add("BIAYA SEHUBUNGAN PROSES PRODUKSI", "", "", "", pemakaian_bahan + upah_harian + jumlah_biaya_penyusutan + lain2_produksi)
        dgv_hpp.Rows.Add("", "", "", "", "") '29

        '30-36
        Dim awal_proses As Decimal = 0
        Dim akhir_proses As Decimal = 0
        Dim awal_warna As Decimal = 0
        Dim akhir_warna As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT awal_kain_proses, akhir_kain_proses, awal_kain_warna, akhir_kain_warna FROM tblaphpp WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        awal_proses = reader.GetDecimal("awal_kain_proses")
                        akhir_proses = reader.GetDecimal("akhir_kain_proses")
                        awal_warna = reader.GetDecimal("awal_kain_warna")
                        akhir_warna = reader.GetDecimal("akhir_kain_warna")
                    End If
                End Using
            End Using
        End Using
        Dim hpp As Decimal = 0
        hpp = (pemakaian_bahan + upah_harian + jumlah_biaya_penyusutan + lain2_produksi) - awal_proses + akhir_proses
        dgv_hpp.Rows.Add("SALDO AWAL KAIN DALAM PROSES TAHUN " & tahun, "", "", "", awal_proses)
        dgv_hpp.Rows.Add("SALDO AKHIR KAIN DALAM PROSES TAHUN " & tahun, "", "", "", akhir_proses)
        dgv_hpp.Rows.Add("HARGA POKOK PRODUKSI", "", "", "", hpp)
        dgv_hpp.Rows(32).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_hpp.Rows.Add("", "", "", "", "")
        Dim hpp2 As Decimal = Math.Floor(hpp - awal_warna + akhir_warna)
        dgv_hpp.Rows.Add("SALDO AWAL KAIN WARNA TAHUN " & tahun, "", "", "", awal_warna)
        dgv_hpp.Rows.Add("SALDO AKHIR KAIN WARNA TAHUN " & tahun, "", "", "", akhir_warna)
        dgv_hpp.Rows.Add("HARGA POKOK PENJUALAN", "", "", "", hpp2)
        dgv_hpp.Rows(36).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight

        '----
        dgv_hpp.Rows(0).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_hpp.Rows(0).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_hpp.Rows(0).Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgv_hpp.ColumnHeadersVisible = False
        dgv_hpp.Columns(0).Width = 300
        For i = 1 To 4
            dgv_hpp.Columns(i).Width = 150
        Next
        For h = 1 To 4
            dgv_hpp.Columns(h).DefaultCellStyle.Format = "#,##0.00"
            dgv_hpp.Columns(h).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        hargapokokpenjualan = hpp2

        'dgv_hpp.Rows(36).Cells(4).Style.Format = "#,##0"
    End Sub
    Private Sub saldo_awal()
        'fungsi mencari saldo
        Dim selectedDate As DateTime = dtp_tahun.Value
        Dim bulanDipilih As Integer = 12
        Dim tahunDipilih As Integer = dtp_tahun.Value.Year
        Dim tanggalTerakhirBulanSebelumnya As DateTime = New DateTime(tahunDipilih - 1, bulanDipilih, 1).AddDays(-1)
        dtp_awal.Value = tanggalTerakhirBulanSebelumnya
        dtp_akhir.Value = dtp_awal.Value.AddYears(-3)
        dtp_akhir.Value = dtp_akhir.Value.AddDays(+1)
        dtp_awal.CustomFormat = "yyyy/MM/dd"
        dtp_akhir.CustomFormat = "yyyy/MM/dd"

        dgv_saldo1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                 "SUM(stok_masuk) - SUM(stok_keluar) AS stok_awal, " &
                 "harga, harga_jual " &
                 "FROM tbhistorygrey " &
                 "WHERE tanggal BETWEEN @dtp_akhir AND @dtp_awal " &
                 "GROUP BY nama_specs;"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp_awal", dtp_awal.Value)
                cmdx.Parameters.AddWithValue("@dtp_akhir", dtp_akhir.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv_saldo1.DataSource = dsx.Tables("tbhistorygrey")
                    End Using
                End Using
            End Using
        End Using
        dgv_saldo2.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                "harga, harga_jual " &
                "FROM tbhistorygrey " &
                "WHERE MONTH(tanggal) = 12 AND YEAR(tanggal) = YEAR(@dtp) - 1 " &
                "GROUP BY nama_specs;"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp", dtp_tahun.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv_saldo2.DataSource = dsx.Tables("tbhistorygrey")
                    End Using
                End Using
            End Using
        End Using

        dgv_saldo3.Columns.Clear()
        dgv_saldo3.Rows.Clear()

        ' Menambahkan kolom-kolom ke dgv_saldo3
        dgv_saldo3.Columns.Add("nama_specs", "Nama Specs")
        dgv_saldo3.Columns.Add("harga_jual_ppn", "Harga Jual PPN")
        dgv_saldo3.Columns.Add("stok_awal", "Stok Awal")
        dgv_saldo3.Columns.Add("total_stok_masuk", "Total Stok Masuk")
        dgv_saldo3.Columns.Add("total_stok_keluar", "Total Stok Keluar")
        dgv_saldo3.Columns.Add("stok_akhir", "Stok Akhir")
        dgv_saldo3.Columns.Add("harga", "Harga")
        dgv_saldo3.Columns.Add("harga_jual", "Harga Jual")
        dgv_saldo3.Columns.Add("dpp_beli_akhir", "DPP Beli Akhir")
        dgv_saldo3.Columns.Add("dpp_jual_akhir", "DPP Jual Akhir")

        ' Mengatur tipe data untuk kolom desimal
        dgv_saldo3.Columns("harga_jual_ppn").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("stok_awal").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("total_stok_masuk").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("total_stok_keluar").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("stok_akhir").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("harga").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("harga_jual").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("dpp_beli_akhir").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("dpp_jual_akhir").ValueType = GetType(Decimal)

        ' Membuat dictionary untuk menyimpan data sementara
        Dim combinedData As New Dictionary(Of String, DataGridViewRow)

        ' Mengisi data dari dgv1 (stok bulan sebelumnya)
        For Each row As DataGridViewRow In dgv_saldo1.Rows
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
                    ' Tambahkan baris baru ke dgv_saldo3 dengan stok_awal, total_stok_masuk, dan total_stok_keluar sementara 0
                    Dim index As Integer = dgv_saldo3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, 0D, 0D, stokAwal, harga, hargaJual, 0D, 0D)
                    combinedData(key) = dgv_saldo3.Rows(index)
                End If
            End If
        Next

        ' Mengisi data dari dgv2 (stok bulan berjalan)
        For Each row As DataGridViewRow In dgv_saldo2.Rows
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
                    ' Update data di dgv_saldo3 untuk kolom total_stok_masuk dan total_stok_keluar dari dgv2 saja
                    Dim dgvRow As DataGridViewRow = combinedData(key)
                    dgvRow.Cells("total_stok_masuk").Value = totalStokMasuk
                    dgvRow.Cells("total_stok_keluar").Value = totalStokKeluar

                    ' Update harga dan harga_jual dari dgv2
                    dgvRow.Cells("harga").Value = harga
                    dgvRow.Cells("harga_jual").Value = hargaJual

                    ' Hitung stok_akhir berdasarkan stok_awal di dgv_saldo3 dan total_stok_masuk/total_stok_keluar dari dgv2
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

                    Dim index As Integer = dgv_saldo3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, totalStokMasuk, totalStokKeluar, stokAkhir, harga, hargaJual, dppBeliAkhir, dppJualAkhir)
                    combinedData(key) = dgv_saldo3.Rows(index)
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

        ' Menghapus baris dengan stok_akhir < 5
        For i As Integer = dgv_saldo3.Rows.Count - 1 To 0 Step -1
            If Not dgv_saldo3.Rows(i).IsNewRow Then
                Dim stokAwal As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(2).Value)
                Dim stokMasuk As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(3).Value)
                Dim stokKeluar As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(4).Value)
                Dim stokAkhir As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(5).Value)
                If stokAwal <= 5D And stokMasuk <= 0D And stokKeluar <= 0D And stokAkhir <= 5D Then
                    dgv_saldo3.Rows.RemoveAt(i)
                End If
            End If
        Next
        nilai_saldo_awal = 0
        For i As Integer = 0 To dgv_saldo3.Rows.Count - 1
            nilai_saldo_awal = nilai_saldo_awal + Decimal.Round((dgv_saldo3.Rows(i).Cells(8).Value), 10)
        Next
        'akhir fungsi saldo awal
    End Sub
    Private Sub saldo_akhir()
        'fungsi mencari saldo
        Dim selectedDate As DateTime = dtp_tahun.Value
        Dim bulanDipilih As Integer = 12
        Dim tahunDipilih As Integer = dtp_tahun.Value.Year
        Dim tanggalTerakhirBulanSebelumnya As DateTime = New DateTime(tahunDipilih, bulanDipilih, 1).AddDays(-1)
        dtp_awal.Value = tanggalTerakhirBulanSebelumnya
        dtp_akhir.Value = dtp_awal.Value.AddYears(-3)
        dtp_akhir.Value = dtp_akhir.Value.AddDays(+1)
        dtp_awal.CustomFormat = "yyyy/MM/dd"
        dtp_akhir.CustomFormat = "yyyy/MM/dd"
        'fungsi mencari saldo akhir
        dgv_saldo1.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                 "SUM(stok_masuk) - SUM(stok_keluar) AS stok_awal, " &
                 "harga, harga_jual " &
                 "FROM tbhistorygrey " &
                 "WHERE tanggal BETWEEN @dtp_akhir AND @dtp_awal " &
                 "GROUP BY nama_specs;"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp_awal", dtp_awal.Value)
                cmdx.Parameters.AddWithValue("@dtp_akhir", dtp_akhir.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv_saldo1.DataSource = dsx.Tables("tbhistorygrey")
                    End Using
                End Using
            End Using
        End Using
        dgv_saldo2.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_specs, harga_jual_ppn, SUM(stok_masuk) AS total_stok_masuk, SUM(stok_keluar) AS total_stok_keluar, " &
                "harga, harga_jual " &
                "FROM tbhistorygrey " &
                "WHERE MONTH(tanggal) = 12 AND YEAR(tanggal) = YEAR(@dtp) " &
                "GROUP BY nama_specs;"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@dtp", dtp_tahun.Value)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbhistorygrey")
                        dgv_saldo2.DataSource = dsx.Tables("tbhistorygrey")
                    End Using
                End Using
            End Using
        End Using

        dgv_saldo3.Columns.Clear()
        dgv_saldo3.Rows.Clear()

        ' Menambahkan kolom-kolom ke dgv_saldo3
        dgv_saldo3.Columns.Add("nama_specs", "Nama Specs")
        dgv_saldo3.Columns.Add("harga_jual_ppn", "Harga Jual PPN")
        dgv_saldo3.Columns.Add("stok_awal", "Stok Awal")
        dgv_saldo3.Columns.Add("total_stok_masuk", "Total Stok Masuk")
        dgv_saldo3.Columns.Add("total_stok_keluar", "Total Stok Keluar")
        dgv_saldo3.Columns.Add("stok_akhir", "Stok Akhir")
        dgv_saldo3.Columns.Add("harga", "Harga")
        dgv_saldo3.Columns.Add("harga_jual", "Harga Jual")
        dgv_saldo3.Columns.Add("dpp_beli_akhir", "DPP Beli Akhir")
        dgv_saldo3.Columns.Add("dpp_jual_akhir", "DPP Jual Akhir")

        ' Mengatur tipe data untuk kolom desimal
        dgv_saldo3.Columns("harga_jual_ppn").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("stok_awal").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("total_stok_masuk").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("total_stok_keluar").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("stok_akhir").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("harga").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("harga_jual").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("dpp_beli_akhir").ValueType = GetType(Decimal)
        dgv_saldo3.Columns("dpp_jual_akhir").ValueType = GetType(Decimal)

        ' Membuat dictionary untuk menyimpan data sementara
        Dim combinedDataAkhir As New Dictionary(Of String, DataGridViewRow)

        ' Mengisi data dari dgv1 (stok bulan sebelumnya)
        For Each row As DataGridViewRow In dgv_saldo1.Rows
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
                If Not combinedDataAkhir.ContainsKey(key) Then
                    ' Tambahkan baris baru ke dgv_saldo3 dengan stok_awal, total_stok_masuk, dan total_stok_keluar sementara 0
                    Dim index As Integer = dgv_saldo3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, 0D, 0D, stokAwal, harga, hargaJual, 0D, 0D)
                    combinedDataAkhir(key) = dgv_saldo3.Rows(index)
                End If
            End If
        Next

        ' Mengisi data dari dgv2 (stok bulan berjalan)
        For Each row As DataGridViewRow In dgv_saldo2.Rows
            If Not row.IsNewRow Then
                Dim namaSpecs As String = row.Cells("nama_specs").Value.ToString()
                Dim hargaJualPPN As Decimal = Convert.ToDecimal(row.Cells("harga_jual_ppn").Value)
                Dim totalStokMasuk As Decimal = Convert.ToDecimal(row.Cells("total_stok_masuk").Value)
                Dim totalStokKeluar As Decimal = Convert.ToDecimal(row.Cells("total_stok_keluar").Value)
                Dim harga As Decimal = Convert.ToDecimal(row.Cells("harga").Value)
                Dim hargaJual As Decimal = Convert.ToDecimal(row.Cells("harga_jual").Value)

                ' Key berdasarkan kombinasi nama_specs dan harga_jual_ppn
                Dim key As String = namaSpecs.ToString()

                If combinedDataAkhir.ContainsKey(key) Then
                    ' Update data di dgv_saldo3 untuk kolom total_stok_masuk dan total_stok_keluar dari dgv2 saja
                    Dim dgvRow As DataGridViewRow = combinedDataAkhir(key)
                    dgvRow.Cells("total_stok_masuk").Value = totalStokMasuk
                    dgvRow.Cells("total_stok_keluar").Value = totalStokKeluar

                    ' Update harga dan harga_jual dari dgv2
                    dgvRow.Cells("harga").Value = harga
                    dgvRow.Cells("harga_jual").Value = hargaJual

                    ' Hitung stok_akhir berdasarkan stok_awal di dgv_saldo3 dan total_stok_masuk/total_stok_keluar dari dgv2
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

                    Dim index As Integer = dgv_saldo3.Rows.Add(namaSpecs, hargaJualPPN, stokAwal, totalStokMasuk, totalStokKeluar, stokAkhir, harga, hargaJual, dppBeliAkhir, dppJualAkhir)
                    combinedDataAkhir(key) = dgv_saldo3.Rows(index)
                End If
            End If
        Next

        ' Mengisi stok_akhir untuk data yang hanya ada di dgv1 (jika tidak ada data di dgv2)
        For Each kvp As KeyValuePair(Of String, DataGridViewRow) In combinedDataAkhir
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

        ' Menghapus baris dengan stok_akhir < 5
        For i As Integer = dgv_saldo3.Rows.Count - 1 To 0 Step -1
            If Not dgv_saldo3.Rows(i).IsNewRow Then
                Dim stokAwal As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(2).Value)
                Dim stokMasuk As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(3).Value)
                Dim stokKeluar As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(4).Value)
                Dim stokAkhir As Decimal = Convert.ToDecimal(dgv_saldo3.Rows(i).Cells(5).Value)
                If stokAwal <= 5D And stokMasuk <= 0D And stokKeluar <= 0D And stokAkhir <= 5D Then
                    dgv_saldo3.Rows.RemoveAt(i)
                End If
            End If
        Next
        nilai_saldo_akhir = 0
        For i As Integer = 0 To dgv_saldo3.Rows.Count - 1
            nilai_saldo_akhir = nilai_saldo_akhir + Decimal.Round((dgv_saldo3.Rows(i).Cells(8).Value), 10)
        Next
        'akhir fungsi saldo akhir
    End Sub

    Private Sub load_sheet_lapkeu()
        lbl_lapkeu.Text = "1 JANUARI - 31 DESEMBER " & dtp_tahun.Text
        dgv_lapkeu.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        If dgv_lapkeu.ColumnCount = 0 Then
            dgv_lapkeu.Columns.Add("kategori", "")
            dgv_lapkeu.Columns.Add("rp1", "")
            dgv_lapkeu.Columns.Add("komersial", "")
            dgv_lapkeu.Columns.Add("positif", "")
            dgv_lapkeu.Columns.Add("negatif", "")
            dgv_lapkeu.Columns.Add("rp2", "")
            dgv_lapkeu.Columns.Add("fiskal", "")
        End If
        dgv_lapkeu.Rows.Add("", "", "", "", "", "", "") '0
        dgv_lapkeu.Rows.Add("", "", "KOMERSIAL", "KOREKSI POSITIF", "KOREKSI NEGATIF", "", "FISKAL") '1
        dgv_lapkeu.Rows.Add("PENDAPATAN", "Rp", pendapatan, "", "", "Rp", pendapatan) '2
        dgv_lapkeu.Rows.Add("HARGA POKOK PENJUALAN", "Rp", hargapokokpenjualan, "", "", "Rp", hargapokokpenjualan) '3
        Dim labarugi As Decimal = pendapatan - hargapokokpenjualan
        dgv_lapkeu.Rows.Add("LABA/RUGI BRUTO", "Rp", labarugi, "", "", "Rp", labarugi) '4
        dgv_lapkeu.Rows.Add("", "", "", "", "", "", "") '5
        dgv_lapkeu.Rows.Add("BIAYA OPERASIONAL", "", "", "", "", "", "") '6
        '7
        Dim total_keperluan_kantor As Decimal = 0D
        Dim query7 As String = "SELECT " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA KEPERLUAN KANTOR' " &
            "AND YEAR(tanggal) = @tahun;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query7, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0D)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0D)
                        total_keperluan_kantor = total_dpp + total_polos
                    End If
                End Using
            End Using
        End Using
        ' Menambahkan hasil ke DataGridView
        dgv_lapkeu.Rows.Add("BIAYA KEPERLUAN KANTOR", "Rp", total_keperluan_kantor, "", "", "Rp", total_keperluan_kantor)
        '8
        Dim gaji_pegawai As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT gaji_pegawai FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("gaji_pegawai")) Then
                            gaji_pegawai = reader.GetDecimal("gaji_pegawai")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("BIAYA GAJI PEGAWAI", "Rp", gaji_pegawai, "", "", "Rp", gaji_pegawai)
        '9
        Dim biaya_penyusutan_kendaraan As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(nilai_penyusutan) AS total_penyusutan " &
                    "FROM tbdatapenyusutan " &
                    "WHERE kategori_aset = 'KENDARAAN' AND tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("total_penyusutan")) Then
                            biaya_penyusutan_kendaraan = reader.GetDecimal("total_penyusutan")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("BIAYA PENYUSUTAN KENDARAAN", "Rp", biaya_penyusutan_kendaraan, "", "", "Rp", biaya_penyusutan_kendaraan)
        '10
        Dim sewa_kantor As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT sewa_kantor FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_kantor")) Then
                            sewa_kantor = reader.GetDecimal("sewa_kantor")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("BIAYA SEWA KANTOR", "Rp", sewa_kantor, "", "", "Rp", sewa_kantor)
        '11
        Dim total_air_telepon As Decimal = 0D
        Dim query11 As String = "SELECT " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA AIR TELEPON' " &
            "AND YEAR(tanggal) = @tahun;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query11, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0D)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0D)
                        total_air_telepon = total_dpp + total_polos
                    End If
                End Using
            End Using
        End Using
        ' Menambahkan hasil ke DataGridView
        dgv_lapkeu.Rows.Add("BIAYA AIR TELEPON", "Rp", total_air_telepon, "", "", "Rp", total_air_telepon)
        '12
        Dim biaya_pengiriman As Decimal = 0D
        Dim query12 As String = "SELECT " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA PENGIRIMAN' " &
            "AND YEAR(tanggal) = @tahun;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query12, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0D)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0D)
                        biaya_pengiriman = total_dpp + total_polos
                    End If
                End Using
            End Using
        End Using
        ' Menambahkan hasil ke DataGridView
        dgv_lapkeu.Rows.Add("BIAYA PENGIRIMAN", "Rp", biaya_pengiriman, "", "", "Rp", biaya_pengiriman)
        '13
        Dim biaya_pbb As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT pbb FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("pbb")) Then
                            biaya_pbb = reader.GetDecimal("pbb")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("PBB", "Rp", biaya_pbb, "", "", "Rp", biaya_pbb)
        '14
        Dim peralatan_gedung As Decimal = 0D
        Dim query14 As String = "SELECT " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA MAINTENANCE PERALATAN DAN GEDUNG' " &
            "AND YEAR(tanggal) = @tahun;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query14, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0D)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0D)
                        peralatan_gedung = total_dpp + total_polos
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("BIAYA MAINTENANCE PERALATAN DAN GEDUNG", "Rp", peralatan_gedung, "", "", "Rp", peralatan_gedung)
        '15
        Dim maintenance_kendaraan As Decimal = 0D
        Dim query15 As String = "SELECT " &
            "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
            "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA MAINTENANCE KENDARAAN' " &
            "AND YEAR(tanggal) = @tahun;"
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query15, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0D)
                        Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0D)
                        maintenance_kendaraan = total_dpp + total_polos
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu.Rows.Add("BIAYA MAINTENANCE KENDARAAN", "Rp", maintenance_kendaraan, "", "", "Rp", maintenance_kendaraan)
        dgv_lapkeu.Rows.Add("", "", "", "", "", "", "") '16
        '17
        Dim jumlah_lapkeu As Decimal = 0
        jumlah_lapkeu = total_keperluan_kantor + gaji_pegawai + biaya_penyusutan_kendaraan + sewa_kantor + total_air_telepon _
            + biaya_pengiriman + biaya_pbb + peralatan_gedung + maintenance_kendaraan
        dgv_lapkeu.Rows.Add("JUMLAH", "Rp", jumlah_lapkeu, "", "", "Rp", jumlah_lapkeu)
        dgv_lapkeu.Rows.Add("", "", "", "", "", "", "") '18
        Dim labarugisebelum As Decimal = labarugi - jumlah_lapkeu
        dgv_lapkeu.Rows.Add("LABA/RUGI SEBELUM PAJAK", "Rp", labarugisebelum, "", "", "Rp", labarugisebelum) '19

        'dgv_lapkeu_2
        dgv_lapkeu_2.Columns.Clear()
        If dgv_lapkeu_2.ColumnCount = 0 Then
            dgv_lapkeu_2.Columns.Add("kolom1", "")
            dgv_lapkeu_2.Columns.Add("kolom2", "")
            dgv_lapkeu_2.Columns.Add("kolom3", "")
            dgv_lapkeu_2.Columns.Add("kolom4", "")
        End If
        dgv_lapkeu_2.Rows.Add("", "", "", "")
        dgv_lapkeu_2.Rows.Add("", "", "", labarugisebelum)
        Dim hasilrounddown As Double = RoundDown(labarugisebelum, -3)
        dgv_lapkeu_2.Rows.Add("", "", "", hasilrounddown)
        dgv_lapkeu_2.Rows.Add("PPh Terhutang 22%", "", "", "")
        Dim fasilitas As Decimal = 0
        If pendapatan * hasilrounddown = 0 Then
            fasilitas = 0
        Else
            fasilitas = 4800000000 / pendapatan * hasilrounddown
        End If
        dgv_lapkeu_2.Rows.Add("Fasilitas 11%", "", fasilitas, fasilitas * 0.11)
        Dim nonfasilitas As Decimal = (hasilrounddown - fasilitas) * 0.22
        dgv_lapkeu_2.Rows.Add("NonFasilitas 22%", "", "", nonfasilitas)
        Dim pph_terhutang As Decimal = (fasilitas * 0.11) + nonfasilitas
        dgv_lapkeu_2.Rows.Add("Total PPh Terhutang", "", "", pph_terhutang)
        Dim angsuran_pph25 As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT total FROM tbangsuranpph25 WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("total")) Then
                            angsuran_pph25 = reader.GetDecimal("total")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu_2.Rows.Add("Angsuran PPh 25", "", "", angsuran_pph25)
        Dim bukpot As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(pph23_actual) AS total_pph23 " &
                    "FROM tbpenjualan " &
                    "WHERE YEAR(tanggal) = @tahun;" ' Perbaiki kondisi tanggal
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", dtp_tahun.Value.Year) ' Pastikan format tahun benar
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not reader.IsDBNull(reader.GetOrdinal("total_pph23")) Then
                        bukpot = reader.GetDecimal("total_pph23") ' Ambil nilai yang benar
                    End If
                End Using
            End Using
        End Using
        dgv_lapkeu_2.Rows.Add("PPh 23 Bukti Potong", "", "", bukpot) ' Tambahkan hasil ke tabel
        Dim kblb As Decimal = pph_terhutang - angsuran_pph25 - bukpot
        dgv_lapkeu_2.Rows.Add("KB / (LB)", "", "", kblb)
        dgv_lapkeu_2.Rows.Add("", "", "", "")
        dgv_lapkeu_2.Rows.Add("Angsuran th selanjutnya", "", "", "")
        dgv_lapkeu_2.Rows.Add("PPh Terhutang", "", "", pph_terhutang)
        dgv_lapkeu_2.Rows.Add("Bukti Potong PPh 23", "", "", bukpot)
        Dim kb As Decimal = pph_terhutang - bukpot
        dgv_lapkeu_2.Rows.Add("KB", "", "", kb)
        dgv_lapkeu_2.Rows.Add("PPh 25 selanjutnya", "", "", kb / 12)
        '---
        dgv_lapkeu.Rows.Add("PAJAK TERHUTANG", "Rp", -pph_terhutang, "", "", "", "") '20 'pphnya jadi dikali negatif
        dgv_lapkeu.Rows.Add("LABA RUGI SETELAH PAJAK", "Rp", labarugisebelum + (-pph_terhutang), "", "", "", "") '21

        dgv_lapkeu.ColumnHeadersVisible = False
        dgv_lapkeu.Columns(0).Width = 300
        dgv_lapkeu.Columns(2).Width = 150
        dgv_lapkeu.Columns(3).Width = 150
        dgv_lapkeu.Columns(4).Width = 150
        dgv_lapkeu.Columns(6).Width = 150
        dgv_lapkeu.Columns(1).Width = 30
        dgv_lapkeu.Columns(5).Width = 30

        dgv_lapkeu.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lapkeu.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lapkeu.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lapkeu.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lapkeu.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lapkeu.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgv_lapkeu.Rows(1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lapkeu.Rows(1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lapkeu.Rows(1).Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lapkeu.Rows(1).Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgv_lapkeu_2.ColumnHeadersVisible = False
        dgv_lapkeu_2.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu_2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lapkeu_2.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_lapkeu_2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgv_lapkeu_2.ColumnHeadersVisible = False
        dgv_lapkeu_2.Columns(0).Width = 200
        dgv_lapkeu_2.Columns(1).Width = 5
        dgv_lapkeu_2.Columns(2).Width = 150
        dgv_lapkeu_2.Columns(3).Width = 150

    End Sub
    Function RoundDown(ByVal number As Double, ByVal num_digits As Integer) As Double
        ' Ambil nilai ratusan terakhir dari angka tersebut
        Dim hundreds As Double = number Mod 1000
        ' Kurangkan angka awal dengan nilai ratusan tadi
        Return number - hundreds
    End Function

    Private Sub load_sheet_biaya_baru()
        dgv_biaya.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim bulanArray() As String = {"Januari", "Februari", "Maret", "April", "Mei", "Juni",
                                      "Juli", "Agustus", "September", "Oktober", "November", "Desember"}
        If dgv_biaya.ColumnCount = 0 Then
            dgv_biaya.Columns.Add("kategori", "")
            dgv_biaya.Columns.Add("ppn1", "")
            dgv_biaya.Columns.Add("polos1", "")
            dgv_biaya.Columns.Add("total1", "")
            dgv_biaya.Columns.Add("ppn2", "")
            dgv_biaya.Columns.Add("polos2", "")
            dgv_biaya.Columns.Add("total2", "")
            dgv_biaya.Columns.Add("ppn3", "")
            dgv_biaya.Columns.Add("polos3", "")
            dgv_biaya.Columns.Add("total3", "")
            dgv_biaya.Columns.Add("ppn4", "")
            dgv_biaya.Columns.Add("polos4", "")
            dgv_biaya.Columns.Add("total4", "")
            dgv_biaya.Columns.Add("ppn5", "")
            dgv_biaya.Columns.Add("polos5", "")
            dgv_biaya.Columns.Add("total5", "")
            dgv_biaya.Columns.Add("ppn6", "")
            dgv_biaya.Columns.Add("polos6", "")
            dgv_biaya.Columns.Add("total6", "")
            dgv_biaya.Columns.Add("ppn7", "")
            dgv_biaya.Columns.Add("polos7", "")
            dgv_biaya.Columns.Add("total7", "")
            dgv_biaya.Columns.Add("ppn8", "")
            dgv_biaya.Columns.Add("polos8", "")
            dgv_biaya.Columns.Add("total8", "")
            dgv_biaya.Columns.Add("ppn9", "")
            dgv_biaya.Columns.Add("polos9", "")
            dgv_biaya.Columns.Add("total9", "")
            dgv_biaya.Columns.Add("ppn10", "")
            dgv_biaya.Columns.Add("polos10", "")
            dgv_biaya.Columns.Add("total10", "")
            dgv_biaya.Columns.Add("ppn11", "")
            dgv_biaya.Columns.Add("polos11", "")
            dgv_biaya.Columns.Add("total11", "")
            dgv_biaya.Columns.Add("ppn12", "")
            dgv_biaya.Columns.Add("polos12", "")
            dgv_biaya.Columns.Add("total11", "")
        End If

        dgv_biaya.Rows.Add("", "JANUARI", "", "", "FEBRUARI", "", "", "MARET", "", "", "APRIL", "", "", _
                           "MEI", "", "", "JUNI", "", "", "JULI", "", "", "AGUSTUS", "", "", _
                           "SEPTEMBER", "", "", "OKTOBER", "", "", "NOVEMBER", "", "", "DESEMBER", "", "")
        dgv_biaya.Rows.Add("", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", _
                          "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", _
                         "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL", "PPN", "POLOS", "TOTAL")
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "")
        'upah harian
        'Dim upah_harian As Decimal = 0
        'Using conx As New MySqlConnection(sLocalConn)
        '    conx.Open()
        '    Dim query As String = "SELECT SUM(upah_harian) AS upah_harian FROM tbbiayatahunan WHERE tahun = @tahun;"
        '    Using cmd As New MySqlCommand(query, conx)
        '        cmd.Parameters.AddWithValue("@tahun", tahun)
        '        Using reader As MySqlDataReader = cmd.ExecuteReader()
        '            If reader.Read() Then
        '                If Not reader.IsDBNull(reader.GetOrdinal("upah_harian")) Then
        '                    upah_harian = reader.GetDecimal("upah_harian")
        '                End If
        '            End If
        '        End Using
        '    End Using
        'End Using
        'dgv_biaya.Rows.Add("UPAH HARIAN", "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", upah_harian)
        Dim rowIndex As Integer = dgv_biaya.Rows.Add("UPAH HARIAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "")
        Dim namaBulan() As String = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE",
                                     "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For bulanIndex As Integer = 0 To 11
            Dim bulanEnum As String = namaBulan(bulanIndex)
            Dim query As String = "SELECT IFNULL(SUM(upah), 0) FROM tbupahgaji WHERE bulan = @bulan AND tahun = @tahun"
            Using con As New MySqlConnection(sLocalConn)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@bulan", bulanEnum)
                    cmd.Parameters.AddWithValue("@tahun", tahun)

                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nilaiUpah As Decimal = If(IsDBNull(result), 0D, Convert.ToDecimal(result))
                    Dim colIndex As Integer = bulanIndex * 2 + bulanIndex

                    ' Isi nilai ke kolom yang sesuai, kolom pertama setelah kolom "UPAH HARIAN" = index 1
                    dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = 0
                    dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = nilaiUpah
                    dgv_biaya.Rows(rowIndex).Cells(colIndex + 3).Value = nilaiUpah
                End Using
            End Using
        Next

        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", _
                        "", "", "", "", "", "", "", "", "", "", "", "", _
                        "", "", "", "", "", "", "", "", "", "", "", "")

        Dim penyusutan_bangunan As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query_penyusutan_bangunan As String = "SELECT SUM(nilai_penyusutan) AS penyusutan_bangunan FROM tbdatapenyusutan " &
                "WHERE kategori_aset = 'BANGUNAN' And tahun = @tahun;"
            Using cmd As New MySqlCommand(query_penyusutan_bangunan, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("penyusutan_bangunan")) Then
                            penyusutan_bangunan = reader.GetDecimal("penyusutan_bangunan")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA PENYUSUTAN BANGUNAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", penyusutan_bangunan)

        Dim penyusutan_inventaris As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query_penyusutan_inventaris As String = "SELECT SUM(nilai_penyusutan) AS penyusutan_inventaris FROM tbdatapenyusutan " &
                "WHERE kategori_aset = 'INVENTARIS' And tahun = @tahun;"
            Using cmd As New MySqlCommand(query_penyusutan_inventaris, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("penyusutan_inventaris")) Then
                            penyusutan_inventaris = reader.GetDecimal("penyusutan_inventaris")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA PENYUSUTAN INVENTARIS", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", penyusutan_inventaris)

        Dim tangki_pengolah_limbah As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query_tangki_pengolah_limbah As String = "SELECT SUM(nilai_penyusutan) AS tangki_pengolah_limbah FROM tbdatapenyusutan " &
                "WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH' And tahun = @tahun;"
            Using cmd As New MySqlCommand(query_tangki_pengolah_limbah, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("tangki_pengolah_limbah")) Then
                            tangki_pengolah_limbah = reader.GetDecimal("tangki_pengolah_limbah")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA PENYUSUTAN TANGKI PENGOLAH LIMBAH", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", tangki_pengolah_limbah)

        Dim penyusutan_mesin As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query_penyusutan_mesin As String = "SELECT SUM(nilai_penyusutan) AS penyusutan_mesin FROM tbdatapenyusutan " &
                "WHERE kategori_aset = 'MESIN' And tahun = @tahun;"
            Using cmd As New MySqlCommand(query_penyusutan_mesin, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("penyusutan_mesin")) Then
                            penyusutan_mesin = reader.GetDecimal("penyusutan_mesin")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA PENYUSUTAN MESIN", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", penyusutan_mesin)
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", _
                        "", "", "", "", "", "", "", "", "", "", "", "", _
                        "", "", "", "", "", "", "", "", "", "", "", "")

        'Dim rowIndex As Integer = dgv_biaya.Rows.Add("BIAYA LISTRIK PABRIK", "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", "")
        rowIndex = dgv_biaya.Rows.Add("BIAYA LISTRIK PABRIK", "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querylistrik As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA LISTRIK PABRIK' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querylistrik, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA BATUBARA", "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querybatubara As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BATUBARA' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querybatubara, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA GARAM", "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querygaram As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA GARAM' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querygaram, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA PACKING", "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querypacking As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA PACKING' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querypacking, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA PEMAKAIAN SPAREPART MESIN", "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querysparepart As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA PEMAKAIAN SPAREPART MESIN' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querysparepart, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA PENGOLAHAN LIMBAH", "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "", _
                                      "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querylimbah As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA PENGOLAHAN LIMBAH' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querylimbah, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA PENGUJIAN DAN LEGALITAS", "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querypengujian As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA PENGUJIAN DAN LEGALITAS' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querypengujian, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA MAINTENANCE MESIN", "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querymaintenancemesin As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA MAINTENANCE MESIN' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querymaintenancemesin, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        Dim sewa_pabrik As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT SUM(sewa_pabrik) AS sewa_pabrik FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_pabrik")) Then
                            sewa_pabrik = reader.GetDecimal("sewa_pabrik")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA SEWA PABRIK", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", sewa_pabrik)

        dgv_biaya.Rows.Add()

        rowIndex = dgv_biaya.Rows.Add("BIAYA KEPERLUAN KANTOR", "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "", _
                                     "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querykantor As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA KEPERLUAN KANTOR' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querykantor, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        'Dim gaji_pegawai As Decimal = 0
        'Using conx As New MySqlConnection(sLocalConn)
        '    conx.Open()
        '    Dim query As String = "SELECT SUM(gaji_pegawai) AS gaji_pegawai FROM tbbiayatahunan WHERE tahun = @tahun;"
        '    Using cmd As New MySqlCommand(query, conx)
        '        cmd.Parameters.AddWithValue("@tahun", tahun)
        '        Using reader As MySqlDataReader = cmd.ExecuteReader()
        '            If reader.Read() Then
        '                If Not reader.IsDBNull(reader.GetOrdinal("gaji_pegawai")) Then
        '                    gaji_pegawai = reader.GetDecimal("gaji_pegawai")
        '                End If
        '            End If
        '        End Using
        '    End Using
        'End Using
        'dgv_biaya.Rows.Add("BIAYA GAJI PEGAWAI", "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", "", _
        '                  "", "", "", "", "", "", "", "", "", "", "", gaji_pegawai)

        Dim rowIndexgaji As Integer = dgv_biaya.Rows.Add("BIAYA GAJI PEGAWAI", "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "", _
                         "", "", "", "", "", "", "", "", "", "", "", "")
        Dim namaBulangaji() As String = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE",
                                     "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For bulanIndex As Integer = 0 To 11
            Dim bulanEnum As String = namaBulangaji(bulanIndex)
            Dim query As String = "SELECT IFNULL(SUM(gaji), 0) FROM tbupahgaji WHERE bulan = @bulan AND tahun = @tahun"
            Using con As New MySqlConnection(sLocalConn)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@bulan", bulanEnum)
                    cmd.Parameters.AddWithValue("@tahun", tahun)

                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nilaiUpah As Decimal = If(IsDBNull(result), 0D, Convert.ToDecimal(result))
                    Dim colIndex As Integer = bulanIndex * 2 + bulanIndex

                    ' Isi nilai ke kolom yang sesuai, kolom pertama setelah kolom "UPAH HARIAN" = index 1
                    dgv_biaya.Rows(rowIndexgaji).Cells(colIndex + 1).Value = 0
                    dgv_biaya.Rows(rowIndexgaji).Cells(colIndex + 2).Value = nilaiUpah
                    dgv_biaya.Rows(rowIndexgaji).Cells(colIndex + 3).Value = nilaiUpah
                End Using
            End Using
        Next

        Dim penyusutan_kendaraan As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query_penyusutan_kendaraan As String = "SELECT SUM(nilai_penyusutan) AS penyusutan_kendaraan FROM tbdatapenyusutan " &
                "WHERE kategori_aset = 'KENDARAAN' And tahun = @tahun;"
            Using cmd As New MySqlCommand(query_penyusutan_kendaraan, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("penyusutan_kendaraan")) Then
                            penyusutan_kendaraan = reader.GetDecimal("penyusutan_kendaraan")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA PENYUSUTAN KENDARAAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                           "", "", "", "", "", "", "", "", "", "", "", penyusutan_kendaraan)

        Dim sewa_kantor As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT SUM(sewa_kantor) AS sewa_kantor FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_kantor")) Then
                            sewa_kantor = reader.GetDecimal("sewa_kantor")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("BIAYA SEWA KANTOR", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", sewa_kantor)

        rowIndex = dgv_biaya.Rows.Add("BIAYA AIR TELEPON", "", "", "", "", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim queryair As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA AIR TELEPON' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(queryair, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA PENGIRIMAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querypengiriman As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA PENGIRIMAN' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querypengiriman, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next
       
        Dim pbb As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT SUM(pbb) AS pbb FROM tbbiayatahunan WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(reader.GetOrdinal("pbb")) Then
                            pbb = reader.GetDecimal("pbb")
                        End If
                    End If
                End Using
            End Using
        End Using
        dgv_biaya.Rows.Add("PBB", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", pbb)
        
        rowIndex = dgv_biaya.Rows.Add("BIAYA MAINTENANCE PERALATAN DAN GEDUNG", "", "", "", "", "", "", "", "", "", "", "", "", _
                                   "", "", "", "", "", "", "", "", "", "", "", "", _
                                   "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim queryperalatan As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA MAINTENANCE PERALATAN DAN GEDUNG' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(queryperalatan, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        rowIndex = dgv_biaya.Rows.Add("BIAYA MAINTENANCE KENDARAAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                                   "", "", "", "", "", "", "", "", "", "", "", "", _
                                   "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Dim querykendaraan As String = "SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                "FROM(tbpembelian) WHERE jenis_biaya = 'BIAYA MAINTENANCE KENDARAAN' AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand(querykendaraan, conx)
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_dpp As Decimal = If(Not reader.IsDBNull(0), reader.GetDecimal(0), 0)
                            Dim total_polos As Decimal = If(Not reader.IsDBNull(1), reader.GetDecimal(1), 0)
                            Dim total_biaya As Decimal = total_dpp + total_polos
                            ' Menghitung indeks awal berdasarkan bulan
                            Dim colIndex As Integer = (bulan - 1) * 2 + bulan
                            ' Menetapkan nilai ke DataGridView
                            dgv_biaya.Rows(rowIndex).Cells(colIndex).Value = total_dpp
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 1).Value = total_polos
                            dgv_biaya.Rows(rowIndex).Cells(colIndex + 2).Value = total_biaya
                        End If
                    End Using
                End Using
            End Using
        Next

        dgv_biaya.Rows.Add()

        Call hitungTotalBiaya()

        ' Terapkan format untuk semua kolom bulan
        For i = 1 To dgv_biaya.ColumnCount - 1
            dgv_biaya.Columns(i).DefaultCellStyle.Format = "#,##0.00"
            dgv_biaya.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv_biaya.Columns(i).Width = 120
        Next
        For rowIndex = 0 To 1 ' Baris 1 dan 2 (indeks 0 dan 1)
            For Each cell As DataGridViewCell In dgv_biaya.Rows(rowIndex).Cells
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Next

        dgv_biaya.Columns(0).Width = 300

        dgv_biaya.Rows(0).Cells(37).Value = "BIAYA PER TAHUN"
        dgv_biaya.Rows(1).Cells(37).Value = "PPN"
        dgv_biaya.Rows(1).Cells(38).Value = "POLOS"
        dgv_biaya.Rows(1).Cells(39).Value = "TOTAL"
        dgv_biaya.ColumnHeadersVisible = False
    End Sub
    Private Sub hitungTotalBiaya()
        ' Pastikan kolom tambahan sudah ada, jika belum tambahkan
        Dim kolomPPN As String = "total_ppn"
        Dim kolomPolos As String = "total_polos"
        Dim kolomTotal As String = "total_keseluruhan"

        If dgv_biaya.Columns.Contains(kolomPPN) = False Then
            dgv_biaya.Columns.Add(kolomPPN, "")
            dgv_biaya.Columns.Add(kolomPolos, "")
            dgv_biaya.Columns.Add(kolomTotal, "")
        End If

        ' Looping untuk menjumlahkan setiap baris
        For i As Integer = 2 To dgv_biaya.Rows.Count - 2 ' Hindari header dan total
            Dim kategori As String = If(dgv_biaya.Rows(i).Cells(0).Value IsNot Nothing, dgv_biaya.Rows(i).Cells(0).Value.ToString().Trim(), "")

            ' Lewati baris tanpa judul kategori
            If String.IsNullOrEmpty(kategori) Then
                dgv_biaya.Rows(i).Cells(kolomPPN).Value = ""
                dgv_biaya.Rows(i).Cells(kolomPolos).Value = ""
                dgv_biaya.Rows(i).Cells(kolomTotal).Value = ""
                Continue For
            End If

            Dim totalPPN As Decimal = 0
            Dim totalPolos As Decimal = 0
            Dim totalKeseluruhan As Decimal = 0

            For bulan As Integer = 1 To 12
                Dim colIndex As Integer = (bulan - 1) * 3 + 1 ' Kolom PPN
                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex).Value) Then
                    totalPPN += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex).Value)
                End If

                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex + 1).Value) Then
                    totalPolos += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex + 1).Value)
                End If

                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex + 2).Value) Then
                    totalKeseluruhan += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex + 2).Value)
                End If
            Next

            ' Set hasil per baris ke kolom tambahan
            dgv_biaya.Rows(i).Cells(kolomPPN).Value = totalPPN
            dgv_biaya.Rows(i).Cells(kolomPolos).Value = totalPolos
            dgv_biaya.Rows(i).Cells(kolomTotal).Value = totalKeseluruhan
        Next

        ' Tambahkan baris total di bawah
        Dim rowIndex As Integer = dgv_biaya.Rows.Add("TOTAL PER BULAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                                                     "", "", "", "", "", "", "", "", "", "", "", "", _
                                                     "", "", "", "", "", "", "", "", "", "", "", "")

        ' Looping untuk menjumlahkan setiap kolom total bulanan
        For bulan As Integer = 1 To 12
            Dim totalPPN As Decimal = 0
            Dim totalPolos As Decimal = 0
            Dim totalKeseluruhan As Decimal = 0

            ' Hitung total per kolom
            For i As Integer = 2 To dgv_biaya.Rows.Count - 2 ' Hindari header dan total
                Dim kategori As String = If(dgv_biaya.Rows(i).Cells(0).Value IsNot Nothing, dgv_biaya.Rows(i).Cells(0).Value.ToString().Trim(), "")

                ' Lewati baris tanpa judul kategori
                If String.IsNullOrEmpty(kategori) Then Continue For

                Dim colIndex As Integer = (bulan - 1) * 3 + 1 ' Kolom PPN
                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex).Value) Then
                    totalPPN += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex).Value)
                End If

                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex + 1).Value) Then
                    totalPolos += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex + 1).Value)
                End If

                If IsNumeric(dgv_biaya.Rows(i).Cells(colIndex + 2).Value) Then
                    totalKeseluruhan += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(colIndex + 2).Value)
                End If
            Next

            ' Set hasil ke baris total
            Dim colIndexTotal As Integer = (bulan - 1) * 3 + 1
            dgv_biaya.Rows(rowIndex).Cells(colIndexTotal).Value = totalPPN
            dgv_biaya.Rows(rowIndex).Cells(colIndexTotal + 1).Value = totalPolos
            dgv_biaya.Rows(rowIndex).Cells(colIndexTotal + 2).Value = totalKeseluruhan
        Next

        ' Hitung total keseluruhan per kolom tambahan
        Dim grandTotalPPN As Decimal = 0
        Dim grandTotalPolos As Decimal = 0
        Dim grandTotalKeseluruhan As Decimal = 0

        For i As Integer = 2 To dgv_biaya.Rows.Count - 2 ' Hindari header dan total
            Dim kategori As String = If(dgv_biaya.Rows(i).Cells(0).Value IsNot Nothing, dgv_biaya.Rows(i).Cells(0).Value.ToString().Trim(), "")

            ' Lewati baris tanpa judul kategori
            If String.IsNullOrEmpty(kategori) Then Continue For

            If IsNumeric(dgv_biaya.Rows(i).Cells(kolomPPN).Value) Then
                grandTotalPPN += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(kolomPPN).Value)
            End If
            If IsNumeric(dgv_biaya.Rows(i).Cells(kolomPolos).Value) Then
                grandTotalPolos += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(kolomPolos).Value)
            End If
            If IsNumeric(dgv_biaya.Rows(i).Cells(kolomTotal).Value) Then
                grandTotalKeseluruhan += Convert.ToDecimal(dgv_biaya.Rows(i).Cells(kolomTotal).Value)
            End If
        Next

        ' Set total di baris total pada kolom tambahan
        dgv_biaya.Rows(rowIndex).Cells(kolomPPN).Value = grandTotalPPN
        dgv_biaya.Rows(rowIndex).Cells(kolomPolos).Value = grandTotalPolos
        dgv_biaya.Rows(rowIndex).Cells(kolomTotal).Value = grandTotalKeseluruhan

        ' Terapkan format angka
        For i = 1 To dgv_biaya.ColumnCount - 1
            dgv_biaya.Rows(rowIndex).Cells(i).Style.Format = "#,##0.00"
            dgv_biaya.Rows(rowIndex).Cells(i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Next

        ' Format nama kategori total
        'dgv_biaya.Rows(rowIndex).Cells(0).Style.Font = New Font(dgv_biaya.Font, FontStyle.Bold)
        dgv_biaya.Rows(rowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Sub
    Private Sub load_sheet_biaya()
        dgv_biaya.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        ' Deklarasi array kategori aset
        Dim kategoriAset() As String = {"BANGUNAN", "INVENTARIS", "TANKI PENGOLAH LIMBAH", "MESIN"}

        ' Pastikan DataGridView memiliki kolom yang sesuai
        Dim bulanArray() As String = {"Januari", "Februari", "Maret", "April", "Mei", "Juni",
                                      "Juli", "Agustus", "September", "Oktober", "November", "Desember"}

        ' Jika DataGridView belum memiliki kolom, tambahkan kolomnya
        If dgv_biaya.ColumnCount = 0 Then
            dgv_biaya.Columns.Add("Kategori", "")
            For Each bulan In bulanArray
                dgv_biaya.Columns.Add(bulan, bulan)
            Next
        End If

        'upah harian
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "")
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(upah_harian) AS upah_harian " &
                    "FROM tbbiayatahunan " &
                    "WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim upah_harian As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("upah_harian")) Then
                            upah_harian = reader.GetDecimal("upah_harian")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("UPAH HARIAN", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = upah_harian
                    End If
                End Using
            End Using
        End Using

        ' Penyusutan
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "")
            For Each kategori In kategoriAset
                ' Query untuk setiap kategori aset
                Dim query As String =
                    "SELECT SUM(nilai_penyusutan) AS total_penyusutan " &
                    "FROM tbdatapenyusutan " &
                    "WHERE kategori_aset = @kategori AND tahun = @tahun;"

                Using cmd As New MySqlCommand(query, conx)
                    cmd.Parameters.AddWithValue("@kategori", kategori)
                    cmd.Parameters.AddWithValue("@tahun", tahun)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_penyusutan As Decimal = 0
                            If Not reader.IsDBNull(reader.GetOrdinal("total_penyusutan")) Then
                                total_penyusutan = reader.GetDecimal("total_penyusutan")
                            End If

                            ' Cek apakah baris sudah ada
                            Dim rowIndex As Integer = -1
                            For Each row As DataGridViewRow In dgv_biaya.Rows
                                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = "BIAYA PENYUSUTAN " & kategori Then
                                    rowIndex = row.Index
                                    Exit For
                                End If
                            Next

                            ' Jika belum ada, tambahkan baris baru
                            If rowIndex = -1 Then
                                rowIndex = dgv_biaya.Rows.Add("BIAYA PENYUSUTAN " & kategori, "", "", "", "", "", "", "", "", "", "", "", "")
                            End If

                            ' Isi nilai pada kolom Desember
                            dgv_biaya.Rows(rowIndex).Cells("Desember").Value = total_penyusutan
                        End If
                    End Using
                End Using
            Next
        End Using

        ' Listrik dll
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "")
        Dim daftarBiaya() As String = {
            "BIAYA LISTRIK PABRIK", "BATUBARA", "BIAYA GARAM", "BIAYA PACKING",
            "BIAYA PEMAKAIAN SPAREPART MESIN", "BIAYA PENGOLAHAN LIMBAH",
            "BIAYA PENGUJIAN DAN LEGALITAS"}

        For Each jenisBiaya In daftarBiaya
            ' Pastikan DataGridView memiliki baris kosong untuk jenis biaya ini
            Dim rowIndex As Integer = -1
            For Each row As DataGridViewRow In dgv_biaya.Rows
                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = jenisBiaya Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next

            ' Jika belum ada, tambahkan baris baru
            If rowIndex = -1 Then
                If jenisBiaya = "BATUBARA" Then
                    rowIndex = dgv_biaya.Rows.Add("BIAYA " & jenisBiaya, "", "", "", "", "", "", "", "", "", "", "", "")
                Else
                    rowIndex = dgv_biaya.Rows.Add(jenisBiaya, "", "", "", "", "", "", "", "", "", "", "", "")
                End If
            End If

            ' Loop untuk setiap bulan dari Januari sampai Desember
            For bulan As Integer = 1 To 12
                Dim query As String =
                    "SELECT " &
                    "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                    "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                    "FROM tbpembelian " &
                    "WHERE jenis_biaya = @jenisBiaya " &
                    "AND MONTH(tanggal) = @bulan " &
                    "AND YEAR(tanggal) = @tahun;"

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Using cmd As New MySqlCommand(query, conx)
                        cmd.Parameters.AddWithValue("@jenisBiaya", jenisBiaya)
                        cmd.Parameters.AddWithValue("@bulan", bulan)
                        cmd.Parameters.AddWithValue("@tahun", tahun)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0)
                                Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0)
                                Dim total_biaya As Decimal = total_dpp + total_polos

                                ' Pastikan data masuk ke kolom bulan yang benar
                                Dim namaKolom As String = bulanArray(bulan - 1) ' Ambil nama bulan dari array
                                If dgv_biaya.Columns.Contains(namaKolom) Then
                                    dgv_biaya.Rows(rowIndex).Cells(namaKolom).Value = total_biaya
                                Else
                                    MessageBox.Show("Kolom " & namaKolom & " tidak ditemukan di DataGridView!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End Using
                    End Using
                End Using
            Next
        Next

        'Biaya Maintenance Mesin
        Dim maintenancemesin() As String = {"BIAYA MAINTENANCE MESIN"}
        For Each jenisBiaya In maintenancemesin
            ' Pastikan DataGridView memiliki baris kosong untuk jenis biaya ini
            Dim rowIndex As Integer = -1
            For Each row As DataGridViewRow In dgv_biaya.Rows
                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = jenisBiaya Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next

            ' Jika belum ada, tambahkan baris baru
            If rowIndex = -1 Then
                rowIndex = dgv_biaya.Rows.Add(jenisBiaya, "", "", "", "", "", "", "", "", "", "", "", "")
            End If

            ' Loop untuk setiap bulan dari Januari sampai Desember
            For bulan As Integer = 1 To 12
                Dim query As String =
                    "SELECT " &
                    "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                    "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                    "FROM tbpembelian " &
                    "WHERE jenis_biaya = @jenisBiaya " &
                    "AND MONTH(tanggal) = @bulan " &
                    "AND YEAR(tanggal) = @tahun;"

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Using cmd As New MySqlCommand(query, conx)
                        cmd.Parameters.AddWithValue("@jenisBiaya", jenisBiaya)
                        cmd.Parameters.AddWithValue("@bulan", bulan)
                        cmd.Parameters.AddWithValue("@tahun", tahun)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0)
                                Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0)
                                Dim total_biaya As Decimal = total_dpp + total_polos

                                ' Pastikan data masuk ke kolom bulan yang benar
                                Dim namaKolom As String = bulanArray(bulan - 1) ' Ambil nama bulan dari array
                                If dgv_biaya.Columns.Contains(namaKolom) Then
                                    dgv_biaya.Rows(rowIndex).Cells(namaKolom).Value = total_biaya
                                Else
                                    MessageBox.Show("Kolom " & namaKolom & " tidak ditemukan di DataGridView!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End Using
                    End Using
                End Using
            Next
        Next

        'Biaya sewa pabrik
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(sewa_pabrik) AS sewa_pabrik " &
                    "FROM tbbiayatahunan " &
                    "WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim sewa_pabrik As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_pabrik")) Then
                            sewa_pabrik = reader.GetDecimal("sewa_pabrik")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("BIAYA SEWA PABRIK", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = sewa_pabrik
                    End If
                End Using
            End Using
        End Using

        'Keperluan kantor
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "")
        Dim rowIndex1 As Integer = dgv_biaya.Rows.Add("BIAYA KEPERLUAN KANTOR", "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand("SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                            "FROM(tbpembelian) WHERE jenis_biaya = @jenisBiaya AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;", conx)
                    cmd.Parameters.AddWithValue("@jenisBiaya", "BIAYA KEPERLUAN KANTOR")
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_biaya As Decimal = If(reader("total_dpp") IsNot DBNull.Value, reader.GetDecimal("total_dpp"), 0) +
                                                         If(reader("total_polos") IsNot DBNull.Value, reader.GetDecimal("total_polos"), 0)
                            Dim namaKolom As String = bulanArray(bulan - 1)
                            If dgv_biaya.Columns.Contains(namaKolom) Then
                                dgv_biaya.Rows(rowIndex1).Cells(namaKolom).Value = total_biaya
                            End If
                        End If
                    End Using
                End Using
            End Using
        Next

        'Biaya gaji pegawai
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(gaji_pegawai) AS gaji_pegawai " &
                    "FROM tbbiayatahunan " &
                    "WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim gaji_pegawai As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("gaji_pegawai")) Then
                            gaji_pegawai = reader.GetDecimal("gaji_pegawai")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("BIAYA GAJI PEGAWAI", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = gaji_pegawai
                    End If
                End Using
            End Using
        End Using

        'penyusutan kendaraan
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(nilai_penyusutan) AS total_penyusutan " &
                    "FROM tbdatapenyusutan " &
                    "WHERE kategori_aset = 'KENDARAAN' AND tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim total_penyusutan As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("total_penyusutan")) Then
                            total_penyusutan = reader.GetDecimal("total_penyusutan")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("BIAYA PENYUSUTAN KENDARAAN", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = total_penyusutan
                    End If
                End Using
            End Using
        End Using

        'Biaya sewa kantor
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(sewa_kantor) AS sewa_kantor " &
                    "FROM tbbiayatahunan " &
                    "WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim sewa_kantor As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("sewa_kantor")) Then
                            sewa_kantor = reader.GetDecimal("sewa_kantor")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("BIAYA SEWA KANTOR", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = sewa_kantor
                    End If
                End Using
            End Using
        End Using

        'Biaya air telepon
        Dim rowIndex3 As Integer = dgv_biaya.Rows.Add("BIAYA AIR TELEPON", "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand("SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                            "FROM(tbpembelian) WHERE jenis_biaya = @jenisBiaya AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;", conx)
                    cmd.Parameters.AddWithValue("@jenisBiaya", "BIAYA AIR TELEPON")
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_biaya As Decimal = If(reader("total_dpp") IsNot DBNull.Value, reader.GetDecimal("total_dpp"), 0) +
                                                         If(reader("total_polos") IsNot DBNull.Value, reader.GetDecimal("total_polos"), 0)
                            Dim namaKolom As String = bulanArray(bulan - 1)
                            If dgv_biaya.Columns.Contains(namaKolom) Then
                                dgv_biaya.Rows(rowIndex3).Cells(namaKolom).Value = total_biaya
                            End If
                        End If
                    End Using
                End Using
            End Using
        Next

        'Biaya pengiriman
        Dim rowIndex4 As Integer = dgv_biaya.Rows.Add("BIAYA PENGIRIMAN", "", "", "", "", "", "", "", "", "", "", "", "")
        For bulan As Integer = 1 To 12
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Using cmd As New MySqlCommand("SELECT SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                            "FROM(tbpembelian) WHERE jenis_biaya = @jenisBiaya AND MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;", conx)
                    cmd.Parameters.AddWithValue("@jenisBiaya", "BIAYA PENGIRIMAN")
                    cmd.Parameters.AddWithValue("@bulan", bulan)
                    cmd.Parameters.AddWithValue("@tahun", tahun)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total_biaya As Decimal = If(reader("total_dpp") IsNot DBNull.Value, reader.GetDecimal("total_dpp"), 0) +
                                                         If(reader("total_polos") IsNot DBNull.Value, reader.GetDecimal("total_polos"), 0)
                            Dim namaKolom As String = bulanArray(bulan - 1)
                            If dgv_biaya.Columns.Contains(namaKolom) Then
                                dgv_biaya.Rows(rowIndex4).Cells(namaKolom).Value = total_biaya
                            End If
                        End If
                    End Using
                End Using
            End Using
        Next

        'PBB
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String =
                    "SELECT SUM(pbb) AS pbb " &
                    "FROM tbbiayatahunan " &
                    "WHERE tahun = @tahun;"
            Using cmd As New MySqlCommand(query, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim pbb As Decimal = 0
                        If Not reader.IsDBNull(reader.GetOrdinal("pbb")) Then
                            pbb = reader.GetDecimal("pbb")
                        End If
                        Dim rowIndex2 As Integer = dgv_biaya.Rows.Add("PBB", "", "", "", "", "", "", "", "", "", "", "", "")
                        dgv_biaya.Rows(rowIndex2).Cells("Desember").Value = pbb
                    End If
                End Using
            End Using
        End Using

        'Biaya Maintenance
        Dim daftarBiaya2() As String = {"BIAYA MAINTENANCE PERALATAN DAN GEDUNG", "BIAYA MAINTENANCE KENDARAAN"}
        For Each jenisBiaya In daftarBiaya2
            ' Pastikan DataGridView memiliki baris kosong untuk jenis biaya ini
            Dim rowIndex As Integer = -1
            For Each row As DataGridViewRow In dgv_biaya.Rows
                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = jenisBiaya Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next

            ' Jika belum ada, tambahkan baris baru
            If rowIndex = -1 Then
                rowIndex = dgv_biaya.Rows.Add(jenisBiaya, "", "", "", "", "", "", "", "", "", "", "", "")
            End If

            ' Loop untuk setiap bulan dari Januari sampai Desember
            For bulan As Integer = 1 To 12
                Dim query As String =
                    "SELECT " &
                    "SUM(CASE WHEN status = 'ppn' THEN dpp ELSE 0 END) AS total_dpp, " &
                    "SUM(CASE WHEN status = 'polos' THEN total ELSE 0 END) AS total_polos " &
                    "FROM tbpembelian " &
                    "WHERE jenis_biaya = @jenisBiaya " &
                    "AND MONTH(tanggal) = @bulan " &
                    "AND YEAR(tanggal) = @tahun;"

                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Using cmd As New MySqlCommand(query, conx)
                        cmd.Parameters.AddWithValue("@jenisBiaya", jenisBiaya)
                        cmd.Parameters.AddWithValue("@bulan", bulan)
                        cmd.Parameters.AddWithValue("@tahun", tahun)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim total_dpp As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_dpp")), reader.GetDecimal("total_dpp"), 0)
                                Dim total_polos As Decimal = If(Not reader.IsDBNull(reader.GetOrdinal("total_polos")), reader.GetDecimal("total_polos"), 0)
                                Dim total_biaya As Decimal = total_dpp + total_polos

                                ' Pastikan data masuk ke kolom bulan yang benar
                                Dim namaKolom As String = bulanArray(bulan - 1) ' Ambil nama bulan dari array
                                If dgv_biaya.Columns.Contains(namaKolom) Then
                                    dgv_biaya.Rows(rowIndex).Cells(namaKolom).Value = total_biaya
                                Else
                                    MessageBox.Show("Kolom " & namaKolom & " tidak ditemukan di DataGridView!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End Using
                    End Using
                End Using
            Next
        Next
        dgv_biaya.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "")


        ' Terapkan format untuk semua kolom bulan
        For Each bulan In bulanArray
            If dgv_biaya.Columns.Contains(bulan) Then
                dgv_biaya.Columns(bulan).DefaultCellStyle.Format = "#,##0.00"
                dgv_biaya.Columns(bulan).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_biaya.Columns(bulan).Width = 120
            End If
        Next

        dgv_biaya.Columns(0).Width = 300

        Call hitungTotalBiaya()
    End Sub
   
    Private Sub load_sheet_masukan()
        dgv_masukan.Columns.Clear()
        Call setup_dgv_masukan()
        Dim tahun As Integer = dtp_tahun.Value.Year ' Ambil tahun dari DateTimePicker
        ' Query untuk Kain
        Dim query_kain As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total_dpp) AS total_kain " &
            "FROM tbindukpembelian " &
            "WHERE (jenis_biaya = 'GREY' OR jenis_biaya = 'RETUR') AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk Obat
        Dim query_obat As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total_dpp) AS total_obat " &
            "FROM tbindukpembelian " &
            "WHERE jenis_biaya = 'OBAT' AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk Batubara
        Dim query_batubara As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total_dpp) AS total_batubara " &
            "FROM tbindukpembelian " &
            "WHERE jenis_biaya = 'BATUBARA' AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk Lain2
        Dim query_lain2 As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total_dpp) AS total_lain2 " &
            "FROM tbindukpembelian " &
            "WHERE jenis_biaya NOT IN ('GREY', 'RETUR', 'OBAT', 'BATUBARA') AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Kosongkan semua kolom sebelum diisi ulang
        For Each row As DataGridViewRow In dgv_masukan.Rows
            row.Cells("DPP MASUKAN KAIN").Value = 0
            row.Cells("DPP MASUKAN OBAT").Value = 0
            row.Cells("DPP MASUKAN BATUBARA").Value = 0
            row.Cells("DPP MASUKAN LAIN2").Value = 0
            row.Cells("TOTAL DPP MASUKAN").Value = 0
        Next
        ' Proses Masukan
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_kain, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_masukan As Decimal = reader.GetDecimal("total_kain")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_masukan.Rows(bulan - 1).Cells("DPP MASUKAN KAIN").Value = total_masukan
                        End If
                    End While
                End Using
            End Using
            Using cmd As New MySqlCommand(query_obat, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_masukan As Decimal = reader.GetDecimal("total_obat")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_masukan.Rows(bulan - 1).Cells("DPP MASUKAN OBAT").Value = total_masukan
                        End If
                    End While
                End Using
            End Using
            Using cmd As New MySqlCommand(query_batubara, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_masukan As Decimal = reader.GetDecimal("total_batubara")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_masukan.Rows(bulan - 1).Cells("DPP MASUKAN BATUBARA").Value = total_masukan
                        End If
                    End While
                End Using
            End Using
            Using cmd As New MySqlCommand(query_lain2, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_masukan As Decimal = reader.GetDecimal("total_lain2")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_masukan.Rows(bulan - 1).Cells("DPP MASUKAN LAIN2").Value = total_masukan
                        End If
                    End While
                End Using
            End Using
        End Using
        ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
        Dim totalDPPKain As Decimal = 0
        Dim totalDPPObat As Decimal = 0
        Dim totalDPPBatubara As Decimal = 0
        Dim totalDPPLain2 As Decimal = 0
        Dim totalDPPMasukan As Decimal = 0
        For Each row As DataGridViewRow In dgv_masukan.Rows
            If Not row.IsNewRow Then
                ' Ambil nilai dari masing-masing kolom
                Dim dppKain As Decimal = Convert.ToDecimal(row.Cells("DPP MASUKAN KAIN").Value)
                Dim dppObat As Decimal = Convert.ToDecimal(row.Cells("DPP MASUKAN OBAT").Value)
                Dim dppBatubara As Decimal = Convert.ToDecimal(row.Cells("DPP MASUKAN BATUBARA").Value)
                Dim dppLain2 As Decimal = Convert.ToDecimal(row.Cells("DPP MASUKAN LAIN2").Value)
                ' Hitung TOTAL DPP MASUKAN
                Dim total As Decimal = dppKain + dppObat + dppBatubara + dppLain2
                row.Cells("TOTAL DPP MASUKAN").Value = total
                ' Akumulasi untuk baris total
                totalDPPKain += dppKain
                totalDPPObat += dppObat
                totalDPPBatubara += dppBatubara
                totalDPPLain2 += dppLain2
                totalDPPMasukan += total
            End If
        Next
        ' Tambahkan baris total ke dgv_masukan
        Dim index As Integer = dgv_masukan.Rows.Add()
        With dgv_masukan.Rows(index)
            .Cells(0).Value = "" ' Kolom pertama sebagai label
            .Cells("DPP MASUKAN KAIN").Value = totalDPPKain
            .Cells("DPP MASUKAN OBAT").Value = totalDPPObat
            .Cells("DPP MASUKAN BATUBARA").Value = totalDPPBatubara
            .Cells("DPP MASUKAN LAIN2").Value = totalDPPLain2
            .Cells("TOTAL DPP MASUKAN").Value = totalDPPMasukan
        End With
        For Each col As DataGridViewColumn In dgv_masukan.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub setup_dgv_masukan()
        dgv_masukan.ColumnCount = 6
        dgv_masukan.Columns(0).Name = ""
        dgv_masukan.Columns(1).Name = "DPP MASUKAN KAIN"
        dgv_masukan.Columns(2).Name = "DPP MASUKAN OBAT"
        dgv_masukan.Columns(3).Name = "DPP MASUKAN BATUBARA"
        dgv_masukan.Columns(4).Name = "DPP MASUKAN LAIN2"
        dgv_masukan.Columns(5).Name = "TOTAL DPP MASUKAN"

        Dim bulanArray As String() = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For Each bulan As String In bulanArray
            dgv_masukan.Rows.Add(bulan, 0, 0, 0, 0, 0)
        Next
        dgv_masukan.Columns(1).Width = 140
        dgv_masukan.Columns(2).Width = 140
        dgv_masukan.Columns(3).Width = 170
        dgv_masukan.Columns(4).Width = 140
        dgv_masukan.Columns(5).Width = 140
        dgv_masukan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_masukan.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_masukan.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_masukan.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_masukan.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_masukan.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_masukan.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_masukan.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_masukan.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_masukan.Columns(5).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub load_list_masukan_kain()
        dgv_list_kain.Columns.Clear()

        ' Ambil tahun dari DateTimePicker
        Dim tahun As Integer = dtp_tahun.Value.Year
        ' Query untuk Kain pembelian
        Dim query_kain_pembelian As String =
                "SELECT supplier, SUM(total_dpp) AS total_dpp " &
                "FROM tbindukpembelian " &
                "WHERE (jenis_biaya = 'GREY' OR jenis_biaya = 'RETUR') AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' Query untuk Kain pembelian belum upload
        Dim query_kain_belum_upload As String =
                "SELECT supplier, SUM(total_dpp) AS belum_upload, SUM(total_ppn) AS ppn " &
                "FROM tbindukpembelian " &
                "WHERE (jenis_biaya = 'GREY' OR jenis_biaya = 'RETUR') AND YEAR(tanggal) = @tahun AND tanggal_upload IS NULL AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' DataTable untuk menyimpan hasil query pertama
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            ' Eksekusi query pertama
            Using cmd As New MySqlCommand(query_kain_pembelian, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            ' Tambahkan kolom untuk data belum upload dan PPN ke DataTable
            dt.Columns.Add("BELUM DIUPLOAD", GetType(Decimal))
            dt.Columns.Add("PPN", GetType(Decimal))
            ' Eksekusi query kedua dan update DataTable yang sudah ada
            Using cmd As New MySqlCommand(query_kain_belum_upload, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim supplier As String = reader("supplier").ToString()
                        Dim belumUpload As Decimal = If(IsDBNull(reader("belum_upload")), 0, Convert.ToDecimal(reader("belum_upload")))
                        Dim ppn As Decimal = If(IsDBNull(reader("ppn")), 0, Convert.ToDecimal(reader("ppn")))

                        ' Temukan baris yang sesuai di DataTable
                        For Each row As DataRow In dt.Rows
                            If row("supplier").ToString() = supplier Then
                                row("BELUM DIUPLOAD") = belumUpload
                                row("PPN") = ppn
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using
            ' Tampilkan data di DataGridView
            dgv_list_kain.DataSource = dt
            ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
            Dim totalDPP As Decimal = 0
            Dim totalbelumupload As Decimal = 0
            Dim totalppn As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_kain.Rows
                If Not row.IsNewRow Then
                    ' Ambil nilai dari masing-masing kolom
                    'Dim dppKain As Decimal = Convert.ToDecimal(row.Cells(1).Value)
                    'Dim belumupload As Decimal = Convert.ToDecimal(row.Cells(2).Value)
                    'Dim ppnkain As Decimal = Convert.ToDecimal(row.Cells(3).Value)
                    Dim dppKain As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    Dim belumUpload As Decimal = If(IsDBNull(row.Cells(2).Value), 0, Convert.ToDecimal(row.Cells(2).Value))
                    Dim ppnkain As Decimal = If(IsDBNull(row.Cells(3).Value), 0, Convert.ToDecimal(row.Cells(3).Value))

                    ' Akumulasi untuk baris total
                    totalDPP += dppKain
                    totalbelumupload += belumUpload
                    totalppn += ppnkain
                End If
            Next

            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            baris(2) = totalbelumupload
            baris(3) = totalppn
            dt.Rows.Add(baris)

            Call setup_dgv_list_masukan()
            For Each col As DataGridViewColumn In dgv_list_kain.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub load_list_masukan_obat()
        dgv_list_obat.Columns.Clear()

        ' Ambil tahun dari DateTimePicker
        Dim tahun As Integer = dtp_tahun.Value.Year
        ' Query untuk Kain pembelian
        Dim query_kain_pembelian As String =
                "SELECT supplier, SUM(total_dpp) AS total_dpp " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya = 'OBAT' AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' Query untuk Kain pembelian belum upload
        Dim query_kain_belum_upload As String =
                "SELECT supplier, SUM(total_dpp) AS belum_upload, SUM(total_ppn) AS ppn " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya = 'OBAT' AND YEAR(tanggal) = @tahun AND tanggal_upload IS NULL AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' DataTable untuk menyimpan hasil query pertama
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            ' Eksekusi query pertama
            Using cmd As New MySqlCommand(query_kain_pembelian, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            ' Tambahkan kolom untuk data belum upload dan PPN ke DataTable
            dt.Columns.Add("BELUM DIUPLOAD", GetType(Decimal))
            dt.Columns.Add("PPN", GetType(Decimal))
            ' Eksekusi query kedua dan update DataTable yang sudah ada
            Using cmd As New MySqlCommand(query_kain_belum_upload, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim supplier As String = reader("supplier").ToString()
                        Dim belumUpload As Decimal = If(IsDBNull(reader("belum_upload")), 0, Convert.ToDecimal(reader("belum_upload")))
                        Dim ppn As Decimal = If(IsDBNull(reader("ppn")), 0, Convert.ToDecimal(reader("ppn")))

                        ' Temukan baris yang sesuai di DataTable
                        For Each row As DataRow In dt.Rows
                            If row("supplier").ToString() = supplier Then
                                row("BELUM DIUPLOAD") = belumUpload
                                row("PPN") = ppn
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using
            ' Tampilkan data di DataGridView
            dgv_list_obat.DataSource = dt
            ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
            Dim totalDPP As Decimal = 0
            Dim totalbelumupload As Decimal = 0
            Dim totalppn As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_obat.Rows
                If Not row.IsNewRow Then
                    ' Ambil nilai dari masing-masing kolom
                    'Dim dppKain As Decimal = Convert.ToDecimal(row.Cells(1).Value)
                    'Dim belumupload As Decimal = Convert.ToDecimal(row.Cells(2).Value)
                    'Dim ppnkain As Decimal = Convert.ToDecimal(row.Cells(3).Value)
                    Dim dppKain As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    Dim belumUpload As Decimal = If(IsDBNull(row.Cells(2).Value), 0, Convert.ToDecimal(row.Cells(2).Value))
                    Dim ppnkain As Decimal = If(IsDBNull(row.Cells(3).Value), 0, Convert.ToDecimal(row.Cells(3).Value))

                    ' Akumulasi untuk baris total
                    totalDPP += dppKain
                    totalbelumupload += belumUpload
                    totalppn += ppnkain
                End If
            Next

            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            baris(2) = totalbelumupload
            baris(3) = totalppn
            dt.Rows.Add(baris)

            'Call setup_dgv_list_masukan()
            For Each col As DataGridViewColumn In dgv_list_obat.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub load_list_masukan_batubara()
        dgv_list_batubara.Columns.Clear()

        ' Ambil tahun dari DateTimePicker
        Dim tahun As Integer = dtp_tahun.Value.Year
        ' Query untuk Kain pembelian
        Dim query_kain_pembelian As String =
                "SELECT supplier, SUM(total_dpp) AS total_dpp " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya = 'BATUBARA' AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' Query untuk Kain pembelian belum upload
        Dim query_kain_belum_upload As String =
                "SELECT supplier, SUM(total_dpp) AS belum_upload, SUM(total_ppn) AS ppn " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya = 'BATUBARA' AND YEAR(tanggal) = @tahun AND tanggal_upload IS NULL AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' DataTable untuk menyimpan hasil query pertama
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            ' Eksekusi query pertama
            Using cmd As New MySqlCommand(query_kain_pembelian, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            ' Tambahkan kolom untuk data belum upload dan PPN ke DataTable
            dt.Columns.Add("BELUM DIUPLOAD", GetType(Decimal))
            dt.Columns.Add("PPN", GetType(Decimal))
            ' Eksekusi query kedua dan update DataTable yang sudah ada
            Using cmd As New MySqlCommand(query_kain_belum_upload, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim supplier As String = reader("supplier").ToString()
                        Dim belumUpload As Decimal = If(IsDBNull(reader("belum_upload")), 0, Convert.ToDecimal(reader("belum_upload")))
                        Dim ppn As Decimal = If(IsDBNull(reader("ppn")), 0, Convert.ToDecimal(reader("ppn")))

                        ' Temukan baris yang sesuai di DataTable
                        For Each row As DataRow In dt.Rows
                            If row("supplier").ToString() = supplier Then
                                row("BELUM DIUPLOAD") = belumUpload
                                row("PPN") = ppn
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using
            ' Tampilkan data di DataGridView
            dgv_list_batubara.DataSource = dt
            ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
            Dim totalDPP As Decimal = 0
            Dim totalbelumupload As Decimal = 0
            Dim totalppn As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_batubara.Rows
                If Not row.IsNewRow Then
                    ' Ambil nilai dari masing-masing kolom
                    'Dim dppKain As Decimal = Convert.ToDecimal(row.Cells(1).Value)
                    'Dim belumupload As Decimal = Convert.ToDecimal(row.Cells(2).Value)
                    'Dim ppnkain As Decimal = Convert.ToDecimal(row.Cells(3).Value)
                    Dim dppKain As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    Dim belumUpload As Decimal = If(IsDBNull(row.Cells(2).Value), 0, Convert.ToDecimal(row.Cells(2).Value))
                    Dim ppnkain As Decimal = If(IsDBNull(row.Cells(3).Value), 0, Convert.ToDecimal(row.Cells(3).Value))

                    ' Akumulasi untuk baris total
                    totalDPP += dppKain
                    totalbelumupload += belumUpload
                    totalppn += ppnkain
                End If
            Next

            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            baris(2) = totalbelumupload
            baris(3) = totalppn
            dt.Rows.Add(baris)

            'Call setup_dgv_list_masukan()
            For Each col As DataGridViewColumn In dgv_list_batubara.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub load_list_masukan_lain2()
        dgv_list_lain2.Columns.Clear()

        ' Ambil tahun dari DateTimePicker
        Dim tahun As Integer = dtp_tahun.Value.Year
        ' Query untuk Kain pembelian
        Dim query_kain_pembelian As String =
                "SELECT supplier, SUM(total_dpp) AS total_dpp " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya NOT IN ('GREY', 'RETUR', 'OBAT', 'BATUBARA') AND YEAR(tanggal) = @tahun AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' Query untuk Kain pembelian belum upload
        Dim query_kain_belum_upload As String =
                "SELECT supplier, SUM(total_dpp) AS belum_upload, SUM(total_ppn) AS ppn " &
                "FROM tbindukpembelian " &
                "WHERE jenis_biaya NOT IN ('GREY', 'RETUR', 'OBAT', 'BATUBARA') AND YEAR(tanggal) = @tahun AND tanggal_upload IS NULL AND total_dpp <> 0 " &
                "GROUP BY supplier ORDER BY MONTH(tanggal);"
        ' DataTable untuk menyimpan hasil query pertama
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            ' Eksekusi query pertama
            Using cmd As New MySqlCommand(query_kain_pembelian, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            ' Tambahkan kolom untuk data belum upload dan PPN ke DataTable
            dt.Columns.Add("BELUM DIUPLOAD", GetType(Decimal))
            dt.Columns.Add("PPN", GetType(Decimal))
            ' Eksekusi query kedua dan update DataTable yang sudah ada
            Using cmd As New MySqlCommand(query_kain_belum_upload, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim supplier As String = reader("supplier").ToString()
                        Dim belumUpload As Decimal = If(IsDBNull(reader("belum_upload")), 0, Convert.ToDecimal(reader("belum_upload")))
                        Dim ppn As Decimal = If(IsDBNull(reader("ppn")), 0, Convert.ToDecimal(reader("ppn")))

                        ' Temukan baris yang sesuai di DataTable
                        For Each row As DataRow In dt.Rows
                            If row("supplier").ToString() = supplier Then
                                row("BELUM DIUPLOAD") = belumUpload
                                row("PPN") = ppn
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using
            ' Tampilkan data di DataGridView
            dgv_list_lain2.DataSource = dt
            ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
            Dim totalDPP As Decimal = 0
            Dim totalbelumupload As Decimal = 0
            Dim totalppn As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_lain2.Rows
                If Not row.IsNewRow Then
                    ' Ambil nilai dari masing-masing kolom
                    'Dim dppKain As Decimal = Convert.ToDecimal(row.Cells(1).Value)
                    'Dim belumupload As Decimal = Convert.ToDecimal(row.Cells(2).Value)
                    'Dim ppnkain As Decimal = Convert.ToDecimal(row.Cells(3).Value)
                    Dim dppKain As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    Dim belumUpload As Decimal = If(IsDBNull(row.Cells(2).Value), 0, Convert.ToDecimal(row.Cells(2).Value))
                    Dim ppnkain As Decimal = If(IsDBNull(row.Cells(3).Value), 0, Convert.ToDecimal(row.Cells(3).Value))

                    ' Akumulasi untuk baris total
                    totalDPP += dppKain
                    totalbelumupload += belumUpload
                    totalppn += ppnkain
                End If
            Next

            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            baris(2) = totalbelumupload
            baris(3) = totalppn
            dt.Rows.Add(baris)

            'Call setup_dgv_list_masukan()
            For Each col As DataGridViewColumn In dgv_list_lain2.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub gabung_dgv_masukan()
        ' Pastikan dgv_list_masukan kosong sebelum menambahkan data
        dgv_list_masukan.Rows.Clear()
        dgv_list_masukan.Columns.Clear()

        ' Salin struktur kolom dari dgv_list_kain ke dgv_list_masukan
        For Each col As DataGridViewColumn In dgv_list_kain.Columns
            dgv_list_masukan.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next

        Dim emptyRowIndexKain As Integer = dgv_list_masukan.Rows.Add()
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(0).Value = "DATA MASUKAN KAIN" ' Contoh isi kolom pertama
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(2).Value = "BELUM UPLOAD"
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(3).Value = "PPN"
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexKain).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Salin data dari dgv_list_kain ke dgv_list_masukan
        For Each row As DataGridViewRow In dgv_list_kain.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_masukan.Rows.Add(newRow)
            End If
        Next

        ' Tambahkan 2 baris kosong sebagai pemisah
        dgv_list_masukan.Rows.Add()
        Dim emptyRowIndexObat As Integer = dgv_list_masukan.Rows.Add()
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(0).Value = "DATA MASUKAN KIMIA" ' Contoh isi kolom pertama
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(2).Value = "BELUM UPLOAD"
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(3).Value = "PPN"
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexObat).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' Salin data dari dgv_list_obat ke dgv_list_masukan
        For Each row As DataGridViewRow In dgv_list_obat.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_masukan.Rows.Add(newRow)
            End If
        Next

        ' Tambahkan 2 baris kosong sebagai pemisah
        dgv_list_masukan.Rows.Add()
        Dim emptyRowIndexBatubara As Integer = dgv_list_masukan.Rows.Add()
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(0).Value = "DATA MASUKAN BATUBARA" ' Contoh isi kolom pertama
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(2).Value = "BELUM UPLOAD"
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(3).Value = "PPN"
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexBatubara).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' Salin data dari dgv_list_obat ke dgv_list_masukan
        For Each row As DataGridViewRow In dgv_list_batubara.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_masukan.Rows.Add(newRow)
            End If
        Next

        ' Tambahkan 2 baris kosong sebagai pemisah
        dgv_list_masukan.Rows.Add()
        Dim emptyRowIndexlain2 As Integer = dgv_list_masukan.Rows.Add()
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(0).Value = "DATA MASUKAN LAIN2" ' Contoh isi kolom pertama
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(2).Value = "BELUM UPLOAD"
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(3).Value = "PPN"
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_masukan.Rows(emptyRowIndexlain2).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' Salin data dari dgv_list_obat ke dgv_list_masukan
        For Each row As DataGridViewRow In dgv_list_lain2.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_masukan.Rows.Add(newRow)
            End If
        Next

        ' Nonaktifkan sorting agar tampilan tetap sesuai urutan
        For Each col As DataGridViewColumn In dgv_list_masukan.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub setup_dgv_list_masukan()
        dgv_list_kain.Columns(0).HeaderText = "DPP MASUKAN KAIN"
        dgv_list_kain.Columns(1).HeaderText = "TOTAL DPP"
        dgv_list_kain.Columns(2).HeaderText = "BELUM DIUPLOAD"
        dgv_list_kain.Columns(3).HeaderText = "PPN"
        dgv_list_kain.Columns(0).Width = 200
        dgv_list_kain.Columns(1).Width = 140
        dgv_list_kain.Columns(2).Width = 140
        dgv_list_kain.Columns(3).Width = 140
        dgv_list_kain.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_list_kain.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_list_kain.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_list_kain.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_list_kain.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_list_kain.Columns(3).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub load_sheet_keluaran()
        dgv_keluaran.Columns.Clear()
        Call setup_dgv_keluaran()

        Dim tahun As Integer = dtp_tahun.Value.Year ' Ambil tahun dari DateTimePicker

        ' Query untuk Celup
        Dim query_celup As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(dpp) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE status = 'Celup' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk Kain
        Dim query_kain As String =
           "SELECT MONTH(tanggal) AS bulan, SUM(dpp) AS dpp_kain " &
           "FROM tbpenjualan " &
           "WHERE status = 'Kain' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
           "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        Dim query_total As String =
          "SELECT MONTH(tanggal) AS bulan, SUM(dpp) AS dpp_total " &
          "FROM tbpenjualan " &
          "WHERE (status = 'Celup' OR status = 'Kain') AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
          "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        Dim query_spt As String =
            "SELECT FIELD(bulan, 'JANUARY', 'FEBRUARY', 'MARCH', 'APRIL', 'MAY', 'JUNE', " &
            "'JULY', 'AUGUST', 'SEPTEMBER', 'OCTOBER', 'NOVEMBER', 'DECEMBER') AS bulan_num, nilai_keluaran " &
            "FROM tbsptppn " &
            "WHERE tahun = @tahun " &
            "ORDER BY bulan_num;"
        Dim query_kg As String =
          "SELECT MONTH(tanggal) AS bulan, SUM(jumlah) AS jumlah_kg " &
          "FROM tbpenjualan " &
          "WHERE satuan = 'Kg' AND YEAR(tanggal) = @tahun AND dpp <> 0 AND jenis_biaya = 'Jasa' " &
          "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        Dim query_Meter As String =
        "SELECT MONTH(tanggal) AS bulan, SUM(jumlah) AS jumlah_meter " &
        "FROM tbpenjualan " &
        "WHERE satuan = 'Meter' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
        "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        Dim query_Yard As String =
        "SELECT MONTH(tanggal) AS bulan, SUM(jumlah) AS jumlah_yard " &
        "FROM tbpenjualan " &
        "WHERE satuan = 'Yard' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
        "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"

        ' Kosongkan semua kolom sebelum diisi ulang
        For Each row As DataGridViewRow In dgv_keluaran.Rows
            row.Cells("DPP CELUP").Value = 0
            row.Cells("DPP KAIN").Value = 0
            row.Cells("DPP TOTAL").Value = 0
            row.Cells("DPP SESUAI SPT").Value = 0
            row.Cells("SELISIH").Value = 0
            row.Cells("KOSONG").Value = ""
            row.Cells("KG CELUPAN").Value = 0
            row.Cells("MTR KAIN").Value = 0
            row.Cells("YARD KAIN").Value = 0
        Next

        'Proses(Keluaran)
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("dpp_celup")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("DPP CELUP").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_kain, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("dpp_kain")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("DPP KAIN").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_total, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("dpp_total")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("DPP TOTAL").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_spt, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan_num") ' Ambil nilai angka bulan
                        Dim total_keluaran As Decimal = reader.GetDecimal("nilai_keluaran")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("DPP SESUAI SPT").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_kg, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("jumlah_kg")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("KG CELUPAN").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_Meter, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("jumlah_meter")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("MTR KAIN").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_Yard, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_keluaran As Decimal = reader.GetDecimal("jumlah_yard")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_keluaran.Rows(bulan - 1).Cells("YARD KAIN").Value = total_keluaran
                        End If
                    End While
                End Using
            End Using
        End Using

        ' Pastikan dgv_keluaran sudah memiliki data sebelum menjalankan kode ini
        Dim totalDPPCelup As Decimal = 0
        Dim totalDPPKain As Decimal = 0
        Dim totalDPPTotal As Decimal = 0
        Dim totalDPPSesuaiSPT As Decimal = 0
        Dim totalDPPSelisih As Decimal = 0
        Dim totalKgCelup As Decimal = 0
        Dim totalMtrKain As Decimal = 0
        Dim totalYardKain As Decimal = 0

        For Each row As DataGridViewRow In dgv_keluaran.Rows
            If Not row.IsNewRow Then
                ' Ambil nilai dari masing-masing kolom
                Dim dppcelup As Decimal = Convert.ToDecimal(row.Cells("DPP CELUP").Value)
                Dim dppkain As Decimal = Convert.ToDecimal(row.Cells("DPP KAIN").Value)
                Dim dpptotal As Decimal = Convert.ToDecimal(row.Cells("DPP TOTAL").Value)
                Dim dppsesuaispt As Decimal = Convert.ToDecimal(row.Cells("DPP SESUAI SPT").Value)

                ' Hitung SELISIH
                Dim selisih As Decimal = dpptotal - dppsesuaispt
                row.Cells("SELISIH").Value = selisih

                Dim dppselisih As Decimal = Convert.ToDecimal(row.Cells("SELISIH").Value)
                Dim kgcelup As Decimal = Convert.ToDecimal(row.Cells("KG CELUPAN").Value)
                Dim mtrkain As Decimal = Convert.ToDecimal(row.Cells("MTR KAIN").Value)
                Dim yardkain As Decimal = Convert.ToDecimal(row.Cells("YARD KAIN").Value)

                ' Akumulasi untuk baris total
                totalDPPCelup += dppcelup
                totalDPPKain += dppkain
                totalDPPTotal += dpptotal
                totalDPPSesuaiSPT += dppsesuaispt
                totalDPPSelisih += dppselisih
                totalKgCelup += kgcelup
                totalMtrKain += mtrkain
                totalYardKain += yardkain
            End If
        Next

        ' Tambahkan baris total ke dgv_keluaran
        Dim index As Integer = dgv_keluaran.Rows.Add()
        With dgv_keluaran.Rows(index)
            .Cells(0).Value = "" ' Kolom pertama sebagai label
            .Cells("DPP CELUP").Value = totalDPPCelup
            .Cells("DPP KAIN").Value = totalDPPKain
            .Cells("DPP TOTAL").Value = totalDPPTotal
            .Cells("DPP SESUAI SPT").Value = totalDPPSesuaiSPT
            .Cells("SELISIH").Value = totalDPPSelisih
            .Cells("KG CELUPAN").Value = totalKgCelup
            .Cells("MTR KAIN").Value = totalMtrKain
            .Cells("YARD KAIN").Value = totalYardKain
        End With

        For Each col As DataGridViewColumn In dgv_keluaran.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        pendapatan = dgv_keluaran.Rows(12).Cells(4).Value

    End Sub
    Private Sub setup_dgv_keluaran()
        dgv_keluaran.ColumnCount = 10
        dgv_keluaran.Columns(0).Name = "BULAN"
        dgv_keluaran.Columns(1).Name = "DPP CELUP"
        dgv_keluaran.Columns(1).HeaderText = "DPP CELUPAN"
        dgv_keluaran.Columns(2).Name = "DPP KAIN"
        dgv_keluaran.Columns(3).Name = "DPP TOTAL"
        dgv_keluaran.Columns(4).Name = "DPP SESUAI SPT"
        dgv_keluaran.Columns(5).Name = "SELISIH"
        dgv_keluaran.Columns(6).Name = "KOSONG"
        dgv_keluaran.Columns(6).HeaderText = ""
        dgv_keluaran.Columns(7).Name = "KG CELUPAN"
        dgv_keluaran.Columns(8).Name = "MTR KAIN"
        dgv_keluaran.Columns(9).Name = "YARD KAIN"

        Dim bulanArray As String() = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For Each bulan As String In bulanArray
            dgv_keluaran.Rows.Add(bulan, 0, 0, 0, 0, 0, "", 0, 0, 0)
        Next
        dgv_keluaran.Columns(1).Width = 130
        dgv_keluaran.Columns(2).Width = 130
        dgv_keluaran.Columns(3).Width = 140
        dgv_keluaran.Columns(4).Width = 140
        dgv_keluaran.Columns(5).Width = 70
        dgv_keluaran.Columns(6).Width = 40
        dgv_keluaran.Columns(7).Width = 100
        dgv_keluaran.Columns(8).Width = 100
        dgv_keluaran.Columns(9).Width = 100
        dgv_keluaran.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_keluaran.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv_keluaran.Columns(9).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv_keluaran_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_keluaran.CellFormatting
        If dgv_keluaran.Columns(e.ColumnIndex).Name = "SELISIH" Then
            ' Pastikan nilai tidak kosong dan merupakan angka
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value.ToString()) Then
                Dim nilai As Decimal
                ' Gunakan TryParse untuk menghindari error konversi
                If Decimal.TryParse(e.Value.ToString(), nilai) Then
                    ' Cek jika nilai lebih dari 100
                    If nilai > 100 Or nilai < -100 Then
                        dgv_keluaran.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.White
                        dgv_keluaran.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
                    Else
                        dgv_keluaran.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
                    End If
                End If
            Else
                ' Jika nilai tidak valid, pastikan warna tetap default (opsional)
                dgv_keluaran.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
            End If
        End If
        ' Periksa apakah nilai di sel adalah numerik
        If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)
            If nilai < 0 Then
                ' Format nilai negatif dengan tanda kurung
                e.Value = "(" & Format(Math.Abs(nilai), "#,##0.00") & ")"
                e.FormattingApplied = True
            Else
                ' Format nilai positif atau nol tanpa tanda kurung
                e.Value = Format(nilai, "#,##0.00")
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub load_list_dpp_celup()
        dgv_list_celup.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(dpp) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE status = 'Celup' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_list_celup.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_celup.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)

            Call setup_dgv_list_keluaran()
            For Each col As DataGridViewColumn In dgv_list_celup.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub load_list_dpp_kain()
        dgv_list_keluaran_kain.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(dpp) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE status = 'Kain' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_list_keluaran_kain.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_keluaran_kain.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)
            For Each col As DataGridViewColumn In dgv_list_keluaran_kain.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using
    End Sub
    Private Sub load_list_dpp_total()
        dgv_list_keluaran_total.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(dpp) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE (status = 'Celup' OR status = 'Kain') AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_list_keluaran_total.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_list_keluaran_total.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)
            For Each col As DataGridViewColumn In dgv_list_keluaran_total.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using
    End Sub
    Private Sub gabung_dgv_keluaran()
        ' Pastikan dgv_list_keluaran kosong sebelum menambahkan data
        dgv_list_keluaran.Rows.Clear()
        dgv_list_keluaran.Columns.Clear()
        For Each col As DataGridViewColumn In dgv_list_celup.Columns
            dgv_list_keluaran.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next
        Dim emptyRowIndexKain As Integer = dgv_list_keluaran.Rows.Add()
        dgv_list_keluaran.Rows(emptyRowIndexKain).Cells(0).Value = "DPP CELUPAN" ' Contoh isi kolom pertama
        dgv_list_keluaran.Rows(emptyRowIndexKain).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_keluaran.Rows(emptyRowIndexKain).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_keluaran.Rows(emptyRowIndexKain).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_list_celup.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_keluaran.Rows.Add(newRow)
            End If
        Next

        dgv_list_keluaran.Rows.Add()
        Dim emptyRowIndexObat As Integer = dgv_list_keluaran.Rows.Add()
        dgv_list_keluaran.Rows(emptyRowIndexObat).Cells(0).Value = "DPP KAIN" ' Contoh isi kolom pertama
        dgv_list_keluaran.Rows(emptyRowIndexObat).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_keluaran.Rows(emptyRowIndexObat).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_keluaran.Rows(emptyRowIndexObat).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_list_keluaran_kain.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_keluaran.Rows.Add(newRow)
            End If
        Next

        dgv_list_keluaran.Rows.Add()
        Dim emptyRowIndextotal As Integer = dgv_list_keluaran.Rows.Add()
        dgv_list_keluaran.Rows(emptyRowIndextotal).Cells(0).Value = "DPP TOTAL" ' Contoh isi kolom pertama
        dgv_list_keluaran.Rows(emptyRowIndextotal).Cells(1).Value = "TOTAL DPP" ' Kosongkan kolom lainnya
        dgv_list_keluaran.Rows(emptyRowIndextotal).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_list_keluaran.Rows(emptyRowIndextotal).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_list_keluaran_total.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_list_keluaran.Rows.Add(newRow)
            End If
        Next



        For Each col As DataGridViewColumn In dgv_list_keluaran.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub setup_dgv_list_keluaran()
        dgv_list_celup.Columns(0).HeaderText = "DPP CELUPAN"
        dgv_list_celup.Columns(1).HeaderText = "TOTAL DPP"
        dgv_list_celup.Columns(0).Width = 200
        dgv_list_celup.Columns(1).Width = 140
        dgv_list_celup.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_list_celup.Columns(1).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub load_list_kg()
        dgv_satuan_kg.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(jumlah) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE satuan = 'Kg' AND YEAR(tanggal) = @tahun AND dpp <> 0 AND jenis_biaya = 'Jasa'  " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_satuan_kg.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_satuan_kg.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)

            Call setup_dgv_list_keluaran_satuan()
            For Each col As DataGridViewColumn In dgv_satuan_kg.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using

    End Sub
    Private Sub load_list_mtr()
        dgv_satuan_mtr.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(jumlah) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE satuan = 'Meter' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_satuan_mtr.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_satuan_mtr.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)
            For Each col As DataGridViewColumn In dgv_satuan_mtr.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using
    End Sub
    Private Sub load_list_yard()
        dgv_satuan_yard.Columns.Clear()
        Dim tahun As Integer = dtp_tahun.Value.Year
        Dim query_celup As String =
            "SELECT supplier, SUM(jumlah) AS dpp_celup " &
            "FROM tbpenjualan " &
            "WHERE satuan = 'Yard' AND YEAR(tanggal) = @tahun AND dpp <> 0 " &
            "GROUP BY supplier ORDER BY MONTH(tanggal);"
        Dim dt As New DataTable()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(query_celup, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            dgv_satuan_yard.DataSource = dt
            Dim totalDPP As Decimal = 0
            For Each row As DataGridViewRow In dgv_satuan_yard.Rows
                If Not row.IsNewRow Then
                    Dim dppcelup As Decimal = If(IsDBNull(row.Cells(1).Value), 0, Convert.ToDecimal(row.Cells(1).Value))
                    ' Akumulasi untuk baris total
                    totalDPP += dppcelup
                End If
            Next
            Dim baris As DataRow = dt.NewRow()
            baris(0) = "" ' Kolom pertama sebagai label
            baris(1) = totalDPP
            dt.Rows.Add(baris)
            For Each col As DataGridViewColumn In dgv_satuan_yard.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End Using
    End Sub
    Private Sub gabung_dgv_keluaran_satuan()
        ' Pastikan dgv_keluaran_satuan kosong sebelum menambahkan data
        dgv_keluaran_satuan.Rows.Clear()
        dgv_keluaran_satuan.Columns.Clear()
        For Each col As DataGridViewColumn In dgv_satuan_kg.Columns
            dgv_keluaran_satuan.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next
        Dim emptyRowIndexKain As Integer = dgv_keluaran_satuan.Rows.Add()
        dgv_keluaran_satuan.Rows(emptyRowIndexKain).Cells(0).Value = "KG CELUPAN" ' Contoh isi kolom pertama
        dgv_keluaran_satuan.Rows(emptyRowIndexKain).Cells(1).Value = "JUMLAH" ' Kosongkan kolom lainnya
        dgv_keluaran_satuan.Rows(emptyRowIndexKain).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_keluaran_satuan.Rows(emptyRowIndexKain).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_satuan_kg.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_keluaran_satuan.Rows.Add(newRow)
            End If
        Next

        dgv_keluaran_satuan.Rows.Add()
        Dim emptyRowIndexObat As Integer = dgv_keluaran_satuan.Rows.Add()
        dgv_keluaran_satuan.Rows(emptyRowIndexObat).Cells(0).Value = "MTR KAIN" ' Contoh isi kolom pertama
        dgv_keluaran_satuan.Rows(emptyRowIndexObat).Cells(1).Value = "JUMLAH" ' Kosongkan kolom lainnya
        dgv_keluaran_satuan.Rows(emptyRowIndexObat).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_keluaran_satuan.Rows(emptyRowIndexObat).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_satuan_mtr.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_keluaran_satuan.Rows.Add(newRow)
            End If
        Next

        dgv_keluaran_satuan.Rows.Add()
        Dim emptyRowIndextotal As Integer = dgv_keluaran_satuan.Rows.Add()
        dgv_keluaran_satuan.Rows(emptyRowIndextotal).Cells(0).Value = "YARD KAIN" ' Contoh isi kolom pertama
        dgv_keluaran_satuan.Rows(emptyRowIndextotal).Cells(1).Value = "JUMLAH" ' Kosongkan kolom lainnya
        dgv_keluaran_satuan.Rows(emptyRowIndextotal).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_keluaran_satuan.Rows(emptyRowIndextotal).Cells(1).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        For Each row As DataGridViewRow In dgv_satuan_yard.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_keluaran_satuan.Rows.Add(newRow)
            End If
        Next
        For Each col As DataGridViewColumn In dgv_keluaran_satuan.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub setup_dgv_list_keluaran_satuan()
        dgv_satuan_kg.Columns(0).HeaderText = "DPP CELUPAN"
        dgv_satuan_kg.Columns(1).HeaderText = "TOTAL DPP"
        dgv_satuan_kg.Columns(0).Width = 200
        dgv_satuan_kg.Columns(1).Width = 140
        dgv_satuan_kg.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_satuan_kg.Columns(1).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub tampil_data_bukpot()
        dgv_bukpot.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim selectedYear As Integer = dtp_tahun.Value.Year
            Dim sqlx As String = "SELECT id_jual, supplier, npwp, tanggal, no_faktur, dpp, ppn, pph23, pph23_actual, no_bukpot, tgl_bukpot, masa_bukpot, gabung_bukpot " &
                                 "FROM tbpenjualan " &
                                 "WHERE no_bukpot <> '' " &
                                 "AND jenis_biaya = 'Jasa' " &
                                 "AND no_faktur <> '' " &
                                 "AND YEAR(masa_bukpot) = " & selectedYear & " " &
                                 "ORDER BY tgl_bukpot ASC, no_bukpot ASC, supplier ASC, pph23_actual DESC"

            Using cmdx As New MySqlCommand(sqlx, conx)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbpenjualan")
                        dgv_bukpot.DataSource = dsx.Tables("tbpenjualan")
                    End Using
                End Using
            End Using
        End Using

        dgv_bukpot.Columns(1).HeaderText = "CUSTOMER"
        dgv_bukpot.Columns(2).HeaderText = "NPWP"
        dgv_bukpot.Columns(3).HeaderText = "TANGGAL"
        dgv_bukpot.Columns(4).HeaderText = "NO FAKTUR"
        dgv_bukpot.Columns(5).HeaderText = "DPP"
        dgv_bukpot.Columns(6).HeaderText = "PPN"
        dgv_bukpot.Columns(7).HeaderText = "PPH 23"
        dgv_bukpot.Columns(8).HeaderText = "PPH23 ACTUAL"
        dgv_bukpot.Columns(9).HeaderText = "NO BUKPOT"
        dgv_bukpot.Columns(10).HeaderText = "TGL BUKPOT"
        dgv_bukpot.Columns(11).HeaderText = "MASA BUKPOT"
        For Each column As DataGridViewColumn In dgv_bukpot.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_bukpot.RowHeadersWidth = 60
        dgv_bukpot.Columns(0).Visible = False
        dgv_bukpot.Columns(12).Visible = False
        dgv_bukpot.Columns(1).Width = 220
        dgv_bukpot.Columns(2).Width = 160
        dgv_bukpot.Columns(3).Width = 85
        dgv_bukpot.Columns(4).Width = 160
        dgv_bukpot.Columns(5).Width = 120
        dgv_bukpot.Columns(6).Width = 120
        dgv_bukpot.Columns(7).Width = 120
        dgv_bukpot.Columns(8).Width = 140
        dgv_bukpot.Columns(9).Width = 120
        dgv_bukpot.Columns(10).Width = 120
        dgv_bukpot.Columns(11).Width = 120
        dgv_bukpot.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot.Columns(10).DefaultCellStyle.Format = "dd-MMM-yy"
        dgv_bukpot.Columns(11).DefaultCellStyle.Format = "MMMM-yy"

        For Each col As DataGridViewColumn In dgv_bukpot.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub dgv_bukpot_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_bukpot.CellFormatting
        dgv_bukpot.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub

    Private Sub LoadDataPLN()
        dgv_pln.Columns.Clear()
        Call setup_dgv_pln()
        Dim tahun As Integer = dtp_tahun.Value.Year ' Ambil tahun dari DateTimePicker
        ' Query untuk PLN
        Dim queryPLN As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total) AS total_pln " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA LISTRIK PABRIK' AND YEAR(tanggal) = @tahun " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk GARAM
        Dim queryGARAM As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(total) AS total_garam " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BIAYA GARAM' AND YEAR(tanggal) = @tahun " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Query untuk COAL
        Dim queryCOAL As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(dpp) AS total_coal " &
            "FROM tbpembelian " &
            "WHERE jenis_biaya = 'BATUBARA' AND YEAR(tanggal) = @tahun " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Kosongkan semua kolom sebelum diisi ulang
        For Each row As DataGridViewRow In dgv_pln.Rows
            row.Cells("PLN").Value = 0
            row.Cells("GARAM").Value = 0
            row.Cells("COAL").Value = 0
            row.Cells("PPH 22 COAL").Value = 0
        Next
        ' Proses PLN
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(queryPLN, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_pln As Decimal = reader.GetDecimal("total_pln")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_pln.Rows(bulan - 1).Cells("PLN").Value = total_pln
                        End If
                    End While
                End Using
            End Using
            ' Proses GARAM
            Using cmd As New MySqlCommand(queryGARAM, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_garam As Decimal = reader.GetDecimal("total_garam")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_pln.Rows(bulan - 1).Cells("GARAM").Value = total_garam
                        End If
                    End While
                End Using
            End Using
            ' Proses COAL
            Using cmd As New MySqlCommand(queryCOAL, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_coal As Decimal = reader.GetDecimal("total_coal")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_pln.Rows(bulan - 1).Cells("COAL").Value = total_coal
                            ' Hitung PPH 22 COAL (COAL * PPN 22 dari variabel global)
                            dgv_pln.Rows(bulan - 1).Cells("PPH 22 COAL").Value = total_coal * (pph22 / 100)
                        End If
                    End While
                End Using
            End Using
        End Using

        ' Pastikan dgv_masukan sudah memiliki data sebelum menjalankan kode ini
        Dim totalDPPKain As Decimal = 0
        Dim totalDPPObat As Decimal = 0
        Dim totalDPPBatubara As Decimal = 0
        Dim totalDPPLain2 As Decimal = 0
        For Each row As DataGridViewRow In dgv_pln.Rows
            If Not row.IsNewRow Then
                ' Ambil nilai dari masing-masing kolom
                Dim dppKain As Decimal = Convert.ToDecimal(row.Cells("PLN").Value)
                Dim dppObat As Decimal = Convert.ToDecimal(row.Cells("GARAM").Value)
                Dim dppBatubara As Decimal = Convert.ToDecimal(row.Cells("COAL").Value)
                Dim dppLain2 As Decimal = Convert.ToDecimal(row.Cells("PPH 22 COAL").Value)
                ' Akumulasi untuk baris total
                totalDPPKain += dppKain
                totalDPPObat += dppObat
                totalDPPBatubara += dppBatubara
                totalDPPLain2 += dppLain2
            End If
        Next
        ' Tambahkan baris total ke dgv_masukan
        Dim index As Integer = dgv_pln.Rows.Add()
        With dgv_pln.Rows(index)
            .Cells(0).Value = "" ' Kolom pertama sebagai label
            .Cells("PLN").Value = totalDPPKain
            .Cells("GARAM").Value = totalDPPObat
            .Cells("COAL").Value = totalDPPBatubara
            .Cells("PPH 22 COAL").Value = totalDPPLain2
        End With

        For Each col As DataGridViewColumn In dgv_pln.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub setup_dgv_pln()
        dgv_pln.ColumnCount = 5
        dgv_pln.Columns(0).Name = ""
        dgv_pln.Columns(1).Name = "PLN"
        dgv_pln.Columns(2).Name = "GARAM"
        dgv_pln.Columns(3).Name = "COAL"
        dgv_pln.Columns(4).Name = "PPH 22 COAL"

        Dim bulanArray As String() = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For Each bulan As String In bulanArray
            dgv_pln.Rows.Add(bulan, 0, 0, 0, 0)
        Next
        dgv_pln.Columns(1).Width = 120
        dgv_pln.Columns(2).Width = 120
        dgv_pln.Columns(3).Width = 120
        dgv_pln.Columns(4).Width = 120
        dgv_pln.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_pln.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_pln.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_pln.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_pln.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_pln.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_pln.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_pln.Columns(4).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub tampil_spt()
        dgv_spt_aml.Columns.Clear()
        Call headertablesptaml()
        Dim tahun As Integer = dtp_tahun.Value.Year ' Ambil tahun dari DateTimePicker
        ' Query untuk Pembelian
        Dim querypembelian As String =
            "SELECT MONTH(tanggal_upload) AS bulan, SUM(total_dpp) AS total_beli, SUM(total_ppn) AS total_ppn_beli " &
            "FROM tbindukpembelian " &
            "WHERE YEAR(tanggal_upload) = @tahun " &
            "GROUP BY MONTH(tanggal_upload) ORDER BY MONTH(tanggal_upload);"
        ' Query untuk Penjualan
        Dim querypenjualan As String =
            "SELECT MONTH(tanggal) AS bulan, SUM(dpp) AS total_jual, SUM(ppn) AS total_ppn_jual " &
            "FROM tbpenjualan " &
            "WHERE YEAR(tanggal) = @tahun " &
            "GROUP BY MONTH(tanggal) ORDER BY MONTH(tanggal);"
        ' Kosongkan semua kolom sebelum diisi ulang
        For Each row As DataGridViewRow In dgv_spt_aml.Rows
            row.Cells("NILAI MASUKAN").Value = 0
            row.Cells("NILAI KELUARAN").Value = 0
            row.Cells("PPN MASUKAN").Value = 0
            row.Cells("PPN KELUARAN").Value = 0
            row.Cells("PPN DISETOR").Value = 0
        Next
        ' Proses Pembelian
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Using cmd As New MySqlCommand(querypembelian, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_beli As Decimal = reader.GetDecimal("total_beli")
                        Dim total_ppn_beli As Decimal = reader.GetDecimal("total_ppn_beli")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_spt_aml.Rows(bulan - 1).Cells("NILAI MASUKAN").Value = total_beli
                            dgv_spt_aml.Rows(bulan - 1).Cells("PPN MASUKAN").Value = total_ppn_beli
                        End If
                    End While
                End Using
            End Using
            ' Proses Penjualan
            Using cmd As New MySqlCommand(querypenjualan, conx)
                cmd.Parameters.AddWithValue("@tahun", tahun)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bulan As Integer = reader.GetInt32("bulan")
                        Dim total_jual As Decimal = reader.GetDecimal("total_jual")
                        Dim total_ppn_jual As Decimal = reader.GetDecimal("total_ppn_jual")
                        If bulan >= 1 And bulan <= 12 Then
                            dgv_spt_aml.Rows(bulan - 1).Cells("NILAI KELUARAN").Value = total_jual
                            dgv_spt_aml.Rows(bulan - 1).Cells("PPN KELUARAN").Value = total_ppn_jual
                        End If
                    End While
                End Using
            End Using
            ' Hitung PPN DISETOR
            For Each row As DataGridViewRow In dgv_spt_aml.Rows
                ' Pastikan baris bukan baris kosong baru
                If Not row.IsNewRow Then
                    ' Ambil nilai PPN Keluaran dan PPN Masukan
                    Dim ppnKeluaran As Decimal = 0
                    Dim ppnMasukan As Decimal = 0

                    ' Pastikan nilai tidak kosong sebelum parsing
                    If Not IsDBNull(row.Cells("PPN KELUARAN").Value) AndAlso IsNumeric(row.Cells("PPN KELUARAN").Value) Then
                        ppnKeluaran = Convert.ToDecimal(row.Cells("PPN KELUARAN").Value)
                    End If
                    If Not IsDBNull(row.Cells("PPN MASUKAN").Value) AndAlso IsNumeric(row.Cells("PPN MASUKAN").Value) Then
                        ppnMasukan = Convert.ToDecimal(row.Cells("PPN MASUKAN").Value)
                    End If

                    ' Hitung selisih
                    Dim selisihPPN As Decimal = ppnKeluaran - ppnMasukan

                    ' Masukkan selisih ke kolom baru
                    row.Cells("PPN DISETOR").Value = selisihPPN
                End If
            Next
        End Using

        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim selectedYear As Integer = dtp_tahun.Value.Year
            Dim sqlx As String = "SELECT bulan, nilai_masukan, nilai_keluaran, ppn_masukan, ppn_keluaran, ppn_disetor " &
                                 "FROM tbsptppn " &
                                 "WHERE tahun = @selectedYear " &
                                 "ORDER BY FIELD(bulan, 'January', 'February', 'March', 'April', 'May', 'June', " &
                                 "'July', 'August', 'September', 'October', 'November', 'December')"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@selectedYear", selectedYear)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "spt_ppn")
                        dgv_spt_efaktur.DataSource = dsx.Tables("spt_ppn")
                    End Using
                End Using
            End Using
        End Using

        ' Clear dgv_spt_clone before populating
        dgv_spt_clone.Columns.Clear()
        dgv_spt_clone.Rows.Clear()

        ' Copy columns from dgv_spt_efaktur to dgv_spt_clone
        For Each col As DataGridViewColumn In dgv_spt_efaktur.Columns
            Dim newCol As New DataGridViewColumn(col.CellTemplate)
            newCol.HeaderText = col.HeaderText
            newCol.Name = col.Name
            newCol.Width = col.Width
            dgv_spt_clone.Columns.Add(newCol)
        Next

        ' Add new column "SELISIH PPN" at the end
        Dim selisihPpnCol As New DataGridViewTextBoxColumn()
        selisihPpnCol.HeaderText = "SELISIH PPN"
        selisihPpnCol.Name = "SELISIH PPN"
        dgv_spt_clone.Columns.Add(selisihPpnCol)

        ' Copy rows from dgv_spt_efaktur to dgv_spt_clone
        For Each row As DataGridViewRow In dgv_spt_efaktur.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_spt_clone.Rows.Add(newRow)
            End If
        Next

        For i As Integer = 0 To dgv_spt_clone.Rows.Count - 1
            ' Pastikan kolom pada kedua DataGridView memiliki data numerik
            Dim value1 As Decimal = 0
            Dim value2 As Decimal = 0
            Dim hasil As Decimal = 0
            ' Cek apakah data di dgv_spt_aml valid dan numerik
            If Not IsDBNull(dgv_spt_aml.Rows(i).Cells(5).Value) AndAlso IsNumeric(dgv_spt_aml.Rows(i).Cells(5).Value) Then
                value1 = Convert.ToDecimal(dgv_spt_aml.Rows(i).Cells(5).Value)
            End If
            ' Cek apakah data di dgv_spt_efaktur valid dan numerik
            If Not IsDBNull(dgv_spt_efaktur.Rows(i).Cells(5).Value) AndAlso IsNumeric(dgv_spt_efaktur.Rows(i).Cells(5).Value) Then
                value2 = Convert.ToDecimal(dgv_spt_efaktur.Rows(i).Cells(5).Value)
            End If
            ' Jumlahkan kedua nilai dan masukkan hasilnya ke dgv_spt_aml
            hasil = value1 - value2
            dgv_spt_clone.Rows(i).Cells("SELISIH PPN").Value = hasil
        Next

        ' Tambahkan kolom "TDK DIGUNGGUNG" setelah "NILAI KELUARAN"
        Dim kolomTdkDigunggung As New DataGridViewTextBoxColumn()
        kolomTdkDigunggung.Name = "TDK DIGUNGGUNG"
        kolomTdkDigunggung.HeaderText = "TDK DIGUNGGUNG"
        dgv_spt_clone.Columns.Insert(2 + 1, kolomTdkDigunggung)

        ' Tambahkan kolom "DIGUNGGUNG" setelah "TDK DIGUNGGUNG"
        Dim kolomDigunggung As New DataGridViewTextBoxColumn()
        kolomDigunggung.Name = "DIGUNGGUNG"
        kolomDigunggung.HeaderText = "DIGUNGGUNG"
        dgv_spt_clone.Columns.Insert(2 + 2, kolomDigunggung)

        ' Tambahkan kolom "TDK DIGUNGGUNG" setelah "NILAI KELUARAN"
        Dim kolomTdkDigunggungamal As New DataGridViewTextBoxColumn()
        kolomTdkDigunggungamal.Name = "TDK DIGUNGGUNG"
        kolomTdkDigunggungamal.HeaderText = "TDK DIGUNGGUNG"
        dgv_spt_aml.Columns.Insert(2 + 1, kolomTdkDigunggungamal)

        ' Tambahkan kolom "Digunggungamal" setelah "TDK Digunggungamal"
        Dim kolomDigunggungamal As New DataGridViewTextBoxColumn()
        kolomDigunggungamal.Name = "DIGUNGGUNG"
        kolomDigunggungamal.HeaderText = "DIGUNGGUNG"
        dgv_spt_aml.Columns.Insert(2 + 2, kolomDigunggungamal)

        ' Pastikan nilai awal pada kolom-kolom baru adalah kosong
        For Each row As DataGridViewRow In dgv_spt_clone.Rows
            row.Cells("TDK DIGUNGGUNG").Value = ""
            row.Cells("DIGUNGGUNG").Value = ""
        Next
        For Each row As DataGridViewRow In dgv_spt_aml.Rows
            row.Cells("TDK DIGUNGGUNG").Value = ""
            row.Cells("DIGUNGGUNG").Value = ""
        Next

        Call headertablesptclone()
        Call headertablesptamltambah()

        For Each col As DataGridViewColumn In dgv_spt_clone.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each col As DataGridViewColumn In dgv_spt_aml.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub headertablesptclone()
        dgv_spt_clone.Columns(0).HeaderText = "SPT EFAKTUR"
        dgv_spt_clone.Columns(1).HeaderText = "NILAI MASUKAN"
        dgv_spt_clone.Columns(2).HeaderText = "NILAI KELUARAN"
        dgv_spt_clone.Columns(3).HeaderText = "TDK DIGUNGGUNG"
        dgv_spt_clone.Columns(4).HeaderText = "DIGUNGGUNG"
        dgv_spt_clone.Columns(5).HeaderText = "PPN MASUKAN"
        dgv_spt_clone.Columns(6).HeaderText = "PPN KELUARAN"
        dgv_spt_clone.Columns(7).HeaderText = "PPN DISETOR"
        For Each column As DataGridViewColumn In dgv_spt_clone.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_spt_clone.Columns(0).Width = 100
        dgv_spt_clone.Columns(1).Width = 130
        dgv_spt_clone.Columns(2).Width = 130
        dgv_spt_clone.Columns(3).Width = 100
        dgv_spt_clone.Columns(4).Width = 100
        dgv_spt_clone.Columns(5).Width = 120
        dgv_spt_clone.Columns(6).Width = 120
        dgv_spt_clone.Columns(7).Width = 110
        dgv_spt_clone.Columns(8).Width = 110
        dgv_spt_clone.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_clone.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_clone.Columns(8).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub headertablesptaml()
        dgv_spt_aml.ColumnCount = 6
        dgv_spt_aml.Columns(0).Name = "SPT AML"
        dgv_spt_aml.Columns(1).Name = "NILAI MASUKAN"
        dgv_spt_aml.Columns(2).Name = "NILAI KELUARAN"
        dgv_spt_aml.Columns(3).Name = "PPN MASUKAN"
        dgv_spt_aml.Columns(4).Name = "PPN KELUARAN"
        dgv_spt_aml.Columns(5).Name = "PPN DISETOR"

        Dim bulanArray As String() = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        For Each bulan As String In bulanArray
            dgv_spt_aml.Rows.Add(bulan, 0, 0, 0, 0, 0)
        Next

        For Each column As DataGridViewColumn In dgv_spt_aml.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_spt_aml.Columns(0).Width = 120
        dgv_spt_aml.Columns(1).Width = 150
        dgv_spt_aml.Columns(2).Width = 150
        dgv_spt_aml.Columns(3).Width = 140
        dgv_spt_aml.Columns(4).Width = 140
        dgv_spt_aml.Columns(5).Width = 130
        dgv_spt_aml.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(5).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub headertablesptamltambah()
        dgv_spt_aml.Columns(0).HeaderText = "SPT AML"
        dgv_spt_aml.Columns(1).HeaderText = "NILAI MASUKAN"
        dgv_spt_aml.Columns(2).HeaderText = "NILAI KELUARAN"
        dgv_spt_aml.Columns(3).HeaderText = "TDK DIGUNGGUNG"
        dgv_spt_aml.Columns(4).HeaderText = "DIGUNGGUNG"
        dgv_spt_aml.Columns(5).HeaderText = "PPN MASUKAN"
        dgv_spt_aml.Columns(6).HeaderText = "PPN KELUARAN"
        dgv_spt_aml.Columns(7).HeaderText = "PPN DISETOR"
        For Each column As DataGridViewColumn In dgv_spt_aml.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_spt_aml.Columns(0).Width = 100
        dgv_spt_aml.Columns(1).Width = 130
        dgv_spt_aml.Columns(2).Width = 130
        dgv_spt_aml.Columns(3).Width = 100
        dgv_spt_aml.Columns(4).Width = 100
        dgv_spt_aml.Columns(5).Width = 120
        dgv_spt_aml.Columns(6).Width = 120
        dgv_spt_aml.Columns(7).Width = 110
        dgv_spt_aml.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_spt_aml.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv_spt_aml.Columns(7).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv_spt_aml_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_spt_aml.CellFormatting
        ' Periksa apakah nilai di sel adalah numerik
        If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)
            If nilai < 0 Then
                ' Format nilai negatif dengan tanda kurung
                e.Value = "(" & Format(Math.Abs(nilai), "#,##0.00") & ")"
                e.FormattingApplied = True
            Else
                ' Format nilai positif atau nol tanpa tanda kurung
                e.Value = Format(nilai, "#,##0.00")
                e.FormattingApplied = True
            End If
        End If
    End Sub
    Private Sub dgv_spt_clone_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_spt_clone.CellFormatting
        If dgv_spt_clone.Columns(e.ColumnIndex).Name = "SELISIH PPN" Then
            ' Pastikan nilai tidak kosong dan merupakan angka
            If e.Value IsNot Nothing AndAlso IsNumeric(e.Value.ToString()) Then
                Dim nilai As Decimal
                ' Gunakan TryParse untuk menghindari error konversi
                If Decimal.TryParse(e.Value.ToString(), nilai) Then
                    ' Cek jika nilai lebih dari 100
                    If nilai > 100 Or nilai < -100 Then
                        dgv_spt_clone.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.White
                        dgv_spt_clone.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
                    Else
                        dgv_spt_clone.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
                    End If
                End If
            Else
                ' Jika nilai tidak valid, pastikan warna tetap default (opsional)
                dgv_spt_clone.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black
            End If
        End If
        ' Periksa apakah nilai di sel adalah numerik
        If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)
            If nilai < 0 Then
                ' Format nilai negatif dengan tanda kurung
                e.Value = "(" & Format(Math.Abs(nilai), "#,##0.00") & ")"
                e.FormattingApplied = True
            Else
                ' Format nilai positif atau nol tanpa tanda kurung
                e.Value = Format(nilai, "#,##0.00")
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub tampil_induk_penyusutan()
        dgv_induk_penyusutan_mesin.Columns.Clear()
        dgv_induk_penyusutan_mesin.Columns.Add("Tahun", "Tahun")
        dgv_induk_penyusutan_mesin.Columns.Add("PerolehanTahun", "Perolehan Tahun")
        dgv_induk_penyusutan_mesin.Columns.Add("Penambahan", "Penambahan")
        Dim query As String = "SELECT tahun, SUM(nilai_buku) AS penambahan " &
                      "FROM tbindukpenyusutan " &
                      "WHERE kategori_aset = 'MESIN' " &
                      "GROUP BY tahun " &
                      "ORDER BY tahun"
        Using conn As New MySqlConnection(sLocalConn)
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgv_induk_penyusutan_mesin.Rows.Clear()
                    While reader.Read()
                        Dim tahun As String = reader("tahun").ToString()
                        Dim penambahan As Decimal = Convert.ToDecimal(reader("penambahan"))

                        dgv_induk_penyusutan_mesin.Rows.Add(tahun, 0, If(penambahan = 0, "-", penambahan.ToString("#,##0")))
                    End While
                End Using
            End Using
        End Using

        For i As Integer = 0 To dgv_induk_penyusutan_mesin.Rows.Count - 1
            If i = 0 Then
                dgv_induk_penyusutan_mesin.Rows(i).Cells(1).Value = dgv_induk_penyusutan_mesin.Rows(i).Cells(2).Value
            Else
                Dim nilaiSebelumnya As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_mesin.Rows(i - 1).Cells(1).Value)
                Dim nilaiKolom3 As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_mesin.Rows(i).Cells(2).Value)
                dgv_induk_penyusutan_mesin.Rows(i).Cells(1).Value = nilaiSebelumnya + nilaiKolom3
            End If
        Next
        dgv_induk_penyusutan_mesin.Rows(0).Cells(2).Value = 0

        For Each column As DataGridViewColumn In dgv_induk_penyusutan_mesin.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_induk_penyusutan_mesin.Columns(0).Width = 60
        dgv_induk_penyusutan_mesin.Columns(1).Width = 100
        dgv_induk_penyusutan_mesin.Columns(2).Width = 100
        dgv_induk_penyusutan_mesin.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_induk_penyusutan_mesin.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_mesin.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_mesin.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv_induk_penyusutan_mesin.Columns(2).DefaultCellStyle.Format = "#,##0"

        dgv_induk_penyusutan_tanki.Columns.Clear()
        dgv_induk_penyusutan_tanki.Columns.Add("Tahun", "Tahun")
        dgv_induk_penyusutan_tanki.Columns.Add("PerolehanTahun", "Perolehan Tahun")
        dgv_induk_penyusutan_tanki.Columns.Add("Penambahan", "Penambahan")
        Dim query1 As String = "SELECT tahun, SUM(nilai_buku) AS penambahan " &
                      "FROM tbindukpenyusutan " &
                      "WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH' " &
                      "GROUP BY tahun " &
                      "ORDER BY tahun"
        Using conn As New MySqlConnection(sLocalConn)
            conn.Open()
            Using cmd As New MySqlCommand(query1, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgv_induk_penyusutan_tanki.Rows.Clear()
                    While reader.Read()
                        Dim tahun As String = reader("tahun").ToString()
                        Dim penambahan As Decimal = Convert.ToDecimal(reader("penambahan"))

                        dgv_induk_penyusutan_tanki.Rows.Add(tahun, 0, If(penambahan = 0, "-", penambahan.ToString("#,##0")))
                    End While
                End Using
            End Using
        End Using

        For i As Integer = 0 To dgv_induk_penyusutan_tanki.Rows.Count - 1
            If i = 0 Then
                dgv_induk_penyusutan_tanki.Rows(i).Cells(1).Value = dgv_induk_penyusutan_tanki.Rows(i).Cells(2).Value
            Else
                Dim nilaiSebelumnya As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_tanki.Rows(i - 1).Cells(1).Value)
                Dim nilaiKolom3 As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_tanki.Rows(i).Cells(2).Value)
                dgv_induk_penyusutan_tanki.Rows(i).Cells(1).Value = nilaiSebelumnya + nilaiKolom3
            End If
        Next
        dgv_induk_penyusutan_tanki.Rows(0).Cells(2).Value = 0

        For Each column As DataGridViewColumn In dgv_induk_penyusutan_tanki.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_induk_penyusutan_tanki.Columns(0).Width = 60
        dgv_induk_penyusutan_tanki.Columns(1).Width = 100
        dgv_induk_penyusutan_tanki.Columns(2).Width = 100
        dgv_induk_penyusutan_tanki.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_induk_penyusutan_tanki.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_tanki.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_tanki.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv_induk_penyusutan_tanki.Columns(2).DefaultCellStyle.Format = "#,##0"

        dgv_induk_penyusutan_inventaris.Columns.Clear()
        dgv_induk_penyusutan_inventaris.Columns.Add("Tahun", "Tahun")
        dgv_induk_penyusutan_inventaris.Columns.Add("PerolehanTahun", "Perolehan Tahun")
        dgv_induk_penyusutan_inventaris.Columns.Add("Penambahan", "Penambahan")
        Dim query2 As String = "SELECT tahun, SUM(nilai_buku) AS penambahan " &
                      "FROM tbindukpenyusutan " &
                      "WHERE kategori_aset = 'INVENTARIS' " &
                      "GROUP BY tahun " &
                      "ORDER BY tahun"
        Using conn As New MySqlConnection(sLocalConn)
            conn.Open()
            Using cmd As New MySqlCommand(query2, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgv_induk_penyusutan_inventaris.Rows.Clear()
                    While reader.Read()
                        Dim tahun As String = reader("tahun").ToString()
                        Dim penambahan As Decimal = Convert.ToDecimal(reader("penambahan"))

                        dgv_induk_penyusutan_inventaris.Rows.Add(tahun, 0, If(penambahan = 0, "-", penambahan.ToString("#,##0")))
                    End While
                End Using
            End Using
        End Using

        For i As Integer = 0 To dgv_induk_penyusutan_inventaris.Rows.Count - 1
            If i = 0 Then
                dgv_induk_penyusutan_inventaris.Rows(i).Cells(1).Value = dgv_induk_penyusutan_inventaris.Rows(i).Cells(2).Value
            Else
                Dim nilaiSebelumnya As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_inventaris.Rows(i - 1).Cells(1).Value)
                Dim nilaiKolom3 As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_inventaris.Rows(i).Cells(2).Value)
                dgv_induk_penyusutan_inventaris.Rows(i).Cells(1).Value = nilaiSebelumnya + nilaiKolom3
            End If
        Next
        dgv_induk_penyusutan_inventaris.Rows(0).Cells(2).Value = 0

        For Each column As DataGridViewColumn In dgv_induk_penyusutan_inventaris.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_induk_penyusutan_inventaris.Columns(0).Width = 60
        dgv_induk_penyusutan_inventaris.Columns(1).Width = 100
        dgv_induk_penyusutan_inventaris.Columns(2).Width = 100
        dgv_induk_penyusutan_inventaris.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_induk_penyusutan_inventaris.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_inventaris.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_inventaris.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv_induk_penyusutan_inventaris.Columns(2).DefaultCellStyle.Format = "#,##0"

        dgv_induk_penyusutan_bangunan.Columns.Clear()
        dgv_induk_penyusutan_bangunan.Columns.Add("Tahun", "Tahun")
        dgv_induk_penyusutan_bangunan.Columns.Add("PerolehanTahun", "Perolehan Tahun")
        dgv_induk_penyusutan_bangunan.Columns.Add("Penambahan", "Penambahan")
        Dim query3 As String = "SELECT tahun, SUM(nilai_buku) AS penambahan " &
                      "FROM tbindukpenyusutan " &
                      "WHERE kategori_aset = 'BANGUNAN' " &
                      "GROUP BY tahun " &
                      "ORDER BY tahun"
        Using conn As New MySqlConnection(sLocalConn)
            conn.Open()
            Using cmd As New MySqlCommand(query3, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgv_induk_penyusutan_bangunan.Rows.Clear()
                    While reader.Read()
                        Dim tahun As String = reader("tahun").ToString()
                        Dim penambahan As Decimal = Convert.ToDecimal(reader("penambahan"))

                        dgv_induk_penyusutan_bangunan.Rows.Add(tahun, 0, If(penambahan = 0, "-", penambahan.ToString("#,##0")))
                    End While
                End Using
            End Using
        End Using

        For i As Integer = 0 To dgv_induk_penyusutan_bangunan.Rows.Count - 1
            If i = 0 Then
                dgv_induk_penyusutan_bangunan.Rows(i).Cells(1).Value = dgv_induk_penyusutan_bangunan.Rows(i).Cells(2).Value
            Else
                Dim nilaiSebelumnya As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_bangunan.Rows(i - 1).Cells(1).Value)
                Dim nilaiKolom3 As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_bangunan.Rows(i).Cells(2).Value)
                dgv_induk_penyusutan_bangunan.Rows(i).Cells(1).Value = nilaiSebelumnya + nilaiKolom3
            End If
        Next
        dgv_induk_penyusutan_bangunan.Rows(0).Cells(2).Value = 0

        For Each column As DataGridViewColumn In dgv_induk_penyusutan_bangunan.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_induk_penyusutan_bangunan.Columns(0).Width = 60
        dgv_induk_penyusutan_bangunan.Columns(1).Width = 100
        dgv_induk_penyusutan_bangunan.Columns(2).Width = 100
        dgv_induk_penyusutan_bangunan.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_induk_penyusutan_bangunan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_bangunan.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_bangunan.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv_induk_penyusutan_bangunan.Columns(2).DefaultCellStyle.Format = "#,##0"

        dgv_induk_penyusutan_kendaraan.Columns.Clear()
        dgv_induk_penyusutan_kendaraan.Columns.Add("Tahun", "Tahun")
        dgv_induk_penyusutan_kendaraan.Columns.Add("PerolehanTahun", "Perolehan Tahun")
        dgv_induk_penyusutan_kendaraan.Columns.Add("Penambahan", "Penambahan")
        Dim query4 As String = "SELECT tahun, SUM(nilai_buku) AS penambahan " &
                      "FROM tbindukpenyusutan " &
                      "WHERE kategori_aset = 'KENDARAAN' " &
                      "GROUP BY tahun " &
                      "ORDER BY tahun"
        Using conn As New MySqlConnection(sLocalConn)
            conn.Open()
            Using cmd As New MySqlCommand(query4, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    dgv_induk_penyusutan_kendaraan.Rows.Clear()
                    While reader.Read()
                        Dim tahun As String = reader("tahun").ToString()
                        Dim penambahan As Decimal = Convert.ToDecimal(reader("penambahan"))

                        dgv_induk_penyusutan_kendaraan.Rows.Add(tahun, 0, If(penambahan = 0, "-", penambahan.ToString("#,##0")))
                    End While
                End Using
            End Using
        End Using

        For i As Integer = 0 To dgv_induk_penyusutan_kendaraan.Rows.Count - 1
            If i = 0 Then
                dgv_induk_penyusutan_kendaraan.Rows(i).Cells(1).Value = dgv_induk_penyusutan_kendaraan.Rows(i).Cells(2).Value
            Else
                Dim nilaiSebelumnya As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_kendaraan.Rows(i - 1).Cells(1).Value)
                Dim nilaiKolom3 As Decimal = Convert.ToDecimal(dgv_induk_penyusutan_kendaraan.Rows(i).Cells(2).Value)
                dgv_induk_penyusutan_kendaraan.Rows(i).Cells(1).Value = nilaiSebelumnya + nilaiKolom3
            End If
        Next
        dgv_induk_penyusutan_kendaraan.Rows(0).Cells(2).Value = 0

        For Each column As DataGridViewColumn In dgv_induk_penyusutan_kendaraan.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_induk_penyusutan_kendaraan.Columns(0).Width = 60
        dgv_induk_penyusutan_kendaraan.Columns(1).Width = 100
        dgv_induk_penyusutan_kendaraan.Columns(2).Width = 100
        dgv_induk_penyusutan_kendaraan.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_induk_penyusutan_kendaraan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_kendaraan.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_induk_penyusutan_kendaraan.Columns(1).DefaultCellStyle.Format = "#,##0"
        dgv_induk_penyusutan_kendaraan.Columns(2).DefaultCellStyle.Format = "#,##0"

        dgv_induk_penyusutan_mesin.RowHeadersVisible = False
        dgv_induk_penyusutan_inventaris.RowHeadersVisible = False
        dgv_induk_penyusutan_tanki.RowHeadersVisible = False
        dgv_induk_penyusutan_bangunan.RowHeadersVisible = False
        dgv_induk_penyusutan_kendaraan.RowHeadersVisible = False

    End Sub
    Private Sub tampil_data_penyusutan()
        dgv_penyusutan_mesin.Columns.Clear()
        dgv_penyusutan_mesin.ColumnHeadersVisible = False
        dgv_penyusutan_mesin.RowHeadersVisible = False
        dgv_penyusutan_mesin.ColumnCount = 5
        dgv_penyusutan_mesin.Columns(0).Width = 80 ' Lebar kolom 1
        dgv_penyusutan_mesin.Columns(1).Width = 60 ' Lebar kolom 2
        dgv_penyusutan_mesin.Columns(2).Width = 90 ' Lebar kolom 3
        dgv_penyusutan_mesin.Columns(3).Width = 100 ' Lebar kolom 4
        dgv_penyusutan_mesin.Columns(4).Visible = False ' Sembunyikan kolom kode
        dgv_penyusutan_mesin.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_mesin.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_mesin.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_penyusutan_mesin.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Ambil data dari tbindukpenyusutan
        Using conn As New MySqlConnection(sLocalConn)
            Dim queryInduk As String = "SELECT kode, nama_aset, nilai_buku FROM tbindukpenyusutan WHERE kategori_aset = 'MESIN' ORDER BY tahun"
            Dim cmdInduk As New MySqlCommand(queryInduk, conn)
            conn.Open()

            Using drInduk As MySqlDataReader = cmdInduk.ExecuteReader()
                If drInduk.HasRows Then
                    While drInduk.Read()
                        ' Baris 1: Tampilkan nama_aset dan "NILAI BUKU"
                        dgv_penyusutan_mesin.Rows.Add(drInduk("nama_aset").ToString(), "", "", "NILAI BUKU", drInduk("kode").ToString())

                        ' Baris 2: Tampilkan nilai_buku
                        dgv_penyusutan_mesin.Rows.Add("", "", "", Format(CDec(drInduk("nilai_buku")), "#,##0"), drInduk("kode").ToString())

                        ' Ambil kode sebagai referensi
                        Dim kodeRef As String = drInduk("kode").ToString()

                        ' Gunakan koneksi baru untuk query kedua
                        Using conn2 As New MySqlConnection(sLocalConn)
                            conn2.Open()

                            ' Query untuk mengambil data tbdatapenyusutan berdasarkan kode
                            Dim queryPenyusutan As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku FROM tbdatapenyusutan WHERE kode = @kode ORDER BY tahun"
                            Using cmdPenyusutan As New MySqlCommand(queryPenyusutan, conn2)
                                cmdPenyusutan.Parameters.AddWithValue("@kode", kodeRef)

                                Using drPenyusutan As MySqlDataReader = cmdPenyusutan.ExecuteReader()
                                    If drPenyusutan.HasRows Then
                                        While drPenyusutan.Read()
                                            ' Tampilkan data penyusutan
                                            dgv_penyusutan_mesin.Rows.Add(drPenyusutan("tahun").ToString(), _
                                                          drPenyusutan("persentase").ToString(), _
                                                          Format(CDec(drPenyusutan("nilai_penyusutan")), "#,##0"), _
                                                          Format(CDec(drPenyusutan("nilai_buku")), "#,##0"), _
                                                          kodeRef)
                                        End While
                                    End If
                                End Using
                            End Using
                        End Using

                        ' Tambahkan satu baris kosong
                        dgv_penyusutan_mesin.Rows.Add("", "", "", "", "")
                    End While
                End If
            End Using
        End Using

        dgv_gabungan_penyusutan_mesin.Columns.Clear()
        dgv_gabungan_penyusutan_mesin.ColumnHeadersVisible = False
        dgv_gabungan_penyusutan_mesin.RowHeadersVisible = False
        dgv_gabungan_penyusutan_mesin.ColumnCount = 4
        ' Query untuk menghitung jumlah unik kode pada tbdatapenyusutan kategori MESIN
        Dim queryHitung As String = "SELECT COUNT(DISTINCT kode) AS jumlah_mesin " &
                            "FROM tbdatapenyusutan " &
                            "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'MESIN')"
        Using connHitung As New MySqlConnection(sLocalConn)
            Dim cmdHitung As New MySqlCommand(queryHitung, connHitung)
            connHitung.Open()
            Dim jumlahMesin As Integer = CInt(cmdHitung.ExecuteScalar())
            ' Cek apakah lebih dari satu
            If jumlahMesin > 1 Then
                ' Dapatkan Total Nilai Buku Awal dari tbindukpenyusutan
                Dim totalNilaiBukuAwal As Decimal
                Dim queryNilaiBukuAwal As String = "SELECT SUM(nilai_buku) AS total_nilai_buku_awal FROM tbindukpenyusutan WHERE kategori_aset = 'MESIN'"
                Using connTotal As New MySqlConnection(sLocalConn)
                    Dim cmdTotal As New MySqlCommand(queryNilaiBukuAwal, connTotal)
                    connTotal.Open()
                    totalNilaiBukuAwal = CDec(cmdTotal.ExecuteScalar())
                End Using
                ' Tambahkan header untuk data gabungan
                dgv_gabungan_penyusutan_mesin.Rows.Add("MESIN GABUNGAN", "", "", "", "")
                dgv_gabungan_penyusutan_mesin.Rows.Add("", "", "", "", "")
                ' Query untuk menggabungkan data penyusutan per tahun
                Dim queryGabungan As String = "SELECT tahun, SUM(nilai_penyusutan) AS total_penyusutan FROM(tbdatapenyusutan) " &
                    "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'MESIN') GROUP BY tahun ORDER BY tahun"
                Using connGabungan As New MySqlConnection(sLocalConn)
                    Dim cmdGabungan As New MySqlCommand(queryGabungan, connGabungan)
                    connGabungan.Open()

                    Using drGabungan As MySqlDataReader = cmdGabungan.ExecuteReader()
                        If drGabungan.HasRows Then
                            Dim akumPenyusutan As Decimal = 0  ' Inisialisasi Akumulasi Penyusutan
                            Dim nilaiBuku As Decimal = totalNilaiBukuAwal ' Inisialisasi Nilai Buku Awal

                            ' Tambahkan header untuk kolom
                            dgv_gabungan_penyusutan_mesin.Rows.Add("Tahun", "Penyusutan", "Akum Penyusutan", "Nilai Buku", "")

                            While drGabungan.Read()
                                ' Perhitungan Akumulasi Penyusutan
                                akumPenyusutan += CDec(drGabungan("total_penyusutan"))

                                ' Hitung Nilai Buku
                                nilaiBuku = totalNilaiBukuAwal - akumPenyusutan

                                ' Tampilkan data gabungan
                                dgv_gabungan_penyusutan_mesin.Rows.Add(
                                    drGabungan("tahun").ToString(), _
                                    Format(CDec(drGabungan("total_penyusutan")), "#,##0"), _
                                    Format(akumPenyusutan, "#,##0"), _
                                    If(nilaiBuku > 0, Format(nilaiBuku, "#,##0"), "-"), _
                                    "GABUNGAN")
                            End While
                        End If
                    End Using
                End Using
            End If
        End Using

        dgv_penyusutan_tanki.Columns.Clear()
        dgv_penyusutan_tanki.ColumnHeadersVisible = False
        dgv_penyusutan_tanki.RowHeadersVisible = False
        dgv_penyusutan_tanki.ColumnCount = 5
        dgv_penyusutan_tanki.Columns(0).Width = 80 ' Lebar kolom 1
        dgv_penyusutan_tanki.Columns(1).Width = 60 ' Lebar kolom 2
        dgv_penyusutan_tanki.Columns(2).Width = 90 ' Lebar kolom 3
        dgv_penyusutan_tanki.Columns(3).Width = 100 ' Lebar kolom 4
        dgv_penyusutan_tanki.Columns(4).Visible = False ' Sembunyikan kolom kode
        dgv_penyusutan_tanki.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_tanki.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_tanki.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_penyusutan_tanki.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Ambil data dari tbindukpenyusutan
        Using conn As New MySqlConnection(sLocalConn)
            Dim queryInduk As String = "SELECT kode, nama_aset, nilai_buku FROM tbindukpenyusutan WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH' ORDER BY tahun"
            Dim cmdInduk As New MySqlCommand(queryInduk, conn)
            conn.Open()

            Using drInduk As MySqlDataReader = cmdInduk.ExecuteReader()
                If drInduk.HasRows Then
                    While drInduk.Read()
                        ' Baris 1: Tampilkan nama_aset dan "NILAI BUKU"
                        dgv_penyusutan_tanki.Rows.Add(drInduk("nama_aset").ToString(), "", "", "NILAI BUKU", drInduk("kode").ToString())

                        ' Baris 2: Tampilkan nilai_buku
                        dgv_penyusutan_tanki.Rows.Add("", "", "", Format(CDec(drInduk("nilai_buku")), "#,##0"), drInduk("kode").ToString())

                        ' Ambil kode sebagai referensi
                        Dim kodeRef As String = drInduk("kode").ToString()

                        ' Gunakan koneksi baru untuk query kedua
                        Using conn2 As New MySqlConnection(sLocalConn)
                            conn2.Open()

                            ' Query untuk mengambil data tbdatapenyusutan berdasarkan kode
                            Dim queryPenyusutan As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku FROM tbdatapenyusutan WHERE kode = @kode ORDER BY tahun"
                            Using cmdPenyusutan As New MySqlCommand(queryPenyusutan, conn2)
                                cmdPenyusutan.Parameters.AddWithValue("@kode", kodeRef)

                                Using drPenyusutan As MySqlDataReader = cmdPenyusutan.ExecuteReader()
                                    If drPenyusutan.HasRows Then
                                        While drPenyusutan.Read()
                                            ' Tampilkan data penyusutan
                                            dgv_penyusutan_tanki.Rows.Add(drPenyusutan("tahun").ToString(), _
                                                          drPenyusutan("persentase").ToString(), _
                                                          Format(CDec(drPenyusutan("nilai_penyusutan")), "#,##0"), _
                                                          Format(CDec(drPenyusutan("nilai_buku")), "#,##0"), _
                                                          kodeRef)
                                        End While
                                    End If
                                End Using
                            End Using
                        End Using

                        ' Tambahkan satu baris kosong
                        dgv_penyusutan_tanki.Rows.Add("", "", "", "", "")
                    End While
                End If
            End Using
        End Using

        dgv_gabungan_penyusutan_tanki.Columns.Clear()
        dgv_gabungan_penyusutan_tanki.ColumnHeadersVisible = False
        dgv_gabungan_penyusutan_tanki.RowHeadersVisible = False
        dgv_gabungan_penyusutan_tanki.ColumnCount = 4
        ' Query untuk menghitung jumlah unik kode pada tbdatapenyusutan kategori MESIN
        Dim queryHitungtanki As String = "SELECT COUNT(DISTINCT kode) AS jumlah_mesin " &
                            "FROM tbdatapenyusutan " &
                            "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH')"
        Using connHitung As New MySqlConnection(sLocalConn)
            Dim cmdHitung As New MySqlCommand(queryHitungtanki, connHitung)
            connHitung.Open()
            Dim jumlahMesin As Integer = CInt(cmdHitung.ExecuteScalar())
            ' Cek apakah lebih dari satu
            If jumlahMesin > 1 Then
                ' Dapatkan Total Nilai Buku Awal dari tbindukpenyusutan
                Dim totalNilaiBukuAwal As Decimal
                Dim queryNilaiBukuAwal As String = "SELECT SUM(nilai_buku) AS total_nilai_buku_awal FROM tbindukpenyusutan WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH'"
                Using connTotal As New MySqlConnection(sLocalConn)
                    Dim cmdTotal As New MySqlCommand(queryNilaiBukuAwal, connTotal)
                    connTotal.Open()
                    totalNilaiBukuAwal = CDec(cmdTotal.ExecuteScalar())
                End Using
                ' Tambahkan header untuk data gabungan
                dgv_gabungan_penyusutan_tanki.Rows.Add("TANKI GABUNGAN", "", "", "", "")
                dgv_gabungan_penyusutan_tanki.Rows.Add("", "", "", "", "")
                ' Query untuk menggabungkan data penyusutan per tahun
                Dim queryGabungan As String = "SELECT tahun, SUM(nilai_penyusutan) AS total_penyusutan FROM(tbdatapenyusutan) " &
                    "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'TANKI PENGOLAH LIMBAH') GROUP BY tahun ORDER BY tahun"
                Using connGabungan As New MySqlConnection(sLocalConn)
                    Dim cmdGabungan As New MySqlCommand(queryGabungan, connGabungan)
                    connGabungan.Open()

                    Using drGabungan As MySqlDataReader = cmdGabungan.ExecuteReader()
                        If drGabungan.HasRows Then
                            Dim akumPenyusutan As Decimal = 0  ' Inisialisasi Akumulasi Penyusutan
                            Dim nilaiBuku As Decimal = totalNilaiBukuAwal ' Inisialisasi Nilai Buku Awal

                            ' Tambahkan header untuk kolom
                            dgv_gabungan_penyusutan_tanki.Rows.Add("Tahun", "Penyusutan", "Akum Penyusutan", "Nilai Buku", "")

                            While drGabungan.Read()
                                ' Perhitungan Akumulasi Penyusutan
                                akumPenyusutan += CDec(drGabungan("total_penyusutan"))

                                ' Hitung Nilai Buku
                                nilaiBuku = totalNilaiBukuAwal - akumPenyusutan

                                ' Tampilkan data gabungan
                                dgv_gabungan_penyusutan_tanki.Rows.Add(
                                    drGabungan("tahun").ToString(), _
                                    Format(CDec(drGabungan("total_penyusutan")), "#,##0"), _
                                    Format(akumPenyusutan, "#,##0"), _
                                    If(nilaiBuku > 0, Format(nilaiBuku, "#,##0"), "-"), _
                                    "GABUNGAN")
                            End While
                        End If
                    End Using
                End Using
            End If
        End Using

        'Inventaris
        dgv_penyusutan_inventaris.Columns.Clear()
        dgv_penyusutan_inventaris.ColumnHeadersVisible = False
        dgv_penyusutan_inventaris.RowHeadersVisible = False
        dgv_penyusutan_inventaris.ColumnCount = 5
        dgv_penyusutan_inventaris.Columns(0).Width = 80 ' Lebar kolom 1
        dgv_penyusutan_inventaris.Columns(1).Width = 60 ' Lebar kolom 2
        dgv_penyusutan_inventaris.Columns(2).Width = 90 ' Lebar kolom 3
        dgv_penyusutan_inventaris.Columns(3).Width = 100 ' Lebar kolom 4
        dgv_penyusutan_inventaris.Columns(4).Visible = False ' Sembunyikan kolom kode
        dgv_penyusutan_inventaris.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_inventaris.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_inventaris.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_penyusutan_inventaris.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Ambil data dari tbindukpenyusutan
        Using conn As New MySqlConnection(sLocalConn)
            Dim queryInduk As String = "SELECT kode, nama_aset, nilai_buku FROM tbindukpenyusutan WHERE kategori_aset = 'INVENTARIS' ORDER BY tahun"
            Dim cmdInduk As New MySqlCommand(queryInduk, conn)
            conn.Open()

            Using drInduk As MySqlDataReader = cmdInduk.ExecuteReader()
                If drInduk.HasRows Then
                    While drInduk.Read()
                        ' Baris 1: Tampilkan nama_aset dan "NILAI BUKU"
                        dgv_penyusutan_inventaris.Rows.Add(drInduk("nama_aset").ToString(), "", "", "NILAI BUKU", drInduk("kode").ToString())

                        ' Baris 2: Tampilkan nilai_buku
                        dgv_penyusutan_inventaris.Rows.Add("", "", "", Format(CDec(drInduk("nilai_buku")), "#,##0"), drInduk("kode").ToString())

                        ' Ambil kode sebagai referensi
                        Dim kodeRef As String = drInduk("kode").ToString()

                        ' Gunakan koneksi baru untuk query kedua
                        Using conn2 As New MySqlConnection(sLocalConn)
                            conn2.Open()

                            ' Query untuk mengambil data tbdatapenyusutan berdasarkan kode
                            Dim queryPenyusutan As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku FROM tbdatapenyusutan WHERE kode = @kode ORDER BY tahun"
                            Using cmdPenyusutan As New MySqlCommand(queryPenyusutan, conn2)
                                cmdPenyusutan.Parameters.AddWithValue("@kode", kodeRef)

                                Using drPenyusutan As MySqlDataReader = cmdPenyusutan.ExecuteReader()
                                    If drPenyusutan.HasRows Then
                                        While drPenyusutan.Read()
                                            ' Tampilkan data penyusutan
                                            dgv_penyusutan_inventaris.Rows.Add(drPenyusutan("tahun").ToString(), _
                                                          drPenyusutan("persentase").ToString(), _
                                                          Format(CDec(drPenyusutan("nilai_penyusutan")), "#,##0"), _
                                                          Format(CDec(drPenyusutan("nilai_buku")), "#,##0"), _
                                                          kodeRef)
                                        End While
                                    End If
                                End Using
                            End Using
                        End Using

                        ' Tambahkan satu baris kosong
                        dgv_penyusutan_inventaris.Rows.Add("", "", "", "", "")
                    End While
                End If
            End Using
        End Using

        dgv_gabungan_penyusutan_inventaris.Columns.Clear()
        dgv_gabungan_penyusutan_inventaris.ColumnHeadersVisible = False
        dgv_gabungan_penyusutan_inventaris.RowHeadersVisible = False
        dgv_gabungan_penyusutan_inventaris.ColumnCount = 4
        ' Query untuk menghitung jumlah unik kode pada tbdatapenyusutan kategori MESIN
        Dim queryHitunginventaris As String = "SELECT COUNT(DISTINCT kode) AS jumlah_mesin " &
                            "FROM tbdatapenyusutan " &
                            "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'INVENTARIS')"
        Using connHitung As New MySqlConnection(sLocalConn)
            Dim cmdHitung As New MySqlCommand(queryHitunginventaris, connHitung)
            connHitung.Open()
            Dim jumlahMesin As Integer = CInt(cmdHitung.ExecuteScalar())
            ' Cek apakah lebih dari satu
            If jumlahMesin > 1 Then
                ' Dapatkan Total Nilai Buku Awal dari tbindukpenyusutan
                Dim totalNilaiBukuAwal As Decimal
                Dim queryNilaiBukuAwal As String = "SELECT SUM(nilai_buku) AS total_nilai_buku_awal FROM tbindukpenyusutan WHERE kategori_aset = 'INVENTARIS'"
                Using connTotal As New MySqlConnection(sLocalConn)
                    Dim cmdTotal As New MySqlCommand(queryNilaiBukuAwal, connTotal)
                    connTotal.Open()
                    totalNilaiBukuAwal = CDec(cmdTotal.ExecuteScalar())
                End Using
                ' Tambahkan header untuk data gabungan
                dgv_gabungan_penyusutan_inventaris.Rows.Add("INVENTARIS GABUNGAN", "", "", "", "")
                dgv_gabungan_penyusutan_inventaris.Rows.Add("", "", "", "", "")
                ' Query untuk menggabungkan data penyusutan per tahun
                Dim queryGabungan As String = "SELECT tahun, SUM(nilai_penyusutan) AS total_penyusutan FROM(tbdatapenyusutan) " &
                    "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'INVENTARIS') GROUP BY tahun ORDER BY tahun"
                Using connGabungan As New MySqlConnection(sLocalConn)
                    Dim cmdGabungan As New MySqlCommand(queryGabungan, connGabungan)
                    connGabungan.Open()

                    Using drGabungan As MySqlDataReader = cmdGabungan.ExecuteReader()
                        If drGabungan.HasRows Then
                            Dim akumPenyusutan As Decimal = 0  ' Inisialisasi Akumulasi Penyusutan
                            Dim nilaiBuku As Decimal = totalNilaiBukuAwal ' Inisialisasi Nilai Buku Awal

                            ' Tambahkan header untuk kolom
                            dgv_gabungan_penyusutan_inventaris.Rows.Add("Tahun", "Penyusutan", "Akum Penyusutan", "Nilai Buku", "")

                            While drGabungan.Read()
                                ' Perhitungan Akumulasi Penyusutan
                                akumPenyusutan += CDec(drGabungan("total_penyusutan"))

                                ' Hitung Nilai Buku
                                nilaiBuku = totalNilaiBukuAwal - akumPenyusutan

                                ' Tampilkan data gabungan
                                dgv_gabungan_penyusutan_inventaris.Rows.Add(
                                    drGabungan("tahun").ToString(), _
                                    Format(CDec(drGabungan("total_penyusutan")), "#,##0"), _
                                    Format(akumPenyusutan, "#,##0"), _
                                    If(nilaiBuku > 0, Format(nilaiBuku, "#,##0"), "-"), _
                                    "GABUNGAN")
                            End While
                        End If
                    End Using
                End Using
            End If
        End Using

        'Bangunan
        dgv_penyusutan_bangunan.Columns.Clear()
        dgv_penyusutan_bangunan.ColumnHeadersVisible = False
        dgv_penyusutan_bangunan.RowHeadersVisible = False
        dgv_penyusutan_bangunan.ColumnCount = 5
        dgv_penyusutan_bangunan.Columns(0).Width = 80 ' Lebar kolom 1
        dgv_penyusutan_bangunan.Columns(1).Width = 60 ' Lebar kolom 2
        dgv_penyusutan_bangunan.Columns(2).Width = 90 ' Lebar kolom 3
        dgv_penyusutan_bangunan.Columns(3).Width = 100 ' Lebar kolom 4
        dgv_penyusutan_bangunan.Columns(4).Visible = False ' Sembunyikan kolom kode
        dgv_penyusutan_bangunan.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_bangunan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_bangunan.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_penyusutan_bangunan.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Ambil data dari tbindukpenyusutan
        Using conn As New MySqlConnection(sLocalConn)
            Dim queryInduk As String = "SELECT kode, nama_aset, nilai_buku FROM tbindukpenyusutan WHERE kategori_aset = 'BANGUNAN' ORDER BY tahun"
            Dim cmdInduk As New MySqlCommand(queryInduk, conn)
            conn.Open()

            Using drInduk As MySqlDataReader = cmdInduk.ExecuteReader()
                If drInduk.HasRows Then
                    While drInduk.Read()
                        ' Baris 1: Tampilkan nama_aset dan "NILAI BUKU"
                        dgv_penyusutan_bangunan.Rows.Add(drInduk("nama_aset").ToString(), "", "", "NILAI BUKU", drInduk("kode").ToString())

                        ' Baris 2: Tampilkan nilai_buku
                        dgv_penyusutan_bangunan.Rows.Add("", "", "", Format(CDec(drInduk("nilai_buku")), "#,##0"), drInduk("kode").ToString())

                        ' Ambil kode sebagai referensi
                        Dim kodeRef As String = drInduk("kode").ToString()

                        ' Gunakan koneksi baru untuk query kedua
                        Using conn2 As New MySqlConnection(sLocalConn)
                            conn2.Open()

                            ' Query untuk mengambil data tbdatapenyusutan berdasarkan kode
                            Dim queryPenyusutan As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku FROM tbdatapenyusutan WHERE kode = @kode ORDER BY tahun"
                            Using cmdPenyusutan As New MySqlCommand(queryPenyusutan, conn2)
                                cmdPenyusutan.Parameters.AddWithValue("@kode", kodeRef)

                                Using drPenyusutan As MySqlDataReader = cmdPenyusutan.ExecuteReader()
                                    If drPenyusutan.HasRows Then
                                        While drPenyusutan.Read()
                                            ' Tampilkan data penyusutan
                                            dgv_penyusutan_bangunan.Rows.Add(drPenyusutan("tahun").ToString(), _
                                                          drPenyusutan("persentase").ToString(), _
                                                          Format(CDec(drPenyusutan("nilai_penyusutan")), "#,##0"), _
                                                          Format(CDec(drPenyusutan("nilai_buku")), "#,##0"), _
                                                          kodeRef)
                                        End While
                                    End If
                                End Using
                            End Using
                        End Using

                        ' Tambahkan satu baris kosong
                        dgv_penyusutan_bangunan.Rows.Add("", "", "", "", "")
                    End While
                End If
            End Using
        End Using

        dgv_gabungan_penyusutan_bangunan.Columns.Clear()
        dgv_gabungan_penyusutan_bangunan.ColumnHeadersVisible = False
        dgv_gabungan_penyusutan_bangunan.RowHeadersVisible = False
        dgv_gabungan_penyusutan_bangunan.ColumnCount = 4
        ' Query untuk menghitung jumlah unik kode pada tbdatapenyusutan kategori MESIN
        Dim queryHitungBANGUNAN As String = "SELECT COUNT(DISTINCT kode) AS jumlah_mesin " &
                            "FROM tbdatapenyusutan " &
                            "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'BANGUNAN')"
        Using connHitung As New MySqlConnection(sLocalConn)
            Dim cmdHitung As New MySqlCommand(queryHitungBANGUNAN, connHitung)
            connHitung.Open()
            Dim jumlahMesin As Integer = CInt(cmdHitung.ExecuteScalar())
            ' Cek apakah lebih dari satu
            If jumlahMesin > 1 Then
                ' Dapatkan Total Nilai Buku Awal dari tbindukpenyusutan
                Dim totalNilaiBukuAwal As Decimal
                Dim queryNilaiBukuAwal As String = "SELECT SUM(nilai_buku) AS total_nilai_buku_awal FROM tbindukpenyusutan WHERE kategori_aset = 'BANGUNAN'"
                Using connTotal As New MySqlConnection(sLocalConn)
                    Dim cmdTotal As New MySqlCommand(queryNilaiBukuAwal, connTotal)
                    connTotal.Open()
                    totalNilaiBukuAwal = CDec(cmdTotal.ExecuteScalar())
                End Using
                ' Tambahkan header untuk data gabungan
                dgv_gabungan_penyusutan_bangunan.Rows.Add("BANGUNAN GABUNGAN", "", "", "", "")
                dgv_gabungan_penyusutan_bangunan.Rows.Add("", "", "", "", "")
                ' Query untuk menggabungkan data penyusutan per tahun
                Dim queryGabungan As String = "SELECT tahun, SUM(nilai_penyusutan) AS total_penyusutan FROM(tbdatapenyusutan) " &
                    "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'BANGUNAN') GROUP BY tahun ORDER BY tahun"
                Using connGabungan As New MySqlConnection(sLocalConn)
                    Dim cmdGabungan As New MySqlCommand(queryGabungan, connGabungan)
                    connGabungan.Open()

                    Using drGabungan As MySqlDataReader = cmdGabungan.ExecuteReader()
                        If drGabungan.HasRows Then
                            Dim akumPenyusutan As Decimal = 0  ' Inisialisasi Akumulasi Penyusutan
                            Dim nilaiBuku As Decimal = totalNilaiBukuAwal ' Inisialisasi Nilai Buku Awal

                            ' Tambahkan header untuk kolom
                            dgv_gabungan_penyusutan_bangunan.Rows.Add("Tahun", "Penyusutan", "Akum Penyusutan", "Nilai Buku", "")

                            While drGabungan.Read()
                                ' Perhitungan Akumulasi Penyusutan
                                akumPenyusutan += CDec(drGabungan("total_penyusutan"))

                                ' Hitung Nilai Buku
                                nilaiBuku = totalNilaiBukuAwal - akumPenyusutan

                                ' Tampilkan data gabungan
                                dgv_gabungan_penyusutan_bangunan.Rows.Add(
                                    drGabungan("tahun").ToString(), _
                                    Format(CDec(drGabungan("total_penyusutan")), "#,##0"), _
                                    Format(akumPenyusutan, "#,##0"), _
                                    If(nilaiBuku > 0, Format(nilaiBuku, "#,##0"), "-"), _
                                    "GABUNGAN")
                            End While
                        End If
                    End Using
                End Using
            End If
        End Using

        'kendaraan
        dgv_penyusutan_kendaraan.Columns.Clear()
        dgv_penyusutan_kendaraan.ColumnHeadersVisible = False
        dgv_penyusutan_kendaraan.RowHeadersVisible = False
        dgv_penyusutan_kendaraan.ColumnCount = 5
        dgv_penyusutan_kendaraan.Columns(0).Width = 80 ' Lebar kolom 1
        dgv_penyusutan_kendaraan.Columns(1).Width = 60 ' Lebar kolom 2
        dgv_penyusutan_kendaraan.Columns(2).Width = 90 ' Lebar kolom 3
        dgv_penyusutan_kendaraan.Columns(3).Width = 100 ' Lebar kolom 4
        dgv_penyusutan_kendaraan.Columns(4).Visible = False ' Sembunyikan kolom kode
        dgv_penyusutan_kendaraan.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_kendaraan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_penyusutan_kendaraan.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_penyusutan_kendaraan.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' Ambil data dari tbindukpenyusutan
        Using conn As New MySqlConnection(sLocalConn)
            Dim queryInduk As String = "SELECT kode, nama_aset, nilai_buku FROM tbindukpenyusutan WHERE kategori_aset = 'KENDARAAN' ORDER BY tahun"
            Dim cmdInduk As New MySqlCommand(queryInduk, conn)
            conn.Open()

            Using drInduk As MySqlDataReader = cmdInduk.ExecuteReader()
                If drInduk.HasRows Then
                    While drInduk.Read()
                        ' Baris 1: Tampilkan nama_aset dan "NILAI BUKU"
                        dgv_penyusutan_kendaraan.Rows.Add(drInduk("nama_aset").ToString(), "", "", "NILAI BUKU", drInduk("kode").ToString())

                        ' Baris 2: Tampilkan nilai_buku
                        dgv_penyusutan_kendaraan.Rows.Add("", "", "", Format(CDec(drInduk("nilai_buku")), "#,##0"), drInduk("kode").ToString())

                        ' Ambil kode sebagai referensi
                        Dim kodeRef As String = drInduk("kode").ToString()

                        ' Gunakan koneksi baru untuk query kedua
                        Using conn2 As New MySqlConnection(sLocalConn)
                            conn2.Open()

                            ' Query untuk mengambil data tbdatapenyusutan berdasarkan kode
                            Dim queryPenyusutan As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku FROM tbdatapenyusutan WHERE kode = @kode ORDER BY tahun"
                            Using cmdPenyusutan As New MySqlCommand(queryPenyusutan, conn2)
                                cmdPenyusutan.Parameters.AddWithValue("@kode", kodeRef)

                                Using drPenyusutan As MySqlDataReader = cmdPenyusutan.ExecuteReader()
                                    If drPenyusutan.HasRows Then
                                        While drPenyusutan.Read()
                                            ' Tampilkan data penyusutan
                                            dgv_penyusutan_kendaraan.Rows.Add(drPenyusutan("tahun").ToString(), _
                                                          drPenyusutan("persentase").ToString(), _
                                                          Format(CDec(drPenyusutan("nilai_penyusutan")), "#,##0"), _
                                                          Format(CDec(drPenyusutan("nilai_buku")), "#,##0"), _
                                                          kodeRef)
                                        End While
                                    End If
                                End Using
                            End Using
                        End Using

                        ' Tambahkan satu baris kosong
                        dgv_penyusutan_kendaraan.Rows.Add("", "", "", "", "")
                    End While
                End If
            End Using
        End Using

        dgv_gabungan_penyusutan_kendaraan.Columns.Clear()
        dgv_gabungan_penyusutan_kendaraan.ColumnHeadersVisible = False
        dgv_gabungan_penyusutan_kendaraan.RowHeadersVisible = False
        dgv_gabungan_penyusutan_kendaraan.ColumnCount = 4
        ' Query untuk menghitung jumlah unik kode pada tbdatapenyusutan kategori MESIN
        Dim queryHitungKENDARAAN As String = "SELECT COUNT(DISTINCT kode) AS jumlah_mesin " &
                            "FROM tbdatapenyusutan " &
                            "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'KENDARAAN')"
        Using connHitung As New MySqlConnection(sLocalConn)
            Dim cmdHitung As New MySqlCommand(queryHitungKENDARAAN, connHitung)
            connHitung.Open()
            Dim jumlahMesin As Integer = CInt(cmdHitung.ExecuteScalar())
            ' Cek apakah lebih dari satu
            If jumlahMesin > 1 Then
                ' Dapatkan Total Nilai Buku Awal dari tbindukpenyusutan
                Dim totalNilaiBukuAwal As Decimal
                Dim queryNilaiBukuAwal As String = "SELECT SUM(nilai_buku) AS total_nilai_buku_awal FROM tbindukpenyusutan WHERE kategori_aset = 'KENDARAAN'"
                Using connTotal As New MySqlConnection(sLocalConn)
                    Dim cmdTotal As New MySqlCommand(queryNilaiBukuAwal, connTotal)
                    connTotal.Open()
                    totalNilaiBukuAwal = CDec(cmdTotal.ExecuteScalar())
                End Using
                ' Tambahkan header untuk data gabungan
                dgv_gabungan_penyusutan_kendaraan.Rows.Add("KENDARAAN GABUNGAN", "", "", "", "")
                dgv_gabungan_penyusutan_kendaraan.Rows.Add("", "", "", "", "")
                ' Query untuk menggabungkan data penyusutan per tahun
                Dim queryGabungan As String = "SELECT tahun, SUM(nilai_penyusutan) AS total_penyusutan FROM(tbdatapenyusutan) " &
                    "WHERE kode IN (SELECT kode FROM tbindukpenyusutan WHERE kategori_aset = 'KENDARAAN') GROUP BY tahun ORDER BY tahun"
                Using connGabungan As New MySqlConnection(sLocalConn)
                    Dim cmdGabungan As New MySqlCommand(queryGabungan, connGabungan)
                    connGabungan.Open()

                    Using drGabungan As MySqlDataReader = cmdGabungan.ExecuteReader()
                        If drGabungan.HasRows Then
                            Dim akumPenyusutan As Decimal = 0  ' Inisialisasi Akumulasi Penyusutan
                            Dim nilaiBuku As Decimal = totalNilaiBukuAwal ' Inisialisasi Nilai Buku Awal

                            ' Tambahkan header untuk kolom
                            dgv_gabungan_penyusutan_kendaraan.Rows.Add("Tahun", "Penyusutan", "Akum Penyusutan", "Nilai Buku", "")

                            While drGabungan.Read()
                                ' Perhitungan Akumulasi Penyusutan
                                akumPenyusutan += CDec(drGabungan("total_penyusutan"))

                                ' Hitung Nilai Buku
                                nilaiBuku = totalNilaiBukuAwal - akumPenyusutan

                                ' Tampilkan data gabungan
                                dgv_gabungan_penyusutan_kendaraan.Rows.Add(
                                    drGabungan("tahun").ToString(), _
                                    Format(CDec(drGabungan("total_penyusutan")), "#,##0"), _
                                    Format(akumPenyusutan, "#,##0"), _
                                    If(nilaiBuku > 0, Format(nilaiBuku, "#,##0"), "-"), _
                                    "GABUNGAN")
                            End While
                        End If
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub Export(ByVal filePath As String)
        Try
            Dim txttahun As New TextBox
            txttahun.Text = dtp_tahun.Value.ToString("yyyy")

            Using package As New ExcelPackage()
                'sheet 1 hpp
                Dim ws1 As ExcelWorksheet = package.Workbook.Worksheets.Add("HPP ARTHA")
                ' === Set judul laporan ===
                ws1.Cells(1, 1).Value = "CV ARTHA MEKAR LESTARI"
                ws1.Cells(1, 1, 1, 5).Merge = True
                ws1.Cells(2, 1).Value = "LAPORAN HARGA POKOK PENJUALAN"
                ws1.Cells(2, 1, 2, 5).Merge = True
                ws1.Cells(3, 1).Value = "1 JANUARI - 31 DESEMBER " & txttahun.Text
                ws1.Cells(3, 1, 3, 5).Merge = True
                ws1.Cells(4, 1).Value = "(Dalam Rupiah)"
                ws1.Cells(4, 1, 4, 5).Merge = True

                ' === Isi data dari DataGridView ===
                For row As Integer = 0 To dgv_hpp.Rows.Count - 1
                    For col As Integer = 0 To dgv_hpp.ColumnCount - 1
                        Dim cellValue = dgv_hpp.Rows(row).Cells(col).Value
                        Dim cell = ws1.Cells(row + 5, col + 1) ' Mulai dari baris ke-5 agar tidak tumpang tindih

                        If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                            ' Cek apakah kolom numerik
                            Dim result As Decimal
                            If col > 0 AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
                                cell.Value = result
                                cell.Style.Numberformat.Format = "#,##0.00" ' Format desimal
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right ' Rata kanan untuk angka
                            Else
                                cell.Value = cellValue.ToString().Trim()
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left ' Rata kiri untuk teks
                            End If
                        End If
                    Next
                Next
                Dim tahun As Integer = txttahun.Text
                ws1.Cells(43, 4).Value = "Bandung, 30 April " & tahun + 1
                ws1.Cells(43, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                For i = 1 To 4
                    ws1.Cells(i, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws1.Cells(i, 1).Style.Font.Bold = True
                Next
                ws1.Cells(14, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws1.Cells(19, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws1.Cells(31, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws1.Cells(37, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws1.Cells(41, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ' === Beri border hanya di luar area A1:E42 ===
                For col As Integer = 1 To 5
                    ws1.Cells(1, col).Style.Border.Top.Style = ExcelBorderStyle.Medium
                Next
                ' Garis bawah (A41:E41)
                For col As Integer = 1 To 5
                    ws1.Cells(41, col).Style.Border.Bottom.Style = ExcelBorderStyle.Medium
                Next
                ' Garis kiri (A1:A41)
                For row As Integer = 1 To 41
                    ws1.Cells(row, 1).Style.Border.Left.Style = ExcelBorderStyle.Medium
                Next
                ' Garis kanan (E1:E41)
                For row As Integer = 1 To 41
                    ws1.Cells(row, 5).Style.Border.Right.Style = ExcelBorderStyle.Medium
                Next
                ws1.Cells(8, 2).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws1.Cells(8, 3).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws1.Cells(8, 5).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws1.Cells(10, 2).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws1.Cells(10, 3).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws1.Cells(10, 5).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ' === Beri garis ganda atas dan bawah di baris 4 (A4:E4) ===
                For col As Integer = 1 To 5
                    ws1.Cells(4, col).Style.Border.Top.Style = ExcelBorderStyle.Double ' Garis ganda atas
                    ws1.Cells(4, col).Style.Border.Bottom.Style = ExcelBorderStyle.Double ' Garis ganda bawah
                Next
                ws1.Column(1).Width = 45
                ws1.Column(2).Width = 22
                ws1.Column(3).Width = 22
                ws1.Column(4).Width = 22
                ws1.Column(5).Width = 22

                ws1.Cells.Style.Numberformat.Format = "#,##0;(#,##0)"
                'akhir sheet 1

                'sheet 2 hpp
                Dim ws2 As ExcelWorksheet = package.Workbook.Worksheets.Add("LAPKEU ARTHA")
                ' === Set judul laporan ===
                ws2.Cells(1, 1).Value = "CV ARTHA MEKAR LESTARI"
                ws2.Cells(1, 1, 1, 7).Merge = True
                ws2.Cells(2, 1).Value = "LAPORAN LABA RUGI"
                ws2.Cells(2, 1, 2, 7).Merge = True
                ws2.Cells(3, 1).Value = "1 JANUARI - 31 DESEMBER " & txttahun.Text
                ws2.Cells(3, 1, 3, 7).Merge = True

                ' === Isi data dari DataGridView ===
                For row As Integer = 0 To dgv_lapkeu.Rows.Count - 1
                    For col As Integer = 0 To dgv_lapkeu.ColumnCount - 1
                        Dim cellValue = dgv_lapkeu.Rows(row).Cells(col).Value
                        Dim cell = ws2.Cells(row + 4, col + 1) ' Mulai dari baris ke-5 agar tidak tumpang tindih

                        If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                            ' Cek apakah kolom numerik
                            Dim result As Decimal
                            If col > 0 AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
                                cell.Value = result
                                cell.Style.Numberformat.Format = "#,##0.00" ' Format desimal
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right ' Rata kanan untuk angka
                            Else
                                cell.Value = cellValue.ToString().Trim()
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left ' Rata kiri untuk teks
                            End If
                        End If
                    Next
                Next
                ws2.Cells(27, 5).Value = "Bandung, 30 April " & tahun + 1
                ws2.Cells(27, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
               
                ' === Beri border hanya di luar area A1:E42 ===
                For col As Integer = 1 To 7
                    ws2.Cells(1, col).Style.Border.Top.Style = ExcelBorderStyle.Medium
                Next
                ' Garis bawah (A26:E25)
                For col As Integer = 1 To 7
                    ws2.Cells(25, col).Style.Border.Bottom.Style = ExcelBorderStyle.Medium
                Next
                ' Garis kiri (A1:A25)
                For row As Integer = 1 To 25
                    ws2.Cells(row, 1).Style.Border.Left.Style = ExcelBorderStyle.Medium
                Next
                ' Garis kanan (G1:E25)
                For row As Integer = 1 To 25
                    ws2.Cells(row, 7).Style.Border.Right.Style = ExcelBorderStyle.Medium
                Next
                ws2.Cells(7, 3).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws2.Cells(7, 7).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws2.Cells(20, 3).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws2.Cells(20, 7).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                
                ' === Beri garis ganda atas dan bawah di baris 4 (A4:E4) ===
                For col As Integer = 1 To 7
                    ws2.Cells(4, col).Style.Border.Top.Style = ExcelBorderStyle.Double ' Garis ganda atas
                Next
                For i = 1 To 5
                    ws2.Cells(i, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws2.Cells(i, 1).Style.Font.Bold = True
                    For col = 1 To 7
                        ws2.Cells(5, col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws2.Cells(5, col).Style.Font.Bold = True
                    Next
                Next
                For i = 1 To 7
                    ws2.Cells(8, i).Style.Font.Bold = True
                    ws2.Cells(21, i).Style.Font.Bold = True
                    ws2.Cells(23, i).Style.Font.Bold = True
                    ws2.Cells(25, i).Style.Font.Bold = True
                Next
                ws2.Column(1).Width = 45
                ws2.Column(2).Width = 3
                ws2.Column(3).Width = 22
                ws2.Column(4).Width = 22
                ws2.Column(5).Width = 22
                ws2.Column(6).Width = 3
                ws2.Column(7).Width = 22

                For row As Integer = 0 To dgv_lapkeu_2.Rows.Count - 1
                    For col As Integer = 0 To dgv_lapkeu_2.ColumnCount - 1
                        Dim cellValue = dgv_lapkeu_2.Rows(row).Cells(col).Value
                        Dim cell = ws2.Cells(row + 34, col + 1) ' Mulai dari baris ke-5 agar tidak tumpang tindih

                        If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                            ' Cek apakah kolom numerik
                            Dim result As Decimal
                            If col > 0 AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
                                cell.Value = result
                                cell.Style.Numberformat.Format = "#,##0.00" ' Format desimal
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right ' Rata kanan untuk angka
                            Else
                                cell.Value = cellValue.ToString().Trim()
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left ' Rata kiri untuk teks
                            End If
                        End If
                    Next
                Next

                ws2.Cells(39, 4).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws2.Cells(47, 4).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

                ws2.Cells.Style.Numberformat.Format = "#,##0;(#,##0)"
                'akhir sheet 2

                'sheet 3 biaya
                Dim ws3 As ExcelWorksheet = package.Workbook.Worksheets.Add("BIAYA")
                ' Isi Data
                For row As Integer = 0 To dgv_biaya.Rows.Count - 1
                    For col As Integer = 0 To dgv_biaya.ColumnCount - 1
                        Dim cellValue = dgv_biaya.Rows(row).Cells(col).Value

                        If cellValue IsNot Nothing Then
                            Dim cell = ws3.Cells(row + 1, col + 1) ' Baris ke-2 untuk data

                            ' Cek apakah kolom numerik
                            Dim result As Decimal
                            If col > 0 AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
                                cell.Value = result
                                cell.Style.Numberformat.Format = "#,##0.00;(#,##0.00)" ' Format desimal
                            Else
                                cell.Value = cellValue.ToString()
                            End If
                        End If
                        ws3.Cells(row + 1, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next
                ws3.Column(1).Width = 43 ' Kolom pertama
                For col As Integer = 2 To dgv_biaya.ColumnCount - 1
                    ws3.Column(col).Width = 17 ' Kolom lainnya
                Next
                ws3.Column(dgv_biaya.ColumnCount).Width = 20
                ws3.Column(dgv_biaya.ColumnCount - 1).Width = 20
                ws3.Column(dgv_biaya.ColumnCount - 2).Width = 20 ' Kolom terakhir
                ' Pastikan semua kolom di baris pertama & kedua juga rata tengah
                For i = 1 To dgv_biaya.ColumnCount - 1
                    ws3.Cells(1, i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws3.Cells(2, i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                Next
                For i As Integer = 1 To 13
                    Dim startCol As Integer = (i - 1) * 3 + 2 ' Kolom awal: 2, 5, 8, 11, ...
                    Dim endCol As Integer = startCol + 2      ' Kolom akhir: 4, 7, 10, 13, ...
                    ws3.Cells(1, startCol, 1, endCol).Merge = True
                Next

                ' Sheet 4: MASUKAN
                Dim ws4 As ExcelWorksheet = package.Workbook.Worksheets.Add("MASUKAN")
                ws4.Cells(1, 1).Value = "DATA MASUKAN TAHUN " & txttahun.Text
                ws4.Cells(1, 1, 1, dgv_masukan.Columns.Count).Merge = True
                For col As Integer = 0 To dgv_masukan.Columns.Count - 1
                    ws4.Cells(3, col + 1).Value = dgv_masukan.Columns(col).HeaderText
                    ws4.Cells(3, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws4.Cells(3, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                For row As Integer = 0 To dgv_masukan.Rows.Count - 1
                    For col As Integer = 0 To dgv_masukan.Columns.Count - 1
                        ws4.Cells(row + 4, col + 1).Value = dgv_masukan.Rows(row).Cells(col).Value
                        ws4.Cells(row + 4, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws4.Cells(row + 4, col + 1)
                        Dim value = dgv_masukan.Rows(row).Cells(col).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                    Next
                Next

                Dim totalrowmasukan As Integer = dgv_masukan.Rows.Count + 6
                For row As Integer = 0 To dgv_list_masukan.Rows.Count - 1
                    For col As Integer = 0 To dgv_list_masukan.Columns.Count - 1
                        Dim cell = ws4.Cells(row + totalrowmasukan, col + 1)
                        Dim value = dgv_list_masukan(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next

                ws4.Cells(3, 2).Value = "DPP MASUKAN KAIN"
                ws4.Cells(3, 3).Value = "DPP MASUKAN OBAT"
                ws4.Cells(3, 4).Value = "DPP MASUKAN BATUBARA"
                ws4.Cells(3, 5).Value = "DPP MASUKAN LAIN2"
                ws4.Cells(3, 6).Value = "TOTAL DPP MASUKAN"

                ws4.Cells(ws4.Dimension.Address).AutoFitColumns()
                ' Akhir Sheet 4

                ' Sheet 5: KELUARAN
                Dim ws5 As ExcelWorksheet = package.Workbook.Worksheets.Add("KELUARAN")
                For col As Integer = 0 To dgv_keluaran.Columns.Count - 1
                    ws5.Cells(3, col + 1).Value = dgv_keluaran.Columns(col).HeaderText
                    ws5.Cells(3, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws5.Cells(3, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                For row As Integer = 0 To dgv_keluaran.Rows.Count - 1
                    For col As Integer = 0 To dgv_keluaran.Columns.Count - 1
                        ws5.Cells(row + 4, col + 1).Value = dgv_keluaran.Rows(row).Cells(col).Value
                        ws5.Cells(row + 4, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws5.Cells(row + 4, col + 1)
                        Dim value = dgv_keluaran.Rows(row).Cells(col).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If

                        Dim dgvCell = dgv_keluaran.Rows(row).Cells(col)
                        ' Terapkan warna teks (ForeColor)
                        Dim foreColor As Color = dgvCell.Style.ForeColor
                        If foreColor <> Color.Empty Then
                            cell.Style.Font.Color.SetColor(foreColor)
                        End If

                        ' Terapkan warna latar belakang (BackColor)
                        Dim backColor As Color = dgvCell.Style.BackColor
                        If backColor <> Color.Empty Then
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                            cell.Style.Fill.BackgroundColor.SetColor(backColor)
                        End If
                    Next
                Next

                Dim totalrowkeluaran As Integer = dgv_keluaran.Rows.Count + 6
                For row As Integer = 0 To dgv_list_keluaran.Rows.Count - 1
                    For col As Integer = 0 To dgv_list_keluaran.Columns.Count - 1
                        Dim cell = ws5.Cells(row + totalrowkeluaran, col + 1)
                        Dim value = dgv_list_keluaran(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next

                Dim totalrowsatuan As Integer = dgv_keluaran.Rows.Count + 6
                For row As Integer = 0 To dgv_keluaran_satuan.Rows.Count - 1
                    For col As Integer = 0 To dgv_keluaran_satuan.Columns.Count - 1
                        Dim cell = ws5.Cells(row + totalrowsatuan, col + 4)
                        Dim value = dgv_keluaran_satuan(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next
                ws5.Cells(1, 1).Value = "DATA KELUARAN TAHUN " & txttahun.Text
                ws5.Cells(1, 1, 1, dgv_keluaran.Columns.Count).Merge = True
                ws5.Cells(3, 2).Value = "DPP CELUPAN"
                ws5.Cells(3, 3).Value = "DPP KAIN"
                ws5.Cells(3, 4).Value = "DPP TOTAL"
                ws5.Cells(3, 5).Value = "DPP SESUAI SPT"
                ws5.Cells(3, 6).Value = "SELISIH"
                ws5.Cells(3, 7).Value = ""
                ws5.Cells(3, 8).Value = "KG CELUPAN"
                ws5.Cells(3, 9).Value = "MTR KAIN"
                ws5.Cells(3, 10).Value = "YARD KAIN"

                ws5.Cells(ws5.Dimension.Address).AutoFitColumns()
                ' Akhir Sheet 5

                ' Sheet 6: SPT Masa PPN
                Dim ws6 As ExcelWorksheet = package.Workbook.Worksheets.Add("SPT Masa PPN")
                ws6.Cells(1, 1).Value = "SPT MASA PPN EFAKTUR TAHUN " & txttahun.Text
                ws6.Cells(1, 1, 1, dgv_spt_clone.Columns.Count).Merge = True
                For col As Integer = 0 To dgv_spt_clone.Columns.Count - 1
                    ws6.Cells(3, col + 1).Value = dgv_spt_clone.Columns(col).HeaderText
                    ws6.Cells(3, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws6.Cells(3, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                For row As Integer = 0 To dgv_spt_clone.Rows.Count - 1
                    For col As Integer = 0 To dgv_spt_clone.Columns.Count - 1
                        Dim cell = ws6.Cells(row + 4, col + 1)
                        Dim value = dgv_spt_clone(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next
                For col As Integer = 1 To dgv_spt_clone.Columns.Count + 1
                    ws6.Column(col).Width = 145 / 7.5 ' Mengonversi px ke Excel units
                Next

                ' Tambahkan baris total
                Dim totalRow As Integer = dgv_spt_clone.Rows.Count + 4
                For col As Integer = 1 To dgv_spt_clone.Columns.Count - 1
                    ws6.Cells(totalRow, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim nilaimasukan As Decimal = 0
                Dim nilaikeluaran As Decimal = 0
                Dim ppnmasukan As Decimal = 0
                Dim ppnkeluaran As Decimal = 0
                Dim ppndisetor As Decimal = 0
                For row As Integer = 0 To dgv_spt_clone.Rows.Count - 1
                    nilaimasukan += dgv_spt_clone(1, row).Value
                    nilaikeluaran += dgv_spt_clone(2, row).Value
                    ppnmasukan += dgv_spt_clone(5, row).Value
                    ppnkeluaran += dgv_spt_clone(6, row).Value
                    ppndisetor += dgv_spt_clone(7, row).Value
                Next
                ws6.Cells(totalRow, 2).Value = nilaimasukan
                ws6.Cells(totalRow, 3).Value = nilaikeluaran
                ws6.Cells(totalRow, 6).Value = ppnmasukan
                ws6.Cells(totalRow, 7).Value = ppnkeluaran
                ws6.Cells(totalRow, 8).Value = ppndisetor
                For i As Integer = 2 To 8
                    ws6.Cells(totalRow, i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    ws6.Cells(totalRow, i).Style.Numberformat.Format = "#,##0.00"
                Next

                ws6.Cells(totalRow + 2, 1).Value = "SPT MASA PPN AML TAHUN " & txttahun.Text
                ws6.Cells(totalRow + 2, 1, totalRow + 2, dgv_spt_aml.Columns.Count).Merge = True
                For col As Integer = 0 To dgv_spt_aml.Columns.Count - 1
                    ws6.Cells(totalRow + 4, col + 1).Value = dgv_spt_aml.Columns(col).HeaderText
                    ws6.Cells(totalRow + 4, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws6.Cells(totalRow + 4, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                For row As Integer = 0 To dgv_spt_aml.Rows.Count - 1
                    For col As Integer = 0 To dgv_spt_aml.Columns.Count - 1
                        Dim cell = ws6.Cells(row + totalRow + 5, col + 1)
                        Dim value = dgv_spt_aml(col, row).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next

                ' Tambahkan baris total
                Dim akhirbaris As Integer = dgv_spt_aml.Rows.Count + totalRow + 5
                For col As Integer = 1 To dgv_spt_aml.Columns.Count - 1
                    ws6.Cells(akhirbaris, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim nilaimasukanaml As Decimal = 0
                Dim nilaikeluaranaml As Decimal = 0
                Dim ppnmasukanaml As Decimal = 0
                Dim ppnkeluaranaml As Decimal = 0
                Dim ppndisetoraml As Decimal = 0
                For row As Integer = 0 To dgv_spt_aml.Rows.Count - 1
                    nilaimasukanaml += dgv_spt_aml(1, row).Value
                    nilaikeluaranaml += dgv_spt_aml(2, row).Value
                    ppnmasukanaml += dgv_spt_aml(5, row).Value
                    ppnkeluaranaml += dgv_spt_aml(6, row).Value
                    ppndisetoraml += dgv_spt_aml(7, row).Value
                Next
                ws6.Cells(akhirbaris, 2).Value = nilaimasukanaml
                ws6.Cells(akhirbaris, 3).Value = nilaikeluaranaml
                ws6.Cells(akhirbaris, 6).Value = ppnmasukanaml
                ws6.Cells(akhirbaris, 7).Value = ppnkeluaranaml
                ws6.Cells(akhirbaris, 8).Value = ppndisetoraml
                For i As Integer = 2 To 8
                    ws6.Cells(akhirbaris, i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    ws6.Cells(akhirbaris, i).Style.Numberformat.Format = "#,##0.00"
                Next
                ' Akhir sheet 6

                ' Sheet 7: PLN GARAM COAL
                Dim ws7 As ExcelWorksheet = package.Workbook.Worksheets.Add("PLN GARAM COAL")
                ws7.Cells(1, 1).Value = "DATA PLN GARAM COAL TAHUN " & txttahun.Text
                ws7.Cells(1, 1, 1, dgv_pln.Columns.Count).Merge = True
                'ws7.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'ws7.Cells(1, 1).Style.Font.Bold = True
                'Header PLN GARAM COAL
                For col As Integer = 0 To dgv_pln.Columns.Count - 1
                    ws7.Cells(3, col + 1).Value = dgv_pln.Columns(col).HeaderText
                    'ws7.Cells(3, col + 1).Style.Font.Bold = True
                    ws7.Cells(3, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws7.Cells(3, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                ' Data PLN GARAM COAL
                For row As Integer = 0 To dgv_pln.Rows.Count - 1
                    For col As Integer = 0 To dgv_pln.Columns.Count - 1
                        ws7.Cells(row + 4, col + 1).Value = dgv_pln.Rows(row).Cells(col).Value
                        ws7.Cells(row + 4, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws7.Cells(row + 4, col + 1)
                        Dim value = dgv_pln.Rows(row).Cells(col).Value
                        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                            If value < 0 Then
                                ' Format nilai negatif dengan tanda kurung
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0;(#,##0.00)" ' Format Excel untuk tanda kurung
                            Else
                                ' Format nilai positif biasa
                                cell.Value = value
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                        Else
                            cell.Value = value
                        End If
                    Next
                Next
                'ws7.Cells(ws7.Dimension.Address).AutoFitColumns()
                For col As Integer = 1 To dgv_pln.Columns.Count + 1
                    ws7.Column(col).Width = 135 / 7.5 ' Mengonversi px ke Excel units
                Next
                ws7.Cells(3, 2).Value = "PLN"
                ws7.Cells(3, 3).Value = "GARAM"
                ws7.Cells(3, 4).Value = "COAL"
                ws7.Cells(3, 5).Value = "PPH 22 COAL"

                ' Akhir Sheet 7

                ' Sheet 8: DAFTAR BUKTI POTONG
                Dim ws8 As ExcelWorksheet = package.Workbook.Worksheets.Add("DAFTAR BUKTI POTONG")
                ws8.Cells(1, 1, 1, dgv_bukpot.Columns.Count - 1).Merge = True
                ws8.Cells(1, 1).Value = "DAFTAR BUKTI POTONG TAHUN PAJAK " & txttahun.Text
                'ws8.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'ws8.Cells(1, 1).Style.Font.Bold = True
                ' Header DAFTAR BUKTI POTONG
                Dim headers = {"NO", "NAMA CUSTOMER PEMOTONG", "NPWP CUSTOMER", "TANGGAL FP", "NO FAKTUR PAJAK", "NILAI DPP", "PPN", "PPH23", "PPH23 ACTUAL", "NO BUKPOT", "TGL BUKPOT", "MASA BUKPOT"}
                For col As Integer = 0 To headers.Length - 1
                    ws8.Cells(3, col + 1).Value = headers(col)
                    'ws8.Cells(3, col + 1).Style.Font.Bold = True
                    ws8.Cells(3, col + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws8.Cells(3, col + 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    'ws8.Cells(3, col + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                    'ws8.Cells(3, col + 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                Next
                ' Mengelompokkan data berdasarkan nilai gabung_bukpot
                Dim groupedData As New List(Of Dictionary(Of String, Object))
                Dim tempGroup As Dictionary(Of String, Object) = Nothing
                For row As Integer = 0 To dgv_bukpot.Rows.Count - 1
                    Dim gabung_bukpot = dgv_bukpot.Rows(row).Cells("gabung_bukpot").Value.ToString()
                    If tempGroup IsNot Nothing AndAlso tempGroup("gabung_bukpot").ToString() = gabung_bukpot Then
                        ' Gabungkan nilai pph23_actual
                        tempGroup("pph23_actual") = CDbl(tempGroup("pph23_actual")) + CDbl(dgv_bukpot.Rows(row).Cells("pph23_actual").Value)
                        tempGroup("Rows").Add(row)
                    Else
                        ' Tambahkan grup baru
                        If tempGroup IsNot Nothing Then groupedData.Add(tempGroup)
                        tempGroup = New Dictionary(Of String, Object) From {
                            {"gabung_bukpot", gabung_bukpot},
                            {"pph23_actual", dgv_bukpot.Rows(row).Cells("pph23_actual").Value},
                            {"Rows", New List(Of Integer) From {row}}
                        }
                    End If
                Next
                If tempGroup IsNot Nothing Then groupedData.Add(tempGroup)

                ' Mengisi data ke Excel
                Dim rowIndex As Integer = 4
                For Each group In groupedData
                    Dim Rows = group("Rows")
                    Dim startRow = rowIndex
                    Dim endRow = rowIndex + Rows.Count - 1

                    For Each rowIndexInGroup In Rows
                        ' Menulis nomor urut
                        ws8.Cells(rowIndex, 1).Value = rowIndex - 3
                        ws8.Cells(rowIndex, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws8.Cells(rowIndex, 1).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        ' Menulis data ke kolom lain
                        Dim colIndexData As Integer = 1
                        For col As Integer = 0 To dgv_bukpot.Columns.Count - 1
                            If dgv_bukpot.Columns(col).Name <> "id_jual" AndAlso dgv_bukpot.Columns(col).Name <> "gabung_bukpot" Then
                                colIndexData += 1
                                Dim cell = ws8.Cells(rowIndex, colIndexData)
                                Dim value = dgv_bukpot.Rows(rowIndexInGroup).Cells(col).Value

                                ' Format khusus untuk kolom tertentu
                                Select Case dgv_bukpot.Columns(col).Name
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
                                            ws8.Cells(startRow, colIndexData, endRow, colIndexData).Merge = True
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
                ws8.Cells(ws8.Dimension.Address).AutoFitColumns()
                'Akhir sheet 8

                'Sheet 9 : Rincian penyusutan
                Dim ws9 As ExcelWorksheet = package.Workbook.Worksheets.Add("RINCIAN PENYUSUTAN")
                ws9.Cells(2, 2).Value = "MESIN"
                ws9.Cells(2, 2).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 0 To dgv_induk_penyusutan_mesin.Columns.Count - 1
                    ws9.Cells(2, col + 3).Value = dgv_induk_penyusutan_mesin.Columns(col).HeaderText
                    ws9.Cells(2, col + 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(2, col + 3).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim baris_mesin As Integer = 0
                'For row As Integer = 0 To dgv_induk_penyusutan_mesin.Rows.Count - 1
                '    For col As Integer = 0 To dgv_induk_penyusutan_mesin.Columns.Count - 1
                '        ws9.Cells(row + 3, col + 3).Value = dgv_induk_penyusutan_mesin.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3, col + 3).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3, col + 3)
                '        Dim value = dgv_induk_penyusutan_mesin.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                '    baris_mesin += 1
                'Next

                For row As Integer = 0 To dgv_induk_penyusutan_mesin.Rows.Count - 1
                    For col As Integer = 0 To dgv_induk_penyusutan_mesin.Columns.Count - 1
                        ws9.Cells(row + 3, col + 3).Value = dgv_induk_penyusutan_mesin.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3, col + 3).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3, col + 3)
                        Dim value = dgv_induk_penyusutan_mesin.Rows(row).Cells(col).Value
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                    baris_mesin += 1
                Next
                ws9.Cells(2, 2, baris_mesin + 2, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws9.Cells(2, 2, baris_mesin + 2, 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                ws9.Cells(2, 2, baris_mesin + 2, 2).Merge = True
                ws9.Cells(2, 2, baris_mesin + 2, 2).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                ws9.Cells(2, 7).Value = "TANKI"
                ws9.Cells(2, 7).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 0 To dgv_induk_penyusutan_tanki.Columns.Count - 1
                    ws9.Cells(2, col + 8).Value = dgv_induk_penyusutan_tanki.Columns(col).HeaderText
                    ws9.Cells(2, col + 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(2, col + 8).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim baris_tanki As Integer = 0
                For row As Integer = 0 To dgv_induk_penyusutan_tanki.Rows.Count - 1
                    For col As Integer = 0 To dgv_induk_penyusutan_tanki.Columns.Count - 1
                        ws9.Cells(row + 3, col + 8).Value = dgv_induk_penyusutan_tanki.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3, col + 8).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3, col + 8)
                        Dim value = dgv_induk_penyusutan_tanki.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                    baris_tanki += 1
                Next
                ws9.Cells(2, 7, baris_tanki + 2, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws9.Cells(2, 7, baris_tanki + 2, 7).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                ws9.Cells(2, 7, baris_tanki + 2, 7).Merge = True
                ws9.Cells(2, 7, baris_tanki + 2, 7).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                ws9.Cells(2, 12).Value = "INVENTARIS"
                ws9.Cells(2, 12).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 0 To dgv_induk_penyusutan_inventaris.Columns.Count - 1
                    ws9.Cells(2, col + 13).Value = dgv_induk_penyusutan_inventaris.Columns(col).HeaderText
                    ws9.Cells(2, col + 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(2, col + 13).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim baris_inventaris As Integer = 0
                For row As Integer = 0 To dgv_induk_penyusutan_inventaris.Rows.Count - 1
                    For col As Integer = 0 To dgv_induk_penyusutan_inventaris.Columns.Count - 1
                        ws9.Cells(row + 3, col + 13).Value = dgv_induk_penyusutan_inventaris.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3, col + 13).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3, col + 13)
                        Dim value = dgv_induk_penyusutan_inventaris.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                    baris_inventaris += 1
                Next
                ws9.Cells(2, 12, baris_inventaris + 2, 12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws9.Cells(2, 12, baris_inventaris + 2, 12).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                ws9.Cells(2, 12, baris_inventaris + 2, 12).Merge = True
                ws9.Cells(2, 12, baris_inventaris + 2, 12).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                ws9.Cells(2, 17).Value = "BANGUNAN"
                ws9.Cells(2, 17).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 0 To dgv_induk_penyusutan_bangunan.Columns.Count - 1
                    ws9.Cells(2, col + 18).Value = dgv_induk_penyusutan_bangunan.Columns(col).HeaderText
                    ws9.Cells(2, col + 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(2, col + 18).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim baris_bangunan As Integer = 0
                For row As Integer = 0 To dgv_induk_penyusutan_bangunan.Rows.Count - 1
                    For col As Integer = 0 To dgv_induk_penyusutan_bangunan.Columns.Count - 1
                        ws9.Cells(row + 3, col + 18).Value = dgv_induk_penyusutan_bangunan.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3, col + 18).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3, col + 18)
                        Dim value = dgv_induk_penyusutan_bangunan.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                    baris_bangunan += 1
                Next
                ws9.Cells(2, 17, baris_bangunan + 2, 17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws9.Cells(2, 17, baris_bangunan + 2, 17).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                ws9.Cells(2, 17, baris_bangunan + 2, 17).Merge = True
                ws9.Cells(2, 17, baris_bangunan + 2, 17).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                ws9.Cells(2, 22).Value = "KENDARAAN"
                ws9.Cells(2, 22).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                For col As Integer = 0 To dgv_induk_penyusutan_kendaraan.Columns.Count - 1
                    ws9.Cells(2, col + 23).Value = dgv_induk_penyusutan_kendaraan.Columns(col).HeaderText
                    ws9.Cells(2, col + 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(2, col + 23).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                Dim baris_kendaraan As Integer = 0
                For row As Integer = 0 To dgv_induk_penyusutan_kendaraan.Rows.Count - 1
                    For col As Integer = 0 To dgv_induk_penyusutan_kendaraan.Columns.Count - 1
                        ws9.Cells(row + 3, col + 23).Value = dgv_induk_penyusutan_kendaraan.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3, col + 23).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3, col + 23)
                        Dim value = dgv_induk_penyusutan_kendaraan.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                    baris_kendaraan += 1
                Next
                ws9.Cells(2, 22, baris_kendaraan + 2, 22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws9.Cells(2, 22, baris_kendaraan + 2, 22).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                ws9.Cells(2, 22, baris_kendaraan + 2, 22).Merge = True
                ws9.Cells(2, 22, baris_kendaraan + 2, 22).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                ws9.Cells(ws9.Dimension.Address).AutoFitColumns()
                ws9.Column(2).Width = 13
                ws9.Column(3).Width = 13
                ws9.Column(7).Width = 13
                ws9.Column(8).Width = 13
                ws9.Column(12).Width = 13
                ws9.Column(13).Width = 13
                ws9.Column(17).Width = 13
                ws9.Column(18).Width = 13
                ws9.Column(22).Width = 13
                ws9.Column(23).Width = 13

                'Data Penyusutan
                'MESIN
                'For row As Integer = 0 To dgv_penyusutan_mesin.Rows.Count - 1
                '    For col As Integer = 0 To dgv_penyusutan_mesin.Columns.Count - 2
                '        ws9.Cells(row + 3 + baris_mesin + 1, col + 2).Value = dgv_penyusutan_mesin.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3 + baris_mesin + 1, col + 2).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3 + baris_mesin + 1, col + 2)
                '        Dim value = dgv_penyusutan_mesin.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3 + baris_mesin + 1, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_mesin + 1, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_mesin + 1, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3 + baris_mesin + 1, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                'Next
                For row As Integer = 0 To dgv_penyusutan_mesin.Rows.Count - 1
                    For col As Integer = 0 To dgv_penyusutan_mesin.Columns.Count - 2
                        Dim cell = ws9.Cells(row + 3 + baris_mesin + 1, col + 2)
                        Dim value As Object = dgv_penyusutan_mesin.Rows(row).Cells(col).Value

                        ' Pastikan nilai tidak Null

                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If

                        ' Tambahkan Border untuk setiap sel
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)

                        ' Atur Alignment
                        ws9.Cells(row + 3 + baris_mesin + 1, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_mesin + 1, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_mesin + 1, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_mesin + 1, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                For i As Integer = 0 To baris_mesin + dgv_penyusutan_mesin.Rows.Count - 18
                    ws9.Cells(3 + baris_mesin + 1 + i, 2, 3 + baris_mesin + 2 + i, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_mesin + 1 + i, 2, 3 + baris_mesin + 2 + i, 4).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_mesin + 1 + i, 2, 3 + baris_mesin + 2 + i, 4).Merge = True
                    ws9.Cells(3 + baris_mesin + 1 + i, 2, 3 + baris_mesin + 2 + i, 4).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_mesin + 1 + i, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    i += 18
                Next
                For i As Integer = 0 To baris_mesin + dgv_penyusutan_mesin.Rows.Count - 18
                    Dim range = ws9.Cells(3 + baris_mesin + 19 + i, 2, 3 + baris_mesin + 19 + i, 5)
                    range.Style.Border.Top.Style = ExcelBorderStyle.None
                    range.Style.Border.Left.Style = ExcelBorderStyle.None
                    range.Style.Border.Right.Style = ExcelBorderStyle.None
                    ' Cek apakah ini iterasi terakhir
                    If i + 18 > baris_mesin + dgv_penyusutan_mesin.Rows.Count - 18 Then
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.None
                    Else
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin
                    i += 18
                Next
                baris_mesin += dgv_penyusutan_mesin.Rows.Count
                For row As Integer = 0 To dgv_gabungan_penyusutan_mesin.Rows.Count - 1
                    For col As Integer = 0 To dgv_gabungan_penyusutan_mesin.Columns.Count - 1
                        ws9.Cells(row + 3 + baris_mesin + 1, col + 2).Value = dgv_gabungan_penyusutan_mesin.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3 + baris_mesin + 1, col + 2).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3 + baris_mesin + 1, col + 2)
                        Dim value = dgv_gabungan_penyusutan_mesin.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3 + baris_mesin + 1, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_mesin + 1, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_mesin + 1, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_mesin + 1, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                If dgv_gabungan_penyusutan_mesin.RowCount <> 0 Then
                    ws9.Cells(3 + baris_mesin + 1, 2, 3 + baris_mesin + 2, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_mesin + 1, 2, 3 + baris_mesin + 2, 5).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_mesin + 1, 2, 3 + baris_mesin + 2, 5).Merge = True
                    ws9.Cells(3 + baris_mesin + 1, 2, 3 + baris_mesin + 2, 5).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_mesin + 3, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_mesin + 3, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End If

                'TANKI
                'For row As Integer = 0 To dgv_penyusutan_tanki.Rows.Count - 1
                '    For col As Integer = 0 To dgv_penyusutan_tanki.Columns.Count - 2
                '        ws9.Cells(row + 3 + baris_tanki + 1, col + 7).Value = dgv_penyusutan_tanki.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3 + baris_tanki + 1, col + 7).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3 + baris_tanki + 1, col + 7)
                '        Dim value = dgv_penyusutan_tanki.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3 + baris_tanki + 1, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_tanki + 1, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_tanki + 1, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3 + baris_tanki + 1, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                'Next
                For row As Integer = 0 To dgv_penyusutan_tanki.Rows.Count - 1
                    For col As Integer = 0 To dgv_penyusutan_tanki.Columns.Count - 2
                        Dim cell = ws9.Cells(row + 3 + baris_tanki + 1, col + 7)
                        Dim value As Object = dgv_penyusutan_tanki.Rows(row).Cells(col).Value

                        ' Pastikan nilai tidak Null atau DBNull
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If

                        ' Tambahkan Border untuk setiap sel
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next

                    ' Atur perataan teks di kolom sesuai dengan posisi data
                    ws9.Cells(row + 3 + baris_tanki + 1, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(row + 3 + baris_tanki + 1, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(row + 3 + baris_tanki + 1, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    ws9.Cells(row + 3 + baris_tanki + 1, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                Next
                For i As Integer = 0 To baris_tanki + dgv_penyusutan_tanki.Rows.Count - 19
                    ws9.Cells(3 + baris_tanki + 1 + i, 7, 3 + baris_tanki + 2 + i, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_tanki + 1 + i, 7, 3 + baris_tanki + 2 + i, 9).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_tanki + 1 + i, 7, 3 + baris_tanki + 2 + i, 9).Merge = True
                    ws9.Cells(3 + baris_tanki + 1 + i, 7, 3 + baris_tanki + 2 + i, 9).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_tanki + 1 + i, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    i += 19
                Next
                For i As Integer = 0 To baris_tanki + dgv_penyusutan_tanki.Rows.Count - 19
                    Dim range = ws9.Cells(3 + baris_tanki + 20 + i, 7, 3 + baris_tanki + 20 + i, 10)
                    range.Style.Border.Top.Style = ExcelBorderStyle.None
                    range.Style.Border.Left.Style = ExcelBorderStyle.None
                    range.Style.Border.Right.Style = ExcelBorderStyle.None
                    ' Cek apakah ini iterasi terakhir
                    If i + 19 > baris_tanki + dgv_penyusutan_tanki.Rows.Count - 19 Then
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.None
                    Else
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin
                    i += 19
                Next
                baris_tanki += dgv_penyusutan_tanki.Rows.Count
                For row As Integer = 0 To dgv_gabungan_penyusutan_tanki.Rows.Count - 1
                    For col As Integer = 0 To dgv_gabungan_penyusutan_tanki.Columns.Count - 1
                        ws9.Cells(row + 3 + baris_tanki + 1, col + 7).Value = dgv_gabungan_penyusutan_tanki.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3 + baris_tanki + 1, col + 7).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3 + baris_tanki + 1, col + 7)
                        Dim value = dgv_gabungan_penyusutan_tanki.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3 + baris_tanki + 1, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_tanki + 1, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_tanki + 1, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_tanki + 1, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                If dgv_gabungan_penyusutan_tanki.RowCount <> 0 Then
                    ws9.Cells(3 + baris_tanki + 1, 7, 3 + baris_tanki + 2, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_tanki + 1, 7, 3 + baris_tanki + 2, 10).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_tanki + 1, 7, 3 + baris_tanki + 2, 10).Merge = True
                    ws9.Cells(3 + baris_tanki + 1, 7, 3 + baris_tanki + 2, 10).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_tanki + 3, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_tanki + 3, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End If

                'INVENTARIS
                'For row As Integer = 0 To dgv_penyusutan_inventaris.Rows.Count - 1
                '    For col As Integer = 0 To dgv_penyusutan_inventaris.Columns.Count - 2
                '        ws9.Cells(row + 3 + baris_inventaris + 1, col + 12).Value = dgv_penyusutan_inventaris.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3 + baris_inventaris + 1, col + 12).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3 + baris_inventaris + 1, col + 12)
                '        Dim value = dgv_penyusutan_inventaris.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3 + baris_inventaris + 1, 12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_inventaris + 1, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_inventaris + 1, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3 + baris_inventaris + 1, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                'Next
                For row As Integer = 0 To dgv_penyusutan_inventaris.Rows.Count - 1
                    For col As Integer = 0 To dgv_penyusutan_inventaris.Columns.Count - 2
                        Dim cell = ws9.Cells(row + 3 + baris_inventaris + 1, col + 12)
                        Dim value As Object = dgv_penyusutan_inventaris.Rows(row).Cells(col).Value

                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = ""
                        End If

                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next

                    ws9.Cells(row + 3 + baris_inventaris + 1, 12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(row + 3 + baris_inventaris + 1, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(row + 3 + baris_inventaris + 1, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    ws9.Cells(row + 3 + baris_inventaris + 1, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                Next

                For i As Integer = 0 To baris_inventaris + dgv_penyusutan_inventaris.Rows.Count - 6
                    ws9.Cells(3 + baris_inventaris + 1 + i, 12, 3 + baris_inventaris + 2 + i, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_inventaris + 1 + i, 12, 3 + baris_inventaris + 2 + i, 14).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_inventaris + 1 + i, 12, 3 + baris_inventaris + 2 + i, 14).Merge = True
                    ws9.Cells(3 + baris_inventaris + 1 + i, 12, 3 + baris_inventaris + 2 + i, 14).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_inventaris + 1 + i, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    i += 6
                Next
                For i As Integer = 0 To baris_inventaris + dgv_penyusutan_inventaris.Rows.Count - 6
                    Dim range = ws9.Cells(3 + baris_inventaris + 7 + i, 12, 3 + baris_inventaris + 7 + i, 15)
                    range.Style.Border.Top.Style = ExcelBorderStyle.None
                    range.Style.Border.Left.Style = ExcelBorderStyle.None
                    range.Style.Border.Right.Style = ExcelBorderStyle.None
                    If i + 6 > baris_inventaris + dgv_penyusutan_inventaris.Rows.Count - 6 Then
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.None
                    Else
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin
                    i += 6
                Next
                baris_inventaris += dgv_penyusutan_inventaris.Rows.Count
                For row As Integer = 0 To dgv_gabungan_penyusutan_inventaris.Rows.Count - 1
                    For col As Integer = 0 To dgv_gabungan_penyusutan_inventaris.Columns.Count - 1
                        ws9.Cells(row + 3 + baris_inventaris + 1, col + 12).Value = dgv_gabungan_penyusutan_inventaris.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3 + baris_inventaris + 1, col + 12).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3 + baris_inventaris + 1, col + 12)
                        Dim value = dgv_gabungan_penyusutan_inventaris.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3 + baris_inventaris + 1, 12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_inventaris + 1, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_inventaris + 1, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_inventaris + 1, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                If dgv_gabungan_penyusutan_inventaris.RowCount <> 0 Then
                    ws9.Cells(3 + baris_inventaris + 1, 12, 3 + baris_inventaris + 2, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_inventaris + 1, 12, 3 + baris_inventaris + 2, 15).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_inventaris + 1, 12, 3 + baris_inventaris + 2, 15).Merge = True
                    ws9.Cells(3 + baris_inventaris + 1, 12, 3 + baris_inventaris + 2, 15).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_inventaris + 3, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_inventaris + 3, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End If

                'BANGUNAN
                'For row As Integer = 0 To dgv_penyusutan_bangunan.Rows.Count - 1
                '    For col As Integer = 0 To dgv_penyusutan_bangunan.Columns.Count - 2
                '        ws9.Cells(row + 3 + baris_bangunan + 1, col + 17).Value = dgv_penyusutan_bangunan.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3 + baris_bangunan + 1, col + 17).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3 + baris_bangunan + 1, col + 17)
                '        Dim value = dgv_penyusutan_bangunan.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3 + baris_bangunan + 1, 17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_bangunan + 1, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_bangunan + 1, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3 + baris_bangunan + 1, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                'Next
                For row As Integer = 0 To dgv_penyusutan_bangunan.Rows.Count - 1
                    For col As Integer = 0 To dgv_penyusutan_bangunan.Columns.Count - 2
                        Dim cell = ws9.Cells(row + 3 + baris_bangunan + 1, col + 17)
                        Dim value As Object = dgv_penyusutan_bangunan.Rows(row).Cells(col).Value

                        ' Pastikan nilai tidak Null
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If

                        ' Tambahkan Border untuk setiap sel
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)

                        ' Atur Alignment
                        ws9.Cells(row + 3 + baris_bangunan + 1, 17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_bangunan + 1, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_bangunan + 1, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_bangunan + 1, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                For i As Integer = 0 To baris_bangunan + dgv_penyusutan_bangunan.Rows.Count - 22
                    ws9.Cells(3 + baris_bangunan + 1 + i, 17, 3 + baris_bangunan + 2 + i, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_bangunan + 1 + i, 17, 3 + baris_bangunan + 2 + i, 19).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_bangunan + 1 + i, 17, 3 + baris_bangunan + 2 + i, 19).Merge = True
                    ws9.Cells(3 + baris_bangunan + 1 + i, 17, 3 + baris_bangunan + 2 + i, 19).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_bangunan + 1 + i, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    i += 22
                Next
                For i As Integer = 0 To baris_bangunan + dgv_penyusutan_bangunan.Rows.Count - 22
                    Dim range = ws9.Cells(3 + baris_bangunan + 23 + i, 17, 3 + baris_bangunan + 23 + i, 20)
                    range.Style.Border.Top.Style = ExcelBorderStyle.None
                    range.Style.Border.Left.Style = ExcelBorderStyle.None
                    range.Style.Border.Right.Style = ExcelBorderStyle.None
                    If i + 22 > baris_bangunan + dgv_penyusutan_bangunan.Rows.Count - 22 Then
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.None
                    Else
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin
                    i += 22
                Next
                baris_bangunan += dgv_penyusutan_bangunan.Rows.Count
                For row As Integer = 0 To dgv_gabungan_penyusutan_bangunan.Rows.Count - 1
                    For col As Integer = 0 To dgv_gabungan_penyusutan_bangunan.Columns.Count - 1
                        ws9.Cells(row + 3 + baris_bangunan + 1, col + 17).Value = dgv_gabungan_penyusutan_bangunan.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3 + baris_bangunan + 1, col + 17).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3 + baris_bangunan + 1, col + 17)
                        Dim value = dgv_gabungan_penyusutan_bangunan.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3 + baris_bangunan + 1, 17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_bangunan + 1, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_bangunan + 1, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_bangunan + 1, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                If dgv_gabungan_penyusutan_bangunan.RowCount <> 0 Then
                    ws9.Cells(3 + baris_bangunan + 1, 17, 3 + baris_bangunan + 2, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_bangunan + 1, 17, 3 + baris_bangunan + 2, 20).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_bangunan + 1, 17, 3 + baris_bangunan + 2, 20).Merge = True
                    ws9.Cells(3 + baris_bangunan + 1, 17, 3 + baris_bangunan + 2, 20).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_bangunan + 3, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_bangunan + 3, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End If

                'KENDARAAN
                'For row As Integer = 0 To dgv_penyusutan_kendaraan.Rows.Count - 1
                '    For col As Integer = 0 To dgv_penyusutan_kendaraan.Columns.Count - 2
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22).Value = dgv_penyusutan_kendaraan.Rows(row).Cells(col).Value
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                '        Dim cell = ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22)
                '        Dim value = dgv_penyusutan_kendaraan.Rows(row).Cells(col).Value
                '        If TypeOf value Is Double Or TypeOf value Is Decimal Then
                '            If value < 0 Then
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                '            Else
                '                cell.Value = value
                '                cell.Style.Numberformat.Format = "#,##0"
                '            End If
                '        Else
                '            cell.Value = value
                '        End If
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, 22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '        ws9.Cells(row + 3 + baris_kendaraan + 1, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                '    Next
                'Next
                For row As Integer = 0 To dgv_penyusutan_kendaraan.Rows.Count - 1
                    For col As Integer = 0 To dgv_penyusutan_kendaraan.Columns.Count - 2
                        Dim cell = ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22)
                        Dim value As Object = dgv_penyusutan_kendaraan.Rows(row).Cells(col).Value

                        ' Pastikan nilai tidak Null
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If

                        ' Tambahkan Border untuk setiap sel
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)

                        ' Atur Alignment
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next

                For i As Integer = 0 To baris_kendaraan + dgv_penyusutan_kendaraan.Rows.Count - 6
                    ws9.Cells(3 + baris_kendaraan + 1 + i, 22, 3 + baris_kendaraan + 2 + i, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_kendaraan + 1 + i, 22, 3 + baris_kendaraan + 2 + i, 24).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_kendaraan + 1 + i, 22, 3 + baris_kendaraan + 2 + i, 24).Merge = True
                    ws9.Cells(3 + baris_kendaraan + 1 + i, 22, 3 + baris_kendaraan + 2 + i, 24).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_kendaraan + 1 + i, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    i += 6
                Next
                For i As Integer = 0 To baris_kendaraan + dgv_penyusutan_kendaraan.Rows.Count - 6
                    Dim range = ws9.Cells(3 + baris_kendaraan + 7 + i, 22, 3 + baris_kendaraan + 7 + i, 25)
                    range.Style.Border.Top.Style = ExcelBorderStyle.None
                    range.Style.Border.Left.Style = ExcelBorderStyle.None
                    range.Style.Border.Right.Style = ExcelBorderStyle.None
                    If i + 6 > baris_kendaraan + dgv_penyusutan_kendaraan.Rows.Count - 6 Then
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.None
                    Else
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin
                    i += 6
                Next
                baris_kendaraan += dgv_penyusutan_kendaraan.Rows.Count
                For row As Integer = 0 To dgv_gabungan_penyusutan_kendaraan.Rows.Count - 1
                    For col As Integer = 0 To dgv_gabungan_penyusutan_kendaraan.Columns.Count - 1
                        ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22).Value = dgv_gabungan_penyusutan_kendaraan.Rows(row).Cells(col).Value
                        ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Dim cell = ws9.Cells(row + 3 + baris_kendaraan + 1, col + 22)
                        Dim value = dgv_gabungan_penyusutan_kendaraan.Rows(row).Cells(col).Value
                        'If TypeOf value Is Double Or TypeOf value Is Decimal Then
                        '    If value < 0 Then
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0;(#,##0)" ' Format Excel untuk tanda kurung
                        '    Else
                        '        cell.Value = value
                        '        cell.Style.Numberformat.Format = "#,##0"
                        '    End If
                        'Else
                        '    cell.Value = value
                        'End If
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            Dim numericValue As Decimal
                            If col = 0 Then
                                cell.Value = value
                            Else
                                If Decimal.TryParse(value.ToString(), numericValue) Then
                                    ' Jika angka negatif, gunakan format Excel dengan tanda kurung
                                    If numericValue < 0 Then
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0;(#,##0)"
                                    Else
                                        cell.Value = numericValue
                                        cell.Style.Numberformat.Format = "#,##0"
                                    End If
                                Else
                                    ' Jika bukan angka, tetap masukkan sebagai teks
                                    cell.Value = value.ToString()
                                End If
                            End If
                        Else
                            cell.Value = "" ' Pastikan tidak ada null di Excel
                        End If
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        ws9.Cells(row + 3 + baris_kendaraan + 1, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    Next
                Next
                If dgv_gabungan_penyusutan_kendaraan.RowCount <> 0 Then
                    ws9.Cells(3 + baris_kendaraan + 1, 22, 3 + baris_kendaraan + 2, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_kendaraan + 1, 22, 3 + baris_kendaraan + 2, 25).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    ws9.Cells(3 + baris_kendaraan + 1, 22, 3 + baris_kendaraan + 2, 25).Merge = True
                    ws9.Cells(3 + baris_kendaraan + 1, 22, 3 + baris_kendaraan + 2, 25).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    ws9.Cells(3 + baris_kendaraan + 3, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    ws9.Cells(3 + baris_kendaraan + 3, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End If

                'Akhir Sheet 9

                ' Simpan file Excel
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Data ke Excel Berhasil!")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        Me.Close() ' Menutup form saat ini
        Dim newForm As New form_laporan_keuangan() ' Membuat instance baru dari form
        newForm.Show() ' Menampilkan ulang form
    End Sub

End Class