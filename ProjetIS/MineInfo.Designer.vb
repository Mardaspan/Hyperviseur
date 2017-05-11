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
        Me.label_Title = New System.Windows.Forms.Label()
        Me.label_SH01_title = New System.Windows.Forms.Label()
        Me.label_sh01_temp = New System.Windows.Forms.Label()
        Me.label_sh01_rad = New System.Windows.Forms.Label()
        Me.SH01_temp = New System.Windows.Forms.Label()
        Me.SH01_rad = New System.Windows.Forms.Label()
        Me.label_sh01_hyg = New System.Windows.Forms.Label()
        Me.SH01_hyg = New System.Windows.Forms.Label()
        Me.label_sh01_bat = New System.Windows.Forms.Label()
        Me.SH01_bat = New System.Windows.Forms.Label()
        Me.SH02_bat = New System.Windows.Forms.Label()
        Me.label_sh02_bat = New System.Windows.Forms.Label()
        Me.SH02_hyg = New System.Windows.Forms.Label()
        Me.label_sh02_hyg = New System.Windows.Forms.Label()
        Me.SH02_rad = New System.Windows.Forms.Label()
        Me.SH02_temp = New System.Windows.Forms.Label()
        Me.label_sh02_rad = New System.Windows.Forms.Label()
        Me.label_sh02_temp = New System.Windows.Forms.Label()
        Me.label_SH02_title = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'label_Title
        '
        Me.label_Title.AutoSize = True
        Me.label_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Title.Location = New System.Drawing.Point(95, 24)
        Me.label_Title.Name = "label_Title"
        Me.label_Title.Size = New System.Drawing.Size(271, 20)
        Me.label_Title.TabIndex = 1
        Me.label_Title.Text = "Informations sur l'environnement"
        '
        'label_SH01_title
        '
        Me.label_SH01_title.AutoSize = True
        Me.label_SH01_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SH01_title.Location = New System.Drawing.Point(25, 77)
        Me.label_SH01_title.Name = "label_SH01_title"
        Me.label_SH01_title.Size = New System.Drawing.Size(76, 13)
        Me.label_SH01_title.TabIndex = 2
        Me.label_SH01_title.Text = "Robot SH01"
        '
        'label_sh01_temp
        '
        Me.label_sh01_temp.AutoSize = True
        Me.label_sh01_temp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh01_temp.Location = New System.Drawing.Point(52, 103)
        Me.label_sh01_temp.Name = "label_sh01_temp"
        Me.label_sh01_temp.Size = New System.Drawing.Size(73, 13)
        Me.label_sh01_temp.TabIndex = 3
        Me.label_sh01_temp.Text = "Température :"
        '
        'label_sh01_rad
        '
        Me.label_sh01_rad.AutoSize = True
        Me.label_sh01_rad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh01_rad.Location = New System.Drawing.Point(67, 125)
        Me.label_sh01_rad.Name = "label_sh01_rad"
        Me.label_sh01_rad.Size = New System.Drawing.Size(58, 13)
        Me.label_sh01_rad.TabIndex = 4
        Me.label_sh01_rad.Text = "Radiation :"
        '
        'SH01_temp
        '
        Me.SH01_temp.AutoSize = True
        Me.SH01_temp.Location = New System.Drawing.Point(132, 103)
        Me.SH01_temp.Name = "SH01_temp"
        Me.SH01_temp.Size = New System.Drawing.Size(27, 13)
        Me.SH01_temp.TabIndex = 5
        Me.SH01_temp.Text = "0 °C"
        '
        'SH01_rad
        '
        Me.SH01_rad.AutoSize = True
        Me.SH01_rad.Location = New System.Drawing.Point(132, 125)
        Me.SH01_rad.Name = "SH01_rad"
        Me.SH01_rad.Size = New System.Drawing.Size(49, 13)
        Me.SH01_rad.TabIndex = 6
        Me.SH01_rad.Text = "0 MBq/g"
        '
        'label_sh01_hyg
        '
        Me.label_sh01_hyg.AutoSize = True
        Me.label_sh01_hyg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh01_hyg.Location = New System.Drawing.Point(53, 150)
        Me.label_sh01_hyg.Name = "label_sh01_hyg"
        Me.label_sh01_hyg.Size = New System.Drawing.Size(72, 13)
        Me.label_sh01_hyg.TabIndex = 7
        Me.label_sh01_hyg.Text = "Hygrométrie : "
        '
        'SH01_hyg
        '
        Me.SH01_hyg.AutoSize = True
        Me.SH01_hyg.Location = New System.Drawing.Point(132, 150)
        Me.SH01_hyg.Name = "SH01_hyg"
        Me.SH01_hyg.Size = New System.Drawing.Size(24, 13)
        Me.SH01_hyg.TabIndex = 8
        Me.SH01_hyg.Text = "0 %"
        '
        'label_sh01_bat
        '
        Me.label_sh01_bat.AutoSize = True
        Me.label_sh01_bat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh01_bat.Location = New System.Drawing.Point(26, 173)
        Me.label_sh01_bat.Name = "label_sh01_bat"
        Me.label_sh01_bat.Size = New System.Drawing.Size(99, 13)
        Me.label_sh01_bat.TabIndex = 9
        Me.label_sh01_bat.Text = "Etat de la batterie : "
        '
        'SH01_bat
        '
        Me.SH01_bat.AutoSize = True
        Me.SH01_bat.Location = New System.Drawing.Point(132, 173)
        Me.SH01_bat.Name = "SH01_bat"
        Me.SH01_bat.Size = New System.Drawing.Size(24, 13)
        Me.SH01_bat.TabIndex = 10
        Me.SH01_bat.Text = "0 %"
        '
        'SH02_bat
        '
        Me.SH02_bat.AutoSize = True
        Me.SH02_bat.Location = New System.Drawing.Point(340, 173)
        Me.SH02_bat.Name = "SH02_bat"
        Me.SH02_bat.Size = New System.Drawing.Size(24, 13)
        Me.SH02_bat.TabIndex = 19
        Me.SH02_bat.Text = "0 %"
        '
        'label_sh02_bat
        '
        Me.label_sh02_bat.AutoSize = True
        Me.label_sh02_bat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh02_bat.Location = New System.Drawing.Point(234, 173)
        Me.label_sh02_bat.Name = "label_sh02_bat"
        Me.label_sh02_bat.Size = New System.Drawing.Size(99, 13)
        Me.label_sh02_bat.TabIndex = 18
        Me.label_sh02_bat.Text = "Etat de la batterie : "
        '
        'SH02_hyg
        '
        Me.SH02_hyg.AutoSize = True
        Me.SH02_hyg.Location = New System.Drawing.Point(340, 150)
        Me.SH02_hyg.Name = "SH02_hyg"
        Me.SH02_hyg.Size = New System.Drawing.Size(24, 13)
        Me.SH02_hyg.TabIndex = 17
        Me.SH02_hyg.Text = "0 %"
        '
        'label_sh02_hyg
        '
        Me.label_sh02_hyg.AutoSize = True
        Me.label_sh02_hyg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh02_hyg.Location = New System.Drawing.Point(261, 150)
        Me.label_sh02_hyg.Name = "label_sh02_hyg"
        Me.label_sh02_hyg.Size = New System.Drawing.Size(72, 13)
        Me.label_sh02_hyg.TabIndex = 16
        Me.label_sh02_hyg.Text = "Hygrométrie : "
        '
        'SH02_rad
        '
        Me.SH02_rad.AutoSize = True
        Me.SH02_rad.Location = New System.Drawing.Point(340, 125)
        Me.SH02_rad.Name = "SH02_rad"
        Me.SH02_rad.Size = New System.Drawing.Size(49, 13)
        Me.SH02_rad.TabIndex = 15
        Me.SH02_rad.Text = "0 MBq/g"
        '
        'SH02_temp
        '
        Me.SH02_temp.AutoSize = True
        Me.SH02_temp.Location = New System.Drawing.Point(340, 103)
        Me.SH02_temp.Name = "SH02_temp"
        Me.SH02_temp.Size = New System.Drawing.Size(27, 13)
        Me.SH02_temp.TabIndex = 14
        Me.SH02_temp.Text = "0 °C"
        '
        'label_sh02_rad
        '
        Me.label_sh02_rad.AutoSize = True
        Me.label_sh02_rad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh02_rad.Location = New System.Drawing.Point(275, 125)
        Me.label_sh02_rad.Name = "label_sh02_rad"
        Me.label_sh02_rad.Size = New System.Drawing.Size(58, 13)
        Me.label_sh02_rad.TabIndex = 13
        Me.label_sh02_rad.Text = "Radiation :"
        '
        'label_sh02_temp
        '
        Me.label_sh02_temp.AutoSize = True
        Me.label_sh02_temp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_sh02_temp.Location = New System.Drawing.Point(260, 103)
        Me.label_sh02_temp.Name = "label_sh02_temp"
        Me.label_sh02_temp.Size = New System.Drawing.Size(73, 13)
        Me.label_sh02_temp.TabIndex = 12
        Me.label_sh02_temp.Text = "Température :"
        '
        'label_SH02_title
        '
        Me.label_SH02_title.AutoSize = True
        Me.label_SH02_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SH02_title.Location = New System.Drawing.Point(233, 77)
        Me.label_SH02_title.Name = "label_SH02_title"
        Me.label_SH02_title.Size = New System.Drawing.Size(76, 13)
        Me.label_SH02_title.TabIndex = 11
        Me.label_SH02_title.Text = "Robot SH02"
        '
        'MineInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 396)
        Me.Controls.Add(Me.SH02_bat)
        Me.Controls.Add(Me.label_sh02_bat)
        Me.Controls.Add(Me.SH02_hyg)
        Me.Controls.Add(Me.label_sh02_hyg)
        Me.Controls.Add(Me.SH02_rad)
        Me.Controls.Add(Me.SH02_temp)
        Me.Controls.Add(Me.label_sh02_rad)
        Me.Controls.Add(Me.label_sh02_temp)
        Me.Controls.Add(Me.label_SH02_title)
        Me.Controls.Add(Me.SH01_bat)
        Me.Controls.Add(Me.label_sh01_bat)
        Me.Controls.Add(Me.SH01_hyg)
        Me.Controls.Add(Me.label_sh01_hyg)
        Me.Controls.Add(Me.SH01_rad)
        Me.Controls.Add(Me.SH01_temp)
        Me.Controls.Add(Me.label_sh01_rad)
        Me.Controls.Add(Me.label_sh01_temp)
        Me.Controls.Add(Me.label_SH01_title)
        Me.Controls.Add(Me.label_Title)
        Me.Name = "MineInfo"
        Me.Text = "Informations sur l'environnement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents label_Title As Label
    Friend WithEvents label_SH01_title As Label
    Friend WithEvents label_sh01_temp As Label
    Friend WithEvents label_sh01_rad As Label
    Friend WithEvents SH01_temp As Label
    Friend WithEvents SH01_rad As Label
    Friend WithEvents label_sh01_hyg As Label
    Friend WithEvents SH01_hyg As Label
    Friend WithEvents label_sh01_bat As Label
    Friend WithEvents SH01_bat As Label
    Friend WithEvents SH02_bat As Label
    Friend WithEvents label_sh02_bat As Label
    Friend WithEvents SH02_hyg As Label
    Friend WithEvents label_sh02_hyg As Label
    Friend WithEvents SH02_rad As Label
    Friend WithEvents SH02_temp As Label
    Friend WithEvents label_sh02_rad As Label
    Friend WithEvents label_sh02_temp As Label
    Friend WithEvents label_SH02_title As Label
End Class
