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
    class Bullet
    {
        Bitmap bmp = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.Bullet);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Random random = new Random();
        int damage = 0;
        double gotoX, gotoY, xSpeed, ySpeed, xLoc, yLoc, rise, run;
        int speed = 30;
        bool alive = true;
        int range;
        string type;
        int moveCount = 0;
        bool isPlayerBullet = false;

        public Bullet(int goX, int goY, int xStartPoint, int yStartPoint, string type)
        {
            MakeReuseBullet(goX, goY, xStartPoint, yStartPoint, type);
        }

        public Bullet(int goX, int goY, int xStartPoint, int yStartPoint, int shotGunBulletNumber)
        {
            MakeReuseBullet(goX, goY, xStartPoint, yStartPoint, shotGunBulletNumber);
        }

        public Bullet(string turretType, int turretDamage, int turretLevel, int goX, int goY, int xStartPoint, int yStartPoint)
        {
            MakeReuseBullet(turretType, turretDamage, turretLevel, goX, goY, xStartPoint, yStartPoint);
        }

        public void MakeReuseBullet(int goX, int goY, int xStartPoint, int yStartPoint, int shotGunBulletNumber)
        {
            isPlayerBullet = true;
            moveCount = 2;
            //Shotgun
            bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.Bullet;
            speed = 30;
            damage = 3;
            range = 8;
            alive = true;
            rect.X = xStartPoint;
            rect.Y = yStartPoint;
            xLoc = rect.X;
            yLoc = rect.Y;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            gotoX = goX;
            gotoY = goY;
            rise = (gotoY - yStartPoint);
            run = (gotoX - xStartPoint);
            if (rise == 0 && run == 0)
            {
                Kill();
            }
            else
            {
                double theta = 1;
                if (goX >= xStartPoint)
                {
                    theta = Math.Atan(rise / run);
                }
                else if (goX < xStartPoint)
                {
                    theta = Math.Atan(rise / run) + Math.PI;
                }
                if (shotGunBulletNumber == 2)
                {
                    theta += .07;
                }
                else if (shotGunBulletNumber == 3)
                {
                    theta -= .07;
                }
                rise = 100 * Math.Sin(theta);
                run = 100 * Math.Cos(theta);
                gotoX = xStartPoint + run;
                gotoY = yStartPoint + rise;
                xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * speed;
                ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * speed;
            }

        }

        public void MakeReuseBullet(int goX, int goY, int xStartPoint, int yStartPoint, string type)
        {
            isPlayerBullet = true;
            moveCount = 2;
            bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.Bullet;
            if (type == "pistol")
            {
                damage = 4;
                range = 25;
                speed = 30;
            }
            else if (type == "smg")
            {
                damage = 2;
                range = 30;
                speed = 30;
            }
            else if (type == "sniper")
            {
                range = 50;
                damage = 8;
                speed = 40;
            }
            else if (type == "minigun")
            {
                range = 40;
                damage = 1;
                speed = 40;
            }
            alive = true;
            rect.X = xStartPoint;
            rect.Y = yStartPoint;
            xLoc = rect.X;
            yLoc = rect.Y;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            gotoX = goX;
            gotoY = goY;
            rise = (gotoY - yStartPoint);
            run = (gotoX - xStartPoint);
            if (rise == 0 && run == 0)
            {
                Kill();
            }
            else
            {
                double theta = 1;
                if (goX >= xStartPoint)
                {
                    theta = Math.Atan(rise / run);
                }
                else if (goX < xStartPoint)
                {
                    theta = Math.Atan(rise / run) + Math.PI;
                }
                if (type == "smg" || type == "minigun")
                {                    
                    double q = random.Next(0, 6);
                    q = q / 100;
                    int w = random.Next(0, 2);
                    if (w == 0)
                        theta += q;
                    else
                        theta -= q;
                }
                if (type == "minigun")
                {
                    int _speed = random.Next(35, 45);
                    speed = _speed;
                }
                rise = 100 * Math.Sin(theta);
                run = 100 * Math.Cos(theta);
                gotoX = xStartPoint + run;
                gotoY = yStartPoint + rise;
                xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * speed;
                ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * speed;
            }
            
        }

        public void MakeReuseBullet(string turretType, int turretDamage, int turretLevel, int goX, int goY, int xStartPoint, int yStartPoint)
        {
            isPlayerBullet = false;
            moveCount = 2;
            if (turretType == "ice")
            {
                bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.iceBullet;
            }
            else
            {
                bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.Bullet;
            }
            type = turretType;
            range = 100;
            damage = turretDamage;
            speed = 40;
            alive = true;
            rect.X = xStartPoint;
            rect.Y = yStartPoint;
            xLoc = rect.X;
            yLoc = rect.Y;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            gotoX = goX;
            gotoY = goY;
            rise = (gotoY - yStartPoint);
            run = (gotoX - xStartPoint);
            if (rise == 0 && run == 0)
            {
                Kill();
            }
            else
            {
                double theta = 1;
                if (goX >= xStartPoint)
                {
                    theta = Math.Atan(rise / run);
                }
                else if (goX < xStartPoint)
                {
                    theta = Math.Atan(rise / run) + Math.PI;
                }
                rise = 100 * Math.Sin(theta);
                run = 100 * Math.Cos(theta);
                gotoX = xStartPoint + run;
                gotoY = yStartPoint + rise;
                xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * speed;
                ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * speed;
            }
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

        public void Move()
        {
            moveCount++;
            if (moveCount > 0)
            {
                xLoc = xLoc + xSpeed;
                yLoc = yLoc + ySpeed;
                rect.X = (int)xLoc;
                rect.Y = (int)yLoc;
                range--;
                if (range < 0)
                {
                    Kill();
                }
            }
        }

        public int Damage()
        {
            return damage;
        }

        public Rectangle Rect()
        {
            return rect;
        }

        public string Type()
        {
            return type;
        }

        public void Kill()
        {
            alive = false;
        }

        public bool IsPlayerBullet()
        {
            return isPlayerBullet;
        }

        public bool Alive()
        {
            return alive;
        }

        public void Draw(Graphics g)
        {
            if (moveCount > 0)
                g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
