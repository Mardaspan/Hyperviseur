Public Class MineInfo
    Private Sub Mine_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDatas(13, 45, 12, 67)
    End Sub

    Private Sub LogButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetDatas(64, 67, 34, 24)
    End Sub

    Public Sub GetDatas(ByVal temperature As Double, ByVal radiation As Double, ByVal hygrometry As Double, ByVal battery As Integer)
        Me.r1_temp.Text = Convert.ToString(temperature) + " °C"
        If (temperature > 60.0 Or temperature < -10.0) Then
            Me.r1_temp.ForeColor = Color.Red
            Me.r1_temp_label.ForeColor = Color.Red
        Else
            Me.r1_temp.ForeColor = Color.Black
            Me.r1_temp_label.ForeColor = Color.Black
        End If
        Me.r1_rad.Text = Convert.ToString(radiation) + " MBq/g"
        If (radiation > 1000.0) Then
            Me.r1_rad.ForeColor = Color.Red
            Me.r1_rad_label.ForeColor = Color.Red
        Else
            Me.r1_rad.ForeColor = Color.Black
            Me.r1_rad_label.ForeColor = Color.Black
        End If
        Me.r1_hyg.Text = Convert.ToString(hygrometry) + " %"
        If (hygrometry > 70.0) Then
            Me.r1_hyg.ForeColor = Color.Red
            Me.r1_hyg_label.ForeColor = Color.Red
        Else
            Me.r1_hyg.ForeColor = Color.Black
            Me.r1_hyg_label.ForeColor = Color.Black
        End If
        Me.r1_bat.Text = Convert.ToString(battery) + " %"
        If (battery < 20) Then
            Me.r1_bat.ForeColor = Color.Red
            Me.r1_bat_label.ForeColor = Color.Red
        Else
            Me.r1_bat.ForeColor = Color.Black
            Me.r1_bat_label.ForeColor = Color.Black
        End If
    End Sub
End Class