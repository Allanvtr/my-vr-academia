namespace VrAudioCena.WebApi.Persistence
{
    public interface IOperationRepository
    {
        void Start(Guid operationId);
        void Finish(Guid operationId, string urlAudio);
        (bool Exists, string? urlAudio) Status(Guid operationId);
    }
}