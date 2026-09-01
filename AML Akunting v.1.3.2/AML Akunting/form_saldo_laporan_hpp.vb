Imports MySql.Data.MySqlClient

Public Class form_saldo_laporan_hpp

    Private Sub form_saldo_laporan_hpp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_data()
        btn_simpan.Focus()
    End Sub

    Private Sub tampil_data()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Dim sqlx As String = "SELECT tahun, awal_tahun_obat, akhir_tahun_obat, awal_kain_proses, akhir_kain_proses, awal_kain_warna, akhir_kain_warna " &
                                     "FROM tblaphpp " &
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
                            dt.Rows.Add("SALDO AWAL TAHUN OBAT", If(IsDBNull(reader("awal_tahun_obat")), 0D, Convert.ToDecimal(reader("awal_tahun_obat"))))
                            dt.Rows.Add("SALDO AKHIR TAHUN OBAT", If(IsDBNull(reader("akhir_tahun_obat")), 0D, Convert.ToDecimal(reader("akhir_tahun_obat"))))
                            dt.Rows.Add("SALDO AWAL KAIN PROSES", If(IsDBNull(reader("awal_kain_proses")), 0D, Convert.ToDecimal(reader("awal_kain_proses"))))
                            dt.Rows.Add("SALDO AKHIR KAIN PROSES", If(IsDBNull(reader("akhir_kain_proses")), 0D, Convert.ToDecimal(reader("akhir_kain_proses"))))
                            dt.Rows.Add("SALDO AWAL KAIN WARNA", If(IsDBNull(reader("awal_kain_warna")), 0D, Convert.ToDecimal(reader("awal_kain_warna"))))
                            dt.Rows.Add("SALDO AKHIR KAIN WARNA", If(IsDBNull(reader("akhir_kain_warna")), 0D, Convert.ToDecimal(reader("akhir_kain_warna"))))
                        End If

                        ' Jika data tidak ditemukan, tambahkan baris dengan nilai default 0D
                        If Not dataExist Then
                            dt.Rows.Add("SALDO AWAL TAHUN OBAT", 0D)
                            dt.Rows.Add("SALDO AKHIR TAHUN OBAT", 0D)
                            dt.Rows.Add("SALDO AWAL KAIN PROSES", 0D)
                            dt.Rows.Add("SALDO AKHIR KAIN PROSES", 0D)
                            dt.Rows.Add("SALDO AWAL KAIN WARNA", 0D)
                            dt.Rows.Add("SALDO AKHIR KAIN WARNA", 0D)
                        End If

                        ' Menampilkan data di DataGridView
                        dgv1.DataSource = dt

                        ' Atur tampilan DataGridView
                        dgv1.Columns(0).Width = 200
                        dgv1.Columns(1).Width = 175
                        dgv1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv1.Columns(1).DefaultCellStyle.Format = "#,##0.00" ' Pastikan format tetap

                        txt_awal_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2)
                        txt_akhir_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2)
                        txt_awal_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2)
                        txt_akhir_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2)
                        txt_awal_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2)
                        txt_akhir_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2)

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
        txt_awal_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2)
        txt_akhir_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2)
        txt_awal_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2)
        txt_akhir_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2)
        txt_awal_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2)
        txt_akhir_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2)
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        txt_awal_tahun_obat.Text = "0,00"
        txt_akhir_tahun_obat.Text = "0,00"
        txt_awal_kain_proses.Text = "0,00"
        txt_akhir_kain_proses.Text = "0,00"
        txt_awal_kain_warna.Text = "0,00"
        txt_akhir_kain_warna.Text = "0,00"
    End Sub

    Private Sub FormatTextBoxOnLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txt_awal_tahun_obat.LostFocus, txt_akhir_tahun_obat.LostFocus, txt_awal_kain_proses.LostFocus, txt_akhir_kain_proses.LostFocus, _
    txt_awal_kain_warna.LostFocus, txt_akhir_kain_warna.LostFocus

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
            If txt_awal_tahun_obat.Text = "" Then
                MsgBox("Silakan input SALDO AWAL TAHUN OBAT terlebih dulu")
                txt_awal_tahun_obat.Focus()
            ElseIf txt_akhir_tahun_obat.Text = "" Then
                MsgBox("Silakan input SALDO AKHIR TAHUN OBAT terlebih dulu")
                txt_akhir_tahun_obat.Focus()
            ElseIf txt_awal_kain_proses.Text = "" Then
                MsgBox("Silakan input SALDO AWAL KAIN PROSES terlebih dulu")
                txt_awal_kain_proses.Focus()
            ElseIf txt_akhir_kain_proses.Text = "" Then
                MsgBox("Silakan input SALDO AKHIR KAIN PROSES terlebih dulu")
                txt_akhir_kain_proses.Focus()
            ElseIf txt_awal_kain_warna.Text = "" Then
                MsgBox("Silakan input SALDO AWAL KAIN WARNA terlebih dulu")
                txt_awal_kain_warna.Focus()
            ElseIf txt_akhir_kain_warna.Text = "" Then
                MsgBox("Silakan input SALDO AKHIR KAIN WARNA terlebih dulu")
                txt_akhir_kain_warna.Focus()
            Else
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT tahun FROM tblaphpp WHERE tahun='" & selectedYear & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If txt_awal_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2) _
                                    And txt_akhir_tahun_obat.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2) _
                                    And txt_awal_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2) _
                                    And txt_akhir_kain_proses.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2) _
                                    And txt_awal_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2) _
                                    And txt_akhir_kain_warna.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2) Then
                                    MsgBox("Data SALDO LAPORAN HPP belum ada yang DIUBAH")
                                Else
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "UPDATE tblaphpp SET awal_tahun_obat=@1, akhir_tahun_obat=@2, awal_kain_proses=@3, akhir_kain_proses=@4, awal_kain_warna=@5 , akhir_kain_warna=@6 WHERE tahun = @tahun"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            With cmdy
                                                .Parameters.Clear()
                                                .Parameters.AddWithValue("@tahun", selectedYear)
                                                .Parameters.AddWithValue("@1", txt_awal_tahun_obat.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@2", txt_akhir_tahun_obat.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@3", txt_awal_kain_proses.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@4", txt_akhir_kain_proses.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@5", txt_awal_kain_warna.Text.Replace(".", "").Replace(",", "."))
                                                .Parameters.AddWithValue("@6", txt_akhir_kain_warna.Text.Replace(".", "").Replace(",", "."))
                                                .ExecuteNonQuery()
                                            End With
                                        End Using
                                    End Using
                                    MsgBox("Data SALDO LAPORAN HPP berhasil Di UPDATE")
                                End If
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tblaphpp (tahun, awal_tahun_obat, akhir_tahun_obat, awal_kain_proses, akhir_kain_proses, awal_kain_warna, akhir_kain_warna) VALUES (@1,@2,@3,@4,@5,@6,@7)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", selectedYear)
                                            .Parameters.AddWithValue("@2", txt_awal_tahun_obat.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@3", txt_akhir_tahun_obat.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@4", txt_awal_kain_proses.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@5", txt_akhir_kain_proses.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@6", txt_awal_kain_warna.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_akhir_kain_warna.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                MsgBox("Data SALDO LAPORAN HPP berhasil Di Simpan")
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