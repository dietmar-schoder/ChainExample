using SchoderChain;
using SlackBotMessages;
using SlackBotMessages.Models;

namespace ChainExample.Helpers
{
    public class SlackManager : ISlackManager
    {
        public SlackManager() { }

        public async Task SlackErrorAsync(string messageBody)
            => await new SbmClient(SlackSecrets.SLACK_WEBHOOKURL_ERROR).Send(
                new Message
                {
                    Username = SlackSecrets.SLACK_USER,
                    Text = messageBody,
                    IconEmoji = Emoji.Bomb
                });
    }
}
