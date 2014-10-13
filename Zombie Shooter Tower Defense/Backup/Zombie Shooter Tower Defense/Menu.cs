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
    class Menu
    {
        Panel pnlMain = new Panel();
        Label lblContinue = new Label();
        Label lblHelpText = new Label();
        Panel pnlHelp = new Panel();
        Label lblCloseHelp = new Label();
        Label lblHelp = new Label();
        Label lblExit = new Label();
        Label lblCredits = new Label();
        Label lblCreditsText = new Label();
        Panel pnlCredits = new Panel();
        Label creditsTitle = new Label();
        Label helpTitle = new Label();
        Label lblReset = new Label();

        public Label GetRestartLabel()
        {
            return lblReset;
        }

        public Menu()
        {
            Font captureFont = new Font("Times New Roman", 12);
            try
            {
                System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
                pfc.AddFontFile(Application.StartupPath + "\\Capture it.ttf");
                captureFont = new Font(pfc.Families[0], 16f, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch { }

            pnlMain.Size = new Size(200, 450);
            pnlMain.Location = new Point(30, 70);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;

            pnlMain.Controls.Add(lblContinue);
            pnlMain.Controls.Add(lblHelp);
            pnlMain.Controls.Add(lblCredits);
            pnlMain.Controls.Add(lblExit);
            pnlMain.Controls.Add(lblReset);

            lblContinue.AutoSize = true;
            lblContinue.Font = new Font("Courier New", 14);
            lblContinue.Location = new Point(20, 30);
            lblContinue.Text = "Start Game";
            lblContinue.Click += new EventHandler(lblContinue_Click);

            lblHelp.AutoSize = true;
            lblHelp.Font = new Font("Courier New", 14);
            lblHelp.Location = new Point(20, 80);
            lblHelp.Text = "Controls/Help";
            lblHelp.Click += new EventHandler(lblHelp_Click);

            lblCredits.AutoSize = true;
            lblCredits.Font = new Font("Courier New", 14);
            lblCredits.Location = new Point(20, 130);
            lblCredits.Text = "Credits";
            lblCredits.Click += new EventHandler(lblCredits_Click);

            lblReset.AutoSize = true;
            lblReset.Text = "New Game";
            lblReset.Location = new Point(20, 180);
            lblReset.Font = new Font("Courier New", 14);

            lblExit.Text = "Exit";
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Courier New", 14);
            lblExit.Location = new Point(20, 400);
            lblExit.Click += new EventHandler(lblExit_Click);

            pnlCredits.Visible = false;
            pnlCredits.Size = new Size(650, 600);
            pnlCredits.Location = new Point(70, 50);
            pnlCredits.BorderStyle = BorderStyle.FixedSingle;
            pnlCredits.Controls.Add(lblCreditsText);
            pnlCredits.Controls.Add(lblCloseHelp);

            pnlHelp.Size = new Size(650, 600);
            pnlHelp.Location = new Point(70, 50);
            pnlHelp.BorderStyle = BorderStyle.FixedSingle;
            pnlHelp.Controls.Add(lblHelpText);
            pnlHelp.Controls.Add(lblCloseHelp);
            pnlHelp.Visible = false;

            lblCloseHelp.Text = "X";
            lblCloseHelp.BorderStyle = BorderStyle.FixedSingle;
            lblCloseHelp.AutoSize = true;
            lblCloseHelp.Font = new Font("Courier New", 14, FontStyle.Bold);
            lblCloseHelp.Location = new Point(618, 5);
            lblCloseHelp.Click += new EventHandler(lblCloseHelp_Click);

            creditsTitle.AutoSize = true;
            creditsTitle.Location = new Point(280, 15);
            creditsTitle.Font = captureFont;
            creditsTitle.Text = "Credits";
            pnlCredits.Controls.Add(creditsTitle);

            pnlHelp.Controls.Add(helpTitle);
            helpTitle.AutoSize = true;
            helpTitle.Location = new Point(250, 15);
            helpTitle.Text = "Help/Controls";
            helpTitle.Font = captureFont;

            lblCreditsText.Size = new Size(650, 600);
            lblCreditsText.Font = new Font("Courier New", 10);
            lblCreditsText.Location = new Point(0, 60);
            lblCreditsText.TextAlign = ContentAlignment.TopCenter;
            lblCreditsText.Text = "Some Tower Defense Shooter\n\n\n"
                + "Programming/Design\n"
                + "-----------------------\n"
                + "Joey Gelpi\n"
                + "\n\n"
                + "Graphics\n"
                + "-----------------------\n"
                + "Joey Gelpi\n"
                + "Schwanke Stallion\n"
                + "Grimmjawe\n"
                + "Connor Wilczek\n"
                + "Chris Rogers\n"
                + "\n\n"
                + "Emotional Support\n"
                + "-----------------------\n"
                + "Cody Turner\n"
                + "\n\n"
                + "Kinda Important People\n"
                + "-----------------------\n"
                + "Conner and Connor\n"
                + "Greatness\n"
                + "\n\n"
                + "Special Thanks\n"
                + "-----------------------\n"
                + "G.\n";



            lblHelpText.AutoSize = true;
            lblHelpText.Font = new Font("Courier New", 10);
            lblHelpText.Location = new Point(10, 60);
            lblHelpText.Text = "The objective of the game is to survive as many waves as possible by shooting\n enemies and placing turrets.\n"
                + "You only gain money by kiling enemies yourself, turret kills give you no money.\n"
                + "You unlock weapons as the game progresses.\n"
                + "Health packs and flare boxes will spawn in the corners of the map.\n"
                + "\n"
                + "Controls\n"
                + "--------\n"
                + "Mouse -------- Aim\n"
                + "Left Mouse --- Shoot\n"
                + "             - Place Turret\n"
                + "Right Mouse -- Select Placed Turret\n"
                + "             - Cancel Placing Turret\n"
                + "WASD --------- Move\n"
                + "Escape ------- Menu\n"
                + "F ------------ Flare\n"
                + "\n"
                + "Weapons\n"
                + "-------\n"
                + "1 - Pistol\n"
                + "2 - SMG\n"
                + "3 - Shotgun\n"
                + "4 - Sniper\n"
                + "5 - Minigun\n"
                + "Q/E - Cycle Weapons\n"
                + "Mouse Wheel - Cycle Weapons\n";

        }

        public void ResetText()
        {
            lblContinue.Text = "Start Game";
        }

        void lblCredits_Click(object sender, EventArgs e)
        {
            pnlCredits.Visible = true;
            pnlCredits.BringToFront();
            pnlCredits.Controls.Add(lblCloseHelp);
        }

        void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure you want to quit?", "Some Tower Defense Shooter", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        void lblCloseHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = false;
            pnlCredits.Visible = false;
        }

        void lblHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = true;
            pnlHelp.BringToFront();
            pnlHelp.Controls.Add(lblCloseHelp);
        }

        void lblContinue_Click(object sender, EventArgs e)
        {
            lblContinue.Text = "Continue";
            pnlMain.Visible = false;
            pnlHelp.Visible = false;
            pnlCredits.Visible = false;
        }

        public void ShowHideMenu()
        {
            pnlMain.Visible = !pnlMain.Visible;
        }

        public Label GetContinueLabel()
        {
            return lblContinue;
        }

        public Panel GetCreditsPanel()
        {
            return pnlCredits;
        }

        public Panel GetMenu()
        {
            return pnlMain;
        }

        public Panel GetHelp()
        {
            return pnlHelp;
        }
    }
}
