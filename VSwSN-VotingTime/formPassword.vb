Imports MySql.Data.MySqlClient

Public Class formPassword
    Public approveClose As Boolean

    Private Sub Validatepassword()
        Try
            query = "SELECT * FROM tblLogin WHERE password = '" & txtPassword.Text & "'"
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                If MsgBox("You are about to close this application. Click 'Yes' to proceed, Click 'No' to continue Voting System.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Authorized Confirmation") = vbYes Then
                    approveClose = True
                    Me.Close()
                Else
                    Me.Close()
                End If
            Else
                MsgBox("You are not allowed to close this application. Please contact your system Administrator.", MsgBoxStyle.Exclamation, "Unauthorized")
                txtPassword.Clear()
                approveClose = False
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkClose.LinkClicked
        approveClose = False
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Validatepassword()
        End If
    End Sub

    Private Sub formPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtPassword.Text = ""
            Me.Close()
        End If
    End Sub

    Private Sub formPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPassword.Select()
        approveClose = False
        txtPassword.Text = ""
    End Sub
End Class