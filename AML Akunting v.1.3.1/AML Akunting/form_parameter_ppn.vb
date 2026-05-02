Imports MySql.Data.MySqlClient

Public Class form_parameter_ppn

    Private Sub form_parameter_ppn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_ppn()
        lbl_panjang_fp.Text = My.Settings.panjangfp
        lbl_npwp.Text = My.Settings.npwpartha
    End Sub

    Private Sub tampil_ppn()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT ppn,pph23,pph22 FROM tbppn WHERE id='ppn'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using reader As MySqlDataReader = cmdx.ExecuteReader()
                        If reader.Read() Then
                            lbl_ppn.Text = Format(CDec(reader("ppn")), "#,##0.##") & " %"
                            ''lbl_ppn.Text = reader("ppn").ToString().Replace(".", ",") & " %"
                            lbl_pph.Text = Format(CDec(reader("pph23")), "#,##0.##") & " %"
                            lbl_pph22.Text = Format(CDec(reader("pph22")), "#,##0.##") & " %"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_ppn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ppn.KeyPress, txt_pph23.KeyPress, txt_pph22.KeyPress
        ' Cek jika karakter yang dimasukkan bukan digit, kontrol, atau koma
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "," Then
            e.Handled = True
        ElseIf e.KeyChar = "," Then
            ' Cegah koma jika sudah ada koma sebelumnya atau tidak ada angka di depan
            If CType(sender, TextBox).Text.Contains(",") OrElse CType(sender, TextBox).Text.Length = 0 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_ppn.LostFocus, txt_pph23.LostFocus, txt_pph22.LostFocus
        Dim txtBox As TextBox = CType(sender, TextBox)
        ' Periksa apakah teks mengandung koma tanpa angka di belakang
        If txtBox.Text.Contains(",") Then
            Dim parts() As String = txtBox.Text.Split(","c) ' Pisahkan teks berdasarkan koma
            If parts.Length = 2 AndAlso parts(1).Trim() = "" Then
                ' Jika tidak ada angka di belakang koma
                MessageBox.Show("Harap masukkan angka di belakang koma.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBox.Focus() ' Kembalikan fokus ke TextBox
            End If
        End If
    End Sub

    Private Sub BtnGanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGanti.Click
        'If txt_pph23.Text = "" And txt_ppn.Text = "" Then
        '    MsgBox("Nilai PPN atau PPh 23 belum diinput")
        '    txt_ppn.Focus()
        'ElseIf txt_pph23.Text = "" And Not txt_ppn.Text = "" Then
        '    Call update_ppn()
        '    Call tampil_ppn()
        '    txt_ppn.Text = ""
        '    txt_pph23.Text = ""
        'ElseIf txt_ppn.Text = "" And Not txt_pph23.Text = "" Then
        '    Call update_pph23()
        '    Call tampil_ppn()
        '    txt_ppn.Text = ""
        '    txt_pph23.Text = ""
        'ElseIf Not txt_ppn.Text = "" And Not txt_pph23.Text = "" Then
        '    Call update_ppn_pph23()
        '    Call tampil_ppn()
        '    txt_ppn.Text = ""
        '    txt_pph23.Text = ""
        'End If

        If txt_pph23.Text = "" And txt_ppn.Text = "" And txt_pph22.Text = "" Then
            MsgBox("Nilai PPN atau PPh 23 atau PPh 22 belum diinput")
            Exit Sub
        End If
        If txt_ppn.Text <> "" Then
            Call update_ppn()
        End If
        If txt_pph23.Text <> "" Then
            Call update_pph23()
        End If
        If txt_pph22.Text <> "" Then
            Call update_pph22()
        End If
        MsgBox("Nilai PPN / PPh Berhasil Diubah")
        Call tampil_ppn()
        txt_ppn.Text = ""
        txt_pph23.Text = ""
        txt_pph22.Text = ""
    End Sub

    Private Sub update_ppn()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbppn SET ppn=@1 WHERE id='ppn'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_ppn.Text.Replace(",", "."))
                    .ExecuteNonQuery()
                End With
                'MsgBox("Nilai PPN Berhasil Diubah")
                'form_jenis_biaya.Focus()
            End Using
        End Using
    End Sub
    Private Sub update_pph23()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbppn SET pph23=@1 WHERE id='ppn'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_pph23.Text.Replace(",", "."))
                    .ExecuteNonQuery()
                End With
                'MsgBox("Nilai PPh 22 Berhasil Diubah")
                'form_jenis_biaya.Focus()
            End Using
        End Using
    End Sub
    Private Sub update_pph22()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbppn SET pph22=@1 WHERE id='ppn'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", txt_pph22.Text.Replace(",", "."))
                    .ExecuteNonQuery()
                End With
                'MsgBox("Nilai PPh 23 Berhasil Diubah")
                'form_jenis_biaya.Focus()
            End Using
        End Using
    End Sub

    Private Sub update_ppn_pph23()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "UPDATE tbppn SET ppn=@1,pph23=@2 WHERE id='ppn'"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", (txt_ppn.Text))
                    .Parameters.AddWithValue("@2", (txt_pph23.Text))
                    .ExecuteNonQuery()
                End With
                MsgBox("Nilai PPN dan PPh 23 Berhasil Diubah")
                form_jenis_biaya.Focus()
            End Using
        End Using
    End Sub

    Private Sub txt_panjang_fp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_panjang_fp.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_ganti_panjangfp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ganti_panjangfp.Click
        If txt_panjang_fp.Text = "" Then
            MsgBox("Parameter Panjang Karakter FP belum diinput")
            txt_panjang_fp.Focus()
        ElseIf txt_panjang_fp.Text = 0 Then
            MsgBox("Parameter Panjang Karakter FP Tidak boleh nol")
            txt_panjang_fp.Focus()
        ElseIf My.Settings.panjangfp = txt_panjang_fp.Text Then
            MsgBox("Parameter Panjang Karakter FP sama dengan sebelumnya")
            txt_panjang_fp.Focus()
        Else
            My.Settings.panjangfp = txt_panjang_fp.Text
            My.Settings.Save()
            MessageBox.Show("Parameter Panjang Karakter FP berhasil diubah")
            txt_panjang_fp.Text = ""
            lbl_panjang_fp.Text = My.Settings.panjangfp
        End If
    End Sub

    Private Sub btn_ganti_npwp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ganti_npwp.Click
        If txt_npwp.Text = "" Then
            MsgBox("Parameter NPWP belum diinput")
            txt_npwp.Focus()
        ElseIf My.Settings.npwpartha = txt_npwp.Text Then
            MsgBox("Parameter NPWP sama dengan sebelumnya")
            txt_npwp.Focus()
        Else
            My.Settings.npwpartha = txt_npwp.Text
            My.Settings.Save()
            MessageBox.Show("Parameter NPWP berhasil diubah")
            txt_npwp.Text = ""
            lbl_npwp.Text = My.Settings.npwpartha
        End If
    End Sub
End Class