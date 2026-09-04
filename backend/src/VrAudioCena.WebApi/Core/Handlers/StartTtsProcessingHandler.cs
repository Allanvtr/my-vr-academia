using MediatR;
using Microsoft.AspNetCore.SignalR;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Services.Tts;
using VrAudioCena.WebApi.Infrastructure.Persistence;
using VrAudioCena.WebApi.Infrastructure.Persistence.Models;
using VrAudioCena.WebApi.Hubs;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartTtsProcessingHandler : INotificationHandler<StartTtsProcessingEvent>
    {
        private readonly ILogger<StartTtsProcessingHandler> _logger;
        private readonly ITextToSpeechService _textToSpeechService;
        private readonly IOperationRepository _operationRepository;
        private readonly IHubContext<SceneHub> _hubContext;

        public StartTtsProcessingHandler(
            ILogger<StartTtsProcessingHandler> logger, 
            ITextToSpeechService textToSpeechService,
            IOperationRepository operationRepository,
            IHubContext<SceneHub> hubContext)
        {
            _logger = logger;
            _textToSpeechService = textToSpeechService;
            _operationRepository = operationRepository;
            _hubContext = hubContext;
        }
        public async Task Handle (StartTtsProcessingEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received StartTtsProcessingEvent for operation {notification.operationId}.");
            
            _operationRepository.UpdateStatus(notification.operationId, OperationStatus.GeneratingAudio);
            
            var audioFiles = await _textToSpeechService.ConvertTextToSpeechAsync(notification.operationId, cancellationToken);

            _operationRepository.SaveAudio(notification.operationId, audioFiles);

            for (int i = 0; i < audioFiles.Count; i++)
            {
                _logger.LogInformation($"Audio file {i + 1}/{audioFiles.Count} generated: {audioFiles[i]}");
            }

            // await _hubContext.Clients.Group(notification.operationId.ToString())
            //     .SendAsync("AudioGenerated", audioFiles, cancellationToken);

            await _hubContext.Clients.All.SendAsync("AudioGenerated", audioFiles, cancellationToken);
        }
    }
}