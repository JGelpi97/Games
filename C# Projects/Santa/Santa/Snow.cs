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
    class Snow
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.Snow1);
        ImageAttributes attr = new ImageAttributes();
        int xSpeed = 7;
        int ySpeed = 1;
        int throttleSpeedBonus = 0;
        bool alive = true;

        public Snow(Random rnd)
        {
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            int type = rnd.Next(1, 5);
            if (type == 2)
            {
                bmp = Santa.Properties.Resources.Snow2;
                xSpeed = 10;                
            }
            else if (type == 3)
            {
                bmp = Santa.Properties.Resources.Snow3;
                xSpeed = 14;
                ySpeed = -1;
            }
            else if (type == 4)
            {
                bmp = Santa.Properties.Resources.Snow2;
                xSpeed = 8;
                ySpeed = -1;
            }
            rect.X = 810;
            int y = rnd.Next(-50, 570);
            rect.Y = y;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
        }

        public void MoveSnow()
        {
            rect.X -= (xSpeed + throttleSpeedBonus);
            rect.Y += ySpeed;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);        
        }


        public Rectangle GetRect()
        {
            return rect;
        }

        public bool GetAlive()
        {
            return alive;
        }

        public void KillSnow()
        {
            alive = false;
        }

        public void ChangeCurve(Random rnd)
        {
            int x = rnd.Next(1, 3);
            if (x == 1)
            {
                if (ySpeed == -1)
                {
                    ySpeed = 1;
                }
                else
                {
                    ySpeed = -1;
                }
            }
        }

        public void UdjustSpeedBonus(int x)
        {
            throttleSpeedBonus = x;
        }
    }
}
