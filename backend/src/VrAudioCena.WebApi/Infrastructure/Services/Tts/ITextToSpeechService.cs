namespace VrAudioCena.WebApi.Infrastructure.Services.Tts
{
    public interface ITextToSpeechService
    {
        Task<List<string>> ConvertTextToSpeechAsync(Guid operationId, CancellationToken cancellationToken);
    }
}