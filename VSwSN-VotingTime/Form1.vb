Imports MySql.Data.MySqlClient

Public Class formVotingLogin

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        formPassword.ShowDialog()
        If formPassword.approveClose = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Format(Date.Now, ("Long Time"))
    End Sub

    Private Sub formVotingLogin_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 And e.Modifiers = Keys.Alt Then
            e.Handled = True
        End If

        If e.KeyCode = Keys.F1 And e.Modifiers = Keys.Alt Then
            Application.Exit()
        End If

        If e.KeyCode = Keys.F1 Then
            formDatabase.ShowDialog()
        End If
    End Sub

    Private Sub formVotingLogin_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        getData()
        lblDate.Text = Format(Date.Now, ("MMMM dd, yyyy"))
        txtIDnumber.Text = ""
        txtIDnumber.Focus()
    End Sub

    Private Function ValidateVoter() As Boolean
        Try
            query = "SELECT * FROM Student WHERE StudentID = '" & txtIDnumber.Text & "' AND isVoted = 'YES' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader

            If sqlreader.Read = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Function

    Private Function ValidateIsUserLogin() As Boolean
        Try
            query = "SELECT * FROM Student WHERE StudentID='" & txtIDnumber.Text & "' AND isLogin=1 "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader

            If sqlreader.Read = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Function

    Private Sub UpdateUserToActiveLogin()
        Try
            query = "UPDATE Student SET isLogin=1 WHERE StudentID='" & txtIDnumber.Text & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub LoginToVote()
        If ValidateVoter() = True Then
            MsgBox("YOU WERE ALREADY VOTED", MsgBoxStyle.Exclamation, "Validate Voter")
            txtIDnumber.Text = ""
            txtIDnumber.Focus()
            Exit Sub
        End If

        If ValidateIsUserLogin() = True Then
            MsgBox("Voter Already Login", MsgBoxStyle.Exclamation, "Validate Voter Login")
            txtIDnumber.Text = ""
            txtIDnumber.Focus()
            Exit Sub
        End If

        Try
            query = "SELECT * FROM Student WHERE StudentID='" & txtIDnumber.Text & "' AND StudentID<>'' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader

            If sqlreader.Read = True Then
                UpdateUserToActiveLogin()
                formVotingMain.GetStudentNo()
                formVotingMain.Show()
                Me.Hide()
            ElseIf txtIDnumber.Text = "" Then
                MsgBox("Please enter your Voters ID", MsgBoxStyle.Information, "Logint Voters")
                txtIDnumber.Focus()
            ElseIf sqlreader.Read = False Then
                MsgBox("Invalid Voters ID", MsgBoxStyle.Exclamation, "Login Voters ID")
                txtIDnumber.Text = ""
                txtIDnumber.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        LoginToVote()
    End Sub

    Private Sub txtIDnumber_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIDnumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginToVote()
        End If
    End Sub

End Class
