Imports System.Security.Cryptography
Imports System.Text

Module Main


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
End Module
