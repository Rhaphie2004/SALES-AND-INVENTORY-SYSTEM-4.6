using sims.Splash_page_and_Loading_Screen;
using sims.Staff_Side;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sims.Messages_Boxes
{
    public partial class Staff_Login : Form
    {
        private string loggedInStaffName;

        public Staff_Login(string staffName)
        {
            InitializeComponent();
            this.loggedInStaffName = staffName;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            new Loading_Screen_Staff(loggedInStaffName).Show();
            this.Hide();
        }
    }
}
