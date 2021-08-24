using Telegram.Bot;

namespace jumpbot.Client
{
    public interface ITelegramClient
    {
        ITelegramBotClient GetInstance();
    }
}
