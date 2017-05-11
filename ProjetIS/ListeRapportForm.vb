Public Class ListeRapportForm
    Dim arrayOfData As ArrayList

    Delegate Sub DMajDG()


    Private Sub ListeRapportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call MajDG()
    End Sub

    Public Sub MajDG()
        Dim sqlString As String = "select * from rapport_general where idUser=" + Convert.ToString(userInformation.id)
        arrayOfData = QueryForRapport(sqlString)
        DataGridView1.Rows.Clear()
        Dim i As Integer = 0
        For Each line As Rapport In arrayOfData
            DataGridView1.Rows.Add()
            DataGridView1.Item("idUser", i).Value = userInformation.username
            DataGridView1.Item("Date_debut", i).Value = line.date_debut
            DataGridView1.Item("Date_fin", i).Value = line.date_fin
            If (line.texteRapport.Length > 41) Then
                DataGridView1.Item("Rapport", i).Value = line.texteRapport.Substring(0, 40) & " (...)"
            Else
                DataGridView1.Item("Rapport", i).Value = line.texteRapport
            End If

            i += 1
        Next
    End Sub



    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If (arrayOfData IsNot Nothing) Then
            Dim idRapport = arrayOfData.Item(e.RowIndex)
            Dim rapportEdition = New RapportGeneralForm
            rapportEdition.rapportInformation = idRapport
            rapportEdition.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newRapport = New RapportGeneralForm
        newRapport.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If (Application.OpenForms.OfType(Of RapportGeneralForm).Any()) Then
            For Each rapportGeneralForm As RapportGeneralForm In Application.OpenForms.OfType(Of RapportGeneralForm)
                rapportGeneralForm.rapportInformation = arrayOfData.Item(e.RowIndex)
                Dim msd As RapportGeneralForm.DupdateInfo = AddressOf rapportGeneralForm.updateInfo
                msd.Invoke()
            Next
        End If

    End Sub
End Class