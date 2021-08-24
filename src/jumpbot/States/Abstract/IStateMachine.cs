using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.States.Abstract
{
    public interface IStateMachine
    {
        Task<string> FireEvent(Message message);

        void SetState(string id, IState state);
    }
}
