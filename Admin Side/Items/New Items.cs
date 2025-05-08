using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using sims.Notification;
using sims.Admin_Side.Category;

namespace sims.Admin_Side.Items
{
    public partial class New_Items : Form
    {
        private Manage_Items count;
        private Manage_Items dashboard;
        private Old_Inventory_Dashboard _inventoryDashboard;
        private New_Category _newCategory;

        private Manage_Categoryy dashboardForm;
        private DashboardOwner _dashboardOwner;

        public New_Items(Manage_Items dashboard, Manage_Items count, Manage_Categoryy dashboardForm, Old_Inventory_Dashboard inventoryDashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.count = count;
            this.dashboardForm = dashboardForm;
            _inventoryDashboard = inventoryDashboard;
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

        public void Alert(string msg)
        {
            Item_Added frm = new Item_Added();
            frm.showalert(msg);
        }

        private void New_Items_Load(object sender, EventArgs e)
        {
            ItemsCount();
            GenerateRandomItemID();
            LoadComboBoxData();
            Populate();
            previewItems();
        }

        private void ItemsCount()
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
                        count.CountItem.Text = itemCount.ToString();
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

        private void GenerateRandomItemID()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000000, 99999999);
            itemIDTxt.Text = randomNumber.ToString();
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
                    string query = "SELECT * FROM items";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dashboard.ItemsDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void previewItems()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.ItemsCount();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private Dictionary<string, (int CategoryID, string Description)> categoryData = new Dictionary<string, (int, string)>();
        private void LoadComboBoxData()
        {
            string query = "SELECT Category_ID, Category_Name, Category_Description FROM categories ORDER BY Category_Name";
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
                                string categoryName = reader["Category_Name"].ToString();
                                int categoryID = Convert.ToInt32(reader["Category_ID"]);
                                string categoryDescription = reader["Category_Description"].ToString();
                                categoryCmb.Items.Add(categoryName);
                                categoryData[categoryName] = (categoryID, categoryDescription);
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

        private void backNewItemsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for the "Add Item" button click event
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            AddItem(); // Call the method to add an item to the database
        }

        // Method to add an item to the database
        private void AddItem()
        {
            // Initialize database module and retrieve database connection and command
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            // Retrieve values from input fields
            string itemID = itemIDTxt.Text.Trim();
            string itemName = itemNameTxt.Text.Trim();
            string category = categoryCmb.SelectedItem?.ToString() ?? string.Empty; // Handle null selection
            string itemDescription = itemDescTxt.Text.Trim();
            Image itemImage = itemImagePic.Image;

            // Check if any required field is empty
            if (string.IsNullOrEmpty(itemID) || string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(itemDescription))
            {
                new Messages_Boxes.Field_Required().Show(); // Show a message box indicating required fields
                return;
            }

            try
            {
                conn.Open(); // Open database connection
                cmd.Connection = conn;

                // Prepare SQL command for inserting a new item into the database
                cmd.CommandText = "INSERT INTO items (Item_ID, Item_Name, Category, Item_Description, Item_Image) " +
                                  "VALUES (@Item_ID, @Item_Name, @Category, @Item_Description, @Item_Image)";

                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@Item_ID", itemID);
                cmd.Parameters.AddWithValue("@Item_Name", itemName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Item_Description", itemDescription);

                // Convert the image to a byte array if an image is selected
                byte[] imageBytes = itemImage != null ? ImageToByteArray(ResizeImage(itemImage, 300, 300)) : null;
                cmd.Parameters.AddWithValue("@Item_Image", imageBytes ?? (object)DBNull.Value); // Store null if no image

                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query

                if (rowsAffected > 0)
                {
                    // Perform necessary UI and database updates after successful insertion
                    GenerateRandomItemID(); // Generate a new random item ID
                    ItemsCount(); // Update item count
                    itemNameTxt.Clear(); // Clear item name input
                    categoryCmb.SelectedIndex = -1; // Reset category selection
                    itemDescTxt.Clear(); // Clear description input
                    itemImagePic.Image = null; // Clear image selection

                    this.Alert("Item Added Successfully"); // Show success alert
                    this.Close(); // Close the form

                    Populate(); // Refresh item list
                    previewItems(); // Refresh item preview
                }
                else
                {
                    // Show an error message if the item could not be added
                    MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and display an error message
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed and resources are released
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
                                itemImagePic.Image = resizedImage;
                                itemImagePic.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void categoryCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryCmb.SelectedItem != null)
            {
                string selectedCategory = categoryCmb.SelectedItem.ToString();

                if (categoryData.TryGetValue(selectedCategory, out var categoryDetails))
                {
                    int categoryID = categoryDetails.CategoryID;
                    string categoryDescription = categoryDetails.Description;

                    // Display the category description in the TextBox
                    itemDescTxt.Text = categoryDescription;
                }
                else
                {
                    itemDescTxt.Text = string.Empty;
                }
            }
        }

        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (_newCategory == null || _newCategory.IsDisposed)
            {
                _newCategory = new New_Category(dashboardForm, _inventoryDashboard, _dashboardOwner);
                _newCategory.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                _newCategory.BringToFront();
            }
        }
    }
}