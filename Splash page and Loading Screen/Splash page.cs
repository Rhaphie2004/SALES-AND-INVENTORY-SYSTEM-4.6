using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Splash_page_and_Loading_Screen
{
    public partial class Splash_page : Form
    {
        public Splash_page()
        {
            InitializeComponent();
        }

        private void getStartedBtn_Click(object sender, EventArgs e)
        {
            getStartedBtn.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Login_Form Loading = new Login_Form();
            this.Hide();
            Loading.Show();
            getStartedBtn.Enabled = true;
        }
    }
}
