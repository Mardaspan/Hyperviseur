<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MineInfo
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Title = New System.Windows.Forms.Label()
        Me.SH01_title = New System.Windows.Forms.Label()
        Me.sh01_temp_label = New System.Windows.Forms.Label()
        Me.sh01_rad_label = New System.Windows.Forms.Label()
        Me.sh01_temp = New System.Windows.Forms.Label()
        Me.sh01_rad = New System.Windows.Forms.Label()
        Me.sh01_hyg_label = New System.Windows.Forms.Label()
        Me.sh01_hyg = New System.Windows.Forms.Label()
        Me.sh01_bat_label = New System.Windows.Forms.Label()
        Me.sh01_bat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(95, 24)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(271, 20)
        Me.Title.TabIndex = 1
        Me.Title.Text = "Informations sur l'environnement"
        '
        'SH01_title
        '
        Me.SH01_title.AutoSize = True
        Me.SH01_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SH01_title.Location = New System.Drawing.Point(25, 77)
        Me.SH01_title.Name = "SH01_title"
        Me.SH01_title.Size = New System.Drawing.Size(76, 13)
        Me.SH01_title.TabIndex = 2
        Me.SH01_title.Text = "Robot SH01"
        '
        'sh01_temp_label
        '
        Me.sh01_temp_label.AutoSize = True
        Me.sh01_temp_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sh01_temp_label.Location = New System.Drawing.Point(52, 103)
        Me.sh01_temp_label.Name = "sh01_temp_label"
        Me.sh01_temp_label.Size = New System.Drawing.Size(73, 13)
        Me.sh01_temp_label.TabIndex = 3
        Me.sh01_temp_label.Text = "Température :"
        '
        'sh01_rad_label
        '
        Me.sh01_rad_label.AutoSize = True
        Me.sh01_rad_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sh01_rad_label.Location = New System.Drawing.Point(67, 125)
        Me.sh01_rad_label.Name = "sh01_rad_label"
        Me.sh01_rad_label.Size = New System.Drawing.Size(58, 13)
        Me.sh01_rad_label.TabIndex = 4
        Me.sh01_rad_label.Text = "Radiation :"
        '
        'sh01_temp
        '
        Me.sh01_temp.AutoSize = True
        Me.sh01_temp.Location = New System.Drawing.Point(132, 103)
        Me.sh01_temp.Name = "sh01_temp"
        Me.sh01_temp.Size = New System.Drawing.Size(27, 13)
        Me.sh01_temp.TabIndex = 5
        Me.sh01_temp.Text = "0 °C"
        '
        'sh01_rad
        '
        Me.sh01_rad.AutoSize = True
        Me.sh01_rad.Location = New System.Drawing.Point(132, 125)
        Me.sh01_rad.Name = "sh01_rad"
        Me.sh01_rad.Size = New System.Drawing.Size(49, 13)
        Me.sh01_rad.TabIndex = 6
        Me.sh01_rad.Text = "0 MBq/g"
        '
        'sh01_hyg_label
        '
        Me.sh01_hyg_label.AutoSize = True
        Me.sh01_hyg_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sh01_hyg_label.Location = New System.Drawing.Point(53, 150)
        Me.sh01_hyg_label.Name = "sh01_hyg_label"
        Me.sh01_hyg_label.Size = New System.Drawing.Size(72, 13)
        Me.sh01_hyg_label.TabIndex = 7
        Me.sh01_hyg_label.Text = "Hygrométrie : "
        '
        'sh01_hyg
        '
        Me.sh01_hyg.AutoSize = True
        Me.sh01_hyg.Location = New System.Drawing.Point(132, 150)
        Me.sh01_hyg.Name = "sh01_hyg"
        Me.sh01_hyg.Size = New System.Drawing.Size(24, 13)
        Me.sh01_hyg.TabIndex = 8
        Me.sh01_hyg.Text = "0 %"
        '
        'sh01_bat_label
        '
        Me.sh01_bat_label.AutoSize = True
        Me.sh01_bat_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sh01_bat_label.Location = New System.Drawing.Point(26, 173)
        Me.sh01_bat_label.Name = "sh01_bat_label"
        Me.sh01_bat_label.Size = New System.Drawing.Size(99, 13)
        Me.sh01_bat_label.TabIndex = 9
        Me.sh01_bat_label.Text = "Etat de la batterie : "
        '
        'sh01_bat
        '
        Me.sh01_bat.AutoSize = True
        Me.sh01_bat.Location = New System.Drawing.Point(132, 173)
        Me.sh01_bat.Name = "sh01_bat"
        Me.sh01_bat.Size = New System.Drawing.Size(24, 13)
        Me.sh01_bat.TabIndex = 10
        Me.sh01_bat.Text = "0 %"
        '
        'MineInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 396)
        Me.Controls.Add(Me.sh01_bat)
        Me.Controls.Add(Me.sh01_bat_label)
        Me.Controls.Add(Me.sh01_hyg)
        Me.Controls.Add(Me.sh01_hyg_label)
        Me.Controls.Add(Me.sh01_rad)
        Me.Controls.Add(Me.sh01_temp)
        Me.Controls.Add(Me.sh01_rad_label)
        Me.Controls.Add(Me.sh01_temp_label)
        Me.Controls.Add(Me.SH01_title)
        Me.Controls.Add(Me.Title)
        Me.Name = "MineInfo"
        Me.Text = "Informations sur l'environnement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title As Label
    Friend WithEvents SH01_title As Label
    Friend WithEvents sh01_temp_label As Label
    Friend WithEvents sh01_rad_label As Label
    Friend WithEvents sh01_temp As Label
    Friend WithEvents sh01_rad As Label
    Friend WithEvents sh01_hyg_label As Label
    Friend WithEvents sh01_hyg As Label
    Friend WithEvents sh01_bat_label As Label
    Friend WithEvents sh01_bat As Label
End Class
