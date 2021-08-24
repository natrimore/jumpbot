using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.Commands.Abstract
{
    public interface ICommand
    {
        Task ExecuteAsync(Message message);
    }
}
