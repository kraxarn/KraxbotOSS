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
using Newtonsoft.Json.Linq;
using System.Threading;
using Cleverbot.Net;
using System.Text.RegularExpressions;

namespace KraxbotOSS
{
    public partial class Form1 : Form
    {
        // Some variables
        string version = "0.1.0";
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
                config.Updates         = json.Updates;
                config.FriendRequest   = json.FriendRequest;
                config.ChatRequest     = json.ChatRequest;
                config.LoginAs         = json.LoginAs;
                config.Superadmin      = json.Superadmin;
                config.Chatrooms       = json.Chatrooms;
                config.API_Steam       = json.API.SteamWeb;
                config.API_Google      = json.API.Google;
                config.API_OpenWeather = json.API.OpenWeatherMap;
                config.API_CleverbotIO = json.API.CleverbotIO;
            }

            // Check for updates
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

            public int     Version     = 0;
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
        }

        // User info
        public class UserInfo
        {
            public SteamID         SteamID;
            public EClanPermission Rank;
            public EChatPermission Permission;
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
            internal JArray Chatrooms;

            internal string API_Steam;
            internal string API_Google;
            internal string API_OpenWeather;
            internal string API_CleverbotIO;
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
            Invoke((MethodInvoker)delegate
            {
                btnLogin.Enabled = true;
                lNetwork.Text = "Network: Connected";
            });
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
                // TODO: Add Steam Guard support
                if (callback.Result == EResult.AccountLogonDenied)
                    MessageBox.Show("Denied login to Steam: " + callback.Result, "Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (callback.Result == EResult.AccountLoginDeniedNeedTwoFactor)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        FormLogin login = new FormLogin("NeedTwoFactor");
                        // If we use ShowDialog here, we get disconencted and can't login
                        login.Show(this);
                    });
                }
                else if (callback.Result != EResult.TryAnotherCM)
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

            // Check if we set to save password
            if (!string.IsNullOrEmpty(FormLogin.EncryptKey))
            {
                string[] save = new string[3];
                if (FormLogin.EncryptKey == Environment.MachineName)
                    save[0] = "Auto";
                else
                    save[0] = "Key";
                save[1] = FormLogin.Username;
                save[2] = EncryptDecrypt(FormLogin.Password, FormLogin.EncryptKey);
                File.WriteAllLines(Path.Combine(configPath, "userinfo"), save);
            }

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
            foreach (SteamID groupID in GetGroups())
                if (config.Chatrooms.ToString().IndexOf(groupID.AccountID.ToString()) > -1)
                    friends.JoinChat(groupID);
        }
        void OnFriendAdded(SteamFriends.FriendAddedCallback callback)
        {
            if (config.FriendRequest == "AcceptAll")
                Log(callback.PersonaName + " is now my friend");
        }
        void OnChatInvite(SteamFriends.ChatInviteCallback callback)
        {
            Log(string.Format("\nGot invite to {0} from {1}", callback.ChatRoomName, friends.GetFriendPersonaName(callback.PatronID)));

            // TODO: Add SuperadminOnly
            if (config.ChatRequest == "AcceptAll")
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
                CreateSettings(callback.ChatID, callback.ChatRoomName, callback.FriendID.AccountID, friends.GetFriendPersonaName(callback.FriendID));
            Settings chatRoom = CR.Single(s => s.ChatID == callback.ChatID);

            // Add all current users to the Users list
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
            // TODO: Add more to this
            Log(string.Format("\n[{0}] {1} {2} ({3})", chatRoom.ChatName.Substring(0, 3), friends.GetFriendPersonaName(callback.StateChangeInfo.ChatterActedOn), callback.StateChangeInfo.StateChange, callback.Type));

            // Add or remove user from Users list
            // TODO: Fill rest of info
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
                chatRoom.Users.Remove(chatRoom.Users.Single(s => s.SteamID == callback.StateChangeInfo.ChatterActedOn.AccountID));
                if (chatRoom.AllStates)
                    SendChatMessage(chatRoomID, string.Format("Good bye {0}{1}", name, chatRoom.WelcomeEnd));
            }
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
            // TODO: Commands and/or Cleverbot
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
                SendMessage(userID, session.Send(message));
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
                            string title = GetStringBetween(GetStringBetween(response, "<title", "</title"), ">");
                            if (title.IndexOf("YouTube") > -1)
                            {
                                // Youtube
                                if (string.IsNullOrEmpty(config.API_Google))
                                {
                                    string video = title.Substring(0, title.LastIndexOf("- YouTube"));
                                    SendChatMessage(chatRoomID, string.Format("{0} posted a video: {1}", name, video));
                                } else
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
                            else
                                SendChatMessage(chatRoomID, string.Format("{0} posted {1}", name, title.Trim()));
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
                SendChatMessage(chatRoomID, session.Send(message));
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
                    List<UserInfo> users = new List<UserInfo>(chatRoom.Users);
                    users.Remove(users.Single(s => s.SteamID == client.SteamID));
                    SendChatMessage(chatRoomID, string.Format("The winner is {0}!", friends.GetFriendPersonaName(users[new Random().Next(users.Count)].SteamID)));
                }
                else if (message == "!games" && chatRoom.Games)
                {
                    if (string.IsNullOrEmpty(config.API_Steam))
                        SendChatMessage(chatRoomID, "Steam API isn't set up properly to use this command");
                    else
                    {
                        string response = Get("http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" + config.API_Steam + "&include_appinfo=1&include_played_free_games=1&steamid=" + userID.ConvertToUInt64());
                        if (!string.IsNullOrEmpty(response))
                        {
                            dynamic result = JsonConvert.DeserializeObject(response);
                            SendChatMessage(chatRoomID, string.Format("You have {0} games", result.response.game_count));
                            JArray array = result.response.games;
                            JArray games = new JArray(array.OrderByDescending(obj => obj["playtime_forever"]));
                            for (int i = 0; i <= 4; i++)
                                SendChatMessage(chatRoomID, string.Format("{0}: {1} ({2} hours played)", i+1, games[i]["name"], Math.Round((double)games[i]["playtime_forever"] / 60)));
                        }
                        else
                            SendChatMessage(chatRoomID, "Error: No or invalid response from Steam");
                    }
                }
                else if (message == "!recents" && chatRoom.Games)
                {
                    if (string.IsNullOrEmpty(config.API_Steam))
                        SendChatMessage(chatRoomID, "Steam API isn't set up properly to use this command");
                    else
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
                            for (int i = 0; i <= 4; i++)
                            {
                                int playtime = (int)Math.Round((double)games[i]["playtime_2weeks"] / 60);
                                if (playtime == 1)
                                    SendChatMessage(chatRoomID, string.Format("{0}: {1} (1 hour played recently)", i+1, games[i]["name"]));
                                else
                                    SendChatMessage(chatRoomID, string.Format("{0}: {1} ({2} hours played recently)", i + 1, games[i]["name"], playtime));
                            }
                        }
                    }
                }
                else if (message.StartsWith("!define ") && chatRoom.Define)
                {
                    // TODO: Add cooldown
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
                    // TODO: Same as !bday
                    // TODO: Also make !players if user is currently playing a game
                }
                else if (message.StartsWith("!weather "))
                {
                    // TODO: Same as !bday
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
                SentryFileHash = sentryHash,
                LoginKey = loginkey,
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
            // TODO: Get ChatName, InvitedName and InvitedID
            CR.Add(new Settings() {
                ChatID = ChatRoomID,
                ChatName = ChatRoomName,
                InvitedID = InvitedID,
                InvitedName = InvitedName
            });
        }
        void SaveSettings(Settings setting)
        {
            // TODO: Check if xml is faster (prob not)
            // TODO: Maybe we want to save all settings to the same file
            string file = Path.Combine(configPath, "chatrooms", setting.ChatID.ConvertToUInt64().ToString() + ".json");
            File.WriteAllText(file, JsonConvert.SerializeObject(setting));
        }
        void LoadSettings(SteamID chatRoomID)
        {
            string file = File.ReadAllText(Path.Combine(configPath, "chatrooms", chatRoomID.ConvertToUInt64().ToString() + ".json"));
            CR.Add(JsonConvert.DeserializeObject<Settings>(file));
        }

        string Get(string url)
        {
            // TODO: Check if better way to do this
            using (var client = new System.Net.WebClient())
            {
                try {
                    return client.DownloadString(url);
                } catch (System.Net.WebException e) {
                    Console.WriteLine(e.Message);
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

        void CheckForUpdates()
        {
            // TODO: Maybe ASync this
            string response = Get("http://web.kraxarn.com/api/ver.php?app=kraxbot");
            if (string.IsNullOrEmpty(response)) return;
            dynamic result = JsonConvert.DeserializeObject(response);
            string newVersion = version;
            switch (config.Updates)
            {
                case "All": newVersion = result.stable.version_string; break;
                case "OnlyMajor": newVersion = result.major.version_string; break;
                case "Beta": newVersion = result.beta.version_string; break;
            }
            if (version != newVersion)
            {
                if (MessageBox.Show(string.Format("Current version is {0} \nNew Version is {1} \nDo you want to update now?", version, newVersion), "New Update Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Start updater and update here
                    System.Diagnostics.Process.Start("http://web.kraxarn.com/apps/kraxbot");
                }
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
            if (File.Exists(Path.Combine(configPath, "userinfo")))
            {
                string[] user = File.ReadAllLines(Path.Combine(configPath, "userinfo"));
                if (user[0] == "Auto")
                    Login(user[1], EncryptDecrypt(user[2], Environment.MachineName), true);
                else if (user[0] == "Key")
                {
                    FormSaveLogin saveLogin = new FormSaveLogin();
                    saveLogin.ShowDialog(this);
                    if (!string.IsNullOrEmpty(FormLogin.EncryptKey))
                        Login(user[1], EncryptDecrypt(user[2], FormLogin.EncryptKey), true);
                }
            }
            else
            {
                Form login = new FormLogin();
                login.ShowDialog(this);
            }
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            MessageBox.Show(e.Exception.Message + "\n" + e.Exception.StackTrace, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            #if DEBUG
            #else
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
        }
    }
}
