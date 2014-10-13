<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCannonBall
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.coverUp = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.cannon = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.horizonLine = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.btnFire = New System.Windows.Forms.Button
        Me.tmrMove = New System.Windows.Forms.Timer(Me.components)
        Me.txtVelocity = New System.Windows.Forms.TextBox
        Me.ulblVelo = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.lblDistance = New System.Windows.Forms.Label
        Me.lblTargetDist = New System.Windows.Forms.Label
        Me.ulblLevel = New System.Windows.Forms.Label
        Me.lblLevel = New System.Windows.Forms.Label
        Me.ulblShots = New System.Windows.Forms.Label
        Me.lblShotsLeft = New System.Windows.Forms.Label
        Me.ball = New System.Windows.Forms.PictureBox
        Me.picTarget = New System.Windows.Forms.PictureBox
        CType(Me.ball, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.LineShape1, Me.coverUp, Me.cannon, Me.horizonLine})
        Me.ShapeContainer1.Size = New System.Drawing.Size(692, 503)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(405, 237)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(72, 82)
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = -4
        Me.LineShape1.X2 = 59
        Me.LineShape1.Y1 = 392
        Me.LineShape1.Y2 = 392
        '
        'coverUp
        '
        Me.coverUp.BackColor = System.Drawing.Color.White
        Me.coverUp.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.coverUp.Enabled = False
        Me.coverUp.FillColor = System.Drawing.Color.White
        Me.coverUp.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.coverUp.Location = New System.Drawing.Point(-3, 393)
        Me.coverUp.Name = "coverUp"
        Me.coverUp.Size = New System.Drawing.Size(700, 112)
        '
        'cannon
        '
        Me.cannon.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.cannon.BorderWidth = 30
        Me.cannon.Enabled = False
        Me.cannon.Name = "cannon"
        Me.cannon.X1 = 13
        Me.cannon.X2 = 69
        Me.cannon.Y1 = 391
        Me.cannon.Y2 = 309
        '
        'horizonLine
        '
        Me.horizonLine.Enabled = False
        Me.horizonLine.Name = "horizonLine"
        Me.horizonLine.X1 = -4
        Me.horizonLine.X2 = 2996
        Me.horizonLine.Y1 = 252
        Me.horizonLine.Y2 = 252
        '
        'btnFire
        '
        Me.btnFire.BackColor = System.Drawing.Color.White
        Me.btnFire.Location = New System.Drawing.Point(336, 424)
        Me.btnFire.Name = "btnFire"
        Me.btnFire.Size = New System.Drawing.Size(97, 33)
        Me.btnFire.TabIndex = 1
        Me.btnFire.Text = "Fire"
        Me.btnFire.UseVisualStyleBackColor = False
        '
        'tmrMove
        '
        Me.tmrMove.Interval = 50
        '
        'txtVelocity
        '
        Me.txtVelocity.Location = New System.Drawing.Point(205, 430)
        Me.txtVelocity.Name = "txtVelocity"
        Me.txtVelocity.Size = New System.Drawing.Size(100, 20)
        Me.txtVelocity.TabIndex = 2
        Me.txtVelocity.Text = "300"
        '
        'ulblVelo
        '
        Me.ulblVelo.AutoSize = True
        Me.ulblVelo.BackColor = System.Drawing.Color.White
        Me.ulblVelo.Location = New System.Drawing.Point(152, 433)
        Me.ulblVelo.Name = "ulblVelo"
        Me.ulblVelo.Size = New System.Drawing.Size(47, 13)
        Me.ulblVelo.TabIndex = 4
        Me.ulblVelo.Text = "Velocity:"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.White
        Me.btnReset.Location = New System.Drawing.Point(518, 423)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(73, 33)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'lblDistance
        '
        Me.lblDistance.AutoSize = True
        Me.lblDistance.BackColor = System.Drawing.Color.Black
        Me.lblDistance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDistance.Location = New System.Drawing.Point(99, 217)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(13, 13)
        Me.lblDistance.TabIndex = 6
        Me.lblDistance.Text = "0"
        Me.lblDistance.Visible = False
        '
        'lblTargetDist
        '
        Me.lblTargetDist.AutoSize = True
        Me.lblTargetDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetDist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTargetDist.Location = New System.Drawing.Point(639, 24)
        Me.lblTargetDist.Name = "lblTargetDist"
        Me.lblTargetDist.Size = New System.Drawing.Size(15, 16)
        Me.lblTargetDist.TabIndex = 8
        Me.lblTargetDist.Text = "0"
        '
        'ulblLevel
        '
        Me.ulblLevel.AutoSize = True
        Me.ulblLevel.BackColor = System.Drawing.Color.White
        Me.ulblLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ulblLevel.Location = New System.Drawing.Point(3, 412)
        Me.ulblLevel.Name = "ulblLevel"
        Me.ulblLevel.Size = New System.Drawing.Size(36, 13)
        Me.ulblLevel.TabIndex = 9
        Me.ulblLevel.Text = "Level:"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.BackColor = System.Drawing.Color.White
        Me.lblLevel.Location = New System.Drawing.Point(45, 412)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(13, 13)
        Me.lblLevel.TabIndex = 10
        Me.lblLevel.Text = "1"
        '
        'ulblShots
        '
        Me.ulblShots.AutoSize = True
        Me.ulblShots.BackColor = System.Drawing.Color.White
        Me.ulblShots.Location = New System.Drawing.Point(3, 433)
        Me.ulblShots.Name = "ulblShots"
        Me.ulblShots.Size = New System.Drawing.Size(37, 13)
        Me.ulblShots.TabIndex = 11
        Me.ulblShots.Text = "Shots:"
        '
        'lblShotsLeft
        '
        Me.lblShotsLeft.AutoSize = True
        Me.lblShotsLeft.BackColor = System.Drawing.Color.White
        Me.lblShotsLeft.Location = New System.Drawing.Point(46, 434)
        Me.lblShotsLeft.Name = "lblShotsLeft"
        Me.lblShotsLeft.Size = New System.Drawing.Size(13, 13)
        Me.lblShotsLeft.TabIndex = 12
        Me.lblShotsLeft.Text = "5"
        '
        'ball
        '
        Me.ball.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ball.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ball.Enabled = False
        Me.ball.Image = Global.WindowsApplication1.My.Resources.Resources.Ball2
        Me.ball.Location = New System.Drawing.Point(181, 199)
        Me.ball.Name = "ball"
        Me.ball.Size = New System.Drawing.Size(26, 26)
        Me.ball.TabIndex = 7
        Me.ball.TabStop = False
        Me.ball.Visible = False
        '
        'picTarget
        '
        Me.picTarget.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.picTarget.Location = New System.Drawing.Point(1300, 224)
        Me.picTarget.Name = "picTarget"
        Me.picTarget.Size = New System.Drawing.Size(32, 31)
        Me.picTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTarget.TabIndex = 3
        Me.picTarget.TabStop = False
        Me.picTarget.Tag = "Target"
        '
        'frmCannonBall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(692, 503)
        Me.Controls.Add(Me.lblShotsLeft)
        Me.Controls.Add(Me.ulblShots)
        Me.Controls.Add(Me.lblLevel)
        Me.Controls.Add(Me.ulblLevel)
        Me.Controls.Add(Me.lblTargetDist)
        Me.Controls.Add(Me.ball)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.ulblVelo)
        Me.Controls.Add(Me.picTarget)
        Me.Controls.Add(Me.txtVelocity)
        Me.Controls.Add(Me.btnFire)
        Me.Controls.Add(Me.lblDistance)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.DoubleBuffered = True
        Me.Name = "frmCannonBall"
        Me.Text = "Cannon Ball"
        CType(Me.ball, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents horizonLine As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents cannon As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents btnFire As System.Windows.Forms.Button
    Friend WithEvents tmrMove As System.Windows.Forms.Timer
    Friend WithEvents txtVelocity As System.Windows.Forms.TextBox
    Friend WithEvents picTarget As System.Windows.Forms.PictureBox
    Friend WithEvents ulblVelo As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents coverUp As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ball As System.Windows.Forms.PictureBox
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblTargetDist As System.Windows.Forms.Label
    Friend WithEvents ulblLevel As System.Windows.Forms.Label
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents ulblShots As System.Windows.Forms.Label
    Friend WithEvents lblShotsLeft As System.Windows.Forms.Label

End Class
