namespace VrAudioCena.WebApi.Infrastructure.Services
{
    public interface IAIService
    {
        Task<List<string>> ProcessPresentationAsync (string text);
    }
}