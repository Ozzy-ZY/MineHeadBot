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
            Helpers.printRed("Responding with The Requested Head...");
            await command.RespondWithFileAsync(imgPath);
            Helpers.PrintGreen("success!");
        }

        public static async Task HandleAppCommand(SocketSlashCommand command)
        {
            await command.RespondAsync("Fuck this");
            await Task.Run(() => Console.WriteLine("fuck this"));
        }
    }
}