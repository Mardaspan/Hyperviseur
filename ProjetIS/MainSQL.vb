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

    'Public Function ReadBddMySql(ByVal sql As String, ByRef tableDatas As Array, ByVal nbChamps As Integer, ByRef tabChamps As Array) As Integer
    '    Dim nbEnreg, I As Long
    '    Dim cmdMySql As MySqlCommand
    '    Dim reader As MySqlDataReader
    '    Using bddcn As New MySqlConnection(Cnxstrartemis)
    '        Try
    '            bddcn.Open()
    '            cmdMySql = New MySqlCommand(sql, bddcn)
    '            reader = cmdMySql.ExecuteReader
    '            nbEnreg = 0
    '            While reader.Read
    '                nbEnreg = nbEnreg + 1
    '                For I = 0 To nbChamps - 1
    '                    Select Case tabChamps(I + 1, 2)
    '                        Case Mydate
    '                            tableDatas(nbEnreg, I + 1) = reader.GetMySqlDateTime(tabChamps(I + 1, 1))
    '                        Case Mydecimal
    '                            tableDatas(nbEnreg, I + 1) = reader.GetMySqlDecimal(tabChamps(I + 1, 1))
    '                        Case Else
    '                            tableDatas(nbEnreg, I + 1) = reader.GetValue(I)
    '                    End Select
    '                Next
    '            End While
    '            Return nbEnreg
    '        Catch ex As Exception
    '            MsgBox(ex.Message & " SQL = " & sql)
    '            Return -1
    '        Finally
    '            If reader IsNot Nothing Then
    '                reader.Close()
    '            End If
    '        End Try
    '    End Using

    'End Function

    'Public Function ReadBddMySqlDyn(ByVal sql As String, ByRef tableDatasList As ArrayList, ByVal nbChamps As Integer, ByRef tabChamps As Array) As Integer
    '    Dim nbEnreg, I As Long
    '    Dim tableDatas(nbChamps - 1) As Object
    '    Dim cmdMySql As MySqlCommand
    '    Dim reader As MySqlDataReader

    '    Using bddcn As New MySqlConnection(Cnxstrartemis)
    '        Try
    '            bddcn.Open()
    '            cmdMySql = New MySqlCommand(sql, bddcn)
    '            reader = cmdMySql.ExecuteReader
    '            nbEnreg = 0
    '            While reader.Read
    '                nbEnreg = nbEnreg + 1
    '                For I = 0 To nbChamps - 1
    '                    Select Case tabChamps(I + 1, 2)
    '                        Case Mydate
    '                            tableDatas(nbEnreg) = reader.GetMySqlDateTime(tabChamps(I + 1, 1))
    '                        Case Mydecimal
    '                            tableDatas(nbEnreg) = reader.GetMySqlDecimal(tabChamps(I + 1, 1))
    '                        Case Else
    '                            tableDatas(I) = reader.GetValue(I)
    '                    End Select
    '                Next
    '                tableDatasList.Add(tableDatas)
    '                ReDim tableDatas(nbChamps - 1) 'remet le tableau à zero
    '            End While
    '            Return nbEnreg
    '        Catch ex As Exception
    '            MsgBox(ex.Message & " SQL = " & sql)
    '            Return -1
    '        Finally
    '            If reader IsNot Nothing Then
    '                reader.Close()
    '            End If
    '        End Try
    '    End Using

    'End Function

    Public Function SqlQuery(ByVal sql As String)
        Dim cmdMySql As MySqlCommand
        Dim reader As MySqlDataReader
        Using bddcnTest As New MySqlConnection(Cnxstrartemis)
            Try
                bddcnTest.Open()
                cmdMySql = New MySqlCommand(sql, bddcnTest)
                reader = cmdMySql.ExecuteReader
                reader.Read()
                Return reader.GetString(0)

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


    Public Function QueryOnSingleRow(ByVal sql As String, ByVal nbChamps As Integer) As Array
        Dim cmdMySql As MySqlCommand
        Dim reader As MySqlDataReader
        Dim tab(nbChamps - 1) As Object

        Using bddcn As New MySqlConnection(Cnxstrartemis)
            Try
                bddcn.Open()
                cmdMySql = New MySqlCommand(sql, bddcn)
                reader = cmdMySql.ExecuteReader
                reader.Read()
                reader.GetValues(tab)
                If (tab IsNot Nothing) Then
                    Return tab
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                If cmdMySql IsNot Nothing Then
                    cmdMySql.Dispose()
                End If
                If reader IsNot Nothing Then
                    reader.Close()
                End If
                bddcn.Close()
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

    Public Function UpdateBddMySqlIndex(ByVal table As String, ByVal nbEnreg As Long, ByVal nbChamps As Integer, ByRef champs As Array, ByVal nbPrimary As Integer, ByRef tabValeurs As Array) As Integer
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
                For I = 0 To nbEnreg - 1
                    'Si le tableau des clés primaires n'est pas vide, il faut vérifier si c'est un Insert ou un Update
                    If nbPrimary > 0 Then
                        'Recherche si l'enregistrement existe déjà
                        sql = "Select * FROM " & table & " WHERE "
                        sqlWhere = ""
                        For j = 0 To nbPrimary - 1
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
                            For j = 0 To nbChamps - 1
                                sql = sql & champs(j) & "='" & tabValeurs(I, j) & "',"
                            Next
                            sql = Left(sql, Len(sql) - 1) & " WHERE " & sqlWhere
                            result = 1
                        Case "INSERT INTO "
                            nbInsert = nbInsert + 1
                            sql = sql & table & " ("
                            For j = 0 To nbChamps - 1
                                sql = sql & champs(j) & ","
                            Next
                            sql = Left(sql, Len(sql) - 1) & ") VALUES("
                            For j = 0 To nbChamps - 1
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
End Module

