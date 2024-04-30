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
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContacts f2 = new AddContacts();
            f2.Show();
        }
    }
}
