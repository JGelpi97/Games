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

namespace Santa
{
    public partial class Form1 : Form
    {
        Timer gameTimer = new Timer();
        Graphics g;
        Sleigh sleigh = new Sleigh();
        List<GoodPresent> LstGoodPresents = new List<GoodPresent>();
        List<BadPresent> LstBadPresents = new List<BadPresent>();
        List<Snow> LstSnow = new List<Snow>();
        List<Bullet> LstBullets = new List<Bullet>();
        Random rnd = new Random();
        Scoring theScore = new Scoring();
        BackGround back1 = new BackGround();
        Grinch grinch = new Grinch();
        int presentTimer;
        int snowTimer;
        int snowDirTimer;
        int grinchShowTimer;
        int grinchBombTimer;
        int fireTimer = 10;
        int someImportantVariable = 10;
        int addLifeCounter = 0;

        public Form1()
        {            
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Text = "Some Santa Game - Joey Gelpi";
            gameTimer.Interval = 50;            
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            this.Width = 800;
            this.Height = 600;
            this.Controls.Add(theScore.GetPointsLbl());
            this.Controls.Add(sleigh.GetHpLbl());
            theScore.GetPointsLbl().MouseUp +=new MouseEventHandler(Form1_MouseUp);
            theScore.GetPointsLbl().MouseDown += new MouseEventHandler(Form1_MouseDown);
            sleigh.GetHpLbl().MouseDown +=new MouseEventHandler(Form1_MouseDown);
            sleigh.GetHpLbl().MouseUp += new MouseEventHandler(Form1_MouseUp);
            btnOpenHelp.GotFocus += new EventHandler(btnOpenHelp_GotFocus);
            btnPause.GotFocus += new EventHandler(btnPause_GotFocus);
        }

        void btnPause_GotFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        void btnOpenHelp_GotFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            back1.Draw(g);
            sleigh.Draw(g);
            grinch.Draw(g);
            //Draw snow/presents
            //Decide if you want to draw
            foreach (GoodPresent prsnt in LstGoodPresents)
            {
                if (prsnt.GetAlive())
                    prsnt.Draw(g);
            }
            foreach (BadPresent prsnt in LstBadPresents)
            {
                if (prsnt.GetAlive())
                    prsnt.Draw(g);
            }
            theScore.Draw(g);
            foreach (Snow snow in LstSnow)
            {
                if (snow.GetAlive())
                    snow.Draw(g);
            }
            foreach (Bullet b in LstBullets)
            {            
                if (b.GetAlive())
                    b.Draw(g);
            }
        }

        public void AskPlayAgain()
        {
            DialogResult x = MessageBox.Show("Play Again?", "Santa", MessageBoxButtons.YesNo);
            if (x == DialogResult.No)
            {
                Application.Exit();
            }
            if (x == DialogResult.Yes)
            {
                sleigh.Reset();
                grinch.Reset();
                theScore.Reset();
                Reset();
            }
        }

        public void Reset()
        {
            LstBadPresents.Clear();
            LstBullets.Clear();
            LstGoodPresents.Clear();
            LstSnow.Clear();
            picGameOver.Visible = false;
            gameTimer.Enabled = true;
        }

        void gameTimer_Tick(object sender, EventArgs e)
        {
            if (sleigh.GetAlive())
            {
                if (!grinch.GetAllowShoot())
                {
                    grinchShowTimer++;
                    grinch.GoUp();
                }                
                fireTimer--;
                snowTimer++;
                snowDirTimer++;
                presentTimer++;
                grinchBombTimer++;
                back1.MoveBackGround();
                grinch.ChangeXPos(sleigh.GetX());

                if (theScore.GetPoints() >= someImportantVariable)
                {
                    sleigh.AllowShoot();
                }

                //Add lives

                //Grinch Stuff
                //Show him if 150 ticks/ allow shoot
                if (grinchShowTimer > 130)
                {
                    grinch.GoDown();
                    grinch.SetAllowShoot(true);
                }

                //Make rocket
                if (grinchBombTimer > 30 && grinch.GetAllowShoot())
                {
                    grinchBombTimer = 0;
                    LstBadPresents.Add(new BadPresent(rnd, grinch.GetLeft(), grinch.GetBottom(), 4));
                }

                //Make Snow/Presents
                LstSnow.Add(new Snow(rnd));

                if (presentTimer == 40)
                {
                    presentTimer = 0;
                    int x = rnd.Next(1, 4);
                    if (x == 3)
                    {
                        LstBadPresents.Add(new BadPresent(rnd,0,0,0));
                    }
                    else
                    {
                        LstGoodPresents.Add(new GoodPresent(rnd));
                    }
                }

                //Change Snow Dir
                if (snowDirTimer == 60)
                {
                    foreach (Snow snow in LstSnow)
                    {
                        if (snow.GetAlive())
                            snow.ChangeCurve(rnd);
                    }
                    snowDirTimer = 0;
                }

                //Change snow/background/present(X direction) speed
                if (sleigh.GetSpeed() > 0)
                {
                    back1.UdjustSpeedBonus(sleigh.GetSpeed() - (sleigh.GetSpeed() / 3));
                    foreach (GoodPresent prsnt in LstGoodPresents)
                    {
                        prsnt.UdjustSpeedBonus(1);
                    }

                    foreach (BadPresent prsnt in LstBadPresents)
                    {
                        prsnt.UdjustSpeedBonus(1);
                    }

                    foreach (Snow snow in LstSnow)
                    {
                        snow.UdjustSpeedBonus(sleigh.GetSpeed());
                    }
                }
                else if (sleigh.GetSpeed() < 0)
                {
                    back1.UdjustSpeedBonus(0);

                    foreach (Snow snow in LstSnow)
                    {
                        snow.UdjustSpeedBonus(0);
                    }
                    foreach (GoodPresent prsnt in LstGoodPresents)
                    {
                        prsnt.UdjustSpeedBonus(0);
                    }

                    foreach (BadPresent prsnt in LstBadPresents)
                    {
                        prsnt.UdjustSpeedBonus(0);
                    }
                }

                MoveStuff();
                KillCollideStuff();
                sleigh.ChangeMoveAmount();
                sleigh.MoveSleigh();
                if (sleigh.CheckForDeadness())
                {
                    picGameOver.Visible = true;
                    AskPlayAgain();
                }
                Invalidate();
            }
        }

        public void KillCollideStuff()
        {
            //Set alive to false so dont draw/move
            //Collected
            foreach (GoodPresent prsnt in LstGoodPresents)
            {
                if (prsnt.GetRect().IntersectsWith(sleigh.GetRect()) && prsnt.GetAlive())
                {
                    addLifeCounter += prsnt.GetPoints();
                    if (addLifeCounter >= 150)
                    {
                        addLifeCounter = 0;
                        sleigh.AddLife();
                    }
                    theScore.UpdatePoints(prsnt.GetPoints());
                    prsnt.KillPresent();
                }
            }

            foreach (BadPresent prsnt in LstBadPresents)
            {
                if (prsnt.GetRect().IntersectsWith(sleigh.GetRect()) && prsnt.GetAlive())
                {
                    addLifeCounter += prsnt.GetPoints();
                    if (addLifeCounter >= 150)
                    {
                        addLifeCounter = 0;
                        sleigh.AddLife();
                    } 
                    theScore.UpdatePoints(prsnt.GetPoints());
                    prsnt.KillPresent();
                    if (prsnt.GetType() == 4)
                    {
                        sleigh.ChangeHp(-2);
                    }
                    else
                    {
                        sleigh.ChangeHp(-1);
                    }
                }
            }

            //Shoot grinch
            foreach (Bullet b in LstBullets)
            {
                if (b.GetRect().IntersectsWith(grinch.GetRect()) && b.GetAlive())
                {
                    grinchShowTimer = 0;
                    grinch.SetAllowShoot(false);
                    b.KillBullet();
                }
            }
            //off screen
            foreach (GoodPresent prsnt in LstGoodPresents)
            {
                if (prsnt.GetRect().Y > this.Height && prsnt.GetAlive())
                {
                    prsnt.KillPresent();                    
                }
            }
            foreach (BadPresent prsnt in LstBadPresents)
            {
                if (prsnt.GetRect().Y > this.Height && prsnt.GetAlive())
                {
                    prsnt.KillPresent();
                }
            }
            foreach (Snow snow in LstSnow)
            {
                if (snow.GetRect().X < -10 && snow.GetAlive())
                {
                    snow.KillSnow();
                }
            }
            foreach (Bullet b in LstBullets)
            {
                if (b.GetRect().X < -5 && b.GetAlive())
                {
                    b.KillBullet();
                }
            }
        }

        public void MoveStuff()
        {
            //Move presents/snow
            foreach (GoodPresent prsnt in LstGoodPresents)
            {
                if (prsnt.GetAlive())
                    prsnt.MovePresent();
            }
            foreach (BadPresent prsnt in LstBadPresents)
            {
                if (prsnt.GetAlive())
                    prsnt.MovePresent();
            }
            foreach (Snow snow in LstSnow)
            {
                if (snow.GetAlive())
                    snow.MoveSnow();
            }
            foreach (Bullet b in LstBullets)
            {
                if (b.GetAlive())
                    b.MoveBullet();
            }
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            sleigh.SetThrottle(false);
            sleigh.SetSlowDown();
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sleigh.SetThrottle(true);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space && fireTimer < 0 && sleigh.GetCanShoot())
            {
                LstBullets.Add(new Bullet(sleigh.GetX(), sleigh.GetY()));
                fireTimer = 10;
            }

        }

        private void btnCloseHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = false;
            this.Focus();
            gameTimer.Enabled = true;
        }

        private void btnOpenHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = true;
            gameTimer.Enabled = false;
            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = !gameTimer.Enabled;
            this.Focus();
        }

    }
}
