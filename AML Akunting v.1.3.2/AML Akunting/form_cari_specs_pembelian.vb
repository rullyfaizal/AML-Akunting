Imports MySql.Data.MySqlClient

Public Class form_cari_specs_pembelian

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        If txt_specs.Text = "" Then
            MessageBox.Show("Input Nama barang / Specs terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                'dtp_awal.CustomFormat = "yyyy/MM/dd"
                'dtp_akhir.CustomFormat = "yyyy/MM/dd"
                dgv1.Columns.Clear()
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx As String = "SELECT tanggal,supplier,nama_specs,harga,kode FROM tbpembelian WHERE nama_specs like '%" & txt_specs.Text & "%' ORDER BY tanggal DESC"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using dax As New MySqlDataAdapter
                            dax.SelectCommand = cmdx
                            Using dsx As New DataSet
                                dax.Fill(dsx, "tbpembelian")
                                dgv1.DataSource = dsx.Tables("tbpembelian")
                                Call headertable()
                            End Using
                        End Using
                    End Using
                End Using
                'dtp_awal.CustomFormat = "dd/MM/yyyy"
                'dtp_akhir.CustomFormat = "dd/MM/yyyy"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        dgv1.Columns.Clear()
        txt_specs.Text = ""
    End Sub
    Private Sub headertable()
        dgv1.Columns(0).HeaderText = "TGL BELI"
        dgv1.Columns(1).HeaderText = "SUPPLIER"
        dgv1.Columns(2).HeaderText = "NAMA BARANG"
        dgv1.Columns(3).HeaderText = "HARGA (Rp)"
        For Each column As DataGridViewColumn In dgv1.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dgv1.Columns(0).Width = 100
        dgv1.Columns(1).Width = 200
        dgv1.Columns(2).Width = 220
        dgv1.Columns(3).Width = 150
        dgv1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv1.Columns(3).DefaultCellStyle.Format = "#,##0.00"
        dgv1.Columns(4).Visible = False
    End Sub

    Private Sub btn_kosong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_kosong.Click
        btn_cari.Focus()
        dgv_barang.Visible = False
        txt_specs.Text = ""
    End Sub
    Private Sub txt_specs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs.GotFocus
        If txt_specs.Text = "" Then
            Call isispecs()
        Else
            Call carispecs()
        End If
        dgv_barang.Visible = True
    End Sub
    Private Sub headertablespecs()
        dgv_barang.ColumnHeadersVisible = False
        dgv_barang.RowHeadersVisible = False
        dgv_barang.Columns(0).Width = 300
    End Sub
    Private Sub isispecs()
        Try
            dgv_barang.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT DISTINCT nama_specs From tbpembelian ORDER BY nama_specs"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbnamaspecs")
                            dgv_barang.DataSource = dsx.Tables("tbnamaspecs")
                            Call headertablespecs()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub carispecs()
        Try
            dgv_barang.Columns.Clear()
            Using conx As New MySqlConnection(sLocalConn)
                conx.Open()
                Dim sqlx As String = "SELECT DISTINCT nama_specs FROM tbpembelian WHERE nama_specs like '%" & txt_specs.Text & "%' ORDER BY nama_specs"
                Using cmdx As New MySqlCommand(sqlx, conx)
                    Using dax As New MySqlDataAdapter
                        dax.SelectCommand = cmdx
                        Using dsx As New DataSet
                            dax.Fill(dsx, "tbnamaspecs")
                            dgv_barang.DataSource = dsx.Tables("tbnamaspecs")
                            Call headertablespecs()
                        End Using
                    End Using
                End Using
            End Using
            'dgv_barang.Columns.Clear()
            'Using conx As New MySqlConnection(sLocalConn)
            '    conx.Open()
            '    Dim sqlx As String = "SELECT nama_specs FROM tbnamaspecs WHERE nama_specs like '%" & txt_specs.Text & "%' ORDER BY nama_specs"
            '    Using cmdx As New MySqlCommand(sqlx, conx)
            '        Using dax As New MySqlDataAdapter
            '            dax.SelectCommand = cmdx
            '            Using dsx As New DataSet
            '                dax.Fill(dsx, "tbnamaspecs")
            '                dgv_barang.DataSource = dsx.Tables("tbnamaspecs")
            '                Call headertablespecs()
            '            End Using
            '        End Using
            '    End Using
            'End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_specs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_specs.TextChanged
        If txt_specs.Text = "" Then
            Call isispecs()
        Else
            Call carispecs()
        End If
    End Sub
    Private Sub dgv_barang_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv_barang.CellMouseClick
        Dim i As Integer
        i = Me.dgv_barang.CurrentRow.Index
        With dgv_barang.Rows.Item(i)
            txt_specs.Text = dgv_barang.Rows(i).Cells(0).Value
        End With
        btn_cari.Focus()
        dgv_barang.Visible = False
    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If dgv_barang.Rows.Count > 0 Then
                Dim i As Integer
                i = Me.dgv1.CurrentRow.Index
                With dgv1.Rows.Item(i)
                    form_tampil_pembelian.Show()
                    form_tampil_pembelian.Focus()
                    form_tampil_pembelian.Txt_kode.Text = dgv1.Rows(i).Cells(4).Value
                End With
            End If
        End If
    End Sub
End Class