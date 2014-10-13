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
    class Flashlight
    {
        SolidBrush brush = new SolidBrush(Color.FromArgb(128,0,0,0));
        int[,] shadeArray = new int[160, 160];
        int[,] turretShadeArray = new int[160, 160];
        bool[,] isShadedSpotATurret = new bool[160, 160];

        public void Reset()
        {
            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 160; j++)
                {
                    shadeArray[i, j] = 0;
                }
            }
            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 160; j++)
                {
                    turretShadeArray[i, j] = 0;
                }
            }
            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 160; j++)
                {
                    isShadedSpotATurret[i, j] = false;
                }
            }
        }

        public List<Object> Draw(Graphics g, Rectangle guyRect, List<Turret> lstOfTurrets, List<Flare> lstOfFlares)
        {
            for (int j = 0; j < 160; j++)
            {
                for (int i = 0; i < 160; i++)
                {
                    shadeArray[j, i] = turretShadeArray[j, i];
                }
            }
   
            int left = 0;
            int top = 0;
            double guyDist = 999;
            double distance = 999;

            bool shouldIResetArray = false; //If one deletes, redraw all turrets

            foreach (Turret t in lstOfTurrets)
            {
                if (t.Alive() && !t.DrewLight())
                {
                    t.TheLightWasDrawn();
                    left = t.Rect().X - 150;
                    top = t.Rect().Y - 150;
                    int xLeft = t.Rect().X - 150;
                    int xRight = t.Rect().X + 150;
                    int yTop = t.Rect().Y - 150;
                    int yBottom = t.Rect().Y + 150;

                    for (int j = (xLeft) / 5; j < (xRight) / 5; j++)
                    {
                        for (int i = (yTop) / 5; i < (yBottom) / 5; i++)
                        {
                            if (i >= 0 && i < 160 && j >= 0 && j < 160)
                            {
                                double x = (t.Rect().X + 8 - left) * (t.Rect().X + 8 - left);
                                double y = (t.Rect().Y + 8 - top) * (t.Rect().Y + 8 - top);
                                distance = x + y;
                                distance = Math.Sqrt(distance);
                                if (distance < 130)
                                {
                                    int alpha = 0;
                                    if (distance <= 50)
                                    {
                                        alpha = 1;
                                    }
                                    else if (distance > 50)
                                    {
                                        alpha = (int)((distance - 49) * 2.2);
                                    }
                                    if (shadeArray[j, i] != 0)
                                    {
                                        int lighterShade = Math.Min(alpha, shadeArray[j, i]);
                                        lighterShade -= (int)(lighterShade * .05);
                                        if (lighterShade <= 0)
                                            lighterShade = 1;
                                        if (lighterShade > 175)
                                            lighterShade = 175;
                                        shadeArray[j, i] = lighterShade;
                                    }
                                    else
                                    {
                                        if (alpha > 175)
                                            alpha = 175;
                                        shadeArray[j, i] = alpha;
                                    }
                                }
                            } //End in bounds if
                            left += 5;
                        } //inside for loop
                        top += 5;
                        left = t.Rect().X - 150;
                    } //outside for
                }
                else if (!t.Alive() && !t.WasTurretLightErased())
                {
                    shouldIResetArray = true; //If theres a dead one and its light isnt gone
                    foreach (Turret r in lstOfTurrets)
                    {
                        if (r.Alive()) //Make it so all the alives redraw
                            r.ReDrawLight();
                    }
                    t.TheTurretLightWasErased(); //So it only happens once
                }
            } //end foreach

            #region Redo turret lights if one was deleted
            if (shouldIResetArray) //If one was deleted, reset shadearray
            {
                for (int j = 0; j < 160; j++)
                {
                    for (int i = 0; i < 160; i++)
                    {
                        shadeArray[j, i] = 0;
                    }
                }
                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive())// && !t.DrewLight())
                    {
                        t.TheLightWasDrawn();
                        left = t.Rect().X - 150;
                        top = t.Rect().Y - 150;
                        int xLeft = t.Rect().X - 150;
                        int xRight = t.Rect().X + 150;
                        int yTop = t.Rect().Y - 150;
                        int yBottom = t.Rect().Y + 150;

                        for (int j = (xLeft) / 5; j < (xRight) / 5; j++)
                        {
                            for (int i = (yTop) / 5; i < (yBottom) / 5; i++)
                            {
                                if (i >= 0 && i < 160 && j >= 0 && j < 160)
                                {
                                    double x = (t.Rect().X + 8 - left) * (t.Rect().X + 8 - left);
                                    double y = (t.Rect().Y + 8 - top) * (t.Rect().Y + 8 - top);
                                    distance = x + y;
                                    distance = Math.Sqrt(distance);
                                    if (distance < 130)
                                    {
                                        int alpha = 0;
                                        if (distance <= 50)
                                        {
                                            alpha = 1;
                                        }
                                        else if (distance > 50)
                                        {
                                            alpha = (int)((distance - 49) * 2.2);
                                        }
                                        if (shadeArray[j, i] != 0)
                                        {
                                            int lighterShade = Math.Min(alpha, shadeArray[j, i]);
                                            lighterShade -= (int)(lighterShade * .05);
                                            if (lighterShade <= 0)
                                                lighterShade = 1;
                                            if (lighterShade > 175)
                                                lighterShade = 175;
                                            shadeArray[j, i] = lighterShade;
                                        }
                                        else
                                        {
                                            if (alpha > 175)
                                                alpha = 175;
                                            shadeArray[j, i] = alpha;
                                        }
                                    }
                                } //End in bounds if
                                left += 5;
                            } //inside for loop
                            top += 5;
                            left = t.Rect().X - 150;
                        } //outside for
                    }
                    //else if (!t.Alive() && !t.WasTurretLightErased())
                    //{
                    //    shouldIResetArray = true; //If theres a dead one and its light isnt gone
                    //    foreach (Turret r in lstOfTurrets)
                    //    {
                    //        if (r.Alive()) //Make it so all the alives redraw
                    //            r.ReDrawLight();
                    //    }
                    //    t.TheTurretLightWasErased(); //So it only happens once
                    //}
                } //end foreach
            }
            #endregion

            for (int j = 0; j < 160; j++)
            {
                for (int i = 0; i < 160; i++)
                {
                    turretShadeArray[j, i] = shadeArray[j, i];
                }
            }

            //flares
            foreach (Flare f in lstOfFlares)
            {
                if (f.Alive())
                {
                    left = f.Rect().X - 150;
                    top = f.Rect().Y - 150;
                    int xLeft = f.Rect().X - 150;
                    int xRight = f.Rect().X + 150;
                    int yTop = f.Rect().Y - 150;
                    int yBottom = f.Rect().Y + 150;

                    for (int j = (xLeft) / 5; j < (xRight) / 5; j++)
                    {
                        for (int i = (yTop) / 5; i < (yBottom) / 5; i++)
                        {
                            if (i >= 0 && i < 160 && j >= 0 && j < 160)
                            {
                                double x = (f.Rect().X + 8 - left) * (f.Rect().X + 8 - left);
                                double y = (f.Rect().Y + 8 - top) * (f.Rect().Y + 8 - top);
                                distance = x + y;
                                distance = Math.Sqrt(distance);
                                if (distance < f.TimeLeftToLive() / 4.6)
                                {
                                    int alpha = 0;
                                    if (distance <= f.TimeLeftToLive() / 4.6 * .38)
                                    {
                                        alpha = 1;
                                    }
                                    else if (distance > f.TimeLeftToLive() / 4.6 * .38)
                                    {
                                        //.38 is % of distance to show
                                        //like 50 for a dist of 130 for turrets
                                        //TimeLeftToLive starts at 600. Divide by 4.6 to get a max of 130 for max dist
                                        alpha = (int)((distance - ((f.TimeLeftToLive() / 4.6 * .38) - 1)) * (175 / ((f.TimeLeftToLive() / 4.6) - (f.TimeLeftToLive() / 4.6 * .38))));
                                    }
                                    if (shadeArray[j, i] != 0)
                                    {
                                        int lighterShade = Math.Min(alpha, shadeArray[j, i]);
                                        lighterShade -= (int)(lighterShade * .05);
                                        if (lighterShade <= 0)
                                            lighterShade = 1;
                                        if (lighterShade > 175)
                                            lighterShade = 175;
                                        shadeArray[j, i] = lighterShade;
                                    }
                                    else
                                    {
                                        if (alpha > 175)
                                            alpha = 175;
                                        shadeArray[j, i] = alpha;
                                    }
                                }
                            } //End in bounds if
                            left += 5;
                        } //inside for loop
                        top += 5;
                        left = f.Rect().X - 150;
                    } //outside for
                }
            } //end foreach



            //Guys light
            left = guyRect.X - 150;
            top = guyRect.Y - 150;
            int guyXLeft = guyRect.X - 150;
            int guyXRight = guyRect.X + 150;
            int guyYTop = guyRect.Y - 150;
            int guyYBottom = guyRect.Y + 150;

            for (int j = (guyXLeft) / 5; j < (guyXRight) / 5; j++)
            {
                for (int i = (guyYTop) / 5; i < (guyYBottom) / 5; i++)
                {
                    if (i >= 0 && i < 160 && j >= 0 && j < 160)
                    {
                        double guyX = (guyRect.X + 8 - left) * (guyRect.X + 8 - left);
                        double guyY = (guyRect.Y + 8 - top) * (guyRect.Y + 8 - top);
                        guyDist = (guyX + guyY);
                        guyDist = Math.Sqrt(guyDist);

                        if (guyDist < 110)
                        {
                            int alpha = 0;
                            if (guyDist <= 40)
                            {
                                alpha = 1;
                            }
                            else if (guyDist > 40)
                            {
                                alpha = (int)((guyDist - 39) * 2.5);
                            }
                            if (shadeArray[j, i] != 0)
                            {
                                int lighterShade = Math.Min(alpha, shadeArray[j, i]);
                                lighterShade -= (int)(lighterShade * .05);
                                if (lighterShade <= 0)
                                    lighterShade = 1;
                                if (lighterShade > 175)
                                    lighterShade = 175;
                                shadeArray[j, i] = lighterShade;
                            }
                            else
                            {
                                if (alpha > 175)
                                    alpha = 175;
                                shadeArray[j, i] = alpha;
                            }
                        }
                    }
                    left += 5;
                }
                top += 5;
                left = guyRect.X - 150;
            }

            //Fill array
            for (int j = 0; j < 160; j++)
            {
                for (int i = 0; i < 160; i++)
                {
                    int alpha = shadeArray[j, i];
                    if (alpha == 0)
                        alpha = 175;
                    brush.Color = Color.FromArgb(alpha, 0, 0, 0);
                    g.FillRectangle(brush, j * 5, i * 5, 5, 5);
                }
            }
            List<Object> lst = new List<Object>();
            lst.Add(shadeArray);
            lst.Add(lstOfTurrets);
            lst.Add(lstOfFlares);
            return lst;
        }
    }
}
