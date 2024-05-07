using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace group3_cmpg315
{
    // Class to hold global variables
    

    public partial class frmChat : Form
    {
        
        private const string connectionString = "Data Source=chat.db;Version=3;";
        
        
        private const string dbFilePath = "chat.db";

        [Obsolete]
        public frmChat()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static string hostName = Dns.GetHostName();
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Globals.hostName;
            lblChatRecip.Text = string.Empty;

            txtMessageToSend.ForeColor = Color.DarkGray;
            try
            {
                //CheckDatabaseExistence(); het maar net gecheck of die DB bestaan

                CreateDatabase();

                PopulateDataGridView();

                // Create an instance of the P2PServer class
                P2PServer server = new P2PServer("127.0.0.1", 11000);

                // Start the server in a new thread
                Thread serverThread = new Thread(() =>
                {
                    server.Start();
                });
                serverThread.Start();
                MessageBox.Show("SERVER CONNECTION SUCCESSFUL");
                server.MessageReceived += P2PServer_MessageReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SERVER CONNECTION UNSUCCESSFUL");
                Console.WriteLine(ex);
            }
        }

        private void CheckDatabaseExistence()
        {
            if (File.Exists(dbFilePath))
            {
                Console.WriteLine("SQLite database file exists.");
            }
            else
            {
                Console.WriteLine("SQLite database file does not exist.");
            }
        }

        private void PopulateDataGridView()
        {
            string query = "SELECT User_Name FROM Contacts;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvContacts.DataSource = dataTable;
                }
            }
        }


        private void CreateDatabase()
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Contacts (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    User_Name TEXT NOT NULL,
                    IP_Address TEXT NOT NULL,
                    Port TEXT NOT NULL
                );
            ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void PrintAllContacts()
        {
            string query = "SELECT * FROM Contacts;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader["User_Name"].ToString();
                            string ipAddress = reader["IP_Address"].ToString();
                            string port = reader["Port"].ToString();

                            Console.WriteLine($"Name: {userName}, IP Address: {ipAddress}, Port: {port}");
                        }
                    }
                }
            }
        }


        public void P2PServer_MessageReceived(object sender, string message)
        {
            if (lbxMsgLog.InvokeRequired)
            {
                lbxMsgLog.Invoke(new Action(() =>
                {
                    lbxMsgLog.Items.Add(message);
                }));
            }
            else
            {
                lbxMsgLog.Items.Add(message);
            }
        }

        private void txtMessageToSend_Click(object sender, EventArgs e)
        {
            txtMessageToSend.Text = String.Empty;
            txtMessageToSend.ForeColor = Color.White;
        }

        private void txtMessageToSend_Leave(object sender, EventArgs e)
        {
            txtMessageToSend.Text = "Type your message here...";
            txtMessageToSend.ForeColor = Color.DarkGray;
        }

        private void txtMessageToSend_MouseEnter(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.White;
        }

        private void txtMessageToSend_MouseLeave(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.DarkGray;
        }

        private void frmChat_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("WELCOME " + Globals.hostName);
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                P2PServer server = new P2PServer("127.0.0.1", 11000);
                server.Stop();
                MessageBox.Show("SERVER CONNECTION TERMINATED");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SERVER TERMINATION UNSUCCESSFUL");
                Console.WriteLine(ex);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessageToSend.Text;
            string recipient = lblChatRecip.Text; // Assuming you have a recipient label
            string senderName = Globals.hostName; // Renamed to senderName to avoid conflict

            InsertMessage(senderName, recipient, message);

            P2PServer server = new P2PServer("127.0.0.1", 11000);
            server.SendMessage("127.0.0.1", 11001, message);
        }

        private void InsertMessage(string sender, string recipient, string message)
        {
            string insertQuery = "INSERT INTO Messages (Sender, Recipient, Message) VALUES (@Sender, @Recipient, @Message);";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Sender", sender);
                    command.Parameters.AddWithValue("@Recipient", recipient);
                    command.Parameters.AddWithValue("@Message", message);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            
            AddContacts addContactsForm = new AddContacts();
            addContactsForm.ShowDialog();
        }
    }
}
