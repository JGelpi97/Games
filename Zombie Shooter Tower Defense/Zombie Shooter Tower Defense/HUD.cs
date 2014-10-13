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
using System.IO;

namespace Zombie_Shooter_Tower_Defense
{
    class HUD
    {
        Rectangle turretPlacingRect = new Rectangle();
        Bitmap bmpTurret = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurretBase);
        ImageAttributes attr = new ImageAttributes();
        Rectangle gridRect = new Rectangle();
        Bitmap bmpGrid = new Bitmap(Zombie_Shooter_Tower_Defense.Properties.Resources.grid2);

        Timer slideTimer = new Timer();

        int selectedTurretCost;

        string typeOfTurret;
        bool placingTurret = false;
        bool turretInfoPanelOut = false;
        bool turretPanelOut = false;

        int heartColorTime = 3;
        bool lostHealth = false;

        bool waveBlink = true;
        int waveBlinkTime = 7;

        List<Control> lstOfControls = new List<Control>();

        Label lblTurret = new Label();
        Label lblTurretNames = new Label();
        Label lblTurretPrices = new Label();
        PictureBox picTurretBasic = new PictureBox();
        PictureBox picTurretSpeed = new PictureBox();
        PictureBox picTurretIce = new PictureBox();
        PictureBox picTurretRocket = new PictureBox();
        Panel pnlTurrets = new Panel();

        Panel pnlTurretInfo = new Panel();
        Label lblTurretType = new Label();
        Label lblTurretLevel = new Label();
        Label lblTurretDamage = new Label();
        Label lblTurretHealth = new Label();
        Label lblTurretUpgradeCost = new Label();
        Label lblTurretSellAmount = new Label();
        PictureBox picSellTurret = new PictureBox();
        PictureBox picUpgradeTurret = new PictureBox();
        PictureBox picCloseInfoPanel = new PictureBox();
        PictureBox picRepair = new PictureBox();
        Label lblRepairAmount = new Label();

        Panel pnlPlayerInfo = new Panel();
        Label lblGunType = new Label();
        Label lblGunAmmo = new Label();
        PictureBox picHeart = new PictureBox();
        Label lblHealth = new Label();
        Label lblFlares = new Label();

        Panel pnlWaves = new Panel();
        Label lblWaves = new Label();

        Panel pnlMoney = new Panel();
        Label lblMoney = new Label();        

        public void Create(int width, int height)
        {
            float[][] ptsArray ={
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, 0.8f, 0},
            new float[] {0, 0, 0, 0, 1}};
            ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
            attr.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            turretPlacingRect.Size = bmpTurret.Size;
            gridRect.Size = bmpGrid.Size;

            slideTimer.Interval = 50;
            slideTimer.Enabled = true;
            slideTimer.Tick += new EventHandler(slideTimer_Tick);

            Font captureFont = new Font("Times New Roman", 12);
            Font captureFontSmaller = new Font("Times New Roman", 11);
            Font captureFont2 = new Font("Times New Roman", 11);
            Font skratchFontBigger = new Font("Times New Roman", 13);

            try
            {
                System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
                pfc.AddFontFile(Application.StartupPath + "\\Capture it.ttf");
                captureFont = new Font(pfc.Families[0], 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
                captureFontSmaller = new Font(pfc.Families[0], 11f, FontStyle.Underline, GraphicsUnit.Point, 0);
                captureFont2 = new Font(pfc.Families[0], 11f, FontStyle.Regular, GraphicsUnit.Point, 0);

                pfc.AddFontFile(Application.StartupPath + "\\Skratch_Punk.ttf");
                skratchFontBigger = new Font(pfc.Families[1], 13f, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            catch { }

            #region Waves
            lstOfControls.Add(pnlWaves);
            pnlWaves.Controls.Add(lblWaves);

            pnlWaves.Location = new Point(642, 0);
            pnlWaves.Size = new Size(150, 40);
            pnlWaves.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.wavesPanelBack;

            lblWaves.Font = skratchFontBigger;
            lblWaves.Size = new Size(140, 30);
            lblWaves.Location = new Point(5, 8);
            lblWaves.Text = "Wave: 1";
            lblWaves.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;
            #endregion

            #region Money
            lstOfControls.Add(pnlMoney);
            pnlMoney.Controls.Add(lblMoney);

            pnlMoney.Location = new Point(0, 633);
            pnlMoney.Size = new Size(150, 40);
            pnlMoney.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.wavesPanelBack;

            lblMoney.Font = skratchFontBigger;
            lblMoney.Size = new Size(143, 25);
            lblMoney.Location = new Point(4, 8);
            lblMoney.Text = "Money: 0";
            lblMoney.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            #endregion

            #region PlayerInfo
            lstOfControls.Add(pnlPlayerInfo);
            pnlPlayerInfo.Controls.Add(lblGunAmmo);
            pnlPlayerInfo.Controls.Add(lblGunType);
            pnlPlayerInfo.Controls.Add(picHeart);
            pnlPlayerInfo.Controls.Add(lblHealth);
            pnlPlayerInfo.Controls.Add(lblFlares);


            lblGunAmmo.Font = captureFont;
            lblGunAmmo.Size = new Size(95, 15);
            lblGunAmmo.Location = new Point(250, 6);
            lblGunAmmo.Text = "Ammo: INF";
            lblGunAmmo.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblGunType.Font = captureFont;
            lblGunType.Size = new Size(165, 15);
            lblGunType.Location = new Point(75, 6);
            lblGunType.Text = "Weapon: Pistol";
            lblGunType.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblHealth.Font = captureFont;
            lblHealth.Size = new Size(40, 15);
            lblHealth.Location = new Point(20, 6);
            lblHealth.Text = "20";
            lblHealth.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblFlares.Font = captureFont;
            lblFlares.Size = new Size(95, 15);
            lblFlares.Location = new Point(360, 6);
            lblFlares.Text = "Flares: 10";
            lblFlares.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            picHeart.Size = Zombie_Shooter_Tower_Defense.Properties.Resources.healthHeart.Size;
            picHeart.Location = new Point(5, 6);
            picHeart.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.healthHeart;

            pnlPlayerInfo.Location = new Point(0, 0);
            pnlPlayerInfo.Size = new Size(460, 30);
            pnlPlayerInfo.BackColor = Color.FromArgb(128, 128, 128);
            pnlPlayerInfo.BorderStyle = BorderStyle.None;
            pnlPlayerInfo.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.playerInfoBack;
            #endregion

            #region TurretInfoPanel
            pnlTurretInfo.Controls.Add(lblTurretLevel);
            pnlTurretInfo.Controls.Add(lblTurretDamage);
            pnlTurretInfo.Controls.Add(lblTurretType);
            pnlTurretInfo.Controls.Add(lblTurretHealth);
            pnlTurretInfo.Controls.Add(picSellTurret);
            pnlTurretInfo.Controls.Add(picUpgradeTurret);
            pnlTurretInfo.Controls.Add(picCloseInfoPanel);
            pnlTurretInfo.Controls.Add(lblTurretUpgradeCost);
            pnlTurretInfo.Controls.Add(lblTurretSellAmount);
            pnlTurretInfo.Controls.Add(picRepair);
            pnlTurretInfo.Controls.Add(lblRepairAmount);

            lstOfControls.Add(pnlTurretInfo);
            pnlTurretInfo.Size = new Size(180, 320);
            pnlTurretInfo.Location = new Point(801, 175);
            pnlTurretInfo.BackColor = Color.Gray;
            pnlTurretInfo.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.turretInfoPanelBack;

            lblTurretType.Font = captureFont;
            lblTurretType.AutoSize = true;
            lblTurretType.Location = new Point(30, 10);
            lblTurretType.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblTurretLevel.Font = captureFont;
            lblTurretLevel.AutoSize = true;
            lblTurretLevel.Location = new Point(30, 40);
            lblTurretLevel.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblTurretDamage.Font = captureFont;
            lblTurretDamage.AutoSize = true;
            lblTurretDamage.Location = new Point(30, 70);
            lblTurretDamage.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblTurretHealth.Font = captureFont;
            lblTurretHealth.AutoSize = true;
            lblTurretHealth.Location = new Point(30, 100);
            lblTurretHealth.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            picSellTurret.BackColor = Color.Red;
            picSellTurret.Click += new EventHandler(picSellTurret_Click);
            picSellTurret.Size = new Size(100, 40);
            picSellTurret.Location = new Point(30, 260);
            picSellTurret.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.SellButton;

            lblTurretSellAmount.Font = new Font("Courier New", 10);
            lblTurretSellAmount.AutoSize = true;
            lblTurretSellAmount.Text = "+";
            lblTurretSellAmount.Location = new Point(62, 295);
            lblTurretSellAmount.BringToFront();
            lblTurretSellAmount.BorderStyle = BorderStyle.FixedSingle;

            lblTurretUpgradeCost.Font = new Font("Courier New", 10);
            lblTurretUpgradeCost.AutoSize = true;
            lblTurretUpgradeCost.Text = "-";
            lblTurretUpgradeCost.Location = new Point(62, 165);
            lblTurretUpgradeCost.BringToFront();
            lblTurretUpgradeCost.BorderStyle = BorderStyle.FixedSingle;

            picUpgradeTurret.BackColor = Color.Blue;
            picUpgradeTurret.Size = new Size(100, 40);
            picUpgradeTurret.Location = new Point(30, 130);
            picUpgradeTurret.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.UpgradeButton;

            lblRepairAmount.Font = new Font("Courier New", 10);
            lblRepairAmount.AutoSize = true;
            lblRepairAmount.Location = new Point(62, 230);
            lblRepairAmount.Text = "-10";
            lblRepairAmount.BringToFront();
            lblRepairAmount.BorderStyle = BorderStyle.FixedSingle;

            picRepair.Size = new Size(100, 40);
            picRepair.Location = new Point(30, 195);
            picRepair.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.repairButton;

            picCloseInfoPanel.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.closeArrow;
            picCloseInfoPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            picCloseInfoPanel.Size = new Size(15, 75);
            picCloseInfoPanel.Location = new Point(0, 120);
            picCloseInfoPanel.Visible = false;
            picCloseInfoPanel.Click += new EventHandler(picCloseInfoPanel_Click);
            #endregion

            #region Turret Panel
            lstOfControls.Add(pnlTurrets);

            pnlTurrets.Controls.Add(picTurretBasic);
            pnlTurrets.Controls.Add(picTurretSpeed);
            pnlTurrets.Controls.Add(picTurretIce);
            pnlTurrets.Controls.Add(picTurretRocket);
            pnlTurrets.Controls.Add(lblTurret);
            pnlTurrets.Controls.Add(lblTurretNames);
            pnlTurrets.Controls.Add(lblTurretPrices);

            pnlTurrets.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            pnlTurrets.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);
            
            lblTurret.Font = captureFontSmaller;
            lblTurret.AutoSize = true;
            lblTurret.Location = new Point(100, 4);
            lblTurret.Text = "Turrets";
            lblTurret.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            lblTurret.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);
            lblTurret.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;


            lblTurretNames.Font = new Font("Courier", 9);
            lblTurretNames.AutoSize = true;
            lblTurretNames.Location = new Point(27, 55);
            lblTurretNames.Text = "Basic         Speed           Ice            Rocket";
            lblTurretNames.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            lblTurretNames.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);
            lblTurretNames.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;

            lblTurretPrices.Font = new Font("Courier", 9);
            lblTurretPrices.AutoSize = true;
            lblTurretPrices.Location = new Point(27, 70);
            lblTurretPrices.Text = " $20             $22             $15              $30";
            lblTurretPrices.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            lblTurretPrices.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);
            lblTurretPrices.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.backgroundGrey;


            pnlTurrets.Size = new Size(280, 200);
            pnlTurrets.Location = new Point(350, 585);
            pnlTurrets.BackColor = Color.Gray;
            pnlTurrets.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.turretPanelBack;

            picTurretBasic.Size = new Size(30, 30);
            picTurretBasic.Location = new Point(30, 25);
            picTurretBasic.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurret;
            picTurretBasic.Click += new EventHandler(picTurretBasic_Click);
            picTurretBasic.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            picTurretBasic.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);

            picTurretIce.Size = new Size(30, 30);
            picTurretIce.Location = new Point(150, 25);
            picTurretIce.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurret;
            picTurretIce.Click += new EventHandler(picTurretIce_Click);
            picTurretIce.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            picTurretIce.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);

            picTurretSpeed.Size = new Size(30, 30);
            picTurretSpeed.Location = new Point(90, 25);
            picTurretSpeed.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurret;
            picTurretSpeed.Click += new EventHandler(picTurretSpeed_Click);
            picTurretSpeed.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            picTurretSpeed.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);

            picTurretRocket.Size = new Size(30, 30);
            picTurretRocket.Location = new Point(210, 25);
            picTurretRocket.Image = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurret;
            picTurretRocket.Click += new EventHandler(picTurretRocket_Click);
            picTurretRocket.MouseEnter += new EventHandler(pnlTurrets_MouseEnter);
            picTurretRocket.MouseLeave += new EventHandler(pnlTurrets_MouseLeave);

            #endregion            
        }

        #region TurretClicks
        void picTurretRocket_Click(object sender, EventArgs e)
        {
            bmpTurret = Zombie_Shooter_Tower_Defense.Properties.Resources.rocketTurret;
            placingTurret = true;
            typeOfTurret = "rocket";
            turretInfoPanelOut = false;
            selectedTurretCost = 30;
        }

        void picTurretIce_Click(object sender, EventArgs e)
        {
            bmpTurret = Zombie_Shooter_Tower_Defense.Properties.Resources.iceTurret;
            placingTurret = true;
            typeOfTurret = "ice";
            turretInfoPanelOut = false;
            selectedTurretCost = 15;
        }

        void picTurretSpeed_Click(object sender, EventArgs e)
        {
            bmpTurret = Zombie_Shooter_Tower_Defense.Properties.Resources.speedTurret;
            placingTurret = true;
            typeOfTurret = "speed";
            turretInfoPanelOut = false;
            selectedTurretCost = 22;
        }

        void picTurretBasic_Click(object sender, EventArgs e)
        {
            bmpTurret = Zombie_Shooter_Tower_Defense.Properties.Resources.basicTurret;
            placingTurret = true;
            typeOfTurret = "basic";
            turretInfoPanelOut = false;
            selectedTurretCost = 20;
        }
        #endregion

        public void UpdateFlares(int flares)
        {
            lblFlares.Text = "Flares: " + flares.ToString();
        }

        public void UpdateWave(int x)
        {
            lblWaves.Text = "Wave: " + x.ToString();
            lblWaves.ForeColor = Color.White;
            waveBlink = true;
        }

        public void UpdateWeaponInfo(string weapon, int ammo)
        {
            lblGunType.Text = "Weapon: " + weapon;
            if (weapon != "Pistol")
                lblGunAmmo.Text = "Ammo: " + Convert.ToString(ammo);
            else
                lblGunAmmo.Text = "Ammo: INF";
        }

        public void UpdateMoney(int x)
        {
            lblMoney.Text = "Money: " + x.ToString(); 
        }

        public void UpdateHealth(int x)
        {
            lblHealth.Text = Convert.ToString(x);
            picHeart.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.heartTookDamage;
            lostHealth = true;
            lblHealth.ForeColor = Color.White;
        }

        public void UpdateWeaponAmmo(int x)
        {
            lblGunAmmo.ForeColor = Color.Black;
            lblGunAmmo.Text = "Ammo: " + Convert.ToString(x);
            if (x == 0)
            {
                lblGunAmmo.ForeColor = Color.White;
                lblGunAmmo.Text = "Ammo: --";
            }
        }
        
        void pnlTurrets_MouseLeave(object sender, EventArgs e)
        {
            turretPanelOut = false;
        }

        void pnlTurrets_MouseEnter(object sender, EventArgs e)
        {
            turretPanelOut = true;
        }

        void picCloseInfoPanel_Click(object sender, EventArgs e)
        {
            turretInfoPanelOut = false;
        }

        void picSellTurret_Click(object sender, EventArgs e)
        {
            turretInfoPanelOut = false;
        }

        public void UpdateTurretInfo(string type, int level, int damage, int health, int sellPrice, int upgradePrice)
        {
            type = type.Substring(0, 1).ToUpper() + type.Substring(1);
            lblTurretType.Text = "Type: " + type;
            lblTurretLevel.Text = "Level: " + Convert.ToString(level);
            lblTurretDamage.Text = "Damage: " + Convert.ToString(damage);
            lblTurretHealth.Text = "Health: " + Convert.ToString(health);
            lblTurretSellAmount.Text = "+ " + sellPrice.ToString();
            if (upgradePrice > 0)
            {
                lblTurretUpgradeCost.Text = "- " + upgradePrice.ToString();
            }
            else
            {
                lblTurretUpgradeCost.Text = "--";
            }
        }

        void slideTimer_Tick(object sender, EventArgs e)
        {
            if (waveBlink)
            {
                waveBlinkTime--;
                if (waveBlinkTime == 0)
                {
                    lblWaves.ForeColor = Color.Black;
                    waveBlinkTime = 7;
                    waveBlink = false;
                }
            }

            if (lostHealth)
            {
                heartColorTime--;
                if (heartColorTime == 0)
                {
                    picHeart.BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.healthHeart;
                    lostHealth = false;
                    heartColorTime = 3; 
                }
                else if (heartColorTime == 1)
                {
                    lblHealth.ForeColor = Color.Black;
                }
            }

            if (turretInfoPanelOut)
            {
                if (pnlTurretInfo.Left > 640)
                    pnlTurretInfo.Left -= 15;
                picCloseInfoPanel.Visible = true;
            }
            else if (!turretInfoPanelOut)
            {
                if (pnlTurretInfo.Left < 801)
                    pnlTurretInfo.Left += 15;
                picCloseInfoPanel.Visible = false;
            }

            //if (turretPanelOut)
            //{
            //    if (pnlTurrets.Top > 580)
            //        pnlTurrets.Top -= 15;
            //}
            //else if (!turretPanelOut)
            //{
            //    if (pnlTurrets.Top < 645)
            //        pnlTurrets.Top += 15;
            //}
        }

        public void SetTurretPanelOut(bool x)
        {
            turretInfoPanelOut = x;
        }

        public bool IsTurretPanelOut()
        {
            return turretInfoPanelOut;
        }

        public Panel GetPanel()
        {
            return pnlPlayerInfo;
        }

        public void UpdateRectPosition(int mouseX, int mouseY)
        {
            turretPlacingRect.X = mouseX - 15;
            turretPlacingRect.Y = mouseY - 15;
        }

        public PictureBox GetSellButton()
        {
            return picSellTurret;
        }

        public PictureBox GetRepairButton()
        {
            return picRepair;
        }

        public PictureBox GetUpgradeButton()
        {
            return picUpgradeTurret;
        }

        public string TypeOfTurret()
        {
            return typeOfTurret;
        }

        public bool IsPlacingTurret()
        {
            return placingTurret;
        }

        public void SetPlacingTurret(bool x)
        {
            placingTurret = x;
        }

        public List<Control> GetList()
        {
            return lstOfControls;
        }

        public int SelectedTurretCost()
        {
            return selectedTurretCost;
        }

        public Rectangle TurretPlacingRect()
        {
            return turretPlacingRect;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmpTurret, turretPlacingRect, 0, 0, bmpTurret.Width, bmpTurret.Height, GraphicsUnit.Pixel, attr);
            g.DrawImage(bmpGrid, gridRect, 0, 0, bmpGrid.Width, bmpGrid.Height, GraphicsUnit.Pixel, attr);
        }
    }
}
