Public Class MainForm


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connexion()
        If (userInformation.id = Nothing) Then
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If
        Me.WindowState = FormWindowState.Maximized
        Me.MaximumSize = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
    End Sub

    Private Sub LogButton_Click(sender As Object, e As EventArgs) Handles LogButton.Click
        Dim FormLog As New LogForm
        FormLog.Show()
    End Sub
End Class