using Microsoft.Extensions.Configuration;

namespace homeWorkTill2303
{
    public static class ConfigurationService
    {
        public static Settings GetSettings()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return config.GetSection("Settings").Get<Settings>();
        }
    }
}
