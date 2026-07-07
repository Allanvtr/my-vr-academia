using System.Collections.Concurrent;
using VrAudioCena.WebApi.Infrastructure.Persistence.Models;

namespace VrAudioCena.WebApi.Infrastructure.Persistence
{
    public class MemoryOperationRepository : IOperationRepository
    {
        private readonly ConcurrentDictionary<Guid, OperationState> _operations = new();
        
        public void Start(Guid operationId)
        {
            _operations[operationId] = new OperationState
            {
                Status = OperationStatus.Pending
            };
        }


        public void UpdateStatus(Guid operationId, OperationStatus status)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                operation.Status = status;
            }
        }


        public void SavePresentationText(Guid operationId, string text)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                operation.PresentationText = text;
            }
        }

        public string? GetPresentationText(Guid operationId)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                return operation.PresentationText;
            }

            return null;
        }

        public void SaveAiFeedback(Guid operationId, List<string> feedback)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                operation.AiFeedback = feedback;
            }
        }


        public void SaveAudio(Guid operationId, string urlAudio)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                operation.AudioUrl = urlAudio;
                operation.Status = OperationStatus.Completed;
            }
        }


        public void Fail(Guid operationId, string errorMessage)
        {
            if (_operations.TryGetValue(operationId, out var operation))
            {
                operation.Status = OperationStatus.Failed;
                operation.ErrorMessage = errorMessage;
            }
        }


        public bool TryGet(Guid operationId, out OperationState? operation)
        {
            return _operations.TryGetValue(operationId, out operation);
        }
    }
}