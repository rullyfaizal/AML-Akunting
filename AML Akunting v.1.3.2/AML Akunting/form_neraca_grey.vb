Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_neraca_grey

    Private Sub form_neraca_grey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call awal()
    End Sub

    Private Sub awal()
        dtp_hari_ini.Text = Today
        dtp_awal.Text = "01/" & DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Year.ToString()
        dtp_akhir.Text = Today
        Call isidgvindukgrey()
        txt_tanggal.Text = ""
        ListBox1.Items.Clear()
        Label6.Text = "NERACA GREY"
    End Sub

    Private Sub isidgvindukgrey()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbneracagrey WHERE stok_akhir <> 0"
                'Dim sqlx As String = "SELECT * FROM tbneracagrey"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call tambahkolom()
                            Call hitungjumlah()
                            Call atur_dgv_induk()
                        End Using
                    End Using
                End Using
            End Using
            dtp_awal.CustomFormat = "dd/MM/yyyy"
            dtp_akhir.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub hitungjumlah()
        Dim awal, masuk, keluar, akhir, dpp, beli As Decimal
        awal = 0
        masuk = 0
        keluar = 0
        akhir = 0
        dpp = 0
        beli = 0
        For i As Integer = 0 To dgv1.Rows.Count - 1
            awal = awal + Decimal.Round((dgv1.Rows(i).Cells(2).Value), 10)
            masuk = masuk + Decimal.Round((dgv1.Rows(i).Cells(3).Value), 10)
            keluar = keluar + Decimal.Round((dgv1.Rows(i).Cells(4).Value), 10)
            akhir = akhir + Decimal.Round((dgv1.Rows(i).Cells(5).Value), 10)
            dpp = dpp + Decimal.Round((dgv1.Rows(i).Cells(7).Value), 10)
            beli = beli + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
        Next
        txt_awal.Text = awal.ToString("#,##0.00")
        txt_masuk.Text = masuk.ToString("#,##0.00")
        txt_keluar.Text = keluar.ToString("#,##0.00")
        txt_akhir.Text = akhir.ToString("#,##0.00")
        txt_dpp_tersedia.Text = dpp.ToString("#,##0.00")
        txt_total_dpp_beli.Text = beli.ToString("#,##0.00")
    End Sub
    Private Sub atur_dgv_induk()
        dgv1.Columns(1).HeaderText = "Nama Grey"
        dgv1.Columns(2).HeaderText = "Stok Awal"
        dgv1.Columns(3).HeaderText = "Masuk"
        dgv1.Columns(4).HeaderText = "Keluar"
        dgv1.Columns(5).HeaderText = "Stok Akhir"
        dgv1.Columns(6).HeaderText = "Harga DPP (Rp)"
        dgv1.Columns(7).HeaderText = "DPP Jual Akhir (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(2).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(2).Width = 100
        dgv1.Columns(3).Width = 100
        dgv1.Columns(4).Width = 100
        dgv1.Columns(5).Width = 100
        dgv1.Columns(6).Width = 120
        dgv1.Columns(9).Width = 170
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If e.RowIndex >= 0 Then
                form_detail_neraca.Show()
                form_detail_neraca.Focus()
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                Dim awal As String = row.Cells(2).Value.ToString()
                Dim masuk As String = row.Cells(3).Value.ToString()
                Dim keluar As String = row.Cells(4).Value.ToString()
                Dim akhir As String = row.Cells(5).Value.ToString()
                Dim dpp As String = row.Cells(7).Value.ToString()
                Dim awal_d, masuk_d, keluar_d, akhir_d, dpp_d As Decimal
                Decimal.TryParse(awal, awal_d)
                Decimal.TryParse(masuk, masuk_d)
                Decimal.TryParse(keluar, keluar_d)
                Decimal.TryParse(akhir, akhir_d)
                Decimal.TryParse(dpp, dpp_d)
                form_detail_neraca.txt_awal.Text = awal_d.ToString("#,##0.00")
                form_detail_neraca.txt_masuk.Text = masuk_d.ToString("#,##0.00")
                form_detail_neraca.txt_keluar.Text = keluar_d.ToString("#,##0.00")
                form_detail_neraca.txt_akhir.Text = akhir_d.ToString("#,##0.00")
                form_detail_neraca.txt_dpp_tersedia.Text = dpp_d.ToString("#,##0.00")
                form_detail_neraca.txt_kode_neraca.Text = row.Cells(8).Value.ToString()
            End If
        End If
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub ts_perbarui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_perbarui.Click
        Call awal()
    End Sub

    Private Sub tambahkolom()
        If Not dgv1.Rows.Count = 0 Then
            Dim newColumn As New DataGridViewTextBoxColumn
            newColumn.Name = "hargadppbeli"
            newColumn.HeaderText = "DPP Beli Akhir (Rp)"
            dgv1.Columns.Add(newColumn)
            For i As Integer = 0 To dgv1.Rows.Count - 1
                Dim selectedRow As DataGridViewRow = dgv1.Rows(i)
                txt_kode_neraca.Text = selectedRow.Cells(8).Value.ToString()
                txt_qty.Text = selectedRow.Cells(5).Value.ToString()

                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()
                    Dim sqly As String = "SELECT DISTINCT harga FROM tbhistorygrey WHERE kode_neraca = '" & txt_kode_neraca.Text & "'"
                    Using cmdy As New MySqlCommand(sqly, cony)
                        Using dry As MySqlDataReader = cmdy.ExecuteReader
                            dry.Read()
                            If dry.HasRows Then
                                txt_harga.Text = dry(0).ToString()
                            End If
                        End Using
                    End Using
                End Using

                Dim qty As String = txt_qty.Text
                Dim harga As String = txt_harga.Text

                Dim qty_d, harga_d, dppbeli As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(harga, harga_d)
                dppbeli = qty_d * harga_d
                txt_dpp_beli.Text = dppbeli.ToString("#,##0.00")

                selectedRow.Cells("hargadppbeli").Value = txt_dpp_beli.Text
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgv1.CurrentRow IsNot Nothing Then
            Dim newColumn As New DataGridViewTextBoxColumn
            newColumn.Name = "hargadppbeli"
            newColumn.HeaderText = "DPP Beli Akhir (Rp)"
            dgv1.Columns.Add(newColumn)

            Dim selectedRow As DataGridViewRow = dgv1.CurrentRow
            txt_kode_neraca.Text = selectedRow.Cells(8).Value.ToString()
            txt_qty.Text = selectedRow.Cells(5).Value.ToString()


            Using cony As New MySqlConnection(sLocalConn)
                cony.Open()
                Dim sqly As String = "SELECT DISTINCT harga FROM tbhistorygrey WHERE kode_neraca = '" & txt_kode_neraca.Text & "'"
                Using cmdy As New MySqlCommand(sqly, cony)
                    Using dry As MySqlDataReader = cmdy.ExecuteReader
                        dry.Read()
                        If dry.HasRows Then
                            txt_harga.Text = dry(0).ToString()
                        End If
                    End Using
                End Using
            End Using

            Dim qty As String = txt_qty.Text
            Dim harga As String = txt_harga.Text

            Dim qty_d, harga_d, dppbeli As Decimal
            Decimal.TryParse(qty, qty_d)
            Decimal.TryParse(harga, harga_d)
            dppbeli = qty_d * harga_d
            txt_dpp_beli.Text = dppbeli.ToString("#,##0.00########")

            selectedRow.Cells("hargadppbeli").Value = txt_dpp_beli.Text

        End If
    End Sub

    Private Sub dtp_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("MMMM yyyy", cultureInfo)
        txt_tanggal.Text = formattedDate
    End Sub

    Private Sub btn_kosong_tanggal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal.Click
        If Not txt_tanggal.Text = "" Then
            txt_tanggal.Text = ""
        End If
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        ts_perbarui.PerformClick()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim selectedBulan As Integer = dtp_tanggal.Value.Month
        Dim selectedTahun As Integer = dtp_tanggal.Value.Year

        If txt_tanggal.Text = "" Then
            MsgBox("Pilih Bulan terlebih dahulu")
        Else
            LoadKodeNeracaByMonthYear(selectedBulan, selectedTahun)
            If ListBox1.Items.Count = 0 Then
                MessageBox.Show("Tidak ada data di Bulan yang dicari")
                Return
            Else
                Dim kodeNeracaList As String = String.Join("','", ListBox1.Items.Cast(Of String)())

                ' Query SQL untuk mengambil semua baris berdasarkan kode_neraca yang ada di ListBox1
                Dim query As String = "SELECT * FROM tbneracagrey WHERE kode_neraca IN ('" & kodeNeracaList & "');"
                dtp_awal.CustomFormat = "yyyy/MM/dd"
                dtp_akhir.CustomFormat = "yyyy/MM/dd"
                dgv1.Columns.Clear()
                Using conn As New MySqlConnection(sLocalConn)
                    Using cmd As New MySqlCommand(query, conn)
                        Try
                            conn.Open()
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                ' Load data ke DataTable
                                Dim dt As New DataTable()
                                dt.Load(reader)
                                ' Tampilkan data di DataGridView
                                dgv1.DataSource = dt
                                Call tambahkolom()
                                Call hitungjumlah()
                                Call atur_dgv_induk()
                            End Using
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
                dtp_awal.CustomFormat = "dd/MM/yyyy"
                dtp_akhir.CustomFormat = "dd/MM/yyyy"
                Label6.Text = "DATA NERACA GREY " & txt_tanggal.Text
            End If
        End If

    End Sub
    Public Sub LoadKodeNeracaByMonthYear(ByVal bulan As Integer, ByVal tahun As Integer)
        Dim query As String = "SELECT DISTINCT kode_neraca FROM tbgrey WHERE MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun;"

        Using conn As New MySqlConnection(sLocalConn)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@bulan", bulan)
                cmd.Parameters.AddWithValue("@tahun", tahun)

                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        ' Bersihkan ListBox sebelum mengisi data baru
                        ListBox1.Items.Clear()
                        ' Isi ListBox dengan data dari kolom kode_neraca
                        While reader.Read()
                            ListBox1.Items.Add(reader("kode_neraca").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    
End Class