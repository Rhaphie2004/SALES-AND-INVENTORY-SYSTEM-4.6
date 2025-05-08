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
using sims.Notification.Stock_notification;
using System.IO;
using MySql.Data.MySqlClient;
using Bunifu.UI.WinForms;

namespace sims.Staff_Side.Stocks
{
    public partial class Edit_Stocks_Staff : Form
    {
        private string _itemID;
        private Inventory_Dashboard_Staff _inventoryDashboard;
        private Manage_Stocks_Staff dashboard;

        public Edit_Stocks_Staff(string itemID, Inventory_Dashboard_Staff inventoryDashboard, Manage_Stocks_Staff dashboard)
        {
            InitializeComponent();
            _itemID = itemID;

            itemQuantityTxt.TextChanged += (s, e) => CalculateTotalValue();
            itemPriceTxt.TextChanged += (s, e) => CalculateTotalValue();

            _inventoryDashboard = inventoryDashboard;
            this.dashboard = dashboard;
        }
        public void Alert(string msg)
        {
            Stock_Update frm = new Stock_Update();
            frm.showalert(msg);
        }

        private void previewStock()
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

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image cannot be null.");

            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void Edit_Stocks_Staff_Load(object sender, EventArgs e)
        {
            LoadProductDetails(_itemID);
            previewStock();
            Populate();
            UnitType();
            dateAddedDtp.Value = DateTime.Now;
        }
        private void Populate()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM stocks";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dashboard.ItemsStockDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UnitType()
        {
            string query = "SELECT Unit_Type FROM unittype";
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
                            while (reader.Read())
                            {
                                unitTypeCmb.Items.Add(reader["Unit_Type"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalValue()
        {
            try
            {
                if (int.TryParse(itemQuantityTxt.Text, out int quantity) &&
                    decimal.TryParse(itemPriceTxt.Text, out decimal price))
                {
                    decimal totalValue = quantity * price;

                    // Store the plain numeric value in a variable for future use
                    itemTotalTxt.Tag = totalValue;

                    // Display the value with a peso sign and formatting
                    itemTotalTxt.Text = $"₱ {totalValue:0.00}";
                }
                else
                {
                    itemTotalTxt.Text = string.Empty;
                    itemTotalTxt.Tag = null; // Clear the stored value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadProductDetails(string itemID)
        {
            dbModule db = new dbModule();
            string query = "SELECT Item_ID, Item_Name, Stock_In, Unit_Type, Date_Added, Item_Price, Item_Total, Item_Image " +
                           "FROM stocks WHERE Stock_ID = @Stock_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Stock_ID", itemID);
                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string itemName = reader["Item_Name"].ToString();
                                itemIDTxt.Text = reader["Item_ID"].ToString();
                                itemQuantityTxt.Text = reader["Stock_In"].ToString();
                                string unitType = reader["Unit_Type"].ToString();
                                itemPriceTxt.Text = reader["Item_Price"].ToString();
                                itemTotalTxt.Text = reader["Item_Total"].ToString();

                                if (!string.IsNullOrEmpty(itemName))
                                {
                                    selectItemNameCmb.SelectedItem = itemName;
                                    if (!selectItemNameCmb.Items.Contains(itemName))
                                    {
                                        selectItemNameCmb.Items.Add(itemName);
                                        selectItemNameCmb.SelectedItem = itemName;
                                    }
                                }

                                if (!string.IsNullOrEmpty(unitType))
                                {
                                    unitTypeCmb.SelectedItem = unitType;
                                    if (!unitTypeCmb.Items.Contains(unitType))
                                    {
                                        unitTypeCmb.Items.Add(unitType);
                                        unitTypeCmb.SelectedItem = unitType;
                                    }
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("Item_Image")))
                                {
                                    byte[] imageBytes = (byte[])reader["Item_Image"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        itemImagePic.Image = System.Drawing.Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    itemImagePic.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void updateStockBtn_Click(object sender, EventArgs e)
        {
            UpdateItemStock();
        }
        private void UpdateItemStock()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string itemID = itemIDTxt.Text.Trim();
            string itemName = selectItemNameCmb.SelectedItem?.ToString() ?? string.Empty;
            string stockIn = itemQuantityTxt.Text.Trim();
            string unitType = unitTypeCmb.SelectedItem?.ToString() ?? string.Empty;
            string dateAdded = dateAddedDtp.Value.ToString("yyyy-MM-dd");
            string itemPrice = itemPriceTxt.Text.Trim();
            decimal itemTotal = itemTotalTxt.Tag is decimal value ? value : 0;
            System.Drawing.Image itemImage = itemImagePic.Image;

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(stockIn) || string.IsNullOrEmpty(unitType) || string.IsNullOrEmpty(itemPrice))
            {
                new Messages_Boxes.Field_Required().Show();
                return;
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE stocks SET Item_Name = @Item_Name, Stock_In = @Stock_In, Unit_Type = @Unit_Type, Date_Added = @Date_Added, " +
                                  "Item_Price = @Item_Price, Item_Total = @Item_Total, Item_Image = @Item_Image WHERE Item_ID = @Item_ID";

                cmd.Parameters.AddWithValue("@Item_ID", itemID);
                cmd.Parameters.AddWithValue("@Item_Name", itemName);
                cmd.Parameters.AddWithValue("@Stock_In", int.TryParse(stockIn, out var stock) ? stock : 0); // Convert to integer
                cmd.Parameters.AddWithValue("@Unit_Type", unitType);
                cmd.Parameters.AddWithValue("@Date_Added", dateAdded);
                cmd.Parameters.AddWithValue("@Item_Price", decimal.TryParse(itemPrice, out var price) ? price : 0); // Convert to decimal
                cmd.Parameters.AddWithValue("@Item_Total", itemTotal);

                byte[] imageBytes = itemImage != null ? ImageToByteArray(ResizeImage(itemImage, 300, 300)) : null;
                cmd.Parameters.AddWithValue("@Item_Image", imageBytes ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    selectItemNameCmb.SelectedIndex = -1;
                    itemQuantityTxt.Clear();
                    unitTypeCmb.SelectedIndex = -1;
                    dateAddedDtp.Value = DateTime.Now;
                    itemPriceTxt.Clear();
                    itemTotalTxt.Clear();
                    itemImagePic.Image = null;
                    this.Close();
                    Populate();
                    this.Alert("Stock Updated Successfully");
                    previewStock();
                }
                else
                {
                    MessageBox.Show("Failed to update item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
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

        private void backNewStockBtn_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void totalInfoBtn_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Item Total is calculated by multiplying Item Quantity and Item Price", "Item Total of Item Quantity and Item Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void itemQuantityTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxForNumbersOnly(itemQuantityTxt);

            if (int.TryParse(itemQuantityTxt.Text, out int quantity))
            {
                if (quantity > 20)
                {
                    MessageBox.Show("The maximum stock quantity is 20.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    itemQuantityTxt.Clear();
                }
            }
        }
    }
}
