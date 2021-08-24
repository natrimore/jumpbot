using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace jumpbot.Configuration.Environment
{
    public class EnvironmentService : IEnvironmentService
    {
        private static IConfiguration _configuration;

        private static string _environmentVariableValue = "";
        private static string _environmentVariableKey = "JUMPBOT_ENVIRONMENT";

        public EnvironmentService()
        {
            SetEnvironmentValue();
            SetConfiguration();
        }

        public IConfiguration Configuration => _configuration;


        private void SetConfiguration()
        {
            if (_configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();

                var appsettingsFileName = $"Configuration/appsettings.{_environmentVariableValue.ToLower()}.json";

                _configuration = configurationBuilder.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile(appsettingsFileName, optional: false, reloadOnChange: true)
                    .Build();
            }
        }

        private void SetEnvironmentValue()
        {
            if (Debugger.IsAttached)
            {
                _environmentVariableValue = System.Environment.GetEnvironmentVariable(_environmentVariableKey);
            }
            else
            {
                _environmentVariableValue = System.Environment.GetEnvironmentVariable(_environmentVariableKey, EnvironmentVariableTarget.Process);
            }

            if (_environmentVariableValue == null)
            {
                throw new ArgumentException($"{_environmentVariableKey} environment can not be null!");
            }
        }

        public bool IsDevelopment => _environmentVariableValue.ToLower() == "development";
        public bool IsProduction => _environmentVariableValue.ToLower() == "production";
    }
}
