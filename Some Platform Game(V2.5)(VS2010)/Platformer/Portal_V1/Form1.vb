<System.Serializable()> Public Class Form1
    'The 'guy' as i will refer to him is the picture box called guy.

    '---------------READ THIS-------------------
    'PLAY THE GAME ENTIRELY THROUGH BEFORE TOUCHING THE FORM DESIGNER(Form1.vb[Design]) SO
    'YOU KNOW WHAT EVERYHTING LOOKS LIKE INCASE YOU MESS SOMETHING UP

    'Everything in the form designer has to stay exactly where it is.
    'If you moved anything you must go back and undo what you did.

    'The levels are set up in panels, each level is a differnt panel, and need to be EXACTLY 
    'where they are on the form. If you move them, things will break, which is why i am including
    'an extra copy of my project.

    'To see the differnt levels on the form designer, right click THE PANEL, NOT A PICTURE
    'BOX OR ANYTHING ELSE(which will break things), and click send to back. You can also send
    'the restart label to the back this way. DO NOT move the restart label, only send to back.
    'You do not need to re arrange the panels to how they were, but everything must stay at
    'the same coordinates.


    Dim walls(0 To 150) As PictureBox 'The walls in every single level
    Dim objects(0 To 150) As PictureBox 'Keys, enemies, doors, ect
    Dim moveDist As Integer = 5
    Dim level, nextPicNum, nextPicNum2, secondCounter, jumpTime, airTime, leftMoveSpeed, rightMoveSpeed, upMoveSpeed, guyTop, guyLeft, lowGravityTime, fireCounter, explosionCounter As Integer
    Dim dead, spiked, exploded, inTheAir, haveKey, movingLeft, movingRight, jumping, lowGravity As Boolean
    Dim allowjump As Boolean = True
    Dim downMoveSpeed As Integer = 4
    Dim lastDirection As String = "R"
    Dim jumpHeight As Integer = 10
    Dim stoppedLeft As Boolean = False
    Dim stoppedRight As Boolean = False

    Private Sub makeArrays()
        'Fill arrays with 'holder' walls and objects
        'This prevents the program from breaking if it checks collision
        'for a wall that doesnt exist in the array
        For i = 0 To 150
            Dim holderWall As New PictureBox
            holderWall.Left = 2000
            holderWall.Tag = "Q"
            walls(i) = holderWall
        Next
        For i = 0 To 150
            Dim holderObject As New PictureBox
            holderObject.Left = 2000
            holderObject.Tag = "Q"
            objects(i) = holderObject
        Next
        'Fill arrays, every object and wall
        '===================Level 1
        objects(0) = keylvl1
        objects(1) = doorlvl1
        objects(2) = Spikes1Lvl1
        objects(3) = gravityLvl1
        '===================Level 2
        objects(21) = keylvl2
        objects(22) = doorlvl2
        objects(23) = spikes1Lvl2
        '===================Level 3
        objects(41) = sentry1Lvl3
        objects(42) = sentry2Lvl3
        objects(43) = doorLvl3
        objects(44) = keyLvl3
        objects(45) = gravityLvl3
        '===================Level 4 / 61 - 80
        objects(61) = doorLvl4
        objects(62) = keyLvl4
        '===================Level 5 / 81 - 100
        objects(81) = KeyLvl5
        objects(82) = doorLvl5
        'Level 6 (101 - 130)
        objects(101) = spike6_1
        objects(102) = spike6_2
        objects(103) = spike6_3
        objects(104) = spike6_4
        objects(105) = tele1Btm
        objects(106) = tele2Btm
        objects(107) = spike6_5
        objects(108) = spike6_6
        objects(109) = tele3Btm
        objects(110) = tele4Btm
        objects(111) = doorLvl6
        objects(112) = keyLvl6
        objects(113) = spike6_7
        objects(114) = spike6_8
        objects(115) = movingS1
        objects(116) = spike6_9
        objects(117) = spike6_10
        objects(118) = spike6_11
        objects(119) = spike6_12
        objects(120) = spike6_13
        objects(121) = movingS2
        '=============== Level 1 / 0-20
        walls(0) = wall0
        walls(1) = wall1
        walls(2) = wall2
        walls(3) = wall3
        walls(4) = wall4
        '=============== Level 2 / 21-40
        walls(21) = wall21
        walls(22) = wall22
        walls(23) = wall23
        walls(24) = wall24
        walls(25) = wall25
        walls(26) = wall26
        walls(27) = wall27
        walls(28) = wall28
        walls(29) = wall29
        walls(30) = wall30
        '=============== Level 3 / 41 - 60
        walls(41) = wall41
        walls(42) = wall42
        walls(43) = wall43
        walls(44) = wall44
        walls(45) = wall45
        walls(46) = wall46
        walls(47) = wall47
        walls(48) = wall48
        walls(49) = wall49
        walls(50) = wall50
        walls(51) = wall51
        walls(52) = wall52
        walls(53) = wall53
        walls(54) = wall54
        walls(55) = wall55
        walls(56) = wall56
        walls(57) = wall57
        walls(58) = wall58
        '============== Level 4 / 61 - 80
        walls(61) = wall61
        walls(62) = wall62
        walls(63) = wall63
        walls(64) = wall64
        walls(65) = wall65
        walls(66) = wall66
        walls(67) = wall67
        walls(68) = wall68
        walls(69) = wall69
        '===================Level 5 / 81 - 100
        walls(81) = wall81
        walls(82) = wall82
        walls(83) = wall83
        walls(84) = wall84
        walls(85) = wall85
        walls(86) = wall86
        walls(87) = wall87
        walls(88) = wall88
        walls(89) = wall89
        walls(90) = wall90
        walls(91) = wall91
        walls(92) = wall92
        walls(93) = wall93
        walls(94) = wall94
        walls(95) = wall95
        walls(96) = wall96
        walls(97) = wall97
        walls(98) = wall98
        walls(99) = wall99
        walls(100) = wall100
        walls(101) = wall101
        walls(102) = wall102
        walls(103) = wall103
        walls(104) = wall104
        walls(105) = wall105
        'Credits
        walls(111) = wall111
        walls(112) = wall112
        walls(113) = wall113
        'Level 6, before credits(121-140)
        walls(121) = wall121
        walls(122) = wall122
        walls(123) = wall123
        walls(124) = wall124
        walls(125) = wall125
        walls(126) = wall126
        walls(129) = wall129
    End Sub

    Private Sub changeLevel()
        'Upon advancing to the next level, call this
        level += 1
        If level = 7 Then 'Set level label
            lblLevel.Text = "Credits"
        Else
            lblLevel.Text = level
        End If
        lstLevel.SelectedIndex = level - 1 'Seleted index starts at 0, have to subtract 1 to be the same as the level
        haveKey = False 'Dont have the key on level start
        lblStatus.Text = "You do not have the key."
        pnlLevel2.Left = 5 'level 2 is the earthquake level, reset its coordinates so you cant see it in background
        pnlLevel2.Top = 5

        'Bring panel for each level to front
        'Add the guy to the panel
        'Set guyTop and guyLeft coordinates to the start label for each level
        'The start label is only used for determining the guys start position(except for level 1)
        If level = 1 Then
            pnlLevel1.BringToFront()
            Me.pnlLevel1.Controls.Add(guy)
            guyTop = 480
            guyLeft = 50
        ElseIf level = 2 Then
            pnlLevel2.BringToFront()
            Me.pnlLevel2.Controls.Add(guy)
            guyTop = level2Start.Top
            guyLeft = level2Start.Left
        ElseIf level = 3 Then
            pnlLevel3.BringToFront()
            Me.pnlLevel3.Controls.Add(guy)
            guyTop = level3Start.Top
            guyLeft = level3Start.Left
        ElseIf level = 4 Then
            pnlLevel4.BringToFront()
            Me.pnlLevel4.Controls.Add(guy)
            guyTop = level4Start.Top
            guyLeft = level4Start.Left
        ElseIf level = 5 Then
            pnlLevel5.BringToFront()
            Me.pnlLevel5.Controls.Add(guy)
            guyTop = level5Start.Top
            guyLeft = level5Start.Left
        ElseIf level = 6 Then
            pnlLevel6.BringToFront()
            Me.pnlLevel6.Controls.Add(guy)
            guyTop = Level6Start.Top
            guyLeft = Level6Start.Left
        ElseIf level = 7 Then
            lblStatus.Text = "Glasses has the key."
            pnlFinal.BringToFront()
            Me.pnlFinal.Controls.Add(guy)
            guyLeft = 200
            guyTop = 300
        End If
    End Sub

    Private Sub collideWithObjects()
        'To prevent the guy from colliding with objects not on his current level, i need iStart and iEnd
        'i set iStart and iEnd to the spots in the array that the objects for each level are placed
        Dim iStart As Integer
        Dim iEnd As Integer
        If level = 1 Then
            iStart = 0
            iEnd = 20
        ElseIf level = 2 Then
            iStart = 21
            iEnd = 40
        ElseIf level = 3 Then
            iStart = 41
            iEnd = 60
        ElseIf level = 4 Then
            iStart = 61
            iEnd = 80
        ElseIf level = 5 Then
            iStart = 81
            iEnd = 100
        ElseIf level = 6 Then
            iStart = 101
            iEnd = 130
        End If
        For i = iStart To iEnd 'Go through the objects only in the current level
            'Objects sides(top, bottom, left, right)
            Dim OT As Integer = objects(i).Top
            Dim OB As Integer = objects(i).Bottom
            Dim OL As Integer = objects(i).Left
            Dim ORi As Integer = objects(i).Right
            'guy's sides
            Dim GuyT As Integer = guy.Top
            Dim GuyB As Integer = guy.Top + guy.Height
            Dim GuyL As Integer = guy.Left
            Dim GuyR As Integer = guy.Left + guy.Width

            'Basic collision detection
            'If any part of the guys rectangle is within any part of the objects rectangle,
            'then collide and do stuff depending on what that objects tag is
            If (((GuyB >= OT) And (GuyT <= OB)) And ((GuyR >= OL) And (GuyL <= ORi))) Then 'Collide?
                If objects(i).Tag = "key" Then 'If collided with key
                    objects(i).Visible = False 'Hide the key on screen
                    haveKey = True 'Get key
                    lblStatus.Text = "You Have The Key!"
                    If level = 1 Then 'Open the door on the corresponding level when you get the key
                        doorlvl1.Image = My.Resources.doorOpen1_40by50_
                    ElseIf level = 2 Then
                        doorlvl2.Image = My.Resources.doorOpen1_40by50_
                    ElseIf level = 3 Then
                        doorLvl3.Image = My.Resources.doorOpen1_40by50_
                    ElseIf level = 4 Then
                        doorLvl4.Image = My.Resources.doorOpen1_40by50_
                    ElseIf level = 5 Then
                        doorLvl5.Image = My.Resources.doorOpen1_40by50_
                    ElseIf level = 6 Then
                        doorLvl6.Image = My.Resources.doorOpen1_40by50_
                    End If
                ElseIf objects(i).Tag = "door" And haveKey Then 'Hit door, and have key, change level
                    changeLevel()
                ElseIf objects(i).Tag = "spike" Then 'Hit spike
                    lblStatus.Text = "You Died."
                    dead = True 'Allow for death animation in timer
                    lblRestart.Visible = True 'Show restart graphic thing
                    lblRestart.BringToFront()
                    spiked = True 'Allow for specific death animation, as compared to explosion animation
                ElseIf objects(i).Tag = "Vbullet" Or objects(i).Tag = "Hbullet" Then 'Collide with either kind of bullet
                    If guy.Left >= objects(i).Left Then 'Center the guy a bit more to make the explosion not jump across screen
                        guy.Left -= guy.Left - objects(i).Left
                    End If
                    If guy.Left < objects(i).Left Then
                        guy.Left += objects(i).Left - guy.Left
                    End If
                    exploded = True 'Explosion animation
                    dead = True 'Deadness
                    lblRestart.Visible = True
                    lblRestart.BringToFront()
                    guy.Image = My.Resources.splodeLvl3_1 'Start to do explosion
                    guy.Width = 75 'Change guy size and location to fit exposion pic
                    guy.Height = 77
                    guyTop -= 20
                    guy.SendToBack()
                    objects(i).Dispose() 'Delete bullet so isnt in way of explosion
                    objects(i).Tag = "Q" 'Used or something, i cant figure out why i used this
                ElseIf objects(i).Tag = "sentry" Then 'Little floating ball thing that follows you
                    guy.Image = My.Resources.splodeLvl3_1 'All the same stuff as running into a bullet
                    guyTop -= 20
                    guy.Width = 75
                    guy.Height = 77
                    sentry1Lvl3.Visible = False
                    sentry2Lvl3.Visible = False
                    exploded = True
                    lblStatus.Text = "You Died"
                    dead = True
                    lblRestart.Visible = True
                    lblRestart.BringToFront()
                    objects(i).Left = guyLeft - 10
                    objects(i).Top = guyTop - guy.Height
                    guy.SendToBack()
                ElseIf objects(i).Tag = "gravity" Then 'G symbol thing
                    objects(i).Tag = "used" 'Make it used so you cant pick it up more than once
                    objects(i).Visible = False
                    jumpHeight = 15 'Allow guy to jump higher
                    lowGravity = True 'He has low gravity now
                ElseIf objects(i).Tag = "tele" Then 'Teleporters on level 6
                    'Depending on the name of the teleporter, move the guy to the appropriate
                    'tele and center him
                    If objects(i).Name = "tele1Btm" Then
                        guyLeft = tele1Top.Left + (tele1Top.Width / 2) - 5
                        guyTop = 45
                    ElseIf objects(i).Name = "tele2Btm" Then
                        guyLeft = tele2Top.Left + (tele2Top.Width / 2) - 5
                        guyTop = 45
                    ElseIf objects(i).Name = "tele3Btm" Then
                        guyLeft = tele3Top.Left + (tele3Top.Width / 2) - 5
                        guyTop = 45
                    ElseIf objects(i).Name = "tele4Btm" Then
                        guyLeft = tele4Top.Left + (tele4Top.Width / 2) - 5
                        guyTop = 45
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub collideWithWalls()
        Dim wallsYourNotOnTopOf As Integer
        'Walls your not landing ontop of, so will fall if hitting side. Counts for walls your not
        'on top of and not walls your not touchinng.
        'Makes it so you can fall while touching the side of a wall

        Dim iStart As Integer 'Start and end for the for loop so you dont run into walls on diff levels
        Dim iEnd As Integer
        If level = 1 Then
            iStart = 0
            iEnd = 20
        ElseIf level = 2 Then
            iStart = 21
            iEnd = 40
        ElseIf level = 3 Then
            iStart = 41
            iEnd = 60
        ElseIf level = 4 Then
            iStart = 61
            iEnd = 80
        ElseIf level = 5 Then
            iStart = 81
            iEnd = 110
        ElseIf level = 6 Then
            iStart = 121
            iEnd = 140
        ElseIf level = 7 Then
            iStart = 111
            iEnd = 120
        End If
        For i = iStart To iEnd
            Dim WT As Integer = walls(i).Top 'Wall sides
            Dim WB As Integer = walls(i).Bottom
            Dim WL As Integer = walls(i).Left
            Dim WR As Integer = walls(i).Right
            Dim GuyT As Integer = guyTop 'Guy sides
            Dim GuyB As Integer = guyTop + guy.Height
            Dim GuyL As Integer = guyLeft
            Dim GuyR As Integer = guyLeft + guy.Width
            If (((GuyB >= WT) And (GuyT <= WB)) And ((GuyR >= WL) And (GuyL <= WR))) Then 'General Collision, intersecting rectangles
                wallsYourNotOnTopOf += 1 'Add one regardless
                If ((((GuyL < WR) And (GuyL >= (WR - 6))) And (GuyB > (WT))) And (GuyT <= (WB - 6))) Then 'Crazy specific collision stuff
                    'Moving to the left
                    'The only thing diff from the basic collision detecting is the plus and minus 6
                    'The 6 is used to give him leeway for falling. If the guys bottom is 6 from the top of the wall he will snap up
                    'I think this explanation makes sense, its been a year since i worked on this
                    guyLeft = walls(i).Right 'Set guys position to the right of the wall
                    guy.Image = My.Resources.HitWallLeft2
                ElseIf ((((GuyR > WL) And (GuyR <= (WL + 6))) And (GuyB > (WT))) And (GuyT <= (WB - 6))) Then
                    'Same as above but moving right
                    guyLeft = (walls(i).Left - guy.Width)
                    guy.Image = My.Resources.HitWallRight2
                End If
                If (((GuyB >= WT) And (GuyR > WL)) And (GuyL < WR)) Then 'Above wall and in bounds of it
                    'Collide down
                    'Have to check for downSpeed b/c if its moving to fast it will pass right through objects
                    If downMoveSpeed <= 8 Then 'So if downspeed is less than or 8
                        If (GuyB < (WT + 10)) Then
                            airTime = 0 'Used to increase falling speed
                            inTheAir = False 'Not in the air, used for jumping and stuff
                            downMoveSpeed = 0 'Not moving down
                            guyTop = (walls(i).Top - guy.Height) 'Set him to the top of the wall
                            wallsYourNotOnTopOf -= 1 'Take one because you are ontop of wall
                        ElseIf ((GuyT < WB) And (GuyT > (WB - 6))) Then
                            guyTop = walls(i).Bottom 'Moved up
                        End If
                    Else
                        If (GuyB <= (WT + downMoveSpeed)) Then
                            'Downspeed increases as you fall, so if the guy is moving to fast
                            'he will go right through small walls. This prevents that
                            'Same code inside as above
                            airTime = 0
                            inTheAir = False
                            downMoveSpeed = 0
                            guyTop = (walls(i).Top - guy.Height)
                            wallsYourNotOnTopOf -= 1 'Take one because you are ontop of wall
                        ElseIf ((GuyT < WB) And (GuyT > (WB - 6))) Then
                            guyTop = walls(i).Bottom 'Moved up
                        End If
                    End If
                End If
            Else
                wallsYourNotOnTopOf += 1 'If you didnt collide add 1
            End If
        Next
        If ((wallsYourNotOnTopOf - 1) = iEnd - iStart) Then 'If your not ontop of how many walls on the level, then fall
            inTheAir = True 'Your falling
            airTime += 1 'Increase fall speed
            If ((airTime >= 5) And (downMoveSpeed <= 20)) Then
                'If your in the air for a certain amount of time(5) and your not going more than
                '20 pixels each move, then go faster.
                downMoveSpeed += 1
                airTime = 0
            End If
            If (downMoveSpeed < 6) Then 'Prevent from falling really slow, default speed
                downMoveSpeed = 6
            End If
        End If
    End Sub

    Private Sub fallOffLevel()
        'If guy is below current panel then kill him
        If guy.Top > guy.Parent.Bottom Then
            lblStatus.Text = "You Died"
            lblRestart.Visible = True 'Show big restart label
            lblRestart.BringToFront()
        End If
    End Sub

    Private Sub level1()
        'Move title around and keep it in bounds
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
        If lblTitle.Top <= 40 Then
            lblTitle.Top = 40
        End If
        If lblTitle.Left <= 30 Then
            lblTitle.Left = 30
        End If
        If lblTitle.Left >= 331 Then
            lblTitle.Left = 331
        End If
        If lblTitle.Top >= 80 Then
            lblTitle.Top = 80
        End If

        'Tutorial labels, they go away when you do certain things
        If lblHJump.Visible = False And lblHWalk.Visible = False And lblHGravity.Tag = "notused" Then
            lblHGravity.Tag = "q"
            lblHGravity.Visible = True
        End If
        If haveKey = True Then
            lblHGetKey.Visible = False
        End If
        If lowGravity = True Then
            lblHGravity.Visible = False
        End If
    End Sub

    Private Sub level2()
        'earthquake level
        'Move screen around and keep it in bounds
        Dim x As Integer = Int(Rnd() * 4) + 1
        If x = 1 Then
            pnlLevel2.Top += 4
        ElseIf x = 2 Then
            pnlLevel2.Top -= 4
        ElseIf x = 3 Then
            pnlLevel2.Left += 4
        ElseIf x = 4 Then
            pnlLevel2.Left -= 4
        End If
        If pnlLevel2.Top <= -3 Then
            pnlLevel2.Top = 5
        End If
        If pnlLevel2.Left <= -3 Then
            pnlLevel2.Left = 5
        End If
        If pnlLevel2.Left >= 15 Then
            pnlLevel2.Left = 5
        End If
        If pnlLevel2.Top >= 15 Then
            pnlLevel2.Top = 5
        End If
    End Sub

    Private Sub level3()
        'Check coordinates of sentries and guy and move according to location
        For Each Control In Me.pnlLevel3.Controls
            If Control.tag = "sentry" Then
                If Control.Top > guy.Top + 20 Then 'Move up
                    Control.Top -= 2
                ElseIf Control.Top < guy.Top + 10 Then 'Move down
                    Control.Top += 2
                End If
                If Control.Left > guy.Left Then 'Move left
                    Control.Left -= 2
                End If
                If Control.Left < guy.Left Then 'Move right
                    Control.Left += 2
                End If
            End If
        Next
    End Sub

    Private Sub level4()
        'Everytime a turrets tag reaches firecounter, create a bullet
        'Turret tag is something like 20H(number, H or V for horizontal or vertical)
        'I take apart the tag and use it to decide when to fire and which direction
        fireCounter += 1
        For Each Control In Me.pnlLevel4.Controls
            If Control.Tag <> "Q" And Control.tag <> "" Then 'I use q for variables i cant come up with names for :P
                'Q is a control that was already used
                If Control.Tag.Substring(2, 1) = "V" Or Control.Tag.Substring(2, 1) = "H" Then 'If control is a turret
                    Dim tag As Integer = Control.tag.substring(0, 2) 'The number in the tag
                    If tag = (fireCounter) Then 'If number in tag is firecounter which constanlty counts up
                        Dim bullet As New PictureBox 'Make a bullet
                        With bullet
                            .BackColor = Color.Green
                            If Control.Tag.Substring(2, 1) = "V" Then 'Horiz or vert bullet
                                .Height = 34 'Set up bullet
                                .Width = 14
                                .BackgroundImageLayout = ImageLayout.Stretch
                                .SizeMode = PictureBoxSizeMode.StretchImage
                                .Left = Control.left + 8 'Place it by turret
                                .Top = Control.top
                                .Image = My.Resources.BulletVert2
                                .Tag = "Vbullet"
                            ElseIf Control.Tag.Substring(2, 1) = "H" Then
                                'Same thing for Horzontal bullets
                                .Height = 12
                                .Width = 32
                                .BackgroundImageLayout = ImageLayout.Stretch
                                .SizeMode = PictureBoxSizeMode.StretchImage
                                .Left = Control.left
                                .Top = Control.top + 8
                                .Image = My.Resources.BulletHoriz2
                                .Tag = "Hbullet"
                            End If
                            Me.pnlLevel4.Controls.Add(bullet) 'Add bullet to panel
                            .SendToBack()
                            For i = 63 To 75
                                If objects(i).Tag = "Q" Then
                                    objects(i) = bullet
                                    Exit For
                                End If
                            Next
                        End With
                        Exit For
                    End If
                End If
            End If
        Next
        If fireCounter = 45 Then 'Last bullet fired, restart
            fireCounter = 0
        End If
        For Each Control In Me.pnlLevel4.Controls 'Move bullets
            If Control.Tag = "Vbullet" Then
                Control.Top += 10
            ElseIf Control.tag = "Hbullet" Then
                Control.Left -= 8
            End If
        Next
        'Kill bullets when they go off screen
        For i = 63 To 75
            If (objects(i).Top > pnlLevel4.Bottom And objects(i).Tag = "Vbullet") Or (objects(i).Left < 64 And objects(i).Tag = "Hbullet") Then
                objects(i).Tag = "Q" 'Uh, this is so i dont use the bullet anymore later, i think
                objects(i).Dispose()
                Exit For
            End If
        Next
    End Sub

    Private Sub level5()
        'Time bomb stuff
        Dim time As Integer = lblBombTmr.Text 'Get time left
        time = time - 1 'take away
        lblBombTmr.Text = CStr(time) 'Put new time in text
        If time = 0 Then 'If time 0, you die
            dead = True
            Dim loseExplosion As New PictureBox 'Make and add explosion pic on screen
            Me.Controls.Add(loseExplosion)
            With loseExplosion
                .Tag = "loseEx"
                .Height = pnlLevel5.Height
                .Width = pnlLevel5.Width
                .Image = My.Resources.ExplosionLvl5Lose
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BackgroundImageLayout = ImageLayout.Stretch
                .Left = pnlLevel5.Left + 1
                .Top = pnlLevel5.Top + 1
            End With
            loseExplosion.BringToFront()
            lblRestart.Visible = True
            lblRestart.BringToFront()
        End If
    End Sub

    Private Sub level6()
        'Moving spikes on falling teleport level

        'Moving S1 and S2 are the spike picture names
        'I use enabled and disabled as a sort of flag so i didnt have to make more global variables
        'If its disabled and it one plcae, move it one way, if its not, move it another way
        If movingS1.Enabled = False Then
            movingS1.Left += 1
        ElseIf movingS1.Enabled = True Then
            movingS1.Left -= 1
        End If
        If movingS1.Left <= 242 Then
            movingS1.Enabled = False
        End If
        If movingS1.Right >= 341 Then
            movingS1.Enabled = True
        End If

        If movingS2.Enabled = False Then
            movingS2.Left += 2
        ElseIf movingS2.Enabled = True Then
            movingS2.Left -= 2
        End If
        If movingS2.Left <= 484 Then
            movingS2.Enabled = False
        End If
        If movingS2.Right >= 585 Then
            movingS2.Enabled = True
        End If

    End Sub

    Private Sub tmrMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMove.Tick
        If exploded = True Then 'If you exploded
            guy.BackColor = Color.White
            nextPicNum += 1 'Used to change pic for animation
            'Checks pic num and uses appropraite image
            'I change the position later on because the pic has to get smaller and it has to stay centered
            If nextPicNum = 1 Then
                guy.Image = My.Resources.splodeLvl3_2
            ElseIf nextPicNum = 2 Then
                guy.Image = My.Resources.splodeLvl3_3
            ElseIf nextPicNum = 3 Then
                guy.Image = My.Resources.splodeLvl3_4
            ElseIf nextPicNum = 4 Then
                guy.Image = My.Resources.splodeLvl3_5
            ElseIf nextPicNum = 5 Then
                guy.Image = My.Resources.splodeLvl3_6
            ElseIf nextPicNum = 6 Then
                guy.Image = My.Resources.splodeLvl3_7
            ElseIf nextPicNum = 7 Then
                guy.Image = My.Resources.splodeLvl3_8
            ElseIf nextPicNum = 8 Then
                guy.Image = My.Resources.splodeLvl3_9
            ElseIf nextPicNum = 9 Then
                guy.Image = My.Resources.splodeLvl3_10
            ElseIf nextPicNum = 10 Then
                guy.Image = My.Resources.splodeLvl3_11
            ElseIf nextPicNum = 11 Then
                guy.Image = My.Resources.splodeLvl3_12
            ElseIf nextPicNum = 12 Then
                guy.Image = My.Resources.splodeLvl3_13
            ElseIf nextPicNum = 13 Then
                guy.Image = My.Resources.splodeLvl3_14
            ElseIf nextPicNum = 14 Then
                guy.Image = My.Resources.splodeLvl3_15
            ElseIf nextPicNum = 15 Then
                guy.Image = My.Resources.splodeLvl3_16
            ElseIf nextPicNum = 16 Then
                guy.Image = My.Resources.splodeLvl3_17
            ElseIf nextPicNum = 17 Then
                guy.Image = My.Resources.splodeLvl3_18
            ElseIf nextPicNum = 18 Then
                guy.Image = My.Resources.splodeLvl3_19
            ElseIf nextPicNum = 19 Then
                guy.Image = My.Resources.splodeLvl3_20
            ElseIf nextPicNum = 20 Then
                guy.Image = My.Resources.splodeLvl3_21
                guy.Width = 50
                guy.Height = 50
                guy.Top += 10
                guy.Left += 10
            ElseIf nextPicNum = 21 Then
                guy.Image = My.Resources.splodeLvl3_22
                guy.Width = 45
                guy.Top += 7
                guy.Left += 7
                guy.Height = 45
            ElseIf nextPicNum = 22 Then
                guy.Image = My.Resources.splodeLvl3_23
                guy.Width = 40
                guy.Top += 5
                guy.Left += 5
                guy.Height = 40
            ElseIf nextPicNum = 23 Then
                guy.Image = My.Resources.splodeLvl3_24
                guy.Width = 35
                guy.Height = 35
                guy.Top += 3
                guy.Left += 4
            ElseIf nextPicNum = 24 Then
                guy.Visible = False
            End If
        ElseIf spiked = True Then 'Not exploded but killed by spikes, same deal as above
            nextPicNum2 += 1
            If nextPicNum2 = 1 Then
                guy.Image = My.Resources.blood1
            ElseIf nextPicNum2 = 2 Then
                guy.Image = My.Resources.blood2
            ElseIf nextPicNum2 = 3 Then
                guy.Image = My.Resources.blood4
            ElseIf nextPicNum2 = 4 Then
                guy.Image = My.Resources.blood5
            ElseIf nextPicNum2 = 5 Then
                guy.Image = My.Resources.blood7
            ElseIf nextPicNum2 = 6 Then
                guy.Image = My.Resources.blood8
            ElseIf nextPicNum2 = 7 Then
                guy.Image = My.Resources.blood10
            ElseIf nextPicNum2 = 8 Then
                guy.Image = My.Resources.blood11
            ElseIf nextPicNum2 = 9 Then
                guy.Image = My.Resources.blood13
            ElseIf nextPicNum2 = 10 Then
                guy.Image = My.Resources.blood15
            End If
        End If


        'If the guy isnt dead, then make the game do everyhting
        If Not dead Then
            guy.BackColor = ColorDialog1.Color
            If level = 1 Then 'Run subs according to level
                level1()
            End If
            If level = 4 Then
                level4()
            End If
            If level = 3 Then
                level3()
            End If
            If level = 2 Then
                level2()
            End If
            If level = 6 Then
                level6()
            End If

            'Count every second for the bomb on level 5
            '20 timer ticks = 1 second
            secondCounter += 1
            If secondCounter = 20 Then
                If level = 5 Then
                    level5()
                End If
                secondCounter = 0
            End If

            If lowGravity Then 'Low Gravity(G picture thing)
                lowGravityTime += 1
                If lowGravityTime >= 200 Then 'If you have low gravity for over 200 ticks, you dont anymore
                    lowGravityTime = 0
                    lowGravity = False
                    jumpHeight = 10 'Back to normal jump height
                End If
            End If


            'GuyLeft and Top are used to check for walls
            'I move guyLeft and Top before i actually move the picture box
            'This prevents the guy from moving into a wall then snapping back
            guyLeft = guyLeft + leftMoveSpeed
            guyLeft = guyLeft + rightMoveSpeed
            guyTop = guyTop + upMoveSpeed
            guyTop = guyTop + downMoveSpeed

            If (upMoveSpeed = -11) Then 'Jumping
                'If you pressed up, allow them to jump
                jumping = True
                inTheAir = True
                jumpTime += 1
                downMoveSpeed = 0
            End If
            If (jumpTime = jumpHeight) Then 'can only jump for so long
                jumping = False
                jumpTime = 0
                upMoveSpeed = 0 'Then go down
                downMoveSpeed = 6
            End If

            collideWithWalls() 'collide with walls
            collideWithObjects() 'collide with everything else
            keepOnPanel() 'So cant walk off screen
            guy.Left = guyLeft 'Actually move the picture box
            guy.Top = guyTop
            changePics() 'Change the pics
            fallOffLevel() 'Check to see if he fell down off screen
        End If
    End Sub

    Private Sub keepOnPanel()
        'Dont let guy walk off of panel
        If guyLeft < guy.Parent.Left Then
            guyLeft = guy.Parent.Left
            guy.Image = My.Resources.HitWallLeft2
        End If
        If guyLeft + guy.Width > guy.Parent.Right - 5 Then
            guyLeft = guy.Parent.Right - guy.Width - 5
            guy.Image = My.Resources.HitWallRight2
        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Closes splash screen to prevent program from running in background by closing main form
        Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnFocus.Focus() 'I use the focus button as a sort of a slave button
        'Keeps other buttons from getting focus and getting hit when pressing buttons

        ToolTip1.SetToolTip(PictureBox21, "Its a secret!") 'Tooltip on final level
        lstLevel.SelectedIndex = 0 'Start level selector at begning
        Me.Focus()
        changeLevel() 'Level starts as 0, changeLevel adds one to level and sets up the level
        pnlLevel1.Top = 5
        pnlLevel1.Left = 5

        'Guy left and top are guys coordinates
        guyLeft = guy.Left
        guyTop = guy.Top
        makeArrays() 'Fill arrays so game works
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, btnHelp.KeyDown, btnCloseHelp.KeyDown, btnChangeLevel.KeyDown, lstLevel.KeyDown, btnQuit.KeyDown, btnRestart.KeyDown, btnHelp2.KeyDown, btnChangeColor.KeyDown, btnFocus.KeyDown
        Me.Focus()
        If (e.KeyCode = Keys.A) Then 'Move left
            If lblHWalk.Visible = True Then 'Get rid of tutorial label
                lblHWalk.Visible = False
            End If
            movingLeft = True 'important stuff for later 
            leftMoveSpeed = (-moveDist)
            lastDirection = "L"
        ElseIf (e.KeyCode = Keys.D) Then 'right
            If lblHWalk.Visible = True Then
                lblHWalk.Visible = False
            End If
            movingRight = True
            rightMoveSpeed = moveDist 'Move right
            lastDirection = "R"
        ElseIf ((e.KeyCode = Keys.Space) And Not inTheAir And allowjump) Or (e.KeyCode = Keys.W And Not inTheAir And allowjump) Then
            'Basically, if you press space(or W) and your on the ground and your allowed to jump, then do it
            If lblHJump.Visible = True Then
                lblHJump.Visible = False
            End If
            'Let him go up if your on the ground, and you didnt just jump
            allowjump = False
            upMoveSpeed = -11
        End If
        If (e.KeyCode = Keys.R) And level <> 7 Then 'Restart
            restart()
        End If
        If e.KeyCode = Keys.Tab Then 'Disp or hide help menu
            helpMenu()
        End If
    End Sub

    Private Sub helpMenu()
        'If menu is closed, open, if open, close
        'So tab works both ways
        If pnlHelp.Visible = False Then
            pnlHelp.BringToFront()
            pnlHelp.Visible = True
            dead = True
        ElseIf pnlHelp.Visible = True Then
            pnlHelp.Visible = False
            dead = False
        End If
        Me.Focus()
    End Sub

    Private Sub restart()
        'Reset everything, some stuff based on level
        'Dispose of stuff, set posotions, show picture boxes, ect
        guy.Visible = True
        guy.Width = 20
        guy.Height = 35
        nextPicNum = 0
        nextPicNum2 = 0
        spiked = False
        exploded = False
        lblStatus.Text = "You do not have the key."
        dead = False
        lblRestart.Visible = False
        haveKey = False
        If level = 1 Then
            gravityLvl1.Visible = True
            gravityLvl1.Tag = "gravity"
            keylvl1.Visible = True
            keylvl1.BringToFront()
            guyTop = 400
            guyLeft = 50
            guy.Top = 400
            guy.Left = 50
        ElseIf level = 2 Then
            keylvl2.Visible = True
            keylvl2.BringToFront()
            guyTop = level2Start.Top
            guyLeft = level2Start.Left
            guy.Top = level2Start.Top
            guy.Left = level2Start.Left
        ElseIf level = 3 Then
            gravityLvl3.Visible = True
            gravityLvl3.Tag = "gravity"
            keyLvl3.Visible = True
            keyLvl3.BringToFront()
            guyTop = level3Start.Top
            guyLeft = level3Start.Left
            sentry1Lvl3.Visible = True
            sentry2Lvl3.Visible = True
            sentry1Lvl3.Left = 557
            sentry1Lvl3.Top = 273
            sentry2Lvl3.Left = 171
            sentry2Lvl3.Top = 299
            sentry1Lvl3.Image = My.Resources.sentry
            sentry2Lvl3.Image = My.Resources.sentry
            sentry1Lvl3.Height = 15
            sentry1Lvl3.Width = 15
            sentry2Lvl3.Height = 15
            sentry2Lvl3.Width = 15
        ElseIf level = 4 Then
            keyLvl4.Visible = True
            keyLvl4.BringToFront()
            guyTop = level4Start.Top
            guyLeft = level4Start.Left
            For i = 63 To 75
                If objects(i).Tag = "Vbullet" Or objects(i).Tag = "Hbullet" Then
                    objects(i).Tag = "Q"
                    objects(i).Dispose()
                End If
            Next
        ElseIf level = 5 Then
            KeyLvl5.Visible = True
            KeyLvl5.BringToFront()
            guyTop = level5Start.Top
            guyLeft = level5Start.Left
            lblBombTmr.Text = 40
            For Each Control In Me.Controls
                If Control.tag = "loseEx" Then
                    Control.dispose()
                End If
            Next
        ElseIf level = 6 Then
            guyTop = Level6Start.Top
            guyLeft = Level6Start.Left
            guy.Left = Level6Start.Left
            guy.Top = Level6Start.Top
            keyLvl6.BringToFront()
            keyLvl6.Visible = True
        ElseIf level = 7 Then
            lblStatus.Text = "Glasses has the key."
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, btnHelp.KeyUp, btnCloseHelp.KeyUp, btnChangeLevel.KeyUp, lstLevel.KeyUp, btnQuit.KeyUp, btnRestart.KeyUp, btnHelp2.KeyUp, btnChangeColor.KeyUp, btnFocus.KeyUp
        Me.Focus()
        If (e.KeyCode = Keys.A) Then 'Your not moving left anymore
            movingLeft = False
            leftMoveSpeed = 0
        ElseIf (e.KeyCode = Keys.Space) Or (e.KeyCode = Keys.W) Then 'Jump
            allowjump = True 'Let him jump now, stops repeated jumping
            jumpTime = jumpHeight 'Make him fall, when jumpTime = r you reach your max jump time
            upMoveSpeed = 0
        ElseIf (e.KeyCode = Keys.D) Then 'Your not moving right anymore
            movingRight = False
            rightMoveSpeed = 0
        End If
    End Sub

    Private Sub changePics()
        'A lot of ifs
        'The guy has pics for falling, running, jumping, and hitting walls in both directions
        'These statements cover every possibility
        'The variable names are self explanatory on what each If does
        If inTheAir And Not jumping And movingLeft Then
            guy.Image = My.Resources.FallLeft
            guy.Tag = ""
        ElseIf inTheAir And Not jumping And movingRight Then
            guy.Image = My.Resources.FallRight
            guy.Tag = ""
        ElseIf inTheAir And jumping And movingLeft Then
            guy.Image = My.Resources.JumpLeft
            guy.Tag = "" 'Moving left and jump
        ElseIf inTheAir And jumping And movingRight Then
            guy.Image = My.Resources.JumpRight
            guy.Tag = "" 'Moving right and jump
        ElseIf Not inTheAir And Not movingRight And Not movingLeft Then
            guy.Image = My.Resources.Still01
            guy.Tag = "" 'Not moving
        ElseIf inTheAir And Not movingLeft And Not movingRight And jumping And lastDirection = "R" Then
            guy.Image = My.Resources.JumpRight
            guy.Tag = "" 'Jumping if not moving/ last moved right
        ElseIf inTheAir And Not movingLeft And Not movingRight And jumping And lastDirection = "L" Then
            guy.Image = My.Resources.JumpLeft
            guy.Tag = "" 'Jumping if not moving/ last moved left
        ElseIf inTheAir And Not movingLeft And Not movingRight And Not jumping And lastDirection = "R" Then
            guy.Image = My.Resources.FallRight
            guy.Tag = "" 'Fall right if not moving/ last moved right 
        ElseIf inTheAir And Not movingLeft And Not movingRight And Not jumping And lastDirection = "L" Then
            guy.Image = My.Resources.FallLeft
            guy.Tag = "" 'Fall right if not moving/ last moved left 
        End If
        If guy.Tag <> "right" And Not inTheAir And movingRight Then
            guy.Tag = "right"
            guy.Image = My.Resources.RunRightFixed
        End If
        If guy.Tag <> "left" And Not inTheAir And movingLeft Then
            guy.Tag = "left"
            guy.Image = My.Resources.RunLeftFixed
        End If
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click, btnCloseHelp.Click, btnHelp2.Click
        helpMenu() 'Help menu
    End Sub

    Private Sub btnChangeLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeLevel.Click
        level = lstLevel.SelectedIndex 'Make level the level you have selected
        changeLevel() 'Change for the new level
        restart() 'Reset everything
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        'X is the response of the message box(Ok, cancel)
        Dim x As Integer = MsgBox("Are You Sure You Want To Quit?", MsgBoxStyle.OkCancel, "Some Platform Game.")
        If x = 1 Then 'If x is 1 then you clicked ok so end the program
            Application.Exit()
        End If
    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        restart() 'Restart
    End Sub

    Private Sub btnChangeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeColor.Click
        ColorDialog1.ShowDialog() 'Show color dialog
        guy.BackColor = ColorDialog1.Color 'When click the button to select color set back color of guy
        'All the guy pictures are actually alpha colored(maybe colored isnt the right word, i suck at photoshop)
        'So the back color of the pic box is seen through the alpha of the pic
        movingLeft = False
        movingRight = False
    End Sub

    Private Sub btnFocus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFocus.Click
        btnFocus.Focus() 'Keep focus
    End Sub

    Private Sub BtnRestart_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestart.GotFocus, btnChangeColor.GotFocus, btnChangeLevel.GotFocus, btnCloseHelp.GotFocus
        'If you click any of the buttons on the form, btnFocus gets the focus
        btnFocus.Focus()
    End Sub

End Class