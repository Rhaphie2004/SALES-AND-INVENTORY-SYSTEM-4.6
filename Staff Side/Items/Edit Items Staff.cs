using MySql.Data.MySqlClient;
using sims.Admin_Side.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Staff_Side.Items
{
    public partial class Edit_Items_Staff : Form
    {
        private string _itemID;
        private Manage_Items_Staff dashboard;

        public Edit_Items_Staff(string itemID, Manage_Items_Staff dashboard)
        {
            InitializeComponent();
            _itemID = itemID;
            this.dashboard = dashboard;
        }

        private void Edit_Items_Staff_Load(object sender, EventArgs e)
        {
            Populate();
            LoadProductDetails(_itemID);
            LoadComboBoxData();
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

        private void LoadComboBoxData()
        {
            string query = "SELECT Category_Name FROM categories ORDER BY Category_Name";
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

        private void LoadProductDetails(string itemID)
        {
            dbModule db = new dbModule();
            string query = "SELECT Item_ID, Item_Name, Category, Item_Description, Item_Image " +
                           "FROM items WHERE Item_ID = @Item_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Item_ID", itemID);
                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                itemIDTxt.Text = reader["Item_ID"].ToString();
                                itemNameTxt.Text = reader["Item_Name"].ToString();
                                string categoryValue = reader["Category"].ToString();
                                itemDescTxt.Text = reader["Item_Description"].ToString();

                                if (!string.IsNullOrEmpty(categoryValue))
                                {
                                    categoryCmb.SelectedItem = categoryValue;
                                    if (!categoryCmb.Items.Contains(categoryValue))
                                    {
                                        categoryCmb.Items.Add(categoryValue);
                                        categoryCmb.SelectedItem = categoryValue;
                                    }
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("Item_Image")))
                                {
                                    byte[] imageBytes = (byte[])reader["Item_Image"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        itemImagePic.Image = Image.FromStream(ms);
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

        private void EditItemBtn_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }

        private void UpdateItem()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string itemID = itemIDTxt.Text.Trim();
            string itemName = itemNameTxt.Text.Trim();
            string category = categoryCmb.SelectedItem?.ToString() ?? string.Empty;
            string itemDescription = itemDescTxt.Text.Trim();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE items SET Item_name = @Item_name, Category = @Category, " +
                                  "Item_Description = @Item_Description, Item_Image = @Item_Image " +
                                  "WHERE Item_ID = @Item_ID";

                cmd.Parameters.AddWithValue("@Item_ID", itemID);
                cmd.Parameters.AddWithValue("@Item_name", itemName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Item_Description", itemDescription);

                if (itemImagePic.Image != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (Bitmap bitmap = new Bitmap(itemImagePic.Image)) // Clone to avoid locking issues
                            {
                                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Use a specific format
                                byte[] imageBytes = ms.ToArray();
                                cmd.Parameters.AddWithValue("@Item_Image", imageBytes);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmd.Parameters.AddWithValue("@Item_Image", DBNull.Value); // Set to NULL on failure
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Item_Image", DBNull.Value); // No image to save
                }

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Item updated successfully!", "Item Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    itemNameTxt.Clear();
                    categoryCmb.SelectedIndex = -1;
                    itemDescTxt.Clear();
                    itemImagePic.Image = null;
                    Populate();
                }
                else
                {
                    MessageBox.Show("Failed to update item. Item ID might not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void backNewItemsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void browseImageBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        itemImagePic.Image = Image.FromFile(imagePath);
                        itemImagePic.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
