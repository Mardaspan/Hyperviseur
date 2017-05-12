Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Module Main
    Public FichierLogRapport As String = My.Application.Info.DirectoryPath & "\fichierLogRapport.txt"
    Public FichierLogCapteurs As String = My.Application.Info.DirectoryPath & "\fichierLogCapteurs.txt"


    Public Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create() ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                    hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            Return Convert.ToBase64String(dbytes)

        End Using
    End Function

    Public Structure UserId
        Dim id As Integer
        Dim username As String
    End Structure

    Public Structure Rapport
        Dim idRapport As Integer
        Dim idUser As Integer
        Dim date_debut As String
        Dim date_fin As String
        Dim texteRapport As String
    End Structure

    Public userInformation As New UserId

    Public Sub Connexion()
        Dim frmConnexion As New Authentification
        frmConnexion.ShowDialog()
        frmConnexion.Dispose()
    End Sub

    Public Function ReadFile(file As String)


        If (IO.File.Exists(file)) Then
            Dim _textStreamReader As StreamReader
            _textStreamReader = New StreamReader(file)
            Dim arrayToReturn As New ArrayList
            While Not _textStreamReader.EndOfStream
                Try
                    arrayToReturn.Add(_textStreamReader.ReadLine())
                Catch ex As Exception
                    MsgBox("Ligne " & ex.Message &
                           "Invalide")
                End Try

            End While
            _textStreamReader.Close()
            Return arrayToReturn
        Else
            Throw New Exception("Fichier non trouvé")
        End If
    End Function

    Public Sub WriteFile(fileName As String, stringToWrite As String)

        Dim _textStreamWriter As StreamWriter
        _textStreamWriter = New StreamWriter(fileName, True)
        _textStreamWriter.WriteLine(stringToWrite)
        _textStreamWriter.Close()
    End Sub

    Public Function GenerateRandomLogRapport() As String
        Dim randomIndex As New Random(DateTime.Now.Millisecond)

        Dim robotName() As String = {"SH01", "SH02", "SH03", "MA01", "MA02", "CL01", "CL02", "CL03", "HA01", "HA02"}
        Dim userName() As String = {"U01", "U02", "U03", "U04", "U05", "U06", "U07", "U08", "U09", "U10", "U11"}
        Dim level() As String = {"warn", "info", "alert"}
        Dim type() As String = {"user", "robot"}
        Dim commentaryInfo() As String = {"OK", "Moule plein", "Mise à jour du logiciel réussie", "Batterie chargée"}
        Dim commentaryWarnUser() As String = {"L'utilisateur {0} s'est connecté", "L'utilisateur {0} s'est déconnecté"}
        Dim commentaryWarnRobot() As String = {"Perte de connexion", "Température moteurs élevée"}
        Dim commentaryAlert() As String = {"Niveau de batterie faible", "Dysfonctionnement inconnue"}
        Dim currentDate = DateTime.Now.ToString("yyyy_MM_dd")
        Dim currentTime = DateTime.Now.ToString("HH:mm:ss")
        Dim stringToReturn As New StringBuilder

        stringToReturn.Append(currentDate & ";")
        stringToReturn.Append(currentTime & ";")

        Select Case level(randomIndex.Next(3))
            Case "warn"

                stringToReturn.Append("warn;")
                If (type(randomIndex.Next(2)) = "user") Then

                    stringToReturn.Append("user:")
                    Dim currentUserName = userName(randomIndex.Next(11))
                    stringToReturn.Append(currentUserName & ";")
                    stringToReturn.Append(String.Format(commentaryWarnUser(randomIndex.Next(2)), currentUserName))
                Else

                    stringToReturn.Append("robot:")
                    stringToReturn.Append(robotName(randomIndex.Next(10)) & ";")
                    stringToReturn.Append(commentaryWarnRobot(randomIndex.Next(1)))
                End If
            Case "info"

                stringToReturn.Append("info;")
                stringToReturn.Append("robot:")
                stringToReturn.Append(robotName(randomIndex.Next(10)) & ";")
                stringToReturn.Append(commentaryInfo(randomIndex.Next(4)))
            Case "alert"

                stringToReturn.Append("alert;")
                stringToReturn.Append("robot:")
                stringToReturn.Append(robotName(randomIndex.Next(10)) & ";")
                stringToReturn.Append(commentaryAlert(randomIndex.Next(2)))

        End Select


        Return stringToReturn.ToString()
    End Function

    Public Function GenerateRandomLogCapteurs() As String
        Dim randomIndex As New Random(DateTime.Now.Millisecond)

        Dim robotName() As String = {"SH01", "SH02", "SH03", "MA01", "MA02", "CL01", "CL02", "CL03", "HA01", "HA02"}
        Dim currentDate = DateTime.Now.ToString("yyyy_MM_dd")
        Dim currentTime = DateTime.Now.ToString("HH:mm:ss")
        Dim stringToReturn As New StringBuilder

        stringToReturn.Append(currentDate & ";")
        stringToReturn.Append(currentTime & ";")
        stringToReturn.Append(robotName(randomIndex.Next(10)) & ";")
        stringToReturn.Append(randomIndex.Next(300,360) & ";")
        stringToReturn.Append(randomIndex.Next(5,52) & ";")
        stringToReturn.Append(randomIndex.Next(0,91) & ";")
        stringToReturn.Append(randomIndex.Next(0,100))

        


        Return stringToReturn.ToString()
    End Function

    Public Function NumFromLabel(ByVal value As String) As Integer
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function
End Module
