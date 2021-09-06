using jumpbot.CommandFactory;
using jumpbot.Repositories;
using jumpbot.States.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.States.Concrete
{
    public class InitState : IState
    {
        private readonly ITelegramCommandFactory _commandFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserRepository _userRepository;
        public InitState(IServiceProvider serviceProvider, IUserRepository userRepository)
        {
            _serviceProvider = serviceProvider ??
                throw new ArgumentNullException(nameof(serviceProvider));

            _commandFactory = new InitCommandFactory(_serviceProvider);
            
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
        }
        public Task<string> Update(Message message)
        {
            if (message.Contact != null)
            {

            }
            
            _commandFactory.CreateCommand(message)?.ExecuteAsync(message);
            
            throw new NotImplementedException();
        }
    }
}
