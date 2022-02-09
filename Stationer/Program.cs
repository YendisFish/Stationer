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
                Token = "",
                TokenType = TokenType.Bot,
            });

            client.MessageCreated += async (s, e) => 
            {
                if(e.Message.Content.ToLower().Contains("stat!") && e.Message.Content.ToLower().Contains("startup"))
                {
                    DiscordChannel channel = await e.Guild.CreateChannelAsync("tickets", ChannelType.Text);
                    await channel.SendMessageAsync("Hello members! You may create a ticket by reacting to this message! (Any Reaction!)");
                }

                await client.ConnectAsync();
                await Task.Delay(-1);
            };

            client.MessageReactionAdded += async (s, e) =>
            {
                if(e.Message.Author.Id.ToString() == "940803522352525342")
                {
                    if(e.Message.Content == "Hello members! You may create a ticket by reacting to this message! (Any Reaction!)")
                    {
                        DiscordChannel channel = await e.Guild.CreateChannelAsync(Guid.NewGuid().ToString(), ChannelType.Text);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.AccessChannels);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.AddReactions);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.EmbedLinks);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.AttachFiles);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.SendMessages);
                        await channel.AddOverwriteAsync(await e.Guild.GetMemberAsync(e.User.Id), Permissions.ReadMessageHistory);

                        await channel.SendMessageAsync("<@&928746357693481080> " + $"<@!{e.User.Id}>");
                    }
                }

                await client.ConnectAsync();
                await Task.Delay(-1);
            };
        }
    }
}
