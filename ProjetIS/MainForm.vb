Imports System.Threading

Public Class MainForm

    Public backGroundthread As Thread
    Dim randomTime As New Random(DateTime.Now.Millisecond)
    Dim FormLog As LogForm
    Dim listRobotForm As ListeRobotForm

    Public stopThread As Boolean = False
    Public pauseThread As Boolean = False


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connexion()
        If (userInformation.id = Nothing) Then
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        Label3.Text = userInformation.username
        Label5.Text = DateTime.Now.ToString("dd-MM-yyyy")
        backGroundthread = New Thread(AddressOf writeToFile)
        backGroundthread.Start()

    End Sub



    Private Sub LogButton_Click(sender As Object, e As EventArgs) Handles Log_btn.Click
        If (Not Application.OpenForms.OfType(Of LogForm).Any()) Then
            FormLog = New LogForm()
            FormLog.Show()
        Else
            Dim log As LogForm
            For Each logForm As LogForm In Application.OpenForms.OfType(Of LogForm)
                log = logForm
            Next
            log.Show()
        End If

    End Sub



    Private Sub writeToFile()

        While (True)
            If (pauseThread = False) Then
                WriteFile(FichierLogRapport, GenerateRandomLog())
                If (Application.OpenForms.OfType(Of LogForm).Any()) Then
                    If (FormLog.Visible) Then
                        FormLog.Invoke(New LogForm.DMajDg(AddressOf FormLog.MajDG))
                    End If

                End If

            End If
            If (stopThread) Then
                Exit Sub
            End If
            Thread.Sleep(randomTime.Next(0, 5000))
        End While

    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        stopThread = True
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'info mine
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Liste robot
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Rapport
        Dim rapport As New ListeRapportForm
        rapport.Show()
    End Sub
End Class