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
    class Walker
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.WalkerLeft);
        int arrayX;
        int arrayY;
        bool outOfBounds;
        List<string> goIntoList = new List<string>();
        string dir = "R";

        public Walker(int x, int y, Random random)
        {
            int dir2 = random.Next(1, 5);
            if (dir2 == 2)
                dir = "U";
            else if (dir2 == 3)
                dir = "L";
            else if (dir2 == 4)
                dir = "D";
            
            int q = random.Next(1, 3);
            if (q == 1)
            {
                bmp = Chips_Challenge.Properties.Resources.WalkerRight;
            }
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

        public void MoveBySelf(string[,] board, Random random)
        {
            if (dir == "D")
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                {
                    rect.Y += 32;
                    arrayY++;
                }
                else
                {
                    int newDir = random.Next(1, 4);
                    if (newDir == 1)
                        dir = "U";
                    else if (newDir == 2)
                        dir = "L";
                    else if (newDir == 3)
                        dir = "R";
                }
            }
            else if (dir == "U")
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                {
                    rect.Y -= 32;
                    arrayY--;
                }
                else
                {
                    int newDir = random.Next(1, 4);
                    if (newDir == 1)
                        dir = "D";
                    else if (newDir == 2)
                        dir = "L";
                    else if (newDir == 3)
                        dir = "R";
                }
            }
            else if (dir == "L")
            {
                if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                {
                    rect.X -= 32;
                    arrayX--;
                    bmp = Chips_Challenge.Properties.Resources.WalkerLeft;
                }
                else
                {
                    int newDir = random.Next(1, 4);
                    if (newDir == 1)
                        dir = "D";
                    else if (newDir == 2)
                        dir = "U";
                    else if (newDir == 3)
                        dir = "R";
                }
            }
            else if (dir == "R")
            {
                if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                {
                    rect.X += 32;
                    arrayX++;
                    bmp = Chips_Challenge.Properties.Resources.WalkerRight;
                }
                else
                {
                    int newDir = random.Next(1, 4);
                    if (newDir == 1)
                        dir = "D";
                    else if (newDir == 2)
                        dir = "U";
                    else if (newDir == 3)
                        dir = "L";
                }
            }
            CheckForOutOfBounds();
        }

        public bool OnToggleButton(string[,] board)
        {
            if (board[arrayX, arrayY] == "TB-")
            {
                return true;
            }
            return false;
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
