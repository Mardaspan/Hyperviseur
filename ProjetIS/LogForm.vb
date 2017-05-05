Public Class LogForm

    Private Const Warn As String = "warn"
    Private Const Info As String = "info"
    Private Const Alert As String = "alert"

    Private Sub MajDG()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If (row.Cells(2).Value = Warn) Then
                row.DefaultCellStyle.BackColor = Color.Yellow
            ElseIf (row.Cells(2).Value = Alert) Then
                row.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub



    Private Sub LogForm_OnLoad(sender As Object, e As EventArgs) Handles Me.Load
        Dim dataFromFile As ArrayList = ReadFile(FichierLogRapport)
        Dim tabDataFromRow As String()
        If (dataFromFile.Count > 0) Then
            For Each line As String In dataFromFile
                tabDataFromRow = line.Split(";")

                DataGridView1.Rows.Add(tabDataFromRow)
            Next
        End If

        Call MajDG()
    End Sub

End Class