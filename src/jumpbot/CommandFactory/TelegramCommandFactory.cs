using Microsoft.Extensions.DependencyInjection;
using jumpbot.Commands.Abstract;
using jumpbot.Commands.Concrete;
using Telegram.Bot.Types;
using System;

namespace jumpbot.CommandFactory
{
    public class TelegramCommandFactory : ITelegramCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TelegramCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ??
                throw new ArgumentNullException(nameof(serviceProvider));
        }
        public ICommand CreateCommand(Message command)
        {
            return command.Text switch
            {
                "/start" => _serviceProvider.GetRequiredService<StartCommand>(),
                _ => _serviceProvider.GetRequiredService<StartCommand>()
            };
        }
    }
}
