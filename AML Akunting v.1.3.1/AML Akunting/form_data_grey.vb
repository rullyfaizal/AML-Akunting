Imports MySql.Data.MySqlClient

Public Class form_data_grey

    Private Sub ts_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_harga_jual.Click
        form_input_harga_jual_grey.Show()
        form_input_harga_jual_grey.Focus()
    End Sub

    Private Sub form_data_grey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call awal()
    End Sub

    Private Sub awal()
        dtp_hari_ini.Text = Today
        dtp_awal.Text = "01/" & DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Year.ToString()
        dtp_akhir.Text = Today
        Call isidgvindukgrey()
        rb_tersedia.Checked = True
        Label6.Text = "DATA STOK GREY TERSEDIA"
    End Sub

    Private Sub isidgvindukgrey()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir > 5"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk()
                            Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_awal.CustomFormat = "dd/MM/yyyy"
            dtp_akhir.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub hitungjumlah()
        Dim awal, masuk, keluar, akhir, dpp As Decimal
        awal = 0
        masuk = 0
        keluar = 0
        akhir = 0
        dpp = 0
        For i As Integer = 0 To dgv1.Rows.Count - 1
            awal = awal + Decimal.Round((dgv1.Rows(i).Cells(6).Value), 10)
            masuk = masuk + Decimal.Round((dgv1.Rows(i).Cells(7).Value), 10)
            keluar = keluar + Decimal.Round((dgv1.Rows(i).Cells(8).Value), 10)
            akhir = akhir + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
            dpp = dpp + Decimal.Round((dgv1.Rows(i).Cells(13).Value), 10)
        Next
        txt_awal.Text = awal.ToString("#,##0.00")
        txt_masuk.Text = masuk.ToString("#,##0.00")
        txt_keluar.Text = keluar.ToString("#,##0.00")
        txt_akhir.Text = akhir.ToString("#,##0.00")
        txt_dpp_tersedia.Text = dpp.ToString("#,##0.00")
    End Sub
    Private Sub atur_dgv_induk()
        dgv1.Columns(2).HeaderText = "Tanggal Beli"
        'dgv1.Columns(3).HeaderText = "No Faktur"
        dgv1.Columns(4).HeaderText = "Supplier"
        dgv1.Columns(5).HeaderText = "Nama Grey"
        'dgv1.Columns(6).HeaderText = "Stok Awal (Mtr/Yard)"
        'dgv1.Columns(7).HeaderText = "Masuk (Mtr/Yard)"
        'dgv1.Columns(8).HeaderText = "Keluar (Mtr/Yard)"
        dgv1.Columns(9).HeaderText = "Stok Tersedia (Mtr/Yard)"
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
        dgv1.Columns(6).Visible = False
        dgv1.Columns(7).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        'dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        'dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If e.RowIndex >= 0 Then
                form_detail_grey.Show()
                form_detail_grey.Focus()
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                Dim awal As String = row.Cells(6).Value.ToString()
                Dim masuk As String = row.Cells(7).Value.ToString()
                Dim keluar As String = row.Cells(8).Value.ToString()
                Dim akhir As String = row.Cells(9).Value.ToString()
                Dim dpp As String = row.Cells(13).Value.ToString()
                Dim awal_d, masuk_d, keluar_d, akhir_d, dpp_d As Decimal
                Decimal.TryParse(awal, awal_d)
                Decimal.TryParse(masuk, masuk_d)
                Decimal.TryParse(keluar, keluar_d)
                Decimal.TryParse(akhir, akhir_d)
                Decimal.TryParse(dpp, dpp_d)
                form_detail_grey.txt_awal.Text = awal_d.ToString("#,##0.00")
                form_detail_grey.txt_masuk.Text = masuk_d.ToString("#,##0.00")
                form_detail_grey.txt_keluar.Text = keluar_d.ToString("#,##0.00")
                form_detail_grey.txt_akhir.Text = akhir_d.ToString("#,##0.00")
                form_detail_grey.txt_dpp_tersedia.Text = dpp_d.ToString("#,##0.00")
                form_detail_grey.txt_kode_grey.Text = row.Cells(16).Value.ToString()
            End If
        End If
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub ts_perbarui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_perbarui.Click
        Call awal()
    End Sub

    Private Sub dtp_akhir_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_akhir.TextChanged, dtp_awal.TextChanged
        If dtp_awal.Value > dtp_akhir.Value Then
            dtp_akhir.Text = dtp_awal.Text
        End If
    End Sub
    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        If rb_tersedia.Checked = True Then
            Call isigreytersedia()
            Label6.Text = "DATA STOK GREY TERSEDIA : " & dtp_awal.Text & " s/d " & dtp_akhir.Text & ""
            If dgv1.Rows.Count = 0 Then
                MsgBox("Data yang dicari tidak ada")
            End If
        ElseIf rb_bs.Checked = True Then
            Call isigreybs()
            Label6.Text = "DATA STOK GREY BS : " & dtp_awal.Text & " s/d " & dtp_akhir.Text & ""
            If dgv1.Rows.Count = 0 Then
                MsgBox("Data yang dicari tidak ada")
            End If
        ElseIf rb_kosong.Checked = True Then
            Call isigreykosong()
            Label6.Text = "DATA STOK GREY KOSONG : " & dtp_awal.Text & " s/d " & dtp_akhir.Text & ""
            If dgv1.Rows.Count = 0 Then
                MsgBox("Data yang dicari tidak ada")
            End If
        Else
            Call awal()
        End If
    End Sub
    Private Sub isigreytersedia()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir > 5 AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk()
                            Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_awal.CustomFormat = "dd/MM/yyyy"
            dtp_akhir.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub isigreybs()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbhistorygrey WHERE stok_keluar <= 5 AND stok_keluar >= 1 AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk_bs()
                            'Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_awal.CustomFormat = "dd/MM/yyyy"
            dtp_akhir.CustomFormat = "dd/MM/yyyy"
            txt_akhir.Text = "0,00"
            txt_dpp_tersedia.Text = "0,00"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk_bs()
        dgv1.Columns(2).HeaderText = "Tanggal Beli"
        'dgv1.Columns(3).HeaderText = "No Faktur"
        dgv1.Columns(4).HeaderText = "Supplier"
        dgv1.Columns(5).HeaderText = "Nama Grey"
        'dgv1.Columns(6).HeaderText = "Stok Awal (Mtr/Yard)"
        'dgv1.Columns(7).HeaderText = "Masuk (Mtr/Yard)"
        dgv1.Columns(8).HeaderText = "Stok BS (Mtr/Yard)"
        'dgv1.Columns(9).HeaderText = "Stok Tersedia (Mtr/Yard)"
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
        dgv1.Columns(6).Visible = False
        dgv1.Columns(7).Visible = False
        dgv1.Columns(9).Visible = False
        dgv1.Columns(10).Visible = False
        dgv1.Columns(11).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(13).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.Columns(18).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        'dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub isigreykosong()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir = 0 AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk()
                            Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_awal.CustomFormat = "dd/MM/yyyy"
            dtp_akhir.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        Call awal()
    End Sub

    Private Sub ts_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_hapus.Click
        Try
            If dgv1.CurrentRow.Cells(8).Value = 0 Then
                Using conx As New MySqlConnection(sLocalConn)
                    If MsgBox("Yakin Data STOK Grey : " & dgv1.CurrentRow.Cells(5).Value & " dengan Stok " & Math.Round(dgv1.CurrentRow.Cells(9).Value, 2) & "  Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_grey='" & dgv1.CurrentRow.Cells(0).Value & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE kode_grey='" & dgv1.CurrentRow.Cells(16).Value & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                        Using conz As New MySqlConnection(sLocalConn)
                            conz.Open()
                            Dim sqlz = "UPDATE tbpembelian SET status2 = '' WHERE id_beli = '" & dgv1.CurrentRow.Cells(1).Value & "';"
                            Using cmdz As New MySqlCommand(sqlz, conz)
                                cmdz.ExecuteNonQuery()
                            End Using
                        End Using
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "UPDATE tbneracagrey SET stok_masuk= stok_masuk - @1,stok_akhir= stok_akhir - @2, dpp_jual= dpp_jual- @3 WHERE kode_neraca = '" & dgv1.CurrentRow.Cells(17).Value & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                With cmdy
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@1", dgv1.CurrentRow.Cells(6).Value)
                                    .Parameters.AddWithValue("@2", dgv1.CurrentRow.Cells(6).Value)
                                    .Parameters.AddWithValue("@3", dgv1.CurrentRow.Cells(13).Value)
                                    .ExecuteNonQuery()
                                End With
                            End Using
                        End Using
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "SELECT kode_neraca FROM tbneracagrey WHERE stok_awal=0 AND stok_masuk=0 AND stok_keluar=0 AND stok_akhir=0"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                Using dry As MySqlDataReader = cmdy.ExecuteReader
                                    dry.Read()
                                    If dry.HasRows Then
                                        Using conz As New MySqlConnection(sLocalConn)
                                            conz.Open()
                                            Dim sqlz = "DELETE FROM tbneracagrey WHERE kode_neraca='" & dgv1.CurrentRow.Cells(17).Value & "'"
                                            Using cmdz As New MySqlCommand(sqlz, conz)
                                                cmdz.ExecuteNonQuery()
                                            End Using
                                        End Using
                                    End If
                                End Using
                            End Using
                        End Using
                        MessageBox.Show("Data Data STOK Grey : " & dgv1.CurrentRow.Cells(5).Value & " dengan Stok " & Math.Round(dgv1.CurrentRow.Cells(9).Value, 2) & " berhasil di Hapus", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ts_perbarui.PerformClick()
                    End If
                End Using
            Else
                MsgBox("DATA GREY TIDAK BISA DIHAPUS karena sudah ada STOK KELUAR")
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data STOK yang akan di HAPUS")
        End Try
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        Try
            If dgv1.CurrentRow Is Nothing Then
                MsgBox("Silahkan Pilih Terlebih dahulu Data STOK yang akan di UBAH")
            Else
                form_edit_harga_jual.Show()
                form_edit_harga_jual.Focus()
                form_edit_harga_jual.txt_id_grey.Text = dgv1.CurrentRow.Cells(0).Value
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data STOK yang akan di UBAH")
        End Try
    End Sub

    Private Sub dgv1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.ColumnHeaderMouseClick
        Call atur_dgv_induk()
        Call hitungjumlah()
    End Sub
End Class