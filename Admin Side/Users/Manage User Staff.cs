using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace sims.Admin_Side.Users
{
    public partial class Manage_User_Staff : UserControl
    {
        public Manage_User_Staff()
        {
            InitializeComponent();
            staffsDgv.DataBindingComplete += staffsDgv_DataBindingComplete;
        }

        public DataGridView StaffsDgv
        {
            get { return staffsDgv; }
        }

        private void Manage_User_Staff_Load(object sender, EventArgs e)
        {
            LoadStaff();
        }

        private void LoadStaff()
        {
            dbModule db = new dbModule();
            MySqlDataAdapter adapter = db.GetAdapter();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM staff";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    staffsDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewStaffBtn_Click(object sender, EventArgs e)
        {
            New_Staff newStaff = new New_Staff(this);
            newStaff.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (staffsDgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this Item?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int selectedRowIndex = staffsDgv.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = staffsDgv.Rows[selectedRowIndex];
                    string selectedItemID = selectedRow.Cells["Staff_ID"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(selectedItemID))
                    {
                        DeleteRecord(selectedItemID);
                        staffsDgv.Rows.RemoveAt(selectedRowIndex);
                        LoadStaff();
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

        private void DeleteRecord(string staffID)
        {
            dbModule db = new dbModule();
            string query = "DELETE FROM staff WHERE Staff_ID = @Staff_ID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Staff_ID", staffID);
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

        private void staffsDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            staffsDgv.ClearSelection();
        }
    }
}
