Imports MySql.Data.MySqlClient

Module modul_koneksi_database

    Public dbServer As String
    Public dbUser As String
    Public dbPassword As String
    Public dbName As String
    Public sLocalConn As String

    Public Sub GetDatabaseSetting()
        dbServer = My.Settings.dbServer
        dbUser = My.Settings.dbUser
        dbPassword = My.Settings.dbPassword
        dbName = My.Settings.dbName
        sLocalConn = "server=" & dbServer & ";user id=" & dbUser & ";" & _
                     "password=" & dbPassword & ";database=" & dbName
    End Sub

    Public Function DatabaseConnected(Optional ByVal Server As String = "", _
            Optional ByVal User As String = "", _
            Optional ByVal Password As String = "", _
            Optional ByVal DatabaseName As String = "") As Boolean
        Dim conn As MySqlConnection
        conn = New MySqlConnection()
        If Server = "" And User = "" And Password = "" And DatabaseName = "" Then
            conn.ConnectionString = sLocalConn
        Else
            conn.ConnectionString = "server=" & Server & ";user id=" & _
                                    User & ";password=" & Password & _
                                    ";database=" & DatabaseName
        End If
        Try
            conn.Open()
            conn.Close()
            Return True
        Catch myerror As MySqlException
            Return False
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            conn.Dispose()
        End Try
        Return False
    End Function

End Module
