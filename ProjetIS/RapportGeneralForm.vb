Imports System.Data.SqlTypes

Public Class RapportGeneralForm
    Friend rapportInformation As Rapport
    Delegate Sub DupdateInfo()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim date_debut As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date_fin As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim textToSave As String = RichTextBox1.Text

        If (rapportInformation.idRapport <> Nothing) Then

            Dim sqlSring As String = "Update rapport_general SET texte='" & RichTextBox1.Text & "' WHERE idrapport_general=" & rapportInformation.idRapport
            If (ExecuteQueryMySql(sqlSring)) Then
                MessageBox.Show(Me, "Rapport modifié", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim rapportAMettreAjour As New ListeRapportForm
                For Each logForm As ListeRapportForm In Application.OpenForms.OfType(Of ListeRapportForm)()
                    Dim msd As ListeRapportForm.DMajDG = AddressOf logForm.MajDG

                    msd.Invoke()
                Next

                Me.Close()
                Me.Dispose()
            End If
        Else
            If (textToSave <> "") Then
                Dim sqlSring As String = "Insert into rapport_general VALUES(DEFAULT,'" & userInformation.id & "','" + date_debut + "','" & date_fin + "','" & textToSave + "')"
                If (ExecuteQueryMySql(sqlSring)) Then
                    MessageBox.Show(Me, "Rapport enregistré", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    For Each logForm As ListeRapportForm In Application.OpenForms.OfType(Of ListeRapportForm)()
                        Dim msd As ListeRapportForm.DMajDG = AddressOf logForm.MajDG

                        msd.Invoke()
                    Next
                    Me.Close()
                    Me.Dispose()
                End If
            End If
        End If

    End Sub

    Private Sub RapportGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (rapportInformation.idRapport <> Nothing) Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Me.DateTimePicker1.Value = rapportInformation.date_debut
            Me.DateTimePicker2.Value = rapportInformation.date_fin
            Me.RichTextBox1.Text = rapportInformation.texteRapport
            Button1.Text = "Editer"
        End If
    End Sub

    Public Sub updateInfo()
        If (rapportInformation.idRapport <> Nothing) Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Me.DateTimePicker1.Value = rapportInformation.date_debut
            Me.DateTimePicker2.Value = rapportInformation.date_fin
            Me.RichTextBox1.Text = rapportInformation.texteRapport
            Button1.Text = "Editer"
        End If
    End Sub
End Class