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
using Newtonsoft.Json;

namespace KraxbotOSS
{
    public partial class Form1 : Form
    {
        // Some variables
        string version = "0.1.0";
        bool running;
        static string configPath;
        //Settings[] CR;
        List<Settings> CR = new List<Settings>();

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
            internal SteamID ChatID;
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

        // Settings
        internal class Config
        {
            internal string Updates;
            internal string FriendRequest;
            internal string ChatRequest;
            internal EPersonaState LoginAs;
        }

        // Advanced settings
        internal class AdvConfig
        {
            internal string API_Steam;
            internal string API_Google;
            internal string API_OpenWeather;
            internal string API_CleverbotIO;
        }

        // -- Steam functions -- //

        public static void Login(string username, string password)
        {
            bool isUsernameNull = string.IsNullOrEmpty(username);
            bool isPasswordNull = string.IsNullOrEmpty(password);
            if ((isUsernameNull && isPasswordNull) || (isUsernameNull || isPasswordNull))
                return;

            // Use sentry hash if we have one
            byte[] sentryHash = null;
            if (File.Exists(Path.Combine(configPath, "sentry")))
                sentryHash = CryptoHelper.SHAHash(File.ReadAllBytes(Path.Combine(configPath, "sentry")));

            user.LogOn(new SteamUser.LogOnDetails
            {
                Username = username,
                Password = password,
                SentryFileHash = sentryHash
            });
        }

        public static List<SteamID> GetFriends()
        {
            List<SteamID> friend = new List<SteamID>();
            for (int i = 0; i < friends.GetFriendCount(); i++)
                friend.Add(friends.GetFriendByIndex(i));
            return friend;
        }
        public static string GetFriendName(SteamID userID)
        {
            return friends.GetFriendPersonaName(userID);
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
                lNetwork.Text = "Network: Connected";
            });
        }
        void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // TODO: Only show the message once
            Log("\nDisconnected, attempting to reconnect... ");
            lNetwork.Text = "Network: Disconnected";
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

            // For now, we join all, but in the future, check what's set in the settings
            friends.JoinChat(callback.ChatRoomID);
        }
        void OnChatEnter(SteamFriends.ChatEnterCallback callback)
        {
            // TODO: Just log here as well, check for chatroom settings and stuff later
            SteamFriends.ChatMemberInfo bot = callback.ChatMembers.Single(s => s.SteamID == client.SteamID);

            Log(string.Format("\nJoined {0} as {1}", callback.ChatRoomName, bot.Details));

            // Add to chatrooms list
            Invoke((MethodInvoker)delegate
            {
                lbChatrooms.Items.Add(callback.ChatRoomName);
            });

            // Add value to chatroom settings if needed
            if (CR.SingleOrDefault(s => s.ChatID == callback.ChatID) == null)
                CreateSettings(callback.ChatID);
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
            Log(string.Format("\n{0}: {1}", friends.GetFriendPersonaName(callback.ChatterID), callback.Message));

            // Variables
            // TODO: Get rank of user and bot here
            string message = callback.Message;
            SteamID userID = callback.ChatterID;
            SteamID chatRoomID = callback.ChatRoomID;
            Settings chatRoom = CR.Single(s => s.ChatID == chatRoomID);

            string name = friends.GetFriendPersonaName(callback.ChatterID);
            string game = friends.GetFriendGamePlayedName(callback.ChatterID);

            // TODO: Fix this
            bool isMod = true;

            // TODO: Spam protection
            // TODO: Cleverbot
            // TODO: Link resolving

            // Always on commands
            if (message == "!leave")
            {
                if (isMod || userID == chatRoom.InvitedID)
                {
                    Log(string.Format("Left {0} with request from {1}", chatRoom.ChatName, name));
                    friends.LeaveChat(chatRoomID);
                }
            }

            // Superadmin commands
            // TODO: actually check for superadmin
            if (message == "!info")
            {
                // Get if we are using Mono
                string runtime;
                if (Type.GetType("Mono.Runtime") != null) runtime = "Mono";
                else runtime = ".NET";
                // Get if system is 32 or 64 bit
                string arch;
                if (Environment.Is64BitOperatingSystem) arch = "x64";
                else arch = "x86";

                // TODO: Maybe use WMI to get more info or find cross platform version of it
                SendChatMessage(chatRoomID, string.Format("\nOS: {0} {1} \nRuntime: {2} {3}", Environment.OSVersion.ToString(), arch, runtime, Environment.Version.ToString()));
            }

            // Admin commands
            if (isMod)
            {
                if (message == "!nodelay")
                {
                    // TODO: Maybe there's a better way to do this?
                    chatRoom.DelayDefine  = 0;
                    chatRoom.DelayGames   = 0;
                    chatRoom.DelayRandom  = 0;
                    chatRoom.DelayRecents = 0;
                    chatRoom.DelayYT      = 0;
                    SendChatMessage(chatRoomID, "All delays reset");
                }
                else if (message.StartsWith("!toggle "))
                {
                    bool state = false;
                    string toggle = message.Split(' ')[1];
                    switch (toggle.ToLower())
                    {
                        case "cleverbot": chatRoom.Cleverbot = state = !chatRoom.Cleverbot; break;
                        case "translate": chatRoom.Translate = state = !chatRoom.Translate; break;
                        case "commands":  chatRoom.Commands  = state = !chatRoom.Commands;  break;
                        case "define":    chatRoom.Define    = state = !chatRoom.Define;    break;
                        case "weather":   chatRoom.Weather   = state = !chatRoom.Weather;   break;
                        case "store":     chatRoom.Store     = state = !chatRoom.Store;     break;
                        case "responses": chatRoom.Responses = state = !chatRoom.Responses; break;
                        case "links":     chatRoom.Links     = state = !chatRoom.Links;     break;
                        case "rules":     chatRoom.Rules     = state = !chatRoom.Rules;     break;
                        case "poke":      chatRoom.Poke      = state = !chatRoom.Poke;      break;

                        // These should have custom messages
                        case "welcome":     chatRoom.Welcome       = state = !chatRoom.Welcome;       break;
                        case "games":       chatRoom.Games         = state = !chatRoom.Games;         break; // !games and !recents
                        case "search":      chatRoom.Search        = state = !chatRoom.Search;        break; // !yt
                        case "autowelcome": chatRoom.AutoWelcome   = state = !chatRoom.AutoWelcome;   break;
                        case "allstates":   chatRoom.AllStates     = state = !chatRoom.AllStates;     break;
                        case "allpoke":     chatRoom.AllPoke       = state = !chatRoom.AllPoke;       break;
                        case "custom":      chatRoom.CustomEnabled = state = !chatRoom.CustomEnabled; break;

                        default: SendChatMessage(chatRoomID, "Unknown toggle"); return;
                    }
                    toggle = toggle.First().ToString().ToUpper() + toggle.Substring(1);
                    if (state)
                        SendChatMessage(chatRoomID, toggle + " is now enabled");
                    else
                        SendChatMessage(chatRoomID, toggle + " is now disabled");
                    // TODO: Save settings here
                }
                else if (message.StartsWith("!setdelay "))
                {
                    string[] set = message.Split(' ');
                    int delay;
                    if (int.TryParse(set[2], out delay))
                    {
                        switch(set[1])
                        {
                            case "define":  chatRoom.DelayDefine  = delay; break;
                            case "games":   chatRoom.DelayGames   = delay; break;
                            case "random":  chatRoom.DelayRandom  = delay; break;
                            case "recents": chatRoom.DelayRecents = delay; break;
                            case "search":  chatRoom.DelaySearch  = delay; break;
                            case "yt":      chatRoom.DelayYT      = delay; break;
                            default: return;
                        }
                        SendChatMessage(chatRoomID, string.Format("Delay of {0} was set to {1} seconds", set[1], set[2]));
                        // TODO: Save settings here
                    }
                    else
                        SendChatMessage(chatRoomID, "Delay needs to be a number (in seconds)");
                }
                else if (message.StartsWith("!set"))
                {
                    string[] set = message.Split(' ');
                    if (set[1] == "spam")
                    {
                        switch(set[2])
                        {
                            case "ban":
                                chatRoom.Spam = "Ban";
                                SendChatMessage(chatRoomID, "Spam will now ban");
                                break;
                            case "kick":
                                chatRoom.Spam = "Kick";
                                SendChatMessage(chatRoomID, "Spam will now kick");
                                break;
                            case "none":
                                chatRoom.Spam = "None";
                                SendChatMessage(chatRoomID, "Spam will now be ignored");
                                break;
                            default:
                                SendChatMessage(chatRoomID, "Unknown spam toggle, use ban, kick or none");
                                break;
                        }
                    }
                    else if (set[1] == "dc")
                    {
                        // We make this a switch in case we want to use warnings later
                        switch (set[2])
                        {
                            case "kick":
                                chatRoom.DCKick = "Kick";
                                SendChatMessage(chatRoomID, "Will now kick user after 5 disconnections");
                                break;
                            case "none":
                                chatRoom.DCKick = "None";
                                SendChatMessage(chatRoomID, "Will now ignore disconnections");
                                break;
                            default:
                                SendChatMessage(chatRoomID, "Unknown dc toggle, use kick or none");
                                break;
                        }
                    }
                }
            }

            // User commands with cooldown / Admin commands
            if (chatRoom.Commands || isMod)
            {
                if (message.StartsWith("!poke "))
                {
                    // TODO: Add function to search for users in a chat
                }
                else if (message.StartsWith("!random"))
                {
                    // TODO: Make this once we can get all users in a chatroom
                }
                else if (message == "!games" && chatRoom.Games)
                {
                    // TODO: Make this once we can enter API keys
                }
                else if (message == "!recents" && chatRoom.Games)
                {
                    // TODO: Same as !games
                }
                else if (message == "!define" && chatRoom.Define)
                {
                    // TODO: Add cooldown

                }
                else if (message.StartsWith("!define"))
                {
                    string response = Get("http://api.urbandictionary.com/v0/define?term=" + message.Substring(8));
                    dynamic result = JsonConvert.DeserializeObject(response);
                    if (result.result_type == "no_results")
                        SendChatMessage(chatRoomID, "No results found");
                    else
                    {
                        string def = result.list[0].definition;
                        def = def.Replace("\n", " ");
                        if (def.Length < 500)
                            SendChatMessage(chatRoomID, string.Format("{0} is {1}", result.list[0].word, def));
                        else
                            SendChatMessage(chatRoomID, string.Format("{0} is {1}...", result.list[0].word, def.Substring(0, 500)));
                        if (isMod)
                        {
                            if (result.list[0].example != null)
                                SendChatMessage(chatRoomID, string.Format("Example: \n{0}", result.list[0].example));

                            double thumbsUp = result.list[0].thumbs_up;
                            double thumbsDown = result.list[0].thumbs_down;
                            double thumbsTotal = thumbsUp + thumbsDown;
                            SendChatMessage(chatRoomID, string.Format("Rating: {0}% positive ({1}/{2})", Math.Round((thumbsUp / thumbsTotal) * 100), thumbsUp, thumbsTotal));
                        }
                    }
                }
                else if (message.StartsWith("!yt ") && chatRoom.Search)
                {
                    // TODO: Same as !games
                }
            }

            // User commands
            if (chatRoom.Commands)
            {
                if (message == "!help")
                    SendChatMessage(chatRoomID, "Check https://github.com/KraXarN/KraxbotOSS/wiki/Commands for all commands and how to use them");
                else if (message == "!bday")
                {
                    // TODO: Make this once we can enter API keys
                }
                else if (message == "!users")
                {
                    // TODO: Make this once we can get all users in a chatroom
                }
                else if (message == "!invited")
                    SendChatMessage(chatRoomID, chatRoom.InvitedName + " invited me to this chat");
                else if (message == "!name")
                {
                    // TODO: Same as !bday
                }
                else if (message == "!ver")
                    SendChatMessage(chatRoomID, string.Format("KraxbotOSS {0} by Kraxie / KraXarN", version));
                else if (message == "!id")
                    SendChatMessage(chatRoomID, string.Format("{0}'s SteamID is {1}", name, userID));
                else if (message == "!chatid")
                    SendChatMessage(chatRoomID, "This chat's SteamID is " + chatRoomID);
                else if (message.StartsWith("!8ball"))
                {
                    string[] words = {
                        "It is certain", "It is decidedly so", "Without a doubt",
                        "Yes definitely", "You may rely on it", "As I see it, yes",
                        "Most likely", "Outlook good", "Yes", "Signs point to yes",
                        "Reply hazy try again", "Ask again later", "Better not tell you now",
                        "Cannot predict now", "Concentrate and ask again", "Do not count on it",
                        "My reply is no", "My sources say no", "Outlook not so good", "Very doubtful"
                    };
                    SendChatMessage(chatRoomID, words[new Random().Next(words.Length)]);
                }
                else if (message == "!time")
                    SendChatMessage(chatRoomID, "Current time is " + DateTime.Now.ToShortTimeString());
                else if (message.StartsWith("!roll"))
                {
                    int max = 100;
                    int.TryParse(message.Split(' ')[1], out max);
                    SendChatMessage(chatRoomID, "Your number is " + new Random().Next(0, max));
                }
                else if (message.StartsWith("!math "))
                    SendChatMessage(chatRoomID, "=" + new DataTable().Compute(message.Substring(6), null).ToString());
                else if (message.StartsWith("!players "))
                {
                    // TODO: Same as !bday
                    // TODO: Also make !players if user is currently playing a game
                }
                else if (message.StartsWith("!weather "))
                {
                    // TODO: Same as !bday
                }
            }
        }

        // -- Other stuffs -- //

        void Log(string text)
        {
            Invoke((MethodInvoker)delegate
            {
                log.AppendText(text);
            });
        }

        void SendChatMessage(SteamID chatRoomID, string message)
        {
            friends.SendChatRoomMessage(chatRoomID, EChatEntryType.ChatMsg, message);
        }
        void SendMessage(SteamID userID, string message)
        {
            friends.SendChatMessage(userID, EChatEntryType.ChatMsg, message);
        }

        void CreateSettings(SteamID ChatRoomID)
        {
            // TODO: This may or may not work lol
            CR.Add(new Settings() { ChatID = ChatRoomID });
        }

        void ToggleSetting(string setting, string name, Settings chatRoom)
        {
            // TODO: Maybe use this?
        }

        string Get(string url)
        {
            // TODO: Check if better way to do this
            // TODO: Handle invalid links
            using (var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
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
        private void btnAdvSettings_Click(object sender, EventArgs e)
        {
            Form advSettings = new FormAdvSettings();
            advSettings.Show();
        }
    }
}
