using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace group3_cmpg315
{
    public partial class AddContacts : Form
    {
        public AddContacts()
        {
            InitializeComponent();
        }

        private void txtNewName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact Added");
            this.Visible = false;
        }

        private void btnCancelNew_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
