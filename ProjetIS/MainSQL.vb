Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module MainSql

    Public CnMySql As MySqlConnection
    Private Const Cnxstrartemis As String = "SERVER=localhost;UID=root;DATABASE=exdema;PASSWORD=aaaa"
    ' Private Const Cnxstrartemis As String = "SERVER=srv-dwh.ronsard.loc;UID=DataRonsard;DATABASE=ARTEMIS;PASSWORD=01jfrsmm1jp"
    'Private Const CNXSTRARTEMIS As String = "SERVER=localhost;DATABASE=ARTEMIS;UID=XLA;PASSWORD=LAGUES2506"

    Public Sub OuvertureConnectionArtemis()
        CnMySql = New MySqlConnection(Cnxstrartemis)
    End Sub


    Public Function UpdateBddMySql(ByVal table As String, ByVal nbEnreg As Long, ByVal nbChamps As Integer, ByRef champs As Array, ByVal nbPrimary As Integer, ByRef tabValeurs As Array) As Integer
        Dim sql, sqlWhere As String
        Dim I, j As Integer
        Dim cmdSql As MySqlCommand
        Dim reader As MySqlDataReader
        Dim nbUpdate, nbInsert As Long
        Dim result As Integer = 0
        reader = Nothing
        nbUpdate = 0
        nbInsert = 0
        sql = ""

        Using bddcn As New MySqlConnection(Cnxstrartemis)
            Try
                Dim rowsEffected As Integer = 0
                bddcn.Open()
                sqlWhere = ""
                For I = 1 To nbEnreg
                    'Si le tableau des clés primaires n'est pas vide, il faut vérifier si c'est un Insert ou un Update
                    If nbPrimary > 0 Then
                        'Recherche si l'enregistrement existe déjà
                        sql = "Select * FROM " & table & " WHERE "
                        sqlWhere = ""
                        For j = 1 To nbPrimary
                            sqlWhere = sqlWhere & champs(j) & "='" & tabValeurs(I, j) & "' AND "
                        Next j
                        sqlWhere = Left(sqlWhere, Len(sqlWhere) - 5)
                        sql = sql & sqlWhere
                        cmdSql = New MySqlCommand(sql, bddcn)
                        reader = cmdSql.ExecuteReader
                        If reader.HasRows Then
                            sql = "UPDATE "
                        Else
                            sql = "INSERT INTO "
                        End If
                    End If
                    reader.Close()

                    Select Case sql
                        Case "UPDATE "
                            nbUpdate = nbUpdate + 1
                            sql = sql & table & " SET "
                            For j = 1 To nbChamps
                                sql = sql & champs(j) & "='" & tabValeurs(I, j) & "',"
                            Next
                            sql = Left(sql, Len(sql) - 1) & " WHERE " & sqlWhere
                            result = 1
                        Case "INSERT INTO "
                            nbInsert = nbInsert + 1
                            sql = sql & table & " ("
                            For j = 1 To nbChamps
                                sql = sql & champs(j) & ","
                            Next
                            sql = Left(sql, Len(sql) - 1) & ") VALUES("
                            For j = 1 To nbChamps
                                sql = sql & "'" & tabValeurs(I, j) & "',"
                            Next
                            sql = Left(sql, Len(sql) - 1) & ")"
                    End Select
                    cmdSql = New MySqlCommand(sql, bddcn)

                    rowsEffected = cmdSql.ExecuteNonQuery()

                Next I

                Return result
            Catch ex As Exception
                MsgBox(ex.Message & " SQL = " & sql)
                Return 0
            Finally
                If (reader IsNot Nothing) Then
                    reader.Close()
                End If

            End Try
        End Using


    End Function
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
                Dim sqlQuery = "select * from user WHERE username=@Username and password=@UserPw"
                Dim Cmd As New MySqlCommand(sqlQuery, bddcn)

                Cmd.CommandText = sqlQuery
                Cmd.CommandType = CommandType.Text

                Cmd.Parameters.AddWithValue("@Username", login)
                Cmd.Parameters.AddWithValue("@UserPw", password)
                Dim reader As MySqlDataReader = Cmd.ExecuteReader()
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

