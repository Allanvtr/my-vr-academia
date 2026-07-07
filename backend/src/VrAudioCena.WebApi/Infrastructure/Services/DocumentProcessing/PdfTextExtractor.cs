using System.Text;
using UglyToad.PdfPig;

namespace VrAudioCena.WebApi.Infrastructure.Services.DocumentProcessing
{
    public class PdfTextExtractor : IPdfTextExtractor
    {
        public string ExtractText(Stream stream)
        {
            var sb = new StringBuilder();

            using var document = PdfDocument.Open(stream);

            foreach (var page in document.GetPages())
            {
                sb.AppendLine(page.Text);
            }

            return sb.ToString();
        }
    }
}