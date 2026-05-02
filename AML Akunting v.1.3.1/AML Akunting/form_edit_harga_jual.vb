Imports MySql.Data.MySqlClient

Public Class form_edit_harga_jual
    Dim ppn, pph23 As Double
    Private Sub isi_ppn()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT ppn,pph23 from tbppn WHERE id ='ppn'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        ppn = drx(0)
                        pph23 = drx(1)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub form_edit_harga_jual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        'Dim dtptoday As New DateTimePicker
        'txt_kode_grey.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        'txt_kode_grey.Text = txt_kode_grey.Text.Replace("-", "").Replace(":", "")
        'txt_kode_neraca.Text = txt_kode_grey.Text
    End Sub

    Private Sub txt_id_grey_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id_grey.TextChanged
        Call isidgvpembelian()
        Call inputtextbox()
    End Sub

    Private Sub isidgvpembelian()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE id_grey = '" & txt_id_grey.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                            Call atur_dgv()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv()
        dgv1.Columns(2).HeaderText = "Tanggal Beli"
        dgv1.Columns(4).HeaderText = "Supplier"
        dgv1.Columns(5).HeaderText = "Nama Grey"
        dgv1.Columns(9).HeaderText = "Quantity (Mtr/Yard)"
        dgv1.Columns(10).HeaderText = "Harga Beli DPP (Rp)"
        dgv1.Columns(11).HeaderText = "Harga Jual DPP (Rp)"
        dgv1.Columns(12).HeaderText = "Harga Jual + PPN (Rp)"
        dgv1.Columns(13).HeaderText = "DPP Jual Tersedia (Rp)"
        dgv1.Columns(14).HeaderText = "Nama Jual"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).Visible = False
        dgv1.Columns(3).Visible = False
        dgv1.Columns(7).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(6).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub inputtextbox()
        If dgv1.Rows.Count > 0 Then
            Dim row As DataGridViewRow = dgv1.Rows(0)
            txt_id_beli.Text = row.Cells(1).Value.ToString()
            dtp_tanggal.Text = row.Cells(2).Value.ToString()
            txt_no_faktur.Text = row.Cells(3).Value.ToString()
            txt_Supplier.Text = row.Cells(4).Value.ToString()
            txt_nama_grey.Text = row.Cells(5).Value.ToString()
            cbo_nama_jual.Text = row.Cells(14).Value.ToString()
            cbo_nama_jual_awal.Text = row.Cells(14).Value.ToString()
            txt_kode_beli.Text = row.Cells(15).Value.ToString()
            txt_kode_grey.Text = row.Cells(16).Value.ToString()
            txt_kode_Neraca.Text = row.Cells(17).Value.ToString()

            Dim qty As String = row.Cells(9).Value.ToString()
            Dim dpp As String = row.Cells(10).Value.ToString()
            Dim hargajual As String = row.Cells(11).Value.ToString()
            Dim hargajualppn As String = row.Cells(12).Value.ToString()
            Dim dpptersedia As String = row.Cells(13).Value.ToString()
            Dim qty_d, dpp_d, hargajual_d, hargajualppn_d, dppppn_d, dpptersedia_d As Decimal
            Decimal.TryParse(qty, qty_d)
            Decimal.TryParse(dpp, dpp_d)
            Decimal.TryParse(hargajual, hargajual_d)
            Decimal.TryParse(hargajualppn, hargajualppn_d)
            Decimal.TryParse(dpptersedia, dpptersedia_d)

            dppppn_d = dpp_d * (1 + (ppn / 100))

            txt_jumlah.Text = qty_d.ToString("#,##0.00########")
            txt_dpp_grey.Text = dpp_d.ToString("#,##0.00########")
            txt_harga_dpp_penjualan.Text = hargajual_d.ToString("#,##0.00########")
            txt_harga_jual_ppn.Text = hargajualppn_d.ToString("#,##0")
            txt_dpp_grey_ppn.Text = dppppn_d.ToString("#,##0")
            txt_dpp_tersedia.Text = dpptersedia_d.ToString("#,##0.00########")

            txt_harga_dpp_penjualan_awal.Text = hargajual_d.ToString("#,##0.00########")
            txt_dpp_tersedia_awal.Text = dpptersedia_d.ToString("#,##0.00########")
            txt_harga_jual_ppn_awal.Text = hargajualppn_d.ToString("#,##0")

        End If
    End Sub

    Private Sub btn_hitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung.Click
        Try
            If btn_hitung.Text = "HITUNG" Then
                If cbo_nama_jual.Text = "" Then
                    MsgBox("Nama Jual belum diinput")
                    cbo_nama_jual.Focus()
                ElseIf txt_harga_jual_ppn.Text = "" Then
                    MsgBox("Harga Jual belum diinput")
                    txt_harga_jual_ppn.Focus()
                ElseIf txt_harga_jual_ppn.Text = txt_harga_jual_ppn_awal.Text And cbo_nama_jual.Text = cbo_nama_jual_awal.Text Then
                    MsgBox("Nama atau Harga Jual belum dirubah")
                    txt_harga_jual_ppn.Focus()
                Else
                    Call hitung()
                    Dim dppbeli As String = txt_dpp_grey.Text
                    Dim dppjual As String = txt_harga_dpp_penjualan.Text
                    Dim decdppbeli As Decimal
                    Dim decdppjual As Decimal
                    decdppbeli = Decimal.Parse(dppbeli)
                    decdppjual = Decimal.Parse(dppjual)
                    If Math.Round(decdppjual) < Math.Round(decdppbeli) Then
                        MsgBox("Harga Jual LEBIH KECIL dari Harga beli Grey")
                    ElseIf Math.Round(decdppjual) = Math.Round(decdppbeli) Then
                        MsgBox("Harga Jual SAMA dengan DPP Harga beli Grey")
                    Else
                        btn_hitung.Text = "EDIT"
                        btn_simpan.Enabled = True
                        Panel1.Enabled = False
                    End If
                End If
            Else
                btn_hitung.Text = "HITUNG"
                btn_simpan.Enabled = False
                Panel1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub hitung()
        Dim qty, hargajualppn, hargajualdpp, totaldpp As Double

        qty = txt_jumlah.Text.Replace(".", "")
        hargajualppn = txt_harga_jual_ppn.Text.Replace(".", "")

        hargajualdpp = hargajualppn / (1 + (ppn / 100))
        totaldpp = qty * hargajualdpp

        txt_harga_dpp_penjualan.Text = hargajualdpp.ToString("#,##0.00########")
        txt_dpp_tersedia.Text = totaldpp.ToString("#,##0.00########")

        Dim awaldpp, akhirdpp, selisih As Double

        awaldpp = txt_dpp_tersedia_awal.Text.Replace(".", "")
        akhirdpp = txt_dpp_tersedia.Text.Replace(".", "")
        selisih = akhirdpp - awaldpp

        txt_selisih_dpp.Text = selisih.ToString("#,##0.00########")
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbgrey SET harga_jual=@1, harga_jual_ppn=@2, dpp_jual=@3, nama_jual=@4 WHERE id_grey = '" & txt_id_grey.Text & "'"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@2", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@3", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@4", cbo_nama_jual.Text)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga,harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        dtp_tanggal.Text = Today
                        dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", txt_id_beli.Text)
                        .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur.Text)
                        .Parameters.AddWithValue("@4", txt_Supplier.Text)
                        .Parameters.AddWithValue("@5", txt_nama_grey.Text)
                        .Parameters.AddWithValue("@6", 0)
                        .Parameters.AddWithValue("@7", 0)
                        .Parameters.AddWithValue("@8", 0)
                        .Parameters.AddWithValue("@9", 0)
                        .Parameters.AddWithValue("@10", txt_dpp_grey.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@13", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                        .Parameters.AddWithValue("@15", txt_kode_beli.Text)
                        .Parameters.AddWithValue("@16", txt_kode_grey.Text)
                        .Parameters.AddWithValue("@17", txt_kode_Neraca.Text)
                        .ExecuteNonQuery()
                        dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    End With
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbneracagrey SET harga_jual = @1, dpp_jual= dpp_jual + @2 WHERE kode_neraca = '" & txt_kode_Neraca.Text & "'"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@2", txt_selisih_dpp.Text.Replace(".", "").Replace(",", "."))
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using

            MsgBox("Nama atau Harga Jual Berhasil Diupdate")
            form_data_grey.Show()
            form_data_grey.Focus()
            form_data_grey.ts_perbarui.PerformClick()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
End Class