using jumpbot.Configuration.Environment;

namespace jumpbot.Configuration.Context
{
    public class ConfigurationContext : IConfigurationContext
    {
        public string ConnectionString { get; set; }
        public string TelegramBotKey { get; set; }
        public ConfigurationContext(IEnvironmentService environmentService)
        {
            ConnectionString = environmentService.Configuration["ConnectionString"];
            TelegramBotKey = environmentService.Configuration["TelegramBotKey"];
        }
    }
}
