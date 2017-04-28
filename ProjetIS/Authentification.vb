Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Authentification


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        userInformation = QueryForLogin(TextBox1.Text, GetHash(TextBox2.Text))

        If userInformation.id <> Nothing Then
            Me.Close()
            Me.Dispose()
        Else
            ErrorProvider1.SetError(TextBox2, "Mot de passe ou nom d'utilisateur inconnu")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub



    Private Sub InscriptionLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles InscriptionLabel.LinkClicked
        Dim inscription As New Inscription
        inscription.ShowDialog()
        If inscription.DialogResult = DialogResult.OK Then
            Me.TextBox1.Text = inscription.TextBox1.Text
            Me.TextBox2.Focus()
        End If
    End Sub
End Class