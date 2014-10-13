using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Zombie_Shooter_Tower_Defense
{
    class Flare
    {
        Bitmap bmp = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.flare);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        int burnOutTime = 600;
        bool alive = true;
        bool drewLight = false;
        int timeUntilStartsToBurnOut = 150;

        public Flare(int x, int y)
        {
            rect.Size = bmp.Size;
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.X = x;
            rect.Y = y;
        }

        public bool DrewLight()
        {
            return drewLight;
        }

        public void TheLightWasDraw()
        {
            drewLight = true;
        }

        public void DecreaseBurnOutTime()
        {
            timeUntilStartsToBurnOut--;
            if (timeUntilStartsToBurnOut < 0)
            {
                burnOutTime--;
                if (burnOutTime <= 0)
                    alive = false;
            }
        }

        public int TimeLeftToLive()
        {
            return burnOutTime;
        }

        public Rectangle Rect()
        {
            return rect;
        }

        public bool Alive()
        {
            return alive;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

    }
}
