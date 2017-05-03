Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Module Main

    Public Const FichierLog As String = ""

    Public Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

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

    Public userInformation As New UserId

    Public Sub Connexion()
        Dim frmConnexion As New Authentification
        frmConnexion.ShowDialog()
        frmConnexion.Dispose()
    End Sub

    Public Function ReadFile()
        Dim _assembly As Assembly
        Dim _textStreamReader As StreamReader
        _assembly = Assembly.GetExecutingAssembly()
        _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("ProjetIS.fichierLogRapport.txt"))
        Dim arrayToReturn As New ArrayList
        While Not _textStreamReader.EndOfStream
            Try
                arrayToReturn.Add(_textStreamReader.ReadLine())
            Catch ex As Exception
                MsgBox("Ligne " & ex.Message &
                       "Invalide")
            End Try

        End While

        Return arrayToReturn

    End Function

    Public Sub WriteFile(ByVal password As String)
        Dim wrapper As New Simple3Des("Ronsard")
        Dim cipher As String = wrapper.EncryptData(password)

        Dim objStreamWriter As StreamWriter
        'Pass the file path and the file name to the StreamReader constructor.
        objStreamWriter = New StreamWriter(FichierLog, True, Encoding.Unicode)
        ' objStreamWriter.WriteLine(UserId & ";" & cipher)
        objStreamWriter.Close()

    End Sub
End Module
