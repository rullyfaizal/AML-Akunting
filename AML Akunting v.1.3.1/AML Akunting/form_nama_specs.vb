Imports MySql.Data.MySqlClient

Public Class form_nama_specs

    Private Sub form_nama_specs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgv()
        btn_update.Enabled = False
        btn_hapus.Enabled = False
    End Sub

    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).HeaderText = "NAMA / SPECS"
        dgv1.Columns(1).Width = 635
        dgv1.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub isidgv()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id,nama_specs FROM tbnamaspecs ORDER BY nama_specs"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbnamaspecs")
                            dgv1.DataSource = dsx.Tables("tbnamaspecs")
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
            MsgBox("Tidak terdapat data Nama / Specs untuk ditampilkan")
        End Try
    End Sub
    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_nama.Text = "" Then
            MsgBox("Nama / Specs belum dipilih")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama_specs FROM tbnamaspecs WHERE nama_specs='" & txt_nama.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If MsgBox("Yakin Nama / Specs Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbnamaspecs WHERE id='" & txt_id.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                        btn_refresh.PerformClick()
                                        MsgBox("Nama / Specs berhasil di Hapus")
                                    End Using
                                End If
                            Else
                                MsgBox("Nama / Specs belum terdapat di Database")
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
            MsgBox("Nama / Specs Belum Diinput")
            txt_nama.Focus()
        Else
            Try
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbnamaspecs (nama_specs) VALUES (@1)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", txt_nama.Text)
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
                btn_refresh.PerformClick()
                MsgBox("Nama / Specs Baru berhasil di Simpan")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If txt_id.Text = "" Then
            MsgBox("Nama / Specs Belum Dipilih dari Tabel Data")
        Else
            Try
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "UPDATE tbnamaspecs SET nama_specs=@1 WHERE id = '" & txt_id.Text & "'"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            .Parameters.Clear()
                            .Parameters.AddWithValue("@1", (txt_nama.Text))
                            .ExecuteNonQuery()
                        End With
                    End Using
                End Using
                btn_refresh.PerformClick()
                MsgBox("Nama / Specs berhasil di Update")
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

    Private Sub cari_nama_specs()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT id,nama_specs FROM tbnamaspecs WHERE nama_specs like '%" & txt_cari.Text & "%' ORDER BY nama_specs"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbnamaspecs")
                            Dgv1.DataSource = dsx.Tables("tbnamaspecs")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cari.TextChanged
        If txt_cari.Text = "" Then
            btn_refresh.PerformClick()
        Else
            Call cari_nama_specs()
        End If
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Try
            If txt_form.Text = "specs ppn 1" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs1.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah1.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 2" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs2.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah2.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 3" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs3.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah3.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 4" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs4.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah4.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 5" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs5.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah5.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 6" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs6.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah6.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 7" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs7.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah7.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 8" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs8.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah8.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 9" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs9.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah9.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs ppn 10" Then
                form_input_pembelian_baru.Show()
                form_input_pembelian_baru.txt_specs10.Text = txt_nama.Text
                Me.Close()
                form_input_pembelian_baru.txt_jumlah10.Focus()
                form_input_pembelian_baru.Focus()
            ElseIf txt_form.Text = "specs edit 1" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs1.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah1.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 2" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs2.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah2.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 3" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs3.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah3.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 4" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs4.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah4.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 5" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs5.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah5.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 6" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs6.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah6.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 7" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs7.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah7.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 8" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs8.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah8.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 9" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs9.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah9.Focus()
                form_edit_pembelian.Focus()
            ElseIf txt_form.Text = "specs edit 10" Then
                form_edit_pembelian.Show()
                form_edit_pembelian.txt_specs10.Text = txt_nama.Text
                Me.Close()
                form_edit_pembelian.txt_jumlah10.Focus()
                form_edit_pembelian.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class