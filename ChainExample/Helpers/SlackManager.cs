using SchoderChain;
using SlackBotMessages;
using SlackBotMessages.Models;

namespace ChainExample.Helpers
{
    public class SlackManager : ISlackManager
    {
        public SlackManager() { }

        public async Task SlackErrorChainResultAsync(ChainResult chainResult)
            => await new SbmClient(SlackSecrets.SLACK_WEBHOOKURL_ERROR).Send(
                new Message
                {
                    Username = SlackSecrets.SLACK_USER,
                    Text = $"{DateTime.UtcNow} {chainResult.CalledBy}" +
                        $"\r\n--------------------" +
                        $"\r\n{string.Join("\r\n", chainResult.StackTrace)}" +
                        $"\r\n--------------------" +
                        $"\r\n{chainResult.Exception.ToString()}",
                    IconEmoji = Emoji.Bomb
                });
    }
}
