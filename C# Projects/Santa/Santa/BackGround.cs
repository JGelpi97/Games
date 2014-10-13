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
    class BackGround
    {
        Rectangle rect1 = new Rectangle();
        Bitmap back1 = new Bitmap(Santa.Properties.Resources.Something1);
        ImageAttributes attr = new ImageAttributes();
        Rectangle rect2 = new Rectangle();
        Bitmap back2 = new Bitmap(Santa.Properties.Resources.Something2);
        int speed = 9;
        int throttleSpeedBonus = 0;

        public BackGround()
        {            
            rect1.Y = 0;
            rect1.X = 0;
            rect2.Y = 0;
            rect2.X = 800;
            rect1.Width = 800;
            rect1.Height = 600;
            rect2.Width = 800;
            rect2.Height = 600;

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(back1, rect1, 0, 0, 800, 600, GraphicsUnit.Pixel, attr);
            g.DrawImage(back2, rect2, 0, 0, 800, 600, GraphicsUnit.Pixel, attr);        
        }

        public void MoveBackGround()
        {
            rect1.X -= (speed + throttleSpeedBonus);
            rect2.X -= (speed + throttleSpeedBonus);
            if (rect2.Right < 0)
            {
                rect2.X = rect1.Right;
            }
            if (rect1.Right < 0)
            {
                rect1.X = rect2.Right;
            }
        }

        public void UdjustSpeedBonus(int x)
        {
            throttleSpeedBonus = x;
        }

    }
}
