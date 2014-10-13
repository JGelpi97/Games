Public Class frmCannonBall
    Dim wheelSpins As Decimal
    Dim horizVeloc As Decimal
    Dim vertVeloc As Decimal
    Dim tP As Decimal
    Dim initXofBall As Decimal
    Dim initYofBall As Decimal
    Dim theta As Decimal
    Dim cannonIsCLicked As Boolean = False
    Dim distance As Integer = 0
    Dim lastDisdance As Integer = 0 'place holder to campare for Thing spacing
    Dim lastCannonX As Integer 'To move cannon back
    Dim targetDist As Integer
    Dim level As Integer = 1
    Dim shotsLeft As Integer = 5

    Private Sub btnFire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFire.Click
        shotsLeft -= 1
        lblShotsLeft.Text = shotsLeft
        lastCannonX = cannon.X2
        lblDistance.Visible = True
        ball.Visible = True
        Dim velocity As Decimal = (txtVelocity.Text)
        tP = 0 'Reset
        'Set ball at proper position to fire
        ball.Top = cannon.Y2 - ball.Height / 2
        initYofBall = ball.Top
        ball.Left = cannon.X2 - ball.Width / 2
        initXofBall = ball.Left
        'Calculate stuffs
        theta = Math.Atan(Math.Abs(cannon.Y1 - cannon.Y2) / Math.Abs(cannon.X1 - cannon.X2))
        horizVeloc = velocity * Math.Cos(theta)
        vertVeloc = velocity * Math.Sin(theta)
        tmrMove.Enabled = True
    End Sub

    Private Sub collision()
        Dim bT As Integer = ball.Top
        Dim bB As Integer = ball.Top + ball.Height
        Dim bL As Integer = ball.Left
        Dim bR As Integer = ball.Left + ball.Width
        Dim tT As Integer = picTarget.Top
        Dim tB As Integer = picTarget.Top + picTarget.Height
        Dim tL As Integer = picTarget.Left
        Dim tR As Integer = picTarget.Left + ball.Width
        If (bB >= tT And bT <= tB) And (bR >= tL And bL <= tR) Then
            tmrMove.Enabled = False
            ball.SendToBack()
            If level = 5 Then
                MsgBox("You Win!", MsgBoxStyle.Exclamation, "Hey!")
                level = 1
                lblLevel.Text = level
                shotsLeft = 5
                lblShotsLeft.Text = shotsLeft
            Else
                level = level + 1
                lblLevel.Text = level
                shotsLeft = 5
                lblShotsLeft.Text = shotsLeft
            End If
        End If
    End Sub

    Private Sub tmrMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMove.Tick
        If targetDist >= 0 Then
            targetDist = picTarget.Left - ball.Left
            lblTargetDist.Text = CStr(targetDist) + "  -->"
        Else
            targetDist = picTarget.Left - ball.Left
            lblTargetDist.Text = "<--  " + CStr(Math.Abs(targetDist))
        End If
        'Distance
        distance = distance + (horizVeloc / 20)
        lblDistance.Text = distance
        'Make some Things somehow
        If distance > 400 Then
            Dim randomThing As String = CStr(Int(Rnd() * 300))
            If distance - lastDisdance >= 75 Then
                For Each Control In Me.Controls
                    If Control.tag = randomThing Then
                        Control.tag = "Move"
                    End If
                Next
                lastDisdance = distance
            End If
        End If

        tP = tP + 0.05 'time passed
        Dim horizPos As Decimal = horizVeloc * tP + initXofBall
        Dim vertPos As Decimal = 0.5 * 300 * tP * tP - vertVeloc * tP + initYofBall

        ball.Top = vertPos
        lblDistance.Top = ball.Top - lblDistance.Height
        lblDistance.Left = ball.Left

        If ball.Left <= 400 Then 'When below 400 keep moving right
            ball.Left = horizPos
            lblDistance.Top = ball.Top - lblDistance.Height
            lblDistance.Left = ball.Left
        Else        'Target left
            For Each Control In Me.Controls
                If Control.tag = "Move" Then
                    Control.Left = Control.Left - horizVeloc * 0.05
                    If Control.left < -20 Then
                        Control.dispose()
                    End If
                End If
            Next
            picTarget.Left = picTarget.Left - horizVeloc * 0.05
            'Cannon left
            cannon.X1 = cannon.X1 - horizVeloc * 0.05
            cannon.X2 = cannon.X2 - horizVeloc * 0.05
        End If
        collision() 'Check after move

        'Stop Ball on Ground, move label
        'Check for loss
        If ball.Top + ball.Height > 391 Then
            tmrMove.Enabled = False
            ball.Top = 391 - ball.Height
            lblDistance.Top = ball.Top - lblDistance.Height
            If shotsLeft = 0 Then
                MsgBox("Game Over", MsgBoxStyle.Exclamation, "Hey!")
                level = 1
                shotsLeft = 5
                lblLevel.Text = level
                lblShotsLeft.Text = shotsLeft
            End If
        End If
    End Sub

    Private Sub frmCannonBall_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picTarget.Left = 1300
        picTarget.Top = 224
        lblTargetDist.Text = CStr(picTarget.Left) + " -->"
        lblTargetDist.Top = picTarget.Top + 5
        wheelSpins = 3600 'txtVelocity.Text
        ball.Top = cannon.Y2 - ball.Height / 2
        ball.Left = cannon.X2 - ball.Width / 2
        makeThings()
        targetDist = picTarget.Left
    End Sub

    Private Sub frmCannonBall_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        wheelSpins = wheelSpins + e.Delta
        txtVelocity.Text = wheelSpins \ 12
    End Sub 'Velocity

    Private Sub frmCannonBall_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim xMouse As Integer = e.X
        Dim yMouse As Integer = e.Y
        If cannonIsCLicked Then
            theta = Math.Atan(Math.Abs(cannon.Y1 - yMouse) / Math.Abs(cannon.X1 - xMouse))
            Dim Hyp As Integer = 100
            Dim O As Integer = Math.Sin(theta) * Hyp
            cannon.Y2 = cannon.Y1 - O
            Dim A As Integer = Math.Cos(theta) * Hyp
            cannon.X2 = cannon.X1 + A
        End If
    End Sub 'Move Cannon when mouse is down

    Private Sub frmCannonBall_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Dim xMouse As Integer = e.X
        Dim yMouse As Integer = e.Y
        If ((xMouse >= cannon.X2 - 15) And (xMouse <= cannon.X2 + 15) And (yMouse <= cannon.Y2 + 15) And (yMouse >= cannon.Y2 - 15)) Then
            cannonIsCLicked = True
        End If
    End Sub 'Move Cannon

    Private Sub frmCannonBall_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        cannonIsCLicked = False
    End Sub 'Move Cannon

    Private Sub makeThings()
        For i = 1 To 400
            Dim randomSize As Integer = Int(Rnd() * 4)
            Dim Thing As New PictureBox
            With Thing
                Dim top As Integer = Int(Rnd() * 350)
                If randomSize = 0 Then
                    .Height = 5
                    .Width = 5
                ElseIf randomSize = 1 Then
                    .Height = 10
                    .Width = 10
                ElseIf randomSize = 2 Then
                    .Height = 20
                    .Width = 20
                ElseIf randomSize = 3 Then
                    .Height = 30
                    .Width = 30
                End If
                .Name = "Thing"
                .BackgroundImageLayout = ImageLayout.Stretch
                .Enabled = False
                .BackColor = Color.White
                .Left = 705
                .Top = top
                .Tag = CStr(i)
                Me.Controls.Add(Thing)
                .BringToFront()
            End With
        Next
    End Sub 'Make Things?

    Private Sub reTagThings()
        Dim i As Integer = 0
        For Each Control In Me.Controls
            If Control.Name = "Thing" Then
                i += 1
                Control.Tag = CStr(i)
            End If
        Next
    End Sub

    Private Sub randomTarget()
        If level = 2 Then
            picTarget.Left = 1600
        ElseIf level = 1 Then
            picTarget.Left = 1300
        ElseIf level = 3 Then
            picTarget.Left = 2100
        ElseIf level = 4 Then
            picTarget.Left = 2300
        ElseIf level = 5 Then
            picTarget.Left = 2500
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ball.BringToFront()
        randomTarget()
        reTagThings()
        For i = 1 To 2
            For Each Control In Me.Controls
                If Control.Name = "Thing" Then
                    Control.left = 705
                End If
            Next
        Next
        cannon.X1 = 13
        cannon.X2 = lastCannonX
        lblDistance.Text = 0
        distance = 0
        lblTargetDist.Text = CStr(picTarget.Left) + " -->"
        lblTargetDist.Top = picTarget.Top + 5
        ball.Visible = False
        lblDistance.Visible = False
        lastDisdance = 0
    End Sub
End Class
