using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamKit2;

namespace KraxbotOSS
{
    public partial class FormSettings : Form
    {
        List<SteamID> friends, groups;

        public FormSettings()
        {
            InitializeComponent();

            // Get setttings
            int index = 0;
            switch(Form1.config.Updates)
            {
                case "All":       index = 0; break;
                case "OnlyMajor": index = 1; break;
                case "None":      index = 2; break;
                default: throw new Exception("Unexpected Updates value");
            }
            cbUpdates.SelectedIndex = index;

            switch(Form1.config.FriendRequest)
            {
                case "AcceptAll": index = 0; break;
                case "IgnoreAll": index = 1; break;
                default: throw new Exception("Unexpected FriendRequest value");
            }
            cbFriendRequest.SelectedIndex = index;

            switch(Form1.config.ChatRequest)
            {
                case "AcceptAll": index = 0; break;
                case "SuperadminOnly": index = 1; break;
                case "IgnoreAll": index = 2; break;
                default: throw new Exception("Unexpected ChatRequest value");
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
            foreach (SteamID userID in friends)
            {
                cbFriends.Items.Add(string.Format("{0} ({1})", Form1.GetFriendName(userID), userID.AccountID));
                if (userID.AccountID == Form1.config.Superadmin)
                    cbFriends.SelectedIndex = cbFriends.Items.Count - 1;
            }

            // Get all known chatrooms
            groups = Form1.GetGroups();
            foreach (SteamID clanID in groups)
                if (Form1.config.Chatrooms.ToString().IndexOf(clanID.AccountID.ToString()) > -1)
                    clChats.Items.Add(string.Format("{0} ({1})", Form1.GetGroupName(clanID), clanID.AccountID), true);
                else
                    clChats.Items.Add(string.Format("{0} ({1})", Form1.GetGroupName(clanID), clanID.AccountID));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save, close and show main form again
            // TODO: We don't save chatrooms to join yet

            // API Keys
            // TODO: For now, we just apply them
            if (!string.IsNullOrEmpty(tbApiSteam.Text))
                Form1.config.API_Steam = tbApiSteam.Text;
            if (!string.IsNullOrEmpty(tbApiGoogle.Text))
                Form1.config.API_Google = tbApiGoogle.Text;
            if (!string.IsNullOrEmpty(tbApiWeather.Text))
                Form1.config.API_OpenWeather = tbApiWeather.Text;
            if (!string.IsNullOrEmpty(tbApiCleverbot.Text))
                Form1.config.API_CleverbotIO = tbApiCleverbot.Text;

            // Set variables
            int updates       = cbUpdates.SelectedIndex;
            int friendRequest = cbFriendRequest.SelectedIndex;
            int chatRequest   = cbChatRequest.SelectedIndex;
            int loginAs       = cbLoginAs.SelectedIndex;

            switch (updates)
            {
                case 0: Form1.config.Updates = "All";       break;
                case 1: Form1.config.Updates = "OnlyMajor"; break;
                case 2: Form1.config.Updates = "None";      break;
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
            int from = (cbFriends.Text.LastIndexOf('(') + 1);
            int to = (cbFriends.Text.LastIndexOf(')'));
            string superadmin = cbFriends.Text.Substring(from, to - from);
            Form1.config.Superadmin = friends.Single(s => s.AccountID.ToString() == superadmin).AccountID;

            // Autojoin chatrooms
            List<int> chatrooms = new List<int>();
            for (int i = 0; i < clChats.Items.Count; i++)
                if (clChats.GetItemChecked(i))
                {
                    string group = clChats.Items[i].ToString();
                    from = (group.LastIndexOf('(') + 1);
                    to = (group.LastIndexOf(')'));
                    chatrooms.Add(int.Parse(group.Substring(from, to - from)));
                }

            JObject obj = JObject.FromObject(new
            {
                Updates       = Form1.config.Updates,
                FriendRequest = Form1.config.FriendRequest,
                ChatRequest   = Form1.config.ChatRequest,
                LoginAs       = Form1.config.LoginAs,
                Superadmin    = superadmin,
                Chatrooms     = chatrooms,
                API = new
                {
                    SteamWeb       = Form1.config.API_Steam,
                    Google         = Form1.config.API_Google,
                    OpenWeatherMap = Form1.config.API_OpenWeather,
                    CleverbotIO    = Form1.config.API_CleverbotIO
                }
            });

            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrowGames", "KraxbotOSS", "settings.json"), JsonConvert.SerializeObject(obj, Formatting.Indented));
            Close();
        }

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KraXarN/KraxbotOSS/wiki/API-Keys");
        }
    }
}
