Imports System.Threading

Public Class LogForm
    Private Const Warn As String = "warn"
    Private Const Info As String = "info"
    Private Const Alert As String = "alert"
    Dim nbInfo As Integer = 0
    Dim nbWarning As Integer = 0
    Dim nbAlert As Integer = 0
    public stopThread as Boolean = false

    Private tableData as DataTable = GetTable()
    Private bindingSource1 As New BindingSource()


    Delegate Sub DMajDg()

    Delegate Sub DUpdateData(stringToAdd As String)

    'Public Sub MajDG()
    '    Dim nbInfo As Integer = 0
    '    Dim nbWarning As Integer = 0
    '    Dim nbAlert As Integer = 0

    '    DataGridView1.Rows.Clear()
    '    DataGridView1.ClearSelection()
    '    DataGridView1.CurrentCell = Nothing
    '    Dim dataFromFile As ArrayList = ReadFile(FichierLogRapport)
    '    Dim tabDataFromRow As String()
    '    If (dataFromFile IsNot Nothing) Then
    '        If (dataFromFile.Count > 0) Then
    '            For Each line As String In dataFromFile
    '                tabDataFromRow = line.Split(";")
    '                DataGridView1.Rows.Add(tabDataFromRow)
    '            Next
    '        End If
    '        For Each row As DataGridViewRow In DataGridView1.Rows
    '            If (row.Cells(2).Value = Warn) Then
    '                row.DefaultCellStyle.BackColor = Color.Yellow
    '                nbWarning += 1
    '                Warning_value.Text = nbWarning
    '            ElseIf (row.Cells(2).Value = Alert) Then
    '                row.DefaultCellStyle.BackColor = Color.Red
    '                nbAlert += 1
    '                Alert_value.Text = nbAlert
    '            Else
    '                nbInfo += 1
    '                Information_Value.Text = nbInfo
    '            End If
    '        Next
    '    End If
    '    Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1

    '    'Select the last row.
    '    'Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1).Selected = True
    'End Sub

    Function GetTable() As DataTable
        ' Create new DataTable instance.
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("Date du jour", GetType(String))
        table.Columns.Add("Heure", GetType(String))
        table.Columns.Add("Niveau", GetType(String))
        table.Columns.Add("Source", GetType(String))
        table.Columns.Add("Commentaire", GetType(String))


        Return table
    End Function

    Sub GetData()
        Dim dataFromFile As ArrayList = ReadFile(FichierLogRapport)
        Dim tabDataFromRow As String()
        If (dataFromFile IsNot Nothing) Then
            If (dataFromFile.Count > 0) Then
                For Each line As String In dataFromFile
                    tabDataFromRow = line.Split(";")
                    tableData.Rows.Add(tabDataFromRow(0), tabDataFromRow(1), tabDataFromRow(2), tabDataFromRow(3),
                                       tabDataFromRow(4))
                    if(tabDataFromRow(2) = "warn")
                        nbWarning+=1
                    ElseIf tabDataFromRow(2) = "alert"
                        nbAlert +=1
                        else
                        nbInfo +=1
                    End If

                Next
            End If
        end if
        Me.bindingSource1.DataSource = tableData
        
    End Sub

    Private sub CheckData()

        While (true)

            If (not MainForm.pauseThread or Not stopThread)

                If Me.IsHandleCreated
                    Warning_value.Invoke(Sub() Warning_value.Text = nbWarning)
                    Alert_value.Invoke(Sub() Alert_value.Text = nbAlert)
                    Information_Value.Invoke(Sub()Information_Value.Text = nbInfo)
                End If
                

            End If
            If (stopThread)
                Exit Sub
            End If
            Thread.Sleep(1000)
        End While
    End sub

    Private Sub DGVDashBoard_CellFormatting(ByVal sender As Object,
                                            ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
        Handles DataGridView1.CellFormatting
        if (DataGridView1.Rows(e.RowIndex).Cells(2).Value = "warn")
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
          
        ElseIf (DataGridView1.Rows(e.RowIndex).Cells(2).Value = Alert) Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
       
        else
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White

        End If
    End Sub

    Public sub updateData(stringToAdd As String)
        Dim tabDataFromRow As String()
        If (stringToAdd IsNot Nothing) Then
            tabDataFromRow = stringToAdd.Split(";")
            tableData.Rows.Add(tabDataFromRow(0), tabDataFromRow(1), tabDataFromRow(2), tabDataFromRow(3),
                               tabDataFromRow(4))
            if(tabDataFromRow(2) = "warn")
                nbWarning+=1
            ElseIf tabDataFromRow(2) = "alert"
                nbAlert +=1
            else
                nbInfo +=1
            End If
        end if
        DataGridView1.Invoke(Sub() Me.DataGridView1.FirstDisplayedScrollingRowIndex = Me.DataGridView1.RowCount - 1)
    End sub


    Private Sub LogForm_OnLoad(sender As Object, e As EventArgs) Handles Me.Load
        If MainForm.pauseThread = True Then
            Button1.Text = "Reprendre"
        Else
            Button1.Text = "Pause"
        End If

        Me.dataGridView1.DataSource = Me.bindingSource1
        GetData()
        Dim backGroundThread = new Thread(AddressOf CheckData)
        backGroundThread.Start()
        Me.dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            MainForm.pauseThread = True

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