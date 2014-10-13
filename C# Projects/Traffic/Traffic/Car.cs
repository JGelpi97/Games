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

namespace Traffic
{
    class Car
    {
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Traffic.Properties.Resources.triangle);
        Bitmap box = new Bitmap(Traffic.Properties.Resources.hitbox);
        ImageAttributes attr = new ImageAttributes();
        int xSpeed;
        int ySpeed;
        bool defaultSpeed = true;
        bool alive = true;
        string directionStr;
        int brakeTime = 40;
        bool braked = false;
        string typeStr;
        int lane;

        Rectangle[] HitBoxes = new Rectangle[10];
    
        public Car(Random random, List<Car> lstCars)
        {
            for (int i = 0; i <= 9; i++)
            {
                HitBoxes[i] = new Rectangle();                 
            }
            ResetMakeCar(random, lstCars);
        }

        public void SetRect(Rectangle rect1)
        {
            rect = rect1;
        }

        public void ResetMakeCar(Random random, List<Car> lstCars)
        {
            defaultSpeed = true;
            Array.Clear(HitBoxes, 0, 10);
            alive = true;
            brakeTime = 40;
            braked = false;
            attr.SetColorKey(Color.FromArgb(0,0,0), Color.FromArgb(0,50,0));
            int type = random.Next(1, 14);
            if (type == 1) //Pic
            {
                bmp = Traffic.Properties.Resources.triangle;
                typeStr = "tri";
            }
            else if (type == 2)
            {
                bmp = Traffic.Properties.Resources.circle;
                typeStr = "circ";
            }
            else if (type == 3)
            {
                bmp = Traffic.Properties.Resources.diamond;
                typeStr = "diam";
            }
            else if (type == 4)
            {
                bmp = Traffic.Properties.Resources.square;
                typeStr = "sq";
            }
            else if (type == 5)
            {
                bmp = Traffic.Properties.Resources.square2;
                typeStr = "sq";
            }
            else if (type == 6)
            {
                bmp = Traffic.Properties.Resources.truck;
                typeStr = "rect";
            }
            else if (type == 7)
            {
                bmp = Traffic.Properties.Resources.circle2;
                typeStr = "circ";
            }
            else if (type == 8)
            {
                    bmp = Traffic.Properties.Resources.truck2;
                    typeStr = "rect";
            }
            else if (type == 9)
            {
                bmp = Traffic.Properties.Resources.triangle2;
                typeStr = "tri";
            }
            else if (type == 10)
            {
                bmp = Traffic.Properties.Resources.diamond2;
                typeStr = "diam";
            }
            else if (type == 11)
            {
                bmp = Traffic.Properties.Resources.diamond3;
                typeStr = "diam";
            }
            else if (type == 12)
            {
                bmp = Traffic.Properties.Resources.triangle3;
                typeStr = "tri";
            }
            else if (type == 13)
            {
                bmp = Traffic.Properties.Resources.circle3;
                typeStr = "circ";
            }
            //Direction/lane/speed/position
            int direction = random.Next(1, 5);
            if (direction == 1)
            {
                directionStr = "R";
                xSpeed = 5;
                ySpeed = 0;
                lane = random.Next(1, 3);
                if (lane == 1)
                {
                    rect.X = -130;
                    rect.Y = 185;
                }
                else
                {
                    rect.X = -130;
                    rect.Y = 250;
                }
            }
            else if (direction == 2)
            {
                directionStr = "L";
                xSpeed = -5;
                ySpeed = 0;
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                lane = random.Next(1, 3);
                if (lane == 1)
                {
                    rect.X = 830;
                    rect.Y = 310;
                }
                else
                {
                    rect.X = 830;
                    rect.Y = 370;
                }
            }
            else if (direction == 3)
            {
                directionStr = "U";
                xSpeed = 0;
                ySpeed = -5;
                bmp.RotateFlip(RotateFlipType.Rotate270FlipX);
                lane = random.Next(1, 3);
                if (lane == 1)
                {
                    rect.X = 468;
                    rect.Y = 630;
                }
                else
                {
                    rect.X = 405;
                    rect.Y = 630;
                }
            }
            else if (direction == 4)
            {
                directionStr = "D";
                xSpeed = 0;
                ySpeed = 5;
                bmp.RotateFlip(RotateFlipType.Rotate90FlipX);
                lane = random.Next(1, 3);
                if (lane == 1)
                {
                    rect.X = 343;
                    rect.Y = -130;
                }
                else
                {
                    rect.X = 280;
                    rect.Y = -130;
                }
            }
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;

            foreach (Car car in lstCars)
            {
                if (car.GetRect().IntersectsWith(rect) && car != this && car.GetAlive())
                {
                    Kill();
                }
            }

            MakeHitBoxes();
        }

        public void MakeHitBoxes()
        {
            int hitBoxHeight = 0;
            int hitBoxWidth = 0;
            int lPos = 0;
            int tPos = 0;
            int lChange = 0;
            int tChange = 0;
            int hChange = 0;
            int wChange = 0;

            #region SquareRect HitBoxes
            if (typeStr == "rect" || typeStr == "sq")
            {
                HitBoxes[0].Width = rect.Width;
                HitBoxes[0].Height = rect.Height;
                HitBoxes[0].X = rect.Left;
                HitBoxes[0].Y = rect.Top;
            }
            #endregion

            #region Diamond
            if (typeStr == "diam")
            {
                //Top
                hitBoxHeight = 4;
                hitBoxWidth = rect.Width;
                lPos = rect.Left;
                tPos = rect.Top + (rect.Width / 2) - 4;
                lChange = 3;
                tChange = 4;
                hChange = 0;
                wChange = 6;
                for (int i = 0; i <= 4; i++)
                {
                    HitBoxes[i].X = lPos;
                    HitBoxes[i].Y = tPos;
                    HitBoxes[i].Width = hitBoxWidth;
                    HitBoxes[i].Height = hitBoxHeight;
                    lPos += lChange;
                    tPos -= tChange;
                    hitBoxHeight += hChange;
                    hitBoxWidth -= wChange;
                }

                //Bottom
                hitBoxHeight = 4;
                hitBoxWidth = rect.Width;
                lPos = rect.Left;
                tPos = rect.Bottom - (rect.Height / 2);
                lChange = 3;
                tChange = 4;
                hChange = 0;
                wChange = 6;
                for (int i = 5; i <= 9; i++)
                {
                    HitBoxes[i].X = lPos;
                    HitBoxes[i].Y = tPos;
                    HitBoxes[i].Width = hitBoxWidth;
                    HitBoxes[i].Height = hitBoxHeight;
                    lPos += lChange;
                    tPos += tChange;
                    hitBoxHeight += hChange;
                    hitBoxWidth -= wChange;
                }
            }

            #endregion

            #region Triangle HitBoxes
            if (typeStr == "tri")
            {
                if (directionStr == "R")
                {
                    hitBoxHeight = rect.Height;
                    hitBoxWidth = 8;
                    lPos = rect.Left;
                    tPos = rect.Top;
                    lChange = 8;
                    tChange = 8;
                    hChange = 8;
                    wChange = 0;
                    for (int i = 0; i <= 4; i++)
                    {
                        HitBoxes[i].X = lPos;
                        HitBoxes[i].Y = tPos;
                        HitBoxes[i].Width = hitBoxWidth;
                        HitBoxes[i].Height = hitBoxHeight;
                        lPos += lChange;
                        tPos += tChange - 4;
                        hitBoxHeight -= hChange;
                        hitBoxWidth += wChange;
                    }
                }
                if (directionStr == "L")
                {
                    hitBoxHeight = rect.Height;
                    hitBoxWidth = 8;
                    lPos = rect.Right - 8;
                    tPos = rect.Top;
                    lChange = 8;
                    tChange = 8;
                    hChange = 8;
                    wChange = 0;
                    for (int i = 0; i <= 4; i++)
                    {
                        HitBoxes[i].X = lPos;
                        HitBoxes[i].Y = tPos;
                        HitBoxes[i].Width = hitBoxWidth;
                        HitBoxes[i].Height = hitBoxHeight;
                        lPos -= lChange;
                        tPos += tChange - 4;
                        hitBoxHeight -= hChange;
                        hitBoxWidth += wChange;
                    }
                }
                if (directionStr == "U")
                {
                    hitBoxHeight = 8;
                    hitBoxWidth = rect.Width;
                    lPos = rect.Left;
                    tPos = rect.Bottom - 8;
                    lChange = 8;
                    tChange = 8;
                    hChange = 0;
                    wChange = 8;
                    for (int i = 0; i <= 4; i++)
                    {
                        HitBoxes[i].X = lPos;
                        HitBoxes[i].Y = tPos;
                        HitBoxes[i].Width = hitBoxWidth;
                        HitBoxes[i].Height = hitBoxHeight;
                        lPos += lChange - 4;
                        tPos -= tChange;
                        hitBoxHeight += hChange;
                        hitBoxWidth -= wChange;
                    }
                }
                if (directionStr == "D")
                {
                    hitBoxHeight = 8;
                    hitBoxWidth = rect.Width;
                    lPos = rect.Left;
                    tPos = rect.Top;
                    lChange = 8;
                    tChange = 8;
                    hChange = 0;
                    wChange = 8;
                    for (int i = 0; i <= 4; i++)
                    {
                        HitBoxes[i].X = lPos;
                        HitBoxes[i].Y = tPos;
                        HitBoxes[i].Width = hitBoxWidth;
                        HitBoxes[i].Height = hitBoxHeight;
                        lPos += lChange - 4;
                        tPos += tChange;
                        hitBoxHeight += hChange;
                        hitBoxWidth -= wChange;
                    }
                }
            }
            #endregion

        }

        public bool OffScreen()
        {
            if (directionStr == "U")
            {
                if (rect.Bottom < 0)
                {
                    return true;
                }
            }
            else if (directionStr == "D")
            {
                if (rect.Top > 600)
                {
                    return true;
                }
            }
            else if (directionStr == "L")
            {
                if (rect.Right < 0)
                {
                    return true;
                }
            }
            else if (directionStr == "R")
            {
                if (rect.Left > 800)
                {
                    return true;
                }
            }
            return false;

        }

        public void Kill()
        {
            alive = false;
        }

        public void BrakeStuff()
        {                        
            brakeTime--;
            if (brakeTime == 0)
            {
                defaultSpeed = true;
                braked = false;
                if (directionStr == "U")
                {
                    ySpeed = -5;
                }
                else if (directionStr == "D")
                {
                    ySpeed = 5;
                }
                else if (directionStr == "L")
                {
                    xSpeed = -5;
                }
                else if (directionStr == "R")
                {
                    xSpeed = 5;
                }
                brakeTime = 40;
            }
        }

        public void Move()
        {
            rect.Y += ySpeed;
            rect.X += xSpeed;
            for (int i = 0; i <= 9; i++)
            {
                HitBoxes[i].X += xSpeed;
                HitBoxes[i].Y += ySpeed;
            }
        }

        public void SpeedUp()
        {
            defaultSpeed = false;
            brakeTime = 40;
            if (directionStr == "R")
            {
                if (xSpeed == 0)
                {
                    xSpeed = 5;
                }
                else
                {
                    xSpeed += 4;
                }
            }
            else if (directionStr == "L")
            {
                if (xSpeed == 0)
                {
                    xSpeed = -5;
                }
                else
                {
                    xSpeed -= 4;
                }
            }
            else if (directionStr == "U")
            {
                if (ySpeed == 0)
                {
                    ySpeed = -5;
                }
                else
                {
                    ySpeed -= 4;
                }
            }
            else if (directionStr == "D")
            {
                if (ySpeed == 0)
                {
                    ySpeed = 5;
                }
                else
                {
                    ySpeed += 4;
                }
            }
        }

        public void Brake()
        {
            braked = true;
            xSpeed = 0;
            ySpeed = 0;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
            //for (int i = 0; i <= 9; i++)
            {
              //  g.DrawImage(box, HitBoxes[i], 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
            }
        }

        public string GetTypeOf()
        {
            return typeStr;
        }

        public int GetLane()
        {
            return lane;
        }

        public Rectangle GetRect()
        {
            return rect;
        }

        public Rectangle[] GetHitBoxes()
        {
            return HitBoxes;
        }

        public bool GetBraked()
        {
            return braked;
        }

        public bool GetAlive()
        {
            return alive;
        }

        public string GetDirection()
        {
            return directionStr;
        }

        public bool GetDefaultSpeed()
        {
            return defaultSpeed;
        }

        //if (directionStr == "U")
        //{
         
        //}
        //else if (directionStr == "D")
        //{
         
        //}
        //else if (directionStr == "L")
        //{
         
        //}
        //else if (directionStr == "R")
        //{
         
        //}
    }
}
