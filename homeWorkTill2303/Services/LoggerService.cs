using Microsoft.Extensions.Logging;

namespace homeWorkTill2303.Services
{
    public static class LoggerService
    {
        public static ILogger GetLogger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            return loggerFactory.CreateLogger<Program>();
        }
    }
}
