using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamKit2;
using System.Diagnostics;

namespace KraxbotOSS
{
    public partial class FormSettings : Form
    {
        private readonly List<SteamID> friends, groups;

	    private readonly Form1 parent;

        public FormSettings(Form1 form)
        {
            InitializeComponent();

	        parent = form;

            // Get setttings
            int index;
            switch(Form1.config.Updates)
            {
                case "None": index = 1; break;
                default:     index = 0; break; // 0: All
            }
	        cbUpdates.Checked = index == 0;

            switch(Form1.config.FriendRequest)
            {
                case "IgnoreAll": index = 1; break;
                default:          index = 0; break; // 0: AcceptAll
            }
            cbFriendRequest.SelectedIndex = index;

            switch(Form1.config.ChatRequest)
            {
                case "SuperadminOnly": index = 1; break;
                case "IgnoreAll":      index = 2; break;
                default:               index = 0; break; // 0: AcceptAll
            }
            cbChatRequest.SelectedIndex = index;

            cbLoginAs.SelectedIndex = (int)Form1.config.LoginAs;

            // Get API keys
            tbApiSteam.Text     = Form1.config.API_Steam;
            tbApiGoogle.Text    = Form1.config.API_Google;
            tbApiWeather.Text   = Form1.config.API_OpenWeather;
            tbApiCleverbot.Text = Form1.config.API_CleverbotIO;

            // Get all our friends and fill the list
            friends = Form1.GetFriends();
            foreach (var userID in friends)
            {
                cbFriends.Items.Add($"{Form1.GetFriendName(userID)} ({userID.AccountID})");
                if (userID.AccountID == Form1.config.Superadmin)
                    cbFriends.SelectedIndex = cbFriends.Items.Count - 1;
            }

            if (cbFriends.Items.Count == 0)
                cbFriends.Enabled = false;

            // Get all known chatrooms
            groups = Form1.GetGroups();
            if (groups.Count > 0)
            {
                foreach (var clanID in groups)
                    if (Form1.config.Chatrooms.ToString().IndexOf(clanID.AccountID.ToString()) > -1)
                        clChats.Items.Add($"{Form1.GetGroupName(clanID)} ({clanID.AccountID})", true);
                    else
                        clChats.Items.Add($"{Form1.GetGroupName(clanID)} ({clanID.AccountID})");
            }
            else
                clChats.Enabled = false;

            // Get game info
            if (Form1.config.GamePlayed_ID == 12350489788975939584)
            {
                cbGameType.Checked = true;
                gbGame.Text = "App Name";
                tbGameInfo.Text = Form1.config.GamePlayed_ExtraInfo;
            }
            else
                tbGameInfo.Text = Form1.config.GamePlayed_ID.ToString();

			// Discord
			gbDiscordToken.Enabled        = gbDiscordAdmin.Enabled = gbDiscordSettings.Enabled = cbEnableDiscord.Checked = Form1.config.Discord_Enabled;
			tbDiscordToken.Text           = Form1.config.Discord_Token;
			tbDiscordAdmin.Text           = Form1.config.Discord_Admin;
			cbDiscordStateChanges.Checked = Form1.config.Discord_StateChanges;
			cbDiscordToSteam.Checked      = Form1.config.Discord_DiscordToSteam;
			cbSteamToDiscord.Checked      = Form1.config.Discord_SteamToDiscord;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // API Keys
            Form1.config.API_Steam = tbApiSteam.Text;
            Form1.config.API_Google = tbApiGoogle.Text;
            Form1.config.API_OpenWeather = tbApiWeather.Text;
            if (string.IsNullOrEmpty(tbApiCleverbot.Text))
                Form1.config.API_CleverbotIO = null;
            else if (tbApiCleverbot.Text.Contains(';'))
                Form1.config.API_CleverbotIO = tbApiCleverbot.Text;
            else
            {
                MessageBox.Show("Cleverbot API key doesn't seem to have been correctly entered, so it was ignored", "Cleverbot API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Form1.config.API_CleverbotIO = null;
            }

            // Set variables
	        var updates       = cbUpdates.Checked;
            var friendRequest = cbFriendRequest.SelectedIndex;
            var chatRequest   = cbChatRequest.SelectedIndex;
            var loginAs       = cbLoginAs.SelectedIndex;

            switch (updates)
            {
                case true:  Form1.config.Updates = "All";  break;
                case false: Form1.config.Updates = "None"; break;
            }
            switch (friendRequest)
            {
                case 0: Form1.config.FriendRequest = "AcceptAll"; break;
                case 1: Form1.config.FriendRequest = "IgnoreAll"; break;
            }
            switch (chatRequest)
            {
                case 0: Form1.config.ChatRequest = "AcceptAll";      break;
                case 1: Form1.config.ChatRequest = "SuperadminOnly"; break;
                case 2: Form1.config.ChatRequest = "IgnoreAll";      break;
            }
            Form1.config.LoginAs = (EPersonaState)loginAs;

            // Superadmin
            int from, to;
            var superadmin = Form1.config.Superadmin.ToString();
            if (cbFriends.Enabled && cbFriends.SelectedIndex > 0)
            {
                from = cbFriends.Text.LastIndexOf('(') + 1;
                to   = cbFriends.Text.LastIndexOf(')');
                superadmin = cbFriends.Text.Substring(from, to - from);
                Form1.config.Superadmin = friends.Single(s => s.AccountID.ToString() == superadmin).AccountID;
            }

            // Autojoin chatrooms
            Form1.config.Chatrooms.Clear();
            var chatrooms = new List<int>();
            if (clChats.Enabled)
            {
                for (var i = 0; i < clChats.Items.Count; i++)
                    if (clChats.GetItemChecked(i))
                    {
                        var group = clChats.Items[i].ToString();
                        from = (group.LastIndexOf('(') + 1);
                        to   = (group.LastIndexOf(')'));
                        var groupID = int.Parse(group.Substring(from, to - from));
                        chatrooms.Add(groupID);
                        Form1.config.Chatrooms.Add(groupID);
                    }
            }

            // Game to play
            ulong gameID;
            var gameExtraInfo = Form1.config.GamePlayed_ExtraInfo;
            if (cbGameType.Checked)
            {
                gameID = 12350489788975939584;
                gameExtraInfo = tbGameInfo.Text;
            }
            else
            {
                if (!ulong.TryParse(tbGameInfo.Text, out gameID))
                {
                    MessageBox.Show("App ID doesn't seem to be a number and was set as non-Steam game", "App ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gameID = 12350489788975939584;
                    gameExtraInfo = tbGameInfo.Text;
                }
            }
            Form1.config.GamePlayed_ID        = gameID;
            Form1.config.GamePlayed_ExtraInfo = gameExtraInfo;

            // Start game
            Form1.PlayGame(gameID, gameExtraInfo);

			// Discord
			Form1.config.Discord_Enabled        = cbEnableDiscord.Checked;
			Form1.config.Discord_Token          = tbDiscordToken.Text;
			Form1.config.Discord_Admin          = tbDiscordAdmin.Text;
			Form1.config.Discord_StateChanges   = cbDiscordStateChanges.Checked;
			Form1.config.Discord_DiscordToSteam = cbDiscordToSteam.Checked;
			Form1.config.Discord_SteamToDiscord = cbSteamToDiscord.Checked;

			var obj = JObject.FromObject(new
            {
	            Form1.config.Updates,
	            Form1.config.FriendRequest,
	            Form1.config.ChatRequest,
	            Form1.config.LoginAs,
                Superadmin = superadmin,
                Chatrooms  = chatrooms,
                API = new
                {
                    SteamWeb       = Form1.config.API_Steam,
                    Google         = Form1.config.API_Google,
                    OpenWeatherMap = Form1.config.API_OpenWeather,
                    CleverbotIO    = Form1.config.API_CleverbotIO
                },
                GamePlayed = new
                {
                    ID = gameID,
                    ExtraInfo = gameExtraInfo
                },
				Discord = new
				{
					Enabled        = Form1.config.Discord_Enabled,
					Token          = Form1.config.Discord_Token,
					Admin          = Form1.config.Discord_Admin,
					StateChanges   = Form1.config.Discord_StateChanges,
					DiscordToSteam = Form1.config.Discord_DiscordToSteam,
					SteamToDiscord = Form1.config.Discord_SteamToDiscord
				}
            });

            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrowGames", "KraxbotOSS", "settings.json"), JsonConvert.SerializeObject(obj, Formatting.Indented));
            Close();
        }

		private void cbGameType_CheckedChanged(object sender, EventArgs e) => gbGame.Text = cbGameType.Checked ? "App Name" : "App ID";

		private void tpAbout_Enter(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var build = new DateTime(2000, 1, 1)
                .AddDays(version.Build)
                .AddSeconds(version.Revision * 2);
            var buildDate = build.ToString();
            if (!string.IsNullOrEmpty(buildDate))
                lBuildDate.Text = "This version was built on \n" + buildDate;
        }

        private void btnHomePage_Click(object sender, EventArgs e)    => Process.Start("https://github.com/KraXarN/KraxbotOSS");
        private void btnMoreInfo_Click(object sender, EventArgs e)    => Process.Start("https://github.com/KraXarN/KraxbotOSS/wiki/API-Keys");
		private void btnDiscordHelp_Click(object sender, EventArgs e) => Process.Start("https://github.com/kraxarn/KraxbotOSS/wiki/Discord");

		private void cbEnableDiscord_CheckedChanged(object sender, EventArgs e) => gbDiscordToken.Enabled = gbDiscordAdmin.Enabled = gbDiscordSettings.Enabled = cbEnableDiscord.Checked;

		private void btnCheckUpdate_Click(object sender, EventArgs e)
		{
			// Update button
			btnCheckUpdate.Enabled = false;
			btnCheckUpdate.Text = "Checking...";

			// Check for updates
			if (!parent.CheckForUpdates())
				MessageBox.Show("You're running the latest version!", "No New Update Found", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

			// Restore button
			btnCheckUpdate.Enabled = true;
			btnCheckUpdate.Text = "Check for updates";
		}

		private void btnForgetLogin_Click(object sender, EventArgs e)
        {
            File.Delete(Path.Combine(Form1.ConfigPath, "loginkey"));
            File.Delete(Path.Combine(Form1.ConfigPath, "user"));
        }
	}
}
