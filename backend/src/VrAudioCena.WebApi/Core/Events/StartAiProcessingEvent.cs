using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
   public class StartAiProcessingEvent : INotification
    {
        public Guid OperationId {get; init;}

        public StartAiProcessingEvent(Guid operationId)
        {
            OperationId = operationId;
        }
    } 
}