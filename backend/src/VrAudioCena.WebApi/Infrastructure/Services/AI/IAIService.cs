namespace VrAudioCena.WebApi.Infrastructure.Services.AI
{
    public interface IAIService
    {
        Task<List<string>> ProcessPresentationAsync (string text, int questionCount);
    }
}