using VrAudioCena.WebApi.Core.Events;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using VrAudioCena.WebApi.Infrastructure.Services.DocumentProcessing;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartFileExtractionHandler : INotificationHandler<StartFileExtractionEvent>
    {
        private readonly IPdfTextExtractor _pdfTextExtractor;

        public StartFileExtractionHandler(IPdfTextExtractor pdfTextExtractor)
        {
            _pdfTextExtractor = pdfTextExtractor;
        }
        public Task Handle(StartFileExtractionEvent notification, CancellationToken cancellationToken)
        {
            using var stream = notification.File.OpenReadStream();
            var text = _pdfTextExtractor.ExtractText(stream);

                        

            return Task.CompletedTask;
        }
    }
}