using Discord.Net;
using Discord;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot.Commands
{
    internal class MineHead
    {
        public static async Task CreateMineHeadCommand()
        {
            var guild = BotApp._client.GetGuild(481968987929051167);
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
    }
}