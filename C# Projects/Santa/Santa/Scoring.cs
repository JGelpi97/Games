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

namespace Santa
{
    class Scoring
    {
        int points = 0;
        Label lblPoints = new Label();
        Rectangle rect = new Rectangle();
        Bitmap bmp = new Bitmap(Santa.Properties.Resources.Score);
        ImageAttributes attr = new ImageAttributes();

        public Scoring()
        {
            attr.SetColorKey(Color.FromArgb(250, 0, 250), Color.FromArgb(250, 0, 250));
            lblPoints.Text = "Points:" + points;
            lblPoints.Left = 664;
            lblPoints.Top = 28;
            lblPoints.AutoSize = true;
            lblPoints.BackColor = Color.Transparent;
            lblPoints.Font = new Font("Courier New" , 12, FontStyle.Bold);
            
            rect.X = 650;
            rect.Y = 10;
            rect.Width = bmp.Width;
            rect.Height = bmp.Height;
        }

        public void Reset()
        {
            points = 0;
            lblPoints.Text = "Points:" + points;
        }

        public int GetPoints()
        {
            return points;
        }

        public void UpdatePoints(int x)
        {
            points += x;
            lblPoints.Text = "Points:" + points;
        }

        public Label GetPointsLbl()
        {
            return lblPoints;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, rect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
        }

    }
}
