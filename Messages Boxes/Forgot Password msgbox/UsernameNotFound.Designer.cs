namespace sims.Messages_Boxes.Forgot_Password_msgbox
{
    partial class UsernameNotFound
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
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.ContinueBtn = new Guna.UI.WinForms.GunaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 12;
            this.gunaElipse1.TargetControl = this;
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.AnimationHoverSpeed = 0.07F;
            this.ContinueBtn.AnimationSpeed = 0.03F;
            this.ContinueBtn.BackColor = System.Drawing.Color.Transparent;
            this.ContinueBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ContinueBtn.BorderColor = System.Drawing.Color.Black;
            this.ContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContinueBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ContinueBtn.FocusedColor = System.Drawing.Color.Empty;
            this.ContinueBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueBtn.ForeColor = System.Drawing.Color.White;
            this.ContinueBtn.Image = null;
            this.ContinueBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.ContinueBtn.Location = new System.Drawing.Point(345, 207);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ContinueBtn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.ContinueBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.ContinueBtn.OnHoverImage = null;
            this.ContinueBtn.OnPressedColor = System.Drawing.Color.Black;
            this.ContinueBtn.Radius = 5;
            this.ContinueBtn.Size = new System.Drawing.Size(175, 36);
            this.ContinueBtn.TabIndex = 45;
            this.ContinueBtn.Text = "OK";
            this.ContinueBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 34);
            this.label2.TabIndex = 44;
            this.label2.Text = "Double check your username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 48);
            this.label1.TabIndex = 43;
            this.label1.Text = "USERNAME NOT FOUND";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::sims.Properties.Resources.warning_sign_icon_transparent_ba;
            this.gunaPictureBox1.Location = new System.Drawing.Point(28, 64);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Radius = 6;
            this.gunaPictureBox1.Size = new System.Drawing.Size(230, 216);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 42;
            this.gunaPictureBox1.TabStop = false;
            // 
            // UsernameNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 344);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsernameNotFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsernameNotFound";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        internal Guna.UI.WinForms.GunaButton ContinueBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
    }
}