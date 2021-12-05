using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordNuker.NET
{
    public class Program
    {
        //Look at trello board!
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            Console.Title = "rxversed's nuker.";
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
#if DEBUG
                LogLevel = LogSeverity.Verbose
#endif

            });
            CommandHandler Handler;
            Handler = new CommandHandler();
            await Handler.Init(_client);
            _client.Log += Log;

            await GetToken();

            var tkn = Console.ReadLine();

            try
            {
                await _client.LoginAsync(TokenType.Bot, tkn);
                Console.WriteLine("Logging in..");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to login. This window will close in 10 seconds. \n Reason: " + ex);
                Thread.Sleep(10000);
                Environment.Exit(1);
            }

            await _client.StartAsync();
            _client.Ready += () =>
            {
                Console.WriteLine("Ready! Connected with " + _client.CurrentUser);
                _client.SetStatusAsync(UserStatus.Offline);
                return Task.CompletedTask;
            };

            Thread.Sleep(2000);
            Console.Clear();

            await Help();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
#if DEBUG
            Console.WriteLine("Log: " + msg.ToString());
#endif
            return Task.CompletedTask;
        }

        private static Task Help()
        {
            //Look at trello board!
            File.CreateText("NukerLogs.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                                                                                                       
                                    kkkkkkkk                                                   
                                    k::::::k                                                   
                                    k::::::k                                                   
                                    k::::::k                                                   
nnnn  nnnnnnnn    uuuuuu    uuuuuu   k:::::k    kkkkkkk    eeeeeeeeeeee    rrrrr   rrrrrrrrr   
n:::nn::::::::nn  u::::u    u::::u   k:::::k   k:::::k   ee::::::::::::ee  r::::rrr:::::::::r  
n::::::::::::::nn u::::u    u::::u   k:::::k  k:::::k   e::::::eeeee:::::eer:::::::::::::::::r 
nn:::::::::::::::nu::::u    u::::u   k:::::k k:::::k   e::::::e     e:::::err::::::rrrrr::::::r
  n:::::nnnn:::::nu::::u    u::::u   k::::::k:::::k    e:::::::eeeee::::::e r:::::r     r:::::r
  n::::n    n::::nu::::u    u::::u   k:::::::::::k     e:::::::::::::::::e  r:::::r     rrrrrrr
  n::::n    n::::nu::::u    u::::u   k:::::::::::k     e::::::eeeeeeeeeee   r:::::r            
  n::::n    n::::nu:::::uuuu:::::u   k::::::k:::::k    e:::::::e            r:::::r            
  n::::n    n::::nu:::::::::::::::uuk::::::k k:::::k   e::::::::e           r:::::r            
  n::::n    n::::n u:::::::::::::::uk::::::k  k:::::k   e::::::::eeeeeeee   r:::::r            
  n::::n    n::::n  uu::::::::uu:::uk::::::k   k:::::k   ee:::::::::::::e   r:::::r            
  nnnnnn    nnnnnn    uuuuuuuu  uuuukkkkkkkk    kkkkkkk    eeeeeeeeeeeeee   rrrrrrr 

  _                                                                      _ 
 | |                                                                    | |
 | |__    _   _     _ __  __  __ __   __   ___   _ __   ___    ___    __| |
 | '_ \  | | | |   | '__| \ \/ / \ \ / /  / _ \ | '__| / __|  / _ \  / _` |
 | |_) | | |_| |   | |     >  <   \ V /  |  __/ | |    \__ \ |  __/ | (_| |
 |_.__/   \__, |   |_|    /_/\_\   \_/    \___| |_|    |___/  \___|  \__,_|
           __/ |                                                           
          |___/                                                            
                                                                                               
");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[-] Prefix = \"n\".");
            Console.WriteLine("Type all commands in chat.\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
    Creation Commands:
.mass chan = Mass creates text channels
.mass cate = Mass creates categories.
.mass vc = Mass creates voice channels.
.mass role = Mass creates roles (rainbow)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            Deletion Commands:
.mass del = Mass deletes text, voice channnels and categories.
.mass del roles = Deletes all roles..
.mass del emojis
.mass ban = Bans everyone in a server and outputs it in a file (same file where this exe is located)
.mass prune = Prunes members from a server in a certain span of days.
   Mention Commands:
.mass mention = Mentions every single user in a seperate message (not @everyone)
.mass ping = Pings @everyone in every single channel
");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"
            Misc Commands:
.mass nickname = Nicknames everyone in the server
.mass rename chan = Mass renames text channels
.unban all = Unbans everyone in the banned list
");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            Destroy Server:
.nuke
");
            Console.ForegroundColor = ConsoleColor.White;
            return Task.CompletedTask;
        }

        private static Task GetToken()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("[-] Enter your token: ");
            return Task.CompletedTask;
        }
    }
}
