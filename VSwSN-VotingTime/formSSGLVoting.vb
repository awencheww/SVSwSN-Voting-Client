Imports MySql.Data.MySqlClient

Public Class formSSGLVoting

    Private Sub formSSGLVoting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub LoadPositions()
        LoadGov()
        LoadViceGov()
        LoadSecretary()
        LoadTreasurer()
        LoadBusinessManager()
        LoadAuditor()
        LoadPIO()
    End Sub

#Region "Load Positions"

#Region "GOVERNOR"
    Private Sub LoadGov()
        Try
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName,PicFile FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Governor' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname ASC"
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
    Private Sub cmbGov_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGov.SelectedIndexChanged
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Vice-Governor' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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
    Private Sub cmbViceGov_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cmbViceGov.SelectedIndexChanged
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Secretary' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Treasurer' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Business Manager' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'Auditor' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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
            query = "SELECT CandidateID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename, '   - ', PartyName) as CanName FROM Candidate as C, Party as P, Positions as Po, voting_level as L WHERE L.LevelID = Po.LevelID AND C.PartyID = P.PartyID AND C.PositionID = Po.PositionID AND PositionName = 'PIO' AND LevelName = 'SSG Legislative Branch'  ORDER BY Lastname, Firstname"
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

#End Region

End Class