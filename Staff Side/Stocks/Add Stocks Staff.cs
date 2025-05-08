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
    public partial class Add_Stocks_Staff : Form
    {
        private Manage_Stocks_Staff dashboard;
        private Inventory_Dashboard_Staff _inventoryDashboard;

        public Add_Stocks_Staff(Manage_Stocks_Staff dashboard, Inventory_Dashboard_Staff inventoryDashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;

            itemQuantityTxt.TextChanged += (s, e) => CalculateTotalValue();
            itemPriceTxt.TextChanged += (s, e) => CalculateTotalValue();
            _inventoryDashboard = inventoryDashboard;
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text; // Display ItemName in ComboBox
            }
        }

        public void Alert(string msg)
        {
            Stock_Added frm = new Stock_Added();
            frm.showalert(msg);
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

        private void Add_Stocks_Staff_Load(object sender, EventArgs e)
        {
            dateAddedDtp.Value = DateTime.Now;
            CalculateTotalValue();
            SelectItemID();
            UnitType();
            previewStock();
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

        private Dictionary<string, (int ItemID, string ItemName, string Category, byte[] ItemImage)> itemData =
    new Dictionary<string, (int, string, string, byte[])>();

        private void SelectItemID()
        {
            string query = "SELECT Item_ID, Item_Name, Category, Item_Image FROM items"; // Include the image column
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
                                int itemID = Convert.ToInt32(reader["Item_ID"]);
                                string itemName = reader["Item_Name"].ToString();
                                string category = reader["Category"].ToString();
                                byte[] itemImage = !reader.IsDBNull(reader.GetOrdinal("Item_Image"))
                                    ? (byte[])reader["Item_Image"]
                                    : null;
                                selectItemNameCmb.Items.Add(itemName);
                                itemData[itemName] = (itemID, itemName, category, itemImage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addStockBtn_Click(object sender, EventArgs e)
        {
            AddItemStock();
        }
        private void AddItemStock()
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
                cmd.CommandText = "INSERT INTO stocks (Item_ID, Item_Name, Stock_In, Unit_Type, Date_Added, Item_Price, Item_Total, Item_Image) " +
                                  "VALUES (@Item_ID, @Item_Name, @Stock_In, @Unit_Type, @Date_Added, @Item_Price, @Item_Total, @Item_Image)";

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
                    this.Alert("Stock Added Successfully");
                    Populate();
                    previewStock();
                }
                else
                {
                    MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void backNewStockBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void itemPriceTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxForNumbersOnly(itemPriceTxt);
        }

        private void selectItemNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectItemNameCmb.SelectedItem != null)
            {
                string selectedItem = selectItemNameCmb.SelectedItem.ToString();

                if (itemData.TryGetValue(selectedItem, out var itemInfo))
                {
                    itemIDTxt.Text = itemInfo.ItemID.ToString();

                    // Ensure the category exists in categoryCmb
                    categoryCmb.Items.Clear(); // Clear previous selection
                    categoryCmb.Items.Add(itemInfo.Category);
                    categoryCmb.SelectedIndex = 0; // Automatically select the category

                    // Load item image
                    byte[] imageBytes = itemInfo.ItemImage;
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
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
                    MessageBox.Show("Item not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    itemIDTxt.Clear();
                    categoryCmb.Items.Clear();
                    itemImagePic.Image = null;
                }
            }
            else
            {
                itemIDTxt.Clear();
                categoryCmb.Items.Clear();
                itemImagePic.Image = null;
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
    }
}
