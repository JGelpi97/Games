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

namespace SnakeFu
{
    class SnakePiece
    {
        Bitmap bmp = new Bitmap(SnakeFu.Properties.Resources.SnakeRed);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        bool alive = true;

        public SnakePiece(int xLoc, int yLoc, string color)
        {
            rect.X = xLoc;
            rect.Y = yLoc;
            rect.Size = bmp.Size;
            if (color == "red")
            {
                bmp = SnakeFu.Properties.Resources.SnakeRed;
            }
            if (color == "blue")
            {
                bmp = SnakeFu.Properties.Resources.SnakeBlue;
            }
            if (color == "yellow")
            {
                bmp = SnakeFu.Properties.Resources.SnakeYellow;
            }
            if (color == "green")
            {
                bmp = SnakeFu.Properties.Resources.SnakeGreen;
            }

        }

        public bool GetAlive()
        {
            return alive;
        }

        public void Kill()
        {
            alive = false;
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public void Draw(Graphics g)
        {
           g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
