using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Chips_Challenge
{
    public partial class Form1 : Form
    {
        #region Variables
        string[,] board = new string[100, 100];
        List<Tile> lstTiles = new List<Tile>();
        List<Teeth> lstMonsters = new List<Teeth>();
        List<Ball> lstOfBalls = new List<Ball>();
        List<Fireball> lstOfFireballs = new List<Fireball>();
        List<Blob> lstOfBlobs = new List<Blob>();
        List<Walker> lstOfWalkers = new List<Walker>();
        string[] levels = new string[50];
        string[] levelHelp = new string[50];
        string[] levelNames = new string[50];
        string[] levelCodes = new string[50];
        Graphics g;
        Timer tmrMain = new Timer();
        Guy guy = new Guy();
        Label lblLoading = new Label();
        Panel pnlLevelIntro = new Panel();
        Label lblPassword = new Label();
        Label lblLevel = new Label();
        LevelSelector levelSelector1 = new LevelSelector();
        Label lblPaused = new Label();
        HUD hud = new HUD();
        Random random = new Random();
        int turnCounter = 0;
        int currentLevel = 1;
        int chipsNeeded = 0;
        int levelTime = 0;
        int teethMoveCounter = 0;
        int ballMoveCounter = 0;
        int timerCounter2Tick = 0;
        int secondCounter = 0;
        int blobMoveCounter = 0;
        bool won = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
            Width = 605;
            Height = 471;
            BackgroundImage = Chips_Challenge.Properties.Resources.backgroundNew;
            BackgroundImageLayout = ImageLayout.None;
            BackColor = Color.Green;
            Text = "Chips Challenge";
            Paint += new PaintEventHandler(Form1_Paint);
            tmrMain.Tick += new EventHandler(tmrMain_Tick);
            tmrMain.Interval = 50;
            DoubleBuffered = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            Controls.Add(hud.GetPanel());
            levels[1] = Chips_Challenge.Properties.Resources.Level_1;
            levels[2] = Chips_Challenge.Properties.Resources.Level_2;
            levels[3] = Chips_Challenge.Properties.Resources.Level_3;
            levels[4] = Chips_Challenge.Properties.Resources.Level_4;
            levels[5] = Chips_Challenge.Properties.Resources.Level_5;
            levels[6] = Chips_Challenge.Properties.Resources.Level_6;
            levels[7] = Chips_Challenge.Properties.Resources.Level_7;
            levels[8] = Chips_Challenge.Properties.Resources.Level_8;
            levels[9] = Chips_Challenge.Properties.Resources.Level_9;
            levels[10] = Chips_Challenge.Properties.Resources.Level_10;
            levels[11] = Chips_Challenge.Properties.Resources.Level_11;
            levels[12] = Chips_Challenge.Properties.Resources.Level_12;
            levels[13] = Chips_Challenge.Properties.Resources.Level_13;
            levelCodes[1] = "LVL1";
            levelCodes[2] = "QWER";
            levelCodes[3] = "ABCE";
            levelCodes[4] = "FREG";
            levelCodes[5] = "WATR";
            levelCodes[6] = "PIHC";
            levelCodes[7] = "LOLZ";
            levelCodes[8] = "YGQT";
            levelCodes[9] = "FHUT";
            levelCodes[10] = "SHJY";
            levelCodes[11] = "OTQN";
            levelCodes[12] = "PGKS";
            levelCodes[13] = "XDUG";
            levelHelp[1] = "Pick up chips to get through the chip socket. Boots help you walk on fire, water, and ice.";
            levelHelp[2] = "Pick up the green boots to walk on force floors. Green buttons toggle green walls and floors.";
            levelHelp[3] = "Push dirt into water and walk on it to push it down.";
            levelHelp[9] = "Some walls are invisible until you run into them.";
            levelHelp[10] = "Use dirt to destroy bombs. Also it's number 6. Oh yea, number, 6. 6. Down.";
            levelHelp[12] = "A thief will take all your boots.";
            levelHelp[13] = "It's actually the north pole.";
            levelNames[1] = "Lesson 1";
            levelNames[2] = "Lesson 2";
            levelNames[3] = "Lesson 3";
            levelNames[4] = "Lesson 4";
            levelNames[5] = "It's Like Ice";
            levelNames[6] = "CHIPS";
            levelNames[7] = "This Sucks";
            levelNames[8] = "Dirts";
            levelNames[9] = "I'm a Magician";
            levelNames[10] = "It's Number 6";
            levelNames[11] = "BlobSsSSs";
            levelNames[12] = "Level Name Here";
            levelNames[13] = "Southpole";
            Controls.Add(levelSelector1.GetPanel());
            levelSelector1.GetButton().Click += new EventHandler(btnLevelSelect_Click);
            levelSelector1.GetTxt().KeyDown += new KeyEventHandler(txtInput_KeyDown);
            LoadLevel("");
            Cursor = Cursors.Cross;            

            #region Labels and panels
            lblPaused.Font = new Font("Courier New", 12, FontStyle.Bold);
            lblPaused.Text = "Paused.";
            lblPaused.Left = 170;
            lblPaused.Top = 265;
            lblPaused.Visible = false;
            lblPaused.AutoSize = true;
            lblPaused.BackColor = Color.Transparent;
            Controls.Add(lblPaused);

            lblLoading.Text = "Loading...";
            lblLoading.AutoSize = true;
            lblLoading.Left = 170;
            lblLoading.Top = 265;
            lblLoading.Visible = false;
            lblLoading.BackColor = Color.FromArgb(192, 192, 192);
            lblLoading.Font = new Font("Courier New", 12, FontStyle.Bold);
            lblLoading.BackColor = Color.Transparent;
            Controls.Add(lblLoading);

            pnlLevelIntro.Size = Chips_Challenge.Properties.Resources.LevelIntro.Size;
            pnlLevelIntro.BackgroundImage = Chips_Challenge.Properties.Resources.LevelIntro;
            pnlLevelIntro.Location = new Point(115, 300);
            Controls.Add(pnlLevelIntro);

            lblPassword.Font = new Font("Arial", 13, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(255, 255, 0);
            lblPassword.AutoSize = true;
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            lblPassword.Text = "Password: " + levelCodes[currentLevel];
            lblPassword.BackColor = Color.Black;
            pnlLevelIntro.Controls.Add(lblPassword);
            lblPassword.Left = (pnlLevelIntro.Width / 2) - (lblPassword.Width / 2);
            lblPassword.Top = 28;


            lblLevel.Font = new Font("Arial", 13, FontStyle.Bold);
            lblLevel.ForeColor = Color.FromArgb(255, 255, 0);
            lblLevel.AutoSize = true;
            lblLevel.Text = levelNames[currentLevel];
            lblLevel.BackColor = Color.Black;
            pnlLevelIntro.Controls.Add(lblLevel);
            lblLevel.Left = (pnlLevelIntro.Width / 2) - (lblLevel.Width / 2);
            lblLevel.Top = 7;
            #endregion
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string x = levelSelector1.LevelCode().ToUpper();
                int index = -1;
                bool match = false;
                foreach (string y in levelCodes)
                {
                    index++;
                    if (y == x)
                    {
                        match = true;
                        levelSelector1.SetVisibility(false);
                        levelSelector1.SetEnabled(false);
                        currentLevel = index;
                        LoadLevel("");
                        break;
                    }
                }
                if (!match)
                {
                    MessageBox.Show("Not a valid level code.", "Chips Challenge");
                }
            }
        }

        private void btnLevelSelect_Click(object sender, EventArgs e)
        {
            string x = levelSelector1.LevelCode().ToUpper();
            int index = -1;
            bool match = false;
            foreach (string y in levelCodes)
            {
                index++;
                if (y == x)
                {
                    match = true;
                    levelSelector1.SetVisibility(false);
                    levelSelector1.SetEnabled(false);
                    currentLevel = index;
                    LoadLevel("");
                    break;
                }
            }
            if (!match)
            {
                MessageBox.Show("Not a valid level code.", "Chips Challenge");
            }
        }

        public void Reset()
        {
            won = false;
            pnlLevelIntro.Visible = true;
            lblLevel.Text = levelNames[currentLevel];
            lblLevel.Left = (pnlLevelIntro.Width / 2) - (lblLevel.Width / 2);

            lblPassword.Text = "Password: " + levelCodes[currentLevel];
            lblPassword.Left = (pnlLevelIntro.Width / 2) - (lblPassword.Width / 2);
            tmrMain.Enabled = true;
            guy.Reset();
            hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            turnCounter = 0;
            chipsNeeded = 0;
            lstTiles.Clear();
            lstMonsters.Clear();
            lstOfBalls.Clear();
            lstOfFireballs.Clear();
            lstOfBlobs.Clear();
            lstOfWalkers.Clear();
            for (int i = 0; i < 100; i++)
            {
                for (int k = 0; k < 100; k++)
                {
                    board[i, k] = null;
                }
            }
        }

        public bool CantMove(string x)
        {
            if (x == "R")
            {
                if (board[guy.ArrayX() + 1, guy.ArrayY()] == "WW-" || board[guy.ArrayX() + 1, guy.ArrayY()] == "TW-" || board[guy.ArrayX() + 1, guy.ArrayY()] == "IW-")
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DR-" && guy.NumRedKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DG-" && guy.NumGreenKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DY-" && guy.NumYellowKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DB-" && guy.NumBlueKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DO-" && chipsNeeded != 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "BR-")
                {
                    board[guy.ArrayX() + 1, guy.ArrayY()] = "WW-";
                    ChangeTilePic(guy.ArrayX() + 1, guy.ArrayY(), "WW-");
                    return true;
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "HW-")
                {
                    board[guy.ArrayX() + 1, guy.ArrayY()] = "WW-";
                    ChangeTilePic(guy.ArrayX() + 1, guy.ArrayY(), "WW-");
                    return true;
                }
                else if (board[guy.ArrayX() + 2, guy.ArrayY()] != "FL-" && (board[guy.ArrayX() + 1, guy.ArrayY()] == "DT-") && (board[guy.ArrayX() + 2, guy.ArrayY()] != "BO-"))
                {
                    if (board[guy.ArrayX() + 2, guy.ArrayY()] != "WA-")
                        return true;
                }
            }
            else if (x == "L")
            {
                if (board[guy.ArrayX() - 1, guy.ArrayY()] == "WW-" || board[guy.ArrayX() - 1, guy.ArrayY()] == "TW-" || board[guy.ArrayX() - 1, guy.ArrayY()] == "IW-")
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DR-" && guy.NumRedKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DG-" && guy.NumGreenKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DY-" && guy.NumYellowKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DB-" && guy.NumBlueKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DO-" && chipsNeeded != 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "BR-")
                {
                    board[guy.ArrayX() - 1, guy.ArrayY()] = "WW-";
                    ChangeTilePic(guy.ArrayX() - 1, guy.ArrayY(), "WW-");
                    return true;
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "HW-")
                {
                    board[guy.ArrayX() - 1, guy.ArrayY()] = "WW-";
                    ChangeTilePic(guy.ArrayX() - 1, guy.ArrayY(), "WW-");
                    return true;
                }
                else if (guy.ArrayX() > 1 && board[guy.ArrayX() - 2, guy.ArrayY()] != "FL-" && (board[guy.ArrayX() - 1, guy.ArrayY()] == "DT-") && (board[guy.ArrayX() - 2, guy.ArrayY()] != "BO-"))
                {
                    if (board[guy.ArrayX() - 2, guy.ArrayY()] != "WA-")
                        return true;
                }
            }
            else if (x == "U")
            {
                if (board[guy.ArrayX(), guy.ArrayY() - 1] == "WW-" || board[guy.ArrayX(), guy.ArrayY() - 1] == "TW-" || board[guy.ArrayX(), guy.ArrayY() - 1] == "IW-")
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DR-" && guy.NumRedKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DG-" && guy.NumGreenKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DY-" && guy.NumYellowKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DB-" && guy.NumBlueKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DO-" && chipsNeeded != 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "BR-")
                {
                    board[guy.ArrayX(), guy.ArrayY() - 1] = "WW-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 1, "WW-");
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "HW-")
                {
                    board[guy.ArrayX(), guy.ArrayY() - 1] = "WW-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 1, "WW-");
                    return true;
                }
                else if (guy.ArrayY() >= 2 && board[guy.ArrayX(), guy.ArrayY() - 2] != "FL-" && (board[guy.ArrayX(), guy.ArrayY() - 1] == "DT-") && (board[guy.ArrayX(), guy.ArrayY() - 2] != "BO-"))
                {
                    if (board[guy.ArrayX(), guy.ArrayY() - 2] != "WA-")
                        return true;
                }
            }
            else if (x == "D")
            {
                if (board[guy.ArrayX(), guy.ArrayY() + 1] == "WW-" || board[guy.ArrayX(), guy.ArrayY() + 1] == "TW-" || board[guy.ArrayX(), guy.ArrayY() + 1] == "IW-")
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DR-" && guy.NumRedKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DG-" && guy.NumGreenKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DY-" && guy.NumYellowKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DB-" && guy.NumBlueKeys() == 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DO-" && chipsNeeded != 0)
                {
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "BR-")
                {
                    board[guy.ArrayX(), guy.ArrayY() + 1] = "WW-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 1, "WW-");
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "HW-")
                {
                    board[guy.ArrayX(), guy.ArrayY() + 1] = "WW-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 1, "WW-");
                    return true;
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 2] != "FL-" && (board[guy.ArrayX(), guy.ArrayY() + 1] == "DT-") && (board[guy.ArrayX(), guy.ArrayY() + 2] != "BO-"))
                {
                    if (board[guy.ArrayX(), guy.ArrayY() + 2] != "WA-")
                        return true;
                }
            }
            return false;
        }

        public void ChangeTilePic(int x, int y, string type)
        {
            //Collected something, make it a floor piece
            foreach (Tile tile in lstTiles)
            {
                if (tile.ArrayX() == x && tile.ArrayY() == y)
                {
                    tile.SetPic(type);
                }
            }
        }

        public void ToggleTiles()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int k = 0; k < 50; k++)
                {
                    if (board[i, k] == "TW-")
                    {
                        board[i, k] = "TF-";
                        foreach (Tile tile in lstTiles)
                        {
                            if (tile.ArrayX() == i && tile.ArrayY() == k)
                            {
                                tile.SetPic("TF-");
                            }
                        }
                    }
                    else if (board[i, k] == "TF-")
                    {
                        board[i, k] = "TW-";
                        foreach (Tile tile in lstTiles)
                        {
                            if (tile.ArrayX() == i && tile.ArrayY() == k)
                            {
                                tile.SetPic("TW-");
                            }
                        }
                    }
                }
            }
        }

        public void StepOnTile() //Not walls
        {            
            hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            hud.HideHelp();
            //Called after he moved
            //Call guy.SteppedOnTile to do stuff
            if (board[guy.ArrayX(), guy.ArrayY()] == "FI-")
            {                
                guy.SteppedOnTile("FI-");
                if (!guy.Alive())
                {
                    MessageBox.Show("Chip needs fire boots to walk on fire!", "Game Over");
                    LoadLevel("");
                }
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "BO-")
            {
                guy.SteppedOnTile("BO-");
                if (!guy.Alive())
                {
                    MessageBox.Show("Ooops! Don't touch the bombs!", "Game Over");
                    LoadLevel("");
                }
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "WA-")
            {
                guy.SteppedOnTile("WA-");
                if (!guy.Alive())
                {
                    MessageBox.Show("Chip needs flippers to swim!", "Game Over");
                    LoadLevel("");
                }
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "RW-")
            {
                board[guy.ArrayX(), guy.ArrayY()] = "WW-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "WW-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "BF-")
            {
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "MU-")
            {
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
            }

            else if (board[guy.ArrayX(), guy.ArrayY()] == "HP-")
            {
                hud.ShowHelp(levelHelp[currentLevel]);
            }

            else if (board[guy.ArrayX(), guy.ArrayY()] == "TB-")
            {
                ToggleTiles();
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "TH-")
            {
                guy.SteppedOnTile("TH-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }

            #region Push tiles
            else if (board[guy.ArrayX(), guy.ArrayY()] == "PQ-")
            {
                string x = guy.SteppedOnTile("PQ-", random);
                if (x == "R")
                {
                    MoveEverything("R");
                }
                else if (x == "L")
                {
                    MoveEverything("L");
                }
                else if (x == "U")
                {
                    MoveEverything("U");
                }
                else if (x == "D")
                {
                    MoveEverything("D");
                }
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "PR-" && !guy.HasSuctionBoots())
            {
                guy.SteppedOnTile("PR-");
                MoveEverything("R");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "PU-" && !guy.HasSuctionBoots())
            {
                guy.SteppedOnTile("PU-");
                MoveEverything("U");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "PL-" && !guy.HasSuctionBoots())
            {
                guy.SteppedOnTile("PL-");
                MoveEverything("L");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "PD-" && !guy.HasSuctionBoots())
            {
                guy.SteppedOnTile("PD-");
                MoveEverything("D");
            }
            #endregion

            else if (board[guy.ArrayX(), guy.ArrayY()] == "WN-")
            {
                won = true;
                MessageBox.Show("Level Complete", "Chips Challenge");
                currentLevel++;
                LoadLevel("");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "IC-")
            {
                guy.SteppedOnTile("IC-");
            }

            #region Ice Turn Tiles
            else if (board[guy.ArrayX(), guy.ArrayY()] == "NW-")
            {
                guy.SteppedOnTile("NW-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "NE-")
            {
                guy.SteppedOnTile("NE-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "SE-")
            {
                guy.SteppedOnTile("SE-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "SW-")
            {
                guy.SteppedOnTile("SW-");
            }
            #endregion

            else if (board[guy.ArrayX(), guy.ArrayY()] == "CH-")
            {
                if (chipsNeeded > 0)
                    chipsNeeded--;
                hud.UpdateChips(chipsNeeded);
                guy.SteppedOnTile("");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "DO-")
            {
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
            }

            #region Keys
            else if (board[guy.ArrayX(), guy.ArrayY()] == "KB-")
            {
                guy.SteppedOnTile("KB-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "KY-")
            {
                guy.SteppedOnTile("KY-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "KG-")
            {
                guy.SteppedOnTile("KG-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "KR-")
            {
                guy.SteppedOnTile("KR-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            #endregion

            #region Shoes
            else if (board[guy.ArrayX(), guy.ArrayY()] == "FP-")
            {
                guy.SteppedOnTile("FP-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "FB-")
            {
                guy.SteppedOnTile("FB-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "IS-")
            {
                guy.SteppedOnTile("IS-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "SB-")
            {
                guy.SteppedOnTile("SB-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            #endregion

            #region Doors
            else if (board[guy.ArrayX(), guy.ArrayY()] == "DR-")
            {
                guy.SteppedOnTile("DR-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "DB-")
            {
                guy.SteppedOnTile("DB-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "DY-")
            {
                guy.SteppedOnTile("DY-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            else if (board[guy.ArrayX(), guy.ArrayY()] == "DG-")
            {
                guy.SteppedOnTile("DG-");
                board[guy.ArrayX(), guy.ArrayY()] = "FL-";
                ChangeTilePic(guy.ArrayX(), guy.ArrayY(), "FL-");
                hud.HideShowPics(guy.NumRedKeys(), guy.NumBlueKeys(), guy.NumGreenKeys(), guy.NumYellowKeys(), guy.HasFireBoots(), guy.HasFlippers(), guy.HasSuctionBoots(), guy.HasIceSkates());
            }
            #endregion

            else
            {
                guy.SteppedOnTile("");
            }

        }

        public void MoveEverything(string dir) //Tiles, monsters
        {
            foreach (Tile tile in lstTiles)
            {
                tile.Move(dir);
            }
            foreach (Teeth m in lstMonsters)
            {
                m.MoveWithGuy(dir);
            }
            foreach (Ball b in lstOfBalls)
            {
                b.MoveWithGuy(dir);
            }
            foreach (Fireball f in lstOfFireballs)
            {
                f.MoveWithGuy(dir);
            }
            foreach (Blob b in lstOfBlobs)
            {
                b.MoveWithGuy(dir);
            }
            foreach (Walker w in lstOfWalkers)
            {
                w.MoveWithGuy(dir); 
            }
        }

        public void CheckForCollision() //With monsters
        {
            foreach (Teeth m in lstMonsters)
            {
                if (guy.Alive())
                {
                    if (guy.GetRect().IntersectsWith(m.GetRect()))
                    {
                        guy.Kill();
                        MessageBox.Show("Watch out for creatures!", "Chips Challenge");
                        LoadLevel("");
                        break;
                    }
                }
            }
            foreach (Ball b in lstOfBalls)
            {
                if (guy.Alive())
                {
                    if (guy.GetRect().IntersectsWith(b.GetRect()))
                    {
                        guy.Kill();
                        MessageBox.Show("Watch out for balls!", "Chips Challenge");
                        LoadLevel("");
                        break;
                    }
                }
            }
            foreach (Fireball f in lstOfFireballs)
            {
                if (guy.Alive())
                {
                    if (guy.GetRect().IntersectsWith(f.GetRect()))
                    {
                        guy.Kill();
                        MessageBox.Show("Watch out for creatures!", "Chips Challenge");
                        LoadLevel("");
                        break;
                    }
                }
            }
            foreach (Blob b in lstOfBlobs)
            {
                if (guy.Alive())
                {
                    if (guy.GetRect().IntersectsWith(b.GetRect()))
                    {
                        guy.Kill();
                        MessageBox.Show("Watch out for creatures!", "Chips Challenge");
                        LoadLevel("");
                        break;
                    }
                }
            }
            foreach (Walker w in lstOfWalkers)
            {
                if (guy.Alive())
                {
                    if (guy.GetRect().IntersectsWith(w.GetRect()))
                    {
                        guy.Kill();
                        MessageBox.Show("Watch out for creatures!", "Chips Challenge");
                        LoadLevel("");
                        break;
                    }
                }
            }
            if (!guy.Alive())
            {
                tmrMain.Enabled = false;
            }
        }

        public void MoveDirt(string dir)
        {
            if (dir == "D")
            {
                if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() + 2] == "BO-")
                {
                    board[guy.ArrayX(), guy.ArrayY() + 2] = "FL-";
                    board[guy.ArrayX(), guy.ArrayY() + 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 2, "FL-");
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() + 2] != "WA-")
                {
                    board[guy.ArrayX(), guy.ArrayY() + 2] = "DT-";
                    board[guy.ArrayX(), guy.ArrayY() + 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 2, "DT-");
                }
                else if (board[guy.ArrayX(), guy.ArrayY() + 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() + 2] == "WA-")
                {
                    board[guy.ArrayX(), guy.ArrayY() + 2] = "MU-";
                    board[guy.ArrayX(), guy.ArrayY() + 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() + 2, "MU-");
                }
            }
            else if (dir == "U")
            {
                if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() - 2] == "BO-")
                {
                    board[guy.ArrayX(), guy.ArrayY() - 2] = "FL-";
                    board[guy.ArrayX(), guy.ArrayY() - 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 2, "FL-");
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() - 2] != "WA-")
                {
                    board[guy.ArrayX(), guy.ArrayY() - 2] = "DT-";
                    board[guy.ArrayX(), guy.ArrayY() - 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 2, "DT-");
                }
                else if (board[guy.ArrayX(), guy.ArrayY() - 1] == "DT-" && board[guy.ArrayX(), guy.ArrayY() - 2] == "WA-")
                {
                    board[guy.ArrayX(), guy.ArrayY() - 2] = "MU-";
                    board[guy.ArrayX(), guy.ArrayY() - 1] = "FL-";
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 1, "FL-");
                    ChangeTilePic(guy.ArrayX(), guy.ArrayY() - 2, "MU-");
                }
            }
            else if (dir == "R")
            {
                if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() + 2, guy.ArrayY()] == "BO-")
                {
                    board[guy.ArrayX() + 2, guy.ArrayY()] = "FL-";
                    board[guy.ArrayX() + 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() + 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() + 2, guy.ArrayY(), "FL-");
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() + 2, guy.ArrayY()] != "WA-")
                {
                    board[guy.ArrayX() + 2, guy.ArrayY()] = "DT-";
                    board[guy.ArrayX() + 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() + 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() + 2, guy.ArrayY(), "DT-");
                }
                else if (board[guy.ArrayX() + 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() + 2, guy.ArrayY()] == "WA-")
                {
                    board[guy.ArrayX() + 2, guy.ArrayY()] = "MU-";
                    board[guy.ArrayX() + 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() + 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() + 2, guy.ArrayY(), "MU-");
                }
            }
            else if (dir == "L")
            {
                if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() - 2, guy.ArrayY()] == "BO-")
                {
                    board[guy.ArrayX() - 2, guy.ArrayY()] = "FL-";
                    board[guy.ArrayX() - 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() - 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() - 2, guy.ArrayY(), "FL-");
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() - 2, guy.ArrayY()] != "WA-")
                {
                    board[guy.ArrayX() - 2, guy.ArrayY()] = "DT-";
                    board[guy.ArrayX() - 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() - 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() - 2, guy.ArrayY(), "DT-");
                }
                else if (board[guy.ArrayX() - 1, guy.ArrayY()] == "DT-" && board[guy.ArrayX() - 2, guy.ArrayY()] == "WA-")
                {
                    board[guy.ArrayX() - 2, guy.ArrayY()] = "MU-";
                    board[guy.ArrayX() - 1, guy.ArrayY()] = "FL-";
                    ChangeTilePic(guy.ArrayX() - 1, guy.ArrayY(), "FL-");
                    ChangeTilePic(guy.ArrayX() - 2, guy.ArrayY(), "MU-");
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                LoadLevel("");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            else if (e.KeyCode == Keys.N)
            {
                currentLevel = 1;
                LoadLevel("");
            }
            else if (e.KeyCode == Keys.F3)
            {
                tmrMain.Enabled = !tmrMain.Enabled;
                if (tmrMain.Enabled == true)
                {
                    lblPaused.Visible = false;
                }
                else if (tmrMain.Enabled == false)
                {
                    lblPaused.Visible = true;
                }
            }
            if (e.KeyCode != Keys.F3)
            {
                if (tmrMain.Enabled == false)
                {
                    tmrMain.Enabled = true;
                    lblPaused.Visible = false;
                }
            }
            if (e.KeyCode != Keys.R)
            {
                if (pnlLevelIntro.Visible == true)
                {
                    pnlLevelIntro.Visible = false;
                }
            }
            if (!guy.IsOnIce())
            {
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    if (!CantMove("U"))
                    {
                        turnCounter = 0;
                        MoveDirt("U");
                        guy.MoveChangeDirection("U");
                        MoveEverything("U");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    if (!CantMove("L"))
                    {
                        turnCounter = 0;
                        MoveDirt("L");
                        guy.MoveChangeDirection("L");
                        MoveEverything("L");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    if (!CantMove("R"))
                    {
                        turnCounter = 0;
                        MoveDirt("R");
                        guy.MoveChangeDirection("R");
                        MoveEverything("R");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    if (!CantMove("D"))
                    {
                        turnCounter = 0;
                        MoveDirt("D");
                        guy.MoveChangeDirection("D");
                        MoveEverything("D");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
            }

        }

        public void DoIceStuff()
        {
            if (guy.IsOnIce())
            {
                if (guy.LastDirection() == "R")
                {
                    if (!CantMove("R"))
                    {
                        guy.MoveChangeDirection("R");
                        MoveEverything("R");
                        StepOnTile();
                        guy.ChangePics();
                    }
                    else
                    {
                        guy.MoveChangeDirection("L");
                        MoveEverything("L");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (guy.LastDirection() == "L")
                {
                    if (!CantMove("L"))
                    {
                        guy.MoveChangeDirection("L");
                        MoveEverything("L");
                        StepOnTile();
                        guy.ChangePics();
                    }
                    else
                    {
                        guy.MoveChangeDirection("R");
                        MoveEverything("R");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (guy.LastDirection() == "U")
                {
                    if (!CantMove("U"))
                    {
                        guy.MoveChangeDirection("U");
                        MoveEverything("U");
                        StepOnTile();
                        guy.ChangePics();
                    }
                    else
                    {
                        guy.MoveChangeDirection("D");
                        MoveEverything("D");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
                else if (guy.LastDirection() == "D")
                {
                    if (!CantMove("D"))
                    {
                        guy.MoveChangeDirection("D");
                        MoveEverything("D");
                        StepOnTile();
                        guy.ChangePics();
                    }
                    else
                    {
                        guy.MoveChangeDirection("U");
                        MoveEverything("U");
                        StepOnTile();
                        guy.ChangePics();
                    }
                }
            }

        }

        void tmrMain_Tick(object sender, EventArgs e)
        {            
            
            #region 1 second
            if (pnlLevelIntro.Visible == false && !won)
            {
                secondCounter++;
                if (secondCounter == 20)
                {
                    levelTime--;
                    hud.UpdateTime(levelTime);
                    secondCounter = 0;
                }
            }
            #endregion

            #region Force floors/ice slow down
            timerCounter2Tick++;
            int x = 2;
            if (timerCounter2Tick == x)
            {
                DoIceStuff();
                if (guy.OnPushTile() && !guy.HasSuctionBoots()) //Do stuff if hes on a pushy tile
                {
                    StepOnTile();
                }
                timerCounter2Tick = 0;
                if (x == 2)
                {
                    x = 3;
                }
                else if (x == 3)
                {
                     x = 2;
                }
            }
            #endregion

            #region EnemyAutoMoves
            teethMoveCounter++;
            ballMoveCounter++;
            blobMoveCounter++;
            //Teeth/Fireballs
            if (teethMoveCounter > 5)
            {
                foreach (Teeth m in lstMonsters)
                {
                    m.MoveBySelf(board, guy.GetRect().X, guy.GetRect().Y);
                    if (m.OnToggleButton(board))
                    {
                        ToggleTiles();
                    }
                }
                foreach (Fireball f in lstOfFireballs)
                {
                    f.MoveBySelf(board);
                    if (f.OnToggleButton(board))
                    {
                        ToggleTiles();
                    }
                }
                teethMoveCounter = 0;
            }
            //Balls
            if (ballMoveCounter > 3)
            {
                foreach (Ball b in lstOfBalls)
                {
                    b.MoveBySelf(board);
                    if (b.OnToggleButton(board))
                    {
                        ToggleTiles();
                    }
                }
                foreach (Walker w in lstOfWalkers)
                {
                    w.MoveBySelf(board, random);
                    if (w.OnToggleButton(board))
                    {
                        ToggleTiles();
                    }
                }
                ballMoveCounter = 0;
            }
            //Blobs
            if (blobMoveCounter > 10)
            {
                foreach (Blob b in lstOfBlobs)
                {
                    b.MoveBySelf(board, random);
                    if (b.OnToggleButton(board))
                    {
                        ToggleTiles();
                    }
                }
                blobMoveCounter = 0;
            }
            #endregion

            #region Turn Forward
            turnCounter++;
            if (turnCounter > 20 && guy.Alive() && !guy.OnPushTile() && !guy.IsOnIce()) //Set standing pic
            {
                if (!guy.IsInWater())
                    guy.NormalPic("R");
                else
                    guy.NormalPic("W");
                turnCounter = 0;
            }
            #endregion

            CheckForCollision(); //Monsters
            Invalidate();

            if (levelTime == 0)
            {
                tmrMain.Enabled = false;
                MessageBox.Show("Out of time!", "Chips Challenge");
                LoadLevel("");
            }
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (Tile tile in lstTiles)
            {
                if (!tile.IsOutOfBounds())
                {
                    tile.Draw(g);
                }
            }
            guy.Draw(g);
            foreach (Teeth t in lstMonsters)
            {
                if (!t.IsOutOfBounds())
                {
                    t.Draw(g);
                }
            }
            foreach (Ball b in lstOfBalls)
            {
                if (!b.IsOutOfBounds())
                {
                    b.Draw(g);
                }
            }
            foreach (Fireball f in lstOfFireballs)
            {
                if (!f.IsOutOfBounds())
                {
                    f.Draw(g);
                }
            }
            foreach (Blob b in lstOfBlobs)
            {
                if (!b.IsOutOfBounds())
                {
                    b.Draw(g);
                }
            }
            foreach (Walker w in lstOfWalkers)
            {
                if (!w.IsOutOfBounds())
                {
                    w.Draw(g);
                }
            }

        }

        public void LoadLevel(string level)
        {
            Reset();
            lblLoading.Visible = true;
            Application.DoEvents();

            if (level == "") //Send in nothing, not custom level
            {
                level = levels[currentLevel];
            }
            else //If custom level, level = 0
            {
                currentLevel = 0;
            }
            if (level != null) //If out of levels, level = null from levels array
            {
                level = level.ToUpper();
                levelTime = Convert.ToInt16(level.Substring(0, 3));

                bool countChips = false;
                if (level.Substring(4, 3) == "999")
                {
                    countChips = true;
                }
                else
                {
                    chipsNeeded = Convert.ToInt16(level.Substring(4, 3));
                }

                int j = 0;
                int columnm = 0;

                for (int i = 9; i < level.Length - 3; i += 3)
                {
                    string x = level.Substring(i, 3);
                    if (countChips)
                    {
                        if (x == "CH-")
                        {
                            chipsNeeded++;
                        }
                    }
                    if (x != ";\r\n")
                    {
                        board[columnm, j] = x;
                        columnm++;
                    }
                    else
                    {
                        j++;
                      columnm = 0;
                    }
                }

                for (int i = 0; i < 50; i++)
                {
                    for (int k = 0; k < 50; k++)
                    {
                        if (board[i, k] == null)
                        {
                            board[i, k] = "FL-";
                        }
                        else if (board[i, k] == "TE-")
                        {
                            board[i, k] = "FL-";
                            lstMonsters.Add(new Teeth(i, k));
                        }
                        else if (board[i, k] == "BV-")
                        {
                            board[i, k] = "FL-";
                            lstOfBalls.Add(new Ball(i, k, "BV-"));
                        }
                        else if (board[i, k] == "BH-")
                        {
                            board[i, k] = "FL-";
                            lstOfBalls.Add(new Ball(i, k, "BH-"));
                        }
                        else if (board[i, k] == "FE-")
                        {
                            board[i, k] = "FL-";
                            lstOfFireballs.Add(new Fireball(i, k));
                        }
                        else if (board[i, k] == "BL-")
                        {
                            board[i, k] = "FL-";
                            lstOfBlobs.Add(new Blob(i, k));
                        }
                        else if (board[i, k] == "WK-")
                        {
                            board[i, k] = "FL-";
                            lstOfWalkers.Add(new Walker(i, k, random));
                        }
                    }
                }

                //Make tiles with array
                for (int i = 0; i < 50; i++)
                {
                    for (int k = 0; k < 50; k++)
                    {
                        lstTiles.Add(new Tile(i, k, board[i, k]));
                    }
                }

                //Put tiles in right place
                for (int i = 0; i < 50; i++)
                {
                    for (int k = 0; k < 50; k++)
                    {
                        if (board[i, k] == "SP-")
                        {
                            board[i, k] = "FL-";
                            int x = (6 - i) * 32;
                            int y = (7 - k) * 32;
                            guy.SetArrayPos(i, k);

                            foreach (Tile tile in lstTiles)
                            {
                                tile.SetPosition(x, y);
                                tile.CheckForOutOfBounds();
                            }
                            foreach (Teeth m in lstMonsters)
                            {
                                m.SetPosition(x, y);
                                m.CheckForOutOfBounds();
                            }
                            foreach (Ball b in lstOfBalls)
                            {
                                b.SetPosition(x, y);
                                b.CheckForOutOfBounds();
                            }
                            foreach (Fireball f in lstOfFireballs)
                            {
                                f.SetPosition(x, y);
                                f.CheckForOutOfBounds();
                            }
                            foreach (Blob b in lstOfBlobs)
                            {
                                b.SetPosition(x, y);
                                b.CheckForOutOfBounds();
                            }
                            foreach (Walker w in lstOfWalkers)
                            {
                                w.SetPosition(x, y);
                                w.CheckForOutOfBounds();
                            }

                        }
                    }
                }
                lblLoading.Visible = false;
                hud.SetLevel(currentLevel);
                hud.UpdateChips(chipsNeeded);
                hud.UpdateTime(levelTime);
            }
            else //If out of levels/ level = null
            {
                MessageBox.Show("You win!");
                currentLevel = 1;
                LoadLevel("");
            }
        }

        #region Menu Buttons

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentLevel = 1;
            LoadLevel("");
        }

        private void levelCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            levelSelector1.SetVisibility(true);
            levelSelector1.SetEnabled(true);
            levelSelector1.Focus();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLevel("");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void loadCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Filter = "Text Files (.txt)|*.txt";
            DialogResult result = x.ShowDialog();
            if (x.FileName != "")
            {
                StreamReader q = new StreamReader(x.FileName);
                string level = q.ReadToEnd();
                LoadLevel(level);
                q.Close();
            }
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrMain.Enabled = !tmrMain.Enabled;
            if (tmrMain.Enabled == true)
            {
                lblPaused.Visible = false;
            }
            else if (tmrMain.Enabled == false)
            {
                lblPaused.Visible = true;
            }
        }
        #endregion
    }
}
