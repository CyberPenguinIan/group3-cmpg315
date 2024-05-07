using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace group3_cmpg315
{
    public partial class frmChat : Form
    {
        

        [Obsolete]
        public frmChat()
        {
            InitializeComponent();

        }

        private bool connected = false;
        private bool gConnected = false;
        private bool ptpConnected = false;

        private TcpClient clientSocket;
        private Thread receiveThread;

        string p2pIP = string.Empty;
        string username = string.Empty;
        string userIP = string.Empty;

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
            lblUserName.Text = Globals.hostName;
            lblChatRecip.Text = string.Empty;

            txtMessageToSend.ForeColor = Color.DarkGray;
            try
            {
                // Create an instance of the Server class
                P2PServer server = new P2PServer("127.0.0.1", 11000);

                // Start the server in a new thread
                System.Threading.Thread serverThread = new System.Threading.Thread(() =>
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
            MessageBox.Show("WELCOME "+Globals.hostName);
        }


        private void txtMessageToSend_MouseEnter(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.White;
        }

        private void txtMessageToSend_MouseLeave(object sender, EventArgs e)
        {
            txtMessageToSend.ForeColor = Color.DarkGray;
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                P2PServer server = new P2PServer("127.0.0.1", 11000);
                server.Stop();
                MessageBox.Show("SERVER CONNECTION TERMINATED");
            }
            catch(Exception ex)
            {
                MessageBox.Show("SERVER TERMINATION UNSUCCESSFUL");
                Console.WriteLine(ex);
            }
           
        }
        public void P2PServer_MessageReceived(object sender, string message)
        {
            // Invoke on UI thread if needed
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

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            P2PServer server = new P2PServer("127.0.0.1", 11000);
            //dummy value 
            server.SendMessage("127.0.0.1", 11001, txtMessageToSend.Text);
        }
    }
}