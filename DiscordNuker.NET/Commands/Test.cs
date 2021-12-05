using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordNuker.NET.Commands
{
    public class Test : ModuleBase
    {
        [Command("Test", RunMode = RunMode.Async)]

        public async Task SendTest()
        {
            await ReplyAsync("ight");
        }
    }
}
