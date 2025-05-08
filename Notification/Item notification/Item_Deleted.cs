using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Notification
{
    public partial class Item_Deleted : Form
    {
        public Item_Deleted()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        private Item_Deleted.enmAction action;
        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;

                    if (this.Opacity >= 1.0)
                    {
                        action = enmAction.wait; // Transition to "wait" after fully opaque
                    }
                    break;

                case enmAction.wait:
                    timer1.Interval = 2000; // Wait for 1 second
                    action = enmAction.close; // Transition to "close" after waiting
                    break;

                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    if (this.Opacity <= 0.0)
                    {
                        timer1.Stop(); // Stop the timer after fully transparent
                        this.Close();  // Close the form
                    }
                    break;
            }
        }
        public void showalert(string msg)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Item_Deleted frm = (Item_Deleted)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = screenWidth - this.Width - 5; // Align to the right of the working area
                    this.y = screenHeight - this.Height * (i + 1) - 5; // Position above the taskbar, offset for each alert
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            // Ensure the alert doesn't overlap the taskbar
            this.x = screenWidth - this.Width - 5;
            this.label1.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
