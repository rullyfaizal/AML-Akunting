Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_input_penjualan_celup

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

    Private Sub form_input_penjualan_celup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
        Dim dtptoday As New DateTimePicker
        Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
        Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
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
                Call hitungtotal()
                btn_hitung.Text = "EDIT"
                btn_simpan.Enabled = True
                Panel2.Enabled = False
            End If
        Else
            btn_hitung.Text = "HITUNG"
            btn_simpan.Enabled = False
            Panel2.Enabled = True
            'txt_total_sjx.Text = ""
            'txt_grand_total_transfer.Text = ""
            'txt_total_dpp_obat.Text = ""
            'txt_total_dpp_jasa.Text = ""
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
    End Sub
    Private Sub hitungtotal()
        Try
            Dim tagihan1, tagihan2, tagihan3 As Decimal
            tagihan1 = 0
            tagihan2 = 0
            tagihan3 = 0
            Dim transfer1, transfer2, transfer3 As Decimal
            transfer1 = 0
            transfer2 = 0
            transfer3 = 0
            Dim dpp_obat1, dpp_obat2, dpp_obat3 As Decimal
            dpp_obat1 = 0
            dpp_obat2 = 0
            dpp_obat3 = 0
            Dim dpp_jasa1, dpp_jasa2, dpp_jasa3 As Decimal
            dpp_jasa1 = 0
            dpp_jasa2 = 0
            dpp_jasa3 = 0

            Dim dppo1 As String = txt_total_dpp1.Text
            Dim dppo2 As String = txt_total_dpp2.Text
            Dim dppo3 As String = txt_total_dpp3.Text
            Dim dppo4 As String = txt_total_dpp4.Text
            Dim dppo5 As String = txt_total_dpp5.Text
            Dim dppo6 As String = txt_total_dpp6.Text
            Decimal.TryParse(dppo1, dpp_obat1)
            Decimal.TryParse(dppo2, dpp_jasa1)
            Decimal.TryParse(dppo3, dpp_obat2)
            Decimal.TryParse(dppo4, dpp_jasa2)
            Decimal.TryParse(dppo5, dpp_obat3)
            Decimal.TryParse(dppo6, dpp_jasa3)

            Dim tgh1 As String = txt_total_harga1.Text
            Dim tgh2 As String = txt_total_harga2.Text
            Dim tgh3 As String = txt_total_harga3.Text
            Dim tgh4 As String = txt_total_harga4.Text
            Dim tgh5 As String = txt_total_harga5.Text
            Dim tgh6 As String = txt_total_harga6.Text
            Dim tgh_d1, tgh_d2, tgh_d3, tgh_d4, tgh_d5, tgh_d6 As Decimal
            Decimal.TryParse(tgh1, tgh_d1)
            Decimal.TryParse(tgh2, tgh_d2)
            Decimal.TryParse(tgh3, tgh_d3)
            Decimal.TryParse(tgh4, tgh_d4)
            Decimal.TryParse(tgh5, tgh_d5)
            Decimal.TryParse(tgh6, tgh_d6)
            tagihan1 = tgh_d1 + tgh_d2
            tagihan2 = tgh_d3 + tgh_d4
            tagihan3 = tgh_d5 + tgh_d6

            Dim trf1 As String = txt_total_transfer.Text
            Dim trf2 As String = txt_total_transfer2.Text
            Dim trf3 As String = txt_total_transfer3.Text
            Decimal.TryParse(trf1, transfer1)
            Decimal.TryParse(trf2, transfer2)
            Decimal.TryParse(trf3, transfer3)

            Dim total_sjx, total_transfer, total_dpp_obat, total_dpp_jasa As Decimal
            total_sjx = tagihan1 + tagihan2 + tagihan3
            txt_total_sjx.Text = total_sjx.ToString("#,##0.00########")
            total_transfer = transfer1 + transfer2 + transfer3
            txt_grand_total_transfer.Text = total_transfer.ToString("#,##0.00########")
            total_dpp_obat = dpp_obat1 + dpp_obat2 + dpp_obat3
            txt_total_dpp_obat.Text = total_dpp_obat.ToString("#,##0.00########")
            total_dpp_jasa = dpp_jasa1 + dpp_jasa2 + dpp_jasa3
            txt_total_dpp_jasa.Text = total_dpp_jasa.ToString("#,##0.00########")

        Catch ex As ArgumentOutOfRangeException
            MsgBox("Data tidak dapat ditampilkan")
        End Try
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

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur1.Text)
                        .Parameters.AddWithValue("@4", txt_client.Text)
                        .Parameters.AddWithValue("@5", txt_jenis_biaya1.Text)
                        .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                        .Parameters.AddWithValue("@7", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@8", txt_harga1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@9", txt_total_dpp1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@10", txt_ppn1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_total_harga1.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", "")
                        .Parameters.AddWithValue("@13", "")
                        .Parameters.AddWithValue("@14", "")
                        .Parameters.AddWithValue("@15", "Kg")
                        .Parameters.AddWithValue("@16", "Celup")
                        .Parameters.AddWithValue("@17", 1)
                        .Parameters.AddWithValue("@18", Txt_kode.Text)
                        .ExecuteNonQuery()
                        dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    End With
                End Using
            End Using
            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                Using cmdy As New MySqlCommand(sqly, cony)
                    With cmdy
                        dtp_tanggal.CustomFormat = "yyyy/MM/dd"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("@1", dtp_tanggal.Text)
                        .Parameters.AddWithValue("@2", txt_surat_jalan1.Text)
                        .Parameters.AddWithValue("@3", txt_no_faktur2.Text)
                        .Parameters.AddWithValue("@4", txt_client.Text)
                        .Parameters.AddWithValue("@5", txt_jenis_biaya2.Text)
                        .Parameters.AddWithValue("@6", cbo_nama_kain.Text)
                        .Parameters.AddWithValue("@7", txt_jumlah.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@8", txt_harga2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@9", txt_total_dpp2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@10", txt_ppn2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@11", txt_total_harga2.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@12", txt_pph23.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@13", txt_total_transfer.Text.Replace(".", "").Replace(",", "."))
                        .Parameters.AddWithValue("@14", "")
                        .Parameters.AddWithValue("@15", "Kg")
                        .Parameters.AddWithValue("@16", "Celup")
                        .Parameters.AddWithValue("@17", 2)
                        .Parameters.AddWithValue("@18", Txt_kode.Text)
                        .ExecuteNonQuery()
                        dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                    End With
                End Using
            End Using
            If Not txt_jumlah2.Text = "" And Not txt_tagihan2.Text = "" Then
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
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
                            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                        End With
                    End Using
                End Using
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
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
                            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                        End With
                    End Using
                End Using
            End If
            If Not txt_jumlah3.Text = "" And Not txt_tagihan3.Text = "" Then
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
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
                            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                        End With
                    End Using
                End Using
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly = "INSERT INTO tbpenjualan (tanggal,surat_jalan,no_faktur,supplier,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18)"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        With cmdy
                            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
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
                            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
                        End With
                    End Using
                End Using
            End If
            MsgBox("PENJUALAN CELUP Baru Berhasil Disimpan")

            form_menu_utama.btn_hitung_bukpot.Visible = True
            form_menu_utama.btn_hitung_bukpot.PerformClick()

            form_penjualan.Show()
            form_penjualan.Focus()
            form_penjualan.ts_perbarui.PerformClick()

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class