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
    class BadPresent
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.BadPresent1);
        ImageAttributes attr = new ImageAttributes();

        int type;
        int points;
        int Yspeed;
        int Xspeed = 1;
        int throttleSpeedBonus = 0;
        bool alive = true;

        public int GetType()
        {
            return type;
        }

        public void UdjustSpeedBonus(int x)
        {
            throttleSpeedBonus = x;
        }

        public BadPresent(Random rnd, int grinchLeft, int grinchBottom, int sentType)
        {
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            if (sentType == 0)
            {
                type = rnd.Next(1, 4);
            }
            else
            {
                type = sentType;
            }

            if (type == 1)
            {
                points = -3;
                Yspeed = 4;
            }
            else if (type == 2)
            {
                points = -8;
                Yspeed = 5;
                bmp = Santa.Properties.Resources.BadPresent2;
            }
            else if (type == 3)
            {
                points = -12;
                Yspeed = 7;
                bmp = Santa.Properties.Resources.BadPresent3;
            }
            else if (type == 4)
            {
                Yspeed = 15;
                bmp = Santa.Properties.Resources.Rocket;
            }
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            if (sentType == 0)
            {
                int xLoc = rnd.Next(100, 820);
                rect.X = xLoc;
                rect.Y = -50;
            }
            else
            {
                rect.X = grinchLeft + 12;
                rect.Y = grinchBottom - 22;
            }
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
