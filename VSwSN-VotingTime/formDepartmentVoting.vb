Imports MySql.Data.MySqlClient

Public Class formDepartmentVoting

    Private Sub formDepartmentVoting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPositions()
        ClearAllFields()
    End Sub

    Public Sub ClearAllFields()
        cmbGov.Text = ""
        cmbGov.SelectedValue = vbNull
        cmbViceGov.Text = ""
        cmbViceGov.SelectedValue = vbNull
        cmbSecretary.Text = ""
        cmbSecretary.SelectedValue = vbNull
        cmbAuditor.Text = ""
        cmbAuditor.SelectedValue = vbNull
        cmbBMan.Text = ""
        cmbBMan.SelectedValue = vbNull
        cmbTreasurer.Text = ""
        cmbTreasurer.SelectedValue = vbNull
        cmbPIO.Text = ""
        cmbPIO.SelectedValue = vbNull
        cmb1stYrRep.Text = ""
        cmb1stYrRep.SelectedValue = vbNull
        cmb2ndYrRep.Text = ""
        cmb2ndYrRep.SelectedValue = vbNull
        cmb3rdYrRep.Text = ""
        cmb3rdYrRep.SelectedValue = vbNull
        cmb4thYrRep.Text = ""
        cmb4thYrRep.SelectedValue = vbNull
    End Sub

    Private Sub LoadPositions()
        LoadGov()
        LoadViceGov()
        LoadSecretary()
        LoadTreasurer()
        LoadBusinessManager()
        LoadAuditor()
        LoadPIO()
        Load1stYrRep()
        Load2ndYrRep()
        Load3rdYrRep()
        Load4thYrRep()
    End Sub

#Region "Load Positions"

#Region "GOVERNOR"
    Private Sub LoadGov()
        Try
            query = "SELECT CandidateID,DepartmentID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName,PicFile FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Governor' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname ASC"
            Connection()
            cmbGov.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbGov.DataSource = sqlds.Tables("Candidate")
            cmbGov.DisplayMember = "CanName"
            cmbGov.ValueMember = "CandidateID"
            cmbGov.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbGov_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbGov.SelectedIndexChanged
        Try
            query = "SELECT PicFile from Candidate where CandidateID = '" & cmbGov.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxGov.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "VICE-GOVERNOR"
    Private Sub LoadViceGov()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Vice-Governor' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbViceGov.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbViceGov.DataSource = sqlds.Tables("Candidate")
            cmbViceGov.DisplayMember = "CanName"
            cmbViceGov.ValueMember = "CandidateID"
            cmbViceGov.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbViceGov_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbViceGov.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbViceGov.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxViceGov.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "SECRETARY"
    Private Sub LoadSecretary()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Secretary' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbSecretary.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbSecretary.DataSource = sqlds.Tables("Candidate")
            cmbSecretary.DisplayMember = "CanName"
            cmbSecretary.ValueMember = "CandidateID"
            cmbSecretary.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbSecretary_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbSecretary.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbSecretary.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxSecretary.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "TREASURER"
    Private Sub LoadTreasurer()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Treasurer' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbTreasurer.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbTreasurer.DataSource = sqlds.Tables("Candidate")
            cmbTreasurer.DisplayMember = "CanName"
            cmbTreasurer.ValueMember = "CandidateID"
            cmbTreasurer.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbTreasurer_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbTreasurer.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbTreasurer.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxTreasurer.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "BUSINESS MANAGER"
    Private Sub LoadBusinessManager()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Business Manager' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbBMan.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbBMan.DataSource = sqlds.Tables("Candidate")
            cmbBMan.DisplayMember = "CanName"
            cmbBMan.ValueMember = "CandidateID"
            cmbBMan.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbBMan_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbBMan.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbBMan.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxBMan.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "AUDITOR"
    Private Sub LoadAuditor()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Auditor' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbAuditor.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbAuditor.DataSource = sqlds.Tables("Candidate")
            cmbAuditor.DisplayMember = "CanName"
            cmbAuditor.ValueMember = "CandidateID"
            cmbAuditor.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbAuditor_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbAuditor.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbAuditor.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxAuditor.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "PIO"
    Private Sub LoadPIO()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'PIO' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmbPIO.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmbPIO.DataSource = sqlds.Tables("Candidate")
            cmbPIO.DisplayMember = "CanName"
            cmbPIO.ValueMember = "CandidateID"
            cmbPIO.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmbPIO_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbPIO.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmbPIO.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBoxPIO.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "1st Year Representative"
    Private Sub Load1stYrRep()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = '1st Year Rep' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmb1stYrRep.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmb1stYrRep.DataSource = sqlds.Tables("Candidate")
            cmb1stYrRep.DisplayMember = "CanName"
            cmb1stYrRep.ValueMember = "CandidateID"
            cmb1stYrRep.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmb1stYrRep_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmb1stYrRep.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmb1stYrRep.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBox1Rep.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "2nd Year Representative"
    Private Sub Load2ndYrRep()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = '2nd Year Rep' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmb2ndYrRep.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmb2ndYrRep.DataSource = sqlds.Tables("Candidate")
            cmb2ndYrRep.DisplayMember = "CanName"
            cmb2ndYrRep.ValueMember = "CandidateID"
            cmb2ndYrRep.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmb2ndYrRep_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmb2ndYrRep.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmb2ndYrRep.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBox2Rep.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "3rd Year Representative"
    Private Sub Load3rdYrRep()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = '3rd Year Rep' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmb3rdYrRep.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmb3rdYrRep.DataSource = sqlds.Tables("Candidate")
            cmb3rdYrRep.DisplayMember = "CanName"
            cmb3rdYrRep.ValueMember = "CandidateID"
            cmb3rdYrRep.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmb3rdYrRep_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmb3rdYrRep.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmb3rdYrRep.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBox3Rep.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#Region "4th Year Representative"
    Private Sub Load4thYrRep()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = '4th Year Rep' AND LevelName = 'Department' AND DepartmentID='" & formVotingMain.lblDepartment.Tag & "'  ORDER BY Lastname, Firstname"
            Connection()
            cmb4thYrRep.Items.Clear()
            sqlda = New MySqlDataAdapter(query, conn)
            sqlds = New DataSet
            sqlda.Fill(sqlds, "Candidate")
            cmb4thYrRep.DataSource = sqlds.Tables("Candidate")
            cmb4thYrRep.DisplayMember = "CanName"
            cmb4thYrRep.ValueMember = "CandidateID"
            cmb4thYrRep.Text = ""
        Catch ex As Exception

        Finally
            sqlda.Dispose()
            conn.Close()
        End Try
    End Sub
    'Load IMAGE
    Private Sub cmb4thYrRep_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmb4thYrRep.SelectedIndexChanged
        Try
            query = "select picFile from Candidate where CandidateID = '" & cmb4thYrRep.SelectedValue.ToString & "' "
            Connection()
            sqlcommand = New MySqlCommand(query, conn)
            sqlreader = sqlcommand.ExecuteReader()

            If sqlreader.Read = True Then
                Dim data As Byte() = DirectCast(sqlreader("PicFile"), Byte())
                Dim ms As New System.IO.MemoryStream(data)
                PictureBox4Rep.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        Finally
            sqlcommand.Dispose()
            conn.Close()
        End Try
    End Sub
#End Region

#End Region

End Class