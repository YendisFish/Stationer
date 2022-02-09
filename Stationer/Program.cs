using DSharpPlus;
using DSharpPlus.Entities;

namespace Stationer.Main
{
    internal class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Starting...");
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            DiscordClient client = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText("token.txt"),
                TokenType = TokenType.Bot,
            });
        }
    }
}
