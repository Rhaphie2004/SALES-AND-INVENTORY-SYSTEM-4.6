namespace sims.Admin_Side.Category
{
    partial class Manage_Categoryy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_Categoryy));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recentlyAddedDgv = new Guna.UI.WinForms.GunaDataGridView();
            this.Category_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DeleteCategoryBtn = new Guna.UI.WinForms.GunaButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.newCategoryBtn = new Guna.UI.WinForms.GunaButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.editCategoryBtn = new Guna.UI.WinForms.GunaButton();
            this.searchCategoryTxt = new Bunifu.UI.WinForms.BunifuTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaElipsePanel2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentlyAddedDgv)).BeginInit();
            this.gunaGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gunaElipsePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.recentlyAddedDgv);
            this.panel1.Location = new System.Drawing.Point(16, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 470);
            this.panel1.TabIndex = 28;
            // 
            // recentlyAddedDgv
            // 
            this.recentlyAddedDgv.AllowUserToAddRows = false;
            this.recentlyAddedDgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.recentlyAddedDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recentlyAddedDgv.BackgroundColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentlyAddedDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.recentlyAddedDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(157)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recentlyAddedDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.recentlyAddedDgv.ColumnHeadersHeight = 40;
            this.recentlyAddedDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.recentlyAddedDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category_ID,
            this.Category_Name,
            this.Category_Description});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recentlyAddedDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.recentlyAddedDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentlyAddedDgv.EnableHeadersVisualStyles = false;
            this.recentlyAddedDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.recentlyAddedDgv.Location = new System.Drawing.Point(0, 0);
            this.recentlyAddedDgv.Name = "recentlyAddedDgv";
            this.recentlyAddedDgv.ReadOnly = true;
            this.recentlyAddedDgv.RowHeadersVisible = false;
            this.recentlyAddedDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.recentlyAddedDgv.RowTemplate.Height = 35;
            this.recentlyAddedDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recentlyAddedDgv.Size = new System.Drawing.Size(1143, 468);
            this.recentlyAddedDgv.TabIndex = 30;
            this.recentlyAddedDgv.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.recentlyAddedDgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.recentlyAddedDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.recentlyAddedDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.recentlyAddedDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.recentlyAddedDgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.recentlyAddedDgv.ThemeStyle.HeaderStyle.Height = 40;
            this.recentlyAddedDgv.ThemeStyle.ReadOnly = true;
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.Height = 35;
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.recentlyAddedDgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.recentlyAddedDgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.recentlyAddedDgv_DataBindingComplete);
            // 
            // Category_ID
            // 
            this.Category_ID.DataPropertyName = "Category_ID";
            this.Category_ID.HeaderText = "Category ID";
            this.Category_ID.Name = "Category_ID";
            this.Category_ID.ReadOnly = true;
            // 
            // Category_Name
            // 
            this.Category_Name.DataPropertyName = "Category_Name";
            this.Category_Name.HeaderText = "Category Name";
            this.Category_Name.Name = "Category_Name";
            this.Category_Name.ReadOnly = true;
            // 
            // Category_Description
            // 
            this.Category_Description.DataPropertyName = "Category_Description";
            this.Category_Description.HeaderText = "Category Description";
            this.Category_Description.Name = "Category_Description";
            this.Category_Description.ReadOnly = true;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.tableLayoutPanel1);
            this.gunaGroupBox1.Controls.Add(this.searchCategoryTxt);
            this.gunaGroupBox1.Controls.Add(this.panel1);
            this.gunaGroupBox1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.LineColor = System.Drawing.Color.White;
            this.gunaGroupBox1.LineTop = 0;
            this.gunaGroupBox1.Location = new System.Drawing.Point(11, 77);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Radius = 10;
            this.gunaGroupBox1.Size = new System.Drawing.Size(1171, 605);
            this.gunaGroupBox1.TabIndex = 17;
            this.gunaGroupBox1.Text = "Soothing Café Categories";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 13);
            this.gunaGroupBox1.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(370, 530);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 75);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DeleteCategoryBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(340, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(178, 75);
            this.panel5.TabIndex = 2;
            // 
            // DeleteCategoryBtn
            // 
            this.DeleteCategoryBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteCategoryBtn.AnimationHoverSpeed = 0.07F;
            this.DeleteCategoryBtn.AnimationSpeed = 0.03F;
            this.DeleteCategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.DeleteCategoryBtn.BaseColor = System.Drawing.Color.Transparent;
            this.DeleteCategoryBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.DeleteCategoryBtn.BorderSize = 2;
            this.DeleteCategoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteCategoryBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DeleteCategoryBtn.FocusedColor = System.Drawing.Color.Empty;
            this.DeleteCategoryBtn.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCategoryBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteCategoryBtn.Image = null;
            this.DeleteCategoryBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.DeleteCategoryBtn.Location = new System.Drawing.Point(5, 12);
            this.DeleteCategoryBtn.Name = "DeleteCategoryBtn";
            this.DeleteCategoryBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.DeleteCategoryBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.DeleteCategoryBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.DeleteCategoryBtn.OnHoverImage = null;
            this.DeleteCategoryBtn.OnPressedColor = System.Drawing.Color.White;
            this.DeleteCategoryBtn.Radius = 6;
            this.DeleteCategoryBtn.Size = new System.Drawing.Size(165, 50);
            this.DeleteCategoryBtn.TabIndex = 32;
            this.DeleteCategoryBtn.Text = "Remove Category";
            this.DeleteCategoryBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DeleteCategoryBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.DeleteCategoryBtn.Click += new System.EventHandler(this.DeleteCategoryBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.editCategoryBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(170, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 75);
            this.panel4.TabIndex = 1;
            // 
            // newCategoryBtn
            // 
            this.newCategoryBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newCategoryBtn.AnimationHoverSpeed = 0.07F;
            this.newCategoryBtn.AnimationSpeed = 0.03F;
            this.newCategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.newCategoryBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.newCategoryBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.newCategoryBtn.BorderSize = 2;
            this.newCategoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newCategoryBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.newCategoryBtn.FocusedColor = System.Drawing.Color.Empty;
            this.newCategoryBtn.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCategoryBtn.ForeColor = System.Drawing.Color.White;
            this.newCategoryBtn.Image = global::sims.Properties.Resources.add_white;
            this.newCategoryBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.newCategoryBtn.Location = new System.Drawing.Point(3, 12);
            this.newCategoryBtn.Name = "newCategoryBtn";
            this.newCategoryBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.newCategoryBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.newCategoryBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.newCategoryBtn.OnHoverImage = null;
            this.newCategoryBtn.OnPressedColor = System.Drawing.Color.White;
            this.newCategoryBtn.Radius = 6;
            this.newCategoryBtn.Size = new System.Drawing.Size(161, 50);
            this.newCategoryBtn.TabIndex = 25;
            this.newCategoryBtn.Text = "New Category";
            this.newCategoryBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.newCategoryBtn.Click += new System.EventHandler(this.newCategoryBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.newCategoryBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 75);
            this.panel3.TabIndex = 0;
            // 
            // editCategoryBtn
            // 
            this.editCategoryBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editCategoryBtn.AnimationHoverSpeed = 0.07F;
            this.editCategoryBtn.AnimationSpeed = 0.03F;
            this.editCategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.editCategoryBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.editCategoryBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.editCategoryBtn.BorderSize = 2;
            this.editCategoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editCategoryBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.editCategoryBtn.FocusedColor = System.Drawing.Color.Empty;
            this.editCategoryBtn.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCategoryBtn.ForeColor = System.Drawing.Color.White;
            this.editCategoryBtn.Image = global::sims.Properties.Resources.edit_white;
            this.editCategoryBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.editCategoryBtn.Location = new System.Drawing.Point(3, 12);
            this.editCategoryBtn.Name = "editCategoryBtn";
            this.editCategoryBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.editCategoryBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(178)))), ((int)(((byte)(84)))));
            this.editCategoryBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.editCategoryBtn.OnHoverImage = null;
            this.editCategoryBtn.OnPressedColor = System.Drawing.Color.White;
            this.editCategoryBtn.Radius = 6;
            this.editCategoryBtn.Size = new System.Drawing.Size(163, 50);
            this.editCategoryBtn.TabIndex = 25;
            this.editCategoryBtn.Text = "Edit Category";
            this.editCategoryBtn.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            this.editCategoryBtn.Click += new System.EventHandler(this.editCategoryBtn_Click);
            // 
            // searchCategoryTxt
            // 
            this.searchCategoryTxt.AcceptsReturn = false;
            this.searchCategoryTxt.AcceptsTab = false;
            this.searchCategoryTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchCategoryTxt.AnimationSpeed = 200;
            this.searchCategoryTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchCategoryTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchCategoryTxt.BackColor = System.Drawing.Color.Transparent;
            this.searchCategoryTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchCategoryTxt.BackgroundImage")));
            this.searchCategoryTxt.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.searchCategoryTxt.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.searchCategoryTxt.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.searchCategoryTxt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.searchCategoryTxt.BorderRadius = 30;
            this.searchCategoryTxt.BorderThickness = 1;
            this.searchCategoryTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchCategoryTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchCategoryTxt.DefaultFont = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCategoryTxt.DefaultText = "";
            this.searchCategoryTxt.FillColor = System.Drawing.Color.White;
            this.searchCategoryTxt.HideSelection = true;
            this.searchCategoryTxt.IconLeft = null;
            this.searchCategoryTxt.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchCategoryTxt.IconPadding = 10;
            this.searchCategoryTxt.IconRight = null;
            this.searchCategoryTxt.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchCategoryTxt.Lines = new string[0];
            this.searchCategoryTxt.Location = new System.Drawing.Point(879, 12);
            this.searchCategoryTxt.MaximumSize = new System.Drawing.Size(282, 35);
            this.searchCategoryTxt.MaxLength = 32767;
            this.searchCategoryTxt.MinimumSize = new System.Drawing.Size(282, 35);
            this.searchCategoryTxt.Modified = false;
            this.searchCategoryTxt.Multiline = false;
            this.searchCategoryTxt.Name = "searchCategoryTxt";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchCategoryTxt.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.searchCategoryTxt.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchCategoryTxt.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchCategoryTxt.OnIdleState = stateProperties4;
            this.searchCategoryTxt.Padding = new System.Windows.Forms.Padding(3);
            this.searchCategoryTxt.PasswordChar = '\0';
            this.searchCategoryTxt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.searchCategoryTxt.PlaceholderText = "Search by category name";
            this.searchCategoryTxt.ReadOnly = false;
            this.searchCategoryTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchCategoryTxt.SelectedText = "";
            this.searchCategoryTxt.SelectionLength = 0;
            this.searchCategoryTxt.SelectionStart = 0;
            this.searchCategoryTxt.ShortcutsEnabled = true;
            this.searchCategoryTxt.Size = new System.Drawing.Size(282, 35);
            this.searchCategoryTxt.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.searchCategoryTxt.TabIndex = 33;
            this.searchCategoryTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.searchCategoryTxt.TextMarginBottom = 0;
            this.searchCategoryTxt.TextMarginLeft = 3;
            this.searchCategoryTxt.TextMarginTop = 0;
            this.searchCategoryTxt.TextPlaceholder = "Search by category name";
            this.searchCategoryTxt.UseSystemPasswordChar = false;
            this.searchCategoryTxt.WordWrap = true;
            this.searchCategoryTxt.TextChanged += new System.EventHandler(this.searchCategoryTxt_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gunaElipsePanel2);
            this.panel2.Location = new System.Drawing.Point(11, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 56);
            this.panel2.TabIndex = 16;
            // 
            // gunaElipsePanel2
            // 
            this.gunaElipsePanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel2.BaseColor = System.Drawing.Color.White;
            this.gunaElipsePanel2.Controls.Add(this.label4);
            this.gunaElipsePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaElipsePanel2.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gunaElipsePanel2.Name = "gunaElipsePanel2";
            this.gunaElipsePanel2.Radius = 10;
            this.gunaElipsePanel2.Size = new System.Drawing.Size(1171, 53);
            this.gunaElipsePanel2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 34);
            this.label4.TabIndex = 22;
            this.label4.Text = "Dashboard / Categories\r\n";
            // 
            // Manage_Categoryy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(196)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1194, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gunaGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_Categoryy";
            this.Text = "Manage_Categoryy";
            this.Load += new System.EventHandler(this.Manage_Categoryy_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recentlyAddedDgv)).EndInit();
            this.gunaGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gunaElipsePanel2.ResumeLayout(false);
            this.gunaElipsePanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public Guna.UI.WinForms.GunaDataGridView recentlyAddedDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category_Description;
        private Guna.UI.WinForms.GunaButton newCategoryBtn;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Bunifu.UI.WinForms.BunifuTextBox searchCategoryTxt;
        private Guna.UI.WinForms.GunaButton DeleteCategoryBtn;
        private Guna.UI.WinForms.GunaButton editCategoryBtn;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
    }
}