using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace group3_cmpg315
{
    public partial class AddContacts : Form
    {
        private SqlConnection connection;

        public AddContacts()
        {
            InitializeComponent();

            // Set up the database connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\xande\\source\\repos\\CyberPenguinIan\\group3-cmpg315\\group3-cmpg315\\Database1.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void txtNewName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateContact_Click(object sender, EventArgs e)
        {
            // Insert the new contact into the database
            string query = "INSERT INTO tblMessage (User_name, IP, Port) VALUES (@Username, @IP, @Port)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", txtNewName.Text);
            command.Parameters.AddWithValue("@IP", txtNewIP.Text);
            command.Parameters.AddWithValue("@Port", txtNewPort.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Contact Added");
            
        }

        private void btnCancelNew_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}