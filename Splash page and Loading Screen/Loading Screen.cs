using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Splash_page_and_Loading_Screen
{
    public partial class Loading_Screen : Form
    {
        private int counter;

        public Loading_Screen()
        {
            InitializeComponent();
        }

        private void Loading_Screen_Load(object sender, EventArgs e)
        {
            counter = 0;
            GunaProgressBar1.Value = 0;

            Thread workerThread = new Thread(new ThreadStart(PerformTask));
            workerThread.Start();
        }
        private void PerformTask()
        {
            while (counter < 105)
            {
                Thread.Sleep(105);

                this.Invoke((Action)(() =>
                {
                    counter += 3;
                    if (counter > 100) counter = 105;

                    GunaLabel2.Text = $"{counter}%";
                    GunaProgressBar1.Value = counter;

                    if (counter == 105)
                    {
                        this.Hide();
                        DashboardOwner dashboard = new DashboardOwner();
                        dashboard.StartPosition = FormStartPosition.CenterScreen;
                        dashboard.WindowState = FormWindowState.Normal; // Make sure not minimized
                        dashboard.Show();
                        dashboard.BringToFront();
                        dashboard.Activate();
                    }
                }));
            }
        }

    }
}
