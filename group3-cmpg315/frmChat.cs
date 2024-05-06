using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
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
    public partial class frmChat : Form
    {
        private SqlConnection connection;

        [Obsolete]
        public frmChat()
        {
            InitializeComponent();

            // Set up the database connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbMessage.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        public static class Globals//creating global var class
        {
            public static string hostName = Dns.GetHostName(); //accessing hostname
            [Obsolete]
            public static string IP = Dns.GetHostByName(hostName).AddressList[0].ToString(); //accessing IP-address of hostname

        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContacts f2 = new AddContacts();
            f2.Show();
        }

        [Obsolete]
        private void frmChat_Load(object sender, EventArgs e)
        {
            // Add columns to dgvContacts
            dgvContacts.Columns.Add("UserName", "User Name");

            // Populate dgvContacts with the names from the table
            string query = "SELECT User_name FROM tblMessage";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dgvContacts.Rows.Add(reader["User_name"].ToString());
            }
            reader.Close();
            connection.Close();
        }


        private void txtMessageToSend_Click(object sender, EventArgs e)
        {
            txtMessageToSend.Text = String.Empty;//empties text box on click
            txtMessageToSend.ForeColor = Color.White;
        }

        private void txtMessageToSend_Leave(object sender, EventArgs e)
        {
            txtMessageToSend.Text = "Type your message here...";//setting texbox back to original state
            txtMessageToSend.ForeColor = Color.DarkGray;
        }

        private void frmChat_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("WELCOME " + Globals.hostName);
        }

        private void txtMessageToSend_MouseEnter(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.White;
        }

        private void txtMessageToSend_MouseLeave(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.DarkGray;
        }

    }
}