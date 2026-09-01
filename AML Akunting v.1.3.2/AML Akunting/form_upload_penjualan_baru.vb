Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_upload_penjualan_baru
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
    Private Sub form_upload_penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
    End Sub
    Private Sub isidgv()
        Try
            Dim bulan, tahun As Integer
            bulan = dtp_tanggal_upload.Value.Month
            tahun = dtp_tanggal_upload.Value.Year
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE no_faktur <> '' AND MONTH(tanggal) = '" & bulan & "' AND YEAR(tanggal) = '" & tahun & "' ORDER BY tanggal ASC, no_faktur ASC"
                Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE no_faktur <> '' AND MONTH(tanggal) = '" & bulan & "' AND YEAR(tanggal) = '" & tahun & "' " &
                    "ORDER BY tanggal ASC, supplier ASC, FIELD(jenis_biaya, 'Obat', 'Jasa', 'Kain'), nama_kain ASC;"
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
            Call atur_dgv1()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv1()
        dgv1.Columns(1).HeaderText = "TANGGAL"
        dgv1.Columns(4).HeaderText = "CLIENT"
        dgv1.Columns(9).HeaderText = "DPP (Rp)"
        dgv1.Columns(10).HeaderText = "PPN (Rp)"
        dgv1.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 29
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv1.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv1.Columns(i).Visible = False
            End If
        Next
        dgv1.RowHeadersWidth = 60
        dgv1.Columns(1).Width = 85
        dgv1.Columns(4).Width = 220
        dgv1.Columns(9).Width = 120
        dgv1.Columns(10).Width = 110
        dgv1.Columns(11).Width = 130
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub dtp_tanggal_upload_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_tanggal_upload.TextChanged
        Dim selectedDate As DateTime = dtp_tanggal_upload.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal_upload.Text = formattedDate
    End Sub
    Private Sub btn_kosong_tanggal_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal_upload.Click
        If Not txt_tanggal_upload.Text = "" Then
            txt_tanggal_upload.Text = ""
        End If
    End Sub
    Private Sub txt_tanggal_upload_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_tanggal_upload.TextChanged
        If txt_tanggal_upload.Text = "" Then
            dgv1.Columns.Clear()
            Call hitungjumlah()
        Else
            Call isidgv()
            Call hitungjumlah()
        End If
    End Sub
    Private Sub hitungjumlah()
        Try
            Dim totaldppupload As Decimal
            totaldppupload = 0
            For i As Integer = 0 To dgv1.Rows.Count - 1
                totaldppupload = totaldppupload + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
            Next
            txt_dpp_upload.Text = totaldppupload.ToString("#,##0.00########")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class