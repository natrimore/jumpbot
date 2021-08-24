using jumpbot.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace jumpbot.CommandFactory
{
    public interface ITelegramCommandFactory
    {
        ICommand CreateCommand(Message command);
    }
}
