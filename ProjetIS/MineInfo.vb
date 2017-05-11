Imports System.Threading

Public Class MineInfo
    Public backgroundThread As Thread
    Delegate Sub DShowDatas(ByVal robot As String, ByVal temperature As String, ByVal radiation As String, ByVal hygrometry As String, ByVal battery As Integer)
    Dim randomTime As New Random(DateTime.Now.Millisecond)
    Dim allLabel As New ArrayList
    Dim threadStopped As Boolean = False

    Private Sub Mine_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backgroundThread = New Thread(AddressOf GetDatasFromLogs)
        backgroundThread.Start()
        Call GetAllLabelOnForm()
    End Sub

    Private Sub GetAllLabelOnForm()
        For Each control As Control In Me.Controls.OfType(Of Label)
            If Not control.Name.StartsWith("label") Then
                allLabel.Add(control)
            End If
        Next
    End Sub

    Private Sub GetDatasFromLogs()
        Dim datas As ArrayList = ReadFile(FichierLogCapteurs)
        Dim tabDatas As String()
        Dim radiation As String
        Dim hygrometry As String
        Dim temperature As String
        Dim battery As Integer
        Dim date_log As String
        Dim time_log As String
        Dim robot As String

        While (True)
            If (datas IsNot Nothing) Then
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
                        If Me.IsHandleCreated Then

                            Me.Invoke(New MineInfo.DShowDatas(AddressOf Me.ShowDatas), robot, temperature, radiation, hygrometry, battery)

                        End If
                    Next

                End If
            End If




            If (threadStopped) Then
                Exit Sub
            End If
            Thread.Sleep(randomTime.Next(0, 3000))
        End While
    End Sub

    Public Sub ShowDatas(ByVal robot As String, ByVal temperature As String, ByVal radiation As String, ByVal hygrometry As String, ByVal battery As Integer)
        Dim stringSplitted As String()
        For Each label As Label In allLabel
            stringSplitted = label.Name.Split("_")
            If (stringSplitted(0) = robot) Then
                Select Case stringSplitted(1)
                    Case "temp"
                        label.Text = temperature + " °C"
                    Case "rad"
                        label.Text = radiation + " MBq/g"
                    Case "hyg"
                        label.Text = hygrometry + " %"
                    Case "bat"
                        label.Text = Convert.ToString(battery) + " %"
                End Select
            End If
        Next





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

    Private Sub MineInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        threadStopped = True
    End Sub
End Class