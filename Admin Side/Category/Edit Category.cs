using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
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
using static sims.Admin_Side.Category.New_Category;

namespace sims.Admin_Side.Category
{
    public partial class Edit_Category : Form
    {
        private string _categoryID;
        private Manage_Categoryy dashboardForm;
        private Manage_Categoryy flow;

        public Edit_Category(string categoryID, Manage_Categoryy dashboardForm, Manage_Categoryy flow)
        {
            InitializeComponent();
            _categoryID = categoryID;
            this.dashboardForm = dashboardForm;
            this.flow = flow;
        }

        private void Edit_Category_Load(object sender, EventArgs e)
        {
            Populate();
            LoadCategoryDetails(_categoryID);
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
                    string query = "SELECT * FROM categories";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dashboardForm.RecentlyAddedDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadCategoryDetails(string itemID)
        {
            dbModule db = new dbModule();
            string query = "SELECT Category_ID, Category_Name, Category_Description " +
                           "FROM categories WHERE Category_ID = @Category_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category_ID", _categoryID);
                    try
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                categoryIDTxt.Text = reader["Category_ID"].ToString();
                                categoryNameTxt.Text = reader["Category_Name"].ToString();
                                categoryDescriptionTxt.Text = reader["Category_Description"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while fetching categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editCategoryBtn_Click(object sender, EventArgs e)
        {
            editCategory();
        }

        private void editCategory()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string categoryID = categoryIDTxt.Text.Trim();
            string categoryName = categoryNameTxt.Text.Trim();
            string categoryDescription = categoryDescriptionTxt.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryDescription))
            {
                new Messages_Boxes.Field_Required().Show();
                return;
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE categories SET Category_Name = @Category_Name, Category_Description = @Category_Description WHERE Category_ID = @Category_ID";
                cmd.Parameters.AddWithValue("@Category_ID", categoryID);
                cmd.Parameters.AddWithValue("@Category_Name", categoryName);
                cmd.Parameters.AddWithValue("@Category_Description", categoryDescription);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Category updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    categoryNameTxt.Clear();
                    categoryDescriptionTxt.Clear();
                    Populate();
                }
                else
                {
                    MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void backNewCatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
