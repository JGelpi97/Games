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
    class GoodPresent
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.PresentGood1);
        ImageAttributes attr = new ImageAttributes();

        int type;
        int points;
        int Xspeed;
        int Yspeed;
        int throttleSpeedBonus = 0;
        bool alive = true;


        public void UdjustSpeedBonus(int x)
        {
            throttleSpeedBonus = x;
        }

        public GoodPresent(Random rnd)
        {
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            type = rnd.Next(1, 4);
            if (type == 1)
            {
                points = 5;
                Yspeed = 4;
                Xspeed = 1;
            }
            else if (type == 2)
            {
                points = 10;
                Yspeed = 5;
                Xspeed = 2;
                bmp = Santa.Properties.Resources.PresentGood2;
            }
            else if (type == 3)
            {
                points = 20;
                Yspeed = 6;
                Xspeed = 1;
                bmp = Santa.Properties.Resources.PresentGood3;
            }
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            int xLoc = rnd.Next(100, 820);
            rect.X = xLoc;
            rect.Y = -50;
        }

        public int GetPoints()
        {
            return points;
        }

        public void MovePresent()
        {
            rect.Y += Yspeed;
            rect.X -= (Xspeed + throttleSpeedBonus);
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

        public void KillPresent()
        {
            alive = false;
        }

    }
}
