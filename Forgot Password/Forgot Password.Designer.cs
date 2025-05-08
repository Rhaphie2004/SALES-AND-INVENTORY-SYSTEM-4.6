namespace sims.Forgot_Password
{
    partial class Forgot_Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forgot_Password));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.BackToSigninLink = new Guna.UI.WinForms.GunaLinkLabel();
            this.ContinueBtn = new Guna.UI.WinForms.GunaButton();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.usernameTxt = new Bunifu.UI.WinForms.BunifuTextBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackToSigninLink
            // 
            this.BackToSigninLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.BackToSigninLink.AutoSize = true;
            this.BackToSigninLink.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToSigninLink.LinkColor = System.Drawing.Color.Black;
            this.BackToSigninLink.Location = new System.Drawing.Point(508, 297);
            this.BackToSigninLink.Name = "BackToSigninLink";
            this.BackToSigninLink.Size = new System.Drawing.Size(154, 34);
            this.BackToSigninLink.TabIndex = 44;
            this.BackToSigninLink.TabStop = true;
            this.BackToSigninLink.Text = "Back to Sign In";
            this.BackToSigninLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BackToSigninLink_LinkClicked);
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.AnimationHoverSpeed = 0.07F;
            this.ContinueBtn.AnimationSpeed = 0.03F;
            this.ContinueBtn.BackColor = System.Drawing.Color.Transparent;
            this.ContinueBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ContinueBtn.BorderColor = System.Drawing.Color.Black;
            this.ContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContinueBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ContinueBtn.FocusedColor = System.Drawing.Color.Empty;
            this.ContinueBtn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueBtn.ForeColor = System.Drawing.Color.White;
            this.ContinueBtn.Image = null;
            this.ContinueBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.ContinueBtn.Location = new System.Drawing.Point(434, 246);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ContinueBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.ContinueBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.ContinueBtn.OnHoverImage = null;
            this.ContinueBtn.OnPressedColor = System.Drawing.Color.Black;
            this.ContinueBtn.Radius = 5;
            this.ContinueBtn.Size = new System.Drawing.Size(311, 36);
            this.ContinueBtn.TabIndex = 43;
            this.ContinueBtn.Text = "CONTINUE";
            this.ContinueBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.Font = new System.Drawing.Font("Poppins", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel1.Location = new System.Drawing.Point(424, 64);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(325, 112);
            this.GunaLabel1.TabIndex = 41;
            this.GunaLabel1.Text = "FORGOT \r\nYOUR PASSWORD?";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 12;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // usernameTxt
            // 
            this.usernameTxt.AcceptsReturn = false;
            this.usernameTxt.AcceptsTab = false;
            this.usernameTxt.AnimationSpeed = 200;
            this.usernameTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.usernameTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.usernameTxt.BackColor = System.Drawing.Color.Transparent;
            this.usernameTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usernameTxt.BackgroundImage")));
            this.usernameTxt.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.usernameTxt.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.usernameTxt.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.usernameTxt.BorderColorIdle = System.Drawing.Color.Silver;
            this.usernameTxt.BorderRadius = 5;
            this.usernameTxt.BorderThickness = 0;
            this.usernameTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.usernameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTxt.DefaultFont = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxt.DefaultText = "";
            this.usernameTxt.FillColor = System.Drawing.Color.White;
            this.usernameTxt.HideSelection = true;
            this.usernameTxt.IconLeft = global::sims.Properties.Resources.user_dark;
            this.usernameTxt.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTxt.IconPadding = 5;
            this.usernameTxt.IconRight = null;
            this.usernameTxt.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTxt.Lines = new string[0];
            this.usernameTxt.Location = new System.Drawing.Point(434, 190);
            this.usernameTxt.MaxLength = 32767;
            this.usernameTxt.MinimumSize = new System.Drawing.Size(1, 1);
            this.usernameTxt.Modified = false;
            this.usernameTxt.Multiline = false;
            this.usernameTxt.Name = "usernameTxt";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.usernameTxt.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.usernameTxt.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.usernameTxt.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.usernameTxt.OnIdleState = stateProperties4;
            this.usernameTxt.Padding = new System.Windows.Forms.Padding(3);
            this.usernameTxt.PasswordChar = '\0';
            this.usernameTxt.PlaceholderForeColor = System.Drawing.Color.Black;
            this.usernameTxt.PlaceholderText = "Enter Username";
            this.usernameTxt.ReadOnly = false;
            this.usernameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameTxt.SelectedText = "";
            this.usernameTxt.SelectionLength = 0;
            this.usernameTxt.SelectionStart = 0;
            this.usernameTxt.ShortcutsEnabled = true;
            this.usernameTxt.Size = new System.Drawing.Size(311, 35);
            this.usernameTxt.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.usernameTxt.TabIndex = 42;
            this.usernameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.usernameTxt.TextMarginBottom = 0;
            this.usernameTxt.TextMarginLeft = 15;
            this.usernameTxt.TextMarginTop = 0;
            this.usernameTxt.TextPlaceholder = "Enter Username";
            this.usernameTxt.UseSystemPasswordChar = false;
            this.usernameTxt.WordWrap = true;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::sims.Properties.Resources.forgot_password_lock;
            this.gunaPictureBox1.Location = new System.Drawing.Point(51, 64);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Radius = 6;
            this.gunaPictureBox1.Size = new System.Drawing.Size(334, 322);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 40;
            this.gunaPictureBox1.TabStop = false;
            // 
            // Forgot_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.BackToSigninLink);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.GunaLabel1);
            this.Controls.Add(this.gunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Forgot_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot_Password";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuTextBox usernameTxt;
        internal Guna.UI.WinForms.GunaLinkLabel BackToSigninLink;
        internal Guna.UI.WinForms.GunaButton ContinueBtn;
        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
    }
}