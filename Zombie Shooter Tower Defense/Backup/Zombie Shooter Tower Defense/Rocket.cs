using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Zombie_Shooter_Tower_Defense
{
    class Rocket
    {
        Bitmap bmp = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.Rocket);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Random random = new Random();
        int damage = 1;
        double gotoX, gotoY, xSpeed, ySpeed, xLoc, yLoc, rise, run;
        int speed = 5;
        bool alive = true;
        Enemy target = null;

        public Rocket(int goX, int goY, int startX, int startY, Enemy _target, int _damage)
        {
            MakeReuseRocket(goX, goY, startX, startY, _target, _damage);
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
        }

        public void MakeReuseRocket(int goX, int goY, int startX, int startY, Enemy _target, int _damage)
        {
            damage = _damage;
            target = _target;
            alive = true;
            rect.X = startX;
            rect.Y = startY;
            xLoc = rect.X;
            yLoc = rect.Y;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            gotoX = goX;
            gotoY = goY;
            rise = (gotoY - startY);
            run = (gotoX - startX);
            if (rise == 0 && run == 0)
            {
                Kill();
            }
            else
            {
                double theta = 1;
                if (goX >= startX)
                {
                    theta = Math.Atan(rise / run);
                }
                else if (goX < startX)
                {
                    theta = Math.Atan(rise / run) + Math.PI;
                }
                rise = 100 * Math.Sin(theta);
                run = 100 * Math.Cos(theta);
                gotoX = startX + run;
                gotoY = startY + rise;
                xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * speed;
                ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * speed;
            }
        }

        public void Move()
        {
            rise = (target.Rect().Y + (target.Rect().Height / 2) - rect.Y);
            run = (target.Rect().X + (target.Rect().Width / 2) - rect.X);
            if (rise == 0 && run == 0)
            {
            }
            else
            {
                xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * speed;
                ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * speed;
                xLoc = xLoc + xSpeed;
                yLoc = yLoc + ySpeed;
                rect.X = Convert.ToInt32(xLoc);
                rect.Y = Convert.ToInt32(yLoc);
            }

            xLoc = xLoc + xSpeed;
            yLoc = yLoc + ySpeed;
            rect.X = (int)xLoc;
            rect.Y = (int)yLoc;
        }

        public void SendNewTargetCoordinates(Enemy _target)
        {
            target = _target;
            if (!target.Alive() || !target.Visible())
                Kill();
        }

        public Enemy Target()
        {
            return target;
        }

        public void CheckForOffScreen(int width, int height)
        {
            if (rect.X < 0)
                Kill();
            if (rect.X > width)
                Kill();
            if (rect.Y > height)
                Kill();
            if (rect.Y < 0)
                Kill();
        }

        public float GetAngle()
        {
            double rise = (target.Rect().Y + (target.Rect().Height / 2) - rect.Y);
            double run = (target.Rect().X + (target.Rect().Width / 2) - rect.X);
            double theta = 1;
            if (rise == 0 && run == 0)
            {
                theta = 0;
            }
            else if (target.Rect().X + (target.Rect().Width / 2) >= rect.X)
            {
                theta = Math.Atan(rise / run);
            }
            else if (target.Rect().X + (target.Rect().Width / 2) < rect.X)
            {
                theta = Math.Atan(rise / run) + Math.PI;
            }
            theta = (theta * 360) / (Math.PI * 2);
            return (float)theta;
        }

        public void Kill()
        {
            alive = false;
        }

        public bool Alive()
        {
            return alive;
        }

        public Rectangle Rect()
        {
            return rect;
        }

        public int Damage()
        {
            return damage;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
