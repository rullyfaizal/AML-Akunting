Imports MySql.Data.MySqlClient

Public Class form_biaya_penyusutan

    Private Sub form_biaya_penyusutan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil_induk_penyusutan()
    End Sub

    Private Sub ts_input_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_input.Click
        form_input_biaya_penyusutan.Show()
        form_input_biaya_penyusutan.Focus()
    End Sub
    Private Sub tampil_induk_penyusutan()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT kode, kategori_aset, nama_aset, tahun, nilai_buku " &
                                    "FROM tbindukpenyusutan " &
                                    "ORDER BY kategori_aset ASC"
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
            dgv1.Columns(1).HeaderText = "KATEGORI"
            dgv1.Columns(2).HeaderText = "NAMA"
            dgv1.Columns(3).HeaderText = "TAHUN"
            dgv1.Columns(4).HeaderText = "NILAI BUKU"
            For Each column As DataGridViewColumn In dgv1.Columns
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgv1.Columns(0).Visible = False
            dgv1.Columns(1).Width = 140
            dgv1.Columns(2).Width = 130
            dgv1.Columns(3).Width = 70
            dgv1.Columns(4).Width = 120
            dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv1.Columns(4).DefaultCellStyle.Format = "#,##0"
            For Each col As DataGridViewColumn In dgv1.Columns
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next
            dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tampil_detail_penyusutan()
        dgv2.Columns.Clear()
        Using conx As New MySqlConnection(sLocalConn)
            conx.Open()
            Dim sqlx As String = "SELECT tahun, persentase, nilai_penyusutan, nilai_buku, kode " &
                                "FROM tbdatapenyusutan " &
                                "WHERE kode = '" & dgv1.Rows(0).Cells(0).Value & "' " &
                                "ORDER BY tahun ASC"
            Using cmdx As New MySqlCommand(sqlx, conx)
                Using dax As New MySqlDataAdapter
                    dax.SelectCommand = cmdx
                    Using dsx As New DataSet
                        dax.Fill(dsx, "tbpenjualan")
                        dgv2.DataSource = dsx.Tables("tbpenjualan")
                    End Using
                End Using
            End Using
        End Using
        dgv2.Columns(0).HeaderText = "TAHUN"
        dgv2.Columns(1).HeaderText = "%"
        dgv2.Columns(2).HeaderText = "PENYUSUTAN"
        dgv2.Columns(3).HeaderText = "NILAI BUKU"
        For Each column As DataGridViewColumn In dgv2.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv2.Columns(4).Visible = False
        dgv2.Columns(0).Width = 70
        dgv2.Columns(1).Width = 70
        dgv2.Columns(2).Width = 120
        dgv2.Columns(3).Width = 120
        dgv2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv2.Columns(2).DefaultCellStyle.Format = "#,##0"
        dgv2.Columns(3).DefaultCellStyle.Format = "#,##0"
    End Sub
   
    Private Sub dgv1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
         If e.RowIndex >= 0 Then
            ' Ambil DataTable dari DataSource
            Dim dt As DataTable = CType(dgv1.DataSource, DataTable)
            ' Simpan baris yang diklik
            Dim selectedRow As DataRow = dt.Rows(e.RowIndex)
            Dim newDt As DataTable = dt.Clone() ' Buat DataTable kosong dengan struktur sama
            newDt.ImportRow(selectedRow) ' Masukkan kembali baris yang dipilih
            ' Bind DataTable baru ke DataGridView
            dgv1.DataSource = newDt
        End If
        Call tampil_detail_penyusutan()
    End Sub

    Private Sub REFRESHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_refresh.Click
        Call tampil_induk_penyusutan()
        dgv2.Columns.Clear()
    End Sub

    Private Sub ts_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_hapus.Click
        Try
            If dgv1.RowCount = 1 Then
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT kode FROM tbindukpenyusutan WHERE kode='" & dgv1.Rows(0).Cells(0).Value & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If drx.HasRows Then
                                If MsgBox("Yakin Aset yang dipilih akan Dihapus ?", vbYesNo + vbQuestion, "Hapus Data") = vbYes Then
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbindukpenyusutan WHERE kode='" & dgv1.Rows(0).Cells(0).Value & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                    End Using
                                    Using cony As New MySqlConnection(sLocalConn)
                                        cony.Open()
                                        Dim sqly = "DELETE FROM tbdatapenyusutan WHERE kode='" & dgv1.Rows(0).Cells(0).Value & "'"
                                        Using cmdy As New MySqlCommand(sqly, cony)
                                            cmdy.ExecuteNonQuery()
                                        End Using
                                    End Using
                                    MsgBox("Aset yang dipilih berhasil di Hapus")
                                    ts_refresh.PerformClick()
                                End If
                            Else
                                MsgBox("Aset belum terdapat di Database")
                            End If
                        End Using
                    End Using
                End Using
            Else
                MsgBox("Pilih terlebih dahulu Aset yang akan dihapus")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        If dgv1.RowCount = 1 Then
            form_input_biaya_penyusutan.Show()
            form_input_biaya_penyusutan.Focus()
            form_input_biaya_penyusutan.txt_id.Text = dgv1.Rows(0).Cells(0).Value
            form_input_biaya_penyusutan.cbo_aset.Text = dgv1.Rows(0).Cells(1).Value
            form_input_biaya_penyusutan.txt_nama_aset.Text = dgv1.Rows(0).Cells(2).Value
            form_input_biaya_penyusutan.Label7.Text = "EDIT PENYUSUTAN"

            ' Ambil nilai tahun dari DataGridView dan konversi ke Integer
            Dim tahun As Integer = CInt(dgv1.Rows(0).Cells(3).Value)
            ' Masukkan ke DateTimePicker dengan format 1 Januari tahun tersebut
            form_input_biaya_penyusutan.dtp_tahun.Value = New DateTime(tahun, 1, 1)

            Dim nilai As Decimal = Convert.ToDecimal(dgv1.Rows(0).Cells(4).Value)
            form_input_biaya_penyusutan.txt_nilai_buku.Text = nilai.ToString("#,##0")


        Else
            MsgBox("Pilih terlebih dahulu Aset yang akan diedit")
        End If
    End Sub
End Class