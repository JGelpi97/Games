using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;

namespace Captor
{
    class HeloCopter
    {
        Rectangle rect = new Rectangle();
        Rectangle rectPlayer = new Rectangle();
        Bitmap bmp = new Bitmap(Captor.Properties.Resources.CopterFlat);
        Bitmap bmpPlayer = new Bitmap(Captor.Properties.Resources.P1);
        ImageAttributes attr = new ImageAttributes();

        List<string> lstCopterTypes = new List<string>();
        string currentCopterTypeStr = "Copter";
        int currentCopterTypeIndex = 0;
        int moveAmount = 0;
        bool alive = false;
        bool throttle = false;
        int player;
        int explosionNum = 1;

        public void Expode()
        {
            if (explosionNum == 1)
            {
                explosionNum = 2;
                bmp = Captor.Properties.Resources.Ex2;
            }
            else if (explosionNum == 2)
            {
                explosionNum = 3;
                bmp = Captor.Properties.Resources.Ex3;
            }
            else if (explosionNum == 3)
            {
                explosionNum = 4;
                bmp = Captor.Properties.Resources.Ex4;
            }
            else if (explosionNum == 4)
            {
                explosionNum = 5;
                bmp = Captor.Properties.Resources.Ex5;
            }
            else if (explosionNum == 5)
            {
                explosionNum = 6;
                bmp = Captor.Properties.Resources.Ex6;
            }
            else if (explosionNum == 6)
            {
                explosionNum = 7;
                bmp = Captor.Properties.Resources.Ex7;
            }
            else if (explosionNum == 7)
            {
                explosionNum = 8;
                bmp = Captor.Properties.Resources.Ex8;
            }
            else if (explosionNum == 8)
            {
                explosionNum = 9;
                bmp = Captor.Properties.Resources.Ex9;
            }
            else if (explosionNum == 9)
            {
                explosionNum = 10;
                bmp = Captor.Properties.Resources.Ex10;
            }
            else if (explosionNum == 10)
            {
                explosionNum = 11;
                bmp = Captor.Properties.Resources.Ex11;
            }

        }

        public void StartExplode()
        {
            bmp = Captor.Properties.Resources.Ex1;
        }
        
        public HeloCopter(int player2)
        {
            player = player2;
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            lstCopterTypes.Add("Copter");
            lstCopterTypes.Add("Balloon");
            lstCopterTypes.Add("Velo");
            lstCopterTypes.Add("Banshee");
            lstCopterTypes.Add("Ufo");
            lstCopterTypes.Add("Charz");
            lstCopterTypes.Add("Superman");
            rect.Height = bmp.Height;
            rect.Width = bmp.Width;
            rect.X = 50;

            if (player == 1)
            {
                bmpPlayer = Captor.Properties.Resources.P1;
                rect.Y = 100;
            }
            else if (player == 2)
            {
                bmpPlayer = Captor.Properties.Resources.P2;
                rect.Y = 150;
            }
            rectPlayer.Width = 10;
            rectPlayer.Height = 14;
            rectPlayer.X = (rect.X + (rect.Width / 2)) - (rectPlayer.Width / 2);
            rectPlayer.Y = rect.Y - rectPlayer.Height - 4;
        }

        public void Reset()
        {
            moveAmount = 0;

            if (player == 1)
            {
                rect.Y = 100;
            }
            else
            {
                rect.Y = 150;
            }
            throttle = false;
            SetCopterPicture();
            rectPlayer.Y = rect.Y - rectPlayer.Height - 4;            
            rect.X = 50;
            rectPlayer.X = (rect.X + (rect.Width / 2)) - (rectPlayer.Width / 2);
            explosionNum = 1;
        }

        public void SetCopterPicture()
        {
            if (currentCopterTypeStr == "Copter")
            {
                bmp = (Captor.Properties.Resources.CopterFlat);
            }
            else if (currentCopterTypeStr == "Balloon")
            {
                bmp = (Captor.Properties.Resources.balloon);
            }
            else if (currentCopterTypeStr == "Velo")
            {
                bmp = (Captor.Properties.Resources.Velo);
            }
            else if (currentCopterTypeStr == "Banshee")
            {
                bmp = (Captor.Properties.Resources.Banshee);
            }
            else if (currentCopterTypeStr == "Ufo")
            {
                bmp = (Captor.Properties.Resources.UFO);
            }
            else if (currentCopterTypeStr == "Charz")
            {
                bmp = (Captor.Properties.Resources.Charz);
            }
            else if (currentCopterTypeStr == "Superman")
            {
                bmp = (Captor.Properties.Resources.Superman);
            }

        }

        public void ChangeCopterType(string x)
        {
            if (x == "R")
            {
                currentCopterTypeIndex++;
                if (currentCopterTypeIndex > lstCopterTypes.Count() - 1)
                {
                    currentCopterTypeIndex = 0;
                }
                currentCopterTypeStr = lstCopterTypes[currentCopterTypeIndex];
            }
            if (x == "L")
            {
                currentCopterTypeIndex--;
                if (currentCopterTypeIndex <  0)
                {
                    currentCopterTypeIndex = lstCopterTypes.Count() - 1;
                }
                currentCopterTypeStr = lstCopterTypes[currentCopterTypeIndex];
            }

            SetCopterPicture();
            rect.Size = bmp.Size;
            rectPlayer.X = (rect.X + (rect.Width / 2)) - (rectPlayer.Width / 2);
        }

        public void ChangeMoveAmount() 
        {
            if (throttle)
            {
                if (moveAmount >= -16)
                {
                    moveAmount -= 1;
                }
            }
            else if (!throttle)
            {
                if (moveAmount < 16)
                {
                    moveAmount += 2;
                }
            }

        }

        public void MoveCopterY()
        {
            rect.Y += moveAmount;
            rectPlayer.Y += moveAmount;
        }

        public void MoveCopterX()
        {
            rect.X -= 10;
            rectPlayer.X -= 10; 
        }

        public void SetThrottle(bool throttled)
        {
            throttle = throttled;

        }

        public bool GetAlive()
        {
            return alive;
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public bool GetThrottle()
        {
            return throttle;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
            g.DrawImage(bmpPlayer, rectPlayer, 0, 0, bmpPlayer.Width, bmpPlayer.Height, GraphicsUnit.Pixel, attr);
        }

        public void SetAlive(bool q)
        {
            alive = q;
        }

    }
}
