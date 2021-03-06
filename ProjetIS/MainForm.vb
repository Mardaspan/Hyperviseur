﻿Imports System.Threading

Public Class MainForm
    Public backGroundthread As Thread
    Dim randomTime As New Random(DateTime.Now.Millisecond)
    Dim FormLog As LogForm
    Dim mInfo As MineInfo
    Dim listRobotForm As ListeRobotForm
    Dim formMine As MineInfo

    Public stopThread As Boolean = False
    Public pauseThread As Boolean = False


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       

        Label3.Text = userInformation.username
        Label5.Text = DateTime.Now.ToString("dd-MM-yyyy")
        backGroundthread = New Thread(AddressOf writeToFileRapport)
        backGroundthread.Start()
        backGroundthread = New Thread(AddressOf writeToFileCapteurs)
        backGroundthread.Start()
    End Sub


    Private Sub LogButton_Click(sender As Object, e As EventArgs) Handles Log_btn.Click
        If (Not Application.OpenForms.OfType (Of LogForm).Any()) Then
            FormLog = New LogForm()
            FormLog.Show()
        Else
            Dim log As LogForm
            For Each logForm As LogForm In Application.OpenForms.OfType (Of LogForm)
                log = logForm
            Next
            pauseThread = false
            log.Show()
        End If
    End Sub


    Private Sub writeToFileRapport()

        While (True)
            If (pauseThread = False) Then
                Dim randomString as String = GenerateRandomLogRapport()
                WriteFile(FichierLogRapport, randomString)
                If (Application.OpenForms.OfType (Of LogForm).Any()) Then
                    If (FormLog.Visible) Then
                        FormLog.Invoke(New LogForm.DUpdateData(AddressOf FormLog.updateData),randomString)
                    End If

                End If
                
            End If
            If (stopThread) Then
                Exit Sub
            End If
            Thread.Sleep(randomTime.Next(0, 5000))
        End While
    End Sub

    Private Sub writeToFileCapteurs()

        While(true)
            
                WriteFile(FichierLogCapteurs, GenerateRandomLogCapteurs())
            If (stopThread) Then
                Exit Sub
            End If
            Thread.Sleep(randomTime.Next(0, 2000))
        End While
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        stopThread = True
        If(FormLog isnot Nothing)
            FormLog.stopThread = true
        End If
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        'info mine
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Environnement de la mine / Liste robot
        If (Not Application.OpenForms.OfType (Of MineInfo).Any()) Then
            formMine = New MineInfo()
            formMine.Show()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Rapport
        Dim rapport As New ListeRapportForm
        rapport.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show(Me,"Superviseur alertée","Alerte",MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
End Class