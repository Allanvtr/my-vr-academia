using MediatR;

namespace VrAudioCena.WebApi.Infrastructure.Background
{
    public class VrBackgroundWorker : BackgroundService
    {
        private readonly EventQueue _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<VrBackgroundWorker> _logger;

        public VrBackgroundWorker(EventQueue channel, IServiceProvider serviceProvider, ILogger<VrBackgroundWorker> logger)
        {
            _channel = channel;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background worker started and is waiting for events.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogDebug("Waiting for the next event...");

                    var nextEvent = await _channel.ReadQueueAsync(stoppingToken);

                    _logger.LogInformation(
                        "Processing event {EventType}.",
                        nextEvent.GetType().Name);

                    using var scope = _serviceProvider.CreateScope();

                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    await mediator.Publish(nextEvent, stoppingToken);

                    _logger.LogInformation(
                        "Event {EventType} processed successfully.",
                        nextEvent.GetType().Name);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Background worker is stopping.");

                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "An unexpected error occurred while processing a background event.");
                }
            }

            _logger.LogInformation("Background worker stopped.");
        }
    }
}