using sims.Admin_Side.Stocks;
using sims.Admin_Side;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sims.Staff_Side.Stocks;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using sims.Messages_Boxes;
using Bunifu.UI.WinForms;

namespace sims.Staff_Side.Sales_Staff
{
    public partial class Sales_Form_Staff : Form
    {
        private string _productID;
        private string _category;
        private Manage_Stocks_Staff _stock;
        private Inventory_Dashboard_Staff _inventoryDashboard;

        public Sales_Form_Staff(string productID, Manage_Stocks_Staff stock, Inventory_Dashboard_Staff inventoryDashboard, string category)
        {
            InitializeComponent();

            _stock = stock;
            _inventoryDashboard = inventoryDashboard;
            _productID = productID;

            quantityStockTxt.TextChanged += (s, e) => CalculateTotalProductSale();
            productPriceTxt.TextChanged += (s, e) => CalculateTotalProductSale();
            _category = category;
        }
        private void previewStock()
        {
            if (_stock != null)
            {
                _stock.ViewStock();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void previewProductsDashboard()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.ProductsCount();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void previewItemSales()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.TotalSalesItems();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void previewStockDashboard()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.StockPreview();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void previewDailySalesChart(string _category)
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.TotalSalesPreview(_category);
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private void Sales_Form_Staff_Load(object sender, EventArgs e)
        {
            LoadProductDetails(_productID);

            // Dynamically determine the correct table name based on the category
            string tableName = DetermineTableName(_category);

            if (!string.IsNullOrEmpty(tableName))
            {
                // Call RetrieveProductDetails with the correct table
                RetrieveProductDetails(_productID, tableName);
            }
            else
            {
                MessageBox.Show("Invalid category. Cannot determine the table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TotalSales(tableName, _category);

            previewStock();
            stocks();

            Timer timer = new Timer();
            timer.Tick += timer1_Tick;
            timer.Start();

            DateLbl.Text = DateTime.Now.ToString("ddd, d MMMM yyyy");
            CalculateTotalProductSale();
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            string tableName = DetermineTableName(_category);
            if (!string.IsNullOrEmpty(tableName))
            {
                RetrieveProductDetails(_productID, tableName);
            }
            else
            {
                MessageBox.Show("Invalid category. Cannot determine table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string DetermineTableName(string category)
        {
            if (category.Equals("Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_coffee";
            }
            else if (category.Equals("Non-Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_noncoffee";
            }
            else if (category.Equals("Hot Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_hotcoffee";
            }
            else if (category.Equals("Pastries", StringComparison.OrdinalIgnoreCase))
            {
                return "productsales_pastries";
            }

            return string.Empty;
        }
        private List<string> allStockItems = new List<string>();
        private bool isUpdatingComboBoxes = false;

        private void stocks()
        {
            string query = "SELECT Item_Name FROM stocks";
            dbModule db = new dbModule();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            allStockItems.Clear();

                            while (reader.Read())
                            {
                                string itemName = reader["Item_Name"].ToString();
                                allStockItems.Add(itemName);
                            }
                        }
                    }
                }

                // Populate combo boxes
                PopulateComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stocks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxes()
        {
            stockCmb.Items.Clear();
            stock2Cmb.Items.Clear();
            stock3Cmb.Items.Clear();
            stock4Cmb.Items.Clear();
            stock5Cmb.Items.Clear();
            stock6Cmb.Items.Clear();

            foreach (var item in allStockItems)
            {
                stockCmb.Items.Add(item);
                stock2Cmb.Items.Add(item);
                stock3Cmb.Items.Add(item);
                stock4Cmb.Items.Add(item);
                stock5Cmb.Items.Add(item);
                stock6Cmb.Items.Add(item);
            }
        }

        private void UpdateComboBoxItems()
        {
            // Prevent recursive updates
            if (isUpdatingComboBoxes) return;

            isUpdatingComboBoxes = true;

            try
            {
                // Get selected items from all combo boxes
                var selectedItems = new HashSet<string>
        {
            stockCmb.SelectedItem?.ToString(),
            stock2Cmb.SelectedItem?.ToString(),
            stock3Cmb.SelectedItem?.ToString(),
            stock4Cmb.SelectedItem?.ToString(),
            stock5Cmb.SelectedItem?.ToString(),
            stock6Cmb.SelectedItem?.ToString()
        };

                // Update each combo box's items
                UpdateComboBox(stockCmb, selectedItems);
                UpdateComboBox(stock2Cmb, selectedItems);
                UpdateComboBox(stock3Cmb, selectedItems);
                UpdateComboBox(stock4Cmb, selectedItems);
                UpdateComboBox(stock5Cmb, selectedItems);
                UpdateComboBox(stock6Cmb, selectedItems);
            }
            finally
            {
                // Re-enable updates
                isUpdatingComboBoxes = false;
            }
        }

        private void UpdateComboBox(GunaComboBox comboBox, HashSet<string> selectedItems)
        {
            // Get the currently selected item
            var currentSelection = comboBox.SelectedItem?.ToString();

            // Clear and repopulate items
            comboBox.Items.Clear();
            foreach (var item in allStockItems)
            {
                if (!selectedItems.Contains(item) || item == currentSelection)
                {
                    comboBox.Items.Add(item);
                }
            }

            // Restore the current selection if still valid
            if (!string.IsNullOrEmpty(currentSelection))
            {
                comboBox.SelectedItem = currentSelection;
            }
        }

        public void TotalSales(string tableName, string category)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Use the provided table name in the query
                cmd.CommandText = $"SELECT SUM(Total_Product_Sale) AS TotalSales FROM {tableName}";

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);

                // Set the category label
                categoryLbl.Text = $"Total Sale of {category}: ";

                if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("TotalSales"))
                {
                    object totalSalesValue = dataTable.Rows[0]["TotalSales"];
                    if (decimal.TryParse(totalSalesValue?.ToString(), out decimal totalSales))
                    {
                        totalSalesLbl.Text = $"₱ {totalSales:0.00}";
                    }
                    else
                    {
                        totalSalesLbl.Text = "₱ 0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to populate sales data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void CalculateTotalProductSale()
        {
            try
            {
                // Parse quantity and price
                if (int.TryParse(quantityStockTxt.Text, out int quantity) &&
                    decimal.TryParse(productPriceTxt.Text, out decimal price))
                {
                    decimal totalValue = quantity * price;

                    // Store the numeric value in the Tag property
                    totalSaleTxt.Tag = totalValue;

                    // Display the formatted value with a peso sign
                    totalSaleTxt.Text = $"₱ {totalValue:0.00}";
                }
                else
                {
                    // Clear the total sale field if inputs are invalid
                    totalSaleTxt.Text = string.Empty;
                    totalSaleTxt.Tag = null;
                }
            }
            catch (Exception ex)
            {
                // Show an error message in case of unexpected issues
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadProductDetails(string productID)
        {
            dbModule db = new dbModule();
            string query = "SELECT Product_ID, Product_Name, Category " +
                           "FROM products WHERE Product_ID = @Product_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Product_ID", _productID);
                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productIDTxt.Text = reader["Product_ID"].ToString();
                                productNameTxt.Text = reader["Product_Name"].ToString();
                                string categoryValue = reader["Category"].ToString();

                                if (!string.IsNullOrEmpty(categoryValue))
                                {
                                    categoryCmb.SelectedItem = categoryValue;
                                    if (!categoryCmb.Items.Contains(categoryValue))
                                    {
                                        categoryCmb.Items.Add(categoryValue);
                                        categoryCmb.SelectedItem = categoryValue;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while fetching product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void RetrieveProductDetails(string productID, string tableName)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Use the provided table name in the query
                cmd.CommandText = $@"
                SELECT Product_ID, Product_Name, Category, Product_Price, Stock_Quantity, Quantity_Sold, Stock_Needed
                FROM {tableName}
                WHERE Product_ID = @ProductID";

                cmd.Parameters.AddWithValue("@ProductID", productID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the textboxes with the retrieved data
                        productIDTxt.Text = reader["Product_ID"]?.ToString() ?? string.Empty;
                        productNameTxt.Text = reader["Product_Name"]?.ToString() ?? string.Empty;
                        categoryCmb.SelectedItem = reader["Category"]?.ToString();
                        productPriceTxt.Text = reader["Product_Price"]?.ToString() ?? "0.00";
                        quantityStockTxt.Text = reader["Stock_Quantity"]?.ToString() ?? "0";
                        quantitySoldTxt.Text = reader["Quantity_Sold"]?.ToString() ?? "0";

                        // Retrieve the 'Stock_Needed' column, which contains the stock items
                        string stockNeeded = reader["Stock_Needed"]?.ToString();

                        if (!string.IsNullOrEmpty(stockNeeded))
                        {
                            // Split the 'Stock_Needed' value into separate items based on a delimiter (e.g., comma)
                            string[] stockItems = stockNeeded.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                             .Select(s => s.Trim()) // Trim any extra spaces
                                                             .ToArray();

                            // Assign each item to the corresponding ComboBox if available
                            if (stockItems.Length >= 1) stockCmb.SelectedItem = stockItems[0];
                            if (stockItems.Length >= 2) stock2Cmb.SelectedItem = stockItems[1];
                            if (stockItems.Length >= 3) stock3Cmb.SelectedItem = stockItems[2];
                            if (stockItems.Length >= 4) stock4Cmb.SelectedItem = stockItems[3];
                            if (stockItems.Length >= 5) stock5Cmb.SelectedItem = stockItems[4];
                            if (stockItems.Length >= 6) stock6Cmb.SelectedItem = stockItems[5];
                        }
                        else
                        {
                            // Clear selections if no stock items are available
                            stockCmb.SelectedIndex = -1;
                            stock2Cmb.SelectedIndex = -1;
                            stock3Cmb.SelectedIndex = -1;
                            stock4Cmb.SelectedIndex = -1;
                            stock5Cmb.SelectedIndex = -1;
                            stock6Cmb.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            addProduct();
        }
        private void addProduct()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string productID = productIDTxt.Text.Trim();
            string productName = productNameTxt.Text.Trim();
            string category = categoryCmb.SelectedItem?.ToString().Trim() ?? string.Empty;
            string productPrice = productPriceTxt.Text.Trim();
            string stockQuantity = quantityStockTxt.Text.Trim();
            string quantitySold = quantitySoldTxt.Text.Trim();

            List<string> stockItems = new List<string>();
            if (!string.IsNullOrEmpty(stockCmb.SelectedItem?.ToString())) stockItems.Add(stockCmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock2Cmb.SelectedItem?.ToString())) stockItems.Add(stock2Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock3Cmb.SelectedItem?.ToString())) stockItems.Add(stock3Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock4Cmb.SelectedItem?.ToString())) stockItems.Add(stock4Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock5Cmb.SelectedItem?.ToString())) stockItems.Add(stock5Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock6Cmb.SelectedItem?.ToString())) stockItems.Add(stock6Cmb.SelectedItem.ToString());

            // Add more stock items if necessary...

            string stockNeeded = string.Join(", ", stockItems);

            if (string.IsNullOrEmpty(productID) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(stockQuantity) || string.IsNullOrEmpty(quantitySold))
            {
                new Field_Required().Show();
                return;
            }

            if (!int.TryParse(stockQuantity, out var parsedStockQuantity))
            {
                MessageBox.Show("Invalid stock quantity. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(quantitySold, out var parsedQuantitySold))
            {
                MessageBox.Show("Invalid quantity sold. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dynamically determine the table name based on category
            string tableName = string.Empty;

            if (category.Equals("Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_coffee";
            }
            else if (category.Equals("Non-Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_noncoffee";
            }
            else if (category.Equals("Hot Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_hotcoffee";
            }
            else if (category.Equals("Pastries", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_pastries";
            }
            else
            {
                MessageBox.Show($"Invalid category: {category}. Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call TotalSales with the correct table name
            TotalSales(tableName, _category);

            // Convert DateLbl.Text to a DateTime object
            if (!DateTime.TryParse(DateLbl.Text, out DateTime saleDate))
            {
                MessageBox.Show("Invalid date format in DateLbl. Please check the value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Format the date for MySQL
            string formattedDate = saleDate.ToString("yyyy-MM-dd");

            // Format the current time for MySQL
            string formattedTime = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Use dynamic table name in the INSERT statement
                cmd.CommandText = $"INSERT INTO {tableName} (Sales_ID, Product_ID, Product_Name, Category, Product_Price, Stock_Quantity, Quantity_Sold, Total_Product_Sale, Stock_Needed, Sale_Date, Sale_Time) " +
                                  "VALUES (@Sales_ID, @Product_ID, @Product_Name, @Category, @Product_Price, @Stock_Quantity, @Quantity_Sold, @Total_Product_Sale, @Stock_Needed, @Sale_Date, @Sale_Time)";

                cmd.Parameters.AddWithValue("@Sales_ID", Guid.NewGuid().ToString()); // Generate a unique Sales ID
                cmd.Parameters.AddWithValue("@Product_ID", productID);
                cmd.Parameters.AddWithValue("@Product_Name", productName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Product_Price", decimal.TryParse(productPrice, out var price) ? price : 0);
                cmd.Parameters.AddWithValue("@Stock_Quantity", stockQuantity);
                cmd.Parameters.AddWithValue("@Quantity_Sold", int.TryParse(quantitySold, out var stock) ? stock : 0);
                cmd.Parameters.AddWithValue("@Total_Product_Sale", totalSaleTxt.Tag?.ToString() ?? "0");
                cmd.Parameters.AddWithValue("@Stock_Needed", stockNeeded);
                cmd.Parameters.AddWithValue("@Sale_Date", formattedDate);
                cmd.Parameters.AddWithValue("@Sale_Time", formattedTime);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    foreach (var stockItem in stockItems)
                    {
                        // Update query to reduce both Stock_In and Item_Total
                        cmd.CommandText = @"UPDATE stocks SET Stock_In = Stock_In - @Stock_In, Item_Total = Item_Total - (@Stock_In * Item_Price) 
                            WHERE Item_Name = @ItemName";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Stock_In", parsedStockQuantity);  // Quantity sold
                        cmd.Parameters.AddWithValue("@ItemName", stockItem);            // Item name

                        cmd.ExecuteNonQuery();

                        previewStock();
                        previewStockDashboard();
                        previewItemSales();
                        previewDailySalesChart(_category);
                        //previewMonthlySalesChart(_category);
                    }

                    MessageBox.Show("Product added successfully, and stock quantities updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset the form
                    productNameTxt.Clear();
                    categoryCmb.SelectedIndex = -1;
                    productPriceTxt.Clear();
                    quantitySoldTxt.Clear();
                    stockCmb.SelectedIndex = -1;
                    stock2Cmb.SelectedIndex = -1;
                    this.Hide();
                    previewProductsDashboard();
                }
                else
                {
                    MessageBox.Show("Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void UpdateProductBtn_Click(object sender, EventArgs e)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string productID = productIDTxt.Text.Trim();
            string productName = productNameTxt.Text.Trim();
            string category = categoryCmb.SelectedItem?.ToString().Trim() ?? string.Empty;
            string productPriceText = productPriceTxt.Text.Trim();
            string stockQuantityText = quantityStockTxt.Text.Trim();
            string quantitySoldText = quantitySoldTxt.Text.Trim();

            List<string> stockItems = new List<string>();
            if (!string.IsNullOrEmpty(stockCmb.SelectedItem?.ToString())) stockItems.Add(stockCmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock2Cmb.SelectedItem?.ToString())) stockItems.Add(stock2Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock3Cmb.SelectedItem?.ToString())) stockItems.Add(stock3Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock4Cmb.SelectedItem?.ToString())) stockItems.Add(stock4Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock5Cmb.SelectedItem?.ToString())) stockItems.Add(stock5Cmb.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(stock6Cmb.SelectedItem?.ToString())) stockItems.Add(stock6Cmb.SelectedItem.ToString());

            // Add more stock items if necessary...

            string stockNeeded = string.Join(", ", stockItems);

            if (string.IsNullOrEmpty(productID) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(stockQuantityText) || string.IsNullOrEmpty(quantitySoldText))
            {
                new Field_Required().Show();
                return;
            }

            if (!decimal.TryParse(productPriceText, out var productPrice))
            {
                MessageBox.Show("Invalid product price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stockQuantityText, out var stockQuantity))
            {
                MessageBox.Show("Invalid stock quantity. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(quantitySoldText, out var quantitySold))
            {
                MessageBox.Show("Invalid quantity sold. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(DateLbl.Text, out var saleDate))
            {
                MessageBox.Show("Invalid sale date format. Please check the DateLbl value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Determine the table name
            string tableName = string.Empty;
            if (category.Equals("Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_coffee";
            }
            else if (category.Equals("Non-Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_noncoffee";
            }
            else if (category.Equals("Hot Coffee", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_hotcoffee";
            }
            else if (category.Equals("Pastries", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "productsales_pastries";
            }
            else
            {
                MessageBox.Show("Invalid category. Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Update query
                cmd.CommandText = $"UPDATE {tableName} " +
                                  "SET Product_Name = @Product_Name, Category = @Category, Product_Price = @Product_Price, " +
                                  "Stock_Quantity = @Stock_Quantity, Quantity_Sold = @Quantity_Sold, Total_Product_Sale = @Total_Product_Sale, " +
                                  "Stock_Needed = @Stock_Needed, Sale_Date = @Sale_Date, Sale_Time = @Sale_Time " +
                                  "WHERE Product_ID = @Product_ID";

                cmd.Parameters.AddWithValue("@Product_ID", productID);
                cmd.Parameters.AddWithValue("@Product_Name", productName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Product_Price", productPrice);
                cmd.Parameters.AddWithValue("@Stock_Quantity", stockQuantity);
                cmd.Parameters.AddWithValue("@Quantity_Sold", quantitySold);
                cmd.Parameters.AddWithValue("@Total_Product_Sale", quantitySold * productPrice);
                cmd.Parameters.AddWithValue("@Stock_Needed", stockNeeded);
                cmd.Parameters.AddWithValue("@Sale_Date", saleDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Sale_Time", DateTime.Now.ToString("HH:mm:ss"));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    foreach (var stockItem in stockItems)
                    {
                        // Update query to reduce both Stock_In and Item_Total
                        cmd.CommandText = @"UPDATE stocks SET Stock_In = Stock_In - @Stock_In, Item_Total = Item_Total - (@Stock_In * Item_Price) 
                            WHERE Item_Name = @ItemName";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Stock_In", stockQuantity);  // Quantity sold
                        cmd.Parameters.AddWithValue("@ItemName", stockItem);            // Item name

                        cmd.ExecuteNonQuery();

                        previewStock();
                        previewStockDashboard();
                        previewItemSales();
                        previewDailySalesChart(_category);

                    }

                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    previewProductsDashboard();
                    TotalSales(tableName, _category);
                    previewDailySalesChart(_category);
                }

                else
                {
                    MessageBox.Show("No changes were made to the product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show($"MySQL Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void UpdateProduct(string productID, string productName, string category, decimal productPrice, int stockQuantity, int quantitySold, string stockNeeded, string tableName, DateTime saleDate)
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Update query
                cmd.CommandText = $"UPDATE {tableName} " +
                                  "SET Product_Name = @Product_Name, Category = @Category, Product_Price = @Product_Price, " +
                                  "Stock_Quantity = @Stock_Quantity, Quantity_Sold = @Quantity_Sold, Total_Product_Sale = @Total_Product_Sale, " +
                                  "Stock_Needed = @Stock_Needed, Sale_Date = @Sale_Date, Sale_Time = @Sale_Time " +
                                  "WHERE Product_ID = @Product_ID";

                cmd.Parameters.AddWithValue("@Product_ID", productID);
                cmd.Parameters.AddWithValue("@Product_Name", productName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Product_Price", productPrice);
                cmd.Parameters.AddWithValue("@Stock_Quantity", stockQuantity);
                cmd.Parameters.AddWithValue("@Quantity_Sold", quantitySold);
                cmd.Parameters.AddWithValue("@Total_Product_Sale", quantitySold * productPrice);
                cmd.Parameters.AddWithValue("@Stock_Needed", stockNeeded);
                cmd.Parameters.AddWithValue("@Sale_Date", saleDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Sale_Time", DateTime.Now.ToString("HH:mm:ss"));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    previewProductsDashboard();
                    TotalSales(tableName, _category);
                    previewDailySalesChart(_category);
                }
                else
                {
                    MessageBox.Show("No changes were made to the product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show($"MySQL Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
                conn.Dispose();
            }
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            stockCmb.SelectedIndex = -1;
            stock2Cmb.SelectedIndex = -1;
            stock3Cmb.SelectedIndex = -1;
            stock4Cmb.SelectedIndex = -1;
            stock5Cmb.SelectedIndex = -1;
            stock6Cmb.SelectedIndex = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLbl.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void ValidateTextBoxForNumbersOnly(BunifuTextBox textBox)
        {
            string newText = textBox.Text;

            if (System.Text.RegularExpressions.Regex.IsMatch(newText, @"[a-zA-Z]"))
            {
                MessageBox.Show("Letters are not allowed!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = System.Text.RegularExpressions.Regex.Replace(newText, @"[a-zA-Z]", "");
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void productPriceTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxForNumbersOnly(productPriceTxt);
        }

        private void quantitySoldTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxForNumbersOnly(quantitySoldTxt);
        }

        private void quantityStockTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxForNumbersOnly(quantityStockTxt);

            quantitySoldTxt.Text = quantityStockTxt.Text;
        }

        private void stockCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void stock2Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void stock3Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void stock4Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void stock5Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void stock6Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }
    }
}