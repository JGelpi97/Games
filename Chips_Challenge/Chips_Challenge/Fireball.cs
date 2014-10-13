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
    class Fireball
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.fireball);
        int arrayX;
        int arrayY;
        bool outOfBounds;
        string direction = "U";
        List<string> goIntoList = new List<string>();

        public Fireball(int x, int y)
        {
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.Size = bmp.Size;
            arrayX = x;
            arrayY = y;
            rect.X = x * 32;
            rect.Y = y * 32;
            goIntoList.Add("FL-");
            goIntoList.Add("TF-");
            goIntoList.Add("FI-");
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
            if (direction == "U")
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                {
                    rect.Y -= 32;
                    arrayY--;
                }
                else if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                {
                    direction = "R";
                    rect.X += 32;
                    arrayX++;
                }
                else if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                {
                    direction = "L";
                    rect.X -= 32;
                    arrayX--;
                }
                else if ((!goIntoList.Contains<string>(board[arrayX + 1, arrayY]) && !goIntoList.Contains<string>(board[arrayX - 1, arrayY])) || ((!goIntoList.Contains<string>(board[arrayX + 1, arrayY]) && goIntoList.Contains<string>(board[arrayX - 1, arrayY]))))
                {
                    direction = "D";
                    rect.Y += 32;
                    arrayY++;
                }
            }
            else if (direction == "D")
            {
                if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                {
                    rect.Y += 32;
                    arrayY++;
                }
                else if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                {
                    direction = "R";
                    rect.X += 32;
                    arrayX++;
                }
                else if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                {
                    direction = "L";
                    rect.X -= 32;
                    arrayX--;
                }
                else if ((!goIntoList.Contains<string>(board[arrayX + 1, arrayY]) && !goIntoList.Contains<string>(board[arrayX - 1, arrayY])) || ((!goIntoList.Contains<string>(board[arrayX + 1, arrayY]) && goIntoList.Contains<string>(board[arrayX - 1, arrayY]))))
                {
                    direction = "U";
                    rect.Y -= 32;
                    arrayY--;
                }
            }
            else if (direction == "R")
            {
                if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]))
                {
                    rect.X += 32;
                    arrayX++;
                }
                else if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                {
                    direction = "D";
                    rect.Y += 32;
                    arrayY++;
                }
                else if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                {
                    direction = "U";
                    rect.Y -= 32;
                    arrayY--;
                }
                else if ((!goIntoList.Contains<string>(board[arrayX, arrayY + 1]) && !goIntoList.Contains<string>(board[arrayX, arrayY - 1])) || (!goIntoList.Contains<string>(board[arrayX, arrayY + 1]) && !goIntoList.Contains<string>(board[arrayX, arrayY - 1])))
                {
                    direction = "L";
                    rect.X -= 32;
                    arrayX--;
                }
            }
            else if (direction == "L")
            {
                if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]))
                {
                    rect.X -= 32;
                    arrayX--;
                }
                else if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]))
                {
                    direction = "D";
                    rect.Y += 32;
                    arrayY++;
                }
                else if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]))
                {
                    direction = "U";
                    rect.Y -= 32;
                    arrayY--;
                }
                else if ((!goIntoList.Contains<string>(board[arrayX, arrayY + 1]) && !goIntoList.Contains<string>(board[arrayX, arrayY - 1])) || (!goIntoList.Contains<string>(board[arrayX, arrayY + 1]) && !goIntoList.Contains<string>(board[arrayX, arrayY - 1])))
                {
                    direction = "R";
                    rect.X += 32;
                    arrayX++;
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
