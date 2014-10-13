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
    //Bold italics arial
    class HUD
    {
        Panel pnlMain = new Panel();
        PictureBox picRedKey = new PictureBox();
        PictureBox picBlueKey = new PictureBox();
        PictureBox picGreenKey = new PictureBox();
        PictureBox picYellowKey = new PictureBox();

        PictureBox picFlippers = new PictureBox();
        PictureBox picSuction = new PictureBox();
        PictureBox picIceSkates = new PictureBox();
        PictureBox picFireBoots = new PictureBox();

        PictureBox picTime1 = new PictureBox();
        PictureBox picTime2 = new PictureBox();
        PictureBox picTime3 = new PictureBox();

        PictureBox picChips1 = new PictureBox();
        PictureBox picChips2 = new PictureBox();
        PictureBox picChips3 = new PictureBox();

        PictureBox picLevel1 = new PictureBox();
        PictureBox picLevel2 = new PictureBox();
        PictureBox picLevel3 = new PictureBox();

        Label lblHelp = new Label();

        public HUD()
        {
            pnlMain.Controls.Add(picRedKey);
            pnlMain.Controls.Add(picBlueKey);
            pnlMain.Controls.Add(picGreenKey);
            pnlMain.Controls.Add(picYellowKey);
            pnlMain.Controls.Add(picFireBoots);
            pnlMain.Controls.Add(picSuction);
            pnlMain.Controls.Add(picFlippers);
            pnlMain.Controls.Add(picIceSkates);
            pnlMain.Controls.Add(picTime1);
            pnlMain.Controls.Add(picTime2);
            pnlMain.Controls.Add(picTime3);
            pnlMain.Controls.Add(picLevel1);
            pnlMain.Controls.Add(picLevel2);
            pnlMain.Controls.Add(picLevel3);
            pnlMain.Controls.Add(picChips1);
            pnlMain.Controls.Add(picChips2);
            pnlMain.Controls.Add(picChips3);
            pnlMain.Controls.Add(lblHelp);

            lblHelp.BackColor = Color.Black;
            lblHelp.Left = 17;
            lblHelp.Top = 143;
            lblHelp.Width = 120;
            lblHelp.Height = 138;
            lblHelp.AutoSize = false;
            lblHelp.BringToFront();
            lblHelp.Visible = false;
            lblHelp.Font = new Font("Arial", 12, FontStyle.Bold);
            lblHelp.TextAlign = ContentAlignment.TopCenter;
            lblHelp.ForeColor = Color.FromArgb(0, 255, 255);

            picChips3.Size = new Size(13, 23);
            picChips3.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picChips3.Location = new Point(49, 189);

            picChips2.Size = new Size(13, 23);
            picChips2.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picChips2.Location = new Point(66, 189);

            picChips1.Size = new Size(13, 23);
            picChips1.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picChips1.Location = new Point(83, 189);

            picLevel3.Size = new Size(13, 23);
            picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picLevel3.Location = new Point(49, 37);

            picLevel2.Size = new Size(13, 23);
            picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picLevel2.Location = new Point(66, 37);

            picLevel1.Size = new Size(13, 23);
            picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picLevel1.Location = new Point(83, 37);

            picTime3.Size = new Size(13, 23);
            picTime3.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picTime3.Location = new Point(49, 99);

            picTime2.Size = new Size(13, 23);
            picTime2.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picTime2.Location = new Point(66, 99);

            picTime1.Size = new Size(13, 23);
            picTime1.Image = Chips_Challenge.Properties.Resources.Tmr0;
            picTime1.Location = new Point(83, 99);

            pnlMain.Size = new Size(154, 300);
            pnlMain.Location = new Point(417, 90);
            pnlMain.BackgroundImage = Chips_Challenge.Properties.Resources.HUD;

            picRedKey.Image = Chips_Challenge.Properties.Resources.KeyRed;
            picRedKey.Size = new Size(32, 32);
            picRedKey.Location = new Point(13, 221);
            picRedKey.Visible = false;

            picBlueKey.Image = Chips_Challenge.Properties.Resources.KeyBlue;
            picBlueKey.Size = new Size(32, 32);
            picBlueKey.Location = new Point(45, 221);
            picBlueKey.Visible = false;

            picGreenKey.Image = Chips_Challenge.Properties.Resources.KeyGreen;
            picGreenKey.Size = new Size(32, 32);
            picGreenKey.Location = new Point(77, 221);
            picGreenKey.Visible = false;

            picYellowKey.Image = Chips_Challenge.Properties.Resources.KeyYellow;
            picYellowKey.Size = new Size(32, 32);
            picYellowKey.Location = new Point(109, 221);
            picYellowKey.Visible = false;

            picFireBoots.Image = Chips_Challenge.Properties.Resources.FireBoot;
            picFireBoots.Size = new Size(32, 32);
            picFireBoots.Location = new Point(13, 253);
            picFireBoots.Visible = false;

            picIceSkates.Image = Chips_Challenge.Properties.Resources.IceSkate;
            picIceSkates.Size = new Size(32, 32);
            picIceSkates.Location = new Point(45, 253);
            picIceSkates.Visible = false;

            picFlippers.Image = Chips_Challenge.Properties.Resources.Flipper;
            picFlippers.Size = new Size(32, 32);
            picFlippers.Location = new Point(77, 253);
            picFlippers.Visible = false;

            picSuction.Image = Chips_Challenge.Properties.Resources.SuctionBoots;
            picSuction.Size = new Size(32, 32);
            picSuction.Location = new Point(109, 253);
            picSuction.Visible = false;
        }

        public void UpdateChips(int chips)
        {
            if (chips == 0)
            {
                picChips1.Image = Chips_Challenge.Properties.Resources.TmrYellow;
                picChips2.Image = Chips_Challenge.Properties.Resources.TmrYellow;
                picChips3.Image = Chips_Challenge.Properties.Resources.TmrYellow;
            }

            if (chips != 0)
            {
                string x = Convert.ToString(chips);
                if (x.Length == 1)
                {
                    picChips2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    picChips3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    if (x == "0")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x == "1")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x == "2")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x == "3")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x == "4")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x == "5")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x == "6")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x == "7")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x == "8")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x == "9")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr9;
                }
                else if (x.Length == 2)
                {
                    picChips3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    if (x.Substring(1, 1) == "0")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x.Substring(1, 1) == "1")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x.Substring(1, 1) == "2")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x.Substring(1, 1) == "3")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x.Substring(1, 1) == "4")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x.Substring(1, 1) == "5")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x.Substring(1, 1) == "6")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x.Substring(1, 1) == "7")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x.Substring(1, 1) == "8")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x.Substring(1, 1) == "9")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                    if (x.Substring(0, 1) == "0")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x.Substring(0, 1) == "1")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x.Substring(0, 1) == "2")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x.Substring(0, 1) == "3")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x.Substring(0, 1) == "4")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x.Substring(0, 1) == "5")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x.Substring(0, 1) == "6")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x.Substring(0, 1) == "7")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x.Substring(0, 1) == "8")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x.Substring(0, 1) == "9")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr9;
                }
                else if (x.Length == 3)
                {
                    if (x.Substring(2, 1) == "0")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x.Substring(2, 1) == "1")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x.Substring(2, 1) == "2")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x.Substring(2, 1) == "3")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x.Substring(2, 1) == "4")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x.Substring(2, 1) == "5")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x.Substring(2, 1) == "6")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x.Substring(2, 1) == "7")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x.Substring(2, 1) == "8")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x.Substring(2, 1) == "9")
                        picChips1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                    if (x.Substring(1, 1) == "0")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x.Substring(1, 1) == "1")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x.Substring(1, 1) == "2")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x.Substring(1, 1) == "3")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x.Substring(1, 1) == "4")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x.Substring(1, 1) == "5")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x.Substring(1, 1) == "6")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x.Substring(1, 1) == "7")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x.Substring(1, 1) == "8")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x.Substring(1, 1) == "9")
                        picChips2.Image = Chips_Challenge.Properties.Resources.Tmr9;

                    if (x.Substring(0, 1) == "0")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                    else if (x.Substring(0, 1) == "1")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr1;
                    else if (x.Substring(0, 1) == "2")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr2;
                    else if (x.Substring(0, 1) == "3")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr3;
                    else if (x.Substring(0, 1) == "4")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr4;
                    else if (x.Substring(0, 1) == "5")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr5;
                    else if (x.Substring(0, 1) == "6")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr6;
                    else if (x.Substring(0, 1) == "7")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr7;
                    else if (x.Substring(0, 1) == "8")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr8;
                    else if (x.Substring(0, 1) == "9")
                        picChips3.Image = Chips_Challenge.Properties.Resources.Tmr9;
                }
            }

        }

        public void SetLevel(int level)
        {
            string x = Convert.ToString(level);
            if (x.Length == 1)
            {
                picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                if (x == "0")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x == "1")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x == "2")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x == "3")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x == "4")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x == "5")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x == "6")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x == "7")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x == "8")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x == "9")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }
            else if (x.Length == 2)
            {
                picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                if (x.Substring(1, 1) == "0")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(1, 1) == "1")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(1, 1) == "2")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(1, 1) == "3")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(1, 1) == "4")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(1, 1) == "5")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(1, 1) == "6")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(1, 1) == "7")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(1, 1) == "8")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(1, 1) == "9")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(0, 1) == "0")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(0, 1) == "1")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(0, 1) == "2")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(0, 1) == "3")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(0, 1) == "4")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(0, 1) == "5")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(0, 1) == "6")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(0, 1) == "7")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(0, 1) == "8")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(0, 1) == "9")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }
            else if (x.Length == 3)
            {
                if (x.Substring(2, 1) == "0")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(2, 1) == "1")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(2, 1) == "2")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(2, 1) == "3")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(2, 1) == "4")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(2, 1) == "5")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(2, 1) == "6")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(2, 1) == "7")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(2, 1) == "8")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(2, 1) == "9")
                    picLevel1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(1, 1) == "0")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(1, 1) == "1")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(1, 1) == "2")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(1, 1) == "3")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(1, 1) == "4")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(1, 1) == "5")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(1, 1) == "6")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(1, 1) == "7")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(1, 1) == "8")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(1, 1) == "9")
                    picLevel2.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(0, 1) == "0")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(0, 1) == "1")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(0, 1) == "2")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(0, 1) == "3")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(0, 1) == "4")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(0, 1) == "5")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(0, 1) == "6")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(0, 1) == "7")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(0, 1) == "8")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(0, 1) == "9")
                    picLevel3.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }

        }

        public void UpdateTime(int time)
        {
            string x = Convert.ToString(time);
            if (x.Length == 1)
            {
                picTime2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                picTime3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                if (x == "0")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x == "1")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x == "2")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x == "3")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x == "4")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x == "5")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x == "6")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x == "7")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x == "8")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x == "9")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }

            else if (x.Length == 2)
            {
                picTime3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                if (x.Substring(1, 1) == "0")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(1, 1) == "1")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(1, 1) == "2")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(1, 1) == "3")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(1, 1) == "4")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(1, 1) == "5")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(1, 1) == "6")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(1, 1) == "7")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(1, 1) == "8")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(1, 1) == "9")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(0, 1) == "0")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(0, 1) == "1")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(0, 1) == "2")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(0, 1) == "3")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(0, 1) == "4")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(0, 1) == "5")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(0, 1) == "6")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(0, 1) == "7")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(0, 1) == "8")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(0, 1) == "9")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }
            else if (x.Length == 3)
            {
                if (x.Substring(2, 1) == "0")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(2, 1) == "1")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(2, 1) == "2")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(2, 1) == "3")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(2, 1) == "4")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(2, 1) == "5")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(2, 1) == "6")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(2, 1) == "7")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(2, 1) == "8")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(2, 1) == "9")
                    picTime1.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(1, 1) == "0")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(1, 1) == "1")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(1, 1) == "2")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(1, 1) == "3")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(1, 1) == "4")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(1, 1) == "5")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(1, 1) == "6")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(1, 1) == "7")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(1, 1) == "8")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(1, 1) == "9")
                    picTime2.Image = Chips_Challenge.Properties.Resources.Tmr9;

                if (x.Substring(0, 1) == "0")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr0;
                else if (x.Substring(0, 1) == "1")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr1;
                else if (x.Substring(0, 1) == "2")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr2;
                else if (x.Substring(0, 1) == "3")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr3;
                else if (x.Substring(0, 1) == "4")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr4;
                else if (x.Substring(0, 1) == "5")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr5;
                else if (x.Substring(0, 1) == "6")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr6;
                else if (x.Substring(0, 1) == "7")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr7;
                else if (x.Substring(0, 1) == "8")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr8;
                else if (x.Substring(0, 1) == "9")
                    picTime3.Image = Chips_Challenge.Properties.Resources.Tmr9;
            }
        }

        public void HideShowPics(int redKeys, int blueKeys, int greenKeys, int yellowKeys, bool fireBoots, bool flippers, bool suctionBoots, bool IceSkates)
        {
            if (redKeys != 0)
                picRedKey.Visible = true;
            else
                picRedKey.Visible = false;
            //
            if (blueKeys != 0)
                picBlueKey.Visible = true;
            else
                picBlueKey.Visible = false;
            //
            if (yellowKeys != 0)
                picYellowKey.Visible = true;
            else
                picYellowKey.Visible = false;
            //
            if (greenKeys != 0)
                picGreenKey.Visible = true;
            else
                picGreenKey.Visible = false;

            if (fireBoots)
                picFireBoots.Visible = true;
            else
                picFireBoots.Visible = false;

            if (flippers)
                picFlippers.Visible = true;
            else
                picFlippers.Visible = false;

            if (suctionBoots)
                picSuction.Visible = true;
            else
                picSuction.Visible = false;

            if (IceSkates)
                picIceSkates.Visible = true;
            else
                picIceSkates.Visible = false;

        }

        public void ShowHelp(string x)
        {
            pnlMain.BackgroundImage = Chips_Challenge.Properties.Resources.Hud_Help;
            lblHelp.Visible = true;
            lblHelp.Text = x;
            lblHelp.BringToFront();
            picFlippers.Visible = false;
            picFireBoots.Visible = false;
            picIceSkates.Visible = false;
            picSuction.Visible = false;
            picGreenKey.Visible = false;
            picRedKey.Visible = false;
            picYellowKey.Visible = false;
            picBlueKey.Visible = false;
        }

        public void HideHelp()
        {
            pnlMain.BackgroundImage = Chips_Challenge.Properties.Resources.HUD;
            lblHelp.Visible = false;
        }

        public Panel GetPanel()
        {
            return pnlMain;
        }

    }
}
