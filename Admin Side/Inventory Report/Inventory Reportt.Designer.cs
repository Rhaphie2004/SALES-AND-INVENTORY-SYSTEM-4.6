namespace sims.Admin_Side.Inventory_Report
{
    partial class Inventory_Reportt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory_Reportt));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.BackBtn = new Guna.UI.WinForms.GunaButton();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Stocks_Report1 = new sims.Stocks_Report();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel1.SuspendLayout();
            this.gunaElipsePanel2.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gunaElipsePanel2);
            this.panel1.Location = new System.Drawing.Point(12, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 53);
            this.panel1.TabIndex = 51;
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel2.Controls.Add(this.BackBtn);
            this.gunaElipsePanel2.Controls.Add(this.label4);
            this.gunaElipsePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaElipsePanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 7;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(1170, 53);
            this.gunaElipsePanel2.TabIndex = 46;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackBtn.AnimationHoverSpeed = 0.07F;
            this.BackBtn.AnimationSpeed = 0.03F;
            this.BackBtn.BackColor = System.Drawing.Color.Transparent;
            this.BackBtn.BaseColor = System.Drawing.Color.Transparent;
            this.BackBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.BackBtn.BorderSize = 2;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BackBtn.FocusedColor = System.Drawing.Color.Empty;
            this.BackBtn.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.Black;
            this.BackBtn.Image = null;
            this.BackBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.BackBtn.Location = new System.Drawing.Point(1030, 9);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.BackBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.BackBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.BackBtn.OnHoverImage = null;
            this.BackBtn.OnPressedColor = System.Drawing.Color.White;
            this.BackBtn.Radius = 6;
            this.BackBtn.Size = new System.Drawing.Size(130, 35);
            this.BackBtn.TabIndex = 37;
            this.BackBtn.Text = "Back";
            this.BackBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BackBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 34);
            this.label4.TabIndex = 21;
            this.label4.Text = "Dashboard / Inventory Report\r\n";
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.panel5);
            this.gunaGroupBox2.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox2.LineColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineTop = 0;
            this.gunaGroupBox2.Location = new System.Drawing.Point(12, 80);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 10;
            this.gunaGroupBox2.Size = new System.Drawing.Size(1171, 607);
            this.gunaGroupBox2.TabIndex = 52;
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 15);
            this.gunaGroupBox2.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.crystalReportViewer1);
            this.panel5.Location = new System.Drawing.Point(11, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1149, 577);
            this.panel5.TabIndex = 38;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Stocks_Report1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1149, 577);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 12;
            this.gunaElipse1.TargetControl = this;
            // 
            // Inventory_Reportt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1194, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gunaGroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory_Reportt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory_Reportt";
            this.Load += new System.EventHandler(this.Inventory_Reportt_Load);
            this.panel1.ResumeLayout(false);
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            this.gunaGroupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        internal System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI.WinForms.GunaButton BackBtn;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private sims.Stocks_Report Stocks_Report1;
    }
}