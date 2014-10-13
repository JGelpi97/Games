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
    class Blob
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.Blob);
        int arrayX;
        int arrayY;
        bool outOfBounds;
        List<string> goIntoList = new List<string>();

        public Blob(int x, int y)
        {
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.Size = bmp.Size;
            arrayX = x;
            arrayY = y;
            rect.X = x * 32;
            rect.Y = y * 32;
            goIntoList.Add("FL-");
            goIntoList.Add("TF-");
            goIntoList.Add("TB-");
        }

        public bool OnToggleButton(string[,] board)
        {
            if (board[arrayX, arrayY] == "TB-")
            {
                return true;
            }            
            return false;
        }

        public void MoveBySelf(string[,] board, Random random)
        {
            int dir = random.Next(1, 5);
            if (dir == 1) //up
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                {
                    rect.Y -= 32;
                    arrayY--;
                }
            }
            else if (dir == 2) //down
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                {
                    rect.Y += 32;
                    arrayY++;
                }
            }
            else if (dir == 3) //right
            {
                if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                {
                    rect.X += 32;
                    arrayX++;
                }
            }
            else if (dir == 4) //left
            {
                if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                {
                    rect.X -= 32;
                    arrayX--;
                }
            }
            CheckForOutOfBounds();
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

        public void SetPosition(int x, int y)
        {
            rect.X += x;
            rect.Y += y;
        }

        public void MoveWithGuy(string x)
        {
            if (x == "R")
            {
                rect.X -= 32;
            }
            else if (x == "L")
            {
                rect.X += 32;
            }
            else if (x == "U")
            {
                rect.Y += 32;
            }
            else if (x == "D")
            {
                rect.Y -= 32;
            }
            CheckForOutOfBounds();
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

        public Rectangle GetRect()
        {
            return rect;
        }
        public bool IsOutOfBounds()
        {
            return outOfBounds;
        }
        public int ArrayX()
        {
            return arrayX;
        }
        public int ArrayY()
        {
            return arrayY;
        }
    }
}
