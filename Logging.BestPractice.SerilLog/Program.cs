// See https://aka.ms/new-console-template for more information


using Serilog;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
    
    logger.Information("Random number {RandomNumber}", Random.Shared.Next());