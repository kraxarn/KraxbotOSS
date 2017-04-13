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

using SteamKit2;

namespace KraxbotOSS
{
    public partial class Form1 : Form
    {
        // Some variables
        string version = "0.1.0";
        bool running;
        static string configPath;
        Settings[] CR;

        // Steam variables
        static SteamClient client;
        static CallbackManager manager;
        static SteamUser user;
        static SteamFriends friends;

        public Form1()
        {
            InitializeComponent();

            // Testing stuff
            //lbChatrooms.Items.Add("Test");

            // Check config dir
            configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrowGames", "KraxbotOSS");
            if (!Directory.Exists(configPath))
            {
                // User is prob running for the first time
                Directory.CreateDirectory(configPath);
            }

            // Welcome the user :)
            log.AppendText("Welcome to KraxBot " + version);

            // Steam stuff
            // Create client and callback manager to route callbacks to functions
            client = new SteamClient();
            manager = new CallbackManager(client);
            // Get the user handler, which is used for logging in
            user = client.GetHandler<SteamUser>();
            friends = client.GetHandler<SteamFriends>();
            // Register more callbacks
            manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);            // When we connect
            manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);      // When we disconnect
            manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);                // When we finished logging in
            manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);              // When we got logged off
            manager.Subscribe<SteamUser.AccountInfoCallback>(OnAccountInfo);          // We finished logging in
            //manager.Subscribe<SteamFriends.FriendsListCallback>(OnFriendsList);     // We recieved our friends list
            //manager.Subscribe<SteamFriends.PersonaStateCallback>(OnPersonaState);   // When a friend changes status
            manager.Subscribe<SteamFriends.FriendAddedCallback>(OnFriendAdded);       // Someone added us
            manager.Subscribe<SteamFriends.FriendMsgCallback>(OnFriendMsg);           // We got a PM
            manager.Subscribe<SteamFriends.ChatMsgCallback>(OnChatMsg);               // Someone sent a chat message
            manager.Subscribe<SteamFriends.ChatInviteCallback>(OnChatInvite);         // We got invited to a chat
            manager.Subscribe<SteamFriends.ChatEnterCallback>(OnChatEnter);           // We entered a chat
            //manager.Subscribe<SteamFriends.ChatActionResultCallback>(OnChatAction); // ?
            manager.Subscribe<SteamFriends.ChatMemberInfoCallback>(OnChatMemberInfo); // A user has left or entered a chat
            manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);    // We logged in and can store it

            // Tell the main Steam loop we are running
            running = true;

            // Connect
            log.AppendText("\nConnecting to Steam... ");
            client.Connect();

            // Run main loop in a seperate thread
            Task.Run(() => { while (running) { manager.RunWaitCallbacks(TimeSpan.FromSeconds(1)); } });
        }

        // -- Classes -- //

        // Chat settings
        internal class Settings
        {
            internal int Version = 0;
            internal string ChatName = "NoName";
            internal SteamID InvitedID;
            internal string InvitedName = "NoName";

            internal string Spam = "Kick";
            internal string WelcomeMsg = "Welcome";
            internal string WelcomeEnd = "!";
            internal SteamID LastPoke;
            internal string DCKick = "Kick";

            internal bool Cleverbot = false;
            internal bool Translate = false;
            internal bool Commands = true;

            internal bool Welcome = true;
            internal bool Games = true;
            internal bool Define = true;
            internal bool Wiki = true;
            internal bool Search = true;
            internal bool Weather = true;
            internal bool Store = true;
            internal bool Responses = true;
            internal bool Links = true;
            internal bool Rules = true;
            internal bool Poke = true;
            internal bool AllStates = false;
            internal bool AllPoke = false;
            internal bool AutoWelcome = false;

            internal int DCLimit = 5;
            internal int DelayRandom = 120;
            internal int DelayDefine = 300;
            internal int DelayGames = 120;
            internal int DelayRecents = 120;
            internal int DelaySearch = 120;
            internal int DelayYT = 120;

            internal int DCKickLimit = 3;
            internal int DCBanLimit = 5;

            internal int TimeoutRandom = 0;
            internal int TimeoutDefine = 0;
            internal int TimeoutGames = 0;
            internal int TimeoutRecents = 0;
            internal int TimeoutSearch = 0;
            internal int TimeoutYT = 0;

            internal bool CustomEnabled = false;
            internal bool CustomModOnly = false;
            internal int CustomDelay = 5;
            internal string CustomCommand = "!custom";
            internal string CustomResponse = "Custom response";

            internal string AutokickMode = "None";
            internal SteamID AutokickUser;
        }

        // -- Steam functions -- //

        public static void Login(string username, string password)
        {
            user.LogOn(new SteamUser.LogOnDetails
            {
                Username = username,
                Password = password,
            });
        }

        // -- Steam callbacks -- //

        void OnConnected(SteamClient.ConnectedCallback callback)
        {
            // TODO: Handle this better or something
            if (callback.Result != EResult.OK)
            {
                MessageBox.Show("Error connecting to Steam, try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                running = false;
                this.Close();
                return;
            }
            Log("Ok");
            this.Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = true;
                lState.Text = "State: Connected";
            });
        }
        void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // TODO: Only show the message once
            Log("\nDisconnected, attempting to reconnect... ");
            client.Connect();
        }
        void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                // TODO: Add Steam Guard support
                if (callback.Result == EResult.AccountLogonDenied)
                    MessageBox.Show("Denied login to Steam: " + callback.Result, "Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Unable to login to Steam: " + callback.Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Log("\nLogged in");
            Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = false;
                btnBotSettings.Enabled = true;
                lStatus.Text = "State: Logged in";
            });

            // To other stuff here after logging in (like joining chatrooms)
        }
        void OnAccountInfo(SteamUser.AccountInfoCallback callback)
        {
            // Set as online
            friends.SetPersonaState(EPersonaState.Online);
        }
        void OnFriendAdded(SteamFriends.FriendAddedCallback callback)
        {
            Log(callback.PersonaName + " is now my friend");
        }
        void OnChatInvite(SteamFriends.ChatInviteCallback callback)
        {
            // TODO: For now, just log it
            Log(string.Format("\nGot invite to {0} from {1}", callback.ChatRoomName, friends.GetFriendPersonaName(callback.PatronID)));
        }
        void OnChatEnter(SteamFriends.ChatEnterCallback callback)
        {
            // TODO: Just log here as well, check for chatroom settings and stuff later
            Log(string.Format("\nJoined {0}", callback.ChatRoomName));
        }
        void OnChatMemberInfo(SteamFriends.ChatMemberInfoCallback callback)
        {
            // When a user enters or leaves a chat
            // TODO: Add more to this
            Log(string.Format("\n{0} {1} ({2})", friends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn), callback.StateChangeInfo.StateChange, callback.Type));
        }
        void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            Log("\nLogged out");
        }
        static void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            // Writes sentry file
            int fileSize;
            byte[] sentryHash;
            using (var fs = File.Open(Path.Combine(configPath, "sentry"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(callback.Offset, SeekOrigin.Begin);
                fs.Write(callback.Data, 0, callback.BytesToWrite);
                fileSize = (int)fs.Length;
                fs.Seek(0, SeekOrigin.Begin);
                using (var sha = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                    sentryHash = sha.ComputeHash(fs);
            }
            // Inform Steam what we're accepting this sentry file
            user.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                JobID = callback.JobID,
                FileName = callback.FileName,
                BytesWritten = callback.BytesToWrite,
                FileSize = fileSize,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,
                OneTimePassword = callback.OneTimePassword,
                SentryFileHash = sentryHash
            });
        }
        void OnFriendMsg(SteamFriends.FriendMsgCallback callback)
        {
            // TODO: Commands and/or Cleverbot
            string message = callback.Message;
            if (!string.IsNullOrEmpty(message))
            {
                Log(string.Format("\n{0}: {1}", friends.GetFriendPersonaName(callback.Sender), message));
            }
        }
        void OnChatMsg(SteamFriends.ChatMsgCallback callback)
        {
            // TODO: Commands and maybe Cleverbot
            // TODO: Log this different than friend messages
            // TODO: Does this assume we are friends with the user?
            log.AppendText(string.Format("\n{1}: {2}", friends.GetFriendPersonaName(callback.ChatterID), callback.Message));
        }

        // -- Other stuffs -- //

        void Log(string text)
        {
            Invoke((MethodInvoker)delegate
            {
                log.AppendText(text);
            });
        }

        void CreateSettings(SteamID ChatRoomID)
        {
            // TODO: This may or may not work lol
            CR[ChatRoomID.ConvertToUInt64()] = new Settings();
        }

        // -- Buttons and ui stuff -- //

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Hide the main form and show the settings form
            //this.Hide();
            Form settings = new FormSettings();
            settings.Show();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form login = new FormLogin();
            login.Show();
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }
    }
}
