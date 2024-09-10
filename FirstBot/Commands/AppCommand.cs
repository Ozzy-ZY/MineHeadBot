using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net;
using Discord;
using Newtonsoft.Json;

namespace FirstBot.Commands
{
    public class AppCommand
    {
        public static async Task CreateAppCommand()
        {
            var globalCommand = new SlashCommandBuilder()
                .WithName("fuck-discord")
                .WithDescription("lol");
            try
            {
                await BotApp._client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
            }
            catch (HttpException e)
            {
                var json = JsonConvert.SerializeObject(e.Errors, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
}