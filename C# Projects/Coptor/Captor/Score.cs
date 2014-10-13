using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Captor
{    
    class Score
    {
        int currentScore;
        int highScore;
        Label lblCurrentScore = new Label();
        Label lblHighScore = new Label();

        public Score()
        {           
            lblCurrentScore.Text = "Distance: 0";
            lblCurrentScore.Location = new Point(10, 545);
            lblCurrentScore.BackColor = Color.Black;
            lblCurrentScore.ForeColor = Color.White;
            lblCurrentScore.AutoSize = true;
            lblCurrentScore.Font = new Font("Courier New", 10);
            lblHighScore.Text = "High Score: 0";
            lblHighScore.Location = new Point(140, 545);
            lblHighScore.BackColor = Color.Black;
            lblHighScore.ForeColor = Color.White;
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Courier New", 10);
        }       

        public void IncreaseScore()
        {
            currentScore++;
            lblCurrentScore.Text = "Distance: " + currentScore;
        }

        public Label GetCurrentScoreLabel()
        {
            return lblCurrentScore;
        }

        public Label GetHighScoreLabel()
        {
            return lblHighScore;
        }

        public void ResetScore()
        {
            currentScore = 0;
            lblCurrentScore.Text = "Distance: 0";
        }

        public void CheckForRecord()
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                lblHighScore.Text = "High Score: " + Convert.ToString(currentScore);
            }
        }

    }
}
