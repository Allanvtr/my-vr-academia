using VrAudioCena.WebApi.Core.Events;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartFileExtractionHandler : INotificationHandler<StartFileExtractionEvent>
    {
        public Task Handle(StartFileExtractionEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}