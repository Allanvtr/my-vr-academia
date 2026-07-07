using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
    public class StartFileExtractionEvent : INotification
    {
        public required IFormFile File { get; init; }

        public StartFileExtractionEvent (IFormFile file)
        {
            File = file;
        }
    }
}