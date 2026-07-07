namespace VrAudioCena.WebApi.Infrastructure.Persistence.Models
{
    public enum OperationStatus
    {
        Pending,
        ExtractingPdf,
        ProcessingAi,
        GeneratingAudio,
        Completed,
        Failed
    }
}
