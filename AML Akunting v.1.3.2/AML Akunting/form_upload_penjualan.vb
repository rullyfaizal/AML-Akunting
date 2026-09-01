Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class form_upload_penjualan
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
                Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE NOT no_faktur = '' AND upload IS Null AND MONTH(tanggal) = '" & bulan & "' AND YEAR(tanggal) = '" & tahun & "' ORDER BY tanggal ASC"
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
            btn_simpan.Enabled = False
            dgv_upload.Columns.Clear()
        Else
            dgv_batal_upload.Rows.Clear()
            dgv_batal_upload.Columns.Clear()
            btn_simpan.Enabled = True
            Call isidgv()
            Call isidgv3()
            Call cariupload()
            Call hitungjumlah()
        End If
    End Sub

    Private Sub isidgv3()
        dgv3.Rows.Clear()
        dgv3.Columns.Clear()
        For Each col As DataGridViewColumn In dgv1.Columns
            dgv3.Columns.Add(CType(col.Clone(), DataGridViewColumn))
        Next
        For Each row As DataGridViewRow In dgv1.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv3.Rows.Add(newRow)
            End If
        Next
        Call atur_dgv3()
    End Sub
    Private Sub atur_dgv3()
        dgv3.Columns(1).HeaderText = "TANGGAL"
        dgv3.Columns(4).HeaderText = "CLIENT"
        dgv3.Columns(9).HeaderText = "DPP (Rp)"
        dgv3.Columns(10).HeaderText = "PPN (Rp)"
        dgv3.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv3.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 23
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv3.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv3.Columns(i).Visible = False
            End If
        Next

        dgv3.Columns(1).Width = 85
        dgv3.Columns(4).Width = 220
        dgv3.Columns(9).Width = 120
        dgv3.Columns(10).Width = 110
        dgv3.Columns(11).Width = 130
        dgv3.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv3.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv3.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv3.Columns(11).DefaultCellStyle.Format = "#,##0.00"

    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub dgv3_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv3.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                'If txt_dpp_penjualan.Text = "" Then
                '    MessageBox.Show("Silahkan Input DPP Penjualan terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    txt_dpp_penjualan.Focus()
                If txt_tanggal_upload.Text = "" Then
                    MessageBox.Show("Silahkan pilih Bulan Upload terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If dgv2.ColumnCount = 0 Then
                        With dgv2
                            .ColumnCount = 24
                        End With
                        If dgv3.RowCount > 0 Then
                            Dim i As Integer
                            i = Me.dgv3.CurrentRow.Index
                            With dgv3.Rows.Item(i)
                                dgv2.Rows.Add(1)
                                For colIndex As Integer = 0 To 23
                                    dgv2.Rows(dgv2.RowCount - 1).Cells(colIndex).Value = dgv3.Rows(i).Cells(colIndex).Value
                                Next
                                dgv3.Rows.Remove(dgv3.Rows(i))
                            End With
                        Else
                            MsgBox("Tabel Kosong")
                        End If
                    Else
                        If dgv3.RowCount > 0 Then
                            Dim i As Integer
                            i = Me.dgv3.CurrentRow.Index
                            With dgv3.Rows.Item(i)
                                dgv2.Rows.Add(1)
                                For colIndex As Integer = 0 To 23
                                    dgv2.Rows(dgv2.RowCount - 1).Cells(colIndex).Value = dgv3.Rows(i).Cells(colIndex).Value
                                Next
                                dgv3.Rows.Remove(dgv3.Rows(i))
                            End With
                        Else
                            MsgBox("Tabel Kosong")
                        End If
                    End If
                    Call atur_dgv2()
                    Call hitungjumlah()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub atur_dgv2()
        dgv2.Columns(1).HeaderText = "TANGGAL"
        dgv2.Columns(4).HeaderText = "CLIENT"
        dgv2.Columns(9).HeaderText = "DPP (Rp)"
        dgv2.Columns(10).HeaderText = "PPN (Rp)"
        dgv2.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 23
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv2.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv2.Columns(i).Visible = False
            End If
        Next

        dgv2.Columns(1).Width = 85
        dgv2.Columns(4).Width = 220
        dgv2.Columns(9).Width = 120
        dgv2.Columns(10).Width = 110
        dgv2.Columns(11).Width = 130
        dgv2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(11).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv2_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv2.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgv3.ColumnCount = 0 Then
                    With dgv3
                        .ColumnCount = 24
                    End With
                    If dgv2.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv2.CurrentRow.Index
                        With dgv2.Rows.Item(i)
                            dgv3.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv3.Rows(dgv3.RowCount - 1).Cells(colIndex).Value = dgv2.Rows(i).Cells(colIndex).Value
                            Next
                            dgv2.Rows.Remove(dgv2.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                Else
                    If dgv2.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv2.CurrentRow.Index
                        With dgv2.Rows.Item(i)
                            dgv3.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv3.Rows(dgv3.RowCount - 1).Cells(colIndex).Value = dgv2.Rows(i).Cells(colIndex).Value
                            Next
                            dgv2.Rows.Remove(dgv2.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                End If
                Call atur_dgv3()
                Call hitungjumlah()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub cariupload()
        Try
            Dim bulan, tahun As Integer
            bulan = dtp_tanggal_upload.Value.Month
            tahun = dtp_tanggal_upload.Value.Year
            dgv_tampil_upload.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbpenjualan WHERE no_faktur <> '' AND upload IS NOT NULL AND MONTH(tanggal) = '" & bulan & "' AND YEAR(tanggal) = '" & tahun & "' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv_tampil_upload.DataSource = dsx.Tables("tbpembelian")
                        End Using
                    End Using
                End Using
            End Using
            Call atur_dgv_tampil_upload()
            Call isidgvupload()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_tampil_upload()
        dgv_tampil_upload.Columns(1).HeaderText = "TANGGAL"
        dgv_tampil_upload.Columns(4).HeaderText = "CLIENT"
        dgv_tampil_upload.Columns(9).HeaderText = "DPP (Rp)"
        dgv_tampil_upload.Columns(10).HeaderText = "PPN (Rp)"
        dgv_tampil_upload.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv_tampil_upload.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 23
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv_tampil_upload.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv_tampil_upload.Columns(i).Visible = False
            End If
        Next
        dgv_tampil_upload.Columns(1).Width = 85
        dgv_tampil_upload.Columns(4).Width = 220
        dgv_tampil_upload.Columns(9).Width = 120
        dgv_tampil_upload.Columns(10).Width = 110
        dgv_tampil_upload.Columns(11).Width = 130
        dgv_tampil_upload.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_tampil_upload.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_tampil_upload.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_tampil_upload.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_tampil_upload.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv_tampil_upload.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv_tampil_upload.Columns(11).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub isidgvupload()
        dgv_upload.Rows.Clear()
        dgv_upload.Columns.Clear()
        For Each col As DataGridViewColumn In dgv_tampil_upload.Columns
            dgv_upload.Columns.Add(CType(col.Clone(), DataGridViewColumn))
        Next
        For Each row As DataGridViewRow In dgv_tampil_upload.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                dgv_upload.Rows.Add(newRow)
            End If
        Next
        Call atur_dgv_upload()
    End Sub
    Private Sub atur_dgv_upload()
        dgv_upload.Columns(1).HeaderText = "TANGGAL"
        dgv_upload.Columns(4).HeaderText = "CLIENT"
        dgv_upload.Columns(9).HeaderText = "DPP (Rp)"
        dgv_upload.Columns(10).HeaderText = "PPN (Rp)"
        dgv_upload.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv_upload.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 23
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv_upload.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv_upload.Columns(i).Visible = False
            End If
        Next
        dgv_upload.Columns(1).Width = 85
        dgv_upload.Columns(4).Width = 220
        dgv_upload.Columns(9).Width = 120
        dgv_upload.Columns(10).Width = 110
        dgv_upload.Columns(11).Width = 130
        dgv_upload.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_upload.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_upload.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_upload.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_upload.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv_upload.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv_upload.Columns(11).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub dgv_upload_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_upload.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgv_batal_upload.ColumnCount = 0 Then
                    With dgv_batal_upload
                        .ColumnCount = 24
                    End With
                    If dgv_upload.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv_upload.CurrentRow.Index
                        With dgv_upload.Rows.Item(i)
                            dgv_batal_upload.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv_batal_upload.Rows(dgv_batal_upload.RowCount - 1).Cells(colIndex).Value = dgv_upload.Rows(i).Cells(colIndex).Value
                            Next
                            dgv_upload.Rows.Remove(dgv_upload.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                Else
                    If dgv_upload.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv_upload.CurrentRow.Index
                        With dgv_upload.Rows.Item(i)
                            dgv_batal_upload.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv_batal_upload.Rows(dgv_batal_upload.RowCount - 1).Cells(colIndex).Value = dgv_upload.Rows(i).Cells(colIndex).Value
                            Next
                            dgv_upload.Rows.Remove(dgv_upload.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                End If
                Call atur_dgv_batal_upload()
                Call hitungjumlah()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub dgv_batal_upload_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_batal_upload.CellMouseClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgv_upload.ColumnCount = 0 Then
                    With dgv_upload
                        .ColumnCount = 24
                    End With
                    If dgv_batal_upload.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv_batal_upload.CurrentRow.Index
                        With dgv_batal_upload.Rows.Item(i)
                            dgv_upload.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv_upload.Rows(dgv_upload.RowCount - 1).Cells(colIndex).Value = dgv_batal_upload.Rows(i).Cells(colIndex).Value
                            Next
                            dgv_batal_upload.Rows.Remove(dgv_batal_upload.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                Else
                    If dgv_batal_upload.RowCount > 0 Then
                        Dim i As Integer
                        i = Me.dgv_batal_upload.CurrentRow.Index
                        With dgv_batal_upload.Rows.Item(i)
                            dgv_upload.Rows.Add(1)
                            For colIndex As Integer = 0 To 23
                                dgv_upload.Rows(dgv_upload.RowCount - 1).Cells(colIndex).Value = dgv_batal_upload.Rows(i).Cells(colIndex).Value
                            Next
                            dgv_batal_upload.Rows.Remove(dgv_batal_upload.Rows(i))
                        End With
                    Else
                        MsgBox("Tabel Kosong")
                    End If
                End If
                Call atur_dgv_upload()
                Call hitungjumlah()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub atur_dgv_batal_upload()
        dgv_batal_upload.Columns(1).HeaderText = "TANGGAL"
        dgv_batal_upload.Columns(4).HeaderText = "CLIENT"
        dgv_batal_upload.Columns(9).HeaderText = "DPP (Rp)"
        dgv_batal_upload.Columns(10).HeaderText = "PPN (Rp)"
        dgv_batal_upload.Columns(11).HeaderText = "TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv_batal_upload.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        ' Memastikan semua kolom diatur tidak terlihat
        For i As Integer = 0 To 23
            ' Menampilkan kolom 1, 4, 9, 10, dan 11
            If i = 1 Or i = 4 Or i = 9 Or i = 10 Or i = 11 Then
                dgv_batal_upload.Columns(i).Visible = True
            Else
                ' Menyembunyikan kolom lainnya
                dgv_batal_upload.Columns(i).Visible = False
            End If
        Next
        dgv_batal_upload.Columns(1).Width = 85
        dgv_batal_upload.Columns(4).Width = 220
        dgv_batal_upload.Columns(9).Width = 120
        dgv_batal_upload.Columns(10).Width = 110
        dgv_batal_upload.Columns(11).Width = 130
        dgv_batal_upload.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_batal_upload.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_batal_upload.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_batal_upload.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_batal_upload.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv_batal_upload.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv_batal_upload.Columns(11).DefaultCellStyle.Format = "#,##0.00"
    End Sub

    Private Sub hitungjumlah()
        Try
            Call tampil_upload_pembelian()

            Dim totaldpppenjualan, totaldppupload, totaldppakanupload, selisihppn As Decimal
            totaldppupload = 0
            totaldppakanupload = 0
            'If txt_dpp_penjualan.Text = "" Then
            '    totaldpppenjualan = 0
            '    txt_dpp_penjualan.Text = totaldpppenjualan.ToString("#,##0.00########")
            'Else
            '    totaldpppenjualan = Convert.ToDecimal(txt_dpp_penjualan.Text.Replace(".", "").Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            'End If
            selisihppn = 0
            totaldpppenjualan = 0
            For i As Integer = 0 To dgv_pembelian.Rows.Count - 1
                totaldpppenjualan = totaldpppenjualan + Decimal.Round((dgv_pembelian.Rows(i).Cells(6).Value), 10)
            Next
            For i As Integer = 0 To dgv_upload.Rows.Count - 1
                totaldppupload = totaldppupload + Decimal.Round((dgv_upload.Rows(i).Cells(9).Value), 10)
            Next
            For i As Integer = 0 To dgv2.Rows.Count - 1
                totaldppakanupload = totaldppakanupload + Decimal.Round((dgv2.Rows(i).Cells(9).Value), 10)
            Next
            txt_dpp_penjualan.Text = totaldpppenjualan.ToString("#,##0.00########")
            txt_dpp_upload.Text = totaldppupload.ToString("#,##0.00########")
            txt_dpp_akan_upload.Text = totaldppakanupload.ToString("#,##0.00########")
            selisihppn = ((totaldppupload + totaldppakanupload) - totaldpppenjualan) * (ppn / 100)
            txt_selisih_ppn.Text = selisihppn.ToString("#,##0.00########")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tampil_upload_pembelian()
        Try
            Dim bulan, tahun As Integer
            bulan = dtp_tanggal_upload.Value.Month
            tahun = dtp_tanggal_upload.Value.Year
            dgv_pembelian.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE MONTH(tanggal_upload) = '" & bulan & "' AND YEAR(tanggal_upload) = '" & tahun & "' ORDER BY tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv_pembelian.DataSource = dsx.Tables("tbpembelian")
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        Try
            If dgv2.Rows.Count = 0 Then
                MsgBox("PENJUALAN yang akan diupload belum dipilih")
            Else
                If MsgBox("Yakin PENJUALAN Akan Diupload ?", vbYesNo + vbQuestion, "UPLOAD PENJUALAN") = vbYes Then
                    For i As Int32 = 0 To dgv2.Rows.Count - 1
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "UPDATE tbpenjualan SET upload=@1 WHERE id_jual = '" & dgv2.Rows.Item(i).Cells(0).Value.ToString & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                With cmdy
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@1", dgv2.Rows.Item(i).Cells(1).Value)
                                    .ExecuteNonQuery()
                                End With
                            End Using
                        End Using
                    Next
                    MsgBox("Data PENJUALAN Berhasil Di UPLOAD")
                    dgv2.Rows.Clear()
                    dgv2.Columns.Clear()
                    dgv_batal_upload.Rows.Clear()
                    dgv_batal_upload.Columns.Clear()
                    Call cariupload()
                    Call isidgv()
                    Call hitungjumlah()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_batal_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_upload.Click
        Try
            If dgv_batal_upload.Rows.Count = 0 Then
                MsgBox("PENJUALAN yang akan batal upload belum dipilih")
            Else
                If MsgBox("Yakin PENJUALAN BATAL UPLOAD ?", vbYesNo + vbQuestion, "BATAL UPLOAD") = vbYes Then
                    For i As Int32 = 0 To dgv_batal_upload.Rows.Count - 1
                        Using cony As New MySqlConnection(sLocalConn)
                            cony.Open()
                            Dim sqly = "UPDATE tbpenjualan SET upload=@1 WHERE id_jual = '" & dgv_batal_upload.Rows.Item(i).Cells(0).Value.ToString & "'"
                            Using cmdy As New MySqlCommand(sqly, cony)
                                With cmdy
                                    .Parameters.Clear()
                                    .Parameters.AddWithValue("@1", DBNull.Value)
                                    .ExecuteNonQuery()
                                End With
                            End Using
                        End Using
                    Next
                    MsgBox("Data UPLOAD PENJUALAN Berhasil Diupdate")
                    dgv2.Rows.Clear()
                    dgv2.Columns.Clear()
                    dgv_batal_upload.Rows.Clear()
                    dgv_batal_upload.Columns.Clear()
                    Call cariupload()
                    Call isidgv()
                    Call isidgv3()
                    Call hitungjumlah()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class