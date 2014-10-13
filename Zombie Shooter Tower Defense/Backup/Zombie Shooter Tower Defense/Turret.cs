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
    class Turret
    {
        Bitmap bmpBase = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase);
        ImageAttributes attr = new ImageAttributes();
        Rectangle rectBase = new Rectangle();
        Bitmap bmpGun = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase);
        Rectangle rectGun = new Rectangle();
        Enemy target;
        string type;
        int level, health, arrayX, arrayY;
        bool alive = true;
        int firingDelay, firingTime;
        int damage;
        float oldAngle = 0;
        bool drewLight = false;
        bool turretLightWasErased = false;
        int costToUpgrade = 0;
        int sellAmount = 0;
        int maxHealth = 0;

        public float GetAngle(int x, int y)
        {
            double rise = (y - rectBase.Y - 12);
            double run = (x - rectBase.X - 8);
            double theta = 1;
            if (rise == 0 && run == 0)
            {
                theta = 0;
            }
            else if (x >= rectBase.X + 8)
            {
                theta = Math.Atan(rise / run);
            }
            else if (x < rectBase.X + 8)
            {
                theta = Math.Atan(rise / run) + Math.PI;
            }
            theta = (theta * 360) / (Math.PI * 2);
            oldAngle = (float)theta;
            return (float)theta;
        }

        public float OldAngle()
        {
            return oldAngle;
        }

        public void Repair()
        {
            health += 10;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public int MaxHealth()
        {
            return maxHealth;
        }

        public void DecreaseTimeToFire()
        {
            firingTime--;
            if (firingTime < 0)
                firingTime = 0;
        }

        public bool WasTurretLightErased()
        {
            return turretLightWasErased;
        }

        public void TheTurretLightWasErased()
        {
            turretLightWasErased = true;
        }

        public Turret(int xLoc, int yLoc, string _type)
        {
            type = _type;
            if (type == "basic")
            {
                bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretBase;
                bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretGun;
                firingDelay = 12;
                firingTime = firingDelay;
                health = 20;
                level = 1;
                damage = 2;
                costToUpgrade = 30;
                sellAmount = 10;
            }
            else if (type == "speed")
            {
                bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase;
                bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretGun;
                firingDelay = 4;
                firingTime = firingDelay;
                health = 20;
                level = 1;
                damage = 1;
                costToUpgrade = 40;
                sellAmount = 12;
            }
            else if (type == "ice")
            {
                bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretBase;
                bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretGun;
                firingDelay = 15;
                firingTime = firingDelay;
                health = 15;
                level = 1;
                damage = 1;
                costToUpgrade = 25;
                sellAmount = 10;
            }
            else if (type == "rocket")
            {
                bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretBase;
                bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretGun;
                firingDelay = 30;
                firingTime = firingDelay;
                health = 15;
                level = 1;
                damage = 5;
                costToUpgrade = 50;
                sellAmount = 20;
            }
            arrayX = xLoc / 30;
            arrayY = yLoc / 30;
            rectBase.X = xLoc;
            rectBase.Y = yLoc;
            rectBase.Size = bmpBase.Size;
            rectGun.Size = bmpBase.Size;
            rectGun.X = xLoc;
            rectGun.Y = yLoc;
            attr.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            maxHealth = health;
        }

        public void Upgrade()
        {
            if (level < 3)
                level++;
            if (type == "basic")
            {
                if (level == 2)
                {
                    damage = 4;
                    health = 30;
                    firingDelay = 10;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretBase2;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretGun2;
                    costToUpgrade = 40;
                    sellAmount = 15;
                    maxHealth = health;
                }
                else if (level == 3)
                {
                    damage = 6;
                    health = 40;
                    firingDelay = 8;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretBase3;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurretGun3;
                    sellAmount = 20;
                    costToUpgrade = 0;
                    maxHealth = health;
                }
            }
            else if (type == "speed")
            {
                if (level == 2)
                {
                    damage = 2;
                    health = 25;
                    firingDelay = 3;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase2;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretGun2;
                    costToUpgrade = 50;
                    sellAmount = 15;
                    maxHealth = health;
                }
                else if (level == 3)
                {
                    damage = 3;
                    health = 30;
                    firingDelay = 3;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase3;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretGun3;
                    sellAmount = 20;
                    costToUpgrade = 0;
                    maxHealth = health;
                }
            }
            else if (type == "ice")
            {
                if (level == 2)
                {
                    damage = 1;
                    health = 20;
                    firingDelay = 12;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretBase2;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretGun2;
                    costToUpgrade = 30;
                    sellAmount = 15;
                    maxHealth = health;
                }
                else if (level == 3)
                {
                    damage = 2;
                    health = 25;
                    firingDelay = 7;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretBase3;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurretGun3;
                    sellAmount = 20;
                    costToUpgrade = 0;
                    maxHealth = health;
                }
            }
            else if (type == "rocket")
            {
                if (level == 2)
                {
                    damage = 8;
                    health = 25;
                    firingDelay = 25;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretBase2;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretGun2;
                    costToUpgrade = 65;
                    sellAmount = 35;
                    maxHealth = health;
                }
                else if (level == 3)
                {
                    damage = 10;
                    health = 35;
                    firingDelay = 25;
                    bmpBase = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretBase3;
                    bmpGun = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurretGun3;
                    sellAmount = 45;
                    costToUpgrade = 0;
                    maxHealth = health;
                }
            }
        }

        public bool DrewLight()
        {
            return drewLight;
        }

        public void ReDrawLight()
        {
            drewLight = false;
        }

        public void TheLightWasDrawn()
        {
            drewLight = true;
        }

        public void Target(List<Enemy> lstEnemies)
        {
            if (target == null)
            {
                foreach (Enemy en in lstEnemies)
                {
                    double x = (rectBase.X - en.Rect().X) * (rectBase.X - en.Rect().X);
                    double y = (rectBase.Y - en.Rect().Y) * (rectBase.Y - en.Rect().Y);

                    double dist = (x + y);
                    dist = Math.Sqrt(dist);
                    if (dist < 150 && en.Alive() && en.Visible())
                    {
                        target = en;
                        break;
                    }
                }
            }
            if (target != null)
            {
                double x = (rectBase.X - target.Rect().X) * (rectBase.X - target.Rect().X);
                double y = (rectBase.Y - target.Rect().Y) * (rectBase.Y - target.Rect().Y);
                double dist = (x + y);
                dist = Math.Sqrt(dist);
                if (dist > 150 || !target.Alive() || !target.Visible())
                {
                    target = null;
                }
            }
        }

        public void LoseHealth(int healthLost)
        {
            health -= healthLost;
            if (health <= 0)
                Kill();
        }

        public int Health()
        {
            return health;
        }

        public void ResetFiringTime()
        {
            firingTime = firingDelay;
        }

        public int FireTime()
        {
            return firingTime;
        }

        public int Damage()
        {
            return damage;
        }

        public int ArrayX()
        {
            return arrayX;
        }

        public int ArrayY()
        {
            return arrayY;
        }

        public int Level()
        {
            return level;
        }

        public string Type()
        {
            return type;
        }

        public Enemy CurrentTarget()
        {
            return target;
        }

        public bool Alive()
        {
            return alive;
        }

        public Rectangle Rect()
        {
            return rectBase;
        }

        public void Kill()
        {
            alive = false;
        }

        public int UpgradeCost()
        {
            return costToUpgrade;
        }

        public int SellAmount()
        {
            return sellAmount;
        }

        public void DrawBase(Graphics g)
        {
            g.DrawImage(bmpBase, rectBase, 0, 0, bmpBase.Width, bmpBase.Height, GraphicsUnit.Pixel, attr);
        }

        public void DrawGun(Graphics g)
        {
            g.DrawImage(bmpGun, rectGun, 0, 0, bmpGun.Width, bmpGun.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
