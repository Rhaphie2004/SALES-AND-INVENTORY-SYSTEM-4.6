using MySql.Data.MySqlClient;
using sims.Notification;
using System;
using System.Data;
using System.Windows.Forms;

namespace sims.Admin_Side.Category
{
    public partial class Manage_Categoryy : Form
    {
        private Old_Inventory_Dashboard _inventoryDashboard;
        private New_Category _newCategory;
        private DashboardOwner _dashboardOwner;

        public Manage_Categoryy(Old_Inventory_Dashboard inventoryDashboard, DashboardOwner dashboardOwner)
        {
            InitializeComponent();
            _inventoryDashboard = inventoryDashboard;
            _dashboardOwner = dashboardOwner;
            recentlyAddedDgv.DataBindingComplete += recentlyAddedDgv_DataBindingComplete;
        }

        public DataGridView RecentlyAddedDgv
        {
            get { return recentlyAddedDgv; }
        }

        public void Alert(string msg)
        {
            Category_Deleted frm = new Category_Deleted();
            frm.showalert(msg);
        }

        private void Manage_Categoryy_Load(object sender, EventArgs e)
        {
            DataTable dataTable = GetCategoriesData();
            recentlyAddedDgv.DataSource = dataTable;
        }

        // 1. REUSABLE FUNCTION: Get Categories DataTable
        public static DataTable GetCategoriesData()
        {
            dbModule db = new dbModule();
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM categories";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dataTable;
        }

        private void CategoryCount()
        {
            if (_inventoryDashboard != null)
            {
                _inventoryDashboard.CategoriesCount();
            }
            else
            {
                MessageBox.Show("Inventory Dashboard is not available.");
            }
        }

        private DataTable SearchInDatabase(string searchTerm)
        {
            DataTable dataTable = new DataTable();
            dbModule db = new dbModule();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT Category_ID, Category_Name, Category_Description " +
                               "FROM categories WHERE Category_Name LIKE @SearchTerm";

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

        private void searchCategoryTxt_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchCategoryTxt.Text.Trim();

            // Search for results in the database
            DataTable searchResultDataTable = SearchInDatabase(searchTerm);

            // Bind the search results to the DataGridView
            recentlyAddedDgv.DataSource = searchResultDataTable;

            // Clear selection in the DataGridView
            recentlyAddedDgv.ClearSelection();
        }

        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            //Check if the form is already open
            if (_newCategory == null || _newCategory.IsDisposed)
            {
                _newCategory = new New_Category(this, _inventoryDashboard, _dashboardOwner);
                _newCategory.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                _newCategory.BringToFront();
            }
        }

        private void editCategoryBtn_Click(object sender, EventArgs e)
        {
            if (recentlyAddedDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to update.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Update Category?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = recentlyAddedDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = recentlyAddedDgv.Rows[selectedRowIndex];
                    string itemID = selectedRow.Cells["Category_ID"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(itemID))
                    {
                        Edit_Category updateCategoryForm = new Edit_Category(itemID, this, this);
                        updateCategoryForm.Show();
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

        private void DeleteCategoryBtn_Click(object sender, EventArgs e)
        {
            if (recentlyAddedDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = recentlyAddedDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = recentlyAddedDgv.Rows[selectedRowIndex];
                    string selectedItemID = selectedRow.Cells["Category_ID"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(selectedItemID))
                    {
                        DeleteRecord(selectedItemID);
                        recentlyAddedDgv.Rows.RemoveAt(selectedRowIndex);
                        //MessageBox.Show("Item successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Category successfully deleted.");
                        CategoryCount();
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

        private void DeleteRecord(string categoryID)
        {
            dbModule db = new dbModule();
            string query = "DELETE FROM categories WHERE Category_ID = @Category_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Category_ID", categoryID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void recentlyAddedDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            recentlyAddedDgv.ClearSelection();
        }
    }
}