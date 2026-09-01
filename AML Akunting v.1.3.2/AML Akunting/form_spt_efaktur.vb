Imports MySql.Data.MySqlClient

Public Class form_spt_efaktur

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
    Private Sub form_spt_efaktur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_spt()
        Call isi_ppn()
    End Sub
    Private Sub tampil_spt()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim selectedYear As Integer = dtp_tahun.Value.Year
            Dim sqlx As String = "SELECT id,bulan, tahun, nilai_masukan, nilai_keluaran, ppn_masukan, ppn_keluaran, ppn_disetor " &
                                 "FROM tbsptppn " &
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
        dgv1.Columns(3).HeaderText = "NILAI MASUKAN"
        dgv1.Columns(4).HeaderText = "NILAI KELUARAN"
        dgv1.Columns(5).HeaderText = "PPN MASUKAN"
        dgv1.Columns(6).HeaderText = "PPN KELUARAN"
        dgv1.Columns(7).HeaderText = "PPN DISETOR"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(1).Width = 85
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).Width = 130
        dgv1.Columns(5).Width = 120
        dgv1.Columns(6).Width = 120
        dgv1.Columns(7).Width = 115
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
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

    Private Sub txt_nilai_keluaran_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nilai_keluaran.LostFocus
        Dim input As String = txt_nilai_keluaran.Text
        Dim number As Decimal
        If Not txt_nilai_keluaran.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_nilai_keluaran.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_nilai_keluaran.Focus()
            End If
        End If
    End Sub
    Private Sub txt_nilai_masukan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nilai_masukan.LostFocus
        Dim input As String = txt_nilai_masukan.Text
        Dim number As Decimal
        If Not txt_nilai_masukan.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_nilai_masukan.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_nilai_masukan.Focus()
            End If
        End If
    End Sub
    Private Sub txt_ppn_keluaran_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ppn_keluaran.LostFocus
        Dim input As String = txt_ppn_keluaran.Text
        Dim number As Decimal
        If Not txt_ppn_keluaran.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_ppn_keluaran.Text = number.ToString("#,##0.00########")
                Call hitung_disetor()
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_ppn_keluaran.Focus()
            End If
        End If
    End Sub
    Private Sub txt_ppn_masukan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ppn_masukan.LostFocus
        Dim input As String = txt_ppn_masukan.Text
        Dim number As Decimal
        If Not txt_ppn_masukan.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_ppn_masukan.Text = number.ToString("#,##0.00########")
                Call hitung_disetor()
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_ppn_masukan.Focus()
            End If
        End If
    End Sub
    Private Sub hitung_disetor()
        If txt_ppn_masukan.Text = "" And txt_ppn_keluaran.Text <> "" Then
            txt_ppn_disetor.Text = ""
        ElseIf txt_ppn_masukan.Text <> "" And txt_ppn_keluaran.Text = "" Then
            txt_ppn_disetor.Text = ""
        ElseIf txt_ppn_keluaran.Text <> "" And txt_ppn_masukan.Text <> "" Then
            Dim ppnkeluar, ppnmasuk, ppndisetor As Decimal
            Decimal.TryParse(txt_ppn_masukan.Text, ppnmasuk)
            Decimal.TryParse(txt_ppn_keluaran.Text, ppnkeluar)
            ppndisetor = ppnkeluar - ppnmasuk
            txt_ppn_masukan.Text = ppnmasuk.ToString("#,##0.00########")
            txt_ppn_keluaran.Text = ppnkeluar.ToString("#,##0.00########")
            txt_ppn_disetor.Text = ppndisetor.ToString("#,##0.00########")
        Else
            txt_ppn_disetor.Text = ""
        End If
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        cbo_bulan.Text = "-- Pilih Bulan --"
        cbo_bulan.Enabled = True
        txt_nilai_keluaran.Text = ""
        txt_nilai_masukan.Text = ""
        txt_ppn_disetor.Text = ""
        txt_ppn_keluaran.Text = ""
        txt_ppn_masukan.Text = ""
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
                    If txt_nilai_masukan.Text = "" Then
                        MsgBox("Silakan input nilai masukan terlebih dulu")
                        txt_nilai_masukan.Focus()
                    ElseIf txt_nilai_keluaran.Text = "" Then
                        MsgBox("Silakan input nilai keluaran terlebih dulu")
                        txt_nilai_keluaran.Focus()
                    ElseIf txt_ppn_masukan.Text = "" Then
                        MsgBox("Silakan input ppn masukan terlebih dulu")
                        txt_ppn_masukan.Focus()
                    ElseIf txt_ppn_keluaran.Text = "" Then
                        MsgBox("Silakan input ppn keluaran terlebih dulu")
                        txt_ppn_keluaran.Focus()
                    Else
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim selectedYear As Integer = dtp_tahun.Value.Year
                            Dim selectedMonth As String = cbo_bulan.Text
                            Dim sqly = "INSERT INTO tbsptppn (bulan, tahun, nilai_masukan, nilai_keluaran, ppn_masukan, ppn_keluaran, ppn_disetor) VALUES (@1,@2,@3,@4,@5,@6,@7)"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                With cmdy
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@1", selectedMonth)
                                    .Parameters.AddWithValue("@2", selectedYear)
                                    .Parameters.AddWithValue("@3", txt_nilai_masukan.Text.Replace(".", "").Replace(",", "."))
                                    .Parameters.AddWithValue("@4", txt_nilai_keluaran.Text.Replace(".", "").Replace(",", "."))
                                    .Parameters.AddWithValue("@5", txt_ppn_masukan.Text.Replace(".", "").Replace(",", "."))
                                    .Parameters.AddWithValue("@6", txt_ppn_keluaran.Text.Replace(".", "").Replace(",", "."))
                                    .Parameters.AddWithValue("@7", txt_ppn_disetor.Text.Replace(".", "").Replace(",", "."))
                                    .ExecuteNonQuery()
                                End With
                            End Using
                        End Using
                        MsgBox("Data SPT berhasil Di Simpan")
                        btn_refresh.PerformClick()
                    End If
                ElseIf btn_simpan.Text = "UPDATE" Then
                    Using cony As New MySqlConnection(sLocalConn)
                        cony.Open()
                        Dim id As Integer = txt_id.Text
                        Dim sqly = "UPDATE tbsptppn SET nilai_masukan=@1, nilai_keluaran=@2, ppn_masukan=@3, ppn_keluaran=@4, ppn_disetor=@5 WHERE id = @id"
                        Using cmdy As New MySqlCommand(sqly, cony)
                            With cmdy
                                .Parameters.Clear()
                                .Parameters.AddWithValue("@id", id)
                                .Parameters.AddWithValue("@1", txt_nilai_masukan.Text.Replace(".", "").Replace(",", "."))
                                .Parameters.AddWithValue("@2", txt_nilai_keluaran.Text.Replace(".", "").Replace(",", "."))
                                .Parameters.AddWithValue("@3", txt_ppn_masukan.Text.Replace(".", "").Replace(",", "."))
                                .Parameters.AddWithValue("@4", txt_ppn_keluaran.Text.Replace(".", "").Replace(",", "."))
                                .Parameters.AddWithValue("@5", txt_ppn_disetor.Text.Replace(".", "").Replace(",", "."))
                                .ExecuteNonQuery()
                            End With
                        End Using
                    End Using
                    MsgBox("Data SPT berhasil Di Update")
                    btn_refresh.PerformClick()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT bulan, tahun, nilai_masukan, nilai_keluaran, ppn_masukan, ppn_keluaran, ppn_disetor FROM tbsptppn WHERE id='" & txt_id.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            If MsgBox("Yakin Data SPT Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "DELETE FROM tbsptppn WHERE id='" & txt_id.Text & "'"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                    btn_refresh.PerformClick()
                                    MsgBox("Data SPT berhasil di Hapus")
                                End Using
                            End If
                        Else
                            MsgBox("Data SPT belum terdapat di Database")
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
                Dim sqly As String = "SELECT id, bulan, tahun, nilai_masukan, nilai_keluaran, ppn_masukan, ppn_keluaran, ppn_disetor " &
                                 "FROM tbsptppn " &
                                 "WHERE tahun = @selectedYear AND bulan = @selectedMonth "
                Using cmdy As New MySqlCommand(sqly, cony)
                    cmdy.Parameters.AddWithValue("@selectedYear", selectedYear)
                    cmdy.Parameters.AddWithValue("@selectedMonth", selectedMonth)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            txt_id.Text = dry(0).ToString
                            txt_nilai_masukan.Text = Convert.ToDecimal(dry(3)).ToString("#,##0.00########")
                            txt_nilai_keluaran.Text = Convert.ToDecimal(dry(4)).ToString("#,##0.00########")
                            txt_ppn_masukan.Text = Convert.ToDecimal(dry(5)).ToString("#,##0.00########")
                            txt_ppn_keluaran.Text = Convert.ToDecimal(dry(6)).ToString("#,##0.00########")
                            txt_ppn_disetor.Text = Convert.ToDecimal(dry(7)).ToString("#,##0.00########")
                            btn_simpan.Text = "UPDATE"
                            btn_hapus.Enabled = True
                        Else
                            If btn_simpan.Text = "SIMPAN" Then
                                txt_id.Text = ""
                                btn_simpan.Text = "SIMPAN"
                                btn_hapus.Enabled = False
                            Else
                                txt_nilai_keluaran.Text = ""
                                txt_nilai_masukan.Text = ""
                                txt_ppn_disetor.Text = ""
                                txt_ppn_keluaran.Text = ""
                                txt_ppn_masukan.Text = ""
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
    Private Sub dtp_tahun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tahun.ValueChanged
        btn_refresh.PerformClick()
    End Sub

End Class