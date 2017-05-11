Imports System.Threading

Public Class MineInfo
    Public backgroundThread As Thread
    Delegate Sub DShowDatas(ByVal temperature As Double, ByVal radiation As Double, ByVal hygrometry As Double, ByVal battery As Integer)
    Dim randomTime As New Random(DateTime.Now.Millisecond)

    Private Sub Mine_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backgroundThread = New Thread(AddressOf GetDatasFromLogs)
        backgroundThread.Start()
    End Sub

    Private Sub GetDatasFromLogs()
        Dim datas As ArrayList = ReadFile(FichierLogCapteurs)
        Dim tabDatas As String()
        Dim radiation As Double
        Dim hygrometry As Double
        Dim temperature As Double
        Dim battery As Integer
        Dim date_log As String
        Dim time_log As String
        Dim robot As String

        While (True)
            If (datas IsNot Nothing) Then
                If (datas.Count > 0) Then
                    For Each line As String In datas
                        tabDatas = line.Split(";")
                    Next

                    date_log = tabDatas(0)
                    time_log = tabDatas(1)
                    robot = tabDatas(2)
                    radiation = Convert.ToDouble(tabDatas(3))
                    hygrometry = Convert.ToDouble(tabDatas(4))
                    temperature = Convert.ToDouble(tabDatas(5))
                    battery = Convert.ToDouble(tabDatas(6))
                End If
            End If
            Me.Invoke(New MineInfo.DShowDatas(AddressOf Me.ShowDatas), temperature, radiation, hygrometry, battery)

            Thread.Sleep(randomTime.Next(0, 3000))
        End While
    End Sub

    Public Sub ShowDatas(ByVal temperature As Double, ByVal radiation As Double, ByVal hygrometry As Double, ByVal battery As Integer)
        Me.sh01_temp.Text = Convert.ToString(temperature) + " °C"
        If (temperature > 60.0 Or temperature < -10.0) Then
            Me.sh01_temp.ForeColor = Color.Red
            Me.sh01_temp_label.ForeColor = Color.Red
        Else
            Me.sh01_temp.ForeColor = Color.Black
            Me.sh01_temp_label.ForeColor = Color.Black
        End If
        Me.sh01_rad.Text = Convert.ToString(radiation) + " MBq/g"
        If (radiation > 1000.0) Then
            Me.sh01_rad.ForeColor = Color.Red
            Me.sh01_rad_label.ForeColor = Color.Red
        Else
            Me.sh01_rad.ForeColor = Color.Black
            Me.sh01_rad_label.ForeColor = Color.Black
        End If
        Me.sh01_hyg.Text = Convert.ToString(hygrometry) + " %"
        If (hygrometry > 70.0) Then
            Me.sh01_hyg.ForeColor = Color.Red
            Me.sh01_hyg_label.ForeColor = Color.Red
        Else
            Me.sh01_hyg.ForeColor = Color.Black
            Me.sh01_hyg_label.ForeColor = Color.Black
        End If
        Me.sh01_bat.Text = Convert.ToString(battery) + " %"
        If (battery < 20) Then
            Me.sh01_bat.ForeColor = Color.Red
            Me.sh01_bat_label.ForeColor = Color.Red
        Else
            Me.sh01_bat.ForeColor = Color.Black
            Me.sh01_bat_label.ForeColor = Color.Black
        End If
    End Sub
End Class