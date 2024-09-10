using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstBot.Handlers;
using FirstBot.Commands;

namespace FirstBot
{
    public class BotApp
    {
        public static readonly DiscordSocketClient _client;

        internal const string _token = @"MTI4Mjk5Mzg2MTU2Nzk3MTMyOA.GhWaUn.lxRXrE7196OpQi03cgN1bsSv9ggNqRjrHfBPWI";

        static BotApp()
        {
            var Config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };
            _client = new DiscordSocketClient(Config);
            //_client.MessageReceived += MessageHandler;
            _client.Ready += MineHead.CreateMineHeadCommand;
            _client.SlashCommandExecuted += GuildCommandHandler.SlashCommandHandler;

            Console.WriteLine("INIT Program");
        }

        public async Task StartBotAsync()
        {
            _client.Log += Helpers.LogAsync;
            await _client.LoginAsync(Discord.TokenType.Bot, _token);
            await _client.StartAsync();
            //_client.Ready += RegisterCommandsAsync;
            await Task.Delay(-1);
            Console.WriteLine("Started Bot Async indifnitly");
        }
    }
}