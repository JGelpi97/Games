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
    class LevelSelector
    {
        Panel pnlMain = new Panel();
        Label lbl1 = new Label();
        TextBox txtInput = new TextBox();
        Button btn1 = new Button();
        Button btnCancel = new Button();
        string levelCode;

        public LevelSelector()
        {
            pnlMain.Controls.Add(lbl1);
            pnlMain.Controls.Add(txtInput);
            pnlMain.Controls.Add(btn1);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Left = 100;
            pnlMain.Top = 100;
            pnlMain.Width = 140;
            pnlMain.Height = 140;
            pnlMain.Visible = false;
            pnlMain.Enabled = false;
            lbl1.AutoSize = true;
            lbl1.Text = "Enter Level Code:";
            lbl1.Left = 10;
            lbl1.Top = 30;
            lbl1.Font = new Font("Courier New", 9);
            txtInput.Left = 20;
            txtInput.Top = 60;
            txtInput.TabStop = false;
            txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            btn1.Text = "Ok";
            btn1.Left = 25;
            btn1.Top = 92;
            btn1.Height = 30;
            btn1.Width = 90;
            btn1.Click += new EventHandler(btn1_Click);
            btnCancel.Text = "X";
            btnCancel.Width = 20;
            btnCancel.Height = 20;
            btnCancel.Left = 117;
            btnCancel.Top = 1;
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                levelCode = txtInput.Text;
                txtInput.Text = "";
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            pnlMain.Enabled = false;
            pnlMain.Visible = false;
            txtInput.Text = "";
        }

        public void SetVisibility(bool bork)
        {
            pnlMain.Visible = bork;
        }

        public void Focus()
        {
            txtInput.Focus();
        }

        public TextBox GetTxt()
        {
            return txtInput;
        }

        void btn1_Click(object sender, EventArgs e)
        {
            levelCode = txtInput.Text;
            txtInput.Text = "";
        }

        public Panel GetPanel()
        {
            return pnlMain;
        }

        public Button GetButton()
        {
            return btn1;
        }

        public string LevelCode()
        {
            return levelCode;
        }

        public void SetEnabled(bool bork)
        {
            pnlMain.Enabled = bork;
        }
    }
}
