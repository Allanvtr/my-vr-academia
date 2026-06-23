using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
   public class StartAiProcessingEvent : INotification
    {
        public string Text {get; set;}

        public StartAiProcessingEvent(string text)
        {
            Text = text;
        }
    } 
}