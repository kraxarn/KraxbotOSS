using System.Windows.Forms;

namespace KraxbotOSS
{
    public partial class FormChatroomInfo : Form
    {
        public FormChatroomInfo(Form1.Settings settings, Form1 form)
        {
            InitializeComponent();

            Text = settings.ChatName;

            Set(lInvitedName, settings.InvitedName);
            Set(lSpam,        settings.Spam);
            Set(lWelcomeMsg,  settings.WelcomeMsg);

            Set(lCleverbot,     settings.Cleverbot);
            Set(lCommands,      settings.Commands);
            Set(lDcKick,        settings.DCKick);
            Set(lWelcome,       settings.Welcome);
            Set(lGames,         settings.Games);
            Set(lDefine,        settings.Define);
            Set(lWiki,          settings.Wiki);
            Set(lSearch,        settings.Search);
            Set(lWeather,       settings.Weather);
            Set(lStore,         settings.Store);
            Set(lResponses,     settings.Responses);
            Set(lLinkResolving, settings.Links);
            Set(lRules,         settings.Rules);
            Set(lAllPoke,       settings.AllPoke);

            Set(lDelayRandom,  settings.DelayRandom);
            Set(lDelayDefine,  settings.DelayDefine);
            Set(lDelayGames,   settings.DelayGames);
            Set(lDelayRecents, settings.DelayRecents);
            Set(lDelaySearch,  settings.DelaySearch);
            Set(lYtDelay,      settings.DelayYT);

            foreach (var userID in settings.Users)
            {
                string[] add =
                {
	                form.GetFriendName(userID.SteamID), userID.SteamID.AccountID.ToString(), userID.Rank.ToString()
                };
                lvUsers.Items.Add(new ListViewItem(add));
            }
            foreach (ColumnHeader header in lvUsers.Columns)
                header.Width = -1;
        }

		private static void Set(Control label, string setting) => label.Text = setting;

		private static void Set(Control label, bool setting) => label.Text = setting ? "Enabled" : "Disabled";

		// Assume it's for delays
		private static void Set(Control label, int delay) => label.Text = $"{delay} s";
    }
}
