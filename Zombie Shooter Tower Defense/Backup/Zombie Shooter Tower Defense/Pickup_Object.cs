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

namespace Zombie_Shooter_Tower_Defense
{
    class Pickup_Object
    {
        Bitmap bmp = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.flare);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        bool alive = true;
        string type;

        public Pickup_Object(string _type, Random random)
        {
            type = _type;
            if (type == "health")
            {
                bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.healthPack;
            }
            else if (type == "flare")
            {
                bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.flareBox;
            }
            rect.Size = bmp.Size;
            int x = random.Next(1, 5);
            if (x == 1)
            {
                rect.Location = new Point(30, 40);
            }
            else if (x == 2)
            {
                rect.Location = new Point(700, 60);
            }
            else if (x == 3)
            {
                rect.Location = new Point(30, 500);
            }
            else if (x == 4)
            {
                rect.Location = new Point(700, 500);
            }
        }

        public string Type()
        {
            return type;
        }

        public Rectangle Rect()
        {
            return rect;
        }

        public void Kill()
        {
            alive = false;
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
