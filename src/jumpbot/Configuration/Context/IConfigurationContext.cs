namespace jumpbot.Configuration.Context
{
    public interface IConfigurationContext
    {
        public string ConnectionString { get; set; }
        public string TelegramBotKey { get; set; }
    }
}
