
using Microsoft.Extensions.Logging;

using var  _loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Information);
});

ILogger logger = new Logger<Program>(_loggerFactory);

logger.LogInformation("Random number {RandomNumber}",Random.Shared.Next());

Console.ReadKey();