Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_omset_penjualan
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

    Private Sub form_omset_penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        Call isidgv()
        btn_update.Enabled = False
        btn_hapus.Enabled = False
        Dim dtptoday As New DateTimePicker
        txt_kode_omset.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        txt_kode_omset.Text = txt_kode_omset.Text.Replace("-", "").Replace(":", "")
    End Sub

    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(8).Visible = False
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(1).HeaderText = "BULAN"
        dgv1.Columns(2).HeaderText = "CLIENT"
        dgv1.Columns(3).HeaderText = "GRAND TOTAL OMSET"
        dgv1.Columns(4).HeaderText = "DPP OMSET"
        dgv1.Columns(5).HeaderText = "DPP KAIN"
        dgv1.Columns(6).HeaderText = "GRAND TOTAL KAIN"
        dgv1.Columns(7).HeaderText = "POLOS"
        dgv1.Columns(9).HeaderText = "SISA OMSET"
        dgv1.Columns(1).Width = 130
        'dgv1.Columns(2).Width = 130
        'dgv1.Columns(3).Width = 110
        'dgv1.Columns(4).Width = 110
        'dgv1.Columns(5).Width = 140
        'dgv1.Columns(6).Width = 100
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(1).DefaultCellStyle.Format = "MMMM yyyy"
        dgv1.Columns(1).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    End Sub
    Private Sub isidgv()
        Try
            Dim currentYear As Integer = dtp_tanggal.Value.Year ' Ambil tahun dari DateTimePicker
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbomset WHERE YEAR(tanggal) = @tahun ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    cmdx.Parameters.AddWithValue("@tahun", currentYear) ' Gunakan parameter untuk keamanan
                    Using dax As New MySqlDataAdapter(cmdx)
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbomset")
                            ' Pastikan dataset tidak kosong sebelum mengisi DataGridView
                            If dsx.Tables("tbomset").Rows.Count > 0 Then
                                dgv1.DataSource = dsx.Tables("tbomset")
                                Call headertable()
                            Else
                                dgv1.DataSource = Nothing
                            End If
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub isicaridgv()
        Try
            Dim currentMonth As Integer = dtp_tanggal_cari.Value.Month
            Dim currentYear As Integer = dtp_tanggal_cari.Value.Year
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbomset WHERE YEAR(tanggal) = @tahun AND MONTH(tanggal) = @bulan ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    cmdx.Parameters.AddWithValue("@tahun", currentYear)
                    cmdx.Parameters.AddWithValue("@bulan", currentMonth)
                    Using dax As New MySqlDataAdapter(cmdx)
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbomset")
                            ' Pastikan dataset tidak kosong sebelum mengisi DataGridView
                            If dsx.Tables("tbomset").Rows.Count > 0 Then
                                dgv1.DataSource = dsx.Tables("tbomset")
                                Call headertable()
                            Else
                                dgv1.DataSource = Nothing
                            End If
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dtp_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal.Text = formattedDate
    End Sub
    Private Sub btn_kosong_tanggal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal.Click
        If Not txt_tanggal.Text = "" Then
            txt_tanggal.Text = ""
        End If
    End Sub
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
        If txt_tanggal_cari.Text = "" Then
            Call isidgv()
        Else
            Call isicaridgv()
        End If
    End Sub

    'Private Sub cariupload()
    '    Try
    '        Dim bulan, tahun As Integer
    '        bulan = dtp_tanggal_upload.Value.Month
    '        tahun = dtp_tanggal_upload.Value.Year
    '        dgv_tampil_upload.Columns.Clear()
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE MONTH(tanggal_upload) = '" & bulan & "' AND YEAR(tanggal_upload) = '" & tahun & "' ORDER BY tanggal ASC"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using dax As New MySqlDataAdapter
    '                    dax.SelectCommand = cmdx
    '                    Using dsx As New DataSet
    '                        dax.Fill(dsx, "tbpembelian")
    '                        dgv_tampil_upload.DataSource = dsx.Tables("tbpembelian")
    '                    End Using
    '                End Using
    '            End Using
    '        End Using
    '        Call atur_dgv_tampil_upload()
    '        Call isidgvupload()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_grand_total_omset_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_grand_total_omset.LostFocus
        Dim input As String = txt_grand_total_omset.Text
        Dim number As Decimal
        If Not txt_grand_total_omset.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_grand_total_omset.Text = number.ToString("#,##0.00########")

                Dim omset As String = txt_grand_total_omset.Text
                Dim omset_d, dppomset_d As Decimal
                Decimal.TryParse(omset, omset_d)
                dppomset_d = omset_d / (1 + (ppn / 100))
                txt_dpp_omset.Text = dppomset_d.ToString("#,##0.00########")

                If btn_simpan.Enabled = True Then
                    txt_grand_total_kain.Text = "0,00"
                    txt_dpp_kain.Text = "0,00"
                    txt_polos.Text = "0,00"
                    txt_sisa_omset.Text = txt_grand_total_omset.Text
                Else
                    Dim sisa, kain, polos As Decimal
                    Decimal.TryParse(txt_grand_total_kain.Text, kain)
                    Decimal.TryParse(txt_polos.Text, polos)

                    sisa = input - kain - polos
                    txt_sisa_omset.Text = sisa.ToString("#,##0.00########")

                End If
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_grand_total_omset.Focus()
            End If
        End If
    End Sub
    Private Sub txt_dpp_omset_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dpp_omset.LostFocus
        Dim input As String = txt_dpp_omset.Text
        Dim number As Decimal
        If Not txt_dpp_omset.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_dpp_omset.Text = number.ToString("#,##0.00########")

                Dim dppomset As String = txt_dpp_omset.Text
                Dim omset_d, dppomset_d As Decimal
                Decimal.TryParse(dppomset, dppomset_d)
                omset_d = dppomset_d * (1 + (ppn / 100))
                txt_grand_total_omset.Text = omset_d.ToString("#,##0.00########")

                If btn_simpan.Enabled = True Then
                    txt_grand_total_kain.Text = "0,00"
                    txt_dpp_kain.Text = "0,00"
                    txt_polos.Text = "0,00"
                    txt_sisa_omset.Text = txt_grand_total_omset.Text
                Else
                    Dim sisa, kain, polos As Decimal
                    Decimal.TryParse(txt_grand_total_kain.Text, kain)
                    Decimal.TryParse(txt_polos.Text, polos)

                    sisa = omset_d - kain - polos
                    txt_sisa_omset.Text = sisa.ToString("#,##0.00########")

                End If
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_dpp_omset.Focus()
            End If
        End If
    End Sub

    'Private Sub hitung()
    '    If txt_grand_total_omset.Text = "" Then
    '        Dim dppomset As String = txt_dpp_omset.Text
    '        Dim omset_d, dppomset_d As Decimal
    '        Decimal.TryParse(dppomset, dppomset_d)
    '        omset_d = dppomset_d * (1 + (ppn / 100))
    '        txt_grand_total_omset.Text = omset_d.ToString("#,##0.00########")
    '    ElseIf txt_dpp_omset.Text = "" Then
    '        Dim omset As String = txt_grand_total_omset.Text
    '        Dim omset_d, dppomset_d As Decimal
    '        Decimal.TryParse(omset, omset_d)
    '        dppomset_d = omset_d / (1 + (ppn / 100))
    '        txt_dpp_omset.Text = dppomset_d.ToString("#,##0.00########")
    '    Else
    '        Dim omset As String = txt_grand_total_omset.Text
    '        Dim omset_d, dppomset_d As Decimal
    '        Decimal.TryParse(omset, omset_d)
    '        dppomset_d = omset_d / (1 + (ppn / 100))
    '        txt_dpp_omset.Text = dppomset_d.ToString("#,##0.00########")
    '    End If
    'End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txt_tanggal.Text = "" Then
            MsgBox("Bulan Omset belum diinput")
            dtp_tanggal.Focus()
        ElseIf txt_client.Text = "" Then
            MsgBox("Nama CLIENT Belum Diinput")
            txt_client.Focus()
        ElseIf txt_grand_total_omset.Text = "" And txt_dpp_omset.Text = "" Then
            MsgBox("Grand Total Omset atau DPP Omset belum diinput")
            txt_grand_total_omset.Focus()
        Else
            Try
                'Call hitung()
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbomset (tanggal,client,omset,dpp,dpp_jual,grand_total_kain,polos,kode_omset,sisa_omset) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                            .Parameters.AddWithValue("@2", txt_client.Text)
                            .Parameters.AddWithValue("@3", txt_grand_total_omset.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@4", txt_dpp_omset.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@5", txt_dpp_kain.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@6", txt_grand_total_kain.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@7", txt_polos.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@8", txt_kode_omset.Text)
                            .Parameters.AddWithValue("@9", txt_sisa_omset.Text.Replace(".", "").Replace(",", "."))
                            .ExecuteNonQuery()
                            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                        End With
                    End Using
                End Using
                btn_refresh.PerformClick()
                MessageBox.Show("OMSET Penjualan Baru berhasil di Simpan", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        Try
            dtp_tanggal_cari.Value = Now
            dtp_tanggal.Value = Now
            txt_tanggal_cari.Text = ""
            Call isidgv()
            txt_id_omset.Text = ""
            txt_client.Text = ""
            txt_grand_total_omset.Text = ""
            txt_dpp_omset.Text = ""
            txt_grand_total_kain.Text = ""
            txt_dpp_kain.Text = ""
            txt_polos.Text = ""
            txt_id_omset.Text = ""
            Dim dtptoday As New DateTimePicker
            txt_kode_omset.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
            txt_kode_omset.Text = txt_kode_omset.Text.Replace("-", "").Replace(":", "")
            dtp_tanggal.Value = Today
            txt_tanggal.Text = ""
            txt_sisa_omset.Text = ""
            txt_client_asal.Text = ""
            txt_grand_total_omset_asal.Text = ""
            txt_dpp_omset_asal.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
            form_tampil_isi_omset.txt_kode_omset.Text = row.Cells(8).Value.ToString()
            form_tampil_isi_omset.Show()
            form_tampil_isi_omset.Focus()
            form_tampil_isi_omset.btn_isi_dgv.PerformClick()
        End If
    End Sub

    Private Sub dgv1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim i As Integer
                Dim id, nama, kode As String
                Dim omset, dpp, dpp_jual, grand_total, polos, sisa As Decimal
                Dim tanggal As DateTime
                i = Me.dgv1.CurrentRow.Index
                With dgv1.Rows.Item(i)
                    id = .Cells(0).Value.ToString
                    tanggal = Convert.ToDateTime(.Cells(1).Value)
                    nama = .Cells(2).Value.ToString
                    kode = .Cells(8).Value.ToString

                    Decimal.TryParse(.Cells(3).Value.ToString, omset)
                    Decimal.TryParse(.Cells(4).Value.ToString, dpp)
                    Decimal.TryParse(.Cells(5).Value.ToString, dpp_jual)
                    Decimal.TryParse(.Cells(6).Value.ToString, grand_total)
                    Decimal.TryParse(.Cells(7).Value.ToString, polos)
                    Decimal.TryParse(.Cells(9).Value.ToString, sisa)
                    
                End With
                txt_id_omset.Text = id
                txt_client.Text = nama
                txt_kode_omset.Text = kode
                dtp_tanggal.Text = tanggal
                txt_grand_total_omset.Text = omset.ToString("#,##0.00########")
                txt_dpp_omset.Text = dpp.ToString("#,##0.00########")
                txt_dpp_kain.Text = dpp_jual.ToString("#,##0.00########")
                txt_grand_total_kain.Text = grand_total.ToString("#,##0.00########")
                txt_polos.Text = polos.ToString("#,##0.00########")
                txt_sisa_omset.Text = sisa.ToString("#,##0.00########")

                txt_client_asal.Text = nama
                txt_grand_total_omset_asal.Text = omset.ToString("#,##0.00########")
                txt_dpp_omset_asal.Text = dpp.ToString("#,##0.00########")
                txt_tanggal_asal.Text = txt_tanggal.Text
            End If
        Catch ex As Exception
            MsgBox("Tidak terdapat data Supplier untuk ditampilkan")
        End Try
    End Sub

    Private Sub txt_id_omset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id_omset.TextChanged
        If txt_id_omset.Text = "" Then
            btn_simpan.Enabled = True
            btn_hapus.Enabled = False
            btn_update.Enabled = False
        Else
            btn_simpan.Enabled = False
            btn_hapus.Enabled = True
            btn_update.Enabled = True
        End If
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_grand_total_omset.Text = txt_sisa_omset.Text Then
            If MsgBox("Yakin DATA OMSET Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "DELETE FROM tbomset WHERE id_omset='" & txt_id_omset.Text & "'"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        cmdy.ExecuteNonQuery()
                    End Using
                End Using
                MsgBox("Data Omset berhasil Dihapus")
                btn_refresh.PerformClick()
            End If
        Else
            MsgBox("Sudah ada Transaksi di Omset ini jadi tidak bisa dihapus")
        End If
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        Dim omset, sisa As Decimal
        Decimal.TryParse(txt_grand_total_omset.Text, omset)
        Decimal.TryParse(txt_sisa_omset.Text, sisa)

        If txt_tanggal.Text = "" Then
            MsgBox("Bulan Omset belum diinput")
            dtp_tanggal.Focus()
        ElseIf txt_client.Text = "" Then
            MsgBox("Nama CLIENT Belum Diinput")
            txt_client.Focus()
        ElseIf txt_tanggal.Text = txt_tanggal_asal.Text And txt_grand_total_omset.Text = txt_grand_total_omset_asal.Text _
                   And txt_client.Text = txt_client_asal.Text Then
            MsgBox("Data belum ada yang UBAH")
            txt_grand_total_omset.Focus()
        ElseIf sisa < 0 Then
            MsgBox("Sisa Omset tidak boleh kurang dari 0")
            txt_grand_total_omset.Focus()
        ElseIf (txt_client.Text <> txt_client_asal.Text) And (omset <> sisa) Then
            MsgBox("Tidak dapat merubah Nama Client karena sudah ada transaksi di Omset ini, Clien awal :" & txt_client_asal.Text)
        Else
            Call updateomset()
            MsgBox("DATA OMSET Berhasil Di UPDATE")
            btn_refresh.PerformClick()
        End If
    End Sub
    Private Sub updateomset()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbomset SET tanggal=@1,client=@2,omset=@3,dpp=@4,sisa_omset=@5 WHERE id_omset = '" & txt_id_omset.Text & "'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_client.Text)
                    .Parameters.AddWithValue("@3", txt_grand_total_omset.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@4", txt_dpp_omset.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@5", txt_sisa_omset.Text.Replace(".", "").Replace(",", "."))
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub

End Class