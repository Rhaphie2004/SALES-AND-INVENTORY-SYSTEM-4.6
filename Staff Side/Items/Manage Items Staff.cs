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
using MySql.Data.MySqlClient;

namespace sims.Staff_Side.Items
{
    public partial class Manage_Items_Staff : Form
    {
        private Inventory_Dashboard_Staff _inventoryDashboard;
        private New_Items_Staff _newItems;

        public Manage_Items_Staff(Inventory_Dashboard_Staff inventoryDashboard)
        {
            InitializeComponent();
            _inventoryDashboard = inventoryDashboard;
            itemsDgv.DataBindingComplete += itemsDgv_DataBindingComplete;
        }

        public DataGridView ItemsDgv
        {
            get { return itemsDgv; }
        }

        public Label CountItem
        {
            get { return itemCountTxt; }
        }
        public void Alert(string msg)
        {
            Item_Deleted frm = new Item_Deleted();
            frm.showalert(msg);
        }

        private void Manage_Items_Staff_Load(object sender, EventArgs e)
        {
            Populate();
            ItemsCount();
            searchComboBox();
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
                    itemsDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void previewStock()
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

        private void searchComboBox()
        {
            searchCategoryCmb.Items.Clear();

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
                                searchCategoryCmb.Items.Add(reader["Category_Name"].ToString());
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
                        itemCountTxt.Text = itemCount.ToString();
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
        private DataTable SearchInDatabase(string searchTerm)
        {
            DataTable dataTable = new DataTable();
            dbModule db = new dbModule();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT Item_ID, Item_Name, Category, Item_Description, Item_Image " +
                               "FROM items WHERE Item_Name LIKE @SearchTerm";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        private void ApplyFilters()
        {
            string searchText = searchItemTxt.Text.Trim();
            string selectedCategory = searchCategoryCmb.SelectedItem?.ToString();

            // If no filters are applied, show all data
            if (string.IsNullOrEmpty(searchText) && string.IsNullOrEmpty(selectedCategory))
            {
                itemsDgv.DataSource = SearchInDatabase(""); // Pass an empty string to retrieve all records
                return;
            }

            // Build the search term for database filtering
            List<string> filters = new List<string>();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                filters.Add($"Category = '{selectedCategory.Replace("'", "''")}'"); // Escape single quotes
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                filters.Add($"Item_Name LIKE '%{searchText.Replace("'", "''")}%'"); // Escape single quotes
            }

            string searchTerm = string.Join(" AND ", filters);

            // Retrieve filtered data from the database
            DataTable filteredData = SearchInDatabase(searchText); // Use `searchText` to fetch from the database

            // If a category is selected, filter the returned data further
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                DataView dv = filteredData.DefaultView;
                dv.RowFilter = $"Category = '{selectedCategory.Replace("'", "''")}'";
                filteredData = dv.ToTable();
            }

            // Bind the filtered data to the DataGridView
            itemsDgv.DataSource = filteredData;
        }

        private void searchCategoryCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void searchItemTxt_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ResetFilters()
        {
            searchCategoryCmb.SelectedIndex = -1; // Reset category filter
            searchItemTxt.Clear();               // Clear text filter
            ApplyFilters();                      // Reapply filters to reset DataView
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            if (itemsDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this Item?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = itemsDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = itemsDgv.Rows[selectedRowIndex];
                    string selectedItemID = selectedRow.Cells["Item_ID"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(selectedItemID))
                    {
                        DeleteRecord(selectedItemID);
                        itemsDgv.Rows.RemoveAt(selectedRowIndex);
                        this.Alert("Item successfully deleted.");
                        ItemsCount();
                        Populate();
                        previewStock();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Item_ID. Unable to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteRecord(string itemID)
        {
            dbModule db = new dbModule();
            string query = "DELETE FROM items WHERE Item_ID = @Item_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Item_ID", itemID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No record found to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewItemBtn_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (_newItems == null || _newItems.IsDisposed)
            {
                _newItems = new New_Items_Staff(this, this, _inventoryDashboard);
                _newItems.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                _newItems.BringToFront();
            }
        }

        private void UpdateItemBtn_Click(object sender, EventArgs e)
        {
            if (itemsDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Update Item!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = itemsDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = itemsDgv.Rows[selectedRowIndex];
                    string itemID = selectedRow.Cells["Item_ID"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(itemID))
                    {
                        Edit_Items_Staff updateProductForm = new Edit_Items_Staff(itemID, this);
                        updateProductForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Item_ID. Unable to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void itemsDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            itemsDgv.ClearSelection();
        }
    }
}
