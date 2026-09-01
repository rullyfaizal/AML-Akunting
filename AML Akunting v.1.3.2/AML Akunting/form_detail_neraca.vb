Imports MySql.Data.MySqlClient

Public Class form_detail_neraca

    Private Sub form_detail_neraca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_kode_neraca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kode_neraca.TextChanged
        Call isidgvindukgrey()
    End Sub
    Private Sub isidgvindukgrey()
        Try
            dgv1.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT * FROM tbhistorygrey WHERE kode_neraca='" & txt_kode_neraca.Text & "'"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbindukgrey")
                            dgv1.DataSource = dsx.Tables("tbindukgrey")
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
        dgv1.Columns(2).HeaderText = "Tanggal"
        dgv1.Columns(4).HeaderText = "Supplier"
        dgv1.Columns(5).HeaderText = "Nama Grey"
        dgv1.Columns(7).HeaderText = "Masuk (Mtr/Yard)"
        dgv1.Columns(8).HeaderText = "Keluar (Mtr/Yard)"
        dgv1.Columns(10).HeaderText = "Harga Beli DPP (Rp)"
        dgv1.Columns(11).HeaderText = "Harga Jual DPP (Rp)"
        dgv1.Columns(12).HeaderText = "Harga Jual + PPN (Rp)"
        dgv1.Columns(13).HeaderText = "DPP Jual (Rp)"
        dgv1.Columns(14).HeaderText = "Nama Jual"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.Columns(0).Visible = False
        dgv1.Columns(1).Visible = False
        dgv1.Columns(3).Visible = False
        dgv1.Columns(9).Visible = False
        dgv1.Columns(6).Visible = False
        dgv1.Columns(15).Visible = False
        dgv1.Columns(16).Visible = False
        dgv1.Columns(17).Visible = False
        dgv1.Columns(18).Visible = False
        dgv1.RowHeadersWidth = 60
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(7).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(8).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(10).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(11).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(12).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(13).DefaultCellStyle.Format = "#,##0.00"
    End Sub
    Private Sub dgv1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv1.CellFormatting
        dgv1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
End Class