using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordNuker.Commands
{
    public class Ping : ModuleBase
    {

        [Command("Ping", RunMode = RunMode.Async)]

        public async Task SendPing()
        {
            await ReplyAsync($"Pong! {Context.User.Mention}");

        }
    }

}