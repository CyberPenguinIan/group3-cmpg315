namespace group3_cmpg315
{
    partial class frmChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblChatRecip = new System.Windows.Forms.Label();
            this.pnlChatRecipient = new System.Windows.Forms.Panel();
            this.lbxMsgLog = new System.Windows.Forms.ListBox();
            this.txtMessageToSend = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.pnlChatRecipient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.dgvContacts);
            this.panel1.Controls.Add(this.btnAddContact);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 554);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(259, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 63);
            this.panel2.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUserName.Location = new System.Drawing.Point(20, 510);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 24);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "lblUserName";
            // 
            // dgvContacts
            // 
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvContacts.Location = new System.Drawing.Point(12, 60);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersWidth = 62;
            this.dgvContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvContacts.Size = new System.Drawing.Size(233, 433);
            this.dgvContacts.TabIndex = 0;
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.Color.Transparent;
            this.btnAddContact.BackgroundImage = global::group3_cmpg315.Properties.Resources.rounded_add_button_icon_icons_com_72592;
            this.btnAddContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddContact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddContact.FlatAppearance.BorderSize = 0;
            this.btnAddContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAddContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddContact.Location = new System.Drawing.Point(176, 16);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(44, 36);
            this.btnAddContact.TabIndex = 2;
            this.btnAddContact.UseVisualStyleBackColor = false;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contacts";
            // 
            // lblChatRecip
            // 
            this.lblChatRecip.AutoSize = true;
            this.lblChatRecip.BackColor = System.Drawing.Color.Transparent;
            this.lblChatRecip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatRecip.ForeColor = System.Drawing.SystemColors.Control;
            this.lblChatRecip.Location = new System.Drawing.Point(28, 20);
            this.lblChatRecip.Name = "lblChatRecip";
            this.lblChatRecip.Size = new System.Drawing.Size(213, 24);
            this.lblChatRecip.TabIndex = 1;
            this.lblChatRecip.Text = "@RecipientUsername";
            // 
            // pnlChatRecipient
            // 
            this.pnlChatRecipient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlChatRecipient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChatRecipient.Controls.Add(this.lblChatRecip);
            this.pnlChatRecipient.Location = new System.Drawing.Point(257, 0);
            this.pnlChatRecipient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlChatRecipient.Name = "pnlChatRecipient";
            this.pnlChatRecipient.Size = new System.Drawing.Size(807, 62);
            this.pnlChatRecipient.TabIndex = 2;
            // 
            // lbxMsgLog
            // 
            this.lbxMsgLog.BackColor = System.Drawing.Color.DimGray;
            this.lbxMsgLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxMsgLog.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMsgLog.ForeColor = System.Drawing.SystemColors.Control;
            this.lbxMsgLog.FormattingEnabled = true;
            this.lbxMsgLog.ItemHeight = 21;
            this.lbxMsgLog.Location = new System.Drawing.Point(279, 74);
            this.lbxMsgLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxMsgLog.Name = "lbxMsgLog";
            this.lbxMsgLog.Size = new System.Drawing.Size(765, 401);
            this.lbxMsgLog.TabIndex = 0;
            // 
            // txtMessageToSend
            // 
            this.txtMessageToSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessageToSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageToSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageToSend.ForeColor = System.Drawing.SystemColors.Control;
            this.txtMessageToSend.Location = new System.Drawing.Point(279, 508);
            this.txtMessageToSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessageToSend.Name = "txtMessageToSend";
            this.txtMessageToSend.Size = new System.Drawing.Size(721, 30);
            this.txtMessageToSend.TabIndex = 4;
            this.txtMessageToSend.Text = "Type your message here...";
            this.txtMessageToSend.Click += new System.EventHandler(this.txtMessageToSend_Click);
            this.txtMessageToSend.Leave += new System.EventHandler(this.txtMessageToSend_Leave);
            this.txtMessageToSend.MouseEnter += new System.EventHandler(this.txtMessageToSend_MouseEnter);
            this.txtMessageToSend.MouseLeave += new System.EventHandler(this.txtMessageToSend_MouseLeave);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.DimGray;
            this.btnSendMessage.BackgroundImage = global::group3_cmpg315.Properties.Resources.pngwing_com;
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Location = new System.Drawing.Point(1004, 508);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(39, 26);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessageToSend);
            this.Controls.Add(this.lbxMsgLog);
            this.Controls.Add(this.pnlChatRecipient);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChat";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.Shown += new System.EventHandler(this.frmChat_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.pnlChatRecipient.ResumeLayout(false);
            this.pnlChatRecipient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblChatRecip;
        private System.Windows.Forms.Panel pnlChatRecipient;
        private System.Windows.Forms.TextBox txtMessageToSend;
        private System.Windows.Forms.Button btnSendMessage;
        public System.Windows.Forms.ListBox lbxMsgLog;
    }
}

