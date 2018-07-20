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
			this.listChatrooms = new MaterialSkin.Controls.MaterialListView();
			this.lDiscordStatus = new MaterialSkin.Controls.MaterialLabel();
			this.lSteamStatus = new MaterialSkin.Controls.MaterialLabel();
			this.btnChatroomInfo = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnSettings = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnBotSettings = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnLogin = new MaterialSkin.Controls.MaterialFlatButton();
			this.log = new System.Windows.Forms.RichTextBox();
			this.dividerLeft = new MaterialSkin.Controls.MaterialDivider();
			this.labelChatrooms = new MaterialSkin.Controls.MaterialLabel();
			this.labelStatus = new MaterialSkin.Controls.MaterialLabel();
			this.labelLog = new MaterialSkin.Controls.MaterialLabel();
			this.SuspendLayout();
			// 
			// listChatrooms
			// 
			this.listChatrooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listChatrooms.Depth = 0;
			this.listChatrooms.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.listChatrooms.FullRowSelect = true;
			this.listChatrooms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listChatrooms.Location = new System.Drawing.Point(12, 97);
			this.listChatrooms.MouseLocation = new System.Drawing.Point(-1, -1);
			this.listChatrooms.MouseState = MaterialSkin.MouseState.OUT;
			this.listChatrooms.Name = "listChatrooms";
			this.listChatrooms.OwnerDraw = true;
			this.listChatrooms.Size = new System.Drawing.Size(170, 264);
			this.listChatrooms.TabIndex = 0;
			this.listChatrooms.UseCompatibleStateImageBehavior = false;
			this.listChatrooms.View = System.Windows.Forms.View.Details;
			this.listChatrooms.SelectedIndexChanged += new System.EventHandler(this.LbChatrooms_SelectedIndexChanged);
			// 
			// lDiscordStatus
			// 
			this.lDiscordStatus.AutoSize = true;
			this.lDiscordStatus.Depth = 0;
			this.lDiscordStatus.Font = new System.Drawing.Font("Roboto", 11F);
			this.lDiscordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lDiscordStatus.Location = new System.Drawing.Point(188, 114);
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
			this.lSteamStatus.Location = new System.Drawing.Point(188, 95);
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
			this.btnChatroomInfo.Location = new System.Drawing.Point(189, 142);
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
			this.btnSettings.Location = new System.Drawing.Point(189, 325);
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
			this.btnBotSettings.Location = new System.Drawing.Point(189, 289);
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
			this.btnLogin.Location = new System.Drawing.Point(189, 178);
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
			// log
			// 
			this.log.BackColor = System.Drawing.SystemColors.Control;
			this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.log.Location = new System.Drawing.Point(361, 95);
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.Size = new System.Drawing.Size(188, 270);
			this.log.TabIndex = 0;
			this.log.Text = "";
			// 
			// dividerLeft
			// 
			this.dividerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.dividerLeft.Depth = 0;
			this.dividerLeft.Location = new System.Drawing.Point(0, 0);
			this.dividerLeft.MouseState = MaterialSkin.MouseState.HOVER;
			this.dividerLeft.Name = "dividerLeft";
			this.dividerLeft.Size = new System.Drawing.Size(0, 1);
			this.dividerLeft.TabIndex = 0;
			// 
			// labelChatrooms
			// 
			this.labelChatrooms.AutoSize = true;
			this.labelChatrooms.Depth = 0;
			this.labelChatrooms.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
			this.labelChatrooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelChatrooms.Location = new System.Drawing.Point(12, 70);
			this.labelChatrooms.MouseState = MaterialSkin.MouseState.HOVER;
			this.labelChatrooms.Name = "labelChatrooms";
			this.labelChatrooms.Size = new System.Drawing.Size(102, 25);
			this.labelChatrooms.TabIndex = 8;
			this.labelChatrooms.Text = "Chatrooms";
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Depth = 0;
			this.labelStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
			this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelStatus.Location = new System.Drawing.Point(188, 70);
			this.labelStatus.MouseState = MaterialSkin.MouseState.HOVER;
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(64, 25);
			this.labelStatus.TabIndex = 9;
			this.labelStatus.Text = "Status";
			// 
			// labelLog
			// 
			this.labelLog.AutoSize = true;
			this.labelLog.Depth = 0;
			this.labelLog.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
			this.labelLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.labelLog.Location = new System.Drawing.Point(361, 70);
			this.labelLog.MouseState = MaterialSkin.MouseState.HOVER;
			this.labelLog.Name = "labelLog";
			this.labelLog.Size = new System.Drawing.Size(43, 25);
			this.labelLog.TabIndex = 10;
			this.labelLog.Text = "Log";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 374);
			this.Controls.Add(this.log);
			this.Controls.Add(this.labelLog);
			this.Controls.Add(this.lDiscordStatus);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.lSteamStatus);
			this.Controls.Add(this.listChatrooms);
			this.Controls.Add(this.labelChatrooms);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnBotSettings);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnChatroomInfo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kraxbot: Open Source";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MaterialListView listChatrooms;
        private System.Windows.Forms.RichTextBox log;
		private MaterialFlatButton btnChatroomInfo;
		private MaterialFlatButton btnSettings;
		private MaterialFlatButton btnBotSettings;
		private MaterialFlatButton btnLogin;
		private MaterialLabel lSteamStatus;
		private MaterialLabel lDiscordStatus;
	    private MaterialDivider dividerLeft;
		private MaterialLabel labelChatrooms;
		private MaterialLabel labelStatus;
		private MaterialLabel labelLog;
		//private System.Windows.Forms.RichTextBox log;
	}
}

