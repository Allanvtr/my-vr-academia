using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
    public class StartTtsProcessingEvent : INotification
    {
        public List<string> Questions {get; set;} = new List<string>();

        public StartTtsProcessingEvent (List<String> questions)
        {
            Questions = questions;
        }
    }
}