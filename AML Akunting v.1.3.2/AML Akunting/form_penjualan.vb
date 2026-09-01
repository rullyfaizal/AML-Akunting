Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports System.IO
Imports OfficeOpenXml.Style

Public Class form_penjualan
    Dim indonesiaCulture As New System.Globalization.CultureInfo("id-ID")
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

    Private Sub form_penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call awal()
        Call isi_ppn()
    End Sub

    Private Sub awal()
        dtp_hari_ini.Text = Today
        dtp_awal.Text = "01/" & DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Year.ToString()
        dtp_akhir.Text = Today
        Call isidgvpenjualan()
    End Sub

    Private Sub isidgvpenjualan()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                'Dim sqlx As String = "SELECT id_jual, supplier, tanggal, surat_jalan, no_faktur, jenis_biaya, nama_kain, jumlah, harga, dpp, ppn, total, pph23, transfer, total_polos, satuan, status, baris, kode FROM tbpenjualan WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY tanggal ASC, no_faktur ASC"

                Dim sqlx As String = "SELECT id_jual, supplier, tanggal, surat_jalan, no_faktur, jenis_biaya, nama_kain, jumlah, harga, dpp, ppn, total, pph23, transfer, total_polos, satuan, status, baris, kode " &
                    "FROM tbpenjualan WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' " &
                    "ORDER BY tanggal ASC, supplier ASC, FIELD(jenis_biaya, 'Obat', 'Jasa', 'Kain'), nama_kain ASC;"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv1.DataSource = dsx.Tables("tbpenjualan")
                            Call atur_dgv_induk()
                            Call hitungjumlah()
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
    Private Sub atur_dgv_induk()
        dgv1.Columns(1).HeaderText = "NAMA CLIENT"
        dgv1.Columns(2).HeaderText = "TANGGAL"
        dgv1.Columns(3).HeaderText = "SURAT JALAN"
        dgv1.Columns(4).HeaderText = "FAKTUR PAJAK"
        dgv1.Columns(6).HeaderText = "NAMA KAIN"
        dgv1.Columns(7).HeaderText = "QTY"
        dgv1.Columns(8).HeaderText = "HARGA (Rp)"
        dgv1.Columns(9).HeaderText = "DPP (Rp)"
        dgv1.Columns(10).HeaderText = "PPN (Rp)"
        dgv1.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        dgv1.Columns(12).HeaderText = "PPH23 (Rp)"
        dgv1.Columns(13).HeaderText = "TOTAL TRANSFER (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(5).Visible = False
        dgv1.Columns(14).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.Columns(18).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'dgv1.Columns(1).Width = 85
        'dgv1.Columns(2).Width = 70
        'dgv1.Columns(3).Width = 130
        'dgv1.Columns(4).Width = 130
        'dgv1.Columns(5).Width = 130
        'dgv1.Columns(6).Width = 130
        'dgv1.Columns(7).Width = 130
        'dgv1.Columns(8).Width = 130
        'dgv1.Columns(9).Width = 130
        'dgv1.Columns(10).Width = 85
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        'If dgv1.ColumnCount > 15 Then
        '    dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)

        '    Dim indexStatusColumn As Integer = dgv1.Columns(16).Index

        '    ' Memeriksa apakah kolom yang sedang diformat adalah kolom "Status"
        '    If e.ColumnIndex = indexStatusColumn Then
        '        ' Ambil nilai dari kolom "Status"
        '        Dim statusValue As String = e.Value.ToString()
        '        ' Ubah warna baris berdasarkan nilai kolom "Status"
        '        If statusValue = "Celup" Then
        '            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        '        ElseIf statusValue = "Kain" Then
        '            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Khaki
        '        Else
        '            ' Warna default
        '            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        '        End If
        '    End If
        'End If

        If dgv1.ColumnCount > 15 Then
            ' Tambahkan nomor baris di HeaderCell
            dgv1.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()

            ' Periksa apakah DataBoundItem ada
            If dgv1.Rows(e.RowIndex).DataBoundItem IsNot Nothing Then
                ' Ambil nilai "Status" langsung dari sumber data
                Dim statusValue As String = TryCast(dgv1.Rows(e.RowIndex).Cells("status").Value, String) ' Ganti "Status" dengan nama kolom di data sumber

                ' Jika nilai tidak null, ubah warna berdasarkan status
                If Not String.IsNullOrEmpty(statusValue) Then
                    Select Case statusValue
                        Case "Celup"
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "Kain"
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Khaki
                        Case Else
                            dgv1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    End Select
                End If
            End If
        End If

    End Sub
    Private Sub dgv1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.Sorted

    End Sub

    Private Sub hitungjumlah()
        'Dim totaldpp, totalppn, grantotal, totaltransfer As Decimal
        'totaldpp = 0
        'totalppn = 0
        'grantotal = 0
        'totaltransfer = 0
        'For i As Integer = 0 To dgv1.Rows.Count - 1
        '    totaldpp = totaldpp + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
        '    totalppn = totalppn + Decimal.Round((dgv1.Rows(i).Cells(10).Value), 10)
        '    grantotal = grantotal + Decimal.Round((dgv1.Rows(i).Cells(11).Value), 10)
        '    totaltransfer = totaltransfer + Decimal.Round((dgv1.Rows(i).Cells(13).Value), 10)
        'Next
        'txt_total_dpp.Text = totaldpp.ToString("#,##0.00########")
        'txt_total_ppn.Text = totalppn.ToString("#,##0.00########")
        'txt_gran_total.Text = grantotal.ToString("#,##0.00########")
        'txt_transfer.Text = totaltransfer.ToString("#,##0.00########")

        Dim totaldpp_kain, totalppn_kain, grantotal_kain, totaltransfer_kain As Decimal
        Dim totaldpp_celup, totalppn_celup, grantotal_celup, totaltransfer_celup As Decimal
        totaldpp_kain = 0
        totalppn_kain = 0
        grantotal_kain = 0
        totaltransfer_kain = 0
        totaldpp_celup = 0
        totalppn_celup = 0
        grantotal_celup = 0
        totaltransfer_celup = 0
        For i As Integer = 0 To dgv1.Rows.Count - 1
            If dgv1.Rows(i).Cells(16).Value = "Celup" Then
                totaldpp_celup = totaldpp_celup + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
                totalppn_celup = totalppn_celup + Decimal.Round((dgv1.Rows(i).Cells(10).Value), 10)
                grantotal_celup = grantotal_celup + Decimal.Round((dgv1.Rows(i).Cells(11).Value), 10)
                totaltransfer_celup = totaltransfer_celup + Decimal.Round((dgv1.Rows(i).Cells(13).Value), 10)
            Else
                totaldpp_kain = totaldpp_kain + Decimal.Round((dgv1.Rows(i).Cells(9).Value), 10)
                totalppn_kain = totalppn_kain + Decimal.Round((dgv1.Rows(i).Cells(10).Value), 10)
                grantotal_kain = grantotal_kain + Decimal.Round((dgv1.Rows(i).Cells(11).Value), 10)
                totaltransfer_kain = totaltransfer_kain + Decimal.Round((dgv1.Rows(i).Cells(11).Value), 10)
            End If
        Next
        txt_total_dpp_kain.Text = totaldpp_kain.ToString("#,##0.00########")
        txt_total_ppn_kain.Text = totalppn_kain.ToString("#,##0.00########")
        txt_gran_total_kain.Text = grantotal_kain.ToString("#,##0.00########")
        txt_transfer_kain.Text = totaltransfer_kain.ToString("#,##0.00########")
        txt_total_dpp_celup.Text = totaldpp_celup.ToString("#,##0.00########")
        txt_total_ppn_celup.Text = totalppn_celup.ToString("#,##0.00########")
        txt_gran_total_celup.Text = grantotal_celup.ToString("#,##0.00########")
        txt_transfer_celup.Text = totaltransfer_celup.ToString("#,##0.00########")
    End Sub

    Private Sub ts_celup_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_celup_baru.Click
        form_input_penjualan_celup.Show()
        form_input_penjualan_celup.Focus()
    End Sub

    Private Sub ts_perbarui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_perbarui.Click
        Call awal()
        Cbo_Supplier.Text = ""
        btn_cari.Text = "CARI"
        dgv1.Focus()
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgv1.RowCount = 0 Then
                    MsgBox("Tidak Terdapat data untuk Di tampilkan")
                Else
                    If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                        form_tampil_penjualan_celup.Show()
                        form_tampil_penjualan_celup.Focus()
                        Dim cellValue As String = dgv1.CurrentRow.Cells(18).Value.ToString()
                        form_tampil_penjualan_celup.Txt_kode.Text = cellValue
                    Else
                        form_tampil_penjualan_kain.Show()
                        form_tampil_penjualan_kain.Focus()
                        form_tampil_penjualan_kain.Txt_kode.Text = dgv1.CurrentRow.Cells(18).Value
                        form_tampil_penjualan_kain.btn_cari.PerformClick()
                        'Dim cellValue As String = dgv1.CurrentRow.Cells(18).Value.ToString()
                        'form_tampil_penjualan_kain.Txt_kode.Text = cellValue
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ts_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_hapus.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di HAPUS")
            Else
                If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                    Using conx As New MySqlConnection(sLocalConn)
                        If MsgBox("Yakin Data PENJUALAN dengan No SJ : " & dgv1.CurrentRow.Cells(3).Value & " Akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                            Using cony As New MySqlConnection(sLocalConn)
                                cony.Open()
                                Dim sqly = "DELETE FROM tbpenjualan WHERE kode='" & dgv1.CurrentRow.Cells(18).Value & "'"
                                Using cmdy As New MySqlCommand(sqly, cony)
                                    cmdy.ExecuteNonQuery()
                                End Using
                            End Using
                            MessageBox.Show("Data PENJUALAN dengan No SJ : " & dgv1.CurrentRow.Cells(3).Value & " berhasil di Hapus", "Validasi Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btn_cari.PerformClick()
                        End If
                    End Using
                    form_menu_utama.btn_hitung_bukpot.Visible = True
                    form_menu_utama.btn_hitung_bukpot.PerformClick()
                Else
                    form_hapus_penjualan_kain.Show()
                    form_hapus_penjualan_kain.Focus()
                    form_hapus_penjualan_kain.Txt_kode.Text = dgv1.CurrentRow.Cells(18).Value
                    form_hapus_penjualan_kain.btn_cari.PerformClick()
                End If
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan di HAPUS")
        End Try
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di UBAH")
            Else
                If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                    form_edit_penjualan_celup.Show()
                    form_edit_penjualan_celup.Focus()
                    Dim cellValue As String = dgv1.CurrentRow.Cells(18).Value.ToString()
                    form_edit_penjualan_celup.Txt_kode.Text = cellValue
                Else
                    form_edit_penjualan_kain.Show()
                    form_edit_penjualan_kain.Focus()
                    form_edit_penjualan_kain.Txt_kode.Text = dgv1.CurrentRow.Cells(18).Value
                    form_edit_penjualan_kain.btn_cari.PerformClick()
                End If
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan di UBAH")
        End Try
    End Sub

    Private Sub Cbo_Supplier_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Supplier.GotFocus
        If Cbo_Supplier.Text = "" Then
            Call isicbosupplier()
        Else
            Call carisupplier()
        End If
        dgv_supplier.Visible = True
    End Sub
    Private Sub btn_supplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_supplier.Click
        btn_cari.Focus()
        dgv_supplier.Visible = False
        Cbo_Supplier.Text = ""
    End Sub
    Private Sub headertablesupplier()
        dgv_supplier.ColumnHeadersVisible = False
        dgv_supplier.RowHeadersVisible = False
        dgv_supplier.Columns(0).Width = 300
    End Sub
    Private Sub isicbosupplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT nama From tbclient ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_supplier.DataSource = dsx.Tables("tbclient")
                            Call headertablesupplier()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub carisupplier()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT nama From tbclient WHERE nama like '%" & Cbo_Supplier.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbclient")
                            dgv_supplier.DataSource = dsx.Tables("tbclient")
                            Call headertablesupplier()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cbo_Supplier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Supplier.TextChanged
        If Cbo_Supplier.Text = "" Then
            Call isicbosupplier()
        Else
            Call carisupplier()
        End If
    End Sub
    Private Sub dgv_supplier_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_supplier.CellMouseClick
        Try
            Dim i As Integer
            i = Me.dgv_supplier.CurrentRow.Index
            With dgv_supplier.Rows.Item(i)
                Cbo_Supplier.Text = dgv_supplier.Rows(i).Cells(0).Value
            End With
            btn_cari.Focus()
            dgv_supplier.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        ts_perbarui.PerformClick()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        If Cbo_Supplier.Text = "" Then
            Call isidgvpenjualan()
        Else
            Call isidgvpenjualanbyclient()
        End If
    End Sub
    Private Sub isidgvpenjualanbyclient()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan WHERE supplier = '" & Cbo_Supplier.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                'Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga,dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan ORDER BY Tanggal ASC"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv1.DataSource = dsx.Tables("tbpenjualan")
                            Call atur_dgv_induk()
                            Call hitungjumlah()
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

    Private Sub dtp_akhir_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_akhir.TextChanged, dtp_awal.TextChanged
        If dtp_awal.Value > dtp_akhir.Value Then
            dtp_akhir.Text = dtp_awal.Text
        End If
    End Sub

    Private Sub ts_kain_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_kain_baru.Click
        form_input_penjualan_kain.Show()
        form_input_penjualan_kain.Focus()
    End Sub
    Private Sub ts_generate_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_generate_sj.Click
        form_generate_sj_penjualan_baru.Show()
        form_generate_sj_penjualan_baru.Focus()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If dgv1.RowCount = 0 Then
            MsgBox("Tidak ada Data Penjualan tidak bisa di Ekspor")
        Else
            Dim txtdate As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            Call gantiMakloon()
            ExportDataGridViewToExcelEPPlus(dgv1, "D:\Ekspor\Penjualan " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub
    Public Sub ExportDataGridViewToExcelEPPlusLama(ByVal dgv1 As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Penjualan")
                ' Hapus kolom pertama dari DataGridView jika ada
                If dgv1.Columns.Count > 0 Then
                    dgv1.Columns.RemoveAt(0)
                    dgv1.Columns.RemoveAt(4)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                End If
                ' Tambahkan header kolom
                ws.Cells(1, 1).Value = "NO" ' Header untuk kolom nomor urut
                ws.Cells(1, 1).Style.Font.Bold = True
                ws.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(1, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                For col As Integer = 1 To dgv1.Columns.Count
                    Dim cell = ws.Cells(1, col + 1)
                    cell.Value = dgv1.Columns(col - 1).HeaderText
                    cell.Style.Font.Bold = True
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                ' Tambahkan baris data
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    ' Tambahkan nomor urut di kolom pertama
                    Dim cellNo = ws.Cells(row + 2, 1)
                    cellNo.Value = row + 1
                    cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    Dim dgvBackColor As Color = dgv1.Rows(row).DefaultCellStyle.BackColor

                    For col As Integer = 0 To dgv1.Columns.Count - 1
                        Dim cell = ws.Cells(row + 2, col + 2)
                        cell.Value = dgv1(col, row).Value
                        If TypeOf dgv1(col, row).Value Is DateTime Then
                            cell.Style.Numberformat.Format = "dd/mm/yyyy"
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ElseIf IsNumeric(dgv1(col, row).Value) Then
                            'cell.Style.Numberformat.Format = "#,##0.00########"
                            If col = 5 Or col = 6 Then
                                cell.Style.Numberformat.Format = "#,##0.00########"
                            Else
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        Else
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        End If
                        If col = 1 Or col = 8 AndAlso TypeOf dgv1(col, row).Value Is String Then
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        End If

                        If col = 9 AndAlso TypeOf dgv1(col, row).Value Is DateTime Then
                            Dim dt As DateTime = DirectCast(dgv1(col, row).Value, DateTime)
                            cell.Value = dt.ToString("MMMM yyyy", New CultureInfo("id-ID"))
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        End If

                        ' Terapkan warna baris dari DataGridView
                        If dgvBackColor <> Color.Empty Then
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                            cell.Style.Fill.BackgroundColor.SetColor(dgvBackColor)
                        End If

                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next
                ' Auto-fit the columns
                ws.Cells(ws.Dimension.Address).AutoFitColumns()
                ' Simpan workbook ke file
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Data ke Excel Berhasil")
                ts_perbarui.PerformClick()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub ExportDataGridViewToExcelEPPlus(ByVal dgv1 As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Penjualan")
                ' Hapus kolom pertama dari DataGridView jika ada
                If dgv1.Columns.Count > 0 Then
                    dgv1.Columns.RemoveAt(0)
                    dgv1.Columns.RemoveAt(4)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                    dgv1.Columns.RemoveAt(12)
                End If
                ' Tambahkan header kolom
                ws.Cells(1, 1).Value = "NO" ' Header untuk kolom nomor urut
                ws.Cells(1, 1).Style.Font.Bold = True
                ws.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(1, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(1, 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                For col As Integer = 1 To dgv1.Columns.Count
                    Dim cell = ws.Cells(1, col + 1)
                    cell.Value = dgv1.Columns(col - 1).HeaderText
                    cell.Style.Font.Bold = True
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray)
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                ' Tambahkan baris data
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    ' Tambahkan nomor urut di kolom pertama
                    Dim cellNo = ws.Cells(row + 2, 1)
                    cellNo.Value = row + 1
                    cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    Dim dgvBackColor As Color = dgv1.Rows(row).DefaultCellStyle.BackColor

                    For col As Integer = 0 To dgv1.Columns.Count - 1
                        Dim cell = ws.Cells(row + 2, col + 2)
                        cell.Value = dgv1(col, row).Value
                        If TypeOf dgv1(col, row).Value Is DateTime Then
                            cell.Style.Numberformat.Format = "dd/mm/yyyy"
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ElseIf IsNumeric(dgv1(col, row).Value) Then
                            'cell.Style.Numberformat.Format = "#,##0.00########"
                            If col = 5 Or col = 6 Then
                                cell.Style.Numberformat.Format = "#,##0.00########"
                            Else
                                cell.Style.Numberformat.Format = "#,##0.00"
                            End If
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        Else
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        End If
                        If col = 1 Or col = 8 AndAlso TypeOf dgv1(col, row).Value Is String Then
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        End If

                        If col = 9 AndAlso TypeOf dgv1(col, row).Value Is DateTime Then
                            Dim dt As DateTime = DirectCast(dgv1(col, row).Value, DateTime)
                            cell.Value = dt.ToString("MMMM yyyy", New CultureInfo("id-ID"))
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        End If


                        ' Terapkan warna baris dari DataGridView
                        If dgvBackColor <> Color.Empty Then
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid
                            cell.Style.Fill.BackgroundColor.SetColor(dgvBackColor)
                        End If

                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                Next


                ' Tambahkan baris total
                Dim totalRow As Integer = dgv1.Rows.Count + 3
                'ws.Cells(totalRow, 1).Value = ""
                'ws.Cells(totalRow, 2).Value = ""
                'ws.Cells(totalRow, 3).Value = ""
                'ws.Cells(totalRow, 4).Value = ""
                ws.Cells(totalRow, 7).Value = "TOTAL"
                ws.Cells(totalRow, 7).Style.Font.Bold = True
                ws.Cells(totalRow, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

                Dim noFaktur As New HashSet(Of String)
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    Dim faktur = dgv1(3, row).Value.ToString().Trim()
                    If Not String.IsNullOrEmpty(faktur) Then
                        noFaktur.Add(faktur)
                    End If
                Next
                Dim jumlahFaktur = noFaktur.Count
                If jumlahFaktur = 0 Then
                    ws.Cells(totalRow, 8).Value = "0 lembar FP"
                Else
                    ws.Cells(totalRow, 8).Value = jumlahFaktur.ToString() + " lembar FP"
                End If
                ws.Cells(totalRow, 8).Style.Font.Bold = True
                ws.Cells(totalRow, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

                '---
                Dim total9 As Decimal = 0
                Dim total10 As Decimal = 0
                Dim total11 As Decimal = 0
                For row As Integer = 0 To dgv1.Rows.Count - 1
                    total9 += dgv1(7, row).Value
                    total10 += dgv1(8, row).Value
                    total11 += dgv1(9, row).Value
                Next
                ws.Cells(totalRow, 9).Value = total9
                ws.Cells(totalRow, 9).Style.Font.Bold = True
                ws.Cells(totalRow, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(totalRow, 9).Style.Numberformat.Format = "#,##0.00"

                ws.Cells(totalRow, 10).Value = total10
                ws.Cells(totalRow, 10).Style.Font.Bold = True
                ws.Cells(totalRow, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(totalRow, 10).Style.Numberformat.Format = "#,##0.00"

                ws.Cells(totalRow, 11).Value = total11
                ws.Cells(totalRow, 11).Style.Font.Bold = True
                ws.Cells(totalRow, 11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(totalRow, 11).Style.Numberformat.Format = "#,##0.00"

                ' Rentang kolom 7-11
                Dim cellRange = ws.Cells(totalRow, 7, totalRow, 11)

                ' Menambahkan border hitam untuk seluruh rentang
                Dim border = cellRange.Style.Border
                border.Top.Style = ExcelBorderStyle.Thin
                border.Bottom.Style = ExcelBorderStyle.Thin
                border.Left.Style = ExcelBorderStyle.Thin
                border.Right.Style = ExcelBorderStyle.Thin

                ' Mengatur warna sel menggunakan dgvBackColor untuk seluruh rentang
                cellRange.Style.Fill.PatternType = ExcelFillStyle.Solid
                cellRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                ' Auto-fit the columns
                ws.Cells(ws.Dimension.Address).AutoFitColumns()
                ' Simpan workbook ke file
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Data ke Excel Berhasil")

                btn_cari.PerformClick()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub gantiMakloon()
        'dgv1.Columns(5).ReadOnly = False ' Kolom 6 (indeks 5)
        For row As Integer = 0 To dgv1.Rows.Count - 1
            ' Mengambil nilai dari kolom 17 (status) dan kolom 18 (genap/ganjil)
            Dim statusValue As String = dgv1.Rows(row).Cells(16).Value.ToString() ' Kolom ke-17 (status)
            Dim numericValue As Integer
            If Integer.TryParse(dgv1.Rows(row).Cells(17).Value.ToString(), numericValue) Then ' Kolom ke-18 (genap/ganjil)
                If statusValue = "Celup" Then
                    ' Periksa apakah baris ganjil atau genap dan ubah nilai kolom 6 (misalnya)
                    If numericValue Mod 2 = 0 Then ' Baris genap
                        dgv1.Rows(row).Cells(6).Value = "Jasa Makloon" ' Kolom 6 diubah
                    Else ' Baris ganjil
                        dgv1.Rows(row).Cells(6).Value = "Penggantian Obat Makloon" ' Kolom 6 diubah
                    End If
                End If
            End If
        Next
        'dgv1.Columns(5).ReadOnly = True  ' Kolom 6 (indeks 5)

    End Sub
    Private Sub ts_gabung_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_gabung_sj.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di Gabung SJ")
            Else
                If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                    MsgBox("Penjualan yang dipilih tidak bisa di Gabung SJ")
                Else
                    Call isidgvgabungsj()

                    Dim allCellsFilled As Integer = 0 ' Anggap semua sel sudah terisi
                    For i As Integer = 0 To dgv2.Rows.Count - 1
                        If dgv2.Rows(i).Cells(19).Value Is Nothing OrElse dgv2.Rows(i).Cells(19).Value.ToString() = "" Then
                            allCellsFilled += 1
                        Else
                            allCellsFilled += 0
                        End If
                    Next

                    Dim dtptoday As New DateTimePicker
                    Txt_kode.Text = dtptoday.Value.ToString("dd-MM-yyyyHH:mm:ss")
                    Txt_kode.Text = Txt_kode.Text.Replace("-", "").Replace(":", "")
                    If dgv2.Rows.Count < 2 Then
                        dgv2.Columns.Clear()
                        MsgBox("Penjualan yang dipilih tidak bisa di Gabung SJ")
                    ElseIf allCellsFilled = 0 Then
                        MsgBox("Penjualan yang dipilih sudah di Gabung SJ")
                    Else
                        panelGabung.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan di Gabung SJ")
        End Try
    End Sub
    Private Sub isidgvgabungsj()
        Try
            ' Pastikan baris aktif di dgv1
            If dgv1.CurrentRow Is Nothing Then
                MessageBox.Show("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan di Gabung SJ")
                Exit Sub
            End If

            ' Ambil data dari baris aktif
            Dim supplier As String = dgv1.CurrentRow.Cells(1).Value.ToString() ' Index 1 untuk supplier
            Dim tanggal As Date = Convert.ToDateTime(dgv1.CurrentRow.Cells(2).Value) ' Index 2 untuk tanggal

            ' Konfigurasi DataGridView dgv2
            dgv2.Columns.Clear()

            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                ' Query untuk mencari data berdasarkan supplier dan tanggal
                Dim sqlx As String = "SELECT id_jual, supplier, tanggal, surat_jalan, no_faktur, jenis_biaya, nama_kain, jumlah, harga, dpp, ppn, total, pph23, transfer, total_polos, satuan, status, baris, kode, gabung_faktur " &
                                     "FROM tbpenjualan " &
                                     "WHERE supplier = @supplier AND tanggal = @tanggal AND no_faktur = '' AND jenis_biaya = 'Kain' AND gabung_faktur = ''" &
                                     "ORDER BY tanggal ASC"

                Using cmdx As New MySqlCommand(sqlx, conx)
                    ' Tambahkan parameter
                    cmdx.Parameters.AddWithValue("@supplier", supplier)
                    cmdx.Parameters.AddWithValue("@tanggal", tanggal)

                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv2.DataSource = dsx.Tables("tbpenjualan")
                            Call atur_dgv_induk_1()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub atur_dgv_induk_1()
        dgv2.Columns(1).HeaderText = "NAMA CLIENT"
        dgv2.Columns(2).HeaderText = "TANGGAL"
        dgv2.Columns(3).HeaderText = "SURAT JALAN"
        dgv2.Columns(4).HeaderText = "FAKTUR PAJAK"
        dgv2.Columns(6).HeaderText = "NAMA KAIN"
        dgv2.Columns(7).HeaderText = "QTY"
        dgv2.Columns(8).HeaderText = "HARGA (Rp)"
        dgv2.Columns(9).HeaderText = "DPP (Rp)"
        dgv2.Columns(10).HeaderText = "PPN (Rp)"
        dgv2.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        dgv2.Columns(12).HeaderText = "PPH23 (Rp)"
        dgv2.Columns(13).HeaderText = "TOTAL TRANSFER (Rp)"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.Columns(0).Visible = False
        dgv2.Columns(5).Visible = False
        dgv2.Columns(14).Visible = False
        dgv2.Columns(15).Visible = False
        dgv2.Columns(16).Visible = False
        dgv2.Columns(17).Visible = False
        dgv2.Columns(18).Visible = False
        dgv2.Columns(19).Visible = False
        dgv2.RowHeadersWidth = 60
        dgv2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        dgv2.Columns(1).Width = 200
        'dgv2.Columns(2).Width = 70
        'dgv2.Columns(3).Width = 130
        'dgv2.Columns(4).Width = 130
        'dgv2.Columns(5).Width = 130
        'dgv2.Columns(6).Width = 130
        'dgv2.Columns(7).Width = 130
        'dgv2.Columns(8).Width = 130
        'dgv2.Columns(9).Width = 130
        'dgv2.Columns(10).Width = 85
        dgv2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(9).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv2.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        dgv2.Columns.Clear()
        panelGabung.Visible = False
        Txt_kode.Text = ""
    End Sub
    Private Sub btnGabung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGabung.Click
        ' Konfirmasi dari pengguna
        Dim dialogResult As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menggabungkan Surat Jalan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialogResult = dialogResult.Yes Then
            Try
                Using cony As New MySqlConnection(sLocalConn)
                    cony.Open()

                    ' Iterasi setiap baris di dgv2 untuk melakukan update
                    For Each row As DataGridViewRow In dgv2.Rows
                        If Not row.IsNewRow Then
                            Dim idJual As String = row.Cells(0).Value.ToString() ' Kolom id_jual (index 0)

                            ' Query untuk update tbpenjualan
                            Dim sqly As String = "UPDATE tbpenjualan SET gabung_faktur = @gabung_faktur WHERE id_jual = @id_jual"

                            Using cmdy As New MySqlCommand(sqly, cony)
                                cmdy.Parameters.Clear()
                                cmdy.Parameters.AddWithValue("@gabung_faktur", Txt_kode.Text)
                                cmdy.Parameters.AddWithValue("@id_jual", idJual)
                                cmdy.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                End Using
                MessageBox.Show("Data Penjualn berhasil di Gabung SJ", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgv2.Columns.Clear()
                panelGabung.Visible = False
                Txt_kode.Text = ""
                btn_cari.PerformClick()
            Catch ex As Exception
                MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        If dgv2.CurrentRow Is Nothing Then
            MessageBox.Show("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan dihapus untuk Gabung SJ")
            Exit Sub
        End If
        dgv2.Rows.RemoveAt(dgv2.CurrentRow.Index)
        If dgv2.Rows.Count = 0 Then
            dgv2.Columns.Clear()
            panelGabung.Visible = False
            Txt_kode.Text = ""
            btn_cari.PerformClick()
        End If
    End Sub

    'Fungsi potong nama client
    Private Function AmbilDuaKata(ByVal txt As TextBox) As String
        Dim kata() As String = txt.Text.Trim().Split(" "c)
        If kata.Length >= 2 Then
            Return kata(0) & " " & kata(1)
        ElseIf kata.Length = 1 Then
            Return kata(0)
        Else
            Return ""
        End If
    End Function
    'Fungsi potong alamat client
    Private Function AmbilDelapanKata(ByVal txt As TextBox) As String
        Dim kata() As String = txt.Text.Trim().Split(" "c)
        Dim hasil As String = ""
        Dim jumlahKata As Integer = Math.Min(8, kata.Length)
        For i As Integer = 0 To jumlahKata - 1
            hasil &= kata(i) & " "
        Next
        Return hasil.Trim()
    End Function
    ' Fungsi untuk mendapatkan nilai Decimal dari sel DGV
    Private Function GetDecimalValue(ByVal cellValue As Object, Optional ByVal defaultValue As Decimal = 0) As Decimal
        Dim result As Decimal
        If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) AndAlso Decimal.TryParse(cellValue.ToString(), result) Then
            Return result
        End If
        Return defaultValue
    End Function
    ' Fungsi untuk mendapatkan nilai String dari sel DGV
    Private Function GetStringValue(ByVal cellValue As Object, Optional ByVal defaultValue As String = "") As String
        If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
            Return cellValue.ToString().Trim()
        End If
        Return defaultValue
    End Function

    '-----FITUR PRINT

    'surat jalan
    Private Sub ts_print_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print_sj.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Print Surat Jalan")
            ElseIf dgv1.CurrentRow.Cells(3).Value = "" And dgv1.CurrentRow.Cells(4).Value = "" Then
                MsgBox("Data penjualan belum mempunyai Surat Jalan")
            Else
                dtp_tanggal_print_sj.Value = dgv1.CurrentRow.Cells(2).Value
                txt_ket_sj.Text = ""
                txt_client.Text = dgv1.CurrentRow.Cells(1).Value
                txt_no_sj.Text = dgv1.CurrentRow.Cells(3).Value
                Call cariclient()
                Call carisj()
                Call atur_print_sj()
                panelPrintSuratJalan.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Print Surat Jalan")
        End Try
    End Sub
    Private Sub cariclient()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT alamat, kota FROM tbclient WHERE nama = @nama"
            Using cmdx As New MySqlCommand(sqlx, conx)
                ' Tambahkan parameter untuk menghindari SQL Injection
                cmdx.Parameters.AddWithValue("@nama", txt_client.Text)
                Using reader As MySqlDataReader = cmdx.ExecuteReader()
                    If reader.Read() Then
                        ' Jika data ditemukan, masukkan ke TextBox
                        Dim alamat As String = reader("alamat").ToString()
                        ' Batasi kota hingga 50 karakter
                        If alamat.Length > 80 Then
                            txt_alamat_client.Text = alamat.Substring(0, 80)
                        Else
                            txt_alamat_client.Text = alamat
                        End If
                        txt_kota_client.Text = reader("kota").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub carisj()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = ""
            If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Obat'"
            Else
                sqlx = "SELECT nama_kain, jumlah, satuan FROM tbpenjualan WHERE surat_jalan = @surat_jalan AND jenis_biaya = 'Kain'"
            End If
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@surat_jalan", txt_no_sj.Text)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbpenjualan")
                        ' Bind data ke DataGridView
                        dgv_print_sj.DataSource = dsx.Tables("tbpenjualan")
                        ' Atur seluruh DataGridView ke ReadOnly = False
                        dgv_print_sj.ReadOnly = False
                        ' Setel ReadOnly untuk kolom yang ada (selain Keterangan)
                        For Each col As DataGridViewColumn In dgv_print_sj.Columns
                            col.ReadOnly = True
                        Next
                        ' Tambahkan kolom baru untuk Keterangan jika belum ada
                        If Not dgv_print_sj.Columns.Contains("Keterangan") Then
                            Dim colKeterangan As New DataGridViewTextBoxColumn()
                            colKeterangan.Name = "Keterangan"
                            colKeterangan.HeaderText = "Keterangan"
                            colKeterangan.MaxInputLength = 25
                            colKeterangan.ReadOnly = False ' Hanya kolom ini yang bisa diinput
                            dgv_print_sj.Columns.Add(colKeterangan)
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub atur_print_sj()
        dgv_print_sj.Columns(0).HeaderText = "NAMA BARANG"
        dgv_print_sj.Columns(1).HeaderText = "KUANTITAS"
        dgv_print_sj.Columns(2).HeaderText = "SATUAN"
        dgv_print_sj.Columns(3).HeaderText = "KETERANGAN"
        For Each column As DataGridViewColumn In dgv_print_sj.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_print_sj.RowHeadersWidth = 60
        dgv_print_sj.Columns(0).Width = 220
        dgv_print_sj.Columns(1).Width = 150
        dgv_print_sj.Columns(2).Width = 100
        dgv_print_sj.Columns(3).Width = 270
        dgv_print_sj.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_print_sj.Columns(1).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv_print_sj_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_print_sj.CellFormatting
        dgv_print_sj.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub SatuanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SatuanToolStripMenuItem.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Print Surat Jalan")
            ElseIf dgv1.CurrentRow.Cells(3).Value = "" And dgv1.CurrentRow.Cells(4).Value = "" Then
                MsgBox("Data penjualan belum mempunyai Surat Jalan")
            Else
                dtp_tanggal_print_sj.Value = dgv1.CurrentRow.Cells(2).Value
                txt_ket_sj.Text = ""
                txt_client.Text = dgv1.CurrentRow.Cells(1).Value
                txt_no_sj.Text = dgv1.CurrentRow.Cells(3).Value
                Call cariclient()
                Call carisj()
                Call atur_print_sj()
                panelPrintSuratJalan.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Print Surat Jalan")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dgv_print_sj.Columns.Clear()
        panelPrintSuratJalan.Visible = False
        txt_ket_sj.Text = ""
    End Sub
    Private Sub btnPrintSj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSj.Click
        If txt_tanggal_print_sj.Text = "" Then
            MsgBox("Silahkan isi Tanggal Surat Jalan terlebih dahulu")
        Else
            Dim tbsuratjalan As New DataTable
            With tbsuratjalan
                .Columns.Add("client")
                .Columns.Add("alamat_client")
                .Columns.Add("kota_client")
                .Columns.Add("no_surat_jalan")
                .Columns.Add("tanggal")
                .Columns.Add("ket_bawah")
            End With
            tbsuratjalan.Rows.Add(txt_client.Text, txt_alamat_client.Text, txt_kota_client.Text, txt_no_sj.Text, txt_tanggal_print_sj.Text, txt_ket_sj.Text)

            Dim tbdata As New DataTable
            ' Tambahkan kolom ke DataTable
            With tbdata
                .Columns.Add("no")
                .Columns.Add("nama_barang")
                .Columns.Add("kuantitas")
                .Columns.Add("satuan")
                .Columns.Add("keterangan")
            End With
            ' Loop melalui baris di DataGridView dan tambahkan ke DataTable
            For Each row As DataGridViewRow In dgv_print_sj.Rows
                ' Abaikan baris kosong
                If Not row.IsNewRow Then
                    tbdata.Rows.Add(row.HeaderCell.Value, "Kain " & row.Cells("nama_kain").Value, Format(row.Cells("jumlah").Value, "#,##0.00"), row.Cells("satuan").Value, row.Cells("Keterangan").Value)
                End If
            Next

            form_print_surat_jalan.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbsuratjalan
            form_print_surat_jalan.ReportViewer1.LocalReport.DataSources.Item(1).Value = tbdata
            form_print_surat_jalan.ShowDialog()
            form_print_surat_jalan.Dispose()
        End If
    End Sub
    Private Sub dtp_tanggal_print_sj_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal_print_sj.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal_print_sj.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("dd MMMM yyyy", cultureInfo)
        txt_tanggal_print_sj.Text = formattedDate
    End Sub
    Private Sub btn_kosong_tanggal_print_sj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong_tanggal_print_sj.Click
        'If Not txt_tanggal_print_sj.Text = "" Then
        '    txt_tanggal_print_sj.Text = ""
        'End If
    End Sub
    Private Sub btn_ekspor_surat_jalan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ekspor_surat_jalan.Click
        If dgv_print_sj.RowCount = 0 Then
            MsgBox("Tidak ada Data Penjualan tidak bisa di Ekspor")
        Else
            Dim txtdate As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            Dim namaclient As String = AmbilDuaKata(txt_client)
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            EksporSuratJalan(dgv_print_sj, "D:\Ekspor\Surat Jalan " & namaclient & " " & txt_tanggal_print_sj.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub
    Private Sub EksporSuratJalan(ByVal dgv_print_sj As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Surat Jalan")
                ' === Set judul laporan ===
                ws.Cells.Style.Font.Name = "Arial"
                Dim values As String() = {
                    "CV. Artha Mekar Lestari",
                    "Jl. Halimun No. 5",
                    "Malabar, Kota Bandung"}
                For i As Integer = 0 To values.Length - 1
                    With ws.Cells(i + 1, 1)
                        .Value = values(i)
                        .Style.Font.Size = 9
                    End With
                Next
                For i As Integer = 1 To 3
                    ws.Row(i).Height = 12 ' 16 pixel ≈ 12 point
                Next
                With ws.Cells(4, 1)
                    .Value = "SURAT JALAN"
                    .Style.Font.Size = 24
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With
                ws.Cells(4, 1, 4, 9).Merge = True
                ws.Row(4).Height = 30

                Dim columnWidths As Double() = {4.71, 13.84, 1.43, 18.41, 13.42, 9.42, 1.43, 13.42, 13.13}
                For i As Integer = 0 To columnWidths.Length - 1
                    ws.Column(i + 1).Width = columnWidths(i)
                Next
                For i As Integer = 5 To 21
                    ws.Row(i).Height = 12
                    ws.Row(i).Style.Font.Size = 9
                Next
                ws.Cells(6, 1).Value = "Kepada"
                ws.Cells(6, 3).Value = ":"
                ws.Cells(6, 4).Value = txt_client.Text
                ws.Cells(7, 4).Value = AmbilDelapanKata(txt_alamat_client)
                ws.Cells(8, 4).Value = txt_kota_client.Text
                ws.Cells(6, 4, 6, 9).Merge = True
                ws.Cells(7, 4, 7, 9).Merge = True
                ws.Cells(8, 4, 8, 9).Merge = True
                ws.Cells(10, 1, 10, 9).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                ws.Cells(10, 1).Value = "No. Surat Jalan"
                ws.Cells(10, 3).Value = ":"
                ws.Cells(10, 4).Value = txt_no_sj.Text
                ws.Cells(10, 6).Value = "Tanggal"
                ws.Cells(10, 7).Value = ":"
                ws.Cells(10, 8).Value = txt_tanggal_print_sj.Text

                For i As Integer = 12 To 18
                    For j As Integer = 1 To 9
                        ws.Cells(i, j).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                    ws.Cells(i, 2, i, 4).Merge = True
                    ws.Cells(i, 6, i, 7).Merge = True
                    ws.Cells(i, 8, i, 9).Merge = True
                Next
                ws.Cells(12, 1).Value = "No."
                ws.Cells(12, 2).Value = "Nama Barang"
                ws.Cells(12, 5).Value = "Kuantitas"
                ws.Cells(12, 6).Value = "Satuan"
                ws.Cells(12, 8).Value = "Keterangan"
                ws.Cells(10, 4, 10, 5).Merge = True
                ws.Cells(10, 8, 10, 9).Merge = True

                For row As Integer = 0 To dgv_print_sj.Rows.Count - 1
                    ' Pastikan baris bukan baris baru
                    If Not dgv_print_sj.Rows(row).IsNewRow Then
                        Dim cellNo = ws.Cells(row + 13, 1) ' Kolom 1 di Excel untuk nomor urut
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

                        ' Menggunakan nama kolom DGV
                        Dim cellNamaKain = "Kain " & dgv_print_sj.Rows(row).Cells("nama_kain").Value
                        Dim cellJumlah = dgv_print_sj.Rows(row).Cells("jumlah").Value
                        Dim cellSatuan = dgv_print_sj.Rows(row).Cells("satuan").Value
                        Dim cellKeterangan = dgv_print_sj.Rows(row).Cells("keterangan").Value

                        ' Pastikan data tidak kosong
                        If cellNamaKain IsNot Nothing Then
                            ws.Cells(row + 13, 2).Value = cellNamaKain.ToString().Trim()
                        End If

                        If cellJumlah IsNot Nothing AndAlso Not IsDBNull(cellJumlah) Then
                            Dim jumlah As Decimal
                            If Decimal.TryParse(cellJumlah.ToString(), jumlah) Then
                                ws.Cells(row + 13, 5).Value = jumlah
                                ws.Cells(row + 13, 5).Style.Numberformat.Format = "#,##0.00"
                                ws.Cells(row + 13, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                            Else
                                ws.Cells(row + 13, 5).Value = 0 ' Jika parsing gagal
                            End If
                        End If

                        If cellSatuan IsNot Nothing Then
                            ws.Cells(row + 13, 6).Value = cellSatuan.ToString().Trim()
                        End If

                        If cellKeterangan IsNot Nothing Then
                            ws.Cells(row + 13, 8).Value = cellKeterangan.ToString().Trim()
                        End If
                    End If
                Next
                ws.Cells(20, 2).Value = "Keterangan"
                ws.Cells(20, 3).Value = ":"
                ws.Cells(20, 4).Value = txt_ket_sj.Text
                ws.Cells(20, 4, 20, 9).Merge = True
                ws.Cells(22, 2).Value = "Yang Menerima"
                ws.Cells(27, 2).Value = "(                     )"
                ws.Cells(22, 8).Value = "Hormat Kami"
                ws.Cells(27, 8).Value = "(                     )"
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Surat Jalan ke Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    'Print Invoice
    Private Sub cariclientinv()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT alamat, kota FROM tbclient WHERE nama = @nama"
            Using cmdx As New MySqlCommand(sqlx, conx)
                ' Tambahkan parameter untuk menghindari SQL Injection
                cmdx.Parameters.AddWithValue("@nama", txt_client_inv.Text)
                Using reader As MySqlDataReader = cmdx.ExecuteReader()
                    If reader.Read() Then
                        ' Jika data ditemukan, masukkan ke TextBox
                        Dim alamat As String = reader("alamat").ToString()
                        ' Batasi kota hingga 50 karakter
                        If alamat.Length > 80 Then
                            txt_alamat_client_inv.Text = alamat.Substring(0, 80)
                        Else
                            txt_alamat_client_inv.Text = alamat
                        End If
                        txt_kota_client_inv.Text = reader("kota").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub carisjinv()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT nama_kain, jumlah, satuan, harga, dpp, jenis_biaya, status, ppn, total FROM tbpenjualan WHERE surat_jalan = @surat_jalan ORDER BY no_faktur ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@surat_jalan", txt_no_sj_inv.Text)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbpenjualan")
                        dgv_inv.DataSource = dsx.Tables("tbpenjualan")
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub carifakturinv()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT no_faktur FROM tbpenjualan WHERE surat_jalan = @suratjalan"
            Using cmdx As New MySqlCommand(sqlx, conx)
                ' Tambahkan parameter untuk menghindari SQL Injection
                cmdx.Parameters.AddWithValue("@suratjalan", txt_no_sj_inv.Text)

                Using reader As MySqlDataReader = cmdx.ExecuteReader()
                    Dim uniqueResults As New HashSet(Of String) ' Gunakan HashSet untuk menghindari duplikasi
                    While reader.Read()
                        uniqueResults.Add(reader("no_faktur").ToString())
                    End While

                    ' Gabungkan hasil dengan simbol "&"
                    If uniqueResults.Count > 0 Then
                        txt_no_faktur.Text = String.Join(" & ", uniqueResults)
                    Else
                        txt_no_faktur.Text = "" ' Kosongkan jika tidak ada hasil
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub gantiMaklooninv()
        For row As Integer = 0 To dgv_inv.Rows.Count - 1
            If dgv_inv.Rows(row).Cells(6).Value = "Celup" Then
                If dgv_inv.Rows(row).Cells(5).Value.ToString() = "Jasa" Then
                    dgv_inv.Rows(row).Cells(0).Value = "Jasa Makloon Kain " & dgv_inv.Rows(row).Cells(0).Value
                Else
                    dgv_inv.Rows(row).Cells(0).Value = "Penggantian Obat Makloon"
                End If
            Else
                dgv_inv.Rows(row).Cells(0).Value = "Kain " & dgv_inv.Rows(row).Cells(0).Value
            End If
        Next
    End Sub
    Private Sub HitungTotalDGV()
        Dim totalKolom4 As Decimal = 0
        Dim totalKolom7 As Decimal = 0
        Dim totalKolom8 As Decimal = 0

        ' Loop melalui setiap baris di DataGridView
        For Each row As DataGridViewRow In dgv_inv.Rows
            ' Abaikan baris kosong
            If Not row.IsNewRow Then
                ' Pastikan nilai kolom tidak null dan dapat dikonversi ke angka
                totalKolom4 += If(IsNumeric(row.Cells(4).Value), Convert.ToDecimal(row.Cells(4).Value), 0)
                totalKolom7 += If(IsNumeric(row.Cells(7).Value), Convert.ToDecimal(row.Cells(7).Value), 0)
                totalKolom8 += If(IsNumeric(row.Cells(8).Value), Convert.ToDecimal(row.Cells(8).Value), 0)
            End If
        Next

        ' Tampilkan hasil di TextBox
        txt_dpp_inv.Text = totalKolom4.ToString("#,##0")
        txt_ppn_inv.Text = totalKolom7.ToString("#,##0")
        txt_total_inv.Text = totalKolom8.ToString("#,##0")
    End Sub
    Private Sub atur_inv()
        dgv_inv.Columns(0).HeaderText = "NAMA BARANG"
        dgv_inv.Columns(1).HeaderText = "KUANTITAS"
        dgv_inv.Columns(2).HeaderText = "SATUAN"
        dgv_inv.Columns(3).HeaderText = "HARGA SATUAN"
        dgv_inv.Columns(4).HeaderText = "JUMLAH HARGA"
        For Each column As DataGridViewColumn In dgv_inv.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv_inv.RowHeadersWidth = 60
        dgv_inv.Columns(5).Visible = False
        dgv_inv.Columns(6).Visible = False
        dgv_inv.Columns(7).Visible = False
        dgv_inv.Columns(8).Visible = False
        dgv_inv.Columns(0).Width = 270
        dgv_inv.Columns(1).Width = 110
        dgv_inv.Columns(2).Width = 80
        dgv_inv.Columns(3).Width = 150
        dgv_inv.Columns(4).Width = 150
        dgv_inv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_inv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_inv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_inv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_inv.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        dgv_inv.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv_inv.Columns(4).DefaultCellStyle.Format = "#,##0"
    End Sub
    Private Sub ts_print_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print_invoice.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Print Invoice")
            ElseIf dgv1.CurrentRow.Cells(3).Value = "" And dgv1.CurrentRow.Cells(4).Value = "" Then
                MsgBox("Data penjualan belum mempunyai Surat Jalan")
            Else
                dtp_tanggal_inv.Value = dgv1.CurrentRow.Cells(2).Value
                txt_ket_inv.Text = ""
                txt_client_inv.Text = dgv1.CurrentRow.Cells(1).Value
                txt_no_sj_inv.Text = dgv1.CurrentRow.Cells(3).Value
                Call cariclientinv()
                Call carisjinv()
                Call carifakturinv()
                Call gantiMaklooninv()
                Call isi_ppn()
                lblPPN.Text = "PPN " & ppn & "%"
                Call HitungTotalDGV()
                Call atur_inv()

                panelPrintInvoice.Visible = True

            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Print Surat Jalan")
        End Try
    End Sub
    Private Sub btn_batal_inv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_inv.Click
        dgv_inv.Columns.Clear()
        panelPrintInvoice.Visible = False
        txt_ket_inv.Text = ""
    End Sub
    Private Sub dgv_inv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_inv.CellFormatting
        dgv_inv.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub dtp_tanggal_inv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_tanggal_inv.ValueChanged
        Dim selectedDate As DateTime = dtp_tanggal_inv.Value
        Dim cultureInfo As New CultureInfo("id-ID")
        Dim formattedDate As String = selectedDate.ToString("dd MMMM yyyy", cultureInfo)
        txt_tanggal_inv.Text = formattedDate
    End Sub
    Private Sub btn_tanggal_inv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tanggal_inv.Click
        'If Not txt_tanggal_inv.Text = "" Then
        '    txt_tanggal_inv.Text = ""
        'End If
    End Sub
    Private Sub btn_print_inv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_inv.Click
        If txt_tanggal_inv.Text = "" Then
            MsgBox("Silahkan isi Tanggal Invoice terlebih dahulu")
        Else
            Dim tbsuratjalan As New DataTable
            With tbsuratjalan
                .Columns.Add("client")
                .Columns.Add("alamat_client")
                .Columns.Add("kota_client")
                .Columns.Add("no_surat_jalan")
                .Columns.Add("tanggal")
                .Columns.Add("ket_bawah")
                .Columns.Add("no_faktur")
            End With
            tbsuratjalan.Rows.Add(txt_client_inv.Text, txt_alamat_client_inv.Text, txt_kota_client_inv.Text, txt_no_sj_inv.Text, txt_tanggal_inv.Text, txt_ket_inv.Text, _
                                  txt_no_faktur.Text)

            Dim tbdata As New DataTable
            ' Tambahkan kolom ke DataTable
            With tbdata
                .Columns.Add("no")
                .Columns.Add("nama_barang")
                .Columns.Add("kuantitas")
                .Columns.Add("satuan")
                .Columns.Add("harga_satuan")
                .Columns.Add("jumlah_harga")
                .Columns.Add("dpp")
                .Columns.Add("ppn")
                .Columns.Add("ppn_isi")
                .Columns.Add("total")
            End With
            ' Loop melalui baris di DataGridView dan tambahkan ke DataTable
            For Each row As DataGridViewRow In dgv_inv.Rows
                ' Abaikan baris kosong
                If Not row.IsNewRow Then
                    tbdata.Rows.Add(row.HeaderCell.Value, row.Cells("nama_kain").Value, Format(row.Cells("jumlah").Value, "#,##0.00"), row.Cells("satuan").Value, _
                                    Format(row.Cells("harga").Value, "#,##0.00"), Format(row.Cells("dpp").Value, "#,##0"), txt_dpp_inv.Text, lblPPN.Text, txt_ppn_inv.Text, txt_total_inv.Text)
                End If
            Next

            form_print_invoice.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbsuratjalan
            form_print_invoice.ReportViewer1.LocalReport.DataSources.Item(1).Value = tbdata
            form_print_invoice.ShowDialog()
            form_print_invoice.Dispose()
        End If
    End Sub
    Private Sub btn_ekspor_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ekspor_invoice.Click
        If dgv_inv.RowCount = 0 Then
            MsgBox("Tidak ada Data Penjualan tidak bisa di Ekspor")
        Else
            Dim txtdate As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            Dim namaclient As String = AmbilDuaKata(txt_client_inv)
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            EksporInvoice(dgv_inv, "D:\Ekspor\Invoice " & namaclient & " " & txt_tanggal_inv.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub
    Private Sub EksporInvoice(ByVal dgv_inv As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Surat Jalan")
                ' === Set judul laporan ===
                ws.Cells.Style.Font.Name = "Arial"
                Dim values As String() = {
                    "CV. Artha Mekar Lestari",
                    "Jl. Halimun No. 5",
                    "Malabar, Kota Bandung"}
                For i As Integer = 0 To values.Length - 1
                    With ws.Cells(i + 1, 1)
                        .Value = values(i)
                        .Style.Font.Size = 9
                    End With
                Next
                For i As Integer = 1 To 3
                    ws.Row(i).Height = 12 ' 16 pixel ≈ 12 point
                Next
                With ws.Cells(4, 1)
                    .Value = "INVOICE"
                    .Style.Font.Size = 24
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With
                ws.Cells(4, 1, 4, 9).Merge = True
                ws.Row(4).Height = 30

                Dim columnWidths As Double() = {4.71, 13.84, 1.43, 18.41, 13.42, 9.42, 1.43, 13.42, 13.13}
                For i As Integer = 0 To columnWidths.Length - 1
                    ws.Column(i + 1).Width = columnWidths(i)
                Next
                For i As Integer = 5 To 21
                    ws.Row(i).Height = 12
                    ws.Row(i).Style.Font.Size = 9
                Next
                ws.Cells(6, 1).Value = "Kepada"
                ws.Cells(6, 3).Value = ":"
                ws.Cells(6, 4).Value = txt_client_inv.Text
                ws.Cells(7, 4).Value = AmbilDelapanKata(txt_alamat_client_inv)
                ws.Cells(8, 4).Value = txt_kota_client_inv.Text
                ws.Cells(6, 4, 6, 9).Merge = True
                ws.Cells(7, 4, 7, 9).Merge = True
                ws.Cells(8, 4, 8, 9).Merge = True
                ws.Cells(10, 1).Value = "No. Surat Jalan"
                ws.Cells(10, 3).Value = ":"
                ws.Cells(10, 4).Value = txt_no_sj_inv.Text
                ws.Cells(10, 6).Value = "Tanggal"
                ws.Cells(10, 7).Value = ":"
                ws.Cells(10, 8).Value = txt_tanggal_inv.Text
                ws.Cells(11, 1).Value = "No. Faktur"
                ws.Cells(11, 3).Value = ":"
                ws.Cells(11, 4).Value = txt_no_faktur.Text
                ws.Cells(10, 1, 11, 9).Style.Border.BorderAround(ExcelBorderStyle.Thin)

                For i As Integer = 13 To 20
                    For j As Integer = 1 To 9
                        ws.Cells(i, j).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                    ws.Cells(i, 2, i, 4).Merge = True
                    ws.Cells(i, 6, i, 7).Merge = True
                Next
                ws.Cells(13, 1).Value = "No."
                ws.Cells(13, 2).Value = "Nama Barang"
                ws.Cells(13, 5).Value = "Kuantitas"
                ws.Cells(13, 6).Value = "Satuan"
                ws.Cells(13, 8).Value = "Harga Satuan"
                ws.Cells(13, 9).Value = "Jumlah Harga"
                ws.Cells(10, 4, 10, 5).Merge = True
                ws.Cells(11, 4, 11, 9).Merge = True

                For row As Integer = 0 To dgv_inv.Rows.Count - 1
                    If Not dgv_inv.Rows(row).IsNewRow Then
                        ' Nomor urut
                        Dim cellNo = ws.Cells(row + 14, 1)
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

                        ' Ambil nilai dari DGV dengan validasi
                        Dim namaKain As String = GetStringValue(dgv_inv.Rows(row).Cells("nama_kain").Value)
                        Dim jumlah As Decimal = GetDecimalValue(dgv_inv.Rows(row).Cells("jumlah").Value)
                        Dim satuan As String = GetStringValue(dgv_inv.Rows(row).Cells("satuan").Value)
                        Dim harga As Decimal = GetDecimalValue(dgv_inv.Rows(row).Cells("harga").Value)
                        Dim dpp As Decimal = GetDecimalValue(dgv_inv.Rows(row).Cells("dpp").Value)

                        ' Isi nilai ke Excel
                        ws.Cells(row + 14, 2).Value = namaKain
                        ws.Cells(row + 14, 5).Value = jumlah
                        ws.Cells(row + 14, 5).Style.Numberformat.Format = "#,##0.00"
                        ws.Cells(row + 14, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

                        ws.Cells(row + 14, 6).Value = satuan

                        ws.Cells(row + 14, 8).Value = harga
                        ws.Cells(row + 14, 8).Style.Numberformat.Format = "#,##0.00"
                        ws.Cells(row + 14, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

                        ws.Cells(row + 14, 9).Value = dpp
                        ws.Cells(row + 14, 9).Style.Numberformat.Format = "#,##0" ' Sesuaikan dengan harga
                        ws.Cells(row + 14, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    End If
                Next

                ' Baris mulai menaruh nilai
                Dim startRow As Integer = 18
                ws.Cells(startRow, 8).Value = "DPP"
                ws.Cells(startRow + 1, 8).Value = "PPN " & ppn & "%"
                ws.Cells(startRow + 2, 8).Value = "TOTAL"
                ws.Cells(startRow + 2, 8).Style.Font.Bold = True
                ' DPP
                Dim dpptot As Decimal
                If Decimal.TryParse(txt_dpp_inv.Text, dpptot) Then
                    With ws.Cells(startRow, 9)
                        .Value = dpptot
                        .Style.Numberformat.Format = "#,##0"
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    End With
                End If
                ' PPN
                Dim nilaippn As Decimal
                If Decimal.TryParse(txt_ppn_inv.Text, nilaippn) Then
                    With ws.Cells(startRow + 1, 9)
                        .Value = nilaippn
                        .Style.Numberformat.Format = "#,##0"
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    End With
                End If
                ' Total
                Dim total As Decimal
                If Decimal.TryParse(txt_total_inv.Text, total) Then
                    With ws.Cells(startRow + 2, 9)
                        .Value = total
                        .Style.Numberformat.Format = "#,##0"
                        .Style.Font.Bold = True
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    End With
                End If

                ws.Cells(22, 2).Value = "Keterangan"
                ws.Cells(22, 3).Value = ":"
                ws.Cells(22, 4).Value = txt_ket_inv.Text
                For i = 2 To 4
                    ws.Cells(22, i).Style.Font.Size = 9
                Next
                ws.Cells(22, 4, 22, 6).Merge = True
                ws.Cells(22, 8).Value = "Hormat Kami"
                ws.Cells(27, 8).Value = "(                     )"
                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Invoice ke Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    
    'Kontra Bon
    Private Sub ts_print_kontra_bon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print_kontra_bon.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Print Kontra Bon")
            Else
                txt_periode_kontra_bon.Text = dtp_awal.Value.ToString("MMMM yyyy", indonesiaCulture)
                txt_client_kontra_bon.Text = dgv1.CurrentRow.Cells(1).Value
                If dgv1.CurrentRow.Cells(16).Value = "Celup" Then
                    Call carikontraboncelup()
                    Call HitungTotalKontraBonCelup()
                    lbl_kontra_bon.Text = "PRINT KONTRA BON CELUP"
                    panelKontraBonCelup.Visible = True
                Else
                    Call carikontrabonkain()
                    Call HitungTotalKontraBonkain()
                    lbl_kontra_bon.Text = "PRINT KONTRA BON KAIN"
                    panelKontraBonCelup.Visible = True
                End If
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Print Kontra Bon")
        End Try
    End Sub
    Private Sub btn_batal_kontra_bon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_kontra_bon.Click
        dgv_kontra_bon.Columns.Clear()
        panelKontraBonCelup.Visible = False
        txt_periode_kontra_bon.Text = ""
        txt_client_kontra_bon.Text = ""
        lbl_kontra_bon.Text = "PRINT KONTRA BON"
        txt_total_kontra_bon.Text = ""
        txt_pph23_kontra_bon.Text = ""
        txt_transfer_kontra_bon.Text = ""
    End Sub
    Private Sub carikontraboncelup()
        dgv_kontra_bon.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT surat_jalan, total, pph23, transfer FROM tbpenjualan " &
                                 "WHERE MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun AND status = 'Celup' AND supplier = @client " &
                                 "ORDER BY surat_jalan ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@bulan", dtp_awal.Value.Month)
                cmdx.Parameters.AddWithValue("@tahun", dtp_awal.Value.Year)
                cmdx.Parameters.AddWithValue("@client", txt_client_kontra_bon.Text)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "surat_jalan")
                        dgv_kontra_bon.DataSource = dsx.Tables("surat_jalan")
                        dgv_kontra_bon.Columns(0).HeaderText = "SURAT JALAN"
                        dgv_kontra_bon.Columns(1).HeaderText = "TOTAL"
                        dgv_kontra_bon.Columns(2).HeaderText = "PPH23"
                        dgv_kontra_bon.Columns(3).HeaderText = "TRANSFER"
                        For Each column As DataGridViewColumn In dgv_kontra_bon.Columns
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Next
                        dgv_kontra_bon.RowHeadersWidth = 60
                        dgv_kontra_bon.Columns(0).Width = 220
                        dgv_kontra_bon.Columns(1).Width = 150
                        dgv_kontra_bon.Columns(2).Width = 150
                        dgv_kontra_bon.Columns(3).Width = 150
                        dgv_kontra_bon.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kontra_bon.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kontra_bon.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kontra_bon.Columns(1).DefaultCellStyle.Format = "#,##0.00"
                        dgv_kontra_bon.Columns(2).DefaultCellStyle.Format = "#,##0.00"
                        dgv_kontra_bon.Columns(3).DefaultCellStyle.Format = "#,##0.00"
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub HitungTotalKontraBonCelup()
        Dim totalKolom2 As Decimal = 0
        Dim totalKolom3 As Decimal = 0
        Dim totalKolom4 As Decimal = 0
        For Each row As DataGridViewRow In dgv_kontra_bon.Rows
            If Not row.IsNewRow Then
                totalKolom2 += Convert.ToDecimal(If(IsDBNull(row.Cells(1).Value), 0, row.Cells(1).Value))
                totalKolom3 += Convert.ToDecimal(If(IsDBNull(row.Cells(2).Value), 0, row.Cells(2).Value))
                totalKolom4 += Convert.ToDecimal(If(IsDBNull(row.Cells(3).Value), 0, row.Cells(3).Value))
            End If
        Next
        txt_total_kontra_bon.Text = totalKolom2.ToString("#,##0")
        txt_pph23_kontra_bon.Text = totalKolom3.ToString("#,##0")
        txt_transfer_kontra_bon.Text = totalKolom4.ToString("#,##0")
    End Sub
    Private Sub carikontrabonkain()
        dgv_kontra_bon.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT surat_jalan, total FROM tbpenjualan " &
                                 "WHERE MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun AND status = 'Kain' AND supplier = @client " &
                                 "ORDER BY surat_jalan ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@bulan", dtp_awal.Value.Month)
                cmdx.Parameters.AddWithValue("@tahun", dtp_awal.Value.Year)
                cmdx.Parameters.AddWithValue("@client", txt_client_kontra_bon.Text)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "surat_jalan")
                        dgv_kontra_bon.DataSource = dsx.Tables("surat_jalan")
                        dgv_kontra_bon.Columns(0).HeaderText = "SURAT JALAN"
                        dgv_kontra_bon.Columns(1).HeaderText = "TOTAL"
                        For Each column As DataGridViewColumn In dgv_kontra_bon.Columns
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Next
                        dgv_kontra_bon.RowHeadersWidth = 60
                        dgv_kontra_bon.Columns(0).Width = 220
                        dgv_kontra_bon.Columns(1).Width = 150
                        dgv_kontra_bon.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kontra_bon.Columns(1).DefaultCellStyle.Format = "#,##0.00"
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub HitungTotalKontraBonKain()
        Dim totalKolom2 As Decimal = 0
        For Each row As DataGridViewRow In dgv_kontra_bon.Rows
            If Not row.IsNewRow Then
                totalKolom2 += Convert.ToDecimal(If(IsDBNull(row.Cells(1).Value), 0, row.Cells(1).Value))
            End If
        Next
        txt_total_kontra_bon.Text = totalKolom2.ToString("#,##0")
    End Sub
    Private Sub btn_print_kontra_bon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_kontra_bon.Click
        Dim tbkontrabon As New DataTable
        With tbkontrabon
            .Columns.Add("client")
            .Columns.Add("total")
            .Columns.Add("pph23")
            .Columns.Add("transfer")
            .Columns.Add("periode")
        End With
        tbkontrabon.Rows.Add(txt_client_kontra_bon.Text, txt_total_kontra_bon.Text, txt_pph23_kontra_bon.Text, txt_transfer_kontra_bon.Text, txt_periode_kontra_bon.Text)
        If txt_pph23_kontra_bon.Text = "" And txt_transfer_kontra_bon.Text = "" Then
            form_print_kontra_bon_kain.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbkontrabon
            form_print_kontra_bon_kain.ShowDialog()
            form_print_kontra_bon_kain.Dispose()
        Else
            form_print_kontra_bon_celup.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbkontrabon
            form_print_kontra_bon_celup.ShowDialog()
            form_print_kontra_bon_celup.Dispose()
        End If
    End Sub
    Private Sub btn_ekspor_kontra_bon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ekspor_kontra_bon.Click
        If dgv_kontra_bon.RowCount = 0 Then
            MsgBox("Tidak ada Data Penjualan tidak bisa di Ekspor")
        Else
            Dim txtdate As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            Dim namaclient As String = AmbilDuaKata(txt_client_kontra_bon)
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            EksporKontraBon(dgv_kontra_bon, "D:\Ekspor\Kontra Bon " & namaclient & " " & txt_periode_kontra_bon.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub
    Private Sub EksporKontraBon(ByVal dgv_kontra_bon As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Kontra Bon")
                With ws.Cells(2, 3)
                    .Value = "TANDA TERIMA"
                    .Style.Font.Size = 24
                End With
                ws.Cells(2, 3, 2, 8).Merge = True
                With ws.Cells(3, 3)
                    .Value = "KONTRA BON ARTHA MEKAR"
                    .Style.Font.Size = 24
                End With
                ws.Cells(3, 3, 3, 8).Merge = True
                With ws.Cells(4, 1)
                    .Value = ""
                    .Style.Font.Size = 24
                End With
                ws.Cells(5, 2).Value = "Telah Diterima dari CV. Artha Mekar Lestari"
                'ws.Cells(5, 2, 5, 7).Merge = True
                ws.Cells(6, 2).Value = "Surat Jalan, Faktur dan Faktur Pajak Untuk " & txt_client_kontra_bon.Text & " senilai ="
                'ws.Cells(6, 2, 6, 7).Merge = True
                Dim total As Decimal
                If Decimal.TryParse(txt_total_kontra_bon.Text, total) Then
                    With ws.Cells(6, 8)
                        .Value = total
                        .Style.Font.Size = 16
                        .Style.Numberformat.Format = "#,##0"
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                    End With
                End If
                ws.Column(2).Width = 10
                ws.Column(3).Width = 10
                ws.Column(4).Width = 10
                ws.Column(5).Width = 10
                ws.Column(6).Width = 10
                ws.Column(7).Width = 27
                ws.Column(8).Width = 21


                If txt_pph23_kontra_bon.Text = "" And txt_transfer_kontra_bon.Text = "" Then
                    ws.Cells(8, 2).Value = "Untuk PEMBELIAN KAIN Periode " & txt_periode_kontra_bon.Text
                    'ws.Cells(1, 1, 1, 5).Merge = True
                    ws.Cells(10, 6).Value = "Hormat Kami"
                    'ws.Cells(1, 1, 1, 5).Merge = True
                    With ws.Cells(6, 8)
                        .Style.Font.Bold = True
                    End With
                Else
                    ws.Cells(7, 2).Value = "Dipotong PPH23 sebesar ="
                    'ws.Cells(1, 1, 1, 5).Merge = True
                    ws.Cells(8, 2).Value = "TOTAL YANG DITRANSFER ="
                    'ws.Cells(1, 1, 1, 5).Merge = True
                    ws.Cells(9, 2).Value = "Untuk PROSES CELUP Periode " & txt_periode_kontra_bon.Text
                    'ws.Cells(1, 1, 1, 5).Merge = True
                    ws.Cells(11, 6).Value = "Hormat Kami"
                    'ws.Cells(1, 1, 1, 5).Merge = True

                    Dim pph23 As Decimal
                    If Decimal.TryParse(txt_pph23_kontra_bon.Text, pph23) Then
                        With ws.Cells(7, 8)
                            .Value = pph23
                            .Style.Font.Size = 16
                            .Style.Numberformat.Format = "#,##0"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    Dim transfer As Decimal
                    If Decimal.TryParse(txt_transfer_kontra_bon.Text, transfer) Then
                        With ws.Cells(8, 8)
                            .Value = transfer
                            .Style.Font.Size = 16
                            .Style.Font.Bold = True
                            .Style.Numberformat.Format = "#,##0"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                End If

                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Kontra Bon ke Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    'Kwitansi Invoice
    Private Sub ts_kwitansi_invoive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_kwitansi_invoive.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Print Kwitansi Invoice")
            Else
                txt_periode_kwitansi_invoice.Text = dtp_awal.Value.ToString("MMMM yyyy", indonesiaCulture)
                txt_client_kwitansi_invoice.Text = dgv1.CurrentRow.Cells(1).Value
                Call cariclientkwitansi()
                Call carikwitansiinvoice()
                Call HitungKwitansiInvoice()
                panelKwitansiInvoice.Visible = True
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PENJUALAN yang akan Print Kwitansi Invoice")
        End Try
    End Sub
    Private Sub cariclientkwitansi()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT alamat, kota FROM tbclient WHERE nama = @nama"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@nama", txt_client_kwitansi_invoice.Text)
                Using reader As MySqlDataReader = cmdx.ExecuteReader()
                    If reader.Read() Then
                        Dim alamat As String = reader("alamat").ToString()
                        If alamat.Length > 80 Then
                            txt_alamat_kwitansi_invoice.Text = alamat.Substring(0, 80)
                        Else
                            txt_alamat_kwitansi_invoice.Text = alamat
                        End If
                        txt_kota_kwitansi_invoice.Text = reader("kota").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub
    Private Sub carikwitansiinvoice()
        dgv_kwitansi_invoice.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT tanggal, surat_jalan, no_faktur, dpp, ppn, total FROM tbpenjualan " &
                                 "WHERE MONTH(tanggal) = @bulan AND YEAR(tanggal) = @tahun AND supplier = @client " &
                                 "ORDER BY surat_jalan ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                cmdx.Parameters.AddWithValue("@bulan", dtp_awal.Value.Month)
                cmdx.Parameters.AddWithValue("@tahun", dtp_awal.Value.Year)
                cmdx.Parameters.AddWithValue("@client", txt_client_kwitansi_invoice.Text)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "surat_jalan")
                        dgv_kwitansi_invoice.DataSource = dsx.Tables("surat_jalan")
                        dgv_kwitansi_invoice.Columns(0).HeaderText = "Tanggal"
                        dgv_kwitansi_invoice.Columns(1).HeaderText = "No. Surat Jalan"
                        dgv_kwitansi_invoice.Columns(2).HeaderText = "No. Faktur Pajak"
                        dgv_kwitansi_invoice.Columns(3).HeaderText = "Nilai DPP"
                        For Each column As DataGridViewColumn In dgv_kwitansi_invoice.Columns
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Next
                        dgv_kwitansi_invoice.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv_kwitansi_invoice.TopLeftHeaderCell.Value = "No"
                        dgv_kwitansi_invoice.RowHeadersWidth = 60
                        dgv_kwitansi_invoice.Columns(0).Width = 100
                        dgv_kwitansi_invoice.Columns(1).Width = 170
                        dgv_kwitansi_invoice.Columns(2).Width = 170
                        dgv_kwitansi_invoice.Columns(3).Width = 170
                        dgv_kwitansi_invoice.Columns(4).Visible = False
                        dgv_kwitansi_invoice.Columns(5).Visible = False
                        dgv_kwitansi_invoice.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kwitansi_invoice.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgv_kwitansi_invoice.Columns(3).DefaultCellStyle.Format = "#,##0.00"
                        dgv_kwitansi_invoice.Columns(0).DefaultCellStyle.Format = "dd/MMM/yy"
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Private Sub btn_batal_kwitansi_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_kwitansi_invoice.Click
        dgv_kwitansi_invoice.Columns.Clear()
        panelKwitansiInvoice.Visible = False
        txt_periode_kwitansi_invoice.Text = ""
        txt_client_kwitansi_invoice.Text = ""
        txt_total_kwitansi_invoice.Text = ""
        txt_dpp_kwitansi_invoice.Text = ""
        txt_ppn_kwitansi_invoice.Text = ""
        txt_alamat_kwitansi_invoice.Text = ""
        txt_kota_kwitansi_invoice.Text = ""
    End Sub
    Private Sub dgv_kwitansi_invoice_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_kwitansi_invoice.CellFormatting
        dgv_kwitansi_invoice.Rows(e.RowIndex).HeaderCell.Value = (e.RowIndex + 1).ToString()
    End Sub
    Private Sub HitungKwitansiInvoice()
        Dim totaldpp As Decimal = 0
        Dim totalppn As Decimal = 0
        Dim totalpembayaran As Decimal = 0
        For Each row As DataGridViewRow In dgv_kwitansi_invoice.Rows
            If Not row.IsNewRow Then
                totaldpp += Convert.ToDecimal(If(IsDBNull(row.Cells(3).Value), 0, row.Cells(3).Value))
                totalppn += Convert.ToDecimal(If(IsDBNull(row.Cells(4).Value), 0, row.Cells(4).Value))
                totalpembayaran += Convert.ToDecimal(If(IsDBNull(row.Cells(5).Value), 0, row.Cells(5).Value))
                totalpembayaran = Math.Floor(totalpembayaran)
            End If
        Next
        txt_dpp_kwitansi_invoice.Text = totaldpp.ToString("#,##0.00")
        txt_ppn_kwitansi_invoice.Text = totalppn.ToString("#,##0.00")
        txt_total_kwitansi_invoice.Text = totalpembayaran.ToString("#,##0.00")
    End Sub
    Private Sub btn_print_kwitansi_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_kwitansi_invoice.Click
        Dim tbkwitansiheader As New DataTable
        With tbkwitansiheader
            .Columns.Add("periode")
            .Columns.Add("client")
            .Columns.Add("alamat")
            .Columns.Add("kota")
            .Columns.Add("tanggal_ttd")
        End With
        Dim tanggalTerakhir As Date = New Date(dtp_awal.Value.Year, dtp_awal.Value.Month, Date.DaysInMonth(dtp_awal.Value.Year, dtp_awal.Value.Month))
        tbkwitansiheader.Rows.Add(txt_periode_kwitansi_invoice.Text.ToUpper(), txt_client_kwitansi_invoice.Text, AmbilDelapanKata(txt_alamat_kwitansi_invoice), _
                                  txt_kota_kwitansi_invoice.Text, tanggalTerakhir.ToString("dd MMMM yyyy", indonesiaCulture))

        Dim tbkwitansi As New DataTable
        With tbkwitansi
            .Columns.Add("no")
            .Columns.Add("tanggal")
            .Columns.Add("surat_jalan")
            .Columns.Add("faktur_pajak")
            .Columns.Add("nilai_dpp")
            .Columns.Add("jumlah")
            .Columns.Add("ppn")
            .Columns.Add("jumlah_ppn")
            .Columns.Add("total")
        End With
        Dim tbkwitansi2 As New DataTable
        With tbkwitansi2
            .Columns.Add("no")
            .Columns.Add("tanggal")
            .Columns.Add("surat_jalan")
            .Columns.Add("faktur_pajak")
            .Columns.Add("nilai_dpp")
        End With

        If dgv_kwitansi_invoice.Rows.Count > 10 Then
            For i As Integer = 0 To 9
                Dim row As DataGridViewRow = dgv_kwitansi_invoice.Rows(i)
                tbkwitansi2.Rows.Add(i + 1, Format(row.Cells(0).Value, "dd/MMM/yy"), row.Cells(1).Value, row.Cells(2).Value, _
                                    Format(row.Cells(3).Value, "#,##0.00"))
            Next
            For i As Integer = 10 To dgv_kwitansi_invoice.Rows.Count - 1
                Dim row As DataGridViewRow = dgv_kwitansi_invoice.Rows(i)
                tbkwitansi.Rows.Add(i + 1, Format(row.Cells(0).Value, "dd/MMM/yy"), row.Cells(1).Value, row.Cells(2).Value, _
                                     Format(row.Cells(3).Value, "#,##0.00"), txt_dpp_kwitansi_invoice.Text, "PPN " & ppn & " %", _
                                     txt_ppn_kwitansi_invoice.Text, txt_total_kwitansi_invoice.Text)
            Next
            form_print_kwitansi_invoice_2halaman.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbkwitansiheader
            form_print_kwitansi_invoice_2halaman.ReportViewer1.LocalReport.DataSources.Item(1).Value = tbkwitansi
            form_print_kwitansi_invoice_2halaman.ReportViewer1.LocalReport.DataSources.Item(2).Value = tbkwitansi2
            form_print_kwitansi_invoice_2halaman.ShowDialog()
            form_print_kwitansi_invoice_2halaman.Dispose()

        Else
            For Each row As DataGridViewRow In dgv_kwitansi_invoice.Rows
                If Not row.IsNewRow Then
                    tbkwitansi.Rows.Add(row.Index + 1, Format(row.Cells(0).Value, "dd/MMM/yy"), row.Cells(1).Value, row.Cells(2).Value, _
                                    Format(row.Cells(3).Value, "#,##0.00"), txt_dpp_kwitansi_invoice.Text, "PPN " & ppn & " %", _
                                    txt_ppn_kwitansi_invoice.Text, txt_total_kwitansi_invoice.Text)
                End If
            Next
            form_print_kwitansi_invoice.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbkwitansiheader
            form_print_kwitansi_invoice.ReportViewer1.LocalReport.DataSources.Item(1).Value = tbkwitansi
            form_print_kwitansi_invoice.ShowDialog()
            form_print_kwitansi_invoice.Dispose()
        End If
    End Sub
    Private Sub btn_ekspor_kwitansi_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ekspor_kwitansi_invoice.Click
        If dgv_kwitansi_invoice.RowCount = 0 Then
            MsgBox("Tidak ada Data Penjualan tidak bisa di Ekspor")
        Else
            Dim txtdate As New TextBox
            Dim dtptoday As New DateTimePicker
            dtptoday.Value = DateTime.Now
            Dim namaclient As String = AmbilDuaKata(txt_client_kwitansi_invoice)
            txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
            EksporKwitansi(dgv_kwitansi_invoice, "D:\Ekspor\Kwitansi Invoice " & namaclient & " " & txt_periode_kwitansi_invoice.Text & " " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
        End If
    End Sub
    Public Sub EksporKwitansi(ByVal dgv_kwitansi_invoice As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Kwitansi Invoice")
                ' === Set judul laporan ===
                ws.Cells(1, 1).Value = "KWITANSI INVOICE BULAN " & txt_periode_kwitansi_invoice.Text.ToUpper
                ws.Cells(1, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(1, 1, 1, 5).Merge = True
                ws.Cells(3, 2).Value = txt_client_kwitansi_invoice.Text
                ws.Cells(3, 2, 3, 5).Merge = True
                ws.Cells(4, 2).Value = AmbilDelapanKata(txt_alamat_kwitansi_invoice)
                ws.Cells(4, 2, 4, 5).Merge = True
                ws.Cells(5, 2).Value = txt_kota_kwitansi_invoice.Text
                ws.Cells(5, 2, 5, 5).Merge = True
                ws.Cells(7, 1).Value = "No."
                ws.Cells(7, 2).Value = "Tanggal"
                ws.Cells(7, 3).Value = "No. Surat Jalan"
                ws.Cells(7, 4).Value = "No. Faktur Pajak"
                ws.Cells(7, 5).Value = "Nilai DPP"
                For i As Integer = 1 To 5
                    ws.Cells(7, i).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                Next
                If dgv_kwitansi_invoice.Rows.Count > 10 Then
                    For row As Integer = 0 To 9
                        Dim cellNo = ws.Cells(row + 8, 1)
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        For col As Integer = 0 To 3
                            Dim cellValue = dgv_kwitansi_invoice.Rows(row).Cells(col).Value
                            Dim cell = ws.Cells(row + 8, col + 2)
                            If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                                If col = 0 Then
                                    Dim tanggal As Date = CDate(cellValue)
                                    cell.Value = tanggal.ToString("dd/MMM/yyyy", indonesiaCulture)
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                ElseIf col = 1 Or col = 2 Then
                                    cell.Value = cellValue.ToString().Trim()
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                                ElseIf col = 3 Then
                                    cell.Value = Convert.ToDecimal(cellValue)
                                    cell.Style.Numberformat.Format = "#,##0.00"
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                End If
                            End If
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Next
                    Next
                    ws.Cells(7, 7).Value = "No."
                    ws.Cells(7, 8).Value = "Tanggal"
                    ws.Cells(7, 9).Value = "No. Surat Jalan"
                    ws.Cells(7, 10).Value = "No. Faktur Pajak"
                    ws.Cells(7, 11).Value = "Nilai DPP"
                    For i As Integer = 7 To 11
                        ws.Cells(7, i).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    Next
                    For row As Integer = 10 To dgv_kwitansi_invoice.Rows.Count - 1
                        Dim cellNo = ws.Cells(row - 2, 7)
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        For col As Integer = 0 To 3
                            Dim cellValue = dgv_kwitansi_invoice.Rows(row).Cells(col).Value
                            Dim cell = ws.Cells(row - 2, col + 8)
                            If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                                If col = 0 Then
                                    Dim tanggal As Date = CDate(cellValue)
                                    cell.Value = tanggal.ToString("dd/MMM/yyyy", indonesiaCulture)
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                ElseIf col = 1 Or col = 2 Then
                                    cell.Value = cellValue.ToString().Trim()
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                                ElseIf col = 3 Then
                                    cell.Value = Convert.ToDecimal(cellValue)
                                    cell.Style.Numberformat.Format = "#,##0.00"
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                End If
                            End If
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Next
                    Next
                    ' Baris mulai menaruh nilai
                    Dim startRow As Integer = dgv_kwitansi_invoice.Rows.Count - 1
                    ws.Cells(startRow, 10).Value = "JUMLAH"
                    ws.Cells(startRow + 1, 10).Value = "PPN " & ppn & "%"
                    ws.Cells(startRow + 2, 10).Value = "TOTAL PEMBAYARAN"
                    ' DPP
                    Dim dpp As Decimal
                    If Decimal.TryParse(txt_dpp_kwitansi_invoice.Text, dpp) Then
                        With ws.Cells(startRow, 11)
                            .Value = dpp
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    ' PPN
                    Dim nilaippn As Decimal
                    If Decimal.TryParse(txt_ppn_kwitansi_invoice.Text, nilaippn) Then
                        With ws.Cells(startRow + 1, 11)
                            .Value = nilaippn
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    ' Total
                    Dim total As Decimal
                    If Decimal.TryParse(txt_total_kwitansi_invoice.Text, total) Then
                        With ws.Cells(startRow + 2, 11)
                            .Value = total
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.Font.Bold = True
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    Dim tanggalTerakhir As Date = New Date(dtp_awal.Value.Year, dtp_awal.Value.Month, Date.DaysInMonth(dtp_awal.Value.Year, dtp_awal.Value.Month))
                    ws.Cells(startRow + 4, 10).Value = "Bandung, " & tanggalTerakhir.ToString("dd MMMM yyyy", indonesiaCulture)
                    ws.Cells(startRow + 4, 10, startRow + 4, 11).Merge = True

                    For a As Integer = startRow - 1 To startRow + 2
                        For i As Integer = 7 To 11
                            ws.Cells(a, i).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Next
                    Next
                    ws.Cells(ws.Dimension.Address).AutoFitColumns()
                    ws.Column(1).Width = 5
                    ws.Column(6).Width = 5
                    ws.Column(7).Width = 5
                Else
                    For row As Integer = 0 To dgv_kwitansi_invoice.Rows.Count - 1
                        Dim cellNo = ws.Cells(row + 8, 1)
                        cellNo.Value = row + 1
                        cellNo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        cellNo.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        For col As Integer = 0 To 3
                            Dim cellValue = dgv_kwitansi_invoice.Rows(row).Cells(col).Value
                            Dim cell = ws.Cells(row + 8, col + 2)
                            If cellValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                                If col = 0 Then
                                    Dim tanggal As Date = CDate(cellValue)
                                    cell.Value = tanggal.ToString("dd/MMM/yyyy", indonesiaCulture)
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                ElseIf col = 1 Or col = 2 Then
                                    cell.Value = cellValue.ToString().Trim()
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                                ElseIf col = 3 Then
                                    cell.Value = Convert.ToDecimal(cellValue)
                                    cell.Style.Numberformat.Format = "#,##0.00"
                                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                                End If
                            End If
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Next
                    Next
                    For a As Integer = dgv_kwitansi_invoice.Rows.Count To dgv_kwitansi_invoice.Rows.Count + 3
                        For i As Integer = 1 To 5
                            ws.Cells(a + 8, i).Style.Border.BorderAround(ExcelBorderStyle.Thin)
                        Next
                    Next

                    ' Baris mulai menaruh nilai
                    Dim startRow As Integer = dgv_kwitansi_invoice.Rows.Count + 9
                    ws.Cells(startRow, 4).Value = "JUMLAH"
                    ws.Cells(startRow + 1, 4).Value = "PPN " & ppn & "%"
                    ws.Cells(startRow + 2, 4).Value = "TOTAL PEMBAYARAN"
                    ' DPP
                    Dim dpp As Decimal
                    If Decimal.TryParse(txt_dpp_kwitansi_invoice.Text, dpp) Then
                        With ws.Cells(startRow, 5)
                            .Value = dpp
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    ' PPN
                    Dim nilaippn As Decimal
                    If Decimal.TryParse(txt_ppn_kwitansi_invoice.Text, nilaippn) Then
                        With ws.Cells(startRow + 1, 5)
                            .Value = nilaippn
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    ' Total
                    Dim total As Decimal
                    If Decimal.TryParse(txt_total_kwitansi_invoice.Text, total) Then
                        With ws.Cells(startRow + 2, 5)
                            .Value = total
                            .Style.Numberformat.Format = "#,##0.00"
                            .Style.Font.Bold = True
                            .Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                        End With
                    End If
                    Dim tanggalTerakhir As Date = New Date(dtp_awal.Value.Year, dtp_awal.Value.Month, Date.DaysInMonth(dtp_awal.Value.Year, dtp_awal.Value.Month))
                    ws.Cells(startRow + 4, 4).Value = "Bandung, " & tanggalTerakhir.ToString("dd MMMM yyyy", indonesiaCulture)
                    ws.Cells(startRow + 4, 4, startRow + 4, 5).Merge = True
                    ws.Cells(ws.Dimension.Address).AutoFitColumns()
                    ws.Column(1).Width = 5
                End If

                Dim fi As New FileInfo(filePath)
                package.SaveAs(fi)
                MessageBox.Show("Ekspor Kwitansi ke Excel Berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class