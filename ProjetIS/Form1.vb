Public Class MainForm
    Dim test = 0
    Dim tableau As New ArrayList


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connexion()
        If (userInformation.id = Nothing) Then
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If
        Me.WindowState = FormWindowState.Maximized
        Me.MaximumSize = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
    End Sub


End Class
