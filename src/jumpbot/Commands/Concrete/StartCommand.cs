using jumpbot.Client;
using jumpbot.Commands.Abstract;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace jumpbot.Commands.Concrete
{
    public class StartCommand : ICommand
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public StartCommand(ITelegramClient telegramClient)
        {
            _telegramBotClient = telegramClient.GetInstance();
        }
        public async Task ExecuteAsync(Message message)
        {
            await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Hello");
        }
    }
}
