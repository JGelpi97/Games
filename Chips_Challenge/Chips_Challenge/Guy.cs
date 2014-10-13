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

namespace Chips_Challenge
{
    class Guy
    {
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.GuyNormal);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        int arrayX;
        int arrayY;
        int blueKeys = 0;
        int redKeys = 0;
        int greenKeys = 0;
        int yellowKeys = 0;
        bool fireBoots = false;
        bool suctionBoots = false;
        bool flippers = false;
        bool iceSkates = false;
        bool onIce = false;
        string lastDir;
        bool alive = true;
        bool onPushTile = false;
        bool inWater = false;

        public Guy()
        {
            rect.Size = bmp.Size;
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.X = 192;
            rect.Y = 224;
        }

        public void Kill()
        {
            alive = false;
        }

        public void Reset()
        {
            blueKeys = 0;
            redKeys = 0;
            yellowKeys = 0;
            greenKeys = 0;
            fireBoots = false;
            suctionBoots = false;
            flippers = false;
            iceSkates = false;
            onIce = false;
            alive = true;
            bmp = Chips_Challenge.Properties.Resources.GuyNormal;
        }

        public void SetArrayPos(int x, int y)
        {
            arrayX = x;
            arrayY = y;
        }

        public void ChangePics()
        {
            if (alive)
            {
                if (lastDir == "R")
                {
                    if (!inWater)
                        bmp = Chips_Challenge.Properties.Resources.GuyRight;
                    else
                        bmp = Chips_Challenge.Properties.Resources.ChipWaterRight;
                }
                else if (lastDir == "L")
                {
                    if (!inWater)
                        bmp = Chips_Challenge.Properties.Resources.GuyLeft;
                    else
                        bmp = Chips_Challenge.Properties.Resources.ChipWaterLeft;
                }
                else if (lastDir == "U")
                {
                    if (!inWater)
                        bmp = Chips_Challenge.Properties.Resources.GuyUp;
                    else
                        bmp = Chips_Challenge.Properties.Resources.ChipWaterUp;
                }
                else if (lastDir == "D")
                {
                    if (!inWater)
                        bmp = Chips_Challenge.Properties.Resources.GuyNormal;
                    else
                        bmp = Chips_Challenge.Properties.Resources.ChipWaterNormal;
                }
            }
        }

        public void MoveChangeDirection(string x)
        {
            if (x == "R")
            {
                lastDir = "R";
                arrayX++;
            }
            else if (x == "L")
            {
                lastDir = "L";
                arrayX--;

            }
            else if (x == "U")
            {
                lastDir = "U";
                arrayY--;
            }
            else if (x == "D")
            {
                lastDir = "D";
                arrayY++;
            }

        }

        public void NormalPic(string x)
        {
            if (x == "R")
                bmp = Chips_Challenge.Properties.Resources.GuyNormal;
            else
                bmp = Chips_Challenge.Properties.Resources.ChipWaterNormal;
        }

        public string SteppedOnTile(string x, Random random)
        {
            onPushTile = false;
            onIce = false;
            inWater = false;
            if (x == "PQ-")
            {
                int a = random.Next(1, 5);
                if (a == 1)
                {
                    MoveChangeDirection("R");
                    onPushTile = true;
                    ChangePics();
                    return "R";
                }
                else if (a == 2)
                {
                    MoveChangeDirection("L");
                    onPushTile = true;
                    ChangePics();
                    return "L";
                }
                else if (a == 3)
                {
                    MoveChangeDirection("U");
                    onPushTile = true;
                    ChangePics();
                    return "U";
                }
                else if (a == 4)
                {
                    MoveChangeDirection("D");
                    onPushTile = true;
                    ChangePics();
                    return "D";
                }
            }
            return "";
        }

        public void SteppedOnTile(string x)
        {
            onPushTile = false;
            onIce = false;
            inWater = false;
            if (x == "FI-" && !fireBoots)
            {
                bmp = Chips_Challenge.Properties.Resources.GuyDeadFire;
                Kill();
            }
            else if (x == "BO-")
            {
                bmp = Chips_Challenge.Properties.Resources.GuyNormal;
                Kill();
            }
            else if (x == "NW-" && !iceSkates)
            {
                if (lastDir == "L")
                {
                    lastDir = "D";
                }
                else if (lastDir == "U")
                {
                    lastDir = "R";
                }
                onIce = true;
            }
            else if (x == "NE-" && !iceSkates)
            {
                if (lastDir == "R")
                {
                    lastDir = "D";
                }
                else if (lastDir == "U")
                {
                    lastDir = "L";
                }
                onIce = true;
            }
            else if (x == "SW-" && !iceSkates)
            {
                if (lastDir == "D")
                {
                    lastDir = "R";
                }
                else if (lastDir == "L")
                {
                    lastDir = "U";
                }
                onIce = true;
            }
            else if (x == "SE-" && !iceSkates)
            {
                if (lastDir == "D")
                {
                    lastDir = "L";
                }
                else if (lastDir == "R")
                {
                    lastDir = "U";
                }
                onIce = true;
            }

            else if (x == "TH-")
            {
                fireBoots = false;
                iceSkates = false;
                suctionBoots = false;
                flippers = false;
            }
            else if (x == "WA-" && !flippers)
            {
                bmp = Chips_Challenge.Properties.Resources.GuyDeadWater;
                Kill();
            }
            else if (x == "WA-" && flippers)
            {
                inWater = true;
            }
            else if (x == "PR-")
            {
                MoveChangeDirection("R");
                onPushTile = true;
                ChangePics();
            }
            else if (x == "PL-")
            {
                MoveChangeDirection("L");
                onPushTile = true;
                ChangePics();
            }
            else if (x == "PU-")
            {
                MoveChangeDirection("U");
                onPushTile = true;
                ChangePics();
            }
            else if (x == "PD-")
            {
                MoveChangeDirection("D");
                onPushTile = true;
                ChangePics();
            }
            else if (x == "KB-")
            {
                blueKeys++;
            }
            else if (x == "KG-")
            {
                greenKeys++;
            }
            else if (x == "KY-")
            {
                yellowKeys++;
            }
            else if (x == "KR-")
            {
                redKeys++;
            }
            else if (x == "IS-")
            {
                iceSkates = true;
            }
            else if (x == "SB-")
            {
                suctionBoots = true;
            }
            else if (x == "FB-")
            {
                fireBoots = true;
            }
            else if (x == "FP-")
            {
                flippers = true;
            }
            else if (x == "DB-")
            {
                blueKeys--;
            }
            else if (x == "DR-")
            {
                redKeys--;
            }
            else if (x == "DY-")
            {
                yellowKeys--;
            }
            else if (x == "IC-" && !iceSkates)
            {
                onIce = true;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }


        #region Returns
        public bool IsInWater()
        {
            return inWater;
        }
        public bool Alive()
        {
            return alive;
        }
        public bool IsOnIce()
        {
            return onIce;
        }
        public int ArrayX()
        {
            return arrayX;
        }
        public int ArrayY()
        {
            return arrayY;
        }
        public string LastDirection()
        {
            return lastDir;
        }
        public bool HasFireBoots()
        {
            return fireBoots;
        }
        public bool HasIceSkates()
        {
            return iceSkates;
        }
        public bool HasFlippers()
        {
            return flippers;
        }
        public bool HasSuctionBoots()
        {
            return suctionBoots;
        }
        public int NumBlueKeys()
        {
            return blueKeys;
        }
        public int NumRedKeys()
        {
            return redKeys;
        }
        public int NumGreenKeys()
        {
            return greenKeys;
        }
        public int NumYellowKeys()
        {
            return yellowKeys;
        }
        public Rectangle GetRect()
        {
            return rect;
        }
        public bool OnPushTile()
        {
            return onPushTile;
        }
        #endregion
    }
}
