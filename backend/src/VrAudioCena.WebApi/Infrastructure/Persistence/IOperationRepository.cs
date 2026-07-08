using VrAudioCena.WebApi.Infrastructure.Persistence.Models;

namespace VrAudioCena.WebApi.Infrastructure.Persistence
{
    public interface IOperationRepository
    {
        void Start(Guid operationId);
        string? GetPresentationText(Guid operationId);
        List<string>? GetAiFeedback(Guid operationId);
        void UpdateStatus(Guid operationId, OperationStatus status);

        void SavePresentationText(Guid operationId, string text);

        void SaveAiFeedback(Guid operationId, List<string> feedback);

        void SaveAudio(Guid operationId, List<string> urlAudio);

        void Fail(Guid operationId, string errorMessage);

        bool TryGet(Guid operationId, out OperationState? operation);
    }
}