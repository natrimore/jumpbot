using jumpbot.States.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.States.Concrete
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<string, IState> _stateStorage;
        private readonly Func<IState> _initStateFactory;

        public StateMachine(Func<IState> initStateFactory)
        {
            _stateStorage = new Dictionary<string, IState>();
            _initStateFactory = initStateFactory;
        }

        public async Task<string> FireEvent(Message message)
        {
            // если есть состояни по ключу
            if (_stateStorage.TryGetValue(message.Chat.Id.ToString(), out var currentState))
            {
                return await currentState.Update(message);
            }

            // если нету, то создаем и обновляем
            var state = _initStateFactory();
            SetState(message.Chat.Id.ToString(), state);
            return await state.Update(message);
        }

        public void SetState(string id, IState state)
        {
            _stateStorage[id] = state;
        }
    }
}
