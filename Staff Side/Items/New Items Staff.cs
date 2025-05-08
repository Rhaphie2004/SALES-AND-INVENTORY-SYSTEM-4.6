using sims.Admin_Side.Items;
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
using sims.Notification;
using System.IO;
using MySql.Data.MySqlClient;

namespace sims.Staff_Side.Items
{
    public partial class New_Items_Staff : Form
    {
        private Manage_Items_Staff count;
        private Manage_Items_Staff dashboard;
        private Inventory_Dashboard_Staff _inventoryDashboard;

        public New_Items_Staff(Manage_Items_Staff dashboard, Manage_Items_Staff count, Inventory_Dashboard_Staff inventoryDashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.count = count;
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

        private void New_Items_Staff_Load(object sender, EventArgs e)
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

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        private void AddItem()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string itemID = itemIDTxt.Text.Trim();
            string itemName = itemNameTxt.Text.Trim();
            string category = categoryCmb.SelectedItem?.ToString() ?? string.Empty;
            string itemDescription = itemDescTxt.Text.Trim();
            Image itemImage = itemImagePic.Image;

            if (string.IsNullOrEmpty(itemID) || string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(itemDescription))
            {
                new Messages_Boxes.Field_Required().Show();
                return;
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO items (Item_ID, Item_Name, Category, Item_Description, Item_Image) " +
                                  "VALUES (@Item_ID, @Item_Name, @Category, @Item_Description, @Item_Image)";
                cmd.Parameters.AddWithValue("@Item_ID", itemID);
                cmd.Parameters.AddWithValue("@Item_Name", itemName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Item_Description", itemDescription);

                // Resize and convert the image
                byte[] imageBytes = itemImage != null ? ImageToByteArray(ResizeImage(itemImage, 300, 300)) : null;
                cmd.Parameters.AddWithValue("@Item_Image", imageBytes ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    GenerateRandomItemID();
                    ItemsCount();
                    itemNameTxt.Clear();
                    categoryCmb.SelectedIndex = -1;
                    itemDescTxt.Clear();
                    itemImagePic.Image = null;
                    this.Alert("Item Added Successfully");
                    this.Close();
                    Populate();
                    previewItems();
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

        private void backNewItemsBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
