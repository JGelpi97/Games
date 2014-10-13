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
    class Teeth
    {
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        Bitmap bmp = new Bitmap(Chips_Challenge.Properties.Resources.MonsterNormal);
        int arrayX;
        int arrayY;
        bool outOfBounds;
        List<string> goIntoList = new List<string>();

        public Teeth(int x, int y)
        {
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.Size = bmp.Size;
            arrayX = x;
            arrayY = y;
            rect.X = x * 32;
            rect.Y = y * 32;
            goIntoList.Add("TF-");
            goIntoList.Add("FL-");
            goIntoList.Add("TB-");
            goIntoList.Add("HP-");
        }

        public bool OnToggleButton(string[,] board)
        {
            if (board[arrayX, arrayY] == "TB-")
            {
                return true;
            }
            return false;
        }

        public void MoveBySelf(string[,] board, int guyX, int guyY)
        {
            if (guyX > rect.X)
            {
                bmp = Chips_Challenge.Properties.Resources.MonsterRight;
            }
            else if (guyX < rect.X)
            {
                bmp = Chips_Challenge.Properties.Resources.MonsterLeft;
            }
            else if (guyY > rect.Y)
            {
                bmp = Chips_Challenge.Properties.Resources.MonsterNormal;
            }
            else if (guyY < rect.Y)
            {
                bmp = Chips_Challenge.Properties.Resources.MonsterUp;
            }


            if (goIntoList.Contains<string>(board[arrayX + 1, arrayY]) && (guyX > rect.X))
            {
                rect.X += 32;
                arrayX++;
            }
            else if (goIntoList.Contains<string>(board[arrayX - 1, arrayY]) && (guyX < rect.X))
            {
                rect.X -= 32;
                arrayX--;
            }
            else if (goIntoList.Contains<string>(board[arrayX, arrayY - 1]) && (guyY < rect.Y))
            {
                rect.Y -= 32;
                arrayY--;
            }
            else if (goIntoList.Contains<string>(board[arrayX, arrayY + 1]) && (guyY > rect.Y))
            {
                rect.Y += 32;
                arrayY++;
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
