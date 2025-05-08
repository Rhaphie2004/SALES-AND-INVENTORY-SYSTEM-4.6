using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Admin_Side.Users
{
    public partial class New_Staff : Form
    {
        private Manage_User_Staff dashboard;

        public New_Staff(Manage_User_Staff dashboard)
        {
            InitializeComponent();
            ConfirmPasswordTextBox();
            this.dashboard = dashboard;
        }

        private void New_Staff_Load(object sender, EventArgs e)
        {
            GenerateRandomItemID();
            Populate();
        }

        private void ConfirmPasswordTextBox()
        {
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.PasswordChar = '\0';
            passwordTxt.TextChanged += (sender, e) =>
            {
                string enteredPassword = passwordTxt.Text;
                if (string.IsNullOrEmpty(enteredPassword))
                {
                    passwordTxt.PlaceholderText = "Password";
                    passwordTxt.PasswordChar = '\0';
                }
                else
                {
                    passwordTxt.PlaceholderText = "";
                    passwordTxt.PasswordChar = '●';
                }
            };
        }

        private void GenerateRandomItemID()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            staffIDTxt.Text = randomNumber.ToString();
        }

        //private string HashPassword(string password)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        StringBuilder builder = new StringBuilder();
        //        foreach (byte b in bytes)
        //        {
        //            builder.Append(b.ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

        private void addStaffBtn_Click(object sender, EventArgs e)
        {
            register();
        }

        private void register()
        {
            dbModule db = new dbModule();
            MySqlConnection conn = db.GetConnection();
            MySqlCommand cmd = db.GetCommand();

            string staffID = staffIDTxt.Text.Trim();
            string staffName = staffNameTxt.Text.Trim();
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();
            string action = actionCmb.SelectedItem?.ToString() ?? string.Empty;
            //string hashedPassword = HashPassword(password);

            if (string.IsNullOrEmpty(staffName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                new Messages_Boxes.Field_Required().Show();
                return;
            }
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO staff (Staff_ID, Staff_Name, username, password, Action) " +
                                  "VALUES (@Staff_ID, @Staff_Name, @username, @password, @Action)";

                cmd.Parameters.AddWithValue("@Staff_ID", staffID);
                cmd.Parameters.AddWithValue("@Staff_Name", staffName);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@Action", action);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GenerateRandomItemID();
                    staffNameTxt.Clear();
                    usernameTxt.Clear();
                    passwordTxt.Clear();
                    actionCmb.SelectedIndex = -1;
                    Populate();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Populate()
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
                    dashboard.StaffsDgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backStaffBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showPasswordChk_OnChange(object sender, EventArgs e)
        {
            if (showPasswordChk.Checked)
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '●';
            }
        }

        private void staffNameTxt_TextChanged(object sender, EventArgs e)
        {
            string newText = staffNameTxt.Text;

            if (System.Text.RegularExpressions.Regex.IsMatch(newText, @"\d"))
            {
                MessageBox.Show("Numbers are not allowed!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                staffNameTxt.Text = System.Text.RegularExpressions.Regex.Replace(newText, @"\d", "");
                staffNameTxt.SelectionStart = staffNameTxt.Text.Length;
            }
        }
    }
}
