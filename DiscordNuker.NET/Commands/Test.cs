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

            await ReplyAsync("Check console.");
            Console.WriteLine("[-] Delay: (seconds)");
            var userdelay = Console.ReadLine();
            int delay = Convert.ToInt32(userdelay);

            for (; ; )
            {
                Console.WriteLine(delay);
                await Task.Delay(delay);
            }

        }
    }
}
