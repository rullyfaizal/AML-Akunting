Imports MySql.Data.MySqlClient

Public Class form_input_harga_jual_grey

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

    Private Sub form_input_harga_jual_grey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgvpembelian()
        Call isi_ppn()
        Dim dtptoday As New DateTimePicker
        txt_kode_grey.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        txt_kode_grey.Text = txt_kode_grey.Text.Replace("-", "").Replace(":", "")
        txt_kode_neraca.Text = txt_kode_grey.Text
    End Sub

    Private Sub isidgvpembelian()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbpembelian WHERE jenis_biaya = 'GREY' AND status2 = '' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                            Call tambahkolom()
                            Call atur_dgv()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub tambahkolom()
        Dim newColumn As New DataGridViewTextBoxColumn
        newColumn.Name = "hargappn"
        newColumn.HeaderText = "HARGA GREY +PPN (Rp)"
        dgv1.Columns.Add(newColumn)

        ' Iterasi setiap baris untuk mengisi kolom baru dengan hasil pembagian
        For Each row As DataGridViewRow In dgv1.Rows
            ' Pastikan nilai di kolom 1 dan kolom 2 bukan null dan tidak 0
            If Not IsDBNull(row.Cells(6).Value) AndAlso Not IsDBNull(row.Cells(10).Value) Then
                Dim kolom1Value As Decimal = Convert.ToDecimal(row.Cells(6).Value)
                Dim kolom2Value As Decimal = Convert.ToDecimal(row.Cells(10).Value)

                If kolom1Value <> 0 Then
                    row.Cells("hargappn").Value = kolom2Value / kolom1Value
                Else
                    row.Cells("hargappn").Value = "Error" ' Atau 0, atau pesan lain jika kolom1Value = 0
                End If
            Else
                row.Cells("hargappn").Value = DBNull.Value
            End If
        Next
    End Sub
    Private Sub atur_dgv()
        dgv1.Columns(1).HeaderText = "TGL BELI"
        dgv1.Columns(2).HeaderText = "NO FAKTUR"
        dgv1.Columns(3).HeaderText = "SUPPLIER"
        dgv1.Columns(5).HeaderText = "NAMA GREY"
        dgv1.Columns(6).HeaderText = "QUANTITY"
        dgv1.Columns(7).HeaderText = "HARGA DPP GREY (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(4).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(9).Visible = False
        dgv1.Columns(10).Visible = False
        dgv1.Columns(11).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(13).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(17).Width = 120
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(17).DefaultCellStyle.Format = "#,##0"
    End Sub

    Private Sub dgv1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        Dim dtptoday As New DateTimePicker
        txt_kode_grey.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        txt_kode_grey.Text = txt_kode_grey.Text.Replace("-", "").Replace(":", "")
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                txt_id_beli.Text = row.Cells(0).Value.ToString()
                dtp_tanggal.Text = row.Cells(1).Value.ToString()
                txt_no_faktur.Text = row.Cells(2).Value.ToString()
                txt_Supplier.Text = row.Cells(3).Value.ToString()
                txt_nama_grey.Text = row.Cells(5).Value.ToString()
                Dim qty As String = row.Cells(6).Value.ToString()
                Dim dpp As String = row.Cells(7).Value.ToString()
                Dim dppppn As String = row.Cells(17).Value.ToString()
                Dim qty_d, dpp_d, dppppn_d As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(dpp, dpp_d)
                Decimal.TryParse(dppppn, dppppn_d)
                txt_jumlah.Text = qty_d.ToString("#,##0.00########")
                txt_dpp_grey.Text = dpp_d.ToString("#,##0.00########")
                txt_dpp_grey_ppn.Text = dppppn_d.ToString("#,##0")
                txt_kode_beli.Text = row.Cells(15).Value.ToString()

                cbo_nama_jual.Text = ""
                txt_harga_jual_ppn.Text = ""
                txt_harga_dpp_penjualan.Text = ""
                txt_dpp_tersedia.Text = ""
                Call isidgvindukgrey()
            End If
        End If
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
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

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "INSERT INTO tbgrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga,harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", txt_id_beli.Text)
                        .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur.Text)
                        .Parameters.AddWithValue("@4", txt_Supplier.Text)
                        .Parameters.AddWithValue("@5", txt_nama_grey.Text)
                        .Parameters.AddWithValue("@6", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@7", 0)
                        .Parameters.AddWithValue("@8", 0)
                        .Parameters.AddWithValue("@9", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@10", txt_dpp_grey.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@13", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                        .Parameters.AddWithValue("@15", txt_kode_beli.Text)
                        .Parameters.AddWithValue("@16", txt_kode_grey.Text)
                        .Parameters.AddWithValue("@17", txt_kode_neraca.Text)
                        .ExecuteNonQuery()
                        dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    End With
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbpembelian SET status2=@1 WHERE id_beli = '" & txt_id_beli.Text & "'"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", "GREY")
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using

            If txt_kode_neraca.Text = txt_kode_grey.Text Then
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbneracagrey (nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga_jual,dpp_jual,kode_neraca) VALUES (@1,@2,@3,@4,@5,@6,@7,@8)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", txt_nama_grey.Text)
                            .Parameters.AddWithValue("@2", 0)
                            .Parameters.AddWithValue("@3", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@4", 0)
                            .Parameters.AddWithValue("@5", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@6", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@7", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@8", txt_kode_neraca.Text)
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
            Else
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "UPDATE tbneracagrey SET stok_masuk= stok_masuk + @1,stok_akhir= stok_akhir + @2, harga_jual = @3, dpp_jual= dpp_jual+ @4 WHERE kode_neraca = '" & txt_kode_neraca.Text & "'"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@2", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@3", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                            .Parameters.AddWithValue("@4", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
            End If
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "INSERT INTO tbhistorygrey (id_beli,tanggal,no_faktur,supplier,nama_specs,stok_awal,stok_masuk,stok_keluar,stok_akhir,harga,harga_jual,harga_jual_ppn,dpp_jual,nama_jual,kode,kode_grey,kode_neraca) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", txt_id_beli.Text)
                        .Parameters.AddWithValue("@2", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur.Text)
                        .Parameters.AddWithValue("@4", txt_Supplier.Text)
                        .Parameters.AddWithValue("@5", txt_nama_grey.Text)
                        .Parameters.AddWithValue("@6", 0)
                        .Parameters.AddWithValue("@7", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@8", 0)
                        .Parameters.AddWithValue("@9", 0)
                        .Parameters.AddWithValue("@10", txt_dpp_grey.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_harga_dpp_penjualan.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", txt_harga_jual_ppn.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@13", txt_dpp_tersedia.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@14", cbo_nama_jual.Text)
                        .Parameters.AddWithValue("@15", txt_kode_beli.Text)
                        .Parameters.AddWithValue("@16", txt_kode_grey.Text)
                        .Parameters.AddWithValue("@17", txt_kode_neraca.Text)
                        .ExecuteNonQuery()
                        dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    End With
                End Using
            End Using

            MsgBox("Input Nama dan Harga Jual Berhasil Disimpan")
            form_data_grey.Show()
            form_data_grey.Focus()
            form_data_grey.ts_perbarui.PerformClick()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub isidgvindukgrey()
        Try
            Dim inputValue As String = txt_dpp_grey.Text
            Dim decimalValue As Decimal
            decimalValue = Decimal.Parse(inputValue)

            dgv2.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE nama_specs='" & txt_nama_grey.Text & "' AND ROUND(harga)='" & Math.Round(decimalValue) & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv2.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk()
                        End Using
                    End Using
                End Using
            End Using
            If dgv2.Rows.Count > 0 Then
                cbo_nama_jual.Text = dgv2.Rows(0).Cells(14).Value
                txt_kode_neraca.Text = dgv2.Rows(0).Cells(17).Value
                txt_harga_jual_ppn.Text = Math.Round(dgv2.Rows(0).Cells(12).Value)
                Dim input As String = txt_harga_jual_ppn.Text
                Dim number As Decimal
                number = Decimal.Parse(input)
                txt_harga_jual_ppn.Text = number.ToString("#,##0")
            Else
                txt_kode_neraca.Text = txt_kode_grey.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub atur_dgv_induk()
        dgv2.Columns(2).HeaderText = "Tanggal Beli"
        dgv2.Columns(4).HeaderText = "Supplier"
        dgv2.Columns(5).HeaderText = "Nama Grey"
        dgv2.Columns(9).HeaderText = "Quantity (Mtr/Yard)"
        dgv2.Columns(10).HeaderText = "Harga Beli DPP (Rp)"
        dgv2.Columns(11).HeaderText = "Harga Jual DPP (Rp)"
        dgv2.Columns(12).HeaderText = "Harga Jual + PPN (Rp)"
        dgv2.Columns(13).HeaderText = "DPP Jual Tersedia (Rp)"
        dgv2.Columns(14).HeaderText = "Nama Jual"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.Columns(0).Visible = False
        dgv2.Columns(1).Visible = False
        dgv2.Columns(3).Visible = False
        dgv2.Columns(7).Visible = False
        dgv2.Columns(8).Visible = False
        dgv2.Columns(6).Visible = False
        dgv2.Columns(15).Visible = False
        dgv2.Columns(16).Visible = False
        dgv2.RowHeadersWidth = 60
        dgv2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub dgv1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.ColumnHeaderMouseClick
        dgv1.Columns.RemoveAt(dgv1.Columns.Count - 1)
        Call tambahkolom()
        Call atur_dgv()
    End Sub
End Class