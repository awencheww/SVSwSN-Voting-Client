Imports MySql.Data.MySqlClient

Public Class formDatabase
    Private TstServerMySQL As String
    Private TstPortMySQL As String
    Private TstUserNameMySQL As String
    Private TstPwdMySQL As String
    Private TstDBNameMySQL As String

    Private Sub formDatabase_load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(178, 127)
        txtServerHost.Text = ServerMySQL
        txtPort.Text = PortMySQL
        txtDatabase.Text = DBNameMySQL
        txtUserName.Text = UserNameMySQL
        txtPassword.Text = PwdMySQL
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdTest.Click
        'Test Database connection
        TstServerMySQL = txtServerHost.Text
        TstPortMySQL = txtPort.Text
        TstUserNameMySQL = txtUserName.Text
        TstPwdMySQL = txtPassword.Text
        TstDBNameMySQL = txtDatabase.Text

        Try
            conn.ConnectionString = "Server='" & TstServerMySQL & "'; Port='" & TstPortMySQL & "'; Database='" & TstDBNameMySQL & "'; User id='" & TstUserNameMySQL & "'; Password='" & TstPwdMySQL & "' "
            conn.Open()
            MsgBox("Test connection successful", MsgBoxStyle.Information, "Database Settings")
        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")
        End Try
        Call DisconnMy()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        'Save Database Connection if Test Connection success
        TstServerMySQL = txtServerHost.Text
        TstPortMySQL = txtPort.Text
        TstDBNameMySQL = txtDatabase.Text
        TstUserNameMySQL = txtUserName.Text
        TstPwdMySQL = txtPassword.Text

        Try
            conn.ConnectionString = "Server='" & TstServerMySQL & "'; " & "Port='" & TstPortMySQL & "'; " & "Database='" & TstDBNameMySQL & "'; " & "userid='" & TstUserNameMySQL & "';" & "password='" & TstPwdMySQL & "'; "
            conn.Open()

            ServerMySQL = txtServerHost.Text
            DBNameMySQL = txtDatabase.Text
            PortMySQL = txtPort.Text
            UserNameMySQL = txtUserName.Text
            PwdMySQL = txtPassword.Text

            Call SaveData()
            Me.Close()
        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Critical, "Database Settings")
        End Try
        Call DisconnMy()
    End Sub
End Class