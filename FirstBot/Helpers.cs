﻿using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot
{
    public class Helpers
    {
        public static async Task LogAsync(LogMessage log)
        {
            await Task.Run(() => Console.WriteLine(log));
        }
    }
}