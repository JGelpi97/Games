Imports System.IO

Public Class Form1
    Dim lPos As Integer = 10
    Dim tPos As Integer = 80
    Dim tileArray(0 To 500) As PictureBox
    Dim checked(0 To 500, 0 To 500) As Boolean
    Dim arrayCounter As Integer = 0
    Dim minesArray(0 To 500, 0 To 500) As Boolean
    Dim flagsArray(0 To 500, 0 To 500) As Boolean
    Dim flagged As Boolean
    Dim numOfRows As Integer
    Dim numOfColumns As Integer
    Dim numOfMines As Integer
    Dim started As Boolean = False
    Dim time As Integer = 0
    Dim spacesClicked As Integer = 0
    Dim namesArray(0 To 2) As String
    Dim scoresArray(0 To 2) As String
    'tileArray(randCol + txtColumns.Text * randRow) 
    Dim difficulty As String

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        numOfRows = txtRows.Text
        numOfColumns = txtColumns.Text
        numOfMines = txtMineNum.Text
        If (numOfColumns - 1) * (numOfRows - 1) < numOfMines Then
            MsgBox("Too many mines", MsgBoxStyle.Exclamation, "Hey!")
        Else
            newGameStuff()
            difficulty = "C"
        End If
    End Sub

    Private Sub createBoard()
        pnlCreate.Visible = False
        lPos = 10
        tPos = 80

        For i = 0 To arrayCounter - 1 'Dispose all tiles
            tileArray(i).Dispose()
        Next

        arrayCounter = 0
        If numOfRows * numOfColumns < 499 Then
            For i = 0 To numOfRows - 1
                lPos = 10
                For j = 0 To numOfColumns - 1
                    Dim tile As New PictureBox
                    tileArray(arrayCounter) = tile 'Add tile to array
                    With tile
                        .Image = My.Resources.TileUp
                        .Tag = j + numOfColumns * i
                        .Name = "tile"
                        .Height = 25
                        .Width = 25
                        .BackColor = Color.Black
                        .Left = lPos
                        .Top = tPos
                        AddHandler tile.Click, AddressOf mineClick_Click
                        AddHandler tile.MouseDown, AddressOf mineClick_MouseDown
                        Me.Controls.Add(tile)
                    End With
                    arrayCounter += 1
                    lPos += 26
                Next
                tPos = tPos + 26
            Next
            placeMines(numOfMines)
            For i = 0 To 500
                For j = 0 To 500
                    flagsArray(i, j) = False
                Next
            Next
            For i = 0 To 500
                For j = 0 To 500
                    checked(i, j) = False
                Next
            Next
        Else
            MsgBox("Too big of a board.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub placeMines(ByVal mines As Integer)
        For i = 0 To 500
            For j = 0 To 500
                minesArray(i, j) = False
            Next
        Next
        Dim mineCount As Integer = 0
        Do Until mineCount = mines
            Dim randRow As Integer = Int(Rnd() * numOfRows)
            Dim randCol As Integer = Int(Rnd() * numOfColumns)
            If minesArray(randRow, randCol) = False Then
                minesArray(randRow, randCol) = True
                mineCount += 1
                'tileArray(randCol + numOfColumns * randRow).BackColor = Color.Red
            End If
        Loop
    End Sub

    Private Sub countAround(ByVal row As Integer, ByVal column As Integer)
        spacesClicked += 1
        tileArray(column + numOfColumns * row).Enabled = False
        'Change all pics
        checked(row, column) = True
        Dim mineCounter As Integer = 0
        Dim lowRow As Integer = row - 1
        Dim highRow As Integer = row + 1
        Dim lowCol As Integer = column - 1
        Dim highCol As Integer = column + 1

        If lowRow = -1 Then
            lowRow = 0
        End If
        If highRow = numOfRows Then
            highRow = numOfRows - 1
        End If
        If lowCol = -1 Then
            lowCol = 0
        End If
        If highCol = numOfColumns Then
            highCol = numOfColumns - 1
        End If

        For i = lowRow To highRow
            For j = lowCol To highCol
                If minesArray(i, j) Then
                    mineCounter += 1
                End If
            Next
        Next
        If Not minesArray(row, column) Then
            If mineCounter = 0 Then
                tileArray(column + numOfColumns * row).Image = My.Resources.TileDown
            ElseIf mineCounter = 1 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._1
            ElseIf mineCounter = 2 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._2
            ElseIf mineCounter = 3 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._3
            ElseIf mineCounter = 4 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._4
            ElseIf mineCounter = 5 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._5
            ElseIf mineCounter = 6 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._6
            ElseIf mineCounter = 7 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._7
            ElseIf mineCounter = 8 Then
                tileArray(column + numOfColumns * row).Image = My.Resources._8
            End If
        End If
        If minesArray(row, column) Then 'Show Mines
            tmrCount.Enabled = False
            For Each Control In Me.Controls
                If TypeOf Control Is PictureBox And Control.name = "tile" Then
                    Control.enabled = False
                End If
            Next
            tileArray(column + numOfColumns * row).Image = My.Resources.Mine
            For i = 0 To 500
                For j = 0 To 500
                    If minesArray(i, j) Then
                        tileArray(j + numOfColumns * i).Image = My.Resources.Mine
                    End If
                Next
            Next
            picSmiley.Image = My.Resources.LoseSmiley
            MsgBox("You lose.", MsgBoxStyle.Critical, "Game Over")
        Else
            If spacesClicked = (numOfColumns * numOfRows) - numOfMines Then
                win()
            End If
        End If

        If mineCounter = 0 Then
            For i = lowRow To highRow
                For j = lowCol To highCol
                    If checked(i, j) = False Then
                        delay(0.0001)
                        countAround(i, j)
                    End If
                Next
            Next
        End If
        'Check for win -------------------------------------
    End Sub

    Private Sub delay(ByVal interval As Decimal)
        Dim startTime As Decimal = Microsoft.VisualBasic.DateAndTime.Timer
        Do While Microsoft.VisualBasic.DateAndTime.Timer < startTime + interval
            Application.DoEvents()
        Loop
    End Sub

    Private Sub win()
        picSmiley.Image = My.Resources.WinSlimey
        tmrCount.Enabled = False
        Dim scoreWriter As IO.StreamWriter
        Dim nameWriter As IO.StreamWriter
        MsgBox("You Win!", MsgBoxStyle.Exclamation, "Congratulations!")
        For Each Control In Me.Controls
            If TypeOf Control Is PictureBox And Control.name = "tile" Then
                Control.enabled = False
            End If
        Next

        'Write to files
        If File.Exists(Application.StartupPath + "\scores.txt") Then
            If difficulty = "easy" Then
                If time < CInt(scoresArray(0)) Then
                    scoresArray(0) = CStr(time)
                    Dim name As String = InputBox("Name:", "New High Score!")
                    namesArray(0) = name
                End If
            ElseIf difficulty = "inter" Then
                If time < CInt(scoresArray(1)) Then
                    scoresArray(1) = CStr(time)
                    Dim name As String = InputBox("Name:", "New High Score!")
                    namesArray(1) = name
                End If
            ElseIf difficulty = "expert" Then
                If time < CInt(scoresArray(2)) Then
                    scoresArray(2) = CStr(time)
                    Dim name As String = InputBox("Name:", "New High Score!")
                    namesArray(2) = name
                End If
            End If
            scoreWriter = IO.File.CreateText(Application.StartupPath + "\scores.txt")
            For i = 0 To 2
                scoreWriter.WriteLine(CStr(scoresArray(i)))
            Next
            scoreWriter.Close()
            nameWriter = IO.File.CreateText(Application.StartupPath + "\names.txt")
            For i = 0 To 2
                nameWriter.WriteLine(CStr(namesArray(i)))
            Next
            nameWriter.Close()
        End If
    End Sub

    Private Sub btnCustomPnlCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomPnlCreate.Click
        pnlCreate.Visible = True
        btnCreate.Focus()
        If Me.Width < 300 Then
            Me.Width = 300
        End If
        If Me.Height < 230 Then
            Me.Height = 235
        End If
    End Sub

    Private Sub mineClick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mineClick.Click
        tmrCount.Enabled = True
        If Not flagged Then
            Dim index As Integer = sender.tag
            Dim row As Integer = index \ numOfColumns
            Dim column As Integer = index - (row * numOfColumns)
            lblRow.Text = row
            lblColumn.Text = column
            lblBlockNum.Text = index
            countAround(row, column)
        End If
        flagged = False
    End Sub

    Private Sub mineClick_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mineClick.MouseDown
        Dim index As Integer = sender.tag
        Dim numOfRows As Integer = txtRows.Text
        Dim numOfColumns As Integer = txtColumns.Text
        Dim row As Integer = index \ numOfColumns
        Dim column As Integer = index - (row * numOfColumns)

        If MouseButtons = Windows.Forms.MouseButtons.Right Then
            If Not flagsArray(row, column) Then 'Not flagged, flag
                sender.image = My.Resources.Flag
                flagsArray(row, column) = True
                flagged = True
            ElseIf flagsArray(row, column) Then 'Unflag
                sender.image = My.Resources.TileUp
                flagsArray(row, column) = False
                flagged = True
            End If
        End If
    End Sub

    Private Sub btnEasy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEasy.Click
        difficulty = "easy"
        numOfColumns = 9
        numOfRows = 9
        numOfMines = 10
        newGameStuff()
    End Sub

    Private Sub btnNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNormal.Click
        difficulty = "inter"
        numOfColumns = 16
        numOfRows = 16
        numOfMines = 40
        newGameStuff()
    End Sub

    Private Sub btnExpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpert.Click
        difficulty = "expert"
        numOfColumns = 30
        numOfRows = 16
        numOfMines = 99
        newGameStuff()
    End Sub

    Private Sub tmrCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCount.Tick
        time = time + 1
        Dim timeString As String = time
        If Len(timeString) = 1 Then
            If timeString = 1 Then
                picTime3.Image = My.Resources.Tmr1
            ElseIf timeString = 2 Then
                picTime3.Image = My.Resources.Tmr2
            ElseIf timeString = 3 Then
                picTime3.Image = My.Resources.Tmr3
            ElseIf timeString = 4 Then
                picTime3.Image = My.Resources.Tmr4
            ElseIf timeString = 5 Then
                picTime3.Image = My.Resources.Tmr5
            ElseIf timeString = 6 Then
                picTime3.Image = My.Resources.Tmr6
            ElseIf timeString = 7 Then
                picTime3.Image = My.Resources.Tmr7
            ElseIf timeString = 8 Then
                picTime3.Image = My.Resources.Tmr8
            ElseIf timeString = 9 Then
                picTime3.Image = My.Resources.Tmr9
            End If

        ElseIf Len(timeString) = 2 Then '2 long
            If Mid(timeString, 1, 1) = 1 Then
                picTime2.Image = My.Resources.Tmr1
            ElseIf Mid(timeString, 1, 1) = 2 Then
                picTime2.Image = My.Resources.Tmr2
            ElseIf Mid(timeString, 1, 1) = 3 Then
                picTime2.Image = My.Resources.Tmr3
            ElseIf Mid(timeString, 1, 1) = 4 Then
                picTime2.Image = My.Resources.Tmr4
            ElseIf Mid(timeString, 1, 1) = 5 Then
                picTime2.Image = My.Resources.Tmr5
            ElseIf Mid(timeString, 1, 1) = 6 Then
                picTime2.Image = My.Resources.Tmr6
            ElseIf Mid(timeString, 1, 1) = 7 Then
                picTime2.Image = My.Resources.Tmr7
            ElseIf Mid(timeString, 1, 1) = 8 Then
                picTime2.Image = My.Resources.Tmr8
            ElseIf Mid(timeString, 1, 1) = 9 Then
                picTime2.Image = My.Resources.Tmr9
            End If
            If Mid(timeString, 2, 1) = 0 Then
                picTime3.Image = My.Resources.Tmr0
            ElseIf Mid(timeString, 2, 1) = 1 Then
                picTime3.Image = My.Resources.Tmr1
            ElseIf Mid(timeString, 2, 1) = 2 Then
                picTime3.Image = My.Resources.Tmr2
            ElseIf Mid(timeString, 2, 1) = 3 Then
                picTime3.Image = My.Resources.Tmr3
            ElseIf Mid(timeString, 2, 1) = 4 Then
                picTime3.Image = My.Resources.Tmr4
            ElseIf Mid(timeString, 2, 1) = 5 Then
                picTime3.Image = My.Resources.Tmr5
            ElseIf Mid(timeString, 2, 1) = 6 Then
                picTime3.Image = My.Resources.Tmr6
            ElseIf Mid(timeString, 2, 1) = 7 Then
                picTime3.Image = My.Resources.Tmr7
            ElseIf Mid(timeString, 2, 1) = 8 Then
                picTime3.Image = My.Resources.Tmr8
            ElseIf Mid(timeString, 2, 1) = 9 Then
                picTime3.Image = My.Resources.Tmr9
            End If
        ElseIf Len(timeString) = 3 Then
            If Mid(timeString, 1, 1) = 1 Then
                picTime1.Image = My.Resources.Tmr1
            ElseIf Mid(timeString, 1, 1) = 2 Then
                picTime1.Image = My.Resources.Tmr2
            ElseIf Mid(timeString, 1, 1) = 3 Then
                picTime1.Image = My.Resources.Tmr3
            ElseIf Mid(timeString, 1, 1) = 4 Then
                picTime1.Image = My.Resources.Tmr4
            ElseIf Mid(timeString, 1, 1) = 5 Then
                picTime1.Image = My.Resources.Tmr5
            ElseIf Mid(timeString, 1, 1) = 6 Then
                picTime1.Image = My.Resources.Tmr6
            ElseIf Mid(timeString, 1, 1) = 7 Then
                picTime1.Image = My.Resources.Tmr7
            ElseIf Mid(timeString, 1, 1) = 8 Then
                picTime1.Image = My.Resources.Tmr8
            ElseIf Mid(timeString, 1, 1) = 9 Then
                picTime1.Image = My.Resources.Tmr9
            End If
            If Mid(timeString, 2, 1) = 0 Then
                picTime2.Image = My.Resources.Tmr0
            ElseIf Mid(timeString, 2, 1) = 1 Then
                picTime2.Image = My.Resources.Tmr1
            ElseIf Mid(timeString, 2, 1) = 2 Then
                picTime2.Image = My.Resources.Tmr2
            ElseIf Mid(timeString, 2, 1) = 3 Then
                picTime2.Image = My.Resources.Tmr3
            ElseIf Mid(timeString, 2, 1) = 4 Then
                picTime2.Image = My.Resources.Tmr4
            ElseIf Mid(timeString, 2, 1) = 5 Then
                picTime2.Image = My.Resources.Tmr5
            ElseIf Mid(timeString, 2, 1) = 6 Then
                picTime2.Image = My.Resources.Tmr6
            ElseIf Mid(timeString, 2, 1) = 7 Then
                picTime2.Image = My.Resources.Tmr7
            ElseIf Mid(timeString, 2, 1) = 8 Then
                picTime2.Image = My.Resources.Tmr8
            ElseIf Mid(timeString, 2, 1) = 9 Then
                picTime2.Image = My.Resources.Tmr9
            End If
            If Mid(timeString, 3, 1) = 0 Then
                picTime3.Image = My.Resources.Tmr0
            ElseIf Mid(timeString, 3, 1) = 1 Then
                picTime3.Image = My.Resources.Tmr1
            ElseIf Mid(timeString, 3, 1) = 2 Then
                picTime3.Image = My.Resources.Tmr2
            ElseIf Mid(timeString, 3, 1) = 3 Then
                picTime3.Image = My.Resources.Tmr3
            ElseIf Mid(timeString, 3, 1) = 4 Then
                picTime3.Image = My.Resources.Tmr4
            ElseIf Mid(timeString, 3, 1) = 5 Then
                picTime3.Image = My.Resources.Tmr5
            ElseIf Mid(timeString, 3, 1) = 6 Then
                picTime3.Image = My.Resources.Tmr6
            ElseIf Mid(timeString, 3, 1) = 7 Then
                picTime3.Image = My.Resources.Tmr7
            ElseIf Mid(timeString, 3, 1) = 8 Then
                picTime3.Image = My.Resources.Tmr8
            ElseIf Mid(timeString, 3, 1) = 9 Then
                picTime3.Image = My.Resources.Tmr9
            End If
        End If
    End Sub

    Private Sub newGameStuff()
        picSmiley.Image = My.Resources.NeutralSmiley
        spacesClicked = 0
        tmrCount.Enabled = False
        btnNewGame.Enabled = True
        Dim frmHeight As Integer = (numOfRows * 25) + numOfRows + 120
        Dim frmWidth As Integer = (numOfColumns * 25) + numOfColumns + 30
        picSmiley.Left = frmWidth / 2 
        If numOfRows * numOfColumns < 499 Then
            Me.Height = frmHeight
            Me.Width = frmWidth
        End If
        time = 0
        picTime1.Image = My.Resources.Tmr0
        picTime2.Image = My.Resources.Tmr0
        picTime3.Image = My.Resources.Tmr0
        createBoard()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click, picSmiley.Click
        newGameStuff()
    End Sub

    Private Sub btnBestTimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBestTimes.Click
        If File.Exists(Application.StartupPath + "\scores.txt") Then
            MsgBox("Beginner - " + scoresArray(0) + " - " + namesArray(0) + Chr(13) + "Intermediate - " + scoresArray(1) + " - " + namesArray(1) + Chr(13) + "Expert - " + scoresArray(2) + " - " + namesArray(2), MsgBoxStyle.Exclamation, "High Scores")
        Else
            MsgBox("Can't retrieve best times.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        If File.Exists(Application.StartupPath + "\scores.txt") Then
            Dim scoreReader As IO.StreamReader
            Dim nameReader As IO.StreamReader
            scoreReader = IO.File.OpenText(Application.StartupPath + "\scores.txt")
            For i = 0 To 2 'Read scores in for comparing at begginng
                scoresArray(i) = CStr(scoreReader.ReadLine)
            Next
            scoreReader.Close()
            nameReader = IO.File.OpenText(Application.StartupPath + "\names.txt")
            For i = 0 To 2
                namesArray(i) = CStr(nameReader.ReadLine)
            Next
            nameReader.Close()
        End If
    End Sub

    Private Sub picSmiley_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picSmiley.MouseDown
        picSmiley.Image = My.Resources.OhGodSmiley
    End Sub

    Private Sub picSmiley_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picSmiley.MouseUp
        picSmiley.Image = My.Resources.NeutralSmiley
    End Sub
End Class