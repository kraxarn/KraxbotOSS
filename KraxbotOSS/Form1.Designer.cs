namespace KraxbotOSS
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbChatrooms = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lStatus = new System.Windows.Forms.Label();
			this.lNetwork = new System.Windows.Forms.Label();
			this.btnChatroomInfo = new System.Windows.Forms.Button();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnBotSettings = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.log = new System.Windows.Forms.RichTextBox();
			this.lDiscordStatus = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbChatrooms);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(185, 295);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chatrooms";
			// 
			// lbChatrooms
			// 
			this.lbChatrooms.FormattingEnabled = true;
			this.lbChatrooms.Location = new System.Drawing.Point(7, 20);
			this.lbChatrooms.Name = "lbChatrooms";
			this.lbChatrooms.Size = new System.Drawing.Size(170, 264);
			this.lbChatrooms.TabIndex = 0;
			this.lbChatrooms.SelectedIndexChanged += new System.EventHandler(this.LbChatrooms_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lDiscordStatus);
			this.groupBox2.Controls.Add(this.lStatus);
			this.groupBox2.Controls.Add(this.lNetwork);
			this.groupBox2.Location = new System.Drawing.Point(203, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(150, 90);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Status";
			// 
			// lStatus
			// 
			this.lStatus.AutoSize = true;
			this.lStatus.Location = new System.Drawing.Point(8, 40);
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(97, 13);
			this.lStatus.TabIndex = 1;
			this.lStatus.Text = "Status: Logged out";
			// 
			// lNetwork
			// 
			this.lNetwork.AutoSize = true;
			this.lNetwork.Location = new System.Drawing.Point(8, 20);
			this.lNetwork.Name = "lNetwork";
			this.lNetwork.Size = new System.Drawing.Size(119, 13);
			this.lNetwork.TabIndex = 0;
			this.lNetwork.Text = "Network: Disconnected";
			// 
			// btnChatroomInfo
			// 
			this.btnChatroomInfo.Enabled = false;
			this.btnChatroomInfo.Location = new System.Drawing.Point(203, 108);
			this.btnChatroomInfo.Name = "btnChatroomInfo";
			this.btnChatroomInfo.Size = new System.Drawing.Size(150, 23);
			this.btnChatroomInfo.TabIndex = 2;
			this.btnChatroomInfo.Text = "Chatroom Info";
			this.btnChatroomInfo.UseVisualStyleBackColor = true;
			this.btnChatroomInfo.Click += new System.EventHandler(this.BtnChatroomInfo_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(203, 284);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(150, 23);
			this.btnSettings.TabIndex = 4;
			this.btnSettings.Text = "Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
			// 
			// btnBotSettings
			// 
			this.btnBotSettings.Enabled = false;
			this.btnBotSettings.Location = new System.Drawing.Point(203, 255);
			this.btnBotSettings.Name = "btnBotSettings";
			this.btnBotSettings.Size = new System.Drawing.Size(150, 23);
			this.btnBotSettings.TabIndex = 5;
			this.btnBotSettings.Text = "Bot Settings";
			this.btnBotSettings.UseVisualStyleBackColor = true;
			this.btnBotSettings.Click += new System.EventHandler(this.BtnBotSettings_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Enabled = false;
			this.btnLogin.Location = new System.Drawing.Point(203, 137);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(150, 23);
			this.btnLogin.TabIndex = 6;
			this.btnLogin.Text = "Log in";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.log);
			this.groupBox3.Location = new System.Drawing.Point(359, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 295);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Log";
			// 
			// log
			// 
			this.log.BackColor = System.Drawing.SystemColors.Control;
			this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.log.Location = new System.Drawing.Point(6, 19);
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.Size = new System.Drawing.Size(188, 270);
			this.log.TabIndex = 0;
			this.log.Text = "";
			// 
			// lDiscordStatus
			// 
			this.lDiscordStatus.AutoSize = true;
			this.lDiscordStatus.Location = new System.Drawing.Point(8, 62);
			this.lDiscordStatus.Name = "lDiscordStatus";
			this.lDiscordStatus.Size = new System.Drawing.Size(90, 13);
			this.lDiscordStatus.TabIndex = 2;
			this.lDiscordStatus.Text = "Discord: Disabled";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 320);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnBotSettings);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnChatroomInfo);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kraxbot: Open Source";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbChatrooms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lNetwork;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button btnChatroomInfo;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBotSettings;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox log;
		private System.Windows.Forms.Label lDiscordStatus;
		//private System.Windows.Forms.RichTextBox log;
	}
}

