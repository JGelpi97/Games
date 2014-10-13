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
    class Ball
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.ball);
        int arrayX;
        int arrayY;
        bool outOfBounds;
        string overAllDirection;
        string actualDirection;
        List<string> goIntoList = new List<string>();

        public Ball(int x, int y, string dir)
        {
            attr.SetColorKey(Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 0));
            rect.Size = bmp.Size;
            arrayX = x;
            arrayY = y;
            rect.X = x * 32;
            rect.Y = y * 32;
            if (dir == "BH-")
            {
                overAllDirection = "H";
                actualDirection = "R";
            }
            else if (dir == "BV-")
            {
                overAllDirection = "V";
                actualDirection = "U";
            }
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

        public void MoveBySelf(string[,] board)
        {
            if (overAllDirection == "V")
            {
                if (actualDirection == "U")
                {
                    if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                    {
                        rect.Y -= 32;
                        arrayY--;
                    }
                    else
                    {
                        actualDirection = "D";
                    }
                }
                else if (actualDirection == "D")
                {
                    if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                    {
                        rect.Y += 32;
                        arrayY++;
                    }
                    else
                    {
                        actualDirection = "U";
                    }

                }
            }

            else if (overAllDirection == "H")
            {
                if (actualDirection == "R")
                {
                    if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                    {
                        rect.X += 32;
                        arrayX++;
                    }
                    else
                    {
                        actualDirection = "L";
                    }
                }
                if (actualDirection == "L")
                {
                    if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                    {
                        rect.X -= 32;
                        arrayX--;
                    }
                    else
                    {
                        actualDirection = "R";
                    }
                    
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

        public void SetPosition(int x, int y)
        {
            rect.X += x;
            rect.Y += y;
        }

        public Rectangle GetRect()
        {
            return rect;
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
    }
}
