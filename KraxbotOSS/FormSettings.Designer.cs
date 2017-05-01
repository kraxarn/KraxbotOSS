namespace KraxbotOSS
{
    partial class FormSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUpdates = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFriends = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbFriendRequest = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbChatRequest = new System.Windows.Forms.ComboBox();
            this.cbLoginAs = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.clChats = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tbGamePlayed = new System.Windows.Forms.TabPage();
            this.gbGame = new System.Windows.Forms.GroupBox();
            this.tbGameInfo = new System.Windows.Forms.TextBox();
            this.cbGameType = new System.Windows.Forms.CheckBox();
            this.tpChatrooms = new System.Windows.Forms.TabPage();
            this.tpAPI = new System.Windows.Forms.TabPage();
            this.btnMoreInfo = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbApiSteam = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbApiCleverbot = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbApiGoogle = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbApiWeather = new System.Windows.Forms.TextBox();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.lBuildDate = new System.Windows.Forms.Label();
            this.btnForgetLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tbGamePlayed.SuspendLayout();
            this.gbGame.SuspendLayout();
            this.tpChatrooms.SuspendLayout();
            this.tpAPI.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tpAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUpdates);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Updates to Recieve";
            // 
            // cbUpdates
            // 
            this.cbUpdates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdates.FormattingEnabled = true;
            this.cbUpdates.Items.AddRange(new object[] {
            "All",
            "Only Major",
            "None"});
            this.cbUpdates.Location = new System.Drawing.Point(6, 19);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Size = new System.Drawing.Size(169, 21);
            this.cbUpdates.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFriends);
            this.groupBox2.Location = new System.Drawing.Point(6, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Superadmin";
            // 
            // cbFriends
            // 
            this.cbFriends.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFriends.FormattingEnabled = true;
            this.cbFriends.Location = new System.Drawing.Point(7, 20);
            this.cbFriends.Name = "cbFriends";
            this.cbFriends.Size = new System.Drawing.Size(167, 21);
            this.cbFriends.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbFriendRequest);
            this.groupBox3.Location = new System.Drawing.Point(6, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Friend requests";
            // 
            // cbFriendRequest
            // 
            this.cbFriendRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFriendRequest.FormattingEnabled = true;
            this.cbFriendRequest.Items.AddRange(new object[] {
            "Accept All",
            "Ignore All"});
            this.cbFriendRequest.Location = new System.Drawing.Point(7, 20);
            this.cbFriendRequest.Name = "cbFriendRequest";
            this.cbFriendRequest.Size = new System.Drawing.Size(167, 21);
            this.cbFriendRequest.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbChatRequest);
            this.groupBox4.Location = new System.Drawing.Point(5, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chat requests";
            // 
            // cbChatRequest
            // 
            this.cbChatRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChatRequest.FormattingEnabled = true;
            this.cbChatRequest.Items.AddRange(new object[] {
            "Accept All",
            "Superadmin Only",
            "Ignore All"});
            this.cbChatRequest.Location = new System.Drawing.Point(8, 20);
            this.cbChatRequest.Name = "cbChatRequest";
            this.cbChatRequest.Size = new System.Drawing.Size(167, 21);
            this.cbChatRequest.TabIndex = 0;
            // 
            // cbLoginAs
            // 
            this.cbLoginAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoginAs.FormattingEnabled = true;
            this.cbLoginAs.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Busy",
            "Away",
            "Snooze",
            "Looking to Trade",
            "Looking to Play"});
            this.cbLoginAs.Location = new System.Drawing.Point(7, 19);
            this.cbLoginAs.Name = "cbLoginAs";
            this.cbLoginAs.Size = new System.Drawing.Size(167, 21);
            this.cbLoginAs.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbLoginAs);
            this.groupBox5.Location = new System.Drawing.Point(6, 231);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 50);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Login As";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.clChats);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 275);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Chats to Auto Join";
            // 
            // clChats
            // 
            this.clChats.FormattingEnabled = true;
            this.clChats.Location = new System.Drawing.Point(6, 19);
            this.clChats.Name = "clChats";
            this.clChats.Size = new System.Drawing.Size(188, 244);
            this.clChats.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Controls.Add(this.tbGamePlayed);
            this.tabControl1.Controls.Add(this.tpChatrooms);
            this.tabControl1.Controls.Add(this.tpAPI);
            this.tabControl1.Controls.Add(this.tpAbout);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 320);
            this.tabControl1.TabIndex = 8;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.groupBox1);
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Controls.Add(this.groupBox3);
            this.tpGeneral.Controls.Add(this.groupBox5);
            this.tpGeneral.Controls.Add(this.groupBox4);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(272, 294);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tbGamePlayed
            // 
            this.tbGamePlayed.Controls.Add(this.gbGame);
            this.tbGamePlayed.Controls.Add(this.cbGameType);
            this.tbGamePlayed.Location = new System.Drawing.Point(4, 22);
            this.tbGamePlayed.Name = "tbGamePlayed";
            this.tbGamePlayed.Padding = new System.Windows.Forms.Padding(3);
            this.tbGamePlayed.Size = new System.Drawing.Size(272, 294);
            this.tbGamePlayed.TabIndex = 3;
            this.tbGamePlayed.Text = "Game";
            this.tbGamePlayed.UseVisualStyleBackColor = true;
            // 
            // gbGame
            // 
            this.gbGame.Controls.Add(this.tbGameInfo);
            this.gbGame.Location = new System.Drawing.Point(20, 50);
            this.gbGame.Name = "gbGame";
            this.gbGame.Size = new System.Drawing.Size(181, 50);
            this.gbGame.TabIndex = 2;
            this.gbGame.TabStop = false;
            this.gbGame.Text = "App ID";
            // 
            // tbGameInfo
            // 
            this.tbGameInfo.Location = new System.Drawing.Point(6, 19);
            this.tbGameInfo.Name = "tbGameInfo";
            this.tbGameInfo.Size = new System.Drawing.Size(169, 20);
            this.tbGameInfo.TabIndex = 1;
            // 
            // cbGameType
            // 
            this.cbGameType.AutoSize = true;
            this.cbGameType.Location = new System.Drawing.Point(20, 20);
            this.cbGameType.Name = "cbGameType";
            this.cbGameType.Size = new System.Drawing.Size(110, 17);
            this.cbGameType.TabIndex = 0;
            this.cbGameType.Text = "Non-Steam Game";
            this.cbGameType.UseVisualStyleBackColor = true;
            this.cbGameType.CheckedChanged += new System.EventHandler(this.cbGameType_CheckedChanged);
            // 
            // tpChatrooms
            // 
            this.tpChatrooms.Controls.Add(this.groupBox6);
            this.tpChatrooms.Location = new System.Drawing.Point(4, 22);
            this.tpChatrooms.Name = "tpChatrooms";
            this.tpChatrooms.Padding = new System.Windows.Forms.Padding(3);
            this.tpChatrooms.Size = new System.Drawing.Size(272, 294);
            this.tpChatrooms.TabIndex = 1;
            this.tpChatrooms.Text = "Chatrooms";
            this.tpChatrooms.UseVisualStyleBackColor = true;
            // 
            // tpAPI
            // 
            this.tpAPI.Controls.Add(this.btnMoreInfo);
            this.tpAPI.Controls.Add(this.groupBox10);
            this.tpAPI.Controls.Add(this.groupBox7);
            this.tpAPI.Controls.Add(this.groupBox9);
            this.tpAPI.Controls.Add(this.groupBox8);
            this.tpAPI.Location = new System.Drawing.Point(4, 22);
            this.tpAPI.Name = "tpAPI";
            this.tpAPI.Size = new System.Drawing.Size(272, 294);
            this.tpAPI.TabIndex = 2;
            this.tpAPI.Text = "API Keys";
            this.tpAPI.UseVisualStyleBackColor = true;
            // 
            // btnMoreInfo
            // 
            this.btnMoreInfo.Location = new System.Drawing.Point(4, 257);
            this.btnMoreInfo.Name = "btnMoreInfo";
            this.btnMoreInfo.Size = new System.Drawing.Size(75, 23);
            this.btnMoreInfo.TabIndex = 4;
            this.btnMoreInfo.Text = "More Info";
            this.btnMoreInfo.UseVisualStyleBackColor = true;
            this.btnMoreInfo.Click += new System.EventHandler(this.btnMoreInfo_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbApiSteam);
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(260, 55);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Steam Web API";
            // 
            // tbApiSteam
            // 
            this.tbApiSteam.Location = new System.Drawing.Point(7, 20);
            this.tbApiSteam.Name = "tbApiSteam";
            this.tbApiSteam.Size = new System.Drawing.Size(240, 20);
            this.tbApiSteam.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbApiCleverbot);
            this.groupBox7.Location = new System.Drawing.Point(4, 195);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(259, 55);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cleverbot";
            // 
            // tbApiCleverbot
            // 
            this.tbApiCleverbot.Location = new System.Drawing.Point(7, 20);
            this.tbApiCleverbot.Name = "tbApiCleverbot";
            this.tbApiCleverbot.Size = new System.Drawing.Size(239, 20);
            this.tbApiCleverbot.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbApiGoogle);
            this.groupBox9.Location = new System.Drawing.Point(4, 66);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(259, 55);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Google API";
            // 
            // tbApiGoogle
            // 
            this.tbApiGoogle.Location = new System.Drawing.Point(6, 20);
            this.tbApiGoogle.Name = "tbApiGoogle";
            this.tbApiGoogle.Size = new System.Drawing.Size(240, 20);
            this.tbApiGoogle.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbApiWeather);
            this.groupBox8.Location = new System.Drawing.Point(4, 132);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(259, 55);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Open Weather Map";
            // 
            // tbApiWeather
            // 
            this.tbApiWeather.Location = new System.Drawing.Point(7, 20);
            this.tbApiWeather.Name = "tbApiWeather";
            this.tbApiWeather.Size = new System.Drawing.Size(239, 20);
            this.tbApiWeather.TabIndex = 0;
            // 
            // tpAbout
            // 
            this.tpAbout.Controls.Add(this.btnHomePage);
            this.tpAbout.Controls.Add(this.lBuildDate);
            this.tpAbout.Controls.Add(this.btnForgetLogin);
            this.tpAbout.Controls.Add(this.label1);
            this.tpAbout.Location = new System.Drawing.Point(4, 22);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tpAbout.Size = new System.Drawing.Size(272, 294);
            this.tpAbout.TabIndex = 4;
            this.tpAbout.Text = "About";
            this.tpAbout.UseVisualStyleBackColor = true;
            this.tpAbout.Enter += new System.EventHandler(this.tpAbout_Enter);
            // 
            // btnHomePage
            // 
            this.btnHomePage.Location = new System.Drawing.Point(140, 260);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(120, 25);
            this.btnHomePage.TabIndex = 4;
            this.btnHomePage.Text = "Project Page";
            this.btnHomePage.UseVisualStyleBackColor = true;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // lBuildDate
            // 
            this.lBuildDate.AutoSize = true;
            this.lBuildDate.Location = new System.Drawing.Point(15, 110);
            this.lBuildDate.Name = "lBuildDate";
            this.lBuildDate.Size = new System.Drawing.Size(0, 13);
            this.lBuildDate.TabIndex = 3;
            // 
            // btnForgetLogin
            // 
            this.btnForgetLogin.Location = new System.Drawing.Point(10, 260);
            this.btnForgetLogin.Name = "btnForgetLogin";
            this.btnForgetLogin.Size = new System.Drawing.Size(120, 25);
            this.btnForgetLogin.TabIndex = 2;
            this.btnForgetLogin.Text = "Forget current login";
            this.btnForgetLogin.UseVisualStyleBackColor = true;
            this.btnForgetLogin.Click += new System.EventHandler(this.btnForgetLogin_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 95);
            this.label1.TabIndex = 0;
            this.label1.Text = "KraxbotOSS by KraXarN / Kraxie\r\nCopyright © CrowGames 2017\r\n\r\nThis software is op" +
    "en source and will always be. If you decide to make your own software based off " +
    "this, please don\'t remove this notice.";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 370);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tbGamePlayed.ResumeLayout(false);
            this.tbGamePlayed.PerformLayout();
            this.gbGame.ResumeLayout(false);
            this.gbGame.PerformLayout();
            this.tpChatrooms.ResumeLayout(false);
            this.tpAPI.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tpAbout.ResumeLayout(false);
            this.tpAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbUpdates;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbFriendRequest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbChatRequest;
        private System.Windows.Forms.ComboBox cbLoginAs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox clChats;
        private System.Windows.Forms.ComboBox cbFriends;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpChatrooms;
        private System.Windows.Forms.TabPage tpAPI;
        private System.Windows.Forms.Button btnMoreInfo;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox tbApiSteam;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbApiCleverbot;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbApiGoogle;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tbApiWeather;
        private System.Windows.Forms.TabPage tbGamePlayed;
        private System.Windows.Forms.TextBox tbGameInfo;
        private System.Windows.Forms.CheckBox cbGameType;
        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lBuildDate;
        private System.Windows.Forms.Button btnForgetLogin;
        private System.Windows.Forms.Button btnHomePage;
    }
}