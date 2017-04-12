using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SteamKit2;

namespace KraxbotOSS
{
    public partial class Form1 : Form
    {
        // Some variables
        string version = "0.1.0";
        bool running;

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
            manager.Subscribe<SteamFriends.ChatMemberInfoCallback>(OnChatMemberInfo); // ?

            // Tell the main Steam loop we are running
            running = true;

            // Connect
            log.AppendText("\nConnecting to Steam... ");
            client.Connect();

            // Run main loop in a seperate thread
            Task.Run(() => { while (running) { manager.RunWaitCallbacks(TimeSpan.FromSeconds(1)); } });
        }

        // -- Steam functions -- //

        public void Login(string username, string password)
        {

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
            Log("OK");
            this.Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = true;
                lStatus.Text = "State: Connected";
            });
        }
        void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // TODO: Only show the message once
            log.AppendText("\nDisconnected, attempting to reconnect...");
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
            }
            log.AppendText("\nLogged in");

            // To other stuff here after logging in (like joining chatrooms)
        }
        void OnAccountInfo(SteamUser.AccountInfoCallback callback)
        {
            // Set as online
            friends.SetPersonaState(EPersonaState.Online);
        }
        void OnFriendAdded(SteamFriends.FriendAddedCallback callback)
        {
            log.AppendText(callback.PersonaName + " is now my friend");
        }
        void OnChatInvite(SteamFriends.ChatInviteCallback callback)
        {
            // TODO: For now, just log it
            log.AppendText(string.Format("\nGot invite to {0} from {1}", callback.ChatRoomName, friends.GetFriendPersonaName(callback.InvitedID)));
        }
        void OnChatEnter(SteamFriends.ChatEnterCallback callback)
        {
            // TODO: Just log here as well, check for chatroom settings and stuff later
            log.AppendText(string.Format("\nJoined {0}", callback.ChatRoomName));
        }
        void OnChatMemberInfo(SteamFriends.ChatMemberInfoCallback callback)
        {
            // When a user enters or leaves a chat
            // TODO: Add more to this
            log.AppendText(string.Format("\n{0} {1} ({2})", friends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn), callback.StateChangeInfo.StateChange, callback.Type));
        }
        void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            log.AppendText("\nLogged out");
        }
        void OnFriendMsg(SteamFriends.FriendMsgCallback callback)
        {
            // TODO: Commands and/or Cleverbot
            log.AppendText(string.Format("\n{0}: {1}", friends.GetFriendPersonaName(callback.Sender), callback.Message));
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
            this.Invoke((MethodInvoker)delegate
            {
                log.AppendText(text);
            });
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
            client.Disconnect();
        }
    }
}
