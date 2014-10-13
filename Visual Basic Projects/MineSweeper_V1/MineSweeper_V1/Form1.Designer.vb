<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtColumns = New System.Windows.Forms.TextBox
        Me.txtRows = New System.Windows.Forms.TextBox
        Me.btnCreate = New System.Windows.Forms.Button
        Me.pnlCreate = New System.Windows.Forms.Panel
        Me.ulblMines = New System.Windows.Forms.Label
        Me.txtMineNum = New System.Windows.Forms.TextBox
        Me.ulblMakeBaord = New System.Windows.Forms.Label
        Me.ulblHeight = New System.Windows.Forms.Label
        Me.ulblWidth = New System.Windows.Forms.Label
        Me.ulblRow = New System.Windows.Forms.Label
        Me.ulblCoumn = New System.Windows.Forms.Label
        Me.lblRow = New System.Windows.Forms.Label
        Me.lblColumn = New System.Windows.Forms.Label
        Me.ulblBlockNum = New System.Windows.Forms.Label
        Me.lblBlockNum = New System.Windows.Forms.Label
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip
        Me.btnOpenMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNewGame = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEasy = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNormal = New System.Windows.Forms.ToolStripMenuItem
        Me.btnExpert = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCustomPnlCreate = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnBestTimes = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem
        Me.tmrCount = New System.Windows.Forms.Timer(Me.components)
        Me.picTime2 = New System.Windows.Forms.PictureBox
        Me.picTime3 = New System.Windows.Forms.PictureBox
        Me.picTime1 = New System.Windows.Forms.PictureBox
        Me.mineClick = New System.Windows.Forms.PictureBox
        Me.picSmiley = New System.Windows.Forms.PictureBox
        Me.pnlCreate.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        CType(Me.picTime2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTime3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTime1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mineClick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSmiley, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtColumns
        '
        Me.txtColumns.Location = New System.Drawing.Point(75, 38)
        Me.txtColumns.Name = "txtColumns"
        Me.txtColumns.Size = New System.Drawing.Size(100, 20)
        Me.txtColumns.TabIndex = 0
        Me.txtColumns.Text = "9"
        '
        'txtRows
        '
        Me.txtRows.Location = New System.Drawing.Point(75, 64)
        Me.txtRows.Name = "txtRows"
        Me.txtRows.Size = New System.Drawing.Size(100, 20)
        Me.txtRows.TabIndex = 1
        Me.txtRows.Text = "9"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(184, 47)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(76, 29)
        Me.btnCreate.TabIndex = 3
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'pnlCreate
        '
        Me.pnlCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCreate.Controls.Add(Me.ulblMines)
        Me.pnlCreate.Controls.Add(Me.txtMineNum)
        Me.pnlCreate.Controls.Add(Me.ulblMakeBaord)
        Me.pnlCreate.Controls.Add(Me.ulblHeight)
        Me.pnlCreate.Controls.Add(Me.ulblWidth)
        Me.pnlCreate.Controls.Add(Me.txtColumns)
        Me.pnlCreate.Controls.Add(Me.btnCreate)
        Me.pnlCreate.Controls.Add(Me.txtRows)
        Me.pnlCreate.Location = New System.Drawing.Point(12, 78)
        Me.pnlCreate.Name = "pnlCreate"
        Me.pnlCreate.Size = New System.Drawing.Size(272, 122)
        Me.pnlCreate.TabIndex = 3
        Me.pnlCreate.Visible = False
        '
        'ulblMines
        '
        Me.ulblMines.AutoSize = True
        Me.ulblMines.Location = New System.Drawing.Point(31, 93)
        Me.ulblMines.Name = "ulblMines"
        Me.ulblMines.Size = New System.Drawing.Size(38, 13)
        Me.ulblMines.TabIndex = 7
        Me.ulblMines.Text = "Mines:"
        '
        'txtMineNum
        '
        Me.txtMineNum.Location = New System.Drawing.Point(75, 90)
        Me.txtMineNum.Name = "txtMineNum"
        Me.txtMineNum.Size = New System.Drawing.Size(100, 20)
        Me.txtMineNum.TabIndex = 2
        Me.txtMineNum.Text = "10"
        '
        'ulblMakeBaord
        '
        Me.ulblMakeBaord.AutoSize = True
        Me.ulblMakeBaord.Location = New System.Drawing.Point(89, 10)
        Me.ulblMakeBaord.Name = "ulblMakeBaord"
        Me.ulblMakeBaord.Size = New System.Drawing.Size(69, 13)
        Me.ulblMakeBaord.TabIndex = 5
        Me.ulblMakeBaord.Text = "Create Board"
        '
        'ulblHeight
        '
        Me.ulblHeight.AutoSize = True
        Me.ulblHeight.Location = New System.Drawing.Point(32, 67)
        Me.ulblHeight.Name = "ulblHeight"
        Me.ulblHeight.Size = New System.Drawing.Size(37, 13)
        Me.ulblHeight.TabIndex = 4
        Me.ulblHeight.Text = "Rows:"
        '
        'ulblWidth
        '
        Me.ulblWidth.AutoSize = True
        Me.ulblWidth.Location = New System.Drawing.Point(19, 41)
        Me.ulblWidth.Name = "ulblWidth"
        Me.ulblWidth.Size = New System.Drawing.Size(50, 13)
        Me.ulblWidth.TabIndex = 3
        Me.ulblWidth.Text = "Columns:"
        '
        'ulblRow
        '
        Me.ulblRow.AutoSize = True
        Me.ulblRow.Location = New System.Drawing.Point(68, 683)
        Me.ulblRow.Name = "ulblRow"
        Me.ulblRow.Size = New System.Drawing.Size(32, 13)
        Me.ulblRow.TabIndex = 7
        Me.ulblRow.Text = "Row:"
        '
        'ulblCoumn
        '
        Me.ulblCoumn.AutoSize = True
        Me.ulblCoumn.Location = New System.Drawing.Point(55, 667)
        Me.ulblCoumn.Name = "ulblCoumn"
        Me.ulblCoumn.Size = New System.Drawing.Size(45, 13)
        Me.ulblCoumn.TabIndex = 8
        Me.ulblCoumn.Text = "Column:"
        '
        'lblRow
        '
        Me.lblRow.AutoSize = True
        Me.lblRow.Location = New System.Drawing.Point(106, 683)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(13, 13)
        Me.lblRow.TabIndex = 9
        Me.lblRow.Text = "0"
        '
        'lblColumn
        '
        Me.lblColumn.AutoSize = True
        Me.lblColumn.Location = New System.Drawing.Point(106, 667)
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(13, 13)
        Me.lblColumn.TabIndex = 10
        Me.lblColumn.Text = "0"
        '
        'ulblBlockNum
        '
        Me.ulblBlockNum.AutoSize = True
        Me.ulblBlockNum.Location = New System.Drawing.Point(170, 683)
        Me.ulblBlockNum.Name = "ulblBlockNum"
        Me.ulblBlockNum.Size = New System.Drawing.Size(62, 13)
        Me.ulblBlockNum.TabIndex = 11
        Me.ulblBlockNum.Text = "Block Num:"
        '
        'lblBlockNum
        '
        Me.lblBlockNum.AutoSize = True
        Me.lblBlockNum.Location = New System.Drawing.Point(238, 683)
        Me.lblBlockNum.Name = "lblBlockNum"
        Me.lblBlockNum.Size = New System.Drawing.Size(13, 13)
        Me.lblBlockNum.TabIndex = 12
        Me.lblBlockNum.Text = "0"
        '
        'MenuStripMain
        '
        Me.MenuStripMain.AutoSize = False
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenMenu})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(302, 30)
        Me.MenuStripMain.TabIndex = 13
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'btnOpenMenu
        '
        Me.btnOpenMenu.AutoSize = False
        Me.btnOpenMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewGame, Me.ToolStripSeparator3, Me.btnEasy, Me.btnNormal, Me.btnExpert, Me.btnCustomPnlCreate, Me.ToolStripSeparator2, Me.btnBestTimes, Me.ToolStripSeparator1, Me.btnExit})
        Me.btnOpenMenu.Name = "btnOpenMenu"
        Me.btnOpenMenu.Size = New System.Drawing.Size(94, 26)
        Me.btnOpenMenu.Text = "Game"
        '
        'btnNewGame
        '
        Me.btnNewGame.Enabled = False
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.btnNewGame.Size = New System.Drawing.Size(183, 22)
        Me.btnNewGame.Tag = "GO"
        Me.btnNewGame.Text = "New"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        '
        'btnEasy
        '
        Me.btnEasy.Name = "btnEasy"
        Me.btnEasy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.btnEasy.Size = New System.Drawing.Size(183, 22)
        Me.btnEasy.Text = "Beginner"
        '
        'btnNormal
        '
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.btnNormal.Size = New System.Drawing.Size(183, 22)
        Me.btnNormal.Text = "Intermediate"
        '
        'btnExpert
        '
        Me.btnExpert.Name = "btnExpert"
        Me.btnExpert.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.btnExpert.Size = New System.Drawing.Size(183, 22)
        Me.btnExpert.Text = "Expert"
        '
        'btnCustomPnlCreate
        '
        Me.btnCustomPnlCreate.Name = "btnCustomPnlCreate"
        Me.btnCustomPnlCreate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.btnCustomPnlCreate.Size = New System.Drawing.Size(183, 22)
        Me.btnCustomPnlCreate.Text = "Custom..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(180, 6)
        '
        'btnBestTimes
        '
        Me.btnBestTimes.Name = "btnBestTimes"
        Me.btnBestTimes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.btnBestTimes.Size = New System.Drawing.Size(183, 22)
        Me.btnBestTimes.Text = "Best Times"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(180, 6)
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.btnExit.Size = New System.Drawing.Size(183, 22)
        Me.btnExit.Text = "Quit"
        '
        'tmrCount
        '
        Me.tmrCount.Interval = 1000
        '
        'picTime2
        '
        Me.picTime2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picTime2.Image = Global.WindowsApplication1.My.Resources.Resources.Tmr0
        Me.picTime2.Location = New System.Drawing.Point(33, 39)
        Me.picTime2.Name = "picTime2"
        Me.picTime2.Size = New System.Drawing.Size(20, 30)
        Me.picTime2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTime2.TabIndex = 17
        Me.picTime2.TabStop = False
        '
        'picTime3
        '
        Me.picTime3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picTime3.Image = Global.WindowsApplication1.My.Resources.Resources.Tmr0
        Me.picTime3.Location = New System.Drawing.Point(53, 39)
        Me.picTime3.Name = "picTime3"
        Me.picTime3.Size = New System.Drawing.Size(20, 30)
        Me.picTime3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTime3.TabIndex = 16
        Me.picTime3.TabStop = False
        '
        'picTime1
        '
        Me.picTime1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picTime1.Image = Global.WindowsApplication1.My.Resources.Resources.Tmr0
        Me.picTime1.Location = New System.Drawing.Point(13, 39)
        Me.picTime1.Name = "picTime1"
        Me.picTime1.Size = New System.Drawing.Size(20, 30)
        Me.picTime1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTime1.TabIndex = 15
        Me.picTime1.TabStop = False
        '
        'mineClick
        '
        Me.mineClick.Location = New System.Drawing.Point(502, 443)
        Me.mineClick.Name = "mineClick"
        Me.mineClick.Size = New System.Drawing.Size(35, 21)
        Me.mineClick.TabIndex = 6
        Me.mineClick.TabStop = False
        Me.mineClick.Visible = False
        '
        'picSmiley
        '
        Me.picSmiley.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picSmiley.Image = Global.WindowsApplication1.My.Resources.Resources.NeutralSmiley
        Me.picSmiley.Location = New System.Drawing.Point(153, 39)
        Me.picSmiley.Name = "picSmiley"
        Me.picSmiley.Size = New System.Drawing.Size(32, 32)
        Me.picSmiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSmiley.TabIndex = 18
        Me.picSmiley.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 29)
        Me.Controls.Add(Me.picSmiley)
        Me.Controls.Add(Me.picTime2)
        Me.Controls.Add(Me.picTime3)
        Me.Controls.Add(Me.picTime1)
        Me.Controls.Add(Me.lblBlockNum)
        Me.Controls.Add(Me.ulblBlockNum)
        Me.Controls.Add(Me.lblColumn)
        Me.Controls.Add(Me.lblRow)
        Me.Controls.Add(Me.ulblCoumn)
        Me.Controls.Add(Me.ulblRow)
        Me.Controls.Add(Me.mineClick)
        Me.Controls.Add(Me.pnlCreate)
        Me.Controls.Add(Me.MenuStripMain)
        Me.MainMenuStrip = Me.MenuStripMain
        Me.Name = "Form1"
        Me.Text = "MineSweeper - A Joey Gelpi Production"
        Me.pnlCreate.ResumeLayout(False)
        Me.pnlCreate.PerformLayout()
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        CType(Me.picTime2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTime3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTime1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mineClick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSmiley, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtColumns As System.Windows.Forms.TextBox
    Friend WithEvents txtRows As System.Windows.Forms.TextBox
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents pnlCreate As System.Windows.Forms.Panel
    Friend WithEvents ulblMakeBaord As System.Windows.Forms.Label
    Friend WithEvents ulblHeight As System.Windows.Forms.Label
    Friend WithEvents ulblWidth As System.Windows.Forms.Label
    Friend WithEvents mineClick As System.Windows.Forms.PictureBox
    Friend WithEvents ulblRow As System.Windows.Forms.Label
    Friend WithEvents ulblCoumn As System.Windows.Forms.Label
    Friend WithEvents lblRow As System.Windows.Forms.Label
    Friend WithEvents lblColumn As System.Windows.Forms.Label
    Friend WithEvents ulblBlockNum As System.Windows.Forms.Label
    Friend WithEvents lblBlockNum As System.Windows.Forms.Label
    Friend WithEvents ulblMines As System.Windows.Forms.Label
    Friend WithEvents txtMineNum As System.Windows.Forms.TextBox
    Friend WithEvents MenuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents btnOpenMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEasy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNormal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExpert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomPnlCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCount As System.Windows.Forms.Timer
    Friend WithEvents picTime1 As System.Windows.Forms.PictureBox
    Friend WithEvents picTime3 As System.Windows.Forms.PictureBox
    Friend WithEvents picTime2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBestTimes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNewGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents picSmiley As System.Windows.Forms.PictureBox
End Class
