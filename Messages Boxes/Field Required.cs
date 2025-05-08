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
    public partial class Field_Required : Form
    {
        public Field_Required()
        {
            InitializeComponent();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
