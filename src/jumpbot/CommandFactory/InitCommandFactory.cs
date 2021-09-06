using jumpbot.Commands.Abstract;
using System;
using Telegram.Bot.Types;

namespace jumpbot.CommandFactory
{
    public class InitCommandFactory : ITelegramCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public InitCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ??
                throw new ArgumentNullException(nameof(serviceProvider));
        }
        public ICommand CreateCommand(Message command)
        {
            throw new NotImplementedException();
        }
    }
}
