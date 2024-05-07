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

        //connection methon
        public bool Connect(string serverIP, int serverPort)
        {
            try
            {
                if (!connected)
                {
                    // Connecting to server
                    clientSocket = new TcpClient();
                    clientSocket.Connect(serverIP, serverPort);
                    connected = true;

                    Console.WriteLine("Connected to server {0}:{1}", serverIP, serverPort);

                    return true; // Connection successful
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return false;
        }

        //disconnection method
        public void Disconnect()
        {
            if (connected)
            {
                try
                {
                    // disconnecting from sockets.
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    clientSocket = null;
                    receiveThread.Join();
                    connected = false;
                    ptpConnected = false;
                    gConnected = false;

                    Console.WriteLine("Disconnected from the server");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
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
            //connecting to p2p server
            if (Connect("35.194.95.129", 31331))
            {
                ptpConnected = true;
                MessageBox.Show("Successfully Connected to Peer to Peer server");
            }
            else MessageBox.Show("The Peer to peer server is offline");
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
            // disconnecting from p2p server
            if (Connect("35.194.95.129", 31331))
            {
                try
                {
                    Disconnect();
                    MessageBox.Show("Disconnected from peer to peer server successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error detected: " + ex);
                }
            }  

        }
    }
}