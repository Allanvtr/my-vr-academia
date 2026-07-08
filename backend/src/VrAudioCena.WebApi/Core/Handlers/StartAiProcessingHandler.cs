using MediatR;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Services.AI;
using VrAudioCena.WebApi.Infrastructure.Persistence;
using VrAudioCena.WebApi.Infrastructure.Persistence.Models;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartAiProcessingHandler : INotificationHandler<StartAiProcessingEvent>
    {
        private readonly ILogger<StartAiProcessingHandler> _logger;
        private readonly IAIService _aiService;
        private readonly IOperationRepository _operationRepository;
        private readonly IMediator _mediator;

        public StartAiProcessingHandler(
            ILogger<StartAiProcessingHandler> logger, 
            IAIService aiService, 
            IOperationRepository operationRepository,
            IMediator mediator)
        {
            _logger = logger;
            _aiService = aiService;
            _operationRepository = operationRepository;
            _mediator = mediator;
        }
        
        public async Task Handle(StartAiProcessingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received StartAiProcessingEvent with text.");

            var text = _operationRepository.GetPresentationText(notification.OperationId);
            if (text == null)
            {
                _logger.LogWarning($"No presentation text found for operation {notification.OperationId}");
                return;
            }
            
            _operationRepository.UpdateStatus(notification.OperationId, OperationStatus.ProcessingAi);
            var mensagem = await _aiService.ProcessPresentationAsync(text);
            for (int i = 0; i < mensagem.Count; i++)
            {
                _logger.LogInformation($"Question {i + 1}: {mensagem[i]}");
            }

            _operationRepository.SaveAiFeedback(notification.OperationId, mensagem);

            await _mediator.Publish(new StartTtsProcessingEvent(notification.OperationId), cancellationToken);
        }
    }   
}