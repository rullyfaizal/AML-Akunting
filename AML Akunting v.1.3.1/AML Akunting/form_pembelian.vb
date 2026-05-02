Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports OfficeOpenXml
Imports System.IO
Imports OfficeOpenXml.Style
Imports System.Text.RegularExpressions

Public Class form_pembelian
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

    Private Sub ts_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_excel.Click
        Dim txtdate As New TextBox
        Dim dtptoday As New DateTimePicker
        dtptoday.Value = DateTime.Now
        txtdate.Text = dtptoday.Value.ToString("dd-MM-yyyy HH:mm:ss")
        ExportDataGridViewToExcelEPPlus(dgv1, "D:\Ekspor\Pembelian " & txtdate.Text.Replace("-", "").Replace(":", "") & ".xlsx")
    End Sub
    Public Sub ExportDataGridViewToExcelEPPlus(ByVal dgv1 As DataGridView, ByVal filePath As String)
        Try
            Using package As New ExcelPackage()
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Pembelian")
                ' Hapus kolom pertama dari DataGridView jika ada
                If dgv1.Columns.Count > 0 Then
                    dgv1.Columns.RemoveAt(0)
                    'dgv1.Columns.RemoveAt(14)
                    'dgv1.Columns.RemoveAt(13)
                    'dgv1.Columns.RemoveAt(12)
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
                    For col As Integer = 0 To dgv1.Columns.Count - 1
                        Dim cell = ws.Cells(row + 2, col + 2)
                        cell.Value = dgv1(col, row).Value
                        If TypeOf dgv1(col, row).Value Is DateTime Then
                            cell.Style.Numberformat.Format = "dd/mm/yyyy"
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                        ElseIf IsNumeric(dgv1(col, row).Value) Then
                            cell.Style.Numberformat.Format = "#,##0.00########"
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

    Private Sub form_pembelian_grey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If form_menu_utama.Status2.Text = "User" Then
        '    ts_ubah.Visible = False
        '    ts_hapus.Visible = False
        'ElseIf form_menu_utama.Status2.Text = "Admin" Then
        '    ts_ubah.Visible = True
        '    ts_hapus.Visible = True
        'End If
        Call awal()
        Call isi_ppn()

        'Call isicbosupplier()
        'Call isicbojenisbiaya()
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
                Dim sqlx As String = "SELECT nama From tbsupplier ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv_supplier.DataSource = dsx.Tables("tbsupplier")
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
                Dim sqlx = "SELECT nama From tbsupplier WHERE nama like '%" & Cbo_Supplier.Text & "%' ORDER BY nama"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbsupplier")
                            dgv_supplier.DataSource = dsx.Tables("tbsupplier")
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
            CboJenisBiaya.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CboJenisBiaya_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboJenisBiaya.GotFocus
        If CboJenisBiaya.Text = "" Then
            Call isicbojenisbiaya()
        Else
            Call caricbojenisbiaya()
        End If
        dgv_jenis_biaya.Visible = True
    End Sub
    Private Sub btn_jenis_biaya_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jenis_biaya.Click
        btn_cari.Focus()
        dgv_jenis_biaya.Visible = False
        CboJenisBiaya.Text = ""
    End Sub
    Private Sub isicbojenisbiaya()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT jenis_biaya From tbjenisbiaya ORDER BY jenis_biaya"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbjenisbiaya")
                            dgv_jenis_biaya.DataSource = dsx.Tables("tbjenisbiaya")
                            Call headertablejenisbiaya()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub headertablejenisbiaya()
        dgv_jenis_biaya.ColumnHeadersVisible = False
        dgv_jenis_biaya.RowHeadersVisible = False
        dgv_jenis_biaya.Columns(0).Width = 300
    End Sub
    Private Sub caricbojenisbiaya()
        Try
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx = "SELECT jenis_biaya From tbjenisbiaya WHERE jenis_biaya like '%" & CboJenisBiaya.Text & "%' ORDER BY jenis_biaya"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbjenisbiaya")
                            dgv_jenis_biaya.DataSource = dsx.Tables("tbjenisbiaya")
                            Call headertablejenisbiaya()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CboJenisBiaya_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboJenisBiaya.TextChanged
        If CboJenisBiaya.Text = "" Then
            Call isicbojenisbiaya()
        Else
            Call caricbojenisbiaya()
        End If
    End Sub

    Private Sub dgv_jenis_biaya_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_jenis_biaya.CellMouseClick
        Try
            Dim i As Integer
            i = Me.dgv_jenis_biaya.CurrentRow.Index
            With dgv_jenis_biaya.Rows.Item(i)
                CboJenisBiaya.Text = dgv_jenis_biaya.Rows(i).Cells(0).Value
            End With
            btn_cari.Focus()
            dgv_jenis_biaya.Visible = False
            Cbo_Supplier.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub awal()
        dtp_hari_ini.Text = Today
        dtp_awal.Text = "01/" & DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Year.ToString()
        dtp_akhir.Text = Today
        Call isidgvindukpembelian()
    End Sub

    Private Sub isidgvindukpembelian()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
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
        dgv1.Columns(1).HeaderText = "TGL BELI"
        dgv1.Columns(2).HeaderText = "PAY"
        dgv1.Columns(3).HeaderText = "SUPPLIER"
        dgv1.Columns(4).HeaderText = "JENIS BIAYA"
        dgv1.Columns(5).HeaderText = "TOTAL POLOS (Rp)"
        dgv1.Columns(6).HeaderText = "TOTAL DPP (Rp)"
        dgv1.Columns(7).HeaderText = "TOTAL PPN (Rp)"
        dgv1.Columns(8).HeaderText = "GRAND TOTAL (Rp)"
        dgv1.Columns(9).HeaderText = "NO FAKTUR"
        dgv1.Columns(10).HeaderText = "UPLOAD"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(1).Width = 85
        dgv1.Columns(2).Width = 70
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).Width = 130
        dgv1.Columns(5).Width = 130
        dgv1.Columns(6).Width = 130
        dgv1.Columns(7).Width = 130
        dgv1.Columns(8).Width = 130
        dgv1.Columns(9).Width = 150
        dgv1.Columns(10).Width = 85
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "MMMM yyyy"
        dgv1.Columns(10).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    End Sub
    Private Sub atur_dgv_induk_ppn()
        dgv1.Columns(1).HeaderText = "TGL BELI"
        dgv1.Columns(2).HeaderText = "PAY"
        dgv1.Columns(3).HeaderText = "SUPPLIER"
        dgv1.Columns(4).HeaderText = "JENIS BIAYA"
        dgv1.Columns(5).HeaderText = "TOTAL POLOS (Rp)"
        dgv1.Columns(6).HeaderText = "TOTAL DPP (Rp)"
        dgv1.Columns(7).HeaderText = "TOTAL PPN (Rp)"
        dgv1.Columns(8).HeaderText = "GRAND TOTAL (Rp)"
        dgv1.Columns(9).HeaderText = "NO FAKTUR"
        dgv1.Columns(10).HeaderText = "UPLOAD"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(5).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(1).Width = 85
        dgv1.Columns(2).Width = 70
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).Width = 130
        dgv1.Columns(5).Width = 130
        dgv1.Columns(6).Width = 130
        dgv1.Columns(7).Width = 130
        dgv1.Columns(8).Width = 130
        dgv1.Columns(9).Width = 130
        dgv1.Columns(10).Width = 85
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "MMMM yyyy"
        dgv1.Columns(10).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    End Sub
    Private Sub atur_dgv_induk_polos()
        dgv1.Columns(1).HeaderText = "TGL BELI"
        dgv1.Columns(2).HeaderText = "PAY"
        dgv1.Columns(3).HeaderText = "SUPPLIER"
        dgv1.Columns(4).HeaderText = "JENIS BIAYA"
        dgv1.Columns(5).HeaderText = "TOTAL POLOS (Rp)"
        dgv1.Columns(6).HeaderText = "TOTAL DPP (Rp)"
        dgv1.Columns(7).HeaderText = "TOTAL PPN (Rp)"
        dgv1.Columns(8).HeaderText = "GRAND TOTAL (Rp)"
        dgv1.Columns(9).HeaderText = "NO FAKTUR"
        dgv1.Columns(10).HeaderText = "UPLOAD"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(6).Visible = False
        dgv1.Columns(7).Visible = False
        dgv1.Columns(8).Visible = False
        dgv1.Columns(9).Visible = False
        dgv1.Columns(10).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(1).Width = 85
        dgv1.Columns(2).Width = 70
        dgv1.Columns(3).Width = 130
        dgv1.Columns(4).Width = 130
        dgv1.Columns(5).Width = 130
        dgv1.Columns(6).Width = 130
        dgv1.Columns(7).Width = 130
        dgv1.Columns(8).Width = 130
        dgv1.Columns(9).Width = 130
        dgv1.Columns(10).Width = 85
        dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(5).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "MMMM yyyy"
        dgv1.Columns(10).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    End Sub

    'Private Sub isidgvpembelian()
    '    Try
    '        dtp_awal.CustomFormat = "yyyy/MM/dd"
    '        dtp_akhir.CustomFormat = "yyyy/MM/dd"
    '        dgv1.Columns.Clear()
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx As String = "SELECT * FROM tbpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using dax As New MySqlDataAdapter
    '                    dax.SelectCommand = cmdx
    '                    Using dsx As New DataSet
    '                        dax.Fill(dsx, "tbpembelian")
    '                        dgv1.DataSource = dsx.Tables("tbpembelian")
    '                        Call atur_dgv_induk()
    '                        Call hitungjumlah()
    '                    End Using
    '                End Using
    '            End Using
    '        End Using
    '        dtp_awal.CustomFormat = "dd/MM/yyyy"
    '        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub atur_dgv_induk()
    '    dgv1.Columns(1).HeaderText = "TGL BELI"
    '    dgv1.Columns(2).HeaderText = "NO FAKTUR"
    '    dgv1.Columns(3).HeaderText = "SUPPLIER"
    '    dgv1.Columns(4).HeaderText = "JENIS BIAYA"
    '    dgv1.Columns(5).HeaderText = "NAMA/SPECS"
    '    dgv1.Columns(6).HeaderText = "JUMLAH"
    '    dgv1.Columns(7).HeaderText = "HARGA/DPP (Rp)"
    '    dgv1.Columns(8).HeaderText = "TOTAL DPP (Rp)"
    '    dgv1.Columns(9).HeaderText = "PPN (Rp)"
    '    dgv1.Columns(10).HeaderText = "GRAND TOTAL (Rp)"
    '    dgv1.Columns(11).HeaderText = "PAY"
    '    dgv1.Columns(12).HeaderText = "UPLOAD"
    '    For Each column As DataGridViewColumn In dgv1.Columns
    '        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    Next
    '    dgv1.RowHeadersWidth = 60
    '    dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    '    dgv1.Columns(1).Width = 85
    '    dgv1.Columns(2).Width = 100
    '    dgv1.Columns(3).Width = 100
    '    dgv1.Columns(4).Width = 100
    '    dgv1.Columns(5).Width = 100
    '    dgv1.Columns(6).Width = 90
    '    dgv1.Columns(7).Width = 120
    '    dgv1.Columns(8).Width = 150
    '    dgv1.Columns(9).Width = 150
    '    dgv1.Columns(10).Width = 150
    '    dgv1.Columns(11).Width = 50
    '    dgv1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    'dgv1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    dgv1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    dgv1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    'dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    'dgv1.Columns(6).DefaultCellStyle.Format = "N"
    '    'dgv1.Columns(7).DefaultCellStyle.Format = "Rp #,##0.00########"
    '    'dgv1.Columns(8).DefaultCellStyle.Format = "Rp #,##0.00########"
    '    'dgv1.Columns(9).DefaultCellStyle.Format = "Rp #,##0.00########"
    '    'dgv1.Columns(10).DefaultCellStyle.Format = "Rp #,##0.00########"
    '    'dgv1.Columns(11).DefaultCellStyle.Format = "Rp #,##0.00########"
    '    dgv1.Columns(6).DefaultCellStyle.Format = "#,##0.##"
    '    dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
    '    dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
    '    dgv1.Columns(9).DefaultCellStyle.Format = "#,##0.00"
    '    dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
    '    'dgv1.Columns(11).DefaultCellStyle.Format = "Rp #,##0.00"
    '    dgv1.Columns(12).DefaultCellStyle.Format = "MMMM yyyy"
    '    dgv1.Columns(12).DefaultCellStyle.FormatProvider = New CultureInfo("id-ID")
    '    dgv1.Columns(0).Visible = False
    '    'dgv1.Columns(12).Visible = False
    '    dgv1.Columns(13).Visible = False
    '    dgv1.Columns(14).Visible = False
    '    dgv1.Columns(15).Visible = False
    'End Sub

    Private Sub ts_perbarui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_perbarui.Click
        Call awal()
        CboJenisBiaya.Text = ""
        Cbo_Supplier.Text = ""
        cb_ppn.Checked = True
        cb_polos.Checked = True
        Panel3.Enabled = True
        btn_cari.Text = "CARI"
        dgv1.Focus()
    End Sub

    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
        If e.ColumnIndex = 6 AndAlso IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)

            ' Jika nilai negatif, ubah tampilan kolom ke-3 dengan menambahkan "(RETUR)"
            If nilai < 0 Then
                Dim cellValue = dgv1.Rows(e.RowIndex).Cells(3).Value.ToString()

                ' Periksa apakah "(RETUR)" belum ada di kolom ke-3
                If Not cellValue.Contains("(RETUR)") Then
                    dgv1.Rows(e.RowIndex).Cells(3).Value = cellValue & " (RETUR)"
                End If
            End If
        End If
        ' Periksa apakah sel memiliki nilai numerik
        If IsNumeric(e.Value) Then
            Dim nilai As Decimal = Convert.ToDecimal(e.Value)

            ' Jika nilai negatif, ubah tampilannya menjadi tanda kurung
            If nilai < 0 Then
                e.Value = String.Format("({0:N2})", Math.Abs(nilai))
                e.FormattingApplied = True ' Tandai format sudah diterapkan
            End If
        End If
    End Sub

    Private Sub hitungjumlah()
        Dim totaldpp, totalppn, totalpolos, grantotal As Decimal
        totaldpp = 0
        totalppn = 0
        totalpolos = 0
        grantotal = 0
        For i As Integer = 0 To dgv1.Rows.Count - 1
            totalpolos = totalpolos + Decimal.Round((dgv1.Rows(i).Cells(5).Value), 10)
            totaldpp = totaldpp + Decimal.Round((dgv1.Rows(i).Cells(6).Value), 10)
            totalppn = totalppn + Decimal.Round((dgv1.Rows(i).Cells(7).Value), 10)
            grantotal = grantotal + Decimal.Round((dgv1.Rows(i).Cells(8).Value), 10)
        Next
        txt_total_dpp.Text = totaldpp.ToString("#,##0.00########")
        txt_total_ppn.Text = totalppn.ToString("#,##0.00########")
        txt_total_polos.Text = totalpolos.ToString("#,##0.00########")
        txt_gran_total.Text = grantotal.ToString("#,##0.00########")
    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        ts_perbarui.PerformClick()
    End Sub
    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        If cb_ppn.Checked = False And cb_polos.Checked = False Then
            MsgBox("Pilihan PPN dan POLOS Tidak Boleh Kosong Keduanya", MsgBoxStyle.Exclamation)
            cb_ppn.Focus()
        Else
            If Cbo_Supplier.Text = "" And CboJenisBiaya.Text = "" Then
                If cb_ppn.Checked = True And cb_polos.Checked = True Then
                    Call cari_polos_ppn()
                ElseIf cb_ppn.Checked = True And cb_polos.Checked = False Then
                    Call cari_ppn()
                ElseIf cb_ppn.Checked = False And cb_polos.Checked = True Then
                    Call cari_polos()
                End If
            ElseIf Not Cbo_Supplier.Text = "" And CboJenisBiaya.Text = "" Then
                If cb_ppn.Checked = True And cb_polos.Checked = True Then
                    Call cari_polos_ppn_supplier()
                ElseIf cb_ppn.Checked = True And cb_polos.Checked = False Then
                    Call cari_ppn_supplier()
                ElseIf cb_ppn.Checked = False And cb_polos.Checked = True Then
                    Call cari_polos_supplier()
                End If
            ElseIf Cbo_Supplier.Text = "" And Not CboJenisBiaya.Text = "" Then
                If cb_ppn.Checked = True And cb_polos.Checked = True Then
                    Call cari_polos_ppn_jenisbiaya()
                ElseIf cb_ppn.Checked = True And cb_polos.Checked = False Then
                    Call cari_ppn_jenisbiaya()
                ElseIf cb_ppn.Checked = False And cb_polos.Checked = True Then
                    Call cari_polos_jenisbiaya()
                End If
            End If
        End If
    End Sub
    Private Sub cari_ppn()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE NOT no_faktur = '' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpembelian")
                            dgv1.DataSource = dsx.Tables("tbpembelian")
                            Call atur_dgv_induk_ppn()
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
    Private Sub cari_polos()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE no_faktur = '' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
                            Call atur_dgv_induk_polos()
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
    Private Sub cari_polos_ppn()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
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

    Private Sub cari_ppn_supplier()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE NOT no_faktur = '' AND supplier = '" & Cbo_Supplier.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
                            Call atur_dgv_induk_ppn()
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
    Private Sub cari_polos_supplier()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE no_faktur = '' AND supplier = '" & Cbo_Supplier.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
                            Call atur_dgv_induk_polos()
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
    Private Sub cari_polos_ppn_supplier()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE supplier = '" & Cbo_Supplier.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
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

    Private Sub cari_ppn_jenisbiaya()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE NOT no_faktur = '' AND jenis_biaya = '" & CboJenisBiaya.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
                            Call atur_dgv_induk_ppn()
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
    Private Sub cari_polos_jenisbiaya()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE no_faktur = '' AND jenis_biaya = '" & CboJenisBiaya.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
                            Call atur_dgv_induk_polos()
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
    Private Sub cari_polos_ppn_jenisbiaya()
        Try
            dtp_awal.CustomFormat = "yyyy/MM/dd"
            dtp_akhir.CustomFormat = "yyyy/MM/dd"
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE jenis_biaya = '" & CboJenisBiaya.Text & "' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukpembelian")
                            dgv1.DataSource = dsx.Tables("tbindukpembelian")
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

    'Private Sub cari_ppn_namaspecs()
    '    Try
    '        dtp_awal.CustomFormat = "yyyy/MM/dd"
    '        dtp_akhir.CustomFormat = "yyyy/MM/dd"
    '        dgv1.Columns.Clear()
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE nama_specs LIKE '%" & txt_specs.Text & "%' AND NOT no_faktur = '' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using dax As New MySqlDataAdapter
    '                    dax.SelectCommand = cmdx
    '                    Using dsx As New DataSet
    '                        dax.Fill(dsx, "tbindukpembelian")
    '                        dgv1.DataSource = dsx.Tables("tbindukpembelian")
    '                        Call atur_dgv_induk()
    '                        Call hitungjumlah()
    '                    End Using
    '                End Using
    '            End Using
    '        End Using
    '        dtp_awal.CustomFormat = "dd/MM/yyyy"
    '        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub cari_polos_namaspecs()
    '    Try
    '        dtp_awal.CustomFormat = "yyyy/MM/dd"
    '        dtp_akhir.CustomFormat = "yyyy/MM/dd"
    '        dgv1.Columns.Clear()
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE nama_specs LIKE '%" & txt_specs.Text & "%' AND no_faktur = '' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using dax As New MySqlDataAdapter
    '                    dax.SelectCommand = cmdx
    '                    Using dsx As New DataSet
    '                        dax.Fill(dsx, "tbindukpembelian")
    '                        dgv1.DataSource = dsx.Tables("tbindukpembelian")
    '                        Call atur_dgv_induk()
    '                        Call hitungjumlah()
    '                    End Using
    '                End Using
    '            End Using
    '        End Using
    '        dtp_awal.CustomFormat = "dd/MM/yyyy"
    '        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub cari_polos_ppn_namaspecs()
    '    Try
    '        dtp_awal.CustomFormat = "yyyy/MM/dd"
    '        dtp_akhir.CustomFormat = "yyyy/MM/dd"
    '        dgv1.Columns.Clear()
    '        Using conx As New MySqlConnection(sLocalConn)
    '            conx.Open()
    '            Dim sqlx As String = "SELECT * FROM tbindukpembelian WHERE nama_specs LIKE '%" & txt_specs.Text & "%' AND tanggal BETWEEN '" & dtp_awal.Text & "' AND '" & dtp_akhir.Text & "' ORDER BY Tanggal ASC"
    '            Using cmdx As New MySqlCommand(sqlx, conx)
    '                Using dax As New MySqlDataAdapter
    '                    dax.SelectCommand = cmdx
    '                    Using dsx As New DataSet
    '                        dax.Fill(dsx, "tbindukpembelian")
    '                        dgv1.DataSource = dsx.Tables("tbindukpembelian")
    '                        Call atur_dgv_induk()
    '                        Call hitungjumlah()
    '                    End Using
    '                End Using
    '            End Using
    '        End Using
    '        dtp_awal.CustomFormat = "dd/MM/yyyy"
    '        dtp_akhir.CustomFormat = "dd/MM/yyyy"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub dtp_akhir_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_akhir.TextChanged, dtp_awal.TextChanged
        If dtp_awal.Value > dtp_akhir.Value Then
            dtp_akhir.Text = dtp_awal.Text
        End If
    End Sub

    Private Sub ts_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_hapus.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di Hapus")
            Else
                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                form_hapus_pembelian.Show()
                form_hapus_pembelian.Focus()
                form_hapus_pembelian.Txt_kode.Text = cellValue
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PEMBELIAN yang akan di HAPUS")
        End Try
    End Sub
    Private Sub ts_ubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_ubah.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di Ubah")
            ElseIf dgv1.CurrentRow.Cells(4).Value = "RETUR" Then
                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                form_edit_pembelian.Show()
                form_edit_pembelian.Focus()
                form_edit_pembelian.Txt_kode.Text = cellValue
                form_edit_pembelian.Panel2.Enabled = False
                form_edit_pembelian.Cbo_Supplier.ReadOnly = True
                form_edit_pembelian.btn_supplier.Enabled = False
                form_edit_pembelian.CboJenisBiaya.Enabled = False
            ElseIf dgv1.CurrentRow.Cells(4).Value = "GREY" Then
                Using cona As New MySqlConnection(sLocalConn)
                    cona.Open()
                    Dim sqla = "SELECT kode FROM tbgrey WHERE kode='" & dgv1.CurrentRow.Cells(0).Value & "'"
                    Using cmda As New MySqlCommand(sqla, cona)
                        Using dra As MySqlDataReader = cmda.ExecuteReader
                            dra.Read()
                            If dra.HasRows Then
                                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                                form_edit_pembelian.Show()
                                form_edit_pembelian.Focus()
                                form_edit_pembelian.Txt_kode.Text = cellValue
                                form_edit_pembelian.Panel2.Enabled = False
                                form_edit_pembelian.Cbo_Supplier.ReadOnly = True
                                form_edit_pembelian.btn_supplier.Enabled = False
                                form_edit_pembelian.CboJenisBiaya.Enabled = False



                            Else
                                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                                form_edit_pembelian.Show()
                                form_edit_pembelian.Focus()
                                form_edit_pembelian.Txt_kode.Text = cellValue
                            End If
                        End Using
                    End Using
                End Using
            Else
                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                form_edit_pembelian.Show()
                form_edit_pembelian.Focus()
                form_edit_pembelian.Txt_kode.Text = cellValue
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PEMBELIAN yang akan di UBAH")
        End Try
    End Sub
    Private Sub ts_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_baru.Click
        form_input_pembelian_baru.Show()
        form_input_pembelian_baru.Focus()
    End Sub
    Private Sub ts_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_upload.Click
        form_upload_pembelian.Show()
        form_upload_pembelian.Focus()
    End Sub

    Private Sub dgv1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseDoubleClick
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk Di tampilkan")
            Else
                form_tampil_pembelian.Show()
                form_tampil_pembelian.Focus()
                Dim cellValue As String = dgv1.CurrentRow.Cells(0).Value.ToString()
                form_tampil_pembelian.Txt_kode.Text = cellValue
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub akhir()

    End Sub


    '---Akhir

    'Private Sub reportbeligrey()
    '    Dim tbheaderfooter As New DataTable
    '    With tbheaderfooter
    '        .Columns.Add("DataColumn1")
    '        .Columns.Add("DataColumn2")
    '        .Columns.Add("DataColumn3")
    '        .Columns.Add("DataColumn4")
    '        .Columns.Add("DataColumn5")
    '        .Columns.Add("DataColumn6")
    '        .Columns.Add("DataColumn7")
    '        .Columns.Add("DataColumn8")
    '    End With
    '    tbheaderfooter.Rows.Add(dtp_awal.Text, dtp_akhir.Text, dtp_hari_ini.Text, _
    '                            txt_jumlah_qty.Text, txt_total_polos.Text, _
    '                            txt_qty_yard.Text, txt_total_ppn.Text, txt_total_pembelian.Text)
    '    Dim dtreportkontrakgrey As New DataTable
    '    With dtreportkontrakgrey
    '        .Columns.Add("DataColumn1")
    '        .Columns.Add("DataColumn2")
    '        .Columns.Add("DataColumn3")
    '        .Columns.Add("DataColumn4")
    '        .Columns.Add("DataColumn5")
    '        .Columns.Add("DataColumn6")
    '        .Columns.Add("DataColumn7")
    '        .Columns.Add("DataColumn8")
    '        .Columns.Add("DataColumn9")
    '        .Columns.Add("DataColumn10")
    '        .Columns.Add("DataColumn11")
    '    End With
    '    For Each row As DataGridViewRow In dgv1.Rows
    '        If Not row.Cells(8).Value = 0 Then
    '            dtreportkontrakgrey.Rows.Add(row.Cells(0).FormattedValue, row.Cells(1).Value, row.Cells(2).Value, _
    '                                     row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).FormattedValue, _
    '                                     row.Cells(6).Value, row.Cells(7).FormattedValue, row.Cells(8).FormattedValue, _
    '                                     row.Cells(9).Value, row.Cells(10).Value)
    '        End If
    '    Next
    '    form_report_pembelian_grey.ReportViewer1.LocalReport.DataSources.Item(0).Value = tbheaderfooter
    '    form_report_pembelian_grey.ReportViewer1.LocalReport.DataSources.Item(1).Value = dtreportkontrakgrey
    '    form_report_pembelian_grey.ShowDialog()
    '    form_report_pembelian_grey.Dispose()
    'End Sub
    'Private Sub ts_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print.Click
    '    If dgv1.RowCount = 0 Then
    '        MsgBox("Tidak Terdapat Data Untuk Dicetak")
    '    Else
    '        Call reportbeligrey()
    '    End If
    'End Sub

    'Private Sub txt_qty_yard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If txt_qty_yard.Text <> String.Empty Then
    '        Dim temp As String = txt_qty_yard.Text.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator, String.Empty)
    '        If temp.Contains(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) = True Then
    '            Dim xxx() As String = temp.Split(CChar(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
    '            txt_qty_yard.Text = CDec(xxx(0)).ToString("N0") & System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator & xxx(1)
    '            txt_qty_yard.Select(txt_qty_yard.Text.Length, 0)
    '        ElseIf txt_qty_yard.Text = "-"c Then

    '        Else
    '            txt_qty_yard.Text = CDec(temp).ToString("N0")
    '            txt_qty_yard.Select(txt_qty_yard.Text.Length, 0)
    '        End If
    '    End If
    'End Sub    

    Private Sub ts_cari_barang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cari_barang.Click
        form_cari_specs_pembelian.Show()
        form_cari_specs_pembelian.Focus()
    End Sub

    '------ FITUR  RETUR
    Private Sub ts_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_retur.Click
        Try
            If dgv1.RowCount = 0 Then
                MsgBox("Tidak Terdapat data untuk RETUR Pembelian")
            Else
                If dgv1.CurrentRow.Cells(4).Value <> "GREY" Then
                    MsgBox("Fitur untuk RETUR sementara hanya untuk Pembelian GREY")
                    'dgv1.Enabled = False
                    'Panel1.Enabled = False
                    'dtp_tanggal_retur.Value = dgv1.CurrentRow.Cells(1).Value
                    'txt_supplier_retur.Text = dgv1.CurrentRow.Cells(3).Value
                    'panelRetur.Visible = True
                    'txt_dpp_retur.Focus()
                Else
                    form_retur.Visible = True
                    form_retur.Focus()
                    form_retur.txt_no_faktur_retur.Text = dgv1.CurrentRow.Cells(2).Value
                    form_retur.txt_supplier_retur.Text = dgv1.CurrentRow.Cells(3).Value
                    form_retur.txt_kode_induk.Text = dgv1.CurrentRow.Cells(0).Value
                    form_retur.txt_no_faktur_retur.Text = dgv1.CurrentRow.Cells(9).Value
                End If
            End If
        Catch ex As Exception
            MsgBox("Silahkan Pilih Terlebih dahulu Data PEMBELIAN yang akan di RETUR")
        End Try
    End Sub
    Private Sub btn_batal_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal_retur.Click
        panelRetur.Visible = False
        dtp_tanggal_retur.Value = Today
        txt_supplier_retur.Text = ""
        txt_dpp_retur.Text = ""
        txt_ppn_retur.Text = ""
        txt_total_retur.Text = ""
        btn_simpan_retur.Enabled = False
        dgv1.Enabled = True
        Panel1.Enabled = True
    End Sub
    Private Sub btn_hitung_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hitung_retur.Click
        If txt_dpp_retur.Text = "" Then
            MsgBox("Silahkan isi nilai DPP Retur")
        Else
            Dim dpp As String = txt_dpp_retur.Text
            Dim dpp_d, ppn_retur_d, total_d As Decimal
            Decimal.TryParse(dpp, dpp_d)
            ppn_retur_d = dpp_d * (ppn / 100)
            total_d = dpp_d + ppn_retur_d
            txt_dpp_retur.Text = dpp_d.ToString("#,##0.00########")
            txt_ppn_retur.Text = ppn_retur_d.ToString("#,##0.00########")
            txt_total_retur.Text = total_d.ToString("#,##0.00########")
            btn_simpan_retur.Enabled = True
        End If
    End Sub
    Private Sub txt_dpp_retur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_dpp_retur.KeyPress
        ' Cek apakah input adalah angka (0-9), koma, atau backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            ' Jika bukan, batalkan input
            e.Handled = True
        End If
        If e.KeyChar = ","c Then
            ' Jika koma sudah ada atau TextBox kosong, batalkan input
            If txt_dpp_retur.Text.Contains(",") OrElse txt_dpp_retur.Text.Length = 0 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub btn_simpan_retur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan_retur.Click
        Call simpan_retur_pembelian()
        MsgBox("RETUR Pembelian Berhasil Disimpan")
        btn_batal_retur.PerformClick()
        btn_cari.PerformClick()
    End Sub
    Private Sub simpan_retur_pembelian()
        Dim dpp As String = txt_dpp_retur.Text
        Dim ppn_retur As String = txt_ppn_retur.Text
        Dim total As String = txt_total_retur.Text
        Dim dpp_d, ppn_retur_d, total_d As Decimal
        Decimal.TryParse(dpp, dpp_d)
        Decimal.TryParse(ppn_retur, ppn_retur_d)
        Decimal.TryParse(total, total_d)
        dpp_d = dpp_d * -1
        ppn_retur_d = ppn_retur_d * -1
        total_d = total_d * -1
        dtp_tanggal_retur.CustomFormat = "yyyy/MM/dd"

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbpembelian (tanggal,no_faktur,supplier,jenis_biaya,nama_specs,jumlah,harga,dpp,ppn,total,pembayaran,tanggal_upload,status,baris,kode) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", dtp_tanggal_retur.Text)
                    .Parameters.AddWithValue("@2", dgv1.CurrentRow.Cells(9).Value & "R")
                    .Parameters.AddWithValue("@3", txt_supplier_retur.Text)
                    .Parameters.AddWithValue("@4", "RETUR")
                    .Parameters.AddWithValue("@5", "RETUR")
                    .Parameters.AddWithValue("@6", 1)
                    .Parameters.AddWithValue("@7", dpp_d)
                    .Parameters.AddWithValue("@8", dpp_d)
                    .Parameters.AddWithValue("@9", ppn_retur_d)
                    .Parameters.AddWithValue("@10", total_d)
                    .Parameters.AddWithValue("@11", "")
                    If dtp_tanggal_retur.Text = "" Then
                        .Parameters.AddWithValue("@12", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@12", dtp_tanggal_retur.Text)
                    End If
                    .Parameters.AddWithValue("@13", "ppn")
                    .Parameters.AddWithValue("@14", 1)
                    .Parameters.AddWithValue("@15", dgv1.CurrentRow.Cells(0).Value & "R")
                    .ExecuteNonQuery()
                End With
            End Using
        End Using

        Using cony As New MySqlConnection(sLocalConn)
            cony.Open()
            Dim sqly = "INSERT INTO tbindukpembelian (kode,tanggal,no_faktur,supplier,jenis_biaya,total_dpp,total_ppn,total_pembelian,pembayaran,tanggal_upload,total_polos) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
            Using cmdy As New MySqlCommand(sqly, cony)
                With cmdy
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@0", dgv1.CurrentRow.Cells(0).Value & "R")
                    .Parameters.AddWithValue("@1", dtp_tanggal_retur.Text)
                    .Parameters.AddWithValue("@2", dgv1.CurrentRow.Cells(9).Value & "R")
                    .Parameters.AddWithValue("@3", txt_supplier_retur.Text)
                    .Parameters.AddWithValue("@4", "RETUR")
                    .Parameters.AddWithValue("@5", dpp_d)
                    .Parameters.AddWithValue("@6", ppn_retur_d)
                    .Parameters.AddWithValue("@7", total_d)
                    .Parameters.AddWithValue("@8", "")
                    If dtp_tanggal_retur.Text = "" Then
                        .Parameters.AddWithValue("@9", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@9", dtp_tanggal_retur.Text)
                    End If
                    .Parameters.AddWithValue("@10", "")
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
        dtp_tanggal_retur.CustomFormat = "dd/MM/yyyy"
    End Sub



End Class