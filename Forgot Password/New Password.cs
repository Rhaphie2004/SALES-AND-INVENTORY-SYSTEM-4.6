using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Forgot_Password
{
    public partial class New_Password : Form
    {
        private Forgot_Password username;
        public string Username { get; set; }

        public New_Password(Forgot_Password username)
        {
            InitializeComponent();
            this.username = username;
            InitializePasswordTextBox();
            ConfirmPasswordTextBox();
            showNewPasswordChk.OnChange += new EventHandler(showNewPasswordChk_OnChange);
            confirmPasswordChk.OnChange += new EventHandler(showNewPasswordChk_OnChange);
        }

        private void InitializePasswordTextBox()
        {
            newPasswordTxt.PlaceholderText = "Create new password";

            newPasswordTxt.PasswordChar = '\0';

            newPasswordTxt.TextChanged += (sender, e) =>
            {
                string enteredPassword = newPasswordTxt.Text;
                if (string.IsNullOrEmpty(enteredPassword))
                {
                    newPasswordTxt.PlaceholderText = "Create new password";
                    newPasswordTxt.PasswordChar = '\0';
                    newPasswordTxt.BorderColorActive = Color.Gray;
                    passwordStrengthLabel.Text = "";
                }
                else
                {
                    newPasswordTxt.PlaceholderText = "";
                    newPasswordTxt.PasswordChar = '●';
                    if (enteredPassword.Length < 8)
                    {
                        newPasswordTxt.FillColor = Color.Red;
                        passwordStrengthLabel.Text = "Password too short, must be at least 8 characters.";
                    }
                    else if (!enteredPassword.Any(char.IsDigit) || !enteredPassword.Any(char.IsLetter))
                    {
                        newPasswordTxt.FillColor = Color.Orange;
                        passwordStrengthLabel.Text = "Password must contain both letters and numbers.";
                    }
                    else if (!enteredPassword.Any(char.IsUpper))
                    {
                        newPasswordTxt.FillColor = Color.Orange;
                        passwordStrengthLabel.Text = "Password must contain at least one uppercase letter.";
                    }
                    else
                    {
                        newPasswordTxt.FillColor = Color.Green;
                        passwordStrengthLabel.Text = "Password strength is good.";
                    }
                }

            };
        }

        private void ConfirmPasswordTextBox()
        {
            confirmPasswordTxt.PlaceholderText = "Confirm your password";
            confirmPasswordTxt.PasswordChar = '\0';
            confirmPasswordTxt.TextChanged += (sender, e) =>
            {
                string enteredPassword = confirmPasswordTxt.Text;
                if (string.IsNullOrEmpty(enteredPassword))
                {
                    confirmPasswordTxt.PlaceholderText = "Confirm your password";
                    confirmPasswordTxt.PasswordChar = '\0';
                }
                else
                {
                    confirmPasswordTxt.PlaceholderText = "";
                    confirmPasswordTxt.PasswordChar = '●';
                }
            };
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            Username = username.UsernameTxt.Text;
            string newPassword = newPasswordTxt.Text;
            string confirmPassword = confirmPasswordTxt.Text;

            if (ChangePasswordInDatabase(newPassword, confirmPassword))
            {
                MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Login_Form().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("New password and confirm password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsPasswordConfirmed(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        private bool ChangePasswordInDatabase(string newPassword, string confirmPassword)
        {
            dbModule db = new dbModule();

            // Ensure password is confirmed before proceeding
            if (!IsPasswordConfirmed(newPassword, confirmPassword))
            {
                return false;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Query to update password in 'users' table
                    string userUpdateQuery = "UPDATE users SET password = @Password WHERE BINARY username = @Username";
                    // Query to update password in 'staff' table
                    string staffUpdateQuery = "UPDATE staff SET password = @Password WHERE BINARY username = @Username";

                    using (MySqlCommand cmd = new MySqlCommand(userUpdateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Username", Username); // Use the passed-in username

                        // Execute the update for the users table
                        int userRowsAffected = cmd.ExecuteNonQuery();

                        if (userRowsAffected == 0)
                        {
                            // If no rows were affected in the users table, try updating the staff table
                            using (MySqlCommand staffCmd = new MySqlCommand(staffUpdateQuery, conn))
                            {
                                staffCmd.Parameters.AddWithValue("@Password", newPassword);
                                staffCmd.Parameters.AddWithValue("@Username", Username); // Use the passed-in username

                                // Execute the update for the staff table
                                int staffRowsAffected = staffCmd.ExecuteNonQuery();

                                if (staffRowsAffected > 0)
                                {
                                    return true; // Password updated in staff table
                                }
                            }

                            return false; // Username not found in either table
                        }

                        return true; // Password updated in users table
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the update process.
                    MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void showNewPasswordChk_OnChange(object sender, EventArgs e)
        {
            if (showNewPasswordChk.Checked)
            {
                newPasswordTxt.PasswordChar = '\0';
            }
            else
            {
                newPasswordTxt.PasswordChar = '●';
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            new Forgot_Password().Show();
            this.Hide();
        }

        private void confirmPasswordChk_OnChange(object sender, EventArgs e)
        {
            if (confirmPasswordChk.Checked)
            {
                confirmPasswordTxt.PasswordChar = '\0';
            }
            else
            {
                confirmPasswordTxt.PasswordChar = '●';
            }
        }
    }
}
