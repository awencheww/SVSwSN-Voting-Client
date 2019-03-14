Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class formVotingMain

    Private Sub formVotingMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblDate.Text = Format(Date.Now, ("MMMM dd, yyyy"))
        GetStudentNo()
        formSSGVoting.MdiParent = Me
        formSSGVoting.Show()
        formSSGVoting.WindowState = FormWindowState.Maximized
    End Sub


    Public Sub GetStudentNo()
        Try
            query = "SELECT StudentID,DepartmentID, Concat(Firstname,' ', Middlename,' ', Lastname) as StudName FROM Student WHERE StudentID = '" & formVotingLogin.txtIDnumber.Text & "'"
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader

            If sqlreader.Read = True Then
                lblStudentName.Text = sqlreader("StudName")
                lblStudentName.Tag = sqlreader("StudentID")
                lblDepartment.Tag = sqlreader("DepartmentID")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        formSSGVoting.MdiParent = Me
        formSSGVoting.Show()
        formSSGVoting.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        formDepartmentVoting.MdiParent = Me
        formDepartmentVoting.Show()
        formDepartmentVoting.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        formSSGLVoting.MdiParent = Me
        formSSGLVoting.Show()
        formSSGLVoting.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Format(Date.Now, ("Long Time"))
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        UpdateVoterToLogout()
        formSSGVoting.ClearAllFields()
        Me.Close()
        formVotingLogin.Show()
    End Sub


    Private Sub CastSSGVotes()
        'SSG Voting
        If formSSGVoting.cmbGov.Text <> "" Then
            UpdateSSGE_GovVotes()
        End If
        If formSSGVoting.cmbViceGov.Text <> "" Then
            UpdateSSGE_ViceGovVotes()
        End If
        If formSSGVoting.cmbSecretary.Text <> "" Then
            UpdateSSGE_SecretaryVotes()
        End If
        If formSSGVoting.cmbTreasurer.Text <> "" Then
            UpdateSSGE_TreasurerVotes()
        End If
        If formSSGVoting.cmbBMan.Text <> "" Then
            UpdateSSGE_BmanVotes()
        End If
        If formSSGVoting.cmbAuditor.Text <> "" Then
            UpdateSSGE_AuditorVotes()
        End If
        If formSSGVoting.cmbPIO.Text <> "" Then
            UpdateSSGE_PIOVotes()
        End If
        'END OF SSG VOTING EXECUTIVE BRANCH

        If formSSGLVoting.cmbGov.Text <> "" Then
            UpdateSSGL_GovVotes()
        End If
        If formSSGLVoting.cmbViceGov.Text <> "" Then
            UpdateSSGL_ViceGovVotes()
        End If
        If formSSGLVoting.cmbSecretary.Text <> "" Then
            UpdateSSGL_SecretaryVotes()
        End If
        If formSSGLVoting.cmbTreasurer.Text <> "" Then
            UpdateSSGL_TreasurerVotes()
        End If
        If formSSGLVoting.cmbBMan.Text <> "" Then
            UpdateSSGL_BmanVotes()
        End If
        If formSSGLVoting.cmbAuditor.Text <> "" Then
            UpdateSSGL_AuditorVotes()
        End If
        If formSSGLVoting.cmbPIO.Text <> "" Then
            UpdateSSGL_PIOVotes()
        End If
        'END OF SSG VOTING LEGISLATIVE BRANCH

        If formDepartmentVoting.cmbGov.Text <> "" Then
            UpdateDept_GovVotes()
        End If
        If formDepartmentVoting.cmbViceGov.Text <> "" Then
            UpdateDept_ViceGovVotes()
        End If
        If formDepartmentVoting.cmbSecretary.Text <> "" Then
            UpdateDept_SecretaryVotes()
        End If
        If formDepartmentVoting.cmbTreasurer.Text <> "" Then
            UpdateDept_TreasurerVotes()
        End If
        If formDepartmentVoting.cmbBMan.Text <> "" Then
            UpdateDept_BmanVotes()
        End If
        If formDepartmentVoting.cmbAuditor.Text <> "" Then
            UpdateDept_AuditorVotes()
        End If
        If formDepartmentVoting.cmbPIO.Text <> "" Then
            UpdateDept_PIOVotes()
        End If
        'END DEPARTMENT VOTING
    End Sub

#Region "Casting SSG Executive Votes"
    Private Sub UpdateSSGE_GovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_ViceGovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbViceGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_SecretaryVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbSecretary.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_TreasurerVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbTreasurer.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_AuditorVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbAuditor.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_BmanVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbBMan.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGE_PIOVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGVoting.cmbPIO.SelectedValue.ToString & "' "
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
#End Region

#Region "Casting SSG Legislative Votes"
    Private Sub UpdateSSGL_GovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_ViceGovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbViceGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_SecretaryVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbSecretary.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_TreasurerVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbTreasurer.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_AuditorVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbAuditor.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_BmanVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbBMan.SelectedValue.ToString & "' "
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

    Private Sub UpdateSSGL_PIOVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formSSGLVoting.cmbPIO.SelectedValue.ToString & "' "
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
#End Region

#Region "Casting Department Votes"
    Private Sub UpdateDept_GovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_ViceGovVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbViceGov.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_SecretaryVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbSecretary.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_TreasurerVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbTreasurer.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_AuditorVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbAuditor.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_BmanVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbBMan.SelectedValue.ToString & "' "
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

    Private Sub UpdateDept_PIOVotes()
        Try
            query = "UPDATE Candidate SET Votes=Votes+1 WHERE CandidateID='" & formDepartmentVoting.cmbPIO.SelectedValue.ToString & "' "
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
#End Region

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        'If formSSGVoting.cmbGov.Text = "" Or formSSGVoting.cmbViceGov.Text = "" Or formSSGVoting.cmbSecretary.Text = "" Or formSSGVoting.cmbTreasurer.Text = "" Or formSSGVoting.cmbBMan.Text = "" Or formSSGVoting.cmbAuditor.Text = "" Or formSSGVoting.cmbPIO.Text = "" Then
        '    MsgBox("All Fields Required", MsgBoxStyle.Exclamation, "Submit Votes")
        If MsgBox("Are you sure you want to finally submit your votes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Submit Votes") = MsgBoxResult.Yes Then
            CastSSGVotes()
            UpdateVoterIsVoted()
            UpdateVoterToLogout()
            Me.Hide()
            AddLogs()
            formVotingLogin.Show()
            formVotingLogin.txtIDnumber.Clear()
            formVotingLogin.txtIDnumber.Focus()
            MsgBox("Congratulations you have successfully Voted", MsgBoxStyle.Information, "Submit Votes")
        End If
    End Sub

    Public Sub AddLogs()
        Dim strPCName As String = System.Net.Dns.GetHostName()
        Dim strDesc As String = lblStudentName.Text & " voted this unit"

        Try
            query = "INSERT INTO VotingLogs(Date, Time, Description, PCName) VALUES('" & Date.Now.ToString("MM/dd/yyyy") & "', '" & Format(Date.Now, "Long Time") & "', '" & strDesc & "', '" & strPCName & "')"
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlcommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub UpdateVoterToLogout()
        Try
            query = "UPDATE Student SET isLogin=0 WHERE StudentID='" & lblStudentName.Tag & "' "
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

    Private Sub UpdateVoterIsVoted()
        Try
            query = "UPDATE Student SET isVoted='YES' WHERE StudentID='" & lblStudentName.Tag & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlcommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
        Me.Close()
    End Sub

End Class
