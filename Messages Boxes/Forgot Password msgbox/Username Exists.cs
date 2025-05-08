using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace sims.Messages_Boxes.Forgot_Password_msgbox
{
    public partial class Username_Exists : Form
    {
        private Forgot_Password.Forgot_Password username;

        public Username_Exists(Forgot_Password.Forgot_Password username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            new Forgot_Password.New_Password(username).Show();
            this.Hide();
        }
    }
}
