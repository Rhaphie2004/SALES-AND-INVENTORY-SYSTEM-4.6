using MySql.Data.MySqlClient;
using sims.Messages_Boxes;
using System;
using System.IO;
using System.Windows.Forms;

namespace sims
{
    public partial class Login_Form : Form
    {
        private int failedAttempts = 0;
        private const int maxAttempts = 3;
        private DateTime lockoutEndTime;
        private System.Windows.Forms.Timer lockoutTimer;
        private const string lockoutFilePath = "lockout_data.txt";
        public Login_Form()
        {
            InitializeComponent();
            ConfirmPasswordTextBox();
            showPasswordChk.OnChange += new EventHandler(showPasswordChk_OnChange);

            usernameTxt.KeyDown += new KeyEventHandler(OnEnterKeyPress);
            passwordTxt.KeyDown += new KeyEventHandler(OnEnterKeyPress);

            // Check for existing lockout when the form loads
            CheckExistingLockout();
        }

        private void CheckExistingLockout()
        {
            try
            {
                if (File.Exists(lockoutFilePath))
                {
                    string[] lockoutData = File.ReadAllLines(lockoutFilePath);
                    if (lockoutData.Length >= 2)
                    {
                        // Parse lockout end time from file
                        if (DateTime.TryParse(lockoutData[0], out DateTime savedLockoutTime))
                        {
                            lockoutEndTime = savedLockoutTime;

                            // Parse failed attempts from file
                            if (int.TryParse(lockoutData[1], out int savedFailedAttempts))
                            {
                                failedAttempts = savedFailedAttempts;
                            }

                            // If the lockout is still active
                            if (DateTime.Now < lockoutEndTime)
                            {
                                DisableLogin();
                            }
                            else
                            {
                                // Lockout has expired, but we still show the remaining attempts
                                failedAttempts = 0;
                                UpdateAttemptsLabel();
                                // Delete the lockout file as it's no longer needed
                                File.Delete(lockoutFilePath);
                            }
                        }
                    }
                }
                else
                {
                    // No lockout file exists, ensure the UI reflects normal state
                    failedAttempts = 0;
                    UpdateAttemptsLabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading lockout data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLockoutData()
        {
            try
            {
                // Save lockout end time and failed attempts to file
                string[] lockoutData = new string[]
                {
                    lockoutEndTime.ToString("o"), // ISO 8601 format for reliable parsing
                    failedAttempts.ToString()
                };

                File.WriteAllLines(lockoutFilePath, lockoutData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving lockout data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void OnEnterKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the 'ding' sound
                Login(); // Call the login method
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            // Check if there's an active lockout
            if (failedAttempts >= maxAttempts)
            {
                if (DateTime.Now < lockoutEndTime)
                {
                    int remainingTime = (int)(lockoutEndTime - DateTime.Now).TotalSeconds;
                    MessageBox.Show($"Too many failed attempts. Please wait {remainingTime} seconds before trying again.", "Login Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    failedAttempts = 0; // Reset attempts after timeout
                    AttemptsLbl.Visible = true; // Show attempts again
                    UpdateAttemptsLabel();

                    // Delete the lockout file as it's no longer needed
                    if (File.Exists(lockoutFilePath))
                    {
                        File.Delete(lockoutFilePath);
                    }
                }
            }

            dbModule db = new dbModule();
            string username = usernameTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                usernameTxt.Focus();
                new Field_Required().Show();
                usernameTxt.Clear();
                passwordTxt.Clear();
                return;
            }

            string userQuery = "SELECT Staff_Name FROM users WHERE BINARY username = @Username AND BINARY password = @Password";
            string staffQuery = "SELECT Staff_Name, Action FROM staff WHERE BINARY username = @Username AND BINARY password = @Password";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        string ownerName = cmd.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(ownerName))
                        {
                            ResetLoginState();
                            AddLoginActivity(ownerName, "Owner");
                            new ownerLogin().Show();
                            this.Hide();
                            return;
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(staffQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader staffReader = cmd.ExecuteReader())
                        {
                            if (staffReader.Read())
                            {
                                string staffName = staffReader["Staff_Name"].ToString();
                                string accountStatus = staffReader["Action"].ToString();

                                if (accountStatus == "Inactive")
                                {
                                    usernameTxt.Focus();
                                    new Inactive_Account().Show();
                                    usernameTxt.Clear();
                                    passwordTxt.Clear();
                                    return;
                                }

                                ResetLoginState();
                                AddLoginActivity(staffName, "Staff");

                                // Open the Dashboard Staff form and pass the staff name
                                var dashboard = new Staff_Login(staffName);
                                dashboard.Show();
                                this.Hide();
                                return;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If login fails
            failedAttempts++;
            if (failedAttempts >= maxAttempts)
            {
                lockoutEndTime = DateTime.Now.AddSeconds(20);
                Failed_Attempts failedForm = new Failed_Attempts();
                failedForm.Owner = this;  // Set the login form as owner
                failedForm.Show();

                DisableLogin();

                // Save the lockout data to file for persistence
                SaveLockoutData();
            }
            else
            {
                UpdateAttemptsLabel();
            }

            usernameTxt.Focus();
            new Invalid_Account().Show();
            usernameTxt.Clear();
            passwordTxt.Clear();
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lockoutEndTime)
            {
                lockoutTimer.Stop();
                lockoutTimer.Dispose();
                LoginBtn.Enabled = true;
                failedAttempts = 0; // Reset failed attempts
                lockoutLabel.Visible = false; // Hide the label after the lockout period
                AttemptsLbl.Visible = true; // Show attempts again
                UpdateAttemptsLabel();

                // Delete the lockout file as it's no longer needed
                if (File.Exists(lockoutFilePath))
                {
                    File.Delete(lockoutFilePath);
                }
            }
            else
            {
                UpdateLockoutLabel();
            }
        }

        // Update the label to show remaining time
        private void UpdateLockoutLabel()
        {
            int remainingTime = (int)(lockoutEndTime - DateTime.Now).TotalSeconds;
            lockoutLabel.Text = $"Try again in {remainingTime} seconds...";
        }

        // Update the label to show attempts left
        private void UpdateAttemptsLabel()
        {
            int remainingAttempts = maxAttempts - failedAttempts;
            AttemptsLbl.Text = $"Attempts left: {remainingAttempts}";
        }

        // Reset the login state after successful login
        private void ResetLoginState()
        {
            failedAttempts = 0; // Reset attempts on successful login
            lockoutLabel.Visible = false; // Hide countdown timer
            AttemptsLbl.Visible = true; // Show attempts label
            UpdateAttemptsLabel();
        }

        // Disable login button and start lockout timer
        private void DisableLogin()
        {
            LoginBtn.Enabled = false;
            AttemptsLbl.Visible = false; // Hide attempts counter
            lockoutLabel.Visible = true; // Show lockout countdown
            lockoutTimer = new System.Windows.Forms.Timer();
            lockoutTimer.Interval = 1000; // 1 second interval
            lockoutTimer.Tick += LockoutTimer_Tick;
            lockoutTimer.Start();
            UpdateLockoutLabel();
        }

        private void AddLoginActivity(string staffName, string role)
        {
            dbModule db = new dbModule();

            string query = "INSERT INTO activitylogs (Staff_Name, Role, Activity, Date_Logged_In) VALUES (@StaffName, @Role, @Activity, @DateLoggedIn)";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffName", staffName);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Activity", "Logged In");
                        cmd.Parameters.AddWithValue("@DateLoggedIn", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void forgotPasswordLnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Forgot_Password.Forgot_Password().Show();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}