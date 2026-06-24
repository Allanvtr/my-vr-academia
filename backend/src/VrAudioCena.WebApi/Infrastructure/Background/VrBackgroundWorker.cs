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
            _logger.LogInformation("Background iniciando, aguardando pedidos...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var nextEvent = await _channel.ReadQueueAsync(stoppingToken);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                        await mediator.Publish(nextEvent, stoppingToken);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro crítico ao processar evento em background.");
                }
            }
        }

    }
}