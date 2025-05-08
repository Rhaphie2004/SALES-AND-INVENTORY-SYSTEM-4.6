namespace sims.Staff_Side
{
    partial class Dashboard_Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_Staff));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.salesReportBtn = new FontAwesome.Sharp.IconButton();
            this.productSalesBtn = new FontAwesome.Sharp.IconButton();
            this.StocksBtn = new FontAwesome.Sharp.IconButton();
            this.ItemsBtn = new FontAwesome.Sharp.IconButton();
            this.SignoutBtn = new FontAwesome.Sharp.IconButton();
            this.DashboardBtn = new FontAwesome.Sharp.IconButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.gunaCirclePictureBox2 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TimeLbl = new Guna.UI.WinForms.GunaLabel();
            this.DateLbl = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.greetingNameTxt = new System.Windows.Forms.Label();
            this.DashboardPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerTransition = new System.Windows.Forms.Timer(this.components);
            this.PanelMenu.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.White;
            this.PanelMenu.Controls.Add(this.salesReportBtn);
            this.PanelMenu.Controls.Add(this.productSalesBtn);
            this.PanelMenu.Controls.Add(this.StocksBtn);
            this.PanelMenu.Controls.Add(this.ItemsBtn);
            this.PanelMenu.Controls.Add(this.SignoutBtn);
            this.PanelMenu.Controls.Add(this.DashboardBtn);
            this.PanelMenu.Controls.Add(this.panel12);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(299, 779);
            this.PanelMenu.TabIndex = 91;
            // 
            // salesReportBtn
            // 
            this.salesReportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salesReportBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.salesReportBtn.FlatAppearance.BorderSize = 0;
            this.salesReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesReportBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesReportBtn.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.salesReportBtn.IconColor = System.Drawing.Color.Black;
            this.salesReportBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.salesReportBtn.IconSize = 40;
            this.salesReportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salesReportBtn.Location = new System.Drawing.Point(0, 314);
            this.salesReportBtn.Name = "salesReportBtn";
            this.salesReportBtn.Padding = new System.Windows.Forms.Padding(35, 0, 20, 0);
            this.salesReportBtn.Size = new System.Drawing.Size(299, 58);
            this.salesReportBtn.TabIndex = 36;
            this.salesReportBtn.Text = "Sales Report";
            this.salesReportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salesReportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.salesReportBtn.UseVisualStyleBackColor = true;
            this.salesReportBtn.Click += new System.EventHandler(this.salesReportBtn_Click);
            // 
            // productSalesBtn
            // 
            this.productSalesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productSalesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.productSalesBtn.FlatAppearance.BorderSize = 0;
            this.productSalesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productSalesBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productSalesBtn.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            this.productSalesBtn.IconColor = System.Drawing.Color.Black;
            this.productSalesBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.productSalesBtn.IconSize = 40;
            this.productSalesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productSalesBtn.Location = new System.Drawing.Point(0, 256);
            this.productSalesBtn.Name = "productSalesBtn";
            this.productSalesBtn.Padding = new System.Windows.Forms.Padding(35, 0, 20, 0);
            this.productSalesBtn.Size = new System.Drawing.Size(299, 58);
            this.productSalesBtn.TabIndex = 35;
            this.productSalesBtn.Text = "Products Sales";
            this.productSalesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productSalesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.productSalesBtn.UseVisualStyleBackColor = true;
            this.productSalesBtn.Click += new System.EventHandler(this.productSalesBtn_Click);
            // 
            // StocksBtn
            // 
            this.StocksBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StocksBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.StocksBtn.FlatAppearance.BorderSize = 0;
            this.StocksBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StocksBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StocksBtn.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.StocksBtn.IconColor = System.Drawing.Color.Black;
            this.StocksBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.StocksBtn.IconSize = 40;
            this.StocksBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StocksBtn.Location = new System.Drawing.Point(0, 198);
            this.StocksBtn.Name = "StocksBtn";
            this.StocksBtn.Padding = new System.Windows.Forms.Padding(35, 0, 20, 0);
            this.StocksBtn.Size = new System.Drawing.Size(299, 58);
            this.StocksBtn.TabIndex = 30;
            this.StocksBtn.Text = "Stocks";
            this.StocksBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StocksBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StocksBtn.UseVisualStyleBackColor = true;
            this.StocksBtn.Click += new System.EventHandler(this.StocksBtn_Click);
            // 
            // ItemsBtn
            // 
            this.ItemsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItemsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsBtn.FlatAppearance.BorderSize = 0;
            this.ItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemsBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsBtn.IconChar = FontAwesome.Sharp.IconChar.List;
            this.ItemsBtn.IconColor = System.Drawing.Color.Black;
            this.ItemsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ItemsBtn.IconSize = 40;
            this.ItemsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ItemsBtn.Location = new System.Drawing.Point(0, 140);
            this.ItemsBtn.Name = "ItemsBtn";
            this.ItemsBtn.Padding = new System.Windows.Forms.Padding(35, 0, 20, 0);
            this.ItemsBtn.Size = new System.Drawing.Size(299, 58);
            this.ItemsBtn.TabIndex = 29;
            this.ItemsBtn.Text = "Items";
            this.ItemsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ItemsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ItemsBtn.UseVisualStyleBackColor = true;
            this.ItemsBtn.Click += new System.EventHandler(this.ItemsBtn_Click);
            // 
            // SignoutBtn
            // 
            this.SignoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SignoutBtn.FlatAppearance.BorderSize = 0;
            this.SignoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignoutBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignoutBtn.ForeColor = System.Drawing.Color.Black;
            this.SignoutBtn.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.SignoutBtn.IconColor = System.Drawing.Color.Black;
            this.SignoutBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.SignoutBtn.IconSize = 40;
            this.SignoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SignoutBtn.Location = new System.Drawing.Point(0, 721);
            this.SignoutBtn.Name = "SignoutBtn";
            this.SignoutBtn.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.SignoutBtn.Size = new System.Drawing.Size(299, 58);
            this.SignoutBtn.TabIndex = 28;
            this.SignoutBtn.Text = "SIGN OUT";
            this.SignoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SignoutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SignoutBtn.UseVisualStyleBackColor = true;
            this.SignoutBtn.Click += new System.EventHandler(this.SignoutBtn_Click);
            // 
            // DashboardBtn
            // 
            this.DashboardBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DashboardBtn.FlatAppearance.BorderSize = 0;
            this.DashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashboardBtn.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardBtn.ForeColor = System.Drawing.Color.Black;
            this.DashboardBtn.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.DashboardBtn.IconColor = System.Drawing.Color.Black;
            this.DashboardBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.DashboardBtn.IconSize = 40;
            this.DashboardBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardBtn.Location = new System.Drawing.Point(0, 82);
            this.DashboardBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DashboardBtn.Name = "DashboardBtn";
            this.DashboardBtn.Padding = new System.Windows.Forms.Padding(35, 0, 20, 0);
            this.DashboardBtn.Size = new System.Drawing.Size(299, 58);
            this.DashboardBtn.TabIndex = 21;
            this.DashboardBtn.Text = "Dashboard";
            this.DashboardBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DashboardBtn.UseVisualStyleBackColor = true;
            this.DashboardBtn.Click += new System.EventHandler(this.DashboardBtn_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.gunaCirclePictureBox2);
            this.panel12.Controls.Add(this.Label1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(299, 82);
            this.panel12.TabIndex = 1;
            // 
            // gunaCirclePictureBox2
            // 
            this.gunaCirclePictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox2.Image = global::sims.Properties.Resources.logo_soothing_cafe;
            this.gunaCirclePictureBox2.Location = new System.Drawing.Point(29, 9);
            this.gunaCirclePictureBox2.Name = "gunaCirclePictureBox2";
            this.gunaCirclePictureBox2.Size = new System.Drawing.Size(65, 65);
            this.gunaCirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox2.TabIndex = 93;
            this.gunaCirclePictureBox2.TabStop = false;
            this.gunaCirclePictureBox2.UseTransfarantBackground = false;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(106, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(168, 37);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Soothing Café";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(299, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1145, 79);
            this.panel2.TabIndex = 92;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TimeLbl);
            this.panel3.Controls.Add(this.DateLbl);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(812, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 79);
            this.panel3.TabIndex = 4;
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLbl.ForeColor = System.Drawing.Color.White;
            this.TimeLbl.Location = new System.Drawing.Point(43, 41);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(85, 28);
            this.TimeLbl.TabIndex = 127;
            this.TimeLbl.Text = "h:mm:ss";
            this.TimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.ForeColor = System.Drawing.Color.White;
            this.DateLbl.Location = new System.Drawing.Point(43, 13);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(170, 28);
            this.DateLbl.TabIndex = 126;
            this.DateLbl.Text = "ddd, d MMMM yyyy";
            this.DateLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::sims.Properties.Resources.bell__1____white;
            this.pictureBox1.Location = new System.Drawing.Point(255, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Label3);
            this.panel5.Controls.Add(this.greetingNameTxt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(322, 79);
            this.panel5.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(4, 38);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(300, 37);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Welcome to Soothing Cafe";
            // 
            // greetingNameTxt
            // 
            this.greetingNameTxt.AutoSize = true;
            this.greetingNameTxt.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetingNameTxt.ForeColor = System.Drawing.Color.White;
            this.greetingNameTxt.Location = new System.Drawing.Point(4, 4);
            this.greetingNameTxt.Name = "greetingNameTxt";
            this.greetingNameTxt.Size = new System.Drawing.Size(211, 37);
            this.greetingNameTxt.TabIndex = 9;
            this.greetingNameTxt.Text = "Hi (Name of Staff),";
            // 
            // DashboardPanel
            // 
            this.DashboardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.DashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DashboardPanel.Location = new System.Drawing.Point(299, 79);
            this.DashboardPanel.Name = "DashboardPanel";
            this.DashboardPanel.Size = new System.Drawing.Size(1145, 700);
            this.DashboardPanel.TabIndex = 93;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerTransition
            // 
            this.TimerTransition.Tick += new System.EventHandler(this.TimerTransition_Tick);
            // 
            // Dashboard_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 779);
            this.Controls.Add(this.DashboardPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard_Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Dashboard (Staff)";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Dashboard_Staff_Load);
            this.PanelMenu.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        internal FontAwesome.Sharp.IconButton SignoutBtn;
        internal FontAwesome.Sharp.IconButton DashboardBtn;
        private System.Windows.Forms.Panel panel12;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label greetingNameTxt;
        private System.Windows.Forms.Panel DashboardPanel;
        internal FontAwesome.Sharp.IconButton ItemsBtn;
        internal FontAwesome.Sharp.IconButton StocksBtn;
        private System.Windows.Forms.Panel panel3;
        internal FontAwesome.Sharp.IconButton salesReportBtn;
        internal FontAwesome.Sharp.IconButton productSalesBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        internal Guna.UI.WinForms.GunaLabel TimeLbl;
        internal Guna.UI.WinForms.GunaLabel DateLbl;
        private System.Windows.Forms.Timer TimerTransition;
    }
}