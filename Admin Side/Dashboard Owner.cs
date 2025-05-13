using FontAwesome.Sharp;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using Guna.UI2.AnimatorNS;
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
        private User_Staff manageUserStaffInstance;
        private Database_Backup databaseBackupInstance;
        private readonly Add_Stock addStockInstance;

        private Form activeForm = null;

        public PictureBox bellIcon
        {
            get { return pictureBox1; }
        }

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
            manageUserStaffInstance = new User_Staff();
            databaseBackupInstance = new Database_Backup();

            LoadForm(dashboardInventoryInstance);

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

        private void LoadForm(Form formInstance)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            activeForm = formInstance;
            formInstance.TopLevel = false;
            formInstance.FormBorderStyle = FormBorderStyle.None;
            formInstance.Dock = DockStyle.Fill;
            formInstance.MouseDown += (s, e) => ((Form)s).Capture = false;

            if (!DashboardPanel.Controls.Contains(formInstance))
            {
                DashboardPanel.Controls.Add(formInstance);
            }

            formInstance.Show();
            formInstance.BringToFront();
        }

        // Modified OpeninPanel method with transition
        private void OpeninPanel(object formOpen)
        {
            foreach (Control control in DashboardPanel.Controls)
            {
                control.Visible = false;
            }
            if (formOpen is Form dh)
            {
                if (!DashboardPanel.Controls.Contains(dh))
                {
                    dh.TopLevel = false;
                    dh.FormBorderStyle = FormBorderStyle.None;
                    dh.Dock = DockStyle.Fill;
                    DashboardPanel.Controls.Add(dh);
                    DashboardPanel.Tag = dh;
                }

                dh.Visible = true;
                dh.BringToFront();
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
            customizeDesign();
            OpeninPanel(dashboardInventoryInstance);
        }

        private void CategoriesBtn_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, Color.FromArgb(255, 255, 255));
            //OpeninPanel(manageCategoryInstance);
            //customizeDesign();
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(InventoryPanelSubMenu);
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageItemsInstance);

        }

        private void StocksBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageStockInstance);

        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(salesPanelSubMenu);
        }

        private void productSalesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(productSalesInstance);
        }

        private void salesReportBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageSalesReportInstance);
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageUserStaffInstance);
            customizeDesign();
        }

        private void backupDbBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(databaseBackupInstance);
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
    }
}