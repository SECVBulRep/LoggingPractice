using Microsoft.Extensions.Logging;

using var _loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole().SetMinimumLevel(LogLevel.Warning); });

ILogger logger = new Logger<Program>(_loggerFactory);

for (int i = 0; i < 70_000_000_00; i++)
{
    //if (logger.IsEnabled(LogLevel.Information))
        logger.LogInformation($"Random number {Random.Shared.Next()}");
}

//Console.ReadKey();