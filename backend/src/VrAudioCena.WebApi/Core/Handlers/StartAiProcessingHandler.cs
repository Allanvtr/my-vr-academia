using MediatR;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Services.AI;
using VrAudioCena.WebApi.Infrastructure.Persistence;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartAiProcessingHandler : INotificationHandler<StartAiProcessingEvent>
    {
        private readonly ILogger<StartAiProcessingHandler> _logger;
        private readonly IAIService _aiService;
        private readonly IOperationRepository _operationRepository;

        public StartAiProcessingHandler(
            ILogger<StartAiProcessingHandler> logger, 
            IAIService aiService, 
            IOperationRepository operationRepository)
        {
            _logger = logger;
            _aiService = aiService;
            _operationRepository = operationRepository;
        }
        
        public Task Handle(StartAiProcessingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received StartAiProcessingEvent with text.");

            var text = _operationRepository.GetPresentationText(notification.OperationId);
            if (text == null)
            {
                _logger.LogWarning($"No presentation text found for operation {notification.OperationId}");
                return Task.CompletedTask;
            }
            
            var mensagem = _aiService.ProcessPresentationAsync(text);
            for (int i = 0; i < mensagem.Result.Count; i++)
            {
                _logger.LogInformation($"Question {i + 1}: {mensagem.Result[i]}");
            }
            
            return Task.CompletedTask;
        }
    }   
}