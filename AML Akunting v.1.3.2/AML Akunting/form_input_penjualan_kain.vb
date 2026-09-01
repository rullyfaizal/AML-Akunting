Imports MySql.Data.MySqlClient

Public Class form_input_penjualan_kain

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

    'Private Sub form_input_penjualan_kain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If panel_stok1.Enabled = False Then
    '        e.Cancel = True
    '        MessageBox.Show("Anda tidak diizinkan menutup form ini sekarang, silahkan lanjutkan atau batalkan")
    '    End If
    'End Sub

    Private Sub form_input_penjualan_kain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
        'Timer1.Interval = 750
        'Timer1.Enabled = True
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Label2.Visible = Not Label2.Visible
    'End Sub

    Private Sub txt_client_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_client.GotFocus
        If txt_client.Text = "" Then
            Call isitxtclient()
        Else
            Call cariclient()
        End If
        dgv_client.Visible = True
    End Sub
    Private Sub btn_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_client.Click
        btn_client.Focus()
        dgv_client.Visible = False
        txt_client.Text = ""
    End Sub
    Private Sub headertableclient()
        dgv_client.ColumnHeadersVisible = False
        dgv_client.RowHeadersVisible = False
        dgv_client.Columns(0).Width = 300
    End Sub
    Private Sub isitxtclient()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT nama From tbclient ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_client.DataSource = dsx.Tables("tbclient")
                            Call headertableclient()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub cariclient()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama From tbclient WHERE nama like '%" & txt_client.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_client.DataSource = dsx.Tables("tbclient")
                            Call headertableclient()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_client_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_client.TextChanged
        If txt_client.Text = "" Then
            Call isitxtclient()
        Else
            Call cariclient()
        End If
    End Sub
    Private Sub dgv_client_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_client.CellMouseClick
        Try
            Dim i As Integer
            i = Me.dgv_client.CurrentRow.Index
            With dgv_client.Rows.Item(i)
                txt_client.Text = dgv_client.Rows(i).Cells(0).Value
            End With
            btn_client.Focus()
            dgv_client.Visible = False
            'Using conx As New MySqlConnection(sLocalConn)
            '    conx.Open()
            '    Dim sqlx = "SELECT nama,jenis_biaya from tbclient WHERE nama ='" & txt_client.Text & "'"
            '    Using cmdx As New MySqlCommand(sqlx, conx)
            '        Using drx As MySqlDataReader = cmdx.ExecuteReader
            '            drx.Read()
            '            If drx.HasRows Then
            '                CboJenisBiaya.Text = drx(1)
            '            End If
            '        End Using
            '    End Using
            'End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_nama_grey1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nama_grey1.GotFocus
        form_ambil_stok_grey.Show()
        form_ambil_stok_grey.Focus()
        form_ambil_stok_grey.txt_baris.Text = "1"
        form_ambil_stok_grey.dtp_tanggal.Text = dtp_tanggal.Text
        btn_hitung.Focus()
        form_ambil_stok_grey.btn_isi_dgv.PerformClick()
        form_ambil_stok_grey.txt_id_grey1.Text = txt_id_grey1.Text
        form_ambil_stok_grey.txt_id_grey2.Text = txt_id_grey2.Text
        form_ambil_stok_grey.txt_id_grey3.Text = txt_id_grey3.Text
    End Sub
    Private Sub txt_nama_grey2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nama_grey2.GotFocus
        form_ambil_stok_grey.Show()
        form_ambil_stok_grey.Focus()
        If txt_nama_grey1.Text = "" Then
            form_ambil_stok_grey.txt_baris.Text = "1"
        Else
            form_ambil_stok_grey.txt_baris.Text = "2"
        End If
        form_ambil_stok_grey.dtp_tanggal.Text = dtp_tanggal.Text
        btn_hitung.Focus()
        form_ambil_stok_grey.btn_isi_dgv.PerformClick()
        form_ambil_stok_grey.txt_id_grey1.Text = txt_id_grey1.Text
        form_ambil_stok_grey.txt_id_grey2.Text = txt_id_grey2.Text
        form_ambil_stok_grey.txt_id_grey3.Text = txt_id_grey3.Text
    End Sub
    Private Sub txt_nama_grey3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nama_grey3.GotFocus
        form_ambil_stok_grey.Show()
        form_ambil_stok_grey.Focus()
        If txt_nama_grey1.Text = "" Then
            form_ambil_stok_grey.txt_baris.Text = "1"
        ElseIf txt_nama_grey2.Text = "" Then
            form_ambil_stok_grey.txt_baris.Text = "2"
        Else
            form_ambil_stok_grey.txt_baris.Text = "3"
        End If
        form_ambil_stok_grey.dtp_tanggal.Text = dtp_tanggal.Text
        btn_hitung.Focus()
        form_ambil_stok_grey.btn_isi_dgv.PerformClick()
        form_ambil_stok_grey.txt_id_grey1.Text = txt_id_grey1.Text
        form_ambil_stok_grey.txt_id_grey2.Text = txt_id_grey2.Text
        form_ambil_stok_grey.txt_id_grey3.Text = txt_id_grey3.Text
    End Sub

    Private Sub txt_supplier1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_supplier1.TextChanged
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT satuan FROM tbsupplier WHERE nama='" & txt_supplier1.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            cbo_satuan.Text = drx(0).ToString
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_qty1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qty1.LostFocus
        Dim input As String = txt_qty1.Text
        Dim number As Decimal
        If Not txt_qty1.Text = "" Then
            If Decimal.TryParse(input, number) Then
                'txt_qty1.Text = number.ToString("#,##0.00")
                txt_qty1.Text = number.ToString("#,##0.00########")
                Dim qty As String = txt_qty_asal1.Text
                Dim qtyb As String = txt_qty1.Text
                Dim qty_d, qtyb_d As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(qtyb, qtyb_d)
                If qtyb_d > qty_d Then
                    MsgBox("STOK yang diinput lebih besar dari STOK yang tersedia : " & txt_qty_asal1.Text)
                    txt_qty1.Focus()
                End If
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_qty1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_qty2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qty2.LostFocus
        Dim input As String = txt_qty2.Text
        Dim number As Decimal
        If Not txt_qty2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                'txt_qty2.Text = number.ToString("#,##0.00")
                txt_qty2.Text = number.ToString("#,##0.00########")
                Dim qty As String = txt_qty_asal2.Text
                Dim qtyb As String = txt_qty2.Text
                Dim qty_d, qtyb_d As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(qtyb, qtyb_d)
                If qtyb_d > qty_d Then
                    MsgBox("STOK yang diinput lebih besar dari STOK yang tersedia : " & txt_qty_asal2.Text)
                    txt_qty2.Focus()
                End If
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_qty2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_qty3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qty3.LostFocus
        Dim input As String = txt_qty3.Text
        Dim number As Decimal
        If Not txt_qty3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                'txt_qty3.Text = number.ToString("#,##0.00")
                txt_qty3.Text = number.ToString("#,##0.00##########")
                Dim qty As String = txt_qty_asal3.Text
                Dim qtyb As String = txt_qty3.Text
                Dim qty_d, qtyb_d As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(qtyb, qtyb_d)
                If qtyb_d > qty_d Then
                    MsgBox("STOK yang diinput lebih besar dari STOK yang tersedia : " & txt_qty_asal3.Text)
                    txt_qty3.Focus()
                End If
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_qty3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga_jual_ppn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_harga_jual_ppn.LostFocus
        Dim input As String = txt_harga_jual_ppn.Text
        Dim number As Decimal
        If Not txt_harga_jual_ppn.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga_jual_ppn.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga_jual_ppn.Focus()
            End If
        End If
    End Sub
    Private Sub txt_dpp_sjx_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dpp_sjx.LostFocus
        Dim input As String = txt_dpp_sjx.Text
        Dim number As Decimal
        If Not txt_dpp_sjx.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_dpp_sjx.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_dpp_sjx.Focus()
            End If
        End If
    End Sub
    Private Sub txt_sjx_grand_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_sjx_grand_total.LostFocus
        Dim input As String = txt_sjx_grand_total.Text
        Dim number As Decimal
        If Not txt_sjx_grand_total.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_sjx_grand_total.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_sjx_grand_total.Focus()
            End If
        End If
    End Sub

    Private Sub hitungstok()
        Dim qty1 As String = txt_qty1.Text
        Dim qty2 As String = txt_qty2.Text
        Dim qty3 As String = txt_qty3.Text
        Dim qty1_d, qty2_d, qty3_d, qty_d As Decimal
        Decimal.TryParse(qty1, qty1_d)
        Decimal.TryParse(qty2, qty2_d)
        Decimal.TryParse(qty3, qty3_d)
        qty_d = qty1_d + qty2_d + qty3_d
        'txt_qty.Text = qty_d.ToString("#,##0.##")
        'txt_qty.Text = qty_d.ToString("#,##0.##########")
        txt_qty.Text = Math.Floor(qty_d).ToString("#,##0")

        Dim hargajualppn As String = txt_harga_jual_ppn.Text
        Dim hargajualppn_d, hargajualdpp_d, totaldpp1, totalppn1, totalharga1, totaldpp2, totalppn2, totalharga2, totaldpp3, totalppn3, totalharga3, totaldpp, totalppn, totalharga As Decimal
        Decimal.TryParse(hargajualppn, hargajualppn_d)

        hargajualdpp_d = hargajualppn_d / (1 + (ppn / 100))
        txt_harga_jual_dpp.Text = hargajualdpp_d.ToString("#,##0.00########")

        totaldpp1 = (hargajualppn_d / (1 + (ppn / 100))) * qty1_d
        totalharga1 = hargajualppn_d * qty1_d
        totalppn1 = totalharga1 - totaldpp1
        txt_total_dpp1.Text = totaldpp1.ToString("#,##0.00########")
        txt_total_harga1.Text = totalharga1.ToString("#,##0.00########")
        txt_ppn1.Text = totalppn1.ToString("#,##0.00########")

        If txt_nama_grey2.Text <> "" Then
            totaldpp2 = (hargajualppn_d / (1 + (ppn / 100))) * qty2_d
            totalharga2 = hargajualppn_d * qty2_d
            totalppn2 = totalharga2 - totaldpp2
            txt_total_dpp2.Text = totaldpp2.ToString("#,##0.00########")
            txt_total_harga2.Text = totalharga2.ToString("#,##0.00########")
            txt_ppn2.Text = totalppn2.ToString("#,##0.00########")
        End If
        If txt_nama_grey3.Text <> "" Then
            totaldpp3 = (hargajualppn_d / (1 + (ppn / 100))) * qty3_d
            totalharga3 = hargajualppn_d * qty3_d
            totalppn3 = totalharga3 - totaldpp3
            txt_total_dpp3.Text = totaldpp3.ToString("#,##0.00########")
            txt_total_harga3.Text = totalharga3.ToString("#,##0.00########")
            txt_ppn3.Text = totalppn3.ToString("#,##0.00########")
        End If

        totaldpp = totaldpp1 + totaldpp2 + totaldpp3
        totalharga = totalharga1 + totalharga2 + totalharga3
        totalppn = totalppn1 + totalppn2 + totalppn3
        txt_total_dpp.Text = totaldpp.ToString("#,##0.00########")
        txt_total_harga.Text = totalharga.ToString("#,##0.00########")
        txt_ppn.Text = totalppn.ToString("#,##0.00########")
    End Sub
    Private Sub hitungomset()
        Dim omset, dppomset, totalkain, dppkain, polos, totalkainasal, totalhargaomset, sisaomset As Decimal
        Decimal.TryParse(txt_sjx_grand_total_asal.Text, omset)
        Decimal.TryParse(txt_dpp_sjx_asal.Text, dppomset)
        Decimal.TryParse(txt_grand_total_kain_asal.Text, totalkainasal)
        Decimal.TryParse(txt_polos.Text, polos)
        Decimal.TryParse(txt_total_harga.Text, totalhargaomset)
        totalkain = totalkainasal + totalhargaomset
        dppkain = totalkain / (1 + (ppn / 100))
        sisaomset = omset - totalkain - polos

        txt_grand_total_kain.Text = totalkain.ToString("#,##0.00")
        txt_total_dpp_jual.Text = dppkain.ToString("#,##0.00")
        txt_sisa_omset.Text = sisaomset.ToString("#,##0.00")
    End Sub

    Private Sub btn_hitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung.Click
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
        If btn_hitung.Text = "HITUNG PPN" Then
            If txt_client.Text = "" Then
                MsgBox("Nama Client belum diinput")
                txt_client.Focus()
            ElseIf txt_nama_grey1.Text = "" And txt_nama_grey2.Text = "" And txt_nama_grey3.Text = "" Then
                MsgBox("STOK GREY belum diinput")
                txt_nama_grey1.Focus()
            Else
                If txt_grand_total_kain_asal.Text = "" And txt_dpp_sjx_asal.Text = "" Then
                    Call hitungstok()
                Else
                    Call hitungstok()
                    Call hitungomset()

                    Dim inputNumber As Decimal
                    If Decimal.TryParse(txt_sisa_omset.Text, inputNumber) Then
                        If inputNumber < 0 Then
                            Dim sisaOmset As Decimal = Decimal.Parse(txt_sisa_omset_asal.Text)
                            Dim hargaJualPPN As Decimal = Decimal.Parse(txt_harga_jual_ppn.Text)
                            Dim Qty, Total1, Total2 As Decimal

                            If txt_qty3.Text <> "" Then
                                Decimal.TryParse(txt_total_harga1.Text, Total1)
                                Decimal.TryParse(txt_total_harga2.Text, Total2)
                                Qty = Math.Floor((sisaOmset - Total1 - Total2) / hargaJualPPN)
                                If Qty < 0 Then
                                    MsgBox("Terlalu banyak memasukkan stok silahkan HAPUS baris ke-3")
                                    Call kosong()
                                    Return
                                End If
                                txt_qty3.Text = Math.Floor(Qty).ToString("#,##0.00")
                            ElseIf txt_qty2.Text <> "" Then
                                Decimal.TryParse(txt_total_harga1.Text, Total1)
                                Qty = Math.Floor((sisaOmset - Total1) / hargaJualPPN)
                                If Qty < 0 Then
                                    MsgBox("Terlalu banyak memasukkan stok silahkan HAPUS baris ke-2")
                                    Call kosong()
                                    Return
                                End If
                                txt_qty2.Text = Math.Floor(Qty).ToString("#,##0.00")
                            Else
                                Qty = Math.Floor(sisaOmset / hargaJualPPN)
                                txt_qty1.Text = Math.Floor(Qty).ToString("#,##0.00")
                            End If
                        End If
                        Call hitungstok()
                        Call hitungomset()
                    End If

                End If
                btn_hitung.Text = "EDIT"
                txt_status.Text = "Kain"
                btn_simpan.Enabled = True
                btn_hitung_polos.Enabled = False
                panel_stok1.Enabled = False
                panel_stok2.Enabled = False
                panel_omset.Enabled = False
                btn_simpan.Enabled = True
            End If
        Else
            btn_hitung.Text = "HITUNG PPN"
            txt_status.Text = ""
            btn_hitung_polos.Enabled = True
            panel_stok1.Enabled = True
            panel_stok2.Enabled = True
            panel_omset.Enabled = True
            btn_simpan.Enabled = False
            txt_qty.Text = ""
            txt_total_dpp.Text = ""
            txt_ppn.Text = ""
            txt_total_harga.Text = ""
            txt_total_dpp1.Text = ""
            txt_total_dpp2.Text = ""
            txt_total_dpp3.Text = ""
            txt_ppn1.Text = ""
            txt_ppn2.Text = ""
            txt_ppn3.Text = ""
            txt_total_harga1.Text = ""
            txt_total_harga2.Text = ""
            txt_total_harga3.Text = ""

            Dim totalkain, dppkain, polos, sisa As Decimal
            Decimal.TryParse(txt_grand_total_kain_asal.Text, totalkain)
            Decimal.TryParse(txt_total_dpp_jual_asal.Text, dppkain)
            Decimal.TryParse(txt_polos_asal.Text, polos)
            Decimal.TryParse(txt_sisa_omset_asal.Text, sisa)

            If txt_grand_total_kain_asal.Text = "" And txt_dpp_sjx_asal.Text = "" Then
                txt_grand_total_kain.Text = ""
                txt_total_dpp_jual.Text = ""
                txt_polos.Text = ""
                txt_sisa_omset.Text = ""
            Else
                txt_grand_total_kain.Text = totalkain.ToString("#,##0.00")
                txt_total_dpp_jual.Text = dppkain.ToString("#,##0.00")
                txt_polos.Text = polos.ToString("#,##0.00")
                txt_sisa_omset.Text = sisa.ToString("#,##0.00")
            End If
        End If
    End Sub
    Private Sub kosong()
        btn_hitung.Text = "HITUNG PPN"
        txt_status.Text = ""
        btn_hitung_polos.Enabled = True
        panel_stok1.Enabled = True
        panel_stok2.Enabled = True
        panel_omset.Enabled = True
        btn_simpan.Enabled = False
        txt_qty.Text = ""
        txt_total_dpp.Text = ""
        txt_ppn.Text = ""
        txt_total_harga.Text = ""
        txt_total_dpp1.Text = ""
        txt_total_dpp2.Text = ""
        txt_total_dpp3.Text = ""
        txt_ppn1.Text = ""
        txt_ppn2.Text = ""
        txt_ppn3.Text = ""
        txt_total_harga1.Text = ""
        txt_total_harga2.Text = ""
        txt_total_harga3.Text = ""

        Dim totalkain, dppkain, polos, sisa As Decimal
        Decimal.TryParse(txt_grand_total_kain_asal.Text, totalkain)
        Decimal.TryParse(txt_total_dpp_jual_asal.Text, dppkain)
        Decimal.TryParse(txt_polos_asal.Text, polos)
        Decimal.TryParse(txt_sisa_omset_asal.Text, sisa)

        If txt_grand_total_kain_asal.Text = "" And txt_dpp_sjx_asal.Text = "" Then
            txt_grand_total_kain.Text = ""
            txt_total_dpp_jual.Text = ""
            txt_polos.Text = ""
            txt_sisa_omset.Text = ""
        Else
            txt_grand_total_kain.Text = totalkain.ToString("#,##0.00")
            txt_total_dpp_jual.Text = dppkain.ToString("#,##0.00")
            txt_polos.Text = polos.ToString("#,##0.00")
            txt_sisa_omset.Text = sisa.ToString("#,##0.00")
        End If
    End Sub
    Private Sub hitungstokpolos()
        Dim qty1 As String = txt_qty1.Text
        Dim qty2 As String = txt_qty2.Text
        Dim qty3 As String = txt_qty3.Text
        Dim qty1_d, qty2_d, qty3_d, qty_d As Decimal
        Decimal.TryParse(qty1, qty1_d)
        Decimal.TryParse(qty2, qty2_d)
        Decimal.TryParse(qty3, qty3_d)
        qty_d = qty1_d + qty2_d + qty3_d
        'txt_qty.Text = qty_d.ToString("#,##0.##")
        'txt_qty.Text = qty_d.ToString("#,##0.##########")
        txt_qty.Text = Math.Floor(qty_d).ToString("#,##0")

        Dim hargajualppn As String = txt_harga_jual_ppn.Text
        Dim hargajualppn_d, hargajualdpp_d, totaldpp1, totalppn1, totalharga1, totaldpp2, totalppn2, totalharga2, totaldpp3, totalppn3, totalharga3, totaldpp, totalppn, totalharga As Decimal
        Decimal.TryParse(hargajualppn, hargajualppn_d)

        hargajualdpp_d = hargajualppn_d / (1 + (ppn / 100))
        txt_harga_jual_dpp.Text = hargajualdpp_d.ToString("#,##0.00########")

        totaldpp1 = (hargajualppn_d / (1 + (ppn / 100))) * qty1_d
        totalharga1 = hargajualppn_d * qty1_d
        totalppn1 = totalharga1 - totaldpp1
        'txt_total_dpp1.Text = totaldpp1.ToString("#,##0.00########")
        txt_total_harga1.Text = totalharga1.ToString("#,##0.00########")
        'txt_ppn1.Text = totalppn1.ToString("#,##0.00########")

        If txt_nama_grey2.Text <> "" Then
            totaldpp2 = (hargajualppn_d / (1 + (ppn / 100))) * qty2_d
            totalharga2 = hargajualppn_d * qty2_d
            totalppn2 = totalharga2 - totaldpp2
            'txt_total_dpp2.Text = totaldpp2.ToString("#,##0.00########")
            txt_total_harga2.Text = totalharga2.ToString("#,##0.00########")
            'txt_ppn2.Text = totalppn2.ToString("#,##0.00########")
        End If
        If txt_nama_grey3.Text <> "" Then
            totaldpp3 = (hargajualppn_d / (1 + (ppn / 100))) * qty3_d
            totalharga3 = hargajualppn_d * qty3_d
            totalppn3 = totalharga3 - totaldpp3
            'txt_total_dpp3.Text = totaldpp3.ToString("#,##0.00########")
            txt_total_harga3.Text = totalharga3.ToString("#,##0.00########")
            'txt_ppn3.Text = totalppn3.ToString("#,##0.00########")
        End If

        totaldpp = totaldpp1 + totaldpp2 + totaldpp3
        totalharga = totalharga1 + totalharga2 + totalharga3
        totalppn = totalppn1 + totalppn2 + totalppn3
        'txt_total_dpp.Text = totaldpp.ToString("#,##0.00########")
        txt_total_harga.Text = totalharga.ToString("#,##0.00########")
        'txt_ppn.Text = totalppn.ToString("#,##0.00########")
    End Sub
    Private Sub hitungomsetpolos()
        Dim omset, totalkain, polos, totalharga, sisaomset, totalpolos As Decimal
        Decimal.TryParse(txt_sjx_grand_total_asal.Text, omset)
        Decimal.TryParse(txt_grand_total_kain.Text, totalkain)
        Decimal.TryParse(txt_polos_asal.Text, polos)
        Decimal.TryParse(txt_total_harga.Text, totalharga)

        totalpolos = polos + totalharga
        sisaomset = omset - totalkain - totalpolos

        txt_polos.Text = totalpolos.ToString("#,##0.00")
        txt_sisa_omset.Text = sisaomset.ToString("#,##0.00")
    End Sub
    Private Sub btn_hitung_polos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung_polos.Click
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
        If btn_hitung_polos.Text = "HITUNG POLOS" Then
            If txt_client.Text = "" Then
                MsgBox("Nama Client belum diinput")
                txt_client.Focus()
            ElseIf txt_nama_grey1.Text = "" And txt_nama_grey2.Text = "" And txt_nama_grey3.Text = "" Then
                MsgBox("STOK GREY belum diinput")
                txt_nama_grey1.Focus()
            Else
                If txt_grand_total_kain_asal.Text = "" And txt_dpp_sjx_asal.Text = "" Then
                    Call hitungstokpolos()
                Else
                    Call hitungstokpolos()
                    Call hitungomsetpolos()

                    Dim inputNumber As Decimal
                    If Decimal.TryParse(txt_sisa_omset.Text, inputNumber) Then
                        If inputNumber < 0 Then
                            Dim sisaOmset As Decimal = Decimal.Parse(txt_sisa_omset_asal.Text)
                            Dim hargaJualPPN As Decimal = Decimal.Parse(txt_harga_jual_ppn.Text)
                            Dim Qty, Total1, Total2 As Decimal

                            If txt_qty3.Text <> "" Then
                                Decimal.TryParse(txt_total_harga1.Text, Total1)
                                Decimal.TryParse(txt_total_harga2.Text, Total2)
                                Qty = Math.Floor((sisaOmset - Total1 - Total2) / hargaJualPPN)
                                If Qty < 0 Then
                                    MsgBox("Terlalu banyak memasukkan stok silahkan HAPUS baris ke-3")
                                    Call kosong()
                                    Return
                                End If
                                txt_qty3.Text = Math.Floor(Qty).ToString("#,##0.00")
                            ElseIf txt_qty2.Text <> "" Then
                                Decimal.TryParse(txt_total_harga1.Text, Total1)
                                Qty = Math.Floor((sisaOmset - Total1) / hargaJualPPN)
                                If Qty < 0 Then
                                    MsgBox("Terlalu banyak memasukkan stok silahkan HAPUS baris ke-2")
                                    Call kosong()
                                    Return
                                End If
                                txt_qty2.Text = Math.Floor(Qty).ToString("#,##0.00")
                            Else
                                Qty = Math.Floor(sisaOmset / hargaJualPPN)
                                txt_qty1.Text = Math.Floor(Qty).ToString("#,##0.00")
                            End If
                        End If
                        Call hitungstokpolos()
                        Call hitungomsetpolos()
                    End If

                End If
                btn_hitung_polos.Text = "EDIT"
                txt_status.Text = "Kain Polos"
                btn_simpan.Enabled = True
                btn_hitung.Enabled = False
                panel_stok1.Enabled = False
                panel_stok2.Enabled = False
                panel_omset.Enabled = False
                btn_simpan.Enabled = True
            End If
        Else
            btn_hitung_polos.Text = "HITUNG POLOS"
            txt_status.Text = ""
            btn_hitung.Enabled = True
            panel_stok1.Enabled = True
            panel_stok2.Enabled = True
            panel_omset.Enabled = True
            btn_simpan.Enabled = False
            txt_qty.Text = ""
            txt_total_dpp.Text = ""
            txt_ppn.Text = ""
            txt_total_harga.Text = ""
            txt_total_dpp1.Text = ""
            txt_total_dpp2.Text = ""
            txt_total_dpp3.Text = ""
            txt_ppn1.Text = ""
            txt_ppn2.Text = ""
            txt_ppn3.Text = ""
            txt_total_harga1.Text = ""
            txt_total_harga2.Text = ""
            txt_total_harga3.Text = ""

            Dim totalkain, dppkain, polos, sisa As Decimal
            Decimal.TryParse(txt_grand_total_kain_asal.Text, totalkain)
            Decimal.TryParse(txt_total_dpp_jual_asal.Text, dppkain)
            Decimal.TryParse(txt_polos_asal.Text, polos)
            Decimal.TryParse(txt_sisa_omset_asal.Text, sisa)

            If txt_grand_total_kain_asal.Text = "" And txt_dpp_sjx_asal.Text = "" Then
                txt_grand_total_kain.Text = ""
                txt_total_dpp_jual.Text = ""
                txt_polos.Text = ""
            Else
                txt_grand_total_kain.Text = totalkain.ToString("#,##0.00")
                txt_total_dpp_jual.Text = dppkain.ToString("#,##0.00")
                txt_polos.Text = polos.ToString("#,##0.00")
                txt_sisa_omset.Text = sisa.ToString("#,##0.00")
            End If
        End If
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        'Dim totalsjx, totalkain As Decimal
        'Decimal.TryParse(txt_sjx_grand_total.Text, totalsjx)
        'Decimal.TryParse(txt_grand_total_kain.Text, totalkain)
        Dim sisa_omset As Decimal
        Decimal.TryParse(txt_sisa_omset.Text, sisa_omset)
        Dim Total_harga As Decimal
        Decimal.TryParse(txt_total_harga.Text, Total_harga)

        If sisa_omset < 0 Then
            MsgBox("Total Penjualan Melebihi OMSET")
        ElseIf Total_harga <= 0 Then
            MsgBox("Total Penjualan tidak bisa Rp. 0,-")
        Else
            Call simpanpenjualan()
            Call updategrey1()
            Call simpanhistorygrey1()
            Call updateneracagrey1()
            If txt_nama_grey2.Text <> "" Then
                Call updategrey2()
                Call simpanhistorygrey2()
                Call updateneracagrey2()
            End If
            If txt_nama_grey3.Text <> "" Then
                Call updategrey3()
                Call simpanhistorygrey3()
                Call updateneracagrey3()
            End If
            If txt_grand_total_kain_asal.Text <> "" And txt_dpp_sjx_asal.Text <> "" Then
                Call updateomset()
            End If
            MsgBox("PENJUALAN KAIN Baru Berhasil Disimpan")
            form_penjualan.Show()
            form_penjualan.Focus()
            form_penjualan.ts_perbarui.PerformClick()
            Me.Close()
        End If
    End Sub

    Private Sub simpanpenjualan()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total," &
                 "pph23,transfer,total_polos,satuan,status,baris,kode,id_grey1,id_grey2,id_grey3,kode_omset) " &
                 "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_surat_jalan.Text)
                    .Parameters.AddWithValue("@3", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@4", txt_client.Text)
                    .Parameters.AddWithValue("@5", "Kain")
                    .Parameters.AddWithValue("@6", cbo_nama_jual.Text)
                    .Parameters.AddWithValue("@7", txt_qty.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_harga_jual_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_total_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_ppn.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", txt_total_harga.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@12", "")
                    .Parameters.AddWithValue("@13", "")
                    .Parameters.AddWithValue("@14", "")
                    .Parameters.AddWithValue("@15", cbo_satuan.Text)
                    .Parameters.AddWithValue("@16", txt_status.Text)
                    .Parameters.AddWithValue("@17", 0)
                    .Parameters.AddWithValue("@18", Txt_kode.Text)
                    .Parameters.AddWithValue("@19", txt_id_grey1.Text)
                    .Parameters.AddWithValue("@20", txt_id_grey2.Text)
                    .Parameters.AddWithValue("@21", txt_id_grey3.Text)
                    .Parameters.AddWithValue("@22", txt_kode_omset.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty1.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty2.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty3.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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

    Private Sub simpanhistorygrey1()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga," &
                "harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca,kode_jual) " &
                "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_beli1.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_id_beli1.Text)
                    .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@3", txt_no_faktur1.Text)
                    .Parameters.AddWithValue("@4", txt_supplier1.Text)
                    .Parameters.AddWithValue("@5", txt_nama_grey1.Text)
                    .Parameters.AddWithValue("@6", 0)
                    .Parameters.AddWithValue("@7", 0)
                    .Parameters.AddWithValue("@8", txt_qty1.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", 0)
                    .Parameters.AddWithValue("@10", txt_harga_grey1.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", txt_harga_jual_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@13", txt_total_dpp1.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                    .Parameters.AddWithValue("@15", txt_kode_beli1.Text)
                    .Parameters.AddWithValue("@16", txt_kode_grey1.Text)
                    .Parameters.AddWithValue("@17", txt_kode_neraca1.Text)
                    .Parameters.AddWithValue("@18", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_beli1.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpanhistorygrey2()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga," &
                "harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca,Kode_jual) " &
                "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_beli2.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_id_beli2.Text)
                    .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@3", txt_no_faktur2.Text)
                    .Parameters.AddWithValue("@4", txt_supplier2.Text)
                    .Parameters.AddWithValue("@5", txt_nama_grey2.Text)
                    .Parameters.AddWithValue("@6", 0)
                    .Parameters.AddWithValue("@7", 0)
                    .Parameters.AddWithValue("@8", txt_qty2.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", 0)
                    .Parameters.AddWithValue("@10", txt_harga_grey2.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", txt_harga_jual_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@13", txt_total_dpp2.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                    .Parameters.AddWithValue("@15", txt_kode_beli2.Text)
                    .Parameters.AddWithValue("@16", txt_kode_grey2.Text)
                    .Parameters.AddWithValue("@17", txt_kode_neraca2.Text)
                    .Parameters.AddWithValue("@18", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_beli2.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpanhistorygrey3()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga," &
                "harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca,kode_jual) " &
                "VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_beli3.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_id_beli3.Text)
                    .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@3", txt_no_faktur3.Text)
                    .Parameters.AddWithValue("@4", txt_supplier3.Text)
                    .Parameters.AddWithValue("@5", txt_nama_grey3.Text)
                    .Parameters.AddWithValue("@6", 0)
                    .Parameters.AddWithValue("@7", 0)
                    .Parameters.AddWithValue("@8", txt_qty3.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", 0)
                    .Parameters.AddWithValue("@10", txt_harga_grey3.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", txt_harga_jual_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@13", txt_total_dpp3.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                    .Parameters.AddWithValue("@15", txt_kode_beli3.Text)
                    .Parameters.AddWithValue("@16", txt_kode_grey3.Text)
                    .Parameters.AddWithValue("@17", txt_kode_neraca3.Text)
                    .Parameters.AddWithValue("@18", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_beli3.CustomFormat = "dd/MM/yyyy"
                End With
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty1.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty2.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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
        Dim keluar, dpp_jual As Decimal
        Decimal.TryParse(txt_qty3.Text, keluar)

        stok_keluar = stok_keluar + keluar
        stok_akhir = stok_akhir - keluar
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

    Private Sub btn_hapus_grey1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus_grey1.Click
        If txt_nama_grey3.Text <> "" Then
            MsgBox("Silahkan hapus terlebih dahulu baris ke-3 untuk menghapus baris ini")
        ElseIf txt_nama_grey2.Text <> "" Then
            MsgBox("Silahkan hapus terlebih dahulu baris ke-2 untuk menghapus baris ini")
        Else
            txt_nama_grey1.Text = ""
            dtp_tanggal_beli1.Text = Today
            txt_harga_grey1.Text = ""
            txt_supplier1.Text = ""
            txt_qty1.Text = ""
            txt_total_dpp1.Text = ""
            txt_ppn1.Text = ""
            txt_total_harga1.Text = ""
            txt_qty_asal1.Text = ""
            txt_id_grey1.Text = ""
            txt_kode_grey1.Text = ""
            cbo_nama_jual_asal.Text = ""
            cbo_nama_jual.Text = ""
            cbo_satuan.Text = ""
            txt_harga_jual_ppn.Text = ""
            txt_harga_jual_dpp.Text = ""
            txt_harga_grey_ppn1.Text = ""
        End If
    End Sub
    Private Sub btn_hapus_grey2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus_grey2.Click
        If txt_nama_grey3.Text <> "" Then
            MsgBox("Silahkan hapus terlebih dahulu baris ke-3 untuk menghapus baris ini")
        Else
            txt_nama_grey2.Text = ""
            dtp_tanggal_beli2.Text = Today
            txt_harga_grey2.Text = ""
            txt_supplier2.Text = ""
            txt_qty2.Text = ""
            txt_total_dpp2.Text = ""
            txt_ppn2.Text = ""
            txt_total_harga2.Text = ""
            txt_qty_asal2.Text = ""
            txt_id_grey2.Text = ""
            txt_kode_grey2.Text = ""
        End If
    End Sub
    Private Sub btn_hapus_grey3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus_grey3.Click
        txt_nama_grey3.Text = ""
        dtp_tanggal_beli3.Text = Today
        txt_harga_grey3.Text = ""
        txt_supplier3.Text = ""
        txt_qty3.Text = ""
        txt_total_dpp3.Text = ""
        txt_ppn3.Text = ""
        txt_total_harga3.Text = ""
        txt_qty_asal3.Text = ""
        txt_id_grey3.Text = ""
        txt_kode_grey3.Text = ""
    End Sub

    Private Sub btn_pilih_omset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pilih_omset.Click
        If btn_pilih_omset.Text = "PILIH OMSET" Then
            btn_pilih_omset.Text = "RESET OMSET"
            form_ambil_omset_penjualan.Show()
            form_ambil_omset_penjualan.Focus()
            txt_sjx_grand_total.ReadOnly = True
            txt_dpp_sjx.ReadOnly = True
            txt_client.Enabled = False
            btn_client.Enabled = False

        Else
            btn_pilih_omset.Text = "PILIH OMSET"
            txt_sjx_grand_total.ReadOnly = False
            txt_dpp_sjx.ReadOnly = False
            txt_sjx_grand_total.Text = ""
            txt_dpp_sjx.Text = ""
            txt_grand_total_kain.Text = ""
            txt_total_dpp_jual.Text = ""
            txt_polos.Text = ""
            txt_sjx_grand_total_asal.Text = ""
            txt_dpp_sjx_asal.Text = ""
            txt_grand_total_kain_asal.Text = ""
            txt_total_dpp_jual_asal.Text = ""
            txt_polos_asal.Text = ""
            txt_id_omset.Text = ""
            txt_kode_omset.Text = ""
            txt_client.Text = ""
            txt_sisa_omset.Text = ""
            txt_client.Enabled = True
            btn_client.Enabled = True
            dgv1.Columns.Clear()
        End If
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

    Private Sub txt_no_faktur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur.SelectionStart
        If txt_no_faktur.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur.SelectionStart = cursorPosition
        'End If
    End Sub

    Private Sub dtp_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal.ValueChanged
        ' Cek apakah bulan berbeda dengan dtpUtama
        If txt_sisa_omset.Text <> "" Then
            If dtp_tanggal.Value.Month <> dtp_omset.Value.Month OrElse dtp_tanggal.Value.Year <> dtp_omset.Value.Year Then
                MessageBox.Show("Bulan dan tahun tidak boleh berbeda dengan OMSET", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtp_tanggal.Value = dtp_omset.Value
            End If
        End If
    End Sub
End Class