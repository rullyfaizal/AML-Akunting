Imports MySql.Data.MySqlClient

Public Class form_client
    Private Sub form_client_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgv()
        btn_update.Enabled = False
        btn_hapus.Enabled = False
        txt_supplier.Focus()
    End Sub
    Private Sub isidgv()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbclient ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv1.DataSource = dsx.Tables("tbclient")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).HeaderText = "NAMA"
        dgv1.Columns(2).HeaderText = "ALIAS CELUP"
        dgv1.Columns(3).HeaderText = "ALIAS KAIN"
        dgv1.Columns(4).HeaderText = "ALAMAT"
        dgv1.Columns(5).HeaderText = "KOTA"
        dgv1.Columns(6).HeaderText = "TELEPON"
        dgv1.Columns(7).HeaderText = "NPWP"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        'dgv1.Columns(1).Width = 120
        dgv1.Columns(2).Width = 120
        dgv1.Columns(3).Width = 120
        dgv1.Columns(4).Width = 180
        'dgv1.Columns(5).Width = 150
        'dgv1.Columns(6).Width = 120
        'dgv1.Columns(7).Width = 170
    End Sub

    Private Sub txt_npwp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_npwp.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'Dim cursorPosition As Integer = txt_npwp.SelectionStart

        'If txt_npwp.Text.Length >= 20 AndAlso Not Char.IsControl(e.KeyChar) Then
        '    e.Handled = True
        '    Return
        'End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 1, 5, 9, 15
        '            txt_npwp.Text = txt_npwp.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 11
        '            txt_npwp.Text = txt_npwp.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_npwp.Text = txt_npwp.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_npwp.SelectionStart = cursorPosition
        'End If
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        Try
            Call isidgv()
            txt_id.Text = ""
            txt_supplier.Text = ""
            txt_supplier_asal.Text = ""
            txt_alias_celup.Text = ""
            txt_alias_celup_asal.Text = ""
            txt_alias_kain.Text = ""
            txt_alias_kain_asal.Text = ""
            txt_alamat.Text = ""
            txt_kota.Text = ""
            txt_telp.Text = ""
            txt_npwp.Text = ""
            txt_cari.Text = ""
            'txt_supplier.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txt_supplier.Text = "" Then
            MsgBox("Nama CLIENT Belum Diinput")
            txt_supplier.Focus()
            'ElseIf txt_alias_celup.Text = "" Then
            '    MsgBox("Nama ALIAS CELUP Belum Diinput")
            '    txt_alias_celup.Focus()
            'ElseIf txt_alias_kain.Text = "" Then
            '    MsgBox("Nama ALIAS KAIN Belum Diinput")
            '    txt_alias_kain.Focus()
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbclient WHERE nama='" & txt_supplier.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                MessageBox.Show("Nama CLIENT yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txt_supplier.Focus()
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbclient (nama,alias_celup,alias_kain,alamat,kota,telepon,npwp) VALUES (@1,@2,@3,@4,@5,@6,@7)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .Parameters.AddWithValue("@2", (txt_alias_celup.Text))
                                            .Parameters.AddWithValue("@3", (txt_alias_kain.Text))
                                            .Parameters.AddWithValue("@4", (txt_alamat.Text))
                                            .Parameters.AddWithValue("@5", (txt_kota.Text))
                                            .Parameters.AddWithValue("@6", (txt_telp.Text))
                                            .Parameters.AddWithValue("@7", (txt_npwp.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                btn_refresh.PerformClick()
                                MessageBox.Show("CLIENT Baru berhasil di Simpan", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)



                                'Using conz As New MySqlConnection(sLocalConn)
                                '    conz.Open()
                                '    Dim sqlz = "SELECT alias_celup FROM tbclient WHERE alias_celup='" & txt_alias_celup.Text & "'"
                                '    Using cmdz As New MySqlCommand(sqlz, conz)
                                '        Using drz As MySqlDataReader = cmdz.ExecuteReader
                                '            drz.Read()
                                '            If drz.HasRows Then
                                '                MessageBox.Show("ALIAS CELUP yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '                txt_alias_celup.Focus()
                                '            Else
                                '                Using cona As New MySqlConnection(sLocalConn)
                                '                    cona.Open()
                                '                    Dim sqla = "SELECT alias_kain FROM tbclient WHERE alias_kain='" & txt_alias_kain.Text & "'"
                                '                    Using cmda As New MySqlCommand(sqla, cona)
                                '                        Using dra As MySqlDataReader = cmda.ExecuteReader
                                '                            dra.Read()
                                '                            If dra.HasRows Then
                                '                                MessageBox.Show("ALIAS KAIN yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '                                txt_alias_kain.Focus()
                                '                            Else
                                '                                Using cony As New MySqlConnection(sLocalConn)
                                '                                    cony.Open()
                                '                                    Dim sqly = "INSERT INTO tbclient (nama,alias_celup,alias_kain,alamat,kota,telepon,npwp) VALUES (@1,@2,@3,@4,@5,@6,@7)"
                                '                                    Using cmdy As New MySqlCommand(sqly, cony)
                                '                                        With cmdy
                                '                                            .Parameters.Clear()
                                '                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                '                                            .Parameters.AddWithValue("@2", (txt_alias_celup.Text))
                                '                                            .Parameters.AddWithValue("@3", (txt_alias_kain.Text))
                                '                                            .Parameters.AddWithValue("@4", (txt_alamat.Text))
                                '                                            .Parameters.AddWithValue("@5", (txt_kota.Text))
                                '                                            .Parameters.AddWithValue("@6", (txt_telp.Text))
                                '                                            .Parameters.AddWithValue("@7", (txt_npwp.Text))
                                '                                            .ExecuteNonQuery()
                                '                                        End With
                                '                                    End Using
                                '                                End Using
                                '                                btn_refresh.PerformClick()
                                '                                MessageBox.Show("CLIENT Baru berhasil di Simpan", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                '                            End If
                                '                        End Using
                                '                    End Using
                                '                End Using
                                '            End If
                                '        End Using
                                '    End Using
                                'End Using
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub dgv1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Try
                Dim i As Integer
                Dim id, nama, namacelup, namakain, alamat, kota, telepon, npwp As String
                i = Me.dgv1.CurrentRow.Index
                With dgv1.Rows.Item(i)
                    id = .Cells(0).Value.ToString
                    nama = .Cells(1).Value.ToString
                    namacelup = .Cells(2).Value.ToString
                    namakain = .Cells(3).Value.ToString
                    alamat = .Cells(4).Value.ToString
                    kota = .Cells(5).Value.ToString
                    telepon = .Cells(6).Value.ToString
                    npwp = .Cells(7).Value.ToString
                End With
                txt_id.Text = id
                txt_supplier.Text = nama
                txt_supplier_asal.Text = nama
                txt_alias_celup.Text = namacelup
                txt_alias_celup_asal.Text = namacelup
                txt_alias_kain.Text = namakain
                txt_alias_kain_asal.Text = namakain
                txt_alamat.Text = alamat
                txt_kota.Text = kota
                txt_telp.Text = telepon
                txt_npwp.Text = npwp
            Catch ex As Exception
                MsgBox("Tidak terdapat data CLIENT untuk ditampilkan")
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

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_supplier.Text = "" Then
            MsgBox("NAMA CLIENT Belum Dipilih")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbclient WHERE nama='" & txt_supplier.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If MsgBox("Yakin CLIENT Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbclient WHERE id='" & txt_id.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                        btn_refresh.PerformClick()
                                        MsgBox("CLIENT berhasil di Hapus")
                                    End Using
                                End If
                            Else
                                MsgBox("CLIENT belum terdapat di Database")
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txt_telp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_telp.LostFocus
        If Not txt_telp.Text = "" Then
            Dim input As String = txt_telp.Text
            Dim regex As New System.Text.RegularExpressions.Regex("^\d+$")

            If Not regex.IsMatch(input) Then
                MessageBox.Show("No Telepon hanya bisa diinput dengan angka", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_telp.Focus()
            End If
        End If
    End Sub

    Private Sub cari_supplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT * FROM tbclient WHERE nama like '%" & txt_cari.Text & "%' OR alias_celup like '%" & txt_cari.Text & "%' OR alias_kain like '%" & txt_cari.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv1.DataSource = dsx.Tables("tbclient")
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
            Call cari_supplier()
        End If
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If txt_id.Text = "" Then
            MsgBox("CLIENT Belum Dipilih dari Tabel Data")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbclient WHERE nama='" & txt_supplier.Text & "' AND nama<>'" & txt_supplier_asal.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                MessageBox.Show("Nama CLIENT yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txt_supplier.Focus()
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbclient SET nama=@1,alias_celup=@2,alias_kain=@3,alamat=@4,kota=@5,telepon=@6,npwp=@7 WHERE id = '" & txt_id.Text & "'"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .Parameters.AddWithValue("@2", (txt_alias_celup.Text))
                                            .Parameters.AddWithValue("@3", (txt_alias_kain.Text))
                                            .Parameters.AddWithValue("@4", (txt_alamat.Text))
                                            .Parameters.AddWithValue("@5", (txt_kota.Text))
                                            .Parameters.AddWithValue("@6", (txt_telp.Text))
                                            .Parameters.AddWithValue("@7", (txt_npwp.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbpenjualan SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbomset SET client=@1 WHERE client = '" & txt_supplier_asal.Text & "'"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly As String = "UPDATE tbpenjualan p " &
                                                         "JOIN tbclient c ON p.supplier = c.nama " &
                                                         "SET p.npwp = c.npwp " &
                                                         "WHERE p.supplier = @supplier"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.Parameters.AddWithValue("@supplier", txt_supplier.Text)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using


                                btn_refresh.PerformClick()
                                MessageBox.Show("CLIENT berhasil di Update", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                'Using conz As New MySqlConnection(sLocalConn)
                                '    conz.Open()
                                '    Dim sqlz = "SELECT alias_celup FROM tbclient WHERE alias_celup='" & txt_alias_celup.Text & "' AND alias_celup<>'" & txt_alias_celup_asal.Text & "'"
                                '    Using cmdz As New MySqlCommand(sqlz, conz)
                                '        Using drz As MySqlDataReader = cmdz.ExecuteReader
                                '            drz.Read()
                                '            If drz.HasRows Then
                                '                MessageBox.Show("ALIAS CELUP yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '                txt_alias_celup.Focus()
                                '            Else
                                '                Using cona As New MySqlConnection(sLocalConn)
                                '                    cona.Open()
                                '                    Dim sqla = "SELECT alias_kain FROM tbclient WHERE alias_kain='" & txt_alias_kain.Text & "' AND alias_kain<>'" & txt_alias_kain_asal.Text & "'"
                                '                    Using cmda As New MySqlCommand(sqla, cona)
                                '                        Using dra As MySqlDataReader = cmda.ExecuteReader
                                '                            dra.Read()
                                '                            If dra.HasRows Then
                                '                                MessageBox.Show("ALIAS KAIN yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '                                txt_alias_kain.Focus()
                                '                            Else
                                '                                Using cony As New MySqlConnection(sLocalConn)
                                '                                    cony.Open()
                                '                                    Dim sqly = "UPDATE tbclient SET nama=@1,alias_celup=@2,alias_kain=@3,alamat=@4,kota=@5,telepon=@6,npwp=@7 WHERE id = '" & txt_id.Text & "'"
                                '                                    Using cmdy As New MySqlCommand(sqly, cony)
                                '                                        With cmdy
                                '                                            .Parameters.Clear()
                                '                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                '                                            .Parameters.AddWithValue("@2", (txt_alias_celup.Text))
                                '                                            .Parameters.AddWithValue("@3", (txt_alias_kain.Text))
                                '                                            .Parameters.AddWithValue("@4", (txt_alamat.Text))
                                '                                            .Parameters.AddWithValue("@5", (txt_kota.Text))
                                '                                            .Parameters.AddWithValue("@6", (txt_telp.Text))
                                '                                            .Parameters.AddWithValue("@7", (txt_npwp.Text))
                                '                                            .ExecuteNonQuery()
                                '                                        End With
                                '                                    End Using
                                '                                End Using
                                '                                Using cony As New MySqlConnection(sLocalConn)
                                '                                    cony.Open()
                                '                                    Dim sqly = "UPDATE tbpenjualan SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
                                '                                    Using cmdy As New MySqlCommand(sqly, cony)
                                '                                        With cmdy
                                '                                            .Parameters.Clear()
                                '                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                '                                            .ExecuteNonQuery()
                                '                                        End With
                                '                                    End Using
                                '                                End Using

                                '                                btn_refresh.PerformClick()
                                '                                MessageBox.Show("CLIENT berhasil di Update", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                '                            End If
                                '                        End Using
                                '                    End Using
                                '                End Using
                                '            End If
                                '        End Using
                                '    End Using
                                'End Using

                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    
End Class