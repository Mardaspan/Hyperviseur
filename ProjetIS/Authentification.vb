Public Class Authentification


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim test = SqlQuery("select username from user")
        Console.WriteLine(test)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class