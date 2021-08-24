using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.States.Abstract
{
    public interface IState
    {
        Task<string> Update(Message message);

    }
}
