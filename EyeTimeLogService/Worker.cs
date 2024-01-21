namespace EyeTimeLogService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //while (!stoppingToken.IsCancellationRequested)
        //{
        _logger.LogInformation("Now: {time}", DateTimeOffset.Now);
        //await Task.Delay(5000, stoppingToken);
        //}

        await StopAsync(stoppingToken);
        //_hostApplicationLifetime.StopApplication();
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Shutting Down... {time}", DateTimeOffset.Now);
        await base.StopAsync(cancellationToken);
        Environment.Exit(1);
    }
}
