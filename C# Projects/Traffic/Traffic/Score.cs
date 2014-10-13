using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Traffic
{
    class Score
    {
        Label lblScore = new Label();
        Label lblHighScore = new Label();
        Label lblHelp = new Label();
        int points = 0;
        int highScore = 0;

        public void CheckHighScore()
        {
            if (points > highScore)
            {
                highScore = points;
                lblHighScore.Text = "High Score: " + highScore;
            }
        }

        public Score()
        {
            lblScore.Text = "Score: " + points;
            lblScore.Font = new Font("Courier New", 12);
            lblScore.AutoSize = true;
            lblScore.Left = 10;
            lblScore.Top = 10;
            lblScore.BackColor = Color.Black;
            lblScore.ForeColor = Color.White;

            lblHighScore.Text = "High Score: " + highScore;
            lblHighScore.Font = new Font("Courier New", 12);
            lblHighScore.AutoSize = true;
            lblHighScore.Left = 10;
            lblHighScore.Top = 30;
            lblHighScore.BackColor = Color.Black;
            lblHighScore.ForeColor = Color.White;

            lblHelp.Text = "Press Q to restart.\nPress Space to pause.";
            lblHelp.Font = new Font("Courier New", 12);
            lblHelp.AutoSize = true;
            lblHelp.Left = 10;
            lblHelp.Top = 480;
            lblHelp.BackColor = Color.Black;
            lblHelp.ForeColor = Color.White;
        }

        public Label GetHelpLbl()
        {
            return lblHelp;
        }

        public Label GetHighScoreLbl()
        {
            return lblHighScore;
        }

        public Label GetScoreLbl()
        {
            return lblScore;
        }

        public void AddPoint()
        {
            points++;
            lblScore.Text = "Score: " + points;
        }

        public void Reset()
        {
            points = 0;
            lblScore.Text = "Score: " + points;
        }
    }
}
