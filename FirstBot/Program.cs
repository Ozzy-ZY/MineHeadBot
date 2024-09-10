using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using System.Reactive.Subjects;

namespace FirstBot
{
    internal class Program
    {
        private readonly DiscordSocketClient _client;

        private const string _token = @"YOUR TOKEN";

        public Program()
        {
            var Config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };
            this._client = new DiscordSocketClient(Config);
            _client.MessageReceived += MessageHandler;
            _client.Ready += CreateSlashCommand;
            _client.SlashCommandExecuted += SlashCommandHandler;

            Console.WriteLine("INIT Program");
        }

        public async Task StartBotAsync()
        {
            _client.Log += LogAsync;
            await _client.LoginAsync(Discord.TokenType.Bot, _token);
            await _client.StartAsync();
            //_client.Ready += RegisterCommandsAsync;
            await Task.Delay(-1);
            Console.WriteLine("Started Bot Async indifnitly");
        }

        private async Task MessageHandler(SocketMessage message)
        {
            Console.WriteLine("started Message Handler");
            if (message.Author.IsBot)
                return;
            var insult = await GetMineHead.GetMinecraftAvatarAsync(message.Content);
            await ReplyAsync(message, insult);
        }

        private async Task ReplyAsync(SocketMessage message, string response)
        {
            Console.WriteLine("replying Async");
            await message.Channel.SendMessageAsync(response);
            await message.Channel.SendFileAsync(response);
        }

        private async Task LogAsync(LogMessage log)
        {
            await Task.Run(() => Console.WriteLine(log));
        }

        public async Task CreateSlashCommand()
        {
            var guild = _client.GetGuild(481968987929051167);
            var guildCommand = new SlashCommandBuilder()
                .WithName("minehead")
                .WithDescription("Gets the minecraft head of specified user")
                .AddOption("username", ApplicationCommandOptionType.String,
                "The username of the minecraft account", isRequired: true);
            try
            {
                await guild.CreateApplicationCommandAsync(guildCommand.Build());
            }
            catch (HttpException e)
            {
                var json = JsonConvert.SerializeObject(e.Errors, Formatting.Indented);
                Console.WriteLine(json);
            }
        }

        //private async Task SlashCommandHandler(SocketSlashCommand command)
        //{
        //    await command.RespondAsync($"You executed {command.Data.Name}");
        //}

        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            // Let's add a switch statement for the command name so we can handle multiple commands in one event.
            switch (command.Data.Name)
            {
                case "minehead":
                    await HandleMineHeadCommand(command);
                    break;
            }
        }

        private async Task HandleMineHeadCommand(SocketSlashCommand command)
        {
            var name = command.Data.Options.First().Value;
            var imgPath = await GetMineHead.GetMinecraftAvatarAsync(name as string ?? "zyad");
            await command.RespondWithFileAsync(imgPath);
        }

        // bot Id : ID
        // GUILD Id : Id

        //private async Task RegisterCommandsAsync()
        //{
        //    var guild = _client.GetGuild(481968987929051167);

        //    var testCommand = new SlashCommandBuilder()
        //        .WithName("hello")
        //        .WithDescription("Replies with Hello!")
        //        .Build();

        //    await guild.CreateApplicationCommandAsync(testCommand);

        //    Console.WriteLine("Slash commands registered.");
        //}

        //private async Task SlashCommandHandler(SocketSlashCommand command)
        //{
        //    Console.WriteLine("command Executing");
        //    switch (command.Data.Name)
        //    {
        //        case "hello":
        //            await command.RespondAsync("Hello!");
        //            break;

        //        default:
        //            await command.RespondAsync("Unknown command.");
        //            break;
        //    }
        //}

        private static async Task Main(string[] args)
        {
            var mybot = new Program();
            await mybot.StartBotAsync();
        }
    }
}