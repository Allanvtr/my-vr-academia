using MediatR;

namespace VrAudioCena.WebApi.Core.Events
{
    public class StartFileExtractionEvent : INotification
    {
        public string FilePath { get; }
        public Guid OperationId { get; init; }

        public StartFileExtractionEvent (string filePath, Guid operationId)
        {
            FilePath = filePath;
            OperationId = operationId;
        }
    }
}