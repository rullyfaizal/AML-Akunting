Imports MySql.Data.MySqlClient

Public Class form_koneksi_database

    Private Sub frm_koneksi_database_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDatabaseSetting()
        TxtDbServer.Text = dbServer
        TxtDbUser.Text = dbUser
        TxtDbPassword.Text = dbPassword
        TxtDbName.Text = "dbamlfix"
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        form_menu_utama.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If DatabaseConnected(TxtDbServer.Text, TxtDbUser.Text, _
                            TxtDbPassword.Text, TxtDbName.Text) = True Then
            With My.Settings
                .dbServer = TxtDbServer.Text
                .dbUser = TxtDbUser.Text
                .dbPassword = TxtDbPassword.Text
                .dbName = TxtDbName.Text
                .Save()
            End With
            GetDatabaseSetting()
            form_login.MdiParent = form_menu_utama
            form_login.Show()
            form_login.Focus()
            form_login.txt_username.Focus()
            Me.Close()
        Else
            MsgBox("GAGAL Tehubung Dengan DATABASE")
        End If
    End Sub

    Private Sub TxtDbServer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDbServer.KeyPress
        If e.KeyChar = Chr(13) Then
            BtnOk.PerformClick()
        End If
    End Sub
End Class