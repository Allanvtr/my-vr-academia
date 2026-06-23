using Microsoft.AspNetCore.Mvc;

namespace VrAudioCena.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenaController : ControllerBase
    {
        private readonly ILogger<CenaController> _logger;

        public CenaController(ILogger<CenaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from CenaController!");
        }
    }   
}