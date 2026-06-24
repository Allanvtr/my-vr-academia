using System.Collections.Concurrent;

namespace VrAudioCena.WebApi.Persistence
{
    public class MemoryOperationRepository : IOperationRepository
    {
        private readonly ConcurrentDictionary<Guid, string?> _estados = new();

        public void Start(Guid operationId)
        {
            _estados[operationId] = null;
        }

        public void Finish(Guid operacaoId, string urlAudio)
        {
            _estados[operacaoId] = urlAudio;
        }
        public (bool Exists, string? urlAudio) Status(Guid operacaoId)
        {
            if (_estados.TryGetValue(operacaoId, out var urlAudio))
            {
                return (true, urlAudio);
            }
            
            return (false, null); 
        }
    }
}