namespace CSE.WorkerService.Jobs.HealthJob;

public class HealthJob(ILogger<HealthJob> logger) : BackgroundService
{
    private readonly ILogger<HealthJob> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            DoWork();
        }
    }

    private void DoWork() => _logger.LogInformation($"Health job is running at: '{DateTime.UtcNow.ToString()}'.");

}
