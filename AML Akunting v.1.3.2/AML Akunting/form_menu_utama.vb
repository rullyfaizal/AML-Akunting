Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_menu_utama

    Private Sub Form_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form_koneksi_database.MdiParent = Me
        form_koneksi_database.Show()
        form_koneksi_database.Focus()
        MenuStrip1.Visible = False
        StatusStrip1.Visible = False
        Call otomastis_bs()
    End Sub
    Private Sub KELUARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KELUARToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub JenisBiayaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JenisBiayaToolStripMenuItem.Click
        form_jenis_biaya.Show()
        form_jenis_biaya.Focus()
    End Sub
    Private Sub NamaSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NamaSpecsToolStripMenuItem.Click
        form_nama_specs.Show()
        form_nama_specs.Focus()
    End Sub
    Private Sub SupplierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        form_supplier.Show()
        form_supplier.Focus()
    End Sub
    Private Sub PPNPPh23ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPNPPh23ToolStripMenuItem.Click
        'form_parameter_ppn.MdiParent = Me
        form_parameter_ppn.Show()
        form_parameter_ppn.Focus()
    End Sub
    Private Sub DataPembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPembelianToolStripMenuItem.Click
        form_pembelian.Show()
        form_pembelian.Focus()
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        form_input_pembelian_baru.Show()
        form_input_pembelian_baru.Focus()
    End Sub
    Private Sub UploadPembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPembelianToolStripMenuItem.Click
        form_upload_pembelian.Show()
        form_upload_pembelian.Focus()
    End Sub
    Private Sub ExportUploadPembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportUploadPembelianToolStripMenuItem.Click
        form_export_pembelian.Show()
        form_export_pembelian.Focus()
    End Sub
    Private Sub CariNamaBarangSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariNamaBarangSpecsToolStripMenuItem.Click
        form_cari_specs_pembelian.Show()
        form_cari_specs_pembelian.Focus()
    End Sub

    Private Sub CLIENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLIENTToolStripMenuItem.Click
        form_client.Show()
        form_client.Focus()
    End Sub

    Private Sub DataPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPenjualanToolStripMenuItem.Click
        form_penjualan.Show()
        form_penjualan.Focus()
    End Sub

    Private Sub InputPenjualanCelupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputPenjualanCelupToolStripMenuItem.Click
        form_input_penjualan_celup.Show()
        form_input_penjualan_celup.Focus()
    End Sub

    Private Sub InputNamaHargaJualGreyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputNamaHargaJualGreyToolStripMenuItem.Click
        form_input_harga_jual_grey.Show()
        form_input_harga_jual_grey.Focus()
    End Sub

    Private Sub PatchPembelianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchPembelianToolStripMenuItem.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT status2 FROM tbpembelian"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel Pembelian Sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz = "ALTER TABLE tbpembelian ADD COLUMN status2 VARCHAR(255) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("PATCH Tabel Pembelian BERHASIL")
        End Try
    End Sub

    Private Sub DataGreyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGreyToolStripMenuItem.Click
        form_data_grey.Show()
        form_data_grey.Focus()
    End Sub

    Private Sub PatchGreyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchGreyToolStripMenuItem.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "DROP TABLE tbindukgrey;"
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.ExecuteNonQuery()
                End Using
            End Using
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz = "UPDATE tbpembelian SET status2 = '' WHERE status2 = 'GREY';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("PATCH Tabel Grey BERHASIL")
        Catch ex As Exception
            MsgBox("Tabel Grey Sudah di PATCH")
        End Try
    End Sub

    Private Sub InputPenjualanKainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputPenjualanKainToolStripMenuItem.Click
        form_input_penjualan_kain.Show()
        form_input_penjualan_kain.Focus()
    End Sub

    Private Sub PatchPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchPenjualanToolStripMenuItem.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT gabung_faktur FROM tbpenjualan"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel Penjualan Sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz = "ALTER TABLE tbpenjualan ADD COLUMN gabung_faktur VARCHAR(255) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("PATCH Tabel Penjualan BERHASIL")
        End Try

        'Try
        '    Using cony As New MySqlConnection(sLocalConn)
        '        cony.Open()
        '        Dim sqly = "SELECT upload FROM tbpenjualan"
        '        Using cmdy As New MySqlCommand(sqly, cony)
        '            Using dry As MySqlDataReader = cmdy.ExecuteReader
        '                dry.Read()
        '                If dry.HasRows Then
        '                    MsgBox("Tabel Penjualan Sudah di PATCH")
        '                End If
        '            End Using
        '        End Using
        '    End Using
        'Catch ex As Exception
        '    Using conz As New MySqlConnection(sLocalConn)
        '        conz.Open()
        '        Dim sqlz = "ALTER TABLE tbpenjualan ADD COLUMN upload DATE NULL COLLATE latin1_swedish_ci;"
        '        Using cmdz As New MySqlCommand(sqlz, conz)
        '            cmdz.ExecuteNonQuery()
        '        End Using
        '    End Using
        '    MsgBox("PATCH Tabel Penjualan BERHASIL")
        'End Try
        'Try
        '    Using cony As New MySqlConnection(sLocalConn)
        '        cony.Open()
        '        Dim sqly = "SELECT id_grey1 FROM tbpenjualan"
        '        Using cmdy As New MySqlCommand(sqly, cony)
        '            Using dry As MySqlDataReader = cmdy.ExecuteReader
        '                dry.Read()
        '                If dry.HasRows Then
        '                    MsgBox("Tabel Penjualan Sudah di PATCH")
        '                End If
        '            End Using
        '        End Using
        '    End Using
        'Catch ex As Exception
        '    Using conz As New MySqlConnection(sLocalConn)
        '        conz.Open()
        '        Dim sqlz = "ALTER TABLE tbpenjualan ADD COLUMN id_grey1 int(11) NOT NULL DEFAULT 0, " &
        '            "ADD COLUMN id_grey2 int(11) NOT NULL DEFAULT 0, " &
        '            "ADD COLUMN id_grey3 int(11) NOT NULL DEFAULT 0, " &
        '            "ADD COLUMN kode_omset VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
        '        Using cmdz As New MySqlCommand(sqlz, conz)
        '            cmdz.ExecuteNonQuery()
        '        End Using
        '    End Using
        '    MsgBox("PATCH Tabel Penjualan BERHASIL")
        'End Try

        'Using conx As New MySqlConnection(sLocalConn)
        '    conx.Open()
        '    Dim sqlx = "SELECT id_jual FROM tbpenjualan WHERE id_jual = 21"
        '    Using cmdx As New MySqlCommand(sqlx, conx)
        '        Using drx As MySqlDataReader = cmdx.ExecuteReader
        '            drx.Read()
        '            If drx.HasRows Then
        '                Using cony As New MySqlConnection(sLocalConn)
        '                    cony.Open()
        '                    Dim sqly = "DELETE FROM tbhistorygrey WHERE id_grey = 14"
        '                    Using cmdy As New MySqlCommand(sqly, cony)
        '                        cmdy.ExecuteNonQuery()
        '                    End Using
        '                End Using
        '                Using cony As New MySqlConnection(sLocalConn)
        '                    cony.Open()
        '                    Dim sqly = "DELETE FROM tbpenjualan WHERE id_jual = 21"
        '                    Using cmdy As New MySqlCommand(sqly, cony)
        '                        cmdy.ExecuteNonQuery()
        '                    End Using
        '                End Using
        '                Using cony As New MySqlConnection(sLocalConn)
        '                    cony.Open()
        '                    Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1, stok_akhir=@2, dpp_jual=@3 WHERE id_neraca = 3"
        '                    Using cmdy As New MySqlCommand(sqly, cony)
        '                        With cmdy
        '                            .Parameters.Clear()
        '                            .Parameters.AddWithValue("@1", 0)
        '                            .Parameters.AddWithValue("@2", 42748.98)
        '                            .Parameters.AddWithValue("@3", 379349056.75675786)
        '                            .ExecuteNonQuery()
        '                        End With
        '                    End Using
        '                End Using
        '                Using cony As New MySqlConnection(sLocalConn)
        '                    cony.Open()
        '                    Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE id_grey = 8"
        '                    Using cmdy As New MySqlCommand(sqly, cony)
        '                        With cmdy
        '                            .Parameters.Clear()
        '                            .Parameters.AddWithValue("@1", 0)
        '                            .Parameters.AddWithValue("@2", 29790.98)
        '                            .Parameters.AddWithValue("@3", 264361399.09909987)
        '                            .ExecuteNonQuery()
        '                        End With
        '                    End Using
        '                End Using
        '                MsgBox("PATCH PENJUALAN BERHASIL")
        '            Else
        '                MsgBox("PENJUALAN Sudah di PATCH")
        '            End If
        '        End Using
        '    End Using
        'End Using
    End Sub

    Private Sub PatchSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchSupplierToolStripMenuItem.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT satuan FROM tbsupplier"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel Supplier Sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz = "ALTER TABLE tbsupplier ADD COLUMN satuan VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("PATCH Tabel Supplier BERHASIL")
        End Try
    End Sub

    Private Sub OmsetPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OmsetPenjualanToolStripMenuItem.Click
        form_omset_penjualan.Show()
        form_omset_penjualan.Focus()
    End Sub

    Private Sub GenerateSuratJalanDanFakturToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateSuratJalanDanFakturToolStripMenuItem.Click
        'form_generate_sj_penjualan.Show()
        'form_generate_sj_penjualan.Focus()
        form_generate_sj_penjualan_baru.Show()
        form_generate_sj_penjualan_baru.Focus()
    End Sub

    Private Sub NeracaGreyBaruToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeracaGreyBaruToolStripMenuItem.Click
        form_neraca_grey_baru.Show()
        form_neraca_grey_baru.Focus()
    End Sub

    Private Sub PatchOmsetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchOmsetToolStripMenuItem.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT sisa_omset FROM tbomset"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel Omset Sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz = "ALTER TABLE tbomset ADD COLUMN sisa_omset DECIMAL(65,10) DEFAULT 0;"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("PATCH Tabel Omset BERHASIL")
        End Try
    End Sub

    Private Sub ExportUploadPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportUploadPenjualanToolStripMenuItem.Click
        form_export_penjualan.Show()
        form_export_penjualan.Focus()
    End Sub

    Private Sub UploadPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPenjualanToolStripMenuItem.Click
        form_upload_penjualan_baru.Show()
        form_upload_penjualan_baru.Focus()
    End Sub

    Private Sub otomastis_bs()
        '---FITUR HAPUS BS OTOMATIS
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir <= 5 AND stok_akhir <> 0"
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
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                ' Loop melalui setiap baris di dgv1
                For Each row As DataGridViewRow In dgv1.Rows
                    If Not row.IsNewRow Then
                        ' Ambil data dari DataGridView
                        Dim id_grey As String = row.Cells(0).Value.ToString() ' Index 0: id_grey
                        Dim stok_keluar As Decimal = Convert.ToDecimal(row.Cells(8).Value) ' Index 8: stok_keluar
                        Dim stok_akhir As Decimal = Convert.ToDecimal(row.Cells(9).Value) ' Index 9: stok_akhir
                        Dim updated_stok_keluar As Decimal = stok_keluar + stok_akhir
                        ' Query untuk update data
                        Dim sqly As String = "UPDATE tbgrey SET stok_keluar=@1, stok_akhir=@2, dpp_jual=@4 WHERE id_grey=@3"
                        Using cmdy As New MySqlCommand(sqly, cony)
                            With cmdy
                                .Parameters.Clear()
                                .Parameters.AddWithValue("@1", updated_stok_keluar)
                                .Parameters.AddWithValue("@2", 0) ' Reset stok_akhir menjadi 0
                                .Parameters.AddWithValue("@3", id_grey)
                                .Parameters.AddWithValue("@4", 0)
                                .ExecuteNonQuery()
                            End With
                        End Using
                    End If
                Next
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                For Each row As DataGridViewRow In dgv1.Rows
                    If Not row.IsNewRow Then
                        Dim stok_keluar As Decimal = Convert.ToDecimal(row.Cells(9).Value)
                        Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga," &
                            "Harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca,kode_jual) " &
                            "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                        Using cmdy As New MySqlCommand(sqly, cony)
                            With cmdy
                                .Parameters.Clear()
                                .Parameters.AddWithValue("@1", row.Cells(1).Value)
                                .Parameters.AddWithValue("@2", row.Cells(2).Value)
                                .Parameters.AddWithValue("@3", row.Cells(3).Value)
                                .Parameters.AddWithValue("@4", row.Cells(4).Value)
                                .Parameters.AddWithValue("@5", row.Cells(5).Value)
                                .Parameters.AddWithValue("@6", 0)
                                .Parameters.AddWithValue("@7", 0)
                                .Parameters.AddWithValue("@8", stok_keluar)
                                .Parameters.AddWithValue("@9", 0)
                                .Parameters.AddWithValue("@10", row.Cells(10).Value)
                                .Parameters.AddWithValue("@11", row.Cells(11).Value)
                                .Parameters.AddWithValue("@12", row.Cells(12).Value)
                                .Parameters.AddWithValue("@13", row.Cells(13).Value)
                                .Parameters.AddWithValue("@14", row.Cells(14).Value)
                                .Parameters.AddWithValue("@15", row.Cells(15).Value)
                                .Parameters.AddWithValue("@16", row.Cells(16).Value)
                                .Parameters.AddWithValue("@17", row.Cells(17).Value)
                                .Parameters.AddWithValue("@18", "BS")
                                .ExecuteNonQuery()
                            End With
                        End Using
                    End If
                Next
            End Using
            dgv1.Columns.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
   
    Private Sub PatchToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchToolStripMenuItem1.Click
        'patch Revisi 10 Jan 2024 (Generate SJ)
        Try
            If MsgBox("Yakin SJ bulan September 2024 akan dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                Using conz As New MySqlConnection(sLocalConn)
                    conz.Open()
                    Dim sqlz = "UPDATE tbpenjualan SET surat_jalan = '', no_faktur = '' WHERE MONTH(tanggal) = 9 AND YEAR(tanggal) = 2024;"
                    Using cmdz As New MySqlCommand(sqlz, conz)
                        cmdz.ExecuteNonQuery()
                    End Using
                End Using
                Call hitung_belum_bukpot()
                MsgBox("SJ bulan September 2024 berhasil di hapus")
            End If
        Catch ex As Exception
            MsgBox("Tidak terdapat data di bulan September 2024")
        End Try
    End Sub

    Private Sub PatchBukpotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchBukpotToolStripMenuItem.Click
        'patch bukpot v.1.2.0
        'Try
        '    Using cony As New MySqlConnection(sLocalConn)
        '        cony.Open()
        '        Dim sqly = "SELECT pph23_actual FROM tbpenjualan"
        '        Using cmdy As New MySqlCommand(sqly, cony)
        '            Using dry As MySqlDataReader = cmdy.ExecuteReader
        '                dry.Read()
        '                If dry.HasRows Then
        '                    MsgBox("Tabel Penjualan untuk Bukpot Sudah di PATCH")
        '                End If
        '            End Using
        '        End Using
        '    End Using
        'Catch ex As Exception
        '    Using conz As New MySqlConnection(sLocalConn)
        '        conz.Open()
        '        Dim sqlz As String = "ALTER TABLE tbpenjualan " &
        '             "ADD COLUMN pph23_actual DECIMAL(65,10) NOT NULL DEFAULT 0, " &
        '             "ADD COLUMN no_bukpot VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '', " &
        '             "ADD COLUMN tgl_bukpot DATETIME DEFAULT NULL, " &
        '             "ADD COLUMN masa_bukpot DATETIME DEFAULT NULL, " &
        '             "ADD COLUMN gabung_bukpot VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
        '        Using cmdz As New MySqlCommand(sqlz, conz)
        '            cmdz.ExecuteNonQuery()
        '        End Using
        '    End Using
        '    Call hitung_belum_bukpot()
        '    MsgBox("PATCH Tabel Penjualan untuk Bukpot BERHASIL")
        'End Try

        'patch bukpot v.1.2.0a
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly As String = "ALTER TABLE tbpenjualan MODIFY COLUMN tgl_bukpot DATE, MODIFY COLUMN masa_bukpot DATE"
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.ExecuteNonQuery()
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT npwp FROM tbpenjualan"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel Penjualan untuk Bukpot Sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz As String = "ALTER TABLE tbpenjualan " &
                    "ADD COLUMN npwp VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            Call hitung_belum_bukpot()
            MsgBox("PATCH Tabel Penjualan untuk Bukpot BERHASIL")
        End Try
    End Sub

    '---fitur Bukti Potong
    Private Sub hitung_belum_bukpot()
        Try
            dgv_bukpot.Columns.Clear()
            Dim currentYear As Integer = dtp_bukpot.Value.Year - 1 ' Ambil tahun dari DateTimePicker, lalu kurangi 1 tahun

            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                ' Tambahkan kondisi untuk mengambil data dari tahun sebelumnya
                'Dim sqlx As String = "SELECT id_jual, tanggal, supplier, no_faktur, pph23 " &
                '                     "FROM tbpenjualan " &
                '                     "WHERE no_bukpot = '' " &
                '                     "AND jenis_biaya = 'Jasa' " &
                '                     "AND no_faktur <> '' " &
                '                     "AND YEAR(tanggal) = @prevYear ORDER BY tanggal ASC"
                Dim sqlx As String = "SELECT id_jual, tanggal, supplier, no_faktur, pph23 " &
                                    "FROM tbpenjualan " &
                                    "WHERE no_bukpot = '' " &
                                    "AND jenis_biaya = 'Jasa' " &
                                    "AND no_faktur <> '' " &
                                    "ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    ' Tambahkan parameter untuk tahun sebelumnya
                    cmdx.Parameters.AddWithValue("@prevYear", currentYear)

                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv_bukpot.DataSource = dsx.Tables("tbpenjualan")
                        End Using
                    End Using
                End Using
            End Using


            'Using conx As New MySqlConnection(sLocalConn)
            '    conx.Open()
            '    Dim sqlx As String = "SELECT id_jual, tanggal, supplier, no_faktur, pph23 FROM tbpenjualan WHERE no_bukpot = '' AND jenis_biaya = 'Jasa' AND no_faktur <> ''"
            '    Using cmdx As New MySqlCommand(sqlx, conx)
            '        Using dax As New MySqlDataAdapter
            '            dax.SelectCommand = cmdx
            '            Using dsx As New DataSet
            '                dax.Fill(dsx, "tbpenjualan")
            '                dgv_bukpot.DataSource = dsx.Tables("tbpenjualan")
            '            End Using
            '        End Using
            '    End Using
            'End Using

            dgv_bukpot.Columns(1).HeaderText = "TANGGAL"
            dgv_bukpot.Columns(2).HeaderText = "CLIENT"
            dgv_bukpot.Columns(3).HeaderText = "NO FAKTUR"
            dgv_bukpot.Columns(4).HeaderText = "PPH 23"
            For Each column As DataGridViewColumn In dgv_bukpot.Columns
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgv_bukpot.RowHeadersWidth = 60
            dgv_bukpot.Columns(0).Visible = False
            dgv_bukpot.Columns(1).Width = 100
            dgv_bukpot.Columns(2).Width = 220
            dgv_bukpot.Columns(3).Width = 170
            dgv_bukpot.Columns(4).Width = 120
            dgv_bukpot.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv_bukpot.Columns(4).DefaultCellStyle.Format = "#,##0.00"

            txt_jumlah_bukpot.Text = dgv_bukpot.RowCount
            btn_hitung_bukpot.Visible = False
        Catch ex As Exception
            btn_hitung_bukpot.Visible = False
            MessageBox.Show("Silahkan Patch terlebih dahulu 'Patch Bukpot v.1.2.0'")
        End Try
    End Sub

    Private Sub btn_hitung_bukpot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung_bukpot.Click
        panel_bukpot.Visible = True
        Call hitung_belum_bukpot()
    End Sub

    Private Sub dgv_bukpot_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_bukpot.CellFormatting
        dgv_bukpot.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub

    Private Sub btn_refresh_bukpot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh_bukpot.Click
        Call hitung_belum_bukpot()
    End Sub

    Private Sub BuktiPotongToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuktiPotongToolStripMenuItem.Click
        form_input_bukpot.Show()
        form_input_bukpot.Focus()
    End Sub

    Private Sub PatchPPNPPHV121ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchPPNPPHV121ToolStripMenuItem.Click
        'patch ppn/pph v.1.2.1
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "SELECT pph22 FROM tbppn"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            MsgBox("Tabel PPN/PPH sudah di PATCH")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Using conz As New MySqlConnection(sLocalConn)
                conz.Open()
                Dim sqlz As String = "ALTER TABLE tbppn " &
                    "ADD COLUMN pph22 VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL DEFAULT '';"
                Using cmdz As New MySqlCommand(sqlz, conz)
                    cmdz.ExecuteNonQuery()
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly As String = "ALTER TABLE tbppn " &
                                     "MODIFY COLUMN ppn DECIMAL(10,2), " &
                                     "MODIFY COLUMN pph23 DECIMAL(10,2), " &
                                     "MODIFY COLUMN pph22 DECIMAL(10,2)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.ExecuteNonQuery()
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbppn SET pph22=@1 WHERE id='ppn'"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", 1.5)
                        .ExecuteNonQuery()
                    End With
                   
                End Using
            End Using
            MsgBox("PATCH Tabel PPN/PPH BERHASIL")
        End Try
    End Sub

    Private Sub PatchPenyusutanV121ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchPenyusutanV121ToolStripMenuItem.Click
        'patch penyusutan v 1.2.5
        Try
            Using con As New MySqlConnection(sLocalConn)
                con.Open()
                ' Cek apakah kolom kategori_aset sudah ada di tbdatapenyusutan
                Dim sqlCheck As String = "SELECT kategori_aset FROM tbdatapenyusutan LIMIT 1"
                Using cmdCheck As New MySqlCommand(sqlCheck, con)
                    Try
                        Using dr As MySqlDataReader = cmdCheck.ExecuteReader()
                            dr.Read()
                            If dr.HasRows Then
                                MsgBox("Data Penyusutan sudah di PATCH")
                            End If
                        End Using
                    Catch ex As Exception
                        ' Jika error berarti kolom belum ada, maka kita tambahkan
                        Dim sqlAlter As String = "ALTER TABLE tbdatapenyusutan " &
                                                 "ADD COLUMN kategori_aset VARCHAR(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;"
                        Using cmdAlter As New MySqlCommand(sqlAlter, con)
                            cmdAlter.ExecuteNonQuery()
                        End Using
                        ' Update kolom kategori_aset dari tbindukpenyusutan
                        Dim sqlUpdate As String = "UPDATE tbdatapenyusutan dp " &
                                                  "JOIN tbindukpenyusutan ip ON dp.kode = ip.kode " &
                                                  "SET dp.kategori_aset = ip.kategori_aset;"
                        Using cmdUpdate As New MySqlCommand(sqlUpdate, con)
                            cmdUpdate.ExecuteNonQuery()
                            'Dim rowsAffected As Integer = cmdUpdate.ExecuteNonQuery()
                            'MsgBox("PATCH: " & rowsAffected.ToString() & " baris berhasil diperbarui di tbdatapenyusutan.")
                        End Using
                        MsgBox("Data Penyusutan Berhasil di PATCH")
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message)
        End Try

        'patch penyusutan v 1.2.3
        'Try
        '    Using conz As New MySqlConnection(sLocalConn)
        '        conz.Open()
        '        Dim sqlz As String = "CREATE TABLE tbindukpenyusutan (" &
        '                                       "kode VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL PRIMARY KEY," &
        '                                       "kategori_aset VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL," &
        '                                       "nama_aset VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL," &
        '                                       "tahun INT," &
        '                                       "nilai_buku DECIMAL(65, 10))"
        '        Using cmdz As New MySqlCommand(sqlz, conz)
        '            cmdz.ExecuteNonQuery()
        '        End Using
        '    End Using
        '    Using conz As New MySqlConnection(sLocalConn)
        '        conz.Open()
        '        Dim sqlz As String = "CREATE TABLE tbdatapenyusutan (" &
        '                                       "id INT NOT NULL PRIMARY KEY AUTO_INCREMENT," &
        '                                       "tahun INT," &
        '                                       "persentase VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL," &
        '                                       "nilai_penyusutan DECIMAL(65, 10)," &
        '                                       "nilai_buku DECIMAL(65, 10)," &
        '                                       "kode VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL)"
        '        Using cmdz As New MySqlCommand(sqlz, conz)
        '            cmdz.ExecuteNonQuery()
        '        End Using
        '    End Using
        '    MessageBox.Show("Patch Tabel Penyusutan Berhasil")
        'Catch ex As Exception
        '    MessageBox.Show("Table Penyusutan Sudah di Patch")
        'End Try
    End Sub

    Private Sub LaporanKeuanganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanKeuanganToolStripMenuItem.Click
        form_laporan_keuangan.Show()
        form_laporan_keuangan.Focus()
    End Sub

    Private Sub PatchSPTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchSPTToolStripMenuItem.Click
        'patch SPT v.1.2.1
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlCreateTable As String = "CREATE TABLE tbsptppn (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "bulan ENUM('JANUARY', 'FEBRUARY', 'MARCH', 'APRIL', 'MAY', 'JUNE', 'JULY', 'AUGUST', 'SEPTEMBER', 'OCTOBER', 'NOVEMBER', 'DECEMBER') NOT NULL, " & _
                    "tahun YEAR NOT NULL, " &
                    "nilai_masukan DECIMAL(65,10) DEFAULT 0, " &
                    "nilai_keluaran DECIMAL(65,10) DEFAULT 0, " &
                    "ppn_masukan DECIMAL(65,10) DEFAULT 0, " &
                    "ppn_keluaran DECIMAL(65,10) DEFAULT 0, " &
                    "ppn_disetor DECIMAL(65,10) DEFAULT 0, " &
                    "UNIQUE(bulan, tahun)" &
                ");"
                Using cmd As New MySqlCommand(sqlCreateTable, conx)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Patch Tabel SPT Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Tabel SPT sudah di Patch")
        End Try
    End Sub

    Private Sub SPTMasaPPNEfakturToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPTMasaPPNEfakturToolStripMenuItem.Click
        form_spt_efaktur.Show()
        form_spt_efaktur.Focus()
    End Sub

    Private Sub PatchBukpotV121aToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchBukpotV121aToolStripMenuItem.Click
        'patch Bukpot v.1.2.2a
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly As String = "UPDATE tbpenjualan p " &
                                     "JOIN tbclient c ON p.supplier = c.nama " &
                                     "SET p.npwp = c.npwp"
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.ExecuteNonQuery()
                    MessageBox.Show("Patch Tabel Bukpot Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Tabel SPT sudah di Patch")
        End Try
    End Sub

    Private Sub PenyusutanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenyusutanToolStripMenuItem.Click
        form_biaya_penyusutan.Show()
        form_biaya_penyusutan.Focus()
    End Sub

    Private Sub EksporExcelCoretaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EksporExcelCoretaxToolStripMenuItem.Click
        form_export_excel_coretax.Show()
        form_export_excel_coretax.Focus()
    End Sub

    Private Sub PatchBiayaTahunanV125ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchBiayaTahunanV125ToolStripMenuItem.Click
        Try
            'patch Biaya v.1.2.5
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlCreateTable As String = "CREATE TABLE tbbiayatahunan (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "tahun YEAR NOT NULL, " &
                    "upah_harian DECIMAL(65,10) DEFAULT 0, " &
                    "gaji_pegawai DECIMAL(65,10) DEFAULT 0, " &
                    "sewa_pabrik DECIMAL(65,10) DEFAULT 0, " &
                    "sewa_kantor DECIMAL(65,10) DEFAULT 0, " &
                    "pbb DECIMAL(65,10) DEFAULT 0, " &
                    "UNIQUE(tahun)" &
                ");"
                Using cmd As New MySqlCommand(sqlCreateTable, conx)
                    cmd.ExecuteNonQuery()
                    For tahun As Integer = 2010 To 2040
                        Dim sqlInsert As String = "INSERT IGNORE INTO tbbiayatahunan (tahun, upah_harian, gaji_pegawai, sewa_pabrik, sewa_kantor, pbb) " &
                                                  "VALUES (@tahun, 0.00, 0.00, 0.00, 0.00, 0.00);"

                        Using cmdInsert As New MySqlCommand(sqlInsert, conx)
                            cmdInsert.Parameters.AddWithValue("@tahun", tahun)
                            cmdInsert.ExecuteNonQuery()
                        End Using
                    Next
                    MessageBox.Show("Patch Biaya Tahunan Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Biaya Tahunan Sudah di Patch")
        End Try
    End Sub

    Private Sub BiayaTahunanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiayaTahunanToolStripMenuItem.Click
        Form_biaya_tahunan.Show()
        Form_biaya_tahunan.Focus()
    End Sub

    Private Sub PatchHPPV126ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchHPPV126ToolStripMenuItem.Click
        Try
            'patch hpp v.1.2.6
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlCreateTable As String = "CREATE TABLE tblaphpp (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "tahun YEAR NOT NULL, " &
                    "awal_tahun_obat DECIMAL(65,10) DEFAULT 0, " &
                    "akhir_tahun_obat DECIMAL(65,10) DEFAULT 0, " &
                    "awal_kain_proses DECIMAL(65,10) DEFAULT 0, " &
                    "akhir_kain_proses DECIMAL(65,10) DEFAULT 0, " &
                    "awal_kain_warna DECIMAL(65,10) DEFAULT 0, " &
                    "akhir_kain_warna DECIMAL(65,10) DEFAULT 0, " &
                    "UNIQUE(tahun)" &
                ");"
                Using cmd As New MySqlCommand(sqlCreateTable, conx)
                    cmd.ExecuteNonQuery()
                    For tahun As Integer = 2010 To 2040
                        Dim sqlInsert As String = "INSERT IGNORE INTO tblaphpp (tahun, awal_tahun_obat, akhir_tahun_obat, awal_kain_proses, akhir_kain_proses, awal_kain_warna, akhir_kain_warna) " &
                                                  "VALUES (@tahun, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);"

                        Using cmdInsert As New MySqlCommand(sqlInsert, conx)
                            cmdInsert.Parameters.AddWithValue("@tahun", tahun)
                            cmdInsert.ExecuteNonQuery()
                        End Using
                    Next
                    MessageBox.Show("Patch Laporan HPP Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Laporan HPP Sudah di Patch")
        End Try
    End Sub

    Private Sub SaldoLaporanHPPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldoLaporanHPPToolStripMenuItem.Click
        form_saldo_laporan_hpp.Show()
        form_saldo_laporan_hpp.Focus()
    End Sub

    Private Sub PatchAngsuranPPh25V126ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchAngsuranPPh25V126ToolStripMenuItem.Click
        Try
            'patch angsuran pph 25 v.1.2.6
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlCreateTable As String = "CREATE TABLE tbangsuranpph25 (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "tahun YEAR NOT NULL, " &
                    "januari DECIMAL(65,10) DEFAULT 0, " &
                    "februari DECIMAL(65,10) DEFAULT 0, " &
                    "maret DECIMAL(65,10) DEFAULT 0, " &
                    "april DECIMAL(65,10) DEFAULT 0, " &
                    "mei DECIMAL(65,10) DEFAULT 0, " &
                    "juni DECIMAL(65,10) DEFAULT 0, " &
                    "juli DECIMAL(65,10) DEFAULT 0, " &
                    "agustus DECIMAL(65,10) DEFAULT 0, " &
                    "september DECIMAL(65,10) DEFAULT 0, " &
                    "oktober DECIMAL(65,10) DEFAULT 0, " &
                    "november DECIMAL(65,10) DEFAULT 0, " &
                    "desember DECIMAL(65,10) DEFAULT 0, " &
                    "total DECIMAL(65,10) DEFAULT 0, " &
                    "UNIQUE(tahun)" &
                ");"
                Using cmd As New MySqlCommand(sqlCreateTable, conx)
                    cmd.ExecuteNonQuery()
                    For tahun As Integer = 2010 To 2040
                        Dim sqlInsert As String = "INSERT IGNORE INTO tbangsuranpph25 (tahun, januari, februari, maret, april, mei, juni, juli, agustus, september, oktober, november, desember, total) " &
                                                  "VALUES (@tahun, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);"

                        Using cmdInsert As New MySqlCommand(sqlInsert, conx)
                            cmdInsert.Parameters.AddWithValue("@tahun", tahun)
                            cmdInsert.ExecuteNonQuery()
                        End Using
                    Next
                    MessageBox.Show("Patch Angsuran PPh 25 Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Angsuran PPh 25 Sudah di Patch")
        End Try
    End Sub

    Private Sub AngsuranPPh25ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngsuranPPh25ToolStripMenuItem.Click
        form_angsuran_pph25.Show()
        form_angsuran_pph25.Focus()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOGOUTToolStripMenuItem.Click
        '' Tutup semua form kecuali form_menu_utama dan form_login
        'For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToList()
        '    If Not (TypeOf frm Is form_menu_utama Or TypeOf frm Is form_login) Then
        '        frm.Close()
        '    End If
        'Next
        '' Tampilkan kembali form_login
        'form_login.Show()
        '' Fokus ke form_login
        'form_login.BringToFront()

        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Restart() ' Restart aplikasi dari awal
        End If
    End Sub

    Private Sub ts_print_sj_bulanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print_sj_bulanan.Click
        form_sj_bulanan.Show()
        form_sj_bulanan.Focus()
    End Sub

    Private Sub PrintEksporInvoiceBulananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintEksporInvoiceBulananToolStripMenuItem.Click
        form_invoice_bulanan.Show()
        form_invoice_bulanan.Focus()
    End Sub

    '==============================================================================
    '=                              Modul LABA RUGI                               =
    '==============================================================================

    Dim pendapatan As Decimal = 0
    Dim hargapokokpenjualan As Decimal = 0
    Dim ppn, pph23, pph22 As Double
    Dim FormatID As New CultureInfo("id-ID")

    Private Sub btn_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        'Try
        dtp_tahun.Value = Today
        Dim selectedDate As DateTime = dtp_tahun.Value
        lbl_laba_rugi.Text = "LABA RUGI : 1 Januari " & dtp_tahun.Value.ToString("yyyy") & " - " & selectedDate.ToString("dd MMMM yyyy", FormatID)

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

        Call LoadMonitoringUpahGaji()
        Call cekangsuranpph25()
        Call CekBiayaSewa()
        Call CekLaphppTahunan()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub isi_ppn()
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

        lbl_nilai_laba_rugi.Text = "Rp. " & labarugisebelum.ToString("#,##0.00")

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
        Dim upah_harian As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT SUM(upah_harian) AS upah_harian FROM tbbiayatahunan WHERE tahun = @tahun;"
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
        dgv_biaya.Rows.Add("UPAH HARIAN", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", upah_harian)
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

        Dim rowIndex As Integer = dgv_biaya.Rows.Add("BIAYA LISTRIK PABRIK", "", "", "", "", "", "", "", "", "", "", "", "", _
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

        Dim gaji_pegawai As Decimal = 0
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim query As String = "SELECT SUM(gaji_pegawai) AS gaji_pegawai FROM tbbiayatahunan WHERE tahun = @tahun;"
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
        dgv_biaya.Rows.Add("BIAYA GAJI PEGAWAI", "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", "", _
                          "", "", "", "", "", "", "", "", "", "", "", gaji_pegawai)

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
        dgv_bukpot_lapkeu.Columns.Clear()
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
                        dgv_bukpot_lapkeu.DataSource = dsx.Tables("tbpenjualan")
                    End Using
                End Using
            End Using
        End Using

        dgv_bukpot_lapkeu.Columns(1).HeaderText = "CUSTOMER"
        dgv_bukpot_lapkeu.Columns(2).HeaderText = "NPWP"
        dgv_bukpot_lapkeu.Columns(3).HeaderText = "TANGGAL"
        dgv_bukpot_lapkeu.Columns(4).HeaderText = "NO FAKTUR"
        dgv_bukpot_lapkeu.Columns(5).HeaderText = "DPP"
        dgv_bukpot_lapkeu.Columns(6).HeaderText = "PPN"
        dgv_bukpot_lapkeu.Columns(7).HeaderText = "PPH 23"
        dgv_bukpot_lapkeu.Columns(8).HeaderText = "PPH23 ACTUAL"
        dgv_bukpot_lapkeu.Columns(9).HeaderText = "NO BUKPOT"
        dgv_bukpot_lapkeu.Columns(10).HeaderText = "TGL BUKPOT"
        dgv_bukpot_lapkeu.Columns(11).HeaderText = "MASA BUKPOT"
        For Each column As DataGridViewColumn In dgv_bukpot_lapkeu.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_bukpot_lapkeu.RowHeadersWidth = 60
        dgv_bukpot_lapkeu.Columns(0).Visible = False
        dgv_bukpot_lapkeu.Columns(12).Visible = False
        dgv_bukpot_lapkeu.Columns(1).Width = 220
        dgv_bukpot_lapkeu.Columns(2).Width = 160
        dgv_bukpot_lapkeu.Columns(3).Width = 85
        dgv_bukpot_lapkeu.Columns(4).Width = 160
        dgv_bukpot_lapkeu.Columns(5).Width = 120
        dgv_bukpot_lapkeu.Columns(6).Width = 120
        dgv_bukpot_lapkeu.Columns(7).Width = 120
        dgv_bukpot_lapkeu.Columns(8).Width = 140
        dgv_bukpot_lapkeu.Columns(9).Width = 120
        dgv_bukpot_lapkeu.Columns(10).Width = 120
        dgv_bukpot_lapkeu.Columns(11).Width = 120
        dgv_bukpot_lapkeu.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_bukpot_lapkeu.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot_lapkeu.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot_lapkeu.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot_lapkeu.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv_bukpot_lapkeu.Columns(10).DefaultCellStyle.Format = "dd-MMM-yy"
        dgv_bukpot_lapkeu.Columns(11).DefaultCellStyle.Format = "MMMM-yy"

        For Each col As DataGridViewColumn In dgv_bukpot_lapkeu.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub dgv_bukpot_lapkeu_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_bukpot_lapkeu.CellFormatting
        dgv_bukpot_lapkeu.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
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

    Private Sub btn_refresh_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh_generate.Click
        btn_generate.PerformClick()
    End Sub
    '==============================================================================
    '=                          AKHIR Modul LABA RUGI                             =
    '==============================================================================

    Private Sub PatchUpahDanGajiV129ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchUpahDanGajiV129ToolStripMenuItem.Click
        'patch Upah dan Gaji v.1.2.9
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlCreateTable As String = "CREATE TABLE tbupahgaji (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "bulan ENUM('JANUARY', 'FEBRUARY', 'MARCH', 'APRIL', 'MAY', 'JUNE', 'JULY', 'AUGUST', 'SEPTEMBER', 'OCTOBER', 'NOVEMBER', 'DECEMBER') NOT NULL, " & _
                    "tahun YEAR NOT NULL, " &
                    "upah DECIMAL(65,10) DEFAULT 0, " &
                    "gaji DECIMAL(65,10) DEFAULT 0, " &
                    "UNIQUE(bulan, tahun)" &
                    ");"
                Using cmd As New MySqlCommand(sqlCreateTable, conx)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Patch Tabel Upah dan Gaji Berhasil")
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Tabel Upah dan Gaji sudah di Patch")
        End Try
    End Sub
    Private Sub UPAHDanGAJIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPAHDanGAJIToolStripMenuItem.Click
        form_upah_dan_gaji.Show()
        form_upah_dan_gaji.Focus()
    End Sub

    '==============================================================================
    '=                   Modul Monitoring Pengisian Laporan                       =
    '==============================================================================

    Private Sub LoadMonitoringUpahGaji()
        Dim bulanTerisi As New List(Of String)
        Dim bulanTerisiSpt As New List(Of String)
        Dim tahunIni As Integer = Today.Year

        Using con As New MySqlConnection(sLocalConn)
            con.Open()
            Dim sql As String = "SELECT bulan FROM tbupahgaji WHERE tahun = @tahun"
            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@tahun", tahunIni)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        bulanTerisi.Add(dr("bulan").ToString().ToLower())
                    End While
                End Using
            End Using
        End Using
        Using con As New MySqlConnection(sLocalConn)
            con.Open()
            Dim sql As String = "SELECT bulan FROM tbsptppn WHERE tahun = @tahun"
            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@tahun", tahunIni)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        bulanTerisiSpt.Add(dr("bulan").ToString().ToLower())
                    End While
                End Using
            End Using
        End Using

        Dim namaBulan() As String = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
        Dim bulanspt() As String = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}

        For i As Integer = 1 To 12
            Dim cb As CheckBox = CariCheckBox("ck_uh" & i)
            Dim cbspt As CheckBox = CariCheckBox("ck_sp" & i)
            If cb IsNot Nothing Then
                If bulanTerisi.Contains(namaBulan(i - 1).ToLower()) Then
                    cb.Checked = True
                Else
                    cb.Checked = False
                End If
            End If
            If cbspt IsNot Nothing Then
                If bulanTerisiSpt.Contains(bulanspt(i - 1).ToLower()) Then
                    cbspt.Checked = True
                Else
                    cbspt.Checked = False
                End If
            End If
        Next

        Call NonaktifkanAutoCheck()

    End Sub
    Private Sub NonaktifkanAutoCheck()
        For i As Integer = 1 To 12
            Dim cb As CheckBox = CariCheckBox("ck_uh" & i)
            Dim cbsp As CheckBox = CariCheckBox("ck_sp" & i)
            If cb IsNot Nothing Then
                cb.AutoCheck = False
            End If
            If cbsp IsNot Nothing Then
                cbsp.AutoCheck = False
            End If
        Next
    End Sub
    Private Function CariCheckBox(ByVal nama As String) As CheckBox
        For Each ctrl As Control In Me.Controls
            Dim cb As CheckBox = CariCheckBoxDalamKontrol(ctrl, nama)
            If cb IsNot Nothing Then Return cb
        Next
        Return Nothing
    End Function
    Private Function CariCheckBoxDalamKontrol(ByVal ctrl As Control, ByVal nama As String) As CheckBox
        If ctrl.Name = nama AndAlso TypeOf ctrl Is CheckBox Then
            Return CType(ctrl, CheckBox)
        End If
        For Each child As Control In ctrl.Controls
            Dim result As CheckBox = CariCheckBoxDalamKontrol(child, nama)
            If result IsNot Nothing Then Return result
        Next
        Return Nothing
    End Function

    Private Sub cekangsuranpph25()
        Dim bulanIndo() As String = {
            "januari", "februari", "maret", "april", "mei", "juni",
            "juli", "agustus", "september", "oktober", "november", "desember"
        }

        Using con As New MySqlConnection(sLocalConn)
            con.Open()
            Dim tahunSekarang As Integer = Today.Year
            Dim sql = "SELECT * FROM tbangsuranpph25 WHERE tahun = @tahun"
            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@tahun", tahunSekarang)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        For i As Integer = 0 To 11
                            Dim namaBulan As String = bulanIndo(i)
                            Dim nilai As Decimal = If(IsDBNull(dr(namaBulan)), 0D, Convert.ToDecimal(dr(namaBulan)))

                            ' Ambil CheckBox berdasarkan nama: ck_ap1 - ck_ap12
                            Dim cb As CheckBox = CariCheckBox("ck_ap" & (i + 1))
                            If cb IsNot Nothing Then
                                cb.Checked = (nilai > 0) ' Ceklis jika nilai > 0
                                cb.AutoCheck = False     ' Tidak bisa dicentang manual
                            End If
                        Next
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub CekBiayaSewa()
        Using con As New MySqlConnection(sLocalConn)
            con.Open()

            Dim tahunSekarang As Integer = Today.Year
            Dim sql As String = "SELECT sewa_kantor, sewa_pabrik, pbb FROM tbbiayatahunan WHERE tahun = @tahun"

            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@tahun", tahunSekarang)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        ' Baca dan set checkbox untuk sewa_kantor
                        If Not IsDBNull(dr("sewa_kantor")) Then
                            ck_sewa_kantor.Checked = Convert.ToDecimal(dr("sewa_kantor")) > 0
                        Else
                            ck_sewa_kantor.Checked = False
                        End If

                        ' Baca dan set checkbox untuk sewa_pabrik
                        If Not IsDBNull(dr("sewa_pabrik")) Then
                            ck_sewa_pabrik.Checked = Convert.ToDecimal(dr("sewa_pabrik")) > 0
                        Else
                            ck_sewa_pabrik.Checked = False
                        End If

                        ' Baca dan set checkbox untuk pbb
                        If Not IsDBNull(dr("pbb")) Then
                            ck_pbb.Checked = Convert.ToDecimal(dr("pbb")) > 0
                        Else
                            ck_pbb.Checked = False
                        End If
                    Else
                        ' Kalau tidak ada data untuk tahun sekarang, semua tidak dicentang
                        ck_sewa_kantor.Checked = False
                        ck_sewa_pabrik.Checked = False
                        ck_pbb.Checked = False
                    End If
                End Using
            End Using
        End Using

        ' Opsional: matikan AutoCheck supaya tidak bisa klik manual
        ck_sewa_kantor.AutoCheck = False
        ck_sewa_pabrik.AutoCheck = False
        ck_pbb.AutoCheck = False
    End Sub
    Private Sub CekLaphppTahunan()
        Using con As New MySqlConnection(sLocalConn)
            con.Open()

            Dim tahunSekarang As Integer = Today.Year
            Dim sql As String = "SELECT awal_tahun_obat, akhir_tahun_obat, awal_kain_proses, akhir_kain_proses, " &
            "awal_kain_warna, akhir_kain_warna FROM tblaphpp WHERE tahun = @tahun"

            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@tahun", tahunSekarang)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        ck_awal_tahun_obat.Checked = ToDecimalIfNotNull(dr("awal_tahun_obat")) > 0
                        ck_akhir_tahun_obat.Checked = ToDecimalIfNotNull(dr("akhir_tahun_obat")) > 0
                        ck_awal_kain_proses.Checked = ToDecimalIfNotNull(dr("awal_kain_proses")) > 0
                        ck_akhir_kain_proses.Checked = ToDecimalIfNotNull(dr("akhir_kain_proses")) > 0
                        ck_awal_kain_warna.Checked = ToDecimalIfNotNull(dr("awal_kain_warna")) > 0
                        ck_akhir_kain_warna.Checked = ToDecimalIfNotNull(dr("akhir_kain_warna")) > 0
                    Else
                        ' Kalau tidak ada data, semua checkbox tidak dicentang
                        ck_awal_tahun_obat.Checked = False
                        ck_akhir_tahun_obat.Checked = False
                        ck_awal_kain_proses.Checked = False
                        ck_akhir_kain_proses.Checked = False
                        ck_awal_kain_warna.Checked = False
                        ck_akhir_kain_warna.Checked = False
                    End If
                End Using
            End Using
        End Using

        ' Cegah dicentang manual (opsional)
        ck_awal_tahun_obat.AutoCheck = False
        ck_akhir_tahun_obat.AutoCheck = False
        ck_awal_kain_proses.AutoCheck = False
        ck_akhir_kain_proses.AutoCheck = False
        ck_awal_kain_warna.AutoCheck = False
        ck_akhir_kain_warna.AutoCheck = False
    End Sub
    Private Function ToDecimalIfNotNull(ByVal value As Object) As Decimal
        If value Is DBNull.Value Then
            Return 0
        Else
            Return Convert.ToDecimal(value)
        End If
    End Function

End Class
