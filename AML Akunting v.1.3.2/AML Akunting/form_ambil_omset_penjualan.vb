Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_ambil_omset_penjualan

    Private Sub form_ambil_omset_penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isidgv()
    End Sub

    Private Sub headertable()
        dgv1.Columns(0).Visible = False
        dgv1.Columns(8).Visible = False
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(1).HeaderText = "BULAN"
        dgv1.Columns(2).HeaderText = "CLIENT"
        dgv1.Columns(3).HeaderText = "GRAND TOTAL OMSET"
        dgv1.Columns(4).HeaderText = "DPP OMSET"
        dgv1.Columns(5).HeaderText = "DPP KAIN"
        dgv1.Columns(6).HeaderText = "GRAND TOTAL KAIN"
        dgv1.Columns(7).HeaderText = "POLOS"
        dgv1.Columns(9).HeaderText = "SISA OMSET"
        dgv1.Columns(1).Width = 130
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(1).DefaultCellStyle.Format = "MMMM yyyy"
        dgv1.Columns(1).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    End Sub
    Private Sub isidgv()
        Try
            Dim currentYear As Integer = Year(Now)
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbomset WHERE YEAR(tanggal) = '" & currentYear & "' ORDER BY tanggal DESC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbomset")
                            dgv1.DataSource = dsx.Tables("tbomset")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub isicaridgv()
        Try
            Dim currentMonth As Integer = Month(dtp_tanggal_cari.Value)
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbomset WHERE MONTH(tanggal) = '" & currentMonth & "' ORDER BY tanggal DESC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbomset")
                            dgv1.DataSource = dsx.Tables("tbomset")
                            Call headertable()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtp_tanggal_cari_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal_cari.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal_cari.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_cari.Text = formattedDate
    End Sub
    Private Sub btn_hapus_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus_cari.Click
        If Not txt_tanggal_cari.Text = "" Then
            txt_tanggal_cari.Text = ""
        End If
    End Sub
    Private Sub txt_tanggal_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal_cari.TextChanged
        If txt_tanggal_cari.Text = "" Then
            Call isidgv()
        Else
            Call isicaridgv()
        End If
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
            form_input_penjualan_kain.txt_id_omset.Text = row.Cells(0).Value.ToString()
            form_input_penjualan_kain.dtp_omset.Value = row.Cells(1).Value
            form_input_penjualan_kain.dtp_tanggal.Value = row.Cells(1).Value
            form_input_penjualan_kain.txt_client.Text = row.Cells(2).Value.ToString()
            form_input_penjualan_kain.txt_kode_omset.Text = row.Cells(8).Value.ToString()

            form_input_penjualan_kain.txt_sjx_grand_total_asal.Text = row.Cells(3).Value.ToString()
            form_input_penjualan_kain.txt_dpp_sjx_asal.Text = row.Cells(4).Value.ToString()
            form_input_penjualan_kain.txt_grand_total_kain_asal.Text = row.Cells(6).Value.ToString()
            form_input_penjualan_kain.txt_total_dpp_jual_asal.Text = row.Cells(5).Value.ToString()
            form_input_penjualan_kain.txt_polos_asal.Text = row.Cells(7).Value.ToString()
            form_input_penjualan_kain.txt_sisa_omset_asal.Text = row.Cells(9).Value.ToString()

            Dim omset As String = row.Cells(3).Value.ToString()
            Dim dpp As String = row.Cells(4).Value.ToString()
            Dim dppjual As String = row.Cells(5).Value.ToString()
            Dim grand_total_kain As String = row.Cells(6).Value.ToString()
            Dim polos As String = row.Cells(7).Value.ToString()
            Dim sisa As String = row.Cells(9).Value.ToString()
            Dim omset_d, dpp_d, dppjual_d, grand_total_kain_d, polos_d, sisa_d As Decimal
            Decimal.TryParse(omset, omset_d)
            Decimal.TryParse(dpp, dpp_d)
            Decimal.TryParse(dppjual, dppjual_d)
            Decimal.TryParse(grand_total_kain, grand_total_kain_d)
            Decimal.TryParse(polos, polos_d)
            Decimal.TryParse(sisa, sisa_d)

            form_input_penjualan_kain.txt_sjx_grand_total.Text = omset_d.ToString("#,##0.00")
            form_input_penjualan_kain.txt_dpp_sjx.Text = dpp_d.ToString("#,##0.00")
            form_input_penjualan_kain.txt_grand_total_kain.Text = grand_total_kain_d.ToString("#,##0.00")
            form_input_penjualan_kain.txt_total_dpp_jual.Text = dppjual_d.ToString("#,##0.00")
            form_input_penjualan_kain.txt_polos.Text = polos_d.ToString("#,##0.00")
            form_input_penjualan_kain.txt_sisa_omset.Text = sisa_d.ToString("#,##0.00")

            form_input_penjualan_kain.btn_omset.PerformClick()

            Me.Close()
        End If
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

End Class