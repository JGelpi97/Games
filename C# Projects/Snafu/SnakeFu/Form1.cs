using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeFu
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Graphics g;
        Snake snakeRed;
        Snake snakeBlue;
        Snake snakeYellow;
        Snake snakeGreen;
        Snake holderSnake;
        Timer gameTimer = new Timer();
        List<Snake> lstSnakes = new List<Snake>();
        List<SnakePiece> lstGreenSnakes = new List<SnakePiece>();
        List<SnakePiece> lstRedSnakes = new List<SnakePiece>();
        List<SnakePiece> lstYellowSnakes = new List<SnakePiece>();
        List<SnakePiece> lstBlueSnakes = new List<SnakePiece>();
        PlayerSelect playerSelect = new PlayerSelect();
        Score score = new Score();       
        int moveTime = 0;
        int[,] board = new int[79, 58];
        decimal players;
        bool inRedLoop = false;
        bool inBlueLoop = false;
        bool inYellowLoop = false;
        bool inGreenLoop = false;
        int twoCounter;
        int gameType = 1;

        public Form1()
        {

            #region SetUpStuff
            PictureBox picControls = new PictureBox();
            picControls.Image = SnakeFu.Properties.Resources.Controls;
            picControls.Left = 795;
            picControls.Top = 0;
            picControls.Size = SnakeFu.Properties.Resources.Controls.Size;
            Label lblGameTypes = new Label();
            lblGameTypes.AutoSize = true;
            lblGameTypes.Font = new Font("Courier New", 10);
            lblGameTypes.Text = "Press 1 or 2 to select game types \n 1 - Regular \n 2 - Snakes Disappear on Death";
            lblGameTypes.Left = 450;
            lblGameTypes.Top = 585;
            Panel pnl1 = new Panel();
            pnl1.BorderStyle = BorderStyle.FixedSingle;
            pnl1.Width = 2;
            pnl1.Height = 100;
            pnl1.Left = 420;
            pnl1.Top = 580;
            Panel pnl2 = new Panel();
            pnl2.BorderStyle = BorderStyle.FixedSingle;
            pnl2.Width = 2;
            pnl2.Height = 100;
            pnl2.Left = 788;
            pnl2.Top = 580;
            #endregion

            InitializeComponent();
            snakeRed = new Snake(130, 110, random, 13, 11, "red");
            snakeBlue = new Snake(140, 390, random, 14, 39, "blue");
            snakeYellow = new Snake(690, 120, random, 69, 12, "yellow");
            snakeGreen = new Snake(680, 380, random, 68, 38, "green");
            Width = 900;
            Height = 670;
            BackgroundImage = SnakeFu.Properties.Resources.Board;
            BackgroundImageLayout = ImageLayout.None;
            BackColor = Color.White;
            Text = "SnakeFu";
            DoubleBuffered = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            Paint += new PaintEventHandler(Form1_Paint);

            StartPosition = FormStartPosition.CenterScreen;

            g = CreateGraphics();

            gameTimer.Enabled = false;
            gameTimer.Interval = 50;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);

            Controls.Add(playerSelect.GetPnl());
            Controls.Add(score.GetPanel());
            Controls.Add(lblGameTypes);
            Controls.Add(pnl1);
            Controls.Add(picControls);
            Controls.Add(pnl2);
            playerSelect.GetBtn().Click += new EventHandler(btnPlayers_Click);
            playerSelect.GetNumPlayersControl().KeyDown +=new KeyEventHandler(numPlayers_KeyDown);
                    
            for (int i = 0; i < 78; i++)
            {
                board[i, 0] = 1;
                board[i, 57] = 1;
            }
            for (int i = 0; i < 58; i++)
            {
                board[0, i] = 1;
                board[78, i] = 1;
            }

        }

        public void CheckForWin()
        {
            int x = 0;

            foreach (Snake snk in lstSnakes)
            {
                if (snk.GetAlive())
                {
                    x++;
                    holderSnake = snk;
                }
            }
            if (x == 1)
            {
                score.ChangeScores(holderSnake.GetColor());
            }

        }

        void numPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPlayers_Click(sender, e);
            }
        }

        void btnPlayers_Click(object sender, EventArgs e) //Player panel button
        {
            players = playerSelect.GetNumOfPlayers();
            Focus();
            SetupPlayers();
            gameTimer.Enabled = true;
        }

        public void SetupPlayers()
        {
            if (players == 1)
            {
                lstSnakes.Add(snakeRed);                
            }
            else if (players == 2)
            {
                lstSnakes.Add(snakeRed);
                lstSnakes.Add(snakeBlue);
            }
            else if (players == 3)
            {
                lstSnakes.Add(snakeRed);
                lstSnakes.Add(snakeBlue);
                lstSnakes.Add(snakeYellow);
            }
            else if (players == 4)
            {
                lstSnakes.Add(snakeRed);
                lstSnakes.Add(snakeBlue);
                lstSnakes.Add(snakeYellow);
                lstSnakes.Add(snakeGreen);
            }

        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (SnakePiece p in lstBlueSnakes)
            {
                if (p.GetAlive())
                    p.Draw(g);
            }
            foreach (SnakePiece p in lstRedSnakes)
            {
                if (p.GetAlive())
                    p.Draw(g);
            }
            foreach (SnakePiece p in lstGreenSnakes)
            {
                if (p.GetAlive())
                    p.Draw(g);
            }
            foreach (SnakePiece p in lstYellowSnakes)
            {
                if (p.GetAlive())
                    p.Draw(g);
            }
            g = CreateGraphics();
        }

        public void Restart()
        {
            for (int i = 1; i < 78; i++)
            {
                for (int j = 1; j < 57; j++)
                {
                    board[i, j] = 0;
                }
            }
            lstBlueSnakes.Clear();
            lstGreenSnakes.Clear();
            lstRedSnakes.Clear();
            lstYellowSnakes.Clear();
            foreach (Snake snk in lstSnakes)
            {
                snk.Reset();
                snk.SetRandomDirection(random);
            }
            Invalidate();                
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                if (!inGreenLoop && !inRedLoop && !inYellowLoop && !inBlueLoop)
                {
                    Restart();
                    gameType = 1;
                }
            }
            if (e.KeyCode == Keys.D2)
            {
                if (!inGreenLoop && !inRedLoop && !inYellowLoop && !inBlueLoop)
                {
                Restart();
                gameType = 2;
                }
            }

            if (gameTimer.Enabled)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (!inGreenLoop && !inRedLoop && !inYellowLoop && !inBlueLoop)
                        Restart();
                }

                //Red
                if (e.KeyCode == Keys.W)
                {
                    snakeRed.ChangeDirection("up");
                }
                else if (e.KeyCode == Keys.A)
                {
                    snakeRed.ChangeDirection("left");
                }
                else if (e.KeyCode == Keys.D)
                {
                    snakeRed.ChangeDirection("right");
                }
                else if (e.KeyCode == Keys.S)
                {
                    snakeRed.ChangeDirection("down");
                }

                //Blue
                if (e.KeyCode == Keys.Up)
                {
                    snakeBlue.ChangeDirection("up");
                }
                else if (e.KeyCode == Keys.Left)
                {
                    snakeBlue.ChangeDirection("left");
                }
                else if (e.KeyCode == Keys.Right)
                {
                    snakeBlue.ChangeDirection("right");
                }
                else if (e.KeyCode == Keys.Down)
                {
                    snakeBlue.ChangeDirection("down");
                }

                //Yellow
                if (e.KeyCode == Keys.NumPad8)
                {
                    snakeYellow.ChangeDirection("up");
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    snakeYellow.ChangeDirection("left");
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    snakeYellow.ChangeDirection("right");
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    snakeYellow.ChangeDirection("down");
                }

                //Green
                if (e.KeyCode == Keys.I)
                {
                    snakeGreen.ChangeDirection("up");
                }
                else if (e.KeyCode == Keys.J)
                {
                    snakeGreen.ChangeDirection("left");
                }
                else if (e.KeyCode == Keys.L)
                {
                    snakeGreen.ChangeDirection("right");
                }
                else if (e.KeyCode == Keys.K)
                {
                    snakeGreen.ChangeDirection("down");
                }
            }

        }

        void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!Focused)
            {
                Invalidate();
            }
            moveTime++;
            if (moveTime >= 1)
            {
                foreach (Snake snake in lstSnakes)
                {
                    if (snake.GetAlive())
                    {
                        moveTime = 0;
                        if (snake.GetAIControlled())
                        {
                            snake.AI(board);
                        }
                        SnakePiece snakePiece = new SnakePiece(snake.GetRect().X, snake.GetRect().Y, snake.GetColor());
                        snakePiece.Draw(g);
                        if (snake.GetColor() == "red")
                        {
                            lstRedSnakes.Add(snakePiece);
                        }
                        else if (snake.GetColor() == "green")
                        {
                            lstGreenSnakes.Add(snakePiece);
                        }
                        else if (snake.GetColor() == "blue")
                        {
                            lstBlueSnakes.Add(snakePiece);
                        }
                        else if (snake.GetColor() == "yellow")
                        {
                            lstYellowSnakes.Add(snakePiece);
                        }
                        board[snake.GetArrayX(), snake.GetArrayY()] = 1;
                        snake.Move();
                        CheckForCollision();
                    }
                }
            }
        }

        public void Delay()
        {
            int delay = 1;

            while (delay > 0)
            {
                Application.DoEvents();
                delay--;
            }
        }

        public void CheckForCollision()
        {
            foreach (Snake snake in lstSnakes)
            {
                if (snake.GetAlive())
                {
                    if (board[snake.GetArrayX(), snake.GetArrayY()] == 1)
                    {
                        snake.Kill();
                        CheckForWin();
                        if (gameType == 2)
                        {
                            if (snake.GetColor() == "red")
                            {
                                foreach (SnakePiece snkP in lstRedSnakes)
                                {
                                    int size = lstRedSnakes.Count;
                                    int counter = size / 15;
                                    inRedLoop = true;
                                    int x = snkP.GetRect().X / 10;
                                    int y = snkP.GetRect().Y / 10;
                                    board[x, y] = 0;
                                    snkP.Kill();
                                    Invalidate();
                                    twoCounter++;
                                    if (twoCounter == 5)
                                    {
                                        Delay();
                                        twoCounter = 0;
                                    }
                                    gameTimer.Enabled = false;
                                }
                                inRedLoop = false;
                                gameTimer.Enabled = true;
                                lstRedSnakes.Clear();
                            }
                            if (snake.GetColor() == "yellow")
                            {
                                foreach (SnakePiece snkP in lstYellowSnakes)
                                {
                                    inYellowLoop = true;
                                    int x = snkP.GetRect().X / 10;
                                    int y = snkP.GetRect().Y / 10;
                                    board[x, y] = 0;
                                    snkP.Kill();
                                    Invalidate();
                                    twoCounter++;
                                    if (twoCounter == 5)
                                    {
                                        Delay();
                                        twoCounter = 0;
                                    }

                                    gameTimer.Enabled = false;
                                }
                                inYellowLoop = false;
                                gameTimer.Enabled = true;
                                lstYellowSnakes.Clear();
                            }
                            if (snake.GetColor() == "blue")
                            {
                                foreach (SnakePiece snkP in lstBlueSnakes)
                                {
                                    inBlueLoop = true;
                                    int x = snkP.GetRect().X / 10;
                                    int y = snkP.GetRect().Y / 10;
                                    board[x, y] = 0;
                                    snkP.Kill();
                                    Invalidate();
                                    twoCounter++;
                                    if (twoCounter == 5)
                                    {
                                        Delay();
                                        twoCounter = 0;
                                    }

                                    gameTimer.Enabled = false;
                                }
                                inBlueLoop = false;
                                gameTimer.Enabled = true;
                                lstBlueSnakes.Clear();
                            }
                            if (snake.GetColor() == "green")
                            {
                                foreach (SnakePiece snkP in lstGreenSnakes)
                                {
                                    inGreenLoop = true;
                                    int x = snkP.GetRect().X / 10;
                                    int y = snkP.GetRect().Y / 10;
                                    board[x, y] = 0;
                                    snkP.Kill();
                                    Invalidate();
                                    twoCounter++;
                                    if (twoCounter == 5)
                                    {
                                        Delay();
                                        twoCounter = 0;
                                    }

                                    gameTimer.Enabled = false;
                                }
                                inGreenLoop = false;
                                gameTimer.Enabled = true;
                                lstGreenSnakes.Clear();
                            }
                        }
                        Invalidate();
                    }
                }
            }
        }
    }
}
