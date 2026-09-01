Imports MySql.Data.MySqlClient

Public Class Form_biaya_tahunan

    Private Sub Form_biaya_tahunan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_data()
        btn_simpan.Focus()
    End Sub

    Private Sub tampil_data()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Dim sqlx As String = "SELECT tahun, upah_harian, gaji_pegawai, sewa_pabrik, sewa_kantor, pbb " &
                                     "FROM tbbiayatahunan " &
                                     "WHERE tahun = @selectedYear"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    cmdx.Parameters.AddWithValue("@selectedYear", selectedYear)
                    Using reader As MySqlDataReader = cmdx.ExecuteReader()
                        ' Membuat DataTable
                        Dim dt As New DataTable()
                        dt.Columns.Add("TAHUN", GetType(String))
                        dt.Columns.Add(selectedYear.ToString(), GetType(Decimal)) ' Ubah ke Decimal agar bisa diformat

                        ' Menambahkan data default jika tidak ada hasil
                        Dim dataExist As Boolean = False

                        If reader.Read() Then
                            dataExist = True
                            dt.Rows.Add("UPAH HARIAN", If(IsDBNull(reader("upah_harian")), 0D, Convert.ToDecimal(reader("upah_harian"))))
                            dt.Rows.Add("GAJI PEGAWAI", If(IsDBNull(reader("gaji_pegawai")), 0D, Convert.ToDecimal(reader("gaji_pegawai"))))
                            dt.Rows.Add("SEWA PABRIK", If(IsDBNull(reader("sewa_pabrik")), 0D, Convert.ToDecimal(reader("sewa_pabrik"))))
                            dt.Rows.Add("SEWA KANTOR", If(IsDBNull(reader("sewa_kantor")), 0D, Convert.ToDecimal(reader("sewa_kantor"))))
                            dt.Rows.Add("PBB", If(IsDBNull(reader("pbb")), 0D, Convert.ToDecimal(reader("pbb"))))
                        End If

                        ' Jika data tidak ditemukan, tambahkan baris dengan nilai default 0D
                        If Not dataExist Then
                            dt.Rows.Add("UPAH HARIAN", 0D)
                            dt.Rows.Add("GAJI PEGAWAI", 0D)
                            dt.Rows.Add("SEWA PABRIK", 0D)
                            dt.Rows.Add("SEWA KANTOR", 0D)
                            dt.Rows.Add("PBB", 0D)
                        End If

                        ' Menampilkan data di DataGridView
                        dgv1.DataSource = dt

                        ' Atur tampilan DataGridView
                        dgv1.Columns(0).Width = 150
                        dgv1.Columns(1).Width = 175
                        dgv1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv1.Columns(1).DefaultCellStyle.Format = "#,##0.00" ' Pastikan format tetap

                        txt_upah_harian.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2)
                        txt_gaji_pegawai.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2)
                        txt_sewa_pabrik.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2)
                        txt_sewa_kantor.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2)
                        txt_pbb.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2)

                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtp_tahun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_tahun.KeyPress
        e.Handled = True
    End Sub

    Private Sub dtp_tahun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tahun.ValueChanged
        Call tampil_data()
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        Call tampil_data()
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        txt_upah_harian.Text = "0,00"
        txt_gaji_pegawai.Text = "0,00"
        txt_sewa_pabrik.Text = "0,00"
        txt_sewa_kantor.Text = "0,00"
        txt_pbb.Text = "0,00"
    End Sub

    Private Sub FormatTextBoxOnLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txt_upah_harian.LostFocus, txt_gaji_pegawai.LostFocus, txt_sewa_pabrik.LostFocus, txt_sewa_kantor.LostFocus, txt_pbb.LostFocus

        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim input As String = txt.Text
        Dim number As Decimal

        If String.IsNullOrWhiteSpace(input) Then
            ' Jika kosong, set default 0.00
            txt.Text = "0,00"
        ElseIf Decimal.TryParse(input, number) Then
            ' Format angka dengan #,##0.00########
            txt.Text = number.ToString("#,##0.00########")
        Else
            ' Jika bukan angka, tampilkan pesan error & kembalikan fokus
            MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt.Focus()
        End If
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If txt_upah_harian.Text = "" Then
                MsgBox("Silakan input UPAH HARIAN terlebih dulu")
                txt_upah_harian.Focus()
            ElseIf txt_gaji_pegawai.Text = "" Then
                MsgBox("Silakan input GAJI PEGAWAI terlebih dulu")
                txt_gaji_pegawai.Focus()
            ElseIf txt_sewa_pabrik.Text = "" Then
                MsgBox("Silakan input BIAYA SEWA PABRIK terlebih dulu")
                txt_sewa_pabrik.Focus()
            ElseIf txt_sewa_kantor.Text = "" Then
                MsgBox("Silakan input BIAYA SEWA KANTOR terlebih dulu")
                txt_sewa_kantor.Focus()
            ElseIf txt_pbb.Text = "" Then
                MsgBox("Silakan input BIAYA PBB terlebih dulu")
                txt_pbb.Focus()
            Else
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT tahun FROM tbbiayatahunan WHERE tahun='" & selectedYear & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If txt_upah_harian.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2) _
                                    And txt_gaji_pegawai.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2) _
                                    And txt_sewa_pabrik.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2) _
                                    And txt_sewa_kantor.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2) _
                                    And txt_pbb.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2) Then
                                    MsgBox("Data BIAYA TAHUNAN BELUM ada yang DIUBAH")
                                Else
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "UPDATE tbbiayatahunan SET upah_harian=@1, gaji_pegawai=@2, sewa_pabrik=@3, sewa_kantor=@4, pbb=@5 WHERE tahun = @tahun"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            With cmdy
                                                .Parameters.Clear()
                                                .Parameters.AddWithValue("@tahun", selectedYear)
                                                .Parameters.AddWithValue("@1", txt_upah_harian.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@2", txt_gaji_pegawai.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@3", txt_sewa_pabrik.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@4", txt_sewa_kantor.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@5", txt_pbb.Text.Replace(".", "").Replace(",", "."))
                                                .ExecuteNonQuery()
                                            End With
                                        End Using
                                    End Using
                                    MsgBox("Data BIAYA TAHUNAN berhasil Di UPDATE")
                                End If
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbbiayatahunan (tahun, upah_harian, gaji_pegawai, sewa_pabrik, sewa_kantor, pbb) VALUES (@1,@2,@3,@4,@5,@6)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", selectedYear)
                                            .Parameters.AddWithValue("@2", txt_upah_harian.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@3", txt_gaji_pegawai.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@4", txt_sewa_pabrik.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@5", txt_sewa_kantor.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@6", txt_pbb.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                MsgBox("Data BIAYA TAHUNAN berhasil Di Simpan")
                            End If
                        End Using
                    End Using
                End Using
                Call tampil_data()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class