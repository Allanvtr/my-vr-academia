using VrAudioCena.WebApi.Core.Events;
using MediatR;
using VrAudioCena.WebApi.Infrastructure.Services.DocumentProcessing;
using VrAudioCena.WebApi.Infrastructure.Persistence;
using VrAudioCena.WebApi.Infrastructure.Persistence.Models;

namespace VrAudioCena.WebApi.Core.Handlers
{
    public class StartFileExtractionHandler : INotificationHandler<StartFileExtractionEvent>
    {
        private readonly IPdfTextExtractor _pdfTextExtractor;
        private readonly IMediator _mediator;
        private readonly ILogger<StartFileExtractionHandler> _logger;
        private readonly IOperationRepository _operationRepository;

        public StartFileExtractionHandler(
            IPdfTextExtractor pdfTextExtractor, 
            IMediator mediator, 
            ILogger<StartFileExtractionHandler> logger, 
            IOperationRepository operationRepository)
        {
            _pdfTextExtractor = pdfTextExtractor;
            _mediator = mediator;
            _logger = logger;
            _operationRepository = operationRepository;
        }
        public Task Handle(
            StartFileExtractionEvent notification,
            CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation(
                    "Extracting text from file: {FilePath}",
                    notification.FilePath);

                _operationRepository.UpdateStatus(
                    notification.OperationId,
                    OperationStatus.ExtractingPdf);

                using var stream = File.OpenRead(notification.FilePath);

                var text = _pdfTextExtractor.ExtractText(stream);

                if (string.IsNullOrWhiteSpace(text))
                {
                    _logger.LogWarning(
                        "No text extracted from file: {FilePath}",
                        notification.FilePath);

                    _operationRepository.Fail(
                        notification.OperationId,
                        "No text extracted from the PDF file.");

                    return Task.CompletedTask;
                }

                _operationRepository.SavePresentationText(
                    notification.OperationId,
                    text);

                _logger.LogInformation(
                    "Text extracted successfully. Characters: {Length}",
                    text.Length);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to extract text from PDF.");

                _operationRepository.Fail(
                    notification.OperationId,
                    ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}