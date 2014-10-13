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
    class Sleigh
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.santa1);
        ImageAttributes attr = new ImageAttributes();
        
        Label lblHp = new Label();
        bool throttle;
        int speed = 0;
        int hitPoints = 5;
        bool alive = true;
        bool canShoot = false;

        public void Reset()
        {
            hitPoints = 5;
            speed = 0;
            lblHp.Text = "Lives: " + hitPoints;
            canShoot = false;
            alive = true;
            throttle = false;
            bmp = Santa.Properties.Resources.santa1;
            rect.X = 400;
            rect.Y = 500;
        }

        public void AddLife()
        {
            hitPoints++;
            lblHp.Text = "Lives: " + hitPoints;
        }

        public bool GetCanShoot()
        {
            return canShoot;
        }

        public void AllowShoot()
        {
            canShoot = true;
            bmp = Santa.Properties.Resources.santaGun;
        }

        public int GetX()
        {
            return rect.X;
        }

        public int GetY()
        {
            return rect.Y;
        }

        public bool CheckForDeadness()
        {
            if (hitPoints <= 0)
            {
                alive = false; 
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetAlive()
        {
            return alive;
        }

        public int GetHp()
        {
            return hitPoints;
        }

        public Sleigh()
        {
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            rect.X = 400;
            rect.Y = 500;
            lblHp.Left = 664;
            lblHp.Top = 75;
            lblHp.Text = "Lives: " + hitPoints;
            lblHp.AutoSize = true;
            lblHp.Font = new Font("Courier New", 12, FontStyle.Bold);
            lblHp.BackColor = Color.Transparent;
        }

        public void SetThrottle(bool throttled)
        {
            throttle = throttled;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public void ChangeMoveAmount()
        {
            if (throttle)
            {
                if (speed <= 16)
                {
                    speed += 1;
                }
            }
            else if (!throttle)
            {
                if (speed > -16)
                {
                    speed -= 1;
                }
            }
        }

        public void SetSlowDown()
        {
            speed = speed / 2;
        }

        public void MoveSleigh()
        {
                rect.X += speed;
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void ChangeHp(int x) 
        {
            hitPoints += x;
            lblHp.Text = "Lives: " + hitPoints;
        }

        public Label GetHpLbl()
        {
            return lblHp;
        }

        public bool GetThrottle()
        {
            return throttle;
        }
    }
}
