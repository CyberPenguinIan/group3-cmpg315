using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text;

namespace group3_cmpg315
{
    public partial class frmChat : Form
    {

        private const string connectionString = "Data Source=chat.db;Version=3;";
        private const string dbFilePath = "chat.db";

        [Obsolete]
        public frmChat()
        {
            InitializeComponent();
            //dgvContacts.SelectionChanged += dgvContacts_SelectionChanged;
        }

        public static class Globals
        {
            public static string hostName = Dns.GetHostName();
            public static string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            public static string SelectedContactIP { get; set; }
            public static string SelectedContactPort { get; set; }
            public static string SelectedContactName { get; set; }
            public static string s_sender;


        }

        public void frmChat_Load(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow row in dgvContacts.Rows)
            {
                row.Selected = false;
            }*/
            Console.WriteLine("User_IP-Address: " + Globals.IP);
            lblUserName.Text = Globals.hostName;
            lblChatRecip.Text = string.Empty;
            dgvContacts.Enabled = true;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContacts.SelectionChanged += dgvContacts_SelectionChanged;
            

            txtMessageToSend.ForeColor = Color.DarkGray;

            CreateDatabase();

            PopulateDataGridView();
        }

        private void DisplaySelectedContact()
        {
            if (!string.IsNullOrEmpty(Globals.SelectedContactIP) && !string.IsNullOrEmpty(Globals.SelectedContactPort))
            {
                Console.WriteLine($"Selected Contact IP: {Globals.SelectedContactIP}, Port: {Globals.SelectedContactPort}");
            }
            else
            {
                Console.WriteLine("No contact selected.");
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

        public void PopulateDataGridView()
        {
            string query = "SELECT User_Name, IP_Address, Port FROM Contacts;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvContacts.DataSource = dataTable;

                    dgvContacts.Columns["User_Name"].HeaderText = "User Name";
                    dgvContacts.Columns["IP_Address"].HeaderText = "IP Address";
                    dgvContacts.Columns["Port"].HeaderText = "Port";
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

        public void PrintAllContacts()
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
                    lbxMsgLog.BorderStyle = BorderStyle.Fixed3D;
                    lbxMsgLog.Items.Add(Globals.SelectedContactName+": "+message);
                    
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
            MessageBox.Show("YOUR CURRENT IP ADDRESS IS: " + Globals.IP);
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                P2PServer server = new P2PServer(Globals.IP, 11000);
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
            string recipient = lblChatRecip.Text; // recipient label used for reciepient name
            string senderName = Globals.hostName; // Renamed to senderName to avoid conflict
            P2PServer server = new P2PServer(Globals.IP, 11000);
            if (dgvContacts.SelectedRows.Count > 1)
            {

                int dgvcount = dgvContacts.SelectedRows.Count;
                
                string[] ipaddresses = new string[dgvContacts.SelectedRows.Count];
                int i = 0;

                foreach(DataGridViewRow row in dgvContacts.SelectedRows)
                {
                    ipaddresses[i] = row.Cells[1].Value.ToString();
                    i++;
                }
                Console.WriteLine(ipaddresses);

                foreach(string ip in ipaddresses)
                {
                    // Start the server in a new thread
                    Thread serverThread = new Thread(() =>
                    {
                        server.Start();
                    });
                    serverThread.Start();
                    server.MessageReceived += P2PServer_MessageReceived;
                    server.SendMessage(ip, 11000, message);
                    server.Stop();
                }

            }
            
            if (message != " ")
            {
                lbxMsgLog.Items.Add(senderName + ": " + message);
                

                server.SendMessage(Globals.SelectedContactIP, 11000, message);

            }
            else
            {
                MessageBox.Show("Type a message");
            }
            //InsertMessage(senderName, recipient, message);

            

            txtMessageToSend.Text = "Type your message here...";
            txtMessageToSend.ForeColor = Color.DarkGray;
            Console.WriteLine(Globals.SelectedContactName);
        }

        /*
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
        }*/

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContacts addContactsForm = new AddContacts(this);
            addContactsForm.ShowDialog();
        }

        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            P2PServer server = new P2PServer(Globals.IP, 11000);
            server.Stop();
            //dgvContacts.SelectionChanged += dgvContacts_SelectionChanged;
            //werk in die if statement
            if (dgvContacts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvContacts.SelectedRows[0];
                Globals.SelectedContactIP = selectedRow.Cells["IP_Address"].Value.ToString();
                Globals.SelectedContactPort = selectedRow.Cells["Port"].Value.ToString();
                Globals.SelectedContactName = selectedRow.Cells["User_Name"].Value.ToString();
                Console.WriteLine($"Selected Contact IP: {Globals.SelectedContactIP}, Port: {Globals.SelectedContactPort}");
                lbxMsgLog.Items.Clear();



            }
            else
            {
                Console.WriteLine("No contact selected.");
            }
        }

        private void dgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // Create an instance of the P2PServer class
                P2PServer server = new P2PServer(Globals.IP, 11000);

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
    }
}