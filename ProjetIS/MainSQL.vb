Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module MainSql

    Public CnMySql As MySqlConnection
    Private Const Cnxstrartemis As String = "SERVER=localhost;UID=root;DATABASE=exdema;PASSWORD=500EATHnote"
    ' Private Const Cnxstrartemis As String = "SERVER=srv-dwh.ronsard.loc;UID=DataRonsard;DATABASE=ARTEMIS;PASSWORD=01jfrsmm1jp"
    'Private Const CNXSTRARTEMIS As String = "SERVER=localhost;DATABASE=ARTEMIS;UID=XLA;PASSWORD=LAGUES2506"

    Public Sub OuvertureConnectionArtemis()
        CnMySql = New MySqlConnection(Cnxstrartemis)
    End Sub


    Public Sub ExecuteQueryMySql(ByVal sql As String)
        Dim cmdMySql As MySqlCommand
        Using bddcn As New MySqlConnection(Cnxstrartemis)
            Try
                bddcn.Open()
                cmdMySql = New MySqlCommand(sql, bddcn)
                cmdMySql.ExecuteNonQuery()
                cmdMySql.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message & " SQL = " & sql)
            Finally
            End Try
        End Using

    End Sub

    Public Function QueryForLogin(ByVal login As String, ByVal password As String)
        Using bddcn As New MySqlConnection(Cnxstrartemis)
            Try
                Dim userId As New UserId
                bddcn.Open()
                Const sqlQuery As String = "select * from user WHERE username=@Username and password=@UserPw"
                Dim cmd As New MySqlCommand(sqlQuery, bddcn)

                cmd.CommandText = sqlQuery
                cmd.CommandType = CommandType.Text

                cmd.Parameters.AddWithValue("@Username", login)
                cmd.Parameters.AddWithValue("@UserPw", password)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                reader.Read()
                If reader.HasRows Then
                    userId.id = reader.GetValue(0)
                    userId.username = reader.GetValue(1)
                End If

                Return userId

            Catch ex As Exception
                MsgBox(ex.Message & " SQL = ")
            Finally
            End Try
        End Using

        Return Nothing
    End Function

    Public Function SqlQuery(ByVal sql As String)
        Dim cmdMySql As MySqlCommand
        Dim reader As MySqlDataReader = Nothing
        Using bddcnTest As New MySqlConnection(Cnxstrartemis)
            Try
                bddcnTest.Open()
                cmdMySql = New MySqlCommand(sql, bddcnTest)
                reader = cmdMySql.ExecuteReader
                Dim arrayToReturn As New ArrayList
                While reader.Read()
                    For i As Integer = 0 To 2
                        arrayToReturn.Add(reader.GetValue(i))
                    Next

                End While

                Return arrayToReturn

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -1
            Finally

                If reader IsNot Nothing Then
                    reader.Close()
                End If



            End Try
        End Using

    End Function

    Public Function WeekOfYear(ByVal dateTraitee As Date) As Integer
        Dim week As Double
        Dim weekInt, firstDay As Integer
        Dim firstDayDate As Date

        'Premier jour de l'année
        firstDayDate = DateAdd(DateInterval.Day, -dateTraitee.DayOfYear + 1, dateTraitee)
        firstDay = firstDayDate.DayOfWeek
        week = (dateTraitee.DayOfYear + 5 + firstDay) / 7
        weekInt = Fix(week)
        If firstDay > 4 Then weekInt -= 1
        Return weekInt
    End Function
End Module

