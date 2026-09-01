Imports MySql.Data.MySqlClient

Public Class form_upah_dan_gaji

    Private Sub form_upah_dan_gaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_spt()
    End Sub

    Private Sub tampil_spt()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim selectedYear As Integer = dtp_tahun.Value.Year
            Dim sqlx As String = "SELECT id,bulan, tahun, upah, gaji " &
                                 "FROM tbupahgaji " &
                                 "WHERE tahun = @selectedYear " &
                                 "ORDER BY FIELD(bulan, 'January', 'February', 'March', 'April', 'May', 'June', " &
                                 "'July', 'August', 'September', 'October', 'November', 'December')"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@selectedYear", selectedYear)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "spt_ppn")
                        dgv1.DataSource = dsx.Tables("spt_ppn")
                        Call headertable()
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(2).Visible = False
        dgv1.Columns(1).HeaderText = "BULAN"
        dgv1.Columns(3).HeaderText = "UPAH"
        dgv1.Columns(4).HeaderText = "GAJI"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(1).Width = 85
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).Width = 130
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
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

    Private Sub txt_nilai_masukan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_upah.LostFocus
        Dim input As String = txt_upah.Text
        Dim number As Decimal
        If Not txt_upah.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_upah.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_upah.Focus()
            End If
        End If
    End Sub
    Private Sub txt_nilai_keluaran_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_gaji.LostFocus
        Dim input As String = txt_gaji.Text
        Dim number As Decimal
        If Not txt_gaji.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_gaji.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_gaji.Focus()
            End If
        End If
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        cbo_bulan.Text = "-- Pilih Bulan --"
        cbo_bulan.Enabled = True
        txt_upah.Text = ""
        txt_gaji.Text = ""
        txt_id.Text = ""
        Call tampil_spt()
        btn_simpan.Text = "SIMPAN"
        btn_hapus.Enabled = False
    End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If cbo_bulan.Text = "-- Pilih Bulan --" Then
                MsgBox("Silahkan Pilih Dahulu Bulan")
            Else
                If btn_simpan.Text = "SIMPAN" Then
                    If txt_upah.Text = "" Then
                        MsgBox("Silakan input UPAH HARIAN terlebih dulu")
                        txt_upah.Focus()
                    ElseIf txt_gaji.Text = "" Then
                        MsgBox("Silakan input GAJI KARYAWAN terlebih dulu")
                        txt_gaji.Focus()
                    Else
                        'Using cony As New MySqlConnection(sLocalConn)
                        '    cony.Open()
                        '    Dim selectedYear As Integer = dtp_tahun.Value.Year
                        '    Dim selectedMonth As String = cbo_bulan.Text
                        '    Dim sqly = "INSERT INTO tbupahgaji (bulan, tahun, upah, gaji) VALUES (@1,@2,@3,@4)"
                        '    Using cmdy As New MySqlCommand(sqly, cony)
                        '        With cmdy
                        '            .Parameters.Clear()
                        '            .Parameters.AddWithValue("@1", selectedMonth)
                        '            .Parameters.AddWithValue("@2", selectedYear)
                        '            .Parameters.AddWithValue("@3", txt_upah.Text.Replace(".", "").Replace(",", "."))
                        '            .Parameters.AddWithValue("@4", txt_gaji.Text.Replace(".", "").Replace(",", "."))
                        '            .ExecuteNonQuery()
                        '        End With
                        '    End Using
                        'End Using
                        'MsgBox("Data Upah dan Gaji berhasil Di Simpan")
                        'btn_refresh.PerformClick()
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim selectedYear As Integer = dtp_tahun.Value.Year
                            Dim selectedMonth As String = cbo_bulan.Text
                            Dim upahDecimal As Decimal = Decimal.Parse(txt_upah.Text)
                            Dim gajiDecimal As Decimal = Decimal.Parse(txt_gaji.Text)

                            ' 1. INSERT ke tbupahgaji
                            Dim sqly = "INSERT INTO tbupahgaji (bulan, tahun, upah, gaji) VALUES (@1,@2,@3,@4)"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                With cmdy
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@1", selectedMonth)
                                    .Parameters.AddWithValue("@2", selectedYear)
                                    .Parameters.AddWithValue("@3", upahDecimal)
                                    .Parameters.AddWithValue("@4", gajiDecimal)
                                    .ExecuteNonQuery()
                                End With
                            End Using

                            ' 2. CEK apakah data tahun sudah ada di tbbiayatahunan
                            Dim checkSql As String = "SELECT COUNT(*) FROM tbbiayatahunan WHERE tahun = @tahun"
                            Dim isExist As Boolean
                            Using cmdCheck As New MySqlCommand(checkSql, cony)
                                cmdCheck.Parameters.AddWithValue("@tahun", selectedYear)
                                isExist = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0
                            End Using

                            ' 3. Jika ADA, maka TAMBAH (UPDATE dengan penjumlahan)
                            If isExist Then
                                Dim updateSql As String = "UPDATE tbbiayatahunan SET upah_harian = upah_harian + @upah, gaji_pegawai = gaji_pegawai + @gaji WHERE tahun = @tahun"
                                Using cmdUpdate As New MySqlCommand(updateSql, cony)
                                    With cmdUpdate
                                        .Parameters.AddWithValue("@upah", upahDecimal)
                                        .Parameters.AddWithValue("@gaji", gajiDecimal)
                                        .Parameters.AddWithValue("@tahun", selectedYear)
                                        .ExecuteNonQuery()
                                    End With
                                End Using
                            Else
                                ' 4. Jika BELUM ADA, maka INSERT awal
                                Dim insertTahunan As String = "INSERT INTO tbbiayatahunan (tahun, upah_harian, gaji_pegawai) VALUES (@tahun, @upah, @gaji)"
                                Using cmdInsertTahunan As New MySqlCommand(insertTahunan, cony)
                                    With cmdInsertTahunan
                                        .Parameters.AddWithValue("@tahun", selectedYear)
                                        .Parameters.AddWithValue("@upah", upahDecimal)
                                        .Parameters.AddWithValue("@gaji", gajiDecimal)
                                        .ExecuteNonQuery()
                                    End With
                                End Using
                            End If
                        End Using

                        MsgBox("Data Upah & Gaji berhasil disimpan dan ditambahkan ke Rekap Tahunan")
                        btn_refresh.PerformClick()

                    End If
                ElseIf btn_simpan.Text = "UPDATE" Then
                    'Using cony As New MySqlConnection(sLocalConn)
                    '    cony.Open()
                    '    Dim id As Integer = txt_id.Text
                    '    Dim sqly = "UPDATE tbupahgaji SET upah=@1, gaji=@2 WHERE id = @id"
                    '    Using cmdy As New MySqlCommand(sqly, cony)
                    '        With cmdy
                    '            .Parameters.Clear()
                    '            .Parameters.AddWithValue("@id", id)
                    '            .Parameters.AddWithValue("@1", txt_upah.Text.Replace(".", "").Replace(",", "."))
                    '            .Parameters.AddWithValue("@2", txt_gaji.Text.Replace(".", "").Replace(",", "."))
                    '            .ExecuteNonQuery()
                    '        End With
                    '    End Using
                    'End Using
                    'MsgBox("Data Upah dan Gaji berhasil Di Update")
                    'btn_refresh.PerformClick()
                    Using conx As New MySqlConnection(sLocalConn)
                        conx.Open()
                        Dim id As Integer = Val(txt_id.Text)

                        ' Ambil data lama sebelum diupdate
                        Dim oldUpah As Decimal = 0
                        Dim oldGaji As Decimal = 0
                        Dim tahun As Integer = 0

                        Dim sqlGet = "SELECT upah, gaji, tahun FROM tbupahgaji WHERE id = @id"
                        Using cmdGet As New MySqlCommand(sqlGet, conx)
                            cmdGet.Parameters.AddWithValue("@id", id)
                            Using dr As MySqlDataReader = cmdGet.ExecuteReader()
                                If dr.Read() Then
                                    oldUpah = Convert.ToDecimal(dr("upah"))
                                    oldGaji = Convert.ToDecimal(dr("gaji"))
                                    tahun = Convert.ToInt32(dr("tahun"))
                                Else
                                    MsgBox("Data tidak ditemukan.")
                                    Exit Sub
                                End If
                            End Using
                        End Using

                        ' Data baru dari TextBox
                        Dim newUpah As Decimal = Decimal.Parse(txt_upah.Text)
                        Dim newGaji As Decimal = Decimal.Parse(txt_gaji.Text)

                        ' Update tbbiayatahunan: kurangi yang lama, tambahkan yang baru
                        Dim sqlUpdateTahunan = "UPDATE tbbiayatahunan " &
                            "SET upah_harian = upah_harian - @oldUpah + @newUpah, " &
                            "gaji_pegawai = gaji_pegawai - @oldGaji + @newGaji " &
                            "WHERE tahun = @tahun"
                        Using cmdUpdateTahunan As New MySqlCommand(sqlUpdateTahunan, conx)
                            cmdUpdateTahunan.Parameters.AddWithValue("@oldUpah", oldUpah)
                            cmdUpdateTahunan.Parameters.AddWithValue("@newUpah", newUpah)
                            cmdUpdateTahunan.Parameters.AddWithValue("@oldGaji", oldGaji)
                            cmdUpdateTahunan.Parameters.AddWithValue("@newGaji", newGaji)
                            cmdUpdateTahunan.Parameters.AddWithValue("@tahun", tahun)
                            cmdUpdateTahunan.ExecuteNonQuery()
                        End Using

                        ' Update tbupahgaji dengan nilai baru
                        Dim sqlUpdate = "UPDATE tbupahgaji SET upah = @upah, gaji = @gaji WHERE id = @id"
                        Using cmdUpdate As New MySqlCommand(sqlUpdate, conx)
                            cmdUpdate.Parameters.AddWithValue("@id", id)
                            cmdUpdate.Parameters.AddWithValue("@upah", newUpah)
                            cmdUpdate.Parameters.AddWithValue("@gaji", newGaji)
                            cmdUpdate.ExecuteNonQuery()
                        End Using
                    End Using

                    MsgBox("Data Upah dan Gaji berhasil diupdate")
                    btn_refresh.PerformClick()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        Try
            'Using conx As New MySqlConnection(sLocalConn)
            '    conx.Open()
            '    Dim sqlx = "SELECT bulan, tahun, upah, gaji FROM tbupahgaji WHERE id='" & txt_id.Text & "'"
            '    Using cmdx As New MySqlCommand(sqlx, conx)
            '        Using drx As MySqlDataReader = cmdx.ExecuteReader
            '            drx.Read()
            '            If drx.HasRows Then
            '                If MsgBox("Yakin Data SPT Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
            '                    Using cony As New MySqlConnection(sLocalConn)
            '                        cony.Open()
            '                        Dim sqly = "DELETE FROM tbupahgaji WHERE id='" & txt_id.Text & "'"
            '                        Using cmdy As New MySqlCommand(sqly, cony)
            '                            cmdy.ExecuteNonQuery()
            '                        End Using
            '                        btn_refresh.PerformClick()
            '                        MsgBox("Data Upah dan Gaji berhasil di Hapus")
            '                    End Using
            '                End If
            '            Else
            '                MsgBox("Data Upah dan Gaji belum terdapat di Database")
            '            End If
            '        End Using
            '    End Using
            'End Using
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT bulan, tahun, upah, gaji FROM tbupahgaji WHERE id = @id"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    cmdx.Parameters.AddWithValue("@id", txt_id.Text)

                    Using drx As MySqlDataReader = cmdx.ExecuteReader()
                        If drx.Read() Then
                            If MsgBox("Yakin Data Upah dan Gaji Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                Dim tahun As Integer = Convert.ToInt32(drx("tahun"))
                                Dim upah As Decimal = Convert.ToDecimal(drx("upah"))
                                Dim gaji As Decimal = Convert.ToDecimal(drx("gaji"))

                                drx.Close() ' Tutup reader sebelum pakai koneksi lagi

                                ' Koneksi baru untuk UPDATE dan DELETE
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()

                                    ' Kurangi dari tbbiayatahunan
                                    Dim sqlUpdate = "UPDATE tbbiayatahunan SET upah_harian = upah_harian - @upah, " &
                                        "gaji_pegawai = gaji_pegawai - @gaji " &
                                        "WHERE tahun = @tahun"
                                    Using cmdUpdate As New MySqlCommand(sqlUpdate, cony)
                                        cmdUpdate.Parameters.AddWithValue("@upah", upah)
                                        cmdUpdate.Parameters.AddWithValue("@gaji", gaji)
                                        cmdUpdate.Parameters.AddWithValue("@tahun", tahun)
                                        cmdUpdate.ExecuteNonQuery()
                                    End Using

                                    ' Hapus dari tbupahgaji
                                    Dim sqly = "DELETE FROM tbupahgaji WHERE id = @id"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.Parameters.AddWithValue("@id", txt_id.Text)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using

                                btn_refresh.PerformClick()
                                MsgBox("Data Upah dan Gaji berhasil dihapus dan dikurangi dari total tahunan.")
                            End If
                        Else
                            MsgBox("Data Upah dan Gaji belum terdapat di Database")
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbo_bulan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_bulan.KeyPress
        e.Handled = True
    End Sub
    Private Sub cbo_bulan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_bulan.SelectedIndexChanged
        If cbo_bulan.Text <> "-- Pilih Bulan -- " Then
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim selectedYear As Integer = dtp_tahun.Value.Year
                Dim selectedMonth As String = cbo_bulan.Text
                Dim sqly As String = "SELECT id, bulan, tahun, upah, gaji " &
                                 "FROM tbupahgaji " &
                                 "WHERE tahun = @selectedYear AND bulan = @selectedMonth "
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.Parameters.AddWithValue("@selectedYear", selectedYear)
                    cmdy.Parameters.AddWithValue("@selectedMonth", selectedMonth)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            txt_id.Text = dry(0).ToString
                            txt_upah.Text = Convert.ToDecimal(dry(3)).ToString("#,##0.00########")
                            txt_gaji.Text = Convert.ToDecimal(dry(4)).ToString("#,##0.00########")
                            btn_simpan.Text = "UPDATE"
                            btn_hapus.Enabled = True
                        Else
                            If btn_simpan.Text = "SIMPAN" Then
                                txt_id.Text = ""
                                btn_simpan.Text = "SIMPAN"
                                btn_hapus.Enabled = False
                            Else
                                txt_upah.Text = ""
                                txt_gaji.Text = ""
                                txt_id.Text = ""
                                btn_simpan.Text = "SIMPAN"
                                btn_hapus.Enabled = False
                            End If
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub
    Private Sub dtp_tahun_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_tahun.ValueChanged
        btn_refresh.PerformClick()
    End Sub

    
End Class