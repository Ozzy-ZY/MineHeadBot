using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot.Handlers
{
    internal class HandleCommands
    {
        public static async Task HandleMineHeadCommand(SocketSlashCommand command)
        {
            var name = command.Data.Options.First().Value;
            var imgPath = await GetMineHead.GetMinecraftAvatarAsync(name as string ?? "zyad");
            await command.RespondWithFileAsync(imgPath);
        }
    }
}