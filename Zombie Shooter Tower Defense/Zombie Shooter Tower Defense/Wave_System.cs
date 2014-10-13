using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zombie_Shooter_Tower_Defense
{
    class Wave_System
    {
        int currentWave = 1;

        int bugsToSendOut = 0;
        int pacmansToSendOut = 0;
        int trogdorsToSendOut = 0;
        int unicornsToSendOut = 0;
        int plantsToSendOut = 0;

        decimal bugsThisWave = -3;
        decimal pacmansThisWave = -5;
        decimal trogdorsThisWave = -12;
        decimal unicornsThisWave = -10;
        decimal plantsThisWave = 3;

        int[] enemyCounts = new int[5];
        string[] enemyTypes = new string[5];

        public void Reset()
        {
            currentWave = 1;

            bugsToSendOut = 0;
            pacmansToSendOut = 0;
            trogdorsToSendOut = 0;
            unicornsToSendOut = 0;
            plantsToSendOut = 0;

            bugsThisWave = -3;
            pacmansThisWave = -5;
            trogdorsThisWave = -12;
            unicornsThisWave = -10;
            plantsThisWave = 3;

            bugsToSendOut = (int)bugsThisWave;
            pacmansToSendOut = (int)pacmansThisWave;
            trogdorsToSendOut = (int)trogdorsThisWave;
            unicornsToSendOut = (int)unicornsThisWave;
            plantsToSendOut = (int)plantsThisWave;

            enemyCounts[0] = bugsToSendOut;
            enemyCounts[1] = pacmansToSendOut;
            enemyCounts[2] = trogdorsToSendOut;
            enemyCounts[3] = unicornsToSendOut;
            enemyCounts[4] = plantsToSendOut;

            enemyTypes[0] = "bug";
            enemyTypes[1] = "pacman";
            enemyTypes[2] = "trogdor";
            enemyTypes[3] = "unicorn";
            enemyTypes[4] = "plant";
        }

        public Wave_System()
        {
            bugsToSendOut = (int)bugsThisWave;
            pacmansToSendOut = (int)pacmansThisWave;
            trogdorsToSendOut = (int)trogdorsThisWave;
            unicornsToSendOut = (int)unicornsThisWave;
            plantsToSendOut = (int)plantsThisWave;

            enemyCounts[0] = bugsToSendOut;
            enemyCounts[1] = pacmansToSendOut;
            enemyCounts[2] = trogdorsToSendOut;
            enemyCounts[3] = unicornsToSendOut;
            enemyCounts[4] = plantsToSendOut;

            enemyTypes[0] = "bug";
            enemyTypes[1] = "pacman";
            enemyTypes[2] = "trogdor";
            enemyTypes[3] = "unicorn";
            enemyTypes[4] = "plant";
        }

        public string GetNextEnemyToSendOut()
        {
            bool enemyLeft = false;
            foreach (int x in enemyCounts)
            {
                if (x > 0)
                {
                    enemyLeft = true;
                }
            }

            int enemyCountToUse = 0;
            int index = 0;
            if (enemyLeft)
            {
                do
                {
                    index = new Random().Next(0, 5);
                    enemyCountToUse = enemyCounts[index];

                } while (enemyCountToUse <= 0);

                if (enemyTypes[index] == "pacman")
                {
                    pacmansToSendOut--;
                }
                else if (enemyTypes[index] == "bug")
                {
                    bugsToSendOut--;
                }
                else if (enemyTypes[index] == "trogdor")
                {
                    trogdorsToSendOut--;
                }
                else if (enemyTypes[index] == "unicorn")
                {
                    unicornsToSendOut--;
                }
                else if (enemyTypes[index] == "plant")
                {
                    plantsToSendOut--;
                }


                enemyCounts[0] = bugsToSendOut;
                enemyCounts[1] = pacmansToSendOut;
                enemyCounts[2] = trogdorsToSendOut;
                enemyCounts[3] = unicornsToSendOut;
                enemyCounts[4] = plantsToSendOut;

                return enemyTypes[index];
            }
            return "";
        }

        public bool EnemiesLeftToSend()
        {
            bool enemyLeft = false;
            foreach (int x in enemyCounts)
            {
                if (x > 0)
                {
                    enemyLeft = true;
                }
            }
            return enemyLeft;
        }

        public void AddWave()
        {
            currentWave++;
        }

        public void CalculateEnemiesForNextWave()
        {
            currentWave++;

            bugsThisWave++;
            pacmansThisWave++;
            trogdorsThisWave++;
            unicornsThisWave++;
            plantsThisWave++;

            bugsToSendOut = (int)bugsThisWave;
            pacmansToSendOut = (int)pacmansThisWave;
            trogdorsToSendOut = (int)trogdorsThisWave;
            unicornsToSendOut = (int)unicornsThisWave;
            plantsToSendOut = (int)plantsThisWave;

            enemyCounts[0] = bugsToSendOut;
            enemyCounts[1] = pacmansToSendOut;
            enemyCounts[2] = trogdorsToSendOut;
            enemyCounts[3] = unicornsToSendOut;
            enemyCounts[4] = plantsToSendOut;
        }

        public int CurrentWave()
        {
            return currentWave;
        }
    }
}
