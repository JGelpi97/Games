using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Traffic
{
    public partial class Form1 : Form
    {
        List<Car> lstCars = new List<Car>();
        Graphics g;
        Rectangle clickRect = new Rectangle(-1, -1, 1, 1);
        Random random = new Random();
        Timer gameTimer = new Timer();
        Score theScore = new Score();
        Plode plode = new Plode();
        int carTimer = 00;
        int pointsToIncreaseRate = 10;
        int releaseTime = 45;
        int pointCounter = 0;
        bool dead = false;

        public Form1()
        {
            InitializeComponent();
            Text = "Geometry Rush";
            Width = 800;
            Height = 600;
            BackgroundImage = Traffic.Properties.Resources.board2;
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Form1_Paint);
            MouseClick += new MouseEventHandler(Form1_MouseClick);
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            StartPosition = FormStartPosition.CenterScreen;
            LostFocus += new EventHandler(Form1_LostFocus);            
            lstCars.Add(new Car(random, lstCars));
            gameTimer.Enabled = true;
            gameTimer.Interval = 50;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            Controls.Add(theScore.GetScoreLbl());
            Controls.Add(theScore.GetHighScoreLbl());
            Controls.Add(theScore.GetHelpLbl());
        }

        void Form1_LostFocus(object sender, EventArgs e)
        {
            gameTimer.Enabled = false;
        }

        void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!dead)
            {
                //Increase release rate
                if (pointCounter >= pointsToIncreaseRate && releaseTime > 15)
                {
                    pointCounter = 0;
                    releaseTime -= 7;
                    if (releaseTime < 15)
                    {
                        releaseTime = 15;
                    }
                }
                //Make car
                int x = 0;
                carTimer++;
                if (carTimer > releaseTime)
                {
                    foreach (Car car in lstCars)
                    {
                        if (!car.GetAlive())
                        {
                            car.ResetMakeCar(random, lstCars);
                            x = 1;
                            break;
                        }
                    }
                    if (x == 0)
                    {
                        lstCars.Add(new Car(random, lstCars));
                    }
                    carTimer = 0;
                }

                //Do stuff to every car
                foreach (Car car in lstCars)
                {
                    if (car.GetAlive())
                    {
                        car.Move();
                        Collide();
                    }
                    if (car.GetBraked() && car.GetAlive())
                    {
                        car.BrakeStuff();
                    }
                    if (car.GetAlive() && car.OffScreen())
                    {
                        theScore.AddPoint();
                        car.Kill();
                        pointCounter++;
                    }
                }
                AutoBrake();
            }

            Invalidate();
        }

        public void AutoBrake()
        {
            foreach (Car car1 in lstCars)
            {
                if (car1.GetBraked() && car1.GetAlive())
                {
                    foreach (Car car2 in lstCars)
                    {
                        if ((car1 != car2) && (car2.GetDefaultSpeed()) && (car2.GetAlive()) && (car2.GetDirection() == car1.GetDirection()) && (car2.GetLane() == car1.GetLane()))
                        {
                            if ((car1.GetDirection() == "R") && (car1.GetRect().Left > car2.GetRect().Right) && ((car1.GetRect().Left - car2.GetRect().Right) < 15))
                            {
                                car2.Brake();
                            }
                            if ((car1.GetDirection() == "L") && (car1.GetRect().Right < car2.GetRect().Left) && ((car2.GetRect().Left - car1.GetRect().Right) < 15))
                            {
                                car2.Brake();
                            }
                            if ((car1.GetDirection() == "D") && (car1.GetRect().Top > car2.GetRect().Bottom) && ((car1.GetRect().Top - car2.GetRect().Bottom) < 15))
                            {
                                car2.Brake();
                            }
                            if ((car1.GetDirection() == "U") && (car1.GetRect().Bottom < car2.GetRect().Top) && ((car2.GetRect().Top - car1.GetRect().Bottom) < 15))
                            {
                                car2.Brake();
                            }

                        }
                    }
                }
            }
        }

        public void Collide()
        {
            #region Not Circles
            foreach (Car car1 in lstCars)
            {
                if (car1.GetAlive())
                {
                    Rectangle[] HitBoxes = car1.GetHitBoxes();
                    foreach (Car car2 in lstCars)
                    {
                        if (car2.GetAlive())
                        {
                            Rectangle[] HitBoxes1 = car2.GetHitBoxes();
                            if ((car1 != car2) && (!car1.OffScreen()) && (!car2.OffScreen()) &&
                                (car1.GetRect().IntersectsWith(car2.GetRect())) &&
                                (car1.GetTypeOf() != "circ") && (car2.GetTypeOf() != "circ"))
                            {
                                foreach (Rectangle box in HitBoxes)
                                {
                                    foreach (Rectangle box1 in HitBoxes1)
                                    {
                                        if (box.IntersectsWith(box1))
                                        {                                            
                                            box.Intersect(box1);
                                            Die(box);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Stupid circle collision

            foreach (Car car1 in lstCars)
            {
                if (car1.GetAlive())
                {
                    Rectangle[] HitBoxes1 = car1.GetHitBoxes();
                    foreach (Car car2 in lstCars)
                    {
                        if (car2.GetAlive())
                        {
                            Rectangle[] HitBoxes2 = car2.GetHitBoxes();
                            if ((car1 != car2) && (!car1.OffScreen()) && (!car2.OffScreen()) && (car1.GetTypeOf() == "circ" || car2.GetTypeOf() == "circ") && (car1.GetRect().IntersectsWith(car2.GetRect())))
                            {
                                if (car1.GetTypeOf() == "circ" && car2.GetTypeOf() == "circ")
                                {
                                    double x = (car1.GetRect().X - car2.GetRect().X) * (car1.GetRect().X - car2.GetRect().X);
                                    double y = (car1.GetRect().Y - car2.GetRect().Y) * (car1.GetRect().Y - car2.GetRect().Y);
                                    double dist = Math.Sqrt(x + y);
                                    double radius = car1.GetRect().Width / 2;
                                    if (dist <= (radius * 2))
                                    {
                                        Rectangle rect = car1.GetRect();
                                        rect.Intersect(car2.GetRect());
                                        Die(rect);
                                    }
                                }
                                else //Only 1 is circle
                                {
                                    int left;
                                    int right;
                                    int top;
                                    int bottom;
                                    int middleHoriz;
                                    int middleVert;
                                    int circleMiddleX;
                                    int circleMiddleY;

                                    if (car1.GetTypeOf() != "circ")
                                    {
                                        foreach (Rectangle box in HitBoxes1)
                                        {
                                            left = box.Left;
                                            right = box.Right;
                                            top = box.Top;
                                            bottom = box.Bottom;
                                            middleHoriz = ((right - left) / 2) + left;
                                            middleVert = ((bottom - top) / 2) + top;
                                            circleMiddleX = car2.GetRect().X + 22;
                                            circleMiddleY = car2.GetRect().Y + 22;
                                            double x;
                                            double y;
                                            double dist;
                                            //Top right
                                            x = Math.Pow(left - circleMiddleX, 2);
                                            y = Math.Pow(top - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(right - circleMiddleX, 2);
                                            y = Math.Pow(top - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(left - circleMiddleX, 2);
                                            y = Math.Pow(bottom - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(right - circleMiddleX, 2);
                                            y = Math.Pow(bottom - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(middleHoriz - circleMiddleX, 2);
                                            y = Math.Pow(top - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(middleHoriz - circleMiddleX, 2);
                                            y = Math.Pow(bottom - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(left - circleMiddleX, 2);
                                            y = Math.Pow(middleVert - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }
                                            x = Math.Pow(right - circleMiddleX, 2);
                                            y = Math.Pow(middleVert - circleMiddleY, 2);
                                            dist = Math.Sqrt(x + y);
                                            if (dist < 22)
                                            {
                                                Rectangle rect = car1.GetRect();
                                                rect.Intersect(car2.GetRect());
                                                Die(rect);

                                            }

                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        public void Die(Rectangle box)
        {
            dead = true;
            plode.SetRectangle(box);
            theScore.CheckHighScore();
        }

        public void Reset()
        {
            theScore.Reset();
            lstCars.Clear();
            gameTimer.Enabled = true;
            dead = false;
            pointCounter = 0;
            releaseTime = 45;
            carTimer = 0;
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameTimer.Enabled)
            {
                clickRect.Location = new Point(e.X, e.Y);
                foreach (Car car in lstCars)
                {
                    if (clickRect.IntersectsWith(car.GetRect()))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            car.SpeedUp();
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            car.Brake();
                        }
                    }
                }
                clickRect.Location = new Point(-1, -1);
            }
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {            
            g = e.Graphics;
            foreach (Car car in lstCars)
            {
                if (car.GetAlive())
                {
                    car.Draw(g);
                }
            }
            if (dead)
            {
                plode.Draw(g);
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Reset();
            }
            if (e.KeyCode == Keys.Space && dead == false)
            {
                Collide();
                gameTimer.Enabled = !gameTimer.Enabled;
            }
        }
    }
}
