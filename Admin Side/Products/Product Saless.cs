using MySql.Data.MySqlClient;
using sims.Admin_Side.Inventory_Report;
using sims.Admin_Side.Products;
using sims.Admin_Side.Sales_Report_Owner;
using sims.Admin_Side.Stocks;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static sims.Admin_Side.Sales.Add_Product;

namespace sims.Admin_Side.Sales
{
    public partial class Product_Saless : Form
    {
        private Old_Inventory_Dashboard _inventoryDashboard;
        private Manage_Stockk _stock;
        private Add_Product _addProductForm;
        private Add_Stock _addStock;
        private Inventory_Reportt _reportt;
        private DashboardOwner _dashboardOwner;
        private Product_Sales _sales;
        public Product_Saless(Old_Inventory_Dashboard inventoryDashboard, Manage_Stockk stock, Add_Stock addStock, Inventory_Reportt reportt, DashboardOwner dashboardOwner, Product_Sales sales)
        {
            InitializeComponent();
            _inventoryDashboard = inventoryDashboard;
            _stock = stock;
            _reportt = reportt;
            _sales = sales;
            _dashboardOwner = dashboardOwner;

        }

        public FlowLayoutPanel CoffeeLayoutPanel
        {
            get { return coffeeLayoutPanel; }
        }

        public FlowLayoutPanel NonCoffeeLayoutPanel
        {
            get { return nonCoffeeLayoutPanel; }
        }

        public FlowLayoutPanel HotCoffeeLayoutPanel
        {
            get { return hotCoffeeLayoutPanel; }
        }

        public FlowLayoutPanel PastriesLayoutPanel
        {
            get { return pastriesLayoutPanel; }
        }

        private void Product_Saless_Load(object sender, EventArgs e)
        {
            LoadProductButtons();
        }

        private void AddProductButton(string productID, string productName, string category)
        {
            // Create a new button for the product
            Button productButton = new Button
            {
                Width = 170,
                Height = 110,
                Text = $"{productName}",
                Tag = new ProductDetails
                {
                    ProductID = productID,
                    ProductName = productName,
                    category = category
                },
                BackColor = Color.FromArgb(222, 196, 125),
                Font = new Font("Poppins", 12),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Attach the click event
            productButton.Click += ProductButton_Click;

            // Add the button to the appropriate FlowLayoutPanel based on the category
            switch (category.Trim().ToLower())
            {
                case "coffee":
                    CoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "non-coffee":
                    NonCoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "hot coffee":
                    HotCoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "pastries":
                    PastriesLayoutPanel.Controls.Add(productButton);
                    break;
                default:
                    // Optionally, handle unknown categories
                    MessageBox.Show($"Unknown category: {category}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is ProductDetails productDetails)
            {
                string productID = productDetails.ProductID;
                string category = productDetails.category; // Retrieve the category

                // Pass both productID and category to the Sales_Form
                Sales_Form detailsForm = new Sales_Form(productID, _stock, _inventoryDashboard, category, _sales);
                detailsForm.Show();
            }
        }

        private void LoadProductButtons()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Product_ID, Product_Name, Category FROM products";

                MySqlDataReader reader = cmd.ExecuteReader();

                CoffeeLayoutPanel.Controls.Clear();
                NonCoffeeLayoutPanel.Controls.Clear();
                HotCoffeeLayoutPanel.Controls.Clear();

                while (reader.Read())
                {
                    string productID = reader.GetInt32("Product_ID").ToString();
                    string productName = reader.GetString("Product_Name");
                    string category = reader.GetString("Category");

                    // Add the product to the appropriate FlowLayoutPanel
                    AddProductButton(productID, productName, category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void NewProductBtn_Click(object sender, EventArgs e)
        {
            _stock = new Manage_Stockk(_inventoryDashboard, _addStock, _dashboardOwner, _reportt);
            _addProductForm = new Add_Product(this, _stock, _inventoryDashboard);
            _addProductForm.Show();
        }

        private void SalesHistoryBtn_Click(object sender, EventArgs e)
        {
            Sales_History_Form salesHistory = new Sales_History_Form();
            salesHistory.Show();
        }
    }
}
