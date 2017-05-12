Imports System.Threading

Public Class MineInfo
    Public backgroundThread As Thread

    Delegate Sub DShowDatas()

    Dim randomTime As New Random(DateTime.Now.Millisecond)
    Dim allLabel As New ArrayList
    Dim threadStopped As Boolean = False

    Private Sub Mine_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        call GetAllLabel()
        backgroundThread = New Thread(AddressOf GetDataFromThread)
        backgroundThread.Start()

        backgroundThread = new Thread(AddressOf Average)
        backgroundThread.Start()
    End Sub

    Private sub GetAllLabel()
        For Each control As Label In Me.Controls.OfType (Of Label)
            If _
                control.Name.StartsWith("CL") or control.Name.StartsWith("MA") or control.Name.StartsWith("SH") or
                control.Name.StartsWith("HA") Then
                allLabel.Add(control)
            End If
        Next
    End sub

    Private Sub GetDataFromThread()

While(True)
    Dim datas As ArrayList = ReadFile(FichierLogCapteurs)
    Dim tabDatas As String()
    Dim radiation As String
    Dim hygrometry As String
    Dim temperature As String
    Dim battery As Integer
    Dim date_log As String
    Dim time_log As String
    Dim robot As String


    If (datas.Count > 0) Then
        For Each line As String In datas
            tabDatas = line.Split(";")
            date_log = tabDatas(0)
            time_log = tabDatas(1)
            robot = tabDatas(2)
            radiation = tabDatas(3)
            hygrometry = tabDatas(4)
            temperature = tabDatas(5)
            battery = Integer.Parse(tabDatas(6))
            Dim stringSplitted As String()
            For Each label As Label In allLabel
                stringSplitted = label.Name.Split("_")
                If (stringSplitted(0) = robot) Then
                    If (Me.IsHandleCreated)
                        Select Case stringSplitted(1)
                            Case "temp"
                                label.Invoke(Sub() label.Text = temperature + " °C")
                                If temperature > 60
                                    label.Invoke(Sub() label.ForeColor = Color.Red)
                                elseif temperature < 10
                                    label.Invoke(Sub() label.ForeColor = Color.Blue)
                                Else 
                                    label.Invoke(Sub() label.ForeColor = Color.Black)
                                        
                                End If
                            Case "rad"
                                label.Invoke(Sub() label.Text = radiation + " MBq/g")
                            Case "hyg"
                                label.Invoke(Sub() label.Text = hygrometry + " %")
                            Case "bat"
                                label.Invoke(Sub() label.Text = Convert.ToString(battery) + " %")
                        End Select
                    End If

                End If
            Next
            if (threadStopped)
                Exit Sub
            End If
            Thread.Sleep(randomTime.Next(0, 5000))
        Next

    End If
End While
        
    End Sub

    Private sub Average()
        dim allLabelMoyenne as New ArrayList
        dim sommeTemp = 0
        dim sommeRad = 0
        Dim sommeHyg = 0

        For Each control As Label In Me.Controls.OfType (Of Label)
            If control.Name.StartsWith("moyenne") Then
                allLabelMoyenne.Add(control)
            End If
        Next

        While (true)
            sommeTemp = 0
            sommeHyg = 0
            sommeRad = 0
            If Me.IsHandleCreated
                For Each label As Label In allLabel
                    select Case label.Name.Split("_")(1)
                        Case "temp"
                            sommeTemp = sommeTemp + NumFromLabel(label.Text)
                        Case "rad"
                            sommeRad = sommeRad + NumFromLabel(label.Text)
                        Case "hyg"
                            sommeHyg = sommeHyg + NumFromLabel(label.Text)
                    End Select
                Next


                For Each label As Label In allLabelMoyenne
                    Select Case label.Name.Split("_")(1)
                        Case "temp"
                            label.Invoke(Sub() label.Text = "Temperature moyenne :" & sommeTemp/10 & " °C")
                        case "rad"
                            label.Invoke(Sub() label.Text = "Radiation moyenne :" & sommeRad/10 & " MBq/g")
                        case "hyg"
                            label.Invoke(Sub() label.Text = "Hygrométrie moyenne :" & sommeHyg/10 & " %")
                    End Select
                Next
            End If
            if (threadStopped)
                Exit Sub
            End If
            Thread.Sleep(5000)
        End While
    End sub

    Private Sub GetDatasFromLogs()
        'Dim datas As ArrayList = ReadFile(FichierLogCapteurs)
        'Dim tabDatas As String()
        'Dim radiation As String
        'Dim hygrometry As String
        'Dim temperature As String
        'Dim battery As Integer
        'Dim date_log As String
        'Dim time_log As String
        'Dim robot As String

        'While (True)
        '    If (datas IsNot Nothing) Then
        '        If (datas.Count > 0) Then
        '            For Each line As String In datas
        '                tabDatas = line.Split(";")
        '                date_log = tabDatas(0)
        '                time_log = tabDatas(1)
        '                robot = tabDatas(2)
        '                radiation = tabDatas(3)
        '                hygrometry = tabDatas(4)
        '                temperature = tabDatas(5)
        '                battery = Integer.Parse(tabDatas(6))
        '                If Me.IsHandleCreated Then
        '                    Me.Invoke(New MineInfo.DShowDatas(AddressOf Me.ShowDatas), robot, temperature, radiation, hygrometry, battery)
        '                End If
        '            Next

        '        End If
        '    End If


        '    If (threadStopped) Then
        '        Exit Sub
        '    End If
        '   ' Thread.Sleep(randomTime.Next(0, 3000))
        'End While
    End Sub

    Public Sub ShowDatas()


        'Me.sh01_temp.Text = Convert.ToString(temperature) + " °C"
        'If (temperature > 60.0 Or temperature < -10.0) Then
        '    Me.sh01_temp.ForeColor = Color.Red
        '    Me.label_sh01_temp.ForeColor = Color.Red
        'Else
        '    Me.sh01_temp.ForeColor = Color.Black
        '    Me.label_sh01_temp.ForeColor = Color.Black
        'End If
        'Me.sh01_rad.Text = Convert.ToString(radiation) + " MBq/g"
        'If (radiation > 1000.0) Then
        '    Me.sh01_rad.ForeColor = Color.Red
        '    Me.label_sh01_rad.ForeColor = Color.Red
        'Else
        '    Me.sh01_rad.ForeColor = Color.Black
        '    Me.label_sh01_rad.ForeColor = Color.Black
        'End If
        'Me.sh01_hyg.Text = Convert.ToString(hygrometry) + " %"
        'If (hygrometry > 70.0) Then
        '    Me.sh01_hyg.ForeColor = Color.Red
        '    Me.label_sh01_hyg.ForeColor = Color.Red
        'Else
        '    Me.sh01_hyg.ForeColor = Color.Black
        '    Me.label_sh01_hyg.ForeColor = Color.Black
        'End If
        'Me.sh01_bat.Text = Convert.ToString(battery) + " %"
        'If (battery < 20) Then
        '    Me.sh01_bat.ForeColor = Color.Red
        '    Me.label_sh01_bat.ForeColor = Color.Red
        'Else
        '    Me.sh01_bat.ForeColor = Color.Black
        '    Me.label_sh01_bat.ForeColor = Color.Black
        'End If
    End Sub

    Private sub updateData()
    End sub

    Private Sub MineInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        threadStopped = True
    End Sub

    Private Sub label_SH01_title_Click(sender As Object, e As EventArgs) Handles label_SH01_title.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = SH01_rad.Text
        formVuRobot.Label5.Text = SH01_temp.Text
        formVuRobot.Label6.Text = SH01_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub label_SH02_title_Click(sender As Object, e As EventArgs) Handles label_SH02_title.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = SH02_rad.Text
        formVuRobot.Label5.Text = SH02_temp.Text
        formVuRobot.Label6.Text = SH02_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub label_SH03_title_Click(sender As Object, e As EventArgs) Handles label_SH03_title.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = SH03_rad.Text
        formVuRobot.Label5.Text = SH03_temp.Text
        formVuRobot.Label6.Text = SH03_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = CL01_rad.Text
        formVuRobot.Label5.Text = CL01_temp.Text
        formVuRobot.Label6.Text = CL01_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = CL02_rad.Text
        formVuRobot.Label5.Text = CL02_temp.Text
        formVuRobot.Label6.Text = CL02_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = CL03_rad.Text
        formVuRobot.Label5.Text = CL03_temp.Text
        formVuRobot.Label6.Text = CL03_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = HA01_rad.Text
        formVuRobot.Label5.Text = HA01_temp.Text
        formVuRobot.Label6.Text = HA01_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label54_Click(sender As Object, e As EventArgs) Handles Label54.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = HA02_rad.Text
        formVuRobot.Label5.Text = HA02_temp.Text
        formVuRobot.Label6.Text = HA02_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label63_Click(sender As Object, e As EventArgs) Handles Label63.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = MA01_rad.Text
        formVuRobot.Label5.Text = MA01_temp.Text
        formVuRobot.Label6.Text = MA01_hyg.Text
        formVuRobot.Show()
    End Sub

    Private Sub Label72_Click(sender As Object, e As EventArgs) Handles Label72.Click
        Dim formVuRobot = new VuRobotForm
        formVuRobot.Label4.Text = MA02_rad.Text
        formVuRobot.Label5.Text = MA02_temp.Text
        formVuRobot.Label6.Text = MA02_hyg.Text
        formVuRobot.Show()
    End Sub
End Class