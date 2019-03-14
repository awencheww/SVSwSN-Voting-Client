Imports MySql.Data.MySqlClient
Module SQLConn
    Public ServerMySQL As String
    Public PortMySQL As String
    Public UserNameMySQL As String
    Public PwdMySQL As String
    Public DBNameMySQL As String
    Public query As String
    Public data As DataTable
    Public sqlds As New DataSet
    Public sqlcommand As MySqlCommand
    Public sqlreader As MySqlDataReader
    Public sqlda As MySqlDataAdapter
    Public sqlcmdbuilder As MySqlCommandBuilder

    Public conn As New MySqlConnection
    Dim AppName As String = Application.ProductName

    Sub getData()
        Try
            DBNameMySQL = GetSetting(AppName, "DBSection", "DB_Name", "temp")
            ServerMySQL = GetSetting(AppName, "DBSection", "DB_IP", "temp")
            PortMySQL = GetSetting(AppName, "DBSection", "DB_Port", "temp")
            UserNameMySQL = GetSetting(AppName, "DBSection", "DB_User", "temp")
            PwdMySQL = GetSetting(AppName, "DBSection", "DB_Password", "temp")
        Catch ex As Exception
            MsgBox("System registry was not established, you can set/save " & _
            "these settings by pressing F1", MsgBoxStyle.Information)
        End Try
    End Sub

    Sub SaveData()
        SaveSetting(AppName, "DBSection", "DB_Name", DBNameMySQL)
        SaveSetting(AppName, "DBSection", "DB_IP", ServerMySQL)
        SaveSetting(AppName, "DBSection", "DB_Port", PortMySQL)
        SaveSetting(AppName, "DBSection", "DB_User", UserNameMySQL)
        SaveSetting(AppName, "DBSection", "DB_Password", PwdMySQL)

        MsgBox("Database connection settings are saved.", MsgBoxStyle.Information)
    End Sub

    Public Sub Connection()
        conn.Close()
        Try
            conn.ConnectionString = "Server = '" & ServerMySQL & "';  " _
                                         & "Port = '" & PortMySQL & "'; " _
                                         & "Database = '" & DBNameMySQL & "'; " _
                                         & "user id = '" & UserNameMySQL & "'; " _
                                         & "password = '" & PwdMySQL & "'"
            conn.Open()
        Catch ex As Exception
            Try
                conn = New MySqlConnection("datasource = localhost; port=3306; username=root; password=root; database=thesis")
                conn.Open()
            Catch
                MsgBox("Please configure database.", MsgBoxStyle.Information, "Database")
            End Try
        End Try
    End Sub

    Public Sub DisconnMy()
        conn.Close()
        conn.Dispose()
    End Sub

End Module