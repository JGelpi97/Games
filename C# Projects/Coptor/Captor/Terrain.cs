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

namespace Captor
{
    class Terrain
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Captor.Properties.Resources.Terrain1_10x10_);

        bool show = false;

        public Terrain(int x, int y, int shade)
        {
            rect.Height = bmp.Height;
            rect.Width = bmp.Width;
            rect.X = x;
            rect.Y = y;
            if (shade == 2)
            {
                bmp = Captor.Properties.Resources.Terrain2;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public bool GetShow()
        {
            return show;
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public void SetShow(bool x)
        {
            show = x;
        }

    }
}
