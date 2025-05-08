namespace sims.Splash_page_and_Loading_Screen
{
    partial class Splash_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash_page));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.getStartedBtn = new Guna.UI.WinForms.GunaButton();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.GunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GunaElipse1
            // 
            this.GunaElipse1.Radius = 10;
            this.GunaElipse1.TargetControl = this;
            // 
            // getStartedBtn
            // 
            this.getStartedBtn.AnimationHoverSpeed = 0.07F;
            this.getStartedBtn.AnimationSpeed = 0.03F;
            this.getStartedBtn.BackColor = System.Drawing.Color.Transparent;
            this.getStartedBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.getStartedBtn.BorderColor = System.Drawing.Color.Black;
            this.getStartedBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getStartedBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.getStartedBtn.FocusedColor = System.Drawing.Color.Empty;
            this.getStartedBtn.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStartedBtn.ForeColor = System.Drawing.Color.White;
            this.getStartedBtn.Image = null;
            this.getStartedBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.getStartedBtn.Location = new System.Drawing.Point(35, 248);
            this.getStartedBtn.Name = "getStartedBtn";
            this.getStartedBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.getStartedBtn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.getStartedBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.getStartedBtn.OnHoverImage = null;
            this.getStartedBtn.OnPressedColor = System.Drawing.Color.Black;
            this.getStartedBtn.Radius = 6;
            this.getStartedBtn.Size = new System.Drawing.Size(307, 52);
            this.getStartedBtn.TabIndex = 12;
            this.getStartedBtn.Text = "Get Started";
            this.getStartedBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.getStartedBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.getStartedBtn.Click += new System.EventHandler(this.getStartedBtn_Click);
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.GunaLabel1.Location = new System.Drawing.Point(26, 97);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(480, 102);
            this.GunaLabel1.TabIndex = 11;
            this.GunaLabel1.Text = "SALES AND INVENTORY SYSTEM \r\nFOR SOOTHING CAFÉ";
            this.GunaLabel1.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // GunaPictureBox1
            // 
            this.GunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.GunaPictureBox1.Image = global::sims.Properties.Resources.sales_and_inventory;
            this.GunaPictureBox1.Location = new System.Drawing.Point(539, 69);
            this.GunaPictureBox1.Name = "GunaPictureBox1";
            this.GunaPictureBox1.Size = new System.Drawing.Size(332, 282);
            this.GunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GunaPictureBox1.TabIndex = 13;
            this.GunaPictureBox1.TabStop = false;
            // 
            // Splash_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 448);
            this.Controls.Add(this.GunaPictureBox1);
            this.Controls.Add(this.getStartedBtn);
            this.Controls.Add(this.GunaLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash_page";
            ((System.ComponentModel.ISupportInitialize)(this.GunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        internal Guna.UI.WinForms.GunaElipse GunaElipse1;
        internal Guna.UI.WinForms.GunaPictureBox GunaPictureBox1;
        internal Guna.UI.WinForms.GunaButton getStartedBtn;
        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
    }
}