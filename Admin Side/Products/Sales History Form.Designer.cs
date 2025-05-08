namespace sims.Admin_Side.Products
{
    partial class Sales_History_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.BackBtn = new Guna.UI.WinForms.GunaButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.chartTitleLabel = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.CoffeeMonthlyChart = new System.Windows.Forms.ToolStripMenuItem();
            this.NonCoffeeMonthlyChart = new System.Windows.Forms.ToolStripMenuItem();
            this.HotCoffeeMonthlyChart = new System.Windows.Forms.ToolStripMenuItem();
            this.pastriesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.toDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDatePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.salesHistoryDgv = new Guna.UI.WinForms.GunaDataGridView();
            this.Sales_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity_Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Product_Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_Needed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gunaElipsePanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gunaElipsePanel1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesHistoryDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 12;
            this.gunaElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gunaElipsePanel2);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 53);
            this.panel1.TabIndex = 52;
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
            this.BackBtn.Location = new System.Drawing.Point(1032, 8);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.BackBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.BackBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.BackBtn.OnHoverImage = null;
            this.BackBtn.OnPressedColor = System.Drawing.Color.White;
            this.BackBtn.Radius = 6;
            this.BackBtn.Size = new System.Drawing.Size(130, 35);
            this.BackBtn.TabIndex = 38;
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
            this.label4.Size = new System.Drawing.Size(261, 34);
            this.label4.TabIndex = 21;
            this.label4.Text = "Dashboard / Sales History";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gunaElipsePanel1);
            this.panel2.Location = new System.Drawing.Point(11, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 53);
            this.panel2.TabIndex = 53;
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel1.Controls.Add(this.chartTitleLabel);
            this.gunaElipsePanel1.Controls.Add(this.menuStrip2);
            this.gunaElipsePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaElipsePanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Radius = 7;
            this.gunaElipsePanel1.Size = new System.Drawing.Size(1170, 53);
            this.gunaElipsePanel1.TabIndex = 46;
            // 
            // chartTitleLabel
            // 
            this.chartTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTitleLabel.AutoSize = true;
            this.chartTitleLabel.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTitleLabel.Location = new System.Drawing.Point(900, 12);
            this.chartTitleLabel.Name = "chartTitleLabel";
            this.chartTitleLabel.Size = new System.Drawing.Size(258, 28);
            this.chartTitleLabel.TabIndex = 6;
            this.chartTitleLabel.Text = "productsaleshistory_hotcoffee";
            this.chartTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1170, 53);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "MenuStrip1";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CoffeeMonthlyChart,
            this.NonCoffeeMonthlyChart,
            this.HotCoffeeMonthlyChart,
            this.pastriesToolStripMenuItem1});
            this.toolStripMenuItem5.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(128, 49);
            this.toolStripMenuItem5.Text = "Monthly Sales";
            // 
            // CoffeeMonthlyChart
            // 
            this.CoffeeMonthlyChart.Name = "CoffeeMonthlyChart";
            this.CoffeeMonthlyChart.Size = new System.Drawing.Size(213, 30);
            this.CoffeeMonthlyChart.Text = "Coffee Sales";
            this.CoffeeMonthlyChart.Click += new System.EventHandler(this.CoffeeMonthlyChart_Click);
            // 
            // NonCoffeeMonthlyChart
            // 
            this.NonCoffeeMonthlyChart.Name = "NonCoffeeMonthlyChart";
            this.NonCoffeeMonthlyChart.Size = new System.Drawing.Size(213, 30);
            this.NonCoffeeMonthlyChart.Text = "Non Coffee Sales";
            this.NonCoffeeMonthlyChart.Click += new System.EventHandler(this.NonCoffeeMonthlyChart_Click);
            // 
            // HotCoffeeMonthlyChart
            // 
            this.HotCoffeeMonthlyChart.Name = "HotCoffeeMonthlyChart";
            this.HotCoffeeMonthlyChart.Size = new System.Drawing.Size(213, 30);
            this.HotCoffeeMonthlyChart.Text = "Hot Coffee Sales";
            this.HotCoffeeMonthlyChart.Click += new System.EventHandler(this.HotCoffeeMonthlyChart_Click);
            // 
            // pastriesToolStripMenuItem1
            // 
            this.pastriesToolStripMenuItem1.Name = "pastriesToolStripMenuItem1";
            this.pastriesToolStripMenuItem1.Size = new System.Drawing.Size(213, 30);
            this.pastriesToolStripMenuItem1.Text = "Pastries Sales";
            this.pastriesToolStripMenuItem1.Click += new System.EventHandler(this.pastriesToolStripMenuItem1_Click);
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.toDatePicker);
            this.gunaGroupBox2.Controls.Add(this.label2);
            this.gunaGroupBox2.Controls.Add(this.fromDatePicker);
            this.gunaGroupBox2.Controls.Add(this.label1);
            this.gunaGroupBox2.Controls.Add(this.panel5);
            this.gunaGroupBox2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox2.LineColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineTop = 0;
            this.gunaGroupBox2.Location = new System.Drawing.Point(12, 139);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 10;
            this.gunaGroupBox2.Size = new System.Drawing.Size(1170, 549);
            this.gunaGroupBox2.TabIndex = 54;
            this.gunaGroupBox2.Text = "Soothing Café Sales History";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 13);
            this.gunaGroupBox2.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // toDatePicker
            // 
            this.toDatePicker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.toDatePicker.BorderRadius = 4;
            this.toDatePicker.BorderThickness = 2;
            this.toDatePicker.CheckedState.Parent = this.toDatePicker;
            this.toDatePicker.FillColor = System.Drawing.Color.White;
            this.toDatePicker.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.toDatePicker.HoverState.Parent = this.toDatePicker;
            this.toDatePicker.Location = new System.Drawing.Point(957, 9);
            this.toDatePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.toDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.ShadowDecoration.Parent = this.toDatePicker;
            this.toDatePicker.Size = new System.Drawing.Size(200, 37);
            this.toDatePicker.TabIndex = 110;
            this.toDatePicker.Value = new System.DateTime(2025, 1, 14, 0, 31, 40, 562);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(917, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "To:";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.fromDatePicker.BorderRadius = 4;
            this.fromDatePicker.BorderThickness = 2;
            this.fromDatePicker.CheckedState.Parent = this.fromDatePicker;
            this.fromDatePicker.FillColor = System.Drawing.Color.White;
            this.fromDatePicker.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.fromDatePicker.HoverState.Parent = this.fromDatePicker;
            this.fromDatePicker.Location = new System.Drawing.Point(702, 9);
            this.fromDatePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.fromDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.ShadowDecoration.Parent = this.fromDatePicker;
            this.fromDatePicker.Size = new System.Drawing.Size(200, 37);
            this.fromDatePicker.TabIndex = 110;
            this.fromDatePicker.Value = new System.DateTime(2025, 1, 14, 0, 31, 40, 562);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(641, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 28);
            this.label1.TabIndex = 21;
            this.label1.Text = "From:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.salesHistoryDgv);
            this.panel5.Location = new System.Drawing.Point(9, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1149, 480);
            this.panel5.TabIndex = 30;
            // 
            // salesHistoryDgv
            // 
            this.salesHistoryDgv.AllowUserToAddRows = false;
            this.salesHistoryDgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.salesHistoryDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.salesHistoryDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.salesHistoryDgv.BackgroundColor = System.Drawing.Color.White;
            this.salesHistoryDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.salesHistoryDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.salesHistoryDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.salesHistoryDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.salesHistoryDgv.ColumnHeadersHeight = 30;
            this.salesHistoryDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sales_ID,
            this.Product_ID,
            this.Product_Name,
            this.Category,
            this.Product_Price,
            this.Stock_Quantity,
            this.Quantity_Sold,
            this.Total_Product_Sale,
            this.Stock_Needed,
            this.Sale_Date,
            this.Sale_Time});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.salesHistoryDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.salesHistoryDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesHistoryDgv.EnableHeadersVisualStyles = false;
            this.salesHistoryDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesHistoryDgv.Location = new System.Drawing.Point(0, 0);
            this.salesHistoryDgv.Name = "salesHistoryDgv";
            this.salesHistoryDgv.ReadOnly = true;
            this.salesHistoryDgv.RowHeadersVisible = false;
            this.salesHistoryDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.salesHistoryDgv.RowTemplate.Height = 100;
            this.salesHistoryDgv.RowTemplate.ReadOnly = true;
            this.salesHistoryDgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.salesHistoryDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.salesHistoryDgv.Size = new System.Drawing.Size(1147, 478);
            this.salesHistoryDgv.TabIndex = 3;
            this.salesHistoryDgv.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.salesHistoryDgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.salesHistoryDgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.salesHistoryDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.salesHistoryDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.salesHistoryDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.salesHistoryDgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.salesHistoryDgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.salesHistoryDgv.ThemeStyle.HeaderStyle.Height = 30;
            this.salesHistoryDgv.ThemeStyle.ReadOnly = true;
            this.salesHistoryDgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.salesHistoryDgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.salesHistoryDgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesHistoryDgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.salesHistoryDgv.ThemeStyle.RowsStyle.Height = 100;
            this.salesHistoryDgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesHistoryDgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Sales_ID
            // 
            this.Sales_ID.DataPropertyName = "Sales_ID";
            this.Sales_ID.HeaderText = "Sales ID";
            this.Sales_ID.Name = "Sales_ID";
            this.Sales_ID.ReadOnly = true;
            this.Sales_ID.Width = 96;
            // 
            // Product_ID
            // 
            this.Product_ID.DataPropertyName = "Product_ID ";
            this.Product_ID.HeaderText = "Product ID";
            this.Product_ID.Name = "Product_ID";
            this.Product_ID.ReadOnly = true;
            this.Product_ID.Visible = false;
            this.Product_ID.Width = 116;
            // 
            // Product_Name
            // 
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Width = 149;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 110;
            // 
            // Product_Price
            // 
            this.Product_Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Product_Price.DataPropertyName = "Product_Price";
            this.Product_Price.HeaderText = "Product Price";
            this.Product_Price.Name = "Product_Price";
            this.Product_Price.ReadOnly = true;
            this.Product_Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_Price.Width = 140;
            // 
            // Stock_Quantity
            // 
            this.Stock_Quantity.DataPropertyName = "Stock_Quantity";
            this.Stock_Quantity.HeaderText = "Stock Quantity";
            this.Stock_Quantity.Name = "Stock_Quantity";
            this.Stock_Quantity.ReadOnly = true;
            this.Stock_Quantity.Width = 151;
            // 
            // Quantity_Sold
            // 
            this.Quantity_Sold.DataPropertyName = "Quantity_Sold";
            this.Quantity_Sold.HeaderText = "Quantity Sold";
            this.Quantity_Sold.Name = "Quantity_Sold";
            this.Quantity_Sold.ReadOnly = true;
            this.Quantity_Sold.Width = 142;
            // 
            // Total_Product_Sale
            // 
            this.Total_Product_Sale.DataPropertyName = "Total_Product_Sale";
            this.Total_Product_Sale.HeaderText = "Total Product Sale";
            this.Total_Product_Sale.Name = "Total_Product_Sale";
            this.Total_Product_Sale.ReadOnly = true;
            this.Total_Product_Sale.Width = 179;
            // 
            // Stock_Needed
            // 
            this.Stock_Needed.DataPropertyName = "Stock_Needed";
            this.Stock_Needed.HeaderText = "Stock Needed";
            this.Stock_Needed.Name = "Stock_Needed";
            this.Stock_Needed.ReadOnly = true;
            this.Stock_Needed.Width = 145;
            // 
            // Sale_Date
            // 
            this.Sale_Date.DataPropertyName = "Sale_Date";
            this.Sale_Date.HeaderText = "Sale Date";
            this.Sale_Date.Name = "Sale_Date";
            this.Sale_Date.ReadOnly = true;
            this.Sale_Date.Width = 111;
            // 
            // Sale_Time
            // 
            this.Sale_Time.DataPropertyName = "Sale_Time";
            this.Sale_Time.HeaderText = "Sale Time";
            this.Sale_Time.Name = "Sale_Time";
            this.Sale_Time.ReadOnly = true;
            this.Sale_Time.Width = 112;
            // 
            // Sales_History_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1194, 700);
            this.Controls.Add(this.gunaGroupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sales_History_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales_History_Form";
            this.Load += new System.EventHandler(this.Sales_History_Form_Load);
            this.panel1.ResumeLayout(false);
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gunaElipsePanel1.ResumeLayout(false);
            this.gunaElipsePanel1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.gunaGroupBox2.ResumeLayout(false);
            this.gunaGroupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.salesHistoryDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        internal System.Windows.Forms.MenuStrip menuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem CoffeeMonthlyChart;
        internal System.Windows.Forms.ToolStripMenuItem NonCoffeeMonthlyChart;
        internal System.Windows.Forms.ToolStripMenuItem HotCoffeeMonthlyChart;
        private System.Windows.Forms.ToolStripMenuItem pastriesToolStripMenuItem1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI.WinForms.GunaDataGridView salesHistoryDgv;
        private Guna.UI.WinForms.GunaButton BackBtn;
        private System.Windows.Forms.Label chartTitleLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity_Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Product_Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_Needed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Time;
        private Guna.UI2.WinForms.Guna2DateTimePicker fromDatePicker;
        internal System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker toDatePicker;
        internal System.Windows.Forms.Label label2;
    }
}