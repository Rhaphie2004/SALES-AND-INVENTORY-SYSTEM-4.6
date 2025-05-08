namespace sims.Splash_page_and_Loading_Screen
{
    partial class Loading_Screen_Staff
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
            this.components = new System.ComponentModel.Container();
            this.GunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.GunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.GunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.GunaProgressBar1 = new Guna.UI.WinForms.GunaProgressBar();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.GunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.GunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GunaLabel4
            // 
            this.GunaLabel4.AutoSize = true;
            this.GunaLabel4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel4.ForeColor = System.Drawing.Color.Black;
            this.GunaLabel4.Location = new System.Drawing.Point(361, 247);
            this.GunaLabel4.Name = "GunaLabel4";
            this.GunaLabel4.Size = new System.Drawing.Size(85, 28);
            this.GunaLabel4.TabIndex = 52;
            this.GunaLabel4.Text = "Loading...";
            // 
            // GunaLabel3
            // 
            this.GunaLabel3.AutoSize = true;
            this.GunaLabel3.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel3.ForeColor = System.Drawing.Color.Black;
            this.GunaLabel3.Location = new System.Drawing.Point(110, 110);
            this.GunaLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.GunaLabel3.Name = "GunaLabel3";
            this.GunaLabel3.Size = new System.Drawing.Size(297, 84);
            this.GunaLabel3.TabIndex = 51;
            this.GunaLabel3.Text = "SALES AND INVENTORY \r\nSYSTEM";
            this.GunaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GunaLabel2
            // 
            this.GunaLabel2.AutoSize = true;
            this.GunaLabel2.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel2.Location = new System.Drawing.Point(58, 241);
            this.GunaLabel2.Name = "GunaLabel2";
            this.GunaLabel2.Size = new System.Drawing.Size(46, 37);
            this.GunaLabel2.TabIndex = 50;
            this.GunaLabel2.Text = "0%";
            // 
            // GunaProgressBar1
            // 
            this.GunaProgressBar1.BorderColor = System.Drawing.Color.Black;
            this.GunaProgressBar1.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.GunaProgressBar1.IdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.GunaProgressBar1.Location = new System.Drawing.Point(65, 209);
            this.GunaProgressBar1.Name = "GunaProgressBar1";
            this.GunaProgressBar1.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.GunaProgressBar1.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.GunaProgressBar1.Size = new System.Drawing.Size(381, 29);
            this.GunaProgressBar1.TabIndex = 49;
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel1.Location = new System.Drawing.Point(207, 37);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(164, 37);
            this.GunaLabel1.TabIndex = 48;
            this.GunaLabel1.Text = "Soothing Café";
            // 
            // GunaElipse1
            // 
            this.GunaElipse1.Radius = 10;
            this.GunaElipse1.TargetControl = this;
            // 
            // Timer1
            // 
            this.Timer1.Interval = 20;
            // 
            // GunaPictureBox1
            // 
            this.GunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.GunaPictureBox1.Image = global::sims.Properties.Resources.logo_soothing_cafe;
            this.GunaPictureBox1.Location = new System.Drawing.Point(130, 15);
            this.GunaPictureBox1.Name = "GunaPictureBox1";
            this.GunaPictureBox1.Size = new System.Drawing.Size(70, 70);
            this.GunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GunaPictureBox1.TabIndex = 47;
            this.GunaPictureBox1.TabStop = false;
            // 
            // Loading_Screen_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 310);
            this.Controls.Add(this.GunaLabel4);
            this.Controls.Add(this.GunaLabel3);
            this.Controls.Add(this.GunaLabel2);
            this.Controls.Add(this.GunaProgressBar1);
            this.Controls.Add(this.GunaLabel1);
            this.Controls.Add(this.GunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading_Screen_Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading_Screen_Staff";
            this.Load += new System.EventHandler(this.Loading_Screen_Staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Guna.UI.WinForms.GunaLabel GunaLabel4;
        internal Guna.UI.WinForms.GunaLabel GunaLabel3;
        internal Guna.UI.WinForms.GunaLabel GunaLabel2;
        internal Guna.UI.WinForms.GunaProgressBar GunaProgressBar1;
        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
        internal Guna.UI.WinForms.GunaPictureBox GunaPictureBox1;
        internal Guna.UI.WinForms.GunaElipse GunaElipse1;
        internal System.Windows.Forms.Timer Timer1;
    }
}