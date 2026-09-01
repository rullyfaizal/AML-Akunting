Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_hapus_pembelian

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
                            Call atur_dgv()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub atur_dgv()
        dgv1.Columns(5).HeaderText = "NAMA/SPECS"
        dgv1.Columns(6).HeaderText = "JUMLAH"
        dgv1.Columns(7).HeaderText = "HARGA/DPP (Rp)"
        dgv1.Columns(8).HeaderText = "TOTAL DPP (Rp)"
        dgv1.Columns(9).HeaderText = "PPN (Rp)"
        dgv1.Columns(10).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(5).Width = 350
        dgv1.Columns(6).Width = 90
        dgv1.Columns(7).Width = 150
        dgv1.Columns(8).Width = 150
        dgv1.Columns(9).Width = 150
        dgv1.Columns(10).Width = 150
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.##"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).Visible = False
        dgv1.Columns(2).Visible = False
        dgv1.Columns(3).Visible = False
        dgv1.Columns(4).Visible = False
        dgv1.Columns(11).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(13).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
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
        Dim txt_jumlah_asal As TextBox() = {txt_jumlah_asal1, txt_jumlah_asal2, txt_jumlah_asal3, txt_jumlah_asal4, txt_jumlah_asal5, txt_jumlah_asal6, txt_jumlah_asal7, txt_jumlah_asal8, txt_jumlah_asal9, txt_jumlah_asal10}
        Dim txt_id_beli As TextBox() = {txt_id_beli1, txt_id_beli2, txt_id_beli3, txt_id_beli4, txt_id_beli5, txt_id_beli6, txt_id_beli7, txt_id_beli8, txt_id_beli9, txt_id_beli10}
        For i As Integer = 0 To 9
            Try
                Dim row As DataGridViewRow = dgv1.Rows(i)
                txt_id_beli(i).Text = row.Cells(0).Value.ToString()
                Dim input1 As String = row.Cells(6).Value.ToString
                Dim number1 As Decimal
                Decimal.TryParse(input1, number1)
                txt_jumlah_asal(i).Text = number1
            Catch ex As ArgumentOutOfRangeException
            End Try
        Next
    End Sub

    Private Sub form_hapus_pembelian_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Panel2.Enabled = False
    End Sub

    Private Sub hapus_history_grey_baris1()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli1.Text & "' AND stok_masuk='" & txt_jumlah_asal1.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli1.Text & "' AND stok_masuk='" & txt_jumlah_asal1.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris2()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli2.Text & "' AND stok_masuk='" & txt_jumlah_asal2.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli2.Text & "' AND stok_masuk='" & txt_jumlah_asal2.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris3()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli3.Text & "' AND stok_masuk='" & txt_jumlah_asal3.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli3.Text & "' AND stok_masuk='" & txt_jumlah_asal3.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris4()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli4.Text & "' AND stok_masuk='" & txt_jumlah_asal4.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli4.Text & "' AND stok_masuk='" & txt_jumlah_asal4.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris5()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli5.Text & "' AND stok_masuk='" & txt_jumlah_asal5.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli5.Text & "' AND stok_masuk='" & txt_jumlah_asal5.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris6()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli6.Text & "' AND stok_masuk='" & txt_jumlah_asal6.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli6.Text & "' AND stok_masuk='" & txt_jumlah_asal6.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris7()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli7.Text & "' AND stok_masuk='" & txt_jumlah_asal7.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli7.Text & "' AND stok_masuk='" & txt_jumlah_asal7.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris8()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli8.Text & "' AND stok_masuk='" & txt_jumlah_asal8.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli8.Text & "' AND stok_masuk='" & txt_jumlah_asal8.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris9()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli9.Text & "' AND stok_masuk='" & txt_jumlah_asal9.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli9.Text & "' AND stok_masuk='" & txt_jumlah_asal9.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_history_grey_baris10()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbhistorygrey WHERE id_beli='" & txt_id_beli10.Text & "' AND stok_masuk='" & txt_jumlah_asal10.Text.Replace(",", ".") & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbhistorygrey WHERE id_beli='" & txt_id_beli10.Text & "' AND stok_masuk='" & txt_jumlah_asal10.Text.Replace(",", ".") & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub hapus_grey_baris1()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli1.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli1.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris2()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli2.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli2.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris3()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli3.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli3.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris4()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli4.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli4.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris5()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli5.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli5.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris6()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli6.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli6.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris7()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli7.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli7.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris8()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli8.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli8.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris9()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli9.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli9.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub hapus_grey_baris10()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx = "SELECT id_beli FROM tbgrey WHERE id_beli='" & txt_id_beli10.Text & "'"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using drx As MySqlDataReader = cmdx.ExecuteReader
                    drx.Read()
                    If drx.HasRows Then
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "DELETE FROM tbgrey WHERE id_beli='" & txt_id_beli10.Text & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End Using
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT kode FROM tbindukpembelian WHERE kode='" & Txt_kode.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using drx As MySqlDataReader = cmdx.ExecuteReader
                        drx.Read()
                        If drx.HasRows Then
                            If CboJenisBiaya.Text = "GREY" Then
                                Using cona As New MySqlConnection(sLocalConn)
                                    cona.Open()
                                    Dim sqla = "SELECT kode FROM tbgrey WHERE kode='" & Txt_kode.Text & "'"
                                    Using cmda As New MySqlCommand(sqla, cona)
                                        Using dra As MySqlDataReader = cmda.ExecuteReader
                                            dra.Read()
                                            If dra.HasRows Then
                                                MsgBox("Data Pembelian GREY sudah Masuk Stok GREY, Hapus terlebih dahulu Stok GREY untuk bisa menghapus data pembelian ini")
                                            Else
                                                If MsgBox("Yakin PEMBELIAN GREY Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                                    Using cony As New MySqlConnection(sLocalConn)
                                                        cony.Open()
                                                        Dim sqly = "DELETE FROM tbindukpembelian WHERE kode='" & Txt_kode.Text & "'"
                                                        Using cmdy As New MySqlCommand(sqly, cony)
                                                            cmdy.ExecuteNonQuery()
                                                        End Using
                                                    End Using
                                                    Using cony As New MySqlConnection(sLocalConn)
                                                        cony.Open()
                                                        Dim sqly = "SELECT kode FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                                        Using cmdy As New MySqlCommand(sqly, cony)
                                                            Using dry As MySqlDataReader = cmdy.ExecuteReader
                                                                dry.Read()
                                                                If dry.HasRows Then
                                                                    Using conz As New MySqlConnection(sLocalConn)
                                                                        conz.Open()
                                                                        Dim sqlz = "DELETE FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                                                        Using cmdz As New MySqlCommand(sqlz, conz)
                                                                            cmdz.ExecuteNonQuery()
                                                                        End Using
                                                                    End Using
                                                                End If
                                                            End Using
                                                        End Using
                                                    End Using
                                                    Call hapus_history_grey_baris1()
                                                    Call hapus_history_grey_baris2()
                                                    Call hapus_history_grey_baris3()
                                                    Call hapus_history_grey_baris4()
                                                    Call hapus_history_grey_baris5()
                                                    Call hapus_history_grey_baris6()
                                                    Call hapus_history_grey_baris7()
                                                    Call hapus_history_grey_baris8()
                                                    Call hapus_history_grey_baris9()
                                                    Call hapus_history_grey_baris10()
                                                    Call hapus_grey_baris1()
                                                    Call hapus_grey_baris2()
                                                    Call hapus_grey_baris3()
                                                    Call hapus_grey_baris4()
                                                    Call hapus_grey_baris5()
                                                    Call hapus_grey_baris6()
                                                    Call hapus_grey_baris7()
                                                    Call hapus_grey_baris8()
                                                    Call hapus_grey_baris9()
                                                    Call hapus_grey_baris10()
                                                    MessageBox.Show("PEMBELIAN berhasil di Hapus", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                End If
                                            End If
                                        End Using
                                    End Using
                                End Using
                            ElseIf CboJenisBiaya.Text = "RETUR" Then
                                If MsgBox("Yakin RETUR PEMBELIAN GREY Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbindukpembelian WHERE kode='" & Txt_kode.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                    End Using
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "SELECT kode FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            Using dry As MySqlDataReader = cmdy.ExecuteReader
                                                dry.Read()
                                                If dry.HasRows Then
                                                    Using conz As New MySqlConnection(sLocalConn)
                                                        conz.Open()
                                                        Dim sqlz = "DELETE FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                                        Using cmdz As New MySqlCommand(sqlz, conz)
                                                            cmdz.ExecuteNonQuery()
                                                        End Using
                                                    End Using
                                                End If
                                            End Using
                                        End Using
                                    End Using

                                    'Update tbgrey
                                    Dim stok_keluar, stok_akhir, harga_jual As Decimal
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbgrey WHERE no_faktur = '" & txt_no_faktur.Text & "' AND supplier = '" & Cbo_Supplier.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            Using reader As MySqlDataReader = cmdy.ExecuteReader()
                                                If reader.HasRows Then
                                                    While reader.Read()
                                                        stok_keluar = Convert.ToDecimal(reader("stok_keluar"))
                                                        stok_akhir = Convert.ToDecimal(reader("stok_akhir"))
                                                        harga_jual = Convert.ToDecimal(reader("harga_jual"))
                                                    End While
                                                End If
                                            End Using
                                        End Using
                                    End Using
                                    Dim keluar, dpp_jual As Decimal
                                    Decimal.TryParse(txt_jumlah_asal1.Text, keluar)
                                    stok_keluar = stok_keluar - keluar
                                    stok_akhir = stok_akhir + keluar
                                    dpp_jual = Math.Round(harga_jual * stok_akhir, 10)
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "UPDATE tbgrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE no_faktur = '" & txt_no_faktur.Text & "' AND supplier = '" & Cbo_Supplier.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            With cmdy
                                                .Parameters.Clear()
                                                .Parameters.AddWithValue("@1", stok_keluar)
                                                .Parameters.AddWithValue("@2", stok_akhir)
                                                .Parameters.AddWithValue("@3", dpp_jual)
                                                .ExecuteNonQuery()
                                            End With
                                        End Using
                                    End Using

                                    'update tbneracagrey
                                    Dim kode_neraca As String = ""
                                    Using cona As New MySqlConnection(sLocalConn)
                                        cona.Open()
                                        Dim sqla As String = "SELECT kode_neraca FROM tbhistorygrey WHERE no_faktur = '" & txt_no_faktur.Text & "' AND supplier = '" & Cbo_Supplier.Text & "'"
                                        Using cmda As New MySqlCommand(sqla, cona)
                                            Using dra As MySqlDataReader = cmda.ExecuteReader
                                                If dra.Read() Then
                                                    kode_neraca = dra("kode_neraca").ToString()
                                                End If
                                            End Using
                                        End Using
                                    End Using
                                    'Dim stok_keluar, stok_akhir, harga_jual As Decimal
                                    Dim ref_stok As Decimal = 0
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly As String = "SELECT stok_keluar,stok_akhir,harga_jual FROM tbneracagrey WHERE kode_neraca = '" & kode_neraca & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            Using reader As MySqlDataReader = cmdy.ExecuteReader()
                                                If reader.HasRows Then
                                                    While reader.Read()
                                                        stok_keluar = Convert.ToDecimal(reader("stok_keluar"))
                                                        stok_akhir = Convert.ToDecimal(reader("stok_akhir"))
                                                        harga_jual = Convert.ToDecimal(reader("harga_jual"))
                                                        ref_stok = Convert.ToDecimal(reader("stok_keluar"))
                                                    End While
                                                End If
                                            End Using
                                        End Using
                                    End Using
                                    'Dim keluar, dpp_jual As Decimal
                                    'Decimal.TryParse(txt_jumlah_retur.Text, keluar)

                                    stok_keluar = stok_keluar - keluar
                                    stok_akhir = stok_akhir + keluar
                                    dpp_jual = Math.Round(harga_jual * stok_akhir, 10)

                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "UPDATE tbneracagrey SET stok_keluar=@1,stok_akhir=@2,dpp_jual=@3 WHERE kode_neraca = '" & kode_neraca & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            With cmdy
                                                .Parameters.Clear()
                                                .Parameters.AddWithValue("@1", stok_keluar)
                                                .Parameters.AddWithValue("@2", stok_akhir)
                                                .Parameters.AddWithValue("@3", dpp_jual)
                                                .ExecuteNonQuery()
                                            End With
                                        End Using
                                    End Using

                                    'hapus tbhistorygrey
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbhistorygrey WHERE kode_neraca = '" & kode_neraca & "' AND stok_keluar='" & ref_stok & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                    End Using
                                End If
                            Else
                                If MsgBox("Yakin PEMBELIAN Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbindukpembelian WHERE kode='" & Txt_kode.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                    End Using
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "SELECT kode FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            Using dry As MySqlDataReader = cmdy.ExecuteReader
                                                dry.Read()
                                                If dry.HasRows Then
                                                    Using conz As New MySqlConnection(sLocalConn)
                                                        conz.Open()
                                                        Dim sqlz = "DELETE FROM tbpembelian WHERE kode='" & Txt_kode.Text & "'"
                                                        Using cmdz As New MySqlCommand(sqlz, conz)
                                                            cmdz.ExecuteNonQuery()
                                                        End Using
                                                    End Using
                                                End If
                                            End Using
                                        End Using
                                    End Using
                                    MessageBox.Show("PEMBELIAN berhasil di Hapus", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            End If
                        End If
                    End Using
                End Using
            End Using
            form_pembelian.Show()
            form_pembelian.Focus()
            form_pembelian.btn_cari.PerformClick()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class