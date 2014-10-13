using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;

namespace Zombie_Shooter_Tower_Defense
{
    public partial class Form1 : Form
    {
        int[,] board = new int[200, 200];
        int[,] shadeArray = new int[160, 160];
        Flashlight flashLight = new Flashlight();
        Rectangle clickRect = new Rectangle(-1, -1, 1, 1);
        Random random = new Random();
        Timer gameTimer = new Timer();
        Player guy = new Player();
        Graphics g;
        List<Bullet> lstOfBullets = new List<Bullet>();
        List<Enemy> lstOfEnemies = new List<Enemy>();
        List<Turret> lstOfTurrets = new List<Turret>();
        List<Flare> lstOfFlares = new List<Flare>();
        List<Rocket> lstOfRockets = new List<Rocket>();
        List<Pickup_Object> lstOfPickups = new List<Pickup_Object>();
        Matrix rotationMatrix = new Matrix();
        HUD hud = new HUD();
        Turret currentlySelectedTurret;
        bool mouseIsDown = false;
        int mouseX, mouseY;
        int enemySpawnCounter = -9999999;
        int fireCounter = 0;
        int firingDelay = 5;
        long placeHolderTime;
        int frames = 0;
        Wave_System waveSystem = new Wave_System();
        Label lblFps = new Label();
        bool RunGame = false;
        Brush brush = new SolidBrush(Color.White);
        string[] weaponsList = new string[6];
        bool[] weaponCanSelect = new bool[6];
        int selectedWeaponSlot = 1;
        int bombSpawnCounter = 0;
        Menu menu = new Menu();
        int textDisplayTime = 0;
        string textToDisplay = "";
        int waveBreakTime = 40;
        int waveTextDispTime = 0;
        string waveTextToDisplay = "";
        int healthPackSpawnTime = 0;
        int flareSpawnCounter = 0;
        bool minigunFiring = false;
        int longestSpawnTime = 35;
        SoundPlayer pistolShot = new SoundPlayer(Zombie_Shooter_Tower_Defense.Properties.Resources.pistol_fire2);
        SoundPlayer smgShot = new SoundPlayer(Zombie_Shooter_Tower_Defense.Properties.Resources.smg);
        SoundPlayer shotgunShot = new SoundPlayer(Zombie_Shooter_Tower_Defense.Properties.Resources.shotgun);
        SoundPlayer sniperShot = new SoundPlayer(Zombie_Shooter_Tower_Defense.Properties.Resources.sniper);
        SoundPlayer minigunShot = new SoundPlayer(Zombie_Shooter_Tower_Defense.Properties.Resources.minigun_fire);

        public Form1()
        {
            InitializeComponent();
            Text = "Some Tower Defense Shooter";
            BackgroundImage = Zombie_Shooter_Tower_Defense.Properties.Resources.background_png_;
            hud.Create(Width, Height);
            Size = new Size(800, 705);
            MinimumSize = new Size(800, 705);
            MaximumSize = new Size(800, 715);
            gameTimer.Interval = 45;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            gameTimer.Enabled = true;
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;
            Paint += new PaintEventHandler(Form1_Paint);
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            KeyUp += new KeyEventHandler(Form1_KeyUp);
            MouseDown += new MouseEventHandler(Form1_MouseDown);
            MouseUp += new MouseEventHandler(Form1_MouseUp);
            MouseMove += new MouseEventHandler(Form1_MouseMove);          
            IntPtr yea = Zombie_Shooter_Tower_Defense.Properties.Resources.Crosshair.GetHicon();
            Cursor = new Cursor(yea);
            BackColor = Color.Gray;
            currentlySelectedTurret = null;
            List<Control> lstOfControls = new List<Control>();
            lstOfControls = hud.GetList();
            hud.GetSellButton().Click += new EventHandler(picSellTurret_Click);
            hud.GetUpgradeButton().Click+=new EventHandler(picUpgradeTurret_Click);
            hud.GetRepairButton().Click += new EventHandler(picRepairTurret_Click);
            hud.GetPanel().MouseMove+=new MouseEventHandler(Form1_MouseMove);

            MouseWheel += new MouseEventHandler(Form1_MouseWheel);

            weaponsList[1] = "pistol";
            weaponsList[2] = "smg";
            weaponsList[3] = "shotgun";
            weaponsList[4] = "sniper";
            weaponsList[5] = "minigun";

            weaponCanSelect[1] = true;
            weaponCanSelect[2] = false;
            weaponCanSelect[3] = false;
            weaponCanSelect[4] = false;
            weaponCanSelect[5] = false;

            placeHolderTime = DateTime.Now.Ticks;

            foreach (Control o in lstOfControls)
            {
                Controls.Add(o);
            }

            Controls.Add(lblFps);

            lblFps.AutoSize = true;
            lblFps.BackColor = Color.Gray;
            lblFps.Location = new Point(10, 40);
            lblFps.ForeColor = Color.White;

            Controls.Add(menu.GetMenu());
            Controls.Add(menu.GetHelp());
            Controls.Add(menu.GetCreditsPanel());
            menu.GetContinueLabel().Click += new EventHandler(lblContinue_Click);
            menu.GetRestartLabel().Click += new EventHandler(lblRestart_Click);

        }

        void lblRestart_Click(object sender, EventArgs e)
        {
            Reset();
            menu.ShowHideMenu();
        }

        void picRepairTurret_Click(object sender, EventArgs e)
        {
            foreach (Turret t in lstOfTurrets)
            {
                if (t == currentlySelectedTurret)
                {
                    if (guy.Money() >= 10 && t.Health() != t.MaxHealth())
                    {
                        guy.LoseMoney(10);
                        t.Repair();
                        hud.UpdateTurretInfo(t.Type(), t.Level(), t.Damage(), t.Health(), t.SellAmount(), t.UpgradeCost());
                        break;
                    }
                }
            }
        }

        public void Reset()
        {
            lstOfTurrets.Clear();
            lstOfRockets.Clear();
            lstOfPickups.Clear();
            lstOfFlares.Clear();
            lstOfEnemies.Clear();
            lstOfBullets.Clear();
            guy.Reset();
            hud.Create(Width, Height);
            weaponCanSelect[1] = true;
            weaponCanSelect[2] = false;
            weaponCanSelect[3] = false;
            weaponCanSelect[4] = false;
            weaponCanSelect[5] = false;
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    board[i, j] = 0;
                }
            }
            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 160; j++)
                {
                    shadeArray[i, j] = 0;
                }
            }
            flashLight.Reset();
            textDisplayTime = 0;
            textToDisplay = "";
            waveBreakTime = 40;
            waveTextDispTime = 0;
            waveTextToDisplay = "";
            healthPackSpawnTime = 0;
            flareSpawnCounter = 0;
            minigunFiring = false;
            longestSpawnTime = 35;
            selectedWeaponSlot = 1;
            bombSpawnCounter = 0;
            RunGame = false;
            currentlySelectedTurret = null;
            mouseIsDown = false;
            enemySpawnCounter = -9999999;
            fireCounter = 0;
            firingDelay = 5;
            frames = 0;
            waveSystem.Reset();
            menu.ShowHideMenu();
        }

        void lblContinue_Click(object sender, EventArgs e)
        {
            RunGame = true;
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                do
                {
                    selectedWeaponSlot++;
                    if (selectedWeaponSlot > 5)
                    {
                        selectedWeaponSlot = 1;
                    }
                } while (!weaponCanSelect[selectedWeaponSlot]);

                if (weaponsList[selectedWeaponSlot] == "pistol")
                {
                    guy.SetWeapon("pistol");
                    firingDelay = 5;
                    hud.UpdateWeaponInfo("Pistol", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "smg")
                {
                    firingDelay = 1;
                    guy.SetWeapon("smg");
                    hud.UpdateWeaponInfo("SMG", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "shotgun")
                {
                    firingDelay = 8;
                    guy.SetWeapon("shotgun");
                    hud.UpdateWeaponInfo("Shotgun", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "sniper")
                {
                    firingDelay = 10;
                    guy.SetWeapon("sniper");
                    hud.UpdateWeaponInfo("Sniper", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "minigun")
                {
                    firingDelay = 0;
                    guy.SetWeapon("minigun");
                    hud.UpdateWeaponInfo("Minigun", guy.CurrentWeaponAmmo());
                }
            }
            else if (e.Delta < 0)
            {
                do
                {
                    selectedWeaponSlot--;
                    if (selectedWeaponSlot < 1)
                    {
                        selectedWeaponSlot = 5;
                    }
                } while (!weaponCanSelect[selectedWeaponSlot]);

                if (weaponsList[selectedWeaponSlot] == "pistol")
                {
                    guy.SetWeapon("pistol");
                    firingDelay = 5;
                    hud.UpdateWeaponInfo("Pistol", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "smg")
                {
                    firingDelay = 1;
                    guy.SetWeapon("smg");
                    hud.UpdateWeaponInfo("SMG", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "shotgun")
                {
                    firingDelay = 8;
                    guy.SetWeapon("shotgun");
                    hud.UpdateWeaponInfo("Shotgun", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "sniper")
                {
                    firingDelay = 10;
                    guy.SetWeapon("sniper");
                    hud.UpdateWeaponInfo("Sniper", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "minigun")
                {
                    firingDelay = 0;
                    guy.SetWeapon("minigun");
                    hud.UpdateWeaponInfo("Minigun", guy.CurrentWeaponAmmo());
                }
            }
        }
        
        void picUpgradeTurret_Click(object sender, EventArgs e)
        {
            foreach (Turret t in lstOfTurrets)
            {
                if (t == currentlySelectedTurret)
                {
                    if (guy.Money() >= t.UpgradeCost())
                    {
                        guy.LoseMoney(t.UpgradeCost());
                        t.Upgrade();
                    }
                    hud.UpdateTurretInfo(t.Type(), t.Level(), t.Damage(), t.Health(), t.SellAmount(), t.UpgradeCost());
                    break;
                }
            }
        }        

        void picSellTurret_Click(object sender, EventArgs e)
        {
            RunGame = true;
            foreach (Turret t in lstOfTurrets)
            {
                if (t == currentlySelectedTurret)
                {
                    guy.GainMoney(t.SellAmount());
                    t.Kill();
                    board[t.ArrayX(), t.ArrayY()] = 0;
                    break;
                }
            }
        }        

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            hud.UpdateRectPosition(mouseX, mouseY);
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            guy.IsFiring(false);
            minigunFiring = false;
            if (guy.CurrentWeapon() == "minigun")
            {                
                minigunShot.Stop();
            }
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool clickingOnTurret = false;            
            clickRect.Location = new Point(mouseX, mouseY);
            if (e.Button == MouseButtons.Left && hud.IsPlacingTurret() 
                && !hud.TurretPlacingRect().IntersectsWith(guy.Rect()) && guy.Money() >= hud.SelectedTurretCost())
            {
                if (menu.GetMenu().Visible == false)
                {
                    RunGame = true;
                }
                int x = mouseX / 30 * 30;
                int y = mouseY / 30 * 30;
                //If no turret in spot make one
                if (board[x / 30, y / 30] == 0)
                {
                    lstOfTurrets.Add(new Turret(x, y, hud.TypeOfTurret()));
                    board[x / 30, y / 30] = 1;
                    guy.LoseMoney(hud.SelectedTurretCost());
                    hud.SetPlacingTurret(false);
                }
            }
            else if (hud.IsPlacingTurret() && guy.Money() < hud.SelectedTurretCost())
            {
                //Didnt have money to make turret
                if (menu.GetMenu().Visible == false)
                {
                    RunGame = true;
                }
                hud.SetPlacingTurret(false);
            }
            else if (e.Button == MouseButtons.Right && !hud.IsPlacingTurret())
            {
                if (menu.GetMenu().Visible == false)
                {
                    RunGame = true;
                }
                hud.SetTurretPanelOut(false);
                //If not placing turret
                //Check for collision
                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive() && t.Rect().IntersectsWith(clickRect))
                    {
                        RunGame = false;
                        currentlySelectedTurret = t;
                        hud.UpdateTurretInfo(t.Type(), t.Level(), t.Damage(), t.Health(), t.SellAmount(), t.UpgradeCost());
                        hud.SetTurretPanelOut(true);
                        clickingOnTurret = true;
                        break;
                    }                    
                }
            }
            else if (e.Button == MouseButtons.Left && !hud.IsPlacingTurret())
            {
                if (menu.GetMenu().Visible == false)
                {
                    RunGame = true;
                }
                if (clickingOnTurret == false) //Didnt click on turret, fire bullet
                {
                    hud.SetTurretPanelOut(false);
                    mouseIsDown = true;
                    currentlySelectedTurret = null;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (menu.GetMenu().Visible == false)
                {
                    RunGame = true;
                }
                hud.SetPlacingTurret(false);
                hud.SetTurretPanelOut(false);
                currentlySelectedTurret = null;
            }
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.A)
                guy.SetMovingLeft(false);
            else if (e.KeyCode == Keys.D)
                guy.SetMovingRight(false);
            else if (e.KeyCode == Keys.W)
                guy.SetMovingUp(false);
            else if (e.KeyCode == Keys.S)
                guy.SetMovingDown(false);
            if (e.KeyCode == Keys.Space)
                enemySpawnCounter = 0;
        }

        public void TurretEverything()
        {
            foreach (Turret t in lstOfTurrets)
            {
                if (t.Alive())
                {
                    t.Target(lstOfEnemies);
                    t.DecreaseTimeToFire();
                }
                else
                {
                    break;
                }
            }
            foreach (Enemy en in lstOfEnemies)
            {
                if (!en.Alive())
                    break;
                foreach (Turret t in lstOfTurrets)
                {
                    if (t.FireTime() == 0 && t.Alive() && t.CurrentTarget() == en)
                    {
                        if (t.Type() != "rocket")
                        {
                        t.ResetFiringTime();
                        lstOfBullets.Add(new Bullet(t.Type(), t.Damage(), t.Level(), 
                            en.Rect().X + (en.Rect().Width / 2), en.Rect().Y + (en.Rect().Height / 2), 
                            t.Rect().X + (t.Rect().Width / 2), t.Rect().Y + (t.Rect().Height / 2)));
                        }
                        else 
                        {
                            t.ResetFiringTime();
                            lstOfRockets.Add(new Rocket(en.Rect().X + (en.Rect().Width / 2), en.Rect().Y + (en.Rect().Height / 2), 
                                t.Rect().X + (t.Rect().Width / 2), 
                                t.Rect().Y + (t.Rect().Height / 2), t.CurrentTarget(), t.Damage()));
                        }
                    }
                    else if (!t.Alive())
                    {
                        break;
                    }
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                Reset();
            }
            if (e.KeyCode == Keys.F)
            {
                if (guy.Flares() > 0)
                {
                    lstOfFlares.Add(new Flare(guy.Rect().X, guy.Rect().Y));
                    guy.LoseFlare();
                    hud.UpdateFlares(guy.Flares());
                }
            }

            if (e.KeyCode == Keys.F3)
            {
                lblFps.Visible = !lblFps.Visible;
            }

            if (e.KeyCode == Keys.Escape)
            {
                RunGame = !RunGame;
                menu.ShowHideMenu();
            }

            #region Q/E weapon switching
            if (e.KeyCode == Keys.E)
            {
                do
                {
                    selectedWeaponSlot++;
                    if (selectedWeaponSlot > 5)
                    {
                        selectedWeaponSlot = 1;
                    }
                } while (!weaponCanSelect[selectedWeaponSlot]);

                if (weaponsList[selectedWeaponSlot] == "pistol")
                {
                    guy.SetWeapon("pistol");
                    firingDelay = 5;
                    hud.UpdateWeaponInfo("Pistol", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "smg")
                {
                    firingDelay = 1;
                    guy.SetWeapon("smg");
                    hud.UpdateWeaponInfo("SMG", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "shotgun")
                {
                    firingDelay = 8;
                    guy.SetWeapon("shotgun");
                    hud.UpdateWeaponInfo("Shotgun", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "sniper")
                {
                    firingDelay = 10;
                    guy.SetWeapon("sniper");
                    hud.UpdateWeaponInfo("Sniper", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "minigun")
                {
                    firingDelay = 0;
                    guy.SetWeapon("minigun");
                    hud.UpdateWeaponInfo("Minigun", guy.CurrentWeaponAmmo());
                }
            }

            if (e.KeyCode == Keys.Q)
            {
                do
                {
                    selectedWeaponSlot--;
                    if (selectedWeaponSlot < 1)
                    {
                        selectedWeaponSlot = 5;
                    }
                } while (!weaponCanSelect[selectedWeaponSlot]);

                if (weaponsList[selectedWeaponSlot] == "pistol")
                {
                    guy.SetWeapon("pistol");
                    firingDelay = 5;
                    hud.UpdateWeaponInfo("Pistol", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "smg")
                {
                    firingDelay = 1;
                    guy.SetWeapon("smg");
                    hud.UpdateWeaponInfo("SMG", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "shotgun")
                {
                    firingDelay = 8;
                    guy.SetWeapon("shotgun");
                    hud.UpdateWeaponInfo("Shotgun", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "sniper")
                {
                    firingDelay = 10;
                    guy.SetWeapon("sniper");
                    hud.UpdateWeaponInfo("Sniper", guy.CurrentWeaponAmmo());
                }
                else if (weaponsList[selectedWeaponSlot] == "minigun")
                {
                    firingDelay = 0;
                    guy.SetWeapon("minigun");
                    hud.UpdateWeaponInfo("Minigun", guy.CurrentWeaponAmmo());
                }
            }
            #endregion

            #region Moving
            if (e.KeyCode == Keys.A)
            {
                guy.SetMovingLeft(true);
            }
            else if (e.KeyCode == Keys.D)
            {
                guy.SetMovingRight(true);
            }
            else if (e.KeyCode == Keys.W)
            {
                guy.SetMovingUp(true);
            }
            else if (e.KeyCode == Keys.S)
            {
                guy.SetMovingDown(true);
            }
            #endregion

            #region WeaponSwitching
            if (e.KeyCode == Keys.D1 && weaponCanSelect[1] == true)
            {
                selectedWeaponSlot = 1;
                guy.SetWeapon("pistol");
                firingDelay = 5;
                hud.UpdateWeaponInfo("Pistol", guy.CurrentWeaponAmmo());
            }
            else if (e.KeyCode == Keys.D2 && weaponCanSelect[2] == true)
            {
                selectedWeaponSlot = 2;
                firingDelay = 1;
                guy.SetWeapon("smg");
                hud.UpdateWeaponInfo("SMG", guy.CurrentWeaponAmmo());
            }
            else if (e.KeyCode == Keys.D3 && weaponCanSelect[3] == true)
            {
                selectedWeaponSlot = 3;
                firingDelay = 8;
                guy.SetWeapon("shotgun");
                hud.UpdateWeaponInfo("Shotgun", guy.CurrentWeaponAmmo());
            }
            else if (e.KeyCode == Keys.D4 && weaponCanSelect[4] == true)
            {
                selectedWeaponSlot = 4;
                firingDelay = 10;
                guy.SetWeapon("sniper");
                hud.UpdateWeaponInfo("Sniper", guy.CurrentWeaponAmmo());
            }
            else if (e.KeyCode == Keys.D5 && weaponCanSelect[5] == true)
            {
                selectedWeaponSlot = 5;
                firingDelay = 0;
                guy.SetWeapon("minigun");
                hud.UpdateWeaponInfo("Minigun", guy.CurrentWeaponAmmo());
            }
            #endregion
        }

        public void CollideBulletsWithEnemies()
        {
            foreach (Bullet b in lstOfBullets)
            {
                if (b.Alive())
                {
                    foreach (Enemy e in lstOfEnemies)
                    {
                        if (e.Alive() && e.Visible() && e.Rect().IntersectsWith(b.Rect()))
                        {
                            e.LoseHealth(b.Damage());
                            b.Kill();
                            if (b.Type() == "ice")
                            {
                                e.Ice();
                            }
                            if (!e.Alive() && b.IsPlayerBullet())
                            {
                                guy.GainMoney(e.Value());
                            }
                            break;
                        }
                    }
                }
                else if (!b.Alive())
                {
                    break;
                }
            }

            foreach (Rocket r in lstOfRockets)
            {
                if (r.Alive())
                {
                    foreach (Enemy e in lstOfEnemies)
                    {
                        if (e.Alive() && e.Visible() && e.Rect().IntersectsWith(r.Rect()))
                        {
                            e.LoseHealth(r.Damage());
                            r.Kill();
                            break;
                        }
                    }
                }
                else if (!r.Alive())
                {
                    break;
                }
            }
        }

        public bool EnemiesAlive()
        {
            foreach (Enemy e in lstOfEnemies)
            {
                if (e.Alive())
                {
                    return true;
                }
            }
            return false;
        }

        public void Enemies()
        {
            waveBreakTime--;
            bombSpawnCounter++;
            if (bombSpawnCounter > 300)
            {
                bombSpawnCounter = 0;
                int turretStrenght = 0;

                foreach (Turret t in lstOfTurrets)
                {
                    if (t.Alive())
                        turretStrenght += t.Level();
                }
                if (waveBreakTime <= 0)
                {
                    for (int i = 0; i < turretStrenght / 4; i++)
                    {
                        lstOfEnemies.Add(new Enemy(random, "bomb", lstOfTurrets));
                    }
                }
            }

            enemySpawnCounter--;
            if (enemySpawnCounter <= 0 && waveSystem.EnemiesLeftToSend() && waveBreakTime <= 0)
            {
                enemySpawnCounter = random.Next(5, longestSpawnTime);
                bool x = false;
                foreach (Enemy e in lstOfEnemies)
                {
                    if (!e.Alive())
                    {                        
                        e.MakeRecycleEnemy(random, waveSystem.GetNextEnemyToSendOut(), lstOfTurrets);
                        x = true;
                        break;
                    }
                }
                if (x == false)
                {
                    lstOfEnemies.Add(new Enemy(random, waveSystem.GetNextEnemyToSendOut(), lstOfTurrets));   
                }
            }

            SortEnemies();
            bool died = false;
            foreach (Enemy en in lstOfEnemies)
            {
                if (en.Alive())
                {
                    en.Animate();
                    en.AttackStuff();
                    en.LoseIcedTime();
                    //see if collided with turret or guy to cause damage
                    //and move
                    List<Object> returnedList = en.Move(guy.CollisionRect(), lstOfTurrets, board, shadeArray);
                    Turret t = (Turret)returnedList[0];
                    bool collidedWithGuy = (bool)returnedList[1];

                    if (t != null)
                    {
                        foreach (Turret t2 in lstOfTurrets)
                        {
                            if (t == t2)
                            {
                                t2.LoseHealth(en.TurretDamage());
                                board[t2.ArrayX(), t2.ArrayY()] = 0;
                            }
                        }
                    }
                    if (collidedWithGuy && en.Alive())
                    {
                        guy.TakeDamage(en.PlayerDamage());
                        hud.UpdateHealth(guy.Health());
                        if (guy.Health() <= 0)
                        {
                            died = true;
                        }
                    }
                }
                else if (!en.Alive())
                {
                    break;
                }
            }
            if (died)
            {
                RunGame = false;
                MessageBox.Show("You reached wave " + waveSystem.CurrentWave(), "Game Over");
                Reset();
            }
        }

        public void CreateBullets()
        {
            if (guy.CurrentWeaponAmmo() != 0)
            {
                guy.IsFiring(true);
                fireCounter = 0;

                //Calculate x, y for tip of gun
                double angle = guy.GetAngle(mouseX, mouseY);
                angle = angle * 2 * Math.PI / 360;
                //GetAngle gets angle from guys head, not gun, so have to adjust it
                angle = angle + .27;

                //21.8 is hypotenuse from hat to gun tip
                double yPos = 21.8 * Math.Sin(angle);
                double xPos = 21.8 * Math.Cos(angle);

                #region Pistol Bullets
                if (guy.CurrentWeapon() == "pistol")
                {
                    //pistolShot.Play();
                    bool x = false;
                    Rectangle rect = guy.Rect();
                    foreach (Bullet b in lstOfBullets)
                    {
                        if (!b.Alive())
                        {
                            b.MakeReuseBullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "pistol");
                            x = true;
                            break;
                        }
                    }
                    if (x == false)
                    {
                        lstOfBullets.Add(new Bullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "pistol"));
                    }
                    guy.LoseAmmo();
                }
                #endregion

                #region SniperBullets
                else if (guy.CurrentWeapon() == "sniper")
                {
                    //sniperShot.Play();
                    bool x = false;
                    Rectangle rect = guy.Rect();
                    foreach (Bullet b in lstOfBullets)
                    {
                        if (!b.Alive())
                        {
                            b.MakeReuseBullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "sniper");
                            x = true;
                            break;
                        }
                    }
                    if (x == false)
                    {
                        lstOfBullets.Add(new Bullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "sniper"));
                    }
                    guy.LoseAmmo();
                    hud.UpdateWeaponAmmo(guy.CurrentWeaponAmmo());
                }
                #endregion

                #region Minigun Bullets
                else if (guy.CurrentWeapon() == "minigun")
                {
                    if (!minigunFiring)
                    {
                        //minigunShot.Play();
                        minigunFiring = true;
                    }
                    int numberBulletsToMake = random.Next(1, 4);
                    for (int i = 0; i < numberBulletsToMake; i++)
                    {
                        bool x = false;
                        Rectangle rect = guy.Rect();
                        foreach (Bullet b in lstOfBullets)
                        {
                            if (!b.Alive())
                            {
                                b.MakeReuseBullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "minigun");
                                x = true;
                                break;
                            }
                        }
                        if (x == false)
                        {
                            lstOfBullets.Add(new Bullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "minigun"));
                        }
                    }
                    guy.LoseAmmo();
                    hud.UpdateWeaponAmmo(guy.CurrentWeaponAmmo());
                }
                #endregion

                #region Smg Bullets
                else if (guy.CurrentWeapon() == "smg")
                {
                    //smgShot.Play();
                    bool x = false;
                    Rectangle rect = guy.Rect();
                    foreach (Bullet b in lstOfBullets)
                    {
                        if (!b.Alive())
                        {
                            b.MakeReuseBullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "smg");
                            x = true;
                            break;
                        }
                    }
                    if (x == false)
                    {
                        lstOfBullets.Add(new Bullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), "smg"));
                    }
                    guy.LoseAmmo();
                    hud.UpdateWeaponAmmo(guy.CurrentWeaponAmmo());
                }
                #endregion

                #region Shotgun Bullets
                else if (guy.CurrentWeapon() == "shotgun")
                {
                    //shotgunShot.Play();
                    bool x = false;
                    Rectangle rect = guy.Rect();
                    for (int i = 1; i < 4; i++)
                    {
                        x = false;
                        foreach (Bullet b in lstOfBullets)
                        {
                            if (!b.Alive())
                            {
                                b.MakeReuseBullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), i);
                                x = true;
                                break;
                            }
                        }
                        if (x == false)
                        {
                            lstOfBullets.Add(new Bullet(mouseX, mouseY, (int)(rect.X + xPos + 8), (int)(rect.Y + yPos + 12), i));
                        }
                    }
                    guy.LoseAmmo();
                    hud.UpdateWeaponAmmo(guy.CurrentWeaponAmmo());
                }
                #endregion
            }
        }

        public void MoveBullets()
        {
            foreach (Bullet b in lstOfBullets)
            {
                if (b.Alive())
                {
                    b.CheckForOffScreen(Width, Height);
                    b.Move();
                }
                else if (!b.Alive())
                {
                    break;
                }
            }
        }

        public void MoveRockets()
        {
            foreach (Rocket r in lstOfRockets)
            {
                if (r.Alive())
                {
                    r.CheckForOffScreen(Width, Height);
                    int x = lstOfEnemies.IndexOf(r.Target());
                    r.SendNewTargetCoordinates(lstOfEnemies[x]);                    
                    r.Move();
                }
            }
        }

        public void SortBullets()
        {
            lstOfBullets.Sort(delegate(Bullet b1, Bullet b2)
            {
                int x = (b1.Alive().CompareTo(b2.Alive()));
                x = -x;
                return x;
            });
        }

        public void SortTurrets()
        {
            lstOfTurrets.Sort(delegate(Turret t1, Turret t2)
            {
                int x = (t1.Alive().CompareTo(t2.Alive()));
                x = -x;
                return x;
            });
        }

        public void SortRockets()
        {
            lstOfRockets.Sort(delegate(Rocket r1, Rocket r2)
            {
                int x = (r1.Alive().CompareTo(r2.Alive()));
                x = -x;
                return x;
            });
        }

        public void SortEnemies()
        {
            lstOfEnemies.Sort(delegate(Enemy e1, Enemy e2)
            {
                int x = (e1.Alive().CompareTo(e2.Alive()));
                x = -x;
                return x;
            });
        }

        public void CollidePickups()
        {
            foreach (Pickup_Object p in lstOfPickups)
            {
                if (p.Rect().IntersectsWith(guy.Rect()) && p.Alive())
                {
                    if (p.Type() == "health")
                    {
                        guy.GainHealth(random.Next(1, 3));
                        p.Kill();
                        hud.UpdateHealth(guy.Health());
                    }
                    else if (p.Type() == "flare")
                    {
                        guy.AddFlare(random.Next(1, 4));
                        p.Kill();
                        hud.UpdateFlares(guy.Flares());
                    }
                }
            }
        }

        void gameTimer_Tick(object sender, EventArgs e)
        {
            hud.UpdateMoney(guy.Money());

            if (hud.IsPlacingTurret())
            {
                RunGame = false;
            }
            if (RunGame)
            {
                healthPackSpawnTime++;
                if (healthPackSpawnTime >= 1800)
                {
                    healthPackSpawnTime = 0;
                    bool aliveHealthPac = false;
                    foreach (Pickup_Object p in lstOfPickups)
                    {
                        if (p.Alive() && p.Type() == "health")
                        {
                            aliveHealthPac = true;
                        }
                    }
                    if (!aliveHealthPac)
                    {
                        lstOfPickups.Add(new Pickup_Object("health", random));
                    }
                }
                flareSpawnCounter++;
                if (flareSpawnCounter >= 3600)
                {
                    flareSpawnCounter = 0;
                    bool AliveFlare = false;
                    foreach (Pickup_Object p in lstOfPickups)
                    {
                        if (p.Alive() && p.Type() == "health")
                        {
                            AliveFlare = true;
                        }
                    }
                    if (!AliveFlare)
                    {
                        lstOfPickups.Add(new Pickup_Object("flare", random));
                    }
                }

                //New wave
                if (!waveSystem.EnemiesLeftToSend() && !EnemiesAlive())
                {
                    waveBreakTime = 200;
                    waveTextToDisplay = "Wave Completed";
                    waveTextDispTime = 120;
                    lstOfBullets.Clear();
                    lstOfEnemies.Clear();
                    lstOfRockets.Clear();
                    lstOfPickups.Clear();
                    waveSystem.CalculateEnemiesForNextWave();
                    hud.UpdateWave(waveSystem.CurrentWave());
                    int x = waveSystem.CurrentWave();
                    if (x == 5)
                    {
                        textToDisplay = "Got SMG";
                        textDisplayTime = 60;
                        weaponCanSelect[2] = true;
                    }
                    else if (x == 10)
                    {
                        textToDisplay = "Got Shotgun";
                        textDisplayTime = 60;
                        weaponCanSelect[3] = true;
                    }
                    else if (x == 15)
                    {
                        textToDisplay = "Got Sniper";
                        textDisplayTime = 60;
                        weaponCanSelect[4] = true;
                    }
                    else if (x == 25)
                    {
                        textToDisplay = "Got Minigun";
                        textDisplayTime = 60;
                        weaponCanSelect[5] = true;
                    }
                    if (((decimal)waveSystem.CurrentWave() / 5) == Math.Floor((decimal)waveSystem.CurrentWave() / 5))
                    {
                        longestSpawnTime -= 1;
                        if (longestSpawnTime < 17)
                        {
                            longestSpawnTime = 17;
                        }
                    }
                }

                double currentTime = DateTime.Now.Ticks;
                if (currentTime - placeHolderTime >= 10000000)
                {
                    placeHolderTime = DateTime.Now.Ticks;
                    lblFps.Text = Convert.ToString(frames);
                    frames = 0;
                }
                foreach (Flare f in lstOfFlares)
                {
                    f.DecreaseBurnOutTime();
                }

                frames++;

                SortTurrets();
                SortEnemies();
                TurretEverything();

                SortEnemies();
                Enemies();

                fireCounter++;
                if (mouseIsDown && !hud.IsPlacingTurret())
                {
                    if (fireCounter > firingDelay)
                    {
                        CreateBullets();
                    }
                }

                SortRockets();
                SortBullets();
                CollideBulletsWithEnemies();

                CollidePickups();

                SortBullets();
                MoveBullets();

                MoveRockets();

                guy.Move(lstOfTurrets, lstOfEnemies);

                guy.Animate();
                guy.RechargeAmmo();
                if (guy.CurrentWeapon() != "pistol")
                    hud.UpdateWeaponAmmo(guy.CurrentWeaponAmmo());

                SortBullets();
                SortEnemies();
                SortTurrets();
            }
            Invalidate();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (Turret t in lstOfTurrets)
            {
                if (t.Alive())
                {
                    t.DrawBase(g);
                    if (t.CurrentTarget() != null)
                    {
                        Enemy q = t.CurrentTarget();
                        rotationMatrix.RotateAt(t.GetAngle(q.Rect().X + (q.Rect().Width / 2), q.Rect().Y + (q.Rect().Height / 2)),
                            new Point(t.Rect().X + (t.Rect().Width / 2), t.Rect().Y + (t.Rect().Height / 2)));
                        g.Transform = rotationMatrix;
                        t.DrawGun(g);
                        g.ResetTransform();
                        rotationMatrix.Reset();
                    }
                    else
                    {
                        rotationMatrix.RotateAt(t.OldAngle(), new Point(t.Rect().X + (t.Rect().Width / 2), t.Rect().Y + (t.Rect().Height / 2)));
                        g.Transform = rotationMatrix;
                        t.DrawGun(g);
                        g.ResetTransform();
                        rotationMatrix.Reset();
                    }
                }
                else
                {
                    break;
                }
            }
            foreach (Rocket r in lstOfRockets)
            {
                if (r.Alive())
                {
                    rotationMatrix.RotateAt(r.GetAngle(), new Point(r.Rect().X + 3, r.Rect().Y + 1));
                    g.Transform = rotationMatrix;
                    r.Draw(g);
                    g.ResetTransform();
                    rotationMatrix.Reset();
                }
            }
            foreach (Pickup_Object p in lstOfPickups)
            {
                if (p.Alive())
                    p.Draw(g);
            }
            foreach (Bullet b in lstOfBullets)
            {
                if (b.Alive())
                    b.Draw(g);
            }
            foreach (Flare f in lstOfFlares)
            {
                if (f.Alive())
                    f.Draw(g);
            }
            foreach (Enemy en in lstOfEnemies)
            {
                if (en.Alive() && en.Visible())
                {
                    rotationMatrix.RotateAt(en.GetAngle(guy.Rect()), new Point(en.Rect().X + 15, en.Rect().Y + 15));
                    g.Transform = rotationMatrix;
                    en.Draw(g);
                    g.ResetTransform();
                    rotationMatrix.Reset();
                }
            }
            if (hud.IsPlacingTurret())
            {                
                hud.Draw(g);
            }

            rotationMatrix.RotateAt(guy.GetAngle(mouseX, mouseY), new Point(guy.Rect().X + 8, guy.Rect().Y + 12));
            g.Transform = rotationMatrix;
            guy.Draw(g);
            g.ResetTransform();
            rotationMatrix.Reset();


            List<Object> lstOfThings = flashLight.Draw(g, guy.Rect(), lstOfTurrets, lstOfFlares);
            shadeArray = (int[,])lstOfThings[0];
            lstOfTurrets = (List<Turret>)lstOfThings[1];
            lstOfFlares = (List<Flare>)lstOfThings[2];

            if (textDisplayTime > 0)
            {
                textDisplayTime--;
                g.DrawString(textToDisplay, new Font("Courier New", 12), brush, new PointF(350, 300));
            }

            if (waveTextDispTime > 60)
            {
                waveTextDispTime--;
                g.DrawString(waveTextToDisplay, new Font("Courier New", 12), brush, new PointF(340, 330));
            }
            else if (waveTextDispTime > 0 && waveTextDispTime <= 60)
            {
                waveTextDispTime--;
                waveTextToDisplay = "Wave " + waveSystem.CurrentWave().ToString();
                g.DrawString(waveTextToDisplay, new Font("Courier New", 12), brush, new PointF(340, 330));
            }

            if (!RunGame)
            {
                g.DrawString("Paused", new Font("Courier New", 12), brush, new PointF(350, 300));
            }
        }
    }

}
