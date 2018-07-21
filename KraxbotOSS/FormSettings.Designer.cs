using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
			this.cbUpdates = new MaterialSkin.Controls.MaterialCheckBox();
			this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
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
			this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.tbGamePlayed = new System.Windows.Forms.TabPage();
			this.gbGame = new System.Windows.Forms.GroupBox();
			this.tbGameInfo = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.cbGameType = new MaterialSkin.Controls.MaterialCheckBox();
			this.tpChatrooms = new System.Windows.Forms.TabPage();
			this.tpAPI = new System.Windows.Forms.TabPage();
			this.btnMoreInfo = new MaterialSkin.Controls.MaterialFlatButton();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.tbApiSteam = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.tbApiCleverbot = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.tbApiGoogle = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.tbApiWeather = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.tpDiscord = new System.Windows.Forms.TabPage();
			this.gbDiscordSteam = new System.Windows.Forms.GroupBox();
			this.cbDiscordSteam = new System.Windows.Forms.ComboBox();
			this.gbDiscordMessages = new System.Windows.Forms.GroupBox();
			this.cbDiscordMessages = new System.Windows.Forms.ComboBox();
			this.gbDiscordSettings = new System.Windows.Forms.GroupBox();
			this.cbDiscordStateChanges = new MaterialSkin.Controls.MaterialCheckBox();
			this.gbDiscordChannel = new System.Windows.Forms.GroupBox();
			this.tbDiscordChannel = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.gbDiscordAdmin = new System.Windows.Forms.GroupBox();
			this.tbDiscordAdmin = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.btnDiscordHelp = new MaterialSkin.Controls.MaterialFlatButton();
			this.cbEnableDiscord = new MaterialSkin.Controls.MaterialCheckBox();
			this.gbDiscordToken = new System.Windows.Forms.GroupBox();
			this.tbDiscordToken = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.tpAbout = new System.Windows.Forms.TabPage();
			this.btnCheckUpdate = new MaterialSkin.Controls.MaterialFlatButton();
			this.btnHomePage = new MaterialSkin.Controls.MaterialFlatButton();
			this.lBuildDate = new MaterialSkin.Controls.MaterialLabel();
			this.btnForgetLogin = new MaterialSkin.Controls.MaterialFlatButton();
			this.label1 = new MaterialSkin.Controls.MaterialLabel();
			this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
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
			this.tpDiscord.SuspendLayout();
			this.gbDiscordSteam.SuspendLayout();
			this.gbDiscordMessages.SuspendLayout();
			this.gbDiscordSettings.SuspendLayout();
			this.gbDiscordChannel.SuspendLayout();
			this.gbDiscordAdmin.SuspendLayout();
			this.gbDiscordToken.SuspendLayout();
			this.tpAbout.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.materialCheckBox1);
			this.groupBox1.Controls.Add(this.cbUpdates);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(366, 57);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Updates";
			// 
			// materialCheckBox1
			// 
			this.materialCheckBox1.AutoSize = true;
			this.materialCheckBox1.Depth = 0;
			this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
			this.materialCheckBox1.Location = new System.Drawing.Point(150, 16);
			this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
			this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
			this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialCheckBox1.Name = "materialCheckBox1";
			this.materialCheckBox1.Ripple = true;
			this.materialCheckBox1.Size = new System.Drawing.Size(175, 30);
			this.materialCheckBox1.TabIndex = 1;
			this.materialCheckBox1.Text = "Check for beta releases";
			this.materialCheckBox1.UseVisualStyleBackColor = true;
			// 
			// cbUpdates
			// 
			this.cbUpdates.AutoSize = true;
			this.cbUpdates.Depth = 0;
			this.cbUpdates.Font = new System.Drawing.Font("Roboto", 10F);
			this.cbUpdates.Location = new System.Drawing.Point(8, 16);
			this.cbUpdates.Margin = new System.Windows.Forms.Padding(0);
			this.cbUpdates.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbUpdates.MouseState = MaterialSkin.MouseState.HOVER;
			this.cbUpdates.Name = "cbUpdates";
			this.cbUpdates.Ripple = true;
			this.cbUpdates.Size = new System.Drawing.Size(134, 30);
			this.cbUpdates.TabIndex = 0;
			this.cbUpdates.Text = "Check on startup";
			this.cbUpdates.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.AutoSize = true;
			this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSave.Depth = 0;
			this.btnSave.Icon = null;
			this.btnSave.Location = new System.Drawing.Point(547, 453);
			this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnSave.Name = "btnSave";
			this.btnSave.Primary = true;
			this.btnSave.Size = new System.Drawing.Size(55, 36);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbFriends);
			this.groupBox2.Location = new System.Drawing.Point(6, 69);
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
			this.cbFriends.Location = new System.Drawing.Point(8, 20);
			this.cbFriends.Name = "cbFriends";
			this.cbFriends.Size = new System.Drawing.Size(167, 21);
			this.cbFriends.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbFriendRequest);
			this.groupBox3.Location = new System.Drawing.Point(6, 125);
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
			this.cbFriendRequest.Location = new System.Drawing.Point(8, 20);
			this.cbFriendRequest.Name = "cbFriendRequest";
			this.cbFriendRequest.Size = new System.Drawing.Size(167, 21);
			this.cbFriendRequest.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbChatRequest);
			this.groupBox4.Location = new System.Drawing.Point(192, 69);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(180, 50);
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
			this.cbLoginAs.Location = new System.Drawing.Point(8, 20);
			this.cbLoginAs.Name = "cbLoginAs";
			this.cbLoginAs.Size = new System.Drawing.Size(167, 21);
			this.cbLoginAs.TabIndex = 5;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cbLoginAs);
			this.groupBox5.Location = new System.Drawing.Point(192, 125);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(180, 50);
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
			this.clChats.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.clChats.FormattingEnabled = true;
			this.clChats.Location = new System.Drawing.Point(6, 19);
			this.clChats.Name = "clChats";
			this.clChats.Size = new System.Drawing.Size(188, 240);
			this.clChats.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpGeneral);
			this.tabControl1.Controls.Add(this.tbGamePlayed);
			this.tabControl1.Controls.Add(this.tpChatrooms);
			this.tabControl1.Controls.Add(this.tpAPI);
			this.tabControl1.Controls.Add(this.tpDiscord);
			this.tabControl1.Controls.Add(this.tpAbout);
			this.tabControl1.Depth = 0;
			this.tabControl1.Location = new System.Drawing.Point(12, 127);
			this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(594, 320);
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
			this.tpGeneral.Size = new System.Drawing.Size(586, 294);
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
			this.tbGamePlayed.Size = new System.Drawing.Size(586, 294);
			this.tbGamePlayed.TabIndex = 3;
			this.tbGamePlayed.Text = "Game";
			// 
			// gbGame
			// 
			this.gbGame.Controls.Add(this.tbGameInfo);
			this.gbGame.Location = new System.Drawing.Point(20, 53);
			this.gbGame.Name = "gbGame";
			this.gbGame.Size = new System.Drawing.Size(181, 50);
			this.gbGame.TabIndex = 2;
			this.gbGame.TabStop = false;
			this.gbGame.Text = "App ID";
			// 
			// tbGameInfo
			// 
			this.tbGameInfo.Depth = 0;
			this.tbGameInfo.Hint = "";
			this.tbGameInfo.Location = new System.Drawing.Point(6, 19);
			this.tbGameInfo.MaxLength = 32767;
			this.tbGameInfo.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbGameInfo.Name = "tbGameInfo";
			this.tbGameInfo.PasswordChar = '\0';
			this.tbGameInfo.SelectedText = "";
			this.tbGameInfo.SelectionLength = 0;
			this.tbGameInfo.SelectionStart = 0;
			this.tbGameInfo.Size = new System.Drawing.Size(169, 23);
			this.tbGameInfo.TabIndex = 1;
			this.tbGameInfo.TabStop = false;
			this.tbGameInfo.UseSystemPasswordChar = false;
			// 
			// cbGameType
			// 
			this.cbGameType.AutoSize = true;
			this.cbGameType.Depth = 0;
			this.cbGameType.Font = new System.Drawing.Font("Roboto", 10F);
			this.cbGameType.Location = new System.Drawing.Point(20, 20);
			this.cbGameType.Margin = new System.Windows.Forms.Padding(0);
			this.cbGameType.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbGameType.MouseState = MaterialSkin.MouseState.HOVER;
			this.cbGameType.Name = "cbGameType";
			this.cbGameType.Ripple = true;
			this.cbGameType.Size = new System.Drawing.Size(139, 30);
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
			this.tpChatrooms.Size = new System.Drawing.Size(586, 294);
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
			this.tpAPI.Size = new System.Drawing.Size(586, 294);
			this.tpAPI.TabIndex = 2;
			this.tpAPI.Text = "API Keys";
			// 
			// btnMoreInfo
			// 
			this.btnMoreInfo.AutoSize = true;
			this.btnMoreInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnMoreInfo.Depth = 0;
			this.btnMoreInfo.Icon = null;
			this.btnMoreInfo.Location = new System.Drawing.Point(489, 252);
			this.btnMoreInfo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnMoreInfo.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnMoreInfo.Name = "btnMoreInfo";
			this.btnMoreInfo.Primary = false;
			this.btnMoreInfo.Size = new System.Drawing.Size(93, 36);
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
			this.groupBox10.Size = new System.Drawing.Size(400, 55);
			this.groupBox10.TabIndex = 0;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Steam Web API";
			// 
			// tbApiSteam
			// 
			this.tbApiSteam.Depth = 0;
			this.tbApiSteam.Hint = "";
			this.tbApiSteam.Location = new System.Drawing.Point(7, 20);
			this.tbApiSteam.MaxLength = 32767;
			this.tbApiSteam.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbApiSteam.Name = "tbApiSteam";
			this.tbApiSteam.PasswordChar = '\0';
			this.tbApiSteam.SelectedText = "";
			this.tbApiSteam.SelectionLength = 0;
			this.tbApiSteam.SelectionStart = 0;
			this.tbApiSteam.Size = new System.Drawing.Size(387, 23);
			this.tbApiSteam.TabIndex = 0;
			this.tbApiSteam.TabStop = false;
			this.tbApiSteam.UseSystemPasswordChar = false;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.tbApiCleverbot);
			this.groupBox7.Location = new System.Drawing.Point(4, 195);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(399, 55);
			this.groupBox7.TabIndex = 3;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Cleverbot";
			// 
			// tbApiCleverbot
			// 
			this.tbApiCleverbot.Depth = 0;
			this.tbApiCleverbot.Hint = "";
			this.tbApiCleverbot.Location = new System.Drawing.Point(7, 20);
			this.tbApiCleverbot.MaxLength = 32767;
			this.tbApiCleverbot.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbApiCleverbot.Name = "tbApiCleverbot";
			this.tbApiCleverbot.PasswordChar = '\0';
			this.tbApiCleverbot.SelectedText = "";
			this.tbApiCleverbot.SelectionLength = 0;
			this.tbApiCleverbot.SelectionStart = 0;
			this.tbApiCleverbot.Size = new System.Drawing.Size(386, 23);
			this.tbApiCleverbot.TabIndex = 0;
			this.tbApiCleverbot.TabStop = false;
			this.tbApiCleverbot.UseSystemPasswordChar = false;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.tbApiGoogle);
			this.groupBox9.Location = new System.Drawing.Point(4, 66);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(399, 55);
			this.groupBox9.TabIndex = 1;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Google API";
			// 
			// tbApiGoogle
			// 
			this.tbApiGoogle.Depth = 0;
			this.tbApiGoogle.Hint = "";
			this.tbApiGoogle.Location = new System.Drawing.Point(6, 20);
			this.tbApiGoogle.MaxLength = 32767;
			this.tbApiGoogle.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbApiGoogle.Name = "tbApiGoogle";
			this.tbApiGoogle.PasswordChar = '\0';
			this.tbApiGoogle.SelectedText = "";
			this.tbApiGoogle.SelectionLength = 0;
			this.tbApiGoogle.SelectionStart = 0;
			this.tbApiGoogle.Size = new System.Drawing.Size(387, 23);
			this.tbApiGoogle.TabIndex = 0;
			this.tbApiGoogle.TabStop = false;
			this.tbApiGoogle.UseSystemPasswordChar = false;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.tbApiWeather);
			this.groupBox8.Location = new System.Drawing.Point(4, 132);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(399, 55);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Open Weather Map";
			// 
			// tbApiWeather
			// 
			this.tbApiWeather.Depth = 0;
			this.tbApiWeather.Hint = "";
			this.tbApiWeather.Location = new System.Drawing.Point(7, 20);
			this.tbApiWeather.MaxLength = 32767;
			this.tbApiWeather.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbApiWeather.Name = "tbApiWeather";
			this.tbApiWeather.PasswordChar = '\0';
			this.tbApiWeather.SelectedText = "";
			this.tbApiWeather.SelectionLength = 0;
			this.tbApiWeather.SelectionStart = 0;
			this.tbApiWeather.Size = new System.Drawing.Size(386, 23);
			this.tbApiWeather.TabIndex = 0;
			this.tbApiWeather.TabStop = false;
			this.tbApiWeather.UseSystemPasswordChar = false;
			// 
			// tpDiscord
			// 
			this.tpDiscord.Controls.Add(this.gbDiscordSteam);
			this.tpDiscord.Controls.Add(this.gbDiscordMessages);
			this.tpDiscord.Controls.Add(this.gbDiscordSettings);
			this.tpDiscord.Controls.Add(this.gbDiscordChannel);
			this.tpDiscord.Controls.Add(this.gbDiscordAdmin);
			this.tpDiscord.Controls.Add(this.btnDiscordHelp);
			this.tpDiscord.Controls.Add(this.cbEnableDiscord);
			this.tpDiscord.Controls.Add(this.gbDiscordToken);
			this.tpDiscord.Location = new System.Drawing.Point(4, 22);
			this.tpDiscord.Name = "tpDiscord";
			this.tpDiscord.Size = new System.Drawing.Size(586, 294);
			this.tpDiscord.TabIndex = 5;
			this.tpDiscord.Text = "Discord";
			// 
			// gbDiscordSteam
			// 
			this.gbDiscordSteam.Controls.Add(this.cbDiscordSteam);
			this.gbDiscordSteam.Location = new System.Drawing.Point(152, 157);
			this.gbDiscordSteam.Name = "gbDiscordSteam";
			this.gbDiscordSteam.Size = new System.Drawing.Size(199, 50);
			this.gbDiscordSteam.TabIndex = 8;
			this.gbDiscordSteam.TabStop = false;
			this.gbDiscordSteam.Text = "Steam Chatroom";
			// 
			// cbDiscordSteam
			// 
			this.cbDiscordSteam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDiscordSteam.FormattingEnabled = true;
			this.cbDiscordSteam.Location = new System.Drawing.Point(7, 20);
			this.cbDiscordSteam.Name = "cbDiscordSteam";
			this.cbDiscordSteam.Size = new System.Drawing.Size(186, 21);
			this.cbDiscordSteam.TabIndex = 0;
			// 
			// gbDiscordMessages
			// 
			this.gbDiscordMessages.Controls.Add(this.cbDiscordMessages);
			this.gbDiscordMessages.Location = new System.Drawing.Point(12, 157);
			this.gbDiscordMessages.Name = "gbDiscordMessages";
			this.gbDiscordMessages.Size = new System.Drawing.Size(134, 50);
			this.gbDiscordMessages.TabIndex = 7;
			this.gbDiscordMessages.TabStop = false;
			this.gbDiscordMessages.Text = "Messages to Send";
			// 
			// cbDiscordMessages
			// 
			this.cbDiscordMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDiscordMessages.FormattingEnabled = true;
			this.cbDiscordMessages.Items.AddRange(new object[] {
            "None",
            "Discord to Steam",
            "Steam to Discord",
            "Both"});
			this.cbDiscordMessages.Location = new System.Drawing.Point(7, 20);
			this.cbDiscordMessages.Name = "cbDiscordMessages";
			this.cbDiscordMessages.Size = new System.Drawing.Size(121, 21);
			this.cbDiscordMessages.TabIndex = 3;
			// 
			// gbDiscordSettings
			// 
			this.gbDiscordSettings.Controls.Add(this.cbDiscordStateChanges);
			this.gbDiscordSettings.Enabled = false;
			this.gbDiscordSettings.Location = new System.Drawing.Point(12, 213);
			this.gbDiscordSettings.Name = "gbDiscordSettings";
			this.gbDiscordSettings.Size = new System.Drawing.Size(339, 59);
			this.gbDiscordSettings.TabIndex = 3;
			this.gbDiscordSettings.TabStop = false;
			this.gbDiscordSettings.Text = "Settings";
			// 
			// cbDiscordStateChanges
			// 
			this.cbDiscordStateChanges.AutoSize = true;
			this.cbDiscordStateChanges.Depth = 0;
			this.cbDiscordStateChanges.Font = new System.Drawing.Font("Roboto", 10F);
			this.cbDiscordStateChanges.Location = new System.Drawing.Point(10, 20);
			this.cbDiscordStateChanges.Margin = new System.Windows.Forms.Padding(0);
			this.cbDiscordStateChanges.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbDiscordStateChanges.MouseState = MaterialSkin.MouseState.HOVER;
			this.cbDiscordStateChanges.Name = "cbDiscordStateChanges";
			this.cbDiscordStateChanges.Ripple = true;
			this.cbDiscordStateChanges.Size = new System.Drawing.Size(196, 30);
			this.cbDiscordStateChanges.TabIndex = 2;
			this.cbDiscordStateChanges.Text = "Notify about state changes";
			this.cbDiscordStateChanges.UseVisualStyleBackColor = true;
			// 
			// gbDiscordChannel
			// 
			this.gbDiscordChannel.Controls.Add(this.tbDiscordChannel);
			this.gbDiscordChannel.Location = new System.Drawing.Point(187, 101);
			this.gbDiscordChannel.Name = "gbDiscordChannel";
			this.gbDiscordChannel.Size = new System.Drawing.Size(164, 50);
			this.gbDiscordChannel.TabIndex = 6;
			this.gbDiscordChannel.TabStop = false;
			this.gbDiscordChannel.Text = "Channel";
			// 
			// tbDiscordChannel
			// 
			this.tbDiscordChannel.Depth = 0;
			this.tbDiscordChannel.Hint = "";
			this.tbDiscordChannel.Location = new System.Drawing.Point(6, 20);
			this.tbDiscordChannel.MaxLength = 32767;
			this.tbDiscordChannel.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbDiscordChannel.Name = "tbDiscordChannel";
			this.tbDiscordChannel.PasswordChar = '\0';
			this.tbDiscordChannel.SelectedText = "";
			this.tbDiscordChannel.SelectionLength = 0;
			this.tbDiscordChannel.SelectionStart = 0;
			this.tbDiscordChannel.Size = new System.Drawing.Size(142, 23);
			this.tbDiscordChannel.TabIndex = 0;
			this.tbDiscordChannel.TabStop = false;
			this.tbDiscordChannel.UseSystemPasswordChar = false;
			// 
			// gbDiscordAdmin
			// 
			this.gbDiscordAdmin.Controls.Add(this.tbDiscordAdmin);
			this.gbDiscordAdmin.Enabled = false;
			this.gbDiscordAdmin.Location = new System.Drawing.Point(12, 101);
			this.gbDiscordAdmin.Name = "gbDiscordAdmin";
			this.gbDiscordAdmin.Size = new System.Drawing.Size(164, 50);
			this.gbDiscordAdmin.TabIndex = 5;
			this.gbDiscordAdmin.TabStop = false;
			this.gbDiscordAdmin.Text = "Admin";
			// 
			// tbDiscordAdmin
			// 
			this.tbDiscordAdmin.Depth = 0;
			this.tbDiscordAdmin.Hint = "";
			this.tbDiscordAdmin.Location = new System.Drawing.Point(7, 20);
			this.tbDiscordAdmin.MaxLength = 32767;
			this.tbDiscordAdmin.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbDiscordAdmin.Name = "tbDiscordAdmin";
			this.tbDiscordAdmin.PasswordChar = '\0';
			this.tbDiscordAdmin.SelectedText = "";
			this.tbDiscordAdmin.SelectionLength = 0;
			this.tbDiscordAdmin.SelectionStart = 0;
			this.tbDiscordAdmin.Size = new System.Drawing.Size(141, 23);
			this.tbDiscordAdmin.TabIndex = 0;
			this.tbDiscordAdmin.TabStop = false;
			this.tbDiscordAdmin.UseSystemPasswordChar = false;
			// 
			// btnDiscordHelp
			// 
			this.btnDiscordHelp.AutoSize = true;
			this.btnDiscordHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDiscordHelp.Depth = 0;
			this.btnDiscordHelp.Icon = null;
			this.btnDiscordHelp.Location = new System.Drawing.Point(527, 252);
			this.btnDiscordHelp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnDiscordHelp.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnDiscordHelp.Name = "btnDiscordHelp";
			this.btnDiscordHelp.Primary = false;
			this.btnDiscordHelp.Size = new System.Drawing.Size(55, 36);
			this.btnDiscordHelp.TabIndex = 4;
			this.btnDiscordHelp.Text = "Help";
			this.btnDiscordHelp.UseVisualStyleBackColor = true;
			this.btnDiscordHelp.Click += new System.EventHandler(this.btnDiscordHelp_Click);
			// 
			// cbEnableDiscord
			// 
			this.cbEnableDiscord.AutoSize = true;
			this.cbEnableDiscord.Depth = 0;
			this.cbEnableDiscord.Font = new System.Drawing.Font("Roboto", 10F);
			this.cbEnableDiscord.Location = new System.Drawing.Point(12, 12);
			this.cbEnableDiscord.Margin = new System.Windows.Forms.Padding(0);
			this.cbEnableDiscord.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbEnableDiscord.MouseState = MaterialSkin.MouseState.HOVER;
			this.cbEnableDiscord.Name = "cbEnableDiscord";
			this.cbEnableDiscord.Ripple = true;
			this.cbEnableDiscord.Size = new System.Drawing.Size(174, 30);
			this.cbEnableDiscord.TabIndex = 1;
			this.cbEnableDiscord.Text = "Enable Discord Support";
			this.cbEnableDiscord.UseVisualStyleBackColor = true;
			this.cbEnableDiscord.CheckedChanged += new System.EventHandler(this.cbEnableDiscord_CheckedChanged);
			// 
			// gbDiscordToken
			// 
			this.gbDiscordToken.Controls.Add(this.tbDiscordToken);
			this.gbDiscordToken.Enabled = false;
			this.gbDiscordToken.Location = new System.Drawing.Point(12, 45);
			this.gbDiscordToken.Name = "gbDiscordToken";
			this.gbDiscordToken.Size = new System.Drawing.Size(339, 50);
			this.gbDiscordToken.TabIndex = 0;
			this.gbDiscordToken.TabStop = false;
			this.gbDiscordToken.Text = "Bot Token";
			// 
			// tbDiscordToken
			// 
			this.tbDiscordToken.Depth = 0;
			this.tbDiscordToken.Hint = "";
			this.tbDiscordToken.Location = new System.Drawing.Point(7, 20);
			this.tbDiscordToken.MaxLength = 32767;
			this.tbDiscordToken.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbDiscordToken.Name = "tbDiscordToken";
			this.tbDiscordToken.PasswordChar = '\0';
			this.tbDiscordToken.SelectedText = "";
			this.tbDiscordToken.SelectionLength = 0;
			this.tbDiscordToken.SelectionStart = 0;
			this.tbDiscordToken.Size = new System.Drawing.Size(326, 23);
			this.tbDiscordToken.TabIndex = 0;
			this.tbDiscordToken.TabStop = false;
			this.tbDiscordToken.UseSystemPasswordChar = false;
			// 
			// tpAbout
			// 
			this.tpAbout.Controls.Add(this.btnCheckUpdate);
			this.tpAbout.Controls.Add(this.btnHomePage);
			this.tpAbout.Controls.Add(this.lBuildDate);
			this.tpAbout.Controls.Add(this.btnForgetLogin);
			this.tpAbout.Controls.Add(this.label1);
			this.tpAbout.Location = new System.Drawing.Point(4, 22);
			this.tpAbout.Name = "tpAbout";
			this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
			this.tpAbout.Size = new System.Drawing.Size(586, 294);
			this.tpAbout.TabIndex = 4;
			this.tpAbout.Text = "About";
			this.tpAbout.UseVisualStyleBackColor = true;
			this.tpAbout.Enter += new System.EventHandler(this.tpAbout_Enter);
			// 
			// btnCheckUpdate
			// 
			this.btnCheckUpdate.AutoSize = true;
			this.btnCheckUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCheckUpdate.Depth = 0;
			this.btnCheckUpdate.Icon = null;
			this.btnCheckUpdate.Location = new System.Drawing.Point(421, 175);
			this.btnCheckUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnCheckUpdate.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnCheckUpdate.Name = "btnCheckUpdate";
			this.btnCheckUpdate.Primary = false;
			this.btnCheckUpdate.Size = new System.Drawing.Size(158, 36);
			this.btnCheckUpdate.TabIndex = 5;
			this.btnCheckUpdate.Text = "Check for updates";
			this.btnCheckUpdate.UseVisualStyleBackColor = true;
			this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
			// 
			// btnHomePage
			// 
			this.btnHomePage.AutoSize = true;
			this.btnHomePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnHomePage.Depth = 0;
			this.btnHomePage.Icon = null;
			this.btnHomePage.Location = new System.Drawing.Point(460, 249);
			this.btnHomePage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnHomePage.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnHomePage.Name = "btnHomePage";
			this.btnHomePage.Primary = false;
			this.btnHomePage.Size = new System.Drawing.Size(119, 36);
			this.btnHomePage.TabIndex = 4;
			this.btnHomePage.Text = "Project page";
			this.btnHomePage.UseVisualStyleBackColor = true;
			this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
			// 
			// lBuildDate
			// 
			this.lBuildDate.AutoSize = true;
			this.lBuildDate.Depth = 0;
			this.lBuildDate.Font = new System.Drawing.Font("Roboto", 11F);
			this.lBuildDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lBuildDate.Location = new System.Drawing.Point(12, 160);
			this.lBuildDate.MouseState = MaterialSkin.MouseState.HOVER;
			this.lBuildDate.Name = "lBuildDate";
			this.lBuildDate.Size = new System.Drawing.Size(0, 19);
			this.lBuildDate.TabIndex = 3;
			// 
			// btnForgetLogin
			// 
			this.btnForgetLogin.AutoSize = true;
			this.btnForgetLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnForgetLogin.Depth = 0;
			this.btnForgetLogin.Icon = null;
			this.btnForgetLogin.Location = new System.Drawing.Point(399, 212);
			this.btnForgetLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnForgetLogin.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnForgetLogin.Name = "btnForgetLogin";
			this.btnForgetLogin.Primary = false;
			this.btnForgetLogin.Size = new System.Drawing.Size(180, 36);
			this.btnForgetLogin.TabIndex = 2;
			this.btnForgetLogin.Text = "Forget current login";
			this.btnForgetLogin.UseVisualStyleBackColor = true;
			this.btnForgetLogin.Click += new System.EventHandler(this.btnForgetLogin_Click);
			// 
			// label1
			// 
			this.label1.Depth = 0;
			this.label1.Font = new System.Drawing.Font("Roboto", 11F);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.MouseState = MaterialSkin.MouseState.HOVER;
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(328, 122);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// materialTabSelector
			// 
			this.materialTabSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialTabSelector.BaseTabControl = this.tabControl1;
			this.materialTabSelector.Depth = 0;
			this.materialTabSelector.Location = new System.Drawing.Point(0, 64);
			this.materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabSelector.Name = "materialTabSelector";
			this.materialTabSelector.Size = new System.Drawing.Size(619, 48);
			this.materialTabSelector.TabIndex = 17;
			this.materialTabSelector.Text = "materialTabSelector";
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 500);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.materialTabSelector);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
			this.tpChatrooms.ResumeLayout(false);
			this.tpAPI.ResumeLayout(false);
			this.tpAPI.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.tpDiscord.ResumeLayout(false);
			this.tpDiscord.PerformLayout();
			this.gbDiscordSteam.ResumeLayout(false);
			this.gbDiscordMessages.ResumeLayout(false);
			this.gbDiscordSettings.ResumeLayout(false);
			this.gbDiscordSettings.PerformLayout();
			this.gbDiscordChannel.ResumeLayout(false);
			this.gbDiscordAdmin.ResumeLayout(false);
			this.gbDiscordToken.ResumeLayout(false);
			this.tpAbout.ResumeLayout(false);
			this.tpAbout.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialRaisedButton btnSave;
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
        private MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpChatrooms;
        private System.Windows.Forms.TabPage tpAPI;
        private MaterialFlatButton btnMoreInfo;
        private System.Windows.Forms.GroupBox groupBox10;
        private MaterialSingleLineTextField tbApiSteam;
        private System.Windows.Forms.GroupBox groupBox7;
        private MaterialSingleLineTextField tbApiCleverbot;
        private System.Windows.Forms.GroupBox groupBox9;
        private MaterialSingleLineTextField tbApiGoogle;
        private System.Windows.Forms.GroupBox groupBox8;
        private MaterialSingleLineTextField tbApiWeather;
        private System.Windows.Forms.TabPage tbGamePlayed;
        private MaterialSingleLineTextField tbGameInfo;
        private MaterialCheckBox cbGameType;
        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.TabPage tpAbout;
        private MaterialLabel label1;
        private MaterialLabel lBuildDate;
        private MaterialFlatButton btnForgetLogin;
        private MaterialFlatButton btnHomePage;
		private System.Windows.Forms.TabPage tpDiscord;
		private MaterialCheckBox cbEnableDiscord;
		private System.Windows.Forms.GroupBox gbDiscordToken;
		private MaterialSingleLineTextField tbDiscordToken;
		private MaterialFlatButton btnDiscordHelp;
		private System.Windows.Forms.GroupBox gbDiscordSettings;
		private MaterialCheckBox cbDiscordStateChanges;
		private System.Windows.Forms.GroupBox gbDiscordAdmin;
		private MaterialSingleLineTextField tbDiscordAdmin;
		private MaterialFlatButton btnCheckUpdate;
		private MaterialCheckBox cbUpdates;
		private System.Windows.Forms.GroupBox gbDiscordChannel;
		private MaterialSingleLineTextField tbDiscordChannel;
		private System.Windows.Forms.ComboBox cbDiscordMessages;
		private System.Windows.Forms.GroupBox gbDiscordMessages;
		private System.Windows.Forms.GroupBox gbDiscordSteam;
		private System.Windows.Forms.ComboBox cbDiscordSteam;
	    private MaterialTabSelector materialTabSelector;
		private MaterialCheckBox materialCheckBox1;
	}
}