namespace Santa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.btnCloseHelp = new System.Windows.Forms.Button();
            this.btnOpenHelp = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.picGameOver = new System.Windows.Forms.PictureBox();
            this.pnlHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackgroundImage = global::Santa.Properties.Resources.HelpScren;
            this.pnlHelp.Controls.Add(this.btnCloseHelp);
            this.pnlHelp.Location = new System.Drawing.Point(12, 12);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(770, 550);
            this.pnlHelp.TabIndex = 0;
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.BackColor = System.Drawing.Color.White;
            this.btnCloseHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseHelp.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseHelp.Location = new System.Drawing.Point(661, 512);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(75, 23);
            this.btnCloseHelp.TabIndex = 0;
            this.btnCloseHelp.Text = "Close";
            this.btnCloseHelp.UseVisualStyleBackColor = false;
            this.btnCloseHelp.Click += new System.EventHandler(this.btnCloseHelp_Click);
            this.btnCloseHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // btnOpenHelp
            // 
            this.btnOpenHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenHelp.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnOpenHelp.FlatAppearance.BorderSize = 3;
            this.btnOpenHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOpenHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOpenHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenHelp.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenHelp.Location = new System.Drawing.Point(680, 120);
            this.btnOpenHelp.Name = "btnOpenHelp";
            this.btnOpenHelp.Size = new System.Drawing.Size(80, 30);
            this.btnOpenHelp.TabIndex = 1;
            this.btnOpenHelp.TabStop = false;
            this.btnOpenHelp.Text = "Help";
            this.btnOpenHelp.UseVisualStyleBackColor = false;
            this.btnOpenHelp.Click += new System.EventHandler(this.btnOpenHelp_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Transparent;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnPause.FlatAppearance.BorderSize = 3;
            this.btnPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(680, 162);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 30);
            this.btnPause.TabIndex = 2;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // picGameOver
            // 
            this.picGameOver.Image = global::Santa.Properties.Resources.Gameover;
            this.picGameOver.Location = new System.Drawing.Point(39, 430);
            this.picGameOver.Name = "picGameOver";
            this.picGameOver.Size = new System.Drawing.Size(722, 78);
            this.picGameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGameOver.TabIndex = 3;
            this.picGameOver.TabStop = false;
            this.picGameOver.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnOpenHelp);
            this.Controls.Add(this.picGameOver);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGameOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Button btnCloseHelp;
        private System.Windows.Forms.Button btnOpenHelp;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.PictureBox picGameOver;

    }
}

