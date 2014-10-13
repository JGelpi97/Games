Public Class frmMemory
    Dim firstTurn As Boolean = True
    Dim matches As Integer
    Dim cardNames(0 To 15) As String
    Dim deckPicked As Boolean = False
    Dim Diffpicked As Boolean = False
    Dim deckChoice As String = ""
    Dim difficulty As String = ""
    Dim moves As Decimal = 0
    Dim time As Decimal = 0
    Dim loss As Boolean = False

    Private Sub picCard0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCard9.Click, picCard8.Click, picCard7.Click, picCard6.Click, picCard5.Click, picCard4.Click, picCard3.Click, picCard2.Click, picCard15.Click, picCard14.Click, picCard13.Click, picCard12.Click, picCard11.Click, picCard10.Click, picCard1.Click, picCard0.Click
        If loss = False Then
            '---CLICK A CARD---
            'Start time after card is clicked
            tmrCountDown.Enabled = True
            'TF2 Cards
            If deckChoice = "TF2" Then
                If sender.tag = "Sniper" Then
                    sender.image = My.Resources.RedSniper
                ElseIf sender.tag = "Scout" Then
                    sender.image = My.Resources.RedScout
                ElseIf sender.tag = "Demoman" Then
                    sender.image = My.Resources.RedDemo
                ElseIf sender.tag = "Heavy" Then
                    sender.image = My.Resources.Heavynew
                ElseIf sender.tag = "Pyro" Then
                    sender.image = My.Resources.RedPyro
                ElseIf sender.tag = "Engineer" Then
                    sender.image = My.Resources.RedEngee
                ElseIf sender.tag = "Soldier" Then
                    sender.image = My.Resources.RedSoldier
                ElseIf sender.tag = "Spy" Then
                    sender.image = My.Resources.RedSpy
                End If
                'Links Cards
            ElseIf deckChoice = "Links" Then
                If sender.tag = "Twighlight Princess" Then
                    sender.image = My.Resources.LinkTP
                ElseIf sender.tag = "4 Swords Adventure" Then
                    sender.image = My.Resources.Link4Swords
                ElseIf sender.tag = "Windwaker" Then
                    sender.image = My.Resources.LinkWindwaker
                ElseIf sender.tag = "Ocarina of Time" Then
                    sender.image = My.Resources.LinkOcOfTime
                ElseIf sender.tag = "NES Link" Then
                    sender.image = My.Resources.LinkOriginal
                ElseIf sender.tag = "Wolf Link" Then
                    sender.image = My.Resources.LinkWolf
                ElseIf sender.tag = "The Minish Cap" Then
                    sender.image = My.Resources.LinkMinishCap
                ElseIf sender.tag = "Phantom Hourglass" Then
                    sender.image = My.Resources.LinkPHour
                End If
                'Pikmin Cards
            ElseIf deckChoice = "Pikmin" Then
                If sender.tag = "Olimar" Then
                    sender.image = My.Resources.PikminOlimar
                ElseIf sender.tag = "Louie" Then
                    sender.image = My.Resources.PikminLouie
                ElseIf sender.tag = "Red Pikmin" Then
                    sender.image = My.Resources.PikminRed
                ElseIf sender.tag = "Blue Pikmin" Then
                    sender.image = My.Resources.PikminBlue
                ElseIf sender.tag = "Yellow Pikmin" Then
                    sender.image = My.Resources.PikminYellow
                ElseIf sender.tag = "Purple Pikmin" Then
                    sender.image = My.Resources.PikminPurple
                ElseIf sender.tag = "White Pikmin" Then
                    sender.image = My.Resources.PikminWhite
                ElseIf sender.tag = "Raging Long Legs" Then
                    sender.image = My.Resources.PikminRLL
                End If
            End If
            If firstTurn Then
                'First Turn? Disable card, set label
                sender.enabled = False
                lblCard1.Text = sender.tag
            ElseIf Not firstTurn Then
                '2nd Turn?
                Dim pic As PictureBox
                For Each pic In Me.grpCards.Controls
                    pic.Enabled = False
                Next
                lblCard2.Text = sender.tag
                'Delay according to difficulty
                If difficulty = "Easy" Then
                    delay(1.5)
                ElseIf difficulty = "Medium" Then
                    delay(0.8)
                Else
                    delay(0.3)
                End If
                'Check for match and for win
                match()
                cardBacks()
                For Each pic In Me.grpCards.Controls
                    pic.Enabled = True
                Next
            End If
            firstTurn = Not firstTurn
            checkForLoss()
        End If
    End Sub

    Private Sub match()
        'Check for match, win, play sounds
        Dim points As Integer = lblPoints.Text
        If lblCard1.Text = lblCard2.Text Then
            If lblCard1.Text = "Sniper" Then
                My.Computer.Audio.Play(My.Resources.sniper_award04, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Scout" Then
                My.Computer.Audio.Play(My.Resources.scout_award08, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Demoman" Then
                My.Computer.Audio.Play(My.Resources.demoman_go02, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Heavy" Then
                My.Computer.Audio.Play(My.Resources.heavy_domination17, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Pyro" Then
                My.Computer.Audio.Play(My.Resources.flame_thrower_pilot, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Engineer" Then
                My.Computer.Audio.Play(My.Resources.engineer_niceshot02, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Soldier" Then
                My.Computer.Audio.Play(My.Resources.soldier_battlecry03, AudioPlayMode.Background)
            ElseIf lblCard1.Text = "Spy" Then
                My.Computer.Audio.Play(My.Resources.spy_battlecry01, AudioPlayMode.Background)
            End If
            points = points + 1
            lblPoints.Text = CStr(points)
            Dim pic As PictureBox
            For Each pic In Me.grpCards.Controls
                If pic.Tag = lblCard1.Text Then
                    pic.Visible = False
                End If
            Next
            If lblPoints.Text = 8 Then
                tmrCountDown.Enabled = False
                wmpBack1.URL = Application.StartupPath + "\win.wav"
                MsgBox("Winnar", MsgBoxStyle.Critical, "You Win")
                writeToFile()
            End If
        End If
        lblCard1.Text = ""
        lblCard2.Text = ""
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        '---PLAY BTN ON MENU---
        choiceStuffSet()
        Me.Height = pnlPlay.Height
        Me.Width = pnlPlay.Width
        pnlMenu.Visible = False
        pnlPlay.Visible = True
        pnlPlay.Top = 1
        pnlPlay.Left = 1
        loadNames()
        swapCards()
        giveTags()
        cardResetW_D()
    End Sub

    Private Sub playAgain()
        '---SUB, NOT BTN---
        If deckChoice = "TF2" Then
            wmpBack1.URL = Application.StartupPath + "\gamestartup1.mp3"
        ElseIf deckChoice = "Pikmin" Then
            wmpBack1.URL = Application.StartupPath + "\pikmin.mp3"
        ElseIf deckChoice = "Links" Then
            wmpBack1.URL = Application.StartupPath + "\link.mp3"
        End If
        loss = False
        tmrCountDown.Enabled = False
        setMovesTimes()
        noPics()
        picsVisible()
        swapCards()
        giveTags()
        cardResetW_D()
        firstTurn = True
        enablePics()
        lblCard1.Text = ""
        lblCard2.Text = ""
        lblPoints.Text = 0
    End Sub

    Private Sub btnBackToMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackToMenu.Click
        '---GO BACK TO THE MENU---
        lblRealShowMoves.Text = ""
        lblRealShowDiff.Text = ""
        lblRealShowTime.Text = ""
        loss = False
        tmrCountDown.Enabled = False
        deckPicked = False
        Diffpicked = False
        deckChoice = ""
        difficulty = ""
        firstTurn = True
        lblCard1.Text = ""
        lblCard2.Text = ""
        menuSet()
        noPics()
        picsVisible()
        enablePics()
        lblPoints.Text = 0
        'RESET BTNS
        For Each RadioButton In Me.grpDeck.Controls
            RadioButton.checked = False
        Next
        For Each RadioButton In Me.grpDifficulty.Controls
            RadioButton.checked = False
        Next
        btnPlay.Enabled = False
    End Sub
    Private Sub checkForLoss()
        'Check for moves ran out
        'Make moves go down
        moves = moves - 1
        lblMoves.Text = CStr(moves)
        If moves = 0 Then
            tmrCountDown.Enabled = False
            If deckChoice = "TF2" Then
                wmpBack1.URL = Application.StartupPath + "\lose.wav"
            End If
            MsgBox("Out of moves, game over.", MsgBoxStyle.Critical)
            disablePics()
            loss = True
        End If
    End Sub

    Private Sub choiceStuffSet()
        'Sets, moves, time, backrounds, cards, sounds...
        If radLink.Checked Then
            deckChoice = "Links"
            grpCards.BackgroundImage = Nothing
            wmpBack1.URL = Application.StartupPath + "\link.mp3"
        ElseIf radPikmin.Checked Then
            deckChoice = "Pikmin"
            grpCards.BackgroundImage = My.Resources.PikminWall
            wmpBack1.URL = Application.StartupPath + "\pikmin.mp3"
        ElseIf radTF2.Checked Then
            deckChoice = "TF2"
            grpCards.BackgroundImage = My.Resources.tf2Back1
            wmpBack1.URL = Application.StartupPath + "\gamestartup1.mp3"
        End If
        If radEasy.Checked Then
            difficulty = "Easy"
            lblRealShowDiff.Text = "Easy"
        ElseIf radMedium.Checked Then
            difficulty = "Medium"
            lblRealShowDiff.Text = "Medium"
        ElseIf radHard.Checked Then
            difficulty = "Hard"
            lblRealShowDiff.Text = "Hard"
        End If
        setMovesTimes()
    End Sub
















    Private Sub cardResetW_D()
        '---CARD RESET WITH DELAY---
        Dim pic As PictureBox
        'IF NOT EASY ALL BACKS ON START
        If difficulty <> "Easy" Then
            For Each pic In Me.grpCards.Controls
                delay(0.1)
                If deckChoice = "TF2" Then
                    pic.Image = My.Resources.RedCardBack
                ElseIf deckChoice = "Pikmin" Then
                    pic.Image = My.Resources.PikminBack
                ElseIf deckChoice = "Links" Then
                    pic.Image = My.Resources.LinkBack
                End If
            Next
        Else        'IF EASY SHOW CARDS UP AT BEGINING
            For Each pic In Me.grpCards.Controls
                delay(0.1)
                If deckChoice = "TF2" Then
                    If pic.Tag = "Sniper" Then
                        pic.Image = My.Resources.RedSniper
                    ElseIf pic.Tag = "Scout" Then
                        pic.Image = My.Resources.RedScout
                    ElseIf pic.Tag = "Demoman" Then
                        pic.Image = My.Resources.RedDemo
                    ElseIf pic.Tag = "Heavy" Then
                        pic.Image = My.Resources.Heavynew
                    ElseIf pic.Tag = "Pyro" Then
                        pic.Image = My.Resources.RedPyro
                    ElseIf pic.Tag = "Engineer" Then
                        pic.Image = My.Resources.RedEngee
                    ElseIf pic.Tag = "Soldier" Then
                        pic.Image = My.Resources.RedSoldier
                    ElseIf pic.Tag = "Spy" Then
                        pic.Image = My.Resources.RedSpy
                    End If
                ElseIf deckChoice = "Pikmin" Then
                    If pic.Tag = "Olimar" Then
                        pic.Image = My.Resources.PikminOlimar
                    ElseIf pic.Tag = "Louie" Then
                        pic.Image = My.Resources.PikminLouie
                    ElseIf pic.Tag = "Red Pikmin" Then
                        pic.Image = My.Resources.PikminRed
                    ElseIf pic.Tag = "Blue Pikmin" Then
                        pic.Image = My.Resources.PikminBlue
                    ElseIf pic.Tag = "Yellow Pikmin" Then
                        pic.Image = My.Resources.PikminYellow
                    ElseIf pic.Tag = "Purple Pikmin" Then
                        pic.Image = My.Resources.PikminPurple
                    ElseIf pic.Tag = "White Pikmin" Then
                        pic.Image = My.Resources.PikminWhite
                    ElseIf pic.Tag = "Raging Long Legs" Then
                        pic.Image = My.Resources.PikminRLL
                    End If
                ElseIf deckChoice = "Links" Then
                    If pic.Tag = "Twighlight Princess" Then
                        pic.Image = My.Resources.LinkTP
                    ElseIf pic.Tag = "4 Swords Adventure" Then
                        pic.Image = My.Resources.Link4Swords
                    ElseIf pic.Tag = "Windwaker" Then
                        pic.Image = My.Resources.LinkWindwaker
                    ElseIf pic.Tag = "Ocarina of Time" Then
                        pic.Image = My.Resources.LinkOcOfTime
                    ElseIf pic.Tag = "NES Link" Then
                        pic.Image = My.Resources.LinkOriginal
                    ElseIf pic.Tag = "Wolf Link" Then
                        pic.Image = My.Resources.LinkWolf
                    ElseIf pic.Tag = "The Minish Cap" Then
                        pic.Image = My.Resources.LinkMinishCap
                    ElseIf pic.Tag = "Phantom Hourglass" Then
                        pic.Image = My.Resources.LinkPHour
                    End If
                End If
            Next
        End If
        'FLIP BACK OVER IF EASY
        delay(2)
        If difficulty = "Easy" Then
            For Each pic In Me.grpCards.Controls
                delay(0.1)
                If deckChoice = "TF2" Then
                    pic.Image = My.Resources.RedCardBack
                ElseIf deckChoice = "Pikmin" Then
                    pic.Image = My.Resources.PikminBack
                ElseIf deckChoice = "Links" Then
                    pic.Image = My.Resources.LinkBack
                End If
            Next
        End If
    End Sub

    Private Sub setMovesTimes()
        'Set time/moves as universal variables so dont have to read label
        If radEasy.Checked Then
            moves = 65
            lblMoves.Text = CStr(moves)
            time = 60
            lblTimeLeft.Text = CStr(time)
            lblRealShowMoves.Text = moves
            lblRealShowTime.Text = time
        ElseIf radMedium.Checked Then
            moves = 40
            lblMoves.Text = CStr(moves)
            time = 35
            lblTimeLeft.Text = CStr(time)
            lblRealShowMoves.Text = moves
            lblRealShowTime.Text = time
        ElseIf radHard.Checked Then
            moves = 36
            lblMoves.Text = CStr(moves)
            time = 25
            lblTimeLeft.Text = CStr(time)
            lblRealShowMoves.Text = moves
            lblRealShowTime.Text = time
        End If
    End Sub
    Private Sub delay(ByVal interval As Decimal)
        Dim startTime As Decimal = Microsoft.VisualBasic.DateAndTime.Timer
        Do While Microsoft.VisualBasic.DateAndTime.Timer < startTime + interval
            Application.DoEvents()
        Loop
    End Sub

    Private Sub swapCards()
        Dim swap1 As Integer
        Dim swap2 As Integer
        Dim cup3 As String
        Randomize()
        For i = 1 To 50
            swap1 = Int(Rnd() * 16)
            swap2 = Int(Rnd() * 16)
            cup3 = cardNames(swap1)
            cardNames(swap1) = cardNames(swap2)
            cardNames(swap2) = cup3
        Next
    End Sub

    Private Sub btnPlayAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayAgain.Click
        playAgain()
    End Sub

    Private Sub btnHelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelpMenu.Click, btnHelp.Click
        MsgBox("Click 2 Cards" + Chr(13) + "Match and You get A Point" + Chr(13) + "Match All and You Win", MsgBoxStyle.Critical, "Help")
    End Sub

    Private Sub menuSet()
        'Put menu in right place
        pnlMenu.Visible = True
        pnlPlay.Visible = False
        pnlMenu.Top = 1
        pnlMenu.Left = 1
        Me.Height = pnlMenu.Height
        Me.Width = pnlMenu.Width
    End Sub

    Private Sub picsVisible()
        'All cards visible
        Dim pic As PictureBox
        For Each pic In Me.grpCards.Controls
            pic.Visible = True
        Next
    End Sub
    Private Sub disablePics()
        'All disabled
        Dim pic As PictureBox
        For Each pic In Me.grpCards.Controls
            pic.Enabled = False
        Next
    End Sub
    Private Sub enablePics()
        Dim pic As PictureBox
        For Each pic In Me.grpCards.Controls
            pic.Enabled = True
        Next
    End Sub

    Private Sub noPics()
        'No pictures, not invis
        Dim pic As PictureBox
        For Each pic In Me.grpCards.Controls
            pic.Image = Nothing
        Next
    End Sub

    Private Sub loadNames()
        'ARRAY
        If deckChoice = "TF2" Then
            cardNames(0) = "Sniper"
            cardNames(1) = "Sniper"
            cardNames(2) = "Scout"
            cardNames(3) = "Scout"
            cardNames(4) = "Demoman"
            cardNames(5) = "Demoman"
            cardNames(6) = "Heavy"
            cardNames(7) = "Heavy"
            cardNames(8) = "Pyro"
            cardNames(9) = "Pyro"
            cardNames(10) = "Engineer"
            cardNames(11) = "Engineer"
            cardNames(12) = "Soldier"
            cardNames(13) = "Soldier"
            cardNames(14) = "Spy"
            cardNames(15) = "Spy"
        ElseIf deckChoice = "Pikmin" Then
            cardNames(0) = "Olimar"
            cardNames(1) = "Olimar"
            cardNames(2) = "Louie"
            cardNames(3) = "Louie"
            cardNames(4) = "Red Pikmin"
            cardNames(5) = "Red Pikmin"
            cardNames(6) = "Blue Pikmin"
            cardNames(7) = "Blue Pikmin"
            cardNames(8) = "Yellow Pikmin"
            cardNames(9) = "Yellow Pikmin"
            cardNames(10) = "Purple Pikmin"
            cardNames(11) = "Purple Pikmin"
            cardNames(12) = "White Pikmin"
            cardNames(13) = "White Pikmin"
            cardNames(14) = "Raging Long Legs"
            cardNames(15) = "Raging Long Legs"
        ElseIf deckChoice = "Links" Then
            cardNames(0) = "Twighlight Princess"
            cardNames(1) = "Twighlight Princess"
            cardNames(2) = "4 Swords Adventure"
            cardNames(3) = "4 Swords Adventure"
            cardNames(4) = "Windwaker"
            cardNames(5) = "Windwaker"
            cardNames(6) = "Ocarina of Time"
            cardNames(7) = "Ocarina of Time"
            cardNames(8) = "NES Link"
            cardNames(9) = "NES Link"
            cardNames(10) = "Wolf Link"
            cardNames(11) = "Wolf Link"
            cardNames(12) = "Phantom Hourglass"
            cardNames(13) = "Phantom Hourglass"
            cardNames(14) = "The Minish Cap"
            cardNames(15) = "The Minish Cap"
        End If
    End Sub
    Private Sub giveTags()
        picCard0.Tag = cardNames(0)
        picCard1.Tag = cardNames(1)
        picCard2.Tag = cardNames(2)
        picCard3.Tag = cardNames(3)
        picCard4.Tag = cardNames(4)
        picCard5.Tag = cardNames(5)
        picCard6.Tag = cardNames(6)
        picCard7.Tag = cardNames(7)
        picCard8.Tag = cardNames(8)
        picCard9.Tag = cardNames(9)
        picCard10.Tag = cardNames(10)
        picCard11.Tag = cardNames(11)
        picCard12.Tag = cardNames(12)
        picCard13.Tag = cardNames(13)
        picCard14.Tag = cardNames(14)
        picCard15.Tag = cardNames(15)
    End Sub
    Private Sub frmMemory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        menuSet()
    End Sub
    Private Sub radHard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTF2.CheckedChanged, radPikmin.CheckedChanged, radLink.CheckedChanged, radMedium.CheckedChanged, radHard.CheckedChanged, radEasy.CheckedChanged
        'MAKE THEM CLICK DIFF/DECK TO CONTINUE
        If radEasy.Checked = True Or radMedium.Checked = True Or radHard.Checked = True Then
            Diffpicked = True
        End If
        If radTF2.Checked = True Or radPikmin.Checked = True Or radLink.Checked = True Then
            deckPicked = True
        End If
        If Diffpicked = True And deckPicked = True Then
            btnPlay.Enabled = True
        End If
    End Sub

    Private Sub cardBacks()
        'BACK PICTURE
        Dim pic As PictureBox
        For Each pic In Me.grpCards.Controls
            If deckChoice = "TF2" Then
                pic.Image = My.Resources.RedCardBack
            ElseIf deckChoice = "Pikmin" Then
                pic.Image = My.Resources.PikminBack
            ElseIf deckChoice = "Links" Then
                pic.Image = My.Resources.LinkBack
            End If
        Next
    End Sub

    Private Sub tmrCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountDown.Tick
        'Make time go down
        time = time - 1
        lblTimeLeft.Text = CStr(time)
        'Play tf2 countdown sounds
        If deckChoice = "TF2" Then
            If time = 5 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\5sec.wav"
            ElseIf time = 4 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\4sec.wav"
            ElseIf time = 3 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\3sec.wav"
            ElseIf time = 2 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\2sec.wav"
            ElseIf time = 1 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\1sec.wav"
            End If
            If time = 20 Then
                wmpTf2Countdown.URL = Application.StartupPath + "\ends20.wav"
            End If
        End If
        If time <= 0 Then
            tmrCountDown.Enabled = False
            If deckChoice = "TF2" Then
                wmpBack1.URL = Application.StartupPath + "\lose.wav"
            End If
            MsgBox("Time is up, game over.", MsgBoxStyle.Critical)
            disablePics()
            loss = True
        End If
    End Sub

    Private Sub btnMenuQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuQuit.Click, btnQuit.Click
        End
    End Sub

    Private Sub writeToFile()
        Name = InputBox("Enter Your Name:", "You Win!")
        If difficulty = "Hard" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\winNamesHard.txt", Name + Chr(13), True)
        ElseIf difficulty = "Medium" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\winNamesMed.txt", Name + Chr(13), True)
        ElseIf difficulty = "Easy" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\winNamesEasy.txt", Name + Chr(13), True)
        End If
    End Sub

    Private Sub btnEasyWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEasyWin.Click
        Dim f As String
        f = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\winNamesEasy.txt")
        MsgBox(f, MsgBoxStyle.Exclamation, "Winners")
    End Sub

    Private Sub btnMedWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedWin.Click
        Dim f As String
        f = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\winNamesMed.txt")
        MsgBox(f, MsgBoxStyle.Exclamation, "Winners")
    End Sub

    Private Sub btnHardWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHardWin.Click
        Dim f As String
        f = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\winNamesHard.txt")
        MsgBox(f, MsgBoxStyle.Exclamation, "Winners")
    End Sub
End Class