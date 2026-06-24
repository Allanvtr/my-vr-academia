using MediatR;
using VrAudioCena.WebApi.Core.Events;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartTtsProcessingHandler : INotificationHandler<StartTtsProcessingEvent>
    {
        public Task Handle (StartTtsProcessingEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}