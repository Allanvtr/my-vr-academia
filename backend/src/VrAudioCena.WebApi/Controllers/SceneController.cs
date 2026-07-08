using Microsoft.AspNetCore.Mvc;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Background;
using VrAudioCena.WebApi.Infrastructure.Persistence;
using VrAudioCena.WebApi.Infrastructure.Persistence.Models;

namespace VrAudioCena.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly EventQueue _eventQueue;
        private readonly MediatR.IMediator _mediator;
        private readonly ILogger<SceneController> _logger;

        public SceneController(
            IOperationRepository operationRepository, 
            EventQueue eventQueue, 
            MediatR.IMediator mediator, 
            ILogger<SceneController> logger)
        {
            _operationRepository = operationRepository;
            _eventQueue = eventQueue;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("start")]
        public async Task<IActionResult> UploadPdf(
            [FromForm] IFormFile file,
            [FromForm] int questionCount,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Question count: {QuestionCount}", questionCount);
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
            {
                return BadRequest("Only PDF files are allowed.");
            }

            var id = Guid.NewGuid();

            var tempPath = Path.Combine(
                Path.GetTempPath(),
                $"{id}.pdf");

            try
            {
                // Save the uploaded file temporarily
                await using (var stream = System.IO.File.Create(tempPath))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }

                // Initialize operation tracking
                _operationRepository.Start(id);

                // Extract text from PDF before starting AI processing
                await _mediator.Publish(
                    new StartFileExtractionEvent(tempPath, id),
                    cancellationToken);

                // Check if PDF extraction failed
                if (_operationRepository.TryGet(id, out var operation) &&
                    operation?.Status == OperationStatus.Failed)
                {
                    return BadRequest(new
                    {
                        operationId = id,
                        error = operation.ErrorMessage
                    });
                }

                // Start AI processing in background
                await _eventQueue.EnqueueAsync(
                    new StartAiProcessingEvent(id),
                    cancellationToken);

                return Accepted(new
                {
                    operationId = id
                });
            }
            catch (Exception ex)
            {
                // Remove temporary file if processing fails
                if (System.IO.File.Exists(tempPath))
                {
                    System.IO.File.Delete(tempPath);
                }

                _logger.LogError(
                    ex,
                    "Failed to upload and process PDF file.");

                return StatusCode(
                    500,
                    "Failed to process the uploaded file.");
            }
        }
    }   
}