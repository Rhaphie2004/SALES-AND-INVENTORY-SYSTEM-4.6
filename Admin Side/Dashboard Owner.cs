using FontAwesome.Sharp;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using sims.Admin_Side;
using sims.Admin_Side.Category;
using sims.Admin_Side.Database;
using sims.Admin_Side.Inventory_Report;
using sims.Admin_Side.Items;
using sims.Admin_Side.Sales;
using sims.Admin_Side.Sales_Report_Owner;
using sims.Admin_Side.Stocks;
using sims.Admin_Side.Users;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace sims
{
    public partial class DashboardOwner : Form
    {
        // Stores the currently active button to apply highlighting and styling
        private IconButton currentBtn;
        private GunaPanel leftBorderBtn;

        private readonly string _category;
        private Old_Inventory_Dashboard dashboardInventoryInstance;
        private Manage_Categoryy manageCategoryInstance;
        private Manage_Items manageItemsInstance;
        private Manage_Stockk manageStockInstance;
        private Inventory_Reportt inventoryReportInstance;
        private Product_Saless productSalesInstance;
        private Product_Sales manageSalesReportInstance;
        private Manage_User_Staff manageUserStaffInstance;
        private Database_Backup databaseBackupInstance;
        private readonly Add_Stock addStockInstance;

        public PictureBox bellIcon
        {
            get { return pictureBox1; }
        }

        // Add these enum and variables at the class level
        public enum TransitionEffect
        {
            Slide,
            Fade,
            Zoom,
            None
        }

        private Timer transitionTimer;
        private Control transitionControl;
        private int transitionProgress = 0;
        private TransitionEffect currentEffect = TransitionEffect.Slide;

        public DashboardOwner()
        {
            InitializeComponent();
            ShowUsernameWithGreeting();

            customizeDesign();

            leftBorderBtn = new GunaPanel
            {
                Size = new Size(10, 58)
            };
            PanelMenu.Controls.Add(leftBorderBtn);

            Timer timer = new Timer();
            timer.Tick += timer1_Tick;
            timer.Start();

            DateLbl.Text = DateTime.Now.ToString("ddd, d MMMM yyyy");
        }

        private void DashboardOwner_Load(object sender, EventArgs e)
        {
            dashboardInventoryInstance = new Old_Inventory_Dashboard(_category);
            manageCategoryInstance = new Manage_Categoryy(dashboardInventoryInstance, this);
            manageItemsInstance = new Manage_Items(dashboardInventoryInstance, manageCategoryInstance);
            manageStockInstance = new Manage_Stockk(dashboardInventoryInstance, addStockInstance, this, inventoryReportInstance);
            inventoryReportInstance = new Inventory_Reportt(manageStockInstance);
            productSalesInstance = new Product_Saless(dashboardInventoryInstance, manageStockInstance, addStockInstance, inventoryReportInstance, this, manageSalesReportInstance);
            manageSalesReportInstance = new Product_Sales();
            manageUserStaffInstance = new Manage_User_Staff();
            databaseBackupInstance = new Database_Backup();

            LoadView(dashboardInventoryInstance);

            ActivateButton(DashboardBtn, Color.White);

            ShowUsernameWithGreeting();
        }

        private void ShowUsernameWithGreeting()
        {
            dbModule db = new dbModule();
            string query = "SELECT Staff_Name FROM users LIMIT 1";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string username = result.ToString();
                            greetingNameTxt.Text = $"HI! {username},";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void LoadView(object viewInstance)
        {
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }

            if (viewInstance is UserControl uc)
            {
                if (!DashboardPanel.Controls.Contains(uc))
                {
                    uc.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(uc);
                }
                uc.Visible = true;
                uc.BringToFront();
            }
            else if (viewInstance is Form form)
            {
                if (!DashboardPanel.Controls.Contains(form))
                {
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(form);
                }
                form.MouseDown += (s, e) => ((Form)s).Capture = false;
                form.Visible = true;
                form.BringToFront();
            }
            else
            {
                throw new InvalidOperationException("Unsupported type. Only UserControl and Form are allowed.");
            }
        }

        private void customizeDesign()
        {
            InventoryPanelSubMenu.Visible = false;
            salesPanelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (InventoryPanelSubMenu.Visible == true)
                InventoryPanelSubMenu.Visible = false;
        }

        private void hideSubMenu2()
        {
            if (salesPanelSubMenu.Visible == true)
                salesPanelSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                hideSubMenu2();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void ActivateButton(object senderBtn, Color customColor)
        {
            if (senderBtn == null) return;
            DisableBtn();
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = Color.FromArgb(222, 196, 125);
            currentBtn.ForeColor = customColor;
            currentBtn.IconColor = customColor;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            leftBorderBtn.BackColor = customColor;
            leftBorderBtn.Size = new Size(7, currentBtn.Height);
            leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
        }

        // Instead of modifying the OpeninPanel method to remove effects, let's simply make it always use TransitionEffect.None
        private void OpeninPanel(object formOpen, TransitionEffect effect = TransitionEffect.None)
        {
            // Stop any ongoing transition
            if (transitionTimer != null && transitionTimer.Enabled)
            {
                transitionTimer.Stop();
                transitionTimer.Dispose();
            }

            // Hide all controls
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }

            Control toShow = null;

            if (formOpen is UserControl uc)
            {
                if (!DashboardPanel.Controls.Contains(uc))
                {
                    uc.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(uc);
                    DashboardPanel.Tag = uc;
                }
                toShow = uc;
            }
            else if (formOpen is Form dh)
            {
                if (!DashboardPanel.Controls.Contains(dh))
                {
                    dh.TopLevel = false;
                    dh.FormBorderStyle = FormBorderStyle.None;
                    dh.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(dh);
                    DashboardPanel.Tag = dh;
                }
                toShow = dh;
            }

            if (toShow != null)
            {
                // Set location and make visible
                toShow.Location = new Point(0, 0);
                toShow.Visible = true;
                toShow.BringToFront();
                toShow.Dock = DockStyle.Fill;
            }
        }

        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 255, 255);
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            leftBorderBtn.Visible = false;
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }
            dashboardInventoryInstance.Visible = true;
            dashboardInventoryInstance.BringToFront();
            customizeDesign();
        }

        private void CategoriesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageCategoryInstance, TransitionEffect.None);
            customizeDesign();
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(InventoryPanelSubMenu);
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageItemsInstance, TransitionEffect.None);

        }

        private void StocksBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageStockInstance, TransitionEffect.None);

        }

        private void inventoryReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            //OpeninPanel(inventoryReportInstance);
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(salesPanelSubMenu);
        }

        private void productSalesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(productSalesInstance, TransitionEffect.None);
        }

        private void salesReportBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageSalesReportInstance, TransitionEffect.None);
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageUserStaffInstance, TransitionEffect.None);
            customizeDesign();
        }

        private void backupDbBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(databaseBackupInstance, TransitionEffect.None);
        }

        private void SignoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.OK)
            {
                this.Hide();
                new Login_Form().Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLbl.Text = DateTime.Now.ToString("h:mm:ss tt");

        }

        private void TimerTransition_Tick(object sender, EventArgs e)
        {
            const int TRANSITION_STEPS = 20; // Total steps for the transition

            // Increase progress
            transitionProgress++;

            // Calculate percent complete (0.0 to 1.0)
            float percent = (float)transitionProgress / TRANSITION_STEPS;

            // Apply appropriate effect
            switch (currentEffect)
            {
                case TransitionEffect.Slide:
                    // Move from -width (off left) to 0 (normal position)
                    int targetX = 0;
                    int startX = -transitionControl.Width;
                    int distance = Math.Abs(startX);
                    int currentX = startX + (int)(distance * percent);

                    transitionControl.Left = currentX;

                    // Check if done
                    if (percent >= 1.0)
                    {
                        transitionControl.Left = targetX;
                        transitionControl.Dock = DockStyle.Fill;  // Restore dock
                        transitionTimer.Stop();
                        transitionTimer.Dispose();
                        transitionTimer = null;
                    }
                    break;

                case TransitionEffect.Fade:
                    // Apply opacity
                    if (transitionControl is Form form)
                    {
                        form.Opacity = percent;

                        // Check if done
                        if (percent >= 1.0)
                        {
                            form.Opacity = 1.0;
                            transitionControl.Dock = DockStyle.Fill;  // Restore dock
                            transitionTimer.Stop();
                            transitionTimer.Dispose();
                            transitionTimer = null;
                        }
                    }
                    else
                    {
                        // For UserControl, update BackColor alpha
                        Color originalColor = (Color)transitionControl.Tag;
                        int alpha = (int)(255 * percent);
                        transitionControl.BackColor = Color.FromArgb(alpha, originalColor.R, originalColor.G, originalColor.B);

                        // Check if done
                        if (percent >= 1.0)
                        {
                            transitionControl.BackColor = originalColor;
                            transitionControl.Dock = DockStyle.Fill;  // Restore dock
                            transitionTimer.Stop();
                            transitionTimer.Dispose();
                            transitionTimer = null;
                        }
                    }
                    break;

                case TransitionEffect.Zoom:
                    // Get original size
                    Size originalSize = (Size)transitionControl.Tag;

                    // Calculate new size
                    int newWidth = (int)(originalSize.Width * percent);
                    int newHeight = (int)(originalSize.Height * percent);

                    // Make sure we don't go to zero
                    newWidth = Math.Max(newWidth, 1);
                    newHeight = Math.Max(newHeight, 1);

                    // Set new size
                    transitionControl.Size = new Size(newWidth, newHeight);

                    // Center the control
                    transitionControl.Location = new Point(
                        (DashboardPanel.Width - newWidth) / 2,
                        (DashboardPanel.Height - newHeight) / 2
                    );

                    // Check if done
                    if (percent >= 1.0)
                    {
                        transitionControl.Size = originalSize;
                        transitionControl.Location = new Point(0, 0);
                        transitionControl.Dock = DockStyle.Fill;  // Restore dock
                        transitionTimer.Stop();
                        transitionTimer.Dispose();
                        transitionTimer = null;
                    }
                    break;
            }
        }
    }
}