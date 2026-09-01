Imports MySql.Data.MySqlClient

Public Class form_jenis_biaya

    Private Sub form_input_jenis_kain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgv()
        btn_update.Enabled = False
        btn_hapus.Enabled = False
    End Sub

    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).HeaderText = "JENIS BIAYA"
        dgv1.Columns(1).Width = 635
        dgv1.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub isidgv()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id,jenis_biaya FROM tbjenisbiaya ORDER BY jenis_biaya"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbjenisbiaya")
                            dgv1.DataSource = dsx.Tables("tbjenisbiaya")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        Try
            Call isidgv()
            txt_id.Text = ""
            txt_nama.Text = ""
            txt_cari.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseClick
        Try
            Dim i As Integer
            Dim id, nama As String
            i = Me.dgv1.CurrentRow.Index
            With dgv1.Rows.Item(i)
                id = .Cells(0).Value.ToString
                nama = .Cells(1).Value.ToString
            End With
            txt_id.Text = id
            txt_nama.Text = nama
        Catch ex As Exception
            MsgBox("Tidak terdapat data JENIS BIAYA untuk ditampilkan")
        End Try
    End Sub
    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_nama.Text = "" Then
            MsgBox("JENIS BIAYA belum dipilih")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT jenis_biaya FROM tbjenisbiaya WHERE jenis_biaya='" & txt_nama.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If MsgBox("Yakin JENIS BIAYA Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbjenisbiaya WHERE id='" & txt_id.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                        btn_refresh.PerformClick()
                                        MsgBox("JENIS BIAYA berhasil di Hapus")
                                    End Using
                                End If
                            Else
                                MsgBox("JENIS BIAYA belum terdapat di Database")
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txt_nama.Text = "" Then
            MsgBox("JENIS BIAYA Belum Diinput")
            txt_nama.Focus()
        Else
            Try
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbjenisbiaya (jenis_biaya) VALUES (@1)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", txt_nama.Text)
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
                btn_refresh.PerformClick()
                MsgBox("JENIS BIAYA Baru berhasil di Simpan")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If txt_id.Text = "" Then
            MsgBox("JENIS BIAYA Belum Dipilih dari Tabel Data")
        Else
            Try
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "UPDATE tbjenisbiaya SET jenis_biaya=@1 WHERE id = '" & txt_id.Text & "'"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", (txt_nama.Text))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
                btn_refresh.PerformClick()
                MsgBox("JENIS BIAYA berhasil di Update")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub txt_id_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        If txt_id.Text = "" Then
            btn_simpan.Enabled = True
            btn_hapus.Enabled = False
            btn_update.Enabled = False
        Else
            btn_simpan.Enabled = False
            btn_hapus.Enabled = True
            btn_update.Enabled = True
        End If
    End Sub

    Private Sub txt_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cari.TextChanged
        If txt_cari.Text = "" Then
            btn_refresh.PerformClick()
        Else
            Call carijenisbiaya()
        End If
    End Sub
    Private Sub carijenisbiaya()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT id,jenis_biaya FROM tbjenisbiaya WHERE jenis_biaya like '%" & txt_cari.Text & "%' ORDER BY jenis_biaya"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbjenisbiaya")
                            dgv1.DataSource = dsx.Tables("tbjenisbiaya")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '----Batas akhir

    'Private Sub form_input_jenis_kain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    If TxtForm.Text = "form_input_pembelian_grey_baru_1" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_2" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_3" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_4" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_5" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_6" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_7" Or _
    '       TxtForm.Text = "form_input_pembelian_grey_baru_8" Then
    '        form_input_pembelian_grey_baru.Focus()
    '        form_input_pembelian_grey_baru.Label1.Focus()
    '    ElseIf TxtForm.Text = "form_input_kontrak_grey" Then
    '        form_input_kontrak_grey.Focus()
    '        form_input_kontrak_grey.Label1.Focus()
    '    ElseIf TxtForm.Text = "form_input_nama_warna" Then
    '        form_input_jenis_biaya.Focus()
    '        form_input_jenis_biaya.Label1.Focus()
    '    End If
    'End Sub

    'Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
    '    If TxtCari.Text = "" Then
    '        MsgBox("JENIS KAIN belum diinput")
    '    Else
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx = "SELECT Nama_Grey from tbjenisgrey WHERE Nama_Grey ='" & TxtCari.Text & "'"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using drx As MySqlDataReader = cmdx.ExecuteReader
    '                    drx.Read()
    '                    If Not drx.HasRows Then
    '                        If MsgBox("JENIS KAIN belum terdapat di Database, Buat Baru ?", vbYesNo + vbQuestion, "Buat Baru") = vbYes Then
    '                            form_input_nama.MdiParent = form_menu_utama
    '                            form_input_nama.Show()
    '                            form_input_nama.txt_frm.Text = "form_input_jenis_kain"
    '                            form_input_nama.Label1.Text = "Input Jenis Kain Baru"
    '                            form_input_nama.Label2.Text = "Jenis Kain"
    '                            form_input_nama.txt_nama.Text = TxtCari.Text
    '                            form_input_nama.txt_nama.Focus()
    '                            form_input_nama.Focus()
    '                        End If
    '                    Else
    '                        If TxtForm.Text = "form_input_kontrak_grey" Then
    '                            form_input_kontrak_grey.MdiParent = form_menu_utama
    '                            form_input_kontrak_grey.Show()
    '                            form_input_kontrak_grey.txt_jenis_kain.Text = TxtCari.Text
    '                            If form_input_kontrak_grey.Label1.Text = "Ubah Kontrak" Then
    '                                form_input_kontrak_grey.txt_harga.Focus()
    '                            Else
    '                                form_input_kontrak_grey.txt_supplier.Focus()
    '                            End If
    '                            form_input_kontrak_grey.Focus()
    '                            Me.Close()
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_1" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_1.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_1.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_1.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_1.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_2" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_2.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_2.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_2.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_2.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_3" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_3.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_3.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_3.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_3.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_4" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_4.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_4.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_4.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_4.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_5" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_5.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_5.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_5.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_5.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_6" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_6.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_6.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_6.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_6.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_7" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_7.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_7.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_7.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_7.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_pembelian_grey_baru_8" Then
    '                            form_input_pembelian_grey_baru.MdiParent = form_menu_utama
    '                            form_input_pembelian_grey_baru.Show()
    '                            form_input_pembelian_grey_baru.Focus()
    '                            form_input_pembelian_grey_baru.txt_jenis_kain_8.Text = TxtCari.Text
    '                            Me.Close()
    '                            If form_input_pembelian_grey_baru.txt_supplier_8.Text = "" Then
    '                                form_input_pembelian_grey_baru.txt_supplier_8.Focus()
    '                            Else
    '                                form_input_pembelian_grey_baru.txt_harga_8.Focus()
    '                            End If
    '                        ElseIf TxtForm.Text = "form_input_nama_warna" Then
    '                            form_input_jenis_biaya.MdiParent = form_menu_utama
    '                            form_input_jenis_biaya.Show()
    '                            form_input_jenis_biaya.txt_nama_warna.Focus()
    '                            form_input_jenis_biaya.txt_jenis_kain.Text = TxtCari.Text
    '                            Me.Close()
    '                        End If
    '                    End If
    '                End Using
    '            End Using
    '        End Using
    '    End If
    'End Sub
    'Private Sub ts_keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_keluar.Click
    '    If TxtForm.Text = "form_input_kontrak_grey" Then
    '        form_input_kontrak_grey.txt_no_kontrak.Focus()
    '        form_input_kontrak_grey.Focus()
    '        Me.Close()
    '    ElseIf TxtForm.Text = "form_input_pembelian_grey" Then
    '        form_input_pembelian_grey.txt_no_kontrak.Focus()
    '        form_input_pembelian_grey.Focus()
    '        Me.Close()
    '    Else
    '        Me.Close()
    '    End If
    'End Sub

End Class