Imports MySql.Data.MySqlClient

Public Class form_tampil_isi_omset

    Private Sub isidgvpenjualan()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT id_jual,supplier,tanggal,surat_jalan,no_faktur,jenis_biaya,nama_kain,jumlah,harga," &
                    "dpp,ppn,total,pph23,transfer,total_polos,satuan,status,baris,kode FROM tbpenjualan WHERE kode_omset = '" & txt_kode_omset.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbpenjualan")
                            dgv1.DataSource = dsx.Tables("tbpenjualan")
                            Call atur_dgv_induk()
                        End Using
                    End Using
                End Using
            End Using
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
        dgv1.Columns(8).HeaderText = "HARGA SATUAN (Rp)"
        dgv1.Columns(9).HeaderText = "DPP (Rp)"
        dgv1.Columns(10).HeaderText = "PPN (Rp)"
        dgv1.Columns(11).HeaderText = "GRAND TOTAL (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(5).Visible = False
        dgv1.Columns(12).Visible = False
        dgv1.Columns(13).Visible = False
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
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub btn_isi_dgv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_isi_dgv.Click
        Call isidgvpenjualan()
    End Sub
End Class