Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_tampil_penjualan_celup
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

            dtp_tanggal.Text = dgv1.Rows(0).Cells(1).Value.ToString()
            txt_surat_jalan1.Text = dgv1.Rows(0).Cells(2).Value.ToString()
            txt_no_faktur1.Text = dgv1.Rows(0).Cells(3).Value.ToString()
            txt_client.Text = dgv1.Rows(0).Cells(4).Value.ToString()
            cb_nama_kain.Text = dgv1.Rows(0).Cells(6).Value.ToString()
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
            dpp_obat1 = number3

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
            tagihan1 = number5 + number4a
            transfer1 = number6a
            dpp_jasa1 = number2a

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
                dpp_obat2 = number3b

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
                tagihan2 = number5b + number4c
                transfer2 = number6c
                dpp_jasa2 = number2c
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
                dpp_obat3 = number3d

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
                tagihan3 = number5d + number4e
                transfer3 = number6e
                dpp_jasa3 = number2e
            End If
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

End Class