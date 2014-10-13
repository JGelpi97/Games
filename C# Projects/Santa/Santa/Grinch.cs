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
    class Grinch
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.sleigh12);
        ImageAttributes attr = new ImageAttributes();
        bool AllowShoot = true;

        public int GetBottom()
        {
            return rect.Bottom;
        }

        public int GetLeft()
        {
            return rect.Left;
        }

        public void Reset()
        {
            AllowShoot = true;
            rect.Y = 10;
        }

        public Grinch()
        {
            rect.Height = bmp.Height;
            rect.Width = bmp.Width;
            rect.X = 300;
            rect.Y = 10;
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
        }

        public void ChangeXPos(int x)
        {
            rect.X = x - 20;
        }

        public void SetAllowShoot(bool x)
        {
            AllowShoot = x;
        }

        public bool GetAllowShoot()
        {
            return AllowShoot;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public void GoUp()
        {
            if (rect.Y > -110)
            {
                rect.Y -= 4;
            }
        }

        public void GoDown()
        {
            if (rect.Y < 10)
            {
                rect.Y += 4;
            }
        }

        public Rectangle GetRect()
        {
            return rect;
        }
    }
}
