Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_input_pembelian_baru

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

    Private Sub Cbo_Supplier_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Supplier.GotFocus
        If Cbo_Supplier.Text = "" Then
            Call isicbosupplier()
        Else
            Call carisupplier()
        End If
        dgv_supplier.Visible = True
    End Sub
    Private Sub btn_supplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_supplier.Click
        btn_supplier.Focus()
        dgv_supplier.Visible = False
        Cbo_Supplier.Text = ""
    End Sub
    Private Sub headertablesupplier()
        dgv_supplier.ColumnHeadersVisible = False
        dgv_supplier.RowHeadersVisible = False
        dgv_supplier.Columns(0).Width = 300
    End Sub
    Private Sub isicbosupplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT nama From tbsupplier ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv_supplier.DataSource = dsx.Tables("tbsupplier")
                            Call headertablesupplier()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub carisupplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama From tbsupplier WHERE nama like '%" & Cbo_Supplier.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv_supplier.DataSource = dsx.Tables("tbsupplier")
                            Call headertablesupplier()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cbo_Supplier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Supplier.TextChanged
        If Cbo_Supplier.Text = "" Then
            Call isicbosupplier()
            CboJenisBiaya.Text = ""
        Else
            Call carisupplier()
        End If
    End Sub
    Private Sub dgv_supplier_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_supplier.CellMouseClick
        Try
            Dim i As Integer
            i = Me.dgv_supplier.CurrentRow.Index
            With dgv_supplier.Rows.Item(i)
                Cbo_Supplier.Text = dgv_supplier.Rows(i).Cells(0).Value
            End With
            btn_supplier.Focus()
            dgv_supplier.Visible = False
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama,jenis_biaya from tbsupplier WHERE nama ='" & Cbo_Supplier.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            CboJenisBiaya.Text = drx(1)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub form_input_pembelian_baru_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        txt_no_faktur.Focus()
        'Call isicbosupplier()
        Call isicbojenisbiaya()
        'Call nilai_awal_dtp_upload()
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
    End Sub
    Private Sub nilai_awal_dtp_upload()
        Dim currentDate As DateTime = dtp_tanggal_upload.Value
        Dim tomorrowDate As DateTime = currentDate.AddDays(1)
        dtp_tanggal_upload.Value = tomorrowDate
    End Sub
    Private Sub btn_kosong_tanggal_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal_upload.Click
        If Not txt_tanggal_upload.Text = "" Then
            txt_tanggal_upload.Text = ""
        End If
    End Sub
    Private Sub dtp_tanggal_upload_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_tanggal_upload.TextChanged
        Dim selectedDate As DateTime = dtp_tanggal_upload.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_upload.Text = formattedDate
    End Sub

    Private Sub cbo_pembayaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_pembayaran.KeyPress
        If Not e.KeyChar = Chr(13) Then e.Handled = True
    End Sub

    Private Sub txt_no_faktur_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_no_faktur.KeyPress
        ' Mengizinkan hanya angka
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        ' Hanya memproses input jika belum penuh
        If txt_no_faktur.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        '' Posisi kursor saat ini
        'Dim cursorPosition As Integer = txt_no_faktur.SelectionStart
        '' Memasukkan karakter ke posisi yang sesuai
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            'txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
        '        Case 6
        '            'txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & If(cursorPosition = 7, "-", "."))
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2 ' Menggeser kursor ke kanan melewati titik atau strip
        '        Case Else
        '            txt_no_faktur.Text = txt_no_faktur.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select

        '    ' Menangani event untuk mencegah karakter ganda
        '    e.Handled = True

        '    ' Mengatur posisi kursor baru
        '    txt_no_faktur.SelectionStart = cursorPosition
        'End If
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
    Private Sub Cbo_Supplier_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama from tbsupplier WHERE nama ='" & Cbo_Supplier.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If Not Cbo_Supplier.Text = "" Then
                            If Not drx.HasRows Then
                                MsgBox("Nama Supplier belum Tersimpan di Database")
                                Cbo_Supplier.Focus()
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
                                MsgBox("JENIS BIAYA belum Tersimpan di Database")
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
    Private Sub cb_status_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb_status1.KeyPress, _
        cb_status2.KeyPress, cb_status3.KeyPress, cb_status4.KeyPress, cb_status5.KeyPress, cb_status6.KeyPress, cb_status7.KeyPress, _
        cb_status8.KeyPress, cb_status9.KeyPress, cb_status10.KeyPress
        If Not e.KeyChar = Chr(13) Then e.Handled = True
    End Sub
    Private Sub txt_no_faktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_no_faktur.TextChanged
        If txt_no_faktur.Text = "" Then
            cb_status1.Text = "polos"
            cb_status2.Text = "polos"
            cb_status3.Text = "polos"
            cb_status4.Text = "polos"
            cb_status5.Text = "polos"
            cb_status6.Text = "polos"
            cb_status7.Text = "polos"
            cb_status8.Text = "polos"
            cb_status9.Text = "polos"
            cb_status10.Text = "polos"
        Else
            cb_status1.Text = "ppn"
            cb_status2.Text = "ppn"
            cb_status3.Text = "ppn"
            cb_status4.Text = "ppn"
            cb_status5.Text = "ppn"
            cb_status6.Text = "ppn"
            cb_status7.Text = "ppn"
            cb_status8.Text = "ppn"
            cb_status9.Text = "ppn"
            cb_status10.Text = "ppn"
        End If
    End Sub

    Private Sub txt_specs1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs1.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 1"
        form_nama_specs.txt_nama.Text = txt_specs1.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs2.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 2"
        form_nama_specs.txt_nama.Text = txt_specs2.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs3.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 3"
        form_nama_specs.txt_nama.Text = txt_specs3.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs4.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 4"
        form_nama_specs.txt_nama.Text = txt_specs4.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs5.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 5"
        form_nama_specs.txt_nama.Text = txt_specs5.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs6.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 6"
        form_nama_specs.txt_nama.Text = txt_specs6.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs7.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 7"
        form_nama_specs.txt_nama.Text = txt_specs7.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs8.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 8"
        form_nama_specs.txt_nama.Text = txt_specs8.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs9.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 9"
        form_nama_specs.txt_nama.Text = txt_specs9.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub
    Private Sub txt_specs10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs10.GotFocus
        form_nama_specs.Show()
        form_nama_specs.txt_form.Text = "specs ppn 10"
        form_nama_specs.txt_nama.Text = txt_specs10.Text
        form_nama_specs.Focus()
        form_nama_specs.btn_simpan.Visible = False
        form_nama_specs.btn_update.Visible = False
        form_nama_specs.btn_hapus.Visible = False
        form_nama_specs.btn_ok.Visible = True
    End Sub

    Private Sub txt_jumlah1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah1.LostFocus
        Dim input As String = txt_jumlah1.Text
        Dim number As Decimal
        If Not txt_jumlah1.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah1.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah2.LostFocus
        Dim input As String = txt_jumlah2.Text
        Dim number As Decimal
        If Not txt_jumlah2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah2.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah3.LostFocus
        Dim input As String = txt_jumlah3.Text
        Dim number As Decimal
        If Not txt_jumlah3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah3.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah4.LostFocus
        Dim input As String = txt_jumlah4.Text
        Dim number As Decimal
        If Not txt_jumlah4.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah4.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah5_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah5.LostFocus
        Dim input As String = txt_jumlah5.Text
        Dim number As Decimal
        If Not txt_jumlah5.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah5.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah5.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah6_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah6.LostFocus
        Dim input As String = txt_jumlah6.Text
        Dim number As Decimal
        If Not txt_jumlah6.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah6.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah6.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah7_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah7.LostFocus
        Dim input As String = txt_jumlah7.Text
        Dim number As Decimal
        If Not txt_jumlah7.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah7.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah7.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah8_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah8.LostFocus
        Dim input As String = txt_jumlah8.Text
        Dim number As Decimal
        If Not txt_jumlah8.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah8.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah8.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah9_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah9.LostFocus
        Dim input As String = txt_jumlah9.Text
        Dim number As Decimal
        If Not txt_jumlah9.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah9.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah9.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah10_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_jumlah10.LostFocus
        Dim input As String = txt_jumlah10.Text
        Dim number As Decimal
        If Not txt_jumlah10.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah10.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah10.Focus()
            End If
        End If
    End Sub

    Private Sub txt_harga1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga1.LostFocus
        Dim input As String = txt_harga1.Text
        Dim number As Decimal
        If Not txt_harga1.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga1.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga2.LostFocus
        Dim input As String = txt_harga2.Text
        Dim number As Decimal
        If Not txt_harga2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga2.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga3.LostFocus
        Dim input As String = txt_harga3.Text
        Dim number As Decimal
        If Not txt_harga3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga3.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga4.LostFocus
        Dim input As String = txt_harga4.Text
        Dim number As Decimal
        If Not txt_harga4.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga4.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga5_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga5.LostFocus
        Dim input As String = txt_harga5.Text
        Dim number As Decimal
        If Not txt_harga5.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga5.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga5.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga6_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga6.LostFocus
        Dim input As String = txt_harga6.Text
        Dim number As Decimal
        If Not txt_harga6.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga6.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga6.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga7_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga7.LostFocus
        Dim input As String = txt_harga7.Text
        Dim number As Decimal
        If Not txt_harga7.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga7.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga7.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga8_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga8.LostFocus
        Dim input As String = txt_harga8.Text
        Dim number As Decimal
        If Not txt_harga8.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga8.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga8.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga9_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga9.LostFocus
        Dim input As String = txt_harga9.Text
        Dim number As Decimal
        If Not txt_harga9.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga9.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga9.Focus()
            End If
        End If
    End Sub
    Private Sub txt_harga10_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_harga10.LostFocus
        Dim input As String = txt_harga10.Text
        Dim number As Decimal
        If Not txt_harga10.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_harga10.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_harga10.Focus()
            End If
        End If
    End Sub

    Private Sub txt_total_dpp1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp1.LostFocus
        Dim input As String = txt_total_dpp1.Text
        Dim number As Decimal
        If Not txt_total_dpp1.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp1.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp2.LostFocus
        Dim input As String = txt_total_dpp2.Text
        Dim number As Decimal
        If Not txt_total_dpp2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp2.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp3.LostFocus
        Dim input As String = txt_total_dpp3.Text
        Dim number As Decimal
        If Not txt_total_dpp3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp3.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp4.LostFocus
        Dim input As String = txt_total_dpp4.Text
        Dim number As Decimal
        If Not txt_total_dpp4.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp4.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp5_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp5.LostFocus
        Dim input As String = txt_total_dpp5.Text
        Dim number As Decimal
        If Not txt_total_dpp5.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp5.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp5.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp6_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp6.LostFocus
        Dim input As String = txt_total_dpp6.Text
        Dim number As Decimal
        If Not txt_total_dpp6.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp6.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp6.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp7_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp7.LostFocus
        Dim input As String = txt_total_dpp7.Text
        Dim number As Decimal
        If Not txt_total_dpp7.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp7.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp7.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp8_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp8.LostFocus
        Dim input As String = txt_total_dpp8.Text
        Dim number As Decimal
        If Not txt_total_dpp8.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp8.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp8.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp9_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp9.LostFocus
        Dim input As String = txt_total_dpp9.Text
        Dim number As Decimal
        If Not txt_total_dpp9.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp9.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp9.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_dpp10_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_dpp10.LostFocus
        Dim input As String = txt_total_dpp10.Text
        Dim number As Decimal
        If Not txt_total_dpp10.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_dpp10.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_dpp10.Focus()
            End If
        End If
    End Sub

    Private Sub txt_total_harga1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga1.LostFocus
        Dim input As String = txt_total_harga1.Text
        Dim number As Decimal
        If Not txt_total_harga1.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga1.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga2.LostFocus
        Dim input As String = txt_total_harga2.Text
        Dim number As Decimal
        If Not txt_total_harga2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga2.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga3.LostFocus
        Dim input As String = txt_total_harga3.Text
        Dim number As Decimal
        If Not txt_total_harga3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga3.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga4.LostFocus
        Dim input As String = txt_total_harga4.Text
        Dim number As Decimal
        If Not txt_total_harga4.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga4.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga5_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga5.LostFocus
        Dim input As String = txt_total_harga5.Text
        Dim number As Decimal
        If Not txt_total_harga5.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga5.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga5.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga6_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga6.LostFocus
        Dim input As String = txt_total_harga6.Text
        Dim number As Decimal
        If Not txt_total_harga6.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga6.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga6.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga7_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga7.LostFocus
        Dim input As String = txt_total_harga7.Text
        Dim number As Decimal
        If Not txt_total_harga7.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga7.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga7.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga8_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga8.LostFocus
        Dim input As String = txt_total_harga8.Text
        Dim number As Decimal
        If Not txt_total_harga8.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga8.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga8.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga9_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga9.LostFocus
        Dim input As String = txt_total_harga9.Text
        Dim number As Decimal
        If Not txt_total_harga9.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga9.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga9.Focus()
            End If
        End If
    End Sub
    Private Sub txt_total_harga10_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total_harga10.LostFocus
        Dim input As String = txt_total_harga10.Text
        Dim number As Decimal
        If Not txt_total_harga10.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_total_harga10.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_total_harga10.Focus()
            End If
        End If
    End Sub

    Private Sub btn_hitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung.Click
        Try
            If btn_hitung.Text = "HITUNG" Then
                If txt_specs1.Text = "" And txt_specs2.Text = "" And txt_specs3.Text = "" And txt_specs4.Text = "" And txt_specs5.Text = "" _
               And txt_specs6.Text = "" And txt_specs7.Text = "" And txt_specs8.Text = "" And txt_specs9.Text = "" And txt_specs10.Text = "" Then
                    MsgBox("Nama Barang / Specs Barang belum input")
                Else
                    Call hitung_baris1()
                    Call hitung_baris2()
                    Call hitung_baris3()
                    Call hitung_baris4()
                    Call hitung_baris5()
                    Call hitung_baris6()
                    Call hitung_baris7()
                    Call hitung_baris8()
                    Call hitung_baris9()
                    Call hitung_baris10()
                    Call hitung_total()
                    btn_simpan.Enabled = True
                    btn_hitung.Text = "EDIT"
                    Panel2.Enabled = False
                End If
            Else
                btn_simpan.Enabled = False
                btn_hitung.Text = "HITUNG"
                Panel2.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub hitung_baris1()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status1.Text = "polos" Then
            If Not txt_specs1.Text = "" Then
                If Not txt_harga1.Text = "" Then
                    jumlah = txt_jumlah1.Text.Replace(".", "")
                    harga = txt_harga1.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga1.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga1.Text = "" Then
                    jumlah = txt_jumlah1.Text.Replace(".", "")
                    grand_total = txt_total_harga1.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga1.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp1.Text = ""
                txt_ppn1.Text = ""
            End If
        ElseIf cb_status1.Text = "ppn" Then
            If Not txt_specs1.Text = "" Then
                If Not txt_harga1.Text = "" Then
                    jumlah = txt_jumlah1.Text.Replace(".", "")
                    harga = txt_harga1.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp1.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn1.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga1.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp1.Text = "" Then
                    jumlah = txt_jumlah1.Text.Replace(".", "")
                    total_dpp = txt_total_dpp1.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga1.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn1.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga1.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga1.Text = "" Then
                    jumlah = txt_jumlah1.Text.Replace(".", "")
                    grand_total = txt_total_harga1.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga1.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp1.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn1.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris2()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status2.Text = "polos" Then
            If Not txt_specs2.Text = "" Then
                If Not txt_harga2.Text = "" Then
                    jumlah = txt_jumlah2.Text.Replace(".", "")
                    harga = txt_harga2.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga2.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga2.Text = "" Then
                    jumlah = txt_jumlah2.Text.Replace(".", "")
                    grand_total = txt_total_harga2.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga2.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp2.Text = ""
                txt_ppn2.Text = ""
            End If
        ElseIf cb_status2.Text = "ppn" Then
            If Not txt_specs2.Text = "" Then
                If Not txt_harga2.Text = "" Then
                    jumlah = txt_jumlah2.Text.Replace(".", "")
                    harga = txt_harga2.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp2.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn2.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga2.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp2.Text = "" Then
                    jumlah = txt_jumlah2.Text.Replace(".", "")
                    total_dpp = txt_total_dpp2.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga2.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn2.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga2.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga2.Text = "" Then
                    jumlah = txt_jumlah2.Text.Replace(".", "")
                    grand_total = txt_total_harga2.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga2.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp2.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn2.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris3()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status3.Text = "polos" Then
            If Not txt_specs3.Text = "" Then
                If Not txt_harga3.Text = "" Then
                    jumlah = txt_jumlah3.Text.Replace(".", "")
                    harga = txt_harga3.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga3.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga3.Text = "" Then
                    jumlah = txt_jumlah3.Text.Replace(".", "")
                    grand_total = txt_total_harga3.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga3.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp3.Text = ""
                txt_ppn3.Text = ""
            End If
        ElseIf cb_status3.Text = "ppn" Then
            If Not txt_specs3.Text = "" Then
                If Not txt_harga3.Text = "" Then
                    jumlah = txt_jumlah3.Text.Replace(".", "")
                    harga = txt_harga3.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp3.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn3.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga3.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp3.Text = "" Then
                    jumlah = txt_jumlah3.Text.Replace(".", "")
                    total_dpp = txt_total_dpp3.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga3.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn3.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga3.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga3.Text = "" Then
                    jumlah = txt_jumlah3.Text.Replace(".", "")
                    grand_total = txt_total_harga3.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga3.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp3.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn3.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris4()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status4.Text = "polos" Then
            If Not txt_specs4.Text = "" Then
                If Not txt_harga4.Text = "" Then
                    jumlah = txt_jumlah4.Text.Replace(".", "")
                    harga = txt_harga4.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga4.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga4.Text = "" Then
                    jumlah = txt_jumlah4.Text.Replace(".", "")
                    grand_total = txt_total_harga4.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga4.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp4.Text = ""
                txt_ppn4.Text = ""
            End If
        ElseIf cb_status4.Text = "ppn" Then
            If Not txt_specs4.Text = "" Then
                If Not txt_harga4.Text = "" Then
                    jumlah = txt_jumlah4.Text.Replace(".", "")
                    harga = txt_harga4.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp4.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn4.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga4.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp4.Text = "" Then
                    jumlah = txt_jumlah4.Text.Replace(".", "")
                    total_dpp = txt_total_dpp4.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga4.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn4.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga4.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga4.Text = "" Then
                    jumlah = txt_jumlah4.Text.Replace(".", "")
                    grand_total = txt_total_harga4.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga4.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp4.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn4.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris5()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status5.Text = "polos" Then
            If Not txt_specs5.Text = "" Then
                If Not txt_harga5.Text = "" Then
                    jumlah = txt_jumlah5.Text.Replace(".", "")
                    harga = txt_harga5.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga5.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga5.Text = "" Then
                    jumlah = txt_jumlah5.Text.Replace(".", "")
                    grand_total = txt_total_harga5.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga5.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp5.Text = ""
                txt_ppn5.Text = ""
            End If
        ElseIf cb_status5.Text = "ppn" Then
            If Not txt_specs5.Text = "" Then
                If Not txt_harga5.Text = "" Then
                    jumlah = txt_jumlah5.Text.Replace(".", "")
                    harga = txt_harga5.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp5.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn5.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga5.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp5.Text = "" Then
                    jumlah = txt_jumlah5.Text.Replace(".", "")
                    total_dpp = txt_total_dpp5.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga5.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn5.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga5.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga5.Text = "" Then
                    jumlah = txt_jumlah5.Text.Replace(".", "")
                    grand_total = txt_total_harga5.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga5.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp5.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn5.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris6()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status6.Text = "polos" Then
            If Not txt_specs6.Text = "" Then
                If Not txt_harga6.Text = "" Then
                    jumlah = txt_jumlah6.Text.Replace(".", "")
                    harga = txt_harga6.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga6.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga6.Text = "" Then
                    jumlah = txt_jumlah6.Text.Replace(".", "")
                    grand_total = txt_total_harga6.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga6.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp6.Text = ""
                txt_ppn6.Text = ""
            End If
        ElseIf cb_status6.Text = "ppn" Then
            If Not txt_specs6.Text = "" Then
                If Not txt_harga6.Text = "" Then
                    jumlah = txt_jumlah6.Text.Replace(".", "")
                    harga = txt_harga6.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp6.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn6.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga6.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp6.Text = "" Then
                    jumlah = txt_jumlah6.Text.Replace(".", "")
                    total_dpp = txt_total_dpp6.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga6.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn6.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga6.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga6.Text = "" Then
                    jumlah = txt_jumlah6.Text.Replace(".", "")
                    grand_total = txt_total_harga6.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga6.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp6.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn6.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris7()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status7.Text = "polos" Then
            If Not txt_specs7.Text = "" Then
                If Not txt_harga7.Text = "" Then
                    jumlah = txt_jumlah7.Text.Replace(".", "")
                    harga = txt_harga7.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga7.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga7.Text = "" Then
                    jumlah = txt_jumlah7.Text.Replace(".", "")
                    grand_total = txt_total_harga7.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga7.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp7.Text = ""
                txt_ppn7.Text = ""
            End If
        ElseIf cb_status7.Text = "ppn" Then
            If Not txt_specs7.Text = "" Then
                If Not txt_harga7.Text = "" Then
                    jumlah = txt_jumlah7.Text.Replace(".", "")
                    harga = txt_harga7.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp7.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn7.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga7.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp7.Text = "" Then
                    jumlah = txt_jumlah7.Text.Replace(".", "")
                    total_dpp = txt_total_dpp7.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga7.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn7.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga7.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga7.Text = "" Then
                    jumlah = txt_jumlah7.Text.Replace(".", "")
                    grand_total = txt_total_harga7.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga7.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp7.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn7.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris8()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status8.Text = "polos" Then
            If Not txt_specs8.Text = "" Then
                If Not txt_harga8.Text = "" Then
                    jumlah = txt_jumlah8.Text.Replace(".", "")
                    harga = txt_harga8.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga8.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga8.Text = "" Then
                    jumlah = txt_jumlah8.Text.Replace(".", "")
                    grand_total = txt_total_harga8.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga8.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp8.Text = ""
                txt_ppn8.Text = ""
            End If
        ElseIf cb_status8.Text = "ppn" Then
            If Not txt_specs8.Text = "" Then
                If Not txt_harga8.Text = "" Then
                    jumlah = txt_jumlah8.Text.Replace(".", "")
                    harga = txt_harga8.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp8.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn8.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga8.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp8.Text = "" Then
                    jumlah = txt_jumlah8.Text.Replace(".", "")
                    total_dpp = txt_total_dpp8.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga8.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn8.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga8.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga8.Text = "" Then
                    jumlah = txt_jumlah8.Text.Replace(".", "")
                    grand_total = txt_total_harga8.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga8.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp8.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn8.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris9()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status9.Text = "polos" Then
            If Not txt_specs9.Text = "" Then
                If Not txt_harga9.Text = "" Then
                    jumlah = txt_jumlah9.Text.Replace(".", "")
                    harga = txt_harga9.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga9.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga9.Text = "" Then
                    jumlah = txt_jumlah9.Text.Replace(".", "")
                    grand_total = txt_total_harga9.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga9.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp9.Text = ""
                txt_ppn9.Text = ""
            End If
        ElseIf cb_status9.Text = "ppn" Then
            If Not txt_specs9.Text = "" Then
                If Not txt_harga9.Text = "" Then
                    jumlah = txt_jumlah9.Text.Replace(".", "")
                    harga = txt_harga9.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp9.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn9.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga9.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp9.Text = "" Then
                    jumlah = txt_jumlah9.Text.Replace(".", "")
                    total_dpp = txt_total_dpp9.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga9.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn9.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga9.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga9.Text = "" Then
                    jumlah = txt_jumlah9.Text.Replace(".", "")
                    grand_total = txt_total_harga9.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga9.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp9.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn9.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub
    Private Sub hitung_baris10()
        Dim jumlah As Double
        Dim harga As Double
        Dim total_dpp As Double
        Dim total_ppn As Double
        Dim grand_total As Double
        If cb_status10.Text = "polos" Then
            If Not txt_specs10.Text = "" Then
                If Not txt_harga10.Text = "" Then
                    jumlah = txt_jumlah10.Text.Replace(".", "")
                    harga = txt_harga10.Text.Replace(".", "")
                    grand_total = jumlah * harga
                    txt_total_harga10.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga10.Text = "" Then
                    jumlah = txt_jumlah10.Text.Replace(".", "")
                    grand_total = txt_total_harga10.Text.Replace(".", "")
                    harga = grand_total / jumlah
                    txt_harga10.Text = harga.ToString("#,##0.00########")
                End If
                txt_total_dpp10.Text = ""
                txt_ppn10.Text = ""
            End If
        ElseIf cb_status10.Text = "ppn" Then
            If Not txt_specs10.Text = "" Then
                If Not txt_harga10.Text = "" Then
                    jumlah = txt_jumlah10.Text.Replace(".", "")
                    harga = txt_harga10.Text.Replace(".", "")
                    total_dpp = jumlah * harga
                    txt_total_dpp10.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn10.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga10.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_dpp10.Text = "" Then
                    jumlah = txt_jumlah10.Text.Replace(".", "")
                    total_dpp = txt_total_dpp10.Text.Replace(".", "")
                    harga = total_dpp / jumlah
                    txt_harga10.Text = harga.ToString("#,##0.00########")
                    total_ppn = total_dpp * (ppn / 100)
                    txt_ppn10.Text = total_ppn.ToString("#,##0.00########")
                    grand_total = total_dpp + total_ppn
                    txt_total_harga10.Text = grand_total.ToString("#,##0.00########")
                ElseIf Not txt_total_harga10.Text = "" Then
                    jumlah = txt_jumlah10.Text.Replace(".", "")
                    grand_total = txt_total_harga10.Text.Replace(".", "")
                    harga = grand_total / (jumlah + (jumlah * (ppn / 100)))
                    txt_harga10.Text = harga.ToString("#,##0.00########")
                    total_dpp = jumlah * harga
                    txt_total_dpp10.Text = total_dpp.ToString("#,##0.00########")
                    total_ppn = grand_total - total_dpp
                    txt_ppn10.Text = total_ppn.ToString("#,##0.00########")
                End If
            End If
        End If
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If Cbo_Supplier.Text = "" Then
                MsgBox("Nama SUPPLIER belum Diinput")
            Else
                Call simpan_induk()

                If Not txt_specs1.Text = "" Then
                    Call simpan_baris1()
                End If
                If Not txt_specs2.Text = "" Then
                    Call simpan_baris2()
                End If
                If Not txt_specs3.Text = "" Then
                    Call simpan_baris3()
                End If
                If Not txt_specs4.Text = "" Then
                    Call simpan_baris4()
                End If
                If Not txt_specs5.Text = "" Then
                    Call simpan_baris5()
                End If
                If Not txt_specs6.Text = "" Then
                    Call simpan_baris6()
                End If
                If Not txt_specs7.Text = "" Then
                    Call simpan_baris7()
                End If
                If Not txt_specs8.Text = "" Then
                    Call simpan_baris8()
                End If
                If Not txt_specs9.Text = "" Then
                    Call simpan_baris9()
                End If
                If Not txt_specs10.Text = "" Then
                    Call simpan_baris10()
                End If

                MsgBox("Pembelian Baru Berhasil Disimpan")
                form_pembelian.Show()
                form_pembelian.Focus()
                form_pembelian.ts_perbarui.PerformClick()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub simpan_baris1()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs1.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah1.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga1.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp1.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn1.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga1.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status1.Text)
                    .Parameters.AddWithValue("@14", 1)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris2()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs2.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah2.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga2.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp2.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn2.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga2.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status2.Text)
                    .Parameters.AddWithValue("@14", 2)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris3()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs3.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah3.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga3.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp3.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn3.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga3.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status3.Text)
                    .Parameters.AddWithValue("@14", 3)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris4()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs4.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah4.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga4.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp4.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn4.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga4.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status4.Text)
                    .Parameters.AddWithValue("@14", 4)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris5()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs5.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah5.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga5.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp5.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn5.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga5.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status5.Text)
                    .Parameters.AddWithValue("@14", 5)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris6()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs6.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah6.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga6.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp6.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn6.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga6.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status6.Text)
                    .Parameters.AddWithValue("@14", 6)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris7()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs7.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah7.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga7.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp7.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn7.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga7.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status7.Text)
                    .Parameters.AddWithValue("@14", 7)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris8()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs8.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah8.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga8.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp8.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn8.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga8.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status8.Text)
                    .Parameters.AddWithValue("@14", 8)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris9()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs9.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah9.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga9.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp9.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn9.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga9.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status9.Text)
                    .Parameters.AddWithValue("@14", 9)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub
    Private Sub simpan_baris10()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_specs10.Text)
                    .Parameters.AddWithValue("@6", txt_jumlah10.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_harga10.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", txt_total_dpp10.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@9", txt_ppn10.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@10", txt_total_harga10.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@11", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@13", cb_status10.Text)
                    .Parameters.AddWithValue("@14", 10)
                    .Parameters.AddWithValue("@15", Txt_kode.Text)
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub

    Private Sub simpan_induk()
        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbindukpembelian (kode,tanggal,no_faktur,supplier,jenis_biaya,total_dpp,total_ppn,total_pembelian,pembayaran,tanggal_upload,total_polos) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                    dtp_tanggal_upload.CustomFormat = "yyyy/MM/dd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@0", Txt_kode.Text)
                    .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                    .Parameters.AddWithValue("@2", txt_no_faktur.Text)
                    .Parameters.AddWithValue("@3", Cbo_Supplier.Text)
                    .Parameters.AddWithValue("@4", CboJenisBiaya.Text)
                    .Parameters.AddWithValue("@5", txt_total_dpp.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@6", txt_total_ppn.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@7", txt_gran_total.Text.Replace(".", "").Replace(",", "."))
                    .Parameters.AddWithValue("@8", cbo_pembayaran.Text)
                    If txt_tanggal_upload.Text = "" Then
                        .Parameters.AddWithValue("@9", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@9", dtp_tanggal_upload.Text)
                    End If
                    .Parameters.AddWithValue("@10", txt_total_polos.Text.Replace(".", "").Replace(",", "."))
                    .ExecuteNonQuery()
                    dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    dtp_tanggal_upload.CustomFormat = "dd/MM/yyyy"
                End With
            End Using
        End Using
    End Sub

    Private Sub hitung_total()
        Dim total_harga1 As Decimal
        Dim total_harga2 As Decimal
        Dim total_harga3 As Decimal
        Dim total_harga4 As Decimal
        Dim total_harga5 As Decimal
        Dim total_harga6 As Decimal
        Dim total_harga7 As Decimal
        Dim total_harga8 As Decimal
        Dim total_harga9 As Decimal
        Dim total_harga10 As Decimal
        Decimal.TryParse(txt_total_harga1.Text, total_harga1)
        Decimal.TryParse(txt_total_harga2.Text, total_harga2)
        Decimal.TryParse(txt_total_harga3.Text, total_harga3)
        Decimal.TryParse(txt_total_harga4.Text, total_harga4)
        Decimal.TryParse(txt_total_harga5.Text, total_harga5)
        Decimal.TryParse(txt_total_harga6.Text, total_harga6)
        Decimal.TryParse(txt_total_harga7.Text, total_harga7)
        Decimal.TryParse(txt_total_harga8.Text, total_harga8)
        Decimal.TryParse(txt_total_harga9.Text, total_harga9)
        Decimal.TryParse(txt_total_harga10.Text, total_harga10)
        
        Dim total_ppn As Decimal = 0
        Dim total_polos As Decimal = 0

        If cb_status1.Text = "ppn" Then
            total_ppn = total_ppn + total_harga1
        Else
            total_polos = total_polos + total_harga1
        End If
        If cb_status2.Text = "ppn" Then
            total_ppn = total_ppn + total_harga2
        Else
            total_polos = total_polos + total_harga2
        End If
        If cb_status3.Text = "ppn" Then
            total_ppn = total_ppn + total_harga3
        Else
            total_polos = total_polos + total_harga3
        End If
        If cb_status4.Text = "ppn" Then
            total_ppn = total_ppn + total_harga4
        Else
            total_polos = total_polos + total_harga4
        End If
        If cb_status5.Text = "ppn" Then
            total_ppn = total_ppn + total_harga5
        Else
            total_polos = total_polos + total_harga5
        End If
        If cb_status6.Text = "ppn" Then
            total_ppn = total_ppn + total_harga6
        Else
            total_polos = total_polos + total_harga6
        End If
        If cb_status7.Text = "ppn" Then
            total_ppn = total_ppn + total_harga7
        Else
            total_polos = total_polos + total_harga7
        End If
        If cb_status8.Text = "ppn" Then
            total_ppn = total_ppn + total_harga8
        Else
            total_polos = total_polos + total_harga8
        End If
        If cb_status9.Text = "ppn" Then
            total_ppn = total_ppn + total_harga9
        Else
            total_polos = total_polos + total_harga9
        End If
        If cb_status10.Text = "ppn" Then
            total_ppn = total_ppn + total_harga10
        Else
            total_polos = total_polos + total_harga10
        End If

        txt_gran_total.Text = total_ppn.ToString("#,##0.00########")
        txt_total_polos.Text = total_polos.ToString("#,##0.00########")

        Dim total_dpp1 As Decimal
        Dim total_dpp2 As Decimal
        Dim total_dpp3 As Decimal
        Dim total_dpp4 As Decimal
        Dim total_dpp5 As Decimal
        Dim total_dpp6 As Decimal
        Dim total_dpp7 As Decimal
        Dim total_dpp8 As Decimal
        Dim total_dpp9 As Decimal
        Dim total_dpp10 As Decimal
        Decimal.TryParse(txt_total_dpp1.Text, total_dpp1)
        Decimal.TryParse(txt_total_dpp2.Text, total_dpp2)
        Decimal.TryParse(txt_total_dpp3.Text, total_dpp3)
        Decimal.TryParse(txt_total_dpp4.Text, total_dpp4)
        Decimal.TryParse(txt_total_dpp5.Text, total_dpp5)
        Decimal.TryParse(txt_total_dpp6.Text, total_dpp6)
        Decimal.TryParse(txt_total_dpp7.Text, total_dpp7)
        Decimal.TryParse(txt_total_dpp8.Text, total_dpp8)
        Decimal.TryParse(txt_total_dpp9.Text, total_dpp9)
        Decimal.TryParse(txt_total_dpp10.Text, total_dpp10)
        Dim total_dpp As Decimal = total_dpp1 + total_dpp2 + total_dpp3 + total_dpp4 + total_dpp5 + total_dpp6 + total_dpp7 + total_dpp8 + total_dpp9 + total_dpp10
        txt_total_dpp.Text = total_dpp.ToString("#,##0.00########")

        Dim ppn1 As Decimal
        Dim ppn2 As Decimal
        Dim ppn3 As Decimal
        Dim ppn4 As Decimal
        Dim ppn5 As Decimal
        Dim ppn6 As Decimal
        Dim ppn7 As Decimal
        Dim ppn8 As Decimal
        Dim ppn9 As Decimal
        Dim ppn10 As Decimal
        Decimal.TryParse(txt_ppn1.Text, ppn1)
        Decimal.TryParse(txt_ppn2.Text, ppn2)
        Decimal.TryParse(txt_ppn3.Text, ppn3)
        Decimal.TryParse(txt_ppn4.Text, ppn4)
        Decimal.TryParse(txt_ppn5.Text, ppn5)
        Decimal.TryParse(txt_ppn6.Text, ppn6)
        Decimal.TryParse(txt_ppn7.Text, ppn7)
        Decimal.TryParse(txt_ppn8.Text, ppn8)
        Decimal.TryParse(txt_ppn9.Text, ppn9)
        Decimal.TryParse(txt_ppn10.Text, ppn10)
        Dim ppn As Decimal = ppn1 + ppn2 + ppn3 + ppn4 + ppn5 + ppn6 + ppn7 + ppn8 + ppn9 + ppn10
        txt_total_ppn.Text = ppn.ToString("#,##0.00########")

    End Sub

End Class