﻿using System;
using System.Net;
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
        [Obsolete]
        public frmChat()
        {
            InitializeComponent();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContacts f2 = new AddContacts();
            f2.Show();
        }

        [Obsolete]
        private void FrmChat_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Globals.hostName;//setting username to hostname
            Console.WriteLine(Globals.IP);

        }


        private void txtMessageToSend_Click(object sender, EventArgs e)
        {
            txtMessageToSend.Text = String.Empty;//empties text box on click
        }

        private void txtMessageToSend_Leave(object sender, EventArgs e)
        {
            txtMessageToSend.Text = "Type your message here...";//setting texbox back to original state
        }
    }
    public static class Globals//creating global var class
    {
        public static string hostName = Dns.GetHostName(); //accessing hostname
        [Obsolete]
        public static string IP = Dns.GetHostByName(hostName).AddressList[0].ToString(); //accessing IP-address of hostname

    }
}