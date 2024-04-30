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
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblChatRecip = new System.Windows.Forms.Label();
            this.pnlChatRecipient = new System.Windows.Forms.Panel();
            this.lbxMsgLog = new System.Windows.Forms.ListBox();
            this.txtMessageToSend = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlChatRecipient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnAddContact);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 692);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(291, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 78);
            this.panel2.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUserName.Location = new System.Drawing.Point(22, 637);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 26);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "lblUserName";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(14, 75);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(262, 541);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.Color.Transparent;
            this.btnAddContact.BackgroundImage = global::group3_cmpg315.Properties.Resources.rounded_add_button_icon_icons_com_72592;
            this.btnAddContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddContact.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAddContact.FlatAppearance.BorderSize = 0;
            this.btnAddContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddContact.Location = new System.Drawing.Point(211, 24);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(43, 41);
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
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contacts";
            // 
            // lblChatRecip
            // 
            this.lblChatRecip.AutoSize = true;
            this.lblChatRecip.BackColor = System.Drawing.Color.Transparent;
            this.lblChatRecip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatRecip.ForeColor = System.Drawing.SystemColors.Control;
            this.lblChatRecip.Location = new System.Drawing.Point(32, 24);
            this.lblChatRecip.Name = "lblChatRecip";
            this.lblChatRecip.Size = new System.Drawing.Size(244, 26);
            this.lblChatRecip.TabIndex = 1;
            this.lblChatRecip.Text = "@RecipientUsername";
            // 
            // pnlChatRecipient
            // 
            this.pnlChatRecipient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlChatRecipient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChatRecipient.Controls.Add(this.lblChatRecip);
            this.pnlChatRecipient.Location = new System.Drawing.Point(290, 0);
            this.pnlChatRecipient.Name = "pnlChatRecipient";
            this.pnlChatRecipient.Size = new System.Drawing.Size(908, 77);
            this.pnlChatRecipient.TabIndex = 2;
            // 
            // lbxMsgLog
            // 
            this.lbxMsgLog.BackColor = System.Drawing.Color.DimGray;
            this.lbxMsgLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxMsgLog.ForeColor = System.Drawing.SystemColors.Control;
            this.lbxMsgLog.FormattingEnabled = true;
            this.lbxMsgLog.ItemHeight = 20;
            this.lbxMsgLog.Location = new System.Drawing.Point(313, 92);
            this.lbxMsgLog.Name = "lbxMsgLog";
            this.lbxMsgLog.Size = new System.Drawing.Size(860, 522);
            this.lbxMsgLog.TabIndex = 3;
            // 
            // txtMessageToSend
            // 
            this.txtMessageToSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessageToSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageToSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageToSend.ForeColor = System.Drawing.SystemColors.Control;
            this.txtMessageToSend.Location = new System.Drawing.Point(313, 635);
            this.txtMessageToSend.Name = "txtMessageToSend";
            this.txtMessageToSend.Size = new System.Drawing.Size(811, 35);
            this.txtMessageToSend.TabIndex = 4;
            this.txtMessageToSend.Text = "Type your message here...";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.DimGray;
            this.btnSendMessage.BackgroundImage = global::group3_cmpg315.Properties.Resources.pngwing_com;
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Location = new System.Drawing.Point(1130, 636);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(43, 32);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.UseVisualStyleBackColor = false;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessageToSend);
            this.Controls.Add(this.lbxMsgLog);
            this.Controls.Add(this.pnlChatRecipient);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChat";
            this.Text = "Chat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlChatRecipient.ResumeLayout(false);
            this.pnlChatRecipient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblChatRecip;
        private System.Windows.Forms.Panel pnlChatRecipient;
        private System.Windows.Forms.ListBox lbxMsgLog;
        private System.Windows.Forms.TextBox txtMessageToSend;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

