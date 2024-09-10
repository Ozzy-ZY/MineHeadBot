using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using System.Reactive.Subjects;

namespace FirstBot
{
    internal class Program
    {
        //private async Task MessageHandler(SocketMessage message)
        //{
        //    Console.WriteLine("started Message Handler");
        //    if (message.Author.IsBot)
        //        return;
        //    var insult = await GetMineHead.GetMinecraftAvatarAsync(message.Content);
        //    await ReplyAsync(message, insult);
        //}

        //private async Task ReplyAsync(SocketMessage message, string response)
        //{
        //    Console.WriteLine("replying Async");
        //    await message.Channel.SendMessageAsync(response);
        //    await message.Channel.SendFileAsync(response);
        //}

        //private async Task SlashCommandHandler(SocketSlashCommand command)
        //{
        //    await command.RespondAsync($"You executed {command.Data.Name}");
        //}

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
            var mybot = new BotApp();
            await mybot.StartBotAsync();
        }
    }
}