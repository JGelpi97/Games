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

namespace SnakeFu
{
    class Snake
    {
        Rectangle rect = new Rectangle();
        string direction;
        int arrayX;
        int arrayY;
        string color;
        bool alive = true;
        bool AIControlled = true;
        Random random;
        int startX;
        int startY;
        int startArrayX;
        int startArrayY;

        public Snake(int xLoc, int yLoc, Random random2, int arrayX2, int arrayY2, string color2)
        {
            random = random2;
            startX = xLoc;
            startY = yLoc;
            startArrayX = arrayX2;
            startArrayY = arrayY2;
            SetRandomDirection(random2);
            rect.Width = 10;
            rect.Height = 10;
            rect.X = xLoc;
            rect.Y = yLoc;
            arrayX = arrayX2;
            arrayY = arrayY2;
            color = color2;
        }

        public void SetRandomDirection(Random random2)
        {
            int x = random2.Next(0, 4);
            if (x == 0)
                direction = "right";
            else if (x == 1)
                direction = "left";
            else if (x == 2)
                direction = "up";
            else if (x == 3)
                direction = "down";
        }

        public void Reset()
        {
            arrayX = startArrayX;
            arrayY = startArrayY;
            rect.X = startX;
            rect.Y = startY;
            AIControlled = true;
            alive = true;
        }

        public void SetAIControlled(bool x)
        {
            AIControlled = x;
        }

        public bool GetAIControlled()
        {
            return AIControlled;
        }

        public bool GetAlive()
        {
            return alive;
        }

        public void Kill()
        {
            alive = false;
        }

        public void AI(int[,] board)
        {
            int x = random.Next(0, 2);
            if (direction == "right")
            {
                if (board[arrayX + 1, arrayY] == 1)
                {
                    if (board[arrayX, arrayY + 1] == 1)
                    {
                        direction = "up";
                    }
                    else if (board[arrayX, arrayY - 1] == 1)
                    {
                        direction = "down";
                    }
                    else
                    {
                        if (x == 0)
                        {
                            direction = "down";
                        }
                        else
                        {
                            direction = "up";
                        }
                    }
                }
            }

            if (direction == "left")
            {
                if (board[arrayX - 1, arrayY] == 1)
                {
                    if (board[arrayX, arrayY + 1] == 1)
                    {
                        direction = "up";
                    }
                    else if (board[arrayX, arrayY - 1] == 1)
                    {
                        direction = "down";
                    }
                    else
                    {
                        if (x == 0)
                        {
                            direction = "down";
                        }
                        else
                        {
                            direction = "up";
                        }
                    }
                }
            }

            if (direction == "down")
            {
                if (board[arrayX, arrayY + 1] == 1)
                {
                    if (board[arrayX + 1, arrayY] == 1)
                    {
                        direction = "left";
                    }
                    else if (board[arrayX - 1, arrayY] == 1)
                    {
                        direction = "right";
                    }
                    else
                    {
                        if (x == 0)
                        {
                            direction = "right";
                        }
                        else
                        {
                            direction = "left";
                        }
                    }
                }
            }

            if (direction == "up")
            {
                if (board[arrayX, arrayY - 1] == 1)
                {
                    if (board[arrayX + 1, arrayY] == 1)
                    {
                        direction = "left";
                    }
                    else if (board[arrayX - 1, arrayY] == 1)
                    {
                        direction = "right";
                    }
                    else
                    {
                        if (x == 0)
                        {
                            direction = "left";
                        }
                        else
                        {
                            direction = "right";
                        }
                    }
                }
            }


        }

        public string GetColor()
        {
            return color;
        }

        public void ChangeDirection(string dir)
        {
            AIControlled = false;
            direction = dir;
        }

        public void Move()
        {
            if (direction == "right")
            {
                rect.X += 10;
                arrayX++;
            }
            else if (direction == "left")
            {
                rect.X -= 10;
                arrayX--;
            }
            else if (direction == "down")
            {
                rect.Y += 10;
                arrayY++;
            }
            else if (direction == "up")
            {
                rect.Y -= 10;
                arrayY--;
            }
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public int GetArrayX()
        {
            return arrayX;
        }

        public int GetArrayY()
        {
            return arrayY;
        }

    }
}
