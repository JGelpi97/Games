using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Zombie_Shooter_Tower_Defense
{
    class Enemy
    {
        Bitmap bmp = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorWalk1);
        Rectangle rect = new Rectangle();
        ImageAttributes attr = new ImageAttributes();
        bool alive = true;
        double xSpeed, ySpeed, xLoc, yLoc;
        int actualSpeed;
        int regSpeed = 5;
        int iceSpeed;
        double rise, run;
        int health = 0;
        int playerDamage = 1;
        int turretDamage = 500;
        bool visible = false;
        int icedTime = 60;
        int value;
        bool attacking = false;
        int attackDelay = 0;
        int attackDelayTime = 20;
        bool canAttack = true;
        bool finishedAnimating = false;
        bool readyToKill = false;
        string type;
        int walkAnimNumber = 0;
        int attackAnimNumber = 0;
        Turret target = null;

        public Enemy(Random random, string _type, List<Turret> lstOfTurrets)
        {
            MakeRecycleEnemy(random, _type, lstOfTurrets);
        }

        public void MakeRecycleEnemy(Random random, string _type, List<Turret> lstOfTurrets)
        {

            type = _type;

            if (type == "pacman")
            {
                value = 6;
                attackDelayTime = 18;
                health = 18;
                playerDamage = 2;
                turretDamage = 5;
                regSpeed = 6;
            }
            else if (type == "bug")
            {
                value = 3;
                attackDelayTime = 14;
                health = 12;
                playerDamage = 2;
                turretDamage = 3;
                regSpeed = 6;
            }
            else if (type == "trogdor")
            {
                value = 10;
                attackDelayTime = 20;
                health = 20;
                turretDamage = 8;
                playerDamage = 3;
                regSpeed = 5;
            }
            else if (type == "bomb")
            {
                value = 12;
                attackDelayTime = 20;
                health = 50;
                turretDamage = 40;
                playerDamage = 0;
                regSpeed = 5;
            }
            else if (type == "unicorn")
            {
                value = 7;
                attackDelayTime = 18;
                health = 20;
                turretDamage = 6;
                playerDamage = 2;
                regSpeed = 6;
            }
            else if (type == "plant")
            {
                value = 2;
                attackDelayTime = 20;
                health = 10;
                turretDamage = 3;
                playerDamage = 1;
                regSpeed = 5;
            }

            attacking = false;
            attackDelay = 0;
            canAttack = true;
            finishedAnimating = false;
            readyToKill = false;            
            walkAnimNumber = 0;
            attackAnimNumber = 0;
            target = null;
            alive = true;
            visible = false;
            iceSpeed = (int)(regSpeed * .7);

            actualSpeed = regSpeed;         
            int side = random.Next(1, 5);
            if (side == 1)
            {
                yLoc = -30;
                xLoc = random.Next(800);
            }
            else if (side == 2)
            {
                xLoc = 810;
                yLoc = random.Next(700);
            }
            else if (side == 3)
            {
                yLoc = 710;
                xLoc = random.Next(800);
            }
            else if (side == 4)
            {
                yLoc = random.Next(700);
                xLoc = -30;
            }
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rect.Size = bmp.Size;
            rect.Location = new Point(Convert.ToInt32(xLoc), Convert.ToInt32(yLoc));
        }

        public void Ice()
        {
            actualSpeed = iceSpeed;
            icedTime = 30;
        }

        public void Animate()
        {
            #region TrogdorAnims
            if (type == "trogdor")
            {
                if (!attacking)
                {
                    walkAnimNumber++;
                    if (walkAnimNumber == 3)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorWalk1;
                    }
                    else if (walkAnimNumber == 6)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorWalk2;
                    }
                    else if (walkAnimNumber == 9)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorWalk3;
                    }
                    else if (walkAnimNumber == 12)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorWalk2;
                        walkAnimNumber = 0;
                    }
                }
                else if (attacking)
                {
                    attackAnimNumber++;
                    if (attackAnimNumber == 2)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorAttack2;
                    }
                    else if (attackAnimNumber == 4)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorAttack1;
                    }
                    else if (attackAnimNumber == 6)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.trogdorAttack2;
                        attackAnimNumber = 0;
                        attacking = false;
                    }

                }
            }
            #endregion

            #region Plant
            else if (type == "plant")
            {
                if (!attacking)
                {
                    walkAnimNumber++;
                    if (walkAnimNumber == 2)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantWalk2;
                    }
                    if (walkAnimNumber == 4)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantWalk1;
                    }
                    if (walkAnimNumber == 6)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantWalk3;
                    }
                    if (walkAnimNumber == 8)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantWalk1;
                        walkAnimNumber = 0;
                    }
                }
                else if (attacking)
                {
                    attackAnimNumber++;
                    if (attackAnimNumber == 2)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantAttack1;
                    }
                    else if (attackAnimNumber == 4)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantAttack2;
                    }
                    else if (attackAnimNumber == 6)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.plantAttack1;
                        attackAnimNumber = 0;
                        attacking = false;
                    }
                }
            }
            #endregion

            #region Unicorn
            else if (type == "unicorn")
            {
                attacking = false;
                walkAnimNumber++;
                if (walkAnimNumber == 2)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.unicornWalk1;
                }
                else if (walkAnimNumber == 4)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.unicornWalk2;
                }
                else if (walkAnimNumber == 6)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.unicornWalk3;
                }
                else if (walkAnimNumber == 8)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.unicornWalk2;
                    walkAnimNumber = 0;
                }

            }
            #endregion

            #region PacmanAnims
            else if (type == "pacman")
            {
                walkAnimNumber++;
                if (walkAnimNumber == 2)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.pacman1;
                }
                else if (walkAnimNumber == 4)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.pacman2;
                }
                else if (walkAnimNumber == 6)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.pacman3;
                }
                else if (walkAnimNumber == 8)
                {
                    bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.pacman2;
                    walkAnimNumber = 0;
                    attacking = false;
                }
            }
            #endregion

            #region BugAnims
            else if (type == "bug")
            {
                if (!attacking)
                {
                    walkAnimNumber++;
                    if (walkAnimNumber == 1)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugWalk1;
                    }
                    else if (walkAnimNumber == 2)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugWalk2;
                    }
                    else if (walkAnimNumber == 3)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugWalk3;
                    }
                    else if (walkAnimNumber == 4)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugWalk2;
                        walkAnimNumber = 0;
                    }
                }
                else if (attacking)
                {
                    attackAnimNumber++;
                    if (attackAnimNumber == 1)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugAttack1;
                    }
                    else if (attackAnimNumber == 2)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugAttack2;
                    }
                    else if (attackAnimNumber == 3)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bugAttack1;
                        attacking = false;
                        attackAnimNumber = 0;
                    }
                }
            }
            #endregion

            #region BombAnims
            else if (type == "bomb")
            {
                if (!attacking)
                {
                    walkAnimNumber++;
                    if (walkAnimNumber == 3)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombWalk1;
                    }
                    else if (walkAnimNumber == 6)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombWalk2;
                    }
                    else if (walkAnimNumber == 9)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombWalk3;
                    }
                    else if (walkAnimNumber == 12)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombWalk2;
                        walkAnimNumber = 0;
                    }
                }
                else if (attacking)
                {
                    attackAnimNumber++;
                    if (attackAnimNumber == 8)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombAttack1;
                    }
                    else if (attackAnimNumber == 18)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombAttack2;
                    }
                    else if (attackAnimNumber == 20)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombAttack3;
                    }
                    else if (attackAnimNumber == 26)
                    {
                        bmp = Zombie_Shooter_Tower_Defense.Properties.Resources.bombAttack4;
                    }
                    else if (attackAnimNumber == 28)
                    {
                        attackAnimNumber = 0;
                        attacking = false;
                        finishedAnimating = true;
                        readyToKill = true;
                    }
                }
            }
            #endregion

            rect.Size = bmp.Size;
        }

        public void LoseIcedTime()
        {
            icedTime--;
            if (icedTime == 0)
                actualSpeed = regSpeed;
        }

        public void AttackStuff()
        {
            if (!canAttack && !attacking)
            {
                attackDelay--;
            }
            if (attackDelay <= 0)
            {
                canAttack = true;
            }
        }

        public float GetAngle(Rectangle rect2)
        {
            double rise = (rect2.Y + (rect2.Height / 2) - rect.Y - 12);
            double run = (rect2.X + (rect2.Width / 2) - rect.X - 8);
            double theta = 1;
            if (rise == 0 && run == 0)
            {
                theta = 0;
            }
            else if (rect2.X + (rect2.Width / 2) >= rect.X + 8)
            {
                theta = Math.Atan(rise / run);
            }
            else if (rect2.X + (rect2.Width / 2) < rect.X + 8)
            {
                theta = Math.Atan(rise / run) + Math.PI;
            }
            theta = (theta * 360) / (Math.PI * 2);
            return (float)theta;
        }

        public void GetTarget(List<Turret> lstOfTurrets)
        {
            bool theresATurretToTarget = false;
            foreach (Turret t in lstOfTurrets)
            {
                if (t.Alive())
                {
                    theresATurretToTarget = true;
                    break;
                }
            }
            if (!theresATurretToTarget)
            {
                Kill();
            }
            if (target == null && theresATurretToTarget)
            {
                List<int> distancesList = new List<int>();
                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive())
                    {
                        double x = (t.Rect().X + 8 - rect.X) * (t.Rect().X + 8 - rect.X);
                        double y = (t.Rect().Y + 8 - rect.Y) * (t.Rect().Y + 8 - rect.Y);
                        double distance = x + y;
                        distance = Math.Sqrt(distance);
                        distancesList.Add((int)distance);
                    }
                }

                int minDist = distancesList.Min();

                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive())
                    {
                        double x = (t.Rect().X + 8 - rect.X) * (t.Rect().X + 8 - rect.X);
                        double y = (t.Rect().Y + 8 - rect.Y) * (t.Rect().Y + 8 - rect.Y);
                        double distance = x + y;
                        distance = Math.Sqrt(distance);
                        if (minDist == (int)distance)
                        {
                            target = t;
                        }
                    }
                }
            }
        }

        public List<Object> Move(Rectangle guyRect, List<Turret> lstOfTurrets, int[,] board, int[,] shadeArray)
        {
            List<Object> returnList = new List<object>();
            returnList.Add(null);
            returnList.Add(false);

            #region MoveBombs
            if (type == "bomb")
            {
                GetTarget(lstOfTurrets);

                foreach (Turret t in lstOfTurrets)
                {
                    if (t == target)
                    {
                        if (!t.Alive())
                        {
                            target = null;
                            GetTarget(lstOfTurrets);
                            break;
                        }
                    }
                }

                if (alive && target != null)
                {
                    //Move stuff. Moves toward target instead of guy, everything else is same.
                    rise = (target.Rect().Y - rect.Y);
                    run = (target.Rect().X - rect.X);
                    if (rise == 0 && run == 0)
                    {
                    }
                    else
                    { //Move him
                        xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * actualSpeed;
                        ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * actualSpeed;
                        xLoc = xLoc + xSpeed;
                        yLoc = yLoc + ySpeed;
                        rect.X = Convert.ToInt32(xLoc);
                        rect.Y = Convert.ToInt32(yLoc);
                    }

                    visible = false;

                    //See if he is in fog or not
                    for (int j = 0; j < 160; j++)
                    {
                        for (int i = 0; i < 160; i++)
                        {
                            Rectangle shadedRect = new Rectangle(j * 5, i * 5, 5, 5);
                            if (shadedRect.IntersectsWith(rect))
                            {
                                if (shadeArray[j, i] != 0)
                                    visible = true;
                            }
                            if (visible == true)
                                break;
                        }
                        if (visible == true)
                            break;
                    }

                    //Collide with turrets, move back
                    foreach (Turret t in lstOfTurrets)
                    {
                        if (t.Alive())
                        {
                            if (t.Alive() && t.Rect().IntersectsWith(rect))
                            {
                                int rectTop = rect.Top;
                                int rectLeft = rect.Left;
                                int rectRight = rect.Right;
                                int rectBottom = rect.Bottom;

                                int turretTop = t.Rect().Top;
                                int turretRight = t.Rect().Right;
                                int turretLeft = t.Rect().Left;
                                int turretBottom = t.Rect().Bottom;

                                //down
                                if (rectBottom > turretTop && rectBottom < turretTop + 6)
                                {
                                    xLoc = xLoc - xSpeed;
                                    yLoc = yLoc - ySpeed;
                                    rect.X = Convert.ToInt32(xLoc);
                                    rect.Y = Convert.ToInt32(yLoc);
                                }
                                //up
                                if (rectTop < turretBottom && rectTop > turretBottom - 6)
                                {
                                    xLoc = xLoc - xSpeed;
                                    yLoc = yLoc - ySpeed;
                                    rect.X = Convert.ToInt32(xLoc);
                                    rect.Y = Convert.ToInt32(yLoc);
                                }
                                //right
                                if (rectRight > turretLeft && rectRight < turretLeft + 6)
                                {
                                    xLoc = xLoc - xSpeed;
                                    yLoc = yLoc - ySpeed;
                                    rect.X = Convert.ToInt32(xLoc);
                                    rect.Y = Convert.ToInt32(yLoc);
                                }
                                //left
                                if (rectLeft < turretRight && rectLeft > turretRight - 6)
                                {
                                    xLoc = xLoc - xSpeed;
                                    yLoc = yLoc - ySpeed;
                                    rect.X = Convert.ToInt32(xLoc);
                                    rect.Y = Convert.ToInt32(yLoc);
                                }
                                //Return turret you collided with to cause damage to it
                                if (canAttack)
                                {
                                    canAttack = false;
                                    attacking = true;
                                    attackDelay = attackDelayTime;
                                }
                                if (finishedAnimating)
                                {
                                    returnList[0] = t;
                                }
                            }
                        }
                        else if (!t.Alive())
                        {
                            break;
                        }
                    }
                }
                if (readyToKill)
                {
                    Kill();
                }
            }
            #endregion

            #region NotBombs
            if (type != "bomb")
            {
                rise = (guyRect.Y - rect.Y);
                run = (guyRect.X - rect.X);
                if (rise == 0 && run == 0)
                {
                }
                else
                { //Move him
                    xSpeed = (run / (Math.Abs(rise) + Math.Abs(run))) * actualSpeed;
                    ySpeed = (rise / (Math.Abs(rise) + Math.Abs(run))) * actualSpeed;
                    xLoc = xLoc + xSpeed;
                    yLoc = yLoc + ySpeed;
                    rect.X = Convert.ToInt32(xLoc);
                    rect.Y = Convert.ToInt32(yLoc);
                }

                visible = false;

                //See if he is in fog or not
                for (int j = 0; j < 160; j++)
                {
                    for (int i = 0; i < 160; i++)
                    {
                        Rectangle shadedRect = new Rectangle(j * 5, i * 5, 5, 5);
                        if (shadedRect.IntersectsWith(rect))
                        {
                            if (shadeArray[j, i] != 0)
                                visible = true;
                        }
                        if (visible == true)
                            break;
                    }
                    if (visible == true)
                        break;
                }

                //Collide with guy, move back
                if (rect.IntersectsWith(guyRect))
                {
                    int rectTop = rect.Top;
                    int rectLeft = rect.Left;
                    int rectRight = rect.Right;
                    int rectBottom = rect.Bottom;

                    int guyTop = guyRect.Top;
                    int guyRight = guyRect.Right;
                    int guyLeft = guyRect.Left;
                    int guyBottom = guyRect.Bottom;

                    //down
                    if (rectBottom > guyTop && rectBottom < guyTop + 6)
                    {
                        //xLoc = xLoc - xSpeed;
                        yLoc = yLoc - ySpeed;
                        rect.X = Convert.ToInt32(xLoc);
                        rect.Y = Convert.ToInt32(yLoc);
                    }
                    //up
                    if (rectTop < guyBottom && rectTop > guyBottom - 6)
                    {
                        //xLoc = xLoc - xSpeed;
                        yLoc = yLoc - ySpeed;
                        rect.X = Convert.ToInt32(xLoc);
                        rect.Y = Convert.ToInt32(yLoc);
                    }
                    //right
                    if (rectRight > guyLeft && rectRight < guyLeft + 6)
                    {
                        xLoc = xLoc - xSpeed;
                        //yLoc = yLoc - ySpeed;
                        rect.X = Convert.ToInt32(xLoc);
                        rect.Y = Convert.ToInt32(yLoc);
                    }
                    //left
                    if (rectLeft < guyRight && rectLeft > guyRight - 6)
                    {
                        xLoc = xLoc - xSpeed;
                        //yLoc = yLoc - ySpeed;
                        rect.X = Convert.ToInt32(xLoc);
                        rect.Y = Convert.ToInt32(yLoc);
                    }
                    if (canAttack)
                    {
                        returnList[1] = true;
                        canAttack = false;
                        attacking = true;
                        attackDelay = attackDelayTime;
                    }

                    if (guyRect.IntersectsWith(rect))
                    {
                        //if (xSpeed > 0)
                        //{
                        //    xLoc = guyRect.Left - rect.Width - 1;
                        //    rect.X = Convert.ToInt32(xLoc);
                        //}
                        //else if (xSpeed < 0)
                        //{
                        //    xLoc = guyRect.Right + 1;
                        //    rect.X = Convert.ToInt32(xLoc);
                        //}
                        //else if (ySpeed > 0)
                        //{
                        //    yLoc = guyRect.Top - rect.Height - 1;
                        //    rect.Y = Convert.ToInt32(yLoc);
                        //}
                        //else if (ySpeed < 0)
                        //{
                        //    yLoc = guyRect.Bottom + 1;
                        //    rect.Y = Convert.ToInt32(yLoc);
                        //}
                        Point guyMiddle = new Point((guyRect.X + guyRect.Width / 2), (guyRect.Y + guyRect.Height / 2));
                        Point enemyMiddle = new Point((rect.X + rect.Width / 2), (rect.Y + rect.Height / 2));                        

                        int yDiff = guyMiddle.Y - enemyMiddle.Y;
                        //if negative, enemy below
                        int xDiff = guyMiddle.X - enemyMiddle.X;
                        //if neg, enemy to right

                        if (xDiff < 0 && xSpeed < -1)
                        {
                            xLoc = guyRect.Right + 1;
                            rect.X = Convert.ToInt32(xLoc);
                        }
                        if (xDiff > 0 && xSpeed > 1)
                        {
                            xLoc = guyRect.Left - rect.Width - 1;
                            rect.X = Convert.ToInt32(xLoc);
                        }
                        if (yDiff < 0 && ySpeed < -1)
                        {
                            yLoc = guyRect.Bottom + 1;
                            rect.Y = Convert.ToInt32(yLoc);
                        }
                        if (yDiff > 0 && ySpeed > 1)
                        {
                            yLoc = guyRect.Top - rect.Height - 1;
                            rect.Y = Convert.ToInt32(yLoc);
                        }
                    }

                }


                //Collide with turrets, move back
                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive())
                    {
                        if (t.Alive() && t.Rect().IntersectsWith(rect))
                        {
                            int rectTop = rect.Top;
                            int rectLeft = rect.Left;
                            int rectRight = rect.Right;
                            int rectBottom = rect.Bottom;

                            int turretTop = t.Rect().Top;
                            int turretRight = t.Rect().Right;
                            int turretLeft = t.Rect().Left;
                            int turretBottom = t.Rect().Bottom;

                            //down
                            if (rectBottom > turretTop && rectBottom < turretTop + 6)
                            {
                                xLoc = xLoc - xSpeed;
                                yLoc = yLoc - ySpeed;
                                rect.X = Convert.ToInt32(xLoc);
                                rect.Y = Convert.ToInt32(yLoc);
                            }
                            //up
                            if (rectTop < turretBottom && rectTop > turretBottom - 6)
                            {
                                xLoc = xLoc - xSpeed;
                                yLoc = yLoc - ySpeed;
                                rect.X = Convert.ToInt32(xLoc);
                                rect.Y = Convert.ToInt32(yLoc);
                            }
                            //right
                            if (rectRight > turretLeft && rectRight < turretLeft + 6)
                            {
                                xLoc = xLoc - xSpeed;
                                yLoc = yLoc - ySpeed;
                                rect.X = Convert.ToInt32(xLoc);
                                rect.Y = Convert.ToInt32(yLoc);
                            }
                            //left
                            if (rectLeft < turretRight && rectLeft > turretRight - 6)
                            {
                                xLoc = xLoc - xSpeed;
                                yLoc = yLoc - ySpeed;
                                rect.X = Convert.ToInt32(xLoc);
                                rect.Y = Convert.ToInt32(yLoc);
                            }
                            //Return turret you collided with to cause damage to it
                            if (canAttack)
                            {
                                returnList[0] = t;
                                canAttack = false;
                                attacking = true;
                                attackDelay = attackDelayTime;
                            }
                        }
                    }
                    else if (!t.Alive())
                    {
                        break;
                    }
                }
            }
            #endregion

            return returnList;
        }

        public void LoseHealth(int damageTaken)
        {
            health -= damageTaken;
            if (health <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            alive = false;
        }

        public int Value()
        {
            return value;
        }

        public int TurretDamage()
        {
            return turretDamage;
        }

        public int PlayerDamage()
        {
            return playerDamage;
        }

        public bool Alive()
        {
            return alive;
        }

        public bool Visible()
        {
            return visible;
        }

        public string Type()
        {
            return type;
        }

        public Rectangle Rect()
        {
            return rect;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
