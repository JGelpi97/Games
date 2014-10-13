Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lblTitle.Click, Label2.Click, Label1.Click, guy2.Click, guy.Click, turret4VertLvl4.Click, spikes1Lvl2.Click, PictureBox6.Click, PictureBox5.Click, PictureBox4.Click, PictureBox3.Click, PictureBox2.Click, PictureBox1.Click, keyLvl6.Click, doorlvl1.Click
        'Hide splash screen and show form
        Me.Hide()
        Form1.Show()
    End Sub


    Private Sub tmrLoad_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLoad.Tick
        'Move title around and keep in bounds
        Dim x As Integer = Int(Rnd() * 4) + 1
        If x = 1 Then
            lblTitle.Top += 1
        ElseIf x = 2 Then
            lblTitle.Top -= 1
        ElseIf x = 3 Then
            lblTitle.Left += 1
        ElseIf x = 4 Then
            lblTitle.Left -= 1
        End If
        If lblTitle.Top <= 42 Then
            lblTitle.Top = 42
        End If
        If lblTitle.Left <= 102 Then
            lblTitle.Left = 102
        End If
        If lblTitle.Left >= 408 Then
            lblTitle.Left = 408
        End If
        If lblTitle.Top >= 78 Then
            lblTitle.Top = 78
        End If
    End Sub
End Class
