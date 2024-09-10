using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot.Handlers
{
    internal class GuildCommandHandler
    {
        public static async Task SlashCommandHandler(SocketSlashCommand command)
        {
            // Let's add a switch statement for the command name so we can handle multiple commands in one event.
            switch (command.Data.Name)
            {
                case "minehead":
                    await HandleCommands.HandleMineHeadCommand(command);
                    break;
            }
        }
    }
}