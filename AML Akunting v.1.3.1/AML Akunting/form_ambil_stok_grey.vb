Imports MySql.Data.MySqlClient

Public Class form_ambil_stok_grey

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

    Private Sub form_ambil_stok_grey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isi_ppn()
    End Sub

    Private Sub isidgvindukgrey()
        Try
            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir > 5 AND tanggal <= '" & dtp_tanggal.Text & "'  ORDER BY tanggal ASC"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk()
                            'Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk()
        dgv1.Columns(2).HeaderText = "Tanggal Beli"
        'dgv1.Columns(3).HeaderText = "No Faktur"
        dgv1.Columns(4).HeaderText = "Supplier"
        dgv1.Columns(5).HeaderText = "Nama Grey"
        'dgv1.Columns(6).HeaderText = "Stok Awal (Mtr/Yard)"
        'dgv1.Columns(7).HeaderText = "Masuk (Mtr/Yard)"
        'dgv1.Columns(8).HeaderText = "Keluar (Mtr/Yard)"
        dgv1.Columns(9).HeaderText = "Stok Tersedia (Mtr/Yard)"
        dgv1.Columns(10).HeaderText = "Harga Beli DPP (Rp)"
        dgv1.Columns(11).HeaderText = "Harga Jual DPP (Rp)"
        dgv1.Columns(12).HeaderText = "Harga Jual + PPN (Rp)"
        dgv1.Columns(13).HeaderText = "DPP Jual Tersedia (Rp)"
        dgv1.Columns(14).HeaderText = "Nama Jual"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).Visible = False
        dgv1.Columns(3).Visible = False
        dgv1.Columns(6).Visible = False
        dgv1.Columns(7).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        'dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        'dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub isidgvindukgrey2()
        Try
            dtp_tanggal.CustomFormat = "yyyy/MM/dd"
            dgv2.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Dim sqlx As String = "SELECT * FROM tbgrey WHERE stok_akhir > 5 AND tanggal > '" & dtp_tanggal.Text & "' ORDER BY tanggal ASC"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv2.DataSource = dsx.Tables("tbindukgrey")
                            Call atur_dgv_induk2()
                            'Call hitungjumlah()
                        End Using
                    End Using
                End Using
            End Using
            dtp_tanggal.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk2()
        dgv2.Columns(2).HeaderText = "Tanggal Beli"
        'dgv2.Columns(3).HeaderText = "No Faktur"
        dgv2.Columns(4).HeaderText = "Supplier"
        dgv2.Columns(5).HeaderText = "Nama Grey"
        'dgv2.Columns(6).HeaderText = "Stok Awal (Mtr/Yard)"
        'dgv2.Columns(7).HeaderText = "Masuk (Mtr/Yard)"
        'dgv2.Columns(8).HeaderText = "Keluar (Mtr/Yard)"
        dgv2.Columns(9).HeaderText = "Stok Tersedia (Mtr/Yard)"
        dgv2.Columns(10).HeaderText = "Harga Beli DPP (Rp)"
        dgv2.Columns(11).HeaderText = "Harga Jual DPP (Rp)"
        dgv2.Columns(12).HeaderText = "Harga Jual + PPN (Rp)"
        dgv2.Columns(13).HeaderText = "DPP Jual Tersedia (Rp)"
        dgv2.Columns(14).HeaderText = "Nama Jual"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.Columns(0).Visible = False
        dgv2.Columns(1).Visible = False
        dgv2.Columns(3).Visible = False
        dgv2.Columns(6).Visible = False
        dgv2.Columns(7).Visible = False
        dgv2.Columns(8).Visible = False
        dgv2.Columns(15).Visible = False
        dgv2.Columns(16).Visible = False
        dgv2.Columns(17).Visible = False
        dgv2.RowHeadersWidth = 60
        dgv2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgv2.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        'dgv2.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        'dgv2.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub btn_isi_dgv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_isi_dgv.Click
        Call isidgvindukgrey()
        Call isidgvindukgrey2()
        ' Menghapus baris yang sudah dipilih
        For i As Integer = dgv1.Rows.Count - 1 To 0 Step -1
            If Not dgv1.Rows(i).IsNewRow Then
                Dim idGrey As String = dgv1.Rows(i).Cells(0).Value
                If idGrey = txt_id_grey1.Text Or idGrey = txt_id_grey2.Text Or idGrey = txt_id_grey3.Text Then
                    dgv1.Rows.RemoveAt(i)
                End If
            End If
        Next
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If txt_baris.Text = "1" Then
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                form_input_penjualan_kain.txt_id_grey1.Text = row.Cells(0).Value.ToString()
                form_input_penjualan_kain.txt_id_beli1.Text = row.Cells(1).Value.ToString()
                form_input_penjualan_kain.txt_no_faktur1.Text = row.Cells(3).Value.ToString()
                form_input_penjualan_kain.txt_supplier1.Text = row.Cells(4).Value.ToString()
                form_input_penjualan_kain.txt_nama_grey1.Text = row.Cells(5).Value.ToString()
                form_input_penjualan_kain.cbo_nama_jual.Text = row.Cells(14).Value.ToString()
                form_input_penjualan_kain.cbo_nama_jual_asal.Text = row.Cells(14).Value.ToString()
                form_input_penjualan_kain.txt_kode_beli1.Text = row.Cells(15).Value.ToString()
                form_input_penjualan_kain.txt_kode_grey1.Text = row.Cells(16).Value.ToString()
                form_input_penjualan_kain.txt_kode_neraca1.Text = row.Cells(17).Value.ToString()

                Dim tanggal As DateTime = Convert.ToDateTime(row.Cells(2).Value)
                form_input_penjualan_kain.dtp_tanggal_beli1.Text = tanggal.ToString("dd/MM/yyyy")

                Dim qty As String = row.Cells(9).Value.ToString()
                Dim hargagrey As String = row.Cells(10).Value.ToString()
                Dim hargajualdpp As String = row.Cells(11).Value.ToString()
                Dim hargajualppn As String = row.Cells(12).Value.ToString()
                Dim qty_d, hargagrey_d, hargajualdpp_d, hargajualppn_d As Decimal
                Decimal.TryParse(qty, qty_d)
                Decimal.TryParse(hargagrey, hargagrey_d)
                Decimal.TryParse(hargajualdpp, hargajualdpp_d)
                Decimal.TryParse(hargajualppn, hargajualppn_d)
                form_input_penjualan_kain.txt_qty1.Text = qty_d.ToString("#,##0.00")
                form_input_penjualan_kain.txt_qty_asal1.Text = qty_d.ToString("#,##0.00")
                form_input_penjualan_kain.txt_harga_grey1.Text = hargagrey_d.ToString("#,##0.00########")
                form_input_penjualan_kain.txt_harga_jual_dpp.Text = hargajualdpp_d.ToString("#,##0.00########")
                form_input_penjualan_kain.txt_harga_jual_ppn.Text = hargajualppn_d.ToString("#,##0")

                Dim hargagreyppn As Decimal = hargagrey_d * (1 + (ppn / 100))
                form_input_penjualan_kain.txt_harga_grey_ppn1.Text = hargagreyppn.ToString("#,##0")
                Me.Close()
            ElseIf txt_baris.Text = "2" Then
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                If form_input_penjualan_kain.txt_id_grey1.Text = row.Cells(0).Value.ToString() Then
                    MsgBox("STOK yang dipilih sudah diinput di baris 1")
                ElseIf form_input_penjualan_kain.txt_harga_jual_dpp.Text.Replace(".", "") <> row.Cells(11).Value.ToString() Then
                    MsgBox("STOK yang dipilih Harga Jual tidak sama dengan STOK awal yang dipilih")
                Else
                    form_input_penjualan_kain.txt_id_grey2.Text = row.Cells(0).Value.ToString()
                    form_input_penjualan_kain.txt_id_beli2.Text = row.Cells(1).Value.ToString()
                    form_input_penjualan_kain.txt_no_faktur2.Text = row.Cells(3).Value.ToString()
                    form_input_penjualan_kain.txt_supplier2.Text = row.Cells(4).Value.ToString()
                    form_input_penjualan_kain.txt_nama_grey2.Text = row.Cells(5).Value.ToString()
                    'form_input_penjualan_kain.cbo_nama_jual2.Text = row.Cells(14).Value.ToString()
                    'form_input_penjualan_kain.cbo_nama_jual_asal2.Text = row.Cells(14).Value.ToString()
                    form_input_penjualan_kain.txt_kode_beli2.Text = row.Cells(15).Value.ToString()
                    form_input_penjualan_kain.txt_kode_grey2.Text = row.Cells(16).Value.ToString()
                    form_input_penjualan_kain.txt_kode_neraca2.Text = row.Cells(17).Value.ToString()

                    Dim tanggal As DateTime = Convert.ToDateTime(row.Cells(2).Value)
                    form_input_penjualan_kain.dtp_tanggal_beli2.Text = tanggal.ToString("dd/MM/yyyy")

                    Dim qty As String = row.Cells(9).Value.ToString()
                    Dim hargagrey As String = row.Cells(10).Value.ToString()
                    Dim hargajualdpp As String = row.Cells(11).Value.ToString()
                    Dim hargajualppn As String = row.Cells(12).Value.ToString()
                    Dim qty_d, hargagrey_d, hargajualdpp_d, hargajualppn_d As Decimal
                    Decimal.TryParse(qty, qty_d)
                    Decimal.TryParse(hargagrey, hargagrey_d)
                    Decimal.TryParse(hargajualdpp, hargajualdpp_d)
                    Decimal.TryParse(hargajualppn, hargajualppn_d)
                    form_input_penjualan_kain.txt_qty2.Text = qty_d.ToString("#,##0.00")
                    form_input_penjualan_kain.txt_qty_asal2.Text = qty_d.ToString("#,##0.00")
                    form_input_penjualan_kain.txt_harga_grey2.Text = hargagrey_d.ToString("#,##0.00########")
                    'form_input_penjualan_kain.txt_harga_jual_dpp2.Text = hargajualdpp_d.ToString("#,##0.00########")
                    'form_input_penjualan_kain.txt_harga_jual_ppn2.Text = hargajualppn_d.ToString("#,##0")

                    'Dim hargagreyppn As Decimal = hargagrey_d * (1 + (ppn / 100))
                    'form_input_penjualan_kain.txt_harga_grey_ppn2.Text = hargagreyppn.ToString("#,##0")
                    Me.Close()
                End If
            ElseIf txt_baris.Text = "3" Then
                Dim row As DataGridViewRow = dgv1.Rows(e.RowIndex)
                If form_input_penjualan_kain.txt_id_grey1.Text = row.Cells(0).Value.ToString() Then
                    MsgBox("STOK yang dipilih sudah diinput di baris 1")
                ElseIf form_input_penjualan_kain.txt_id_grey2.Text = row.Cells(0).Value.ToString() Then
                    MsgBox("STOK yang dipilih sudah diinput di baris 2")
                ElseIf form_input_penjualan_kain.txt_harga_jual_dpp.Text.Replace(".", "") <> row.Cells(11).Value.ToString() Then
                    MsgBox("STOK yang dipilih Harga Jual tidak sama dengan STOK awal yang dipilih")
                Else
                    form_input_penjualan_kain.txt_id_grey3.Text = row.Cells(0).Value.ToString()
                    form_input_penjualan_kain.txt_id_beli3.Text = row.Cells(1).Value.ToString()
                    form_input_penjualan_kain.txt_no_faktur3.Text = row.Cells(3).Value.ToString()
                    form_input_penjualan_kain.txt_supplier3.Text = row.Cells(4).Value.ToString()
                    form_input_penjualan_kain.txt_nama_grey3.Text = row.Cells(5).Value.ToString()
                    'form_input_penjualan_kain.cbo_nama_jual3.Text = row.Cells(14).Value.ToString()
                    'form_input_penjualan_kain.cbo_nama_jual_asal3.Text = row.Cells(14).Value.ToString()
                    form_input_penjualan_kain.txt_kode_beli3.Text = row.Cells(15).Value.ToString()
                    form_input_penjualan_kain.txt_kode_grey3.Text = row.Cells(16).Value.ToString()
                    form_input_penjualan_kain.txt_kode_neraca3.Text = row.Cells(17).Value.ToString()

                    Dim tanggal As DateTime = Convert.ToDateTime(row.Cells(2).Value)
                    form_input_penjualan_kain.dtp_tanggal_beli3.Text = tanggal.ToString("dd/MM/yyyy")

                    Dim qty As String = row.Cells(9).Value.ToString()
                    Dim hargagrey As String = row.Cells(10).Value.ToString()
                    Dim hargajualdpp As String = row.Cells(11).Value.ToString()
                    Dim hargajualppn As String = row.Cells(12).Value.ToString()
                    Dim qty_d, hargagrey_d, hargajualdpp_d, hargajualppn_d As Decimal
                    Decimal.TryParse(qty, qty_d)
                    Decimal.TryParse(hargagrey, hargagrey_d)
                    Decimal.TryParse(hargajualdpp, hargajualdpp_d)
                    Decimal.TryParse(hargajualppn, hargajualppn_d)
                    form_input_penjualan_kain.txt_qty3.Text = qty_d.ToString("#,##0.00")
                    form_input_penjualan_kain.txt_qty_asal3.Text = qty_d.ToString("#,##0.00")
                    form_input_penjualan_kain.txt_harga_grey3.Text = hargagrey_d.ToString("#,##0.00########")
                    'form_input_penjualan_kain.txt_harga_jual_dpp3.Text = hargajualdpp_d.ToString("#,##0.00########")
                    'form_input_penjualan_kain.txt_harga_jual_ppn3.Text = hargajualppn_d.ToString("#,##0")

                    'Dim hargagreyppn As Decimal = hargagrey_d * (1 + (ppn / 100))
                    'form_input_penjualan_kain.txt_harga_grey_ppn3.Text = hargagreyppn.ToString("#,##0")
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub dgv2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv2.CellFormatting
        dgv2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

End Class