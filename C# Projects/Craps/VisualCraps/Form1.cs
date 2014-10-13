using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace VisualCraps
{
    public partial class Form1 : Form
    {
        Button btnRoll2 = new Button();
        Random randNum = new Random();
        die die1 = new die(10, 10);
        die die2 = new die(130, 10);
        score theScore = new score();
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            btnRoll2.Top = 375;
            btnRoll2.Left = 153;
            btnRoll2.Height = 27;
            btnRoll2.Width = 78;
            btnRoll2.Text = "Roll";
            this.Controls.Add(btnRoll2);
            btnRoll2.Click += new EventHandler(btnRoll2_Click);
        }

        void btnRoll2_Click(object sender, EventArgs e)
        {
            if (btnRoll2.Text == "Roll")
            {
                die1.roll(randNum);
                die2.roll(randNum);
                lblDie1.Text = Convert.ToString(die1.getValue());
                lblDie2.Text = Convert.ToString(die2.getValue());
                theScore.setTotalScore(die1.getValue(), die2.getValue());
                lblTotal.Text = Convert.ToString(die1.getValue() + die2.getValue());
                if (theScore.checkForWin() == "win")
                {
                    lblStatus.Text = "You Win!";
                    btnRoll2.Text = "Restart";
                }

                if (theScore.checkForLoss() == "lose")
                {
                    lblStatus.Text = "You Lose";
                    btnRoll2.Text = "Restart";
                }
                else
                {
                    lblPoint.Text = Convert.ToString(theScore.returnPoint());
                }
                die1.chooseDie();
                die2.chooseDie();
            }
            else //Reset
            {
                lblDie1.Text = "0";
                lblDie2.Text = "0";
                lblPoint.Text = "0";
                lblTotal.Text = "0";
                lblStatus.Text = "";
                btnRoll2.Text = "Roll";

            }
            Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            die1.drawDie(g);
            die2.drawDie(g);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
    
    class die
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(VisualCraps.Properties.Resources.die1);
        ImageAttributes attr = new ImageAttributes();
        
        int value;
        public void moveDie()
        {

        }

        public void roll(Random randNum)
        {
            value = randNum.Next(1, 7);
        }
        public int getValue()
        {
            return (value);
        }
        public void chooseDie()
        {
            if (value == 1)
            {
                bmp = (VisualCraps.Properties.Resources.die1);
            }
            else if (value == 2)
            {
                bmp = (VisualCraps.Properties.Resources.die2);
            }
            else if (value == 3)
            {
                bmp = (VisualCraps.Properties.Resources.die3);
            }
            else if (value == 4)
            {
                bmp = (VisualCraps.Properties.Resources.die4);
            }
            else if (value == 5)
            {
                bmp = (VisualCraps.Properties.Resources.die5);
            }
            else if (value == 6)
            {
                bmp = (VisualCraps.Properties.Resources.die6);
            }

        }

        public void drawDie(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public die(int x, int y)
        {
            rect.Height = 50;
            rect.Width = 50;
            rect.X = x; rect.Y = y;
        }
    }

    class score
    {
        int totalScore;
        int point = 0;
        

        public void setTotalScore(int die1, int die2)
        {
            totalScore = die1 + die2;
        }

        public void reset()
        {
            point = 0;
            totalScore = 0;
        }

        public string checkForWin()
        {
            if (point != 0 && point == totalScore)
            {                
                reset();
                return "win";
            }
            else if ((totalScore == 11 || totalScore == 7) && point == 0)
            {
                reset();
                return "win";
            }
            else
            {
                return "neither";
            }
        }

        public string checkForLoss()
        {
            if ((point == 0) && (totalScore == 2 || totalScore == 3 || totalScore == 12))
            {
                reset();
                return "lose";
            }
            else if (point != 0 && totalScore == 7)
            {
                reset();
                return "lose";
            }
            else if (point == 0)
            {
                point = totalScore;
                return "neither";
            }
            else
            {
                return "neither";
            }
        }

        public int returnPoint()
        {
                return point;
        }

    }
}
