using MaterialSkin.Controls;

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
			this.lDiscordStatus = new MaterialSkin.Controls.MaterialLabel();
			this.lSteamStatus = new MaterialSkin.Controls.MaterialLabel();
			this.btnChatroomInfo = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnSettings = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnBotSettings = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnLogin = new MaterialSkin.Controls.MaterialFlatButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.log = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbChatrooms);
			this.groupBox1.Location = new System.Drawing.Point(12, 70);
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
			this.groupBox2.Controls.Add(this.lSteamStatus);
			this.groupBox2.Location = new System.Drawing.Point(203, 70);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(169, 71);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Status";
			// 
			// lDiscordStatus
			// 
			this.lDiscordStatus.AutoSize = true;
			this.lDiscordStatus.Depth = 0;
			this.lDiscordStatus.Font = new System.Drawing.Font("Roboto", 11F);
			this.lDiscordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lDiscordStatus.Location = new System.Drawing.Point(8, 39);
			this.lDiscordStatus.MouseState = MaterialSkin.MouseState.HOVER;
			this.lDiscordStatus.Name = "lDiscordStatus";
			this.lDiscordStatus.Size = new System.Drawing.Size(127, 19);
			this.lDiscordStatus.TabIndex = 2;
			this.lDiscordStatus.Text = "Discord: Disabled";
			// 
			// lSteamStatus
			// 
			this.lSteamStatus.AutoSize = true;
			this.lSteamStatus.Depth = 0;
			this.lSteamStatus.Font = new System.Drawing.Font("Roboto", 11F);
			this.lSteamStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lSteamStatus.Location = new System.Drawing.Point(8, 20);
			this.lSteamStatus.MouseState = MaterialSkin.MouseState.HOVER;
			this.lSteamStatus.Name = "lSteamStatus";
			this.lSteamStatus.Size = new System.Drawing.Size(152, 19);
			this.lSteamStatus.TabIndex = 0;
			this.lSteamStatus.Text = "Steam: Disconnected";
			// 
			// btnChatroomInfo
			// 
			this.btnChatroomInfo.AutoSize = true;
			this.btnChatroomInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnChatroomInfo.Depth = 0;
			this.btnChatroomInfo.Enabled = false;
			this.btnChatroomInfo.Icon = null;
			this.btnChatroomInfo.Location = new System.Drawing.Point(203, 150);
			this.btnChatroomInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnChatroomInfo.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnChatroomInfo.Name = "btnChatroomInfo";
			this.btnChatroomInfo.Primary = false;
			this.btnChatroomInfo.Size = new System.Drawing.Size(131, 36);
			this.btnChatroomInfo.TabIndex = 2;
			this.btnChatroomInfo.Text = "Chatroom Info";
			this.btnChatroomInfo.UseVisualStyleBackColor = true;
			this.btnChatroomInfo.Click += new System.EventHandler(this.BtnChatroomInfo_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.AutoSize = true;
			this.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSettings.Depth = 0;
			this.btnSettings.Icon = null;
			this.btnSettings.Location = new System.Drawing.Point(204, 329);
			this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnSettings.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Primary = false;
			this.btnSettings.Size = new System.Drawing.Size(85, 36);
			this.btnSettings.TabIndex = 4;
			this.btnSettings.Text = "Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
			// 
			// btnBotSettings
			// 
			this.btnBotSettings.AutoSize = true;
			this.btnBotSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnBotSettings.Depth = 0;
			this.btnBotSettings.Enabled = false;
			this.btnBotSettings.Icon = null;
			this.btnBotSettings.Location = new System.Drawing.Point(204, 293);
			this.btnBotSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnBotSettings.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnBotSettings.Name = "btnBotSettings";
			this.btnBotSettings.Primary = false;
			this.btnBotSettings.Size = new System.Drawing.Size(115, 36);
			this.btnBotSettings.TabIndex = 5;
			this.btnBotSettings.Text = "Bot Settings";
			this.btnBotSettings.UseVisualStyleBackColor = true;
			this.btnBotSettings.Click += new System.EventHandler(this.BtnBotSettings_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.AutoSize = true;
			this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnLogin.Depth = 0;
			this.btnLogin.Enabled = false;
			this.btnLogin.Icon = null;
			this.btnLogin.Location = new System.Drawing.Point(203, 186);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Primary = false;
			this.btnLogin.Size = new System.Drawing.Size(64, 36);
			this.btnLogin.TabIndex = 6;
			this.btnLogin.Text = "Log in";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.log);
			this.groupBox3.Location = new System.Drawing.Point(378, 70);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 374);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnBotSettings);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnChatroomInfo);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
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
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbChatrooms;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox log;
		private MaterialFlatButton btnChatroomInfo;
		private MaterialFlatButton btnSettings;
		private MaterialFlatButton btnBotSettings;
		private MaterialFlatButton btnLogin;
		private MaterialLabel lSteamStatus;
		private MaterialLabel lDiscordStatus;
		//private System.Windows.Forms.RichTextBox log;
	}
}

