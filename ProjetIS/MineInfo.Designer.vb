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
        Me.SubTitle1 = New System.Windows.Forms.Label()
        Me.r1_temp_label = New System.Windows.Forms.Label()
        Me.r1_rad_label = New System.Windows.Forms.Label()
        Me.r1_temp = New System.Windows.Forms.Label()
        Me.r1_rad = New System.Windows.Forms.Label()
        Me.r1_hyg_label = New System.Windows.Forms.Label()
        Me.r1_hyg = New System.Windows.Forms.Label()
        Me.r1_bat_label = New System.Windows.Forms.Label()
        Me.r1_bat = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
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
        'SubTitle1
        '
        Me.SubTitle1.AutoSize = True
        Me.SubTitle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubTitle1.Location = New System.Drawing.Point(25, 77)
        Me.SubTitle1.Name = "SubTitle1"
        Me.SubTitle1.Size = New System.Drawing.Size(76, 13)
        Me.SubTitle1.TabIndex = 2
        Me.SubTitle1.Text = "Robot SH01"
        '
        'r1_temp_label
        '
        Me.r1_temp_label.AutoSize = True
        Me.r1_temp_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r1_temp_label.Location = New System.Drawing.Point(52, 103)
        Me.r1_temp_label.Name = "r1_temp_label"
        Me.r1_temp_label.Size = New System.Drawing.Size(73, 13)
        Me.r1_temp_label.TabIndex = 3
        Me.r1_temp_label.Text = "Température :"
        '
        'r1_rad_label
        '
        Me.r1_rad_label.AutoSize = True
        Me.r1_rad_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r1_rad_label.Location = New System.Drawing.Point(67, 125)
        Me.r1_rad_label.Name = "r1_rad_label"
        Me.r1_rad_label.Size = New System.Drawing.Size(58, 13)
        Me.r1_rad_label.TabIndex = 4
        Me.r1_rad_label.Text = "Radiation :"
        '
        'r1_temp
        '
        Me.r1_temp.AutoSize = True
        Me.r1_temp.Location = New System.Drawing.Point(132, 103)
        Me.r1_temp.Name = "r1_temp"
        Me.r1_temp.Size = New System.Drawing.Size(27, 13)
        Me.r1_temp.TabIndex = 5
        Me.r1_temp.Text = "0 °C"
        '
        'r1_rad
        '
        Me.r1_rad.AutoSize = True
        Me.r1_rad.Location = New System.Drawing.Point(132, 125)
        Me.r1_rad.Name = "r1_rad"
        Me.r1_rad.Size = New System.Drawing.Size(49, 13)
        Me.r1_rad.TabIndex = 6
        Me.r1_rad.Text = "0 MBq/g"
        '
        'r1_hyg_label
        '
        Me.r1_hyg_label.AutoSize = True
        Me.r1_hyg_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r1_hyg_label.Location = New System.Drawing.Point(53, 150)
        Me.r1_hyg_label.Name = "r1_hyg_label"
        Me.r1_hyg_label.Size = New System.Drawing.Size(72, 13)
        Me.r1_hyg_label.TabIndex = 7
        Me.r1_hyg_label.Text = "Hygrométrie : "
        '
        'r1_hyg
        '
        Me.r1_hyg.AutoSize = True
        Me.r1_hyg.Location = New System.Drawing.Point(132, 150)
        Me.r1_hyg.Name = "r1_hyg"
        Me.r1_hyg.Size = New System.Drawing.Size(24, 13)
        Me.r1_hyg.TabIndex = 8
        Me.r1_hyg.Text = "0 %"
        '
        'r1_bat_label
        '
        Me.r1_bat_label.AutoSize = True
        Me.r1_bat_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r1_bat_label.Location = New System.Drawing.Point(26, 173)
        Me.r1_bat_label.Name = "r1_bat_label"
        Me.r1_bat_label.Size = New System.Drawing.Size(99, 13)
        Me.r1_bat_label.TabIndex = 9
        Me.r1_bat_label.Text = "Etat de la batterie : "
        '
        'r1_bat
        '
        Me.r1_bat.AutoSize = True
        Me.r1_bat.Location = New System.Drawing.Point(132, 173)
        Me.r1_bat.Name = "r1_bat"
        Me.r1_bat.Size = New System.Drawing.Size(24, 13)
        Me.r1_bat.TabIndex = 10
        Me.r1_bat.Text = "0 %"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(294, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MineInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 396)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.r1_bat)
        Me.Controls.Add(Me.r1_bat_label)
        Me.Controls.Add(Me.r1_hyg)
        Me.Controls.Add(Me.r1_hyg_label)
        Me.Controls.Add(Me.r1_rad)
        Me.Controls.Add(Me.r1_temp)
        Me.Controls.Add(Me.r1_rad_label)
        Me.Controls.Add(Me.r1_temp_label)
        Me.Controls.Add(Me.SubTitle1)
        Me.Controls.Add(Me.Title)
        Me.Name = "MineInfo"
        Me.Text = "Informations sur l'environnement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title As Label
    Friend WithEvents SubTitle1 As Label
    Friend WithEvents r1_temp_label As Label
    Friend WithEvents r1_rad_label As Label
    Friend WithEvents r1_temp As Label
    Friend WithEvents r1_rad As Label
    Friend WithEvents r1_hyg_label As Label
    Friend WithEvents r1_hyg As Label
    Friend WithEvents r1_bat_label As Label
    Friend WithEvents r1_bat As Label
    Friend WithEvents Button1 As Button
End Class
