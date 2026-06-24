using Microsoft.AspNetCore.Mvc;

namespace VrAudioCena.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from CenaController!");
        }

        [HttpPost("upload")]
        public IActionResult UploadPdf (IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".pdf")
            {
                return BadRequest("Apenas arquivos PDF são permitidos.");
            }

            return Ok("Arquivo Enviado com sucesso");
        }
    }   
}