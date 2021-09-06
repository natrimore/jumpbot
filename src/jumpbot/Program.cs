using jumpbot.Client;
using jumpbot.CommandFactory;
using jumpbot.Commands.Concrete;
using jumpbot.Configuration.Context;
using jumpbot.Configuration.Environment;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace jumpbot
{
    class Program
    {
        public static IServiceProvider Services { get; set; }

        public static ITelegramClient TelegramClient { get; set; }
        public static ITelegramBotClient TelegramBotClient { get; set; }

        public static ITelegramCommandFactory TelegramCommandFactory { get; set; }

        static void Main(string[] args)
        {
            RegisterDependencies();

            TelegramClient = Services.GetRequiredService<ITelegramClient>();
            TelegramCommandFactory = Services.GetRequiredService<ITelegramCommandFactory>();

            TelegramBotClient = TelegramClient.GetInstance();

            TelegramBotClient.OnMessage += TelegramBotClientOnOnMessage;

            TelegramBotClient.StartReceiving();

            System.Console.WriteLine($"JumpTelegramBot.Console.Program started!");
            
            while (true)
            {
                Thread.Sleep(4000);
            }
        }

        private static async void TelegramBotClientOnOnMessage(object sender, MessageEventArgs e)
        {
            if (e?.Message == null)
            {
                return;
            }

            //RequestHistoryRepository.InsertAsync(new RequestHistory(e.Message));

            try
            {
                await TelegramCommandFactory.CreateCommand(e?.Message).ExecuteAsync(e.Message);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                await TelegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Ops! something went wrong. 😢🤦‍♀️ Can you try again?");
            }
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                await botClient.SendTextMessageAsync(message.Chat, "Hello");
            }
        }

        async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(123, apiRequestException.ToString());
            }
        }

        private static void RegisterDependencies()
        {
            Services = new ServiceCollection()
                .AddSingleton<IEnvironmentService, EnvironmentService>()
                .AddSingleton<IConfigurationContext, ConfigurationContext>()
                .AddSingleton<ITelegramClient, TelegramClient>()
                .AddSingleton<ITelegramCommandFactory, InitCommandFactory>()
                .AddSingleton<ITelegramCommandFactory, ProcessCommandFactory>()
                .AddSingleton<ITelegramCommandFactory, PaymentCommandFactory>()
                .AddSingleton<ITelegramCommandFactory, DeliveryCommandFactory>()
                .AddSingleton<ITelegramCommandFactory, TelegramCommandFactory>()
                .AddSingleton<StartCommand>()
                .AddHttpClient()
                .BuildServiceProvider();
        }
    }
}
