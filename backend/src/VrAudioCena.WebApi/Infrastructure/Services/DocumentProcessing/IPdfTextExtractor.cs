namespace VrAudioCena.WebApi.Infrastructure.Services.DocumentProcessing
{
    public interface IPdfTextExtractor
    {
        string ExtractText(Stream stream);
    }
}