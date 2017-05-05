using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SteamKit2;
using SteamKit2.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using Cleverbot.Net;
using System.Net;

namespace KraxbotOSS
{
    public partial class Form1 : Form
    {
        // Some variables
        string version = "1.0.1";
        bool running;
        public static string configPath;
        List<Settings> CR = new List<Settings>();
        public static Config config = new Config();
        List<CleverbotUser> CB = new List<CleverbotUser>();

        // Steam variables
        static SteamClient client;
        static CallbackManager manager;
        static SteamUser user;
        static SteamFriends friends;

        public Form1()
        {
            InitializeComponent();

            // Crash handler
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            // Check config dir
            configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrowGames", "KraxbotOSS");
            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(Path.Combine(configPath, "chatrooms"));
                Directory.CreateDirectory(Path.Combine(configPath, "sentryhash"));
            }

            // Check and load config
            if (File.Exists(Path.Combine(configPath, "settings.json")))
            {
                dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(configPath, "settings.json")));
                config.Updates              = json.Updates;
                config.FriendRequest        = json.FriendRequest;
                config.ChatRequest          = json.ChatRequest;
                config.LoginAs              = json.LoginAs;
                config.Superadmin           = json.Superadmin;
                config.Chatrooms            = json.Chatrooms;
                config.API_Steam            = json.API.SteamWeb;
                config.API_Google           = json.API.Google;
                config.API_OpenWeather      = json.API.OpenWeatherMap;
                config.API_CleverbotIO      = json.API.CleverbotIO;
                config.GamePlayed_ID        = json.GamePlayed.ID;
                config.GamePlayed_ExtraInfo = json.GamePlayed.ExtraInfo;
            }

            // Check for updates
            if (config.Updates != "None")
                CheckForUpdates();

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
            manager.Subscribe<SteamFriends.FriendAddedCallback>(OnFriendAdded);       // Someone added us
            manager.Subscribe<SteamFriends.FriendMsgCallback>(OnFriendMsg);           // We got a PM
            manager.Subscribe<SteamFriends.ChatMsgCallback>(OnChatMsg);               // Someone sent a chat message
            manager.Subscribe<SteamFriends.ChatInviteCallback>(OnChatInvite);         // We got invited to a chat
            manager.Subscribe<SteamFriends.ChatEnterCallback>(OnChatEnter);           // We entered a chat
            manager.Subscribe<SteamFriends.ChatMemberInfoCallback>(OnChatMemberInfo); // A user has left or entered a chat
            manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);    // We logged in and can store it
            manager.Subscribe<SteamUser.LoginKeyCallback>(OnLoginKey);                // When we want to save our password
            manager.Subscribe<SteamFriends.FriendsListCallback>(OnFriendsList);       // When we get our friends list

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
        public class Settings
        {
            public List<UserInfo> Users = new List<UserInfo>();
            public List<String> SetRules = new List<String>();

            public int     Version     = 1;
            public string  ChatName    = "NoName";
            public string  InvitedName = "NoName";
            public SteamID ChatID;
            public SteamID InvitedID;

            public string  Spam       = "Kick";
            public string  WelcomeMsg = "Welcome";
            public string  WelcomeEnd = "!";
            public string  DCKick     = "Kick";
            public SteamID LastPoke;

            public bool Cleverbot = false;
            public bool Translate = false;
            public bool Commands  = true;

            public bool Welcome     = true;
            public bool Games       = true;
            public bool Define      = true;
            public bool Wiki        = true;
            public bool Search      = true;
            public bool Weather     = true;
            public bool Store       = true;
            public bool Responses   = true;
            public bool Links       = true;
            public bool Rules       = true;
            public bool Poke        = true;
            public bool AllStates   = false;
            public bool AllPoke     = false;
            public bool AutoWelcome = false;

            public int DCLimit      = 5;
            public int DelayRandom  = 120;
            public int DelayDefine  = 300;
            public int DelayGames   = 120;
            public int DelayRecents = 120;
            public int DelaySearch  = 120;
            public int DelayYT      = 120;

            public int DCKickLimit = 3;
            public int DCBanLimit  = 5;

            public int TimeoutRandom  = 0;
            public int TimeoutDefine  = 0;
            public int TimeoutGames   = 0;
            public int TimeoutRecents = 0;
            public int TimeoutSearch  = 0;
            public int TimeoutYT      = 0;

            public bool   CustomEnabled  = false;
            public bool   CustomModOnly  = false;
            public int    CustomDelay    = 5;
            public string CustomCommand  = "!custom";
            public string CustomResponse = "Custom response";

            public string  AutokickMode = "None";
            public SteamID AutokickUser;

            // We may use these later
            public int SpamSameMessageTimeout = 3000; // Max time when saying the same message
            public int SpamTimeout            = 500;  // Max time when saying different messages
            public int SpamMessageLength      = 400;  // Max length of message
        }

        // User info
        public class UserInfo
        {
            public SteamID         SteamID;
            public EClanPermission Rank;
            public EChatPermission Permission;
            public long            LastTime = 0;
            public string          LastMessage;
            // We may use these later
            public int Disconnect = 0;
            public int Warning    = 0;
        }
        public class CleverbotUser
        {
            public SteamID          SteamID;
            public CleverbotSession Session;
        }

        // Settings
        public class Config
        {
            // For config, we just set default settings at first
            internal string Updates        = "All";
            internal string FriendRequest  = "AcceptAll";
            internal string ChatRequest    = "AcceptAll";
            internal EPersonaState LoginAs = EPersonaState.Online;
            internal uint Superadmin;
            internal JArray Chatrooms      = new JArray();

            internal string API_Steam;
            internal string API_Google;
            internal string API_OpenWeather;
            internal string API_CleverbotIO;

            internal ulong  GamePlayed_ID;
            internal string GamePlayed_ExtraInfo;
        }

        // -- Steam callbacks -- //

        void OnConnected(SteamClient.ConnectedCallback callback)
        {
            // TODO: Handle this better or something
            if (callback.Result != EResult.OK)
            {
                MessageBox.Show("Error connecting to Steam, try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                running = false;
                Close();
                return;
            }
            Log("Ok");
            if (File.Exists(Path.Combine(configPath, "user")))
            {
                Invoke((MethodInvoker)delegate
                {
                    lNetwork.Text = "Network: Connected";
                });
                string[] user = File.ReadAllLines(Path.Combine(configPath, "user"));
                FormLogin.Username = user[0];
                Login(user[0]);
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    btnLogin.Enabled = true;
                    lNetwork.Text = "Network: Connected";
                });
            }
        }
        void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // TODO: Only show the message once
            Log("\nDisconnected, attempting to reconnect... ");
            Invoke((MethodInvoker)delegate
            {
                lNetwork.Text = "Network: Disconnected";
            });
            client.Connect();
        }
        void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                if (callback.Result == EResult.AccountLogonDenied)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        FormLogin login = new FormLogin("NeedGuard");
                        // If we use ShowDialog here, we get disconencted and can't login
                        login.Show(this);
                    });
                }
                else if (callback.Result == EResult.AccountLoginDeniedNeedTwoFactor)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        FormLogin login = new FormLogin("NeedTwoFactor");
                        // If we use ShowDialog here, we get disconencted and can't login
                        login.Show(this);
                    });
                }
                else if (callback.Result == EResult.InvalidPassword && string.IsNullOrEmpty(FormLogin.Password))
                {
                    File.Delete(Path.Combine(configPath, "loginkey"));
                    File.Delete(Path.Combine(configPath, "user"));
                    MessageBox.Show("Your saved login seems to be invalid, so it was removed.\nTry logging in again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (callback.Result != EResult.TryAnotherCM)
                    MessageBox.Show("Unable to login to Steam: " + callback.Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Log("\nLogged in");
            Invoke((MethodInvoker)delegate
            {
                btnLogin.Hide();
                btnBotSettings.Enabled = true;
                lStatus.Text = "State: Logged in";
            });

            // To other stuff here after logging in (like joining chatrooms)
        }
        void OnLoginKey(SteamUser.LoginKeyCallback callback)
        {
            File.WriteAllText(Path.Combine(configPath, "loginkey"), callback.LoginKey);
            user.AcceptNewLoginKey(callback);
        }
        void OnAccountInfo(SteamUser.AccountInfoCallback callback)
        {
            friends.SetPersonaState(config.LoginAs);
        }
        void OnFriendsList(SteamFriends.FriendsListCallback callback)
        {
            // Join chatrooms
            if (config.Chatrooms != null)
            {
                foreach (SteamID groupID in GetGroups())
                    if (config.Chatrooms.ToString().IndexOf(groupID.AccountID.ToString()) > -1)
                        friends.JoinChat(groupID);
            }

            // Start game
            PlayGame(config.GamePlayed_ID, config.GamePlayed_ExtraInfo);
        }
        void OnFriendAdded(SteamFriends.FriendAddedCallback callback)
        {
            if (config.FriendRequest == "AcceptAll")
                Log(callback.PersonaName + " is now my friend");
        }
        void OnChatInvite(SteamFriends.ChatInviteCallback callback)
        {
            Log(string.Format("\nGot invite to {0} from {1}", callback.ChatRoomName, friends.GetFriendPersonaName(callback.PatronID)));
            
            if (config.ChatRequest == "AcceptAll")
                friends.JoinChat(callback.ChatRoomID);
            else if (config.ChatRequest == "SuperadminOnly" && callback.InvitedID.AccountID == config.Superadmin)
                friends.JoinChat(callback.ChatRoomID);
        }
        void OnChatEnter(SteamFriends.ChatEnterCallback callback)
        {
            SteamFriends.ChatMemberInfo bot = callback.ChatMembers.Single(s => s.SteamID == client.SteamID);
            Log(string.Format("\nJoined {0} as {1}", callback.ChatRoomName, bot.Details));

            // Add to chatrooms list
            Invoke((MethodInvoker)delegate
            {
                lbChatrooms.Items.Add(callback.ChatRoomName);
            });

            // Create settings if needed
            if (File.Exists(Path.Combine(configPath, "chatrooms", callback.ChatID.ConvertToUInt64().ToString() + ".json")))
                LoadSettings(callback.ChatID);
            else
                CreateSettings(callback.ChatID, callback.ChatRoomName, callback.FriendID.AccountID, friends.GetFriendPersonaName(callback.FriendID));
            Settings chatRoom = CR.Single(s => s.ChatID == callback.ChatID);

            // Check if we have permission to kick
            if (!CheckPermission("kick", chatRoom.Users.Single(s => s.SteamID == client.SteamID).Permission))
                chatRoom.Spam = "None";

            // Add all current users to the Users list
            chatRoom.Users.Clear();
            foreach (SteamFriends.ChatMemberInfo member in callback.ChatMembers)
            {
                chatRoom.Users.Add(new UserInfo() {
                    SteamID = member.SteamID,
                    Rank = member.Details,
                    Permission = member.Permissions
                });
            }

            // Then save settings
            SaveSettings(chatRoom);
        }
        void OnChatMemberInfo(SteamFriends.ChatMemberInfoCallback callback)
        {
            // Vars
            Settings chatRoom = CR.Single(s => s.ChatID == callback.ChatRoomID);
            SteamID chatRoomID = callback.ChatRoomID;
            EChatMemberStateChange state = callback.StateChangeInfo.StateChange;
            string name = friends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn);

            // When a user enters or leaves a chat
            Log(string.Format("\n[{0}] {1} {2}", chatRoom.ChatName.Substring(0, 3), friends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn), callback.StateChangeInfo.StateChange));

            // Add or remove user from Users list
            if (state == EChatMemberStateChange.Entered)
            {
                chatRoom.Users.Add(new UserInfo()
                {
                    SteamID    = callback.StateChangeInfo.MemberInfo.SteamID,
                    Permission = callback.StateChangeInfo.MemberInfo.Permissions,
                    Rank       = callback.StateChangeInfo.MemberInfo.Details
                });
                if (chatRoom.Welcome)
                    SendChatMessage(chatRoomID, string.Format("{0} {1}{2}", chatRoom.WelcomeMsg, name, chatRoom.WelcomeEnd));
            }
            else if (state == EChatMemberStateChange.Left)
            {
                chatRoom.Users.Remove(chatRoom.Users.Single(s => s.SteamID == callback.StateChangeInfo.ChatterActedOn));
                if (chatRoom.AllStates)
                    SendChatMessage(chatRoomID, string.Format("Good bye {0}{1}", name, chatRoom.WelcomeEnd));
            }
        }
        void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            Log("\nLogged out");
        }
        void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            // Writes sentry file
            int fileSize;
            byte[] sentryHash;
            using (var fs = File.Open(Path.Combine(configPath, "sentryhash", FormLogin.Username + ".bin"), FileMode.OpenOrCreate, FileAccess.ReadWrite))
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
            string message = callback.Message;
            SteamID userID = callback.Sender;
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                Log(string.Format("\n{0}: {1}", friends.GetFriendPersonaName(callback.Sender), message));

                // Check if we have a Cleverbot session
                if (!CB.Exists(x => x.SteamID == userID))
                {
                    Log(string.Format("\nNo Cleverbot session for {0}", friends.GetFriendPersonaName(userID)));
                    string[] apikey = config.API_CleverbotIO.Split(';');
                    CB.Add(new CleverbotUser()
                    {
                        SteamID = userID,
                        Session = CleverbotSession.NewSession(apikey[0], apikey[1])
                    });
                }
                // Use Cleverbot
                CleverbotSession session = CB.Single(s => s.SteamID == userID).Session;
                try
                { SendMessage(userID, session.Send(message)); }
                catch (Exception e)
                { Log("\n" + e.Message); }
            }
        }
        void OnChatMsg(SteamFriends.ChatMsgCallback callback)
        {
            // TODO: Log this different than friend messages
            // TODO: Does this assume we are friends with the user?
            Log(string.Format("\n{0}: {1}", friends.GetFriendPersonaName(callback.ChatterID), callback.Message));

            // Variables
            string   message    = callback.Message;
            SteamID  userID     = callback.ChatterID;
            SteamID  chatRoomID = callback.ChatRoomID;
            Settings chatRoom   = CR.Single(s => s.ChatID == chatRoomID);
            UserInfo chatter    = chatRoom.Users.Single(s => s.SteamID == userID);
            UserInfo bot        = chatRoom.Users.Single(s => s.SteamID == client.SteamID);
            long     now        = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            int      timeout    = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string name = friends.GetFriendPersonaName(callback.ChatterID);
            string game = friends.GetFriendGamePlayedName(callback.ChatterID);

            // Check if mod
            bool isMod = false;
            switch(chatter.Rank)
            {
                case EClanPermission.Moderator:
                case EClanPermission.Officer:
                case EClanPermission.Owner:
                    isMod = true;
                    break;
            }

            // Always treat Superadmin as mod
            if (userID.AccountID == config.Superadmin) isMod = true;

            // Check if bot is mod
            bool isBotMod = false;
            switch(bot.Rank)
            {
                case EClanPermission.Moderator:
                case EClanPermission.Officer:
                case EClanPermission.Owner:
                    isBotMod = true;
                    break;
            }

            // Spam protection
            if (isBotMod && !isMod && chatRoom.Spam != "None")
            {
                if (chatter.LastMessage == message && chatter.LastTime + 3000 > now)
                {
                    // Sent the same message within the same 3 seconds
                    SendChatMessage(chatRoomID, string.Format("Please {0}, don't spam", name));
                    if (chatRoom.Spam == "Kick")
                        friends.KickChatMember(chatRoomID, userID);
                    else if (chatRoom.Spam == "Ban")
                        friends.BanChatMember(chatRoomID, userID);
                }
                else if (chatter.LastTime + 500 > now)
                {
                    // Sent a mesage within the same 0.5 seconds
                    SendChatMessage(chatRoomID, string.Format("Please {0}, don't post too fast", name));
                    if (chatRoom.Spam == "Kick")
                        friends.KickChatMember(chatRoomID, userID);
                    else if (chatRoom.Spam == "Ban")
                        friends.BanChatMember(chatRoomID, userID);
                }
                else if (message.Length > 400)
                {
                    // Sent a message longer than 400 characters
                    SendChatMessage(chatRoomID, string.Format("Please {0}, don't post too long messages", name));
                    if (chatRoom.Spam == "Kick")
                        friends.KickChatMember(chatRoomID, userID);
                    else if (chatRoom.Spam == "Ban")
                        friends.BanChatMember(chatRoomID, userID);
                }
            }
            chatter.LastMessage = message;
            chatter.LastTime = now;

            // Link resolving
            if (chatRoom.Links)
            {
                string[] links = message.Split(' ');
                for(int i = 0; i < links.Length;  i++)
                {
                    if (links[i].StartsWith("http"))
                    {
                        string response = Get(links[i]);
                        if (!string.IsNullOrEmpty(response))
                        {
                            if (response.IndexOf("<title") > -1 && response.IndexOf("</title>") > -1)
                            {
                                string title = GetStringBetween(GetStringBetween(response, "<title", "</title"), ">");
                                if (title.IndexOf("YouTube") > -1)
                                {
                                    // Youtube
                                    if (string.IsNullOrEmpty(config.API_Google))
                                    {
                                        string video = title.Substring(0, title.LastIndexOf("- YouTube"));
                                        SendChatMessage(chatRoomID, string.Format("{0} posted a video: {1}", name, video));
                                    }
                                    else
                                    {
                                        string videoID = null;
                                        if (links[i].StartsWith("https://youtu.be/"))
                                            videoID = links[i].Substring(17, 11);
                                        else
                                            videoID = links[i].Substring(32, 11);
                                        if (!string.IsNullOrEmpty(videoID))
                                        {
                                            dynamic info = JsonConvert.DeserializeObject(Get("https://www.googleapis.com/youtube/v3/videos?id=" + videoID + "&key=" + config.API_Google + "&part=statistics,snippet,contentDetails"));
                                            dynamic video = info.items[0];
                                            TimeSpan time = System.Xml.XmlConvert.ToTimeSpan(video.contentDetails.duration.ToString());
                                            string duration = time.Minutes + ":" + time.Seconds;
                                            SendChatMessage(chatRoomID, string.Format("{0} posted a video: {1} by {2} with {3} views, lasting {4}", name, video.snippet.title, video.snippet.channelTitle, video.statistics.viewCount.ToString(), duration));
                                        }
                                    }
                                }
                                else if (title.IndexOf("on Steam") > -1)
                                    SendChatMessage(chatRoomID, string.Format("{0} posted a game: {1}", name, GetStringBetween(title, "", "on Steam")));
                                else if (title.IndexOf("Steam Community :: Screenshot") > -1)
                                    SendChatMessage(chatRoomID, string.Format("{0} posted a screenshot from {1}", name, GetStringBetween(response, "This item is incompatible with ", ". Please see the")));
                                else if (title.IndexOf("Item Inventory") < 0)
                                    SendChatMessage(chatRoomID, string.Format("{0} posted {1}", name, title.Trim()));
                            }
                        }
                    }
                }
            }

            // Cleverbot
            if (message.StartsWith("."))
            {
                // Check if we have a Cleverbot session
                if (!CB.Exists(x => x.SteamID == chatRoomID))
                {
                    Log(string.Format("\nNo Cleverbot session for {0}", chatRoom.ChatName));
                    string[] apikey = config.API_CleverbotIO.Split(';');
                    CB.Add(new CleverbotUser()
                    {
                        SteamID = chatRoomID,
                        Session = CleverbotSession.NewSession(apikey[0], apikey[1])
                    });
                }
                // Use Cleverbot
                CleverbotSession session = CB.Single(s => s.SteamID == chatRoomID).Session;
                try
                { SendChatMessage(chatRoomID, session.Send(message)); }
                catch (Exception e)
                { Log("\n" + e.Message); }
            }

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
            if (userID.AccountID == config.Superadmin)
            {
                if (message == "!timestamp")
                    SendChatMessage(chatRoomID, string.Format("Current timestamp: {0}", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()));
                else if (message.StartsWith("!permission"))
                    SendChatMessage(chatRoomID, CheckPermission(message.Split()[1], bot.Permission).ToString());
                else if (message == "!info")
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
            }

            // Admin commands
            if (isMod)
            {
                if (message == "!nodelay")
                {
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
                    SaveSettings(chatRoom);
                }
                else if (message.StartsWith("!setdelay "))
                {
                    string[] set = message.Split(' ');
                    if (int.TryParse(set[2], out int delay))
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
                        SaveSettings(chatRoom);
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
                                if (CheckPermission("ban", bot.Permission))
                                {
                                    chatRoom.Spam = "Ban";
                                    SendChatMessage(chatRoomID, "Spam will now ban");
                                }
                                else
                                    SendChatMessage(chatRoomID, "I don't have permission to ban users");
                                break;
                            case "kick":
                                if (CheckPermission("kick", bot.Permission))
                                {
                                    chatRoom.Spam = "Kick";
                                    SendChatMessage(chatRoomID, "Spam will now kick");
                                }
                                else
                                    SendChatMessage(chatRoomID, "I don't have permission to kick users");
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
                else if (message.StartsWith("!rule "))
                {
                    switch(message.Split(' ')[1])
                    {
                        case "add":
                            // Add rule
                            chatRoom.SetRules.Add(message.Substring(10));
                            if (chatRoom.Rules) SendChatMessage(chatRoomID, "Rule added");
                            else SendChatMessage(chatRoomID, "Rule added, but rules are disabled");
                            break;
                        case "remove":
                            // Remove rule
                            string search = message.Substring(13).ToLower();
                            List<string> results = chatRoom.SetRules.FindAll(s => s.ToLower().Contains(search));
                            if (results.Count == 0)
                                SendChatMessage(chatRoomID, "No rule matching your search was found");
                            else if (results.Count > 1)
                                SendChatMessage(chatRoomID, "Multiple rules matching your search was found");
                            else
                            {
                                chatRoom.SetRules.Remove(chatRoom.SetRules.Single(s => s.ToLower().Contains(search)));
                                SendChatMessage(chatRoomID, "Rule removed");
                            }
                            break;
                        case "cls":
                        case "clear":
                            // Clear all rules
                            chatRoom.SetRules.Clear();
                            SendChatMessage(chatRoomID, "All rules removed");
                            break;
                        default:
                            SendChatMessage(chatRoomID, "Invalid argument, use add, remove or clear");
                            break;
                    }
                    SaveSettings(chatRoom);
                }
            }

            // User commands with cooldown / Admin commands
            if (chatRoom.Commands || isMod)
            {
                if (message.StartsWith("!poke "))
                {
                    if (isMod || chatRoom.AllPoke)
                    {
                        string search = message.Substring(6);
                        List<SteamID> results = new List<SteamID>();
                        foreach (UserInfo user in chatRoom.Users)
                            if (friends.GetFriendPersonaName(user.SteamID).ToLower().IndexOf(search.ToLower()) > -1)
                                results.Add(user.SteamID);

                        if (results.Count > 1)
                            SendChatMessage(chatRoomID, "Found multiple users, try to be more specific");
                        else if (results.Count == 0)
                            SendChatMessage(chatRoomID, "No user found");
                        else if (results[0] == chatRoom.LastPoke)
                            SendChatMessage(chatRoomID, "You have already poked that user");
                        else if (results[0] == client.SteamID)
                            SendChatMessage(chatRoomID, "Poked myself, *poke*");
                        else
                        {
                            SendMessage(results[0], string.Format("Hey you! {0} poked you in {1}", friends.GetFriendPersonaName(userID), chatRoom.ChatName));
                            SendChatMessage(chatRoomID, string.Format("Poked {0}", friends.GetFriendPersonaName(results[0])));
                            chatRoom.LastPoke = userID;
                        }
                    }
                }
                else if (message.StartsWith("!random"))
                {
                    if (isMod || chatRoom.TimeoutRandom < timeout)
                    {
                        List<UserInfo> users = new List<UserInfo>(chatRoom.Users);
                        users.Remove(users.Single(s => s.SteamID == client.SteamID));
                        SendChatMessage(chatRoomID, string.Format("The winner is {0}!", friends.GetFriendPersonaName(users[new Random().Next(users.Count)].SteamID)));
                        chatRoom.TimeoutRandom = timeout + chatRoom.DelayRandom;
                    }
                    else
                        SendChatMessage(chatRoomID, string.Format("This command is disabled for {0}", FormatTime(chatRoom.TimeoutRandom)));
                }
                else if (message == "!games" && chatRoom.Games)
                {
                    if (string.IsNullOrEmpty(config.API_Steam))
                        SendChatMessage(chatRoomID, "Steam API isn't set up properly to use this command");
                    else if (isMod || chatRoom.TimeoutGames < timeout)
                    {
                        string response = Get("http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" + config.API_Steam + "&include_appinfo=1&include_played_free_games=1&steamid=" + userID.ConvertToUInt64());
                        if (!string.IsNullOrEmpty(response))
                        {
                            dynamic result = JsonConvert.DeserializeObject(response);
                            SendChatMessage(chatRoomID, string.Format("You have {0} games", result.response.game_count));
                            JArray array = result.response.games;
                            JArray games = new JArray(array.OrderByDescending(obj => obj["playtime_forever"]));
                            for (int i = 0; i <= 4; i++)
                                SendChatMessage(chatRoomID, string.Format("{0}: {1} ({2} hours played)", i + 1, games[i]["name"], Math.Round((double)games[i]["playtime_forever"] / 60)));
                        }
                        else
                            SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                        chatRoom.TimeoutGames = timeout + chatRoom.DelayGames;
                    }
                    else
                        SendChatMessage(chatRoomID, string.Format("This command is disabled for {0}", FormatTime(chatRoom.TimeoutGames - timeout)));
                }
                else if (message == "!recents" && chatRoom.Games)
                {
                    if (string.IsNullOrEmpty(config.API_Steam))
                        SendChatMessage(chatRoomID, "Steam API isn't set up properly to use this command");
                    else if (isMod || chatRoom.TimeoutRecents < timeout)
                    {
                        string response = Get("http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=" + config.API_Steam + "&steamid=" + userID.ConvertToUInt64());
                        if (string.IsNullOrEmpty(response))
                            SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                        else
                        {
                            dynamic result = JsonConvert.DeserializeObject(response);
                            SendChatMessage(chatRoomID, string.Format("You have played {0} games recently", result.response.total_count));
                            JArray array = result.response.games;
                            JArray games = new JArray(array.OrderByDescending(obj => obj["playtime_2weeks"]));
                            int total = 5;
                            if (games.Count < 5) total = games.Count;
                            for (int i = 0; i < total; i++)
                            {
                                int playtime = (int)Math.Round((double)games[i]["playtime_2weeks"] / 60);
                                if (playtime == 1)
                                    SendChatMessage(chatRoomID, string.Format("{0}: {1} (1 hour played recently)", i+1, games[i]["name"]));
                                else
                                    SendChatMessage(chatRoomID, string.Format("{0}: {1} ({2} hours played recently)", i + 1, games[i]["name"], playtime));
                            }
                        }
                        chatRoom.TimeoutRecents = timeout + chatRoom.DelayRecents;
                    }
                    else
                        SendChatMessage(chatRoomID, string.Format("This command is disabled for {0}", FormatTime(chatRoom.TimeoutRecents - timeout)));
                }
                else if (message.StartsWith("!define ") && chatRoom.Define)
                {
                    if (isMod || chatRoom.TimeoutDefine < timeout)
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
                                SendChatMessage(chatRoomID, string.Format("{1}", result.list[0].word, def));
                            else
                                SendChatMessage(chatRoomID, string.Format("{1}...", result.list[0].word, def.Substring(0, 500)));
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
                        chatRoom.TimeoutDefine = timeout + chatRoom.DelayDefine;
                    }
                    else
                        SendChatMessage(chatRoomID, string.Format("This command is disabled for {0}", FormatTime(chatRoom.TimeoutDefine - timeout)));
                }
                else if (message.StartsWith("!yt ") && chatRoom.Search)
                {
                    if (isMod || chatRoom.TimeoutYT < timeout)
                    {
                        if (string.IsNullOrEmpty(config.API_Google))
                            SendChatMessage(chatRoomID, "Google API isn't set up properly to use this command");
                        else
                        {
                            dynamic result = JsonConvert.DeserializeObject(Get("https://www.googleapis.com/youtube/v3/search?part=snippet&q=" + message.Substring(4) + "&type=video&key=" + config.API_Google));
                            if (string.IsNullOrEmpty(result.items[0].snippet.ToString()))
                                SendChatMessage(chatRoomID, "No results found");
                            else
                            {
                                string results = null;
                                int limit = 1;
                                if (isMod) limit = 3;
                                for (int i = 0; i < limit; i++)
                                    if (!string.IsNullOrEmpty(result.items[i].ToString()))
                                        results += string.Format("\n{0} ({1}): https://youtu.be/{2}", result.items[i].snippet.title, result.items[i].snippet.channelTitle, result.items[i].id.videoId);
                                SendChatMessage(chatRoomID, "Results: " + results);
                            }
                        }
                        chatRoom.TimeoutYT = timeout + chatRoom.DelayYT;
                    }
                    else
                        SendChatMessage(chatRoomID, string.Format("This command is disabled for {0}", FormatTime(chatRoom.TimeoutYT - timeout)));
                }
            }

            // User commands
            if (chatRoom.Commands)
            {
                if (message == "!help")
                    SendChatMessage(chatRoomID, "Check https://github.com/KraXarN/KraxbotOSS/wiki/Commands for all commands and how to use them");
                else if (message == "!bday")
                {
                    if (string.IsNullOrEmpty(config.API_Steam))
                        SendChatMessage(chatRoomID, "Steam API isn't set up properly to use this command");
                    else
                    {
                        string response = Get("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + config.API_Steam + "&steamids=" + userID.ConvertToUInt64());
                        if (string.IsNullOrEmpty(response))
                            SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                        else
                        {
                            dynamic result = JsonConvert.DeserializeObject(response);
                            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                            date = date.AddSeconds(long.Parse(result.response.players[0].timecreated.ToString()));
                            DateTime curDate = DateTime.UtcNow;
                            if ((curDate.Year - date.Year) == 1)
                                SendChatMessage(chatRoomID, string.Format("{0}'s Steam birthday is {1}{2} of {3} (Account created {4} and 1 year old)", name, date.Day, GetDateSuffix(date.Day), date.ToString("MMMM"), date.Year));
                            else
                                SendChatMessage(chatRoomID, string.Format("{0}'s Steam birthday is {1}{2} of {3} (Account created {4} and {5} years old)", name, date.Day, GetDateSuffix(date.Day), date.ToString("MMMM"), date.Year, curDate.Year - date.Year));
                        }
                    }
                }
                else if (message == "!users")
                {
                    int nobodies, members, mods, officers;
                    nobodies = members = mods = officers = 0;
                    string owner = "no ";
                    foreach (UserInfo user in chatRoom.Users)
                    {
                        switch (user.Rank)
                        {
                            case EClanPermission.Nobody:    nobodies++;   break;
                            case EClanPermission.Member:    members++;    break;
                            case EClanPermission.Moderator: mods++;       break;
                            case EClanPermission.Officer:   officers++;   break;
                            case EClanPermission.Owner:     owner = null; break;
                        }
                    }
                    string users = null;
                    if (nobodies != 0) users += (nobodies + " are guests, ");
                    if (members != 0)  users += (members  + " are users, " );
                    if (mods != 0)     users += (mods     + " are mods, "  );
                    if (officers != 0) users += (officers + " are admins, ");
                    SendChatMessage(chatRoomID, string.Format("{0} people are in this chat, where {1} and {2}owner", chatRoom.Users.Count, users.Substring(0, users.Length - 2), owner));
                }
                else if (message == "!invited")
                    SendChatMessage(chatRoomID, chatRoom.InvitedName + " invited me to this chat");
                else if (message == "!name")
                {
                    string chatr = chatter.Rank.ToString();
                    if (string.IsNullOrEmpty(game))
                        SendChatMessage(chatRoomID, string.Format("{0} ({1})", name, chatr));
                    else
                        SendChatMessage(chatRoomID, string.Format("{0} playing {1} ({2})", name, game, chatr));
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
                    #pragma warning disable IDE0018
                    int max = 100;
                    #pragma warning restore IDE0018
                    int.TryParse(message.Split(' ')[1], out max);
                    SendChatMessage(chatRoomID, "Your number is " + new Random().Next(0, max));
                }
                else if (message.StartsWith("!math "))
                    SendChatMessage(chatRoomID, "= " + new DataTable().Compute(message.Substring(6), null).ToString());
                else if (message.StartsWith("!players "))
                {
                    // TODO: Collect all results in a list and choose the value with most players
                    string app = message.Substring(9);
                    string response = Get("http://api.steampowered.com/ISteamApps/GetAppList/v2");
                    if (string.IsNullOrEmpty(response))
                        SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                    else
                    {
                        dynamic result = JsonConvert.DeserializeObject(response);
                        string gameName = null;
                        int playerCount = 0;
                        foreach (dynamic value in result.applist.apps)
                        {
                            if (value.name.ToString().ToLower().IndexOf(app.ToLower()) > -1)
                            {
                                gameName = value.name;
                                playerCount = JsonConvert.DeserializeObject(Get("http://api.steampowered.com/ISteamUserStats/GetNumberOfCurrentPlayers/v1/?appid=" + value.appid)).response.player_count;
                                if (playerCount > 0) break;
                            }
                        }
                        if (string.IsNullOrEmpty(gameName))
                            SendChatMessage(chatRoomID, "No results found");
                        else
                            SendChatMessage(chatRoomID, string.Format("There are currently {0} people playing {1}", playerCount, gameName));
                    }
                }
                else if (message == "!players")
                {
                    uint appID = friends.GetFriendGamePlayed(userID).AppID;
                    if (appID == 0)
                        SendChatMessage(chatRoomID, "You need to either play a game or specify a game to check players");
                    else
                    {
                        string response = Get("http://api.steampowered.com/ISteamUserStats/GetNumberOfCurrentPlayers/v1/?appid=" + appID);
                        if (string.IsNullOrEmpty(response))
                            SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                        else
                        {
                            dynamic result = JsonConvert.DeserializeObject(response);
                            SendChatMessage(chatRoomID, string.Format("There are currently {0} people playing {1}", result.response.player_count, game));
                        }
                    }

                    SendChatMessage(chatRoomID, friends.GetFriendGamePlayed(userID));
                }
                else if (message.StartsWith("!weather ") && chatRoom.Weather)
                {
                    if (string.IsNullOrEmpty(config.API_OpenWeather))
                        SendChatMessage(chatRoomID, "Weather API isn't set up properly to use this command");
                    else
                    {
                        dynamic result = JsonConvert.DeserializeObject(Get("http://api.openweathermap.org/data/2.5/weather?units=metric&appid=" + config.API_OpenWeather + "&q=" + message.Substring(9)));
                        if (!string.IsNullOrEmpty(result.message))
                            SendChatMessage(chatRoomID, result.message);
                        else
                        {
                            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(long.Parse(result.dt.ToString()));
                            SendChatMessage(chatRoomID, string.Format("The weather in {0} is {1}, {2}ºC with wind at {3} m/s and {4}% clouds (Updated {5}:{6})", result.name, result.weather[0].main, Math.Round(double.Parse(result.main.temp.ToString())), Math.Round(double.Parse(result.wind.speed.ToString())), result.clouds.all, date.Hour, date.Minute));
                        }
                    }
                }
                else if (message.StartsWith("!convert "))
                {
                    dynamic result = JsonConvert.DeserializeObject(Get("http://api.duckduckgo.com/?format=json&q=" + message.Substring(9)));
                    if (string.IsNullOrEmpty(result.Answer.ToString()))
                        SendChatMessage(chatRoomID, "No answer found");
                    else
                        SendChatMessage(chatRoomID, result.Answer.ToString());
                }
                else if (message == "!rules" && chatRoom.Rules)
                {
                    if (chatRoom.SetRules.Count == 0)
                        SendChatMessage(chatRoomID, "No rules found, use !rule to add some");
                    else
                    {
                        int count = 1;
                        foreach (string rule in chatRoom.SetRules)
                        {
                            SendChatMessage(chatRoomID, string.Format("{0}: {1}", count, rule));
                            count++;
                        }
                    }
                }
            }
        }

        // -- Steam functions -- //

        public static void Login(string username, string password, bool rememberPassword, string authCode = null, string twoFactorCode = null)
        {
            bool isUsernameNull = string.IsNullOrEmpty(username);
            bool isPasswordNull = string.IsNullOrEmpty(password);
            if ((isUsernameNull && isPasswordNull) || (isUsernameNull || isPasswordNull))
                return;

            // Use sentry hash if we have one
            byte[] sentryHash = null;
            if (File.Exists(Path.Combine(configPath, "sentryhash", username + ".bin")))
                sentryHash = CryptoHelper.SHAHash(File.ReadAllBytes(Path.Combine(configPath, "sentryhash", username + ".bin")));

            user.LogOn(new SteamUser.LogOnDetails
            {
                Username = username,
                Password = password,
                SentryFileHash = sentryHash,
                ShouldRememberPassword = rememberPassword,
                AuthCode = authCode,
                TwoFactorCode = twoFactorCode
            });
        }
        public static void Login(string username)
        {
            // Use sentry hash if we have one
            byte[] sentryHash = null;
            if (File.Exists(Path.Combine(configPath, "sentryhash", username + ".bin")))
                sentryHash = CryptoHelper.SHAHash(File.ReadAllBytes(Path.Combine(configPath, "sentryhash", username + ".bin")));

            // Get our login key
            string loginkey = null;
            if (File.Exists(Path.Combine(configPath, "loginkey")))
                loginkey = File.ReadAllText(Path.Combine(configPath, "loginkey"));

            user.LogOn(new SteamUser.LogOnDetails
            {
                Username = username,
                ShouldRememberPassword = true,
                LoginKey = loginkey,
                SentryFileHash = sentryHash
            });
        }
        public static void UpdateBotSetttings(string name, EPersonaState state)
        {
            friends.SetPersonaName(name);
            friends.SetPersonaState(state);
        }

        public static List<SteamID> GetGroups()
        {
            List<SteamID> groups = new List<SteamID>();
            for (int i = 0; i < friends.GetClanCount(); i++)
                groups.Add(friends.GetClanByIndex(i));
            return groups;
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
        public static string GetGroupName(SteamID clanID)
        {
            return friends.GetClanName(clanID);
        }
        public static void PlayGame(ulong gameID, string gameExtraInfo)
        {
            var playGame = new ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);
            playGame.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
            {
                game_id = gameID,
                game_extra_info = gameExtraInfo

            });
            client.Send(playGame);
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

        void CreateSettings(SteamID ChatRoomID, string ChatRoomName, SteamID InvitedID, string InvitedName)
        {
            CR.Add(new Settings() {
                ChatID = ChatRoomID,
                ChatName = ChatRoomName,
                InvitedID = InvitedID,
                InvitedName = InvitedName
            });
        }
        void SaveSettings(Settings setting)
        {
            string file = Path.Combine(configPath, "chatrooms", setting.ChatID.ConvertToUInt64().ToString() + ".json");
            File.WriteAllText(file, JsonConvert.SerializeObject(setting, Formatting.Indented));
        }
        void LoadSettings(SteamID chatRoomID)
        {
            string file = File.ReadAllText(Path.Combine(configPath, "chatrooms", chatRoomID.ConvertToUInt64().ToString() + ".json"));
            CR.Add(JsonConvert.DeserializeObject<Settings>(file));
        }

        bool CheckPermission(string check, EChatPermission permission)
        {
            // TODO: Not actually sure if this is how it works
            if (check == "kick")
            {
                if ((permission & EChatPermission.Kick) == EChatPermission.Kick) return true;
                else return false;
            }
            else if (check == "ban")
            {
                if ((permission & EChatPermission.Ban) == EChatPermission.Ban) return true;
                else return false;
            }
            else return false;
        }

        string Get(string url)
        {
            // TODO: Check if better way to do this
            using (var client = new WebClient())
            {
                try {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:54.0) Gecko/20100101 Firefox/54.0");
                    return client.DownloadString(url);
                } catch (WebException e) {
                    MessageBox.Show(e.StackTrace);
                    return null;
                }
            }
        }

        string EncryptDecrypt(string input, string key)
        {
            char[] cKey = key.ToCharArray();
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
                output[i] = (char)(input[i] ^ cKey[i % cKey.Length]);
            return new string(output);
        }
        string GetDateSuffix(int day)
        {
            if (day % 10 == 1 && day != 11) return "st";
            else if (day % 10 == 2 && day != 12) return "nd";
            else if (day % 10 == 3 && day != 13) return "rd";
            else return "th";
        }

        void CheckForUpdates()
        {
            string response = Get("https://api.github.com/repos/KraXarN/KraxbotOSS/releases");
            if (string.IsNullOrEmpty(response)) return;
            dynamic result = JsonConvert.DeserializeObject(response);
            string newVersion = result[0].tag_name;
            newVersion = newVersion.Substring(1);
            if (version != newVersion)
            {
                if (MessageBox.Show(string.Format("Current version is {0} \nNew Version is {1} \nDo you want to update now?", version, newVersion), "New Update Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start("https://github.com/KraXarN/KraxbotOSS/releases");
            }
        }

        string GetStringBetween(string token, string first, string second = null)
        {
            int from = token.IndexOf(first) + first.Length;
            if (!string.IsNullOrEmpty(second))
            {
                int to = token.IndexOf(second);
                return token.Substring(from, to - from);
            }
            else
                return token.Substring(from);
        }
        string FormatTime(int seconds)
        {
            int min = (int)(Math.Floor(seconds / 60.0));
            int sec = (seconds - (min * 60));
            if (sec < 10)
                return string.Format("{0}:0{1}", min, sec);
            else
                return string.Format("{0}:{1}", min, sec);
        }

        // -- Buttons and ui stuff -- //

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Hide the main form and show the settings form
            //this.Hide();
            Form settings = new FormSettings();
            settings.ShowDialog(this);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(configPath, "user")))
            {
                string[] user = File.ReadAllLines(Path.Combine(configPath, "user"));
                FormLogin.Username = user[0];
                Login(user[0]);
            }
            else
            {
                Form login = new FormLogin();
                login.ShowDialog(this);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            Environment.Exit(Environment.ExitCode);
        }
        private void btnBotSettings_Click(object sender, EventArgs e)
        {
            Form botSettings = new FormBotSettings()
            {
                Tag = friends.GetPersonaName() + (int)friends.GetPersonaState()
            };
            botSettings.ShowDialog(this);
        }
        private void lbChatrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChatroomInfo.Enabled = true;
        }
        private void btnChatroomInfo_Click(object sender, EventArgs e)
        {
            Form chatroomInfo = new FormChatroomInfo(CR.Single(s => s.ChatName == lbChatrooms.Items[lbChatrooms.SelectedIndex].ToString()));
            chatroomInfo.ShowDialog(this);
        }

        // -- Crash handler -- //

        private void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DumpError(e.Exception);
            #if DEBUG
            #else
                MessageBox.Show(e.Exception.Message + "\n" + e.Exception.StackTrace, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
            Close();
        }
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            DumpError(ex);
            #if DEBUG
            #else
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
        }
        private void DumpError(Exception error)
        {
            string[] dump = { error.Message, error.StackTrace };
            File.WriteAllLines(Path.Combine(configPath, "crash.log"), dump);
        }
    }
}
