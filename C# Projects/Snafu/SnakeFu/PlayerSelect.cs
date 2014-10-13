using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeFu
{
    class PlayerSelect
    {
        Panel pnl = new Panel();
        Label lblPlayers = new Label();
        NumericUpDown numPlayers = new NumericUpDown();
        Button btnPlayers = new Button();

        decimal players;

        public PlayerSelect()
        {
            pnl.BorderStyle = BorderStyle.FixedSingle;

            pnl.Width = 250;
            pnl.Height = 150;
            pnl.Left = 230;
            pnl.Top = 200;
            pnl.Controls.Add(numPlayers);
            pnl.Controls.Add(lblPlayers);
            pnl.Controls.Add(btnPlayers);

            btnPlayers.Left = 85;
            btnPlayers.Top = 110;
            btnPlayers.Font = new Font("Courier New", 10);
            btnPlayers.Text = "OK";

            lblPlayers.Text = "Number of Players";
            lblPlayers.Font = new Font("Courier New", 13);
            lblPlayers.AutoSize = true;
            lblPlayers.Left = 25;
            lblPlayers.Top = 10;

            numPlayers.Font = new Font("Courier New", 20);
            numPlayers.Width = 38;
            numPlayers.Left = 105;
            numPlayers.Top = 50;
            numPlayers.Minimum = 2;
            numPlayers.Maximum = 4;
            numPlayers.Value = 4;

            numPlayers.KeyDown += new KeyEventHandler(numPlayers_KeyDown);
            btnPlayers.Click += new EventHandler(btnOk_Click);
        }

        public NumericUpDown GetNumPlayersControl()
        {
            return numPlayers;
        }

        void numPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            players = numPlayers.Value;
            players = numPlayers.Value;
            pnl.Visible = false;
        }

        public decimal GetNumOfPlayers()
        {
            return players;
        }

        public Panel GetPnl()
        {
            return pnl;
        }

        public Button GetBtn()
        {
            return btnPlayers;
        }
    }

}
