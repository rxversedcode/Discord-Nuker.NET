using Discord;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordNuker.NET
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        public async Task MainAsync()
        {

            _client = new DiscordSocketClient();
            CommandHandler Handler;
            Handler = new CommandHandler();
            await Handler.Init(_client);
            _client.Log += Log;

            await GetToken();

            var tkn = Console.ReadLine();

            await _client.LoginAsync(TokenType.Bot, tkn);
            await _client.StartAsync();
            _client.Ready += () =>
            {
                Console.WriteLine("Ready! User: " + _client.CurrentUser);
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                                        _ _                   _             ");
            Console.WriteLine("                                       | ( )                 | |            ");
            Console.WriteLine(" _ ____  ____   _____ _ __ ___  ___  __| |/ ___   _ __  _   _| | _____ _ __ ");
            Console.WriteLine("| '__\\ \\/ /\\ \\ / / _ \\ '__/ __|/ _ \\/ _` | / __| | '_\\ \\| | | | |/ / _ \\ '__|");
            Console.WriteLine("| |   >  <  \\ V /  __/ |  \\__ \\  __/ (_| | \\__ \\ | | | | |_| |   <  __/ |   ");
            Console.WriteLine("|_|  /_/\\_\\  \\_/ \\___|_|  |___/\\___|\\__,_| |___/ |_| |_|\\__,_|_|\\_\\___|_| \n");

            Console.WriteLine(" ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ");
            Console.WriteLine("|______|______|______|______|______|______|______|______|______|______|");
            Console.WriteLine("\n [-] Prefix = \"-\".");
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
