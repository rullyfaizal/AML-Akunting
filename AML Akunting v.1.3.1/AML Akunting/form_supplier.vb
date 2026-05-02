Imports MySql.Data.MySqlClient

Public Class form_supplier

    Private Sub form_input_warna_resep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgv()
        Call isicbojenisbiaya()
        btn_update.Enabled = False
        btn_hapus.Enabled = False
    End Sub

    Private Sub isicbojenisbiaya()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT jenis_biaya From tbjenisbiaya"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        While drx.Read
                            CboJenisBiaya.Items.Add(drx.Item(0))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub CboJenisBiaya_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboJenisBiaya.Leave
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT jenis_biaya from tbjenisbiaya WHERE jenis_biaya ='" & CboJenisBiaya.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If Not CboJenisBiaya.Text = "" Then
                            If Not drx.HasRows Then
                                MsgBox("JENIS BIAYA yang diinput belum Tersimpan di Database")
                                CboJenisBiaya.Focus()
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).HeaderText = "NAMA"
        dgv1.Columns(2).HeaderText = "ALAMAT"
        dgv1.Columns(3).HeaderText = "TELEPON"
        dgv1.Columns(4).HeaderText = "NPWP"
        dgv1.Columns(5).HeaderText = "JENIS BIAYA"
        dgv1.Columns(6).HeaderText = "SATUAN"
        dgv1.Columns(1).Width = 150
        dgv1.Columns(2).Width = 130
        dgv1.Columns(3).Width = 110
        dgv1.Columns(4).Width = 110
        dgv1.Columns(5).Width = 140
        dgv1.Columns(6).Width = 100
    End Sub
    Private Sub isidgv()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id,nama,alamat,telepon,npwp,jenis_biaya,satuan FROM tbsupplier ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv1.DataSource = dsx.Tables("tbsupplier")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    'Private Sub txt_telp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telp.KeyPress
    '    If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Back) AndAlso Not e.KeyChar = "-" Then
    '        e.Handled = True
    '    End If
    '    If e.KeyChar = "-" AndAlso txt_telp.Text.Contains("-") Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        Try
            Call isidgv()
            txt_id.Text = ""
            txt_supplier.Text = ""
            txt_alamat.Text = ""
            txt_telp.Text = ""
            txt_npwp.Text = ""
            CboJenisBiaya.Text = ""
            txt_cari.Text = ""
            cbo_satuan.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim i As Integer
                Dim id, nama, alamat, telepon, npwp, jenis_biaya, satuan As String
                i = Me.dgv1.CurrentRow.Index
                With dgv1.Rows.Item(i)
                    id = .Cells(0).Value.ToString
                    nama = .Cells(1).Value.ToString
                    alamat = .Cells(2).Value.ToString
                    telepon = .Cells(3).Value.ToString
                    npwp = .Cells(4).Value.ToString
                    jenis_biaya = .Cells(5).Value.ToString
                    satuan = .Cells(6).Value.ToString
                End With
                txt_id.Text = id
                txt_supplier.Text = nama
                txt_supplier_asal.Text = nama
                txt_alamat.Text = alamat
                txt_telp.Text = telepon
                txt_npwp.Text = npwp
                CboJenisBiaya.Text = jenis_biaya
                cbo_satuan.Text = satuan
            End If
        Catch ex As Exception
            MsgBox("Tidak terdapat data Supplier untuk ditampilkan")
        End Try
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txt_supplier.Text = "" Then
            MsgBox("NAMA SUPPLIER Belum Dipilih")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbsupplier WHERE nama='" & txt_supplier.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If MsgBox("Yakin SUPPLIER Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbsupplier WHERE id='" & txt_id.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                        btn_refresh.PerformClick()
                                        MsgBox("SUPPLIER berhasil di Hapus")
                                    End Using
                                End If
                            Else
                                MsgBox("SUPPLIER belum terdapat di Database")
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
        If txt_supplier.Text = "" Then
            MsgBox("Nama SUPPLIER Belum Diinput")
            txt_supplier.Focus()
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbsupplier WHERE nama='" & txt_supplier.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                MessageBox.Show("Nama Supplier yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbsupplier (nama,alamat,telepon,npwp,jenis_biaya,satuan) VALUES (@1,@2,@3,@4,@5,@6)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .Parameters.AddWithValue("@2", (txt_alamat.Text))
                                            .Parameters.AddWithValue("@3", (txt_telp.Text))
                                            .Parameters.AddWithValue("@4", (txt_npwp.Text))
                                            .Parameters.AddWithValue("@5", (CboJenisBiaya.Text))
                                            .Parameters.AddWithValue("@6", (cbo_satuan.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                btn_refresh.PerformClick()
                                MessageBox.Show("SUPPLIER Baru berhasil di Simpan", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If txt_id.Text = "" Then
            MsgBox("SUPPLIER Belum Dipilih dari Tabel Data")
        Else
            Try
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT nama FROM tbsupplier WHERE nama='" & txt_supplier.Text & "'AND nama<>'" & txt_supplier_asal.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                MessageBox.Show("Nama Supplier yang diinput sudah ada di Database", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbsupplier SET nama=@1,alamat=@2,telepon=@3,npwp=@4,jenis_biaya=@5,satuan=@6 WHERE id = '" & txt_id.Text & "'"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                            .Parameters.AddWithValue("@2", (txt_alamat.Text))
                                            .Parameters.AddWithValue("@3", (txt_telp.Text))
                                            .Parameters.AddWithValue("@4", (txt_npwp.Text))
                                            .Parameters.AddWithValue("@5", (CboJenisBiaya.Text))
                                            .Parameters.AddWithValue("@6", (cbo_satuan.Text))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                If txt_supplier.Text <> txt_supplier_asal.Text Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "UPDATE tbpembelian SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
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
                                        Dim sqly = "UPDATE tbindukpembelian SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
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
                                        Dim sqly = "UPDATE tbgrey SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
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
                                        Dim sqly = "UPDATE tbhistorygrey SET supplier=@1 WHERE supplier = '" & txt_supplier_asal.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            With cmdy
                                                .Parameters.Clear()
                                                .Parameters.AddWithValue("@1", (txt_supplier.Text))
                                                .ExecuteNonQuery()
                                            End With
                                        End Using
                                    End Using
                                End If
                                btn_refresh.PerformClick()
                                MessageBox.Show("SUPPLIER berhasil di Update", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End Using
                    End Using
                End Using
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

    Private Sub cari_supplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT * FROM tbsupplier WHERE nama like '%" & txt_cari.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv1.DataSource = dsx.Tables("tbsupplier")
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
End Class