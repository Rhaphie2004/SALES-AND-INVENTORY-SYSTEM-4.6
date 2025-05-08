using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
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
    public partial class Inventory_Dashboard_Staff : Form
    {
        public Inventory_Dashboard_Staff()
        {
            InitializeComponent();

        }

        private void Inventory_Dashboard_Staff_Load(object sender, EventArgs e)
        {
            ItemsCount();
            ProductsCount();
            StockPreview();
            TotalSalesItems();

            TotalSalesPreview("Coffee");
            MonthlySalesPreview("Coffee");
            ResetPreviousDaySales();
        }

        public void ItemsCount()
        {
            dbModule db = new dbModule();
            string query = "SELECT COUNT(*) FROM items";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int itemCount = Convert.ToInt32(cmd.ExecuteScalar());
                        itemsCountTxt.Text = itemCount.ToString();
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

        public void ProductsCount()
        {
            dbModule db = new dbModule();
            string query = "SELECT COUNT(*) FROM products";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int itemCount = Convert.ToInt32(cmd.ExecuteScalar());
                        productsCountTxt.Text = itemCount.ToString();
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
        public void TotalSalesItems()
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

                // Query to get all stocks and calculate the total of Item_Total
                cmd.CommandText = "SELECT *, SUM(Item_Total) AS TotalSales FROM stocks";

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);

                //activityLogsBtn.DataSource = dataTable;

                // Check if the TotalSales column is present in the result
                if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("TotalSales"))
                {
                    object totalSalesValue = dataTable.Rows[0]["TotalSales"];
                    if (decimal.TryParse(totalSalesValue?.ToString(), out decimal totalSales))
                    {
                        // Format the total sales value with a peso sign
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
                MessageBox.Show($"Failed to populate stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void StockPreview()
        {
            dbModule db = new dbModule();
            SeriesCollection series = new SeriesCollection();

            // Dictionary to aggregate stocks by item name
            Dictionary<string, int> stockMap = new Dictionary<string, int>();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Item_Name, Stock_In FROM stocks";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["Item_Name"]?.ToString() ?? string.Empty;

                            if (int.TryParse(reader["Stock_In"]?.ToString(), out int stockIn))
                            {
                                if (stockMap.ContainsKey(itemName))
                                {
                                    stockMap[itemName] += stockIn; // Sum duplicates
                                }
                                else
                                {
                                    stockMap[itemName] = stockIn;
                                }
                            }
                        }
                    }
                }

                if (stockPreviewChart != null)
                {
                    ChartValues<int> values = new ChartValues<int>();
                    List<string> itemNames = new List<string>();

                    // Order for consistent axis rendering
                    foreach (var entry in stockMap)
                    {
                        itemNames.Add(entry.Key);
                        values.Add(entry.Value);
                    }

                    stockPreviewChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Stock",
                    Values = values,
                    DataLabels = true
                }
            };

                    stockPreviewChart.AxisX.Clear();
                    stockPreviewChart.AxisX.Add(new Axis
                    {
                        Title = "Item Name",
                        Labels = itemNames,
                        LabelsRotation = 15,
                        Separator = new Separator { Step = 1 },
                        MinValue = 0,
                        MaxValue = 10 // Adjust depending on how many to show at once
                    });

                    stockPreviewChart.AxisY.Clear();
                    stockPreviewChart.AxisY.Add(new Axis
                    {
                        Title = "Item Stocks",
                        LabelFormatter = value => value.ToString()
                    });

                    stockPreviewChart.Zoom = ZoomingOptions.X;
                    stockPreviewChart.Pan = PanningOptions.X;
                    stockPreviewChart.DisableAnimations = true;

                    stockPreviewChart.Update(true, true);
                }
                else
                {
                    MessageBox.Show("Cartesian chart is not initialized!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ResetPreviousDaySales()
        {
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            dbModule db = new dbModule();
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                Dictionary<string, string> tablePairs = new Dictionary<string, string>
        {
            { "productsales_coffee", "productsaleshistory_coffee" },
            { "productsales_noncoffee", "productsaleshistory_noncoffee" },
            { "productsales_hotcoffee", "productsaleshistory_hotcoffee" },
            { "productsales_pastries", "productsaleshistory_pastries" }
        };

                bool hasReset = false; // Track if any reset happened

                foreach (var pair in tablePairs)
                {
                    string currentTable = pair.Key;
                    string historyTable = pair.Value;

                    string insertQuery = $@"
                INSERT INTO {historyTable} 
                (Sales_ID, Product_ID, Product_Name, Category, Product_Price, Stock_Quantity, Quantity_Sold, Total_Product_Sale, Stock_Needed, Sale_Date, Sale_Time)
                SELECT Sales_ID, Product_ID, Product_Name, Category, Product_Price, Stock_Quantity, Quantity_Sold, Total_Product_Sale, Stock_Needed, Sale_Date, Sale_Time
                FROM {currentTable}
                WHERE Sale_Date < @Today";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Today", todayDate);
                        int insertedRows = insertCmd.ExecuteNonQuery(); // returns number of rows inserted

                        if (insertedRows > 0)
                        {
                            hasReset = true;
                        }
                    }

                    string deleteQuery = $"DELETE FROM {currentTable} WHERE Sale_Date < @Today";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@Today", todayDate);
                        deleteCmd.ExecuteNonQuery();
                    }
                }

                if (hasReset)
                {
                    MessageBox.Show("Previous day's sales have been saved to history, reset, and removed from current tables.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // else, no message box shown
            }
        }

        public void TotalSalesPreview(string category)
        {
            dbModule db = new dbModule();
            SeriesCollection series = new SeriesCollection();
            decimal totalSales = 0;

            try
            {
                // Determine the table name based on the category
                string tableName = DetermineTableName(category);
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show($"Invalid category: {category}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Get total sales for the category
                    string totalSalesQuery = $"SELECT SUM(Total_Product_Sale) AS TotalSales FROM {tableName}";
                    MySqlCommand totalSalesCmd = new MySqlCommand(totalSalesQuery, conn);
                    object result = totalSalesCmd.ExecuteScalar();
                    totalSales = (result == DBNull.Value || result == null) ? 0 : Convert.ToDecimal(result);

                    // Get sales and quantity per product
                    string query = $@"SELECT Product_Name, 
                SUM(Total_Product_Sale) AS TotalSales, 
                SUM(Quantity_Sold) AS TotalQuantity 
                FROM {tableName} 
                GROUP BY Product_Name";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader["Product_Name"]?.ToString() ?? "Unknown Product";
                            decimal productSales = reader["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalSales"]);
                            int productQuantity = reader["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalQuantity"]);

                            // Add the product data to the chart
                            series.Add(new PieSeries
                            {
                                Title = $"{productName} ({productQuantity} sold)", // Include quantity in the label
                                Values = new ChartValues<decimal> { productSales },
                                DataLabels = true
                            });
                        }
                    }
                }

                if (DailySalesChart != null)
                {
                    // Clear and set the pie chart series
                    DailySalesChart.Series.Clear();
                    DailySalesChart.Series = series;

                    // Update chart properties
                    DailySalesChart.LegendLocation = LegendLocation.Bottom;
                    DailySalesChart.Update(true, true);

                    // Update the title label
                    chartTitleLabel.Text = $"{category} Sales";
                    chartTitleLabel.Font = new Font("Poppins", 11);
                    chartTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    MessageBox.Show("Pie chart is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MonthlySalesPreview(string category)
        {
            dbModule db = new dbModule();
            SeriesCollection series = new SeriesCollection();
            decimal totalSales = 0;

            try
            {
                // Determine the table name based on the category
                string tableName = DetermineMonthlyTableName(category);
                if (string.IsNullOrEmpty(tableName))
                {
                    MessageBox.Show($"Invalid category: {category}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Get total sales for the category
                    string totalSalesQuery = $"SELECT SUM(Total_Product_Sale) AS TotalSales FROM {tableName}";
                    MySqlCommand totalSalesCmd = new MySqlCommand(totalSalesQuery, conn);
                    object result = totalSalesCmd.ExecuteScalar();
                    totalSales = (result == DBNull.Value || result == null) ? 0 : Convert.ToDecimal(result);

                    // Get sales per product
                    string query = $@"
                SELECT 
                    Product_Name, 
                    SUM(Total_Product_Sale) AS TotalSales, 
                    SUM(Quantity_Sold) AS TotalQuantity 
                FROM {tableName} 
                GROUP BY Product_Name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader["Product_Name"]?.ToString() ?? "Unknown Product";
                            decimal productSales = reader["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalSales"]);
                            int productQuantity = reader["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalQuantity"]);

                            series.Add(new PieSeries
                            {
                                Title = $"{productName} ({productQuantity} sold)", // Include quantity in the label
                                Values = new ChartValues<decimal> { productSales },
                                DataLabels = true
                            });
                        }
                    }
                }

                if (MonthlySalesChart != null)
                {
                    // Clear and set the pie chart series
                    MonthlySalesChart.Series.Clear();
                    MonthlySalesChart.Series = series;

                    // Update chart properties
                    //MonthlySalesChart.LegendLocation = LegendLocation.Bottom;
                    //MonthlySalesChart.Update(true, true);

                    // Update the title label
                    chartMonthlyLbl.Text = $"{category} Monthly Sales";
                    chartMonthlyLbl.Font = new Font("Poppins", 11);
                    chartMonthlyLbl.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    MessageBox.Show("Pie chart is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string DetermineMonthlyTableName(string category)
        {
            if (category.Equals("Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsaleshistory_coffee";
            }
            else if (category.Equals("Non-Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsaleshistory_noncoffee";
            }
            else if (category.Equals("Hot Coffee", StringComparison.OrdinalIgnoreCase))
            {
                return "productsaleshistory_hotcoffee";
            }
            else if (category.Equals("Pastries", StringComparison.OrdinalIgnoreCase))
            {
                return "productsaleshistory_pastries";
            }
            return string.Empty;
        }

        private void CoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Coffee");
        }

        private void NonCoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Non-Coffee");
        }

        private void HotCoffeeMenuItem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Hot Coffee");
        }

        private void PastriesMenuITem_Click(object sender, EventArgs e)
        {
            TotalSalesPreview("Pastries");
        }

        private void CoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            MonthlySalesPreview("Coffee");
        }

        private void NonCoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            MonthlySalesPreview("Non-Coffee");
        }

        private void HotCoffeeMonthlyChart_Click(object sender, EventArgs e)
        {
            MonthlySalesPreview("Hot Coffee");
        }

        private void PastriesMonthlyMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySalesPreview("Pastries");
        }
    }
}
