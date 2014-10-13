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
    class Bullet
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.Bullet);
        ImageAttributes attr = new ImageAttributes();


        bool alive = true;

        public Bullet(int santaX, int santaY)
        {
            rect.X = santaX + 40;
            rect.Y = santaY + 12;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public void MoveBullet()
        {            
            rect.Y -= 12;
        }

        public bool GetAlive()
        {
            return alive;
        }

        public void KillBullet()
        {
            alive = false;
        }

        public Rectangle GetRect()
        {
            return rect;
        }
    }
}
