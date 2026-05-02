Imports MySql.Data.MySqlClient

Public Class form_hapus_penjualan_kain

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

    Private Sub form_hapus_penjualan_kain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim kode As String = Txt_kode.Text
        LoadIdGreyByKode(kode)
        btn_omset.PerformClick()
    End Sub
    Public Sub LoadIdGreyByKode(ByVal kode As String)
        Try
            Dim query As String = "SELECT id_grey1, id_grey2, id_grey3, kode_omset FROM tbpenjualan WHERE kode = @kode;"
            Using conn As New MySqlConnection(sLocalConn)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@kode", kode)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        ' Periksa apakah data ditemukan
                        If reader.Read() Then
                            ' Isi TextBox dengan nilai id_grey dari query
                            txt_id_grey1.Text = reader("id_grey1").ToString()
                            txt_id_grey2.Text = reader("id_grey2").ToString()
                            txt_id_grey3.Text = reader("id_grey3").ToString()
                            txt_kode_omset.Text = reader("kode_omset").ToString()
                        End If
                    End Using
                End Using
            End Using
            If txt_id_grey1.Text <> 0 Then
                Dim query2 As String = "SELECT kode_grey FROM tbgrey WHERE id_grey = @id1;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query2, conn)
                        cmd.Parameters.AddWithValue("@id1", txt_id_grey1.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_kode_grey1.Text = reader("kode_grey").ToString()
                            End If
                        End Using
                    End Using
                End Using
                Dim query2a As String = "SELECT * FROM tbhistorygrey WHERE kode_grey = @kodegrey1 AND kode_jual = @kode;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query2a, conn)
                        cmd.Parameters.AddWithValue("@kode", kode)
                        cmd.Parameters.AddWithValue("@kodegrey1", txt_kode_grey1.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_nama_grey1.Text = reader("nama_specs").ToString()
                                txt_tanggal_beli1.Text = reader("tanggal").ToString()
                                txt_supplier1.Text = reader("supplier").ToString()
                                Dim harga1, qty1, dpp1, ppn1, total1, hargappn As Decimal
                                Decimal.TryParse(reader("harga"), harga1)
                                Decimal.TryParse(reader("stok_keluar"), qty1)
                                Decimal.TryParse(reader("dpp_jual"), dpp1)
                                Decimal.TryParse(reader("harga_jual_ppn"), hargappn)
                                txt_harga_grey1.Text = harga1.ToString("#,##0.00")
                                txt_qty1.Text = qty1.ToString("#,##0.00")
                                txt_total_dpp1.Text = dpp1.ToString("#,##0.00")
                                ppn1 = dpp1 * (ppn / 100)
                                total1 = qty1 * hargappn
                                txt_ppn1.Text = ppn1.ToString("#,##0.00")
                                txt_total_harga1.Text = total1.ToString("#,##0.00")
                                txt_id_beli1.Text = reader("id_beli").ToString()
                                txt_kode_neraca1.Text = reader("kode_neraca").ToString()
                            End If
                        End Using
                    End Using
                End Using
            End If
            If txt_id_grey2.Text <> 0 Then
                Dim query3 As String = "SELECT kode_grey FROM tbgrey WHERE id_grey = @id2;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query3, conn)
                        cmd.Parameters.AddWithValue("@id2", txt_id_grey2.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_kode_grey2.Text = reader("kode_grey").ToString()
                            End If
                        End Using
                    End Using
                End Using
                Dim query3a As String = "SELECT * FROM tbhistorygrey WHERE kode_grey = @kodegrey2 AND kode_jual = @kode;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query3a, conn)
                        cmd.Parameters.AddWithValue("@kode", kode)
                        cmd.Parameters.AddWithValue("@kodegrey2", txt_kode_grey2.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_nama_grey2.Text = reader("nama_specs").ToString()
                                txt_tanggal_beli2.Text = reader("tanggal").ToString()
                                txt_supplier2.Text = reader("supplier").ToString()
                                Dim harga2, qty2, dpp2, ppn2, total2, hargappn2 As Decimal
                                Decimal.TryParse(reader("harga"), harga2)
                                Decimal.TryParse(reader("stok_keluar"), qty2)
                                Decimal.TryParse(reader("dpp_jual"), dpp2)
                                Decimal.TryParse(reader("harga_jual_ppn"), hargappn2)
                                txt_harga_grey2.Text = harga2.ToString("#,##0.00")
                                txt_qty2.Text = qty2.ToString("#,##0.00")
                                txt_total_dpp2.Text = dpp2.ToString("#,##0.00")
                                ppn2 = dpp2 * (ppn / 100)
                                total2 = qty2 * hargappn2
                                txt_ppn2.Text = ppn2.ToString("#,##0.00")
                                txt_total_harga2.Text = total2.ToString("#,##0.00")
                                txt_id_beli2.Text = reader("id_beli").ToString()
                                txt_kode_neraca2.Text = reader("kode_neraca").ToString()
                            End If
                        End Using
                    End Using
                End Using
            End If
            If txt_id_grey3.Text <> 0 Then
                Dim query4 As String = "SELECT kode_grey FROM tbgrey WHERE id_grey = @id3;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query4, conn)
                        cmd.Parameters.AddWithValue("@id3", txt_id_grey3.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_kode_grey3.Text = reader("kode_grey").ToString()
                            End If
                        End Using
                    End Using
                End Using
                Dim query4a As String = "SELECT * FROM tbhistorygrey WHERE kode_grey = @kodegrey3 AND kode_jual = @kode;"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query4a, conn)
                        cmd.Parameters.AddWithValue("@kode", kode)
                        cmd.Parameters.AddWithValue("@kodegrey3", txt_kode_grey3.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_nama_grey3.Text = reader("nama_specs").ToString()
                                txt_tanggal_beli3.Text = reader("tanggal").ToString()
                                txt_supplier3.Text = reader("supplier").ToString()
                                Dim harga3, qty3, dpp3, ppn3, total3, hargappn3 As Decimal
                                Decimal.TryParse(reader("harga"), harga3)
                                Decimal.TryParse(reader("stok_keluar"), qty3)
                                Decimal.TryParse(reader("dpp_jual"), dpp3)
                                Decimal.TryParse(reader("harga_jual_ppn"), hargappn3)
                                txt_harga_grey3.Text = harga3.ToString("#,##0.00")
                                txt_qty3.Text = qty3.ToString("#,##0.00")
                                txt_total_dpp3.Text = dpp3.ToString("#,##0.00")
                                ppn3 = dpp3 * (ppn / 100)
                                total3 = qty3 * hargappn3
                                txt_ppn3.Text = ppn3.ToString("#,##0.00")
                                txt_total_harga3.Text = total3.ToString("#,##0.00")
                                txt_id_beli3.Text = reader("id_beli").ToString()
                                txt_kode_neraca3.Text = reader("kode_neraca").ToString()
                            End If
                        End Using
                    End Using
                End Using
            End If
            Dim query5 As String = "SELECT * FROM tbpenjualan WHERE kode = @kode;"
            Using conn As New MySqlConnection(sLocalConn)
                Using cmd As New MySqlCommand(query5, conn)
                    cmd.Parameters.AddWithValue("@kode", kode)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            dtp_tanggal.Text = reader("tanggal").ToString()
                            txt_surat_jalan.Text = reader("surat_jalan").ToString()
                            txt_no_faktur.Text = reader("no_faktur").ToString()
                            txt_client.Text = reader("supplier").ToString()
                            cbo_nama_jual.Text = reader("nama_kain").ToString()
                            txt_status.Text = reader("status").ToString()
                            Dim qty, harga, dpp, ppntotal, total, hargappn As Decimal
                            Decimal.TryParse(reader("jumlah"), qty)
                            Decimal.TryParse(reader("harga"), harga)
                            Decimal.TryParse(reader("dpp"), dpp)
                            Decimal.TryParse(reader("ppn"), ppntotal)
                            Decimal.TryParse(reader("total"), total)
                            txt_qty.Text = qty.ToString("#,##0.00")
                            txt_harga_jual_dpp.Text = harga.ToString("#,##0.00")
                            txt_total_dpp.Text = dpp.ToString("#,##0.00")
                            txt_ppn.Text = ppntotal.ToString("#,##0.00")
                            txt_total_harga.Text = total.ToString("#,##0.00")
                            cbo_satuan.Text = reader("satuan").ToString()
                            hargappn = harga * (1 + (ppn / 100))
                            txt_harga_jual_ppn.Text = hargappn.ToString("#,##0.00")
                        End If
                    End Using
                End Using
            End Using

            If txt_kode_omset.Text <> "" Then
                Dim query6 As String = "SELECT * FROM tbomset WHERE kode_omset = @kode"
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query6, conn)
                        cmd.Parameters.AddWithValue("@kode", txt_kode_omset.Text)
                        conn.Open()
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_id_omset.Text = reader("id_omset").ToString()

                                txt_sjx_grand_total_asal.Text = reader("omset").ToString()
                                txt_dpp_sjx_asal.Text = reader("dpp").ToString()
                                txt_grand_total_kain_asal.Text = reader("grand_total_kain").ToString()
                                txt_total_dpp_jual_asal.Text = reader("dpp_jual").ToString()
                                txt_polos_asal.Text = reader("polos").ToString()
                                txt_sisa_omset_asal.Text = reader("sisa_omset").ToString()

                                Dim omset As String = reader("omset").ToString()
                                Dim dpp As String = reader("dpp").ToString()
                                Dim dppjual As String = reader("dpp_jual").ToString()
                                Dim grand_total_kain As String = reader("grand_total_kain").ToString()
                                Dim polos As String = reader("polos").ToString()
                                Dim sisa As String = reader("sisa_omset").ToString()
                                Dim omset_d, dpp_d, dppjual_d, grand_total_kain_d, polos_d, sisa_d As Decimal
                                Decimal.TryParse(omset, omset_d)
                                Decimal.TryParse(dpp, dpp_d)
                                Decimal.TryParse(dppjual, dppjual_d)
                                Decimal.TryParse(grand_total_kain, grand_total_kain_d)
                                Decimal.TryParse(polos, polos_d)
                                Decimal.TryParse(sisa, sisa_d)

                                txt_sjx_grand_total.Text = omset_d.ToString("#,##0.00")
                                txt_dpp_sjx.Text = dpp_d.ToString("#,##0.00")
                                txt_grand_total_kain.Text = grand_total_kain_d.ToString("#,##0.00")
                                txt_total_dpp_jual.Text = dppjual_d.ToString("#,##0.00")
                                txt_polos.Text = polos_d.ToString("#,##0.00")
                                txt_sisa_omset.Text = sisa_d.ToString("#,##0.00")
                            End If
                        End Using
                    End Using
                End Using

                'Dim omset1, dppomset, totalkain, dppkain, polos1, totalkainasal, totalhargaomset As Decimal
                'Decimal.TryParse(txt_sjx_grand_total_asal.Text, omset1)
                'Decimal.TryParse(txt_dpp_sjx_asal.Text, dppomset)
                'Decimal.TryParse(txt_grand_total_kain_asal.Text, totalkainasal)

                'Decimal.TryParse(txt_total_harga.Text, totalhargaomset)
                'totalkain = totalkainasal - totalhargaomset
                'dppkain = totalkain / (1 + (ppn / 100))
                'polos1 = omset1 - totalkain

                'txt_grand_total_kain_asal.Text = totalkain.ToString("#,##0.00")
                'txt_total_dpp_jual_asal.Text = dppkain.ToString("#,##0.00")
                'txt_polos_asal.Text = polos1.ToString("#,##0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub isidgvpenjualan()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga," &
                    "dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan WHERE kode_omset = '" & txt_kode_omset.Text & "'"
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_omset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_omset.Click
        Call isidgvpenjualan()
    End Sub
    Private Sub atur_dgv_induk()
        dgv1.Columns(1).HeaderText = "NAMA CLIENT"
        dgv1.Columns(2).HeaderText = "TANGGAL"
        dgv1.Columns(3).HeaderText = "SURAT JALAN"
        dgv1.Columns(4).HeaderText = "FAKTUR PAJAK"
        dgv1.Columns(6).HeaderText = "NAMA KAIN"
        dgv1.Columns(7).HeaderText = "QTY"
        dgv1.Columns(8).HeaderText = "HARGA SATUAN (Rp)"
        dgv1.Columns(9).HeaderText = "DPP (Rp)"
        dgv1.Columns(10).HeaderText = "PPN (Rp)"
        dgv1.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(5).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(13).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.Columns(18).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'dgv1.Columns(1).Width = 85
        'dgv1.Columns(2).Width = 70
        'dgv1.Columns(3).Width = 130
        'dgv1.Columns(4).Width = 130
        'dgv1.Columns(5).Width = 130
        'dgv1.Columns(6).Width = 130
        'dgv1.Columns(7).Width = 130
        'dgv1.Columns(8).Width = 130
        'dgv1.Columns(9).Width = 130
        'dgv1.Columns(10).Width = 85
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
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        Me.Close()
    End Sub

    Private Sub hapuspenjualan()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "DELETE FROM tbpenjualan WHERE kode='" & Txt_kode.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                cmdy.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub hapushistorygrey1()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "DELETE FROM tbhistorygrey WHERE kode_jual='" & Txt_kode.Text & "' AND kode_grey ='" & txt_kode_grey1.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                cmdy.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub hapushistorygrey2()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "DELETE FROM tbhistorygrey WHERE kode_jual='" & Txt_kode.Text & "' AND kode_grey ='" & txt_kode_grey2.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                cmdy.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub hapushistorygrey3()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "DELETE FROM tbhistorygrey WHERE kode_jual='" & Txt_kode.Text & "' AND kode_grey ='" & txt_kode_grey3.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                cmdy.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub updateneracagrey1()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbneracagrey WHERE kode_neraca = '" & txt_kode_neraca1.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty1.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE kode_neraca = '" & txt_kode_neraca1.Text & "'"
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
    Private Sub updateneracagrey2()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbneracagrey WHERE kode_neraca = '" & txt_kode_neraca2.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty2.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE kode_neraca = '" & txt_kode_neraca2.Text & "'"
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
    Private Sub updateneracagrey3()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbneracagrey WHERE kode_neraca = '" & txt_kode_neraca3.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty3.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE kode_neraca = '" & txt_kode_neraca3.Text & "'"
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

    Private Sub updategrey1()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbgrey WHERE id_grey = '" & txt_id_grey1.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty1.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE id_grey = '" & txt_id_grey1.Text & "'"
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
    Private Sub updategrey2()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbgrey WHERE id_grey = '" & txt_id_grey2.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty2.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE id_grey = '" & txt_id_grey2.Text & "'"
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
    Private Sub updategrey3()
        Dim stok_keluar, stok_akhir, harga_jual As Decimal
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbgrey WHERE id_grey = '" & txt_id_grey3.Text & "'"
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
        Dim qty, dpp_jual As Decimal
        Decimal.TryParse(txt_qty3.Text, qty)

        stok_keluar = stok_keluar - qty
        stok_akhir = stok_akhir + qty
        dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE id_grey = '" & txt_id_grey3.Text & "'"
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

    Private Sub updateomset()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbomset SET dpp_jual=@1,grand_total_kain=@2,polos=@3,sisa_omset=@4 WHERE kode_omset = '" & txt_kode_omset.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_total_dpp_jual.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@2", txt_grand_total_kain.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@3", txt_polos.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@4", txt_sisa_omset.Text.Replace(".", "").Replace(",", "."))
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If MsgBox("Yakin DATA PENJUALAN Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
            Dim sjx, totaljual, dpp, totalomset, polos, sisa As Decimal
            Decimal.TryParse(txt_sjx_grand_total_asal.Text, sjx)
            Decimal.TryParse(txt_total_harga.Text, totaljual)
            Decimal.TryParse(txt_grand_total_kain_asal.Text, totalomset)
            Decimal.TryParse(txt_polos_asal.Text, polos)
            Decimal.TryParse(txt_total_dpp_jual_asal.Text, dpp)

            If txt_status.Text = "Kain" Then
                totalomset = totalomset - totaljual
                dpp = totalomset / (1 + (ppn / 100))
                sisa = sjx - polos - totalomset
                txt_total_dpp_jual.Text = dpp.ToString("#,##0.00########")
                txt_grand_total_kain.Text = totalomset.ToString("#,##0.00########")
                txt_polos.Text = polos.ToString("#,##0.00########")
                txt_sisa_omset.Text = sisa.ToString("#,##0.00########")
            Else
                polos = polos - totaljual
                sisa = sjx - polos - totalomset
                txt_total_dpp_jual.Text = dpp.ToString("#,##0.00########")
                txt_grand_total_kain.Text = totalomset.ToString("#,##0.00########")
                txt_polos.Text = polos.ToString("#,##0.00########")
                txt_sisa_omset.Text = sisa.ToString("#,##0.00########")
            End If

            Call updateomset()
            Call hapuspenjualan()

            If txt_id_grey1.Text <> 0 Then
                Call hapushistorygrey1()
                Call updateneracagrey1()
                Call updategrey1()
            End If

            If txt_id_grey2.Text <> 0 Then
                Call hapushistorygrey2()
                Call updateneracagrey2()
                Call updategrey2()
            End If

            If txt_id_grey3.Text <> 0 Then
                Call hapushistorygrey3()
                Call updateneracagrey3()
                Call updategrey3()
            End If
            MsgBox("Data Penjualan berhasil Dihapus")
            form_penjualan.btn_cari.PerformClick()
            Me.Close()

        End If
    End Sub

End Class