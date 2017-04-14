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
using SteamKit2;

namespace KraxbotOSS
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            // TODO: For now, default to all, but get from settings later
            cbUpdates.SelectedIndex = 2;
            cbFriendRequest.SelectedIndex = 0;
            cbChatRequest.SelectedIndex = 0;
            cbLoginAs.SelectedIndex = 0;

            // Get all our friends and fill the list
            List<SteamID> friends = Form1.GetFriends();
            foreach (SteamID userID in friends)
                cbFriends.Items.Add(Form1.GetFriendName(userID));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save, close and show main form again
            // TODO: We don't save chatrooms to join yet

            // TODO: Remake this into a list or something and use that instead

            /*
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter w = new JsonTextWriter(sw))
            {
                w.Formatting = Formatting.Indented;
                w.WriteStartObject();
                w.WritePropertyName("Updates");
                w.WriteValue(cbUpdates.SelectedIndex);
                //w.WritePropertyName("Superadmin");
                //w.WriteValue(tbSuperadmin.Text);
                w.WritePropertyName("FriendRequest");
                w.WriteValue(cbFriendRequest.SelectedIndex);
                w.WritePropertyName("ChatRequest");
                w.WriteValue(cbChatRequest.SelectedIndex);
                w.WritePropertyName("LoginAs");
                w.WriteValue(cbLoginAs.SelectedIndex);
            }
            // This is bad
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrowGames", "KraxbotOSS", "settings"), sb.ToString());
            */

            this.Close();
        }
    }
}
