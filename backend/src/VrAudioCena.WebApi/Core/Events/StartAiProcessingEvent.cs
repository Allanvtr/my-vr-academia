using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
   public class StartAiProcessingEvent : INotification
    {
        public Guid OperationId {get; init;}
        public int QuestionCount {get; init;}

        public StartAiProcessingEvent(Guid operationId, int questionCount)
        {
            OperationId = operationId;
            QuestionCount = questionCount;
        }
    } 
}