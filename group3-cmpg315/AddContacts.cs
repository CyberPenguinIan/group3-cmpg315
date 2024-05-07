using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace group3_cmpg315
{
    public partial class AddContacts : Form
    {
        
        private const string connectionString = "Data Source=chat.db;Version=3;";

        public AddContacts()
        {
            InitializeComponent();
        }

        private void btnCreateContact_Click(object sender, EventArgs e)
        {
            string newName = txtNewName.Text;
            string newIP = txtNewIP.Text;
            string newPort = txtNewPort.Text;

            if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newIP) && !string.IsNullOrWhiteSpace(newPort))
            {
                try
                {
                    InsertContact(newName, newIP, newPort);
                    MessageBox.Show("Contact added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void btnCancelNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertContact(string name, string ip, string port)
        {
            string insertQuery = "INSERT INTO Contacts (User_Name, IP_Address, Port) VALUES (@Name, @IP, @Port);";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@IP", ip);
                    command.Parameters.AddWithValue("@Port", port);

                    command.ExecuteNonQuery();
                }
            }
        }

        
        private void AddContacts_Load(object sender, EventArgs e)
        {
            
        }

        
        private void txtNewName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
