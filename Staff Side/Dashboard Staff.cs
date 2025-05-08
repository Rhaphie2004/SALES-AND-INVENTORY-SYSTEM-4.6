    using FontAwesome.Sharp;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using sims.Admin_Side;
using sims.Admin_Side.Items;
using sims.Admin_Side.Sales_Report_Owner;
using sims.Admin_Side.Stocks;
using sims.Staff_Side.Items;
using sims.Staff_Side.Sales_Staff;
using sims.Staff_Side.Stocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Staff_Side
{
    public partial class Dashboard_Staff : Form
    {
        private IconButton currentBtn;
        private GunaPanel leftBorderBtn;

        private Inventory_Dashboard_Staff dashboardInventoryInstance;
        private Manage_Items_Staff manageItemsStaffInstance;
        private Manage_Stocks_Staff manageStocksStaffInstance;
        private Product_Sales_Staff productSalesStaffInstance;
        private Add_Stocks_Staff addStockInstance;
        private Product_Sales salesReportStaffInstance;

        private string loggedInStaffName;

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

        public Dashboard_Staff(string staffName)
        {
            InitializeComponent();
            leftBorderBtn = new GunaPanel
            {
                Size = new Size(10, 58)
            };
            PanelMenu.Controls.Add(leftBorderBtn);
            loggedInStaffName = staffName;

            Timer timer = new Timer();
            timer.Tick += timer1_Tick;
            timer.Start();

            DateLbl.Text = DateTime.Now.ToString("ddd, d MMMM yyyy");
        }

        public PictureBox bellIcon
        {
            get { return pictureBox1; }
        }

        private void Dashboard_Staff_Load(object sender, EventArgs e)
        {
            ShowUsernameWithGreeting();

            dashboardInventoryInstance = new Inventory_Dashboard_Staff();
            manageItemsStaffInstance = new Manage_Items_Staff(dashboardInventoryInstance);
            manageStocksStaffInstance = new Manage_Stocks_Staff(dashboardInventoryInstance, addStockInstance, this);
            productSalesStaffInstance = new Product_Sales_Staff(dashboardInventoryInstance, manageStocksStaffInstance, addStockInstance, this);
            salesReportStaffInstance = new Product_Sales();
            LoadView(dashboardInventoryInstance);
            ActivateButton(DashboardBtn, Color.White);

        }

        private void ShowUsernameWithGreeting()
        {
            dbModule db = new dbModule();
            string query = "SELECT Staff_Name FROM staff";

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
                            greetingNameTxt.Text = $"HI! {loggedInStaffName},";
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
                form.Visible = true;
                form.BringToFront();
            }
            else
            {
                throw new InvalidOperationException("Unsupported type. Only UserControl and Form are allowed.");
            }
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

        private void OpeninPanel(object formOpen, TransitionEffect effect = TransitionEffect.Slide)
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
                // Store the control for use in the timer
                transitionControl = toShow;

                // Set current effect
                currentEffect = effect;

                // Important: Temporarily remove Dock to allow positioning
                toShow.Dock = DockStyle.None;

                // Make sure the control is the right size
                toShow.Size = DashboardPanel.Size;

                // Initialize control based on effect
                switch (effect)
                {
                    case TransitionEffect.Slide:
                        // Place completely off-screen to the left
                        toShow.Location = new Point(-toShow.Width, 0);
                        toShow.Visible = true;
                        break;

                    case TransitionEffect.Fade:
                        toShow.Location = new Point(0, 0);
                        toShow.Visible = true;

                        // Set initial opacity
                        if (toShow is Form form)
                        {
                            form.Opacity = 0;
                        }
                        else
                        {
                            Color originalColor = toShow.BackColor;
                            // Store the original color for later
                            toShow.Tag = originalColor;
                            toShow.BackColor = Color.FromArgb(0, originalColor.R, originalColor.G, originalColor.B);
                        }
                        break;

                    case TransitionEffect.Zoom:
                        // Store original size
                        toShow.Tag = new Size(toShow.Width, toShow.Height);

                        // Start with smaller size centered
                        int startWidth = toShow.Width / 4;
                        int startHeight = toShow.Height / 4;
                        toShow.Size = new Size(startWidth, startHeight);
                        toShow.Location = new Point(
                            (DashboardPanel.Width - startWidth) / 2,
                            (DashboardPanel.Height - startHeight) / 2
                        );
                        toShow.Visible = true;
                        break;

                    case TransitionEffect.None:
                    default:
                        toShow.Location = new Point(0, 0);
                        toShow.Visible = true;
                        toShow.BringToFront();
                        toShow.Dock = DockStyle.Fill;  // Restore dock
                        return; // No animation needed
                }

                // Reset progress
                transitionProgress = 0;

                // Setup and start timer
                transitionTimer = new Timer();
                transitionTimer.Interval = 10;
                transitionTimer.Tick += TimerTransition_Tick;
                transitionTimer.Start();

                // Bring control to front
                toShow.BringToFront();
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
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageItemsStaffInstance);
        }

        private void StocksBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(manageStocksStaffInstance);
        }

        private void productSalesBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(productSalesStaffInstance);
        }

        private void salesReportBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 255, 255));
            OpeninPanel(salesReportStaffInstance);
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