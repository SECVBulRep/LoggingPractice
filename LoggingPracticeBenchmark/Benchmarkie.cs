using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Engines;
using Microsoft.Extensions.Logging;

namespace LoggingPracticeBenchmark;

//[SimpleJob(RunStrategy.Monitoring)]
[MemoryDiagnoser]
public class Benchmarkie
{
    private const string LogMessageWithParams = "This is a log message with params {1}, {2} and {3}";

    private const string LogMessage = " This is a log message";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<Benchmarkie> _logger;
    private readonly ILoggerAdapter<Benchmarkie> _loggerAdapter;

    public Benchmarkie()
    {
        _logger = new Logger<Benchmarkie>(_loggerFactory);
        _loggerAdapter = new LoggerAdapter<Benchmarkie>(_logger);
    }

    [Benchmark(Baseline = true)]
    public void LogWithOut_If()
    {
        _logger.LogInformation(LogMessage);
    }

    [Benchmark]
    public void LogWith_If()
    {
        if (_logger.IsEnabled(LogLevel.Information))
            _logger.LogInformation(LogMessage);
    }


    [Benchmark]
    public void LogWithOut_If_WithParams()
    {
        _logger.LogInformation(LogMessageWithParams, 1, 2, 3);
    }

    [Benchmark]
    public void LogWith_If_WithParams()
    {
        if (_logger.IsEnabled(LogLevel.Information))
            _logger.LogInformation(LogMessageWithParams, 1, 2, 3);
    }

    [Benchmark]
    public void LogAdapterWith_If_WithParams()
    {
        _loggerAdapter.LogInformtion(LogMessageWithParams, 1, 2, 3);
    }
}