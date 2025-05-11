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
    public partial class Enter_OTP : Form
    {
        private string correctOTP;
        private Forgot_Password forgotPasswordForm;
        private Timer otpTimerr;
        private int timeRemaining = 300; // 5 minutes in seconds
        
        public Enter_OTP()
        {
            InitializeComponent();
        }

        private void Enter_OTP_Load(object sender, EventArgs e)
        {
            SetupTimer();
        }

        private void SetupTimer()
        {
            otpTimerr = new Timer();
            otpTimerr.Interval = 1000; // 1 second
            otpTimerr.Tick += otpTimerr_Tick;
            otpTimerr.Start();
        }

        private void otpTimerr_Tick(object sender, EventArgs e)
        {
            timeRemaining--;

            // Update timer display
            int minutes = timeRemaining / 60;
            int seconds = timeRemaining % 60;
            timerLabel.Text = $"Time remaining: {minutes:D2}:{seconds:D2}";

            if (timeRemaining <= 0)
            {
                otpTimerr.Stop();
                MessageBox.Show("OTP has expired. Please request a new one.", "OTP Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
                new Forgot_Password().Show();
            }
        }

        public void SetOTP(string otp)
        {
            correctOTP = otp;
        }

        public void SetForgotPasswordForm(Forgot_Password form)
        {
            forgotPasswordForm = form;
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            string enteredOTP = otpTextBox.Text.Trim();

            if (string.IsNullOrEmpty(enteredOTP))
            {
                MessageBox.Show("Please enter the OTP sent to your email.", "OTP Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredOTP == correctOTP)
            {
                otpTimerr.Stop();
                MessageBox.Show("OTP verified successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Fix: Check if forgotPasswordForm is null
                if (forgotPasswordForm != null)
                {
                    New_Password newPasswordForm = new New_Password(forgotPasswordForm);
                    this.Hide();
                    newPasswordForm.Show();
                }
                else
                {
                    MessageBox.Show("An error occurred. Cannot continue to password reset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // ❌ Invalid OTP
                MessageBox.Show("Invalid OTP. Please try again.", "Invalid OTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                otpTextBox.Clear();
                otpTextBox.Focus();
            }
        }

        private void ResendOTPBtn_Click_Click(object sender, EventArgs e)
        {
            // Return to Forgot_Password form to resend OTP
            otpTimerr.Stop();
            this.Hide();
            new Forgot_Password().Show();
        }

        private void otpTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
