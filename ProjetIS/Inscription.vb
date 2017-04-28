Imports System.Windows.Forms

Public Class Inscription

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim sqlString = "Insert into user values(default,'" + TextBox1.Text + "','" + GetHash(TextBox2.Text) + "')"
            ExecuteQueryMySql(sqlString)
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
