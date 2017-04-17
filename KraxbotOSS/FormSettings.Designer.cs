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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnMoreInfo = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbApiSteam = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbApiCleverbot = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbApiGoogle = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbApiWeather = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 320);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(272, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chatrooms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnMoreInfo);
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(272, 294);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "API Keys";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 370);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnMoreInfo;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox tbApiSteam;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbApiCleverbot;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbApiGoogle;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tbApiWeather;
    }
}