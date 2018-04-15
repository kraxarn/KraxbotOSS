using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Net.WebSocket;
using SteamKit2;

namespace KraxbotOSS
{
	public class DiscordBot
	{
		private readonly Form1 form;
		private readonly Form1.Config cfg;
		private DiscordClient client;

		private readonly SteamID steamChat;
		private DiscordChannel discordChannel;

		public DiscordBot(Form1 form1)
		{
			// Form and config refs
			form = form1;
			cfg  = Form1.config;

			// Discord
			form.DiscordStatus = "Connecting";
			Task.Run(() => Bot().ConfigureAwait(false).GetAwaiter().GetResult());

			// Set the Steam chatroom to send messages to
			if (cfg.Discord_Steam != 0)
			{
				foreach (var steamID in form.GetGroups())
				{
					if (cfg.Discord_Steam == steamID.AccountID)
						steamChat = steamID;
				}
			}
		}

		public void Disconnect() => Task.Run(async () => await client.DisconnectAsync()).Wait();

		public void SendMessage(string message) => Task.Run(async () => await client.SendMessageAsync(discordChannel, message));

		private async Task Bot()
		{
			// Create bot
			client = new DiscordClient(new DiscordConfiguration
			{
				Token = cfg.Discord_Token,
				TokenType = TokenType.Bot,
				AutoReconnect = true
			});

			// Set web socket implementation
			client.SetWebSocketClient<WebSocket4NetClient>();

			// Create listeners
			client.MessageCreated += OnMessageCreated;
			client.Ready += ClientOnReady;

			// Connect
			await client.ConnectAsync();

			// Find Discord channel
			// Can this be set from constructor?
			discordChannel = await client.GetChannelAsync(cfg.Discord_Channel);

			// Wait
			await Task.Delay(-1);
		}

		private Task ClientOnReady(ReadyEventArgs readyEventArgs)
		{
			form.DiscordStatus = "Logged in";
			return Task.CompletedTask;
		}

		private Task OnMessageCreated(MessageCreateEventArgs args)
		{
			// Ignore messages from the bot
			if (args.Author == client.CurrentUser)
				return Task.CompletedTask;

			// Get whole username
			var author = $"{args.Author.Username}#{args.Author.Discriminator}";

			// Log it
			form.Log($"\n{author} ({args.Channel.Name}): {args.Message.Content}");

			// Check if we should send it to Steam
			if (ShouldSendToSteam(args.Channel))
				form.SendChatMessage(steamChat, $"{args.Author.Username}: {args.Message.Content}");

			// Return
			return Task.CompletedTask;
		}

		private bool ShouldSendToSteam(DiscordChannel channel)
		{
			switch (cfg.Discord_Messages)
			{
				case "DiscordToSteam":
				case "Both":
					return channel == discordChannel;
				default:
					return false;
			}
		}

		public bool ShouldSendToDiscord(SteamID chatID)
		{
			switch (cfg.Discord_Messages)
			{
				case "SteamToDiscord":
				case "Both":
					return chatID.AccountID == steamChat.AccountID;
				default:
					return false;
			}
		}
	}
}