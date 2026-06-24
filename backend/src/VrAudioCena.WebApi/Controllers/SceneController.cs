using Microsoft.AspNetCore.Mvc;
using VrAudioCena.WebApi.Core.Events;
using VrAudioCena.WebApi.Infrastructure.Background;
using VrAudioCena.WebApi.Persistence;

namespace VrAudioCena.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly EventQueue _eventQueue;

        public SceneController(IOperationRepository operationRepository, EventQueue eventQueue)
        {
            _operationRepository = operationRepository;
            _eventQueue = eventQueue;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from SceneController!");
        }

        [HttpPost("start")]
        public async Task<IActionResult> UploadPdf (IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
            {
                return BadRequest("Apenas arquivos PDF são permitidos.");
            }

            var id = Guid.NewGuid();

            _operationRepository.Start(id);

           // _eventQueue.EnqueueAsync(new StartAiProcessingEvent(...));

            return Accepted(new {operationId = id});
        }
    }   
}