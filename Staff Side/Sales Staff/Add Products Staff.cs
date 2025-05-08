using MySql.Data.MySqlClient;
using sims.Messages_Boxes;
using sims.Staff_Side.Stocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace sims.Staff_Side.Sales_Staff
{
    public partial class Add_Products_Staff : Form
    {
        private Product_Sales_Staff _product_Saless;
        private Manage_Stocks_Staff _stock;
        private Inventory_Dashboard_Staff _inventoryDashboard;

        public Add_Products_Staff(Product_Sales_Staff product_Saless, Manage_Stocks_Staff stock, Inventory_Dashboard_Staff inventoryDashboard)
        {
            InitializeComponent();
            _product_Saless = product_Saless;
            _stock = stock;
            _inventoryDashboard = inventoryDashboard;
        }

        public class ProductDetails
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public string ProductPrice { get; set; }
            public string category { get; set; }
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image cannot be null.");

            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void Add_Products_Staff_Load(object sender, EventArgs e)
        {
            stocks();
            GenerateRandomItemID();
            LoadCategoriesProducts();
            LoadProductButtons();
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

        private void LoadCategoriesProducts()
        {
            string query = "SELECT Category_Name FROM categoriesproducts";
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
                                categoryCmb.Items.Add(reader["Category_Name"].ToString());
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

        private List<string> allStockItems = new List<string>();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stocks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateRandomItemID()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000000, 99999999);
            productIDTxt.Text = randomNumber.ToString();
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
            productButton.Click += ProductButton_Click;

            // Add the button to the appropriate FlowLayoutPanel based on the category
            switch (category.Trim().ToLower())
            {
                case "coffee":
                    _product_Saless.CoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "non-coffee":
                    _product_Saless.NonCoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "hot coffee":
                    _product_Saless.HotCoffeeLayoutPanel.Controls.Add(productButton);
                    break;
                case "pastries":
                    _product_Saless.PastriesLayoutPanel.Controls.Add(productButton);
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

                //Pass both productID and category to the Sales_Form
                Sales_Form_Staff detailsForm = new Sales_Form_Staff(productID, _stock, _inventoryDashboard, category);
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

                // Clear all layout panels before loading products
                _product_Saless.CoffeeLayoutPanel.Controls.Clear();
                _product_Saless.NonCoffeeLayoutPanel.Controls.Clear();
                _product_Saless.HotCoffeeLayoutPanel.Controls.Clear();
                _product_Saless.PastriesLayoutPanel.Controls.Clear();

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

        private void browseImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        // Load the image using a MemoryStream to avoid file lock issues
                        using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var ms = new MemoryStream())
                            {
                                fs.CopyTo(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                                Image originalImage = Image.FromStream(ms);

                                // Resize the image to prevent issues with larger dimensions
                                Image resizedImage = ResizeImage(originalImage, 300, 300);

                                // Assign resized image to the PictureBox
                                productImagePic.Image = resizedImage;
                                productImagePic.SizeMode = PictureBoxSizeMode.Zoom;
                                itemImageLabel.Visible = false; // Hide label after selecting an image
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            string category = categoryCmb.SelectedItem?.ToString() ?? string.Empty;
            Image productImage = productImagePic.Image;

            if (string.IsNullOrEmpty(productID) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(category))
            {
                new Field_Required().Show();
                return;
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;

                // Insert the product
                cmd.CommandText = "INSERT INTO products(Product_ID, Product_Name, Category, Product_Image)" +
                                  "VALUES (@Product_ID, @Product_Name, @Category, @Product_Image)";
                cmd.Parameters.AddWithValue("@Product_ID", productID);
                cmd.Parameters.AddWithValue("@Product_Name", productName);
                cmd.Parameters.AddWithValue("@Category", category);

                byte[] imageBytes = productImage != null ? ImageToByteArray(ResizeImage(productImage, 300, 300)) : null;
                cmd.Parameters.AddWithValue("@Product_Image", imageBytes ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset the form
                    productNameTxt.Clear();
                    categoryCmb.SelectedIndex = -1;
                    this.Hide();
                    GenerateRandomItemID();
                    AddProductButton(productID, productName, category);
                    LoadProductButtons();
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
        private Image ResizeImage(Image image, int width, int height)
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}