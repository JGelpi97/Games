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
    class Tile
    {
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.FloorTile);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        bool outOfBounds = true;
        int arrayX;
        int arrayY;
        int locX;
        int locY;

        public Tile(int x, int y, string type)
        {
            rect.Width = 32;
            rect.Height = 32;
            rect.X = x * 32;
            rect.Y = y * 32;
            arrayX = x;
            arrayY = y;
            SetPic(type);
            CheckForOutOfBounds();
        }

        public int ArrayX()
        {
            return arrayX;
        }

        public int ArrayY()
        {
            return arrayY;
        }

        public void SetPic(string type)
        {
            if (type == "FL-")
            {
                bmp = Chips_Challenge.Properties.Resources.FloorTile;
            }
            else if (type == "PQ-")
            {
                bmp = Chips_Challenge.Properties.Resources.ForceFloorRandom;
            }
            else if (type == "BO-")
            {
                bmp = Chips_Challenge.Properties.Resources.Bomb;
            }
            else if (type == "BR-" || type == "BF-")
            {
                bmp = Chips_Challenge.Properties.Resources.BlueWall;
            }
            else if (type == "RW-")
            {
                bmp = Chips_Challenge.Properties.Resources.RecessedWall;
            }
            else if (type == "NE-")
            {
                bmp = Chips_Challenge.Properties.Resources.NEice;
            }
            else if (type == "NW-")
            {
                bmp = Chips_Challenge.Properties.Resources.NWice;
            }
            else if (type == "SE-")
            {
                bmp = Chips_Challenge.Properties.Resources.SEice;
            }
            else if (type == "SW-")
            {
                bmp = Chips_Challenge.Properties.Resources.SWice;
            }
            else if (type == "GR-")
            {
                bmp = Chips_Challenge.Properties.Resources.Gravel;
            }
            else if (type == "TH-")
            {
                bmp = Chips_Challenge.Properties.Resources.Theif;
            }
            else if (type == "MU-")
            {
                bmp = Chips_Challenge.Properties.Resources.DirtInWater;
            }
            else if (type == "DT-")
            {
                bmp = Chips_Challenge.Properties.Resources.Dirt;
            }
            else if (type == "HP-")
            {
                bmp = Chips_Challenge.Properties.Resources.Help;
            }
            else if (type == "TB-")
            {
                bmp = Chips_Challenge.Properties.Resources.ToggleButton;
            }
            else if (type == "TW-")
            {
                bmp = Chips_Challenge.Properties.Resources.ToggleWall;
            }
            else if (type == "TF-")
            {
                bmp = Chips_Challenge.Properties.Resources.ToggleFloor;
            }

            else if (type == "PR-")
            {
                bmp = Chips_Challenge.Properties.Resources.PushRight;
            }
            else if (type == "PL-")
            {
                bmp = Chips_Challenge.Properties.Resources.PushLeft;
            }
            else if (type == "PU-")
            {
                bmp = Chips_Challenge.Properties.Resources.PushUp;
            }
            else if (type == "PD-")
            {
                bmp = Chips_Challenge.Properties.Resources.PushDown;
            }
            else if (type == "WW-")
            {
                bmp = Chips_Challenge.Properties.Resources.WallTile;
            }
            else if (type == "CH-")
            {
                bmp = Chips_Challenge.Properties.Resources.ChipTile;
            }
            else if (type == "DO-")
            {
                bmp = Chips_Challenge.Properties.Resources.DoorTile;
            }
            else if (type == "WN-")
            {
                bmp = Chips_Challenge.Properties.Resources.WinTile;
            }
            else if (type == "DG-")
            {
                bmp = Chips_Challenge.Properties.Resources.DoorGreen;
            }
            else if (type == "DB-")
            {
                bmp = Chips_Challenge.Properties.Resources.DoorBlue;
            }
            else if (type == "DR-")
            {
                bmp = Chips_Challenge.Properties.Resources.DoorRed;
            }
            else if (type == "DY-")
            {
                bmp = Chips_Challenge.Properties.Resources.DoorYellow;
            }
            else if (type == "FB-")
            {
                bmp = Chips_Challenge.Properties.Resources.FireBoot;
            }
            else if (type == "FP-")
            {
                bmp = Chips_Challenge.Properties.Resources.Flipper;
            }
            else if (type == "SB-")
            {
                bmp = Chips_Challenge.Properties.Resources.SuctionBoots;
            }
            else if (type == "IS-")
            {
                bmp = Chips_Challenge.Properties.Resources.IceSkate;
            }
            else if (type == "WA-")
            {
                bmp = Chips_Challenge.Properties.Resources.WaterTile;
            }
            else if (type == "IC-")
            {
                bmp = Chips_Challenge.Properties.Resources.IceTile;
            }
            else if (type == "FI-")
            {
                bmp = Chips_Challenge.Properties.Resources.FireTile;
            }
            else if (type == "KB-")
            {
                bmp = Chips_Challenge.Properties.Resources.KeyBlue;
            }
            else if (type == "KR-")
            {
                bmp = Chips_Challenge.Properties.Resources.KeyRed;
            }
            else if (type == "KY-")
            {
                bmp = Chips_Challenge.Properties.Resources.KeyYellow;
            }
            else if (type == "KG-")
            {
                bmp = Chips_Challenge.Properties.Resources.KeyGreen;
            }
        }

        public void Move(string x)
        {
            if (x == "R")
            {
                rect.X -= 32;
                locX -= 32;
            }
            else if (x == "L")
            {
                rect.X += 32;
                locX += 32;
            }
            else if (x == "U")
            {
                rect.Y += 32;
                locY += 32;
            }
            else if (x == "D")
            {
                rect.Y -= 32;
                locY -= 32;
            }
            CheckForOutOfBounds();

        }

        public void SetPosition(int x, int y)
        {
            rect.X += x;
            rect.Y += y;
            locX = x;
            locY = y;
        }

        public int GetlocY()
        {
            return locY;
        }

        public int GetlocX()
        {
            return locX;
        }

        public void CheckForOutOfBounds()
        {
            if (rect.X < 32 || rect.Y < 64)
            {
                outOfBounds = true;
            }
            else if (rect.Bottom > 416 || rect.Right > 384)
            {
                outOfBounds = true;
            }
            else
            {
                outOfBounds = false;
            }
        }

        public bool IsOutOfBounds()
        {
            return outOfBounds;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

    }
}
