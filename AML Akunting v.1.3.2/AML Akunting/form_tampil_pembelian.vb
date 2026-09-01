Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_tampil_pembelian

    Private Sub isidgv()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbpembelian WHERE kode = '" & Txt_kode.Text & "' ORDER BY baris ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub isidgvinduk()
        Try
            dgv2.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE kode = '" & Txt_kode.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv2.DataSource = dsx.Tables("tbindukpembelian")
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_kode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_kode.TextChanged
        Call isidgvinduk()
        dtp_tanggal.Text = dgv2.Rows(0).Cells(1).Value.ToString
        txt_no_faktur.Text = dgv2.Rows(0).Cells(9).Value.ToString
        Cbo_Supplier.Text = dgv2.Rows(0).Cells(3).Value.ToString
        CboJenisBiaya.Text = dgv2.Rows(0).Cells(4).Value.ToString
        cbo_pembayaran.Text = dgv2.Rows(0).Cells(2).Value.ToString
        If Not dgv2.Rows(0).Cells(10).Value.ToString = "" Then
            dtp_tanggal_upload.Text = dgv2.Rows(0).Cells(10).Value.ToString
            Dim cultureInfo As New CultureInfo("id-ID")
            Dim selectedDate As DateTime = dtp_tanggal_upload.Value
            Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
            txt_tanggal_upload.Text = formattedDate
        End If
        Dim totalpolos As String = dgv2.Rows(0).Cells(5).Value.ToString
        Dim totaldpp As String = dgv2.Rows(0).Cells(6).Value.ToString
        Dim totalppn As String = dgv2.Rows(0).Cells(7).Value.ToString
        Dim grantotal As String = dgv2.Rows(0).Cells(8).Value.ToString
        Dim polos, dpp, ppn, gran As Decimal
        Decimal.TryParse(totalpolos, polos)
        Decimal.TryParse(totaldpp, dpp)
        Decimal.TryParse(totalppn, ppn)
        Decimal.TryParse(grantotal, gran)
        txt_gran_total.Text = gran.ToString("#,##0.00########")
        txt_total_polos.Text = polos.ToString("#,##0.00########")
        txt_total_dpp.Text = dpp.ToString("#,##0.00########")
        txt_total_ppn.Text = ppn.ToString("#,##0.00########")

        Call isidgv()
        Dim txt_specs As TextBox() = {txt_specs1, txt_specs2, txt_specs3, txt_specs4, txt_specs5, txt_specs6, txt_specs7, txt_specs8, txt_specs9, txt_specs10}
        Dim txt_jumlah As TextBox() = {txt_jumlah1, txt_jumlah2, txt_jumlah3, txt_jumlah4, txt_jumlah5, txt_jumlah6, txt_jumlah7, txt_jumlah8, txt_jumlah9, txt_jumlah10}
        Dim txt_harga As TextBox() = {txt_harga1, txt_harga2, txt_harga3, txt_harga4, txt_harga5, txt_harga6, txt_harga7, txt_harga8, txt_harga9, txt_harga10}
        Dim txt_total_dpp_all As TextBox() = {txt_total_dpp1, txt_total_dpp2, txt_total_dpp3, txt_total_dpp4, txt_total_dpp5, txt_total_dpp6, txt_total_dpp7, txt_total_dpp8, txt_total_dpp9, txt_total_dpp10}
        Dim txt_ppn As TextBox() = {txt_ppn1, txt_ppn2, txt_ppn3, txt_ppn4, txt_ppn5, txt_ppn6, txt_ppn7, txt_ppn8, txt_ppn9, txt_ppn10}
        Dim txt_total_harga As TextBox() = {txt_total_harga1, txt_total_harga2, txt_total_harga3, txt_total_harga4, txt_total_harga5, txt_total_harga6, txt_total_harga7, txt_total_harga8, txt_total_harga9, txt_total_harga10}
        For i As Integer = 0 To 9
            Try
                Dim row As DataGridViewRow = dgv1.Rows(i)
                txt_specs(i).Text = row.Cells(5).Value.ToString()
                Dim input1 As String = row.Cells(6).Value.ToString
                Dim input2 As String = row.Cells(7).Value.ToString
                Dim input3 As String = row.Cells(8).Value.ToString
                Dim input4 As String = row.Cells(9).Value.ToString
                Dim input5 As String = row.Cells(10).Value.ToString
                Dim number1, number2, number3, number4, number5 As Decimal
                Decimal.TryParse(input1, number1)
                Decimal.TryParse(input2, number2)
                Decimal.TryParse(input3, number3)
                Decimal.TryParse(input4, number4)
                Decimal.TryParse(input5, number5)
                txt_jumlah(i).Text = number1.ToString("#,##0.##")
                txt_harga(i).Text = number2.ToString("#,##0.00########")
                txt_total_dpp_all(i).Text = number3.ToString("#,##0.00########")
                txt_ppn(i).Text = number4.ToString("#,##0.00########")
                txt_total_harga(i).Text = number5.ToString("#,##0.00########")
                CboJenisBiaya.Text = dgv1.Rows(0).Cells(4).Value.ToString
            Catch ex As ArgumentOutOfRangeException
            End Try
        Next
        If Not txt_specs1.Text = "" Then
            cb_status1.Text = dgv1.Rows(0).Cells(13).Value.ToString
        End If
        If Not txt_specs2.Text = "" Then
            cb_status2.Text = dgv1.Rows(1).Cells(13).Value.ToString
        End If
        If Not txt_specs3.Text = "" Then
            cb_status3.Text = dgv1.Rows(2).Cells(13).Value.ToString
        End If
        If Not txt_specs4.Text = "" Then
            cb_status4.Text = dgv1.Rows(3).Cells(13).Value.ToString
        End If
        If Not txt_specs5.Text = "" Then
            cb_status5.Text = dgv1.Rows(4).Cells(13).Value.ToString
        End If
        If Not txt_specs6.Text = "" Then
            cb_status6.Text = dgv1.Rows(5).Cells(13).Value.ToString
        End If
        If Not txt_specs7.Text = "" Then
            cb_status7.Text = dgv1.Rows(6).Cells(13).Value.ToString
        End If
        If Not txt_specs8.Text = "" Then
            cb_status8.Text = dgv1.Rows(7).Cells(13).Value.ToString
        End If
        If Not txt_specs9.Text = "" Then
            cb_status9.Text = dgv1.Rows(8).Cells(13).Value.ToString
        End If
        If Not txt_specs10.Text = "" Then
            cb_status10.Text = dgv1.Rows(9).Cells(13).Value.ToString
        End If
    End Sub

End Class