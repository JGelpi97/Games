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

namespace Zombie_Shooter_Tower_Defense
{
    class Player
    {
        Bitmap bmpMain = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistol);
        Rectangle rectMain = new Rectangle();

        ImageAttributes attr = new ImageAttributes();
        
        Rectangle rectFeet = new Rectangle();
        Bitmap bmpFeet = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.guyFeet1);

        Rectangle rectCollision = new Rectangle();

        int money = 20;

        bool movingRight, movingLeft, movingDown, movingUp, isFiring = false;
        string currentWeapon = "pistol";
        int feetAnimation = 0;
        int gunAnimation = 0;
        bool inAnimation = false;
        int flares = 10;

        int smgRechargeTime = 0;
        int shotgunRechargeTime = 0;
        int sniperRechargeTime = 0;
        int minigunRechargeTime = 0;

        int smgMaxAmmo = 50;
        int shotgunMaxAmmo = 20;
        int sniperMaxAmmo = 20;
        int minigunMaxAmmo = 75;

        int smgAmmo = 50;
        int shotgunAmmo = 20;
        int sniperAmmo = 20;
        int minigunAmmo = 75;
        int currentWeaponAmmo = 999;

        int health = 20;

        double XPos, YPos;

        public void Reset()
        {
             money = 20;

             movingRight = false; movingLeft = false; movingDown = false; movingUp = false; isFiring = false;
             currentWeapon = "pistol";
             feetAnimation = 0;
             gunAnimation = 0;
             inAnimation = false;
             flares = 10;

             smgRechargeTime = 0;
             shotgunRechargeTime = 0;
             sniperRechargeTime = 0;
             minigunRechargeTime = 0;

             smgMaxAmmo = 50;
             shotgunMaxAmmo = 20;
             sniperMaxAmmo = 20;
             minigunMaxAmmo = 75;

             smgAmmo = 50;
             shotgunAmmo = 20;
             sniperAmmo = 20;
             minigunAmmo = 75;
             currentWeaponAmmo = 999;

             health = 20;

             rectCollision.Size = new Size(17, 25);
             rectCollision.Location = new Point(300, 300);
             attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
             rectMain.Size = bmpMain.Size;
             rectMain.Location = new Point(300, 300);
             rectFeet.Location = new Point(300, 300);
             rectFeet.Size = bmpFeet.Size;
             XPos = rectMain.X;
             YPos = rectMain.Y;
        }

        public Player()
        {
            rectCollision.Size = new Size(17, 25);
            rectCollision.Location = new Point(300, 300);
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            rectMain.Size = bmpMain.Size;
            rectMain.Location = new Point(300, 300);
            rectFeet.Location = new Point(300, 300);
            rectFeet.Size = bmpFeet.Size;
            XPos = rectMain.X;
            YPos = rectMain.Y;
        }

        public void IsFiring(bool x)
        {
            isFiring = x;
        }

        public void AddFlare(int x)
        {
            flares += x; ;
        }

        public void Animate()
        {
            //feet anims
            if (movingDown || movingLeft || movingRight || movingUp)
            {
                feetAnimation++;
                if (feetAnimation == 3)
                {
                    bmpFeet = Zombie_Shooter_Tower_Defense.Properties.Resources.guyFeet1;
                }
                else if (feetAnimation == 6)
                {
                    bmpFeet = Zombie_Shooter_Tower_Defense.Properties.Resources.guyFeet2;
                    feetAnimation = 0;
                }
            }

            //weapon anims
            if (currentWeaponAmmo != 0)
            {
                if (isFiring || inAnimation)
                {
                    if (currentWeapon == "minigun")
                    {
                        gunAnimation++;
                        if (gunAnimation == 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyMinigunFiring1;
                        }
                        else if (gunAnimation == 2)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyMinigunFiring2;
                            gunAnimation = 0;
                        }
                    }
                    else if (currentWeapon == "smg")
                    {
                        inAnimation = true;
                        gunAnimation++;
                        if (gunAnimation == 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySMGFiring1;
                        }
                        else if (gunAnimation == 2)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySMGFiring2;
                            gunAnimation = 0;
                            inAnimation = false;
                        }
                    }
                    else if (currentWeapon == "pistol")
                    {
                        inAnimation = true;
                        gunAnimation++;
                        if (gunAnimation == 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistolFiring1;
                        }
                        else if (gunAnimation != 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistol;
                        }
                        if (gunAnimation > 5)
                        {
                            gunAnimation = 0;
                            inAnimation = false;
                        }
                    }
                    else if (currentWeapon == "shotgun")
                    {
                        inAnimation = true;
                        gunAnimation++;
                        if (gunAnimation == 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyShotgunFiring1;
                        }
                        else if (gunAnimation != 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyShotgun;
                        }
                        if (gunAnimation > 8)
                        {
                            gunAnimation = 0;
                            inAnimation = false;
                        }
                    }
                    else if (currentWeapon == "sniper")
                    {
                        inAnimation = true;
                        gunAnimation++;
                        if (gunAnimation == 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySniperFiring1;
                        }
                        else if (gunAnimation != 1)
                        {
                            bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySniper;
                        }
                        if (gunAnimation > 10)
                        {
                            gunAnimation = 0;
                            inAnimation = false;
                        }
                    }
                    rectMain.Size = bmpMain.Size;
                }
            }
            else
            {
                gunAnimation = 0;
                if (currentWeapon == "pistol")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistol;
                else if (currentWeapon == "smg")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySMG;
                else if (currentWeapon == "shotgun")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyShotgun;
                else if (currentWeapon == "sniper")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySniper;
                else if (currentWeapon == "minigun")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyMinigun;
                rectMain.Size = bmpMain.Size;
            }

            //if doing nothing, set to default
            if (!isFiring && !inAnimation)
            {
                gunAnimation = 0;
                if (currentWeapon == "pistol")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistol;
                else if (currentWeapon == "smg")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySMG;
                else if (currentWeapon == "shotgun")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyShotgun;
                else if (currentWeapon == "sniper")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySniper;
                else if (currentWeapon == "minigun")
                    bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyMinigun;
                rectMain.Size = bmpMain.Size;
            }
        }

        public void GainHealth(int x)
        {
            health += x;
        }

        public void RechargeAmmo()
        {
            smgRechargeTime--;
            shotgunRechargeTime--;
            sniperRechargeTime--;
            minigunRechargeTime--;

            if (isFiring && currentWeapon == "pistol")
            {
                if (smgAmmo < smgMaxAmmo && smgRechargeTime <= 0)
                {
                    smgRechargeTime = 3;
                    smgAmmo++;
                }
                if (shotgunAmmo < shotgunMaxAmmo && shotgunRechargeTime <= 0)
                {
                    shotgunRechargeTime = 9;
                    shotgunAmmo++;
                }
                if (sniperAmmo < sniperMaxAmmo && sniperRechargeTime <= 0)
                {
                    sniperRechargeTime = 11;
                    sniperAmmo++;
                }
                if (minigunAmmo < minigunMaxAmmo && minigunRechargeTime <= 0)
                {
                    minigunRechargeTime = 6;
                    minigunAmmo++;
                }
            }
            else if (isFiring && currentWeapon == "smg")
            {
                if (shotgunAmmo < shotgunMaxAmmo && shotgunRechargeTime <= 0)
                {
                    shotgunRechargeTime = 9;
                    shotgunAmmo++;
                }
                if (sniperAmmo < sniperMaxAmmo && sniperRechargeTime <= 0)
                {
                    sniperRechargeTime = 11;
                    sniperAmmo++;
                }
                if (minigunAmmo < minigunMaxAmmo && minigunRechargeTime <= 0)
                {
                    minigunRechargeTime = 6;
                    minigunAmmo++;
                }
            }
            else if (isFiring && currentWeapon == "shotgun")
            {
                if (smgAmmo < smgMaxAmmo && smgRechargeTime <= 0)
                {
                    smgRechargeTime = 3;
                    smgAmmo++;
                }
                if (sniperAmmo < sniperMaxAmmo && sniperRechargeTime <= 0)
                {
                    sniperRechargeTime = 11;
                    sniperAmmo++;
                }
                if (minigunAmmo < minigunMaxAmmo && minigunRechargeTime <= 0)
                {
                    minigunRechargeTime = 6;
                    minigunAmmo++;
                }
            }
            else if (isFiring && currentWeapon == "sniper")
            {
                if (smgAmmo < smgMaxAmmo && smgRechargeTime <= 0)
                {
                    smgRechargeTime = 3;
                    smgAmmo++;
                }
                if (shotgunAmmo < shotgunMaxAmmo && shotgunRechargeTime <= 0)
                {
                    shotgunRechargeTime = 9;
                    shotgunAmmo++;
                }
                if (minigunAmmo < minigunMaxAmmo && minigunRechargeTime <= 0)
                {
                    minigunRechargeTime = 6;
                    minigunAmmo++;
                }
            }
            else if (isFiring && currentWeapon == "minigun")
            {
                if (smgAmmo < smgMaxAmmo && smgRechargeTime <= 0)
                {
                    smgRechargeTime = 3;
                    smgAmmo++;
                }
                if (shotgunAmmo < shotgunMaxAmmo && shotgunRechargeTime <= 0)
                {
                    shotgunRechargeTime = 9;
                    shotgunAmmo++;
                }
                if (sniperAmmo < sniperMaxAmmo && sniperRechargeTime <= 0)
                {
                    sniperRechargeTime = 11;
                    sniperAmmo++;
                }
            }
            else if (!isFiring)
            { 
                if (smgAmmo < smgMaxAmmo && smgRechargeTime <= 0)
                {
                    smgRechargeTime = 3;
                    smgAmmo++;
                }
                if (shotgunAmmo < shotgunMaxAmmo && shotgunRechargeTime <= 0)
                {
                    shotgunRechargeTime = 9;
                    shotgunAmmo++;
                }
                if (sniperAmmo < sniperMaxAmmo && sniperRechargeTime <= 0)
                {
                    sniperRechargeTime = 11;
                    sniperAmmo++;
                }
                if (minigunAmmo < minigunMaxAmmo && minigunRechargeTime <= 0)
                {
                    minigunRechargeTime = 6;
                    minigunAmmo++;
                }
            }

            if (currentWeapon == "pistol")
            {
                currentWeaponAmmo = 999;
            }
            else if (currentWeapon == "smg")
            {
                currentWeaponAmmo = smgAmmo;
            }
            else if (currentWeapon == "shotgun")
            {
                currentWeaponAmmo = shotgunAmmo;
            }
            else if (currentWeapon == "sniper")
            {
                currentWeaponAmmo = sniperAmmo;
            }
            else if (currentWeapon == "minigun")
            {
                currentWeaponAmmo = minigunAmmo;
            }
        }

        public void Move(List<Turret> lstOfTurrets, List<Enemy> lstOfEnemies)
        {
            double YChange = 0;
            double XChange = 0;
            if (movingRight && !movingUp && !movingDown)
            {
                XChange += 6;
            }
            else if (movingLeft && !movingUp && !movingDown)
            {
                XChange -= 6;
            }
            else if (movingDown && !movingLeft && !movingRight)
            {
                YChange += 6;
            }
            else if (movingUp && !movingLeft && !movingRight)
            {
                YChange -= 6;
            }
            if (movingRight && movingUp)
            {
                XChange += Math.Sqrt(18);
                YChange -= Math.Sqrt(18);
            }
            else if (movingRight && movingDown)
            {
                XChange += Math.Sqrt(18);
                YChange += Math.Sqrt(18);
            }
            else if (movingLeft && movingDown)
            {
                XChange -= Math.Sqrt(18);
                YChange += Math.Sqrt(18);
            }
            else if (movingLeft && movingUp)
            {
                XChange -= Math.Sqrt(18);
                YChange -= Math.Sqrt(18);
            }
            XPos += XChange;
            YPos += YChange;
            rectCollision.Location = new Point((int)XPos , (int)YPos);
            rectFeet.Location = new Point((int)XPos, (int)YPos);
            rectMain.Location = new Point((int)XPos, (int)YPos);

            foreach (Turret t in lstOfTurrets)
            {
                if (t.Alive() && t.Rect().IntersectsWith(rectCollision))
                {
                    int rectTop = rectCollision.Top;
                    int rectLeft = rectCollision.Left;
                    int rectRight = rectCollision.Right;
                    int rectBottom = rectCollision.Bottom;

                    int turretTop = t.Rect().Top;
                    int turretRight = t.Rect().Right;
                    int turretLeft = t.Rect().Left;
                    int turretBottom = t.Rect().Bottom;

                    //down
                    if (movingDown && rectBottom >= turretTop && rectBottom <= turretTop + 6)
                    {
                        YPos = turretTop - rectCollision.Height;
                    }
                    
                    //up
                    if (movingUp && rectTop <= turretBottom && rectTop >= turretBottom - 6)
                    {
                        YPos = turretBottom;
                    }

                    //right
                    if (movingRight && rectRight >= turretLeft && rectRight <= turretLeft + 6)
                    {
                        XPos = turretLeft - rectCollision.Width;
                    }

                    //left
                    if (movingLeft && rectLeft <= turretRight && rectLeft >= turretRight - 6)
                    {
                        XPos = turretRight;
                    }
                    rectCollision.Location = new Point((int)XPos, (int)YPos);
                    rectFeet.Location = new Point((int)XPos, (int)YPos);
                    rectMain.Location = new Point((int)XPos, (int)YPos);
                }
            }

            foreach (Enemy t in lstOfEnemies)
            {
                if (t.Alive() && t.Rect().IntersectsWith(rectCollision))
                {
                    int rectTop = rectCollision.Top;
                    int rectLeft = rectCollision.Left;
                    int rectRight = rectCollision.Right;
                    int rectBottom = rectCollision.Bottom;

                    int eTop = t.Rect().Top;
                    int eRight = t.Rect().Right;
                    int eLeft = t.Rect().Left;
                    int eBottom = t.Rect().Bottom;

                    //down
                    if (movingDown && rectBottom >= eTop && rectBottom <= eTop + 6)
                    {
                        YPos = eTop - rectCollision.Height;
                    }

                    //up
                    if (movingUp && rectTop <= eBottom && rectTop >= eBottom - 6)
                    {
                        YPos = eBottom;
                    }

                    //right
                    if (movingRight && rectRight >= eLeft && rectRight <= eLeft + 6)
                    {
                        XPos = eLeft - rectCollision.Width;
                    }

                    //left
                    if (movingLeft && rectLeft <= eRight && rectLeft >= eRight - 6)
                    {
                        XPos = eRight;
                    }
                    rectCollision.Location = new Point((int)XPos, (int)YPos);
                    rectFeet.Location = new Point((int)XPos, (int)YPos);
                    rectMain.Location = new Point((int)XPos, (int)YPos);
                }
            }
        }

        public float GetAngle(int x, int y)
        {
            double rise = (y - rectMain.Y - 12);
            double run = (x - rectMain.X - 8);
            double theta = 1;
            if (rise == 0 && run == 0)
            {
                theta = 0;
            }
            else if (x >= rectMain.X + 8)
            {
                theta = Math.Atan(rise / run);
            }
            else if (x < rectMain.X + 8)
            {
                theta = Math.Atan(rise / run) + Math.PI;
            }
            theta = (theta * 360 ) /  (Math.PI * 2);
            return (float)theta;
        }

        public Rectangle Rect()
        {
            return rectMain;
        }

        public Rectangle CollisionRect()
        {
            return rectCollision;
        }

        #region Moving Codes
        public void SetMovingRight(bool x)
        {
            movingRight = x;
        }
        public void SetMovingLeft(bool x)
        {
            movingLeft = x;
        }
        public void SetMovingDown(bool x)
        {
            movingDown = x;
        }
        public void SetMovingUp(bool x)
        {
            movingUp = x;
        }

        public bool MovingRight()
        {
            return movingRight;
        }
        public bool MovingLeft()
        {
            return movingLeft;
        }
        public bool MovingDown()
        {
            return movingDown;
        }
        public bool MovingUp()
        {
            return movingUp;
        }
        #endregion

        public void LoseHealth(int x)
        {
            health -= x;
        }

        public string CurrentWeapon()
        {
            return currentWeapon;
        }

        public int Health()
        {
            return health;
        }

        public void SetWeapon(string x)
        {
            inAnimation = false;
            currentWeapon = x;
            feetAnimation = 0;
            gunAnimation = 0;
            if (currentWeapon == "pistol")
            {
                bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyPistol;
                currentWeaponAmmo = 999;
            }
            else if (currentWeapon == "smg")
            {
                bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySMG;
                currentWeaponAmmo = smgAmmo;
            }
            else if (currentWeapon == "shotgun")
            {
                bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyShotgun;
                currentWeaponAmmo = shotgunAmmo;
            }
            else if (currentWeapon == "sniper")
            {
                bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guySniper;
                currentWeaponAmmo = sniperAmmo;
            }
            else if (currentWeapon == "minigun")
            {
                bmpMain = Zombie_Shooter_Tower_Defense.Properties.Resources.guyMinigun;
                currentWeaponAmmo = minigunAmmo;
            }
            rectMain.Size = bmpMain.Size;
        }

        public void LoseAmmo()
        {
            if (currentWeapon == "smg")
            {
                smgAmmo--;
                currentWeaponAmmo = smgAmmo;
            }
            else if (currentWeapon == "shotgun")
            {
                shotgunAmmo--;
                currentWeaponAmmo = shotgunAmmo;
            }
            else if (currentWeapon == "sniper")
            {
                sniperAmmo--;
                currentWeaponAmmo = sniperAmmo;
            }
            else if (currentWeapon == "minigun")
            {
                minigunAmmo--;
                currentWeaponAmmo = minigunAmmo;
            }
        }

        public int CurrentWeaponAmmo()
        {
            return currentWeaponAmmo;
        }

        public int Flares()
        {
            return flares;
        }

        public void LoseFlare()
        {             
            flares--;
            if (flares < 0)
                flares = 0;
        }

        public void LoseMoney(int x)
        {
            money -= x;
        }

        public void GainMoney(int x)
        {
            money += x;
            if (money > 9999)
                money = 9999;
        }

        public int Money()
        {
            return money;
        }

        public void TakeDamage(int x)
        {
            health -= x;
        }

        public void Draw(Graphics g)
        {            
            g.DrawImage(bmpMain, rectMain, 0, 0, bmpMain.Width, bmpMain.Height, GraphicsUnit.Pixel, attr);
            g.DrawImage(bmpFeet, rectFeet, 0, 0, bmpFeet.Width, bmpFeet.Height, GraphicsUnit.Pixel, attr);
        }

    }
}
