namespace sims.Forgot_Password
{
    partial class Enter_OTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enter_OTP));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.verifyBtn = new Guna.UI.WinForms.GunaButton();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.otpTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.ResendOTPBtn_Click = new Guna.UI.WinForms.GunaButton();
            this.timerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 12;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // verifyBtn
            // 
            this.verifyBtn.AnimationHoverSpeed = 0.07F;
            this.verifyBtn.AnimationSpeed = 0.03F;
            this.verifyBtn.BackColor = System.Drawing.Color.Transparent;
            this.verifyBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.verifyBtn.BorderColor = System.Drawing.Color.Black;
            this.verifyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verifyBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.verifyBtn.FocusedColor = System.Drawing.Color.Empty;
            this.verifyBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyBtn.ForeColor = System.Drawing.Color.White;
            this.verifyBtn.Image = null;
            this.verifyBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.verifyBtn.Location = new System.Drawing.Point(410, 273);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.verifyBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.verifyBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.verifyBtn.OnHoverImage = null;
            this.verifyBtn.OnPressedColor = System.Drawing.Color.Black;
            this.verifyBtn.Radius = 5;
            this.verifyBtn.Size = new System.Drawing.Size(175, 36);
            this.verifyBtn.TabIndex = 101;
            this.verifyBtn.Text = "CONTINUE";
            this.verifyBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.Font = new System.Drawing.Font("Poppins", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel1.Location = new System.Drawing.Point(402, 46);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(365, 112);
            this.GunaLabel1.TabIndex = 99;
            this.GunaLabel1.Text = "ENTER VALID \r\nONE TIME PASSWORD";
            // 
            // otpTextBox
            // 
            this.otpTextBox.AcceptsReturn = false;
            this.otpTextBox.AcceptsTab = false;
            this.otpTextBox.AnimationSpeed = 200;
            this.otpTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.otpTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.otpTextBox.BackColor = System.Drawing.Color.Transparent;
            this.otpTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("otpTextBox.BackgroundImage")));
            this.otpTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.otpTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.otpTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.otpTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.otpTextBox.BorderRadius = 5;
            this.otpTextBox.BorderThickness = 0;
            this.otpTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.otpTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.otpTextBox.DefaultFont = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otpTextBox.DefaultText = "";
            this.otpTextBox.FillColor = System.Drawing.Color.White;
            this.otpTextBox.HideSelection = true;
            this.otpTextBox.IconLeft = global::sims.Properties.Resources.password;
            this.otpTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.otpTextBox.IconPadding = 5;
            this.otpTextBox.IconRight = null;
            this.otpTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.otpTextBox.Lines = new string[0];
            this.otpTextBox.Location = new System.Drawing.Point(410, 216);
            this.otpTextBox.MaxLength = 32767;
            this.otpTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.otpTextBox.Modified = false;
            this.otpTextBox.Multiline = false;
            this.otpTextBox.Name = "otpTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.otpTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.otpTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.otpTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.otpTextBox.OnIdleState = stateProperties4;
            this.otpTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.otpTextBox.PasswordChar = '\0';
            this.otpTextBox.PlaceholderForeColor = System.Drawing.Color.Black;
            this.otpTextBox.PlaceholderText = "Enter OTP";
            this.otpTextBox.ReadOnly = false;
            this.otpTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.otpTextBox.SelectedText = "";
            this.otpTextBox.SelectionLength = 0;
            this.otpTextBox.SelectionStart = 0;
            this.otpTextBox.ShortcutsEnabled = true;
            this.otpTextBox.Size = new System.Drawing.Size(355, 44);
            this.otpTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.otpTextBox.TabIndex = 100;
            this.otpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.otpTextBox.TextMarginBottom = 0;
            this.otpTextBox.TextMarginLeft = 15;
            this.otpTextBox.TextMarginTop = 0;
            this.otpTextBox.TextPlaceholder = "Enter OTP";
            this.otpTextBox.UseSystemPasswordChar = false;
            this.otpTextBox.WordWrap = true;
            this.otpTextBox.TextChanged += new System.EventHandler(this.otpTextBox_TextChanged);
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::sims.Properties.Resources.forgot_password_lock;
            this.gunaPictureBox1.Location = new System.Drawing.Point(36, 46);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Radius = 6;
            this.gunaPictureBox1.Size = new System.Drawing.Size(346, 340);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 98;
            this.gunaPictureBox1.TabStop = false;
            // 
            // ResendOTPBtn_Click
            // 
            this.ResendOTPBtn_Click.AnimationHoverSpeed = 0.07F;
            this.ResendOTPBtn_Click.AnimationSpeed = 0.03F;
            this.ResendOTPBtn_Click.BackColor = System.Drawing.Color.Transparent;
            this.ResendOTPBtn_Click.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ResendOTPBtn_Click.BorderColor = System.Drawing.Color.Black;
            this.ResendOTPBtn_Click.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResendOTPBtn_Click.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ResendOTPBtn_Click.FocusedColor = System.Drawing.Color.Empty;
            this.ResendOTPBtn_Click.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResendOTPBtn_Click.ForeColor = System.Drawing.Color.White;
            this.ResendOTPBtn_Click.Image = null;
            this.ResendOTPBtn_Click.ImageSize = new System.Drawing.Size(20, 20);
            this.ResendOTPBtn_Click.Location = new System.Drawing.Point(591, 273);
            this.ResendOTPBtn_Click.Name = "ResendOTPBtn_Click";
            this.ResendOTPBtn_Click.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ResendOTPBtn_Click.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ResendOTPBtn_Click.OnHoverForeColor = System.Drawing.Color.White;
            this.ResendOTPBtn_Click.OnHoverImage = null;
            this.ResendOTPBtn_Click.OnPressedColor = System.Drawing.Color.Black;
            this.ResendOTPBtn_Click.Radius = 5;
            this.ResendOTPBtn_Click.Size = new System.Drawing.Size(174, 36);
            this.ResendOTPBtn_Click.TabIndex = 104;
            this.ResendOTPBtn_Click.Text = "Resend OTP";
            this.ResendOTPBtn_Click.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResendOTPBtn_Click.Click += new System.EventHandler(this.ResendOTPBtn_Click_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(536, 185);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(97, 28);
            this.timerLabel.TabIndex = 103;
            this.timerLabel.Text = "timerLabel";
            this.timerLabel.Visible = false;
            // 
            // Enter_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResendOTPBtn_Click);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.otpTextBox);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.GunaLabel1);
            this.Controls.Add(this.gunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Enter_OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter_OTP";
            this.Load += new System.EventHandler(this.Enter_OTP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        public Bunifu.UI.WinForms.BunifuTextBox otpTextBox;
        internal Guna.UI.WinForms.GunaButton verifyBtn;
        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        internal Guna.UI.WinForms.GunaButton ResendOTPBtn_Click;
        private System.Windows.Forms.Label timerLabel;
    }
}