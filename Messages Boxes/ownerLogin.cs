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
    public partial class ownerLogin : Form
    {
        public ownerLogin()
        {
            InitializeComponent();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Loading_Screen().Show();
        }
    }
}
