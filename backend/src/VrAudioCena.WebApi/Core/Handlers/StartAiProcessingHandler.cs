using MediatR;
using VrAudioCena.WebApi.Core.Events;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartAiProcessingHandler : INotificationHandler<StartAiProcessingEvent>
    {
        public Task Handle(StartAiProcessingEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }   
}