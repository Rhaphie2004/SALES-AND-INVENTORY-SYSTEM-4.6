using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace sims.Forgot_Password
{
    public partial class Forgot_Password : Form
    {
        private string generatedOTP;
        public Forgot_Password()
        {
            InitializeComponent();
        }
        private void Forgot_Password_Load(object sender, EventArgs e)
        {
            // Initially hide the email-related controls until username is validated
            emailTxt.Visible = false;
            lblMessage.Visible = false;
        }

        public BunifuTextBox UsernameTxt
        {
            get { return usernameTxt; }
        }

        private string GenerateOTP()
        {
            Random rand = new Random();
            return rand.Next(100000, 1000000).ToString();
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            string Username = usernameTxt.Text.Trim();

            // Step 1: Validate Username
            if (!emailTxt.Visible)
            {
                if (string.IsNullOrEmpty(Username))
                {
                    new Messages_Boxes.Forgot_Password_msgbox.UsernameRequired().Show();
                    return;
                }

                if (CheckUsername(Username))
                {
                    MessageBox.Show("Username exists. Please enter your email to continue.", "Username Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show email input fields and prepare for next step
                    emailTxt.Visible = true;
                    ContinueBtn.Text = "Send OTP"; // Optional: change button text
                }
                else
                {
                    usernameTxt.Focus();
                    new Messages_Boxes.Forgot_Password_msgbox.UsernameNotFound().Show();
                    usernameTxt.Clear();
                }

                return; // End here if we were still on username step
            }

            // Step 2: Validate Email (emailTxt is now visible)
            string email = emailTxt.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblMessage.Text = "Please enter your email.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblMessage.Text = "Please enter a valid email address.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            // Generate OTP
            generatedOTP = GenerateOTP();

            // Send email
            if (SendOTPEmail(email, generatedOTP))
            {
                // Email sent successfully, proceed to OTP form
                Enter_OTP otpForm = new Enter_OTP();
                otpForm.SetOTP(generatedOTP);
                otpForm.SetForgotPasswordForm(this);
                this.Hide();
                otpForm.Show();
            }
            else
            {
                lblMessage.Text = "Failed to send OTP. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private bool CheckUsername(string username)
        {
            dbModule db = new dbModule();
            string query = @"
            SELECT COUNT(*) 
            FROM (
                SELECT username FROM users 
                UNION 
                SELECT username FROM staff
            ) AS combined 
            WHERE BINARY username = @Username";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private bool SendOTPEmail(string toEmail, string otpCode)
        {
            MailAddress fromAddress = new MailAddress("pedroannamarierhaphie@gmail.com", "Sales and Inventory System - Soothing Cafe");
            MailAddress toAddress = new MailAddress(toEmail);

            const string fromPassword = "ipoecapypglrfmxh"; // Your Gmail App Password
            const string subject = "Your OTP Code";
            string body = $"<p>Hello,</p><p>Your OTP code is: <strong>{otpCode}</strong></p><p>This code will expire in 5 minutes.</p>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                EnableSsl = true
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("SMTP Error: " + ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("General Error: " + ex.Message);
                    return false;
                }
            }
        }

        private void BackToSigninLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Login_Form().Show();
        }

    }
}
