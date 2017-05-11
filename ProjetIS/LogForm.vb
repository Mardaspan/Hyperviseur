Public Class LogForm

    Private Const Warn As String = "warn"
    Private Const Info As String = "info"
    Private Const Alert As String = "alert"

    Delegate Sub DMajDg()

    Public Sub MajDG()
        Dim nbInfo As Integer = 0
        Dim nbWarning As Integer = 0
        Dim nbAlert As Integer = 0

        DataGridView1.Rows.Clear()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
        Dim dataFromFile As ArrayList = ReadFile(FichierLogRapport)
        Dim tabDataFromRow As String()
        If (dataFromFile IsNot Nothing) Then
            If (dataFromFile.Count > 0) Then
                For Each line As String In dataFromFile
                    tabDataFromRow = line.Split(";")
                    DataGridView1.Rows.Add(tabDataFromRow)
                Next
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If (row.Cells(2).Value = Warn) Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    nbWarning += 1
                    Warning_value.Text = nbWarning
                ElseIf (row.Cells(2).Value = Alert) Then
                    row.DefaultCellStyle.BackColor = Color.Red
                    nbAlert += 1
                    Alert_value.Text = nbAlert
                Else
                    nbInfo += 1
                    Information_Value.Text = nbInfo
                End If
            Next
        End If
        Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1

        'Select the last row.
        'Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True

    End Sub




    Private Sub LogForm_OnLoad(sender As Object, e As EventArgs) Handles Me.Load
        If MainForm.pauseThread = True Then
            Button1.Text = "Reprendre"
        Else
            Button1.Text = "Pause"
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MainForm.pauseThread = False Then
            MainForm.pauseThread = True
            Button1.Text = "Reprendre"
        Else
            MainForm.pauseThread = False
            Button1.Text = "Pause"
        End If

    End Sub
End Class