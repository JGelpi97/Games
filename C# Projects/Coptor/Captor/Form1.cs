using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Captor
{
    public partial class Form1 : Form
    {
        Timer gameTimer = new Timer();
        Graphics g;
        HeloCopter copter1 = new HeloCopter(1);
        HeloCopter copter2 = new HeloCopter(2);
        List<Terrain> terrainList = new List<Terrain>();
        Score score1 = new Score();
        CheckBox chkP1Ready = new CheckBox();
        CheckBox chkP2Ready = new CheckBox();
        int[,] cordsArray = new int[5000, 53];
        int players = 1;
        bool p1CanGo = true;
        bool p2CanGo = false;
        int WhichThrottled;
        int row;
        int column;
        
        public void SetUpStuff()
        {
            chkP1Ready.Text = "Player 1 Ready";
            chkP1Ready.Checked = true;
            chkP1Ready.Location = new Point(10, 7);
            chkP1Ready.AutoSize = true;
            chkP1Ready.BackColor = Color.Lime;
            chkP1Ready.ForeColor = Color.Black;
            chkP1Ready.Enabled = false;
            chkP1Ready.Font = new Font("Courier New", 10, FontStyle.Bold);
            chkP1Ready.KeyDown +=new KeyEventHandler(Form1_KeyDown);
            chkP1Ready.KeyUp += new KeyEventHandler(Form1_KeyUp);

            chkP2Ready.Text = "Player 2 Ready";
            chkP2Ready.Checked = false;
            chkP2Ready.Location = new Point(160, 7);
            chkP2Ready.AutoSize = true;
            chkP2Ready.BackColor = Color.Lime;
            chkP2Ready.ForeColor = Color.Black;
            chkP2Ready.Enabled = false;
            chkP2Ready.Font = new Font("Courier New", 10, FontStyle.Bold);
            chkP2Ready.KeyDown += new KeyEventHandler(Form1_KeyDown);
            chkP2Ready.KeyUp += new KeyEventHandler(Form1_KeyUp);


            pnlHelp.Left = (this.Width / 2) - (pnlHelp.Width / 2);
            pnlHelp.Top = (this.Height / 2) - (pnlHelp.Height / 2);
        }

        public Form1()
        {
            InitializeComponent();
            this.Text = "Copter - Joey Gelpi";
            this.Height = 600;
            this.Width = 800;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.Controls.Add(score1.GetCurrentScoreLabel());
            this.Controls.Add(score1.GetHighScoreLabel());
            SetUpStuff();
            this.Controls.Add(chkP1Ready);
            this.Controls.Add(chkP2Ready);
            gameTimer.Interval = 50;
            gameTimer.Enabled = true;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            int i, j;
            for (j = 0; j < 53; j++)
            {
                for (i = 0; i < 80; i++)
                {
                    if (i < 45)
                    {
                        Terrain aTerrain = new Terrain(i * 10, j * 10, 1);
                        terrainList.Add(aTerrain);
                    }
                    else
                    {
                        Terrain aTerrain = new Terrain(i * 10, j * 10, 2);
                        terrainList.Add(aTerrain);
                    }
                    terrainList[j * 80 + i].SetShow(false);
                }
            }
            FillCords();

        }

#region KeyPressing

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //P1
            if (e.KeyCode == Keys.W)
            {
                if (copter1.GetAlive())
                {
                    copter1.SetThrottle(false);
                }
            }
            //P2 ----------------------------------------
            if (e.KeyCode == Keys.Up)
            {
                if (copter2.GetAlive())
                {
                    copter2.SetThrottle(false);
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            //P1 ----------------------------------------
            if (e.KeyCode == Keys.W)
            {
                if (copter1.GetAlive())
                {
                    copter1.SetThrottle(true);
                    if (!copter2.GetThrottle())
                    {
                        WhichThrottled = 1;
                    }
                }
            }
            //P1 Change Pics
            if (e.KeyCode == Keys.A)
            {
                copter1.ChangeCopterType("L");
            }
            if (e.KeyCode == Keys.D)
            {
                copter1.ChangeCopterType("R");
            }

            //P2 -----------------------------------------------
            if (e.KeyCode == Keys.Up)
            {
                if (copter2.GetAlive())
                {
                    copter2.SetThrottle(true);
                    if (!copter1.GetThrottle())
                    {
                        WhichThrottled = 2;
                    }
                }
            }
            //P2 Change Pics 
            {
                if (e.KeyCode == Keys.Left)
                {
                    copter2.ChangeCopterType("L");
                }
                if (e.KeyCode == Keys.Right)
                {
                    copter2.ChangeCopterType("R");
                }
            }

            //Change Players -----------------------------------
            if (e.KeyCode == Keys.D1 && players == 2 && !copter1.GetAlive() && !copter2.GetAlive())
            {
                players = 1;
            }
            if (e.KeyCode == Keys.D2 && players == 1 && !copter1.GetAlive())
            {
                players = 2;
                copter2.SetCopterPicture();
            }


            //Restart --------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                copter2.SetCopterPicture();
                if (players == 2)
                {                    
                    if (e.KeyCode == Keys.S && !copter1.GetAlive() && !copter2.GetAlive())
                    {
                        p1CanGo = true;
                        chkP1Ready.Checked = true;
                        Reset();
                    }
                    if (e.KeyCode == Keys.Down && !copter2.GetAlive() && !copter1.GetAlive())
                    {
                        p2CanGo = true;
                        chkP2Ready.Checked = true;
                        Reset();
                    }
                    if ((e.KeyCode == Keys.S && !copter1.GetAlive() && !copter2.GetAlive() && p1CanGo && p2CanGo) || 
                        (e.KeyCode == Keys.Down && !copter1.GetAlive() && !copter2.GetAlive() && p1CanGo && p2CanGo))
                    {
                        copter1.SetAlive(true);
                        copter2.SetAlive(true);
                        p1CanGo = false;
                        p2CanGo = false;
                    }
                }
                else if (players == 1)
                {
                    if (e.KeyCode == Keys.S && !copter1.GetAlive() && p1CanGo)
                    {
                        copter1.SetAlive(true);
                        p1CanGo = false;
                    }
                    if (e.KeyCode == Keys.S && !copter1.GetAlive())
                    {
                        p1CanGo = true;
                        chkP1Ready.Checked = true;
                        Reset();
                    }
                }

            }

            //------------------------------------------------------------

            
        }

#endregion

        public void MoveDeadCopter()
        {
            if (!copter1.GetAlive())
            {
                copter1.MoveCopterX();
            }
            if (!copter2.GetAlive())
            {
                copter2.MoveCopterX();
            }
        }

        public void Reset()
        {
            score1.ResetScore();
            copter1.Reset();
            copter2.Reset();
            FillCords();
        }

        public void Collide()
        {
            foreach (Terrain trn in terrainList)
            {
                if (trn.GetRect().IntersectsWith(copter1.GetRect()) && (trn.GetShow()))
                {
                    copter1.SetAlive(false);
                    chkP1Ready.Checked = false;
                    if (players == 1)
                    {
                        row = trn.GetRect().Y / 10;
                        column = trn.GetRect().X / 10;
                    }
                    copter1.StartExplode();
                }
            }
            foreach (Terrain trn in terrainList)
            {
                if (trn.GetRect().IntersectsWith(copter2.GetRect()) && (trn.GetShow()))
                {
                    copter2.SetAlive(false);
                    chkP2Ready.Checked = false;
                    copter2.StartExplode();
                }
            }
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            //This draws everything
            g = e.Graphics;

            foreach (Terrain trn in terrainList)
            {
                if (trn.GetShow())
                {
                    trn.Draw(g);
                }
            }

            if (players == 2)
            {
                if (copter1.GetThrottle() && !copter2.GetThrottle())
                {
                    copter2.Draw(g);
                    copter1.Draw(g);
                }
                else if (copter2.GetThrottle() && !copter1.GetThrottle())
                {
                    copter1.Draw(g);
                    copter2.Draw(g);
                }
                else if (copter1.GetThrottle() && copter2.GetThrottle() && WhichThrottled == 1)
                {
                    copter2.Draw(g);
                    copter1.Draw(g);
                }
                else if (copter1.GetThrottle() && copter2.GetThrottle() && WhichThrottled == 2)
                {
                    copter1.Draw(g);
                    copter2.Draw(g);
                }
                else if (!copter1.GetThrottle() && !copter2.GetThrottle() && WhichThrottled == 1)
                {
                    copter2.Draw(g);
                    copter1.Draw(g);
                }
                else if (!copter1.GetThrottle() && !copter2.GetThrottle() && WhichThrottled == 2)
                {
                    copter1.Draw(g);
                    copter2.Draw(g);
                }
                else
                {
                    copter1.Draw(g);
                    copter2.Draw(g);
                }
            }
            if (players == 1)
            {
                copter1.Draw(g);
            }
        }

        void gameTimer_Tick(object sender, EventArgs e)
        {         
            DrawOrNot();
            if (players == 1)
            {
                if (copter1.GetAlive())
                {
                    MoveTerrainLeft();
                    copter1.ChangeMoveAmount();
                    copter1.MoveCopterY();
                    score1.IncreaseScore();
                    score1.CheckForRecord();
                    Collide();
                }
                else if (!copter1.GetAlive() && !p1CanGo)
                {
                    Splode();
                }
            }

            //2Player choosing what to move and crap
            if (players == 2) 
            {
                if (copter1.GetAlive())
                {
                    copter1.ChangeMoveAmount();
                    copter1.MoveCopterY();
                }
                if (copter2.GetAlive())
                {
                    copter2.ChangeMoveAmount();
                    copter2.MoveCopterY();                
                }
                if (copter1.GetAlive() || copter2.GetAlive())
                {
                    MoveTerrainLeft();
                    score1.IncreaseScore();
                    score1.CheckForRecord();
                    Collide();
                    MoveDeadCopter();
                }
            }
            if (players == 1)
            {
                if (!copter1.GetAlive() && !p1CanGo)
                {
                    copter1.Expode();
                }
            }
            if (players == 2)
            {
                if (!copter1.GetAlive() && !p1CanGo && !p2CanGo)
                {
                    copter1.Expode();
                }
                if (!copter2.GetAlive() && !p2CanGo && !p1CanGo)
                {
                    copter2.Expode();
                }
            }

            Invalidate();        
        }

#region TerrainStuff

        public void Splode()
        {            
            for (int i = 0; i < 80; i++)
            {
                cordsArray[i, row] = 0;
            }
            for (int i = 0; i < 52; i++)
            {
                cordsArray[column, i] = 0;
            }


            //Top right
            for (int i = 80; i > column; i--)
            {
                for (int j = 0; j <= row - 1; j++)
                {
                    cordsArray[i, j] = cordsArray[i - 1, j + 1];
                }
            }            

            //Bottom right
            for (int i = 80; i > column; i--)
            {
                for (int j = 52; j >= row + 1; j--)
                {
                    cordsArray[i, j] = cordsArray[i - 1, j - 1];
                }
            }

            //Top Left
            for (int i = 0; i <= column; i++)
            {
                for (int j = 0; j <= row - 1; j++)
                {
                    cordsArray[i, j] = cordsArray[i + 1, j + 1];
                }
            }

            //Bottom Left
            for (int i = 0; i <= column; i++)
            {
                for (int j = 52; j >= row + 1; j--)
                {
                    cordsArray[i, j] = cordsArray[i + 1, j - 1];
                }
            }


        }

        public void MoveTerrainLeft()
        {
            for (int i = 0; i < 4999; i++)
            {
                for (int j = 0; j < 53; j++)
                {
                    cordsArray[i, j] = cordsArray[i + 1, j];
                }
            }
        }

        public void FillCords()
        {
            //Clear
            for (int i = 0; i < 5000; i++)
            {
                for (int j = 0; j < 53; j++)
                {
                    cordsArray[i, j] = 0;
                }
            }

            Random rnd = new Random();

            //Fill
            for (int i = 150; i < 4999; i += 50)
            {
                int yLoc = rnd.Next(4, 35);
                MakeSection(i, yLoc, i + 3, yLoc + 10);
            }

            for (int i = 150; i < 4999; i += 70)
            {
                int length = rnd.Next(4, 10);
                int width = rnd.Next(1, 3);
                int yLoc = rnd.Next(4, 35);
                MakeSection(i, yLoc, i + length, yLoc + width);
            }

            //Top/bottom
            for (int j = 0; j < 3; j++)
            {

                for (int i = 0; i < 5000; i++)
                {
                    cordsArray[i, j] = 1;

                }
            }

            for (int j = 50; j < 53; j++)
            {

                for (int i = 0; i < 5000; i++)
                {
                    cordsArray[i, j] = 1;

                }
            }

            //Hills and such
            int yLoc2 = 0;
            int xLoc2 = 200;
            bool goDown = true;
            for (int i = 0; i < 4000; i++)
            {
                xLoc2++;
                int height = rnd.Next(6, 16);
                int xDist = rnd.Next(1, 5);
                int height2 = rnd.Next(34, 38);
                if (i % xDist == 0)
                {
                    if (goDown)
                    {
                        yLoc2++;
                        if (yLoc2 > height)
                        {
                            goDown = false;
                        }
                    }
                    else
                    {
                        yLoc2--;
                        if (yLoc2 <= 3)
                        {
                            goDown = true;
                        }
                    }
                }
                MakeSection(xLoc2, 1, xLoc2 + 2, yLoc2);
                MakeSection(xLoc2, yLoc2 + height2, xLoc2 + 2, 52);
            }
        }

        public void MakeSection(int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    cordsArray[i, j] = 1;
                }
            }
        }

        public void DrawOrNot()
        {
            int i, j = 0;
            for (i = 0; i < 80; i++)
            {
                for (j = 0; j < 53; j++)
                {
                    if (cordsArray[i, j] == 1)
                    {
                        terrainList[j * 80 + i].SetShow(true);
                    }
                    else
                    {
                        terrainList[j * 80 + i].SetShow(false);
                    }
                }
            }

        }

#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = false;
            this.Focus();
        }

    }
}
