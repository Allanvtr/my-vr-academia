using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
   public class StartAiProcessingEvent : INotification
    {
        public string Text {get; init;}

        public StartAiProcessingEvent(string text)
        {
            Text = text;
        }
    } 
}