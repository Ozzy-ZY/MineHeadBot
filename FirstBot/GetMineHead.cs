using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot
{
    public class GetMineHead
    {
        private static HttpClient _http = new HttpClient();

        public static async Task<string> GetMinecraftAvatarAsync(string message)
        {
            //var str = await _http.GetStringAsync("https://evilinsult.com/generate_insult.php?lang=en&type=text");
            string path = "C:\\Users\\user\\source\\repos\\FirstBot\\FirstBot\\Assets\\temp.png";
            Helpers.PrintBlue("and APi Call to https://minotar.net/helm...");
            var img = await _http.GetAsync($"https://minotar.net/helm/{message}/100.png");
            Helpers.PrintBlue($"Getting {message} MineCraft Head as PNG");
            img.EnsureSuccessStatusCode();
            await using var fileStream = new FileStream
                (path, FileMode.Create);
            await img.Content.CopyToAsync(fileStream);
            Helpers.PrintGreen("Image Downloading..");
            return path;
            //return str;
        }
    }
}