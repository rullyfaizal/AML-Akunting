Imports MySql.Data.MySqlClient

Public Class form_angsuran_pph25

    Private Sub form_angsuran_pph25_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_data()
        btn_simpan.Focus()
    End Sub

    Private Sub tampil_data()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Dim sqlx As String = "SELECT tahun, januari, februari, maret, april, mei, juni, juli, agustus, september, oktober, november, desember, total " &
                                     "FROM tbangsuranpph25 " &
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
                            dt.Rows.Add("JANUARI", If(IsDBNull(reader("januari")), 0D, Convert.ToDecimal(reader("januari"))))
                            dt.Rows.Add("FEBRUARI", If(IsDBNull(reader("februari")), 0D, Convert.ToDecimal(reader("februari"))))
                            dt.Rows.Add("MARET", If(IsDBNull(reader("maret")), 0D, Convert.ToDecimal(reader("maret"))))
                            dt.Rows.Add("APRIL", If(IsDBNull(reader("april")), 0D, Convert.ToDecimal(reader("april"))))
                            dt.Rows.Add("MEI", If(IsDBNull(reader("mei")), 0D, Convert.ToDecimal(reader("mei"))))
                            dt.Rows.Add("JUNI", If(IsDBNull(reader("juni")), 0D, Convert.ToDecimal(reader("juni"))))
                            dt.Rows.Add("JULI", If(IsDBNull(reader("juli")), 0D, Convert.ToDecimal(reader("juli"))))
                            dt.Rows.Add("AGUSTUS", If(IsDBNull(reader("agustus")), 0D, Convert.ToDecimal(reader("agustus"))))
                            dt.Rows.Add("SEPTEMBER", If(IsDBNull(reader("september")), 0D, Convert.ToDecimal(reader("september"))))
                            dt.Rows.Add("OKTOBER", If(IsDBNull(reader("oktober")), 0D, Convert.ToDecimal(reader("oktober"))))
                            dt.Rows.Add("NOVEMBER", If(IsDBNull(reader("november")), 0D, Convert.ToDecimal(reader("november"))))
                            dt.Rows.Add("DESEMBER", If(IsDBNull(reader("desember")), 0D, Convert.ToDecimal(reader("desember"))))
                            dt.Rows.Add("TOTAL", If(IsDBNull(reader("total")), 0D, Convert.ToDecimal(reader("total"))))
                        End If

                        ' Jika data tidak ditemukan, tambahkan baris dengan nilai default 0D
                        If Not dataExist Then
                            dt.Rows.Add("JANUARI", 0D)
                            dt.Rows.Add("FEBRUARI", 0D)
                            dt.Rows.Add("MARET", 0D)
                            dt.Rows.Add("APRIL", 0D)
                            dt.Rows.Add("MEI", 0D)
                            dt.Rows.Add("JUNI", 0D)
                            dt.Rows.Add("JULI", 0D)
                            dt.Rows.Add("AGUSTUS", 0D)
                            dt.Rows.Add("SEPTEMBER", 0D)
                            dt.Rows.Add("OKTOBER", 0D)
                            dt.Rows.Add("NOVEMBER", 0D)
                            dt.Rows.Add("DESEMBER", 0D)
                            dt.Rows.Add("TOTAL", 0D)
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
                        dgv1.Rows(12).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight

                        txt_januari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2)
                        txt_februari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2)
                        txt_maret.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2)
                        txt_april.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2)
                        txt_mei.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2)
                        txt_juni.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2)
                        txt_juli.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(6).Cells(1).Value), 2)
                        txt_agustus.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(7).Cells(1).Value), 2)
                        txt_september.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(8).Cells(1).Value), 2)
                        txt_oktober.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(9).Cells(1).Value), 2)
                        txt_november.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(10).Cells(1).Value), 2)
                        txt_desember.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(11).Cells(1).Value), 2)
                        txt_total.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(12).Cells(1).Value), 2)
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
        txt_januari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2)
        txt_februari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2)
        txt_maret.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2)
        txt_april.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2)
        txt_mei.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2)
        txt_juni.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2)
        txt_juli.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(6).Cells(1).Value), 2)
        txt_agustus.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(7).Cells(1).Value), 2)
        txt_september.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(8).Cells(1).Value), 2)
        txt_oktober.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(9).Cells(1).Value), 2)
        txt_november.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(10).Cells(1).Value), 2)
        txt_desember.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(11).Cells(1).Value), 2)
        txt_total.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(12).Cells(1).Value), 2)
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        txt_januari.Text = "0,00"
        txt_februari.Text = "0,00"
        txt_maret.Text = "0,00"
        txt_april.Text = "0,00"
        txt_mei.Text = "0,00"
        txt_juni.Text = "0,00"
        txt_juli.Text = "0,00"
        txt_agustus.Text = "0,00"
        txt_september.Text = "0,00"
        txt_oktober.Text = "0,00"
        txt_november.Text = "0,00"
        txt_desember.Text = "0,00"
        txt_total.Text = "0,00"
    End Sub

    Private Sub FormatTextBoxOnLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txt_januari.LostFocus, txt_februari.LostFocus, txt_maret.LostFocus, txt_april.LostFocus, txt_mei.LostFocus, txt_juni.LostFocus, _
    txt_juli.LostFocus, txt_agustus.LostFocus, txt_september.LostFocus, txt_oktober.LostFocus, txt_november.LostFocus, txt_desember.LostFocus
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim input As String = txt.Text
        Dim number As Decimal

        If String.IsNullOrWhiteSpace(input) Then
            ' Jika kosong, set default 0.00
            txt.Text = "0,00"
        ElseIf Decimal.TryParse(input, number) Then
            ' Format angka dengan #,##0.00########
            txt.Text = number.ToString("#,##0.00########")
            Call hitung_total()
        Else
            ' Jika bukan angka, tampilkan pesan error & kembalikan fokus
            MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt.Focus()
        End If
    End Sub

    Private Sub hitung_total()
        Dim jan As Decimal = txt_januari.Text.Replace(".", "")
        Dim feb As Decimal = txt_februari.Text.Replace(".", "")
        Dim mar As Decimal = txt_maret.Text.Replace(".", "")
        Dim apr As Decimal = txt_april.Text.Replace(".", "")
        Dim mei As Decimal = txt_mei.Text.Replace(".", "")
        Dim jun As Decimal = txt_juni.Text.Replace(".", "")
        Dim jul As Decimal = txt_juli.Text.Replace(".", "")
        Dim agu As Decimal = txt_agustus.Text.Replace(".", "")
        Dim sep As Decimal = txt_september.Text.Replace(".", "")
        Dim okt As Decimal = txt_oktober.Text.Replace(".", "")
        Dim nov As Decimal = txt_november.Text.Replace(".", "")
        Dim des As Decimal = txt_desember.Text.Replace(".", "") '.Replace(",", ".")
        Dim total As Decimal = jan + feb + mar + apr + mei + jun + jul + agu + sep + okt + nov + des
        txt_total.Text = total.ToString("#,##0.00")
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            Dim selectedYear As Integer = dtp_tahun.Value.Year
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT tahun FROM tbangsuranpph25 WHERE tahun='" & selectedYear & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            If txt_januari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(0).Cells(1).Value), 2) _
                                And txt_februari.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(1).Cells(1).Value), 2) _
                                And txt_maret.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(2).Cells(1).Value), 2) _
                                And txt_april.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(3).Cells(1).Value), 2) _
                                And txt_mei.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(4).Cells(1).Value), 2) _
                                And txt_juni.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(5).Cells(1).Value), 2) _
                                And txt_juli.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(6).Cells(1).Value), 2) _
                                And txt_agustus.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(7).Cells(1).Value), 2) _
                                And txt_september.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(8).Cells(1).Value), 2) _
                                And txt_oktober.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(9).Cells(1).Value), 2) _
                                And txt_november.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(10).Cells(1).Value), 2) _
                                And txt_desember.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(11).Cells(1).Value), 2) _
                                And txt_total.Text = FormatNumber(Convert.ToDecimal(dgv1.Rows(12).Cells(1).Value), 2) Then
                                MsgBox("Data Angsuran PPh 25 belum ada yang DIUBAH")
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbangsuranpph25 SET januari=@1, februari=@2, maret=@3, april=@4, mei=@5, " &
                                        "juni=@6, juli=@7, agustus=@8, september=@9, oktober=@10, november=@11, desember=@12, total=@13 WHERE tahun = @tahun"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@tahun", selectedYear)
                                            .Parameters.AddWithValue("@1", txt_januari.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@2", txt_februari.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@3", txt_maret.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@4", txt_april.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@5", txt_mei.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@6", txt_juni.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_juli.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_agustus.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_september.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_oktober.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_november.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", txt_desember.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@13", txt_total.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                MsgBox("Data Angsuran PPh 25 berhasil Di UPDATE")
                            End If
                        Else
                            Using cony As New MySqlConnection(sLocalConn)
                                cony.Open()
                                Dim sqly = "INSERT INTO tbangsuranpph25 (tahun, januari, februari, maret, april, mei, juni, juli, agustus, september, oktober, november, desember, total) VALUES (@tahun,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)"
                                Using cmdy As New MySqlCommand(sqly, cony)
                                    With cmdy
                                        .Parameters.Clear()
                                        .Parameters.AddWithValue("@tahun", selectedYear)
                                        .Parameters.AddWithValue("@1", txt_januari.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@2", txt_februari.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@3", txt_maret.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@4", txt_april.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@5", txt_mei.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@6", txt_juni.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@7", txt_juli.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@8", txt_agustus.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@9", txt_september.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@10", txt_oktober.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@11", txt_november.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@12", txt_desember.Text.Replace(".", "").Replace(",", "."))
                                        .Parameters.AddWithValue("@13", txt_total.Text.Replace(".", "").Replace(",", "."))
                                        .ExecuteNonQuery()
                                    End With
                                End Using
                            End Using
                            MsgBox("Data Angsuran PPh 25 berhasil Di Simpan")
                        End If
                    End Using
                End Using
            End Using
            Call tampil_data()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class