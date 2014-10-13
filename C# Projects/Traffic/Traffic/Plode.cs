using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Traffic
{
    class Plode
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Traffic.Properties.Resources.plode);
        ImageAttributes attr = new ImageAttributes();

        public Plode()
        {
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
            attr.SetColorKey(Color.Black, Color.Black);
        }

        public void SetRectangle(Rectangle rect1)
        {
            rect.X = (rect1.X + rect1.Width / 2) - (rect.Width / 2);
            rect.Y = (rect1.Y + rect1.Height / 2) - (rect.Height / 2);
        }


        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
