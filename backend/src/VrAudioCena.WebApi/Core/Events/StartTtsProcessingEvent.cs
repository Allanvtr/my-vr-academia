using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
    public class StartTtsProcessingEvent : INotification
    {
        public Guid operationId { get; }

        public StartTtsProcessingEvent(Guid operationId)
        {
            this.operationId = operationId;
        }
    }
}