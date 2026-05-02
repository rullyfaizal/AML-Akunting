Imports MySql.Data.MySqlClient

Public Class form_login

    Private Sub form_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_username.Text = ""
        txt_password.Text = ""
    End Sub
    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        form_menu_utama.Close()
    End Sub
    Private Sub txt_username_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_username.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_password.Focus()
        End If
    End Sub
    Private Sub txt_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_password.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnOk.PerformClick()
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If txt_username.Text = "" Or txt_password.Text = "" Then
                MsgBox("USERNAME Atau PASSWORD Tidak Boleh Kosong")
                If txt_username.Text = "" Then
                    txt_username.Focus()
                ElseIf txt_password.Text = "" Then
                    txt_password.Focus()
                Else
                    txt_username.Focus()
                End If
            ElseIf txt_username.Text = "1" And txt_password.Text = "1" Then
                'ElseIf txt_username.Text = "SUPERUSER" And txt_password.Text = "07041980" Then
                form_menu_utama.LOGINToolStripMenuItem.Enabled = False
                form_menu_utama.LOGOUTToolStripMenuItem.Enabled = True
                form_menu_utama.MenuStrip1.Visible = True
                form_menu_utama.Status1.Text = "SUPERUSER"
                form_menu_utama.btn_hitung_bukpot.Visible = True
                form_menu_utama.btn_hitung_bukpot.PerformClick()
                form_menu_utama.pn_laba_rugi.Visible = True
                form_menu_utama.btn_generate.PerformClick()
                form_menu_utama.pn_nilai_laba_rugi.Visible = True
                Me.Close()
            Else
                Using conx As New MySqlConnection(sLocalConn)
                    conx.Open()
                    Dim sqlx = "SELECT * FROM tbpengguna WHERE Username='" & txt_username.Text & "' AND Password='" & txt_password.Text & "'"
                    Using cmdx As New MySqlCommand(sqlx, conx)
                        Using drx As MySqlDataReader = cmdx.ExecuteReader
                            drx.Read()
                            If Not drx.HasRows Then
                                MsgBox("USERNAME Atau PASSWORD Salah")
                                txt_username.Focus()
                            Else
                                form_menu_utama.Status1.Text = drx.Item("Username")
                                form_menu_utama.Status2.Text = drx.Item("Hak_Akses")
                                If form_menu_utama.Status2.Text = "Admin" Then
                                    form_menu_utama.MenuStrip1.Visible = True
                                    'form_menu_utama.SISTEMToolStripMenuItem.Visible = True
                                    'form_menu_utama.GREYToolStripMenuItem.Visible = True
                                    'form_menu_utama.ProsesToolStripMenuItem.Visible = True
                                    'form_menu_utama.PACKINGToolStripMenuItem.Visible = True
                                    'form_menu_utama.DataToolStripMenuItem.Visible = True
                                    'form_menu_utama.ReportToolStripMenuItem.Visible = True
                                    'form_menu_utama.LainlainToolStripMenuItem.Visible = True
                                    'form_menu_utama.PenggunaToolStripMenuItem.Visible = True
                                    'form_menu_utama.StokToolStripMenuItem.Visible = True
                                    'form_menu_utama.LOGINToolStripMenuItem.Enabled = False
                                    'form_menu_utama.LOGOUTToolStripMenuItem.Enabled = True

                                    '----SEMENTARA----'
                                    
                                    '---Menu---
                                    form_menu_utama.SISTEMToolStripMenuItem.Visible = True
                                    'form_menu_utama.GREYToolStripMenuItem.Visible = True
                                    'form_menu_utama.ProsesToolStripMenuItem.Visible = True
                                    'form_menu_utama.PACKINGToolStripMenuItem.Visible = False
                                    'form_menu_utama.StokToolStripMenuItem.Visible = True
                                    'form_menu_utama.DataToolStripMenuItem.Visible = True
                                    'form_menu_utama.ReportToolStripMenuItem.Visible = False
                                    'form_menu_utama.PenjualanToolStripMenuItem1.Visible = False
                                    'form_menu_utama.LainlainToolStripMenuItem.Visible = False

                                    '---Sub Menu Sistem---
                                    form_menu_utama.LOGINToolStripMenuItem.Enabled = False
                                    form_menu_utama.LOGOUTToolStripMenuItem.Enabled = True
                                    form_menu_utama.PenggunaToolStripMenuItem.Visible = False
                                    form_menu_utama.KELUARToolStripMenuItem.Visible = True

                                    '---Sub Menu Grey--
                                    'form_menu_utama.KONTRAKToolStripMenuItem.Visible = True
                                    'form_menu_utama.PROGRESSToolStripMenuItem.Visible = True



                                    '---Sub Menu Stok---
                                    'form_menu_utama.StokProsesAdminToolStripMenuItem.Visible = False
                                    'form_menu_utama.StokWIPPackingToolStripMenuItem.Visible = False
                                    'form_menu_utama.GradeAToolStripMenuItem1.Visible = False
                                    'form_menu_utama.GradeBToolStripMenuItem1.Visible = False
                                    'form_menu_utama.ClaimCelupToolStripMenuItem1.Visible = False
                                    'form_menu_utama.ClaimJadiToolStripMenuItem1.Visible = False

                                    form_menu_utama.btn_hitung_bukpot.Visible = True
                                    form_menu_utama.btn_hitung_bukpot.PerformClick()
                                    Me.Close()
                                ElseIf form_menu_utama.Status2.Text = "User" Then
                                    form_menu_utama.MenuStrip1.Visible = True
                                    form_menu_utama.SISTEMToolStripMenuItem.Visible = True
                                    'form_menu_utama.GREYToolStripMenuItem.Visible = True
                                    'form_menu_utama.ProsesToolStripMenuItem.Visible = False
                                    'form_menu_utama.PACKINGToolStripMenuItem.Visible = False
                                    'form_menu_utama.DataToolStripMenuItem.Visible = False
                                    'form_menu_utama.ReportToolStripMenuItem.Visible = False
                                    'form_menu_utama.LainlainToolStripMenuItem.Visible = False
                                    'form_menu_utama.StokToolStripMenuItem.Visible = False
                                    form_menu_utama.PenggunaToolStripMenuItem.Visible = False
                                    form_menu_utama.LOGINToolStripMenuItem.Enabled = False
                                    form_menu_utama.LOGOUTToolStripMenuItem.Enabled = True

                                    form_menu_utama.btn_hitung_bukpot.Visible = True
                                    form_menu_utama.btn_hitung_bukpot.PerformClick()
                                    Me.Close()
                                Else
                                    MsgBox("USERNAME Belum Mempunyai HAK AKSES DATABASE")
                                    form_menu_utama.Status1.Text = ""
                                    form_menu_utama.Status2.Text = ""
                                    txt_username.Focus()
                                End If
                            End If
                        End Using
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class