namespace VrAudioCena.WebApi.Infrastructure.Persistence.Models
{
    public class OperationState
    {
        public OperationStatus Status { get; set; }

        public string? PresentationText { get; set; }

        public List<string>? AiFeedback { get; set; }

        public List<string>? AudioUrl { get; set; }

        public string? ErrorMessage { get; set; }
    }
}