using MediatR;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Services.AI;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartAiProcessingHandler : INotificationHandler<StartAiProcessingEvent>
    {
        private readonly ILogger<StartAiProcessingHandler> _logger;
        private readonly IAIService _aiService;

        public StartAiProcessingHandler(ILogger<StartAiProcessingHandler> logger, IAIService aiService)
        {
            _logger = logger;
            _aiService = aiService;
        }
        
        public Task Handle(StartAiProcessingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received StartAiProcessingEvent with text.");
            var mensagem = _aiService.ProcessPresentationAsync(notification.Text);
            for (int i = 0; i < mensagem.Result.Count; i++)
            {
                _logger.LogInformation($"Question {i + 1}: {mensagem.Result[i]}");
            }
            return Task.CompletedTask;
        }
    }   
}