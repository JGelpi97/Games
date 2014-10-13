<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMemory))
        Me.pnlMenu = New System.Windows.Forms.Panel
        Me.btnMenuQuit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ulblDifficulty = New System.Windows.Forms.Label
        Me.spicMenu1 = New System.Windows.Forms.PictureBox
        Me.ulblDeck = New System.Windows.Forms.PictureBox
        Me.spicMenuTF2 = New System.Windows.Forms.PictureBox
        Me.btnHelpMenu = New System.Windows.Forms.Button
        Me.btnPlay = New System.Windows.Forms.Button
        Me.grpDifficulty = New System.Windows.Forms.GroupBox
        Me.radMedium = New System.Windows.Forms.RadioButton
        Me.radEasy = New System.Windows.Forms.RadioButton
        Me.radHard = New System.Windows.Forms.RadioButton
        Me.grpDeck = New System.Windows.Forms.GroupBox
        Me.radLink = New System.Windows.Forms.RadioButton
        Me.radTF2 = New System.Windows.Forms.RadioButton
        Me.radPikmin = New System.Windows.Forms.RadioButton
        Me.pnlPlay = New System.Windows.Forms.Panel
        Me.btnQuit = New System.Windows.Forms.Button
        Me.lblRealShowDiff = New System.Windows.Forms.Label
        Me.lblRealShowTime = New System.Windows.Forms.Label
        Me.lblRealShowMoves = New System.Windows.Forms.Label
        Me.lblShowDiff = New System.Windows.Forms.Label
        Me.lblShowTime = New System.Windows.Forms.Label
        Me.lblShowMoves = New System.Windows.Forms.Label
        Me.lblTimeLeft = New System.Windows.Forms.Label
        Me.slblTimeLeft = New System.Windows.Forms.Label
        Me.slblMoves = New System.Windows.Forms.Label
        Me.lblMoves = New System.Windows.Forms.Label
        Me.btnBackToMenu = New System.Windows.Forms.Button
        Me.slblPoints = New System.Windows.Forms.Label
        Me.btnHelp = New System.Windows.Forms.Button
        Me.btnPlayAgain = New System.Windows.Forms.Button
        Me.lblPoints = New System.Windows.Forms.Label
        Me.lblCard2 = New System.Windows.Forms.Label
        Me.lblCard1 = New System.Windows.Forms.Label
        Me.slblCard2 = New System.Windows.Forms.Label
        Me.slblCard1 = New System.Windows.Forms.Label
        Me.grpCards = New System.Windows.Forms.GroupBox
        Me.picCard0 = New System.Windows.Forms.PictureBox
        Me.picCard1 = New System.Windows.Forms.PictureBox
        Me.picCard2 = New System.Windows.Forms.PictureBox
        Me.picCard3 = New System.Windows.Forms.PictureBox
        Me.picCard4 = New System.Windows.Forms.PictureBox
        Me.picCard5 = New System.Windows.Forms.PictureBox
        Me.picCard6 = New System.Windows.Forms.PictureBox
        Me.picCard7 = New System.Windows.Forms.PictureBox
        Me.picCard8 = New System.Windows.Forms.PictureBox
        Me.picCard9 = New System.Windows.Forms.PictureBox
        Me.picCard10 = New System.Windows.Forms.PictureBox
        Me.picCard11 = New System.Windows.Forms.PictureBox
        Me.picCard12 = New System.Windows.Forms.PictureBox
        Me.picCard13 = New System.Windows.Forms.PictureBox
        Me.picCard14 = New System.Windows.Forms.PictureBox
        Me.picCard15 = New System.Windows.Forms.PictureBox
        Me.wmpBack1 = New AxWMPLib.AxWindowsMediaPlayer
        Me.tmrCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.wmpTf2Countdown = New AxWMPLib.AxWindowsMediaPlayer
        Me.slblWiners = New System.Windows.Forms.Label
        Me.btnEasyWin = New System.Windows.Forms.Button
        Me.btnHardWin = New System.Windows.Forms.Button
        Me.btnMedWin = New System.Windows.Forms.Button
        Me.slblMemory = New System.Windows.Forms.Label
        Me.pnlMenu.SuspendLayout()
        CType(Me.spicMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ulblDeck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spicMenuTF2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDifficulty.SuspendLayout()
        Me.grpDeck.SuspendLayout()
        Me.pnlPlay.SuspendLayout()
        Me.grpCards.SuspendLayout()
        CType(Me.picCard0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCard15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wmpBack1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wmpTf2Countdown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.slblMemory)
        Me.pnlMenu.Controls.Add(Me.btnMedWin)
        Me.pnlMenu.Controls.Add(Me.btnHardWin)
        Me.pnlMenu.Controls.Add(Me.btnEasyWin)
        Me.pnlMenu.Controls.Add(Me.slblWiners)
        Me.pnlMenu.Controls.Add(Me.btnMenuQuit)
        Me.pnlMenu.Controls.Add(Me.Label1)
        Me.pnlMenu.Controls.Add(Me.ulblDifficulty)
        Me.pnlMenu.Controls.Add(Me.spicMenu1)
        Me.pnlMenu.Controls.Add(Me.ulblDeck)
        Me.pnlMenu.Controls.Add(Me.spicMenuTF2)
        Me.pnlMenu.Controls.Add(Me.btnHelpMenu)
        Me.pnlMenu.Controls.Add(Me.btnPlay)
        Me.pnlMenu.Controls.Add(Me.grpDifficulty)
        Me.pnlMenu.Controls.Add(Me.grpDeck)
        Me.pnlMenu.Location = New System.Drawing.Point(68, 22)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(519, 475)
        Me.pnlMenu.TabIndex = 1
        '
        'btnMenuQuit
        '
        Me.btnMenuQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenuQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMenuQuit.Location = New System.Drawing.Point(195, 129)
        Me.btnMenuQuit.Name = "btnMenuQuit"
        Me.btnMenuQuit.Size = New System.Drawing.Size(90, 30)
        Me.btnMenuQuit.TabIndex = 15
        Me.btnMenuQuit.Text = "Quit"
        Me.btnMenuQuit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Deck:"
        '
        'ulblDifficulty
        '
        Me.ulblDifficulty.AutoSize = True
        Me.ulblDifficulty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ulblDifficulty.Location = New System.Drawing.Point(3, 207)
        Me.ulblDifficulty.Name = "ulblDifficulty"
        Me.ulblDifficulty.Size = New System.Drawing.Size(65, 17)
        Me.ulblDifficulty.TabIndex = 5
        Me.ulblDifficulty.Text = "Difficulty:"
        '
        'spicMenu1
        '
        Me.spicMenu1.Image = Global.Memory_1.My.Resources.Resources.PikminBack
        Me.spicMenu1.Location = New System.Drawing.Point(179, 270)
        Me.spicMenu1.Name = "spicMenu1"
        Me.spicMenu1.Size = New System.Drawing.Size(150, 150)
        Me.spicMenu1.TabIndex = 4
        Me.spicMenu1.TabStop = False
        '
        'ulblDeck
        '
        Me.ulblDeck.Image = Global.Memory_1.My.Resources.Resources.LinkBack
        Me.ulblDeck.Location = New System.Drawing.Point(335, 270)
        Me.ulblDeck.Name = "ulblDeck"
        Me.ulblDeck.Size = New System.Drawing.Size(150, 150)
        Me.ulblDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ulblDeck.TabIndex = 3
        Me.ulblDeck.TabStop = False
        '
        'spicMenuTF2
        '
        Me.spicMenuTF2.Image = Global.Memory_1.My.Resources.Resources.RedCardBack
        Me.spicMenuTF2.Location = New System.Drawing.Point(23, 270)
        Me.spicMenuTF2.Name = "spicMenuTF2"
        Me.spicMenuTF2.Size = New System.Drawing.Size(150, 150)
        Me.spicMenuTF2.TabIndex = 2
        Me.spicMenuTF2.TabStop = False
        '
        'btnHelpMenu
        '
        Me.btnHelpMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelpMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHelpMenu.Location = New System.Drawing.Point(195, 93)
        Me.btnHelpMenu.Name = "btnHelpMenu"
        Me.btnHelpMenu.Size = New System.Drawing.Size(90, 30)
        Me.btnHelpMenu.TabIndex = 1
        Me.btnHelpMenu.Text = "Help"
        Me.btnHelpMenu.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPlay.Enabled = False
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPlay.Location = New System.Drawing.Point(195, 57)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(90, 30)
        Me.btnPlay.TabIndex = 0
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'grpDifficulty
        '
        Me.grpDifficulty.Controls.Add(Me.radMedium)
        Me.grpDifficulty.Controls.Add(Me.radEasy)
        Me.grpDifficulty.Controls.Add(Me.radHard)
        Me.grpDifficulty.Location = New System.Drawing.Point(74, 199)
        Me.grpDifficulty.Name = "grpDifficulty"
        Me.grpDifficulty.Size = New System.Drawing.Size(378, 27)
        Me.grpDifficulty.TabIndex = 13
        Me.grpDifficulty.TabStop = False
        '
        'radMedium
        '
        Me.radMedium.AutoSize = True
        Me.radMedium.Location = New System.Drawing.Point(149, 8)
        Me.radMedium.Name = "radMedium"
        Me.radMedium.Size = New System.Drawing.Size(62, 17)
        Me.radMedium.TabIndex = 8
        Me.radMedium.TabStop = True
        Me.radMedium.Text = "Medium"
        Me.radMedium.UseVisualStyleBackColor = True
        '
        'radEasy
        '
        Me.radEasy.AutoSize = True
        Me.radEasy.Location = New System.Drawing.Point(5, 8)
        Me.radEasy.Name = "radEasy"
        Me.radEasy.Size = New System.Drawing.Size(48, 17)
        Me.radEasy.TabIndex = 6
        Me.radEasy.TabStop = True
        Me.radEasy.Text = "Easy"
        Me.radEasy.UseVisualStyleBackColor = True
        '
        'radHard
        '
        Me.radHard.AutoSize = True
        Me.radHard.Location = New System.Drawing.Point(308, 8)
        Me.radHard.Name = "radHard"
        Me.radHard.Size = New System.Drawing.Size(48, 17)
        Me.radHard.TabIndex = 7
        Me.radHard.TabStop = True
        Me.radHard.Text = "Hard"
        Me.radHard.UseVisualStyleBackColor = True
        '
        'grpDeck
        '
        Me.grpDeck.Controls.Add(Me.radLink)
        Me.grpDeck.Controls.Add(Me.radTF2)
        Me.grpDeck.Controls.Add(Me.radPikmin)
        Me.grpDeck.Location = New System.Drawing.Point(74, 234)
        Me.grpDeck.Name = "grpDeck"
        Me.grpDeck.Size = New System.Drawing.Size(378, 27)
        Me.grpDeck.TabIndex = 14
        Me.grpDeck.TabStop = False
        '
        'radLink
        '
        Me.radLink.AutoSize = True
        Me.radLink.Location = New System.Drawing.Point(308, 9)
        Me.radLink.Name = "radLink"
        Me.radLink.Size = New System.Drawing.Size(50, 17)
        Me.radLink.TabIndex = 12
        Me.radLink.TabStop = True
        Me.radLink.Text = "Links"
        Me.radLink.UseVisualStyleBackColor = True
        '
        'radTF2
        '
        Me.radTF2.AutoSize = True
        Me.radTF2.Location = New System.Drawing.Point(5, 9)
        Me.radTF2.Name = "radTF2"
        Me.radTF2.Size = New System.Drawing.Size(44, 17)
        Me.radTF2.TabIndex = 10
        Me.radTF2.TabStop = True
        Me.radTF2.Text = "TF2"
        Me.radTF2.UseVisualStyleBackColor = True
        '
        'radPikmin
        '
        Me.radPikmin.AutoSize = True
        Me.radPikmin.Location = New System.Drawing.Point(149, 9)
        Me.radPikmin.Name = "radPikmin"
        Me.radPikmin.Size = New System.Drawing.Size(56, 17)
        Me.radPikmin.TabIndex = 11
        Me.radPikmin.TabStop = True
        Me.radPikmin.Text = "Pikmin"
        Me.radPikmin.UseVisualStyleBackColor = True
        '
        'pnlPlay
        '
        Me.pnlPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlPlay.Controls.Add(Me.btnQuit)
        Me.pnlPlay.Controls.Add(Me.lblRealShowDiff)
        Me.pnlPlay.Controls.Add(Me.lblRealShowTime)
        Me.pnlPlay.Controls.Add(Me.lblRealShowMoves)
        Me.pnlPlay.Controls.Add(Me.lblShowDiff)
        Me.pnlPlay.Controls.Add(Me.lblShowTime)
        Me.pnlPlay.Controls.Add(Me.lblShowMoves)
        Me.pnlPlay.Controls.Add(Me.lblTimeLeft)
        Me.pnlPlay.Controls.Add(Me.slblTimeLeft)
        Me.pnlPlay.Controls.Add(Me.slblMoves)
        Me.pnlPlay.Controls.Add(Me.lblMoves)
        Me.pnlPlay.Controls.Add(Me.btnBackToMenu)
        Me.pnlPlay.Controls.Add(Me.slblPoints)
        Me.pnlPlay.Controls.Add(Me.btnHelp)
        Me.pnlPlay.Controls.Add(Me.btnPlayAgain)
        Me.pnlPlay.Controls.Add(Me.lblPoints)
        Me.pnlPlay.Controls.Add(Me.lblCard2)
        Me.pnlPlay.Controls.Add(Me.lblCard1)
        Me.pnlPlay.Controls.Add(Me.slblCard2)
        Me.pnlPlay.Controls.Add(Me.slblCard1)
        Me.pnlPlay.Controls.Add(Me.grpCards)
        Me.pnlPlay.Location = New System.Drawing.Point(664, 342)
        Me.pnlPlay.Name = "pnlPlay"
        Me.pnlPlay.Size = New System.Drawing.Size(1000, 700)
        Me.pnlPlay.TabIndex = 0
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(695, 594)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(56, 37)
        Me.btnQuit.TabIndex = 22
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'lblRealShowDiff
        '
        Me.lblRealShowDiff.AutoSize = True
        Me.lblRealShowDiff.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealShowDiff.Location = New System.Drawing.Point(732, 548)
        Me.lblRealShowDiff.Name = "lblRealShowDiff"
        Me.lblRealShowDiff.Size = New System.Drawing.Size(58, 19)
        Me.lblRealShowDiff.TabIndex = 21
        Me.lblRealShowDiff.Text = "Label4"
        '
        'lblRealShowTime
        '
        Me.lblRealShowTime.AutoSize = True
        Me.lblRealShowTime.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealShowTime.Location = New System.Drawing.Point(696, 526)
        Me.lblRealShowTime.Name = "lblRealShowTime"
        Me.lblRealShowTime.Size = New System.Drawing.Size(57, 19)
        Me.lblRealShowTime.TabIndex = 20
        Me.lblRealShowTime.Text = "Label3"
        '
        'lblRealShowMoves
        '
        Me.lblRealShowMoves.AutoSize = True
        Me.lblRealShowMoves.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealShowMoves.Location = New System.Drawing.Point(705, 505)
        Me.lblRealShowMoves.Name = "lblRealShowMoves"
        Me.lblRealShowMoves.Size = New System.Drawing.Size(57, 19)
        Me.lblRealShowMoves.TabIndex = 19
        Me.lblRealShowMoves.Text = "Label2"
        '
        'lblShowDiff
        '
        Me.lblShowDiff.AutoSize = True
        Me.lblShowDiff.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowDiff.Location = New System.Drawing.Point(645, 548)
        Me.lblShowDiff.Name = "lblShowDiff"
        Me.lblShowDiff.Size = New System.Drawing.Size(93, 19)
        Me.lblShowDiff.TabIndex = 18
        Me.lblShowDiff.Text = "Difficulty: "
        '
        'lblShowTime
        '
        Me.lblShowTime.AutoSize = True
        Me.lblShowTime.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowTime.Location = New System.Drawing.Point(646, 526)
        Me.lblShowTime.Name = "lblShowTime"
        Me.lblShowTime.Size = New System.Drawing.Size(55, 19)
        Me.lblShowTime.TabIndex = 17
        Me.lblShowTime.Text = "Time: "
        '
        'lblShowMoves
        '
        Me.lblShowMoves.AutoSize = True
        Me.lblShowMoves.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowMoves.Location = New System.Drawing.Point(646, 505)
        Me.lblShowMoves.Name = "lblShowMoves"
        Me.lblShowMoves.Size = New System.Drawing.Size(66, 19)
        Me.lblShowMoves.TabIndex = 16
        Me.lblShowMoves.Text = "Moves: "
        '
        'lblTimeLeft
        '
        Me.lblTimeLeft.AutoSize = True
        Me.lblTimeLeft.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeLeft.Location = New System.Drawing.Point(733, 323)
        Me.lblTimeLeft.Name = "lblTimeLeft"
        Me.lblTimeLeft.Size = New System.Drawing.Size(18, 19)
        Me.lblTimeLeft.TabIndex = 15
        Me.lblTimeLeft.Text = "0"
        '
        'slblTimeLeft
        '
        Me.slblTimeLeft.AutoSize = True
        Me.slblTimeLeft.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblTimeLeft.Location = New System.Drawing.Point(650, 325)
        Me.slblTimeLeft.Name = "slblTimeLeft"
        Me.slblTimeLeft.Size = New System.Drawing.Size(77, 17)
        Me.slblTimeLeft.TabIndex = 14
        Me.slblTimeLeft.Text = "Time Left:"
        '
        'slblMoves
        '
        Me.slblMoves.AutoSize = True
        Me.slblMoves.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblMoves.Location = New System.Drawing.Point(645, 291)
        Me.slblMoves.Name = "slblMoves"
        Me.slblMoves.Size = New System.Drawing.Size(88, 17)
        Me.slblMoves.TabIndex = 13
        Me.slblMoves.Text = "Moves Left:"
        '
        'lblMoves
        '
        Me.lblMoves.AutoSize = True
        Me.lblMoves.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoves.Location = New System.Drawing.Point(739, 291)
        Me.lblMoves.Name = "lblMoves"
        Me.lblMoves.Size = New System.Drawing.Size(18, 19)
        Me.lblMoves.TabIndex = 12
        Me.lblMoves.Text = "0"
        '
        'btnBackToMenu
        '
        Me.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBackToMenu.Location = New System.Drawing.Point(659, 106)
        Me.btnBackToMenu.Name = "btnBackToMenu"
        Me.btnBackToMenu.Size = New System.Drawing.Size(100, 30)
        Me.btnBackToMenu.TabIndex = 11
        Me.btnBackToMenu.Text = "Menu"
        Me.btnBackToMenu.UseVisualStyleBackColor = True
        '
        'slblPoints
        '
        Me.slblPoints.AutoSize = True
        Me.slblPoints.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblPoints.Location = New System.Drawing.Point(644, 260)
        Me.slblPoints.Name = "slblPoints"
        Me.slblPoints.Size = New System.Drawing.Size(59, 19)
        Me.slblPoints.TabIndex = 10
        Me.slblPoints.Text = "Points:"
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHelp.Location = New System.Drawing.Point(659, 70)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(100, 30)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnPlayAgain
        '
        Me.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPlayAgain.Location = New System.Drawing.Point(659, 34)
        Me.btnPlayAgain.Name = "btnPlayAgain"
        Me.btnPlayAgain.Size = New System.Drawing.Size(100, 30)
        Me.btnPlayAgain.TabIndex = 8
        Me.btnPlayAgain.Text = "Play Again"
        Me.btnPlayAgain.UseVisualStyleBackColor = True
        '
        'lblPoints
        '
        Me.lblPoints.AutoSize = True
        Me.lblPoints.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoints.Location = New System.Drawing.Point(709, 260)
        Me.lblPoints.Name = "lblPoints"
        Me.lblPoints.Size = New System.Drawing.Size(18, 19)
        Me.lblPoints.TabIndex = 7
        Me.lblPoints.Text = "0"
        '
        'lblCard2
        '
        Me.lblCard2.AutoSize = True
        Me.lblCard2.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCard2.Location = New System.Drawing.Point(712, 229)
        Me.lblCard2.Name = "lblCard2"
        Me.lblCard2.Size = New System.Drawing.Size(0, 19)
        Me.lblCard2.TabIndex = 6
        '
        'lblCard1
        '
        Me.lblCard1.AutoSize = True
        Me.lblCard1.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCard1.Location = New System.Drawing.Point(712, 197)
        Me.lblCard1.Name = "lblCard1"
        Me.lblCard1.Size = New System.Drawing.Size(0, 19)
        Me.lblCard1.TabIndex = 5
        '
        'slblCard2
        '
        Me.slblCard2.AutoSize = True
        Me.slblCard2.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblCard2.Location = New System.Drawing.Point(644, 229)
        Me.slblCard2.Name = "slblCard2"
        Me.slblCard2.Size = New System.Drawing.Size(62, 19)
        Me.slblCard2.TabIndex = 4
        Me.slblCard2.Text = "Card 2:"
        '
        'slblCard1
        '
        Me.slblCard1.AutoSize = True
        Me.slblCard1.Font = New System.Drawing.Font("Lucida Calligraphy", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblCard1.Location = New System.Drawing.Point(644, 197)
        Me.slblCard1.Name = "slblCard1"
        Me.slblCard1.Size = New System.Drawing.Size(60, 19)
        Me.slblCard1.TabIndex = 3
        Me.slblCard1.Text = "Card 1:"
        '
        'grpCards
        '
        Me.grpCards.BackgroundImage = Global.Memory_1.My.Resources.Resources.Back
        Me.grpCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpCards.Controls.Add(Me.picCard0)
        Me.grpCards.Controls.Add(Me.picCard1)
        Me.grpCards.Controls.Add(Me.picCard2)
        Me.grpCards.Controls.Add(Me.picCard3)
        Me.grpCards.Controls.Add(Me.picCard4)
        Me.grpCards.Controls.Add(Me.picCard5)
        Me.grpCards.Controls.Add(Me.picCard6)
        Me.grpCards.Controls.Add(Me.picCard7)
        Me.grpCards.Controls.Add(Me.picCard8)
        Me.grpCards.Controls.Add(Me.picCard9)
        Me.grpCards.Controls.Add(Me.picCard10)
        Me.grpCards.Controls.Add(Me.picCard11)
        Me.grpCards.Controls.Add(Me.picCard12)
        Me.grpCards.Controls.Add(Me.picCard13)
        Me.grpCards.Controls.Add(Me.picCard14)
        Me.grpCards.Controls.Add(Me.picCard15)
        Me.grpCards.Location = New System.Drawing.Point(3, -6)
        Me.grpCards.Name = "grpCards"
        Me.grpCards.Size = New System.Drawing.Size(635, 648)
        Me.grpCards.TabIndex = 2
        Me.grpCards.TabStop = False
        '
        'picCard0
        '
        Me.picCard0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard0.Location = New System.Drawing.Point(6, 19)
        Me.picCard0.Name = "picCard0"
        Me.picCard0.Size = New System.Drawing.Size(150, 150)
        Me.picCard0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard0.TabIndex = 15
        Me.picCard0.TabStop = False
        '
        'picCard1
        '
        Me.picCard1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard1.Location = New System.Drawing.Point(162, 19)
        Me.picCard1.Name = "picCard1"
        Me.picCard1.Size = New System.Drawing.Size(150, 150)
        Me.picCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard1.TabIndex = 14
        Me.picCard1.TabStop = False
        '
        'picCard2
        '
        Me.picCard2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard2.Location = New System.Drawing.Point(318, 19)
        Me.picCard2.Name = "picCard2"
        Me.picCard2.Size = New System.Drawing.Size(150, 150)
        Me.picCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard2.TabIndex = 13
        Me.picCard2.TabStop = False
        '
        'picCard3
        '
        Me.picCard3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard3.Location = New System.Drawing.Point(474, 19)
        Me.picCard3.Name = "picCard3"
        Me.picCard3.Size = New System.Drawing.Size(150, 150)
        Me.picCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard3.TabIndex = 12
        Me.picCard3.TabStop = False
        '
        'picCard4
        '
        Me.picCard4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard4.Location = New System.Drawing.Point(6, 175)
        Me.picCard4.Name = "picCard4"
        Me.picCard4.Size = New System.Drawing.Size(150, 150)
        Me.picCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard4.TabIndex = 11
        Me.picCard4.TabStop = False
        '
        'picCard5
        '
        Me.picCard5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard5.Location = New System.Drawing.Point(162, 175)
        Me.picCard5.Name = "picCard5"
        Me.picCard5.Size = New System.Drawing.Size(150, 150)
        Me.picCard5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard5.TabIndex = 10
        Me.picCard5.TabStop = False
        '
        'picCard6
        '
        Me.picCard6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard6.Location = New System.Drawing.Point(318, 175)
        Me.picCard6.Name = "picCard6"
        Me.picCard6.Size = New System.Drawing.Size(150, 150)
        Me.picCard6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard6.TabIndex = 9
        Me.picCard6.TabStop = False
        '
        'picCard7
        '
        Me.picCard7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard7.Location = New System.Drawing.Point(474, 175)
        Me.picCard7.Name = "picCard7"
        Me.picCard7.Size = New System.Drawing.Size(150, 150)
        Me.picCard7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard7.TabIndex = 8
        Me.picCard7.TabStop = False
        '
        'picCard8
        '
        Me.picCard8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard8.Location = New System.Drawing.Point(6, 331)
        Me.picCard8.Name = "picCard8"
        Me.picCard8.Size = New System.Drawing.Size(150, 150)
        Me.picCard8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard8.TabIndex = 7
        Me.picCard8.TabStop = False
        '
        'picCard9
        '
        Me.picCard9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard9.Location = New System.Drawing.Point(162, 331)
        Me.picCard9.Name = "picCard9"
        Me.picCard9.Size = New System.Drawing.Size(150, 150)
        Me.picCard9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard9.TabIndex = 6
        Me.picCard9.TabStop = False
        '
        'picCard10
        '
        Me.picCard10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard10.Location = New System.Drawing.Point(318, 331)
        Me.picCard10.Name = "picCard10"
        Me.picCard10.Size = New System.Drawing.Size(150, 150)
        Me.picCard10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard10.TabIndex = 5
        Me.picCard10.TabStop = False
        '
        'picCard11
        '
        Me.picCard11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard11.Location = New System.Drawing.Point(474, 331)
        Me.picCard11.Name = "picCard11"
        Me.picCard11.Size = New System.Drawing.Size(150, 150)
        Me.picCard11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard11.TabIndex = 4
        Me.picCard11.TabStop = False
        '
        'picCard12
        '
        Me.picCard12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard12.Location = New System.Drawing.Point(6, 487)
        Me.picCard12.Name = "picCard12"
        Me.picCard12.Size = New System.Drawing.Size(150, 150)
        Me.picCard12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard12.TabIndex = 3
        Me.picCard12.TabStop = False
        '
        'picCard13
        '
        Me.picCard13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard13.Location = New System.Drawing.Point(162, 487)
        Me.picCard13.Name = "picCard13"
        Me.picCard13.Size = New System.Drawing.Size(150, 150)
        Me.picCard13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard13.TabIndex = 2
        Me.picCard13.TabStop = False
        '
        'picCard14
        '
        Me.picCard14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard14.Location = New System.Drawing.Point(318, 487)
        Me.picCard14.Name = "picCard14"
        Me.picCard14.Size = New System.Drawing.Size(150, 150)
        Me.picCard14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard14.TabIndex = 1
        Me.picCard14.TabStop = False
        '
        'picCard15
        '
        Me.picCard15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCard15.Location = New System.Drawing.Point(474, 487)
        Me.picCard15.Name = "picCard15"
        Me.picCard15.Size = New System.Drawing.Size(150, 150)
        Me.picCard15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCard15.TabIndex = 0
        Me.picCard15.TabStop = False
        '
        'wmpBack1
        '
        Me.wmpBack1.Enabled = True
        Me.wmpBack1.Location = New System.Drawing.Point(103, 96)
        Me.wmpBack1.Name = "wmpBack1"
        Me.wmpBack1.OcxState = CType(resources.GetObject("wmpBack1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpBack1.Size = New System.Drawing.Size(75, 23)
        Me.wmpBack1.TabIndex = 2
        Me.wmpBack1.Visible = False
        '
        'tmrCountDown
        '
        Me.tmrCountDown.Interval = 1000
        '
        'wmpTf2Countdown
        '
        Me.wmpTf2Countdown.Enabled = True
        Me.wmpTf2Countdown.Location = New System.Drawing.Point(414, 50)
        Me.wmpTf2Countdown.Name = "wmpTf2Countdown"
        Me.wmpTf2Countdown.OcxState = CType(resources.GetObject("wmpTf2Countdown.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpTf2Countdown.Size = New System.Drawing.Size(75, 23)
        Me.wmpTf2Countdown.TabIndex = 3
        Me.wmpTf2Countdown.Visible = False
        '
        'slblWiners
        '
        Me.slblWiners.AutoSize = True
        Me.slblWiners.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblWiners.Location = New System.Drawing.Point(390, 33)
        Me.slblWiners.Name = "slblWiners"
        Me.slblWiners.Size = New System.Drawing.Size(59, 17)
        Me.slblWiners.TabIndex = 16
        Me.slblWiners.Text = "Winars"
        '
        'btnEasyWin
        '
        Me.btnEasyWin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEasyWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEasyWin.Location = New System.Drawing.Point(372, 57)
        Me.btnEasyWin.Name = "btnEasyWin"
        Me.btnEasyWin.Size = New System.Drawing.Size(90, 30)
        Me.btnEasyWin.TabIndex = 17
        Me.btnEasyWin.Text = "Easy"
        Me.btnEasyWin.UseVisualStyleBackColor = True
        '
        'btnHardWin
        '
        Me.btnHardWin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHardWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHardWin.Location = New System.Drawing.Point(372, 129)
        Me.btnHardWin.Name = "btnHardWin"
        Me.btnHardWin.Size = New System.Drawing.Size(90, 30)
        Me.btnHardWin.TabIndex = 18
        Me.btnHardWin.Text = "Hard"
        Me.btnHardWin.UseVisualStyleBackColor = True
        '
        'btnMedWin
        '
        Me.btnMedWin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMedWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMedWin.Location = New System.Drawing.Point(372, 93)
        Me.btnMedWin.Name = "btnMedWin"
        Me.btnMedWin.Size = New System.Drawing.Size(90, 30)
        Me.btnMedWin.TabIndex = 19
        Me.btnMedWin.Text = "Medium"
        Me.btnMedWin.UseVisualStyleBackColor = True
        '
        'slblMemory
        '
        Me.slblMemory.AutoSize = True
        Me.slblMemory.Font = New System.Drawing.Font("Lucida Calligraphy", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblMemory.Location = New System.Drawing.Point(17, 74)
        Me.slblMemory.Name = "slblMemory"
        Me.slblMemory.Size = New System.Drawing.Size(145, 36)
        Me.slblMemory.TabIndex = 20
        Me.slblMemory.Text = "Memory"
        '
        'frmMemory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 666)
        Me.Controls.Add(Me.pnlPlay)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.wmpBack1)
        Me.Controls.Add(Me.wmpTf2Countdown)
        Me.Name = "frmMemory"
        Me.Text = "Memory"
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        CType(Me.spicMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ulblDeck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spicMenuTF2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDifficulty.ResumeLayout(False)
        Me.grpDifficulty.PerformLayout()
        Me.grpDeck.ResumeLayout(False)
        Me.grpDeck.PerformLayout()
        Me.pnlPlay.ResumeLayout(False)
        Me.pnlPlay.PerformLayout()
        Me.grpCards.ResumeLayout(False)
        CType(Me.picCard0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCard15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wmpBack1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wmpTf2Countdown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPlay As System.Windows.Forms.Panel
    Friend WithEvents grpCards As System.Windows.Forms.GroupBox
    Friend WithEvents slblCard2 As System.Windows.Forms.Label
    Friend WithEvents slblCard1 As System.Windows.Forms.Label
    Friend WithEvents lblCard2 As System.Windows.Forms.Label
    Friend WithEvents lblCard1 As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents lblPoints As System.Windows.Forms.Label
    Friend WithEvents btnPlayAgain As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents slblPoints As System.Windows.Forms.Label
    Friend WithEvents btnHelpMenu As System.Windows.Forms.Button
    Friend WithEvents spicMenu1 As System.Windows.Forms.PictureBox
    Friend WithEvents ulblDeck As System.Windows.Forms.PictureBox
    Friend WithEvents spicMenuTF2 As System.Windows.Forms.PictureBox
    Friend WithEvents ulblDifficulty As System.Windows.Forms.Label
    Friend WithEvents radMedium As System.Windows.Forms.RadioButton
    Friend WithEvents radHard As System.Windows.Forms.RadioButton
    Friend WithEvents radEasy As System.Windows.Forms.RadioButton
    Friend WithEvents btnBackToMenu As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents radLink As System.Windows.Forms.RadioButton
    Friend WithEvents radPikmin As System.Windows.Forms.RadioButton
    Friend WithEvents radTF2 As System.Windows.Forms.RadioButton
    Friend WithEvents grpDifficulty As System.Windows.Forms.GroupBox
    Friend WithEvents grpDeck As System.Windows.Forms.GroupBox
    Friend WithEvents lblMoves As System.Windows.Forms.Label
    Friend WithEvents slblMoves As System.Windows.Forms.Label
    Friend WithEvents wmpBack1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents lblTimeLeft As System.Windows.Forms.Label
    Friend WithEvents slblTimeLeft As System.Windows.Forms.Label
    Friend WithEvents tmrCountDown As System.Windows.Forms.Timer
    Friend WithEvents lblShowDiff As System.Windows.Forms.Label
    Friend WithEvents lblShowTime As System.Windows.Forms.Label
    Friend WithEvents lblShowMoves As System.Windows.Forms.Label
    Friend WithEvents wmpTf2Countdown As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents picCard0 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard1 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard2 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard3 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard4 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard5 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard6 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard7 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard8 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard9 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard10 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard11 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard12 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard13 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard14 As System.Windows.Forms.PictureBox
    Friend WithEvents picCard15 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRealShowDiff As System.Windows.Forms.Label
    Friend WithEvents lblRealShowTime As System.Windows.Forms.Label
    Friend WithEvents lblRealShowMoves As System.Windows.Forms.Label
    Friend WithEvents btnMenuQuit As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents slblMemory As System.Windows.Forms.Label
    Friend WithEvents btnMedWin As System.Windows.Forms.Button
    Friend WithEvents btnHardWin As System.Windows.Forms.Button
    Friend WithEvents btnEasyWin As System.Windows.Forms.Button
    Friend WithEvents slblWiners As System.Windows.Forms.Label

End Class
