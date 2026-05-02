Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_edit_penjualan_celup
    Private Sub isipenjualan()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' ORDER BY baris ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv1.DataSource = dsx.Tables("tbpenjualan")
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Txt_kode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_kode.TextChanged
        Call isipenjualan()
        Try
            dtp_tanggal.Text = dgv1.Rows(0).Cells(1).Value.ToString()
            txt_surat_jalan1.Text = dgv1.Rows(0).Cells(2).Value.ToString()
            txt_no_faktur1.Text = dgv1.Rows(0).Cells(3).Value.ToString()
            txt_client.Text = dgv1.Rows(0).Cells(4).Value.ToString()
            cbo_nama_kain.Text = dgv1.Rows(0).Cells(6).Value.ToString()
            Dim input1 As String = dgv1.Rows(0).Cells(7).Value.ToString()
            Dim input2 As String = dgv1.Rows(0).Cells(8).Value.ToString()
            Dim input3 As String = dgv1.Rows(0).Cells(9).Value.ToString()
            Dim input4 As String = dgv1.Rows(0).Cells(10).Value.ToString()
            Dim input5 As String = dgv1.Rows(0).Cells(11).Value.ToString()
            Dim number1, number2, number3, number4, number5 As Decimal
            Decimal.TryParse(input1, number1)
            Decimal.TryParse(input2, number2)
            Decimal.TryParse(input3, number3)
            Decimal.TryParse(input4, number4)
            Decimal.TryParse(input5, number5)
            txt_jumlah.Text = number1.ToString("#,##0.##")
            txt_harga1.Text = number2.ToString("#,##0.00########")
            txt_total_dpp1.Text = number3.ToString("#,##0.00########")
            txt_ppn1.Text = number4.ToString("#,##0.00########")
            txt_total_harga1.Text = number5.ToString("#,##0.00########")

            txt_no_faktur2.Text = dgv1.Rows(1).Cells(3).Value.ToString()
            Dim input1a As String = dgv1.Rows(1).Cells(8).Value.ToString()
            Dim input2a As String = dgv1.Rows(1).Cells(9).Value.ToString()
            Dim input3a As String = dgv1.Rows(1).Cells(10).Value.ToString()
            Dim input4a As String = dgv1.Rows(1).Cells(11).Value.ToString()
            Dim input5a As String = dgv1.Rows(1).Cells(12).Value.ToString()
            Dim input6a As String = dgv1.Rows(1).Cells(13).Value.ToString()
            Dim number1a, number2a, number3a, number4a, number5a, number6a As Decimal
            Decimal.TryParse(input1a, number1a)
            Decimal.TryParse(input2a, number2a)
            Decimal.TryParse(input3a, number3a)
            Decimal.TryParse(input4a, number4a)
            Decimal.TryParse(input5a, number5a)
            Decimal.TryParse(input6a, number6a)
            txt_harga2.Text = number1a.ToString("#,##0.00########")
            txt_total_dpp2.Text = number2a.ToString("#,##0.00########")
            txt_ppn2.Text = number3a.ToString("#,##0.00########")
            txt_total_harga2.Text = number4a.ToString("#,##0.00########")
            txt_pph23.Text = number5a.ToString("#,##0.00########")
            txt_total_transfer.Text = number6a.ToString("#,##0.00########")
            txt_tagihan.Text = (number5 + number4a).ToString("#,##0.00########")

            If dgv1.Rows.Count > 2 Then
                txt_no_faktur3.Text = dgv1.Rows(2).Cells(3).Value.ToString()
                Dim input1b As String = dgv1.Rows(2).Cells(7).Value.ToString()
                Dim input2b As String = dgv1.Rows(2).Cells(8).Value.ToString()
                Dim input3b As String = dgv1.Rows(2).Cells(9).Value.ToString()
                Dim input4b As String = dgv1.Rows(2).Cells(10).Value.ToString()
                Dim input5b As String = dgv1.Rows(2).Cells(11).Value.ToString()
                Dim number1b, number2b, number3b, number4b, number5b As Decimal
                Decimal.TryParse(input1b, number1b)
                Decimal.TryParse(input2b, number2b)
                Decimal.TryParse(input3b, number3b)
                Decimal.TryParse(input4b, number4b)
                Decimal.TryParse(input5b, number5b)
                txt_jumlah2.Text = number1b.ToString("#,##0.##")
                txt_harga3.Text = number2b.ToString("#,##0.00########")
                txt_total_dpp3.Text = number3b.ToString("#,##0.00########")
                txt_ppn3.Text = number4b.ToString("#,##0.00########")
                txt_total_harga3.Text = number5b.ToString("#,##0.00########")

                txt_no_faktur4.Text = dgv1.Rows(3).Cells(3).Value.ToString()
                Dim input1c As String = dgv1.Rows(3).Cells(8).Value.ToString()
                Dim input2c As String = dgv1.Rows(3).Cells(9).Value.ToString()
                Dim input3c As String = dgv1.Rows(3).Cells(10).Value.ToString()
                Dim input4c As String = dgv1.Rows(3).Cells(11).Value.ToString()
                Dim input5c As String = dgv1.Rows(3).Cells(12).Value.ToString()
                Dim input6c As String = dgv1.Rows(3).Cells(13).Value.ToString()
                Dim number1c, number2c, number3c, number4c, number5c, number6c As Decimal
                Decimal.TryParse(input1c, number1c)
                Decimal.TryParse(input2c, number2c)
                Decimal.TryParse(input3c, number3c)
                Decimal.TryParse(input4c, number4c)
                Decimal.TryParse(input5c, number5c)
                Decimal.TryParse(input6c, number6c)
                txt_harga4.Text = number1c.ToString("#,##0.00########")
                txt_total_dpp4.Text = number2c.ToString("#,##0.00########")
                txt_ppn4.Text = number3c.ToString("#,##0.00########")
                txt_total_harga4.Text = number4c.ToString("#,##0.00########")
                txt_pph232.Text = number5c.ToString("#,##0.00########")
                txt_total_transfer2.Text = number6c.ToString("#,##0.00########")
                txt_tagihan2.Text = (number5b + number4c).ToString("#,##0.00########")
            End If

            If dgv1.Rows.Count > 4 Then
                txt_no_faktur5.Text = dgv1.Rows(4).Cells(3).Value.ToString()
                Dim input1d As String = dgv1.Rows(4).Cells(7).Value.ToString()
                Dim input2d As String = dgv1.Rows(4).Cells(8).Value.ToString()
                Dim input3d As String = dgv1.Rows(4).Cells(9).Value.ToString()
                Dim input4d As String = dgv1.Rows(4).Cells(10).Value.ToString()
                Dim input5d As String = dgv1.Rows(4).Cells(11).Value.ToString()
                Dim number1d, number2d, number3d, number4d, number5d As Decimal
                Decimal.TryParse(input1d, number1d)
                Decimal.TryParse(input2d, number2d)
                Decimal.TryParse(input3d, number3d)
                Decimal.TryParse(input4d, number4d)
                Decimal.TryParse(input5d, number5d)
                txt_jumlah3.Text = number1d.ToString("#,##0.##")
                txt_harga5.Text = number2d.ToString("#,##0.00########")
                txt_total_dpp5.Text = number3d.ToString("#,##0.00########")
                txt_ppn5.Text = number4d.ToString("#,##0.00########")
                txt_total_harga5.Text = number5d.ToString("#,##0.00########")

                txt_no_faktur6.Text = dgv1.Rows(5).Cells(3).Value.ToString()
                Dim input1e As String = dgv1.Rows(5).Cells(8).Value.ToString()
                Dim input2e As String = dgv1.Rows(5).Cells(9).Value.ToString()
                Dim input3e As String = dgv1.Rows(5).Cells(10).Value.ToString()
                Dim input4e As String = dgv1.Rows(5).Cells(11).Value.ToString()
                Dim input5e As String = dgv1.Rows(5).Cells(12).Value.ToString()
                Dim input6e As String = dgv1.Rows(5).Cells(13).Value.ToString()
                Dim number1e, number2e, number3e, number4e, number5e, number6e As Decimal
                Decimal.TryParse(input1e, number1e)
                Decimal.TryParse(input2e, number2e)
                Decimal.TryParse(input3e, number3e)
                Decimal.TryParse(input4e, number4e)
                Decimal.TryParse(input5e, number5e)
                Decimal.TryParse(input6e, number6e)
                txt_harga6.Text = number1e.ToString("#,##0.00########")
                txt_total_dpp6.Text = number2e.ToString("#,##0.00########")
                txt_ppn6.Text = number3e.ToString("#,##0.00########")
                txt_total_harga6.Text = number4e.ToString("#,##0.00########")
                txt_pph233.Text = number5e.ToString("#,##0.00########")
                txt_total_transfer3.Text = number6e.ToString("#,##0.00########")
                txt_tagihan3.Text = (number5d + number4e).ToString("#,##0.00########")
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim ppn, pph23 As Double
    Private Sub isi_ppn()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT ppn,pph23 from tbppn WHERE id ='ppn'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        ppn = drx(0)
                        pph23 = drx(1)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub isicboclient()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT nama From tbclient ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_client.DataSource = dsx.Tables("tbclient")
                            Call headertableclient()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub headertableclient()
        dgv_client.ColumnHeadersVisible = False
        dgv_client.RowHeadersVisible = False
        dgv_client.Columns(0).Width = 300
    End Sub
    Private Sub cariclient()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama From tbclient WHERE nama like '%" & txt_client.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_client.DataSource = dsx.Tables("tbclient")
                            Call headertableclient()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_client_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_client.GotFocus
        If txt_client.Text = "" Then
            Call isicboclient()
        Else
            Call cariclient()
        End If
        dgv_client.Visible = True
    End Sub
    Private Sub txt_client_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_client.TextChanged
        If txt_client.Text = "" Then
            Call isicboclient()
        Else
            Call cariclient()
        End If
    End Sub
    Private Sub dgv_client_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_client.CellMouseClick
        Try
            Dim i As Integer
            i = Me.dgv_client.CurrentRow.Index
            With dgv_client.Rows.Item(i)
                txt_client.Text = dgv_client.Rows(i).Cells(0).Value
            End With
            btn_client.Focus()
            dgv_client.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub btn_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_client.Click
        btn_client.Focus()
        dgv_client.Visible = False
        txt_client.Text = ""
    End Sub

    Private Sub cbo_nama_kain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_nama_kain.KeyPress
        If Not e.KeyChar = Chr(13) Then e.Handled = True
    End Sub
    Private Sub txt_jumlah_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_jumlah.LostFocus
        Dim input As String = txt_jumlah.Text
        Dim number As Decimal
        If Not txt_jumlah.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_jumlah.Text = number.ToString("#,##0.##")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_jumlah.Focus()
            End If
        End If
    End Sub
    Private Sub txt_jumlah2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_jumlah2.LostFocus
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
    Private Sub txt_jumlah3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_jumlah3.LostFocus
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
    Private Sub txt_tagihan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tagihan.LostFocus
        Dim input As String = txt_tagihan.Text
        Dim number As Decimal
        If Not txt_tagihan.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_tagihan.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_tagihan.Focus()
            End If
        End If
    End Sub
    Private Sub txt_tagihan2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tagihan2.LostFocus
        Dim input As String = txt_tagihan2.Text
        Dim number As Decimal
        If Not txt_tagihan2.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_tagihan2.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_tagihan2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_tagihan3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tagihan3.LostFocus
        Dim input As String = txt_tagihan3.Text
        Dim number As Decimal
        If Not txt_tagihan3.Text = "" Then
            If Decimal.TryParse(input, number) Then
                txt_tagihan3.Text = number.ToString("#,##0.00########")
            Else
                MessageBox.Show("Input harus berupa angka dengan format yang benar", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_tagihan3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_no_faktur1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur1.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur1.SelectionStart
        If txt_no_faktur1.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur1.Text = txt_no_faktur1.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur1.Text = txt_no_faktur1.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur1.Text = txt_no_faktur1.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur1.SelectionStart = cursorPosition
        'End If
    End Sub
    Private Sub txt_no_faktur2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur2.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur2.SelectionStart
        If txt_no_faktur2.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur2.Text = txt_no_faktur2.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur2.Text = txt_no_faktur2.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur2.Text = txt_no_faktur2.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur2.SelectionStart = cursorPosition
        'End If
    End Sub
    Private Sub txt_no_faktur3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur3.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur3.SelectionStart
        If txt_no_faktur3.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur3.Text = txt_no_faktur3.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur3.Text = txt_no_faktur3.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur3.Text = txt_no_faktur3.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur3.SelectionStart = cursorPosition
        'End If
    End Sub
    Private Sub txt_no_faktur4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur4.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur4.SelectionStart
        If txt_no_faktur4.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur4.Text = txt_no_faktur4.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur4.Text = txt_no_faktur4.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur4.Text = txt_no_faktur4.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur4.SelectionStart = cursorPosition
        'End If
    End Sub
    Private Sub txt_no_faktur5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur5.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur5.SelectionStart
        If txt_no_faktur5.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur5.Text = txt_no_faktur5.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur5.Text = txt_no_faktur5.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur5.Text = txt_no_faktur5.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur5.SelectionStart = cursorPosition
        'End If
    End Sub
    Private Sub txt_no_faktur6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_no_faktur6.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim cursorPosition As Integer = txt_no_faktur6.SelectionStart
        If txt_no_faktur6.Text.Length >= My.Settings.panjangfp AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        'If Char.IsDigit(e.KeyChar) Then
        '    Select Case cursorPosition
        '        Case 2, 9
        '            txt_no_faktur6.Text = txt_no_faktur6.Text.Insert(cursorPosition, e.KeyChar & ".")
        '            cursorPosition += 2
        '        Case 6
        '            txt_no_faktur6.Text = txt_no_faktur6.Text.Insert(cursorPosition, e.KeyChar & "-")
        '            cursorPosition += 2
        '        Case Else
        '            txt_no_faktur6.Text = txt_no_faktur6.Text.Insert(cursorPosition, e.KeyChar.ToString())
        '            cursorPosition += 1
        '    End Select
        '    e.Handled = True
        '    txt_no_faktur6.SelectionStart = cursorPosition
        'End If
    End Sub

    Private Sub btn_hitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung.Click
        If btn_hitung.Text = "HITUNG" Then
            If txt_client.Text = "" Then
                MsgBox("Nama CLIENT belum dipilih")
                txt_client.Focus()
            ElseIf cbo_nama_kain.Text = "" Then
                MsgBox("NAMA KAIN belum dipilih")
                cbo_nama_kain.Focus()
            ElseIf txt_tagihan.Text = "" Then
                MsgBox("Nilai TAGIHAN belum diinput")
                txt_tagihan.Focus()
            ElseIf txt_jumlah.Text = "" Then
                MsgBox("QTY belum diinput")
                txt_jumlah.Focus()
            Else
                Call hitung()
                btn_hitung.Text = "EDIT"
                btn_simpan.Enabled = True
                Panel2.Enabled = False
            End If
        Else
            btn_hitung.Text = "HITUNG"
            btn_simpan.Enabled = False
            Panel2.Enabled = True
        End If
    End Sub

    Private Sub hitung()
        Dim tagihan, jumlah, hargaobat, hargajasa, dpp, dppobat, dppjasa, total23, ppnobat, ppnjasa, grandtotalobat, grandtotaljasa, transfer As Double

        tagihan = txt_tagihan.Text.Replace(".", "")
        jumlah = txt_jumlah.Text.Replace(".", "")

        dpp = tagihan / (1 + (ppn / 100))
        dppobat = 0.85 * dpp
        dppjasa = 0.15 * dpp
        hargaobat = dppobat / jumlah
        hargajasa = dppjasa / jumlah
        total23 = (pph23 / 100) * dppjasa
        ppnobat = (ppn / 100) * dppobat
        ppnjasa = (ppn / 100) * dppjasa
        grandtotalobat = dppobat + ppnobat
        grandtotaljasa = dppjasa + ppnjasa
        transfer = grandtotalobat + grandtotaljasa - total23

        TextBox1.Text = dpp.ToString("#,##0.00########")
        txt_total_dpp1.Text = dppobat.ToString("#,##0.00########")
        txt_total_dpp2.Text = dppjasa.ToString("#,##0.00########")
        txt_harga1.Text = hargaobat.ToString("#,##0.00########")
        txt_harga2.Text = hargajasa.ToString("#,##0.00########")
        txt_pph23.Text = total23.ToString("#,##0.00########")
        txt_ppn1.Text = ppnobat.ToString("#,##0.00########")
        txt_ppn2.Text = ppnjasa.ToString("#,##0.00########")
        txt_total_harga1.Text = grandtotalobat.ToString("#,##0.00########")
        txt_total_harga2.Text = grandtotaljasa.ToString("#,##0.00########")
        txt_total_transfer.Text = transfer.ToString("#,##0.00########")

        If Not txt_jumlah2.Text = "" And Not txt_tagihan2.Text = "" Then
            Dim tagihan2, jumlah2, hargaobat2, hargajasa2, dpp2, dppobat2, dppjasa2, total232, ppnobat2, ppnjasa2, grandtotalobat2, grandtotaljasa2, transfer2 As Double

            tagihan2 = txt_tagihan2.Text.Replace(".", "")
            jumlah2 = txt_jumlah2.Text.Replace(".", "")

            dpp2 = tagihan2 / (1 + (ppn / 100))
            dppobat2 = 0.85 * dpp2
            dppjasa2 = 0.15 * dpp2
            hargaobat2 = dppobat2 / jumlah2
            hargajasa2 = dppjasa2 / jumlah2
            total232 = (pph23 / 100) * dppjasa2
            ppnobat2 = (ppn / 100) * dppobat2
            ppnjasa2 = (ppn / 100) * dppjasa2
            grandtotalobat2 = dppobat2 + ppnobat2
            grandtotaljasa2 = dppjasa2 + ppnjasa2
            transfer2 = grandtotalobat2 + grandtotaljasa2 - total232

            'TextBox1.Text = dpp.ToString("#,##0.00########")
            txt_total_dpp3.Text = dppobat2.ToString("#,##0.00########")
            txt_total_dpp4.Text = dppjasa2.ToString("#,##0.00########")
            txt_harga3.Text = hargaobat2.ToString("#,##0.00########")
            txt_harga4.Text = hargajasa2.ToString("#,##0.00########")
            txt_pph232.Text = total232.ToString("#,##0.00########")
            txt_ppn3.Text = ppnobat2.ToString("#,##0.00########")
            txt_ppn4.Text = ppnjasa2.ToString("#,##0.00########")
            txt_total_harga3.Text = grandtotalobat2.ToString("#,##0.00########")
            txt_total_harga4.Text = grandtotaljasa2.ToString("#,##0.00########")
            txt_total_transfer2.Text = transfer2.ToString("#,##0.00########")

        End If
        If Not txt_jumlah3.Text = "" And Not txt_tagihan3.Text = "" Then
            Dim tagihan3, jumlah3, hargaobat3, hargajasa3, dpp3, dppobat3, dppjasa3, total233, ppnobat3, ppnjasa3, grandtotalobat3, grandtotaljasa3, transfer3 As Double

            tagihan3 = txt_tagihan3.Text.Replace(".", "")
            jumlah3 = txt_jumlah3.Text.Replace(".", "")

            dpp3 = tagihan3 / (1 + (ppn / 100))
            dppobat3 = 0.85 * dpp3
            dppjasa3 = 0.15 * dpp3
            hargaobat3 = dppobat3 / jumlah3
            hargajasa3 = dppjasa3 / jumlah3
            total233 = (pph23 / 100) * dppjasa3
            ppnobat3 = (ppn / 100) * dppobat3
            ppnjasa3 = (ppn / 100) * dppjasa3
            grandtotalobat3 = dppobat3 + ppnobat3
            grandtotaljasa3 = dppjasa3 + ppnjasa3
            transfer3 = grandtotalobat3 + grandtotaljasa3 - total233

            'TextBox1.Text = dpp.ToString("#,##0.00########")
            txt_total_dpp5.Text = dppobat3.ToString("#,##0.00########")
            txt_total_dpp6.Text = dppjasa3.ToString("#,##0.00########")
            txt_harga5.Text = hargaobat3.ToString("#,##0.00########")
            txt_harga6.Text = hargajasa3.ToString("#,##0.00########")
            txt_pph233.Text = total233.ToString("#,##0.00########")
            txt_ppn5.Text = ppnobat3.ToString("#,##0.00########")
            txt_ppn6.Text = ppnjasa3.ToString("#,##0.00########")
            txt_total_harga5.Text = grandtotalobat3.ToString("#,##0.00########")
            txt_total_harga6.Text = grandtotaljasa3.ToString("#,##0.00########")
            txt_total_transfer3.Text = transfer3.ToString("#,##0.00########")
        End If

        If txt_jumlah2.Text = "" Or txt_tagihan2.Text = "" Then
            txt_tagihan2.Text = ""
            txt_jumlah2.Text = ""
            txt_no_faktur3.Text = ""
            txt_no_faktur4.Text = ""
            txt_harga3.Text = ""
            txt_harga4.Text = ""
            txt_total_dpp3.Text = ""
            txt_total_dpp4.Text = ""
            txt_ppn3.Text = ""
            txt_ppn4.Text = ""
            txt_total_harga3.Text = ""
            txt_total_harga4.Text = ""
            txt_pph232.Text = ""
            txt_total_transfer2.Text = ""
        End If

        If txt_jumlah3.Text = "" Or txt_tagihan3.Text = "" Then
            txt_tagihan3.Text = ""
            txt_jumlah3.Text = ""
            txt_no_faktur5.Text = ""
            txt_no_faktur6.Text = ""
            txt_harga5.Text = ""
            txt_harga6.Text = ""
            txt_total_dpp5.Text = ""
            txt_total_dpp6.Text = ""
            txt_ppn5.Text = ""
            txt_ppn6.Text = ""
            txt_total_harga5.Text = ""
            txt_total_harga6.Text = ""
            txt_pph233.Text = ""
            txt_total_transfer3.Text = ""
        End If
    End Sub

    Private Sub form_edit_penjualan_celup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10 WHERE kode = '" & Txt_kode.Text & "' AND baris=1"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur1.Text)
                        .Parameters.AddWithValue("@4", txt_client.Text)
                        .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                        .Parameters.AddWithValue("@6", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@7", txt_harga1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@8", txt_total_dpp1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@9", txt_ppn1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@10", txt_total_harga1.Text.Replace(".", "").Replace(",", "."))
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10,pph23=@11,transfer=@12 WHERE kode = '" & Txt_kode.Text & "' AND baris=2"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur2.Text)
                        .Parameters.AddWithValue("@4", txt_client.Text)
                        .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                        .Parameters.AddWithValue("@6", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@7", txt_harga2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@8", txt_total_dpp2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@9", txt_ppn2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@10", txt_total_harga2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_pph23.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", txt_total_transfer.Text.Replace(".", "").Replace(",", "."))
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT id_jual FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=3"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            If txt_jumlah2.Text = "" And txt_tagihan2.Text = "" Then
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "DELETE FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=3"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "DELETE FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=4"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10 WHERE kode = '" & Txt_kode.Text & "' AND baris=3"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur3.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@6", txt_jumlah2.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_harga3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_total_dpp3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_ppn3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_total_harga3.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10,pph23=@11,transfer=@12 WHERE kode = '" & Txt_kode.Text & "' AND baris=4"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur4.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@6", txt_jumlah2.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_harga4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_total_dpp4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_ppn4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_total_harga4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_pph232.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", txt_total_transfer2.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                            End If
                        Else
                            If Not txt_jumlah2.Text = "" And Not txt_tagihan2.Text = "" Then
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur3.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", txt_jenis_biaya3.Text)
                                            .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@7", txt_jumlah2.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_harga3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_total_dpp3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_ppn3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_total_harga3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", "")
                                            .Parameters.AddWithValue("@13", "")
                                            .Parameters.AddWithValue("@14", "")
                                            .Parameters.AddWithValue("@15", "Kg")
                                            .Parameters.AddWithValue("@16", "Celup")
                                            .Parameters.AddWithValue("@17", 3)
                                            .Parameters.AddWithValue("@18", Txt_kode.Text)
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur4.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", txt_jenis_biaya4.Text)
                                            .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@7", txt_jumlah2.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_harga4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_total_dpp4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_ppn4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_total_harga4.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", txt_pph232.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@13", txt_total_transfer2.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@14", "")
                                            .Parameters.AddWithValue("@15", "Kg")
                                            .Parameters.AddWithValue("@16", "Celup")
                                            .Parameters.AddWithValue("@17", 4)
                                            .Parameters.AddWithValue("@18", Txt_kode.Text)
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                            End If
                        End If
                    End Using
                End Using
            End Using
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT id_jual FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=5"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            If txt_jumlah3.Text = "" And txt_tagihan3.Text = "" Then
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "DELETE FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=5"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "DELETE FROM tbpenjualan WHERE kode = '" & Txt_kode.Text & "' AND baris=6"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        cmdy.ExecuteNonQuery()
                                    End Using
                                End Using
                            Else
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10 WHERE kode = '" & Txt_kode.Text & "' AND baris=5"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur5.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@6", txt_jumlah3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_harga5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_total_dpp5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_ppn5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_total_harga5.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "UPDATE tbpenjualan SET tanggal=@1,surat_jalan=@2,no_faktur=@3,supplier=@4,nama_kain=@5,jumlah=@6,harga=@7,dpp=@8,ppn=@9,total=@10,pph23=@11,transfer=@12 WHERE kode = '" & Txt_kode.Text & "' AND baris=6"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur6.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@6", txt_jumlah3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@7", txt_harga6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_total_dpp6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_ppn6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_total_harga6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_pph233.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", txt_total_transfer3.Text.Replace(".", "").Replace(",", "."))
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                            End If
                        Else
                            If Not txt_jumlah3.Text = "" And Not txt_tagihan3.Text = "" Then
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur5.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", txt_jenis_biaya5.Text)
                                            .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@7", txt_jumlah3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_harga5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_total_dpp5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_ppn5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_total_harga5.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", "")
                                            .Parameters.AddWithValue("@13", "")
                                            .Parameters.AddWithValue("@14", "")
                                            .Parameters.AddWithValue("@15", "Kg")
                                            .Parameters.AddWithValue("@16", "Celup")
                                            .Parameters.AddWithValue("@17", 5)
                                            .Parameters.AddWithValue("@18", Txt_kode.Text)
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                                Using cony As New MySqlConnection(sLocalConn)
                                    cony.Open()
                                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                                    Using cmdy As New MySqlCommand(sqly, cony)
                                        With cmdy
                                            .Parameters.Clear()
                                            .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                                            .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                                            .Parameters.AddWithValue("@3", txt_no_faktur6.Text)
                                            .Parameters.AddWithValue("@4", txt_client.Text)
                                            .Parameters.AddWithValue("@5", txt_jenis_biaya6.Text)
                                            .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                                            .Parameters.AddWithValue("@7", txt_jumlah3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@8", txt_harga6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@9", txt_total_dpp6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@10", txt_ppn6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@11", txt_total_harga6.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@12", txt_pph233.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@13", txt_total_transfer3.Text.Replace(".", "").Replace(",", "."))
                                            .Parameters.AddWithValue("@14", "")
                                            .Parameters.AddWithValue("@15", "Kg")
                                            .Parameters.AddWithValue("@16", "Celup")
                                            .Parameters.AddWithValue("@17", 6)
                                            .Parameters.AddWithValue("@18", Txt_kode.Text)
                                            .ExecuteNonQuery()
                                        End With
                                    End Using
                                End Using
                            End If
                        End If
                    End Using
                End Using
            End Using

            MsgBox("PENJUALAN CELUP Berhasil Di UPDATE")

            form_menu_utama.btn_hitung_bukpot.Visible = True
            form_menu_utama.btn_hitung_bukpot.PerformClick()

            form_penjualan.Show()
            form_penjualan.Focus()
            form_penjualan.btn_cari.PerformClick()
            Me.Close()
            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class