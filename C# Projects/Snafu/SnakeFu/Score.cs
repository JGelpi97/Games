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
    class Score
    {
        Panel pnlMain = new Panel();
        Label lblRed = new Label();
        Label lblBlue = new Label();
        Label lblGreen = new Label();
        Label lblYellow = new Label();
        Label lblScore = new Label();

        public Score()
        {
            pnlMain.Top = 580;
            pnlMain.Left = 0;
            pnlMain.Width = 400;
            pnlMain.Height = 70;
            pnlMain.Controls.Add(lblBlue);
            pnlMain.Controls.Add(lblRed);
            pnlMain.Controls.Add(lblYellow);
            pnlMain.Controls.Add(lblGreen);
            pnlMain.Controls.Add(lblScore);

            lblScore.Font = new Font("Courier New", 14, FontStyle.Bold);
            lblRed.Font = new Font("Courier New", 24, FontStyle.Bold);
            lblBlue.Font = new Font("Courier New", 24, FontStyle.Bold);
            lblGreen.Font = new Font("Courier New", 24, FontStyle.Bold);
            lblYellow.Font = new Font("Courier New", 24, FontStyle.Bold);

            lblScore.Left = 177;
            lblScore.Top = 2;
            lblScore.Text = "Scores";

            lblRed.Left = 50;
            lblRed.Top = 21;
            lblRed.Text = "0";

            lblBlue.Left = 150;
            lblBlue.Top = 21;
            lblBlue.Text = "0";

            lblGreen.Left = 250;
            lblGreen.Top = 21;
            lblGreen.Text = "0";
            
            lblYellow.Left = 350;
            lblYellow.Top = 21;
            lblYellow.Text = "0";

            lblScore.AutoSize = true;
            lblRed.AutoSize = true;
            lblBlue.AutoSize = true;
            lblGreen.AutoSize = true;
            lblYellow.AutoSize = true;

            lblRed.ForeColor = Color.Red;
            lblBlue.ForeColor = Color.Blue;
            lblYellow.ForeColor = Color.Yellow;
            lblGreen.ForeColor = Color.LightGreen;
        }

        public Panel GetPanel()
        {
            return pnlMain;
        }

        public void ChangeScores(string x)
        {
            if (x == "red")
            {
                int q = Convert.ToInt16(lblRed.Text);
                q++;
                lblRed.Text = Convert.ToString(q);
            }
            else if (x == "blue")
            {
                int q = Convert.ToInt16(lblBlue.Text);
                q++;
                lblBlue.Text = Convert.ToString(q);
            }
            else if (x == "green")
            {
                int q = Convert.ToInt16(lblGreen.Text);
                q++;
                lblGreen.Text = Convert.ToString(q);
            }
            else if (x == "yellow")
            {
                int q = Convert.ToInt16(lblYellow.Text);
                q++;
                lblYellow.Text = Convert.ToString(q);
            }
        }

    }
}
