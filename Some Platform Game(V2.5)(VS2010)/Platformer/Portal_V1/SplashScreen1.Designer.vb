<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label
        Me.guy = New System.Windows.Forms.PictureBox
        Me.guy2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.spikes1Lvl2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.turret4VertLvl4 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.keyLvl6 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.doorlvl1 = New System.Windows.Forms.PictureBox
        CType(Me.guy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.guy2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spikes1Lvl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.turret4VertLvl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.keyLvl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.doorlvl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrLoad
        '
        Me.tmrLoad.Enabled = True
        Me.tmrLoad.Interval = 50
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(105, 45)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(301, 30)
        Me.lblTitle.TabIndex = 95
        Me.lblTitle.Text = "Some Platform Game"
        '
        'guy
        '
        Me.guy.BackColor = System.Drawing.Color.Black
        Me.guy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.guy.Image = Global.Platfomer.My.Resources.Resources.RunLeftFixed
        Me.guy.Location = New System.Drawing.Point(291, 144)
        Me.guy.Name = "guy"
        Me.guy.Size = New System.Drawing.Size(20, 35)
        Me.guy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.guy.TabIndex = 96
        Me.guy.TabStop = False
        Me.guy.Tag = ""
        '
        'guy2
        '
        Me.guy2.BackColor = System.Drawing.Color.Black
        Me.guy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.guy2.Image = Global.Platfomer.My.Resources.Resources.RunRightFixed
        Me.guy2.Location = New System.Drawing.Point(195, 144)
        Me.guy2.Name = "guy2"
        Me.guy2.Size = New System.Drawing.Size(20, 35)
        Me.guy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.guy2.TabIndex = 97
        Me.guy2.TabStop = False
        Me.guy2.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 17)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "A Joey Gelpi Production"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(143, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 17)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Click Anywhere to Start"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.Platfomer.My.Resources.Resources.Still01
        Me.PictureBox1.Location = New System.Drawing.Point(242, 144)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = ""
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = Global.Platfomer.My.Resources.Resources.JumpLeft
        Me.PictureBox2.Location = New System.Drawing.Point(448, 117)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 101
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = ""
        '
        'spikes1Lvl2
        '
        Me.spikes1Lvl2.Image = Global.Platfomer.My.Resources.Resources.Spike2
        Me.spikes1Lvl2.Location = New System.Drawing.Point(415, 146)
        Me.spikes1Lvl2.Name = "spikes1Lvl2"
        Me.spikes1Lvl2.Size = New System.Drawing.Size(27, 15)
        Me.spikes1Lvl2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.spikes1Lvl2.TabIndex = 102
        Me.spikes1Lvl2.TabStop = False
        Me.spikes1Lvl2.Tag = "spike"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Black
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Image = Global.Platfomer.My.Resources.Resources.FallRight
        Me.PictureBox3.Location = New System.Drawing.Point(26, 145)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 103
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Tag = ""
        '
        'turret4VertLvl4
        '
        Me.turret4VertLvl4.BackColor = System.Drawing.Color.Blue
        Me.turret4VertLvl4.Image = Global.Platfomer.My.Resources.Resources.TurretVert
        Me.turret4VertLvl4.Location = New System.Drawing.Point(23, 23)
        Me.turret4VertLvl4.Name = "turret4VertLvl4"
        Me.turret4VertLvl4.Size = New System.Drawing.Size(30, 52)
        Me.turret4VertLvl4.TabIndex = 104
        Me.turret4VertLvl4.TabStop = False
        Me.turret4VertLvl4.Tag = "45V"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Black
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Image = Global.Platfomer.My.Resources.Resources.BulletVert2
        Me.PictureBox4.Location = New System.Drawing.Point(27, 90)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 35)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 105
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Tag = ""
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Black
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Image = Global.Platfomer.My.Resources.Resources.FallLeft
        Me.PictureBox5.Location = New System.Drawing.Point(415, 230)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 35)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 106
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Tag = ""
        '
        'keyLvl6
        '
        Me.keyLvl6.BackColor = System.Drawing.Color.White
        Me.keyLvl6.Image = Global.Platfomer.My.Resources.Resources.Key1_17by36_
        Me.keyLvl6.Location = New System.Drawing.Point(94, 207)
        Me.keyLvl6.Name = "keyLvl6"
        Me.keyLvl6.Size = New System.Drawing.Size(13, 27)
        Me.keyLvl6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.keyLvl6.TabIndex = 108
        Me.keyLvl6.TabStop = False
        Me.keyLvl6.Tag = "key"
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Black
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox6.Image = Global.Platfomer.My.Resources.Resources.JumpRight
        Me.PictureBox6.Location = New System.Drawing.Point(68, 230)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 35)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 109
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Tag = ""
        '
        'doorlvl1
        '
        Me.doorlvl1.BackColor = System.Drawing.Color.SaddleBrown
        Me.doorlvl1.Image = Global.Platfomer.My.Resources.Resources.door1_40by50_
        Me.doorlvl1.Location = New System.Drawing.Point(367, 249)
        Me.doorlvl1.Name = "doorlvl1"
        Me.doorlvl1.Size = New System.Drawing.Size(40, 50)
        Me.doorlvl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.doorlvl1.TabIndex = 110
        Me.doorlvl1.TabStop = False
        Me.doorlvl1.Tag = "door"
        '
        'SplashScreen1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.doorlvl1)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.keyLvl6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.turret4VertLvl4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.spikes1Lvl2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.guy2)
        Me.Controls.Add(Me.guy)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.guy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.guy2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spikes1Lvl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.turret4VertLvl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.keyLvl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.doorlvl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrLoad As System.Windows.Forms.Timer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents guy As System.Windows.Forms.PictureBox
    Friend WithEvents guy2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents spikes1Lvl2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents turret4VertLvl4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents keyLvl6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents doorlvl1 As System.Windows.Forms.PictureBox

End Class
