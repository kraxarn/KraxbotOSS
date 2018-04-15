using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace KraxbotOSS
{
	/*
	 * NOTE
	 *
	 * This doesn't work that well
	 * on Windows 7 and macOS/Linux due
	 * to them not supported the
	 * .NET WebSocket implementation.
	 */

	public class DiscordBot
	{
		private Form1 form;
		private readonly Form1.Config cfg;

		private DiscordClient client;

		public DiscordBot(Form1 form1)
		{
			// Form and config refs
			form = form1;
			cfg  = Form1.config;

			// Discord
			form.DiscordStatus = "Connecting";
			Task.Run(() => Bot().ConfigureAwait(false).GetAwaiter().GetResult());
		}

		public void Disconnect()
		{
			Task.Run(async () => { await client.DisconnectAsync(); });
		}

		private async Task Bot()
		{
			// Create bot
			client = new DiscordClient(new DiscordConfiguration
			{
				Token = cfg.Discord_Token,
				TokenType = TokenType.Bot
			});

			// Create listeners
			client.MessageCreated += OnMessageCreated;

			// Connect
			await client.ConnectAsync();
			form.DiscordStatus = "Logged in";
		}

		private async Task OnMessageCreated(MessageCreateEventArgs args)
		{
			form.Log($"\n{args.Author.Username} ({args.Channel.Name}): {args.Message.Content}");

			if (args.Message.Content.ToLower().StartsWith("ping"))
				await args.Message.RespondAsync("pong");
		}
	}
}