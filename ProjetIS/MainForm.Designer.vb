<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Log_btn = New System.Windows.Forms.Button()
        Me.Btn_env = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Log_btn
        '
        Me.Log_btn.Location = New System.Drawing.Point(242, 120)
        Me.Log_btn.Name = "Log_btn"
        Me.Log_btn.Size = New System.Drawing.Size(75, 23)
        Me.Log_btn.TabIndex = 0
        Me.Log_btn.Text = "Rapports"
        Me.Log_btn.UseVisualStyleBackColor = True
        '
        'Btn_env
        '
        Me.Btn_env.Location = New System.Drawing.Point(378, 120)
        Me.Btn_env.Name = "Btn_env"
        Me.Btn_env.Size = New System.Drawing.Size(88, 23)
        Me.Btn_env.TabIndex = 3
        Me.Btn_env.Text = "Environnement"
        Me.Btn_env.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 681)
        Me.Controls.Add(Me.Btn_env)
        Me.Controls.Add(Me.Log_btn)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Log_btn As Button
    Friend WithEvents Btn_env As Button
End Class
